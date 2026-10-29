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
    
    //DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
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

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque3(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                 //   ResetFormControl(this);
                }

            }


        }


        if (!IsPostBack)
        {


            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb"] = dtMyTableCertificate;
        }

        if (!IsPostBack)
        {

            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "73");

            if (dsnew.Tables[0].Rows.Count > 0)
            {




            }
            else
            {


                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {

                    Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                }



            }


        }
        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();

            }

        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }


    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).ReadOnly = true;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intQuessionaireid", typeof(string));
        dtMyTable.Columns.Add("intCFEForestid", typeof(string));
        dtMyTable.Columns.Add("intCFEEnterpid", typeof(string));
        dtMyTable.Columns.Add("Species", typeof(string));
        dtMyTable.Columns.Add("Est_Len_Timber", typeof(string));
        dtMyTable.Columns.Add("Est_Vol_Timber", typeof(string));
        dtMyTable.Columns.Add("Girth", typeof(string));
        dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        dtMyTable.Columns.Add("Created_by", typeof(string));

        dtMyTable.Columns.Add("intCFEForestBulkid", typeof(string));


        return dtMyTable;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {


        if (BtnSave1.Text == "Save")
        {

            DataSet ds = new DataSet();

            ds = Gen.GetdataofForestenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {




                lblmsg.Text = "";
                int i = Gen.insertForestdatalatest(ds.Tables[0].Rows[0]["intCFEForestid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtcontact25.Text, txtcontact28.Text, txtcontact26.Text, txtcontact29.Text, Session["uid"].ToString(), RdProp_Site.SelectedValue, Txt_NoofTrees.Text);

                int k = Gen.DeletebyForestdataid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetails(myDtNewRecdr);
                    //Session.Remove("CertificateTb");

                    //gvCertificate.DataSource = null;
                    //gvCertificate.DataBind();

                }



                if (i != 999)
                {

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                   // clear();
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


                lblmsg.Text = "";
                int i = Gen.insertForestdatalatest("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtcontact25.Text, txtcontact28.Text, txtcontact26.Text, txtcontact29.Text, Session["uid"].ToString(), RdProp_Site.SelectedValue, Txt_NoofTrees.Text);

                int k = Gen.DeletebyForestdataid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetails(myDtNewRecdr);
                    //Session.Remove("CertificateTb");

                    //gvCertificate.DataSource = null;
                    //gvCertificate.DataBind();

                }



                if (i != 999)
                {

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                   // clear();
                }
                else
                {
                    lblmsg0.Text = "Already Exist. ";
                    success.Visible = false;
                    Failure.Visible = true;
                }

            }

        }
       
    }
    void clear()
    {



        txtcontact25.Text = "";
        txtcontact26.Text = "";
        txtcontact28.Text = "";
        txtcontact29.Text = "";
        Txt_NoofTrees.Text = "";
        lblFileName.Text = "";
        Label1.Text = "";
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        string number = "";


        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }


        if (BtnDelete.Text == "Next")
        {
            DataSet ds = new DataSet();

            ds = Gen.GetdataofForestenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {



                lblmsg.Text = "";
                int i = Gen.insertForestdatalatest(ds.Tables[0].Rows[0]["intCFEForestid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtcontact25.Text, txtcontact28.Text, txtcontact26.Text, txtcontact29.Text, Session["uid"].ToString(), RdProp_Site.SelectedValue, Txt_NoofTrees.Text);

                int k = Gen.DeletebyForestdataid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetails(myDtNewRecdr);

                }



                if (i != 999)
                {

                    Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");


                    lblmsg.Text = "Added Successfully..!";
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

                lblmsg.Text = "";
                int i = Gen.insertForestdatalatest("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtcontact25.Text, txtcontact28.Text, txtcontact26.Text, txtcontact29.Text, Session["uid"].ToString(), RdProp_Site.SelectedValue, Txt_NoofTrees.Text);

                int k = Gen.DeletebyForestdataid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetails(myDtNewRecdr);

                }


                if (i != 999)
                {

                    Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");


                    lblmsg.Text = "Added Successfully..!";
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
        }

    }
    void FillDetails()
    {
        //hdfFlagID0.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            //ds = Gen.GetEnterPreneurdata(hdfID.Value.ToString());

            ds = Gen.GetForestdata(hdfFlagID0.Value.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            
            {
                txtcontact25.Text = ds.Tables[0].Rows[0]["Forest_North"].ToString();
                txtcontact26.Text = ds.Tables[0].Rows[0]["Forest_East"].ToString();
                txtcontact28.Text = ds.Tables[0].Rows[0]["Forest_West"].ToString();
                txtcontact29.Text = ds.Tables[0].Rows[0]["Forest_South"].ToString();

                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFEForestid"].ToString();

                if (ds.Tables[0].Rows[0]["HavingTrees"].ToString().Trim() != "")
                {
                    RdProp_Site.SelectedValue = RdProp_Site.Items.FindByValue(ds.Tables[0].Rows[0]["HavingTrees"].ToString()).Value;
                }

                Txt_NoofTrees.Text = ds.Tables[0].Rows[0]["Nooftrees"].ToString();

                // DataSet dsTrade = Gen.getRawmaterialdetails(hdfFlagID0.Value.ToString());
                DataSet dsTrade = Gen.getForestbulkdetails(hdfFlagID0.Value.ToString());
                if (dsTrade.Tables[0].Rows.Count > 0)
                {
                    DataTableReader rdt = new DataTableReader(dsTrade.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    ((DataTable)Session["CertificateTb"]).Clear();
                    ((DataTable)Session["CertificateTb"]).Load(readert);
                    gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]);
                    gvCertificate.DataBind();
                   // gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;


                }
                else
                {
                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();
                }

            



            }
        
            DataSet dsnew = new DataSet();
            dsnew = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                int c = dsnew.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsnew.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");



                    if (sen.Contains("ForestFolder"))
                    {
                        lblFileName.NavigateUrl = sen;
                        lblFileName.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label449.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("ForestFolder1"))
                    {
                        Label1.NavigateUrl = sen;
                        Label1.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label452.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }


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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmForestDetails.aspx");
        clear();
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
        
         myDtNewRecdr = (DataTable)Session["CertificateTb"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }


    private void AddDataToTableCeertificate(string intQuessionaireid, string intCFEEnterpid,string Species, string Est_Len_Timber, string Est_Vol_Timber, string Girth, string Est_FireWood,string Forest_Pole,DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb");



            Row["new"] = "0";
            Row["intCFEForestid"] = "0";
            Row["intQuessionaireid"] = intQuessionaireid;
            Row["intCFEEnterpid"] = intCFEEnterpid;
            Row["Species"] = Species;

            Row["Est_Len_Timber"] = Est_Len_Timber;
            Row["Est_Vol_Timber"] = Est_Vol_Timber;
            Row["Girth"] = Girth;
            Row["Est_FireWood"] = Est_FireWood;
            Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intCFEForestBulkid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        


        gvCertificate.Visible = true;
        try
        {
            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate(Session["Applid"].ToString(),Request.QueryString[0].ToString(),txtcontact11.Text,txtcontact12.Text,txtcontact24.Text,txtcontact18.Text,txtcontact31.Text,txtcontact32.Text,(DataTable)Session["CertificateTb"]);


                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;

                lblmsg.Text = "";
                txtcontact11.Text = ""; txtcontact12.Text = ""; txtcontact24.Text = ""; txtcontact18.Text = ""; txtcontact31.Text = ""; txtcontact32.Text = "";
                //}
            }
            else
                if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                {

                    //gvCertificate.Visible = true;


                    //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    //siva as on 10-08-2103
                    // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    AddDataToTableCeertificate(Session["Applid"].ToString(),Request.QueryString[0].ToString(),txtcontact11.Text, txtcontact12.Text, txtcontact24.Text, txtcontact18.Text, txtcontact31.Text, txtcontact32.Text, (DataTable)Session["Experience"]);
                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                    this.gvCertificate.DataBind();
                    gvCertificate.Columns[0].Visible = false;
                    //clear_child_TOT();
                    lblmsg.Text = "";
                    txtcontact11.Text = ""; txtcontact12.Text = ""; txtcontact24.Text = ""; txtcontact18.Text = ""; txtcontact31.Text = ""; txtcontact32.Text = "";
                    //}
                }
        }

        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate.Visible = true;

    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    //if (BtnSave1.Text == "Save")
        //    //{
        //    ((DataTable)Session["CertificateTb"]).Rows.RemoveAt(e.RowIndex);
        //    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]);
        //    this.gvCertificate.DataBind();
        //    //}

        //}
        //catch (Exception ex)
        //{
        //    //  lblresult.Text = ex.ToString();

        //}
        //finally
        //{


        //}







        try
        {
            if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                //((DataTable)Session["CertificateTb"]).Rows.RemoveAt(e.RowIndex);
                //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]);
                //this.gvCertificate.DataBind();


                ((DataTable)Session["CertificateTb"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                this.gvCertificate.DataBind();
                //ddlSector.SelectedIndex = 0;
                //ddlTrade.SelectedIndex = 0;
                //btnAddTrdmpNew.Visible = true;
                //BtnTradeUpdate.Visible = false;
            }
            else
            {
                if (hdfFlagID0.Value.Trim() != "")
                {



                    //DataSet dsbat = new DataSet();
                    //dsbat = gen.batchexistswithtrngtrade(trainertradesname, hdfID.Value.ToString());
                    //if (dsbat.Tables[0].Rows[0][0].ToString() == "0")
                    //{
                    //    gen.deleteTCTradeTrainer(trainertradesname, tradestrainneid, hdfID.Value.ToString());
                    //}
                    //else
                    //{
                    //   lblresult.Text = "Trade already assigned to a batch";
                    //    return;
                    //}

                    try
                    {
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intCFEForestBulkid"].ToString();
                        //string traineeids = gvTradeMapping.DataKeys[e.RowIndex].Values["intTraineeID"].ToString();
                        DataSet dsna = new DataSet();
                        //dsna = Gen.deleteGroupSavingData1(traineetradesnames);
                        //if (dsna.Tables[0].Rows.Count > 0)
                        //{

                        //    lblmsg.Text = "This Trainee is Already alloted to Batch,So you can't delete this trainee trade";
                        //}
                        //else
                        //{


                        int i1 = Gen.deleteGroupSavingData3(traineetradesnames);

                        ((DataTable)Session["CertificateTb"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //}

                    }
                    catch (Exception eee)
                    { }






                }
            }
            // Added by Srikanth on 20-08-2013 for Page Breakup
            //hdnfocus.Value = txtOrganisation.ClientID;
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {
        }

    }
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        txtcontact11.Text = ""; txtcontact12.Text = ""; txtcontact24.Text = ""; txtcontact18.Text = ""; txtcontact31.Text = ""; txtcontact32.Text = "";

    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ForestFolder");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B1 FORM");

                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ForestFolder", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName.Text = FileUpload1.FileName;
                            Label444.Text = FileUpload1.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
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

                string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ForestFolder1");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ForestFolder1", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label1.Text = FileUpload2.FileName;
                        Label445.Text = FileUpload2.FileName;
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
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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


    }
}
