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
using System.Xml.Linq;
using System.Web.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Text;

public partial class Default3 : System.Web.UI.Page
{

    int statewellappl, staterigsappl;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../IpassLogin.aspx");
        }

        if (!IsPostBack)
        {
            
            if (Session["Role_Code"].ToString() == "DGWO")
            {
                //Ground water Dept
                btn_gwdept_groundwater.Visible = true;
                btn_drillingsrigs.Visible = true;
            }
            else
            {
               // btn_gwdept_groundwater.Visible = false;
                btn_drillingsrigs.Visible = false;
                if (Session["Role_Code"].ToString() == "GWTRANSCO")
                {
                    //Ground water Dept-Transco
                    btn_gwdept_groundwater.Visible = true;
                }
                else
                {
                    btn_gwdept_groundwater.Visible = false;
                }
            }

            if (Session["Role_Code"].ToString() == "MRO")
            {
                //MRO
                btn_mrogroundwater.Visible = true;

            }
            else
            {
                btn_mrogroundwater.Visible = false;
            }

            if (Session["user_id"].ToString().Contains("MRO-"))
            {
                Button1.Visible = false;
                Button2.Visible = false;
                btnIncentive.Visible = false;
                btnAmendments.Visible = false;
            }
            // added on 17.10.2017  for NewIncentives dashboard link showing
            if (  //(Session["Role_Code"].ToString() == "ADDL") || (Session["Role_Code"].ToString() == "JD") || 
                Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
            {
                trnewinc.Visible = true;
                tdTTAP.Visible = true;
                trgm.Visible = false;/// kept false on 14/06/2021
            }
            else
            {
                tdTTAP.Visible = false;
                trnewinc.Visible = false;
                trgm.Visible = false;
            }
            if ( Session["Role_Code"].ToString() == "GM")
            {
                btnUSERIDPSW.Visible = true;
            }

            if (Session["user_id"].ToString() == "IIPC_COI")
            {
                Response.Redirect("IIPC_COIDASHBOARD.aspx");


            }
            if (Session["User_Code"].ToString() == "1" || Session["User_Code"].ToString() == "9" || Session["User_Code"].ToString() == "3" ||
                Session["User_Code"].ToString() == "6" || Session["User_Code"].ToString() == "19" || Session["User_Code"].ToString() == "18" || 
                Session["User_Code"].ToString() == "56" || Session["User_Code"].ToString() == "14" || Session["User_Code"].ToString() == "7" ||
                Session["User_Code"].ToString() == "8" || Session["User_Code"].ToString() == "268" || Session["User_Code"].ToString() == "267"
                || Session["User_Code"].ToString() == "11" || Session["User_Code"].ToString() == "403" || Session["User_Code"].ToString() == "4"
                || Session["User_Code"].ToString() == "20"|| Session["User_Code"].ToString() == "73")
            {
                btnfirm.Visible = true;
                btnSociety.Visible = true;
                BtnDelete.Visible = true;
                if( Session["User_Code"].ToString() == "20" || Session["User_Code"].ToString() == "73")
                {
                    btnfirm.Visible = false;
                    btnSociety.Visible = false;
                }

            }
            else
            {
                btnfirm.Visible = false;
                btnSociety.Visible = false;
                BtnDelete.Visible = false;

            }

            if (Session["user_id"].ToString() == "TSIIC")
            {
                btnMSME.Visible = true;
                btnfialedattachments.Visible = true;
            }
            else
            {
                btnMSME.Visible = false;
                btnfialedattachments.Visible = false;
            }

            //if (Session["uid"].ToString() == "1134" || Session["uid"].ToString() == "1135" || Session["uid"].ToString() == "1136" || Session["uid"].ToString() == "1137" || Session["uid"].ToString() == "1138"
            //        || Session["uid"].ToString() == "1139" || Session["uid"].ToString() == "1140" || Session["uid"].ToString() == "1141" || Session["uid"].ToString() == "1142" || Session["uid"].ToString() == "1143")
            //{
            //    BtnDelete0.Visible = true;

            //}
            //else
            //{
            //    BtnDelete0.Visible = false;
            //}

            if (Session["Role_Code"].ToString() == "GM")
            {
                BtnDelete0.Visible = true;

            }
            else
            {
                BtnDelete0.Visible = false;
            }

            if (Session["User_Code"].ToString() == "1" || Session["User_Code"].ToString() == "9" || Session["User_Code"].ToString() == "56" || Session["User_Code"].ToString() == "14" || Session["User_Code"].ToString() == "20")
            {
                Button3.Visible = true;
                if (Session["User_Code"].ToString() == "1")
                {
                    btnbattery.Visible = true;
                }
                else
                {

                }
            }

            if (Session["User_Code"].ToString() == "151")
            {
                BtnSave1.Visible = true;
                BtnDelete.Visible = true;
                Button1.Visible = false;
                Button2.Visible = false;
                BtnDelete0.Visible = false;
                btnIncentive.Visible = false;
                //btnincentivenew.Visible = false;
                Button3.Visible = false;
            }

            if (Session["User_Code"].ToString() == "407" || Session["User_Code"].ToString() == "411" || Session["User_Code"].ToString() == "427" || Session["User_Code"].ToString() == "412")
            {
                BtnDelete.Visible = true;
                btn_tourismEvent.Visible = true;
            }


            if (Convert.ToInt32(Session["uid"].ToString()) >= 1021 && Convert.ToInt32(Session["uid"].ToString()) <= 1055)
            {
                btnIncentive.Visible = false;
                // btnincentivenew.Visible = false;
            }

            if (Session["User_Code"].ToString() == "422" || Session["User_Code"].ToString() == "14")
            {
                btn_tourismEvent.Visible = true;
                btn_tourismagent.Visible = true;
            }
            //else
            //{
            //    btn_tourismEvent.Visible = false;
            //    btn_tourismagent.Visible = false;
            //}



            if (Convert.ToInt32(Session["uid"].ToString()) == 2181 || Convert.ToInt32(Session["uid"].ToString()) == 7709 || Convert.ToInt32(Session["uid"].ToString()) == 9073)
            {
                btnIncentive.Visible = false;
                // btnincentivenew.Visible = false;
            }

            if (Session["DummyLogin"].ToString() == "Y")
            {
                Tr1.Visible = true;
                maintr.Visible = false;
            }
            else
            {
                Tr1.Visible = false;
                maintr.Visible = true;
            }

            if (Session["Role_Code"].ToString() == "GWCOMM")
            {
                if (Session["user_id"].ToString().Trim().ToLower() == "gw_commissioner" || Session["user_id"].ToString().Trim().ToLower() == "gw_director")
                {
                    Bindgrids();
                    BtnSave1.Visible = false;
                    BtnDelete.Visible = false;
                    Button1.Visible = false;
                    Button2.Visible = false;
                    btnIncentive.Visible = false;
                    btnAmendments.Visible = false;

                }
            }
            if (Session["userlevel"].ToString().Trim() == "10" && Session["User_Code"].ToString().Trim() == "424" && Session["Role_Code"].ToString().Trim() == "ADMG")
            {
                //To View ADMG Dashboard
                tradmg.Visible = true;
                trPattaDashboard.Visible = true;
                BtnSave1.Visible = false;
                BtnDelete.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                BtnDelete0.Visible = false;
                btnIncentive.Visible = false;
                trnewinc.Visible = false;
                Button3.Visible = false;
                btnAmendments.Visible = false;
                btnbattery.Visible = false;
            }
            if (Session["userlevel"].ToString().Trim() == "10" && Session["Role_Code"].ToString().Trim() == "MRO")
            {
                tradmgtahsldar.Visible = true;//MRO Login
                tradmg.Visible = false;
                BtnSave1.Visible = true;
                BtnDelete.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                BtnDelete0.Visible = false;
                btnIncentive.Visible = false;
                trnewinc.Visible = false;
                Button3.Visible = false;
                btnAmendments.Visible = false;
                btnbattery.Visible = false;
            }
            //if (Session["User_Code"].ToString() == "1")
            //{
            //    trbattery.Visible = true;
            //}
            //else
            //{
            //    trbattery.Visible = false;
            //}
            if (Session["User_Code"].ToString() == "406")
            {
                trPLOT.Visible = true;
                btnplot.Visible = true;
                tradmgtahsldar.Visible = false;//MRO Login
                tradmg.Visible = false;
                BtnSave1.Visible = false;
                BtnDelete.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                BtnDelete0.Visible = false;
                btnIncentive.Visible = false;
                trnewinc.Visible = false;
                Button3.Visible = false;
                btnAmendments.Visible = false;
                btnbattery.Visible = false;
            }
            else
            {
                trPLOT.Visible = false;
                btnplot.Visible = false;
            }
            if (Session["Role_Code"].ToString() == "DIST_GW")
            {
                //MRO
                Button2.Visible = false;
                btnIncentive.Visible = false;
                btnusereodb.Visible = false;
                Button1.Visible = false;
                Label437.Visible = false;
            }

        }


    }



    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //if (Session["uid"].ToString() == "1134" || Session["uid"].ToString() == "1135" || Session["uid"].ToString() == "1136" || Session["uid"].ToString() == "1137" || Session["uid"].ToString() == "1138"
        //        || Session["uid"].ToString() == "1139" || Session["uid"].ToString() == "1140" || Session["uid"].ToString() == "1141" || Session["uid"].ToString() == "1142" || Session["uid"].ToString() == "1143")
        //{

        //    Response.Redirect("CollectorDistrictWiseReportDIC.aspx");

        //}
        //else
        //{
        if (Session["User_code"].ToString() == "11")
        {
            Response.Redirect("frmDepartementDashboardNewHmda.aspx");
        }
        else if (Session["User_code"].ToString() == "3" || Session["User_code"].ToString() == "1023" || Session["User_code"].ToString() == "61")
        {
            Response.Redirect("frmDepartementDashboardNewTSIICFCDA.aspx");
        }
        //else if (Session["User_code"].ToString() == "142")
        //{
        //    Response.Redirect("frmDepartementDashboardNewKUDA.aspx");

        //}
        else
        {
            Response.Redirect("frmDepartementDashboardNew.aspx");
        }
        //}

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmDepartementDashboardNewCFO.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("GreivanceDashboard.aspx");

        if (Session["userlevel"].ToString() == "13" || Session["userlevel"].ToString() == "10")
        {
            Response.Redirect("DashboardNewGriv.aspx");
        }
        else
        {
            Response.Redirect("GreivanceDashboard.aspx");
        }


    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("RawMaterialsReport.aspx");

    }
    protected void btnIncentive_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10")
        {
            if (Session["Role_Code"] =="AD" || (Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))
            {
                Response.Redirect("frmIPOIncentiveDashboard.aspx");
            }
            else
            {
                Response.Redirect("frmDepartementIncentiveDashboard.aspx");
            }
        }
        else
        {
            Response.Redirect("HomeDeptDashboard.aspx");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmDepartementDashboardNewRenuwalsnew.aspx");
        Response.Redirect("frmDepartementDashboardNewREN.aspx");
    }
    protected void btnAmendments_Click(object sender, EventArgs e)
    {
        Response.Redirect("Ammendments.aspx");

    }

    protected void btn_tourismEvent_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourismEventDashboard.aspx");
    }

    protected void btn_tourismagent_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourismagentAdminDashboard.aspx");
    }
    protected void btnMSME_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmMSMEReport.aspx");
    }
    protected void btnincentivenew_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10")
        {
            if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
            {
                Response.Redirect("frmIPOIncentiveDashboardNew.aspx");
            }
            else
            {
                if (Session["User_Code"].ToString() == "1102030408")
                {
                    Response.Redirect("frmNewIPODashboard.aspx");
                }
                else if (Session["User_Code"].ToString() == "1102030415")
                {
                    Response.Redirect("frmSupDashboard.aspx");
                }
                else if (Session["User_Code"].ToString() == "1102030420")
                {
                    Response.Redirect("frmADDashboard.aspx");
                }
                else
                {
                    Response.Redirect("frmDepartementIncentiveDashboardNew1.aspx");
                }
            }


        }
        else
        {
            Response.Redirect("HomeDeptDashboard.aspx");
        }
    }

    protected void btn_drillingsrigs_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmDepartementDashboardNew_DrillingRigs.aspx");
    }

    protected void btn_gwdept_groundwater_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmDepartementDashboardNew_GW.aspx");
        if (Session["Role_Code"].ToString() == "DGWO")
        {
            //Ground water Dept -District Ground water officer
            Response.Redirect("frmDepartementDashboardNew_GW.aspx");
        }
        if (Session["Role_Code"].ToString() == "GWTRANSCO")
        {
            //Ground water Dept-Transco District Ground water
            //Response.Redirect("frmDepartementDashboardNewGW_Transco.aspx");
            Response.Redirect("frmDepartementDashboardNewGW_Transco.aspx");
        }
    }

    protected void btn_mrogroundwater_Click(object sender, EventArgs e)
    {
        Response.Redirect("MRO_GroundwaterDashboard.aspx");
    }


    public void Bindgrids()
    {
        tr_gwcomdas.Visible = false;
        Cls_OSGroundWater obj_insert = new Cls_OSGroundWater();
        //string FromdateforDB = null, TodateforDB = null, DistrictID = null;
        string FromdateforDB = "%", TodateforDB = "%", DistrictID = "%";
        try
        {
            DataSet dsd = obj_insert.Getstatereport_groundwater(FromdateforDB, TodateforDB, DistrictID);
            if (dsd != null && dsd.Tables.Count > 0)
            {
                grdDetails_state.DataSource = dsd.Tables[0];
                grdDetails_state.DataBind();
                tr_gwcomdas.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetails_state_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails_state.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 2 || i == 3)
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
            tcMergePackage.Text = "Applications";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

        }
    }

    protected void grdDetails_state_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int statewellappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GroundwaterAppl"));
            statewellappl = statewellappl1 + statewellappl;
            int staterigsappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DrillingAppl"));
            staterigsappl = staterigsappl1 + staterigsappl;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = statewellappl.ToString();
            e.Row.Cells[3].Text = staterigsappl.ToString();
        }
    }


    protected void btnUSERIDPSW_Click(object sender, EventArgs e)
    {
        Response.Redirect("usersearchslcdlc.aspx");
    }

    protected void btnbattery_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmbatterydealerdashboard.aspx");
    }
    protected void btnadmg_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10" && Session["User_Code"].ToString().Trim() == "424" && Session["Role_Code"].ToString().Trim() == "ADMG")
        {

            Response.Redirect("frmDepartmentDashboardADMG.aspx");//ADMG-District Level Application view
        }
    }

    protected void BtnGovtLands_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10" && Session["User_Code"].ToString().Trim() == "424" && Session["Role_Code"].ToString().Trim() == "ADMG")
        {

            Response.Redirect("FormApplicationADMandG.aspx");//ADMG-Application to be filled
        }

    }

    protected void PattadarDashbrd_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10" && Session["User_Code"].ToString().Trim() == "424" && Session["Role_Code"].ToString().Trim() == "ADMG")
        {

            Response.Redirect("frmPattadarDashboard.aspx"); //ADMG -District level Pattadar apllication view
        }
    }
    protected void Btnadmgapll_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10" && Session["Role_Code"].ToString().Trim() == "MRO")
        {

            Response.Redirect("frmADMGapplDashboard.aspx"); //ADMG -Mandal level apllication view
        }

    }



    protected void BtnPattadar_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString().Trim() == "10" && Session["Role_Code"].ToString().Trim() == "MRO")
        {

            Response.Redirect("frmPattadarApplDashboard.aspx"); //Pattadra Appl -MRO view
        }

    }



    protected void btnplot_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPlotAbstractDetails.aspx"); //Pattadra Appl -MRO view
    }

    protected void btnusereodb_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEODBUserData.aspx"); //Pattadra Appl -MRO view
    }
    protected void lnkCommenced_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Role_Code"]) == "GM")
            Response.Redirect("CommencedUnitsStatus.aspx");

    }
    protected void btnfialedattachments_Click(object sender, EventArgs e)
    {
        Response.Redirect("Departmentserviceattachment.aspx"); //Pattadra Appl -MRO view
    }
    protected void btnfirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmFirmRegistrationDetails.aspx"); //frmFirmRegistrationDetails
    }
    protected void btnSociety_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmSocietyRegistrationDetails.aspx"); //frmSocietyRegistrationDetails
    }
    protected void btnViewTTAP_Click(object sender, EventArgs e)
    {

        string UserId = Session["user_id"].ToString();
        string Password = Session["password"].ToString();
        string Flag = Session["PwdEncryflag"].ToString();
        string CreateBy = Session["uid"].ToString();
        string Role = Session["Role_Code"].ToString();
        string User_level = Session["userlevel"].ToString();
        string Fromname = Session["Type"].ToString();
        string DistrictID = Session["DistrictID"].ToString();
        string User_type = Session["user_type"].ToString();

        Response.Redirect("http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserId + "&UserCode=" + Password + "&Flg=Y&CreateBy=" +
                                CreateBy + "&Role=" + Role + "&User_level=" + User_level + "&Fromname=" + Fromname + "&DistrictID=" + DistrictID + "&User_type=" + User_type);
    }

}
