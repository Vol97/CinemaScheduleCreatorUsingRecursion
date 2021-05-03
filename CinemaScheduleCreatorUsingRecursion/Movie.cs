using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScheduleCreatorUsingRecursion
{
    public class Movie
    {
        public string MovieTitle { get; set; }
        public int RunningTime { get; set; }

        public Movie(string movieTitle, int runningTime)
        {
            MovieTitle = movieTitle;
            RunningTime = runningTime;
        }
    }
}
