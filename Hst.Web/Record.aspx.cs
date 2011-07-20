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

public partial class Record : System.Web.UI.Page
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

    [WebMethod]
    [OperationContract]
    public static void SaveLesson(List<int> studentids, List<int> subjectids, string date, string lessonTitle, string lessonDescription, string timeSpent)
    {
        int time = 0;
        bool timeValid = Int32.TryParse(timeSpent, out time);

        if (!timeValid)
        {
            throw new ArgumentException("timeSpent must be a valid number of minutes");
        }

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
                var lesson = new Lesson();
                lesson.LessonDate = recordDate;
                lesson.LessonTitle = lessonTitle;
                lesson.Notes = lessonDescription;
                lesson.TimeSpent = new TimeSpan(0, time, 0);
                lesson.Users.Add(user);

                foreach (var subject in subjects)
                {
                    lesson.Subjects.Add(subject);
                }

                foreach (var student in students)
                {
                    lesson.Children.Add(student);
                }

                recordaccessor.PersistLesson(lesson);
            }
        }
    }

    [WebMethod]
    [OperationContract]
    public static void SaveTest(List<TestScoreDTO> scores, List<int> subjectids, string date, string testName, int totalQuestions)
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
                var studentids = scores.Select(testScoreDto => testScoreDto.StudentId).ToList();

                // Get the students involved
                var students = childaccessor.GetChildrenByIds(studentids);

                // Get the subjects involved
                var subjects = subjectaccessor.GetSubjectsByIds(subjectids);

                // Get the date
                var recordDate = DateTime.Parse(date);

                // Build the test
                var test = new Test();
                test.TestName = testName;
                test.Questions = totalQuestions;
                test.TestDate = recordDate;

                foreach (var subject in subjects)
                {
                    test.Subjects.Add(subject);
                }
                test.Users.Add(user);

                recordaccessor.PersistTest(test);

                foreach (var score in scores)
                {
                    var sid = score.StudentId;
                    var tr = new TestResult();
                    tr.Tests.Add(test);
                    tr.Children.Add( students.Where(s => s.Id == sid).FirstOrDefault());
                    tr.Correct = score.Correct;
                    tr.NotAnswered = score.NotAnswered;
                    tr.Incorrect = score.Incorrect;

                    recordaccessor.PersistTestScore(tr);
                }
            }
        }
    }
}

public class TestScoreDTO
{
    public int StudentId { get; set; }
    public int Correct { get; set; }
    public int NotAnswered { get; set; }
    public int Incorrect { get; set; }
}