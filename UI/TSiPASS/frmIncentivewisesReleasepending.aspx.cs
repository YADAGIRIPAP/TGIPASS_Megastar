using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
 
using System.Globalization;

using System.Data.SqlClient;


public partial class UI_TSIPASS_frmIncentivewisesReleasepending : System.Web.UI.Page
{

    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            financialYear();
            reportMethod();
            Label1.Text = "Report as on date " + DateTime.Now;
        }
        
       
    }

    public void reportMethod()
    {
        osqlConnection.Open();
        SqlDataAdapter da;
        DataSet oDataSet = new DataSet();
        if(ddlFinyear.SelectedItem.Text!=""  )
        {
            da = new SqlDataAdapter("releasePendingIncentives", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@finyear", SqlDbType.VarChar).Value = ddlFinyear.SelectedItem.Text;
            da.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = "Y";
            da.SelectCommand.Parameters.Add("@SLCDLC", SqlDbType.VarChar).Value = ddlworkingstatus.SelectedItem.Text;

            da.Fill(oDataSet);
        
            if(ddlFinyear.SelectedItem.Text!="--ALL--")
            {
                grdDetailsPavallavaddiSC.Visible = true;
                grdDetailsPavallavaddiSC.DataSource = oDataSet.Tables[1];
                grdDetailsPavallavaddiSC.DataBind();
                grdAllFinyear.Visible = false;
            }
            else if (ddlFinyear.SelectedItem.Text == "--ALL--")
            {
                grdAllFinyear.Visible = true;
                grdAllFinyear.DataSource = oDataSet.Tables[0];
                grdAllFinyear.DataBind();
                grdDetailsPavallavaddiSC.Visible = false;
            }


        }
        osqlConnection.Close();




    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = "Release pending";
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdAllFinyear.RenderControl(hw);
                string label1text = "Release pending";
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + "Release pending" + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public void financialYear()
    {
        osqlConnection.Open();
        SqlDataAdapter da;
        DataSet oDataSet = new DataSet();

        da = new SqlDataAdapter("releasePendingIncentives", osqlConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = "N";


        da.Fill(oDataSet);
        ddlFinyear.DataSource = oDataSet.Tables[0];
        
      


        
        ddlFinyear.DataTextField = "FinancialYear";
        
        ddlFinyear.DataBind();
        
        ddlFinyear.Items.Insert(0, new ListItem("--ALL--", "0"));
        //ddlFinyear.SelectedItem.Text = "2020-2021";


        osqlConnection.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        reportMethod();
    }

    protected void grdAllFinyear_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow grdAllFin_r = e.Row;
            GridViewRow grdAllFinyear_Header = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            this.grdAllFinyear.Controls[0].Controls.AddAt(0, grdAllFinyear_Header);

            int headerCellCount = grdAllFin_r.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = grdAllFin_r.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    grdAllFinyear_Header.Cells.Add(tcHeader);
                }
            }
            TableCell tcMergePackage = new TableCell();   //2015-2016
            tcMergePackage.Text = "2015-2016";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            grdAllFinyear_Header.Cells.AddAt(3, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell(); //2016-2017
            tcMergePackage1.Text = "2016-2017";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            grdAllFinyear_Header.Cells.AddAt(4, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell(); //2017-2018
            tcMergePackage2.Text = "2017-2018";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 2;
            grdAllFinyear_Header.Cells.AddAt(5, tcMergePackage2);

            TableCell tcMergePackage3 = new TableCell(); //2018-2019
            tcMergePackage3.Text = "2018-2019";
            tcMergePackage3.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage3.ColumnSpan = 2;
            grdAllFinyear_Header.Cells.AddAt(6, tcMergePackage3);

            TableCell tcMergePackage4 = new TableCell(); //2019-2020
            tcMergePackage4.Text = "2019-2020";
            tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage4.ColumnSpan = 2;
            grdAllFinyear_Header.Cells.AddAt(7, tcMergePackage4);

            TableCell tcMergePackage5 = new TableCell(); //2020-2021
            tcMergePackage5.Text = "2020-2021";
            tcMergePackage5.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage5.ColumnSpan = 2;
            grdAllFinyear_Header.Cells.AddAt(8, tcMergePackage5);
        }
    }
}