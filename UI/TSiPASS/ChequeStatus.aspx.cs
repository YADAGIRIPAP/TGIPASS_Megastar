using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_ChequeStatus : System.Web.UI.Page
{
    General gen = new General();
    DataSet Gds = null;
    string DIPCFlag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFinancialYears(ddlFinancialYear);
            txtsvcdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //string[] datett = txtsvcdate.Text.Trim().Split('/');
            //string ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];

            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            }


            //DataSet ds = new DataSet();
            //ds = gen.getincentiveslclistWorkigngList(ProposedDate);


            //grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            //grdDetailsPavallavaddiSC.DataBind();
        }
    }

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

            Response.Redirect("CheckStatusUpdatedDetails.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text + "&RlsProceedNo=" + ddlapplicationto.SelectedValue + "&checkNo=" + ddlCheckList.SelectedValue + "&SubIncTypeId=" + lblsubInctypeid + "&DIPC=" + DIPCFlag);

            //Response.Redirect("CheckListPrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text);
            // Response.Redirect("UpdateCheckChearenceDate.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text + "&RlsProceedNo=" + ddlapplicationto.SelectedValue + "&checkNo=" + ddlCheckList.SelectedValue + "&SubIncTypeId=" + lblsubInctypeid);

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
        string releaseProcedingno = ddlapplicationto.SelectedValue;
        string checkno = ddlCheckList.SelectedValue;
        string DIPCFlag = "";
        if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
        {
            DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
        }

        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@releaseProceno",SqlDbType.VarChar),
                 new SqlParameter("@checkno",SqlDbType.VarChar),
                  new SqlParameter("@DIPCFlag",SqlDbType.VarChar)
            };
        pp[0].Value = releaseProcedingno;
        pp[1].Value = checkno;
        pp[2].Value = DIPCFlag;



        ds = gen.GenericFillDs("USP_GET_LIST_INCENTIVEWISE_CHECKCLEARENCE_ABSTRACT", pp);



        //ds = gen.getincentivesClearenceDtls(releaseProcedingno,checkno); 

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // trConvened.Visible = true;
            // txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }


    //public DataSet getincentivesClearenceDtls(string releaseProcedingno, string checkno)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_CHECKCLEARENCE_ABSTRACT", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.SelectCommand.Parameters.Add("@releaseProceno", SqlDbType.VarChar).Value = releaseProcedingno;
    //        da.SelectCommand.Parameters.Add("@checkno", SqlDbType.VarChar).Value = checkno;

    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}




    protected void ddlapplicationto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlapplicationto.SelectedItem.Value != "0")
        {
            trCheckblock.Visible = true;
            BindChecksList();
        }
        else
        {
            trCheckblock.Visible = false;
        }
    }

    public void BindChecksList()
    {
        if (Gds != null && Gds.Tables.Count > 0 && Gds.Tables[0].Rows.Count > 0)
        {
            var result = Gds.Tables[0].AsEnumerable().Where(w => w.Field<String>("ReleaseProceedingNo") == ddlapplicationto.SelectedValue).Select(g => new { checkNo = g.Field<String>("CheckNO") });
            ddlCheckList.Items.Clear();
            ddlCheckList.Items.Insert(0, new ListItem(" Select ", "0"));

            foreach (var ListItems in result)
            {
                ListItem li = new ListItem();
                li.Text = ListItems.checkNo;
                li.Value = ListItems.checkNo.ToString();
                ddlCheckList.Items.Add(li);
            }
        }
        else
        {
            string DIPCFlag = "";
            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            }
            DataSet ds = new DataSet();
            ds = gen.getCheckNOlistDtls(DIPCFlag, ddlFinancialYear.SelectedValue);
            Gds = ds;
            BindChecksList();
        }
    }

    protected void ddlCheckList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCheckList.SelectedItem.Value != "0")
        {
            Button2.Visible = true;
        }
        else
        {
            Button2.Visible = false;
        }
    }

    protected void ddlFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = gen.getCheckNOlistDtls(DIPCFlag, ddlFinancialYear.SelectedValue);



        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Gds = ds;
            var result = Gds.Tables[0].AsEnumerable().GroupBy(r => r.Field<String>("ReleaseProceedingNo")).Select(g => new { Rpno = g.First().Field<string>("ReleaseProceedingNo") });
            ddlapplicationto.Items.Clear();
            ddlapplicationto.Items.Insert(0, new ListItem(" Select ", "0"));

            foreach (var ListItems in result)
            {
                ListItem li = new ListItem();
                li.Text = ListItems.Rpno;
                li.Value = ListItems.Rpno.ToString();
                ddlapplicationto.Items.Add(li);
            }
            //ddlapplicationto.DataSource = ds.Tables[0];
            //ddlapplicationto.DataValueField = "ReleaseProceedingNo"; // "CheckNO";
            //ddlapplicationto.DataTextField = "ReleaseProceedingNo"; // "CheckNO";
            //ddlapplicationto.DataBind();

        }

        else
        {
            ddlapplicationto.Items.Clear();
            ddlapplicationto.Items.Insert(0, "--Select--");
            ddlCheckList.Items.Clear();
            ddlCheckList.Items.Insert(0, new ListItem(" Select ", "0"));
        }
    }
}