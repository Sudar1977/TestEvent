using System;
using TestDelegate.Example21;

namespace TestDelegate
{
    //https://metanit.com/sharp/tutorial/3.13.php
    //https://metanit.com/sharp/tutorial/3.33.php

    class Program
    {

        static void Main(string[] args)
        {
            new Example01_SimpleMessage();
            new Example02_Operation();
            new Example03_Messages();
            new Example04_Invoke();
            new Example05_DelegateAsMethodParametr();
            new Example06_GenericDelegate();
            //Далее примеры Action
            new Example51_ActionPredicateFunc();
            new Program22();
            Console.ReadKey();

        }
    }
}
