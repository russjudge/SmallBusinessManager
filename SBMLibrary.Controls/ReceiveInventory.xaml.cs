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
using System.Collections.ObjectModel;
using Microsoft.Win32;
namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ReceiveInventory : UserControl
    {
        public ReceiveInventory()
        {
            Activity = new ActiveInventoryCollection();
            
            InitializeComponent();
        }

        public static readonly DependencyProperty ReceiptIDProperty =
           DependencyProperty.Register("ReceiptID", typeof(string),
           typeof(ReceiveInventory));

        public string ReceiptID
        {
            get
            {
                return (string)this.UIThreadGetValue(ReceiptIDProperty);
            }
            set
            {
                this.UIThreadSetValue(ReceiptIDProperty, value);
            }
        }

        public static readonly DependencyProperty SearchKeyProperty =
             DependencyProperty.Register("SearchKey", typeof(string),
             typeof(ReceiveInventory));

        public string SearchKey
        {
            get
            {
                return (string)this.UIThreadGetValue(SearchKeyProperty);
            }
            set
            {
                this.UIThreadSetValue(SearchKeyProperty, value);
            }
        }



        public static readonly DependencyProperty QuantityProperty =
             DependencyProperty.Register("Quantity", typeof(int),
             typeof(ReceiveInventory), new PropertyMetadata(1));

        public int Quantity
        {
            get
            {
                return (int)this.UIThreadGetValue(QuantityProperty);
            }
            set
            {
                this.UIThreadSetValue(QuantityProperty, value);
            }
        }


        public static readonly DependencyProperty ActivityProperty =
             DependencyProperty.Register("Activity", typeof(ActiveInventoryCollection),
             typeof(ReceiveInventory));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ActiveInventoryCollection Activity
        {
            get
            {
                return (ActiveInventoryCollection)this.UIThreadGetValue(ActivityProperty);
            }
            set
            {
                this.UIThreadSetValue(ActivityProperty, value);
            }
        }




        private void OnDelete(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ActiveInventoryObject aio = btn.Command as ActiveInventoryObject;
                if (aio != null)
                {
                    
                    Activity.Remove(aio);
                    aio.TotalDollarChanged -= newItem_TotalDollarChanged;
                }
            }
        }
        void AddEntry()
        {
            //First, get item from Inventory.
            if (!string.IsNullOrEmpty(SearchKey))
            {
                
                foreach (ActiveInventoryObject aio in Cache.Current.Inventory.GetByUPCorSKU(SearchKey.ToUpperInvariant()))
                {
                    ActiveInventoryObject newItem = new ActiveInventoryObject();

                    newItem.CopyProperties(aio);
                    newItem.Quantity = this.Quantity;
                    newItem.Price = 0;
                    newItem.AcceptChanges();
                    newItem.TotalDollarChanged += newItem_TotalDollarChanged;
                    Activity.Add(newItem);
                }
                RefreshTotals();
                SetStartFocus();
            }
        }

        private void RefreshTotals()
        {
            
        }

        private void newItem_TotalDollarChanged(object sender, EventArgs e)
        {
            
        }
        private void OnAdd(object sender, RoutedEventArgs e)
        {
         

            AddEntry();

        }
        void SetStartFocus()
        {

            SearchKey = string.Empty;
            Quantity = 1;
            txtSearchX.SelectAll();
            txtSearchX.Focus();

            FocusManager.SetFocusedElement(txtSearchX, txtSearchX);
        }
        private void OnPost(object sender, RoutedEventArgs e)
        {
            ReceiptID = Configuration.BuildReceiptID();


            foreach (ActiveInventoryObject aio in Activity)
            {
                aio.TotalDollarChanged -= newItem_TotalDollarChanged;


            }

            foreach (ActiveInventoryObject aio in Activity)
            {
                aio.TotalDollarChanged -= newItem_TotalDollarChanged;
                List<ActiveInventoryObject> aioList = Cache.Current.Inventory.GetByUPCorSKU(aio.UPC);
                if (aioList.Count > 1)
                {
                    aioList.Clear();
                    ActiveInventoryObject newio = Cache.Current.Inventory.GetByProductID(aio.ProductID);
                    if (newio != null)
                    {
                        aioList.Add(newio);
                    }

                }
                if (aioList.Count == 1)
                {
                    aioList[0].Quantity += aio.Quantity;
                }
            }

            TransactionEngine.ReceiveInventory(Activity, ReceiptID);


            Configuration.Current.ReceiptIDNumber++;
            ReceiptID = Configuration.BuildReceiptID();
            Configuration.Current.Save();
            ResetPage();

            Activity.Clear();
            SetStartFocus();

        }
        void ResetPage()
        {

        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ReceiptID = Configuration.BuildReceiptID();
            SetStartFocus();
            
        }

        private void OnArrived(object sender, RoutedEventArgs e)
        {

        }

        private void OnSearchByOutstandingOrder(object sender, RoutedEventArgs e)
        {

        }

        private void OnSearchByUPC(object sender, RoutedEventArgs e)
        {

        }

        private void OnSearchByPurchaseOrder(object sender, RoutedEventArgs e)
        {

        }

        private void OnUPCKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAdd(sender, null);
                e.Handled = true;
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            ReceiptID = Configuration.BuildReceiptID();

            Activity.Clear();
            SetStartFocus();
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            //SetStartFocus();
        }

        private void OnStageForExport(object sender, RoutedEventArgs e)
        {

            SaveFileDialog diag = new SaveFileDialog();
            diag.Title = "Stage Received Inventory Reporting: Select report file";
            diag.DefaultExt = "pdf";
            diag.Filter = "PDF Files|*.pdf|All Files|*.*";
            if (diag.ShowDialog() == true)
            {
                TransactionEngine.StageReceiving(diag.FileName);
                System.Diagnostics.Process.Start(diag.FileName);

                Cache.Current.Save();
                
            }
            
        }
    }
}
