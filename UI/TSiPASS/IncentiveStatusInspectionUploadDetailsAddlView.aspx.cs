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

public partial class UI_TSiPASS_IncentiveStatusInspectionUploadDetailsAddlView : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string paths = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_Code"] == null)
        {
            Response.Redirect("~/ipasslogin.aspx");
        }
        string status = Request.QueryString[0].ToString().Trim();
        string distid = Session["DistrictID"].ToString().Trim();
        if (Request.QueryString.Count > 0)
        {

            //ddlstatus.SelectedValue = status;
            //ddlstatus.Enabled = false;
            //ddlDistrict.SelectedValue = distid;
            //ddlDistrict.Enabled = false;
            //grdDetails.Columns[7].Visible = false;
            //grdDetails.Columns[8].Visible = false;
        }
        else
        {
            //ddlstatus.SelectedIndex = 0;
            //ddlstatus.Enabled = true;
            //ddlDistrict.SelectedValue = distid;
            //ddlDistrict.Enabled = false;
        }

        if (!IsPostBack)
        {

            DataSet dsdist = new DataSet();
            dsdist = Gen.GetDistnamebylogin(Session["User_Code"].ToString());

            if (dsdist.Tables[0].Rows.Count > 0)
            {

                ddlDistrict.DataSource = dsdist.Tables[0];
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataBind();
                ddlDistrict.SelectedValue = ddlDistrict.Items.FindByValue(dsdist.Tables[0].Rows[0]["District_Id"].ToString().Trim()).Value;
                ddlDistrict.Enabled = false;
                //ddlDistrict.Items.Insert(0, "--Select--");


            }
            // getdistricts();
            getincentives();
            fetchIncentivedet();

        }

    }
    protected void GetDepartment()
    {

    }
    protected void getincentives()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetIncentives();

        ddlIncentiveName.DataSource = dsnew.Tables[0];
        ddlIncentiveName.DataTextField = "IncentiveName";
        ddlIncentiveName.DataValueField = "IncentiveID";
        ddlIncentiveName.DataBind();
        ddlIncentiveName.Items.Insert(0, "--Select--");
    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        ddlDistrict.DataSource = dsnew.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }
    //protected void fetchIncentivedet()
    //{
    //    DataSet ds= new DataSet();

    //    ds = Gen.fetchIncentivedetIPO(Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim(), ddlIncentiveName.SelectedValue, TxtIndname.Text);
    //         grdDetails.DataSource = ds.Tables[0]; 
    //        grdDetails.DataBind();

    //}
    //fetchIncentivedetIPONewIncType

    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.fetchIncentivedetIPONewIncTypeAddlDirector(Session["uid"].ToString(), Request.QueryString[0].ToString().Trim(), ddlIncentiveName.SelectedValue, TxtIndname.Text);
        //grdDetails.DataSource = ds.Tables[0];
        //grdDetails.DataBind();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvdetailsnew.DataSource = ds.Tables[0];
            gvdetailsnew.DataBind();
            if (Request.QueryString[0].ToString().Trim() == "1" || Request.QueryString[0].ToString().Trim() == "8")
            {
                gvdetailsnew.Columns[11].Visible = true;
                //gvdetailsnew.Columns[8].Visible = false;
            }
            else
            {
                gvdetailsnew.Columns[11].Visible = false;
            }
            if (Request.QueryString[0].ToString().Trim() == "21" || Request.QueryString[0].ToString().Trim() == "22")
            {
                gvdetailsnew.Columns[10].Visible = true;
                //gvdetailsnew.Columns[8].Visible = false;
            }
            else
            {
                gvdetailsnew.Columns[10].Visible = false;
            }
            if (Request.QueryString[0].ToString().Trim() == "24")
            {
                gvdetailsnew.Columns[12].Visible = true;
            }
            else
            {
                gvdetailsnew.Columns[12].Visible = false;
            }

        }
    }
    protected void gvdetailsnew_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
        //    string status = Request.QueryString[0].ToString().Trim();
        //    //Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
        //    (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status + "&SVCStatus="+Request.QueryString[1].ToString();
        //}
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
        fetchIncentivedet();
    }
   
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        FileUpload FileUpload6 = (FileUpload)row.FindControl("FileUpload6");
        Label Label572 = (Label)row.FindControl("Label572");
        //  Label lblFileName2 = (Label)row.FindControl("lblFileName2");
        TextBox txtInspectionDate = (TextBox)row.FindControl("txtInspectionDate");

        string newPath = "";
        string sFileDir = Server.MapPath("~\\IpoIncentive");

        General t1 = new General();
        if (FileUpload6.HasFile)
        {
            if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        newPath = System.IO.Path.Combine(sFileDir, HdfintApplicationid.Value + System.DateTime.Now.ToString("ddMMyyyyhhmm") + "\\IpoIncentive");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int returnValue = Gen.InsertUpload(HdfintApplicationid.Value, "", txtInspectionDate.Text, Session["uid"].ToString(), ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString());

                        if (returnValue != 999)
                        {
                            DataTable dt = objFetch.FetchIncentiveDtlsbyIncentiveID(HdfintApplicationid.Value);
                            string names = dt.Rows[0]["UnitName"].ToString();
                            string emailid = dt.Rows[0]["EmailID"].ToString();
                            paths = ViewState["pathAttachment"].ToString();


                            string msg = "Dear " + names + " , Your Unit's inspection report is prepared and sent to GM.Please see the given link for your inspection report URL: " + paths.Replace(@"D:\TS-iPASSFinal\", "https://ipass.telangana.gov.in/") + "  for your reference.Thank You";
                            cmf.SendMailTSiPASSIncentive(emailid, msg);
                            // cmf.SendMailTSiPASSIncentive("fss.srikanth@gmail.com", msg);
                            fetchIncentivedet();
                            lblresult.Text = "Attachment Successfully Uploaded";
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);



                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                            lblresult.Text = "Status Not Updated";

                        }



                        //int result = 0;

                        //result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalBoiler");


                        //if (result > 0)
                        //{
                        //ResetFormControl(this);
                        lblresult.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        //   lblFileName2.Text = FileUpload6.FileName;
                        Label572.Text = FileUpload6.FileName;
                        //success0.Visible = true;
                        //Failure0.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                        //}
                        //else
                        //{
                        //    lblresult.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        //    ////success0.Visible = false;
                        //    ////Failure0.Visible = true;
                        //    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        //}

                    }
                    else
                    {
                        lblresult.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        ////success0.Visible = false;
                        ////Failure0.Visible = true;
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    //// DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please upload certificate..');", true);

            lblresult.Text = "Please upload certificate";
            //int returnValue = Gen.InsertUpload(HdfintApplicationid.Value, "",txtInspectionDate.Text , Session["uid"].ToString(), null, null);

            //if (returnValue != 999)
            //{
            //    fetchIncentivedet();
            //    lblresult.Text = "Attachment Successfully Uploaded";
            //    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);



            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

            //    lblresult.Text = "Status Not Updated";
            //}
            ////lblresult.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success0.Visible = false;
            //Failure0.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

        //Button BtnSaveg = (Button)sender;
        //GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        //HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

        //if (ddlStatus.SelectedIndex == 0)
        //{
        //    lblresult.Text = "Please Select Status";
        //}
        //else
        //{
        //    //  lblresult.Text = "Status Updated";


        //    int returnValue = Gen.ChangeStateWiseStatus(HdfintApplicationid.Value, ddlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString());

        //    if (returnValue != 999)
        //    {

        //        lblresult.Text = "Status Updated";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);

        //        fillgrid();

        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

        //        lblresult.Text = "Status Not Updated";

        //    }


        //        }
        //  int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());




    }


    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        //ExportToExcel();
    }
    protected void anchortaglink_Click(object sender, EventArgs e)
    {
        Button ddlDeptnameFnl2 = (Button)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

        Label enterid = (Label)row.FindControl("lblIncentiveID");
        Label Incids = (Label)row.FindControl("lblIncentiveIDS");
        string status = Request.QueryString[0].ToString().Trim();
        Button Button1 = (Button)row.FindControl("anchortaglink");


        string newurl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status + "&SVCStatus=" + Request.QueryString[1].ToString() + "&IncIds=" + Incids.Text.Trim();
        Response.Redirect(newurl);
        // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open(" + newurl + ",'_newtab');", true);
    }

}