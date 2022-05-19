using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.Tool;

namespace Оформление_заказов.DTO
{
    [t("type")]
    public class Types : BaseDTO
    {
        [c("title_type")]
        public string Title { get; set; }   
    }
}
