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
        public string DepartmentName { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }
        public int SalaryDepartment { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public Department(ObservableCollection<Worker> Workers, string Name)
        {
            this.DepartmentName = Name;
            foreach (var elem in Workers)
            {
                this.Workers.Add(elem);
            }
        }
        public Department(string Name)
        {
            this.DepartmentName = Name;
        }
        public void AddDepartment(Department department)
        {
            if (Departments == null)
                Departments = new ObservableCollection<Department>();
            Departments.Add(department);
        }
        public override string ToString()
        {
            return DepartmentName;
        }
    }
}
