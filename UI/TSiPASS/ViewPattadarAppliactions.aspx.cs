using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_ViewPattadarAppliactions : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    string rstages = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            GetDetails();
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }

    }

    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            rstages = Request.QueryString[0].ToString().Trim();

            DataSet dsn = new DataSet();

            dsn = GetShowPattadar(Session["uid"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());

            if (dsn.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                if (rstages == "12" || rstages == "3")
                {
                    grdDetails.Columns[18].Visible = false;//Rejected reason
                    grdDetails.Columns[19].Visible = false;//status
                }
                if (rstages == "13")//if approved
                {
                    grdDetails.Columns[18].Visible = false;
                    grdDetails.Columns[19].Visible = true;
                }
                if (rstages == "16") //if rejected
                {
                    grdDetails.Columns[18].Visible = true;
                    grdDetails.Columns[19].Visible = false;

                }

            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
    }
    public DataSet GetShowPattadar(string DistrictUID, string intStageid, string DistrictID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        da = new SqlDataAdapter("GetPattadarDistrictwiseAppl", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;


        if (DistrictUID.Trim() == "" || DistrictUID.Trim() == null)
            da.SelectCommand.Parameters.Add("@DistrictUID", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@DistrictUID", SqlDbType.VarChar).Value = DistrictUID.ToString();
        if (intStageid.Trim() == "" || intStageid.Trim() == null)
            da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

        if (DistrictID.Trim() == "" || DistrictID.Trim() == null)
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID.ToString();


        da.Fill(ds);
        return ds;

    }



    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            rstages = Request.QueryString[0].ToString().Trim();
            if (rstages == "12" || rstages == "4")
            {
                grdDetails.Columns[18].Visible = false;
                grdDetails.Columns[19].Visible = false;
            }
            if (rstages == "13")//if approved
            {
                e.Row.Cells[19].Text = "Approved";
                e.Row.Cells[19].Font.Bold = true;
                // grdDetails.Columns[15].Visible = false;
            }

            if (rstages == "16")
            {
                grdDetails.Columns[18].Visible = true;//Rejected reason
                e.Row.Cells[19].Text = "Rejected";
                e.Row.Cells[19].Font.Bold = true;
            }
            HyperLink appl = (HyperLink)e.Row.Cells[16].Controls[0];
            appl.Target = "_blank";
            appl.NavigateUrl = "PrintPattalandappl.aspx?PattalandApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PATTADARID")).Trim();
            HyperLink attachmnt = (HyperLink)e.Row.Cells[17].Controls[0];
            attachmnt.Target = "_blank";
            attachmnt.NavigateUrl = "frmViewPattalandattachments.aspx?PattalandApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PATTADARID")).Trim()
                + "&StageID=" + Request.QueryString[0].ToString().Trim() 
                + "&ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
            //HyperLink Process = (HyperLink)e.Row.Cells[18].Controls[0];
            //Process.Target = "_blank";
            //Process.NavigateUrl = "frmProcessPattalandappl.aspx?PattalandApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PATTADARID")).Trim()
            //                        + "&ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();

        }
    }



    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
}