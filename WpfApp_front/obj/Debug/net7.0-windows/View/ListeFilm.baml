   M S B A M L   `   `   `  ����G  CWpfApp_front, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp_front.ViewWpfApp_front.View  5   	   !    WpfApp_front.View.ListeFilm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfApp_front.View     5   	     � Title$  
MainWindow��5   
   $	��600��6   $	��900��6*   
������� � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonStyle �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6+   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 0q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $	 border��6!   $
 10��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5)      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?    � �� �#4444446S   �� 51   "   $ border��6@    � �� �#4444446T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?    � �� �#6666666S   �� 55   "   $ border��6@    � �� �#6666666T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8   � ��6i   5;      5=      5?      5@      5A      .��5B      � ��5C   
   �� 5D       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5E      �  � Color$ Black��6   � 5F      $	 Red��6    � Offset$ 1Q�6+   5G      .+�5J   
   �� $��Center=�6   $��Center=�62   .+�5L      �� -   5        $��Message��5L   U   $�� ��6   $
��Left=�6   $��Center=�6:   6U   �� 5N      -   5        $��hidId��5N   �   $
��Left=�6    �� TextWrapping$
 Wrap=�62   $��Saisir un Id��6F   $��Center=�6Z   $	��120��6u   $y�Hidden=�6�   �� 5P      -   5        $��IdFilm��5P   _   $��
Id du film��6   $
��Left=�6)   $��Center=�6D   
�������$y�Hidden=�6�   �� 5Q      -   5        $��txtId��5Q   �   $
��Left=�6   $
 Wrap=�62   $��Saisir un id��6F   $��Center=�6Z   $	��120��6u   $y�Hidden=�6�   �� 5S      -   5        $��NomFilm��5S   `   $��Nom du film��6   $
��Left=�6*   $��Center=�6E   
�������6o   �� 5T      -   5        $��txtNom��5T   �   $
��Left=�6   $
 Wrap=�62   $��Saisir un film��6F   $��Center=�6\   $	��120��6w   6�   �� 5U      -   5        $��DescriptionFilm��5U   h   $��Description du film��6   $
��Left=�62   $��Center=�6M   
�������6   �� 5V      -   5        $��txtDesc��5V   �   $
��Left=�6   $
 Wrap=�62   $��Saisir une description��6F   $��Center=�6d   $	��120��6   6�   �� 5W      -	   5        #��� 
 5W      $��Ajouter��6B   $
��Left=�6T   $��Center=�6o   $��80��6�   $��20��6�    J� RenderTransformOrigin$ -4.496,2.238&�6�   
���   �
�������$��Arial)�5Z      �� 5[      -
   5        $��update��5[   �   #��� 
 6   $��Mettre a jour��6B   $
��Left=�6Z   $��Center=�6u   $��80��6�   $��20��6�   
���   �
�������$��Arial)�5^      �� 5_      -   5        #��� 
 5_      $��Charger la liste��6B   $��Center=�6]   $��Center=�6z   $	��100��6�   $��20��6�   
���   �
�������$��Arial)�5b      &   System.Windows.Controls.DataGrid  5c      7m)http://schemas.microsoft/wpf/2008/toolkit     5e      -   5        $��FilmList��5d         AutoGenerateColumns$ False��5f      $��1��65   $��2��6B   $	��821��6S   ��5c      ��    Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ��  �� Path$ id�  5j      $ Nom du film��6)    6>   �� $	 nom�  5k      $ Description��6)    6>   �� $ description�4  .System.Windows.Controls.DataGridTemplateColumn  5l      $ Modifier��6-      CellTemplate 5m      �� 5n      .R�5o   "   �� -   5        #��� 
 5o   )   $	��100��6V   $��20��6b   
���   �
�������$��Arial)�6�   .��6�   
Modifier6�   5p      5s        5t      $ 	Supprimer��6-    5u      �� 5v      .R�5w   "   �� -   5        #��� 
 5w   )   $	��100��6V   $��20��6b   
���   �
�������$��Arial)�6�   .��6�   	Supprimer6�   5x      5{      5}      5~      �� 5   
   -   5        #��� 
 5      $��Suivant��6>   $��Right=�6P   $��
25,25,25,0q�6l   $	��Top=�6�   $��41��6�   $	��145��6�   
���   �$��20(�6�   ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $	 red��6#   � 5�      $	 red��6#   $ 1Q�6/   5�      5�      5�      5�      