using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PerfilPrivate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonPost_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonToRight_Click(object sender, EventArgs e)
    {
        IEnumerable<ListItem> selected = ListUserHobbies.Items.GetSelectedItems();

        foreach (ListItem item in selected)
        {
            
        }
    }

    protected void ButtonToLeft_Click(object sender, EventArgs e)
    {

    }
}


public static class Extensions
{
    public static IEnumerable<ListItem> GetSelectedItems(this ListItemCollection items)
    {
        return items.OfType<ListItem>().Where(item => item.Selected);
    }
}