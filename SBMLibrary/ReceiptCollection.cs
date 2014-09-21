using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SBMLibrary
{
    public class ReceiptCollection : Collection<ReceiptEntry>
    {
        public readonly static string ReceiptStoreDirectory = System.IO.Path.Combine(Configuration.GetDataPath(), "ReceiptStore");
        protected override void ClearItems()
        {
            base.ClearItems();
        }
        protected override void InsertItem(int index, ReceiptEntry item)
        {
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, ReceiptEntry item)
        {
            base.SetItem(index, item);
        }
        Dictionary<string, List<int>> UPCToItems = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> SKUToItems = new Dictionary<string, List<int>>();
        Dictionary<DateTime, List<int>> TransactionDateToItems = new Dictionary<DateTime, List<int>>();
    }
}
