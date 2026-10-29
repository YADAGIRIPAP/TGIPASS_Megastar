using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmlistofwellapplicationdetails : System.Web.UI.Page
{
    Cls_OSGroundWater obj_insert = new Cls_OSGroundWater();
    string Statusofappl = ""; string Category = ""; string Districtid = ""; string DistrictName = ""; string applicationtype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_headtitle.Text = "Well Applications";
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                //Request.QueryString[0].Trim()

                Statusofappl = Convert.ToString(Request.QueryString["Status"]);
                Category = Convert.ToString(Request.QueryString["Category"].Trim());
                Districtid = Convert.ToString(Request.QueryString["Districtid"].Trim());
                DistrictName = Convert.ToString(Request.QueryString["DistrictName"].Trim());
                applicationtype = Convert.ToString(Request.QueryString["Typedataofappl"].Trim());

                lbl_headtitle.Text = "Well Applications";
            }
            fillgrid(applicationtype, Statusofappl, Category, Districtid);
        }
    }


    public void fillgrid(string Typedataofappl, string Status, string Category, string Districtid)
    {


        DataSet vehicleDS = new DataSet();
        vehicleDS = obj_insert.DB_statereportlistofwellrigsdetails(Typedataofappl, Status, Category, Districtid);
        grdDetails.DataSource = vehicleDS;
        grdDetails.DataBind();
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //        ID,ApplicationType_IndusorAgri,ApplicantName,DistrictID,MandalId,VillageId,Street,HouseNo,LocationOfWell,TypeofWell,TypeOfDrwngWater,
        //SpecifactioncnOFPump,DistanceFromExistWell,StageId,paymentFlag,ApplicationType_IndusorAgriName,UID_No,App_Status,PaymentDate,
        //DWGOApproved,DWGOApproveddate,DWGOApprovedby,FormRejectNumber,FormApproveNumber,FormAppNumber,DistrictName,MandalName,VillageName,
        //ApplicantMobileNO,ApplicantEmailID,TypeofWellName,TypeOfDrwngWaterName,DWGORejected,DWGORejecteddate,DWGORejectedby,DWGOQueryRaised,
        //DWGOQueryRaiseddate,DWGOQueryRaisedby,ISDWGOQueryResponded,MROApproveddate,MRORejecteddate,District_Name,Manda_lName,Village_Name,
        //intCFEEnterpid,Address,Status,Query_RaiseDate,QueryRespondDate,MRORejectedReason,DGWORejetedReason
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink anchortaglink_applicationform = (HyperLink)e.Row.FindControl("anchortaglink_applicationform");
            HyperLink anchortaglink_payment = (HyperLink)e.Row.FindControl("anchortaglink_payment");
            HyperLink anchortaglink_attachment = (HyperLink)e.Row.FindControl("anchortaglink_attachment");

            anchortaglink_applicationform.Target = "_blank";
            anchortaglink_applicationform.NavigateUrl = "GroundWaterPrint.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            anchortaglink_payment.Target = "_blank";
            anchortaglink_payment.NavigateUrl = "UserGroundwaterPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            anchortaglink_attachment.Target = "_blank";
            anchortaglink_attachment.NavigateUrl = "UserGroundwaterAttachments.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            Label lbl_grdrejectedremarks = (Label)e.Row.FindControl("lbl_grdrejectedremarks");
            Label lbl_queryraisedetails = (Label)e.Row.FindControl("lbl_queryraisedetails");
            Label lbl_queryresponsedetails = (Label)e.Row.FindControl("lbl_queryresponsedetails");
            lbl_grdrejectedremarks.Visible = false;
            lbl_queryraisedetails.Visible = false;
            lbl_queryresponsedetails.Visible = false;

            string Rejectedreason = "";
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MRORejectedReason"))))
            {
                Rejectedreason = "MRO Rejected Reason:" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MRORejectedReason"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DGWORejetedReason"))))
            {
                Rejectedreason += Rejectedreason + "Ground water Rejected Reason:" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DGWORejetedReason"));
            }
            if (!string.IsNullOrEmpty(Rejectedreason))
            {
                lbl_grdrejectedremarks.Visible = true;
                lbl_grdrejectedremarks.Text = Rejectedreason;
            }
            string Queryraiseddate = "";
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                Queryraiseddate = "MRO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaiseddate"))))
            {
                Queryraiseddate += Queryraiseddate + "DGWO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaiseddate"));
            }
            if (!string.IsNullOrEmpty(Queryraiseddate))
            {
                lbl_queryraisedetails.Visible = true;
                lbl_queryraisedetails.Text = Queryraiseddate;
            }

            string Queryresponsedate = "";

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"))))
            {
                Queryresponsedate = "MRO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
            {
                Queryresponsedate += Queryresponsedate + "DGWO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"));
            }

            if (!string.IsNullOrEmpty(Queryresponsedate))
            {
                lbl_queryresponsedetails.Visible = true;
                lbl_queryresponsedetails.Text = Queryresponsedate;
            }

            HyperLink hyp_viewqueryresponse = (HyperLink)e.Row.FindControl("hyp_viewqueryresponse");
            hyp_viewqueryresponse.Visible = false;

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
                {
                    hyp_viewqueryresponse.Visible = true;
                    hyp_viewqueryresponse.NavigateUrl = "frmqueryresponseview_GroundwaterUser.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaiseddate"))))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"))))
                {
                    hyp_viewqueryresponse.Visible = true;
                    hyp_viewqueryresponse.NavigateUrl = "frmqueryresponseview_GroundwaterUser.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }

            HyperLink anchortaglink_approvalrejectedattachment = (HyperLink)e.Row.FindControl("anchortaglink_approvalrejectedattachment");
            anchortaglink_approvalrejectedattachment.Visible = false;

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId"))))
            {             
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalDocument"))))
                {
                    anchortaglink_approvalrejectedattachment.ForeColor = System.Drawing.Color.Green;
                    anchortaglink_approvalrejectedattachment.Text = "Approval Document";
                    anchortaglink_approvalrejectedattachment.Visible = true;
                    anchortaglink_approvalrejectedattachment.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalDocument"));
                }
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedDocument"))))
                {
                    anchortaglink_approvalrejectedattachment.ForeColor = System.Drawing.Color.Red;
                    anchortaglink_approvalrejectedattachment.Text = "Rejected Document";
                    anchortaglink_approvalrejectedattachment.Visible = true;
                    anchortaglink_approvalrejectedattachment.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedDocument"));
                }
            }
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();
        // fillgrid();

    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=R6.3: TSiPASS - Progress Of Implementation Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //  Government.Visible = true;
            tr1.Style["width"] = "680px";
            // Button1.Visible = false;
            Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                //To Export all pages
                grdDetails.AllowPaging = false;
                this.fillgrid(applicationtype, Statusofappl, Category, Districtid);

                grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                {
                    //cell.BackColor = GridView1.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.Black;
                }
                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                    cell.ForeColor = System.Drawing.Color.Black;
                    // cell.
                }


                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {

                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();
                    foreach (Control control in cell.Controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                controls.Add(control);
                                break;
                            case "TextBox":
                                controls.Add(control);
                                break;
                            case "LinkButton":
                                controls.Add(control);
                                break;
                            case "CheckBox":
                                controls.Add(control);
                                break;
                            case "RadioButton":
                                controls.Add(control);
                                break;
                        }
                    }
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdDetails.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();
                        foreach (Control control in cell.Controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    controls.Add(control);
                                    break;
                                case "TextBox":
                                    controls.Add(control);
                                    break;
                                case "LinkButton":
                                    controls.Add(control);
                                    break;
                                case "CheckBox":
                                    controls.Add(control);
                                    break;
                                case "RadioButton":
                                    controls.Add(control);
                                    break;
                            }
                        }
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                }

                divPrint.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    Button2.Visible = false;
            //    Button1.Visible = false;
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    divPrint.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = true;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.5_Month_wise_Applications_Received" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }


}