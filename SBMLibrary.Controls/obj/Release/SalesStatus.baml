   M S B A M L   `   `   `  ���� S  ORussLibrary.Controls, Version=1.0.0.38730, Culture=neutral, PublicKeyToken=nullyPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  Y@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls   SBMLibrary.Controls%   SBMLibrary.Controls.SalesStatus   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     iValueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     -   $��uc��
�������  � 	Resources  <   6RussLibrary.Controls.ValueConverters.CurrencyFormatter   CurrencyFormatter��%   &	          .���� 
�����_�
����+��$��2q����� $��18(�$��Point of Sale Summary��$
��Bold"�.���  � RowDefinitions �� �� �� �� �� �� �� �� ��  � ColumnDefinitions �� �� .+��� $��0��$��Center=�$��0��
���`���$��Current Tax Rate:��$
��Bold"�%   RussLibrary.Controls.DecimalBox  $��0��$��Center=�$��1��   DisplayFormat$ 0.000%��   Value ��  �� Path$ SalesTax� �� Mode$ TwoWay=� �� ElementName$ uc���� $��1��$��Center=�$��0��
���`���$��Starting Cash:��$
��Bold"�  $��1��$��1��$��Center=�$ C�� �� $ StartingCash�$ TwoWay=�$ uc���� $��2��$��Center=�$��0��
���`���$��Total Cash Sales:��$
��Bold"��� $��2��$��1��$��Center=����� *TotalCashSales+$ OneWay=�$ uc�� �� 	Converter# [  �� $��3��$��Center=�$��0��
���`���$��Total Check Sales:��$
��Bold"��� $��3��$��1��$��Center=����� *TotalCheckSales+$ OneWay=�$ uc��# [  �� $��4��$��Center=�$��0��
���`���$��Total Credit Sales:��$
��Bold"��� $��4��$��1��$��Center=����� *TotalCreditSales+$ OneWay=�$ uc��# [  �� $��5��$��Center=�$��0��
���`���$��Total Taxes Assessed:��$
��Bold"��� $��5��$��1��$��Center=����� *TotalTaxesAssesed+$ OneWay=�$ uc��# [  �� $��6��$��Center=�$��0��
���`���$��Total Profit:��$
��Bold"��� $��6��$��1��$��Center=����� *TotalProfit+$ OneWay=�$ uc��# [  �� $��7��$��Center=�$��0��
���`���$��Expected Cash in Hand:��$
��Bold"��� $��7��$��1��$��Center=����� *ExpectedCash+$ OneWay=�$ uc��# [  �� -   $��8��$��1��$��	Close Day��