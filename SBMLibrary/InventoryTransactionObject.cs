using RussLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBMLibrary
{
    public class InventoryTransactionObject
    {
        [ByteArray]
        public int ProductID { get; set; }
        [ByteArray]
        public string UPC { get; set; }
        [ByteArray]
        public string SKU { get; set; }

        [ByteArray]
        public DateTime TransactionTime { get; set; }


        [ByteArray]
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is sale.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is sale; otherwise, if inventory received, <c>false</c>.
        /// </value>
        [ByteArray]
        public bool IsSale { get; set; }



        
        [ByteArray]
        public decimal DiscountRateLevel{get;set;}
        

        [ByteArray]
        public decimal Discount{get;set;}



        [ByteArray]
        public string ReceiptID { get; set; }


        [ByteArray]
        public int Quantity{get;set;}





        /// <summary>
        /// Gets or sets the price each.  
        /// </summary>
        /// <value>
        /// The price each.
        /// </value>
        ///
        [ByteArray]
        public decimal SellingPriceEach{ get; set;}

        [ByteArray]
        public decimal CostEach { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is matched to its pair.  Inventory received is the source--POS sale is the pair.
        /// Close day is where the matching should occur.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this transaction has been matched to its pair, then true otherwise, <c>false</c>.
        /// </value>
        [ByteArray]
        public bool PairMatched { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [exported to web].  Will be true if imported from web.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [exported to web]; otherwise, <c>false</c>.
        /// </value>
        [ByteArray]
        public bool ExportedToWeb { get; set; }
    }
}
