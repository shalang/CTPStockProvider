using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace CalmBeltFund.Trading.CTPStock
{
  public class CTPStockMarketData : CTPStockClient
  {

    #region Event

    public event EventHandler<CTPEventArgs<CZQThostFtdcDepthMarketDataField>> DepthMarketDataResponse
    {
      add { AddHandler(CTPStockResponseType.DepthMarketDataResponse, value); }
      remove { RemoveHandler(CTPStockResponseType.DepthMarketDataResponse, value); }
    }

    #endregion


    public void Connect(string[] frontAddress, string brokerID, string userID, string password)
    {
      this.BrokerID = brokerID;
      this.InvestorID = userID;
      this.Password = password;

      connTempFile = Path.GetTempFileName();

      //创建
      _instance = (IntPtr)Process(Marshal.GetFunctionPointerForDelegate(this.callback), (int)CTPStockRequestAction.MarketDataCreate, 0, new StringBuilder(connTempFile));

      foreach (string front in frontAddress)
      {
        string address = front;

        if (address.StartsWith("tcp://", StringComparison.OrdinalIgnoreCase) == false)
        {
          address = "tcp://" + address;
        }

        Process(this._instance, (int)CTPStockRequestAction.MarketDataRegisterFront, 0, new StringBuilder(address));

        this.FrontAddress = address;
      }

      Process(this._instance, (int)CTPStockRequestAction.MarketDataInit, 0, null);
    }

    void UserLogin()
    {
      CZQThostFtdcReqUserLoginField userLogin = new CZQThostFtdcReqUserLoginField();

      userLogin.BrokerID = this.BrokerID;
      userLogin.UserID = this.InvestorID;
      userLogin.Password = this.Password;

      int result = InvokeAPI(CTPStockRequestAction.MarketDataUserLoginAction, userLogin);

    }


    /// <summary>
    /// 订阅行情
    /// </summary>
    /// <param name="symbols"></param>
    public void SubscribeMarketData(string exchangeID, string[] symbols)
    {

      IntPtr[] handlers = new IntPtr[symbols.Length];

      for (int i = 0; i < symbols.Length; i++)
      {
        handlers[i] = Marshal.StringToHGlobalAnsi(symbols[i]);
      }

      CTPWrapper.StockSubscribe(this._instance, handlers, symbols.Length, exchangeID);

      //StringBuilder buffer = new StringBuilder();

      //foreach (var item in symbols)
      //{
      //  buffer.Append(item).Append('\0');
      //}

      //CTPWrapper.Process(this._instance, (int)CTPRequestAction.MarketDataSubscribeMarketData, symbols.Length, buffer);

    }

    /// <summary>
    /// 退订行情
    /// </summary>
    /// <param name="symbols"></param>
    public void UnSubscribeMarketData(string exchangeID, string[] symbols)
    {

      if (symbols == null || symbols.Length == 0)
      {
        return;
      }

      IntPtr[] handlers = new IntPtr[symbols.Length];

      for (int i = 0; i < symbols.Length; i++)
      {
        handlers[i] = Marshal.StringToHGlobalAnsi(symbols[i]);
      }

      CTPWrapper.StockUnSubscribe(this._instance, handlers, symbols.Length, exchangeID);
    }


    protected override void ProcessBusinessResponse(CTPStockResponseType responseType, IntPtr pData, CTPResponseInfo rspInfo, int requestID)
    {
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

        #region 用户登录
        case CTPStockResponseType.UserLoginResponse:
          {
            CTPEventArgs<CZQThostFtdcRspUserLoginField> args = CreateEventArgs<CZQThostFtdcRspUserLoginField>(requestID, rspInfo);

            this.isLogin = true;

            this.OnEventHandler(CTPStockResponseType.UserLoginResponse, args);
          }
          break;
        #endregion


        case CTPStockResponseType.DepthMarketDataResponse:
          {
            if (this == null || this.isDispose == true)
            {
              return;
            }

            CTPEventArgs<CZQThostFtdcDepthMarketDataField> args = CreateEventArgs<CZQThostFtdcDepthMarketDataField>(pData, rspInfo);

            OnEventHandler(CTPStockResponseType.DepthMarketDataResponse, args);

            break;
          }

        case CTPStockResponseType.ErrorResponse:
          {
            CTPEventArgs args = new CTPEventArgs(rspInfo);

            OnEventHandler(CTPStockResponseType.ErrorResponse, args);
            break;
          }
      }
    }

    #region IDisposable 成员

    public override void Dispose()
    {
      isDispose = true;

      if (this._instance != IntPtr.Zero)
      {
        Process(this._instance, (int)CTPStockRequestAction.MarketDataRelease, 0, null);

        this._instance = IntPtr.Zero;
      }

      base.Dispose();
    }

    #endregion


    #region Response

    /// <summary>
    /// 订阅行情应答
    /// </summary>
    internal void OnSubMarketData(IntPtr pSpecificInstrument, IntPtr pRspInfo, int nRequestID, bool bIsLast)
    {
      CZQThostFtdcSpecificInstrumentField instrument = PInvokeUtility.GetObjectFromIntPtr<CZQThostFtdcSpecificInstrumentField>(pSpecificInstrument);
      Trace.WriteLine("【订阅行情】" + instrument.InstrumentID);
    }

    /// <summary>
    /// 取消订阅行情应答
    /// </summary>
    internal void OnUnSubMarketData(IntPtr pSpecificInstrument, IntPtr pRspInfo, int nRequestID, bool bIsLast)
    {

    }

    #endregion





  }
}

