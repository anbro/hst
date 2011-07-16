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

public partial class Account_Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        var txtFirstname = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FirstName") as TextBox;
        var txtLastname = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("LastName") as TextBox;
        var txtSchoolname = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("SchoolName") as TextBox;
        var rblist = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CreateSchool") as RadioButtonList;

        if (txtFirstname == null || txtLastname == null || txtSchoolname == null || rblist == null)
        {
            throw new ApplicationException("Fields did not exist!");
        }

        var createSchool = false;
        foreach (ListItem li in rblist.Items)
        {
            if (li.Value == "Create" && li.Selected)
            {
                createSchool = true;
            }
        }
        
        // Create the user object
        var u = new User();
        u.Email = RegisterUser.Email;
        u.Login = RegisterUser.UserName;
        u.NameFirst = txtFirstname.Text;
        u.NameLast = txtLastname.Text;
        u.IsActive = true;
        u.IsTeacher = createSchool;

        if (createSchool)
        {
            // Create the school object, if needed
            var s = new School();
            s.SchoolName = txtSchoolname.Text;
            s.DateJoined = DateTime.Today;

            var sa = new SchoolAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sa.CreateSchool(s);

            u.SchoolId = s.Id;
        }
        
        var ua = new UserAccessor(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        ua.PersistUser(u);
        //Profile.User = u;
        //Profile.Save();


        string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }
        Response.Redirect(continueUrl);
    }

    protected void CreateSchool_Changed(object sender, EventArgs e)
    {
        var pnl = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("pnlSchoolName") as Panel;

        var rblist = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CreateSchool") as RadioButtonList;

        var schoolnamevalidator = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("SchoolNameRequired") as RequiredFieldValidator;

        if (pnl == null && rblist == null)
        {
            return;
        }

        foreach (ListItem item in rblist.Items)
        {
            if (item.Value == "Create" && item.Selected)
            {
                pnl.Visible = true;
                schoolnamevalidator.Enabled = true;
            }
            if (item.Value == "Join" && item.Selected)
            {
                pnl.Visible = false;
                schoolnamevalidator.Enabled = false;
            }
        }
    }
}
