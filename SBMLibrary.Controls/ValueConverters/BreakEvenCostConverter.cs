using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SBMLibrary.Controls.ValueConverters
{
    [ValueConversion(typeof(ActiveInventoryObject), typeof(string))]
    public class BreakEvenCostConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal retVal = 0;
            ActiveInventoryObject val = value as ActiveInventoryObject;
            if (val != null)
            {
                retVal = val.AdditionalOverhead + val.WholeSalePrice;
            }
            return retVal.ToString("C", System.Globalization.CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
