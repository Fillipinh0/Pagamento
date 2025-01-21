using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pagamento.Entities;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pagamento.Services
{
    internal class ContractService
    {
        public Contracts Contract { get; set; }
        public ContractService(Contracts contract)
        {
            Contract = contract;
            ProcessContract();
        }
        public void ProcessContract()
        {

            for (int months = 1; months <= Contract.InstallmentsNumber; months++)
            {
                IOnlinePayMentService onlinePayMentService = new PaypalService();

                DateTime DateForMonth = Contract.Date.AddMonths(months);

                double valuePerMonth = Contract.TotalValue / Contract.InstallmentsNumber;
                double installmentValue = valuePerMonth + onlinePayMentService.PaymentFee(valuePerMonth);
                installmentValue += onlinePayMentService.Interest(installmentValue, months);

                Contract.Installments.Add(new Installment(DateForMonth, installmentValue));
                

            }
        }
    }
}
