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

public partial class UI_TSiPASS_CentralInspectionSystemReport : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                //txtFMDD.Text = DateTime.Today.Day.ToString();
                //txtFMMM.Text = DateTime.Today.Month.ToString();
                //txtFMYYYY.Text = DateTime.Today.Year.ToString();
                //txtTODD.Text = DateTime.Today.Day.ToString();
                //txtTOMM.Text = DateTime.Today.Month.ToString();
                //txtTOYYYY.Text = DateTime.Today.Year.ToString();
                DateTime today = DateTime.Today;
                //txtFromDate.Text = today.ToString("dd-MM-yyyy");
                txtTodate.Text = today.ToString("dd-MM-yyyy");

                BindYears(ddlyear);
                BindMonths(ddlmonth);
                ddlyear.SelectedValue = DateTime.Now.Year.ToString();
                ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
        }
    }

    public void BindYears(DropDownList ddlyears)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlyear.Items.Clear();
            dsd = Gen.GetYEARS();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlyear.DataSource = dsd.Tables[0];
                ddlyear.DataValueField = "Year";
                ddlyear.DataTextField = "Year";
                ddlyear.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlDistrict);
                //}
            }


        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void BindMonths(DropDownList ddlmonths)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlmonth.Items.Clear();
            dsd = Gen.GetMONTHS();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlmonth.DataSource = dsd.Tables[0];
                ddlmonth.DataValueField = "intMonthid";
                ddlmonth.DataTextField = "MonthName";
                ddlmonth.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlDistrict);
                //}
            }


        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            string FromdateforDB = "", TodateforDB = "";
            lblDeptName.Text = "";
            if (txtFromDate.Text != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            ds = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, null, null, null, FromdateforDB, TodateforDB);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                trdate.Visible = true;
                trprint.Visible = true;
                gvinspection.DataSource = ds.Tables[0];
                gvinspection.DataBind();
                //trMandalData.Visible = true;
                trdistrictwise.Visible = false;
                trCentralInfo.Visible = false;
                trabstract.Visible = true;
                trjoint.Visible = false;
                foreach (GridViewRow gvr in gvinspection.Rows)
                {
                    LinkButton lbtn = (LinkButton)gvr.FindControl("LinkButton1");
                    Label lbl = (Label)gvr.FindControl("Labeldept");
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
                    if (lbtn.Text.ToUpper() == "PCB DEPARTMENT" || lbtn.Text.ToUpper().Contains("BOILER"))
                    {
                        lbtn.Visible = false;
                        lbl.Visible = true;
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    // lbldate.Text = ds.Tables[1].Rows[0]["InspectionSechduleInsertDate"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void gvinspection_RowCommand(object sender, GridViewCommandEventArgs e)
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

            //int introwIndex = gvinspection.Rows[index];
            string RetrievalFlag = "GRID";
            string status = "";
            string deptname = "";
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (e.CommandName.ToString() == "Department")
            {
                lblDeptName.Text = e.CommandArgument.ToString();
                deptname = e.CommandArgument.ToString();
                status = null;
                dsdl = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, null, status, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    gvdist.DataSource = dsdl.Tables[0];
                    gvdist.DataBind();
                    //trMandalData.Visible = true;
                    trCentralInfo.Visible = false;
                    trabstract.Visible = false;
                    trdistrictwise.Visible = true;
                    trjoint.Visible = false;
                    foreach (GridViewRow gvr in gvdist.Rows)
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
            }
            else
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                Label lblProdId = (Label)row.FindControl("Labeldept");
                //int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = gvinspection.Rows[index];
                deptname = lblProdId.Text;
                status = e.CommandName.ToString();
                dsdl = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, null, status, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    if (deptname.Contains("Joint Inspection with"))
                    {

                        trjoint.Visible = true;
                        grdjoint.DataSource = dsdl.Tables[0];
                        grdjoint.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = false;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                    }
                    else
                    {

                        gvCluster.DataSource = dsdl.Tables[0];
                        gvCluster.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = true;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                        trjoint.Visible = false;
                    }
                    //foreach (GridViewRow gvr in gvCluster.Rows)
                    //{
                    //    LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnMandal");
                    //    Label lbl = (Label)gvr.FindControl("lblMandalName");
                    //    if (lbtn.Text.ToUpper() == "TOTAL")
                    //    {
                    //        lbtn.Visible = false;
                    //        lbl.Visible = true;

                    //        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                    //        GVR1.Style.Add("font-weight", "bold");
                    //        GVR1.Cells[0].Text = "";

                    //    }
                    //}
                }

            }
            Session["DEptname"] = deptname;


        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvdist_RowCommand(object sender, GridViewCommandEventArgs e)
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
            string RetrievalFlag = "GRID";
            string deptname = "";
            string status = "";
            string distcd = "";
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (Session["DEptname"] != null)
            {
                deptname = Session["DEptname"].ToString();
            }
            if (e.CommandName.ToString() == "DISTRICT")
            {
                distcd = e.CommandArgument.ToString();
                status = null;


                //string distcd = e.CommandArgument.ToString();
                dsdl = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, distcd, null, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    // if (deptname == "Joint Inspection with Labour & Factories Departments")
                    if (deptname.Contains("Joint Inspection with"))
                    {

                        trjoint.Visible = true;
                        grdjoint.DataSource = dsdl.Tables[0];
                        grdjoint.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = false;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                    }
                    else
                    {

                        gvCluster.DataSource = dsdl.Tables[0];
                        gvCluster.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = true;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                        trjoint.Visible = false;
                        if (e.CommandName == "VIEW")
                        {
                            // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('ClusterPrint.aspx?ClusterID=" + ClusterID + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
                        }
                    }
                    //foreach (GridViewRow gvr in gvCluster.Rows)
                    //{
                    //    LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnMandal");
                    //    Label lbl = (Label)gvr.FindControl("lblMandalName");
                    //    if (lbtn.Text.ToUpper() == "TOTAL")
                    //    {
                    //        lbtn.Visible = false;
                    //        lbl.Visible = true;

                    //        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                    //        GVR1.Style.Add("font-weight", "bold");
                    //        GVR1.Cells[0].Text = "";

                    //    }
                    //}
                }
            }
            else
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                Label lblProdId = (Label)row.FindControl("Label5");
                distcd = lblProdId.Text;
                status = e.CommandName.ToString();
                dsdl = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, distcd, status, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    //if (deptname == "Joint Inspection with Labour & Factories Departments")
                    if (deptname.Contains("Joint Inspection with"))
                    {
                        trjoint.Visible = true;
                        grdjoint.DataSource = dsdl.Tables[0];
                        grdjoint.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = false;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                    }
                    else
                    {
                        trdate.Visible = true;
                        gvCluster.DataSource = dsdl.Tables[0];
                        gvCluster.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = true;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                        trjoint.Visible = false;
                        if (e.CommandName == "VIEW")
                        {
                            // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('ClusterPrint.aspx?ClusterID=" + ClusterID + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
                        }
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=CentralInspectionSystem" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                if (trabstract.Visible == true)
                {
                    gvinspection.RenderControl(hw);
                }
                else if (trdistrictwise.Visible == true)
                {
                    gvdist.RenderControl(hw);
                }
                else if (trCentralInfo.Visible == true)
                {
                    gvCluster.RenderControl(hw);
                }

                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    //protected void BTNbACK_Click(object sender, EventArgs e)
    //{
    //    if (trdistrictwise.Visible == true)
    //    {
    //        trdistrictwise.Visible = false;
    //        trabstract.Visible = true;
    //    }        
    //}
    protected void grdjoint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string regnno = e.CommandArgument.ToString();
        string deptname = Session["DEptname"].ToString();
        string year = ddlyear.SelectedItem.Text.Trim();
        string month = ddlmonth.SelectedValue;
        if (e.CommandName == "VIEW")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('CentralInspectionPrint.aspx?regnno=" + regnno + "&query1=" + deptname + "&query2=" + year + "&query3=" + month + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        }
    }
    protected void gvCluster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string regnno = e.CommandArgument.ToString();
        string deptname = Session["DEptname"].ToString();
        string year = ddlyear.SelectedItem.Text.Trim();
        string month = ddlmonth.SelectedValue;
        if (e.CommandName == "VIEW")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('CentralInspectionPrint.aspx?regnno=" + regnno + "&query1=" + deptname + "&query2=" + year + "&query3=" + month + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        }
    }

    protected void grdjoint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Finding label
            HyperLink HyperLinkfactory = (HyperLink)e.Row.FindControl("HyperLinkfactory");
            HyperLink HyperLinklabour = (HyperLink)e.Row.FindControl("HyperLinklabour");
            if (HyperLinklabour.NavigateUrl.Trim() == "")
            {
                HyperLinklabour.Visible = false;
               
            }
            if (HyperLinkfactory.NavigateUrl.Trim() == "")
            {
                HyperLinkfactory.Visible = false;
            }
        }
        if (lblDeptName.Text.Trim() == "Joint Inspection with Labour Department")
        {
            //grdjoint.
            e.Row.Cells[10].Visible = false;
        }
        else if (lblDeptName.Text.Trim() == "Joint Inspection with Factories Department")
        {
            //grdjoint.
            e.Row.Cells[9].Visible = false;

        }
        //if (lblDeptName.Text.Trim() == "Joint Inspection with Labour Department")
        //{
        //    //grdjoint.
        //    e.Row.Cells[10].Visible = false;
        //}
    }
}