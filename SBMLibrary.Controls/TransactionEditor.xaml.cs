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
    /// Interaction logic for TransactionEditor.xaml
    /// </summary>
    public partial class TransactionEditor : UserControl
    {
        public TransactionEditor()
        {
            Transactions = new TransactionCollection();
            UsePreCloseDay = true;

            InitializeComponent();
        }
        public static readonly DependencyProperty TransactionsProperty =
         DependencyProperty.Register("Transactions", typeof(TransactionCollection),
         typeof(TransactionEditor));


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

        static void OnUsePreCloseDayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TransactionEditor me = sender as TransactionEditor;
            if (me != null)
            {
                me.Transactions.Clear();
                if (me.UsePreCloseDay)
                {
                    foreach (InventoryTransactionObject tran in Cache.Current.InventoryActivity)
                    {
                        me.Transactions.Add(tran);
                    }
                }
                else
                {
                    foreach (InventoryTransactionObject tran in Cache.Current.ReadyForOpenCartUpdate)
                    {
                        me.Transactions.Add(tran);
                    }
                }
            }
        }

        public static readonly DependencyProperty UsePreCloseDayProperty =
        DependencyProperty.Register("UsePreCloseDay", typeof(bool),
        typeof(TransactionEditor), new PropertyMetadata(OnUsePreCloseDayChanged));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public bool UsePreCloseDay
        {
            get
            {
                return (bool)this.UIThreadGetValue(UsePreCloseDayProperty);
            }
            set
            {
                this.UIThreadSetValue(UsePreCloseDayProperty, value);
            }
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            Cache.Current.SaveInventoryActivity();
            Cache.Current.SaveReadyForOpenCartUpdate();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                InventoryTransactionObject tran = btn.CommandParameter as InventoryTransactionObject;
                if (tran != null)
                {
                    if (UsePreCloseDay)
                    {
                        Cache.Current.InventoryActivity.Remove(tran);
                    }
                    else
                    {
                        Cache.Current.ReadyForOpenCartUpdate.Remove(tran);

                    }
                    Transactions.Remove(tran);
                }
            }
        }

       
    }
}
