   M S B A M L   `   `   `  ���� S  ORussLibrary.Controls, Version=1.0.0.38730, Culture=neutral, PublicKeyToken=nullyPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  Y@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  N JSBMLibrary.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters %   SBMLibrary.Controls.PointOfSale   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     iValueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     @d2http://schemas.microsoft.com/expression/blend/2008     JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $��uc��$	��300��  � 	Resources  <   6RussLibrary.Controls.ValueConverters.CurrencyFormatter   CurrencyFormatterC   =RussLibrary.Controls.ValueConverters.PositiveNegativeColoring  PositiveNegativeColoring9  3SBMLibrary.Controls.ValueConverters.OrderEntryTotal  OrderEntryTotal��%-   &	        &	      &	 
           .��]� .+�� $	��Top=� � RowDefinitions �� �� �� ��  � ColumnDefinitions �� �� �� �� .+��� $��1��$��0��$��Right=�$��Receipt ID:��$
��Bold"��� $��1��$��1��$��Center=����� *	ReceiptID+ �� Mode$ OneWay=� �� ElementName$ uc���� $��0��$��0�� �� Orientation$ 
Horizontal=�.+��� $��Center=�$��Pricing Model:��$
��Bold"��� $	��150��$��Stretch=�
���z��� �� DisplayMemberPath$
 Name��$��14(�$
��Bold"�
��� d ����� *PricingModels+$ OneWay=�$ uc�� �� SelectedItem ��  �� Path$ SelectedPricingModel�$ TwoWay=�$ uc���� $��1��$��0��$ 
Horizontal=�.+��� $��Center=�$��State:��$
��Bold"��� $��50������ $ USState�$ uc��$ TwoWay=��� $��0��$��4��$��1��$��2��$	��170��$��Center=�$��Center=����� *Logo+$ OneWay=�$ uc���� $��0��$��2��$��Right=�$��Center=�$��	Quantity:���� $��0��$��3������ $ Quantity�$ TwoWay=�$ uc���� $��1��$��2��$ 
Horizontal=��� $��1��$��2��$��Right=�$��Center=�$��UPC or SKU:���� -   $��	txtSearch��$��1��$��3������ $ 	SearchKey�$ TwoWay=�$ uc��	 �� UpdateSourceTrigger$	 PropertyChanged=��� -   $��2��$��3��$	��Add��
 �� 	IsDefault
 . ]� $��Bottom=�.+��� -   $��Cancel Sale��$
��Left=�$��5,5,5,5q��� -   $
��Post��$��Right=�$��26(�$
��Bold"�$��5,5,5,5q��� � $��Bottom=� �� �� �� �� �� �� ��  �� �� �� �� .+��� $��0��$��2��$��Right=�$��Total:��$
��Bold"��� $��0��$��3��$
��Left=�$��Center=����� *Total+$ uc��$ OneWay=� �� 	Converter# [  �� $��1��$��2��$��Right=�$
��Tax:��$
��Bold"��� $��1��$��3��$
��Left=�$��Center=����� *
TotalTax+$ uc��$ OneWay=�# [  �� $��2��$��2��$��Right=�$��Total:��$
��Bold"��� $��2��$��3��$
��Left=�$��Center=����� *TotalTaxTotal+$ uc��$ OneWay=�# [  �� $��3��$��2��$��Right=�$��Credit Tendered:��$
��Bold"�%   RussLibrary.Controls.DecimalBox  $��3��$��3��   DisplayFormat$ C��   Value �� $ CreditTendered�$ TwoWay=�$ uc��$	 PropertyChanged=��� $��4��$��2��$��Right=�$��Cash Tendered:��$
��Bold"�  $��4��$��3��$ C�� �� $ CashTendered�$ TwoWay=�$ uc��$	 PropertyChanged=��� $��5��$��2��$��Right=�$��Check Tendered:��$
��Bold"�  $��5��$��3��$ C�� �� $ CheckTendered�$ TwoWay=�$ uc��$	 PropertyChanged=��� $��6��$��2��$��Right=�$��Center=�$��Cash Due Back:��$
��Bold"��� $��6��$��3��$
��Left=�$��Center=�$��28(�$
��Bold"����� *	CashDue+$ OneWay=�# [ $ uc������ *	CashDue+$ uc��$ OneWay=�# [  �� $	��Top=�$
��Auto=�.���� $��Stretch=����� *
Activity+$ OneWay=�$ uc�� �� View �� .P���  �� Width$ 70�� �� CellTemplate �� .R��� $ 
Horizontal=�.+��� -   $��X������ �� $	 120�� �� HeaderTemplate �� .R��� $��Center=�$
��Bold"�$	��UPC�� �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *UPC+�� $	 120�� �� .R��� $��Center=�$
��Bold"�$	��SKU�� �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *SKU+�� $	 220�� �� .R��� $��Center=�$
��Bold"�$
��Item�� �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *Name+�� -   PART_QuantityCol��$ 70�� �� .R��� $��Center=�$
��Bold"�$��Quantity�� �� .R��� $ 
Horizontal=�.+�  $��2q�$��Center=����� *Width+$ PART_QuantityCol�� �� $ Quantity�$ TwoWay=��� $	 160�� �� .R��� $��Center=�$
��Bold"�$��
Price Each�� �� .R��� $ 
Horizontal=�.+��� $��2q�$��Right=�$��Center=����� *Price+$ OneWay=�# [  �� -   PART_DiscountCol��$	 160�� �� .R��� $��Center=�$
��Bold"�$��Discount�� �� .R��� $ 
Horizontal=�.+�  $��2q�$��Center=�$ C������ *Width+$ PART_DiscountCol�� �� $ Discount�$ TwoWay=��� $	 160�� �� .R��� $��Center=�$
��Bold"�$��Total�� �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *TotalAmount+$ OneWay=�# [  