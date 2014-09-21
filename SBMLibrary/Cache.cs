using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using RussLibrary;
namespace SBMLibrary
{
    public class Cache
    {

        //NOTE: DO NOT MAKE THESE STATIC--IT DOES NOT WORK!!!
        readonly string InventoryFile = System.IO.Path.Combine(Configuration.GetDataPath(), "Inventory.aio");
        readonly string InventoryActivityFile = System.IO.Path.Combine(Configuration.GetDataPath(), "Activity.aio");
        readonly string ReadyToPostFile = System.IO.Path.Combine(Configuration.GetDataPath(), "ReadyToPost.aio");

        readonly string FinancialsFile = System.IO.Path.Combine(Configuration.GetDataPath(), "CurrentFinancials.fo");

        readonly string StagedFinancialsFile = System.IO.Path.Combine(Configuration.GetDataPath(), "StagedFinancials.fo");

        private Cache()
        {
            Inventory = new ActiveInventoryCollection();
            Inventory.Load(InventoryFile);
            InventoryActivity = new TransactionCollection();
            InventoryActivity.Load(InventoryActivityFile);

            ReadyForOpenCartUpdate = new TransactionCollection();
            ReadyForOpenCartUpdate.Load(ReadyToPostFile);

            if (Configuration.Current.FileVersion < Configuration.CurrentFileVersion)
            {
                DoVersionUpdateProcess();
            }

            CurrentFinancials = new FinancialObjectCollection();
            CurrentFinancials.Load(FinancialsFile);


            StagedFinancials = new FinancialObjectCollection();
            StagedFinancials.Load(StagedFinancialsFile);
        }


        void DoVersionUpdateProcess()
        {
            //do
            //{
            //    //if (Configuration.Current.FileVersion == 1.0M)
            //    //{
            //    //    Version10to11Conversion();
            //    //}
            //} while (Configuration.Current.FileVersion < Configuration.CurrentFileVersion);
        }
        //void Version10to11Conversion()
        //{
        //    foreach (ActiveInventoryObject aio in Inventory)
        //    {
        //        if (aio.DiscountRateLevel == 0.05M)
        //        {
        //            aio.IsModelKit = true;
        //        }
        //    }

        //    SaveInventory();
        //    Configuration.Current.FileVersion = 1.1M;
        //    Configuration.Current.Save();
        //}
        public void SaveInventory()
        {
            Inventory.Save(InventoryFile);
        }
        public void Save()
        {
            SaveInventory();
            SaveInventoryActivity();
            SaveReadyForOpenCartUpdate();
            SaveFinancials();
            SaveStagedFinancials();
        }
        public void SaveFinancials()
        {
            CurrentFinancials.Save(FinancialsFile);
        }
        public void SaveStagedFinancials()
        {
            StagedFinancials.Save(StagedFinancialsFile);
        }
        public void SaveInventoryActivity()
        {
            InventoryActivity.Save(InventoryActivityFile);
        }
        public void SaveReadyForOpenCartUpdate()
        {
            ReadyForOpenCartUpdate.Save(ReadyToPostFile);
        }
        static Cache _current= new Cache();
        public static Cache Current
        {
            get
            {
                return _current;
            }
        }
        public ActiveInventoryCollection Inventory { get; private set; }

        public TransactionCollection InventoryActivity { get; private set; }

        public TransactionCollection ReadyForOpenCartUpdate { get; private set; }

        public FinancialObjectCollection CurrentFinancials { get; private set; }

        public FinancialObjectCollection StagedFinancials { get; private set; }

        public object ReceiptIndex { get; private set; }


        
    }
}
