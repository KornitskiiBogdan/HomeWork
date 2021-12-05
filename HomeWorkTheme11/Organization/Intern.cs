using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Intern : Worker
    {
        public Intern(
            string FirstName, 
            string LastName, 
            int Age, 
            int Salary,
            string Position,
            string NameDepartment) 
            : base(FirstName, LastName, Age, Salary, Position, NameDepartment)
        {
        }
    }
}
