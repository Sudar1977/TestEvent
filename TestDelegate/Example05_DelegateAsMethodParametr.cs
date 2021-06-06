using System;
using System.Collections.Generic;
using System.Text;

//Также делегаты могут быть параметрами методов:

namespace TestDelegate
{
    class Example05_DelegateAsMethodParametr
    {
        delegate void GetMessage();
        public Example05_DelegateAsMethodParametr()
        {
            if (DateTime.Now.Hour < 12)
            {
                Show_Message(GoodMorning);
            }
            else
            {
                Show_Message(GoodEvening);
            }
        }
        private void Show_Message(GetMessage _del)
        {
            _del?.Invoke();
        }
        private void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
    }
}
