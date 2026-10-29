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
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    int n1;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            if (Session["uid"].ToString() == "17083")
            {
                 

                dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "141");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                    Response.Redirect("https://tsbcl.telangana.gov.in/ts/index.php/site/logineodb?username=" + Session["user_id"].ToString() + "&password=" + Session["password_decrypt"].ToString() + "&approvalid=141");
                }
                dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "142");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                    Response.Redirect("https://tsbcl.telangana.gov.in/ts/index.php/site/logineodb?username=" + Session["user_id"].ToString() + "&password=" + Session["password_decrypt"].ToString() + "&approvalid=142");
                }
                dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "143");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                    Response.Redirect("https://tsbcl.telangana.gov.in/ts/index.php/site/logineodb?username=" + Session["user_id"].ToString() + "&password=" + Session["password_decrypt"].ToString() + "&approvalid=143");
                }
            }

            DataSet ss = new DataSet();
            ss = Gen.GetQuesionaryID(Session["uid"].ToString());
            //hdfFlagID0.Value = .Tables[0].Rows[0][0].ToString();
            if (ss.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = ss.Tables[0].Rows[0][0].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }


            string res = Gen.RetriveStatusCFO(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");


            if (Convert.ToInt32(res) >= 3)
            {

                ResetFormControl(this);

            }
            DataSet ds = new DataSet();
            ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                    FillDetails();
            }
        }



        if (!IsPostBack)
        {
            //Session["Applid"] = "1005";
            //Session["Approvalid"] = "33";
            //Session["Deptid"] = "2";

            DataSet ds = new DataSet();




            ds = Gen.RetriveIsOfflineByAPPIDCFO(Session["Applid"].ToString());
            //ds = Gen.retruvedatabyCFOQuessione(Session["Applid"].ToString());
            //if
            int count = ds.Tables[0].Rows.Count;

            for (int l = 0; l < count; l++)
            {
                string Refno = Gen.RetriveRefNoCFO(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());

                string res = Gen.RetriveIsOfflineCFO(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());


                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "1")
                {
                    ViewState["pcbD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["pcbA"] = ds.Tables[0].Rows[l][1].ToString();
                    CFOPCBref.Visible = true;
                    CFOPCB.Visible = true;
                    
                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        txtPCBRefNo.Text = Refno;

                }


                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "9")
                {

                    //ViewState["TSCTD"] != null && ViewState["TSCTA"] != null
                    ViewState["TSCTD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["TSCTA"] = ds.Tables[0].Rows[l][1].ToString();
                    
                    CFOFactoryref.Visible = true;
                    CFOFactory.Visible = true;
                    //CFOPCBref.Visible = true;
                    //CFOPCB.Visible = true;

                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        txtTSCTRefNo.Text = Refno;
                    if (HyperLink1.Text == "[HyperLink1]")
                    {
                        Button9.Enabled = true;
                        FileUpload11.Enabled = true;
                    }

                }


                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "8")
                {

                    //ViewState["TSCTD"] != null && ViewState["TSCTA"] != null
                    ViewState["SERTSSPDCLD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["SERTSSPDCLA"] = ds.Tables[0].Rows[l][1].ToString();

                    SerTSSPDCL.Visible = true;
                    SerTSSPDCLRef.Visible = true;
                    //CFOPCBref.Visible = true;
                    //CFOPCB.Visible = true;

                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        TextBox6.Text = Refno;

                }

                if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "7")
                {
                    ViewState["SERTSNPDCLD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["SERTSNPDCLA"] = ds.Tables[0].Rows[l][1].ToString();
                    SerTSNPDCLRef.Visible = true;
                    SerTSNPDCL.Visible = true;
                    if (Refno != "")
                        TextBox7.Text = Refno;
                }


                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "14")
                {
                    //ViewState["TSIICD"] != null && ViewState["TSIICA"] != null
                    ViewState["TSIICD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["TSIICA"] = ds.Tables[0].Rows[l][1].ToString();
                    CFOFireref.Visible = true;
                    CFOFire.Visible = true;
                    

                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        TextBox2.Text = Refno;

                }

                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "6")
                {
                    //ViewState["TSIICD"] != null && ViewState["TSIICA"] != null
                   // ViewState["PRDD"] != null && ViewState["PRDA"] != null

                    ViewState["PRDD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["PRDA"] = ds.Tables[0].Rows[l][1].ToString();
                    CFOCEIGref.Visible = true;
                    CFOCEIG.Visible = true;


                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        TextBox3.Text = Refno;

                }

                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "19")
                {
                    
                    ViewState["DISCOMD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["DISCOMA"] = ds.Tables[0].Rows[l][1].ToString();
                    CFODRUG.Visible = true;
                    CFODRUGref.Visible = true;


                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        TextBox4.Text = Refno;

                }

               
                if (res == "N" && ds.Tables[0].Rows[l][0].ToString() == "27")
                {
                    
                    //ViewState["CEIGD"] != null && ViewState["CEIGA"] != null
                    ViewState["CEIGD"] = ds.Tables[0].Rows[l][0].ToString();
                    ViewState["CEIGA"] = ds.Tables[0].Rows[l][1].ToString();
                    CFOBoiler.Visible = true;
                    CFOBoilerref.Visible = true;
                    


                    //Panelpcb1.Visible = true;
                    //Panelpcb.Visible = true;
                    if (Refno != "")
                        TextBox5.Text = Refno;

                }







                //string res = Gen.RetriveCFOPCBbyQues(Session["Applid"].ToString());


                //if (res == "Y")
                //{

                //    CFOPCBref.Visible = true;
                //    CFOPCB.Visible = true;
                //}

                //string res1 = Gen.RetriveCFOPCBbyQuesFactory(Session["Applid"].ToString());

                //if (res1 == "Y")
                //{
                //    CFOFactoryref.Visible = true;
                //    CFOFactory.Visible = true;

                //}

                //string res2 = Gen.RetriveCFOPCBbyQuesHT(Session["Applid"].ToString());
                //if (res2 == "Y")
                //{

                //    CFOCEIGref.Visible = true;
                //    CFOCEIG.Visible = true;


                //}

                //string res3 = Gen.RetriveCFOFirerefQue(Session["Applid"].ToString());

                //if (res3 == "Y")
                //{
                //    CFOFireref.Visible = true;
                //    CFOFire.Visible = true;
                //}

                //string res4 = Gen.RetriveCFODrugQue(Session["Applid"].ToString());

                //if (res4 == "Y")
                //{
                //    CFODRUG.Visible = true;
                //    CFODRUGref.Visible = true;

                //}
                //string res5 = Gen.RetriveCFOBoilersQue(Session["Applid"].ToString());
                //if (res5 == "Y")
                //{

                //    CFOBoilerref.Visible = true;
                //    CFOBoiler.Visible = true;

                //}



            }




            //int count = ds.Tables[0].Rows.Count;

            //for (int l = 0; l < count; l++)
            //{
            //    string Refno = Gen.RetriveRefNo(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());
            //    //string res = Gen.RetriveIsOffline(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());
            //}


        }


        //DataSet ds = new DataSet();
        //ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    if (!IsPostBack)
        //    {
        //        FillDetails();
        //    }

        //}
        Fileuploadinvisble();

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
        if (Label454.Text == "")
        {
            //CFOPCB.Visible = true;
            FileUpload10.Enabled = true;
            Button8.Enabled = true;
            
        }
    }

    public void Fileuploadinvisble()
    {

        if (FileUpload10.Enabled == false)
        {
            FileUpload10.Visible = false;
            Button8.Visible = false;
        }
        else
        {
            FileUpload10.Visible = true;
            Button8.Visible = true;
        }
        if (FileUpload11.Enabled == false)
        {
            FileUpload11.Visible = false;
            Button9.Visible = false;
        }
        else
        {
            FileUpload11.Visible = true;
            Button9.Visible = true;
        }
        if (FileUpload12.Enabled == false)
        {
            FileUpload12.Visible = false;
            Button10.Visible = false;
        }
        else
        {
            FileUpload12.Visible = true;
            Button10.Visible = true;
        }
        if (FileUpload13.Enabled == false)
        {
            FileUpload13.Visible = false;
            Button11.Visible = false;
        }
        else
        {
            FileUpload13.Visible = true;
            Button11.Visible = true;
        }
        if (FileUpload14.Enabled == false)
        {
            FileUpload14.Visible = false;
            Button12.Visible = false;
        }
        else
        {
            FileUpload14.Visible = true;
            Button12.Visible = true;
        }
        if (FileUpload15.Enabled == false)
        {
            FileUpload15.Visible = false;
            Button13.Visible = false;
        }
        else
        {
            FileUpload15.Visible = true;
            Button13.Visible = true;
        }
        if (FileUpload16.Enabled == false)
        {
            FileUpload16.Visible = false;
            Button15.Visible = false;
        }
        else
        {
            FileUpload16.Visible = true;
            Button15.Visible = true;
        }
        if (FileUpload17.Enabled == false)
        {
            FileUpload17.Visible = false;
            Button16.Visible = false;
        }
        else
        {
            FileUpload17.Visible = true;
            Button16.Visible = true;
        }
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

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        lblmsg0.Text = "<font color='red'>Attachments Saved Success..!</font>";
        success.Visible = false;
        Failure.Visible = true;




       
    }

    void clear()
    {

        
       
       
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        
      

    }




    void FillDetails()
    {

        DataSet ds = new DataSet();
        ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            int c = ds.Tables[0].Rows.Count;
            string sen, sen1, sen2, sennew;
            int i = 0;

            while (i < c)
            {
                sen2 = ds.Tables[0].Rows[i][0].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                sennew = ds.Tables[0].Rows[i]["linkview"].ToString();// LINKNEW
                string encpassword = Gen.Encrypt(sennew, "SYSTIME");


              //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                if (sen1.Contains("CFOAttachments"))
                {
                    sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                    if (sen.Contains("CFOPCB"))
                    {
                        //Label453.NavigateUrl = sen;
                        Label453.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label453.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label454.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("CFOFactory"))
                    {
                        //HyperLink1.NavigateUrl = sen;
                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label8.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOFire"))
                    {
                       // HyperLink2.NavigateUrl = sen;
                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label11.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOHT"))
                    {
                       // HyperLink3.NavigateUrl = sen;
                        HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label14.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFODRUG"))
                    {
                       // HyperLink4.NavigateUrl = sen;
                        HyperLink4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label17.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOboilers"))
                    {
                        //HyperLink6.NavigateUrl = sen;
                        HyperLink6.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink6.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label20.Text = ds.Tables[0].Rows[i][1].ToString();
                    }


                    if (sen.Contains("CFOServiceConn"))
                    {
                       // HyperLink7.NavigateUrl = sen;
                        HyperLink7.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink7.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label472.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOServiceConn1"))
                    {
                       // HyperLink8.NavigateUrl = sen;
                        HyperLink8.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink8.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label475.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
                i++;
            }

        }
          
    }    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        
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



    protected void Button8_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
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

                string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOPCB");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    int n1 = 0;
                    if (ViewState["pcbD"] != null && ViewState["pcbA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(txtPCBRefNo.Text, Session["Applid"].ToString(), ViewState["pcbD"].ToString(), ViewState["pcbA"].ToString());

                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFO Polution Control Board", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFO Polution Control Board");
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label453.Text = FileUpload10.FileName;
                        Label454.Text = FileUpload10.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }


    protected void Button9_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
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

                string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOFactory");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    int n1 = 0;
                    if (ViewState["TSCTD"] != null && ViewState["TSCTA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(txtTSCTRefNo.Text, Session["Applid"].ToString(), ViewState["TSCTD"].ToString(), ViewState["TSCTA"].ToString());
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFOFactory", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFOFactory");
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink1.Text = FileUpload11.FileName;
                        Label8.Text = FileUpload11.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload12.PostedFile != null) && (FileUpload12.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload12.PostedFile.FileName);
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

                string[] fileType = FileUpload12.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOFire");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    int n1 = 0;
                    if (ViewState["TSIICD"] != null && ViewState["TSIICA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(TextBox2.Text, Session["Applid"].ToString(), ViewState["TSIICD"].ToString(), ViewState["TSIICA"].ToString());
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFOFire", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFOFire");
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink2.Text = FileUpload12.FileName;
                        Label11.Text = FileUpload12.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

      


    }
  
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
      
    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {

              

            }
            else
            {
               

            }
        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {

        }
    }



    protected void GetNewRectoInsertdr()
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

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
    
   
   
  
  
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmDepartmentApprovalDetailsCFO.aspx");
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
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

                string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOHT");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    if (ViewState["PRDD"] != null && ViewState["PRDA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(TextBox3.Text, Session["Applid"].ToString(), ViewState["PRDD"].ToString(), ViewState["PRDA"].ToString());

                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFOHT", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFOHT");
                    if (result > 0 && n1==0)//ds1.Tables[0].Rows.Count > 0
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink3.Text = FileUpload13.FileName;
                        Label14.Text = FileUpload13.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload14.PostedFile != null) && (FileUpload14.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload14.PostedFile.FileName);
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

                string[] fileType = FileUpload14.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFODRUG");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload14.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload14.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["DISCOMD"] != null && ViewState["DISCOMA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(TextBox4.Text, Session["Applid"].ToString(), ViewState["DISCOMD"].ToString(), ViewState["DISCOMA"].ToString());

                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFODRUG", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFODRUG");

                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink4.Text = FileUpload14.FileName;
                        Label17.Text = FileUpload14.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }

    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload15.PostedFile != null) && (FileUpload15.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload15.PostedFile.FileName);
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

                string[] fileType = FileUpload15.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOboilers");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    if (ViewState["CEIGD"] != null && ViewState["CEIGA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(TextBox5.Text, Session["Applid"].ToString(), ViewState["CEIGD"].ToString(), ViewState["CEIGA"].ToString());
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFOboilers", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFOboilers");
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink6.Text = FileUpload15.FileName;
                        Label20.Text = FileUpload15.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {

        if (CFOPCB.Visible && CFOPCBref.Visible)
        {
            if (Label454.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload PCB Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                FileUpload10.Enabled = true;
                Button8.Enabled = true;
                CFOPCB.Visible = true;
                return;
            }
        }

        if (CFOFactoryref.Visible && CFOFactory.Visible)
        {
            if (Label8.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Factory Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                FileUpload11.Enabled = true;
                Button9.Enabled = true;
                return;
            }
        }

        if (CFOFireref.Visible && CFOFire.Visible)
        {
            if (Label11.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload FIRE Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                FileUpload12.Enabled = true;
                Button10.Enabled = true;
                return;
            }
        }

        //if (CFOCEIGref.Visible && CFOCEIG.Visible)
        //{
        //    if (Label14.Text == "")
        //    {
        //        lblmsg0.Text = "<font color='red'>Please Upload HT Approval Attachment..!</font>";
        //        success.Visible = false;
        //        Failure.Visible = true;
        //        return;
        //    }
        //}



        //if (CFODRUG.Visible && CFODRUGref.Visible)
        //{
        //    if (Label17.Text == "")
        //    {
        //        lblmsg0.Text = "<font color='red'>Please Upload DRUG Approval Attachment..!</font>";
        //        success.Visible = false;
        //        Failure.Visible = true;
        //        return;
        //    }
        //}


        //if (CFOBoilerref.Visible && CFOBoiler.Visible)
        //{
        //    if (Label20.Text == "")
        //    {
        //        lblmsg0.Text = "<font color='red'>Please Upload Boilers Approval Attachment..!</font>";
        //        success.Visible = false;
        //        Failure.Visible = true;
        //        return;
        //    }
        //}


        Response.Redirect("frmCAFEntrepreneurDetails.aspx");

    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload16.PostedFile != null) && (FileUpload16.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload16.PostedFile.FileName);
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

                string[] fileType = FileUpload16.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOServiceConn");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload16.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload16.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    if (ViewState["SERTSSPDCLD"] != null && ViewState["SERTSSPDCLA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(TextBox6.Text, Session["Applid"].ToString(), ViewState["SERTSSPDCLD"].ToString(), ViewState["SERTSSPDCLA"].ToString());
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFOboilers", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFOServiceConn");
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink7.Text = FileUpload16.FileName;
                        Label472.Text = FileUpload16.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }


    }
    protected void Button15_Click(object sender, EventArgs e)
    {

        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload17.PostedFile != null) && (FileUpload17.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload17.PostedFile.FileName);
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

                string[] fileType = FileUpload17.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CFOServiceConn1");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload17.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload17.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    if (ViewState["SERTSNPDCLD"] != null && ViewState["SERTSNPDCLA"] != null)
                        n1 = Gen.UpdateRefferenceNumber1(TextBox6.Text, Session["Applid"].ToString(), ViewState["SERTSNPDCLD"].ToString(), ViewState["SERTSNPDCLA"].ToString());
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CFOboilers", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CFOServiceConn1");

                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink8.Text = FileUpload17.FileName;
                        Label475.Text = FileUpload17.FileName;
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
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }



    }
}
