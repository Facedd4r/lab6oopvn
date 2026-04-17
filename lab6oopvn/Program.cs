using MyLib4Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace lab6oopvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myType = typeof(ReflectionClass);
            // вывод информации о полях с помощью рефлексии
            // выводятся также автоматически сгенерированные компилятором поля для авто свойств
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = "";

                // получаем модификатор доступа
                if (field.IsPublic)
                    modificator += "public ";
                else if (field.IsPrivate)
                    modificator += "private ";
                else if (field.IsAssembly)
                    modificator += "internal ";
                else if (field.IsFamily)
                    modificator += "protected ";
                else if (field.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (field.IsFamilyOrAssembly)
                    modificator += "protected internal ";

                // если поле статическое
                if (field.IsStatic) modificator += "static ";

                Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
            }
            // вывод информации о свойствах с помощью рефлексии
            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                Console.Write($"{prop.PropertyType} {prop.Name} {{");

                // если свойство доступно для чтения
                if (prop.CanRead) Console.Write("get;");
                // если свойство доступно для записи
                if (prop.CanWrite) Console.Write("set;");
                Console.WriteLine("}");
            }
            // вывод информации о методах с помощью рефлексии
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";

                // если метод статический
                if (method.IsStatic) modificator += "static ";
                // если метод виртуальный
                if (method.IsVirtual) modificator += "virtual ";

                Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
            }
            // Получение и изменение значения поля
            // получаем приватное поле _privateField
            ReflectionClass reflectionClass = new ReflectionClass(159, "Беспредел", 228.88);
            var num = myType.GetField("_privateField", BindingFlags.Instance | BindingFlags.NonPublic);

            // получаем значение поля _privateField
            var value = num?.GetValue(reflectionClass);
            Console.WriteLine(value);

            // изменяем значение поля _privateField
            num?.SetValue(reflectionClass, 155);
            reflectionClass.PrintInfo();

            // Получение и изменение значения свойств
            // получаем свойство ProtectedProperty
            var strProp = myType.GetProperty("ProtectedProperty", BindingFlags.NonPublic | BindingFlags.Instance);
            // получаем значение свойства ProtectedProperty у объекта reflectionClass
            var str = strProp?.GetValue(reflectionClass);
            Console.WriteLine(str);
            // устанавливаем новое значение для свойства 
            strProp?.SetValue(reflectionClass, "Груз 200");
            reflectionClass.PrintInfo();


            string[] methodNames = { "PublicMethod", "ProtectedMethod", "PrivateMethod" };

            foreach (string methodName in methodNames)
            {
                var method = myType.GetMethod(methodName,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (method != null)
                {
                    // Для PrivateMethod нужен параметр, для остальных – нет
                    object[] parameters = methodName == "PrivateMethod"
                        ? new object[] { "Вызов из foreach" }
                        : null;

                    method.Invoke(reflectionClass, parameters);
                }
            }

            // Вызов конструктора с тремя параметрами
            // Получаем конструктор с параметрами (int, string, double)
            var constructor = myType.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(double) });
            // Вызываем конструктор, передавая аргументы
            object newObj = constructor?.Invoke(new object[] { 999, "Новый объект", 123.45 });
            // Проверяем, что объект создан
            ((ReflectionClass)newObj).PrintInfo();

            // Вызов конструктора без параметров
            var emptyConstructor = myType.GetConstructor(Type.EmptyTypes);
            object defaultObj = emptyConstructor?.Invoke(null);

            //Загрузить библиотеку и получить информацию о классе
            Assembly assembly = Assembly.LoadFrom("MyLib4Reflection.dll");

            // Получаем тип по полному имени (с пространством имён)
            Type myTypeAssembly = assembly.GetType("MyLib4Reflection.ReflectionClass");

            if (myTypeAssembly != null)
            {
                Console.WriteLine($"\nИнформация о классе {myTypeAssembly.Name}:\n");

                // Поля
                Console.WriteLine("Поля:");
                foreach (FieldInfo field in myTypeAssembly.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    Console.WriteLine($"{field.FieldType.Name} {field.Name} (доступ: {field.Attributes})");
                }

                // Свойства
                Console.WriteLine("\nСвойства:");
                foreach (PropertyInfo prop in myTypeAssembly.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    Console.WriteLine($"{prop.PropertyType.Name} {prop.Name} (Read: {prop.CanRead}, Write: {prop.CanWrite})");
                }

                // Методы
                Console.WriteLine("\nМетоды:");
                foreach (MethodInfo method in myTypeAssembly.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    if (!method.IsSpecialName)
                        Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
                }
            }

            // солнечная система с singleton
            var planets = new IPlanet[]
            {
                Mercury.Instance,
                Venus.Instance,
                Earth.Instance,
                Mars.Instance,
                Jupiter.Instance,
                Saturn.Instance,
                Uranus.Instance,
                Neptune.Instance
            };

            foreach (var planet in planets)
            {
                planet.ShowInfo();
                Console.WriteLine();
            }
            // ПРОВЕРКА что при обращении к Instance возвращается один и тот же объект
            var s1 = Mercury.Instance;
            var s2 = Mercury.Instance;
            Console.WriteLine(s1 == s2); // True

            // Prototype
            Computer original = new Computer(CpuType.X64, ComputerManufacturer.Apple, OSType.Windows, 3200, 16, 
                new List<string> { "VsC", "Safari" },
                new List<string> { "Nikita", "Vlados" });
            Computer clone = (Computer)original.Clone();

            original.Users.Add("Zahar");
            original.InstalledSoftware.Add("Visual Basic");

            Console.WriteLine("Оригинал: " + original); // Users: 3, SW: 3
            Console.WriteLine("Клон:     " + clone);    // Users: 2, SW: 2 – клон не изменился

        }
    }
}
