   M S B A M L   `   `   `  ����?  ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nemo.ManagerNemo.Manager  5          Nemo.Manager.Products   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Nemo.Manager     5        N� Title$  Products��5	       � 	Resources 5         rowsOptions��%�   &	        �� 5   
   @�5      m� 5      -   5        $��Update��5      m� 5      -   5        $��Delete��5      5      5      .��5      �� $	��700��6   $
��Auto=�6#   .��5   
   ��   WordBlueBrush#��[ 6   $��14q�5      ._�5      � ��5      �� 5        j� TileMode$
 Tile=�6!    j� ViewportUnits$ Absolute=�5!       j� Viewport$ 0 0 500 500�5"       �� ImageSource$. (/Images/Backgrounds/emoji-background.png��5#      .+�5&      �� .+�5(      �� -   5        $��30��5)      $��
16  4 16 4q�5*       J� RenderTransformOrigin$ 0.5,0.57&�5+      $��35��5,      $	��Top=�5-      $��Right=�5.      ��50      �� 51       �� DecodePixelWidth$	 400��6*    �� 	UriSource$ ../Images/plus.ico?�6A   53      &   System.Windows.Controls.DataGrid  55      -   5        	  Name$	 allProducts��56      $��14 14 14 14q�57      
������ 
���   �
   RowBackground

 ����    AutoGenerateColumns .   	 dGrid#��[ 5=         CanUserAddRows .  $��20(�5?      ��5;      ��  �� Path$ 
Collection�   	CellStyle 5B      �� 5C       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$   .�5D   "   ��  �� Property �@�ContextMenu �� Value# [  6@   5E         Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��61      FontSize$ 20Q�5L   -      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6;      
Foreground
 �����1  +System.Windows.Controls.DataGridBoundColumn   Binding 5N   -   �� $
 Name� �� Mode$ OneWay=�  5P      $
 Cost��62   $ 20Q�5Q   .   $ * 6<   
 ����� 5S   .   �� $
 cost�$ OneWay=�5Y      5[      5\      5^      5_      5`      