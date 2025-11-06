namespace практикаЗадание4
    //Алгоритм выполнения задание с поиском сокровищ
    //есть переменная в которой хранится количество шагов, и булевская переменная которая обозначает закончена игра или нет,
    //дальше проходит проверка количества шагов и не закончена ли игра
    //В каждом шаге есть проверка введённых данных и используется switch-case для выбора вариантов действий
    
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать на поиски сокровищ!");

            int step = 0;
            bool gameCompleted = false;

            while (step < 10 && !gameCompleted)
            {
                switch (step)
                {
                    case 0: // Развилка
                        step = Fork(step);
                        break;
                    case 1: // Озеро
                        step = Lake(step);
                        break;
                    case 2: // Двери дома
                        step = HouseDoors(step);
                        break;
                    case 3: // Пещера
                        step = Cave(step);
                        break;
                    case 4: // Загадка старца
                        step = OldManRiddle(step);
                        break;
                    case 5: // Подземный ход
                        step = UndergroundPassage(step);
                        break;
                    case 6: // Сундук с загадкой
                        step = TreasureChest(step);
                        break;
                    case 7: // Финальная головоломка
                        step = FinalPuzzle(step);
                        gameCompleted = true;
                        break;
                    default:
                        Console.WriteLine("Игра завершена!");
                        step = 10;
                        break;
                }
            }

            Console.WriteLine("\nСпасибо за игру!");
        }

        static int Fork(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nИтак, Вы на острове сокровищ. Вы находитесь на развилке. Куда пойдете?");
                Console.Write("(напечатайте «направо», «налево» или «прямо»): ");
                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "налево":
                        Console.WriteLine("Вы прибыли к озеру.");
                        return 1;
                    case "направо":
                        Console.WriteLine("Вы нашли вход в пещеру.");
                        return 3;
                    case "прямо":
                        Console.WriteLine("Вы встретили старого мудреца, который предлагает вам загадку.");
                        return 4;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите одно из предложенных значений.");
                        break;
                }
            }
        }

        static int Lake(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nВ центре озера находится остров.");
                Console.Write("Напечатайте «ждать» чтобы подождать лодку или «плыть» чтобы добраться до острова вплавь: ");
                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "ждать":
                        Console.WriteLine("Вы прибыли на остров. Перед Вами дом с тремя дверями.");
                        return 2;
                    case "плыть":
                        Console.WriteLine("К сожалению, в озере водятся пираньи. Вы не доплыли. Начните сначала.");
                        return 0;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите «ждать» или «плыть».");
                        break;
                }
            }
        }

        static int HouseDoors(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nПеред Вами дом с тремя дверями: красная, желтая и зеленая.");
                Console.Write("Напечатайте цвет двери: ");
                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "красная":
                        Console.WriteLine("Это был вход в горящую комнату, и Вы сгорели. Начните сначала.");
                        return 0;
                    case "желтая":
                        Console.WriteLine("Вы нашли карту, ведущую к подземному ходу!");
                        return 5;
                    case "зеленая":
                        Console.WriteLine("За дверью вас ждала ловушка - яма с шипами. Начните сначала.");
                        return 0;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите «красная», «желтая» или «зеленая».");
                        break;
                }
            }
        }

        static int Cave(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nВы в пещере. Видите два тоннеля.");
                Console.Write("Напечатайте «левый» или «правый»: ");
                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "левый":
                        Console.WriteLine("Вы нашли древний сундук с загадкой!");
                        return 6;
                    case "правый":
                        Console.WriteLine("Тоннель обвалился. Начните сначала.");
                        return 0;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите «левый» или «правый».");
                        break;
                }
            }
        }

        static int OldManRiddle(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nСтарец задает загадку: 'Без окон, без дверей, полна горница людей.'");
                Console.Write("Напечатайте ваш ответ: ");
                string input = Console.ReadLine()?.ToLower().Trim();

                if (input == "огурец" || input == "арбуз" || input == "тыква")
                {
                    Console.WriteLine("Правильно! Старец дает вам волшебный ключ.");
                    return 6;
                }
                else
                {
                    Console.WriteLine("Неправильно! Старец исчезает, и вы возвращаетесь к развилке.");
                    return 0;
                }
            }
        }

        static int UndergroundPassage(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nВы в подземном ходе. Перед вами три рычага.");
                Console.Write("Напечатайте «первый», «второй» или «третий»: ");
                string input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "первый":
                        Console.WriteLine("Сработала ловушка. Начните сначала.");
                        return 0;
                    case "второй":
                        Console.WriteLine("Открывается потайная дверь к сокровищам!");
                        return 7;
                    case "третий":
                        Console.WriteLine("Ничего не происходит. Попробуйте другой рычаг.");
                        break;
                    default:
                        Console.WriteLine("Ошибка! Пожалуйста, введите «первый», «второй» или «третий».");
                        break;
                }
            }
        }

        static int TreasureChest(int currentStep)
        {
            while (true)
            {
                Console.WriteLine("\nПеред вами сундук с числовой загадкой: 'Я больше 5, меньше 10, и я простое число.'");
                Console.Write("Введите число: ");
                string input = Console.ReadLine()?.Trim();

                if (input == "7")
                {
                    Console.WriteLine("Правильно! Сундук открывается, и вы находите ключ от финальной комнаты.");
                    return 7;
                }
                else
                {
                    Console.WriteLine("Неправильно! Сундук исчезает. Начните сначала.");
                    return 0;
                }
            }
        }

        static int FinalPuzzle(int currentStep)
        {
            Console.WriteLine("\n🎉 ПОЗДРАВЛЯЮ! 🎉");
            Console.WriteLine("Вы нашли сокровища!");
            Console.WriteLine("В сундуке вы находите золотые монеты, драгоценные камни и древние артефакты.");
            Console.WriteLine("Вы стали богатым и знаменитым искателем приключений!");
            return 8;
        }
    }
}
