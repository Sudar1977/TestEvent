using System;
using System.Collections.Generic;
using System.Text;

//Посмотрим на примере другого делегата:

//В данном случае делегат Operation возвращает значение типа int и имеет два параметра типа int.
//Поэтому этому делегату соответствует любой метод, который возвращает значение типа int
//и принимает два параметра типа int.
//В данном случае это методы Add и Multiply.
//То есть мы можем присвоить переменной делегата любой из этих методов и вызывать.

//Поскольку делегат принимает два параметра типа int, то при его вызове необходимо передать значения
//для этих параметров: del(4,5).
namespace TestDelegate
{
    class Math
    {
        public int Sum(int x, int y) { return x + y; }
    }

    class Example02_Operation
    {
        delegate int Operation(int x, int y);
        public Example02_Operation()
        {
            Math math = new Math();
            // присваивание адреса метода через контруктор
            Operation del = Add; // делегат указывает на метод Add
            int result = del(4, 5); // фактически Add(4, 5)
            Console.WriteLine(result);

            del = Multiply; // теперь делегат указывает на метод Multiply
            result = del(4, 5); // фактически Multiply(4, 5)
            Console.WriteLine(result);
            //Делегаты необязательно могут указывать только на методы, которые определены в том же классе,
            //где определена переменная делегата. Это могут быть также методы из других классов и структур.
            del = math.Sum;
            result = del(4, 5);     // math.Sum(4, 5)
            Console.WriteLine(result);  // 9
            //Выше переменной делегата напрямую присваивался метод. Есть еще один способ -
            //создание объекта делегата с помощью конструктора, в который передается нужный метод:
            Operation del2 = new Operation(Add);
            result = del2(4, 5); 
            Console.WriteLine(result);
        }
        private  int Add(int x, int y)
        {
            return x + y;
        }
        private  int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
