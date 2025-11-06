using System.Text;

//Шифр Цезаря
//Алгоритм решения: основной код программы Main это выбор действий,
//существует переменная выполнения которая по дефолту тру, дальше вызывается функция для получения выбора пользователя, функция возвращает варианты действий.
//Дальше в зависимости от выбора порльзователя вызываются фнкции по шифровки, засшифровки. В каждой функции присутствует валидация ввода.
//Для каждого введённого параметра существует отдельная функция с проверкой данных, для английских слов, для корректности ввода сдвига и т.д
namespace практикаЗадание5
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в шифровальщик!");

            bool running = true;

            while (running)
            {
                string action = GetUserAction();

                switch (action)
                {
                    case "зашифровать":
                        EncryptMessage();
                        break;
                    case "расшифровать":
                        DecryptMessage();
                        break;
                    case "выйти":
                        running = false;
                        Console.WriteLine("До свидания!");
                        break;
                }

                if (running && action != "выйти")
                {
                    running = HandleContinue();
                }
            }
        }

        static string GetUserAction()
        {
            while (true)
            {
                Console.WriteLine("\nНапечатайте «зашифровать» для зашифровки сообщения.");
                Console.WriteLine("Или «расшифровать» - для расшифровки:");
                Console.WriteLine("Или «выйти» для завершения программы:");

                string input = Console.ReadLine()?.ToLower().Trim();

                if (input == "зашифровать" || input == "расшифровать" || input == "выйти")
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Ошибка! Пожалуйста, введите «зашифровать», «расшифровать» или «выйти».");
                }
            }
        }

        static void EncryptMessage()
        {
            string message = GetValidMessage("Введите сообщение для шифровки без пробелов английскими буквами: ");
            int shift = GetValidShift();

            string encrypted = CaesarCipherTransform(message, shift, true);
            Console.WriteLine($"Зашифрованный результат: {encrypted}");
        }

        static void DecryptMessage()
        {
            string message = GetValidMessage("Введите сообщение для расшифровки: ");
            int shift = GetValidShift();

            string decrypted = CaesarCipherTransform(message, shift, false);
            Console.WriteLine($"Расшифрованный результат: {decrypted}");
        }

        static string GetValidMessage(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ошибка! Сообщение не может быть пустым.");
                    continue;
                }

                
                bool isValid = true;
                foreach (char c in input)
                {
                    if (!char.IsLetter(c) || !IsEnglishLetter(c))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    return input.ToLower();
                }
                else
                {
                    Console.WriteLine("Ошибка! Сообщение должно содержать только английские буквы без пробелов и других символов.");
                }
            }
        }

        static int GetValidShift()
        {
            while (true)
            {
                Console.Write("Введите сдвиг (целое число от 1 до 25): ");
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out int shift))
                {
                    if (shift >= 1 && shift <= 25)
                    {
                        return shift;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Сдвиг должен быть в диапазоне от 1 до 25.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Пожалуйста, введите целое число.");
                }
            }
        }

        static string CaesarCipherTransform(string text, int shift, bool encrypt)
        {
            StringBuilder result = new StringBuilder();

            if (!encrypt)
            {
                shift = -shift; 
            }

            foreach (char character in text)
            {
                if (char.IsLetter(character))
                {
                    char offset = char.IsUpper(character) ? 'A' : 'a';
                    char shifted = (char)(((character - offset + shift + 26) % 26) + offset);
                    result.Append(shifted);
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }

        static bool IsEnglishLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        static bool HandleContinue()
        {
            while (true)
            {
                Console.WriteLine("\nНапечатайте «сначала» чтобы вернутся в меню.");
                Console.WriteLine("Или «выйти» для завершения программы:");

                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "сначала":
                        return true;
                    case "выйти":
                        return false;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите «сначала» или «выйти».");
                        break;
                }
            }
        }
    }
}
