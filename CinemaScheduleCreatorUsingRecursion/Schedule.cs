using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Schedule
    {
        public List<Movie> MoviesInSchedule { get; set; }
        public int FreeTime => CinemaHall.WorkingTime - TotalMoviesRuntimeInSchedule;
        public int UniqueMoviesCount => GetUniqueMoviesCountInSchedule();
        public int TotalMoviesRuntimeInSchedule => MoviesInSchedule.Sum(movie => movie.RunningTimeInMinutes);

        public Schedule()
        {
            MoviesInSchedule = new List<Movie>();
        }

        private Schedule(Schedule schedule)
        {
            MoviesInSchedule = new List<Movie>(schedule.MoviesInSchedule);
        }

        public static Schedule CreateSchedule(Schedule schedule)
        {
            if (schedule != null)
            {
                return new Schedule(schedule);
            }

            throw new ArgumentNullException();
        }

        public bool AddMovie(Movie movie)
        {
            if (movie != null)
            {
                bool result = false;

                if (FreeTime >= movie.RunningTimeInMinutes)
                {
                    MoviesInSchedule.Add(movie);
                    result = true;
                }

                return result;
            }

            throw new ArgumentNullException();
        }

        public void RemoveMovie(Movie movie)
        {
            if (movie != null)
            {
                if (!(MoviesInSchedule is null))
                {
                    MoviesInSchedule.Remove(movie);
                }
            }
        }

        private int GetUniqueMoviesCountInSchedule()
        {
            List<Movie> uniqueMovies = new List<Movie>();

            foreach (Movie movie in MoviesInSchedule)
            {
                if (!uniqueMovies.Contains(movie))
                {
                    uniqueMovies.Add(movie);
                }
            }

            return uniqueMovies.Count;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Movie movie in MoviesInSchedule)
            {
                result.Append($"{movie}{Environment.NewLine}");
            }

            return result.ToString();
        }
    }
}
