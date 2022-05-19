using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("menu")]
    public class Menu : BaseDTO
    {
        [c("title")]
        public string Title { get; set; }
        [c("price")]
        public int Price { get; set; } 
        [c("description")]
        public string Description { get; set; }
        [c("type_id_type")]
        public int TypeID { get; set; }
        public Types Types { get; set; }
    }
}
