   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=0.9.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      J FLunchMoneyMatch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LunchMoneyMatchLunchMoneyMatch 5         LunchMoneyMatch.Profile   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T
Behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      /localclr-namespace:LunchMoneyMatch     5        N� Title$  Profile��5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   �� 5      $H Bpack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml?�6%   �� 5      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6%   �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   �� 5      $e _pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml?�6%   %    5      .��5      0   *MahApps.Metro.Controls.MetroContentControl  .��5   
   � .+�5      �� -   5        $��tabControl1��5   (   $��25,75q�6   .@�5      �� -   5        $��basicTab��5   )   $��Basic��6   .��5      � .+�5!      �� -   5        $��txtFirstName��5!   ]   $��30��6"   $
��Left=�6.   $��
170,10,0,0q�6I   *   $MahApps.Metro.Controls.TextboxHelper   	Watermark$ Enter first name��6q   $	��Top=�6�   $	��190��6�   6�   �� 5"      -   5        $��txtLastName��5"   ]   $��30��6"   $
��Left=�6.   $��
170,50,0,0q�6I   $ Enter last name��6p   $	��Top=�6�   $	��190��6�   6�   �� 5#      -   5        $��
txtAddress��5#   ^   $��30��6"   $
��Left=�6.   $��170,130,0,0q�6I   $ Enter home address��6p   $	��Top=�6�   $	��190��6�   6�   �� 5$      -   5        $��txtCity��5$   ^   $��30��6"   $
��Left=�6.   $��170,170,0,0q�6I   $ 
Enter city��6m   $	��Top=�6�   $	��190��6�   6�   �� 5%      -   5        $��
txtZipcode��5%   ^   $��30��6"   $
��Left=�6.   $��170,250,0,0q�6I   $ Enter zipcode��6p   $	��Top=�6�   $	��190��6�    �� 	MaxLength$ 5��6�   �� 5&      -   5        $��txtEmail��5&   ^   $��30��6"   $
��Left=�6.   $��170,290,0,0q�6I   $ Enter email address��6n   $	��Top=�6�   $	��190��6�   6�   �� 5'      -	   5        $��txtAreaCode��5'   ^   $��30��6"   $
��Left=�6.   $��170,330,0,0q�6I   $ Enter phone number��6q   $	��Top=�6�   $��49��6�   $ 3��6�   �� 5(      -
   5        $��	txtMobile��5(   ^   $��30��6"   $
��Left=�6.   $��170,370,0,0q�6I   $ Enter mobile number��6o   $	��Top=�6�   $	��190��6�   6�   (  "System.Windows.Controls.DatePicker  5)      -   5        $��dpDateOfBirth��5)   `   $��30��6%   $
��Left=�61   $��
170,90,0,0q�6L   $	��Top=�6u   $	��190��6�   �� 5*      -   5        $��	txtPhone1��5*   ^   $��30��6"   $
��Left=�6.   $��226,330,0,0q�6I   $ Enter phone number��6o   $	��Top=�6�   $��49��6�   $ 3��6�   �� 5+      -   5        $��	txtPhone2��5+   _   $��30��6"   $��Right=�6.   $��0,332,365,0q�6J   $ Enter phone number��6p   $	��Top=�6�   $��76��6�   $ 4��6�   �� 5,      -   5        $��lblFirstName��5,   t   $��1. First Name :��6    $��30��6:   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 5-      -   5        $��lblLastName��5-   s   $��2. Last Name :��6    $��30��69   $
��Left=�6E   $��	10,50,0,0q�6`   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 5.      -   5        $��lblDateOfBirth��5.   w   $��3. Date of Birth :��6    $��30��6=   $
��Left=�6I   $��	10,90,0,0q�6d   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 5/      -   5        $��
lblAddress��5/   r   $��4. Address :��6    $��30��67   $
��Left=�6C   $��
10,130,0,0q�6^   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 50      -   5        $��lblCity��50   o   $��	5. City :��6    $��30��64   $
��Left=�6@   $��
10,170,0,0q�6[   $	��Top=�6~   $	��140��6�   $��15(�6�   �� 51      -   5        $��lblState��51   p   $��
6. State :��6    $��30��65   $
��Left=�6A   $��
10,210,0,0q�6\   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 52      -   5        $��
lblZipcode��52   r   $��7. Zipcode :��6    $��30��67   $
��Left=�6C   $��
10,250,0,0q�6^   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 53      -   5        $��lblEmail��53   p   $��
8. Email :��6    $��30��65   $
��Left=�6A   $��
10,290,0,0q�6\   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 54      -   5        $��lblPhoneNumber��54   w   $��9. Phone Number :��6    $��30��6<   $
��Left=�6H   $��
10,330,0,0q�6c   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 55      -   5        $��lblMobileNumber��55   y   $��10. Mobile Number :��6    $��30��6>   $
��Left=�6J   $��
10,370,0,0q�6e   $	��Top=�6�   $	��140��6�   $��15(�6�   �� 56      -   5        $��comboBoxStates��56   _   $��30��6#   $
��Left=�6/   $��170,206,0,0q�6J   $	��Top=�6u   $	��190��6�   ��6�   ��  �� Path$ States�58      59      5:      �� 5>      -   5        $��educationTab��5>   -   $��	Education��6   .��5?      �� -   5        $��scrollEducation��5?   #   .��5@      �� -   5        $��stackEducation��5@   %   5B      5C      5D      �� 5E      -   5        $��workTab��5E   (   $
��Work��6   .��5F      � .+�5G      �� -   5        $��lblJob1��5G   h   $	��Job��6    $��45��6.   $
��Left=�6:   $��	33,28,0,0q�6U   $	��Top=�6w   $	��140��6�   $��15(�6�   �� 5H      -   5        $��lblPositionTitle1��5H   u   $��Position Title: ��6    $��37��6;   $
��Left=�6G   $��	31,80,0,0q�6b   $	��Top=�6�   $	��112��6�   �� 5I      -   5        $��lblCompanyName1��5I   t   $��Company Name: ��6    $��37��69   $
��Left=�6E   $��
32,118,0,0q�6`   $	��Top=�6�   $	��112��6�   �� 5J      -    5        $��lblDiration1��5J   p   $��
Duration: ��6    $��37��65   $
��Left=�6A   $��
382,74,0,0q�6\   $	��Top=�6�   $	��112��6�   �� 5K      -!   5        $��lblLocation1��5K   q   $��
Location: ��6    $��37��65   $
��Left=�6A   $��383,115,0,0q�6\   $	��Top=�6�   $	��112��6�   �� 5L      -"   5        $��txtWorkDescription1��5L   ^   $��67��6"   $
��Left=�6.   $��190,155,0,0q�6I   $	��Top=�6y   $	��477��6�   �� 5M      -#   5        $��lblWorkDescription1��5M   �   $!��Brief description of work: ��6    $��28��6F   $
��Left=�6R   $��
34,156,0,0q�6m   $	��Top=�6�   $	��150��6�   �� 5N      -$   5        $��	btnNewJob��5N   r   $��Add New Job��6!   $��36��67   $
��Left=�6C   $��
40,249,0,0q�6^   $	��Top=�6�   $	��136��6�   �� 5O      -%   5        $��txtPositionTitle1��5O   ]   $��26��6"   $
��Left=�6.   $��
131,82,0,0q�6I   $	��Top=�6v   $	��169��6�   �� 5P      -&   5        $��txtCompanyName1��5P   ^   $��26��6"   $
��Left=�6.   $��131,116,0,0q�6I   $	��Top=�6u   $	��169��6�   �� 5Q      -'   5        $��txtLocation1��5Q   ^   $��26��6"   $
��Left=�6.   $��443,112,0,0q�6I   $	��Top=�6r   $	��169��6�   �� 5R      -(   5        $��txtDuration1��5R   ]   $��26��6"   $
��Left=�6.   $��
443,73,0,0q�6I   $	��Top=�6q   $	��169��6�   5S      5T      �� 5U      -)   5        $��otherDetailsTab��5U   1   $��Other Details��6   .��5V      � 6   5W      5X      �� 5Y      -*   5        $��
lblProfile��5Y   `   $��Profile��6   $��50��6&   $
��Left=�62   $��	27,13,0,0q�6M   $	��Top=�6r   $	��127��6�   $��32(�6�   �� 5Z      -+   5        $��	btnSubmit��5Z   b   $��Submit��6   $��34��6&   $
��Left=�62   $��631,542,0,0q�6M   $	��Top=�6s   $	��123��6�   ���	#FF00E900$��Adobe Caslon Pro)�6�   $��15(�6�   $��Normal$�6�   $
��Bold"�6�   $��Normal&�6�   
���   �$��3q�6(  5[      5\      5]      