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
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BusinessLogic;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using Org.BouncyCastle.Crypto.Tls;

public partial class UI_TSiPASS_AgreementBondUploadEnterpriseChanges : System.Web.UI.Page
{
    General gen = new General();
    comFunctions cmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string linkfile = "";
    string incid, mstid;
    static DataTable dtMyTable = new DataTable();
    static DataTable dtMyTable1 = new DataTable();
    string checks = "N";
    //dtMyTable1
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTableCertificate = new DataTable();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            DataSet dsData = new DataSet();
            string incentiveid = "", MstIncentiveId = "";
            if (Request.QueryString.Count > 0 && Request.QueryString[0].ToString() != null && Request.QueryString[0].ToString() != "")
            {
                incentiveid = Request.QueryString[0].ToString();
                ViewState["incentiveid"] = incentiveid;
            }
            if (Request.QueryString.Count > 1 && Request.QueryString[1].ToString() != null && Request.QueryString[1].ToString() != "")
            {
                MstIncentiveId = Request.QueryString[1].ToString();
                ViewState["MstIncentiveId"] = MstIncentiveId;
            }
            incid = ViewState["incentiveid"].ToString();
            mstid = ViewState["MstIncentiveId"].ToString();

            hdfFlagID.Value = incid;
            hdfID.Value = mstid;
            ds = gen.GetAgreementUploadedFlag(incentiveid, MstIncentiveId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string UPLOADSREQ_FLAG = ds.Tables[0].Rows[0]["UPLOADSREQ_FLAG"].ToString();
                string SCHEME_NAMAE = ds.Tables[0].Rows[0]["SCHEMENME"].ToString();
                string allUploadFlag = ds.Tables[0].Rows[0]["allUploadFlag"].ToString();
                string incenid = ds.Tables[0].Rows[0]["IncentveID"].ToString();
                incid = incenid;
                ViewState["incentiveid"] = incenid;

                //if (UPLOADSREQ_FLAG == "Y")
                //{
                // divSecond.Visible = false;
                divFirst.Visible = true;
                fucAgreementBond.Enabled = true;
                fucAssignment.Enabled = true;
                hplFilenameLink.Visible = true;
                if (SCHEME_NAMAE.Contains("IIPP"))
                    hplFilenameLink.NavigateUrl = "viewpdf.aspx?filepathnew=D:/TS-iPASSFinal//docs/ReleaseAttachments/IIPP_2010_2015_AGR_BOND.pdf";
                if (SCHEME_NAMAE.Contains("IDEA"))
                    hplFilenameLink.NavigateUrl = "viewpdf.aspx?filepathnew=D:/TS-iPASSFinal//docs/ReleaseAttachments/T_IDEA_2015-19_AGR_BOND.pdf";
                if (SCHEME_NAMAE.Contains("PRIDE"))
                    hplFilenameLink.NavigateUrl = "viewpdf.aspx?filepathnew=D:/TS-iPASSFinal//docs/ReleaseAttachments/T_PRIDE_2015-19_AGR_BOND.pdf";

                //}
                //else if (UPLOADSREQ_FLAG == "N")
                //{
                chkAbideTr.Visible = true;
                divAbide.Visible = true;
                //chkAbide.Checked = true;
                //chkAbide.Enabled = false;
                DataSet oDataSet = new DataSet();
                //oDataSet = gen.GetAgreementAttachmetsData(incentiveid);

                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
                //if (Request.QueryString["code"] != null)



                oSqlDataAdapter = new SqlDataAdapter("sp_GetattachmentAgreement_testing", osqlConnection);
                oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                oSqlDataAdapter.SelectCommand.Parameters.Add("@incId", SqlDbType.VarChar).Value = incid;
                oSqlDataAdapter.SelectCommand.Parameters.Add("@mstid", SqlDbType.VarChar).Value = mstid;
                //incid = ViewState["incentiveid"].ToString();
                //mstid = ViewState["MstIncentiveId"].ToString();

                //oSqlDataAdapter.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
                oSqlDataAdapter.Fill(oDataSet);
                string sen, sen1, sen2, senPlanB, sennew;
                int c = oDataSet.Tables[0].Rows.Count;
                int i = 0;
                while (i < c)
                {
                    senPlanB = oDataSet.Tables[0].Rows[i][1].ToString();
                    sen2 = oDataSet.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = oDataSet.Tables[0].Rows[i]["LINKNEW"].ToString();
                    string encpassword = gen.Encrypt(sennew, "SYSTIME");

                    if (sen.Contains("AgreementBond"))
                    {
                        lblFileName.Visible = true;
                        //lblFileName.NavigateUrl = sen;
                        lblFileName.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblFileName.Text = "Agreement Bond Copy";
                        bntUpload.Visible = false;
                        fucAgreementBond.Enabled = false;



                    }
                    if (sen.Contains("AssignmentLetter"))
                    {
                        lnkAssignmentLetter.Visible = true;
                        //lnkAssignmentLetter.NavigateUrl = sen;
                        lnkAssignmentLetter.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lnkAssignmentLetter.Text = "Assignment Letter";
                        btnUploadAssignmentLetter.Visible = false;
                        fucAssignment.Enabled = false;

                    }

                    i++;
                }
                //if (allUploadFlag == "")
                //{
                //    fucAgreementBond.Enabled = true;
                //    fucAssignment.Enabled = true;
                //    bntUpload.Visible = true;
                //    btnUploadAssignmentLetter.Visible = true;
                //}
                if (oDataSet.Tables[1].Rows.Count > 0)
                {
                    chkAbide.Checked = true;
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["BankChange_Flag"]) == "Y")
                    {
                        chkBankChange.Checked = true;
                        trBankDtls.Visible = true;
                        ddlBank.SelectedValue = Convert.ToString(oDataSet.Tables[1].Rows[0]["Bank_Name"]);
                        txtBranchName.Text= Convert.ToString(oDataSet.Tables[1].Rows[0]["Branch_Name"]);
                        txtAccNumber.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["AccountNo"]);
                        txtIfscCode.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["IFSC_Cd"]);
                        ddlaccounttype.SelectedValue = Convert.ToString(oDataSet.Tables[1].Rows[0]["Account_Type"]);
                        txtremarks.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Bank_Remarks"]);
                    }
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["ManageChange_Flag"]) == "Y")
                    {
                        chkManagementChange.Checked = true;
                        trManagementDtls.Visible = true;
                        txtManagement.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["ManageChange"]);
                        txtINCPartner.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["directorAdded"]);
                    }
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["Break_Flag"] )== "Y")
                    {
                        chkBreakProd.Checked = true;
                        trBreakDtls.Visible = true;
                        txtBreakFromDate0.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Break_FromDt"]);
                        //Sickness	Distrctcd	MandalCd	VillageCd	LOA	Other_remarks
                    }
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["Sick_Flag"]) == "Y")
                    {
                        chkSickness.Checked = true;
                        trSicknessDtls.Visible = true;
                        txtSickness.Text = Convert.ToString(oDataSet.Tables[1].Rows[0]["Sickness"]);
                    }
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["LocChange_Flag"]) == "Y")
                    {
                        chkLocationChange.Checked = true;
                    }
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["LOAChange_Flag"]) == "Y")
                    {
                        chkLOAChange.Checked = true;
                        loatr.Visible = true;
                        gvCertificate.DataSource = oDataSet.Tables[1];
                        gvCertificate.DataBind();
                    }
                    if (Convert.ToString(oDataSet.Tables[1].Rows[0]["OthersChange_Flag"]) == "Y")
                    {
                        chkOther.Checked = true;
                        trOtherReasons.Visible = true;
                        txtOtherReasons.Text= Convert.ToString(oDataSet.Tables[1].Rows[0]["Other_remarks"]);
                    }

                }

                //fucAgreementBond.Enabled = false;
                //fucAssignment.Enabled = false;
                if (allUploadFlag != "Y")
                {
                    divSecond.Visible = true;
                    btnSave.Enabled = true;
                    btnSave.Visible = true;
                    bntUpload.Visible = true;
                    fucAgreementBond.Enabled = true;
                    btnUploadAssignmentLetter.Visible = true;
                    fucAssignment.Enabled = true;
                }

                else if (allUploadFlag == "Y")
                {
                    divSecond.Visible = false;
                    btnSave.Enabled = false;
                    btnSave.Visible = false;
                    divAbide.Visible = false;
                    divmatter.Visible = false;
                }
                chkAbideTr.Visible = true;
               
                //}
                //else
                //{
                //    chkAbideTr.Visible = true;
                //    divAbide.Visible = true;
                //}
            }


        }
    }



    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");
        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("incid", typeof(string));
        dtMyTable.Columns.Add("mstid", typeof(string));
        dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
        dtMyTable.Columns.Add("OtherItemName", typeof(string));
        dtMyTable.Columns.Add("Created_by", typeof(string));
        dtMyTable.Columns.Add("Created_dt", typeof(string));
        return dtMyTable;
    }
    private void AddDataToTableCeertificate(string incid, string mstid, string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, string Manf_Item_Quantity_Per, string OtherItemName, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();
            dtMyTable = new DataTable("CertificateTb2");
            Row["new"] = "0";
            Row["incid"] = incid;
            Row["mstid"] = mstid;
            Row["Manf_ItemName"] = Manf_ItemName;
            Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
            Row["OtherItemName"] = OtherItemName;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            Row["Created_dt"] = DateTime.Now.ToShortDateString();

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {

        }
    }
    private void AddDataToTableCeertificate1(string intQuessionaireid, string intCFEEnterpid, string Raw_ItemName, string Raw_Item_Quantity, string Raw_Item_Quantity_In, string Raw_Item_Quantity_Per, string OtherItemName, DataTable myTable1)
    {
        try
        {
            DataRow Row;
            Row = myTable1.NewRow();
            dtMyTable1 = new DataTable("CertificateTb1");
            Row["new"] = "0";
            Row["incid"] = incid;
            Row["mstid"] = mstid;
            Row["Raw_ItemName"] = Raw_ItemName;
            Row["Raw_Item_Quantity"] = Raw_Item_Quantity;
            Row["Raw_Item_Quantity_In"] = Raw_Item_Quantity_In;
            Row["Raw_Item_Quantity_Per"] = Raw_Item_Quantity_Per;
            Row["OtherItemName"] = OtherItemName;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            myTable1.Rows.Add(Row);
        }
        catch (Exception ee)
        {
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        if (BtnSave1.Text == "Save")
        {
            lblmsg.Text = "";
            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details and Click add new Button </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
            {
                GetNewRectoInsertdr();
                int statuspr = bulkInsertmanufacture(myDtNewRecdr);
                if (statuspr == 1)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Saved successfully!";
                }
                if (statuspr == 0)
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Failed. Pl enter all the details correctly!";
                }
            }
        }
    }

    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        myDtNewRecdr = dvdr.ToTable();

    }

    protected void BtnClear0_Click2(object sender, EventArgs e)
    {
        txtitem.Text = "";
        txtquantity.Text = "";
        ddlquantityin.SelectedIndex = 0;
        ddlQuantityper1.SelectedIndex = 0;

    }
    protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquantityin.SelectedValue.ToString() == "Others")
        {
            qty.Visible = true;

        }
        else
        {
            qty.Visible = false;

        }

    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        gvCertificate.Visible = true;
        try
        {
            if (txtitem.Text != "")
            {

                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
                incid = ViewState["incentiveid"].ToString();
                mstid = ViewState["MstIncentiveId"].ToString();
                AddDataToTableCeertificate(incid, mstid, txtitem.Text, txtquantity.Text, ddlquantityin.SelectedValue.ToString(), ddlQuantityper1.SelectedValue.ToString(), txtitem2.Text, (DataTable)Session["CertificateTb2"]);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;
                gvCertificate.Columns[6].Visible = false;
                lblmsg.Text = "";
                txtitem.Text = "";
                txtquantity.Text = "";
                ddlquantityin.SelectedIndex = 0;
                ddlQuantityper1.SelectedValue = ddlQuantityper1.SelectedValue;
                txtitem2.Text = "";

            }

        }

        catch (Exception ee)
        {

        }

        gvCertificate.Visible = true;

    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
            }
            else
            {
                if (hdfFlagID.Value.Trim() != "")
                {

                    try
                    {
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["incid"].ToString();

                        DataSet dsna = new DataSet();
                        int i1 = DeletebyManufactureid(traineetradesnames);

                        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //}

                    }
                    catch (Exception eee)
                    { }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";

        }
        finally
        {
        }


    }
    public int bulkInsertmanufacture(DataTable dt)
    {
        osqlConnection.Open();

        int i = 0;

        try
        {

            SqlBulkCopy bulkCopy = new SqlBulkCopy(osqlConnection);
            SqlBulkCopyColumnMapping mapping1 = new SqlBulkCopyColumnMapping("incid", "incid");
            SqlBulkCopyColumnMapping mapping2 = new SqlBulkCopyColumnMapping("mstid", "mstid");
            SqlBulkCopyColumnMapping mapping3 = new SqlBulkCopyColumnMapping("Manf_ItemName", "Manf_ItemName");
            SqlBulkCopyColumnMapping mapping4 = new SqlBulkCopyColumnMapping("Manf_Item_Quantity", "Manf_Item_Quantity");
            SqlBulkCopyColumnMapping mapping5 = new SqlBulkCopyColumnMapping("Manf_Item_Quantity_In", "Manf_Item_Quantity_In");
            SqlBulkCopyColumnMapping mapping6 = new SqlBulkCopyColumnMapping("Manf_Item_Quantity_Per", "Manf_Item_Quantity_Per");
            SqlBulkCopyColumnMapping mapping7 = new SqlBulkCopyColumnMapping("OtherItemName", "OtherItemName");
            SqlBulkCopyColumnMapping mapping8 = new SqlBulkCopyColumnMapping("Created_by", "Created_by");
            SqlBulkCopyColumnMapping mapping9 = new SqlBulkCopyColumnMapping("Created_dt", "Created_dt");

            bulkCopy.ColumnMappings.Add(mapping1);
            bulkCopy.ColumnMappings.Add(mapping2);
            bulkCopy.ColumnMappings.Add(mapping3);
            bulkCopy.ColumnMappings.Add(mapping4);
            bulkCopy.ColumnMappings.Add(mapping5);
            bulkCopy.ColumnMappings.Add(mapping6);
            bulkCopy.ColumnMappings.Add(mapping7);
            bulkCopy.ColumnMappings.Add(mapping8);
            bulkCopy.ColumnMappings.Add(mapping9);

            bulkCopy.DestinationTableName = ("td_LineofActivity_ReleaseUpdate");
            bulkCopy.WriteToServer(dt);
            checks = "Y";
            i = 1;

        }
        catch (Exception ex)
        {
            i = 0;
            checks = "N";
        }
        finally
        {
            osqlConnection.Close();
        }

        return i;


    }
    public int DeletebyManufactureid(string id)
    {

        osqlConnection.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DeleteManufacturebyEnterPrenuer_ReleaseINC";

        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;


        cmd.Connection = osqlConnection;

        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            return 0;
        }
        finally
        {
            cmd.Dispose();
            osqlConnection.Close();

        }
    }


    protected void chkBankChange_CheckedChanged(object sender, EventArgs e)
    {
        if (chkBankChange.Checked == true)
        {
            trBankDtls.Visible = true;
            cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
        }
        else
        {
            trBankDtls.Visible = false;
        }
    }

    protected void chkManagementChange_CheckedChanged(object sender, EventArgs e)
    {
        if (chkManagementChange.Checked == true)
        {
            trManagementDtls.Visible = true;
        }
        else
        {
            trManagementDtls.Visible = false;
        }
    }

    protected void chkBreakProd_CheckedChanged(object sender, EventArgs e)
    {
        if (chkBreakProd.Checked == true)
        {
            trBreakDtls.Visible = true;
        }
        else
        {
            trBreakDtls.Visible = false;
        }
    }

    protected void chkSickness_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSickness.Checked == true)
        {
            trSicknessDtls.Visible = true;
        }
        else
        {
            trSicknessDtls.Visible = false;
        }
    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //hdnfldtsiic.Value = "";
            //ddlLoc_of_unit.Items.Clear();
            //ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");

                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");

                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
                    ddlProp_intMandalid.DataTextField = "Manda_lName";
                    ddlProp_intMandalid.DataBind();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
            }
            //hdnfocus.Value = ddlProp_intDistrictid.ClientID;
            //if (rdIaLa_Lst.SelectedValue == "Y") //lavanya
            //{
            //    BindIndustrialParks();
            //} 
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ddlLoc_of_unit.Items.Clear();
            //ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            if (ddlProp_intMandalid.SelectedIndex == 0)
            {
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = gen.GetVillages(ddlProp_intMandalid.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intVillageid.DataSource = dsv.Tables[0];
                    ddlProp_intVillageid.DataValueField = "Village_Id";
                    ddlProp_intVillageid.DataTextField = "Village_Name";
                    ddlProp_intVillageid.DataBind();
                    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlProp_intVillageid.Items.Clear();
                    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                }
                #region commented by lavanya . need to show based on village master

                #endregion
            }

            // hdnfocus.Value = ddlProp_intMandalid.ClientID;
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void chkLocationChange_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLocationChange.Checked == true)
        {
            trLocation.Visible = true;
            BindDistricts();
        }
        else
        {
            trLocation.Visible = false;
        }
    }

    protected void chkLOAChange_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLOAChange.Checked == true)
        {
            loatr.Visible = true;
            loaSaveButton.Visible = true;
            trLOA.Visible = true;
        }
        else
        {
            loatr.Visible = false;
            loaSaveButton.Visible = false;
            trLOA.Visible = false;
        }
    }

    protected void chkOther_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOther.Checked == true)
        {
            trOtherReasons.Visible = true;
        }
        else
        {
            trOtherReasons.Visible = false;
        }
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
    protected void btnUploadAssignmentLetter_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fucAssignment.HasFile)
        {
            //string incentiveid = ((Label)grdDetails.Rows[0].FindControl("lblEnterperIncentiveID")).Text;// Session["EntprIncentive"].ToString();
            //string masterincentiveid = ((Label)grdDetails.Rows[0].FindControl("lblIncentiveID")).Text;
            string incentiveid = "";
            string MstIncentiveId = "";
            if (ViewState["incentiveid"] != null && ViewState["incentiveid"].ToString() != "")
            {
                incentiveid = ViewState["incentiveid"].ToString();
            }
            if (ViewState["MstIncentiveId"] != null && ViewState["MstIncentiveId"].ToString() != "")
            {
                MstIncentiveId = ViewState["MstIncentiveId"].ToString();
            }
            if ((fucAssignment.PostedFile != null) && (fucAssignment.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fucAssignment.PostedFile.FileName);
                try
                {
                    string[] fileType = fucAssignment.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                        //string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];//"~\\IncentivesAttachmentsNew\\"
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\" + MstIncentiveId.ToString() + "\\AssignmentLetter");
                        string serverpath = System.IO.Path.Combine(sFileDir, incentiveid.ToString() + "\\" + MstIncentiveId.ToString() + "\\AssignmentLetter");
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fucAssignment.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, MstIncentiveId, "100025", sFileName, serverpath, CrtdUser);

                        lnkAssignmentLetter.NavigateUrl = serverpath + sFileName;
                        lnkAssignmentLetter.Text = sFileName;
                        lnkAssignmentLetter.Visible = true;
                        success.Visible = true;
                        Failure.Visible = false;
                        // troptpbutton.Visible = true;
                    }
                    else
                    {
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    protected void bntUploadAgreement_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fucAgreementBond.HasFile)
        {
            //string incentiveid = ((Label)grdDetails.Rows[0].FindControl("lblEnterperIncentiveID")).Text;// Session["EntprIncentive"].ToString();
            //string masterincentiveid = ((Label)grdDetails.Rows[0].FindControl("lblIncentiveID")).Text;
            string incentiveid = "";
            string MstIncentiveId = "";
            if (ViewState["incentiveid"] != null && ViewState["incentiveid"].ToString() != "")
            {
                incentiveid = ViewState["incentiveid"].ToString();
            }
            if (ViewState["MstIncentiveId"] != null && ViewState["MstIncentiveId"].ToString() != "")
            {
                MstIncentiveId = ViewState["MstIncentiveId"].ToString();
            }
            if ((fucAgreementBond.PostedFile != null) && (fucAgreementBond.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fucAgreementBond.PostedFile.FileName);
                try
                {
                    string[] fileType = fucAgreementBond.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\" + MstIncentiveId.ToString() + "\\AgreementBond");
                        string serverpath = System.IO.Path.Combine(sFileDir, incentiveid.ToString() + "\\" + MstIncentiveId.ToString() + "\\AgreementBond");
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fucAgreementBond.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, MstIncentiveId, "100024", sFileName, serverpath, CrtdUser);

                        lblFileName.NavigateUrl = serverpath + sFileName;
                        lblFileName.Text = sFileName;
                        lblFileName.Visible = true;
                        success.Visible = true;
                        Failure.Visible = false;
                        // troptpbutton.Visible = true;
                    }
                    else
                    {
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    public string ValidationBeforeSave()
    {
        string Msg = "";
        if (chkAbide.Checked == false && divSecond.Visible == true)
        {
            Msg = "Please select abide by the condition and then click on submit";

        }
        if (lnkAssignmentLetter.Text == "" || lblFileName.Text == "")
        {
            Msg = "Please upload Agreement bond copy and Assignment letter";
        }

        if (divSecond.Visible == true)
        {

            if (chkBankChange.Checked == true && (txtAccNumber.Text == "" || txtBranchName.Text == "" || txtIfscCode.Text == "" || (ddlaccounttype.SelectedIndex == 0) || txtremarks.Text == ""))
            {
                Msg = "Please Enter bank details";

            }
            if (chkManagementChange.Checked == true && (txtManagement.Text == ""))
            {
                Msg = "Please Enter Change of Management by the Enterprise";

            }
            if (chkBreakProd.Checked == true && (txtBreakFromDate.Text == ""))
            {
                Msg = "Please Enter Break in Production Date";

            }
            if (chkSickness.Checked == true && (txtSickness.Text == ""))
            {
                Msg = "Please Enter Closure / Sickness of the unit found";

            }
            if (chkLocationChange.Checked == true && (ddlProp_intDistrictid.SelectedIndex == 0 || ddlProp_intMandalid.SelectedIndex == 0 || ddlProp_intVillageid.SelectedIndex == 0))
            {
                Msg = "Please Enter Change in location of the Unit";

            }
            if (chkLOAChange.Checked == true && (gvCertificate.Rows.Count == 0))
            {
                Msg = "Please Enter Line of activity details.";

            }
            if (chkOther.Checked == true && (txtOtherReasons.Text == ""))
            {
                Msg = "Please Enter Any other specific reasons not worthy of receiving incentives Enterprise";

            }


        }
        //if (Msg != "")
        //{
        //    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Msg + "');", true);

        //}


        return Msg;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            UnitLatest unitLatest = new UnitLatest();
            string Message = "";
            Message = ValidationBeforeSave();
            if (Message != "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "');", true);
                return;
            }

            string incentiveid = "";
            string MstIncentiveId = "";

            if (ViewState["incentiveid"] != null && ViewState["incentiveid"].ToString() != "")
            {
                incentiveid = ViewState["incentiveid"].ToString();
            }
            if (ViewState["MstIncentiveId"] != null && ViewState["MstIncentiveId"].ToString() != "")
            {
                MstIncentiveId = ViewState["MstIncentiveId"].ToString();
            }
            unitLatest.IncentiveId = incentiveid;
            unitLatest.MstIncentiveID = MstIncentiveId;

            if (chkBankChange.Checked == true)
            {
                unitLatest.BankChange_Flag = "Y";

                unitLatest.Bank_Name = ddlBank.SelectedValue;
                unitLatest.Branch_Name = txtBranchName.Text.Trim();
                unitLatest.AccountNo = txtAccNumber.Text.Trim();
                unitLatest.IFSC_Cd = txtIfscCode.Text.Trim();
                unitLatest.Account_Type = ddlaccounttype.SelectedValue;
                unitLatest.Bank_Remarks = txtremarks.Text.Trim();
            }
            else
            {
                unitLatest.BankChange_Flag = "N";
            }
            if (chkManagementChange.Checked == true)
            {
                unitLatest.ManageChange_Flag = "Y";
                unitLatest.directorDropped = txtManagement.Text.Trim();
                unitLatest.directorAdded = txtINCPartner.Text.Trim();
            }
            else
            {
                unitLatest.ManageChange_Flag = "N";
            }
            if (chkBreakProd.Checked == true)
            {
                unitLatest.Break_Flag = "Y";
                unitLatest.Break_FromDt = txtBreakFromDate.Text;
                unitLatest.Break_ToDt = txtBreakFromDate0.Text;
            }
            else
            {
                unitLatest.Break_Flag = "N";
            }
            if (chkSickness.Checked == true)
            {
                unitLatest.Sick_Flag = "Y";
                unitLatest.Sickness = txtSickness.Text.Trim();
            }
            else
            {
                unitLatest.Sick_Flag = "N";
            }
            if (chkLocationChange.Checked == true)
            {
                unitLatest.LocChange_Flag = "Y";
                unitLatest.Distrctcd = ddlProp_intDistrictid.SelectedValue;
                unitLatest.MandalCd = ddlProp_intMandalid.SelectedValue;
                unitLatest.VillageCd = ddlProp_intVillageid.SelectedValue;
            }
            else
            {
                unitLatest.LocChange_Flag = "N";
            }
            if (chkLOAChange.Checked == true)
            {
                unitLatest.LOAChange_Flag = "Y";

            }
            else
            {
                unitLatest.LOAChange_Flag = "N";
            }
            if (chkOther.Checked == true)
            {
                unitLatest.OthersChange_Flag = "Y";
                unitLatest.Other_remarks = txtOtherReasons.Text.Trim();
            }
            else
            {
                unitLatest.OthersChange_Flag = "N";
            }
            unitLatest.CrtdUser = Session["uid"].ToString();
            unitLatest.AgreementBond = lblFileName.NavigateUrl;
            unitLatest.AssignmentLetter = lnkAssignmentLetter.NavigateUrl;
            int i = gen.InsertUnitLatestDetails(unitLatest, "");
            if (i == 0)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Latest Details of the Unit Submitted";
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg.Text = "Failed";
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


}