using LibraryManager.cli.handlers;
using System;

namespace LibraryManager
{
    class MemberHandler
    {
        private Menu memberMenu;
        public MemberHandler(Menu memberMenu)
        {
            this.memberMenu = memberMenu;
        }

        /// <summary>
        /// Display all the information about all the movie DVD's in alphabetical order of the current movie title.
        /// </summary>
        /// <returns>Member Menu</returns>
        public Menu DisplayAllMovies()
        {
            Program.library.PrintMovies();
            return memberMenu;
        }

        /// <summary>
        /// Borrow a movie DVD from the community library, given the title of the movie DVD
        /// </summary>
        /// <returns>Member Menu</returns>
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

        /// <summary>
        /// Return a movie DVD to the community library, given the title of the movie DVD
        /// </summary>
        /// <returns>Member Menu</returns>
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

        /// <summary>
        /// List current movie DVD's that are currently being held by the registerd member
        /// </summary>
        /// <returns>Member Menu</returns>
        public Menu ListOwnBorrowed()
        {
            Console.WriteLine($"ALL BORROWED ITEMS FOR USER {Program.currentUser.UserName}");
            Program.currentUser.PrintLoans();
            return memberMenu;
        }

        /// <summary>
        /// Display the top 10 most frequently borrowed movie DVDs by the members in the
        /// descending order of frequency.
        /// </summary>
        /// <returns></returns>
        public Menu ListMostPopular()
        {
            if (Program.library.Count() == 0)
            {
                Console.WriteLine("No movies currently in Library.");
            }
            else
            {
                Movie[] m = Program.library.ToArray();
                Algorithms.QuickSort(m, 0, m.Length - 1);

                // iterate through lenght of array or first 10 items, whichever smaller
                for (int i = 0; i < Math.Min(10, m.Length); i++)
                {
                    Console.WriteLine($"{i + 1}: {m[i].Title} -- borrowed {m[i].LoanedCount} times");
                }
            }

            return memberMenu;
        }

    }
}
