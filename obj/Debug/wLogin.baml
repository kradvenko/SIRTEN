   M S B A M L   `   `   `  ����A  =SIRTEN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SIRTENSIRTEN  5   	       SIRTEN.wLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:SIRTEN     5   	     � Title$  Inicio de Sesión��5   	   $	��400��6"   $	��300��6/    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � WindowStyle$
 None=�6v   .��5	      ]� ��.  ��5
   
   �� 5       �� ImageSource$) #Imagenes/noise-background-login.png��6    j� Stretch$
 Fill=�6K    j� TileMode$
 Tile=�6Z   .+�5   
   � $	��Top=�6   ���	#7F4F628E � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� $��0��6   .��6$   Inicio de Sesión66   ]� 5      $��2��6   ��.  $��
0, 0, 5, 0q�6>   .+�5      �� -   5        $��Right=�5      $��15��6E   $��15��6S   ��5      �� 5       �� 
TargetType" ��6    .�5      �� 	 �� Property	 � ��
 �� Value
 5   "   �� 5   &   $ Imagenes/close-window.png��61   6[   5      �� 5      	 � ��
 5   "   �� 5   &    �� 
TargetType" ��66   .R�5    *   �� #��z��61   
���   �$��0q�6o   ._�5!   .   �� $��Center=�6?   $��Center=�6\   5"   +   5#   '   5%       �� Triggers 5&      P� 5'   "    P� Property �@J�IsMouseOver P� Value . . �5(   &   �� 	 � ��
 5)   *   �� 5*   .   $) #Imagenes/close-window-highlight.png��69   6m   5,   '   5-   #   5/      51      52      53      � 54   
   $	��Top=�6   $��30, 30, 30, 0q�6)   .+�55      �� $
��Auto��6   $
��Auto��6"   $��Imagenes/Logo2018.png��6/   $��Uniform=�6N   56      �� 57   
   $��Center=�6   $��Center=�60   $	��200��6M   $	��Top=�6Y   .+�58      �� $��USUARIO��6   �� 59      -   5         ��Name$ tbLogin��59   a   $��23��6    �� TextWrapping$
 Wrap=�6"   $�� ��66   $	��0,0q�6>   $��Center=�6r   $��Center=�6�   �� 5:      $��CONTRASEÑA��6   G� 5;      -   5         G�Name$ 
pbPassword��5;   h   
����ح� G� PasswordChar$ *��61   $��23��6B   $��Center=�6|   $��Center=�6�   5<      � 5=   
   $��Bottom=�6   ���#162955 � RowDefinitions 5>      �� 5?      $��* �6    6-   �� 5@      $��* �6    6-   �� 5A      $��* �6    6-   .+�5C      �� $��1��6   
�������.��64   #!Registro Público de la Propiedad6V   5D      5E      5F      