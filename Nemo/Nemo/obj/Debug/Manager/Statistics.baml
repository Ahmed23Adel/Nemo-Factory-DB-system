   M S B A M L   `   `   `  ����?  ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nemo.ManagerNemo.Manager  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          Nemo.Manager.Statistics   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Nemo.Manager     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        N� Title$  
Statistics��5
      .��5      ��    WordBlueBrush#��[  6   $��14q�69   ._�5   
   � ��5      �� 5       j� TileMode$
 Tile=�6    j� ViewportUnits$ Absolute=�6-    j� Viewport$ 0 0 500 500�6F    �� ImageSource$. (/Images/Backgrounds/emoji-background.png��6]   .+�5      �� $
��Auto=�6   $
��Auto=�6>   $	��650��6c   ��. .��5      �� .+�5      � $
��Auto��6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   .+�5      �� .+�5      �� -   5         ��Name$ numEmps��5   &   $8��2You have 20 Worker, 30 superVisor, and 60 manager ��5   !   
������ 
�������$��8 8 8 8q�5    %   $��20(�5!   &   $��0 0 0 0q�5"   &    �� 
IsReadOnly . 5#   &   &   System.Windows.Controls.DataGrid  5%      -   5          Name$ avgSal��5&   +   $��0��5%   '   $	��180��5'   +   $	��300��5(   +   $��8 8 8 8q�5)   +   $
��Left=�5*   +   $	��Top=�5+   +   
������ 
���   �	   RowBackground
	 ���� 
   AutoGenerateColumns
 .   	 dGrid#��[ 51   *      CanUserAddRows .  ��5/   *   ��  �� Path$ 
Collection�   Columns 55   "   0  *System.Windows.Controls.DataGridTextColumn  56   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Production line ��69      FontSize$ 20Q�57   5      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6C      
Foreground
 �����1  +System.Windows.Controls.DataGridBoundColumn   Binding 59   5   �� $ Production_line� �� Mode$ OneWay=�  5<   &   $ Average salaries��69   $ 20Q�5=   5   $ * 6C   
 ����� 5?   5   �� $ Average�$ OneWay=�5D      5E        LiveCharts.Wpf.PieChart  5F      -   5          Name$ maleToFemale��5K   #   $��1��5F   '   $	��200��5G   #   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�5H   #      	Hoverable .     DataTooltip 5J   #   Z�    Series 5L   #   �� *SeriesCollection+5O      5P      �� 5Q      $��	16 16 8 8q�6   � 5e      $
��Auto��6   $
��Auto��6%    5f      �� 5g      $��* �6+   .+�5k      �� .+�5l      �� $6��0Top 5 Production lines (based on daily produced)��6$   
�������$��	16 8 16 8q�5n   $   $��15(�5o   $     5p      -   5        $ topProdLines��5p   $   $	��150��5q   #   $	��700��5r   #   $��8 8 8 8q�5s   #   $��Stretch=�5t   #   $	��Top=�5u   #   
������ 
���   �
	 ���� 
 .  #��[ 5{   "    .  ��5y   "   �� $ 
Collection� 5        5�   "   $ Production line��65   $ 20Q�5�   -   $ * 6;   
 ����� 5�   -   �� $ prodLine�$ OneWay=�  5�   "   $ Start date ��65   $ 20Q�5�   -   $ * 6;   
 ����� 5�   -   �� $ Product�$ OneWay=�  5�   "   $ Daily amount��65   $ 20Q�5�   -   $ * 6;   
 ����� 5�   -   �� $ Daily_amount�$ OneWay=�  5�   "   $ 
Supervisor��65   $ 20Q�5�   -   $ * 6;   
 ����� 5�   -   �� $ 
supervisor�$ OneWay=�5�      5�      5�      �� 5�      $��	16 16 8 8q�6   � 5�      $
��Auto��6    5�      �� 5�      $��* �6+   .+�5�      �� .+�5�      �� $2��,Oldest 20 machies, may be you need to update��6$   
�������$��	16 8 16 8q�5�   $   $��15(�5�   $     5�      -   5        $ oldMachines��5�   $   $	��150��5�   #   $	��700��5�   #   $��8 8 8 8q�5�   #   $
��Left=�5�   #   $	��Top=�5�   #   
������ 
���   �
	 ���� 
 .  #��[ 5�   "    .  ��5�   "   �� $ 
Collection� 5�        5�   "   $ Machine name��65   $ 20Q�5�   -   $ * 6;   
 ����� 5�   -   �� $
 Name�$ OneWay=�  5�   "   $ Start date ��65   $ 20Q�5�   -   $ * 6;   
 ����� 5�   -   �� $ 
Start_date�$ OneWay=�5�      �� 5�      $��	16 16 8 8q�6(   �� 5�      $)��#Histogram of addresses of employees��6$   
�������$��20(�6f   $��4 4 4 4q�6u   #  LiveCharts.Wpf.CartesianChart  5�      $	��200��5�   1   $
 Left=�5�   1     WordOrangeBrush#��[ 5�   1   $
��Auto��5�   1    5�   1   �� *SeriesCollection3+   SeriesColors 5�   &   %	  LiveCharts.Wpf.ColorsCollection	  ��5�   *   
Orange��68   5�   '      AxisX 5�   &   
  LiveCharts.Wpf.Axis
   
  Title$ Address��6/    
  
Foreground# [ 6Z    
  FontSize$ 20Q�6�    
  Labels 6?   �� *	Address+6�      AxisY 5�   &   
  $ Count��6/   # [ 6^   $ 20Q�6�     
  LabelFormatter  6=   �� *count+6�   5�      �� 5�      $��	16 16 8 8q�6(   �� 5�      $)��#Histogram of religions of employees��6$   
�������$��20(�6e   $��4 4 4 4q�6s     5�      $	��120��5�   1   $
 Left=�5�   1   #��[ 5�   1   $
��Auto��5�   1    5�   1   �� *SeriesCollection4+ 5�   &   	  ��5�   *   
Orange��68   5�   '    5�   &   
  $ Religion��6/   # [ 6\   $ 20Q�6�    6@   �� *
Religion+6�    5�   &   
  $ Count��6/   # [ 6_   $ 20Q�6�     6=   �� *Countr+6�   5�      �� 5�      $��	16 16 8 8q�6(   5�      5�      5�      5�      5�      5     5     