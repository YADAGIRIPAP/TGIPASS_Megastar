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
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;


public partial class UI_TSiPASS_ReleaseProceedingsPartialCase_BULK : System.Web.UI.Page
{
    DB.DB con = new DB.DB();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            btnGet_Click(sender, e);

        }

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        DataSet dsd = new DataSet();
        dsd = GET_TBL_ANNEXURE_II_SLC();
        if (dsd != null && dsd.Tables.Count > 0)
        {
            grdDetails.DataSource = dsd.Tables[0];
            grdDetails.DataBind();
            grdDetails.Visible = true;
        }
        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
            grdDetails.Visible = false;

        }
    }
        public DataSet GET_TBL_ANNEXURE_II_SLC()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_TBL_ANNEXURE_II_SLC", con.GetConnection);
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

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }

    protected void btnrollback_Click(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
       

        ReleasingProceedings frmvo = new ReleasingProceedings();
        frmvo.ReleasingSlcSpeacCaseAmount = row.Cells[5].Text;//PRESENT RELEASED AMOUNT 50 %
        frmvo.ReleasingSlcSpeacCaseDate = DateTime.Now.ToString("dd/MM/yyyy");
        frmvo.Remarks = "PARTIAL RELEASE";
        frmvo.GOSpeaclCaseNo = "204";//GO NUMBER
        frmvo.PendingAmount = row.Cells[8].Text;//PENDING AMOUNT  TO BE RELEASED LATER
        frmvo.SanctionSpecialCaseAmount = row.Cells[4].Text;//ACTUAL SANCTIOED AMOUNT

        frmvo.EnterperIncentiveID = row.Cells[6].Text;
        frmvo.slno = row.Cells[7].Text;//SLCNUMBER
        frmvo.MstIncentiveId = "6";
        frmvo.CreatedByid = "21345";
        int valid = InsertSlcspecialDetailspartial_BULK(frmvo);
        if (valid == 1)
        {

            string message = "alert('Details Updated Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            btnGet_Click(sender, e);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Details Not Updated... Please Try Again...');", true);
            return;
            //}
        }

        }
    public int InsertSlcspecialDetailspartial_BULK(ReleasingProceedings objvo)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("[USP_Update_SlcSpecialCaseDetals_partial_BULK]", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            //added by chinna
            cmd.Parameters.AddWithValue("@ReleaseSlcAmount", Convert.ToString(objvo.ReleasingSlcSpeacCaseAmount));
            cmd.Parameters.AddWithValue("@ReleaseSlcSpecicaseProcedingDate", Convert.ToString(objvo.ReleasingSlcSpeacCaseDate));
            cmd.Parameters.AddWithValue("@IncentiveId", Convert.ToString(objvo.EnterperIncentiveID));
            cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(objvo.MstIncentiveId));
            cmd.Parameters.AddWithValue("@GoNo", Convert.ToString(objvo.GOSpeaclCaseNo));
            cmd.Parameters.AddWithValue("@Remarks", Convert.ToString(objvo.Remarks));
            cmd.Parameters.AddWithValue("@ActualSanctionAmount", Convert.ToString(objvo.SanctionSpecialCaseAmount));
            cmd.Parameters.AddWithValue("@PendingAmount", Convert.ToString(objvo.PendingAmount));
            cmd.Parameters.AddWithValue("@slno", Convert.ToString(objvo.slno));
            cmd.Parameters.AddWithValue("@ModifiedBy", Convert.ToString(objvo.CreatedByid));



            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            valid = (Int32)cmd.Parameters["@Valid"].Value;
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }

        return valid;
    }
}