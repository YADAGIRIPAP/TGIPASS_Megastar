using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;

public partial class UI_TSIPASS_DistrictWiseUpdateabstarctDrill : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    DB.DB con = new DB.DB();
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("../../IpassLogin.aspx");
        }
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            HyperLink1.NavigateUrl = "DistrictWiseUpdateabstarct.aspx?AppsType=" + Request.QueryString["TSiPASSType"].ToString();
            HyperLink2.NavigateUrl = "DistrictWiseUpdateabstarct.aspx?AppsType=" + Request.QueryString["TSiPASSType"].ToString();
            getdistricts();
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                ddlConnectLoad.SelectedValue = (Session["DistrictID"].ToString().Trim());
                ddlConnectLoad.Enabled = false;
            }
            else
                ddlConnectLoad.Enabled = true;
            fillgrid();
        }
    }
    #endregion

    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlConnectLoad.DataSource = dsnew.Tables[0];
        ddlConnectLoad.DataTextField = "District_Name";
        ddlConnectLoad.DataValueField = "District_Id";
        ddlConnectLoad.DataBind();
        ddlConnectLoad.Items.Insert(0, "--Select--");

    }
    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        // dsnew = Gen.getdataofDistrictlevel1(ddlConnectLoad.SelectedItem.Text.ToString(), txtUnitname.Text);
        string ONLINEFLAG = "", District = "", unitname = "", TSiPASSType = "", progress = "", status = "";
        status = Request.QueryString["status"].ToString();
        ONLINEFLAG = Request.QueryString["AppsType"].ToString();
        District = Request.QueryString["dist"].ToString();
        unitname = txtUnitname.Text.Trim().TrimStart();
        TSiPASSType = Request.QueryString["TSiPASSType"].ToString();
        progress = Request.QueryString["impstatus"].ToString();
        Label1.Text = TSiPASSType + " Levle Update - Status of Implementation";
        dsnew = GetAppealApplications(ONLINEFLAG, District, unitname, TSiPASSType, progress, status);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            lblMsg0.Text = "Total Records Found :" + dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblMsg0.Text = "Total Records Found : 0";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    public DataSet GetAppealApplications(string ONLINEFLAG, string District, string unitname, string TSiPASSType, string progress, string status)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ONLINEFLAG",SqlDbType.VarChar),
               new SqlParameter("@District",SqlDbType.VarChar),
               new SqlParameter("@unitname",SqlDbType.VarChar),
               new SqlParameter("@TSiPASSType",SqlDbType.VarChar),
               new SqlParameter("@progress",SqlDbType.VarChar),
               new SqlParameter("@status",SqlDbType.VarChar)
           };
        pp[0].Value = ONLINEFLAG;
        pp[1].Value = District;
        pp[2].Value = unitname;
        pp[3].Value = TSiPASSType;
        pp[4].Value = progress;
        pp[5].Value = status;
        Dsnew = gen.GenericFillDs("USP_GET_IMPLIMENTAION_STATUS_ABSTRACT_DISTRICTS_DRILL", pp);
        return Dsnew;
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + "District Level Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                DataSet dsnew = new DataSet();

                dsnew = Gen.getdataofDistrictlevel1(ddlConnectLoad.SelectedItem.Text.ToString(), txtUnitname.Text);

                GridExport.DataSource = dsnew.Tables[0];
                GridExport.DataBind();

                GridExport.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }


    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    ds = Gen.FetchInspectionProgressRpt();
    //    grdDetails.DataSource = ds.Tables[0];
    //    grdDetails.DataBind();
    //}

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Performance indicator"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections to be conducted"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections completed"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of inspection reports uploaded within 48 hrs"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
        //    //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;


        //}

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
        //    e.Row.Cells[3].Text = Completed1.ToString();
        //    e.Row.Cells[4].Text = QueryRaised1.ToString();
        //    e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Pendingmorthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intSNo")).Trim();
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
            Button BtnSaveg = (Button)e.Row.FindControl("BtnSaveg");

            string progress = e.Row.Cells[11].Text.ToString();
            if (progress.ToUpper() == "COMMENCED OPERATIONS")
            {
                ddlStatus.Items.Remove(new ListItem("ADVANCED STAGE"));
                ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
                ddlStatus.Items.Remove(new ListItem("COMMENCED OPERATIONS"));
                // ddlStatus.SelectedIndex = 1;
                BtnSaveg.Enabled = false;
            }
            if (progress.ToUpper() == "ADVANCED STAGE")
            {
                ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            }
            if (progress.ToUpper() == "INITIAL STAGE")
            {
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            }
            //if (progress.ToUpper() == "YET TO START CONSTRUCTION")
            //{
            //    ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            //}
            if (progress.ToUpper() == "DROPPED")
            {
                ddlStatus.Items.Remove(new ListItem("ADVANCED STAGE"));
                ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
                ddlStatus.Items.Remove(new ListItem("COMMENCED OPERATIONS"));
                // ddlStatus.SelectedIndex = 1;
                BtnSaveg.Enabled = false;
            }
        }
    }


    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        string errormsg = "";

        string newPath = "";
        string sFileName = "";

        string newPathImage = "";
        string sFileNameImage = "";

        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtreasonschange = (TextBox)row.FindControl("txtreasonschange");

        Label Label6 = (Label)row.FindControl("Label6new");
        FileUpload fupPERCert = (FileUpload)row.FindControl("fluPrincipalEmployersRegistrationCertificate");
        FileUpload fupPERCertimage = (FileUpload)row.FindControl("FileUpload1");
        HyperLink HyperLinknew = (HyperLink)row.FindControl("HyperLink1");
        HtmlTableRow TRWORKINGSTATUS = (HtmlTableRow)row.FindControl("TRWORKINGSTATUS");
        HtmlTableRow TRRBTINTERACTED = (HtmlTableRow)row.FindControl("TRRBTINTERACTED");
        HtmlTableRow TRRBTINTERACTIONDATE = (HtmlTableRow)row.FindControl("TRRBTINTERACTIONDATE");

        TextBox TXTINTERACTIONDATE = (TextBox)row.FindControl("TXTINTERACTIONDATE");
        TextBox TXTDCP = (TextBox)row.FindControl("TXTDCP");
        TextBox TXTPRESENTWORKINGSTATUS = (TextBox)row.FindControl("TXTPRESENTWORKINGSTATUS");
        RadioButtonList rbtinteracted = (RadioButtonList)row.FindControl("rbtinteracted");
        ScriptManager.GetCurrent(this).RegisterPostBackControl(rbtinteracted);

        
        if (ddlStatus.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Status')", true);

            //lblresult.Text = "Please Select Status";
        }
        else
        {
            try
            {
                string sFileDir = Server.MapPath("~\\IndustriesImages");

                if (fupPERCertimage.HasFile)
                {
                    General t1 = new General();
                    if ((fupPERCertimage.PostedFile != null) && (fupPERCertimage.PostedFile.ContentLength > 0))
                    {
                        //determine file name
                        sFileNameImage = System.IO.Path.GetFileName(fupPERCertimage.PostedFile.FileName);
                        try
                        {
                            string[] fileType = fupPERCertimage.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                //Create a new subfolder under the current active folder   PERegitrationCertificate
                                newPathImage = System.IO.Path.Combine(sFileDir, HyperLinknew.Text + "\\IndsPictures");

                                // Create the subfolder
                                if (!Directory.Exists(newPathImage))

                                    System.IO.Directory.CreateDirectory(newPathImage);
                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPathImage);
                                int count = dir.GetFiles().Length;
                                if (count == 0)
                                    fupPERCertimage.PostedFile.SaveAs(newPathImage + "\\" + sFileNameImage);
                                else
                                {
                                    if (count == 1)
                                    {
                                        string[] Files = Directory.GetFiles(newPathImage);

                                        foreach (string file in Files)
                                        {
                                            File.Delete(file);
                                        }
                                        fupPERCertimage.PostedFile.SaveAs(newPathImage + "\\" + sFileNameImage);
                                    }
                                }
                                int result = 0;
                                Label6.Text = fupPERCertimage.FileName;
                            }

                        }
                        catch (Exception)//in case of an error
                        {
                            DeleteFile(newPathImage + "\\" + sFileNameImage);
                        }
                    }
                }
                else
                {

                    //string message1 = "alert(Please Upload file)";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                    //return;
                }
            }
            catch (Exception ex)
            {

            }
            if (ddlStatus.SelectedValue == "COMMENCED OPERATIONS")
            {
                if (TRRBTINTERACTED.Visible == true && rbtinteracted.SelectedIndex == -1)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Whether interacted or not')", true);
                    errormsg = errormsg + "Please select Whether interacted or not \\n";
                }
                if (TRRBTINTERACTED.Visible == true && rbtinteracted.SelectedValue == "1")
                {
                    if (TXTINTERACTIONDATE.Text == null || TXTINTERACTIONDATE.Text == "" || string.IsNullOrWhiteSpace(TXTINTERACTIONDATE.Text))
                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Interaction date')", true);
                        errormsg = errormsg + "Please select Interaction date \\n";
                }
                if (TXTPRESENTWORKINGSTATUS.Text == null || TXTPRESENTWORKINGSTATUS.Text == "" || string.IsNullOrWhiteSpace(TXTPRESENTWORKINGSTATUS.Text))
                {
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Presend working status ')", true);
                    errormsg = errormsg + "Please Enter Present working status \\n";
                }
                if (TXTDCP.Text == null || TXTDCP.Text == "" || string.IsNullOrWhiteSpace(TXTDCP.Text))
                { errormsg = errormsg + "Please select DCP date \\n"; }
            }

            if (ddlStatus.SelectedValue == "DROPPED")
            {
                //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
                //string sFileDir = "~\\TenderNotice";
                string sFileDir = Server.MapPath("~\\DropedAttachments");

                if (fupPERCert.HasFile)
                {
                    General t1 = new General();
                    if ((fupPERCert.PostedFile != null) && (fupPERCert.PostedFile.ContentLength > 0))
                    {
                        //determine file name
                        sFileName = System.IO.Path.GetFileName(fupPERCert.PostedFile.FileName);
                        try
                        {
                            string[] fileType = fupPERCert.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                //Create a new subfolder under the current active folder   PERegitrationCertificate
                                newPath = System.IO.Path.Combine(sFileDir, HyperLinknew.Text + "\\DROPEDCERTIFICATE");

                                // Create the subfolder
                                if (!Directory.Exists(newPath))

                                    System.IO.Directory.CreateDirectory(newPath);
                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                int count = dir.GetFiles().Length;
                                if (count == 0)
                                    fupPERCert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                else
                                {
                                    if (count == 1)
                                    {
                                        string[] Files = Directory.GetFiles(newPath);

                                        foreach (string file in Files)
                                        {
                                            File.Delete(file);
                                        }
                                        fupPERCert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    }
                                }
                                int result = 0;
                                Label6.Text = fupPERCert.FileName;
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

                    //string message1 = "alert(Please Upload file)";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                    //return;
                }
            }
            if (txtreasonschange.Text.Trim().TrimStart() == "")
            {
                errormsg = errormsg + "Please Enter Reason For Status Change \\n";

                //lblresult.Text = "Please Enter Reason For Status Change";
                //lblresult.Focus();
                //return;
            }
            if (errormsg == "")
            {
                //int returnValue = Gen.ChangeDistrictWiseStatus(HdfintApplicationid.Value, ddlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString(), txtreasonschange.Text.Trim().TrimStart(), (newPath + "\\" + sFileName), (newPathImage + "\\" + sFileNameImage), rbtinteracted.SelectedValue, TXTINTERACTIONDATE.Text, TXTPRESENTWORKINGSTATUS.Text);
                int returnValue = ChangeDistrictWiseStatus(HdfintApplicationid.Value, ddlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString(), txtreasonschange.Text.Trim().TrimStart(), (newPath + "\\" + sFileName), (newPathImage + "\\" + sFileNameImage), rbtinteracted.SelectedValue, TXTINTERACTIONDATE.Text, TXTPRESENTWORKINGSTATUS.Text, TXTDCP.Text);

                lblresult.Text = "Status Updated";
                //int returnValue = Gen.ChangeDistrictWiseStatus(HdfintApplicationid.Value,ddlStatus.SelectedValue.ToString(),Session["uid"].ToString());
                fillgrid();
                string message = "alert('Status of Unit implementation has been Updated. Thank You')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill all details')", true);


            }

        }
        //  int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());

    }
    public int ChangeDistrictWiseStatus(string intApplicationid, string Status, string Modified_by, string Reason, string Filepath, 
        string FilepathNew, string interacted, string interactiondate, string presentworkingstatus, string DCP)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "updateDistrictWiseStatus";

        if (intApplicationid.Trim() == "" || intApplicationid.Trim() == null)
            com.Parameters.Add("@intApplicationid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApplicationid", SqlDbType.VarChar).Value = intApplicationid.Trim();

        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();

        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@Reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reason", SqlDbType.VarChar).Value = Reason.Trim();

        if (Filepath.Trim() == "" || Filepath.Trim() == null)
            com.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = Filepath.Trim();

        com.Parameters.Add("@FilepathNew", SqlDbType.VarChar).Value = FilepathNew.Trim();


        if (interacted.Trim() == "" || interacted.Trim() == null)
            com.Parameters.Add("@INTERACTION", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@INTERACTION", SqlDbType.VarChar).Value = interacted.Trim();

        if (interactiondate.Trim() == "" || interactiondate.Trim() == null)
            com.Parameters.Add("@INTERACTIONDATE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@INTERACTIONDATE", SqlDbType.DateTime).Value = interactiondate;

        if (presentworkingstatus.Trim() == "" || presentworkingstatus.Trim() == null)
            com.Parameters.Add("@PRESENTWORKINGSTATUS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PRESENTWORKINGSTATUS", SqlDbType.VarChar).Value = presentworkingstatus.Trim();
      
        if (DCP.Trim() == "" || DCP.Trim() == null)
            com.Parameters.Add("@DCP", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DCP", SqlDbType.DateTime).Value = DCP;


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            return com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
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
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("StateLevelwiseReport.aspx");

    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        Button BtnSaveg = (Button)row.FindControl("BtnSaveg");
        ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnSaveg);
        HtmlTableRow dropupload = (HtmlTableRow)row.FindControl("dropupload");
        HtmlTableRow TRRBTINTERACTED = (HtmlTableRow)row.FindControl("TRRBTINTERACTED");
        HtmlTableRow TRWORKINGSTATUS = (HtmlTableRow)row.FindControl("TRWORKINGSTATUS");
        HtmlTableRow TRRBTINTERACTIONDATE = (HtmlTableRow)row.FindControl("TRRBTINTERACTIONDATE");

        if (ddlStatus.SelectedValue == "DROPPED")
        {
            dropupload.Visible = true;
            TRRBTINTERACTED.Visible = false;
            TRWORKINGSTATUS.Visible = false;
            TRRBTINTERACTIONDATE.Visible = false;
        }
        else if (ddlStatus.SelectedValue == "COMMENCED OPERATIONS")
        {
            TRRBTINTERACTED.Visible = true;
            TRWORKINGSTATUS.Visible = true;
            dropupload.Visible = false;
        }
        else
        {
            dropupload.Visible = false;
            TRRBTINTERACTED.Visible = false;
            TRWORKINGSTATUS.Visible = false;
            TRRBTINTERACTIONDATE.Visible = false;
        }
    }
    protected void rbtinteracted_SelectedIndexChanged(object sender, EventArgs e)
    {

        RadioButtonList rbtyesorno = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rbtyesorno.NamingContainer;
        Button BtnSaveg = (Button)row.FindControl("BtnSaveg");
        ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnSaveg);
        HtmlTableRow TRRBTINTERACTIONDATE = (HtmlTableRow)row.FindControl("TRRBTINTERACTIONDATE");
        TextBox TXTINTERACTIONDATE = (TextBox)row.FindControl("TXTINTERACTIONDATE");
        TXTINTERACTIONDATE.Text = "";
        if (rbtyesorno.SelectedValue == "1")
        {
            TRRBTINTERACTIONDATE.Visible = true;
        }
        else
        {
            TRRBTINTERACTIONDATE.Visible = false;
        }
    }

}