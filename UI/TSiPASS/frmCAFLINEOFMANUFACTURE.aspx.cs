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
    string applicationstatus;


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



            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                applicationstatus = dscheck1.Tables[0].Rows[0]["Appl_Status"].ToString().Trim();

                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }

            DataSet dspcb = new DataSet();
            dspcb = Gen.GetdataRedirectionurltopcbCFO(Session["ApplidA"].ToString(), "");
            if (dspcb != null && dspcb.Tables.Count > 0 && dspcb.Tables[0].Rows.Count > 0)
            {
                // string URI = "164.100.163.19/TLNPCB/industryRegMaster/doLoginWithDetails";
                //string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&industryEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString() +
                //    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().ToUpper()
                //    + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&serviceId=6";
                string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString().Trim() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
                      "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString().Trim() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString().Trim()
                       + "&serviceId=6" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString().Trim() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString()
                       + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString().Trim() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString().Trim()
                       + "&indCapInvt=" + dspcb.Tables[0].Rows[0]["indCapInvt"].ToString().Trim() + "&indNewCapInvt=" + dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString().Trim()
                       + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString().Trim()
                       + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString().Trim()
                       + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString().Trim() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString().Trim()
                       + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString().Trim() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString().Trim()
                       + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString().Trim() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString().Trim()
                       + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString().Trim() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString().Trim()
                       + "&buildArea=" + dspcb.Tables[0].Rows[0]["buildArea"].ToString().Trim() + "&industryTypeId=" + dspcb.Tables[0].Rows[0]["industryTypeId"].ToString().Trim() +
                       "&categoryId=" + dspcb.Tables[0].Rows[0]["categoryId"].ToString().Trim()
                       + "&uniqueUserId=" + dspcb.Tables[0].Rows[0]["uniqueUserId"].ToString().Trim();
                LogErrorFile.LogData(Convert.ToString(myParameters));
                Response.Redirect("https://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
            }

            /////**added code for getting rawmaterial and product details from PCB by madhuri 10/04/2018**///

            DataSet dsTrade = Gen.getCFOLineofActMan(Request.QueryString["intApplicationId"].ToString());
            if (dsTrade.Tables[0].Rows.Count == 0)
            {
                string msg = "https://tsocmms.nic.in/TLWS/productDeatil?swiftApplicationNo=" + Session["uid"].ToString().Trim();

                try
                {
                    var webRequest = System.Net.WebRequest.Create(msg);
                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/x-www-form-urlencoded";

                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                        //{
                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                        //        sw.Write(jsonData);
                        //}

                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                            {
                                var jsonResponse = sr.ReadToEnd();

                                if (jsonResponse != null)
                                {
                                    string xml = jsonResponse;
                                    StringReader str = new StringReader(xml);
                                    DataSet dsout = new DataSet();
                                    dsout.ReadXml(str);

                                    if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                    {
                                        int pcbcount = dsout.Tables[0].Rows.Count;
                                        for (int i = 0; i < pcbcount; i++)
                                        {
                                            string existingQuantity = ""; string unit = "", unit2 = "", Letter = "";

                                            string[] Quantity = null;
                                            string[] QuantityIn = null;
                                            //string[] QuantityPer = null;
                                            Quantity = dsout.Tables[0].Rows[i]["existingQuantity"].ToString().Split(' ');
                                            QuantityIn = dsout.Tables[0].Rows[i]["unit"].ToString().Split('/');
                                            // QuantityPer = unit.Split('/');


                                            string intQuessionaireid = Session["Applid"].ToString();
                                            string intCFEEnterpid = Request.QueryString["intApplicationId"].ToString();
                                            string Manf_ItemName = dsout.Tables[0].Rows[i]["productName"].ToString();
                                            string Manf_Item_Quantity = Quantity[0].ToString();
                                            string Manf_Item_Quantity_In = QuantityIn[0].ToString();
                                            string Manf_Item_Quantity_Per = QuantityIn[1].ToString();
                                            if (Manf_ItemName != null & Manf_ItemName != "")
                                            {
                                                int outputpcb = Gen.insertProductsfromPCBCFO(intQuessionaireid, intCFEEnterpid, null, null, Manf_ItemName, Manf_Item_Quantity, Manf_Item_Quantity_In,
                 Manf_Item_Quantity_Per, Session["uid"].ToString().Trim(), Session["uid"].ToString().Trim(), null);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

            }


            DataSet dsTradeMaterial = Gen.getCFOLineofActRaw(Request.QueryString["intApplicationId"].ToString());
            if (dsTradeMaterial.Tables[0].Rows.Count == 0)
            {
                string msg1 = "https://tsocmms.nic.in/TLWS/rawMaterialDeatil?swiftApplicationNo=" + Session["uid"].ToString().Trim();

                try
                {
                    var webRequest = System.Net.WebRequest.Create(msg1);
                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/x-www-form-urlencoded";

                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                        //{
                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                        //        sw.Write(jsonData);
                        //}

                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                            {
                                var jsonResponse = sr.ReadToEnd();

                                if (jsonResponse != null)
                                {
                                    string xml = jsonResponse;
                                    StringReader str = new StringReader(xml);
                                    DataSet dsout = new DataSet();
                                    dsout.ReadXml(str);

                                    if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                    {
                                        int pcbcount = dsout.Tables[0].Rows.Count;
                                        for (int i = 0; i < pcbcount; i++)
                                        {
                                            string existingQuantity = ""; string unit = "", unit2 = "", Letter = "";

                                            string[] Quantity = null;
                                            string[] QuantityIn = null;
                                            //string[] QuantityPer = null;
                                            Quantity = dsout.Tables[0].Rows[i]["existingQuantity"].ToString().Split(' ');
                                            QuantityIn = dsout.Tables[0].Rows[i]["unit"].ToString().Split('/');
                                            // QuantityPer = unit.Split('/');


                                            string intQuessionaireid = Session["Applid"].ToString();
                                            string intCFEEnterpid = Request.QueryString["intApplicationId"].ToString();
                                            string Manf_ItemName = dsout.Tables[0].Rows[i]["rawMaterialName"].ToString();
                                            string Manf_Item_Quantity = Quantity[0].ToString();
                                            string Manf_Item_Quantity_In = QuantityIn[0].ToString();
                                            string Manf_Item_Quantity_Per = QuantityIn[1].ToString();
                                            if (Manf_ItemName != null & Manf_ItemName != "")
                                            {
                                                int outputpcb = Gen.insertRawMaterialfromPCBCFO(intQuessionaireid, intCFEEnterpid, null, null, Manf_ItemName, Manf_Item_Quantity, Manf_Item_Quantity_In,
                 Manf_Item_Quantity_Per, Session["uid"].ToString().Trim(), Session["uid"].ToString().Trim(), null);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
            ///**Endofaddedcodeby madhuri////
            ///
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;

            dtMyTableCertificate1 = createtablecrtificate1();
            Session["CertificateTb1"] = dtMyTableCertificate1;

            FillDetails();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }


    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intQuessionaireCFOid", typeof(string));
        dtMyTable.Columns.Add("intCFOEnterpid", typeof(string));
        dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
        dtMyTable.Columns.Add("Created_by", typeof(string));
        dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


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
        if (BtnSave1.Text == "Save")
        {
            lblmsg.Text = "";



            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }




            if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Raw Material Details </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }



            int i = Gen.DelCFOLineofActivity_Man(Session["uid"].ToString());

            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
            {

                GetNewRectoInsertdr();
                int statuspr = Gen.bulkCFOLineofActivity_Man(myDtNewRecdr);
            }

            int j = Gen.DelCFOLineofActivity_Raw(Session["uid"].ToString());

            if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
            {
                GetNewRectoInsertdr1();
                int statuspr1 = Gen.bulkInsertCFOLineofActivity_Raw(myDtNewRecdr1);

                if (statuspr1 > 0)
                {
                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    //clear();
                }

            }

        }
    }
    void clear()
    {

        txtManItem.Text = "";
        txtManQuantity.Text = "";
        ddlManQuantityIn.SelectedIndex = 0;
        ddlManQuantityPer.SelectedIndex = 0;
        
        txtRawItem.Text = "";
        txtRawQuantity.Text = "";
        ddlRawQuantityIn.SelectedIndex = 0;
        ddlRawQuantityPer.SelectedIndex = 0;
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmCAFPowerDetails.aspx");

        if (BtnDelete.Text == "Next")
        {


            if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }




            if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Raw Material Details </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }




            int i = Gen.DelCFOLineofActivity_Man(Session["uid"].ToString());

            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
            {

                GetNewRectoInsertdr();
                int statuspr = Gen.bulkCFOLineofActivity_Man(myDtNewRecdr);
            }

            int j = Gen.DelCFOLineofActivity_Raw(Session["uid"].ToString());

            if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
            {
                GetNewRectoInsertdr1();
                int statuspr1 = Gen.bulkInsertCFOLineofActivity_Raw(myDtNewRecdr1);

                if (statuspr1 > 0)
                {
                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    //clear();
                }

            }

            Response.Redirect("frmCAFPowerDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

        }

      

    }
    void FillDetails()
    {

        DataSet ds = new DataSet();
        try
        {

            DataSet dsTrade = Gen.getCFOLineofActRaw(Session["uid"].ToString());
            if (dsTrade.Tables[0].Rows.Count > 0)
            {
                DataTableReader rdt = new DataTableReader(dsTrade.Tables[0]);
                IDataReader readert = rdt;

                ((DataTable)Session["CertificateTb1"]).Clear();
                ((DataTable)Session["CertificateTb1"]).Load(readert);
                gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]);
                gvCertificate0.DataBind();
                if (applicationstatus == "3")
                {
                    gvCertificate0.Columns[1].Visible = false;

                }

            }
            else
            {
                gvCertificate0.DataSource = null;
                gvCertificate0.DataBind();
            }

            DataSet dsTradenew = Gen.getCFOLineofActMan(Session["uid"].ToString());
            if (dsTrade.Tables[0].Rows.Count > 0)
            {
                DataTableReader rdt = new DataTableReader(dsTradenew.Tables[0]);
                IDataReader readert = rdt;

                ((DataTable)Session["CertificateTb2"]).Clear();
                ((DataTable)Session["CertificateTb2"]).Load(readert);
                gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
                gvCertificate.DataBind();
                if (applicationstatus == "3")
                {
                    gvCertificate.Columns[1].Visible = false;

                }

            }
            else
            {
                gvCertificate.DataSource = null;
                gvCertificate.DataBind();
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
            gvCertificate.Visible = true;

            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtManItem.Text, txtManQuantity.Text, ddlManQuantityIn.SelectedItem.Text.ToString(), ddlManQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb2"]);//Session["uid"].ToString()


                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;

                //lblmsg.Text = "";
                lblmsg.Text = "";
                txtManItem.Text = "";
                txtManQuantity.Text = "";
                ddlManQuantityIn.SelectedIndex = 0;
                ddlManQuantityPer .SelectedIndex = 0;
                
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
            if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
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
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                        DataSet dsna = new DataSet();
                        int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

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



    private void AddDataToTableCeertificate(string intQuessionaireCFOid, string intCFOEnterpid, string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, string Manf_Item_Quantity_Per, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataTable dtMyTable;
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
            Row["intCFOEnterpid"] = intCFOEnterpid;
            Row["Manf_ItemName"] = Manf_ItemName;

            Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
           // Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }


    private void AddDataToTableCeertificate1(string intQuessionaireCFOid, string intCFOEnterpid, string Raw_ItemName, string Raw_Item_Quantity, string Raw_Item_Quantity_In, string Raw_Item_Quantity_Per, DataTable myTable1)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable1.NewRow();

            dtMyTable1 = new DataTable("CertificateTb1");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
            Row["intCFOEnterpid"] = intCFOEnterpid;
            Row["Raw_ItemName"] = Raw_ItemName;

            Row["Raw_Item_Quantity"] = Raw_Item_Quantity;
            Row["Raw_Item_Quantity_In"] = Raw_Item_Quantity_In;
            Row["Raw_Item_Quantity_Per"] = Raw_Item_Quantity_Per;
            //Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityRid"] = "0";

            myTable1.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
            throw ex;
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
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }

    protected void GetNewRectoInsertdr1()
    {
        myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
        DataView dvdr1 = new DataView(myDtNewRecdr1);
        //dvdr1.RowFilter = "new = 0";
        myDtNewRecdr1 = dvdr1.ToTable();

    }

    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    protected void gvCertificate0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                this.gvCertificate0.DataBind();
            }
            else
            {
                if (hdfFlagID0.Value.Trim() != "")
                {
                    try
                    {
                        string traineetradesnames = gvCertificate0.DataKeys[e.RowIndex].Values["intLineofActivityRid"].ToString();
                        DataSet dsna = new DataSet();

                        int i1 = Gen.deleteGroupSavingData2(traineetradesnames);

                        ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gvCertificate0.DataBind();
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
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        gvCertificate0.Visible = true;
        try
        {
            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate1(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtRawItem.Text, txtRawQuantity.Text, ddlRawQuantityIn.SelectedItem.Text.ToString(), ddlRawQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb1"]);//Session["uid"].ToString()


                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                this.gvCertificate0.DataBind();
                gvCertificate0.Columns[0].Visible = false;

                lblmsg.Text = "";
                txtRawItem.Text = "";
                txtRawQuantity.Text = "";
                ddlRawQuantityIn.SelectedIndex = 0;
                ddlRawQuantityPer.SelectedIndex = 0;
                //}
            }
            else
                if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                {

                    //gvCertificate.Visible = true;


                    //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    //siva as on 10-08-2103
                    // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    AddDataToTableCeertificate1(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtRawItem.Text, txtRawQuantity.Text, ddlRawQuantityIn.SelectedItem.Text.ToString(), ddlRawQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb1"]);
                    this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                    this.gvCertificate0.DataBind();
                    gvCertificate0.Columns[0].Visible = false;
                    //clear_child_TOT();
                    lblmsg.Text = "";
                    txtRawItem.Text = "";
                    txtRawQuantity.Text = "";
                    ddlRawQuantityIn.SelectedIndex = 0;
                    ddlRawQuantityPer.SelectedIndex = 0;
                    //}
                }
        }
        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate0.Visible = true;
    }
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {
        txtManItem.Text = "";
        txtManQuantity.Text = "";
        ddlManQuantityIn.SelectedIndex = 0;
        ddlManQuantityPer.SelectedIndex = 0;
    }
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        txtRawItem.Text = "";
        txtRawQuantity.Text = "";
        ddlRawQuantityIn.SelectedIndex = 0;
        ddlRawQuantityPer.SelectedIndex = 0;
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmCAFEntrepreneurDetails.aspx?intApplicationId=" + Session["uid"].ToString());
    }
}
