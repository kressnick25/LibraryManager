using LibraryManager.cli.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace LibraryManager 
{ 
    class StaffHandler
    {
        private Menu staffMenu;
        public StaffHandler(Menu staffMenu)
        {
            this.staffMenu = staffMenu;
        }

        public Menu RegisterMovie()
        {
            while (true)
            {
                // build string for genre options
                string genreString = "Genre:\n" + Genre.SelectionList();

                string[] inputs =
                    InputHandler.GetInputs(
                        new string[] { 
                            "Title", 
                            "Year (YYYY-MM-DD)", 
                            "Director", 
                            "Classification ['G', 'PG', 'M', 'MA']", 
                            genreString, 
                            "Starring [seperated by a comma]"
                        },
                        "REGISTER MOVIE\n"
                        );
                DateTime releaseDate;
                string[] starring;
                // Parse dateinput to DateTime
                try
                {
                    DateTime.TryParse(inputs[1], out releaseDate);
                } catch (Exception)
                {
                    Console.WriteLine("Invalid Date format entered. Please try again.");
                    continue;
                }
                // Parse starring input to seperate strings
                try
                {
                     starring = inputs[5].Split(',');
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid starring format. Please try again.");
                    continue;
                }
                // Create new Movie object and add to library
                try
                {
                    Movie newMovie = new Movie(inputs[0], inputs[2], inputs[4], inputs[3], releaseDate, starring);
                    Program.library.Add(newMovie);
                }
                catch (Exception)
                {
                    Console.Write("Failed to add new movie. Please try again.");
                }

                // TODO handle voluntary return to main
                break;
            }

            return staffMenu;
        }

        public Menu UnRegisterMovie()
        {
            while (true)
            {
                string titleInput =
                    InputHandler.GetInputs("Movie Title", "REMOVE MOVIE\n");
     
                try
                {
                    Program.library.Delete(new Movie(titleInput));
                } catch(Exception)
                {
                    Console.WriteLine($"Failed to delete movie [{titleInput}]. Please 0 to try again on enter 1 to return to Staff Menu.");
                    if (Console.ReadKey(true).KeyChar == '1')
                        break;
                }
                break;
            }
            return staffMenu;
        }

        public Menu RegisterMember()
        {
            while (true) {
                string[] inputs = 
                    InputHandler.GetInputs(new string[] { "Firstname", "Lastname", "Address", "PhoneNumber", "Password [4 digits]" },
                                           "REGISTER MEMBER\n");
                // verify password format
                if (inputs[4].Length != 4)
                {
                    Console.WriteLine("Incorrect password length. Please try again.");
                    continue;
                }
                // Check all chars in password are numbers
                if (!inputs[4].All(Char.IsDigit))
                {
                    Console.WriteLine("Password must contain only digits. Please try again.");
                    continue;
                }
                // Create new Member object and add to memberCollection
                try
                {
                    Member newMember = new Member(inputs);
                    Program.members.Add(newMember);
                    break;
                } catch(Exception e)
                {
                    Console.WriteLine("ERROR: Failed to add new Member to MemberCollection.");
                }
            }

            return staffMenu;
        }

        public Menu FindMember()
        {
            while(true)
            {
                try
                {
                    string input = InputHandler.GetInputs("Full name", "MEMBER PHONE NUMBER LOOKUP\n");
                    if (input == "0")
                        break;
                    Member member = Program.members.Find(input);
                    Console.WriteLine($"Member with name '{input}', phone number: {member.PhoneNumber}");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("User with that name was not found. " +
                                        "\nPlease try again or enter 0 to return to Menu.");
                }
            }
           

            return staffMenu;
        }
    }
}
