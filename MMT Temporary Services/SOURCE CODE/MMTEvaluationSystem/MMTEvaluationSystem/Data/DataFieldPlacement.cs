using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMTEvaluationSystem
{
    public class DataFieldPlacement
    {
        public int EmployeeNumber { get; private set; }
        public int EmployerNumber { get; private set; }

        /// <summary>
        /// Default constructor for the field placement data structure.
        /// </summary>
        /// <param name="EmployeeNumber">The employee's number.</param>
        /// <param name="EmployerNumber">The employer's number.</param>
        public DataFieldPlacement(int EmployeeNumber, int EmployerNumber)
        {
            this.EmployeeNumber = EmployeeNumber;
            this.EmployerNumber = EmployerNumber;
        }
    }
}
