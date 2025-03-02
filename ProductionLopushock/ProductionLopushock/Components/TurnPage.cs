using ProductionLopushock.Components.UserControls;
using ProductionLopushock.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLopushock.Components
{
    internal class TurnPage
    {
        public static ListProductPage productPage;
        public static void NextList(int all, int page, bool next)
        {
            IEnumerable<Product> products = App.db.Product.ToList();
            if (next)
            {
                App.list = page + 1;
            }
            else
            {
                App.list = page - 1;
            }

            productPage.PageWp.Children.Clear();
            for (int i = 1; i <= all; i++)
            {
                if (i == App.list)
                {
                    productPage.PageWp.Children.Add(new NumberUserControl(i, true, all));
                }
                else
                {
                    productPage.PageWp.Children.Add(new NumberUserControl(i, false, all));
                }
            }

            productPage.ProductWp.Children.Clear();
            int count = 20 * (App.list - 1);
            for (int i = count; i < count + 20; i++)
            {
                if (products.Count() > i)
                {
                    productPage.ProductWp.Children.Add(new ProductUserControl(products.ElementAt(i)));
                }
            }
            
        }
        public static void NextListRef(int all, IEnumerable<Product> products)
        {
            App.list = 1;
            productPage.PageWp.Children.Clear();
            for (int i = 1; i <= all; i++)
            {
                if (i == App.list)
                {
                    productPage.PageWp.Children.Add(new NumberUserControl(i, true, all));
                }
                else
                {
                    productPage.PageWp.Children.Add(new NumberUserControl(i, false, all));
                }
            }

            productPage.ProductWp.Children.Clear();
            int count = 20 * (App.list - 1);
            for (int i = count; i < count + 20; i++)
            {
                if(products.Count() > i)
                {
                    productPage.ProductWp.Children.Add(new ProductUserControl(products.ElementAt(i)));
                }
                
            }

        }
    }
}
