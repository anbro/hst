using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Domain.Queries.Records
{
    public static class LessonQueries
    {
        public static IQueryable<Lesson> GetLessonsReportItems(this IQueryable<Lesson> lessons, int studentid, DateTime startdate, DateTime enddate)
        {
            return
                lessons.Where(
                    a =>
                    a.Students.Select(s => s.Id).Contains(studentid) && a.LessonDate <= enddate &&
                    a.LessonDate >= startdate);
        }
    }
}
