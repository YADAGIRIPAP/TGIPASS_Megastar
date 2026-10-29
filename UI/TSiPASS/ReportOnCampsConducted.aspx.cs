using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using static TSIPASSPropertiesModel;

public partial class UI_TSiPASS_ReportOnCampsConducted : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {
            if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "JD")
            {
                if (!IsPostBack)
                {
                    txtfrmdate.Text = "01-10-2023";
                    txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }

    }

    protected void BtnGetData_Click(object sender, EventArgs e)
    {
        string DistrictID = "";
        if (txttodate.Text != "" && txtfrmdate.Text != "")
        {
            if (Session["Role_Code"].ToString() == "GM")
            {
                DistrictID = Session["DistrictID"].ToString();
            }
            if (Session["Role_Code"].ToString() == "JD")
            {
                DistrictID = "%";
            }
            binddata(txtfrmdate.Text, txttodate.Text, DistrictID); 
        }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/ReportOnCampsConducted.aspx");
    }
    protected void binddata(string fromdate, string todate, string DistrictID)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_GetCampsConductedCount", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID;
             da.Fill(ds);
            con.CloseConnection();
            lblForGrid.Visible = true;
            grdsupport.DataSource = ds;
            grdsupport.DataBind();

        }
        catch (Exception Ex)
        { throw Ex; }

    }


    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hnewcount = (HyperLink)e.Row.Cells[2].Controls[0];
            hnewcount.NavigateUrl = "CampsConductedDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim()+"& Type=New" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;
            HyperLink hextcount = (HyperLink)e.Row.Cells[3].Controls[0];
            hextcount.NavigateUrl = "CampsConductedDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=Existing" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;
        }
    }
}