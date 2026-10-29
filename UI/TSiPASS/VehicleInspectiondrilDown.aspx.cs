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
       
        //if (Session.Count <= 0)
        //{
        //   // Response.Redirect("../../frmUserLogin.aspx");
        //    Response.Redirect("~/Index.aspx");
        //}

       // btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("~/IndexNew.aspx");
        }

        if (!IsPostBack)
        {
            Label439.Text = Session["user_id"].ToString();
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
            ddlMonth.Enabled = false;
            ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Value;

            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;
            DataSet ds = Gen.getvehicleInspLookUp(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdfID.Value = ds.Tables[0].Rows[0]["intVehicleInspectionid"].ToString();
                FillDetails();
                //BtnSave1.Text = "Update";
            }
            
            
            DataSet ds1 = new DataSet();

            ds1 = Gen.GetVehicleInspectionTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

            if (ds1.Tables[0].Rows.Count > 0)
            {

                Label432.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
                //lblmsg2.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
            }



        

            //dtMyTableCertificate1 = createtablecrtificate1();
            //Session["CertificateTb1"] = dtMyTableCertificate1;


        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            success.Visible = false;
            Failure.Visible = false;
            FillDetails();
          //  BtnSave1.Text = "Update";
           

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
                 lblVehicleInspected.Enabled = false;

                 LblVehiclenotInspected.Text = dsfill.Tables[0].Rows[0]["Noofnotinspected"].ToString();
                 LblVehiclenotInspected.Enabled = false;

                 ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsfill.Tables[0].Rows[0]["VI_Year"].ToString()).Value;

                 ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(dsfill.Tables[0].Rows[0]["VI_Month"].ToString()).Value;

                 DataSet dstr = new DataSet();
                 dstr = Gen.getvehicleInspTrans(hdfID.Value.ToString());

                     if (dstr.Tables[0].Rows.Count > 0)
                {
                   // lblmsg1.Text = dstr.Tables[0].Rows.Count.ToString();
                    DataTableReader rdt = new DataTableReader(dstr.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    //((DataTable)Session["CertificateTb2"]).Clear();
                    ((DataTable)Session["CertificateTb2"]).Load(readert);
                    gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]);
                    gvCertificate0.DataBind();
                    //gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;

                }
                else
                {
                    gvCertificate0.DataSource = null;
                    gvCertificate0.DataBind();
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

    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

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





    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
//
       // Response.Redirect("frmCAFEntrepreneurDetails.aspx?intApplicationId=" + Session["uid"].ToString());
    }
    
    protected void txtRawItem_TextChanged(object sender, EventArgs e)
    {

    }
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

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }

    //protected void BtnSave_Click(object sender, EventArgs e)
    //{


    //    if (BtnSave1.Text == "Update")
    //    {

    //        lblmsg.Text = "";

    //        if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Vehicle Inspection Details and Click Add new Button. </font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }


    //        int i = 0;

    //        //i = Gen.insertVehicleInspection(hdfID.Value.ToString(),Session["uid"].ToString(), Label432.Text, lblVehicleInspected.Text, LblVehiclenotInspected.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());
    //        //// i = Gen.insertIndustryCatelog(Session["User_Code"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());//txtresMandals.Text,


    //        if (i != 999)
    //        {



    //            int j = Gen.deleteVehicleInspection(hdfID.Value.ToString());



    //            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
    //            {

    //                for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
    //                {
    //                    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intTrVehicleInspectionid"].ToString().Trim() == "0")
    //                    {
    //                        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

    //                        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

    //                        ((DataTable)Session["CertificateTb2"]).Rows[m]["intVehicleInspectionid"] = Convert.ToString(hdfID.Value.ToString());
    //                    }
    //                }

    //                GetNewRectoInsertdr();
    //                int statuspr = Gen.bulkVehicleInspection(myDtNewRecdr);


    //                Session.Remove("CertificateTb2");

    //                gvCertificate0.DataSource = null;
    //                gvCertificate0.DataBind();

    //            }


    //            clear();
    //            lblmsg.Text = "Updated Successfully";

    //            success.Visible = true;
    //            Failure.Visible = false;








    //        }

    //    }


    //    if (BtnSave1.Text == "Save")
    //    {
    //        lblmsg.Text = "";

    //        if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
    //        {
    //            lblmsg0.Text = "<font color=red> Please Enter Vehicle Details and Click Add New button.</font>";

    //            success.Visible = false;
    //            Failure.Visible = true;
    //            return;
    //        }


    //        int i = 0;

    //        i = Gen.insertVehicleInspection("0",Session["uid"].ToString(), Label432.Text, lblVehicleInspected.Text, LblVehiclenotInspected.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());
    //       // i = Gen.insertIndustryCatelog(Session["User_Code"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());//txtresMandals.Text,


    //        if (i != 999)
    //        {



    //            int j = Gen.deleteVehicleInspection(i.ToString());



    //            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
    //            {

    //                for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
    //                {
    //                    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intTrVehicleInspectionid"].ToString().Trim() == "0")
    //                    {
    //                        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

    //                        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

    //                        ((DataTable)Session["CertificateTb2"]).Rows[m]["intVehicleInspectionid"] = Convert.ToString(i);
    //                    }
    //                }

    //                GetNewRectoInsertdr();
    //                int statuspr = Gen.bulkVehicleInspection(myDtNewRecdr);


    //                Session.Remove("CertificateTb2");

    //                gvCertificate0.DataSource = null;
    //                gvCertificate0.DataBind();

    //            }


    //            clear();
    //            lblmsg.Text = "Registered Successfully";

    //            success.Visible = true;
    //            Failure.Visible = false;








    //        }
    //    }


    //}
    //protected void BtnClear_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("VehicleInspection.aspx");
    //}
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {
        //txtnameunit.Text = "";
        //txtaddressunit.Text = "";
        //txtdetailsvehicle.Text = "";
        //ddlincentive.SelectedIndex = 0;
        //ddlcstatus.SelectedIndex = 0;
        //txtDDDate.Text = "";
        //txtremark.Text = "";


    }
    //protected void BtnSave2_Click1(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        gvCertificate0.Visible = true;

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate(Session["uid"].ToString(), txtnameunit.Text, txtaddressunit.Text, txtdetailsvehicle.Text,cmf.convertDateIndia(txtDDDate.Text).ToString("MM-dd-yyyy"),ddlincentive.SelectedItem.Text.ToString(),ddlcstatus.SelectedItem.Text.ToString(),txtremark.Text, (DataTable)Session["CertificateTb2"]);//Session["uid"].ToString()


    //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //            this.gvCertificate0.DataBind();
    //            gvCertificate0.Columns[0].Visible = false;

    //            //lblmsg.Text = "";
    //            lblmsg.Text = "";
    //            ddlcstatus.SelectedIndex = 0;
    //            //ddlBankName.SelectedIndex = 0;
    //            txtremark.Text = "";
    //            txtnameunit.Text = "";
    //            txtaddressunit.Text = "";
    //            txtdetailsvehicle.Text = "";
    //            txtDDDate.Text = "";
    //            ddlincentive.SelectedIndex = 0;
    //            ddlcstatus.SelectedIndex = 0;

    //            //txtManItem.Text = "";
    //            //txtManQuantity.Text = "";
    //            //ddlManQuantityIn.SelectedIndex = 0;
    //            //ddlManQuantityPer.SelectedIndex = 0;

    //            //}
    //        }
    //        else if (hdfID.Value.ToString() != "")
    //        {

    //            AddDataToTableCeertificate(Session["uid"].ToString(), txtnameunit.Text, txtaddressunit.Text, txtdetailsvehicle.Text, cmf.convertDateIndia(txtDDDate.Text).ToString("MM-dd-yyyy"), ddlincentive.SelectedItem.Text.ToString(), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb2"]);//Session["uid"].ToString()


    //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //            this.gvCertificate0.DataBind();
    //            gvCertificate0.Columns[0].Visible = false;

    //            //lblmsg.Text = "";
    //            lblmsg.Text = "";
    //            ddlcstatus.SelectedIndex = 0;
    //            //ddlBankName.SelectedIndex = 0;
    //            txtremark.Text = "";
    //            txtnameunit.Text = "";
    //            txtaddressunit.Text = "";
    //            txtdetailsvehicle.Text = "";
    //            txtDDDate.Text = "";
    //            ddlincentive.SelectedIndex = 0;
    //            ddlcstatus.SelectedIndex = 0;

    //            //txtManItem.Text = "";
    //            //txtManQuantity.Text = "";
    //            //ddlManQuantityIn.SelectedIndex = 0;
    //            //ddlManQuantityPer.SelectedIndex = 0;

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

    private void AddDataToTableCeertificate(string intIPOid, string NameofUnit, string AddressofUnit, string DetailsofVehicle, string DateofInspection, string TypeofIncentive, string CurrentStatus,string Remarks,DataTable myTable)
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
            Row["DetailsofVehicle"] = DetailsofVehicle;
            Row["DateofInspection"] = DateofInspection;
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
            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]);
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
}
