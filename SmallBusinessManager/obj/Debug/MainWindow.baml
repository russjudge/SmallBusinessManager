   M S B A M L   `   `   `  ����O  KSBMLibrary.Controls, Version=0.2.10.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:SBMLibrary.Controls;assembly=SBMLibrary.ControlsSBMLibrary.Controls  5   	    	FoxOnePOS%   SmallBusinessManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Nctl>clr-namespace:SBMLibrary.Controls;assembly=SBMLibrary.Controls     5   	   -   5        $��uc��5   	     � Title$  OpenCart POS Client��5   	   $	��600��5   	    � Icon$ FoxOneLogo.ico��5   	    � SizeToContent$ Width=�5
   	   ��5      
� 5   
   .��5      �  � Offset$ 0Q�6    � Color$ 	#FFEDFFDA��6&   � 5      $ 1Q�6   $ 	#FFB3FBBD��6&   5      .��5      � .+�5   
   �� ���	#FF8A93AC �� TabStripPlacement$
 Left=�6-   .@�5      �� ��5      �� 5      $��20(�6    $
��Bold"�5       $��Point of Sale��5       .��5      �� ��5      �� 5       �� 
StartPoint$ 0.5,0&�6.    �� EndPoint$ 0.5,1&�6A   .��5      � $ 0Q�6+   $ 	#FFF7E4B0��66   � 5       $ 1Q�6+   $ 	#FFFFF5DB��66   5!      ��5#      �� 5$      ���	#FFFFEFA9$��20(�5%   $   $
��Bold"�5&   $   $��Point of Sale��5'   $   .��5)      %   SBMLibrary.Controls.PointOfSale  -   5          Name$ PART_PointOfSale��5)   &   	   Logo	 6@   �� *Logo+
 �� ElementName$
 uc�� �� Mode$ OneWay=�5*      5+      �� 55      -   5        $��tbOrderEntry��55      ��56      �� 57      $	��200��6    $��Center=�58       $��20(�59       $
��Bold"�5:       $��   Receive Inventory��5;       .��5=      �� ��5>      �� 5?      $ 0.5,0&�6.   $ 0.5,1&�6A   .��5@      � $ 0.771Q�6+   $ 	#FFF35858��6:   � 5A      $ 0.384Q�6+   $ 	#FFFFE6E6��6:   5B      ��5D      �� 5E      $��20(�6$   $
��Bold"�5F   $   $��Receive Inventory��5G   $   ��5H      �� 5I   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5J   &   � $ 0.445Q�63   $ 	#FFF9E9D9��6B   � 5K   &   $ 1Q�63   $ 	#FFF3E5D6��6>   5L   #   5N      .��5P      *   $SBMLibrary.Controls.ReceiveInventory  5Q      5R      �� 5T      -   5        ��5U      �� 5V      $��20(�6    $
��Bold"�5W       $��Active Inventory��5X       .��5Z      �� ��5[      
� 5\      .��5]      � $ 0Q�6+   $ Black��66   � 5^      $ 1Q�6+   $ 	#FF3B9FF3��66   5_      ��5a      �� 5b      ���	#FF2E9EFB$��20(�5c   $   $
��Bold"�5d   $   $��Active Inventory��5e   $   .��5g      /   )SBMLibrary.Controls.ActiveInventoryEditor  5h      5j      �� 5t      ��5u      �� 5v      $��20(�6    $
��Bold"�5w       $��Reports��5x       5z      �� 5{      ��5|      �� 5}      $��18(�6    $
��Bold"�5~       $��Import/Export��5       .��5�      �� .+�5�      '   !SBMLibrary.Controls.ImportControl  5�      5�      �� 5�      ��5�      �� 5�      $��14(�6    $
��Bold"�5�       $��Configuration��5�       .��5�      .   (SBMLibrary.Controls.ConfigurationControl  5�      5�      �� 5�   
   $
��Left=�6   $��Bottom=�60   .+�5�      %   SBMLibrary.Controls.SalesStatus  -   5          Name$ PART_SalesStatus��5�         TotalCashSales 5�      ��  �� Path$ TotalCashSales�$ TwoWay=�$
 PART_PointOfSale��   TotalCheckSales 5�      �� $ TotalCheckSales�$ TwoWay=�$
 PART_PointOfSale��   TotalCreditSales 5�      �� $ TotalCreditSales�$ TwoWay=�$
 PART_PointOfSale��   TotalProfit 5�      �� $ TotalProfit�$ TwoWay=�$
 PART_PointOfSale��   TotalTaxesAssesed 5�      �� $ TotalTaxesAssesed�$ TwoWay=�$
 PART_PointOfSale���� 5�      $	��170��6   ��6    �� *Logo+$ OneWay=�$
 uc��5�      5�      5�      