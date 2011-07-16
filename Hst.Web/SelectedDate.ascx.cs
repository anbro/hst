using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectedDate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDate.Text = DateSelected;
    }

    public string DateSelected
    {
        get { return ViewState["SelectedDateOfRecord"].ToString(); }
        set { ViewState["SelectedDateOfRecord"] = value; }

    }
}