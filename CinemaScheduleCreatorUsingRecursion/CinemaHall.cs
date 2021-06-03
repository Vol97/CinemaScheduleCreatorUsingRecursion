using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class CinemaHall
    {
        public static List<Movie> _movies;
        public static int _workingTime;
        public Schedule _bestSchedule;

        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                if (!(value is null))
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
            get
            {
                return _workingTime;
            }
            set
            {
                if (value >= 0)
                {
                    _workingTime = value;
                }
                else
                {
                    _workingTime = 0;
                }
            }
        }

        public Schedule BestSchedule
        {
            get
            {
                return _bestSchedule;
            }
            set
            {
                if (!(value is null))
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
            if (!(movies is null))
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
            if (!(movies is null) && workingTime >= 0)
            {
                return new CinemaHall(movies, workingTime);
            }

            throw new ArgumentException();
        }

        public void CreateSchedule(Schedule currentSchedule)
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

                    if (BestSchedule.UniqueMoviesCount == Movies.Count && BestSchedule.FreeTime == 0)
                    {
                        return;
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
        }

        private void CheckIfGivenScheduleIsTheBest(Schedule currentSchedule)
        {
            if (currentSchedule.FreeTime == 0 &&
                Movies.Count == currentSchedule.UniqueMoviesCount)
            {
                BestSchedule = new Schedule(currentSchedule);
            }
            else if (currentSchedule.UniqueMoviesCount > BestSchedule.UniqueMoviesCount)
            {
                BestSchedule = new Schedule(currentSchedule);
            }
        }
    }
}
