using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmlocationfrommap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string tsipasslatitude = Convert.ToString(Session["tsipasslatitude"]);
        //string tsipasslongitude = Convert.ToString(Session["tsipasslongitude"]);

        //Session["tsipasslatitude"]= Convert.ToString(lbllatitude.Text);
        //Session["tsipasslongitude"]= Convert.ToString(lbllongitude.Text);
       // Session["MSMENO"] = Request.QueryString[0].ToString().Trim();
        //hf_msmeno.Value = Convert.ToString(Request.QueryString[0].ToString().Trim());
        hf_msmeno.Value = Convert.ToString(Session["MSMENO"]);
    }
}