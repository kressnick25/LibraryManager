using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    /*
     * Models a library member
     */
    public class Member : WithKey
    {
        private HashSet<Movie> currentLoans; // TOTO STRUCT: SET
        public string Name { get; }
        public string Address { get; }
        public string PhoneNumber { get; }

        public string Key { get { return Name; } }
        public Member(string fullName, string address, string phoneNumber)
        {
            Name = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
            currentLoans = new HashSet<Movie>();
        }

        public HashSet<Movie> CurrentLoans
        {
            get { return currentLoans; }
        }

        public void addMovie(Movie movie)
        {
            if (currentLoans.Count == 10)
            {
                throw new Exception("User already has 10 movies on loan.");
            }
            if (!currentLoans.Add(movie))
            {
                // TODO insert movie name here
                throw new Exception("User already has a copy of THAT movie on loan.");
            }
        }

        // removes a movie from the Member
        public void removeMovie(Movie movie)
        {
            currentLoans.Remove(movie);
        }

        // Returns a Movie to the library by removing from Member
        public void returnMovie(Movie movie)
        {
            removeMovie(movie);
            movie.LoanedTo = null;
        }
    }
}
