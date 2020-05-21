using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LibraryManager
{
    class AuthHandler
    {
        private const string AUTH_FAILED_MSG = "\nAuthentication failed.\nPress 0 to try again or 1 to return to the main menu.\n";
        private const string STAFF_USERNAME = "staff";
        private const string STAFF_PASSWORD = "today123";

        private Menu staffMenu;
        private Menu mainMenu;
        private Menu memberMenu;

        public AuthHandler(Menu mainMenu, Menu staffMenu, Menu memberMenu)
        {
            this.staffMenu = staffMenu;
            this.mainMenu = mainMenu;
            this.memberMenu = memberMenu;
        }

        /// <summary>
        /// Authenticate a staff user using the username "staff" and password "today123"
        /// </summary>
        /// <returns>Staff Menu</returns>
        public Menu StaffLoginHandler()
        {
            while (true)
            {
                string username, password;
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = readObscuredPassword();

                //return staffMenu; // TODO remove
                if (username == STAFF_USERNAME && password == STAFF_PASSWORD)
                {// credentials are correct, grant access
                    return staffMenu;
                } else
                {
                    Console.WriteLine(AUTH_FAILED_MSG);
                    char input = Console.ReadKey(true).KeyChar;
                    if (input == '1')
                    {
                        return mainMenu;
                    }
                    continue;
                }

        
            }

        }

        /// <summary>
        /// Authenticate a library Member using the members username and 4-digit passcode
        /// </summary>
        /// <returns>Member Menu</returns>
        public Menu MemberLoginHandler()
        {
            MemberCollection members = Program.members;
            ref Member currentUser = ref Program.currentUser;
            while (true)
            {
                string username, password;
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = readObscuredPassword();

                Member user;
                try
                {
                    user = members.FindUsername(username);
                } catch (Exception)
                {
                    Console.WriteLine($"\nAuthentication failed. Username [{username}] not found.\nPress 0 to try again or 1 to return to the main menu.\n");
                    char input = Console.ReadKey(true).KeyChar;
                    if (input == '1')
                    {
                        return mainMenu;
                    }
                    continue;
                }
                if (username == user.UserName && password == user.Password)
                {// credentials are correct, grant access
                    currentUser = user;
                    return memberMenu;
                }
                else
                {
                    Console.WriteLine(AUTH_FAILED_MSG);
                    char input = Console.ReadKey(true).KeyChar;
                    if (input == '1')
                    {
                        return mainMenu;
                    }
                    continue;
                }
            }
        }

        /// <summary>
        ///  Read a line from the console but do not show characters on screen for privacy/security
        /// </summary>
        /// <returns>String containing user input</returns>
        private static string readObscuredPassword()
        {
            string output = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (output.Length != 0)
                        // trim last char from output
                        output = output.Remove(output.Length - 1);
                }
                else
                {
                    output += key.KeyChar;
                }
            }

            return output;
        }
    }
}
