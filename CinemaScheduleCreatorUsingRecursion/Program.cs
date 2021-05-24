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
                new Movie("sas", 120),
                new Movie("afgas", 125),
                new Movie("dfh", 200),
                new Movie("rsas", 111),
                new Movie("nsas", 222),
                new Movie("zsas", 333)
            };

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"{movie.MovieTitle} {movie.RunningTimeInMinutes}");
            }

            Console.WriteLine();

            movies.Sort();

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"{movie.MovieTitle} {movie.RunningTimeInMinutes}");
            }

            Console.WriteLine();

            movies.Reverse();

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"{movie.MovieTitle} {movie.RunningTimeInMinutes}");
            }

            Console.WriteLine();

            Console.WriteLine(movies[0].ToString());
        }
    }
}
