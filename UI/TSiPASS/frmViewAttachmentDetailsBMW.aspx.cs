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

public partial class UI_TSiPASS_frmViewAttachmentDetailsBMW : System.Web.UI.Page
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
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {

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

            //ds = ViewAttachmentBattery(hdfFlagID0.Value.ToString());


            //if (!Directory.Exists("~/BatteryAttachments/" + hdfFlagID0.Value.ToString() + "/GST"))
            //{
            //    //D:\TsipassFinal30062022\TsipassFinal\BatteryAttachments\11\GST\flow.pdf

            //    HyperLink1.Text = "No Attachment";
            //}
            //if (!Directory.Exists("~/BatteryAttachments/" + hdfFlagID0.Value.ToString() + "/BatteryDealer Deed"))
            //{
            //    HyperLink2.Text = "No Attachment";
            //}


            //if (!Directory.Exists("~/BatteryAttachments/" + hdfFlagID.Value.ToString() + "/ResponseAttachment"))
            //{
            //    HyperLink14.Text = "No Attachment";
            //}


            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    int c = ds.Tables[0].Rows.Count;
            //    string sen, sen1, sen2;
            //    int i = 0;

            //    while (i < c)
            //    {
            //        sen2 = ds.Tables[0].Rows[i][0].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (sen.Contains("GST Registration Certificate"))
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
            //        }

            //        if (sen.Contains("Copy of Battery Dealer Registration"))
            //        {
            //            HyperLink2.NavigateUrl = sen;
            //            HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
            //        }

            //        i++;
            //    }

            //}


            DataSet dsdept = new DataSet();
            if (Session["User_Code"].ToString().Trim() == "10" || Session["User_Code"].ToString().Trim() == "1000" || Session["User_type"].ToString().Trim() == "Train" || Session["userlevel"].ToString().Trim() == "1" || Session["userlevel"].ToString().Trim() == "2")
            {
                dsdept = GetdatabmwApprovaldocument(hdfFlagID0.Value.ToString());
            }
            else
            {
                dsdept = GetdatabyDeptinBMWdocument(hdfFlagID0.Value.ToString(), Session["User_Code"].ToString().Trim());
            }
            if (dsdept.Tables[0].Rows.Count > 0)
            {
                int c = dsdept.Tables[0].Rows.Count;
                string sen, sen1;
                int i = 0;

                while (i < c)
                {
                    sen = dsdept.Tables[0].Rows[i][0].ToString();

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
                    lab[i].Text += "<tr><td> " + dsdept.Tables[0].Rows[i][1].ToString() + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel7.Controls.Add(lab[i]);
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> " + dsdept.Tables[0].Rows[i][2].ToString() + "</td></tr>";
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

            dsdept1 = GetdatabyDeptinBMWdocumentRespondDetails(hdfFlagID0.Value.ToString());

            if (dsdept1.Tables[0].Rows.Count > 0)
            {
                int c = dsdept1.Tables[0].Rows.Count;
                string sen, sen1;
                int i = 0;

                while (i < c)
                {
                    sen = dsdept1.Tables[0].Rows[i][0].ToString();
                    sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                    lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsdept1.Tables[0].Rows[i][1].ToString() + "</a></td></tr>";
                    lab[i].Text += "</table><br/>";
                    //Panel6.Controls.Add(lab[i]);
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                    lab[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    //Panel5.Controls.Add(lab[i]);

                    i++;
                }

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
    public DataSet GetdatabyDeptinBMWdocument(string intEnterprenuerid, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetrivelinkbyDeptidbatterybyapporval", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();

            if (deptid.Trim() == "" || deptid.Trim() == null || deptid.Trim() == "10" || deptid.Trim() == "1000")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = deptid.ToString();

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

    public DataSet GetdatabyDeptinBMWdocumentRespondDetails(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetrivelinkbyDeptidBMWbyRespondant", con.GetConnection);
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
    public DataSet GetdatabmwApprovaldocument(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveApprovallinkbmw", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = DBNull.Value;
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
    protected void GetNewRectoInsertdr()
    {

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("RenewalPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("RenewalPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }

    public DataSet ViewAttachmentBattery(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        try
        {
            da = new SqlDataAdapter("[sp_RetriveBatteryAttachment]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();

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