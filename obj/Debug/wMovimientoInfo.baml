   M S B A M L   `   `   `  ����b  ^Syncfusion.SfInput.Wpf, Version=16.1460.0.32, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89uOclr-namespace:Syncfusion.Windows.Controls.Input;assembly=Syncfusion.SfInput.Wpf!Syncfusion.Windows.Controls.Input  5   	   A =SIRTEN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SIRTENSIRTEN 5   	      SIRTEN.wMovimientoInfo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   f
SyncfusionOclr-namespace:Syncfusion.Windows.Controls.Input;assembly=Syncfusion.SfInput.Wpf     5   	   &localclr-namespace:SIRTEN     5   	     � Title$  
Movimiento��5	   	   $	��200��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5
         WatermarkTemplate J� Opacity��%T   &	        �� 5   
   .R�5      �� $	 0.5Q�6)   ��6   �� 6)   5      5      .��5      �  5   
    �� 
TargetType  TextBoxStyle �� BasedOn��%0   '��       7  �� 5      " ��6   8   6)   5       � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5       $��* �6   6)   �� 5!      $��* �6   6)   .+�5$   
   �� $��0��6   $��0��6   $
��Acto��6-   6>   4   .Syncfusion.Windows.Controls.Input.SfTextBoxExt  5%   
   -   5          Name$ tbActos��5%   ^   $��0��6"   $��1��6/   $��5��6?   $��2q�6S   	   	Watermark$!	 Escribe el nombre del acto.��5&      
   AutoCompleteMode$
 SuggestAppend=�5'         SearchItemPath$ Nombre��6?      SuggestionMode$ Contains=�5(         WatermarkTemplate# [  5)      $��Center=�5,      $��Center=�6B    �� CharacterCasing$ Upper=�6d   .��6|      AutoCompleteItemTemplate 5-      �� 5.      .R�5/      ��  �� Orientation$ 
Horizontal=�6!   .+�51      �� $��3 0 0 0q�6<   ��6$   �� *Nombre+6<   52      53      .��54   @   55      �� 57   
   $��1��6   $��0��6   $��
Movimiento��6-   6D     58   
   -   5        $ tbMovimientos��58   ^   $��1��6"   $��1��6/   $��5��6?   $��2q�6S   $!	 Escribe el nombre del acto.��59      $
 SuggestAppend=�5:      $ Nombre��6?   $ Contains=�5;      # [  5<      $��Center=�5?      $��Center=�6B   $ Upper=�6d   .��6|    5@      �� 5A      .R�5B      �� $ 
Horizontal=�6!   .+�5D      �� $��3 0 0 0q�6<   ��6$   �� *Nombre+6<   5E      5F      .��5G   @   5H      �� 5J   
   $��2��6   $��0��6   $��
Valor base��6-   6D   �� 5K   
   -   5         ��Name$ tbValorBase��5K      $��2��6'   $��1��64   $��2��6D   $��0��6~   6�   �� 5M   
   $��2��6   $��3��6   $��Cantidad��6-   6B   �� 5N   
   -   5         ��Name$ lblCantidad��5N   9   $��2��6   $��4��6   $��$��6-   6P   �� 5P   
   -   5        $��4��5P      $��5��6!   $��Guardar��6.   $��Stretch=�6@   $��Stretch=�6^   6z   �� 5Q   
   -   5        $��5��5Q      $��5��6!   $��Cancelar��6.   $��Stretch=�6A   $��Stretch=�6_   6{   5R      5S      