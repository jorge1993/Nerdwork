<<<<<<< HEAD:ProjectGen/Websites/Website1/Busqueda.aspx.cs
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    String p_hobby;

    protected void Page_Load(object sender, EventArgs e)
    {
        p_hobby = Request.QueryString["Hobby"];
        HyperLink1.Text = p_hobby;
    }

=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
>>>>>>> origin/master:ProjectGen/Websites/Website1/Default.aspx.cs
}