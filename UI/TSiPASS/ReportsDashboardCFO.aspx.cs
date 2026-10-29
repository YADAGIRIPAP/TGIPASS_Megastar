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

            if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "359030" || Session["uid"].ToString() == "359104")
            {
                LiR9.Visible = true;
              
            }


            if (Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "361264" || Session["uid"].ToString() == "83392"
                 || Session["uid"].ToString() == "368113" || Session["uid"].ToString() == "48844" || Session["uid"].ToString() == "359448" || Session["uid"].ToString() == "1241"
                 || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-CLERK"
                 || Session["Role_Code"].ToString() == "COI-SUPDT" || Session["uid"].ToString() == "3378" || Session["uid"].ToString() == "9942")
            {
                Li3.Visible = false;
                LIR3.Visible = false;
                LIR4.Visible = false;                
                LIR6.Visible = false;

            }
            else
            {
                Li3.Visible = true;
                LIR3.Visible = true;
                LIR4.Visible = true;
                LIR6.Visible = true;

            }
        }
        
        
    }

   
   
}
