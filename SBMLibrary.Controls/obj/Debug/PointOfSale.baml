   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullyPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  5      Y@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5      O KSBMLibrary.Controls, Version=0.2.10.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters 5      %   SBMLibrary.Controls.PointOfSale   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      iValueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     5      Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        $��uc��5	      $	��300��5
        � 	Resources  5      <   6RussLibrary.Controls.ValueConverters.CurrencyFormatter   CurrencyFormatterC   =RussLibrary.Controls.ValueConverters.PositiveNegativeColoring  PositiveNegativeColoring9  3SBMLibrary.Controls.ValueConverters.OrderEntryTotal  OrderEntryTotal��%W   &	        &	      &	 &       5   
   6)     5   
   60     5   
   6'   5      .��5      ]� .+�5   
   � $	��Top=�6    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5!      �� $��1��6   $��0��5"      $��Right=�5#      $��Receipt ID:��5$      $
��Bold"�5%      �� 5&      $��1��6   $��1��5'      $��Center=�5(      ��5)      �� *	ReceiptID+ �� Mode$ OneWay=� �� ElementName$ uc���� 5-      $��0��6   $��0��5.       �� Orientation$ 
Horizontal=�5/      .+�50      �� $��Center=�6   $��Pricing Model:��51      $
��Bold"�52      �� 53      $	��150��6   $��Stretch=�54      
���z��� �� DisplayMemberPath$
 Name��56      $��14(�57      $
��Bold"�58      
��� d ���5:      �� *PricingModels+$ OneWay=�$ uc�� �� SelectedItem 5=      ��  �� Path$ SelectedPricingModel�$ TwoWay=�$ uc��5@      �� 5A      $��1��6   $��0��5B      $ 
Horizontal=�5C      .+�5D      �� $��Center=�6   $��State:��5E      $
��Bold"�5F      �� 5G      $��50��6   ��6(   �� $ USState�$ uc��$ TwoWay=�5H      �� 5J      $��0��6   $��2��5K      $��Right=�5L      $��Center=�5M      $��	Quantity:��5N      �� 5O      $��0��6   $��3��5P      ��5Q      �� $ Quantity�$ TwoWay=�$ uc���� 5T      $��1��6   $��2��5U      $ 
Horizontal=�5V      �� 5X      $��1��6   $��2��5Y      $��Right=�5Z      $��Center=�5[      $��UPC or SKU:��5\      �� 5]      -   5        $��	txtSearch��5]      $��1��5^      $��3��5_      ��5a      �� $ 	SearchKey�$ TwoWay=�$ uc��	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5e      -   5        $��2��5e      $��3��5f      $	��Add��5h      
 �� 	IsDefault
 . 5i      5j      ]� 5k   
   $��Bottom=�6   .+�5m      �� -   5        $��Cancel Sale��5n      $
��Left=�5o      $��5,5,5,5q�5p      �� 5q      -   5        $
��Post��5r      $��Right=�5s      $��26(�5t      $
��Bold"�5u      $��5,5,5,5q�5v      �� 5w      5x      � 5y   
   $��Bottom=�6    5z      �� 5{      �� 5|      �� 5}      �� 5~      �� 5      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��4��5�      $��0��5�      $��2��5�      $	��170��5�      $��Center=�5�      $��Center=�5�      ��5�      �� *Logo+$ OneWay=�$ uc���� 5�      $��0��6   $��2��5�      $��Right=�5�      $��$ Discount:��5�      $
��Bold"�5�      %   RussLibrary.Controls.DecimalBox  5�      $��0��6   $��3��5�         DisplayFormat$ C��5�         Value 5�      �� $ DiscountAmount�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�      $��1��6   $��2��5�      $��Right=�5�      $��Total:��5�      $
��Bold"�5�      �� 5�      $��1��6   $��3��5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *Total+$ uc��$ OneWay=� �� 	Converter# [  �� 5�      $��2��6   $��2��5�      $��Right=�5�      $
��Tax:��5�      $
��Bold"�5�      �� 5�      $��2��6   $��3��5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *
TotalTax+$ uc��$ OneWay=�# [  �� 5�      $��3��6   $��2��5�      $��Right=�5�      $��Total:��5�      $
��Bold"�5�      �� 5�      $��3��6   $��3��5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *TotalTaxTotal+$ uc��$ OneWay=�# [  �� 5�      $��5��6   $��2��5�      $��Right=�5�      $��Credit Tendered:��5�      $
��Bold"�5�        5�      $��5��6   $��3��5�      $ C��5�       5�      �� $ CreditTendered�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�      $��4��6   $��2��5�      $��Right=�5�      $��Cash Tendered:��5�      $��18(�5�      $
��Bold"�5�        5�      $��4��6   $��3��5�      $��Center=�5�      $ C��5�      $��18(�5�       5�      �� $ CashTendered�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�      $��6��6   $��2��5�      $��Right=�5�      $��Check Tendered:��5�      $
��Bold"�5�        5�      $��6��6   $��3��5�      $ C��5�       5�      �� $ CheckTendered�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�      $��7��6   $��2��5�      $��Right=�5�      $��Center=�5�      $��Cash Due Back:��5�      $
��Bold"�5�      �� 5      $��7��6   $��3��5     $
��Left=�5     $��Center=�5     $��28(�5     $
��Bold"�5     ��5     �� *	CashDue+$ OneWay=�# [ $ uc����5
     �� *	CashDue+$ uc��$ OneWay=�# [  5     �� 5  
   $	��Top=�6   $
��Auto=�6,   .��5     �� $��Stretch=�6   ��63   �� *
Activity+$ OneWay=�$ uc�� �� View 5     �� 5     .P�5     ��  �� Width$ 70��6)    �� CellTemplate 5     �� 5  "   .R�5  &   �� $ 
Horizontal=�61   .+�5  *   �� -   5        $��X��5  1   ��5  1   �� 5  1   5  '   5  #   5      �� 5!     $	 120��6)    �� HeaderTemplate 5#     �� 5$  "   .R�5%  &   �� $��Center=�60   $
��Bold"�5&  0   $	��UPC��5'  0   5(  #    5+     �� 5,  "   .R�5-  &   �� $ 
Horizontal=�61   .+�5.  *   �� $��2q�64   $��Center=�5/  4   ��50  4   �� *UPC+51  '   52  #   54     �� 56     $	 120��6)    58     �� 59  "   .R�5:  &   �� $��Center=�60   $
��Bold"�5;  0   $	��SKU��5<  0   5=  #    5@     �� 5A  "   .R�5B  &   �� $ 
Horizontal=�61   .+�5C  *   �� $��2q�64   $��Center=�5D  4   ��5E  4   �� *SKU+5F  '   5G  #   5I     �� 5J     $	 220��6)    5L     �� 5M  "   .R�5N  &   �� $��Center=�60   $
��Bold"�5O  0   $
��Item��5P  0   5Q  #    5T     �� 5U  "   .R�5V  &   �� $ 
Horizontal=�61   .+�5W  *   �� $��2q�64   $��Center=�5X  4   ��5Y  4   �� *Name+5Z  '   5[  #   5]     �� 5`     -   5        PART_QuantityCol��$ 70��5`  C    5b     �� 5c  "   .R�5d  &   �� $��Center=�60   $
��Bold"�5e  0   $��Quantity��5f  0   5g  #    5j     �� 5k  "   .R�5l  &   �� $ 
Horizontal=�61   .+�5m  *     $��2q�5o  9   $��Center=�5p  9   ��5m  9   �� *Width+$ PART_QuantityCol�� 5q  9   �� $ Quantity�$ TwoWay=�5s  '   5t  #   5v     �� 5z     $	 160��6)    5|     �� 5}  "   .R�5~  &   �� $��Center=�60   $
��Bold"�5  0   $��
Price Each��5�  0   5�  #    5�     �� 5�  "   .R�5�  &   �� $ 
Horizontal=�61   .+�5�  *   �� $��2q�64   $��Right=�5�  4   $��Center=�5�  4   ��5�  4   �� *Price+$ OneWay=�# [  5�  '   5�  #   5�     �� 5�     -   5        PART_DiscountCol��$	 160��5�  C    5�     �� 5�  "   .R�5�  &   �� $��Center=�60   $
��Bold"�5�  0   $��Discount��5�  0   5�  #    5�     �� 5�  "   .R�5�  &   �� $ 
Horizontal=�61   .+�5�  *     $��2q�5�  9   $��Center=�5�  9   $ C��5�  9   ��5�  9   �� *Width+$ PART_DiscountCol�� 5�  9   �� $ Discount�$ TwoWay=�5�  '   5�  #   5�     �� 5�     $	 160��6)    5�     �� 5�  "   .R�5�  &   �� $��Center=�60   $
��Bold"�5�  0   $��Total��5�  0   5�  #    5�     �� 5�  "   .R�5�  &   �� $ 
Horizontal=�61   .+�5�  *   �� $��2q�64   $��Center=�5�  4   ��5�  4   �� *TotalAmount+$ OneWay=�# [  5�  '   5�  #   5�     5�     5�     5�     5�     5�     