   M S B A M L   `   `   `  ����
  Tetris0    *Tetris.Views.Overlays.TwoPlayerGameSummary   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��300��5      $	��400��6      OverlayBackground#��[  5      
���   �$��1q�5
        � 	Resources  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   %    �� 
TargetType �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual �� Triggers P� Property	 �� Empty
 P� Value �� Property  CueBannerBrush �� Value��5      %M  '��       7  7  �� 5   
   6sys&clr-namespace:System;assembly=mscorlib     6%   " ��6    5      ��!� 5      CueBannerBrush $
 Left=�65   $ Center=�6G   $
 None=�6[    5      �� 5      $��Enter your name��6    
�������
�������$	��200��6d   5      5       5      P� 5       � ��#
 Z	 6*   . �5      ��  � ��8   63   5      P� 5       � ��
 6*   Z� . �5      ��  � ��8  63   5      P� 5       �@J�IsKeyboardFocused
 . . �5      ��  � ��
 �����63   5      5       5!      .��5#      �� $��10q�6   .+�5$   
   �� -   5         ��Name$ TPGS_winner��5$      $��Player One Wins!��6%   $��20(�5%      $
��Bold"�6   $��Center=�5&      $��Italic$�5'      �� 5(   
   $��Game Summary��6   $��18(�5)      $
��Bold"�6   $��Center=�5*      �� 5,   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5-      �� $��Time Taken:��6   �� 5.      -   5        $ 	TPGS_time��5.      $
��TIME��6'   $
��Bold"�66   5/      �� 51   
   $ 
Horizontal=�6   $��Center=�6.   .+�53      �� $��5q�6   .+�54      �� $��Player One Summary��6   $
��Bold"�55      $��14(�6*   �� 57      $ 
Horizontal=�6   .+�58      �� $��Score:��6   �� 59      -   5        $ TPGS_playerOne_score��59      $��SCORE��6:   $
��Bold"�6J   5:      �� 5;      $ 
Horizontal=�6   .+�5<      �� $��Lines Cleared:��6   �� 5=      -   5        $ TPGS_playerOne_lines��5=      $��LINES��6:   $
��Bold"�6J   5>      �� 5?      .+�5@      �� -   5        $ AHS_playerOne_type��5@      $��New High Score!��68   �� 5C      -   5         ��Name$ AHS_playerOne_name��5C      $	��150��6:   
�������$��1q�5E      �� 5F      -   5        $ AHS_playerOne_chars��5F      $ ��No more than 10 characters��69   $y�	Collapsed=�5G      5H      5I      �� 5M      $��5q�6   $��Right=�6$   .+�5N      �� $��Player Two Summary��6   $��Right=�5O      $
��Bold"�5P      $��14(�6*   �� 5Q      $ 
Horizontal=�6   $��Right=�66   .+�5R      �� $��Score:��6   �� 5S      -   5        $ TPGS_playerTwo_score��5S      $��SCORE��6:   $
��Bold"�6J   5T      �� 5U      $ 
Horizontal=�6   $��Right=�66   .+�5V      �� $��Lines Cleared:��6   �� 5W      -	   5        $ TPGS_playerTwo_lines��5W      $��LINES��6:   $
��Bold"�6J   5X      �� 5Y      .+�5Z      �� -
   5        $ AHS_playerTwo_type��5Z      $��New High Score!��68   $��Right=�5[      �� 5^      -   5        $ AHS_playerTwo_name��5^      $	��150��6:   $��Right=�6F   
�������$��1q�5`      .��62   ��5a      1&clr-namespace:System;assembly=mscorlibSystem 5b   9   �� 6   .sys&clr-namespace:System;assembly=mscorlib  69   " ��6$    5c   "     CueBannerBrush2��%�   &	       !� 5d   &   $ Right=�6J   $ Center=�6]   $
 None=�6q    5e   *   �� 5f   .   $��Enter your name��64   
�������
�������$	��200��6x   $��Right=�5g   4   5i   '   5j   #    5k   "   P� 5l   &    � ��#
 Z	 6>   . �5m   *   ��  � ��# [ 6G   5n   '   P� 5o   &    � ��
 6>   Z� . �5p   *   ��  � ��# [ 6G   5q   '   P� 5r   &    �@J�IsKeyboardFocused
 . . �5s   *   ��  � ��
 �����6G   5t   '   5v      .��5w   )   5x      �� 5y      -   5        $ AHS_playerTwo_chars��5y      $ ��No more than 10 characters��69   $y�	Collapsed=�5z      5{      5|      5~      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   .+�5�      �� -   5         ��Name$ TPGS_playAgain��5�      $��
Play Again��6-     OverlayButtons#��[ 5�      $��18(�5�      $��10q�5�      �� 5�      -   5        $ TPGS_mainMenu��5�      $��	Main Menu��6,   #��[ 5�      $��18(�5�      $��10q�5�      5�      5�      5�      