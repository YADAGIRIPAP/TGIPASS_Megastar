using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmADMGmandalwiseView : System.Web.UI.Page
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

            dsn = GetShowADMGDepartmentFiles(Session["uid"].ToString().Trim(), rstages.ToString().Trim(), Session["MROMandalID"].ToString().Trim());

            if (dsn.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                if(rstages=="16"|| rstages == "13"||rstages == "3")
                {
                    grdDetails.Columns[15].Visible = false;

                }
                if (rstages == "3"|| rstages == "12")
                {
                    grdDetails.Columns[16].Visible = false;

                }


            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
    }
    public DataSet GetShowADMGDepartmentFiles(string MandalUID, string intStageid, string MROMandalID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        da = new SqlDataAdapter("GetADMGmandalwiseAppl", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;


        if (MandalUID.Trim() == "" || MandalUID.Trim() == null)
            da.SelectCommand.Parameters.Add("@MandalUID", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@MandalUID", SqlDbType.VarChar).Value = MandalUID.ToString();
        if (intStageid.Trim() == "" || intStageid.Trim() == null)
            da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

        if (MROMandalID.Trim() == "" || MROMandalID.Trim() == null)
            da.SelectCommand.Parameters.Add("@MROMandalID", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@MROMandalID", SqlDbType.VarChar).Value = MROMandalID.ToString();


        da.Fill(ds);
        return ds;

    }
    


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        rstages = Request.QueryString[0].ToString().Trim();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (rstages == "13")//if approved
            {
                e.Row.Cells[16].Text = "Approved";
                e.Row.Cells[16].Font.Bold = true;
                // grdDetails.Columns[15].Visible = false;
            }
            if (rstages == "16")
            {
                //grdDetails.Columns[15].Visible = true;
                e.Row.Cells[16].Text = "Rejected";
                e.Row.Cells[16].Font.Bold = true;
            }
            HyperLink appl = (HyperLink)e.Row.Cells[13].Controls[0];
            appl.Target = "_blank";
            appl.NavigateUrl = "PrintADMGappl.aspx?ADMGApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();
            HyperLink attachmnt = (HyperLink)e.Row.Cells[14].Controls[0];
            attachmnt.Target = "_blank";
            attachmnt.NavigateUrl = "frmViewADMGattachments.aspx?Applid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID")).Trim()
                + "&StageID=" + Request.QueryString[0].ToString().Trim() +"&ADMGID="+
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();
            HyperLink Process = (HyperLink)e.Row.Cells[15].Controls[0];
            Process.Target = "_blank";
            Process.NavigateUrl = "frmProcessADMGappl.aspx?ADMGApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim()
                                    + "&ID="+ Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
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