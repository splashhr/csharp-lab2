using System;
using System.Globalization;
using System.Text;

namespace Lab2
{
    internal static class Program
    {
        private static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Лабораторная работа №2. Вариант 5.");

            int choice;
            while (true)
            {
                PrintMenu();
                choice = ReadMenuChoice();
                if (choice == 0)
                {
                    return;
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        ShowPointsAndNames();
                        break;
                    case 2:
                        ShowLines();
                        break;
                    case 3:
                        ShowCityMap();
                        break;
                    case 4:
                        ShowCityConstructors();
                        break;
                    case 5:
                        ShowFractions();
                        break;
                    case 6:
                        ShowPointsAndNames();
                        ShowLines();
                        ShowCityMap();
                        ShowCityConstructors();
                        ShowFractions();
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 — Точки и имена (1.1, 1.3)");
            Console.WriteLine("2 — Линии и общие точки (2.1)");
            Console.WriteLine("3 — Схема городов (3.3)");
            Console.WriteLine("4 — Конструкторы города (4.8)");
            Console.WriteLine("5 — Дроби (5.5)");
            Console.WriteLine("6 — Показать все задания");
            Console.WriteLine("0 — Выход");
        }

        private static int ReadMenuChoice()
        {
            string? input;
            int choice;
            while (true)
            {
                Console.Write("Выберите пункт: ");
                input = Console.ReadLine();
                if (input == null)
                {
                    return 0;
                }

                if (int.TryParse(input, CultureInfo.InvariantCulture, out choice)
                    && choice >= 0 && choice <= 6)
                {
                    return choice;
                }

                Console.WriteLine("Введите целое число от 0 до 6.");
            }
        }

        private static void ShowPointsAndNames()
        {
            Console.WriteLine("Задание 1.1. Точки координат");
            var firstPoint = new Point(3, 5);
            var secondPoint = new Point(25, 6);
            var thirdPoint = new Point(7, 8);
            Console.WriteLine(firstPoint);
            Console.WriteLine(secondPoint);
            Console.WriteLine(thirdPoint);

            Console.WriteLine();
            Console.WriteLine("Задание 1.3. Имена");
            var cleopatra = new PersonName(null, "Клеопатра", null);
            var pushkin = new PersonName("Пушкин", "Александр", "Сергеевич");
            var mayakovsky = new PersonName("Маяковский", "Владимир", null);
            Console.WriteLine(cleopatra);
            Console.WriteLine(pushkin);
            Console.WriteLine(mayakovsky);
            Console.WriteLine("Пропущенные части имени не добавляют лишних пробелов.");
            Console.WriteLine();
        }

        private static void ShowLines()
        {
            Console.WriteLine("Задание 2.1. Линии и общие точки");
            var firstLine = new Line(new Point(1, 3), new Point(23, 8));
            var secondLine = new Line(new Point(5, 10), new Point(25, 10));

            var thirdLine = new Line(firstLine.Start, secondLine.End);
            Console.WriteLine("Исходные линии:");
            PrintLines(firstLine, secondLine, thirdLine);

            firstLine.Start.X = 2;
            firstLine.Start.Y = 4;
            secondLine.End.X = 30;
            secondLine.End.Y = 12;
            Console.WriteLine("Изменили общие точки: начало первой и конец второй линии.");
            PrintLines(firstLine, secondLine, thirdLine);
            Console.WriteLine("Третья линия тоже изменилась: точки общие.");

            firstLine.Start = new Point(-1, -2);
            firstLine.End.X = 40;
            firstLine.End.Y = 20;
            Console.WriteLine("Заменили начало первой линии новым объектом и изменили её конец.");
            PrintLines(firstLine, secondLine, thirdLine);
            Console.WriteLine("Третья линия сохранила прежние координаты.");
            Console.WriteLine();
        }

        private static void PrintLines(Line firstLine, Line secondLine, Line thirdLine)
        {
            Console.WriteLine($"Линия 1: {firstLine}");
            Console.WriteLine($"Линия 2: {secondLine}");
            Console.WriteLine($"Линия 3: {thirdLine}");
        }

        private static void ShowCityMap()
        {
            Console.WriteLine("Задание 3.3. Города и пути на рисунке 2");
            var cityA = new City("A");
            var cityB = new City("B");
            var cityC = new City("C");
            var cityD = new City("D");
            var cityE = new City("E");
            var cityF = new City("F");

            cityA.AddRoute(cityB, 5);
            cityA.AddRoute(cityF, 1);
            cityA.AddRoute(cityD, 6);
            cityB.AddRoute(cityA, 5);
            cityB.AddRoute(cityC, 3);
            cityC.AddRoute(cityB, 3);
            cityC.AddRoute(cityD, 4);
            cityD.AddRoute(cityA, 6);
            cityD.AddRoute(cityC, 4);
            cityD.AddRoute(cityE, 2);
            cityE.AddRoute(cityF, 2);
            cityF.AddRoute(cityB, 1);
            cityF.AddRoute(cityE, 2);

            var cities = new City[] { cityA, cityB, cityC, cityD, cityE, cityF };
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine("Всего 6 городов и 13 направленных путей.");
            Console.WriteLine();
        }

        private static void ShowCityConstructors()
        {
            Console.WriteLine("Задание 4.8. Два способа создания города");
            var cityB = new City("B");
            var cityF = new City("F");
            Console.WriteLine($"Только название: {cityB}");

            var routes = new Route[] { new Route(cityB, 5), new Route(cityF, 1) };
            var cityA = new City("A", routes);
            Console.WriteLine($"Название и готовые пути: {cityA}");
            Console.WriteLine($"Название города: {cityA.Name}; путей: {cityA.Routes.Count}.");
            foreach (var route in cityA.Routes)
            {
                Console.WriteLine($"Путь: {route}; город: {route.Destination.Name}; стоимость: {route.Cost}.");
            }

            Console.WriteLine();
        }

        private static void ShowFractions()
        {
            Console.WriteLine("Задание 5.5. Дроби");
            var first = new Fraction(1, 3);
            var second = new Fraction(2, 3);
            var third = new Fraction(3, 4);
            Console.WriteLine($"f1 = {first}, f2 = {second}, f3 = {third}");
            Console.WriteLine($"Числитель f1: {first.Numerator}; знаменатель: {first.Denominator}.");

            Console.WriteLine("Операции с другой дробью:");
            Console.WriteLine($"{first} + {second} = {first.Sum(second)}");
            Console.WriteLine($"{first} - {second} = {first.Minus(second)}");
            Console.WriteLine($"{first} * {second} = {first.Multiply(second)}");
            Console.WriteLine($"{first} / {second} = {first.Div(second)}");

            var number = 2;
            Console.WriteLine("Операции с целым числом:");
            Console.WriteLine($"{first} + {number} = {first.Sum(number)}");
            Console.WriteLine($"{first} - {number} = {first.Minus(number)}");
            Console.WriteLine($"{first} * {number} = {first.Multiply(number)}");
            Console.WriteLine($"{first} / {number} = {first.Div(number)}");

            var result = first.Sum(second).Div(third).Minus(5);
            Console.WriteLine($"f1.Sum(f2).Div(f3).Minus(5) = {result}");
            Console.WriteLine($"Исходные дроби не изменились: {first}, {second}, {third}.");
            Console.WriteLine();
        }
    }
}
