using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    internal class Computer : IComputer, IOverclock, ICloneable
    {
        /// <summary>
        /// // Флаг для IOverclock
        /// </summary>
        private bool _overclocked = false; 
        /// <summary>
        ///  реализация интерфейса 
        /// </summary>
        public CpuType ProcessorType { get; set; }
        public ComputerManufacturer Manufacturer { get; set; }
        public OSType OperatingSystem { get; set; }
        public int ClockSpeed { get; set; }
        public int RamSize { get; set; }
        public List<string> InstalledSoftware { get; set; }
        public List<string> Users { get; set; }

        /// <summary>
        /// Реализация метода разгона
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void OverclockTheComputer()
        {
            if (_overclocked)
                throw new InvalidOperationException("Разгон можно выполнить только один раз!");

            // Увеличение частоты в зависимости от типа процессора (архитектуры)
            switch (ProcessorType)
            {
                case CpuType.X86:
                case CpuType.X64:
                    ClockSpeed = (int)(ClockSpeed * 1.10);
                    break;
                case CpuType.Arm:
                case CpuType.Arm64:
                case CpuType.Armv6:
                    ClockSpeed = (int)(ClockSpeed * 1.05);
                    break;
                default:
                    ClockSpeed = (int)(ClockSpeed * 1.08);
                    break;
            }

            _overclocked = true;
        }



        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Computer()
        {
            InstalledSoftware = new List<string>();
            Users = new List<string>();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="processorType"></param>
        /// <param name="manufacturer"></param>
        /// <param name="os"></param>
        /// <param name="clockSpeed"></param>
        /// <param name="ramSize"></param>
        /// <param name="software"></param>
        /// <param name="users"></param>
        public Computer(CpuType processorType, ComputerManufacturer manufacturer, OSType os,
                        int clockSpeed, int ramSize, List<string> software, List<string> users)
        {
            ProcessorType = processorType;
            Manufacturer = manufacturer;
            OperatingSystem = os;
            ClockSpeed = clockSpeed;
            RamSize = ramSize;
            InstalledSoftware = software ?? new List<string>();
            Users = users ?? new List<string>();
        }

        /// <summary>
        /// Генерация одного случайного компьютера
        /// </summary>
        /// <returns></returns>
        public static Computer Generate(Random rnd)
        {
            // возврат массивов всех значений констант, определенных в перечислениях
            var processorTypes = Enum.GetValues(typeof(CpuType));
            var manufacturers = Enum.GetValues(typeof(ComputerManufacturer));
            var osTypes = Enum.GetValues(typeof(OSType));
            // Получение элемента по индексу + преведение object
            CpuType proc = (CpuType)processorTypes.GetValue(rnd.Next(processorTypes.Length));
            ComputerManufacturer manuf = (ComputerManufacturer)manufacturers.GetValue(rnd.Next(manufacturers.Length));
            OSType os = (OSType)osTypes.GetValue(rnd.Next(osTypes.Length));
            
            // получение рандом значений Тактовой частоты процессов и Объёма оперативной памяти
            int clockSpeed = rnd.Next(1500, 5001);       // 1.5 - 5.0 ГГц
            int ram = rnd.Next(4, 65);                   // 4 - 64 ГБ

            // Случайное ПО
            string[] softwarePool = { "Word", "Excel", "Chrome", "Microsoft VS", "Photoshop", "Telegram", "Skype", "Zoom", "Spotify" }; // Определение пула программ
            int swCount = rnd.Next(1, 6); // Определение случайного количества программ
            List<string> software = new List<string>();
            for (int i = 0; i < swCount; i++)
                software.Add(softwarePool[rnd.Next(softwarePool.Length)]); //добавление выбранной программы

            // Случайные пользователи
            // аналогично ПО
            string[] userPool = { "Nikita", "Vasan", "Papich", "Diana", "Eve", "Frank", "Grace", "Henry", "Alice", "Jack" };
            int userCount = rnd.Next(1, 5);
            List<string> users = new List<string>();
            for (int i = 0; i < userCount; i++)
                users.Add(userPool[rnd.Next(userPool.Length)]);

            return new Computer(proc, manuf, os, clockSpeed, ram, software, users); // новый экземпляр класса Computer
        }

        // Генерация 100 экземпляров
        public static List<Computer> Generate100()
        {
            Random rnd = new Random();
            List<Computer> list = new List<Computer>();
            for (int i = 0; i < 100; i++)
                list.Add(Generate(rnd));
            return list;
        }

        // для вывода в консоль
        public override string ToString()
        {
            return $"{Manufacturer} {ProcessorType} {OperatingSystem} {ClockSpeed}MHz RAM:{RamSize}GB Users:{Users.Count} SW:{InstalledSoftware.Count}";
        }

        // Делегат для события добавления пользователя
        public delegate void UserAddedEventHandler(object sender, string userName);

        // Делегат для события замены процессора
        public delegate void ProcessorChangedEventHandler(object sender, CpuType oldProcessor, int oldClockSpeed, CpuType newProcessor, int newClockSpeed);

        // Делегат для события установки ПО
        public delegate void SoftwareInstalledEventHandler(object sender, string softwareName);

        // Делегат для события замены оперативной памяти
        public delegate void RamUpgradedEventHandler(object sender, int oldRamSize, int newRamSize);

        // Поля для хранения списков обработчиков (для реализации с add/remove)
        private UserAddedEventHandler _userAddedHandlers;
        private ProcessorChangedEventHandler _processorChangedHandlers;
        private SoftwareInstalledEventHandler _softwareInstalledHandlers;
        private RamUpgradedEventHandler _ramUpgradedHandlers;

        // Событие добавления пользователя с явными add/remove (что происходит при подписке и отписке обработчиков)
        public event UserAddedEventHandler UserAdded
        {
            add { _userAddedHandlers += value; } //поле-делегат
            remove { _userAddedHandlers -= value; }  ////поле-делегат
        }

        // Событие замены процессора
        public event ProcessorChangedEventHandler ProcessorChanged
        {
            add { _processorChangedHandlers += value; }
            remove { _processorChangedHandlers -= value; }
        }

        // Событие установки ПО
        public event SoftwareInstalledEventHandler SoftwareInstalled
        {
            add { _softwareInstalledHandlers += value; }
            remove { _softwareInstalledHandlers -= value; }
        }

        // Событие замены оперативной памяти
        public event RamUpgradedEventHandler RamUpgraded
        {
            add { _ramUpgradedHandlers += value; }
            remove { _ramUpgradedHandlers -= value; }
        }

        // методы-триггеры для безопасного вызова событий
        protected virtual void OnUserAdded(string userName)
        {
            // Вызов всех подписанных обработчиков через приватное поле-делегат
            _userAddedHandlers?.Invoke(this, userName);
        }

        protected virtual void OnProcessorChanged(CpuType oldProcessor, int oldClockSpeed, CpuType newProcessor, int newClockSpeed)
        {
            // Вызов всех подписанных обработчиков через приватное поле-делегат
            _processorChangedHandlers?.Invoke(this, oldProcessor, oldClockSpeed, newProcessor, newClockSpeed);
        }
        protected virtual void OnSoftwareInstalled(string softwareName)
        {
            // Вызов всех подписанных обработчиков через приватное поле-делегат
            _softwareInstalledHandlers?.Invoke(this, softwareName);
        }

        protected virtual void OnRamUpgraded(int oldRamSize, int newRamSize)
        {
            // Вызов всех подписанных обработчиков через приватное поле-делегат
            _ramUpgradedHandlers?.Invoke(this, oldRamSize, newRamSize);
        }


        /// <summary>
        /// Добавление нового пользователя.
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        public void AddUser(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Имя пользователя не может быть пустым.");

            Users.Add(userName);
            // Генерация события
            OnUserAdded(userName);
        }

        /// <summary>
        /// Замена процессора.
        /// </summary>
        /// <param name="newProcessorType">Новый тип процессора.</param>
        /// <param name="newClockSpeed">Новая тактовая частота.</param>
        public void ChangeProcessor(CpuType newProcessorType, int newClockSpeed)
        {
            CpuType oldProcessorType = ProcessorType;
            int oldClockSpeed = ClockSpeed;

            ProcessorType = newProcessorType;
            ClockSpeed = newClockSpeed;
            // Генерация события
            OnProcessorChanged(oldProcessorType, oldClockSpeed, newProcessorType, newClockSpeed);
        }

        /// <summary>
        /// Установка нового ПО.
        /// </summary>
        /// <param name="softwareName">Название программы.</param>
        public void InstallSoftware(string softwareName)
        {
            if (string.IsNullOrWhiteSpace(softwareName))
                throw new ArgumentException("Название ПО не может быть пустым.");

            InstalledSoftware.Add(softwareName);
            // Генерация события
            OnSoftwareInstalled(softwareName);
        }

        /// <summary>
        /// Замена оперативной памяти.
        /// </summary>
        /// <param name="newRamSize">Новый объём RAM (в ГБ).</param>
        public void UpgradeRam(int newRamSize)
        {
            if (newRamSize <= 0)
                throw new ArgumentException("Объём RAM должен быть положительным.");

            int oldRamSize = RamSize;
            RamSize = newRamSize;
            // Генерация события
            OnRamUpgraded(oldRamSize, newRamSize);
        }

        /// <summary>
        /// реализация ICloneable
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {

            // 1. Поверхностная копия (копирует все поля – значимые типы и ссылки)
            Computer copy = (Computer)this.MemberwiseClone();

            // 2. Глубокое копирование списков – создаём новые List<string>,
            //    копируя элементы из оригинальных списков
            copy.InstalledSoftware = new List<string>(this.InstalledSoftware);
            copy.Users = new List<string>(this.Users);

            // 3. Возвращаем клон
            return copy;
        }
    }

}
