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
    public class ViewProductVM : BaseVM
    {
        private List<Product> viewProduct;
        public cPage currentPageControl;
        public List<Grams> Grams { get; set; }  
        public Command AddProduct { get; set; }
        public Command Back { get; set; }

        public List<Product> ViewProduct
        {
            get => viewProduct;
            set
            {
                viewProduct = value;
                Signal();
            }
        }

        public ViewProductVM(cPage currentPageControl)
        {
            SQLModel sqlModel = SQLModel.GetInstance();
            ViewProduct = SQLModel.GetInstance().SelectProducrAndGrams();
            this.currentPageControl = currentPageControl;
            Init();
        }

        private void Init()
        {
            AddProduct = new Command(() =>
            {
                currentPageControl.SetPage(new AddProductPage(new AddProductVM(currentPageControl)));

            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });

        }
    }
}
