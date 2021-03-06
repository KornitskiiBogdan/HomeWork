using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Company
    {
        public string CompanyName { get; private set; }
        public ObservableCollection<Department> Departments { get; set; }
        public Boss Boss { get; set; }
        public Boss DeputyBoss { get; set; }

        private Random randomize;
        public void UpdateSalary()
        {
            foreach(var deparment in Departments)
            {

            }
        }
        public Company(List<Department> Departments, string Name, Boss Boss, Boss DeputyBoss)
        {
            this.CompanyName = Name;
            this.Departments = new ObservableCollection<Department>();
            foreach (var departament in Departments)
            {
                this.Departments.Add(departament);
            }
            this.Boss = Boss;
            this.DeputyBoss = DeputyBoss;
        }
        public Company()
        {
            //randomize = new Random();

            //int countDepartment = randomize.Next(10);

            //this.CompanyName = "Example";
            //this.Departments = new ObservableCollection<Department>();
            //for(int i = 0; i < countDepartment; i++)
            //{
            //    Departments.Add(new Department($"departament{i}"));
                
            //}

            //int salary = 0;
            //foreach (var dp in Departments)
            //{
            //    salary += dp.SalaryDepartment;
            //}

            //DeputyBoss = new Boss("DeputyBoss", "LastNameDeputyBoss", 35, salary, "Заместитель", CompanyName);
            
            //Boss = new Boss("Boss", "LastName", 40, salary + salary / 100 * 15, "boss", CompanyName);
        }

    }
}
// Задание 1.
// Спроектировать информационную систему позволяющей работать со следующей структурой:
// Организация, в которой есть департаменты и сотрудники.
// Наполнение деталями предлагается реализовать самостоятельно
// Наполнение сотрудниками и департаментами происходит автоматически из файла *.txt, 
//                                                           предпочтительнее *.xml или *.json 
//
// Сотрудники делятся на несколько групп, разделенных должностями и оплатой труда
// Есть 
//   сотрудники - управленцы (например: директор, Первй заместитель директора, начальник ведомства, 
//                                      начальник департамента)
// 
//   ОАО "Лучшие кодеры"
//       Департамент_1
//          Департамент_11
//          Департамент_12
//       Департамент_2
//          Департамент_21
//          Департамент_22
//          Департамент_23
//          Департамент_24
//       Департамент_3
//          Департамент_31
//       Департамент_4
//          Департамент_41
//          Департамент_42
//          Департамент_43
//          Департамент_44
//          Департамент_45
//          Департамент_46
//          Департамент_47
//          Департамент_48
//       Департамент_5                Начальник_5
//          Департамент_51            Начальник_51
//              Департамент_511       Начальник_511
//                  Департамент_5111  Начальник_5111
//                        Департамент_51111      Начальник_51111
//                              Сотрудник 1
//                              Сотрудник 2
//                              Сотрудник 3
//                              Интерн 1
//                              Интерн 2
//                        Департамент_51112
//                        Департамент_51113
//                        Департамент_51114
//                  Департамент_5112
//                  Департамент_5113
//              Департамент_512
//          Департамент_52
//              Департамент_521
//              Департамент_522
//              Департамент_523
//          Департамент_53
//              Департамент_531
//          Департамент_54

//   сотрудники - рабочие
//   интерны
// У интернов оплата труда фиксированная и определяется при приёме (например $500 в месяц)
// У сотрудников - рабочих оплата труда почасовая и определяется при приёме (например $12 в час)
// У сотрудников - управленцев оплата труда составляет 15% от общей выплаченной суммы всем сотрудникам 
// числящихся в его отделе, но не менее $1300. 
//
// Структура организации следующая:
// Организация, состоит из ведомств в которые включены департаменты
// У каждого ведомства и департамента есть свой начальник.
// Директор руководит Организацией
// 
// Реализовать и продемонстрировать работу информационной системы
// В консоли или с использованием UI


// Задание 3.
// 
// Задавать вопросы
//