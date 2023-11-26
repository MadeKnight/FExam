namespace ControlHomework
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
