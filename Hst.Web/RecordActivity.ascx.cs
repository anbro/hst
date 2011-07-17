using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecordActivity : System.Web.UI.UserControl
{
    protected override void  OnInit(EventArgs e)
    {
 	    base.OnInit(e);
        var script = "rb()";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "rbscript", script, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ActivityNote
    {
        get { return txtActivityNote.Content; }
        set { txtActivityNote.Content = value; }
    }

    public string ActivityName
    {
        get { return txtActivityName.Text; }
        set { txtActivityName.Text = value; }
    }

    public string TimeSpent
    {
        get { return txtTimeSpent.Text; }
        set { txtTimeSpent.Text = value; }
    }
}