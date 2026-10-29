using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_frmQurieResponseStatus_Travelagent : System.Web.UI.Page
{
    Cls_travelagent Gen = new Cls_travelagent();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }

            DataSet ds = new DataSet();
            string eid = Request.QueryString[0].ToString().Trim();
            if (!IsPostBack)
            {
                if (Session["userlevel"].ToString().Trim() == "10" && Session["user_id"].ToString().Trim().ToLower() != "indus")
                {
                    ds = Gen.GetQueryResponseDetailsByEnterpIDDept_Travelagent(eid, Session["User_Code"].ToString().Trim());
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    ds = Gen.GetQueryResponseDetailsByEnterpID_Travelagent(eid);
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
      

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h3 = (HyperLink)e.Row.Cells[15].Controls[0];
            h3.Target = "_blank";
            h3.NavigateUrl = "frmViewAttachmentDetails_Travelagent.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
        }
    }
  
}