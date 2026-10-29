using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class UI_TSiPASS_ApproveDetailsbyquery_Travelagent : System.Web.UI.Page
{
    Cls_travelagent Gen = new Cls_travelagent();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            FillDetails();
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    FillDetails();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            if (BtnSave1.Text == "Submit")
            {
                if (ddlStatus.SelectedItem.Text.Trim() == "Approved")
                {

                    if (lblFileName.Text == "")
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                        lblmsg0.Text = "Please Upload the Approval Document";
                        return;
                    }
                    else
                    {
                        i = Gen.insertApprovalDataTravelagent(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text, getclientIP());
                    }
                }
                else
                {
                    if (txtremarks.Text != "")
                    {
                        i = Gen.insertApprovalDataTravelagent(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text, getclientIP());
                    }
                    else
                    {
                        lblmsg0.Text = "Please Enter Reason For Rejection..";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }

                if (i != 999)
                {
                    DataSet dsMail1 = new DataSet();
                    dsMail1 = Gen.GetShowEmailidandMobileNumber_travelagent(hdfFlagID3.Value.ToString());
                    if (ddlStatus.SelectedItem.Text.Trim() == "Approved")
                    {
                        txtGeo_Cordinate_Latitude.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";

                        lblmsg.Text = "Status Updated Successfully";
                        Response.Redirect("TourismagentAdminDashboard.aspx");
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        txtGeo_Cordinate_Latitude.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";

                        lblmsg.Text = "Status Updated Successfully";
                        Response.Redirect("TourismagentAdminDashboard.aspx");
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                }
                else
                {
                    lblmsg.Text = "failed..";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
  
    void FillDetails()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = Gen.GetdataofApprovaldataAproval_TravelagentbyID(Request.QueryString[0].ToString(), Session["User_Code"].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();

                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                hdfFlagID3.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                Session["Applid"] = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();

            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        finally
        {

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

    protected void BtnClear_Click1(object sender, EventArgs e)
    {


    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\RENAttachments");

           
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {
                       

                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ApprovalDocument\\" + hdfFlagID2.Value);

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
                            result = Gen.InsertAttachementApproval_Travelagent(Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ApprovalDocument", hdfFlagID2.Value, hdfFlagID1.Value);

                            if (result > 0)
                            {
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName.Text = FileUpload1.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlStatus.SelectedValue.ToString().Trim() == "16")
        {
            rem.Visible = true;
            Label455.Text = "Upload Document";
        }
        else
        {
            rem.Visible = false;
            Label455.Text = "Upload Certificate";
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













}