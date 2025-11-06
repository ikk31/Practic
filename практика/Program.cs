using System;
//Первое задание для создания названия для музыкальной группы. Тут вызываются функции для проверка правильности введенных данных
//В фнукцию проверки передаётся сам промт который будет выводится на экран, в функции уже проверяется введённое слово и если оно проходит все проверка, то оно передаётся в нужные переменные и потом формируется название группы по шаблону
class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в генератор твоей крутой музыкальной группы!");

        string city = GetInput("Введите название родного города: ");
        string pet = GetInput("Введите имя своего домашнего питомца: ");

        Console.WriteLine($"\n🎵 Имя Вашей группы: {pet} из {city} 🎵");
    }

    static string GetInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Пожалуйста, введите значение!");
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}