using System;
using System.Collections.Generic;

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
        public int LoanedCount { get; set; }
        public int CoppiesAvailable { get; set; }

        // Default constructor
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
            CoppiesAvailable = 1;
        }


        public bool IsOnLoan
        {
            get { return LoanedTo != null; }
        }

        public string Starring
        {
            get { return starring.ToString(); }
        }

        /// <summary>
        /// Assign an instance of this Movie to a Member
        /// </summary>
        /// <param name="member">Member to loan this Movie to</param>
        public void LoanTo(Member member)
        {
            if (CoppiesAvailable <= 0)
            {
                throw new Exception("All copies of this film are already on loan.");
            }
            member.AddMovie(this);
            LoanedTo = member;
            LoanedCount++;
            CoppiesAvailable--;
        }

        /// <summary>
        /// Return a string with all the Movies formatted information.
        /// </summary>
        public override string ToString()
        {
            return $"{Title} ({ReleaseDate.Year}) DIRECTED BY: {Director}, STARRING: {Starring} {Genre} [{Classification}]\n";
        }

        /// <summary>
        /// Possible Classifications for a Movie
        /// </summary>
        public static Dictionary<string, string> ClassificationEnum = new Dictionary<string, string>
        {
            {"G", "General" },
            {"PG", "Parental Guidance" },
            {"M", "Mature"},
            {"MA", "Mature Accompanied" },
        };

        public int CompareTo(object o)
        {
            Movie movie = (Movie)o;
            return Algorithms.StringCompare(this.Title, movie.Title);
        }
    }

    /// <summary>
    /// Possible Genre's for a Movie
    /// Similar to an enum but with extended functionality.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// List of genre strings
        /// </summary>
        public static string[] List = new string[] { "Action", "Adventure", "Animated", "Comedy", "Drama", "Family", "Other", "Science Fiction", "Thriller"};

        /// <summary>
        /// Formats the possible Genres for selection by Staff members
        /// </summary>
        /// <returns>String with corrspoding index before each genre</returns>
        public static string SelectionList()
        {
            string output = "";
            for (int i = 0; i < List.Length; i++)
            {
                output += i.ToString();
                output += ": ";
                output += List[i];
                output += "\n";
            }

            return output;
        }
    }
}
