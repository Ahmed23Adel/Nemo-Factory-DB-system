   M S B A M L   `   `   `  ����?  ;Nemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nemo.ManagerNemo.Manager  5   	   !    Nemo.Manager.UpdateEmployee   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Nemo.Manager     5   	   -   5          � Title$  Update employee��5   	   $	��550��6!   $	��850��6.   .��5      ��    WordBlueBrush#��[  6   $��14q�5      ._�5   
   � ��5      �� 5       j� TileMode$
 Tile=�6    j� ViewportUnits$ Absolute=�5       j� Viewport$ 0 0 500 500�5       �� ImageSource$. (/Images/Backgrounds/emoji-background.png��5      .+�5      �� .+�5      � $��8 8 8 8q�6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5       $��* �6+   �� 5"      $��* �6+   �� 5$      $��* �6+   .+�5(      �� $��National ID: ��6    $��0��5)       $��20(�5*       $��8 8 8 8q�5+       
�������5,       �� 5/      -   5         ��Name$ 
nationalId��5/      $��1��50      $��20(�51      $��8 8 8 8q�52      
�������
������ 54      �� 56      $��Job title: ��6    $��2��57       $��20(�58       $��8 8 8 8q�59       
�������5:       �� 5<      -   5         ��Name$ 	jop_title��5<      $��3��5=      $��20(�5>      $��8 8 8 8q�5?      .@�5@      �� $��Not defined��6'   �� 5A      $��Manager��6'   �� 5B      $��Worker��6'   �� 5C      $��
Supervisor��6'   5D      5F      �� 5H      � 5K      $��8 8 8 8q�6    5L      �� 5N      $��* �6+   �� 5P      $��* �6+   �� 5R      $��* �6+   �� 5T      $��* �6+   .+�5W      �� $��First Name: ��6    $��0��5X       $��20(�5Y       $��8 8 8 8q�5Z       
�������5[       �� 5^      -   5        $ fName��5^      $��1��5_      $��20(�5`      $��8 8 8 8q�5a      
�������
������ 5c      �� 5e      $��Last Name: ��6    $��2��5f       $��20(�5g       $��8 8 8 8q�5h       
�������5i       �� 5k      -   5        $ lName��5k      $��3��5l      $��20(�5m      $��8 8 8 8q�5n      
�������
������ 5p      5q      �� 5s      � 5u      $��8 8 8 8q�6    5v      �� 5x      $��* �6+   �� 5z      $��* �6+   �� 5|      $��* �6+   �� 5~      $��* �6+   .+�5�      �� $��Salary: ��6    $��0��5�       $��20(�5�       $��8 8 8 8q�5�       
�������5�       �� 5�      -   5        $ salary��5�      $��1��5�      $��20(�5�      $��8 8 8 8q�5�      
�������
������ 5�      �� 5�      $��Birth date: ��6    $��2��5�       $��20(�5�       $��8 8 8 8q�5�       
�������5�       (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ bdate��5�   !   $��3��5�   "   $��20(�5�   !   $��8 8 8 8q�5�   !   5�      �� 5�      � 5�      $��8 8 8 8q�6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��0��6    $��User name: ��5�       $��20(�5�       $��8 8 8 8q�5�       
�������5�       �� 5�      -   5        $ userNameField��5�      $��1��5�      $��20(�5�      $��8 8 8 8q�5�      
�������
������ 5�      �� 5�      $��2��6    $��
Password: ��5�       $��20(�5�       $��8 8 8 8q�5�       
�������5�       �� 5�      -	   5        $
 pass��5�      $��3��5�      $��20(�5�      $��8 8 8 8q�5�      
�������
������ 5�      5�      � 5�      $��8 8 8 8q�6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��0��6    $��Gender: ��5�       $��20(�5�       $��8 8 8 8q�5�       
�������5�       �� 5�      -
   5        $ gender��5�      $��1��5�      $��20(�5�      $��8 8 8 8q�5�      
���   �
������ .@�5�      �� $��Not defined��6'   
���   �6=   �� 5�      $
��Male��6'   
���   �66   �� 5�      $��Female��6'   
���   �68   5�      �� 5�      $��2��6    $��	Address: ��5�       $��20(�5�       $��8 8 8 8q�5�       
�������5�       �� 5�      -   5        $ address��5�      $��3��5�      $��20(�5�      $��8 8 8 8q�5�      
�������
������ 5�      5�      � 5�      $��8 8 8 8q�6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5     $��* �6+   .+�5     �� $��0��6    $��
Religion: ��5      $��20(�5      $��8 8 8 8q�5      
�������5	      �� 5     -   5        $ religion��5     $��1��5     $��20(�5     $��8 8 8 8q�5     
�������
������ 5     �� 5     $��2��6    $��Status: ��5      $��20(�5      $��8 8 8 8q�5      
�������5      �� 5     -   5        $ status��5     $��3��5     $��20(�5     $��8 8 8 8q�5     
���   �
������ .@�5     �� $��	Undefined��6'   
���   �6;   �� 5      $��Married��6'   
���   �69   �� 5!     $��Not married  ��6'   
���   �6?   5"     5#     � 5%     $��8 8 8 8q�6    5&     �� 5(     $��* �6+   �� 5*     $��* �6+   �� 5,     $��* �6+   .+�50     �� -   5        $��0��51     $��Cancel��52     $��Center=�53     $
��Bold"�54      
 cancel#��[ 55     �� 57     -   5        $��1��58     $��Remove��59     $��Center=�5:     $
��Bold"�5;       	updateEmp#��[ 5<     �� 5>     -   5        $��2��5?     $��Update��5@     $��Center=�5A     $
��Bold"�5B     #��[ 5C     5E     5G     5I     5J     5K     