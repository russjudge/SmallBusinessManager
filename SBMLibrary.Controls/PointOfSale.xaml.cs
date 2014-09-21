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
namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for PointOfSale.xaml
    /// </summary>
    public partial class PointOfSale : UserControl
    {
        public PointOfSale()
        {
            Activity = new ObservableCollection<ActiveInventoryObject>();
            PricingModels = PricingModelObject.Models;
            
            SelectedPricingModel = PricingModelObject.GetPricingModel(Configuration.Current.CurrentPricingModel);

            

            ReceiptID = Configuration.BuildReceiptID();
            foreach (FinancialObject fo in Cache.Current.CurrentFinancials)
            {
                TotalCashSales += fo.TotalCash;
                TotalCreditSales += fo.TotalCredit;
                TotalCheckSales += fo.TotalCheck;
                TotalProfit += fo.ProfitLoss;
                TotalTaxesAssesed += fo.TotalTax;

            }
            USState = Configuration.Current.LastUSState;


            InitializeComponent();
        }

        
        public static readonly DependencyProperty SearchKeyProperty =
             DependencyProperty.Register("SearchKey", typeof(string),
             typeof(PointOfSale));

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
             typeof(PointOfSale), new PropertyMetadata(1));

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



        static void OnSelectedPricingModelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PointOfSale me = sender as PointOfSale;
            if (me != null)
            {
                if (me.SelectedPricingModel != null && !string.IsNullOrEmpty(me.SelectedPricingModel.Name))
                {
                    Configuration.Current.CurrentPricingModel = me.SelectedPricingModel.Name;
                }
                else
                {
                    Configuration.Current.CurrentPricingModel = string.Empty;
                }
                Configuration.Current.Save();
                me.RefreshTotals();
            }
        }

        public static readonly DependencyProperty SelectedPricingModelProperty =
             DependencyProperty.Register("SelectedPricingModel", typeof(PricingModelObject),
             typeof(PointOfSale), new PropertyMetadata(OnSelectedPricingModelChanged));

        public PricingModelObject SelectedPricingModel
        {
            get
            {
                return (PricingModelObject)this.UIThreadGetValue(SelectedPricingModelProperty);
            }
            set
            {
                this.UIThreadSetValue(SelectedPricingModelProperty, value);
            }
        }




        public static readonly DependencyProperty PricingModelsProperty =
             DependencyProperty.Register("PricingModels", typeof(ObservableCollection<PricingModelObject>),
             typeof(PointOfSale));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ObservableCollection<PricingModelObject> PricingModels
        {
            get
            {
                return (ObservableCollection<PricingModelObject>)this.UIThreadGetValue(PricingModelsProperty);
            }
            set
            {
                this.UIThreadSetValue(PricingModelsProperty, value);
            }
        }


        static void OnDiscountAmountChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PointOfSale me = sender as PointOfSale;
            if (me != null)
            {
                me.RefreshTotals();
            }
        }
        public static readonly DependencyProperty DiscountAmountProperty =
             DependencyProperty.Register("DiscountAmount", typeof(decimal),
             typeof(PointOfSale));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public decimal DiscountAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(DiscountAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(DiscountAmountProperty, value);
            }
        }





        public static readonly DependencyProperty ActivityProperty =
             DependencyProperty.Register("Activity", typeof(ObservableCollection<ActiveInventoryObject>),
             typeof(PointOfSale));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ObservableCollection<ActiveInventoryObject> Activity
        {
            get
            {
                return (ObservableCollection<ActiveInventoryObject>)this.UIThreadGetValue(ActivityProperty);
            }
            set
            {
                this.UIThreadSetValue(ActivityProperty, value);
            }
        }

        public static readonly DependencyProperty LogoProperty =
            DependencyProperty.Register("Logo", typeof(BitmapImage),
            typeof(PointOfSale));

        public BitmapImage Logo
        {
            get
            {
                return (BitmapImage)this.UIThreadGetValue(LogoProperty);
            }
            set
            {
                this.UIThreadSetValue(LogoProperty, value);
            }
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ReceiptID = Configuration.BuildReceiptID();
            SetStartFocus();
        }
        void SetStartFocus()
        {

            SearchKey = string.Empty;
            Quantity = 1;
            txtSearch.SelectAll();
            txtSearch.Focus();
            FocusManager.SetFocusedElement(txtSearch, txtSearch);
        }
        void AddEntry()
        {
            //First, get item from Inventory.
            if (!string.IsNullOrEmpty(SearchKey))
            {
                foreach (ActiveInventoryObject aio in Cache.Current.Inventory.GetByUPCorSKU(SearchKey))
                {
                    ActiveInventoryObject newItem = new ActiveInventoryObject();

                    newItem.CopyProperties(aio);
                    newItem.Quantity = this.Quantity;
                    newItem.Price = newItem.GetPriceEach(SelectedPricingModel);
                    newItem.AcceptChanges();
                    newItem.TotalDollarChanged += newItem_TotalDollarChanged;
                    Activity.Add(newItem);
                }
                RefreshTotals();
                SetStartFocus();
            }
        }
        private void OnAdd(object sender, RoutedEventArgs e)
        {
            AddEntry();
        }
        void RefreshTotals()
        {

            Total = -DiscountAmount;
            TotalTax = 0;
            TotalTaxTotal = 0;
            if (SelectedPricingModel != null)
            {
                foreach (ActiveInventoryObject aio in Activity)
                {
                    decimal amount = aio.GetTotalPrice(SelectedPricingModel);

                    
                    decimal price = aio.GetPriceEach(SelectedPricingModel);


                    aio.Price = price;
                    aio.TotalAmount = amount;


                    Total += amount;
                    if (SelectedPricingModel.IncludesSalesTax)
                    {
                        TotalTax += (amount - (amount / (1 + Configuration.Current.CurrentSalesTax)));
                    }
                }
                if (SelectedPricingModel.IncludesSalesTax)
                {
                    TotalTaxTotal = Total;
                }
                else
                {
                    TotalTax = Total * Configuration.Current.CurrentSalesTax;
                    TotalTaxTotal = Total + TotalTax;
                }
            }
            CashDue = CreditTendered + CashTendered + CheckTendered - TotalTaxTotal;
        }


        public static readonly DependencyProperty TotalTaxTotalProperty =
             DependencyProperty.Register("TotalTaxTotal", typeof(decimal),
             typeof(PointOfSale));

        public decimal TotalTaxTotal
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalTaxTotalProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalTaxTotalProperty, value);
            }
        }


        static void OnStateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PointOfSale me = sender as PointOfSale;
            if (me != null)
            {
                Configuration.Current.LastUSState = me.USState;
                Configuration.Current.Save();
            }
        }

        public static readonly DependencyProperty USStateProperty =
          DependencyProperty.Register("USState", typeof(string),
          typeof(PointOfSale), new PropertyMetadata(OnStateChanged));

        public string USState
        {
            get
            {
                return (string)this.UIThreadGetValue(USStateProperty);
            }
            set
            {
                this.UIThreadSetValue(USStateProperty, value);
            }
        }





        public static readonly DependencyProperty TotalTaxProperty =
             DependencyProperty.Register("TotalTax", typeof(decimal),
             typeof(PointOfSale));

        public decimal TotalTax
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalTaxProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalTaxProperty, value);
            }
        }


        public static readonly DependencyProperty TotalProperty =
             DependencyProperty.Register("Total", typeof(decimal),
             typeof(PointOfSale));

        public decimal Total
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalProperty, value);
            }
        }

        void newItem_TotalDollarChanged(object sender, EventArgs e)
        {
            RefreshTotals();
        }

        private void OnPost(object sender, RoutedEventArgs e)
        {
            decimal profit = 0;
            decimal totalPrice = 0;
            decimal totalBreakeven=0;
            foreach (ActiveInventoryObject aio in Activity)
            {
                profit += aio.GetTotalPrice(SelectedPricingModel) - (aio.WholeSalePrice + aio.AdditionalOverhead);
                totalPrice+=aio.GetTotalPrice(SelectedPricingModel);
                totalBreakeven+=(aio.WholeSalePrice + aio.AdditionalOverhead);
            }


            if (profit <= 0)
            {
                if (MessageBox.Show(string.Format("WARNING!\r\n\r\nSale price is less than break-even cost.\r\n\r\nSale Price Total:{0}   Break-even cost: {1}\r\n\r\nAre you sure?",totalPrice.ToString("C"), totalBreakeven.ToString("C")), "Completing Sale", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.No)
                {
                    MessageBox.Show("Canceled.", "Sale Canceled", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
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
                    aioList[0].Quantity -= aio.Quantity;
                }
            }




            FinancialObject fin = TransactionEngine.Post(Activity, this.ReceiptID, this.CashTendered - this.CashDue,
                this.CreditTendered, this.CheckTendered, SelectedPricingModel, this.TotalTax, profit, USState, TotalTaxTotal, this.DiscountAmount);

           










            TotalCashSales += fin.TotalCash;
            TotalCreditSales += fin.TotalCredit;
            TotalCheckSales += fin.TotalCheck;
            TotalProfit += profit;
            TotalTaxesAssesed += TotalTax;

            Configuration.Current.ReceiptIDNumber++;
            ReceiptID = Configuration.BuildReceiptID();
            Configuration.Current.Save();
            ResetPage();
            
        }
        void ResetPage()
        {
            Activity.Clear();
            Total = 0;
            TotalTax = 0;
            TotalTaxTotal = 0;
            CashTendered = 0;
            CreditTendered = 0;
            CheckTendered = 0;
            this.DiscountAmount = 0;
            CashDue = 0;
            SetStartFocus();

        }
        public static readonly DependencyProperty TotalCashSalesProperty =
           DependencyProperty.Register("TotalCashSales", typeof(decimal),
           typeof(PointOfSale));

        public decimal TotalCashSales
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalCashSalesProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalCashSalesProperty, value);
            }
        }


        public static readonly DependencyProperty TotalCheckSalesProperty =
          DependencyProperty.Register("TotalCheckSales", typeof(decimal),
          typeof(PointOfSale));

        public decimal TotalCheckSales
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalCheckSalesProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalCheckSalesProperty, value);
            }
        }




        public static readonly DependencyProperty TotalCreditSalesProperty =
            DependencyProperty.Register("TotalCreditSales", typeof(decimal),
            typeof(PointOfSale));

        public decimal TotalCreditSales
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalCreditSalesProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalCreditSalesProperty, value);
            }
        }


        public static readonly DependencyProperty TotalTaxesAssesedProperty =
            DependencyProperty.Register("TotalTaxesAssesed", typeof(decimal),
            typeof(PointOfSale));

        public decimal TotalTaxesAssesed
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalTaxesAssesedProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalTaxesAssesedProperty, value);
            }
        }




        public static readonly DependencyProperty TotalProfitProperty =
            DependencyProperty.Register("TotalProfit", typeof(decimal),
            typeof(PointOfSale));

        public decimal TotalProfit
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalProfitProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalProfitProperty, value);
            }
        }









        private void OnDelete(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ActiveInventoryObject aio = btn.CommandParameter as ActiveInventoryObject;
                if (aio != null)
                {
                    this.Activity.Remove(aio);
                    RefreshTotals();
                }
            }
        }

        public static readonly DependencyProperty ReceiptIDProperty =
            DependencyProperty.Register("ReceiptID", typeof(string),
            typeof(PointOfSale));

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


        static void OnTenderedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PointOfSale me = sender as PointOfSale;
            if (me != null)
            {
                me.CashDue = me.CreditTendered + me.CashTendered + me.CheckTendered - me.TotalTaxTotal;
            }
        }

        public static readonly DependencyProperty CreditTenderedProperty =
            DependencyProperty.Register("CreditTendered", typeof(decimal),
            typeof(PointOfSale), new PropertyMetadata(OnTenderedChanged));

        public decimal CreditTendered
        {
            get
            {
                return (decimal)this.UIThreadGetValue(CreditTenderedProperty);
            }
            set
            {
                this.UIThreadSetValue(CreditTenderedProperty, value);
            }
        }




        public static readonly DependencyProperty CheckTenderedProperty =
            DependencyProperty.Register("CheckTendered", typeof(decimal),
            typeof(PointOfSale), new PropertyMetadata(OnTenderedChanged));

        public decimal CheckTendered
        {
            get
            {
                return (decimal)this.UIThreadGetValue(CheckTenderedProperty);
            }
            set
            {
                this.UIThreadSetValue(CheckTenderedProperty, value);
            }
        }







        public static readonly DependencyProperty CashTenderedProperty =
            DependencyProperty.Register("CashTendered", typeof(decimal),
            typeof(PointOfSale), new PropertyMetadata(OnTenderedChanged));

        public decimal CashTendered
        {
            get
            {
                return (decimal)this.UIThreadGetValue(CashTenderedProperty);
            }
            set
            {
                this.UIThreadSetValue(CashTenderedProperty, value);
            }
        }



        public static readonly DependencyProperty CashDueProperty =
            DependencyProperty.Register("CashDue", typeof(decimal),
            typeof(PointOfSale));

        public decimal CashDue
        {
            get
            {
                return (decimal)this.UIThreadGetValue(CashDueProperty);
            }
            set
            {
                this.UIThreadSetValue(CashDueProperty, value);
            }
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
            if (MessageBox.Show("Are you sure you wish to cancel?", "Cancel Sale", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ResetPage();
            }
        }
    }
}
