using System;
using System.Collections.Generic;

namespace CinemaScheduleCreatorUsingRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaHall.Movies = new List<Movie>()
            {
                new Movie("LOTR", 120),
                new Movie("SW", 200),
                new Movie("Sonic", 134),
                new Movie("Naruto", 167),
                new Movie("Game", 190),
                new Movie("Sick", 233)
            };

            CinemaHall cinemaHall = new CinemaHall(840);

            cinemaHall.CreateSchedule();
            cinemaHall.ShowLastMoviesInSchedule();
        }
    }
}
