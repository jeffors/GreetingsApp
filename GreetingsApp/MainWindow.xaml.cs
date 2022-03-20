using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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

namespace GreetingsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var langsMessage = new LangsReader
            {
                LangMessages = new Dictionary<string, TimesOfDay>
                {
                    ["English"] = new TimesOfDay { Day = "Good Day", Evening = "Good Evening", Morning = "Good Morning", Night = "Good Night" },
                    ["Deutsch"] = new TimesOfDay { Day = "Guten Tag", Evening = "Guten Abend", Morning = "Guten Morgen", Night = "Gute Nacht" },
                    ["Russian"] = new TimesOfDay { Day = "Добрый день", Evening = "Добрый вечер", Morning = "Доброе утро", Night = "Доброй ночи" },
                    ["Татарча"] = new TimesOfDay { Day = "Хәерле көн", Evening = "Хәерле кич", Morning = "Хәерле иртә", Night = "Хәерле төн" }
                }
            };

            string fileName = "langs.json";
            var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic) };
            string jsonString = JsonSerializer.Serialize(langsMessage, options);
            File.WriteAllText(fileName, jsonString);

            jsonBox.Text = File.ReadAllText(fileName);
            
            //greetingsMessage.Content = "";
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var timeMessage = new TimeGreetings();

            greetingsMessage.Content = cmb.SelectedIndex switch
            {
                0 => timeMessage.GetMessage(),
                1 => "Hallo Welt",
                2 => "Привет мир",
                3 => "Сәлам Дөнья",
                _ => "Зарецкий, уйди нахуй отсюда"
            };
        }
    }
}
