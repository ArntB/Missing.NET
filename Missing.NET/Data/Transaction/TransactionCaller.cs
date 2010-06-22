using System;
using System.Transactions;

namespace Missing.Data.Transaction
{
    public class TransactionCaller
    {
        public static void Call(Action action)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.Timeout = new TimeSpan(0,10, 0);
            transactionOptions.IsolationLevel = IsolationLevel.Serializable;

            using (
                var ts = new TransactionScope(
                    TransactionScopeOption.Required, transactionOptions, EnterpriseServicesInteropOption.Full))
            {
                action();
                ts.Complete();
            }
        }
    }
}