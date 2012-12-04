using System;
using System.Collections.Generic;

namespace CalmBeltFund.Trading.CTPStock
{
  partial class CTPStockTrader
  {
    #region Events

    /// <summary>
    /// 客户端认证响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcRspAuthenticateField>> AuthenticateResponse
    {
      add { AddHandler(CTPStockResponseType.AuthenticateResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.AuthenticateResponse, value); }
    }


    public event EventHandler<CTPEventArgs<CZQThostFtdcUserPasswordUpdateField>> UserPasswordUpdateResponse
    {
      add { AddHandler(CTPStockResponseType.UserPasswordUpdateResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.UserPasswordUpdateResponse, value); }
    }

    /// <summary>
    /// 报单录入请求响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcInputOrderField>> OrderInsertResponse
    {
      add { AddHandler(CTPStockResponseType.OrderInsertResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.OrderInsertResponse, value); }
    }


    /// <summary>
    /// 报单操作请求响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcInputOrderActionField>> OrderActionResponse
    {
      add { AddHandler(CTPStockResponseType.OrderActionResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.OrderActionResponse, value); }
    }

    /// <summary>
    /// 查询最大报单数量响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcQueryMaxOrderVolumeField>> QueryMaxOrderVolumeResponse
    {
      add { AddHandler(CTPStockResponseType.QueryMaxOrderVolumeResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryMaxOrderVolumeResponse, value); }
    }


    /// <summary>
    /// 请求查询报单响应
    /// </summary>
    public event EventHandler<CTPEventArgs<List<CZQThostFtdcOrderField>>> QueryOrderResponse
    {
      add { AddHandler(CTPStockResponseType.QueryOrderResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryOrderResponse, value); }
    }

    /// <summary>
    /// 请求查询成交响应
    /// </summary>
    public event EventHandler<CTPEventArgs<List<CZQThostFtdcTradeField>>> QueryTradeResponse
    {
      add { AddHandler(CTPStockResponseType.QueryTradeResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryTradeResponse, value); }
    }

    /// <summary>
    /// 请求查询投资者持仓响应
    /// </summary>
    public event EventHandler<CTPEventArgs<List<CZQThostFtdcInvestorPositionField>>> QueryInvestorPositionResponse
    {
      add { AddHandler(CTPStockResponseType.QueryInvestorPositionResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryInvestorPositionResponse, value); }
    }

    /// <summary>
    /// 请求查询资金账户响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcTradingAccountField>> QueryTradingAccountResponse
    {
      add { AddHandler(CTPStockResponseType.QueryTradingAccountResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryTradingAccountResponse, value); }
    }

    /// <summary>
    /// 请求查询投资者响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcInvestorField>> QueryInvestorResponse
    {
      add { AddHandler(CTPStockResponseType.QueryInvestorResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryInvestorResponse, value); }
    }

    /// <summary>
    /// 请求查询交易编码响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcTradingCodeField>> QueryTradingCodeResponse
    {
      add { AddHandler(CTPStockResponseType.QueryTradingCodeResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryTradingCodeResponse, value); }
    }


    /// <summary>
    /// 请求查询合约手续费率响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcInstrumentCommissionRateField>> QueryInstrumentCommissionRateResponse
    {
      add { AddHandler(CTPStockResponseType.QueryInstrumentCommissionRateResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryInstrumentCommissionRateResponse, value); }
    }

    /// <summary>
    /// 请求查询交易所响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcExchangeField>> QueryExchangeResponse
    {
      add { AddHandler(CTPStockResponseType.QueryExchangeResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryExchangeResponse, value); }
    }

    /// <summary>
    /// 请求查询合约响应
    /// </summary>
    public event EventHandler<CTPEventArgs<List<CZQThostFtdcInstrumentField>>> QueryInstrumentResponse
    {
      add { AddHandler(CTPStockResponseType.QueryInstrumentResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryInstrumentResponse, value); }
    }

    /// <summary>
    /// 请求查询行情响应
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcDepthMarketDataField>> QueryDepthMarketDataResponse
    {
      add { AddHandler(CTPStockResponseType.QueryDepthMarketDataResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryDepthMarketDataResponse, value); }
    }

    /// <summary>
    /// 请求查询投资者持仓明细响应
    /// </summary>
    public event EventHandler<CTPEventArgs<List<CZQThostFtdcInvestorPositionDetailField>>> QueryInvestorPositionDetailResponse
    {
      add { AddHandler(CTPStockResponseType.QueryInvestorPositionDetailResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.QueryInvestorPositionDetailResponse, value); }
    }


    /// <summary>
    /// 报单通知
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcOrderField>> ReturnOrderResponse
    {
      add { AddHandler(CTPStockResponseType.ReturnOrderResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.ReturnOrderResponse, value); }
    }

    /// <summary>
    /// 成交通知
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcTradeField>> ReturnTradeResponse
    {
      add { AddHandler(CTPStockResponseType.ReturnTradeResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.ReturnTradeResponse, value); }
    }

    /// <summary>
    /// 报单录入错误回报
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcInputOrderField>> ErrorReturnOrderInsertResponse
    {
      add { AddHandler(CTPStockResponseType.ErrorReturnOrderInsertResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.ErrorReturnOrderInsertResponse, value); }
    }

    /// <summary>
    /// 报单操作错误回报
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcOrderActionField>> ErrorReturnOrderActionResponse
    {
      add { AddHandler(CTPStockResponseType.ErrorReturnOrderActionResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.ErrorReturnOrderActionResponse, value); }
    }

    /// <summary>
    /// 合约交易状态通知
    /// </summary>
    public event EventHandler<CTPEventArgs<CZQThostFtdcInstrumentStatusField>> ReturnInstrumentStatusResponse
    {
      add { AddHandler(CTPStockResponseType.ReturnInstrumentStatusResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.ReturnInstrumentStatusResponse, value); }
    }

    #endregion
	}
}
