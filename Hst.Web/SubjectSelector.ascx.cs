using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Domain.Entities;

public partial class SubjectSelector : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (_subjects == null)
            {
                _subjects = new List<Subject>();
            }

            _numSubjects = _subjects.Count;
            ViewState["numSubjects"] = _subjects.Count.ToString();
            int i = 0;


            foreach (var subject in _subjects)
            {
                var ins = (IndividualSubject)LoadControl("~/IndividualSubject.ascx");

                //var pnlStudentsList = new Panel();
                pnlSubjectsList.Controls.Add(ins);
                ins.SubjectName = subject.Name;
                ins.Subject = subject;
                ins.ID = "ins_" + i;
                i++;
            }

        }

        if (IsPostBack)
        {
            var num = ViewState["numSubjects"].ToString();
            if (Int32.TryParse(num, out _numSubjects))
            {
                for (var i = 0; i < _numSubjects; i++)
                {
                    var ins = (IndividualSubject)LoadControl("~/IndividualSubject.ascx");
                    ins.ID = "ins_" + i;
                    pnlSubjectsList.Controls.Add(ins);
                }
            }
        }
    }

    private int _numSubjects;
    public int NumSubjects
    {
        get { return _numSubjects; }
        set { _numSubjects = value; }
    }

    private List<Subject> _subjects;
    public List<Subject> Subjects
    {
        get { return _subjects; }
        set { _subjects = value; }
    }

    public List<IndividualSubject> SubjectControls
    {
        get
        {
            var subjects = new List<IndividualSubject>();
            foreach (var control in pnlSubjectsList.Controls)
            {
                var ic = control as IndividualSubject;
                if (ic != null)
                {
                    subjects.Add(ic);
                }
            }
            return subjects;
        }
    }
}