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


public partial class UI_TSiPASS_frmShowcauseReply : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
    string queryid = "";
    List<officerRemarks> lstremarks = new List<officerRemarks>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["EntrpId"] != null)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
                //Session["uid"] = Request.QueryString["EntrpId"].ToString();
                //txtdiscription.Visible = false;
                //lblDesc.Visible = true;
                //lblDesc.Text = txtdiscription.Text;
                //FileUpload1.Visible = false;
                //lblQryStatusResp.Visible = true;
                fillGrdDet();
            }
        }
    }

    public void fillGrdDet()
    {
        string JdOrGMflag = "";
        //if (Request.QueryString["JdOrGMflag"] != null)
        //{
        //    JdOrGMflag = Request.QueryString["JdOrGMflag"].ToString();
        //}

        DataSet ds = new DataSet();
        ds = GetQueryDetailsdept("", Request.QueryString["EntrpId"].ToString(), "", "S", JdOrGMflag);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label447.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
            Label448.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
            Label449.Text = ds.Tables[0].Rows[0]["Sector"].ToString().Trim();
            Label450.Text = ds.Tables[0].Rows[0]["Scheme"].ToString().Trim();
            Label451.Text = ds.Tables[0].Rows[0]["IncentiveName"].ToString().Trim();
            Label452.Text = ds.Tables[0].Rows[0]["DICName"].ToString().Trim();
            Label453.Text = ds.Tables[0].Rows[0]["queryRsdDate"].ToString().Trim();
            Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();

            hdfFlagID0.Value = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            hdfFlagID1.Value = ds.Tables[0].Rows[0]["MstIncentiveId"].ToString();
            anchortagGMCertificate.NavigateUrl = "industriesprintpage.aspx?EntrpId=" + Request.QueryString["EntrpId"].ToString();
        }

    }


    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {

            string userCreadted_by = Session["uid"].ToString().Trim();
            DataSet ds1 = new DataSet();
            ds1 = Gen.GetAllIncentives(userCreadted_by);

            ds = Gen.GetRespondQueryStatusfrIncentive(userCreadted_by);
            //[Label451]

            Label451.Text = "";

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                Label451.Text = ds1.Tables[0].Rows[i]["IncentiveName"] + "," + Label451.Text;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["Udyog Adhaar"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Sector"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["Scheme"].ToString().Trim();
                //  Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["DICName"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();

            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        DataSet dsMail;
        int valid = 0;
        if (ViewState["pathAttachment"] == null)
            ViewState["pathAttachment"] = "";
        if (ViewState["AttachmentName"] == null)
            ViewState["AttachmentName"] = "";
        try
        {
            if (txtdiscription.Text == "" && txtdiscription.Text == string.Empty)
            {
                lblmsg0.Text = "Please Enter Reply";
                Failure.Visible = true;
                valid = 1;
                lblmsg0.Focus();
            }
            //if (Label1.Text == "" && Label1.Text == string.Empty)
            //{
               
            //}
            if (gvCertificate.Rows.Count < 0)
            {
                lblmsg0.Text = "Please Upload Atachment";
                Failure.Visible = true;
                valid = 1;
                lblmsg0.Focus();
            }

            if (valid == 0)
            {
                officerRemarks fromvo = new officerRemarks();
                //int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = hdfFlagID0.Value;// ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

                fromvo.MstIncentiveId = "0";// ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                fromvo.id = "";// ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.status = Label1.Text;
                fromvo.Remarks = txtdiscription.Text.Trim();
                fromvo.CreatedByid = Session["uid"].ToString(); //((Label)gvrow.FindControl("lblCreatedByid")).Text.ToString();
                //fromvo.Designation = "GM";
                //fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();


                lstremarks.Add(fromvo);
                int result = InsertincentiveOfficerCommentsGMShowcausereply(lstremarks, getclientIP());
                string message = "alert('Replied Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //gvdetailsnew.Columns[12].Visible = false;
                BtnDelete.Enabled = false;
            }
        }


        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        gvCertificate.Visible = true;

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = Server.MapPath("~\\ResponseAttachmentforShowcause\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value,"","");
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                catch (Exception)//in case of an error
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

        gvCertificate.Visible = true;
    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {

        }
    }
    private void AddDataToTableCeertificate(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("FileName", typeof(string));
        dtMyTable.Columns.Add("filepath", typeof(string));
        return dtMyTable;
    }
    public void DeleteFile(string strFileName)
    {
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)
            {
                fi.Delete();
            }
        }
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }

    public DataSet GetQueryDetailsdept(string UserID, string incentiveID, string IncentiveType, string ApplicationLevel, string JdOrGMflag)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[FETCHINC_SHOWCAUSEDETAILS_ID]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            da.SelectCommand.Parameters.Add("@incentiveIDNew", SqlDbType.VarChar).Value = incentiveID;
            da.SelectCommand.Parameters.Add("@IncentiveType", SqlDbType.VarChar).Value = IncentiveType;
            da.SelectCommand.Parameters.Add("@ApplicationLevel", SqlDbType.VarChar).Value = ApplicationLevel;
            da.SelectCommand.Parameters.Add("@JdOrGMflag", SqlDbType.VarChar).Value = JdOrGMflag;

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

    public int InsertincentiveOfficerCommentsGMShowcausereply(List<officerRemarks> Ramarks, string IPAddress)
    {
        int valid = 0;
        DB.DB con = new DB.DB();

        foreach (officerRemarks Ramarksvo in Ramarks)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("USP_UPD_GMSHOWCAUSEREPLY", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@EnterperIncentiveID", Convert.ToString(Ramarksvo.EnterperIncentiveID));
                cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(Ramarksvo.MstIncentiveId));
                cmd.Parameters.AddWithValue("@SHOWCAUSEREPLY", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.AddWithValue("@SHOWCAUSEDOCUMENT", Convert.ToString(Ramarksvo.status));
                cmd.Parameters.AddWithValue("@CreatedByid", Convert.ToString(Ramarksvo.CreatedByid));
                cmd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
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
        }

        return valid;
    }
}