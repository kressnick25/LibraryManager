using LibraryManager.cli.handlers;
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
            while (true)
            {
                string titleInput = InputHandler.GetInputs("Movie Title", "BORROW MOVIE\n");

                try
                {
                    Program.library.Get(titleInput).LoanTo(Program.currentUser);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed to add movie [{titleInput}] to user [{Program.currentUser.UserName}].\nPress 0 to try again or 1 to return to member menu.");
                    if (Console.ReadKey(true).KeyChar == '1')
                        break;
                }
                break;
            }
            return memberMenu;
        }

        public Menu ReturnMovie()
        {
            while (true)
            {
                string titleInput = InputHandler.GetInputs("Movie Title", "RETURN MOVIE\n");

                try
                {
                    Program.currentUser.ReturnMovieToLibrary(titleInput);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed to return movie [{titleInput}] from user [{Program.currentUser.UserName}].\nPress 0 to try again or 1 to return to member menu.");
                    if (Console.ReadKey(true).KeyChar == '1')
                        break;
                }
                break;
            }
            return memberMenu;
        }

        public Menu ListOwnBorrowed()
        {
            Console.WriteLine($"ALL BORROWED ITEMS FOR USER {Program.currentUser.UserName}");
            Program.currentUser.PrintLoans();
            return memberMenu;
        }

        public Menu ListMostPopular()
        {   

            return memberMenu;
        }

    }
}
