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
    /// Interaction logic for ActiveInventoryEditor.xaml
    /// </summary>
    public partial class ActiveInventoryEditor : UserControl
    {
        public ActiveInventoryEditor()
        {
            //17 items.
            Inventory = new ActiveInventoryCollection();
            FilteredInventory = new ActiveInventoryCollection();
            foreach (ActiveInventoryObject aio in Cache.Current.Inventory)
            {
                Inventory.Add(aio);
                FilteredInventory.Add(aio);
            }
            

            InitializeComponent();
            RefreshTotals();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ActiveInventoryObject aio = btn.CommandParameter as ActiveInventoryObject;
                if (aio != null && Inventory.Contains(aio))
                {
                    Inventory.Remove(aio);
                }
            }
        }
        public static readonly DependencyProperty InventoryProperty =
           DependencyProperty.Register("Inventory", typeof(ActiveInventoryCollection),
           typeof(ActiveInventoryEditor));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ActiveInventoryCollection Inventory
        {
            get
            {
                return (ActiveInventoryCollection)this.UIThreadGetValue(InventoryProperty);
            }
            set
            {
                this.UIThreadSetValue(InventoryProperty, value);
            }
        }


        public static readonly DependencyProperty FilterUPCProperty =
           DependencyProperty.Register("FilterUPC", typeof(string),
           typeof(ActiveInventoryEditor));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public string FilterUPC
        {
            get
            {
                return (string)this.UIThreadGetValue(FilterUPCProperty);
            }
            set
            {
                this.UIThreadSetValue(FilterUPCProperty, value);
            }
        }



        public static readonly DependencyProperty FilterSKUProperty =
           DependencyProperty.Register("FilterSKU", typeof(string),
           typeof(ActiveInventoryEditor));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public string FilterSKU
        {
            get
            {
                return (string)this.UIThreadGetValue(FilterSKUProperty);
            }
            set
            {
                this.UIThreadSetValue(FilterSKUProperty, value);
            }
        }


        public static readonly DependencyProperty FilterNameProperty =
           DependencyProperty.Register("FilterName", typeof(string),
           typeof(ActiveInventoryEditor));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public string FilterName
        {
            get
            {
                return (string)this.UIThreadGetValue(FilterNameProperty);
            }
            set
            {
                this.UIThreadSetValue(FilterNameProperty, value);
            }
        }







        public static readonly DependencyProperty FilteredInventoryProperty =
           DependencyProperty.Register("FilteredInventory", typeof(ActiveInventoryCollection),
           typeof(ActiveInventoryEditor));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ActiveInventoryCollection FilteredInventory
        {
            get
            {
                return (ActiveInventoryCollection)this.UIThreadGetValue(FilteredInventoryProperty);
            }
            set
            {
                this.UIThreadSetValue(FilteredInventoryProperty, value);
            }
        }

        void RefreshTotals()
        {
            TotalInvested = 0;
            foreach (ActiveInventoryObject aio in Inventory)
            {
                TotalInvested += aio.WholeSalePrice + aio.AdditionalOverhead;
            }
        }
        public static readonly DependencyProperty TotalInvestedProperty =
          DependencyProperty.Register("TotalInvested", typeof(decimal),
          typeof(ActiveInventoryEditor));


        public decimal TotalInvested
        {
            get
            {
                return (decimal)this.UIThreadGetValue(TotalInvestedProperty);
            }
            set
            {
                this.UIThreadSetValue(TotalInvestedProperty, value);
            }
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            ActiveInventoryObject aio = new ActiveInventoryObject();
            aio.Model = "New Item";
            Inventory.Add(aio);
            FilteredInventory.Add(aio);
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {

            Cache.Current.Inventory.Clear();
            foreach (ActiveInventoryObject aio in this.Inventory)
            {
                Cache.Current.Inventory.Add(aio);
            }
            Cache.Current.SaveInventory();
            
        }

        private void OnDetails(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not yet implemented.");
        }

        void DoFilter(string propertyName, string value)
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(propertyName))
            {


                List<ActiveInventoryObject> aioList = new List<ActiveInventoryObject>(FilteredInventory);

                string cmp = value.ToUpperInvariant();
                FilteredInventory.Clear();
                foreach (ActiveInventoryObject aio in aioList)
                {
                    string entry = typeof(ActiveInventoryObject).GetProperty(propertyName).GetValue(aio, null) as string;
                    if (entry.ToUpperInvariant().Contains(cmp))
                    {
                        FilteredInventory.Add(aio);

                    }
                }
                
           

            }
            
        }
        void ResetFilter()
        {
            FilterSKU = string.Empty;
            FilterName = string.Empty;
            FilterUPC = string.Empty;
            FilteredInventory.Clear();
            foreach (ActiveInventoryObject aio in Inventory)
            {
                FilteredInventory.Add(aio);
            }
        }
        private void OnFilterSKU(object sender, RoutedEventArgs e)
        {
            DoFilter("SKU", FilterSKU);
        }

        private void OnFilterName(object sender, RoutedEventArgs e)
        {
            DoFilter("Name", FilterName);
        }

        private void OnResetFilter(object sender, RoutedEventArgs e)
        {
            ResetFilter();
        }

        private void OnFilterUPC(object sender, RoutedEventArgs e)
        {
            DoFilter("UPC", FilterUPC);
        }


    }
}
