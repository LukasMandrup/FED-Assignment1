   M S B A M L   `   `   `  ����C  ?DebtBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DebtBook.ViewsDebtBook.Views  5   	   $    DebtBook.Views.AddDebtorDialog   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   .localclr-namespace:DebtBook.Views     5   	   Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � Title$ 
Add Debtor��5   	   $	��160��6   $	��200��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��
Add Debtor��6   �� 5   
   -   5        $��nameTextBox��5      $��1��5      $��1��5      $��5q�5      ��5      ��  �� Path$ CurrentDebtor.Name�5      �� 5!   
   $��1��6   $
��Name��6      AddDebtorLabels#��[  5"      �� 5$   
   -   5        $��initialValueTextBox��5)      $��1��5%      $��2��5&      $��5q�5'      ��5(      �� $ CurrentDebtor.Balance�5)      �� 5,   
   $��2��6   $��Initial Value��6   #��[  5.      �� 50   
   -   5        $��3��50      $
��Save��51      $��5q�52      ��54      �� *SaveCommand+�� 56   
   $��3��6   $��1��57      $��Cancel��58      $��5q�59       �� IsCancel$
 true��5:      5;      5<      