   M S B A M L   `   `   `  ���� 
  Tetris0    *Tetris.Views.Overlays.TwoPlayerGameSummary   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $	��300��$	��400��   OverlayBackground#��[  
���   �$��1q�  � 	Resources  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  �� 
TargetType �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual �� Triggers P� Property	 �� Empty
 P� Value �� Property  CueBannerBrush �� Value��%o  '��       7  7  �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��!� CueBannerBrush $
 Left=�$ Center=�$
 None=� �� $��Enter your name��
�������
�������$	��200�� P�  � ��#
 Z	 . ���  � ��8   P�  � ��
 Z� . ���  � ��8  P�  �@J�IsKeyboardFocused
 . . ���  � ��
 �����.���� $��10q�.+��� -    ��Name$ TPGS_winner��$��Player One Wins!��$��20(�$
��Bold"�$��Center=�$��Italic$��� $��Game Summary��$��18(�$
��Bold"�$��Center=���  �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Time Taken:���� -   $ 	TPGS_time��$
��TIME��$
��Bold"��� $ 
Horizontal=�$��Center=�.+��� $��5q�.+��� $��Player One Summary��$
��Bold"�$��14(��� $ 
Horizontal=�.+��� $��Score:���� -   $ TPGS_playerOne_score��$��SCORE��$
��Bold"��� $ 
Horizontal=�.+��� $��Lines Cleared:���� -   $ TPGS_playerOne_lines��$��LINES��$
��Bold"��� .+��� -   $ AHS_playerOne_type��$��New High Score!���� -    ��Name$ AHS_playerOne_name��$	��150��
�������$��1q��� -   $ AHS_playerOne_chars��$ ��No more than 10 characters��$y�	Collapsed=��� $��5q�$��Right=�.+��� $��Player Two Summary��$��Right=�$
��Bold"�$��14(��� $ 
Horizontal=�$��Right=�.+��� $��Score:���� -   $ TPGS_playerTwo_score��$��SCORE��$
��Bold"��� $ 
Horizontal=�$��Right=�.+��� $��Lines Cleared:���� -	   $ TPGS_playerTwo_lines��$��LINES��$
��Bold"��� .+��� -
   $ AHS_playerTwo_type��$��New High Score!��$��Right=��� -   $ AHS_playerTwo_name��$	��150��$��Right=�
�������$��1q�.����1&clr-namespace:System;assembly=mscorlibSystem �� .sys&clr-namespace:System;assembly=mscorlib  " ��   CueBannerBrush2��%~   &	       !� $ Right=�$ Center=�$
 None=� �� $��Enter your name��
�������
�������$	��200��$��Right=� P�  � ��#
 Z	 . ���  � ��# [ P�  � ��
 Z� . ���  � ��# [ P�  �@J�IsKeyboardFocused
 . . ���  � ��
 �����.���� -   $ AHS_playerTwo_chars��$ ��No more than 10 characters��$y�	Collapsed=��� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ TPGS_playAgain��$��
Play Again��  OverlayButtons#��[ $��18(�$��10q��� -   $ TPGS_mainMenu��$��	Main Menu��#��[ $��18(�$��10q�