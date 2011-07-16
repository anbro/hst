using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.DataAccess;
using Hst.Domain.Entities;

public partial class Record : BasePage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        var cs = (ChildSelector)LoadControl("~/ChildSelector.ascx");
        cs.ID = "childselector";
        pnlStudents.Controls.Add(cs);

        var ss = (SubjectSelector)LoadControl("~/SubjectSelector.ascx");
        ss.ID = "subjectSelectionTool";
        pnlSubjects.Controls.Add(ss);

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var mu = Membership.GetUser();

            if (mu != null)
            {
                var ca = new ChildAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                var sa = new SubjectAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                var user = ua.GetUserByLogin(mu.UserName);
                //var cs = (ChildSelector)LoadControl("~/ChildSelector.ascx");

                //cs.Children = ca.GetChildrenByUser(user);

                var cs = pnlStudents.FindControl("childselector") as ChildSelector;
                if (cs != null)
                {
                    cs.Children = ca.GetChildrenByUser(user);
                }

                var ss = pnlSubjects.FindControl("subjectSelectionTool") as SubjectSelector;
                if (ss != null)
                {
                    ss.Subjects = sa.GetAllSubjects();
                }

            }
        }

        if (txtRecordDate.Text == string.Empty)
        {
            txtRecordDate.Text = DateTime.Today.ToShortDateString();
        }

        if (hidRecordType.Value == "Activity")
        {
            var ra = (RecordActivity) LoadControl("~/RecordActivity.ascx");
            ra.ID = "recordactivity";
            pnlRecordDetails.Controls.Add(ra);
        }

    }

    protected void btnStudentsSelected_OnClick(object sender, EventArgs e)
    {
        BuildSummary();
        hidAccordionIndex.Value = (1).ToString();

    }

    protected void BuildSummary()
    {
        BuildSelectedChildrenSummary();
        BuildSelectedRecordTypeSummary();
        BuildSelectedSubjectsSummary();
        BuildSelectedDateSummary();
    }

    protected void BuildSelectedDateSummary()
    {
        if (txtRecordDate.Text != string.Empty)
        {
            var rt = (SelectedDate)LoadControl("~/SelectedDate.ascx");
            rt.DateSelected = txtRecordDate.Text;
            pnlSelectedDate.Controls.Add(rt);
        }
    }

    protected void BuildSelectedSubjectsSummary()
    {
        var sss = pnlSelectedSubjects.FindControl("subjectSelectionTool");
        var subselect = sss as SubjectSelector;

        var ss = (SelectedSubjects) LoadControl("~/SelectedSubjects.ascx");
        ss.ID = "selectedSubjectsControl";

        if (subselect != null)
        {
            foreach (var subjectControl in subselect.SubjectControls)
            {
                if (subjectControl.IsChecked)
                {
                    if (ss.Subjects == null)
                    {
                        ss.Subjects = new List<Subject>();
                    }

                    ss.Subjects.Add(subjectControl.Subject);
                }
            }
        }

        pnlSelectedSubjects.Controls.Add(ss);
    }

    protected void BuildSelectedRecordTypeSummary()
    {
        if (hidRecordType.Value != string.Empty)
        {
            var rt = (SelectedRecordType)LoadControl("~/SelectedRecordType.ascx");
            rt.RecordType = hidRecordType.Value;
            pnlSelectedRecordType.Controls.Add(rt);
        }
    }

    protected void BuildSelectedChildrenSummary()
    {
        var ics = pnlStudents.FindControl("childselector");
        var childselector = ics as ChildSelector;

        var ss = (SelectedStudents)LoadControl("~/SelectedStudents.ascx");
        ss.ID = "selectedStudentsControl";


        if (childselector != null)
        {
            foreach (var studentControl in childselector.StudentControls)
            {
                if (studentControl.IsChecked)
                {
                    if (ss.Children == null)
                    {
                        ss.Children = new List<Child>();
                    }
                    ss.Children.Add(studentControl.Child);
                }
            }
        }

        pnlSelectedStudents.Controls.Add(ss);

    }

    protected void btnRecordActivity_Click(object sender, EventArgs e)
    {
        hidRecordType.Value = "Activity";
        BuildSummary();
        hidAccordionIndex.Value = (2).ToString();
    }

    protected void btnRecordLesson_Click(object sender, EventArgs e)
    {
        hidRecordType.Value = "Lesson";
        BuildSummary();
        hidAccordionIndex.Value = (2).ToString();
    }

    protected void btnRecordTest_Click(object sender, EventArgs e)
    {
        hidRecordType.Value = "Test";
        BuildSummary();
        hidAccordionIndex.Value = (2).ToString();
    }

    protected void btnSubjectsSelected_OnClick(object sender, EventArgs e)
    {
        BuildSummary();
        hidAccordionIndex.Value = (3).ToString(); 
    }

    protected void btnDateSelected_OnClick(object sender, EventArgs e)
    {
        BuildSummary();
        hidAccordionIndex.Value = (4).ToString();
    }

    protected void btnSaveDetails_OnClick(object sender, EventArgs e)
    {
        // Verify the currentuser is a teacher for this school
        var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        var recordaccessor = new RecordAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        var studentaccessor = new StudentAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        var mu = Membership.GetUser();

        if (mu != null)
        {
            var user = ua.GetUserByLogin(mu.UserName);

            if (user.IsTeacher)
            {
                // Get the students involved
                var students = GetSelectedStudents();

                // Get the activity type
                var activitytype = hidRecordType.Value;

                // Get the subjects involved
                var subjects = GetSelectedSubjects();

                // Get the date
                var recordDate = DateTime.Parse(txtRecordDate.Text);

                // Get the details
                switch (activitytype)
                {
                    case "Activity":
                        var ad = pnlStudents.FindControl("recordactivity");
                        var ra = ad as RecordActivity;

                        var activity = new Activity();
                        activity.ActivityDate = recordDate;
                        activity.ActivityName = ra.ActivityName;
                        activity.Notes = ra.ActivityNote;
                        activity.TimeSpent = ra.TimeSpent;
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
                        Response.Redirect("~/Record.aspx");
                        break;
                    default:
                        break;
                }



            }
        }


        
    }

    private List<Child> GetSelectedStudents()
    {
        var ics = pnlStudents.FindControl("childselector");
        var childselector = ics as ChildSelector;
        var result = new List<Child>();

        if (childselector != null)
        {
            foreach (var studentControl in childselector.StudentControls)
            {
                result.Add(studentControl.Child);
            }
        }

        return result;
    }

    private List<Subject> GetSelectedSubjects()
    {
        var sss = pnlSelectedSubjects.FindControl("subjectSelectionTool");
        var subselect = sss as SubjectSelector;
        var result = new List<Subject>();

        if (subselect != null)
        {
            foreach (var subjectControl in subselect.SubjectControls)
            {
                if (subjectControl.IsChecked)
                {
                    result.Add(subjectControl.Subject);
                }
            }
        }

        return result;
    }
}