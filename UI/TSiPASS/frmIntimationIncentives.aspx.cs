using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmIntimationIncentives : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (!IsPostBack)
            {

             
            }
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg0.Text = "";
            Failure.Visible = false;
            if (txtUniqueID.Text.Trim() != "")
            {
                DataSet ds = new DataSet();
                ds = gen.GetSanctionedIncentives(txtUniqueID.Text.Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                    lblmsg0.Text = "No Details Found";
                    Failure.Visible = true;
                }
            }
            else
            {
                lblmsg0.Text = "Please Enter Unique Number";
                Failure.Visible = true;
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
}