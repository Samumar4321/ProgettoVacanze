   M S B A M L   `   `   `  ����D  @SimonSays, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SimonSays	SimonSays  5   	       SimonSays.GamesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SimonSays     5   	     � Title$  GamesWindow��5   	   $	��450��6   $	��800��6*   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $	 Red��6   $ 1Q�6+   5      .+�5   
   �� -   5         ��Name$ btnHome��5      $��<--HOME��6"   $
��Left=�67   $��
10,389,0,0q�6R   $	��Top=�6f   $��75��6~   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
ScoreBoard��5      $
��Left=�6'   $	��243��6B   $��	35,10,0,0q�6O   $	��Top=�6b   $	��726��6z   $ ��University Roman LET Plain)�6�   $��15(�6�   
���   ����	#FF111211$ �� IsSynchronizedWithCurrentItem$ FalseY�6�   |�.     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6  	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .     HeadersVisibility$ Column=�6t     
IsReadOnly . ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ 	#FF86C61D��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ btnAll��5      $��Classifica totale��6!   $
��Left=�6=   $��
35,253,0,0q�6X   $	��Top=�6l   $	��362��6�   6�   �� 5   
   -   5        $ 
btnLimited��5      $"��Classifica di qesta sessione��6%   $
��Left=�6L   $��397,253,0,0q�6g   $	��Top=�6|   $	��364��6�   6�   �� 5   
   -   5        $ btnSaveScoreboard��5      $��Salva classifica��6,   $
��Left=�6G   $��
35,278,0,0q�6b   $	��Top=�6v   $	��183��6�   6�   �� 5   
   -   5        $ btnEraseScoreboard��5      $��Cancella classifica��6-   $
��Left=�6K   $��218,278,0,0q�6f   $	��Top=�6{   $	��179��6�   6�   �� 5   
   -   5        $ btnErasetempScoreboard��5      $(��"Cancella classifica della sessione��61   $
��Left=�6^   $��397,278,0,0q�6y   $	��Top=�6�   $	��364��6�   6�   5      5       