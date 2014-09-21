using Microsoft.Win32;
using RussLibrary.Controls.Security;
using SBMLibrary;
using System;
using System.Collections.Generic;
using System.IO;
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
using RussLibrary.Controls.Helpers;
namespace SmallBusinessManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }
        
        private void OnLoaded(object sender, RoutedEventArgs e)
        {

            



            if (Configuration.Current.GetDoApplicationShutdown())
            {
                this.Close();
            }
        }

     

        //private void OnConfiguration(object sender, RoutedEventArgs e)
        //{

        //}

        private void OnImportInventory(object sender, RoutedEventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Title = "Select File for Import";
            diag.Filter = "Comma Delimited|*.csv|All Files|*.*";
            diag.CheckFileExists = true;
            diag.CheckPathExists = true;
            diag.DefaultExt = "csv";
            diag.Multiselect = false;





            if (diag.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(diag.FileName))
                {
                    LumenWorks.Framework.IO.Csv.CsvReader csv = new LumenWorks.Framework.IO.Csv.CsvReader(sr, true);

                    int fieldCount = csv.FieldCount;
                    string[] headers = csv.GetFieldHeaders();

                    while (csv.ReadNextRecord())
                    {
                        ActiveInventoryObject Inv = new ActiveInventoryObject();

                        int i = 0;

                        Inv.UPC = csv[0];

                        Inv.Distributor = csv[1];
                        Inv.SKU = csv[2];
                        Inv.Description = csv[3];
                        Inv.Category = csv[4];
                        if (int.TryParse(csv[5], out i))
                        {
                            Inv.Quantity = i;
                        }


                        Inv.WholeSalePrice = Configuration.CurrencyToDecimal(csv[6]);


                        Inv.MSRP = Configuration.CurrencyToDecimal(csv[7]);


                        Inv.AdditionalOverhead = Configuration.CurrencyToDecimal(csv[8]);

                        Inv.DescriptionShort = Inv.Description;
                        Inv.Manufacturer = csv[14];

                        Cache.Current.Inventory.Add(Inv);
                        
                    }

                }
                MessageBox.Show("Process Complete.");
            }

        }

        private void OnMouseDownActiveInventory(object sender, MouseButtonEventArgs e)
        {

        }
        
        
    }
}
