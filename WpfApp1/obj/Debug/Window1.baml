   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Window1��5   	   $	��450��6   $	��800��6&    � 	Resources 5	         WpfApp1.marathonDataSet   marathonDataSet  charityViewSource �� Source �� Source  dataTable3ViewSource��%�   &	        &	      7   &	 @     7     5
   
   6    �� 5   
    69   �� *	Charity+8   �� 5   
    6<   �� *
DataTable3+8   5      .��5      �  � DataContext# [ 6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataTable3DataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��164,116,228,103q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6j   �� # [ 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        runnerIdColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 	Runner Id��5   Z      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
RunnerId+6m     5      -   5        eventNameColumn��$
 
Event Name��5   \   $ SizeToHeader 6p    6>   �� *	EventName+6p     5      -   5        raceTimeColumn��$
 	Race Time��5   Z   $ SizeToHeader 6m    6=   �� *
RaceTime+6m     5      -   5        dataColumn1Column��$
 Data Column 1��5   `   $ SizeToHeader 6w    6@   �� *DataColumn1+6w     5      -   5        genderColumn��$
 Gender��5   V   $ SizeToHeader 6f    6;   �� *Gender+6f   5      5      5      