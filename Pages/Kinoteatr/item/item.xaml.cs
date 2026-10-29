using KINO_Alikin_2.Classes;
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

namespace KINO_Alikin_2.Pages.Kinoteatr.item
{
    /// <summary>
    /// Логика взаимодействия для item.xaml
    /// </summary>
    public partial class item : UserControl
    {
        KinoteatrContext kinoteatr;
        Main main;
        public item(KinoteatrContext kinoteatr, Main main)
        {
            InitializeComponent();

            name.Text = kinoteatr.name;
            count.Text = kinoteatr.count.ToString();
            countZal.Text = kinoteatr.countZal.ToString();
            this.kinoteatr = kinoteatr;
            this.main = main;
        }

        private void EditRecord(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Add(this.kinoteatr));
        }

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            kinoteatr.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
