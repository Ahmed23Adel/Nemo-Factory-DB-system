   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   ? ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nemo.ManagerNemo.Manager 5   	   #   Nemo.Manager.StatsProdSeeMore   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   ,localclr-namespace:Nemo.Manager     5   	     � Title$  StatsProdSeeMore��5	   	   $	��700��6"   $
��1000��6/   .��5
      ��    WordBlueBrush#��[  6   $��14q�69   ._�5   
   � ��5      �� 5       j� TileMode$
 Tile=�6    j� ViewportUnits$ Absolute=�6-    j� Viewport$ 0 0 500 500�6F    �� ImageSource$. (/Images/Backgrounds/emoji-background.png��6]   .+�5      �� .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   .+�5      �� .+�5      �� $��Choose One product ��6$   $��15(�5       
�������$��
16 16 16 0q�5       �� 5      $%�� to see  production over years.��6$   $��15(�5       
�������$��
16 0 16 16q�5        5"      �� 5$      -   5         ��Name$ productionLines��5$      $��1��5%      $	��150��5&      $��40��5'      $
��Left=�5(      $��16 16 16 16q�5)      
���   � �� DisplayMemberPath$
 Name��5,       �� SelectedValuePath$ ID��5-      �� 50      -   5        $ products��50      $��2��51      $	��150��52      $��40��53      $
��Left=�54      $��16 16 16 16q�55      
���   �$
 Name��57      $ 
product_id��58      �� 5:      -   5        $��3��5;      $��
See result��5<      $
��Left=�5=      $
��Bold"�5>      $��16 16 16 16q�5?        	updateEmp#��[ 5@      5A      � 5B       5C      �� 5D      $��* �6+   �� 5E      $��* �6+   .+�5G      �� $��0��6!   .+�5H      	� -   5        	 	�Name$	 seeProductAllYears��5H   &   $��Over all years��5I      
�������$��16 8 8 8q�5K      $��20(�5L      
 d� 	IsChecked$

 TrueY�5N      	� 5Q      -   5        $	 seeProductThisYears��5Q   &   $��Over this year only��5R      
�������$��16 8 8 8q�5T      $��20(�5U      5V      5X      �� 5Z      $��1��6!   .+�5[      	� -   5        $	 accumulated��5[   &   $��Accumulated��5\   %   
�������$��16 8 8 8q�5^   %   $��20(�5_   %   $

 TrueY�5a   %   	� 5d      -   5        $	 notAccumulated��5d   &   $��Not Accumulated��5e   %   
�������$��16 8 8 8q�5g   %   $��20(�5h   %   5i   %   5k      5l      #   LiveCharts.Wpf.CartesianChart  5o      -   5          Name$ productGraph��5p   )   &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�5o   P   $	��200��5q   )      Series 5o   %   �� *SeriesCollectionProduct+   SeriesColors 5v      %   LiveCharts.Wpf.ColorsCollection  ��5w      #014001��6-   5x         AxisY 5|         LiveCharts.Wpf.Axis     Title$ Productoin amount��6#      LabelFormatter 6=   �� *sum+6^      AxisX 5        $
 Year��6#      Labels 60   �� *year+6J   5�      5�      5�      5�      5�      