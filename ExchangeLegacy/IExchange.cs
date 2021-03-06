﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Almirex.Contracts.Messages;

namespace ExchangeLegacy
{
    [ServiceContract]
//    [XmlSerializerFormat]

    public interface IExchange
    {
        [OperationContract]
        List<ExecutionReport> GetOrders();
        [OperationContract]
        ExecutionReport GetOrder(string id);
        [OperationContract]
        List<ExecutionReport> NewOrder(ExecutionReport order);

        [OperationContract]
        ExecutionReport CancelOrder(string id);
    }
}
