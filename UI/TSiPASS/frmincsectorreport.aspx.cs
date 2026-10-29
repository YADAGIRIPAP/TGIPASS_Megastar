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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Data.SqlClient;
public partial class frmincsectorreport : System.Web.UI.Page


{
    General Gen = new General();
    DB.DB con = new DB.DB();
    decimal MfgNoofUnits, MfgNoofClaims, MfgAmount, FSNoofUnits, FSNoofClaims, FSAmount, PSNoofUnits, PSNoofClaims, PSAmount, NPGNoofUnits, NPGNoofClaims, NPGAmount, EMNoofUnits, EMNoofClaims, EMAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetIncentiveTypes();

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            //GetCasteMaster();
            GetIncentiveTypes();
            ddlCaste.SelectedValue = "All";
            ddlIncentiveType.SelectedValue = "All";
            if (Request.QueryString["fromdt"] != null && Request.QueryString["fromdt"] != "" && Request.QueryString["todt"] != null && Request.QueryString["todt"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdt"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todt"].ToString().Trim();
                //if (Request.QueryString["Category"] != null && Request.QueryString["Category"] != "")
                //{
                //    ddlCategory.SelectedValue = Request.QueryString["Category"].ToString();
                //}

                FillGridDetails();
            }
            else
            {

                txtFromDate.Text = "01-04-2016";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                FillGridDetails();
            }
        }
    }

    protected void GetIncentiveTypes()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetIncentiveTypesForReports();
        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            ddlIncentiveType.DataSource = dsnew.Tables[0];
            ddlIncentiveType.DataTextField = "IncentiveName";
            ddlIncentiveType.DataValueField = "IncentiveID";
            ddlIncentiveType.DataBind();
        }
    }
    public DataSet GetIncentivesClaimedReport(string Caste, string IncentiveType, string fromdate, string todate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //da = new SqlDataAdapter("sp_GetDistriciWiseReport", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_Incentives_Sectorreport", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (Caste.Trim() == "" || Caste.Trim() == null || Caste.Trim().ToLower() == "--select--")
                da.SelectCommand.Parameters.Add("@Caste", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Caste", SqlDbType.VarChar).Value = Caste.ToString();

            if (IncentiveType.Trim() == "" || IncentiveType.Trim() == null || IncentiveType.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@IncentiveType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@IncentiveType", SqlDbType.VarChar).Value = IncentiveType.ToString();

            /* if (District.Trim() == "" || District.Trim() == null || District.Trim().ToLower() == "--select--")
             da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = "%";
         else
             da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = District.ToString();*/

            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();

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
    public void FillGridDetails()
    {
        DataSet ds = new DataSet();

        Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        // ds = Gen.GetIncentivesClaimedReport(ddlCategory.SelectedItem.ToString().Trim(), ddldistrict.SelectedValue, FromdateforDB, TodateforDB);
        ds = GetIncentivesClaimedReport(ddlCaste.SelectedItem.Text, ddlIncentiveType.SelectedValue, FromdateforDB, TodateforDB);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void BtnSave1_Click(object sender, System.EventArgs e)
    {
        int valid = 0;

        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        //if (ddlCaste.SelectedItem.Text== "--Select--")
        //{
        //    lblmsg0.Text += "Please Select Caste <br/>";
        //    valid = 1;
        //}
        if (valid == 1)
        {
            Failure.Visible = true;
        }

        if (valid == 0)
        {
            Failure.Visible = false;
            FillGridDetails();
        }
    }


    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 2 || i == 3 || i == 4)
                {
                    cellIndex++;
                }
                else if (i == 5 || i == 6 || i == 7)
                {
                    cellIndex++;
                }
                else if (i == 8 || i == 9 || i == 10)
                {
                    cellIndex++;
                }
                else if (i == 11 || i == 12 || i == 13)
                {
                    cellIndex++;
                }
                else if (i == 14 || i == 15 || i == 16)
                {
                    cellIndex++;
                }

                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Manufacturing";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Fixed Service";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Passenger";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage2);

            TableCell tcMergePackage3 = new TableCell();
            tcMergePackage3.Text = "Non-Passenger-Goods";
            tcMergePackage3.CssClass = "GridviewScrollC1Header";
            tcMergePackage3.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage3);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Equipment Moveble";
            tcMergePackage4.CssClass = "GridviewScrollC1Header";
            tcMergePackage4.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage4);



        }


    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Service_id = "";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal MfgNoofUnits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MFGNoofunits"));
            MfgNoofUnits = MfgNoofUnits1 + MfgNoofUnits;

            decimal MfgNoofClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MFGNoofclaims"));
            MfgNoofClaims = MfgNoofClaims1 + MfgNoofClaims;

            decimal MfgAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MFGAmount"));
            MfgAmount = MfgAmount1 + MfgAmount;

            decimal FSNoofUnits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERFIXEDSERVNooFunits"));
            FSNoofUnits = FSNoofUnits1 + FSNoofUnits;

            decimal FSNoofClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERFIXEDSERVNOOFclaims"));
            FSNoofClaims = FSNoofClaims1 + FSNoofClaims;

            decimal FSAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERFIXEDSERVAMOUNT"));
            FSAmount = FSAmount1 + FSAmount;

            decimal PSNoofUnits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERPASSENGERNOOFUNITS"));
            PSNoofUnits = PSNoofUnits1 + PSNoofUnits;

            decimal PSNoofClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERPASSENGERNOOFCLAIMS"));
            PSNoofClaims = PSNoofClaims1 + PSNoofClaims;

            decimal PSAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERPASSENGERAMOUNT"));
            PSAmount = PSAmount1 + PSAmount;

            decimal NPGNoofUnits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERNONPASSENGERGOODSNOOFUNITS"));
            NPGNoofUnits = NPGNoofUnits1 + NPGNoofUnits;

            decimal NPGNoofClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERNONPASSENGERGOODSNOOFCLAIMS"));
            NPGNoofClaims = NPGNoofClaims1 + NPGNoofClaims;

            decimal NPGAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SERNONPASSENGERGOODSAMOUNT"));
            NPGAmount = NPGAmount1 + NPGAmount;

            decimal EMNoofUnits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SEREQUIPMOVEBLENOFUNITS"));
            EMNoofUnits = EMNoofUnits1 + EMNoofUnits;

            decimal EMNoofClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SEREQUIPMOVEBLENOFCLAIMS"));
            EMNoofClaims = EMNoofClaims1 + EMNoofClaims;

            decimal EMAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SEREQUIPMOVEBLEAMOUNT"));
            EMAmount = EMAmount1 + EMAmount;


            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
            h1.NavigateUrl = "frimincsectorreportdrll.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink3");
            h2.NavigateUrl = "frimincsectorreportdrll.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink4");
            h3.NavigateUrl = "frimincsectorreportdrll.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink5");
            h4.NavigateUrl = "frimincsectorreportdrll.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink6");
            h5.NavigateUrl = "frimincsectorreportdrll.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink7");
            h6.NavigateUrl = "frimincsectorreportdrll.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLink8");
            h7.NavigateUrl = "frimincsectorreportdrll.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyperLink9");
            h8.NavigateUrl = "frimincsectorreportdrll.aspx?status=H&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h9 = (HyperLink)e.Row.FindControl("HyperLink10");
            h9.NavigateUrl = "frimincsectorreportdrll.aspx?status=I&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h10 = (HyperLink)e.Row.FindControl("HyperLink11");
            h10.NavigateUrl = "frimincsectorreportdrll.aspx?status=J&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h11 = (HyperLink)e.Row.FindControl("HyperLink12");
            h11.NavigateUrl = "frimincsectorreportdrll.aspx?status=K&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();


            HyperLink h12 = (HyperLink)e.Row.FindControl("HyperLink13");
            h12.NavigateUrl = "frimincsectorreportdrll.aspx?status=L&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h13 = (HyperLink)e.Row.FindControl("HyperLink14");
            h13.NavigateUrl = "frimincsectorreportdrll.aspx?status=M&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h14 = (HyperLink)e.Row.FindControl("HyperLink15");
            h14.NavigateUrl = "frimincsectorreportdrll.aspx?status=N&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h15 = (HyperLink)e.Row.FindControl("HyperLink16");
            h15.NavigateUrl = "frimincsectorreportdrll.aspx?status=O&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue +  "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();
        
        
    }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = MfgNoofUnits.ToString();
            Service_id = "%";
            HyperLink h1 = new HyperLink();
            h1.Text = MfgNoofUnits.ToString();
            
                h1.NavigateUrl = "frimincsectorreportdrll.aspx?status=A&intDistid=" + Service_id + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();
                //e.Row.FindControl("HyperLink2");
           
            Label MUnits = new Label();
            MUnits.Text = MfgNoofUnits.ToString();
            e.Row.Cells[2].Controls.Add(MUnits);

            Label MClaims = new Label();
            MClaims.Text = MfgNoofClaims.ToString();
            e.Row.Cells[3].Controls.Add(MClaims);

            Label Mamount = new Label();
            Mamount.Text = MfgAmount.ToString();
            e.Row.Cells[4].Controls.Add(Mamount);

            Label FUnits = new Label();
            FUnits.Text = FSNoofUnits.ToString();
            e.Row.Cells[5].Controls.Add(FUnits);

            Label FClaims = new Label();
            FClaims.Text = FSNoofClaims.ToString();
            e.Row.Cells[6].Controls.Add(FClaims);

            Label FAmount = new Label();
            FAmount.Text = FSAmount.ToString();
            e.Row.Cells[7].Controls.Add(FAmount);

            Label PSNunits = new Label();
            PSNunits.Text = PSNoofUnits.ToString();
            e.Row.Cells[8].Controls.Add(PSNunits);

            Label PSClaims = new Label();
            PSClaims.Text = PSNoofClaims.ToString();
            e.Row.Cells[9].Controls.Add(PSClaims);

            Label PAmount = new Label();
            PAmount.Text = PSAmount.ToString();
            e.Row.Cells[10].Controls.Add(PAmount);
                
            Label NPGunits = new Label();
            NPGunits.Text = NPGNoofUnits.ToString();
            e.Row.Cells[11].Controls.Add(NPGunits);

            Label NPGclaims = new Label();
            NPGclaims.Text = NPGNoofClaims.ToString();
            e.Row.Cells[12].Controls.Add(NPGclaims);

            Label NGAmount = new Label();
            NGAmount.Text = NPGAmount.ToString();
            e.Row.Cells[13].Controls.Add(NGAmount);

            Label EMunits = new Label();
            EMunits.Text = EMNoofUnits.ToString();
            e.Row.Cells[14].Controls.Add(EMunits);

            Label EMClaims = new Label();
            EMClaims.Text = EMNoofClaims.ToString();
            e.Row.Cells[15].Controls.Add(EMClaims);


            Label EAmount = new Label();
            EAmount.Text = EMAmount.ToString();
            e.Row.Cells[16].Controls.Add(EAmount);

        }

    }
}