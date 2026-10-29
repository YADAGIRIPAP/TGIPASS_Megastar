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

public partial class UI_TSiPASS_frmViewAttachmentDetailsTourismAgent_User : System.Web.UI.Page
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
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
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

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
            DataSet ds = GetdatadocumentbyintqueID(hdfFlagID0.Value.ToString());
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