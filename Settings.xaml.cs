using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OpenAiClient
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            if (conf.Default.apiKey != "")
                ApiKey.Text = conf.Default.apiKey;
        }

        private void Write(object sender, RoutedEventArgs e)
        {
            conf.Default.apiKey = ApiKey.Text;
            conf.Default.Save();
        }
    }
}
