using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{   
    /*
     * Models a movie DVD
     */
    public class Movie : IComparable
    {
        private DataStructures.List<string> starring; // TODO STRUCT: LIST
        private Genre genre;
        private Classification classification;
        private int borrowedCount;
        public string Title { get; }
        public string Director { get; }
        public DateTime ReleaseDate { get; }
        public Member LoanedTo { get; set; }
        public Movie(string title, DataStructures.List<string> starring, string directorName, 
                        Genre genre, Classification classification, DateTime releaseDate)
        {
            Title = title;
            Director = directorName;
            this.starring = starring;
            this.genre = genre;
            this.classification = classification;
            this.borrowedCount = 0;
            ReleaseDate = releaseDate;
        }

        public string Key
        {
            get { return Title; }
        }

        public bool onLoan
        {
            get { return LoanedTo != null; }
        }

        public void LoanTo(Member member)
        {
            member.AddMovie(this);
            LoanedTo = member;
        }

        public int CompareTo(object o)
        {
            Movie movie = (Movie)o;
            return Algorithms.StringCompare(this.Title, movie.Title);
        }
    }



    public enum Genre
    {
        Drama,
        Adventure,
        Family,
        Action,
        SciFi,
        Comedy,
        Animated,
        Thriller,
        Other
    }

    public enum Classification
    {
        General,
        ParentalGuidance,
        Mature,
        MatureAccompanied
    }
}
