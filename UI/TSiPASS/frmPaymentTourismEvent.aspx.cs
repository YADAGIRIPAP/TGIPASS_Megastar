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

public partial class UI_TSiPASS_frmPaymentTourismEvent : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    int hp;
    DB.DB con = new DB.DB();
    decimal TotalFee = Convert.ToDecimal("0");
    Cls_TourismDashboard gentourism = new Cls_TourismDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int CreatedBy = Convert.ToInt32(Session["uid"]);
            DataSet ds = Gen.GetperformlicensebyTourismPerformanceLicenseID(CreatedBy);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                    string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                    string PoliceNOC = Convert.ToString(ds.Tables[0].Rows[0]["Police_NOC"]);
                    string StandbyFireService = Convert.ToString(ds.Tables[0].Rows[0]["StandbyFireService"]);

                    if (App_Status == "2")
                    {
                        BtnSave1.Visible = true;

                        DataSet dsv = new DataSet();
                        dsv = null;

                        //   DataSet dsTourism = new DataSet();
                        dsv = Gen.GetShowApprovalandFees_TourismEvent("108", Session["Applid"].ToString());
                        //  dsv.Tables[0].Merge(dsTourism.Tables[0]);

                        DataSet dsPolice = new DataSet();
                        if (PoliceNOC == "Y")
                        {
                            dsPolice = Gen.GetShowApprovalandFees_TourismEvent("107", Session["Applid"].ToString());
                            dsv.Tables[0].Merge(dsPolice.Tables[0]);
                        }

                        DataSet dsFire = new DataSet();
                        if (StandbyFireService == "Y")
                        {
                            dsFire = Gen.GetShowApprovalandFees_TourismEvent("106", Session["Applid"].ToString());
                            dsv.Tables[0].Merge(dsFire.Tables[0]);
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
                    else if (Request.QueryString["AdditionalPayment"] != null)
                    {
                        BtnSave1.Visible = true;
                        DataSet dsnew = new DataSet();
                        dsnew = gentourism.GetEnterPreniourPayDetailsAddtionalPaymentTourismEvent(Session["Applid"].ToString().Trim());
                        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                        {
                            grdDetails.DataSource = dsnew.Tables[0];
                            grdDetails.DataBind();
                            dvfeedetails.Visible = true;
                            //decimal sum = Convert.ToDecimal("0");
                            //foreach (GridViewRow row1 in grdDetails.Rows)
                            //{
                            //    if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                            //    {
                            //        sum = sum + Convert.ToDecimal(row1.Cells[5].Text);
                            //        //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
                            //    }
                            //}

                            ////HdfA.Value = sum.ToString();
                            //txtAmount.Text = HdfA.Value;
                            //TxtAmountOnline.Text = HdfA.Value;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void BindFees()
    {
        try
        {

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

        int UIDUpdate = Gen.UpdateUIDTourismEvent("", hdnTransactionNumber.Value);
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

        if (Request.QueryString["AdditionalPayment"] != null)
        {
            Session["AdditionalPayment"] = "Y";
        }
        //int UIDUpdate = Gen.UpdateUIDTourismEvent(Session["UID_no"].ToString(), hdnTransactionNumber.Value);

        foreach (GridViewRow row in grdDetails.Rows)
        {

            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
            // string HdfAmount = (row.FindControl("Fees") as ).Text;

            s = Gen.insertDepartmentAprroval_TourismEvent(hdnTransactionNumber.Value, HdfQueid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), "N");


            DataSet dsch = new DataSet();
            dsch = Gen.getTourisamEventdatabyQues(hdnTransactionNumber.Value);
            if (dsch.Tables[0].Rows.Count > 0)
            {
                string Hdfeid = dsch.Tables[0].Rows[0]["CreatedBy"].ToString();
                //int A = Gen.InsertPaymentBillDesk_tourismEvent(Session["UID_no"].ToString(), dsch.Tables[0].Rows[0]["CreatedBy"].ToString(), sonlinetrnsNo, HdfQueid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "TE", Session["AdditionalPayment"].ToString());
                int A = Gen.InsertPaymentBillDesk_tourismEvent(Session["UID_no"].ToString(), Convert.ToString(Session["Applid"]).Trim(), sonlinetrnsNo, HdfQueid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "TE", Session["AdditionalPayment"].ToString());

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
                Response.Redirect("KotakTourisamEvent.aspx");
            }
            catch (Exception ex)
            {

            }

        }
    }

    //protected void BtnClear0_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("frmPaymentTourismEvent.aspx");
    //}

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPaymentTourismEvent.aspx");
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
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
            // success.Visible = false;
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
            da = new SqlDataAdapter("getUIDNumberdata_Event", con.GetConnection);
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