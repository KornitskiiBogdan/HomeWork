using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HomeWorkTheme8
{
    public class Organization
    {
        public Department this[int index]
        {
            get { return Departments[index]; }
        }
        public int Count { get { return Departments.Count; }}
        static public int IDWorker = 1;
        public List<Department> Departments { get; set; }
        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="Departments"></param>
        public Organization(List<Department> Departments)
        {
            this.Departments = new List<Department>();
            foreach (var elem in Departments)
            {
                this.Departments.Add(elem);
            }
        }
        
        public Organization() { }
        /// <summary>
        /// Печать
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{"ID", 2}\t{"Имя", 10}\t{"Фамилия",20}\t{"Возраст",3}\t{"Департамент",11}\t{"Оплата Труда",12}{"Количество проектов", 20}");
            foreach(var dep in Departments)
            {
                foreach(var elem in dep.Workers)
                {
                    Console.WriteLine($"{elem.ID, 2}\t{elem.FirstName, 10}\t{elem.LastName, 20}\t{elem.Age, 3}\t{elem.NameDepartament, 11}\t{elem.Salary, 12}{elem.NumOfProject, 20}");
                }
            }
        }
    }
}
