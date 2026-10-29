using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmADMGViewAppl : System.Web.UI.Page//to get Distric wise View
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
           
            dsn = GetShowADMGDepartmentFiles(Session["uid"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());

            if (dsn.Tables[0].Rows.Count > 0)
            {
                
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();

                if (rstages == "12" || rstages == "4")
                {
                    grdDetails.Columns[15].Visible = false;//Rejected reason
                    grdDetails.Columns[16].Visible = false;//signed DGPS
                    grdDetails.Columns[17].Visible = false;//status
                }
                if (rstages == "13")//if approved
                {
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = true;
                    grdDetails.Columns[15].Visible = false;
                }
                if (rstages == "16") //if rejected
                {
                    grdDetails.Columns[15].Visible = true;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = true;
               
                }
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        } 
    }

    public DataSet GetShowADMGDepartmentFiles(string Created_by, string intStageid, string intDistrictid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        da = new SqlDataAdapter("GetADMGDistrictwiseAppl", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();
        if (intStageid.Trim() == "" || intStageid.Trim() == null)
            da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

        if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
            da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();


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
                grdDetails.Columns[15].Visible = false;
            }
            if (rstages == "13")//if approved
            {
                    e.Row.Cells[17].Text = "Approved";
                    e.Row.Cells[17].Font.Bold = true;
               // grdDetails.Columns[15].Visible = false;
            }

            if (rstages == "16")
            {
                //grdDetails.Columns[15].Visible = true;
                e.Row.Cells[17].Text = "Rejected";
                e.Row.Cells[17].Font.Bold = true;
            }

            HyperLink appl = (HyperLink)e.Row.Cells[13].Controls[0];
            appl.Target = "_blank";
            appl.NavigateUrl = "PrintADMGappl.aspx?ADMGApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();
            HyperLink attachmnt = (HyperLink)e.Row.Cells[14].Controls[0];
            attachmnt.Target = "_blank";
            attachmnt.NavigateUrl = "frmViewADMGattachments.aspx?Applid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID")).Trim()
                  + "&StageID=" + Request.QueryString[0].ToString().Trim() + 
                  "&ADMGID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();  
            HyperLink SignedDGPS = (HyperLink)e.Row.Cells[16].Controls[0];
            SignedDGPS.Target = "_blank";
            SignedDGPS.NavigateUrl = "frmViewADMGattachments.aspx?Applid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID")).Trim()
            +"&StageID=" + Request.QueryString[0].ToString().Trim()
            + "&ADMGID="+Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();

            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim();
            //Process.NavigateUrl = "frmProcessADMGappl.aspx?ADMGApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ADM_G_MineralID")).Trim()
            //                        + "&ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));

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