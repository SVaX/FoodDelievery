   M S B A M L   `   `   `  ?????  ;VPKS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VPKSVPKS  5      #    VPKS.ClientOrderHistoryWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $localclr-namespace:VPKS     5        ? Title$#  История заказов??5      $	??600??6   $
??1000??6(    ? 
ResizeMode$ NoResize=?65   ??5	      ?? 5
       ?? ImageSource$# /Images/DefaultBackGround.png??6   .??5      ?  ? ColumnDefinitions 5      ?? 5      $??5* ?6   ?? 5      $??2* ?6    ? RowDefinitions 5      ?? 5      $??2* ?6   ?? 5      $??7* ?6   .+?5      ?? $
??Wrap=?6   $+??%NOTDC - История заказов??6"   $??50(?6A   $??Comic Sans MS)?6O   $??Center=?6j   $??Right=?6?   $	??550??6?   $??0,0,0,0q?6?   ? 5      $??0??6	   $??1??6    5      ?? 5      ?? 5      ?? 5      .+?5      ?? -   5         ??Name$ userNameLabel??5   A   $??0??6   $??30(?6   $??Comic Sans MS)?6&   $??45??6X   $	??Top=?6d   $??Center=?6|   ?? 5       ?? CornerRadius$ 15??6   $??
10,0,10,15q?6   
???   ?$??1??6F   $??30??6S   $??Bottom=?6_   $??1q?6z   ???#584D4D._?5      ?? -   5         ??Name$ 
exitButton??5      
???????
?????? 
?????? $??
Выйти??6?   $??20(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5      ?? 5       $ 15??6   $??
10,0,10,15q?6   
???   ?$??2??6F   $??30??6S   $??Bottom=?6_   $??1q?6z   ???#584D4D._?5!      ?? -   5        $ 
menuButton??5!      
???????
?????? 
?????? $??Меню??6?   $??20(?6?   $??Comic Sans MS)?6?   $??Center=?6?   $??Center=?6?   5"      5#      ?? 5%      $??0??6   $??2??6   $??1??6/   
???   ?$??2q?6P   $??
15,10,15,5q?6d   ???#F4EFEF._?5&      ?  5'      ?? 5(      ?? 5)      ?? 5*      .+?5,      ?? $"??Прошлые заказы:??6   $??24(?6&   $??Comic Sans MS)?64   $??0??6O   $??40??6_   $	??Top=?6k   ?? 5-      
???   ?$??2q?6!   $??10, 0, 15, 5q?65   $??Bottom=?6K   $	??360??6f   ._?5.      ?? -   5         ??Name$ orderListBox??5.      $??Comic Sans MS)?6V   $??20(?6q   5/      ?? 50      $,??&Список блюд в заказе:??6   $??24(?6,   $??Comic Sans MS)?6:   $??1??6U   $??40??6e   $	??Top=?6q   ?? 51      
???   ?$??2q?6!   $??10, 0, 15, 5q?65   $??Bottom=?6K   $??1??6f   $	??360??6v   ._?52      ?? -   5        $ foodListBox??52      $??Comic Sans MS)?6$   $??20(?6?   53      54      55      56      57      