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
    public class AddMenu : BaseVM
    {
        public AddMenus AddComp { get; }
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
        public Menu CompMenu
        {
            get => compMenu;
            set
            {
                compMenu = value;
                Signal();
            }
        }
        public List<Reg> Regs { get; set; }
        public List<Menu> Menus { get; set; }

        private cPage currentPageControl;

        private Reg compReg;
        private Menu compMenu;

        public AddMenu(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddComp = new AddMenus();
            Init();
        }

        public AddMenu(AddMenus editMenu, cPage currentPageControl)
        {
            AddComp = editMenu;
            this.currentPageControl = currentPageControl;
            Init();
            RegDrink = Regs.FirstOrDefault(s => s.ID == editMenu.RegID);
            compMenu = Menus.FirstOrDefault(s => s.ID == editMenu.MenuID);
        }

        private void Init()
        {
            Regs = SQLModel.GetInstance().SelectReg(0, 100);
            Menus = SQLModel.GetInstance().SelectMenus(0, 100);
            SaveComp = new Command(() => {
                if (RegDrink == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать заказ для продолжения");
                    return;
                }
                if (CompMenu == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать блюдо для продолжения");
                    return;
                }
                AddComp.RegID = RegDrink.ID;
                AddComp.MenuID = CompMenu.ID;
                var model = SQLModel.GetInstance();
                if (AddComp.ID == 0)
                    model.Insert(AddComp);
                else
                    model.Update(AddComp);
                System.Windows.MessageBox.Show("Позиция добавлена");
            });
        }
    }
}
