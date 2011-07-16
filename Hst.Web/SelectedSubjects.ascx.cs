using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Domain.Entities;

public partial class SelectedSubjects : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (_subjects == null)
        {
            _subjects = new List<Subject>();
        }

        _numChildren = _subjects.Count;
        ViewState["numChildren"] = _subjects.Count.ToString();
        int i = 0;

        pnlSelectedSubjects.Controls.Clear();
        foreach (var sub in _subjects)
        {
            var ss = (SelectedSubject)LoadControl("~/SelectedSubject.ascx");

            //var pnlStudentsList = new Panel();
            pnlSelectedSubjects.Controls.Add(ss);
            ss.SubjectName = sub.Name;
            ss.ID = "ssub_" + i;
            i++;
        }

    }

    private int _numChildren;
    public int NumChildren
    {
        get { return _numChildren; }
        set { _numChildren = value; }
    }

    private List<Subject> _subjects;
    public List<Subject> Subjects
    {
        get { return _subjects; }
        set { _subjects = value; }
    }


    public List<SelectedSubject> SubjectControls
    {
        get
        {
            var children = new List<SelectedSubject>();
            foreach (var control in pnlSelectedSubjects.Controls)
            {
                var ss = control as SelectedSubject;
                if (ss != null)
                {
                    children.Add(ss);
                }
            }
            return children;
        }
    }
}