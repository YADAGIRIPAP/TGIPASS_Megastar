using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_frmPaymentMobiletowerTSROW : System.Web.UI.Page
{
  
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
            if (Request.QueryString["mobiletowerid"] != null)
            {
                Session["Applid"] = Convert.ToString(Request.QueryString["mobiletowerid"]);
            }
            int CreatedBy = Convert.ToInt32(Session["uid"]);
            DataSet ds = GetTSROWMOBILETOWERAppIDbyuserid(CreatedBy, Request.QueryString[0].ToString());//DONE
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileTowerID"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["MobileTowerID"]);
                    string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationStatus"]);
                    if (App_Status == "2")
                    {
                        BtnSave1.Visible = true;
                        DataSet dsv = new DataSet();
                        dsv = null;
                        dsv = GetShowApprovalandFees_MOBILETOWERTSROW("151", "61", hdnTransactionNumber.Value);//done
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
                            DataSet ds_ap = GeMOBILETOWERTSROWPayDetailsAddtionalPayment(Session["Applid"].ToString().Trim());//done
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
    public DataSet GetTSROWMOBILETOWERAppIDbyuserid(int UserID, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetTSROWMOBILETOWERAppIDbyuserid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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
    public DataSet GetShowApprovalandFees_MOBILETOWERTSROW(string Approvalid, string deptid, string mobiletowerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFees_TSROWMOBILETOWER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Approvalid.Trim() == "" || Approvalid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Approvalid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Approvalid", SqlDbType.VarChar).Value = Approvalid.ToString();
            if (deptid.Trim() == "" || deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@deptid", SqlDbType.VarChar).Value = deptid.ToString();

            if (mobiletowerid.Trim() == "" || mobiletowerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@mobiletowerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@mobiletowerid", SqlDbType.VarChar).Value = mobiletowerid.ToString();

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


    public DataSet GeMOBILETOWERTSROWPayDetailsAddtionalPayment(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetMOBILETOWERTSROWDetails_AddtionalPayment", con.GetConnection);
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int s;

        string Result = "";
        string sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
        Session["onlinetransId"] = sonlinetrnsNo;

        string UID_no = "ROW"+Session["uid"].ToString() + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
        Session["UID_no"] = UID_no.ToString();
        int UIDUpdate = UpdateUIDMOBILETOWERTSROW(Session["UID_no"].ToString(), hdnTransactionNumber.Value);//DONE
        DataSet dsnew = new DataSet();

        dsnew = GetUidnumber(hdnTransactionNumber.Value);//DONE
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
                s = insertDepartmentAprroval_MOBILETOWERTSROW(hdnTransactionNumber.Value, HdfQueid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), "N");//DONE
            }

            DataSet dsch = new DataSet();
            dsch = getMOBILETOWERTSROWdatabyQues(hdnTransactionNumber.Value);
            if (dsch.Tables[0].Rows.Count > 0)
            {
                string Hdfeid = dsch.Tables[0].Rows[0]["CreatedBy"].ToString();

                int A = InsertPaymentBillDesk_MOBILETOWERTSROW(Session["UID_no"].ToString(), Convert.ToString(Session["Applid"]), sonlinetrnsNo, HdfQueid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "MS", Session["AdditionalPayment"].ToString());

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
                Response.Redirect("KotakMobileTowerTSROW.aspx");
            }
            catch (Exception ex)
            {

            }

        }
    }
    public int insertDepartmentAprroval_MOBILETOWERTSROW(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insDepartmentApprovals_MOBILETOWERTSROW";

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (Approval_Fee == "" || Approval_Fee == null)
            com.Parameters.Add("@Approval_Fee", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval_Fee", SqlDbType.Decimal).Value = Convert.ToDecimal(Approval_Fee.Trim());

        if (IsPayment == "" || IsPayment == null)
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = IsPayment;

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (IsOffline == "" || IsOffline == null)
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = IsOffline.Trim();
        con.OpenConnection();
        com.Connection = con.GetConnection;
        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int UpdateUIDMOBILETOWERTSROW(string UID_no, string intQuessionaireid)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("UpdateUID_MOBILETOWERTSROW", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@UID_no", UID_no);
            cmd.Parameters.AddWithValue("@intQuessionaireid", intQuessionaireid);
            cmd.ExecuteNonQuery();
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }

        return valid;
    }
    public DataSet getMOBILETOWERTSROWdatabyQues(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getMOBILETOWERTSROWdatabyQues", con.GetConnection);
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

    public int InsertPaymentBillDesk_MOBILETOWERTSROW(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INSERT_Builldesc_PaymentDtls";

        if (UidNo.Trim() == "" || UidNo.Trim() == null)
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UidNo.Trim();
        }
        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

        if (OnlineOrderNo == "" || OnlineOrderNo == null)
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = OnlineOrderNo.Trim();


        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());


        if (Online_Amount == "" || Online_Amount == null)
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = Convert.ToDecimal(Online_Amount.Trim());


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
        }
        if (AdditionalPayment == "" || AdditionalPayment == null)
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();

        com.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.Trim();
        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
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
            da = new SqlDataAdapter("getUIDNumberdata_TSROWMOBILETOWER", con.GetConnection);
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