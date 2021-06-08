using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Schedule
    {
        public List<Movie> MoviesInSchedule { get; set; }
        public int FreeTime => CinemaHall.WorkingTime - TotalMoviesRuntimeInSchedule;
        public int UniqueMoviesCount => GetUniqueMoviesCountInSchedule();
        public int TotalMoviesRuntimeInSchedule => GetTotalMoviesRuntimeInSchedule();

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
            if (!(schedule is null) && !(schedule.MoviesInSchedule is null))
            {
                return new Schedule(schedule);
            }

            throw new ArgumentNullException();
        }

        public bool AddMovie(Movie movie)
        {
            if (!(movie is null))
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
            if (!(movie is null))
            {
                if (!(MoviesInSchedule is null))
                {
                    MoviesInSchedule.Remove(movie);
                }
            }
        }

        private int GetTotalMoviesRuntimeInSchedule()
        {
            int totalRuntime = 0;

            foreach (Movie movie in MoviesInSchedule)
            {
                totalRuntime += movie.RunningTimeInMinutes;
            }

            return totalRuntime;
        }

        private int GetUniqueMoviesCountInSchedule()
        {
            int count = 0;
            List<Movie> uniqueMovies = new List<Movie>(CinemaHall.Movies);

            foreach (Movie movie in MoviesInSchedule)
            {
                if (uniqueMovies.Contains(movie))
                {
                    uniqueMovies.Remove(movie);
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Movie movie in MoviesInSchedule)
            {
                result.Append(movie.ToString()).Append("\n");
            }

            return result.ToString();
        }
    }
}
