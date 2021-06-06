using System;
using System.Collections.Generic;
using System.Text;


//Делегат Message в качестве возвращаемого типа имеет тип void (то есть ничего не возвращает)
//и не принимает никаких параметров. Это значит, что этот делегат может указывать на любой метод,
//который не принимает никаких параметров и ничего не возвращает.
//Рассмотрим примение этого делегата:
//Для объявления делегата используется ключевое слово delegate, после которого идет возвращаемый тип,
//название и параметры. Например:

//В данном случае делегат определяется внутри класса, но также можно определить делегат вне класса внутри
//пространства имен.

namespace TestDelegate
{
    public class Example01_SimpleMessage
    {
        delegate void Message(); // 1. Объявляем делегат
        public Example01_SimpleMessage()
        {
            Message mes; // 2. Создаем переменную делегата
            if (DateTime.Now.Hour < 12)
            {
                mes = GoodMorning; // 3. Присваиваем этой переменной адрес метода
            }
            else
            {
                mes = GoodEvening;
            }
            //Вызов делегата производится подобно вызову метода.
            mes(); // 4. Вызываем метод
        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
    }
}
