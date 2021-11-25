using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Telegram.Bot.Args;
using System.Threading.Tasks;

namespace HomeWork10
{
    class TelegramUser : IEquatable<TelegramUser>
    {
        public string NickName { get; private set; }
        public long Id { get; private set; }
        public ObservableCollection<string> Messages { get; set; }
        public TelegramUser(string NickName, long ChatId)
        {
            Messages = new ObservableCollection<string>();
            this.Id = ChatId;
            this.NickName = NickName;
        }
        
        public void AddMessage(string Text)
        {
            Messages.Add(Text);
        }

        public bool Equals(TelegramUser other)
        {
            return other.Id == this.Id;
        }
    }
}
//private MainWindow w;

//private TelegramBotClient bot;
//public ObservableCollection<MessageLog> BotMessageLog { get; set; }

//private void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
//{
//    if (e.Message.Text == null) return;

//    var messageText = e.Message.Text;

//    w.Dispatcher.Invoke(() =>
//    {
//        BotMessageLog.Add(
//        new MessageLog(
//            DateTime.Now.ToLongTimeString(), messageText, e.Message.Chat.FirstName, e.Message.Chat.Id));
//    });
//}

//public TelegramMessageClient(MainWindow W,
//    string PathToken = @"C:\Users\Богдан\source\repos\HomeWork\HomeWork10\token.txt")
//{
//    this.BotMessageLog = new ObservableCollection<MessageLog>();
//    this.w = W;

//    bot = new TelegramBotClient(File.ReadAllText(PathToken));

//    bot.OnMessage += MessageListener;

//    bot.StartReceiving();
//}

//public void SendMessage(string Text, string Id)
//{
//    long id = Convert.ToInt64(Id);
//    bot.SendTextMessageAsync(id, Text);
//}