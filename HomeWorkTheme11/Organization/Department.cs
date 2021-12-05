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
        private int salaryDepartment;
        public int SalaryDepartment { get
            {
                salaryDepartment = 0;
                foreach (var w in Workers)
                {
                    salaryDepartment += w.Salary;
                }
                foreach (var i in Interns)
                {
                    salaryDepartment += i.Salary;
                }
                if (Departments != null)
                {
                    foreach (var dep in Departments)
                    {
                        salaryDepartment += dep.salaryDepartment;
                    }
                }
                return salaryDepartment;
            }
            set
            {
                salaryDepartment = value;
            }
        }
        public ObservableCollection<Department> Departments { get; set; }
        public Boss DepartmentBoss { get; set; }
        private Random Random;

        public Department()
        { }

        public Department(string Name)
        {
            this.Name = Name;
            Workers = new ObservableCollection<Worker>();
            Interns = new ObservableCollection<Intern>();
            Random = new Random();
            var count = Random.Next(5);
            for (int i = 0; i < count; i++)
            {
                Workers.Add(new Worker($"FirstNameWorker{Name}{i}", $"LastName{i}", 30 + i, 1000, "Worker", Name));
            }
            for (int i = 0; i < count; i++)
            {
                Interns.Add(new Intern($"FirstNameIntern{Name}{i}", $"LastName{i}", 20 + i, 500, "Intern", Name));
            }
            this.DepartmentBoss = new Boss($"Boss{Name}", "LastName", 30, SalaryDepartment, "Boss", Name);
        }
        public Department(string Name, ObservableCollection<Department> departments)
        {
            this.Departments = departments;
            this.Name = Name;
            Workers = new ObservableCollection<Worker>();
            Interns = new ObservableCollection<Intern>();
            Random = new Random();
            var count = Random.Next(5);
            for (int i = 0; i < count; i++)
            {
                Workers.Add(new Worker($"FirstNameWorker{Name}{i}", $"LastName{i}", 30 + i, 1000, "Worker", Name));
            }
            for (int i = 0; i < count; i++)
            {
                Interns.Add(new Intern($"FirstNameIntern{Name}{i}", $"LastName{i}", 20 + i, 500, "Intern", Name));
            }
            this.DepartmentBoss = new Boss($"Boss{Name}", "LastName", 30, SalaryDepartment, "Boss", Name);
        }
        public Department(string Name, 
            ObservableCollection<Department> departments,
            ObservableCollection<Worker> Workers,
            ObservableCollection<Intern> Interns,
            Boss Boss,
            int SalaryDepartment
            )
        {
            this.Departments = departments;
            this.Name = Name;
            this.Workers = new ObservableCollection<Worker>();
            this.Interns = new ObservableCollection<Intern>();
            foreach (var elem in Workers)
                Workers.Add(elem);
            foreach (var elem in Interns)
                Interns.Add(elem);
            this.DepartmentBoss = new Boss(Boss);
        }
        public void AddDepartment(Department department)
        {
            if (Departments == null)
                Departments = new ObservableCollection<Department>();
            Departments.Add(department);
            DepartmentBoss.Salary = SalaryDepartment * 15 / 100;
        }

    }
}
