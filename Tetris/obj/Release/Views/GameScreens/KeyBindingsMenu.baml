   M S B A M L   `   `   `  ���� 
  Tetris.    (Tetris.Views.GameScreens.KeyBindingsMenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008        ControlsBackground#��[    � 	Resources   �� 
TargetType  keybindings �� Property �� Value��%-   &	       �� " ��.���  � ��$ 35 �.���� .+��� $��/Images/dotTetrisLogo.png��$	��100��$��10q�� $	��380�� � ColumnDefinitions �� �� ��  � RowDefinitions �� �� �� �� �� �� .+��� $��Key Bindings��  KeyBindingLabels#��[ 
�������$��2q�$��0��$��0��$��	ExtraBold"��� $��Player 1��#��[ $��0��$��1��$��	ExtraBold"��� $��Player 2��#��[ 
�������$��2q�$��0��$��2��$��	ExtraBold"��� $��	Move Left��#��[   Brush_LightBlue#��[ $��1q�$��1���� -    ��Name$ P1MoveLeftBox��$��1��$��1��$��15,15,15,15q� �� SelectedItem ��  �� Path$ P1Left�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� -   $ P2MoveLeftBox��$��2��$��1��$��15,15,15,15q� �� $ P2Left�$	 TwoWay=�$
 PropertyChanged=��� $��
Move Right��#��[ #��[ $��1q�$��2���� -   $ P1MoveRightBox��$��1��$��2��$��15,15,15,15q� �� $ P1Right�$	 TwoWay=�$
 PropertyChanged=��� -   $ P2MoveRightBox��$��2��$��2��$��15,15,15,15q� �� $ P2Right�$	 TwoWay=�$
 PropertyChanged=��� $��Rotate��#��[ #��[ $��1q�$��3���� -   $ P1MoveRotateBox��$��1��$��3��$��15,15,15,15q� �� $ P1Rotate�$	 TwoWay=�$
 PropertyChanged=��� -   $ P2MoveRotateBox��$��2��$��3��$��15,15,15,15q� �� $ P2Rotate�$	 TwoWay=�$
 PropertyChanged=��� $��	Soft Drop��#��[ #��[ $��1q�$��4���� -   $ P1MoveSoftDropBox��$��1��$��4��$��15,15,15,15q� �� $ P1Down�$	 TwoWay=�$
 PropertyChanged=��� -   $ P2MoveSoftDropBox��$��2��$��4��$��15,15,15,15q� �� $ P2Down�$	 TwoWay=�$
 PropertyChanged=��� $��	Hard Drop��#��[ #��[ $��1q�$��5���� -	   $ P1MoveHardDropBox��$��1��$��5��$��15,15,15,15q� �� $ P1Drop�$	 TwoWay=�$
 PropertyChanged=��� -
   $ P2MoveHardBox��$��2��$��5��$��15,15,15,15q� �� $ P2Drop�$	 TwoWay=�$
 PropertyChanged=��� -    ��Name$ KBM_back��  MenuButtons#��[ $��Back to Main Menu��$��0,20,0,0q���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $ 	KBM_music��  ImageButton#��[ $��40��$��40��$��0,0,5,0q�$��Right=��� -   $ KBM_sfx��#��[ $��40��$��40��$��5,0,0,0q�$��Right=�