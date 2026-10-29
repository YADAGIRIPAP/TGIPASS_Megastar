using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_ClusterReport : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DateTime fromdt, todt;
    DataSet dsdl = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../../Index.aspx");
            }
            if (!IsPostBack)
            {
                //txtFMDD.Text = DateTime.Today.Day.ToString();
                //txtFMMM.Text = DateTime.Today.Month.ToString();
                //txtFMYYYY.Text = DateTime.Today.Year.ToString();
                //txtTODD.Text = DateTime.Today.Day.ToString();
                //txtTOMM.Text = DateTime.Today.Month.ToString();
                //txtTOYYYY.Text = DateTime.Today.Year.ToString();

                BindDistricts(ddlDistrict);
                if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                {
                    ddlDistrict.Enabled = true;
                    ddlDistrict.SelectedValue = "ALL";
                    gvCluster.Columns[7].Visible = false;

                }
                else
                {
                    ddlDistrict.Enabled = false;
                    ddlDistrict.SelectedValue = (Session["DistrictID"].ToString().Trim());
                    gvCluster.Columns[7].Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            //fromdt = Convert.ToDateTime(txtFMYYYY.Text + "/" + txtFMMM.Text + "/" + txtFMDD.Text);
            //todt = Convert.ToDateTime(txtTOYYYY.Text + "/" + txtTOMM.Text + "/" + txtTODD.Text);
            //if (fromdt > todt)
            //{
            //    lblerrMsg.Text = "From date should be less than Todate";
            //    lblerrMsg.CssClass = "errormsg";
            //    valid = 1;
            //}
            //fromdt = txtFromDate.Text;
            //todt = txtTodate.Text;
            if (valid == 0)
            {
                string Distcd = ddlDistrict.SelectedValue;//(Session["DistrictID"].ToString().Trim());
                dsdl = Gen.GetClusterReport(txtFromDate.Text.Trim(), txtTodate.Text.Trim(), Distcd, null, null, null);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    if (Distcd == "ALL")
                    {
                        gvDistrictData.DataSource = dsdl.Tables[0];
                        gvDistrictData.DataBind();
                        trDistrictData.Visible = true;
                        trMandalData.Visible = false;
                        foreach (GridViewRow gvr in gvDistrictData.Rows)
                        {
                            LinkButton lbtn = (LinkButton)gvr.FindControl("LinkButton1");
                            Label lbl = (Label)gvr.FindControl("Label5");
                            if (lbtn.Text.ToUpper() == "TOTAL")
                            {
                                lbtn.Visible = false;
                                lbl.Visible = true;

                                GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                                GVR1.Style.Add("font-weight", "bold");
                                GVR1.Cells[0].Text = "";
                                //GVR1.Cells.RemoveAt(0);
                                //GVR1.Cells[0].ColumnSpan = 2;
                                //GVR1.Cells[0].Style.Add("text-align", "center");
                            }
                        }
                    }
                    else
                    {
                        gvMandalCount.DataSource = dsdl.Tables[0];
                        gvMandalCount.DataBind();
                        trMandalData.Visible = true;
                        trDistrictData.Visible = false;
                        foreach (GridViewRow gvr in gvMandalCount.Rows)
                        {
                            LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnMandal");
                            Label lbl = (Label)gvr.FindControl("lblMandalName");
                            if (lbtn.Text.ToUpper() == "TOTAL")
                            {
                                lbtn.Visible = false;
                                lbl.Visible = true;

                                GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                                GVR1.Style.Add("font-weight", "bold");
                                GVR1.Cells[0].Text = "";
                                //GVR1.Cells.RemoveAt(0);
                                //GVR1.Cells[0].ColumnSpan = 2;
                                //GVR1.Cells[0].Style.Add("text-align", "center");
                            }
                        }
                    }
                    trVillageData.Visible = false;
                    trClusterInfo.Visible = false;
                }
                else
                {
                    lblerrMsg.Text = "No Records Found";
                    gvDistrictData.DataSource = null;
                    gvDistrictData.DataBind();
                    gvMandalCount.DataSource = null;
                    gvMandalCount.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvMandalCount_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            //fromdt = Convert.ToDateTime(txtFMMM.Text + "/" + txtFMDD.Text + "/" + txtFMYYYY.Text);
            //todt = Convert.ToDateTime(txtTOMM.Text + "/" + txtTODD.Text + "/" + txtTOYYYY.Text);
            //if (fromdt > todt)
            //{
            //    lblerrMsg.Text = "From date should be less than Todate";
            //    lblerrMsg.CssClass = "errormsg";
            //}
            string mandalcd = e.CommandArgument.ToString();
            string Distcd = (Session["DistrictID"].ToString().Trim());
            dsdl = Gen.GetClusterReport(txtFromDate.Text.Trim(), txtTodate.Text.Trim(), null, mandalcd, null, null);
            if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
            {
                gvVillageData.DataSource = dsdl.Tables[0];
                gvVillageData.DataBind();
                trMandalData.Visible = false;
                trVillageData.Visible = true;
                trClusterInfo.Visible = false;
                trDistrictData.Visible = false;
                foreach (GridViewRow gvr in gvVillageData.Rows)
                {
                    LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnVillage");
                    Label lbl = (Label)gvr.FindControl("Label2");
                    if (lbtn.Text.ToUpper() == "TOTAL")
                    {
                        lbtn.Visible = false;
                        lbl.Visible = true;

                        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                        GVR1.Style.Add("font-weight", "bold");
                        GVR1.Cells[0].Text = "";
                        //GVR1.Cells.RemoveAt(0);
                        //GVR1.Cells[0].ColumnSpan = 2;
                        //GVR1.Cells[0].Style.Add("text-align", "center");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvVillageData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblerrMsg.Text = "";
        try
        {
            //fromdt = Convert.ToDateTime(txtFMMM.Text + "/" + txtFMDD.Text + "/" + txtFMYYYY.Text);
            //todt = Convert.ToDateTime(txtTOMM.Text + "/" + txtTODD.Text + "/" + txtTOYYYY.Text);
            //if (fromdt > todt)
            //{
            //    //lblerrMsg.Text = "From date should be less than Todate";
            //    //lblerrMsg.CssClass = "errormsg";
            //    //valid = 1;
            //}
            string villageCd = e.CommandArgument.ToString();
            string Distcd = (Session["DistrictID"].ToString().Trim());
            dsdl = Gen.GetClusterReport(txtFromDate.Text.Trim(), txtTodate.Text.Trim(), null, null, villageCd, null);
            if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
            {
                gvCluster.DataSource = dsdl.Tables[0];
                gvCluster.DataBind();
                trMandalData.Visible = false;
                trVillageData.Visible = false;
                trClusterInfo.Visible = true;
                trDistrictData.Visible = false;

            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvCluster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ClusterID = e.CommandArgument.ToString();
        if (e.CommandName == "VIEW")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('ClusterPrint.aspx?ClusterID=" + ClusterID + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        }
        else if (e.CommandName == "ALTER")
        {
            Session["CLUSTERID"] = ClusterID;
            foreach (GridViewRow gvr in gvCluster.Rows)
            {
                //LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnEdit");
                //lbtn.Attributes.Add("target", "_blank");
            }

            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('ClusterPrint.aspx?ClusterID=" + ClusterID + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        }
    }
    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlDistrict);
                //}
            }

            if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
            {
                AddAll(ddlDistrict);
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--District--");
            }

        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    public void AddAll(DropDownList ddl)
    {
        try
        {
            ListItem Li = new ListItem();
            Li.Text = "ALL";
            Li.Value = "ALL";
            ddl.Items.Insert(0, Li);
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
            lblerrMsg.Visible = true;
        }
    }
    protected void gvDistrictData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            //fromdt = Convert.ToDateTime(txtFMMM.Text + "/" + txtFMDD.Text + "/" + txtFMYYYY.Text);
            //todt = Convert.ToDateTime(txtTOMM.Text + "/" + txtTODD.Text + "/" + txtTOYYYY.Text);
            //if (fromdt > todt)
            //{
            //    //lblerrMsg.Text = "From date should be less than Todate";
            //    //lblerrMsg.CssClass = "errormsg";
            //    //valid = 1;
            //}
            string Distcd = e.CommandArgument.ToString();
            dsdl = Gen.GetClusterReport(txtFromDate.Text.Trim(), txtTodate.Text.Trim(), Distcd, null, null, null);
            if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
            {
                gvMandalCount.DataSource = dsdl.Tables[0];
                gvMandalCount.DataBind();
                trMandalData.Visible = true;
                trDistrictData.Visible = false;
                trVillageData.Visible = false;
                trClusterInfo.Visible = false;

                foreach (GridViewRow gvr in gvMandalCount.Rows)
                {
                    LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnMandal");
                    Label lbl = (Label)gvr.FindControl("lblMandalName");
                    if (lbtn.Text.ToUpper() == "TOTAL")
                    {
                        lbtn.Visible = false;
                        lbl.Visible = true;

                        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                        GVR1.Style.Add("font-weight", "bold");
                        GVR1.Cells[0].Text = "";
                        //GVR1.Cells.RemoveAt(0);
                        //GVR1.Cells[0].ColumnSpan = 2;
                        //GVR1.Cells[0].Style.Add("text-align", "center");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void BTNbACK_Click(object sender, EventArgs e)
    {
        if (trMandalData.Visible == true)
        {
            if (ddlDistrict.SelectedValue == "ALL")
            {
                trDistrictData.Visible = true;
            }
            else
            {
                trDistrictData.Visible = false;
            }
            trMandalData.Visible = false;
            trVillageData.Visible = false;
            trClusterInfo.Visible = false;
        }
        if (trVillageData.Visible == true)
        {
            trDistrictData.Visible = false;
            trMandalData.Visible = true;
            trVillageData.Visible = false;
            trClusterInfo.Visible = false;
        }
        if (trClusterInfo.Visible == true)
        {
            trDistrictData.Visible = false;
            trMandalData.Visible = false;
            trVillageData.Visible = true;
            trClusterInfo.Visible = false;
        }
    }
}