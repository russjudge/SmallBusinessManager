   M S B A M L   `   `   `  ���� S  ORussLibrary.Controls, Version=1.0.0.38730, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls   SBMLibrary.Controls,   &SBMLibrary.Controls.PricingModelEditor   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     -   $��uc��.��]� .+��� $	��Top=�  �� Orientation$  
Horizontal=�.+��� -   $��	Add Model���� -   $��Save Models���� $	��Top=�$
��Auto=�.���� $��Stretch=����� *Models+ �� Mode$ OneWay=� �� ElementName$ uc�� �� View �� .P���  �� Width$ 70�� �� CellTemplate �� .R��� $  
Horizontal=�.+��� -   $��X������ �� $	 170�� �� HeaderTemplate �� .R��� $��Center=�$
��Bold"�$
��Name�� �� .R��� $  
Horizontal=�.+��� $��Stretch=�$	��170������  �� Path$
 Name�$ TwoWay=��� $	 120�� �� .R��� $��Center=�$
��Bold"�$��Base Price Selection�� �� .R��� $  
Horizontal=�.+���  �� SelectedItem �� $ BasePriceChoice�$ TwoWay=����� *PricingSelections+$ uc���� $	 120�� �� .R��� $��Center=�$
��Bold"�$��Round to Nearest�� �� .R��� $  
Horizontal=�.+�%   RussLibrary.Controls.DecimalBox  	   DisplayFormat$	 C��
   Value
 �� $ RoundToNearest�$ TwoWay=��� $	 120�� �� .R��� $��Center=�$
��Bold"�$��
Multiplier�� �� .R��� $  
Horizontal=�.+�  
 �� $ 
Multiplier�$ TwoWay=��� $	 120�� �� .R���  � ToolTip$� �Will add sales tax to multiplier before calculating final price.  If not checked, sales tax is added after total of products are added.��$
��Wrap=�$��Center=�$
��Bold"�$*��$Include Sales Tax with Rounded Price�� �� .R��� $  
Horizontal=�.+���  d� 	IsChecked �� $ IncludesSalesTax�$ TwoWay=�