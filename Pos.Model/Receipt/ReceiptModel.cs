using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Entities.Receipt
{
    public class ReceiptModel
    {
        public int ReceiptNumber { get; set; }
        public List<ReceiptSpecRecord> ReceiptSpecRecords { get; set; }

        public decimal Total { get; set; }

        public int ShiftNumber { get; set; }
        public string Cashier { get; set; }
        public int PaymentType { get; set; }
        public int AmountWithoutDiscount { get; set; }
        public int Discount { get; set; }

    }
}
