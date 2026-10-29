using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
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
using System.Xml;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSMSEFC_TSMSEFCPRINTMAIL : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    public string sEmail;
    //CLS_MSEFC objmsefc = new CLS_MSEFC();
    string EMAILID;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                 HDNAPPLICATIONID.Value = "1234";

                //if (Request.QueryString[0].ToString() != null)
                //{
                //    HDNAPPLICATIONID.Value = Request.QueryString[0].ToString();
                //}
                
                    


                    ds  = GETTSMSEFCDETAILS(HDNAPPLICATIONID.Value);


                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //txtasmtno.Text = ds.Tables[0].Rows[0]["Reference"].ToString();
                        //txtrcptno.Text = TranRefNo;
                        //txtrcptdt.Text = System.DateTime.Now.ToString();
                        //txtname.Text = ds.Tables[0].Rows[0]["IndustryName"].ToString();
                        //txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        //lblMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        //  lblMobileNumber.Text = "7702542727";
                        EMAILID = ds.Tables[0].Rows[0]["RESPONDENT_EMAIL"].ToString();

                        // txtEmailId.Text = "kmrias@gmail.com";

                        //txttotal.Text = Convert.ToDecimal(amount).ToString("#,##0") + " /-";



                       // string message = "Thank you for making the Payment of Rs." + txttotal.Text + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "- TSIPass";

                        if (EMAILID!= "")
                        {
                           
                            try
                            {
                                //SendingEmailWithAttachment(txtEmailId.Text, message, bytes);
                                string messageMail = " It is to inform you that " + ds.Tables[0].Rows[0]["NAMEOFUNIT_PETITIONER"].ToString() + " and " + ds.Tables[0].Rows[0]["PETITIONER_ADDRESS"].ToString()
                                    + "  as filed claim for principle amount " + ds.Tables[0].Rows[0]["PRINCIPLEAMOUNTPAYABLE"].ToString() + " from buyer/respondent"+"  "
                                    + ds.Tables[0].Rows[0]["RESPONDENT_NAME"].ToString() + " and " + ds.Tables[0].Rows[0]["RESPONDENT_ADDRESS"].ToString() + ".<br />"
                                    + "<br />" + " Your advise to file your response/counter with in 7 days at the following address.<br />"
                                    + "<br />" + "The details of the claim are here enclosed.";
                                
                                GeneratePdf(EMAILID, messageMail);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('EncloserList.aspx','popUpWindow','height=600,width=850,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                        // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('DepartmentService.aspx?UIDNO=" + txtasmtno.Text + "','popUpWindow','height=0,width=1,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                        try
                        {
                           // webservice(txtasmtno.Text);
                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            //After Payment send Approvals and status to nsws
                            //Cls_nswswebapiafterpayment obj_nsws = new Cls_nswswebapiafterpayment();
                            //string UIDNO = txtasmtno.Text; string CategoryType = "CFE";
                            //string approvalssenttonsws = obj_nsws.sendapprovalsdeptafterpaymenttonswsAPI(UIDNO, CategoryType);
                            //string appliedstatustonsws = obj_nsws.getlicencesstatusupdateafterpayment(UIDNO, CategoryType);

                            //webservice(txtasmtno.Text);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {

                    }
               
                
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    public void GeneratePdf(string Email, string Message)
    {
        DataSet ds = new DataSet();

        Document document = new Document(PageSize.A4, 20f, 20f, 20f, 50f);
        Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable tablenew = null;
            Color color = null;
            PdfPTable tablenewinner = null;
            document.Open();
            writer.PageEvent = new Footer();
            //Header Table
            PdfContentByte contentBytenew = writer.DirectContent;
            table = new PdfPTable(3);
            table.TotalWidth = document.PageSize.Width - 60f;
            table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
            table.LockedWidth = true;


            cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);


            //phrase = new Phrase();
            //phrase.Add(new Chunk("Telangana State Industrial Project Approval\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            //phrase.Add(new Chunk("&	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            //phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 11, Font.BOLD, Color.BLACK)));

            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            // cell.PaddingBottom = 30f;
            table.AddCell(cell);

            //cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
            //cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            //table.AddCell(cell);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //string strDuration = "";
            //string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
            //string FromdateforDB1 = "", TodateforDB1 = "";
            //int monthday1 = 0, monthday2 = 0;
            //  txtFromDate = Session["FromdateforDB"].ToString();

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("TSMSEFC FORM\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.Colspan = 3;
            cell.PaddingTop = 20f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Dated :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell.Colspan = 3;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 20f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 70f, document.PageSize.Width - 2f, document.Top - 70f, color);
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------




            //---------------------------------------------------------------------------------------------------------------------------------------------------------------
            int CountColumns = 0;

            CountColumns = 8;

            tablenew = new PdfPTable(CountColumns);
            tablenew.SetWidths(new float[] { 3f, 20f, 2f, 22f, 3f, 20f, 2f, 28f });

            tablenew.TotalWidth = document.PageSize.Width - 60f;

            tablenew.LockedWidth = true;
            tablenew.SpacingBefore = 5f;
            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;

            string cellText = "";
            ds = GETTSMSEFCDETAILS(HDNAPPLICATIONID.Value);
            cell = Allcelltext(Server.HtmlDecode("1."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Name of The Petetioner"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            
            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETITIONERNAME"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("2."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Application/Temp No."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["APPLICATIONORTEMPNO"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("3."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Udyog Aadhar No."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["UDYOGAADHARNO"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("4."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Date of Filing Application"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["APPLICATIONFILEDDATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            cell = Allcelltext(Server.HtmlDecode("5."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Name of Petetioner Unit"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["NAMEOFUNIT_PETITIONER"].ToString()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("6."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Petitioner(Supplier) Address"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETITIONER_ADDRESS"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("7."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("State of Petitioner"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETITIONER_STATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("8."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("District of Petitioner"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETITIONER_DISTRICT"].ToString()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------


            cell = Allcelltext(Server.HtmlDecode("9."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Petetioner Mobile No."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETETIONER_MOBILENO"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("10."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Petitioner Email."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETETIONER_EMAIL"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("11."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Type of Petitioner."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PETETIONER_TYPE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("12."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Case Status"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["CASESTATUS"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            cell = Allcelltext(Server.HtmlDecode("13."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Name of Respondent"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_NAME"].ToString()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("14."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("State of Respondent"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_STATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("15."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("District of Respondent"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_DISTRICT"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------



            //--------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("16."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Invoice Date"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["INVOICEDATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("17."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Respondent(Buyes) Address."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_ADDRESS"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("18."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Respondent Mobile No."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_MOBILENO"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("19."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Respondent Email"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_EMAIL"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            cell = Allcelltext(Server.HtmlDecode("20."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Principle Amount Payable"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PRINCIPLEAMOUNTPAYABLE"].ToString()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("21."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Respondent Category"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RESPONDENT_CATEGORY"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("22."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Date of Hearing"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["DATEOFHEARING"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("23."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Old Case No."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["OLDCASENO"].ToString()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------


            cell = Allcelltext(Server.HtmlDecode("24."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Mode od Payment"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["MODEOFPAYMENT"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("25."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Processing Fee Amount in Rs."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PROCESSINGFEEAMOUNT_RUPEES"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("26."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Cash Receipt No/Cheque No/DD No/Pay order No(Processing Fee)"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["RECEIPTNO"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("27."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Processing Fee Date"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["PROCESSINGFEEDATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            cell = Allcelltext(Server.HtmlDecode("28."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Final Settlement Amount"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["FINALSETTLEMENTAMOUNT"].ToString()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("29."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Final Settlement Date"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["FINALSETTLEMENTDATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("30."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Work order Date"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(ds.Tables[0].Rows[0]["WORKORDERDATE"].ToString()), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------


            cellText = Server.HtmlDecode("Note:- Print this payment receipt for further reference.");

            phrase = new Phrase();
            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.PaddingBottom = 5;
            cell.PaddingTop = 30;
            cell.Colspan = 8;
            tablenew.AddCell(cell);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            contentBytenew.SetColorStroke(color);
            contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
            contentBytenew.Stroke();
            ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

            document.Add(tablenew);
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            try
            {
                SendingEmailWithAttachment(Email, Message, bytes);
            }
            catch (Exception ex)
            {

            }
            try
            {
                // memoryStream.Close();
                // Response.Clear();
                // Response.ContentType = "application/pdf";
                // //Response.AddHeader("Content-Disposition", "attachment; filename=DepartmentwiseCFE.pdf");
                // //Response.ContentType = "application/pdf";


                // //Response.ContentType = "application/vnd.ms-excel";
                // //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                // //Response.ContentType = "application/vnd.ms-excel";

                // Response.Buffer = true;
                // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //// Response.BinaryWrite(bytes);
                // Response.Close();
                // Response.End();


                //memoryStream.Close();
                //Response.Clear();
                //Response.ContentType = "text/HTML";
                //Response.Close();
                //Response.End();

            }
            catch (Exception ex)
            {

            }
        }
    }
    public DataSet GETTSMSEFCDETAILS(string APPLICATIONNO)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Retrieve_MSEFC", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (APPLICATIONNO.Trim() == "" || APPLICATIONNO.Trim() == null)
                da.SelectCommand.Parameters.Add("@ApplicationorTempNo", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ApplicationorTempNo", SqlDbType.VarChar).Value = APPLICATIONNO.ToString();
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
    private string SendingEmailWithAttachment(string receiverMailId, string Message, byte[] bytes)
    {
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            //System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "tsipass@2016");
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
            mail.To.Add(receiverMailId);
            //mail.From = new MailAddress("tsipass.telangana@gmail.com", "tsipass@2016");
            mail.From = new MailAddress("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
            mail.Subject = "TS-iPASS - Fee Payment - Acknowledgement";
            mail.Body = "Dear User,<p>" + Message + "</p> <p>Regards,</p> TSIPASS.";
            mail.ReplyTo = new System.Net.Mail.MailAddress("tsipass.telangana@gmail.com");
            mail.IsBodyHtml = true;

            Attachment mailAttachmnet;
            mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "Receipt.pdf"));
            //ObjMailMessage.Bcc.Add("me2@mail-address.com");
            mail.Priority = MailPriority.High;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;
            smtp.Send(mail);
            return "Sent";

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public partial class Footer : PdfPageEventHelper
    {
        //new Color(127, 127, 127)
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Industry Chasing Cell.  Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, Color.BLACK));
            footer.Alignment = Element.ALIGN_LEFT;
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = 500f;
            footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfPCell cell = new PdfPCell(footer);
            cell.Border = 0;
            cell.PaddingLeft = 10;
            footerTbl.AddCell(cell);
            footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
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
        //cell.MinimumHeight = 60f;
        return cell;
    }
    private static PdfPCell PhraseCellnew(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        //cell.PaddingBottom = 5f;
        //cell.PaddingTop = 5f;
        cell.BorderWidthRight = 0.5f;
        cell.BorderWidthLeft = 0.5f;
        cell.BorderWidthTop = 0.5f;
        cell.BorderWidthBottom = 0.5f;
        cell.BorderColorBottom = Color.BLACK;
        cell.BorderColorTop = Color.BLACK;
        cell.BorderColorLeft = Color.BLACK;
        cell.BorderColorRight = Color.BLACK;
        cell.MinimumHeight = 30f;

        return cell;
    }
    private static PdfPCell Allcelltext(string Text, PdfPCell cell, int Colspanno, Color BackColor)
    {
        Phrase phrase = null;
        string cellText = Text;
        phrase = new Phrase();
        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 10, Font.NORMAL, Color.BLACK)));
        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        // cell.BackgroundColor = new Color(grdDetails.HeaderStyle.BackColor);
        cell.PaddingBottom = 5;
        cell.BackgroundColor = BackColor;
        cell.Colspan = Colspanno;
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
}