   M S B A M L   `   `   `  ����J  FLunchMoneyMatch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LunchMoneyMatchLunchMoneyMatch  5      T PMahApps.Metro, Version=0.9.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      "    LunchMoneyMatch.AlertControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      /localclr-namespace:LunchMoneyMatch     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T
Behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      
�������  � 	Resources  5       �� MergedDictionaries �� Source$  LunchMoneyMatch.offsetVertical   offsetVertical  rollDown �� 
TargetName �� TargetProperty g� Duration g� 	BeginTime t� From `� 	Converter	 �� ElementName
 �� Path	 t� To 
 rollUp�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   �� 5      $H Bpack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml?�6%   �� 5      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6%   �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   �� 5      $e _pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml?�6%   %�  &	        &	      7   &	 �    7     5      6#   �� 5      .��5      t� $ gridContent��6%   $ Margin�6I   $ 0:0:0.5D�6l   $ 0:0:0X�6    5      `� 5      8   .1�5      �� $	 gridRoot��6&   $
 Margin.Left�5      �� 5      $	 gridRoot��6&   $
 ActualHeight�5      �� 5       $	 gridRoot��6&   $
 Margin.Right�5!      �� 5"      $	 gridRoot��6&   $
 ActualHeight�5#      5$      $ 0X�5(   -   5)      5*      �� 5+      .��5,      t� $ gridContent��6%   $ Margin�6I   $ 0:0:0.5D�6l   $ 0:0:0X�6    5-      `� 5.      8   .1�5/      �� $	 gridRoot��6&   $
 Margin.Left�50      �� 51      $	 gridRoot��6&   $
 ActualHeight�52      �� 53      $	 gridRoot��6&   $
 Margin.Right�54      �� 55      $	 gridRoot��6&   $
 ActualHeight�56      57      $ 0X�5;   /   5<      5=      5>      .��5B      � -   5        $��gridRoot��5B      
������ .+�5L   
   � -   5        $��gridContent��5L      ���#41a907��6"   ��  �� Source$ gridRoot��$
 Width���6P   �� $ gridRoot��$
 Width� � ColumnDefinitions 5M      �� 5N      $��40 �6#   �� 5O      $
��700* �6#   ��5Q      `� 5R      # [  6   .1�5S      �� $	 gridRoot��6   $
 Margin.Left�5T      �� 5U      $	 gridRoot��6   $
 ActualHeight�5V      �� 5W      $	 gridRoot��6   $
 Margin.Right�5X      �� 5Y      $	 gridRoot��6   $
 ActualHeight�5Z      5[      .+�5]      �� -   5        $��
lblContent��5]      $��MAX 70 CHARACTERS��6&   $��20(�6B   
�������$
��Auto��6c   $
��Auto��6p   $��Center=�6~   $��Center=�6�   $��0q�6�   $��1��6�   6�   �� 5^      -   5        $��	btnRemove��5^      $��30��6&   $��30��62   $��0��6=     MetroCircleButtonStyle#���  6M   $��Center=�6~   $��Center=�6�   .��5_      �� $��15��6   $��15��6'   ��5`      !� 5a       j� Stretch$
 Fill=�6&     appbar_close !� Visual# [ 65   5c      5d      5e      5g      5h      