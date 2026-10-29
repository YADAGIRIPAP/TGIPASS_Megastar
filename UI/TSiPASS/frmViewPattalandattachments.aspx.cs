using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmViewPattalandattachments : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }


        if (Request.QueryString[0].ToString().Trim() != null)
        {
            hdfFlagID0.Value = Request.QueryString[2].ToString().Trim();
            string stageID = Request.QueryString[1].ToString().Trim();
            LblpattalandID.Text = Request.QueryString[0].ToString().Trim();

            if (!IsPostBack)
            {
                FillDetails();
                // HyperLinkcoi.Target = "_blank";
                // HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(hdfFlagID0.Value).Trim();
            }

        }

    }
    void FillDetails()
    {
        string stageID = Request.QueryString[1].ToString().Trim();
        DataSet ds = new DataSet();
       

        try
        {
            ds = ViewAttachmetsData(hdfFlagID0.Value.ToString()); //D:\TsipassFinal_28-12-2022\ADMandGATTACHMENTS\11\PAN
            //D:\TsipassFinal_28-12-2022\ADMandGATTACHMENTS\11\DGPSMAP

            //if (!Directory.Exists("~/PATTADARATTACHMENTS/" + hdfFlagID.Value.ToString() + "/LANDDOCUMENTS"))
            //{
            //    HyperLink1.Text = "No Attachment";
            //}
            if (!Directory.Exists("~/PATTADARATTACHMENTS/" + hdfFlagID.Value.ToString() + "/DGPSMAP"))
            {
                HyperLink2.Text = "No Attachment";
            }
            //if (!Directory.Exists("~/PATTADARATTACHMENTS/" + hdfFlagID.Value.ToString() + "/PAN"))
            //{
            //    HyperLink3.Text = "No Attachment";
            //}

            //if (!Directory.Exists("~/PATTADARATTACHMENTS/" + hdfFlagID.Value.ToString() + "/OtherDocuments"))
            //{
            //    HyperLink4.Text = "No Attachment";
            //}


            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {//D:\TsipassFinal_28-12-2022\ADMandGATTACHMENTS\11\DGPSMAP
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");// //D:\TsipassFinal_28-12-2022\ADMandGATTACHMENTS\11\DGPSMAP
                    sennew = ds.Tables[0].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    //if (sen.Contains("LANDDOCUMENTS"))
                    //{
                    //    HyperLink1.NavigateUrl = sen;
                    //    HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                    //}
                    if (sen.Contains("DGPSMAP"))
                    {
                       // HyperLink2.NavigateUrl = sen;
                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    //if (sen.Contains("PAN"))
                    //{
                    //    HyperLink3.NavigateUrl = sen;
                    //    HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                    //}

                    //if (sen.Contains("OtherDocuments"))
                    //{

                    //    HyperLink4.NavigateUrl = sen;
                    //    HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                    //}
                    if (stageID == "13")
                    {
                        if (sen.Contains("NOC"))
                        {
                            //trDGPS.Visible = false;
                            //trPAN.Visible = false;
                            //trOthDoc.Visible = false;
                            tblapproved.Visible = true;
                            trNOC.Visible = true;
                            HyperLink3.NavigateUrl = sen;
                            HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("SignedDGPS"))
                        {
                            //trDGPS.Visible = false;
                            //trPAN.Visible = false;
                            //trOthDoc.Visible = false;
                            tblapproved.Visible = true;
                            trSignedDGPS.Visible = true;
                            HyperLink4.NavigateUrl = sen;
                            HyperLink4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                        }
                    }

                        i++;
                }

            }

        }
        catch (Exception ex)
        {


        }
        finally
        {

        }

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
    }

    public DataSet ViewAttachmetsData(string ID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveAttachmentsByPattadarID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (ID.Trim() == "" || ID.Trim() == null)
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID.ToString();

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
}