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

        // Default constructor
        public Member(string givenName, string surname, string address, string phoneNumber, string password)
        {
            this.givenName = givenName;
            this.surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
            currentLoans = new MovieCollection();
            this.Password = password;
        }

        /// <summary>
        ///  Alternate constructor using array of strings instead of parameters.
        /// </summary>
        /// <param name="details"></param>
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

        /// <summary>
        /// Add a new movie to the users Collection.
        /// This should not be used externally, instead use the method Movie.LoanTo which calls this method.
        /// </summary>
        /// <param name="movie"></param>
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
                throw new ArgumentException($"Movie with title [{movie.Title}] already on loan to this user [{Name}].");
            }
        }

        /// <summary>
        /// Get a Loaned movie from the members internal collection.
        /// </summary>
        /// <param name="title">The Title of the movie</param>
        /// <returns></returns>
        public Movie GetMovie(string title)
        {
            return currentLoans.Get(title);
        }
        

        /// <summary>
        /// Removes a movie from internal collection.
        /// Not to be used externally except in unit tests.
        /// Instead call ReturnMovieToLibrary method.
        /// </summary>
        /// <param name="title">Title of the movie</param>
        public void removeMovie(string title)
        {
            currentLoans.Delete(title);
        }

        /// <summary>
        /// Remove a movie from the members internal collection and set copy as available in the libary.
        /// </summary>
        /// <param name="title">Title of the movie to return</param>
        public void ReturnMovieToLibrary(string title)
        {
            Program.library.Get(title).LoanedTo = null;
            Program.library.Get(title).CoppiesAvailable++;
            removeMovie(title);
        }

        /// <summary>
        /// Print the details of all current movies loaned to the user. 
        /// </summary>
        public void PrintLoans()
        {
            currentLoans.PrintMovies();
        }
    }
}
