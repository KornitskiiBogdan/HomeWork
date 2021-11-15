using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace HomeWorkTheme9
{
    class Program
    {
        static TelegramBotClient bot;
        static string nameCommand;
        static void Main(string[] args)
        {
            //вставьте свой токен
            string token = File.ReadAllText($"{ Directory.GetCurrentDirectory()}//token.txt ");
            bot = new TelegramBotClient(token);
            bot.StartReceiving();

            bot.OnMessage += MessageCommand;
 
            bot.OnMessage += MessageListener;

            Console.ReadLine();

            bot.StopReceiving();

        }
        /// <summary>
        /// отправка и получение различных типов файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static async void MessageListener(object sender, MessageEventArgs e)
        {
            Console.WriteLine(nameCommand);
            var msg = e.Message;
            switch (nameCommand)
            {
                case "Отправить документ":
                    DownLoad(e.Message.Document.FileId, $"{Directory.GetCurrentDirectory()}//file//{e.Message.Document.FileName}");
                    break;

                case "Получить документ":
                    await bot.SendDocumentAsync(
                        msg.Chat.Id,
                        System.IO.File.Open($"{Directory.GetCurrentDirectory()}\\{msg.Text}", FileMode.Open)
                        );
                    break;
                case "Отправить аудио":
                    DownLoad(e.Message.Document.FileId, $"{Directory.GetCurrentDirectory()}//audio//{e.Message.Document.FileName}");
                    //DownLoad(e.Message.Document.FileId, $"{Directory.GetCurrentDirectory()}//audio//{e.Message.Document.FileName}");
                    break;

                case "Получить аудио":
                    await bot.SendAudioAsync(
                        msg.Chat.Id,
                        System.IO.File.Open($"{Directory.GetCurrentDirectory()}\\{msg.Text}", FileMode.Open)
                        );
                    break;
                case "Отправить изображение":
                    DownLoad(e.Message.Document.FileId, $"{Directory.GetCurrentDirectory()}//pictures//{e.Message.Document.FileName}");
                    break;

                case "Получить изображение":
                    await bot.SendPhotoAsync(
                        msg.Chat.Id,
                        File.Open($"{Directory.GetCurrentDirectory()}\\{msg.Text}", FileMode.Open)
                        );
                    break;
                default:
                    break;
            }
            Thread.Sleep(300);
        }

        /// <summary>
        /// получение команды от бота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static async void MessageCommand(object sender, MessageEventArgs e)
        {
            
            var msg = e.Message;
            if (msg.Text != null)
            {
                switch (msg.Text)
                {
                    case "Отправить документ":
                        
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите файл, который вы хотите отправить");
                        nameCommand = "Отправить документ";
                        break;

                    case "Получить документ":
                        
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите документ, который вы хотите получить, напишите название файла в чат");
                        nameCommand = "Получить документ";
                        GetNameFile(msg.Chat.Id, "file");
                        
                        break;
                    case "Отправить аудио":
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите аудио, которое вы хотите отправить");
                        nameCommand = "Отправить аудио";
                        break;

                    case "Получить аудио":
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите аудио, которое вы хотите получить, напишите название аудио в чат");
                        GetNameFile(msg.Chat.Id, "audio");
                        nameCommand = "Получить аудио";
                        break;
                    case "Отправить изображение":
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите изображение, которое вы хотите отправить");
                        nameCommand = "Отправить изображение";
                        break;

                    case "Получить изображение":
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите изображение, которое вы хотите получить, напишите название изображение в чат");
                        GetNameFile(msg.Chat.Id, "pictures");
                        nameCommand = "Получить изображение";
                        break;
                    default:
                        await bot.SendTextMessageAsync
                        (
                            msg.Chat.Id,
                            "Приветствую тебя! Я умею получать аудиофайлы, документы, картинки, воспользуйся кнопками, чтобы выбрать метод. Удачи!",
                            replyMarkup: GetButtons(),
                            replyToMessageId: msg.MessageId
                        );
                        break;
                }
                
                
            }
            Thread.Sleep(300);
        }
        /// <summary>
        /// отправить названия файлов, хранящиеся в директории
        /// </summary>
        /// <param name="ChatId"></param>
        private static async void GetNameFile(long ChatId, string nameDirectory)
        {
            var file = Directory.GetFiles($"{nameDirectory}//");
            foreach (var elem in file)
            {
                await bot.SendTextMessageAsync(
                                ChatId,
                                elem);
            }
        }
        /// <summary>
        /// Кнопки бота
        /// </summary>
        /// <returns></returns>
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Отправить документ" }, new KeyboardButton { Text = "Получить документ" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Отправить аудио" }, new KeyboardButton { Text = "Получить аудио" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Отправить изображение" }, new KeyboardButton { Text = "Получить изображение" } }
                }
            };
        }
        /// <summary>
        /// Загрузить себе на компьютер файл
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="path"></param>
        static async void DownLoad(string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();
        }
    }
}