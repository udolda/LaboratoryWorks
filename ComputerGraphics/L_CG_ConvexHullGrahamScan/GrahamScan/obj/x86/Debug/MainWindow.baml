   M S B A M L   `   `   `  ����E  AGrahamScan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GrahamScan
GrahamScan  5   	       GrahamScan.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /
GrahamScanclr-namespace:GrahamScan     5   	     � Title$  Graham Scan��5	   	   $	��500��6   $	��525��6*    � 
ResizeMode$ NoResize=�66   .��5
      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $*��$Click the area below to add points  ��6   5      � 5      .+�5      �� -   5        $��MainItemsControl��5   6   
�������$	��500��6�   $	��400��6�   ��6}   �� *Points+��5      �� 5      .R�5      �� 5      5      ��5      �� 5      .R�5      �� 
���   �$��3��6-   $��3��67   6D   5      ��5      �� 5      .�5      ��  �� Property �@��Top �� Value 63   ��  �� Path$ Y��� 5       �@��Left 64   �� $ X�5       5"      � 5#       K� ZIndex$	 100��6   $	��500��6)   $	��400��65   
���  �� � Points 6O   �� $ 
HullPoints�6t   5$      �� 5%      $   GrahamScan.MainWindowViewModel   CreateConvexHull#��Z 6   $��Draw a convex hull��6Z   �� 5&      	   ClearPoints#��Z	 6   $��Clear points��6U   5'      5(      5)      