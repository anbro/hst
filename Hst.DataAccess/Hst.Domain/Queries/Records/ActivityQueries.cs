using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Domain.Queries.Records
{
    public static class ActivityQueries
    {
        public static IQueryable<Activity> GetActivitiesReportItems(this IQueryable<Activity> activities, int studentid, DateTime startdate, DateTime enddate)
        {
            return
                activities.Where(
                    a =>
                    a.Students.Select(s => s.Id).Contains(studentid) && a.ActivityDate <= enddate &&
                    a.ActivityDate >= startdate);
        }
    }
}
