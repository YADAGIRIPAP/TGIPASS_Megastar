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

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        string status = Request.QueryString[0].ToString().Trim();
        string distid = Session["DistrictID"].ToString().Trim();



        //if (!IsPostBack)
        //{
        //    getdistricts();
        //    fetchIncentivedet();

        //}
        if (!IsPostBack)
        {
            getdistricts();
        }
        if (Request.QueryString.Count > 0)
        {


            if (!IsPostBack)
            {
                ddlDistrict.SelectedValue = distid;
                ddlDistrict.Enabled = false;
                if (Session["DistrictID"].ToString().Trim() == null || Session["DistrictID"].ToString().Trim() == "")
                {
                    ddlDistrict.Enabled = true;
                }
                //grdDetails.Columns[7].Visible = false;
                //grdDetails.Columns[8].Visible = false;
            }
        }
        else
        {

            ddlDistrict.SelectedValue = distid;
            ddlDistrict.Enabled = false;
        }

        if (!IsPostBack)
        {
            //getdistricts();
            fetchIncentivedet();

        }


    }
    protected void GetDepartment()
    {
        
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
    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.fetchIncentivedetnew(ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            if (Request.QueryString.Count > 0)
            {
                //if (Request.QueryString[0].ToString().Trim() == "3" || Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11")
                //{
                //    grdDetails.Columns[14].Visible = true;
                //}
                //else
                //{
                //    grdDetails.Columns[14].Visible = false;
                //}
            }
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
        fetchIncentivedet();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        fetchIncentivedet();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LblGmto = (e.Row.FindControl("LblGmto") as Label);
            HiddenField HdfGMTo = (e.Row.FindControl("HdfGMTo") as HiddenField);
           // DropDownList DdlOfficer = (e.Row.FindControl("DdlOfficer") as DropDownList);
            
            string PoluCategory= Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category")).Trim();
           
            if(PoluCategory.Trim().ToLower() =="micro" || PoluCategory.Trim().ToLower() =="small" )
            {
                LblGmto.Text = "Forward To: Collector - " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim();
                DataSet dsnew = new DataSet();
                dsnew = Gen.GetCollectorforIncentive(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistID")).Trim());
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    HdfGMTo.Value = dsnew.Tables[0].Rows[0]["intUserid"].ToString().Trim();
                }
                else
                {
                    HdfGMTo.Value = "1213";
                }
            }
            else
            {
                LblGmto.Text="Forward To: Commissioner"  ;
                 HdfGMTo.Value="1213";
            }
            //dsnew = Gen.GetDepartment();
            //ddlDeptname.DataSource = dsnew.Tables[0];
            //ddlDeptname.DataTextField = "Dept_Name";
            //ddlDeptname.DataValueField = "Dept_Id";
            //ddlDeptname.DataBind();
            //ddlDeptname.Items.Insert(0, "--Select--");
            //GetDepartment();
            //string IncentiveId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            //btn.Text = "View";


            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        FileUpload FileUpload6 = (FileUpload)row.FindControl("FileUpload6");
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtRemarks");
        DropDownList DdlStatus1 = (DropDownList)row.FindControl("DdlStatus");
        Label Label572 = (Label)row.FindControl("Label572");
      //  Label lblFileName2 = (Label)row.FindControl("lblFileName2");
        HiddenField HdfGMTo = (HiddenField)row.FindControl("HdfGMTo");
        if (DdlStatus1.SelectedIndex == 0)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\GMIncentiveCert");

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
                            newPath = System.IO.Path.Combine(sFileDir, HdfintApplicationid.Value +System.DateTime.Now.ToString("ddMMyyyyhhmm") + "\\GMIncentiveCert" + System.DateTime.Now.ToString("ddMMyyyyhhmmss"));
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

                            int returnValue = Gen.GMCertificateInsertUpload(HdfintApplicationid.Value, "", Session["uid"].ToString(), ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString(), HdfGMTo.Value, DdlStatus1.SelectedValue,TxtRemarks.Text);

                            if (returnValue != 999)
                            {
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

                ////lblresult.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                //success0.Visible = false;
                //Failure0.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        else
        {
            int returnValue = Gen.GMCertificateInsertUpload(HdfintApplicationid.Value, "", Session["uid"].ToString(), "","", HdfGMTo.Value, DdlStatus1.SelectedValue, TxtRemarks.Text);

            if (returnValue != 999)
            {
                fetchIncentivedet();
                lblresult.Text = "Attachment Successfully Uploaded";
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);



            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                lblresult.Text = "Status Not Updated";

            }
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


    protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DdlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)DdlStatus.NamingContainer;
        DropDownList DdlStatus1 = (DropDownList)row.FindControl("DdlStatus");
       
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtRemarks");

        FileUpload FileUpload6 = (FileUpload)row.FindControl("FileUpload6");
        Label lbl123 = (Label)row.FindControl("lbl123");
        Label Label572 = (Label)row.FindControl("Label572");
        Label LblGmto = (Label)row.FindControl("LblGmto");
        HyperLink lblFileName2 = (HyperLink)row.FindControl("lblFileName2");

        if (DdlStatus.SelectedIndex == 0)
        {
            
            FileUpload6.Visible = true;
            lbl123.Visible = true;
            Label572.Visible = true;
            LblGmto.Visible = true;
            lblFileName2.Visible = true;
            TxtRemarks.Visible = false;
        }
        else
        {
            
            FileUpload6.Visible = false;
            lbl123.Visible = false;
            Label572.Visible = false;
            LblGmto.Visible = false;
            lblFileName2.Visible = false;
            TxtRemarks.Visible = true;
        }

    }
}
