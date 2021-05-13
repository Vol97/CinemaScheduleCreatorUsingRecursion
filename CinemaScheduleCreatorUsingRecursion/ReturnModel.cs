using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class ReturnModel
    {
        public List<Movie> MoviesInSchedule { get; set; }
        public int FreeTime { get; set; }

        public ReturnModel(int freeTime, List<Movie> moviesInSchedule)
        {
            FreeTime = freeTime;
            MoviesInSchedule = new List<Movie>(moviesInSchedule);
        }
    }
}
