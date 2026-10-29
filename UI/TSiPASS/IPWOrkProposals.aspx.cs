using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

public partial class CheckPOITD : System.Web.UI.Page
{

    //designing and developed by siva as on 27-02-2016

    //Purpose : To update workproposals Details
    //Tables used : tbl_WorkMaster,tr_MemsInvolved,tr_ProposedWorkAct
    //Stored procedures Used : InsertUpdWorkProposal,saveMemsInvolvedinWorksProposal,GetWorkProposalByid,sp_getCounties,sp_getPayams,getBomasbyID

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {


            //Gen.getAreaOfWork(ddlAreaofWork);

            Gen.getStates(ddlState);
            Gen.getIpDet(ddlIP);
            


            if (Session["user_type"].ToString() == "TST")
            {                
                lblheading.Text = "Work Approvals";
                lblSite2.Text = "Work Approvals";
                lblSitemap.Text = "TST";

            }
            else
            {
                lblheading.Text = "Work Proposals";                
                lblSitemap.Text = "IP";
                lblSite2.Text = "Work Proposals";

                ddlIP.SelectedValue = ddlIP.Items.FindByValue(Session["User_Code"].ToString()).Value;
                ddlIP.Enabled = false;
                Gen.getProjects(ddlProject, ddlIP.SelectedValue);
                
            }


            Gen.getCouncilMems(chkTst,"TST");
            Gen.getCouncilMems(ChkCA, "CA");
            Gen.getCouncilMems(ChkPDC, "PDC");
            Gen.getCouncilMems(ChkBDC, "BDC");

            //lblIP.Text = Session["username"].ToString();

           
            Session["dtMyTabledr"] = createtabledr();
            Session["tmpdrDataTable"] = ((DataTable)Session["dtMyTabledr"]);

            if (Request.QueryString.Count > 0)
            {
                if (Session["user_type"].ToString() == "TST")
                {
                    trTSTApproval.Visible = true;
                }
                else
                {
                    trTSTApproval.Visible = false;
                }

                trworkcode.Visible = true;
                Failure.Visible = false;
                success.Visible = false;
                FillDetails();
                if (Session["userlevel"].ToString() == "1")
                {
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                BtnSave1.Text = "Update";
            }
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0" ))
        {

            if (Session["user_type"].ToString() == "TST")
            {
                trTSTApproval.Visible = true;
            }
            else
            {
                trTSTApproval.Visible = false;
            }

            trworkcode.Visible = true;
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "1")
            {
                BtnDelete.Visible = true;
            }
            else
            {
                BtnDelete.Visible = false;
            }
            BtnSave1.Text = "Update";
        }
    }

    public void ResetFormControlDisableEnable(Control parent, bool s)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlDisableEnable(c, s);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Enabled = s;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        ((DropDownList)c).Enabled = s;

                        break;

                    case "System.Web.UI.WebControls.CheckBoxList":

                        ((CheckBoxList)c).Enabled = s;

                        break;




                }
            }
        }

        chkTst.Enabled = false;
        ChkCA.Enabled = false;
        ChkPDC.Enabled = false;
        ChkBDC.Enabled = false;

    }
    void FillDetails()
    {
        string ids = "";
        if (Request.QueryString.Count > 0)
        {
            ids = Request.QueryString[0].ToString();
        }
        else
        {
            ids = hdfID.Value;
        }

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.GetWorkProposalByid(ids.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {



            hdfTSTID.Value = ds.Tables[0].Rows[0]["intTST"].ToString();
            hdfTSTEmail.Value = ds.Tables[0].Rows[0]["TSTemail"].ToString();

            //txtQualification.Text = ds.Tables[0].Rows[0]["QualificationName"].ToString();
            //txtDecription.Text=ds.Tables[0].Rows[0]["QualificationDescription"].ToString();
            ddlIP.SelectedValue = ddlIP.Items.FindByValue(ds.Tables[0].Rows[0]["Ipid"].ToString()).Value;
            ddlIP.Enabled = false;
            Gen.getProjects(ddlProject, ddlIP.SelectedValue);
            ddlProject.SelectedValue = ds.Tables[0].Rows[0]["intprjid"].ToString();

            getworksbyPojects();

            if (ds.Tables[0].Rows[0]["status"].ToString() != "")
            ddlstatus.SelectedValue = ddlstatus.Items.FindByValue(ds.Tables[0].Rows[0]["status"].ToString()).Value;

            if (ddlstatus.SelectedValue == "InProgress" || ddlstatus.SelectedValue == "Closed")
            {
                BtnSave1.Enabled = false;
            }
            else
            {
                BtnSave1.Enabled = true;
            }


            if (ddlstatus.SelectedValue != "New Proposal")
            {
                ResetFormControlDisableEnable(this, false);

                //gvpractical0.Columns[1].Visible = false;
            }
            else
            {
                ResetFormControlDisableEnable(this, true);
                //gvpractical0.Columns[1].Visible = false;
            }

            if (ddlstatus.SelectedValue == "Approved")
            {
                Label426.Text = "Approved Date";
            }
            else if (ddlstatus.SelectedValue == "Rejected")
            {
                Label426.Text = "Rejected Date";
            }
            else
            {
                Label426.Text = "Date";
            }
            


            if (ds.Tables[0].Rows[0]["PDC_ApprvDate"].ToString()!="")
            txtPDCApprvDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PDC_ApprvDate"].ToString()).ToString("dd-MM-yyyy");
            if (ds.Tables[0].Rows[0]["StatusDate"].ToString() != "")
            txtApprRejDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StatusDate"].ToString()).ToString("dd-MM-yyyy");
            txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            if (ds.Tables[0].Rows[0]["TypeofMeeting"].ToString() != "")
                ddlMeeting.SelectedValue = ds.Tables[0].Rows[0]["TypeofMeeting"].ToString();

            getprojectDet();
            txtStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["MeetingDate"].ToString()).ToString("dd-MM-yyyy");
            if (ds.Tables[0].Rows[0]["intStateid"].ToString() != "")
            {
                ddlState.SelectedValue = ds.Tables[0].Rows[0]["intStateid"].ToString();
                getcounties();
            }
            if (ds.Tables[0].Rows[0]["intCountieid"].ToString() != "")
            {
                ddlCounties.SelectedValue = ds.Tables[0].Rows[0]["intCountieid"].ToString();
                getPayams();
            }
            if (ds.Tables[0].Rows[0]["intPayamid"].ToString() != "")
            {
                ddlPayam.SelectedValue = ds.Tables[0].Rows[0]["intPayamid"].ToString();
                getBomas();
            }
            if (ds.Tables[0].Rows[0]["intBomasid"].ToString() != "")
            ddlBoma.SelectedValue = ds.Tables[0].Rows[0]["intBomasid"].ToString();

            lblworkcode.Text = ds.Tables[0].Rows[0]["workcode"].ToString();
           
            if (ds.Tables[1].Rows.Count > 0)
            {
                DataTableReader rdp = new DataTableReader(ds.Tables[1]);
                IDataReader readerp = rdp;


                ((DataTable)Session["tmpdrDataTable"]).Clear();
                ((DataTable)Session["tmpdrDataTable"]).Load(readerp);
                gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                gvpractical0.DataBind();
                gvpractical0.Columns[0].Visible = true;                
                
            }
            else
            {
                gvpractical0.DataSource = null;
                gvpractical0.DataBind();
            }
            

            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (ListItem item in chkTst.Items)
                {
                    for (int n = 0; n < ds.Tables[2].Rows.Count; n++)
                    {
                        if (item.Value == ds.Tables[2].Rows[n]["intMemid"].ToString().Trim())
                        {
                            item.Selected = true;
                            //  CheckBoxList1.Visible = true;
                        }
                    }
                }
            }
            
            if (ds.Tables[3].Rows.Count > 0)
            {
                foreach (ListItem item in ChkCA.Items)
                {
                    for (int n = 0; n < ds.Tables[3].Rows.Count; n++)
                    {
                        if (item.Value == ds.Tables[3].Rows[n]["intMemid"].ToString().Trim())
                        {
                            item.Selected = true;
                            //  CheckBoxList1.Visible = true;
                        }
                    }
                }
            }
            
            if (ds.Tables[4].Rows.Count > 0)
            {
                foreach (ListItem item in ChkPDC.Items)
                {
                    for (int n = 0; n < ds.Tables[4].Rows.Count; n++)
                    {
                        if (item.Value == ds.Tables[4].Rows[n]["intMemid"].ToString().Trim())
                        {
                            item.Selected = true;
                            //  CheckBoxList1.Visible = true;
                        }
                    }
                }
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                foreach (ListItem item in ChkBDC.Items)
                {
                    for (int n = 0; n < ds.Tables[5].Rows.Count; n++)
                    {
                        if (item.Value == ds.Tables[5].Rows[n]["intMemid"].ToString().Trim())
                        {
                            item.Selected = true;
                            //  CheckBoxList1.Visible = true;
                        }
                    }
                }
            }

        }
    }    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(5000);

        string ids = "";
        if (Request.QueryString.Count > 0)
        {
            ids = Request.QueryString[0].ToString();
        }
        else
        {
            ids = hdfID.Value;
        }

        if (BtnSave1.Text == "Save")
        {
            int i = Gen.InsertUpdWorkProposal("0", "", Session["User_Code"].ToString(), ddlProject.SelectedValue, txtStartDate.Text, ddlState.SelectedValue, ddlCounties.SelectedValue, ddlPayam.SelectedValue, ddlBoma.SelectedValue, "New Proposal",txtApprRejDate.Text, txtPDCApprvDate.Text,txtRemarks.Text, Session["uid"].ToString(),ddlMeeting.SelectedValue);
            if (i != 999)
            {

                string appNo = "";
                appNo = DateTime.Now.Year.ToString() + "-" + "TSiPASS" + "-" + ddlProject.SelectedItem.Text +"-" + i.ToString();

                if (i >= 0)
                {
                    int y = Gen.UpdWorkCode(i.ToString(), appNo.ToString());
                }

                //siva as on 04-1-2016
                if (((DataTable)Session["tmpdrDataTable"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["tmpdrDataTable"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["tmpdrDataTable"]).Rows[m]["intWorkid"].ToString().Trim() == "0")
                        {
                            ((DataTable)Session["tmpdrDataTable"]).Rows[m]["intWorkid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertdrNewDetails(myDtNewRecdr);

                }

                #region Inserting of Members Involved
                //TST
                foreach (ListItem objItem in chkTst.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(Convert.ToString(i), objItem.Value, "TST", Session["uid"].ToString());
                    }
                }
                //CA
                foreach (ListItem objItem in ChkCA.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(Convert.ToString(i), objItem.Value, "CA", Session["uid"].ToString());
                    }
                }
                //PDC
                foreach (ListItem objItem in ChkPDC.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(Convert.ToString(i), objItem.Value, "PDC", Session["uid"].ToString());
                    }
                }
                
                //BDC
                foreach (ListItem objItem in ChkBDC.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(Convert.ToString(i), objItem.Value, "BDC", Session["uid"].ToString());
                    }
                }

                #endregion
               DataSet ds = Gen.GetWorkProposalByid(i.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {

                    hdfTSTID.Value = ds.Tables[0].Rows[0]["intTST"].ToString();
                    hdfTSTEmail.Value = ds.Tables[0].Rows[0]["TSTemail"].ToString();
                    hdfTSTName.Value = ds.Tables[0].Rows[0]["TstName"].ToString();
                    hdfWorkCode.Value = ds.Tables[0].Rows[0]["WorkCode"].ToString();
                }
                SendMailAnother(hdfTSTEmail.Value, hdfWorkCode.Value);

                lblmsg.Text = "Submited Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            int i = Gen.InsertUpdWorkProposal(ids.ToString(), lblworkcode.Text, Session["User_Code"].ToString(), ddlProject.SelectedValue, txtStartDate.Text, ddlState.SelectedValue, ddlCounties.SelectedValue, ddlPayam.SelectedValue, ddlBoma.SelectedValue, ddlstatus.SelectedValue, txtApprRejDate.Text, txtPDCApprvDate.Text, txtRemarks.Text, Session["uid"].ToString(),ddlMeeting.SelectedValue);
            if (i != 999)
            {

                if (((DataTable)Session["tmpdrDataTable"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["tmpdrDataTable"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["tmpdrDataTable"]).Rows[m]["intWorkid"].ToString().Trim() == "0")
                        {
                            ((DataTable)Session["tmpdrDataTable"]).Rows[m]["intWorkid"] = Convert.ToString(hdfID.Value);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertdrNewDetails(myDtNewRecdr);

                }
                DataSet  ds = Gen.GetWorkProposalByid(hdfID.Value.ToString());
                if (ds.Tables[2].Rows.Count > 1)
                {
                    delete = Gen.deleteMemInvolved(hdfID.Value.ToString(), "TST");
                }
                if (ds.Tables[3].Rows.Count > 1)
                {
                    delete = Gen.deleteMemInvolved(hdfID.Value.ToString(), "CA");
                }
                if (ds.Tables[4].Rows.Count > 1)
                {
                    delete = Gen.deleteMemInvolved(hdfID.Value.ToString(), "PDC");
                }
                if (ds.Tables[5].Rows.Count > 1)
                {
                    delete = Gen.deleteMemInvolved(hdfID.Value.ToString(), "BDC");
                }
                #region Inserting of Members Involved
                //TST
                foreach (ListItem objItem in chkTst.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(hdfID.Value, objItem.Value, "TST", Session["uid"].ToString());
                    }
                }
                //CA
                foreach (ListItem objItem in ChkCA.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(hdfID.Value, objItem.Value, "CA", Session["uid"].ToString());
                    }
                }
                //PDC
                foreach (ListItem objItem in ChkPDC.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(hdfID.Value, objItem.Value, "PDC", Session["uid"].ToString());
                    }
                }

                //BDC
                foreach (ListItem objItem in ChkBDC.Items)
                {
                    if (objItem.Selected)
                    {
                        Gen.saveMemsInvolvedinWorksProposal(hdfID.Value, objItem.Value, "BDC", Session["uid"].ToString());
                    }
                }

                #endregion

                DataSet dsIp = Gen.GetWorkProposalByid(hdfID.Value.ToString());

                if (dsIp.Tables[0].Rows.Count > 0)
                {

                    hdfTSTID.Value = dsIp.Tables[0].Rows[0]["intTST"].ToString();
                    hdfTSTEmail.Value = dsIp.Tables[0].Rows[0]["TSTemail"].ToString();
                    hdfTSTName.Value = dsIp.Tables[0].Rows[0]["TstName"].ToString();
                    hdfWorkCode.Value = dsIp.Tables[0].Rows[0]["WorkCode"].ToString();
                    hdfIPEmail.Value = dsIp.Tables[0].Rows[0]["IPemaill"].ToString();
                }
                if (ddlstatus.SelectedValue == "Approved")                
                {
                    SendMailAnotherApprv(hdfIPEmail.Value, hdfWorkCode.Value, ddlstatus.SelectedValue, hdfTSTName.Value);
                }

                lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
                //lblmsg.Text = "Added Successfully..!";
            }
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {

    }

    void clear()
    {
        trworkcode.Visible = false;
        trTSTApproval.Visible = false;

        txtRemarks.Text = "";
        txtPDCApprvDate.Text = "";
        txtApprRejDate.Text = "";
        ddlstatus.SelectedIndex = 0;

        Gen.getCouncilMems(chkTst, "TST");
        Gen.getCouncilMems(ChkCA, "CA");
        Gen.getCouncilMems(ChkPDC, "PDC");
        Gen.getCouncilMems(ChkBDC, "BDC");
        ddlProject.SelectedIndex = 0;

        lblworkcode.Text = "";
        lblTargetBenefeciaries.Text = "";
        lblCost.Text = "";


        BtnSave1.Text = "Save";
        ddlMeeting.SelectedIndex = 0;
        txtStartDate.Text = "";
        ddlState.SelectedIndex = 0;
        ddlCounties.Items.Clear();
        ddlCounties.Items.Insert(0, "--Select--");
        ddlCounties.SelectedIndex = 0;

        ddlPayam.Items.Clear();
        ddlPayam.Items.Insert(0, "--Select--");
        ddlPayam.SelectedIndex = 0;

        ddlBoma.Items.Clear();
        
        ddlBoma.Items.Insert(0, "--Select--");
        ddlBoma.SelectedIndex = 0;
        BtnDelete.Visible = false;

        ((DataTable)Session["tmpdrDataTable"]).Clear();
        gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
        gvpractical0.DataBind();
        
    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {

                ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                this.gvpractical0.DataBind();

                //TextBox1.Text = "";
                //txtDomainArea.Text = "";
                //TextBox3.Text = "";
                //TextBox4a.Text = "";


                

            }
            else
            {
                if (((DataTable)Session["tmpdrDataTable"]).Rows[e.RowIndex]["new"].ToString().Trim() == "")
                {
                    int i = Gen.DeleteWorkProposal(gvpractical0.DataKeys[e.RowIndex].Values["intWorkActivityId"].ToString());
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";
                                        
                }
                else
                {
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";
                    
                }

            }
        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {
        }
    }

    public string DisableTheButton(Control pge, Control btn, string vldGroup)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("if (typeof(Page_ClientValidate) == 'function') {");
        if (vldGroup.Trim() == "")
        {
            sb.Append("if (Page_ClientValidate() == false) { return false; }} ");

        }
        else
        {
            sb.Append("if (Page_ClientValidate('" + vldGroup + "') == false) { return false; }} ");

        }
        sb.Append("this.value = 'Please wait...';");
        sb.Append("this.disabled = true;");
        sb.Append(pge.Page.GetPostBackEventReference(btn));
        //sb.Append(pge.Page.GetPostBackEventReference(btn));
        sb.Append(";");
        return sb.ToString();
    }

    
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Update")
            {

                if (BtnSave2.Text.ToString().ToLower() == "update")
                {
                    int i = Gen.DeleteWorkProposal(gvpractical0.SelectedDataKey.Values["intWorkActivityId"].ToString());
                        
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(Convert.ToInt32(hdfRowIndex.Value.ToString()));
                    //addTradeTable(0, 0, ddlSector.SelectedValue.ToString(), ddlTrade.SelectedValue.ToString(), ddlSector.SelectedItem.Text.ToString(), ddlTrade.SelectedItem.Text.ToString(), Convert.ToInt32(Session["uid"].ToString()), (DataTable)Session["tradeDataTable"], ddlTradeDuration.SelectedItem.Text.ToString(), ddlTradeDuration.SelectedValue.ToString(), txtTradetarget.Text);
                    fillTrademappingGriddr((DataTable)Session["tmpdrDataTable"], txtWorkName.Text, ddlAreaofWork.SelectedValue, ddlWorkActivity.SelectedValue, txtManpower.Text, txtEstDays.Text, txtEstEquipmntReq.Text, txtEstiMaterial.Text, txtSkillLabour.Text, cmf.convertDateIndia(txtWorkStartDate.Text).ToString("MM-dd-yyyy"), cmf.convertDateIndia(txtEndDate.Text).ToString("MM-dd-yyyy"), txtEstCost.Text, Session["uid"].ToString(), ddlAreaofWork.SelectedItem.Text, ddlWorkActivity.SelectedItem.Text, txtEstquantity1.Text, txtEstquantity2.Text);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();
                    BtnSave2.Text = "Add New";
                    txtEstquantity1.Text = "";
                    txtEstquantity2.Text = "";
                    txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";


                }
                else
                {

                    fillTrademappingGriddr((DataTable)Session["tmpdrDataTable"], txtWorkName.Text, ddlAreaofWork.SelectedValue, ddlWorkActivity.SelectedValue, txtManpower.Text, txtEstDays.Text, txtEstEquipmntReq.Text, txtEstiMaterial.Text, txtSkillLabour.Text, cmf.convertDateIndia(txtWorkStartDate.Text).ToString("MM-dd-yyyy"), cmf.convertDateIndia(txtEndDate.Text).ToString("MM-dd-yyyy"), txtEstCost.Text, Session["uid"].ToString(), ddlAreaofWork.SelectedItem.Text, ddlWorkActivity.SelectedItem.Text, txtEstquantity1.Text, txtEstquantity2.Text);

                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    txtEstquantity1.Text = "";
                    txtEstquantity2.Text = "";
                    txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";
                }

            }
            else
            {

                if (BtnSave2.Text.ToString().ToLower() == "update")
                {
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(Convert.ToInt32(hdfRowIndex.Value.ToString()));
                    //addTradeTable(0, 0, ddlSector.SelectedValue.ToString(), ddlTrade.SelectedValue.ToString(), ddlSector.SelectedItem.Text.ToString(), ddlTrade.SelectedItem.Text.ToString(), Convert.ToInt32(Session["uid"].ToString()), (DataTable)Session["tradeDataTable"], ddlTradeDuration.SelectedItem.Text.ToString(), ddlTradeDuration.SelectedValue.ToString(), txtTradetarget.Text);
                    fillTrademappingGriddr((DataTable)Session["tmpdrDataTable"], txtWorkName.Text, ddlAreaofWork.SelectedValue, ddlWorkActivity.SelectedValue, txtManpower.Text, txtEstDays.Text, txtEstEquipmntReq.Text, txtEstiMaterial.Text, txtSkillLabour.Text, cmf.convertDateIndia(txtWorkStartDate.Text).ToString("MM-dd-yyyy"), cmf.convertDateIndia(txtEndDate.Text).ToString("MM-dd-yyyy"), txtEstCost.Text, Session["uid"].ToString(), ddlAreaofWork.SelectedItem.Text, ddlWorkActivity.SelectedItem.Text, txtEstquantity1.Text, txtEstquantity2.Text);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();
                    BtnSave2.Text = "Add New";
                    txtEstquantity1.Text = "";
                    txtEstquantity2.Text = "";
                    txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";


                }
                else
                {

                    fillTrademappingGriddr((DataTable)Session["tmpdrDataTable"], txtWorkName.Text, ddlAreaofWork.SelectedValue, ddlWorkActivity.SelectedValue, txtManpower.Text, txtEstDays.Text, txtEstEquipmntReq.Text, txtEstiMaterial.Text, txtSkillLabour.Text, cmf.convertDateIndia(txtWorkStartDate.Text).ToString("MM-dd-yyyy"), cmf.convertDateIndia(txtEndDate.Text).ToString("MM-dd-yyyy"), txtEstCost.Text, Session["uid"].ToString(), ddlAreaofWork.SelectedItem.Text, ddlWorkActivity.SelectedItem.Text, txtEstquantity1.Text, txtEstquantity2.Text);

                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    txtEstquantity1.Text = "";
                    txtEstquantity2.Text = "";
                    txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            //   lblresult.Text = ex.ToString();
        }
        finally
        {

        }
    }


    private void fillTrademappingGriddr(DataTable tmpTabledr, string WorkName, string intAreaofWork, string intWorkActivity, string EstManPower, string EstDays, string EstEquipmnts, string EstMaterial, string EstSkilLabour, string EstWorkStartDate, string EstWorkEndDate, string EstCost, string Created_by, string AreaofWork, string WorkActivity, string EquipmntQuantity, string MaterialQuantity)
    {

        dtrdr = tmpTabledr.NewRow();
        dtrdr["intWorkActivityId"] = "0";
        dtrdr["new"] = "0";
        dtrdr["WorkName"] = WorkName.Trim();
        dtrdr["intAreaofWork"] = intAreaofWork.Trim();
        dtrdr["intWorkActivity"] = intWorkActivity.Trim();
        dtrdr["EstManPower"] = EstManPower.Trim();
        dtrdr["EstDays"] = EstDays.Trim();

        dtrdr["EstEquipmnts"] = EstEquipmnts.Trim();
        dtrdr["EstMaterial"] = EstMaterial.Trim();
        dtrdr["intWorkid"] = "0";
        dtrdr["EstSkilLabour"] = EstSkilLabour.Trim();
        dtrdr["EstWorkStartDate"] = EstWorkStartDate.Trim();
        dtrdr["EstWorkEndDate"] = EstWorkEndDate.Trim();
        dtrdr["EstCost"] = EstCost.Trim();
        dtrdr["WorkActivity"] = WorkActivity.Trim();
        dtrdr["AreaofWork"] = AreaofWork.Trim();

        dtrdr["EquipmntQuantity"] = EquipmntQuantity.Trim();
        dtrdr["MaterialQuantity"] = MaterialQuantity.Trim();


        
            
        tmpTabledr.Rows.Add(dtrdr);


    }

    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["tmpdrDataTable"];
        DataView dvdr = new DataView(myDtNewRecdr);
        dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }

    protected DataTable createtabledr()
    {
        Session["dtMyTabledr"] = new DataTable("drDetails");
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("new", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("WorkName", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intAreaofWork", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intWorkActivity", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstManPower", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstDays", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstEquipmnts", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstMaterial", typeof(string));

        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstSkilLabour", typeof(string));

        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstWorkStartDate", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstWorkEndDate", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EstCost", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Created_by", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intWorkid", typeof(string));

        ((DataTable)Session["dtMyTabledr"]).Columns.Add("AreaofWork", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("WorkActivity", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intWorkActivityId", typeof(string));

        ((DataTable)Session["dtMyTabledr"]).Columns.Add("EquipmntQuantity", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("MaterialQuantity", typeof(string));
        

        return ((DataTable)Session["dtMyTabledr"]);
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcounties();
    }
    void getcounties()
    {
        ddlCounties.Items.Clear();
        ddlPayam.Items.Clear();
        if (ddlState.SelectedIndex != 0)
        {
            Gen.getCounties(ddlCounties, ddlState.SelectedValue);
        }
        else
        {
            ddlCounties.Items.Insert(0, "--Select--");
            ddlPayam.Items.Insert(0, "--Select--");

        }
    }

    void getPayams()
    {
        ddlPayam.Items.Clear();
        if (ddlCounties.SelectedIndex != 0)
        {
            Gen.getPayams(ddlPayam, ddlCounties.SelectedValue);
        }
        else
        {
            ddlPayam.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPayams();
    }
    protected void ddlPayam_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBomas();
    }
    void getBomas()
    {
        ddlBoma.Items.Clear();
        if (ddlPayam.SelectedIndex != 0)
        {
            Gen.getBomas(ddlBoma, ddlPayam.SelectedValue);
        }
        else
        {
            ddlBoma.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        getprojectDet();
        getworksbyPojects();
    }

    void getworksbyPojects()
    {
        
        if (ddlProject.SelectedIndex != 0)
        {
            Gen.getAreaofWorksByPrjid(ddlAreaofWork, ddlProject.SelectedValue);
        }
        else
        {
            ddlAreaofWork.Items.Insert(0, "--Select--");           

        }
    }

    void getprojectDet()
    {
        DataSet ds = new DataSet();
        if (ddlProject.SelectedValue != "--Select--")
        {
            ds = Gen.GetProjectDetbyId(ddlProject.SelectedValue);
            lblTargetBenefeciaries.Text = ds.Tables[0].Rows[0]["TargetBeneficiary"].ToString();
            lblCost.Text = ds.Tables[0].Rows[0]["ProjectCost"].ToString();

        }
        else
        {
            lblTargetBenefeciaries.Text = "";
            lblCost.Text = "";
        }
    }

    protected void ddlIP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIP.SelectedValue != "--Select--")
        {
            Gen.getProjects(ddlProject, ddlIP.SelectedValue);
        }
        else
        {
            ddlProject.Items.Clear();
            ddlProject.Items.Insert(0, "--Select--");
        }

    }

    protected void ddlAreasofWork_SelectedIndexChanged(object sender, EventArgs e)
    {
        getWorkActivities();
    }
    void getWorkActivities()
    {

        ddlWorkActivity.Items.Clear();

        if (ddlAreaofWork.SelectedIndex != 0)
        {
            Gen.getWorkActivitiesByProjects(ddlWorkActivity, ddlAreaofWork.SelectedValue, ddlProject.SelectedValue);
        }
        else
        {
            ddlWorkActivity.Items.Insert(0, "--Select--");
            
        }
    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
        txtWorkName.Text = ""; ddlAreaofWork.SelectedIndex = 0; ddlWorkActivity.SelectedIndex = 0; txtManpower.Text = ""; txtEstDays.Text = ""; txtEstEquipmntReq.Text = ""; txtEstiMaterial.Text = ""; txtSkillLabour.Text = ""; txtWorkStartDate.Text = ""; txtEndDate.Text = ""; txtEstCost.Text = "";
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstatus.SelectedValue == "Approved")
        {
            Label426.Text = "Approved Date";
        }
        else if (ddlstatus.SelectedValue == "Rejected")
        {
            Label426.Text = "Rejected Date";
        }
        else
        {
            Label426.Text = "Date";
        }
    }
    protected void gvpractical0_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int rowval;
            rowval = gvpractical0.SelectedIndex;
            hdfRowIndex.Value = rowval.ToString();
            
            //hdfTradeID.Value = gvpractical0.SelectedDataKey.Values["intTradeID"].ToString();
            //var strSector = gvpractical0.SelectedDataKey.Values["SectorID"].ToString();
            //ddlSector.SelectedValue = ddlSector.Items.FindByValue(strSector.ToString()).Value;
            //clsCommon.getTrade(ddlTrade, ddlSector.SelectedValue.ToString());

            //var strTrade = gvpractical0.SelectedDataKey.Values["TradeID"].ToString();
            //ddlTrade.SelectedValue = ddlTrade.Items.FindByValue(strTrade.ToString()).Value;



            //var DurMonths = gvpractical0.SelectedDataKey.Values["DurMonths"].ToString();
            //ddlTradeDuration.SelectedValue = ddlTradeDuration.Items.FindByValue(DurMonths.ToString()).Value;

            //var Target = gvpractical0.SelectedDataKey.Values["Target"].ToString();
            //txtTradetarget.Text = Target;



            txtWorkName.Text = gvpractical0.SelectedDataKey.Values["WorkName"].ToString();
            ddlAreaofWork.SelectedValue = gvpractical0.SelectedDataKey.Values["intAreaofWork"].ToString();
            getWorkActivities();
            ddlWorkActivity.SelectedValue = gvpractical0.SelectedDataKey.Values["intWorkActivity"].ToString();
            txtManpower.Text = gvpractical0.SelectedDataKey.Values["EstManPower"].ToString();
            txtEstDays.Text = gvpractical0.SelectedDataKey.Values["EstDays"].ToString();
            txtEstEquipmntReq.Text = gvpractical0.SelectedDataKey.Values["EstEquipmnts"].ToString();
            txtEstiMaterial.Text = gvpractical0.SelectedDataKey.Values["EstMaterial"].ToString();
            txtSkillLabour.Text = gvpractical0.SelectedDataKey.Values["EstSkilLabour"].ToString();
            txtWorkStartDate.Text = Convert.ToDateTime( gvpractical0.SelectedDataKey.Values["EstWorkStartDate"].ToString()).ToString("dd-MM-yyyy");
            txtEndDate.Text = Convert.ToDateTime(gvpractical0.SelectedDataKey.Values["EstWorkEndDate"].ToString()).ToString("dd-MM-yyyy");
            txtEstCost.Text = gvpractical0.SelectedDataKey.Values["EstCost"].ToString();
             
             txtEstquantity1.Text = gvpractical0.SelectedDataKey.Values["EquipmntQuantity"].ToString();
            txtEstquantity2.Text = gvpractical0.SelectedDataKey.Values["MaterialQuantity"].ToString();

            BtnSave2.Text = "Update";
            

            
        }
        catch (Exception ex)
        {
            
        }
        finally
        {

        }
    }


    public void SendMailAnother(string anothermail,string Wokcode)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        
        mail.CC.Add("support@fruxsoft.com");
        //if()
        string Messge = ddlIP.SelectedItem.Text + " has Proposed some works.Please verify it.";

        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS MIS ::", System.Text.Encoding.UTF8);

        mail.Subject = "TSiPASS TSiPASS MIS - Notification - From IP : " + Session["user_id"].ToString();

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Dear " + hdfTSTName.Value + "<br><br>  <H2>TSiPASS TSiPASS MIS - Works Notification</H2><br> <b> IP NAME: " + ddlIP.SelectedItem.Text + "</b> <br><br> Work Code: " + Wokcode.ToString() + "<br> <br> Remarks : " + Messge.ToString() + "<br> <br> URL:  <a href=http://203.124.107.65/publicworks target='_blank' > TSiPASS TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>"+ddlIP.SelectedItem.Text+"";
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
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
        } // end try

    }


    public void SendMailAnotherApprv(string anothermail,string workcode,string Status,string Name)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);

        mail.CC.Add("support@fruxsoft.com");
        string Messge = "";
        if (Status.ToString() == "Approved")
        {

             Messge = "Work code " + workcode.ToString() + " has Approved by TST Team. Please verify it.";
        }
        

        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS MIS ::", System.Text.Encoding.UTF8);

        mail.Subject = "TSiPASS TSiPASS MIS - Notification -From TST - " + Session["user_id"].ToString();

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Dear " + ddlIP.SelectedItem.Text + "<br><br>  <H2>TSiPASS TSiPASS MIS - Works Notification</H2><br> <b> IP NAME: " + ddlIP.SelectedItem.Text + "</b> <br><br> Work Code: " + workcode.ToString() + "<br> <br> Remarks : " + Messge.ToString() + "<br> <br> URL:  <a href=http://203.124.107.65/publicworks target='_blank' > TSiPASS TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>"+Name.ToString()+"";
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
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
        } // end try

    }

}
