using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectedSubject : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSubjectName.Text = _subjectName;
    }

    private string _subjectName;
    public string SubjectName
    {
        get { return _subjectName; }
        set { _subjectName = value; }
    }

}