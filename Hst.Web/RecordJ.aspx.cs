using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using Hst.DataAccess;
using Hst.Domain.Entities;

public partial class RecordJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    [OperationContract]
    public static List<object> GetStudents()
    {
        var mu = Membership.GetUser();
        var students = new List<object>();

        if (mu != null)
        {
            var ca = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            var user = ua.GetUserByLogin(mu.UserName);

            var children = ca.GetChildrenByUser(user);

            var student = from child in children
                          select new
                                     {
                                         NameLast = child.NameLast,
                                         NameFirst = child.NameFirst,
                                         Id = child.Id
                                     };
            students.Add(student);
        }

        return students;
    }

    [WebMethod]
    [OperationContract]
    public static IEnumerable<object> GetSubjects()
    {
        var sa = new SubjectAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        var subjects = sa.GetAllSubjects();

        var subject = from sub in subjects
                      select new
                                 {
                                     Name = sub.Name,
                                     Id = sub.Id
                                 };

        return subject;

    }

    [WebMethod]
    [OperationContract]
    public static void SaveActivity(List<int> studentids, List<int> subjectids, string date, string activityName, string activityDescription, string timeSpent)
    {
        // Verify the currentuser is a teacher for this school
        var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        var recordaccessor = new RecordAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        var subjectaccessor = new SubjectAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        var childaccessor = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        var mu = Membership.GetUser();

        if (mu != null)
        {
            var user = ua.GetUserByLogin(mu.UserName);

            if (user.IsTeacher)
            {
                // Get the students involved
                var students = childaccessor.GetChildrenByIds(studentids);


                // Get the subjects involved
                var subjects = subjectaccessor.GetSubjectsByIds(subjectids);

                // Get the date
                var recordDate = DateTime.Parse(date);

                // Get the details
                var activity = new Activity();
                activity.ActivityDate = recordDate;
                activity.ActivityName = activityName;
                activity.Notes = activityDescription;
                activity.TimeSpent = timeSpent;
                activity.Users.Add(user);

                foreach (var subject in subjects)
                {
                    activity.Subjects.Add(subject);
                }

                foreach (var student in students)
                {
                    activity.Children.Add(student);
                }

                recordaccessor.PersistActivity(activity);
            }
        }
    }
}