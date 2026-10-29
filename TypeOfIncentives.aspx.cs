using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;

//Developed By: Bala Prathap Reddy .P
//List of Tables Used :
/*
    * tbl_IncentiveTypeMaster
    * tm_Incentive
    * tblInceniveTransaction
    * tbl_Incentive
*/

//List of Procedures Used
/*
    * FetchIncentiveTypes
    * FetchIncentives
    * InsincentiveDtl
    * FetchIncentivesbyID
*/

// List of Views Used
/*
    * vwtblIncentiveMapping
    * VwtblInceniveTransaction
*/

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    comFunctions objCmf = new comFunctions();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx", false);
                return;
            }
            success.Visible = Failure.Visible = false;            
            if (!IsPostBack)
            {                
                btnNext.Visible = true;
                int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());

                //trVehIncentive.Visible = false;
                //if (Convert.ToBoolean(Session["Incentive_PHC"].ToString()) || caste == 3 || caste == 4) trVehIncentive.Visible = true;

                //if (Session["Incentive_NewOrExisting"] != null && Session["Incentive_NewOrExisting"].ToString() != "0") rblSelection.SelectedValue = Session["Incentive_NewOrExisting"].ToString();

                rblSelection.SelectedValue = "1";
                rblSelection.Visible = false;
                
                if (Session["Incentive_isVehicle"] != null && Convert.ToBoolean(Session["Incentive_isVehicle"])) rblVehicleIncetive.SelectedValue = "1";

                BindIncentives();
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    //private void Incentiveslist(bool IsNewEnterp)
    //{
    //    try 
    //    {
    //        int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
    //        int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());

    //        DataTable dt = new DataTable();
    //        DataTable dtIncentiveType = new DataTable();
    //        dtIncentiveType = objFetch.FetchIncentiveTypes();

    //        //trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = trTpride.Visible = false;
    //        //gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = gvTpride.DataSource = null;

    //        trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false;
    //        gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = null;

    //        gvRepetitive.DataBind();
    //        gvSingleTerm.DataBind();
    //        gvskillSet.DataBind();
    //        //gvTpride.DataBind();

    //        if (dtIncentiveType != null)
    //        {
    //            for (int i = 0; i < dtIncentiveType.Rows.Count; i++)
    //            {                    
    //                dt = objFetch.FetchIncentivesyCasterSector(caste, sector, i + 1,Convert.ToInt32(Session["EntprIncentive"].ToString()));
    //                switch (i + 1)
    //                {
    //                    case 1:
    //                        if (dt.Rows.Count > 0)
    //                        {
    //                            //trTpride.Visible = true;
    //                            //objCmf.FillGrid(dt, gvTpride, false);
    //                        }
    //                        break;
    //                    case 2:
    //                        if (dt.Rows.Count > 0 && IsNewEnterp)
    //                        {
    //                            trOnetime.Visible = true;
    //                            objCmf.FillGrid(dt, gvSingleTerm, false);
    //                        }
    //                        break;
    //                    case 3:
    //                        if (dt.Rows.Count > 0)
    //                        {
    //                            trRegularIncentive.Visible = true;
    //                            objCmf.FillGrid(dt, gvRepetitive, false);
    //                        }
    //                        break;
    //                    case 4:
    //                        if (dt.Rows.Count > 0)
    //                        {
    //                            trSkillset.Visible = true;
    //                            objCmf.FillGrid(dt, gvskillSet, false);
    //                        }
    //                        break;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex) { Errors.ErrorLog(ex); }
    //}

    private DataTable dtYear()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Year");
        dt.Rows.Add(1,"April-2015");
        dt.Rows.Add(2,"October-2015");
        //for (int yr = (DateTime.Now.Year - 1); yr <= (DateTime.Now.Year); yr++) dt.Rows.Add(yr);
        return dt;
    }

    private DataTable dtYear1()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Year");
        dt.Rows.Add(1,"September-2015");
        dt.Rows.Add(2,"March-2016");
        //for (int yr = (DateTime.Now.Year - 1); yr <= (DateTime.Now.Year); yr++) dt.Rows.Add(yr);
        return dt;
    }

    protected void gvRepetitive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DropDownList ddlfrom=(e.Row.FindControl("ddlPassingYearFrom") as DropDownList);
                //DropDownList ddlto = (e.Row.FindControl("ddlPassingYearTo") as DropDownList);
                //objCmf.BindCtlto(true,ddlfrom , dtYear(), 1, 0, false);
                //objCmf.BindCtlto(true, ddlto, dtYear1(), 1, 0, false);

                TextBox txtFrom = (e.Row.FindControl("txtFrom") as TextBox);
                TextBox txtTo = (e.Row.FindControl("txtTo") as TextBox);

                Label lbl = (e.Row.FindControl("lblDropdown") as Label);
                if (lbl.Text.Trim() == "" || lbl.Text.Trim() == "0"|| lbl.Text.ToLower()=="01-jan-1900") txtFrom.Text = ""; else txtFrom.Text = Convert.ToDateTime(lbl.Text).ToString("dd-MMM-yyyy");
                if (lbl.ToolTip.Trim() == "" || lbl.ToolTip.Trim() == "0" || lbl.ToolTip.ToLower() == "01-jan-1900") txtTo.Text = ""; else txtTo.Text = Convert.ToDateTime(lbl.ToolTip).ToString("dd-MMM-yyyy");
                
                lbl = (e.Row.FindControl("lbl") as Label);
                //RadioButtonList rbl = (e.Row.FindControl("rblYesNo") as RadioButtonList);
                //if (lbl.Text.Trim() == "" || lbl.Text.Trim() == "0") rbl.SelectedIndex = -1; else rbl.SelectedValue = lbl.Text.Trim();

                (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = (lbl.ToolTip.Trim() == "" || lbl.ToolTip.Trim() == "0" ? false : true);

                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim() == "3")
                {

                   DataSet dsA=objFetch.FetchIncentivesApplied(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim(),Convert.ToString(Session["EntprIncentive"].ToString()));
                   
                    if(dsA.Tables[0].Rows.Count>0)
                    {
                    
                   
                    (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = false;
                    }
                    else
                    {
                         (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = true;
                    (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = false;
                    }
                }
                else 
                { (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = false;
                (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = true;
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try { save(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    { 
        try { if (save()) Response.Redirect(btnNext.PostBackUrl, false); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    private bool save()
    {
        try
        {
            lblmsg0.Text = "";
            success.Visible = Failure.Visible = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("IncentiveId");
            dt.Columns.Add("AlreadyApplied");
            dt.Columns.Add("FromYear");
            dt.Columns.Add("ToYear");

            DataTable dtIncentiveTypes = new DataTable();
            dtIncentiveTypes.Columns.Add("IncentiveType", typeof(int));

            DateTime dcp = Convert.ToDateTime(Session["Incentive_DateOfCommencement"].ToString());

            foreach (GridViewRow gr in gvRepetitive.Rows) gr.BackColor = System.Drawing.Color.FromName((gr.RowIndex % 2 == 0 ? "#EFF3FB" : "#FFFFFF"));

            bool valid = true;
            foreach (GridViewRow gr in gvRepetitive.Rows)
            {
                if ((gr.FindControl("cbIncentiveCheck") as CheckBox).Checked == true)
                {
                    //DropDownList ddlfrm = (gr.FindControl("ddlPassingYearFrom") as DropDownList);
                    //DropDownList ddlto = (gr.FindControl("ddlPassingYearTo") as DropDownList);
                    TextBox txtFrom = (gr.FindControl("txtFrom") as TextBox);
                    TextBox txtTo = (gr.FindControl("txtTo") as TextBox);

                    DateTime dtfrom, dtto;
                    
                    if ((txtFrom == null || txtTo == null))
                    {
                        break;
                    }
                    else 
                    {
                        if (txtFrom.Text == "" )
                        {
                            valid = false;
                            Failure.Visible = true;
                            gr.BackColor = System.Drawing.Color.Pink;
                            lblmsg0.Text = "Please select From Date";
                            txtFrom.Focus();
                            return false;
                        }

                        if (txtTo.Text == "")
                        {
                            Failure.Visible = true;
                            valid = false;
                            gr.BackColor = System.Drawing.Color.Pink;
                            lblmsg0.Text = "Please select To Date";
                            txtTo.Focus();
                            return false;
                        }
                    }

                    try { dtfrom = Convert.ToDateTime(txtFrom.Text); }
                    catch (Exception)
                    {
                        Failure.Visible = true;
                        txtFrom.Focus();
                        lblmsg0.Text = "Please select Valid Date"; ;
                        break;
                    }

                    try { dtto = Convert.ToDateTime(txtTo.Text); }
                    catch (Exception) {
                        Failure.Visible = true;
                        txtTo.Focus();
                        lblmsg0.Text = "Please select Valid Date"; ;
                        break;
                    }

                    if (dtto < dtfrom)
                    {
                        Failure.Visible = true;
                        //txtTo.Focus();
                        lblmsg0.Text = "To Date cannot be Less than From date";
                        break;
                    }

                    //if (dtto < dcp)incentive change
                    //{
                    //    Failure.Visible = true;
                    //    //txtTo.Focus();
                    //    lblmsg0.Text = "To Date cannot be Less than Date of Commencement of production Date (" + dcp.ToString("dd-MMM-yyyy") + ")";
                    //    break;
                    //}

                    //if (dtfrom < dcp) {incentive change
                    //    Failure.Visible = true;
                    //    txtFrom.Focus();
                    //    lblmsg0.Text = "From date cannot be Less than Date of Commencement of production Date (" + dcp.ToString("dd-MMM-yyyy") + ")" ;
                    //    break;
                    //}

                    if (dtto > dcp.AddYears(9))
                    {
                        Failure.Visible = true;
                        txtTo.Focus();
                        lblmsg0.Text = "From date cannot be Greater than (" + dcp.AddYears(9).ToString("dd-MMM-yyyy") + ")";
                        break;
                    }

                    if (dtto.AddDays(1) < dtfrom.AddMonths(6))
                    {
                        Failure.Visible = true;
                        txtTo.Focus();
                        lblmsg0.Text = "To date should be Greater than (" +  dtfrom.AddMonths(6).ToString("dd-MMM-yyyy") + ")";
                        break;
                    }

                    dtIncentiveTypes.Rows.Add(3);
  
                    dt.Rows.Add(
                                (gr.FindControl("lblIncentiveId") as Label).Text,
                                "0",
                                Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd"),
                                Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd")
                                );
                }
            }
            if (valid)
            {
                foreach (GridViewRow gr in gvSingleTerm.Rows)
                {
                    if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true)
                    {
                        dt.Rows.Add((gr.FindControl("lblIncentiveId") as Label).Text, "", 0, 0);
                        dtIncentiveTypes.Rows.Add(2);
                    }
                }

                //foreach (GridViewRow gr in gvTpride.Rows)
                //{
                //    if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true)
                //    {
                //        dt.Rows.Add((gr.FindControl("lblIncentiveId") as Label).Text, "", 0, 0);
                //        dtIncentiveTypes.Rows.Add(1);
                //    }
                //}

                foreach (GridViewRow gr in gvskillSet.Rows)
                {
                    if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true)
                    {
                        dt.Rows.Add((gr.FindControl("lblIncentiveId") as Label).Text, "", 0, 0);
                        dtIncentiveTypes.Rows.Add(4);
                    }
                }
            }
            else { dt = null; dtIncentiveTypes = null; }

            string msg = "";
            if (dt!=null && dt.Rows.Count > 0 && rblSelection.SelectedIndex>-1)
            {
                //msg = objDml.InsincentiveDtl(Convert.ToInt32(Session["EntprIncentive"]),
                //                            Convert.ToInt32(rblSelection.SelectedValue),
                //                           Convert.ToInt32(Session["uid"]),
                //                           dt);
                msg = objDml.InsincentiveDtl(Convert.ToInt32(Session["EntprIncentive"]),
                                           Convert.ToInt32(rblSelection.SelectedValue),
                                           Convert.ToBoolean(rblVehicleIncetive.SelectedValue == "0" ? false : true),
                                          Convert.ToInt32(Session["uid"]),
                                          dt);

                var UniqueRows = dtIncentiveTypes.AsEnumerable().Distinct(DataRowComparer.Default);
                Session["dtIncentiveTypes"] = dtIncentiveTypes = UniqueRows.AsEnumerable().OrderBy(r => r.Field<int>("IncentiveType")).CopyToDataTable();

                btnNext.Visible = true;
                btnNext.PostBackUrl = "~/IncentiveSingleUploads.aspx?q=" + dtIncentiveTypes.Rows[0]["IncentiveType"].ToString();
                success.Visible = true;
                lblmsg.Text = " Incentives applied successfully, Please click Next for Uploading Documents.";
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please select Incentive type (if applicable please select valid Dates).";
                btnNext.Visible = false;
            }
            return btnNext.Visible;
        }
        catch (Exception ex) { Errors.ErrorLog(ex); return false; }
    }

    protected void rblSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { BindIncentives(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    private void BindIncentives()
    {
        try
        {
            if (rblVehicleIncetive.SelectedIndex > -1 && rblSelection.SelectedIndex > -1)
            {
                int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
                int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());

                DataTable dt = new DataTable();
                DataTable dtIncentiveType = new DataTable();
                dtIncentiveType = objFetch.FetchIncentiveTypes();

                //trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = trTpride.Visible = false;
                //gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = gvTpride.DataSource = null;

                trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false;
                gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = null;

                gvRepetitive.DataBind();
                gvSingleTerm.DataBind();
                gvskillSet.DataBind();
                //gvTpride.DataBind();

                if (dtIncentiveType != null)
                {
                    trNoIncentives.Visible = false;
                    for (int i = 0; i < dtIncentiveType.Rows.Count; i++)
                    {
                        //dt = objFetch.FetchIncentivesyCasterSector(caste, sector, i + 1, Convert.ToInt32(Session["EntprIncentive"].ToString()));
                        //dt = objFetch.FetchIncentives(caste, sector,true,Convert.ToBoolean(rblSelection.SelectedValue),1,false,false, i + 1, Convert.ToInt32(Session["EntprIncentive"].ToString()));

                        dt = objFetch.FetchIncentives(caste,
                                                        sector,
                                                        Convert.ToBoolean(Session["Incentive_GHMC"]),
                                                        Convert.ToInt32(rblSelection.SelectedValue),
                                                        Convert.ToInt32(Session["Incentive_Category"]),
                                                        Convert.ToBoolean (Session["Incentive_PHC"]),
                                                        Convert.ToBoolean(Session["Incentive_isVehicle"]),
                                                        i + 1,
                                                        Convert.ToInt32(Session["EntprIncentive"].ToString())
                                                    );
                        switch (i + 1)
                        {
                            case 1:
                                if (dt.Rows.Count > 0)
                                {
                                    //trTpride.Visible = true;
                                    //objCmf.FillGrid(dt, gvTpride, false);
                                }
                                break;
                            case 2:
                                if (dt.Rows.Count > 0)
                                {
                                    trOnetime.Visible = true;
                                    objCmf.FillGrid(dt, gvSingleTerm, false);
                                }
                                break;
                            case 3:
                                if (dt.Rows.Count > 0)
                                {
                                    trRegularIncentive.Visible = true;
                                    objCmf.FillGrid(dt, gvRepetitive, false);
                                }
                                break;
                            case 4:
                                if (dt.Rows.Count > 0)
                                {
                                    trSkillset.Visible = true;
                                    objCmf.FillGrid(dt, gvskillSet, false);
                                }
                                break;
                        }
                    }
                    if (!(trOnetime.Visible || trRegularIncentive.Visible || trSkillset.Visible)) trNoIncentives.Visible = true;
                }
            }
            else { trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false; }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void rblVehicleIncetive_SelectedIndexChanged(object sender, EventArgs e) 
    {
        try { BindIncentives(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void cbIncentive_CheckedChanged(object sender, EventArgs e)
    { 
        try
        {
            GridViewRow gr = (((CheckBox)sender).Parent.Parent as GridViewRow);
            Label lbl = (gr.FindControl("lblIncentiveId") as Label);
            CheckBox cb = (gr.FindControl("cbIncentive") as CheckBox); ;
            if (Convert.ToInt32(lbl.Text) == 2 && cb.Checked)
            {
                trOnetime.Visible = true;
                objCmf.FillGrid(objFetch.FetchIncentivesbyID(6), gvSingleTerm, false);

                trRegularIncentive.Visible = true;
                objCmf.FillGrid(objFetch.FetchIncentivesbyID(1), gvRepetitive, false);
            }
            else
            { rblSelection_SelectedIndexChanged(sender, e); }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
    
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((TextBox)sender).Parent.Parent as GridViewRow);
            TextBox txtFrom = (gr.FindControl("txtFrom") as TextBox);
            try
            {
                Failure.Visible = false;
                DateTime dtFrom = Convert.ToDateTime(txtFrom.Text);
                DateTime dt = Convert.ToDateTime(Session["Incentive_DateOfCommencement"].ToString());
                if (dtFrom > dt.AddYears(9)) //if (dtFrom < dt || dtFrom > dt.AddYears(9)) incentive change
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please select Date between " + dt.ToString("dd-MMM-yyyy") + " and " + dt.AddYears(9).ToString("dd-MMM-yyyy");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select Date between '" + dt.ToString("dd-MMM-yyyy") + " and " + dt.AddYears(9).ToString("dd-MMM-yyyy") + "');", true);
                }
            }
            catch (Exception)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select valid Date (dd-MMM-yyyy).');", true);
                Failure.Visible = true;
                lblmsg0.Text = "Please select valid Date (dd-MMM-yyyy)";
                txtFrom.Focus();
                return;
            }


        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((TextBox)sender).Parent.Parent as GridViewRow);
            TextBox txtTo = (gr.FindControl("txtTo") as TextBox);
            TextBox txtFrom = (gr.FindControl("txtFrom") as TextBox);
            DateTime dt = Convert.ToDateTime(Session["Incentive_DateOfCommencement"].ToString());
            txtFrom_TextChanged(sender, e);
            try
            {
                DateTime dtTo = Convert.ToDateTime(txtTo.Text);
                DateTime dtfrom = Convert.ToDateTime(txtFrom.Text);

                Failure.Visible = false;
                if (dtTo < dtfrom)
                {
                    Failure.Visible = true;
                    lblmsg0.Text="To Date cannot be less than " + dtfrom.AddMonths(6).ToString("dd-MMM-yyyy");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('To Date cannot be less than" + dtfrom.AddMonths(6).ToString("dd-MMM-yyyy") + "');", true);
                }
                else if (dtTo > dt.AddYears(9))
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "To Date cannot be greater than " + dtfrom.AddYears(9).ToString("dd-MMM-yyyy");
                }
            }
            catch (Exception)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select valid Date (dd-MMM-yyyy).');", true);
                Failure.Visible = true;
                lblmsg0.Text = "Please select valid Date (dd-MMM-yyyy)";
                txtTo.Focus();
                return;
            }            
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
}