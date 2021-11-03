using System;
using System.IO;
using System.Collections.Generic;

namespace HomeWorkTheme8
{
    class Program
    {
        static string OutpathXml = Directory.GetCurrentDirectory() + "\\output.xml";
        static string OutpathJson = Directory.GetCurrentDirectory() + "\\output.json";
        /// <summary>
        /// Получить команды для приложения
        /// </summary>
        static private void GetCommand()
        {
            Console.WriteLine("Нажмите соответствующую кнопку для выбора метода:");
            Console.WriteLine("Добавление рабочего - 1");
            Console.WriteLine("Удаление рабочего - 2");
            Console.WriteLine("Редактирование рабочего - 3");
            Console.WriteLine("Сортировка- 4");
            Console.WriteLine("Выгрузить данные - 5");
            Console.WriteLine("Любая другая кнопка прекратит работу");
        }
        /// <summary>
        /// Получить номер изменяемого департамента
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        static private int GetImportNumberDepartament(Organization organization)
        {
            Console.WriteLine("Введите номер департамента, начиная с 1");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Введите корректный тип");
                while (result <= organization.Count && result > organization.Count)
                    Console.WriteLine($"Введите номер департамента начиная с 1 до {organization.Count}");
            }
            return result;
        }
        /// <summary>
        /// фукнционал приложения
        /// </summary>
        /// <param name="diary"></param>
        /// <returns></returns>
        static private bool Functional(Organization organization)
        {

            char key = Console.ReadKey(true).KeyChar;
            int index;
            switch (char.ToLower(key))
            {
                case '1':
                    int number = GetImportNumberDepartament(organization);
                    Worker worker = ImportWorker();
                    if (organization[number - 1].CheckWorkerInList(worker))
                        Console.WriteLine("Данный рабочий уже существует в этом департаменте");
                    else
                    {
                        worker.NameDepartament = organization[number - 1].Name;
                        organization[number - 1].AddWorker(worker);
                        Console.WriteLine("Организация после применения операции");
                        organization.Print();
                    }
                    return true;
                case '2':
                    number = GetImportNumberDepartament(organization);
                    Console.WriteLine("\nВведите номер удаляемого рабочего, начиная с единицы:");
                    while (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("\nВведите корректный тип");
                        while (true)
                        {
                            if (organization[number - 1].Count >= index && organization[number - 1].Count < index)
                            {
                                Console.WriteLine($"\nПрежде чем удалить запись под таким номером, " +
                                    $"нужно создать такое количество записей");
                                break;
                            }
                        }
                    }
                    organization[number - 1].DeleteWorker(index - 1);
                    organization.Print();
                    return true;
                case '3':
                    number = GetImportNumberDepartament(organization);
                    Console.WriteLine("\nВведите номер редактируемого рабочего, начиная с единицы:");
                    while (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("\nВведите корректный тип");
                        while (true)
                        {
                            if (organization[number - 1].Count >= index && organization[number - 1].Count < index)
                            {
                                Console.WriteLine($"\nПрежде чем редактировать рабочего под таким номером, " +
                                    $"нужно создать такое количество рабочих");
                            }
                            else
                                break;
                        }
                    }
                    Console.WriteLine("\nХотите перенести рабочего из одного департамента в другой д/любая клавиша?");
                    key = Console.ReadKey(true).KeyChar;
                    if (char.ToLower(key) == 'д')
                    {
                        int newNumber = GetImportNumberDepartament(organization);
                        organization[number - 1].EditWorker(ImportWorker(), organization[newNumber - 1]);
                    }
                    else
                        organization[number].EditWorker(organization[number][index], ImportWorker());
                    organization.Print();
                    return true;
                case '4':
                    {
                        char keySort;
                        Console.WriteLine("\nНажмите кнопку для выбора сортировки: з - по зарплате, в - по возрасту, о - по обоим параметрам ");
                        while (true)
                        {
                            keySort = Console.ReadKey(true).KeyChar;
                            if (char.ToLower(keySort) == 'з')
                            {
                                Console.WriteLine("\nХотите сортировать по возрастанию д/н?");
                                while (true)
                                {
                                    keySort = Console.ReadKey(true).KeyChar;
                                    if (char.ToLower(keySort) == 'д')
                                    {
                                        number = GetImportNumberDepartament(organization);
                                        organization[number - 1].SortAscendingSalary();
                                        organization.Print();
                                        break;
                                    }
                                    else if (char.ToLower(keySort) == 'н')
                                    {
                                        number = GetImportNumberDepartament(organization);
                                        organization[number - 1].SortDescendingSalary();
                                        organization.Print();
                                        break;
                                    }
                                    else
                                        Console.WriteLine("\nНажмите корректную клавишу");
                                }
                                break;
                            }
                            else if (char.ToLower(keySort) == 'в')
                            {
                                Console.WriteLine("\nХотите сортировать по возрастанию д/н?");
                                while (true)
                                {
                                    keySort = Console.ReadKey(true).KeyChar;
                                    if (char.ToLower(keySort) == 'д')
                                    {
                                        number = GetImportNumberDepartament(organization);
                                        organization[number - 1].SortAscendingAge();
                                        organization.Print();
                                        break;
                                    }
                                    else if (char.ToLower(keySort) == 'н')
                                    {
                                        number = GetImportNumberDepartament(organization);
                                        organization[number - 1].SortDescendingAge();
                                        organization.Print();
                                        break;
                                    }
                                    else
                                        Console.WriteLine("\nНажмите корректную клавишу");
                                }
                                break;
                            }
                            else if (char.ToLower(keySort) == 'о')
                            {
                                Console.WriteLine("\nХотите сортировать по возрастанию д/н?");
                                while (true)
                                {
                                    keySort = Console.ReadKey(true).KeyChar;
                                    if (char.ToLower(keySort) == 'д')
                                    {
                                        number = GetImportNumberDepartament(organization);
                                        organization[number - 1].SortAscendingSalaryAndAge();
                                        organization.Print();
                                        break;
                                    }
                                    else if (char.ToLower(keySort) == 'н')
                                    {
                                        number = GetImportNumberDepartament(organization);
                                        organization[number - 1].SortDescendingSalaryAndAge();
                                        organization.Print();
                                        break;
                                    }
                                    else
                                        Console.WriteLine("\nНажмите корректную клавишу");
                                }
                                break;
                            }
                            else
                                Console.WriteLine("\nНажмите корректную кнопку");
                        }
                        return true;
                    }
                case '5':
                    Console.WriteLine("\nНажмите кнопку для выбора сериализации данных: x - Xml, j - Json");
                    while (true)
                    {
                        key = Console.ReadKey(true).KeyChar;
                        if (char.ToLower(key) == 'x' || char.ToLower(key) == 'х')
                        {
                            SerializeDeserialize.SerializeXml(organization, OutpathXml);
                            break;
                        }
                        else if (char.ToLower(key) == 'j')
                        {
                            SerializeDeserialize.SerializeJson(organization, OutpathJson);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nНажмите корректную клавишу");
                        }
                    }
                    return true;
                default:
                    return false;
            }

        }
        /// <summary>
        /// загрузить рабочего
        /// </summary>
        /// <returns></returns>
        static private Worker ImportWorker()
        {
            string firstName;
            string lastName;
            int age;
            int salary;
            int numOfProject;
            Console.WriteLine("Введите имя сотрудника: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Введите фамилию сотрудника: ");
            lastName = Console.ReadLine();

            Console.WriteLine("Введите возраст сотрудника: ");
            while (!int.TryParse(Console.ReadLine(), out age))
                Console.WriteLine("Введите возраст в корректном формате");

            Console.WriteLine("Введите зарплату сотрудника: ");
            while (!int.TryParse(Console.ReadLine(), out salary))
                Console.WriteLine("Введите зарплату в корректном формате");

            Console.WriteLine("Введите количество проектов над которыми трудится сотрудник: ");
            while (!int.TryParse(Console.ReadLine(), out numOfProject))
                Console.WriteLine("Введите количество проектов в корректном формате");

            return new Worker(firstName, lastName, age, salary, numOfProject);
        }
        /// <summary>
        /// Получить стартовые данные
        /// </summary>
        /// <param name="maxCountWorker"></param>
        /// <returns></returns>
        static private Organization GetStartDate(int maxCountWorker)
        {
            Organization organization;
            Console.WriteLine("Хотите загрузить данные из файла д/н? Любая другая клавиша приведет программу к завершению работы");
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                if (char.ToLower(key) == 'д')
                {
                    Console.WriteLine("\nНажмите кнопку для выбора десериализации данных: x - Xml, j - Json");
                    while (true)
                    {
                        key = Console.ReadKey(true).KeyChar;
                        if (char.ToLower(key) == 'x' || char.ToLower(key) == 'х')
                        {
                            organization = SerializeDeserialize.DeserializeXml(OutpathXml);
                            break;
                        }
                        else if (char.ToLower(key) == 'j')
                        {
                            organization = SerializeDeserialize.DeserializeJson(OutpathJson);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nНажмите корректную клавишу");
                        }
                    }

                    break;
                }
                else if (char.ToLower(key) == 'н')
                {
                    organization = RandomInputData(maxCountWorker);
                    break;
                }
                else
                {
                    Console.WriteLine("Данные не выбраны попробуйте ещё раз");
                }
            }
            return organization;
        }
        /// <summary>
        /// получение входных данных
        /// </summary>
        /// <returns></returns>
        static private Organization RandomInputData(int maxCountWorker)
        {
            
            Random random = new Random();
            int numberDepartament = 3;
            Organization organization;
            List<Department> departments = new List<Department>();
            for (int i = 0; i < numberDepartament; i++)
            {
                int numberWorker = random.Next(maxCountWorker);
                
                List<Worker> workers = new List<Worker>();
                for (int j = 0; j < numberWorker; j++)
                {
                    Worker worker = new Worker(
                        $"Имя_{i + 1}_{j + 1}", 
                        $"Фамилия_{i + 1}_{j + 1}", 
                        random.Next(30, 50), 
                        random.Next(1, 20) * 10000,
                        random.Next(3));
                    workers.Add(worker);
                }
                Department department = new Department(workers, $"Отдел{i + 1}", DateTime.Parse("27-10-2021"));
                departments.Add(department);
            }
            organization = new Organization(departments);
            return organization;
        }
        static void Main(string[] args)
        {
            int maxCountWorker = 20;
            Organization organization = GetStartDate(maxCountWorker);
            organization.Print();
            GetCommand();
            while (Functional(organization))
                Console.WriteLine("Введите номер следующей операции");
              
        }
    }
}

/// Создать прототип информационной системы, в которой есть возможность работать со структурой организации
/// В структуре присутствуют департаменты и сотрудники
/// Каждый департамент может содержать не более 1_000_000 сотрудников.
/// У каждого департамента есть поля: наименование, дата создания,
/// количество сотрудников числящихся в нём 
/// (можно добавить свои пожелания)
/// 
/// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
/// уникальный номер, размер оплаты труда, количество проектов закрепленным за ним.
///
/// В данной информаиционной системе должна быть возможность 
/// - импорта и экспорта всей информации в xml и json
/// Добавление, удаление, редактирование сотрудников и департаментов
/// 
/// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
/// по нескольким полям, например возрасту и оплате труда
/// 
///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
/// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
/// 
/// 
/// Упорядочивание по одному полю возраст
/// 
///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
/// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
/// 
///
/// Упорядочивание по полям возраст и оплате труда
/// 
///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
/// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
/// 
/// 
/// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
/// 
///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
/// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
/// 