using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movie
    {
        private String title;
        private int releaseYear;
        private IList<Actor> actors;
        private Director director;

        public Movie(String title, int releaseYear)
        {
            actors = new List<Actor>();
            this.title = title;
            this.releaseYear = releaseYear;
        }

        public Director Director
        {
            get { return director; }
        }

        public void setDirector(Director director)
        {
            if (director == null)
                return;
            this.director = director;
            director.addMovie(this);
        }

        public String getTitle()
        {
            return title;
        }
        public void setTitle(String title)
        {
            this.title = title;
        }
        public int getReleaseYear()
        {
            return releaseYear;
        }
        public void setReleaseYear(int releaseYear)
        {
            this.releaseYear = releaseYear;
        }

        public bool addActor(Actor actor)
        {
            if (actors.Contains(actor))
                return false;

            actors.Add(actor);
            if (!actor.containsMovie(this))
                actor.addMovie(this);
            return true;
        }

        public bool containsActor(Actor actor)
        {
            return actors.Contains(actor);
        }

        public override String ToString()
        {
            return "Movie [title=" + title + ", releaseYear=" + releaseYear + "]";
        }
    }
}
