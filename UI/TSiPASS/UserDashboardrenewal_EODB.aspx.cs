using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UI_TSiPASS_UserDashboardrenewal_EODB : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;


    DataSet dslist;
    string intqnreid;

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        { 
        }
        intqnreid = "106629";
        ds = ApplicationWiseDetailedTrakerREN(intqnreid.ToString());
        Session["Applid"] = intqnreid.ToString();

        if (ds.Tables[0].Rows.Count > 0)
        {
            labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            labNameandAddress.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
            labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            //labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
            lblindustryscale.Text= ds.Tables[0].Rows[0]["Ent_is"].ToString();
            lblriskcategory.Text= ds.Tables[0].Rows[0]["Pol_Category"].ToString();
        }
        grdDetails.DataSource = ds.Tables[1];
        grdDetails.DataBind();
    }
    #endregion
    public DataSet ApplicationWiseDetailedTrakerREN(string Quesionary_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_USERDASHBOARD_EODB_RENEWAL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Quesionary_id.Trim() == "" || Quesionary_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = Quesionary_id.ToString();

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

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        //dsnew = Gen.GetDistricts1();
        //ddldistrict.DataSource = dsnew.Tables[0];
        //ddldistrict.DataTextField = "District_Name";
        //ddldistrict.DataValueField = "District_Id";
        //ddldistrict.DataBind();
        //ddldistrict.Items.Insert(0, "--Select--");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //ddldistrict.SelectedIndex = 0;
        //  txtRegDate.Text = "";
        //  ddlCategory.SelectedIndex = 0;

    }


    protected void BtnSave1_Click(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lbl = (e.Row.FindControl("lblFileName") as Label);
        //        HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLink2") as HyperLink);
        //        if (lbl.Text != "")
        //        {
        //            string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "linknew"));
        //            if (filepathnew != "")
        //            {

        //                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
        //                HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
        //            }
        //            else
        //            {
        //                HyperLinkSubsidy.Visible = false;
        //            }
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    ////lblmsg0.Text = "Internal error has occured. Please try after some time";
        //    //lblmsg0.Text = ex.Message;
        //    //Failure.Visible = true;
        //    //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        //}
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NumberofApprovalsappliedfor"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
        //    Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;


        //}

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
        //    e.Row.Cells[3].Text = Completed1.ToString();
        //    e.Row.Cells[4].Text = QueryRaised1.ToString();
        //    e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
        //    e.Row.Cells[6].Text = Pendingmorthan3days1.ToString();
        //    e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        //}
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


            TableCell HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();



            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderGridRow.Cells.Add(HeaderCell);




            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Applicant Status on Approvals";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Pre-Scrutiny Status ";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Payment Status ";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Approval Status ";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);


            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }
}