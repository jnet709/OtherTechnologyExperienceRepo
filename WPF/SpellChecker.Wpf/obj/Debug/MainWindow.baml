   M S B A M L   `   `   `  ����K  GSpellChecker.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SpellChecker.WpfSpellChecker.Wpf  5   	   !    SpellChecker.Wpf.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -uiclr-namespace:SpellChecker.Wpf     5   	   -   5          � Title$  Spell Checker Utility��5	   	   $	��690��5
   	   $
��1130��6    � 	Resources 5         validationTemplate � ToolTip �� ElementName �� Path � Color � Offset  textBoxInError �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property �� Value �� Self �� RelativeSource  RightAlignedCell*  $System.Windows.Controls.DataGridCell �� 
TargetType  LeftAlignedCell  CenterAlignedCell$   SpellChecker.Wpf.PathConverter  iconConverter��%m  &	        &	 �    &	 �    &	 �    &	 F    'Q� �    &	     �� 5   
   .R�5      ]� .+�5      A� $��Right=�5      $	��2,0q�5      $��10��5      $��10��6    5      �� $ errorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent���5      �� 5      .��5      � $ 	#11FF1111��6+   $ 0Q�6=   � 5      $ 	#FFFF0000��6+   $ 1Q�6=   5      5      �� 5      
���  ��$��2q�6+   $��-1q�6?   ._�5      �� 5      5      5      �� 5!   
   " ��6'    5"      P� 5#      	 �@=�HasError
 . . �5$      ��  �@�ToolTip 5%      �� # Z $) #(Validation.Errors)[0].ErrorContent�5'      5)      �� 5,   
   "  6)   .�5-      ��  � �� 5.      �� 5/      "  6&   .R�50      � #��z��6   .+�51      �� $��Right=�6/   $��Center=�6K   52      53      55       56      P� 57      	 �@ 
IsSelected
 . . �58      ��  � �� �#35681563   �� 59       � �� �#e2fce263   5:      5<      �� 5>   
   "  6(   .�5?      ��  � �� 5@      �� 5A      "  6&   .R�5B      � #��z��6   .+�5C      �� $
��Left=�6/   $��Center=�6J   5D      5E      5G       5H      P� 5I      	 �@ 
IsSelected
 . . �5J      ��  � �� �#35681563   �� 5K       � �� �#e2fce263   5L      5N      �� 5P   
   "  6*   .�5Q      ��  � �� 5R      �� 5S      "  6&   .R�5T      � #��z��6   .+�5U      �� $��Center=�6/   $��Center=�6L   5V      5W      5Y       5Z      P� 5[      	 �@ 
IsSelected
 . . �5\      ��  � �� �#35681563   �� 5]       � �� �#e2fce263   5^      5`      �� 5b   
   " Q�6   .�5c      ��  �@Q�
IsExpanded 6+   �� $ 
IsExpanded�5d      5e        5f   
   6   5g      .��5i      ]� -   5         ]�Name$ dockPanelMain��5i      $��Stretch=�6'   $��Stretch=�6E   $
��Auto��6a   $
��Auto��6n   ��. 
�������.+�5k   
   �� $��25��6   $��Bottom=�6    $��Bottom=�68   ��5l      �� 5m      .R�5n      �  � RowDefinitions 5o      �� 5p      $��* �6,    � ColumnDefinitions 5r      �� 5s      $
��200* �6/   �� 5t      $
��200* �6/   �� 5u      $
��Auto �6/   �� 5v      $
��Auto �6/   �� 5w      $
��Auto �6/   �� 5x      $
��Auto �6/   5z      5{      .@�5}      �� $��0��6   .��5~      �� -   5         ��Name$ textBlockStatusText��5~   8   $��Bottom=�6    �� TextAlignment$
 Left=�6U   Ready6q   5      �� 5�      $��1��6   .��5�      � -   5         �Name$ progressBarStatus��5�   Z    � Value$ 0Q�6    � Minimum$ 0Q�6(    � Maximum$	 100Q�64   $	��200��6B   $��20��6N    � IsIndeterminate . 
����  ���6�   Z� ��6�   Z� 5�      �� 5�      $��2��6   .��5�      �� -   5        $  textBlockStatusLastUpdated��5�   8   $��Bottom=�6   $
 Left=�6\   6s   5�      �� 5�      $��3��6   .��5�      �� -   5        $ textBlockVersion��5�   8   $��Bottom=�6   $
 Left=�6R   $��5,0,0,0q�6g   6z   5�      5�      � 5�   
   -   5        $��gridMain��5�      $	��Top=�6   $
��Auto��64   $
��Auto��6A    5�      �� 5�      $��* �6#    5�      �� 5�      $��* �6    .+�5�      � -   5        $��gridForFileDataGrids��5�   4   $��0��6   $��2��6    $��Stretch=�6P    5�      �� 5�      $	��270 �6'   �� 5�       5�      �� 5�      $��* �6$   �� 5�      $	��180 �6$   .+�5�      &   System.Windows.Controls.DataGrid  -	   5        $��dataGridDirectoryFiles��5�      $��0��6:   $��0��6J      AutoGenerateColumns .     AlternatingRowBackground �#CCFFCC �� AlternationCount$ 2��5�   !      FrozenColumnCount$ 2��5�   !   $��13(�5�   !      
IsReadOnly .    GridLinesVisibility$ Vertical=�5�   !       SelectionMode$  Single=�5�   !   !   SelectionUnit$! FullRow=�5�   !   $��5,5,10,0q�69   "   Columns" 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn#   	CellStyle## [ 6K   $   Header$$ 	File Name��6y   %   Width5  /System.Windows.Controls.DataGridLengthConverter$% 1* 6�   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6-   �� $
 Name�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5�      '   MinWidth$	' 120Q�61   ## [ 6@   $$ Command��6m   $% 2* 6~   (   CellTemplate( 5�      �� 5�   "   .R�5�   &   �� $��buttonReload��6f   -
   5        $��35��5�   -   $
��Left=�69   $��14,0,0,6q�6T   $��Bottom=�6�   $	��110��6�   
) � Tag) 6z   �� $
 Name�.��5�   *   �� * �� Orientation$* 
Horizontal=�65   .+�5�   .   �� $��25��64   $��35��6?   $��Resources\reload.png��6K   z�5�   2   �� 5�   6   + �� ScaleX$	+ 1.0Q�6E   , �� ScaleY$	, 1.0Q�6R   5�   /   �� 5�   .   $��Reload��68   $��Center=�6F   $��Center=�6c   - �� Padding$- 5,0,5,0q�6~   6�   5�   +   5�   '   5�   #   5�      5�        5�      -   5        $��dataGridResults��5�      $��1��62   $��0��6B    .   �#CCFFCC$ 2��5�      $ 2��5�      $��13(�5�       . $ Vertical=�5�      $  Single=�5�      $! CellOrRowHeader=�5�      $
��Auto=�5�      $
��Auto=�5�      $��0,5,6,0q�5�      " 5�        5�      ## [ 6K   $
$ Name��6x   $% 1* 6�   & 6-   �� $
 Name�6�     5�      ## [ 6K   $
$ Size��6x   $% 1* 6�   & 6-   �� $
 Size�6�     5�      ## [ 6h   $$ Updated��6�   $% 1* 6�   & 6-   �� $ UpdatedDate�. �� StringFormat$. {0:g}��6�     5�      ## [ 6T   $$ Root Directory��6�   $% 4* 6�   & 6-   �� $ RootDirectory�6�   5�      � 5�      -   5        $��gridGeneralCommands��5�   4   $��1��6   $��0��6$   $��2��6O   $��Stretch=�6^   $��Stretch=�6|   .+�5�      �� $��0��6   $��0��6/   $��General Commands��6<   $��Stretch=�6V   $��	10,10,5,0q�6t   $��Stretch=�6�   .��5�      � -   5        $��gridGeneralCommandsNested��5�      $��Stretch=�6@    5�      �� 5�   "   $��1* �63   �� 5�   "   $��4* �63    5�      �� 5�   "   $��* �60   .+�5�      � $��0��6#   $��0��63    5�   "   �� 5�   &   $��45 �64   .+�5�   "   �� -   5        $��buttonReloadAll��5�   )   $��0��6@   $��0��6P   $��35��6]   $��0,0,7,0q�6i   $��Center=�6z   $
��left=�6�   $	��110��6�   .��5�   &   �� $* 
Horizontal=�61   $C =Please click here select files to upload to selected group(s)��6J   .+�5�   *   �� $��25��60   $��25��6;   $��Resources\Reload.png��6G   z�5�   .   �� 5�   2   $	+ 1.0Q�6A   $	, 1.0Q�6N   5�   +   �� 5�   *   $��
Reload All��64   $��Center=�6F   $��Center=�6c   $- 5,0,5,0q�6~   5�   '   5�   #   5�      � 5�      -   5        $��
gridSearch��5�   #   $��Stretch=�65   $��1��6Q   $��0��6a    5�   "   �� 5�   &   $��1* �67   �� 5�   &   $��1* �67   �� 5�   &   $��1* �67   �� 5�   &   $��* �67    5�   "   �� 5�   &   $��45 �64   �� 5�   &   $��45 �64   �� 5�   &   $��45 �64   .+�5�   "   �� $��0��6,   $��0��69   $��Searched word��6I   6a   �� 5�   "   -   5        $��textBoxSearchedWord��5�   G   $��0��6*   $��1��67   6d   �� 5�   "   -   5        $��buttonBrowse��5�   )   $��2��6=   $��0��6M   $��35��6Z   $��0,0,7,0q�6f   $��Center=�6w   $
��left=�6�   $	��110��6�   .��5�   &   �� $* 
Horizontal=�61   $C =Please click here select files to upload to selected group(s)��6J   .+�5�   *   �� $��25��60   $��25��6;   $��Resources\Reload.png��6G   z�5�   .   �� 5   2   $	+ 1.0Q�6A   $	, 1.0Q�6N   5  +   �� 5  *   $��Browse��64   $��Center=�6B   $��Center=�6_   $- 5,0,5,0q�6z   5  '   5  #   �� 5  "   -   5        $��textBlockSearchResult��5  I   $��0��6,   $��3��69   6i   �� 5  "   $��1��6,   $��0��69   $��Suggested words��6I   6c   �� 5	  "   -   5        $��comboBoxSuggestedWords��5	  H   $��1��6+   $��1��68   6h   �� 5  "   $��2��6,   $��0��69   $��Levenshtein precisions��6I   6j   �� 5  "   -   5        $#��comboBoxLevenshteinPrecisions��5  H   $��2��6+   $��1��68   6�   5     5     5     5     5     5     5     5     