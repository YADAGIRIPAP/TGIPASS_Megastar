using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_Category : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet dscheck = new DataSet();
            if (Session.Count <= 0)
            {
                Response.Redirect("../../Index.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"] != null && Request.QueryString["Mode"].ToString() != "")
                {
                    string Mode = Request.QueryString["Mode"].ToString();
                    ViewState["Mode"] = Mode;
                    if (Mode == "CFE")
                    {
                        dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                        if (dscheck.Tables[0].Rows.Count > 0)
                        {
                            Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                            string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                            if (TourismFlag == "Y")
                            {
                                btntab1next_Click(sender, e);
                            }
                            else
                            {
                                Button1_Click(sender, e);

                            }
                        }
                    }
                    else if (Mode == "CFO")
                    {
                        dscheck = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                        if (dscheck.Tables[0].Rows.Count > 0)
                        {
                            Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                            string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                            if (TourismFlag == "Y")
                            {
                                btntab1next_Click(sender, e);//tab1  means hotel
                            }
                            else
                            {
                                Button1_Click(sender, e);//Button1  means Indus

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btntab1next_Click(object sender, EventArgs e)
    {
        Session["HOTEL"] = "Y";
        if (ViewState["Mode"] != null && ViewState["Mode"].ToString() != "")
        {
            if (ViewState["Mode"].ToString() == "CFE")
            {
                Session["HOTEL"] = "Y";
                Response.Redirect("frmQuesstionniareRegHotel.aspx?HOTEL=Y");
              
            }
            else
            {
                Session["HOTEL"] = "Y";
                Response.Redirect("frmQuesstionniareRegCFOHotel.aspx?HOTEL=Y"); 
            }
        }
       
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["Mode"] != null && ViewState["Mode"].ToString() != "")
        {
            if (ViewState["Mode"].ToString() == "CFE")
            {
                Response.Redirect("frmQuesstionniareReg.aspx?HOTEL=N");
            }
            else
            {
                Response.Redirect("frmQuesstionniareRegCFO.aspx?HOTEL=N");
            }
        }

    }
}