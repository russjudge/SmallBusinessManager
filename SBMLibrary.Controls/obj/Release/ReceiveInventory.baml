   M S B A M L   `   `   `  ���� S  ORussLibrary.Controls, Version=1.0.0.38730, Culture=neutral, PublicKeyToken=nullyPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  Y@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  N JSBMLibrary.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters *   $SBMLibrary.Controls.ReceiveInventory   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     iValueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     @d2http://schemas.microsoft.com/expression/blend/2008     JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $��uc��$	��300��  � 	Resources  9  3SBMLibrary.Controls.ValueConverters.OrderEntryTotal   OrderEntryTotal��%   &	          .��]� .+�� $	��Top=� � RowDefinitions �� �� ��  � ColumnDefinitions �� $��4* ��� �� .+��� $��0��$��1�� �� Orientation$ 
Horizontal=��� $��0��$��1��$��Right=�$��	Quantity:���� $��0��$��2������  �� Path$ Quantity� �� Mode$ TwoWay=� �� ElementName$ uc���� $��1��$��1��$ 
Horizontal=��� $��1��$��1��$��Right=�$��UPC or SKU:���� -   $��	txtSearch��$��1��$��2������ $ 	SearchKey�$ TwoWay=�$ uc���� -   $��2��$��2��$	��Add�� �� 	IsDefault . �� $��Right=�$��Bottom=�$ 
Horizontal=�.+��� -   $
��Post��$
��Bold"�$��24(��� $	��Top=�$
��Auto=�.���� $��Stretch=����� *Result+$ OneWay=�$ uc�� �� View �� .P��� 	 �� Width$	 70��
 �� CellTemplate
 �� .R��� $ 
Horizontal=�.+��� -   $��X������ �� $		 120�� �� HeaderTemplate �� .R��� $��Center=�$
��Bold"�$	��UPC��
 �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *UPC+�� $		 120�� �� .R��� $��Center=�$
��Bold"�$	��SKU��
 �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *SKU+�� $		 220�� �� .R��� $��Center=�$
��Bold"�$��Description��
 �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=����� *Description+�� $	 70�� �� .R��� $��Center=�$
��Bold"�$��Quantity��
 �� .R��� $ 
Horizontal=�.+�%   RussLibrary.Controls.DecimalBox  $��2q�$��Center=�   Value �� $ Quantity�$ TwoWay=��� $		 160�� �� .R��� $��Center=�$
��Bold"�$��
Price Each��
 �� .R��� $ 
Horizontal=�.+�  $��2q�$��Center=�   DisplayFormat$ C�� �� $ Price�$ TwoWay=��� $		 160�� �� .R��� $��Center=�$
��Bold"�$��Total��
 �� .R��� $ 
Horizontal=�.+��� $��2q�$��Center=�����  �� 	Converter# [  �� $	 70��
 �� .R��� $ 
Horizontal=�.+��� -   $��Item Arrived��