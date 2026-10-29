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
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    HyperLink[] h = new HyperLink[100];
    Label[] lab = new Label[100];
    static DataTable dtMyTable;

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



    void FillDetails()
    {
        // hdfFlagID.Value = "1072";RetriveLinkForDD
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsDataCFO(hdfFlagID0.Value.ToString());


            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/B1Form"))
            {
                HyperLink1.Text = "No Attachment";
            }
            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/B2Form"))
            {
                HyperLink2.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/HazForm"))
            {
                HyperLink3.Text = "No Attachment";
            }

             if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CompForm"))
            {
                HyperLink4.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/FileCertForm"))
            {
                HyperLink5.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/BoilerRegForm"))
            {
                HyperLink6.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/DrugForm"))
            {
                HyperLink7.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/ElecDrawForm"))
            {
                HyperLink8.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/AppealAttachment"))
            {
                HyperLink9.Text = "No Attachment";
            }


            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/PartDeedForm"))
            {
                HyperLink16.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/ListofDirForm"))
            {
                HyperLink17.Text = "No Attachment";
            }


            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/PanForm"))
            {
                HyperLink18.Text = "No Attachment";
            }


            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/LandDeedForm"))
            {
                HyperLink19.Text = "No Attachment";
            }



            //if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/Document"))
            //{
            //    HyperLink9.Text = "No Attachment";
            //}

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CFOPCB"))
            {
                HyperLink11.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CFOFactory"))
            {
                HyperLink12.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CFOFire"))
            {
                HyperLink13.Text = "No Attachment";
            }


            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CFOHT"))
            {
                HyperLink20.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CFODRUG"))
            {
                HyperLink21.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/CFOboilers"))
            {
                HyperLink22.Text = "No Attachment";
            }

            if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/ResponseAttachment"))
            {
                HyperLink14.Text = "No Attachment";
            }

            //if (!Directory.Exists("~/CFOAttachments/" + hdfFlagID.Value.ToString() + "/ApprovalDocument"))
            //{
            //    HyperLink15.Text = "No Attachment";
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("B1Form"))
                    {
                        HyperLink1.NavigateUrl = sen;
                        HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("B2Form"))
                    {
                        HyperLink2.NavigateUrl = sen;
                        HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("HazForm"))
                    {
                        HyperLink3.NavigateUrl = sen;
                        HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CompForm"))
                    {
                        HyperLink4.NavigateUrl = sen;
                        HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("FileCertForm"))
                    {
                        HyperLink5.NavigateUrl = sen;
                        HyperLink5.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("BoilerRegForm"))
                    {
                        HyperLink6.NavigateUrl = sen;
                        HyperLink6.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("DrugForm"))
                    {
                        HyperLink7.NavigateUrl = sen;
                        HyperLink7.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("ElecDrawForm"))
                    {
                        HyperLink8.NavigateUrl = sen;
                        HyperLink8.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("AppealAttachment"))
                    {
                        HyperLink9.NavigateUrl = sen;
                        HyperLink9.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("PartDeedForm"))
                    {
                        HyperLink16.NavigateUrl = sen;
                        HyperLink16.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("ListofDirForm"))
                    {
                        HyperLink17.NavigateUrl = sen;
                        HyperLink17.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("PanForm"))
                    {
                        HyperLink18.NavigateUrl = sen;
                        HyperLink18.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("LandDeedForm"))
                    {
                        HyperLink19.NavigateUrl = sen;
                        HyperLink19.Text = ds.Tables[0].Rows[i][1].ToString();
                    }


                    //if (sen.Contains("Document"))
                    //{
                    //    HyperLink9.NavigateUrl = sen;
                    //    HyperLink9.Text = ds.Tables[0].Rows[i][1].ToString();
                    //}


                    if (sen.Contains("CFOPCB"))
                    {
                        HyperLink11.NavigateUrl = sen;
                        HyperLink11.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOFactory"))
                    {
                        HyperLink12.NavigateUrl = sen;
                        HyperLink12.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOFire"))
                    {
                        HyperLink13.NavigateUrl = sen;
                        HyperLink13.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOHT"))
                    {
                        HyperLink20.NavigateUrl = sen;
                        HyperLink20.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFODRUG"))
                    {
                        HyperLink21.NavigateUrl = sen;
                        HyperLink21.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CFOboilers"))
                    {
                        HyperLink22.NavigateUrl = sen;
                        HyperLink22.Text = ds.Tables[0].Rows[i][1].ToString();
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

                    i++;
                }

            }

            //HyperLink15.Text = "TSSPDCL Approval Document";
            //HyperLink15.NavigateUrl = ds.Tables[1].Rows[0]["Dept_Cert_Path"].ToString();
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
            if (Session["User_Code"].ToString().Trim() == "10" || Session["User_Code"].ToString().Trim() == "1000" || Session["User_type"].ToString().Trim() == "Train" || Session["userlevel"].ToString().Trim() == "1" || Session["userlevel"].ToString().Trim() == "2")
            {
                dsdept = Gen.GetdataCFOApprovaldocument(hdfFlagID0.Value.ToString());
            }
            else
            {
                dsdept = Gen.GetdatabyDeptinCFOdocument(hdfFlagID0.Value.ToString(), Session["User_Code"].ToString().Trim());
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


            DataSet dsdept1 = new DataSet();

            dsdept1 = Gen.GetdatabyDeptinCFOdocumentRespondDetails(hdfFlagID0.Value.ToString());

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



            //----------------------------------------------------------
            ds2 = Gen.RetriveLinkForDDCFO(hdfFlagID0.Value.ToString());
            if (ds2.Tables[0].Rows.Count > 0)
            {
                int c = ds2.Tables[0].Rows.Count;
                string sen, sen1;
                int i = 0;

                while (i < c)
                {
                    sen = ds2.Tables[0].Rows[i][0].ToString();
                    //sen1 = sen2.Replace(@"\", @"/");
                    // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                    sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                    lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + ds2.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel1.Controls.Add(lab[i]);
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                    lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel2.Controls.Add(lab[i]);

                    i++;
                }

            }

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
        Response.Redirect("CFOPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFOPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }
}




