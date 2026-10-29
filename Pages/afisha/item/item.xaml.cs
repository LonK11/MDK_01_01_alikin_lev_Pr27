using KINO_Alikin_2.Classes;
using KINO_Alikin_2.Modell;
using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KINO_Alikin_2.Pages.afisha.item
{
    /// <summary>
    /// Логика взаимодействия для item.xaml
    /// </summary>
    public partial class item : UserControl
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        AfishaContext afisha;
        Main main;
        public item(AfishaContext item, Main main)
        {
            InitializeComponent();

            kinoteatrs.Text = AllKinoteatrs.Find(x => x.id == item.idKinoteatr).name;
            name.Text = item.name;
            date.Text = item.time.ToString("yyyy-MM-dd");
            time.Text = item.time.ToString("HH:mm");
            price.Text = item.price.ToString();
            this.afisha = item;
            this.main = main;
        }

        private void EditRecord(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.afisha.Add(this.afisha));
        }

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            afisha.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
