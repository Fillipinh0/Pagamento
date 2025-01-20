using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagamento.Services;

namespace Pagamento.Entities
{
    internal class Contracts
    {
        private string _number;
        private DateTime _date;
        private double _totalValue;

        public string Number { get => _number; set => _number = value.Trim(); }
        public DateTime Date { get => _date; set => _date = value; }
        public double TotalValue { get => _totalValue; set => _totalValue = value; }
        
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contracts(string number, DateTime date, double totalValaue, int installmentsNumber)
        {
            Number = number;
            Date = date;
            TotalValue = totalValaue;
            InstallmentCreation(installmentsNumber);

        }

       public void InstallmentCreation(int installmentsNumber)
        {
            double valuePerInstallment = TotalValue / installmentsNumber;
            for (int i = 1; i <= installmentsNumber; i++)
            {
                DateTime DateForMonth = Date.AddMonths(i);
                double installmentValue = valuePerInstallment + ((valuePerInstallment / 100) * i);
                Installments.Add(new Installment(DateForMonth, installmentValue));

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Installments:\n");

            foreach (Installment instalment in Installments)
            {
                sb.AppendLine(instalment.ToString());
            }
            return sb.ToString();
        }

    }
}
