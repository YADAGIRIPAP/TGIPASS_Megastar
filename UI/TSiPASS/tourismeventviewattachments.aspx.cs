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
public partial class UI_TSiPASS_tourismeventviewattachments : System.Web.UI.Page
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
            da = new SqlDataAdapter("TE_getRetriveAttachmentsBytourismeventID", con.GetConnection);
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
            DataSet ds =GetdatadocumentbyintqueID(hdfFlagID0.Value.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                gvlastattachments.DataSource = ds.Tables[0];
                gvlastattachments.DataBind();
            }
            else
            {
               
            }
           
        }

        catch (Exception ex)
        {
           // lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourismEventPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourismEventPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }

}