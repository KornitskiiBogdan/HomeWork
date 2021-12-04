using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HomeWorkTheme11.Organization;

namespace HomeWorkTheme11.ApplicationViewModel
{
    internal class ApplicationViewModel
    {
        public static string Path = $"{Directory.GetCurrentDirectory()}//Data//";
        public Company company;

        public ApplicationViewModel()
        {
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}//Data//");

            company = new Company();

            company.Departments[0].AddDepartment(new Department("Twer12412"));
        }
        
    }
}
