   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.LoginWindow   5   
   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5   	   -   5          � Title$  LoginWindow��5	   	   $	��600��5
   	   $
��1024��5   	    � WindowStyle$
 None=�5   	   $��LeftToRight=�5   	    � AllowsTransparency .  � WindowState$ 	Maximized=�5   	   
������  � Icon$G AIcones/pngtree___vector_five_star_hotel_icon_3774172_8w2_icon.ico��5   	   .��5      ��  �� CornerRadius$ 22��6   ���	#FF006884$��5q�5      ��5   
   �� 5      -   5        EnterWindow�� �� ImageSource$ Background/8939.jpg��5       j� 
AlignmentY$ Bottom=�5      5      ._�5   
   � -   5         �Name$ LoginWindowGrid��5      	 � ColumnDefinitions	 5      �� 5       $	��20* �6#   �� 5!      $	��20* �6#   �� 5"      $	��20* �6#   �� 5#      $	��20* �6#   �� 5$      $	��20* �6#   �� 5%      $	��20* �6#   �� 5&      $	��20* �6#   �� 5'      $	��20* �6#   �� 5(      $	��20* �6#   �� 5)      $	��20* �6#   
 � RowDefinitions
 5,      �� 5-      $	��40* �6    �� 5.      $	��40* �6    �� 5/      $	��40* �6    �� 50      $	��40* �6    �� 51      $	��40* �6    �� 52      $	��40* �6    �� 53      $	��40* �6    �� 54      $	��40* �6    �� 55      $	��40* �6    �� 56      $	��40* �6    �� 57      $	��25* �6    .+�5;      � $��0��6   $��8��5<      $��2��5=      $��Right=�5?      $��	0,10,20,0q�5@      .+�5D      �� -   5           TitleBarButtons#��[  5E      $��25��5G      $��25��5H      
������ $��0q�5J      ��5M      �� 5N      $��Buttons/minus-sign.png��5O      5R      �� 5T      -   5        #��[  5U      $��25��5X      $��25��5Y      
������ $��0q�5[      $
��10 0q�5\      ��5^      �� 5_      $#��Buttons/expand-button (1).png��5`      5b      �� 5c      -   5        #��[  5d      $��25��5e      $��25��5f      
������ $��0q�5h      ��5k      �� 5l      $��Buttons/closed.png��6    5n      5p      �� 5t      $��1��5u      $��5��5v      $��4��5w      $��2��5x      $��Center=�5y      $��Center=�5z      5}      �� 5~      -   5         ��Name$ TextBlockBeck��5�      $��3��5~      $��7��5      $��2��5�      $��1��5�      $
��Auto��5�      $
��Auto��5�        	TitleText#��[ 5�      welcome back to our site5�      �� 5�      $��3��5�      $��4��5�      $��6��5�      $��6��5�      
������� J� Opacity$	 0.9Q�5�      $ 35��5�      $	��400��5�      $	��330��5�      ._�5�      � -   5        $ 	HoursWork��5�      $��3��5�      $��5��5�      $��6��5�      $��4��5�      $
��auto��5�      $
��auto��6%   $	 0.8Q�5�      
 5�      �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   	 5�      �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��0��5�      $��0��5�      $��6��5�      $��10��5�      $
��auto��5�      $
��auto��5�      5�      �� 5�       �� Orientation$ Vertical=�5�      $��1��5�      $��0��5�      $��6��5�      $��9��5�      $��Center=�5�      $	��Top=�5�      .+�5�      �� -	   5        $ TextBlockUserName��5�        StyleTextBlock#��[ 5�      $��	User Name��5�      5�      �� 5�      -
   5         ��Name$ TextBoxUserName��5�   "   #��[B��5�      ��5�      �� *
UserName+ �� Mode$ OneWayToSource=�.��5�      5�      �� 5�      -   5        $ PasswordBoxInWindowLogin��5�      #��[ 5�      $��Password��5�      5�      G� 5�      -   5         G�Name$ PasswordBoxInLoginWindow��5�      #��[BG�5�      
���   �
�������$	 0.6Q�5�      $��28��6#    � Cursor$	 Pen��5�      5�      �� 5�      $y�Hidden=�5�      ��5�   !   �� *
Password+$ OneWayToSource=���5�      ��  �� ElementName$ PasswordBoxInLoginWindow��5�      �� 5�      -   5         ��Name$ SignIn��5�   !   #��[B��5�      $��50��5      $	��244��5     .��5  0   Login5     � 5     .+�5	     �� #��[ 5
      �� Padding$ 5,10,0,0q�5     $��0,0,10,0q�5     ��5  "   �� 5  &    �� EndPoint$ 0.5,1&�5      �� 
StartPoint$ 0.5,0&�5     .��5  *   �  � Color$ 	#FF000280��67    � Offset$ 0Q�5  +   � 5  *   $ 	#FF576E3D��67   $ 1Q�5  +   5  '   �� 5     $��11(�6   $ �Don't have an account yet?��5     5  5   �� 5     -   5        $ SignUp1��5!       SmallButton#��[ 5      $
��auto��5#     $
��auto��5$     $��Center=�5%     $��Bottom=�5&     $��Sign up��5'     $��12(�5(     
����  �$��10,10,10,10q�5*     5.     50     52     � 54     $��8��55     $��0��56     $��6��57     $��1��58     $
��auto��59     $
��auto��5:     $��Center=�5;     .+�5?     �� -   5        $ RegisterAsAGuest��5A     #��[B��5@     $��0,0,20,0q�5B     $y�Hidden=�5C     $��17(�5D     .��5E  :   Register As A Guest5H     �� 5J     -   5        $ RegisterAsAHosst��5L     #��[B��5K     $��17(�5M     $��5q�5N     $y�Hidden=�5O     .��5P  9   Register As A Host5R     5S     5V     5Y     5Z     5[     5\     