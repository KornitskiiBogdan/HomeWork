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
        static void Main(string[] args)
        {
            //Directory.CreateDirectory("test");
            //вставьте свой токен
            string token = File.ReadAllText($"{ Directory.GetCurrentDirectory()}//token.txt ");
            bot = new TelegramBotClient(token);
            bot.StartReceiving();

            bot.OnMessage += MessageListener;

            Console.ReadLine();

            bot.StopReceiving();

        }
        private static async void GetMe()
        {
            var me = await bot.GetMeAsync();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}");
        }

        private static async void MessageListener(object sender, MessageEventArgs e)
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
                        DownLoad(e.Message.Document.FileId, e.Message.Document.FileName);
                        break;
                    case "Получить документ":
                        await bot.SendTextMessageAsync(
                            msg.Chat.Id,
                            "Выберите документ, который вы хотите получить, напишите название файла в чат");
                        
                        GetNameFile(msg.Chat.Id);
                        Thread.Sleep(3000);
                        await bot.SendDocumentAsync(
                            msg.Chat.Id,
                            System.IO.File.Open(msg.Text, FileMode.Open)
                            );
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
        private static async void GetNameFile(long ChatId)
        {
            var file = Directory.GetFiles("test");
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
                    new List<KeyboardButton> { new KeyboardButton { Text = "Отправить картинку" }, new KeyboardButton { Text = "Получить картинку" } }
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
            FileStream fs = new FileStream("_" + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();
        }
    }
}
// Создать бота, позволяющего принимать разные типы файлов, 
// *Научить бота отправлять выбранный файл в ответ
// 
// https://data.mos.ru/
// https://apidata.mos.ru/
// 
// https://vk.com/dev
// https://vk.com/dev/manuals

// https://dev.twitch.tv/
// https://discordapp.com/developers/docs/intro
// https://discordapp.com/developers/applications/
// https://discordapp.com/verification
