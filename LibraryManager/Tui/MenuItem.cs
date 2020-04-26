using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Tui
{
    class MenuItem
    {
        public int Index { get; }
        public string Text { get; }
        public string ShortText { get; }
        public Menu NextInterface { get; }

        // TODO next might need to be a ref
        MenuItem(int index, string text, Menu next, string shortText = "EMPTY")
        {
            this.Index = index;
            this.Text = text;
            this.NextInterface = next;
            this.ShortText = shortText;
        }
    }
}
