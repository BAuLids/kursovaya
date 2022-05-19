using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Pages;

namespace Оформление_заказов.ViewModel
{
    public class ViewDrinkVM : BaseVM
    {
        private List<Drinks> viewDrink;
        public cPage currentPageControl;
        public Command AddDrink { get; set; }
        public Command Back { get; set; }

        public List<Drinks> ViewDrink
        {
            get => viewDrink;
            set
            {
                viewDrink = value;
                Signal();
            }
        }
        public Drinks SelectDrinks { get; set; }

        public ViewDrinkVM(cPage currentPageControl)
        {
            SQLModel sqlModel = SQLModel.GetInstance();
            ViewDrink = SQLModel.GetInstance().SelectDrink();
            this.currentPageControl = currentPageControl;
            Init();
        }

        private void Init()
        {
            AddDrink = new Command(() =>
            {
                currentPageControl.SetPage(new AddDrinkPage(new AddDrinkVM(currentPageControl)));

            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });

        }
    }
}
