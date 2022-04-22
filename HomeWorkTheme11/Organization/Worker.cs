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
        protected Worker
            (
            string FirstName, 
            string LastName, 
            int Age, 
            string Position,
            string NameDepartment 
            )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NameDepartment = NameDepartment;
            this.Age = Age;
            this.Position = Position;
        }
        static public Worker Create(string FirstName, 
            string LastName, 
            int Age,
            string Position,
            string NameDepartment, int Salary)
        {
            Worker worker = new Worker(FirstName, LastName, Age, Position, NameDepartment);
            worker.Salary = Salary;
            return worker;
        }
    }
}
