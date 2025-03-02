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
    /// Логика взаимодействия для CreateEditProductPage.xaml
    /// </summary>
    public partial class CreateEditProductPage : Page
    {
        private static Product product;
        public CreateEditProductPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            TypeCb.ItemsSource = App.db.TypeProduct.ToList();
            TypeCb.DisplayMemberPath = "Title";
            NumberWorkShopTb.ItemsSource = App.db.Workshop.ToList();
            NumberWorkShopTb.DisplayMemberPath = "Id";
            if (product.Id != 0)
            {
                GlavTitleTb.Text = "Редактирование продукта";
                ArtTb.Text = product.Article;
                TitleTb.Text = product.Title;
                TypeCb.SelectedItem = product.TypeProduct.Title;
                
                if (product.Image != "")
                {
                    LogoImg.Source = new BitmapImage(new Uri("/Resources" + product.Image, UriKind.Relative));
                }
                else
                {
                    LogoImg.Source = new BitmapImage(new Uri("/Resources/picture.png", UriKind.Relative));
                }
                QuantityTb.Text = product.Change.ToList().First().QuantityPeople.ToString();
                NumberWorkShopTb.Text = product.Change.ToList().First().Workshop.Id.ToString();
                if (product.MinCost.Count > 0)
                {
                    MinCostTb.Text = product.MinCost.ToList().Last().Cost.ToString();
                }
                DescriptionTb.Text = product.Description;

                foreach (var item in product.Change.ToList().First().ChangeMaterial.ToList())
                {
                    MaterialWp.Children.Add(new MaterialUserControl(item, product));
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(product.Application.Count() == 0)
            {
                App.db.Product.Remove(product);
                App.db.SaveChanges();
                MessageBox.Show("Продукт удален!");
                Navigations.NextPage(new ListProductPage());
            }
            else
            {
                MessageBox.Show("Продукт использовался агентами, удаление запрещено!");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextPage(new ListProductPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            product.Article = ArtTb.Text;
            product.Title = TitleTb.Text;
            if (App.db.TypeProduct.Where(x => x.Title == TypeCb.Text).ToList().Count() > 0)
            {
                product.TypeId = App.db.TypeProduct.Where(x => x.Title == TypeCb.Text).ToList().First().Id;
            }
            product.Description = DescriptionTb.Text;
            Change change = new Change();
            change.ProductId = product.Id;
            change.QuantityPeople = int.Parse(QuantityTb.Text);
            change.WorkshopId = int.Parse(NumberWorkShopTb.Text);
            if (product.Id != 0)
            {
                App.db.SaveChanges();
            }
            else
            {
                App.db.Product.Add(product);
                App.db.Change.Add(change);
                App.db.SaveChanges();
            }

            if (product.MinCost.Count() != 0)
            {
                if (MinCostTb.Text != product.MinCost.ToList().Last().Cost.ToString())
                {
                    MinCost min = new MinCost();
                    min.Cost = int.Parse(MinCostTb.Text);
                    min.Date = DateTime.Now;
                    min.ProductId = product.Id;
                    App.db.MinCost.Add(min);
                    App.db.SaveChanges();
                }
            }
            else
            {
                MinCost min = new MinCost();
                min.Cost = int.Parse(MinCostTb.Text);
                min.Date = DateTime.Now;
                min.ProductId = product.Id;
                App.db.MinCost.Add(min);
                App.db.SaveChanges();
            }
            MessageBox.Show("Изменения сохранены!");
            Navigations.NextPage(new ListProductPage());    


        }
    }
}
