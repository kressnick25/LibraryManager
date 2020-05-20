using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using BSTreeClass;
using System.Diagnostics.CodeAnalysis;

namespace LibraryManager
{
    /*
     * Models a library member
     */
    public class Member : WithKey
    {
        private MovieCollection currentLoans;
        private string givenName;
        private string surname;
        public string Password { get; }
        public string Address { get; }
        public string PhoneNumber { get; }

        public string Key { 
            get 
            { 
                return Name; 
            } 
        }
        public string Name
        {
            get
            {
                return $"{givenName} {surname}";
            }
        }
        public string UserName 
        {
            get 
            {
                return $"{surname}{givenName}";
            } 
        }
        public Member(string givenName, string surname, string address, string phoneNumber, string password)
        {
            this.givenName = givenName;
            this.surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
            currentLoans = new MovieCollection();
            this.Password = password;
        }

        public Member(string[] details)
        {
            if (details.Length < 5)
            {
                throw new ArgumentException("Not enough inputs provided for Member.");
            } 
            this.givenName = details[0];
            this.surname = details[1];
            Address = details[2];
            PhoneNumber = details[3];
            currentLoans = new MovieCollection();
            this.Password = details[4];
        }

        public void AddMovie(Movie movie)
        {
            if (currentLoans.Count() == 10)
                throw new Exception("User already has 10 movies on loan.");
            // Get Movie should throw an exception, otherwise member already has movie on loan
            try
            {
                GetMovie(movie.Title);
                throw new ArgumentException();
            }
            catch(KeyNotFoundException)
            {
                // Correct behavior
                currentLoans.Add(movie);
            }
            catch(ArgumentException)
            {
                throw new ArgumentException($"Movie with title [{movie.Title}] already on loan to this user [{Key}].");
            }
        }

        public Movie GetMovie(string title)
        {
            return currentLoans.Get(title);
        }
        

        // removes a movie from the Member
        public void removeMovie(Movie movie)
        {
            currentLoans.Delete(movie.Title);
        }

        // Returns a Movie to the library by removing from Member
        public void ReturnMovieToLibrary(string title)
        {
            Program.library.Get(title).LoanedTo = null;
            Program.library.Get(title).CoppiesAvailable++;
            removeMovie(this.GetMovie(title));
        }

        public void ReturnMovieToLibrary(Movie movie)
        {
            this.removeMovie(movie);
            movie.LoanedTo = null;
        }

        public void PrintLoans()
        {
            currentLoans.PrintMovies(true);
        }
    }
}
