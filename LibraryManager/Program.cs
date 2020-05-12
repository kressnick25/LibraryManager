using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class Program
    {
        static Menu ExitProgram()
        {
            Environment.Exit(0);
            return null;
        }

        public static MovieCollection library = new MovieCollection(null);
        public static MemberCollection members = new MemberCollection();
        public static Member currentUser = null;

        static void Main(string[] args)
        {
            // Init Member and Movie collections
            

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

            // Display start
            Console.WriteLine("Welcome to the Community Library");

            // Main program loop
            Menu currentMenu = mainMenu;
            while (true)
            {
                Console.WriteLine(currentMenu.ToString());
                currentMenu = currentMenu.HandleSelection();
            }
        }
    }
}
