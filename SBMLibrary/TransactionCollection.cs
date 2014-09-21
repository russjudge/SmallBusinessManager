using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RussLibrary;
using System.Collections.ObjectModel;
namespace SBMLibrary
{
    public class TransactionCollection : ObservableCollection<InventoryTransactionObject>, ISaveableCollection
    {
        public KeyValuePair<string,string> ExportActivityToCSV()
        {
            int skipcount = 0;
            
            StringBuilder sb = new StringBuilder();


            foreach (InventoryTransactionObject aio in this)
            {
                if (aio.Quantity != 0 && !aio.ExportedToWeb)
                {
                    if (aio.ProductID == 0)
                    {
                        List<ActiveInventoryObject> aioLIst = Cache.Current.Inventory.GetByUPCorSKU(aio.UPC);
                        if (aioLIst.Count == 0 || string.IsNullOrEmpty(aio.UPC))
                        {
                            aioLIst = Cache.Current.Inventory.GetByUPCorSKU(aio.SKU);
                        }
                        if (aioLIst.Count == 1 && aioLIst[0].ProductID != 0)
                        {
                            aio.ProductID = aioLIst[0].ProductID;
                        }
                        if (aio.ProductID == 0)
                        {
                            skipcount++;
                            continue;
                        }
                    }
                    if (aio.ProductID != 0)
                    {
                        if (aio.Quantity > 0)
                        {



                            sb.AppendLine(aio.ProductID.ToString() + ",+" + aio.Quantity.ToString());
                        }
                        else
                        {
                            sb.AppendLine(aio.ProductID.ToString() + "," + aio.Quantity.ToString());
                        }
                        aio.ExportedToWeb = true;

                    }
                }
            }


           
            Cache.Current.SaveReadyForOpenCartUpdate();
            if (skipcount == 0)
            {
                return new KeyValuePair<string, string>(string.Empty, sb.ToString());
            }
            else
            {
                return new KeyValuePair<string, string>(string.Format("{0} transactions had to be skipped because the product id is 0.\r\n\r\nFirst make sure the current export has been applied to the website, \r\n\r\nthen correct Active Inventory by setting the correct product id.\r\n\r\nFinally, re-export to pick up these skipped transactions."),
                    sb.ToString());
            }

        }
    }
}
