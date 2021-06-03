using System;
using System.Collections.Generic;

namespace CinemaScheduleCreatorUsingRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie("AAA", 5),
                new Movie("BBB", 10),
                new Movie("CCC", 15),
                new Movie("DDD", 20),
                new Movie("EEE", 20),
                new Movie("FFF", 20)
            };

            CinemaHall cinemaHall = CinemaHall.CreateCinemaHall(movies, 150);
            Schedule schedule = new Schedule();

            cinemaHall.CreateSchedule(schedule);

            Console.WriteLine(cinemaHall.BestSchedule);
        }
    }
}
