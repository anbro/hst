using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hst.Domain.Entities;

public partial class ChildSelector : System.Web.UI.UserControl
{

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        


        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (_children == null)
            {
                _children = new List<Child>();
            }

            _numChildren = _children.Count;
            ViewState["numChildren"] = _children.Count.ToString();
            int i = 0;

            
            foreach (var child in _children)
            {
                var ic = (IndividualChild)LoadControl("~/IndividualChild.ascx");

                //var pnlStudentsList = new Panel();
                pnlStudentsList.Controls.Add(ic);
                ic.StudentDateOfBirth = child.DateOfBirth;
                ic.StudentFirstName = child.NameFirst;
                ic.StudentLastName = child.NameLast;
                ic.Child = child;
                ic.ID = "ic_" + i;
                i++;
            }

        }

        if (IsPostBack)
        {
            var num = ViewState["numChildren"].ToString();
            if (Int32.TryParse(num, out _numChildren))
            {
                for (var i = 0; i < _numChildren; i++)
                {
                    var ic = (IndividualChild)LoadControl("~/IndividualChild.ascx");
                    ic.ID = "ic_" + i;
                    pnlStudentsList.Controls.Add(ic);
                }
            }
        }

    }

    private int _numChildren;
    public int NumChildren
    {
        get { return _numChildren; }
        set { _numChildren = value; }
    }

    private List<Child> _children;
    public List<Child> Children
    {
        get { return _children; }
        set { _children = value; }
    }

    public List<IndividualChild> StudentControls
    {
        get
        {
            var children = new List<IndividualChild>();
            foreach (var control in pnlStudentsList.Controls)
            {
                var ic = control as IndividualChild;
                if (ic != null)
                {
                    children.Add(ic);
                }
            }
            return children;
        }
    }
    

}