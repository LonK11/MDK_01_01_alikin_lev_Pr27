using KINO_Alikin_2.Classes;
using System.Collections.Generic;
using System.Linq;
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

            ShowList(AllKinoteatrs);
        }
        private void ShowList(IEnumerable<KinoteatrContext> list)
        {
            parent.Children.Clear();
            foreach (KinoteatrContext item in list)
            {
                parent.Children.Add(new item.item(item, this));
            }
        }

        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (parent == null || searchBox == null)
                return;

            string search = searchBox.Text.Trim().ToLower();

            IEnumerable<KinoteatrContext> filtered = AllKinoteatrs.Where(x =>
                x.name.ToLower().Contains(search));

            int nameSort = sortName.SelectedIndex;
            int zalSort = sortCountZal.SelectedIndex;
            int countSort = sortCount.SelectedIndex;

            if (countSort != 0)
                filtered = countSort == 1 ? filtered.OrderBy(x => x.count) : filtered.OrderByDescending(x => x.count);

            if (zalSort != 0)
                filtered = zalSort == 1 ? filtered.OrderBy(x => x.countZal) : filtered.OrderByDescending(x => x.countZal);

            if (nameSort != 0)
                filtered = nameSort == 1 ? filtered.OrderBy(x => x.name) : filtered.OrderByDescending(x => x.name);

            ShowList(filtered);
        }

        private void Filter_Changed(object sender, TextChangedEventArgs e) =>
            Filter_Changed(sender, (SelectionChangedEventArgs)null);

        private void ResetFilter(object sender, System.Windows.RoutedEventArgs e)
        {
            searchBox.Text = "";
            sortName.SelectedIndex = 0;
            sortCountZal.SelectedIndex = 0;
            sortCount.SelectedIndex = 0;
            ShowList(AllKinoteatrs);
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Add());
    }
}
