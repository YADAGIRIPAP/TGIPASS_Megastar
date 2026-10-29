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
using System.Text;

public partial class CCMaster : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {


        // panelredressal.Visible = false;
        //  pnlmaster.Visible = false;
        // pnlreport.Visible = false;

        string section = "";

        if (Session.Count > 0)
        {

            lblwecome.Text =  Session["username"].ToString().ToUpper();
            //   PanelTransaction.Visible = false;
            //by latha on 21/08/2012
            if (Session["userlevel"].ToString() == "10" || Session["userlevel"].ToString() == "11" || Session["userlevel"].ToString() == "1")
            {
                //   pnlreg.Visible = true;
                // panelredressal.Visible = true;
                //Jyotshna On 05-09-2013
                // pnlreport.Visible = true;
                // piarpt.Visible = true;
                // trngrpt.Visible = false;
                //Jyotshna On 05-09-2013
            }
            else if (Session["user_type"].ToString() == "SDA" || Session["user_type"].ToString() == "Train")
            {
                // panelredressal.Visible = true;
                if (Session["user_type"].ToString() == "SDA")
                {
                    //pnlreport.Visible = true;
                    //piarpt.Visible = true;
                    //trngrpt.Visible = false;
                }
                else
                {
                    //pnlreport.Visible = true;
                    //piarpt.Visible = false;
                    //trngrpt.Visible = true;
                }

            }
            else if (Session["user_type"].ToString() == "ADM" || Session["user_type"].ToString() == "BRLPS")
            {
                //pnlreport.Visible = true;
                //piarpt.Visible = true;
                //trngrpt.Visible = false;
            }
            //else if (Session["userlevel"].ToString() == "111")
            //{
            //    pnlmaster.Visible = true;
            //}
            //else
            //{
            //    pnlmaster.Visible = false;

            //}
            if (Session["user_id"].ToString() == "DSPO")
            {
                //   trdspo.Visible=true;
            }

            if (Session["userlevel"].ToString() == "12")
            {
                //  PanelTransaction.Visible = true;
                //  trMeesevareport.Visible = true;
            }
            else
            {
                //     PanelTransaction.Visible = false;
            }
            if (Session["userlevel"].ToString() == "13" || Session["userlevel"].ToString() == "14")
            {
                //    Panelrptstr.Visible = true;
            }
            else
            {
                //  Panelrptstr.Visible = false;
            }

            if (Session["userlevel"].ToString() == "1")
            {
                //     Panelrptstr.Visible = true;
            }


            //    trMeesevareport.Visible = true;
            //    trdspo.Visible = true;


            //  Panel1.Visible = false;
            //  Panelrptstr.Visible = false;
        }
    }



}
