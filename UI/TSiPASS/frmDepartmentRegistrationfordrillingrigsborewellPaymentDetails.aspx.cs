using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSiPASS_frmDepartmentRegistrationfordrillingrigsborewellPaymentDetails : System.Web.UI.Page
{
    Cls_DrillingRigs obj_payment = new Cls_DrillingRigs();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    decimal TotalFee;
    string sonlinetrnsNo;
    string ApplicationID = "";


    string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["intApplicationId"] != null)
            {
                ApplicationID = Request.QueryString["intApplicationId"];
            }
            BtnDelete.Visible = false;
            DataSet dscheck = new DataSet();
            if (Request.QueryString["intApplicationId"] != null)
            {
                dscheck = obj_payment.GetUidnumber_drillingrigs(Request.QueryString["intApplicationId"].ToString());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    Session["UID_no"] = dscheck.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }
            }
            if (Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("Registrationfordrillingrigshandboring.aspx");
            }
            else
            {

                DataSet dspay = obj_payment.GetEnterPreniourPayDetailsPaidDetdrillingrigs(Session["Applid"].ToString().Trim());
                if (dspay.Tables[0].Rows.Count > 0)
                {
                    //already paid
                    grdDetails0.DataSource = dspay.Tables[0];
                    grdDetails0.DataBind();
                }
                else
                {
                    // should pay
                    DataSet ds = obj_payment.GetEnterPreniourPayDetailsDrillingRigs(Session["Applid"].ToString().Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = ds.Tables[0];
                        grdDetails.DataBind();
                        BtnDelete.Visible = true;
                    }
                }
            }
        }
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
                HdfQueid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

                e.Row.Cells[3].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");

                HiddenField HdfAmount = (HiddenField)e.Row.Cells[0].FindControl("HdfAmount");
                HdfAmount.Value = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString();

                HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
                HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();

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

    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        {
            Response.Redirect("waltaform2.aspx");
        }
        else
        {
            //generating          
            Session["AdditionalPayment"] = "N";
            if (Request.QueryString["AdditionalPayment"] != null)
            {
                Session["AdditionalPayment"] = "Y";
            }

            if (chkBuilldesc.Checked && rdbOnlineBankType.SelectedValue == "Kotak")
            {
                sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
                Session["onlinetransId"] = sonlinetrnsNo;
                //inset into Bill Desk payment disbursement table
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                    string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                    string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                    DataSet dsch = new DataSet();
                    dsch = obj_payment.GetEnterPreneurdatabyQue_DrillingRigs(HdfQueid);
                    if (dsch.Tables[0].Rows.Count > 0)
                    {
                        string UIDNOPresent = "";
                        string olduidno = dsch.Tables[0].Rows[0]["UID_No"].ToString();
                        if (string.IsNullOrEmpty(Convert.ToString(dsch.Tables[0].Rows[0]["UID_No"])))
                        {
                            string genuidno = obj_payment.InsertUIDGenerationGroundwater(Session["Applid"].ToString().Trim(), dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString(), HdfDeptid, HdfApprovalid, "Online", HdfAmount, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), olduidno);
                            Session["UID_no"] = Convert.ToString(genuidno);
                            UIDNOPresent = Convert.ToString(genuidno);
                        }
                        else
                        {

                            Session["UID_no"] = Convert.ToString(olduidno);
                            UIDNOPresent = Convert.ToString(olduidno);
                        }

                        int dept = obj_payment.insertDepartmentAprroval_DrillingRigs(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), "N");

                        int s = obj_payment.InsertPaymentBillDesk_DrillingRigs(UIDNOPresent, Convert.ToString(dsch.Tables[0].Rows[0]["intQuessionaireid"]), sonlinetrnsNo, HdfDeptid, HdfAmount, Convert.ToString(Session["uid"]), HdfApprovalid, "DRigs", Convert.ToString(Session["AdditionalPayment"]));
                    }

                }
                Response.Redirect("BilldeskPaymentPage_RegDrillingrigsborewells.aspx");
            }

        }

    }



    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
}