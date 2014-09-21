using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RussLibrary;
using SharpCompress.Writer;
using SharpCompress.Common;
using System.IO;
namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for ImportControl.xaml
    /// </summary>
    public partial class ImportControl : UserControl
    {
        public ImportControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty OverwriteDataProperty =
            DependencyProperty.Register("OverwriteData", typeof(bool),
            typeof(ImportControl), new PropertyMetadata(OnOverwriteData));

        public bool OverwriteData
        {
            get
            {
                return (bool)this.UIThreadGetValue(OverwriteDataProperty);
            }
            set
            {
                this.UIThreadSetValue(OverwriteDataProperty, value);
            }
        }

        public static readonly DependencyProperty UpdateQuantityProperty =
            DependencyProperty.Register("UpdateQuantity", typeof(bool),
            typeof(ImportControl), new PropertyMetadata(OnUpdateQuantity));

        public bool UpdateQuantity
        {
            get
            {
                return (bool)this.UIThreadGetValue(UpdateQuantityProperty);
            }
            set
            {
                this.UIThreadSetValue(UpdateQuantityProperty, value);
            }
        }
        static void OnOverwriteData(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ImportControl me = sender as ImportControl;
            if (me != null)
            {
                if (me.OverwriteData)
                {
                    me.UpdateQuantity = false;
                    me.UpdateNothing = false;
                }
            }
        }
        static void OnUpdateQuantity(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ImportControl me = sender as ImportControl;
            if (me != null)
            {
                if (me.UpdateQuantity)
                {
                    me.UpdateNothing = false;
                    me.OverwriteData = false;
                }
            }
        }
        static void OnUpdateNothing(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ImportControl me = sender as ImportControl;
            if (me != null)
            {
                if (me.UpdateNothing)
                {
                    me.UpdateQuantity = false;
                    me.OverwriteData = false;
                }
            }
        }
        public static readonly DependencyProperty UpdateNothingProperty =
          DependencyProperty.Register("UpdateNothing", typeof(bool),
          typeof(ImportControl), new PropertyMetadata(true, OnUpdateNothing));

        public bool UpdateNothing
        {
            get
            {
                return (bool)this.UIThreadGetValue(UpdateNothingProperty);
            }
            set
            {
                this.UIThreadSetValue(UpdateNothingProperty, value);
            }
        }
        private void OnImportFromOriginal(object sender, RoutedEventArgs e)
        {
            MergeFromFile(OverwriteData, UpdateQuantity);
        }
        void MergeFromOpenCart(bool overlayExistingData, bool updateQuantityOnly)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Title = "Import from Website CSV";
            diag.DefaultExt = "csv";
            if (diag.ShowDialog() == true)
            {
                Import(ActiveInventoryCollection.ImportFromWebsiteOpenCart(diag.FileName), true, overlayExistingData, updateQuantityOnly);
                MessageBox.Show("Import complete.");
            }
        }
        void MergeFromWebsiteFile(bool OverlayExistingData, bool updateQuantityOnly)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Title = "Import from Website CSV";
            diag.DefaultExt = "csv";
            if (diag.ShowDialog() == true)
            {
                Import(ActiveInventoryCollection.ImportFromWebsiteBase(diag.FileName), true, OverlayExistingData, updateQuantityOnly);
                MessageBox.Show("Import complete.");
            }
        }
        void MergeFromFile(bool OverlayExistingData, bool updateQuantityOnly)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Title = "Import from CSV (original spreadsheet)";
            diag.DefaultExt = "csv";
            if (diag.ShowDialog() == true)
            {
                Import(ActiveInventoryCollection.ImportFromSpreadsheet(diag.FileName), false, OverlayExistingData, updateQuantityOnly);
                MessageBox.Show("Import complete.");
            }
        }

        void Import(ActiveInventoryCollection newInventory, bool MatchFirstbyProductID, bool OverlayExistingData, bool updateQuantityOnly)
        {
            if (newInventory != null)
            {
                foreach (ActiveInventoryObject aio in newInventory)
                {
                    bool matched = false;
                    if (MatchFirstbyProductID && aio.ProductID > 0)
                    {

                        ActiveInventoryObject oAio = Cache.Current.Inventory.GetByProductID(aio.ProductID);
                        if (oAio != null)
                        {
                            matched = true;
                            if (updateQuantityOnly)
                            {
                                oAio.Quantity = aio.Quantity;
                            }
                            else
                            {
                                oAio.CopyProperties(aio, OverlayExistingData);
                            }
                        }


                    }
                    if (!matched)
                    {
                        if (!string.IsNullOrEmpty(aio.UPC))
                        {
                            List<ActiveInventoryObject> oAioList = Cache.Current.Inventory.GetByUPCorSKU(aio.UPC);
                            if (oAioList.Count == 1)
                            {

                                matched = true;
                                if (updateQuantityOnly)
                                {
                                    oAioList[0].Quantity = aio.Quantity;
                                }
                                else
                                {
                                    oAioList[0].CopyProperties(aio, OverlayExistingData);
                                }
                            }
                        }
                    }
                    if (!matched)
                    {
                        if (!string.IsNullOrEmpty(aio.SKU))
                        {
                            List<ActiveInventoryObject> oAioList = Cache.Current.Inventory.GetByUPCorSKU(aio.SKU);
                            if (oAioList.Count == 1)
                            {

                                matched = true;
                                if (updateQuantityOnly)
                                {
                                    oAioList[0].Quantity = aio.Quantity;
                                }
                                else
                                {
                                    oAioList[0].CopyProperties(aio, OverlayExistingData);
                                }
                            }
                        }
                    }
                    if (!matched)
                    {
                        Cache.Current.Inventory.Add(aio);
                    }
                }
                Cache.Current.SaveInventory();
            }
        }

        private void OnExportChanges(object sender, RoutedEventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Title = "Activity Export";
            diag.DefaultExt = "csv";
            diag.Filter = "CSV files|*.csv";
            diag.AddExtension = true;
            diag.OverwritePrompt = true;
            
            if (diag.ShowDialog() == true)
            {

                KeyValuePair<string,string> result = Cache.Current.InventoryActivity.ExportActivityToCSV();
                if (!string.IsNullOrEmpty(result.Value))
                {
                    using (StreamWriter sw = new StreamWriter(diag.FileName))
                    {
                        sw.Write(result.Value);
                    }
                }
                if (!string.IsNullOrEmpty(result.Key))
                {
                    MessageBox.Show(result.Key, "Export", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Export complete", "Export");
                }
            }
            Cache.Current.SaveReadyForOpenCartUpdate();
            MessageBox.Show("Export complete.");
        }

        private void OnClear(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("This will remove all inventory.\r\n\r\nARE YOU SURE?", "Clear Inventory", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                if (MessageBox.Show("ARE YOU REALLY SURE?\r\n\r\nThis can mess things up if you aren't sure.", "Clear Inventory", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    Cache.Current.Inventory.Clear();
                }
            }
        }

        private void OnImportFromWeb(object sender, RoutedEventArgs e)
        {
            MergeFromWebsiteFile(OverwriteData, UpdateQuantity);
        }

        private void OnImportFromOpenCartWeb(object sender, RoutedEventArgs e)
        {
            MergeFromOpenCart(OverwriteData, UpdateQuantity);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void OnExportConfig(object sender, RoutedEventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Title = "Enter zip file";
            diag.Filter = "Zip files|*.zip";
            diag.DefaultExt="zip";
            if (diag.ShowDialog() == true)
            {


                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(Configuration.GetDataPath());
                System.IO.FileInfo[] filesList = dirInfo.GetFiles();
                
                using (var zipWriter = WriterFactory.Open(System.IO.File.OpenWrite(diag.FileName), ArchiveType.Zip, CompressionType.Deflate))
                {
                    foreach (var filePath in filesList)
                    {
                        if (filePath.Name.ToUpperInvariant().EndsWith(".LOG") || filePath.Name.ToUpperInvariant().EndsWith(".PMO") || filePath.Name.ToUpperInvariant() == "CONFIG.DAT" ||filePath.Name.ToUpperInvariant().EndsWith(".aio"))
                        {
                            try
                            {
                                zipWriter.Write(filePath.Name, filePath);
                            }
                            catch { }
                        }
                    }
                }

                MessageBox.Show("Configuration Export complete.");
            }
        }

        private void OnWebsiteExportChanges(object sender, RoutedEventArgs e)
        {
            OpenCartConnector connect = OpenCartConnector.UploadQuantityChanges();
            if (connect.LastProcessSuccess)
            {
                MessageBox.Show("Upload Successful.", "OpenCart Quantity Update",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Upload failed.\r\n\r\nError Message:\r\n\r\n" + connect.ErrorMessage,
                    "OpenCart Quantity Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
