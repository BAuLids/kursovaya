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
    public class ViewTypeVM : BaseVM
    {
        private List<Types> viewType;
        public cPage currentPageControl;
        public Command AddType { get; set; }
        public Command Back { get; set; }

        public List<Types> ViewType
        {
            get => viewType;
            set
            {
                viewType = value;
                Signal();
            }
        }

        public ViewTypeVM(cPage currentPageControl)
        {
            SQLModel sqlModel = SQLModel.GetInstance();
            ViewType = SQLModel.GetInstance().SelectType();
            this.currentPageControl = currentPageControl;
            Init();
        }

        private void Init()
        {
            AddType = new Command(() =>
            {
                currentPageControl.SetPage(new AddTupePage(new AddTypeVM(currentPageControl)));

            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });

        }
    }
}
