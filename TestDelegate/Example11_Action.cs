using System;
using System.Collections.Generic;
using System.Text;

//Делегат Action является обобщенным, принимает параметры и возвращает значение void:
//Данный делегат имеет ряд перегруженных версий. Каждая версия принимает разное число параметров:
//от Action<in T1> до Action<in T1, in T2,....in T16>.
//Таким образом можно передать до 16 значений в метод.

//Как правило, этот делегат передается в качестве параметра метода и предусматривает
//вызов определенных действий в ответ на произошедшие действия. Например:

namespace TestDelegate
{
    class Example11_Action
    {
        public Example11_Action()
        {
            Action<int, int> op = null;
            op = Add;
            Operation(10, 6, op);
            op = Substract;
            Operation(10, 6, op);
        }

        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }

        static void Add(int x1, int x2)
        {
            Console.WriteLine("Сумма чисел: " + (x1 + x2));
        }

        static void Substract(int x1, int x2)
        {
            Console.WriteLine("Разность чисел: " + (x1 - x2));
        }

    }


}
