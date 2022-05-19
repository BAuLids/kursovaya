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
    public class AddProductVM : BaseVM
    {
        public Product AddProduct { get; }
        public Command SaveProduct { get; set; }
        public Command Back { get; set; }
        public Grams ProductGrams 
        {
            get => productsGram;
            set
            {
                productsGram = value;
                Signal();
            }
        }

        public List<Grams> Grams { get; set; }

        private cPage currentPageControl;

        private Grams productsGram;

        public AddProductVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddProduct = new Product();
            Init();
        }

        public AddProductVM(Product editProduct, cPage currentPageControl)
        {
            AddProduct = editProduct;
            this.currentPageControl = currentPageControl;
            Init();
            ProductGrams = Grams.FirstOrDefault(s => s.ID == editProduct.GramID);
        }

        private void Init()
        {
            Grams = SQLModel.GetInstance().SelectGram(0, 100);
            SaveProduct = new Command(() => {
                if (ProductGrams == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать систему измерения для продолжения");
                    return;
                }
                AddProduct.GramID = ProductGrams.ID;
                var model = SQLModel.GetInstance();
                if (AddProduct.ID == 0)
                    model.Insert(AddProduct);
                else
                    model.Update(AddProduct);
                currentPageControl.SetPage(new ViewProductPage(new ViewProductVM(currentPageControl)));
            });
            Back = new Command(() =>
            {
                currentPageControl.Back();
            });
        }
    }
}
