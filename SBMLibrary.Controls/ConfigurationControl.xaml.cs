using Microsoft.Win32;
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
namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for ConfigurationControl.xaml
    /// </summary>
    public partial class ConfigurationControl : UserControl
    {
        public ConfigurationControl()
        {
            LoadLogo();
            BusinessName = Configuration.Current.BusinessName;
            StationID = Configuration.Current.StationID;
            OpenCartAdminURL = Configuration.Current.OpenCartAdminURL;
            OpenCartPassword = Configuration.Current.OpenCartPassword;
            OpenCartUsername = Configuration.Current.OpenCartUsername;

            isInitializing = false;
            InitializeComponent();
        }
        
        void LoadLogo()
        {

            if (File.Exists(Configuration.LogoFile))
            {
                using (Stream fs = new FileStream(Configuration.LogoFile, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.StreamSource = ms;
                        img.CacheOption = BitmapCacheOption.OnLoad;
                        img.EndInit();
                        img.Freeze();
                        Logo = img;
                    }
                }
            }
        }
        void SelectLogoImage()
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Title = "Select Logo";
            diag.Filter = "Image files (*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif|All Files (*.*)|*.*";
            diag.CheckFileExists = true;
            diag.CheckPathExists = true;
            if (diag.ShowDialog() == true)
            {
                if (File.Exists(Configuration.LogoFile))
                {
                    File.Delete(Configuration.LogoFile);
                }
                File.Copy(diag.FileName, Configuration.LogoFile);
                LoadLogo();
            }
        }
        bool isInitializing = true;

        static void OnBusinessNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ConfigurationControl me = sender as ConfigurationControl;
            if (me != null)
            {
                if (!me.isInitializing)
                {
                    Configuration.Current.BusinessName = me.BusinessName;

                }
            }
        }
        public static readonly DependencyProperty BusinessNameProperty =
             DependencyProperty.Register("BusinessName", typeof(string),
             typeof(ConfigurationControl), new PropertyMetadata(OnBusinessNameChanged));

        public string BusinessName
        {
            get
            {
                return (string)this.UIThreadGetValue(BusinessNameProperty);
            }
            set
            {
                this.UIThreadSetValue(BusinessNameProperty, value);
            }
        }




        static void OnOpenCartURLChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ConfigurationControl me = sender as ConfigurationControl;
            if (me != null)
            {
                if (!me.isInitializing)
                {
                    Configuration.Current.OpenCartAdminURL = me.OpenCartAdminURL;

                }
            }
        }
        public static readonly DependencyProperty OpenCartAdminURLProperty =
             DependencyProperty.Register("OpenCartAdminURL", typeof(string),
             typeof(ConfigurationControl), new PropertyMetadata(OnOpenCartURLChanged));

        public string OpenCartAdminURL
        {
            get
            {
                return (string)this.UIThreadGetValue(OpenCartAdminURLProperty);
            }
            set
            {
                this.UIThreadSetValue(OpenCartAdminURLProperty, value);
            }
        }


        //OpenCartAdminURL

        static void OnOpenCartUsernameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ConfigurationControl me = sender as ConfigurationControl;
            if (me != null)
            {
                if (!me.isInitializing)
                {
                    Configuration.Current.OpenCartUsername = me.OpenCartUsername;

                }
            }
        }
        public static readonly DependencyProperty OpenCartUsernameProperty =
             DependencyProperty.Register("OpenCartUsername", typeof(string),
             typeof(ConfigurationControl), new PropertyMetadata(OnOpenCartUsernameChanged));

        public string OpenCartUsername
        {
            get
            {
                return (string)this.UIThreadGetValue(OpenCartUsernameProperty);
            }
            set
            {
                this.UIThreadSetValue(OpenCartUsernameProperty, value);
            }
        }
        //OpenCartUsername


        static void OnOpenCartPasswordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ConfigurationControl me = sender as ConfigurationControl;
            if (me != null)
            {
                if (!me.isInitializing)
                {
                    Configuration.Current.OpenCartPassword = me.OpenCartPassword;

                }
            }
        }
        public static readonly DependencyProperty OpenCartPasswordProperty =
            DependencyProperty.Register("OpenCartPassword", typeof(string),
            typeof(ConfigurationControl), new PropertyMetadata(OnOpenCartPasswordChanged));

        public string OpenCartPassword
        {
            get
            {
                return (string)this.UIThreadGetValue(OpenCartPasswordProperty);
            }
            set
            {
                this.UIThreadSetValue(OpenCartPasswordProperty, value);
            }
        }
        //OpenCartPassword

        public static readonly DependencyProperty LogoProperty =
             DependencyProperty.Register("Logo", typeof(BitmapImage),
             typeof(ConfigurationControl));

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
        private void OnImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectLogoImage();
        }

        private void OnBrowse(object sender, RoutedEventArgs e)
        {
            SelectLogoImage();
        }

        static void OnStationIDChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ConfigurationControl me = sender as ConfigurationControl;
            if (me != null)
            {
                if (!me.isInitializing)
                {
                    Configuration.Current.StationID = me.StationID;

                }
            }
        }
        public static readonly DependencyProperty StationIDProperty =
             DependencyProperty.Register("StationID", typeof(string),
             typeof(ConfigurationControl), new PropertyMetadata(OnStationIDChanged));

        public string StationID
        {
            get
            {
                return (string)this.UIThreadGetValue(StationIDProperty);
            }
            set
            {
                this.UIThreadSetValue(StationIDProperty, value);
            }
        }

        private void OnSaveConfiguration(object sender, RoutedEventArgs e)
        {
            Configuration.Current.Save();
        }

        private void OnResetTransactionActivity(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("WARNING!!\r\n\r\nThis will delete all POS activity, including financials!!!\r\n\r\nAre you sure?", "Fucking Clobberation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Cache.Current.CurrentFinancials.Clear();
                Cache.Current.InventoryActivity.Clear();
                Cache.Current.SaveFinancials();
                Cache.Current.SaveInventoryActivity();
                MessageBox.Show("Close and restart to refresh Sales Status.");
            }
        }

        private void OnAdminPasswordChanged(object sender, RoutedEventArgs e)
        {
            OpenCartPassword = OpenCartPasswordBox.Password;
        }

        private void OnApplyProductID(object sender, RoutedEventArgs e)
        {
            foreach (InventoryTransactionObject ito in Cache.Current.InventoryActivity)
            {
                List<ActiveInventoryObject> aioList = Cache.Current.Inventory.GetByUPCorSKU(ito.UPC);
                if (aioList.Count==1)
                {
                ito.ProductID = aioList[0].ProductID;
                }
            }
            Cache.Current.SaveInventoryActivity();


            foreach (InventoryTransactionObject ito in Cache.Current.ReadyForOpenCartUpdate)
            {
                List<ActiveInventoryObject> aioList = Cache.Current.Inventory.GetByUPCorSKU(ito.UPC);
                if (aioList.Count == 1)
                {
                    ito.ProductID = aioList[0].ProductID;
                }
            }
            Cache.Current.SaveReadyForOpenCartUpdate();
            MessageBox.Show("all done.");
        }

        private void OnQuantityAdjust(object sender, RoutedEventArgs e)
        {
            foreach (InventoryTransactionObject ito in Cache.Current.InventoryActivity)
            {
                List<ActiveInventoryObject> aioList = Cache.Current.Inventory.GetByUPCorSKU(ito.UPC);
                if (aioList.Count == 1)
                {
                    aioList[0].Quantity += ito.Quantity;
                    
                }
            }
            Cache.Current.SaveInventory();
            MessageBox.Show("all done.");
        }

        private void OnProductIDVerify(object sender, RoutedEventArgs e)
        {
            bool okay = true;
            foreach (InventoryTransactionObject ito in Cache.Current.InventoryActivity)
            {
                if (ito.ProductID == 0)
                {
                    okay = false;
                    break;
                }
            }
            if (okay)
            {
                MessageBox.Show("All is fucking good!");

            }
            else
            {
                MessageBox.Show("You're screwed.");
            }
        }

    }
}
