   M S B A M L   `   `   `  ���� D  @Admin App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AdministratorApplication.CardsAdministratorApplication.Cards  C&clr-namespace:AdministratorApplicationAdministratorApplication  )    #AdministratorApplication.MenuWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <clk,clr-namespace:AdministratorApplication.Cards     8local&clr-namespace:AdministratorApplication       � WindowStartupLocation$  CenterScreen=� � Title$ Meniu��$	��770��$
��1300�� � Icon$ ./Resources/icon.ico��$
��Bold"� � 	Resources    ButtonColor �� Color  ButtontTextColor  ButtonHoverColor  ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName  RefreshButtonStyle��%  &	        &	      &	 $     &	 7     &	 �    �� $ #317773���� $ White���� $ #193b39���� " ��.���  � ��# �   ��  � �� �#676b6b��  � ��$ 2q���  � ��# �  ��  � ��$ Center=���  � ��$ Center=���  � ��$	 200����  � �� �� " ��.R��� $	 	btnBorder��$
 15��#��z��#��z��$
 True��._��� $ ContentPresenter��$|�False��#��z��#��z��# z $
��True�� P�  �@J�IsMouseOver$
 True��. ��� $ 	btnBorder��# �   � ���� " ��.���  � ��# �   ��  � �� �#676b6b��  � ��$ 2q���  � ��# �  ��  � ��$ Center=���  � ��$ Center=���  � ��$ 50����  � �� �� " ��.R��� $	 	btnBorder��$
 15��#��z��#��z��$
 True��._�� .+��� $ ContentPresenter��$|�False��#��z��#��z��# z $
��True���� $!��/Resources/refresh_icon.png��$��50��$��50��$��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ 	btnBorder��# �   � ��.��� .+��  � RowDefinitions �� $	��100 ��� $��* �.+�� $��0�� � ColumnDefinitions �� $	��100 ��� $��* ��� $	��270 �.+��� $��0��$��/Resources/logo.png���� $��1�� �� Orientation$ 
Horizontal=�$	��900��$��50��$��0,30,0,0q�$��Center=�$	��Top=�.+��� -    ��Name$ BtnEmployees��$��Angajati��#���  $��Center=�$��20(�$
{�True��$��Tahoma)��� -   $ BtnEmployeeAdd��$��Adaugare angajat��#���  $��10,0,0,0q�$��20(�$��Tahoma)��� -   $ 	BtnStatus��$��Status��#���  $��Center=�$��10,0,0,0q�$��20(�$��Tahoma)��� -   $ BtnExit��$��Iesire��#���  $��10,0,0,0q�$��20(�$��Tahoma)��� -   $ 
BtnRefresh��#���  $��10,0,0,0q�1   +AdministratorApplication.Cards.ClockControl  -     Name$ clock��$��2��$��70,10,46,10q� � -     �Name$
 Main��$��	0,100,0,0q�  � NavigationUIVisibility$ Hidden=�