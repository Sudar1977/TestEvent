using System;
using System.Collections.Generic;
using System.Text;
//Обобщенные делегаты
namespace TestDelegate
{
    //Делегаты могут быть обобщенными, например:
    delegate T Operation<T, K>(K val);
    // Создадим обобщенный делегат
    //https://professorweb.ru/my/csharp/charp_theory/level11/11_11.php
    delegate T MyDel<T>(T obj1, T obj2);

    class MySum
    {
        public static int SumInt(int a, int b)
        {
            return a + b;
        }

        // Создадим обобщенный делегат
        delegate T MyDel<T>(T obj1, T obj2);
        public static string SumStr(string s1, string s2)
        {
            return s1 + " " + s2;
        }

        public static char SumCh(char a, char b)
        {
            return (char)(a + b);
        }
    }

    class Example06_GenericDelegate
    {
        public Example06_GenericDelegate()
        {
            Operation<decimal, int> op = Square;

            Console.WriteLine(op(5));

            // Реализуем несколько методов обобщенного делегата
            MyDel<int> del1 = MySum.SumInt;
            Console.WriteLine("6 + 7 = " + del1(6, 7));

            MyDel<string> del2 = MySum.SumStr;
            Console.WriteLine("\"Отличная\" + \"погода\" = " + del2("Отличная", "погода"));

            MyDel<char> del3 = MySum.SumCh;
            Console.WriteLine("'a' + 'c' = " + del3('a', 'c'));

        }
        static decimal Square(int n)
        {
            return n * n;
        }
    }
}
