using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Domain.Entities;

public partial class IndividualSubject : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblSubjectName.Text = SubjectName;
            cbSubjectSelected.Checked = IsChecked;
        }
    }

    protected void cbSubjectSelected_OnCheckedChanged(object sender, EventArgs e)
    {
        IsChecked = cbSubjectSelected.Checked;
    }

    public string SubjectName
    {
        get { return ViewState["SubjectName"].ToString(); }
        set { ViewState["SubjectName"] = value; }
    }

    public Subject Subject
    {
        get { return (Hst.Domain.Entities.Subject)ViewState["Subject"]; }
        set
        {
            ViewState.Add("Subject", value);
        }
    }

    public bool IsChecked
    {
        get { return cbSubjectSelected.Checked; }
        set
        {
            cbSubjectSelected.Checked = value;
        }
    }

}