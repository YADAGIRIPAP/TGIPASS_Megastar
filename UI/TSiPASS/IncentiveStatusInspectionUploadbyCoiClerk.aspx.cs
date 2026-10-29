using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UI_TSiPASS_IncentiveStatusInspectionUploadbyCoiClerk : System.Web.UI.Page
{
    General Gen = new General();
    string status = "";
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("/ipasslogin.aspx");
        }
        status = Request.QueryString[0].ToString().Trim();

        if (!IsPostBack)
        {
            getdistricts();
            FetchDetails();

        }
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        DrpDist.Items.Clear();
        DrpDist.DataSource = dsnew.Tables[0];
        DrpDist.DataTextField = "District_Name";
        DrpDist.DataValueField = "District_Id";
        DrpDist.DataBind();
        DrpDist.Items.Insert(0, new ListItem("Select District", "0"));


        DropDownList1.Items.Clear();
        DropDownList1.DataSource = dsnew.Tables[0];
        DropDownList1.DataTextField = "District_Name";
        DropDownList1.DataValueField = "District_Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select District", "0"));



    }
    private void FetchDetails()
    {
        DataSet ds = new DataSet();


        ds = CoifetchIncentivedetIPONewIncType(Session["uid"].ToString(), status);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (Request.QueryString[0].ToString().Trim() == "54" || Request.QueryString[0].ToString().Trim() == "55" || Request.QueryString[0].ToString().Trim() == "56" ||
                Request.QueryString[0].ToString().Trim() == "83" || Request.QueryString[0].ToString().Trim() == "84")
            {
                trNEW2.Visible = true;
                trNEW1.Visible = false;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                trNEW2.Visible = false;
                trNEW1.Visible = true;
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }
    }


    protected void anchortaglink_Click(object sender, EventArgs e)
    {
        Button ddlDeptnameFnl2 = (Button)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

        Label enterid = (Label)row.FindControl("lblIncentiveID");
        string status = Request.QueryString[0].ToString().Trim();
        Button Button1 = (Button)row.FindControl("anchortaglink");
        Label Incids = (Label)row.FindControl("lblIncentiveIDS");
        string newurl = "ApplicantIncentiveDtlsnew.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status + "&IncIds=" + Incids.Text.Trim();
        Response.Redirect(newurl);
    }

    public DataSet CoifetchIncentivedetIPONewIncType(string intDeptid, string status)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("usp_GetJdForwardedApplications_LEVEL_CLERK", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();
            da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = status.ToString();


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

    protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString[0].ToString().Trim() == "80")
            {
                int gvrcnt = gvdetailsnew.Rows.Count;
                Button btnprocess;

                if (Session["uid"].ToString() == "127573")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                        Label enterid = (Label)e.Row.FindControl("lblIncentiveID");
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            if (lblsector_GM.Text == "Manufacture" || enterid.Text == "247293"|| enterid.Text =="140123" || enterid.Text == "257928")
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = true;// need to rollback
                            }
                            else
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = false;// need to rollback
                            }
                            //if (enterid.Text == "229583" || enterid.Text == "232607" || enterid.Text == "232607" || enterid.Text == "220015")
                            //{
                            //    btnprocess = (Button)e.Row.FindControl("Button1");
                            //    btnprocess.Enabled = true;// false }
                            //}
                            //else
                            //{
                            //    btnprocess = (Button)e.Row.FindControl("Button1");
                            //    btnprocess.Enabled = false;
                            //}
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161020")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161019")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161017")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161018")
                {
                    Label lbldist = (Label)e.Row.FindControl("lblDistID");
                    Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                                        Label enterid1 = (Label)e.Row.FindControl("lblIncentiveID");

                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (lbldist.Text == "29" || lbldist.Text == "12" || lbldist.Text == "13" || lbldist.Text == "9"|| enterid1.Text== "265926")
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {

                            if (i == 0)
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = false;
                            }
                            else
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = false;

                            }

                        }

                    }
                }
                else if (Session["uid"].ToString() == "127574")
                {
                    Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                    Label enterid1 = (Label)e.Row.FindControl("lblIncentiveID");
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0 )
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            //btnprocess = (Button)e.Row.FindControl("Button1");
                            //btnprocess.Enabled = true;// need to rollback
                            if (lblsector_GM.Text == "Manufacture")
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = true;// need to rollback
                            }
                            else
                            {
                                if (enterid1.Text == "253512" || enterid1.Text == "246892" || enterid1.Text == "246515" || enterid1.Text == "247376" || enterid1.Text == "243498" || enterid1.Text == "180551")
                                {
                                    btnprocess = (Button)e.Row.FindControl("Button1");
                                    btnprocess.Enabled = false;// need to rollback
                                }
                                else
                                {
                                    btnprocess = (Button)e.Row.FindControl("Button1");
                                    btnprocess.Enabled = false;// need to rollback}

                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= gvrcnt; i++)
                    {
                        Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;

                        }
                    }
                }
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString[0].ToString().Trim() == "55")
            {
                int gvrcnt = GridView1.Rows.Count;
                Button btnprocess;
                if (Session["uid"].ToString() == "127573")
                {
                    Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            //btnprocess = (Button)e.Row.FindControl("Button1");
                            //btnprocess.Enabled = true;
                            if (lblsector_GM.Text == "Manufacture")
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = true;// need to rollback
                            }
                            else
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = false;// need to rollback
                            }
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161019")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161020")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else if (Session["uid"].ToString() == "127574")
                {
                    Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0 )
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            //btnprocess = (Button)e.Row.FindControl("Button1");
                            //btnprocess.Enabled = true;
                            if (lblsector_GM.Text == "Manufacture")
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = true;// need to rollback
                            }
                            else
                            {
                                btnprocess = (Button)e.Row.FindControl("Button1");
                                btnprocess.Enabled = false;// need to rollback
                            }

                        }

                    }
                }
                else if (Session["uid"].ToString() == "161017")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else if (Session["uid"].ToString() == "161018")
                {
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        if (i == 0)
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                    }
                }
                else
                {

                    for (int i = 0; i <= gvrcnt; i++)
                    {
                        Label lblsector_GM = (Label)e.Row.FindControl("lblsector_GM");
                        Label enterid1 = (Label)e.Row.FindControl("lblIncentiveID");

                        if (i == 0|| enterid1.Text== "265926")
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;
                        }
                        else
                        {
                            btnprocess = (Button)e.Row.FindControl("Button1");
                            btnprocess.Enabled = false;

                        }
                    }
                }
            }
        }
    }

}