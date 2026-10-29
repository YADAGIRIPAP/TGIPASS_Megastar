using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_UpdateCheckNumberListALL : System.Web.UI.Page
{
    General gen = new General();
    string DIPCFlag = "";
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFinancialYears(ddlFinancialYear);
            //txtsvcdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //string[] datett = txtsvcdate.Text.Trim().Split('/');
            //string ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];

            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            }


            Button2_Click(sender, e);
            //DataSet ds = new DataSet();
            //ds = gen.getincentiveslclistWorkigngList(ProposedDate);


            //grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            //grdDetailsPavallavaddiSC.DataBind();
        }
    }
    // SC CAtegory

    public void BindFinancialYears(DropDownList ddlFinYear)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlFinYear.Items.Clear();
            dsd = gen.GetFinancialYearsForReports();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlFinYear.DataSource = dsd.Tables[0];
                ddlFinYear.DataValueField = "SlNo";
                ddlFinYear.DataTextField = "FinancialYear";
                ddlFinYear.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlFinYear);
                //}
            }


            ddlFinYear.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            //string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblsubInctypeid = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblInctypeId")).Text;

            string DIPCFlag = "";
            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            }
            string distid = "";
            if (Session["DistrictID"].ToString().Trim() != null && Session["DistrictID"].ToString().Trim() != "")
            {
                distid = Session["DistrictID"].ToString().Trim();
            }

            //Response.Redirect("CheckListPrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text);

            Response.Redirect("UpdateCheckNumberDeatailFinalALL.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + ddlapplicationto.SelectedValue + "&SubIncTypeId=" + lblsubInctypeid + "&DIPC=" + DIPCFlag + "&Districtid=" + distid);

            //Response.Redirect("UpdateCheckDeatailFinal.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + ddlapplicationto.SelectedValue+"&SubIncTypeId=" + lblsubInctypeid );

            //if (indexing == 0 || indexing == 1 || indexing == 2 || indexing == 3 || indexing == 4)
            //{
            //    Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
            //}
            //if (indexing == 5 || indexing == 6 || indexing == 7 || indexing == 8 || indexing == 9)
            //{
            //    Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
            //}
            //if (indexing == 10 || indexing == 11 || indexing == 12 || indexing == 13 || indexing == 14)
            //{
            //    Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
            //}
        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);

            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string DIPCFlag = "";
        string distid = "";
        if (Session["DistrictID"].ToString().Trim() != null && Session["DistrictID"].ToString().Trim() != "")
        {
            distid = Session["DistrictID"].ToString().Trim();
        }
        if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
        {
            DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
        }
        // string SLcDate = ddlapplicationto.SelectedValue;
        string SLcDate = "";
        SLcDate = ddlapplicationto.SelectedItem.Text.Trim();
        // SLcDate= Convert.ToDateTime(ddlapplicationto.SelectedValue).ToString("yyyy/MM/dd");
        ds = getincentiveslclistWorkigngListNEW(SLcDate, DIPCFlag, distid);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // trConvened.Visible = true;
            // txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }

    protected void ddlFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = getChecklistDtls(DIPCFlag, ddlFinancialYear.SelectedValue, ddlcategory.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlapplicationto.DataSource = ds.Tables[0];
            ddlapplicationto.DataValueField = "ReleaseProceedingNo";  //"CheckPrintedDatenew";
            ddlapplicationto.DataTextField = "ReleaseProceedingNo";  //"CheckPrintedDate";
            ddlapplicationto.DataBind();
            ddlapplicationto.Items.Insert(0, "--Select--");
        }

        else
        {
            ddlapplicationto.Items.Clear();
            ddlapplicationto.Items.Insert(0, "--Select--");
        }
    }

    public DataSet getChecklistDtls(string DIPCFlag, string FinalId, string Caste)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_NOTUPADTED_CHECKLIST_ALL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@DIPCFlag", SqlDbType.VarChar).Value = DIPCFlag;
            da.SelectCommand.Parameters.Add("@FinancialYearCd", SqlDbType.VarChar).Value = FinalId;
            da.SelectCommand.Parameters.Add("@CASTE", SqlDbType.VarChar).Value = Caste;
            //da.SelectCommand.Parameters.Add("@ISPH", SqlDbType.VarChar).Value = Isph;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public DataSet getincentiveslclistWorkigngListNEW(string date, string DIPCFlag, string distid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_WORKING_ABSTRACT_PRINTEDDATE_CHECKNO_ALL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            da.SelectCommand.Parameters.Add("@DIPCFlag", SqlDbType.VarChar).Value = DIPCFlag;
            if (distid.Trim() == "" || distid.Trim() == null || distid.Trim().ToLower() == "--select--")
                da.SelectCommand.Parameters.Add("@DISTID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DISTID", SqlDbType.VarChar).Value = distid.ToString();
            
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}