using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace CinemaScheduleCreatorUsingRecursion.Tests
{
    public class ScheduleTests
    {
        [TestCaseSource(typeof(AddDeleteMovieTestSource))]
        public void AddMovie_WhenGivenMovie_ShouldReturnScheduleWithThisMovieAdded(Movie movie, Schedule emptySchedule, Schedule expectedSchedule)
        {
            emptySchedule.AddMovie(movie);

            if(emptySchedule.MoviesInSchedule.Contains(movie))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestCaseSource(typeof(AddDeleteMovieTestSource))]
        public void DeleteMovie_WhenGivenMovie_DeleteItFromSchedule(Movie movie, Schedule expectedSchedule, Schedule schedule)
        {
            schedule.RemoveMovie(movie);

            if (schedule.MoviesInSchedule.Contains(movie))
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        public class AddDeleteMovieTestSource : IEnumerable
        {
            List<Movie> Movies;
            Schedule EmptySchedule;
            Schedule ScheduleWithOneMovie;

            public IEnumerator GetEnumerator()
            {
                Movies = new List<Movie>()
                {
                    Movie.CreateMovie("AAA", 5)
                };

                EmptySchedule = new Schedule();
                ScheduleWithOneMovie = new Schedule();
                ScheduleWithOneMovie.MoviesInSchedule = new List<Movie>(Movies);

                yield return new object[]
                {
                    Movie.CreateMovie("AAA", 5),
                    EmptySchedule,
                    ScheduleWithOneMovie
                };
            }
        }
    }
}
