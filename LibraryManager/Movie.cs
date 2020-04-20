using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{   
    /*
     * Models a movie DVD
     */
    public class Movie : WithKey
    {
        private List<string> starring; // TODO STRUCT: LIST
        private Genre genre;
        private Classification classification;
        public string Title { get; }
        public string Director { get; }
        public DateTime ReleaseDate { get; }

        public Movie(string title, List<string> starring, string directorName, 
                        Genre genre, Classification classification, DateTime releaseDate)
        {
            Title = title;
            Director = directorName;
            this.starring = starring;
            this.genre = genre;
            this.classification = classification;
            ReleaseDate = releaseDate;
        }

        public string Key
        {
            get { return Title; }
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
