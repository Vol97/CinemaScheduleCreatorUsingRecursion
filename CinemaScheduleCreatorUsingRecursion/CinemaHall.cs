using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class CinemaHall
    {
        public static List<Movie> Movies { get; set; }
        public List<Movie> MoviesInSchedule { get; set; }
        public int FreeTime { get; set; }
        public List<CinemaHall> Next { get; set; }

        public CinemaHall(int freeTime, List<Movie> moviesInSchedule = null)
        {
            FreeTime = freeTime;
            Next = new List<CinemaHall>();

            if (moviesInSchedule is null)
            {
                MoviesInSchedule = new List<Movie>();
            }
            else
            {
                MoviesInSchedule = moviesInSchedule;
            }
        }

        public void CreateSchedule()
        {
            foreach (var movie in Movies)
            {
                if (FreeTime >= movie.RunningTimeInMinutes)
                {
                    List<Movie> tmp = new List<Movie>(MoviesInSchedule);
                    tmp.Add(movie);
                    CinemaHall cinemaHall = new CinemaHall(FreeTime - movie.RunningTimeInMinutes, tmp);
                    Next.Add(cinemaHall);
                    cinemaHall.CreateSchedule();
                }
            }
        }

        public void ShowMoviesInSchedule()
        {
            if (Next.Count == 0)
            {
                foreach (var movie in MoviesInSchedule)
                {
                    Console.Write(movie.MovieTitle + " ");
                }

                Console.WriteLine();
            }
            else
            {
                foreach (var cinemaHall in Next)
                {
                    cinemaHall.ShowMoviesInSchedule();
                }
            }
        }
    }
}
