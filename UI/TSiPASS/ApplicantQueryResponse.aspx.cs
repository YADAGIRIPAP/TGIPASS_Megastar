using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class UI_TSIPASS_ApplicantQueryResponse : System.Web.UI.Page
{

    public static string StageId { get; set; }
    public static DataSet GDs { get; set; }
    public static int uid { get; set; }
    public static string ApplicationId { get; set; }

    General Gen = new General();
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string[] newdate;


    int appid = 0;

    string uploadpath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {

            ApplicationId = Request.QueryString["appid"].ToString();

            appid = Convert.ToInt32(ApplicationId.ToString());
            if (!IsPostBack)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
                bindData(ApplicationId);
                ViewState["newd"] = newdate;
                BindFileUplaod();
            }

        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    private void bindData(string applicationId)
    {
        SqlParameter[] o = new SqlParameter[] {
                new SqlParameter("@AppId",SqlDbType.VarChar),
                 new SqlParameter("@Uid",SqlDbType.VarChar),
        };

        o[0].Value = ApplicationId;
        o[1].Value = Convert.ToInt32(Session["uid"].ToString());

        GDs = Gen.GenericFillDs("USP_tsiic_APPLICANTQUERYDETAILS", o);

        if (GDs.Tables[0].Rows.Count > 0)
        {

            lblRmId.Text = GDs.Tables[0].Rows[0]["Appid"].ToString();
            lblUnitName.Text = GDs.Tables[0].Rows[0]["firmname"].ToString();

            lblindusparkname.Text = GDs.Tables[0].Rows[0]["indusparkid"].ToString();
            lbldstid.Text = GDs.Tables[0].Rows[0]["DistrictName"].ToString();

            lblQueryRaisedDate.Text = GDs.Tables[0].Rows[0]["queryraised"].ToString();
            lblQueryDescription.Text = GDs.Tables[0].Rows[0]["QueryDescription"].ToString().Replace("/", "").Replace(".", "");
            lblplots.Text = GDs.Tables[0].Rows[0]["plotno"].ToString();
            hdnQueryId.Value = GDs.Tables[0].Rows[0]["queryid"].ToString();
            //hdnRmTypeId.Value = result["RMTypeId"].ToString();

            if (lblQueryDescription.Text.Contains("#"))
            {
                string[] date = lblQueryDescription.Text.ToString().Split('#');
                newdate = date[1].ToString().Split(',');
            }

            // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString()
        }

    }

    public void BindFileUplaod()
    {

        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell1 = new HtmlTableCell();
        HtmlTableCell cell2 = new HtmlTableCell();
        HtmlTableCell cell3 = new HtmlTableCell();
        string[] hd = (string[])ViewState["newd"];
        for (int i = 0; i < hd.Length; i++)
        {



            ddltssicattachments.Items.Add(hd[i]);

        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        success.Visible = false;

        String Message = string.Empty;


        if (ddltssicattachments.Items.Count > 0)
        {

            if (ddltssicattachments.SelectedValue != " ")
            {


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Upload  " + ddltssicattachments.SelectedValue.ToString() + " File');", true);
                return;

            }
        }
        else
        {
            if (lblQueryDescription.Text.Trim() != "")
            {
                if (txtQueryResponse.Text.Trim() != "")
                {

                    SqlParameter[] p = new SqlParameter[] {
                            new SqlParameter("@Appid",SqlDbType.Int),

                            new SqlParameter("@Response",SqlDbType.VarChar),
                            new SqlParameter("@CreatedBy",SqlDbType.Int),
                            new SqlParameter("@Result",SqlDbType.Int)
                            };

                    p[0].Value = ApplicationId;

                    p[1].Value = txtQueryResponse.Text;
                    p[2].Value = Convert.ToInt32(Session["uid"].ToString());
                    p[3].Value = 0;
                    p[3].Direction = ParameterDirection.Output;

                    Gen.GenericExecuteNonQuery("USP_INS_TssicAPPLICANTQUERYRESPONSE", p);
                    Message = "Query Response Submited Successfully.";
                    btnSubmit.Enabled = false;




                    TSIICLAND.LandAllotmentService query = new TSIICLAND.LandAllotmentService();
                    TSIICLAND.entry1[] queryvo = null;
                    DataSet ds = new DataSet();
                    ds = Gen.getattachmentdetailsonuidQueryTSIIC(ApplicationId, Session["uid"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable SanctionBuildingDetails = new DataTable();
                        SanctionBuildingDetails = ds.Tables[0];
                        queryvo = new TSIICLAND.entry1[SanctionBuildingDetails.Rows.Count];

                        for (int n = 0; n < SanctionBuildingDetails.Rows.Count; n++)
                        {
                            TSIICLAND.entry1 sanctionvo = new TSIICLAND.entry1();
                            sanctionvo.key = SanctionBuildingDetails.Rows[n]["filename"].ToString();
                            sanctionvo.value = SanctionBuildingDetails.Rows[n]["filepath"].ToString();
                            queryvo[n] = sanctionvo;
                        }
                        string output = query.SaveShortFallDocs(queryvo, appid);
                        if (output == "Documents are saved successfully")
                        {
                            Gen.UpdateDepartwebserviceflagtsiic(ApplicationId, "3", "Q", "Y", output);

                        }
                        else
                        {
                            Gen.UpdateDepartwebserviceflagtsiic(ApplicationId, "3", "Q", "N", output);
                        }
                    }
                }
                else
                {

                    Message = "Please Enter Query Response";

                    success.Visible = false;


                }
            }
           
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('" + Message + "');", true);
           
        }
    }





    protected void btnAttach_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string[] hd = (string[])ViewState["newd"];

        string hh = ddltssicattachments.SelectedValue.ToString().Trim();

        if (ddltssicattachments.Items.Count > 0)
        {

            if (hh != " ")
            {

                if (fupResAttachment.HasFile == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Attach File');", true);
                    return;
                }

                else
                {

                    if (fupResAttachment.HasFile)
                    {

                        if ((fupResAttachment.PostedFile != null) && (fupResAttachment.PostedFile.ContentLength > 0))
                        {
                            string sFileName = System.IO.Path.GetFileName(fupResAttachment.PostedFile.FileName);
                            try
                            {
                                string[] fileType = fupResAttachment.PostedFile.FileName.Split('.');
                                int i = fileType.Length;
                                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                                {
                                    string serverpath = Server.MapPath("~\\Tsiicresponseattachments\\" + ApplicationId.ToString() + "\\" + hh + "\\" + hdnQueryId.Value.ToString());  // incentiveid2
                                    if (!Directory.Exists(serverpath))
                                        Directory.CreateDirectory(serverpath);

                                    fupResAttachment.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                                    string CrtdUser = Session["uid"].ToString();

                                    string Path = serverpath;
                                    string FileName = sFileName;
                                    ViewState["AttachmentName"] = sFileName;
                                    ViewState["pathAttachment"] = serverpath;

                                    SqlParameter[] p = new SqlParameter[] {
                        new SqlParameter("@Appid",SqlDbType.Int),
                        
                     
                        new SqlParameter("@Filename",SqlDbType.VarChar),
                        new SqlParameter("@FilePath",SqlDbType.VarChar),
                        new SqlParameter("@CreatedBy",SqlDbType.Int),
                         new SqlParameter("@tsiicqueryfilename",SqlDbType.VarChar),
                         new SqlParameter("@Result",SqlDbType.Int)
                       
                        };

                                    p[0].Value = ApplicationId;
                                    p[1].Value = FileName;
                                    p[2].Value = Path;
                                    p[3].Value = Convert.ToInt32(Session["uid"].ToString());
                                    p[4].Value = hh;
                                    p[5].Value = 0;
                                    p[5].Direction = ParameterDirection.Output;


                                    Gen.GenericExecuteNonQuery("USP_INS_TsiicqueryATTACHMENTS", p);

                                    // string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                                    // t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value);
                                    string File_Path_Text = System.IO.Path.GetFullPath(fupResAttachment.PostedFile.FileName);
                                    AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                                    this.gvCertificate.DataBind();
                                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                    success.Visible = true;
                                    Failure.Visible = false;
                                    Label1.Visible = false;

 
                                    ddltssicattachments.Items.Remove(ddltssicattachments.SelectedItem);



                                }
                                else
                                {

                                    success.Visible = false;
                                    Failure.Visible = true;
                                    Label1.Visible = true;
                                    Label1.Text = "<font color='red'>Please Upload PDF Only ..!</font>";

                                }
                            }
                            catch (Exception ex)//in case of an error
                            {

                                DeleteFile(newPath + "\\" + sFileName);
                                throw ex;

                            }
                        }
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        Label1.Visible = false;

                    }


                }

            }
        }

        else
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('All Query Raised Attchments are submitted');", true);
            return;

        }



    }


    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        dtMyTable.Columns.Add("FileName", typeof(string));
        dtMyTable.Columns.Add("filepath", typeof(string));
        return dtMyTable;
    }


    protected void btnSubm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Userdashboard.aspx");
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

    private void AddDataToTableCeertificate(string Filename, string filepath, DataTable myTable)
    {
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
            throw ex;
        }
        finally
        {

        }
    }

}




















