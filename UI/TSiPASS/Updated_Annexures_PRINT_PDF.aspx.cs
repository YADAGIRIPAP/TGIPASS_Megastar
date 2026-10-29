using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web;


public partial class UI_TSiPASS_Updated_Annexures_PRINT_PDF : System.Web.UI.Page
{
    General gen = new General();
    decimal NoofClaimsTotal, AmountTotal, Amount_Total;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                if (Request.QueryString["ListNo"] != null)
                {
                    string ListNoValue = Request.QueryString["ListNo"];
                    ListNo.Text = ListNoValue;
                }
        }  // Binding Data for reference from main page

        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        {
                SqlParameter[] pp = new SqlParameter[]
                 {
                    new SqlParameter("@ListNo", SqlDbType.VarChar)
                 };

                pp[0].Value = ListNo.Text;
                ds1 = gen.GenericFillDs("PrintUpdatedData_Pdf", pp);
                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds1.Tables[0].Rows[0];
                    string ReleaseProceedingNo = row["ChequeProceedingNumber"].ToString();
                    ProcessNo.Text = ReleaseProceedingNo;
                    string ConsolidatedProceedingsNo_1 = row["ReleaseProceedingNo"].ToString();
                    ConsolidatedProceedingsNo1.Text = ConsolidatedProceedingsNo_1;
                    string ConsolidatedProceedingsNo_2 = row["ReleaseProceedingNo"].ToString();
                    ConsolidatedProceedingsNo2.Text = ConsolidatedProceedingsNo_2;
                    string AnnexureNumber = row["ListNo"].ToString();
                    ListNo.Text = AnnexureNumber;
                    string LOCNUMBER = row["LOC_NUMBER"].ToString();
                    LOC_NUMBER.Text = LOCNUMBER;
                    string LOC_AMOUNT = row["LOC_AMOUNT"].ToString();
                    LOCDTOHYD.Text = string.Format("Rs. {0:0,0.00}/-", LOC_AMOUNT);
                    string LOC_AMOUNT_1 = row["LOC_AMOUNT"].ToString();
                    LOCDTOHYDERABAD.Text = LOC_AMOUNT_1;
                    string Balance_LOCAMOUNT = row["Sanctioned_LOCAMOUNT"].ToString();
                    DOISanction.Text = Balance_LOCAMOUNT;
                    string ReleaseProceedingDate = DateTime.Parse(row["ReleaseProceedingDate"].ToString()).ToString("dd/MM/yyyy");
                    Dt1.Text = ReleaseProceedingDate;
                    Dt2.Text = ReleaseProceedingDate;
                    string formattedDate = DateTime.Parse(row["LOCDATE"].ToString()).ToString("dd/MM/yyyy");
                    LOC_Date.Text = formattedDate;
                    string Scheme_Category = row["SchemeCategory"].ToString();
                    SchemeCategory.Text = Scheme_Category;
                    Scheme.Text = Scheme_Category;
                    string Scheme_Name = row["SchemeName"].ToString();
                    SchemeName.Text = Scheme_Name; 
                    string Financial_Year = row["FinancialYear"].ToString();
                    FinancialYear.Text = Financial_Year;
                if (!string.IsNullOrEmpty(row["ChequeProceedingDate"].ToString()))
                {
                    string ChequeformattedDate = DateTime.Parse(row["ChequeProceedingDate"].ToString()).ToString("dd/MM/yyyy");
                    Date.Text = " Dt: " + ChequeformattedDate;
                }
            }
            }   //  Static Data in Print Page
            {
                SqlParameter[] pp = new SqlParameter[]
                 {
                    new SqlParameter("@ListNo", SqlDbType.VarChar)
                 };

                pp[0].Value = ListNo.Text;
                
                ds2 = gen.GenericFillDs("GVData_Print_PDF", pp);
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    gvProceedings.DataSource = ds2.Tables[0];
                    gvProceedings.DataBind();
                }
            }  // GridView Data in Print Page
        {
            SqlParameter[] pp = new SqlParameter[]
                 {
                    new SqlParameter("@LIST_NUMBER", SqlDbType.VarChar)
                 };

            pp[0].Value = ListNo.Text;
            DataSet ds3 = new DataSet();
            ds3 = gen.GenericFillDs("Updated_SLC_OR_DIPC_PRINT", pp);
            if (ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds3.Tables[0];
                GridView1.DataBind();
            }
        }   // Detailed GridView 

        if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            decimal LOCDTOHYDERABAD_dynamicNumber = decimal.Parse(LOCDTOHYDERABAD.Text);
            decimal LOCDTOHYDERABAD_decimalNumber = Convert.ToDecimal(LOCDTOHYDERABAD_dynamicNumber);
            string LOCDTOHYDERABAD_fullTextAbbreviation = NumberToWords((int)LOCDTOHYDERABAD_decimalNumber);
            LOCDTOHYDERABAD_IN_WORDS.Text = LOCDTOHYDERABAD_fullTextAbbreviation;

            decimal DOISANCTION_dynamicNumber = decimal.Parse(DOISanction.Text);
            decimal DOISANCTION_decimalNumber = Convert.ToDecimal(DOISANCTION_dynamicNumber);
            string DOISANCTION_fullTextAbbreviation = NumberToWords((int)DOISANCTION_decimalNumber);
            DOISANCTION_IN_WORDS.Text = DOISANCTION_fullTextAbbreviation;

            decimal TotalAmount_dynamicNumber = decimal.Parse(TotalAmount.Text);
            decimal TotalAmount_decimalNumber = Convert.ToDecimal(TotalAmount_dynamicNumber);
            string TotalAmount_fullTextAbbreviation = NumberToWords((int)TotalAmount_decimalNumber);
            TotalAmount_INWORDS.Text = TotalAmount_fullTextAbbreviation;
        }  // Number to words Abbreviation
    }
    private string NumberToWords(int number)
    {
        if (number == 0) { return "ZERO"; }
        if (number < 0) { return "minus " + NumberToWords(Math.Abs(number)); }
        string strWords = "";
        if ((number / 10000000) > 0)
        {
            strWords += NumberToWords(number / 10000000) + " Crores ";
            number %= 10000000;
        }
        if ((number / 100000) > 0)
        {
            strWords += NumberToWords(number / 100000) + " Lakhs ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            strWords += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            strWords += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (strWords != "")
                strWords += "And ";
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                                 "Sixteen", "Sseventeen", "Eighteen", "Nineteen" };
            var TensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            if (number < 20)
                strWords += unitsMap[number];
            else
            {
                strWords += TensMap[number / 10];
                if ((number % 10) > 0)
                    strWords += " " + unitsMap[number % 10];
            }
        }
        return strWords;
    }

    protected void gvProceedings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             decimal Total_NoofClaims = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaims"));
            NoofClaimsTotal = Total_NoofClaims + NoofClaimsTotal;

             decimal Total_Amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            AmountTotal = Total_Amount + AmountTotal;
         }
         if (e.Row.RowType == DataControlRowType.Footer)
         {
             e.Row.Cells[1].Text = "Total";
             e.Row.Cells[2].Text = NoofClaimsTotal.ToString();
             e.Row.Cells[3].Text = string.Format("Rs. {0:0,0.00}/-", AmountTotal);
        }
        TotalNoofClaims.Text = NoofClaimsTotal.ToString();
        TotalNoofClaims_1.Text = NoofClaimsTotal.ToString();
        TotalAmount.Text =  AmountTotal.ToString();
    }   // Footer Data for the grid view 

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string script = "<script type=\"text/javascript\"> window.print(); </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "Print", script);
    }  //Print button in pdf to print page

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        string script = "<script>window.close();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "CloseWindowScript", script);
    } // Close Button in Pdf to close the opened page

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Total_Amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SanctionedAmount"));
            Amount_Total = Total_Amount + Amount_Total;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[6].Text = string.Format("₹&nbsp;{0:0,0.00}/-", Amount_Total);
        }
    }// Footer Data for the detailed grid view

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        GridViewRow headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell headerCell = new TableCell();
        headerCell.ColumnSpan = GridView1.Columns.Count; // Span the cell across all columns
        headerCell.Text = "(" + SchemeCategory.Text + ")" + " - Statement Showing list of units releases for " + FinancialYear.Text + " under " + SchemeName.Text + " Schemes " + "List no. " + ListNo.Text + " " + "(" + FinancialYear.Text + ")";

        headerRow.Cells.Add(headerCell);

        GridView1.Controls[0].Controls.AddAt(0, headerRow);
    }
}



