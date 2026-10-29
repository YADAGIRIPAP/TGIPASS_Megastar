using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Globalization;

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
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    int n1;

    static DataTable dtMyTable;
    Cls_Dharnidata obj_dharani = new Cls_Dharnidata();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        BtnClear0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                //if (Session["uid"].ToString().Trim() != "")
                //{
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    ViewState["intCFEEnterpid"] = dscheck.Tables[2].Rows[0]["intCFEEnterpid"].ToString().Trim();
                    ViewState["Applicationstatus"] = dscheck.Tables[0].Rows[0]["Appl_Status"].ToString().Trim();
                    ViewState["proposalfor"] = dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim();
                    if(dscheck.Tables[6].Rows.Count > 0)
                    {
                        ViewState["PAYMETDATE"] = dscheck.Tables[6].Rows[0]["PAYMENTDATE"].ToString().Trim();

                    }
                    string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                    if (TourismFlag == "Y")
                    {
                        trProcessFlowChart.Visible = false;
                        lblDeed.Text = "Registration/Lease Deed";
                    }
                    else
                    {
                        trProcessFlowChart.Visible = true;
                        lblDeed.Text = "Registration Deed";
                    }
                }
                else
                {
                    Session["Applid"] = "0";
                }


                //obj_dharani.getappliantdharanistatusbyuserid(Convert.ToString(Session["uid"]),
                // Convert.ToString(Session["Applid"]), Request.ServerVariables["Remote_Addr"]);

                string intQuessionaireid = Session["Applid"].ToString();
                bool dharaniredirecturl = false;
                DataTable dt_dharni = obj_dharani.DB_cfe_dharanistageid(Convert.ToString(Session["uid"]), Convert.ToString(Session["Applid"]));
                if (dt_dharni != null)
                {
                    if (dt_dharni.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dt_dharni.Rows[0]["Approvalpresent"])) && Convert.ToInt32(dt_dharni.Rows[0]["Approvalpresent"]) != 0)
                        {
                            obj_dharani.getappliantdharanistatusbyuserid(Convert.ToString(Session["uid"]),
                Convert.ToString(Session["Applid"]), Request.ServerVariables["Remote_Addr"]);
                            //Approvalpresent
                            //DharaniCurrentStageID	intCFEEnterpid	intDeptid	Approvalpresent
                            if (string.IsNullOrEmpty(Convert.ToString(dt_dharni.Rows[0]["DharaniCurrentStageID"])) && string.IsNullOrEmpty(Convert.ToString(dt_dharni.Rows[0]["Curstatusofdharani"])))
                            {
                                if (!string.IsNullOrEmpty(intQuessionaireid) || Convert.ToInt32(intQuessionaireid) != 0)
                                {
                                    obj_dharani.insertredirectdharaniusercfe(Convert.ToString(Session["uid"]));
                                    Response.Redirect("frmDharaniredriect.aspx", false);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(dt_dharni.Rows[0]["DharaniCurrentStageID"]) < 4)
                                {
                                    if (!string.IsNullOrEmpty(intQuessionaireid) && Convert.ToInt32(intQuessionaireid) != 0)
                                    {
                                        obj_dharani.insertredirectdharaniusercfe(Convert.ToString(Session["uid"]));
                                        Response.Redirect("frmDharaniredriect.aspx", false);
                                    }

                                }
                                else
                                {
                                    if (Convert.ToString(dt_dharni.Rows[0]["Curstatusofdharani"]) == "Pending for Payment")
                                    {
                                        if (!string.IsNullOrEmpty(intQuessionaireid) && Convert.ToInt32(intQuessionaireid) != 0)
                                        {
                                            obj_dharani.insertredirectdharaniusercfe(Convert.ToString(Session["uid"]));
                                            Response.Redirect("frmDharaniredriect.aspx", false);
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToString(dt_dharni.Rows[0]["Curstatusofdharani"]) == "Payment completed")
                                        {

                                            if (string.IsNullOrEmpty(Convert.ToString(dt_dharni.Rows[0]["IsNalaSlotBooked"])))
                                            {
                                                if (!string.IsNullOrEmpty(intQuessionaireid) && Convert.ToInt32(intQuessionaireid) != 0)
                                                {
                                                    obj_dharani.insertredirectdharaniusercfe(Convert.ToString(Session["uid"]));
                                                    Response.Redirect("frmDharaniredriect.aspx", false);
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToString(dt_dharni.Rows[0]["IsNalaSlotBooked"]) == "N")
                                                {
                                                    if (!string.IsNullOrEmpty(intQuessionaireid) && Convert.ToInt32(intQuessionaireid) != 0)
                                                    {
                                                        obj_dharani.insertredirectdharaniusercfe(Convert.ToString(Session["uid"]));
                                                        Response.Redirect("frmDharaniredriect.aspx", false);
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }







                DataSet dsver = new DataSet();

                dsver = Gen.Getverifyofque8(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);

                        //FileUpload1.Enabled = false;
                        //FileUpload2.Enabled = false;
                        ////FileUpload3.Enabled = false;
                        //FileUpload5.Enabled = false;
                        //FileUpload4.Enabled = false;
                        //FileUpload6.Enabled = false;
                        //FileUpload7.Enabled = false;
                        //FileUpload8.Enabled = false;
                        //ddlAttachmentType.Enabled = false;
                        //txtOthers.Enabled = false;
                        //FileUpload9.Enabled = false;
                    }

                }
            }
            //}

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = ViewState["intCFEEnterpid"].ToString();//Request.QueryString["intApplicationId"];

                if (!IsPostBack)
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
                ds = Gen.RetriveIsOfflineByAPPID(Session["Applid"].ToString());
                int count = ds.Tables[0].Rows.Count;

                for (int l = 0; l < count; l++)
                {
                    string Refno = Gen.RetriveRefNo(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());
                    string res = Gen.RetriveIsOffline(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());
                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "1")
                    {
                        ViewState["pcbD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["pcbA"] = ds.Tables[0].Rows[l][1].ToString();
                        Panelpcb1.Visible = true;
                        Panelpcb.Visible = true;
                        if (Refno != "")
                            txtPCBRefNo.Text = Refno;

                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "2")
                    {
                        ViewState["TSCTD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["TSCTA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelTSCT.Visible = true;
                        panelTSCT1.Visible = true;
                        if (Refno != "")
                            txtTSCTRefNo.Text = Refno;

                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "3")
                    {
                        ViewState["TSIICD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["TSIICA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelTSIIC.Visible = true;
                        panelTSIIC1.Visible = true;
                        if (Refno != "")
                            TextBox2.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "4")
                    {
                        ViewState["PRDD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["PRDA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelPRD.Visible = true;
                        panelPRD1.Visible = true;
                        if (Refno != "")
                            TextBox3.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "5")
                    {
                        ViewState["DISCOMD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["DISCOMA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelDISCOM.Visible = true;
                        panelDISCOM1.Visible = true;
                        if (Refno != "")
                            TextBox4.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "6")
                    {
                        ViewState["CEIGD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["CEIGA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelCEIG.Visible = true;
                        panelCEIG1.Visible = true;
                        if (Refno != "")
                            TextBox5.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "7")
                    {
                        ViewState["TSNPDCLD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["TSNPDCLA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelTSNPDCL.Visible = true;
                        panelTSNPDCL1.Visible = true;
                        if (Refno != "")
                            TextBox6.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "8")
                    {
                        ViewState["TSSPDCLD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["TSSPDCLA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelTSSPDCL.Visible = true;
                        panelTSSPDCL1.Visible = true;
                        if (Refno != "")
                            TextBox7.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "9")
                    {
                        ViewState["FACTD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["FACTA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelFACT.Visible = true;
                        panelFACT1.Visible = true;
                        if (Refno != "")
                            TextBox8.Text = Refno;
                    }

                    //if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "10")
                    //{
                    //    panelINDUS.Visible = true;
                    //    panelINDUS1.Visible = true;
                    //}

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "11")
                    {
                        ViewState["HMDAD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["HMDAA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelHMDA.Visible = true;
                        panelHMDA1.Visible = true;
                        if (Refno != "")
                            TextBox10.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "12")
                    {
                        ViewState["CCLAD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["CCLAA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelCCLA.Visible = true;
                        panelCCLA1.Visible = true;
                        if (Refno != "")
                            TextBox11.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "13")
                    {
                        ViewState["DTCPD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["DTCPA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelDTCP.Visible = true;
                        panelDTCP1.Visible = true;
                        if (Refno != "")
                            TextBox12.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "14")
                    {
                        ViewState["FIRED"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["FIREA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelFIRE.Visible = true;
                        panelFIRE1.Visible = true;
                        if (Refno != "")
                            TextBox13.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "15")
                    {
                        ViewState["GWD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["GWA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelGW.Visible = true;
                        panelGW1.Visible = true;
                        if (Refno != "")
                            TextBox14.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "16")
                    {
                        ViewState["HMWSSBD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["HMWSSBA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelHMWSSB.Visible = true;
                        panelHMWSSB1.Visible = true;
                        if (Refno != "")
                            TextBox15.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "17")
                    {
                        ViewState["EXCISED"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["EXCISEA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelEXCISE.Visible = true;
                        panelEXCISE1.Visible = true;
                        if (Refno != "")
                            TextBox16.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "18")
                    {
                        ViewState["REGSTAMPD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["REGSTAMPA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelREGSTAMP.Visible = true;
                        panelREGSTAMP1.Visible = true;
                        if (Refno != "")
                            TextBox17.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "19")
                    {
                        ViewState["DCAD"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["DCAA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelDCA.Visible = true;
                        panelDCA1.Visible = true;
                        if (Refno != "")
                            TextBox18.Text = Refno;
                    }

                    if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "20")
                    {
                        ViewState["IRRIGATIOND"] = ds.Tables[0].Rows[l][0].ToString();
                        ViewState["IRRIGATIONA"] = ds.Tables[0].Rows[l][1].ToString();
                        panelIRRIGATION.Visible = true;
                        panelIRRIGATION1.Visible = true;
                        if (Refno != "")
                            TextBox19.Text = Refno;
                    }
                }

            }

            if (!IsPostBack)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb"] = dtMyTableCertificate;
                //  Session["uid"] = "1000";
            }

            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }
            Fileuploadinvisble();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void Fileuploadinvisble()
    {

        if (FileUpload1.Enabled == false)
        {
            FileUpload1.Visible = false;
            BtnSave3.Visible = false;
        }
        else
        {
            FileUpload1.Visible = true;
            BtnSave3.Visible = true;
        }

        if (FileUpload2.Enabled == false)
        {
            FileUpload2.Visible = false;
            Button1.Visible = false;
        }
        else
        {
            FileUpload2.Visible = true;
            Button1.Visible = true;
        }

        if (Label446.Text != "")
        {
            if (FileUpload3.Enabled == false)
            {
                FileUpload3.Visible = false;
                Button2.Visible = false;
            }
        }
        else
        {
            FileUpload3.Visible = true;
            Button2.Visible = true;
            FileUpload3.Enabled = true;
        }

        if (FileUpload5.Enabled == false)
        {
            FileUpload5.Visible = false;
            Button4.Visible = false;
        }
        else
        {
            FileUpload5.Visible = true;
            Button4.Visible = true;
        }

        if (FileUpload4.Enabled == false)
        {
            FileUpload4.Visible = false;
            Button3.Visible = false;
        }
        else
        {
            FileUpload4.Visible = true;
            Button3.Visible = true;
        }

        if (FileUpload6.Enabled == false)
        {
            FileUpload6.Visible = false;
            BtnSave4.Visible = false;
        }
        else
        {
            FileUpload6.Visible = true;
            BtnSave4.Visible = true;
        }
        if (FileUpload7.Enabled == false)
        {
            FileUpload7.Visible = false;
            Button5.Visible = false;
        }
        else
        {
            FileUpload7.Visible = true;
            Button5.Visible = true;
        }

        if (FileUpload8.Enabled == false)
        {
            FileUpload8.Visible = false;
            Button6.Visible = false;
        }
        else
        {
            FileUpload8.Visible = true;
            Button6.Visible = true;
        }
        if (fupdeetack.Enabled == false)
        {
            fupdeetack.Visible = false;
            BTNDEETACK.Visible = false;
        }
        else
        {
            fupdeetack.Visible = true;
            BTNDEETACK.Visible = true;
        }
        if (ViewState["Applicationstatus"].ToString() == "3" && DateTime.ParseExact(ViewState["PAYMETDATE"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("12-12-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture))
        {
            TRDEET.Visible = false;
            TRDEETDESCRIPTION.Visible = false;
        }
        else
        {
            TRDEET.Visible = true;
            TRDEETDESCRIPTION.Visible = true;

        }
    }
    public void ResetFormControl(Control parent)
    {
        try
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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

        Response.Redirect("frmprofessiontax.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
        // Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
        // Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }
    void FillDetails()
    {
        // hdfFlagID.Value = "1000";
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, senPlanB, sennew;
                int i = 0;


                DataTable dt1 = new DataTable();
                dt1.Columns.Add("link");
                dt1.Columns.Add("FileName");
                dt1.Columns.Add("LINKNEW");
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("link");
                dt2.Columns.Add("FileName");
                dt2.Columns.Add("LINKNEW");
                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = ds.Tables[0].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    //if (sen1.Contains("D:/TS-iPASSFinal"))
                    //{
                    //    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    //}
                    //else if (sen1.Contains("G:/TS-iPASSFinal"))
                    //{
                    //    sen = sen1.Replace(@"G:/TS-iPASSFinal/", "~/");
                    //}
                    if (sen.Contains("SelfCertificationForm"))
                    {
                        lblFileName.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;

                        lblFileName.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label444.Text = ds.Tables[0].Rows[i][1].ToString();
                        //DocumentPath(sennew);
                        // DocumentPath(@"G:\TS-iPASSFinal\Attachments\117178\PANorAADHAAR\adhar card & Pan Card.pdf");
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("RegistrationDeed"))
                    {
                        Label1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label1.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label445.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink2.NavigateUrl = sen;
                        //HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("Mutation order"))
                    {
                        Label2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label2.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label446.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink3.NavigateUrl = sen;
                        //HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    //if (sen.Contains("Combinedbuildingplan"))
                    //{
                    //    Label4.NavigateUrl = sen;
                    //    Label4.Text = ds.Tables[0].Rows[i][1].ToString();
                    //    Label447.Text = ds.Tables[0].Rows[i][1].ToString();
                    //    //HyperLink4.NavigateUrl = sen;
                    //    //HyperLink4.Text = 
                    //}

                    //if (sen.Contains("Combinedsiteplan"))
                    //{
                    //    Label3.NavigateUrl = sen;
                    //    Label3.Text = ds.Tables[0].Rows[i][1].ToString();
                    //    Label448.Text = ds.Tables[0].Rows[i][1].ToString();
                    //    //HyperLink5.NavigateUrl = sen;
                    //    //HyperLink5.Text = 
                    //}

                    if (sen.Contains("Combinedbuildingplan"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();
                        string lastfour = senPlanB.Substring(senPlanB.Length - 4);
                        DataRow _row = dt1.NewRow();
                        if (lastfour.ToUpper() == ".DWG")
                        {
                            _row["link"] = sen;
                            _row["FileName"] = senPlanB;
                            _row["LINKNEW"] = sennew;
                            dt1.Rows.Add(_row);
                        }
                        else
                        {
                            _row["link"] = "CS.aspx?filepathnew=" + encpassword;// sen;
                            _row["FileName"] = senPlanB;
                            _row["LINKNEW"] = sennew;
                            dt1.Rows.Add(_row);
                        }


                        Session["CertificateTb1"] = null;
                        Session["CertificateTb1"] = dt1;
                        this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gvUpload4.DataBind();

                        //Button4.Visible = false;
                        // lnkupload4.Visible = true;

                    }

                    if (sen.Contains("Combinedsiteplan"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt2.NewRow();
                        //_row["link"] = sen;
                        //_row["FileName"] = senPlanB;
                        //dt2.Rows.Add(_row);
                        _row["link"] = "CS.aspx?filepathnew=" + encpassword;// sen;
                        _row["FileName"] = senPlanB;
                        _row["LINKNEW"] = sennew;
                        dt2.Rows.Add(_row);

                        Session["CertificateTb2"] = null;
                        Session["CertificateTb2"] = dt2;
                        this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvUpload5.DataBind();
                    }

                    if (sen.Contains("PartnershipdetailsorArticlesofAssociation"))
                    {
                        lblFileName0.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblFileName0.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label449.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink6.NavigateUrl = sen;
                        //HyperLink6.Text = 
                    }

                    if (sen.Contains("ProcessFlowChart"))
                    {
                        Label438.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label438.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label450.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink7.NavigateUrl = sen;
                        //HyperLink7.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("PANorAADHAAR"))
                    {
                        Label440.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label440.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label451.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }
                    if (sen.Contains("DEETREGACKNOWLEDGEMENT"))
                    {
                        hypdeetack.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hypdeetack.Text = ds.Tables[0].Rows[i][1].ToString();
                        lbldeetack.Text = ds.Tables[0].Rows[i][1].ToString();
                        
                    }
                    if (sen.Contains("Document"))
                    {
                        Label5.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label5.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink9.NavigateUrl = sen;
                        //HyperLink9.Text = 
                        gvCertificate.Visible = true;
                        DataSet ds1 = new DataSet();
                        ds1 = Gen.GetAdditonalAttachmets(hdfFlagID0.Value.ToString());
                        this.gvCertificate.DataSource = ds1.Tables[0];
                        this.gvCertificate.DataBind();
                    }

                    if (sen.Contains("PCB"))
                    {
                        Label453.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        Label453.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label454.Text = ds.Tables[0].Rows[i][1].ToString();

                        //    txtPCBRefNo.Enabled = false;
                        //   FileUpload10.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("CommercialTaxes"))
                    {

                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label8.Text = ds.Tables[0].Rows[i][1].ToString();

                        //  txtTSCTRefNo.Enabled = false;
                        //  FileUpload11.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }


                    if (sen.Contains("TSIIC"))
                    {

                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label11.Text = ds.Tables[0].Rows[i][1].ToString();
                        //   TextBox2.Enabled = false;
                        //  FileUpload12.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("PanchayatRaj"))
                    {

                        HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label14.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //  TextBox3.Enabled = false;

                        // FileUpload13.Enabled = false;

                    }

                    if (sen.Contains("DISCOM"))
                    {

                        HyperLink4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label17.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //   TextBox4.Enabled = false;
                        //   FileUpload14.Enabled = false;

                    }

                    if (sen.Contains("ElectricalInspectorate"))
                    {

                        HyperLink5.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink5.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label20.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox5.Enabled = false;
                        //FileUpload15.Enabled = false;
                    }

                    if (sen.Contains("TSNPDCL"))
                    {

                        HyperLink6.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink6.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label23.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox6.Enabled = false;
                        //FileUpload16.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("TSSPDCL"))
                    {

                        HyperLink7.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink7.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label26.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox7.Enabled = false;
                        //FileUpload17.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("Factories"))
                    {

                        HyperLink8.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink8.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label29.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox8.Enabled = false;
                        //FileUpload18.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("HMDA"))
                    {

                        HyperLink10.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink10.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label35.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox10.Enabled = false;
                        //FileUpload20.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("CCLA"))
                    {

                        HyperLink11.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink11.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label38.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox11.Enabled = false;
                        //FileUpload21.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("DistrictTownandCountryPlanning"))
                    {

                        HyperLink12.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink12.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label41.Text = ds.Tables[0].Rows[i][1].ToString();

                        //TextBox12.Enabled = false;
                        //FileUpload22.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("Fire"))
                    {

                        HyperLink13.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink13.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label44.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox13.Enabled = false;
                        //FileUpload23.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("GroundWater"))
                    {

                        HyperLink14.NavigateUrl = sen;
                        HyperLink14.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label47.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox14.Enabled = false;
                        //FileUpload24.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("HMWSSB"))
                    {

                        HyperLink15.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink15.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label50.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox15.Enabled = false;
                        //FileUpload25.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("Excise Department"))
                    {

                        HyperLink16.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink16.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label53.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox16.Enabled = false;
                        //FileUpload26.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("RegistrationsandStamps"))
                    {

                        HyperLink17.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink17.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label56.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox17.Enabled = false;
                        //FileUpload27.Enabled = false;
                    }

                    if (sen.Contains("DrugsControlAdministration"))
                    {

                        HyperLink18.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink18.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label59.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox18.Enabled = false;
                        //FileUpload28.Enabled = false;
                    }

                    if (sen.Contains("Irrigation"))
                    {

                        HyperLink19.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink19.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label62.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox19.Enabled = false;
                        //FileUpload29.Enabled = false;
                    }

                    i++;
                }
                gvCertificate.Visible = true;
                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                this.gvCertificate.DataBind();

            }


        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        finally
        {

        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

        if (Panelpcb1.Visible && Panelpcb.Visible)
        {
            if (Label454.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload PCB Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelTSCT.Visible && panelTSCT1.Visible)
        {
            if (Label8.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload CommercialTaxes Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelTSIIC.Visible && panelTSIIC1.Visible)
        {
            if (Label11.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload TSIIC Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelPRD.Visible && panelPRD1.Visible)
        {
            if (Label14.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload PanchayatRaj Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelDISCOM.Visible && panelDISCOM1.Visible)
        {
            if (Label17.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload DISCOM Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }


        if (panelCEIG.Visible && panelCEIG1.Visible)
        {

            if (Label20.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload  Electrical Inspectorate Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelTSNPDCL.Visible && panelTSNPDCL1.Visible)
        {

            if (Label23.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload TSNPDCL Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelTSSPDCL.Visible && panelTSSPDCL1.Visible)
        {

            if (Label26.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload  TSSPDCL Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelFACT.Visible && panelFACT1.Visible)
        {

            if (Label29.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Factories Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelHMDA.Visible && panelHMDA1.Visible)
        {

            if (Label35.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload HMDA Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelCCLA.Visible && panelCCLA1.Visible)
        {

            if (Label38.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload CCLA Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelDTCP.Visible && panelDTCP1.Visible)
        {

            if (Label41.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload District Town and Country Planning Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }


        if (panelFIRE.Visible && panelFIRE1.Visible)
        {
            if (Label44.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Fire Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }



        if (panelGW.Visible && panelGW1.Visible)
        {

            if (Label47.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Ground Water Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }


        if (panelHMWSSB.Visible && panelHMWSSB1.Visible)
        {

            if (Label50.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload HMWSSB Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }


        if (panelEXCISE.Visible && panelEXCISE1.Visible)
        {

            if (Label53.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Excise Department Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }


        if (panelREGSTAMP.Visible && panelREGSTAMP1.Visible)
        {

            if (Label56.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Registrations and Stamps Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelDCA.Visible && panelDCA1.Visible)
        {

            if (Label59.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Drugs Control Administration Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (panelIRRIGATION.Visible && panelIRRIGATION1.Visible)
        {

            if (Label62.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Irrigation Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (Label444.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Self Certification Form..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            FileUpload1.Visible = true;
            FileUpload1.Enabled = true;
            BtnSave3.Visible = true;
            BtnSave3.Enabled = true;
            return;
        }
        if (Label445.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Registration Deed..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label446.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Mutation Order..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            FileUpload3.Enabled = true;
            return;
        }
        //if (Label447.Text == "")
        if (gvUpload4.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Combined Building Plan including all floor plans..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        //if (Label448.Text == "")
        if (gvUpload5.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Combined Site Plan..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label449.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Partnershipdetails (or) Articles Of Association(AOA)..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label450.Text == "" && trProcessFlowChart.Visible)//lavanya Tourism
        {
            lblmsg0.Text = "<font color='red'>Please Upload Process Flow Chart..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label451.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload PAN/ Aadhar..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (ViewState["Applicationstatus"].ToString() == "2" && ViewState["proposalfor"].ToString() == "New")
        {
            if (lbldeetack.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload DEET Registration Acknowledgement..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (lblFileName.Text != "" && lblFileName0.Text != "" && Label1.Text != "" && Label2.Text != "" && Label440.Text != "")
        {

            Response.Redirect("frmDepartmentApprovalPaymentDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        }
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
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

            General t1 = new General();
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    if (FileUpload1.PostedFile.FileName.Contains("'") == true || FileUpload1.PostedFile.FileName.Contains("/") == true
                        || FileUpload1.PostedFile.FileName.Contains("*") == true || FileUpload1.PostedFile.FileName.Contains("$") == true
                        || FileUpload1.PostedFile.FileName.Contains("^") == true || FileUpload1.PostedFile.FileName.Contains("#") == true
                        || FileUpload1.PostedFile.FileName.Contains("&") == true)
                    {
                        lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\SelfCertificationForm");

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
                            result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Self Certification Form", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                if (FileUpload2.PostedFile.FileName.Contains("'") == true || FileUpload2.PostedFile.FileName.Contains("/") == true
                        || FileUpload2.PostedFile.FileName.Contains("*") == true || FileUpload2.PostedFile.FileName.Contains("$") == true
                        || FileUpload2.PostedFile.FileName.Contains("^") == true || FileUpload2.PostedFile.FileName.Contains("#") == true
                        || FileUpload2.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                // Restrict special characters and filenames starting with "auth"
                //if (System.Text.RegularExpressions.Regex.IsMatch(sFileName, @"[^a-zA-Z0-9._-]"))
                //{
                //    lblmsg0.Text = "<font color='red'>Filename contains special characters. Only alphanumeric characters, dots, underscores, and hyphens are allowed.</font>";
                //    success.Visible = false;
                //    Failure.Visible = true;
                //    return;
                //}
                if (System.Text.RegularExpressions.Regex.IsMatch(sFileName, @"[^a-zA-Z0-9._\s-]"))
                {
                    lblmsg0.Text = "<font color='red'>Filename contains special characters. Only alphanumeric characters, spaces, dots, underscores, and hyphens are allowed.</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (sFileName.ToLower().Contains("auth"))
                {
                    lblmsg0.Text = "<font color='red'>Filename cannot contain the word 'auth'.</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                try
                {
                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\RegistrationDeed");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Registration Deed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label1.Text = FileUpload2.FileName;
                            Label445.Text = FileUpload2.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {
                if (FileUpload3.PostedFile.FileName.Contains("'") == true || FileUpload3.PostedFile.FileName.Contains("/") == true
                        || FileUpload3.PostedFile.FileName.Contains("*") == true || FileUpload3.PostedFile.FileName.Contains("$") == true
                        || FileUpload3.PostedFile.FileName.Contains("^") == true || FileUpload3.PostedFile.FileName.Contains("#") == true
                        || FileUpload3.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
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

                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Mutation order");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label2.Text = FileUpload3.FileName;
                            Label446.Text = FileUpload3.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    //protected void Button4_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //    //string sFileDir = "~\\TenderNotice";
    //     string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

    //    General t1 = new General();
    //    if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
    //    {
    //        //determine file name
    //        string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
    //        try
    //        {
    //            //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
    //            //{
    //            //    //Save File on disk


    //            //if (FileUpload1.FileContent.Length > 102400 * 18)
    //            //{
    //            //     lblmsg0.Text = "size should be less than 600KB";
    //            //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
    //            //    return;
    //            //}

    //            string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
    //            int i = fileType.Length;
    //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
    //            {
    //                //Create a new subfolder under the current active folder
    //                newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Combinedbuildingplan");

    //                // Create the subfolder
    //                if (!Directory.Exists(newPath))

    //                    System.IO.Directory.CreateDirectory(newPath);
    //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                int count = dir.GetFiles().Length;
    //                if (count == 0)
    //                    FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                else
    //                {
    //                    if (count == 1)
    //                    {
    //                        string[] Files = Directory.GetFiles(newPath);

    //                        foreach (string file in Files)
    //                        {
    //                            File.Delete(file);
    //                        }
    //                        FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    }
    //                }

    //                int result = 0;
    //                result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined building plan including all floor plans ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //                if (result > 0)
    //                {
    //                    //ResetFormControl(this);
    //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                    Label4.Text = FileUpload5.FileName;
    //                    Label447.Text = FileUpload5.FileName;
    //                    success.Visible = true;
    //                    Failure.Visible = false;
    //                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                    //fillNews(userid);
    //                }
    //                else
    //                {
    //                    lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                }

    //            }
    //            else
    //            {
    //                lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
    //                success.Visible = false;
    //                Failure.Visible = true;
    //                //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
    //            }
    //        }
    //        catch (Exception)//in case of an error
    //        {
    //            //lblError.Visible = true;
    //            //lblError.Text = "An Error Occured. Please Try Again!";
    //            DeleteFile(newPath + "\\" + sFileName);
    //            // DeleteFile(sFileDir + sFileName);
    //        }
    //    }
    //}
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //    //string sFileDir = "~\\TenderNotice";
    //     string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

    //    General t1 = new General();
    //    if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
    //    {
    //        //determine file name
    //        string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
    //        try
    //        {
    //            //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
    //            //{
    //            //    //Save File on disk


    //            //if (FileUpload1.FileContent.Length > 102400 * 18)
    //            //{
    //            //     lblmsg0.Text = "size should be less than 600KB";
    //            //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
    //            //    return;
    //            //}

    //            string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
    //            int i = fileType.Length;
    //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
    //            {
    //                //Create a new subfolder under the current active folder
    //                newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Combinedsiteplan");

    //                // Create the subfolder
    //                if (!Directory.Exists(newPath))

    //                    System.IO.Directory.CreateDirectory(newPath);
    //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                int count = dir.GetFiles().Length;
    //                if (count == 0)
    //                    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                else
    //                {
    //                    if (count == 1)
    //                    {
    //                        string[] Files = Directory.GetFiles(newPath);

    //                        foreach (string file in Files)
    //                        {
    //                            File.Delete(file);
    //                        }
    //                        FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    }
    //                }

    //                int result = 0;
    //                result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //                if (result > 0)
    //                {
    //                    //ResetFormControl(this);
    //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                    Label3.Text = FileUpload4.FileName;
    //                    Label448.Text = FileUpload4.FileName;
    //                    success.Visible = true;
    //                    Failure.Visible = false;
    //                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                    //fillNews(userid);
    //                }
    //                else
    //                {
    //                    lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                }

    //            }
    //            else
    //            {
    //                lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
    //                success.Visible = false;
    //                Failure.Visible = true;
    //                //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
    //            }
    //        }
    //        catch (Exception)//in case of an error
    //        {
    //            //lblError.Visible = true;
    //            //lblError.Text = "An Error Occured. Please Try Again!";
    //            DeleteFile(newPath + "\\" + sFileName);
    //            // DeleteFile(sFileDir + sFileName);
    //        }
    //    }
    //}


    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
            {
                if (FileUpload5.PostedFile.FileName.Contains("'") == true || FileUpload5.PostedFile.FileName.Contains("/") == true
                        || FileUpload5.PostedFile.FileName.Contains("*") == true || FileUpload5.PostedFile.FileName.Contains("$") == true
                        || FileUpload5.PostedFile.FileName.Contains("^") == true || FileUpload5.PostedFile.FileName.Contains("#") == true
                        || FileUpload5.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Combinedbuildingplan");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);

                        int count = dir.GetFiles().Length;
                        int result = 0;
                        if (count == 0)
                        {
                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined building plan including all floor plans ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        }
                        else
                        {
                            if (count > 0)
                            {
                                string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload5.FileName);
                                string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload5.FileName);

                                FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                                string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                                FileUpload5.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                                result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Combined building plan including all floor plans ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            }
                        }
                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label4.Text = FileUpload5.FileName;
                            Label447.Text = FileUpload5.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            FillDetails();
                            //lnkupload4.Visible = true;
                            //Button4.Visible = false;

                            //DataSet ds = new DataSet();
                            //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

                            //if (ds.Tables[4].Rows.Count > 0)
                            //{
                            //    int c = ds.Tables[4].Rows.Count;
                            //    string sen1, sen2, sen3, sen4;
                            //    int j = 0;

                            //    while (j < c)
                            //    {
                            //        sen1 = ds.Tables[4].Rows[j][0].ToString();

                            //        if (sen1.Contains("Combinedbuildingplan"))
                            //        {
                            //            sen3 = sen1.Replace(@"\", @"/");
                            //            sen4 = sen3.Replace(@"D:/TS-iPASSFinal/", "~/");
                            //            sen2 = ds.Tables[4].Rows[j][1].ToString();

                            //            DataTable dt = new DataTable();
                            //            dt.Clear();
                            //            dt.Columns.Add("link");
                            //            dt.Columns.Add("FileName");
                            //            DataRow _row = dt.NewRow();
                            //            _row["link"] = sen4;
                            //            _row["FileName"] = sen2;
                            //            dt.Rows.Add(_row);

                            //            Session["CertificateTb1"] = null;
                            //            Session["CertificateTb1"] = dt;
                            //            this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                            //            this.gvUpload4.DataBind();
                            //        }
                            //    }
                            //}
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
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(Failure);
                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
            {
                if (FileUpload4.PostedFile.FileName.Contains("'") == true || FileUpload4.PostedFile.FileName.Contains("/") == true
                        || FileUpload4.PostedFile.FileName.Contains("*") == true || FileUpload4.PostedFile.FileName.Contains("$") == true
                        || FileUpload4.PostedFile.FileName.Contains("^") == true || FileUpload4.PostedFile.FileName.Contains("#") == true
                        || FileUpload4.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
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

                    string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Combinedsiteplan");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        //int count = dir.GetFiles().Length;
                        //if (count == 0)
                        //    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);

                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        int count = dir.GetFiles().Length;
                        int result = 0;
                        if (count == 0)
                        {
                            FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        }
                        else
                        {
                            if (count > 0)
                            {
                                string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload4.FileName);
                                string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload4.FileName);

                                FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                                string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                                result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            }
                        }

                        //int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label3.Text = FileUpload4.FileName;
                            Label448.Text = FileUpload4.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            //SetFocus(success);
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                            FillDetails();
                            //DataSet ds = new DataSet();
                            //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

                            //if (ds.Tables[5].Rows.Count > 0)
                            //{
                            //    int c = ds.Tables[5].Rows.Count;
                            //    string sen1, sen2, sen3, sen4;
                            //    int j = 0;

                            //    while (j < c)
                            //    {
                            //        sen1 = ds.Tables[5].Rows[j][0].ToString();

                            //        if (sen1.Contains("Combinedsiteplan"))
                            //        {
                            //            sen3 = sen1.Replace(@"\", @"/");
                            //            sen4 = sen3.Replace(@"D:/TS-iPASSFinal/", "~/");
                            //            sen2 = ds.Tables[5].Rows[j][1].ToString();

                            //            DataTable dt = new DataTable();
                            //            dt.Clear();
                            //            dt.Columns.Add("link");
                            //            dt.Columns.Add("FileName");
                            //            DataRow _row = dt.NewRow();
                            //            _row["link"] = sen4;
                            //            _row["FileName"] = sen2;
                            //            dt.Rows.Add(_row);

                            //            Session["CertificateTb1"] = null;
                            //            Session["CertificateTb1"] = dt;
                            //            this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                            //            this.gvUpload5.DataBind();
                            //        }
                            //    }
                            //}

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            SetFocus(Failure);
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(Failure);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
            {
                if (FileUpload6.PostedFile.FileName.Contains("'") == true || FileUpload6.PostedFile.FileName.Contains("/") == true
                        || FileUpload6.PostedFile.FileName.Contains("*") == true || FileUpload6.PostedFile.FileName.Contains("$") == true
                        || FileUpload6.PostedFile.FileName.Contains("^") == true || FileUpload6.PostedFile.FileName.Contains("#") == true
                        || FileUpload6.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
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

                    string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\PartnershipdetailsorArticlesofAssociation");

                        // Create the subfolder
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

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Partnership Deed (or) Articles of Association (AOA)", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName0.Text = FileUpload6.FileName;
                            Label449.Text = FileUpload6.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload7.PostedFile != null) && (FileUpload7.PostedFile.ContentLength > 0))
            {
                if (FileUpload7.PostedFile.FileName.Contains("'") == true || FileUpload7.PostedFile.FileName.Contains("/") == true
                        || FileUpload7.PostedFile.FileName.Contains("*") == true || FileUpload7.PostedFile.FileName.Contains("$") == true
                        || FileUpload7.PostedFile.FileName.Contains("^") == true || FileUpload7.PostedFile.FileName.Contains("#") == true
                        || FileUpload7.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload7.PostedFile.FileName);
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

                    string[] fileType = FileUpload7.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\ProcessFlowChart");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload7.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload7.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Process Flow Chart", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label438.Text = FileUpload7.FileName;
                            Label450.Text = FileUpload7.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload8.PostedFile != null) && (FileUpload8.PostedFile.ContentLength > 0))
            {
                if (FileUpload8.PostedFile.FileName.Contains("'") == true || FileUpload8.PostedFile.FileName.Contains("/") == true
                        || FileUpload8.PostedFile.FileName.Contains("*") == true || FileUpload8.PostedFile.FileName.Contains("$") == true
                        || FileUpload8.PostedFile.FileName.Contains("^") == true || FileUpload8.PostedFile.FileName.Contains("#") == true
                        || FileUpload8.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload8.PostedFile.FileName);
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

                    string[] fileType = FileUpload8.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\PANorAADHAAR");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload8.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload8.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }


                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "PAN / AADHAAR", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label440.Text = FileUpload8.FileName;
                            Label451.Text = FileUpload8.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
        //dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
        // dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        //  dtMyTable.Columns.Add("Created_by", typeof(string));

        //   dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


        return dtMyTable;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload9.PostedFile != null) && (FileUpload9.PostedFile.ContentLength > 0))
            {
                if (FileUpload9.PostedFile.FileName.Contains("'") == true || FileUpload9.PostedFile.FileName.Contains("/") == true
                       || FileUpload9.PostedFile.FileName.Contains("*") == true || FileUpload9.PostedFile.FileName.Contains("$") == true
                       || FileUpload9.PostedFile.FileName.Contains("^") == true || FileUpload9.PostedFile.FileName.Contains("#") == true
                       || FileUpload9.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload9.PostedFile.FileName);
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

                    string[] fileType = FileUpload9.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Document");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        //int count = dir.GetFiles().Length;
                        //if (count == 0)
                        //    FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);
                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}
                        FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        int result = 0;
                        gvCertificate.Visible = true;
                        string other;
                        if (txtOthers.Text == "" || txtOthers.Text == null)
                            other = ddlAttachmentType.SelectedItem.Text;
                        else
                            other = txtOthers.Text;
                        AddDataToTableCeertificate(other, "", sFileName, (DataTable)Session["CertificateTb"]);

                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //   result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, other, "b", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label5.Text = FileUpload9.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void FileUpload1_Load(object sender, EventArgs e)
    {

    }

    protected void txtcontact6_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlAttachmentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAttachmentType.SelectedIndex == 11)
        {
            txtOthers.Visible = true;
        }
        else
        {
            txtOthers.Visible = false;
        }
    }

    private void AddDataToTableCeertificate(string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb");

            //  Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["Manf_ItemName"] = Manf_ItemName;
            //Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            //    Row["Created_by"] = Session["uid"].ToString().Trim();
            //   Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {

    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
            {
                if (FileUpload10.PostedFile.FileName.Contains("'") == true || FileUpload10.PostedFile.FileName.Contains("/") == true
                      || FileUpload10.PostedFile.FileName.Contains("*") == true || FileUpload10.PostedFile.FileName.Contains("$") == true
                      || FileUpload10.PostedFile.FileName.Contains("^") == true || FileUpload10.PostedFile.FileName.Contains("#") == true
                      || FileUpload10.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\PCB");

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
                            n1 = Gen.UpdateRefferenceNumber(txtPCBRefNo.Text, Session["Applid"].ToString(), ViewState["pcbD"].ToString(), ViewState["pcbA"].ToString());

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Polution Control Board", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
            {
                if (FileUpload11.PostedFile.FileName.Contains("'") == true || FileUpload11.PostedFile.FileName.Contains("/") == true
                      || FileUpload11.PostedFile.FileName.Contains("*") == true || FileUpload11.PostedFile.FileName.Contains("$") == true
                      || FileUpload11.PostedFile.FileName.Contains("^") == true || FileUpload11.PostedFile.FileName.Contains("#") == true
                      || FileUpload11.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\CommercialTaxes");

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
                        if (ViewState["TSCTD"] != null && ViewState["TSCTA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(txtTSCTRefNo.Text, Session["Applid"].ToString(), ViewState["TSCTD"].ToString(), ViewState["TSCTA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommercialTaxes", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload12.PostedFile != null) && (FileUpload12.PostedFile.ContentLength > 0))
            {
                if (FileUpload12.PostedFile.FileName.Contains("'") == true || FileUpload12.PostedFile.FileName.Contains("/") == true
                      || FileUpload12.PostedFile.FileName.Contains("*") == true || FileUpload12.PostedFile.FileName.Contains("$") == true
                      || FileUpload12.PostedFile.FileName.Contains("^") == true || FileUpload12.PostedFile.FileName.Contains("#") == true
                      || FileUpload12.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\TSIIC");

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
                        if (ViewState["TSIICD"] != null && ViewState["TSIIC"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox2.Text, Session["Applid"].ToString(), ViewState["TSCTD"].ToString(), ViewState["TSCTA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TSIIC", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button27_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload29.PostedFile != null) && (FileUpload29.PostedFile.ContentLength > 0))
            {
                if (FileUpload29.PostedFile.FileName.Contains("'") == true || FileUpload29.PostedFile.FileName.Contains("/") == true
                      || FileUpload29.PostedFile.FileName.Contains("*") == true || FileUpload29.PostedFile.FileName.Contains("$") == true
                      || FileUpload29.PostedFile.FileName.Contains("^") == true || FileUpload29.PostedFile.FileName.Contains("#") == true
                      || FileUpload29.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload29.PostedFile.FileName);
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

                    string[] fileType = FileUpload29.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Irrigation");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload29.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload29.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        //ViewState["IRRIGATIOND"] 
                        //ViewState["IRRIGATIONA"]
                        DataSet ds1 = new DataSet();
                        if (ViewState["IRRIGATIOND"] != null && ViewState["IRRIGATIONA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox19.Text, Session["Applid"].ToString(), ViewState["IRRIGATIOND"].ToString(), ViewState["IRRIGATIONA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Irrigation", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink19.Text = FileUpload29.FileName;
                            Label62.Text = FileUpload29.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button26_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload28.PostedFile != null) && (FileUpload28.PostedFile.ContentLength > 0))
            {
                if (FileUpload28.PostedFile.FileName.Contains("'") == true || FileUpload28.PostedFile.FileName.Contains("/") == true
                      || FileUpload28.PostedFile.FileName.Contains("*") == true || FileUpload28.PostedFile.FileName.Contains("$") == true
                      || FileUpload28.PostedFile.FileName.Contains("^") == true || FileUpload28.PostedFile.FileName.Contains("#") == true
                      || FileUpload28.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }

                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload28.PostedFile.FileName);
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

                    string[] fileType = FileUpload28.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\DrugsControlAdministration");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload28.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload28.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        //ViewState["DCAD"] 
                        //ViewState["DCAA"] 
                        //ViewState["IRRIGATIOND"] 
                        //ViewState["IRRIGATIONA"]
                        DataSet ds1 = new DataSet();
                        if (ViewState["DCAD"] != null && ViewState["DCAA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox18.Text, Session["Applid"].ToString(), ViewState["DCAD"].ToString(), ViewState["DCAA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Drugs Control Administration", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink18.Text = FileUpload28.FileName;
                            Label59.Text = FileUpload28.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button25_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload27.PostedFile != null) && (FileUpload27.PostedFile.ContentLength > 0))
            {
                if (FileUpload27.PostedFile.FileName.Contains("'") == true || FileUpload27.PostedFile.FileName.Contains("/") == true
                      || FileUpload27.PostedFile.FileName.Contains("*") == true || FileUpload27.PostedFile.FileName.Contains("$") == true
                      || FileUpload27.PostedFile.FileName.Contains("^") == true || FileUpload27.PostedFile.FileName.Contains("#") == true
                      || FileUpload27.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload27.PostedFile.FileName);
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

                    string[] fileType = FileUpload27.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\RegistrationsandStamps");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload27.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload27.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        //ViewState["REGSTAMPD"] 
                        //ViewState["REGSTAMPA"] 
                        //ViewState["DCAD"] 
                        //ViewState["DCAA"] 
                        //ViewState["IRRIGATIOND"] 
                        //ViewState["IRRIGATIONA"]
                        DataSet ds1 = new DataSet();
                        if (ViewState["REGSTAMPD"] != null && ViewState["REGSTAMPA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox17.Text, Session["Applid"].ToString(), ViewState["REGSTAMPD"].ToString(), ViewState["REGSTAMPA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Registrations and Stamps", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink17.Text = FileUpload27.FileName;
                            Label56.Text = FileUpload27.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button24_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload26.PostedFile != null) && (FileUpload26.PostedFile.ContentLength > 0))
            {
                if (FileUpload26.PostedFile.FileName.Contains("'") == true || FileUpload26.PostedFile.FileName.Contains("/") == true
                      || FileUpload26.PostedFile.FileName.Contains("*") == true || FileUpload26.PostedFile.FileName.Contains("$") == true
                      || FileUpload26.PostedFile.FileName.Contains("^") == true || FileUpload26.PostedFile.FileName.Contains("#") == true
                      || FileUpload26.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload26.PostedFile.FileName);
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

                    string[] fileType = FileUpload26.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Excise Department");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload26.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload26.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        //ViewState["EXCISED"] 
                        //ViewState["EXCISEA"] 
                        //ViewState["REGSTAMPD"] 
                        //ViewState["REGSTAMPA"] 
                        //ViewState["DCAD"] 
                        //ViewState["DCAA"] 
                        //ViewState["IRRIGATIOND"] 
                        //ViewState["IRRIGATIONA"]
                        DataSet ds1 = new DataSet();
                        if (ViewState["EXCISED"] != null && ViewState["EXCISEA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox16.Text, Session["Applid"].ToString(), ViewState["EXCISED"].ToString(), ViewState["EXCISEA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Excise Department", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink16.Text = FileUpload26.FileName;
                            Label53.Text = FileUpload26.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button23_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload25.PostedFile != null) && (FileUpload25.PostedFile.ContentLength > 0))
            {
                if (FileUpload25.PostedFile.FileName.Contains("'") == true || FileUpload25.PostedFile.FileName.Contains("/") == true
                    || FileUpload25.PostedFile.FileName.Contains("*") == true || FileUpload25.PostedFile.FileName.Contains("$") == true
                    || FileUpload25.PostedFile.FileName.Contains("^") == true || FileUpload25.PostedFile.FileName.Contains("#") == true
                    || FileUpload25.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload25.PostedFile.FileName);
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

                    string[] fileType = FileUpload25.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\HMWSSB");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload25.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload25.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

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
                        if (ViewState["HMWSSBD"] != null && ViewState["HMWSSBA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox15.Text, Session["Applid"].ToString(), ViewState["HMWSSBD"].ToString(), ViewState["HMWSSBA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "HMWSSB", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink15.Text = FileUpload25.FileName;
                            Label50.Text = FileUpload25.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button22_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload24.PostedFile != null) && (FileUpload24.PostedFile.ContentLength > 0))
            {
                if (FileUpload24.PostedFile.FileName.Contains("'") == true || FileUpload24.PostedFile.FileName.Contains("/") == true
                   || FileUpload24.PostedFile.FileName.Contains("*") == true || FileUpload24.PostedFile.FileName.Contains("$") == true
                   || FileUpload24.PostedFile.FileName.Contains("^") == true || FileUpload24.PostedFile.FileName.Contains("#") == true
                   || FileUpload24.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload24.PostedFile.FileName);
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

                    string[] fileType = FileUpload24.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\GroundWater");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload24.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload24.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

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
                        if (ViewState["GWD"] != null && ViewState["GWA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox14.Text, Session["Applid"].ToString(), ViewState["GWD"].ToString(), ViewState["GWA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Ground Water", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink14.Text = FileUpload24.FileName;
                            Label47.Text = FileUpload24.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button21_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload23.PostedFile != null) && (FileUpload23.PostedFile.ContentLength > 0))
            {
                if (FileUpload23.PostedFile.FileName.Contains("'") == true || FileUpload23.PostedFile.FileName.Contains("/") == true
                  || FileUpload23.PostedFile.FileName.Contains("*") == true || FileUpload23.PostedFile.FileName.Contains("$") == true
                  || FileUpload23.PostedFile.FileName.Contains("^") == true || FileUpload23.PostedFile.FileName.Contains("#") == true
                  || FileUpload23.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload23.PostedFile.FileName);
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

                    string[] fileType = FileUpload23.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Fire");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload23.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload23.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

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
                        if (ViewState["FIRED"] != null && ViewState["FIREA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox13.Text, Session["Applid"].ToString(), ViewState["FIRED"].ToString(), ViewState["FIREA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Fire", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink13.Text = FileUpload23.FileName;
                            Label44.Text = FileUpload23.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button20_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload22.PostedFile != null) && (FileUpload22.PostedFile.ContentLength > 0))
            {
                if (FileUpload22.PostedFile.FileName.Contains("'") == true || FileUpload22.PostedFile.FileName.Contains("/") == true
                  || FileUpload22.PostedFile.FileName.Contains("*") == true || FileUpload22.PostedFile.FileName.Contains("$") == true
                  || FileUpload22.PostedFile.FileName.Contains("^") == true || FileUpload22.PostedFile.FileName.Contains("#") == true
                  || FileUpload22.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload22.PostedFile.FileName);
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

                    string[] fileType = FileUpload22.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\DistrictTownandCountryPlanning");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload22.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload22.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

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
                        if (ViewState["DTCPD"] != null && ViewState["DTCPA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox12.Text, Session["Applid"].ToString(), ViewState["DTCPD"].ToString(), ViewState["DTCPA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DistrictTownandCountryPlanning", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink12.Text = FileUpload22.FileName;
                            Label41.Text = FileUpload22.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button19_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload21.PostedFile != null) && (FileUpload21.PostedFile.ContentLength > 0))
            {
                if (FileUpload21.PostedFile.FileName.Contains("'") == true || FileUpload21.PostedFile.FileName.Contains("/") == true
                  || FileUpload21.PostedFile.FileName.Contains("*") == true || FileUpload21.PostedFile.FileName.Contains("$") == true
                  || FileUpload21.PostedFile.FileName.Contains("^") == true || FileUpload21.PostedFile.FileName.Contains("#") == true
                  || FileUpload21.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload21.PostedFile.FileName);
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

                    string[] fileType = FileUpload21.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\CCLA");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload21.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload21.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

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
                        if (ViewState["CCLAD"] != null && ViewState["CCLAA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox11.Text, Session["Applid"].ToString(), ViewState["CCLAD"].ToString(), ViewState["CCLAA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CCLA", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink11.Text = FileUpload21.FileName;
                            Label38.Text = FileUpload21.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload20.PostedFile != null) && (FileUpload20.PostedFile.ContentLength > 0))
            {
                if (FileUpload20.PostedFile.FileName.Contains("'") == true || FileUpload20.PostedFile.FileName.Contains("/") == true
                  || FileUpload20.PostedFile.FileName.Contains("*") == true || FileUpload20.PostedFile.FileName.Contains("$") == true
                  || FileUpload21.PostedFile.FileName.Contains("^") == true || FileUpload20.PostedFile.FileName.Contains("#") == true
                  || FileUpload20.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload20.PostedFile.FileName);
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

                    string[] fileType = FileUpload20.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\HMDA");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload20.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload20.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

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
                        if (ViewState["HMDAD"] != null && ViewState["HMDAA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox10.Text, Session["Applid"].ToString(), ViewState["HMDAD"].ToString(), ViewState["HMDAA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "HMDA", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink10.Text = FileUpload20.FileName;
                            Label35.Text = FileUpload20.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button17_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload19.PostedFile != null) && (FileUpload19.PostedFile.ContentLength > 0))
            {
                if (FileUpload19.PostedFile.FileName.Contains("'") == true || FileUpload19.PostedFile.FileName.Contains("/") == true
                 || FileUpload19.PostedFile.FileName.Contains("*") == true || FileUpload19.PostedFile.FileName.Contains("$") == true
                 || FileUpload19.PostedFile.FileName.Contains("^") == true || FileUpload19.PostedFile.FileName.Contains("#") == true
                 || FileUpload19.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload19.PostedFile.FileName);
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

                    string[] fileType = FileUpload19.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Industries");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload19.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload19.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }


                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Industries", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink9.Text = FileUpload19.FileName;
                            Label32.Text = FileUpload19.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    protected void Button16_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload18.PostedFile != null) && (FileUpload18.PostedFile.ContentLength > 0))
            {
                if (FileUpload18.PostedFile.FileName.Contains("'") == true || FileUpload18.PostedFile.FileName.Contains("/") == true
                 || FileUpload18.PostedFile.FileName.Contains("*") == true || FileUpload18.PostedFile.FileName.Contains("$") == true
                 || FileUpload18.PostedFile.FileName.Contains("^") == true || FileUpload18.PostedFile.FileName.Contains("#") == true
                 || FileUpload18.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload18.PostedFile.FileName);
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

                    string[] fileType = FileUpload18.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Factories");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload18.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload18.PostedFile.SaveAs(newPath + "\\" + sFileName);
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
                        if (ViewState["FACTD"] != null && ViewState["FACTA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox8.Text, Session["Applid"].ToString(), ViewState["FACTD"].ToString(), ViewState["FACTA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Factories", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink8.Text = FileUpload18.FileName;
                            Label29.Text = FileUpload18.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button15_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload17.PostedFile != null) && (FileUpload17.PostedFile.ContentLength > 0))
            {
                if (FileUpload17.PostedFile.FileName.Contains("'") == true || FileUpload17.PostedFile.FileName.Contains("/") == true
                || FileUpload17.PostedFile.FileName.Contains("*") == true || FileUpload17.PostedFile.FileName.Contains("$") == true
                || FileUpload17.PostedFile.FileName.Contains("^") == true || FileUpload17.PostedFile.FileName.Contains("#") == true
                || FileUpload17.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\TSSPDCL");

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
                        if (ViewState["TSSPDCLD"] != null && ViewState["TSSPDCLA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox7.Text, Session["Applid"].ToString(), ViewState["TSSPDCLD"].ToString(), ViewState["TSSPDCLA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TSSPDCL", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink7.Text = FileUpload17.FileName;
                            Label26.Text = FileUpload17.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload16.PostedFile != null) && (FileUpload16.PostedFile.ContentLength > 0))
            {
                if (FileUpload16.PostedFile.FileName.Contains("'") == true || FileUpload16.PostedFile.FileName.Contains("/") == true
               || FileUpload16.PostedFile.FileName.Contains("*") == true || FileUpload16.PostedFile.FileName.Contains("$") == true
               || FileUpload16.PostedFile.FileName.Contains("^") == true || FileUpload16.PostedFile.FileName.Contains("#") == true
               || FileUpload16.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\TSNPDCL");

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
                        if (ViewState["TSNPDCLD"] != null && ViewState["TSNPDCLA"] != null)
                            n1 = Gen.UpdateRefferenceNumber(TextBox6.Text, Session["Applid"].ToString(), ViewState["TSNPDCLD"].ToString(), ViewState["TSNPDCLA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TSNPDCL", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink6.Text = FileUpload16.FileName;
                            Label23.Text = FileUpload16.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload15.PostedFile != null) && (FileUpload15.PostedFile.ContentLength > 0))
            {
                if (FileUpload15.PostedFile.FileName.Contains("'") == true || FileUpload15.PostedFile.FileName.Contains("/") == true
               || FileUpload15.PostedFile.FileName.Contains("*") == true || FileUpload15.PostedFile.FileName.Contains("$") == true
               || FileUpload15.PostedFile.FileName.Contains("^") == true || FileUpload15.PostedFile.FileName.Contains("#") == true
               || FileUpload15.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\ElectricalInspectorate");

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
                            n1 = Gen.UpdateRefferenceNumber(TextBox5.Text, Session["Applid"].ToString(), ViewState["CEIGD"].ToString(), ViewState["CEIGA"].ToString());
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Electrical Inspectorate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0 && n1 == 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink5.Text = FileUpload15.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload14.PostedFile != null) && (FileUpload14.PostedFile.ContentLength > 0))
            {

                if (FileUpload14.PostedFile.FileName.Contains("'") == true || FileUpload14.PostedFile.FileName.Contains("/") == true
               || FileUpload14.PostedFile.FileName.Contains("*") == true || FileUpload14.PostedFile.FileName.Contains("$") == true
               || FileUpload14.PostedFile.FileName.Contains("^") == true || FileUpload14.PostedFile.FileName.Contains("#") == true
               || FileUpload14.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\DISCOM");

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
                            n1 = Gen.UpdateRefferenceNumber(TextBox4.Text, Session["Applid"].ToString(), ViewState["DISCOMD"].ToString(), ViewState["DISCOMA"].ToString());

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DISCOM", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
            {
                if (FileUpload13.PostedFile.FileName.Contains("'") == true || FileUpload13.PostedFile.FileName.Contains("/") == true
               || FileUpload13.PostedFile.FileName.Contains("*") == true || FileUpload13.PostedFile.FileName.Contains("$") == true
               || FileUpload13.PostedFile.FileName.Contains("^") == true || FileUpload13.PostedFile.FileName.Contains("#") == true
               || FileUpload13.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\PanchayatRaj");

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
                            n1 = Gen.UpdateRefferenceNumber(TextBox3.Text, Session["Applid"].ToString(), ViewState["PRDD"].ToString(), ViewState["PRDA"].ToString());

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Panchayat Raj", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button11_Click1(object sender, EventArgs e)
    {

    }

    protected void BTNDEETACK_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((fupdeetack.PostedFile != null) && (fupdeetack.PostedFile.ContentLength > 0))
            {
                if (fupdeetack.PostedFile.FileName.Contains("'") == true || fupdeetack.PostedFile.FileName.Contains("/") == true
                        || fupdeetack.PostedFile.FileName.Contains("*") == true || fupdeetack.PostedFile.FileName.Contains("$") == true
                        || fupdeetack.PostedFile.FileName.Contains("^") == true || fupdeetack.PostedFile.FileName.Contains("#") == true
                        || fupdeetack.PostedFile.FileName.Contains("&") == true)
                {
                    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fupdeetack.PostedFile.FileName);
                try
                {


                    string[] fileType = fupdeetack.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\DEETREGACKNOWLEDGEMENT");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupdeetack.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupdeetack.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }


                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DEET REGACKNOWLEDGEMENT", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hypdeetack.Text = fupdeetack.FileName;
                            lbldeetack.Text = fupdeetack.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

}




