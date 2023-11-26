//Задача: Написать программу, которая из имеющегося массива строк 
//формирует новый массив из строк, длина которых меньше, либо равна 3 символам. 
//Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
//При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

//Примеры:
//[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
//[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
//[“Russia”, “Denmark”, “Kazan”] → []

namespace ControlHomework
{
    static class Controller
    {
        private static IObjective _objective;
        private static string _error = "Нет такой домашки";
        private static int _choose_homework = 1;

        private static void Main()
        {
            _objective = ObjSelector(_choose_homework);
            _objective.Start();
        }

        private static IObjective ObjSelector(int number)
        {
            switch (number)
            {
                case 1:
                    return new ObjectiveOne();
                default:
                    Console.WriteLine(_error);
                    return null;
            }
        }
    }

    public interface IObjective
    {
        void Start();
    }
}