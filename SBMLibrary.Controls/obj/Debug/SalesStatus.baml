   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullyPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  5      Y@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5       SBMLibrary.Controls%   SBMLibrary.Controls.SalesStatus   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      iValueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     5      Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        $��uc��5      
�������  � 	Resources  5      <   6RussLibrary.Controls.ValueConverters.CurrencyFormatter   CurrencyFormatter��%   &	          5   
   6)   5      .��5      �� 
����+��$��2q�5      
�����_���5   
   �� 5      $��18(�6   $
��Bold"�5      $��Point of Sale Summary��5      .��5   
   �  � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!       � ColumnDefinitions 5#      �� 5$      �� 5%      .+�5'      �� $��0��6   $��0��5(      $��Center=�5)      $��Current Tax Rate:��5*      $
��Bold"�5+      
���`���5,      %   RussLibrary.Controls.DecimalBox  5-      $��0��6   $��1��5.      $��Center=�5/         DisplayFormat$ 0.000%��50         Value 51      ��  �� Path$ SalesTax� �� Mode$ TwoWay=� �� ElementName$ uc���� 55      $��1��6   $��0��56      $��Center=�57      $��Starting Cash:��58      $
��Bold"�59      
���`���5:        5;      $��1��6   $��1��5<      $��Center=�5=      $ C��5>       5?      �� $ StartingCash�$ TwoWay=�$ uc���� 5D      $��2��6   $��0��5E      $��Center=�5F      $��Total Cash Sales:��5G      $
��Bold"�5H      
���`���5I      �� 5J      $��2��6   $��1��5K      $��Center=�5L      ��5M      �� *TotalCashSales+$ OneWay=�$ uc�� �� 	Converter# [  �� 5R      $��3��6   $��0��5S      $��Center=�5T      $��Total Check Sales:��5U      $
��Bold"�5V      
���`���5W      �� 5X      $��3��6   $��1��5Y      $��Center=�5Z      ��5[      �� *TotalCheckSales+$ OneWay=�$ uc��# [  �� 5a      $��4��6   $��0��5b      $��Center=�5c      $��Total Credit Sales:��5d      $
��Bold"�5e      
���`���5f      �� 5g      $��4��6   $��1��5h      $��Center=�5i      ��5j      �� *TotalCreditSales+$ OneWay=�$ uc��# [  �� 5o      $��5��6   $��0��5p      $��Center=�5q      $��Total Taxes Assessed:��5r      $
��Bold"�5s      
���`���5t      �� 5u      $��5��6   $��1��5v      $��Center=�5w      ��5x      �� *TotalTaxesAssesed+$ OneWay=�$ uc��# [  �� 5}      $��6��6   $��0��5~      $��Center=�5      $��Total Profit:��5�      $
��Bold"�5�      
���`���5�      �� 5�      $��6��6   $��1��5�      $��Center=�5�      ��5�      �� *TotalProfit+$ OneWay=�$ uc��# [  �� 5�      $��7��6   $��0��5�      $��Center=�5�      $��Expected Cash in Hand:��5�      $
��Bold"�5�      
���`���5�      �� 5�      $��7��6   $��1��5�      $��Center=�5�      ��5�      �� *ExpectedCash+$ OneWay=�$ uc��# [  �� 5�      -   5        $��8��5�      $��1��5�      $��	Close Day��5�      5�      5�      5�      