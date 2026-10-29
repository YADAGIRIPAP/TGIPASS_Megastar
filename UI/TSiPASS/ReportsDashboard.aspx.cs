using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Dashboard : System.Web.UI.Page
{
    //designed by siva as on 29-1-2016 
    //Purpose : Report for Year wise dashboard
    //Tables used : All
    //Stored procedures Used :YearwiseDashboardforAdmin
    
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }

        if (!IsPostBack)
        {
            

            if (Session["uid"].ToString() == "1238")
            {

                lst1.Visible = true;
            }
            else
            {
                lst1.Visible = false;
            }

            if (Session["uid"].ToString() == "1213")
            {
                VATManufacture.Visible = true;
                VATExporters.Visible = true;
                Association.Visible = true;
            }
            else
            {
                VATManufacture.Visible = false;
                VATExporters.Visible = false;
                Association.Visible = false;
            }



            if (Session["DistrictID"].ToString() == "")
            {
                LiR52.Visible = true;
            }
            else
            {
                Masters.Visible = false;
                Li1.Visible = false;
                LiR8.Visible = false;
                LiR9.Visible = false;
                LiR10.Visible = false;
                LiR52.Visible = false;
                Li43.Visible = false;
            }
            if (Session["uid"].ToString() == "9942" || Session["uid"].ToString() == "1222")
            {
                Li43.Visible = true;
                LiR32.Visible = true;
                liR5ApplicationData.Visible = true;
            }
            else
            {
                Li43.Visible = false;
                liR5ApplicationData.Visible = false;
                LiR32.Visible = true;
            }
            if (Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "9942")
            {
                Li33.Visible = true;
            }
            else
            {
                Li33.Visible = false;
            }
        }
        
        
    }

   
   
}
