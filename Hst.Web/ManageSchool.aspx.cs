using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Core.Storage;
using Hst.Domain.Model;
using Hst.Domain.Queries.People;
using Hst.Domain.Queries.Other;
using Hst.Services;

public partial class ManageSchool : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    [OperationContract]
    public static void RemoveUser(int id)
    {
        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    if (id != user.Id)
                    {
                        var userToRemove = db.Query<User>().GetUserById(id);
                        //db.DetachEntity(userToRemove);
                        var school = db.Query<School>().GetSchoolByUserId(id);

                        school.Users.Remove(userToRemove);

                        userToRemove.School = null;

                        foreach (var accessibleStudent in userToRemove.AccessibleStudents)
                        {
                            accessibleStudent.AssociatedUsers.Remove(userToRemove);
                            db.AttachEntityAsModified(accessibleStudent);
                        }

                        userToRemove.AccessibleStudents.Clear();

                        db.AttachEntityAsModified(school);
                        db.AttachEntityAsModified(userToRemove);
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    [WebMethod]
    [OperationContract]
    public static void ToggleTeacher(int id)
    {
        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    if (id != user.Id)
                    {
                        var userToToggle = db.Query<User>().GetUserById(id);
                        userToToggle.IsTeacher = !userToToggle.IsTeacher;
                        db.AttachEntityAsModified(userToToggle);
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    [WebMethod]
    [OperationContract]
    public static List<object> GetUsersForSchool()
    {
        var mu = Membership.GetUser();

        var result = new List<object>();
        
        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    var users = db.Query<User>().GetUsersForSchool(user.School.Id);

                    var u = (from us in users
                             select
                                 new
                                 {
                                     Id = us.Id,
                                     Email = us.Email,
                                     FirstName = us.NameFirst,
                                     LastName = us.NameLast,
                                     IsTeacher = us.IsTeacher,
                                     IsActive = us.IsActive
                                 });

                    result.Add(u.ToList());
                }
            }
        }

        return result;
    }

    [WebMethod]
    [OperationContract]
    public static void AddUserToSchool(int id)
    {
        var mu = Membership.GetUser();
        
        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    var userToAdd = db.Query<User>().GetUserById(id);

                    if (userToAdd.Id != 0)
                    {
                        userToAdd.School = user.School;
                        userToAdd.AccessibleStudents = user.School.Students;
                        db.AttachEntityAsModified(userToAdd);
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    [WebMethod]
    [OperationContract]
    public static List<object> GetUsersByEmail(string email)
    {
        var mu = Membership.GetUser();

        var result = new List<object>();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    var users = db.Query<User>().GetUserByEmail(email);

                    //foreach (var tempuser in users)
                    //{
                    //    db.DetachEntity(tempuser);
                    //}

                    var u = (from us in users
                             select
                                 new
                                     {
                                         Id = us.Id,
                                         Email = us.Email,
                                         FirstName = us.NameFirst,
                                         LastName = us.NameLast,
                                         IsTeacher = us.IsTeacher,
                                         IsActive = us.IsActive
                                     });

                    result.Add(u.ToList());

                }
            }
        }

        return result;
    }

    [WebMethod]
    [OperationContract]
    public static void SaveStudent(string Fname, string Lname, string DOB)
    {
        var mu = Membership.GetUser();

        if (mu != null)
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
            {
                var user = db.Query<User>().GetUserByLogin(mu.UserName);

                if (user.IsTeacher)
                {
                    // Create the student
                    var s = new Student();

                    foreach (var u in user.School.Users)
                    {
                        s.AssociatedUsers.Add(u);
                    }
                    s.DateOfBirth = DateTime.Parse(DOB);
                    s.NameFirst = Fname;
                    s.NameLast = Lname;
                    s.School = user.School;

                    db.AddEntity(s);
                    db.SaveChanges();
                }
            }
        }

        
    }
}
