using KINO_Alikin_2.Classes;
using System.Collections.Generic;
using System.Windows.Controls;

namespace KINO_Alikin_2.Pages.Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        public Main()
        {
            InitializeComponent();

            foreach (KinoteatrContext item in AllKinoteatrs){
                parent.Children.Add(new item.item(item, this));
            }
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Add());
    }
}
