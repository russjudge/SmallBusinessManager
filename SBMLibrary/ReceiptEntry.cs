using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBMLibrary
{
    public class ReceiptEntry
    {
        public string ReceiptID { get; set; }
        public string UPC { get; set; }
        public string SKU { get; set; }

        public DateTime TransactionDateTime { get; set; }

    }
}
