using RussLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBMLibrary
{
    public class FinancialObject
    {

        [ByteArray]
        public DateTime TransactionDateTime { get; set; }

        [ByteArray]
        public string ReceiptID { get; set; }

        [ByteArray]
        public decimal TotalSale { get; set; }

        [ByteArray]
        public decimal TotalTax { get; set; }

        [ByteArray]
        public string User { get; set; }

        [ByteArray]
        public string Station { get; set; }

        [ByteArray]
        public decimal TotalCash { get; set; }

        [ByteArray]
        public decimal TotalCredit { get; set; }

        [ByteArray]
        public decimal TotalCheck { get; set; }

        [ByteArray]
        public decimal DiscountAmount { get; set; }

        [ByteArray]
        public int ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the profit loss.  Is an estimate based on the current product cost--does not take into account cost changes.
        /// </summary>
        /// <value>
        /// The profit loss.
        /// </value>
        [ByteArray]
        public decimal ProfitLoss { get; set; }

        [ByteArray]
        public string USStateOfSale { get; set; }

        

        [ByteArray]
        public string PricingModelInEffect { get; set; }
    }
}
