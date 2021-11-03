using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkTheme7
{
    struct Note
    {
        /// <summary>
        /// Дата когда была сделана заметка
        /// </summary>
        public DateTime Date { get; set;}
        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Text"></param>
        public Note(DateTime Date, string Text)
        {
            this.Date = Date;
            this.Text = Text;
        }
    }
}
