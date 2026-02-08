using System;
using System.Collections.Generic;
using DriverMatching.Algorithms.Models;
using DriverMatching.Core.Models;


namespace DriverMatching.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система подбора водителей - Часть 1 ===\n");

            // Создаем тестовых водителей
            var drivers = new List<Driver>
            {
                new Driver(1, 5, 10),
                new Driver(2, 7, 12),
                new Driver(3, 3, 8),
                new Driver(4, 9, 15),
                new Driver(5, 1, 2),
                new Driver(6, 12, 6),
                new Driver(7, 8, 9),
                new Driver(8, 4, 11),
                new Driver(9, 6, 8),
                new Driver(10, 15, 20)
            };

            var order = new Order(6, 10);

            // Тестируем все алгоритмы
            var algorithms = new List<(string Name, INearestDriversFinder Finder)>
            {
                ("Linear Search", new LinearSearchFinder()),
                ("Priority Queue", new PriorityQueueFinder()),
                ("Grid Based", new GridBasedFinder())
            };

            Console.WriteLine($"Заказ: ({order.X}, {order.Y})");
            Console.WriteLine($"Всего водителей: {drivers.Count}\n");

            foreach (var (name, finder) in algorithms)
            {
                Console.WriteLine($"--- {name} ---");

                try
                {
                    var startTime = DateTime.Now;
                    var nearest = finder.FindNearest(order, drivers);
                    var endTime = DateTime.Now;

                    var duration = (endTime - startTime).TotalMilliseconds;

                    if (nearest.Count > 0)
                    {
                        for (int i = 0; i < nearest.Count; i++)
                        {
                            var n = nearest[i];
                            Console.WriteLine($"{i + 1}. Водитель {n.Driver.Id}: ({n.Driver.X}, {n.Driver.Y}), " +
                                            $"расстояние: {n.Distance:F2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не найдено ближайших водителей.");
                    }

                    Console.WriteLine($"Время выполнения: {duration:F2} мс\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в {name}: {ex.Message}\n");
                }
            }

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}