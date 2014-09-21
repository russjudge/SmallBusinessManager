using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RussLibrary;
namespace SBMLibrary
{
    public class FinancialObjectCollection : ObservableCollection<FinancialObject>, ISaveableCollection
    {
        Dictionary<string, int> ReceiptDictionary = new Dictionary<string, int>();

        public FinancialObject GetFinancial(string receiptID)
        {
            if (ReceiptDictionary.ContainsKey(receiptID))
            {
                return this[ReceiptDictionary[receiptID]];
            }
            else
            {
                return null;
            }
        }
        protected override void ClearItems()
        {
            base.ClearItems();
            ReceiptDictionary.Clear();

        }
        protected override void InsertItem(int index, FinancialObject item)
        {
            base.InsertItem(index, item);
            if (item != null)
            {
                if (!ReceiptDictionary.ContainsKey(item.ReceiptID))
                {
                    ReceiptDictionary.Add(item.ReceiptID, index);
                }
            }
        }
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            base.MoveItem(oldIndex, newIndex);
            foreach (string key in ReceiptDictionary.Keys)
            {
                if (ReceiptDictionary[key] == oldIndex)
                {
                    ReceiptDictionary[key] = newIndex;
                }

                //if (ReceiptDictionary[key] == newIndex)
                //{
                //    ReceiptDictionary[key] = oldIndex;
                //}

            }
        }
        protected override void RemoveItem(int index)
        {
            ReceiptDictionary.Remove(this[index].ReceiptID);
            base.RemoveItem(index);
          
        }
        protected override void SetItem(int index, FinancialObject item)
        {
            string key = this[index].ReceiptID;

            base.SetItem(index, item);
            ReceiptDictionary.Remove(key);
            if (item != null)
            {
                ReceiptDictionary.Add(item.ReceiptID, index);
            }
        }

    }
}
