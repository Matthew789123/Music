   M S B A M L   `   `   `  ����D  @Projekt_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projekt_1.ViewsProjekt_1.Views  5      7 clr-namespace:Projekt_1.ControlsProjekt_1.Controls  5          Projekt_1.Views.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Projekt_1.Views     5      4control clr-namespace:Projekt_1.Controls     5        N� FontSize$  20(�5
       N� Title$ Login��5      .��5      �� $	��450��6   $��Center=�6   $��Center=�69    � 	Resources 5   
      	Hyperlink �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  &	        �� 5      " ��6&   .�5      ��  � ��
 � ���6/   �� 5       �@��TextDecorations$ 	Underline{�64    5      P� 5       �@��IsMouseOver . . �5      ��  � �� �#c43c0067   5      P� 5       �@��	IsEnabled .  . �5      ��  � ��# � ��67   5      P� 5       �@��	IsEnabled . . �5      ��  �@�Cursor$
 Hand��63   5      5      5       .+�5"   
   �� -   5        	 ��Name$	 LoginBox��5"   R   $��
10,10,10,0q�6     TextBoxTemplate#��[ 6&   $��10q�6d   6�   � 5#   
   $��
10,10,10,0q�6   .+�5%      G� -   5        $��PasswordBox��5%   W     PasswordBoxTemplate#��[ 6   $��10q�6J   5&      �� 5'      -   5        
 ��Name$
 PasswordBlock��5'       J� IsHitTestVisible .   �� Padding$ 10q�6H   
Password6_   5*      �� 5+   
   -   5        $��
LoginError��5+   l   $	��Top=�6   $
��auto��6)   $��10,0,0,0q�67   $��10(�6I   
���  ��$y�	Collapsed=�6~   6�   �� 5,   
   -   5          ButtonTemplate#��[ 5,      $��
10,10,10,0q�6<   $��10q�6P   $��Log In��6r   5.      �� 50   
   ���#c43c00$��Center=�6)   Don't have an account? �� 52      #���   6   $��Registration.xaml?�6<   .�6\   Register now!6l   53      56      57      