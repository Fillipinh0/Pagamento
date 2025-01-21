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
        private int _installmentsNumber;

        public string Number { get => _number; set => _number = value.Trim(); }
        public DateTime Date { get => _date; set => _date = value; }
        public double TotalValue { get => _totalValue; set => _totalValue = value; }
        public int InstallmentsNumber { get => _installmentsNumber; set => _installmentsNumber = value; }

        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contracts(string number, DateTime date, double totalValaue, int installmentsNumber)
        {
            Number = number;
            Date = date;
            TotalValue = totalValaue;
            InstallmentsNumber = installmentsNumber;
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
