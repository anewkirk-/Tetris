   M S B A M L   `   `   `  ���� 
  Tetris,    &Tetris.Views.GameScreens.TwoPlayerGame   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008        GameBackground#��[  .���� -     ��Name$  TPG_mainPanel�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��0,25,0,0q�.+��� $��
Player One��$��-5,0,0,0q�$��14(�$
��Bold"��� $��
Next Block��$��-5,0,0,0q�$
��Bold"��� 
���   �$��1q�.��� -    �Name$ P1NextTetriminoGrid��$��30��$	��106��$��	-40,0,0,0q� � ColumnDefinitions �� �� �� �� �� �� ��  � RowDefinitions �� �� �� $��Score��$��24��$��-5,0,0,0q��� -    ��Name$ TPG_playerOne_score��$
��Bold"�$��14(�$��	-5,-5,0,0q��� $��Lines Cleared��$��24��$��-5,0,0,0q��� -   $ p1_LinesClearedLabel��$
��Bold"�$��14(�$��	-5,-5,0,0q��� $��Center=�$��10q�.+�� -   $ TPG_playerOne_grid��$	��275��$	��550��$��Center=� �� �� �� �� �� �� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� $��70��$��	0,225,0,0q�.+��� -   $ 
TimerLabel��$��Center=�$��18(�$
��Bold"��� -    ��Name$ 	TPG_pause��  OverlayButtons#��[ $��2,5,2,0q�$��65��$��16(�$��25��$��Pause���� -   $ TPG_save��#��[ $��2,5,2,0q�$��65��$��16(�$��25��$
��Save���� -	   $ TPG_quit��#��[ $��2,5,2,0q�$��65��$��16(�$��25��$
��Quit���� -
   $ 	TPG_music��  ImageButton#��[ $��40��$��40��|�.  $��2,20,2,0q�$��Center=��� -   $ TPG_sfx��#��[ $��40��$��40��|�.  $��2,5,2,0q�$��Center=��� $��Center=�$��10q�.+�� -   $ TPG_playerTwo_grid��$	��275��$	��550�� �� �� �� �� �� �� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� $��0,25,0,0q�.+��� $��
Player Two��$��Right=�$��14(�$
��Bold"�$��0,0,-5,0q��� $��
Next Block��$��Right=�$
��Bold"�$��0,0,-5,0q��� 
���   �$��1q�$��Right=�.��� -   $ P2NextTetriminoGrid��$��30��$	��106��$��	-40,0,0,0q� �� �� �� �� �� �� ��  �� �� �� $��Score��$��Right=�$��24��$��0,0,-5,0q��� -   $ TPG_playerTwo_score��$
��Bold"�$��14(�$��	0,-5,-5,0q�$��Right=��� $��Lines Cleared��$��24��$��Right=�$��0,0,-5,0q��� -   $ p2_LinesClearedLabel��$
��Bold"�$��14(�$��	0,-5,-5,0q�$��Right=�