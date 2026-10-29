using KINO_Alikin_2.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KINO_Alikin_2.Pages.Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        KinoteatrContext kinoteatr;
        public Add(KinoteatrContext kinoteatr = null)
        {
            InitializeComponent();

            if(kinoteatr != null)
            {
                this.kinoteatr = kinoteatr;
                name.Text = kinoteatr.name;
                count.Text = kinoteatr.count.ToString();
                countZal.Text = kinoteatr.countZal.ToString();
                btnAdd.Content = "Изменить";
            }
        }
        private void AddRecord(object sender, RoutedEventArgs e)
        {
            int countZalInt = -1;
            int countInt = -1;

            if (name.Text == ""){
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (count.Text == "" || int.TryParse(count.Text, out countInt) == false){
                MessageBox.Show("Необходимо указать количество мест");
                return;
            }
            if (countZal.Text == "" || int.TryParse(countZal.Text, out countZalInt) == false)
            {
                MessageBox.Show("Необходимо указать количекство залов");
                return;
            }
            if (this.kinoteatr == null){
                KinoteatrContext newKinoteatr = new KinoteatrContext(
                        0,
                        name.Text,
                        countZalInt,
                        countInt
                    );
                newKinoteatr.Add();
                MessageBox.Show("Запись успешно добавлена.");
            }
            else {
                kinoteatr = new KinoteatrContext(
                    kinoteatr.id,
                    name.Text,
                    countZalInt,
                    countInt);
                kinoteatr.Update();
                MessageBox.Show("Запись успешно обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Main());
        }
    }
}
