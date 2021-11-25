using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using Telegram.Bot;

namespace HomeWork10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramBotClient bot;

        string path = $"{Directory.GetCurrentDirectory()}//test.json";

        ObservableCollection<TelegramUser> Users;
        public MainWindow()
        {
            InitializeComponent();

            Users = new ObservableCollection<TelegramUser>();
            userList.ItemsSource = Users;

            string pathToken = @"C:\Users\Богдан\source\repos\HomeWork\HomeWork10\token.txt";

            string token = File.ReadAllText(pathToken);

            bot = new TelegramBotClient(token);

            bot.OnMessage += InputData;

            bot.StartReceiving();

            btnSendMessage.Click += BtnSendMessage_Click;
            btnSaveHistory.Click += BtnSaveHistory_Click;
            btnDownoloadHistory.Click += BtnDownoloadHistory_Click;
        }
        private void InputData(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var person = new TelegramUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
                if (!Users.Contains(person)) Users.Add(person);
                Users[Users.IndexOf(person)].AddMessage($"{person.NickName} : {e.Message.Text}");
            });
        }
        private void BtnDownoloadHistory_Click(object sender, RoutedEventArgs e)
        {
            var user = Users[Users.IndexOf(userList.SelectedItem as TelegramUser)];
            string jsonText = File.ReadAllText(path);

            var messages = JsonConvert.DeserializeObject<ObservableCollection<string>>(jsonText);
            foreach (var elem in messages)
            {
                user.AddMessage(elem);
            }
        }

        private void BtnSaveHistory_Click(object sender, RoutedEventArgs e)
        {
            var user = Users[Users.IndexOf(userList.SelectedItem as TelegramUser)];
            string json = JsonConvert.SerializeObject(user.Messages);
            File.WriteAllText(path, json);
        }

        private void BtnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            var user = Users[Users.IndexOf(userList.SelectedItem as TelegramUser)];
            string message = $"Bot: {txtMessChanged.Text}";
            user.Messages.Add(message);

            bot.SendTextMessageAsync(user.Id, txtMessChanged.Text);

            txtMessChanged.Text = String.Empty;
        }
    }
}
