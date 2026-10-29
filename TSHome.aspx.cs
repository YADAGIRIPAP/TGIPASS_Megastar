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
using System.Data.SqlClient;
using System.Text;

public partial class TSHome : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    DataSet ds = new DataSet();
    decimal NumberTotal, manufacturingtotal, servicetotal, InvestmnetTotal, EmploymentTotal, manumicro, manusmall, manumedium, manularge, manumega, sersmall, sermicro, sermedium, serlarge, sermega, manutotal;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null || Convert.ToString(Session["uid"]) != "")
            {
                UpdateLogout();
            }
            Killsession();
            if (!IsPostBack)
            {
                if (Session.Count != 0)
                {
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();

                    if (!Page.IsPostBack)
                        Session.Abandon();
                }
                // txtuname.Focus();
                if (Request.QueryString["OTP"] != null)
                {
                    General clsGeneral = new General();
                    string userid = Request.QueryString["Uid"].ToString();
                    string OTP = Request.QueryString["OTP"].ToString();

                    string status = clsGeneral.ValidateOTPMail(userid, OTP);

                    if (status == "updated")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mail OTP Verification sucessfull!!. Please login to continue.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mail OTP is already Done!!. Please login to continue.');", true);
                    }
                    //Label1.Text = Request.QueryString["OTP"];
                    //Label1.ForeColor = System.Drawing.Color.Red
                }
                //else
                // Label1.Text = "nikkan";

                StringBuilder line = new StringBuilder();
                StringBuilder sbNews = new StringBuilder();
                DataSet ds = new DataSet();
                ds = objcommon.GetHomepagecontete();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string base64String;
                        string UrlSrc = "";
                        line.Append("<div class='ls-slide' data-ls=' transition2d: all;'>");
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Image"].ToString()))
                        {
                            byte[] bytes1 = (byte[])ds.Tables[0].Rows[i]["Image"];
                            base64String = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                            // UserImage.Src = "data:image/jpeg;base64," + base64String;
                            UrlSrc = "data:image/jpeg;base64," + base64String;
                            line.Append("<img class='ls-bg' src=" + UrlSrc + ">");
                        }
                        //line.Append("<h2 class='ls-l caption-1' style='top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px; white-space: nowrap;' data-ls='offsetxin:-80;delayin:1000;skewxin:-80;'>Welcome to TS-iPass </h2><p class='ls-l caption-1' style='top: 300px; left: 7px; font-weight: 400; font-size: 16px; padding: 15px 50px 15px 25px; line-height: 27px; white-space: nowrap;' data-ls='delayin:2000;skewxin:80;'>Telangana State Industrial Project Approval<br>and Self-Certification System (TS-iPASS) Act, 2014</p>");
                        line.Append("</div>");

                    }
                    //line.Append("<div class='ls-slide' data-ls=' transition2d: all;'><img src='images/banner3.jpg' class='ls-bg' /><h2 class='ls-l caption-1' style='top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px; white-space: nowrap;' data-ls='offsetxin:-80;delayin:1000;skewxin:-80;'>Get Industrial Project Approvals by a single click </h2><p class='ls-l caption-1' style='top: 300px; left: 7px; font-weight: 400; font-size: 16px; padding: 15px 50px 15px 25px; line-height: 27px; white-space: nowrap;' data-ls='delayin:2000;skewxin:80;'><a href='IpassLogin.aspx' class='dt-sc-bordered-button small'>Login </a><a href='UI/TSiPASS/AddnewuserRegistration.aspx' class='dt-sc-bordered-button small'>Register </a></p></div>");
                    layerslider_2.InnerHtml = line.ToString();
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    sbNews.Append("<marquee>");
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        string NewsLatest = ds.Tables[1].Rows[i]["News"].ToString();

                        if (!string.IsNullOrEmpty(NewsLatest))
                        {
                            sbNews.Append(NewsLatest + "&nbsp; | &nbsp;");
                        }
                    }
                    sbNews.Append("</marquee>");
                    divNews.InnerHtml = sbNews.ToString();
                }
                //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                //{
                //    string base64String1;
                //    string CMSrc = "";
                //    if (!string.IsNullOrEmpty(ds.Tables[2].Rows[0]["Image"].ToString()))
                //    {
                //        byte[] bytes1 = (byte[])ds.Tables[2].Rows[0]["Image"];
                //        base64String1 = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                //        // UserImage.Src = "data:image/jpeg;base64," + base64String;
                //        CMSrc = "data:image/jpeg;base64," + base64String1;
                //        imgcm.Src = CMSrc;
                //    }
                //}
                //if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                //{
                //    string base64String2;
                //    string itSrc = "";
                //    if (!string.IsNullOrEmpty(ds.Tables[3].Rows[0]["Image"].ToString()))
                //    {
                //        byte[] bytes1 = (byte[])ds.Tables[3].Rows[0]["Image"];
                //        base64String2 = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                //        // UserImage.Src = "data:image/jpeg;base64," + base64String;
                //        itSrc = "data:image/jpeg;base64," + base64String2;
                //        imgitm.Src = itSrc;
                //    }
                //}
                if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
                }

                FillGridDetails();
                Main();
            }
        }
        catch (Exception ex)
        {
            //LogErrorFile.LogData("TSHOME" + ex.Message);
        }
    }


    public void UpdateLogout()
    {
        try
        {
            int valid = 0;


            con.OpenConnection();
            SqlCommand da = new SqlCommand("[Sp_UpdateLogoutDetails]", con.GetConnection);
            da.CommandType = CommandType.StoredProcedure;
            try
            {
                string SessionID = Session.SessionID;
                da.Parameters.Add("@userid", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
                da.Parameters.Add("@username", SqlDbType.VarChar).Value = Convert.ToString(Session["username"]);
                da.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = SessionID;

                da.Parameters.Add("@result", SqlDbType.Int, 500);
                da.Parameters["@result"].Direction = ParameterDirection.Output;
                da.ExecuteNonQuery();
                valid = (Int32)da.Parameters["@result"].Value;
                con.CloseConnection();
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
        catch (Exception ex) { }
    }
    public void FillGridDetails()
    {

        ds = GetPublicViewReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            //Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string FINANCIALYEAR = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total_Application_received"));
            NumberTotal = NumberTotal1 + NumberTotal;

            decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total_Investments"));
            InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total_Empolyment"));
            EmploymentTotal = EmploymentTotal1 + EmploymentTotal;

            //decimal manumicro1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingMicro"));
            //manumicro = manumicro1 + manumicro;

            //decimal manusmall1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingSmall"));
            //manusmall = manusmall1 + manusmall;

            //decimal manumedium1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingMedium"));
            //manumedium = manumedium1 + manumedium;

            //decimal manularge1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingLarge"));
            //manularge = manularge1 + manularge;

            //decimal manumega1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingMega"));
            //manumega = manumega1 + manumega;

            //decimal sermicro1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceMicro"));
            //sermicro = sermicro1 + sermicro;

            //decimal sersmall1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceSmall"));
            //sersmall = sersmall1 + sersmall;

            //decimal sermedium1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceMedium"));
            //sermedium = sermedium1 + sermedium;

            //decimal serlarge1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceLarge"));
            //serlarge = serlarge1 + serlarge;

            //decimal sermega1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceMega"));
            //sermega = sermega1 + sermega;

            //decimal manufacturingtotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingTotal"));
            //manufacturingtotal = manufacturingtotal1 + manufacturingtotal;

            //decimal servicetotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceTotal"));
            //servicetotal = servicetotal1 + servicetotal;

            //FINANCIALYEAR = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear"));
            //HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //if (h1.Text != "0")
            //{
            //    h1.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=A&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //if (h2.Text != "0")
            //{
            //    h2.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=B&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //if (h3.Text != "0")
            //{
            //    h3.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=C&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //if (h4.Text != "0")
            //{
            //    h4.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=D&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            //if (h5.Text != "0")
            //{
            //    h5.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=E&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            //if (h6.Text != "0")
            //{
            //    h6.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=F&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            //if (h7.Text != "0")
            //{
            //    h7.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=G&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            //if (h8.Text != "0")
            //{
            //    h8.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=H&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
            //if (h9.Text != "0")
            //{
            //    h9.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=I&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h10 = (HyperLink)e.Row.Cells[11].Controls[0];
            //if (h10.Text != "0")
            //{
            //    h10.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=J&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h11 = (HyperLink)e.Row.Cells[12].Controls[0];
            //if (h11.Text != "0")
            //{
            //    h11.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=K&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h12 = (HyperLink)e.Row.Cells[13].Controls[0];
            //if (h12.Text != "0")
            //{
            //    h12.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=L&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h13 = (HyperLink)e.Row.Cells[14].Controls[0];
            //if (h13.Text != "0")
            //{
            //    h13.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=M&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h14 = (HyperLink)e.Row.Cells[15].Controls[0];
            //if (h14.Text != "0")
            //{
            //    h14.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=N&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h15 = (HyperLink)e.Row.Cells[16].Controls[0];
            //if (h15.Text != "0")
            //{
            //    h15.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=O&FINANCIALYEAR=" + FINANCIALYEAR;
            //}


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[3].Text = InvestmnetTotal.ToString();
            e.Row.Cells[4].Text = EmploymentTotal.ToString();
            //e.Row.Cells[5].Text = InvestmnetTotal.ToString();
            //e.Row.Cells[6].Text = EmploymentTotal.ToString();

            //e.Row.Cells[7].Text = manumicro.ToString();
            //e.Row.Cells[8].Text = manusmall.ToString();
            //e.Row.Cells[9].Text = manumedium.ToString();
            //e.Row.Cells[10].Text = manularge.ToString();
            //e.Row.Cells[11].Text = manumega.ToString();
            //manutotal = manumicro + manusmall + manumedium + manularge + manumedium;
            //e.Row.Cells[12].Text = sermicro.ToString();
            //e.Row.Cells[13].Text = sersmall.ToString();
            //e.Row.Cells[14].Text = sermedium.ToString();
            //e.Row.Cells[15].Text = serlarge.ToString();
            //e.Row.Cells[16].Text = sermega.ToString();
            //FINANCIALYEAR = "%";
            //HyperLink h1 = new HyperLink();
            //h1.Text = NumberTotal.ToString();
            //if (h1.Text != "0")
            //{
            //    h1.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=A&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[2].Controls.Add(h1);
            //}
            //HyperLink h2 = new HyperLink();
            //h2.Text = manufacturingtotal.ToString();
            //if (h2.Text != "0")
            //{
            //    h2.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=B&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[3].Controls.Add(h2);
            //}
            //HyperLink h3 = new HyperLink();
            //h3.Text = servicetotal.ToString();
            //if (h3.Text != "0")
            //{
            //    h3.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=C&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[4].Controls.Add(h3);
            //}
            //HyperLink h4 = new HyperLink();
            //h4.Text = InvestmnetTotal.ToString();
            //if (h4.Text != "0")
            //{
            //    h4.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=D&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[5].Controls.Add(h4);
            //}
            //HyperLink h5 = new HyperLink();
            //h5.Text = EmploymentTotal.ToString();
            //if (h5.Text != "0")
            //{
            //    h5.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=E&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[6].Controls.Add(h5);
            //}
            //HyperLink h6 = new HyperLink();
            //h6.Text = manumicro.ToString();
            //if (h6.Text != "0")
            //{
            //    h6.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=F&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[7].Controls.Add(h6);
            //}
            //HyperLink h7 = new HyperLink();
            //h7.Text = manusmall.ToString();
            //if (h7.Text != "0")
            //{
            //    h7.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=G&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[8].Controls.Add(h7);
            //}
            //HyperLink h8 = new HyperLink();
            //h8.Text = manumedium.ToString();
            //if (h8.Text != "0")
            //{
            //    h8.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=H&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[9].Controls.Add(h8);
            //}
            //HyperLink h9 = new HyperLink();
            //h9.Text = manularge.ToString();
            //if (h9.Text != "0")
            //{
            //    h9.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=I&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[10].Controls.Add(h9);
            //}
            //HyperLink h10 = new HyperLink();
            //h10.Text = manumega.ToString();
            //if (h10.Text != "0")
            //{
            //    h10.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=J&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[11].Controls.Add(h10);
            //}
            //HyperLink h11 = new HyperLink();
            //h11.Text = sermicro.ToString();
            //if (h11.Text != "0")
            //{
            //    h11.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=K&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[12].Controls.Add(h11);
            //}
            //HyperLink h12 = new HyperLink();
            //h12.Text = sersmall.ToString();
            //if (h12.Text != "0")
            //{
            //    h12.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=L&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[13].Controls.Add(h12);
            //}
            //HyperLink h13 = new HyperLink();
            //h13.Text = sermedium.ToString();
            //if (h13.Text != "0")
            //{
            //    h13.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=M&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[14].Controls.Add(h13);
            //}
            //HyperLink h14 = new HyperLink();
            //h14.Text = serlarge.ToString();
            //if (h14.Text != "0")
            //{
            //    h14.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=N&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[15].Controls.Add(h14);
            //}
            //HyperLink h15 = new HyperLink();
            //h15.Text = sermega.ToString();
            //if (h15.Text != "0")
            //{
            //    h15.NavigateUrl = "TSHOMEDRILLDOWN.aspx?STATUS=O&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[16].Controls.Add(h15);
            //}
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
                if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17)
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
            tcMergePackage.Text = "Service";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage);
            TableCell tcMergePackage1 = new TableCell();


            tcMergePackage1.Text = "Manufacturing";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage1);

        }
    }

    public DataSet GetPublicViewReport()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
          //  da = new SqlDataAdapter("USP_GET_PUBLICVIEWDASHBOARD", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_PUBLICVIEWDASHBOARD_NEWCOMMISSIONER_DASHBOARD_NEWGOVTANDUNDERPROCESSANDPLOTAPPROVED", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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


    public void Killsession()
    {

        if (Request.Cookies["ASP.NET_SessionId"] != null)
        {

            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;

            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

        }
        if (Request.Cookies["ASP.NET_SessionIdTemp"] != null)
        {
            Response.Cookies["ASP.NET_SessionIdTemp"].Value = string.Empty;

            Response.Cookies["ASP.NET_SessionIdTemp"].Expires = DateTime.Now.AddMonths(-20);
        }

        if (Request.Cookies["AuthToken"] != null)
        {

            Response.Cookies["AuthToken"].Value = string.Empty;

            Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

        }
        if (Request.Cookies["__AntiXsrfToken"] != null)
        {

            Response.Cookies["__AntiXsrfToken"].Value = string.Empty;

            Response.Cookies["__AntiXsrfToken"].Expires = DateTime.Now.AddMonths(-20);

        }
        Session.Abandon();
        Session.Clear();

        var manager = new System.Web.SessionState.SessionIDManager();
        string newSessionId = manager.CreateSessionID(HttpContext.Current);
        bool isRedirected = false;
        bool isAdded = false;
        manager.SaveSessionID(HttpContext.Current, newSessionId, out isRedirected, out isAdded);

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.SetNoStore();
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.Cache.SetExpires(DateTime.Now);
        //Response.Cache.SetNoStore();
        //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

    }
    public string RecordClick()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();

            SqlCommand insertCmd = new SqlCommand("INSCHATBOTCLICK", conn);
            insertCmd.CommandType = CommandType.StoredProcedure;
            insertCmd.Parameters.AddWithValue("@IPADDRESS", getclientIP());
            insertCmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
            insertCmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
            insertCmd.ExecuteNonQuery();
            string res = insertCmd.Parameters["@RESULT"].Value.ToString();
            //SqlCommand countCmd = new SqlCommand("USP_GETCHATBOTCLICK", conn);
            //countCmd.CommandType = CommandType.StoredProcedure;
            //int total = (int)countCmd.ExecuteScalar();

            return res;
        }
    }

    public void Main()
    {
        DataSet ds = new DataSet();
        ds = GetClickCount();
        if (ds.Tables[0].Rows.Count > 0)
        {
            // lblClickCount.Text = Convert.ToString(ds.Tables[0].Rows[0]["VIEWCOUNT"]);
            lblClickCount.Text = "Chatbot View Count: " + Convert.ToString(ds.Tables[0].Rows[0]["VIEWCOUNT"]);

        }
    }
    public DataSet GetClickCount()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("USP_GETCHATBOTCLICK", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void lnkChat_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            // RecordClick();

            string total = RecordClick();
            lblClickCount.Text = "Chatbot View Count: " + total;
            ClientScript.RegisterStartupScript(this.GetType(), "openChat", "toggleChat();", true);
            Main();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}