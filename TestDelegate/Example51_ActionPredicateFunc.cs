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
    class Example51_ActionPredicateFunc
    {
        public Example51_ActionPredicateFunc()
        {
            Action<int, int> op = null;
            op = Add;
            Operation(10, 6, op);
            op = Substract;
            Operation(10, 6, op);

            //Predicate
            //Делегат Predicate<T>, как правило, используется для сравнения,
            //сопоставления некоторого объекта T определенному условию.
            //В качестве выходного результата возвращается значение true, если условие соблюдено,
            //и false, если не соблюдено:
            Predicate<int> isPositive = delegate (int x) { return x > 0; };

            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));

            //Func
            //Еще одним распространенным делегатом является Func.Он возвращает результат действия
            //и может принимать параметры. Он также имеет различные формы: от Func<out T>(),
            //где T -тип возвращаемого значения, до Func <in T1, in T2,...in T16, out TResult > (),
            //то есть может принимать до 16 параметров.
            //TResult Func<out TResult>()
            //TResult Func<in T, out TResult>(T arg)
            //TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
            //TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
            //TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)

            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);  // 720

            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2); // 36

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

        int GetInt(int x1, Func<int, int> retF)
        {
            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
        }
        int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
    }


}
