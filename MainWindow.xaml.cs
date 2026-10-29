using System.Windows;
using KINO_Alikin_2.Classes;
using System.Windows.Controls;

namespace KINO_Alikin_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }
        public void OpenPage(Page Page)
        {
            frame.Navigate(Page);
        }

        private void openKino(object sender, RoutedEventArgs e) => OpenPage(new Pages.Kinoteatr.Main());

        private void openAfishi(object sender, RoutedEventArgs e) => OpenPage(new Pages.afisha.Main());
    }
}
