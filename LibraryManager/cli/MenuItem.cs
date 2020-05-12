using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class MenuItem
    {
        private Func<Menu> next;
        public int Index { get; }
        public string Text { get; }

        // TODO next might need to be a ref
        public MenuItem(int index, string text, Func<Menu> nextInterface)
        {
            this.Index = index;
            this.Text = text;
            this.next = nextInterface;
        }

        public Menu NextInterface()
        {
            return next();
        }
    }
}
