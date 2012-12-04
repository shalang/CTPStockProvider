using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CalmBeltFund.Trading.CTPStock
{
  /// <summary>
  /// CTP回调函数指针
  /// </summary>
  /// <param name="type"></param>
  /// <param name="pData"></param>
  /// <param name="pRspInfo"></param>
  /// <param name="requestID"></param>
  /// <param name="isLast"></param>
  public delegate void CTPResponseCallback(int type, IntPtr pData, IntPtr pRspInfo, int requestID, [MarshalAs(UnmanagedType.U1)]bool isLast);


  internal delegate void OutputCallback(string msg);


  public class CTPResponseInfo
  {
    public int ErrorID { get; set; }
    public string Message { get; set; }

    //internal CTPResponseInfo(IntPtr pRspInfo)
    //{

    //  CThostFtdcRspInfoField rspInfo = PInvokeUtility.GetObjectFromIntPtr<CThostFtdcRspInfoField>(pRspInfo);

    //  this.ErrorID = rspInfo.ErrorID;
    //  this.Message = PInvokeUtility.GetUnicodeString(rspInfo.ErrorMsg);

    //}

    internal CTPResponseInfo()
    {
      this.ErrorID = 0;
      this.Message = "";
    }

    public static CTPResponseInfo Empty
    {
      get
      {
        CTPResponseInfo info = new CTPResponseInfo();
        return info;
      }
    }
  }

  public class CTPEventArgs : EventArgs
  {
    public CTPResponseInfo ResponseInfo { get; internal set; }
    public int RequestID { get; internal set; }

    public CTPEventArgs(CTPResponseInfo rspInfo, int requestID)
    {
      this.ResponseInfo = rspInfo;
      this.RequestID = requestID;
    }

    public CTPEventArgs(CTPResponseInfo rspInfo)
      : this(rspInfo, 0)
    { }

    public CTPEventArgs()
      : this(CTPResponseInfo.Empty, 0)
    { }
  }

  public class CTPEventArgs<T> : CTPEventArgs
  {
    T value;

    public object RequestData { get; internal set; }

    public T Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    public CTPEventArgs(T value)
      : base()
    {
      this.value = value;
    }

    internal CTPEventArgs(T value, CTPResponseInfo rspInfo)
      : this(value, rspInfo, 0)
    {

    }

    internal CTPEventArgs(T value, CTPResponseInfo rspInfo, int requestID)
      : base(rspInfo, requestID)
    {
      this.value = value;
    }
  }

  /// <summary>
  /// 返回的数据类型
  /// </summary>
  public class CTPResponseDataTypeAttribute : Attribute
  {
    public Type Type { get; set; }

    public CTPResponseDataTypeAttribute(Type value)
    {
      this.Type = value;
    }
  }



  public class CTPTaskBase<T>
  {
    T action;
    int requestID;
    object parameter;

    public T Action
    {
      get { return action; }
      set { action = value; }
    }

    public object Parameter
    {
      get { return parameter; }
      set { parameter = value; }
    }

    public int RequestID
    {
      get { return requestID; }
      set { requestID = value; }
    }
  }
}
