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
    public class ViewUserVM : BaseVM
    {
        private List<User> viewUser;
        public cPage currentPageControl;
        public Command AddUser { get; set; }
        public Command Back { get; set; }

        public List<User> ViewUser
        {
            get => viewUser;
            set
            {
                viewUser = value;
                Signal();
            }
        }

        public ViewUserVM(cPage currentPageControl)
        {
            SQLModel sqlModel = SQLModel.GetInstance();
            ViewUser = SQLModel.GetInstance().SelectUser();
            this.currentPageControl = currentPageControl;
            Init();
        }

        private void Init()
        {
            AddUser = new Command(() =>
            {
                currentPageControl.SetPage(new AddUserPage(new AddUserVM(currentPageControl)));

            });
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });

        }
    }
}
