using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Core.Storage;
using Hst.Domain.Model;
using Hst.Domain.Queries.People;
using Hst.Domain.Queries.Records;
using Hst.Services;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    [OperationContract]
    public static List<object> GetActivities(int studentid, string startdate, string enddate)
    {
        // Verify the currentuser is a teacher for this school
        DateTime start;

        if (!DateTime.TryParse(startdate, out start))
        {
            throw new ArgumentException("startdate was not specified in a valid datetime format.");
        }

        DateTime end;
        if (!DateTime.TryParse(enddate, out end))
        {
            throw new ArgumentException("enddate was not specified in a valid datetime format.");
        }

        var result = new List<object>();

        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                // User should have access to the student and be active in order to access this data
                if (user.IsActive && user.AccessibleStudents.Select(s => s.Id).Contains(studentid))
                {
                    var activities = db.Query<Activity>().GetActivitiesReportItems(studentid, start, end);

                    var acts = (from a in activities
                                select new
                                           {
                                               Id = a.Id,
                                               Date = a.ActivityDate,
                                               Title = a.ActivityName,
                                               Notes = a.Notes,
                                               Subjects = a.Subjects.Select(s => s.Name)
                                           });

                    result.Add(acts.ToList());
                }
                else
                {
                    throw new SecurityException("User lacks access to requested student data.");
                }
            }
        }

        return result;
    }

    [WebMethod]
    [OperationContract]
    public static List<object> GetLessons(int studentid, string startdate, string enddate)
    {
        // Verify the currentuser is a teacher for this school
        DateTime start;

        if (!DateTime.TryParse(startdate, out start))
        {
            throw new ArgumentException("startdate was not specified in a valid datetime format.");
        }

        DateTime end;
        if (!DateTime.TryParse(enddate, out end))
        {
            throw new ArgumentException("enddate was not specified in a valid datetime format.");
        }

        var result = new List<object>();

        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                // User should have access to the student and be active in order to access this data
                if (user.IsActive && user.AccessibleStudents.Select(s => s.Id).Contains(studentid))
                {
                    var lessons = db.Query<Lesson>().GetLessonsReportItems(studentid, start, end);

                    var less = (from a in lessons 
                                select new
                                {
                                    Id = a.Id,
                                    Date = a.LessonDate,
                                    Title = a.LessonTitle,
                                    Notes = a.Notes,
                                    Subjects = a.Subjects.Select(s => s.Name)
                                });

                    result.Add(less.ToList());
                }
                else
                {
                    throw new SecurityException("User lacks access to requested student data.");
                }
            }
        }

        return result;
    }
}