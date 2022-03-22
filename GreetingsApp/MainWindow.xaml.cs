using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

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
            InitializeLanguageSelector();
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetMessage();
        }

        internal void GetMessage()
        {
            var langs = ReadLangs().LangMessages;
            var hourNow = DateTime.Now.Hour;

            greetingsMessage.Content = hourNow switch
            {
                >= 5 and < 10 => langs[cmb.SelectedValue.ToString()].Morning,
                >= 10 and < 18 => langs[cmb.SelectedValue.ToString()].Day,
                >= 18 and < 23 => langs[cmb.SelectedValue.ToString()].Evening,
                >= 23 or < 5 => langs[cmb.SelectedValue.ToString()].Night,
            };
        }

        private void InitializeLanguageSelector()
        {
            LangsCollection langs = ReadLangs();

            foreach (var item in langs.LangMessages)
            {
                cmb.Items.Add(item.Key);
            }

            cmb.SelectedIndex = 0;
        }

        private LangsCollection ReadLangs()
        {
            string fileName = "langs.json";
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<LangsCollection>(jsonString);
        }
    }
}
