using ProductionLopushock.Pages;
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

namespace ProductionLopushock.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MaterialUserControl.xaml
    /// </summary>
    public partial class MaterialUserControl : UserControl
    {
        private ChangeMaterial material;
        private Product product;
        public MaterialUserControl(ChangeMaterial materials, Product _product)
        {
            InitializeComponent();
            product = _product;
            material = materials;
            MaterialsCb.ItemsSource = App.db.Material.ToList();
            MaterialsCb.DisplayMemberPath = "Title";
            MaterialsCb.Text = materials.Material.Title;
            QuantityTb.Text = materials.Quantity.ToString();

        }

        private void QuantityTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[^0-9]"))
            {
                e.Handled = true;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.ChangeMaterial.Remove(material);
            MessageBox.Show("Материалы удалены!");
            Navigations.NextPage(new CreateEditProductPage(product));
        }
    }
}
