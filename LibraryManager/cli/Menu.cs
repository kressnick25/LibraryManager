using System;
using System.ComponentModel;

namespace LibraryManager
{
    // Defines a Menu interface
    public class Menu
    {
        const int HEADER_WIDTH = 40;

        private string MenuName;
        private MenuItem goBack;
        private DataStructures.List<MenuItem> selections;

        // Default contructor
        public Menu(string menuName, MenuItem previous)
        {
            this.MenuName = menuName;
            this.goBack = previous;
            this.selections = new DataStructures.List<MenuItem>();
        }

        public int SelectionSize 
        { 
            get { return selections.Length; } 
        }

        /// <summary>
        /// Add a Menu item as a child of this Menu
        /// </summary>
        /// <param name="menuItem">new menuitem to add</param>
        public void AddMenuItem(MenuItem menuItem)
        {
   
            selections.Add(menuItem);
        }

        private string menuHeader
        {
            get 
            {
                int totalEqualChars = HEADER_WIDTH - MenuName.Length;
                string halfWidth = new String('=', totalEqualChars / 2);
                return $"{halfWidth}{MenuName}{halfWidth}";
            }
        }

        /// <summary>
        /// Format the menu as a string as it would appear on screen.
        /// </summary>
        /// <returns>String of output</returns>
        public override string ToString()
        {
            // ===============Main Menu================
            string output = $"\n{this.menuHeader}\n";
            // 1. Staff login (repeating)
            foreach (MenuItem item in selections)
            {
                output += $"{item.Index}. {item.Text}\n";
            }
            // 0. return to main menu
            output += $"{goBack.Index}. {goBack.Text}\n";
            // ======================
            output += new string('=', HEADER_WIDTH) + "\n";
            // Please make a selection (1-5 or 0 to return to main menu)"
            output += $"Please make a selection (1-{SelectionSize} or 0 to {goBack.Text.ToLower()}):";

            return output;
        }

        /// <summary>
        /// Handle input from the user, pass controll to child MenuItem,
        /// which after handling functions, returns controll to this menu
        /// </summary>
        /// <returns>This or Parent menu</returns>
        public Menu HandleSelection()
        {
            // get input 
            int command = -1;
            while (command == -1)
            {
                int input;
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine($"Please enter a valid number (0-{SelectionSize}:");
                    continue;
                }
                if (input < 0 || input > SelectionSize)
                {
                    Console.WriteLine($"Please enter a number between 0 and {SelectionSize}:");
                    continue;
                }
                command = input;
            }

            if (command == 0)
            {
                return goBack.NextInterface();
            }
            foreach(MenuItem i in selections)
            {
                if (i.Index == command)
                {
                    return i.NextInterface();
                }
            }
            throw new Exception("MenuItem not found");
            //return selections.Get(command).NextInterface();
        }
    }
}
