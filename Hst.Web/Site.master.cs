using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Core.Storage;
//using Hst.DataAccess;
//using Hst.Domain.Entities;
using Hst.Domain.Queries.Other;
using Hst.Domain.Queries.People;
using Hst.Domain.Model;
using Hst.Services;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var mu = Membership.GetUser();
            if (mu != null)
            {
                using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>())
                {
                    var user = db.Query<User>().GetUserByLogin(mu.UserName);

                    if (user.School != null)
                    {
                        var schoolname = db.Query<School>().GetSchoolName(user);

                        

                        if (schoolname.Length > 0)
                        {
                            Profile.SchoolName = schoolname;
                        }
                    }

                    Profile.FirstName = user.NameFirst;
                    Profile.LastName = user.NameLast;
                }
                
                Profile.Save();

                lblSchoolName.Text = Profile.SchoolName;
            }
        }
    }
}
