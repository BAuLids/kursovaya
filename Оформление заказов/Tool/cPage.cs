using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Оформление_заказов.Pages;

namespace Оформление_заказов.Tool
{
    public class cPage
    {
        Stack<Page> pages = new Stack<Page>();

        public Page Page { get; internal set; }
        public event EventHandler PageChanged;
        internal void SetPage(Page loginUser)
        {
            if (Page != null)
                pages.Push(Page);
            Page = loginUser;
            PageChanged?.Invoke(this, new EventArgs());
        }

        internal void Back()
        {
            if (pages.Count > 0)
                Page = pages.Pop();
            else
                Page = null;
            PageChanged?.Invoke(this, new EventArgs());
        }
    }
}
