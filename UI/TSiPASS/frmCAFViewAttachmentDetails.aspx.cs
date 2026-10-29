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

            ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());


            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/SelfCertificationForm"))
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
                HyperLink4.Text = "No Attachment";
            }

            if (!Directory.Exists("~/Attachments/" + hdfFlagID.Value.ToString() + "/Combinedsiteplan"))
            {
                HyperLink5.Text = "No Attachment";
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
                    sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");

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

                    

                    i++;
                }

            }

            ds1 = Gen.RetriveLink(hdfFlagID0.Value.ToString());


            //----------------------------------------------------------
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
            //        //sen1 = sen.Replace("D:/Frux Hosting/TS-iPASSFinal/", "../../");
            //        sen1 = sen.Replace(sen.Substring(0, sen.IndexOf(@"/Attachments")), "~");
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



            //----------------------------------------------------------
            ds2 = Gen.RetriveLinkForDD(hdfFlagID0.Value.ToString());
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
                    //sen1 = sen.Replace("D:/Frux Hosting/TS-iPASSFinal/", "../../");
                    sen1 = sen.Replace(sen.Substring(0, sen.IndexOf(@"/Attachments")), "~");
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
        Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }
}




