   M S B A M L   `   `   `  ����D  @Projekt_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projekt_1.ViewsProjekt_1.Views  5      7 clr-namespace:Projekt_1.ControlsProjekt_1.Controls  5      !    Projekt_1.Views.SongDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Projekt_1.Views     5      4control clr-namespace:Projekt_1.Controls     5        N� Title$  SongDetails��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5      �� -   5        $��	SongTitle��5   8      
LabelStyle#��[  6   $��30(�6I   .��6W   
SONG TITLE6c   �� 5      -   5        $
��play��5        TogglePlaySongButton#��[ 6!   6n   5      �� 5   
   $��1��6   $��0��6"   .+�5      �� $ 
Horizontal=�6   .+�5      �� -   5        $��	AlbumName��5   <   #��[  6   .��6M   ALBUM6T   �� 5      -   5        $��
ArtistName��5   <   #��[  6   .��6N   
ARTIST/S6X   5!      � 5"      .+�5#      �� -   5        $��Genre��5#   <   #��[  6   .��6I   	NO GENRES6T   #   Projekt_1.Controls.StarRating  5$      -   5          Name$ Rating��5$   j   #   Projekt_1.Controls.StarRating   UserControlClick$ 	SongRated��6z   $��0,0,0,3q�6%   $��Right=�66   $	��Top=�6R   6�   5%      5'      �� 5(   
   -   5          ButtonTemplate#��[ 5(      $��0��6<   $	��Top=�6I   $��1��6a   $
��auto��6q   $��0,15,0,5q�6~   .��6�   Back6�   �� 5)   
   $��1��6   $��1��6#   $��Bottom=�64   .+�5*      �� -   5        $��AverageScore��5*        TextBlockStyle#��[ 6,   $��Center=�6T   $��20(�6q    J� Opacity$	 0.7Q�6   
No Ratings6�   �� 5+      -	   5        $��NumberOfRatings��5+      #��[ 6/   $��Center=�6W   $��10(�6t   $	 0.7Q�6�   (120)6�   5,      �� 5/   
   -
   5         ��Name$ CommentTextBox��5/   2   ���#616161$��5q�6'   $��2��6J   $��0��6W    �� TextWrapping$
 Wrap=�6h   	 �� AcceptsReturn	 . "
 �� VerticalScrollBarVisibility$

 Auto=�6�    �� 	MaxLength$	 512��6�   .��6�   50      �� 51   
   -   5        $��CharacterCount��51      $��Center=�6*   #��[ 6G   $	 0.7Q�6o   $��2��6}   $��1��6�   $��Center=�6�   $��0,5,45,5q�6�   1006�   �� 52   
   -   5        $��CharacterLimit��52      $��Center=�6*   #��[ 6G   $	 0.7Q�6o   $��2��6}   $��1��6�   $��Center=�6�   $	��0,5q�6�   /5126�   �� 56   
   -   5        #��[ 56      $	 0.7Q�6P   $	��0,5q�6^   $��Bottom=�6k   $��2��6�   $��1��6�   .��6�   	Comment6�   � 58   
   $��3��6   $��0��6   $��2��6,    59      �� 5:      $
��auto �6    �� 5;      .+�5=      �� #��[  6   $��0��68   $	��Top=�6E   .��6]   	Comments:6h   �� 5>      -   5        $��CommentsList��5>      ���#616161  ListBoxStyle#��[ 6@   $��1��6s   $��0q�6�   .@�5?      �� 5@      5A      �� 5B      -   5        $��NoCommentsBlock��5B      $��5q�6/   $��1��6:   No Comments6T   5C      5F      5G      