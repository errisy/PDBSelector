   M S B A M L   `   `   `  ����F  BPDBSelector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PDBSelectorPDBSelector  5   	   A =Errisy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Errisy;assembly=ErrisyErrisy 5   	       PDBSelector.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PDBSelector     5   	   2e$clr-namespace:Errisy;assembly=Errisy     5   	     � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��24 �6   �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $��Center=�6(   �� 6E   -   5         �Name$ 	rSelected��5   I   
����  �$
��Bold"�6l    Of �� 6�   -   5        $ rCount��5   �   
���  ��$
��Bold"�6�   6�   �� 5      -   5        $��2��5      $��Export Selected��6<   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgMain��5       $��1��6      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+5      4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Image��6)      CellTemplate 5      �� 5       .R�5!      �� $	��300��6$   $	��300��60   ��6=   �� *Image+5"      5$        5%      $
 ASA Code��6%    67   �� *Code+5&        5'      $
 Models��6%    65   �� *Models+5(        5)      $
 Selected��6)    5*      �� 5+      .R�5,        Errisy.TickBox  $��80��6(   $��80��63     Errisy.TickBoxBase   	IsChecked 6?   �� *
Selected+5-      5/         	CellStyle 51      �� 52       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 53      P� 54       P� Property �@ 
IsSelected P� Value . . �56      ��  �� Property � �� �� Value
 �����57      �� 58       � ��
 �   �59      5:      5<         RowStyle 5>      �� 5?      )	  #System.Windows.Controls.DataGridRow" 	 6    5@      P� 5A       �@	 
IsSelected . . �5C      ��  � ��
 �����5D      �� 5E       � ��$ 0q�5F      5G      5I      5K      5L      5M      