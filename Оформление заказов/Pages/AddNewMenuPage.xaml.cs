using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Оформление_заказов.Windows;
using Оформление_заказов.ViewModel;
using Оформление_заказов.Tool;

namespace Оформление_заказов.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddNemMenuPage.xaml
    /// </summary>
    public partial class AddNewMenuPage : Page
    {
        public AddNewMenuPage(AddMenuVM p)
        {
            InitializeComponent();
            DataContext = p;
        }
        public cPage currentPageControl;
        private void AddComp(object sender, RoutedEventArgs e)
        {
            CompWin win = new CompWin(new CreateCompVM(currentPageControl));
            win.ShowDialog();
        }
    }
}
