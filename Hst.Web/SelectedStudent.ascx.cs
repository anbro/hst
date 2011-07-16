using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectedStudent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblStudentAge.Text = "Age: " + _studentAge;
        lblStudentName.Text = _studentName;
    }

    private string _studentName;
    public string StudentName
    {
        get { return _studentName; }
        set { _studentName = value; }
    }

    private string _studentAge;
    public string StudentAge
    {
        get { return _studentAge; }
        set { _studentAge = value; }
    }
}