   M S B A M L   `   `   `  ����
  Tetris3    -Tetris.Views.Overlays.SinglePlayerGameSummary   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��275��5      $	��300��6      OverlayBackground#��[  5      
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
�������$	��200��6_   5      5       5      P� 5       � ��#
 Z	 6*   . �5      ��  � ��8   63   5      P� 5       � ��
 6*   Z� . �5      ��  � ��8  63   5      P� 5       �@J�IsKeyboardFocused
 . . �5      ��  � ��
 �����63   5      5       5!      .��5%      �� $��Center=�6   $��20q�6.   .+�5&   
   �� $��Game Summary��6   $
��Bold"�5'      $��18(�5(      � 5*   
   $	��155��6    � ColumnDefinitions 5+      �� 5,      $��6* �6#   �� 5-      $��4* �6#    � RowDefinitions 5/      �� 50      �� 51      �� 52      .+�55      �� $��Score:��6   $��14(�6%   $��0��56      $��0��6!   �� 57      -   5         ��Name$ 
SPGS_score��57      $��SCORE��6(   $��14(�58      $
��Bold"�6"   $��Right=�59      $��0��5:      $��1��6!   �� 5<      $��Lines Cleared:��6   $��14(�6-   $��1��5=      $��0��6!   �� 5>      -   5        $ 
SPGS_lines��5>      $��LINES��6(   $��14(�5?      $
��Bold"�6"   $��Right=�5@      $��1��5A      $��1��6!   �� 5C      $��Time Taken:��6   $��14(�6*   $��2��5D      $��0��6!   �� 5E      -   5        $ 	SPGS_time��5E      $
��TIME��6'   $��14(�5F      $
��Bold"�6"   $��Right=�5G      $��2��5H      $��1��6!   5I      �� 5K   
   .+�5L      �� -   5        $ AHS_type��5L      $��New High Score!��6&   $��Center=�5M      $��0,10,0,0q�5N      �� 5Q      -   5         ��Name$ AHS_name��5Q      $	��150��6(   
�������$��1q�5S      �� 5T      -   5        $ 	AHS_chars��5T      $ ��No more than 10 characters��6'   $��Center=�5U      $y�	Collapsed=�5V      
���  ��5W      5X      �� 5Z   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��5q�6K   .+�5[      �� -   5         ��Name$ SPGS_playAgain��5[      $��
Play Again��6-     OverlayButtons#��[ 5\      $��18(�5]      $��10q�5^      �� 5_      -   5        $ SPGS_mainMenu��5_      $��	Main Menu��6,   #��[ 5`      $��18(�5a      $��10q�5b      5c      5e      5f      