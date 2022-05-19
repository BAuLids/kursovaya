using Оформление_заказов.Pages;
using Оформление_заказов.Tool;

namespace Оформление_заказов.ViewModel
{
    public class StartVM : BaseVM
    {
        public Command Start { get; set; }
        public Command ViewUser { get; set; }
        public Command CreateRep { get; set; }

        public StartVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            Signal();
            Init();
        }
        public cPage currentPageControl;
        private void Init()
        {
            Start = new Command(() =>
            {
                currentPageControl.SetPage(new RegPage(new AddRegVM(currentPageControl)));
            });
            ViewUser = new Command(() =>
            {
                currentPageControl.SetPage(new ViewUserPage(new ViewUserVM(currentPageControl)));
            });
            CreateRep = new Command(() =>
            {
                currentPageControl.SetPage(new ReportsPage(new ReportVM(currentPageControl)));
            });
        }
    }
}
