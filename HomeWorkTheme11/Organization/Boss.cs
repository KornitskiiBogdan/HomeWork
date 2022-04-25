using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Boss : Worker
    {
        protected Boss(
           string FirstName,
           string LastName,
           int Age,
           string Position,
           string NameDepartment)
           : base(FirstName, LastName, Age, Position, NameDepartment)
        {

        }
        static public Boss CreateBossDepartment(string FirstName,
            string LastName,
            int Age,
            string Position,
            string NameDepartment, Department Department)
        {
            Boss boss = new Boss(FirstName, LastName, Age, Position, NameDepartment);
            boss.Salary += boss.SetSalaryBoss(Department, boss.Salary);
            return boss;
        }
        static public Boss CreateBossCompany(string FirstName,
            string LastName,
            int Age,
            string Position,
            string NameDepartment, Company Company)
        {
            Boss boss = new Boss(FirstName, LastName, Age, Position, NameDepartment);
            foreach(var department in Company.Departments)
            {
                boss.Salary += boss.SetSalaryBoss(department, boss.Salary);
            }
            return boss;
        }
        public int SetSalaryBoss(Department department, int Salary)
        {
            foreach(var item in department.Departments)
            {
                Salary += item.DepartmentBoss.Salary;
                SetSalaryBoss(item, Salary);
            }
            foreach(var worker in department.Workers)
            {
                Salary += worker.Salary;
            }
            foreach (var intern in department.Interns)
            {
                Salary += intern.Salary;
            }
            return Salary * 15 / 100;
        }
    }
}
