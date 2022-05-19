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
using Оформление_заказов.Tool;

namespace Оформление_заказов.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateReportMenuPage.xaml
    /// </summary>
    public partial class CreateReportMenuPage : Page
    {
        public cPage currentPageControl;
        public CreateReportMenuPage()
        {
            InitializeComponent();
            DataContext = new CreateReportMenu(currentPageControl);
        }
    }
}
