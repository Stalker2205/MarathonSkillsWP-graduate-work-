   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.SpisokOrg   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  
MainWindow��5   	   $��434.667��6   $	��494��6-    � 	Resources 5	         WpfApp1.marathonDataSet   marathonDataSet  charity1ViewSource �� Source �� Source��%Y   &	        &	      7     5
   
   6    �� 5   
    6:   �� *
Charity1+8   5      .��5      � $��0,-2,0,2q�6    � DataContext# [ 6   .+�5   
   � $��32��6   $��	0,371,0,0q�6   $	��Top=�6.   
���   �.+�5      �� -   5        $��	LabelTime��5   �   $S��M18 дней 8 часов и 17 минут до старта марафона!��6   $
��Left=�6M   
�������$��92,5,0,0q�6{   $	��Top=�6�    J� RenderTransformOrigin$ -0.491,0.41&�6�   $��29��6�   5      � 5   
   $
��Left=�6   $��31��6*   $	��Top=�66   $	��484��6N   
���   �.+�5      �� -   5        $��
Назад��5      
�������$
��Left=�68   $��11,5,0,0q�6S   $	��Top=�6e   $��75��6}   $ -0.569,0.45&�6�   6�   �� 5      $��MARATHON SKILLS 2020��6   
�������$
��Left=�6F   $��	158,2,0,0q�6a   $	��Top=�6t   $ -0.149,-0.064&�6�   5      � 5   
   $
��Left=�6   $��89��6*   $��	10,36,0,0q�66   $	��Top=�6I   $	��466��6a   .+�5      �� {�.  
������� �� TextAlignment$ Center=�6<   $
��Left=�6S   $��0,3,0,0q�6n   $
��Wrap=�6   $L��FСписок благотворительных организаций��6�   $	��Top=�6�   $ -2.905,-3.603&�6�   $	��466��6�   $��35��6	  $��18(�6  �� 5      $
��Left=�6   $��0,38,0,0q�63   $
��Wrap=�6E   $����Это - список всех благотворительных организаций, которые поддерживаются в Marathon skills 2020. Спасибо за помощь вы поддерживаете их, спонсируя бегунов!��6Y   $ Center=�6�   $	��Top=�6  $	��466��6)  $��44��65  5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ charity1DataGrid��5         AutoGenerateColumns .  	   EnableRowVirtualization	 . $��11,107,9,63q�6�   
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�6�   ��6h   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        charityLogoColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Charity Logo��5   a      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *CharityLogo+6w     5      -   5        charityLogoColumn1��$ Charity Logo��5   h   $ SizeToHeader 6~    6A   ��  �� Path$ CharityLogo1�6~     5      -   5        expr1Column��$ Expr 1��5   T      
IsReadOnly . $ SizeToHeader 6v    6:   �� *Expr1+6v     5      -   5        charityIdColumn��$ 
Charity Id��5   \    . $ SizeToHeader 6�    6>   �� *	CharityId+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ MyImage��6)      MaxWidth$	 300Q�6:      CellTemplate 5       �� 5!      .R�5"      �� ��6%   �� $ Images�5#      5%      5'      �� 5(   
   -	   5        $��Button��5(      $
��Left=�67   $��189,346,0,0q�6R   $	��Top=�6g   $��75��6   5+      5,      