   M S B A M L   `   `   `  ����E  AGetYourCar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GetYourCar
GetYourCar  5   	   !    GetYourCar.AddCarDataWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GetYourCar     5   	     � Title$)  #Добавить транспорт��5   	   $	��551��6$   $	��440��61    � 
ResizeMode$ NoResize=�6=   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $
��Left=�6   $��20(�63   �� 6B   $,�&Название транспорта:��6F   6e   �� 5      -   5         ��Name$ NameCar��5      $��18(�6'    J� Opacity$
 0.65Q�65   $+��%Введите что нибудь...��6D   �� 5      $
��Left=�6   $	��143��63   �� 6@   $��20(�6D   $�Номер:��6R   6c   �� 5      -   5        $ StateNumberCar��5      $
 0.65Q�6.   $��18(�6=   $+��%Введите что нибудь...��6K   �� 5      $
��Left=�6   $��20(�63   $��Кол-во мест:��6A   �� 5      -   5        $ NumberPassengersCar��5      $
 0.65Q�63   $��18(�6B   $+��%Введите что нибудь...��6P   �� 5      $
��Left=�6   $��20(�63   $��Тип траспорта��6A   6X   �� 5      -   5         ��Name$ TypeCarCombo��5       �� SelectedValuePath$ Id��6-    �� SelectedIndex$ 0��6D   �� 5      -   5         ��Name$ AddCar��5      $��Добавить��6%   $��40(�68   6F   5      5      5      