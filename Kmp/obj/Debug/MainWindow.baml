   M S B A M L   `   `   `  ����>  :Kmp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KmpKmp  5   	       Kmp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Kmp     5   	     � Title$  
MainWindow��5   	   $	��400��6   $
��1300��6)   ���	#FF9BA88F.��5	      ]� ��. $	��350��6%   $
��1250��65   $��0,0,0,0q�6E   .+�5
   
   � $
��1293��6   $	��370��6    � RowDefinitions 5      �� 5      6"   �� 5      $	��345 �6    6/    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5      o� $��14(�6   $��0��6!   $��3��6.   .@�5      m� $��Файл��6   .@�5      m� -   5        $'��!Заполнить таблицу��5      $
��Left=�6<   $	��210��6Y   6g   m� 5      -   5        $��Загрузить код��5      $
��Left=�68   $	��210��6U   6c   5      m� 5      $ ��Редактировать��6   $��14(�64   .@�5      m� -   5        $��Добавить��5      $
��Left=�63   $	��150��6P   6^   �� 5      $
��Left=�6    $	��140��6=   m� 5      -   5        $��
Поиск��5      $
��Left=�60   $	��150��6K   6Y   5       m� 5!      $	��150��6   $��Сканировать��6'   .@�5"      m� -   5        $+��%Начать сканирование��5"      6U   5#      5$      &   System.Windows.Controls.DataGrid  5%      -   5          Name$ 
IdDataGrid��5%         AutoGenerateColumns .  $	��Top=�6J   $��14(�6b   
�������$��1��6�   $��5,5,0,0q�6�      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *code+  5(      $ Имя��6)   $	 100 66    6B   �� *nameId+  5)      $ Тип��6)   $ 70 66    6A   �� *type+  5*      $ Значение��6)   $ 1* 6;    6F   �� *value+5,      �� 5.      $��
10,5,10,10q�6   
�������$��1q�6B   $��1��6V   $��1��6c   
�������._�5/      �� -   5        	 ��Name$	 CodeList��5/      51      �� 52      $��
10,5,10,10q�6   
�������$��1q�6B   $��1��6V   $��3��6c   
�������._�53      �� -   5        $	 	Code1List��53      55      56      57      58      