using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Intern : Worker
    {
        protected Intern(
            string FirstName, 
            string LastName, 
            int Age, 
            string Position,
            string NameDepartment) 
            : base(FirstName, LastName, Age, Position, NameDepartment)
        {
        }
        static public new Intern Create(string FirstName,
            string LastName,
            int Age,
            string Position,
            string NameDepartment, int Salary)
        {
            Intern intern = new Intern(FirstName, LastName, Age, Position, NameDepartment);
            intern.Salary = Salary;
            return intern;
        }
    }
}
