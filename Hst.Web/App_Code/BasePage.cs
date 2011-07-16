using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public T FindControl<T>(string id) where T : Control
    {
        // We know the control we're searching for isn't the Page itself,
        // so we use the more performant FindChildControl to search.
        return FindChildControl<T>(Page, id);
    }

    public T FindControl<T>(Control startingControl, string id) where T : Control
    {
        return ControlFinder.FindControl<T>(startingControl, id);
    }

    public T FindChildControl<T>(Control startingControl, string id) where T : Control
    {
        return ControlFinder.FindChildControl<T>(startingControl, id);
    }
}