   M S B A M L   `   `   `  ���� 
  Tetris3    -Tetris.Views.Overlays.SinglePlayerGameSummary   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $	��275��$	��300��   OverlayBackground#��[  
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
 �����.���� $��Center=�$��20q�.+��� $��Game Summary��$
��Bold"�$��18(�� $	��155�� � ColumnDefinitions �� $��6* ��� $��4* � � RowDefinitions �� �� �� .+��� $��Score:��$��14(�$��0��$��0���� -    ��Name$ 
SPGS_score��$��SCORE��$��14(�$
��Bold"�$��Right=�$��0��$��1���� $��Lines Cleared:��$��14(�$��1��$��0���� -   $ 
SPGS_lines��$��LINES��$��14(�$
��Bold"�$��Right=�$��1��$��1���� $��Time Taken:��$��14(�$��2��$��0���� -   $ 	SPGS_time��$
��TIME��$��14(�$
��Bold"�$��Right=�$��2��$��1���� .+��� -   $ AHS_type��$��New High Score!��$��Center=�$��0,10,0,0q��� -    ��Name$ AHS_name��$	��150��
�������$��1q��� -   $ 	AHS_chars��$ ��No more than 10 characters��$��Center=�$y�	Collapsed=�
���  ����  �� Orientation$ 
Horizontal=�$��Center=�$��5q�.+��� -    ��Name$ SPGS_playAgain��$��
Play Again��  OverlayButtons#��[ $��18(�$��10q��� -   $ SPGS_mainMenu��$��	Main Menu��#��[ $��18(�$��10q�