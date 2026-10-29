using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_UserDrillingRigsAttachments : System.Web.UI.Page
{
    Cls_DrillingRigs obj_dashboard = new Cls_DrillingRigs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["intApplicationId"] != null)
        {
            string ApplicationID = Request.QueryString["intApplicationId"];

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
            DataSet ds = obj_dashboard.GetdatadocumentbyQuestioneerieid_Drilligrigs(Request.QueryString["intApplicationId"]);
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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserDrillingRigsborewelllist.aspx?intApplicationId=" + Request.QueryString["intApplicationId"]);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserDrillingRigsborewelllist.aspx?intApplicationId=" + Request.QueryString["intApplicationId"]);

    }

}