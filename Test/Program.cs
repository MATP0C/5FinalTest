using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static int CheckNum()
        {
            int result = 0;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out int number);

                if (flag == false || number < 1)
                {
                    Console.WriteLine("Ошибка при вводе!");
                }
                else
                {
                    result = number;
                    break;
                }
            }
            return result;
        }
        static string[] CreateArray(int num)
        {
            var arrResult = new string[num];
            for (int i = 0; i < arrResult.Length; i++)
            {
                Console.Write($"{i + 1}. : ");
                string Name = Console.ReadLine();
                arrResult[i] = Name;
            }
            return arrResult;
        }
        static void PrintTuple((string Name, string lastName, int Age, bool HasPet, string[] NamePet, string[] nameColor) UserPrint)
        {
            Console.Write($"Ваше имя : {UserPrint.Name}");
            Console.Write($"Ваша фамилия : {UserPrint.lastName}");
            Console.Write($"Ваш возраст : {UserPrint.Age}");

            if (UserPrint.HasPet)
            {
                Console.WriteLine("Ваши питомцы : ");
                foreach (var Name in UserPrint.NamePet)
                {
                    Console.WriteLine(Name);
                }
            }
            Console.WriteLine("Ваши любимые цвета : ");
            foreach (var colors in UserPrint.nameColor)
            {
                Console.WriteLine(colors);
            }
        }
        static (string Name, string lastName, int Age, bool HasPet, string[] NamePet, string[] nameColor) EnterUser()
        {
            (string Name, string lastName, int Age, bool HasPet, string[] NamePet, string[] nameColor) User;

            Console.Write("Введите имя :");
            User.Name = Console.ReadLine();

            Console.Write("Введите фамилию :");
            User.lastName = Console.ReadLine();

            Console.Write("Введите возраст :");
            User.Age = CheckNum();

            Console.Write("Есть ли у вас питомец ?(Да/Нет) :");
            string answer = Console.ReadLine();
            if (answer == "Да")
            {
                User.HasPet = true;
                Console.Write("Введите количество ваших питомцев :");
                int numAnswer = CheckNum();
                User.NamePet = CreateArray(numAnswer);
            }
            else
            {
                User.NamePet = null;
                User.HasPet = false;
            }
            Console.Write("Сколько у вас любимых цветов ? :");
            int numColor = CheckNum();
            Console.WriteLine("Введите любимые цвета :");
            User.nameColor = CreateArray(numColor);
            return User;
        }
        static void Main(string[] args)
        {
            (string Name, string lastName, int Age, bool HasPet, string[] NamePet, string[] nameColor) anketa = EnterUser();
            PrintTuple(anketa);
            Console.ReadKey();
        }
    }
}
