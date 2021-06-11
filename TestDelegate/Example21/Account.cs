using System;
using System.Collections.Generic;
using System.Text;
//Рассмотрим подробный пример. Пусть у нас есть класс, описывающий счет в банке:
namespace TestDelegate.Example21
{
    public class Account
    {

        //Допустим, в случае вывода денег с помощью метода Withdraw нам надо как-то
        //уведомлять об этом самого клиента и, может быть, другие объекты.
        //Для этого создадим делегат AccountStateHandler.
        //Чтобы использовать делегат, нам надо создать переменную этого делегата,
        //а затем присвоить ему метод, который будет вызываться делегатом.
        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        // Создаем переменную делегата
        AccountStateHandler _del;

        // Регистрируем делегат
          public void RegisterHandler(AccountStateHandler del)
        {
            _del += del; // добавляем делегат
        }
        //Итак, изменим в классе Account метод RegisterHandler и добавим новый метод UnregisterHandler,
        //который будет удалять методы из списка методов делегата:
        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler del)
        {
            _del -= del; // удаляем делегат
        }

        int _sum; // Переменная для хранения суммы

        public Account(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }
        //Здесь фактически проделываются те же шаги, что были выше, и есть практически все кроме вызова делегата.
        //В данном случае у нас делегат принимает параметр типа string. Теперь изменим метод Withdraw следующим образом:
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                if (_del != null)
                    _del($"Сумма {sum} снята со счета");
            }
            else
            {
                if (_del != null)
                    _del("Недостаточно денег на счете");
            }
        }
    }
}
