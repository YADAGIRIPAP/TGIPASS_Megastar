using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_RptApplicationWiseDetailedTrakerGroundwater : System.Web.UI.Page
{
    #region Declaration
    DataSet ds;
    string intqnreid;


    #endregion
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Convert.ToInt32(Request.QueryString.Count) > 0)
            {
                if(!string.IsNullOrEmpty(Request.QueryString[0]))
                {
                    if (Request.QueryString["intApplicationId"] != null)
                    {

                        intqnreid = Request.QueryString[0].ToString();
                    }
                    else
                    {
                        intqnreid = Request.QueryString[0].ToString();
                        //need to get applicationid by createduser
                    }

                    ds = ApplicationWiseDetailedTrakerGroundwater(intqnreid.ToString());
                    Session["Applid"] = intqnreid.ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        labUidNumber.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                        labName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                        labLineofActivity.Text = ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"].ToString();

                        labDOA.Text = ds.Tables[0].Rows[0]["PaymentDate"].ToString();
                        labAddress.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
                        lab_applicationstatus.Text = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        lbl_approverejectdate.Text = ds.Tables[0].Rows[0]["Approvalrejeteddate"].ToString();
                    }
                    grdDetails.DataSource = ds.Tables[1];
                    grdDetails.DataBind();
                }
            }
        }
       
       

       
    }

    public DataSet ApplicationWiseDetailedTrakerGroundwater(string Quesionary_id)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GW_RetriveR4ReportGroundwateruser", con);
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
                h1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                if (h1.Text!="" && h1.Text!=null)
                {
                    h1.Text = "Click Here";

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
           // lblmsg0.Text = ex.Message;
           // Failure.Visible = true;
        }
    }



}