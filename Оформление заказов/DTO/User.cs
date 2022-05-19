using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("user")]
    public class User : BaseDTO
    {
        [c("firstname")]
        public string Name { get; set; }
        [c("lastname")]
        public string LastName { get; set; }
        [c("nomer")]
        public string Nomer { get; set; }
    }
}
