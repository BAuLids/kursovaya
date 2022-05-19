using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("menu_reg")]
    public class AddMenus : BaseDTO
    {
        [c("id_reg")]
        public int RegID { get; set; }
        [c("id_menu")]
        public int MenuID { get; set; }
        [c("amount")]
        public int Amount { get; set; }
    }
}
