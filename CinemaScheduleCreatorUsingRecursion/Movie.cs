using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Movie
    {
        public string MovieTitle { get; set; }
        public int RunningTimeInMinutes { get; set; }

        public Movie(string movieTitle, int runningTimeInMinutes)
        {
            if (!(movieTitle is null) && runningTimeInMinutes >= 0)
            {
                MovieTitle = movieTitle;
                RunningTimeInMinutes = runningTimeInMinutes;
            }
            else if (movieTitle is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Movie)
            {
                Movie movie = (Movie)obj;

                if (this.MovieTitle == movie.MovieTitle && this.RunningTimeInMinutes == movie.RunningTimeInMinutes)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
