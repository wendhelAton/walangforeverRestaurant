   M S B A M L   `   `   `  ����R  NwalangforeverRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:walangforeverRestaurant.UserswalangforeverRestaurant.Users  5   	   (    "walangforeverRestaurant.Users.List   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:walangforeverRestaurant.Users     5   	     � Title$  Users��5   	   $��439.1��6   $	��637��6&   .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   �� 5      $	��29* �6   �� 5      $
��263* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgList��5      $
��Left=�6#   $	��116��6>   $��
10,148,0,0q�6K   $	��Top=�6_   $	��598��6w    J� RenderTransformOrigin$ 0.5,0.5&�6�      AutoGenerateColumns .  $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ UserName��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
UserName+6B     5      $ 	FirstName��6%   $ * 5   C    6%   �� *	FirstName+6C     5      $ LastName��6%   $ * 5   B    6%   �� *
LastName+6B     5      $
 Role��6%   $ * 5   >    6%   �� *Role+6>   4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 ��Name$
 btnConfirmUpdate��6%   -   5        .��5   W   Update6_   5      5        5       	 5!      �� 5"      .R�5#      �� $
 btnConfirmDelete_Click��6%   -   5        .��5#   ]   Delete6e   5$      5&      5(      �� 5)   
   -   5        $
 btnLast��5)      $��>|��6"   $��1��62   $
��Left=�6B   $��376,348,0,0q�6]   $	��Top=�6r   $��34��6�   $��35��6�   6�   �� 5*   
   -   5        $
 btnFirst��5*      $��|<��6#   $��1��63   $
��Left=�6C   $��107,348,0,0q�6^   $	��Top=�6s   $��38��6�   $��35��6�   $ 0.5,0.5&�6�   6�   �� 5+   
   -   5        $
 btnNext��5+      $��>��6"   $��1��61   $
��Left=�6A   $��336,348,0,0q�6\   $	��Top=�6q   $��35��6�   $ 0.481,0.455&�6�   $��35��6�   6�   �� 5,   
   -   5        $
 btnPrevious��5,      $��<��6&   $��1��65   $
��Left=�6E   $��150,348,0,0q�6`   $	��Top=�6u   $��41��6�   $ 	0.514,0.5&�6�   $��35��6�   6�   �� 5-   
   -   5         ��Name$ lblPages��5-      $��          Page X of Y��6"   $��1��6B   $��Center=�6R   $��219,353,212,0q�6o   $	��Top=�6�   $	��134��6�   �� 5.   
   -	   5        $ lblSort��5.      $��Sort By��6!   $
��Left=�63   $��
17,106,0,0q�6N   $	��Top=�6b   $��2��6z   �� 5/   
   -
   5         ��Name$ 	cboSortby��5/      $��1��6&   $
��Left=�66   $��	8,106,0,0q�6Q   $	��Top=�6d   $��94��6|   6�   �� 50   
   -   5        $ cboSortOrder��50      $��1��6)   $
��Left=�69   $��120,106,0,0q�6T   $	��Top=�6i   $��93��6�   6�   �� 51   
   -   5        $ 	lblResult��51      $��Search Result : Z Users��6#   $��Center=�6E   $��12,284,427,0q�6b   $	��Top=�6x   $ 	0.5,0.346&�6�   $	��188��6�   $��2��6�   �� 52   
   -   5        $ lblPageSize��52      $��	Page Size��6%   $
��Left=�69   $��
12,315,0,0q�6T   $	��Top=�6h   $��87��6�   $��2��6�   �� 53   
   -   5         ��Name$ txtboxPageSize��53      $��1��6*   $
��Left=�6:   $��23��6U   $��
44,315,0,0q�6a    �� TextWrapping$
 Wrap=�6u   $��3��6�   $	��Top=�6�   $��31��6�   6�   �� 54   
   -   5        $ 	lblFilter��54      $��Filter��6#   $��1��64   $
��Left=�6D   $��228,107,0,0q�6_   $	��Top=�6t   �� 55   
   -   5        $ cboRole��55      $��1��6$   $
��Left=�64   $��264,107,0,0q�6O   $	��Top=�6d   $��80��6|   6�   �� 56   
   -   5        $ txtBoxSearch��56      $��1��6(   $
��Left=�68   $��23��6S   $��349,106,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $��95��6�   $ 0.508,0.522&�6�   �� 57   
   -   5        $
 	btnSearch��57      $��Search��6$   $��1��65   $
��Left=�6E   $��471,106,0,0q�6`   $	��Top=�6u   $��84��6�   6�   �� 58   
   -   5        $
 btnUser��58      $��Add User��6"   $��1��65   $
��Left=�6E   $��471,288,0,0q�6`   $	��Top=�6u   $��75��6�   6�   5:      5;      