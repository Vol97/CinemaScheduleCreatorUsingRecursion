using System;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Movie : IComparable
    {
        public string MovieTitle { get; set; }
        public int RunningTimeInMinutes { get; set; }

        private Movie(string movieTitle, int runningTimeInMinutes)
        {
            MovieTitle = movieTitle;
            RunningTimeInMinutes = runningTimeInMinutes;
        }

        public static Movie CreateMovie(string movieTitle, int runningTimeInMinutes)
        {
            if (movieTitle != null && runningTimeInMinutes >= 0)
            {
                return new Movie(movieTitle, runningTimeInMinutes);
            }

            if (movieTitle == null)
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentException();
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Movie)
            {
                Movie movie = (Movie)obj;

                result = MovieTitle == movie.MovieTitle &&
                         RunningTimeInMinutes == movie.RunningTimeInMinutes;
            }

            return result;
        }

        public override string ToString()
        {
            return $"Movie title: {MovieTitle}. Duration: {RunningTimeInMinutes}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Movie)
            {
                Movie movie = (Movie)obj;

                return RunningTimeInMinutes.CompareTo(movie.RunningTimeInMinutes);
            }

            throw new ArgumentException("Invalid object type");
        }
    }
}
