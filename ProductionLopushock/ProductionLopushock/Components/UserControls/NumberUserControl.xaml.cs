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
    /// Логика взаимодействия для NumberUserControl.xaml
    /// </summary>
    public partial class NumberUserControl : UserControl
    {
        private int all_num;
        private int page;
        public NumberUserControl(int number, bool underline, int all)
        {
            InitializeComponent();
            all_num = all;
            page = number;
            NumberTb.Text = number.ToString();
            if (underline)
            {
                NumberTb.TextDecorations = TextDecorations.Underline;
            }
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            TurnPage.NextList(all_num, page - 1, true);
        }
    }
}
