   M S B A M L   `   `   `  ���� S  ORussLibrary.Controls, Version=1.0.0.38730, Culture=neutral, PublicKeyToken=nullY@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.ControlsRussLibrary.Controls  J FRussLibrary, Version=1.0.0.38729, Culture=neutral, PublicKeyToken=nullN6clr-namespace:RussLibrary.Helpers;assembly=RussLibraryRussLibrary.Helpers N JSBMLibrary.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SBMLibrary.Controls.ValueConverters#SBMLibrary.Controls.ValueConverters yPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls$RussLibrary.Controls.ValueConverters  /   )SBMLibrary.Controls.ActiveInventoryEditor   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Pctl@clr-namespace:RussLibrary.Controls;assembly=RussLibrary.Controls     @d2http://schemas.microsoft.com/expression/blend/2008     Ihelper6clr-namespace:RussLibrary.Helpers;assembly=RussLibrary     JlocalConvert1clr-namespace:SBMLibrary.Controls.ValueConverters     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ivalueConvertPclr-namespace:RussLibrary.Controls.ValueConverters;assembly=RussLibrary.Controls     -   $��uc��  � 	Resources     lvStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value@  :SBMLibrary.Controls.ValueConverters.BreakEvenCostConverter  BreakEvenCostConverter<   6RussLibrary.Controls.ValueConverters.CurrencyFormatter  CurrencyFormatter;   5RussLibrary.Controls.ValueConverters.NumericFormatter  NumericFormatter��%)  &	        &	 �     &	 �     &	 �     �� " ��.���  �@$�IsVirtualizing . ��  �@$�VirtualizationMode$ 	Recycling=��� " �@��IsDeferredScrollingEnabled .  ��  �� *	IsLoading+ True.a���  �@�Cursor$
 Wait����  � ��
 �����      .��]� .+��� $��Right=�$	��Top=� �� Orientation$ 
Horizontal=�.+��� -   $
��Save��$��18(�$
��Bold"�� $��Bottom=� � RowDefinitions �� �� 	 � ColumnDefinitions	 �� $��3* ��� �� .+��� $��0��$��1��$��Right=�$��Total Invested:��$��Black"��� $��0��$��2��$��Right=�$��Center=����� *Inventory.TotalInvested+
 �� Mode$
 OneWay=� �� ElementName$ uc�� �� 	Converter# [ �� $	��Top=�$
��Auto=�.���� $��Stretch=�#���   ���� *	Inventory+$
 OneWay=�$ uc�� �� View �� .P���  �� Width$ 70�� �� CellTemplate �� .R��� $ 
Horizontal=�.+��� -   $��X������ �� -   $��Details������ �� -   PART_ProductIDCol��$	 120�� �� HeaderTemplate �� .R��� .+��� $��Center=�$
��Bold"�$��
Product ID�� �� .R��� .+��� $��Center=�$��2q����� *Width+$
 OneWay=�$ PART_ProductIDCol������ *	ProductID+$
 OneWay=��� -   PART_UPCCol��$	 120�� �� .R��� .+��� $��Center=�$
��Bold"�$	��UPC���� $��Center=�$
��Bold"�$	��SKU�� �� .R��� .+��� $��Center=�$��2q����� *Width+$
 OneWay=�$ PART_UPCCol������  �� Path$	 UPC�$
 TwoWay=��� $��Center=�$��2q����� *Width+$
 OneWay=�$ PART_UPCCol������ $	 SKU�$
 TwoWay=��� -   PART_NameCol��$	 220�� �� .R��� $��Center=�.+��� $��Center=�$
��Bold"�$��Model���� $��Center=�$
��Bold"�$
��Name�� �� .R��� $��Center=�.+��� $��Center=�$��Center=�$��2q����� *Width+$
 OneWay=�$ PART_NameCol������ $ Model�$
 TwoWay=��� $��Center=�$��2q����� *Width+$
 OneWay=�$ PART_NameCol������ $
 Name�$
 TwoWay=��� -   PART_DistributorCol��$	 120�� �� .R��� $��Center=�.+��� $��Center=�$
��Bold"�$��Distributor���� $��Center=�$
��Bold"�$��Manufacturer�� �� .R��� $��Stretch=�.+��� $��Stretch=�$��2q����� *Width+$
 OneWay=�$ PART_DistributorCol������ $ Distributor�$
 TwoWay=��� $��Stretch=�$��2q����� *Width+$
 OneWay=�$ PART_DistributorCol������ $ Manufacturer�$
 TwoWay=��� -	   PART_PictureCol��$	 150�� �� .R��� $��Center=�.+��� $��Center=�$
��Bold"�$��Picture���� $��Center=�$
��Bold"�$��Special Discount Level�� �� .R��� .+��� $��Stretch=�$��2q����� *Width+$
 OneWay=�$ PART_PictureCol������ $ 
PictureURL�$
 TwoWay=��� $��Stretch=� �� Padding$ 2q����� *Width+$
 OneWay=�$ PART_PictureCol������ *DiscountRateLevel+# [  �� ConverterParameter$ #.##%���� -
   PART_QuantityCol��$	 120�� �� .R��� .+��� $��Center=�$
��Bold"�$��Quantity�� �� .R��� $��Right=�$��Center=�$��18(�$��Black"�
��� � ����� *
Quantity+�� -   PART_MSRPCol��$	 120�� �� .R��� $��Center=�.+��� $��Center=�$
��Bold"�$��Wholesale Cost���� $��Center=�$
��Bold"�$
��MSRP�� �� .R��� $��Stretch=�.+��� $��Stretch=�$ 2q����� *Width+$
 OneWay=�$ PART_MSRPCol������ *WholeSalePrice+# [ �� $��Stretch=�$ 2q����� *Width+$
 OneWay=�$ PART_MSRPCol������ *MSRP+# [ �� -   PART_CostCol��$	 120�� �� .R��� $��Center=�.+��� $��Center=�$
��Bold"�$��Additional Overhead���� $��Center=�$
��Bold"�$��Break-even Cost�� �� .R��� $��Stretch=�.+�%   RussLibrary.Controls.DecimalBox  $��Stretch=�   DisplayFormat$ C��$��2q����� *Width+$
 OneWay=�$ PART_CostCol��   Value �� $ AdditionalOverhead�$
 TwoWay=��� $��Stretch=�$ 2q����� *Width+$
 OneWay=�$ PART_CostCol������ # [ 