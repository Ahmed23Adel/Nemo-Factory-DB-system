   M S B A M L   `   `   `  ����?  ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Nemo.supervisorNemo.supervisor  5      .    (Nemo.supervisor.viewAssignedMachinesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Nemo.supervisor     5        N� Title$  viewAssignedMachinesPage��5	      .��5      ��    WordBlueBrush#��[  6   $��14q�69   ._�5   
   � ���	#FFDAE6FF.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ machinesGrid��5         CanUserAddRows .     AutoGenerateColumns .  $��20(�6`   $��2��6n   $��
0,0,0,-0.4q�6�   ��5      �� 5       �� ImageSource$ 
myBack.png��6!      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��5   )      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   ;   �� 
 �� Path$
 ID�5   5     5       . $ Machine name��5   )   $ * 6?   	 5   ;   �� $

 Name�5   ?     5       . $ 
Start Date��5   )   $ * 6=   	 5   ;   �� $

 Date�5   =     5       . $
 Line��5   )   $ * 67   	 5   ;   �� $

 Line�5   7   5!      5"      5$      5'      