using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("ingredients")]
    public class Product : BaseDTO
    {
        [c("title_ingr")]
        public string Title { get; set; }
        [c("grams_id_grams")]
        public int GramID { get; set; }

        public Grams Grams { get; set; }

    }
}
