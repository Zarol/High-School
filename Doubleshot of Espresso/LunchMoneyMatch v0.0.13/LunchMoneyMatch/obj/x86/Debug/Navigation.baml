   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=0.9.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5       LunchMoneyMatch    LunchMoneyMatch.Navigation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T
Behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        N� Title$  
Navigation��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   �� 5      $H Bpack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml?�6%   �� 5      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6%   �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   �� 5      $e _pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml?�6%   %    5      .��5      0   *MahApps.Metro.Controls.MetroContentControl  .��5   
   � -   5        $��	gridTiles��5      .+�5   
   � -   5        $��grid1��5   K   $	��260��6   $��Center=�6   $��0,0,0,15q�69   $��bottom=�6X   $	��730��6s    � RowDefinitions 5      �� 5       $��1* �6    �� 5!      $��1* �6     � ColumnDefinitions 5#      �� 5$      $��1* �6#   �� 5%      $��1* �6#   �� 5&      $��1* �6#   �� 5'      $��1* �6#   �� 5(      $��1* �6#   �� 5)      $��1* �6#   .+�5,      !   MahApps.Metro.Controls.Tile  -   5        $��tileNotifications��5,   ^   $�� ��6   $
��Auto��6'   $��Stretch=�65   $��3q�6S   $��Stretch=�6w   $
��Auto��6�     5.      -   5        $��tileJob��5.   z   $��Job Listings��6   $��1��63   $
��Auto��6C   $��Stretch=�6Q   $��3q�6o   $��Stretch=�6�   $
��Auto��6�   6�     50      -   5        $��tileClassifieds��50   z   $��Calander��6    $��2��63   $
��Auto��6C   $��Stretch=�6Q   $��3q�6o   $��Stretch=�6�   $
��Auto��6�   6�     52      -   5        $��tileProfile��52   u   $��Profile��6   $��3��6.   $
��Auto��6>   $��Stretch=�6L   $��3q�6j   $��Stretch=�6�   $
��Auto��6�   6�     54      -   5        $��
tileResume��54   t   $��Resume��6   $��4��6-   $
��Auto��6=   $��Stretch=�6K   $��3q�6i   $��Stretch=�6�   $
��Auto��6�   6�     56      -   5        $��tileCommunity��56   n   $�� ��6   $��5��6'   $
��Auto��67   $��Stretch=�6E   $��3q�6c   $��Stretch=�6�   $
��Auto��6�     58      -	   5        $��tileMail��58   k   $�� ��6   $��1��6'   $
��Auto��64   $��Stretch=�6B   $��3q�6`   $��Stretch=�6{   $
��Auto��6�     5:      -
   5        $��tileEducation��5:   {   $�� ��6   $��1��6'   $��1��67   $
��Auto��6D   $��Stretch=�6R   $��3q�6p   $��Stretch=�6�   $
��Auto��6�     5<      -   5        $��tileHome��5<   {   $�� ��6   $��2��6'   $��1��67   $
��Auto��6D   $��Stretch=�6R   $��3q�6p   $��Stretch=�6�   $
��Auto��6�     5>      -   5        $��tileCalendar��5>   {   $�� ��6   $��3��6'   $��1��67   $
��Auto��6D   $��Stretch=�6R   $��3q�6p   $��Stretch=�6�   $
��Auto��6�   6�     5@      -   5        $��tileApplicationStatus��5@   {   $�� ��6   $��4��6'   $��1��67   $
��Auto��6D   $��Stretch=�6R   $��3q�6p   $��Stretch=�6�   $
��Auto��6�     5B      -   5        $��tileSettings��5B      $�� ��6    $��5��6+   $��1��6;   $
��Auto��6H   $��Stretch=�6V   $��3q�6t   $��Stretch=�6�   $
��Auto��6�   6�   5C      �� 5D   
   -   5        $��lblFirstName��5D   b   $��
First Name��6   $
��Auto��6%   $
��Left=�63   $��
240,35,0,0q�6N   $	��Top=�6v   $
��Auto��6�   $��40(�6�   $
��Bold"�6�   �� 5E   
   -   5        $��lblLastName��5E   �   $��	Last Name��6   $��40(�6$   $
��Bold"�62   $
��Auto��6D   $
��Left=�6R   $��
280,70,0,0q�6m   $	��Top=�6�   $
��Auto��6�   �� 5F   
   -   5        $��borderProfileImage��5F   v   ���#3b5998$��5q�6'   $	��200��6;   $
��Left=�6H   $��	35,35,0,0q�6c   $	��Top=�6�   $	��200��6�   ._�5G      �� -   5        $��imageProfile��5G   "   $
��Auto��6   $
��Fill=�66   $
��Auto��6E   5H      5I      5J      5K      