using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SBMLibrary.Controls.ValueConverters
{
    [ValueConversion(typeof(ActiveInventoryObject), typeof(string))]
    public class OrderEntryTotal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ActiveInventoryObject item = value as ActiveInventoryObject;
            if (item != null)
            {

                decimal retVal = item.GetTotalPrice(PricingModelObject.GetPricingModel(Configuration.Current.CurrentPricingModel)) * item.Quantity;
                return retVal.ToString("C", System.Globalization.CultureInfo.CurrentUICulture);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
