using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Boss : Worker
    {
        private int salary;
        public new int Salary { get { return salary; } 
            set 
            {
                
            } 
        }
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
        public Boss(Boss boss) : base(boss.FirstName, boss.LastName, boss.Age, boss.Salary, boss.Position, boss.NameDepartment)
        {

        }
    }
}
