using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;



public partial class UI_TSiPASS_CheckStatusUpdatedDetails : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    decimal TotalRecAmount, TotalSanctionedAmount;
    string dipc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("../../Index.aspx");
                return;
            }
            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            h1heading.InnerHtml = Cast + " Category";
            string CheckNO = Request.QueryString[4].ToString();
            string rlsproceedno = Request.QueryString[3].ToString();
            string SubInctypeid = Request.QueryString[5].ToString();
            dipc = Request.QueryString[6].ToString();

            DataSet ds = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                 new SqlParameter("@Cast",SqlDbType.VarChar),
                  new SqlParameter("@CheckNO",SqlDbType.VarChar),
                  new SqlParameter("@RlsProceedNo",SqlDbType.VarChar),
                  new SqlParameter("@subIncType",SqlDbType.VarChar),
                  new SqlParameter("@dipc",SqlDbType.VarChar)
            };
            pp[0].Value = Investmentid;
            pp[1].Value = Cast;
            pp[2].Value = CheckNO;
            pp[3].Value = rlsproceedno;
            pp[4].Value = SubInctypeid;
            pp[5].Value = dipc;



            ds = gen.GenericFillDs("USP_GET_UNIT_Wise_CheckStatus", pp);


            // ds = getReleaseProceedingsCheckClearenceUpdate(Cast, Investmentid, CheckNO, rlsproceedno, SubInctypeid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }

            else
            {
                string message = "alert('No records Found with this Cheque Details.!!..Cheque Details Not Updated')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        int valid = 0;

        if (valid == 0)
        {
            valid = SaveData();
            if (valid == 1)
            {
                string message = "alert('Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Failed";
            }
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = "Failed";
        }
    }

    private int SaveData()
    {
        int valid = 0;
        string dipc = Request.QueryString[6].ToString();
        string EmpName = "", Designation = "", ErrorMessage = "";
        if (txtCheckdate.Text.Trim() == "")
        {
            ErrorMessage = "Please Enter Cheque Clearance Date" + "<br/>";
            valid = 2;
        }
        if (txtEmployeeName.Text.Trim() == "")
        {
            ErrorMessage += "Please Enter Employee Namee" + "<br/>";
            valid = 2;
        }
        if (txtDesignation.Text.Trim() == "")
        {
            ErrorMessage += "Please Enter Employee Designation" + "<br/>";
            valid = 2;
        }
        if (valid == 0)
        {
            EmpName = txtEmployeeName.Text.Trim();
            Designation = txtDesignation.Text.Trim();
            foreach (GridViewRow gvrow in grdDetails.Rows)
            {
                int rowIndex = gvrow.RowIndex;
                string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();

                string[] datett = txtCheckdate.Text.Trim().Split('/');
                string checkdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                string RlsProceedNo = Request.QueryString[3].ToString();
                string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                valid = gen.UpdateincentiveClearenceDate(EnterperIncentiveID, MstIncentiveId, checkdate, Session["uid"].ToString(), EmpName, Designation, "", "", "", RlsProceedNo, dipc);
            }
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = ErrorMessage;
        }
        return valid;

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //Button btnNOTCLEAR = e.Row.FindControl("btnCheqNOtClear") as Button;
            //Label ResponceApps = e.Row.FindControl("lblenterresp") as Label;
            //if (btnNOTCLEAR.Text.Trim() == "NOT CLEAR")
            //{
            //    btncoigmraisequery.Visible = false;
            //}



            decimal RecAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RecommendedAmount"));
            TotalRecAmount = RecAmount + TotalRecAmount;
            decimal SanctionedAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AllotedAmount"));
            TotalSanctionedAmount = SanctionedAmount + TotalSanctionedAmount;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[4].Text = TotalRecAmount.ToString();
            e.Row.Cells[5].Text = TotalSanctionedAmount.ToString();
        }
    }

    protected void btnGenChequeList_Click(object sender, EventArgs e)
    {

        string dipc = Request.QueryString[6].ToString();
        int valid = 0;

        if (valid == 0)
        {
            valid = SaveData();
            if (valid == 1)
            {
                string SBIFileNametoSave = "", SBIFilePath = "", OthBankFileNametoSave = "", OthBankFilePath = "";
                string message = "alert('Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                string SLCNumber = grdDetails.Rows[0].Cells[7].Text.Trim();
                string SLCDate = grdDetails.Rows[0].Cells[8].Text.Trim();
                string CheckNO = Request.QueryString[4].ToString();
                string rlsproceedno = Request.QueryString[3].ToString();
                string slcdateforDB = "", SLCDateForFileDate = "";
                if (SLCDate != "" && SLCDate.Contains('/'))
                {
                    string[] slc = SLCDate.Split('/');

                    slcdateforDB = slc[1].ToString() + "/" + slc[0].ToString() + "/" + slc[2].ToString();
                    SLCDateForFileDate = slc[1].ToString() + "-" + slc[0].ToString() + "-" + slc[2].ToString();
                }
                DataSet ds = new DataSet();
                ds = GeneratePayeeListForBank(SLCNumber, slcdateforDB, rlsproceedno, CheckNO, dipc);
                string FileName = "";
                string body = @"<div>
                            Dear Sir," + @"
                            <br/><br />
                            Please find the Attached Documents ";
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string sFileDir = Server.MapPath("~\\Attachments\\BankFiles");
                    if (!Directory.Exists(sFileDir))
                        System.IO.Directory.CreateDirectory(sFileDir);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sFileDir);
                    int count = dir.GetFiles().Length;

                    string File1 = SLCNumber + "-SBI-" + SLCDateForFileDate;
                    FileName = sFileDir + "/" + File1 + ".txt";
                    SBIFileNametoSave = File1 + ".txt";
                    SBIFilePath = FileName;

                    if (File.Exists(FileName))
                        DeleteFile(FileName);
                    CreateTextFile(ds.Tables[0], FileName);
                    foreach (GridViewRow gvrow in grdDetails.Rows)
                    {
                        int rowIndex = gvrow.RowIndex;
                        string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();

                        string[] datett = txtCheckdate.Text.Trim().Split('/');
                        string checkdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                        string RlsProceedNo = Request.QueryString[3].ToString();
                        string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                        valid = gen.UpdateincentiveClearenceDate(EnterperIncentiveID, MstIncentiveId, checkdate, Session["uid"].ToString(), "", "", SBIFileNametoSave, SBIFilePath, "SBI", RlsProceedNo, dipc);
                    }
                    SendEmail1("krishna.cheripally@gmail.com", "tsipass.telangana@gmail.com", body, "TSIpass : Bank Account Details", FileName);
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    string sFileDir = Server.MapPath("~\\Attachments\\BankFiles");
                    if (!Directory.Exists(sFileDir))

                        System.IO.Directory.CreateDirectory(sFileDir);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sFileDir);
                    int count = dir.GetFiles().Length;
                    string File2 = SLCNumber + "-OTHBANK-" + SLCDateForFileDate;
                    FileName = sFileDir + "\\" + File2 + ".txt";

                    OthBankFileNametoSave = File2 + ".txt";
                    OthBankFilePath = FileName;

                    if (File.Exists(FileName))
                        DeleteFile(FileName);
                    CreateTextFile(ds.Tables[1], FileName);

                    foreach (GridViewRow gvrow in grdDetails.Rows)
                    {
                        int rowIndex = gvrow.RowIndex;
                        string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();

                        string[] datett = txtCheckdate.Text.Trim().Split('/');
                        string checkdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                        string RlsProceedNo = Request.QueryString[3].ToString();
                        string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                        valid = gen.UpdateincentiveClearenceDate(EnterperIncentiveID, MstIncentiveId, checkdate, Session["uid"].ToString(), txtEmployeeName.Text.Trim(), txtDesignation.Text.Trim(), OthBankFileNametoSave, OthBankFilePath, "OTH", RlsProceedNo, dipc);
                    }

                    SendEmail1("krishna.cheripally@gmail.com", "tsipass.telangana@gmail.com", body, "TSIpass : Bank Account Details", FileName);
                }
            }
            else
            {
                Failure.Visible = true;
                // lblmsg0.Text = "Failed";
            }
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = "Failed";
        }
    }


    public DataSet GeneratePayeeListForBank(string SLCNumber, string SLCDate, string RlsProno, string checkno, string dipc)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_SANCTIONBANKFILE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@SLCNUMBER", SqlDbType.VarChar).Value = SLCNumber;
            da.SelectCommand.Parameters.Add("@SLCDATE", SqlDbType.VarChar).Value = SLCDate;
            da.SelectCommand.Parameters.Add("@RlsProno", SqlDbType.VarChar).Value = RlsProno;
            da.SelectCommand.Parameters.Add("@Checkno", SqlDbType.VarChar).Value = checkno;
            da.SelectCommand.Parameters.Add("@dipc", SqlDbType.VarChar).Value = dipc;
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



    public void DeleteFile(string strFileName)
    {//Delete file from the server
        try
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void SendEmail1(string to, string from, string body, string sub, string FilePath)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(to);

            mail.From = new MailAddress(from, "TSIpass : Account Numbers", System.Text.Encoding.UTF8);
            mail.Subject = sub;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Body = body;
            //C:\Users\admin\Desktop\Telanganacourtcasesmain\ORDERS\3SRN09062017013318FilePath=FilePath.Replace('//'
            mail.Attachments.Add(new Attachment(FilePath));
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //Jyotshna On 05-10-2012
            client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
            //Jyotshna On 05-10-2012
            client.EnableSsl = true;

            client.Send(mail);
        }
        catch (Exception ex)
        {
            //throw ex;
        }

    }
    public bool downloadfile(string weblink, string uid)
    {
        try
        {
            weblink = "656-OTHBANK-07-29-2017.txt";
            WebClient wc = new WebClient();
            DataSet ds = new DataSet();//objFetch.FetchEnterprenuerDetails(uid);

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Contains("intCFEEnterpid"))
            //{
            // string path = Server.MapPath("") + "\\Attachments\\" + ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString() + "\\ApprovalDocument";
            string path = Server.MapPath("") + "\\Attachments\\";

            string[] targetfileName = weblink.Replace(@"\", "/").Split('/');
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            wc.DownloadFile(weblink, path + "\\" + targetfileName[targetfileName.Length - 1]);
            return true;
            //}
            //else { return false; }
        }
        catch (Exception) { return false; }
    }

    private void CreateTextFile(DataTable dt, string FileName)
    {
        try
        {
            StreamWriter swExtLogFile = new StreamWriter(FileName, true);
            int i;
            swExtLogFile.Write(Environment.NewLine);
            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    swExtLogFile.Write(array[i].ToString() + " | ");
                }
                swExtLogFile.WriteLine(array[i].ToString());
            }

            swExtLogFile.Flush();
            swExtLogFile.Close();
        }
        catch
        {

        }
    }
    protected void btnGenerateBankNote_Click(object sender, EventArgs e)
    {

        string SLCNumber = grdDetails.Rows[0].Cells[7].Text.Trim();
        string SLCDate = grdDetails.Rows[0].Cells[8].Text.Trim();
        string CheckNO = Request.QueryString[4].ToString();
        string rlsproceedno = Request.QueryString[3].ToString();
        string slcdateforDB = "", SLCDateForFileDate = "";
        if (SLCDate != "" && SLCDate.Contains('/'))
        {
            string[] slc = SLCDate.Split('/');

            slcdateforDB = slc[1].ToString() + "/" + slc[0].ToString() + "/" + slc[2].ToString();
            SLCDateForFileDate = slc[1].ToString() + "-" + slc[0].ToString() + "-" + slc[2].ToString();
        }

        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('frmBankLetterForClearanceChk.aspx?SLCNumber=" + SLCNumber.Trim() + "&slcdateforDB=" + slcdateforDB + "&ReleaseProcedingNo= " + rlsproceedno + "&checkno = " + CheckNO + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('frmBankLetterForClearanceChk.aspx?SLCNumber=" + SLCNumber.Trim() + "&slcdateforDB=" + slcdateforDB + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('frmBankLetterForClearanceChk.aspx?SLCNumber=" + SLCNumber.Trim()  + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //string url = "./frmBankLetterForClearanceChk.aspx?InvoiceID=" + SLCNumber.ToString();
        //Session["url"] = url;
        //string winFeatures = "toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,resizable=no,height=650,width=825";
        //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script type='text/javascript'>var popup=window.open('{0}', 'yourWin', '{1}'); popup.focus();</script>", url, winFeatures));

    }


    protected void btnDownload_Click(object sender, EventArgs e)
    {
        // DownloadTextFile();
        bool a = downloadfile("", "");
    }

    protected void btnCheqClear_Click(object sender, EventArgs e)
    {
        try
        {



            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;


            string EnterperIncentiveID = ((Label)grdDetails.Rows[indexing].FindControl("lblEnterperIncentiveID")).Text.ToString();
            string MstIncentiveId = ((Label)grdDetails.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
            string RlsProceedNo = Request.QueryString[3].ToString();
            string TxtUTRNumber = ((TextBox)grdDetails.Rows[indexing].FindControl("TxtUTRNumber")).Text;
            string CheqCleared = "Y";
            string CheqNOTCleared = null;
            string CheqNotClearedRemarks = "";
            string Flag = "CLEAR";



            if (TxtUTRNumber.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Kindly ENTER UTR NUMBER')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }


            int valid = valid = gen.UpdateincenCheckDetails(EnterperIncentiveID, MstIncentiveId, TxtUTRNumber, Session["uid"].ToString(), RlsProceedNo, dipc, CheqCleared, CheqNOTCleared, CheqNotClearedRemarks, Flag);
            if (valid == 1)
            {
                string mSG = "alert('Response Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", mSG, true);
            }



        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        string message = "alert('Response Submitted Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    }

    protected void btnCheqNOtClear_Click(object sender, EventArgs e)
    {
        try
        {



            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;


            string EnterperIncentiveID = ((Label)grdDetails.Rows[indexing].FindControl("lblEnterperIncentiveID")).Text.ToString();
            string MstIncentiveId = ((Label)grdDetails.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
            string RlsProceedNo = Request.QueryString[3].ToString();
            string TxtUTRNumber = ((TextBox)grdDetails.Rows[indexing].FindControl("TxtUTRNumber")).Text;
            string CheqCleared = null;
            string CheqNOTCleared = "Y";
            string CheqNotClearedRemarks = ((TextBox)grdDetails.Rows[indexing].FindControl("NotCleardRemarks")).Text;
            string Flag = "NOTCLEAR";



            if (CheqNotClearedRemarks.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Please Kindly Enter The Remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }


            int valid = valid = gen.UpdateincenCheckDetails(EnterperIncentiveID, MstIncentiveId, TxtUTRNumber, Session["uid"].ToString(), RlsProceedNo, dipc, CheqCleared, CheqNOTCleared, CheqNotClearedRemarks, Flag);
            if (valid == 1)
            {
                string mSG = "alert('Detaails Updated  Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", mSG, true);
            }


        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        string message = "alert('Response Submitted Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    }

}