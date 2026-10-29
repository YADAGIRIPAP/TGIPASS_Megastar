using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Note_TsIPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
    }



    protected void chktick_CheckedChanged(object sender, EventArgs e)
    {
        if(chktick.Checked==true)
        {
            divhplnk.Visible = true;
        }
        else 
        {
            divhplnk.Visible = false;
        }

    }
}
