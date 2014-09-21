using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using RussLibrary;
using System.Collections.ObjectModel;

namespace SBMLibrary
{
    public class PricingModelObject : DependencyObject, ISaveable
    {
        static PricingModelObject()
        {
            Load();
        }
        static ObservableCollection<PricingModelObject> _Models = new ObservableCollection<PricingModelObject>();
        public static ObservableCollection<PricingModelObject> Models
        {
            get
            {
                return _Models;
            }
        }
        public static PricingModelObject GetPricingModel(string name)
        {
            PricingModelObject retVal = null;
            if (!string.IsNullOrEmpty(name))
            {
                foreach (PricingModelObject pmo in Models)
                {
                    if (pmo.Name == name)
                    {
                        retVal = pmo;
                        break;
                    }
                }
            }
            return retVal;
        }
        public static void Save()
        {
            foreach (PricingModelObject pmo in Models)
            {
                if (!string.IsNullOrEmpty(pmo.Name))
                {
                    string f = System.IO.Path.Combine(Configuration.GetDataPath(), pmo.Name + ".pmo");
                    pmo.Save(f);
                }
            }
        }
        public static void Load()
        {
            Models.Clear();
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(Configuration.GetDataPath());
            foreach (System.IO.FileInfo f in d.GetFiles("*.pmo"))
            {
                PricingModelObject pmo = new PricingModelObject();
                pmo.Load(f.FullName);
                Models.Add(pmo);
            }
        }
        public static readonly DependencyProperty BasePriceChoiceProperty =
            DependencyProperty.Register("BasePriceChoice", typeof(BasePriceSelection),
            typeof(PricingModelObject), new PropertyMetadata(BasePriceSelection.BasedOnMSRP));

        [Saveable]
        public BasePriceSelection BasePriceChoice
        {
            get
            {
                return (BasePriceSelection)this.UIThreadGetValue(BasePriceChoiceProperty);
            }
            set
            {
                this.UIThreadSetValue(BasePriceChoiceProperty, value);
            }
        }



        public static readonly DependencyProperty RoundToNearestProperty =
            DependencyProperty.Register("RoundToNearest", typeof(decimal),
            typeof(PricingModelObject), new PropertyMetadata(0.01M));

        [Saveable]
        public decimal RoundToNearest
        {
            get
            {
                return (decimal)this.UIThreadGetValue(RoundToNearestProperty);
            }
            set
            {
                this.UIThreadSetValue(RoundToNearestProperty, value);
            }
        }



        public static readonly DependencyProperty MultiplierProperty =
            DependencyProperty.Register("Multiplier", typeof(decimal),
            typeof(PricingModelObject), new PropertyMetadata(1M));

        [Saveable]
        public decimal Multiplier
        {
            get
            {
                return (decimal)this.UIThreadGetValue(MultiplierProperty);
            }
            set
            {
                this.UIThreadSetValue(MultiplierProperty, value);
            }
        }



        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string),
            typeof(PricingModelObject));

        [Saveable]
        public string Name
        {
            get
            {
                return (string)this.UIThreadGetValue(NameProperty);
            }
            set
            {
                this.UIThreadSetValue(NameProperty, value);
            }
        }




        public static readonly DependencyProperty IncludesSalesTaxProperty =
            DependencyProperty.Register("IncludesSalesTax", typeof(bool),
            typeof(PricingModelObject));

        [Saveable]
        public bool IncludesSalesTax
        {
            get
            {
                return (bool)this.UIThreadGetValue(IncludesSalesTaxProperty);
            }
            set
            {
                this.UIThreadSetValue(IncludesSalesTaxProperty, value);
            }
        }




        public decimal GetSalePrice(decimal SellingPrice, decimal BreakEvenCost, decimal specialRateDiscount)
        {
            
            decimal basePrice = 0;
            switch (BasePriceChoice)
            {
                case BasePriceSelection.BasedOnBreakEven:
                    basePrice = BreakEvenCost;
                    break;
                case BasePriceSelection.BasedOnMSRP:
                    basePrice = SellingPrice;
                    break;
            }
            decimal retVal = basePrice * Multiplier * (1 - specialRateDiscount);

            if (IncludesSalesTax)
            {
                retVal = retVal * (1 + Configuration.Current.CurrentSalesTax);
            }

            retVal = retVal / RoundToNearest;
            retVal = Math.Ceiling(retVal);
            retVal = retVal * RoundToNearest;
            return retVal;

            //return Math.Ceiling(basePrice * Multiplier * (1 - specialRateDiscount) / RoundToNearest) * RoundToNearest;
        }

    }
}
