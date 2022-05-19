using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("drinks_reg")]
    public class AddDrinke : BaseDTO
    {
        [c("id_reg")]
        public int RegID { get; set; }  
        [c("id_drink")]
        public int DrinkID { get; set; }
        [c("amount")]
        public int Amount { get; set; }
    }
}
