using KINO_Alikin_2.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KINO_Alikin_2.Pages.afisha
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        AfishaContext afisha;
        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();

            foreach(var item in AllKinoteatrs)
                kinoteatrs.Items.Add(item.name);

            kinoteatrs.Items.Add("Выберите ...");

            if (afisha != null)
            {
                this.afisha = afisha;
                name.Text = afisha.name;
                kinoteatrs.SelectedIndex = AllKinoteatrs.FindIndex(x => x.id == afisha.idKinoteatr);
                date.Text = afisha.time.ToString("yyyy-MM-dd");
                time.Text = afisha.time.ToString("HH:mm");
                price.Text = afisha.price.ToString();
                btnAdd.Content = "Изменить";
            }
            else
            {
                kinoteatrs.SelectedIndex = kinoteatrs.Items.Count - 1;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            DateTime dataAfisha;
            TimeSpan timeAfisha;
            int priceInt = -1;

            if(name.Text == ""){
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if(kinoteatrs.SelectedIndex == kinoteatrs.Items.Count - 1)
            {
                MessageBox.Show("Выберите кинотеатр");
                return;
            }
            if (date.Text == "")
            {
                MessageBox.Show("Необходимо указать дату");
                return;
            }
            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeAfisha) == false)
            {
                MessageBox.Show("Необходимо указать время");
                return;
            }
            if (price.Text == "" || int.TryParse(price.Text, out priceInt) == false)
            {
                MessageBox.Show("Необходимо указать количекство залов");
                return;
            }

            if (DateTime.TryParse(date.Text, out dataAfisha))
            {
                dataAfisha = dataAfisha.Add(timeAfisha);
            }
            else
            {
                MessageBox.Show("Неверный формат даты");
                return;
            }

            if (afisha == null)
            {
                AfishaContext newAfisha = new AfishaContext(
                    0,
                    name.Text,
                    dataAfisha,
                    priceInt,
                    AllKinoteatrs.Find(x => x.name == kinoteatrs.SelectedItem).id);
                newAfisha.Add();
            }
            else
            {
                afisha = new AfishaContext(
                    afisha.id,
                    name.Text,
                    dataAfisha,
                    priceInt,
                    AllKinoteatrs.Find(x => x.name == kinoteatrs.SelectedItem).id
                    );
                afisha.Update();
            }
            MainWindow.init.OpenPage(new Pages.afisha.Main());
        }
    }
}
