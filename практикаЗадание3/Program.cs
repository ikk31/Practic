using System.Text;

//генератор паролей
//пользователь вводит необходимые данные, вызывается функция проверки чисел, далее все введнные параметры передаются в функцию для генерации паролей, потом генерируется пароль из предоставленных данных по паролю.
//Далее символы в этом пароле перемешиваются по алгоритму Фишера-Йейтса
//(тк по факту наш пароль это массив я подумал использовать именно этот алгоритм, он мне кажется более лекгким для понимания и достаточно надёжным ну и в принципе искал как можно перемешать пароль, в интернете в основном про этот алгоритм писали:)))
//Время выполнения алгоритма O(n), суть алгоритма в том, что мы идём с последнего элемента массив n-1 до второго элемента массива с индексом 1, далее нужно для каждого элемента сгенерировать случайный элемент j в диапазоне от 0 до i, далее надо менять местами значения с индексом i на элемента под индексом j и алгоритм повторяется до того момента пока не будет пройдены все символы
namespace практикаЗадание3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в хакерский генератор паролей!");

            int lettersCount = GetPositiveInteger("Сколько букв должно быть в пароле: ");
            int symbolsCount = GetPositiveInteger("Сколько спецсимволов должно быть в пароле: ");
            int numbersCount = GetPositiveInteger("Сколько чисел должно быть в пароле: ");

            string password = GeneratePassword(lettersCount, symbolsCount, numbersCount);
            Console.WriteLine($"Ваш пароль: {password}");
        }

        static int GetPositiveInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine("Ошибка: введите целое число больше нуля. Попробуйте снова.");
            }
        }

        static string GeneratePassword(int lettersCount, int symbolsCount, int numbersCount)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";
            const string numbers = "0123456789";

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            
            for (int i = 0; i < lettersCount; i++)
            {
                password.Append(letters[random.Next(letters.Length)]);
            }

           
            for (int i = 0; i < symbolsCount; i++)
            {
                password.Append(symbols[random.Next(symbols.Length)]);
            }

            
            for (int i = 0; i < numbersCount; i++)
            {
                password.Append(numbers[random.Next(numbers.Length)]);
            }

            
            return ShuffleString(password.ToString(), random);
        }

        static string ShuffleString(string input, Random random)
        {
            char[] characters = input.ToCharArray();

            
            for (int i = characters.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (characters[i], characters[j]) = (characters[j], characters[i]);
            }

            return new string(characters);
        }
    }
}
