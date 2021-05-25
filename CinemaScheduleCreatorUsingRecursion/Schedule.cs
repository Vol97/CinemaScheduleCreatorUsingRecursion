using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Schedule
    {
        public List<Movie> MoviesInSchedule { get; set; }
        public int FreeTime { get; set; }
        public int UniqueMoviesCount { get; }

        public Schedule(int freetime)
        {
            MoviesInSchedule = new List<Movie>();
            FreeTime = freetime;
        }

        public Schedule(Schedule schedule)
        {
            FreeTime = schedule.FreeTime;
            MoviesInSchedule = schedule.MoviesInSchedule;
        }

        public bool AddMovie(Movie movie)
        {
            if (!(movie is null))
            {
                bool result = false;

                if (FreeTime >= movie.RunningTimeInMinutes)
                {
                    MoviesInSchedule.Add(movie);
                    result = true;
                }

                return result;
            }

            throw new ArgumentNullException();
        }

        public void RemoveMovie(Movie movie)
        {
            if (!(movie is null))
            {
                if (!(MoviesInSchedule is null))
                {
                    MoviesInSchedule.Remove(movie);
                }
            }
        }

        

        private int GetTotalMoviesInScheduleRuntime(Schedule schedule)
        {
            int totalRuntime = 0;

            foreach (Movie movie in schedule.MoviesInSchedule)
            {
                totalRuntime += movie.RunningTimeInMinutes;
            }

            return totalRuntime;
        }

        private int GetUniqueMoviesInScheduleCount(Schedule schedule)
        {
            int count = 0;

            foreach (Movie movie in schedule.MoviesInSchedule)
            {
                count++;
            }

            return count;
        }

        //public void CreateSchedule()
        //{
        //    Schedule currentSchedule;
        //    Schedule bestSchedule;

        //    foreach (var movie in Movies)
        //    {
        //        if (FreeTime >= movie.RunningTimeInMinutes)
        //        {
        //            List<Movie> tmp = new List<Movie>(MoviesInSchedule);
        //            tmp.Add(movie);
        //            currentSchedule = new Schedule(FreeTime - movie.RunningTimeInMinutes, tmp);

        //            if (CheckBestScheduleCriteriaAccordance(currentSchedule))
        //            {
        //                bestSchedule = currentSchedule;
        //            }

        //            currentSchedule.CreateSchedule();
        //        }
        //    }
        //}

        //public bool CheckBestScheduleCriteriaAccordance(Schedule schedule)
        //{
        //    bool result = false;
        //    int uniqueMoviesCount = 0;

        //    foreach(Movie movie in Movies)
        //    {
        //        if(schedule.MoviesInSchedule.Contains(movie))
        //        {
        //            uniqueMoviesCount++;
        //        }
        //    }

        //    return result;
        //}

        //private bool CheckIfAllMoviesCouldFitInSchedule()
        //{
        //    bool result = false;

        //    foreach (Movie movie in Movies)
        //    {

        //    }

        //    return result;
        //}
    }
}
