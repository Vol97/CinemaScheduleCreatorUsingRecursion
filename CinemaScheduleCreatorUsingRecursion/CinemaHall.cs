using System;
using System.Collections.Generic;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class CinemaHall
    {
        public static List<Movie> _movies;
        public static int _workingTime;
        public Schedule _bestSchedule;

        public static List<Movie> Movies
        {
            get => _movies;

            set
            {
                if (value != null)
                {
                    _movies = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public static int WorkingTime
        {
            get => _workingTime;

            set => _workingTime = value >= 0 ? value : 0;
        }

        public Schedule BestSchedule
        {
            get => _bestSchedule;

            set
            {
                if (value != null)
                {
                    _bestSchedule = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private CinemaHall(List<Movie> movies, int workingTime)
        {
            if (movies != null)
            {
                Movies = movies;
                Movies.Sort();
                Movies.Reverse();
            }
            else
            {
                Movies = new List<Movie>();
            }

            WorkingTime = workingTime;
            BestSchedule = new Schedule();
        }

        public static CinemaHall CreateCinemaHall(List<Movie> movies, int workingTime)
        {
            if (movies != null && workingTime >= 0)
            {
                return new CinemaHall(movies, workingTime);
            }

            throw new ArgumentException();
        }

        public Schedule CreateSchedule(Schedule currentSchedule)
        {
            if (currentSchedule != null)
            {
                foreach (Movie movie in Movies)
                {
                    bool movieIsAdded = false;

                    if (currentSchedule.AddMovie(movie))
                    {
                        CreateSchedule(currentSchedule);
                        movieIsAdded = true;
                    }

                    CheckIfGivenScheduleIsTheBest(currentSchedule);

                    if (movieIsAdded)
                    {
                        currentSchedule.RemoveMovie(movie);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Current schedule is null");
            }

            return BestSchedule;
        }

        private void CheckIfGivenScheduleIsTheBest(Schedule currentSchedule)
        {
            if (BestSchedule.UniqueMoviesCount < currentSchedule.UniqueMoviesCount)
            {
                BestSchedule = Schedule.CreateSchedule(currentSchedule);
            }
        }
    }
}
