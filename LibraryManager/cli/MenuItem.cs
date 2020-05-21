using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LibraryManager
{
    public class MenuItem
    {
        private Func<Menu> next;
        public int Index { get; }
        public string Text { get; }

        // Default contstructor
        public MenuItem(int index, string text, Func<Menu> nextInterface)
        {
            this.Index = index;
            this.Text = text;
            this.next = nextInterface;
        }

        // Execute the next Menu interface
        public Menu NextInterface()
        {
            return next();
        }
    }
}
