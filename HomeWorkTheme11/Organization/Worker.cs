using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameDepartment { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public Worker
            (
            string FirstName, 
            string LastName, 
            int Age, 
            int Salary, 
            string Position,
            string NameDepartment 
            )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NameDepartment = NameDepartment;
            this.Age = Age;
            this.Salary = Salary;
            this.Position = Position;
        }

    }
}
