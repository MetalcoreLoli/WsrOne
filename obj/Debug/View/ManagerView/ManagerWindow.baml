   M S B A M L   `   `   `  ����?  ;Wsr1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Wsr1.View.ManagerViewWsr1.View.ManagerView  5   	   /clr-namespace:Wsr1.ViewModelWsr1.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   )    #Wsr1.View.ManagerView.ManagerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Wsr1.View.ManagerView     5   	   +vmclr-namespace:Wsr1.ViewModel     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � WindowStartupLocation$  CenterScreen=�5
   	    � Title$7 1Управление коэффициентами��5   	   $	��550��6+   $	��800��68    � DataContext 5      )   #Wsr1.ViewModel.CoefficientViewModel  5   
   -   5        coeffVM��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      �� 5      $��50 �6   .+�5   
   �� $��2��5      $��/Core/Image/logo.png��5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CoefficientDataGrid��5      $��1��5         AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem 5      �� *SelecteModel+��5       �� *Coefficients+ �� UpdateSourceTrigger$ PropertyChanged=�	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$2
 ,Анализ и проектирование��5$      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5%      �� *CoefficientAnalis+  5&      $1
 +Установка оборудования��5'       5(      �� *CoefficientInstall+  5)      $S
 MТехническое обслуживание и сопровождение��5*       5+      �� *CoefficientService+  5,      $
 Сложность��5-       5.      �� *CoefficientDifficult+  5/      $
 
Время��50       51      �� *CoefficientTime+  52      $
 Junior(Мин. ЗП)��53       54      �� *Junior+  55      $
 Middle(Мин. ЗП)��56       57      �� *Middle+  58      $
 Senior(Мин. ЗП)��59       5:      �� *Senior+.  (System.Windows.Interactivity.Interaction   Triggers 5<      /  )System.Windows.Interactivity.EventTrigger  5=         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5>      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 5?      ��  �� Source %
  System.Windows.Markup.Reference
   
  Name$ coeffVM�� �� Path$ EditCommand� 	  CommandParameter 5@      ��  �� RelativeSource ��  �� AncestorType$ DataGridL� �� Mode$ FindAncestor=�$ SelectedItem�5A      5C      � 5D   
   $��2��5E      $��2��5F      $��3��5G       � ColumnDefinitions 5H      �� 5I      �� 5J      .+�5L      �� -   5        $��
EditButton��5P      $ ��Редактировать��5M         MainStyleOfButton#��[  5N      $��1��5O       5Q        5R      $ Click��6%   . 5S      	   5T   !   �� *EditCommand+ 5U   !   �� *SelecteModel+5V      5X      �� 5Y      -   5        $��
BackButton��5^      $��10,0,0,0q�5Z      $��
Назад��5[      $��0��5\      #��[  5]       5_        5`      $ Click��6%   . 5a      	   5b      �� *CloseCommand+ 5c      ��  �� $ FindAncestor=�$ WindowL�5d      5f      5g      5h      5i      