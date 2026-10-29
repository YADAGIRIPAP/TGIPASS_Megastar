using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
// using iTextSharp.tool;
using System.Text;

public partial class UI_TSiPASS_ProformaQueryRaiseShortFallLetterGMtoApplicant : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
                {
                    string userid = Session["uid"].ToString();
                    string incentiveid = "";
                    incentiveid = Request.QueryString["incentiveid"].ToString();

                    DataSet ds = new DataSet();
                    ds = Gen.GetBasicUnitDetails(incentiveid);
                    binddata(ds);

                    DataSet dsname = new DataSet();
                    //dsname = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveid, "6", "");  // need to clarify
                    //if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                    //{
                    //    if (dsname.Tables[0].Rows[0]["GMName"].ToString() != null)
                    //    {
                    //        lblName.Text = dsname.Tables[0].Rows[0]["GMName"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["GMDesignation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["GMDist"].ToString();
                    //        lblletterFrom.Text =dsname.Tables[0].Rows[0]["Dist"].ToString();
                    //    }
                    //}

                    dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "6", userid, "", "BEFOREINSPQUERYGM");
                    if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                    {
                        if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                        {
                            lblName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br> DIC-" + dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                            lblletterFrom.Text = dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                        }
                    }

                    string txtunitemailid = "";
                    string txtApplicantName = "";
                    if (ds.Tables[0].Rows[0]["UnitEmail"].ToString() != null || ds.Tables[0].Rows[0]["UnitEmail"].ToString() != "")
                    {
                        txtunitemailid = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
                        txtApplicantName = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                    }

                    string Incentiveslist = "";
                    int countno = 1;
                    foreach (GridViewRow gvrow in gvShortfalls.Rows)
                    {
                        if (Incentiveslist == "")
                        {
                            Incentiveslist = countno + ". " + gvrow.Cells[1].Text;
                        }
                        else
                        {
                            Incentiveslist = Incentiveslist + ", <br />" + countno + ". " + gvrow.Cells[1].Text;
                        }
                        countno = countno + 1;
                    }
                    try
                    {
                   //SendMailIncentiveQuery(txtunitemailid, "Dear " + txtApplicantName + "<br /><br />The query has been raised against the " + Incentiveslist + ".<br /> Kindly find the attached query letter. Thank You,<br />  Govt. of Telangana.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
    //protected override void Render(HtmlTextWriter writer)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    HtmlTextWriter tw = new HtmlTextWriter(new StringWriter(sb));
    //    base.Render(tw);
    //    ViewState["innerHtml"] = sb.ToString();
    //}
    public void SendMailIncentiveQuery(string mailid, string Messages)
    {

        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        // string to = mailid; //Replace this with the Email Address to whom you want to send the mail
        string to = "shankarachary.pa9@gmail.com";
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //  mail.CC.Add("coi.tsipass@gmail.com");
        //  mail.CC.Add("kcsbabu@gmail.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Incentive Inspection ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        // string sb = "";
        //StringBuilder sb = new StringBuilder();
        //HtmlTextWriter tw = new HtmlTextWriter(new StringWriter(sb));

        //  string innerHtml = tdpage.InnerHtml;

        // StringWriter sw = new StringWriter();
        // HtmlTextWriter tw = new HtmlTextWriter(sw);
        // this.Page.RenderControl(tw);
        //// sb = tblpage.InnerHtml;
        // string text = sw.ToString();
        //// StringReader sr = new StringReader(sw.ToString().Replace("<img src=\"../../telanganalogo.png\" height=\"75\" width=\"75\" />", ""));
        // StringReader sr = new StringReader(sw.ToString().Replace("<img src=\"telanganalogo.png\" width=\"75px\" height=\"75px\" />", ""));

        // Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        // HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        // using (MemoryStream memoryStream = new MemoryStream())
        // {
        //     PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        //     pdfDoc.Open();
        //     htmlparser.Parse(sr);
        //     pdfDoc.Close();
        //     byte[] bytes = memoryStream.ToArray();
        //     memoryStream.Close();
        var sb = new StringBuilder();

        this.Page.RenderControl(new HtmlTextWriter(new StringWriter(sb)));

        string s = sb.ToString();


        //StringWriter stringWriter = new StringWriter();
        //HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
        //Receipt.RenderControl(htmlTextWriterw);
        s = s.Replace("px", "");

        s = s.Replace("<img src=\"telanganalogo.png\" width=\"75\" height=\"75\" />", "");

        StringReader stringReader = new StringReader(s.ToString());
        Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        MemoryStream memoryStream = new MemoryStream();
       // PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        pdfDoc.Open();
       // iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, stringReader);
        htmlparser.Parse(stringReader);
        pdfDoc.Close();
        byte[] bytes = memoryStream.ToArray();
        memoryStream.Close();

        mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "queryletter.pdf"));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        //}
        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password
        //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
       // client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
        client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");


        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
    }
    public void binddata(DataSet ds)
    {
        //if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
        //{
        //    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
        //    {
        //        lblTIdeaTPride.Text = "T-IDEA";
        //    }
        //}
        //if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
        //{

        //    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
        //    {
        //        lblTIdeaTPride.Text = "T-PRIDE";
        //    }
        //}
        //if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
        //{
        //    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
        //    {
        //        lblTIdeaTPride.Text = "T-PRIDE";
        //    }
        //}
        if (ds.Tables[0].Rows[0]["Scheme"].ToString() != null || ds.Tables[0].Rows[0]["Scheme"].ToString() != "")
        {
            lblTIdeaTPride.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
        }
        if ((ds.Tables[0].Rows[0]["Scheme"].ToString()).Contains("IDEA"))
        {
            if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-IDEA";                   
                }
            }
            if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
            {

                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-PRIDE(TSCP)";            

                }
            }
            if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-PRIDE(TSP)";               
                }
            }
            if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
            {

                lblTIdeaTPride.Text = lblTIdeaTPride.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");


            }
        }


        if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != "")
        {
            lblEntDist.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist1.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblhead.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
        }
        lblRefLetterDate.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
        lblLetterNo.Text = "DIC/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
       // lblRefLetterNo.Text = "DIC/" + Request.QueryString["incentiveid"].ToString();

        if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null && ds.Tables[0].Rows[0]["applicationno"].ToString() != "")
        {
            lblRefLetterNo.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
        }

        if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "")
        {
            lblLetterDate.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
        }
        if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
        {
            lblEnterpreneurDetails.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
        }

        lblEnterpreneurDetails1.Text = "Sri. " + ds.Tables[0].Rows[0]["ApplciantName"].ToString() + ",<br/>" + ds.Tables[0].Rows[0]["UnitDtls"].ToString() + ",<br/> " + lblEntDist1.Text + "  District";
        if (ds.Tables[0].Rows[0]["UnitName"].ToString() != null || ds.Tables[0].Rows[0]["UnitName"].ToString() != "")
        {
            lblEnterpreneurDetails3.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
        {
            lblquerydays.Text = Convert.ToString(ds.Tables[2].Rows[0]["querydays"]);
        }
        // bind query details grid
        string incentiveid = "";
        incentiveid = Request.QueryString["incentiveid"].ToString();
        DataSet daquerie = new DataSet();
        //  daquerie = Gen.GetIncetiveDetailsdeptOfficerRemarksDraft(incentiveid, "", Session["User_Code"].ToString(), "JD");


        daquerie = Gen.GetQueryDetailsdept(Session["uid"].ToString(), incentiveid, "", "ALL","");
        if (daquerie != null && daquerie.Tables.Count > 0 && daquerie.Tables[0].Rows.Count > 0)
        {
            gvShortfalls.DataSource = daquerie.Tables[0];
            gvShortfalls.DataBind();
            Session["CertificateTb2"] = daquerie.Tables[0];
            //foreach (GridViewRow rown in gvShortfalls.Rows)
            //{
            //    string name = ((Label)rown.FindControl("lblCreatedByid")).Text.ToString();
            //    if (Session["uid"].ToString() != name)
            //    {
            //        DataControlFieldCell editable = (DataControlFieldCell)rown.Controls[1];
            //        editable.Enabled = false;
            //    }
            //}
        }
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetIncetiveDetailsdept(incentiveid);

        //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        //{
        //    gvShortfalls.DataSource = dsnew.Tables[0];
        //    gvShortfalls.DataBind();
        //    gvShortfalls.Visible = true;
        //}

    }
}