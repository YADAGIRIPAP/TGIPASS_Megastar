using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_TourismEventPopUp : System.Web.UI.Page
{
    Cls_TourismDashboard obj_dashboard = new Cls_TourismDashboard();
    DataSet ds = new DataSet(); 
    String ComplaintNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Session.Count <= 0)
            //{
            //    Response.Redirect("../../Index.aspx");
            //}
            DataSet dscheck = new DataSet();
            dscheck = obj_dashboard.tourevent_GetShowQuestionariesbyUIDPOP(Request.QueryString[0].ToString().Trim());


            if (dscheck.Tables[0].Rows.Count > 0)
            {
                //Response.Redirect("ApplicationTrakerDetailed.aspx?ID=" + dscheck.Tables[0].Rows[0]["TourismPerformanceLicenseID"].ToString().Trim());
                //Session["Applid"] = dscheck.Tables[0].Rows[0]["TourismPerformanceLicenseID"].ToString().Trim();

                lblUidNo.Text = dscheck.Tables[0].Rows[0]["UID_no"].ToString();
                lblNameOfUndertaker.Text = dscheck.Tables[0].Rows[0]["NameAddEventManagement"].ToString();
                lblNameOfPromoter.Text = dscheck.Tables[0].Rows[0]["NameofTheApplicant"].ToString();
                lblSonOf.Text = dscheck.Tables[0].Rows[0]["FatherName"].ToString();
                if (dscheck.Tables[0].Rows[0]["District"].ToString().Trim() != "")
                {
                    lblDistrict0.Text = dscheck.Tables[0].Rows[0]["NameLocPerformance"].ToString();
                }
                else
                {
                    lblDistrict0.Text = dscheck.Tables[0].Rows[0]["District_Name"].ToString();
                }
                lblMobileNo.Text = dscheck.Tables[0].Rows[0]["MobileNumber"].ToString();
                lblEmail.Text = dscheck.Tables[0].Rows[0]["Email"].ToString();
                lblTelephone.Text = dscheck.Tables[0].Rows[0]["MobileNumber"].ToString();
                Session["Applid"] = dscheck.Tables[0].Rows[0]["TourismPerformanceLicenseID"].ToString();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {
                DataSet dsnew = new DataSet();

                dsnew = obj_dashboard.tourevent_getEnterprenuerdatabyQues(Session["Applid"].ToString());

                if (dsnew != null && dsnew.Tables[0].Rows.Count > 0)
                {
                    ComplaintNo = dsnew.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                    DataSet ds = new DataSet();
                    ds = obj_dashboard.tourismevent_GetQuestionereispopup(Session["Applid"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = ds.Tables[1];
                        grdDetails.DataBind();
                    }
                }
            }
          
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            // Failure.Visible = true;
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
                    //   e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[8].Text = "";
                }

                if (e.Row.Cells[9].Text == "Pre-Scrutiny Stage" || e.Row.Cells[9].Text == "Approval Stage")
                {
                    e.Row.Cells[9].BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    //   e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[9].Text = "";
                }



                if (e.Row.Cells[3].Text == "Yes" || e.Row.Cells[4].Text == "No")
                {

                    e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[6].Text = "";

                    // e.Row.Cells[3].BackColor = System.Drawing.Color.Navy;

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
                            //e.Row.Cells[8].BackColor = System.Drawing.Color.White;
                            //e.Row.Cells[8].Text = "";
                            //e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                            //e.Row.Cells[7].Text = "";
                        }
                    }

                }

                //   e.Row.Cells[3].Text = "";

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }

    }

  


}