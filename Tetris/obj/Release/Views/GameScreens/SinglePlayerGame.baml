   M S B A M L   `   `   `  ���� 
  Tetris/    )Tetris.Views.GameScreens.SinglePlayerGame   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008        GameBackground#��[  .���� -     ��Name$  SPG_mainPanel�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Center=�$
��20,0q�.+�� -    �Name$ SPG_playerOne_grid��$	��275��$	��550�� � ColumnDefinitions �� �� �� �� �� �� �� �� �� ��  � RowDefinitions �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� $��0,25,0,0q�.+��� -    ��Name$ 
TimerLabel��$��-5,0,0,5q�$��16(�$
��Bold"��� $��
Next Block��$��-5,0,0,0q�$��12(�$
��Bold"��� 
���   �$��1q�.��� -   $ NextTetriminoGrid��$��30��$	��106��$��	-32,0,0,0q� �� �� �� �� �� �� ��  �� �� �� $��Score��$��24��$��	-5,10,0,0q��� -   $ SPG_playerOne_score��$
��Bold"�$��14(�$��	-5,-5,0,0q��� $��Lines Cleared��$��24��$��-5,0,0,0q��� -   $ LinesClearedLabel��$
��Bold"�$��14(�$��	-5,-5,0,0q��� -    ��Name$ 	SPG_pause��  OverlayButtons#��[ $��0,25,0,0q�$��Pause���� -   $ SPG_save��#��[ $��0,5,0,0q�$
��Save���� -	   $ SPG_quit��#��[ $��0,5,0,0q�$
��Quit���� -
   $ 	SPG_music��  ImageButton#��[ $��40��$��40��$��Bottom=�|�.  $��0,0,5,30q�$��Right=��� -   $ SPG_sfx��#��[ $��40��$��40��$��Bottom=�|�.  $��5,0,0,30q�$��Right=�