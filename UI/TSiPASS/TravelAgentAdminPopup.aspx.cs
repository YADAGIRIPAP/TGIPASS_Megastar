using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_TravelAgentAdminPopup : System.Web.UI.Page
{

    Cls_travelagent obj_travelagent = new Cls_travelagent();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet dscheck = new DataSet();
            dscheck = obj_travelagent.Get_TravelagentPOPUPDetailsNew(Request.QueryString[0].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count != 0)
            {
                lblUidNo.Text = dscheck.Tables[0].Rows[0]["UID_No"].ToString();
                lblNameOfUndertaker.Text = dscheck.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();

                lblNameOfPromoter.Text = dscheck.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                lblSonOf.Text = dscheck.Tables[0].Rows[0]["SoWo"].ToString();
                if (dscheck.Tables[0].Rows[0]["distid"].ToString().Trim() != "")
                {
                    lblDistrict0.Text = dscheck.Tables[0].Rows[0]["Addressofunit"].ToString();
                }
                else
                {
                    lblDistrict0.Text = dscheck.Tables[0].Rows[0]["distname"].ToString();
                }

                lblMobileNo.Text = dscheck.Tables[0].Rows[0]["MobileNumber"].ToString();
                lblEmail.Text = dscheck.Tables[0].Rows[0]["Email"].ToString();
                lblTelephone.Text = dscheck.Tables[0].Rows[0]["TelephoneNumber"].ToString();

            }

            if (dscheck != null && dscheck.Tables[0].Rows.Count > 0)
            {
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dscheck.Tables[1];
                    grdDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[5].Text == "Red")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[5].Text = "";
                }
                else if (e.Row.Cells[5].Text == "Green")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[5].Text = "";
                }
                else
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[5].Text = "";
                }

                if (e.Row.Cells[7].Text == "Red")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[7].Text = "";
                }
                else if (e.Row.Cells[7].Text == "Green")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[7].Text = "";
                }
                else
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[7].Text = "";
                }

                if (e.Row.Cells[8].Text == "Red")
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].Text = "";
                }
                else if (e.Row.Cells[8].Text == "Green")
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[8].Text = "";
                }
                else
                {
                    e.Row.Cells[8].Text = "";
                }

                if (e.Row.Cells[9].Text == "Pre-Scrutiny Stage" || e.Row.Cells[9].Text == "Approval Stage")
                {
                    e.Row.Cells[9].BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[9].Text = "";
                }



                if (e.Row.Cells[3].Text == "Yes" || e.Row.Cells[4].Text == "No")
                {

                    e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[6].Text = "";
                    if (e.Row.Cells[3].Text == "Yes")
                    {
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[8].Text = "";

                        e.Row.Cells[3].BackColor = System.Drawing.Color.Orange;
                        e.Row.Cells[3].Text = "";
                    }
                    else
                    {

                        if (e.Row.Cells[4].Text == "No")
                        {
                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {
        }

    }


}