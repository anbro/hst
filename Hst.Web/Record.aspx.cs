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
using Hst.Core.Storage;
//using Hst.DataAccess;
using Hst.Domain.Model;
using Hst.Domain.Queries.Other;
using Hst.Domain.Queries.People;
using Hst.Services;

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
        var result = new List<object>();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);
                var students = db.Query<Student>().GetStudentsByUser(user);

                var results = from student in students
                              select new
                                         {
                                             NameLast = student.NameLast,
                                             NameFirst = student.NameFirst,
                                             Id = student.Id
                                         };
                result.Add(results.ToList());
            }

            //var ca = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            //var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            //var user = ua.GetUserByLogin(mu.UserName);

            //var children = ca.GetChildrenByUser(user);

            //var student = from child in children
            //              select new
            //                         {
            //                             NameLast = child.NameLast,
            //                             NameFirst = child.NameFirst,
            //                             Id = child.Id
            //                         };
            //students.Add(student);
        }

        return result;
    }

    [WebMethod]
    [OperationContract]
    public static IEnumerable<object> GetSubjects()
    {
        var mu = Membership.GetUser();
        var result = new List<object>();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);
                if (user.IsActive)
                {
                    var subjects = db.Query<Subject>();

                    var subs = (from sub in subjects
                           select new {Name = sub.Name, Id = sub.Id});

                    result.Add(subs.ToList());
                }
            }
        }

        return result;
    }

    [WebMethod]
    [OperationContract]
    public static void SaveActivity(List<int> studentids, List<int> subjectids, string date, string activityName, string activityDescription, int timeSpent)
    {
        // Verify the currentuser is a teacher for this school
        //var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var recordaccessor = new RecordAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var subjectaccessor = new SubjectAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var childaccessor = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    // Get the students involved
                    var students = db.Query<Student>().GetStudentsByIds(studentids);

                    // Get the subjects involved
                    var subjects = db.Query<Subject>().GetSubjectsByIds(subjectids);

                    // Get the date
                    var recordDate = DateTime.Parse(date);

                    // Get the details
                    var activity = new Activity
                                       {
                                           ActivityDate = recordDate,
                                           ActivityName = activityName,
                                           Notes = activityDescription,
                                           TimeSpent = timeSpent,
                                           RecordedBy = user
                                       };

                    foreach (var subject in subjects)
                    {
                        activity.Subjects.Add(subject);
                    }

                    foreach (var student in students)
                    {
                        activity.Students.Add(student);
                    }

                    db.AddEntity(activity);
                    db.SaveChanges();
                }
            }

        }
    }

    [WebMethod]
    [OperationContract]
    public static void SaveLesson(List<int> studentids, List<int> subjectids, string date, string lessonTitle, string lessonDescription, int timeSpent)
    {
        //int time = 0;
        //bool timeValid = Int32.TryParse(timeSpent, out time);

        //if (!timeValid)
        //{
        //    throw new ArgumentException("timeSpent must be a valid number of minutes");
        //}

        //// Verify the currentuser is a teacher for this school
        //var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var recordaccessor = new RecordAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var subjectaccessor = new SubjectAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var childaccessor = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    // Get the students involved
                    var students = db.Query<Student>().GetStudentsByIds(studentids);

                    // Get the subjects involved
                    var subjects = db.Query<Subject>().GetSubjectsByIds(subjectids);

                    // Get the date
                    var recordDate = DateTime.Parse(date);

                    // Get the details
                    var lesson = new Lesson
                                     {
                                         LessonDate = recordDate,
                                         LessonTitle = lessonTitle,
                                         Notes = lessonDescription,
                                         TimeSpent = timeSpent,
                                         RecordedBy = user
                                     };

                    foreach (var subject in subjects)
                    {
                        lesson.Subjects.Add(subject);
                    }

                    foreach (var student in students)
                    {
                        lesson.Students.Add(student);
                    }

                    db.AddEntity(lesson);
                    db.SaveChanges();
                }
            }
        }
    }

    [WebMethod]
    [OperationContract]
    public static void SaveTest(List<TestScoreDTO> scores, List<int> subjectids, string date, string testName, int totalQuestions)
    {
        //// Verify the currentuser is a teacher for this school
        //var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var recordaccessor = new RecordAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var subjectaccessor = new SubjectAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        //var childaccessor = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    var studentids = scores.Select(testScoreDto => testScoreDto.StudentId).ToList();

                    // Get the students involved
                    var students = db.Query<Student>().GetStudentsByIds(studentids);

                    // Get the subjects involved
                    var subjects = db.Query<Subject>().GetSubjectsByIds(subjectids);

                    // Get the date
                    var recordDate = DateTime.Parse(date);

                    // Build the test
                    var test = new Test
                                   {
                                       TestName = testName,
                                       Questions = totalQuestions,
                                       TestDate = recordDate,
                                       RecordedBy = user
                                   };

                    foreach (var subject in subjects)
                    {
                        test.Subjects.Add(subject);
                    }

                    db.AddEntity(test);
                    
                    foreach (var score in scores)
                    {
                        var sid = score.StudentId;
                        var tr = new TestResult();
                        tr.Test = test;
                        tr.Student = db.Query<Student>().GetStudentById(sid);
                        tr.Correct = score.Correct;
                        tr.NotAnswered = score.NotAnswered;
                        tr.Incorrect = score.Incorrect;

                        db.AddEntity(tr);
                    }

                    db.SaveChanges();
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