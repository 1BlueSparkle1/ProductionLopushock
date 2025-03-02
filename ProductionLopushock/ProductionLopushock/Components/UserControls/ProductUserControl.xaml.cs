using ProductionLopushock.Pages;
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

namespace ProductionLopushock.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        private int click = 0;
        private Product product1;
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            product1 = product;
            if (product.Image != "")
            {
                LogoImg.Source = new BitmapImage(new Uri("/Resources" + product.Image, UriKind.Relative));
            }
            TitleTb.Text = product.TypeProduct.Title + " | " + product.Title;
            ArtTb.Text = product.Article;
            //double cost = 0;
            foreach (var el in product.Change.ToList().First().ChangeMaterial.ToList())
            {
                MaterTb.Text += el.Material.Title + ", ";
                //    if (el.Material.Cost != null)
                //    {
                //        cost += (double)el.Material.Cost;
                //    }
                //}
                //if (cost > 0)
                //{
                //    CostTb.Text = cost.ToString() + " руб.";
                //}
                //else
                //{
                //    CostTb.Text = "-- руб.";
            }
            if (product.MinCost.Count > 0)
            {
                CostTb.Text = product.MinCost.ToList().Last().Cost.ToString() + " руб.";
            }
            else
            {
                CostTb.Text = "-- руб.";
            }
            


            bool find = false;
            foreach(var aplication in product.Application.ToList())
            {
                DateTime dateTime = (DateTime)aplication.DateStart;
                dateTime = dateTime.AddMonths(1);
                if (dateTime > DateTime.Now)
                {
                    find = true;
                }
            }
            if (!find || product.Application.Count() == 0)
            {
                BorderBd.BorderBrush = Brushes.LightCoral;
            }
            else
            {
                BorderBd.BorderBrush = Brushes.Black;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            click++;
            if (click%2 == 0)
            {
                GroupBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                GroupBtn.Visibility = Visibility.Visible;
            }
        }

        private void UpdatePrice_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextPage(new UpdatePricePage(product1));
        }

        private void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextPage(new CreateEditProductPage(product1));
        }
    }
}
