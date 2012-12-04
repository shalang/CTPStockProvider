
#include "..\header\stdafx.h"
#include "..\header\ThostFtdcMdApiSSE.h"


//订阅股票行情
extern "C" CTPWRAPPER_API int StockSubscribe(void *instance, char *ppInstrumentID[], int nCount, char* pExchageID)
{
  return ((CZQThostFtdcMdApi*)instance)->SubscribeMarketData(ppInstrumentID, nCount, pExchageID);
};

//退阅股票行情
extern "C" CTPWRAPPER_API int StockUnSubscribe(void *instance, char *ppInstrumentID[], int nCount, char* pExchageID)
{
  return ((CZQThostFtdcMdApi*)instance)->UnSubscribeMarketData(ppInstrumentID, nCount, pExchageID);
};
