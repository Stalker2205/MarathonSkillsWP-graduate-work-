   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Fsponsor   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Fsponsor��5   	   $	��450��6   $	��492��6'    � 	Resources 5	         WpfApp1.marathonDataSet   marathonDataSet  dataTable1ViewSource �� Source �� Source��%[   &	        &	      7     5
   
   6    �� 5   
    6<   �� *
DataTable1+8   5      .��5      �  � RowDefinitions 5   
   �� 5      .+�5   
   � $��39��6   $��
0,380,-2,0q�6   $	��Top=�6/   
���   �$
��Left=�6Z   $	��486��6u   .+�5      �� -   5         ��Name$ 	LabelTime��5   �   $S��M18 дней 8 часов и 17 минут до старта марафона!��6   $
��Left=�6M   
�������$��92,5,0,0q�6{   $	��Top=�6�    J� RenderTransformOrigin$ -0.491,0.41&�6�   $��29��6�   5      � 5   
   $
��Left=�6   $��31��6*   $	��Top=�66   $	��484��6N   
���   �.+�5      �� -   5        $��
Назад��5      
�������$
��Left=�68   $��11,5,0,0q�6S   $	��Top=�6e   $��75��6}   $ -0.569,0.45&�6�   6�   5      �� 5   
   $��MARATHON SKILLS 2020��6   
�������$
��Left=�6B   $��	158,2,0,0q�6]   $	��Top=�6p   $ -0.149,-0.064&�6�   � 5   
   $
��Left=�6   $��56��6*   $��	3,31,-2,0q�66   $	��Top=�6I   $	��483��6a    � ColumnDefinitions 5      �� 5      .+�5      �� $����Пожалуйста выберите бегуна, которого вы хотели бы спонсировать и сумму,��6   $
��Left=�6f   $��12,7,0,0q�6�   $	��Top=�6�   �� 5      $=��7благотворительных учреждений��6   $
��Left=�6;   $��
131,29,0,0q�6V   $	��Top=�6j   $ 0.693,-1.013&�6�   �� 5      $����Которую вы хотели бы спонсировать. Спасибо за вашу поддержку бегунов и их��6   $
��Left=�6h   $��6,18,0,0q�6�   $	��Top=�6�   �� 5      $!��Спонсор бегуна��6   $
��Left=�6-   $��
181,-6,0,0q�6H   $	��Top=�6\   5       � 5!   
   $
��Left=�6   $	��283��6*   $��	10,92,0,0q�67   $	��Top=�6J   $	��240��6b    � DataContext# [ 6n    5"      �� 5#      $	��68* �6    �� 5$      $
��215* �6    .+�5&      �� $.��(Информация о спонсоре��6   
�������$��Center=�6F   $��18(�6c   $	��240��6q   $
��Bold"�6}   $��0,0,0,33.333q�6�   �� 5'      $��Бегун:��6   $
��Left=�6%   $��0,30.667,0,0q�6@   $	��Top=�6V   $��1��6n   �� 5(      $��Владелец��6   $
��Left=�6'   $��0,56.667,0,0q�6B   $	��Top=�6X   $��1��6p   �� 5)      $��Номер карты#:��6   $
��Left=�6,   $��0,82.667,0,0q�6G   $	��Top=�6]   $��1��6u   �� 5*      $ ��Срок действия:��6   $
��Left=�6-   $��0,104.667,0,0q�6H   $	��Top=�6_   $��1��6w   �� 5+      -   5        $��TboxName��5+   1   $
��Left=�6   $��19��6A   $��	66,14,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6t   $	��147��6�   $��1��6�   �� 5,      -   5        
 ��Name$
 TboxName_Copy��5,   1   $
��Left=�6   $��19��6H   $��	66,62,0,0q�6T   $
	 Wrap=�6g   $	��Top=�6{   $	��147��6�   $��1��6�   �� 5-      -   5        $
 TboxName_Copy2��5-   1   $
��Left=�6   $��19��6I   $��92,87.667,0,0q�6U   $
	 Wrap=�6l   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   ��  �� Mode$ OneWay=��� 5.      -   5        $
 TboxName_Copy3��5.   1   $
��Left=�6   $��19��6I   $��92,109.667,0,0q�6U   $
	 Wrap=�6m   $	��Top=�6�   $��51��6�   $��1��6�   �� 5/      -   5        $
 TboxName_Copy4��5/   1   $
��Left=�6   $��19��6I   $��148,109.667,0,0q�6U   $
	 Wrap=�6n   $	��Top=�6�   $��64��6�   $��1��6�   �� 50      -	   5        $
 TboxName_Copy5��50   1   $
��Left=�6   $��19��6I   $��92,135.667,0,0q�6U   $
	 Wrap=�6m   $	��Top=�6�   $��35��6�   $��1��6�   �� 51      $
��CVC:��6   $
��Left=�6#   $��58,130.667,0,0q�6>   $	��Top=�6V   $��1��6n   �� 52      $��Ваше имя:��6   $
��Left=�6(   $��0,9.667,0,0q�6C   $	��Top=�6X   $��1��6p   � 53      -
   5         �Name$ grid1��53      $
��Left=�6"   $��1,41.667,0,0q�6=   $	��Top=�6S   $��1��6k    54      �� 55      $
��Auto �6'   �� 56      $
��Auto �6'    58      �� 59      $
��Auto �6$   5;      � 5<      -   5        $ grid2��5<      $
��Left=�6"   $��109,186,0,0q�6=   $��1��6R   $	��Top=�6_    5=      �� 5>      $
��Auto �6'   �� 5?      $
��Auto �6'    5A      �� 5B      $
��Auto �6$   5D      � 5E      -   5        $ grid3��5E      $
��Left=�6"   $��
138,41,0,0q�6=   $��1��6Q   $	��Top=�6^   $ 0.46,0.5&�6v    5F      �� 5G      $
��Auto �6'   �� 5H      $
��Auto �6'    5J      �� 5K      $
��Auto �6$   5M      � 5N      $
��Left=�6   $��10��6.   $��
182,61,0,0q�6:   $��2��6N   $	��Top=�6_   $��22��6w   � 5O      -   5        $ grid4��5O      $
��Left=�6"   $��
130,44,0,0q�6=   $��1��6Q   $	��Top=�6^    5P      �� 5Q      $
��Auto �6'   �� 5R      $
��Auto �6'    5T      �� 5U      $
��Auto �6$   5W      5X      � 5Y   
   $
��Left=�6   $	��283��6*   $��
255,92,0,0q�67   $	��Top=�6K   $	��219��6c    5Z      �� 5[      .+�5]      �� $,��&Благотворительность��6   
�������$��Center=�6D   $��18(�6a   $	��219��6o   $
��Bold"�6{   $��	0,0,0,248q�6�   �� 5^      -   5        $��OrgName��5^   D   $��Фонд Кошек��6   $
��Left=�6)   $��	10,44,0,0q�6S   $	��Top=�6f   $��14(�6~   �� 5_      $+��%Сумма пожертвования��6   
�������$��Center=�6D   $��18(�6a   $	��219��6o   $
��Bold"�6{   $��
0,86,0,162q�6�   �� 5`      -   5        $��LPric��5`   "   $	��$50��6   
�������$
��Left=�6A   $��
69,111,0,0q�6\   $	��Top=�6p   $
��Bold"�6�   $��36(�6�   $ 0.5,0.5&�6�   �� 5a      -   5        $��	TboxPrice��5a   >   $
��Left=�6   $��29��62   $��
58,169,0,0q�6O   $
	 Wrap=�6c   $��50��6w   $	��Top=�6�   $	��100��6�    �� TextAlignment$ Center=�6�   $��18(�6�   �� 5b      -   5        $��-��5b      $
��Left=�6!   $��
10,169,0,0q�6<   $	��Top=�6P   $��43��6h   $��29��6s   6   �� 5c      -   5        $��+��5c      $
��Left=�68   $��163,169,0,0q�6S   $	��Top=�6h   $��43��6�   $��29��6�   �� 5d      -   5        $��Заплатить��5d      $
��Left=�6)   $��
10,219,0,0q�6D   $	��Top=�6X   $��75��6p   6{   �� 5e      -   5        $��Отмена��5e      $
��Left=�6&   $��134,219,0,0q�6A   $	��Top=�6V   $��75��6n   6y   �� 5f      -   5        $	��(i)��5f      $
��Left=�6L   $��
180,40,0,0q�6g   $	��Top=�6{   $ 0.342,-0.385&�6�   $��22(�6�   5g      � 5h   
   $
��Left=�6   $	��283��6*   $��	10,92,0,0q�67   $	��Top=�6J   $	��240��6b   # [ 6n    5i      �� 5j      $	��68* �6    �� 5k      $
��215* �6    .+�5m      �� $.��(Информация о спонсоре��6   
�������$��Center=�6F   $��18(�6c   $	��240��6q   $
��Bold"�6}   $��0,0,0,33.333q�6�   �� 5n      $��Бегун:��6   $
��Left=�6%   $��0,30.667,0,0q�6@   $	��Top=�6V   $��1��6n   �� 5o      $��Номер карты#:��6   $
��Left=�6,   $��0,82.667,0,0q�6G   $	��Top=�6]   $��1��6u   �� 5p      $ ��Срок действия:��6   $
��Left=�6-   $��0,104.667,0,0q�6H   $	��Top=�6_   $��1��6w   �� 5q      -   5        $
 	TboxName1��5q   1   $
��Left=�6   $��19��6D   $��	66,14,0,0q�6P   $
	 Wrap=�6c   $	��Top=�6w   $	��147��6�   $��1��6�   �� 5r      -   5        $
 TboxVladCart��5r   1   $
��Left=�6   $��19��6G   $��	66,62,0,0q�6S   $
	 Wrap=�6f   $	��Top=�6z   $	��147��6�   $��1��6�   �� 5s      -   5        $
 TboxNumberCart��5s   1   $
��Left=�6   $��19��6I   $��92,87.667,0,0q�6U   $
	 Wrap=�6l   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   �� $ OneWay=��� 5t      -   5        $
 TboxSrokMunf��5t   1   $
��Left=�6   $��19��6G   $��92,109.667,0,0q�6S   $
	 Wrap=�6k   $	��Top=�6   $��51��6�   $��1��6�   �� 5u      -   5        $
 TboxSrokYear��5u   1   $
��Left=�6   $��19��6G   $��148,109.667,0,0q�6S   $
	 Wrap=�6l   $	��Top=�6�   $��64��6�   $��1��6�   �� 5v      -   5        $
 TboxCVC��5v   1   $
��Left=�6   $��19��6B   $��92,135.667,0,0q�6N   $
	 Wrap=�6f   $	��Top=�6z   $��35��6�   $��1��6�   �� 5w      $
��CVC:��6   $
��Left=�6#   $��58,130.667,0,0q�6>   $	��Top=�6V   $��1��6n   �� 5x      $��Ваше имя:��6   $
��Left=�6(   $��0,9.667,0,0q�6C   $	��Top=�6X   $��1��6p   � 5y      -   5        $ grid5��5y      $
��Left=�6"   $��1,41.667,0,0q�6=   $	��Top=�6S   $��1��6k    5z      �� 5{      $
��Auto �6'   �� 5|      $
��Auto �6'    5~      �� 5      $
��Auto �6$   5�      � 5�      -   5        $ grid6��5�      $
��Left=�6"   $��109,186,0,0q�6=   $��1��6R   $	��Top=�6_    5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'    5�      �� 5�      $
��Auto �6$   5�      � 5�      -   5        $ grid7��5�      $
��Left=�6"   $��
138,41,0,0q�6=   $��1��6Q   $	��Top=�6^   $ 0.46,0.5&�6v    5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'    5�      �� 5�      $
��Auto �6$   5�      � 5�      $
��Left=�6   $��10��6.   $��
182,61,0,0q�6:   $��2��6N   $	��Top=�6_   $��22��6w   � 5�      -   5        $ grid8��5�      $
��Left=�6"   $��
130,44,0,0q�6=   $��1��6Q   $	��Top=�6^    5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'    5�      �� 5�      $
��Auto �6$   5�      � 5�      -    5        $ grid9��5�      $
��Left=�6"   $��	66,33,0,0q�6=   $��1��6P   $	��Top=�6]   $	��147��6u    5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'    5�      �� 5�      $
��Auto �6$   .+�5�      �� -!   5         ��Name$ expr1ComboBox��5�       �� DisplayMemberPath$ Expr1��6a   $
��Left=�6{   $
��Auto��6�   $��	0,4,-12,2q�6�   $��0��6�   $��Center=�6�   $	��147��6�   $��2��6  ��6�   �� ��5�      �� 5�      .R�5�      $� 5�      5�      5�      5�      5�      5�      