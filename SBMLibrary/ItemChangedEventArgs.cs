using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBMLibrary
{
    public class ItemChangedEventArgs : EventArgs
    {
        public ItemChangedEventArgs(object oldValue, object newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;

        }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
