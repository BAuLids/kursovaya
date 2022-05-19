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
    public class AddMenuVM : BaseVM
    {
        public Menu AddMenu { get; }
        public Command SaveMenu { get; set; }
        public Command Back { get; set; }
        public Types MenuType
        {
            get => menuType;
            set
            {
                menuType = value;
                Signal();
            }
        }

        public List<Types> Type { get; set; }

        private cPage currentPageControl;

        private Types menuType;

        public AddMenuVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddMenu = new Menu();
            Init();
        }

        public AddMenuVM(Menu editMenu, cPage currentPageControl)
        {
            AddMenu = editMenu;
            this.currentPageControl = currentPageControl;
            Init();
            MenuType = Type.FirstOrDefault(t => t.ID == editMenu.TypeID);
        }

        private void Init()
        {
            Type = SQLModel.GetInstance().SelectTypes(0, 100);
            SaveMenu = new Command(() => {
                if (MenuType == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать тип блюда для продолжения");
                    return;
                }
                AddMenu.TypeID = MenuType.ID;
                var model = SQLModel.GetInstance();
                if (AddMenu.ID == 0)
                    model.Insert(AddMenu);
                else
                    model.Update(AddMenu);
                System.Windows.MessageBox.Show("Сохранение успешно! Добавьте рецепт.");
            });
            Back = new Command(() => { 
                currentPageControl.Back();
            });
        }
    }
}
