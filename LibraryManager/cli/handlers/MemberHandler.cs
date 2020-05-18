using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LibraryManager
{
    class MemberHandler
    {
        private Menu memberMenu;
        public MemberHandler(Menu memberMenu)
        {
            this.memberMenu = memberMenu;
        }

        public Menu DisplayAllMovies()
        {
            Program.library.PrintMovies(true);
            return memberMenu;
        }

        public Menu BorrowMovie()
        {
            return memberMenu;
        }

        public Menu ReturnMovie()
        {
            return memberMenu;
        }

        public Menu ListOwnBorrowed()
        {
            return memberMenu;
        }

        public Menu ListMostPopular()
        {
            return memberMenu;
        }

    }
}
