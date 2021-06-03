using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Movie : IComparable
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

        public override string ToString()
        {
            return $"Movie title: {this.MovieTitle}. Duration: {this.RunningTimeInMinutes}";
        }

        public int CompareTo(object obj)
        {
            if(obj is Movie)
            {
                Movie movie = (Movie)obj;
                int result;

                if (this.RunningTimeInMinutes > movie.RunningTimeInMinutes)
                    result = 1;
                else if (this.RunningTimeInMinutes < movie.RunningTimeInMinutes)
                    result = -1;
                else
                    result = 0;

                return result;
            }

            throw new ArgumentException("Invalid object type");
        }
    }
}
