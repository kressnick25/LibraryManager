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
        public string Title { get; }
        public string Director { get; }
        public string Classification { get; }
        public DateTime ReleaseDate { get; }
        public Member LoanedTo { get; set; }
        public string Genre { get; }
        public int LoanedCount { get; }

        public Movie(string title, string directorName,
                        string genre, string classification, DateTime releaseDate, params string[] starring)
        {
            Title = title;
            Director = directorName;
            Genre = genre;
            Classification = classification;
            ReleaseDate = releaseDate;
            this.starring = new DataStructures.List<string>();
            foreach (string actor in starring)
            {
                this.starring.Add(actor);
            }
            LoanedCount = 0;
        }

        public Movie(string title)
        {
            this.Title = title;
        }

        public string Key
        {
            get { return Title; }
        }

        public bool IsOnLoan
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

        public override string ToString()
        {
            return $"{Title} ({ReleaseDate.Year}) DIRECTED BY: {Director}, STARRING: {Starring} {Genre} [{Classification}]\n";
        }

        public static Dictionary<string, string> ClassificationEnum = new Dictionary<string, string>
        {
            {"G", "General" },
            {"PG", "Parental Guidance" },
            {"M", "Mature"},
            {"MA", "Mature Accompanied" },
        };
    }

    public class Genre
    {
        public static string[] genres = new string[] { "Action", "Adventure", "Animated", "Comedy", "Drama", "Family", "Other", "Science Fiction", "Thriller"};

        public static string SelectionList()
        {
            string output = "";
            for (int i = 0; i < genres.Length; i++)
            {
                output += i.ToString();
                output += ": ";
                output += genres[i];
                output += "\n";
            }

            return output;
        }
    }
}
