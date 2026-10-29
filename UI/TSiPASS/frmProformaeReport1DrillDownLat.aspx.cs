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
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    //DataRow dtrdr;
    //DataTable myDtNewRecdr = new DataTable();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    string GPSFileName,GPSFilePath,GPSFileType;
    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;

    protected void Page_Load(object sender, EventArgs e)
    {
        //btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");

           
        }


        if (!IsPostBack)
        {

            lblIPOname.Text = Session["user_id"].ToString();

             for (int i = 1990; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add((new ListItem(i.ToString(), i.ToString())));
            }




            string year="";
            year=System.DateTime.Now.Year.ToString();

          //  ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;

           // ddlYear.SelectedItem.Text = year.ToString();
          //  ddlYear.Enabled = false;
            string month="";
            month=System.DateTime.Now.Month.ToString();
           // ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Value;
          //  ddlMonth.SelectedItem.Text = month.ToString();
          // ddlMonth.Enabled = false;
           dtMyTableCertificate = createtablecrtificate();
           Session["CertificateTb2"] = dtMyTableCertificate;

           dtMyTableCertificate1 = createtablecrtificate1();
           Session["CertificateTb1"] = dtMyTableCertificate1;



           DataSet ds = Gen.getBankReport(Request.QueryString[1].ToString(), Request.QueryString[0].ToString(), Session["uidIPO"].ToString());

           if (ds.Tables[0].Rows.Count > 0)
           {
               hdfID.Value = ds.Tables[0].Rows[0]["intBankReportid"].ToString();
               FillDetails();
               //BtnSave1.Text = "Update";
           }


            DataSet ds1 = new DataSet();

            ds1 = Gen.getIPOTargetBankvisit(Request.QueryString[1].ToString(), Request.QueryString[0].ToString(), Session["uidIPO"].ToString());

            if (ds1.Tables[0].Rows.Count > 0)
            {

                txtIPO.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
                //lblmsg2.Text = ds1.Tables[0].Rows[0]["Target"].ToString();

            }





            DataSet dsbank = new DataSet();

            dsbank = Gen.Getbanks();
            if (dsbank.Tables[0].Rows.Count > 0)
            {
                //ddlBankName.DataSource = dsbank.Tables[0];
                //ddlBankName.DataTextField = "BankName";
                //ddlBankName.DataValueField = "Id";
                //ddlBankName.DataBind();
                //ddlBankName.Items.Insert(0, "--Select--");


            }



            //DataSet dsver = new DataSet();

            //dsver = Gen.getIPONamebyuser(Session["User_Code"].ToString());
            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    lblIPOname.Text = dsver.Tables[0].Rows[0][""].ToString();
            //}


           // DataSet dscheck = new DataSet();
           // dscheck = Gen.GetShowQuestionaries(Session["uidIPO"].ToString().Trim());
           // if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}

            //DataSet dsver = new DataSet();


           // dsver = Gen.Getverifyofque2(Session["Applid"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatus(Session["Applid"].ToString());
            //    //string res = Gen.RetriveStatus("1002");


            //    //if (res == "3" || Convert.ToInt32(res) >= 3)
            //    //{
            //    //    //  ResetFormControl(this);
            //    //}

            //}






            //DataSet dsc = new DataSet();
            //dsc = Gen.GetCategoryDet();
            //ddlintLineofActivity.DataSource = dsc.Tables[0];
            //ddlintLineofActivity.DataValueField = "intLineofActivityid";
            //ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            //ddlintLineofActivity.DataBind();
            //ddlintLineofActivity.Items.Insert(0, "--Select--");

           
            //if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");
            //}


            //if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            //{

            //    //DataSet dsch = new DataSet();
            //    //dsch = Gen.GetEnterPreneurdatabylineofactivity1(Session["Applid"].ToString());

            //    //if (dsch.Tables[0].Rows.Count > 0)
            //    //{
            //    //    if (dsch.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim() != "")
            //    //    {

            //    //        ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dsch.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;

            //    //        ddlintLineofActivity.Enabled = false;
            //    //    }

            //    //}



            //}


        }

    



        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
               // FillDetails();

            }

        }
        
        //if (hdfFlagID0.Value.ToString().Trim() != "")
        //{


        //}
        if (Request.QueryString.Count > 0)
        {

            Failure.Visible = false;
            success.Visible = false;

            FillDetails();
         //   BtnSave1.Text = "Update";

        }


      //  if (!IsPostBack)
       // {
            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {
               // if (!IsPostBack)
               // {

                    Failure.Visible = false;
                    success.Visible = false;

                   
                        FillDetails();
                   // }
                    //BtnSave1.Text = "Update";
               // }
            }
       // }
    }


    public void ResetFormControl(Control parent)
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


    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intBankReportid", typeof(string));
        dtMyTable.Columns.Add("TypeofReport", typeof(string));
        dtMyTable.Columns.Add("intBankid", typeof(string));
        dtMyTable.Columns.Add("BranchName", typeof(string));
        dtMyTable.Columns.Add("NameofUnit", typeof(string));
        dtMyTable.Columns.Add("AddressofUnit", typeof(string));
        dtMyTable.Columns.Add("Remarks", typeof(string));
        dtMyTable.Columns.Add("BankName", typeof(string));
        dtMyTable.Columns.Add("TypeName", typeof(string));
       // dtMyTable.Columns.Add("OtherItemName", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));

        

        dtMyTable.Columns.Add("Created_by", typeof(string));

        dtMyTable.Columns.Add("intBankReportChildid", typeof(string));


        return dtMyTable;
    }


    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");

        dtMyTable1.Columns.Add("new", typeof(string));
        dtMyTable1.Columns.Add("intQuessionaireid", typeof(string));
        dtMyTable1.Columns.Add("intCFEEnterpid", typeof(string));
        dtMyTable1.Columns.Add("Raw_ItemName", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity_In", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity_Per", typeof(string));
        dtMyTable1.Columns.Add("OtherItemName", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        dtMyTable1.Columns.Add("Created_by", typeof(string));

        dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


        return dtMyTable1;
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    public void DeleteFile1(string strFileName)
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
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{

    //    if (BtnSave1.Text == "Update")
    //    {

    //        hdfFlagID.Value = "";

    //        if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Bank wise Details and Click Add New Button </font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }

    //        if (ddlType.SelectedValue != "2")
    //        {

    //            GPSFileName = "";
    //            GPSFilePath = "";
    //            GPSFileType = "";
    //            string newPath = "";
    //            string sFileDir = Server.MapPath("~\\IPOSPerformance");

    //            if (FileUpload1.HasFile)
    //            {
    //                GPSFileName = "";
    //                GPSFilePath = "";
    //                GPSFileType = "";
    //                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //                {
    //                    //determine file name
    //                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //                    try
    //                    {

    //                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //                        int i = fileType.Length;
    //                        //if (fileType[i - 1].ToUpper().Trim() == "PDF")
    //                        //{
    //                        //Create a new subfolder under the current active folder
    //                        //newPath = System.IO.Path.Combine(sFileDir, "1000");
    //                        if (Session.Count > 0)
    //                        {
    //                            newPath = System.IO.Path.Combine(sFileDir, Session["uidIPO"].ToString());
    //                        }
    //                        else
    //                        {
    //                            newPath = System.IO.Path.Combine(sFileDir, "1000");
    //                        }

    //                        GPSFilePath = newPath + "IPO" + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
    //                        GPSFileType = fileType[i - 1].ToUpper().Trim();
    //                        GPSFileName = sFileName;
    //                        //////////////

    //                        if (!Directory.Exists(GPSFilePath))

    //                            System.IO.Directory.CreateDirectory(GPSFilePath);
    //                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(GPSFilePath);
    //                        int count = dir.GetFiles().Length;
    //                        if (count == 0)
    //                            FileUpload1.PostedFile.SaveAs(GPSFilePath + "\\" + GPSFileName);
    //                        else
    //                        {
    //                            if (count == 1)
    //                            {
    //                                string[] Files = Directory.GetFiles(GPSFilePath);

    //                                foreach (string file in Files)
    //                                {
    //                                    File.Delete(file);
    //                                }
    //                                FileUpload1.PostedFile.SaveAs(GPSFilePath + "\\" + GPSFileName);
    //                            }
    //                        }

    //                        //}
    //                        //else
    //                        //{
    //                        //    lblresult.Text = "<font color='red'>Upload PDF files only..!</font>";
    //                        //    //success.Visible = false;
    //                        //    //Failure.Visible = true;
    //                        //    return;
    //                        //}

    //                    }
    //                    catch (Exception)//in case of an error
    //                    {
    //                        DeleteFile1(newPath + "\\" + sFileName);
    //                    }
    //                }
    //            }




    //            if (GPSFileName.ToString() == "" || GPSFilePath.ToString() == "" || GPSFileName.ToString() == null || GPSFilePath.ToString() == null)
    //            {

    //                lblmsg0.Text = "Please Upload Document";
    //                success.Visible = false;
    //                Failure.Visible = true;
    //                return;

    //            }
    //        }



    //        int z = 0;

    //        z = Gen.insertIPOBankVisitDet(hdfID.Value.ToString(), txtIPO.Text, TxtNoofMandals.Text, TxtBranchs.Text, Session["uidIPO"].ToString(), Session["uidIPO"].ToString(), Request.QueryString[1].ToString(), Request.QueryString[0].ToString(), GPSFilePath.ToString(), GPSFileName.ToString());

    //        if (z != 999)
    //        {




    //            int j = Gen.deletebankwiserpt(hdfID.Value.ToString());

    //            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
    //            {

    //                for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
    //                {
    //                    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intBankReportChildid"].ToString().Trim() == "0")
    //                    {
    //                        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

    //                        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

    //                        ((DataTable)Session["CertificateTb2"]).Rows[m]["intBankReportid"] = Convert.ToString(hdfID.Value);
    //                    }
    //                }

    //                GetNewRectoInsertdr();
    //                int statuspr = Gen.bulkInsertBankreport(myDtNewRecdr);


    //                Session.Remove("CertificateTb2");

    //                gvCertificate.DataSource = null;
    //                gvCertificate.DataBind();

    //            }


    //            clear();
    //            lblmsg.Text = "Updated Successfully";

    //            success.Visible = true;
    //            Failure.Visible = false;






    //        }

    //    }


    //        if (BtnSave1.Text == "Save")
    //        {

    //            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
    //            {
    //                lblmsg0.Text = "<font color=red> Please Enter Bank wise Details and Click Add New Button. </font>";

    //                success.Visible = false;
    //                Failure.Visible = true;
    //                return;
    //            }



    //            if (ddlType.SelectedValue != "2")
    //            {

    //                GPSFileName = "";
    //                GPSFilePath = "";
    //                GPSFileType = "";
    //                string newPath1 = "";
    //                string sFileDir1 = Server.MapPath("~\\IPOSPerformance");

    //                if (FileUpload1.HasFile)
    //                {
    //                    GPSFileName = "";
    //                    GPSFilePath = "";
    //                    GPSFileType = "";
    //                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //                    {
    //                        //determine file name
    //                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //                        try
    //                        {

    //                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //                            int i = fileType.Length;
    //                            //if (fileType[i - 1].ToUpper().Trim() == "PDF")
    //                            //{
    //                            //Create a new subfolder under the current active folder
    //                            //newPath = System.IO.Path.Combine(sFileDir, "1000");
    //                            if (Session.Count > 0)
    //                            {
    //                                newPath1 = System.IO.Path.Combine(sFileDir1, Session["uidIPO"].ToString());
    //                            }
    //                            else
    //                            {
    //                                newPath1 = System.IO.Path.Combine(sFileDir1, "1000");
    //                            }

    //                            GPSFilePath = newPath1 + "IPO" + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
    //                            GPSFileType = fileType[i - 1].ToUpper().Trim();
    //                            GPSFileName = sFileName;
    //                            //////////////

    //                            if (!Directory.Exists(GPSFilePath))

    //                                System.IO.Directory.CreateDirectory(GPSFilePath);
    //                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(GPSFilePath);
    //                            int count = dir.GetFiles().Length;
    //                            if (count == 0)
    //                                FileUpload1.PostedFile.SaveAs(GPSFilePath + "\\" + GPSFileName);
    //                            else
    //                            {
    //                                if (count == 1)
    //                                {
    //                                    string[] Files = Directory.GetFiles(GPSFilePath);

    //                                    foreach (string file in Files)
    //                                    {
    //                                        File.Delete(file);
    //                                    }
    //                                    FileUpload1.PostedFile.SaveAs(GPSFilePath + "\\" + GPSFileName);
    //                                }
    //                            }

    //                            //}
    //                            //else
    //                            //{
    //                            //    lblresult.Text = "<font color='red'>Upload PDF files only..!</font>";
    //                            //    //success.Visible = false;
    //                            //    //Failure.Visible = true;
    //                            //    return;
    //                            //}

    //                        }
    //                        catch (Exception)//in case of an error
    //                        {
    //                            DeleteFile1(newPath1 + "\\" + sFileName);
    //                        }
    //                    }
    //                }




    //                if (GPSFileName.ToString() == "" || GPSFilePath.ToString() == "" || GPSFileName.ToString() == null || GPSFilePath.ToString() == null)
    //                {

    //                    lblmsg0.Text = "Please Upload Document";
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    return;

    //                }
    //            }
               




    //            int x = 0;

    //            x = Gen.insertIPOBankVisitDet("0", txtIPO.Text, TxtNoofMandals.Text, TxtBranchs.Text, Session["uidIPO"].ToString(), Session["uidIPO"].ToString(), Request.QueryString[1].ToString(), Request.QueryString[0].ToString(), GPSFilePath.ToString(), GPSFileName.ToString());

    //            if (x != 999)
    //            {




    //                int j = Gen.deletebankwiserpt(x.ToString());

    //                if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
    //                {

    //                    for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
    //                    {
    //                        if (((DataTable)Session["CertificateTb2"]).Rows[m]["intBankReportChildid"].ToString().Trim() == "0")
    //                        {
    //                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

    //                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

    //                            ((DataTable)Session["CertificateTb2"]).Rows[m]["intBankReportid"] = Convert.ToString(x);
    //                        }
    //                    }

    //                    GetNewRectoInsertdr();
    //                    int statuspr = Gen.bulkInsertBankreport(myDtNewRecdr);


    //                    Session.Remove("CertificateTb2");

    //                    gvCertificate.DataSource = null;
    //                    gvCertificate.DataBind();

    //                }


    //                clear();
    //                lblmsg.Text = "Registered Successfully";

    //                success.Visible = true;
    //                Failure.Visible = false;



    //            }





    //        }


    //        //if (BtnSave1.Text == "Save")
    //        //{


    //        //    lblmsg.Text = "";


    //        //    if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
    //        //    {
    //        //        lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details </font>";

    //        //        success.Visible = false;
    //        //        Failure.Visible = true;
    //        //        return;
    //        //    }




    //        //    if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
    //        //    {
    //        //        lblmsg0.Text = "<font color=red> Please Enter Raw Material Details </font>";

    //        //        success.Visible = false;
    //        //        Failure.Visible = true;
    //        //        return;
    //        //    }





    //        //    int i = Gen.DeletebyManufactureid(hdfFlagID0.Value.ToString());

    //        //    if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
    //        //    {

    //        //        //for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
    //        //        //{
    //        //        //    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intLineofActivityMid"].ToString().Trim() == "0")
    //        //        //    {
    //        //        //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

    //        //        //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
    //        //        //    }
    //        //        //}

    //        //        GetNewRectoInsertdr();
    //        //        int statuspr = Gen.bulkInsertmanufacture(myDtNewRecdr);


    //        //        //Session.Remove("CertificateTb");

    //        //        //gvCertificate.DataSource = null;
    //        //        //gvCertificate.DataBind();

    //        //    }


    //        //    int j = Gen.DeletebyRawMaterialid(hdfFlagID0.Value.ToString());


    //        //    if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
    //        //    {

    //        //        //for (int n = 0; n < ((DataTable)Session["CertificateTb1"]).Rows.Count; n++)
    //        //        //{
    //        //        //    if (((DataTable)Session["CertificateTb1"]).Rows[n]["intLineofActivityRid"].ToString().Trim() == "0")
    //        //        //    {
    //        //        //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

    //        //        //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
    //        //        //    }
    //        //        //}

    //        //        GetNewRectoInsertdr1();
    //        //        int statuspr1 = Gen.bulkInsertRAWmaterial(myDtNewRecdr1);


    //        //        //Session.Remove("CertificateTb1");

    //        //        //gvCertificate0.DataSource = null;
    //        //        //gvCertificate0.DataBind();

    //        //        if (statuspr1 > 0)
    //        //        {
    //        //            lblmsg.Text = "Added Successfully..!";
    //        //            success.Visible = true;
    //        //            Failure.Visible = false;
    //        //            //clear();

    //        //        }

    //        //    }



    //        //    //if (statuspr1 > 0)
    //        //    //{

    //        //    //}




    //        //}


    //   // }
    //}
    void clear()
    {

        txtIPO.Text = "";
        TxtNoofMandals.Text = "";
        TxtBranchs.Text = "";
        ddlYear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;

        
       
       
    }


   
    void FillDetails()
    {

        DataSet ds = new DataSet();

        
        try
        {


            hdfFlagID.Value = "1";

            DataSet dsfill = new DataSet();
            dsfill = Gen.getBankReportFilldetails(hdfID.Value.ToString());


            if (dsfill.Tables[0].Rows.Count > 0)
            {

                txtIPO.Text = dsfill.Tables[0].Rows[0]["NoofBranches"].ToString();

                TxtNoofMandals.Text = dsfill.Tables[0].Rows[0]["NoofBranchesMandals"].ToString();
                TxtBranchs.Text = dsfill.Tables[0].Rows[0]["NofoBranchesVisited"].ToString();
               // txtIPO.Text = dsfill.Tables[0].Rows[0]["NoofBranches"].ToString();
               // txtIPO.Text = dsfill.Tables[0].Rows[0]["NoofBranches"].ToString();
                ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsfill.Tables[0].Rows[0]["BankR_Year"].ToString()).Value;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(dsfill.Tables[0].Rows[0]["BankR_Month"].ToString()).Value;

                lblFileName.NavigateUrl = dsfill.Tables[0].Rows[0]["FileDownload"].ToString();

                lblFileName.Text = dsfill.Tables[0].Rows[0]["GPSFileName"].ToString();
              //  TxtNoofMandals.Enabled = false;
              //  TxtBranchs.Enabled = false;
               // txtIPO.Enabled = false;
                DataSet dstr = new DataSet();

                dstr = Gen.getBankReportTrans(hdfID.Value.ToString());

                if (dstr.Tables[0].Rows.Count > 0)
                {
                    //lblmsg1.Text = dstr.Tables[0].Rows.Count.ToString();
                    DataTableReader rdt = new DataTableReader(dstr.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    ((DataTable)Session["CertificateTb2"]).Clear();
                    ((DataTable)Session["CertificateTb2"]).Load(readert);
                    gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
                    gvCertificate.DataBind();
                    //gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;

                }
                else
                {
                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();
                }




            }



            


            //DataSet dsbatch = cmn.traineebatchexists(hdfID.Value.ToString());
            //if (dsbatch.Tables[0].Rows.Count > 0)
            //{
            //    gvTradeMapping.Columns[1].Visible = false;
            //    //BtnAddnew.Enabled = false;
            //}
            //else
            //{
            //    gvTradeMapping.Columns[1].Visible = true;
            //    //BtnAddnew.Enabled = true;
            //}

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
        //Response.Redirect("frmLINEOFMANUFACTURE.aspx");
        Response.Redirect("frmProformaeReport1.aspx");
       // clear();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    void getcounties()
    {
       
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    void getPayams()
    {
       
    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
            
        try
        {

           

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    
    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

      


    }
  
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
      
    }
    //protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        if (BtnSave1.Text == "Save")
    //        {

              




    //        }
    //        else
    //        {
               

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //  lblresult.Text = ex.ToString();

    //    }
    //    finally
    //    {
    //    }
    //}



    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
        
    }


    protected void GetNewRectoInsertdr1()
    {
        myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
        DataView dvdr1 = new DataView(myDtNewRecdr1);
        //dvdr1.RowFilter = "new = 0";
        myDtNewRecdr1 = dvdr1.ToTable();

    }
    protected void txtquantity1_TextChanged(object sender, EventArgs e)
    {

    }
    private void AddDataToTableCeertificate(string TypeofReport, string intBankid, string BranchName, string NameofUnit, string AddressofUnit, DataTable myTable, string Remarks, string BankName, string TypeName)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["TypeofReport"] = TypeofReport;
            Row["intBankid"] = intBankid;
            Row["BranchName"] = BranchName;

            Row["NameofUnit"] = NameofUnit;
            Row["AddressofUnit"] = AddressofUnit;
          //  Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
           // Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uidIPO"].ToString().Trim();
            Row["Remarks"] = Remarks;
            Row["BankName"] = BankName;
            Row["TypeName"] = TypeName;
            Row["intBankReportChildid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }



    private void AddDataToTableCeertificate1(string intQuessionaireid,string intCFEEnterpid,string Raw_ItemName, string Raw_Item_Quantity, string Raw_Item_Quantity_In, string Raw_Item_Quantity_Per, string OtherItemName,DataTable myTable1)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable1.NewRow();

            dtMyTable1 = new DataTable("CertificateTb1");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intQuessionaireid"] = intQuessionaireid;
            Row["intCFEEnterpid"] = intCFEEnterpid;
            Row["Raw_ItemName"] = Raw_ItemName;

            Row["Raw_Item_Quantity"] = Raw_Item_Quantity;
            Row["Raw_Item_Quantity_In"] = Raw_Item_Quantity_In;
            Row["Raw_Item_Quantity_Per"] = Raw_Item_Quantity_Per;
            Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uidIPO"].ToString().Trim();

            Row["intLineofActivityRid"] = "0";

            myTable1.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }

    //protected void BtnSave2_Click1(object sender, EventArgs e)
    //{

    //    try
    //    {


    //        gvCertificate.Visible = true;

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate(ddlType.SelectedValue.ToString(), ddlBankName.SelectedValue.ToString(), txtBankBranch.Text, txtUnitName.Text, txtAddress.Text, (DataTable)Session["CertificateTb2"],TxtRemarks.Text,ddlBankName.SelectedItem.Text.ToString(),ddlType.SelectedItem.Text.ToString());//Session["uidIPO"].ToString()

    //            lblmsg1.Text = ((DataTable)Session["CertificateTb2"]).Rows.Count.ToString();
    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //            gvCertificate.Columns[0].Visible = false;

    //            //lblmsg.Text = "";
    //            lblmsg.Text = "";
    //            ddlType.SelectedIndex = 0;
    //            ddlBankName.SelectedIndex = 0;
    //            txtBankBranch.Text = "";
    //            txtUnitName.Text = "";
    //            txtAddress.Text = "";
    //            TxtRemarks.Text = "";
    //            //txtManItem.Text = "";
    //            //txtManQuantity.Text = "";
    //            //ddlManQuantityIn.SelectedIndex = 0;
    //            //ddlManQuantityPer.SelectedIndex = 0;

    //            //}
    //        }

    //        else if (hdfID.Value.Trim() != "")//&& hdfFlagID.Value == "2"
    //            {

    //                AddDataToTableCeertificate(ddlType.SelectedValue.ToString(), ddlBankName.SelectedValue.ToString(), txtBankBranch.Text, txtUnitName.Text, txtAddress.Text, (DataTable)Session["CertificateTb2"], TxtRemarks.Text, ddlBankName.SelectedItem.Text.ToString(), ddlType.SelectedItem.Text.ToString());//Session["uidIPO"].ToString()

    //                lblmsg1.Text = ((DataTable)Session["CertificateTb2"]).Rows.Count.ToString();
    //                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //                this.gvCertificate.DataBind();
    //                gvCertificate.Columns[0].Visible = false;

    //                //lblmsg.Text = "";
    //                lblmsg.Text = "";
    //                ddlType.SelectedIndex = 0;
    //                ddlBankName.SelectedIndex = 0;
    //                txtBankBranch.Text = "";
    //                txtUnitName.Text = "";
    //                txtAddress.Text = "";
    //                TxtRemarks.Text = "";
    //                //txtManItem.Text = "";
    //                //txtManQuantity.Text = "";
    //                //ddlManQuantityIn.SelectedIndex = 0;
    //                //ddlManQuantityPer.SelectedIndex = 0;



    //            }


    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }



    //    //gvCertificate.Visible = true;
    //    //try
    //    //{




    
    //    //    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //    //    {
    //    //        AddDataToTableCeertificate(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem.Text, txtquantity.Text, ddlquantityin.SelectedValue.ToString(), ddlquantityper.SelectedValue.ToString(),txtitem2.Text, (DataTable)Session["CertificateTb2"]);


    //    //        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //    //        this.gvCertificate.DataBind();
    //    //        gvCertificate.Columns[0].Visible = false;
    //    //        gvCertificate.Columns[6].Visible = false;
    //    //        //lblmsg.Text = "";
    //    //        lblmsg.Text = "";
    //    //        txtitem.Text = "";
    //    //        txtquantity.Text = "";
    //    //        ddlquantityin.SelectedIndex = 0;
    //    //        ddlquantityper.SelectedIndex = 0;
    //    //        txtitem2.Text = "";
    //    //        //}
    //    //    }
    //    //    else
    //    //        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
    //    //        {

    //    //            //gvCertificate.Visible = true;


    //    //            //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
    //    //            //siva as on 10-08-2103
    //    //            // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
    //    //            AddDataToTableCeertificate(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem.Text, txtquantity.Text, ddlquantityin.SelectedValue.ToString(), ddlquantityper.SelectedValue.ToString(), txtitem2.Text, (DataTable)Session["CertificateTb2"]);
    //    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //    //            this.gvCertificate.DataBind();
    //    //            gvCertificate.Columns[0].Visible = false;
    //    //            gvCertificate.Columns[6].Visible = false;
    //    //            //clear_child_TOT();
    //    //            lblmsg.Text = "";
    //    //            txtitem.Text = "";
    //    //            txtquantity.Text = "";
    //    //            ddlquantityin.SelectedIndex = 0;
    //    //            ddlquantityper.SelectedIndex = 0;
    //    //            txtitem2.Text = "";
    //    //            //}
    //    //        }
    //    //}

    //    //catch (Exception ee)
    //    //{
    //    //    ////lbldtvalid.Text = "Please enter correct Date.";
    //    //    ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
    //    //}

    //    //gvCertificate.Visible = true;

    //}
    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{

    //    txtAddress.Text = "";
    //    txtBankBranch.Text = "";
    //    ddlBankName.SelectedIndex = 0;
    //    ddlType.SelectedIndex = 0;
    //    txtUnitName.Text = "";
    //    TxtRemarks.Text = "";
    //    //txtitem.Text = "";
    //    //txtquantity.Text = "";
    //    //ddlquantityin.SelectedIndex = 0;
    //    //ddlquantityper.SelectedIndex = 0;

    //}
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //if (BtnSave1.Text == "Save")
            //{
            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
            this.gvCertificate.DataBind();
            //}

        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {


        }






        //try
        //{
        //    if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
        //    {
        //        //((DataTable)Session["CertificateTb"]).Rows.RemoveAt(e.RowIndex);
        //        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]);
        //        //this.gvCertificate.DataBind();


        //        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

        //        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
        //        this.gvCertificate.DataBind();
        //        //ddlSector.SelectedIndex = 0;
        //        //ddlTrade.SelectedIndex = 0;
        //        //btnAddTrdmpNew.Visible = true;
        //        //BtnTradeUpdate.Visible = false;
        //    }
        //    else
        //    {
        //        if (hdfFlagID0.Value.Trim() != "")
        //        {



        //            //DataSet dsbat = new DataSet();
        //            //dsbat = gen.batchexistswithtrngtrade(trainertradesname, hdfID.Value.ToString());
        //            //if (dsbat.Tables[0].Rows[0][0].ToString() == "0")
        //            //{
        //            //    gen.deleteTCTradeTrainer(trainertradesname, tradestrainneid, hdfID.Value.ToString());
        //            //}
        //            //else
        //            //{
        //            //   lblresult.Text = "Trade already assigned to a batch";
        //            //    return;
        //            //}

        //            try
        //            {
        //                string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
        //                //string traineeids = gvTradeMapping.DataKeys[e.RowIndex].Values["intTraineeID"].ToString();
        //                DataSet dsna = new DataSet();
        //                //dsna = Gen.deleteGroupSavingData1(traineetradesnames);
        //                //if (dsna.Tables[0].Rows.Count > 0)
        //                //{

        //                //    lblmsg.Text = "This Trainee is Already alloted to Batch,So you can't delete this trainee trade";
        //                //}
        //                //else
        //                //{


        //                int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

        //                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
        //                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
        //                this.gvCertificate.DataBind();
        //                //}

        //            }
        //            catch (Exception eee)
        //            { }






        //        }
        //    }
        //    // Added by Srikanth on 20-08-2013 for Page Breakup
        //    //hdnfocus.Value = txtOrganisation.ClientID;
        //}
        //catch (Exception ex)
        //{
        //    lblmsg.Text = "Please enter correct data";// ex.ToString();

        //}
        //finally
        //{
        //}


    }
    protected void gvCertificate0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    //if (BtnSave1.Text == "Save")
        //    //{
        //    ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
        //    this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]);
        //    this.gvCertificate0.DataBind();
        //    //}

        //}
        //catch (Exception ex)
        //{
        //    //  lblresult.Text = ex.ToString();

        //}
        //finally
        //{


        //}





        //try
        //{
        //    if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
        //    {
        //        //((DataTable)Session["CertificateTb"]).Rows.RemoveAt(e.RowIndex);
        //        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]);
        //        //this.gvCertificate.DataBind();


        //        ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);

        //        this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
        //        this.gvCertificate0.DataBind();
        //        //ddlSector.SelectedIndex = 0;
        //        //ddlTrade.SelectedIndex = 0;
        //        //btnAddTrdmpNew.Visible = true;
        //        //BtnTradeUpdate.Visible = false;
        //    }
        //    else
        //    {
        //        if (hdfFlagID0.Value.Trim() != "")
        //        {



        //            //DataSet dsbat = new DataSet();
        //            //dsbat = gen.batchexistswithtrngtrade(trainertradesname, hdfID.Value.ToString());
        //            //if (dsbat.Tables[0].Rows[0][0].ToString() == "0")
        //            //{
        //            //    gen.deleteTCTradeTrainer(trainertradesname, tradestrainneid, hdfID.Value.ToString());
        //            //}
        //            //else
        //            //{
        //            //   lblresult.Text = "Trade already assigned to a batch";
        //            //    return;
        //            //}

        //            try
        //            {
        //                string traineetradesnames = gvCertificate0.DataKeys[e.RowIndex].Values["intLineofActivityRid"].ToString();
        //                //string traineeids = gvTradeMapping.DataKeys[e.RowIndex].Values["intTraineeID"].ToString();
        //                DataSet dsna = new DataSet();
        //                //dsna = Gen.deleteGroupSavingData1(traineetradesnames);
        //                //if (dsna.Tables[0].Rows.Count > 0)
        //                //{

        //                //    lblmsg.Text = "This Trainee is Already alloted to Batch,So you can't delete this trainee trade";
        //                //}
        //                //else
        //                //{


        //                int i1 = Gen.deleteGroupSavingData2(traineetradesnames);

        //                ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
        //                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
        //                this.gvCertificate0.DataBind();
        //                //}

        //            }
        //            catch (Exception eee)
        //            { }






        //        }
        //    }
        //    // Added by Srikanth on 20-08-2013 for Page Breakup
        //    //hdnfocus.Value = txtOrganisation.ClientID;
        //}
        //catch (Exception ex)
        //{
        //    lblmsg.Text = "Please enter correct data";// ex.ToString();

        //}
        //finally
        //{
        //}
    }
    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        //gvCertificate0.Visible = true;
        //try
        //{
        //    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
        //    {
        //        AddDataToTableCeertificate1(Session["Applid"].ToString(),Request.QueryString[0].ToString(),txtitem1.Text, txtquantity1.Text, ddlquantity1.SelectedValue.ToString(),  ddlQuantityper1.SelectedValue.ToString(), txtitem3.Text,(DataTable)Session["CertificateTb1"]);


        //        this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
        //        this.gvCertificate0.DataBind();
        //        gvCertificate0.Columns[0].Visible = false;

        //        gvCertificate0.Columns[6].Visible = false;
        //        //lblmsg.Text = "";
        //        lblmsg.Text = "";
        //        txtitem1.Text = "";
        //        txtquantity1.Text = "";
        //        ddlquantity1.SelectedIndex = 0;
        //        //ddlquantityper1.SelectedIndex = 0;
        //        txtitem3.Text = "";

        //        ddlQuantityper1.SelectedIndex = 0;
        //        //}
        //    }
        //    else
        //        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
        //        {

        //            //gvCertificate.Visible = true;


        //            //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
        //            //siva as on 10-08-2103
        //            // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
        //            AddDataToTableCeertificate1(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem1.Text, txtquantity1.Text, ddlquantity1.SelectedValue.ToString(), ddlQuantityper1.SelectedValue.ToString(), txtitem3.Text, (DataTable)Session["CertificateTb1"]);
        //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
        //            this.gvCertificate0.DataBind();
        //            gvCertificate0.Columns[0].Visible = false;
        //            gvCertificate0.Columns[6].Visible = false;
        //            //clear_child_TOT();
        //            lblmsg.Text = "";
        //            txtitem1.Text = "";
        //            txtquantity1.Text = "";
        //            ddlquantity1.SelectedIndex = 0;
        //            //ddlquantityper1.SelectedIndex = 0;

        //            ddlQuantityper1.SelectedIndex = 0;
        //            txtitem3.Text = "";
        //            //}
        //        }
        //}

        //catch (Exception ee)
        //{
        //    ////lbldtvalid.Text = "Please enter correct Date.";
        //    ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        //}

        //gvCertificate0.Visible = true;


    }
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        //txtitem1.Text = "";
        //txtquantity1.Text = "";
        //ddlquantity1.SelectedIndex = 0;
        //ddlQuantityper1.SelectedIndex = 0;

    }
   
    protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlquantityin.SelectedValue.ToString() == "Others")
        //{
        //    qty.Visible = true;

        //}
        //else
        //{
        //    qty.Visible = false;

        //}

    }
    protected void ddlquantity1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlquantity1.SelectedValue.ToString() == "Others")
        //{
        //    Qty1.Visible = true;
        //}
        //else
        //{
        //    Qty1.Visible = false;
        //}

    }
    protected void BtnSave3_Click1(object sender, EventArgs e)
    {

        string newPath = "";
        string sFileDir = Server.MapPath("~\\IPOPerformance");

        General t1 = new General();
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uidIPO"].ToString() + "\\B1Form");
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

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uidIPO"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uidIPO"].ToString(), "B1 FORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName.Text = FileUpload1.FileName;
                            Label444.Text = FileUpload1.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile1(newPath + "\\" + sFileName);
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
}
