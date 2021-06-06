namespace TestGeneric
{
    //Использование нескольких универсальных параметров
    //Обобщения могут использовать несколько универсальных параметров одновременно,
    //которые могут представлять различные типы:
    class Transaction<U, V>
    {
        public U FromAccount { get; set; }  // с какого счета перевод
        public U ToAccount { get; set; }    // на какой счет перевод
        public V Code { get; set; }         // код операции
        public int Sum { get; set; }        // сумма перевода
    }
}
