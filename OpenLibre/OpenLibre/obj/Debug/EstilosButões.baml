   M S B A M L   `   `   `  ����D  @OpenLibre, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OpenLibre	OpenLibre  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   FontAwesome  �� 
TargetType  BotãoDoWindows'   !System.Windows.Shell.WindowChrome �� Property �� Value �� ScaleX �� 
TargetType �� Padding �� Triggers P� Property P� Value  BotãoFechar	 �� BasedOn  
TextButton
 ��Name �� CornerRadius J� SnapsToDevicePixels �� Triggers 	 Botao ��Name ��Name J� IsHitTestVisible
 � Tag �� Padding �� Binding �� RelativeSource �� Value �� 
TargetName  BotaoDeTexto  BotaoPassword  ButaoLivros  	ButaoCasa 	 ButaoPesquisa 
 CaixaBoxPesquisa � ColumnDefinitions  ButaoDeRegistroUser  TextblocStyle  Comando  StyleControle � RowDefinitions K� IsItemsHost  tabItem 
 Botao1�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      !localclr-namespace:OpenLibre  5      % 3  &	        &	 ?     &	 �    7  &	 N    &	 �    &	 �    &	 	    &	 w    7   &	 3    7   &		 �    7   &	
 �    &	 4!    7   &	 �#    7   &	 �$    &	 n'    &	 �)    &	 -    *�5      +'pack://appliction;,,,/Font/#FontAwesome)�6N   �� 5      "  ��6   .�5
   
   ��   �@  IsHitTestVisibleInChrome . 6B   �� 5   
    � ��
 ���� 6'   �� 5   
    � ��$ 8q�6$   �� 5   
    � �� �#6868686'   �� 5   
    �@�LayoutTransform 5      �� 5      $	 1.5Q�6!   5      �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� # z��6   #��z��6A   ._�5      �� $��Center=�6$   $��Center=�6?   #��z��6\   5      5      5       5!   
   P� 5#       �@J�IsMouseOver . . �5%      ��  � �� �#efefef6/   5&      5)      �� 5,      "  ��6   8	    5-   
   P� 5.       �@J�IsMouseOver . . �5/      ��  � ��
 �  ��6/   �� 50       � �� �#efefef6/   51      54      �� 57      "  ��6   .�58   
   ��  � �� �#5dbf4c6'   �� 59   
    � ��
 �����6'   �� 5:   
    � ��$ 0q�6,   �� 5;   
    � ��$ 20(�6%   �� 5<   
    � ��$ Segoe UI)�6'   �� 5=   
    � ��$ 50 10q�6$   �� 5>   
    � ��$
 0 10q�6#   �� 5?   
    � ��$ 40��6#   �� 5B   
    � �� 5C      �� 5D      " ��6"   .R�5E      �� $
 border��6   $ 2��5F      #��z��5G      #��z��5H      #��z��5I       . ._�5K      �� #��z��6$   #��z��5L   $   |�.  #��z��5N   +   #��z��5O   +   # z 5P   +   #��z��5Q   +   5R       5S      P� 5T       �@J�IsMouseOver . . �5U      ��  � ��
 � ���6<   5V      P� 5W       � {� .  . �5X      ��  � �� �#bdbdbd6;   5Y      5[      5]      5^      �� 5a      "  ��6   .�5c   
   ��  � ��$ Segoe UI)�6'   �� 5d   
    � �� �#9e7b7b6)   �� 5e   
    � ��$ 20(�6%   �� 5f   
    � ��$ 6q�6$   �� 5g   
    � ��$ 0 0 0 0q�6#   �� 5h   
    � ��$ 1q�6,   �� 5i   
    � ��$ 40��6#   �� 5k   
    � �� 5l      �� 5m      " ��6#   .R�5o      � .+�5p      �� $
 border��6!   $ 2��5q   !   #��z��5r   !   #��z��5s   !   #��z��5t   !    . ._�5v      �� $ PART_ContentHost��6+   |�.  $��Hidden=�5x   +   $��Hidden=�5y   +   5z      �� 5{      $ PlaceHolder��5}   $    .  #��z 5|   $   #��z��5~   $   # z��5   $   $��Center=�5�   $   $��Center=�5�   $   
���  ����5�      �� 5�   "   "  ��6(   .�5�   &   ��  � y�$ 	Collapsed=�6C    5�   &   �� 5�   *    66   �� *Text+ �� *TemplatedParent+  6   .a�5�   .   ��  � y�$ Visible=�6K   5�   +   5�   #   5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��68    �@J�Opacity$
 0.56Q�6L   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ border��6<    � �� �	#FF7EB4EA6P   5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� $ border��6<    � �� �	#FF569DE56P   5�      5�      5�      5�      �� 5�      "  ��6!   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � �� �#5258596'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$ 20(�6%   �� 5�   
    � ��$ Segoe UI)�6'   �� 5�   
    � ��$ 50 10q�6$   �� 5�   
    � ��$
 0 10q�6#   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $
 border��6   $ 10��5�      #��z��5�      #��z��5�      #��z��5�       . ._�5�      �� #��z��6$   |�.  #��z��5�   $   #��z��5�   $   #��z��5�   $   # z 5�   $   #��z��5�   $   5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 � ���6;   5�      P� 5�       � {� .  . �5�      ��  � ��
 �   �6;   5�      5�      5�      5�      �� 5�      "  G�6   .�5�   
   ��  � ��$ Segoe UI)�6'   �� 5�   
    � �� �#9e7b7b6)   �� 5�   
    � ��$ 20(�6%   �� 5�   
    � ��$ 6q�6$   �� 5�   
    � ��$ 0 0 0 0q�6#   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��$ 40��6#   �� 5�   
    � �� 5�      �� 5�      " G�6#   .R�5�      � .+�5�      �� $
 border��6!   $ 2��5�   !   #��z��5�   !   #��z��5�   !   #��z��5�   !    . ._�5�      �� $ PART_ContentHost��6+   |�.  $��Hidden=�5�   +   $��Hidden=�5�   +   5�      �� 5�      $ PlaceHolder��5�   $    .  #��z 5�   $   #��z��5�   $   # z��5�   $   $��Center=�5�   $   $
��Left=�5�   $   ���#bab6b65�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��68    �@J�Opacity$
 0.56Q�6L   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ border��6<    � �� �	#FF7EB4EA6P   5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� $ border��6<    � �� �	#FF569DE56P   5�      5�      5�      5     �� 5     "  ��6   .�5  
   ��  � ��
 �����6'   �� 5  
    � �� �#5258596'   �� 5  
    � ��$ Center=�60   �� 5  
    � ��$ Center=�6.   �� 5	  
    � ��
 � � �6(   �� 5  
    � ��8   6'   �� 5  
    � ��$ 20(�6%   �� 5  
    � �� 5     �� 5     " ��6"   .R�5     �� #��z��6   ._�5     �� $	����6$   #��z��5  $   #��z��5  $   #��z��5  $   #��z��5  $   $��40(�5  $   $��10 10 10 10q�5  $   5     5     5      5  
   P� 5      �@J�IsMouseOver . . �5      ��  � ��
 � � �6/   �� 5!      � ��
 � ���6/   5"     5$     �� 5'     "  ��6   .�5(  
   ��  � ��
 �����6'   �� 5)  
    � �� �#5258596'   �� 5*  
    � ��$ Center=�60   �� 5+  
    � ��$ Center=�6.   �� 5,  
    � ��
 � � �6(   �� 5-  
    � ��8   6'   �� 5.  
    � ��$ 20(�6%   �� 5/  
    � �� 50     �� 51     " ��6"   .R�52     �� #��z��6   ._�53     �� $	����6$   #��z��54  $   #��z��55  $   #��z��56  $   #��z��57  $   $��40(�58  $   $��10 10 10 10q�59  $   5:     5;     5=      5>  
   P� 5?      �@J�IsMouseOver . . �5@     ��  � ��
 � � �6/   �� 5A      � ��
 � ���6/   5B     5D     �� 5G     "  ��6   .�5H  
   ��  � ��
 �   �6'   �� 5I  
    � ��
 �����6'   �� 5J  
    � ��$ Center=�60   �� 5K  
    � ��$ Center=�6.   �� 5L  
    � ��
 � � �6(   �� 5M  
    � ��8   6'   �� 5N  
    � ��$ 25(�6%   �� 5O  
    � �� 5P     �� 5Q     " ��6"   .R�5R     �� #��z��6   ._�5S     �� $	����6$   #��z��5T  $   #��z��5U  $   #��z��5V  $   #��z��5W  $   $��20(�5X  $   $��5 5 5 5q�5Y  $   5\     5]     5_      5`  
   P� 5a      �@J�IsMouseOver . . �5b     ��  � ��
 �   �6/   �� 5c      � ��
 �����6/   5d     5f     �� 5i     "  ��6   .�5k  
   ��  � ��$ Segoe UI)�6'   �� 5l  
    � �� �#9e7b7b6)   �� 5m  
    � ��$ 20(�6%   �� 5n  
    � ��$ 6q�6$   �� 5o  
    � ��$ 0 0 0 1q�6#   �� 5p  
    � ��$ 0 0 0 1q�6,   �� 5q  
    � ��$ 40��6#   �� 5s  
    � �� 5t     �� 5u     " ��6#   .R�5w     �  5x     �� 5y     $��* �6/   �� 5z     $
��Auto �6/   .+�5}     �� $
 border��6!   #��z��5~  !   #��z��5  !   #��z��5�  !    . ._�5�     �� $ PART_ContentHost��6+   |�.  $��Hidden=�5�  +   $��Hidden=�5�  +   5�     �� 5�     $ PlaceHolder��5�  $    .  #��z 5�  $   #��z��5�  $   # z��5�  $   $��Center=�5�  $   $��Center=�5�  $   
���������5�     �� 5�  "   "  ��6(   .�5�  &   ��  � y�$ 	Collapsed=�6C    5�  &   �� 5�  *    66   �� *Text+ �� *TemplatedParent+  6   .a�5�  .   ��  � y�$ Visible=�6K   5�  +   5�  #   5�     5�      5�     P� 5�      � {� .  . �5�     �� $ border��68    �@J�Opacity$
 0.56Q�6L   5�     P� 5�      �@J�IsMouseOver . . �5�     �� $ border��6<    � �� �	#FF7EB4EA6P   5�     P� 5�      �@J�IsKeyboardFocused . . �5�     �� $ border��6<    � �� �	#FF569DE56P   5�     5�     5�     5�     �� 5�     "  ��6   .�5�  
   ��  � ��
 �   �6'   �� 5�  
    � ��
 �����6'   �� 5�  
    � ��$ Center=�60   �� 5�  
    � ��$ Center=�6.   �� 5�  
    � ��
 � � �6(   �� 5�  
    � ��8   6'   �� 5�  
    � ��$ 25(�6%   �� 5�  
    � �� 5�     �� 5�     " ��6"   .R�5�     �� #��z��6   ._�5�     �� $	����6$   #��z��5�  $   #��z��5�  $   #��z��5�  $   #��z��5�  $   $��33(�5�  $   $��15 15 16 15q�5�  $   5�     5�     5�      5�  
   P� 5�      �@J�IsMouseOver . . �5�     ��  � ��
 �   �6/   �� 5�      � ��
 �����6/   5�     5�     �� 5�     "  ��6   .�5�  
   ��  � ��8   6'   �� 5�  
    � ��$ 45(�6%   �� 5�  
    �@��Padding$ 8q�6$   �� 5�  
    � ��
 �����6'   5�     �� 5�     "  ��6   .�5�  
   ��  � ��$ Arial)�6'   �� 5�  
    � ��$ 20(�6%   �� 5�  
    � ��$ Center=�6.   �� 5�  
    � ��$ Center=�60   �� 5�  
    � ��$ 6q�6$   �� 5�  
    � ��$ 0q�6,   �� 5�  
    � ��
 �����6'   �� 5�  
    � �� �#5258596'   �� 5�  
    � �� 5�     �� 5�     " ��6"   .R�5�     �� #��z��6   #��z��5�     ._�5�     �� $ texto��6$   #��z��5�     |�.  #��z��5�  $   #��z��5�  $   #��z��5�  $   # z 5�  $   #��z��5�  $   5�      5�     P� 5�      �@J�IsMouseOver . . �5�     ��  � ��
 � ���6;   5�     5�     5�     5�     �� 5�     "  ��6   .�5�  
   ��  � ��$ 0 0 0 1q�6,   �� 5�  
    � ��
 �  ��6(   �� 5   
    � ��
 ��ح�6'   �� 5  
    � �� 5     �� 5     " ��6"   .R�5     �  5     �� 5     $
��Auto �6(   �� 5     $��* �6(   .+�5	     �� $��0,0,1,1q�6   ���#D0CEBF$��1��6M   ._�5
     �� #��z��6!   #��z��5     ._�5     �� #��z��6%   ._�5  "   �� $��SelectedContent��63   5     5     5     �� 5     $��0��6    . 6,   5     5     5     5     �� 5     "  ��6   .�5  
   ��  � ��$ 0 0 0 1q�6,   �� 5  
    � ��
 ���� 6(   �� 5  
    � ��$ Center=�6.   �� 5  
    � ��$ Center=�60   �� 5  
    � �� �#fefefe6'   �� 5  
    � �� 5      �� 5!     " ��6"   .R�5"     �� ._�5#     � .+�5$     � .+�5%     �� $
 Borda��6&   #��z��5&  "   #��z��5'  %   #��z��5(  %   5)     �� 5*     #��z��6%   # z��5+  %   #��z��5,  %   ._�5.  "   �� #��z��6,   $��15(�5/  ,   $��Arial)�50  ,   
���   �$��Stretch=�52  ,   53  #   55     56     57      58     P� 59      �@J�IsMouseOver . . �5:     �� $ Borda��6<    � ��
 � � �6O   5;     P� 5<      �@��
IsSelected . . �5=     �� $ Borda��6<    � ��
 � � �6O   5>     5@     5B     5D     �� 5G     "  ��6   .�5H  
   ��  � ��$ 30��6#   �� 5I  
    � ��$ Segoe UI)�6'   �� 5J  
    � ��
 �   �6)   �� 5K  
    � ��$ 12(�6%   �� 5L  
    � ��$ 6q�6$   �� 5M  
    � ��$ 0 0 0 0q�6#   �� 5N  
    � ��$ 1q�6,   �� 5Q  
    � �� 5R     �� 5S     " ��6"   .R�5T     � .+�5U     �� $
 Borda��6!   $ 2��5V  !   #��z��5W  !   #��z��5X  !   #��z��5Y  !    . ._�5[     �� $ PART_ContentHost��6+   |�.  $��Hidden=�5]  +   $��Hidden=�5^  +   5_     �� 5`     $ PlaceHolder��5b  $    .  #��z 5a  $   #��z��5c  $   # z��5d  $   $��Center=�5e  $   $��Center=�5f  $   
���  ����5h     �� 5i  "   "  ��6(   .�5j  &   ��  � y�$ 	Collapsed=�6C    5l  &   �� 5n  *    66   �� *Text+ �� *TemplatedParent+  6   .a�5o  .   ��  � y�$ Visible=�6K   5p  +   5r  #   5t     5v      5w     P� 5x      � {� .  . �5y     �� $ Borda��68    �@J�Opacity$
 0.56Q�6K   5z     P� 5{      �@J�IsMouseOver . . �5|     �� $ Borda��6<    � ��
 � � �6O   5}     P� 5~      �@J�IsKeyboardFocused . . �5     �� $ Borda��6<    � ��
 � � �6O   5�     5�     5�     5�     5�     