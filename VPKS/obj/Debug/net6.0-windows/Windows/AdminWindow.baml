   M S B A M L   `   `   `  ?????  ;VPKS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VPKSVPKS  5          VPKS.AdminWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $localclr-namespace:VPKS     5        ? Title$/  )Панель администратора??5      $	??600??6!   $
??1000??6.    ? 
ResizeMode$ NoResize=?6;   ??5	      ?? 5
       ?? ImageSource$# /Images/DefaultBackGround.png??6   .??5      ?  ? RowDefinitions 5      ?? 5      $??2* ?6   ?? 5      $??7* ?6    ? ColumnDefinitions 5      ?? 5      $??5* ?6   ?? 5      $??2* ?6   .+?5      ?? $??0??6
   $??0??6   $/??)Панель администратора??6'   $??45(?6G   $??Comic Sans MS)?6U   $??Center=?6p   $??Right=?6?   $??0,0,10,0q?6?   ?? 5      -   5         ??Name$ adminNameLabel??5   P   $??0??6
   $??1??6   $??30(?6'   $??Comic Sans MS)?65   $??45??6h   $	??Top=?6t   $??Center=?6?   ?? 5       ?? CornerRadius$ 15??6   $??
10,0,10,15q?6   
???   ?$??0??6E   $??1??6R   $??45??6b   $??Bottom=?6n   $??1q?6?   ???#584D4D._?5      ?? -   5         ??Name$ 
exitButton??5      
???????
?????? 
?????? $??
Выйти??6   $??30(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5      ? 5      $??2??6	   $??1??6    5      ?? 5      ?? 5       .+?5"      ?? $??0??6   $??1??6   
???   ?$??2q?6=   $??10,10,10,10q?6Q   ???#F4EFEF._?5#      ?  5$      ?? 5%      $??2* ?6   ?? 5&      $??3* ?6   .+?5(      ?? $??Список блюд:??6   $??24(?6$   $??Comic Sans MS)?62   $??0??6M   $??40??6]   $	??Top=?6i   ?? 5)      
???   ?$??2q?6"   $??10, 0, 15, 5q?66   $??Bottom=?6L   $	??360??6g   ._?5*      ?? -   5         ??Name$ foodListBox??5*      $??Comic Sans MS)?6U   $??20(?6p   5+      ?? 5-      $<??6Информация о выбранном блюде:??6   $??1??66   $??20(?6F   $
??Wrap=?6T   $??Center=?6h   $??0,0,0,10q?6?   $	??Top=?6?   ?? 5.      ???#E1E1E1$??1??6#   $	??360??63   $??Bottom=?6@   $??10, 10, 10, 5q?6[   
???   ?$??1q?6?   ._?5/      ?  50   	   ?? 51   
   ?? 52   
   ?? 53   
   ?? 54   
   ?? 55   
   ?? 56   
   ?? 57   
   ?? 58   
   ?? 59   
   ?? 5:   
   ?? 5;   
   .+?5=   	   ?? $??Название:??6   $??20(?6#   $??Comic Sans MS)?61   $??0??6L   ?? 5>   	   -   5        	 ??Name$	 nameTextBox??5>      $??20(?6&   $??Comic Sans MS)?64   $??1??6O   $	??225??6\   $
??Left=?6h   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5@   	   $??Вес:??6   $??20(?6   $??Comic Sans MS)?6,   $??2??6G   ?? 5A   	   -   5        $	 weightTextBox??5A      $??20(?6(   $??Comic Sans MS)?66   $??3??6Q   $	??225??6^   $
??Left=?6j   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5C   	   $??	Цена:??6   $??20(?6   $??Comic Sans MS)?6-   $??4??6H   ?? 5D   	   -   5        $	 costTextBox??5D      $??20(?6&   $??Comic Sans MS)?64   $??5??6O   $	??225??6\   $
??Left=?6h   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5F   	   $??Калории:??6   $??20(?6"   $??Comic Sans MS)?60   $??6??6K   ?? 5G   	   -   5        $	 caloriesTextBox??5G      $??20(?6*   $??Comic Sans MS)?68   $??7??6S   $	??225??6`   $
??Left=?6l   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5I   	   $ 15??6   $	??225??6"   $??10,5,0,5q?6.   
???   ?$??8??6T   $??35??6a   $??Center=?6m   $
??Left=?6?   $??1q?6?   ???#584D4D._?5J   
   ?? -   5        $ 
saveButton??5J      
???????
?????? 
?????? $??Сохранить??6?   $??20(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5K   
   ?? 5M   	   $ 15??6   $	??225??6"   $??10,5,0,5q?6.   
???   ?$??9??6T   $??35??6a   $??Center=?6m   $
??Left=?6?   $??1q?6?   ???#584D4D._?5N   
   ?? -	   5        $ 	addButton??5N      
???????
?????? 
?????? $??Добавить??6?   $??20(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5O   
   ?? 5Q   	   $ 15??6   $	??225??6"   $??10,5,0,5q?6.   
???   ?$??10??6T   $??35??6b   $??Center=?6n   $
??Left=?6?   $??1q?6?   ???#584D4D._?5R   
   ?? -
   5        $ deleteButton??5R      
???????
?????? 
?????? $??Удалить??6?   $??20(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5S   
   5T   	   5U      5V      5W      ?? 5X      $??1??6   $??1??6   
???   ?$??2q?6=   $??10,10,10,10q?6Q   ???#F4EFEF._?5Y      ?  5Z      ?? 5[      $??2* ?6   ?? 5\      $??3* ?6   .+?5^      ?? $??Пользователи:??6   $??24(?6%   $??Comic Sans MS)?63   $??0??6N   $??40??6^   $	??Top=?6j   ?? 5_      
???   ?$??2q?6"   $??10, 0, 15, 5q?66   $??Bottom=?6L   $	??360??6g   ._?5`      ?? -   5        $ userListBox??5`      $??Comic Sans MS)?6U   $??20(?6p   5a      ?? 5c      $8??2Информация о пользователе: ??6   $??1??64   $??20(?6D   $
??Wrap=?6R   $??Center=?6f   $??65??6?   $	??Top=?6?   ?? 5d      ???#E1E1E1$??1??6#   $	??360??63   $??Bottom=?6@   $??10, 10, 10, 5q?6[   
???   ?$??1q?6?   ._?5e      ?  5f   	   ?? 5g   
   ?? 5h   
   ?? 5i   
   ?? 5j   
   ?? 5k   
   ?? 5l   
   ?? 5m   
   ?? 5n   
   ?? 5o   
   .+?5q   	   ?? $??Логин:??6   $??25(?6    $??Comic Sans MS)?6.   $??0??6I   ?? 5r   	   -   5        $	 loginTextBox??5r      $??25(?6'   $??Comic Sans MS)?65   $??1??6P   $	??225??6]   $
??Left=?6i   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5t   	   $??Почта:??6   $??25(?6    $??Comic Sans MS)?6.   $??2??6I   ?? 5u   	   -   5        $	 emailTextBox??5u      $??25(?6'   $??Comic Sans MS)?65   $??3??6P   $	??225??6]   $
??Left=?6i   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5w   	   $??	Роль:??6   $??25(?6   $??Comic Sans MS)?6-   $??4??6H   ?? 5x   	   -   5        
 ??Name$
 roleComboBox??5x      $??25(?6(   $??Comic Sans MS)?66   $??5??6Q   $	??225??6^   $
??Left=?6j   $??10,0,0,0q?6?   
???   ?$??1q?6?   ?? 5z   	   $ 15??6   $	??225??6"   $??10,5,0,5q?6.   
???   ?$??6??6T   $??35??6a   $??Center=?6m   $
??Left=?6?   $??1q?6?   ???#584D4D._?5{   
   ?? -   5        $ saveUserButton??5{      
???????
?????? 
?????? $??Сохранить??6?   $??20(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5|   
   5}   	   5~      5      5?      5?      5?      5?      