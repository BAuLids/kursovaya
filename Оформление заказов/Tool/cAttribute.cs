using System;

namespace Оформление_заказов.Tool
{
    internal class cAttribute : Attribute
    {
        public string Column { get; }
        public cAttribute(string column)
        {
            Column = column;
        }
    }
}
