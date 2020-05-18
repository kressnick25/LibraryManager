﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LibraryManager
{
    class AuthHandler
    {
        private const string AUTH_FAILED_MSG = "Authentication failed.\nPress 0 to try again or 1 to return to the main menu.\n";
        private Menu staffMenu;
        private Menu mainMenu;
        private Menu memberMenu;

        public AuthHandler(Menu mainMenu, Menu staffMenu, Menu memberMenu)
        {
            this.staffMenu = staffMenu;
            this.mainMenu = mainMenu;
            this.memberMenu = memberMenu;
        }

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
                    Console.WriteLine($"Authentication failed. Username [{username}] not found.\nPress 0 to try again or 1 to return to the main menu.\n");
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

        private const string STAFF_USERNAME = "staff";
        private const string STAFF_PASSWORD = "today123"; // hash of password defined in assignment spec

        // Read line but does not show characters on screen for privacy/security
        private static string readObscuredPassword()
        {
            string output = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                output += key.KeyChar;
            }

            return output;
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netcore-3.1
        public static string GetMd5Hash(MD5 hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
