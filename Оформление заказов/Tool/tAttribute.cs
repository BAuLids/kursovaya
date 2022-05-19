using System;

namespace Оформление_заказов.Tool
{
    internal class tAttribute : Attribute
    {
        public string Table { get; }
        public tAttribute(string table)
        {
            Table = table;
        }
    }
}
