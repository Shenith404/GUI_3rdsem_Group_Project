   M S B A M L   `   `   `  ����@  <test2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:test2test2  5   	       test2.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:test2     5   	   Ishell9http://schemas.microsoft.com/netfx/2009/xaml/presentation    6+     � WindowStyle$
  None=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5         test2.MainWindowVM  5   
   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 30Q�6      CornerRadius$ 20,20,20,20��5         GlassFrameThickness$ 0q�5         UseAeroCaptionButtons$ False��5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      $	��420 �6   �� 5#      $	��380 �6   .+�5%   
   �� $��1��6   .��5&      �� $��15��6   $$��/Images/black-close-icon-3.png��6      imgicon#��[  6I   5'      �� 5(   
   	 �� CornerRadius$	 	10 0 0 10��6   ._�50      � .+�51      �� $��Right=�6   $	��Top=�64   $��	0,155,0,0q�6L   $��/Images/c.jpg��6_   6y   �� 52      �� 53      $��
30 40 0 0 q�6   
 �� Orientation$
 
Horizontal=�61   $	��Top=�6J   .+�54      ��   CustomGradient_1#��[ 6!   $��5��6P   $��50��6Z   6h   �� 55      .+�56      �� $	��Top=�6%   $��
010 0  0 0q�6=   $��Student Management��6Q   $
��Wrap=�6k    �� TextAlignment$
 Left=�6   #��[ 6�     	titleText#��[ 6�   �� 57      $	��Top=�6%   $��010 -010  0 0q�6=   $��System��6T   $
��Wrap=�6b   $
 Left=�6v   #��[ 6�   #��[ 6�   59      5;      5<      5=      �� 5?   
   $��
 -60 0 0 0q�6   
�������$��1��68   $	 	0 10 10 0��6H   ._�5@      �� $��Center=�6   .+�5A      �� $��Right=�6   .+�5B      ��   ButtonStyle_Close#��[ 6>   ��6   �� *CloseCommand+.��6i   x6l   5C      �� 5D      $
��Left=�6   $��	60 40 0 0q�67   $�� Sing in to App��6J   #��[ 6a   #��[ 6�   �� 5F      $
��Left=�6   $��70 0 0 0q�67   $'��!or use your Username information ��6I     
normalText#��[ 6r   ���#8787876�   �� 5G      $��1q�6   ���#acb0af$
��70 7q�6C   $	 5��6Q   ._�5H      � $	��7 9q�6    5I      �� 5J      $
��auto �6/   �� 5K      $��* �6/   .+�5M      �� $��/Images/un.png��6    $��20��68   �� 5O      -   5         ��Name$ txtEmail��5O   O   
�������  textBox#��[ 6b   ��6"   �� *
UserName+6b   5P      5R      �� 5S      $��1q�6   ���#acb0af$
��70 7q�6C   $	 5��6Q   ._�5T      � $	��7 9q�6    5U      �� 5V      $
��auto �6/   �� 5W      $��* �6/   .+�5Y      �� $��/Images/pw.png��6    $��20��68   G� 5[      -   5         G�Name$ txtPassword��5[   &   
�������#��[ 6�       test2.PasswordBoxAssistant   BoundPassword 6N   �� *
Password+ �� Mode$ TwoWay=�6�   5\      5^      �� 5`      $��Sing In��6   $
��Left=�6+   $��
70 20 0 20q�6G     
mainbutton#��[ 6|   ��6[   �� *LoginCommand+6|   �� 5a      $
 
Horizontal=�6   $��70 20q�66   $
��Left=�6E   .+�5b      ��   buttonCircle#��[ 6   .��5c      �� $��/Images/g.png��6    $��20��67   $��20��6B   5d      �� 5e      #��[ 6   .��5f      �� $��/Images/in.png��6    $��20��68   $��20��6C   5g      �� 5h      #��[ 6   .��5i      �� $��/Images/fb.png��6    $��20��68   $��20��6C   5j      5k      5l      5m      5n      5o      