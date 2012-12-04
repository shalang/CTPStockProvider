using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace CalmBeltFund.Trading.CTPStock
{
  public partial class CTPStockTrader : CTPStockClient
  {

    private string userProductInfo = "";


    //报单引用为NUMBER(12)，需为单调递增的数字
    //内部扩展其格式为：nnnnn.MMM.TT.ii
    //    nnnnn ： Seq，递增序列（按每秒钟一单计算：4H × 60min × 60sec = 14400，5位数字已够用）
    //    MMM   ： ModelID，交易模块识别序号
    //    TT    ： OrderType，区分订单类型
    //    ii    ： Index，组合报单中单腿合约的序号
    const int BaseOrderRef = 1000000;
    int currentOrderRef = 0;

    public int CurrentOrderRef
    {
      get { return currentOrderRef; }
    }

    CTPStockInstrumentStatusType tradingStatus;

    //待调整
    bool isInitialized = true;
    bool isSimulationServer = false;



    //过滤RESTART模式下的，重推数据
    bool filterRestart = true;


    string loginTime = "";

    DateTime tradingDate = DateTime.MinValue;

    TimeSpan loginTimeDCE = TimeSpan.Zero;
    TimeSpan loginTimeCZCE = TimeSpan.Zero;
    TimeSpan loginTimeSHFE = TimeSpan.Zero;
    TimeSpan currentTimeDCE = TimeSpan.Zero;
    TimeSpan currentTimeCZCE = TimeSpan.Zero;
    TimeSpan currentTimeSHFE = TimeSpan.Zero;
    TimeSpan second = new TimeSpan(TimeSpan.TicksPerSecond);
    Stopwatch wallTimeStopwatch = new Stopwatch();

    Timer timer = null;

    CZQThostFtdcInvestorField investor;
    CZQThostFtdcTradingAccountField tradingAccount;

    //成交列表
    List<CZQThostFtdcTradeField> tradeList = new List<CZQThostFtdcTradeField>();
    //委托单列表
    List<CZQThostFtdcOrderField> orderList = new List<CZQThostFtdcOrderField>();

    List<CZQThostFtdcParkedOrderField> parkedOrderList = new List<CZQThostFtdcParkedOrderField>();
    List<CZQThostFtdcParkedOrderActionField> parkedOrderActionList = new List<CZQThostFtdcParkedOrderActionField>();

    //持仓列表
    List<CZQThostFtdcInvestorPositionField> positionList = new List<CZQThostFtdcInvestorPositionField>();
    //持仓明细列表
    List<CZQThostFtdcInvestorPositionDetailField> positionDetailList = new List<CZQThostFtdcInvestorPositionDetailField>();

    List<CZQThostFtdcTransferSerialField> transferSerialList = new List<CZQThostFtdcTransferSerialField>();


    //Dictionary<string, CTPExchange> exchanges = new Dictionary<string, CTPExchange>();
    Dictionary<string, CTPStockInstrument> instrumentDictionary = new Dictionary<string, CTPStockInstrument>();
    Dictionary<string, CTPStockInstrumentStatusType> exchangeStatus = new Dictionary<string, CTPStockInstrumentStatusType>();


    /// <summary>
    /// 查询队列中是否存在任务
    /// </summary>
    public bool HasQueryTask
    {
      get { return this.queryTasks.Count > 0; }
    }


    /// <summary>
    /// 是否已初始化
    /// </summary>
    public bool IsInitialized
    {
      get { return isInitialized; }
    }

    /// <summary>
    /// 是否是模拟服务器
    /// </summary>
    public bool IsSimulationServer
    {
      get { return isSimulationServer; }
    }

    /// <summary>
    /// 终端标识
    /// </summary>
    public string UserProductInfo
    {
      get { return userProductInfo; }
      set { userProductInfo = value; }
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserKey
    {
      get { return CTPStockOrderConvert.GetUserKey(InvestorID, BrokerID); }
    }


    /// <summary>
    /// 交易日
    /// </summary>
    public DateTime TradingDate
    {
      get { return tradingDate; }
    }

    /// <summary>
    /// 当前时间(大商所)
    /// </summary>
    public TimeSpan CurrentTimeDCE
    {
      get { return currentTimeDCE; }
    }

    /// <summary>
    /// 当前时间(郑交所)
    /// </summary>
    public TimeSpan CurrentTimeCZCE
    {
      get { return currentTimeCZCE; }
    }

    /// <summary>
    /// 当前时间(上期所)
    /// </summary>
    public TimeSpan CurrentTimeSHFE
    {
      get { return currentTimeSHFE; }
    }

    public CTPStockInstrumentStatusType TradingStatus
    {
      get { return tradingStatus; }
    }

    public Dictionary<string, CTPStockInstrumentStatusType> ExchangeStatus
    {
      get { return exchangeStatus; }
      set { exchangeStatus = value; }
    }

    public Dictionary<string, CTPStockInstrument> InstrumentDictionary
    {
      get { return instrumentDictionary; }
      set { instrumentDictionary = value; }
    }

    /// <summary>
    /// 投资者
    /// </summary>
    public CZQThostFtdcInvestorField Investor
    {
      get { return investor; }
    }

    //public Dictionary<string, CTPExchange> Exchanges
    //{
    //  get { return exchanges; }
    //  set { exchanges = value; }
    //}

    public CZQThostFtdcTradingAccountField TradingAccount
    {
      get { return tradingAccount; }
      set { tradingAccount = value; }
    }


    public List<CZQThostFtdcOrderField> OrderList
    {
      get { return orderList; }
      private set { orderList = value; }
    }

    public List<CZQThostFtdcTradeField> TradeList
    {
      get { return tradeList; }
      private set { tradeList = value; }
    }
    public List<CZQThostFtdcInvestorPositionField> PositionList
    {
      get { return positionList; }
      private set { positionList = value; }
    }

    public List<CZQThostFtdcInvestorPositionDetailField> PositionDetailList
    {
      get { return positionDetailList; }
      private set { positionDetailList = value; }
    }

    /// <summary>
    /// 转账明细
    /// </summary>
    public List<CZQThostFtdcTransferSerialField> TransferSerialList
    {
      get { return transferSerialList; }
      private set { transferSerialList = value; }
    }


    public CTPStockTrader()
    {

      timer = new Timer(new TimerCallback(this.UpdateTime));
      queryTaskTimer = new Timer(new TimerCallback(this.ProcessQueryTask));
    }



    /// <summary>
    /// 交易所时间
    /// </summary>
    /// <param name="obj"></param>
    void UpdateTime(object obj)
    {
      this.currentTimeDCE = this.loginTimeDCE.Add(wallTimeStopwatch.Elapsed);
      this.currentTimeCZCE = this.loginTimeCZCE.Add(wallTimeStopwatch.Elapsed);
      this.currentTimeSHFE = this.loginTimeSHFE.Add(wallTimeStopwatch.Elapsed);
    }

    public int IncrementOrderRef()
    {
      return Interlocked.Increment(ref this.currentOrderRef);
    }

    public CTPStockInstrument GetInstrument(string instrumentID)
    {

      if (string.IsNullOrEmpty(instrumentID))
      {
        return null;
      }

      if (instrumentDictionary.ContainsKey(instrumentID))
      {
        return instrumentDictionary[instrumentID];
      }
      else if (instrumentDictionary.ContainsKey(instrumentID.ToUpper()))
      {
        return instrumentDictionary[instrumentID.ToUpper()];
      }
      else if (instrumentDictionary.ContainsKey(instrumentID.ToLower()))
      {
        return instrumentDictionary[instrumentID.ToLower()];
      }
      else
      {
        return null;
      }
    }

    void SetInstrumentRate(CZQThostFtdcInstrumentCommissionRateField instrumentCommissionRate)
    {

      if (string.IsNullOrEmpty(instrumentCommissionRate.InstrumentID))
      {
        return;
      }


      //保存手续费信息
      CTPStockInstrument ctpInstrument = this.GetInstrument(instrumentCommissionRate.InstrumentID);
      if (ctpInstrument != null)
      {
        //单合约手续费
        ctpInstrument.SetNativeValue(instrumentCommissionRate);
      }
      else
      {
        //该品种手续费
        foreach (CTPStockInstrument item in this.instrumentDictionary.Values)
        {
          if (string.Compare(instrumentCommissionRate.InstrumentID, item.ProductID, true) == 0)
          {
            item.SetNativeValue(instrumentCommissionRate);
          }
        }
      }
    }


    /// <summary>
    /// 连接交易服务器
    /// </summary>
    /// <param name="frontAddress"></param>
    /// <param name="BrokerID"></param>
    /// <param name="InvestorID"></param>
    /// <param name="password"></param>
    public void Connect(string[] frontAddress, string BrokerID, string InvestorID, string password,bool restart = true)
    {

      this.BrokerID = BrokerID;
      this.InvestorID = InvestorID;
      this.Password = password;

      //创建Trader实例
      this.connTempFile = Path.GetTempFileName();
      //订阅
      int resumeMode = restart ? (int)CTPResumeType.TERT_RESTART : (int)CTPResumeType.TERT_QUICK;

      try
      {

        //创建
        _instance = (IntPtr)Process(Marshal.GetFunctionPointerForDelegate(this.callback), (int)CTPStockRequestAction.TraderApiCreate, (int)resumeMode, new StringBuilder(connTempFile));


        //注册前置机地址
        foreach (string front in frontAddress)
        {
          string address = front;

          if (address.StartsWith("tcp://", StringComparison.OrdinalIgnoreCase) == false)
          {
            address = "tcp://" + address;
          }

          Process(this._instance, (int)CTPStockRequestAction.TraderApiRegisterFront, 0, new StringBuilder(address));
          this.FrontAddress = front;
        }

        Process(this._instance, (int)CTPStockRequestAction.TraderApiInit, 0, null);
      }
      catch (Exception ex)
      {

        throw ex;
      }
    }

    void UserLogin()
    {
      CZQThostFtdcReqUserLoginField userLogin = new CZQThostFtdcReqUserLoginField();

      userLogin.BrokerID = this.BrokerID;
      userLogin.UserID = this.InvestorID;
      userLogin.Password = this.Password;
      userLogin.UserProductInfo = this.UserProductInfo;

      int result = InvokeAPI(CTPStockRequestAction.TraderApiUserLoginAction, userLogin);

      Trace.WriteLine("CTPTrader:UserLogin : " + result.ToString());
    }

    protected void UserLogout()
    {
      CZQThostFtdcUserLogoutField userLogout = new CZQThostFtdcUserLogoutField();

      userLogout.BrokerID = this.BrokerID;
      userLogout.UserID = this.InvestorID;

      int result = InvokeAPI(CTPStockRequestAction.TraderApiUserLogoutAction, userLogout);
    }

    public void InitExchangeInfo()
    {
      this.QueryExchange();
    }

    public void InitInstrumentInfo()
    {
      this.QueryInstrument();
    }

    public void InitInstrumentCommissionRate()
    {
      this.QueryInstrumentCommissionRate("");
    }

    public void InitializeData()
    {
      //确认结算单
      this.QueryOrder();
      this.QueryTrade();
      this.QueryInvestorPosition();
      this.QueryInvestorPositionDetail();

      this.QueryTradingAccount();
    }


    public void ChangePassword(string oldPassword, string newPassword)
    {

      CZQThostFtdcUserPasswordUpdateField req = new CZQThostFtdcUserPasswordUpdateField();

      req.BrokerID = this.BrokerID;
      req.UserID = this.InvestorID;
      req.OldPassword = oldPassword;
      req.NewPassword = newPassword;

      //CTPWrapper.TraderReqUserPasswordUpdate(this._instance, req, CreateRequestID());
      InvokeAPI(CTPStockRequestAction.UserPasswordUpdateAction, req);

    }

    #region 下单类请求


    public CZQThostFtdcInputOrderField InsertOrder(string exchangeID, string symbolCode, CTPStockDirectionType direct, double price, int volume)
    {
      CTPStockOffsetFlagType flag = CTPStockOffsetFlagType.Open;

      switch (direct)
      {
        case CTPStockDirectionType.Buy:
        case CTPStockDirectionType.ETFPur:
        case CTPStockDirectionType.MarginTrade:
        case CTPStockDirectionType.RepayMargin:
        case CTPStockDirectionType.DirectRepayMargin:
          flag = CTPStockOffsetFlagType.Open;
          break;

        case CTPStockDirectionType.Sell:
        case CTPStockDirectionType.ETFRed:
        case CTPStockDirectionType.ShortSell:
        case CTPStockDirectionType.RepayStock:
        case CTPStockDirectionType.DirectRepayStock:
          flag = CTPStockOffsetFlagType.Close;
          break;
        case CTPStockDirectionType.TransferSecurities:
          flag = CTPStockOffsetFlagType.Open;
          break;
        default:
          break;
      }

      CZQThostFtdcInputOrderField order = CreateInputOrder(exchangeID, symbolCode, direct, flag, price, volume);

      SendInsertOrder(order);

      return order;
    }

    public CZQThostFtdcInputOrderField InsertOrder(string symbolCode, CTPStockDirectionType direct, double price, int volume)
    {
      CTPStockInstrument inst = GetInstrument(symbolCode);

      if (inst == null)
      {
        throw new Exception("unknow symbol:" + symbolCode);
      }

      return InsertOrder(inst.ExchangeID, symbolCode, direct, price, volume);
    }

    private int SendInsertOrder(CZQThostFtdcInputOrderField order)
    {
      //return CTPWrapper.TraderReqOrderInsert(this._instance, order, CreateRequestID());
      Trace.WriteLine(string.Format("{0} [{1}]:{2},{3},{4}", this.wallTimeStopwatch.ElapsedMilliseconds, this.UserKey, "SendInsertOrder", order.OrderRef, order.RequestID));
      return InvokeAPI(CTPStockRequestAction.OrderInsertAction, order);
    }


    private CZQThostFtdcInputOrderField CreateInputOrder(string exchangeID,string symbolCode, CTPStockDirectionType direct, CTPStockOffsetFlagType flag,double price,int volume, string orderRef = "")
    {
 
      CZQThostFtdcInputOrderField order = new CZQThostFtdcInputOrderField();

      order.BrokerID = this.BrokerID;
      order.InvestorID = this.InvestorID;

      //合约
      order.ExchangeID = exchangeID;
      order.InstrumentID = symbolCode;

      if (string.IsNullOrEmpty(orderRef))
      {
        order.OrderRef = System.Threading.Interlocked.Increment(ref this.currentOrderRef).ToString();
      }
      else
      {
        order.OrderRef = orderRef;
      }
      

      //限价单
      order.OrderPriceType = CTPStockOrderPriceType.LimitPrice;

      //方向
      order.Direction = direct;

      //开平仓
      order.CombOffsetFlag = new byte[] { (byte)flag, 0, 0, 0, 0 };

      //投机/套保
      order.CombHedgeFlag = new byte[] { (byte)CTPStockHedgeFlagType.Speculation, 0, 0, 0, 0 };

      ///价格
      order.LimitPrice = price.ToString();
      ///数量: 1
      order.VolumeTotalOriginal = volume;
      ///有效期类型: 当日有效
      order.TimeCondition = CTPStockTimeConditionType.GFD;
      ///GTD日期
      //	TThostFtdcDateType	GTDDate;
      ///成交量类型: 任何数量
      order.VolumeCondition = CTPStockVolumeConditionType.AV;
      ///最小成交量: 1
      order.MinVolume = 1;
      ///触发条件: 立即
      order.ContingentCondition = CTPStockContingentConditionType.Immediately;
      ///强平原因: 非强平
      order.ForceCloseReason = CTPStockForceCloseReasonType.NotForceClose;
      ///自动挂起标志: 是
      order.IsAutoSuspend = true;
 
      ///用户强评标志: 否
      order.UserForceClose = false;


      //条件单处理内容
      //if (parameter.OrderType == OrderType.ConditionOrder)
      //{

      //  //条件触发价
      //  order.StopPrice = (double)parameter.ConditionPrice;

      //  //报价方式
      //  if (order.OrderPriceType != CTPStockOrderPriceType.LimitPrice)
      //  {
      //    order.LimitPrice = "0";
      //  }
      //}

      return order;
    }

    public CZQThostFtdcInputOrderActionField DeleteOrder(CZQThostFtdcOrderField order)
    {
      CZQThostFtdcInputOrderActionField orderAction = new CZQThostFtdcInputOrderActionField();

      orderAction.BrokerID = order.BrokerID;
      orderAction.InvestorID = order.InvestorID;
      orderAction.TraderID = order.TraderID;

      orderAction.FrontID = order.FrontID;
      orderAction.SessionID = order.SessionID;
      orderAction.RequestID = order.RequestID;
      orderAction.OrderRef = order.OrderRef;
      orderAction.OrderLocalID = order.OrderLocalID;

      orderAction.ExchangeID = order.ExchangeID;
      orderAction.InstrumentID = order.InstrumentID;

      orderAction.ActionFlag = CTPStockActionFlagType.Delete;

      InvokeAPI(CTPStockRequestAction.OrderActionAction, orderAction);

      return orderAction;
    }

    public CZQThostFtdcInputOrderActionField DeleteOrder(CZQThostFtdcInputOrderField order)
    {
      //撤单时，会引发报单时间小于登录时间的报单回报，
      //因此需要关闭过滤 FLag
      this.filterRestart = false;


      CZQThostFtdcInputOrderActionField orderAction = new CZQThostFtdcInputOrderActionField();

      orderAction.BrokerID = order.BrokerID;
      orderAction.InvestorID = order.InvestorID;

      orderAction.FrontID = this.FrontID;
      orderAction.SessionID = this.SessionID;
      orderAction.OrderRef = order.OrderRef;

      orderAction.InstrumentID = order.InstrumentID;

      orderAction.ActionFlag = CTPStockActionFlagType.Delete;

      //CTPWrapper.TraderReqOrderAction(this._instance, orderAction, CreateRequestID());
      InvokeAPI(CTPStockRequestAction.OrderActionAction, orderAction);

      return orderAction;
    }

    #endregion

    #region 查询类请求



    /// <summary>
    /// 查询交易编码
    /// </summary>
    public void QueryTradingCode()
    {
      CZQThostFtdcQryTradingCodeField req = new CZQThostFtdcQryTradingCodeField();

      req.BrokerID = BrokerID;
      req.InvestorID = InvestorID;
      //req.ExchangeID

      AddQueryTask(req, CTPStockRequestAction.QueryTradingCodeAction);
      //int iResult = CTPWrapper.TraderReqQryTradingCode(this._instance, req, ++nRequestID);
    }


    /// <summary>
    /// 投资者查询
    /// </summary>
    public void QueryInvestor()
    {
      CZQThostFtdcQryInvestorField req = new CZQThostFtdcQryInvestorField();

      req.BrokerID = BrokerID;
      req.InvestorID = InvestorID;

      AddQueryTask(req, CTPStockRequestAction.QueryInvestorAction);
      //int iResult = CTPWrapper.TraderReqQryInvestor(this._instance, req, ++nRequestID);

    }

    public void QueryTradingAccount()
    {
      CZQThostFtdcQryTradingAccountField req = new CZQThostFtdcQryTradingAccountField();

      req.BrokerID = this.BrokerID;
      req.InvestorID = this.InvestorID;

      AddQueryTask(req, CTPStockRequestAction.QueryTradingAccountAction);
      //int iResult = CTPWrapper.TraderReqQryTradingAccount(this._instance, req, ++nRequestID);
    }

    /// <summary>
    /// 查询指定合约
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QueryInstrument(string exchangeID,string instrumentID)
    {
      CZQThostFtdcQryInstrumentField req = new CZQThostFtdcQryInstrumentField();

      req.ExchangeID = exchangeID;
      req.InstrumentID = instrumentID;

      AddQueryTask(req, CTPStockRequestAction.QueryInstrumentAction);
      //int iResult = CTPWrapper.TraderReqQryInstrument(this._instance, req, ++nRequestID);
    }

    /// <summary>
    /// 查询指定市场的合约
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QueryInstrument(string exchangeID)
    {
      this.QueryInstrument(exchangeID, "");
    }
    
    /// <summary>
    /// 查询全部合约
    /// </summary>
    public void QueryInstrument()
    {
      this.QueryInstrument("", "");
    }


    /// <summary>
    /// 查询合约手续费
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QueryInstrumentCommissionRate(string instrumentID)
    {
      CZQThostFtdcQryInstrumentCommissionRateField req = new CZQThostFtdcQryInstrumentCommissionRateField();

      req.BrokerID = this.BrokerID;
      req.InvestorID = this.InvestorID;
      
      req.InstrumentID = instrumentID;

      AddQueryTask(req, CTPStockRequestAction.QueryInstrumentCommissionRateAction);
      //int iResult = CTPWrapper.TraderReqQryInstrumentCommissionRate(this._instance, req, ++nRequestID);
    }


    /// <summary>
    /// 查询成交情况
    /// </summary>
    public void QueryTrade()
    {
      CZQThostFtdcQryTradeField req = new CZQThostFtdcQryTradeField();

      req.BrokerID = BrokerID;
      req.InvestorID = InvestorID;

      this.tradeList = new List<CZQThostFtdcTradeField>();

      this.AddQueryTask(req, CTPStockRequestAction.QueryTradeAction);
      //int iResult = CTPWrapper.TraderReqQryTrade(this._instance, req, ++nRequestID);

    }

    /// <summary>
    /// 持仓情况查询
    /// </summary>
    public void QueryInvestorPosition()
    {
      CZQThostFtdcQryInvestorPositionField req = new CZQThostFtdcQryInvestorPositionField();

      req.BrokerID = BrokerID;
      req.InvestorID = InvestorID;

      this.positionList = new List<CZQThostFtdcInvestorPositionField>();

      this.AddQueryTask(req, CTPStockRequestAction.QueryInvestorPositionAction);
      //int iResult = CTPWrapper.TraderReqQryInvestorPosition(this._instance, req, ++nRequestID);

    }

    /// <summary>
    /// 持仓明细查询
    /// </summary>
    public void QueryInvestorPositionDetail()
    {
      CZQThostFtdcQryInvestorPositionDetailField req = new CZQThostFtdcQryInvestorPositionDetailField();

      req.BrokerID = BrokerID;
      req.InvestorID = InvestorID;

      this.positionDetailList = new List<CZQThostFtdcInvestorPositionDetailField>();

      this.AddQueryTask(req, CTPStockRequestAction.QueryInvestorPositionDetailAction);
      //int iResult = CTPWrapper.TraderReqQryInvestorPositionDetail(this._instance, req, ++nRequestID);

    }


    /// <summary>
    /// 报单查询
    /// </summary>
    public void QueryOrder()
    {
      CZQThostFtdcQryOrderField req = new CZQThostFtdcQryOrderField();

      req.BrokerID = BrokerID;
      req.InvestorID = InvestorID;

      //lock (this.orderList)
      //{
      //  this.orderList.Clear();
      //}

      this.AddQueryTask(req, CTPStockRequestAction.QueryOrderAction);
      //int iResult = CTPWrapper.TraderReqQryOrder(this._instance, req, ++nRequestID);

    }


    /// <summary>
    /// 查询行情
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QueryDepthMarketData(string instrumentID)
    {
      CZQThostFtdcQryDepthMarketDataField req = new CZQThostFtdcQryDepthMarketDataField();

      req.InstrumentID = instrumentID;

      //int iResult = CTPWrapper.TraderReqQryDepthMarketData(this._instance, req, ++nRequestID);
      this.AddQueryTask(req, CTPStockRequestAction.QueryDepthMarketDataAction);
    }

    /// <summary>
    /// 查询交易所
    /// </summary>
    /// <param name="exchangeID"></param>
    public void QueryExchange()
    {
      CZQThostFtdcQryExchangeField req = new CZQThostFtdcQryExchangeField();

      req.ExchangeID = "";

      this.AddQueryTask(req, CTPStockRequestAction.QueryExchangeAction);
      //int iResult = CTPWrapper.TraderReqQryExchange(this._instance, req, ++nRequestID);
    }


    #endregion


    protected override void ProcessBusinessResponse(CTPStockResponseType responseType, IntPtr pData, CTPResponseInfo rspInfo, int requestID)
    {

      Trace.WriteLine(string.Format("{0} [{1}]:{2},{3},{4}", this.wallTimeStopwatch.ElapsedMilliseconds, this.UserKey, "ProcessBusinessResponse", responseType, requestID));

      switch (responseType)
      {
        #region 当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
        case CTPStockResponseType.FrontConnectedResponse:
          {

            this.isConnect = true;

            this.UserLogin();

            //调用事件
            OnEventHandler(CTPStockResponseType.FrontConnectedResponse, new CTPEventArgs());

            break;
          }
        #endregion

        #region 通信中断
        case CTPStockResponseType.FrontDisconnectedResponse:
          ///  当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
          ///@param nReason 错误原因
          ///        0x1001 网络读失败
          ///        0x1002 网络写失败
          ///        0x2001 接收心跳超时
          ///        0x2002 发送心跳失败
          ///        0x2003 收到错误报文
          {
            this.isConnect = false;

            //调用事件
            OnEventHandler(CTPStockResponseType.FrontDisconnectedResponse, new CTPEventArgs());
          }
          break;
        #endregion

        #region 心跳超时警告
        case CTPStockResponseType.HeartBeatWarningResponse:
          {
            /// <summary>
            ///心跳超时警告。当长时间未收到报文时，该方法被调用。
            ///@param nTimeLapse 距离上次接收报文的时间
            /// </summary>
            /// <param name="nTimeLapse"></param>
            Trace.WriteLine("CTPTrader:OnHeartBeatWarning!!  " + pData.ToString());
            break;
          }
        #endregion

        #region 客户端认证响应
        case CTPStockResponseType.AuthenticateResponse:
          {
            CTPEventArgs<CZQThostFtdcRspAuthenticateField> args = CreateEventArgs<CZQThostFtdcRspAuthenticateField>(requestID, rspInfo);

            this.OnEventHandler(CTPStockResponseType.AuthenticateResponse, args);

            break;
          }
        #endregion

        #region 用户登录
        case CTPStockResponseType.UserLoginResponse:
          {

            CTPEventArgs<CZQThostFtdcRspUserLoginField> args = CreateEventArgs<CZQThostFtdcRspUserLoginField>(requestID, rspInfo);

            CZQThostFtdcRspUserLoginField userLogin = args.Value;


            if (rspInfo.ErrorID == 0)
            {

              this.BrokerID = userLogin.BrokerID;
              this.FrontID = userLogin.FrontID;
              this.SessionID = userLogin.SessionID;
              this.isLogin = true;
              this.loginTime = userLogin.LoginTime;

              //最大报单引用
              int orderRef = 0;

              if (int.TryParse(userLogin.MaxOrderRef, out orderRef) == false)
              {
                orderRef = 0;
              }

              this.currentOrderRef = orderRef;
              //this.currentOrderRef++;

              DateTime.TryParseExact(userLogin.TradingDay, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out this.tradingDate);
              TimeSpan.TryParse(userLogin.DCETime, out this.loginTimeDCE);
              TimeSpan.TryParse(userLogin.CZCETime, out this.loginTimeCZCE);
              TimeSpan.TryParse(userLogin.SHFETime, out this.loginTimeSHFE);
              //TimeSpan.TryParse(userLogin.DCETime, out this.currentTimeDCE);

              this.wallTimeStopwatch.Start();
              this.timer.Change(0, 1000);

            }

            this.OnEventHandler(CTPStockResponseType.UserLoginResponse, args);
          }
          break;
        #endregion

        #region 登出请求响应
        case CTPStockResponseType.UserLogoutResponse:
          {
            this.isLogin = false;

            //调用事件
            OnEventHandler(CTPStockResponseType.UserLogoutResponse, new CTPEventArgs());
            break;
          }
        #endregion


        #region 用户口令更新请求响应
        case CTPStockResponseType.UserPasswordUpdateResponse:
          /// <summary>
          /// 用户口令更新请求响应
          /// </summary>
          {
            CTPEventArgs<CZQThostFtdcUserPasswordUpdateField> args = CreateEventArgs<CZQThostFtdcUserPasswordUpdateField>(requestID, rspInfo);

            this.OnEventHandler(CTPStockResponseType.UserPasswordUpdateResponse, args);

            break;
          }
        #endregion

        #region 报单录入请求响应
        case CTPStockResponseType.OrderInsertResponse:
          {

            CTPEventArgs<CZQThostFtdcInputOrderField> args = CreateEventArgs<CZQThostFtdcInputOrderField>(requestID, rspInfo);

            //调用事件
            OnEventHandler(CTPStockResponseType.OrderInsertResponse, args);

            break;
          }
        #endregion

        #region 改单响应
        case CTPStockResponseType.OrderActionResponse:
          {
            CTPEventArgs<CZQThostFtdcInputOrderActionField> args = CreateEventArgs<CZQThostFtdcInputOrderActionField>(requestID, rspInfo);

            //调用事件
            OnEventHandler(CTPStockResponseType.OrderActionResponse, args);

            break;
          }
        #endregion

        #region 查询最大报单数量响应
        case CTPStockResponseType.QueryMaxOrderVolumeResponse:
          {
            CTPEventArgs<CZQThostFtdcQueryMaxOrderVolumeField> args = CreateEventArgs<CZQThostFtdcQueryMaxOrderVolumeField>(requestID, rspInfo);

            this.OnEventHandler(CTPStockResponseType.QueryMaxOrderVolumeResponse, args);

            break;
          }
        #endregion

        #region 查询报单响应
        case CTPStockResponseType.QueryOrderResponse:
          {
            CTPEventArgs<List<CZQThostFtdcOrderField>> args = CreateListEventArgs<CZQThostFtdcOrderField>(requestID, rspInfo);

            lock (this.OrderList)
            {
              this.OrderList.Clear();
              this.OrderList.AddRange(args.Value);
            }

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryOrderResponse, args);

            break;
          }
        #endregion

        #region 查询成交单响应
        case CTPStockResponseType.QueryTradeResponse:
          {
            CTPEventArgs<List<CZQThostFtdcTradeField>> args = CreateListEventArgs<CZQThostFtdcTradeField>(requestID, rspInfo);

            this.TradeList = args.Value;

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryTradeResponse, args);

            break;
          }
        #endregion

        #region 查询投资者持仓响应
        case CTPStockResponseType.QueryInvestorPositionResponse:
          {
            CTPEventArgs<List<CZQThostFtdcInvestorPositionField>> args = CreateListEventArgs<CZQThostFtdcInvestorPositionField>(requestID, rspInfo);

            this.PositionList = args.Value;

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryInvestorPositionResponse, args);
            break;
          }
        #endregion

        #region 查询资金账户响应
        case CTPStockResponseType.QueryTradingAccountResponse:
          {

            /// 查询资金账户响应

            CTPEventArgs<CZQThostFtdcTradingAccountField> args = CreateEventArgs<CZQThostFtdcTradingAccountField>(requestID, rspInfo);

            this.tradingAccount = args.Value;

            this.OnEventHandler(CTPStockResponseType.QueryTradingAccountResponse, args);

            break;
          }
        #endregion

        #region 查询投资者响应
        case CTPStockResponseType.QueryInvestorResponse:
          {
            CTPEventArgs<CZQThostFtdcInvestorField> args = CreateEventArgs<CZQThostFtdcInvestorField>(requestID, rspInfo);

            this.investor = args.Value;

            this.OnEventHandler(CTPStockResponseType.QueryInvestorResponse, args);

            break;
          }
        #endregion

        #region 请求查询交易编码响应
        case CTPStockResponseType.QueryTradingCodeResponse:
          {
            CTPEventArgs<CZQThostFtdcTradingCodeField> args = CreateEventArgs<CZQThostFtdcTradingCodeField>(requestID, rspInfo);

            this.OnEventHandler(CTPStockResponseType.QueryTradingCodeResponse, args);

            break;
          }
        #endregion

        #region 查询手续费响应
        case CTPStockResponseType.QueryInstrumentCommissionRateResponse:
          {
            CTPEventArgs<CZQThostFtdcInstrumentCommissionRateField> args = CreateEventArgs<CZQThostFtdcInstrumentCommissionRateField>(requestID, rspInfo);

            this.SetInstrumentRate(args.Value);

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryInstrumentCommissionRateResponse, args);

            break;
          }
        #endregion

        #region 查询交易所响应
        case CTPStockResponseType.QueryExchangeResponse:
          {

            CTPEventArgs<CZQThostFtdcExchangeField> args = CreateEventArgs<CZQThostFtdcExchangeField>(requestID, rspInfo);

            //保存市场信息
            //CTPExchange ctpExchange = new CTPExchange();
            //ctpExchange.SetNativeValue(args.Value);
            //this.Exchanges.Add(args.Value.ExchangeID, ctpExchange);

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryExchangeResponse, args);

            break;
          }
        #endregion

        #region 查询合约响应
        case CTPStockResponseType.QueryInstrumentResponse:
          {

            CTPEventArgs<List<CZQThostFtdcInstrumentField>> values = CreateListEventArgs<CZQThostFtdcInstrumentField>(requestID, rspInfo);

            foreach (var instrument in values.Value)
            {

              if (instrument.ProductClass == CTPStockProductClassType.EFP || 
                instrument.ProductClass == CTPStockProductClassType.Futures || 
                instrument.ProductClass == CTPStockProductClassType.Options)
              {
                continue;
              }

              CTPStockInstrument ctpInstrument = new CTPStockInstrument();
              ctpInstrument.SetNativeValue(instrument);

              //加入到市场列表
              //if (this.Exchanges.ContainsKey(ctpInstrument.ExchangeID))
              //{
              //  this.Exchanges[instrument.ExchangeID].Instruments.Add(ctpInstrument);
              //}

              //if (this.SymbolProducts.ContainsKey(ctpInstrument.ProductID.ToUpper()) == false)
              //{
              //  this.SymbolProducts.Add(ctpInstrument.ProductID.ToUpper(), new CTPSymbolProduct(instrument));
              //}

              //加入到合约表
              if (this.InstrumentDictionary.ContainsKey(ctpInstrument.ID) == false)
              {
                this.InstrumentDictionary.Add(ctpInstrument.ID, ctpInstrument);
              }
            }

            //创建新的事件参数
            List<CTPStockInstrument> list = new List<CTPStockInstrument>(this.InstrumentDictionary.Values);
            CTPEventArgs<List<CTPStockInstrument>> args = new CTPEventArgs<List<CTPStockInstrument>>(list);

            //调用事件
            //OnEventHandler(CTPStockResponseType.QueryInstrumentResponse, args);
            OnEventHandler(CTPStockResponseType.QueryInstrumentResponse, values);

            break;
          }
        #endregion

        #region 查询行情响应
        case CTPStockResponseType.QueryDepthMarketDataResponse:
          {
            CTPEventArgs<CZQThostFtdcDepthMarketDataField> args = CreateEventArgs<CZQThostFtdcDepthMarketDataField>(requestID, rspInfo);

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryDepthMarketDataResponse, args);

            break;
          }
        #endregion

        #region 查询投资者持仓明细响应
        case CTPStockResponseType.QueryInvestorPositionDetailResponse:
          {

            CTPEventArgs<List<CZQThostFtdcInvestorPositionDetailField>> args = CreateListEventArgs<CZQThostFtdcInvestorPositionDetailField>(requestID, rspInfo);

            this.PositionDetailList = args.Value;

            //调用事件
            OnEventHandler(CTPStockResponseType.QueryInvestorPositionDetailResponse, args);

            break;
          }
        #endregion

        #region 错误回报
        case CTPStockResponseType.ErrorResponse:
          {
            this.OnEventHandler(CTPStockResponseType.ErrorResponse, new CTPEventArgs(rspInfo));
            break;
          }
        #endregion

        #region 报单回报
        case CTPStockResponseType.ReturnOrderResponse:
          {

            CTPEventArgs<CZQThostFtdcOrderField> args = CreateEventArgs<CZQThostFtdcOrderField>(pData, rspInfo);

            lock (this.orderList)
            {
              CTPStockOrderConvert.AppendOrReplaceOrder(this.orderList, args.Value);
            }


            if (this.filterRestart == true && this.isInitialized == false)
            {
            }
            else
            {
              //调用事件
              OnEventHandler(CTPStockResponseType.ReturnOrderResponse, args);
            }

            break;
          }
        #endregion

        #region 成交回报
        case CTPStockResponseType.ReturnTradeResponse:
          {

            CTPEventArgs<CZQThostFtdcTradeField> args = CreateEventArgs<CZQThostFtdcTradeField>(pData, rspInfo);

            //插入到列表中
            CTPStockOrderConvert.AppendOrReplaceOrder(this.tradeList, args.Value);

            if (this.filterRestart == true && this.isInitialized == false)
            {
            }
            else
            {
              //调用事件
              OnEventHandler(CTPStockResponseType.ReturnTradeResponse, args);
            }

            break;
          }
        #endregion

        #region 错单回报
        case CTPStockResponseType.ErrorReturnOrderInsertResponse:
          {
            if (this.filterRestart == true && this.isInitialized == false)
            {
            }
            else
            {
              CTPEventArgs<CZQThostFtdcInputOrderField> args = CreateEventArgs<CZQThostFtdcInputOrderField>(pData, rspInfo);

              //调用事件
              OnEventHandler(CTPStockResponseType.ErrorReturnOrderInsertResponse, args);
            }
            break;
          }
        #endregion

        #region 报单操作错误回报
        case CTPStockResponseType.ErrorReturnOrderActionResponse:
          {
            if (this.filterRestart == true && this.isInitialized == false)
            {
            }
            else
            {
              CTPEventArgs<CZQThostFtdcOrderActionField> args = CreateEventArgs<CZQThostFtdcOrderActionField>(pData, rspInfo);

              //调用事件
              OnEventHandler(CTPStockResponseType.ErrorReturnOrderActionResponse, args);
            }

            break;
          }
        #endregion

        #region 合约交易状态通知
        case CTPStockResponseType.ReturnInstrumentStatusResponse:
          {

            CTPEventArgs<CZQThostFtdcInstrumentStatusField> args = CreateEventArgs<CZQThostFtdcInstrumentStatusField>(pData, rspInfo);

            CZQThostFtdcInstrumentStatusField instrumentStatus = args.Value;

            Trace.WriteLine(string.Format("{0}:{1}", instrumentStatus.ExchangeID, instrumentStatus.InstrumentStatus));

            //交易所状态
            if (this.exchangeStatus.ContainsKey(instrumentStatus.ExchangeID) == false)
            {
              this.exchangeStatus.Add(instrumentStatus.ExchangeID, instrumentStatus.InstrumentStatus);
            }
            //更新交易所状态
            this.exchangeStatus[instrumentStatus.ExchangeID] = instrumentStatus.InstrumentStatus;

            this.tradingStatus = instrumentStatus.InstrumentStatus;

            //调用事件
            OnEventHandler(CTPStockResponseType.ReturnInstrumentStatusResponse, args);

            break;
          }
        #endregion


        default:
          break;
      }
    }


    #region IDisposable 成员

    public override void Dispose()
    {

      if (this.isDispose == true)
      {
        return;
      }

      this.isDispose = true;

      try
      {
        if (this._instance != IntPtr.Zero)
        {
          //CTPWrapper.TraderRegisterSpi(this._instance, IntPtr.Zero);
          //CTPWrapper.TraderRelease(this._instance);
          Process(this._instance, (int)CTPStockRequestAction.TraderApiRelease, 0, null);

          this._instance = IntPtr.Zero;
        }

      }
      catch (Exception ex)
      {

      }
      finally
      {

        this.timer.Change(Timeout.Infinite, Timeout.Infinite);
        this.wallTimeStopwatch.Stop();

        this.queryTaskTimer.Change(Timeout.Infinite, Timeout.Infinite);
        this.queryTasks.Clear();

        this.processedTasks.Clear();
        this.orderList.Clear();

        this.orderList.Clear();
        this.tradeList.Clear();
        this.positionList.Clear();
        this.positionDetailList.Clear();
        this.parkedOrderList.Clear();
        this.parkedOrderActionList.Clear();

      }

      base.Dispose();
    }

    void DeleteTempFile(string filePath)
    {
      try
      {
        if (File.Exists(filePath))
        {
          File.Delete(filePath);
        }
      }
      catch(Exception)
      {

      }

    }

    #endregion

    #region CTP API Invoke


    /// <summary>
    /// 调用CTP接口
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    protected int InvokeAPI(CTPStockTask task)
    {
      int result = -1;

      try
      {
        result = InvokeAPI(this._instance, (int)task.Action, task.Parameter, task.RequestID);
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return result;
    }

    #endregion


    public override bool Equals(object obj)
    {

      if (obj == null)
      {
        return false;
      }

      if (obj is CTPStockTrader)
      {
        CTPStockTrader trader = obj as CTPStockTrader;

        if (trader == this)
        {
          return true;
        }
        else
        {
          return trader.UserKey == this.UserKey;
        }
      }
      else
      {
        return false;
      }
    }

    public override int GetHashCode()
    {
      return this.UserKey.GetHashCode();
    }



  }
}
