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
    //DataRow dtrdr;
    //DataTable myDtNewRecdr = new DataTable();

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
    string TourismFlag;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }


        if (!IsPostBack)
        {

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                applicationstatus = dscheck.Tables[0].Rows[0]["Appl_Status"].ToString().Trim();

                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                //if (TourismFlag == "Y")
                //{
                //    if (Request.QueryString[1].ToString() == "N")
                //    {
                //        Response.Redirect("frmForestDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                //    }
                //    else
                //    {
                //        Response.Redirect("frmLandDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                //    }
                //}
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dsver = new DataSet();

            //dsver = Gen.Getverifyofque2(Session["Applid"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{


            // }

            DataSet dspcb = new DataSet();
            dspcb = Gen.GetdataRedirectionurltopcb(Session["Applid"].ToString(), "");
            if (dspcb != null && dspcb.Tables.Count > 0 && dspcb.Tables[0].Rows.Count > 0)
            {
                // string URI = "164.100.163.19/TLNPCB/industryRegMaster/doLoginWithDetails";
                //string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&industryEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString() +
                //    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim()
                //    + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&serviceId=1";
                string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
                    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString()
                     + "&serviceId=1" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString()
                     + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString()
                     + "&indCapInvt=" + dspcb.Tables[0].Rows[0]["indCapInvt"].ToString() + "&indNewCapInvt=" + dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString()
                     + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString()
                     + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString()
                     + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString()
                     + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString()
                     + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString()
                     + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString()
                     + "&buildArea=" + dspcb.Tables[0].Rows[0]["buildArea"].ToString() + "&industryTypeId=" + dspcb.Tables[0].Rows[0]["industryTypeId"].ToString() +
                     "&categoryId=" + dspcb.Tables[0].Rows[0]["categoryId"].ToString()
                     + "&uniqueUserId=" + dspcb.Tables[0].Rows[0]["uniqueUserId"].ToString();


                Response.Redirect("https://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
            }

            /////**added code for getting rawmaterial and product details from PCB by madhuri 10/04/2018**///

            //DataSet dsTrade = Gen.getManfacturedetails(Request.QueryString["intApplicationId"].ToString());
            //if (dsTrade.Tables[0].Rows.Count == 0)
            //{
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
                                        if (Manf_ItemName != null && Manf_ItemName != "")
                                        {
                                            int outputpcb = Gen.insertProductsfromPCB(Session["Applid"].ToString(), Request.QueryString[0].ToString(), null, null, Manf_ItemName, Manf_Item_Quantity, Manf_Item_Quantity_In,
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

            //}


            //DataSet dsTradeMaterial = Gen.getRawmaterialdetails(Request.QueryString["intApplicationId"].ToString());
            //if (dsTradeMaterial.Tables[0].Rows.Count == 0)
            //{
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
                                            int outputpcb = Gen.insertRawMaterialfromPCB(Session["Applid"].ToString(), Request.QueryString[0].ToString(), null, null, Manf_ItemName, Manf_Item_Quantity, Manf_Item_Quantity_In,
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
            //}
            ///**Endofaddedcodeby madhuri////

            if (TourismFlag == "Y")
            {
                DataSet dsc2 = new DataSet();
                dsc2 = Gen.GetCategoryDetNew_Hotel(Session["uid"].ToString(), "Y");
                if (dsc2 != null && dsc2.Tables.Count > 0 && dsc2.Tables[0].Rows.Count > 0)
                {
                    ddlintLineofActivity.DataSource = dsc2.Tables[0];
                    ddlintLineofActivity.DataValueField = "intLineofActivityid";
                    ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                    ddlintLineofActivity.DataBind();
                    ddlintLineofActivity.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlintLineofActivity.Items.Insert(0, "--Select--");
                }
            }
            else
            {
                DataSet dsc = new DataSet();
                dsc = Gen.GetCategoryDetNew(Session["uid"].ToString().Trim());
                ddlintLineofActivity.DataSource = dsc.Tables[0];
                ddlintLineofActivity.DataValueField = "intLineofActivityid";
                ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                ddlintLineofActivity.DataBind();
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;

            dtMyTableCertificate1 = createtablecrtificate1();
            Session["CertificateTb1"] = dtMyTableCertificate1;


            if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareReg.aspx");
            }


            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {

                DataSet dsch = new DataSet();
                dsch = Gen.GetEnterPreneurdatabylineofactivity1(Session["Applid"].ToString());

                if (dsch.Tables[0].Rows.Count > 0)
                {
                    if (dsch.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim() != "")
                    {

                        string valueFromDS = dsch.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim();
                        ListItem foundItem = ddlintLineofActivity.Items.FindByValue(valueFromDS);
                        if (foundItem != null)
                        {
                            ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dsch.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;

                            ddlintLineofActivity.Enabled = false;
                        }
                        else
                        {
                            ddlintLineofActivity.SelectedIndex = -1;
                            ddlintLineofActivity.Enabled = false;
                        }
                    }

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
        string res = Gen.RetriveStatus(Session["Applid"].ToString());
        ////string res = Gen.RetriveStatus("1002");


        if (res == "3" || Convert.ToInt32(res) >= 3)
        {
            ResetFormControl(this);
            foreach (GridViewRow row in gvCertificate.Rows)
            {
                DataControlFieldCell editable = (DataControlFieldCell)row.Controls[1];
                editable.Enabled = false;
            }
            foreach (GridViewRow row in gvCertificate0.Rows)
            {
                DataControlFieldCell editable = (DataControlFieldCell)row.Controls[1];
                editable.Enabled = false;
            }
        }
        if (gvCertificate.Rows.Count == 0)
        {
            txtitem.ReadOnly = false;
            txtquantity.ReadOnly = false;
            ddlquantityper.Enabled = true;
            ddlquantityin.Enabled = true;
            txtitem2.ReadOnly = false;
        }
        if (gvCertificate0.Rows.Count == 0)
        {
            txtitem1.ReadOnly = false;
            txtquantity1.ReadOnly = false;
            ddlQuantityper1.Enabled = true;
            ddlquantity1.Enabled = true;
            txtitem3.ReadOnly = false;
        }
        //if (hdfFlagID0.Value.ToString().Trim() != "")
        //{


        //}
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
        dtMyTable = new DataTable("CertificateTb2");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intQuessionaireid", typeof(string));
        dtMyTable.Columns.Add("intCFEEnterpid", typeof(string));
        dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
        dtMyTable.Columns.Add("OtherItemName", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        dtMyTable.Columns.Add("Created_by", typeof(string));

        dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


        return dtMyTable;
    }


    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");

        dtMyTable1.Columns.Add("new", typeof(string));
        dtMyTable1.Columns.Add("intQuessionaireid", typeof(string));
        dtMyTable1.Columns.Add("intCFEEnterpid", typeof(string));
        dtMyTable1.Columns.Add("Raw_ItemName", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity_In", typeof(string));
        dtMyTable1.Columns.Add("Raw_Item_Quantity_Per", typeof(string));
        dtMyTable1.Columns.Add("OtherItemName", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        dtMyTable1.Columns.Add("Created_by", typeof(string));

        dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


        return dtMyTable1;
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (ddlintLineofActivity.SelectedValue == "" || ddlintLineofActivity.SelectedValue == null || ddlintLineofActivity.SelectedValue == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Line of Activity and in CFE questionnaire please select line of activity as per new categories and proceed with common application form')", true);
        }
        else
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




                if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
                {
                    lblmsg0.Text = "<font color=red> Please Enter Raw Material Details and Click add new Button</font>";

                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }





                int i = Gen.DeletebyManufactureid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                {

                    //for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                    //{
                    //    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intLineofActivityMid"].ToString().Trim() == "0")
                    //    {
                    //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                    //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                    //    }
                    //}

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertmanufacture(myDtNewRecdr);


                    //Session.Remove("CertificateTb");

                    //gvCertificate.DataSource = null;
                    //gvCertificate.DataBind();

                }


                int j = Gen.DeletebyRawMaterialid(hdfFlagID0.Value.ToString());


                if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
                {

                    //for (int n = 0; n < ((DataTable)Session["CertificateTb1"]).Rows.Count; n++)
                    //{
                    //    if (((DataTable)Session["CertificateTb1"]).Rows[n]["intLineofActivityRid"].ToString().Trim() == "0")
                    //    {
                    //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                    //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                    //    }
                    //}

                    GetNewRectoInsertdr1();
                    int statuspr1 = Gen.bulkInsertRAWmaterial(myDtNewRecdr1);


                    //Session.Remove("CertificateTb1");

                    //gvCertificate0.DataSource = null;
                    //gvCertificate0.DataBind();

                    if (statuspr1 > 0)
                    {
                        lblmsg.Text = "Added Successfully..!";
                        success.Visible = true;
                        Failure.Visible = false;
                        //clear();

                    }

                }



                //if (statuspr1 > 0)
                //{

                //}




            }
        }

    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        string number = "";

        if (hdfID.Value != "")
        {

            //number = hdfpencode.Value;
        }
        if (ddlintLineofActivity.SelectedValue == "" || ddlintLineofActivity.SelectedValue == null || ddlintLineofActivity.SelectedValue == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Line of Activity and in CFE questionnaire please select line of activity as per new categories and proceed with common application form')", true);
        }
        else
        {

            if (BtnDelete.Text == "Next")
            {
                lblmsg.Text = "";


                if (((DataTable)Session["CertificateTb2"]).Rows.Count == 0 || gvCertificate.Rows.Count == 0)
                {
                    lblmsg0.Text = "<font color=red> Please Enter Manufacture  Details and Click add new Button</font>";

                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }




                if (((DataTable)Session["CertificateTb1"]).Rows.Count == 0 || gvCertificate0.Rows.Count == 0)
                {
                    lblmsg0.Text = "<font color=red> Please Enter Raw Material Details and Click add new Button </font>";

                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }







                if (hdfFlagID0.Value.ToString() == "")
                {



                    if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                    {

                        //for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                        //{
                        //    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intLineofActivityMid"].ToString().Trim() == "0")
                        //    {
                        //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                        //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        //    }
                        //}

                        GetNewRectoInsertdr();
                        int statuspr = Gen.bulkInsertmanufacture(myDtNewRecdr);

                    }





                    if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
                    {

                        //for (int n = 0; n < ((DataTable)Session["CertificateTb1"]).Rows.Count; n++)
                        //{
                        //    if (((DataTable)Session["CertificateTb1"]).Rows[n]["intLineofActivityRid"].ToString().Trim() == "0")
                        //    {
                        //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                        //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        //    }
                        //}

                        GetNewRectoInsertdr1();
                        int statuspr1 = Gen.bulkInsertRAWmaterial(myDtNewRecdr1);


                        if (statuspr1 > 0)
                        {
                            //lblmsg.Text = "Added Successfully..!";
                            //success.Visible = true;
                            //Failure.Visible = false;
                            //clear();



                        }

                        Response.Redirect("frmForestDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");//+"&privious="+"P"
                    }
                }
                else
                {
                    int i = Gen.DeletebyManufactureid(hdfFlagID0.Value.ToString());

                    if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
                    {

                        //for (int m = 0; m < ((DataTable)Session["CertificateTb2"]).Rows.Count; m++)
                        //{
                        //    if (((DataTable)Session["CertificateTb2"]).Rows[m]["intLineofActivityMid"].ToString().Trim() == "0")
                        //    {
                        //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                        //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        //    }
                        //}

                        GetNewRectoInsertdr();
                        int statuspr = Gen.bulkInsertmanufacture(myDtNewRecdr);

                    }



                    int j = Gen.DeletebyRawMaterialid(hdfFlagID0.Value.ToString());

                    if (((DataTable)Session["CertificateTb1"]).Rows.Count > 0)
                    {

                        //for (int n = 0; n < ((DataTable)Session["CertificateTb1"]).Rows.Count; n++)
                        //{
                        //    if (((DataTable)Session["CertificateTb1"]).Rows[n]["intLineofActivityRid"].ToString().Trim() == "0")
                        //    {
                        //        //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);

                        //        //((DataTable)Session["CertificateTb"]).Rows[m]["intCFEForestid"] = Convert.ToString(i);
                        //    }
                        //}

                        GetNewRectoInsertdr1();
                        int statuspr1 = Gen.bulkInsertRAWmaterial(myDtNewRecdr1);


                        if (statuspr1 > 0)
                        {
                            //lblmsg.Text = "Added Successfully..!";
                            //success.Visible = true;
                            //Failure.Visible = false;
                            //clear();

                            //Response.Redirect("frmForestDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString());

                        }



                    }


                    Response.Redirect("frmForestDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");//+"&privious="+"P"
                }

            }
        }
    }
    void FillDetails()
    {
        DataSet ds = new DataSet();
        try
        {

            DataSet dsTrade = Gen.getRawmaterialdetails(hdfFlagID0.Value.ToString());
            if (dsTrade.Tables[0].Rows.Count > 0)
            {
                DataTableReader rdt = new DataTableReader(dsTrade.Tables[0]);
                IDataReader readert = rdt;

                //ddlTrade.SelectedIndex = 0;


                //Session["tmpDataTable"] = dsTrade.Tables[0];

                ((DataTable)Session["CertificateTb1"]).Clear();
                ((DataTable)Session["CertificateTb1"]).Load(readert);
                gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]);
                gvCertificate0.DataBind();
                // gvCertificate0.Columns[0].Visible = true;
                //gvCertificate0.Columns[1].Visible = false;
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






            DataSet dsTradenew = Gen.getManfacturedetails(hdfFlagID0.Value.ToString());
            if (dsTrade.Tables[0].Rows.Count > 0)
            {
                DataTableReader rdt = new DataTableReader(dsTradenew.Tables[0]);
                IDataReader readert = rdt;

                //ddlTrade.SelectedIndex = 0;


                //Session["tmpDataTable"] = dsTrade.Tables[0];

                ((DataTable)Session["CertificateTb2"]).Clear();
                ((DataTable)Session["CertificateTb2"]).Load(readert);
                gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]);
                gvCertificate.DataBind();
                //gvCertificate.Columns[0].Visible = true;
                //gvCertificate.Columns[1].Visible = false;
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




            //DataSet dsbatch = cmn.traineebatchexists(hdfID.Value.ToString());
            //if (dsbatch.Tables[0].Rows.Count > 0)
            //{
            //    gvTradeMapping.Columns[1].Visible = false;
            //    //BtnAddnew.Enabled = false;
            //}
            //else
            //{
            //    gvTradeMapping.Columns[1].Visible = true;
            //    //BtnAddnew.Enabled = true;
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
        //Response.Redirect("frmLINEOFMANUFACTURE.aspx");
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
    protected void txtquantity1_TextChanged(object sender, EventArgs e)
    {

    }
    private void AddDataToTableCeertificate(string intQuessionaireid, string intCFEEnterpid, string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, string Manf_Item_Quantity_Per, string OtherItemName, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intQuessionaireid"] = intQuessionaireid;
            Row["intCFEEnterpid"] = intCFEEnterpid;
            Row["Manf_ItemName"] = Manf_ItemName;

            Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            Row["Manf_Item_Quantity_Per"] = Manf_Item_Quantity_Per;
            Row["OtherItemName"] = OtherItemName;
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



    private void AddDataToTableCeertificate1(string intQuessionaireid, string intCFEEnterpid, string Raw_ItemName, string Raw_Item_Quantity, string Raw_Item_Quantity_In, string Raw_Item_Quantity_Per, string OtherItemName, DataTable myTable1)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable1.NewRow();

            dtMyTable1 = new DataTable("CertificateTb1");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["intQuessionaireid"] = intQuessionaireid;
            Row["intCFEEnterpid"] = intCFEEnterpid;
            Row["Raw_ItemName"] = Raw_ItemName;

            Row["Raw_Item_Quantity"] = Raw_Item_Quantity;
            Row["Raw_Item_Quantity_In"] = Raw_Item_Quantity_In;
            Row["Raw_Item_Quantity_Per"] = Raw_Item_Quantity_Per;
            Row["OtherItemName"] = OtherItemName;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityRid"] = "0";

            myTable1.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        gvCertificate.Visible = true;
        try
        {
            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem.Text, txtquantity.Text, ddlquantityin.SelectedValue.ToString(), ddlquantityper.SelectedValue.ToString(), txtitem2.Text, (DataTable)Session["CertificateTb2"]);


                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;
                gvCertificate.Columns[6].Visible = false;
                //lblmsg.Text = "";
                lblmsg.Text = "";
                txtitem.Text = "";
                txtquantity.Text = "";
                ddlquantityin.SelectedIndex = 0;
                // ddlquantityper.SelectedIndex = 0;
                ddlQuantityper1.SelectedValue = ddlquantityper.SelectedValue;
                ddlquantityper.Enabled = false;
                ddlQuantityper1.Enabled = false;

                txtitem2.Text = "";
                //}
            }
            else
                if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                {

                    //gvCertificate.Visible = true;


                    //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    //siva as on 10-08-2103
                    // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    AddDataToTableCeertificate(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem.Text, txtquantity.Text, ddlquantityin.SelectedValue.ToString(), ddlquantityper.SelectedValue.ToString(), txtitem2.Text, (DataTable)Session["CertificateTb2"]);
                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvCertificate.DataBind();
                    gvCertificate.Columns[0].Visible = false;
                    gvCertificate.Columns[6].Visible = false;
                    //clear_child_TOT();
                    lblmsg.Text = "";
                    txtitem.Text = "";
                    txtquantity.Text = "";
                    ddlquantityin.SelectedIndex = 0;
                    ddlquantityper.SelectedIndex = 0;
                    txtitem2.Text = "";
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
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {
        txtitem.Text = "";
        txtquantity.Text = "";
        ddlquantityin.SelectedIndex = 0;
        ddlquantityper.SelectedIndex = 0;

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


                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
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
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                        //string traineeids = gvTradeMapping.DataKeys[e.RowIndex].Values["intTraineeID"].ToString();
                        DataSet dsna = new DataSet();
                        //dsna = Gen.deleteGroupSavingData1(traineetradesnames);
                        //if (dsna.Tables[0].Rows.Count > 0)
                        //{

                        //    lblmsg.Text = "This Trainee is Already alloted to Batch,So you can't delete this trainee trade";
                        //}
                        //else
                        //{


                        int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //}

                    }
                    catch (Exception eee)
                    { }
                }
            }
            if (gvCertificate.Rows.Count < 1)
            {
                ddlquantityper.Enabled = true;
                ddlquantityper.Enabled = true;
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
    protected void gvCertificate0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    //if (BtnSave1.Text == "Save")
        //    //{
        //    ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
        //    this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]);
        //    this.gvCertificate0.DataBind();
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


                ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                this.gvCertificate0.DataBind();
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
                        string traineetradesnames = gvCertificate0.DataKeys[e.RowIndex].Values["intLineofActivityRid"].ToString();
                        //string traineeids = gvTradeMapping.DataKeys[e.RowIndex].Values["intTraineeID"].ToString();
                        DataSet dsna = new DataSet();
                        //dsna = Gen.deleteGroupSavingData1(traineetradesnames);
                        //if (dsna.Tables[0].Rows.Count > 0)
                        //{

                        //    lblmsg.Text = "This Trainee is Already alloted to Batch,So you can't delete this trainee trade";
                        //}
                        //else
                        //{


                        int i1 = Gen.deleteGroupSavingData2(traineetradesnames);

                        ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gvCertificate0.DataBind();
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
    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        gvCertificate0.Visible = true;
        try
        {
            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate1(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem1.Text, txtquantity1.Text, ddlquantity1.SelectedValue.ToString(), ddlQuantityper1.SelectedValue.ToString(), txtitem3.Text, (DataTable)Session["CertificateTb1"]);


                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                this.gvCertificate0.DataBind();
                gvCertificate0.Columns[0].Visible = false;

                gvCertificate0.Columns[6].Visible = false;
                //lblmsg.Text = "";
                lblmsg.Text = "";
                txtitem1.Text = "";
                txtquantity1.Text = "";
                ddlquantity1.SelectedIndex = 0;
                //ddlquantityper1.SelectedIndex = 0;
                txtitem3.Text = "";

                // ddlQuantityper1.SelectedIndex = 0;
                //}
            }
            else
                if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                {

                    //gvCertificate.Visible = true;


                    //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    //siva as on 10-08-2103
                    // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                    AddDataToTableCeertificate1(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtitem1.Text, txtquantity1.Text, ddlquantity1.SelectedValue.ToString(), ddlQuantityper1.SelectedValue.ToString(), txtitem3.Text, (DataTable)Session["CertificateTb1"]);
                    this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                    this.gvCertificate0.DataBind();
                    gvCertificate0.Columns[0].Visible = false;
                    gvCertificate0.Columns[6].Visible = false;
                    //clear_child_TOT();
                    lblmsg.Text = "";
                    txtitem1.Text = "";
                    txtquantity1.Text = "";
                    ddlquantity1.SelectedIndex = 0;
                    //ddlquantityper1.SelectedIndex = 0;

                    ddlQuantityper1.SelectedIndex = 0;
                    txtitem3.Text = "";
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
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        txtitem1.Text = "";
        txtquantity1.Text = "";
        ddlquantity1.SelectedIndex = 0;
        ddlQuantityper1.SelectedIndex = 0;

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        //Session["operation"] = "Update";
        Response.Redirect("frmLandDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
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
    protected void ddlquantity1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquantity1.SelectedValue.ToString() == "Others")
        {
            Qty1.Visible = true;
        }
        else
        {
            Qty1.Visible = false;
        }

    }
}
