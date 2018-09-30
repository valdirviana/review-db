using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewDB.BackgroundTasks.Jobs
{
    public class MovieJob
    {
        public void MovieJobInserted()
        {
            Console.WriteLine("Movie inserted");
            BackgroundJob.Schedule(() => new MovieJob().MovieJobInserted(), TimeSpan.FromSeconds(5));
        }
    }
}
