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
    public class CreateCompVM : BaseVM
    {
        public Comp CreateComp { get; }
        public Command SaveComp { get; set; }
        public Menu CompMenu
        {
            get => compMenu;
            set
            {
                compMenu = value;
                Signal();
            }
        }
        public Product CompProduct
        {
            get => compProduct;
            set
            {
                compProduct = value;
                Signal();
            }
        }
        public List<Menu> Menus { get; set; }
        public List<Product> Products { get; set; }

        private cPage currentPageControl;

        private Menu compMenu;
        private Product compProduct;

        public CreateCompVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            CreateComp = new Comp();
            Init();
        }

        public CreateCompVM(Comp editComp, cPage currentPageControl)
        {
            CreateComp = editComp;
            this.currentPageControl = currentPageControl;
            Init();
            CompMenu = Menus.FirstOrDefault(s => s.ID == editComp.MenuID);
            CompProduct = Products.FirstOrDefault(s=>s.ID == editComp.IngrID);
        }

        private void Init()
        {
            Menus = SQLModel.GetInstance().SelectMenus(0, 100);
            Products = SQLModel.GetInstance().SelectProducts(0, 100);
            SaveComp = new Command(() => {
                if (CompMenu == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать блюдо из меню для продолжения");
                    return;
                }
                if (CompProduct == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать продукт для продолжения");
                    return;
                }
                CreateComp.MenuID = CompMenu.ID;
                CreateComp.IngrID = CompProduct.ID;
                var model = SQLModel.GetInstance();
                if (CreateComp.ID == 0)
                    model.Insert(CreateComp);
                else
                    model.Update(CreateComp);
                System.Windows.MessageBox.Show("Сохранение успешно");
            });
        }
    }
}
