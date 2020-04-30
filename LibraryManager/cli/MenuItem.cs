using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class MenuItem
    {
        public int Index { get; }
        public string Text { get; }
        public Menu NextInterface { get; }

        // TODO next might need to be a ref
        public MenuItem(int index, string text, Menu next)
        {
            this.Index = index;
            this.Text = text;
            this.NextInterface = next;
        }
    }
}
