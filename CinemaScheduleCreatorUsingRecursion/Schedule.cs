using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Schedule
    {
        public static List<Movie> Movies { get; set; }
        public List<Movie> MoviesInSchedule { get; set; }
        public int FreeTime { get; set; }
        public int AllMoviesCount { get; }

        public Schedule(int freeTime, List<Movie> moviesInSchedule = null)
        {
            FreeTime = freeTime;

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
            Schedule currentSchedule;
            Schedule bestSchedule;

            foreach (var movie in Movies)
            {
                if (FreeTime >= movie.RunningTimeInMinutes)
                {
                    List<Movie> tmp = new List<Movie>(MoviesInSchedule);
                    tmp.Add(movie);
                    currentSchedule = new Schedule(FreeTime - movie.RunningTimeInMinutes, tmp);

                    if (CheckBestScheduleCriteriaAccordance(currentSchedule))
                    {
                        bestSchedule = currentSchedule;
                    }

                    currentSchedule.CreateSchedule();
                }
            }
        }

        public bool CheckBestScheduleCriteriaAccordance(Schedule schedule)
        {
            bool result = false;
            int uniqueMoviesCount = 0;

            foreach(Movie movie in Movies)
            {
                if(schedule.MoviesInSchedule.Contains(movie))
                {
                    uniqueMoviesCount++;
                }
            }

            return result;
        }

        private bool CheckIfAllMoviesCouldFitInSchedule()
        {
            bool result = false;

            

            return result;
        }
    }
}
