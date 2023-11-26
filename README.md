#  Итоговая контрольная работа по основному блоку

Данная работа необходима для проверки ваших знаний и навыков по итогу прохождения первого блока обучения на программе Разработчик. Мы должны убедится, что базовое знакомство с IT прошло успешно.

Задача алгоритмически не самая сложная, однако для полноценного выполнения проверочной работы необходимо:

1. Создать репозиторий на GitHub
2. Нарисовать блок-схему алгоритма (можно обойтись блок-схемой основной содержательной части, если вы выделяете её в отдельный метод)
3. Снабдить репозиторий оформленным текстовым описанием решения (файл README.md)
4. Написать программу, решающую поставленную задачу
5. Использовать контроль версий в работе над этим небольшим проектом (не должно быть так, что всё залито одним коммитом, как минимум этапы 2, 3, и 4 должны быть расположены в разных коммитах)

##  Задача:
Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
##  Примеры:
```
[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]

[“1234”, “1567”, “-2”, “computer science”] → [“-2”]

[“Russia”, “Denmark”, “Kazan”] → []
```

#  Выполнение задачи
Был использован `Controller.cs` для запуска программы, в блок схеме он не указан, сделан для удобства выполнения различных задач.
## Код `Controller.cs`:
```
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
```
Основной код программы находится в `ObjectiveOne.cs`.
## Код `ObjectiveOne.cs`:
```
﻿namespace ControlHomework
{
    public class ObjectiveOne : IObjective
    {
        private static readonly int _charLimit = 3;

        private string _msgAnswerToController = "Запуск первого задания";
        private string _msgWelcome = "Пишите любые слова";
        private string _msgMassiveLength = "Сколько слов Вы хотите ввести?";
        private string _msgNotANumber = "Введите число больше 0!";
        private string _msgViewChosenWords = $"Выведем все слова, где количество символов не превышает {_charLimit}";
        private string _msgNoResult = "Нечего выводить";

        private string[] _words;

        public void Start()
        {
            Console.WriteLine(_msgAnswerToController);
            Calculation();
        }

        private void Calculation()
        {
            Console.WriteLine(_msgMassiveLength);
            CheckOnNumber();
            Console.WriteLine(_msgWelcome);
            CreateArray();
            Console.WriteLine(_msgViewChosenWords);
            PrintResult(ChoosingWords());
        }

        private void CheckOnNumber()
        {
            if (int.TryParse(Console.ReadLine(), out int word) && word != 0)
            {
                _words = new string[word];
            }                    
            else
            {
                Console.WriteLine(_msgNotANumber);
                CheckOnNumber();
            }
        }

        private void CreateArray()
        {
            for (int i = 0; i < _words.Length; i++)
            {
                _words[i] = Console.ReadLine();
            }
        }                

        private string[] ChoosingWords()
        {
            string[] tempArray = new string[_words.Length];
            int i = 0;

            foreach (string word in _words)
            {
                if (word.Length <= _charLimit)
                {
                    tempArray[i++] = word;
                }
            }

            return tempArray;
        }

        private void PrintResult(string[] array)
        {
            string tempWord = _msgNoResult;
            bool tempWordExist = false;

            foreach (string word in array)
            {
                if (word != null)
                {
                    tempWord = word;
                    Console.WriteLine(tempWord);
                    tempWordExist = true;
                }
            }

            if (!tempWordExist) Console.WriteLine(tempWord);
        }
    }
}
```
# Блок-схема алгоритма:
![FExam](https://github.com/MadeKnight/FExam/assets/142689532/bf0f90fd-0237-48ab-8bba-fc493bcc2119)
