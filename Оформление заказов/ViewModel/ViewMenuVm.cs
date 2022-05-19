using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Pages;
using Оформление_заказов.Tool;

namespace Оформление_заказов.ViewModel
{
    public class ViewMenuVm : BaseVM
    {
        private List<Menu> viewMenu;
        public cPage currentPageControl;
        public List<Types> Type { get; set; }
        public Command AddMenu { get; set; }
        public Command Back { get; set; }

        public List<Menu> ViewMenu
        {
            get => viewMenu;
            set
            {
                viewMenu = value;
                Signal();
            }
        }
        public Product SelectProduct { get; set; }

        public ViewMenuVm(cPage currentPageControl)
        {
            SQLModel sqlModel = SQLModel.GetInstance();
            ViewMenu = SQLModel.GetInstance().SelectMenuAndType();
            this.currentPageControl = currentPageControl;
            Init();
        }

        private void Init()
        {
            AddMenu = new Command(() =>
            {
                currentPageControl.SetPage(new AddNewMenuPage(new AddMenuVM(currentPageControl)));

            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });

        }
    }
}
