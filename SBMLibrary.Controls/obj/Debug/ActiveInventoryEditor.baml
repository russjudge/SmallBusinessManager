   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5      J FRussLibrary, Version=1.0.0.33811, Culture=neutral, PublicKeyToken=nullN6clr-namespace:RussLibrary.Helpers;assembly=RussLibraryRussLibrary.Helpers 5      O KSBMLibrary.Controls, Version=0.2.10.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters 5      yPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  5	      /   )SBMLibrary.Controls.ActiveInventoryEditor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ihelper6clr-namespace:RussLibrary.Helpers;assembly=RussLibrary     5      JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ivalueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     5	      -   5        $��uc��5
        � 	Resources  5         lvStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value@  :SBMLibrary.Controls.ValueConverters.BreakEvenCostConverter  BreakEvenCostConverter<   6RussLibrary.Controls.ValueConverters.CurrencyFormatter  CurrencyFormatter;   5RussLibrary.Controls.ValueConverters.NumericFormatter  NumericFormatterM   GRussLibrary.Controls.ValueConverters.BoolToVisibilityParameterConverter & "BoolToVisibilityParameterConverter��%�  &	        &	 t    &	 �    &	 �    &	 �    �� 5   
   " ��6    .�5      ��  �@$�IsVirtualizing . 6F   �� 5       �@$�VirtualizationMode$ 	Recycling=�6J   �� 5      " �@��IsDeferredScrollingEnabled . 6H    5      �� 5       6   �� *	IsLoading+ True6<   .a�5      ��  �@�Cursor$
 Wait��68   �� 5       � ��
 �����6<   5      5        5   
   6.     5   
   6)     5   
   6(     5   
   6:   5      .��5      ]� .+�5   
   �� $��Right=�6   $	��Top=�5        �� Orientation$ 
Horizontal=�5!      .+�5"      �� -   5        $
��Save��5#      $��18(�5$      $
��Bold"�5%      5&      � 5(   
   $��Bottom=�6    � RowDefinitions 5)      �� 5*      �� 5+      	 � ColumnDefinitions	 5-      �� 5.      $��3* �6#   �� 5/      �� 50      .+�52      �� $��0��6   $��1��53      $��Right=�54      $��Total Invested:��55      $��Black"�56      �� 57      $��0��6   $��2��58      $��Right=�59      $��Center=�5:      ��5;      �� *Inventory.TotalInvested+
 �� Mode$
 OneWay=� �� ElementName$ uc�� �� 	Converter# [ 5?      � 5A   
   $	��Top=�6    5B      �� 5C      $��28 �6    	 5E      �� 5F      $��70 �6#   �� 5G      $	��120 �6#   �� 5H      $	��120 �6#   �� 5I      $	��120 �6#   �� 5J      $	��320 �6#   �� 5K      $	��150 �6#   �� 5L      $	��120 �6#   �� 5M      $	��120 �6#   �� 5N      $	��120 �6#   �� 5O      $	��120 �6#   .+�5R      �� -   5        $��0��5R      $��Reset Filter��5T      ]� 5V      $��2��6   .+�5W      �� -   5        $��16��5W      $��o��5Y      $��Right=�5Z      �� 5[      ��6   ��  �� Path$ 	FilterUPC�$
 TwoWay=�$ uc��5]      ]� 5^      $��3��6   .+�5_      �� -   5        $��16��5_      $��o��5a      $��Right=�5b      �� 5c      ��6   �� $ 	FilterSKU�$
 TwoWay=�$ uc��5e      ]� 5f      $��4��6   .+�5g      �� -   5        $��16��5g      $��o��5i      $��Right=�5j      �� 5k      ��6   �� $ 
FilterName�$
 TwoWay=�$ uc��5m      5s      �� 5t   
   $	��Top=�6   $
��Auto=�6,   .��5v      �� $��Stretch=�6   #���   5z      ��5w      �� *FilteredInventory+$
 OneWay=�$ uc�� �� View 5|      �� 5~      .P�5      ��  �� Width$ 70��6)    �� CellTemplate 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� -   5        $��X��5�   1   ��5�   1   �� 5�   1   �� 5�   *   -   5        $��Details��5�   1   ��5�   1   �� 5�   1   5�   '   5�   #   5�      �� 5�      -	   5        PART_ProductIDCol��$	 120��5�   D   .��5�      �� 4  .RussLibrary.Helpers.GridViewColumnHeaderSorter   SortColumnID$ 	ProductID��63    �� HeaderTemplate 5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��Center=�64   $
��Bold"�5�   4   $��
Product ID��5�   4   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��Center=�62   $��2q�5�   2   ��5�   2   �� $ 	ProductID�$
 TwoWay=�5�   '   5�   #   5�      �� 5�      -
   5        PART_UPCCol��$	 120��5�   >   .��5�      �� $	 UPC��63    5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��Center=�64   $
��Bold"�5�   4   $	��UPC��5�   4   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��Center=�5�   2   $��2q�5�   2   ��5�   2   �� *Width+$
 OneWay=�$ PART_UPCCol����5�   2   �� $	 UPC�$
 TwoWay=�5�   '   5�   #   5�      �� 5�      -   5        PART_SKUCol��$	 120��5�   >   .��5�      �� $	 SKU��63    5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��Center=�64   $
��Bold"�5�   4   $	��SKU��5�   4   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��Center=�5�   2   $��2q�5�   2   ��5�   2   �� *Width+$
 OneWay=�$ PART_SKUCol����5�   2   �� $	 SKU�$
 TwoWay=�5�   '   5�   #   5�      �� 5�      -   5        PART_NameCol��$	 320��5�   ?   .��5�      �� $
 Name��63    5�      �� 5�   "   .R�5�   &   �� $��Center=�61   .+�5�   *   �� $��Center=�64   $
��Bold"�5�   4   $
��Name��5�   4   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� $��Center=�61   .+�5�   *   �� $��Center=�5�   2   $��2q�5   2   ��5�   2   �� *Width+$
 OneWay=�$ PART_NameCol����5  2   �� $
 Name�$
 TwoWay=�5  '   5  #   5     �� 55     -   5        PART_PictureCol��$	 150��55  B   .��56     �� $ DiscountRateLevel��63    57     �� 58  "   .R�59  &   �� $��Center=�61   .+�5?  *   �� $��Center=�64   $
��Bold"�5@  4   $��Selling Price��5A  4   5B  '   5C  #    5F     �� 5G  "   .R�5H  &   �� $ 
Horizontal=�61   .+�5T  *   %   RussLibrary.Controls.DecimalBox     DisplayFormat$ C��69      Value 6K   �� $ SellingPrice�$
 TwoWay=��� 5V  *    �� Padding$ 5,0,5,0q�64   $��	Model Kit��5W  4   y�5X  4   �� *
IsModelKit+$
 OneWay=�# [  �� ConverterParameter$ Visible|Collapsed��5\  '   5]  #   5_     �� 5g     -   5        PART_QuantityCol��$	 120��5g  C   .��5h     �� $ Quantity��63    5i     �� 5j  "   .R�5k  &   �� .+�5l  *   �� $��Center=�64   $
��Bold"�5m  4   $��Quantity��5n  4   5p  '   5q  #    5t     �� 5u  "   .R�5w  &     $��Right=�65   $��Center=�5x  5   $��18(�5y  5   $��Black"�5z  5   
��� � � 5|  5   �� $ Quantity�$
 TwoWay=�5�  #   5�     �� 5�     -   5        PART_MSRPCol��$	 120��5�  ?   .��5�     �� $
 MSRP��63    5�     �� 5�  "   .R�5�  &   �� $��Center=�61   .+�5�  *   �� $��Center=�64   $
��Bold"�5�  4   $
��MSRP��5�  4   5�  '   5�  #    5�     �� 5�  "   .R�5�  &   �� $��Stretch=�61   .+�5�  *   �� $��Stretch=�5�  4   $ 2q�5�  4   ��5�  4   �� *Width+$
 OneWay=�$ PART_MSRPCol����5�  4   �� *MSRP+# [ 5�  '   5�  #   5�     �� 5�     -   5        PART_WholeSaleCol��$	 120��5�  D   .��5�     �� $ WholeSalePrice��63    5�     �� 5�  "   .R�5�  &   �� $��Center=�61   .+�5�  *   �� $��Center=�64   $
��Bold"�5�  4   $��Wholesale Cost��5�  4   5�  '   5�  #    5�     �� 5�  "   .R�5�  &   �� $��Stretch=�61   .+�5�  *   �� $��Stretch=�5�  4   $ 2q�5�  4   ��5�  4   �� *Width+$
 OneWay=�$ PART_WholeSaleCol����5�  4   �� *WholeSalePrice+# [ 5�  '   5�  #   5�     �� 5�     -   5        PART_CostCol��$	 120��5�  ?   .��5�     �� $ WholeSalePrice��63    5�     �� 5�  "   .R�5�  &   �� $��Center=�61   .+�5�  *   �� $��Center=�64   $
��Bold"�5�  4   $��Break-even Cost��5�  4   5�  '   5�  #    5�     �� 5�  "   .R�5�  &   �� $��Stretch=�61   .+�5�  *   �� $��Stretch=�5�  4   $ 2q�5�  4   ��5�  4   �� *Width+$
 OneWay=�$ PART_CostCol����5�  4   �� # [ 5�  '   5�  #   5�     5�     5�     5�     5�     5�     