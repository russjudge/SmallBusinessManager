   M S B A M L   `   `   `  ����   SBMLibrary.Controls'    !SBMLibrary.Controls.ImportControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $��uc��.���� .+�� .+��� -   $	��100��$��Center=�$��Center=�
���  ������ $��Center=�$
��Bold"�$��Clear Current Inventory��$
��Wrap=��� .+�	� $��5,0,5,0q�$��Center=�$��Overwrite current data��  	� 	GroupName$  	radoption�� d� 	IsChecked ��  �� Path$ OverwriteData� �� Mode$ TwoWay=� �� ElementName$ uc��	� $��5,0,5,0q�$��Center=�$��Update Quantities��$  	radoption�� �� $ UpdateQuantity�$ TwoWay=�$ uc��	� $��5,0,5,0q�$��Center=�$:��4Only update if null, empty, or zero (never quantity)��$  	radoption�� �� $ UpdateNothing�$ TwoWay=�$ uc���� -   $	��200�� � ToolTip$U OAll fields in matching item replaced with data from spreadsheet, matched by UPC������ $��Center=�$
��Bold"�$F��@Import from CSV of Original POS Spreadsheet (Merge with current)��$
��Wrap=��� -   $	��200��$� �All fields in matching item replaced with data from spreadsheet, matched by first ProductID, then UPC (if not ProductID), then SKU (if not UPC)������ $��Center=�$
��Bold"�$?��9Import from CSV of Website Inventory (Merge with current)��$
��Wrap=��� -   $	��200��$� �All fields in matching item replaced with data from spreadsheet, matched by first ProductID, then UPC (if not ProductID), then SKU (if not UPC)������ $��Center=�$
��Bold"�$Q��KImport from CSV of OpenCart (Chad's) Website Inventory (Merge with current)��$
��Wrap=��� 
����+��$��3q�� .+��� -   $	��200������ $��Center=�$
��Bold"�$)��#Export Quantity Changes to CSV file��$
��Wrap=�