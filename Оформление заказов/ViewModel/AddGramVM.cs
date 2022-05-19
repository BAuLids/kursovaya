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
    public class AddGramVM : BaseVM
    {
        public Grams AddGrams { get; set; }
        public Command SaveGram { get; set; }
        public Command ViewGram { get; set;}

        private cPage currentPageControl;
        public AddGramVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddGrams = new Grams();
            InitCommandSpecial();
        }
        public AddGramVM(Grams editGram, cPage currentPageControl)
        {
            AddGrams = editGram;
            this.currentPageControl = currentPageControl;
            InitCommandSpecial();
        }

        private void InitCommandSpecial()
        {
            SaveGram = new Command(() => {
                var model = SQLModel.GetInstance();
                if (AddGrams.ID == 0)
                    model.Insert(AddGrams);
                else
                    model.Insert(AddGrams);
                currentPageControl.SetPage(new ViewGramPage(new ViewGramVM(currentPageControl)));
            });
            
        }
    }
}
