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
namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for SalesStatus.xaml
    /// </summary>
    public partial class SalesStatus : UserControl
    {
        public SalesStatus()
        {
            SalesTax = Configuration.Current.CurrentSalesTax;
            StartingCash = Configuration.Current.CurrentSessionStartingCash;
            InitializeComponent();
        }


        static void OnSalesTaxChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SalesStatus me = sender as SalesStatus;
            if (me != null)
            {
                Configuration.Current.CurrentSalesTax = me.SalesTax;
                Configuration.Current.Save();
            }
        }
        public static readonly DependencyProperty SalesTaxProperty =
             DependencyProperty.Register("SalesTax", typeof(decimal),
             typeof(SalesStatus), new PropertyMetadata(0M, OnSalesTaxChanged));

        public decimal SalesTax
        {
            get
            {
                return (decimal)this.UIThreadGetValue(SalesTaxProperty);
            }
            set
            {
                this.UIThreadSetValue(SalesTaxProperty, value);
            }
        }
        static void OnStartingCashChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SalesStatus me = sender as SalesStatus;
            if (me != null)
            {
                Configuration.Current.CurrentSessionStartingCash = me.StartingCash;
                Configuration.Current.Save();
                me.ExpectedCash = me.StartingCash + me.TotalCashSales;
            }
        }
        public static readonly DependencyProperty StartingCashProperty =
            DependencyProperty.Register("StartingCash", typeof(decimal),
            typeof(SalesStatus), new PropertyMetadata(0M, OnStartingCashChanged));

        public decimal StartingCash
        {
            get
            {
                return (decimal)this.UIThreadGetValue(StartingCashProperty);
            }
            set
            {
                this.UIThreadSetValue(StartingCashProperty, value);
            }
        }

        static void OnCashChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SalesStatus me = sender as SalesStatus;
            if (me != null)
            {
                me.ExpectedCash = me.StartingCash + me.TotalCashSales;
            }
        }
        public static readonly DependencyProperty TotalCashSalesProperty =
            DependencyProperty.Register("TotalCashSales", typeof(decimal),
            typeof(SalesStatus), new PropertyMetadata(OnCashChange));

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

        public static readonly DependencyProperty TotalCreditSalesProperty =
            DependencyProperty.Register("TotalCreditSales", typeof(decimal),
            typeof(SalesStatus));

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

        public static readonly DependencyProperty TotalCheckSalesProperty =
          DependencyProperty.Register("TotalCheckSales", typeof(decimal),
          typeof(SalesStatus));

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

        public static readonly DependencyProperty TotalTaxesAssesedProperty =
            DependencyProperty.Register("TotalTaxesAssesed", typeof(decimal),
            typeof(SalesStatus));

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
            typeof(SalesStatus));

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





        public static readonly DependencyProperty ExpectedCashProperty =
            DependencyProperty.Register("ExpectedCash", typeof(decimal),
            typeof(SalesStatus));

        public decimal ExpectedCash
        {
            get
            {
                return (decimal)this.UIThreadGetValue(ExpectedCashProperty);
            }
            set
            {
                this.UIThreadSetValue(ExpectedCashProperty, value);
            }
        }


        private void OnCloseDay(object sender, RoutedEventArgs e)
        {
            //StartingCash = 0;


            CashBalanceWindow win = new CashBalanceWindow();
            win.ExpectedCash = ExpectedCash;
            win.StartingCash = StartingCash;
            win.ShowDialog();
            StartingCash = 0;
            ExpectedCash = 0;
            TotalProfit = 0;
            TotalTaxesAssesed = 0;
            TotalCashSales = 0;
            TotalCreditSales = 0;
            TotalCheckSales = 0;


        }
    }
}
