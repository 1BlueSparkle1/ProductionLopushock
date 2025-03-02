using ProductionLopushock.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UpdatePricePage.xaml
    /// </summary>
    public partial class UpdatePricePage : Page
    {
        private static Product product1;
        public UpdatePricePage(Product product)
        {
            InitializeComponent();
            product1 = product;
            double cost = 0;
            int num = 1;
            foreach(var min in product.MinCost.ToList())
            {
                cost += (double)min.Cost;
                num++;
            }
            PriceTb.Text = (cost / (num - 1)).ToString();
        }

        private void PriceTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[^0-9]"))
            {
                e.Handled = true;
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextPage(new ListProductPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            MinCost minCost = new MinCost();
            minCost.Cost = double.Parse(PriceTb.Text);
            minCost.ProductId = product1.Id;
            minCost.Date = DateTime.Now;
            App.db.MinCost.Add(minCost);
            App.db.SaveChanges();
            MessageBox.Show("Новая цена записана!");
            Navigations.NextPage(new ListProductPage());
        }
    }
}
