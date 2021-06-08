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
                Movie.CreateMovie("AAA", 5),
                Movie.CreateMovie("BBB", 10),
                Movie.CreateMovie("CCC", 15),
                Movie.CreateMovie("DDD", 20)
            };

            CinemaHall cinemaHall = CinemaHall.CreateCinemaHall(movies, 50);
            Schedule schedule = new Schedule();
            Console.WriteLine(cinemaHall.CreateSchedule(schedule));
        }
    }
}
