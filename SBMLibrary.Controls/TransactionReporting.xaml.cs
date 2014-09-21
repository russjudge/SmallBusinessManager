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
using Microsoft.Win32;
using System.IO;

namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for TransactionReporting.xaml
    /// </summary>
    public partial class TransactionReporting : UserControl
    {
        public TransactionReporting()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TransactionsProperty =
         DependencyProperty.Register("Transactions", typeof(TransactionCollection),
         typeof(TransactionReporting));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public TransactionCollection Transactions
        {
            get
            {
                return (TransactionCollection)this.UIThreadGetValue(TransactionsProperty);
            }
            set
            {
                this.UIThreadSetValue(TransactionsProperty, value);
            }
        }
        public static readonly DependencyProperty FinancesProperty =
        DependencyProperty.Register("Finances", typeof(FinancialObjectCollection),
        typeof(TransactionReporting));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public FinancialObjectCollection Finances
        {
            get
            {
                return (FinancialObjectCollection)this.UIThreadGetValue(FinancesProperty);
            }
            set
            {
                this.UIThreadSetValue(FinancesProperty, value);
            }
        }


        public static readonly DependencyProperty ShowUnexportedOnlyProperty =
         DependencyProperty.Register("ShowUnexportedOnly", typeof(bool),
         typeof(TransactionReporting));



             public bool ShowUnexportedOnly
        {
            get
            {
                return (bool)this.UIThreadGetValue(ShowUnexportedOnlyProperty);
            }
            set
            {
                this.UIThreadSetValue(ShowUnexportedOnlyProperty, value);
            }
        }



        public static readonly DependencyProperty ReportDateProperty =
         DependencyProperty.Register("ReportDate", typeof(string),
         typeof(TransactionReporting));


        
        public string ReportDate
        {
            get
            {
                return (string)this.UIThreadGetValue(ReportDateProperty);
            }
            set
            {
                this.UIThreadSetValue(ReportDateProperty, value);
            }
        }

        private void OnSubmitReport(object sender, RoutedEventArgs e)
        {
            DateTime rpt = DateTime.MinValue;
            try
            {
                rpt = DateTime.Parse(ReportDate);
            }
            catch { }
            Transactions = new TransactionCollection();
            Finances = new FinancialObjectCollection();
            foreach (InventoryTransactionObject tran1 in Cache.Current.ReadyForOpenCartUpdate)
            {
                if (((tran1.TransactionTime.CompareTo(rpt) >= 0 && tran1.TransactionTime.CompareTo(rpt.AddDays(1)) <= 0 || rpt.Year < 2014) && !ShowUnexportedOnly) || (ShowUnexportedOnly && !tran1.ExportedToWeb))
                {
                    Transactions.Add(tran1);
                }
            }
            foreach (FinancialObject fin1 in Cache.Current.CurrentFinancials)
            {
                if (fin1.TransactionDateTime.CompareTo(rpt) >= 0 && fin1.TransactionDateTime.CompareTo(rpt.AddDays(1)) <= 0)
                {
                    Finances.Add(fin1);
                }
            }
            MessageBox.Show("Complete");
            /*
             *   
            foreach (InventoryTransactionObject tran1 in working)
            {
                
                Cache.Current.ReadyForOpenCartUpdate.Add(tran1);
                Cache.Current.InventoryActivity.Remove(tran1);
            }
            if (tran != null)
            {
                Cache.Current.ReadyForOpenCartUpdate.Add(tran);
                working.Add(tran);
            }
            foreach (FinancialObject fin1 in financialList)
            {
                Cache.Current.StagedFinancials.Add(fin1);
                Cache.Current.CurrentFinancials.Remove(fin1);
            }
            if (fin != null)
            {
                Cache.Current.StagedFinancials.Add(fin);
                financialList.Add(fin);
            }
             * */
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            Cache.Current.SaveReadyForOpenCartUpdate();
        }

        private void OnExportList(object sender, RoutedEventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Title = "Select file";
            if (diag.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(diag.FileName))
                {
                    sw.WriteLine("ReceiptID, TransactionTime, ProductID, UPC, SKU, Quantity, SellingPriceEach, TransactionAmount, Discount, ExportedToWeb");
                    foreach (InventoryTransactionObject tran in this.Transactions)
                    {
                        sw.WriteLine(tran.ReceiptID + ","
                            + tran.TransactionTime.ToString() + ","
                            + tran.ProductID.ToString() + ","
                            + tran.UPC + ","
                            + tran.SKU+","
                            + tran.Quantity.ToString() + ","
                            + tran.SellingPriceEach.ToString() + ","
                            + tran.TransactionAmount.ToString() + ","
                            + tran.Discount.ToString() + ","
                            + tran.ExportedToWeb.ToString()
                            );
                    }
                }
                MessageBox.Show("Export Complete.");
            }

        }
    }
}
