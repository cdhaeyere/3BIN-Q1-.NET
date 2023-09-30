using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    internal class Director : Person
    {
        private static readonly long serialVersionUID = 5952964360274024205L;
        private List<Movie> directedMovies;

        public Director(String name, String firstname, DateTime birthDate) : base(name, firstname, birthDate)
        {
            directedMovies = new List<Movie>();
        }

        public bool addMovie(Movie movie)
        {

            if (directedMovies.Contains(movie))
                return false;

            if (movie.Director == null)
                movie.setDirector(this);

            directedMovies.Add(movie);

            return true;

        }

        public IEnumerator<Movie> Movies()
        {
            return directedMovies.GetEnumerator();
        }
    }
}
