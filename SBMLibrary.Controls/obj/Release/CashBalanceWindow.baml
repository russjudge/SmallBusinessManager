   M S B A M L   `   `   `  ���� S  ORussLibrary.Controls, Version=1.0.0.38730, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  yPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters   SBMLibrary.Controls+   %SBMLibrary.Controls.CashBalanceWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     ivalueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     -   $��uc��  � Title$  Cash Balancing�� � SizeToContent$ WidthAndHeight=� � 	Resources <   6RussLibrary.Controls.ValueConverters.CurrencyFormatter   CurrencyFormatter��%   &	          .���  � RowDefinitions �� �� �� �� �� �� �� �� �� �� �� �� ��  � ColumnDefinitions �� �� �� .+��� $��Denomination��$��0��$��0��$
��Bold"�$��14(��� $��Count��$��0��$��1��$
��Bold"�$��14(��� $��Amount��$��0��$��2��$
��Bold"�$��14(��� $��1��$��100s:��$
��Bold"�%   RussLibrary.Controls.DecimalBox  $��Right=�$��70��$��1��$��1��$��Center=�   Value ��  �� Path$ Hundreds� �� Mode$ TwoWay=� �� ElementName$ uc���� $��Right=�$��1��$��2��$��Center=����� *HundredsAmount+$ OneWay=�$ uc��	 �� 	Converter#	 [  �� $��2��$
��50s:��$
��Bold"�  $��Right=�$��2��$��70��$��Center=�$��1�� �� $ Fifties�$ TwoWay=�$ uc���� $��Right=�$��2��$��2��$��Center=����� *FiftiesAmount+$ OneWay=�$ uc��#	 [  �� $��3��$
��20s:��$
��Bold"�  $��Right=�$��3��$��70��$��1��$��Center=� �� $ Twenties�$ TwoWay=�$ uc���� $��Right=�$��3��$��2��$��Center=����� *TwentiesAmount+$ OneWay=�$ uc��#	 [  �� $��4��$
��10s:��$
��Bold"�  $��Right=�$��4��$��70��$��Center=�$��1�� �� $
 Tens�$ TwoWay=�$ uc���� $��Right=�$��4��$��2��$��Center=����� *
TensAmount+$ OneWay=�$ uc��#	 [  �� $��5��$	��5s:��$
��Bold"�  $��Right=�$��5��$��70��$��1��$��Center=� �� $ Fives�$ TwoWay=�$ uc���� $��Right=�$��5��$��2��$��Center=����� *FivesAmount+$ OneWay=�$ uc��#	 [  �� $��6��$	��2s:��$
��Bold"�  $��Right=�$��6��$��70��$��1��$��Center=� �� $
 Twos�$ TwoWay=�$ uc���� $��Right=�$��6��$��2��$��Center=����� *
TwosAmount+$ OneWay=�$ uc��#	 [  �� $��7��$	��1s:��$
��Bold"�  $��Right=�$��7��$��70��$��1��$��Center=� �� $
 Ones�$ TwoWay=�$ uc���� $��Right=�$��7��$��2��$��Center=����� *
OnesAmount+$ OneWay=�$ uc��#	 [  �� $��8��$��Coin:��$
��Bold"�  $��Right=�$��8��$��70��$��2��$��Center=�
   DisplayFormat$
 C�� �� $ 
CoinAmount�$ TwoWay=�$ uc���� $��9��$��Total:��$
��Bold"�$��0��$��12(��� $
��Left=�$��9��$��Center=�$��1������ *TotalBillCount+$ OneWay=�$ uc���� $��Right=�$��9��$��Center=�$��2������ *TotalAmount+$ OneWay=�$ uc��#	 [  �� $5��/-----------------------------------------------��$��10��$��0��$��3���� $��Expected Cash total:��$��11��$��0��$
��Bold"��� $��Right=�$��11��$��2������ *ExpectedCash+$ OneWay=�$ uc��#	 [  �� -   $��12��$��2��$��Continue��