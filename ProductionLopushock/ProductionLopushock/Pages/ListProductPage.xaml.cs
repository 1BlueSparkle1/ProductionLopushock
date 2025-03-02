using ProductionLopushock.Components;
using ProductionLopushock.Components.UserControls;
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

namespace ProductionLopushock.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        private static int all;
        public ListProductPage()
        {
            InitializeComponent();
            TurnPage.productPage = this;
            App.list = 1;
            IEnumerable<Product> products = App.db.Product.ToList();

            int page = products.Count() / 20;
            if (products.Count() % 20 != 0)
            {
                page++;
            }
            all = page;

            for (int i = 1; i <= page; i++)
            {
                if (App.list == i)
                {
                    PageWp.Children.Add(new NumberUserControl(i, true, page));
                }
                else
                {
                    PageWp.Children.Add(new NumberUserControl(i, false, page));
                }
            }

            int count = 20 * (App.list - 1);
            for (int i = count;  i < count+20; i++)
            {
                ProductWp.Children.Add(new ProductUserControl(products.ElementAt(i)));
            }

            IEnumerable<TypeProduct> typeProducts = App.db.TypeProduct.ToList();
            List<string> filter = new List<string>();
            filter.Add("Все");
            foreach(TypeProduct typeProduct in typeProducts)
            {
                filter.Add(typeProduct.Title);
            }

            FilterCb.ItemsSource = filter;
            SortCb.SelectedIndex = 0;
            FilterCb.SelectedIndex = 0;
            
        }

        public void Refresh()
        {
            IEnumerable<Product> products = App.db.Product.ToList();
            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.SelectedIndex == 1)
                    products = products.OrderBy(x => x.Title);
                else if (SortCb.SelectedIndex == 2)
                    products = products.OrderBy(x => x.Change.ToList().First().Workshop.Id);
                else
                    products = products.OrderBy(x => x.MinCost.ToList().Last().Cost);
            }
            if (FilterCb.SelectedIndex > 0)
            {
                products = products.Where(x => x.TypeProduct.Title == FilterCb.SelectedItem);
            }
            products = products.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) || x.Description.ToLower().Contains(SearchTb.Text.ToLower()));

            int page = products.Count() / 20;
            if (products.Count() % 20 != 0)
            {
                page++;
            }
            all = page;

            TurnPage.NextListRef(all, products);
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if(App.list !=1)
            {
                TurnPage.NextList(all, App.list, false);
            }
        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.list != all)
            {
                TurnPage.NextList(all, App.list, true);
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
