using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net;

public partial class UI_TSiPASS_DepartmentApprovalDetailsSWG : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    BMWClass ObjBMW = new BMWClass();
    decimal TotalFee;
    decimal TotalFeeNExt;
    decimal TotalAmountExt;
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string sonlinetrnsNo;
    static DataTable dtMyTable;
    DB.DB conn = new DB.DB();
    //RequestURL objRequestURL = new RequestURL();
    string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    WebClient wc = new WebClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                    Binddata();
                else
                {
                    Response.Redirect("~/SWGDashboard.aspx");
                }
            }
        }
        else { Response.Redirect("~/Ipasslogin.aspx"); }

    }
    public void Binddata()
    {
        try
        {
            DataSet dscheck = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GETSWGPaymentDetails", connection))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Transaction = transaction;

                        da.SelectCommand.Parameters.AddWithValue("@SWGQDId", Convert.ToString(Request.QueryString["SWGQDId"]));

                        da.Fill(dscheck);
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
            {
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = Hdfeid.Value = dscheck.Tables[0].Rows[0]["SCD_QDID"].ToString().Trim();
                    Session["UIDNO"] = hdfUIDNumber.Value = dscheck.Tables[0].Rows[0]["UIDNo"].ToString().Trim();
                    Session["intCFEEnterpid"] = dscheck.Tables[0].Rows[0]["SCD_CREATEDBY"].ToString().Trim();
                }
                if (dscheck.Tables[1].Rows.Count > 0) //---- to be paid
                {
                    grdDetails.DataSource = dscheck.Tables[1];
                    grdDetails.DataBind();
                    paynot.Visible = false;
                    paynotOnline.Visible = true;
                    BtnPay.Text = "Pay";
                    rdbOnlineBankType.Visible = true;
                    TxtAmountOnline.Text = txtAmount.Text = Convert.ToString(dscheck.Tables[1].Rows[0]["Fees"]);

                    if (TxtAmountOnline.Text == "0")
                    {
                        BtnPay.Text = "Submit Application";
                    }
                    else
                    {
                        BtnPay.Text = "Pay";
                    }
                }
                if (dscheck.Tables[2].Rows.Count > 0) //-------paid
                {
                    grdPaidDetails.DataSource = dscheck.Tables[2];
                    grdPaidDetails.DataBind();
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
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            //decimal TotalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            TotalFee = TotalFee + TotalFee1;
            string s = "0";
            if (e.Row.Cells[5].Text != "")
            {
                s = e.Row.Cells[5].Text;
            }
            decimal TotalFee1a = Convert.ToDecimal(s);
            TotalFeeNExt = TotalFeeNExt + TotalFee1a;

            //decimal TotalAmount1 = Convert.ToDecimal(s);
            //TotalAmountExt = TotalAmountExt + TotalAmount1;

            HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
            HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
            HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");

            HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();
            HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim();
                        

            if (HdfApprovalid.Value == "173")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }
            
            if (Convert.ToDouble(HdfAmount.Value) == 0)
            {
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "35")
            {
                grdDetails.Columns[6].Visible = true;
            }
            else
            {
                grdDetails.Columns[6].Visible = false;
            }
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = TotalFee.ToString();
            //   e.Row.Cells[5].Text = TotalFeeNExt.ToString();

        }
    }
    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");

        if (ChkApproval.Checked == true)
        {
            row.Cells[5].Text = row.Cells[3].Text;

        }
        else
        {
            row.Cells[5].Text = "0";


        }
        decimal sum = Convert.ToDecimal("0");
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (row1.Cells[5].Text != "" && row1.Cells[5].Text != "0")
                {

                    sum = sum + Convert.ToDecimal(row1.Cells[5].Text);
                }


                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
            }
        }

        HdfA.Value = sum.ToString();
        txtAmount.Text = HdfA.Value;
        TxtAmountOnline.Text = HdfA.Value;
        if (TxtAmountOnline.Text == "0")
        {
            BtnPay.Text = "Submit Applications";
        }
        else
        {
            BtnPay.Text = "Pay";
        }
    }
    protected void rdbOnlineBankType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbOnlineBankType.SelectedValue == "Billdesk" )
        {
            trbuilddesc.Visible = true;
        }
        else
        {
            trbuilddesc.Visible = false;
        }
    }
    protected void BtnPay_Click(object sender, EventArgs e)
    {
        if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        {
            Response.Redirect("SWGDashboard.aspx");
        }
        else
        {
            int selectioncount = 0;
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    string HdfApprovalidnew = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    if (HdfApprovalidnew.Trim() != "33")
                    {
                        selectioncount = selectioncount + 1;
                    }
                }
            }

            if (selectioncount == 0)
            {
                lblmsg0.Text = "<font color='red'>Please Select Atleaset one Department for Approval ..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            Session["AdditionalPayment"] = "";
            Session["Amount"] = TxtAmountOnline.Text;

            if (Request.QueryString["AdditionalPayment"] != null)
            {
                Session["AdditionalPayment"] = "Y";
            }
            else
            {

            }

            if (rdbOnlineBankType.SelectedValue.ToString().Trim() == "Kotak")
            {
                sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
                Session["onlinetransId"] = sonlinetrnsNo;
                //inset into SBI payment disbursement table
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();



                        // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                        int s = Gen.InsertPaymentBillDesk(Session["UIDNO"].ToString(), Hdfeid.Value, sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "SWG", Session["AdditionalPayment"].ToString());

                        if (TxtAmountOnline.Text == "0")
                        {
                            int quedata = updatenonPaymentinSWG(HdfQueid, Session["uid"].ToString(), HdfApprovalid, HdfAmount);
                            lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
                            success.Visible = true;
                            Failure.Visible = false;
                        }
                    }
                }
                if (TxtAmountOnline.Text == "0")
                {
                   // int quedata = updatenonPaymentinRENQueNew(HdfQueid, Session["uid"].ToString(), HdfApprovalid, HdfAmount);
                    //Webserviceren(Session["UID_no"].ToString());
                }
                else
                {
                    Response.Redirect("KotakPageSWG.aspx");
                }
            }




        }
    }
    public int updatenonPaymentinSWG(string intQuessionaireCFOid, string Created_by, string HdfApprovalid, string HdfAmount)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[Updatedataswithoutpayments_SWG]";

        if (intQuessionaireCFOid == "" || intQuessionaireCFOid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireCFOid.Trim();


        if (Created_by == "" || Created_by == null || Created_by == "--Select--")
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = HdfApprovalid.Trim();
        com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = HdfAmount.Trim();
        conn.OpenConnection();
        com.Connection = conn.GetConnection;

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
            conn.CloseConnection();
        }

    }


}