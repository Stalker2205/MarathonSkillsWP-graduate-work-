   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.ManageCharities   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  ManageCharities��5   	   $��434.667��6!   $	��494��62    � 	Resources 5	         WpfApp1.marathonDataSet   marathonDataSet  charityViewSource �� Source �� Source��%X   &	        &	      7     5
   
   6    �� 5   
    69   �� *	Charity+8   5      .��5      � $��0,-2,0,2q�6    � DataContext# [ 6    � RowDefinitions 5   
   �� 5      .+�5   
   � -   5         �Name$ grid1��5      $
��Left=�6   $��354,135,0,0q�69   $	��Top=�6N    J� RenderTransformOrigin$ -0.394,-1.641&�6f   $��0��6�   $��0��6�    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    5      � 5   
   $��32��6   $��	0,370,0,0q�6   $	��Top=�6.   
���   �.+�5      �� -   5        $��	LabelTime��5   �   $S��M18 дней 8 часов и 17 минут до старта марафона!��6   $
��Left=�6M   
�������$��92,5,0,0q�6{   $	��Top=�6�   $ -0.491,0.41&�6�   $��29��6�   5      � 5   
   $
��Left=�6   $��31��6*   $	��Top=�66   $	��484��6N   
���   �.+�5      �� -   5        $��
Назад��5      
�������$
��Left=�68   $��11,5,0,0q�6S   $	��Top=�6e   $��75��6}   $ -0.569,0.45&�6�   6�   �� 5       $��MARATHON SKILLS 2020��6   
�������$
��Left=�6F   $��	158,2,0,0q�6a   $	��Top=�6t   $ -0.149,-0.064&�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        	  Name$	 charityDataGrid��5"      
   AutoGenerateColumns
 .     EnableRowVirtualization . $��10,36,10,122q�6      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6g   ��    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        charityIdColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
Charity Id��5$   \      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	CharityId+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5%      -   5        charityNameColumn��$ Charity Name��5%   D   $ SizeToHeader 6Z      CellTemplate 5&      �� 5'      .R�5(      �� ��6$   �� *CharityName+5)      5+        5,      -   5        charityDescriptionColumn��$ Charity Description��5,   K   $ SizeToHeader 6h    5-      �� 5.      .R�5/      �� ��6$   �� *CharityDescription+50      52        53      -	   5        charityLogoColumn��$ Charity Logo��53   D   $ SizeToHeader 6Z    54      �� 55      .R�56      �� $��Imgchar��6$   57      59        5:       5;      �� 5<      .R�5=      ��  ��Name$ Details��6%   -
   5        .��5=   L   	Details6U   5>      5@      5C      5D      5E      