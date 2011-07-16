using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.DataAccess;
using Hst.Domain.Entities;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var mu = Membership.GetUser();
            if (mu != null)
            {
                var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                var u = ua.GetUserByLogin(mu.UserName);
                Profile.FirstName = u.NameFirst;
                Profile.LastName = u.NameLast;
                if (u.School != null)
                {
                    Profile.SchoolName = u.School.SchoolName;
                }
                Profile.Save();

                lblSchoolName.Text = Profile.SchoolName;
            }
        }
    }
}
