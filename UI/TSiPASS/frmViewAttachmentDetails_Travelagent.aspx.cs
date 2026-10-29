using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmViewAttachmentDetails_Travelagent : System.Web.UI.Page
{
    General Gen = new General();

    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    Label[] lab = new Label[100];
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
    }
    protected void gvlastattachments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public DataSet GetdatadocumentbyintqueID(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TE_getRetriveAttachmentsBytourismtravelagent", con.GetConnection);
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
        try
        {
            DataSet dsdept = GetdatadocumentbyintqueID(hdfFlagID0.Value.ToString());
            if (dsdept != null && dsdept.Tables.Count > 0)
            {
                gvlastattachments.DataSource = dsdept.Tables[0];
                gvlastattachments.DataBind();
            }
            if (dsdept.Tables[1].Rows.Count > 0)
            {
                int c = dsdept.Tables[1].Rows.Count;
                string sen, sen1, sennew;
                int i = 0;

                while (i < c)
                {
                    sen = dsdept.Tables[1].Rows[i][1].ToString();
                    //sen1 = sen2.Replace(@"\", @"/");
                    // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                    sen1 = sen.Replace("D:/TS-iPASSFinal/", "~/");
                    sennew = dsdept.Tables[1].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    lab[i] = new Label();
                    lab[i].Text += "<table  style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> ";
                    if (sen != "")
                    {
                       // lab[i].Text += "<a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + dsdept.Tables[1].Rows[i][1].ToString() + "</a>";
                        lab[i].Text += "<a href='CS.aspx?filepathnew=" + encpassword + "' target='_blank' style='color:#FF6600;'>" + dsdept.Tables[1].Rows[i][1].ToString() + "</a>";
                    }
                    else
                    {
                        lab[i].Text += "<lable style='color:#FF6600;'>" + dsdept.Tables[1].Rows[i][1].ToString() + "</lable>";
                    }
                    lab[i].Text += "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel4.Controls.Add(lab[i]);

                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> " + dsdept.Tables[1].Rows[i][2].ToString() + "</td></tr>";
                    lab[i].Text += "</table><br/>";
                    Panel7.Controls.Add(lab[i]);
                    lab[i] = new Label();
                    lab[i].Text += "<table style='border: 1px solid #003366;' width='100%' Height='50px'>";
                    lab[i].Text += "<tr><td> " + dsdept.Tables[1].Rows[i][3].ToString() + "</td></tr>";
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
            else
            {

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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourismTravelagentformPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourismTravelagentformPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }









}