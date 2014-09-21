using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using RussLibrary;

namespace SBMLibrary
{
    public class ActiveInventoryObject : DependencyObject
    {
        public decimal GetTotalPrice(PricingModelObject SelectedPricingModel)
        {
            if (SelectedPricingModel == null)
            {
                return SellingPrice *  Quantity - Discount;
            }
            else
            {
                return SelectedPricingModel.GetSalePrice(SellingPrice, WholeSalePrice + AdditionalOverhead, 0) * Quantity - Discount;
            }
        }
        public decimal GetPriceEach(PricingModelObject SelectedPricingModel)
        {
            if (SelectedPricingModel == null)
            {
                return SellingPrice - (Discount / Quantity);
            }
            else
            {
                return SelectedPricingModel.GetSalePrice(SellingPrice, WholeSalePrice + AdditionalOverhead, 0) - (Discount / Quantity);
            }
        }
        public event EventHandler TotalDollarChanged;

        static void OnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ActiveInventoryObject me = sender as ActiveInventoryObject;
            if (me != null)
            {
                if (e.OldValue != e.NewValue)
                {
                    me.Changed = true;
                    if (e.Property == QuantityProperty)
                    {
                        if (e.OldValue is decimal)
                        {
                            decimal oldValue = (decimal)e.OldValue;
                            decimal newValue = (decimal)e.NewValue;
                            if (Math.Abs(oldValue) == Math.Abs(newValue))
                            {
                                return;
                            }
                        }
                        else if (e.OldValue is int)
                        {
                            int oldValue = (int)e.OldValue;
                            int newValue = (int)e.NewValue;
                            if (Math.Abs(oldValue) == Math.Abs(newValue))
                            {
                                return;
                            }
                        }
                    }
                    if (e.Property == QuantityProperty
                        || e.Property == DiscountProperty || e.Property == SellingPriceProperty 
                        || e.Property == WholeSalePriceProperty || e.Property == AdditionalOverheadProperty)
                    {

                        
                        if (me.TotalDollarChanged != null)
                        {
                            me.TotalDollarChanged(me, EventArgs.Empty);
                        }
                    }
                }
            }
        }

        static void OnUPCChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ActiveInventoryObject me = sender as ActiveInventoryObject;
            if (me != null)
            {
                if (me.UPCChanged != null)
                {
                    me.UPCChanged(me, new ItemChangedEventArgs(e.OldValue, e.NewValue));
                }

            }
            OnChanged(sender, e);
        }
        static object OnCoerceUPC(DependencyObject sender, object obj)
        {

            return Configuration.ProcessUPC(obj as string);

        }
        public static readonly DependencyProperty UPCProperty =
            DependencyProperty.Register("UPC", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnUPCChanged), new CoerceValueCallback(OnCoerceUPC)));
        [ByteArray]
        public string UPC
        {
            get
            {
                return (string)this.UIThreadGetValue(UPCProperty);
            }
            set
            {
                this.UIThreadSetValue(UPCProperty, value);
            }
        }


        public static readonly DependencyProperty IsModelKitProperty =
           DependencyProperty.Register("IsModelKit", typeof(bool),
           typeof(ActiveInventoryObject));
        [ByteArray]
        public bool IsModelKit
        {
            get
            {
                return (bool)this.UIThreadGetValue(IsModelKitProperty);
            }
            set
            {
                this.UIThreadSetValue(IsModelKitProperty, value);
            }
        }


        public static readonly DependencyProperty TotalAmountProperty =
            DependencyProperty.Register("TotalAmount", typeof(decimal),
            typeof(ActiveInventoryObject));
        
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

        static void OnTotalAmountAffected(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ActiveInventoryObject me = sender as ActiveInventoryObject;
            if (me != null)
            {
                me.TotalAmount = me.GetTotalPrice(PricingModelObject.GetPricingModel(Configuration.Current.CurrentPricingModel));
                OnChanged(sender, e);
            }
        }

        //public static readonly DependencyProperty DiscountRateLevelProperty =
        //    DependencyProperty.Register("DiscountRateLevel", typeof(decimal),
        //    typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        //[ByteArray]
        //public decimal DiscountRateLevel
        //{
        //    get
        //    {
        //        return (decimal)this.UIThreadGetValue(DiscountRateLevelProperty);
        //    }
        //    set
        //    {
        //        this.UIThreadSetValue(DiscountRateLevelProperty, value);
        //    }
        //}

        public static readonly DependencyProperty DiscountProperty =
            DependencyProperty.Register("Discount", typeof(decimal),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        [ByteArray]
        public decimal Discount
        {
            get
            {
                return (decimal)this.UIThreadGetValue(DiscountProperty);
            }
            set
            {
                this.UIThreadSetValue(DiscountProperty, value);
            }
        }




        public static readonly DependencyProperty SellingPriceProperty =
            DependencyProperty.Register("SellingPrice", typeof(decimal),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        [ByteArray]
        public decimal SellingPrice
        {
            get
            {
                return (decimal)this.UIThreadGetValue(SellingPriceProperty);
            }
            set
            {
                this.UIThreadSetValue(SellingPriceProperty, value);
            }
        }
        

        public static readonly DependencyProperty ProductIDProperty =
            DependencyProperty.Register("ProductID", typeof(int),
            typeof(ActiveInventoryObject));
        [ByteArray]
        public int ProductID
        {
            get
            {
                return (int)this.UIThreadGetValue(ProductIDProperty);
            }
            set
            {
                this.UIThreadSetValue(ProductIDProperty, value);
            }
        }


        public static readonly DependencyProperty DistributorProperty =
            DependencyProperty.Register("Distributor", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Distributor
        {
            get
            {
                return (string)this.UIThreadGetValue(DistributorProperty);
            }
            set
            {
                this.UIThreadSetValue(DistributorProperty, value);
            }
        }


        public event EventHandler<ItemChangedEventArgs> SKUChanged;

        public event EventHandler<ItemChangedEventArgs> UPCChanged;



        public static readonly DependencyProperty MetadataProperty =
            DependencyProperty.Register("Metadata", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Metadata
        {
            get
            {
                return (string)this.UIThreadGetValue(MetadataProperty);
            }
            set
            {
                this.UIThreadSetValue(MetadataProperty, value);
            }
        }



        public static readonly DependencyProperty ChangedProperty =
            DependencyProperty.Register("Changed", typeof(bool),
            typeof(ActiveInventoryObject));

        public bool Changed
        {
            get
            {
                return (bool)this.UIThreadGetValue(ChangedProperty);
            }
            set
            {
                this.UIThreadSetValue(ChangedProperty, value);
            }
        }

        public static readonly DependencyProperty PictureURLProperty =
            DependencyProperty.Register("PictureURL", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string PictureURL
        {
            get
            {
                return (string)this.UIThreadGetValue(PictureURLProperty);
            }
            set
            {
                this.UIThreadSetValue(PictureURLProperty, value);
            }
        }
        public void SubscribeToChangeEvents(EventHandler<ItemChangedEventArgs> UPCChangedEvent, EventHandler<ItemChangedEventArgs> SKUChangedEvent)
        {
            UPCChanged += UPCChangedEvent;
            SKUChanged += SKUChangedEvent;
        }
        public void UnSubscribeToChangeEvents(EventHandler<ItemChangedEventArgs> UPCChangedEvent, EventHandler<ItemChangedEventArgs> SKUChangedEvent)
        {
            UPCChanged -= UPCChangedEvent;
            SKUChanged -= SKUChangedEvent;
        }
        static void OnSKUChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ActiveInventoryObject me = sender as ActiveInventoryObject;
            if (me != null)
            {
                if (me.SKUChanged != null)
                {
                    me.SKUChanged(me, new ItemChangedEventArgs(e.OldValue, e.NewValue));
                }

            }
            OnChanged(sender, e);
        }
        public static readonly DependencyProperty SKUProperty =
            DependencyProperty.Register("SKU", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnSKUChanged));
        [ByteArray]
        public string SKU
        {
            get
            {
                return (string)this.UIThreadGetValue(SKUProperty);
            }
            set
            {
                this.UIThreadSetValue(SKUProperty, value);
            }
        }

        //[ByteArray]
        //public bool Uploaded { get; set; }


        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
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


        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Model
        {
            get
            {
                return (string)this.UIThreadGetValue(ModelProperty);
            }
            set
            {
                this.UIThreadSetValue(ModelProperty, value);
            }
        }

        [ByteArray]
        public InventorySource Source { get; set; }

        public static readonly DependencyProperty DescriptionShortProperty =
            DependencyProperty.Register("DescriptionShort", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string DescriptionShort
        {
            get
            {
                return (string)this.UIThreadGetValue(DescriptionShortProperty);
            }
            set
            {
                this.UIThreadSetValue(DescriptionShortProperty, value);
            }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Description
        {
            get
            {
                return (string)this.UIThreadGetValue(DescriptionProperty);
            }
            set
            {
                this.UIThreadSetValue(DescriptionProperty, value);
            }
        }



        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(int),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        [ByteArray, NoOverlayWhenZero]
        public int Quantity
        {
            get
            {
                return (int)this.UIThreadGetValue(QuantityProperty);
            }
            set
            {
                this.UIThreadSetValue(QuantityProperty, value);
            }
        }




        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(decimal),
            typeof(ActiveInventoryObject));

        public decimal Price
        {
            get
            {
                return (decimal)this.UIThreadGetValue(PriceProperty);
            }
            set
            {
                this.UIThreadSetValue(PriceProperty, value);
            }
        }




        public static readonly DependencyProperty WholeSalePriceProperty =
            DependencyProperty.Register("WholeSalePrice", typeof(decimal),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        [ByteArray]
        public decimal WholeSalePrice
        {
            get
            {
                return (decimal)this.UIThreadGetValue(WholeSalePriceProperty);
            }
            set
            {
                this.UIThreadSetValue(WholeSalePriceProperty, value);
            }
        }




        public static readonly DependencyProperty MSRPProperty =
            DependencyProperty.Register("MSRP", typeof(decimal),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        [ByteArray]
        public decimal MSRP
        {
            get
            {
                return (decimal)this.UIThreadGetValue(MSRPProperty);
            }
            set
            {
                this.UIThreadSetValue(MSRPProperty, value);
            }
        }




        public static readonly DependencyProperty AdditionalOverheadProperty =
            DependencyProperty.Register("AdditionalOverhead", typeof(decimal),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnTotalAmountAffected));
        [ByteArray]
        public decimal AdditionalOverhead
        {
            get
            {
                return (decimal)this.UIThreadGetValue(AdditionalOverheadProperty);
            }
            set
            {
                this.UIThreadSetValue(AdditionalOverheadProperty, value);
            }
        }



        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("Category", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Category
        {
            get
            {
                return (string)this.UIThreadGetValue(CategoryProperty);
            }
            set
            {
                this.UIThreadSetValue(CategoryProperty, value);
            }
        }


        public static readonly DependencyProperty KeywordsProperty =
            DependencyProperty.Register("Keywords", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Keywords
        {
            get
            {
                return (string)this.UIThreadGetValue(KeywordsProperty);
            }
            set
            {
                this.UIThreadSetValue(KeywordsProperty, value);
            }
        }




        public static readonly DependencyProperty ManufacturerProperty =
            DependencyProperty.Register("Manufacturer", typeof(string),
            typeof(ActiveInventoryObject), new PropertyMetadata(OnChanged));
        [ByteArray]
        public string Manufacturer
        {
            get
            {
                return (string)this.UIThreadGetValue(ManufacturerProperty);
            }
            set
            {
                this.UIThreadSetValue(ManufacturerProperty, value);
            }
        }

        public ActiveInventoryObject Original { get; private set; }
        public void AcceptChanges()
        {
            Changed = false;
            ActiveInventoryObject aio = new ActiveInventoryObject();
            aio.CopyProperties(this);
            Original = aio;
            
        }
        public void RejectChanges()
        {
            if (Original != null)
            {
                this.CopyProperties(Original);
            }
            Changed = false;
        }
    }
}
