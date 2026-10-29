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
        //btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {


            //   DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            for (int i = 1990; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add((new ListItem(i.ToString(), i.ToString())));
            }




            string year = "";
            year = System.DateTime.Now.Year.ToString();

            ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;

            ddlYear.Enabled = false;
            // ddlYear.SelectedItem.Text = year.ToString();
            // ddlYear.Enabled = false;
            string month = "";
            month = System.DateTime.Now.Month.ToString();
            ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Value;
            ddlMonth.Enabled = false;
            //  ddlMonth.SelectedItem.Text = month.ToString();
            // ddlMonth.Enabled = false;
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;



            DataSet ds = Gen.getUnitInspLookUp(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdfID.Value = ds.Tables[0].Rows[0]["intUnitInspectionid"].ToString();
                FillDetails();
                BtnSave1.Text = "Update";
            }


            DataSet ds1 = new DataSet();

            ds1 = Gen.getIPOUnitTargets(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

            if (ds1.Tables[0].Rows.Count > 0)
            {

                //Label432.Text = ds1.Tables[0].Rows[0]["Target"].ToString();
                lblmsg2.Text = ds1.Tables[0].Rows[0]["Target"].ToString();

            }
            else
            {
                lblmsg2.Text = "0";
            }

        }


        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        {

            FillDetails();

            BtnSave1.Text = "Update";
            //lblresult.Text = "";
            //Btnsave.Enabled = true;
            hdfFlagID.Value = "";
        }
        if (!IsPostBack)
        {
            //dtMyTableCertificate = createtablecrtificate1();
            //Session["CertificateTb"] = dtMyTableCertificate;
           

         

            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            ddlintLineofActivity.Items.Insert(0, "--Select--");
        }
        
       


    }


   

    //protected DataTable createtablecrtificate1()
    //{
    //   // dtMyTable1 = new DataTable("CertificateTb1");

    //   // dtMyTable1.Columns.Add("new", typeof(string));
    //   // dtMyTable1.Columns.Add("UnitName", typeof(string));
    //   // dtMyTable1.Columns.Add("Address", typeof(string));
    //   // dtMyTable1.Columns.Add("detailsvehicle", typeof(string));
    //   // dtMyTable1.Columns.Add("dateinspection", typeof(string));
    //   // dtMyTable1.Columns.Add("incentive", typeof(string));
    //   // dtMyTable1.Columns.Add("cstatus", typeof(string));
    //   // dtMyTable1.Columns.Add("remark", typeof(string));
    //   //// dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


    //   // return dtMyTable1;
    //}



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

    //            ((DataTable)Session["CertificateTb2"]).Clear();
    //            ((DataTable)Session["CertificateTb2"]).Load(readert);
    //            gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
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
 
    //protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //    try
    //    {
    //        if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
 
    //            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
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

    //                    ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
    //                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
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



    protected void txtRawItem_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlincentive_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlcstatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
   
         try
        {
            
             gvCertificate0.Visible = true;

            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate(txtnameunit.Text, txtaddressunit.Text, ddlintLineofActivity.SelectedItem.ToString(), cmf.convertDateIndia(txtDDDate.Text).ToString(), ddlincentive.SelectedItem.Text.ToString(), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb2"], ddlintLineofActivity.SelectedValue, ddlincentive.SelectedValue, ddlcstatus.SelectedValue);//Session["uid"].ToString()

                //"MM-dd-yyyy"
                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate0.DataBind();
                gvCertificate0.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtnameunit.Text = "";
                txtaddressunit.Text = "";
                ddlintLineofActivity.SelectedIndex = 0;
                txtDDDate.Text = "";
                ddlincentive.SelectedIndex = 0;
                ddlcstatus.SelectedIndex = 0;

                //txtManItem.Text = "";
                //txtManQuantity.Text = "";
                //ddlManQuantityIn.SelectedIndex = 0;
                //ddlManQuantityPer.SelectedIndex = 0;

                //}
            }
            else if (hdfID.Value.ToString() != "")
            {

                AddDataToTableCeertificate( txtnameunit.Text, txtaddressunit.Text, ddlintLineofActivity.SelectedItem.ToString(), cmf.convertDateIndia(txtDDDate.Text).ToString(), ddlincentive.SelectedItem.Text.ToString(), ddlcstatus.SelectedItem.Text.ToString(), txtremark.Text, (DataTable)Session["CertificateTb2"],ddlintLineofActivity.SelectedValue,ddlincentive.SelectedValue,ddlcstatus.SelectedValue);//Session["uid"].ToString()

                //"MM-dd-yyyy"
                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate0.DataBind();
                gvCertificate0.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                ddlcstatus.SelectedIndex = 0;
                //ddlBankName.SelectedIndex = 0;
                txtremark.Text = "";
                txtnameunit.Text = "";
                txtaddressunit.Text = "";
               // txtdetailsvehicle.Text = "";
                ddlintLineofActivity.SelectedIndex = 0;
                txtDDDate.Text = "";
                ddlincentive.SelectedIndex = 0;
                ddlcstatus.SelectedIndex = 0;

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
    private void AddDataToTableCeertificate(string Nameofunit, string AddressofUnit, string lineactivity, string DateofInspection, string TypeofIncentive, string CurrentStatus, string Remarks, DataTable myTable, string Lineofactivity, string incentiveid, string remarkstatus)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");



            Row["new"] = "0";
            //Row["intIPOid"] = intIPOid;
            Row["Nameofunit"] = Nameofunit;

            Row["AddressofUnit"] = AddressofUnit;
            Row["lineactivity"] =  Lineofactivity;
            Row["DateofInspection"] = DateofInspection;
            Row["TypeofIncentive"] =  incentiveid;
            Row["CurrentStatus"] = remarkstatus;
            Row["Remarks"] = Remarks;
            Row["created_by"] = Session["uid"].ToString().Trim();

            Row["LineofActivity_Name"] = lineactivity;
            Row["incentiveid"] = TypeofIncentive;
            Row["cStatus"] = CurrentStatus;
          Row["intUnitInspectionid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        dtMyTable.Columns.Add("new", typeof(string));
       // dtMyTable.Columns.Add("intIPOid", typeof(string));
        //dtMyTable.Columns.Add("intUnitInspectionid", typeof(string));
        dtMyTable.Columns.Add("NameofUnit", typeof(string));
        dtMyTable.Columns.Add("AddressofUnit", typeof(string));
        dtMyTable.Columns.Add("lineactivity", typeof(string));
        dtMyTable.Columns.Add("DateofInspection", typeof(DateTime));
        dtMyTable.Columns.Add("TypeofIncentive", typeof(string));
        dtMyTable.Columns.Add("CurrentStatus", typeof(string));
        dtMyTable.Columns.Add("Remarks", typeof(string));

        dtMyTable.Columns.Add("LineofActivity_Name", typeof(string));
        dtMyTable.Columns.Add("incentiveid", typeof(string));
        dtMyTable.Columns.Add("cStatus", typeof(string));

        dtMyTable.Columns.Add("Created_by", typeof(string));
        dtMyTable.Columns.Add("intUnitInspectionid", typeof(string));

        return dtMyTable;
    }
    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }
   

    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{
    //    txtnameunit.Text = "";
    //    txtaddressunit.Text = "";
    //    txtDDDate.Text = "";
    //    ddlincentive.SelectedIndex = 0;
    //    ddlcstatus.SelectedIndex=0;
    //    txtremark.Text = "";
    //    ddlintLineofActivity.SelectedIndex = 0;

    //}
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //int i = Gen.InsertUnitinsepection(txtapplication.Text, txtinspGM.Text, txtinspcout.Text, txtinsprptSgm.Text, txtinspnot.Text);
        if (BtnSave1.Text == "Update")
        {

            lblmsg.Text = "";

            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
            {
                lblmsg.Text = "<font color=red> Please Enter Unit Inspection Details and Click Add New button.</font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            if (((DataTable)Session["CertificateTb2"]).Rows.Count > Convert.ToInt32(lblmsg2.Text) || gvCertificate0.Rows.Count > Convert.ToInt32(lblmsg2.Text))
            {

                lblmsg.Text = "<font color=red> Unit Inspection Details not registered  More than Target</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            int i = 0;

            //i = Gen.InsertUnitinsepection(hdfID.Value.ToString(), txtapplication.Text, txtinspGM.Text, txtinspcout.Text, txtinsprptSgm.Text, txtinspnot.Text, Session["uid"].ToString(), ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString());
            // i = Gen.insertIndustryCatelog(Session["User_Code"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());//txtresMandals.Text,


            if (i != 999)
            {



                int j = Gen.deleteunitInspection(hdfID.Value.ToString());



                if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb2"]).Rows[m]["intUnitInspectionid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb2"]).Rows[m]["intUnitInspectionid"] = Convert.ToString(hdfID.Value.ToString());
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkUnitInspection(myDtNewRecdr);


                    Session.Remove("CertificateTb2");

                    gvCertificate0.DataSource = null;
                    gvCertificate0.DataBind();

                }

                Response.Redirect("IPOPMSDashboard.aspx");
                //clear();
                lblmsg.Text = "Updated Successfully";

                success.Visible = true;
                Failure.Visible = false;

            }

        }


        if (BtnSave1.Text == "Save")
        {
            lblmsg.Text = "";

            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Unit Inspection Details and Click Add New button.</font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            if (((DataTable)Session["CertificateTb2"]).Rows.Count > Convert.ToInt32(lblmsg2.Text) || gvCertificate0.Rows.Count > Convert.ToInt32(lblmsg2.Text))
            {

                lblmsg0.Text = "<font color=red> Unit Inspection Details not registered  More than Target</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            int i = 0;

            i = Gen.InsertUnitinsepection("0",txtapplication.Text, txtinspGM.Text, txtinspcout.Text, txtinsprptSgm.Text, txtinspnot.Text, Session["uid"].ToString(),ddlYear.SelectedValue.ToString(),ddlMonth.SelectedValue.ToString());
            // i = Gen.insertIndustryCatelog(Session["User_Code"].ToString(), txtNoofUnit.Text, txtYetCapture.Text, ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());//txtresMandals.Text,


            if (i != 999)
            {
               int j = Gen.deleteunitInspection(i.ToString());



                if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb2"]).Rows[m]["intUnitInspectionid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                            //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);

                            ((DataTable)Session["CertificateTb2"]).Rows[m]["intUnitInspectionid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkUnitInspection(myDtNewRecdr);


                    Session.Remove("CertificateTb2");

                    gvCertificate0.DataSource = null;
                    gvCertificate0.DataBind();

                }

                Response.Redirect("IPOPMSDashboard.aspx");
               clear();
                lblmsg.Text = "Registered Successfully";

                success.Visible = true;
                Failure.Visible = false;

            }
        }


   
    }
    void clear()
    {
        txtapplication.Text = "";
        txtinspGM.Text = "";
        txtinspcout.Text = "";
        txtinsprptSgm.Text = "";
        txtinspnot.Text = "";
    }
   
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        txtapplication.Text = "";
        txtinspGM.Text = "";
        txtinspcout.Text = "";
        txtinsprptSgm.Text = "";
        txtinspnot.Text = "";

    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    
    

    void FillDetails()
    {

        DataSet ds = new DataSet();
        try
        {

            DataSet dsTrade = Gen.getUnitInspectioniddet(hdfID.Value);

            if (dsTrade.Tables[0].Rows.Count > 0)
            {
                txtapplication.Text = dsTrade.Tables[0].Rows[0]["NoofApplicationAssigned"].ToString();
                txtinspGM.Text = dsTrade.Tables[0].Rows[0]["InspectionbyGM"].ToString();
                txtinspcout.Text = dsTrade.Tables[0].Rows[0]["Inspectionscarriedout"].ToString();
                txtinsprptSgm.Text = dsTrade.Tables[0].Rows[0]["InspectionreporttoGM"].ToString();
                txtinspnot.Text = dsTrade.Tables[0].Rows[0]["Inspectionnotdone"].ToString();
                txtapplication.Enabled = false;
                txtinspGM.Enabled = false;
                txtinspcout.Enabled = false;
                txtinsprptSgm.Enabled = false;
                txtinspnot.Enabled = false;
            }

            
            if (dsTrade.Tables[1].Rows.Count > 0)
            {
                lblmsg1.Text = dsTrade.Tables[1].Rows.Count.ToString();
                DataTableReader rdt = new DataTableReader(dsTrade.Tables[1]);
                IDataReader readert = rdt;

                ((DataTable)Session["CertificateTb2"]).Clear();
                ((DataTable)Session["CertificateTb2"]).Load(readert);
                gvCertificate0.DataSource = ((DataTable)Session["CertificateTb2"]);
                gvCertificate0.DataBind();

            }
            else
            {
                lblmsg1.Text = "0";
                gvCertificate0.DataSource = null;
                gvCertificate0.DataBind();
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
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

        
        txtnameunit.Text = "";
        txtaddressunit.Text = "";
        txtDDDate.Text = "";
        ddlincentive.SelectedIndex = 0;
        ddlcstatus.SelectedIndex = 0;
        txtremark.Text = "";
        ddlintLineofActivity.SelectedIndex = 0;

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
