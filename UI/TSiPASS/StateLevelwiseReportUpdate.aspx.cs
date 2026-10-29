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

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch


public partial class LookupCA : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
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
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        if (!IsPostBack)
        {
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
        string fromdate, todate;
        if (txtFromdate.Text.Trim() == "")
        {
            fromdate = Convert.ToDateTime("01/01/2010").ToString("yyyy-MM-dd");

        }

        else
        {

            fromdate = Convert.ToDateTime(txtFromdate.Text.Trim()).ToString("yyyy-MM-dd");
        }

        if (txtTodate.Text.Trim() == "")
        {
            todate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyy-MM-dd");

        }

        else
        {

            todate = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("yyyy-MM-dd");
        }

        DataSet dsnew = new DataSet();

        dsnew = Gen.getdataofStatelevel1(ddlConnectLoad.SelectedItem.Text.ToString(), txtUnitname.Text, fromdate, todate);

        if (dsnew.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();


        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + "State Level Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                string fromdate, todate;
                if (txtFromdate.Text.Trim() == "")
                {
                    fromdate = Convert.ToDateTime("01/01/2010").ToString("yyyy-MM-dd");

                }

                else
                {

                    fromdate = Convert.ToDateTime(txtFromdate.Text.Trim()).ToString("yyyy-MM-dd");
                }

                if (txtTodate.Text.Trim() == "")
                {
                    todate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyy-MM-dd");

                }

                else
                {

                    todate = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("yyyy-MM-dd");
                }

                DataSet dsnew = new DataSet();

                dsnew = Gen.getdataofStatelevel1(ddlConnectLoad.SelectedItem.Text.ToString(), txtUnitname.Text, fromdate, todate);

                //dsnew.Tables[0].Columns.Remove("Status");

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
            string progress = e.Row.Cells[10].Text.ToString();
            if (progress.ToUpper() == "COMMENCED OPERATIONS")
            {
                ddlStatus.Items.Remove(new ListItem("COMMENCED OPERATIONS"));
                ddlStatus.Items.Remove(new ListItem("ADVANCED STAGE"));
                ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            }
            if (progress.ToUpper() == "ADVANCED STAGE")
            {
                ddlStatus.Items.Remove(new ListItem("ADVANCED STAGE"));
                ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            }
            if (progress.ToUpper() == "INITIAL STAGE")
            {
                ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            }
            if (progress.ToUpper() == "YET TO START CONSTRUCTION")
            {
                ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            }
        }
    }

    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileName = "";

        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtreasonschange = (TextBox)row.FindControl("txtreasonschange");

        HyperLink HyperLinknew = (HyperLink)row.FindControl("HyperLink1");
        Label Label6 = (Label)row.FindControl("Label6new");
        FileUpload fupPERCert = (FileUpload)row.FindControl("fluPrincipalEmployersRegistrationCertificate");

        if (txtreasonschange.Text.Trim().TrimStart() == "")
        {
            lblresult.Text = "Please Enter Reason For Status Change";
            lblresult.Focus();
            return;
        }

        if (ddlStatus.SelectedIndex == 0)
        { 
            lblresult.Text = "Please Select Status";
        }
        else
        {
          //  lblresult.Text = "Status Updated";
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

                    string message1 = "alert(Please Upload file)";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                    return;
                }
            }

            int returnValue = Gen.ChangeStateWiseStatus(HdfintApplicationid.Value, ddlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString(), txtreasonschange.Text.Trim().TrimStart(), (newPath + "\\" + sFileName));

            if (returnValue != 999)
            {

                lblresult.Text = "Status Updated";
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);

                fillgrid();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                lblresult.Text = "Status Not Updated";

            }

            
        }
        //  int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());




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
}
