using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Domain.Entities;

public partial class SelectedStudents : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

            if (_children == null)
            {
                _children = new List<Child>();
            }

            _numChildren = _children.Count;
            ViewState["numChildren"] = _children.Count.ToString();
            int i = 0;

            pnlSelectedStudents.Controls.Clear();
            foreach (var child in _children)
            {
                var ss = (SelectedStudent)LoadControl("~/SelectedStudent.ascx");

                //var pnlStudentsList = new Panel();
                pnlSelectedStudents.Controls.Add(ss);
                ss.StudentName = child.NameFirst + " " + child.NameLast;
                ss.StudentAge = CalculateAge(child.DateOfBirth, DateTime.Today).ToString();
                ss.ID = "ss_" + i;
                i++;
            }


        //if (IsPostBack)
        //{
        //    string num;
        //    if (ViewState["numChildren"] != null)
        //    {
        //        num = ViewState["numChildren"].ToString();
        //    }
        //    else
        //    {
        //        num = Children.Count.ToString();
        //    }

        //    if (Int32.TryParse(num, out _numChildren))
        //    {
        //        for (var i = 0; i < _numChildren; i++)
        //        {
        //            var ss = (SelectedStudent)LoadControl("~/SelectedStudent.ascx");
        //            ss.ID = "ss_" + i;
        //            pnlSelectedStudents.Controls.Add(ss);
        //        }
        //    }
        //}
    }

    private int _numChildren;
    public int NumChildren
    {
        get { return _numChildren; }
        set { _numChildren = value; }
    }

    private List<Child> _children;
    public List<Child> Children
    {
        get { return _children; }
        set { _children = value; }
    }

    public List<SelectedStudent> StudentControls
    {
        get
        {
            var children = new List<SelectedStudent>();
            foreach (var control in pnlSelectedStudents.Controls)
            {
                var ic = control as SelectedStudent;
                if (ic != null)
                {
                    children.Add(ic);
                }
            }
            return children;
        }
    }

    private int CalculateAge(DateTime birthDate, DateTime now)
    {
        int age = now.Year - birthDate.Year;
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
        return age;
    }
}