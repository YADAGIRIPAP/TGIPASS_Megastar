using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class UI_TSiPASS_APMCReimbursement : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DataSet dscaste = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                if (Session["incentivedata"] != null)
                {
                    string userid = Session["uid"].ToString();
                    string IncentveID = Session["EntprIncentive"].ToString();

                    dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                    string lblscheme = dscaste.Tables[0].Rows[0]["Scheme"].ToString();
                    string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                    string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                    string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();
                    string isAllWomen = dscaste.Tables[0].Rows[0]["isAllWomen"].ToString();
                    string TFAP = dscaste.Tables[0].Rows[0]["TFAPFLAG"].ToString();

                    //if(TFAP!="Y")
                    //{

                    //    Response.Redirect("frmCapitalSubsidy.aspx?next=" + "N");
                    //}


                    LBLTFAP.Visible = true;

                    LBLTFAP.Text = "<center>" + "ANNEXURE: VIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF APMC UNDER TFAP </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    LBLTFAP.ForeColor = System.Drawing.Color.White;

                    if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                    {
                        trisdeclare2_1.Visible = true;
                    }
                    
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                    {
                        trisdeclare2_2.Visible = true;
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                    {
                        trisdeclare2_3.Visible = true;
                    }


                    BindFinancialYears_APMC("21", Session["EntprIncentive"].ToString());

                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 21);
                    if (drs.Length > 0)
                    {
                        DataSet dsnew = new DataSet();
                        dsnew = Gen.GetIncentivesISdata(IncentveID, "21");
                        // Filldata(dsnew);
                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("frmCapitalSubsidy.aspx?next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("frmincentiveformtransportduty.aspx?Previous=" + "P");
                        }
                    }
                    DataSet dsdisable = new DataSet();
                    dsdisable = Gen.GETINCENTIVESCAFDATA(userid, IncentveID);
                    if (dsdisable.Tables.Count > 0 && dsdisable.Tables[6].Rows.Count > 0)
                    {
                        string applicationStatus = "";
                        applicationStatus = dsdisable.Tables[6].Rows[0]["intStatusid"].ToString();
                        if (applicationStatus != "")
                        {

                            if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                            {
                                ResetFormControl(this);
                            }
                        }
                    }
                }
            }
        }
        if (!IsPostBack)
        {
            FillDetails();

        }
    }
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());
        //int IncentiveId = Convert.ToInt32("11");
        ds = GetAPMCIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if(ds.Tables[0].Rows[0]["FinancialYearNew"].ToString()!=""&& ds.Tables[0].Rows[0]["FinancialYearNew"].ToString() !=""&& ds.Tables[0].Rows[0]["FinancialYearNew"].ToString() != "--Select--")
            {
                ddlapmcfeepaidyear.SelectedValue = ds.Tables[0].Rows[0]["FinancialYearNew"].ToString();
            }
            if (ds.Tables[0].Rows[0]["APMCFEEPAID"].ToString() != "" && ds.Tables[0].Rows[0]["APMCFEEPAID"].ToString() != "" && ds.Tables[0].Rows[0]["APMCFEEPAID"].ToString() != "--Select--")
            {
                txtamountpaidindupees.Text = ds.Tables[0].Rows[0]["APMCFEEPAID"].ToString();
            }

            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2, sennew;

                foreach (DataRow dr in table.Rows)
                {
                    string AttcahmentId = dr["AttachmentId"].ToString();

                    sen2 = dr["FilePath"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    // sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = dr["LINKNEW"].ToString(); // LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    if (AttcahmentId == "303")
                    {
                        // lblFileName.NavigateUrl = sen;
                        lblUpload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblUpload1.Text = dr["FileNm"].ToString();
                        lblAttachedFileName1.Text = dr["FileNm"].ToString();
                    }

                }
            }
        }
    }
    public DataSet GetAPMCIncentives(int incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GetAPMCIncentives", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
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


    private void BindFinancialYears_APMC(string Count, string incentiveid)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        DataSet dsYears = new DataSet();
        dsYears = GetFinancialYearIncentives(Count, incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlapmcfeepaidyear.DataSource = dsYears.Tables[0];
            ddlapmcfeepaidyear.DataTextField = "FinancialYear";
            ddlapmcfeepaidyear.DataValueField = "SlNo";
            ddlapmcfeepaidyear.DataBind();
        }
        ddlapmcfeepaidyear.Items.Insert(0, "--Select--");

    }
    public DataSet GetFinancialYearIncentives(string MSTINCID, string incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETFINANCIALYEARS_APMC", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@MSTINCID", SqlDbType.VarChar).Value = MSTINCID;
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = incentiveid;
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

    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnNext.Enabled = true;
            BtnSave.Enabled = false;


            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int c = ds.Tables[1].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[1].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = ds.Tables[1].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                    if (sen.Contains("13")) // if (sen.Contains("62"))
                    {
                        //lblUpload1.NavigateUrl = sen;
                        lblUpload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblUpload1.Visible = true;
                        lblAttachedFileName1.Visible = false;
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }


                    i++;
                }
            }



            BtnSave.Enabled = false;


            
        }
        else
        {

            BtnSave.Enabled = true;


        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (lblAttachedFileName1.Text != "")
        {
            if (save())
            {

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "21", "Y", "");
                string message = "alert('Reimbursement of APMC Subsidy Applied Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                BtnNext.Enabled = true;
                BtnSave.Enabled = false;
            }
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave.Enabled = true;
        }
    }
    public bool save()
    {
        try
        {

            string valid = InsertIncentIS(ddlapmcfeepaidyear.SelectedValue, txtamountpaidindupees.Text, Session["uid"].ToString(), Session["EntprIncentive"].ToString());

            if (valid == "Y")
            {
                lblmsg.Text = "Submitted Successfully";
                success.Visible = true;

            }

        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        return true;
    }
    public string InsertIncentIS(string year, string amount, string createdby, string IncentveID)
    {
        string valid = "";


        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_INSERTAPMCDETAILS";

            if (year == null || year == "" || year == "--Select--")
                com.Parameters.AddWithValue("@year", null);
            else
                com.Parameters.AddWithValue("@year", year);
            if (amount == null || amount == "")
                com.Parameters.AddWithValue("@amount", null);
            else
                com.Parameters.AddWithValue("@amount", Convert.ToDecimal(amount));


            if (createdby == null || createdby == "")
                com.Parameters.AddWithValue("@createdby", null);
            else
                com.Parameters.AddWithValue("@createdby", createdby);

            if (IncentveID == null || IncentveID == "")
                com.Parameters.AddWithValue("@IncentveID", null);
            else
                com.Parameters.AddWithValue("@IncentveID", Convert.ToInt32(IncentveID));


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;

            con.OpenConnection();
            com.Connection = con.GetConnection;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //com.Dispose();
            con.CloseConnection();
        }
        return valid;
    }


    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmincentiveformtransportduty.aspx?Previous=" + "P");
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (lblAttachedFileName1.Text != "")
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "21", "Y", "");

            Response.Redirect("frmCapitalSubsidy.aspx?next=" + "N");
        }
        else
        {


            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave.Enabled = true;
        }

        //Response.Redirect("c.aspx?next=" + "N");

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("APMCReimbursement.aspx");
    }
    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");  commented on 07.02.2018 by chh
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fuDocuments1.HasFile)
        {
            if ((fuDocuments1.PostedFile != null) && (fuDocuments1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fuDocuments1.PostedFile.FileName);
                try
                {
                    string[] fileType = fuDocuments1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\62");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\21\\303");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      //62,
                                                      303,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName1.Text = fuDocuments1.FileName;
                        lblAttachedFileName1.Visible = true;

                        //lblUpload1.Text = fuDocuments1.FileName;
                        //lblUpload1.Visible = true;

                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception EX)//in case of an error
                {
                    throw EX;
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
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

    public int UpdateAnnexureflag(string EnterperIncentiveID, string MstIncentiveId, string flag, string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_ANNEXUREFLA_INCENTIVE";

        if (EnterperIncentiveID == "" || EnterperIncentiveID == null)
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = EnterperIncentiveID.Trim();

        if (MstIncentiveId == "" || MstIncentiveId == null)
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

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
    public void ResetFormControl(Control parent)
    {
        try
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).ReadOnly = true;
                            break;

                        case "System.Web.UI.WebControls.DropDownList":

                            if (((DropDownList)c).Items.Count > 0)
                            {
                                ((DropDownList)c).Enabled = false;
                            }
                            break;
                        case "System.Web.UI.WebControls.FileUpload":
                            ((FileUpload)c).Enabled = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).Enabled = false;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}