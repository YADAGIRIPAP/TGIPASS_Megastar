using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_RptApplicationWiseDetailedTrakerFilmShooting : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    #region Declaration
    int Sno = 0;
    DataSet ds;
    DataTable dt;
    DataSet dslist;
    string intqnreid;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        if (Request.QueryString["intqnreid"] != null)
        {

            intqnreid = Request.QueryString[0].ToString();
        }
        else
        {
            intqnreid = Request.QueryString[0].ToString();
            //need to get applicationid by createduser
        }
        ds = ApplicationWiseDetailedTrakerFilmshooting(intqnreid.ToString());
        Session["Applid"] = intqnreid.ToString();

        if (ds.Tables[0].Rows.Count > 0)
        {
            labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            labNameandAddress.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
            labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
        }
        grdDetails.DataSource = ds.Tables[1];
        grdDetails.DataBind();
    }



    public DataSet ApplicationWiseDetailedTrakerFilmshooting(string Quesionary_id)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FS_RetriveR4Reportfilmshooting", con);
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
            con.Close();
        }
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