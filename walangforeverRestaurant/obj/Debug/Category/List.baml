   M S B A M L   `   `   `  ����R  NwalangforeverRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:walangforeverRestaurant.Category walangforeverRestaurant.Category  5   	   +    %walangforeverRestaurant.Category.List   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:walangforeverRestaurant.Category     5   	     � Title$
  List��5   	   $��460.1��6   $	��718��6%   .��5	      � $��0,0,2,0q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ grList��5
      $
��Left=�6#   $	��186��6>   $��
59,118,0,0q�6K   $	��Top=�6_   $	��606��6w      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   0   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� *Name+60   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� 	 ��Name$	 btnConfirmViewChildren��6%   -   5        y�5   c   �� *ShowChildrenButton+.��6�   View Children6�   5      5        5       5      �� 5      .R�5      �� $	 btnConfirmViewProducts��6%   -   5        y�5   c   �� *ShowProductsButton+.��6�   View Products6�   5      5        5       5      �� 5      .R�5      �� $	 btnUpdate_Click��6%   -   5        .��5   V   Update6^   5       5"      5%      �� 5'   
   -   5        $	 btnLast��5'      $��>|��6"   $
��Left=�62   $��476,376,0,0q�6M   $	��Top=�6b   $��34��6z   $��35��6�   6�   �� 5(   
   -   5        $	 btnFirst��5(      $��|<��6#   $
��Left=�63   $��208,376,0,0q�6N   $	��Top=�6c   $��38��6{   $��35��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   6�   �� 5)   
   -   5        $	 btnNext��5)      $��>��6"   $
��Left=�61   $��436,376,0,0q�6L   $	��Top=�6a   $��36��6y   $
 0.481,0.455&�6�   $��35��6�   6�   �� 5*   
   -   5        $	 btnPrevious��5*      $��<��6&   $
��Left=�65   $��250,376,0,0q�6P   $	��Top=�6e   $��42��6}   $
 0.5,0.5&�6�   $��35��6�   6�   �� 5+   
   -	   5         ��Name$ lblPages��5+      $��          Page X of Y��6"   $��Center=�6B   $��297,381,277,0q�6_   $	��Top=�6v   $	��134��6�   �� 5,   
   -
   5        $ lblSort��5,      $��Sort By��6!   $
��Left=�63   $��	61,80,0,0q�6N   $	��Top=�6a   $
 0.5,0.5&�6y   $��25��6�   $��63��6�   z�5-      V� 5.      .~�5/      �� �� 50      �� 51       �� Angle$ -0.725Q�6&   T� 52      53      55      �� 56   
   -   5         ��Name$ cboSortOrder��56      $
��Left=�6)   $��
124,80,0,0q�6D   $	��Top=�6X   $��94��6p   6{   �� 57   
   -   5        $ 	lblResult��57      $��Search Result : Z Users��6#   $��Center=�6E   $��60,309,460,0q�6b   $	��Top=�6x   $
 	0.5,0.346&�6�   $	��188��6�   �� 58   
   -   5        $ lblPageSize��58      $��	Page Size��6%   $
��Left=�69   $��
65,340,0,0q�6T   $	��Top=�6h   $��87��6�   �� 59   
   -   5         ��Name$ txtboxPageSize��59      $
��Left=�6*   $��23��6E   $��158,343,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $��3��6z   $	��Top=�6�   $��31��6�   6�   �� 5:   
   -   5        $ txtBoxSearch��5:      $
��Left=�6(   $��23��6C   $��
460,79,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $��95��6�   $
 0.508,0.522&�6�   �� 5;   
   -   5        $	 	btnSearch��5;      $��Search��6$   $
��Left=�65   $��
582,79,0,0q�6P   $	��Top=�6d   $��84��6|   6�   �� 5<   
   -   5        $ lblTitle��5<      $��
Categories��6"   $
��Left=�67   $��	59,10,0,0q�6R   $	��Top=�6e   $	��439��6}   $��33��6�   $��18(�6�   $
��Bold"�6�   �� 5=   
   -   5        $	 btnAdd��5=      $��Add Category��6!   $
��Left=�68   $��582,313,0,0q�6S   $	��Top=�6h   $��75��6�   6�   5@      5A      