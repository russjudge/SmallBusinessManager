   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5       SBMLibrary.Controls,   &SBMLibrary.Controls.PricingModelEditor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5      -   5        $��uc��5      .��5      ]� .+�5	   
   �� $	��Top=�6     �� Orientation$  
Horizontal=�6*   .+�5
      �� -   5        $��	Add Model��5
      6)   �� 5      -   5        $��Save Models��5      6+   5      �� 5   
   $	��Top=�6   $
��Auto=�6,   .��5      �� $��Stretch=�6   ��63   �� *Models+ �� Mode$ OneWay=� �� ElementName$ uc�� �� View 5      �� 5      .P�5      ��  �� Width$ 70��6)    �� CellTemplate 5      �� 5   "   .R�5   &   �� $  
Horizontal=�61   .+�5   *   �� -   5        $��X��5   1   ��5   1   �� 5   1   5   '   5   #   5      �� 5"      $	 170��6)    �� HeaderTemplate 5$      �� 5%   "   .R�5&   &   �� $��Center=�60   $
��Bold"�5'   0   $
��Name��5(   0   5)   #    5,      �� 5-   "   .R�5.   &   �� $  
Horizontal=�61   .+�5/   *   �� $��Stretch=�62   $	��170��6P   ��6_   ��  �� Path$
 Name�$ TwoWay=�53   '   54   #   56      �� 5:      $	 120��6)    5<      �� 5=   "   .R�5>   &   �� $��Center=�60   $
��Bold"�5?   0   $��Base Price Selection��5@   0   5A   #    5D      �� 5E   "   .R�5F   &   �� $  
Horizontal=�61   .+�5G   *   ��  �� SelectedItem 5H   -   �� $ BasePriceChoice�$ TwoWay=���5I   -   �� *PricingSelections+$ uc��5M   '   5N   #   5P      �� 5Q      $	 120��6)    5S      �� 5T   "   .R�5U   &   �� $��Center=�60   $
��Bold"�5V   0   $��Round to Nearest��5W   0   5X   #    5[      �� 5\   "   .R�5]   &   �� $  
Horizontal=�61   .+�5^   *   %   RussLibrary.Controls.DecimalBox  	   DisplayFormat$	 C��6l   
   Value
 69   �� $ RoundToNearest�$ TwoWay=�6l   5b   '   5c   #   5e      �� 5g      $	 120��6)    5i      �� 5j   "   .R�5k   &   �� $��Center=�60   $
��Bold"�5l   0   $��
Multiplier��5m   0   5n   #    5q      �� 5r   "   .R�5s   &   �� $  
Horizontal=�61   .+�5t   *     
 69   �� $ 
Multiplier�$ TwoWay=�5x   '   5y   #   5{      �� 5�      $	 120��6)    5�      �� 5�   "   .R�5�   &   ��  � ToolTip$� �Will add sales tax to multiplier before calculating final price.  If not checked, sales tax is added after total of products are added.��60   $
��Wrap=�6�   $��Center=�6�   $
��Bold"�5�   0   $*��$Include Sales Tax with Rounded Price��5�   0   5�   #    5�      �� 5�   "   .R�5�   &   �� $  
Horizontal=�61   .+�5�   *   ��  d� 	IsChecked 63   �� $ IncludesSalesTax�$ TwoWay=�5�   '   5�   #   5�      5�      5�      5�      5�      5�      