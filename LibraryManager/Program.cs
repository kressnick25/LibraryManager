using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class Program
    {
        static Menu ExitProgram(int status = 0)
        {
            Environment.Exit(status);
            return null;
        }
        static void Main(string[] args)
        {
            // Init Member and Movie collections
            MovieCollection library = new MovieCollection();
            MemberCollection members = new MemberCollection();

            // Init menus
            Menu mainMenu = new Menu("Main Menu", null, "Welcome to the Community Library");
            Menu staffMenu = new Menu("Staff Menu", new MenuItem(0, "Return to main menu", mainMenu));
            Menu memberMenu = new Menu("Member Menu", new MenuItem(0, "Return to main menu", mainMenu));

            // Init menu selection items
            mainMenu.AddMenuItem(new MenuItem(1, "Staff Login", Auth.StaffLoginHandler(staffMenu, mainMenu)));
            mainMenu.AddMenuItem(new MenuItem(2, "Member Login", Auth.MemberLoginHandler(memberMenu, mainMenu, members)));
            mainMenu.AddMenuItem(new MenuItem(0, "Exit", ExitProgram()));

            staffMenu.AddMenuItem(new MenuItem(1, "Add a new movie DVD", null));
            staffMenu.AddMenuItem(new MenuItem(2, "Remove a movie DVD", null));
            staffMenu.AddMenuItem(new MenuItem(3, "Register a new Member", null));
            staffMenu.AddMenuItem(new MenuItem(4, "Find a registered member's phone number", null));

            memberMenu.AddMenuItem(new MenuItem(1, "Display all movies", null));
            memberMenu.AddMenuItem(new MenuItem(2, "Borrow a movie DVD", null));
            memberMenu.AddMenuItem(new MenuItem(3, "Return a movie DVD", null));
            memberMenu.AddMenuItem(new MenuItem(4, "List current borrowed movie DVDs", null));
            memberMenu.AddMenuItem(new MenuItem(4, "Display top 10 most popular movies", null));

            // Main program loop
            Menu currentMenu = mainMenu;
            while (true)
            {
                currentMenu.ToString();
                currentMenu = currentMenu.HandleSelection();
            }
        }
    }
}
