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
    public class ViewGramVM : BaseVM
    {
        private List<Grams> viewGrams;
        public cPage currentPageControl;
        public Command AddGrams { get; set; }
        public Command Back {get; set; }

        public List<Grams> ViewGrams
        {
            get => viewGrams;
            set
            {
                viewGrams = value;
                Signal();
            }
        }
        public Grams SelectGrams { get; set; }

        public ViewGramVM(cPage currentPageControl)
        {
            SQLModel sqlModel = SQLModel.GetInstance();
            ViewGrams = SQLModel.GetInstance().SelectGrams();
            this.currentPageControl = currentPageControl;
            Init();
        }

        private void Init()
        {
            AddGrams = new Command(() =>
            {
                currentPageControl.SetPage(new AddGramPage(new AddGramVM(currentPageControl)));

            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });

        }
    }
}
