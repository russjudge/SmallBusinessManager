   M S B A M L   `   `   `  ����S  ORussLibrary.Controls, Version=1.0.1.33814, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  5   	   yPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  5   	    SBMLibrary.Controls+   %SBMLibrary.Controls.CashBalanceWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     5   	   ivalueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     5   	   -   5        $��uc��5   	     � Title$  Cash Balancing��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 	Resources 5	      <   6RussLibrary.Controls.ValueConverters.CurrencyFormatter   CurrencyFormatter��%   &	          5
   
   6)   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       .+�5"   
   �� $��0��6   $��0��5#      $��Denomination��5$      $��14(�5%      $
��Bold"�5&      �� 5'   
   $��0��6   $��1��5(      $��Count��5)      $��14(�5*      $
��Bold"�5+      �� 5,   
   $��0��6   $��2��5-      $��Amount��5.      $��14(�5/      $
��Bold"�50      �� 53   
   $��1��6   $��100s:��54      $
��Bold"�55      %   RussLibrary.Controls.DecimalBox  56   
   $��1��6   $��1��57      $��70��58      $��Right=�59      $��Center=�5:         Value 5;      ��  �� Path$ Hundreds� �� Mode$ TwoWay=� �� ElementName$ uc��	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5?   
   $��1��6   $��2��5@      $��Right=�5A      $��Center=�5B      ��5C      �� *HundredsAmount+$ OneWay=�$ uc��
 �� 	Converter#
 [  �� 5I   
   $��2��6   $
��50s:��5J      $
��Bold"�5K        5L   
   $��2��6   $��1��5M      $��70��5N      $��Right=�5O      $��Center=�5P       5Q      �� $ Fifties�$	 PropertyChanged=�$ TwoWay=�$ uc���� 5U   
   $��2��6   $��2��5V      $��Right=�5W      $��Center=�5X      ��5Y      �� *FiftiesAmount+$ OneWay=�$ uc��#
 [  �� 5^   
   $��3��6   $
��20s:��5_      $
��Bold"�5`        5a   
   $��3��6   $��1��5b      $��70��5c      $��Right=�5d      $��Center=�5e       5f      �� $ Twenties�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5j   
   $��3��6   $��2��5k      $��Right=�5l      $��Center=�5m      ��5n      �� *TwentiesAmount+$ OneWay=�$ uc��#
 [  �� 5s   
   $��4��6   $
��10s:��5t      $
��Bold"�5u        5v   
   $��4��6   $��1��5w      $��70��5x      $��Right=�5y      $��Center=�5z       5{      �� $
 Tens�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5   
   $��4��6   $��2��5�      $��Right=�5�      $��Center=�5�      ��5�      �� *
TensAmount+$ OneWay=�$ uc��#
 [  �� 5�   
   $��5��6   $	��5s:��5�      $
��Bold"�5�        5�   
   $��5��6   $��1��5�      $��70��5�      $��Right=�5�      $��Center=�5�       5�      �� $ Fives�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�   
   $��5��6   $��2��5�      $��Right=�5�      $��Center=�5�      ��5�      �� *FivesAmount+$ OneWay=�$ uc��#
 [  �� 5�   
   $��6��6   $	��2s:��5�      $
��Bold"�5�        5�   
   $��6��6   $��1��5�      $��70��5�      $��Right=�5�      $��Center=�5�       5�      �� $
 Twos�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�   
   $��6��6   $��2��5�      $��Right=�5�      $��Center=�5�      ��5�      �� *
TwosAmount+$ OneWay=�$ uc��#
 [  �� 5�   
   $��7��6   $	��1s:��5�      $
��Bold"�5�        5�   
   $��7��6   $��1��5�      $��70��5�      $��Right=�5�      $��Center=�5�       5�      �� $
 Ones�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�   
   $��7��6   $��2��5�      $��Right=�5�      $��Center=�5�      ��5�      �� *
OnesAmount+$ OneWay=�$ uc��#
 [  �� 5�   
   $��8��6   $��Coin:��5�      $
��Bold"�5�        5�   
   $��8��6   $��2��5�      $��70��5�      $��Right=�5�      $��Center=�5�         DisplayFormat$ C��5�       5�      �� $ 
CoinAmount�$ TwoWay=�$ uc��$	 PropertyChanged=��� 5�   
   $��9��6   $��0��5�      $��Total:��5�      $��12(�5�      $
��Bold"�5�      �� 5�   
   $��9��6   $��1��5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *TotalBillCount+$ OneWay=�$ uc���� 5�   
   $��9��6   $��2��5�      $��Right=�5�      $��Center=�5�      ��5�      �� *TotalAmount+$ OneWay=�$ uc��#
 [  �� 5�   
   $��10��6   $��0��5�      $��3��5�      $5��/-----------------------------------------------��5�      �� 5�   
   $��11��6   $��0��5�      $��Expected Cash total:��5�      $
��Bold"�5�      �� 5�   
   $��11��6   $��2��5�      $��Right=�5�      ��5�      �� *ExpectedCash+$ OneWay=�$ uc��#
 [  �� 5�   
   -   5        $��12��5�      $��2��5�      $��Continue��5�      5�      5�      