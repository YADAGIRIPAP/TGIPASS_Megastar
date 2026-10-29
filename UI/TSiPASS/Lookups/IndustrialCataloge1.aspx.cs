using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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


            for (int i = 1990; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add((new ListItem(i.ToString(), i.ToString())));
            }

            string year = "";
            year = System.DateTime.Now.Year.ToString();

            ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;

            // ddlYear.SelectedItem.Text = year.ToString();
             ddlYear.Enabled = false;
            string month = "";
            month = System.DateTime.Now.Month.ToString();
            ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Value;

            ddlMonth.Enabled = false;



            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;

            dtMyTableCertificate1 = createtablecrtificate1();
            Session["CertificateTb1"] = dtMyTableCertificate1;


            DataSet ds = new DataSet();
            ds = Gen.GetInitialCatelogTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                Label435.Text = ds.Tables[0].Rows[0]["Target"].ToString();



            }




            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            ddlintLineofActivity.Items.Insert(0, "--Select--");



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

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            success.Visible = false;
            Failure.Visible = false;

            FillDetails();

            BtnSave1.Text = "Update";
        }
    }


    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

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

        if (BtnSave1.Text == "Update")
        {
            lblmsg.Text = "";


            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Industrial Catelog Details and Click Add New  Button.</font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }


            int i = 0;

            i = Gen.insertIndustryCatelog(hdfID.Value.ToString(), Session["uid"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), txtresMandals.Text, Label435.Text);//txtresMandals.Text,


            if (i != 999)
            {



                int j = Gen.deleteInitialCatelog(hdfID.Value.ToString());

                if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb2"]).Rows[m]["intTrIndustrialCatalogueid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb2"]).Rows[m]["intIndustrialCatalogueid"] = Convert.ToString(hdfID.Value.ToString());
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInitialCatelog(myDtNewRecdr);


                    Session.Remove("CertificateTb2");

                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();

                }


                clear();
                lblmsg.Text = "Updated Successfully";

                success.Visible = true;
                Failure.Visible = false;








            }
        }




        if (BtnSave1.Text == "Save")
        {
            lblmsg.Text = "";


            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Industrial Catelog Details and Click Add New  Button. </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            int i = 0;

            i = Gen.insertIndustryCatelog("0", Session["uid"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), txtresMandals.Text, Label435.Text);//txtresMandals.Text,


            if (i != 999)
            {



                int j = Gen.deleteInitialCatelog(i.ToString());

                if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb2"]).Rows[m]["intTrIndustrialCatalogueid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb2"]).Rows[m]["intIndustrialCatalogueid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInitialCatelog(myDtNewRecdr);


                    Session.Remove("CertificateTb2");

                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();

                }


                clear();
                lblmsg.Text = "Registered Successfully";

                success.Visible = true;
                Failure.Visible = false;








            }
        }
        //    if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
        //    {
        //        lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details </font>";

        //        success.Visible = false;
        //        Failure.Visible = true;
        //        return;
        //    }


        //    int i = Gen.DelCFOLineofActivity_Man(Session["uid"].ToString());

        //    if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
        //    {

        //        GetNewRectoInsertdr();
        //        int statuspr = Gen.bulkCFOLineofActivity_Man(myDtNewRecdr);
        //    }

           

        //}
    }
    void clear()
    {

        txtYetCapture.Text = "";
        txtNoofUnit.Text = "";
        ddlYear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
        txtresMandals.Text = "";

        //txtBankName.Text = "";
        //txtPromoterName.Text = "";
        //ddlNatureOfLoan.SelectedIndex = 0;
        //ddlintLineofActivity.SelectedIndex = 0;
        //txtDDDate.Text = "";
        //txtBankBranchName.Text = "";
        //txtLoanAmont.Text = "";


      
       
       
    }


   
    void FillDetails()
    {

        DataSet ds1 = new DataSet();

        ds1 = Gen.GetInitialCatelogTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

        if (ds1.Tables[0].Rows.Count > 0)
        {

            Label435.Text = ds1.Tables[0].Rows[0]["Target"].ToString();

        }

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {

            ds = Gen.getIndustrycatelogfillDet(hdfID.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {


                txtresMandals.Text = ds.Tables[0].Rows[0]["NoofUnitsMandal"].ToString();
                txtNoofUnit.Text = ds.Tables[0].Rows[0]["NoofUnitsCaptures"].ToString();

                txtYetCapture.Text = ds.Tables[0].Rows[0]["YettoCaptured"].ToString();

                ddlYear.SelectedValue = ddlYear.Items.FindByValue(ds.Tables[0].Rows[0]["VI_Year"].ToString()).Value;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(ds.Tables[0].Rows[0]["VI_Month"].ToString()).Value;

                txtresMandals.Enabled = false;
                txtNoofUnit.Enabled = false;
                txtYetCapture.Enabled = false;

                DataSet dsnew = new DataSet();
                dsnew = Gen.getIndustryDetTrans(hdfID.Value.ToString());

                if (dsnew.Tables[0].Rows.Count > 0)
                {

                    DataTableReader rdt = new DataTableReader(dsnew.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    ((DataTable)Session["CertificateTb2"]).Clear();
                    ((DataTable)Session["CertificateTb2"]).Load(readert);
                    gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
                    gvCertificate.DataBind();
                    //gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;

                }
                else
                {
                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();
                }


            }

            

            //DataSet dsTradenew = Gen.getCFOLineofActMan(Session["uid"].ToString());
            //if (dsTradenew.Tables[0].Rows.Count > 0)
            //{
            //    DataTableReader rdt = new DataTableReader(dsTradenew.Tables[0]);
            //    IDataReader readert = rdt;

            //    ((DataTable)Session["CertificateTb2"]).Clear();
            //    ((DataTable)Session["CertificateTb2"]).Load(readert);
            //    gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
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
    //            AddDataToTableCeertificate(Session["ApplidA"].ToString(),txtBankName.Text,txtBankBranchName.Text,ddlNatureOfLoan.SelectedItem.ToString(), txtPromoterName.Text,ddlintLineofActivity.SelectedItem.ToString(),txtLoanAmont.Text,txtDDDate.Text, (DataTable)Session["CertificateTb2"]);//Session["uid"].ToString()


    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
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
        
    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
 
                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
            }
            else
            {
                if (hdfFlagID0.Value.Trim() != "")
                {

                    try
                    {
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intTrIndustrialCatalogueid"].ToString();
                        DataSet dsna = new DataSet();
                        //int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //}

                    }
                    catch (Exception eee)
                    {
                    }

                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {
        }
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
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
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

    private void AddDataToTableCeertificate(string intIPOid, string NameofUnit, string AddressofUnit, string intLineofActivityid, string DateofVisited, string CurrentStatus, string Remarks, DataTable myTable, string LineofActivityName)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intIPOid"] = intIPOid;
          //  Row["intIndustrialCatalogueid"] = intIndustrialCatalogueid;
            Row["NameofUnit"] = NameofUnit;

            Row["AddressofUnit"] = AddressofUnit;
            Row["intLineofActivityid"] = intLineofActivityid;
            Row["DateofVisited"] = DateofVisited;
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        try
        {
            gvCertificate.Visible = true;

            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate(Session["uid"].ToString(), txtUnitName.Text, txtaddress.Text, ddlintLineofActivity.SelectedValue.ToString(), cmf.convertDateIndia(txtDateofVisit.Text).ToString("MM-dd-yyyy"), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb2"],ddlintLineofActivity.SelectedItem.Text.ToString());//Session["uid"].ToString()


                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtUnitName.Text = "";
                txtaddress.Text = "";
                txtDateofVisit.Text = "";
                ddlintLineofActivity.SelectedIndex = 0;

                //txtManItem.Text = "";
                //txtManQuantity.Text = "";
                //ddlManQuantityIn.SelectedIndex = 0;
                //ddlManQuantityPer.SelectedIndex = 0;

                //}
            }

            else if (hdfID.Value.Trim() != "")

            {

                AddDataToTableCeertificate(Session["uid"].ToString(), txtUnitName.Text, txtaddress.Text, ddlintLineofActivity.SelectedValue.ToString(), cmf.convertDateIndia(txtDateofVisit.Text).ToString("MM-dd-yyyy"), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb2"],ddlintLineofActivity.SelectedItem.Text.ToString());//Session["uid"].ToString()


                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtUnitName.Text = "";
                txtaddress.Text = "";
                txtDateofVisit.Text = "";
                ddlintLineofActivity.SelectedIndex = 0;
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
}
