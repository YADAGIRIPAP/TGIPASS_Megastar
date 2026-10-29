using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class UI_TSiPASS_frmPaymentTravelAgent : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    int hp;
    DB.DB con = new DB.DB();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int CreatedBy = Convert.ToInt32(Session["uid"]);
            DataSet ds = Gen.GetregtravelagentbytravelagentID(CreatedBy);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["TravelAgentID"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["TravelAgentID"]);
                    string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                    string Trade_License = Convert.ToString(ds.Tables[0].Rows[0]["DoyourequireTradeLicense"]);
                    string Shops_establishment = Convert.ToString(ds.Tables[0].Rows[0]["DoyourequireShopsEstablishmentLicense"]);
                    if (App_Status == "2")
                    {
                        BtnSave.Visible = true;

                        DataSet dsv = new DataSet();
                        dsv = null;

                        //   dataset dstourism = new dataset();
                        dsv = Gen.GetShowApprovalandFees_TravelAgent("114", Session["Applid"].ToString());
                        //  dsv.tables[0].merge(dstourism.tables[0]);

                        DataSet dspolice = new DataSet();
                        if (Trade_License == "Y")
                        {
                            dspolice = Gen.GetShowApprovalandFees_TravelAgent("112", Session["Applid"].ToString());
                            dsv.Tables[0].Merge(dspolice.Tables[0]);
                        }

                        DataSet dsfire = new DataSet();
                        if (Shops_establishment== "Y")
                        {
                            dsfire = Gen.GetShowApprovalandFees_TravelAgent("113" ,Session["Applid"].ToString());
                            dsv.Tables[0].Merge(dsfire.Tables[0]);
                        }

                        if (dsv.Tables[0].Rows.Count > 0)
                        {
                            grdDetails.DataSource = dsv.Tables[0];
                            grdDetails.DataBind();
                            dvfeedetails.Visible = true;
                        }
                        else
                        {
                            grdDetails.DataSource = null;
                            grdDetails.DataBind();
                            dvfeedetails.Visible = false;
                        }
                    }
                    else
                    {
                        BtnSave.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int s;

        string Result = "";
        string sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
        Session["onlinetransId"] = sonlinetrnsNo;

        int UIDUpdate = Gen.UpdateUIDTravelAgent("", hdnTransactionNumber.Value);
        DataSet dsnew = new DataSet();

        dsnew = GetUidnumber(hdnTransactionNumber.Value);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            //hdfUIDNumber.Value = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            Session["UID_no"] = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
        }

        //string UID_no = Session["uid"].ToString() + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
        //Session["UID_no"] = UID_no.ToString();
        Session["AdditionalPayment"] = "N";
        //int UIDUpdate = Gen.UpdateUIDTravelAgent(Session["UID_no"].ToString(), hdnTransactionNumber.Value);
        foreach (GridViewRow row in grdDetails.Rows)
        {

            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
            // string HdfAmount = (row.FindControl("Fees") as ).Text;



            s = Gen.insertDepartmentAprroval_TravelAgent(hdnTransactionNumber.Value, HdfQueid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), "N");


            DataSet dsch = new DataSet();
            dsch = Gen.getTravelAgentdatabyQues(hdnTransactionNumber.Value);
            if (dsch.Tables[0].Rows.Count > 0)
            {
                string Hdfeid = dsch.Tables[0].Rows[0]["CreatedBy"].ToString();
                int A = Gen.InsertPaymentBillDesk_TravelAgent(Session["UID_no"].ToString(), Convert.ToString(Session["Applid"]).Trim(), sonlinetrnsNo, HdfQueid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "TTA", Session["AdditionalPayment"].ToString());

                if (A == 0)
                {
                    Result = "Success";
                }
                else
                {
                    Result = "fail";
                }
            }



        }



        if (Result.ToUpper().ToString() == "SUCCESS")
        {
            try
            {
                Response.Redirect("KotakTravelAgent.aspx");
            }
            catch (Exception ex)
            {

            }

        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPaymentTravelAgent.aspx");
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
                TotalFee = TotalFee + TotalFee1;

                Session["Amount"] = TotalFee;

                HiddenField HdfApprovalid = (HiddenField)e.Row.Cells[0].FindControl("HdfApprovalid");
                HdfApprovalid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim();

                HiddenField HdfQueid = (HiddenField)e.Row.Cells[0].FindControl("HdfQueid");
                HdfQueid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();

                e.Row.Cells[3].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");

                HiddenField HdfAmount = (HiddenField)e.Row.Cells[0].FindControl("HdfAmount");
                HdfAmount.Value = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");
            }
            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[2].Text = "Total Fee";
                e.Row.Cells[3].Text = TotalFee.ToString("#,##0");


            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public DataSet GetUidnumber(string intQuessionaireid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getUIDNumberdata_Agent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();



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