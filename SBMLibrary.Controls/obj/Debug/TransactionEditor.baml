   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5      J FRussLibrary, Version=1.0.0.33811, Culture=neutral, PublicKeyToken=nullN6clr-namespace:RussLibrary.Helpers;assembly=RussLibraryRussLibrary.Helpers 5      O KSBMLibrary.Controls, Version=0.2.10.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters 5      yPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  5	      +   %SBMLibrary.Controls.TransactionEditor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ihelper6clr-namespace:RussLibrary.Helpers;assembly=RussLibrary     5      JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ivalueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     5	      -   5        $��uc��5
        � 	Resources  5      @  :SBMLibrary.Controls.ValueConverters.BreakEvenCostConverter   BreakEvenCostConverter<   6RussLibrary.Controls.ValueConverters.CurrencyFormatter  CurrencyFormatter;   5RussLibrary.Controls.ValueConverters.NumericFormatter  NumericFormatterM   GRussLibrary.Controls.ValueConverters.BoolToVisibilityParameterConverter & "BoolToVisibilityParameterConverter��%t   &	        &	      &	 &     &	 9       5   
   6.     5   
   6)     5   
   6(     5   
   6:   5      .��5      ]� .+�5   
   �� $��Right=�6   $	��Top=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $��5,0,15,0q�6   $��Center=�5      $7��1Check Transactions in the prior to close day list��5       d� 	IsChecked 5      ��  �� Path$ UsePreCloseDay� �� Mode$ TwoWay=� �� ElementName$ uc���� 5!      -   5        $
��Save��5"      $��18(�5#      $
��Bold"�5$      5&      �� 5-   
   $��Stretch=�6   ��6/   �� *Transactions+$ OneWay=�$ uc�� �� View 5/      �� 51      .P�52      ��  �� Width$ 70��6%    �� CellTemplate 53      �� 54      .R�55   "   �� $ 
Horizontal=�6-   .+�56   &   �� -   5        $��X��58   -   ��57   -   �� 58   -   5>   #   5?      5A      �� 5C      -   5        PART_ProductIDCol��$	 120��5C   @   .��5E      �� 4  .RussLibrary.Helpers.GridViewColumnHeaderSorter	   SortColumnID$	 	ProductID��6/   
 �� HeaderTemplate
 5G      �� 5H      .R�5I   "   �� .+�5J   &   �� $��Center=�60   $
��Bold"�5K   0   $��
Product ID��5L   0   5N   #   5O       5R      �� 5S      .R�5T   "   �� .+�5U   &   �� $��Center=�6.   $��2q�5V   .   ��5W   .   �� $ 	ProductID�$ TwoWay=�5Z   #   5[      5]      �� 5a      -   5        PART_UPCCol��$	 120��5a   :   .��5c      �� $		 UPC��6/   
 5d      �� 5e      .R�5f   "   �� .+�5g   &   �� $��Center=�60   $
��Bold"�5h   0   $	��UPC��5i   0   5k   #   5l       5o      �� 5p      .R�5q   "   �� .+�5r   &   �� $��Center=�5u   .   $��2q�5v   .   ��5r   .   �� *Width+$ OneWay=�$ PART_UPCCol����5w   .   �� $	 UPC�$ TwoWay=�5z   #   5{      5}      �� 5�      -   5        PART_SKUCol��$	 120��5�   :   .��5�      �� $		 SKU��6/   
 5�      �� 5�      .R�5�   "   �� .+�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $	��SKU��5�   0   5�   #   5�       5�      �� 5�      .R�5�   "   �� .+�5�   &   �� $��Center=�5�   .   $��2q�5�   .   ��5�   .   �� *Width+$ OneWay=�$ PART_SKUCol����5�   .   �� $	 SKU�$ TwoWay=�5�   #   5�      5�      �� 5�      -   5        PART_DateCol��$	 220��5�   ;   .��5�      �� $	 TransactionTime��6/   
 5�      �� 5�      .R�5�   "   �� $��Center=�6-   .+�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $��Transaction Time��5�   0   5�   #   5�       5�      �� 5�      .R�5�   "   �� $��2,0,2,0q�6,   $��Center=�5�   ,   ��5�   ,   �� $ TransactionTime�$ TwoWay=�5�      5�      �� 5�      -   5        PART_QuantityCol��$	 120��5�   ?   .��5�      �� $	 Quantity��6/   
 5�      �� 5�      .R�5�   "   �� .+�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $��Quantity��5�   0   5�   #   5�       5�      �� 5�      .R�5�   "   �� $��Right=�6,   $��Center=�5�   ,   $��18(�5�   ,   $��Black"�5�   ,   
��� � ���5�   ,   �� *
Quantity+5�      5�      �� 5�      -	   5        PART_MSRPCol��$	 120��5�   ;   .��5�      �� $
	 MSRP��6/   
 5�      �� 5�      .R�5�   "   �� $��Center=�6-   .+�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $��	ReceiptID��5�   0   5�   #   5�       5�      �� 5�      .R�5�   "   �� $��Stretch=�6-   .+�5�   &   �� $��Stretch=�5�   0    �� Padding$ 2q�5�   0   ��5�   0   �� *Width+$ OneWay=�$ PART_MSRPCol����5�   0   �� *	ReceiptID+5�   #   5�      5�      �� 5�      -
   5        PART_DiscountCol��$	 120��5�   ?   .��5�      �� $	 WholeSalePrice��6/   
 5�      �� 5�      .R�5   "   �� $��Center=�6-   .+�5  &   �� $��Center=�60   $
��Bold"�5  0   $��Discount��5  0   5  #   5      5	     �� 5
     .R�5  "   �� $��Stretch=�6-   .+�5  &   �� $��Stretch=�5  0   $ 2q�5  0   ��5  0   �� *Width+$ OneWay=�$ PART_DiscountCol����5  0   �� *
Discount+ �� 	Converter# [ 5  #   5     5     �� 5     -   5        PART_WholeSaleCol��$	 120��5  @   .��5     �� $	 ExportedToWeb��6/   
 5     �� 5      .R�5!  "   �� $��Center=�6-   .+�5"  &   �� $��Center=�60   $
��Bold"�5#  0   $��Exported to Web��5$  0   5'  #   5(      5+     �� 5,     .R�5-  "   �� $��Stretch=�6-   .+�56  &   ��  6/   �� $ ExportedToWeb�$ TwoWay=�58  #   59     5;     5>     5@     5B     5C     