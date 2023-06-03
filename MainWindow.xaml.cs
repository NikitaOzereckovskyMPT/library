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


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user;
        SerializeDeserialize serialize = new SerializeDeserialize();
        public MainWindow()
        {
            InitializeComponent();

            //Создаем спиок тем приложения и вызываем ThemeChange при смене выбранного элемента
            List<string> styles = new List<string> { "light", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";

            //Создаем спиок языков приложения и вызываем ThemeChange при смене выбранного элемента
            List<string> languages = new List<string> { "Russian", "English" };
            languageBox.SelectionChanged += LanguageChange;
            languageBox.ItemsSource = languages;
            languageBox.SelectedItem= "Russian";
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void LanguageChange(object sender, SelectionChangedEventArgs e)
        {
            string language = languageBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(language + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            // сериализируем созданного пользователя
            serialize.serialize(user);
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            // десереализируем пользователя и выводим в ТextBox
            DeserializatedContentTextBox.Text= $"Id: {serialize.deserialize<User>().Id}\nLogin: {serialize.deserialize<User>().Login}";
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            // создаем объект класса User
            user = new User(IdTextBox.Text, LoginTextBox.Text);
        }
    }
}
