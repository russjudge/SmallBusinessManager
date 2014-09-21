using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RussLibrary;
using System.Windows;
using System.ComponentModel;
using log4net;
using System.Web;
using System.IO;
namespace SBMLibrary
{
    public class ActiveInventoryCollection : ObservableCollection<ActiveInventoryObject>, INotifyPropertyChanged, ISaveableCollection
    {

        static readonly ILog _log = LogManager.GetLogger(typeof(ActiveInventoryCollection));
        protected override event PropertyChangedEventHandler PropertyChanged;
        decimal _totalInvested = 0;
        public decimal TotalInvested
        {
            get
            {

                return _totalInvested;
            }
            set
            {
                _totalInvested = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalInvested"));
                }
            }
            
        }
        //public static readonly DependencyProperty ProductIDProperty =
        //    DependencyProperty.Register("ProductID", typeof(int),
        //    typeof(ActiveInventoryCollection));
        
        //public decimal TotalInvested
        //{
        //    get
        //    {
        //        return (decimal)this.UIThreadGetValue(ProductIDProperty);
        //    }
        //    set
        //    {
        //        this.UIThreadSetValue(ProductIDProperty, value);
        //    }
        //}
      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static ActiveInventoryCollection ImportFromWebsiteOpenCart(string file)
        {
             ActiveInventoryCollection retVal = new ActiveInventoryCollection();
             try
             {
                 StringBuilder sb = new StringBuilder();
                 using (StreamReader sr = new StreamReader(file))
                 {
                     string sLine = null;
                     do
                     {
                         sLine = sr.ReadLine();
                         if (!string.IsNullOrEmpty(sLine))
                         {
                            sb.AppendLine(HttpUtility.UrlDecode(sLine));
                         }
                     } while (sLine != null);
                 }
                 using (LumenWorks.Framework.IO.Csv.CsvReader reader
                      = new LumenWorks.Framework.IO.Csv.CsvReader(new StringReader(sb.ToString()),true))
                 {
                     while (reader.ReadNextRecord())
                     {
                         ActiveInventoryObject aio = new ActiveInventoryObject();
                         int i = 0;
                         decimal d = 0M;
                         if (int.TryParse(reader["product_id"], out i))
                         {
                             aio.ProductID = i;

                         }
                         try
                         {
                             if (decimal.TryParse(reader["price"], out d))
                             {
                                 aio.SellingPrice = d;
                             }
                         }
                         catch { }
                        
                             aio.UPC = reader["upc"];
                             aio.SKU = reader["sku"];
                             aio.Name = reader["prodname"];
                             aio.Manufacturer = reader["mname"];
                             aio.Distributor = reader["dname"];
                             aio.Category = reader["catname"];
                             if (reader["modelkit"] == "1")
                             {
                                 //aio.DiscountRateLevel = 0.05M;
                                 aio.IsModelKit = true;
                             }
                             else
                             {
                                 aio.IsModelKit = false;
                             }

                             if (!int.TryParse(reader["stock"], out i))
                             {
                                 aio.Quantity = 0;
                             }
                             else
                             {
                                 aio.Quantity = i;
                             }

                             d = 0;
                             //if (decimal.TryParse(reader["pricesell"], out d))
                             //{
                             //    aio.WholeSalePrice = d;
                             //}
                            
                                 if (retVal.GetByProductID(aio.ProductID) == null)
                                 {
                                     retVal.Add(aio);
                                 }
                           
                         
                     }

                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error on Import:\r\n\r\n" + ex.Message);
                 retVal = null;
                 if (_log.IsWarnEnabled)
                 {
                     _log.Warn("Error importing: ", ex);
                 }
             }
            return retVal;
        }
      
        /// <summary>
        /// Imports from website.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static ActiveInventoryCollection ImportFromWebsiteBase(string file)
        {
            ActiveInventoryCollection retVal = new ActiveInventoryCollection();
            decimal d = 0;
            try
            {
                
                    using (LumenWorks.Framework.IO.Csv.CsvReader reader
                        = new LumenWorks.Framework.IO.Csv.CsvReader(new System.IO.StreamReader(file, Encoding.GetEncoding(1252)), true))
                    {
                        reader.SupportsMultiline = true;
                        //reader.ReadNextRecord();  //Header Record?

                        while (reader.ReadNextRecord())
                        {
                            ActiveInventoryObject aio = new ActiveInventoryObject();
                            string data = reader.GetCurrentRawData();

                            aio.UPC = reader["upc"];


                            int i = 0;
                            if (int.TryParse(reader["product_id"], out i))
                            {
                                aio.ProductID = i;
                            }

                            aio.Name = reader["name"];


                            aio.SKU = reader["sku"];
                            //aio.Model = reader["model"];

                            aio.PictureURL = reader["image_name"];

                            aio.Description = reader["description"];

                            //aio.Category = reader["Category"];


                            if (!int.TryParse(reader["quantity"], out i))
                            {
                                aio.Quantity = 0;
                            }
                            else
                            {
                                aio.Quantity = i;
                            }
                            try
                            {
                                if (decimal.TryParse(reader["price"], out d))
                                {
                                    aio.SellingPrice = d;
                                }
                            }
                            catch { }

                            aio.Metadata = reader["meta_description"];
                            aio.Keywords = reader["meta_keywords"];


                            retVal.Add(aio);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Import:\r\n\r\n" + ex.Message);
                retVal = null;
                if (_log.IsWarnEnabled)
                {
                    _log.Warn("Error importing: ", ex);
                }
            }
            return retVal;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static ActiveInventoryCollection ImportFromSpreadsheet(string file)
        {
            ActiveInventoryCollection retVal = new ActiveInventoryCollection();
            try
            {

              
                using (LumenWorks.Framework.IO.Csv.CsvReader reader = new LumenWorks.Framework.IO.Csv.CsvReader(new System.IO.StreamReader(file, Encoding.GetEncoding(1252)), true))
                {
                    reader.SupportsMultiline = false;
                    //reader.ReadNextRecord();  //Header Record?
                    //string x = reader["UPC"];
                    while (reader.ReadNextRecord())
                    {
                        if (!string.IsNullOrEmpty(reader["SKU"]) && !reader["UPC"].Contains("~~"))
                        {
                            ActiveInventoryObject aio = new ActiveInventoryObject();
                            string data = reader.GetCurrentRawData();

                            aio.UPC = reader["UPC"];
                            int i = 0;
                            if (int.TryParse(reader["Product ID"], out i))
                            {
                                aio.ProductID = i;
                            }
                            aio.Distributor = reader["Distributor"];
                            aio.SKU = reader["SKU"];
                            aio.Name = reader["Description"];

                            //aio.Category = reader["Category"];
                            try
                            {
                                if (reader["Is Model Kit"].ToUpperInvariant() == "YES")
                                {
                                    //aio.DiscountRateLevel = 0.05M;
                                    aio.IsModelKit = true;
                                }
                                else
                                {
                                    aio.IsModelKit = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (_log.IsWarnEnabled)
                                {
                                    _log.Warn("Error importing: ", ex);
                                }
                            }
                            
                            try
                            {
                                //Quantity of zero might be valid--this could change that.
                                if (!int.TryParse(reader["Quantity"], out i))
                                {
                                    aio.Quantity = 0;
                                }
                                else
                                {
                                    aio.Quantity = i;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (_log.IsWarnEnabled)
                                {
                                    _log.Warn("Error importing: ", ex);
                                }

                            }
                            decimal d = 0;
                            try
                            {
                                if (decimal.TryParse(reader["Wholesale"].Replace("$", string.Empty), out d))
                                {
                                    aio.WholeSalePrice = d;
                                }
                                else
                                {
                                    aio.WholeSalePrice = 0;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (_log.IsWarnEnabled)
                                {
                                    _log.Warn("Error importing: ", ex);
                                }
                            }
                            try
                            {
                                if (decimal.TryParse(reader["MSRP"].Replace("$", string.Empty), out d))
                                {
                                    aio.MSRP = d;
                                }
                                else
                                {
                                    aio.MSRP = 0;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (_log.IsWarnEnabled)
                                {
                                    _log.Warn("Error importing: ", ex);
                                }
                            }
                            //try
                            //{
                            //    if (decimal.TryParse(reader["Add'l Overhead"].Replace("$", string.Empty), out d))
                            //    {
                            //        aio.AdditionalOverhead = d;
                            //    }
                            //    else
                            //    {
                            //        aio.AdditionalOverhead = 0;
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    if (_log.IsWarnEnabled)
                            //    {
                            //        _log.Warn("Error importing: ", ex);
                            //    }
                            //}
                            try
                            {
                                if (decimal.TryParse(reader["Price"].Replace("$", string.Empty), out d))
                                {
                                    aio.SellingPrice = d;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (_log.IsWarnEnabled)
                                {
                                    _log.Warn("Error importing: ", ex);
                                }
                            }
                            retVal.Add(aio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Import:\r\n\r\n" + ex.Message);
                retVal = null;
                if (_log.IsWarnEnabled)
                {
                    _log.Warn("Error importing: ", ex);
                }
            }
            return retVal;
        }
       
        //public void Save(string file)
        //{
        //    List<byte> FullData = new List<byte>();
        //    foreach (ActiveInventoryObject obj in this)
        //    {
        //        List<byte> data = new List<byte>();
        //        data.AddRange(obj.GetByteArray());
        //        FullData.AddRange(BitConverter.GetBytes(data.Count));
        //        FullData.AddRange(data);
        //    }

        //    using (System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write))
        //    {
        //        fs.Write(FullData.ToArray(), 0, FullData.Count);
        //    }
        //}
        //public void Load(string file)
        //{
        //    List<byte> FullData = new List<byte>();
        //    if (System.IO.File.Exists(file))
        //    {
        //        using (System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
        //        {
        //            byte[] buffer = new byte[32768];
        //            int byteRead = 0;
        //            do
        //            {
        //                byteRead = fs.Read(buffer, 0, buffer.Length);
        //                if (byteRead > 0)
        //                {
        //                    for (int i = 0; i < byteRead; i++)
        //                    {
        //                        FullData.Add(buffer[i]);
        //                    }
        //                }
        //            } while (byteRead > 0);

        //        }
        //        int pos = 0;
        //        byte[] data = FullData.ToArray();
        //        while (pos < data.Length)
        //        {
        //            int objectLength = BitConverter.ToInt32(data, pos);
        //            pos += 4;

        //            List<byte> work = new List<byte>();
        //            for (int i = pos; i < objectLength + pos; i++)
        //            {
        //                work.Add(data[i]);
        //            }

        //            ActiveInventoryObject aio = new ActiveInventoryObject();

        //            aio.LoadProperties(work.ToArray());
        //            this.Add(aio);
        //            pos += objectLength;
        //        }
        //    }
        //}


        protected override void ClearItems()
        {
            foreach (ActiveInventoryObject item in Items)
            {
                item.UnSubscribeToChangeEvents(item_UPCChanged, item_SKUChanged);
            }
            base.ClearItems();
            UPCDictionary.Clear();
            SKUDictionary.Clear();
            ProductIDDictionary.Clear();
            TotalInvested = 0;
        }
        protected override void RemoveItem(int index)
        {
            ActiveInventoryObject item = this[index];
            UPCDictionary.Remove(item.UPC.ToUpperInvariant());
            SKUDictionary.Remove(item.SKU.ToUpperInvariant());
            ProductIDDictionary.Remove(item.ProductID);
            item.UnSubscribeToChangeEvents(item_UPCChanged, item_SKUChanged);
            base.RemoveItem(index);
            TotalInvested -= (item.WholeSalePrice + item.AdditionalOverhead) * item.Quantity;
        }

        void item_SKUChanged(object sender, ItemChangedEventArgs e)
        {
            string key = e.OldValue as string;
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUpperInvariant();
                int index = SKUDictionary[key];
                SKUDictionary.Remove(key);
                key = e.NewValue as string;
                AddSKUItem(key, index);
            }
        }
        void item_UPCChanged(object sender, ItemChangedEventArgs e)
        {
            string key = e.OldValue as string;
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUpperInvariant();
                int index = UPCDictionary[key];
                UPCDictionary.Remove(key);
                key = e.NewValue as string;
                AddUPCItem(key, index);
            }
        }

        void AddSKUItem(string key, int index)
        {
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUpperInvariant();
                if (!SKUDictionary.ContainsKey(key))
                {
                    SKUDictionary.Add(key, index);
                }
            }
        }
        void AddUPCItem(string key, int index)
        {
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUpperInvariant();
                if (!UPCDictionary.ContainsKey(key))
                {
                    UPCDictionary.Add(key, index);
                }
            }
        }
        void AddProductIDItem(int key, int index)
        {
            if (key > 0 && !ProductIDDictionary.ContainsKey(key))
            {
                ProductIDDictionary.Add(key, index);
            }
        }
        protected override void InsertItem(int index, ActiveInventoryObject item)
        {
            base.InsertItem(index, item);
            if (item != null)
            {
                AddUPCItem(item.UPC, index);
                AddSKUItem(item.SKU, index);
                AddProductIDItem(item.ProductID, index);
                TotalInvested += (item.WholeSalePrice + item.AdditionalOverhead) * item.Quantity;
                item.SubscribeToChangeEvents(item_UPCChanged, item_SKUChanged);
            }
        }
        protected override void SetItem(int index, ActiveInventoryObject item)
        {
            Items[index].UnSubscribeToChangeEvents(item_UPCChanged, item_SKUChanged);
            TotalInvested -= (Items[index].WholeSalePrice + Items[index].AdditionalOverhead) * Items[index].Quantity;


            //TODO: change dictionaries.
            base.SetItem(index, item);
            if (item != null)
            {
                item.SubscribeToChangeEvents(item_UPCChanged, item_SKUChanged);
                TotalInvested += (item.WholeSalePrice + item.AdditionalOverhead) * item.Quantity;
            }
        }
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            foreach (string key in UPCDictionary.Keys)
            {
                if (UPCDictionary[key] == oldIndex)
                {
                    UPCDictionary[key] = newIndex;
                }
            }

            foreach (string key in SKUDictionary.Keys)
            {
                if (SKUDictionary[key] == oldIndex)
                {
                    SKUDictionary[key] = newIndex;
                }
            }
            foreach (int key in ProductIDDictionary.Keys)
            {
                if (ProductIDDictionary[key] == oldIndex)
                {
                    ProductIDDictionary[key] = newIndex;
                }
            }
            base.MoveItem(oldIndex, newIndex);
        }
        public List<ActiveInventoryObject> GetByUPCorSKU(string key)
        {
            List<ActiveInventoryObject> retVal = new List<ActiveInventoryObject>();
            if (key != null)
            {
                key = key.ToUpperInvariant();
                if (UPCDictionary.ContainsKey(key))
                {
                    retVal.Add(Items[UPCDictionary[key]]);
                }
                if (SKUDictionary.ContainsKey(key))
                {
                    retVal.Add(Items[SKUDictionary[key]]);
                }
            }
            return retVal;
        }
        public ActiveInventoryObject GetByProductID(int ID)
        {
            if (ProductIDDictionary.ContainsKey(ID))
            {
                return Items[ProductIDDictionary[ID]];
            }
            else
            {
                return null;
            }
        }
        Dictionary<int, int> ProductIDDictionary = new Dictionary<int, int>();
        Dictionary<string, int> UPCDictionary = new Dictionary<string, int>();
        Dictionary<string, int> SKUDictionary = new Dictionary<string, int>();
    }
}
