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
    public  class AddUserVM : BaseVM
    {
        public User AddUser { get; set; }
        public Command SaveUser { get; set; }
        public Command ViewUser { get; set; }

        private cPage currentPageControl;
        public AddUserVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddUser = new User();
            InitCommandSpecial();
        }
        public AddUserVM(User editUser, cPage currentPageControl)
        {
            AddUser = editUser;
            this.currentPageControl = currentPageControl;
            InitCommandSpecial();
        }

        private void InitCommandSpecial()
        {
            SaveUser = new Command(() => {
                var model = SQLModel.GetInstance();
                if (AddUser.ID == 0)
                    model.Insert(AddUser);
                else
                    model.Insert(AddUser);
                currentPageControl.SetPage(new ViewUserPage(new ViewUserVM(currentPageControl)));
            });
            ViewUser = new Command(() =>
            {
                currentPageControl.SetPage(new ViewUserPage(new ViewUserVM(currentPageControl)));
            });
        }
    }
}
