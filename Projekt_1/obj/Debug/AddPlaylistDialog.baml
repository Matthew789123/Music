   M S B A M L   `   `   `  ����D  @Projekt_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Projekt_1	Projekt_1  5   	   !    Projekt_1.AddPlaylistDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Projekt_1     5   	   ���#212121  � SizeToContent$  WidthAndHeight=�5   	    � WindowStyle$
 None=�5	   	   .��5      �� $��Center=�6   $��Center=�6,   .+�5   
   �� -   5        $��LoginBox��5   r      
LabelStyle#��[  6   $��Center=�64   $��
10,10,10,0q�6Q   $��10q�6e   .��6�   Create new playlist6�   �� 5   
   -   5        $��NewPlaylistName��5   L     TextBoxTemplate#��[ 6   $
��10,0q�6>   $��10q�6c   6�   � 5   
    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5        $	��btn��5   �     ButtonTemplate#��[ 6   $��0��6@   $��
90,10,5,10q�6P   $��5q�6d   $
��auto��6p   $��Right=�6}   .��6�   Create6�   �� 5      -   5        #��[ 5      $��1��6@   $��
5,10,90,10q�6P   $��5q�6d   $
��auto��6p   $
��Left=�6}   .��6�   Cancel6�   5      5      5      