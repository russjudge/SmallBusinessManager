   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullyPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  5      Y@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5      O KSBMLibrary.Controls, Version=0.2.10.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters 5      *   $SBMLibrary.Controls.ReceiveInventory   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      iValueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     5      Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        $	��uc1��5	      $	��300��5
        � 	Resources  5      9  3SBMLibrary.Controls.ValueConverters.OrderEntryTotal   OrderEntryTotal��%   &	          5   
   6'   5      .��5      ]� .+�5   
   � $	��Top=�6    � RowDefinitions 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      �� 5      $��6* �6#   �� 5      �� 5      .+�5       �� -   5        $��0��5       $��0��5!      $��Stage for Export��5#      �� 5%      $��1��6   $��0��5&      $��Right=�5'      $��Receipt ID:��5(      $
��Bold"�5)      �� 5*      $��1��6   $��1��5+      $��Center=�5,      ��5-      �� *	ReceiptID+ �� Mode$ OneWay=� �� ElementName$	 uc1���� 51      $��0��6   $��3��52       �� Orientation$ 
Horizontal=�53      �� 54      $��0��6   $��3��55      $��Right=�56      $��	Quantity:��57      �� 58      $��0��6   $��4��59      ��5:      ��  �� Path$ Quantity�$ TwoWay=�$	 uc1���� 5=      $��1��6   $��3��5>      $ 
Horizontal=�5?      �� 5A      $��1��6   $��3��5B      $��Right=�5C      $��UPC or SKU:��5D      �� 5E      -   5        $��
txtSearchX��5E      $��1��5F      $��4��5G      ��5I      �� $ 	SearchKey�$ TwoWay=�$	 uc1�� �� UpdateSourceTrigger$ PropertyChanged=��� 5N      -   5        $��2��5N      $��4��5O      $	��Add��5Q       �� 	IsDefault . 5R      5S      ]� 5T   
   $��Bottom=�6   .+�5V      �� -   5        $��Cancel��5W      $
��Left=�5X      $��5,5,5,5q�5Y      �� 5Z      -   5        $
��Post��5[      $��Right=�5\      $��24(�5]      $
��Bold"�5^      �� 5_      5`      �� 5a   
   $	��Top=�6   $
��Auto=�6,   .��5b      �� $��Stretch=�6   ��63   �� *
Activity+$ OneWay=�$	 uc1��	 �� View	 5d      �� 5f      .P�5g      �� 
 �� Width$
 70��6)    �� CellTemplate 5h      �� 5i   "   .R�5j   &   �� $ 
Horizontal=�61   .+�5k   *   �� -   5        $��X��5m   1   ��5l   1   �� 5m   1   5n   '   5o   #   5q      �� 5r      $	
 120��6)    �� HeaderTemplate 5t      �� 5u   "   .R�5v   &   �� $��Center=�60   $
��Bold"�5w   0   $	��UPC��5x   0   5y   #    5|      �� 5}   "   .R�5~   &   �� $ 
Horizontal=�61   .+�5   *   �� $��2q�64   $��Center=�5�   4   ��5�   4   �� *UPC+5�   '   5�   #   5�      �� 5�      $	
 120��6)    5�      �� 5�   "   .R�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $	��SKU��5�   0   5�   #    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��2q�64   $��Center=�5�   4   ��5�   4   �� *SKU+5�   '   5�   #   5�      �� 5�      $	
 320��6)    5�      �� 5�   "   .R�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $
��Name��5�   0   5�   #    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��2q�64   $��Center=�5�   4   ��5�   4   �� *Name+5�   '   5�   #   5�      �� 5�      $
 70��6)    5�      �� 5�   "   .R�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $��Quantity��5�   0   5�   #    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   %   RussLibrary.Controls.DecimalBox  $��2q�69   $��Center=�5�   9      Value 5�   9   �� $ Quantity�$ TwoWay=�5�   '   5�   #   5�      �� 5�      -   5        PART_wholesale��$	
 160��5�   A    5�      �� 5�   "   .R�5�   &   �� $��Center=�60   $
��Bold"�5�   0   $��Wholesale Cost��5�   0   5�   #    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *     $��2q�5�   9   $��Right=�5�   9   $��Center=�5�   9      DisplayFormat$ C��5�   9   ��5�   9   �� *Width+$ PART_wholesale�� 5�   9   �� $ WholeSalePrice�$ TwoWay=�5�   '   5�   #   5�      5�      5�      5�      5�      5�      