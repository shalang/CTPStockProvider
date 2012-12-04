using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalmBeltFund.Trading.CTPStock
{
  public abstract class CTPStockClient : CTPBaseClient<CTPStockRequestAction,CTPStockResponseType>
  {

    #region BaseEvents

    public event EventHandler<CTPEventArgs<CZQThostFtdcRspUserLoginField>> UserLoginResponse
    {
      add { AddHandler(CTPStockResponseType.UserLoginResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.UserLoginResponse, value); }
    }

    public event EventHandler<CTPEventArgs> UserLogoutResponse
    {
      add { AddHandler(CTPStockResponseType.UserLogoutResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.UserLogoutResponse, value); }
    }


    public event EventHandler<CTPEventArgs> FrontConnectedResponse
    {
      add { AddHandler(CTPStockResponseType.FrontConnectedResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.FrontConnectedResponse, value); }
    }

    public event EventHandler<CTPEventArgs> FrontDisconnectedResponse
    {
      add { AddHandler(CTPStockResponseType.FrontDisconnectedResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.FrontDisconnectedResponse, value); }
    }

    public event EventHandler<CTPEventArgs> HeartBeatWarningResponse
    {
      add { AddHandler(CTPStockResponseType.HeartBeatWarningResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.HeartBeatWarningResponse, value); }
    }

    public event EventHandler<CTPEventArgs> ErrorResponse
    {
      add { AddHandler(CTPStockResponseType.ErrorResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.ErrorResponse, value); }
    }

    #endregion

    /*
    /// <summary>
    /// 初始化接受数据类型
    /// </summary>
    protected override void InitResponseDataTypeMapping()
    {
      ///客户端认证响应
      responseDataTypeMapping.Add(CTPStockResponseType.AuthenticateResponse, typeof(CZQThostFtdcRspAuthenticateField));
      ///登录请求响应
      responseDataTypeMapping.Add(CTPStockResponseType.UserLoginResponse, typeof(CZQThostFtdcRspUserLoginField));
      ///登出请求响应
      responseDataTypeMapping.Add(CTPStockResponseType.UserLogoutResponse, typeof(CZQThostFtdcUserLogoutField));
      ///用户口令更新请求响应
      responseDataTypeMapping.Add(CTPStockResponseType.UserPasswordUpdateResponse, typeof(CZQThostFtdcUserPasswordUpdateField));
      ///报单录入请求响应
      responseDataTypeMapping.Add(CTPStockResponseType.OrderInsertResponse, typeof(CZQThostFtdcInputOrderField));
      ///报单操作请求响应
      responseDataTypeMapping.Add(CTPStockResponseType.OrderActionResponse, typeof(CZQThostFtdcInputOrderActionField));
      ///查询最大报单数量响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryMaxOrderVolumeResponse, typeof(CZQThostFtdcQueryMaxOrderVolumeField));
      ///请求查询报单响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryOrderResponse, typeof(CZQThostFtdcOrderField));
      ///请求查询成交响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryTradeResponse, typeof(CZQThostFtdcTradeField));
      ///请求查询资金账户响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryTradingAccountResponse, typeof(CZQThostFtdcTradingAccountField));
      ///请求查询投资者响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryInvestorResponse, typeof(CZQThostFtdcInvestorField));
      ///请求查询交易编码响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryTradingCodeResponse, typeof(CZQThostFtdcTradingCodeField));
      ///请求查询合约手续费率响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryInstrumentCommissionRateResponse, typeof(CZQThostFtdcInstrumentCommissionRateField));
      ///请求查询交易所响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryExchangeResponse, typeof(CZQThostFtdcExchangeField));
      ///请求查询合约响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryInstrumentResponse, typeof(CZQThostFtdcInstrumentField));
      ///请求查询行情响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryDepthMarketDataResponse, typeof(CZQThostFtdcDepthMarketDataField));
      ///请求查询投资者持仓明细响应
      responseDataTypeMapping.Add(CTPStockResponseType.QueryInvestorPositionDetailResponse, typeof(CZQThostFtdcInvestorPositionDetailField));
      ///错误应答
      responseDataTypeMapping.Add(CTPStockResponseType.ErrorResponse, typeof(CZQThostFtdcRspInfoField));
      ///报单通知
      responseDataTypeMapping.Add(CTPStockResponseType.ReturnOrderResponse, typeof(CZQThostFtdcOrderField));
      ///成交通知
      responseDataTypeMapping.Add(CTPStockResponseType.ReturnTradeResponse, typeof(CZQThostFtdcTradeField));
      ///报单录入错误回报
      responseDataTypeMapping.Add(CTPStockResponseType.ErrorReturnOrderInsertResponse, typeof(CZQThostFtdcInputOrderField));
      ///报单操作错误回报
      responseDataTypeMapping.Add(CTPStockResponseType.ErrorReturnOrderActionResponse, typeof(CZQThostFtdcOrderActionField));
      ///合约交易状态通知
      responseDataTypeMapping.Add(CTPStockResponseType.ReturnInstrumentStatusResponse, typeof(CZQThostFtdcInstrumentStatusField));
    
    }
    */

    #region CTP API Invoke

    protected override CTPResponseInfo GetResponseInfo(IntPtr pRspInfo)
    {
      CTPResponseInfo rsp = new CTPResponseInfo();

      CZQThostFtdcRspInfoField rspInfo = PInvokeUtility.GetObjectFromIntPtr<CZQThostFtdcRspInfoField>(pRspInfo);

      rsp.ErrorID = rspInfo.ErrorID;
      //rsp.Message = PInvokeUtility.GetUnicodeString(rspInfo.ErrorMsg);
      rsp.Message = rspInfo.ErrorMsg;

      return rsp;
    }

    protected override unsafe int ProcessRequest(void* hTrader, int type, void* pReqData, int requestID)
    {
      return CTPWrapper.CTPStockProcessRequest(hTrader, type, pReqData, requestID);
    }

    protected override int Process(IntPtr handle, int type, int p1, StringBuilder p2)
    {
      return CTPWrapper.CTPStockProcess(handle, type, p1, p2);
    }

    #endregion

    protected override CTPStockResponseType ConvertToResponseType(int rsp)
    {
      return (CTPStockResponseType)rsp;
    }

    protected override int ConvertActionToInt(CTPStockRequestAction action)
    {
      return (int)action;
    }

  }
}
