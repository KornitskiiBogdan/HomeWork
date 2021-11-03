using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkTheme8
{
    public class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameDepartament { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public int Salary { get; set; }
        public int NumOfProject { get; set; }
        public static int valueID = 1;
        /// <summary>
        /// Создание рабочего
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Age"></param>
        /// <param name="Salary"></param>
        /// <param name="NumOfProject"></param>
        public Worker(
            string FirstName, 
            string LastName, 
            int Age, 
            int Salary,
            int NumOfProject)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Salary = Salary;
            this.NumOfProject = NumOfProject;
            ID = valueID;
            valueID++;
        }

    }
}
