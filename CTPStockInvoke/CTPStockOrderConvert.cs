using System;
using System.Collections;
using System.Collections.Generic;

namespace CalmBeltFund.Trading.CTPStock
{

  internal class CTPStockOrderConvert
  {

    public const int OrderRefLength = 12;

    public static string GetUserKey(object field)
    {

      //委托单
      if (field is CZQThostFtdcInputOrderField)
      {
        CZQThostFtdcInputOrderField ctpOrder = (CZQThostFtdcInputOrderField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //撤单
      if (field is CZQThostFtdcOrderActionField)
      {
        CZQThostFtdcOrderActionField ctpOrder = (CZQThostFtdcOrderActionField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //预埋单
      if (field is CZQThostFtdcParkedOrderField)
      {
        CZQThostFtdcParkedOrderField ctpOrder = (CZQThostFtdcParkedOrderField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //删除预埋单
      if (field is CZQThostFtdcRemoveParkedOrderField)
      {
        CZQThostFtdcRemoveParkedOrderField ctpOrder = (CZQThostFtdcRemoveParkedOrderField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //预埋撤单
      if (field is CZQThostFtdcParkedOrderActionField)
      {
        CZQThostFtdcRemoveParkedOrderField ctpOrder = (CZQThostFtdcRemoveParkedOrderField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //删除预埋撤单
      if (field is CZQThostFtdcRemoveParkedOrderActionField)
      {
        CZQThostFtdcRemoveParkedOrderActionField ctpOrder = (CZQThostFtdcRemoveParkedOrderActionField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //订单
      if (field is CZQThostFtdcOrderField)
      {
        CZQThostFtdcOrderField ctpOrder = (CZQThostFtdcOrderField)field;
        return GetUserKey(ctpOrder.InvestorID, ctpOrder.BrokerID);
      }

      //成交单
      if (field is CZQThostFtdcTradeField)
      {
        CZQThostFtdcTradeField ctpData = (CZQThostFtdcTradeField)field;
        return GetUserKey(ctpData.InvestorID, ctpData.BrokerID);
      }

      //持仓
      if (field is CZQThostFtdcInvestorPositionField)
      {
        CZQThostFtdcInvestorPositionField ctpData = (CZQThostFtdcInvestorPositionField)field;
        return GetUserKey(ctpData.InvestorID, ctpData.BrokerID);
      }

      //持仓明细
      if (field is CZQThostFtdcInvestorPositionDetailField)
      {
        CZQThostFtdcInvestorPositionDetailField ctpData = (CZQThostFtdcInvestorPositionDetailField)field;
        return GetUserKey(ctpData.InvestorID, ctpData.BrokerID);
      }

      //持仓明细
      if (field is CZQThostFtdcInvestorPositionCombineDetailField)
      {
        CZQThostFtdcInvestorPositionCombineDetailField ctpData = (CZQThostFtdcInvestorPositionCombineDetailField)field;
        return GetUserKey(ctpData.InvestorID, ctpData.BrokerID);
      }

      //资金账户
      if (field is CZQThostFtdcTradingAccountField)
      {
        CZQThostFtdcTradingAccountField ctpData = (CZQThostFtdcTradingAccountField)field;
        return GetUserKey(ctpData.AccountID, ctpData.BrokerID);
      }

      throw new Exception("unknow type : " + field.GetType().FullName);
    }

    public static string GetUserKey(string investorID, string brokerID)
    {
      return string.Format("{0}@{1}@{2}",investorID, brokerID, "CTPStock");
    }

    public static string GetOrderUniqueKey(CTPStockTrader trader, object field)
    {
      //委托单
      if (field is CZQThostFtdcInputOrderField)
      {
        CZQThostFtdcInputOrderField ctpOrder = (CZQThostFtdcInputOrderField)field;
        return string.Format("{0:X}_{1:X}_{2}", trader.FrontID, trader.SessionID, ctpOrder.OrderRef.Trim());
      }
      //撤单
      if (field is CZQThostFtdcOrderActionField)
      {
        CZQThostFtdcOrderActionField ctpOrder = (CZQThostFtdcOrderActionField)field;
        return string.Format("{0:X}_{1:X}_{2}", ctpOrder.FrontID, ctpOrder.SessionID, ctpOrder.OrderRef.Trim());
      }

      throw new Exception("Unknow type : " + field.GetType().ToString());
    }

    public static string GetOrderUniqueKey(object field)
    {
      //委托单
      //if (field is CZQThostFtdcInputOrderField)
      //{
      //  CZQThostFtdcInputOrderField ctpOrder = (CZQThostFtdcInputOrderField)field;
      //  return string.Format("{0}_{1}_{2}_{3}", ctpOrder.BrokerID, ctpOrder.InvestorID, ctpOrder.InstrumentID, ctpOrder.OrderRef);
      //}

      //撤单
      if (field is CZQThostFtdcOrderActionField)
      {
        CZQThostFtdcOrderActionField ctpOrder = (CZQThostFtdcOrderActionField)field;
        return string.Format("{0:X}_{1:X}_{2}", ctpOrder.FrontID, ctpOrder.SessionID, ctpOrder.OrderRef.Trim());
      }

      //订单
      if (field is CZQThostFtdcOrderField)
      {
        CZQThostFtdcOrderField ctpOrder = (CZQThostFtdcOrderField)field;
        return string.Format("{0:X}_{1:X}_{2}", ctpOrder.FrontID, ctpOrder.SessionID, ctpOrder.OrderRef.Trim());
      }

      //预埋单
      if (field is CZQThostFtdcParkedOrderField)
      {
        CZQThostFtdcParkedOrderField ctpOrder = (CZQThostFtdcParkedOrderField)field;
        return string.Format("{0}_{1}_{2}", ctpOrder.BrokerID, ctpOrder.InvestorID, ctpOrder.ParkedOrderID);
      }

      //删除预埋单
      if (field is CZQThostFtdcRemoveParkedOrderField)
      {
        CZQThostFtdcRemoveParkedOrderField ctpOrder = (CZQThostFtdcRemoveParkedOrderField)field;
        return string.Format("{0}_{1}_{2}", ctpOrder.BrokerID, ctpOrder.InvestorID, ctpOrder.ParkedOrderID);
      }


      //成交单
      if (field is CZQThostFtdcTradeField)
      {
        CZQThostFtdcTradeField ctpData = (CZQThostFtdcTradeField)field;
        return string.Format("{0}_{1}_{2}_{3}", ctpData.BrokerID, ctpData.InvestorID, ctpData.TradingDay, ctpData.TradeID);
      }

      //持仓
      if (field is CZQThostFtdcInvestorPositionField)
      {
        CZQThostFtdcInvestorPositionField ctpData = (CZQThostFtdcInvestorPositionField)field;
        return string.Format("{0}_{1}_{2}_{3}_{4}", ctpData.BrokerID, ctpData.InvestorID, ctpData.TradingDay, ctpData.InstrumentID, ctpData.PosiDirection);
      }

      //持仓明细
      if (field is CZQThostFtdcInvestorPositionDetailField)
      {
        //注意！！成交单ID可能重复
        CZQThostFtdcInvestorPositionDetailField ctpData = (CZQThostFtdcInvestorPositionDetailField)field;
        return string.Format("{0}_{1}_{2}_{3}", ctpData.BrokerID, ctpData.InvestorID, ctpData.TradingDay, ctpData.TradeID);
      }

      throw new Exception("Unknow type : " + field.GetType().ToString());
    }

    /// <summary>
    /// 返回交易模块编号
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    public static string GetModelID(object field)
    {
      //委托单
      if (field is CZQThostFtdcInputOrderField)
      {
        CZQThostFtdcInputOrderField ctpOrder = (CZQThostFtdcInputOrderField)field;
        return GetModelIDByOrderRef(ctpOrder.OrderRef);
      }

      //撤单
      if (field is CZQThostFtdcOrderActionField)
      {
        CZQThostFtdcOrderActionField ctpOrder = (CZQThostFtdcOrderActionField)field;
        return GetModelIDByOrderRef(ctpOrder.OrderRef);
      }

      //订单
      if (field is CZQThostFtdcOrderField)
      {
        CZQThostFtdcOrderField ctpOrder = (CZQThostFtdcOrderField)field;
        return GetModelIDByOrderRef(ctpOrder.OrderRef);
      }

      //成交单
      if (field is CZQThostFtdcTradeField)
      {
        CZQThostFtdcTradeField ctpOrder = (CZQThostFtdcTradeField)field;
        return GetModelIDByOrderRef(ctpOrder.OrderRef);
      }

      throw new Exception("unknow field:" + field.ToString(), null);
    }



    



    static string GetModelIDByOrderRef(string orderRef)
    {

      if (orderRef.Length > 6)
      {
        return orderRef.Substring(orderRef.Length - 4, 2);
      }
      else
      {
        return "";
      }
    }

    public static void AppendOrReplaceOrder(IList list,object ctpOrder)
    {

      for (int i = 0; i < list.Count; i++)
      {
        object order = list[i];

        if (GetOrderUniqueKey(order) == GetOrderUniqueKey(ctpOrder))
        {
          list[i] = ctpOrder;
          return;
        }
      }

      list.Add(ctpOrder);

    }

    static int GetScale(decimal priceTick)
    {
      int scale = 0;

      string s = priceTick.ToString();

      int dotPosition = s.IndexOf('.');
      if (dotPosition < 0)
      {
        scale = 0;
      }
      else
      {
        scale = s.Length - dotPosition - 1;

        if (scale < 0)
        {
          scale = 0;
        }
      }

      return scale;
    }


  }

}
