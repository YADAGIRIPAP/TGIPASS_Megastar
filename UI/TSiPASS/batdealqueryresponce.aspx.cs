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
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID

public partial class UI_TSiPASS_batdealqueryresponce : System.Web.UI.Page
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
    string intEnterpreniourApprovalid = "", batdealerid = "",  intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
    DB.DB con = new DB.DB();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["BatdealerID"] != null)//reference common id to be use//
        {
            hdfFlagID0.Value = Request.QueryString["BatdealerID"];

            if (!IsPostBack)
            {
                FillDetails();

            }

        }





        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        // Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value);


    }
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = GetQueryStatusByTransactionIDbatdealer(Request.QueryString[0].ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["BatdealerID"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["Nameofthedealer"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString() != null && ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim() != "")
                {
                    txtdiscription.Text = ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim();
                }

                if (ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString() != null && ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim() != "")
                {
                    lblFileNameResponse.NavigateUrl = ds.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                    lblFileNameResponse.Text = "Response Attachment";
                    //lblFileNameResponse.Text = ds.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                }
                //if (hdfFlagID1.Value == "266")
                //{
                //    Session["ApplidA"] = intQuessionaireid;
                //    Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + intCFEEnterpid + "&next=N&Query=" + "Y&intApprovalid=" + hdfFlagID2.Value + "&Queryid=" + Request.QueryString[0].ToString());
                //}

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
public int InsertQueryDetailsRenewal(string intEnterpreniourApprovalid,
string batdealerid,
string intDeptid,
string intApprovalid,
string QueryRaiseDate,
string QueryDescription,
string QueryStatus,
string QueryAttachmentFileName,
string QueryAttachmentFilePath,
string QueryRespondDate,
string QueryRespondRemarks,
string Created_by,
string Created_dt,
string Modified_by, string Modified_dt, string IPAddress)
 
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertQueryDetailsbatdealer", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (IPAddress.Trim() == "" || IPAddress.Trim() == null || IPAddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            }



            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null || intEnterpreniourApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = Int32.Parse(intEnterpreniourApprovalid.Trim());
            }

            if (batdealerid.Trim() == "" || batdealerid.Trim() == null || batdealerid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@batdealerID", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@batdealerID", SqlDbType.Int).Value = Int32.Parse(batdealerid.Trim());
            }

           
            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }


            if (QueryDescription.ToString().Trim() == "" || QueryDescription.ToString().Trim() == null || QueryDescription.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();

            if (QueryStatus.ToString().Trim() == "" || QueryStatus.ToString().Trim() == null || QueryStatus.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

            if (QueryAttachmentFileName.ToString().Trim() == "" || QueryAttachmentFileName.ToString().Trim() == null || QueryAttachmentFileName.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.ToString().Trim() == "" || QueryAttachmentFilePath.ToString().Trim() == null || QueryAttachmentFilePath.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();


            if (QueryRespondRemarks.ToString().Trim() == "" || QueryRespondRemarks.ToString().Trim() == null || QueryRespondRemarks.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();


            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }

            


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
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
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }
    public DataSet GetQueryStatusByTransactionIDbatdealer(string User_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_GetQueryStatusByTransactionIDBATDEALER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (User_id.Trim() == "" || User_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = User_id;

            if (User_id.Trim() == "" || User_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";



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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        if (ViewState["pathAttachment"] == null)
            ViewState["pathAttachment"] = "";
        if (ViewState["AttachmentName"] == null)
            ViewState["AttachmentName"] = "";

        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = GetQueryStatusByTransactionIDbatdealer(Request.QueryString[0].ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["BatdealerID"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["Nameofthedealer"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();

                //Label447.Text = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                //Label448.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
                ////Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                ////Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                //Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                ////Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                //Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();


                //intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                //intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                //intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                //intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                //intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                //QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                //Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                //Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";


            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

        try
        {
            int result = 0;
            string queryresopnedesc = txtdiscription.Text.Trim();
            result = InsertQueryDetailsRenewal(intEnterpreniourApprovalid, Label447.Text,  intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), "", queryresopnedesc, Created_by, "", "", "", getclientIP());
            // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            if (result > 0)
            {
              
                lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                Response.Redirect("Batuserdashboard.aspx?batdealerid=" + Label447.Text.ToString());
                }
                else
                {
                lblmsg0.Text = "<font color='red'>Query Details Adding Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
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

    protected void Button6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\BATTERYDEALER");

        General t1 = new General();
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ResponseAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

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

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label440.Text = FileUpload1.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
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
}

