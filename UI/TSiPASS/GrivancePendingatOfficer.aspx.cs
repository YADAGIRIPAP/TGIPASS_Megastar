using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_GrivancePendingatOfficer : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] == null || Session["uid"].ToString() == "")
            {
                Response.Redirect("~/TSHome.aspx");

            }
            else
            {
                if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO"
                     || Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "DD")
                {
                    if (!IsPostBack)
                    {
                        binddata();
                    }
                }
                else { Response.Redirect("~/TSHome.aspx"); }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            return;
        }

    }
    protected void binddata()
    {
        try
        {
            string uid = Convert.ToString(Session["uid"]); string dist = Convert.ToString(Session["DistrictID"]);
            string role = Convert.ToString(Session["Role_Code"]);
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_GetGrievancePendingInteractions", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);
            da.SelectCommand.Parameters.Add("@RoleCode", SqlDbType.VarChar).Value = Convert.ToString(Session["Role_Code"]);

            da.Fill(ds);
            con.CloseConnection();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdUpdate.DataSource = ds.Tables[0];
                    grdUpdate.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    grdplatforms.DataSource = ds.Tables[1];
                    grdplatforms.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            return;
        }
    }
    
    protected void UpdateStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
            Label PIEEID = row.FindControl("InteractionID") as Label;

            if (PIEEID.Text != "")
            {
                string url = "Personal_Interaction_Page_EXISTING_Entrepreneursnew.aspx?HdnEnterpreneur_ID=" + PIEEID.Text+"&Status=Grievance";
                Response.Redirect(url);
            }
        }
        catch(Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            return;
        }

    }

    protected void UpdatePlatforms_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
            Label PIEEID = row.FindControl("InteractionID") as Label;
            Label Meesho = row.FindControl("lblMeesho") as Label;
            Label JustDial = row.FindControl("lblJustDial") as Label;
            Label TSGlobal = row.FindControl("lblTSGlobal") as Label; 
            Label Wallmart = row.FindControl("lblWallMart") as Label;
            Label InvoiceMart = row.FindControl("lblInvoiceMart") as Label;
            Label NSE = row.FindControl("lblNSE") as Label;
            Label SIDBI = row.FindControl("lblSIDBI") as Label;

            if (PIEEID.Text != "")
            {
                string url = "Personal_Interaction_Page_EXISTING_Entrepreneursnew.aspx?HdnEnterpreneur_ID=" + PIEEID.Text
                    + "&Meesho="+ Meesho.Text+ "&JustDial="+ JustDial.Text+ "&TSGlobal="+ TSGlobal.Text+ "&Wallmart="+ Wallmart.Text
                    + "&InvoiceMart="+ InvoiceMart.Text+"&NSE="+NSE.Text;
                Response.Redirect(url);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            return;
        }

    }
}