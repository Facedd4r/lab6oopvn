using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace lab6oopvn
{
    public delegate double MyDel(int[] a);
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine(ClassDelegate.avgResult(arr));

            Computer pc = new Computer();

            // Подписки на события
            pc.UserAdded += (sender, userName) => Console.WriteLine($"Добавлен пользователь: {userName}");
            pc.ProcessorChanged += (sender, oldProc, oldSpeed, newProc, newSpeed) =>
            Console.WriteLine($"Процессор заменён: {oldProc}|{oldSpeed} МГц -> {newProc}|{newSpeed} МГц");
            pc.SoftwareInstalled += (sender, sw) => Console.WriteLine($"Установлено ПО: {sw}");
            pc.RamUpgraded += (sender, oldRam, newRam) => Console.WriteLine($"RAM увеличена: {oldRam} ГБ -> {newRam} ГБ");

            // Действия, вызывающие события
            pc.AddUser("Alice");
            pc.ChangeProcessor(CpuType.X64, 4200);
            pc.InstallSoftware("Visual Studio");
            pc.UpgradeRam(32);
        }
    }
}
