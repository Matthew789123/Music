   M S B A M L   `   `   `  ����D  @Projekt_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projekt_1.ViewsProjekt_1.Views  5      "    Projekt_1.Views.Registration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Projekt_1.Views     5        N� FontSize$  20(�5	       N� Title$ Registration��5
      .��5      �� $
��auto��6   $	��450��6   $��Center=�6+   $��Center=�6F   .+�5   
   �� -   5        $��UsernameBox��5         TextBoxTemplate#��[  6%   $��
10,10,10,0q�6Q   $��10q�6e   .��6�   
Username6�   �� 5   
   -   5        $��UsernameError��5   h   $	��Top=�6   $
��auto��6)   $��10,0,0,0q�67   $��10(�6I   
���  ��$y�	Collapsed=�6}   .��6�   Please enter a name6�   �� 5   
   -   5        $��EmailBox��5      #��[  6"   $��
10,10,10,0q�6N   $��10q�6�   .��6�   Email6�   �� 5   
   -   5        $��
EmailError��5   g   $	��Top=�6   $
��auto��6(   $��10,0,0,0q�66   $��10(�6H   
���  ��$y�	Collapsed=�6y   .��6�   Please enter an email6�   � 5   
   .+�5      G� -   5         G�Name$ PasswordBox��5        PasswordBoxTemplate#��[ 6/   $��
10,10,10,0q�6_   $��10q�6s   6�   �� 5      -   5         ��Name$ PasswordBlock��5   ,   $��
10,10,10,0q�6    J� IsHitTestVisible .   �� Padding$ 10q�6\   
Password6s   5      �� 5   
   -   5        $��PasswordError��5   h   $	��Top=�6   $
��auto��6)   $��10,0,0,0q�67   $��10(�6I   
���  ��$y�	Collapsed=�6}   .��6�   Please choose a password6�   � 5   
   .+�5      G� -   5        $ 
ConfirmBox��5      #��[ 6.   $��
10,10,10,0q�6^   $��10q�6r   6�   �� 5      -	   5        $ ConfirmBlock��5   ,   $��
10,10,10,0q�6    .  $ 10q�6[   Confirm Password6{   5      �� 5   
   -
   5        $��ConfirmationError��5   h   $	��Top=�6   $
��auto��6)   $��10,0,0,0q�67   $��10(�6I   
���  ��$y�	Collapsed=�6�   .��6�   Please confirm password6�   �� 5   
   -   5        $��
10,10,10,0q�5        ButtonTemplate#��[ 6%   $��10q�6P   .��6{   
Register6�   �� 5   
   $��Center=�6   ���#c43c00Already have an account? �� 5        	Hyperlink#���  6   $��
Login.xaml?�6<   .�6U   Log in now!6c   5       5!      5"      