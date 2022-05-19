using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Tool;
using Оформление_заказов.Pages;
using System.Windows;

namespace Оформление_заказов.ViewModel
{
    public class AddDrink : BaseVM
    {
        public AddDrinke AddComp { get; }
        public Command SaveComp { get; set; }
        public Reg RegDrink
        {
            get => compReg;
            set
            {
                compReg = value;
                Signal();
            }
        }
        public Drinks CompDrink
        {
            get => compDrink;
            set
            {
                compDrink = value;
                Signal();
            }
        }
        public List<Reg> Regs { get; set; }
        public List<Drinks> Drink { get; set; }

        private cPage currentPageControl;

        private Reg compReg;
        private Drinks compDrink;

        public AddDrink(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddComp = new AddDrinke();
            Init();
        }

        public AddDrink(AddDrinke edirDrinks, cPage currentPageControl)
        {
            AddComp = edirDrinks;
            this.currentPageControl = currentPageControl;
            Init();
            RegDrink = Regs.FirstOrDefault(s => s.ID == edirDrinks.RegID);
            CompDrink = Drink.FirstOrDefault(s=>s.ID == edirDrinks.DrinkID);
        }
        
        private void Init()
        {
            Regs = SQLModel.GetInstance().SelectReg(0, 100);
            Drink = SQLModel.GetInstance().SelectDrink(0, 100);
            SaveComp = new Command(() => {
                if (RegDrink == null)
                {
                    MessageBox.Show("Нужно выбрать заказ для продолжения");
                    return;
                }
                if (CompDrink == null)
                {
                    MessageBox.Show("Нужно выбрать напиток для продолжения");
                    return;
                }
                AddComp.RegID = RegDrink.ID;
                AddComp.DrinkID = CompDrink.ID;
                var model = SQLModel.GetInstance();
                if (AddComp.ID == 0)
                    model.Insert(AddComp);
                else
                    model.Update(AddComp);
                MessageBox.Show("Позиция добавлена");
            });
        }
    }
}
