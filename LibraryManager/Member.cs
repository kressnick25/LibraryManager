using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LibraryManager
{
    /*
     * Models a library member
     */
    public class Member : WithKey
    {
        private DataStructures.List<Movie> currentLoans;
        private string givenName;
        private string surname;
        public string hashedPassword { get; }
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
                return $"{givenName} {surname} ";
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
            currentLoans = new DataStructures.List<Movie>();
            using (MD5 md5Hash = MD5.Create())
            {
                this.hashedPassword = AuthHandler.GetMd5Hash(md5Hash, password);
            }
        }

        public void AddMovie(Movie movie)
        {
            if (currentLoans.Length == 10)
                throw new Exception("User already has 10 movies on loan.");
            if (GetMovie(movie.Title) != null)
                throw new ArgumentException($"Movie with title [{movie.Title}] already on loan to this user [{Key}].");
            currentLoans.Add(movie);
        }

        public Movie GetMovie(string title)
        {
            foreach (Movie DVD in currentLoans)
            {
                if (DVD.Title == title)
                {
                    return DVD;
                }
            }
            return null;
        }
        

        // removes a movie from the Member
        public void removeMovie(Movie movie)
        {
            for (int i = 0; i < currentLoans.Length; i++)
            {
                if (movie.Key == currentLoans.Get(i).Key)
                {
                    currentLoans.Remove(i);
                }
            }
        }

        // Returns a Movie to the library by removing from Member
        public void ReturnMovieToLibrary(Movie movie)
        {
            removeMovie(movie);
            movie.LoanedTo = null;
        }
    }
}
