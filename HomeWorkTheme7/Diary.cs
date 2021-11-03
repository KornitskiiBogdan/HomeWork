using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeWorkTheme7
{
    struct Diary
    {
        private List<Note> Notes;
        
        public Note this[int index]
        {
            get { return this.Notes[index]; }
        }
        /// <summary>
        ///  Получить количество записей
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Notes.Count;
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="index"></param>
        public void DeleteNote(int index)
        {
            Notes.RemoveAt(index);
        }
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(Note note)
        {
            Notes.Add(note);
        }
        /// <summary>
        /// Редактирование заметки
        /// </summary>
        /// <param name="note"></param>
        /// <param name="Text"></param>
        public void EditNote(Note note, DateTime Date, string Text)
        {
            note.Date = Date;
            note.Text = Text;
        }
        /// <summary>
        /// Редактирование заметки
        /// </summary>
        /// <param name="note"></param>
        /// <param name="Text"></param>
        public void EditNote(Note noteOld, Note noteNew)
        {
            noteOld.Date = noteNew.Date;
            noteOld.Text = noteNew.Text;
        }
        /// <summary>
        /// Печать ежедневника
        /// </summary>
        public void Print()
        {
            Console.WriteLine();
            int i = 1;
            foreach (var elem in Notes)
            {
                Console.WriteLine($"Заметка №{i}");
                Console.WriteLine($"Дата заметки: {elem.Date}");
                Console.WriteLine($"Текст: {elem.Text}");
                i++;
            }
        }
        /// <summary>
        /// Выгрузка данных по пути к файлу
        /// </summary>
        /// <param name="path"></param>
        public void ExportData(string path)
        {
            int i = 1;
            using(StreamWriter writer = new StreamWriter(path))
            {
                foreach(var elem in Notes)
                {
                    writer.WriteLine($"Заметка №{i}");
                    writer.WriteLine($"Дата заметки: {elem.Date}");
                    writer.WriteLine($"Текст: {elem.Text}");
                    i++;
                }
            }
        }
        /// <summary>
        /// импорт данных по указанному пути3
        /// </summary>
        /// <param name="path"></param>
        public void ImportData(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();//сначала идет номер заметки, затем дата и текст заметки

                    DateTime result;
                    if (!DateTime.TryParse(reader.ReadLine(), out result))
                    {
                        Console.WriteLine("Введен в файле  некорректный тип данных для даты заметки");
                        System.Environment.Exit(1);
                    }
                    Notes.Add(new Note(result, reader.ReadLine()));
                }
            }
        }
        /// <summary>
        /// импорт данных по указанному диапозону дат
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        public void ImportData(string path, DateTime dateStart, DateTime dateEnd)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();//сначала идет номер заметки, затем дата и текст заметки
                    DateTime result;
                    if (!DateTime.TryParse(reader.ReadLine(), out result))
                    {
                        Console.WriteLine("Введен в файле  некорректный тип данных для даты заметки");
                        System.Environment.Exit(1);
                    }
                    if (result >= dateStart && result <= dateEnd)
                        Notes.Add(new Note(result, reader.ReadLine()));
                    else
                        reader.ReadLine();
                }
            }
        }
        /// <summary>
        /// сортировка по убыванию дат
        /// </summary>
        public void SortDescendingDate()
        {
            Note temp;
            for (int i = 0; i < Notes.Count - 1; i++)
            {
                for (int j = i + 1; j < Notes.Count; j++)
                {
                    if (Notes[i].Date < Notes[j].Date)
                    {
                        temp = Notes[i];
                        Notes[i] = Notes[j];
                        Notes[j] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// сортировка по возрастанию дат
        /// </summary>
        public void SortAscendingDate() 
        {
            Note temp;
            for (int i = 0; i < Notes.Count - 1; i++)
            {
                for (int j = i + 1; j < Notes.Count; j++)
                {
                    if (Notes[i].Date > Notes[j].Date)
                    {
                        temp = Notes[i];
                        Notes[i] = Notes[j];
                        Notes[j] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// сортировка по убыванию длины записки 
        /// </summary>
        public void SortDescendingLenghtText()
        {
            Note temp;
            for (int i = 0; i < Notes.Count - 1; i++)
            {
                for (int j = i + 1; j < Notes.Count; j++)
                {
                    if (Notes[i].Text.Length < Notes[j].Text.Length)
                    {
                        temp = Notes[i];
                        Notes[i] = Notes[j];
                        Notes[j] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// сортировка по возрастанию длины записки 
        /// </summary>
        public void SortAscendingLenghtText() 
        {
            Note temp;
            for (int i = 0; i < Notes.Count - 1; i++)
            {
                for (int j = i + 1; j < Notes.Count; j++)
                {
                    if (Notes[i].Text.Length > Notes[j].Text.Length)
                    {
                        temp = Notes[i];
                        Notes[i] = Notes[j];
                        Notes[j] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// создание ежедневника
        /// </summary>
        /// <param name="args"></param>
        public Diary(params Note[] args)
        {
            Notes = new List<Note>();
            foreach (var elem in args)
                Notes.Add(elem);
        }
        /// <summary>
        /// Загрузка Данных 
        /// </summary>
        /// <param name="path"></param>
        public Diary(string path)
        {
            Notes = new List<Note>();
            using(StreamReader reader = new StreamReader(path))
            {
                while(!reader.EndOfStream)
                {
                    reader.ReadLine();
                    DateTime result;
                    if (!DateTime.TryParse(reader.ReadLine(), out result))
                    {
                        Console.WriteLine("Введите корректный тип данных для даты заметки");
                        System.Environment.Exit(1);
                    }
                    Notes.Add(new Note(result, reader.ReadLine()));
                }
            }
        }
    }
}
