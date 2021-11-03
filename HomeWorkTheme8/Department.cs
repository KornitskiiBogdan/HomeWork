using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HomeWorkTheme8
{
    public class Department
    {
        public Worker this[int index]
        {
            get { return this.Workers[index]; }
        }
        public int Count { get { return Workers.Count; } }
        public List<Worker> Workers { get; private set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public Department(
            List<Worker> Workers,
            string Name,
            DateTime DateCreate
            )
        {
            this.Workers = new List<Worker>();
            this.Name = Name;
            for(int i = 0; i < Workers.Count; ++i)
            {
                this.Workers.Add(Workers[i]);
                Workers[i].NameDepartament = Name;
            }
            this.DateCreate = DateCreate;
        }
        /// <summary>
        /// Удаление рабочего по индексу
        /// </summary>
        /// <param name="index"></param>
        public void DeleteWorker(int index)
        {
            Workers.RemoveAt(index);
        }
        /// <summary>
        /// Добавление рабочего
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }
        /// <summary>
        /// Редактирование рабочего
        /// </summary>
        /// <param name="workerOld"></param>
        /// <param name="workerNew"></param>
        public void EditWorker(Worker workerOld, Worker workerNew)
        {
            workerOld.FirstName = workerNew.FirstName;
            workerOld.LastName = workerNew.LastName;
            workerOld.Salary = workerNew.Salary;
            workerOld.Age = workerNew.Age;
        }
        /// <summary>
        /// редактирование рабочего, если нужно его перенести из одного департамента в другой
        /// </summary>
        /// <param name="workerOld"></param>
        /// <param name="workerNew"></param>
        /// <param name="departmentNew"></param>
        public void EditWorker(Worker worker, Department departmentNew)
        {
            Workers.Remove(worker);
            departmentNew.AddWorker(worker);
            worker.ID = departmentNew.Count;
        }
        /// <summary>
        /// проверка, есть ли рабочик в базе данных
        /// </summary>
        /// <returns></returns>
        public bool CheckWorkerInList(Worker worker)
        {
            foreach(var elem in Workers)
            {
                if (elem.FirstName == worker.FirstName &&
                    elem.LastName == worker.LastName &&
                    elem.Age == worker.Age)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Сортировка в порядке убывании зарплаты
        /// </summary>
        public void SortDescendingSalary()
        {
            var sortedWorker = Workers.OrderByDescending(w => w.Salary).ToList();
            Workers = sortedWorker;
        }
        /// <summary>
        /// Сортировка в порядке возрастании зарплаты
        /// </summary>
        public void SortAscendingSalary()
        {
            var sortedWorker = Workers.OrderBy(w => w.Salary).ToList();
            Workers = sortedWorker;

        }
        /// <summary>
        /// Сортировка в порядке убывании возраста
        /// </summary>
        public void SortDescendingAge()
        {
            var sortedWorker = Workers.OrderByDescending(w => w.Age).ToList();
            Workers = sortedWorker;
        }
        /// <summary>
        /// Сортировка в порядке возрастании возраста
        /// </summary>
        public void SortAscendingAge()
        {
            var sortedWorker = Workers.OrderBy(w => w.Age).ToList();
            Workers = sortedWorker;
        }
        /// <summary>
        /// Сортировка в порядке убывания и возраста и зарплаты
        /// </summary>
        public void SortDescendingSalaryAndAge()
        {
            var sortedWorker = Workers.OrderByDescending(w => w.Salary).ThenByDescending(w => w.Age).ToList();
            Workers = sortedWorker;
        }
        /// <summary>
        /// Сортировка в порядке возрастания возраста и зарплаты
        /// </summary>
        public void SortAscendingSalaryAndAge()
        {
            var sortedWorker = Workers.OrderBy(w => w.Salary).ThenBy(w => w.Age).ToList();
            Workers = sortedWorker;
        }

    }
}
