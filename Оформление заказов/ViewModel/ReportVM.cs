using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;
using Оформление_заказов.Pages;

namespace Оформление_заказов.ViewModel
{
    public class ReportVM : BaseVM
    {
        public Command OpenMenu { get; set; }
        public Command OpenReg { get; set; }
        public Command Back { get; set; }

        public ReportVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            Signal();
            Init();
        }
        public cPage currentPageControl;
        private void Init()
        {
            OpenMenu = new Command(() =>
            {
                currentPageControl.SetPage(new CreateReportMenuPage());
            });
            OpenReg = new Command(() =>
            {
                currentPageControl.SetPage(new CreateReportPage(new CreateReportRegVM(currentPageControl)));
            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });
        }
    }
}
