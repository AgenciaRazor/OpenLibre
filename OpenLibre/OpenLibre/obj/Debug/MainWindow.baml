   M S B A M L   `   `   `  ����D  @OpenLibre, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OpenLibre	OpenLibre  5   	       OpenLibre.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:OpenLibre     5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency .  � Icon$ imagens\Livro.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Livros��5   	   $	��350��6   $	��525��6%   ��5   	   �� *larguraMinima_Da_Janela+��5   	   �� *AlturaMiima_Da_janela+ � 	Resources 5         OpenLibre.MainWindow �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius � RowDefinitions �� FallbackValue K� ZIndex � ColumnDefinitions �� Orientation   BotãoDoWindows  BotãoFechar��%�  '        7   7   7  �� 5   
   "  6   .�5      ��  � �� 5      �� 5      "	 �6&   .R�5      �� 
�������$
 16 16 16 16��64   ._�5      � .+�5   "   �� ���#fafafa$
 16 16 16 16��6>   � 5       5   "   �� 5   &   ��64   �� *TamanhoDaBarraDeTitulo+$ 42���� 5!   &   $��* �64   .+�5$   "   � $��0��6'   $ 1��67    5%   &   �� 5'   *   $��* �6;   �� 5)   *   $
��Auto �6;   .+�5-   &   �� $��15(�60   ���#686868$
��Left=�6S   $��Center=�6n   $��0q�6�   
Open Libre6�   �� 50   &   $ 
Horizontal=�61   $��1��6J   .+�52   *   �� $��_��6W   8��  ��61   �� *Comando_Minimizar+6�   �� 54   *   $	��[ ]��6W   8�� ��61   �� *Comando_Maximizar+6�   �� 56   *   $��X��6T   8�� ��61   �� *Comando_Fechar+6�   58   '   59   #   �� 5<   "   $��2��6)   $
 10��66   ._�5=   &   �� #��z��67   5>   #   5@      5B      5D      5E      5J      5L      5N      '  !System.Windows.Shell.WindowChrome   WindowChrome 5Q        5R   
      GlassFrameThickness$ 0q�5V   
      CornerRadius$ 0��5W         ResizeBorderThickness 5S   
   �� *!RedimensionamentoBordaThickness+   CaptionHeight 5U   
   �� *TamanhoDaBarraDeTitulo+5W      .��5Y      � ���#fefefe.+�5Z   
    � -   5          �Name$ 	MainFrame��5Z        � NavigationUIVisibility$ Hidden=�6#   ��6C   �� *Pagina_Atual+ �� 	Converter    OpenLibre.AppConversao  5[      5\      