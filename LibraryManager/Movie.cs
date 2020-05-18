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
        private DataStructures.List<string> starring;
        private Genre genre;
        private int borrowedCount;
        public string Title { get; }
        public string Director { get; }
        public string Classification { get; }
        public DateTime ReleaseDate { get; }
        public Member LoanedTo { get; set; }
        public Movie(string title, string directorName,
                        Genre genre, string classification, DateTime releaseDate, params string[] starring)
        {
            Title = title;
            Director = directorName;
            this.genre = genre;
            this.Classification = classification;
            this.borrowedCount = 0;
            ReleaseDate = releaseDate;
            this.starring = new DataStructures.List<string>();
            foreach (string actor in starring)
            {
                this.starring.Add(actor);
            }
        }

        public Movie(string title)
        {
            this.Title = title;
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

        public string Starring
        {
            get { return starring.ToString(); }
        }

        public string GetGenre()
        {
            if (this.genre == Genre.SciFi)
            {
                return "Science Fiction";
            }
            else
            {
                return Enum.GetName(typeof(Genre), this.genre);
            }
        }

        public override string ToString()
        {
            return $"{Title} ({ReleaseDate.Year}) DIRECTED BY: {Director}, STARRING: {Starring} {GetGenre()} [{Classification}]\n";
        }

        public static Dictionary<string, string> ClassificationEnum = new Dictionary<string, string>
        {
            {"G", "General" },
            {"PG", "Parental Guidance" },
            {"M", "Mature"},
            {"MA", "Mature Accompanied" },
        };
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
    }
}
