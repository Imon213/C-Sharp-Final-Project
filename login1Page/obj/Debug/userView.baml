   M S B A M L   `   `   `  ����E  Alogin1Page, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:login1Page
login1Page  5   	       login1Page.userView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:login1Page     5   	     � Title$  userView��5   	   $	��550��6   $
��1200��6'   .��5	      � 
����·�$��0,0,2,3q�6     � ColumnDefinitions 5
   
   �� 5      $
��377* �6   �� 5      $
��105* �6   .+�5   
   �� -   5        $��DR��5      $��30(�6   
��� � �$
��Left=�6;   $��
710,25,0,0q�6V   $	��Top=�6j   $	��452��6�    J� RenderTransformOrigin$ 0.403,0.622&�6�   $��2��6�   �� 5   
   -   5         ��Name$ DR_Copy��5      $�� ��6!   $��20(�6,   
��� � �$
��Left=�6M   $��635,176,0,0q�6h   $	��Top=�6}   $��67��6�   $ 0.403,0.622&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��profileshow��5      $��20(�6&   
�������
��� � �
�������$
��Left=�6o   $��97��6�   $��121,165,0,0q�6�   $	��Top=�6�   $	��581��6�     5   
   -   5          Name$ grid1��5      $
��Left=�6"   $��12(�6=   
��� � �$	��130��6_   $��
10,320,0,0q�6l   $	��Top=�6�   $	��767��6�   �� 5   
   
���   �$��1q�6&   
��� � �$
��Left=�6M   $��91��6h   $
��-3,0q�6t   $	��Top=�6�   $
��1196��6�   $ 0.5,0.5&�6�   $��2��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.312Q�6&   T� 5      5      5      �� 5   
   -   5        $��SHOW PROFILE��5      $��16(�6<   
��� � �
��� � �$
��Left=�6r   $	��Top=�6�   $	��123��6�   $��	64,36,0,0q�6�   $ 0.528,0.125&�6�   z�5      V� 5      .~�5      �� �� 5       �� 5!      $ 0.648Q�6&   T� 5"      5#      5%      �� 5&   
   -   5        $��ADD CONSULTATION��5&      
��� � �
��� � �$��16(�6S   $
��Left=�6a   $��
247,35,0,0q�6�   $	��Top=�6�   $	��165��6�   �� 5'   
   -   5        $��SHOW CONSULTATION��5'      $��16(�6-   
��� � �
��� � �$
��Left=�6b   $��
509,35,0,0q�6�   $	��Top=�6�   $	��178��6�   �� 5(   
   -   5        $��SHOW PATIENTLIST��5(      $��16(�6,   
��� � �
��� � �$
��Left=�6u   $	��Top=�6�   $	��154��6�   $��
777,35,0,0q�6�   �� 5)   
   -	   5        $��LOGOUT��5)      
��� � �
��� � �$��16(�6I   $
��Left=�6l   $��
100,35,0,0q�6�   $	��Top=�6�   $��75��6�   $ 
0.453,0.22&�6�   $��1��6�   �� 5*   
   
������$
��Left=�6-   $	��424��6H   $��
777,92,0,0q�6U   $	��Top=�6i   $	��413��6�   $��2��6�   �� 5+   
   $��Update Profile��6   $��25(�6)   $
��Bold"�67   $��Italic$�6I   $
��Left=�6\   $	��Top=�6w   $��876,116,0,0q�6�   $��2��6�   $	��189��6�   �� 5,   
   $
��Name��6   $��14(�6   $��Italic$�6-   $
��Left=�6@   $	��Top=�6[   $ 1.158,1.885&�6s   $��804,196,0,0q�6�   �� 5-   
   -
   5         ��Name$	 mb1��5-      $
��Left=�6   $��23��6:    �� TextWrapping$
 Wrap=�6F   $	��Top=�6Z   $	��202��6r   $��2��6~   $��886,199,0,0q�6�   �� 5.   
   -   5        $��UPDATE��5.      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��1��6`   $��168,199,0,0q�6p   $��23��6�   6�   �� 5/   
   $��ID��6   $
��Left=�6   $	��Top=�68   $��804,230,0,0q�6P   $ 3.737,4.538&�6e   $��47��6�   �� 50   
   -   5        $	 mb2��50      $
��Left=�6   $��23��6:   $
 Wrap=�6F   $	��Top=�6Z   $	��202��6r   $��2��6~   $��886,233,0,0q�6�   �� 51   
   -   5        $��UPDATE��51      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��168,233,0,0q�6`   $��1��6u   $��26��6�   6�   �� 52   
   $��Email��6   $
��Left=�6    $	��Top=�6;   $ 1.158,2.269&�6S   $��804,264,0,0q�6w   $��47��6�   �� 53   
   -   5        $	 mb3��53      $
��Left=�6   $��23��6:   $
 Wrap=�6F   $	��Top=�6Z   $	��202��6r   $��886,267,0,0q�6~   $��2��6�   �� 54   
   -   5        $��UPDATE��54      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��1��6`   $��168,267,0,0q�6p   $��24��6�   6�   �� 55   
   $��Gender��6   $
��Left=�6!   $	��Top=�6<   $��804,302,0,0q�6T   $��59��6i   $ 	0.809,0.5&�6t   �� 56   
   -   5        $��UPDATE��56      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��1��6`   $��168,303,0,0q�6p   $��23��6�   6�   �� 57   
   $��Address��6   $
��Left=�6"   $	��Top=�6=   $��804,336,0,0q�6U   $��59��6j   �� 58   
   -   5        $	 mb4��58      $
��Left=�6   $��23��6:   $
 Wrap=�6F   $	��Top=�6Z   $	��202��6r   $��2��6~   $��886,339,0,0q�6�   �� 59   
   -   5        $��UPDATE��59      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��168,339,0,0q�6`   $��1��6u   $��23��6�   6�   �� 5:   
   -   5        $	��cb1��5:      $
��Left=�6   $	��Top=�69   $	��202��6Q   $��2��6]   $��886,302,0,0q�6q   $ 0.508,0.909&�6�   $��26��6�   .@�5;      ��  �� 
IsSelected . .��6-   Male63   �� 5<      .��6   Female6#   5=      �� 5>   
   $��
Depertment��6   $
��Left=�6%   $	��Top=�6@   $��804,375,0,0q�6X   $��73��6m   �� 5?   
   -   5        $	 mb5��5?      $
��Left=�6   $��23��6:   $
 Wrap=�6F   $	��Top=�6Z   $	��202��6r   $��2��6~   $��886,378,0,0q�6�   �� 5@   
   -   5        $��UPDATE��5@      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��1��6`   $��168,378,0,0q�6p   $��23��6�   6�   �� 5A   
   $��Enter User Name��6   $
��Left=�6*   $	��Top=�6E   $��809,432,0,0q�6]   $	��112��6r   �� 5B   
   $��Enter Password��6   $
��Left=�6)   $	��Top=�6D   $��809,472,0,0q�6\   $��95��6q   �� 5C   
   -   5        $	 mb6��5C      $
��Left=�6   $��23��6:   $
 Wrap=�6F   $	��Top=�6Z   $	��213��6r   $��2��6~   $��921,436,0,0q�6�   G� 5D   
   -   5        	 G�Name$		 mb7��5D      $
��Left=�6#   $	��Top=�6>   $	��213��6V   $��921,476,0,0q�6b   $��2��6w   $��22��6�   �� 5E   
   -   5        $��l1��5E      $�� ��6   
���  ��$
��Left=�66   $	��Top=�6Q   $��926,410,0,0q�6i   $��2��6~   $	��208��6�   �� 5F   
   -   5        $��l2��5F      $�� ��6   
���  ��$
��Left=�66   $	��Top=�6Q   $��926,454,0,0q�6i   $	��208��6~   $��2��6�   5H      5I      