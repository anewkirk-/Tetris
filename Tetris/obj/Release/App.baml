   M S B A M L   `   `   `  ���� A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Tetris.ControllersTetris.Controllers  5clr-namespace:Tetris.ConvertersTetris.Converters  a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes     
Tetris.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     8controllers clr-namespace:Tetris.Controllers     6
convertersclr-namespace:Tetris.Converters     ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero       �� 	Resources     MainBackground �� ImageSource  GameBackground  OverlayBackground  ScoresBackground  ControlsBackground  
KBM_Labels �� Color �� A �� R �� G �� B  Brush_LightBlue  Brush_GridBackground  Brush_GridBorders 	 MenuButtons �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� Triggers P� Property P� Value 
 OverlayButtons 
 Scores  GridRow1  GridRow2  KeyBindingLabels,   &Tetris.Converters.BoolToImageConverter  MusicConverter   ifOn   ifMuted  SFXConverter  ImageButton �Name J� SnapsToDevicePixels �� Triggers �� 
TargetName  ComboBoxFocusVisual �� StrokeDashArray  ButtonNormalBorder  DownArrowGeometry   ComboBoxReadonlyToggleButton ��Name F�Name  ComboBoxEditableTextBox ��Name  ComboBoxToggleButton+  %Microsoft.Windows.Themes.ButtonChrome  Name   BorderBrush   
Background J� IsMouseOver   RenderMouseOver   RenderPressed   RoundCorners  ComboBoxEditableTemplate � ColumnDefinitions  �Name! � AllowsTransparency" �� RelativeSource5  /Microsoft.Windows.Themes.SystemDropShadowChrome#  Name$   Color% �� MaxDropDownHeight& �� ElementName' �� ClearTypeHint( ��Name) ��Name-  'System.Windows.Input.KeyboardNavigation*   DirectionalNavigation,  &Microsoft.Windows.Themes.ListBoxChrome+  Name,   BorderBrush-   BorderThickness.   
Background/   RenderMouseOver0 J� IsKeyboardFocusWithin1   RenderFocused2 ��Name3 �� 
IsReadOnly4 d� 	IsChecked5 �� Mode6 ]� 
Conditions7 �� Property8 �� Value9 P� 
SourceName'  !System.Windows.VisualStateManager:   VisualStateGroups%  System.Windows.VisualStateGroup;   States   System.Windows.VisualState< �� SelectionBoxItemTemplate= �� SelectionBoxItem#> �� SelectionBoxItemStringFormat? �� ContentStringFormat@ J� IsHitTestVisible�� %�  &	        &	 &     &	 R     &	 {     &	 �     &	 �     &	     &	 9    &	 o    &		 �    7  &	
     7  &	 �    &	     &	 0    7  &	 O    &	 �    &	 �    &	 A    &	 �    &	 �    &	 	    &	 1	    7  &	 �
    &	     7  &	 �    7  7  '�� �    7  7  7  �� $  /Images/MainBackground.png���� $&  /Images/GameScreenBackground.png���� $# /Images/OverlayBackground.png���� $" /Images/ScoresBackground.png���� $$ /Images/ControlsBackground.png����  �� $	 255��$	 171��$	 149��$	 149����  �� $	 255��$	 203��$	 230��$	 247����  �� $	 255��$	 240��$	 240��$	 240����  �� $	 255��$ 30��$ 30��$ 30���� " ��.���  � ��$	 10q���  � ��$		 200����  � ��$	 50����  � ��$	 24(���  � ��$	 Miriam)���  � ��8	   ��  � ��
	 �������  � ��$	 2q���  � ��	 �� "
 ��.R��� #��z��#��z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
	 �p���  � ��
	 ������� " ��.���  � ��$	 	5,0,10,15q���  � ��$		 100����  � ��$	 30����  � ��$	 20(���  � ��$	 Miriam)���  � ��8	   ��  � ��
	 �   ���  � ��$	 1q���  � ��$	 Center=���  � ��$	 Center=���  � ��	 �� "
 ��.R��� #��z��#��z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
	 �p���  � ��
	 ������� " ��.���  � ��$	 	25,0,25,0q���  � ��$	 18(��� " ��.���  � ��
	 ������� " ��.���  � ��8	   �� " ��.���  � ��$	 Center=���  � ��$	 Center=���  � ��$		 200����  � ��$	 50����  � ��$	 24(���  � ��$	 Miriam)���  � ��
	 ��d���  � ��
	 �������  � ��$	 2q���  � ��	 �� "
 ��.R��� #��z��#��z��#��z��#��z��._��� $��Center=�$��Center=�   �� $��/Images/sound_music.png�� �� $#��/Images/sound_music_muted.png��   �� $��/Images/sound_sfx.png�� �� $!��/Images/sound_sfx_muted.png���� " ��.���  � ��
	 ���� ��  � ��$	 1q���  � ��#	 � ����  � ��$	 Center=���  � ��$	 Center=���  � ��$	 1q���  � ��	 �� "
 ��.R�� $ Chrome��#��z�� . .+��� #��z��#��z����. # z #��z�� P�  � {� .  . ���  � ��	 �#ADADAD�� $ Chrome�� �@J�Opacity$		 0.5Q��� .���  � ��	 �� .R��� $��4,4,21,4q� . 
����d�$��1��$	 1 2R��� $ 	#FF707070���M 0 0 L 3.5 4 L 7 0 Z��� " d�.���  �@�OverridesDefaultStyle	 . ��  � ��	 .  ��  � |�	 .  ��  �@��	ClickMode$	 Press=���  � ��
	 ���� ��  � ��	 �� "
 d�.R��� $ Chrome��#��z��$��1q�#��z�� . ._�� $��Right=�#��� r�.+�F� $ Arrow��8��  
���   �$��Center=�$��3,1,0,0q�$��Center=� P�  � {� .  . ��� $ Arrow�� � ��	 �#AFAFAF�� " ��.���  �@�OverridesDefaultStyle	 . ��  �@J�	AllowDrop	 . ��  � ��$	 0����  � ��$	 0����  �@�FocusVisualStyle	 Z� ��  �@��PanningMode$	 VerticalFirst=���  �@��IsFlicksEnabled	 .  ��  � ��	 �� "
 ��.R��� $ PART_ContentHost��
������ |�.  $��Hidden=�$��Hidden=��� " d�.���  �@�OverridesDefaultStyle	 . ��  � ��	 .  ��  � |�	 .  ��  �@��	ClickMode$	 Press=���  � ��
	 ���� ��  � ��	 �� "
 d�.R�  $ Chrome��# z��# z��# z # z�� .   . #��� r�._�F� $ Arrow��8��  
���   �$��Center=�$��0,1,0,0q�$��Center=� P�  �@d�	IsChecked$
 trueY�. ��� $ Chrome�� �@ RenderPressed	 . P�  � {� .  . ��� $ Arrow�� � ��	 �#AFAFAF�� "
 ��.R�� $ 	Placement�� .  �� $��* ��� $
��Auto �.+�� $  
PART_Popup��! . $��2��#��� .�$��Bottom=����� *IsDropDownOpen+" �� *TemplatedParent+.��  $
# Shdw��$$ Transparent��#��z% ���� *ActualWidth+$& 	Placement��._��� $ DropDownBorder��#��� ��$��1q�#��� ��._��� $ DropDownScrollViewer��.��� $' Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $( 
OpaqueRect������ *
Background+$& DropDownBorder������ *ActualHeight+$& DropDownBorder������ *ActualWidth+$& DropDownBorder���� $) ItemsPresenter��$* 	Contained=�# z   $+ Border��#, z��#- z��#. z��$��2��#/ z #1 z0 �� $2 PART_EditableTextBox��#��z��#��z��8��  #��z��3 �� *
IsReadOnly+" �� *TemplatedParent+d� $��1��8�� 4 �� *IsDropDownOpen+$5 TwoWay=�" �� *TemplatedParent+ P�  �@J�IsKeyboardFocusWithin . . ���  � ��
	 �   �P�  �@��IsDropDownOpen . . ��� $ Border�� �@ RenderFocused	 . P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$	 95��P�  � {� .  . ��� #	 � �� � ����  � ��	 �	#FFF4F4F4]� 6 �� 7 �@��
IsGrouping8 . �� "7 �@%�IsVirtualizingWhenGrouping8 .  ./���  � ��	 .  P� $9 
PART_Popup�� �@�HasDropShadow . . ��� $
 Shdw�� � ��$	 0,0,5,5q��� $
 Shdw�� �@ Color$	 	#71000000��P� $9 DropDownScrollViewer�� � �� .  . ��� $ 
OpaqueRect��	 �� *VerticalOffset+$& DropDownScrollViewer�� �@��Top�� $ 
OpaqueRect��	 �� *HorizontalOffset+$& DropDownScrollViewer�� �@��Left�� " ��.���  �@�FocusVisualStyle8	   ��  � ��#	 � ����  � ��
	 �������  � ��
	 �������  � ��$	 1q���  � ��$
	 Auto=���  � ��$
	 Auto=���  � ��$		 4,3q���  � ��	 . ��  �@��PanningMode$
	 Both=���  �@��IsFlicksEnabled	 .  ��  � ��	 �� "
 ��.R�� $ MainGrid�� .  �� $��* ��� #��� r�$��0 �:   CommonStates��.;   
Normal��  	MouseOver��.+�� $  
PART_Popup��! . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+" �� *TemplatedParent+.��  $
# Shdw��$$ Transparent��#��z% ���� *ActualWidth+$& MainGrid��._��� $ DropDownBorder��
����d�$��1q�
�������._��� $ DropDownScrollViewer��.��� $' Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $( 
OpaqueRect������ *
Background+$& DropDownBorder������ *ActualHeight+$& DropDownBorder������ *ActualWidth+$& DropDownBorder���� $) ItemsPresenter��$* 	Contained=�# z d� #��z��#��z��$��2��8�� 4 �� *IsDropDownOpen+$5 TwoWay=�" �� *TemplatedParent+�� #��z< #��z��#��z= #? z> #��z��@ .  #��z��# z #��z�� P�  �@J�IsMouseOver . . ���  � ��
	 �����P� $9 
PART_Popup�� �@�HasDropShadow . . ��� $
 Shdw�� � ��$	 0,0,5,5q��� $
 Shdw�� �@ Color$	 	#71000000��P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$	 95��P�  � {� .  . ��� #	 � �� � ����  � ��	 �	#FFF4F4F4]� 6 �� 7 �@��
IsGrouping8 . �� "7 �@%�IsVirtualizingWhenGrouping8 .  ./���  � ��	 .  P� $9 DropDownScrollViewer�� � �� .  . ��� $ 
OpaqueRect��	 �� *VerticalOffset+$& DropDownScrollViewer�� �@��Top�� $ 
OpaqueRect��	 �� *HorizontalOffset+$& DropDownScrollViewer�� �@��Left P�  �@��
IsEditable . . ���  � ��
	 �   ���  � ��#	 � ����  � ��	 .  ��  � ��$	 3q���  � ��8	  P�  �@J�IsMouseOver . . ���  � ��
	 �����