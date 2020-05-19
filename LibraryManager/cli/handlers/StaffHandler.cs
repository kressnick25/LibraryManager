using LibraryManager.cli.handlers;
using System;
using System.Collections.Generic;
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
                    InputHandler.GetInputs(new string[] { "Title", "Year (YYYY-MM-DD)", "Director", "Classification ['G', 'PG', 'M', 'MA']", genreString, "Starring [seperated by a comma]"});
                DateTime releaseDate;
                string[] starring;
                try
                {
                    DateTime.TryParse(inputs[1], out releaseDate);
                } catch (Exception)
                {
                    Console.WriteLine("Invalid Date format entered. Please try again.");
                    continue;
                }
                try
                {
                     starring = inputs[5].Split(',');
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid starring format. Please try again.");
                    continue;
                }
                try
                {
                    Movie newMovie = new Movie(inputs[0], inputs[2], inputs[4], inputs[3], releaseDate, starring);
                    Program.library.Add(newMovie);
                }
                catch (Exception)
                {
                    Console.Write("Failed to add new movie. Please try again.");
                }

                break;
            }

            return staffMenu;
        }

        public Menu UnRegisterMovie()
        {
            throw new NotImplementedException();
            return staffMenu;
        }

        public Menu RegisterMember()
        {
            //public Member(string givenName, string surname, string address, string phoneNumber, string password)
            while (true) {
                string[] inputs = 
                    InputHandler.GetInputs(new string[] { "Firstname", "Lastname", "Address", "PhoneNumber", "Password" },
                                           "Please enter new Member details: ");
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
                    string input = InputHandler.GetInputs("Full name", "Member phone number lookup:");
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
