using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Оформление_заказов.Pages;
using Оформление_заказов.Tool;

namespace Оформление_заказов.ViewModel
{
    class MainVM : BaseVM
    {
        cPage currentPageControl;

        public Command ViewProduct { get; set; }
        public Command ViewGram { get; set; }
        public Command ViewType { get; set; }
        public Command ViewDrink { get; set; }
        public Command ViewMenu { get; set; }
        public Command AddReg { get; set; }
        public Command ViewUser { get; set; }

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        public MainVM()
        {
            currentPageControl = new cPage();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;
            currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));

            ViewProduct = new Command(() => {
                currentPageControl.SetPage(new ViewProductPage(new ViewProductVM(currentPageControl)));
            });
            ViewGram = new Command(() => {
                currentPageControl.SetPage(new ViewGramPage(new ViewGramVM(currentPageControl)));
            });
            ViewType = new Command(() => { 
                currentPageControl.SetPage(new ViewTypePage(new ViewTypeVM(currentPageControl)));
            });
            ViewDrink = new Command(() =>
            {
                currentPageControl.SetPage(new ViewDrinkPage(new ViewDrinkVM(currentPageControl)));
            });
            ViewMenu = new Command(() =>
            {
                currentPageControl.SetPage(new ViewMenuPage(new ViewMenuVm(currentPageControl)));
            });
            AddReg = new Command(() =>
            {
                currentPageControl.SetPage(new RegPage(new AddRegVM(currentPageControl)));
            });
            ViewUser = new Command(() =>
            {
                currentPageControl.SetPage(new ViewUserPage(new ViewUserVM(currentPageControl)));
            });
        }
        
        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
