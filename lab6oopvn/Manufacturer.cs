using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    internal class Manufacturer : IManufacturer
    {
        // реализация интерфейса
        public string Name { get; set; }
        public Country Country { get; set; }
        public int EmployeesCount { get; set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Manufacturer() { }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="employeesCount"></param>
        public Manufacturer(string name, Country country, int employeesCount)
        {
            Name = name;
            Country = country;
            EmployeesCount = employeesCount;
        }
        //public override string ToString() => $"{Name} ({Country}) - {EmployeesCount} сотрудников";
    }
}
