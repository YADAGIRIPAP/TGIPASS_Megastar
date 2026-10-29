using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_frmPaymentAdvertisement : System.Web.UI.Page
{
    Cls_OSAdvertisement obj_adv = new Cls_OSAdvertisement();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    int hp;
    DB.DB con = new DB.DB();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["intApplicationId"] != null)
            {
                Session["Applid"] = Convert.ToString(Request.QueryString["intApplicationId"]);
            }
                int CreatedBy = Convert.ToInt32(Session["uid"]);
            DataSet ds = obj_adv.GetAdvertisementAppIDbyuserid(CreatedBy);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["AdvertisementID_SO"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["AdvertisementID_SO"]);
                    string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                    if (App_Status == "2")
                    {
                        BtnSave1.Visible = true;
                        DataSet dsv = new DataSet();
                        dsv = null;
                        dsv = obj_adv.GetShowApprovalandFees_AdvertisemsntOther(Session["Applid"].ToString());
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
                        if (Request.QueryString["AdditionalPayment"] != null)
                        {
                            DataSet ds_ap = obj_adv.GetAdvertisementPayDetailsAddtionalPayment(Session["Applid"].ToString().Trim());
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                grdDetails.DataSource = ds.Tables[0];
                                grdDetails.DataBind();
                            }
                        }
                        else
                        {
                            BtnSave1.Visible = false;
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int s;

        string Result = "";
        string sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
        Session["onlinetransId"] = sonlinetrnsNo;

        int UIDUpdate = obj_adv.UpdateUIDAdvertisementSOA ("", hdnTransactionNumber.Value);
        DataSet dsnew = new DataSet();

        dsnew = GetUidnumber(hdnTransactionNumber.Value);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            //hdfUIDNumber.Value = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            Session["UID_no"] = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
        }



        //string UID_no = Session["uid"].ToString() + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
        //Session["UID_no"] = UID_no.ToString();
        string AdditionalPayment = "N";
        if (Request.QueryString["AdditionalPayment"] != null)
        {
            AdditionalPayment = "Y";
        }
        Session["AdditionalPayment"] = AdditionalPayment;

        //int UIDUpdate = obj_adv.UpdateUIDAdvertisementSOA(Session["UID_no"].ToString(), hdnTransactionNumber.Value);

        foreach (GridViewRow row in grdDetails.Rows)
        {

            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
            // string HdfAmount = (row.FindControl("Fees") as ).Text;

          //  s = Gen.insertDepartmentAprroval_TourismEvent(hdnTransactionNumber.Value, HdfQueid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), "N");
            if (Request.QueryString["AdditionalPayment"] != null)
            {
                AdditionalPayment = "Y";
            }
            else
            {
                s = obj_adv.insertDepartmentAprroval_AdvertisementSOA(hdnTransactionNumber.Value, HdfQueid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), "N");
            }

            DataSet dsch = new DataSet();
            dsch = obj_adv.getAdvertisementtdatabyQues(hdnTransactionNumber.Value);
            if (dsch.Tables[0].Rows.Count > 0)
            {
                string Hdfeid = dsch.Tables[0].Rows[0]["CreatedBy"].ToString();
               
                int A = obj_adv.InsertPaymentBillDesk_AdvertisementSOA(Session["UID_no"].ToString(), Convert.ToString(Session["Applid"]), sonlinetrnsNo, HdfQueid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "TE", Session["AdditionalPayment"].ToString());

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
                Response.Redirect("Kotakadvertisement.aspx");
            }
            catch (Exception ex)
            {

            }

        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyAdvertisement.aspx");
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
            da = new SqlDataAdapter("getUIDNumberdata_Advertisement", con.GetConnection);
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