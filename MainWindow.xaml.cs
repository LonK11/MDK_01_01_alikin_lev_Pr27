using System.Windows;
using KINO_Alikin_2.Classes;

namespace KINO_Alikin_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            new KinoteatrContext(0 ,"test", 12, 12).Add();
        }
    }
}
