using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    /// <summary>
    /// интерфейс IComputer
    /// </summary>
    internal interface IComputer
    {
        /// <summary>
        /// Тип процессора 
        /// </summary>
        /// 
        CpuType ProcessorType { get; set; }

        /// <summary>
        /// Название производителя
        /// </summary>
        /// 
        ComputerManufacturer Manufacturer { get; set; }

        /// <summary>
        /// Тип операционной системы 
        /// </summary>
        OSType OperatingSystem { get; set; }
        
        /// <summary>
        /// Тактовая частота процессов 
        /// </summary>
        int ClockSpeed { get; set; }
        
        /// <summary>
        /// Объём оперативной памяти 
        /// </summary>
        int RamSize { get; set; }
        
        /// <summary>
        /// Установленное ПО 
        /// </summary>
        List<string> InstalledSoftware { get; set; }
        
        /// <summary>
        /// Пользователи системы 
        /// </summary>
        List<string> Users { get; set; }
    }
}
