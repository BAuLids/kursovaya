using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Tool;
using Оформление_заказов.Pages;
using System.Windows;

namespace Оформление_заказов.ViewModel
{
    public class AddRegVM : BaseVM
    {
        public Reg AddReg { get; }
        public Command SaveReg { get; set; }
        public Command Back { get; set; }
        public User RegUser
        {
            get => regUser;
            set
            {
                regUser = value;
                Signal();
            }
        }

        public List<User> Users { get; set; }

        private cPage currentPageControl;

        private User regUser;

        public AddRegVM(cPage currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            AddReg = new Reg { Date = DateTime.Now };
            Init();
        }

        public AddRegVM(Reg editReg, cPage currentPageControl)
        {
            AddReg = editReg;
            this.currentPageControl = currentPageControl;
            Init();
            RegUser = Users.FirstOrDefault(s => s.ID == editReg.UserId);
        }

        private void Init()
        {
            Users = SQLModel.GetInstance().SelectUsers(0, 100);
            SaveReg = new Command(() => {
                if (RegUser == null)
                {
                    MessageBox.Show("Нужно выбрать клиента для продолжения");
                    return;
                }
                AddReg.UserId = RegUser.ID;
                var model = SQLModel.GetInstance();
                if (AddReg.ID == 0)
                    model.Insert(AddReg);
                else
                    model.Update(AddReg);
                MessageBox.Show("Заказ создан! Добавьте позиции к блюду");
            });
            Back = new Command(() => {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });
        }
    }
}
