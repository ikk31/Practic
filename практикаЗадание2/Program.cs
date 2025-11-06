namespace практикаЗадание2
    //в этом задание присутствуют функциии для проверки чисел, натуральное ли число, и для проверки корректности введённого процента чаевых, при ошибке введённых данных пользователю предоставляется возможность ввести данные ещё раз
    //далее в функции Main высчитывается сумма которую должен выплатить каждый и округляется.
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в SplitMeal, приложение, которое избавит тебя от подсчётов и добавит авторитета в кругу друзей");

            double totalAmount = GetPositiveNumber("Введите общую сумму обеда: ");
            int participants = (int)GetPositiveNumber("Введите количество участников обеда: ");
            int tipPercentage = GetTipPercentage();

            double totalWithTip = totalAmount * (1 + tipPercentage / 100.0);
            double amountPerPerson = totalWithTip / participants;

            Console.WriteLine($"Каждый должен заплатить: {Math.Round(amountPerPerson)} рублей");
        }

        static double GetPositiveNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double result))
                {
                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: число должно быть больше нуля. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: пожалуйста, введите корректное число.");
                }
            }
        }

        static int GetTipPercentage()
        {
            while (true)
            {
                Console.Write("Какой процент чаевых Вы оставляете 10, 12, 15: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 10 || result == 12 || result == 15)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: процент чаевых может быть только 10, 12 или 15. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: пожалуйста, введите корректное число (10, 12 или 15).");
                }
            }
        }
    }
}
