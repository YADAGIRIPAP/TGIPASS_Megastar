using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.IO;

public partial class UI_TSiPASS_SactionViewSLC : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string paths = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }
        if (!IsPostBack)
        {
            string statusnew = Request.QueryString["stage"].ToString().Trim();
            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            h1heading.InnerHtml = Cast + " Category";
           // txtsvcdate.Text = Request.QueryString[2].ToString();

            string status = "1";
           // string distid = Session["DistrictID"].ToString().Trim();

            string dateslc = Request.QueryString[2].ToString();
            txtslcnodate.Text = Request.QueryString[3].ToString();
            DataSet ds = new DataSet();

            ds = Gen.getReleaseProceedingsAssignSLCDATENOUpdated(Cast, Investmentid, dateslc, statusnew);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                btnSubmit.Visible = true;

                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                ViewState["IncentiveType"] = "";
                ViewState["IncentiveType"] = ds.Tables[1].Rows[0]["IncentiveName"].ToString();
            }
            else
            {
                btnSubmit.Visible = false;
            }


            //DataSet dsnew = new DataSet();
            //dsnew = Gen.getincentiveslcfinallistNewFinalsaction("2", "6", "2");
            //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            //{
            //    gvdetailsfinalproforma.DataSource = dsnew.Tables[0];
            //    gvdetailsfinalproforma.DataBind();
            //}

            //if (!IsPostBack)
            //{
            //    fetchIncentivedet();
            //}
        }
    }
    protected void GetDepartment()
    {

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }

    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.fetchIncentivedetIPONewIncTypeAddlDirector(Session["uid"].ToString(), "3", "", "");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvdetailsnew.DataSource = ds.Tables[0];
            gvdetailsnew.DataBind();
            btnSubmit.Visible = true;
        }
        else
        {
            btnSubmit.Visible = false;
        }
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        //ExportToExcel();
    }

    protected void bntUpload_Click(object sender, EventArgs e)
    {
        string EnterperIncentiveId = "";
        string MstIncentiveId = "";
        string SLCNumer = "";
        string message = "";
        if (txtslcno.Text == "" && txtslcnodate.Text == "")
        {
            message = "Please Enter SLC No \\nPlease Enter SLC Date";
        }
        else
            if (txtslcno.Text == "")
            {
                message = "Please Enter SLC No";
            }
            else
                if (txtslcnodate.Text == "")
                {
                    message = "Please Enter SLC Date";
                }
        if (message != "")
        {
            string message1 = "alert('" + message + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
            return;
        }



        string newPath = "";
        string sFileDir = Server.MapPath("~\\GoCOIIncentiveAttachments");
        General t1 = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();


        SLCNumer = txtslcno.Text;

        if (fucMinOfMeet.HasFile)
        {
            if ((fucMinOfMeet.PostedFile != null) && (fucMinOfMeet.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fucMinOfMeet.PostedFile.FileName);
                try
                {
                    string[] fileType = fucMinOfMeet.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, SLCNumer);

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        //int count = dir.GetFiles().Length;
                        //if (count == 0)

                        fucMinOfMeet.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);

                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        fucReleaseProCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        foreach (GridViewRow gvrow in gvdetailsnew.Rows)
                        {
                            EnterperIncentiveId = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                            MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                            objDml.InsUpdCOI_Incentive_Attachments(1, Convert.ToInt32(MstIncentiveId), Convert.ToInt32(EnterperIncentiveId), Convert.ToInt32(SLCNumer), sFileName, newPath, Convert.ToInt32(Session["uid"].ToString()));
                        }



                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lnkMinOfMeeting.Text = fucMinOfMeet.FileName;
                        lnkMinOfMeeting.NavigateUrl = newPath + "\\" + sFileName;

                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception ex)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

    }
    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        int valid = 0;
        foreach (GridViewRow gvrow in gvdetailsnew.Rows)
        {
            officerRemarks fromvo = new officerRemarks();
            int rowIndex = gvrow.RowIndex;

            fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
            fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
            string ApproveStatus = ((RadioButtonList)gvrow.FindControl("rbtnLstApprove")).SelectedValue;
            string rejectedRemarks = ((TextBox)gvrow.FindControl("txtIncQueryFnl2")).Text.Trim();
            string SactionnedAmount = ((TextBox)gvrow.FindControl("txtsactionnedAmount")).Text.Trim();
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
            if (ApproveStatus == "Y")
            {
                fromvo.status = "File in full shape";
                fromvo.Remarks = SactionnedAmount;
            }
            if (ApproveStatus == "N")
            {
                fromvo.status = "Reject";
                fromvo.Remarks = rejectedRemarks;
            }

            string[] datett = txtslcnodate.Text.Trim().Split('/');
            // commented by chaitanya
            fromvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
           // fromvo.Slcdate = txtslcnodate.Text.Trim();
            fromvo.SLCNO = txtslcno.Text.Trim();

            fromvo.CreatedByid = Session["uid"].ToString();
            fromvo.Designation = Role_Code.Trim();
            //return;

            valid = Gen.InsertincentiveSLCBulkinsert(fromvo, "POSTSLC");   // commented on 01.03.2018  for testing

            // added by chh on 28.02.2018 for SMS & email alert to applicant at the time of SLC sanctioned(approved in SLC)
            if (valid == 1)
            {
                if (ApproveStatus == "Y")
                {
                    // SendSmsEmail(fromvo.EnterperIncentiveID, fromvo.MstIncentiveId);
                }
            }
            
        }

        if (valid == 1)
        {
            string message = "alert('SLC Proceedings Updated Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            string Investmentid = Request.QueryString[1].ToString();
            string[] datett = txtslcnodate.Text.Trim().Split('/');
            string Slcdatenew = datett[2] + "/" + datett[1] + "/" + datett[0];
            DataSet dsnew = new DataSet();
            dsnew = Gen.getincentiveslcfinallistNewFinalsaction(txtslcno.Text.Trim(), Investmentid, Slcdatenew);
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {
                gvdetailsfinalproforma.DataSource = dsnew.Tables[0];
                gvdetailsfinalproforma.DataBind();
            }
        }
    }
    protected void gvdetailsfinalproforma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);

            Label lblScheme = (e.Row.FindControl("lblScheme") as Label);
            Label lblDIPCNumer = (e.Row.FindControl("lblDIPCNumer") as Label);
            Label lblOfflineFlag = (e.Row.FindControl("lblOfflineFlag") as Label);
            Label lbloffiline= (e.Row.FindControl("lbloffiline") as Label);

            if (MstIncentiveId.Text == "6")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantInvestmentSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "1")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPavalaVaddiSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "3")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPowerCostSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "5")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSalesTaxSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            //if (MstIncentiveId.Text == "9")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            //}
            if (MstIncentiveId.Text == "9" || MstIncentiveId.Text == "14" || MstIncentiveId.Text == "15" || MstIncentiveId.Text == "16" || MstIncentiveId.Text == "17")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim() + "&MstIncentiveId=" + MstIncentiveId.Text;
            }
            if (MstIncentiveId.Text == "4")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantCleanerProductionSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "7")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantIIDFSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "8")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantskillupgradationSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "10")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSeedCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "11")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantQualityCertificationSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "12")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantAdvanceSubsidyforSCSTSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }


            //if (MstIncentiveId.Text == "6")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantInvestmentSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "1")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPavalaVaddiSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "3")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPowerCostSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "5")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSalesTaxSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "9")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "4")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantCleanerProductionSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "7")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantIIDFSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "8")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantskillupgradationSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "10")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSeedCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "11")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantQualityCertificationSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
            //if (MstIncentiveId.Text == "12")
            //{
            //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantAdvanceSubsidyforSCSTSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            //}
        }
    }
    protected void rbtnLstApprove_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList ddlDeptnameFnl2 = (RadioButtonList)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
        TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2");
        if (ddlDeptnameFnl2.SelectedValue == "Y")
        {
            txtIncQuery.Visible = false;
        }
        else
        {
            txtIncQuery.Visible = true;
        }
    }


    public void SendSmsEmail(string incentiveid, string masterincentiveid)
    {
        string useridnew = Session["uid"].ToString();
        string IncentveID = incentiveid;
        DataSet dsAppliedIncentives = new DataSet();
        string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", ApplicationDate = "", DistrictName = ""; string applicationno = "";
        string incentivetype = ""; string sanctionedamount = ""; string SLCdate = "";

        //DataSet dscaste = Gen.GetIntimationLetterDtls(incentiveid, masterincentiveid, useridnew);

        DataSet dscaste = GetIntimationLetterDtls(incentiveid, masterincentiveid, useridnew);

        if (dscaste != null && dscaste.Tables.Count > 1 && dscaste.Tables[0].Rows.Count > 0 && dscaste.Tables[2].Rows.Count > 0)  
        {

            UnitName = dscaste.Tables[0].Rows[0]["UnitName"].ToString();
            if (!UnitName.ToUpper().ToString().Contains("M/S"))
            {
                UnitName = "M/s " + UnitName.ToString();
            }
            ApplicantName = dscaste.Tables[2].Rows[0]["ApplciantName"].ToString();
           //  UnitEmail = "krishna.cheripally@gmail.com";
             UnitEmail = dscaste.Tables[2].Rows[0]["UnitEmail"].ToString();
           //  UnitMobileNo = "9966889972";
            UnitMobileNo = dscaste.Tables[2].Rows[0]["UnitMObileNo"].ToString();
            ApplicationDate = dscaste.Tables[0].Rows[0]["DOA"].ToString();
            DistrictName = dscaste.Tables[0].Rows[0]["District"].ToString();

            applicationno = dscaste.Tables[0].Rows[0]["ApplicationNo"].ToString();
            incentivetype = ViewState["IncentiveType"].ToString();
            sanctionedamount = dscaste.Tables[0].Rows[0]["sanctionedamount"].ToString();
            SLCdate = dscaste.Tables[0].Rows[0]["SLCDateNew"].ToString();
        }

        System.Text.StringBuilder strMandt = new System.Text.StringBuilder();
        string nameuid = UnitEmail.Replace("@", "(at)");

        try
        {
            //cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by SLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login" + " <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana."); 
            cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by SLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login" + " <br /> Thank You, Commisionerate of Industries " + "<br />  Govt. of Telangana.");


        }
        catch (Exception ex)
        {

        }
        try
        {
            //cmf.SendSingleSMS(UnitMobileNo, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by SLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login." +'\n'+ "Thank You, GM, DIC -" + DistrictName +'\n'+ " Govt. of Telangana.");

            cmf.SendSingleSMS(UnitMobileNo, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by SLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login." + '\n' + "Thank You, Commisionerate of Industries " + '\n' + " Govt. of Telangana.");
        }
        catch (Exception ex)
        {

        }

    }

    // for sanction message alert
    public DataSet GetIntimationLetterDtls(string incentiveID, string masterincentiveid, string userid)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INTIMATIONLETTER_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                da.SelectCommand.Parameters.Add("@incentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@MasterIncentiveType", SqlDbType.VarChar).Value = masterincentiveid;
                da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@isDLC", SqlDbType.VarChar).Value = null;
            }

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