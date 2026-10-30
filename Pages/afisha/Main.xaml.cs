using KINO_Alikin_2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KINO_Alikin_2.Pages.afisha
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<AfishaContext> AllAfishas = AfishaContext.Select();
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        public Main()
        {
            InitializeComponent();

            filterKinoteatr.Items.Add("Все");
            foreach (var kino in AllKinoteatrs)
                filterKinoteatr.Items.Add(kino.name);
            filterKinoteatr.SelectedIndex = 0;

            ShowList(AllAfishas);
        }

        private void ShowList(IEnumerable<AfishaContext> list)
        {
            parent.Children.Clear();
            foreach (AfishaContext item in list)
            {
                parent.Children.Add(new item.item(item, this));
            }
        }

        private void Filter_Changed(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (parent == null || searchBox == null)
                return;

            string search = searchBox.Text.Trim().ToLower();

            bool hasMinPrice = int.TryParse(priceFrom.Text, out int minPrice);
            bool hasMaxPrice = int.TryParse(priceTo.Text, out int maxPrice);
            bool hasDateFrom = dateFrom.SelectedDate.HasValue;
            bool hasDateTo = dateTo.SelectedDate.HasValue;
            DateTime dateFromValue = hasDateFrom ? dateFrom.SelectedDate.Value.Date : DateTime.MinValue;
            DateTime dateToValue = hasDateTo ? dateTo.SelectedDate.Value.Date : DateTime.MaxValue;

            IEnumerable<AfishaContext> filtered = AllAfishas.Where(x =>
                x.name.ToLower().Contains(search) &&
                (!hasMinPrice || x.price >= minPrice) &&
                (!hasMaxPrice || x.price <= maxPrice) &&
                (!hasDateFrom || x.time.Date >= dateFromValue) &&
                (!hasDateTo || x.time.Date <= dateToValue));

            if (filterKinoteatr.SelectedIndex > 0)
            {
                string kinoName = filterKinoteatr.SelectedItem.ToString();
                var kino = AllKinoteatrs.Find(x => x.name == kinoName);
                if (kino != null)
                    filtered = filtered.Where(x => x.idKinoteatr == kino.id);
            }

            int nameSort = sortName.SelectedIndex;
            int dateSort = sortDate.SelectedIndex;
            int priceSort = sortPrice.SelectedIndex;

            if (priceSort != 0)
                filtered = priceSort == 1 ? filtered.OrderBy(x => x.price) : filtered.OrderByDescending(x => x.price);

            if (dateSort != 0)
                filtered = dateSort == 1 ? filtered.OrderByDescending(x => x.time) : filtered.OrderBy(x => x.time);

            if (nameSort != 0)
                filtered = nameSort == 1 ? filtered.OrderBy(x => x.name) : filtered.OrderByDescending(x => x.name);

            ShowList(filtered);
        }

        private void Filter_Changed(object sender, SelectionChangedEventArgs e) =>
            Filter_Changed(sender, (RoutedPropertyChangedEventArgs<DateTime?>)null);

        private void Filter_Changed(object sender, TextChangedEventArgs e) =>
            Filter_Changed(sender, (RoutedPropertyChangedEventArgs<DateTime?>)null);

        private void ResetFilter(object sender, System.Windows.RoutedEventArgs e)
        {
            searchBox.Text = "";
            priceFrom.Text = "";
            priceTo.Text = "";
            dateFrom.SelectedDate = null;
            dateTo.SelectedDate = null;
            filterKinoteatr.SelectedIndex = 0;
            sortName.SelectedIndex = 0;
            sortDate.SelectedIndex = 0;
            sortPrice.SelectedIndex = 0;
            ShowList(AllAfishas);
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Pages.afisha.Add());
    }
}
