using System;
using System.ComponentModel;

namespace LibraryManager
{
    class Program
    {
        // set to true to start program with some movies and users pre-initialised
        const bool PRE_SEED = false; 
        static Menu ExitProgram()
        {
            Environment.Exit(0);
            return null;
        }

        // init member library, members and current user instances
        public static MovieCollection library = new MovieCollection();
        public static MemberCollection members = new MemberCollection();
        public static Member currentUser = null;

        static void Main(string[] args)
        {            
            // Init menus
            Menu mainMenu = new Menu("Main Menu", new MenuItem(0, "Exit", ExitProgram));
            Menu staffMenu = new Menu("Staff Menu", new MenuItem(0, "Return to main menu", () => mainMenu));
            Menu memberMenu = new Menu("Member Menu", new MenuItem(0, "Return to main menu", () => mainMenu));

            // Init interface handlers
            AuthHandler auth = new AuthHandler(mainMenu, staffMenu, memberMenu);
            StaffHandler staffHandler = new StaffHandler(staffMenu);
            MemberHandler memberHandler = new MemberHandler(memberMenu);

            // Init menu selection items
            mainMenu.AddMenuItem(new MenuItem(1, "Staff Login", auth.StaffLoginHandler));
            mainMenu.AddMenuItem(new MenuItem(2, "Member Login", auth.MemberLoginHandler));
            //mainMenu.AddMenuItem(new MenuItem(0, "Exit", ExitProgram));

            staffMenu.AddMenuItem(new MenuItem(1, "Add a new movie DVD", staffHandler.RegisterMovie));
            staffMenu.AddMenuItem(new MenuItem(2, "Remove a movie DVD", staffHandler.UnRegisterMovie));
            staffMenu.AddMenuItem(new MenuItem(3, "Register a new Member", staffHandler.RegisterMember));
            staffMenu.AddMenuItem(new MenuItem(4, "Find a registered member's phone number", staffHandler.FindMember));

            memberMenu.AddMenuItem(new MenuItem(1, "Display all movies", memberHandler.DisplayAllMovies));
            memberMenu.AddMenuItem(new MenuItem(2, "Borrow a movie DVD", memberHandler.BorrowMovie));
            memberMenu.AddMenuItem(new MenuItem(3, "Return a movie DVD", memberHandler.ReturnMovie));
            memberMenu.AddMenuItem(new MenuItem(4, "List current borrowed movie DVDs", memberHandler.ListOwnBorrowed));
            memberMenu.AddMenuItem(new MenuItem(5, "Display top 10 most popular movies", memberHandler.ListMostPopular));

            // Pre seed library and members with some existing values
            if (PRE_SEED)
            {
                members.Add(new Member("Tim", "Watts", "29 Address Close, Newtown", "0456666777", "0000"));
                library.Add(
                    new Movie
                    (
                        "Star Wars",
                        "George Lucas",
                        "Science Fiction",
                        Movie.ClassificationEnum["PG"],
                        new DateTime(1977, 10, 27),
                        new string[] { "Mark Hamill", "Carrie Fischer", "Harrison Ford" }
                    )
                );
                library.Add(
                    new Movie
                    (
                        "Forrest Gump",
                        "Robert Zemeckis",
                        "Drama",
                        Movie.ClassificationEnum["PG"],
                        new DateTime(1994, 11, 17),
                        new string[] { "Tom Hanks", "Robin Wright", "Sally Field" }
                    )
                );
                library.Add(
                    new Movie
                    (
                        "Toy Story",
                        "Brad Bird",
                        "Animation",
                        Movie.ClassificationEnum["G"],
                        new DateTime(1999, 12, 01),
                        new string[] { "Tom Hanks", "Tim Allen" }
                    )
                );
            }

            // Display start
            Console.WriteLine("Welcome to the Community Library");
            Menu currentMenu = mainMenu;

            // Main program loop
            while (true)
            {
                Console.WriteLine(currentMenu.ToString());
                currentMenu = currentMenu.HandleSelection();
            }
        }
    }
}
