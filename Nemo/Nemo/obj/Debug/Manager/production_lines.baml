   M S B A M L   `   `   `  ����?  ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nemo.ManagerNemo.Manager  5      #    Nemo.Manager.production_lines   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Nemo.Manager     5        N� Title$  production_lines��5	      .��5      ��    WordBlueBrush#��[  6   $��14q�69   ._�5   
   � ��5      �� 5       j� TileMode$
 Tile=�6    j� ViewportUnits$ Absolute=�5       j� Viewport$ 0 0 500 500�5       �� ImageSource$. (/Images/Backgrounds/emoji-background.png��5      .+�5      �� .+�5      �� -   5        $��30��5       $��
16  4 16 4q�5!       J� RenderTransformOrigin$ 0.5,0.57&�5"      $��35��5#      $	��Top=�5$      $��Right=�5%      ��5'      �� 5(       �� DecodePixelWidth$	 400��6&    �� 	UriSource$ ../Images/plus.ico?�6=   5*      &   System.Windows.Controls.DataGrid  5,      -   5          Name$ prodLinesGrid��5,      $��14 14 14 14q�5-      
������ 
���   �	   RowBackground
	 ����  	 dGrid#��[ 52      
   CanUserAddRows
 .     AutoGenerateColumns .  $��20(�54      ��51      ��  �� Path$
 data� � ContextMenu 58      �� 59      .@�5:      m� -   5        $��item_update��5:   '   $��Update��5;   #   63   m� 5=      -   5        $��
itm_delete��5=   '   $��delete��5>   #   63   5A         Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    
Foreground
 �����   Header$
 Name��5F   <      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5E   ;   �� $
 Name�5F   J     5G       . 
 �����$ ID��5H   <   $ * 6H    5G   ;   �� $ ID�5H   H     5I       . 
 �����$ Location��5J   <   $ * 6N    5I   ;   �� $ Location�5J   N     5K       . 
 �����$ 
Supervisor��5L   <   $ * 6P    5K   ;   �� $ 
Supervisor�5L   P   5S      5T      5U      5W      5Z      