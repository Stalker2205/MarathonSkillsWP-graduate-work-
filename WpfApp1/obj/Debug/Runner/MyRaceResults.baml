   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MyRaceResults   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  
MainWindow��5   	   $��434.667��6   $	��494��6-    � 	Resources 5	         WpfApp1.marathonDataSet   marathonDataSet  genderViewSource �� Source �� Source  eventViewSource  dataTable3ViewSource��%�   &	        &	      7   &	 ?     7   &	 j     7     5
   
   6    �� 5   
    68   �� *Gender+8   �� 5   
    67   �� *Event+8   �� 5   
    6<   �� *
DataTable3+8   5      .��5      � $��0,-2,0,2q�6    � DataContext# [ 6    � RowDefinitions 5   
   �� 5      .+�5   
   � -   5         �Name$ grid1��5      $
��Left=�6   $��354,135,0,0q�69   $	��Top=�6N    J� RenderTransformOrigin$ -0.394,-1.641&�6f   $��0��6�   $��0��6�    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    5      � 5   
   $��32��6   $��	0,370,0,0q�6   $	��Top=�6.   
���   �.+�5      �� -   5        $��	LabelTime��5   �   $S��M18 дней 8 часов и 17 минут до старта марафона!��6   $
��Left=�6M   
�������$��92,5,0,0q�6{   $	��Top=�6�   $ -0.491,0.41&�6�   $��29��6�   5      � 5    
   $
��Left=�6   $��31��6*   $	��Top=�66   $	��484��6N   
���   �.+�5!      �� -   5        $��
Назад��5!      
�������$
��Left=�68   $��11,5,0,0q�6S   $	��Top=�6e   $��75��6}   $ -0.569,0.45&�6�   6�   �� 5"      $��MARATHON SKILLS 2020��6   
�������$
��Left=�6F   $��	158,2,0,0q�6a   $	��Top=�6t   $ -0.149,-0.064&�6�   5#      � 5$   
   $
��Left=�6   $	��100��6*   $��	10,36,0,0q�67   $	��Top=�6J   $	��466��6b   .+�5%      �� $
��Left=�6   $��	10,10,0,0q�63   $
��Wrap=�6F   $!��Мои результаты��6Z   $	��Top=�6p   $	��446��6�   $��27��6�   	 �� TextAlignment$	 Center=�6�   
�������{�.  $��18(�6�   �� 5&      $
��Left=�6   $��	10,42,0,0q�63   $
��Wrap=�6F   $}��wТут вы можите посмотреть результаты и свое место в соревнованиях��6Z   $	 Center=�6�   {�.  $	��Top=�6�   $	��446��6�   $��48��6�   $��16(�6�   5'      � 5(   
   -   5        $ grid2��5(      # [ 6   $
��Left=�6N   $��	0,128,0,0q�6i   $	��Top=�6|    5)      �� 5*      $
��Auto �6#   �� 5+      $
��Auto �6#    5-      �� 5.      $
��Auto �6    50      � 51   
   -   5        $ grid3��51      # [ 6   $
��Left=�6M   $��172,128,0,0q�6h   $	��Top=�6}    52      �� 53      $
��Auto �6#   �� 54      $
��Auto �6#    56      �� 57      $
��Auto �6    59      &   System.Windows.Controls.DataGrid  5:   
   -   5        
  Name$
 dataTable3DataGrid��5:         AutoGenerateColumns .     EnableRowVirtualization . $��10,128,10,39q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6j   ��    Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      -   5        runnerIdColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 	Runner Id��5<   Z      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
RunnerId+6m     5=      -	   5        eventNameColumn��$ 
Event Name��5=   \   $ SizeToHeader 6p    6>   �� *	EventName+6p     5>      -
   5        raceTimeColumn��$ 	Race Time��5>   Z   $ SizeToHeader 6m    6=   �� *
RaceTime+6m     5?      -   5        genderColumn��$ Gender��5?   V   $ SizeToHeader 6f    6;   �� *Gender+6f   5A      5B      5C      