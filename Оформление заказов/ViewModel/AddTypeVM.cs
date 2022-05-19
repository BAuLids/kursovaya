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
    public class AddTypeVM
    {
        public Types AddType { get; set; }   
        public Command SaveType { get; set; }
        public Command Back { get; set; }

        private cPage currentPageControl;
        public AddTypeVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddType = new Types();
            InitCommandSpecial();
        }
        public AddTypeVM(Types editType, cPage currentPageControl)
        {
            AddType = editType;
            this.currentPageControl = currentPageControl;
            InitCommandSpecial();
        }

        private void InitCommandSpecial()
        {
            SaveType = new Command(() => {
                var model = SQLModel.GetInstance();
                if (AddType.ID == 0)
                    model.Insert(AddType);
                else
                    model.Insert(AddType);
                currentPageControl.SetPage(new ViewTypePage(new ViewTypeVM(currentPageControl)));
            });
            Back = new Command(() =>
            {
                currentPageControl.Back();
            });
        }
    }
}
