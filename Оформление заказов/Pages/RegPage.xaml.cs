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
using Оформление_заказов.ViewModel;
using Оформление_заказов.Windows;
using Оформление_заказов.Tool;

namespace Оформление_заказов.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage(AddRegVM p)
        {
            InitializeComponent();
            DataContext = p;    
        }
        public cPage currentPageControl;
        private void Drink(object sender, RoutedEventArgs e)
        {
            AddDrinkWin win = new AddDrinkWin(new AddDrink(currentPageControl));
            win.ShowDialog();
        }
        private void Menus(object sender, RoutedEventArgs e)
        {
            AddMenuWin win = new AddMenuWin(new AddMenu(currentPageControl));
            win.ShowDialog();
        }
    }
}
