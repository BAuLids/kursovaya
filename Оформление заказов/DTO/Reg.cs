using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("registration")]
    public class Reg : BaseDTO
    {
        [c("data")]
        public DateTime Date { get; set; }
        [c("user_id")]
        public int UserId { get; set; }
        [c("number")]
        public string Nomer { get; set; }
        public User User { get; set; }
    }
}
