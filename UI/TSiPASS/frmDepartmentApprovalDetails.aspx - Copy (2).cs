using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    int RowCount;
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee, TotalFeeAmount;
    decimal amounts1;
    decimal TotalFeeNExt;
    decimal amounts22 = 0;
    int hmdaCount;
    int hmdaCount1;
    string amt = "0";
    int n1;

    string SubmissionCheck;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareReg.aspx");
            }

            DataSet ds = new DataSet();
            ds = Gen.GetEnterpreneourDashboardDetails(Session["uid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["Submitted"].ToString() == "No")
                {

                    SubmissionCheck = "Draft";
                }
                else
                {
                    Label6.Text = "Submitted";
                }
            }
            DataSet dsdtls = new DataSet();
            dsdtls = Gen.GetQuestionereisReceiptDetails(Session["Applid"].ToString().Trim());
            if (dsdtls.Tables[1].Rows.Count > 0)
            {
                if (dsdtls.Tables[0].Rows[0]["Locationofunit"].ToString() == "Within the purview of DT&CP")
                {
                    Session["dtcpFlag"] = "Y";
                }
                grdDetails.DataSource = dsdtls.Tables[1];
                grdDetails.DataBind();
                RowCount = dsdtls.Tables[1].Rows.Count;
            }
       

            //fillfileattachments();
            //uploadedfilesattchments();
            //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            //{

            //}
        }
    }
    void uploadedfilesattchments()
    {
        DataSet dsent = new DataSet();
        // dsent = Gen.GetdataofEnterprenuer(Session["Applid"].ToString());
        //if (dsent.Tables[0].Rows.Count > 0)
        //{

        //    hdfID.Value = dsent.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
        //    FillDetailsNew(dsent);
        //}
        hdfID.Value = Session["Applid"].ToString();
        FillDetailsNew(dsent);
    }
    void fillfileattachments()
    {

        DataSet ds = new DataSet();
        ds = Gen.RetriveIsOfflineByAPPID(Session["Applid"].ToString());
        int count = ds.Tables[0].Rows.Count;
        string fileexistyes = "";

        for (int l = 0; l < count; l++)
        {
            string Refno = Gen.RetriveRefNo(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());
            string res = Gen.RetriveIsOffline(Session["Applid"].ToString(), ds.Tables[0].Rows[l][0].ToString(), ds.Tables[0].Rows[l][1].ToString());
            // ---------------------------------------------------------------------------------------------------------------------------------------------------------
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "268" && ds.Tables[0].Rows[l][1].ToString() == "46")
            {
                fileexistyes = "Y";
                ViewState["LegalMetrologyDepartmentD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["LegalMetrologyDepartmentA"] = ds.Tables[0].Rows[l][1].ToString();
                trLegalMetrologyDepartmentref.Visible = true;
                trLegalMetrologyDepartment.Visible = true;
                if (Refno != "")
                    txtLegalMetrologyDepartment.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "267" && ds.Tables[0].Rows[l][1].ToString() == "47")
            {
                // Registration Under Buildings & Other Construction Workers (RE & COS) Act, 1996 As Required
                fileexistyes = "Y";
                ViewState["LabourDepartment47D"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["LabourDepartment47A"] = ds.Tables[0].Rows[l][1].ToString();
                trLabourDepartmentref.Visible = true;
                trLabourDepartment.Visible = true;
                if (Refno != "")
                    txtLabourDepartment.Text = Refno;
            }
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "267" && ds.Tables[0].Rows[l][1].ToString() == "48")
            {
                // Registration Under Contract Labour(Regulation and Abolition) Act, 1970 
                fileexistyes = "Y";
                ViewState["LabourDepartment48D"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["LabourDepartment48A"] = ds.Tables[0].Rows[l][1].ToString();
                trLabourDepartmentref48.Visible = true;
                trLabourDepartment48.Visible = true;
                if (Refno != "")
                    txtLabourDepartment48.Text = Refno;
            }
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "267" && ds.Tables[0].Rows[l][1].ToString() == "49")
            {
                // Registration Under Inter State Migrant Workman Act, 1979 (for Contractor)
                fileexistyes = "Y";
                ViewState["LabourDepartment49D"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["LabourDepartment49A"] = ds.Tables[0].Rows[l][1].ToString();
                trLabourDepartmentref49.Visible = true;
                trLabourDepartment49.Visible = true;
                if (Refno != "")
                    txtLabourDepartment49.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "73" && ds.Tables[0].Rows[l][1].ToString() == "28")
            {

                fileexistyes = "Y";
                ViewState["ForestD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["ForestA"] = ds.Tables[0].Rows[l][1].ToString();
                trforestref.Visible = true;
                trforestdept.Visible = true;
                if (Refno != "")
                    txttrforestref.Text = Refno;
            }
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "142" && ds.Tables[0].Rows[l][1].ToString() == "30")
            {
                fileexistyes = "Y";
                ViewState["KudaD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["KudaA"] = ds.Tables[0].Rows[l][1].ToString();
                trKUDAref.Visible = true;
                trkuda.Visible = true;
                if (Refno != "")
                    txttrKUDAref.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "151" && ds.Tables[0].Rows[l][1].ToString() == "41")
            {
                fileexistyes = "Y";
                ViewState["CessD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["CessA"] = ds.Tables[0].Rows[l][1].ToString();
                trcessref.Visible = true;
                trcess.Visible = true;
                if (Refno != "")
                    txttrcess.Text = Refno;
            }
            if (res == "Y" && ds.Tables[0].Rows[l][1].ToString() == "32")
            {
                fileexistyes = "Y";
                ViewState["NOCforExplosiveLicenseD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["NOCforExplosiveLicenseA"] = ds.Tables[0].Rows[l][1].ToString();
                TrExplosiveLicenseref.Visible = true;
                TrExplosiveLicenser.Visible = true;
                if (Refno != "")
                    txtTrExplosiveLicense.Text = Refno;
            }
            if (res == "Y" && ds.Tables[0].Rows[l][1].ToString() == "60")
            {
                fileexistyes = "Y";
                ViewState["FTLNocforChangeofLandUseRevenueD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["FTLNocforChangeofLandUseRevenueA"] = ds.Tables[0].Rows[l][1].ToString();
                trtrFTLRevenueref.Visible = true;
                trFTLRevenue.Visible = true;
                if (Refno != "")
                    txttrFTLRevenue.Text = Refno;
            }
            //-----------------------------------------------------------------------------------------------------------------------------
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "1")
            {
                fileexistyes = "Y";
                ViewState["pcbD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["pcbA"] = ds.Tables[0].Rows[l][1].ToString();
                Panelpcb1.Visible = true;
                Panelpcb.Visible = true;
                if (Refno != "")
                    txtPCBRefNo.Text = Refno;

            }
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "2")
            {
                fileexistyes = "Y";
                ViewState["TSCTD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["TSCTA"] = ds.Tables[0].Rows[l][1].ToString();
                panelTSCT.Visible = true;
                panelTSCT1.Visible = true;
                if (Refno != "")
                    txtTSCTRefNo.Text = Refno;

            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "3")
            {
                fileexistyes = "Y";
                ViewState["TSIICD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["TSIICA"] = ds.Tables[0].Rows[l][1].ToString();
                panelTSIIC.Visible = true;
                panelTSIIC1.Visible = true;
                if (Refno != "")
                    TextBox2.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "4" && ds.Tables[0].Rows[l][1].ToString() == "2")
            {
                fileexistyes = "Y";
                ViewState["PRDD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["PRDA"] = ds.Tables[0].Rows[l][1].ToString();
                panelPRD.Visible = true;
                panelPRD1.Visible = true;
                if (Refno != "")
                    TextBox3.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "5")
            {
                fileexistyes = "Y";
                ViewState["DISCOMD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["DISCOMA"] = ds.Tables[0].Rows[l][1].ToString();
                panelDISCOM.Visible = true;
                panelDISCOM1.Visible = true;
                if (Refno != "")
                    TextBox4.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "6")
            {
                fileexistyes = "Y";
                ViewState["CEIGD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["CEIGA"] = ds.Tables[0].Rows[l][1].ToString();
                panelCEIG.Visible = true;
                panelCEIG1.Visible = true;
                if (Refno != "")
                    TextBox5.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "7")
            {
                fileexistyes = "Y";
                ViewState["TSNPDCLD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["TSNPDCLA"] = ds.Tables[0].Rows[l][1].ToString();
                panelTSNPDCL.Visible = true;
                panelTSNPDCL1.Visible = true;
                if (Refno != "")
                    TextBox6.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "8")
            {
                fileexistyes = "Y";
                ViewState["TSSPDCLD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["TSSPDCLA"] = ds.Tables[0].Rows[l][1].ToString();
                panelTSSPDCL.Visible = true;
                panelTSSPDCL1.Visible = true;
                if (Refno != "")
                    TextBox7.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "9")
            {
                fileexistyes = "Y";
                ViewState["FACTD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["FACTA"] = ds.Tables[0].Rows[l][1].ToString();
                panelFACT.Visible = true;
                panelFACT1.Visible = true;
                if (Refno != "")
                    TextBox8.Text = Refno;
            }

            //if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "10")
            //{
            //    panelINDUS.Visible = true;
            //    panelINDUS1.Visible = true;
            //}

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "11")
            {
                fileexistyes = "Y";
                ViewState["HMDAD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["HMDAA"] = ds.Tables[0].Rows[l][1].ToString();
                panelHMDA.Visible = true;
                panelHMDA1.Visible = true;
                if (Refno != "")
                    TextBox10.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][1].ToString() == "34")
            {
                fileexistyes = "Y";
                ViewState["CCLAD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["CCLAA"] = ds.Tables[0].Rows[l][1].ToString();
                panelCCLA.Visible = true;
                panelCCLA1.Visible = true;
                if (Refno != "")
                    TextBox11.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "13")
            {
                fileexistyes = "Y";
                ViewState["DTCPD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["DTCPA"] = ds.Tables[0].Rows[l][1].ToString();
                panelDTCP.Visible = true;
                panelDTCP1.Visible = true;
                if (Refno != "")
                    TextBox12.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "14")
            {
                fileexistyes = "Y";
                ViewState["FIRED"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["FIREA"] = ds.Tables[0].Rows[l][1].ToString();
                panelFIRE.Visible = true;
                panelFIRE1.Visible = true;
                if (Refno != "")
                    TextBox13.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "15")
            {
                fileexistyes = "Y";
                ViewState["GWD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["GWA"] = ds.Tables[0].Rows[l][1].ToString();
                panelGW.Visible = true;
                panelGW1.Visible = true;
                if (Refno != "")
                    TextBox14.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "16")
            {
                fileexistyes = "Y";
                ViewState["HMWSSBD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["HMWSSBA"] = ds.Tables[0].Rows[l][1].ToString();
                panelHMWSSB.Visible = true;
                panelHMWSSB1.Visible = true;
                if (Refno != "")
                    TextBox15.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "17")
            {
                fileexistyes = "Y";
                ViewState["EXCISED"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["EXCISEA"] = ds.Tables[0].Rows[l][1].ToString();
                panelEXCISE.Visible = true;
                panelEXCISE1.Visible = true;
                if (Refno != "")
                    TextBox16.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "18")
            {
                fileexistyes = "Y";
                ViewState["REGSTAMPD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["REGSTAMPA"] = ds.Tables[0].Rows[l][1].ToString();
                panelREGSTAMP.Visible = true;
                panelREGSTAMP1.Visible = true;
                if (Refno != "")
                    TextBox17.Text = Refno;
            }
            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "19")
            {
                fileexistyes = "Y";
                ViewState["DCAD"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["DCAA"] = ds.Tables[0].Rows[l][1].ToString();
                panelDCA.Visible = true;
                panelDCA1.Visible = true;
                if (Refno != "")
                    TextBox18.Text = Refno;
            }

            if (res == "Y" && ds.Tables[0].Rows[l][0].ToString() == "20")
            {
                fileexistyes = "Y";
                ViewState["IRRIGATIOND"] = ds.Tables[0].Rows[l][0].ToString();
                ViewState["IRRIGATIONA"] = ds.Tables[0].Rows[l][1].ToString();
                panelIRRIGATION.Visible = true;
                panelIRRIGATION1.Visible = true;
                if (Refno != "")
                    TextBox19.Text = Refno;
            }
        }
        if (fileexistyes == "")
        {
            Response.Redirect("frmEntrepreneurDetails.aspx");
        }
        else
        {
            attachmentsdiv.Visible = true;
            btnnext.Focus();
        }
    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }
    protected void txtcontact6_TextChanged(object sender, EventArgs e)
    {

    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        {

            Response.Redirect("frmQuesstionniareReg.aspx");

        }
        else
        {
            int cnt = 0;
            int selectedcount = 0;
            int selectedcount1 = 0;
            foreach (GridViewRow row in grdDetails.Rows)
            {
                RadioButtonList rdbyn = (RadioButtonList)row.FindControl("RdWhetherAlreadyApproved");
                if (rdbyn.SelectedValue == "N")
                {
                    selectedcount = selectedcount + 1;
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        selectedcount1 = selectedcount1 + 1;
                    }
                }

                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    cnt = cnt + 1;
                }
            }
            if (cnt <= 1)
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please Select Atleaset one Department for Approval";
                lblmsg0.Visible = true;
            }
            //else if (selectedcount != selectedcount1)
            //{
            //    Failure.Visible = true;
            //    lblmsg0.Text = "Please Select Department for Approval if You Not already obtained";
            //    lblmsg0.Visible = true;
            //}
            else
            {

                Failure.Visible = false;
                lblmsg0.Text = "";
                lblmsg0.Visible = false;

                foreach (GridViewRow row in grdDetails.Rows) //only for NALA
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                        if (HdfApprovalid == "34")
                        {
                            string CHKVALUE = CheckNalaValue(HdfQueid, HdfApprovalid, "0", "CHK");
                            if (CHKVALUE == "NO")
                            {
                                trmarketvalue.Visible = true;
                                //  trnewbuttons.Visible = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                                return;
                            }
                            else
                            {
                                trmarketvalue.Visible = false;
                                // trnewbuttons.Visible = true;
                            }
                        }
                    }
                }
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                        string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                        if(RdWhetherAlreadyApproved=="Y")
                        {
                            int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "Y", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                        }
                        else
                        {
                            int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                        }

                       
                    }
                    else
                    {
                        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                        string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                        int s = Gen.UpdDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                    }
                }
                fillfileattachments();
                uploadedfilesattchments();
                int rowsIndex = grdDetails.Rows.Count;

                if(rowsIndex>0)
                {

                    for (int i=0;i< rowsIndex;i++)
                    {
                        CheckBox chkCheck = (CheckBox)grdDetails.Rows[i].FindControl("ChkApproval");
                        //GridViewRow grdRwos = (GridViewRow)grdDetails.
                         GridViewRow grdRwos = (GridViewRow)chkCheck.NamingContainer;
                        if (chkCheck.Checked == true)
                            grdRwos.Cells[6].Text = grdRwos.Cells[4].Text;
                    }
                }
            }
        }

    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {



        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {




    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {






            }
            else
            {


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



    protected void GetNewRectoInsertdr()
    {

    }
    protected void RdWhetherAlreadyApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)RdWhetherAlreadyApproved.NamingContainer;
        int Rowindex = row.RowIndex;
        RadioButtonList rdbCheck = (RadioButtonList)grdDetails.Rows[Rowindex].FindControl("RdWhetherAlreadyApproved");
        HiddenField hdAmountCheck=(HiddenField)grdDetails.Rows[Rowindex].FindControl("HdfAmount");
        CheckBox chkCheck=(CheckBox)grdDetails.Rows[Rowindex].FindControl("ChkApproval");

        decimal amounts3 = 0;
        chkCheck.Enabled = false;
        Label lblAmount = (Label)row.FindControl("lblAmounts");


        if (lblAmount.Text != "Label" && rdbCheck.SelectedItem.Value == "Y")
        {
            amounts3 = Convert.ToDecimal(lblAmount.Text.ToString());
            amounts3 = 0;
        }
       else if (lblAmount.Text == "Label" && rdbCheck.SelectedItem.Value != "Y")
        {
            string feees = hdAmountCheck.Value.ToString();
            feees = feees.Replace(",", "");
            amounts3 = Convert.ToDecimal(feees);
        }
        else if (lblAmount.Text == "Label" && rdbCheck.SelectedItem.Value == "Y")
        {
            string feees = hdAmountCheck.Value.ToString();
            feees = feees.Replace(",", "");
            amounts3 = Convert.ToDecimal(feees);
        }
        else
        {
            string feees = hdAmountCheck.Value.ToString();
            feees = feees.Replace(",", "");
            amounts3 = Convert.ToDecimal(feees);
        }
          


        
        decimal amounts4 = 0;
        int initailRowindex=0;

        //HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();
        CheckBox ChkApproval = (CheckBox)row.FindControl("ChkApproval");

        ChkApproval.Enabled = false;
          HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        if (RdWhetherAlreadyApproved.Items[0].Selected == true)
        {

            ChkApproval.Visible = false;
            row.Cells[6].Text = "0";
            initailRowindex = row.RowIndex;
        }
        else
        {

            ChkApproval.Visible = true;
            //ChkApproval.Checked = false;
            ChkApproval.Enabled = false;
            if (chkCheck.Checked == true)
            {
                row.Cells[6].Text = row.Cells[4].Text;
                RdWhetherAlreadyApproved.Items[1].Selected = true;
                RdWhetherAlreadyApproved.Enabled = false;
            }
            else
            {
                row.Cells[6].Text = "0";
                initailRowindex = row.RowIndex;
            }


        }

        //int Rowindex = row.RowIndex;
        int totalRowindex = grdDetails.Rows.Count;
        int incRowindex = 0;

        while (incRowindex < totalRowindex)
        {
            string ApprovalNameCheck = grdDetails.Rows[incRowindex].Cells[2].Text.ToString();
            rdbCheck = (RadioButtonList)grdDetails.Rows[incRowindex].FindControl("RdWhetherAlreadyApproved");
            if (incRowindex != totalRowindex && rdbCheck.SelectedItem.Value!="Y")
            {
                
                amounts3 = Convert.ToDecimal(grdDetails.Rows[incRowindex].Cells[4].Text.ToString());
                grdDetails.Rows[incRowindex].Cells[6].Text = grdDetails.Rows[incRowindex].Cells[4].Text;
                //grdDetails.Rows[incRowindex].Cells[6].Text = string.Format("{0:N0}", grdDetails.Rows[Rowindex].Cells[6].Text.ToString());
                amounts4 = amounts4 + amounts3;


            }


            else if (incRowindex <= totalRowindex || rdbCheck.SelectedItem.Value == "Y")
            {
                if(rdbCheck.SelectedItem.Value == "Y")
                {
                    amounts3 = 0;
                    grdDetails.Rows[incRowindex].Cells[6].Text = "0";
                }
                
                string testing = grdDetails.Rows[incRowindex].Cells[6].Text;
                
                amounts4 = amounts4 + amounts3;

            }
            string amountCheck = grdDetails.Rows[incRowindex].Cells[6].Text.ToString();
            incRowindex = incRowindex + 1;
        }
        decimal finalAmount = 0;
        
        //while (totalRowindex > 0)
        //{
        //    totalRowindex = totalRowindex - 1;  //since count starts from 1 less..
        //    HiddenField lblAmount_final = (HiddenField)grdDetails.Rows[totalRowindex].FindControl("HdfAmount");
        //    string ApprovalNameCheck = grdDetails.Rows[totalRowindex].Cells[2].Text.ToString();
        //    string feees = grdDetails.Rows[totalRowindex].Cells[4].Text.ToString();
        //    string ActualFee = grdDetails.Rows[totalRowindex].Cells[6].Text.ToString();
        //    feees = feees.Replace(",", "");
            
        //    if(feees!="")
        //    finalAmount = finalAmount+ Convert.ToDecimal(feees.ToString());
        //    if (lblAmount_final.Value.ToString() == "Label")
        //        grdDetails.Rows[totalRowindex].Cells[6].Text = grdDetails.Rows[totalRowindex].Cells[4].Text;
        //    //Label lblAmount_final = (Label)row.FindControl("lblAmounts");
           

        //}


        string TEXT = amounts4.ToString();

        decimal totalCheck = 0;

      

        grdDetails.FooterRow.Cells[6].Text = amounts4.ToString();
        //amounts1 = 0;

        //if ((row.RowType == DataControlRowType.Footer))
        //{
        //    row.Cells[5].Text = "Total Fee";
        //    //  e.Row.Cells[4].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0"); ;
        //    row.Cells[6].Text = amounts4.ToString("#,##0");
        //    //grdDetails.FooterRow.HorizontalAlign=cent
        //}

    }
    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
       // hmdaCount = Convert.ToInt32(Session["hmdaCount"].ToString());
      //  hmdaCount1 = Convert.ToInt32(Session["hmdaCount1"].ToString());
        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        HiddenField HdfQueid = (HiddenField)row.FindControl("HdfQueid");
        HiddenField HdfApprovalid = (HiddenField)row.FindControl("HdfApprovalid");
        CheckBox ChkApprovalnew = (CheckBox)row.FindControl("ChkApproval");
        ChkApprovalnew.Enabled=false;
        if (HdfApprovalid.Value == "34")
        {
            string CHKVALUE = CheckNalaValue(HdfQueid.Value, HdfApprovalid.Value, "0", "CHK");
            if (CHKVALUE == "NO")
            {
                trmarketvalue.Visible = true;
                ChkApprovalnew.Checked = false;
                //trnewbuttons.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }
            else
            {
                trmarketvalue.Visible = false;
                // trnewbuttons.Visible = true;
            }
        }
        if (HdfApprovalid.Value == "2")
        {
            ChkApprovalnew.Checked = false;
            string message = Server.HtmlDecode("As per the New Panchayat Raj Act (No.5 of 2018 published in gazette on 30-03-2018) and Memo (No.7578/Pts.II/A1/2017 Dt 11.05.2018) GP NOC (No Objection Certificate from Panchayat Secretary of Village) is no longer required for establishing industries");
            string messagenew = "alert('" + message + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
            return;
        }
        decimal amount = Convert.ToDecimal("0.00");
        if (ChkApproval.Checked == true)
        {            
    
            row.Cells[6].Text = row.Cells[4].Text;
        }
        else
        {
            row.Cells[6].Text = "0";
        }

        // string name = (grdDetails.FooterRow.FindControl("txtName") as TextBox).Text;
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (row1.Cells[6].Text == "")
                {
                    if (row1.Cells[4].Text != "")

                        row1.Cells[6].Text = row1.Cells[4].Text;
                    else
                        row1.Cells[6].Text = "0";
                }
                amount = amount + Convert.ToDecimal(row1.Cells[6].Text);

            }
        }

        amt = amount.ToString("f0");

        int Rowindex = row.RowIndex;
        int totalRowindex = grdDetails.Rows.Count;

        while (Rowindex < totalRowindex)
        {

            grdDetails.Rows[Rowindex].Cells[6].Text = grdDetails.Rows[Rowindex].Cells[4].Text;
            grdDetails.Rows[Rowindex].Cells[6].Text = string.Format("{0:N0}", grdDetails.Rows[Rowindex].Cells[6].Text.ToString());
            Rowindex = Rowindex + 1;
        }

        //Label lblAmount = (Label)row.FindControl("lblAmounts");
        //decimal amounts = Convert.ToDecimal(lblAmount.Text.ToString());
        ////amounts1 = 0;
        //amounts1 = amounts1 + amounts;
       

        if ((row.RowType == DataControlRowType.Footer))
        {
            row.Cells[5].Text = "Total Fee";
            //  e.Row.Cells[4].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0"); ;
            row.Cells[6].Text = amount.ToString("#,##0");
            //grdDetails.FooterRow.HorizontalAlign=cent
        }

        grdDetails.FooterRow.Cells[6].Text = Convert.ToDecimal(amt).ToString("#,##0");


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            TotalFee = TotalFee + TotalFee1;
            //string s = "0";
            //if (e.Row.Cells[6].Text != "")
            //{
            //    s = e.Row.Cells[6].Text;
            //}
            //decimal TotalFee1a = Convert.ToDecimal(s);
            // TotalFeeNExt = TotalFeeNExt + TotalFee1a;

            HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
            HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
            HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
            RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)e.Row.FindControl("RdWhetherAlreadyApproved");

            HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();
            HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim();

            string approvalName = DataBinder.Eval(e.Row.DataItem, "ApprovalName").ToString().Trim();

            ChkApproval.Checked = true;
   
            //ChkApproval.Enabled = false;
            Label lblAmount = (Label)e.Row.FindControl("lblAmounts");
            lblAmount.Text = HdfAmount.Value.ToString();
           
 
            lblAmount.Text= string.Format("{0:N0}", lblAmount.Text.ToString());
            decimal amounts = Convert.ToDecimal(lblAmount.Text.ToString());
            int textCheck = grdDetails.Columns.Count;
        
            if(HdfDeptid.Value=="10")
            {
                RdWhetherAlreadyApproved.Enabled = false;
            }



            if (HdfApprovalid.Value == "33")
            {
                RdWhetherAlreadyApproved.Items[1].Selected = true;
                RdWhetherAlreadyApproved.Enabled = false;
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[4].Text;
            }


            if (HdfApprovalid.Value == "34")
            {
                string CHKVALUE = CheckNalaValue(HdfQueid.Value, HdfApprovalid.Value, "0", "CHK");
                if (CHKVALUE == "NO")
                {
                    trmarketvalue.Visible = true;
                    // trnewbuttons.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else
                {
                    trmarketvalue.Visible = false;
                    //  trnewbuttons.Visible = true;
                }
            }


            DataSet dsappr = new DataSet();
            dsappr = Gen.GetQuestionaryAprovalsApplyData(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim());
          
            if(dsappr.Tables[1].Rows.Count > 0 && dsappr.Tables[0].Rows.Count == 0)  //DEPT 0 AND QUES VALUES HAS - NEED TO ENABLE THE YES BUTTON
            {
                RdWhetherAlreadyApproved.Enabled = true;  //check here- this is true!
                ChkApproval.Enabled = false;
                ChkApproval.Checked = true;
            }
          
            else if (dsappr.Tables[0].Rows.Count >0)
            {
                if(SubmissionCheck!= "Draft")
                {
                    RdWhetherAlreadyApproved.Enabled = false;
                }
                
                if(dsappr.Tables[0].Rows[0]["IsOffline"].ToString().Trim()=="Y")
                {
                    RdWhetherAlreadyApproved.SelectedValue = "Y";

                    lblAmount.Text = "0";
                    amounts = 0;
                    e.Row.Cells[6].Text = "0";

                }
                ChkApproval.Enabled = false;
            }

            if (HdfApprovalid.Value == "33")
            {
                if (SubmissionCheck != "Draft" || SubmissionCheck != "Submitted")
                {
                    RdWhetherAlreadyApproved.Enabled = false;
                }

                RdWhetherAlreadyApproved.Items[1].Selected = true;
                RdWhetherAlreadyApproved.Enabled = false;
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[4].Text;
            }

            if (ChkApproval.Checked == true && amounts != 0)
            {
                e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                //RdWhetherAlreadyApproved.Items[1].Selected = true;
                //RdWhetherAlreadyApproved.Enabled = false;
            }

            if (e.Row.Cells[6].Text != "" && amounts!=0)
            {

                decimal TotalFeeAmount1 = Convert.ToDecimal(e.Row.Cells[6].Text);
                TotalFeeAmount = TotalFeeAmount + TotalFeeAmount1;
                if (e.Row.Cells[6].Text != "")
                    e.Row.Cells[6].Text = Convert.ToDecimal(e.Row.Cells[6].Text).ToString("#,##0");
            }

            if (e.Row.RowIndex >= 0)
            {
                amounts1 = amounts;
                amounts22 = amounts1 + amounts22;

            }


        }

        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[5].Text = "Total Fee";
            //  e.Row.Cells[4].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0"); ;
            e.Row.Cells[6].Text = amounts22.ToString("#,##0");
            //grdDetails.FooterRow.HorizontalAlign=cent
        }



        //if ((e.Row.RowType == DataControlRowType.Footer))
        //{
        //    e.Row.Cells[5].Text = "Total Fee";
        //    //  e.Row.Cells[4].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0"); ;
        //    e.Row.Cells[6].Text = amounts1.ToString("#,##0");
        //    //grdDetails.FooterRow.HorizontalAlign=cent
        //}
    }
    protected void HdfAmount_ValueChanged(object sender, EventArgs e)
    {

    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\PCB");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    int n1 = 0;
                    if (ViewState["pcbD"] != null && ViewState["pcbA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtPCBRefNo.Text, Session["Applid"].ToString(), ViewState["pcbD"].ToString(), ViewState["pcbA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Polution Control Board", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["pcbA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label453.Text = FileUpload10.FileName;
                        Label454.Text = FileUpload10.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button8.Focus();
    }
    void FillDetailsNew(DataSet dsent)
    {
        // hdfFlagID.Value = "1000";
        DataSet ds = new DataSet();


        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            // ds = Gen.ViewAttachmetsData(dsent.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim());
            ds = Gen.ApprovalViewAttachmetsData(Session["Applid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, intapprovalidnew, OfflineApprovalflag;
                int i = 0;

                while (i < c)
                {
                    intapprovalidnew = ds.Tables[0].Rows[i]["intapprovalid"].ToString();
                    OfflineApprovalflag = ds.Tables[0].Rows[i]["OfflineApprovalflag"].ToString();

                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    if (intapprovalidnew == "46" && OfflineApprovalflag == "Y")
                    {
                        // legal
                        HlptrLegalMetrologyDepartment.NavigateUrl = sen;
                        HlptrLegalMetrologyDepartment.Text = ds.Tables[0].Rows[i][1].ToString();
                        lbltrLegalMetrologyDepartment.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "47" && OfflineApprovalflag == "Y")
                    {
                        // labour
                        HpLabourDepartment.NavigateUrl = sen;
                        HpLabourDepartment.Text = ds.Tables[0].Rows[i][1].ToString();
                        lblLabourDepartment.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "48" && OfflineApprovalflag == "Y")
                    {
                        // labour
                        HpLabourDepartment48.NavigateUrl = sen;
                        HpLabourDepartment48.Text = ds.Tables[0].Rows[i][1].ToString();
                        lblLabourDepartment48.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "49" && OfflineApprovalflag == "Y")
                    {
                        // labour
                        HpLabourDepartment49.NavigateUrl = sen;
                        HpLabourDepartment49.Text = ds.Tables[0].Rows[i][1].ToString();
                        lblLabourDepartment49.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "28" && OfflineApprovalflag == "Y")
                    {
                        // forest
                        hpltrforestdept.NavigateUrl = sen;
                        hpltrforestdept.Text = ds.Tables[0].Rows[i][1].ToString();
                        lbltrforestdept.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "30" && OfflineApprovalflag == "Y")
                    {
                        // kuda
                        hlptrkuda.NavigateUrl = sen;
                        hlptrkuda.Text = ds.Tables[0].Rows[i][1].ToString();
                        lbltrkuda.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "41" && OfflineApprovalflag == "Y")
                    {
                        // cess
                        hpltrcess.NavigateUrl = sen;
                        hpltrcess.Text = ds.Tables[0].Rows[i][1].ToString();
                        lbltrcess.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "32" && OfflineApprovalflag == "Y")
                    {
                        //NOCforExplosiveLicenseD
                        hlpTrExplosiveLicenser.NavigateUrl = sen;
                        hlpTrExplosiveLicenser.Text = ds.Tables[0].Rows[i][1].ToString();
                        lblTrExplosiveLicenser.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    if (intapprovalidnew == "60" && OfflineApprovalflag == "Y")
                    {
                        //FTLNocforChangeofLandUseRevenueD
                        hptrFTLRevenue.NavigateUrl = sen;
                        hptrFTLRevenue.Text = ds.Tables[0].Rows[i][1].ToString();
                        lbltrFTLRevenue.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    if (sen.Contains("PCB"))
                    {
                        Label453.NavigateUrl = sen;
                        Label453.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label454.Text = ds.Tables[0].Rows[i][1].ToString();

                        //    txtPCBRefNo.Enabled = false;
                        //   FileUpload10.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("CommercialTaxes"))
                    {

                        HyperLink1.NavigateUrl = sen;
                        HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label8.Text = ds.Tables[0].Rows[i][1].ToString();

                        //  txtTSCTRefNo.Enabled = false;
                        //  FileUpload11.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }


                    if (sen.Contains("TSIIC"))
                    {

                        HyperLink2.NavigateUrl = sen;
                        HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label11.Text = ds.Tables[0].Rows[i][1].ToString();
                        //   TextBox2.Enabled = false;
                        //  FileUpload12.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("PanchayatRaj"))
                    {

                        HyperLink3.NavigateUrl = sen;
                        HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label14.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //  TextBox3.Enabled = false;

                        // FileUpload13.Enabled = false;

                    }

                    if (sen.Contains("DISCOM"))
                    {

                        HyperLink4.NavigateUrl = sen;
                        HyperLink4.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label17.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //   TextBox4.Enabled = false;
                        //   FileUpload14.Enabled = false;

                    }

                    if (sen.Contains("ElectricalInspectorate"))
                    {

                        HyperLink5.NavigateUrl = sen;
                        HyperLink5.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label20.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox5.Enabled = false;
                        //FileUpload15.Enabled = false;
                    }

                    if (sen.Contains("TSNPDCL"))
                    {

                        HyperLink6.NavigateUrl = sen;
                        HyperLink6.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label23.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox6.Enabled = false;
                        //FileUpload16.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("TSSPDCL"))
                    {

                        HyperLink7.NavigateUrl = sen;
                        HyperLink7.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label26.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox7.Enabled = false;
                        //FileUpload17.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("Factories"))
                    {

                        HyperLink8.NavigateUrl = sen;
                        HyperLink8.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label29.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox8.Enabled = false;
                        //FileUpload18.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("HMDA"))
                    {

                        HyperLink10.NavigateUrl = sen;
                        HyperLink10.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label35.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox10.Enabled = false;
                        //FileUpload20.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("CCLA"))
                    {

                        HyperLink11.NavigateUrl = sen;
                        HyperLink11.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label38.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox11.Enabled = false;
                        //FileUpload21.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("DistrictTownandCountryPlanning"))
                    {

                        HyperLink12.NavigateUrl = sen;
                        HyperLink12.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label41.Text = ds.Tables[0].Rows[i][1].ToString();

                        //TextBox12.Enabled = false;
                        //FileUpload22.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("Fire"))
                    {

                        HyperLink13.NavigateUrl = sen;
                        HyperLink13.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label44.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox13.Enabled = false;
                        //FileUpload23.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("GroundWater"))
                    {

                        HyperLink14.NavigateUrl = sen;
                        HyperLink14.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label47.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox14.Enabled = false;
                        //FileUpload24.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("HMWSSB"))
                    {

                        HyperLink15.NavigateUrl = sen;
                        HyperLink15.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label50.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox15.Enabled = false;
                        //FileUpload25.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("Excise Department"))
                    {

                        HyperLink16.NavigateUrl = sen;
                        HyperLink16.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label53.Text = ds.Tables[0].Rows[i][1].ToString();
                        //TextBox16.Enabled = false;
                        //FileUpload26.Enabled = false;
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                    }

                    if (sen.Contains("RegistrationsandStamps"))
                    {

                        HyperLink17.NavigateUrl = sen;
                        HyperLink17.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label56.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox17.Enabled = false;
                        //FileUpload27.Enabled = false;
                    }

                    if (sen.Contains("DrugsControlAdministration"))
                    {

                        HyperLink18.NavigateUrl = sen;
                        HyperLink18.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label59.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox18.Enabled = false;
                        //FileUpload28.Enabled = false;
                    }

                    if (sen.Contains("Irrigation"))
                    {

                        HyperLink19.NavigateUrl = sen;
                        HyperLink19.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label62.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink8.NavigateUrl = sen;
                        //HyperLink8.Text = 
                        //TextBox19.Enabled = false;
                        //FileUpload29.Enabled = false;
                    }

                    i++;
                }

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\CommercialTaxes");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    if (ViewState["TSCTD"] != null && ViewState["TSCTA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtTSCTRefNo.Text, Session["Applid"].ToString(), ViewState["TSCTD"].ToString(), ViewState["TSCTA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "CommercialTaxes", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["TSCTA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink1.Text = FileUpload11.FileName;
                        Label8.Text = FileUpload11.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button9.Focus();
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload12.PostedFile != null) && (FileUpload12.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload12.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload12.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\TSIIC");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    if (ViewState["TSIICD"] != null && ViewState["TSIICA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox2.Text, Session["Applid"].ToString(), ViewState["TSIICD"].ToString(), ViewState["TSIICA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "TSIIC", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["TSIICA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink2.Text = FileUpload12.FileName;
                        Label11.Text = FileUpload12.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button10.Focus();
    }
    protected void Button27_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload29.PostedFile != null) && (FileUpload29.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload29.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload29.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\Irrigation");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload29.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload29.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["IRRIGATIOND"] != null && ViewState["IRRIGATIONA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox19.Text, Session["Applid"].ToString(), ViewState["IRRIGATIOND"].ToString(), ViewState["IRRIGATIONA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Irrigation", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["IRRIGATIONA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink19.Text = FileUpload29.FileName;
                        Label62.Text = FileUpload29.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button27.Focus();
    }
    protected void Button26_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload28.PostedFile != null) && (FileUpload28.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload28.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload28.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\DrugsControlAdministration");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload28.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload28.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["DCAD"] != null && ViewState["DCAA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox18.Text, Session["Applid"].ToString(), ViewState["DCAD"].ToString(), ViewState["DCAA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Drugs Control Administration", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["DCAA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink18.Text = FileUpload28.FileName;
                        Label59.Text = FileUpload28.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button26.Focus();
    }
    protected void Button25_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload27.PostedFile != null) && (FileUpload27.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload27.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload27.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\RegistrationsandStamps");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload27.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload27.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["REGSTAMPD"] != null && ViewState["REGSTAMPA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox17.Text, Session["Applid"].ToString(), ViewState["REGSTAMPD"].ToString(), ViewState["REGSTAMPA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Registrations and Stamps", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["REGSTAMPA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink17.Text = FileUpload27.FileName;
                        Label56.Text = FileUpload27.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button25.Focus();
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload26.PostedFile != null) && (FileUpload26.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload26.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload26.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\Excise Department");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload26.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload26.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["EXCISED"] != null && ViewState["EXCISEA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox16.Text, Session["Applid"].ToString(), ViewState["EXCISED"].ToString(), ViewState["EXCISEA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Excise Department", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["EXCISEA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink16.Text = FileUpload26.FileName;
                        Label53.Text = FileUpload26.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button24.Focus();
    }
    protected void Button23_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload25.PostedFile != null) && (FileUpload25.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload25.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload25.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\HMWSSB");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload25.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload25.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["HMWSSBD"] != null && ViewState["HMWSSBA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox15.Text, Session["Applid"].ToString(), ViewState["HMWSSBD"].ToString(), ViewState["HMWSSBA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "HMWSSB", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["HMWSSBA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink15.Text = FileUpload25.FileName;
                        Label50.Text = FileUpload25.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button23.Focus();
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload24.PostedFile != null) && (FileUpload24.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload24.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload24.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\GroundWater");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload24.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload24.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["GWD"] != null && ViewState["GWA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox14.Text, Session["Applid"].ToString(), ViewState["GWD"].ToString(), ViewState["GWA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Ground Water", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["GWA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink14.Text = FileUpload24.FileName;
                        Label47.Text = FileUpload24.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button22.Focus();
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload23.PostedFile != null) && (FileUpload23.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload23.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload23.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\Fire");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload23.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload23.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["FIRED"] != null && ViewState["FIREA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox13.Text, Session["Applid"].ToString(), ViewState["FIRED"].ToString(), ViewState["FIREA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Fire", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["FIREA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink13.Text = FileUpload23.FileName;
                        Label44.Text = FileUpload23.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button21.Focus();
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload22.PostedFile != null) && (FileUpload22.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload22.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload22.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\DistrictTownandCountryPlanning");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload22.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload22.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["DTCPD"] != null && ViewState["DTCPA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox12.Text, Session["Applid"].ToString(), ViewState["DTCPD"].ToString(), ViewState["DTCPA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "DistrictTownandCountryPlanning", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["DTCPA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink12.Text = FileUpload22.FileName;
                        Label41.Text = FileUpload22.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button20.Focus();
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload21.PostedFile != null) && (FileUpload21.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload21.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload21.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\CCLA");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload21.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload21.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["CCLAD"] != null && ViewState["CCLAA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox11.Text, Session["Applid"].ToString(), ViewState["CCLAD"].ToString(), ViewState["CCLAA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "CCLA", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["CCLAA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink11.Text = FileUpload21.FileName;
                        Label38.Text = FileUpload21.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button19.Focus();
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload20.PostedFile != null) && (FileUpload20.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload20.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload20.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\HMDA");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload20.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload20.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    DataSet ds1 = new DataSet();
                    if (ViewState["HMDAD"] != null && ViewState["HMDAA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox10.Text, Session["Applid"].ToString(), ViewState["HMDAD"].ToString(), ViewState["HMDAA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "HMDA", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["HMDAA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink10.Text = FileUpload20.FileName;
                        Label35.Text = FileUpload20.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button18.Focus();
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload19.PostedFile != null) && (FileUpload19.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload19.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload19.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\Industries");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload19.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload19.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }


                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Industries", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(),"33");
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink9.Text = FileUpload19.FileName;
                        Label32.Text = FileUpload19.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button17.Focus();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload18.PostedFile != null) && (FileUpload18.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload18.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload18.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\Factories");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload18.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload18.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    if (ViewState["FACTD"] != null && ViewState["FACTA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox8.Text, Session["Applid"].ToString(), ViewState["FACTD"].ToString(), ViewState["FACTA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Factories", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["FACTA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink8.Text = FileUpload18.FileName;
                        Label29.Text = FileUpload18.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button16.Focus();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload17.PostedFile != null) && (FileUpload17.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload17.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload17.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\TSSPDCL");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload17.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload17.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    if (ViewState["TSSPDCLD"] != null && ViewState["TSSPDCLA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox7.Text, Session["Applid"].ToString(), ViewState["TSSPDCLD"].ToString(), ViewState["TSSPDCLA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "TSSPDCL", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["TSSPDCLA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink7.Text = FileUpload17.FileName;
                        Label26.Text = FileUpload17.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button15.Focus();
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload16.PostedFile != null) && (FileUpload16.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload16.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload16.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\TSNPDCL");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload16.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload16.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    if (ViewState["TSNPDCLD"] != null && ViewState["TSNPDCLA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox6.Text, Session["Applid"].ToString(), ViewState["TSNPDCLD"].ToString(), ViewState["TSNPDCLA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "TSNPDCL", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["TSNPDCLA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink6.Text = FileUpload16.FileName;
                        Label23.Text = FileUpload16.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button14.Focus();
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload15.PostedFile != null) && (FileUpload15.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload15.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload15.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\ElectricalInspectorate");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    DataSet ds1 = new DataSet();
                    if (ViewState["CEIGD"] != null && ViewState["CEIGA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox5.Text, Session["Applid"].ToString(), ViewState["CEIGD"].ToString(), ViewState["CEIGA"].ToString());
                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Electrical Inspectorate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["CEIGA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink5.Text = FileUpload15.FileName;
                        Label20.Text = FileUpload15.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button13.Focus();
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload14.PostedFile != null) && (FileUpload14.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload14.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload14.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\DISCOM");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload14.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload14.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }


                    DataSet ds1 = new DataSet();
                    if (ViewState["DISCOMD"] != null && ViewState["DISCOMA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox4.Text, Session["Applid"].ToString(), ViewState["DISCOMD"].ToString(), ViewState["DISCOMA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "DISCOM", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["DISCOMA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink4.Text = FileUpload14.FileName;
                        Label17.Text = FileUpload14.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button12.Focus();
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\PanchayatRaj");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    //ViewState["pcbD"] 
                    //ViewState["pcbA"] 
                    //ViewState["TSCTD"] 
                    //ViewState["TSCTA"] 
                    //ViewState["TSIICD"] 
                    //ViewState["TSIICA"] 
                    //ViewState["PRDD"] 
                    //ViewState["PRDA"] 
                    //ViewState["DISCOMD"] 
                    //ViewState["DISCOMA"] 
                    //ViewState["CEIGD"] 
                    //ViewState["CEIGA"] 
                    //ViewState["TSNPDCLD"] 
                    //ViewState["TSNPDCLA"] 
                    //ViewState["TSSPDCLD"] 
                    //ViewState["TSSPDCLA"] 
                    //ViewState["FACTD"] 
                    //ViewState["FACTA"] 
                    //ViewState["HMDAD"] 
                    //ViewState["HMDAA"] 
                    //ViewState["CCLAD"] 
                    //ViewState["CCLAA"] 
                    //ViewState["DTCPD"] 
                    //ViewState["DTCPA"] 
                    //ViewState["FIRED"] 
                    //ViewState["FIREA"] 
                    //ViewState["GWD"] 
                    //ViewState["GWA"] 
                    //ViewState["HMWSSBD"] 
                    //ViewState["HMWSSBA"] 
                    //ViewState["EXCISED"] 
                    //ViewState["EXCISEA"] 
                    //ViewState["REGSTAMPD"] 
                    //ViewState["REGSTAMPA"] 
                    //ViewState["DCAD"] 
                    //ViewState["DCAA"] 
                    //ViewState["IRRIGATIOND"] 
                    //ViewState["IRRIGATIONA"]
                    if (ViewState["PRDD"] != null && ViewState["PRDA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(TextBox3.Text, Session["Applid"].ToString(), ViewState["PRDD"].ToString(), ViewState["PRDA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Panchayat Raj", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["PRDA"].ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HyperLink3.Text = FileUpload13.FileName;
                        Label14.Text = FileUpload13.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
        Button11.Focus();
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }
    //protected void btnnext_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("frmEntrepreneurDetails.aspx");
    //}

    protected void btnnext_Click(object sender, EventArgs e)
    {
        string Message = "";
        if (Panelpcb1.Visible == true && Label453.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload PCB Approval Document";
        }
        if (panelTSCT1.Visible == true && HyperLink1.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Commercial Taxes Approval Document";
        }
        if (panelTSIIC1.Visible == true && HyperLink2.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload TSIIC Approval Document";
        }
        if (panelPRD1.Visible == true && HyperLink3.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Panchayat Raj Approval Document";
        }
        if (panelDISCOM1.Visible == true && HyperLink4.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload DISCOM Approval Document";
        }
        if (panelCEIG1.Visible == true && HyperLink5.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Electrical Inspectorate Approval Document";
        }
        if (panelTSNPDCL1.Visible == true && HyperLink6.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload TSNPDCL Approval Document";
        }
        if (panelTSSPDCL1.Visible == true && HyperLink7.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload TSSPDCL Approval Document";
        }
        if (panelFACT1.Visible == true && HyperLink8.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Factories Approval Document";
        }
        if (panelINDUS1.Visible == true && HyperLink9.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Industries Approval Document";
        }
        if (panelHMDA1.Visible == true && HyperLink10.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload HMDA Approval Document";
        }
        if (panelCCLA1.Visible == true && HyperLink11.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload CCLA Approval Document";
        }
        if (panelDTCP1.Visible == true && HyperLink12.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload District Town and Country Planning Approval Document";
        }
        if (panelFIRE1.Visible == true && HyperLink13.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Fire Approval Document";
        }
        if (panelGW1.Visible == true && HyperLink14.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Ground Water Approval Document";
        }
        if (panelHMWSSB1.Visible == true && HyperLink15.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload HMWSSB Approval Document";
        }
        if (panelEXCISE1.Visible == true && HyperLink16.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Excise Department Approval Document";
        }
        if (panelREGSTAMP1.Visible == true && HyperLink17.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Registrations and Stamps Approval Document";
        }
        if (panelDCA1.Visible == true && HyperLink18.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Drugs Control Administration Approval Document";
        }
        if (panelIRRIGATION1.Visible == true && HyperLink19.Text.Trim() == "")
        {
            Message = Message + "<br/> Please Upload Irrigation Approval Document";
        }

        if (Message == "")
        {
            Response.Redirect("frmEntrepreneurDetails.aspx");
        }
        else
        {
            lblmsg0.Text = "<font color='red'>" + Message + "</font>";
            lblmsg0.Visible = true;
            success.Visible = false;
            Failure.Visible = true;
        }

    }

    protected void btnLegalMetrologyDepartment_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FUtrLegalMetrologyDepartment.PostedFile != null) && (FUtrLegalMetrologyDepartment.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FUtrLegalMetrologyDepartment.PostedFile.FileName);
            try
            {
                string[] fileType = FUtrLegalMetrologyDepartment.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\LGDEPT");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FUtrLegalMetrologyDepartment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FUtrLegalMetrologyDepartment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["LegalMetrologyDepartmentD"] != null && ViewState["LegalMetrologyDepartmentA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtLegalMetrologyDepartment.Text, Session["Applid"].ToString(), ViewState["LegalMetrologyDepartmentD"].ToString(), ViewState["LegalMetrologyDepartmentA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Legal Metrology Department", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["LegalMetrologyDepartmentA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HlptrLegalMetrologyDepartment.Text = FUtrLegalMetrologyDepartment.FileName;
                        lbltrLegalMetrologyDepartment.Text = FUtrLegalMetrologyDepartment.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btnLabourDepartment_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FUptrLabourDepartment.PostedFile != null) && (FUptrLabourDepartment.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FUptrLabourDepartment.PostedFile.FileName);
            try
            {
                string[] fileType = FUptrLabourDepartment.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\LD47");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FUptrLabourDepartment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FUptrLabourDepartment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["LabourDepartment47D"] != null && ViewState["LabourDepartment47A"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtLabourDepartment.Text, Session["Applid"].ToString(), ViewState["LabourDepartment47D"].ToString(), ViewState["LabourDepartment47A"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Labour Department 47", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["LabourDepartment47A"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpLabourDepartment.Text = FUptrLabourDepartment.FileName;
                        lblLabourDepartment.Text = FUptrLabourDepartment.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btnLabourDepartment48_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FUptrLabourDepartment48.PostedFile != null) && (FUptrLabourDepartment48.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FUptrLabourDepartment48.PostedFile.FileName);
            try
            {
                string[] fileType = FUptrLabourDepartment48.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\LD48");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FUptrLabourDepartment48.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FUptrLabourDepartment48.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["LabourDepartment48D"] != null && ViewState["LabourDepartment48A"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtLabourDepartment48.Text, Session["Applid"].ToString(), ViewState["LabourDepartment48D"].ToString(), ViewState["LabourDepartment48A"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Labour Department 48", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["LabourDepartment48A"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpLabourDepartment48.Text = FUptrLabourDepartment48.FileName;
                        lblLabourDepartment48.Text = FUptrLabourDepartment48.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btnLabourDepartment49_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((FUptrLabourDepartment49.PostedFile != null) && (FUptrLabourDepartment49.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FUptrLabourDepartment49.PostedFile.FileName);
            try
            {
                string[] fileType = FUptrLabourDepartment49.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\LD49");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FUptrLabourDepartment49.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FUptrLabourDepartment49.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["LabourDepartment49D"] != null && ViewState["LabourDepartment49A"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtLabourDepartment49.Text, Session["Applid"].ToString(), ViewState["LabourDepartment49D"].ToString(), ViewState["LabourDepartment49A"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Labour Department 49", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["LabourDepartment49A"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpLabourDepartment49.Text = FUptrLabourDepartment49.FileName;
                        lblLabourDepartment49.Text = FUptrLabourDepartment49.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btntrforestdept_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((futrforestdept.PostedFile != null) && (futrforestdept.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(futrforestdept.PostedFile.FileName);
            try
            {
                string[] fileType = futrforestdept.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\FOREST");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        futrforestdept.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            futrforestdept.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["ForestD"] != null && ViewState["ForestA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txttrforestref.Text, Session["Applid"].ToString(), ViewState["ForestD"].ToString(), ViewState["ForestA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "FOREST", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["ForestA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hpltrforestdept.Text = futrforestdept.FileName;
                        lbltrforestdept.Text = futrforestdept.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btntrkuda_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((futrkuda.PostedFile != null) && (futrkuda.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(futrkuda.PostedFile.FileName);
            try
            {
                string[] fileType = futrkuda.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\KUDA");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        futrkuda.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            futrkuda.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["KudaD"] != null && ViewState["KudaA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txttrKUDAref.Text, Session["Applid"].ToString(), ViewState["KudaD"].ToString(), ViewState["KudaA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "KUDA", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["KudaA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hlptrkuda.Text = futrkuda.FileName;
                        lbltrkuda.Text = futrkuda.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btntrcess_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((futrcess.PostedFile != null) && (futrcess.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(futrcess.PostedFile.FileName);
            try
            {
                string[] fileType = futrcess.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\CESS-Sircilla");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        futrcess.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            futrcess.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["CessD"] != null && ViewState["CessA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txttrcess.Text, Session["Applid"].ToString(), ViewState["CessD"].ToString(), ViewState["CessA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "CESS-Sircilla", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["CessA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hpltrcess.Text = futrcess.FileName;
                        lbltrcess.Text = futrcess.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btnTrExplosiveLicenser_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((fuTrExplosiveLicenser.PostedFile != null) && (fuTrExplosiveLicenser.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fuTrExplosiveLicenser.PostedFile.FileName);
            try
            {
                string[] fileType = fuTrExplosiveLicenser.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\NOCforExplosiveLicense");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fuTrExplosiveLicenser.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fuTrExplosiveLicenser.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["NOCforExplosiveLicenseD"] != null && ViewState["NOCforExplosiveLicenseA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txtTrExplosiveLicense.Text, Session["Applid"].ToString(), ViewState["NOCforExplosiveLicenseD"].ToString(), ViewState["NOCforExplosiveLicenseA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "NOC for Explosive License", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["NOCforExplosiveLicenseA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hlpTrExplosiveLicenser.Text = fuTrExplosiveLicenser.FileName;
                        lblTrExplosiveLicenser.Text = fuTrExplosiveLicenser.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void btntrFTLRevenue_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\OfflineApprovals");

        General t1 = new General();
        if ((futrFTLRevenue.PostedFile != null) && (futrFTLRevenue.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(futrFTLRevenue.PostedFile.FileName);
            try
            {
                string[] fileType = futrFTLRevenue.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfID.Value + "\\FTLNocforChangeofLandUseRevenue");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        futrFTLRevenue.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            futrFTLRevenue.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    DataSet ds1 = new DataSet();
                    int n1 = 0;
                    if (ViewState["FTLNocforChangeofLandUseRevenueD"] != null && ViewState["FTLNocforChangeofLandUseRevenueA"] != null)
                        n1 = Gen.UpdateRefferenceNumber(txttrFTLRevenue.Text, Session["Applid"].ToString(), ViewState["FTLNocforChangeofLandUseRevenueD"].ToString(), ViewState["FTLNocforChangeofLandUseRevenueA"].ToString());

                    int result = 0;
                    result = t1.InsertImagedataOfflineApprovals(Session["Applid"].ToString(), hdfID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "FTL Noc for Change of Land Use Revenue", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ViewState["FTLNocforChangeofLandUseRevenueA"].ToString());
                    if (result > 0 && n1 == 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hptrFTLRevenue.Text = futrFTLRevenue.FileName;
                        lbltrFTLRevenue.Text = futrFTLRevenue.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtmarketvalue.Text) <= 0)
        {
            string message = "alert('Land Market Value Shloud not be Zero')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            lblmsg0.Text = "Land Market Value Shloud not be Zero";
            Failure.Visible = true;
            success.Visible = false;
            return;
        }

        if (txtmarketvalue.Text.Trim().TrimStart().TrimEnd() != "" && txtmarketvalue.Text.Trim().TrimStart().TrimEnd() != "0")
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                // string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                //string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();
                string statusv = CheckNalaValue(HdfQueid, "34", txtmarketvalue.Text.Trim().TrimStart().TrimEnd(), "UPD");
                if (statusv == "DONE")
                {
                    string message = "alert('Land Market Value Updated Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                Response.Redirect("frmDepartmentApprovalDetails.aspx");
            }
        }
        // Response.Redirect();
    }
    public string CheckNalaValue(string intQuessionaireid, string intApprovalid, string NalaValu, string Checktype)
    {
        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intQuessionaireid",SqlDbType.VarChar),
               new SqlParameter("@intApprovalid",SqlDbType.VarChar),
               new SqlParameter("@NalaValu",SqlDbType.VarChar),
               new SqlParameter("@Checktype",SqlDbType.VarChar),
               new SqlParameter("@Outresponse",SqlDbType.VarChar)
           };
        pp[0].Value = intQuessionaireid;
        pp[1].Value = intApprovalid;
        pp[2].Value = NalaValu;
        pp[3].Value = Checktype;
        pp[4].Value = "0";
        pp[4].Size = 1000;
        pp[4].Direction = ParameterDirection.Output;

        Gen.GenericFillDs("USP_GET_NALAVALUE", pp);
        string value = pp[4].Value.ToString();
        return value;
    }
}
