using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CalmBeltFund.Trading.CTPStock
{

  public enum CTPResumeType
  {
    TERT_RESTART = 0,
    TERT_RESUME = 1,
    TERT_QUICK = 2
  }
    /// <summary>
  /// TFtdcExchangePropertyType是一个交易所属性类型
  /// </summary>
  public enum CTPStockExchangePropertyType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = (byte)'0',
    /// <summary>
    /// 根据成交生成报单
    /// </summary>
    [Description("根据成交生成报单")]
    GenOrderByTrade = (byte)'1'
  }

  /// <summary>
  /// TFtdcIdCardTypeType是一个证件类型类型
  /// </summary>
  public enum CTPStockIdCardType : byte
  {
    /// <summary>
    /// 组织机构代码
    /// </summary>
    [Description("组织机构代码")]
    EID = (byte)'0',
    /// <summary>
    /// 身份证
    /// </summary>
    [Description("身份证")]
    IDCard = (byte)'1',
    /// <summary>
    /// 军官证
    /// </summary>
    [Description("军官证")]
    OfficerIDCard = (byte)'2',
    /// <summary>
    /// 警官证
    /// </summary>
    [Description("警官证")]
    PoliceIDCard = (byte)'3',
    /// <summary>
    /// 士兵证
    /// </summary>
    [Description("士兵证")]
    SoldierIDCard = (byte)'4',
    /// <summary>
    /// 户口簿
    /// </summary>
    [Description("户口簿")]
    HouseholdRegister = (byte)'5',
    /// <summary>
    /// 护照
    /// </summary>
    [Description("护照")]
    Passport = (byte)'6',
    /// <summary>
    /// 台胞证
    /// </summary>
    [Description("台胞证")]
    TaiwanCompatriotIDCard = (byte)'7',
    /// <summary>
    /// 回乡证
    /// </summary>
    [Description("回乡证")]
    HomeComingCard = (byte)'8',
    /// <summary>
    /// 营业执照号
    /// </summary>
    [Description("营业执照号")]
    LicenseNo = (byte)'9',
    /// <summary>
    /// 其他证件
    /// </summary>
    [Description("其他证件")]
    OtherCard = (byte)'x'
  }

  /// <summary>
  /// TFtdcInvestorRangeType是一个投资者范围类型
  /// </summary>
  public enum CTPStockInvestorRangeType : byte
  {
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    All = (byte)'1',
    /// <summary>
    /// 投资者组
    /// </summary>
    [Description("投资者组")]
    Group = (byte)'2',
    /// <summary>
    /// 单一投资者
    /// </summary>
    [Description("单一投资者")]
    Single = (byte)'3'
  }

  /// <summary>
  /// TFtdcDepartmentRangeType是一个投资者范围类型
  /// </summary>
  public enum CTPStockDepartmentRangeType : byte
  {
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    All = (byte)'1',
    /// <summary>
    /// 组织架构
    /// </summary>
    [Description("组织架构")]
    Group = (byte)'2',
    /// <summary>
    /// 单一投资者
    /// </summary>
    [Description("单一投资者")]
    Single = (byte)'3'
  }

  /// <summary>
  /// TFtdcDataSyncStatusType是一个数据同步状态类型
  /// </summary>
  public enum CTPStockDataSyncStatusType : byte
  {
    /// <summary>
    /// 未同步
    /// </summary>
    [Description("未同步")]
    Asynchronous = (byte)'1',
    /// <summary>
    /// 同步中
    /// </summary>
    [Description("同步中")]
    Synchronizing = (byte)'2',
    /// <summary>
    /// 已同步
    /// </summary>
    [Description("已同步")]
    Synchronized = (byte)'3'
  }

  /// <summary>
  /// TFtdcBrokerDataSyncStatusType是一个经纪公司数据同步状态类型
  /// </summary>
  public enum CTPStockBrokerDataSyncStatusType : byte
  {
    /// <summary>
    /// 已同步
    /// </summary>
    [Description("已同步")]
    Synchronized = (byte)'1',
    /// <summary>
    /// 同步中
    /// </summary>
    [Description("同步中")]
    Synchronizing = (byte)'2'
  }

  /// <summary>
  /// TFtdcExchangeConnectStatusType是一个交易所连接状态类型
  /// </summary>
  public enum CTPStockExchangeConnectStatusType : byte
  {
    /// <summary>
    /// 没有任何连接
    /// </summary>
    [Description("没有任何连接")]
    NoConnection = (byte)'1',
    /// <summary>
    /// 已经发出合约查询请求
    /// </summary>
    [Description("已经发出合约查询请求")]
    QryInstrumentSent = (byte)'2',
    /// <summary>
    /// 已经获取信息
    /// </summary>
    [Description("已经获取信息")]
    GotInformation = (byte)'9'
  }

  /// <summary>
  /// TFtdcTraderConnectStatusType是一个交易所交易员连接状态类型
  /// </summary>
  public enum CTPStockTraderConnectStatusType : byte
  {
    /// <summary>
    /// 没有任何连接
    /// </summary>
    [Description("没有任何连接")]
    NotConnected = (byte)'1',
    /// <summary>
    /// 已经连接
    /// </summary>
    [Description("已经连接")]
    Connected = (byte)'2',
    /// <summary>
    /// 已经发出合约查询请求
    /// </summary>
    [Description("已经发出合约查询请求")]
    QryInstrumentSent = (byte)'3',
    /// <summary>
    /// 订阅私有流
    /// </summary>
    [Description("订阅私有流")]
    SubPrivateFlow = (byte)'4'
  }

  /// <summary>
  /// TFtdcFunctionCodeType是一个功能代码类型
  /// </summary>
  public enum CTPStockFunctionCodeType : byte
  {
    /// <summary>
    /// 数据异步化
    /// </summary>
    [Description("数据异步化")]
    DataAsync = (byte)'1',
    /// <summary>
    /// 强制用户登出
    /// </summary>
    [Description("强制用户登出")]
    ForceUserLogout = (byte)'2',
    /// <summary>
    /// 变更管理用户口令
    /// </summary>
    [Description("变更管理用户口令")]
    UserPasswordUpdate = (byte)'3',
    /// <summary>
    /// 变更经纪公司口令
    /// </summary>
    [Description("变更经纪公司口令")]
    BrokerPasswordUpdate = (byte)'4',
    /// <summary>
    /// 变更投资者口令
    /// </summary>
    [Description("变更投资者口令")]
    InvestorPasswordUpdate = (byte)'5',
    /// <summary>
    /// 报单插入
    /// </summary>
    [Description("报单插入")]
    OrderInsert = (byte)'6',
    /// <summary>
    /// 报单操作
    /// </summary>
    [Description("报单操作")]
    OrderAction = (byte)'7',
    /// <summary>
    /// 同步系统数据
    /// </summary>
    [Description("同步系统数据")]
    SyncSystemData = (byte)'8',
    /// <summary>
    /// 同步经纪公司数据
    /// </summary>
    [Description("同步经纪公司数据")]
    SyncBrokerData = (byte)'9',
    /// <summary>
    /// 批量同步经纪公司数据
    /// </summary>
    [Description("批量同步经纪公司数据")]
    BachSyncBrokerData = (byte)'A',
    /// <summary>
    /// 超级查询
    /// </summary>
    [Description("超级查询")]
    SuperQuery = (byte)'B',
    /// <summary>
    /// 报单插入
    /// </summary>
    [Description("报单插入")]
    ParkedOrderInsert = (byte)'C',
    /// <summary>
    /// 报单操作
    /// </summary>
    [Description("报单操作")]
    ParkedOrderAction = (byte)'D',
    /// <summary>
    /// 同步动态令牌
    /// </summary>
    [Description("同步动态令牌")]
    SyncOTP = (byte)'E'
  }

  /// <summary>
  /// TFtdcBrokerFunctionCodeType是一个经纪公司功能代码类型
  /// </summary>
  public enum CTPStockBrokerFunctionCodeType : byte
  {
    /// <summary>
    /// 强制用户登出
    /// </summary>
    [Description("强制用户登出")]
    ForceUserLogout = (byte)'1',
    /// <summary>
    /// 变更用户口令
    /// </summary>
    [Description("变更用户口令")]
    UserPasswordUpdate = (byte)'2',
    /// <summary>
    /// 同步经纪公司数据
    /// </summary>
    [Description("同步经纪公司数据")]
    SyncBrokerData = (byte)'3',
    /// <summary>
    /// 批量同步经纪公司数据
    /// </summary>
    [Description("批量同步经纪公司数据")]
    BachSyncBrokerData = (byte)'4',
    /// <summary>
    /// 报单插入
    /// </summary>
    [Description("报单插入")]
    OrderInsert = (byte)'5',
    /// <summary>
    /// 报单操作
    /// </summary>
    [Description("报单操作")]
    OrderAction = (byte)'6',
    /// <summary>
    /// 全部查询
    /// </summary>
    [Description("全部查询")]
    AllQuery = (byte)'7',
    /// <summary>
    /// 系统功能：登入/登出/修改密码等
    /// </summary>
    [Description("系统功能：登入/登出/修改密码等")]
    log = (byte)'a',
    /// <summary>
    /// 基本查询：查询基础数据，如合约，交易所等常量
    /// </summary>
    [Description("基本查询：查询基础数据，如合约，交易所等常量")]
    BaseQry = (byte)'b',
    /// <summary>
    /// 交易查询：如查成交，委托
    /// </summary>
    [Description("交易查询：如查成交，委托")]
    TradeQry = (byte)'c',
    /// <summary>
    /// 交易功能：报单，撤单
    /// </summary>
    [Description("交易功能：报单，撤单")]
    Trade = (byte)'d',
    /// <summary>
    /// 银期转账
    /// </summary>
    [Description("银期转账")]
    Virement = (byte)'e',
    /// <summary>
    /// 风险监控
    /// </summary>
    [Description("风险监控")]
    Risk = (byte)'f',
    /// <summary>
    /// 查询/管理：查询会话，踢人等
    /// </summary>
    [Description("查询/管理：查询会话，踢人等")]
    Session = (byte)'g',
    /// <summary>
    /// 风控通知控制
    /// </summary>
    [Description("风控通知控制")]
    RiskNoticeCtl = (byte)'h',
    /// <summary>
    /// 风控通知发送
    /// </summary>
    [Description("风控通知发送")]
    RiskNotice = (byte)'i',
    /// <summary>
    /// 察看经纪公司资金权限
    /// </summary>
    [Description("察看经纪公司资金权限")]
    BrokerDeposit = (byte)'j',
    /// <summary>
    /// 资金查询
    /// </summary>
    [Description("资金查询")]
    QueryFund = (byte)'k',
    /// <summary>
    /// 报单查询
    /// </summary>
    [Description("报单查询")]
    QueryOrder = (byte)'l',
    /// <summary>
    /// 成交查询
    /// </summary>
    [Description("成交查询")]
    QueryTrade = (byte)'m',
    /// <summary>
    /// 持仓查询
    /// </summary>
    [Description("持仓查询")]
    QueryPosition = (byte)'n',
    /// <summary>
    /// 行情查询
    /// </summary>
    [Description("行情查询")]
    QueryMarketData = (byte)'o',
    /// <summary>
    /// 用户事件查询
    /// </summary>
    [Description("用户事件查询")]
    QueryUserEvent = (byte)'p',
    /// <summary>
    /// 风险通知查询
    /// </summary>
    [Description("风险通知查询")]
    QueryRiskNotify = (byte)'q',
    /// <summary>
    /// 出入金查询
    /// </summary>
    [Description("出入金查询")]
    QueryFundChange = (byte)'r',
    /// <summary>
    /// 投资者信息查询
    /// </summary>
    [Description("投资者信息查询")]
    QueryInvestor = (byte)'s',
    /// <summary>
    /// 交易编码查询
    /// </summary>
    [Description("交易编码查询")]
    QueryTradingCode = (byte)'t',
    /// <summary>
    /// 强平
    /// </summary>
    [Description("强平")]
    ForceClose = (byte)'u',
    /// <summary>
    /// 压力测试
    /// </summary>
    [Description("压力测试")]
    PressTest = (byte)'v',
    /// <summary>
    /// 权益反算
    /// </summary>
    [Description("权益反算")]
    RemainCalc = (byte)'w',
    /// <summary>
    /// 净持仓保证金指标
    /// </summary>
    [Description("净持仓保证金指标")]
    NetPositionInd = (byte)'x',
    /// <summary>
    /// 风险预算
    /// </summary>
    [Description("风险预算")]
    RiskPredict = (byte)'y',
    /// <summary>
    /// 数据导出
    /// </summary>
    [Description("数据导出")]
    DataExport = (byte)'z',
    /// <summary>
    /// 风控指标设置
    /// </summary>
    [Description("风控指标设置")]
    RiskTargetSetup = (byte)'A',
    /// <summary>
    /// 同步动态令牌
    /// </summary>
    [Description("同步动态令牌")]
    SyncOTP = (byte)'E'
  }

  /// <summary>
  /// TFtdcOrderActionStatusType是一个报单操作状态类型
  /// </summary>
  public enum CTPStockOrderActionStatusType : byte
  {
    /// <summary>
    /// 已经提交
    /// </summary>
    [Description("已经提交")]
    Submitted = (byte)'a',
    /// <summary>
    /// 已经接受
    /// </summary>
    [Description("已经接受")]
    Accepted = (byte)'b',
    /// <summary>
    /// 已经被拒绝
    /// </summary>
    [Description("已经被拒绝")]
    Rejected = (byte)'c'
  }

  /// <summary>
  /// TFtdcOrderStatusType是一个报单状态类型
  /// </summary>
  public enum CTPStockOrderStatusType : byte
  {
    /// <summary>
    /// 全部成交
    /// </summary>
    [Description("全部成交")]
    AllTraded = (byte)'0',
    /// <summary>
    /// 部分成交还在队列中
    /// </summary>
    [Description("部分成交还在队列中")]
    PartTradedQueueing = (byte)'1',
    /// <summary>
    /// 部分成交不在队列中
    /// </summary>
    [Description("部分成交不在队列中")]
    PartTradedNotQueueing = (byte)'2',
    /// <summary>
    /// 未成交还在队列中
    /// </summary>
    [Description("未成交还在队列中")]
    NoTradeQueueing = (byte)'3',
    /// <summary>
    /// 未成交不在队列中
    /// </summary>
    [Description("未成交不在队列中")]
    NoTradeNotQueueing = (byte)'4',
    /// <summary>
    /// 撤单
    /// </summary>
    [Description("撤单")]
    Canceled = (byte)'5',
    /// <summary>
    /// 未知
    /// </summary>
    [Description("未知")]
    Unknown = (byte)'a',
    /// <summary>
    /// 尚未触发
    /// </summary>
    [Description("尚未触发")]
    NotTouched = (byte)'b',
    /// <summary>
    /// 已触发
    /// </summary>
    [Description("已触发")]
    Touched = (byte)'c'
  }

  /// <summary>
  /// TFtdcOrderSubmitStatusType是一个报单提交状态类型
  /// </summary>
  public enum CTPStockOrderSubmitStatusType : byte
  {
    /// <summary>
    /// 已经提交
    /// </summary>
    [Description("已经提交")]
    InsertSubmitted = (byte)'0',
    /// <summary>
    /// 撤单已经提交
    /// </summary>
    [Description("撤单已经提交")]
    CancelSubmitted = (byte)'1',
    /// <summary>
    /// 修改已经提交
    /// </summary>
    [Description("修改已经提交")]
    ModifySubmitted = (byte)'2',
    /// <summary>
    /// 已经接受
    /// </summary>
    [Description("已经接受")]
    Accepted = (byte)'3',
    /// <summary>
    /// 报单已经被拒绝
    /// </summary>
    [Description("报单已经被拒绝")]
    InsertRejected = (byte)'4',
    /// <summary>
    /// 撤单已经被拒绝
    /// </summary>
    [Description("撤单已经被拒绝")]
    CancelRejected = (byte)'5',
    /// <summary>
    /// 改单已经被拒绝
    /// </summary>
    [Description("改单已经被拒绝")]
    ModifyRejected = (byte)'6'
  }

  /// <summary>
  /// TFtdcPositionDateType是一个持仓日期类型
  /// </summary>
  public enum CTPStockPositionDateType : byte
  {
    /// <summary>
    /// 今日持仓
    /// </summary>
    [Description("今日持仓")]
    Today = (byte)'1',
    /// <summary>
    /// 历史持仓
    /// </summary>
    [Description("历史持仓")]
    History = (byte)'2'
  }

  /// <summary>
  /// TFtdcPositionDateTypeType是一个持仓日期类型类型
  /// </summary>
  public enum CTPStockHistoryPositionUseType : byte
  {
    /// <summary>
    /// 使用历史持仓
    /// </summary>
    [Description("使用历史持仓")]
    UseHistory = (byte)'1',
    /// <summary>
    /// 不使用历史持仓
    /// </summary>
    [Description("不使用历史持仓")]
    NoUseHistory = (byte)'2'
  }

  /// <summary>
  /// TFtdcTradingRoleType是一个交易角色类型
  /// </summary>
  public enum CTPStockTradingRoleType : byte
  {
    /// <summary>
    /// 代理
    /// </summary>
    [Description("代理")]
    Broker = (byte)'1',
    /// <summary>
    /// 自营
    /// </summary>
    [Description("自营")]
    Host = (byte)'2',
    /// <summary>
    /// 做市商
    /// </summary>
    [Description("做市商")]
    Maker = (byte)'3'
  }

  /// <summary>
  /// TFtdcProductClassType是一个产品类型类型
  /// </summary>
  public enum CTPStockProductClassType : byte
  {
    /// <summary>
    /// 期货
    /// </summary>
    [Description("期货")]
    Futures = (byte)'1',
    /// <summary>
    /// 期权
    /// </summary>
    [Description("期权")]
    Options = (byte)'2',
    /// <summary>
    /// 组合
    /// </summary>
    [Description("组合")]
    Combination = (byte)'3',
    /// <summary>
    /// 即期
    /// </summary>
    [Description("即期")]
    Spot = (byte)'4',
    /// <summary>
    /// 期转现
    /// </summary>
    [Description("期转现")]
    EFP = (byte)'5',
    /// <summary>
    /// 证券A股
    /// </summary>
    [Description("证券A股")]
    StockA = (byte)'6',
    /// <summary>
    /// 证券B股
    /// </summary>
    [Description("证券B股")]
    StockB = (byte)'7',
    /// <summary>
    /// ETF
    /// </summary>
    [Description("ETF")]
    ETF = (byte)'8',
    /// <summary>
    /// ETF申赎
    /// </summary>
    [Description("ETF申赎")]
    ETFPurRed = (byte)'9'
  }

  /// <summary>
  /// TFtdcInstLifePhaseType是一个合约生命周期状态类型
  /// </summary>
  public enum CTPStockInstLifePhaseType : byte
  {
    /// <summary>
    /// 未上市
    /// </summary>
    [Description("未上市")]
    NotStart = (byte)'0',
    /// <summary>
    /// 上市
    /// </summary>
    [Description("上市")]
    Started = (byte)'1',
    /// <summary>
    /// 停牌
    /// </summary>
    [Description("停牌")]
    Pause = (byte)'2',
    /// <summary>
    /// 到期
    /// </summary>
    [Description("到期")]
    Expired = (byte)'3'
  }

  /// <summary>
  /// TFtdcDirectionType是一个买卖方向类型
  /// </summary>
  public enum CTPStockDirectionType : byte
  {
    /// <summary>
    /// 买
    /// </summary>
    [Description("买")]
    Buy = (byte)'0',
    /// <summary>
    /// 卖
    /// </summary>
    [Description("卖")]
    Sell = (byte)'1',
    /// <summary>
    /// ETF申购
    /// </summary>
    [Description("ETF申购")]
    ETFPur = (byte)'2',
    /// <summary>
    /// ETF赎回
    /// </summary>
    [Description("ETF赎回")]
    ETFRed = (byte)'3',
    /// <summary>
    /// 融资买入
    /// </summary>
    [Description("融资买入")]
    MarginTrade = (byte)'4',
    /// <summary>
    /// 融券卖出
    /// </summary>
    [Description("融券卖出")]
    ShortSell = (byte)'5',
    /// <summary>
    /// 卖券还款
    /// </summary>
    [Description("卖券还款")]
    RepayMargin = (byte)'6',
    /// <summary>
    /// 买券还券
    /// </summary>
    [Description("买券还券")]
    RepayStock = (byte)'7',
    /// <summary>
    /// 直接还款
    /// </summary>
    [Description("直接还款")]
    DirectRepayMargin = (byte)'8',
    /// <summary>
    /// 直接还券
    /// </summary>
    [Description("直接还券")]
    DirectRepayStock = (byte)'9',
    /// <summary>
    /// 担保品划转
    /// </summary>
    [Description("担保品划转")]
    TransferSecurities = (byte)'A'
  }

  /// <summary>
  /// TFtdcPositionTypeType是一个持仓类型类型
  /// </summary>
  public enum CTPStockPositionType : byte
  {
    /// <summary>
    /// 净持仓
    /// </summary>
    [Description("净持仓")]
    Net = (byte)'1',
    /// <summary>
    /// 综合持仓
    /// </summary>
    [Description("综合持仓")]
    Gross = (byte)'2'
  }

  /// <summary>
  /// TFtdcPosiDirectionType是一个持仓多空方向类型
  /// </summary>
  public enum CTPStockPosiDirectionType : byte
  {
    /// <summary>
    /// 净
    /// </summary>
    [Description("净")]
    Net = (byte)'1',
    /// <summary>
    /// 多头
    /// </summary>
    [Description("多头")]
    Long = (byte)'2',
    /// <summary>
    /// 空头
    /// </summary>
    [Description("空头")]
    Short = (byte)'3',
    /// <summary>
    /// 融资
    /// </summary>
    [Description("融资")]
    MarginTrade = (byte)'4',
    /// <summary>
    /// 融券
    /// </summary>
    [Description("融券")]
    ShortSell = (byte)'5'
  }

  /// <summary>
  /// TFtdcSysSettlementStatusType是一个系统结算状态类型
  /// </summary>
  public enum CTPStockSysSettlementStatusType : byte
  {
    /// <summary>
    /// 不活跃
    /// </summary>
    [Description("不活跃")]
    NonActive = (byte)'1',
    /// <summary>
    /// 启动
    /// </summary>
    [Description("启动")]
    Startup = (byte)'2',
    /// <summary>
    /// 操作
    /// </summary>
    [Description("操作")]
    Operating = (byte)'3',
    /// <summary>
    /// 结算
    /// </summary>
    [Description("结算")]
    Settlement = (byte)'4',
    /// <summary>
    /// 结算完成
    /// </summary>
    [Description("结算完成")]
    SettlementFinished = (byte)'5'
  }

  /// <summary>
  /// TFtdcRatioAttrType是一个费率属性类型
  /// </summary>
  public enum CTPStockRatioAttrType : byte
  {
    /// <summary>
    /// 交易费率
    /// </summary>
    [Description("交易费率")]
    Trade = (byte)'0',
    /// <summary>
    /// 结算费率
    /// </summary>
    [Description("结算费率")]
    Settlement = (byte)'1'
  }

  /// <summary>
  /// TFtdcHedgeFlagType是一个投机套保标志类型
  /// </summary>
  public enum CTPStockHedgeFlagType : byte
  {
    /// <summary>
    /// 投机
    /// </summary>
    [Description("投机")]
    Speculation = (byte)'1',
    /// <summary>
    /// 套保
    /// </summary>
    [Description("套保")]
    Hedge = (byte)'3'
  }

  /// <summary>
  /// TFtdcOrderPriceTypeType是一个报单价格条件类型
  /// </summary>
  public enum CTPStockOrderPriceType : byte
  {
    /// <summary>
    /// 任意价
    /// </summary>
    [Description("任意价")]
    AnyPrice = (byte)'1',
    /// <summary>
    /// 限价
    /// </summary>
    [Description("限价")]
    LimitPrice = (byte)'2',
    /// <summary>
    /// 最优价
    /// </summary>
    [Description("最优价")]
    BestPrice = (byte)'3',
    /// <summary>
    /// 最新价
    /// </summary>
    [Description("最新价")]
    LastPrice = (byte)'4',
    /// <summary>
    /// 最新价浮动上浮1个ticks
    /// </summary>
    [Description("最新价浮动上浮1个ticks")]
    LastPricePlusOneTicks = (byte)'5',
    /// <summary>
    /// 最新价浮动上浮2个ticks
    /// </summary>
    [Description("最新价浮动上浮2个ticks")]
    LastPricePlusTwoTicks = (byte)'6',
    /// <summary>
    /// 最新价浮动上浮3个ticks
    /// </summary>
    [Description("最新价浮动上浮3个ticks")]
    LastPricePlusThreeTicks = (byte)'7',
    /// <summary>
    /// 卖一价
    /// </summary>
    [Description("卖一价")]
    AskPrice1 = (byte)'8',
    /// <summary>
    /// 卖一价浮动上浮1个ticks
    /// </summary>
    [Description("卖一价浮动上浮1个ticks")]
    AskPrice1PlusOneTicks = (byte)'9',
    /// <summary>
    /// 卖一价浮动上浮2个ticks
    /// </summary>
    [Description("卖一价浮动上浮2个ticks")]
    AskPrice1PlusTwoTicks = (byte)'A',
    /// <summary>
    /// 卖一价浮动上浮3个ticks
    /// </summary>
    [Description("卖一价浮动上浮3个ticks")]
    AskPrice1PlusThreeTicks = (byte)'B',
    /// <summary>
    /// 买一价
    /// </summary>
    [Description("买一价")]
    BidPrice1 = (byte)'C',
    /// <summary>
    /// 买一价浮动上浮1个ticks
    /// </summary>
    [Description("买一价浮动上浮1个ticks")]
    BidPrice1PlusOneTicks = (byte)'D',
    /// <summary>
    /// 买一价浮动上浮2个ticks
    /// </summary>
    [Description("买一价浮动上浮2个ticks")]
    BidPrice1PlusTwoTicks = (byte)'E',
    /// <summary>
    /// 买一价浮动上浮3个ticks
    /// </summary>
    [Description("买一价浮动上浮3个ticks")]
    BidPrice1PlusThreeTicks = (byte)'F',
    /// <summary>
    /// 激活A股网络密码服务代码
    /// </summary>
    [Description("激活A股网络密码服务代码")]
    ActiveANetPassSvrCode = (byte)'G',
    /// <summary>
    /// 注销A股网络密码服务代码
    /// </summary>
    [Description("注销A股网络密码服务代码")]
    InactiveANetPassSvrCode = (byte)'H',
    /// <summary>
    /// 激活B股网络密码服务代码
    /// </summary>
    [Description("激活B股网络密码服务代码")]
    ActiveBNetPassSvrCode = (byte)'I',
    /// <summary>
    /// 注销B股网络密码服务代码
    /// </summary>
    [Description("注销B股网络密码服务代码")]
    InactiveBNetPassSvrCode = (byte)'J',
    /// <summary>
    /// 回购注销
    /// </summary>
    [Description("回购注销")]
    Repurchase = (byte)'K',
    /// <summary>
    /// 指定撤销
    /// </summary>
    [Description("指定撤销")]
    DesignatedCancel = (byte)'L',
    /// <summary>
    /// 指定登记
    /// </summary>
    [Description("指定登记")]
    Designated = (byte)'M',
    /// <summary>
    /// 证券参与申购
    /// </summary>
    [Description("证券参与申购")]
    SubscribingShares = (byte)'N',
    /// <summary>
    /// 证券参与配股
    /// </summary>
    [Description("证券参与配股")]
    Split = (byte)'O',
    /// <summary>
    /// 要约收购登记
    /// </summary>
    [Description("要约收购登记")]
    TenderOffer = (byte)'P',
    /// <summary>
    /// 要约收购撤销
    /// </summary>
    [Description("要约收购撤销")]
    TenderOfferCancel = (byte)'Q',
    /// <summary>
    /// 证券投票
    /// </summary>
    [Description("证券投票")]
    Ballot = (byte)'R',
    /// <summary>
    /// 可转债转换登记
    /// </summary>
    [Description("可转债转换登记")]
    ConvertibleBondsConvet = (byte)'S',
    /// <summary>
    /// 可转债回售登记
    /// </summary>
    [Description("可转债回售登记")]
    ConvertibleBondsRepurchase = (byte)'T',
    /// <summary>
    /// 权证行权
    /// </summary>
    [Description("权证行权")]
    Exercise = (byte)'U',
    /// <summary>
    /// 开放式基金申购
    /// </summary>
    [Description("开放式基金申购")]
    PurchasingFunds = (byte)'V',
    /// <summary>
    /// 开放式基金赎回
    /// </summary>
    [Description("开放式基金赎回")]
    RedemingFunds = (byte)'W',
    /// <summary>
    /// 开放式基金认购
    /// </summary>
    [Description("开放式基金认购")]
    SubscribingFunds = (byte)'X',
    /// <summary>
    /// 开放式基金转托管转出
    /// </summary>
    [Description("开放式基金转托管转出")]
    LOFIssue = (byte)'Y',
    /// <summary>
    /// 开放式基金设置分红方式
    /// </summary>
    [Description("开放式基金设置分红方式")]
    LOFSetBonusType = (byte)'Z',
    /// <summary>
    /// 开放式基金转换为其他基金
    /// </summary>
    [Description("开放式基金转换为其他基金")]
    LOFConvert = (byte)'a',
    /// <summary>
    /// 债券入库
    /// </summary>
    [Description("债券入库")]
    DebentureStockIn = (byte)'b',
    /// <summary>
    /// 债券出库
    /// </summary>
    [Description("债券出库")]
    DebentureStockOut = (byte)'c',
    /// <summary>
    /// ETF申购
    /// </summary>
    [Description("ETF申购")]
    PurchasesETF = (byte)'d',
    /// <summary>
    /// ETF赎回
    /// </summary>
    [Description("ETF赎回")]
    RedeemETF = (byte)'e',
    /// <summary>
    /// 证券公司融券专用账户过户到证券公司信用交易担保证券账户
    /// </summary>
    [Description("证券公司融券专用账户过户到证券公司信用交易担保证券账户")]
    ShortAccToCreditAcc = (byte)'f',
    /// <summary>
    /// 证券公司信用交易担保证券账户过户到证券公司融券专用账户
    /// </summary>
    [Description("证券公司信用交易担保证券账户过户到证券公司融券专用账户")]
    CreditAccToShortAcc = (byte)'g',
    /// <summary>
    /// 投资者普通证券账户过户到证券公司信用交易担保证券账户
    /// </summary>
    [Description("投资者普通证券账户过户到证券公司信用交易担保证券账户")]
    InvAccToCreditAcc = (byte)'h',
    /// <summary>
    /// 证券公司融券专用账户过户到证券公司自营账户
    /// </summary>
    [Description("证券公司融券专用账户过户到证券公司自营账户")]
    ShortAccToHostAcc = (byte)'i'
  }

  /// <summary>
  /// TFtdcOffsetFlagType是一个开平标志类型
  /// </summary>
  public enum CTPStockOffsetFlagType : byte
  {
    /// <summary>
    /// 开仓
    /// </summary>
    [Description("开仓")]
    Open = (byte)'0',
    /// <summary>
    /// 平仓
    /// </summary>
    [Description("平仓")]
    Close = (byte)'1',
    /// <summary>
    /// 强平
    /// </summary>
    [Description("强平")]
    ForceClose = (byte)'2',
    /// <summary>
    /// 平今
    /// </summary>
    [Description("平今")]
    CloseToday = (byte)'3',
    /// <summary>
    /// 平昨
    /// </summary>
    [Description("平昨")]
    CloseYesterday = (byte)'4',
    /// <summary>
    /// 强减
    /// </summary>
    [Description("强减")]
    ForceOff = (byte)'5',
    /// <summary>
    /// 本地强平
    /// </summary>
    [Description("本地强平")]
    LocalForceClose = (byte)'6'
  }

  /// <summary>
  /// TFtdcForceCloseReasonType是一个强平原因类型
  /// </summary>
  public enum CTPStockForceCloseReasonType : byte
  {
    /// <summary>
    /// 非强平
    /// </summary>
    [Description("非强平")]
    NotForceClose = (byte)'0',
    /// <summary>
    /// 资金不足
    /// </summary>
    [Description("资金不足")]
    LackDeposit = (byte)'1',
    /// <summary>
    /// 客户超仓
    /// </summary>
    [Description("客户超仓")]
    ClientOverPositionLimit = (byte)'2',
    /// <summary>
    /// 会员超仓
    /// </summary>
    [Description("会员超仓")]
    MemberOverPositionLimit = (byte)'3',
    /// <summary>
    /// 持仓非整数倍
    /// </summary>
    [Description("持仓非整数倍")]
    NotMultiple = (byte)'4',
    /// <summary>
    /// 违规
    /// </summary>
    [Description("违规")]
    Violation = (byte)'5',
    /// <summary>
    /// 其它
    /// </summary>
    [Description("其它")]
    Other = (byte)'6'
  }

  /// <summary>
  /// TFtdcOrderTypeType是一个报单类型类型
  /// </summary>
  public enum CTPStockOrderType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = (byte)'0',
    /// <summary>
    /// 报价衍生
    /// </summary>
    [Description("报价衍生")]
    DeriveFromQuote = (byte)'1',
    /// <summary>
    /// 组合衍生
    /// </summary>
    [Description("组合衍生")]
    DeriveFromCombination = (byte)'2',
    /// <summary>
    /// 组合报单
    /// </summary>
    [Description("组合报单")]
    Combination = (byte)'3',
    /// <summary>
    /// 条件单
    /// </summary>
    [Description("条件单")]
    ConditionalOrder = (byte)'4',
    /// <summary>
    /// 互换单
    /// </summary>
    [Description("互换单")]
    Swap = (byte)'5'
  }

  /// <summary>
  /// TFtdcTimeConditionType是一个有效期类型类型
  /// </summary>
  public enum CTPStockTimeConditionType : byte
  {
    /// <summary>
    /// 立即完成，否则撤销
    /// </summary>
    [Description("立即完成，否则撤销")]
    IOC = (byte)'1',
    /// <summary>
    /// 本节有效
    /// </summary>
    [Description("本节有效")]
    GFS = (byte)'2',
    /// <summary>
    /// 当日有效
    /// </summary>
    [Description("当日有效")]
    GFD = (byte)'3',
    /// <summary>
    /// 指定日期前有效
    /// </summary>
    [Description("指定日期前有效")]
    GTD = (byte)'4',
    /// <summary>
    /// 撤销前有效
    /// </summary>
    [Description("撤销前有效")]
    GTC = (byte)'5',
    /// <summary>
    /// 集合竞价有效
    /// </summary>
    [Description("集合竞价有效")]
    GFA = (byte)'6'
  }

  /// <summary>
  /// TFtdcVolumeConditionType是一个成交量类型类型
  /// </summary>
  public enum CTPStockVolumeConditionType : byte
  {
    /// <summary>
    /// 任何数量
    /// </summary>
    [Description("任何数量")]
    AV = (byte)'1',
    /// <summary>
    /// 最小数量
    /// </summary>
    [Description("最小数量")]
    MV = (byte)'2',
    /// <summary>
    /// 全部数量
    /// </summary>
    [Description("全部数量")]
    CV = (byte)'3'
  }

  /// <summary>
  /// TFtdcContingentConditionType是一个触发条件类型
  /// </summary>
  public enum CTPStockContingentConditionType : byte
  {
    /// <summary>
    /// 立即
    /// </summary>
    [Description("立即")]
    Immediately = (byte)'1',
    /// <summary>
    /// 止损
    /// </summary>
    [Description("止损")]
    Touch = (byte)'2',
    /// <summary>
    /// 止赢
    /// </summary>
    [Description("止赢")]
    TouchProfit = (byte)'3',
    /// <summary>
    /// 预埋单
    /// </summary>
    [Description("预埋单")]
    ParkedOrder = (byte)'4',
    /// <summary>
    /// 最新价大于条件价
    /// </summary>
    [Description("最新价大于条件价")]
    LastPriceGreaterThanStopPrice = (byte)'5',
    /// <summary>
    /// 最新价大于等于条件价
    /// </summary>
    [Description("最新价大于等于条件价")]
    LastPriceGreaterEqualStopPrice = (byte)'6',
    /// <summary>
    /// 最新价小于条件价
    /// </summary>
    [Description("最新价小于条件价")]
    LastPriceLesserThanStopPrice = (byte)'7',
    /// <summary>
    /// 最新价小于等于条件价
    /// </summary>
    [Description("最新价小于等于条件价")]
    LastPriceLesserEqualStopPrice = (byte)'8',
    /// <summary>
    /// 卖一价大于条件价
    /// </summary>
    [Description("卖一价大于条件价")]
    AskPriceGreaterThanStopPrice = (byte)'9',
    /// <summary>
    /// 卖一价大于等于条件价
    /// </summary>
    [Description("卖一价大于等于条件价")]
    AskPriceGreaterEqualStopPrice = (byte)'A',
    /// <summary>
    /// 卖一价小于条件价
    /// </summary>
    [Description("卖一价小于条件价")]
    AskPriceLesserThanStopPrice = (byte)'B',
    /// <summary>
    /// 卖一价小于等于条件价
    /// </summary>
    [Description("卖一价小于等于条件价")]
    AskPriceLesserEqualStopPrice = (byte)'C',
    /// <summary>
    /// 买一价大于条件价
    /// </summary>
    [Description("买一价大于条件价")]
    BidPriceGreaterThanStopPrice = (byte)'D',
    /// <summary>
    /// 买一价大于等于条件价
    /// </summary>
    [Description("买一价大于等于条件价")]
    BidPriceGreaterEqualStopPrice = (byte)'E',
    /// <summary>
    /// 买一价小于条件价
    /// </summary>
    [Description("买一价小于条件价")]
    BidPriceLesserThanStopPrice = (byte)'F',
    /// <summary>
    /// 买一价小于等于条件价
    /// </summary>
    [Description("买一价小于等于条件价")]
    BidPriceLesserEqualStopPrice = (byte)'H'
  }

  /// <summary>
  /// TFtdcActionFlagType是一个操作标志类型
  /// </summary>
  public enum CTPStockActionFlagType : byte
  {
    /// <summary>
    /// 删除
    /// </summary>
    [Description("删除")]
    Delete = (byte)'0',
    /// <summary>
    /// 修改
    /// </summary>
    [Description("修改")]
    Modify = (byte)'3'
  }

  /// <summary>
  /// TFtdcTradingRightType是一个交易权限类型
  /// </summary>
  public enum CTPStockTradingRightType : byte
  {
    /// <summary>
    /// 可以交易
    /// </summary>
    [Description("可以交易")]
    Allow = (byte)'0',
    /// <summary>
    /// 不能交易
    /// </summary>
    [Description("不能交易")]
    Forbidden = (byte)'2'
  }

  /// <summary>
  /// TFtdcOrderSourceType是一个报单来源类型
  /// </summary>
  public enum CTPStockOrderSourceType : byte
  {
    /// <summary>
    /// 来自参与者
    /// </summary>
    [Description("来自参与者")]
    Participant = (byte)'0',
    /// <summary>
    /// 来自管理员
    /// </summary>
    [Description("来自管理员")]
    Administrator = (byte)'1'
  }

  /// <summary>
  /// TFtdcTradeTypeType是一个成交类型类型
  /// </summary>
  public enum CTPStockTradeType : byte
  {
    /// <summary>
    /// 普通成交
    /// </summary>
    [Description("普通成交")]
    Common = (byte)'0',
    /// <summary>
    /// 期权执行
    /// </summary>
    [Description("期权执行")]
    OptionsExecution = (byte)'1',
    /// <summary>
    /// OTC成交
    /// </summary>
    [Description("OTC成交")]
    OTC = (byte)'2',
    /// <summary>
    /// 期转现衍生成交
    /// </summary>
    [Description("期转现衍生成交")]
    EFPDerived = (byte)'3',
    /// <summary>
    /// 组合衍生成交
    /// </summary>
    [Description("组合衍生成交")]
    CombinationDerived = (byte)'4',
    /// <summary>
    /// ETF申购
    /// </summary>
    [Description("ETF申购")]
    EFTPurchase = (byte)'5',
    /// <summary>
    /// ETF赎回
    /// </summary>
    [Description("ETF赎回")]
    EFTRedem = (byte)'6'
  }

  /// <summary>
  /// TFtdcPriceSourceType是一个成交价来源类型
  /// </summary>
  public enum CTPStockPriceSourceType : byte
  {
    /// <summary>
    /// 前成交价
    /// </summary>
    [Description("前成交价")]
    LastPrice = (byte)'0',
    /// <summary>
    /// 买委托价
    /// </summary>
    [Description("买委托价")]
    Buy = (byte)'1',
    /// <summary>
    /// 卖委托价
    /// </summary>
    [Description("卖委托价")]
    Sell = (byte)'2'
  }

  /// <summary>
  /// TFtdcInstrumentStatusType是一个合约交易状态类型
  /// </summary>
  public enum CTPStockInstrumentStatusType : byte
  {
    /// <summary>
    /// 开盘前
    /// </summary>
    [Description("开盘前")]
    BeforeTrading = (byte)'0',
    /// <summary>
    /// 非交易
    /// </summary>
    [Description("非交易")]
    NoTrading = (byte)'1',
    /// <summary>
    /// 连续交易
    /// </summary>
    [Description("连续交易")]
    Continous = (byte)'2',
    /// <summary>
    /// 集合竞价报单
    /// </summary>
    [Description("集合竞价报单")]
    AuctionOrdering = (byte)'3',
    /// <summary>
    /// 集合竞价价格平衡
    /// </summary>
    [Description("集合竞价价格平衡")]
    AuctionBalance = (byte)'4',
    /// <summary>
    /// 集合竞价撮合
    /// </summary>
    [Description("集合竞价撮合")]
    AuctionMatch = (byte)'5',
    /// <summary>
    /// 收盘
    /// </summary>
    [Description("收盘")]
    Closed = (byte)'6'
  }

  /// <summary>
  /// TFtdcInstStatusEnterReasonType是一个品种进入交易状态原因类型
  /// </summary>
  public enum CTPStockInstStatusEnterReasonType : byte
  {
    /// <summary>
    /// 自动切换
    /// </summary>
    [Description("自动切换")]
    Automatic = (byte)'1',
    /// <summary>
    /// 手动切换
    /// </summary>
    [Description("手动切换")]
    Manual = (byte)'2',
    /// <summary>
    /// 熔断
    /// </summary>
    [Description("熔断")]
    Fuse = (byte)'3'
  }

  /// <summary>
  /// TFtdcBatchStatusType是一个处理状态类型
  /// </summary>
  public enum CTPStockBatchStatusType : byte
  {
    /// <summary>
    /// 未上传
    /// </summary>
    [Description("未上传")]
    NoUpload = (byte)'1',
    /// <summary>
    /// 已上传
    /// </summary>
    [Description("已上传")]
    Uploaded = (byte)'2',
    /// <summary>
    /// 审核失败
    /// </summary>
    [Description("审核失败")]
    Failed = (byte)'3'
  }

  /// <summary>
  /// TFtdcReturnStyleType是一个按品种返还方式类型
  /// </summary>
  public enum CTPStockReturnStyleType : byte
  {
    /// <summary>
    /// 按所有品种
    /// </summary>
    [Description("按所有品种")]
    All = (byte)'1',
    /// <summary>
    /// 按品种
    /// </summary>
    [Description("按品种")]
    ByProduct = (byte)'2'
  }

  /// <summary>
  /// TFtdcReturnPatternType是一个返还模式类型
  /// </summary>
  public enum CTPStockReturnPatternType : byte
  {
    /// <summary>
    /// 按成交手数
    /// </summary>
    [Description("按成交手数")]
    ByVolume = (byte)'1',
    /// <summary>
    /// 按留存手续费
    /// </summary>
    [Description("按留存手续费")]
    ByFeeOnHand = (byte)'2'
  }

  /// <summary>
  /// TFtdcReturnLevelType是一个返还级别类型
  /// </summary>
  public enum CTPStockReturnLevelType : byte
  {
    /// <summary>
    /// 级别1
    /// </summary>
    [Description("级别1")]
    Level1 = (byte)'1',
    /// <summary>
    /// 级别2
    /// </summary>
    [Description("级别2")]
    Level2 = (byte)'2',
    /// <summary>
    /// 级别3
    /// </summary>
    [Description("级别3")]
    Level3 = (byte)'3',
    /// <summary>
    /// 级别4
    /// </summary>
    [Description("级别4")]
    Level4 = (byte)'4',
    /// <summary>
    /// 级别5
    /// </summary>
    [Description("级别5")]
    Level5 = (byte)'5',
    /// <summary>
    /// 级别6
    /// </summary>
    [Description("级别6")]
    Level6 = (byte)'6',
    /// <summary>
    /// 级别7
    /// </summary>
    [Description("级别7")]
    Level7 = (byte)'7',
    /// <summary>
    /// 级别8
    /// </summary>
    [Description("级别8")]
    Level8 = (byte)'8',
    /// <summary>
    /// 级别9
    /// </summary>
    [Description("级别9")]
    Level9 = (byte)'9'
  }

  /// <summary>
  /// TFtdcReturnStandardType是一个返还标准类型
  /// </summary>
  public enum CTPStockReturnStandardType : byte
  {
    /// <summary>
    /// 分阶段返还
    /// </summary>
    [Description("分阶段返还")]
    ByPeriod = (byte)'1',
    /// <summary>
    /// 按某一标准
    /// </summary>
    [Description("按某一标准")]
    ByStandard = (byte)'2'
  }

  /// <summary>
  /// TFtdcMortgageTypeType是一个质押类型类型
  /// </summary>
  public enum CTPStockMortgageType : byte
  {
    /// <summary>
    /// 质出
    /// </summary>
    [Description("质出")]
    Out = (byte)'0',
    /// <summary>
    /// 质入
    /// </summary>
    [Description("质入")]
    In = (byte)'1'
  }

  /// <summary>
  /// TFtdcInvestorSettlementParamIDType是一个投资者结算参数代码类型
  /// </summary>
  public enum CTPStockInvestorSettlementParamIDType : byte
  {
    /// <summary>
    /// 基础保证金
    /// </summary>
    [Description("基础保证金")]
    BaseMargin = (byte)'1',
    /// <summary>
    /// 最低权益标准
    /// </summary>
    [Description("最低权益标准")]
    LowestInterest = (byte)'2',
    /// <summary>
    /// 质押比例
    /// </summary>
    [Description("质押比例")]
    MortgageRatio = (byte)'4',
    /// <summary>
    /// 保证金算法
    /// </summary>
    [Description("保证金算法")]
    MarginWay = (byte)'5',
    /// <summary>
    /// 结算单(盯市)权益等于结存
    /// </summary>
    [Description("结算单(盯市)权益等于结存")]
    BillDeposit = (byte)'9'
  }

  /// <summary>
  /// TFtdcExchangeSettlementParamIDType是一个交易所结算参数代码类型
  /// </summary>
  public enum CTPStockExchangeSettlementParamIDType : byte
  {
    /// <summary>
    /// 质押比例
    /// </summary>
    [Description("质押比例")]
    MortgageRatio = (byte)'1',
    /// <summary>
    /// 分项资金导入项
    /// </summary>
    [Description("分项资金导入项")]
    OtherFundItem = (byte)'2',
    /// <summary>
    /// 分项资金入交易所出入金
    /// </summary>
    [Description("分项资金入交易所出入金")]
    OtherFundImport = (byte)'3',
    /// <summary>
    /// 上期所交割手续费收取方式
    /// </summary>
    [Description("上期所交割手续费收取方式")]
    SHFEDelivFee = (byte)'4',
    /// <summary>
    /// 大商所交割手续费收取方式
    /// </summary>
    [Description("大商所交割手续费收取方式")]
    DCEDelivFee = (byte)'5',
    /// <summary>
    /// 中金所开户最低可用金额
    /// </summary>
    [Description("中金所开户最低可用金额")]
    CFFEXMinPrepa = (byte)'6'
  }

  /// <summary>
  /// TFtdcSystemParamIDType是一个系统参数代码类型
  /// </summary>
  public enum CTPStockSystemParamIDType : byte
  {
    /// <summary>
    /// 投资者代码最小长度
    /// </summary>
    [Description("投资者代码最小长度")]
    InvestorIDMinLength = (byte)'1',
    /// <summary>
    /// 投资者帐号代码最小长度
    /// </summary>
    [Description("投资者帐号代码最小长度")]
    AccountIDMinLength = (byte)'2',
    /// <summary>
    /// 投资者开户默认登录权限
    /// </summary>
    [Description("投资者开户默认登录权限")]
    UserRightLogon = (byte)'3',
    /// <summary>
    /// 投资者交易结算单成交汇总方式
    /// </summary>
    [Description("投资者交易结算单成交汇总方式")]
    SettlementBillTrade = (byte)'4',
    /// <summary>
    /// 统一开户更新交易编码方式
    /// </summary>
    [Description("统一开户更新交易编码方式")]
    TradingCode = (byte)'5',
    /// <summary>
    /// 结算是否判断存在未复核的出入金和分项资金
    /// </summary>
    [Description("结算是否判断存在未复核的出入金和分项资金")]
    CheckFund = (byte)'6',
    /// <summary>
    /// 上传的结算文件标识
    /// </summary>
    [Description("上传的结算文件标识")]
    UploadSettlementFile = (byte)'U',
    /// <summary>
    /// 下载的保证金存管文件
    /// </summary>
    [Description("下载的保证金存管文件")]
    DownloadCSRCFile = (byte)'D',
    /// <summary>
    /// 结算单文件标识
    /// </summary>
    [Description("结算单文件标识")]
    SettlementBillFile = (byte)'S',
    /// <summary>
    /// 证监会文件标识
    /// </summary>
    [Description("证监会文件标识")]
    CSRCOthersFile = (byte)'C',
    /// <summary>
    /// 投资者照片路径
    /// </summary>
    [Description("投资者照片路径")]
    InvestorPhoto = (byte)'P'
  }

  /// <summary>
  /// TFtdcTradeParamIDType是一个交易系统参数代码类型
  /// </summary>
  public enum CTPStockTradeParamIDType : byte
  {
    /// <summary>
    /// 系统加密算法
    /// </summary>
    [Description("系统加密算法")]
    EncryptionStandard = (byte)'E',
    /// <summary>
    /// 系统风险算法
    /// </summary>
    [Description("系统风险算法")]
    RiskMode = (byte)'R',
    /// <summary>
    /// 系统风险算法是否全局 0-否 1-是
    /// </summary>
    [Description("系统风险算法是否全局 0-否 1-是")]
    RiskModeGlobal = (byte)'G'
  }

  /// <summary>
  /// TFtdcFileIDType是一个文件标识类型
  /// </summary>
  public enum CTPStockFileIDType : byte
  {
    /// <summary>
    /// 资金数据
    /// </summary>
    [Description("资金数据")]
    SettlementFund = (byte)'F',
    /// <summary>
    /// 成交数据
    /// </summary>
    [Description("成交数据")]
    Trade = (byte)'T',
    /// <summary>
    /// 投资者持仓数据
    /// </summary>
    [Description("投资者持仓数据")]
    InvestorPosition = (byte)'P',
    /// <summary>
    /// 投资者分项资金数据
    /// </summary>
    [Description("投资者分项资金数据")]
    SubEntryFund = (byte)'O'
  }

  /// <summary>
  /// TFtdcFileTypeType是一个文件上传类型类型
  /// </summary>
  public enum CTPStockFileType : byte
  {
    /// <summary>
    /// 结算
    /// </summary>
    [Description("结算")]
    Settlement = (byte)'0',
    /// <summary>
    /// 核对
    /// </summary>
    [Description("核对")]
    Check = (byte)'1'
  }

  /// <summary>
  /// TFtdcFileFormatType是一个文件格式类型
  /// </summary>
  public enum CTPStockFileFormatType : byte
  {
    /// <summary>
    /// 文本文件(.txt)
    /// </summary>
    [Description("文本文件(.txt)")]
    Txt = (byte)'0',
    /// <summary>
    /// 压缩文件(.zip)
    /// </summary>
    [Description("压缩文件(.zip)")]
    Zip = (byte)'1',
    /// <summary>
    /// DBF文件(.dbf)
    /// </summary>
    [Description("DBF文件(.dbf)")]
    DBF = (byte)'2'
  }

  /// <summary>
  /// TFtdcFileUploadStatusType是一个文件状态类型
  /// </summary>
  public enum CTPStockFileUploadStatusType : byte
  {
    /// <summary>
    /// 上传成功
    /// </summary>
    [Description("上传成功")]
    SucceedUpload = (byte)'1',
    /// <summary>
    /// 上传失败
    /// </summary>
    [Description("上传失败")]
    FailedUpload = (byte)'2',
    /// <summary>
    /// 导入成功
    /// </summary>
    [Description("导入成功")]
    SucceedLoad = (byte)'3',
    /// <summary>
    /// 导入部分成功
    /// </summary>
    [Description("导入部分成功")]
    PartSucceedLoad = (byte)'4',
    /// <summary>
    /// 导入失败
    /// </summary>
    [Description("导入失败")]
    FailedLoad = (byte)'5'
  }

  /// <summary>
  /// TFtdcTransferDirectionType是一个移仓方向类型
  /// </summary>
  public enum CTPStockTransferDirectionType : byte
  {
    /// <summary>
    /// 移出
    /// </summary>
    [Description("移出")]
    Out = (byte)'0',
    /// <summary>
    /// 移入
    /// </summary>
    [Description("移入")]
    In = (byte)'1'
  }

  /// <summary>
  /// TFtdcBankFlagType是一个银行统一标识类型类型
  /// </summary>
  public enum CTPStockBankFlagType : byte
  {
    /// <summary>
    /// 工商银行
    /// </summary>
    [Description("工商银行")]
    ICBC = (byte)'1',
    /// <summary>
    /// 农业银行
    /// </summary>
    [Description("农业银行")]
    ABC = (byte)'2',
    /// <summary>
    /// 中国银行
    /// </summary>
    [Description("中国银行")]
    BC = (byte)'3',
    /// <summary>
    /// 建设银行
    /// </summary>
    [Description("建设银行")]
    CBC = (byte)'4',
    /// <summary>
    /// 交通银行
    /// </summary>
    [Description("交通银行")]
    BOC = (byte)'5',
    /// <summary>
    /// 其他银行
    /// </summary>
    [Description("其他银行")]
    Other = (byte)'Z'
  }

  /// <summary>
  /// TFtdcSpecialCreateRuleType是一个特殊的创建规则类型
  /// </summary>
  public enum CTPStockSpecialCreateRuleType : byte
  {
    /// <summary>
    /// 没有特殊创建规则
    /// </summary>
    [Description("没有特殊创建规则")]
    NoSpecialRule = (byte)'0',
    /// <summary>
    /// 不包含春节
    /// </summary>
    [Description("不包含春节")]
    NoSpringFestival = (byte)'1'
  }

  /// <summary>
  /// TFtdcBasisPriceTypeType是一个挂牌基准价类型类型
  /// </summary>
  public enum CTPStockBasisPriceType : byte
  {
    /// <summary>
    /// 上一合约结算价
    /// </summary>
    [Description("上一合约结算价")]
    LastSettlement = (byte)'1',
    /// <summary>
    /// 上一合约收盘价
    /// </summary>
    [Description("上一合约收盘价")]
    LaseClose = (byte)'2'
  }

  /// <summary>
  /// TFtdcProductLifePhaseType是一个产品生命周期状态类型
  /// </summary>
  public enum CTPStockProductLifePhaseType : byte
  {
    /// <summary>
    /// 活跃
    /// </summary>
    [Description("活跃")]
    Active = (byte)'1',
    /// <summary>
    /// 不活跃
    /// </summary>
    [Description("不活跃")]
    NonActive = (byte)'2',
    /// <summary>
    /// 注销
    /// </summary>
    [Description("注销")]
    Canceled = (byte)'3'
  }

  /// <summary>
  /// TFtdcDeliveryModeType是一个交割方式类型
  /// </summary>
  public enum CTPStockDeliveryModeType : byte
  {
    /// <summary>
    /// 现金交割
    /// </summary>
    [Description("现金交割")]
    CashDeliv = (byte)'1',
    /// <summary>
    /// 实物交割
    /// </summary>
    [Description("实物交割")]
    CommodityDeliv = (byte)'2'
  }

  /// <summary>
  /// TFtdcFundIOTypeType是一个出入金类型类型
  /// </summary>
  public enum CTPStockFundIOType : byte
  {
    /// <summary>
    /// 出入金
    /// </summary>
    [Description("出入金")]
    FundIO = (byte)'1',
    /// <summary>
    /// 银期转帐
    /// </summary>
    [Description("银期转帐")]
    Transfer = (byte)'2'
  }

  /// <summary>
  /// TFtdcFundTypeType是一个资金类型类型
  /// </summary>
  public enum CTPStockFundType : byte
  {
    /// <summary>
    /// 银行存款
    /// </summary>
    [Description("银行存款")]
    Deposite = (byte)'1',
    /// <summary>
    /// 分项资金
    /// </summary>
    [Description("分项资金")]
    ItemFund = (byte)'2',
    /// <summary>
    /// 公司调整
    /// </summary>
    [Description("公司调整")]
    Company = (byte)'3'
  }

  /// <summary>
  /// TFtdcFundDirectionType是一个出入金方向类型
  /// </summary>
  public enum CTPStockFundDirectionType : byte
  {
    /// <summary>
    /// 入金
    /// </summary>
    [Description("入金")]
    In = (byte)'1',
    /// <summary>
    /// 出金
    /// </summary>
    [Description("出金")]
    Out = (byte)'2'
  }

  /// <summary>
  /// TFtdcFundStatusType是一个资金状态类型
  /// </summary>
  public enum CTPStockFundStatusType : byte
  {
    /// <summary>
    /// 已录入
    /// </summary>
    [Description("已录入")]
    Record = (byte)'1',
    /// <summary>
    /// 已复核
    /// </summary>
    [Description("已复核")]
    Check = (byte)'2',
    /// <summary>
    /// 已冲销
    /// </summary>
    [Description("已冲销")]
    Charge = (byte)'3'
  }

  /// <summary>
  /// TFtdcPublishStatusType是一个发布状态类型
  /// </summary>
  public enum CTPStockPublishStatusType : byte
  {
    /// <summary>
    /// 未发布
    /// </summary>
    [Description("未发布")]
    None = (byte)'1',
    /// <summary>
    /// 正在发布
    /// </summary>
    [Description("正在发布")]
    Publishing = (byte)'2',
    /// <summary>
    /// 已发布
    /// </summary>
    [Description("已发布")]
    Published = (byte)'3'
  }

  /// <summary>
  /// TFtdcSystemStatusType是一个系统状态类型
  /// </summary>
  public enum CTPStockSystemStatusType : byte
  {
    /// <summary>
    /// 不活跃
    /// </summary>
    [Description("不活跃")]
    NonActive = (byte)'1',
    /// <summary>
    /// 启动
    /// </summary>
    [Description("启动")]
    Startup = (byte)'2',
    /// <summary>
    /// 交易开始初始化
    /// </summary>
    [Description("交易开始初始化")]
    Initialize = (byte)'3',
    /// <summary>
    /// 交易完成初始化
    /// </summary>
    [Description("交易完成初始化")]
    Initialized = (byte)'4',
    /// <summary>
    /// 收市开始
    /// </summary>
    [Description("收市开始")]
    Close = (byte)'5',
    /// <summary>
    /// 收市完成
    /// </summary>
    [Description("收市完成")]
    Closed = (byte)'6',
    /// <summary>
    /// 结算
    /// </summary>
    [Description("结算")]
    Settlement = (byte)'7'
  }

  /// <summary>
  /// TFtdcSettlementStatusType是一个结算状态类型
  /// </summary>
  public enum CTPStockSettlementStatusType : byte
  {
    /// <summary>
    /// 初始
    /// </summary>
    [Description("初始")]
    Initialize = (byte)'0',
    /// <summary>
    /// 结算中
    /// </summary>
    [Description("结算中")]
    Settlementing = (byte)'1',
    /// <summary>
    /// 已结算
    /// </summary>
    [Description("已结算")]
    Settlemented = (byte)'2',
    /// <summary>
    /// 结算完成
    /// </summary>
    [Description("结算完成")]
    Finished = (byte)'3'
  }

  /// <summary>
  /// TFtdcInvestorTypeType是一个投资者类型类型
  /// </summary>
  public enum CTPStockInvestorType : byte
  {
    /// <summary>
    /// 自然人
    /// </summary>
    [Description("自然人")]
    Person = (byte)'0',
    /// <summary>
    /// 法人
    /// </summary>
    [Description("法人")]
    Company = (byte)'1',
    /// <summary>
    /// 投资基金
    /// </summary>
    [Description("投资基金")]
    Fund = (byte)'2'
  }

  /// <summary>
  /// TFtdcBrokerTypeType是一个经纪公司类型类型
  /// </summary>
  public enum CTPStockBrokerType : byte
  {
    /// <summary>
    /// 交易会员
    /// </summary>
    [Description("交易会员")]
    Trade = (byte)'0',
    /// <summary>
    /// 交易结算会员
    /// </summary>
    [Description("交易结算会员")]
    TradeSettle = (byte)'1'
  }

  /// <summary>
  /// TFtdcRiskLevelType是一个风险等级类型
  /// </summary>
  public enum CTPStockRiskLevelType : byte
  {
    /// <summary>
    /// 低风险客户
    /// </summary>
    [Description("低风险客户")]
    Low = (byte)'1',
    /// <summary>
    /// 普通客户
    /// </summary>
    [Description("普通客户")]
    Normal = (byte)'2',
    /// <summary>
    /// 关注客户
    /// </summary>
    [Description("关注客户")]
    Focus = (byte)'3',
    /// <summary>
    /// 风险客户
    /// </summary>
    [Description("风险客户")]
    Risk = (byte)'4'
  }

  /// <summary>
  /// TFtdcFeeAcceptStyleType是一个手续费收取方式类型
  /// </summary>
  public enum CTPStockFeeAcceptStyleType : byte
  {
    /// <summary>
    /// 按交易收取
    /// </summary>
    [Description("按交易收取")]
    ByTrade = (byte)'1',
    /// <summary>
    /// 按交割收取
    /// </summary>
    [Description("按交割收取")]
    ByDeliv = (byte)'2',
    /// <summary>
    /// 不收
    /// </summary>
    [Description("不收")]
    None = (byte)'3',
    /// <summary>
    /// 按指定手续费收取
    /// </summary>
    [Description("按指定手续费收取")]
    FixFee = (byte)'4'
  }

  /// <summary>
  /// TFtdcPasswordTypeType是一个密码类型类型
  /// </summary>
  public enum CTPStockPasswordType : byte
  {
    /// <summary>
    /// 交易密码
    /// </summary>
    [Description("交易密码")]
    Trade = (byte)'1',
    /// <summary>
    /// 资金密码
    /// </summary>
    [Description("资金密码")]
    Account = (byte)'2'
  }

  /// <summary>
  /// TFtdcAlgorithmType是一个盈亏算法类型
  /// </summary>
  public enum CTPStockAlgorithmType : byte
  {
    /// <summary>
    /// 浮盈浮亏都计算
    /// </summary>
    [Description("浮盈浮亏都计算")]
    All = (byte)'1',
    /// <summary>
    /// 浮盈不计，浮亏计
    /// </summary>
    [Description("浮盈不计，浮亏计")]
    OnlyLost = (byte)'2',
    /// <summary>
    /// 浮盈计，浮亏不计
    /// </summary>
    [Description("浮盈计，浮亏不计")]
    OnlyGain = (byte)'3',
    /// <summary>
    /// 浮盈浮亏都不计算
    /// </summary>
    [Description("浮盈浮亏都不计算")]
    None = (byte)'4'
  }

  /// <summary>
  /// TFtdcIncludeCloseProfitType是一个是否包含平仓盈利类型
  /// </summary>
  public enum CTPStockIncludeCloseProfitType : byte
  {
    /// <summary>
    /// 包含平仓盈利
    /// </summary>
    [Description("包含平仓盈利")]
    Include = (byte)'0',
    /// <summary>
    /// 不包含平仓盈利
    /// </summary>
    [Description("不包含平仓盈利")]
    NotInclude = (byte)'2'
  }

  /// <summary>
  /// TFtdcAllWithoutTradeType是一个是否受可提比例限制类型
  /// </summary>
  public enum CTPStockAllWithoutTradeType : byte
  {
    /// <summary>
    /// 不受可提比例限制
    /// </summary>
    [Description("不受可提比例限制")]
    Enable = (byte)'0',
    /// <summary>
    /// 受可提比例限制
    /// </summary>
    [Description("受可提比例限制")]
    Disable = (byte)'2'
  }

  /// <summary>
  /// TFtdcFuturePwdFlagType是一个资金密码核对标志类型
  /// </summary>
  public enum CTPStockFuturePwdFlagType : byte
  {
    /// <summary>
    /// 不核对
    /// </summary>
    [Description("不核对")]
    UnCheck = (byte)'0',
    /// <summary>
    /// 核对
    /// </summary>
    [Description("核对")]
    Check = (byte)'1'
  }

  /// <summary>
  /// TFtdcTransferTypeType是一个银期转账类型类型
  /// </summary>
  public enum CTPStockTransferType : byte
  {
    /// <summary>
    /// 银行转期货
    /// </summary>
    [Description("银行转期货")]
    BankToFuture = (byte)'0',
    /// <summary>
    /// 期货转银行
    /// </summary>
    [Description("期货转银行")]
    FutureToBank = (byte)'1'
  }

  /// <summary>
  /// TFtdcTransferValidFlagType是一个转账有效标志类型
  /// </summary>
  public enum CTPStockTransferValidFlagType : byte
  {
    /// <summary>
    /// 无效或失败
    /// </summary>
    [Description("无效或失败")]
    Invalid = (byte)'0',
    /// <summary>
    /// 有效
    /// </summary>
    [Description("有效")]
    Valid = (byte)'1',
    /// <summary>
    /// 冲正
    /// </summary>
    [Description("冲正")]
    Reverse = (byte)'2'
  }

  /// <summary>
  /// TFtdcReasonType是一个事由类型
  /// </summary>
  public enum CTPStockReasonType : byte
  {
    /// <summary>
    /// 错单
    /// </summary>
    [Description("错单")]
    CD = (byte)'0',
    /// <summary>
    /// 资金在途
    /// </summary>
    [Description("资金在途")]
    ZT = (byte)'1',
    /// <summary>
    /// 其它
    /// </summary>
    [Description("其它")]
    QT = (byte)'2'
  }

  /// <summary>
  /// TFtdcSexType是一个性别类型
  /// </summary>
  public enum CTPStockSexType : byte
  {
    /// <summary>
    /// 未知
    /// </summary>
    [Description("未知")]
    None = (byte)'0',
    /// <summary>
    /// 男
    /// </summary>
    [Description("男")]
    Man = (byte)'1',
    /// <summary>
    /// 女
    /// </summary>
    [Description("女")]
    Woman = (byte)'2'
  }

  /// <summary>
  /// TFtdcUserTypeType是一个用户类型类型
  /// </summary>
  public enum CTPStockUserType : byte
  {
    /// <summary>
    /// 投资者
    /// </summary>
    [Description("投资者")]
    Investor = (byte)'0',
    /// <summary>
    /// 操作员
    /// </summary>
    [Description("操作员")]
    Operator = (byte)'1',
    /// <summary>
    /// 管理员
    /// </summary>
    [Description("管理员")]
    SuperUser = (byte)'2'
  }

  /// <summary>
  /// TFtdcRateTypeType是一个费率类型类型
  /// </summary>
  public enum CTPStockRateType : byte
  {
    /// <summary>
    /// 保证金率
    /// </summary>
    [Description("保证金率")]
    MarginRate = (byte)'2',
    /// <summary>
    /// 手续费率
    /// </summary>
    [Description("手续费率")]
    CommRate = (byte)'1',
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    AllRate = (byte)'0'
  }

  /// <summary>
  /// TFtdcNoteTypeType是一个通知类型类型
  /// </summary>
  public enum CTPStockNoteType : byte
  {
    /// <summary>
    /// 交易结算单
    /// </summary>
    [Description("交易结算单")]
    TradeSettleBill = (byte)'1',
    /// <summary>
    /// 交易结算月报
    /// </summary>
    [Description("交易结算月报")]
    TradeSettleMonth = (byte)'2',
    /// <summary>
    /// 追加保证金通知书
    /// </summary>
    [Description("追加保证金通知书")]
    CallMarginNotes = (byte)'3',
    /// <summary>
    /// 强行平仓通知书
    /// </summary>
    [Description("强行平仓通知书")]
    ForceCloseNotes = (byte)'4',
    /// <summary>
    /// 成交通知书
    /// </summary>
    [Description("成交通知书")]
    TradeNotes = (byte)'5',
    /// <summary>
    /// 交割通知书
    /// </summary>
    [Description("交割通知书")]
    DelivNotes = (byte)'6'
  }

  /// <summary>
  /// TFtdcSettlementStyleType是一个结算单方式类型
  /// </summary>
  public enum CTPStockSettlementStyleType : byte
  {
    /// <summary>
    /// 逐日盯市
    /// </summary>
    [Description("逐日盯市")]
    Day = (byte)'1',
    /// <summary>
    /// 逐笔对冲
    /// </summary>
    [Description("逐笔对冲")]
    Volume = (byte)'2'
  }

  /// <summary>
  /// TFtdcSettlementBillTypeType是一个结算单类型类型
  /// </summary>
  public enum CTPStockSettlementBillType : byte
  {
    /// <summary>
    /// 日报
    /// </summary>
    [Description("日报")]
    Day = (byte)'0',
    /// <summary>
    /// 月报
    /// </summary>
    [Description("月报")]
    Month = (byte)'1'
  }

  /// <summary>
  /// TFtdcUserRightTypeType是一个客户权限类型类型
  /// </summary>
  public enum CTPStockUserRightType : byte
  {
    /// <summary>
    /// 登录
    /// </summary>
    [Description("登录")]
    Logon = (byte)'1',
    /// <summary>
    /// 银期转帐
    /// </summary>
    [Description("银期转帐")]
    Transfer = (byte)'2',
    /// <summary>
    /// 邮寄结算单
    /// </summary>
    [Description("邮寄结算单")]
    EMail = (byte)'3',
    /// <summary>
    /// 传真结算单
    /// </summary>
    [Description("传真结算单")]
    Fax = (byte)'4',
    /// <summary>
    /// 条件单
    /// </summary>
    [Description("条件单")]
    ConditionOrder = (byte)'5'
  }

  /// <summary>
  /// TFtdcMarginPriceTypeType是一个保证金价格类型类型
  /// </summary>
  public enum CTPStockMarginPriceType : byte
  {
    /// <summary>
    /// 昨结算价
    /// </summary>
    [Description("昨结算价")]
    PreSettlementPrice = (byte)'1',
    /// <summary>
    /// 最新价
    /// </summary>
    [Description("最新价")]
    SettlementPrice = (byte)'2',
    /// <summary>
    /// 成交均价
    /// </summary>
    [Description("成交均价")]
    AveragePrice = (byte)'3',
    /// <summary>
    /// 开仓价
    /// </summary>
    [Description("开仓价")]
    OpenPrice = (byte)'4'
  }

  /// <summary>
  /// TFtdcBillGenStatusType是一个结算单生成状态类型
  /// </summary>
  public enum CTPStockBillGenStatusType : byte
  {
    /// <summary>
    /// 不生成
    /// </summary>
    [Description("不生成")]
    None = (byte)'0',
    /// <summary>
    /// 未生成
    /// </summary>
    [Description("未生成")]
    NoGenerated = (byte)'1',
    /// <summary>
    /// 已生成
    /// </summary>
    [Description("已生成")]
    Generated = (byte)'2'
  }

  /// <summary>
  /// TFtdcAlgoTypeType是一个算法类型类型
  /// </summary>
  public enum CTPStockAlgoType : byte
  {
    /// <summary>
    /// 持仓处理算法
    /// </summary>
    [Description("持仓处理算法")]
    HandlePositionAlgo = (byte)'1',
    /// <summary>
    /// 寻找保证金率算法
    /// </summary>
    [Description("寻找保证金率算法")]
    FindMarginRateAlgo = (byte)'2'
  }

  /// <summary>
  /// TFtdcHandlePositionAlgoIDType是一个持仓处理算法编号类型
  /// </summary>
  public enum CTPStockHandlePositionAlgoIDType : byte
  {
    /// <summary>
    /// 基本
    /// </summary>
    [Description("基本")]
    Base = (byte)'1',
    /// <summary>
    /// 大连商品交易所
    /// </summary>
    [Description("大连商品交易所")]
    DCE = (byte)'2',
    /// <summary>
    /// 郑州商品交易所
    /// </summary>
    [Description("郑州商品交易所")]
    CZCE = (byte)'3',
    /// <summary>
    /// 非交易
    /// </summary>
    [Description("非交易")]
    NoneTrade = (byte)'4',
    /// <summary>
    /// 证券
    /// </summary>
    [Description("证券")]
    Stock = (byte)'5'
  }

  /// <summary>
  /// TFtdcFindMarginRateAlgoIDType是一个寻找保证金率算法编号类型
  /// </summary>
  public enum CTPStockFindMarginRateAlgoIDType : byte
  {
    /// <summary>
    /// 基本
    /// </summary>
    [Description("基本")]
    Base = (byte)'1',
    /// <summary>
    /// 大连商品交易所
    /// </summary>
    [Description("大连商品交易所")]
    DCE = (byte)'2',
    /// <summary>
    /// 郑州商品交易所
    /// </summary>
    [Description("郑州商品交易所")]
    CZCE = (byte)'3'
  }

  /// <summary>
  /// TFtdcHandleTradingAccountAlgoIDType是一个资金处理算法编号类型
  /// </summary>
  public enum CTPStockHandleTradingAccountAlgoIDType : byte
  {
    /// <summary>
    /// 基本
    /// </summary>
    [Description("基本")]
    Base = (byte)'1',
    /// <summary>
    /// 大连商品交易所
    /// </summary>
    [Description("大连商品交易所")]
    DCE = (byte)'2',
    /// <summary>
    /// 郑州商品交易所
    /// </summary>
    [Description("郑州商品交易所")]
    CZCE = (byte)'3'
  }

  /// <summary>
  /// TFtdcPersonTypeType是一个联系人类型类型
  /// </summary>
  public enum CTPStockPersonType : byte
  {
    /// <summary>
    /// 指定下单人
    /// </summary>
    [Description("指定下单人")]
    Order = (byte)'1',
    /// <summary>
    /// 开户授权人
    /// </summary>
    [Description("开户授权人")]
    Open = (byte)'2',
    /// <summary>
    /// 资金调拨人
    /// </summary>
    [Description("资金调拨人")]
    Fund = (byte)'3',
    /// <summary>
    /// 结算单确认人
    /// </summary>
    [Description("结算单确认人")]
    Settlement = (byte)'4'
  }

  /// <summary>
  /// TFtdcQueryInvestorRangeType是一个查询范围类型
  /// </summary>
  public enum CTPStockQueryInvestorRangeType : byte
  {
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    All = (byte)'1',
    /// <summary>
    /// 查询分类
    /// </summary>
    [Description("查询分类")]
    Group = (byte)'2',
    /// <summary>
    /// 单一投资者
    /// </summary>
    [Description("单一投资者")]
    Single = (byte)'3'
  }

  /// <summary>
  /// TFtdcInvestorRiskStatusType是一个投资者风险状态类型
  /// </summary>
  public enum CTPStockInvestorRiskStatusType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = (byte)'1',
    /// <summary>
    /// 警告
    /// </summary>
    [Description("警告")]
    Warn = (byte)'2',
    /// <summary>
    /// 追保
    /// </summary>
    [Description("追保")]
    Call = (byte)'3',
    /// <summary>
    /// 强平
    /// </summary>
    [Description("强平")]
    Force = (byte)'4',
    /// <summary>
    /// 异常
    /// </summary>
    [Description("异常")]
    Exception = (byte)'5'
  }

  /// <summary>
  /// TFtdcUserEventTypeType是一个用户事件类型类型
  /// </summary>
  public enum CTPStockUserEventType : byte
  {
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    All = (byte)' ',
    /// <summary>
    /// 登录
    /// </summary>
    [Description("登录")]
    Login = (byte)'1',
    /// <summary>
    /// 登出
    /// </summary>
    [Description("登出")]
    Logout = (byte)'2',
    /// <summary>
    /// 交易成功
    /// </summary>
    [Description("交易成功")]
    Trading = (byte)'3',
    /// <summary>
    /// 交易失败
    /// </summary>
    [Description("交易失败")]
    TradingError = (byte)'4',
    /// <summary>
    /// 修改密码
    /// </summary>
    [Description("修改密码")]
    UpdatePassword = (byte)'5',
    /// <summary>
    /// 其他
    /// </summary>
    [Description("其他")]
    Other = (byte)'9'
  }

  /// <summary>
  /// TFtdcCloseStyleType是一个平仓方式类型
  /// </summary>
  public enum CTPStockCloseStyleType : byte
  {
    /// <summary>
    /// 先开先平
    /// </summary>
    [Description("先开先平")]
    Close = (byte)'0',
    /// <summary>
    /// 先平今再平昨
    /// </summary>
    [Description("先平今再平昨")]
    CloseToday = (byte)'1'
  }

  /// <summary>
  /// TFtdcStatModeType是一个统计方式类型
  /// </summary>
  public enum CTPStockStatModeType : byte
  {
    /// <summary>
    /// ----
    /// </summary>
    [Description("----")]
    Non = (byte)'0',
    /// <summary>
    /// 按合约统计
    /// </summary>
    [Description("按合约统计")]
    Instrument = (byte)'1',
    /// <summary>
    /// 按产品统计
    /// </summary>
    [Description("按产品统计")]
    Product = (byte)'2',
    /// <summary>
    /// 按投资者统计
    /// </summary>
    [Description("按投资者统计")]
    Investor = (byte)'3'
  }

  /// <summary>
  /// TFtdcParkedOrderStatusType是一个预埋单状态类型
  /// </summary>
  public enum CTPStockParkedOrderStatusType : byte
  {
    /// <summary>
    /// 未发送
    /// </summary>
    [Description("未发送")]
    NotSend = (byte)'1',
    /// <summary>
    /// 已发送
    /// </summary>
    [Description("已发送")]
    Send = (byte)'2',
    /// <summary>
    /// 已删除
    /// </summary>
    [Description("已删除")]
    Deleted = (byte)'3'
  }

  /// <summary>
  /// TFtdcVirDealStatusType是一个处理状态类型
  /// </summary>
  public enum CTPStockVirDealStatusType : byte
  {
    /// <summary>
    /// 正在处理
    /// </summary>
    [Description("正在处理")]
    Dealing = (byte)'1',
    /// <summary>
    /// 处理成功
    /// </summary>
    [Description("处理成功")]
    DeaclSucceed = (byte)'2'
  }

  /// <summary>
  /// TFtdcOrgSystemIDType是一个原有系统代码类型
  /// </summary>
  public enum CTPStockOrgSystemIDType : byte
  {
    /// <summary>
    /// 综合交易平台
    /// </summary>
    [Description("综合交易平台")]
    Standard = (byte)'0',
    /// <summary>
    /// 易盛系统
    /// </summary>
    [Description("易盛系统")]
    ESunny = (byte)'1',
    /// <summary>
    /// 金仕达V6系统
    /// </summary>
    [Description("金仕达V6系统")]
    KingStarV6 = (byte)'2'
  }

  /// <summary>
  /// TFtdcVirTradeStatusType是一个交易状态类型
  /// </summary>
  public enum CTPStockVirTradeStatusType : byte
  {
    /// <summary>
    /// 正常处理中
    /// </summary>
    [Description("正常处理中")]
    NaturalDeal = (byte)'0',
    /// <summary>
    /// 成功结束
    /// </summary>
    [Description("成功结束")]
    SucceedEnd = (byte)'1',
    /// <summary>
    /// 失败结束
    /// </summary>
    [Description("失败结束")]
    FailedEND = (byte)'2',
    /// <summary>
    /// 异常中
    /// </summary>
    [Description("异常中")]
    Exception = (byte)'3',
    /// <summary>
    /// 已人工异常处理
    /// </summary>
    [Description("已人工异常处理")]
    ManualDeal = (byte)'4',
    /// <summary>
    /// 通讯异常 ，请人工处理
    /// </summary>
    [Description("通讯异常 ，请人工处理")]
    MesException = (byte)'5',
    /// <summary>
    /// 系统出错，请人工处理
    /// </summary>
    [Description("系统出错，请人工处理")]
    SysException = (byte)'6'
  }

  /// <summary>
  /// TFtdcVirBankAccTypeType是一个银行帐户类型类型
  /// </summary>
  public enum CTPStockVirBankAccType : byte
  {
    /// <summary>
    /// 存折
    /// </summary>
    [Description("存折")]
    BankBook = (byte)'1',
    /// <summary>
    /// 储蓄卡
    /// </summary>
    [Description("储蓄卡")]
    BankCard = (byte)'2',
    /// <summary>
    /// 信用卡
    /// </summary>
    [Description("信用卡")]
    CreditCard = (byte)'3'
  }

  /// <summary>
  /// TFtdcVirementStatusType是一个银行帐户类型类型
  /// </summary>
  public enum CTPStockVirementStatusType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Natural = (byte)'0',
    /// <summary>
    /// 销户
    /// </summary>
    [Description("销户")]
    Canceled = (byte)'9'
  }

  /// <summary>
  /// TFtdcVirementAvailAbilityType是一个有效标志类型
  /// </summary>
  public enum CTPStockVirementAvailAbilityType : byte
  {
    /// <summary>
    /// 未确认
    /// </summary>
    [Description("未确认")]
    NoAvailAbility = (byte)'0',
    /// <summary>
    /// 有效
    /// </summary>
    [Description("有效")]
    AvailAbility = (byte)'1',
    /// <summary>
    /// 冲正
    /// </summary>
    [Description("冲正")]
    Repeal = (byte)'2'
  }

  /// <summary>
  /// TFtdcVirementTradeCodeType是一个交易代码类型
  /// </summary>
  public enum CTPStockVirementTradeCodeType : byte
  {
    ///// <summary>
    ///// 银行发起银行资金转期货
    ///// </summary>
    //[Description("银行发起银行资金转期货")]
    //BankBankToFuture = (byte)'102001',
    ///// <summary>
    ///// 银行发起期货资金转银行
    ///// </summary>
    //[Description("银行发起期货资金转银行")]
    //BankFutureToBank = (byte)'102002',
    ///// <summary>
    ///// 期货发起银行资金转期货
    ///// </summary>
    //[Description("期货发起银行资金转期货")]
    //FutureBankToFuture = (byte)'202001',
    ///// <summary>
    ///// 期货发起期货资金转银行
    ///// </summary>
    //[Description("期货发起期货资金转银行")]
    //FutureFutureToBank = (byte)'202002'
  }

  /// <summary>
  /// TFtdcCFMMCKeyKindType是一个动态密钥类别(保证金监管)类型
  /// </summary>
  public enum CTPStockCFMMCKeyKindType : byte
  {
    /// <summary>
    /// 主动请求更新
    /// </summary>
    [Description("主动请求更新")]
    REQUEST = (byte)'R',
    /// <summary>
    /// CFMMC自动更新
    /// </summary>
    [Description("CFMMC自动更新")]
    AUTO = (byte)'A',
    /// <summary>
    /// CFMMC手动更新
    /// </summary>
    [Description("CFMMC手动更新")]
    MANUAL = (byte)'M'
  }

  /// <summary>
  /// TFtdcCertificationTypeType是一个证件类型类型
  /// </summary>
  public enum CTPStockCertificationType : byte
  {
    /// <summary>
    /// 身份证
    /// </summary>
    [Description("身份证")]
    IDCard = (byte)'0',
    /// <summary>
    /// 护照
    /// </summary>
    [Description("护照")]
    Passport = (byte)'1',
    /// <summary>
    /// 军官证
    /// </summary>
    [Description("军官证")]
    OfficerIDCard = (byte)'2',
    /// <summary>
    /// 士兵证
    /// </summary>
    [Description("士兵证")]
    SoldierIDCard = (byte)'3',
    /// <summary>
    /// 回乡证
    /// </summary>
    [Description("回乡证")]
    HomeComingCard = (byte)'4',
    /// <summary>
    /// 户口簿
    /// </summary>
    [Description("户口簿")]
    HouseholdRegister = (byte)'5',
    /// <summary>
    /// 营业执照号
    /// </summary>
    [Description("营业执照号")]
    LicenseNo = (byte)'6',
    /// <summary>
    /// 组织机构代码证
    /// </summary>
    [Description("组织机构代码证")]
    InstitutionCodeCard = (byte)'7',
    /// <summary>
    /// 临时营业执照号
    /// </summary>
    [Description("临时营业执照号")]
    TempLicenseNo = (byte)'8',
    /// <summary>
    /// 民办非企业登记证书
    /// </summary>
    [Description("民办非企业登记证书")]
    NoEnterpriseLicenseNo = (byte)'9',
    /// <summary>
    /// 其他证件
    /// </summary>
    [Description("其他证件")]
    OtherCard = (byte)'x',
    /// <summary>
    /// 主管部门批文
    /// </summary>
    [Description("主管部门批文")]
    SuperDepAgree = (byte)'a'
  }

  /// <summary>
  /// TFtdcFileBusinessCodeType是一个文件业务功能类型
  /// </summary>
  public enum CTPStockFileBusinessCodeType : byte
  {
    /// <summary>
    /// 其他
    /// </summary>
    [Description("其他")]
    Others = (byte)'0',
    /// <summary>
    /// 转账交易明细对账
    /// </summary>
    [Description("转账交易明细对账")]
    TransferDetails = (byte)'1',
    /// <summary>
    /// 客户账户状态对账
    /// </summary>
    [Description("客户账户状态对账")]
    CustAccStatus = (byte)'2',
    /// <summary>
    /// 账户类交易明细对账
    /// </summary>
    [Description("账户类交易明细对账")]
    AccountTradeDetails = (byte)'3',
    /// <summary>
    /// 期货账户信息变更明细对账
    /// </summary>
    [Description("期货账户信息变更明细对账")]
    FutureAccountChangeInfoDetails = (byte)'4',
    /// <summary>
    /// 客户资金台账余额明细对账
    /// </summary>
    [Description("客户资金台账余额明细对账")]
    CustMoneyDetail = (byte)'5',
    /// <summary>
    /// 客户销户结息明细对账
    /// </summary>
    [Description("客户销户结息明细对账")]
    CustCancelAccountInfo = (byte)'6',
    /// <summary>
    /// 客户资金余额对账结果
    /// </summary>
    [Description("客户资金余额对账结果")]
    CustMoneyResult = (byte)'7',
    /// <summary>
    /// 其它对账异常结果文件
    /// </summary>
    [Description("其它对账异常结果文件")]
    OthersExceptionResult = (byte)'8',
    /// <summary>
    /// 客户结息净额明细
    /// </summary>
    [Description("客户结息净额明细")]
    CustInterestNetMoneyDetails = (byte)'9',
    /// <summary>
    /// 客户资金交收明细
    /// </summary>
    [Description("客户资金交收明细")]
    CustMoneySendAndReceiveDetails = (byte)'a',
    /// <summary>
    /// 法人存管银行资金交收汇总
    /// </summary>
    [Description("法人存管银行资金交收汇总")]
    CorporationMoneyTotal = (byte)'b',
    /// <summary>
    /// 主体间资金交收汇总
    /// </summary>
    [Description("主体间资金交收汇总")]
    MainbodyMoneyTotal = (byte)'c',
    /// <summary>
    /// 总分平衡监管数据
    /// </summary>
    [Description("总分平衡监管数据")]
    MainPartMonitorData = (byte)'d',
    /// <summary>
    /// 存管银行备付金余额
    /// </summary>
    [Description("存管银行备付金余额")]
    PreparationMoney = (byte)'e',
    /// <summary>
    /// 协办存管银行资金监管数据
    /// </summary>
    [Description("协办存管银行资金监管数据")]
    BankMoneyMonitorData = (byte)'f'
  }

  /// <summary>
  /// TFtdcCashExchangeCodeType是一个汇钞标志类型
  /// </summary>
  public enum CTPStockCashExchangeCodeType : byte
  {
    /// <summary>
    /// 汇
    /// </summary>
    [Description("汇")]
    Exchange = (byte)'1',
    /// <summary>
    /// 钞
    /// </summary>
    [Description("钞")]
    Cash = (byte)'2'
  }

  /// <summary>
  /// TFtdcYesNoIndicatorType是一个是或否标识类型
  /// </summary>
  public enum CTPStockYesNoIndicatorType : byte
  {
    /// <summary>
    /// 是
    /// </summary>
    [Description("是")]
    Yes = (byte)'0',
    /// <summary>
    /// 否
    /// </summary>
    [Description("否")]
    No = (byte)'1'
  }

  /// <summary>
  /// TFtdcBanlanceTypeType是一个余额类型类型
  /// </summary>
  public enum CTPStockBanlanceType : byte
  {
    /// <summary>
    /// 当前余额
    /// </summary>
    [Description("当前余额")]
    CurrentMoney = (byte)'0',
    /// <summary>
    /// 可用余额
    /// </summary>
    [Description("可用余额")]
    UsableMoney = (byte)'1',
    /// <summary>
    /// 可取余额
    /// </summary>
    [Description("可取余额")]
    FetchableMoney = (byte)'2',
    /// <summary>
    /// 冻结余额
    /// </summary>
    [Description("冻结余额")]
    FreezeMoney = (byte)'3'
  }

  /// <summary>
  /// TFtdcGenderType是一个性别类型
  /// </summary>
  public enum CTPStockGenderType : byte
  {
    /// <summary>
    /// 未知状态
    /// </summary>
    [Description("未知状态")]
    Unknown = (byte)'0',
    /// <summary>
    /// 男
    /// </summary>
    [Description("男")]
    Male = (byte)'1',
    /// <summary>
    /// 女
    /// </summary>
    [Description("女")]
    Female = (byte)'2'
  }

  /// <summary>
  /// TFtdcFeePayFlagType是一个费用支付标志类型
  /// </summary>
  public enum CTPStockFeePayFlagType : byte
  {
    /// <summary>
    /// 由受益方支付费用
    /// </summary>
    [Description("由受益方支付费用")]
    BEN = (byte)'0',
    /// <summary>
    /// 由发送方支付费用
    /// </summary>
    [Description("由发送方支付费用")]
    OUR = (byte)'1',
    /// <summary>
    /// 由发送方支付发起的费用，受益方支付接受的费用
    /// </summary>
    [Description("由发送方支付发起的费用，受益方支付接受的费用")]
    SHA = (byte)'2'
  }

  /// <summary>
  /// TFtdcPassWordKeyTypeType是一个密钥类型类型
  /// </summary>
  public enum CTPStockPassWordKeyType : byte
  {
    /// <summary>
    /// 交换密钥
    /// </summary>
    [Description("交换密钥")]
    ExchangeKey = (byte)'0',
    /// <summary>
    /// 密码密钥
    /// </summary>
    [Description("密码密钥")]
    PassWordKey = (byte)'1',
    /// <summary>
    /// MAC密钥
    /// </summary>
    [Description("MAC密钥")]
    MACKey = (byte)'2',
    /// <summary>
    /// 报文密钥
    /// </summary>
    [Description("报文密钥")]
    MessageKey = (byte)'3'
  }

  /// <summary>
  /// TFtdcFBTPassWordTypeType是一个密码类型类型
  /// </summary>
  public enum CTPStockFBTPassWordType : byte
  {
    /// <summary>
    /// 查询
    /// </summary>
    [Description("查询")]
    Query = (byte)'0',
    /// <summary>
    /// 取款
    /// </summary>
    [Description("取款")]
    Fetch = (byte)'1',
    /// <summary>
    /// 转帐
    /// </summary>
    [Description("转帐")]
    Transfer = (byte)'2',
    /// <summary>
    /// 交易
    /// </summary>
    [Description("交易")]
    Trade = (byte)'3'
  }

  /// <summary>
  /// TFtdcFBTEncryModeType是一个加密方式类型
  /// </summary>
  public enum CTPStockFBTEncryModeType : byte
  {
    /// <summary>
    /// 不加密
    /// </summary>
    [Description("不加密")]
    NoEncry = (byte)'0',
    /// <summary>
    /// DES
    /// </summary>
    [Description("DES")]
    DES = (byte)'1',
    /// <summary>
    /// 3DES
    /// </summary>
    [Description("3DES")]
    DES3 = (byte)'2'
  }

  /// <summary>
  /// TFtdcBankRepealFlagType是一个银行冲正标志类型
  /// </summary>
  public enum CTPStockBankRepealFlagType : byte
  {
    /// <summary>
    /// 银行无需自动冲正
    /// </summary>
    [Description("银行无需自动冲正")]
    BankNotNeedRepeal = (byte)'0',
    /// <summary>
    /// 银行待自动冲正
    /// </summary>
    [Description("银行待自动冲正")]
    BankWaitingRepeal = (byte)'1',
    /// <summary>
    /// 银行已自动冲正
    /// </summary>
    [Description("银行已自动冲正")]
    BankBeenRepealed = (byte)'2'
  }

  /// <summary>
  /// TFtdcBrokerRepealFlagType是一个期商冲正标志类型
  /// </summary>
  public enum CTPStockBrokerRepealFlagType : byte
  {
    /// <summary>
    /// 期商无需自动冲正
    /// </summary>
    [Description("期商无需自动冲正")]
    BrokerNotNeedRepeal = (byte)'0',
    /// <summary>
    /// 期商待自动冲正
    /// </summary>
    [Description("期商待自动冲正")]
    BrokerWaitingRepeal = (byte)'1',
    /// <summary>
    /// 期商已自动冲正
    /// </summary>
    [Description("期商已自动冲正")]
    BrokerBeenRepealed = (byte)'2'
  }

  /// <summary>
  /// TFtdcInstitutionTypeType是一个机构类别类型
  /// </summary>
  public enum CTPStockInstitutionType : byte
  {
    /// <summary>
    /// 银行
    /// </summary>
    [Description("银行")]
    Bank = (byte)'0',
    /// <summary>
    /// 期商
    /// </summary>
    [Description("期商")]
    Future = (byte)'1',
    /// <summary>
    /// 券商
    /// </summary>
    [Description("券商")]
    Store = (byte)'2'
  }

  /// <summary>
  /// TFtdcLastFragmentType是一个最后分片标志类型
  /// </summary>
  public enum CTPStockLastFragmentType : byte
  {
    /// <summary>
    /// 是最后分片
    /// </summary>
    [Description("是最后分片")]
    Yes = (byte)'0',
    /// <summary>
    /// 不是最后分片
    /// </summary>
    [Description("不是最后分片")]
    No = (byte)'1'
  }

  /// <summary>
  /// TFtdcBankAccStatusType是一个银行账户状态类型
  /// </summary>
  public enum CTPStockBankAccStatusType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = (byte)'0',
    /// <summary>
    /// 冻结
    /// </summary>
    [Description("冻结")]
    Freeze = (byte)'1',
    /// <summary>
    /// 挂失
    /// </summary>
    [Description("挂失")]
    ReportLoss = (byte)'2'
  }

  /// <summary>
  /// TFtdcMoneyAccountStatusType是一个资金账户状态类型
  /// </summary>
  public enum CTPStockMoneyAccountStatusType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = (byte)'0',
    /// <summary>
    /// 销户
    /// </summary>
    [Description("销户")]
    Cancel = (byte)'1'
  }

  /// <summary>
  /// TFtdcManageStatusType是一个存管状态类型
  /// </summary>
  public enum CTPStockManageStatusType : byte
  {
    /// <summary>
    /// 指定存管
    /// </summary>
    [Description("指定存管")]
    Point = (byte)'0',
    /// <summary>
    /// 预指定
    /// </summary>
    [Description("预指定")]
    PrePoint = (byte)'1',
    /// <summary>
    /// 撤销指定
    /// </summary>
    [Description("撤销指定")]
    CancelPoint = (byte)'2'
  }

  /// <summary>
  /// TFtdcSystemTypeType是一个应用系统类型类型
  /// </summary>
  public enum CTPStockSystemType : byte
  {
    /// <summary>
    /// 银期转帐
    /// </summary>
    [Description("银期转帐")]
    FutureBankTransfer = (byte)'0',
    /// <summary>
    /// 银证转帐
    /// </summary>
    [Description("银证转帐")]
    StockBankTransfer = (byte)'1',
    /// <summary>
    /// 第三方存管
    /// </summary>
    [Description("第三方存管")]
    TheThirdPartStore = (byte)'2'
  }

  /// <summary>
  /// TFtdcTxnEndFlagType是一个银期转帐划转结果标志类型
  /// </summary>
  public enum CTPStockTxnEndFlagType : byte
  {
    /// <summary>
    /// 正常处理中
    /// </summary>
    [Description("正常处理中")]
    NormalProcessing = (byte)'0',
    /// <summary>
    /// 成功结束
    /// </summary>
    [Description("成功结束")]
    Success = (byte)'1',
    /// <summary>
    /// 失败结束
    /// </summary>
    [Description("失败结束")]
    Failed = (byte)'2',
    /// <summary>
    /// 异常中
    /// </summary>
    [Description("异常中")]
    Abnormal = (byte)'3',
    /// <summary>
    /// 已人工异常处理
    /// </summary>
    [Description("已人工异常处理")]
    ManualProcessedForException = (byte)'4',
    /// <summary>
    /// 通讯异常 ，请人工处理
    /// </summary>
    [Description("通讯异常 ，请人工处理")]
    CommuFailedNeedManualProcess = (byte)'5',
    /// <summary>
    /// 系统出错，请人工处理
    /// </summary>
    [Description("系统出错，请人工处理")]
    SysErrorNeedManualProcess = (byte)'6'
  }

  /// <summary>
  /// TFtdcProcessStatusType是一个银期转帐服务处理状态类型
  /// </summary>
  public enum CTPStockProcessStatusType : byte
  {
    /// <summary>
    /// 未处理
    /// </summary>
    [Description("未处理")]
    NotProcess = (byte)'0',
    /// <summary>
    /// 开始处理
    /// </summary>
    [Description("开始处理")]
    StartProcess = (byte)'1',
    /// <summary>
    /// 处理完成
    /// </summary>
    [Description("处理完成")]
    Finished = (byte)'2'
  }

  /// <summary>
  /// TFtdcCustTypeType是一个客户类型类型
  /// </summary>
  public enum CTPStockCustType : byte
  {
    /// <summary>
    /// 自然人
    /// </summary>
    [Description("自然人")]
    Person = (byte)'0',
    /// <summary>
    /// 机构户
    /// </summary>
    [Description("机构户")]
    Institution = (byte)'1'
  }

  /// <summary>
  /// TFtdcFBTTransferDirectionType是一个银期转帐方向类型
  /// </summary>
  public enum CTPStockFBTTransferDirectionType : byte
  {
    /// <summary>
    /// 入金，银行转期货
    /// </summary>
    [Description("入金，银行转期货")]
    FromBankToFuture = (byte)'1',
    /// <summary>
    /// 出金，期货转银行
    /// </summary>
    [Description("出金，期货转银行")]
    FromFutureToBank = (byte)'2'
  }

  /// <summary>
  /// TFtdcOpenOrDestroyType是一个开销户类别类型
  /// </summary>
  public enum CTPStockOpenOrDestroyType : byte
  {
    /// <summary>
    /// 开户
    /// </summary>
    [Description("开户")]
    Open = (byte)'1',
    /// <summary>
    /// 销户
    /// </summary>
    [Description("销户")]
    Destroy = (byte)'0'
  }

  /// <summary>
  /// TFtdcAvailabilityFlagType是一个有效标志类型
  /// </summary>
  public enum CTPStockAvailabilityFlagType : byte
  {
    /// <summary>
    /// 未确认
    /// </summary>
    [Description("未确认")]
    Invalid = (byte)'0',
    /// <summary>
    /// 有效
    /// </summary>
    [Description("有效")]
    Valid = (byte)'1',
    /// <summary>
    /// 冲正
    /// </summary>
    [Description("冲正")]
    Repeal = (byte)'2'
  }

  /// <summary>
  /// TFtdcOrganTypeType是一个机构类型类型
  /// </summary>
  public enum CTPStockOrganType : byte
  {
    /// <summary>
    /// 银行代理
    /// </summary>
    [Description("银行代理")]
    Bank = (byte)'1',
    /// <summary>
    /// 交易前置
    /// </summary>
    [Description("交易前置")]
    Future = (byte)'2',
    /// <summary>
    /// 银期转帐平台管理
    /// </summary>
    [Description("银期转帐平台管理")]
    PlateForm = (byte)'9'
  }

  /// <summary>
  /// TFtdcOrganLevelType是一个机构级别类型
  /// </summary>
  public enum CTPStockOrganLevelType : byte
  {
    /// <summary>
    /// 银行总行或期商总部
    /// </summary>
    [Description("银行总行或期商总部")]
    HeadQuarters = (byte)'1',
    /// <summary>
    /// 银行分中心或期货公司营业部
    /// </summary>
    [Description("银行分中心或期货公司营业部")]
    Branch = (byte)'2'
  }

  /// <summary>
  /// TFtdcProtocalIDType是一个协议类型类型
  /// </summary>
  public enum CTPStockProtocalIDType : byte
  {
    /// <summary>
    /// 期商协议
    /// </summary>
    [Description("期商协议")]
    FutureProtocal = (byte)'0',
    /// <summary>
    /// 工行协议
    /// </summary>
    [Description("工行协议")]
    ICBCProtocal = (byte)'1',
    /// <summary>
    /// 农行协议
    /// </summary>
    [Description("农行协议")]
    ABCProtocal = (byte)'2',
    /// <summary>
    /// 中国银行协议
    /// </summary>
    [Description("中国银行协议")]
    CBCProtocal = (byte)'3',
    /// <summary>
    /// 建行协议
    /// </summary>
    [Description("建行协议")]
    CCBProtocal = (byte)'4',
    /// <summary>
    /// 交行协议
    /// </summary>
    [Description("交行协议")]
    BOCOMProtocal = (byte)'5',
    /// <summary>
    /// 银期转帐平台协议
    /// </summary>
    [Description("银期转帐平台协议")]
    FBTPlateFormProtocal = (byte)'X'
  }

  /// <summary>
  /// TFtdcConnectModeType是一个套接字连接方式类型
  /// </summary>
  public enum CTPStockConnectModeType : byte
  {
    /// <summary>
    /// 短连接
    /// </summary>
    [Description("短连接")]
    ShortConnect = (byte)'0',
    /// <summary>
    /// 长连接
    /// </summary>
    [Description("长连接")]
    LongConnect = (byte)'1'
  }

  /// <summary>
  /// TFtdcSyncModeType是一个套接字通信方式类型
  /// </summary>
  public enum CTPStockSyncModeType : byte
  {
    /// <summary>
    /// 异步
    /// </summary>
    [Description("异步")]
    ASync = (byte)'0',
    /// <summary>
    /// 同步
    /// </summary>
    [Description("同步")]
    Sync = (byte)'1'
  }

  /// <summary>
  /// TFtdcBankAccTypeType是一个银行帐号类型类型
  /// </summary>
  public enum CTPStockBankAccType : byte
  {
    /// <summary>
    /// 银行存折
    /// </summary>
    [Description("银行存折")]
    BankBook = (byte)'1',
    /// <summary>
    /// 储蓄卡
    /// </summary>
    [Description("储蓄卡")]
    SavingCard = (byte)'2',
    /// <summary>
    /// 信用卡
    /// </summary>
    [Description("信用卡")]
    CreditCard = (byte)'3'
  }

  /// <summary>
  /// TFtdcFutureAccTypeType是一个期货公司帐号类型类型
  /// </summary>
  public enum CTPStockFutureAccType : byte
  {
    /// <summary>
    /// 银行存折
    /// </summary>
    [Description("银行存折")]
    BankBook = (byte)'1',
    /// <summary>
    /// 储蓄卡
    /// </summary>
    [Description("储蓄卡")]
    SavingCard = (byte)'2',
    /// <summary>
    /// 信用卡
    /// </summary>
    [Description("信用卡")]
    CreditCard = (byte)'3'
  }

  /// <summary>
  /// TFtdcOrganStatusType是一个接入机构状态类型
  /// </summary>
  public enum CTPStockOrganStatusType : byte
  {
    /// <summary>
    /// 启用
    /// </summary>
    [Description("启用")]
    Ready = (byte)'0',
    /// <summary>
    /// 签到
    /// </summary>
    [Description("签到")]
    CheckIn = (byte)'1',
    /// <summary>
    /// 签退
    /// </summary>
    [Description("签退")]
    CheckOut = (byte)'2',
    /// <summary>
    /// 对帐文件到达
    /// </summary>
    [Description("对帐文件到达")]
    CheckFileArrived = (byte)'3',
    /// <summary>
    /// 对帐
    /// </summary>
    [Description("对帐")]
    CheckDetail = (byte)'4',
    /// <summary>
    /// 日终清理
    /// </summary>
    [Description("日终清理")]
    DayEndClean = (byte)'5',
    /// <summary>
    /// 注销
    /// </summary>
    [Description("注销")]
    Invalid = (byte)'9'
  }

  /// <summary>
  /// TFtdcCCBFeeModeType是一个建行收费模式类型
  /// </summary>
  public enum CTPStockCCBFeeModeType : byte
  {
    /// <summary>
    /// 按金额扣收
    /// </summary>
    [Description("按金额扣收")]
    ByAmount = (byte)'1',
    /// <summary>
    /// 按月扣收
    /// </summary>
    [Description("按月扣收")]
    ByMonth = (byte)'2'
  }

  /// <summary>
  /// TFtdcCommApiTypeType是一个通讯API类型类型
  /// </summary>
  public enum CTPStockCommApiType : byte
  {
    /// <summary>
    /// 客户端
    /// </summary>
    [Description("客户端")]
    Client = (byte)'1',
    /// <summary>
    /// 服务端
    /// </summary>
    [Description("服务端")]
    Server = (byte)'2',
    /// <summary>
    /// 交易系统的UserApi
    /// </summary>
    [Description("交易系统的UserApi")]
    UserApi = (byte)'3'
  }

  /// <summary>
  /// TFtdcLinkStatusType是一个连接状态类型
  /// </summary>
  public enum CTPStockLinkStatusType : byte
  {
    /// <summary>
    /// 已经连接
    /// </summary>
    [Description("已经连接")]
    Connected = (byte)'1',
    /// <summary>
    /// 没有连接
    /// </summary>
    [Description("没有连接")]
    Disconnected = (byte)'2'
  }

  /// <summary>
  /// TFtdcPwdFlagType是一个密码核对标志类型
  /// </summary>
  public enum CTPStockPwdFlagType : byte
  {
    /// <summary>
    /// 不核对
    /// </summary>
    [Description("不核对")]
    NoCheck = (byte)'0',
    /// <summary>
    /// 明文核对
    /// </summary>
    [Description("明文核对")]
    BlankCheck = (byte)'1',
    /// <summary>
    /// 密文核对
    /// </summary>
    [Description("密文核对")]
    EncryptCheck = (byte)'2'
  }

  /// <summary>
  /// TFtdcSecuAccTypeType是一个期货帐号类型类型
  /// </summary>
  public enum CTPStockSecuAccType : byte
  {
    /// <summary>
    /// 资金帐号
    /// </summary>
    [Description("资金帐号")]
    AccountID = (byte)'1',
    /// <summary>
    /// 资金卡号
    /// </summary>
    [Description("资金卡号")]
    CardID = (byte)'2',
    /// <summary>
    /// 上海股东帐号
    /// </summary>
    [Description("上海股东帐号")]
    SHStockholderID = (byte)'3',
    /// <summary>
    /// 深圳股东帐号
    /// </summary>
    [Description("深圳股东帐号")]
    SZStockholderID = (byte)'4'
  }

  /// <summary>
  /// TFtdcTransferStatusType是一个转账交易状态类型
  /// </summary>
  public enum CTPStockTransferStatusType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = (byte)'0',
    /// <summary>
    /// 被冲正
    /// </summary>
    [Description("被冲正")]
    Repealed = (byte)'1'
  }

  /// <summary>
  /// TFtdcSponsorTypeType是一个发起方类型
  /// </summary>
  public enum CTPStockSponsorType : byte
  {
    /// <summary>
    /// 期商
    /// </summary>
    [Description("期商")]
    Broker = (byte)'0',
    /// <summary>
    /// 银行
    /// </summary>
    [Description("银行")]
    Bank = (byte)'1'
  }

  /// <summary>
  /// TFtdcReqRspTypeType是一个请求响应类别类型
  /// </summary>
  public enum CTPStockReqRspType : byte
  {
    /// <summary>
    /// 请求
    /// </summary>
    [Description("请求")]
    Request = (byte)'0',
    /// <summary>
    /// 响应
    /// </summary>
    [Description("响应")]
    Response = (byte)'1'
  }

  /// <summary>
  /// TFtdcFBTUserEventTypeType是一个银期转帐用户事件类型类型
  /// </summary>
  public enum CTPStockFBTUserEventType : byte
  {
    /// <summary>
    /// 签到
    /// </summary>
    [Description("签到")]
    SignIn = (byte)'0',
    /// <summary>
    /// 银行转期货
    /// </summary>
    [Description("银行转期货")]
    FromBankToFuture = (byte)'1',
    /// <summary>
    /// 期货转银行
    /// </summary>
    [Description("期货转银行")]
    FromFutureToBank = (byte)'2',
    /// <summary>
    /// 开户
    /// </summary>
    [Description("开户")]
    OpenAccount = (byte)'3',
    /// <summary>
    /// 销户
    /// </summary>
    [Description("销户")]
    CancelAccount = (byte)'4',
    /// <summary>
    /// 变更银行账户
    /// </summary>
    [Description("变更银行账户")]
    ChangeAccount = (byte)'5',
    /// <summary>
    /// 冲正银行转期货
    /// </summary>
    [Description("冲正银行转期货")]
    RepealFromBankToFuture = (byte)'6',
    /// <summary>
    /// 冲正期货转银行
    /// </summary>
    [Description("冲正期货转银行")]
    RepealFromFutureToBank = (byte)'7',
    /// <summary>
    /// 查询银行账户
    /// </summary>
    [Description("查询银行账户")]
    QueryBankAccount = (byte)'8',
    /// <summary>
    /// 查询期货账户
    /// </summary>
    [Description("查询期货账户")]
    QueryFutureAccount = (byte)'9',
    /// <summary>
    /// 签退
    /// </summary>
    [Description("签退")]
    SignOut = (byte)'A',
    /// <summary>
    /// 密钥同步
    /// </summary>
    [Description("密钥同步")]
    SyncKey = (byte)'B',
    /// <summary>
    /// 其他
    /// </summary>
    [Description("其他")]
    Other = (byte)'Z'
  }

  /// <summary>
  /// TFtdcNotifyClassType是一个风险通知类型类型
  /// </summary>
  public enum CTPStockNotifyClassType : byte
  {
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    NOERROR = (byte)'0',
    /// <summary>
    /// 警示
    /// </summary>
    [Description("警示")]
    Warn = (byte)'1',
    /// <summary>
    /// 追保
    /// </summary>
    [Description("追保")]
    Call = (byte)'2',
    /// <summary>
    /// 强平
    /// </summary>
    [Description("强平")]
    Force = (byte)'3',
    /// <summary>
    /// 穿仓
    /// </summary>
    [Description("穿仓")]
    CHUANCANG = (byte)'4',
    /// <summary>
    /// 异常
    /// </summary>
    [Description("异常")]
    Exception = (byte)'5'
  }

  /// <summary>
  /// TFtdcForceCloseTypeType是一个强平单类型类型
  /// </summary>
  public enum CTPStockForceCloseType : byte
  {
    /// <summary>
    /// 手工强平
    /// </summary>
    [Description("手工强平")]
    Manual = (byte)'0',
    /// <summary>
    /// 单一投资者辅助强平
    /// </summary>
    [Description("单一投资者辅助强平")]
    Single = (byte)'1',
    /// <summary>
    /// 批量投资者辅助强平
    /// </summary>
    [Description("批量投资者辅助强平")]
    Group = (byte)'2'
  }

  /// <summary>
  /// TFtdcRiskNotifyMethodType是一个风险通知途径类型
  /// </summary>
  public enum CTPStockRiskNotifyMethodType : byte
  {
    /// <summary>
    /// 系统通知
    /// </summary>
    [Description("系统通知")]
    System = (byte)'0',
    /// <summary>
    /// 短信通知
    /// </summary>
    [Description("短信通知")]
    SMS = (byte)'1',
    /// <summary>
    /// 邮件通知
    /// </summary>
    [Description("邮件通知")]
    EMail = (byte)'2'
  }

  /// <summary>
  /// TFtdcRiskNotifyStatusType是一个风险通知状态类型
  /// </summary>
  public enum CTPStockRiskNotifyStatusType : byte
  {
    /// <summary>
    /// 未生成
    /// </summary>
    [Description("未生成")]
    NotGen = (byte)'0',
    /// <summary>
    /// 已生成未发送
    /// </summary>
    [Description("已生成未发送")]
    Generated = (byte)'1',
    /// <summary>
    /// 发送失败
    /// </summary>
    [Description("发送失败")]
    SendError = (byte)'2',
    /// <summary>
    /// 已发送未接收
    /// </summary>
    [Description("已发送未接收")]
    SendOk = (byte)'3',
    /// <summary>
    /// 已接收未确认
    /// </summary>
    [Description("已接收未确认")]
    Received = (byte)'4',
    /// <summary>
    /// 已确认
    /// </summary>
    [Description("已确认")]
    Confirmed = (byte)'5'
  }

  /// <summary>
  /// TFtdcRiskUserEventType是一个风控用户操作事件类型
  /// </summary>
  public enum CTPStockRiskUserEventType : byte
  {
    /// <summary>
    /// 导出数据
    /// </summary>
    [Description("导出数据")]
    ExportData = (byte)'0'
  }

  /// <summary>
  /// TFtdcConditionalOrderSortTypeType是一个条件单索引条件类型
  /// </summary>
  public enum CTPStockConditionalOrderSortType : byte
  {
    /// <summary>
    /// 使用最新价升序
    /// </summary>
    [Description("使用最新价升序")]
    LastPriceAsc = (byte)'0',
    /// <summary>
    /// 使用最新价降序
    /// </summary>
    [Description("使用最新价降序")]
    LastPriceDesc = (byte)'1',
    /// <summary>
    /// 使用卖价升序
    /// </summary>
    [Description("使用卖价升序")]
    AskPriceAsc = (byte)'2',
    /// <summary>
    /// 使用卖价降序
    /// </summary>
    [Description("使用卖价降序")]
    AskPriceDesc = (byte)'3',
    /// <summary>
    /// 使用买价升序
    /// </summary>
    [Description("使用买价升序")]
    BidPriceAsc = (byte)'4',
    /// <summary>
    /// 使用买价降序
    /// </summary>
    [Description("使用买价降序")]
    BidPriceDesc = (byte)'5'
  }

  /// <summary>
  /// TFtdcSendTypeType是一个报送状态类型
  /// </summary>
  public enum CTPStockSendType : byte
  {
    /// <summary>
    /// 未发送
    /// </summary>
    [Description("未发送")]
    NoSend = (byte)'0',
    /// <summary>
    /// 已发送
    /// </summary>
    [Description("已发送")]
    Sended = (byte)'1',
    /// <summary>
    /// 已生成
    /// </summary>
    [Description("已生成")]
    Generated = (byte)'2',
    /// <summary>
    /// 报送失败
    /// </summary>
    [Description("报送失败")]
    SendFail = (byte)'3',
    /// <summary>
    /// 接收成功
    /// </summary>
    [Description("接收成功")]
    Success = (byte)'4',
    /// <summary>
    /// 接收失败
    /// </summary>
    [Description("接收失败")]
    Fail = (byte)'5',
    /// <summary>
    /// 取消报送
    /// </summary>
    [Description("取消报送")]
    Cancel = (byte)'6'
  }

  /// <summary>
  /// TFtdcClientIDStatusType是一个交易编码状态类型
  /// </summary>
  public enum CTPStockClientIDStatusType : byte
  {
    /// <summary>
    /// 未申请
    /// </summary>
    [Description("未申请")]
    NoApply = (byte)'1',
    /// <summary>
    /// 已提交申请
    /// </summary>
    [Description("已提交申请")]
    Submited = (byte)'2',
    /// <summary>
    /// 已发送申请
    /// </summary>
    [Description("已发送申请")]
    Sended = (byte)'3',
    /// <summary>
    /// 完成
    /// </summary>
    [Description("完成")]
    Success = (byte)'4',
    /// <summary>
    /// 拒绝
    /// </summary>
    [Description("拒绝")]
    Refuse = (byte)'5',
    /// <summary>
    /// 已撤销编码
    /// </summary>
    [Description("已撤销编码")]
    Cancel = (byte)'6'
  }

  /// <summary>
  /// TFtdcQuestionTypeType是一个特有信息类型类型
  /// </summary>
  public enum CTPStockQuestionType : byte
  {
    /// <summary>
    /// 单选
    /// </summary>
    [Description("单选")]
    Radio = (byte)'1',
    /// <summary>
    /// 多选
    /// </summary>
    [Description("多选")]
    Option = (byte)'2',
    /// <summary>
    /// 填空
    /// </summary>
    [Description("填空")]
    Blank = (byte)'3'
  }

  /// <summary>
  /// TFtdcProcessTypeType是一个流程功能类型类型
  /// </summary>
  public enum CTPStockProcessType : byte
  {
    /// <summary>
    /// 申请交易编码
    /// </summary>
    [Description("申请交易编码")]
    ApplyTradingCode = (byte)'1',
    /// <summary>
    /// 撤销交易编码
    /// </summary>
    [Description("撤销交易编码")]
    CancelTradingCode = (byte)'2',
    /// <summary>
    /// 修改身份信息
    /// </summary>
    [Description("修改身份信息")]
    ModifyIDCard = (byte)'3',
    /// <summary>
    /// 修改一般信息
    /// </summary>
    [Description("修改一般信息")]
    ModifyNoIDCard = (byte)'4',
    /// <summary>
    /// 交易所开户报备
    /// </summary>
    [Description("交易所开户报备")]
    ExchOpenBak = (byte)'5',
    /// <summary>
    /// 交易所销户报备
    /// </summary>
    [Description("交易所销户报备")]
    ExchCancelBak = (byte)'6'
  }

  /// <summary>
  /// TFtdcBusinessTypeType是一个业务类型类型
  /// </summary>
  public enum CTPStockBusinessType : byte
  {
    /// <summary>
    /// 请求
    /// </summary>
    [Description("请求")]
    Request = (byte)'1',
    /// <summary>
    /// 应答
    /// </summary>
    [Description("应答")]
    Response = (byte)'2',
    /// <summary>
    /// 通知
    /// </summary>
    [Description("通知")]
    Notice = (byte)'3'
  }

  /// <summary>
  /// TFtdcCfmmcReturnCodeType是一个监控中心返回码类型
  /// </summary>
  public enum CTPStockCfmmcReturnCodeType : byte
  {
    /// <summary>
    /// 成功
    /// </summary>
    [Description("成功")]
    Success = (byte)'0',
    /// <summary>
    /// 该客户已经有流程在处理中
    /// </summary>
    [Description("该客户已经有流程在处理中")]
    Working = (byte)'1',
    /// <summary>
    /// 监控中客户资料检查失败
    /// </summary>
    [Description("监控中客户资料检查失败")]
    InfoFail = (byte)'2',
    /// <summary>
    /// 监控中实名制检查失败
    /// </summary>
    [Description("监控中实名制检查失败")]
    IDCardFail = (byte)'3',
    /// <summary>
    /// 其他错误
    /// </summary>
    [Description("其他错误")]
    OtherFail = (byte)'4'
  }

  /// <summary>
  /// TFtdcClientTypeType是一个客户类型类型
  /// </summary>
  public enum CTPStockClientType : byte
  {
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    All = (byte)'0',
    /// <summary>
    /// 个人
    /// </summary>
    [Description("个人")]
    Person = (byte)'1',
    /// <summary>
    /// 单位
    /// </summary>
    [Description("单位")]
    Company = (byte)'2'
  }

  /// <summary>
  /// TFtdcExchangeIDTypeType是一个交易所编号类型
  /// </summary>
  public enum CTPStockExchangeIDType : byte
  {
    /// <summary>
    /// 上海期货交易所
    /// </summary>
    [Description("上海期货交易所")]
    SHFE = (byte)'S',
    /// <summary>
    /// 郑州商品交易所
    /// </summary>
    [Description("郑州商品交易所")]
    CZCE = (byte)'Z',
    /// <summary>
    /// 大连商品交易所
    /// </summary>
    [Description("大连商品交易所")]
    DCE = (byte)'D',
    /// <summary>
    /// 中国金融期货交易所
    /// </summary>
    [Description("中国金融期货交易所")]
    CFFEX = (byte)'J'
  }

  /// <summary>
  /// TFtdcExClientIDTypeType是一个交易编码类型类型
  /// </summary>
  public enum CTPStockExClientIDType : byte
  {
    /// <summary>
    /// 套保
    /// </summary>
    [Description("套保")]
    Hedge = (byte)'1',
    /// <summary>
    /// 套利
    /// </summary>
    [Description("套利")]
    Arbitrage = (byte)'2',
    /// <summary>
    /// 投机
    /// </summary>
    [Description("投机")]
    Speculation = (byte)'3'
  }

  /// <summary>
  /// TFtdcUpdateFlagType是一个更新状态类型
  /// </summary>
  public enum CTPStockUpdateFlagType : byte
  {
    /// <summary>
    /// 未更新
    /// </summary>
    [Description("未更新")]
    NoUpdate = (byte)'0',
    /// <summary>
    /// 更新全部信息成功
    /// </summary>
    [Description("更新全部信息成功")]
    Success = (byte)'1',
    /// <summary>
    /// 更新全部信息失败
    /// </summary>
    [Description("更新全部信息失败")]
    Fail = (byte)'2',
    /// <summary>
    /// 更新交易编码成功
    /// </summary>
    [Description("更新交易编码成功")]
    TCSuccess = (byte)'3',
    /// <summary>
    /// 更新交易编码失败
    /// </summary>
    [Description("更新交易编码失败")]
    TCFail = (byte)'4',
    /// <summary>
    /// 已丢弃
    /// </summary>
    [Description("已丢弃")]
    Cancel = (byte)'5'
  }

  /// <summary>
  /// TFtdcApplyOperateIDType是一个申请动作类型
  /// </summary>
  public enum CTPStockApplyOperateIDType : byte
  {
    /// <summary>
    /// 开户
    /// </summary>
    [Description("开户")]
    OpenInvestor = (byte)'1',
    /// <summary>
    /// 修改身份信息
    /// </summary>
    [Description("修改身份信息")]
    ModifyIDCard = (byte)'2',
    /// <summary>
    /// 修改一般信息
    /// </summary>
    [Description("修改一般信息")]
    ModifyNoIDCard = (byte)'3',
    /// <summary>
    /// 申请交易编码
    /// </summary>
    [Description("申请交易编码")]
    ApplyTradingCode = (byte)'4',
    /// <summary>
    /// 撤销交易编码
    /// </summary>
    [Description("撤销交易编码")]
    CancelTradingCode = (byte)'5',
    /// <summary>
    /// 销户
    /// </summary>
    [Description("销户")]
    CancelInvestor = (byte)'6'
  }

  /// <summary>
  /// TFtdcApplyStatusIDType是一个申请状态类型
  /// </summary>
  public enum CTPStockApplyStatusIDType : byte
  {
    /// <summary>
    /// 未补全
    /// </summary>
    [Description("未补全")]
    NoComplete = (byte)'1',
    /// <summary>
    /// 已提交
    /// </summary>
    [Description("已提交")]
    Submited = (byte)'2',
    /// <summary>
    /// 已审核
    /// </summary>
    [Description("已审核")]
    Checked = (byte)'3',
    /// <summary>
    /// 已拒绝
    /// </summary>
    [Description("已拒绝")]
    Refused = (byte)'4',
    /// <summary>
    /// 已删除
    /// </summary>
    [Description("已删除")]
    Deleted = (byte)'5'
  }

  /// <summary>
  /// TFtdcSendMethodType是一个发送方式类型
  /// </summary>
  public enum CTPStockSendMethodType : byte
  {
    /// <summary>
    /// 电子发送
    /// </summary>
    [Description("电子发送")]
    ByAPI = (byte)'1',
    /// <summary>
    /// 文件发送
    /// </summary>
    [Description("文件发送")]
    ByFile = (byte)'2'
  }

  /// <summary>
  /// TFtdcEventModeType是一个操作方法类型
  /// </summary>
  public enum CTPStockEventModeType : byte
  {
    /// <summary>
    /// 增加
    /// </summary>
    [Description("增加")]
    ADD = (byte)'1',
    /// <summary>
    /// 修改
    /// </summary>
    [Description("修改")]
    UPDATE = (byte)'2',
    /// <summary>
    /// 删除
    /// </summary>
    [Description("删除")]
    DELETE = (byte)'3',
    /// <summary>
    /// 复核
    /// </summary>
    [Description("复核")]
    CHECK = (byte)'4'
  }

  /// <summary>
  /// TFtdcUOAAutoSendType是一个统一开户申请自动发送类型
  /// </summary>
  public enum CTPStockUOAAutoSendType : byte
  {
    /// <summary>
    /// 自动发送并接收
    /// </summary>
    [Description("自动发送并接收")]
    ASR = (byte)'1',
    /// <summary>
    /// 自动发送，不自动接收
    /// </summary>
    [Description("自动发送，不自动接收")]
    ASNR = (byte)'2',
    /// <summary>
    /// 不自动发送，自动接收
    /// </summary>
    [Description("不自动发送，自动接收")]
    NSAR = (byte)'3',
    /// <summary>
    /// 不自动发送，也不自动接收
    /// </summary>
    [Description("不自动发送，也不自动接收")]
    NSR = (byte)'4'
  }

  /// <summary>
  /// TFtdcFlowIDType是一个流程ID类型
  /// </summary>
  public enum CTPStockFlowIDType : byte
  {
    /// <summary>
    /// 投资者对应投资者组设置
    /// </summary>
    [Description("投资者对应投资者组设置")]
    InvestorGroupFlow = (byte)'1'
  }

  /// <summary>
  /// TFtdcCheckLevelType是一个复核级别类型
  /// </summary>
  public enum CTPStockCheckLevelType : byte
  {
    /// <summary>
    /// 零级复核
    /// </summary>
    [Description("零级复核")]
    Zero = (byte)'0',
    /// <summary>
    /// 一级复核
    /// </summary>
    [Description("一级复核")]
    One = (byte)'1',
    /// <summary>
    /// 二级复核
    /// </summary>
    [Description("二级复核")]
    Two = (byte)'2'
  }

  /// <summary>
  /// TFtdcCheckStatusType是一个复核级别类型
  /// </summary>
  public enum CTPStockCheckStatusType : byte
  {
    /// <summary>
    /// 未复核
    /// </summary>
    [Description("未复核")]
    Init = (byte)'0',
    /// <summary>
    /// 复核中
    /// </summary>
    [Description("复核中")]
    Checking = (byte)'1',
    /// <summary>
    /// 已复核
    /// </summary>
    [Description("已复核")]
    Checked = (byte)'2',
    /// <summary>
    /// 拒绝
    /// </summary>
    [Description("拒绝")]
    Refuse = (byte)'3',
    /// <summary>
    /// 作废
    /// </summary>
    [Description("作废")]
    Cancel = (byte)'4'
  }

  /// <summary>
  /// TFtdcUsedStatusType是一个生效状态类型
  /// </summary>
  public enum CTPStockUsedStatusType : byte
  {
    /// <summary>
    /// 未生效
    /// </summary>
    [Description("未生效")]
    Unused = (byte)'0',
    /// <summary>
    /// 已生效
    /// </summary>
    [Description("已生效")]
    Used = (byte)'1',
    /// <summary>
    /// 生效失败
    /// </summary>
    [Description("生效失败")]
    Fail = (byte)'2'
  }

  /// <summary>
  /// TFtdcBankAcountOriginType是一个账户来源类型
  /// </summary>
  public enum CTPStockBankAcountOriginType : byte
  {
    /// <summary>
    /// 手工录入
    /// </summary>
    [Description("手工录入")]
    ByAccProperty = (byte)'0',
    /// <summary>
    /// 银期转账
    /// </summary>
    [Description("银期转账")]
    ByFBTransfer = (byte)'1'
  }

  /// <summary>
  /// TFtdcMonthBillTradeSumType是一个结算单月报成交汇总方式类型
  /// </summary>
  public enum CTPStockMonthBillTradeSumType : byte
  {
    /// <summary>
    /// 同日同合约
    /// </summary>
    [Description("同日同合约")]
    ByInstrument = (byte)'0',
    /// <summary>
    /// 同日同合约同价格
    /// </summary>
    [Description("同日同合约同价格")]
    ByDayInsPrc = (byte)'1',
    /// <summary>
    /// 同合约
    /// </summary>
    [Description("同合约")]
    ByDayIns = (byte)'2'
  }

  /// <summary>
  /// TFtdcFBTTradeCodeEnumType是一个银期交易代码枚举类型
  /// </summary>
  public enum CTPStockFBTTradeCodeEnumType : byte
  {
    ///// <summary>
    ///// 银行发起银行转期货
    ///// </summary>
    //[Description("银行发起银行转期货")]
    //BankLaunchBankToBroker = (byte)'102001',
    ///// <summary>
    ///// 期货发起银行转期货
    ///// </summary>
    //[Description("期货发起银行转期货")]
    //BrokerLaunchBankToBroker = (byte)'202001',
    ///// <summary>
    ///// 银行发起期货转银行
    ///// </summary>
    //[Description("银行发起期货转银行")]
    //BankLaunchBrokerToBank = (byte)'102002',
    ///// <summary>
    ///// 期货发起期货转银行
    ///// </summary>
    //[Description("期货发起期货转银行")]
    //BrokerLaunchBrokerToBank = (byte)'202002'
  }

  /// <summary>
  /// TFtdcOTPTypeType是一个动态令牌类型类型
  /// </summary>
  public enum CTPStockOTPType : byte
  {
    /// <summary>
    /// 无动态令牌
    /// </summary>
    [Description("无动态令牌")]
    NONE = (byte)'0',
    /// <summary>
    /// 时间令牌
    /// </summary>
    [Description("时间令牌")]
    TOTP = (byte)'1'
  }

  /// <summary>
  /// TFtdcOTPStatusType是一个动态令牌状态类型
  /// </summary>
  public enum CTPStockOTPStatusType : byte
  {
    /// <summary>
    /// 未使用
    /// </summary>
    [Description("未使用")]
    Unused = (byte)'0',
    /// <summary>
    /// 已使用
    /// </summary>
    [Description("已使用")]
    Used = (byte)'1',
    /// <summary>
    /// 注销
    /// </summary>
    [Description("注销")]
    Disuse = (byte)'2'
  }

  /// <summary>
  /// TFtdcBrokerUserTypeType是一个经济公司用户类型类型
  /// </summary>
  public enum CTPStockBrokerUserType : byte
  {
    /// <summary>
    /// 投资者
    /// </summary>
    [Description("投资者")]
    Investor = (byte)'1'
  }

  /// <summary>
  /// TFtdcFutureTypeType是一个期货类型类型
  /// </summary>
  public enum CTPStockFutureType : byte
  {
    /// <summary>
    /// 商品期货
    /// </summary>
    [Description("商品期货")]
    Commodity = (byte)'1',
    /// <summary>
    /// 金融期货
    /// </summary>
    [Description("金融期货")]
    Financial = (byte)'2'
  }

  /// <summary>
  /// TFtdcFundEventTypeType是一个资金管理操作类型类型
  /// </summary>
  public enum CTPStockFundEventType : byte
  {
    /// <summary>
    /// 转账限额
    /// </summary>
    [Description("转账限额")]
    Restriction = (byte)'0',
    /// <summary>
    /// 当日转账限额
    /// </summary>
    [Description("当日转账限额")]
    TodayRestriction = (byte)'1',
    /// <summary>
    /// 期商流水
    /// </summary>
    [Description("期商流水")]
    Transfer = (byte)'2',
    /// <summary>
    /// 资金冻结
    /// </summary>
    [Description("资金冻结")]
    Credit = (byte)'3',
    /// <summary>
    /// 投资者可提资金比例
    /// </summary>
    [Description("投资者可提资金比例")]
    InvestorWithdrawAlm = (byte)'4'
  }

  /// <summary>
  /// TFtdcAccountSourceTypeType是一个资金账户来源类型
  /// </summary>
  public enum CTPStockAccountSourceType : byte
  {
    /// <summary>
    /// 银期同步
    /// </summary>
    [Description("银期同步")]
    FBTransfer = (byte)'0',
    /// <summary>
    /// 手工录入
    /// </summary>
    [Description("手工录入")]
    ManualEntry = (byte)'1'
  }

  /// <summary>
  /// TFtdcCodeSourceTypeType是一个交易编码来源类型
  /// </summary>
  public enum CTPStockCodeSourceType : byte
  {
    /// <summary>
    /// 统一开户
    /// </summary>
    [Description("统一开户")]
    UnifyAccount = (byte)'0',
    /// <summary>
    /// 手工录入
    /// </summary>
    [Description("手工录入")]
    ManualEntry = (byte)'1'
  }

  /// <summary>
  /// TFtdcUserRangeType是一个操作员范围类型
  /// </summary>
  public enum CTPStockUserRangeType : byte
  {
    /// <summary>
    /// 所有
    /// </summary>
    [Description("所有")]
    All = (byte)'0',
    /// <summary>
    /// 单一操作员
    /// </summary>
    [Description("单一操作员")]
    Single = (byte)'1'
  }

  /// <summary>
  /// TFtdcStockTradeTypeType是一个证券交易类型类型
  /// </summary>
  public enum CTPStockStockTradeType : byte
  {
    /// <summary>
    /// 可交易证券
    /// </summary>
    [Description("可交易证券")]
    Stock = (byte)'0',
    /// <summary>
    /// 买入网络密码服务
    /// </summary>
    [Description("买入网络密码服务")]
    BuyNetService = (byte)'1',
    /// <summary>
    /// 回购注销
    /// </summary>
    [Description("回购注销")]
    CancelRepurchase = (byte)'2',
    /// <summary>
    /// 指定撤销
    /// </summary>
    [Description("指定撤销")]
    CancelRegister = (byte)'3',
    /// <summary>
    /// 指定登记
    /// </summary>
    [Description("指定登记")]
    Register = (byte)'4',
    /// <summary>
    /// 买入发行申购
    /// </summary>
    [Description("买入发行申购")]
    PurchaseIssue = (byte)'5',
    /// <summary>
    /// 卖出配股
    /// </summary>
    [Description("卖出配股")]
    Allotment = (byte)'6',
    /// <summary>
    /// 卖出要约收购
    /// </summary>
    [Description("卖出要约收购")]
    SellTender = (byte)'7',
    /// <summary>
    /// 买入要约收购
    /// </summary>
    [Description("买入要约收购")]
    BuyTender = (byte)'8',
    /// <summary>
    /// 网上投票
    /// </summary>
    [Description("网上投票")]
    NetVote = (byte)'9',
    /// <summary>
    /// 卖出可转债回售
    /// </summary>
    [Description("卖出可转债回售")]
    SellConvertibleBonds = (byte)'a',
    /// <summary>
    /// 权证行权代码
    /// </summary>
    [Description("权证行权代码")]
    OptionExecute = (byte)'b',
    /// <summary>
    /// 开放式基金申购
    /// </summary>
    [Description("开放式基金申购")]
    PurchaseOF = (byte)'c',
    /// <summary>
    /// 开放式基金赎回
    /// </summary>
    [Description("开放式基金赎回")]
    RedeemOF = (byte)'d',
    /// <summary>
    /// 开放式基金认购
    /// </summary>
    [Description("开放式基金认购")]
    SubscribeOF = (byte)'e',
    /// <summary>
    /// 开放式基金转托管转出
    /// </summary>
    [Description("开放式基金转托管转出")]
    OFCustodianTranfer = (byte)'f',
    /// <summary>
    /// 开放式基金分红设置
    /// </summary>
    [Description("开放式基金分红设置")]
    OFDividendConfig = (byte)'g',
    /// <summary>
    /// 开放式基金转成其他基金
    /// </summary>
    [Description("开放式基金转成其他基金")]
    OFTransfer = (byte)'h',
    /// <summary>
    /// 债券入库
    /// </summary>
    [Description("债券入库")]
    BondsIn = (byte)'i',
    /// <summary>
    /// 债券出库
    /// </summary>
    [Description("债券出库")]
    BondsOut = (byte)'j',
    /// <summary>
    /// EFT申购
    /// </summary>
    [Description("EFT申购")]
    PurchaseETF = (byte)'k',
    /// <summary>
    /// EFT赎回
    /// </summary>
    [Description("EFT赎回")]
    RedeemETF = (byte)'l',
    /// <summary>
    /// 可转债回售登记
    /// </summary>
    [Description("可转债回售登记")]
    ConvertibleRegister = (byte)'m'
  }

  /// <summary>
  /// TFtdcCreationredemptionStatusType是一个基金当天申购赎回状态类型
  /// </summary>
  public enum CTPStockCreationredemptionStatusType : byte
  {
    /// <summary>
    /// 不允许申购赎回
    /// </summary>
    [Description("不允许申购赎回")]
    Forbidden = (byte)'0',
    /// <summary>
    /// 表示允许申购和赎回
    /// </summary>
    [Description("表示允许申购和赎回")]
    Allow = (byte)'1',
    /// <summary>
    /// 允许申购、不允许赎回
    /// </summary>
    [Description("允许申购、不允许赎回")]
    OnlyPurchase = (byte)'2',
    /// <summary>
    /// 不允许申购、允许赎回
    /// </summary>
    [Description("不允许申购、允许赎回")]
    OnlyRedeem = (byte)'3'
  }

  /// <summary>
  /// TFtdcETFCurrenceReplaceStatusType是一个ETF现金替代标志类型
  /// </summary>
  public enum CTPStockETFCurrenceReplaceStatusType : byte
  {
    /// <summary>
    /// 禁止现金替代
    /// </summary>
    [Description("禁止现金替代")]
    Forbidden = (byte)'0',
    /// <summary>
    /// 可以现金替代
    /// </summary>
    [Description("可以现金替代")]
    Allow = (byte)'1',
    /// <summary>
    /// 必须现金替代
    /// </summary>
    [Description("必须现金替代")]
    Force = (byte)'2'
  }


}
