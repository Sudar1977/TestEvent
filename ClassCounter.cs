using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvent
{
    class ClassCounter  //Это класс - в котором производится счет.
    {
        //Синтаксис по сигнатуре метода, на который мы создаем делегат: 
        //delegate <выходной тип> ИмяДелегата(<тип входных параметров>);
        //Мы создаем на void Message(). Он должен запуститься, когда условие выполнится.

        public delegate void MethodContainer();

        //Событие OnCount c типом делегата MethodContainer.
        public event MethodContainer onCount;

        //Dictionary<string, Action> _actions;
//        void NameMetods(string value)
//        {
//            _actions = new Dictionary<string, Action>
//            {
////                ["Message_I"] = Message_I;
//            }
//        }

        public void Count()
        {
            //Здесь будет производиться счет
            for (int i = 0; i < 100; i++)
            {
                if (i == 71)
                {
                    onCount?.Invoke();
                }
            }

        }
    }
}
