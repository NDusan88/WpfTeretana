   M S B A M L   `   `   `  ����O  KWpfTeretanaClanarina, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfTeretanaClanarinaWpfTeretanaClanarina  5   	   %    WpfTeretanaClanarina.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfTeretanaClanarina     5   	   -   5          � Title$  
MainWindow��5   	   $��414.248��6   $	��525��6-    � 
ResizeMode$ NoResize=�6P    � WindowStartupLocation$ CenterScreen=�6f   .��5	      � .+�5
   
   �� -   5         ��Name$ 	textBlock��5
      $
��Left=�6'   $��	70,23,0,0q�6B   $
��Wrap=�6U   $��Dodaj clana u listu��6i   $	��Top=�6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��	10,67,0,0q�6C   $
��Wrap=�6V   $	��Ime��6j   $	��Top=�6u   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��
10,120,0,0q�6C   $
��Wrap=�6W   $��Prezime��6k   $	��Top=�6z   �� 5   
   -   5        $ 
textBlock3��5      $
��Left=�6(   $��
10,176,0,0q�6C   $
��Wrap=�6W   $��VremeOd��6k   $	��Top=�6z   �� 5   
   -   5        $ 
textBlock4��5      $
��Left=�6(   $��
10,230,0,0q�6C   $
��Wrap=�6W   $��VremeDo��6k   $	��Top=�6z   �� 5   
   -   5         ��Name$ 
textBoxIme��5      $
��Left=�6&   $��23��6A   $��	70,60,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $ textBoxPrezime��5      $
��Left=�6*   $��23��6E   $��
70,119,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5        $��dtpOd��5      $
��Left=�6"   $��
70,172,0,0q�6=   $	��Top=�6Q     5   
   -
   5        $��dtpDo��5      $
��Left=�6"   $��
70,230,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ buttonUpisi��5      $��Upisi��6&   $
��Left=�66   $��
70,271,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5         ��Name$ listView��5      $
��Left=�6%   $	��194��6@   $��
319,60,0,0q�6M   $	��Top=�6a   $	��172��6y    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5        $ 
textBlock5��5      $
��Left=�6(   $��
352,23,0,0q�6C   $
��Wrap=�6W   $��Zahtevi za uclanjenje��6k   $	��Top=�6�   �� 5   
   -   5        $ buttonObradi��5      $��Obradi zahteve��6'   $
��Left=�6@   $��363,271,0,0q�6[   $	��Top=�6p   $��90��6�   6�   �� 5   
   -   5        $ buttonAktivneClanarine��5      $��Aktivne clanarine��61   $
��Left=�6M   $��350,303,0,0q�6h   $	��Top=�6}   $	��112��6�   6�   �� 5   
   -   5        $ buttonIstekleClanarine��5      $��Istekle clanarine��61   $
��Left=�6M   $��350,336,0,0q�6h   $	��Top=�6}   $	��112��6�   6�   5       5!      