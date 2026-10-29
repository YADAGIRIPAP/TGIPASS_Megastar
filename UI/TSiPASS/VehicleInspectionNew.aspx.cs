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

public partial class UI_TSiPASS_VehicleInspectionNew : System.Web.UI.Page
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

        //if (Session.Count <= 0)
        //{
        //   // Response.Redirect("../../frmUserLogin.aspx");
        //    Response.Redirect("~/Index.aspx");
        //}


        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            BindDistrictsGrid();
       

            Label439.Text = Session["user_id"].ToString();
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
            month = (System.DateTime.Now.Month - 1).ToString();
            if (month == "0")
            {
                month = "12";
            }
            //ddlMonth.SelectedValue =  ddlMonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
            bindUserwiseData(Session["uid"].ToString(), month);

            ddlMonth.Enabled = false;
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

            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb9"] = dtMyTableCertificate;

            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {

                ddlUnitDIst1.SelectedValue = ddlUnitDIst1.Items.FindByValue(Session["DistrictID"].ToString().Trim()).Value;
                ddlUnitDIst1_SelectedIndexChanged(sender, e);
                ddlUnitDIst1.Enabled = false;
            }

            DataSet ds = Gen.getvehicleInspLookUp(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdfID.Value = ds.Tables[0].Rows[0]["intVehicleInspectionid"].ToString();
                FillDetails();
                BtnSave1.Text = "Update";
            }
            else
            {
                //  else
                //{
                lblmsg1.Text = "0";
            }
            //}

            DataSet ds1 = new DataSet();

            ds1 = Gen.GetVehicleInspectionTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

            if (ds1.Tables[0].Rows.Count > 0)
            {

                Label432.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
                lblmsg2.Text = ds1.Tables[0].Rows[0]["Target"].ToString();

            }
            else
            {
                lblmsg2.Text = "0";
            }



            //dtMyTableCertificate = createtablecrtificate();
            //Session["CertificateTb9"] = dtMyTableCertificate;

            //dtMyTableCertificate1 = createtablecrtificate1();
            //Session["CertificateTb1"] = dtMyTableCertificate1;


        }

        //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "1"))
        //{
        //    success.Visible = false;
        //    Failure.Visible = false;
        //   FillDetails();
        //    BtnSave1.Text = "Update";


        //}

        //if (!IsPostBack)
        //{

        //    DataSet dscheck = new DataSet();
        //    dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
        //    if (dscheck.Tables[0].Rows.Count > 0)
        //    {
        //        Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
        //    }
        //    else
        //    {
        //        Session["Applid"] = "0";
        //    }



        //    DataSet dscheck1 = new DataSet();
        //    dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
        //    if (dscheck1.Tables[0].Rows.Count > 0)
        //    {
        //        Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
        //    }
        //    else
        //    {
        //        Session["ApplidA"] = "0";
        //    }


        //    dtMyTableCertificate = createtablecrtificate();
        //    Session["CertificateTb9"] = dtMyTableCertificate;

        //    dtMyTableCertificate1 = createtablecrtificate1();
        //    Session["CertificateTb1"] = dtMyTableCertificate1;

        //    FillDetails();
        //}


    }

    void bindUserwiseData(string createdBy,string monthName)
    {
        try
        {
            SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("USP_getVehicleInspectionDetails", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = createdBy;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@monthName", SqlDbType.VarChar).Value = monthName;
            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);


            GridView1.DataSource = oDataSet.Tables[0];
            GridView1.DataBind();
            GridView1.Columns[6].Visible = false;
            GridView1.Columns[7].Visible = false;
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[10].Visible = false;
            GridView1.Columns[11].Visible = false;

            osqlConnection.Close();

        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
       
        }
    }

    void FillDetails()
    {

        DataSet ds = new DataSet();


        try
        {


            hdfFlagID.Value = "1";

            DataSet dsfill = new DataSet();

            dsfill = Gen.GetVehicleInspectionDet(hdfID.Value.ToString());

            if (dsfill.Tables[0].Rows.Count > 0)
            {

                lblVehicleInspected.Text = dsfill.Tables[0].Rows[0]["NoofInspected"].ToString();
                lblVehicleInspected.Enabled = true;

                LblVehiclenotInspected.Text = dsfill.Tables[0].Rows[0]["Noofnotinspected"].ToString();
                LblVehiclenotInspected.Enabled = false;

                ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsfill.Tables[0].Rows[0]["VI_Year"].ToString()).Value;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(dsfill.Tables[0].Rows[0]["VI_Month"].ToString()).Value;

                txtNoOfApplnsReceived.Text = dsfill.Tables[0].Rows[0]["TotalNoOfAppln_MOnth"].ToString();
                txtInspectionCarri_2ndFriday.Text = dsfill.Tables[0].Rows[0]["InspectionCarri_2ndFriday"].ToString();
                txtInspectionCarri_4thFriday.Text = dsfill.Tables[0].Rows[0]["InspectionCarri_4thFriday"].ToString();
                txtInspectionreptAT_GM.Text = dsfill.Tables[0].Rows[0]["InspectionreptAT_GM"].ToString();

                DataSet dstr = new DataSet();
                dstr = Gen.getvehicleInspTrans(hdfID.Value.ToString());

                if (dstr.Tables[0].Rows.Count > 0)
                {
                    lblmsg1.Text = dstr.Tables[0].Rows.Count.ToString();
                    DataTableReader rdt = new DataTableReader(dstr.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    ((DataTable)Session["CertificateTb9"]).Clear();
                    ((DataTable)Session["CertificateTb9"]).Load(readert);
                    gvCertificate0.DataSource = ((DataTable)Session["CertificateTb9"]);
                    gvCertificate0.DataBind();
                    //gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;

                }
                else
                {
                    lblmsg1.Text = "0";
                    gvCertificate0.DataSource = null;
                    gvCertificate0.DataBind();
                }





            }
            else
            {
                lblmsg1.Text = "0";

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

    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb9");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intIPOid", typeof(string));
        dtMyTable.Columns.Add("intVehicleInspectionid", typeof(string));
        dtMyTable.Columns.Add("NameofUnit", typeof(string));
        dtMyTable.Columns.Add("AddressofUnit", typeof(string));
        dtMyTable.Columns.Add("DetailsofVehicle", typeof(string));
        dtMyTable.Columns.Add("DateofInspection", typeof(string));
        dtMyTable.Columns.Add("TypeofIncentive", typeof(string));
        dtMyTable.Columns.Add("CurrentStatus", typeof(string));
        dtMyTable.Columns.Add("Remarks", typeof(string));

        dtMyTable.Columns.Add("Created_by", typeof(string));
        dtMyTable.Columns.Add("intTrVehicleInspectionid", typeof(string));
        dtMyTable.Columns.Add("MandalId", typeof(string));
        dtMyTable.Columns.Add("DistrictId", typeof(string));
        dtMyTable.Columns.Add("VillageId", typeof(string));
        dtMyTable.Columns.Add("DistricName", typeof(string));
        dtMyTable.Columns.Add("MandalName", typeof(string));
        dtMyTable.Columns.Add("VillageName", typeof(string));
        dtMyTable.Columns.Add("WhetherYorN", typeof(string));
        dtMyTable.Columns.Add("FilePath", typeof(string));

        return dtMyTable;
    }

    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");

        dtMyTable1.Columns.Add("new", typeof(string));
        dtMyTable1.Columns.Add("UnitName", typeof(string));
        dtMyTable1.Columns.Add("Address", typeof(string));
        dtMyTable1.Columns.Add("detailsvehicle", typeof(string));
        dtMyTable1.Columns.Add("dateinspection", typeof(string));
        dtMyTable1.Columns.Add("incentive", typeof(string));
        dtMyTable1.Columns.Add("cstatus", typeof(string));
        dtMyTable1.Columns.Add("remark", typeof(string));
        // dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


        return dtMyTable1;
    }


    //protected void btnOrgLookup_Click(object sender, EventArgs e)
    //{

    //}
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    if (BtnSave1.Text == "Save")
    //    {
    //        lblmsg.Text = "";



    //        if (((DataTable)Session["CertificateTb9"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details </font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }




    //        if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Raw Material Details </font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }



    //        int i = Gen.DelCFOLineofActivity_Man(Session["uid"].ToString());

    //        if (((DataTable)Session["CertificateTb9"]).Rows.Count > 0)
    //        {

    //            GetNewRectoInsertdr();
    //            int statuspr = Gen.bulkCFOLineofActivity_Man(myDtNewRecdr);
    //        }

    //        int j = Gen.DelCFOLineofActivity_Raw(Session["uid"].ToString());

    //        if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
    //        {
    //            GetNewRectoInsertdr1();
    //            int statuspr1 = Gen.bulkInsertCFOLineofActivity_Raw(myDtNewRecdr1);

    //            if (statuspr1 > 0)
    //            {
    //                lblmsg.Text = "Added Successfully..!";
    //                success.Visible = true;
    //                Failure.Visible = false;
    //                //clear();
    //            }

    //        }

    //    }
    //}
    void clear()
    {

        lblVehicleInspected.Text = ""; LblVehiclenotInspected.Text = ""; ddlYear.SelectedIndex = 0; ddlMonth.SelectedIndex = 0;

        //txtnameunit.Text = "";
        //txtaddressunit.Text = "";
        //txtdetailsvehicle.Text = "";
        //txtDDDate.Text = "";

        //ddlcstatus.SelectedIndex = 0;
        //ddlincentive.SelectedIndex = 0;
        //txtremark.Text = "";




    }


    //protected void BtnClear0_Click(object sender, EventArgs e)
    //{
    //    //Response.Redirect("frmCAFPowerDetails.aspx");

    //    if (BtnDelete.Text == "Next")
    //    {


    //        if (((DataTable)Session["CertificateTb9"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details </font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }




    //        if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Raw Material Details </font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }




    //        int i = Gen.DelCFOLineofActivity_Man(Session["uid"].ToString());

    //        if (((DataTable)Session["CertificateTb9"]).Rows.Count > 0)
    //        {

    //            GetNewRectoInsertdr();
    //            int statuspr = Gen.bulkCFOLineofActivity_Man(myDtNewRecdr);
    //        }

    //        int j = Gen.DelCFOLineofActivity_Raw(Session["uid"].ToString());

    //        if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
    //        {
    //            GetNewRectoInsertdr1();
    //            int statuspr1 = Gen.bulkInsertCFOLineofActivity_Raw(myDtNewRecdr1);

    //            if (statuspr1 > 0)
    //            {
    //                lblmsg.Text = "Added Successfully..!";
    //                success.Visible = true;
    //                Failure.Visible = false;
    //                //clear();
    //            }

    //        }

    //        Response.Redirect("frmCAFPowerDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

    //    }



    //}
    //void FillDetails()
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {

    //        DataSet dsTrade = Gen.getCFOLineofActRaw(Session["uid"].ToString());
    //        if (dsTrade.Tables[0].Rows.Count > 0)
    //        {
    //            DataTableReader rdt = new DataTableReader(dsTrade.Tables[0]);
    //            IDataReader readert = rdt;

    //            ((DataTable)Session["CertificateTb1"]).Clear();
    //            ((DataTable)Session["CertificateTb1"]).Load(readert);
    //            gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]);
    //            gvCertificate0.DataBind();

    //        }
    //        else
    //        {
    //            gvCertificate0.DataSource = null;
    //            gvCertificate0.DataBind();
    //        }

    //        DataSet dsTradenew = Gen.getCFOLineofActMan(Session["uid"].ToString());
    //        if (dsTrade.Tables[0].Rows.Count > 0)
    //        {
    //            DataTableReader rdt = new DataTableReader(dsTradenew.Tables[0]);
    //            IDataReader readert = rdt;

    //            ((DataTable)Session["CertificateTb9"]).Clear();
    //            ((DataTable)Session["CertificateTb9"]).Load(readert);
    //            gvCertificate.DataSource = ((DataTable)Session["CertificateTb9"]);
    //            gvCertificate.DataBind();

    //        }
    //        else
    //        {
    //            gvCertificate.DataSource = null;
    //            gvCertificate.DataBind();
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
    //protected void BtnClear_Click(object sender, EventArgs e)
    //{
    //    clear();

    //}
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //void getcounties()
    //{

    //}
    //protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //void getPayams()
    //{

    //}
    //protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    //{

    //}
    //protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    //{

    //}
    //protected void BtnSave2_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        gvCertificate.Visible = true;

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtManItem.Text, txtManQuantity.Text, ddlManQuantityIn.SelectedItem.Text.ToString(), ddlManQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb9"]);//Session["uid"].ToString()


    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //            gvCertificate.Columns[0].Visible = false;

    //            //lblmsg.Text = "";
    //            lblmsg.Text = "";
    //            txtManItem.Text = "";
    //            txtManQuantity.Text = "";
    //            ddlManQuantityIn.SelectedIndex = 0;
    //            ddlManQuantityPer .SelectedIndex = 0;

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

    //protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
    //    }

    //}

    //protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //    try
    //    {
    //        if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {

    //            ((DataTable)Session["CertificateTb9"]).Rows.RemoveAt(e.RowIndex);

    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //        }
    //        else
    //        {
    //            if (hdfFlagID0.Value.Trim() != "")
    //            {

    //                try
    //                {
    //                    string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
    //                    DataSet dsna = new DataSet();
    //                    int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

    //                    ((DataTable)Session["CertificateTb9"]).Rows.RemoveAt(e.RowIndex);
    //                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
    //                    this.gvCertificate.DataBind();
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



    //private void AddDataToTableCeertificate(string intQuessionaireCFOid, string intCFOEnterpid, string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, string Manf_Item_Quantity_Per, DataTable myTable)
    //{//totStartDate, string totEndDate, string totSummary,
    //    try
    //    {
    //        DataTable dtMyTable;
    //        DataRow Row;
    //        Row = myTable.NewRow();

    //        dtMyTable = new DataTable("CertificateTb9");



    //        Row["new"] = "0";
    //        //Row["intCFEForestid"] = "0";
    //        Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
    //        Row["intCFOEnterpid"] = intCFOEnterpid;
    //        Row["Manf_ItemName"] = Manf_ItemName;

    //        Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
    //        Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
    //        Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
    //       // Row["OtherItemName"] = OtherItemName;
    //        //Row["Forest_Pole"] = Forest_Pole;
    //        //Row["Est_FireWood"] = Est_FireWood;
    //        //Row["created_dt"] = createddate;
    //        // Row["tnrExpEndDate"] = tnrExpEndDate1;
    //        Row["Created_by"] = Session["uid"].ToString().Trim();

    //        Row["intLineofActivityMid"] = "0";

    //        myTable.Rows.Add(Row);
    //    }
    //    catch (Exception ee)
    //    {
    //        //  ((DataTable)Session["myDatatable"]).Rows.Clear();
    //        //  Response.Redirect("~/EmpFacility.aspx");
    //    }
    //}


    private void AddDataToTableCeertificate1(string intQuessionaireCFOid, string UnitName, string Address, string detailsvehicle, string dateinspection, string incentive, string cstatus, string remark, DataTable myTable1)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            //  DataRow Row;
            //  Row = myTable1.NewRow();

            //  dtMyTable1 = new DataTable("CertificateTb1");



            //  Row["new"] = "0";
            //  //Row["intCFEForestid"] = "0";
            ////  Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
            //  Row["UnitName"] = UnitName;
            //  Row["Address"] = Address;

            //  Row["detailsvehicle"] = detailsvehicle;
            //  Row["dateinspection"] = dateinspection;
            //  Row["incentive"] = incentive;
            //  Row["cstatus"] = cstatus;
            //  Row["remark"] = remark;
            //  //Row["Est_FireWood"] = Est_FireWood;
            //  //Row["created_dt"] = createddate;
            //  // Row["tnrExpEndDate"] = tnrExpEndDate1;
            //  Row["Created_by"] = Session["uid"].ToString().Trim();

            //  Row["intLineofActivityRid"] = "0";

            //  myTable1.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
            throw ex;
        }
    }


    //private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    //{




    //}

    //protected void BtnClear0_Click1(object sender, EventArgs e)
    //{

    //}
    //protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        if (BtnSave1.Text == "Save")
    //        {






    //        }
    //        else
    //        {


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //  lblresult.Text = ex.ToString();

    //    }
    //    finally
    //    {
    //    }
    //}



    //protected void GetNewRectoInsertdr()
    //{
    //    myDtNewRecdr = (DataTable)Session["CertificateTb9"];
    //    DataView dvdr = new DataView(myDtNewRecdr);
    //    //dvdr.RowFilter = "new = 0";
    //    myDtNewRecdr = dvdr.ToTable();
    //}

    //protected void GetNewRectoInsertdr1()
    //{
    //    myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
    //    DataView dvdr1 = new DataView(myDtNewRecdr1);
    //    //dvdr1.RowFilter = "new = 0";
    //    myDtNewRecdr1 = dvdr1.ToTable();

    //}

    //protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
    //    }
    //}

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
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        //gvCertificate0.Visible = true;
        //try
        //{
        //    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0"))
        //    {
        //        AddDataToTableCeertificate1(Session["ApplidA"].ToString(), txtnameunit.Text, txtaddressunit.Text, txtdetailsvehicle.Text, txtDDDate.Text, ddlincentive.SelectedItem.ToString(), ddlcstatus.SelectedItem.ToString(),txtremark.Text, (DataTable)Session["CertificateTb1"]);//Session["uid"].ToString()


        //        this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
        //        this.gvCertificate0.DataBind();
        //        gvCertificate0.Columns[0].Visible = false;

        //        lblmsg.Text = "";
        //        //txtRawItem.Text = "";
        //        //txtRawQuantity.Text = "";
        //        //ddlRawQuantityIn.SelectedIndex = 0;
        //        //ddlRawQuantityPer.SelectedIndex = 0;
        //        //}
        //    }
        //    else
        //        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
        //        {

        //            //gvCertificate.Visible = true;


        //            //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
        //            //siva as on 10-08-2103
        //            // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
        //            AddDataToTableCeertificate1(Session["ApplidA"].ToString(), txtnameunit.Text, txtaddressunit.Text, txtdetailsvehicle.Text, txtDDDate.Text, ddlincentive.SelectedItem.ToString(), ddlcstatus.SelectedItem.ToString(), txtremark.Text, (DataTable)Session["CertificateTb1"]);
        //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
        //            this.gvCertificate0.DataBind();
        //            gvCertificate0.Columns[0].Visible = false;
        //            //clear_child_TOT();
        //            lblmsg.Text = "";
        //            //txtRawItem.Text = "";
        //            //txtRawQuantity.Text = "";
        //            //ddlRawQuantityIn.SelectedIndex = 0;
        //            //ddlRawQuantityPer.SelectedIndex = 0;
        //            ////}
        //        }
        //}
        //catch (Exception ee)
        //{
        //    ////lbldtvalid.Text = "Please enter correct Date.";
        //    ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        //}

        //gvCertificate0.Visible = true;
    }
    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{
    //    txtManItem.Text = "";
    //    txtManQuantity.Text = "";
    //    ddlManQuantityIn.SelectedIndex = 0;
    //    ddlManQuantityPer.SelectedIndex = 0;
    //}
    //protected void BtnClear1_Click(object sender, EventArgs e)
    //{

    //}




    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        //
        // Response.Redirect("frmCAFEntrepreneurDetails.aspx?intApplicationId=" + Session["uid"].ToString());
    }
    //protected void BtnSave3_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        gvCertificate0.Visible = true;

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "")||(hdfID.Value.Trim() == "" && hdfFlagID.Value == "0")||(hdfID.Value.Trim() == "" && hdfFlagID.Value == "0"))
    //        {
    //            AddDataToTableCeertificate(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtManItem.Text, txtManQuantity.Text, ddlManQuantityIn.SelectedItem.Text.ToString(), ddlManQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb9"]);//Session["uid"].ToString()


    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //            gvCertificate.Columns[0].Visible = false;

    //            //lblmsg.Text = "";
    //            lblmsg.Text = "";
    //            txtManItem.Text = "";
    //            txtManQuantity.Text = "";
    //            ddlManQuantityIn.SelectedIndex = 0;
    //            ddlManQuantityPer.SelectedIndex = 0;

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
    //protected void BtnClear1_Click(object sender, EventArgs e)
    //{

    //}
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{

    //}
    //protected void BtnClear_Click(object sender, EventArgs e)
    //{

    //}
    //protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{

    //}
    //protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    //{

    //}
    //protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //}
    //protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void txtRawItem_TextChanged(object sender, EventArgs e)
    //{

    //}
    //protected void TextBox1_TextChanged(object sender, EventArgs e)
    //{

    //}

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnClear1_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb9"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
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


        if (txtNoOfApplnsReceived.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Please enter No of Online Application Recived in the reporting month \\n";
            slno = slno + 1;
        }

        if (lblVehicleInspected.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + "Please Enter No of Vehicles Inspected  \\n";
            slno = slno + 1;
        }

        //if (LblVehiclenotInspected.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + "Please Enter No of Vehicle Not Inspected  \\n";
        //    slno = slno + 1;
        //}

        if (txtInspectionCarri_2ndFriday.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + "Please Enter Inspection Carried out(2nd Friday)  \\n";
            slno = slno + 1;
        }

        if (txtInspectionCarri_4thFriday.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + "Please Enter Inspection Carried out(4th Friday) \\n";
            slno = slno + 1;
        }

        if (txtInspectionreptAT_GM.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + "Please Enter Inspection  report submitted to GM  \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
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

        if (txtaddressunit.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Address   \\n";
            slno = slno + 1;
        }

        if (txtdetailsvehicle.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Details of the vehicle  \\n";
            slno = slno + 1;
        }

        if (txtDDDate.Text.TrimStart().TrimEnd().Trim() == "")
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

            if (((DataTable)Session["CertificateTb9"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0 || ((DataTable)Session["CertificateTb9"]).Rows.Count < Convert.ToInt32(lblVehicleInspected.Text))
            {
                string message = "alert(' Please Enter All Vehicle Inspection Details and proceed...!!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                lblmsg0.Text = "<font color=red> Please Enter Vehicle Inspection Details and Click Add new Button. </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }


            //if (((DataTable)Session["CertificateTb9"]).Rows.Count > Convert.ToInt32(lblmsg2.Text) || gvCertificate0.Rows.Count > Convert.ToInt32(lblmsg2.Text))
            //{

            //    lblmsg0.Text = "<font color=red> Vehicle Inspection Details not registered  More than Target</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}




            int i = 0;

            i = Gen.insertVehicleInspection(hdfID.Value.ToString(), Session["uid"].ToString(), Label432.Text, lblVehicleInspected.Text, LblVehiclenotInspected.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), txtNoOfApplnsReceived.Text, txtInspectionCarri_2ndFriday.Text, txtInspectionCarri_4thFriday.Text, txtInspectionreptAT_GM.Text);
            // i = Gen.insertIndustryCatelog(Session["User_Code"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());//txtresMandals.Text,


            if (i != 999)
            {



                int j = Gen.deleteVehicleInspection(hdfID.Value.ToString());



                if (((DataTable)Session["CertificateTb9"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb9"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb9"]).Rows[m]["intTrVehicleInspectionid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb9"]).Rows[m]["intVehicleInspectionid"] = Convert.ToString(hdfID.Value.ToString());
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkVehicleInspection(myDtNewRecdr);

                    if (statuspr > 0)
                    {
                        string message = "alert('Updated Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        lblmsg.Text = "Updated Successfully";

                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {
                        string message = "alert(' Not Updated please Try Again !! ')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    Session.Remove("CertificateTb9");

                    gvCertificate0.DataSource = null;
                    gvCertificate0.DataBind();

                    //Response.Redirect("IPOPMSDashboard.aspx");   
                }
                //Response.Redirect("IPOPMSDashboard.aspx");

                //clear();








            }

        }


        if (BtnSave1.Text == "Save")
        {
            lblmsg.Text = "";

            if (((DataTable)Session["CertificateTb9"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0 || ((DataTable)Session["CertificateTb9"]).Rows.Count < Convert.ToInt32(lblVehicleInspected.Text))
            {
                string message = "alert(' Please Enter All Vehicle Inspection Details and proceed...!!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                lblmsg0.Text = "<font color=red> Please Enter Vehicle Inspection Details and Click Add new Button. </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            //if (((DataTable)Session["CertificateTb9"]).Rows.Count > Convert.ToInt32(lblmsg2.Text) || gvCertificate0.Rows.Count > Convert.ToInt32(lblmsg2.Text))
            //{

            //    lblmsg0.Text = "<font color=red> Vehicle Inspection Details not registered  More than Target</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}


            int i = 0;

            i = Gen.insertVehicleInspection("0", Session["uid"].ToString(), Label432.Text, lblVehicleInspected.Text, LblVehiclenotInspected.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), txtNoOfApplnsReceived.Text, txtInspectionCarri_2ndFriday.Text, txtInspectionCarri_4thFriday.Text, txtInspectionreptAT_GM.Text);
            // i = Gen.insertIndustryCatelog(Session["User_Code"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());//txtresMandals.Text,


            if (i != 999)
            {



                int j = Gen.deleteVehicleInspection(i.ToString());



                if (((DataTable)Session["CertificateTb9"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb9"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb9"]).Rows[m]["intTrVehicleInspectionid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb9"]).Rows[m]["intVehicleInspectionid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkVehicleInspection(myDtNewRecdr);

                    if (statuspr > 0)
                    {
                        string message = "alert('Registered Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        lblmsg.Text = "Registered Successfully";

                        clear();
                        lblmsg.Text = "Registered Successfully";

                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {
                        string message = "alert(' Not Registered Please Try Again')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    Session.Remove("CertificateTb9");

                    gvCertificate0.DataSource = null;
                    gvCertificate0.DataBind();


                }









            }
        }


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("VehicleInspection.aspx");
    }
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {
        txtnameunit.Text = "";
        txtaddressunit.Text = "";
        txtdetailsvehicle.Text = "";
        ddlincentive.SelectedIndex = 0;
        ddlcstatus.SelectedIndex = 0;
        txtDDDate.Text = "";
        txtremark.Text = "";


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

        string DateofVisit = "";

        if (txtDDDate.Text == "" || txtDDDate.Text == null)
        {
            DateofVisit = "01-01-0101";
        }
        else
        {
            DateofVisit = txtDDDate.Text;
        }

        try
        {
            gvCertificate0.Visible = true;

            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {

                if (FileUpload1.HasFile)
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                    {
                        FIleUploading(FileUpload1, "VehicleInspReport", lblFileName, "1", "1010000", "IPO");
                    }
                    else
                    {
                        string message = "alert('" + "Please Upload XLS Files Only" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                if (FileUpload1.HasFile == false)
                {
                    ViewState["FileUpload1"] = "";
                }






                AddDataToTableCeertificate(Session["uid"].ToString(), txtnameunit.Text, txtaddressunit.Text, txtdetailsvehicle.Text, cmf.convertDateIndia(DateofVisit).ToString(), ddlincentive.SelectedItem.Text.ToString(), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb9"], ddlUnitMandal1.SelectedValue.ToString(), ddlUnitDIst1.SelectedValue.ToString(), ddlVillageunit.SelectedValue.ToString(), ddlUnitMandal1.SelectedItem.ToString(), ddlUnitDIst1.SelectedItem.ToString(), ddlVillageunit.SelectedItem.ToString(), rdIaLa_Lst.SelectedValue.ToString(), ViewState["FileUpload1"].ToString());//Session["uid"].ToString()

                //lblmsg1.Text = ((DataTable)Session["CertificateTb9"]).Rows.Count.ToString();
                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
                this.gvCertificate0.DataBind();
                gvCertificate0.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtnameunit.Text = "";
                txtaddressunit.Text = "";
                txtdetailsvehicle.Text = "";
                txtDDDate.Text = "";
                ddlincentive.SelectedIndex = 0;
                ddlcstatus.SelectedIndex = 0;
                // ddlUnitDIst1.SelectedIndex = 0;
                ddlUnitMandal1.SelectedIndex = 0;
                ddlVillageunit.SelectedIndex = 0;

                //txtManItem.Text = "";
                //txtManQuantity.Text = "";
                //ddlManQuantityIn.SelectedIndex = 0;
                //ddlManQuantityPer.SelectedIndex = 0;

                //}
            }
            else if (hdfID.Value.ToString() != "")
            {
                string DateofVisit1 = "";

                if (txtDDDate.Text == "" || txtDDDate.Text == null)
                {
                    DateofVisit1 = "01-01-0101";
                }
                else
                {
                    DateofVisit1 = txtDDDate.Text;
                }

                if (FileUpload1.HasFile)
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                    {
                        FIleUploading(FileUpload1, "VehicleInspReport", lblFileName, "1", "1010000", "IPO");
                    }
                    else
                    {
                        string message = "alert('" + "Please Upload XLS Files Only" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                if (FileUpload1.HasFile == false)
                {
                    ViewState["FileUpload1"] = "";
                }



                AddDataToTableCeertificate(Session["uid"].ToString(), txtnameunit.Text, txtaddressunit.Text, txtdetailsvehicle.Text, cmf.convertDateIndia(DateofVisit1).ToString(), ddlincentive.SelectedItem.Text.ToString(), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb9"], ddlUnitMandal1.SelectedValue.ToString(), ddlUnitDIst1.SelectedValue.ToString(), ddlVillageunit.SelectedValue.ToString(), ddlUnitMandal1.SelectedItem.ToString(), ddlUnitDIst1.SelectedItem.ToString(), ddlVillageunit.SelectedItem.ToString(), rdIaLa_Lst.SelectedValue.ToString(), ViewState["FileUpload1"].ToString());//Session["uid"].ToString()

                // lblmsg1.Text = ((DataTable)Session["CertificateTb9"]).Rows.Count.ToString();
                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
                this.gvCertificate0.DataBind();
                gvCertificate0.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtnameunit.Text = "";
                txtaddressunit.Text = "";
                txtdetailsvehicle.Text = "";
                txtDDDate.Text = "";
                ddlincentive.SelectedIndex = 0;
                ddlcstatus.SelectedIndex = 0;
                // ddlUnitDIst1.SelectedIndex = 0;
                ddlUnitMandal1.SelectedIndex = 0;
                ddlVillageunit.SelectedIndex = 0;

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

    private void AddDataToTableCeertificate(string intIPOid, string NameofUnit, string AddressofUnit, string DetailsofVehicle, string DateofInspection, string TypeofIncentive, string CurrentStatus, string Remarks, DataTable myTable, string MandalId, string DistrictId, string VillageId, string MandalName, string DistricName, string VillageName, string WhetherYorN, string Filepath)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb9");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intIPOid"] = intIPOid;
            //  Row["intIndustrialCatalogueid"] = intIndustrialCatalogueid;
            Row["NameofUnit"] = NameofUnit;

            Row["AddressofUnit"] = AddressofUnit;
            Row["DetailsofVehicle"] = DetailsofVehicle;


            string[] Dov = DateofInspection.Split(' ');
            string desiredDate = Dov[0];
            if (desiredDate == "01-01-0101")
            {
                Row["DateofInspection"] = null;

            }
            else
            {
                Row["DateofInspection"] = desiredDate;
            }


            Row["TypeofIncentive"] = TypeofIncentive;
            Row["CurrentStatus"] = CurrentStatus;

            Row["Remarks"] = Remarks;
            //  Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
            // Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            //Row["Remarks"] = Remarks;

            Row["intTrVehicleInspectionid"] = "0";
            Row["MandalId"] = MandalId;
            Row["DistrictId"] = DistrictId;
            Row["VillageId"] = VillageId;

            Row["MandalName"] = MandalName;
            Row["DistricName"] = DistricName;
            Row["VillageName"] = VillageName;
            Row["WhetherYorN"] = WhetherYorN;
            Row["Filepath"] = Filepath;

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }



    protected void ddlcstatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void gvCertificate0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //if (BtnSave1.Text == "Save")
            //{
            ((DataTable)Session["CertificateTb9"]).Rows.RemoveAt(e.RowIndex);
            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb9"]);
            this.gvCertificate0.DataBind();
            //}

        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {


        }
    }
    //protected void lblVehicleInspected_TextChanged(object sender, EventArgs e)
    //{
    //    if(Label432.Text.Trim() =="")
    //    {
    //    Label432.Text="0";
    //    }
    //    if (lblVehicleInspected.Text != "")
    //    {
    //        if (Convert.ToInt32(Label432.Text.Trim()) < Convert.ToInt32(lblVehicleInspected.Text.Trim()))
    //        {
    //            success.Visible = true;
    //            lblmsg.Text = "No of Vehicles Inspection must be less than No of Application recieved";
    //            lblVehicleInspected.Text = "";
    //        }
    //        else
    //        {
    //            success.Visible = false;
    //            lblmsg.Text = "";
    //        }
    //    }
    //}


    public void FIleUploading(FileUpload fpd, string Description, HyperLink hlp, string ApprovalID, string DocID, string DocUploadedUserType)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\VehicleInsptonIpoReportAttachments");
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
                if (fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
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
                        hlp.NavigateUrl = "~/VehicleInsptonIpoReportAttachments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        ViewState[fpd.ID] = "~/VehicleInsptonIpoReportAttachments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
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

                    lblmsg0.Text = "<font color='red'>Upload xls files only..!</font>";
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

    protected void txtDDDate_TextChanged(object sender, EventArgs e)
    {
        if (txtDDDate.Text != "")
        {
            if (cmf.convertDateIndia(txtDDDate.Text) < Convert.ToDateTime("01-" + ddlMonth.SelectedIndex.ToString() + "-" + ddlYear.SelectedValue.ToString().Trim()) || cmf.convertDateIndia(txtDDDate.Text) > Convert.ToDateTime("30-" + ddlMonth.SelectedIndex.ToString() + "-" + ddlYear.SelectedValue.ToString().Trim()))
            {

                success.Visible = true;
                lblmsg.Text = "Inspected Date Must be in this month";
               // lblVehicleInspected.Text = "";
            }
            else
            {
                success.Visible = false;
                lblmsg.Text = "";
            }
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
        }
    }



    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        rdIaLa_Lst.Enabled = false;
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        txtnameunit.Text= row.Cells[1].Text;
        ddlUnitMandal1.SelectedValue = row.Cells[8].Text;
        DataSet dsv = new DataSet();
        dsv = Gen.GetVillages(ddlUnitMandal1.SelectedValue);
        if (dsv.Tables[0].Rows.Count > 0)
        {
            ddlVillageunit.DataSource = dsv.Tables[0];
            ddlVillageunit.DataValueField = "Village_Id";
            ddlVillageunit.DataTextField = "Village_Name";
            ddlVillageunit.DataBind();
 
            //  ddlVillageunit.Items.Insert(0, "--Village--");
        }
        ddlVillageunit.SelectedValue = row.Cells[9].Text;
        ddlincentive.SelectedValue = row.Cells[6].Text;
        txtaddressunit.Text= row.Cells[11].Text;
        txtDDDate.Text= row.Cells[5].Text;
        txtdetailsvehicle.Text = row.Cells[12].Text;
        ChkApproval.Enabled = false;

    }
}