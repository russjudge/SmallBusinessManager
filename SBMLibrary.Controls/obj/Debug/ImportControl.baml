   M S B A M L   `   `   `  ����  SBMLibrary.Controls'    !SBMLibrary.Controls.ImportControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        $��uc��5      .��5      �� .+�5	   
   � .+�5
      �� -   5        $	��100��5
      $��Center=�5      $��Center=�5      
���  ����5      �� 5      $��Center=�6    $
��Bold"�5       $��Clear Current Inventory��5       $
��Wrap=�5       5      �� 5      .+�5      	� $��5,0,5,0q�6   $��Center=�5      $��Overwrite current data��5        	� 	GroupName$  	radoption��5       d� 	IsChecked 5      ��  �� Path$ OverwriteData� �� Mode$ TwoWay=� �� ElementName$ uc��	� 5      $��5,0,5,0q�6   $��Center=�5       $��Update Quantities��5!      $  	radoption��5"       5#      �� $ UpdateQuantity�$ TwoWay=�$ uc��	� 5&      $��5,0,5,0q�6   $��Center=�5'      $:��4Only update if null, empty, or zero (never quantity)��5(      $  	radoption��5)       5*      �� $ UpdateNothing�$ TwoWay=�$ uc��5.      �� 50      -   5        $	��200��50       � ToolTip$U OAll fields in matching item replaced with data from spreadsheet, matched by UPC��52      ��53      �� 54      $��Center=�6    $
��Bold"�55       $F��@Import from CSV of Original POS Spreadsheet (Merge with current)��56       $
��Wrap=�57       5:      �� 5;      -   5        $	��200��5;      $� �All fields in matching item replaced with data from spreadsheet, matched by first ProductID, then UPC (if not ProductID), then SKU (if not UPC)��5=      ��5>      �� 5?      $��Center=�6    $
��Bold"�5@       $?��9Import from CSV of Website Inventory (Merge with current)��5A       $
��Wrap=�5B       5E      �� 5F      -   5        $	��200��5F      $� �All fields in matching item replaced with data from spreadsheet, matched by first ProductID, then UPC (if not ProductID), then SKU (if not UPC)��5H      ��5I      �� 5J      $��Center=�6    $
��Bold"�5K       $Q��KImport from CSV of OpenCart (Chad's) Website Inventory (Merge with current)��5L       $
��Wrap=�5M       5P      5Q      �� 5R   
   
����+��$��3q�6*   � 5T   
   .+�5U      �� -   5        $	��200��5U      ��5V      �� 5W      $��Center=�6    $
��Bold"�5X       $)��#Export Quantity Changes to CSV file��5Y       $
��Wrap=�5Z       5]      �� 5^      -   5        $	��200��5^      ��5_      �� 5`       � MappingMode$ RelativeToBoundingBox=�6*    �� 
StartPoint$ 0.5,0&�6N    �� EndPoint$ 0.5,1&�6a   .��5a      � 	 � Offset$	 0Q�6'   
 � Color$
 	#FFF3F3F3��62   � 5b      $		 0.5Q�6'   $
 	#FFEBEBEB��64   � 5c      $		 0.5Q�6'   $
 	#FFDDDDDD��64   � 5d      $	 1Q�6'   $
 	#FFCFF95F��62   5e      ��5g      �� 5h      $��Center=�6    $
��Bold"�5i       $Q��KExport Quantity Changes Directly to Website (must have Internet Connection)��5j       $
��Wrap=�5k       5n      5o      �� 5p   
   
����+��$��3q�6*   �� 5q   
   ��5r      �� 5s      $
��Bold"�6   $��Troubleshooting��6.   .��5u      � .+�5v      �� -   5        $	��150��5v      ��5w      �� 5x      $��Center=�6$   $=��7Export configuration data and log file for support team��5y   $   $
��Wrap=�5z   $   5}      5~      5      5�      5�      