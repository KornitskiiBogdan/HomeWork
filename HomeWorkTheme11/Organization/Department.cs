using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HomeWorkTheme11.Organization
{
    internal class Department
    {
        public string Name { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }
        public ObservableCollection<Intern> Interns { get; set; }
        public int SalaryDepartment { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        private Random Random;
        public Department(ObservableCollection<Worker> Workers, string Name)
        {
            this.Name = Name;
            Workers = new ObservableCollection<Worker>();
            foreach (var elem in Workers)
            {
                this.Workers.Add(elem);
            }
        }
        public Department(string Name)
        {
            this.Name = Name;

            Workers = new ObservableCollection<Worker>();
            Interns = new ObservableCollection<Intern>();
            Random = new Random();
            var count = Random.Next(5);
            for(int i = 0; i < count; i++)
            {
                Workers.Add(new Worker($"FirstNameWorker{Name}{i}", $"LastName{i}", 30 + i, (i + 1) * 10, "Worker", Name));
            }
            for (int i = 0; i < count; i++)
            {
                Interns.Add(new Intern($"FirstNameIntern{Name}{i}", $"LastName{i}", 20 + i, 500, "Intern", Name));
            }
        }
        public void AddDepartment(Department department)
        {
            if (Departments == null)
                Departments = new ObservableCollection<Department>();
            Departments.Add(department);
        }

    }
}
