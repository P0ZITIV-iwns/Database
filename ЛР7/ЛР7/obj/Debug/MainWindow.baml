   M S B A M L   `   `   `  ????	  ЛР7    ЛР7.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? WindowStartupLocation$  CenterScreen=?5   	    ? Title$ Телефончики??5   	   $	??550??6   $
??1000??6-   .??5
      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   6)   ?? 5      $
??0.2* ?6   6,    ? ColumnDefinitions 5   
   ?? 5      $
??0.2* ?6   6.   ?? 5      $??* ?6   6+   ?? 5      $
??0.2* ?6   6.   .+?5   
   &   System.Windows.Controls.DataGrid  -   5        $??mainDataGridView??5   %   $??1??5         AutoGenerateColumns .  $??0 10 0 0q?5      $??16(?5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      ?? 5      .R?5      ??  ?? Orientation$ 
Horizontal=?6)   .+?5   "   ?? -   5        $??25??5   )   $??25??65   
?????? $??0q?5   )   .??5    &   ?? $??20??6,   $??../Images/edit-button.png??5!   ,   5"   #   ?? 5#   "   -   5        $??25??5#   )   $??25??65   
?????? $??0q?5%   )   .??5'   &   ?? $??20??6,   $??../Images/remove.png??5(   ,   5)   #   5*      5+      5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Название??6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5/   %   ?? 
 ?? Path$
 title?  50      $ Компания??6%   	 51   %   ?? $
 CompanyEntity.title?  52      $ Цена??6%   	 63   ?? $
 price?54      ?? 57   
   $ 
Horizontal=?6   $??1??6.   $??1??6;   .+?58      ?? -   5        $??addButtonView??58      $??70??6B   $??70??6P   
?????? $??0q?6w   .??59      ?? $??/Images/plus.png??6   64   5:      5;      5<      5=      