   M S B A M L   `   `   `  ����D  @Projekt_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projekt_1.ViewsProjekt_1.Views  5      7 clr-namespace:Projekt_1.ControlsProjekt_1.Controls  5      "    Projekt_1.Views.ItemsDisplay   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Projekt_1.Views     5      4control clr-namespace:Projekt_1.Controls     5      -   5          N� Title$  	SongsView��5
       � 	Resources 5         AddToPlaylistButton  ToggleAddToPlaylist  AddPlaylist  ToggleAddPlaylist  AddToFavourites#   Projekt_1.Controls.Favourites#   Projekt_1.Controls.Favourites   Loaded   	onUncheck   onCheck  PlaySong ��Name  TogglePlaySongButton �� 
TargetType �� Property �� Value	 �� Triggers
 �� Binding �� RelativeSource �� Mode �� AncestorType �� Path �� Value  
DeleteSong  ToggleDeleteButton��%  &	        7  &	 D     7  &	 �     &	     7  &	 g    7  �� 5   
   .R�5      �� -   5        8��  5   8   5      �� 5   
   .R�5      �� -   5        8��  5   ;   5      �� 5   
   .R�5         FavouriteStatus6!    RemoveArtistsFromFavourites6:    AddArtistToFavourites6b   5      �� 5   
   .R�5      �� $
 Play��6   -   5        8��  ��5      �� 5      " ��6   .�5      ��  � y�$ Hidden=�67   5      	 5      �� 5       
 6*   ��  �� $ FindAncestor=�" ��$ IsMouseOver� True6�   .a�5!   "   ��  � y�$ Visible=�6?   6Q   5"      5$      5&      5'      �� 5)   
   .R�5*      �� $ Delete��6   -   5        8��  ��5+      �� 5,      " ��6   .�5-      ��  � y�$ Hidden=�67   5/      	 50      �� 51      
 6*   ��  �� $ FindAncestor=�" ��$ IsMouseOver� True6�   .a�52   "   ��  � y�$ Visible=�6?   6Q   53      55      57      58      5<      .��5>      �  � RowDefinitions 5@   
   �� 5A      $
��auto �6   �� 5B      $
��auto �6   �� 5C       � ColumnDefinitions 5E   
   �� 5F      $
��auto �6   �� 5G      �� 5H      $
��auto �6   .+�5K   
   �� -   5        $��	SearchBar��5K   >    	 TextBoxTemplate#��[	 6   $��1��6�   $��0��6�   $��5q�6�   $��5,0,5,0q�6�   6�   �� 5L   
   -   5        $��SearchButton��5L   @    
 ToggleSearchButton#��[
 6   $��2��6T   $��0��6d   $��5q�6�   .��6�   Search6�   �� 5N   
   -   5        $��
ItemsLabel��5N   U     
LabelStyle#��[ 6   $��1��64   $��2��6A   $��30(�6g   $
��Bold"�6u   6�   �� 5O   
   -	   5        $��DeleteButton��5O      #��[ 6A   $��1��6p   $y�Hidden=�6}   $��2��6�   6�   �� 5P   
   -
   5        $��LogoutButton��5P        ButtonTemplate#��[ 6A   $��1��6l   $y�	Collapsed=�6y   $��2��6�   $��Logout��6�   $��5q�6�   $��Center=�6�   6�   �� 5R   
   -   5        $��ItemsContainer��5R   4   $��3��6   $��2��6'   ���#616161��5S      �� 5T      " ��6   Item��.�5U      ��  � ��
 �   �63   	 5V      P� 5W       P� Property �@J�IsMouseOver P� Value . . �5X      ��  � �� �#6161616;   5Y      5\       �� View 5^      �� 5_      -   5        	ItemsGrid��! �� ColumnHeaderContainerStyle 5`      �� 5b      " ��6    .�5d      ��  � �� �#3737376;   	 5e      P� 5f   "    �@J�IsMouseOver . . �5g   &   ��  � �� �#6161616C   5i   #   5k      5n      5q      5s      5t      