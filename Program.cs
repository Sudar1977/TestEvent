using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvent
{
    //https://habr.com/ru/post/213809/
    //События C# по-человечески
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("События C# по-человечески");
            ClassCounter Counter = new ClassCounter();
            Handler_I Handler1 = new Handler_I();
            Handler_II Handler2 = new Handler_II();
            //Подписались на событие
            Counter.onCount += Handler1.Message_I;
            Counter.onCount += Handler2.Message_II;
            //Запустили счетчик
            Counter.Count();
            Console.WriteLine("Нажмите клавишу");
            Console.ReadKey();

        }
    }
}
