using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace CinemaScheduleCreatorUsingRecursion.Tests
{
    public class CinemaHallTests
    {
        [TestCaseSource(typeof(CreateScheduleTestSource))]
        public void CreateSchedule_WhenGivenSchedule_ShouldReturnBestSchedule(Schedule schedule, Schedule expectedSchedule, CinemaHall cinemaHall)
        {
            Schedule actualSchedule = cinemaHall.CreateSchedule(schedule);

            foreach (Movie movie in expectedSchedule.MoviesInSchedule)
            {
                if (!(actualSchedule.MoviesInSchedule.Contains(movie)))
                {
                    Assert.Fail();
                }
                else
                {
                    if (actualSchedule.FreeTime == expectedSchedule.FreeTime)
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }

            }
        }

        public class CreateScheduleTestSource : IEnumerable
        {
            List<Movie> Movies;
            CinemaHall CinemaHall;
            Schedule EmptySchedule;
            Schedule ResultSchedule;

            public IEnumerator GetEnumerator()
            {
                Movies = new List<Movie>()
                {
                    Movie.CreateMovie("AAA", 5),
                    Movie.CreateMovie("BBB", 10),
                    Movie.CreateMovie("CCC", 15),
                    Movie.CreateMovie("DDD", 20)
                };

                CinemaHall = CinemaHall.CreateCinemaHall(Movies, 50);
                EmptySchedule = new Schedule();
                ResultSchedule = new Schedule();
                ResultSchedule.MoviesInSchedule = new List<Movie>(Movies);

                yield return new object[]
                {
                    EmptySchedule,
                    ResultSchedule,
                    CinemaHall
                };
            }
        }
    }
}