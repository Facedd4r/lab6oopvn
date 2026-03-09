using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    internal interface IManufacturer
    {
        /// <summary>
        /// название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        Country Country { get; set; }

        /// <summary>
        /// кол-во сотрудников
        /// </summary>
        int EmployeesCount { get; set; }
    }
}
