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
using System.Text;
// using System.Drawing;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class UI_TSiPASS_DepartmentWiseCfoAnalasis : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFinancialYear.SelectedValue = "1";

            txtFromDate.Text = "01-04-2016";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");


            fillgrid();
        }

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {


        fillgrid();


    }
    public void fillgrid()
    {

        DataSet dsnew = new DataSet();

        string FromdateforDB = "", TodateforDB = "";
        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

        dsnew = Gen.FetchAnalisReport(ddlFinancialYear.SelectedValue, FromdateforDB, TodateforDB);
        // lblMsg.Text = "";
        if (dsnew.Tables[2].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

            Session["dtdataset"] = dsnew;

            GridView1.DataSource = dsnew.Tables[2];
            GridView1.DataBind();


            GridView2.DataSource = dsnew.Tables[3];
            GridView2.DataBind();


        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            GridView1.DataSource = null;
            GridView1.DataBind();


            GridView2.DataSource = null;
            GridView2.DataBind();
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text == "CFO - Total" || e.Row.Cells[1].Text == "CFE + CFO TOTAL" || e.Row.Cells[1].Text == "GRAND TOTAL" || e.Row.Cells[1].Text == "CFE - Total")
            {
                e.Row.Font.Bold = true;
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }




    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    //protected void btnGet_Click(object sender, EventArgs e)
    //{
    //    //OBJECT OF MISSING "NULL VALUE"

    //    Object oMissing = System.Reflection.Missing.Value;
    //    Object oTemplatePath = "D:\\Analasis\\DynamicGenerationofanasis.dotx";

    //    Application wordApp = new Application();
    //    Document wordDoc=null;
    //    for (int i = 0; i <= 2; i++)
    //    {
    //         wordDoc = new Document();
    //        wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
    //        foreach (Field myMergeField in wordDoc.Fields)
    //        {
    //            Range rngFieldCode = myMergeField.Code;
    //            String fieldText = rngFieldCode.Text;

    //            // ONLY GETTING THE MAILMERGE FIELDS

    //            if (fieldText.StartsWith(" MERGEFIELD"))
    //            {
    //                // THE TEXT COMES IN THE FORMAT OF
    //                // MERGEFIELD  MyFieldName  \\* MERGEFORMAT
    //                // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"

    //                Int32 endMerge = fieldText.IndexOf("\\");

    //                Int32 fieldNameLength = fieldText.Length - endMerge;

    //                String fieldName = fieldText.Substring(11, endMerge - 11);

    //                // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

    //                fieldName = fieldName.Trim();

    //                // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//

    //                // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE

    //                if (fieldName.TrimStart().TrimEnd() == "DepartmentName")
    //                {
    //                    myMergeField.Select();
    //                    wordApp.Selection.TypeText("Vivek");
    //                }
    //            }
    //        }
    //    }
    //    wordDoc.Save();
    //  //  wordApp.Documents.Open("myFile.doc");
    //   // wordApp.Application.Quit();
    //}
    protected void Button3_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void btnbdf_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)Session["dtdataset"];

        // DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable tablenew = null;
            PdfPTable tablenewinner = null;
            PdfPTable tablenbeyond1 = null;
            PdfPTable tablenewbeyond2 = null;
            PdfPTable tablenewbeyondinner = null;
            PdfPTable tablenewbeyondinner2 = null;
            PdfPTable tablenewwirhininner = null;
            PdfPTable tablenewwithininner2 = null;

            Color color = null;

            document.Open();

            //Header Table
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                table = new PdfPTable(2);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 0.3f, 0.7f });

                string deptid = ds.Tables[2].Rows[i]["intDeptid"].ToString();
                string deptname = ds.Tables[0].Rows[i]["DEPARTMENTNAMEShow"].ToString();
                string Handledapps = ds.Tables[2].Rows[i]["NOOFAPPLICATIONS"].ToString();
                string deptnameapprovalname = ds.Tables[0].Rows[i]["ApprovalSHow"].ToString();
                string Appswithin = ds.Tables[2].Rows[i]["Applications_disposed_within_Duedate"].ToString();
                string Appswithinsla = ds.Tables[2].Rows[i]["Average_Number_of_days_taken_for_approval"].ToString();
                string Appswithinpsc = ds.Tables[2].Rows[i]["No_of_apps_dsd_on_the_same_day_excl_timetaken_PSC"].ToString();
                string Appsbeyondpsc = ds.Tables[2].Rows[i]["No_of_apps_dsd_on_the_same_day_incl_timetaken_PSC"].ToString();
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 30f;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(deptname + " Department", FontFactory.GetFont("Trebuchet MS", 16, Font.BOLD, Color.RED)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 30f;
                table.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("•	Name of the Approval : " + deptnameapprovalname + " \n\n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                phrase.Add(new Chunk("•	Total number of applications handled : " + Handledapps + "\n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));

                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 2;
                cell.PaddingBottom = 30f;
                table.AddCell(cell);

                document.Add(table);

                tablenew = new PdfPTable(4);
                tablenew.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
                //tablenew.SetWidths(new float[] { 0.15f, 0.85f });
                tablenew.TotalWidth = 500f;
                tablenew.LockedWidth = true;
                tablenew.SpacingBefore = 20f;
                tablenew.HorizontalAlignment = Element.ALIGN_RIGHT;

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenew.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("1. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenew.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Applications disposed within due date : ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenew.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appswithin + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.BOLD, new Color(6, 170, 26))));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenew.AddCell(cell);

                color = new Color(6, 170, 26);
                DrawLine(writer, 60f, document.Top - 200f, document.PageSize.Width - 60f, document.Top - 200f, color);
                document.Add(tablenew);
                // ----------------------------------within anothher table ----------------------------------------

                tablenewinner = new PdfPTable(2);
                tablenewinner.SetWidths(new float[] { 0.15f, 0.85f });
                tablenewinner.TotalWidth = 500f;
                tablenewinner.LockedWidth = true;
                tablenewinner.SpacingBefore = 20f;
                tablenewinner.HorizontalAlignment = Element.ALIGN_RIGHT;

                cell = ImageCell("~/images/GREEN.JPG", 20f, PdfPCell.ALIGN_CENTER);
                tablenewinner.AddCell(cell);

                //  inner table

                tablenewwirhininner = new PdfPTable(3);
                tablenewwirhininner.SetWidths(new float[] { 0.05f, 0.70f, 0.25f });
                tablenewwirhininner.TotalWidth = 435f;
                tablenewwirhininner.LockedWidth = true;
                tablenewwirhininner.HorizontalAlignment = Element.ALIGN_RIGHT;



                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewwirhininner.AddCell(cell);

                tablenewwithininner2 = new PdfPTable(3);
                tablenewwithininner2.SetWidths(new float[] { 0.05f, 0.70f, 0.25f });
                tablenewwithininner2.TotalWidth = 410f;
                tablenewwithininner2.LockedWidth = true;
                tablenewwithininner2.HorizontalAlignment = Element.ALIGN_RIGHT;

                phrase = new Phrase();
                phrase.Add(new Chunk("a. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewwithininner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Average Number of Days Taken For :\n Approval v/s SLA ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwithininner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appswithinsla + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, new Color(6, 170, 26))));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwithininner2.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 20f;
                tablenewwithininner2.AddCell(cell);

                cell = new PdfPCell(tablenewwithininner2); // inner-inner table adding to this
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                cell.Colspan = 2;
                tablenewwirhininner.AddCell(cell);

                //  -----------------------------------------------------------------------------------------------------------------
                phrase = new Phrase();
                phrase.Add(new Chunk("2. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                cell.BorderColorRight = new Color(6, 170, 26);
                tablenewwirhininner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("No of applications disposed on the same day : (excluding time taken for Pre-Scrutiny)", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwirhininner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appswithinpsc + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, new Color(6, 170, 26))));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwirhininner.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 20f;
                tablenewwirhininner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("3. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwirhininner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("No of applications disposed on the same day : (including time taken for Pre-Scrutiny)  ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwirhininner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appsbeyondpsc + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, new Color(6, 170, 26))));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewwirhininner.AddCell(cell);

                cell = new PdfPCell(tablenewwirhininner);  // inner table adding to this
                cell.BorderWidthLeft = 1;
                cell.BorderColor = Color.WHITE;
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewinner.AddCell(cell);

                color = new Color(0, 173, 0);
                //DrawLine(writer, 90f, 40f, 90f, 200f, color);
                //DrawLine(writer, 160f, 80f, 160f, 690f, Color.BLACK);
                DrawLine(writer, 90f, 632f, 90f, 480f, color);

                color = new Color(8, 8, 8);
                DrawLineMiddleline(writer, 2f, document.Top - 400f, document.PageSize.Width - 2f, document.Top - 400f, color);
                document.Add(tablenewinner);
                // --------------------------------------------------------------------------Beyond Table --------------------------------------------------------------------
                // deptid
                DataRow[] resultnew = ds.Tables[3].Select("intDeptid=" + deptid);

                string Appswithin1 = resultnew[0]["Applications_disposed_within_Duedate"].ToString();
                string Appswithinslabyond = resultnew[0]["Average_Number_of_days_taken_for_approval"].ToString();
                string Appsmaximumno = resultnew[0]["Maximum_number_of_days_taken_inanapplication"].ToString();
                string Appsavgbeyond = resultnew[0]["Averagedelaybeyondduedate"].ToString();

                string Appsbyond1 = resultnew[0]["Noofapplicationsdisposedwithin_1_week_fromduedate"].ToString();
                string Appsbyond2 = resultnew[0]["Noofapplicationsdisposedwithin_2_week_fromduedate"].ToString();
                string Appsbyond3 = resultnew[0]["Noofapplicationsdisposedwithin_3_week_fromduedate"].ToString();

                //string Appswithinsla1 = ds.Tables[0].Rows[i]["Average_Number_of_days_taken_for_approval"].ToString();
                //string Appswithinpsc1 = ds.Tables[0].Rows[i]["No_of_apps_dsd_on_the_same_day_excl_timetaken_PSC"].ToString();
                //string Appsbeyondpsc1 = ds.Tables[0].Rows[i]["No_of_apps_dsd_on_the_same_day_incl_timetaken_PSC"].ToString();

                tablenbeyond1 = new PdfPTable(4);
                tablenbeyond1.TotalWidth = 500f;
                tablenbeyond1.LockedWidth = true;
                tablenbeyond1.SpacingBefore = 20f;
                tablenbeyond1.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
                tablenbeyond1.HorizontalAlignment = Element.ALIGN_RIGHT;

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 4;
                cell.PaddingBottom = 80f;
                tablenbeyond1.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenbeyond1.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("1. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenbeyond1.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Applications Disposed Beyond Due Date : ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenbeyond1.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appswithin1 + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.BOLD, Color.RED)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenbeyond1.AddCell(cell);

                color = new Color(6, 170, 26);
                // DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                DrawLine(writer, 60f, document.Top - 465f, document.PageSize.Width - 60f, document.Top - 465f, color);
                document.Add(tablenbeyond1);

                // ---------------------------------------------------------------------------------------------------------------

                tablenewbeyond2 = new PdfPTable(2);
                tablenewbeyond2.SetWidths(new float[] { 0.15f, 0.85f });
                tablenewbeyond2.TotalWidth = 500f;
                tablenewbeyond2.LockedWidth = true;
                tablenewbeyond2.SpacingBefore = 20f;
                tablenewbeyond2.HorizontalAlignment = Element.ALIGN_RIGHT;

                cell = ImageCell("~/images/RED.JPG", 20f, PdfPCell.ALIGN_CENTER);
                tablenewbeyond2.AddCell(cell);

                //  inner table

                tablenewbeyondinner = new PdfPTable(3);
                tablenewbeyondinner.SetWidths(new float[] { 0.05f, 0.70f, 0.25f });
                tablenewbeyondinner.TotalWidth = 435f;
                tablenewbeyondinner.LockedWidth = true;
                tablenewbeyondinner.HorizontalAlignment = Element.ALIGN_RIGHT;

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 10f;
                tablenewbeyondinner.AddCell(cell);
                //  Again inner table ------------------------------------------------------------------------------------------------------------

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewbeyondinner.AddCell(cell);

                tablenewbeyondinner2 = new PdfPTable(3);
                tablenewbeyondinner2.SetWidths(new float[] { 0.05f, 0.70f, 0.25f });
                tablenewbeyondinner2.TotalWidth = 410f;
                tablenewbeyondinner2.LockedWidth = true;
                tablenewbeyondinner2.HorizontalAlignment = Element.ALIGN_RIGHT;

                phrase = new Phrase();
                phrase.Add(new Chunk("a. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("No of applications disposed within 1 week from due date : ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appsbyond1 + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 10f;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("b. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("No of applications disposed within 2 weeks from due date : ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appsbyond2 + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 10f;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("C. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("No of applications disposed within 2 weeks from due date : ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appsbyond3 + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner2.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 20f;
                tablenewbeyondinner2.AddCell(cell);

                cell = new PdfPCell(tablenewbeyondinner2); // inner-inner table adding to this
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                cell.Colspan = 2;
                tablenewbeyondinner.AddCell(cell);

                //   ----------------------------------------------------------------------------------------------------------------------------------


                phrase = new Phrase();
                phrase.Add(new Chunk("2. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                cell.BorderColorRight = new Color(6, 170, 26);
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Average number of days taken for disposal : \n v/s SLA", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appswithinslabyond + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 20f;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("3. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Maximum Number of Days Taken in : \n an Application", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appsmaximumno + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 20f;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("4. ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Average delay beyond due date (no. of days) : ", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(Appsavgbeyond + " \n", FontFactory.GetFont("Trebuchet MS", 14, Font.NORMAL, Color.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyondinner.AddCell(cell);

                phrase = new Phrase();
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Colspan = 3;
                cell.PaddingBottom = 20f;
                tablenewbeyondinner.AddCell(cell);

                cell = new PdfPCell(tablenewbeyondinner);  // inner table adding to this
                cell.BorderWidthLeft = 1;
                cell.BorderColor = Color.WHITE;
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                tablenewbeyond2.AddCell(cell);

                color = new Color(0, 173, 0);
                DrawLine(writer, 90f, 100f, 90f, 368f, color);

                document.Add(tablenewbeyond2);

                // Footer 

                PdfPTable footerTbl = new PdfPTable(2);
                footerTbl.SetWidths(new float[] { 0.1f, 0.9f });
                footerTbl.TotalWidth = 500f;
                footerTbl.LockedWidth = true;
                footerTbl.SpacingBefore = 20f;
                footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

                phrase = new Phrase();
                phrase.Add(new Chunk("Note:", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.BOLD, new Color(127, 127, 127))));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                cell.Border = 0;
                footerTbl.AddCell(cell);

                // string txtFromDate = "", txtTodate = "";
                string strDuration = "";
                string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
                string FromdateforDB1 = "", TodateforDB1 = "";
                int monthday1 = 0, monthday2 = 0;
                //  txtFromDate = Session["FromdateforDB"].ToString();

                if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM"));
                    monthday1 = Convert.ToInt32(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("dd"));
                    monthday2 = Convert.ToInt32(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("dd"));

                    FromdateforDB1 = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy"));
                    TodateforDB1 = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy"));

                    monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(FromdateforDB));
                    monthName1 = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(TodateforDB));
                }

                strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
                // strDuration = monthday1.DisplayWithSuffix();
                phrase = new Phrase();
                phrase.Add(new Chunk("Analysis is based on applications handled by the department from " + strDuration, FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.NORMAL, new Color(127, 127, 127))));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                footerTbl.AddCell(cell);

                footerTbl.WriteSelectedRows(0, -1, 30, 50, writer.DirectContent);

                document.NewPage();
            }
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=DepartmentwiseCFO.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(1f);
        contentByte.Stroke();
    }
    private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(2f);
        contentByte.Stroke();
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }



    public string DisplayWithSuffix(int num)
    {
        if (num.ToString().EndsWith("11")) return num.ToString() + "th";
        if (num.ToString().EndsWith("12")) return num.ToString() + "th";
        if (num.ToString().EndsWith("13")) return num.ToString() + "th";
        if (num.ToString().EndsWith("1")) return num.ToString() + "st";
        if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
        if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
        return num.ToString() + "th";
    }

}

