   M S B A M L   `   `   `  ����  ATechBoardGameClub%    ATechBoardGameClub.AddBoardGame   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $	��600��5        N� Title$  AddBoardGame��5	      .��5      � -   5        $��gridRoot��5       � ColumnDefinitions 5   
   �� 5      $	��.7* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��40 �6   .+�5   
   �� -   5        $��	lblPreset��5      $��Preset:��5      $
��Left=�5      $	��Top=�6/   $��15,0,0,0q�5      $��18(�5      $
��Bold"�6   �� 5   
   -   5        $��comboPreset��5      $��Center=�5      $��	80,0,15,0q�5      �� 5    
   -   5        $��
lblBarcode��5       $��Barcode:��5!      $��1��5"      $
��Left=�5#      $	��Top=�6/   $��18(�5$      $
��Bold"�6   �� 5%   
   -   5        $��txtBoxBarcode��5%      $��1��5&      $��Center=�5'      $��	85,0,15,0q�5(      5)      � 5+   
   -   5        $��	gridImage��5+      $��0��5,      $��1��6   .+�5-      �� -   5        $��lblImage��5-      $��Image��5.      $��Center=�5/      $	��Top=�61   $��18(�50      $
��Bold"�6   �� 51      -	   5        $��borderImage��51      ���#1585B5$��3q�52   +   $��15,30,15,35q�53      ._�54      �� -
   5        $��
imageImage��54      $��Uniform=�55      $	��190��56      57      �� 58      -   5        $��txtBoxImagePath��58      $��Bottom=�59      $��	15,0,50,3q�5:      |�.  5;      �� 5<      -   5        $��btnImagePath��5<         MetroCircleButtonStyle#���   5=      $��Right=�5>      $��Bottom=�65   $��33��5?      $��33��6$   $��0,0,15,0q�5@      ��5B      �� 5C      $��15��6    $��15��6,   ��5D      !� 5E       j� Stretch$
 Fill=�6*     appbar_upload !� Visual# [ 69   5G      5I      5J      � 5L   
   -   5        $��gridUpperRightContent��5L      $��1��5M      $��1��6   $��2��5N      $��0,0,15,0q�5O       5P      �� 5Q      $��1* �6    �� 5R      $��1* �6    �� 5S      $��1* �6    �� 5T      $��1* �6    �� 5U      $��1* �6    �� 5V      $��1* �6    �� 5W      $��1* �6    �� 5X      $��1* �6    �� 5Y      $��1* �6    �� 5Z      $��1* �6    �� 5[      $��1* �6    �� 5\      $��1* �6    �� 5]      $��1* �6    .+�5`      � -   5        $��gridName��5`      $��0��5a      $��0��6#   .+�5b      �� -   5        $��lblName��5b      $��Name:��5c      $��Center=�5d      $
��Left=�63   $��18(�5e      $
��Bold"�6"   �� 5f      -   5        $��
txtBoxName��5f      $��Center=�5g      $��65,0,0,0q�5h      5i      5j      � 5l      -   5        $��	gridGenre��5l      $��0��5m      $��1��6#   .+�5n      �� -   5        $��lblGenre��5n      $��Genre:��5o      $��Center=�5p      $
��Left=�63   $��18(�5q      $
��Bold"�6"   �� 5r      -   5        $��txtBoxGenre��5r      $��Center=�5s      $��65,0,0,0q�5t      5u      5v      � 5x      -   5        $��gridSubClass��5x      $��0��5y      $��2��6#   .+�5z      �� -   5        $��lblSubClass��5z      $��Sub-Class.:��5{      $��Center=�5|      $
��Left=�63   $��18(�5}      $
��Bold"�6"   �� 5~      -   5        $��txtBoxSubClass��5~      $��Center=�5      $��	100,0,0,0q�5�      6)   5�      � 5�      -   5        $��gridDifficulty��5�      $��0��5�      $��3��6#   .+�5�      �� -   5        $��lblDifficulty��5�      $��Difficulty:��5�      $��Center=�5�      $
��Left=�63   $��18(�5�      $
��Bold"�6"   �� 5�      -   5        $��txtBoxDifficulty��5�      $��Center=�5�      $��95,0,0,0q�5�      6(   5�      � 5�      -   5        $��gridSetupTime��5�      $��0��5�      $��4��6#   .+�5�      �� -   5        $��lblSetupTime��5�      $��Setup Time (Mins):��5�      $��Center=�5�      $
��Left=�63   $��18(�5�      $
��Bold"�6"   �� 5�      -   5        $��txtBoxSetupTime��5�      $��Center=�5�      $��	170,0,0,0q�5�      6)   5�      � 5�      -   5        $��gridGameTime��5�      $��0��5�      $��5��6#   .+�5�      �� -   5        $��lblGameTime��5�      $��Game Length (Mins):��5�      $��Center=�5�      $
��Left=�63   $��18(�5�      $
��Bold"�6"   �� 5�      -   5        $��txtBoxGameTime��5�      $��Center=�5�      $��	185,0,0,0q�5�      6)   5�      � 5�      -    5        $��gridPlayers��5�      $��0��5�      $��6��6#    5�      �� 5�      $��1* �6'   �� 5�      $��1* �6'   .+�5�      �� -!   5        $��lblMinPlayers��5�      $��Min. Players:��5�      $��0��5�      $��0��6(   $��Center=�5�      $
��Left=�63   $��18(�5�      $
��Bold"�6"   �� 5�      -"   5        $��txtBoxMinPlayers��5�      $��Center=�5�      $��0��5�      $��0��6(   $��	115,0,0,0q�5�      6)   �� 5�      -#   5        $��lblMaxPlayers��5�      $��Max Players:��5�      $��1��5�      $��0��6(   $��Center=�5�      $
��Left=�63   $��18(�5�      $
��Bold"�6"   �� 5�      -$   5        $��txtBoxMaxPlayers��5�      $��Center=�5�      $��1��5�      $��0��6(   $��	115,0,0,0q�5�      6)   5�      � 5�      -%   5        $��
gridRating��5�      $��0��5�      $��7��6#   .+�5�      �� -&   5        $��	lblRating��5�      $��Game Rating:��5�      $��Center=�5�      $
��Left=�63   $��18(�5�      $
��Bold"�6"   �� 5�      -'   5        $��txtBoxRating��5�      $��Center=�5�      $��	125,0,0,0q�5�      6)   5�      � 5�      -(   5        $��gridSummary��5�      $��0��5�      $��8��6#   $��5��60   .+�5�      �� -)   5        $��
lblSummary��5�      $��Summary:��5�      $	��Top=�5�      $
��Left=�60   $��18(�5�      $
��Bold"�6"   �� 5�      -*   5        $��txtBlockSummary��5�      $��0,35,0,0q�5�      $	��160��5�       �� TextWrapping$
 Wrap=�5�      6.   5�      5�      � 5�   
   -+   5        $��	gridVideo��5�      $��0��5�      $��2��6   .+�5�      �� -,   5        $��lblVideo��5�      $��YouTube Video��5�      $��Center=�5�      $	��Top=�61   $��18(�5�      $
��Bold"�6   �� 5�      --   5        $��borderVideo��5�      ���#1585B5$��3q�5�   +   $��15,30,15,35q�5�      ._�5�      (  "System.Windows.Controls.WebBrowser  -.   5        $��
webBrowser��5�      ��5�      ��  �� ElementName$ 
imageImage�� �� Path$ ActualHeight�5�      �� 5�      -/   5        $��lblVideoLink��5�      $��Link:��5�      $��15,0,0,0q�5�      $
��Left=�5�      $��Bottom=�6/   $��16(�5�      �� 5�      -0   5        $��txtBoxVideoLink��5�      $��Bottom=�5�      $��	55,0,15,3q�5�      5�      5�      �� 5�   
   -1   5        $��
lblWebsite��5�      $��Website:��5�      $��0��5�      $��3��6    $
��Left=�5�      $��Center=�6+   $��15,0,0,0q�5�      $��18(�5�      $
��Bold"�6   �� 5�   
   -2   5        $��txtBoxWebsite��5�      $��0��5�      $��3��6"   $��2��6/   $��Center=�5�      $��100,0,180,0q�5�      6'   �� 5�   
   -3   5        $��	btnCreate��5�      $��Create!��5�      $��1��5�      $��3��6!   $��Center=�5�      $��Right=�6,   $	��155��5�      $��
300,0,15,0q�5�      6%   5�      5      