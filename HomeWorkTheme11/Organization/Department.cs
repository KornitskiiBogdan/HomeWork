using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeWorkTheme11.Organization
{
    internal class Department
    {
        public string Name { get; set; }

        public Boss DepartmentBoss { get; set; }

        public ObservableCollection<Worker> Workers { get; set; }

        public ObservableCollection<Department> Departments { get; set; }
        
        public ObservableCollection<Intern> Interns { get; set; }

        
        private Random Random;

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName] string prop = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //}

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
                Workers.Add(Worker.Create($"FirstNameWorker{Name}{i}", $"LastName{i}", 30 + i, "Worker", Name, 1000));
            }
            for (int i = 0; i < count; i++)
            {
                Interns.Add(Intern.Create($"FirstNameIntern{Name}{i}", $"LastName{i}", 20 + i, "Intern", Name, 500));
            }
            this.DepartmentBoss = Boss.CreateBossDepartment($"Boss{Name}", "LastName", 30, "Boss", Name, this);
        }
        public Department(string Name,
            ObservableCollection<Worker> Workers,
            ObservableCollection<Intern> Interns
            )
        {
            this.Name = Name;
            this.Workers = new ObservableCollection<Worker>();
            this.Interns = new ObservableCollection<Intern>();
            foreach (var elem in Workers)
                Workers.Add(elem);
            foreach (var elem in Interns)
                Interns.Add(elem);
        }
        public Department(string Name,
            ObservableCollection<Department> departments,
            ObservableCollection<Worker> Workers,
            ObservableCollection<Intern> Interns
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
        }
        public void AddDepartment(Department department)
        {
            if (Departments == null)
                Departments = new ObservableCollection<Department>();
            Departments.Add(department);
            this.DepartmentBoss.Salary = DepartmentBoss.SetSalaryBoss(this, 0);
        }

    }
}
