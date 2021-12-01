using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Boss : Worker
    {
        public Boss(
           string FirstName,
           string LastName,
           int Age,
           int SalaryDepartment,
           string Position,
           string NameDepartment)
           : base(FirstName, LastName, Age, SalaryDepartment, Position, NameDepartment)
        {
            this.Salary = SalaryDepartment * 15 /100;
        }
    }
}
