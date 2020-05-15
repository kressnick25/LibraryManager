using LibraryManager.cli.handlers;
using System;
using System.Collections.Generic;
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
            return staffMenu;
        }

        public Menu UnRegisterMovie()
        {
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
