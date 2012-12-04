#pragma once
#include "include_CTPStock.h"

class CTPStockTraderSpi : public CZQThostFtdcTraderSpi
{
public:


  CTPStockTraderSpi(CTPResponseCallback callback)
  {
    this->callback = callback;
  }

  ///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
  virtual void OnFrontConnected()
  {
    this->OnResponse(OnFrontConnectedResponse);
  }

  ///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
  ///@param nReason 错误原因
  ///        0x1001 网络读失败
  ///        0x1002 网络写失败
  ///        0x2001 接收心跳超时
  ///        0x2002 发送心跳失败
  ///        0x2003 收到错误报文
  virtual void OnFrontDisconnected(int nReason)
  {
    this->OnResponse(OnFrontDisconnectedResponse,(void*)nReason);
  }

  ///心跳超时警告。当长时间未收到报文时，该方法被调用。
  ///@param nTimeLapse 距离上次接收报文的时间
  virtual void OnHeartBeatWarning(int nTimeLapse)
  {
    this->OnResponse(OnHeartBeatWarningResponse,(void*)nTimeLapse);
  }
  
  ///客户端认证响应
	virtual void OnRspAuthenticate(CZQThostFtdcRspAuthenticateField *pRspAuthenticateField, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
  {
    this->OnResponse(OnRspAuthenticateResponse ,pRspAuthenticateField,pRspInfo,nRequestID,bIsLast);
  }

  ///登录请求响应
  virtual void OnRspUserLogin(CZQThostFtdcRspUserLoginField *pRspUserLogin, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
  {
    this->OnResponse(OnRspUserLoginResponse,pRspUserLogin,pRspInfo,nRequestID,bIsLast);
  }

  ///登出请求响应
  virtual void OnRspUserLogout(CZQThostFtdcUserLogoutField *pUserLogout, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
  {
    this->OnResponse(OnRspUserLogoutResponse,pUserLogout,pRspInfo,nRequestID,bIsLast);
  }

  ///用户口令更新请求响应
  virtual void OnRspUserPasswordUpdate(CZQThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
  {
    this->OnResponse(OnRspUserPasswordUpdateResponse,pUserPasswordUpdate,pRspInfo,nRequestID,bIsLast);
  }

  ///报单录入请求响应			
  void OnRspOrderInsert(CZQThostFtdcInputOrderField *pInputOrder, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspOrderInsertResponse, pInputOrder, pRspInfo, nRequestID, bIsLast);
  }

  ///报单操作请求响应			
  void OnRspOrderAction(CZQThostFtdcInputOrderActionField *pInputOrderAction, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspOrderActionResponse, pInputOrderAction, pRspInfo, nRequestID, bIsLast);
  }


  ///查询最大报单数量响应			
  void OnRspQueryMaxOrderVolume(CZQThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQueryMaxOrderVolumeResponse, pQueryMaxOrderVolume, pRspInfo, nRequestID, bIsLast);
  }

  ///请求查询报单响应			
  void OnRspQryOrder(CZQThostFtdcOrderField *pOrder, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryOrderResponse, pOrder, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询成交响应			
  void OnRspQryTrade(CZQThostFtdcTradeField *pTrade, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryTradeResponse, pTrade, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询投资者持仓响应			
  void OnRspQryInvestorPosition(CZQThostFtdcInvestorPositionField *pInvestorPosition, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryInvestorPositionResponse, pInvestorPosition, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询资金账户响应			
  void OnRspQryTradingAccount(CZQThostFtdcTradingAccountField *pTradingAccount, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryTradingAccountResponse, pTradingAccount, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询投资者响应			
  void OnRspQryInvestor(CZQThostFtdcInvestorField *pInvestor, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryInvestorResponse, pInvestor, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询交易编码响应			
  void OnRspQryTradingCode(CZQThostFtdcTradingCodeField *pTradingCode, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryTradingCodeResponse, pTradingCode, pRspInfo, nRequestID, bIsLast);
  }

  ///请求查询合约手续费率响应			
  void OnRspQryInstrumentCommissionRate(CZQThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryInstrumentCommissionRateResponse, pInstrumentCommissionRate, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询交易所响应			
  void OnRspQryExchange(CZQThostFtdcExchangeField *pExchange, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryExchangeResponse, pExchange, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询合约响应			
  void OnRspQryInstrument(CZQThostFtdcInstrumentField *pInstrument, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryInstrumentResponse, pInstrument, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询行情响应			
  void OnRspQryDepthMarketData(CZQThostFtdcDepthMarketDataField *pDepthMarketData, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryDepthMarketDataResponse, pDepthMarketData, pRspInfo, nRequestID, bIsLast);
  }


  ///请求查询投资者持仓明细响应			
  void OnRspQryInvestorPositionDetail(CZQThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspQryInvestorPositionDetailResponse, pInvestorPositionDetail, pRspInfo, nRequestID, bIsLast);
  }

  ///错误应答			
  void OnRspError(CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) 			
  {
    this->OnResponse(OnRspErrorResponse, pRspInfo, nRequestID, bIsLast);
  }


  ///报单通知			
  void OnRtnOrder(CZQThostFtdcOrderField *pOrder) 			
  {
    this->OnResponse(OnRtnOrderResponse, pOrder);
  }


  ///成交通知			
  void OnRtnTrade(CZQThostFtdcTradeField *pTrade) 			
  {
    this->OnResponse(OnRtnTradeResponse, pTrade);
  }


  ///报单录入错误回报			
  void OnErrRtnOrderInsert(CZQThostFtdcInputOrderField *pInputOrder, CZQThostFtdcRspInfoField *pRspInfo) 			
  {
    this->OnResponse(OnErrRtnOrderInsertResponse, pInputOrder, pRspInfo);
  }


  ///报单操作错误回报			
  void OnErrRtnOrderAction(CZQThostFtdcOrderActionField *pOrderAction, CZQThostFtdcRspInfoField *pRspInfo) 			
  {
    this->OnResponse(OnErrRtnOrderActionResponse, pOrderAction, pRspInfo);
  }


  ///合约交易状态通知			
  void OnRtnInstrumentStatus(CZQThostFtdcInstrumentStatusField *pInstrumentStatus) 			
  {
    this->OnResponse(OnRtnInstrumentStatusResponse, pInstrumentStatus);
  }

private:


  /*    回调函数指针    */
  CTPResponseCallback callback;

  void OnResponse(CTP_STOCK_RESPONSE_TYPE type, void *pRspData, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
  {
    if(this->callback)
    {
      this->callback(type,pRspData,pRspInfo,nRequestID,bIsLast);
    }
  }

  void OnResponse(CTP_STOCK_RESPONSE_TYPE type, CZQThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
  {
    OnResponse(type,NULL,pRspInfo,nRequestID,bIsLast);
  }

  void OnResponse(CTP_STOCK_RESPONSE_TYPE type, void *pRspData, CZQThostFtdcRspInfoField *pRspInfo)
  {
    OnResponse(type,pRspData,pRspInfo,0,TRUE);
  }

  void OnResponse(CTP_STOCK_RESPONSE_TYPE type, void *pRspData)
  {
    OnResponse(type,pRspData,NULL,0,TRUE);
  }

  void OnResponse(CTP_STOCK_RESPONSE_TYPE type)
  {
    OnResponse(type,NULL,NULL,0,TRUE);
  }

};
