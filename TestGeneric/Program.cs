using System;

namespace TestGeneric
{
    //https://metanit.com/sharp/tutorial/3.12.php
    //Кроме обычных типов фреймворк .NET также поддерживает обобщенные типы (generics),
    //а также создание обобщенных методов. Чтобы разобраться в особенности данного явления,
    //сначала посмотрим на проблему, которая могла возникнуть до появления обобщенных типов.

    class Program
    {
        static void Main(string[] args)
        {
            //Затем этот класс можно было использовать для создания банковских счетов в программе:
            Account account1 = new Account { Sum = 5000 };
            Account account2 = new Account { Sum = 4000 };
            //Все вроде замечательно работает, но такое решение является не очень оптимальным.
            //Дело в том, что в данном случае мы сталкиваемся с такими явлениями как упаковка (boxing)
            //и распаковка (unboxing).
            //Так, при присвоении свойству Id значения типа int, происходит упаковка этого значения в тип Object:
            account1.Id = 2;//// упаковка в значения int в тип Object
            //Упаковка(boxing) предполагает преобразование объекта значимого типа(например, типа int)
            //к типу object. При упаковке общеязыковая среда CLR обертывает значение в объект
            //типа System.Object и сохраняет его в управляемой куче(хипе).
            //Распаковка(unboxing), наоборот, предполагает преобразование объекта типа object
            //к значимому типу.
            //Упаковка и распаковка ведут к снижению производительности,
            //так как системе надо осуществить необходимые преобразования.
            account2.Id = "4356";
            //Чтобы обратно получить данные в переменную типов int, необходимо выполнить распаковку:
            int id1 = (int)account1.Id; // Распаковка в тип int
            string id2 = (string)account2.Id;
            Console.WriteLine(id1);
            Console.WriteLine(id2);
            //Кроме того, существует другая проблема -проблема безопасности типов.
            //Так, мы получим ошибку во время выполнения программы, если напишем следующим образом:
            try
            {
                int id3 = (int)account2.Id;     // Исключение InvalidCastException
                //Мы можем не знать, какой именно объект представляет Id, и при попытке получить число
                //в данном случае мы столкнемся с исключением InvalidCastException.
            }
            catch
            {
                Console.WriteLine(" Исключение InvalidCastException!");
            }
            //Например, вместо параметра T можно использовать объект int, то есть число, представляющее номер счета.
            //Это также может быть объект string, либо или любой другой класс или структура:
            AccountGeneric<int>    _accountGeneric1 = new AccountGeneric<int> { Sum = 5000 };
            AccountGeneric<string> _accountGeneric2 = new AccountGeneric<string> { Sum = 5000 };
            _accountGeneric1.Id = 2;        // упаковка не нужна
            _accountGeneric2.Id = "4356";
            id1 = _accountGeneric1.Id;  // распаковка не нужна
            id2 = _accountGeneric2.Id;
            //id1 = _accountGeneric2.Id;  // ошибка компиляции
            Console.WriteLine(id1);
            Console.WriteLine(id2);
            //Статические поля обобщенных классов
            AccountGeneric<int>.session = 5436;
            AccountGeneric<string>.session = "45245";
            //В итоге для Account<string> и для Account<int> будет создана своя переменная session.
            Console.WriteLine(AccountGeneric<int>.session);      // 5436
            Console.WriteLine(AccountGeneric<string>.session);  // 45245
            //Использование нескольких универсальных параметров
            //Здесь класс Transaction использует два универсальных параметра. Применим данный класс:
            AccountGeneric<int> acc1 = new AccountGeneric<int> { Id = 1857, Sum = 4500 };
            AccountGeneric<int> acc2 = new AccountGeneric<int> { Id = 3453, Sum = 5000 };
            //Здесь объект Transaction типизируется типами Account<int> и string.
            //То есть в качестве универсального параметра U используется класс Account<int>,
            //а для параметра V - тип string.
            //При этом, как можно заметить, класс, которым типизируется Transaction,
            //сам является обобщенным.
            Transaction<AccountGeneric<int>, string> transaction1 = new Transaction<AccountGeneric<int>, string>
            {
                FromAccount = acc1,
                ToAccount = acc2,
                Code = "45478758",
                Sum = 900
            };
            //Обобщенные методы
            int x = 7;
            int y = 25;
            Swap<int>(ref x, ref y); // или так Swap(ref x, ref y);
            Console.WriteLine($"x={x}    y={y}");   // x=25   y=7

            string s1 = "hello";
            string s2 = "bye";
            Swap<string>(ref s1, ref s2); // или так Swap(ref s1, ref s2);
            Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello
        }
        //Кроме обобщенных классов можно также создавать обобщенные методы,
        //которые точно также будут использовать универсальные параметры.
        //Например:
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
