using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Entities
{
    internal class Installment
    {
        private double _amount;
        public DateTime DueDate { get; set; }
        public double Amount { get => _amount; private set => _amount = value + value * 0.2; }
        public Installment(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(DueDate.ToString("dd/MM/yyyy"));
            sb.Append(" - ");
            sb.Append(Amount.ToString("F2"));
            return sb.ToString();
        }
    }
}
