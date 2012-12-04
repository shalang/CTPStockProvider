using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalmBeltFund.Trading.CTPStock;

namespace CalmBeltFund.Trading.CTPStock
{

  /// <summary>
  /// 请求动作
  /// </summary>
  public enum CTPStockRequestAction : int
  {
    /// <summary>
    /// 创建交易接口
    /// </summary>
    TraderApiCreate = 1,


    /// <summary>
    /// 删除接口对象本身
    /// </summary>
    TraderApiRelease,

    /// <summary>
    /// 初始化
    /// </summary>
    TraderApiInit,

    /// <summary>
    /// 等待接口线程结束运行
    /// </summary>
    TraderApiJoin,

    /// <summary>
    /// 获取当前交易日
    /// </summary>
    TraderApiGetTradingDay,

    /// <summary>
    /// 注册前置机网络地址
    /// </summary>
    TraderApiRegisterFront,

    /// <summary>
    /// 注册前置机网络地址
    /// </summary>
    TraderApiRegisterNameServer,

    /// <summary>
    /// 注册回调接口
    /// </summary>
    TraderApiRegisterSpi,

    /// <summary>
    /// 订阅私有流。
    /// </summary>
    TraderApiSubscribePrivateTopic,

    /// <summary>
    /// 订阅公共流。
    /// </summary>
    TraderApiSubscribePublicTopic,

    /// <summary>
    /// 客户端认证请求
    /// </summary>
    TraderApiAuthenticate,

    /// <summary>
    /// 用户登录请求
    /// </summary>
    TraderApiUserLoginAction,

    /// <summary>
    /// 登出请求
    /// </summary>
    TraderApiUserLogoutAction,


    ///创建MdApi
    ///@param pszFlowPath 存贮订阅信息文件的目录，默认为当前目录
    ///@return 创建出的UserApi
    ///modify for udp marketdata
    MarketDataCreate,

    ///删除接口对象本身
    ///@remark 不再使用本接口对象时,调用该函数删除接口对象
    MarketDataRelease,

    ///初始化
    ///@remark 初始化运行环境,只有调用后,接口才开始工作
    MarketDataInit,

    ///等待接口线程结束运行
    ///@return 线程退出代码
    MarketDataJoin,

    ///获取当前交易日
    ///@retrun 获取到的交易日
    ///@remark 只有登录成功后,才能得到正确的交易日
    MarketDataGetTradingDay,

    ///注册前置机网络地址
    ///@param pszFrontAddress：前置机网络地址。
    ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
    ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
    MarketDataRegisterFront,

    ///注册名字服务器网络地址
    ///@param pszNsAddress：名字服务器网络地址。
    ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
    ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
    ///@remark RegisterNameServer优先于RegisterFront
    MarketDataRegisterNameServer,

    ///注册回调接口
    ///@param pSpi 派生自回调接口类的实例
    MarketDataRegisterSpi,

    ///用户登录请求
    MarketDataUserLoginAction,

    ///登出请求
    MarketDataUserLogoutAction,

    ///订阅行情。
    ///@param ppInstrumentID 合约ID  
    ///@param nCount 要订阅/退订行情的合约个数
    ///@remark 
    MarketDataSubscribeMarketData,

    ///退订行情。
    ///@param ppInstrumentID 合约ID  
    ///@param nCount 要订阅/退订行情的合约个数
    ///@remark 
    MarketDataUnSubscribeMarketData,

    /// <summary>
    /// 用户口令更新请求
    /// </summary>
    UserPasswordUpdateAction = 100,

    /// <summary>
    ///报单录入请求
    /// </summary>
    OrderInsertAction,

    /// <summary>
    ///报单操作请求
    /// </summary>
    OrderActionAction,

    /// <summary>
    ///查询最大报单数量请求
    /// </summary>
    QueryMaxOrderVolumeAction,

    /// <summary>
    ///请求查询报单
    /// </summary>
    QueryOrderAction,

    /// <summary>
    ///请求查询成交
    /// </summary>
    QueryTradeAction,

    /// <summary>
    ///请求查询投资者持仓
    /// </summary>
    QueryInvestorPositionAction,

    /// <summary>
    ///请求查询资金账户
    /// </summary>
    QueryTradingAccountAction,

    /// <summary>
    ///请求查询投资者
    /// </summary>
    QueryInvestorAction,

    /// <summary>
    ///请求查询交易编码
    /// </summary>
    QueryTradingCodeAction,

    /// <summary>
    ///请求查询合约手续费率
    /// </summary>
    QueryInstrumentCommissionRateAction,

    /// <summary>
    ///请求查询交易所
    /// </summary>
    QueryExchangeAction,

    /// <summary>
    ///请求查询合约
    /// </summary>
    QueryInstrumentAction,

    /// <summary>
    ///请求查询行情
    /// </summary>
    QueryDepthMarketDataAction,

    /// <summary>
    ///请求查询投资者持仓明细
    /// </summary>
    QueryInvestorPositionDetailAction,

  }

  /// <summary>
  /// 响应类型
  /// </summary>
  public enum CTPStockResponseType : int
  {
    /// <summary>
    /// 当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
    /// </summary>
    [CTPResponseDataType(null)]
    FrontConnectedResponse = 0,

    /// <summary>
    /// 当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
    /// </summary>
    [CTPResponseDataType(null)]
    FrontDisconnectedResponse,

    /// <summary>
    /// 心跳超时警告。当长时间未收到报文时，该方法被调用。
    /// </summary>
    [CTPResponseDataType(null)]
    HeartBeatWarningResponse,

    /// <summary>
    /// 客户端认证响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcRspAuthenticateField))]
    AuthenticateResponse,

    /// <summary>
    /// 登录请求响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcRspUserLoginField))]
    UserLoginResponse,

    /// <summary>
    /// 登出请求响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcUserLogoutField))]
    UserLogoutResponse,

    /// <summary>
    /// 用户口令更新请求响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcUserPasswordUpdateField))]
    UserPasswordUpdateResponse,

    /// <summary>
    /// 订阅行情应答
    /// </summary>
    SubMarketDataResponse,

    /// <summary>
    /// 取消订阅行情应答
    /// </summary>
    UnSubMarketDataResponse,

    /// <summary>
    /// 深度行情通知
    /// </summary>
    DepthMarketDataResponse,

    /// <summary>
    /// 报单录入请求响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInputOrderField))]
    OrderInsertResponse,

    /// <summary>
    /// 报单操作请求响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInputOrderActionField))]
    OrderActionResponse,

    /// <summary>
    /// 查询最大报单数量响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcQueryMaxOrderVolumeField))]
    QueryMaxOrderVolumeResponse,

    /// <summary>
    /// 请求查询报单响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcOrderField))]
    QueryOrderResponse,

    /// <summary>
    /// 请求查询成交响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcTradeField))]
    QueryTradeResponse,

    /// <summary>
    /// 请求查询投资者持仓响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInvestorPositionField))]
    QueryInvestorPositionResponse,

    /// <summary>
    /// 请求查询资金账户响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcTradingAccountField))]
    QueryTradingAccountResponse,

    /// <summary>
    /// 请求查询投资者响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInvestorField))]
    QueryInvestorResponse,

    /// <summary>
    /// 请求查询交易编码响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcTradingCodeField))]
    QueryTradingCodeResponse,

    /// <summary>
    /// 请求查询合约手续费率响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInstrumentCommissionRateField))]
    QueryInstrumentCommissionRateResponse,

    /// <summary>
    /// 请求查询交易所响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcExchangeField))]
    QueryExchangeResponse,

    /// <summary>
    /// 请求查询合约响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInstrumentField))]
    QueryInstrumentResponse,

    /// <summary>
    /// 请求查询行情响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcDepthMarketDataField))]
    QueryDepthMarketDataResponse,

    /// <summary>
    /// 请求查询投资者持仓明细响应
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInvestorPositionDetailField))]
    QueryInvestorPositionDetailResponse,

    /// <summary>
    /// 错误应答
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcRspInfoField))]
    ErrorResponse,

    /// <summary>
    /// 报单通知
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcOrderField))]
    ReturnOrderResponse,

    /// <summary>
    /// 成交通知
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcTradeField))]
    ReturnTradeResponse,

    /// <summary>
    /// 报单录入错误回报
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInputOrderField))]
    ErrorReturnOrderInsertResponse,

    /// <summary>
    /// 报单操作错误回报
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcOrderActionField))]
    ErrorReturnOrderActionResponse,

    /// <summary>
    /// 合约交易状态通知
    /// </summary>
    [CTPResponseDataType(typeof(CZQThostFtdcInstrumentStatusField))]
    ReturnInstrumentStatusResponse,

  }

  public class CTPStockTask : CTPTaskBase<CTPStockRequestAction>
  {

  }


  /// <summary>
  /// 合约
  /// </summary>
  public class CTPStockInstrument
  {
    CZQThostFtdcInstrumentField nativeValue;
    CZQThostFtdcInstrumentMarginRateField instrumentMarginRate;
    CZQThostFtdcInstrumentCommissionRateField instrumentCommissionRate;

    bool isRefreshMarginRate = false;
    bool isRefreshCommissionRate = false;

    /// <summary>
    /// 是否查询更新过保证金率
    /// </summary>
    public bool IsRefreshMarginRate
    {
      get { return isRefreshMarginRate; }
      set { isRefreshMarginRate = value; }
    }

    /// <summary>
    /// 是否查询更新过手续费
    /// </summary>
    public bool IsRefreshCommissionRate
    {
      get { return isRefreshCommissionRate; }
      set { isRefreshCommissionRate = value; }
    }

    public void SetNativeValue(CZQThostFtdcInstrumentField nativeValue)
    {
      this.nativeValue = nativeValue;
    }
    public void SetNativeValue(CZQThostFtdcInstrumentMarginRateField instrumentMarginRate)
    {
      this.instrumentMarginRate = instrumentMarginRate;
      this.isRefreshMarginRate = true;
    }
    public void SetNativeValue(CZQThostFtdcInstrumentCommissionRateField instrumentCommissionRate)
    {
      this.instrumentCommissionRate = instrumentCommissionRate;
      this.isRefreshCommissionRate = true;
    }

    /// <summary>
    /// 合约名
    /// </summary>
    public string Name
    {
      get { return nativeValue.InstrumentName; }
    }

    public string ID
    {
      get { return nativeValue.InstrumentID; }
    }

    public string ExchangeID
    {
      get { return nativeValue.ExchangeID; }
    }

    public string ProductID
    {
      get { return nativeValue.ProductID; }
    }

    public string DeliveryYear
    {
      get { return nativeValue.DeliveryYear.ToString(); }
    }

    public string DeliveryMonth
    {
      get { return nativeValue.DeliveryMonth.ToString("D2"); }
    }

    public string ExpireDate
    {
      get { return nativeValue.ExpireDate; }
    }


    public string ExchangeInstID
    {
      get { return nativeValue.ExchangeInstID; }
    }

    /// <summary>
    /// 上市日
    /// </summary>
    public string OpenDate
    {
      get { return nativeValue.OpenDate; }
    }

    /// <summary>
    /// 产品类型
    /// </summary>
    public CTPStockProductClassType ProductClass
    {
      get { return nativeValue.ProductClass; }
    }

    public double PriceTick
    {
      get { return nativeValue.PriceTick; }
    }

    public int VolumeMultiple
    {
      get { return nativeValue.VolumeMultiple; }
    }


    public bool IsTrading
    {
      get { return nativeValue.IsTrading; }
    }

    public double LongMarginRatio
    {
      get { return nativeValue.LongMarginRatio; }
    }

    public double ShortMarginRatio
    {
      get { return nativeValue.ShortMarginRatio; }
    }


    /// <summary>
    /// 多头保证金（成交额百分比）
    /// </summary>
    public double LongMarginRatioByMoney
    {
      get { return instrumentMarginRate.LongMarginRatioByMoney; }
    }
    /// <summary>
    /// 多头保证金
    /// </summary>
    public double LongMarginRatioByVolume
    {
      get { return instrumentMarginRate.LongMarginRatioByVolume; }
    }
    /// <summary>
    /// 空头保证金（成交额百分比）
    /// </summary>
    public double ShortMarginRatioByMoney
    {
      get { return instrumentMarginRate.ShortMarginRatioByMoney; }
    }
    /// <summary>
    /// 空头保证金
    /// </summary>
    public double ShortMarginRatioByVolume
    {
      get { return instrumentMarginRate.ShortMarginRatioByVolume; }
    }

    /// <summary>
    /// 开仓手续费率
    /// </summary>
    public double BuyTradeFeeByMoney
    {
      get { return instrumentCommissionRate.BuyTradeFeeByMoney; }
    }
    /// <summary>
    /// 开仓手续费
    /// </summary>
    public double BuyTradeFeeByVolume
    {
      get { return instrumentCommissionRate.BuyTradeFeeByVolume; }
    }
    
    public double CalcMargin(double price, bool longMargin)
    {

      double margin = double.MaxValue;

      //保证金
      if (this.IsRefreshMarginRate)
      {


        double r1 = this.LongMarginRatio + this.ShortMarginRatio;
        double r2 = this.LongMarginRatioByMoney + this.ShortMarginRatioByMoney;
        double r3 = this.LongMarginRatioByVolume + this.ShortMarginRatioByVolume;

        if (r3 != 0)
        {
          //存在按量保证金费时：
          if (this.LongMarginRatio == this.ShortMarginRatio &&
            this.LongMarginRatioByVolume == this.ShortMarginRatioByVolume)
          {

            margin = price * this.nativeValue.VolumeMultiple * this.LongMarginRatioByMoney + this.LongMarginRatioByVolume;
          }
          else
          {

            if (longMargin)
            {
              margin = price * this.nativeValue.VolumeMultiple * this.LongMarginRatioByMoney + this.LongMarginRatioByVolume;
            }
            else
            {
              margin = price * this.nativeValue.VolumeMultiple * this.ShortMarginRatioByMoney + this.ShortMarginRatioByVolume;
            }
          }
        }
        else
        {
          if (this.LongMarginRatio == this.ShortMarginRatio)
          {
            margin = price * this.nativeValue.VolumeMultiple * this.LongMarginRatioByMoney;
          }
          else
          {
            if (longMargin)
            {
              margin = price * this.nativeValue.VolumeMultiple * this.LongMarginRatioByMoney;
            }
            else
            {
              margin = price * this.nativeValue.VolumeMultiple * this.ShortMarginRatioByMoney;
            }
          }
        }
      }

      return margin;
    }

    string FormatCommissionRate(double value)
    {
      value = value * 10000;

      return string.Concat(value, "%%");
    }

    public string GetCommissionString()
    {
      string s = "";
      //手续费
      return s;
    }


    public string GetMarginRateString()
    {
      string s = "";

      //保证金
      if (this.IsRefreshMarginRate)
      {


        double r1 = this.LongMarginRatio + this.ShortMarginRatio;
        double r2 = this.LongMarginRatioByMoney + this.ShortMarginRatioByMoney;
        double r3 = this.LongMarginRatioByVolume + this.ShortMarginRatioByVolume;

        if (r3 != 0)
        {
          //存在按量保证金费时：
          if (this.LongMarginRatio == this.ShortMarginRatio &&
            this.LongMarginRatioByVolume == this.ShortMarginRatioByVolume)
          {
            s = string.Format("{0:P}+{1}", this.LongMarginRatioByMoney, this.LongMarginRatioByVolume);
          }
          else
          {
            s = string.Format("多|空：{0:P}+{1}|{2:P}+{3}",
              this.LongMarginRatioByMoney, this.LongMarginRatioByVolume,
              this.ShortMarginRatioByMoney, this.ShortMarginRatioByVolume);
          }
        }
        else
        {
          if (this.LongMarginRatio == this.ShortMarginRatio)
          {
            s = string.Format("{0:P}", this.LongMarginRatioByMoney);
          }
          else
          {
            s = string.Format("多|空：{0:P}|{1:P}", this.LongMarginRatioByMoney, this.ShortMarginRatioByMoney);
          }
        }
      }
      return s;

    }
  }
}
