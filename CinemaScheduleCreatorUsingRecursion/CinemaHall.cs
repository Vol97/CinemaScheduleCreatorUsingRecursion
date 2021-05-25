using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class CinemaHall
    {
        public static List<Movie> _movies;
        public static int _freeTime;
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

        public static int FreeTime
        {
            get
            {
                return _freeTime;
            }
            set
            {
                if (value >= 0)
                {
                    _freeTime = value;
                }
                else
                {
                    _freeTime = 0;
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

        private CinemaHall(List<Movie> movies, int freeTime)
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

            FreeTime = freeTime;
        }

        public static CinemaHall CreateCinemaHall(List<Movie> movies, int freeTime)
        {
            if(!(movies is null) && freeTime >= 0)
            {
                return new CinemaHall(movies, freeTime);
            }

            throw new ArgumentException();
        }

        private void CreateSchedules(Schedule currentSchedule)
        {
            if (currentSchedule != null)
            {
                foreach (Movie movie in Movies)
                {
                    bool movieIsAdded = false;

                    if (currentSchedule.AddMovie(movie))
                    {
                        CreateSchedules(currentSchedule);
                        movieIsAdded = true;
                    }

                    if(CheckIfGivenScheduleIsTheBest(currentSchedule))
                    {
                        BestSchedule = currentSchedule;
                    }

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

        //public void CreateSchedule()
        //{
        //    foreach (var movie in Movies)
        //    {
        //        if (FreeTime >= movie.RunningTimeInMinutes)
        //        {
        //            List<Movie> tmp = new List<Movie>(MoviesInSchedule);
        //            tmp.Add(movie);
        //            CinemaHall cinemaHall = new CinemaHall(FreeTime - movie.RunningTimeInMinutes, tmp);
        //            cinemaHall.CreateSchedule();
        //        }
        //    }
        //}

        //public void ShowMoviesInSchedule()
        //{
        //    if (Next.Count == 0)
        //    {
        //        foreach (var movie in MoviesInSchedule)
        //        {
        //            Console.Write(movie.MovieTitle + " ");
        //        }

        //        Console.WriteLine();
        //    }
        //    else
        //    {
        //        foreach (var cinemaHall in Next)
        //        {
        //            cinemaHall.ShowMoviesInSchedule();
        //        }
        //    }
        //}
    }
}
