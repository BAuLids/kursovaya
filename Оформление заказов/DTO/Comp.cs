using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("composition")]
    public class Comp : BaseDTO
    {
        [c("id_menu")]
        public int MenuID   { get; set; }
        [c("id_ingr")]
        public int IngrID { get; set; }
        [c("amount")]
        public int Amount { get; set; }
    }
}
