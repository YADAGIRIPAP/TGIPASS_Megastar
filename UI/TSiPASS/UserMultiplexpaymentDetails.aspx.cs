using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_UserMultiplexpaymentDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsnew = new DataSet();
        if (Request.QueryString[0].ToString() != "")
            dsnew = BindReceipt(Request.QueryString[0].ToString());

        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            lbluidno.Text = dsnew.Tables[0].Rows[0]["UID_No"].ToString();
            lblunitname.Text = dsnew.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
            lbladdress.Text = dsnew.Tables[0].Rows[0]["Village_Name"].ToString();
            lblvillage.Text = dsnew.Tables[0].Rows[0]["Manda_lName"].ToString();
            lblmandal.Text = dsnew.Tables[0].Rows[0]["District_Name"].ToString();
            lblnum2wrds.Text = dsnew.Tables[0].Rows[0]["date"].ToString();
            if (dsnew != null && dsnew.Tables.Count > 2 && dsnew.Tables[2].Rows.Count > 0)
            {
                gvdata.DataSource = dsnew.Tables[2];
                gvdata.DataBind();
                foreach (GridViewRow row in gvdata.Rows)
                {
                    //foreach (TableCell cell in row.Cells)
                    //{
                    row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    row.Cells[2].Attributes.CssStyle["Width"] = "100px";
                    //}
                }
            }
            else
            {
                Response.Redirect("MultiplexDashboardList.aspx");
            }
        }
        else
        {
            Response.Redirect("MultiplexDashboardList.aspx");
        }
    }



    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PaymentReceipt.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
            Receipt.RenderControl(htmlTextWriterw);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //iTextSharp.text.Image gifghmc1 = iTextSharp.text.Image.GetInstance(Server.MapPath("images/tsSmalllogo.png"));
            //gifghmc1.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
            //gifghmc1.ScaleToFit(80, 80);
            //gifghmc1.Alignment = iTextSharp.text.Image.UNDERLYING;
            //gifghmc1.SetAbsolutePosition(260, 600);
            //pdfDoc.Add(gifghmc1);
            htmlparser.Parse(stringReader);
            pdfDoc.Close();
        }
        catch
        {

        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect(" ~/UI/TSiPASS/FilmShootingUserDashboardList.aspx");
    }

    private DataSet BindReceipt(string TranRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("USP_GET_ACKNOWLEDGEMENT_Multiplexpayment", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@intEntid", TranRefNo);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            conn.Close();
            return ds;

        }
        catch (Exception ex)
        {

        }
        return null;
    }
}