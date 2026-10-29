using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.IO;


public partial class UI_TSiPASS_AssignSVCDatePrint : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    static GridView gvdetailsnew2 = new GridView();
    static string filename = "";
    static string ExcelHeading = "";
    DataTable dt2 = new DataTable();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string paths = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
            }
            if (!IsPostBack)
            {
                filename = "iPASS Excel Download";
                ExcelHeading = "";
                gvdetailsnew2.DataSource = null;
                gvdetailsnew2.DataBind();

                string Stagenew = Request.QueryString["Stage"].ToString().Trim();
                if (Stagenew != "2")
                {
                    trdatefld.Visible = false;
                }
                string Cast = Request.QueryString[0].ToString();
                string Investmentid = Request.QueryString[1].ToString();
                h1heading.InnerHtml = Cast + " Category";
                txtsvcdate.Text = Request.QueryString[2].ToString();
                string proposedSvcDate = Request.QueryString[3].ToString();
                string status = "1";
                string distid = Session["DistrictID"].ToString().Trim();

                if (proposedSvcDate == "0" || proposedSvcDate == "")
                {
                    proposedSvcDate = "0";
                }
                else
                {
                    string[] date = proposedSvcDate.Split(' ');
                    string[] date1 = date[0].Split('-');
                    proposedSvcDate = date1[2] + "/" + date1[1] + "/" + date1[0];
                }

                DataSet ds = new DataSet();

                ds = Gen.getReleaseProceedingsAssignSVCAgenda(Cast, Investmentid, proposedSvcDate, Stagenew);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = ds.Tables[0];
                    gvdetailsnew.DataBind();

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 1; i < ds.Tables[2].Rows.Count; i++)
                        {
                            if (ds.Tables[2].Rows[i][0].ToString().Trim() == ds.Tables[2].Rows[i - 1][0].ToString().Trim())
                            {

                                ds.Tables[2].Rows[i - 1][9] = ds.Tables[2].Rows[i - 1][9].ToString().Trim() + ", " + ds.Tables[2].Rows[i][9].ToString().Trim();
                                ds.Tables[2].Rows.RemoveAt(i);
                                i = i - 1;
                            }
                        }

                        dt2 = ds.Tables[2];
                        dt2.Columns.RemoveAt(6);
                        dt2.Columns.RemoveAt(6);
                        dt2.Columns.RemoveAt(6);
                        dt2.Columns.RemoveAt(2);

                        dt2.Columns[0].ColumnName = "Slno";
                        //dt2.Columns[0].DataType = typeof(string);
                        dt2.Columns[1].ColumnName = "Name Of Unit and Address";
                        dt2.Columns[2].ColumnName = "Scheme";
                        dt2.Columns[3].ColumnName = "Recommended Amount";
                        dt2.Columns[4].ColumnName = "Incentive ID";
                        dt2.Columns[5].ColumnName = "Line of Activity";

                        dt2.Columns["Incentive ID"].SetOrdinal(1);
                        dt2.Columns["Line of Activity"].SetOrdinal(4);

                        gvdetailsnew2.RowDataBound += new GridViewRowEventHandler(gvdetailsnew2_RowDataBound);
                        gvdetailsnew2.DataSource = dt2;
                        gvdetailsnew2.DataBind();
                    }

                    btnPrint.Visible = true;
                    if (Stagenew == "5")
                    {
                        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "  -- Rejected Applications";
                        filename = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "_Rejected Applications";
                        ExcelHeading = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + " " + proposedSvcDate.Split('/')[0].ToString().Trim() + "-" + GetDateValue(proposedSvcDate.Split('/')[1].ToString().Trim(), "M") + "-" + proposedSvcDate.Split('/')[2].ToString().Trim();
                    }
                    else if (Stagenew == "3" || Stagenew == "4")
                    {
                        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "  -- SVC Approved Applications";
                        filename = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "_SVC Approved Applications";
                        ExcelHeading = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + " " + proposedSvcDate.Split('/')[0].ToString().Trim() + "-" + GetDateValue(proposedSvcDate.Split('/')[1].ToString().Trim(), "M") + "-" + proposedSvcDate.Split('/')[2].ToString().Trim();
                    }
                    else if (Stagenew == "10")
                    {
                        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "  -- Total Applications(Approved and Rejected)";
                        filename = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "_Total Applications_Approved_Rejected";
                        ExcelHeading = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + " " + proposedSvcDate.Split('/')[0].ToString().Trim() + "-" + GetDateValue(proposedSvcDate.Split('/')[1].ToString().Trim(), "M") + "-" + proposedSvcDate.Split('/')[2].ToString().Trim();
                    }
                    else
                    {
                        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "  -- Total Applications(Pending,Approved and Rejected)";
                        filename = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + "_Total Applications_Pending_Approved_Rejected";
                        ExcelHeading = ds.Tables[1].Rows[0]["IncentiveName"].ToString() + " " + proposedSvcDate.Split('/')[0].ToString().Trim() + "-" + GetDateValue(proposedSvcDate.Split('/')[1].ToString().Trim(), "M") + "-" + proposedSvcDate.Split('/')[2].ToString().Trim();
                    }
                    if (Stagenew == "5" || Stagenew == "10")
                    {
                        gvdetailsnew.Columns[6].Visible = true;

                    }
                    else
                    {
                        gvdetailsnew.Columns[6].Visible = false;
                    }
                }
                else
                {
                    btnPrint.Visible = false;
                }

                if (Request.QueryString.Count > 0)
                {
                    //ddlstatus.SelectedValue = status;
                    //ddlstatus.Enabled = false;
                    //ddlDistrict.SelectedValue = distid;
                    //ddlDistrict.Enabled = false;
                    //grdDetails.Columns[7].Visible = false;
                    //grdDetails.Columns[8].Visible = false;
                }
                else
                {
                    //ddlstatus.SelectedIndex = 0;
                    //ddlstatus.Enabled = true;
                    //ddlDistrict.SelectedValue = distid;
                    //ddlDistrict.Enabled = false;
                }
                //if (!IsPostBack)
                //{
                //    fetchIncentivedet();
                //}
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    protected void GetDepartment()
    {

    }


    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            fetchIncentivedet();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }


    protected void fetchIncentivedet()
    {
        try
        {
            DataSet ds = new DataSet();

            ds = Gen.fetchIncentivedetIPONewIncTypeAddlDirector(Session["uid"].ToString(), "3", "", "");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                btnPrint.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    protected void gvdetailsnew2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Amount = e.Row.Cells[5].Text.ToString().Trim();
            Amount = Amount + " (" + Gen.NumberToWord(Convert.ToInt32(Amount.Split('.')[0].ToString().Trim())) + " Rupees)";
            e.Row.Cells[5].Text = Amount;
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.ForeColor = System.Drawing.Color.Black;
            e.Row.Font.Bold = true;
        }
    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + "_" + DateTime.Now.ToString("dd-MMM-yyyy HH-mm-ss") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //DataSet dsnew = new DataSet();

                //dsnew = Gen.getdataofDistrictlevel1(ddlConnectLoad.SelectedItem.Text.ToString(), txtUnitname.Text);

                //GridExport.DataSource = dsnew.Tables[0];
                //GridExport.DataBind();

                gvdetailsnew2.RenderControl(hw);
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + ExcelHeading + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }

    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected string GetDateValue(string NumberFormat, string DatePart)
    {
        string StringFormat = string.Empty;

        if (DatePart == "M")
        {
            switch (NumberFormat)
            {
                case "01":
                    StringFormat = "Jan";
                    break;
                case "02":
                    StringFormat = "Feb";
                    break;
                case "03":
                    StringFormat = "Mar";
                    break;
                case "04":
                    StringFormat = "Apr";
                    break;
                case "05":
                    StringFormat = "May";
                    break;
                case "06":
                    StringFormat = "Jun";
                    break;
                case "07":
                    StringFormat = "Jul";
                    break;
                case "08":
                    StringFormat = "Aug";
                    break;
                case "09":
                    StringFormat = "Sep";
                    break;
                case "10":
                    StringFormat = "Oct";
                    break;
                case "11":
                    StringFormat = "Nov";
                    break;
                case "12":
                    StringFormat = "Dec";
                    break;
            }
        }

        return StringFormat;
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        //ExportToExcel();
    }

}