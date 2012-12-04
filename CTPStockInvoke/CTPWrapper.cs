using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection;
using System.IO;

namespace CalmBeltFund.Trading.CTPStock
{

  internal delegate int CTPProcessFunction(IntPtr handle, int type, int p1, StringBuilder p2);
  internal unsafe delegate int CTPProcessRequestFunction(void* hTrader, int type, void* pReqData, int requestID);

  internal class CTPWrapper
  {

    static IntPtr pData = IntPtr.Zero;
    static IntPtr hLib = IntPtr.Zero;

    internal static CTPProcessFunction ProcessFunction{get;private set;}
    internal static CTPProcessRequestFunction ProcessRequestFunction { get; private set; }


    [DllImport("CTPStockWrapper.dll")]
    internal unsafe static extern int CTPStockProcessRequest(void* hTrader, int type, void* pReqData, int requestID);

    [DllImport("CTPStockWrapper.dll")]
    internal static extern int CTPStockProcess(IntPtr handle, int type, int p1, StringBuilder p2);

    /// <summary>
    /// 订阅股票行情
    /// </summary>
    /// <param name="hMarketData"></param>
    [DllImport("CTPStockWrapper.dll")]
    internal static extern void StockSubscribe(IntPtr hMarketDatachar, IntPtr[] ppInstrumentID, int nCount, string pExchageID);

    /// <summary>
    /// 退订股票行情
    /// </summary>
    /// <param name="hMarketData"></param>
    [DllImport("CTPStockWrapper.dll")]
    internal static extern void StockUnSubscribe(IntPtr hMarketData, IntPtr[] ppInstrumentID, int nCount, string pExchageID);

  }

}
