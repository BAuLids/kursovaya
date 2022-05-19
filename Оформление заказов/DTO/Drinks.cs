using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("drinks")]
    public class Drinks : BaseDTO
    {
        [c("title_drink")]
        public string Title { get; set; }
        [c("price_drink")]
        public int Price { get; set; }
    }
}
