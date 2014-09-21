using RussLibrary;
using RussLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media.Imaging;

namespace SBMLibrary
{
    public class Configuration : ConfigurationObject
    {

        public static string BuildReceiptID()
        {
            return string.Format("{0} {1}-{2}", DateTime.Today.ToString("yyyyMMdd"), Configuration.Current.StationID, Configuration.Current.ReceiptIDNumber + 1);
        }
        public static string LogoFile
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Russ Judge", "Small Business POS", "logo.jpg");
            }
        }
        public const decimal CurrentFileVersion = 1.1M;

        public static decimal CurrencyToDecimal(string currency)
        {
            decimal retVal = 0;
            if (!string.IsNullOrEmpty(currency))
            {
                string val = currency.Replace("$", string.Empty).Trim();

                if (!decimal.TryParse(val, out retVal))
                {
                    return 0;
                }
            }
            return retVal;
            
            
        }
        public static string ProcessUPC(string upc)
        {
            string retVal = string.Empty;
            if (upc != null)
            {
                retVal = upc.Replace(" ", string.Empty).Trim();
                for (int i = 0; i < retVal.Length;i++ )
                {
                    if (retVal[i] > '9' || retVal[i] < '0')
                    {
                        retVal = retVal.Substring(0, i) + " " + retVal.Substring(i + 1);
                    }
                }
                
            }
            return retVal.Replace(" ", string.Empty).Trim();
        }
      
        static Configuration _currentConfig = new Configuration();

        public static Configuration Current
        {
            get
            {
                return _currentConfig;
            }
        }
        private Configuration() : base()
        {

        }
        #region Fields
        
        //NOTE: DO NOT MAKE THIS STATIC--IT DOES NOT WORK!!!
        readonly string configFile =
            System.IO.Path.Combine(GetDataPath(), "Config.dat");

        
        public static string GetDataPath()
        {

            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Russ Judge", "Small Business POS");

        }

        #endregion
        #region Constants
        
       
        #endregion
        public void DoApplicationShutdown()
        {
            ApplicationShutdown = true;
        }
        public bool GetDoApplicationShutdown()
        {
            return ApplicationShutdown;
        }
        bool ApplicationShutdown = false;
       


        protected override void SaveConfigurationData(MemoryStream stream)
        {
            if (stream != null)
            {
                if (File.Exists(configFile))
                {
                    File.Delete(configFile);
                }
                using (FileStream sr = new FileStream(configFile, FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    stream.WriteTo(sr);
                }
            }
           
        }

        protected override void LoadConfigurationData(MemoryStream stream)
        {
            
            System.IO.FileInfo f = new System.IO.FileInfo(configFile);
            FileHelper.CreatePath(f.DirectoryName);
            if (f.Exists && stream != null)
            {
                using (FileStream sr = new FileStream(configFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] buffer = new byte[32767];
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = sr.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                    } while (bytesRead > 0);
                }
            }
        }

        protected override void Initialize()
        {
            if (FileVersion == 0)
            {
                FileVersion = CurrentFileVersion;
            }
            
        }
       

        #region Properties
        
        public decimal FileVersion { get; internal set; }

        public string BusinessName { get; set; }

        public decimal CurrentSalesTax { get; set; }
        public decimal CurrentSessionStartingCash { get; set; }

        public string CurrentPricingModel { get; set; }

        public string StationID { get; set; }
        public int ReceiptIDNumber { get; set; }
        public string LastUSState { get; set; }
        public string OpenCartPassword { get; set; }
        public string OpenCartUsername { get; set; }
        public string OpenCartAdminURL { get; set; }
        #endregion

    }
}
