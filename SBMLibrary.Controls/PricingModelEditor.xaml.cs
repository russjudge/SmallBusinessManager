using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SBMLibrary.Controls
{
    /// <summary>
    /// Interaction logic for PricingModelEditor.xaml
    /// </summary>
    public partial class PricingModelEditor : UserControl
    {
        public PricingModelEditor()
        {
            PricingSelections = new ObservableCollection<BasePriceSelection>();
            PricingSelections.Add(BasePriceSelection.BasedOnMSRP);
            PricingSelections.Add(BasePriceSelection.BasedOnBreakEven);
            InitializeComponent();
        }
        public ObservableCollection<PricingModelObject> Models
        {
            get
            {
                return PricingModelObject.Models;
            }
        }
        public ObservableCollection<BasePriceSelection> PricingSelections { get; private set; }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            Models.Add(new PricingModelObject());
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                PricingModelObject pmo = btn.CommandParameter as PricingModelObject;
                if (pmo != null)
                {
                    if (Models.Contains(pmo))
                    {
                        Models.Remove(pmo);
                    }
                }
            }
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            PricingModelObject.Save();
        }
    }
}
