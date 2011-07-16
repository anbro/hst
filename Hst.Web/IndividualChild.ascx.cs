using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Domain.Entities;

public partial class IndividualChild : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblStudentName.Text = StudentFirstName + " " + StudentLastName;
            lblStudentAge.Text = CalculateAge(StudentDateOfBirth, DateTime.Today).ToString();
            lblStudentAge.ToolTip = StudentDateOfBirth.ToShortDateString();
            cbStudentSelected.Checked = IsChecked;
        }

    }

    //private string _studentFirstName;
    public string StudentFirstName
    {
        get { return ViewState["StudentFirstName"].ToString(); }
        set { ViewState["StudentFirstName"] = value; }
    }
    
    //private string _studentLastName;
    public string StudentLastName
    {
        get { return ViewState["StudentLastName"].ToString(); }
        set { ViewState["StudentLastName"] = value; }
    }

    //private int _studentAge;
    //private DateTime _studentDateOfBirth;
    public DateTime StudentDateOfBirth
    {
        get { return DateTime.Parse(ViewState["StudentDOB"].ToString()); }
        set { ViewState["StudentDOB"] = value.ToShortDateString(); }
    }

    //private bool _isChecked;
    public bool IsChecked
    {
        get { return cbStudentSelected.Checked; }
        set { cbStudentSelected.Checked = value;
        }
    }

    public Child Child
    {
        get { return (Hst.Domain.Entities.Child) ViewState["Child"]; }
        set
        {
            ViewState.Add("Child", value);
        }
    }

    private int CalculateAge(DateTime birthDate, DateTime now)
    {
        int age = now.Year - birthDate.Year;
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
        return age;
    }

    protected void cbStudentSelected_OnCheckedChanged(object sender, EventArgs e)
    {
        IsChecked = cbStudentSelected.Checked;
    }
}