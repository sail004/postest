﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Entities.Receipt
{
    public class ReceiptSpecRecord
    {
        public int NumPos { get; set; }
        public int GoodId  { get; set; }
        public int Amount { get; set; }

        public string GoodName { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}