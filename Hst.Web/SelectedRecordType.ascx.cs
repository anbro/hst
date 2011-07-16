using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectedRecordType : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblRecordType.Text = RecordType;
        switch (RecordType)
        {
            case "Lesson":
                break;

            case "Activity":
                imgType.ImageUrl = "~/Icons/32x32/search.png";
                break;
            case "Test":
                imgType.ImageUrl = "~/Icons/32x32/page_edit.png";
                break;
            default:
                break;
        }
    }

    public string RecordType
    {
        get { return ViewState["RecordType"].ToString(); }
        set { ViewState["RecordType"] = value; }
    }
}