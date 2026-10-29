using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_UserGroundwaterAttachments : System.Web.UI.Page
{
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["intApplicationId"] != null)
        //{
        //   string ApplicationID = Request.QueryString["intApplicationId"];

        //    if (!IsPostBack)
        //    {
        //        FillDetails();
        //    }

        //}

        if (Request.QueryString[0].ToString() != null)
        {
            string ApplicationID =Convert.ToString(Request.QueryString[0]);

            if (!IsPostBack)
            {
                FillDetails();
            }

        }

    }

    void FillDetails()
    {
        try
        {
            //DataSet ds = obj_dashboard.GetdatadocumentbyQuestioneerieid_Groundwater(Request.QueryString["intApplicationId"]);
            DataSet ds = obj_dashboard.GetdatadocumentbyQuestioneerieid_Groundwater(Convert.ToString(Request.QueryString[0]));
            if (ds != null && ds.Tables.Count > 0)
            {
                gvlastattachments.DataSource = ds.Tables[0];
                gvlastattachments.DataBind();
            }
            else
            {

            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

    }



    protected void gvlastattachments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLinkSubsidy");
                h1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                h1.Text = "Click Here";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}