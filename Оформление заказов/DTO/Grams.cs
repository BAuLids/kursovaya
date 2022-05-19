using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("grams")]
    public class Grams : BaseDTO
    {
        [c("title_grams")]
        public string Title { get; set; }
    }
}
