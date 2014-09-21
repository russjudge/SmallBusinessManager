using log4net;
using RussLibrary.Controls;
using RussLibrary.Controls.Helpers;
using RussLibrary.Controls.Security;
using SBMLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace SmallBusinessManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(App));
        private void OnExplode(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //Run processes to save data in RAM.  Log data.
            //System.Data.OleDb.OleDbConnection c = new System.Data.OleDb.OleDbConnection();
            //System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            if (_log.IsFatalEnabled)
            {
                RussLibrary.Helpers.Log4Net.Helper.PerformCrashLogging(e.Exception);
            }

        }
        const string UpdateURL = "https://dl.dropboxusercontent.com/u/14746342/FoxOnePOSShared/Current_versionData.txt";
        private void OnStartup(object sender, StartupEventArgs e)
        {

            if (_log.IsFatalEnabled)
            {
                _log.Fatal("Application Start\r\n");
            }
            if (SelfUpdater.CheckForUpdate(UpdateURL))
            {
                Configuration.Current.DoApplicationShutdown();
            }

        }
    }
}
