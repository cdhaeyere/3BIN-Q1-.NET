using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    internal class Actor : Person
    {
        private static readonly long serialVersionUID = 1L;
        private readonly int _sizeInCentimeter;
        private List<Movie> movies;

        public int SizeInCentimeter
        {
            get { return _sizeInCentimeter; }
        }

        public Actor(string name, string firstName, DateTime birthDate, int sizeInCentimeter) : base(name, firstName, birthDate)
        {
            this._sizeInCentimeter = sizeInCentimeter;
            movies = new List<Movie>();
        }

        public override String ToString()
        {
            return "Actor [name = " + Name + " firstname = " + Firstname + " sizeInCentimeter = " + SizeInCentimeter + " birthdate = " + getBirthDate() + "]";
        }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public IEnumerator<Movie> Movies()
        {
            return movies.GetEnumerator();
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public bool addMovie(Movie movie)
        {
            if ((movie == null) || movies.Contains(movie))
                return false;

            if (!movie.containsActor(this))
                movie.addActor(this);

            movies.Add(movie);

            return true;
        }

        public bool containsMovie(Movie movie)
        {
            return movies.Contains(movie);
        }

        public override String Name
        {
            get { return base.Name.ToUpper(); }
        }
    }
}
