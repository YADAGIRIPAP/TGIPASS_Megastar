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
public partial class UI_TSiPASS_frmViewAttachmentDetailsOtherServices : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    HyperLink[] h = new HyperLink[100];
    Label[] lab = new Label[100];
    static DataTable dtMyTable;

    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    Globavaribles gbp = new Globavaribles();

    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }


        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();
                HyperLinkcoi.Target = "_blank";
                HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(hdfFlagID0.Value).Trim();
            }

        }


        if (!IsPostBack)
        {
            //  hdfFlagID.Value = "1073";
            //dtMyTableCertificate = createtablecrtificate();
            //Session["CertificateTb"] = dtMyTableCertificate;
            // FillDetails();

        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }



    void clear()
    {




    }

    public DataSet GetdatabyDeptinCFEdocumentReject(string intEnterprenuerid)  //added..23.09.19
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetrivelinkbyDeptid_RejectionDoc", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();



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




    void FillDetails()
    {
        // hdfFlagID.Value = "1072";RetriveLinkForDD
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        DataTable dt1 = new DataTable();
        dt1.Columns.Add("link");
        dt1.Columns.Add("FileName");

        DataTable dt2 = new DataTable();
        dt2.Columns.Add("link");
        dt2.Columns.Add("FileName");

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsDataOtherServices(hdfFlagID0.Value.ToString());



            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/OtherServiceDistReforms"))
            {
                HyperLink1.Text = "No Attachment";
            }
            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/RegistrationDeed"))
            {
                HyperLink2.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/Mutation order"))
            {
                HyperLink3.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/Combinedbuildingplan"))
            {
                //HyperLink4.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/Combinedsiteplan"))
            {
                //HyperLink5.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/PartnershipdetailsorArticlesofAssociation"))
            {
                HyperLink6.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/ProcessFlowChart"))
            {
                HyperLink7.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/PANorAADHAAR"))
            {
                HyperLink8.Text = "No Attachment";
            }

            //if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/Document"))
            //{
            //    HyperLink9.Text = "No Attachment";
            //}

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/GoogleMaptoUpload"))
            {
                HyperLink11.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/KML File"))
            {
                HyperLink12.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/KML FILE1"))
            {
                HyperLink13.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/ResponseAttachment"))
            {
                HyperLink14.Text = "No Attachment";

            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/CFERejectedDocumentS"))
            {
                hplRejectedDoc.Text = "No Attachment";
            }

            //if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/AppealAttachment"))
            //{
            //    HyperLink9.Text = "No Attachment";
            //}

            //if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/ApprovalDocument"))
            //{

            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, senPlanB;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("OtherServiceDistReforms"))
                    {
                        HyperLink1.NavigateUrl = sen;
                        HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("RegistrationDeed"))
                    {
                        HyperLink2.NavigateUrl = sen;
                        HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("Mutation order"))
                    {
                        HyperLink3.NavigateUrl = sen;
                        HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("Combinedbuildingplan"))
                    {
                        //HyperLink4.NavigateUrl = sen;
                        //HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt1.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt1.Rows.Add(_row);

                        Session["CertificateTb1"] = null;
                        Session["CertificateTb1"] = dt1;
                        this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gvUpload4.DataBind();
                    }

                    if (sen.Contains("Combinedsiteplan"))
                    {
                        //HyperLink5.NavigateUrl = sen;
                        //HyperLink5.Text = ds.Tables[0].Rows[i][1].ToString();
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt2.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt2.Rows.Add(_row);

                        Session["CertificateTb2"] = null;
                        Session["CertificateTb2"] = dt2;
                        this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvUpload5.DataBind();
                    }

                    if (sen.Contains("PartnershipdetailsorArticlesofAssociation"))
                    {
                        HyperLink6.NavigateUrl = sen;
                        HyperLink6.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("ProcessFlowChart"))
                    {
                        HyperLink7.NavigateUrl = sen;
                        HyperLink7.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("PANorAADHAAR"))
                    {
                        HyperLink8.NavigateUrl = sen;
                        HyperLink8.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    //if (sen.Contains("Document"))
                    //{
                    //    HyperLink9.NavigateUrl = sen;
                    //    HyperLink9.Text = ds.Tables[0].Rows[i][1].ToString();
                    //}


                    if (sen.Contains("GoogleMaptoUpload"))
                    {
                        HyperLink11.NavigateUrl = sen;
                        HyperLink11.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("KML File"))
                    {
                        HyperLink12.NavigateUrl = sen;
                        HyperLink12.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("KML FILE1"))
                    {
                        HyperLink13.NavigateUrl = sen;
                        HyperLink13.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("ResponseAttachment"))
                    {
                        HyperLink14.NavigateUrl = sen;
                        HyperLink14.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("ApprovalDocument"))
                    {
                        HyperLink15.NavigateUrl = sen;
                        HyperLink15.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    //if (sen.Contains("AppealAttachment"))
                    //{
                    //    HyperLink9.NavigateUrl = sen;
                    //    HyperLink9.Text = ds.Tables[0].Rows[i][1].ToString();
                    //}

                    i++;
                }

            }

            //if (ds.Tables[8].Rows.Count > 0)  //added newly
            //{
            //    string senRejection, senRejection1, senRejection2, strCheck;
            //    senRejection = ds.Tables[8].Rows[0][0].ToString();
            //    senRejection1 = senRejection.Replace(@"\", @"/");
            //    senRejection2 = senRejection1.Replace(@"D:/TS-iPASSFinal/", "~/");
            //    strCheck = ds.Tables[8].Rows[0][1].ToString();
            //    hplRejectedDoc.NavigateUrl = senRejection2;
            //    hplRejectedDoc.Text = "Rejection Letter";


            //}


            //Modified by kabeer
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    HyperLink15.NavigateUrl = ds.Tables[1].Rows[0]["Dept_Cert_Path"].ToString();
            //    HyperLink15.Text = "Fire Approval";
            //}

            //ds1 = Gen.RetriveLink(hdfFlagID0.Value.ToString());


            ////----------------------------------------------------------
            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    int c = ds1.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = ds1.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + ds1.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        AdditionalHyper.Controls.Add(lab[i]);
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        AdditionalSno.Controls.Add(lab[i]);

            //        i++;
            //    }

            //}

            //------------------------------------------------------------


            DataSet dsdept = new DataSet();
            if (Session["User_Code"].ToString().Trim() == "10" || Session["User_Code"].ToString().Trim() == "1000" || Session["User_type"].ToString().Trim() == "Train" || Session["userlevel"].ToString().Trim() == "1" || Session["userlevel"].ToString().Trim() == "2" || Session["DistrictID"].ToString().Trim() != "")
            {
                dsdept = Gen.GetdataCFEApprovaldocumentOtherServices(hdfFlagID0.Value.ToString());
            }
            else
            {
                dsdept = Gen.GetdatabyDeptinCFEdocumentOtherServices(hdfFlagID0.Value.ToString(), Session["User_Code"].ToString().Trim());
            }
            if (dsdept.Tables[0].Rows.Count > 0)
            {
                int c = dsdept.Tables[0].Rows.Count;
                string sen, sen1;
                int i = 0;

                while (i < c)
                {
                    sen = dsdept.Tables[0].Rows[i][0].ToString();
                    //sen1 = sen2.Replace(@"\", @"/");
                    // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                    sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
                    lab[i] = new Label();
                    lab[i].Text += "<table  style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> ";
                    if (sen != "")
                    {
                        lab[i].Text += "<a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsdept.Tables[0].Rows[i][1].ToString() + "</a>";
                    }
                    else
                    {
                        lab[i].Text += "<lable style='color:#FF6600;'>" + dsdept.Tables[0].Rows[i][1].ToString() + "</lable>";
                    }
                    lab[i].Text += "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel4.Controls.Add(lab[i]);

                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> " + dsdept.Tables[0].Rows[i][2].ToString() + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel7.Controls.Add(lab[i]);
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> " + dsdept.Tables[0].Rows[i][3].ToString() + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel8.Controls.Add(lab[i]);

                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel3.Controls.Add(lab[i]);

                    i++;
                }

            }

            //DataSet dsdeptdigital = new DataSet();
            //dsdeptdigital = Gen.GetdatabyDeptinCFEdocumentDigitalDetails(hdfFlagID0.Value.ToString());

            //if (dsdeptdigital.Tables[0].Rows.Count > 0)
            //{
            //    //trdigi1.Visible = true;
            //    //trdigi.Visible = true;
            //    int c = dsdeptdigital.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = dsdeptdigital.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsdeptdigital.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        Panel10.Controls.Add(lab[i]);
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        Panel9.Controls.Add(lab[i]);
            //        i++;
            //    }

            //}

            //DataSet dsdpmsplans = new DataSet();
            //dsdpmsplans = Gen.GetdatabyDeptinCFEdocumentDPMSPlans(hdfFlagID0.Value.ToString());

            //if (dsdpmsplans.Tables[0].Rows.Count > 0)
            //{
            //    //trdigi1.Visible = true;
            //    //trdigi.Visible = true;
            //    int c = dsdpmsplans.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = dsdpmsplans.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsdpmsplans.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        Panel12.Controls.Add(lab[i]);
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        Panel11.Controls.Add(lab[i]);
            //        i++;
            //    }

            //}
            //else
            //{
            //    trdigi1.Visible = false;
            //    trdigi.Visible = false;
            //}
            DataSet dsdept1 = new DataSet();
            dsdept1 = Gen.GetdatabyDeptinCFEdocumentRespondDetailsOtherServices(hdfFlagID0.Value.ToString());

            if (dsdept1.Tables[0].Rows.Count > 0)
            {
                int c = dsdept1.Tables[0].Rows.Count;
                string sen, sen1;
                int i = 0;

                while (i < c)
                {
                    sen = dsdept1.Tables[0].Rows[i][0].ToString();
                    //sen1 = sen2.Replace(@"\", @"/");
                    // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                    sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                    lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsdept1.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel6.Controls.Add(lab[i]);
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                    lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel5.Controls.Add(lab[i]);

                    i++;
                }

            }

            //For appeal attachments - 20.10.18

            //DataSet dsAppeal = new DataSet();
            //dsAppeal = Gen.GetdatabyDeptinCFEdocumentAppeal(hdfFlagID0.Value.ToString());

            //if (dsAppeal.Tables[0].Rows.Count > 0)
            //{
            //    int c = dsAppeal.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = dsAppeal.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsAppeal.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlAppeal.Controls.Add(lab[i]);
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlAppealCount.Controls.Add(lab[i]);

            //        i++;
            //    }

            //}

            //DataSet dsRejct_Doc = new DataSet();
            //dsRejct_Doc = GetdatabyDeptinCFEdocumentReject(hdfFlagID0.Value.ToString());

            //if (dsRejct_Doc.Tables[0].Rows.Count > 0)
            //{
            //    int c = dsRejct_Doc.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = dsRejct_Doc.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsRejct_Doc.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlRejectionAttachment1.Controls.Add(lab[i]);
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlRejectionAttachment.Controls.Add(lab[i]);

            //        i++;
            //    }

            //}

            //SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            //SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            //DataSet dsoffline;

            //osqlConnection.Open();
            //oSqlDataAdapter = new SqlDataAdapter("sp_RetrivelinkbyDeptid_offline", osqlConnection);
            //oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //oSqlDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = hdfFlagID0.Value.ToString();

            //dsoffline = new DataSet();
            //oSqlDataAdapter.Fill(dsoffline);

            //if (dsoffline.Tables[0].Rows.Count > 0)
            //{
            //    int c = dsoffline.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = dsoffline.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsoffline.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlOflPath.Controls.Add(lab[i]);

            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + dsoffline.Tables[0].Rows[i][2].ToString() + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlOflAppr.Controls.Add(lab[i]);

            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        pnlOflSno.Controls.Add(lab[i]);

            //        i++;
            //    }

            //}
            //osqlConnection.Close();

            ////----------------------------------------------------------
            //ds2 = Gen.RetriveLinkForDD(hdfFlagID0.Value.ToString());
            //if (ds2.Tables[0].Rows.Count > 0)
            //{
            //    int c = ds2.Tables[0].Rows.Count;
            //    string sen, sen1;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen = ds2.Tables[0].Rows[i][0].ToString();
            //        //sen1 = sen2.Replace(@"\", @"/");
            //        // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
            //        sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + ds2.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        Panel1.Controls.Add(lab[i]);
            //        lab[i] = new Label();
            //        lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //        lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
            //        lab[i].Text += "</table><br/>";
            //        Panel2.Controls.Add(lab[i]);

            //        i++;
            //    }

            //}

            //------------------------------------------------------------

            //System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo("D:\\RAJESHP\\TS-iPASSFinal\\Attachments\\" + hdfFlagID.Value.ToString() + "\\DD Upload");
            //System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo("~/Attachments/" + hdfFlagID.Value.ToString() + "/DD Upload");
            ////int count = dir.GetFiles().Length;
            //FileInfo[] Files1 = dir1.GetFiles();
            //int j = 1;
            //foreach (FileInfo file in Files1)
            //{
            //    lab[j] = new Label();
            //    lab[j].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //    lab[j].Text += "<tr><td> <a href='~/Attachments/" + hdfFlagID.Value.ToString() + "/DD Upload/" + file.Name + "' target='_blank' style='color:#FF6600;'>" + file.Name + "</a></td></tr>";
            //    lab[j].Text += "</table><br/>";
            //    //h[j] = new HyperLink();
            //    //h[j].NavigateUrl = "~/Attachments/" + hdfFlagID.Value.ToString() + "/DD Upload/" + file.Name;
            //    //h[j].Visible = true;
            //    //h[j].Target = "_blank";
            //    Panel1.Controls.Add(lab[j]);
            //    lab[j] = new Label();
            //    lab[j].Text += "<table style='border: 1px solid #003366;' width='100%'>";
            //    lab[j].Text += "<tr><td> " + j + "</td></tr>";
            //    lab[j].Text += "</table><br/>";
            //    Panel2.Controls.Add(lab[j]);
            //    j++;
            //}

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                hmdaattachements.Visible = true;
                gvlastattachments.DataSource = ds.Tables[3];
                gvlastattachments.DataBind();
            }
            else
            {
                hmdaattachements.Visible = false;
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






    protected void GetNewRectoInsertdr()
    {

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }
}