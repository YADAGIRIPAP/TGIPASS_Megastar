using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;//.OleDb;
using System.Data;
using iTextSharp.text;
//using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class SBHChallan : System.Web.UI.Page
{
    #region "Global Variables"
  
    DataSet ds = new DataSet();
    string connectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Amount"] != null && Session["UID_no"] != null && Session["SBHCHLNREF"] != null)
                {
                    string ReferenceNumber = Session["UID_no"].ToString();//"505560"; //Session["Reference"].ToString();
                    ViewState["Reference"] = ReferenceNumber;
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("[dbo].[GetChallanDetails]", conn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@UIDNo", ReferenceNumber);
                    cmd1.Connection = conn;
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    //OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lblCustName.Text = lblCustName2.Text = ds1.Tables[0].Rows[0]["nameofunit"].ToString();
                        lblTSIpassRefNo1.Text = lblTSIpassRefNo2.Text = Session["UID_no"].ToString();//ds1.Tables[0].Rows[0]["Reference"].ToString();
                        lblTransAmount.Text = lblTransAmount2.Text = Session["Amount"].ToString();//ds1.Tables[0].Rows[0]["Total_Fee"].ToString();
                        string[] values = lblTransAmount2.Text.Split('.');
                        int NumTotal = (Convert.ToInt32(values[0]) + Convert.ToInt32(lblBankcharges.Text));
                        lblTotalAmount.Text = lbltotAmount2.Text = Convert.ToString(NumTotal);
                        lblRefNo.Text = lblRefNumber2.Text = Session["SBHCHLNREF"].ToString(); //"E"+System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                        lblChallanDate.Text = lblChallanDate2.Text = System.DateTime.Now.ToString("dd/MMM/yyyy");
                        lblnotowords2.Text = lblAmounttoWords.Text = NumberToText(NumTotal) + " Rupee(s) Only.";
                    }
                    ds1.Clear();
                    ds1.Dispose();
                    conn.Close();
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            #region "Insert the challan details"
            if (Session["Amount"] != null && Session["UID_no"] != null && Session["SBHCHLNREF"] != null)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[InsertChallanDetails]";

                cmd.Parameters.AddWithValue("@TSIPASS_REFNO", lblTSIpassRefNo2.Text);
                cmd.Parameters.AddWithValue("@Amount", lblTransAmount.Text);
                cmd.Parameters.AddWithValue("@Created_by", Session["uid"].ToString());
                cmd.Parameters.AddWithValue("@OwnerName", lblCustName.Text);
                cmd.Parameters.AddWithValue("@SBHRefNumber", lblRefNo.Text);
                cmd.Parameters.AddWithValue("@UID", lblTSIpassRefNo2.Text);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
                if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string sRefNo = ds.Tables[0].Rows[0][0].ToString();
                    if(sRefNo != null)
                    {
                        #region "for Print"
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=SbhChallan.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter stringWriter = new StringWriter();
                        HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
                        divPDF.RenderControl(htmlTextWriterw);
                        // this.Page.RenderControl(htmlTextWriterw);
                        StringReader stringReader = new StringReader(stringWriter.ToString());
                        Document pdfDoc = new Document(new RectangleReadOnly(842, 595), 30f, 30f, 10f, 10f); //88f,88f,10f,10f         
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        MemoryStream memoryStream = new MemoryStream();
                        PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(stringReader);
                        pdfDoc.Close();
                        #endregion
                    }


                }
            }
            #endregion
          
           
        }
        catch(Exception ex)
        {

        }
    }
    #region "Number To Text"
    private string NumberToText(int number)
    {
        if (number == 0) return "Zero";
        int[] num = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (number < 0)
        {
            sb.Append("Minus ");
            number = -number;
        }
        string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        string[] words2 = { "Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };
        num[0] = number % 1000; // units
        num[1] = number / 1000;
        num[2] = number / 100000;
        num[1] = num[1] - 100 * num[2]; // thousands
        num[3] = number / 10000000; // crores
        num[2] = num[2] - 100 * num[3]; // lakhs
        for (int i = 3; i > 0; i--)
        {
            if (num[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (num[i] == 0) continue;
            u = num[i] % 10; // ones
            t = num[i] / 10;
            h = num[i] / 100; // hundreds
            t = t - 10 * h; // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                //if (h > 0 || i == 0) sb.Append("and ");
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }

        // TextBox2.Text = "Rupees " + sb.ToString().TrimEnd() + " Only";
        return sb.ToString().TrimEnd();
    }
    #endregion
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
   
}
