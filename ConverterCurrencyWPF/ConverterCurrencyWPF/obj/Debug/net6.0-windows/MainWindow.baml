   M S B A M L   `   `   `  ����O  KConverterCurrencyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ConverterCurrencyWPFConverterCurrencyWPF  5   	   %    ConverterCurrencyWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ConverterCurrencyWPF     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 	Converter��5	   	   $	��500��6   $	��600��6(    � WindowStyle$ ThreeDBorderWindow=�64    � WindowStartupLocation$ CenterScreen=�6U    � 	Resources 5
       �� 
TargetType   CurrencyButton �� Property �� Value��%�   &	        �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Left=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$ 50��6&   �� 5       � ��$ 25��6'   5      5      .��5      � -   5         �Name$ MainRoot��5      ���	#FFA3CAED.+�5   
   &   System.Windows.Controls.Calendar  -   5        	  Name$	 calendar��5      $��200,10,200,280q�6%   $	��170��6=   �� 5   
   -   5        
 ��Name$
 inputTextBox��5      $��1��6(   $��40,240,340,157q�61    �� TextWrapping$
 Wrap=�6I   $��20(�6]    �� MaxLines$ 1��6k    �� TextAlignment$ Center=�6x    �� 	MaxLength$ 10��6�   $��Times New Roman)�6�   �� 5   
   -   5         ��Name$ outputLabel��5      
�������$�� ��69   $��340,240,40,157q�6D   $	��220��6\   $��20(�6h   $��Times New Roman)�6v   $��Center=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ CharCodeComboBox1��5      $
��Left=�6.    �� MaxDropDownHeight$ 60��6I    �� IsTextSearchEnabled$
 True��6`    �� 
IsEditable$
 True��6{   $��190,215,0,0q�6�   $	��Top=�6�   $��65��6�   $��50��6�   $��25��6�   �� 5   
   -   5        $ CharCodeComboBox2��5      $
��Left=�6.   $ 60��6I   $
 True��6`   $
 True��6{   $��490,215,0,0q�6�   $	��Top=�6�   $��70��6�   $��50��6�   $��25��6�   �� 5   
   -   5         ��Name$ button��5      
�������$��70��64   $��30��6?   $��Convert��6L   $��	0,350,0,0q�6^   $��Center=�6q   $	��Top=�6�   6�   �� 5   
   -   5        $ ChartButton��5      
�������$��70��69   $��30��6D   $��Charts��6Q   $��Center=�6b   $��
0, 390,0,0q�6   $	��Top=�6�   6�   �� 5    
   -	   5        $ 
RubButton1��5       #��[  6%   $	��RUB��6M   $��
40,215,0,0q�6[   6o   �� 5!   
   -
   5        $ 
UsdButton1��5!      #��[  6%   $	��USD��6M   $��
90,215,0,0q�6[   6o   �� 5"   
   -   5        $ 
EurButton1��5"      #��[  6%   $	��EUR��6M   $��140,215,0,0q�6[   6p   �� 5#   
   -   5        $ 
RubButton2��5#      #��[  6%   $	��RUB��6M   $��340,215,0,0q�6[   6p   �� 5$   
   -   5        $ 
UsdButton2��5$      #��[  6%   $	��USD��6M   $��390,215,0,0q�6[   6p   �� 5%   
   -   5        $ 
EurButton2��5%      #��[  6%   $	��EUR��6M   $��440,215,0,0q�6[   6p   5'      5(      