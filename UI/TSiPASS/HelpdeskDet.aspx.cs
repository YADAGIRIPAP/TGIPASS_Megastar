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
using System.Data.SqlClient;

public partial class HelpdeskDet : System.Web.UI.Page
{
    #region Declarations

    DB.DB con1 = new DB.DB();
    General clsCommon = new General();
    //General clsGeneral = new General();
    DataSet ds = new DataSet();
    //SqlDataReader drFBNum = null;
    int sno = 0;
    string stat = "", fromdt1 = "", todt1 = "", FBType = "", FBNum = "", PiaName = "", PiaNum = "", ReqType="";

    #endregion
    DB.DB con = new DB.DB();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            //if (Session.Count > 0)
            //{

            //}


            if (!IsPostBack)
            {
                
                if (Request.QueryString.Count != 5)
                {
                    stat = Request.QueryString["code"].Trim();
                    fromdt1 = Request.QueryString["Fr"].Trim();
                    todt1 = Request.QueryString["To"].Trim();
                    FBType = Request.QueryString["FBTyp"].Trim();
                    FBNum = Request.QueryString["FBNo"].Trim();
                    PiaNum = Request.QueryString["Piano"].Trim();
                    PiaName = Request.QueryString["Pianam"].Trim();
                    Session["ReqType"] = "2";
                    //ReqType = "With Pia";
                }
                else
                {
                    stat = Request.QueryString["code"].Trim();
                    fromdt1 = Request.QueryString["Fr"].Trim();
                    todt1 = Request.QueryString["To"].Trim();
                    FBType = Request.QueryString["FBTyp"].Trim();
                    FBNum = Request.QueryString["FBNo"].Trim();
                    PiaNum = "";
                    Session["ReqType"] = "1";
                    //ReqType = "Without Pia";
                }

                fillgrid();
            }
            
        }
        catch (Exception ex)
        {
        }
        
    }

    #region GridBinding
    public void fillgrid()
    {
        try
        {
            //con1.OpenConnection();
            //drFBNum = clsCommon.GetFBNum(FBType, con1.GetConnection);
            ////FBNum = drFBNum.Read();
            //while (drFBNum.Read())
            //{
            //    FBNum = drFBNum.GetString(0);
            //}
            DataSet HelpDeskDS = new DataSet();
           // HelpDeskDS = clsCommon.GetFBDet(stat, fromdt1, todt1, FBNum, PiaNum);
            HelpDeskDS = GetFBDet(stat, fromdt1, todt1, FBNum, PiaNum);
            grdHelpdesk.DataSource = HelpDeskDS;
            grdHelpdesk.DataBind();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Convert.ToInt32(Session["uid"].ToString()));
        }
        finally
        {
        }
    }
    #endregion
    public DataSet GetFBDet(string status, string FromDt, string Todt, string FBNum, string PiaNum)
    {
        string cond = " ";
        if (FromDt.Trim() != "" && Todt.Trim() != "")
            cond = "  where   (DATEDIFF(dd, '" + FromDt.Trim() + "', created_dt) >= 0) and (DATEDIFF(dd, '" + Todt.Trim() + "', created_dt) <= 0)  ";
        switch (status)
        {
            case "1":
                break;
            case "2":
                if (cond.Trim() != "")
                    cond = cond + " and Status='Open' ";
                else
                    cond = cond + " where Status='Open' ";
                break;
            case "3":
                if (cond.Trim() != "")
                    cond = cond + " and Status='Closed' ";
                else
                    cond = cond + " where Status='Closed' ";
                break;
            case "4":
                if (cond.Trim() != "")
                    cond = cond + " and Status='Rejected' ";
                else
                    cond = cond + " where Status='Rejected' ";
                break;

        }
        if (FBNum.Trim() != "")
        {
            if (cond.Trim() != "")
                cond = cond + " and intfb_id='" + FBNum.Trim() + "'";
            else
                cond = cond + " where intfb_id='" + FBNum.Trim() + "'";
        }
        if (PiaNum.Trim() != "")
        {
            if (cond.Trim() != "")
                cond = cond + " and hd_Username='" + PiaNum.Trim() + "'";
            else
                cond = cond + " where hd_Username='" + PiaNum.Trim() + "'" + " order by Created_dt desc";
        }

        string qryList;
        qryList = "Select int_fbid,User_Type,hd_desc,Remarks,Status,hd_uplddocname,hd_fileuploadname, REPLACE(REPLACE(REPLACE(uploadfilepath, '\\', '/'),'D:','https://ipass.telangana.gov.in'),'/TS-iPASSFinal/','/')+'\\'+hd_fileuploadname as filepath,Reply_Filename, REPLACE(Reply_Filepath, '\\','/') as Reply_Filepath,uploadfilepath+'\\'+hd_fileuploadname as LINKNEW,convert(varchar,Created_dt, 103) as Createddt,convert(varchar,Modified_dt, 103) as Modified_dt  from tm_Helpdesk " + cond;

        return (con.ExecuteQuery(qryList));
    }
    protected void grdHelpdesk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    sno = ++sno;
        //    e.Row.Cells[0].Text = sno.ToString();
        //    e.Row.Cells[1].Text = FBType.ToString();
        //    HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter");
        //    h2.NavigateUrl = "HDDocsDL.aspx?type=2&id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "int_fbid"));
        //    h2.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "hd_uplddocname"));
        //}
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            sno = ++sno;
            e.Row.Cells[0].Text = sno.ToString();
            e.Row.Cells[1].Text = FBType.ToString();
            HyperLink hypReply_Filepath = (HyperLink)e.Row.FindControl("hypReply_Filepath");
            HyperLink hypLetter = (HyperLink)e.Row.FindControl("hypLetter");
            string filepath = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Reply_Filepath"));

            //https://ipass.telangana.gov.in/TS-iPASSFinal/Helpdesk/77261/189379/Blank15.pdf
            if (filepath != "")
            {

                string encpassword = Gen.Encrypt(filepath, "SYSTIME");
                hypReply_Filepath.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
            }
            else
            {
                hypReply_Filepath.Visible = false;
            }
            string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
            if (filepathnew != "")
            {

                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                hypLetter.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
            }
            else
            {
                hypLetter.Visible = false;
            }

            //h2.NavigateUrl = "HDDocsDL.aspx?type=2&id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "int_fbid"));
            // h2.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "hd_uplddocname"));


        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        //if (ReqType == "Without Pia")
        if (Session["ReqType"].ToString().Trim() == "1")        
            Response.Redirect("Helpdeskrpt.aspx");
        if (Session["ReqType"].ToString().Trim() == "2")
        //if (ReqType=="With Pia")
            Response.Redirect("HDPiaRpt.aspx");

    }
}
