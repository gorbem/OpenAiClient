using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAiClient;

namespace OpenAiClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Spinner.Visibility = Visibility.Hidden;
        }

        private async void Send(object sender, RoutedEventArgs e)
        {
            var api = new OpenAIAPI(conf.Default.apiKey);
            var chat = api.Chat.CreateConversation();
            chat.AppendUserInput(Request.Text);
            Spinner.Visibility = Visibility.Visible;
            Result.Text = await chat.GetResponseFromChatbot();
            Spinner.Visibility = Visibility.Hidden;
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            if (!IsWindowOpen<Settings>("SettingsWindow"))
            {
                new Settings().Show();
            }
            
        }
    }
}
