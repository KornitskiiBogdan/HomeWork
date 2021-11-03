using System;
using System.IO;
namespace HomeWorkTheme7
{
    class Program
    {
        /// <summary>
        /// фукнционал приложения
        /// </summary>
        /// <param name="diary"></param>
        /// <returns></returns>
        static private bool Functional(Diary diary)
        {
            string Outpath = Directory.GetCurrentDirectory() + "\\output.txt";
            string Inpath = Directory.GetCurrentDirectory() + "\\input.txt";
            char key = Console.ReadKey(true).KeyChar;
            int index;
            switch (char.ToLower(key))
            {
                case '1':
                    diary.AddNote(ImportNote());
                    Console.WriteLine("Ежедневник после применения операции");
                    diary.Print();
                    return true;
                case '2':
                    Console.WriteLine("Введите номер удаляемой записки, начиная с нуля:");
                    while (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("Введите корректный тип");
                        
                    }
                    while (true)
                    {
                        if (diary.GetCount() <= index)
                        {
                            Console.WriteLine($"Прежде чем удалить запись под таким номером, " +
                                $"нужно создать такое количество записей");
                            break;
                        }
                        else
                        {
                            diary.DeleteNote(index);
                            diary.Print();
                            break;
                        }
                    }
                    return true;
                case '3':
                    Console.WriteLine("Введите номер редактируемой записки, начиная с нуля:");
                    while (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("Введите корректный тип");
                        while (true)
                        {
                            if (diary.GetCount() <= index)
                            {
                                Console.WriteLine($"Прежде чем редактировать запись под таким номером, " +
                                    $"нужно создать такое количество записей");
                            }
                            else
                                break;
                        }
                    }
                    diary.EditNote(diary[index], ImportNote());
                    diary.Print();
                    return true;
                case '4':
                    diary.ExportData(Outpath);
                    Console.WriteLine("Данные выгружены");
                    return true;
                case '5':
                    Console.WriteLine("Хотите загрузить произвольные данные д/н?");
                    char key_ = Console.ReadKey().KeyChar;
                    while (true)
                    {
                        if (char.ToLower(key_) == 'д')
                        {
                            diary.ImportData(Inpath);
                            break;
                        }
                        else if (char.ToLower(key_) == 'н')
                        {
                            DateTime date1;
                            DateTime date2;
                            Console.WriteLine("Введите диапозон дат в формате гг-мм-дд");
                            while (!DateTime.TryParse(Console.ReadLine(), out date1))
                                Console.WriteLine("Введите дату в корректном формате");
                            Console.WriteLine("Вторая дата:");
                            while (!DateTime.TryParse(Console.ReadLine(), out date2))
                                Console.WriteLine("Введите дату в корректном формате");
                            diary.ImportData(Inpath, date1, date2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Нажата неверная клавиша, попробуйте ещё раз");
                            key_ = Console.ReadKey().KeyChar;
                        }
                    }
                    return true;
                case '6':
                    {
                        char keySort;
                        Console.WriteLine("Нажмите кнопку для выбора сортировки: д - по дате, т - по длине текста ");
                        while (true)
                        {
                            keySort = Console.ReadKey(true).KeyChar;
                            if (char.ToLower(keySort) == 'д')
                            {

                                Console.WriteLine("Хотите сортировать по возрастанию д/н?");
                                while (true)
                                {
                                    keySort = Console.ReadKey(true).KeyChar;
                                    if (char.ToLower(keySort) == 'д')
                                    {
                                        diary.SortAscendingDate();
                                        diary.Print();
                                        break;
                                    }
                                    else if (char.ToLower(keySort) == 'н')
                                    {
                                        diary.SortDescendingDate();
                                        diary.Print();
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Нажмите корректную клавишу");
                                }
                                diary.Print();
                                break;
                            }
                            else if (char.ToLower(keySort) == 'т')
                            {
                                Console.WriteLine("Хотите сортировать по возрастанию д/н?");
                                while (true)
                                {
                                    keySort = Console.ReadKey(true).KeyChar;
                                    if (char.ToLower(keySort) == 'д')
                                    {
                                        diary.SortAscendingLenghtText();
                                        diary.Print();
                                        break;
                                    }
                                    else if (char.ToLower(keySort) == 'н')
                                    {
                                        diary.SortDescendingLenghtText();
                                        diary.Print();
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Нажмите корректную клавишу");
                                }
                                break;
                            }
                            else
                                Console.WriteLine("Нажмите кнопку \"д\" или \"н\"");
                        }
                        return true;
                    }
                default:
                    return false;
            }
            
        }
        /// <summary>
        /// загрузить записку
        /// </summary>
        /// <returns></returns>
        static private Note ImportNote()
        {
            DateTime date;
            string text;
            Console.WriteLine("Введите дату записи в формате гг-мм-дд: ");
            while (!DateTime.TryParse(Console.ReadLine(), out date))
                Console.WriteLine("Введите дату в корректном формате");
            Console.WriteLine("Введите текст заметки:");
            text = Console.ReadLine();
            return new Note(date, text);
        }
        /// <summary>
        /// ввод данных
        /// </summary>
        /// <returns></returns>
        static private Diary InputData()
        {
            Diary diary = new Diary(ImportNote());
            int temp = 0;
            do
            {
                if(temp != 0)
                    diary.AddNote(ImportNote());
                Console.WriteLine("Хотите продолжить д/н?");
                temp++;
            } while (char.ToLower(Console.ReadKey(true).KeyChar) == 'д');
            return diary;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Хотите создать ежедневник вручную д/н?");
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                if (char.ToLower(key) == 'д')
                {
                    Diary diary = InputData();
                    Console.WriteLine("Нажмите соответствующую кнопку для выбора метода:");
                    Console.WriteLine("Добавление записи - 1");
                    Console.WriteLine("Удаление записи - 2");
                    Console.WriteLine("Редактирование записи - 3");
                    Console.WriteLine("Выгрузить данные - 4");
                    Console.WriteLine("Загрузить данные - 5");
                    Console.WriteLine("Сортировка - 6");
                    Console.WriteLine("Любая другая кнопка прекратит работу");
                    while(Functional(diary))
                        Console.WriteLine("Введите номер следующей операции");
                    break;
                }
                else if (char.ToLower(key) == 'н')
                {
                    string Inpath = Directory.GetCurrentDirectory() + "\\input.txt";
                    Diary diary = new Diary(Inpath);
                    diary.Print();
                    Console.WriteLine("Нажмите соответствующую кнопку для выбора метода:");
                    Console.WriteLine("Добавление записи - 1");
                    Console.WriteLine("Удаление записи - 2");
                    Console.WriteLine("Редактирование записи - 3");
                    Console.WriteLine("Выгрузить данные - 4");
                    Console.WriteLine("Загрузить данные - 5");
                    Console.WriteLine("Сортировка - 6");
                    Console.WriteLine("Любая другая кнопка прекратит работу");
                    while(Functional(diary))
                        Console.WriteLine("Введите номер следующей операции");
                    break;
                }
                else
                    Console.WriteLine("Попробуйте ещё раз");
            }
        }
    }
}
/// Разработать ежедневник.
/// В ежедневнике реализовать возможность 
/// - создания
/// - удаления
/// - реактирования 
/// записей
/// 
/// В отдельной записи должно быть не менее пяти полей
/// 
/// Реализовать возможность 
/// - Загрузки даннах из файла
/// - Выгрузки даннах в файл
/// - Добавления данных в текущий ежедневник из выбранного файла
/// - Импорт записей по выбранному диапазону дат
/// - Упорядочивания записей ежедневника по выбранному полю
