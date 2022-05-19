using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Tool;
using Оформление_заказов.Pages;

namespace Оформление_заказов.ViewModel
{
    public class AddDrinkVM : BaseVM
    {
        public Drinks AddDrink { get; set; } 
        public Command SaveDrink { get; set; }
        public Command ViewDrink { get; set; }

        private cPage currentPageControl;
        public AddDrinkVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddDrink = new Drinks();
            InitCommandSpecial();
        }
        public AddDrinkVM(Drinks editDrink, cPage currentPageControl)
        {
            AddDrink = editDrink;
            this.currentPageControl = currentPageControl;
            InitCommandSpecial();
        }

        private void InitCommandSpecial()
        {
            SaveDrink = new Command(() => {
                var model = SQLModel.GetInstance();
                if (AddDrink.ID == 0)
                    model.Insert(AddDrink);
                else
                    model.Insert(AddDrink);
                currentPageControl.SetPage(new ViewDrinkPage(new ViewDrinkVM(currentPageControl)));
            });

        }
    }
}
