using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now
                + LoginValidation.currentUserUsername + ";" + LoginValidation.currentUserRole + ";"
                + activity;

            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("test.txt", activityLine);
            }
        }



        static public string GetCurrentSessionActivities(string filter)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var action in currentSessionActivities)
            {
                sb.Append(action);
            }

            List<string> filteredActivities =
                (from activity in currentSessionActivities
                 where activity.Contains(filter)
                 select activity).ToList();

            if (currentSessionActivities.Count > 0)
            {
                return currentSessionActivities[currentSessionActivities.Count];
            }
            else
            {
                return null;
            }
        }
    }
}
