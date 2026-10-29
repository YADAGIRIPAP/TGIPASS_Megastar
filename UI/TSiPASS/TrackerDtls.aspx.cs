using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UI_TSiPASS_TrackerDtls : System.Web.UI.Page
{
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string intQuessionaireid = "", intStageid = "", intApprovalid = "";

            intQuessionaireid = Request.QueryString["intQuessionaireid"].ToString().Trim();
            intStageid = Request.QueryString["intStageid"].ToString().Trim();
            intApprovalid = Request.QueryString["intApprovalid"].ToString().Trim();

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetApplicationTrackerDetailedDetails(intQuessionaireid, intStageid, intApprovalid);
            if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
            {
                if (intStageid == "1")
                {
                    trquerydtls.Visible = true;
                    trPayment.Visible = false;
                    trrejcted.Visible = false;

                    tddeptname.InnerHtml = dscheck.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                    tdqdate.InnerHtml = dscheck.Tables[0].Rows[0]["QRYRSDDATE"].ToString().Trim();
                    tdremarks.InnerHtml = dscheck.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                    tdResponseDate.InnerHtml = dscheck.Tables[0].Rows[0]["QRYRESPDATE"].ToString().Trim();
                    tdnotakes.InnerHtml = dscheck.Tables[0].Rows[0]["Nodaystakne"].ToString().Trim();
                    tdresonce.InnerHtml = dscheck.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim();
                    if (dscheck.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim() == "")
                    {
                        trresponce1.Visible = false;
                        trresponce2.Visible = false;
                    }
                    if (dscheck.Tables[0].Rows[0]["QueryDetails"].ToString() != "" && dscheck.Tables[0].Rows[0]["QueryDetails"].ToString() != string.Empty)
                    {
                        string attachmentid = dscheck.Tables[0].Rows[0]["QueryDetails"].ToString().Trim();
                        if (dscheck.Tables[0].Rows[0]["additionaldocs"].ToString().Contains(','))
                        {
                            string[] split = dscheck.Tables[0].Rows[0]["QueryDetails"].ToString().Split(',');
                            for (int i = 0; i < split.Length; i++)
                            {
                                if (split[i].ToString().TrimStart().Trim() == "10")//Combined building plan including all floor plans
                                {
                                    trshortfalldoc.Visible = true;
                                    string[] split1 = dscheck.Tables[0].Rows[0]["additionaldocs"].ToString().Split(',');
                                    HyperLink1.Text = "Short Fall Letter";
                                    HyperLink1.NavigateUrl = split1[0];
                                    trsDraawingfalldoc.Visible = true;
                                    HyperLink2.Text = "Drawing Short Fall Letter";
                                    HyperLink2.NavigateUrl = split1[1];

                                }
                                else
                                {
                                    trshortfalldoc.Visible = true;
                                    HyperLink1.Text = "Short Fall Letter";
                                    HyperLink1.NavigateUrl = dscheck.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();
                                    trsDraawingfalldoc.Visible = false;
                                }
                                
                            }
                        }
                        else
                        {
                            trshortfalldoc.Visible = true;
                            HyperLink1.Text = "Short Fall Letter";
                            HyperLink1.NavigateUrl = dscheck.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();
                            trsDraawingfalldoc.Visible = false;
                        }
                        if (intApprovalid == "35")
                        {
                            trshortfalldoc.Visible = false;

                        }


                    }

                    if (dscheck != null && dscheck.Tables.Count > 1 && dscheck.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToString(dscheck.Tables[1].Rows[0]["Linknew"]) != "")
                        {
                            Trqueryresponceattachemnts.Visible = true;
                            gvqueryresponse.DataSource = dscheck.Tables[1];
                            gvqueryresponse.DataBind();
                        }
                    }
                }
                else if (intStageid == "2" || intStageid == "3" || intStageid == "6")
                {
                    trquerydtls.Visible = false;
                    trPayment.Visible = true;
                    trrejcted.Visible = false;
                    grdDetails.DataSource = dscheck.Tables[0];
                    grdDetails.DataBind();

                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        //foreach (TableCell cell in row.Cells)
                        //{
                        row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                        row.Cells[3].Attributes.CssStyle["Width"] = "100px";
                        //}
                    }
                }
                else if (intStageid == "4")
                {
                    trquerydtls.Visible = false;
                    trPayment.Visible = false;
                    trrejcted.Visible = true;
                    tddeptnamenew.InnerHtml = dscheck.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                    tdrejcteddate.InnerHtml = dscheck.Tables[0].Rows[0]["Dept_Rejected_date"].ToString().Trim();
                    tdremarksrejected.InnerHtml = dscheck.Tables[0].Rows[0]["rejected_reason"].ToString().Trim();

                    if (dscheck != null && dscheck.Tables.Count > 1 && dscheck.Tables[1].Rows.Count > 0)
                    {
                        hmdaattachements.Visible = true;
                        gvlastattachments.DataSource = dscheck.Tables[1];
                        gvlastattachments.DataBind();
                    }
                }
                else if (intStageid == "5")
                {
                    trquerydtls.Visible = false;
                    trPayment.Visible = false;
                    trrejcted.Visible = false;
                    Divappsinfo.Visible = true;
                    if (intApprovalid == "6" || intApprovalid == "45")
                    {
                        tddeptnameapp.InnerHtml = dscheck.Tables[0].Rows[0]["Name of the approval"].ToString().Trim();
                        tdApprovalAppliedDate.InnerHtml = dscheck.Tables[0].Rows[0]["Approval Application Date"].ToString().Trim();
                        tdtpscdate.InnerHtml = dscheck.Tables[0].Rows[0]["Target Date of PSC"].ToString().Trim();
                        tdpscdate.InnerHtml = dscheck.Tables[0].Rows[0]["PSC Completion_Rejection Date"].ToString().Trim();

                        tddaystakenpsc.InnerHtml = dscheck.Tables[0].Rows[0]["No of days taken for PSC excluding holidays"].ToString().Trim();
                        tdReceivedApproval.InnerHtml = dscheck.Tables[0].Rows[0]["Date of Approval received to Approval Stage Max of payment or PSC date"].ToString().Trim();
                        tdSendMAUDTarget.InnerHtml = dscheck.Tables[0].Rows[0]["APPROVALDATEHMDANEW"].ToString().Trim();
                        tdDateofSenttoMAUD.InnerHtml = dscheck.Tables[0].Rows[0]["HMDASnetDate"].ToString().Trim();
                        tdDaysTaken.InnerHtml = dscheck.Tables[0].Rows[0]["Noofdaystakentosendmaud"].ToString().Trim();   // hmda days 
                        // tdpscdate.InnerHtml = dscheck.Tables[0].Rows[0][""].ToString().Trim();
                    }
                    if (intApprovalid == "45")
                    {
                        trmauddata1.Visible = true;
                        trmauddata.Visible = true;
                        trmauddata2.Visible = true;
                        tdTargetDateforApprovalmaud.InnerHtml = dscheck.Tables[0].Rows[0]["APPROVALDATEMAUDNEW"].ToString().Trim();
                        tdActualApprovaldate.InnerHtml = dscheck.Tables[0].Rows[0]["Actual Date of Approval Rejection"].ToString().Trim();
                        tdDaysTakenforApproval.InnerHtml = dscheck.Tables[0].Rows[0]["Noofdaystakentoapprovemaud"].ToString().Trim();
                    }
                }
            }
            else if (intStageid == "21")
            {

                trrejectionDtls.Visible = true;
                //trrejectionDtls.Visible = true;
                //DataSet dsRejectDetailsCheck = new DataSet();
                //dscheck=Gen.
                SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                //private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                osqlConnection.Open();
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                try
                {
                    // da = new SqlDataAdapter("GetApplicationTrackerDetailed2", con.GetConnection);
                    da = new SqlDataAdapter("USP_GETREJECTIONALLDETAILS_TRACKER", osqlConnection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;



                    if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                        da.SelectCommand.Parameters.Add("@intquesssionaireid", SqlDbType.VarChar).Value = "%";
                    else
                        da.SelectCommand.Parameters.Add("@intquesssionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

                    da.SelectCommand.Parameters.Add("@intapprovalid", SqlDbType.VarChar).Value = intApprovalid.ToString();

                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblDepartmentName.Text = ds.Tables[0].Rows[0]["Dept_Full_name"].ToString();
                        lblRejectedDate.Text = ds.Tables[0].Rows[0]["Dept_Rejected_date"].ToString();
                        lblRejectionRemarks.Text = ds.Tables[0].Rows[0]["rejected_reason"].ToString();
                        lblAppeal.Text = ds.Tables[0].Rows[0]["AppealDescription"].ToString();
                        lblAppealDate.Text = ds.Tables[0].Rows[0]["Appealdate"].ToString();
                        hplRejection.NavigateUrl = ds.Tables[0].Rows[0]["RejectedLetter"].ToString();

                    }

                    DataSet dsAppeal = new DataSet();
                    string intapprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString();
                    SqlDataAdapter osqlDataAdapter;
                    //dsAppeal = Gen.GetdatabyDeptinCFEdocumentAppeal(intQuessionaireid,intapprovalid);
                    osqlDataAdapter = new SqlDataAdapter("sp_RetrivelinkbyDeptid_Appeal", osqlConnection);
                    osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                        osqlDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
                    else
                        osqlDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

                    osqlDataAdapter.SelectCommand.Parameters.Add("@intCheck", SqlDbType.VarChar).Value = "1";
                    osqlDataAdapter.SelectCommand.Parameters.Add("@intapprovalid", SqlDbType.VarChar).Value = intapprovalid;


                    osqlDataAdapter.Fill(dsAppeal);

                    if (dsAppeal.Tables[0].Rows.Count > 0)
                    {
                        Tr10.Visible = true;
                        int c = dsAppeal.Tables[0].Rows.Count;
                        string sen, sen1;
                        int i = 0;
                        Label[] lab = new Label[100];
                        Label[] lab1 = new Label[100];

                        while (i < c)
                        {
                            sen = dsAppeal.Tables[0].Rows[i][0].ToString();
                            //sen1 = sen2.Replace(@"\", @"/");
                            // D:\Frux Hosting\TS-iPASS\Attachments\1061\Combinedbuildingplan
                            sen1 = sen.Replace("D:/TS-iPASSFinal/", "../../");
                            lab[i] = new Label();
                            lab[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                            lab[i].Text += "<tr><td> <a href='" + sen1 + "' target='_blank' style='color:#FF6600;'>" + "Appeal Attachment" + "</a></td></tr>";
                            lab[i].Text += "</table><br/>";
                            pnlAppeal.Controls.Add(lab[i]);
                            lab1[i] = new Label();
                            lab1[i].Text += "<table style='border: 1px solid #003366;' width='100%'>";
                            lab1[i].Text += "<tr><td> " + (i + 1) + "</td></tr>";
                            lab1[i].Text += "</table><br/>";
                            pnlAppealCount.Controls.Add(lab1[i]);

                            i++;
                        }

                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    osqlConnection.Close();
                }
            }
        }
    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(e.Row.Cells[3].Text);
            TotalFee = TotalFee + TotalFee1;
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0");
            e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
        }
    }


    protected void gvqueryresponse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLinkSubsidy");
                if (filepathnew.Contains("TS-iPASSFinal") && filepathnew.Contains("Attachments"))
                    h1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                else
                    h1.NavigateUrl = filepathnew;
                //h1.Text = "Click Here";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}