using iTextSharp.text;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_SWGApplicationTracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                    Binddata();
                else { }
            }
        }
        else { }
    }

    public void Binddata()
    {
        try
        {
            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("USP_GETSWGTRACKER", connection))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Transaction = transaction;

                        da.SelectCommand.Parameters.AddWithValue("@SWGQDId", Convert.ToString(Request.QueryString[0]));

                        da.Fill(ds);
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                
                lblUidNumber.Text = ds.Tables[0].Rows[0]["UIDNo"].ToString();
                lblName.Text = ds.Tables[0].Rows[0]["SCD_PTINOWNERNAME"].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}