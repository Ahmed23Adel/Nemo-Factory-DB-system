   M S B A M L   `   `   `  ����?  ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nemo.ManagerNemo.Manager  5          Nemo.Manager.Employees   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Nemo.Manager     5        N� Title$  	employees��5	       � 	Resources 5
         rowsOptions��%E  &	        �� 5   
   @�5      m� 5      -   5        $��Update��5      m� 5      -   5        $��Delete��5      m� 5      -   5        $��Make it Manager��5      m� 5      -   5        $��Make it Worker��5      m� 5      -   5        $��Make it Supervisor��5      5      5      .��5!      �� $	��700��6   $
��Auto=�6#   .��5"   
   ��   WordBlueBrush#��[ 6   $��14q�5#      ._�5$      � ��5&      �� 5'       j� TileMode$
 Tile=�6!    j� ViewportUnits$ Absolute=�5(   !    j� Viewport$ 0 0 500 500�5)   !    �� ImageSource$. (/Images/Backgrounds/emoji-background.png��5*   !   .+�5-      �� .+�5.      � .+�5/      �  � ColumnDefinitions 50      �� 51   "   $	��10* �63   �� 52   "   $��* �63   �� 53   "   $��* �63   .+�56      �� -   5        $��1��57   %   $��30��58   %   $��
16  4 16 4q�59   %    J� RenderTransformOrigin$ 0.5,0.57&�5:   %   $��35��5;   %   ��5>   "   �� 5?   &    �� DecodePixelWidth$	 400��62   	 �� 	UriSource$	 ../Images/search.ico?�6I   5A      �� 5C      -   5        $��2��5D   %   $��30��5E   %   $ 0.5,0.57&�5F   %   $��35��5G   %   ��5I   "   �� 5J   &   $	 400��62   $	 ../Images/plus.ico?�6I   5L      5M      5O      &   System.Windows.Controls.DataGrid  5S      -   5        
  Name$
 allEmps��5T      $��14 14 14 14q�5U      
������ 
���   �   RowBackground
 ����    AutoGenerateColumns .   	 dGrid#��[ 5[         CanUserAddRows .     
IsReadOnly . ��5Y      ��  �� Path$ 
Collection�   	CellStyle 5`      �� 5a       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$   .�5b   "   ��  �� Property �@�ContextMenu �� Value# [  6@   5c         Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��61      FontSize$ 20Q�5j   1      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?      
Foreground
 �����1  +System.Windows.Controls.DataGridBoundColumn   Binding 5l   1   �� $
 Name� �� Mode$ OneWay=�  5n      $ Job description��62   $ 20Q�5o   2   $ * 6@   
 ����� 5q   2   �� $ Jop_description�$ OneWay=�  5s      $ Balance��63   $ 20Q�5t   3   $ * 6A   
 ����� 5v   3   �� $ Salary�$ OneWay=�5y      5{      5|      5~      5      5�      