using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmBankLoanSanctionList : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    //2162903
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtBridgeLoanAmt.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
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


    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsn = new DataSet();
            dsn = GetGridIncdata(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, txtnameofunit.Text.Trim());
            if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dsn.Tables[0];
                GridView1.DataBind();
                GridView1.Visible = true;
                lblReleaseError.Visible = false;

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.Visible = false;
                string message = "alert('No Record Exists..... please select correct Details....try Again!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblReleaseError.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBankLoanSanctionList.aspx");
    }

    public DataSet GetGridIncdata(string District, string Mandal, string Unitname)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTRICT",SqlDbType.VarChar),
               new SqlParameter("@MANDAL",SqlDbType.VarChar),

               new SqlParameter("@UNITNAME",SqlDbType.VarChar),
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = District;
            pp[1].Value = Mandal;

            pp[2].Value = (Unitname == "") ? "%" : "%" + Unitname.ToString() + "%";

            Dsnew = Gen.GenericFillDs("USP_GET_UNITLIST_INCENTIVESANCTIONSLC", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return Dsnew;
    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");

            }
            else
            {

                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
                    ddlProp_intMandalid.DataTextField = "Manda_lName";
                    ddlProp_intMandalid.DataBind();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
            }

            //   ddlProp_intDistrictid.Focus();
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

    public void BindLineofActivityName()
    {
        try
        {
            ddlintLineofActivity.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDetNew(Session["uid"].ToString());
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = dsc.Tables[0];
                ddlintLineofActivity.DataValueField = "intLineofActivityid";
                ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                ddlintLineofActivity.DataBind();
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlintLineofActivity.Items.Insert(0, "--Select--");
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
    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncetivesNewForm2.aspx?rblSector=" + rblSector.SelectedValue);
    }

    public string IncentiveCFECFO(string sector, string District, string Mandal, string LineofActivityid, string NameofIndustry, string Uidno, string ActivityProposed, string LineofActivity, string TotalInvst, string DateofApplication, string Createdby)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        string valid = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INS_INCENTIVECFECFO";

            com.Transaction = transaction;
            com.Connection = connection;

            if (District != "" && District != null)
                com.Parameters.AddWithValue("@District", District);
            else
                com.Parameters.AddWithValue("@District", null);
            if (Mandal != "" && Mandal != null)
                com.Parameters.AddWithValue("@Mandal", Mandal);
            else
                com.Parameters.AddWithValue("@Mandal", null);
            if (LineofActivityid != "" && LineofActivityid != null)
                com.Parameters.AddWithValue("@LineofActivityid", LineofActivityid);
            else
                com.Parameters.AddWithValue("@LineofActivityid", null);

            if (NameofIndustry != "" && NameofIndustry != null)
                com.Parameters.AddWithValue("@NameofIndustry", NameofIndustry);
            else
                com.Parameters.AddWithValue("@NameofIndustry", null);

            if (Uidno != "" && Uidno != null)
                com.Parameters.AddWithValue("@Uidno", Uidno);
            else
                com.Parameters.AddWithValue("@Uidno", null);

            if (ActivityProposed != "" && ActivityProposed != null)
                com.Parameters.AddWithValue("@ActivityProposed", ActivityProposed);
            else
                com.Parameters.AddWithValue("@ActivityProposed", null);
            if (LineofActivity != "" && LineofActivity != null)
                com.Parameters.AddWithValue("@LineofActivity", LineofActivity);
            else
                com.Parameters.AddWithValue("@LineofActivity", null);

            if (TotalInvst != "" && TotalInvst != null)
                com.Parameters.AddWithValue("@TotalInvst", TotalInvst);
            else
                com.Parameters.AddWithValue("@TotalInvst", null);
            if (DateofApplication != "" && DateofApplication != null)
                com.Parameters.AddWithValue("@DateofApplication", Convert.ToDateTime(DateofApplication));
            else
                com.Parameters.AddWithValue("@DateofApplication", null);
            if (Createdby != "" && Createdby != null)
                com.Parameters.AddWithValue("@Createdby", Createdby);
            else
                com.Parameters.AddWithValue("@Createdby", null);


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();

            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }

    public DataSet getReport(string gmID, string monthh, string year)
    {
        try
        {
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("IPOGMlinkMonthlyTest", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (gmID.Trim() == "" || gmID.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@intGMid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@intGMid", SqlDbType.VarChar).Value = gmID.Trim();
            }

            if (monthh.Trim() == "" || monthh.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = monthh.Trim();
            }
            if (year.Trim() == "" || year.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year.Trim();
            }

            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
            //Session["impSno"] = sno.ToString();
            osqlConnection.Close();
            //osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
        return oDataSet;
    }



    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }


    public int InsertBridgeLoanAttachment(string intcentiveId, string masterIncenId, string FileNm, string FilePath, string FileDescription, string Created_dt, string Createdby)
    {
        try
        {

            osqlConnection.Open();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertBridgeLoanAttachments", osqlConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intcentiveId.Trim() == "" || intcentiveId.Trim() == null || intcentiveId.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intcentiveId", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intcentiveId", SqlDbType.Int).Value = Int32.Parse(intcentiveId.Trim());
            }

            if (masterIncenId.Trim() == "" || masterIncenId.Trim() == null || masterIncenId.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@masterIncveId", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@masterIncveId", SqlDbType.Int).Value = Int32.Parse(masterIncenId.Trim());
            }


            if (FileNm.Trim() == "" || FileNm.Trim() == null || FileNm.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm.Trim();
            }



            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (Createdby.Trim() == "" || Createdby.Trim() == null || Createdby.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.Int).Value = Int32.Parse(Createdby.Trim());
            }

            if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            }





            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            osqlConnection.Close();
            throw ex;

        }
        finally
        {

            osqlConnection.Close();

        }

    }


    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    int Rowindex = row.RowIndex;
                    Label lblIncid = (Label)GridView1.Rows[Rowindex].FindControl("lblIncid");
                    string incentiveid = lblIncid.Text.ToString();
                    ViewState["incentiveid"] = incentiveid;
                    Label lblIncentiveTypeID = (Label)GridView1.Rows[Rowindex].FindControl("IncentiveTypeID");
                    string masterincentiveid = lblIncentiveTypeID.Text.ToString();
                    ViewState["masterincentiveid"] = masterincentiveid;
                }
            }
            //        string incentiveid = ((Label)GridView1.Rows[0].FindControl("lblIncid")).Text;// Session["EntprIncentive"].ToString();
            //string masterincentiveid = ((Label)GridView1.Rows[0].FindControl("IncentiveTypeID")).Text;
            string newPath = "";

            string sFileDir = Server.MapPath("~\\BridgeLoanAttachments");

            General t1 = new General();
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {

                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {


                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {

                            newPath = System.IO.Path.Combine(sFileDir, ViewState["incentiveid"].ToString() + "\\" + ViewState["masterincentiveid"].ToString() + "\\BridgeLoanDoc");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }


                            int result = 0;
                            result = InsertBridgeLoanAttachment(ViewState["incentiveid"].ToString(), ViewState["masterincentiveid"].ToString(), sFileName, newPath, "BridgeLoan Doc", DateTime.Now.ToString(), Session["uid"].ToString());

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                BtnSave1.Enabled = true;
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName.Text = FileUpload1.FileName;
                                Label444.Text = FileUpload1.FileName;
                                Label444.Visible = true;
                                success.Visible = true;
                                Failure.Visible = false;
                                //lblFileName.Text = "View";
                                //lblFileName.NavigateUrl = newPath + "/" + sFileName;
                                //lblFileName.NavigateUrl =newPath+ "~\\IPOMonthlyRprtAttachments" + "/" + Session["impSno"].ToString() + "/" + "IPOMonthReport" + "/" + sFileName;
                                //lblFileName.NavigateUrl = "https://ipass.telangana.gov.in/iPOMonthlyRprtAttachments/1062/MonthlyReport/bt%20road.pdf";
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Record Already Exists..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");

                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception ex)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        //DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Label444.Text != "" && Label444.Text != null)
            {
                int cnt = 0;
                int insertCheck = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        cnt = cnt + 1;
                    }
                }

                if (cnt < 1)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Select Atleaset One Record  for further Process";
                    lblmsg0.Visible = true;
                }
                //else if (cnt > 1)
                //{
                //    Failure.Visible = true;
                //    lblmsg0.Text = "Please Select Only Record for processing";
                //    lblmsg0.Visible = true;
                //}
                else
                {

                    Failure.Visible = false;
                    lblmsg0.Text = "";
                    lblmsg0.Visible = false;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            int Rowindex = row.RowIndex;
                            string ApplicationNo = GridView1.Rows[Rowindex].Cells[1].Text.ToString();
                            string UnitName = GridView1.Rows[Rowindex].Cells[2].Text.ToString();
                            string Incentive = GridView1.Rows[Rowindex].Cells[4].Text.ToString();
                            string Status = GridView1.Rows[Rowindex].Cells[5].Text.ToString();
                            string ApplicationFiledDate = GridView1.Rows[Rowindex].Cells[6].Text.ToString();
                            string SanctionDate = GridView1.Rows[Rowindex].Cells[9].Text.ToString();
                            string SanctionAmount = GridView1.Rows[Rowindex].Cells[8].Text.ToString();
                            //string IncentiveTypeID = GridView1.Rows[Rowindex].Cells[6].Text.ToString();
                            //string IncentiveID = GridView1.Rows[Rowindex].Cells[7].Text.ToString();

                            Label lblIncid = (Label)GridView1.Rows[Rowindex].FindControl("lblIncid");
                            string IncentiveID = lblIncid.Text.ToString();
                            Label lblIncentiveTypeID = (Label)GridView1.Rows[Rowindex].FindControl("IncentiveTypeID");
                            string IncentiveTypeID = lblIncentiveTypeID.Text.ToString();

                            Failure.Visible = false;
                            osqlConnection.Open();
                            SqlCommand oSqlCommand = new SqlCommand("INSERT_BridgeLoanDetails");
                            oSqlCommand.Connection = osqlConnection;
                            oSqlCommand.CommandType = CommandType.StoredProcedure;
                            oSqlCommand.Parameters.AddWithValue("@IncentiveID", IncentiveID);
                            oSqlCommand.Parameters.AddWithValue("@IncentiveTypeID", IncentiveTypeID);
                            oSqlCommand.Parameters.AddWithValue("@UnitName", UnitName);
                            oSqlCommand.Parameters.AddWithValue("@Incentive", Incentive);
                            oSqlCommand.Parameters.AddWithValue("@Statuss", Status);
                            if (ApplicationFiledDate == "" || ApplicationFiledDate == null || ApplicationFiledDate == "&nbsp;")
                            {
                                string ApplicationDate = null;
                                oSqlCommand.Parameters.AddWithValue("@ApplicationFiledDate", ApplicationDate);
                            }
                            else
                            {
                                string[] ConvertedDt12 = ApplicationFiledDate.Split('/');
                                string ApplicationDate = ConvertedDt12[2].ToString() + "/" + ConvertedDt12[1].ToString() + "/" + ConvertedDt12[0].ToString();
                                oSqlCommand.Parameters.AddWithValue("@ApplicationFiledDate", ApplicationDate);
                            }
                            oSqlCommand.Parameters.AddWithValue("@ApplicationNo", ApplicationNo);
                            oSqlCommand.Parameters.AddWithValue("@BridgeLoanNo", txtBridgeLoanNo.Text.Trim());
                            oSqlCommand.Parameters.AddWithValue("@BridgeAccNo", txtBridgeAccNo.Text.Trim());
                            oSqlCommand.Parameters.AddWithValue("@verify", ViewState["checkVerifyinsp"].ToString());
                            oSqlCommand.Parameters.AddWithValue("@SanctionAmount", SanctionAmount);
                            if (SanctionDate == "" || SanctionDate == null)
                            {
                                string SanctionDatee = null;
                                oSqlCommand.Parameters.AddWithValue("@SanctionDate", SanctionDatee);
                            }
                            else
                            {
                                string[] ConvertedDt111 = SanctionDate.Split('/');
                                string SanctionDatee = ConvertedDt111[2].ToString() + "/" + ConvertedDt111[1].ToString() + "/" + ConvertedDt111[0].ToString();
                                oSqlCommand.Parameters.AddWithValue("@SanctionDate", SanctionDatee);
                            }

                            if (txtBridgeLoanDate.Text == "" || txtBridgeLoanDate.Text == null)
                            {
                                string LoanDate = null;
                                oSqlCommand.Parameters.AddWithValue("@BridgeLoanDate", LoanDate);
                            }
                            else
                            {
                                string[] ConvertedDt11 = txtBridgeLoanDate.Text.Split('/');
                                string LoanDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
                                oSqlCommand.Parameters.AddWithValue("@BridgeLoanDate", LoanDate);
                            }
                            oSqlCommand.Parameters.AddWithValue("@BridgeLoanAmount", txtBridgeLoanAmt.Text.Trim());


                            oSqlCommand.Parameters.AddWithValue("@Createdby", Session["uid"].ToString());


                            oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
                            oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;

                            oSqlCommand.ExecuteNonQuery();
                            osqlConnection.Close();
                            insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;
                            //getIPOS();





                        }
                        else
                        {
                            //string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            //string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            //string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            //string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            //string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                            //// int s = Gen.UpdDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                        }
                    }
                    if (insertCheck == 1)
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Record Inserted successfully!";

                        string message = "alert('Application Processed  successfully!')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //Response.Redirect("frmBankLoanSanctionList.aspx");


                    }

                    else
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Application Already Processed!";

                        string message = "alert('Appliaction Already Exists!')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                }

            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please upload  Document(s).";

            }
        }
        catch (Exception ex)
        {
            Failure.Visible = true;
            lblmsg0.Text = ex.Message;
        }
    }


    public DataSet getCheckedStaus(string IncentiveId)
    {
        try
        {
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("SP_IncentveSLCstatus", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.VarChar).Value = IncentiveId.Trim();
            }

            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
            //Session["impSno"] = sno.ToString();
            osqlConnection.Close();
            //osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
        return oDataSet;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblInc = (e.Row.FindControl("lblIncid") as Label);


        //    //string IncentiveId = e.Row.Cells[7].Text;

        //    string IncentiveId = lblInc.Text;
        //    CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    ds = getCheckedStaus(IncentiveId);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows[0]["Statuss"].ToString() == "2")
        //        {

        //            ChkApproval.Checked = true;
        //            ChkApproval.Enabled = false;


        //        }
        //        else
        //        {
        //            ChkApproval.Checked = false;
        //        }
        //    }
        //}
    }

    protected void chkverifyallDoc0_CheckedChanged(object sender, EventArgs e)
    {
        if (chkverifyallDoc0.Checked == true)
        {
            btnSubmit.Enabled = true;

            ViewState["checkVerifyinsp"] = "Verified";

        }
        if (chkverifyallDoc0.Checked != true)
        {
            btnSubmit.Enabled = false;
            ViewState["checkVerifyinsp"] = "Not Verified";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBankLoanSanctionList.aspx");
    }

    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {



        //foreach (GridViewRow oldrow in GridView1.Rows)
        //{

        //    ((CheckBox)oldrow.FindControl("ChkApproval")).Checked = false;
        //    ((CheckBox)oldrow.FindControl("ChkApproval")).Enabled = true;

        //}
        CheckBox rb = (CheckBox)sender;

        GridViewRow rows = (GridViewRow)rb.NamingContainer;

        bool CHK = ((CheckBox)rows.FindControl("ChkApproval")).Checked = true;
        if (CHK == true)
        {
            if (((CheckBox)rows.FindControl("ChkApproval")).Checked)
            {
                // ((CheckBox)rows.FindControl("ChkApproval")).Enabled = false;
                tablLoanDetails.Visible = true;
            }

        }
        else
        {
            tablLoanDetails.Visible = false;
        }


    }


}