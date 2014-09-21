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
using System.Windows.Shapes;
using RussLibrary;
using Microsoft.Win32;
namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for CashBalanceWindow.xaml
    /// </summary>
    public partial class CashBalanceWindow : Window
    {
        public CashBalanceWindow()
        {
            InitializeComponent();
        }
        bool isChanging = false;
        static void OnCashCountChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CashBalanceWindow me = sender as CashBalanceWindow;
            if (me != null)
            {
                if (!me.isChanging)
                {
                    me.isChanging = true;
                    me.HundredsAmount = me.Hundreds * 100;
                    me.FiftiesAmount = me.Fifties * 50;
                    me.TwentiesAmount = me.Twenties * 20;
                    me.TensAmount = me.Tens * 10;
                    me.FivesAmount = me.Fives * 5;
                    me.TwosAmount = me.Twos * 2;
                    me.OnesAmount = me.Ones;
                    me.isChanging = false;
                }
                me.TotalBillCount = me.Hundreds + me.Fifties + me.Twenties + me.Tens + me.Fives + me.Twos + me.Ones;
            }
        }
        static void OnCashChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CashBalanceWindow me = sender as CashBalanceWindow;
            if (me != null)
            {
                if (!me.isChanging)
                {
                    me.isChanging = true;
                    me.Hundreds = Convert.ToInt32(me.HundredsAmount / 100);
                    me.Fifties = Convert.ToInt32(me.FiftiesAmount / 50);
                    me.Twenties = Convert.ToInt32(me.TwentiesAmount / 20);
                    me.Tens = Convert.ToInt32(me.TensAmount / 10);
                    me.Fives = Convert.ToInt32(me.FivesAmount / 5);
                    me.Twos = Convert.ToInt32(me.TwosAmount / 2);
                    me.Ones = Convert.ToInt32(me.OnesAmount);
                    me.isChanging = false;
                }
                me.TotalAmount = me.HundredsAmount + me.FiftiesAmount + me.TwentiesAmount + me.TensAmount + me.FivesAmount + me.TwosAmount + me.OnesAmount + me.CoinAmount;
            }
        }

        public static readonly DependencyProperty HundredsProperty =
           DependencyProperty.Register("Hundreds", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Hundreds
        {
            get
            {
                return (int)this.UIThreadGetValue(HundredsProperty);
            }
            set
            {
                this.UIThreadSetValue(HundredsProperty, value);
            }
        }


        public static readonly DependencyProperty HundredsAmountProperty =
           DependencyProperty.Register("HundredsAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal HundredsAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(HundredsAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(HundredsAmountProperty, value);
            }
        }




        public static readonly DependencyProperty FiftiesProperty =
           DependencyProperty.Register("Fifties", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Fifties
        {
            get
            {
                return (int)this.UIThreadGetValue(FiftiesProperty);
            }
            set
            {
                this.UIThreadSetValue(FiftiesProperty, value);
            }
        }


        public static readonly DependencyProperty FiftiesAmountProperty =
           DependencyProperty.Register("FiftiesAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal FiftiesAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(FiftiesAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(FiftiesAmountProperty, value);
            }
        }



        public static readonly DependencyProperty TwentiesProperty =
           DependencyProperty.Register("Twenties", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Twenties
        {
            get
            {
                return (int)this.UIThreadGetValue(TwentiesProperty);
            }
            set
            {
                this.UIThreadSetValue(TwentiesProperty, value);
            }
        }


        public static readonly DependencyProperty TwentiesAmountProperty =
           DependencyProperty.Register("TwentiesAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal TwentiesAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TwentiesAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(TwentiesAmountProperty, value);
            }
        }



        public static readonly DependencyProperty TensProperty =
           DependencyProperty.Register("Tens", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Tens
        {
            get
            {
                return (int)this.UIThreadGetValue(TensProperty);
            }
            set
            {
                this.UIThreadSetValue(TensProperty, value);
            }
        }


        public static readonly DependencyProperty TensAmountProperty =
           DependencyProperty.Register("TensAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal TensAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TensAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(TensAmountProperty, value);
            }
        }



        public static readonly DependencyProperty FivesProperty =
           DependencyProperty.Register("Fives", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Fives
        {
            get
            {
                return (int)this.UIThreadGetValue(FivesProperty);
            }
            set
            {
                this.UIThreadSetValue(FivesProperty, value);
            }
        }


        public static readonly DependencyProperty FivesAmountProperty =
           DependencyProperty.Register("FivesAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal FivesAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(FivesAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(FivesAmountProperty, value);
            }
        }




        public static readonly DependencyProperty TwosProperty =
           DependencyProperty.Register("Twos", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Twos
        {
            get
            {
                return (int)this.UIThreadGetValue(TwosProperty);
            }
            set
            {
                this.UIThreadSetValue(TwosProperty, value);
            }
        }


        public static readonly DependencyProperty TwosAmountProperty =
           DependencyProperty.Register("TwosAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal TwosAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TwosAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(TwosAmountProperty, value);
            }
        }





        public static readonly DependencyProperty OnesProperty =
           DependencyProperty.Register("Ones", typeof(int),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashCountChanged));

        public int Ones
        {
            get
            {
                return (int)this.UIThreadGetValue(OnesProperty);
            }
            set
            {
                this.UIThreadSetValue(OnesProperty, value);
            }
        }


        public static readonly DependencyProperty OnesAmountProperty =
           DependencyProperty.Register("OnesAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal OnesAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(OnesAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(OnesAmountProperty, value);
            }
        }




        public static readonly DependencyProperty CoinAmountProperty =
           DependencyProperty.Register("CoinAmount", typeof(decimal),
           typeof(CashBalanceWindow), new PropertyMetadata(OnCashChanged));

        public decimal CoinAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(CoinAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(CoinAmountProperty, value);
            }
        }





        public static readonly DependencyProperty TotalBillCountProperty =
           DependencyProperty.Register("TotalBillCount", typeof(int),
           typeof(CashBalanceWindow));

        public int TotalBillCount
        {
            get
            {
                return (int)this.UIThreadGetValue(TotalBillCountProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalBillCountProperty, value);
            }
        }




        public static readonly DependencyProperty TotalAmountProperty =
           DependencyProperty.Register("TotalAmount", typeof(decimal),
           typeof(CashBalanceWindow));

        public decimal TotalAmount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalAmountProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalAmountProperty, value);
            }
        }





        public static readonly DependencyProperty ExpectedCashProperty =
           DependencyProperty.Register("ExpectedCash", typeof(decimal),
           typeof(CashBalanceWindow));

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




        public static readonly DependencyProperty StartingCashProperty =
           DependencyProperty.Register("StartingCash", typeof(decimal),
           typeof(CashBalanceWindow));

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



        private void OnContinue(object sender, RoutedEventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Title = "Close Day Reporting: Select report file";
            diag.DefaultExt = "pdf";
            diag.Filter = "PDF Files|*.pdf|All Files|*.*";
            if (diag.ShowDialog() == true)
            {
                TransactionEngine.CloseDay(StartingCash, TotalAmount, diag.FileName);
                System.Diagnostics.Process.Start(diag.FileName);
                
                Cache.Current.Save();
                this.Close();
            }
        }
    }
}
