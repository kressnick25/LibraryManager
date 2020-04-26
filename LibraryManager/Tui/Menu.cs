using LibraryManager.DataStructures;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;

namespace LibraryManager.Tui
{
    class Menu
    {
        const int HEADER_WIDTH = 40;

        private string MenuName;
        private string HeaderMessage;
        private MenuItem goBack;
        public DataStructures.List<MenuItem> Selections { get; }

        Menu(string menuName, MenuItem previous, string headerMessage = null)
        {
            this.MenuName = menuName;
            this.HeaderMessage = headerMessage;
            this.goBack = previous;
        }

        public int SelectionSize 
        { 
            get { return Selections.Length; } 
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

        public string toString()
        {
            // Welcome to the community library (optional)
            // ===============Main Menu================
            string output = $"{HeaderMessage} {this.menuHeader}\n";
            // 1. Staff login (repeating)
            foreach (MenuItem item in Selections)
            {
                output += $"{item.Index}. {item.Text}\n";
            }
            // 0. return to main menu
            output += $"{goBack.Index}. {goBack.Text}\n";
            // ======================
            output += new string('=', HEADER_WIDTH) + "\n";
            // Please make a selection (1-5 or 0 to return to main menu)"
            output += $"Please make a selection (1-${SelectionSize} or 0 to ${goBack.ShortText}):";

            return output;
        }

        // Returns the next menu to go to after selection is given
        public Menu HandleSelection()
        {
            // get input 
            int command = -1;
            while (command == -1)
            {
                int input;
                if (!Int32.TryParse(Console.ReadLine(), out input))
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

            return Selections.Get(command).NextInterface;
        }
    }
}
