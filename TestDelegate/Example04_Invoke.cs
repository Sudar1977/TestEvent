using System;
using System.Collections.Generic;
using System.Text;

//Вызов делегата


namespace TestDelegate
{
    class Example04_Invoke
    {
        delegate int Operation(int x, int y);
        delegate void Message();
        public Example04_Invoke()
        {
            //В примерах выше делегат вызывался как обычный метод.
            //Если делегат принимал параметры, то при ее вызове для параметров
            //передавались необходимые значения:
            Message mes = null;
            mes += Hello;
            mes();
            Operation op = Add;
            op(3, 4);
            //Другой способ вызова делегата представляет метод Invoke():
            mes.Invoke();
            op.Invoke(3, 4);
            //Если делегат принимает параметры, то в метод Invoke передаются значения для этих параметров.

            //Следует учитывать, что если делегат пуст, то есть в его списке вызова нет ссылок
            //ни на один из методов (то есть делегат равен Null),
            //то при вызове такого делегата мы получим исключение, как, например, в следующем случае:
            op -= Add;          // делегат op пуст
            op?.Invoke(3, 4);   // ошибки нет, делегат просто не вызывается

            //Если делегат возвращает некоторое значение, то возвращается значение последнего метода
            //из списка вызова(если в списке вызова несколько методов). Например:
            op += Multiply;
            op += Subtract;
            op += Add;
            Console.WriteLine(op(7, 2));    // Add(7,2) = 9
        }
        private  void Hello() { Console.WriteLine("Hello Invoke"); }
        private  int Add(int x, int y) { return x + y; }
        private  int Subtract(int x, int y) { return x - y; }
        private  int Multiply(int x, int y) { return x * y; }
    }
}
