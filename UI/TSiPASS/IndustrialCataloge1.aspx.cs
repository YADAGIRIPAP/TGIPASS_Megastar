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
    General Gen = new General();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;


    protected void Page_Load(object sender, EventArgs e)
    {

        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {

            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}

            BindDistrictsGrid();
            for (int i = 1990; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add((new ListItem(i.ToString(), i.ToString())));
            }

            string year = "";
            year = System.DateTime.Now.Year.ToString();

           // ddlYear.SelectedValue =  ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;

            // ddlYear.SelectedItem.Text = year.ToString();
            ddlYear.Enabled = false;
            string month = "";
            month = (System.DateTime.Now.Month-1).ToString();
           // ddlMonth.SelectedValue =  ddlMonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
            if ((System.DateTime.Now.Month) == 1)
            {
                ddlMonth.SelectedValue = "12";
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.SelectedValue = ddlYear.Items.FindByValue((System.DateTime.Now.Year - 1).ToString()).Value;
            }
            else
            {
                ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
                ddlYear.Enabled = false;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
                ddlMonth.Enabled = false;

            }

            ddlMonth.Enabled = false;

            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                
                ddlUnitDIst1.SelectedValue = ddlUnitDIst1.Items.FindByValue(Session["DistrictID"].ToString().Trim()).Value;
                ddlUnitDIst1_SelectedIndexChanged(sender, e);
                ddlUnitDIst1.Enabled = false;
            }

            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb11"] = dtMyTableCertificate;

            dtMyTableCertificate1 = createtablecrtificate1();
            Session["CertificateTb1"] = dtMyTableCertificate1;


            DataSet ds = Gen.getIndustryCatelogLookUp(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdfID.Value = ds.Tables[0].Rows[0]["intIndustrialCatalogueid"].ToString();
                FillDetails();
                BtnSave1.Text = "Update";
            }
            else
            {
                lblmsg1.Text = "0";
            }


            //DataSet ds1 = new DataSet();

            //ds1 = Gen.GetInitialCatelogTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

            //if (ds1.Tables[0].Rows.Count > 0)
            //{

            //    Label435.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
            //    lblmsg2.Text = ds1.Tables[0].Rows[0]["Target"].ToString();


            //}
            //else
            //{
            //    lblmsg2.Text = "0";
            //}


            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            AddSelect(ddlintLineofActivity);
            //ddlintLineofActivity.Items.Insert(0, "--Select--");



            //DataSet dscheck1 = new DataSet();
            //dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            //if (dscheck1.Tables[0].Rows.Count > 0)
            //{
            //    Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["ApplidA"] = "0";
            //}





        }

        //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        //{
        //    success.Visible = false;
        //    Failure.Visible = false;

        //    FillDetails();

        //    BtnSave1.Text = "Update";
        //}
    }


    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb11");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intIPOid", typeof(string));
        dtMyTable.Columns.Add("intIndustrialCatalogueid", typeof(string));
        dtMyTable.Columns.Add("NameofUnit", typeof(string));
        dtMyTable.Columns.Add("AddressofUnit", typeof(string));
        dtMyTable.Columns.Add("intLineofActivityid", typeof(string));
        dtMyTable.Columns.Add("DateofVisited", typeof(string));
        dtMyTable.Columns.Add("CurrentStatus", typeof(string));

        dtMyTable.Columns.Add("Remarks", typeof(string));
        dtMyTable.Columns.Add("Created_by", typeof(string));
        dtMyTable.Columns.Add("LineofActivityName", typeof(string));

        dtMyTable.Columns.Add("intTrIndustrialCatalogueid", typeof(string));
        dtMyTable.Columns.Add("FilePath", typeof(string));
        dtMyTable.Columns.Add("MandalId", typeof(string));
        dtMyTable.Columns.Add("DistrictId", typeof(string));
        dtMyTable.Columns.Add("VillageId", typeof(string));
        dtMyTable.Columns.Add("DistricName", typeof(string));
        dtMyTable.Columns.Add("MandalName", typeof(string));
        dtMyTable.Columns.Add("VillageName", typeof(string));

        dtMyTable.Columns.Add("WhetherYorN", typeof(string));
        dtMyTable.Columns.Add("NoofMandalsgrid", typeof(string));

        return dtMyTable;
    }

    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");

        dtMyTable1.Columns.Add("new", typeof(string));
        dtMyTable1.Columns.Add("intQuessionaireCFOid", typeof(string));
        dtMyTable1.Columns.Add("intCFOEnterpid", typeof(string));
        dtMyTable1.Columns.Add("Raw_ItemName", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity_In", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity_Per", typeof(string));
        dtMyTable1.Columns.Add("Created_by", typeof(string));
        dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


        return dtMyTable1;
    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }


        if (BtnSave1.Text == "Update")
        {
            lblmsg.Text = "";





            if (((DataTable)Session["CertificateTb11"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0 || ((DataTable)Session["CertificateTb11"]).Rows.Count < Convert.ToInt32(txtNoofUnit.Text))
            {
                string message = "alert(' Please Enter ALL the No.of Units Captured	 Details and proceed...!!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = "<font color=red> Please Enter ALL the No.of Units Captured	 Details and Click Add New Button. </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }


            //if ((((DataTable)Session["CertificateTb11"]).Rows.Count > Convert.ToInt32(lblmsg2.Text)) || (gvCertificate.Rows.Count > Convert.ToInt32(lblmsg2.Text)))
            //{

            //    lblmsg0.Text = "<font color=red> Industry Catelouge Details not registered  More than Target</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}



            int i = 0;

            i = Gen.insertIndustryCatelog(hdfID.Value.ToString(), Session["uid"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), txtresMandals.Text, Label435.Text);//txtresMandals.Text,


            if (i != 999)
            {



                int j = Gen.deleteInitialCatelog(hdfID.Value.ToString());

                if (((DataTable)Session["CertificateTb11"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb11"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb11"]).Rows[m]["intTrIndustrialCatalogueid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb11"]).Rows[m]["intIndustrialCatalogueid"] = Convert.ToString(hdfID.Value.ToString());
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInitialCatelog(myDtNewRecdr);

                    if (statuspr > 0)
                    {
                        string message = "alert('Updated Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        lblmsg.Text = "Updated Successfully";

                        success.Visible = true;
                        Failure.Visible = false;
                        gvCertificate.DataSource = null;
                        gvCertificate.DataBind();

                    }
                    else
                    {
                        string message = "alert('Not Updated Please Try Again')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                       // lblmsg.Text = "Updated Successfully";

                       // success.Visible = true;
                        Failure.Visible = false;
                        gvCertificate.DataSource = null;
                        gvCertificate.DataBind();
                    }

                    Session.Remove("CertificateTb11");

                   

                   

                }


                // clear();
                







            }
        }




        if (BtnSave1.Text == "Save")
        {
            lblmsg.Text = "";
            if (((DataTable)Session["CertificateTb11"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0 || ((DataTable)Session["CertificateTb11"]).Rows.Count < Convert.ToInt32(txtNoofUnit.Text))
            {
                string message = "alert(' Please Enter ALL the No.of Units Captured	 Details and proceed...!!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = "<font color=red> Please Enter ALL the No.of Units Captured	 Details and Click Add New Button. </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            int i = 0;

            i = Gen.insertIndustryCatelog("0", Session["uid"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), txtresMandals.Text, Label435.Text);//txtresMandals.Text,

            if (i != 999)
            {
                int j = Gen.deleteInitialCatelog(i.ToString());

                if (((DataTable)Session["CertificateTb11"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb11"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb11"]).Rows[m]["intTrIndustrialCatalogueid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb11"]).Rows[m]["intIndustrialCatalogueid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInitialCatelog(myDtNewRecdr);

                    if (statuspr > 0)
                    {

                        clear();
                        string message = "alert('Registered Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        lblmsg.Text = "Registered Successfully";

                        success.Visible = true;
                        Failure.Visible = false;
                        BtnSave1.Enabled = false;
                       

                        gvCertificate.DataSource = null;
                        gvCertificate.DataBind();

                    }
                    else
                    {
                        string message = "alert('Not Registered..please try Again')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        gvCertificate.DataSource = null;
                        gvCertificate.DataBind();
                    }
                    Session.Remove("CertificateTb11");
                }

            

            }
        }
        
    }
    void clear()
    {

        txtYetCapture.Text = "";
        txtNoofUnit.Text = "";
        ddlYear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
        txtresMandals.Text = "";

       


      
       
       
    }


   
    void FillDetails()
    {

        DataSet ds1 = new DataSet();

        //ds1 = Gen.GetInitialCatelogTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

        //if (ds1.Tables[0].Rows.Count > 0)
        //{

        //    Label435.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
        //    Label435.Enabled = false;
        //}

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {

            ds = Gen.getIndustrycatelogfillDet(hdfID.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {


                txtNoofUnit.Text = ds.Tables[0].Rows[0]["NoofUnitsCaptures"].ToString();

                txtYetCapture.Text = ds.Tables[0].Rows[0]["YettoCaptured"].ToString();
                txtresMandals.Text = ds.Tables[0].Rows[0]["NoofUnitsMandal"].ToString();
                ddlYear.SelectedValue = ddlYear.Items.FindByValue(ds.Tables[0].Rows[0]["VI_Year"].ToString()).Value;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(ds.Tables[0].Rows[0]["VI_Month"].ToString()).Value;
                txtresMandals.Enabled = false;
                txtNoofUnit.Enabled = true;
                txtYetCapture.Enabled = false;

                DataSet dsnew = new DataSet();
                dsnew = Gen.getIndustryDetTrans(hdfID.Value.ToString());

                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    lblmsg1.Text = dsnew.Tables[0].Rows.Count.ToString();
                    DataTableReader rdt = new DataTableReader(dsnew.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    ((DataTable)Session["CertificateTb11"]).Clear();
                    ((DataTable)Session["CertificateTb11"]).Load(readert);
                    gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]);
                    gvCertificate.DataBind();
                    //gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;

                }
                else
                {
                    lblmsg1.Text = "0";
                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();
                }


            }

            else
            {
                lblmsg1.Text = "0";
            }
            

            //DataSet dsTradenew = Gen.getCFOLineofActMan(Session["uid"].ToString());
            //if (dsTradenew.Tables[0].Rows.Count > 0)
            //{
            //    DataTableReader rdt = new DataTableReader(dsTradenew.Tables[0]);
            //    IDataReader readert = rdt;

            //    ((DataTable)Session["CertificateTb11"]).Clear();
            //    ((DataTable)Session["CertificateTb11"]).Load(readert);
            //    gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]);
            //    gvCertificate.DataBind();

            //}
            //else
            //{
            //    gvCertificate.DataSource = null;
            //    gvCertificate.DataBind();
            //}

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
          
    }    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndustrialCataloge1.aspx");
        //clear();

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
    //protected void BtnSave2_Click(object sender, EventArgs e)
    //{
            
    //    try
    //    {
    //        gvCertificate.Visible = true;

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate(Session["ApplidA"].ToString(),txtBankName.Text,txtBankBranchName.Text,ddlNatureOfLoan.SelectedItem.ToString(), txtPromoterName.Text,ddlintLineofActivity.SelectedItem.ToString(),txtLoanAmont.Text,txtDDDate.Text, (DataTable)Session["CertificateTb11"]);//Session["uid"].ToString()


    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //            gvCertificate.Columns[0].Visible = false;
    //            clear();
    //            //lblmsg.Text = "";
    //            //lblmsg.Text = "";
    //            //txtBankName.Text = "";
    //            //txtPromoterName.Text = "";
    //            //ddlManQuantityIn.SelectedIndex = 0;
    //           // ddlManQuantityPer .SelectedIndex = 0;

                
    //            //}
    //        }
           

    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }
    
    //}

    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        }

        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }

    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //if (BtnSave1.Text == "Save")
            //{
            ((DataTable)Session["CertificateTb11"]).Rows.RemoveAt(e.RowIndex);
            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]);
            this.gvCertificate.DataBind();
            //}

        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {


        }




        //try
        //{
        //    if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
        //    {
 
        //        ((DataTable)Session["CertificateTb11"]).Rows.RemoveAt(e.RowIndex);

        //        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]).DefaultView;
        //        this.gvCertificate.DataBind();
        //    }
        //    else
        //    {
        //        if (hdfFlagID0.Value.Trim() != "")
        //        {

        //            try
        //            {
        //                string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intTrIndustrialCatalogueid"].ToString();
        //                DataSet dsna = new DataSet();
        //                //int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

        //                ((DataTable)Session["CertificateTb11"]).Rows.RemoveAt(e.RowIndex);
        //                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]).DefaultView;
        //                this.gvCertificate.DataBind();
        //                //}

        //            }
        //            catch (Exception eee)
        //            {
        //            }

        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblmsg.Text = "Please enter correct data";// ex.ToString();

        //}
        //finally
        //{
        //}
    }



   


    //private void AddDataToTableCeertificate1(string intQuessionaireCFOid, string intCFOEnterpid, string Raw_ItemName, string Raw_Item_Quantity, string Raw_Item_Quantity_In, string Raw_Item_Quantity_Per, DataTable myTable1)
    //{//totStartDate, string totEndDate, string totSummary,
    //    try
    //    {
    //        DataRow Row;
    //        Row = myTable1.NewRow();

    //        dtMyTable1 = new DataTable("CertificateTb1");



    //        Row["new"] = "0";
    //        //Row["intCFEForestid"] = "0";
    //        Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
    //        Row["intCFOEnterpid"] = intCFOEnterpid;
    //        Row["Raw_ItemName"] = Raw_ItemName;

    //        Row["Raw_Item_Quantity"] = Raw_Item_Quantity;
    //        Row["Raw_Item_Quantity_In"] = Raw_Item_Quantity_In;
    //        Row["Raw_Item_Quantity_Per"] = Raw_Item_Quantity_Per;
    //        //Row["OtherItemName"] = OtherItemName;
    //        //Row["Forest_Pole"] = Forest_Pole;
    //        //Row["Est_FireWood"] = Est_FireWood;
    //        //Row["created_dt"] = createddate;
    //        // Row["tnrExpEndDate"] = tnrExpEndDate1;
    //        Row["Created_by"] = Session["uid"].ToString().Trim();

    //        Row["intLineofActivityRid"] = "0";

    //        myTable1.Rows.Add(Row);
    //    }
    //    catch (Exception ex)
    //    {
    //        //  ((DataTable)Session["myDatatable"]).Rows.Clear();
    //        //  Response.Redirect("~/EmpFacility.aspx");
    //        throw ex;
    //    }
    //}


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
        myDtNewRecdr = (DataTable)Session["CertificateTb11"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }

    protected void GetNewRectoInsertdr1()
    {
        //myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
        //DataView dvdr1 = new DataView(myDtNewRecdr1);
        ////dvdr1.RowFilter = "new = 0";
        //myDtNewRecdr1 = dvdr1.ToTable();

    }

    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //}
    }

    //protected void gvCertificate0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);

    //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //            this.gvCertificate0.DataBind();
    //        }
    //        else
    //        {
    //            if (hdfFlagID0.Value.Trim() != "")
    //            {
    //                try
    //                {
    //                    string traineetradesnames = gvCertificate0.DataKeys[e.RowIndex].Values["intLineofActivityRid"].ToString();
    //                    DataSet dsna = new DataSet();

    //                    int i1 = Gen.deleteGroupSavingData2(traineetradesnames);

    //                    ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
    //                    this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //                    this.gvCertificate0.DataBind();
    //                    //}

    //                }
    //                catch (Exception eee)
    //                {
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = "Please enter correct data";// ex.ToString();
    //    }
    //    finally
    //    {
    //    }

    //}
    //protected void BtnSave3_Click(object sender, EventArgs e)
    //{
    //    gvCertificate0.Visible = true;
    //    try
    //    {
    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate1(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtRawItem.Text, txtRawQuantity.Text, ddlRawQuantityIn.SelectedItem.Text.ToString(), ddlRawQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb1"]);//Session["uid"].ToString()


    //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //            this.gvCertificate0.DataBind();
    //            gvCertificate0.Columns[0].Visible = false;

    //            lblmsg.Text = "";
    //            txtRawItem.Text = "";
    //            txtRawQuantity.Text = "";
    //            ddlRawQuantityIn.SelectedIndex = 0;
    //            ddlRawQuantityPer.SelectedIndex = 0;
    //            //}
    //        }
    //        else
    //            if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
    //            {

    //                //gvCertificate.Visible = true;


    //                //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
    //                //siva as on 10-08-2103
    //                // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
    //                AddDataToTableCeertificate1(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtRawItem.Text, txtRawQuantity.Text, ddlRawQuantityIn.SelectedItem.Text.ToString(), ddlRawQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb1"]);
    //                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //                this.gvCertificate0.DataBind();
    //                gvCertificate0.Columns[0].Visible = false;
    //                //clear_child_TOT();
    //                lblmsg.Text = "";
    //                txtRawItem.Text = "";
    //                txtRawQuantity.Text = "";
    //                ddlRawQuantityIn.SelectedIndex = 0;
    //                ddlRawQuantityPer.SelectedIndex = 0;
    //                //}
    //            }
    //    }
    //    catch (Exception ee)
    //    {
    //        ////lbldtvalid.Text = "Please enter correct Date.";
    //        ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
    //    }

    //    gvCertificate0.Visible = true;
    //}
    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{
    //    txtBankName.Text = "";
    //    txtPromoterName.Text = "";
    //    //ddlManQuantityIn.SelectedIndex = 0;
    //    //ddlManQuantityPer.SelectedIndex = 0;
    //}
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        //txtRawItem.Text = "";
        //txtRawQuantity.Text = "";
        //ddlRawQuantityIn.SelectedIndex = 0;
        //ddlRawQuantityPer.SelectedIndex = 0;
    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void BtnSave2_Click(object sender, EventArgs e)
    //{

    //}
    protected void txtUnitName_TextChanged(object sender, EventArgs e)
    {

    }

    public string ValidateControlsGrid()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlUnitDIst1.SelectedValue == "0" || ddlUnitDIst1.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District  details\\n";
            slno = slno + 1;
        }
        if (ddlUnitMandal1.SelectedValue == "0" || ddlUnitMandal1.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal details \\n";
            slno = slno + 1;
        }

        if (ddlVillageunit.SelectedValue == "0" || ddlVillageunit.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Village details \\n";
            slno = slno + 1;
        }

        if (ddlcstatus.SelectedValue == "0" || ddlcstatus.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Current Status details \\n";
            slno = slno + 1;
        }

        if (ddlintLineofActivity.SelectedValue == "0" || ddlintLineofActivity.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Line Of Acitivity details \\n";
            slno = slno + 1;
        }

        if (ddlcstatus.SelectedItem.Text == "Others")
        {
            if (txtOthersCurrentStatus.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Status Details  \\n";
                slno = slno + 1;
            }
        }

        


        if (txtgridmaldasNo.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Units In respective Mandals details  \\n";
            slno = slno + 1;
        }


        if (txtaddress.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Address details  \\n";
            slno = slno + 1;
        }

      

        if (txtDateofVisit.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Visited details  \\n";
            slno = slno + 1;
        }

        if (txtremark.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks  \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }

    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

       

        if (ddlYear.SelectedValue == "0" || ddlYear.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Year  \\n";
            slno = slno + 1;
        }

        if (ddlMonth.SelectedValue == "0" || ddlMonth.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Month \\n";
            slno = slno + 1;
        }


        if (txtYetCapture.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Please enter Yet To Capture Details \\n";
            slno = slno + 1;
        }

        if (txtNoofUnit.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + "Please Enter No.of Units In respective Districts	 \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }
    private void AddDataToTableCeertificate(string intIPOid, string NameofUnit, string AddressofUnit, string intLineofActivityid, string DateofVisited, string CurrentStatus, string Remarks, DataTable myTable, string LineofActivityName, string Filepath, string MandalId, string DistrictId, string VillageId, string MandalName, string DistricName, string VillageName, string WhetherYorN,string NoofMandalsgrid)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb11");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intIPOid"] = intIPOid;
          //  Row["intIndustrialCatalogueid"] = intIndustrialCatalogueid;
            Row["NameofUnit"] = NameofUnit;

            Row["AddressofUnit"] = AddressofUnit;
            Row["intLineofActivityid"] = intLineofActivityid;

            string[] Dov= DateofVisited.Split(' ');
            string desiredDate= Dov[0];

            if (desiredDate == "01-01-0101")
            {
                Row["DateofVisited"] = null;
                
            }
            else
            {
                Row["DateofVisited"] = DateofVisited;
            }

           
            Row["CurrentStatus"] = CurrentStatus;
            Row["Remarks"] = Remarks;
            Row["LineofActivityName"] = LineofActivityName;
            //  Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
            // Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            //Row["Remarks"] = Remarks;

            Row["intTrIndustrialCatalogueid"] = "0";
            Row["Filepath"] = Filepath;
            Row["MandalId"] = MandalId;
            Row["DistrictId"] = DistrictId;
            Row["VillageId"] = VillageId;

            Row["MandalName"] = MandalName;
            Row["DistricName"] = DistricName;
            Row["VillageName"] = VillageName;

            Row["WhetherYorN"] = WhetherYorN;
            Row["NoofMandalsgrid"] = NoofMandalsgrid;
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }



    protected void BtnClear0_Click2(object sender, EventArgs e)
    {
        txtaddress.Text = "";
        txtUnitName.Text = "";
        txtDateofVisit.Text = "";
        ddlcstatus.SelectedIndex = 0;
        txtremark.Text = "";
        ddlintLineofActivity.SelectedIndex = 0;

    }

    public void FIleUploading(FileUpload fpd, string Description, HyperLink hlp, string ApprovalID, string DocID, string DocUploadedUserType)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\BankwiseIpoIndustrialCatelogAttch");
        General t1 = new General();
        if ((fpd.PostedFile != null) && (fpd.PostedFile.ContentLength > 0))
        {
            string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);
            // string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);
            //string sFileName = "";

            string fileExtension = Path.GetExtension(sFileName);
            string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
            string Attachmentidnew = Session["uid"].ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

            sFileName = Description + Attachmentidnew + fileExtension;

            try
            {
                string[] fileType = fpd.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                {

                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Description + "\\" + Attachmentidnew);
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fpd.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fpd.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    //  result = t1.InsertCFEUploads(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, Session["uid"].ToString(), ApprovalID, DocID, DocUploadedUserType);
                    // result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    // result = t1.InsertImagedata(Session["Questionaireid"].ToString(), Session["CFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result == 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hlp.Text = "View";
                        hlp.NavigateUrl = "~/BankwiseIpoIndustrialCatelogAttch/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        ViewState[fpd.ID] = "~/BankwiseIpoIndustrialCatelogAttch/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        //   ViewState[fpd.ID] = "~/Attachments/" + "1" + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
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

                    lblmsg0.Text = "<font color='red'>Upload JPEG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Upload PDF files only..');", true);
                    //return;
                }
            }
            catch (Exception ex)//in case of an error
            {
                throw ex;
            }
        }
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        if (rdIaLa_Lst.SelectedValue.ToString() == "Y")
        {
            string errormsg = ValidateControlsGrid();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }



        string currentStatus;
        try
        {
            gvCertificate.Visible = true;

            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {

                if (FileUpload1.HasFile)
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                    {
                        FIleUploading(FileUpload1, "BankWiseIndustrialCatelogReport", lblFileName, "1", "1000001", "IPO");
                    }
                    else
                    {
                        string message = "alert('" + "Please Upload photo of JPG Format Files Only" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                if (FileUpload1.HasFile == false)
                {
                    ViewState["FileUpload1"] = "";
                }

               
                if (ddlcstatus.SelectedItem.Text.ToString() == "Others")
                {

                    currentStatus = txtOthersCurrentStatus.Text.Trim();
                }
                else
                {
                    currentStatus = ddlcstatus.SelectedItem.Text.ToString();
                }
                string DateofVisit;

                if (txtDateofVisit.Text=="" || txtDateofVisit.Text == null)
                {
                    DateofVisit = "01-01-0101";
                }
                else
                {
                    DateofVisit = txtDateofVisit.Text;
                }
                


                AddDataToTableCeertificate(Session["uid"].ToString(), txtUnitName.Text, txtaddress.Text, ddlintLineofActivity.SelectedValue.ToString(), cmf.convertDateIndia(DateofVisit).ToString(), currentStatus, txtremark.Text, (DataTable)Session["CertificateTb11"],ddlintLineofActivity.SelectedItem.Text.ToString(), ViewState["FileUpload1"].ToString(), ddlUnitMandal1.SelectedValue.ToString(), ddlUnitDIst1.SelectedValue.ToString(), ddlVillageunit.SelectedValue.ToString(), ddlUnitMandal1.SelectedItem.ToString(), ddlUnitDIst1.SelectedItem.ToString(), ddlVillageunit.SelectedItem.ToString(), rdIaLa_Lst.SelectedValue.ToString(),txtgridmaldasNo.Text);//Session["uid"].ToString()

               // lblmsg1.Text = ((DataTable)Session["CertificateTb11"]).Rows.Count.ToString();
                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = true;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtUnitName.Text = "";
                txtaddress.Text = "";
                txtDateofVisit.Text = "";
                txtOthersCurrentStatus.Text = "";
                //txtManItem.Text = "";
                ddlintLineofActivity.SelectedIndex = 0;
              //  ddlUnitDIst1.SelectedIndex = 0;
                ddlUnitMandal1.SelectedIndex = 0;
                ddlVillageunit.SelectedIndex = 0;
                txtgridmaldasNo.Text = "";
                //txtManQuantity.Text = "";
                //ddlManQuantityIn.SelectedIndex = 0;
                //ddlManQuantityPer.SelectedIndex = 0;

                //}
            }

            else if (hdfID.Value.Trim() != "")

            {
                if (FileUpload1.HasFile)
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                    {
                        FIleUploading(FileUpload1, "BankWiseReport", lblFileName, "1", "1000000", "IPO");
                    }
                    else
                    {
                        string message = "alert('" + "Please Upload photo of JPG Format Files Only" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                if (FileUpload1.HasFile == false)
                {
                    ViewState["FileUpload1"] = "";
                }

                if (ddlcstatus.SelectedItem.Text.ToString() == "Others")
                {

                    currentStatus = txtOthersCurrentStatus.Text.Trim();
                }
                else
                {
                    currentStatus = ddlcstatus.SelectedItem.Text.ToString();
                }

                string DateofVisit = "";

                if (txtDateofVisit.Text == "" || txtDateofVisit.Text == null)
                {
                    DateofVisit = "01-01-0101";
                }
                else
                {
                    DateofVisit = txtDateofVisit.Text;
                }



                AddDataToTableCeertificate(Session["uid"].ToString(), txtUnitName.Text, txtaddress.Text, ddlintLineofActivity.SelectedValue.ToString(), cmf.convertDateIndia(DateofVisit).ToString(), currentStatus, txtremark.Text, (DataTable)Session["CertificateTb11"],ddlintLineofActivity.SelectedItem.Text.ToString(), ViewState["FileUpload1"].ToString(), ddlUnitMandal1.SelectedValue.ToString(), ddlUnitDIst1.SelectedValue.ToString(), ddlVillageunit.SelectedValue.ToString(), ddlUnitMandal1.SelectedItem.ToString(), ddlUnitDIst1.SelectedItem.ToString(), ddlVillageunit.SelectedItem.ToString(), rdIaLa_Lst.SelectedValue.ToString(), txtgridmaldasNo.Text);//Session["uid"].ToString()

               // lblmsg1.Text = ((DataTable)Session["CertificateTb11"]).Rows.Count.ToString();
                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb11"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = true;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtUnitName.Text = "";
                txtaddress.Text = "";
                txtDateofVisit.Text = "";
                txtOthersCurrentStatus.Text = "";
              //  ddlUnitDIst1.SelectedIndex = 0;
                ddlUnitMandal1.SelectedIndex = 0;
                ddlVillageunit.SelectedIndex = 0;
                txtgridmaldasNo.Text = "";
                //txtManItem.Text = "";
                //txtManQuantity.Text = "";
                //ddlManQuantityIn.SelectedIndex = 0;
                //ddlManQuantityPer.SelectedIndex = 0;

                //}


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

    protected void ddlUnitDIst1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitDIst1.SelectedIndex == 0)
        {
            ddlUnitMandal1.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal1);
        }
        else
        {
            ddlUnitMandal1.Items.Clear();
            DataSet dsm = new DataSet();
            // added newly for testing only

            //if (ddlUnitDIst.SelectedValue == "Medchal")
            //{
            //    ddlUnitDIst.SelectedValue = "20";
            //}

            dsm = Gen.GetMandals(ddlUnitDIst1.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlUnitMandal1.DataSource = dsm.Tables[0];
                ddlUnitMandal1.DataValueField = "Mandal_Id";
                ddlUnitMandal1.DataTextField = "Manda_lName";
                ddlUnitMandal1.DataBind();
                // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlUnitMandal1);
            }
            else
            {
                ddlUnitMandal1.Items.Clear();
                //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlUnitMandal1);
            }
        }
    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public void BindDistrictsGrid()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlUnitDIst1.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlUnitDIst1.DataSource = dsd.Tables[0];
                ddlUnitDIst1.DataValueField = "District_Id";
                ddlUnitDIst1.DataTextField = "District_Name";
                ddlUnitDIst1.DataBind();
                //ddlUnitDIst.Items.Insert(0, "--District--");
                AddSelect(ddlUnitDIst1);
            }
            else
            {
                //ddlUnitDIst.Items.Insert(0, "--District--");
                AddSelect(ddlUnitDIst1);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void ddlUnitMandal1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitMandal1.SelectedIndex == 0)
        {

            ddlVillageunit.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlVillageunit);
        }
        else
        {
            ddlVillageunit.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlUnitMandal1.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillageunit.DataSource = dsv.Tables[0];
                ddlVillageunit.DataValueField = "Village_Id";
                ddlVillageunit.DataTextField = "Village_Name";
                ddlVillageunit.DataBind();
                AddSelect(ddlVillageunit);
                //  ddlVillageunit.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
        }
    }

    protected void ddlcstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlcstatus.SelectedItem.Text.ToString()== "Others")
        {

            trCurrentStatus.Visible = true;
        }
        else
        {
            trCurrentStatus.Visible = false;
        }
    }

    protected void rdIaLa_Lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdIaLa_Lst.SelectedValue.ToString() == "N")
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
            lbl9.Visible = false;
            lbl10.Visible = false;
            lbl21.Visible = false;

        }
        else
        {
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = true;
            lbl7.Visible = true;
            lbl8.Visible = true;
            lbl9.Visible = true;
            lbl10.Visible = true;
            lbl21.Visible = true;
        }
    }
}
