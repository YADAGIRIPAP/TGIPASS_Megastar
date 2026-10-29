using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ClusterAbstractReportPublic : System.Web.UI.Page
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


                BindYears(ddlyear);
                BindMonths(ddlmonth);
                ddlyear.SelectedValue = DateTime.Now.Year.ToString();
                ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
            }
        }
        catch (Exception)
        {

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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, null, null, null);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvinspection.DataSource = ds.Tables[0];
            gvinspection.DataBind();
            //trMandalData.Visible = true;
            trdistrictwise.Visible = false;
            trCentralInfo.Visible = false;
            trabstract.Visible = true;
            foreach (GridViewRow gvr in gvinspection.Rows)
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
    protected void BTNbACK_Click(object sender, EventArgs e)
    {

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
            string RetrievalFlag = "GRID";
            string deptname = e.CommandArgument.ToString();
            Session["DEptname"] = deptname;
            dsdl = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, null, null);
            if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
            {
                gvdist.DataSource = dsdl.Tables[0];
                gvdist.DataBind();
                //trMandalData.Visible = true;
                trCentralInfo.Visible = false;
                trabstract.Visible = false;
                trdistrictwise.Visible = true;

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
            if (Session["DEptname"] != null)
            {
                deptname = Session["DEptname"].ToString();
            }
            string distcd = e.CommandArgument.ToString();
            dsdl = Gen.GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, distcd, null);
            if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
            {
                gvCluster.DataSource = dsdl.Tables[0];
                gvCluster.DataBind();
                //trMandalData.Visible = true;
                trCentralInfo.Visible = true;
                trabstract.Visible = false;
                trdistrictwise.Visible = false;

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
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
}