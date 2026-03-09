using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace lab6oopvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Генерируем 100 компьютеров
            List<Computer> computers = Computer.Generate100();
            Console.WriteLine("Сгенерировано 100 компьютеров.\n");

            // задание 2 (Синтаксис запросов + Синтаксис методов)
            Console.WriteLine("ЗАДАНИЕ 2: ");

            // 2.1 По типу процессора (X64)
            // Синтаксис запросов
            var query2_1 = from c in computers
                           where c.ProcessorType == CpuType.X64
                           select c;

            var result2_1 = query2_1.ToList();
            Console.WriteLine($"\n2.1 (query) X64: {result2_1.Count} шт.");
            for (int i = 0; i < result2_1.Count; i++)
                Console.WriteLine($"  {result2_1[i]}");

            // Расширяющие методы
            var method2_1 = computers.Where(c => c.ProcessorType == CpuType.X64).ToList();
            Console.WriteLine($"\n2.1 (method) X64: {method2_1.Count()} шт.");
            for (int i = 0; i < method2_1.Count; i++)
                Console.WriteLine($"  {method2_1[i]}");

            // 2.2 По типу процессора и производителю (X64 + Microsoft)
            // Синтаксис запросов
            var query2_2 = from c in computers
                           where c.ProcessorType == CpuType.X64 && c.Manufacturer == ComputerManufacturer.Microsoft
                           select c;
            var result2_2 = query2_2.ToList();
            Console.WriteLine($"\n2.2 (query) X64: {result2_2.Count} шт.");
            for (int i = 0; i < result2_2.Count; i++)
                Console.WriteLine($"  {result2_2[i]}");

            // Расширяющие методы
            var method2_2 = computers.Where(c => c.ProcessorType == CpuType.X64 && c.Manufacturer == ComputerManufacturer.Microsoft).ToList();
            Console.WriteLine($"\n2.2 (method) X64 + Microsoft: {method2_2.Count()} шт.");
            for (int i = 0; i < method2_2.Count; i++)
                Console.WriteLine($"  {method2_2[i]}");

            // 2.3 По наличию пользователя "Alice" и RAM > 16 ГБ
            // Синтаксис запросов
            var query2_3 = from c in computers
                           where c.Users.Contains("Alice") && c.RamSize > 16
                           select c;

            var result2_3 = query2_3.ToList();
            Console.WriteLine($"\n2.3 (query) Alice + RAM>16: {result2_3.Count()} шт.");
            for (int i = 0; i < result2_3.Count; i++)
                Console.WriteLine($"  {result2_3[i]}");

            // Расширяющие методы
            var method2_3 = computers.Where(c => c.Users.Contains("Alice") && c.RamSize > 16).ToList();
            Console.WriteLine($"\n2.3 (method) Alice + RAM>16: {method2_3.Count()} шт.");
            for (int i = 0; i < method2_3.Count; i++)
                Console.WriteLine($"  {method2_3[i]}");

            // ЗАДАНИЕ 3
            Console.WriteLine("\n ЗАДАНИЕ 3:");
            //Генерируем 100 компьютеров
            List<Computer> computers3 = Computer.Generate100();
            Console.WriteLine("Сгенерировано 100 компьютеров.\n");
            // 3.1 По типу процессора
            // Синтаксис запросов
            var query3_1 = from c in computers3
                           orderby c.ProcessorType
                           select c;

            var result3_1 = query3_1.ToList();
            for (int i = 0; i < result3_1.Count; i++)
                Console.WriteLine($"  {result3_1[i]}");  // P.S ИХ ТУТ СОТКА, ЛУЧШЕ КОММЕНТИТЬ И ЗАПУСКАТЬ ОТДЕЛЬНО
            Console.WriteLine("========================");
            // Расширяющие методы
            var method3_1 = computers3.OrderBy(c => c.ProcessorType).ToList();
            for (int i = 0; i < method3_1.Count; i++)
                Console.WriteLine($"  {method3_1[i]}");  // P.S ИХ ТУТ СОТКА, ЛУЧШЕ КОММЕНТИТЬ И ЗАПУСКАТЬ ОТДЕЛЬНО
            Console.WriteLine("========================");
            // 3.2 По типу процессора и производителю
            // Синтаксис запросов
            var query3_2 = from c in computers3
                           orderby c.ProcessorType, c.Manufacturer.ToString()
                           select c;
            var result3_2 = query3_2.ToList();
            for (int i = 0; i < result3_2.Count; i++)
                Console.WriteLine($"  {result3_2[i]}");  // P.S ИХ ТУТ СОТКА, ЛУЧШЕ КОММЕНТИТЬ И ЗАПУСКАТЬ ОТДЕЛЬНО
            Console.WriteLine("========================");
            // Расширяющие методы
            var method3_2 = computers3.OrderBy(c => c.ProcessorType).ThenBy(c => c.Manufacturer.ToString()).ToList();
            for (int i = 0; i < method3_2.Count; i++)
                Console.WriteLine($"  {method3_2[i]}");  // P.S ИХ ТУТ СОТКА, ЛУЧШЕ КОММЕНТИТЬ И ЗАПУСКАТЬ ОТДЕЛЬНО
            Console.WriteLine("========================");


            //ЗАДАНИЕ 4
            Console.WriteLine("\nЗАДАНИЕ 4");
            //Генерируем 100 компьютеров
            List<Computer> computers4 = Computer.Generate100();
            Console.WriteLine("Сгенерировано 100 компьютеров.\n");
            // Синтаксис запросов
            var query4 = from c in computers4
                         select new
                         {
                             c.ClockSpeed,
                             c.RamSize,
                             Software = string.Join(", ", c.InstalledSoftware) // теперь это строка
                         };
            var result4 = query4.ToList();
            for (int i = 0; i < result4.Count; i++)
                Console.WriteLine($"  {result4[i]}"); // P.S ИХ ТУТ СОТКА, ЛУЧШЕ КОММЕНТИТЬ И ЗАПУСКАТЬ ОТДЕЛЬНО
            Console.WriteLine("========================");
            // Расширяющие методы
            var method4 = computers4.Select(c => new
            {
                c.ClockSpeed,
                c.RamSize,
                Software = string.Join(", ", c.InstalledSoftware) // теперь это строка
            }).ToList();
            for (int i = 0; i < method4.Count; i++)
                Console.WriteLine($"  {method4[i]}");  // P.S ИХ ТУТ СОТКА, ЛУЧШЕ КОММЕНТИТЬ И ЗАПУСКАТЬ ОТДЕЛЬНО
            Console.WriteLine("========================");

            // ЗАДАНИЕ 5: Внутреннее соединение 
            Console.WriteLine("\nЗАДАНИЕ 5: Внутреннее соединение ");
            // Генерируем 100 компьютеров
            List<Computer> computers5 = Computer.Generate100();
            Console.WriteLine("Сгенерировано 100 компьютеров.\n");
            // Создаём коллекцию производителей
            List<Manufacturer> manufacturers = new List<Manufacturer>
            {
                new Manufacturer("Microsoft", Country.USA, 180000),
                new Manufacturer("Apple", Country.USA, 147000),
                new Manufacturer("Dell", Country.USA, 165000),
                new Manufacturer("HP", Country.USA, 53000),
                new Manufacturer("Lenovo", Country.China, 75000),
                new Manufacturer("Asus", Country.Taiwan, 18000),
                new Manufacturer("Acer", Country.Taiwan, 7000)
            };

            // Синтаксис запросов (join)
            var query5 = from comp in computers5
                         join manuf in manufacturers on comp.Manufacturer.ToString() equals manuf.Name
                         select new { Computer = comp.Manufacturer, Manufacturer = manuf.Name };
            var result5 = query5.ToList();
            foreach (var item in result5)
            {
                Console.WriteLine($"Computer: {item.Computer}, Manufacturer: {item.Manufacturer}");
            }
            Console.WriteLine("========================");
            // Расширяющие методы (Join)
            var method5 = computers5.Join(manufacturers,
                                          comp => comp.Manufacturer.ToString(),
                                          manuf => manuf.Name,
                                          (comp, manuf) => new { Computer = comp.Manufacturer, Manufacturer = manuf.Name }).ToList();
            foreach (var item in method5)
            {
                Console.WriteLine($"Computer: {item.Computer}, Manufacturer: {item.Manufacturer}");
            }
            Console.WriteLine("========================");
            // ЗАДАНИЕ 6
            Console.WriteLine("\nЗАДАНИЕ 6: Расширяющий метод");
            string testString = "Hello Привет World Мир! 123";
            //string testString = null;
            string cleaned = testString.RemoveRussianLetters();
            Console.WriteLine($"Исходная: \"{testString}\"");
            Console.WriteLine($"Результат: \"{cleaned}\"");

            // Генерируем 100 компьютеров
            List<Computer> computers1 = Computer.Generate100();
            Console.WriteLine("Сгенерировано 100 компьютеров.\n");
            // Демонстрация IOverclock
            Console.WriteLine("\nДемонстрация IOverclock (однократный разгон) ");
            Computer testComp = computers1[0];
            Console.WriteLine($"До разгона: {testComp.ClockSpeed} МГц");
            testComp.OverclockTheComputer();
            Console.WriteLine($"После разгона: {testComp.ClockSpeed} МГц");
            try
            {
                testComp.OverclockTheComputer();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка при повторном вызове: {ex.Message}");
            }
        }
    }
}
