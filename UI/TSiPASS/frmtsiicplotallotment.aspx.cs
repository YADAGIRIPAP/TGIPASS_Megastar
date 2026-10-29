using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.Linq;
using System.ServiceModel.Description;
using System.Text.RegularExpressions;


public partial class UI_TSIPASS_frmtsiicplotallotment : System.Web.UI.Page
{
    General Gen = new General();
    TsiicProperties tsiic = new TsiicProperties();
    CommonBL objcommon = new CommonBL();
    TSIICPLOTCGG.TSPlotDetailsService tsiicplotobj = new TSIICPLOTCGG.TSPlotDetailsService();

    public static decimal TotalPhase { get; set; }

    DataTable dt = new DataTable();

    DataSet dsmypower = new DataSet();
    static DataTable dtMyTableCertificate3;
    static DataTable dtMyTableCertificate1;
    static DataTable dtMyTable;
    static DataTable dtMyTable1;
    static DataTable dtMyTable2;
    static DataTable dtMyTable3;
    static DataTable dtMyTableCertificate2;
    static DataTable dtMyTableCertificate4;

    int Applicationid = 0;

    static DataTable dtMyTableCertificate5;
    TSIICPLOTCGG.TSPlotDetailsService plotvo = new TSIICPLOTCGG.TSPlotDetailsService();

    double emd = 0;

    TSIICLANDCGG.LandAllotmentService landservice = new TSIICLANDCGG.LandAllotmentService();

    public DataSet GDs { get; set; }

    public string plotno { get; set; }


    DataSet obj = new DataSet();
    DataTable dtMyPower;
    DataSet dsplotdtls = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

        if (Convert.ToDecimal(ViewState["total"]) != 0)
        {

            TextBox49.Text = ViewState["total"].ToString();

        }
        if(Convert.ToString(Session["uid"])== "378226")
        {
            btntab1next.Enabled = false;
            ddlProp_intDistrictid.Enabled = false;
            btntab1next.Visible = false;
        }
        if (!Page.IsPostBack)
        {
            if (Convert.ToString(Session["uid"]) == "378226")
            {
                btntab1next.Enabled = false;
                ddlProp_intDistrictid.Enabled = false;

                btntab1next.Visible = false;
            }
            ddlprojectcategory1.SelectedIndex = 0;

            dtMyTableCertificate4 = proposedproject();   //createtablecrtificate1();
            Session["Proposedprj"] = dtMyTableCertificate4;

            dtMyTableCertificate2 = createtablecrtificateDir();   //createtablecrtificate1();
            Session["CertificateDir"] = dtMyTableCertificate2;

            dtMyTableCertificate1 = createtablecrtificate();   //createtablecrtificate1();
            Session["Certificate"] = dtMyTableCertificate1;


            dtMyTableCertificate3 = createtablecrtificateDir1();   //createtablecrtificate1();
            Session["CertificateDirTb1"] = dtMyTableCertificate3;

            dtMyTableCertificate5 = createtablecrtificateDir5();   //createtablecrtificate1();
            Session["CertificateDirTb5"] = dtMyTableCertificate5;
            //string[] plotdists = plotvo.getDistricts();
            //string[] plot = plotvo.getDistricts();
            //ddldistrict.DataSource = plotdists;
            //ddldistrict.DataBind();
            //txtfunctionalProposed.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtassetsrs.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtfunctionalliabilites.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtotherassets.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtland.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtbuilding.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtmachinaryimp.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtmachinaryindenous.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtmachinaryauxequ.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtfixedassets.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtContinencies.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtpreliminaryexp.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtworkcapital.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txttotalprojcost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtmalephase1.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");
            txtmalephase2.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");
            txtmalephase3.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");
            txtfemalephase1.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");
            txtfemalephase2.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");
            txtfemalephase3.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");

            txtPlantFactoryBuildings.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtAdministrationBuildings.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtStorageWarehousing.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtRoadsWaterstorage.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtOpenAreasGreenBelt.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txttotalAreaLandRequired.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtPowerrequirements.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtPowerrequirementsphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtPowerrequirementsphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");


            txtContractedmaximumdemand.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtContractedmaximumdemandphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtContractedmaximumdemandphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtRequiredpowersupplyline.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtRequiredpowersupplylinephase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtRequiredpowersupplylinephase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtVoltagerating.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtVoltageratingphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtVoltageratingphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtConnectedload.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtConnectedloadphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtConnectedloadphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtLoadfactor.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtLoadfactorphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtLoadfactorphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtdomesticphase2temp.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtdomesticphase3temp.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtindustrialphase2temp.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtindustrialphasetemp3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtdomesticpermphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtdomesticpermphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtIndustrialPermanentphase2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtIndustrialPermanentphase3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtDomesticTemporary.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtIndustrialTemporary.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtDomesticPermanent.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtIndustrialPermanent.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtcapacitykw.Attributes.Add("onkeypress", "javascript:return ValidateDecimal(event,this);");
            TextBox13.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtdailyconsum.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txteffluentqtyphase1.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txteffluentqtyphase2.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txteffluentqtyphase3.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtsolidwastephase1.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtsolidwastephase2.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtsolidwastephase3.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtcapacitykw.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtdailyconsum.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtinstalledcapacity.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtcost.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");
            txtexperience.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");

            txtquantity.Attributes.Add("onkeypress", "Javascript:return ValidateDecimal(event,this);");

            BindDistricts();
            Bindcategorys();
            getstates();
            bindyears();
            BindenterpriseSectors();
            ActiveIndex(0);
            BindConstitutionunit();


            if (Convert.ToInt64(Request.QueryString["AppId"]) != 0)
            {
                Applicationid = Convert.ToInt32(Request.QueryString["AppId"].ToString());

            }

            else if (Convert.ToInt64(Request.QueryString["ApppId"]) != 0)
            {

                Applicationid = Convert.ToInt32(Request.QueryString["ApppId"].ToString());
                ActiveIndex(4);


            }

            else if (Convert.ToInt32(Session["Applicationid"]) > 0)
            {

                Session.Clear();
                Applicationid = 0;
            }
            else if (Applicationid == 0)
            {

                MainView.ActiveViewIndex = 0;
            }

            if (Applicationid != 0)
            {

                Session["Applicationid"] = Applicationid;
                dsplotdtls = GetSavedPlotdtls(Convert.ToInt64(Session["uid"]), Convert.ToInt64(Session["Applicationid"]));
                FillDetails();

                if (dsplotdtls != null && dsplotdtls.Tables.Count > 0 && dsplotdtls.Tables[0].Rows.Count > 0)
                {
                    Session["Applicationid"] = dsplotdtls.Tables[0].Rows[0]["ApplicationId"].ToString();
                    ddlProp_intDistrictid.SelectedValue = dsplotdtls.Tables[0].Rows[0]["DistrctID"].ToString();
                    ddlProp_intDistrictid_SelectedIndexChanged(sender, e);
                    ddlIndustrialParkName.SelectedValue = dsplotdtls.Tables[0].Rows[0]["IndustrialParkId"].ToString();
                    btntab1next_Click(sender, e);
                    ddlProp_intDistrictid.Enabled = false;
                    ddlIndustrialParkName.Enabled = false;
                    //PlotsReset.Visible = false;

                    if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[1].Rows.Count > 0)
                    {
                        DataTable dts = (DataTable)Session["CertificateDirTb1"];
                        for (int i = 0; i < dsplotdtls.Tables[1].Rows.Count; i++)
                        {
                            string DistrictName = dsplotdtls.Tables[1].Rows[i]["DistrictName"].ToString();
                            string IndustrialParkName = dsplotdtls.Tables[1].Rows[i]["IndustrialParkName"].ToString();
                            string PlotNo = dsplotdtls.Tables[1].Rows[i]["PlotNo"].ToString();
                            string Area_in_Sq_Mtrs = dsplotdtls.Tables[1].Rows[i]["Area_in_Sq_Mtrs"].ToString();
                            string Persqmtsprice = dsplotdtls.Tables[1].Rows[i]["Persqmtsprice"].ToString();
                            string PlotNoID = dsplotdtls.Tables[1].Rows[i]["PlotnoID"].ToString();
                            if (Convert.ToString(Session["uid"]) != "1240")
                            {
                                //AddDataToTableCeertificateDir(DistrictName, IndustrialParkName, PlotNo, Area_in_Sq_Mtrs, Persqmtsprice, PlotNoID, dts);
                            }
                            //if (ddlavailableplots.SelectedItem.Text != )
                            //ddlavailableplots.SelectedItem.Text.Remove(Convert.ToInt32(PlotNo));
                           // ddlavailableplots.Items.Remove(new ListItem(PlotNo, PlotNoID));
                        }
                        Session["CertificateDirTb1"] = dts;
                        if (Convert.ToString(Session["uid"]) != "1240")
                        {
                            //bindfeegrid(dts);
                        }

                        if (dsplotdtls != null && dsplotdtls.Tables.Count > 3 && dsplotdtls.Tables[3].Rows.Count > 0)
                        {


                            bindata(dsplotdtls);


                        }


                        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[5].Rows.Count > 0)
                        {
                            DataTable dt = (DataTable)Session["CertificateDir"];
                            for (int i = 0; i < dsplotdtls.Tables[5].Rows.Count; i++)
                            {
                                string Name = dsplotdtls.Tables[5].Rows[i]["name"].ToString();
                                string Address = dsplotdtls.Tables[5].Rows[i]["Address"].ToString();
                                long contactno = Convert.ToInt64(dsplotdtls.Tables[5].Rows[i]["Contactno"].ToString());
                                string qualif = dsplotdtls.Tables[5].Rows[i]["Qualification"].ToString();
                                string Exp = dsplotdtls.Tables[5].Rows[i]["Experience"].ToString();
                                decimal networth = Convert.ToDecimal(dsplotdtls.Tables[5].Rows[i]["Networth"].ToString());

                                AddDataToTableCeertificate(Name, Address, contactno, qualif, Exp, networth, dt);


                            }

                            Session["CertificateDir"] = dt;
                            dsgvaddl(dt);
                        }

                        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[6].Rows.Count > 0)
                        {
                            DataTable dt1 = (DataTable)Session["Proposedprj"];
                            for (int i = 0; i < dsplotdtls.Tables[6].Rows.Count; i++)
                            {
                                string product = dsplotdtls.Tables[6].Rows[i]["Product"].ToString();
                                string Itemcode = dsplotdtls.Tables[6].Rows[i]["Itemcode"].ToString();

                                string unitmeasurement = dsplotdtls.Tables[6].Rows[i]["Unitmeasurement"].ToString();
                                string installedcapacity = dsplotdtls.Tables[6].Rows[i]["Installedcapacity"].ToString();

                                AddDataToTableCeert(product, Itemcode, unitmeasurement, installedcapacity, dt1);

                            }

                            Session["Proposedprj"] = dt1;
                            prosed(dt1);

                        }

                        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[8].Rows.Count > 0)
                        {
                            DataTable dt5 = (DataTable)Session["CertificateDirTb5"];
                            for (int i = 0; i < dsplotdtls.Tables[8].Rows.Count; i++)
                            {
                                string desitem = dsplotdtls.Tables[8].Rows[i]["descplantmachinery"].ToString();
                                string Itemcode = dsplotdtls.Tables[8].Rows[i]["capacitykw"].ToString();
                                string Quantity = dsplotdtls.Tables[8].Rows[i]["Quantity"].ToString();
                                decimal cost;

                                if (dsplotdtls.Tables[8].Rows[i]["cost"].ToString() == "" || dsplotdtls.Tables[8].Rows[i]["cost"].ToString() == null)
                                {

                                    cost = 0;
                                }
                                else
                                {
                                    cost = Convert.ToDecimal(dsplotdtls.Tables[8].Rows[i]["cost"].ToString());
                                }


                                AddDataToTableCeerticate5(desitem, Itemcode, Quantity, cost, dt5);

                            }

                            Session["CertificateDirTb5"] = dt5;
                            plantmachinery(dt5);
                        }
                        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[7].Rows.Count > 0)
                        {
                            DataTable dt2 = (DataTable)Session["Certificate"];
                            for (int i = 0; i < dsplotdtls.Tables[7].Rows.Count; i++)
                            {
                                string desitem = dsplotdtls.Tables[7].Rows[i]["Descriptionitem"].ToString();
                                string Itemcode = dsplotdtls.Tables[7].Rows[i]["Itemcode"].ToString();

                                string dailyconsumption = dsplotdtls.Tables[7].Rows[i]["DailyConsumption"].ToString();
                                string unitmeasurement = dsplotdtls.Tables[7].Rows[i]["unitmeasurement"].ToString();
                                AddDataToTableCeerticate(desitem, Itemcode, dailyconsumption, unitmeasurement, dt2);

                            }

                            Session["Certificate"] = dt2;
                            Rawed(dt2);
                        }
                    }

                }
            }


            else if (Convert.ToInt64(Request.QueryString["ApId"]) != 0)
            {
                formdata();

            }

        }



    }




    public DataSet GetprojectsTsiic()
    {
        DataSet Dsnew = new DataSet();
        Dsnew = Gen.GenericFillDs("[Getprojects_TSiic]");
        return Dsnew;
    }
    private void Bindcategorys()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlprojectcategory1.Items.Clear();
            dsd = GetprojectsTsiic();
            if (dsd != null & dsd.Tables[0].Rows.Count > 0)
            {

                ddlprojectcategory1.DataSource = dsd.Tables[0];
                ddlprojectcategory1.DataTextField = "projectother";
                ddlprojectcategory1.DataValueField = "id";
                ddlprojectcategory1.DataBind();
            }
            ddlprojectcategory1.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });
        }
        catch (Exception)
        {

            throw;
        }


    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            string[] Districtdt = plotvo.getDistricts();

            DataTable dtDists = new DataTable();
            dtDists.Columns.Add("DistID");
            dtDists.Columns.Add("DistDesc");
            DataRow drDists = dtDists.NewRow();
            //drDists["DistID"] = "0";
            //drDists["DistDesc"] = "---SELECT---";
            dtDists.Rows.Add(drDists);

            foreach (string str in Districtdt)
            {
                DataRow drDist = dtDists.NewRow();
                drDist["DistID"] = str.Split('$')[0].ToString().Trim();
                drDist["DistDesc"] = str.Split('$')[1].ToString().Trim();
                dtDists.Rows.Add(drDist);
            }

            ddlProp_intDistrictid.DataSource = dtDists;
            ddlProp_intDistrictid.DataValueField = "DistID";
            ddlProp_intDistrictid.DataTextField = "DistDesc";
            ddlProp_intDistrictid.DataBind();

            //ddlProp_intDistrictid.DataSource = Districtdt;
            //ddlProp_intDistrictid.DataBind();

            ddlProp_intDistrictid.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });
            //dsd = GetDistrictsTsiic();

        }
        catch (Exception ex)
        {

        }
    }


    protected void grdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public void formdata()
    {

        dsplotdtls = GetSavedPlotdtls(Convert.ToInt64(Session["uid"]), Applicationid);

        dsplotdtls = GetSavedPlotdtls(Convert.ToInt64(Session["uid"]), Convert.ToInt64(Session["Applicationid"]));
        if (dsplotdtls != null && dsplotdtls.Tables.Count > 3 && dsplotdtls.Tables[3].Rows.Count > 0)
        {
            bindata(dsplotdtls);
        }
        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[5].Rows.Count > 0)
        {
            DataTable dt = (DataTable)Session["CertificateDir"];
            for (int i = 0; i < dsplotdtls.Tables[5].Rows.Count; i++)
            {
                string Name = dsplotdtls.Tables[5].Rows[i]["name"].ToString();
                string Address = dsplotdtls.Tables[5].Rows[i]["Address"].ToString();
                long contactno = Convert.ToInt64(dsplotdtls.Tables[5].Rows[i]["Contactno"].ToString());
                string qualif = dsplotdtls.Tables[5].Rows[i]["Qualification"].ToString();
                string Exp = dsplotdtls.Tables[5].Rows[i]["Experience"].ToString();
                decimal networth = Convert.ToDecimal(dsplotdtls.Tables[5].Rows[i]["Networth"].ToString());
                AddDataToTableCeertificate(Name, Address, contactno, qualif, Exp, networth, dt);
            }

            Session["CertificateDir"] = dt;
            dsgvaddl(dt);
        }
        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[6].Rows.Count > 0)
        {
            DataTable dt1 = (DataTable)Session["Proposedprj"];
            for (int i = 0; i < dsplotdtls.Tables[6].Rows.Count; i++)
            {
                string product = dsplotdtls.Tables[6].Rows[i]["Product"].ToString();
                string Itemcode = dsplotdtls.Tables[6].Rows[i]["Itemcode"].ToString();

                string unitmeasurement = dsplotdtls.Tables[6].Rows[i]["Unitmeasurement"].ToString();
                string installedcapacity = dsplotdtls.Tables[6].Rows[i]["Installedcapacity"].ToString();
                AddDataToTableCeert(product, Itemcode, unitmeasurement, installedcapacity, dt1);

            }

            Session["Proposedprj"] = dt1;
            prosed(dt1);

        }

        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[8].Rows.Count > 0)
        {
            DataTable dt5 = (DataTable)Session["CertificateDirTb5"];
            for (int i = 0; i < dsplotdtls.Tables[8].Rows.Count; i++)
            {
                string desitem = dsplotdtls.Tables[8].Rows[i]["descplantmachinery"].ToString();
                string Itemcode = dsplotdtls.Tables[8].Rows[i]["capacitykw"].ToString();

                string Quantity = dsplotdtls.Tables[8].Rows[i]["Quantity"].ToString();
                decimal cost = Convert.ToDecimal(dsplotdtls.Tables[8].Rows[i]["cost"].ToString());

                AddDataToTableCeerticate5(desitem, Itemcode, Quantity, cost, dt5);

            }

            Session["CertificateDirTb5"] = dt5;
            plantmachinery(dt5);
        }
        if (dsplotdtls != null && dsplotdtls.Tables.Count > 1 && dsplotdtls.Tables[7].Rows.Count > 0)
        {
            DataTable dt2 = (DataTable)Session["Certificate"];
            for (int i = 0; i < dsplotdtls.Tables[7].Rows.Count; i++)
            {
                string desitem = dsplotdtls.Tables[7].Rows[i]["Descriptionitem"].ToString();
                string Itemcode = dsplotdtls.Tables[7].Rows[i]["Itemcode"].ToString();

                string dailyconsumption = dsplotdtls.Tables[7].Rows[i]["DailyConsumption"].ToString();
                string unitmeasurement = dsplotdtls.Tables[7].Rows[i]["unitmeasurement"].ToString();
                AddDataToTableCeerticate(desitem, Itemcode, dailyconsumption, unitmeasurement, dt2);
            }

            Session["Certificate"] = dt2;
            Rawed(dt2);

        }
    }

    protected void Addlpromotordetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public DataSet GetSavedPlotdtls(Int64 uid, Int64 appid)
    {
        try
        {
            DataSet ds = new DataSet();
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@Createdby",SqlDbType.Int),
                new SqlParameter("@Appid",SqlDbType.Int),

                };
            p[0].Value = uid;
            p[1].Value = appid;

            ds = Gen.GenericFillDs("USP_GET_PLOTDETAILS_USERID", p);
            return ds;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }




    public void FillDetails()
    {




        dsplotdtls = GetSavedPlotdtls(Convert.ToInt64(Session["uid"]), Convert.ToInt64(Session["Applicationid"]));


        DataSet ds = new DataSet();
        ds.Merge(dsplotdtls);





        int c = dsplotdtls.Tables[4].Rows.Count;
        string sen, sen1, sen2, senid;

        int i = 0;


        DataTable dt1 = new DataTable();
        dt1.Columns.Add("link");
        dt1.Columns.Add("FileName");

        DataTable dt2 = new DataTable();
        dt2.Columns.Add("link");
        dt2.Columns.Add("FileName");

        while (i < c)
        {
            senid = dsplotdtls.Tables[4].Rows[i][0].ToString();
            sen2 = dsplotdtls.Tables[4].Rows[i][2].ToString();
            sen1 = sen2.Replace(@"\", @"/");
            sen = sen1.Replace(@"D:/TS-iPASSFinal/", "/");//sen1.Replace(@"E:/Newfloder(2)\", "~/");

            if (senid.Contains("15"))
            {
                HyperLink1.NavigateUrl = sen;
                HyperLink1.Text = dsplotdtls.Tables[4].Rows[i][1].ToString();
                Label444.Text = dsplotdtls.Tables[4].Rows[i][1].ToString();

                Label444.Visible = false;

            }


            if (senid.Contains("14"))
            {
                hyprojectupload.NavigateUrl = sen;
                hyprojectupload.Text = dsplotdtls.Tables[4].Rows[i][1].ToString();

                lblprojectupload.Text = dsplotdtls.Tables[4].Rows[i][1].ToString();

                lblprojectupload.Visible = false;

            }

            i++;

        }


    }
    public void bindata(DataSet ds)
    {

        if (ds.Tables[3].Rows.Count > 0)
        {
            txtDoorNo.Text = ds.Tables[3].Rows[0]["Door_No_RegOffice"].ToString();
            txtstreetName.Text = ds.Tables[3].Rows[0]["Street_1_RegOffice"].ToString();
            txtstreetName2.Text = ds.Tables[3].Rows[0]["Street_2_RegOffice"].ToString();

            getstates();
            ddlstate.SelectedValue = ds.Tables[3].Rows[0]["state_regoffice"].ToString();
            ddlstateContact.SelectedValue = ds.Tables[3].Rows[0]["state_cont_info"].ToString();
            ddlstateComm.SelectedValue = ds.Tables[3].Rows[0]["state_CommAddr"].ToString();

            if (ddlstate.SelectedValue == "31")
            {
                dist1.Visible = true;
                getdistricts();
                ddldistrict.SelectedValue = ds.Tables[3].Rows[0]["Distid_regoffice"].ToString();


                mandal1.Visible = true;
                getMandals();
                ddlMandal.SelectedValue = ds.Tables[3].Rows[0]["Mandal_RegOffice"].ToString();

                vill1.Visible = true;
                getVillages();
                ddlvillage.SelectedValue = ds.Tables[3].Rows[0]["village_regoffice"].ToString();
            }
            else
            {
                dist.Visible = true;
                txtDistrict.Text = ds.Tables[3].Rows[0]["DistName_RegOffice"].ToString();
                mandal.Visible = true;
                txtMandal.Text = ds.Tables[3].Rows[0]["MandalName_RegOffice"].ToString();
                Vill.Visible = true;
                txtVillage.Text = ds.Tables[3].Rows[0]["VillageName_RegOffice"].ToString();

            }


            txtuidno.Text = ds.Tables[3].Rows[0]["processtechnology"].ToString();
            txtprocesstechnology.Text = ds.Tables[3].Rows[0]["processtechnologysteam"].ToString();

            rdIaLa_Lst.SelectedValue = ds.Tables[3].Rows[0]["technicalcollabration"].ToString();
            txtprovidedetails.Text = ds.Tables[3].Rows[0]["providedetails"].ToString();

            if (ddlstateComm.SelectedValue == "31")
            {
                dist1comm.Visible = true;
                getdistrictscomm();

                ddldistrictComm.SelectedValue = ds.Tables[3].Rows[0]["Distid_CommAddr"].ToString();
                mandal1comm.Visible = true;
                getMandalsComm();
                ddlMandalComm.SelectedValue = ds.Tables[3].Rows[0]["mandal_commaddr"].ToString();
                vill1comm.Visible = true;
                getVillagesComm();
                ddlvillageComm.SelectedValue = ds.Tables[3].Rows[0]["village_commaddr"].ToString();
            }
            else
            {

                distcomm.Visible = true;
                txtDistrictComm.Text = ds.Tables[3].Rows[0]["DistName_CommAddr"].ToString();
                mandalComm.Visible = true;
                txtMandalComm.Text = ds.Tables[3].Rows[0]["MandalName_CommAddr"].ToString();
                Villcomm.Visible = true;
                txtVillageComm.Text = ds.Tables[3].Rows[0]["VillageName_CommAddr"].ToString();

            }

            if (ddlstateContact.SelectedValue == "31")
            {
                dist1Contact.Visible = true;
                getdistrictsContact();
                ddldistrictContact.SelectedValue = ds.Tables[3].Rows[0]["Distid_cont_info"].ToString();
                mandal1Contact.Visible = true;
                getMandalsContact();
                ddlMandalContact.SelectedValue = ds.Tables[3].Rows[0]["Mandal_Cont_info"].ToString();
                vill1Contact.Visible = true;
                getVillagesContact();
                ddlvillageContact.SelectedValue = ds.Tables[3].Rows[0]["Village_Cont_info"].ToString();
            }
            else
            {

                distContact.Visible = true;
                txtDistrictContact.Text = ds.Tables[3].Rows[0]["DistName_Cont_info"].ToString();
                mandalContact.Visible = true;

                txtMandalContact.Text = ds.Tables[3].Rows[0]["MandalName_Cont_info"].ToString();
                VillContact.Visible = true;

                txtVillageContact.Text = ds.Tables[3].Rows[0]["VillageName_Cont_info"].ToString();
            }

            rbtaddress.SelectedValue = ds.Tables[3].Rows[0]["DiffCommunicationAddr_Flag"].ToString();

            txtPincode.Text = ds.Tables[3].Rows[0]["Pincode_RegOffice"].ToString();
            string categoryvalues = ds.Tables[3].Rows[0]["Category_RegOffice"].ToString();
            if (categoryvalues != "")
            {
                string[] arraycat = categoryvalues.Split(',');
                foreach (string value in arraycat)
                {
                    int itemindx = lstboxCategory.Items.IndexOf(lstboxCategory.Items.FindByValue(value));
                    lstboxCategory.Items[itemindx].Selected = true;
                }
            }

            txtdomestic.Text = ds.Tables[3].Rows[0]["Domestic"].ToString();
            txtforeigns.Text = ds.Tables[3].Rows[0]["Foreigns"].ToString();
            txtequity.Text = ds.Tables[3].Rows[0]["TotalEquity"].ToString();
            txtamount.Text = ds.Tables[3].Rows[0]["Amount"].ToString();
            txtname.Text = ds.Tables[3].Rows[0]["EquityName"].ToString();
            txteuitdebit.Text = ds.Tables[3].Rows[0]["TotalEquitdebit"].ToString();
            txtforeign.Text = ds.Tables[3].Rows[0]["Foreigninvestment"].ToString();
            txtforeigndate.Text = ds.Tables[3].Rows[0]["Foreigninvestmentdate"].ToString();
            txtIEM.Text = ds.Tables[3].Rows[0]["IEM"].ToString();
            txtIEMdate.Text = ds.Tables[3].Rows[0]["IEMdate"].ToString();
            txtloi.Text = ds.Tables[3].Rows[0]["LOI"].ToString();
            txtloidate.Text = ds.Tables[3].Rows[0]["LOIdate"].ToString();
            txteou.Text = ds.Tables[3].Rows[0]["EOUNo"].ToString();
            txteoudate.Text = ds.Tables[3].Rows[0]["EOUdate"].ToString();
            TextBox1.Text = ds.Tables[3].Rows[0]["tstranscosupply"].ToString();
            TextBox2.Text = ds.Tables[3].Rows[0]["owngeneration"].ToString();
            TextBox3.Text = ds.Tables[3].Rows[0]["DGset"].ToString();
            ddlYearofEstablishment.Text = ds.Tables[3].Rows[0]["YearofEstablishment_Firmregistration"].ToString();

            ddlYearofCommencement.Text = ds.Tables[3].Rows[0]["YearofCommencement_Firmregistration"].ToString();

            txtfirmregno.Text = ds.Tables[3].Rows[0]["RegistrationNo_Firmregistration"].ToString();

            txtEmail.Text = ds.Tables[3].Rows[0]["Email_Cont_info"].ToString();

            txtRegAuthority.Text = ds.Tables[3].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
            txtsurname.Text = ds.Tables[3].Rows[0]["Surname_Cont_info"].ToString();

            txtFirstName.Text = ds.Tables[3].Rows[0]["FirstName_Cont_info"].ToString();

            txtmobileNoContactnew.Text = ds.Tables[3].Rows[0]["MobileNo_Cont_info"].ToString();
            txtmobileNo1.Text = ds.Tables[3].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            txtmobileNo.Text = ds.Tables[3].Rows[0]["TelephonoNo2_RegOffice"].ToString();
            txtOraganisationgovt.Text = ds.Tables[3].Rows[0]["GovtDeptName_RegOffice"].ToString();

            txtDoorNoContact.Text = ds.Tables[3].Rows[0]["Door_No_Cont_info"].ToString();
            txtAltmobileno1.Text = ds.Tables[3].Rows[0]["FaxNo1_RegOffice"].ToString();
            txtAltmobileno.Text = ds.Tables[3].Rows[0]["FaxNo2_RegOffice"].ToString();

            TextBox49.Text = ds.Tables[3].Rows[0]["Industrialshedarea"].ToString();

            RadioButtonList1.SelectedValue = ds.Tables[3].Rows[0]["highpressurevessel"].ToString();
            TextBox13.Text = ds.Tables[3].Rows[0]["noofvessels"].ToString();

            txteffluentqtyphase1.Text = ds.Tables[3].Rows[0]["Effluentsphase1"].ToString();

            txteffluentqtyphase2.Text = ds.Tables[3].Rows[0]["Effluentsphase2"].ToString();

            txteffluentqtyphase3.Text = ds.Tables[3].Rows[0]["Effluentsphase3"].ToString();

            txtsolidwastephase1.Text = ds.Tables[3].Rows[0]["SoildWastephase1"].ToString();
            txtsolidwastephase2.Text = ds.Tables[3].Rows[0]["SoildWastephase2"].ToString();
            txtsolidwastephase3.Text = ds.Tables[3].Rows[0]["SoildWastephase3"].ToString();
            txtdesceffluents.Text = ds.Tables[3].Rows[0]["Descriptioneffulents"].ToString();
            txtstreetNameContact.Text = ds.Tables[3].Rows[0]["Street_1_Cont_info"].ToString();
            txtstreetName2Contact.Text = ds.Tables[3].Rows[0]["Street_2_Cont_info"].ToString();
            txtDoorNoComm.Text = ds.Tables[3].Rows[0]["Door_No_CommAddr"].ToString();
            txtstreetName2Comm.Text = ds.Tables[3].Rows[0]["Street_2_CommAddr"].ToString();
            txtstreetNameComm.Text = ds.Tables[3].Rows[0]["Street_1_CommAddr"].ToString();
            //  txtPrvplotNo.Text = ds.Tables[3].Rows[0]["PlotNo"].ToString();
            TxtNameOftheFirmApplicant.Text = ds.Tables[3].Rows[0]["NameOftheFirm_Applicant"].ToString();
            ddlConst_of_unit.SelectedValue = ds.Tables[3].Rows[0]["TypeofOrganization_RegOffice"].ToString();
            txtPincodeComm.Text = ds.Tables[3].Rows[0]["Pincode_CommAddr"].ToString();

            txtmobileNo1Comm.Text = ds.Tables[3].Rows[0]["TelephonoNo1_CommAddr"].ToString();

            txtmobileNoComm.Text = ds.Tables[3].Rows[0]["TelephonoNo2_CommAddr"].ToString();

            txtAltmobileno1Comm.Text = ds.Tables[3].Rows[0]["FaxNo1_CommAddr"].ToString();
            txtAltmobilenoComm.Text = ds.Tables[3].Rows[0]["FaxNo2_CommAddr"].ToString();
            txtHouse.Text = ds.Tables[3].Rows[0]["House_Prv_flot"].ToString();
            txtPrvplotNo.Text = ds.Tables[3].Rows[0]["PlotNo_Prv_flot"].ToString();
            txtshop.Text = ds.Tables[3].Rows[0]["Shop_Prv_flot"].ToString();
            txtshed.Text = ds.Tables[3].Rows[0]["ShedName_Prv_flot"].ToString();
            txtprvother.Text = ds.Tables[3].Rows[0]["OtherDetails_Prv_flot"].ToString();
            txtstatusprv.Text = ds.Tables[3].Rows[0]["StatusAllotted_Lease_Name_Prv_flot"].ToString();
            //verifyFirmvo.categoryOfAllotment = ds.Tables[3].Rows[0]["TypeofOrganization_RegOffice"].ToString();


            txtRegAuthority.Text = ds.Tables[3].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
            txtfirmregno.Text = ds.Tables[3].Rows[0]["RegistrationNo_Firmregistration"].ToString();
            ddlYearofEstablishment.SelectedValue = ds.Tables[3].Rows[0]["YearofEstablishment_Firmregistration"].ToString();
            ddlYearofCommencement.SelectedValue = ds.Tables[3].Rows[0]["YearofCommencement_Firmregistration"].ToString();
            txtEmail.Text = ds.Tables[3].Rows[0]["Email_Cont_info"].ToString();
            ddlprojectcategory.SelectedValue = ds.Tables[3].Rows[0]["ProjectCategory1_General_Info"].ToString();
            ddmanu_SelectedIndexChanged(this, EventArgs.Empty);
            txtProjectNameDescription.Text = ds.Tables[3].Rows[0]["ProjectName_Description_General_Info"].ToString();
            ddlproposal.SelectedValue = ds.Tables[3].Rows[0]["ProjectStatus_General_Info"].ToString();
            ddlSector_Ent.SelectedValue = ds.Tables[3].Rows[0]["TypeofVenture_General_Info"].ToString();
            ddlprojectcategory1.SelectedValue = ds.Tables[3].Rows[0]["ProjectCategory2_General_Info"].ToString();
            txtProjectcategorytext.Text = ds.Tables[3].Rows[0]["ProjectCategory3_General_Info"].ToString();
            txtdatecommercialoperations.Text = ds.Tables[3].Rows[0]["DtCommencement_Commercial_Operations_General_Info_DT"].ToString();
            txtdatecommencementconstruction.Text = ds.Tables[3].Rows[0]["Expected_Dt_Commencement_Construction_General_Info_DT"].ToString();
            txtdatetrialoperations.Text = ds.Tables[3].Rows[0]["Expected_Dt_Trial_Operations_General_Info_DT"].ToString();
            txtdatecommercialoperationsphase2.Text = ds.Tables[3].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString();
            txtdatecommencementconstructionphase2.Text = ds.Tables[3].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString();
            txtdatetrialoperationsphase2.Text = ds.Tables[3].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString();
            txtdatecommercialoperationsphase3.Text = ds.Tables[3].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString();
            txtdatecommencementconstructionphase3.Text = ds.Tables[3].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString();
            txtdatetrialoperationsphase3.Text = ds.Tables[3].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString();
            txtland.Text = ds.Tables[3].Rows[0]["Land_Project_Cost_Lakhs"].ToString();
            txtbuilding.Text = ds.Tables[3].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString();
            txtContinencies.Text = ds.Tables[3].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString();
            txtmachinaryauxequ.Text = ds.Tables[3].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString();
            txtmachinaryindenous.Text = ds.Tables[3].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString();
            txtmachinaryimp.Text = ds.Tables[3].Rows[0]["Imported_Project_Cost_Lakhs"].ToString();
            txtworkcapital.Text = ds.Tables[3].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString();
            txtpreliminaryexp.Text = ds.Tables[3].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString();
            txtfixedassets.Text = ds.Tables[3].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString();
            txttotalprojcost.Text = ds.Tables[3].Rows[0]["Total_Project_Cost_Lakhs"].ToString();
            txtMaximumempfactory.Text = ds.Tables[3].Rows[0]["Workers_factory_emp"].ToString();
            txtSkilledemp.Text = ds.Tables[3].Rows[0]["Skilled_Emp"].ToString();
            txtSupervisoryemp.Text = ds.Tables[3].Rows[0]["Supervisory_Emp"].ToString();
            txttotalempdirect.Text = ds.Tables[3].Rows[0]["Total_Emp"].ToString();
            txtManagerialemp.Text = ds.Tables[3].Rows[0]["Managerial_Emp"].ToString();
            txtUnskilledemp.Text = ds.Tables[3].Rows[0]["Unskilled_Emp"].ToString();
            txtlandphase2.Text = ds.Tables[3].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString();
            txtbuildingphase2.Text = ds.Tables[3].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString();
            txtContinenciesphase2.Text = ds.Tables[3].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString();
            txtauxilaryequipphase2.Text = ds.Tables[3].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString();
            txtmachinaryindenousphase2.Text = ds.Tables[3].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString();
            txtmachinaryimpphase2.Text = ds.Tables[3].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString();
            txtworkcapitalphase2.Text = ds.Tables[3].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString();
            txtpreliminaryexpphase2.Text = ds.Tables[3].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString();
            txtfixedassetsphase2.Text = ds.Tables[3].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString();
            txttotalprojcostphase2.Text = ds.Tables[3].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString();
            txtskilledphase2.Text = ds.Tables[3].Rows[0]["Skilled_Empphase2"].ToString();
            txtsupervisoryphase2.Text = ds.Tables[3].Rows[0]["Supervisory_Empphase2"].ToString();
            txttotalempdirectphase2.Text = ds.Tables[3].Rows[0]["Total_Empphase2"].ToString();
            txtmanagerialphase2.Text = ds.Tables[3].Rows[0]["Managerial_Empphase2"].ToString();
            txtunskilledphase2.Text = ds.Tables[3].Rows[0]["Unskilled_Empphase2"].ToString();
            txtlandphase3.Text = ds.Tables[3].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString();
            txtbuildingphase3.Text = ds.Tables[3].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString();
            txtContinenciesphase3.Text = ds.Tables[3].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString();
            txtauxilaryequipphase3.Text = ds.Tables[3].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString();
            txtmachinaryindenousphase3.Text = ds.Tables[3].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString();
            txtmachinaryimpphase3.Text = ds.Tables[3].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString();
            txtworkcapitalphase3.Text = ds.Tables[3].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString();
            txtpreliminaryexpphase3.Text = ds.Tables[3].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString();
            txtfixedassetsphase3.Text = ds.Tables[3].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString();
            txttotalprojcostphase3.Text = ds.Tables[3].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString();
            txtskilledphase3.Text = ds.Tables[3].Rows[0]["Skilled_Empphase3"].ToString();
            txtsupervisoryphase3.Text = ds.Tables[3].Rows[0]["Supervisory_Empphase3"].ToString();
            txttotalempdirectphase3.Text = ds.Tables[3].Rows[0]["Total_Empphase3"].ToString();
            txtmanagerialphase3.Text = ds.Tables[3].Rows[0]["Managerial_Empphase3"].ToString();
            txtunskilledphase3.Text = ds.Tables[3].Rows[0]["Unskilled_Empphase3"].ToString();
            txtmalephase1.Text = ds.Tables[3].Rows[0]["malephase1"].ToString();
            txtmalephase2.Text = ds.Tables[3].Rows[0]["malephase2"].ToString();
            txtmalephase3.Text = ds.Tables[3].Rows[0]["malephase3"].ToString();
            txtfemalephase1.Text = ds.Tables[3].Rows[0]["femalephase1"].ToString();
            txtfemalephase2.Text = ds.Tables[3].Rows[0]["femalephase2"].ToString();
            txtfemalephase3.Text = ds.Tables[3].Rows[0]["femalephase3"].ToString();
            txtAdministrationBuildings.Text = ds.Tables[3].Rows[0]["AdministrationBuildings_LandRequired"].ToString();
            txtRoadsWaterstorage.Text = ds.Tables[3].Rows[0]["RoadsWaterstorage_LandRequired"].ToString();
            txtPlantFactoryBuildings.Text = ds.Tables[3].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString();
            txtStorageWarehousing.Text = ds.Tables[3].Rows[0]["StorageWarehousing_LandRequired"].ToString();
            txttotalAreaLandRequired.Text = ds.Tables[3].Rows[0]["Total_LandRequired"].ToString();

            txtOpenAreasGreenBelt.Text = ds.Tables[3].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString();
            txtRequiredpowersupplyline.Text = ds.Tables[3].Rows[0]["Req_PowerSupply_KV"].ToString();
            txtPowerrequirements.Text = ds.Tables[3].Rows[0]["TSTRANSCO_Energy_KVA"].ToString();
            txtVoltagerating.Text = ds.Tables[3].Rows[0]["VoltageRating_HT"].ToString();
            txtLoadfactor.Text = ds.Tables[3].Rows[0]["Loadfactor"].ToString();
            txtConnectedload.Text = ds.Tables[3].Rows[0]["Connectedload_KW"].ToString();
            txtContractedmaximumdemand.Text = ds.Tables[3].Rows[0]["ContractedMaxDem_KVA"].ToString();
            txtConstructionphasedate.Text = ds.Tables[3].Rows[0]["Dt_Construction_PowerSupply_DT"].ToString();
            txtCommercialproductiondate.Text = ds.Tables[3].Rows[0]["Dt_Commercial_PowerSupply_DT"].ToString();


            txtAdministrationBuildingsphase2.Text = ds.Tables[3].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString();
            txtRoadsWaterstoragephase2.Text = ds.Tables[3].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString();
            txtPlantFactoryBuildingsphase2.Text = ds.Tables[3].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString();
            txtStorageWarehousingphase2.Text = ds.Tables[3].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString();
            txttotalAreaLandRequiredphase2.Text = ds.Tables[3].Rows[0]["Total_LandRequiredphase2"].ToString();
            txtOpenAreasGreenBeltphase2.Text = ds.Tables[3].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString();
            txtRequiredpowersupplylinephase2.Text = ds.Tables[3].Rows[0]["Req_PowerSupply_KVphase2"].ToString();
            txtPowerrequirementsphase2.Text = ds.Tables[3].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString();
            txtVoltageratingphase2.Text = ds.Tables[3].Rows[0]["VoltageRating_HTphase2"].ToString();
            txtLoadfactorphase2.Text = ds.Tables[3].Rows[0]["Loadfactorphase2"].ToString();
            txtConnectedloadphase2.Text = ds.Tables[3].Rows[0]["Connectedload_KWphase2"].ToString();
            txtContractedmaximumdemandphase2.Text = ds.Tables[3].Rows[0]["ContractedMaxDem_KVAphase2"].ToString();
            txtConstructionphasedatephase2.Text = ds.Tables[3].Rows[0]["Dt_Construction_PowerSupplyphase2_DT"].ToString();
            txtCommercialproductiondatephase2.Text = ds.Tables[3].Rows[0]["Dt_Commercial_PowerSupplyphase2_DT"].ToString();

            txtAdministrationBuildingsphase3.Text = ds.Tables[3].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString();
            txtRoadsWaterstoragephase3.Text = ds.Tables[3].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString();
            txtPlantFactoryBuildingsphase3.Text = ds.Tables[3].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString();
            txtStorageWarehousingphase3.Text = ds.Tables[3].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString();
            txttotalAreaLandRequiredphase3.Text = ds.Tables[3].Rows[0]["Total_LandRequiredphase3"].ToString();
            txtOpenAreasGreenBeltphase3.Text = ds.Tables[3].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString();
            txtRequiredpowersupplylinephase3.Text = ds.Tables[3].Rows[0]["Req_PowerSupply_KVphase3"].ToString();
            txtPowerrequirementsphase3.Text = ds.Tables[3].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString();
            txtVoltageratingphase3.Text = ds.Tables[3].Rows[0]["VoltageRating_HTphase3"].ToString();
            txtLoadfactorphase3.Text = ds.Tables[3].Rows[0]["Loadfactorphase3"].ToString();
            txtConnectedloadphase3.Text = ds.Tables[3].Rows[0]["Connectedload_KWphase3"].ToString(); //
            txtContractedmaximumdemandphase3.Text = ds.Tables[3].Rows[0]["ContractedMaxDem_KVAphase3"].ToString();
            txtConstructionphasedatephase3.Text = ds.Tables[3].Rows[0]["Dt_Construction_PowerSupplyphase3_DT"].ToString();
            txtCommercialproductiondatephase3.Text = ds.Tables[3].Rows[0]["Dt_Commercial_PowerSupplyphase3_DT"].ToString();


            txtmobileNo1Contact.Text = ds.Tables[3].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            txtmobileNoContact.Text = ds.Tables[3].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            txtPincodeContact.Text = ds.Tables[3].Rows[0]["Pincode_Cont_info"].ToString();
            txtfaxone.Text = ds.Tables[3].Rows[0]["FaxNo1_Cont_info"].ToString();


            txtDomesticPermanent.Text = ds.Tables[3].Rows[0]["Domestic_Perm_WaterReq"].ToString();
            txtDomesticTemporary.Text = ds.Tables[3].Rows[0]["Domestic_Temp_WaterReq"].ToString();
            txtIndustrialTemporary.Text = ds.Tables[3].Rows[0]["Industrial_Temp_WaterReq"].ToString();
            txtIndustrialPermanent.Text = ds.Tables[3].Rows[0]["Industrial_Perm_WaterReq"].ToString();


            txtdomesticpermphase2.Text = ds.Tables[3].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString();
            txtdomesticphase2temp.Text = ds.Tables[3].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString();
            txtindustrialphase2temp.Text = ds.Tables[3].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString();
            txtIndustrialPermanentphase2.Text = ds.Tables[3].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString();

            txtdomesticpermphase3.Text = ds.Tables[3].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString();
            txtdomesticphase3temp.Text = ds.Tables[3].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString();
            txtindustrialphasetemp3.Text = ds.Tables[3].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString();
            txtIndustrialPermanentphase3.Text = ds.Tables[3].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString();


            txtfaxonenew.Text = ds.Tables[3].Rows[0]["FaxNo2_Cont_info"].ToString();


            txtpannofinancial.Text = ds.Tables[3].Rows[0]["PanNumber_Financial_Info"].ToString();
            txtfinancialotherinfo.Text = ds.Tables[3].Rows[0]["Anyother_Financial_Info"].ToString();
            txtassetsrs.Text = ds.Tables[3].Rows[0]["Assets_Financial_Inlakhs"].ToString();
            txtotherassets.Text = ds.Tables[3].Rows[0]["OtherAssets_Financial_Inlakhs"].ToString();
            txtfunctionalliabilites.Text = ds.Tables[3].Rows[0]["Liabilities_Financial_Inlakhs"].ToString();
            txtGst.Text = ds.Tables[3].Rows[0]["GSTNumber"].ToString();
            txtassetsland.Text = ds.Tables[3].Rows[0]["Immovable_Assets_Land_Building_Financial"].ToString();
            txtfunctionalProposed.Text = ds.Tables[3].Rows[0]["ProposedProject_Financial"].ToString();


            txtIfsccode.Text = ds.Tables[3].Rows[0]["Ifsccode"].ToString();
            txtAccountHolderName.Text = ds.Tables[3].Rows[0]["AccountHolderName"].ToString();
            txtTypeAccount.Text = ds.Tables[3].Rows[0]["TypeofAccount"].ToString();
            txtBankName.Text = ds.Tables[3].Rows[0]["BankName"].ToString();
            txtBankBranchName.Text = ds.Tables[3].Rows[0]["BranchName"].ToString();
            txtBanAccNO.Text = ds.Tables[3].Rows[0]["AccountNo"].ToString();

        }
    }
    private void BindIndustrialParks()
    {
        try
        {
            DataSet dsParks = new DataSet();
            //int DistrictCd = Convert.ToInt64(ddlProp_intDistrictid.SelectedValue);
            string[] plotdt = plotvo.getIndustrialParks(Convert.ToInt32(ddlProp_intDistrictid.SelectedValue));


            DataTable dtDists = new DataTable();
            dtDists.Columns.Add("DistID");
            dtDists.Columns.Add("DistDesc");
            DataRow drDists = dtDists.NewRow();
            //drDists["DistID"] = "0";
            //drDists["DistDesc"] = "---SELECT---";
            dtDists.Rows.Add(drDists);

            foreach (string str in plotdt)
            {
                DataRow drDist = dtDists.NewRow();
                drDist["DistID"] = str.Split('$')[0].ToString().Trim();
                drDist["DistDesc"] = str.Split('$')[1].ToString().Trim();
                dtDists.Rows.Add(drDist);
            }

            ddlIndustrialParkName.DataSource = dtDists;
            ddlIndustrialParkName.DataValueField = "DistID";
            ddlIndustrialParkName.DataTextField = "DistDesc";
            ddlIndustrialParkName.DataBind();



            //ddlIndustrialParkName.DataSource = plotdt;
            //ddlIndustrialParkName.DataBind();

            ddlIndustrialParkName.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });

            //dsParks = GetIalaList(0,DistrictCd);
            //if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
            //{
            //    ddlIndustrialParkName.DataSource = dsParks.Tables[0];
            //    ddlIndustrialParkName.DataValueField = "IALA_Cd";
            //    ddlIndustrialParkName.DataTextField = "NameofIALA";
            //    ddlIndustrialParkName.DataBind();
            //    AddSelect(ddlIndustrialParkName);
            //}
            //else
            //{
            //    ddlIndustrialParkName.Items.Clear();
            //    AddSelect(ddlIndustrialParkName);
            //}
        }
        catch (Exception ex)
        {

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
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    public DataSet GetDistrictsTsiic()
    {
        DataSet Dsnew = new DataSet();
        Dsnew = Gen.GenericFillDs("[GetDistricts_TSiic]");
        return Dsnew;
    }
    public DataSet GetIalaList(Int64 IALACode, Int64 DistrictCd)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IALA_Cd",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTCD",SqlDbType.VarChar)
           };
        pp[0].Value = IALACode;
        pp[1].Value = DistrictCd;
        Dsnew = Gen.GenericFillDs("USP_GET_IALA_INDUSTRIALPARKS_TSIIC", pp);
        return Dsnew;
    }



    protected DataTable createtablecrtificateDir1()
    {
        dtMyTable = new DataTable("CertificateDirTb1");

        //dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("distid", typeof(string));
        dtMyTable.Columns.Add("indparkid", typeof(string));
        dtMyTable.Columns.Add("plotno", typeof(string));
        dtMyTable.Columns.Add("sqmts", typeof(string));
        dtMyTable.Columns.Add("EMD", typeof(decimal));

        dtMyTable.Columns.Add("price", typeof(string));
        dtMyTable.Columns.Add("Persqmtsprice", typeof(string));
        dtMyTable.Columns.Add("plotid", typeof(string));
        DataRow row;
        row = dtMyTable.NewRow();

        return dtMyTable;
    }

    protected DataTable createtablecrtificateDir5()
    {
        dtMyTable = new DataTable("CertificateDirTb5");


        dtMyTable.Columns.Add("descplantmachinery", typeof(string));
        dtMyTable.Columns.Add("capacitykw", typeof(string));
        dtMyTable.Columns.Add("Quantity", typeof(string));
        dtMyTable.Columns.Add("cost", typeof(decimal));



        DataRow row;
        row = dtMyTable.NewRow();

        return dtMyTable;
    }
    private void AddDataToTableCeerticate5(string PlantMachinery, string capacitykw, string quantity, decimal cost, DataTable myTable2)
    {
        try
        {

            DataRow Row;
            Row = myTable2.NewRow();

            dtMyTable = new DataTable("CertificateDirTb5");

            //Row["new"] = "0";
            Row["descplantmachinery"] = PlantMachinery;
            Row["capacitykw"] = capacitykw;
            Row["Quantity"] = quantity;
            Row["cost"] = cost;




            myTable2.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }



    }



    protected DataTable createtablecrtificateDir()
    {
        dtMyTable1 = new DataTable("CertificateDir");

        //dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable1.Columns.Add("Name", typeof(string));
        dtMyTable1.Columns.Add("Address", typeof(string));
        dtMyTable1.Columns.Add("ContactNo", typeof(Int64));
        dtMyTable1.Columns.Add("Qualification", typeof(string));
        dtMyTable1.Columns.Add("Experience", typeof(string));
        dtMyTable1.Columns.Add("Networth", typeof(decimal));


        DataRow row;
        row = dtMyTable1.NewRow();

        return dtMyTable1;
    }

    protected DataTable createtablecrtificate()
    {
        dtMyTable2 = new DataTable("Certificate");


        dtMyTable2.Columns.Add("Descriptionitem", typeof(string));
        dtMyTable2.Columns.Add("Itemcode", typeof(string));
        dtMyTable2.Columns.Add("DailyConsumption", typeof(string));
        dtMyTable2.Columns.Add("unitmeasurement", typeof(string));



        DataRow row;
        row = dtMyTable2.NewRow();

        return dtMyTable2;
    }

    protected DataTable proposedproject()
    {
        dtMyTable3 = new DataTable("Proposedprj");
        dtMyTable3.Columns.Add("product", typeof(string));
        dtMyTable3.Columns.Add("Itemcode", typeof(string));
        dtMyTable3.Columns.Add("Unitmeasurement", typeof(string));
        dtMyTable3.Columns.Add("Installedcapacity", typeof(string));
        DataRow row;
        row = dtMyTable3.NewRow();

        return dtMyTable3;
    }

    private void AddDataToTableCeert(string product, string productcode, string unitmeasurement, string installedcapacity, DataTable myTable3)
    {
        try
        {

            DataRow Row;
            Row = myTable3.NewRow();

            dtMyTable3 = new DataTable("Proposedprj");

            //Row["new"] = "0";
            Row["product"] = product;
            Row["Itemcode"] = productcode;
            Row["Unitmeasurement"] = unitmeasurement;
            Row["Installedcapacity"] = installedcapacity;



            myTable3.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }



    }




    private void AddDataToTableCeerticate(string description, string itemcode, string dailyconsumption, string measurement, DataTable myTable2)
    {
        try
        {

            DataRow Row;
            Row = myTable2.NewRow();

            dtMyTable2 = new DataTable("Certificate");

            //Row["new"] = "0";
            Row["Descriptionitem"] = description;
            Row["Itemcode"] = itemcode;
            Row["DailyConsumption"] = dailyconsumption;
            Row["unitmeasurement"] = measurement;



            myTable2.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }



    }






    private void AddDataToTableCeertificate(string name, string address, Int64 contactno, string Qualification, string Experience, decimal netwoth, DataTable myTable1)
    {
        try
        {

            DataRow Row;
            Row = myTable1.NewRow();
            dtMyTable1 = new DataTable("CertificateDir");
            Row["Name"] = name;
            Row["Address"] = address;
            Row["ContactNo"] = contactno;
            Row["Qualification"] = Qualification;
            Row["Experience"] = Experience;
            Row["Networth"] = netwoth;
            myTable1.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }



    }



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProp_intDistrictid.SelectedValue != "0")
        {
            BindIndustrialParks();



        }
        else
        {

        }
    }

    public DataSet GetTSIICdata(Int64 uid, Int64 appid, string form)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@createdby",SqlDbType.Int),
                      new SqlParameter("@APPID",SqlDbType.Int),
                 new SqlParameter("@form1",SqlDbType.VarChar),
                };
            p[0].Value = uid;
            p[1].Value = appid;
            p[2].Value = form;



            // XmlDocument doc = new XmlDocument(); USP_GET_RM_ABSTRACTDETAILS

            GDs = Gen.GenericFillDs("USP_GET_tsiiccheckdata", p);




            //GDs.Tables[0].TableName = "CommonFields";
            //GDs.Tables[1].TableName = "DepartmentFlow";
            //GDs.Tables[2].TableName = "RMtype";



            return GDs;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    private void AddDataToTableCeertificateDir(string dist, string indusp, string plot, string area, string price, string PlotnoID, DataTable myTable)
    {
        try
        {
            decimal EMD = 0;
            DataRow Row;
            Row = myTable.NewRow();

            decimal FinalPrice = 0;


            FinalPrice = Convert.ToDecimal(area) * Convert.ToDecimal(price);
            EMD = FinalPrice * Convert.ToDecimal(0.1);
            //Row["new"] = "0";
            Row["distid"] = dist;
            Row["indparkid"] = indusp;
            Row["plotno"] = plot;
            Row["sqmts"] = area;
            Row["EMD"] = EMD;
            Row["price"] = FinalPrice;
            Row["Persqmtsprice"] = price;
            Row["plotid"] = PlotnoID;

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }

    }



    public void AddSelectedplost()
    {

        int valid = 0;
        try
        {


            if (ddlProp_intDistrictid.SelectedItem.Text == "--Select--")
            {
                //lblmsg0.Text = "Please Select Community" + "<br/>";
                //Failure.Visible = true;
                ddlProp_intDistrictid.Focus();
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Select District');", true);
                return;
            }
            if (ddlIndustrialParkName.SelectedItem.Text == "--Select--")
            {
                //lblmsg0.Text = "Please Select Community" + "<br/>";
                //Failure.Visible = true;
                ddlIndustrialParkName.Focus();
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Select Industrial Park*');", true);
                return;
            }
            if (ddlavailableplots.SelectedItem.Text == "--Select--")
            {
                ddlavailableplots.Focus();
                valid = 1;
            }



            if (tdAreasqrmtrs.InnerText == "" || tdAreasqrmtrs.InnerText == null)
            {
                //lblmsg0.Text = "Name Cannot be blank" + "<br/>";
                //Failure.Visible = true;
                tdAreasqrmtrs.Focus();
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Name Cannot be blank');", true);
                return;
            }

            if (tdrssqmtrs.InnerText == "" || tdrssqmtrs.InnerText == null)
            {
                //lblmsg0.Text = "Name Cannot be blank" + "<br/>";
                //Failure.Visible = true;
                tdrssqmtrs.Focus();
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Name Cannot be blank');", true);
                return;
            }
            if (valid == 0)
            {
                // if (ddlProp_intDistrictid.SelectedItem.Text == "--Select--")
                // {


                DataTable dts = (DataTable)Session["CertificateDirTb1"];
                //AddDataToTableCeertificateDir(ddlProp_intDistrictid.SelectedItem.Text, ddlIndustrialParkName.SelectedItem.Text, ddlavailableplots.SelectedItem.Text,
                //    tdAreasqrmtrs.InnerText, tdrssqmtrs.InnerText, dts);
                AddDataToTableCeertificateDir(ddlProp_intDistrictid.SelectedItem.Text, ddlIndustrialParkName.SelectedItem.Text, ddlavailableplots.SelectedItem.Text,
                    tdAreasqrmtrs.InnerText, tdrssqmtrs.InnerText, ddlavailableplots.SelectedValue, dts);

                Session["CertificateDirTb1"] = dts;
                bindfeegrid(dts);
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }

    }

    public void Rawed(DataTable dt)
    {
        DataTable ds = new DataTable();
        ds.Merge(dt);
        rawmaterialconsumption.DataSource = dt;
        rawmaterialconsumption.DataBind();



        rawmaterialconsumption.Visible = true;



    }


    public void plantmachinery(DataTable dt)
    {
        DataTable ds = new DataTable();
        ds.Merge(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();



        GridView2.Visible = true;



    }

    public void prosed(DataTable dt)
    {
        DataTable ds = new DataTable();
        ds.Merge(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();


        GridView1.Visible = true;



    }
    public void dsgvaddl(DataTable dt)
    {
        DataTable dsdata = new DataTable();
        dsdata.Merge(dt);

        Addlpromotordetails.DataSource = dt;
        Addlpromotordetails.DataBind();


        Addlpromotordetails.Visible = true;



    }

    public void bindfeegrid(DataTable dts)
    {
        DataTable dsgvbind = new DataTable();
        dsgvbind.Merge(dts);
        // dsgvbind = dts;

        dsgvbind.TableName = "Shankar";
        decimal AreaTotal = 0, PriceTotal = 0, EMDTotal = 0, Processfee = 0, CGST = 0, SGST = 0, Amounttobepaid = 0, Gst = 0;
        for (int i = 0; i < dsgvbind.Rows.Count; i++)
        {
            AreaTotal = AreaTotal + Convert.ToDecimal(dsgvbind.Rows[i]["sqmts"].ToString());
            PriceTotal = PriceTotal + Convert.ToDecimal(dsgvbind.Rows[i]["price"].ToString());
            EMDTotal = EMDTotal + Convert.ToDecimal(dsgvbind.Rows[i]["EMD"].ToString());
            // if (ddlIndustrialParkName.SelectedValue == "2666" || ddlIndustrialParkName.SelectedValue == "2663" || ddlIndustrialParkName.SelectedValue == "2665"
            //|| ddlIndustrialParkName.SelectedValue == "2667" || ddlIndustrialParkName.SelectedValue == "2668" || ddlIndustrialParkName.SelectedValue == "2669"
            //     || ddlIndustrialParkName.SelectedValue == "2670" || ddlIndustrialParkName.SelectedValue == "2671"
            //     || ddlIndustrialParkName.SelectedValue == "2672" || ddlIndustrialParkName.SelectedValue == "2673"
            //     || ddlIndustrialParkName.SelectedValue == "2675"
            //     )//|| ddlIndustrialParkName.SelectedValue == "2674"  removed on 14/10/2022
            // {
            //     EMDTotal = 0;
            //     PriceTotal = 0;
            // }
        }

        ViewState["total"] = AreaTotal;
        Processfee = Math.Round((EMDTotal * Convert.ToDecimal(0.01)), 2);
        if (Processfee < 1000)
        {
            Processfee = 1000;
        }
        Gst = Math.Round((Processfee * Convert.ToDecimal(0.18)), 2);
        CGST = Math.Round((Gst / Convert.ToDecimal(2.0)), 2);
        SGST = Math.Round((Gst / Convert.ToDecimal(2.0)), 2);

        Amounttobepaid = Gst + Processfee + EMDTotal;

        //if (ddlIndustrialParkName.SelectedValue == "2666" || ddlIndustrialParkName.SelectedValue == "2663" || ddlIndustrialParkName.SelectedValue == "2665"
        //    || ddlIndustrialParkName.SelectedValue == "2667" || ddlIndustrialParkName.SelectedValue == "2668" || ddlIndustrialParkName.SelectedValue == "2669"
        //    || ddlIndustrialParkName.SelectedValue == "2670" || ddlIndustrialParkName.SelectedValue == "2671"
        //        || ddlIndustrialParkName.SelectedValue == "2672" || ddlIndustrialParkName.SelectedValue == "2673"
        //        || ddlIndustrialParkName.SelectedValue == "2675") // || ddlIndustrialParkName.SelectedValue == "2674" removed on 14/10/2022
        //{
        //    EMDTotal = 0;
        //    PriceTotal = 0;
        //    Processfee = 0;
        //    Gst = 0;
        //    CGST = 0;
        //    SGST = 0;

        //    Amounttobepaid = 0;
        //}
        TsiicPropertiesMain VoTsiicPropertiesMain = new TsiicPropertiesMain();
        if (Session["Applicationid"] != null && Session["Applicationid"].ToString() != "" && Session["Applicationid"].ToString() != "0")
        {
            VoTsiicPropertiesMain.ApplicationId = Convert.ToInt32(Session["Applicationid"]);
        }
        else
        {
            VoTsiicPropertiesMain.ApplicationId = Convert.ToInt32("0");
        }

        VoTsiicPropertiesMain.PlotID = ddlavailableplots.SelectedValue;
        VoTsiicPropertiesMain.DistrictId = ddlProp_intDistrictid.SelectedValue;
        VoTsiicPropertiesMain.IndustrialParkId = ddlIndustrialParkName.SelectedValue;
        VoTsiicPropertiesMain.IndustrialParkNAME = ddlIndustrialParkName.SelectedItem.Text;
        //VoTsiicPropertiesMain.DistrictId = ddlProp_intDistrictid.SelectedValue;
        //VoTsiicPropertiesMain.IndustrialParkId = ddlIndustrialParkName.SelectedValue;
        VoTsiicPropertiesMain.Created_by = Session["uid"].ToString();
        VoTsiicPropertiesMain.PlotTotalArea = AreaTotal;
        VoTsiicPropertiesMain.PlotTotalamount = PriceTotal;
        VoTsiicPropertiesMain.TotalEmd = EMDTotal;
        VoTsiicPropertiesMain.CGST = CGST;
        VoTsiicPropertiesMain.SGST = SGST;
        VoTsiicPropertiesMain.ProcessFee = Processfee;
        VoTsiicPropertiesMain.Amounttobepaid = Amounttobepaid;

        ViewState["TsiicPropertiesMain"] = VoTsiicPropertiesMain;


        DataRow Row;
        Row = dsgvbind.NewRow();
        Row["distid"] = "";
        Row["indparkid"] = "";
        Row["plotno"] = "Total ";
        Row["sqmts"] = AreaTotal;
        Row["EMD"] = EMDTotal;
        Row["price"] = PriceTotal;

        dsgvbind.Rows.Add(Row);


        DataRow Row1;
        Row1 = dsgvbind.NewRow();
        Row1["distid"] = "";
        Row1["indparkid"] = "";
        Row1["plotno"] = "";
        Row1["sqmts"] = "";
        Row1["EMD"] = Processfee;
        Row1["price"] = "Process Fee";

        dsgvbind.Rows.Add(Row1);

        DataRow Row2;
        Row2 = dsgvbind.NewRow();
        Row2["distid"] = "";
        Row2["indparkid"] = "";
        Row2["plotno"] = "";
        Row2["sqmts"] = "";
        Row2["EMD"] = CGST;
        Row2["price"] = "CGST";

        dsgvbind.Rows.Add(Row2);

        DataRow Row3;
        Row3 = dsgvbind.NewRow();
        Row3["distid"] = "";
        Row3["indparkid"] = "";
        Row3["plotno"] = "";
        Row3["sqmts"] = "";
        Row3["EMD"] = SGST;
        Row3["price"] = "SGST";

        dsgvbind.Rows.Add(Row3);

        DataRow Row4;
        Row4 = dsgvbind.NewRow();
        Row4["distid"] = "";
        Row4["indparkid"] = "";
        Row4["plotno"] = "";
        Row4["sqmts"] = "";
        Row4["EMD"] = Amounttobepaid;
        Row4["price"] = "Amount to be paid ";

        dsgvbind.Rows.Add(Row4);


        //this.grdDetails.DataSource = dsgvbind.DefaultView;
        this.grdDetails.DataSource = dsgvbind;
        this.grdDetails.DataBind();
        // ClearTxt();

        // dsgvbind.Clear();

        grdDetails.Visible = true;

        DataTable dsgvbindnew = (DataTable)Session["CertificateDirTb1"];
        //lblmsg0.Text = "";
        //Failure.Visible = false;


    }

    //private void plottable( )
    //{
    //    try
    //    {

    //        ViewState["Power_I"] = "0";
    //        dtMyPower = new DataTable("Power_I");

    //        dtMyPower.Columns.Add("DIstid", typeof(string));

    //        dtMyPower.Columns.Add("indparkid", typeof(string));
    //        dtMyPower.Columns.Add("plotno", typeof(string));
    //        dtMyPower.Columns.Add("sqmts", typeof(string));
    //        dtMyPower.Columns.Add("price", typeof(string));
    //        DataRow Row;
    //        Row = dtMyPower.NewRow();



    //        Row["DIstid"] = ddlProp_intDistrictid.SelectedItem.Text;
    //        Row["indparkid"]=ddlIndustrialParkName.SelectedValue;
    //        Row["plotno"] =ddlavailableplots.SelectedItem.Text;
    //        Row["sqmts"] = tdAreasqrmtrs.InnerText;
    //        Row["price"] = tdrssqmtrs.InnerText;
    //        dtMyPower.Rows.Add(Row);

    //        //DataTable dt = (DataTable)ViewState["Customers"];

    //        //dt.Rows.Add(,, ,, tdrssqmtrs.InnerText);

    //        grdDetails.DataSource = dtMyPower;
    //        grdDetails.DataBind();
    //        ViewState["Power_I"] = "1";






    //        }
    ///////
    //    catch (Exception ee)
    //    {
    //    }
    //}


    //private void plottable()
    //{
    //    DataTable dt = new DataTable();
    //    DataRow dr = null;
    //    dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
    //    dt.Columns.Add(new DataColumn("DIstid", typeof(string)));
    //    dt.Columns.Add(new DataColumn("indparkid", typeof(string)));
    //    dt.Columns.Add(new DataColumn("plotno", typeof(string)));
    //    dt.Columns.Add(new DataColumn("sqmts", typeof(string)));
    //    dt.Columns.Add(new DataColumn("price", typeof(string)));
    //    dr = dt.NewRow();

    //    dr["RowNumber"] = 1;
    //    dr["DIstid"] = ddlProp_intDistrictid.SelectedItem.Text;
    //    dr["indparkid"] = ddlIndustrialParkName.SelectedValue;
    //    dr["plotno"] = ddlavailableplots.SelectedItem.Text;
    //    dr["sqmts"] = tdAreasqrmtrs.InnerText;
    //    dr["price"] = tdrssqmtrs.InnerText;
    //    dt.Rows.Add(dr);




    //    ViewState["CurrentTable"] = dt;

    //     grdDetails.DataSource =dt;
    //     grdDetails.DataBind();


    //}





    //public void Getplotdetails(int uid, int appid)
    //{

    //    try
    //    {
    //        SqlParameter[] p = new SqlParameter[] {
    //                new SqlParameter("@Createdby",SqlDbType.Int),
    //            new SqlParameter("@Appid",SqlDbType.Int),

    //            };
    //        p[0].Value = uid;
    //        p[1].Value = appid;



    //        // XmlDocument doc = new XmlDocument(); USP_GET_RM_ABSTRACTDETAILS

    //        dt = Gen.GenericFillDs("USP_select_TSIIC_MAIN_DTLS", p);


    //        if (dt.Tables[0].Rows.Count > 0)
    //        {

    //            grdDetails.DataSource = dt.Tables[0];
    //            grdDetails.DataBind();


    //            Session["CertificateDirTb"] = (DataTable)dt.Tables[0];


    //        }




    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
    //public DataSet GetApplicationdetails(int createdby)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("@createdby", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.SelectCommand.Parameters.AddWithValue("@Loc_of_unitid", Loc_of_unitid);
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}

    protected void btntab1next_Click(object sender, EventArgs e)
    {
        BindAvailablePlots();


    }

    protected void Button5_Click(object sender, EventArgs e)
    {

        if (txtnames.Text == "" || txtaddress.Text == "" || txtcontact.Text == "" || txtqualification.Text == "" || txtexperience.Text == "" || txtnetworth.Text == "")
        {
            string message = "alert('" + "Please Add Additional Promotor details" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        else
        {
            DataTable dt = (DataTable)Session["CertificateDir"];
            AddDataToTableCeertificate(txtnames.Text.ToString(), txtaddress.Text.ToString(), Convert.ToInt64(txtcontact.Text), txtqualification.Text.ToString(),
                txtexperience.Text.ToString(), Convert.ToDecimal(txtnetworth.Text), (DataTable)Session["CertificateDir"]);

            Session["CertificateDir"] = dt;
            dsgvaddl(dt);

        }


        txtnames.Text = " "; txtaddress.Text = ""; txtcontact.Text = " "; txtqualification.Text = ""; txtexperience.Text = ""; txtnetworth.Text = "";



    }


    protected void Button6_Click(object sender, EventArgs e)
    {


        if (txtdesitem.Text == "" || txtitemcode.Text == "" || txtdailyconsum.Text == "" || txtunitfont.Text == "")
        {
            string message = "alert('" + "Please Add  Rawmaterial Consumption  Details" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {

            DataTable dt2 = (DataTable)Session["Certificate"];

            AddDataToTableCeerticate(txtdesitem.Text.ToString(), txtitemcode.Text.ToString(), txtdailyconsum.Text.ToString(),
                txtunitfont.Text.ToString(), (DataTable)Session["Certificate"]);
            Session["Certificate"] = dt2;
            Rawed(dt2);
        }


        txtdesitem.Text = ""; txtitemcode.Text = ""; txtdailyconsum.Text = ""; txtunitfont.Text = "";


    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        if (txtmachinaryplant.Text == "" || txtcapacitykw.Text == "" || txtquantity.Text == "" || txtcost.Text == "")
        {
            string message = "alert('" + "Please Add  Plant and machinery  Details" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {

            DataTable dt5 = (DataTable)Session["CertificateDirTb5"];

            AddDataToTableCeerticate5(txtmachinaryplant.Text.ToString(), txtcapacitykw.Text.ToString(), txtquantity.Text.ToString(),

               Convert.ToDecimal(txtcost.Text.ToString()),
               (DataTable)Session["CertificateDirTb5"]);
            Session["CertificateDirTb5"] = dt5;
            plantmachinery(dt5);
        }
        txtmachinaryplant.Text = ""; txtcapacitykw.Text = ""; txtquantity.Text = ""; txtcost.Text = "";

    }


    protected void Button7_Click(object sender, EventArgs e)
    {

        if (txtproduct.Text == "" || txtproductcode.Text == "" || txtunitmasurement.Text == "" || txtinstalledcapacity.Text == "")
        {
            string message = "alert('" + "Please Add Proposed Project  Details" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        else
        {

            DataTable dt1 = (DataTable)Session["Proposedprj"];

            AddDataToTableCeert(txtproduct.Text.ToString(), txtproductcode.Text.ToString(), txtunitmasurement.Text.ToString(),
                txtinstalledcapacity.Text.ToString(), (DataTable)Session["Proposedprj"]);

            Session["Proposedprj"] = dt1;
            prosed(dt1);
        }

        txtproduct.Text = " "; txtproductcode.Text = " "; txtunitmasurement.Text = " "; txtinstalledcapacity.Text = "";

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void rawmaterialconsumption_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public void checkdropdowndata()
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;
        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand();
        command.Transaction = trans;
        command.Connection = connection;


        try
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "USP_INSERT_TSIIC_checkdpLOT_DTLS]";
            command.Transaction = trans;
            command.Connection = connection;
            command.Parameters.AddWithValue("@ApplicationId", Session["ApplicationId"].ToString());
            //connection.Close();
        }
        catch (Exception ex)
        {


        }

    }


    private void BindAvailablePlots()
    {
        try
        {

            if (ddlIndustrialParkName.SelectedValue != "")
            {
                string[] plotdt = plotvo.getVacantPlots(Convert.ToInt32(ddlIndustrialParkName.SelectedValue));
                DataTable dtDists = new DataTable();
                dtDists.Columns.Add("DistID");
                dtDists.Columns.Add("DistDesc");
                DataRow drDists = dtDists.NewRow();
                //drDists["DistID"] = "0";
                //drDists["DistDesc"] = "---SELECT---";
                dtDists.Rows.Add(drDists);

                foreach (string str in plotdt)
                {
                    DataRow drDist = dtDists.NewRow();
                    drDist["DistID"] = str.Split('$')[0].ToString().Trim();
                    drDist["DistDesc"] = str.Split('$')[1].ToString().Trim();
                    dtDists.Rows.Add(drDist);
                }

                ddlavailableplots.DataSource = dtDists;
                ddlavailableplots.DataValueField = "DistID";
                ddlavailableplots.DataTextField = "DistDesc";
                ddlavailableplots.DataBind();
                AddSelect(ddlavailableplots);


                //if (plotdt != null)
                //{
                //    ddlavailableplots.DataSource = plotdt;

                //    ddlavailableplots.DataBind();
                //    AddSelect(ddlavailableplots);
                //}
                //else
                //{
                //    ddlavailableplots.Items.Clear();
                //    AddSelect(ddlavailableplots);
                //}
                //DataSet dsParks = new DataSet();
                ddlProp_intDistrictid.Enabled = false;
                ddlIndustrialParkName.Enabled = false;

            }


        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlavailableplots_SelectedIndexChanged(object sender, EventArgs e)
    {
        //tsiicplotobj = plotvo.getPlotDetails(ddlProp_intDistrictid.SelectedItem.Text, ddlIndustrialParkName.SelectedItem.Text, ddlavailableplots.SelectedItem.Text);
        try
        {
            if (ddlavailableplots.SelectedValue != "")
            {
                double area = plotvo.getPlotArea(Convert.ToInt32(ddlProp_intDistrictid.SelectedValue), Convert.ToInt32(ddlIndustrialParkName.SelectedValue), Convert.ToInt32(ddlavailableplots.SelectedValue));
                double cost = plotvo.getPlotPrice(Convert.ToInt32(ddlProp_intDistrictid.SelectedValue), Convert.ToInt32(ddlIndustrialParkName.SelectedValue), Convert.ToInt32(ddlavailableplots.SelectedValue));
                tdrssqmtrs.InnerText = Convert.ToString(cost);// tsiicplotobj.landcost.ToString();
                tdAreasqrmtrs.InnerText = Convert.ToString(area);// tsiicplotobj.area.ToString();
                //td1.InnerText = tsiicplotobj.emd.ToString();
                //td2.InnerText = tsiicplotobj.gst.ToString();
                //td3.InnerText = tsiicplotobj.processFee.ToString();
                emd = ((Convert.ToDouble(tdrssqmtrs.InnerText)) * 0.1);
                double processfee = (emd * 0.01);

                if (processfee <= 1000)
                {
                    processfee = 1000;
                }
                else
                {
                    processfee = (emd * 0.001);
                }
                double Gst = (processfee * 0.18);

                double CGST = Gst / 2;
                double SGST = Gst / 2;
                double total = emd + processfee + CGST + SGST;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
        //string Areasqrmtrsstr = "", rssqmtrsstr = "";
        //tdAreasqrmtrs.InnerHtml = Areasqrmtrsstr;
        //tdrssqmtrs.InnerHtml = rssqmtrsstr;
    }
    protected void PlotsReset_Click(object sender, EventArgs e)
    {
        ddlProp_intDistrictid.SelectedValue = "0";
        ddlIndustrialParkName.SelectedItem.Text = "";
        ddlavailableplots.SelectedItem.Text = "";
        tdrssqmtrs.InnerText = "";
        tdrssqmtrs.InnerText = "";
        ddlProp_intDistrictid.Enabled = true;
        ddlIndustrialParkName.Enabled = true;
        grdDetails.DataSource = null;
        string newurl = "frmtsiicplotallotment.aspx?ApId=" + Session["Applicationid"];
        Response.Redirect(newurl);


    }
    protected void BtnAddSelectedplos_Click(object sender, EventArgs e)
    {

        AddSelectedplost();
        var gyy = ddlavailableplots.SelectedValue.ToString();
        ddlavailableplots.Items.Remove(gyy);
        ddlProp_intDistrictid.Enabled = false;
        ddlIndustrialParkName.Enabled = false;
        tdAreasqrmtrs.InnerText = "0.00";
        tdrssqmtrs.InnerText = "0.00";

    }
    public void ActiveIndex(int IndexNew)
    {
        MainView.ActiveViewIndex = IndexNew;
        if (MainView.ActiveViewIndex == 0)
        {
            Tab1.Attributes.Add("class", "active");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");

        }
        if (MainView.ActiveViewIndex == 1)
        {
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "active");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
        }
        if (MainView.ActiveViewIndex == 2)
        {
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "active");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
        }
        if (MainView.ActiveViewIndex == 3)
        {
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "active");
            Tab5.Attributes.Add("class", "");
        }
        if (MainView.ActiveViewIndex == 4)
        {
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "active");
        }

        //if (MainView.ActiveViewIndex == 5)
        //{
        //    Tab1.Attributes.Add("class", "");
        //    Tab2.Attributes.Add("class", "");
        //    Tab3.Attributes.Add("class", "");
        //    Tab4.Attributes.Add("class", "");
        //    Tab5.Attributes.Add("class", "");
        //    //Tab6.Attributes.Add("class", "active");
        //}
        //if (MainView.ActiveViewIndex == 6)
        //{
        //    Tab1.Attributes.Add("class", "");
        //    Tab2.Attributes.Add("class", "");
        //    Tab3.Attributes.Add("class", "");
        //    Tab4.Attributes.Add("class", "");
        //    Tab5.Attributes.Add("class", "");
        //    //Tab6.Attributes.Add("class", "");

        //}
    }

    public void getstates()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();
        if (ddlstate.SelectedValue.ToString() != "0")
        {
            ddlstate.DataSource = ds.Tables[0];
            ddlstate.DataTextField = "State_Name";
            ddlstate.DataValueField = "State_id";
            ddlstate.DataBind();
            AddSelect(ddlstate);

        }

        if (ddlstateComm.SelectedValue.ToString() != "0")
        {

            ddlstateComm.DataSource = ds.Tables[0];
            ddlstateComm.DataTextField = "State_Name";
            ddlstateComm.DataValueField = "State_id";
            ddlstateComm.DataBind();
            AddSelect(ddlstateComm);
        }
        if (ddlstateContact.SelectedValue.ToString() != "0")
        {
            ddlstateContact.DataSource = ds.Tables[0];
            ddlstateContact.DataTextField = "State_Name";
            ddlstateContact.DataValueField = "State_id";
            ddlstateContact.DataBind();
            AddSelect(ddlstateContact);
        }
    }
    public void BindConstitutionunit()
    {
        try
        {
            ddlConst_of_unit.Items.Clear();
            DataSet dsConstofunit = new DataSet();
            dsConstofunit = objcommon.GetConstitutionunit();
            if (dsConstofunit != null && dsConstofunit.Tables.Count > 0 && dsConstofunit.Tables[0].Rows.Count > 0)
            {
                ddlConst_of_unit.DataSource = dsConstofunit.Tables[0];
                ddlConst_of_unit.DataTextField = "ConstitutionUnit";
                ddlConst_of_unit.DataValueField = "CunitId";
                ddlConst_of_unit.DataBind();
                AddSelect(ddlConst_of_unit);
            }
            else
            {
                ddlConst_of_unit.Items.Clear();
                AddSelect(ddlConst_of_unit);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    protected void btntab2previous_Click(object sender, EventArgs e)
    {
        //lblmsg0.Text = "";
        //Failure.Visible = false;
        Tab1.Attributes.Add("class", "active");
        Tab2.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "");
        Tab4.Attributes.Add("class", "");
        Tab5.Attributes.Add("class", "");
        //Tab6.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 0;
    }

    protected void btntab3previous_Click(object sender, EventArgs e)
    {
        //lblmsg0.Text = "";
        //Failure.Visible = false;
        Tab1.Attributes.Add("class", "");
        Tab2.Attributes.Add("class", "active");
        Tab3.Attributes.Add("class", "");
        Tab4.Attributes.Add("class", "");
        Tab5.Attributes.Add("class", "");
        //Tab6.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 1;
    }

    protected void btntab4previous_Click(object sender, EventArgs e)
    {
        //lblmsg0.Text = "";
        //Failure.Visible = false;
        Tab1.Attributes.Add("class", "");
        Tab2.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "active");
        Tab4.Attributes.Add("class", "");
        Tab5.Attributes.Add("class", "");
        //Tab6.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 2;
    }

    protected void btntab5previous_Click(object sender, EventArgs e)
    {
        //lblmsg0.Text = "";
        //Failure.Visible = false;
        Tab1.Attributes.Add("class", "");
        Tab2.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "");
        Tab4.Attributes.Add("class", "active");
        Tab5.Attributes.Add("class", "");
        //Tab6.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 3;
    }


    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddlstate.SelectedValue.ToString() != "--Select--")
        {
            // getdistricts();

            if (ddlstate.SelectedValue.ToString() == "31")
            {
                getdistricts();

                dist.Visible = false;
                mandal.Visible = false;
                Vill.Visible = false;

                dist1.Visible = true;
                mandal1.Visible = true;
                vill1.Visible = true;


            }
            else
            {
                dist.Visible = true;
                mandal.Visible = true;
                Vill.Visible = true;

                dist1.Visible = false;
                mandal1.Visible = false;
                vill1.Visible = false;

            }


        }
        else
        {
            ddldistrict.Items.Clear();
            AddSelect(ddldistrict);

        }

    }

    //private void GetUdistrict()
    //{
    //    ddlUMandal.Items.Clear();
    //    ddlUVillage.Items.Clear();
    //    if (ddlUDistrict.SelectedValue.ToString() != "0")
    //    {
    //        SqlParameter[] o = new SqlParameter[] {
    //          new SqlParameter("@Dist",SqlDbType.Int)
    //        };
    //        o[0].Value = Convert.ToInt64(ddlUDistrict.SelectedValue);

    //        DataTable dt = Common.GenericFillDataTable("USP_GET_RM_MANDALS", o);

    //        ddlUMandal.DataSource = dt;
    //        ddlUMandal.DataTextField = "Manda_lName";
    //        ddlUMandal.DataValueField = "Mandal_Id";
    //        ddlUMandal.DataBind();
    //    }

    //    ddlUMandal.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });
    //    ddlUVillage.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });
    //}
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }


    //public void txttotalAreaLandRequired_TextChanged(object sender, EventArgs e)
    //    {




    //    }

    //private void AlertMessage(string message)
    //{
    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //    sb.Append("<script type = 'text/javascript'>");
    //    sb.Append("window.onload=function(){");
    //    sb.Append("alert('");
    //    sb.Append(message);
    //    sb.Append("')};");
    //    sb.Append("</script>");
    //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    //}
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlMandal.SelectedValue.ToString() != "--Select--")
        {
            getVillages();

        }
        else
        {
            ddlvillage.Items.Clear();
            AddSelect(ddlvillage);
        }
    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();


        dsnew = Gen.GetDistrictsbystate(ddlstate.SelectedValue.ToString());
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        AddSelect(ddldistrict);

    }
    protected void getdistrictscomm()
    {
        DataSet dsnew = new DataSet();


        dsnew = Gen.GetDistrictsbystate(ddlstateComm.SelectedValue.ToString());
        ddldistrictComm.DataSource = dsnew.Tables[0];
        ddldistrictComm.DataTextField = "District_Name";
        ddldistrictComm.DataValueField = "District_Id";
        ddldistrictComm.DataBind();
        AddSelect(ddldistrictComm);


    }
    protected void getdistrictsContact()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistrictsbystate(ddlstateContact.SelectedValue.ToString());
        ddldistrictContact.DataSource = dsnew.Tables[0];
        ddldistrictContact.DataTextField = "District_Name";
        ddldistrictContact.DataValueField = "District_Id";
        ddldistrictContact.DataBind();
        AddSelect(ddldistrictContact);

    }
    void getMandals()
    {

        DataSet dsnew = new DataSet();
        dsnew = Gen.Getmandalsbydistrict(ddldistrict.SelectedValue.ToString());
        ddlMandal.DataSource = dsnew.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        AddSelect(ddlMandal);


    }
    void getMandalsComm()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddldistrictComm.SelectedValue.ToString());
        ddlMandalComm.DataSource = dsnew.Tables[0];
        ddlMandalComm.DataTextField = "Manda_lName";
        ddlMandalComm.DataValueField = "Mandal_Id";
        ddlMandalComm.DataBind();
        AddSelect(ddlMandalComm);

    }
    void getMandalsContact()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.Getmandalsbydistrict(ddldistrictContact.SelectedValue.ToString());
        ddlMandalContact.DataSource = dsnew.Tables[0];
        ddlMandalContact.DataTextField = "Manda_lName";
        ddlMandalContact.DataValueField = "Mandal_Id";
        ddlMandalContact.DataBind();
        AddSelect(ddlMandalContact);

    }
    void getVillages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlMandal.SelectedValue.ToString());
        ddlvillage.DataSource = dsnew.Tables[0];
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "Village_Id";
        ddlvillage.DataBind();
        AddSelect(ddlvillage);



    }
    void getVillagesComm()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlMandalComm.SelectedValue.ToString());
        ddlvillageComm.DataSource = dsnew.Tables[0];
        ddlvillageComm.DataTextField = "Village_Name";
        ddlvillageComm.DataValueField = "Village_Id";
        ddlvillageComm.DataBind();
        AddSelect(ddlvillageComm);


    }
    void getVillagesContact()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlMandalContact.SelectedValue.ToString());
        ddlvillageContact.DataSource = dsnew.Tables[0];
        ddlvillageContact.DataTextField = "Village_Name";
        ddlvillageContact.DataValueField = "Village_Id";
        ddlvillageContact.DataBind();
        AddSelect(ddlvillageContact);


    }
    public void BindenterpriseSectors()
    {
        try
        {
            ddlSector_Ent.Items.Clear();
            DataSet dsSector = new DataSet();
            dsSector = objcommon.GetenterpriseSectors();
            if (dsSector != null && dsSector.Tables.Count > 0 && dsSector.Tables[0].Rows.Count > 0)
            {
                ddlSector_Ent.DataSource = dsSector.Tables[0];
                ddlSector_Ent.DataTextField = "EnterpriseSector";
                ddlSector_Ent.DataValueField = "EsectorId";
                ddlSector_Ent.DataBind();
                AddSelect(ddlSector_Ent);
            }
            else
            {
                ddlSector_Ent.Items.Clear();
                AddSelect(ddlSector_Ent);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    protected void ddlstateComm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstateComm.SelectedValue.ToString() != "--Select--")
        {
            if (ddlstateComm.SelectedValue.ToString() == "31")
            {



                getdistrictscomm();

                //distcomm.Visible = false;
                //mandalComm.Visible = false;
                //Villcomm.Visible = false;

                dist1comm.Visible = true;
                mandal1comm.Visible = true;
                vill1comm.Visible = true;
            }
            else
            {
                distcomm.Visible = true;
                mandalComm.Visible = true;
                Villcomm.Visible = true;
                dist1comm.Visible = false;
                mandal1comm.Visible = false;
                vill1comm.Visible = false;
            }
        }
        else
        {
            ddldistrictComm.Items.Clear();
            AddSelect(ddldistrictComm);

        }
    }
    protected void ddldistrictComm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrictComm.SelectedValue.ToString() != "--Select--")
        {
            getMandalsComm();
        }
        else
        {
            ddlMandalComm.Items.Clear();
            AddSelect(ddlMandalComm);
        }
    }
    protected void ddlMandalComm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandalComm.SelectedValue.ToString() != "--Select--")
        {
            getVillagesComm();

        }
        else
        {
            ddlvillageComm.Items.Clear();
            AddSelect(ddlvillageComm);
        }
    }
    public DataSet GetYears(string Appstype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@type",SqlDbType.VarChar),
           };
        pp[0].Value = Appstype;
        Dsnew = Gen.GenericFillDs("USP_GET_Tbl_Tsiic_Year_Establishment", pp);
        return Dsnew;
    }
    public void bindyears()
    {
        DataSet Dsnew = new DataSet();
        Dsnew = GetYears("1");
        ddlYearofEstablishment.DataSource = Dsnew.Tables[0];
        ddlYearofEstablishment.DataTextField = "YearName";
        ddlYearofEstablishment.DataValueField = "YearID";
        ddlYearofEstablishment.DataBind();
        AddSelect(ddlYearofEstablishment);


        ddlYearofCommencement.DataSource = Dsnew.Tables[1];
        ddlYearofCommencement.DataTextField = "YearName";
        ddlYearofCommencement.DataValueField = "YearID";
        ddlYearofCommencement.DataBind();
        AddSelect(ddlYearofCommencement);
    }
    protected void ddlstateContact_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstateContact.SelectedValue.ToString() != "--Select--")
        {
            if (ddlstateContact.SelectedValue.ToString() == "31")
            {
                getdistrictsContact();
                distContact.Visible = false;
                mandalContact.Visible = false;
                VillContact.Visible = false;

                dist1Contact.Visible = true;
                mandal1Contact.Visible = true;
                vill1Contact.Visible = true;
            }
            else
            {
                distContact.Visible = true;
                mandalContact.Visible = true;
                VillContact.Visible = true;
                dist1Contact.Visible = false;
                mandal1Contact.Visible = false;
                vill1Contact.Visible = false;
            }
        }
        else
        {
            ddldistrictContact.Items.Clear();
            ddldistrictContact.Items.Insert(0, "--Select--");
        }
    }
    protected void ddldistrictContact_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrictContact.SelectedValue.ToString() != "--Select--")
        {
            getMandalsContact();
        }
        else
        {
            ddlMandalContact.Items.Clear();
            AddSelect(ddlMandalContact);

        }
    }
    protected void ddlMandalContact_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandalContact.SelectedValue.ToString() != "--Select--")
        {
            getVillagesContact();

        }
        else
        {
            ddlvillageContact.Items.Clear();
            AddSelect(ddlvillageContact);

        }
    }
    protected void rbtaddress_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (rbtaddress.SelectedValue == "Y")
        {
            string errormsg = RegisteredAddreecheck();

            if (errormsg.Trim().TrimStart() != "")
            {
                rbtaddress.SelectedValue = "N";

                //string errorms = CommunicationAddresscheck();
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                if (rbtaddress.SelectedValue == "Y")
                {
                    txtDoorNoComm.Text = txtDoorNo.Text.Trim();
                    txtstreetNameComm.Text = txtstreetName.Text.Trim();
                    txtstreetName2Comm.Text = txtstreetName2.Text.Trim();
                    if (ddlstate.SelectedValue == "31")
                    {
                        ddlstateComm.SelectedValue = ddlstate.SelectedValue;
                        ddlstateComm_SelectedIndexChanged(sender, e);
                        ddldistrictComm.SelectedValue = ddldistrict.SelectedValue;
                        ddldistrictComm_SelectedIndexChanged(sender, e);
                        ddlMandalComm.SelectedValue = ddlMandal.SelectedValue;
                        ddlMandalComm_SelectedIndexChanged(sender, e);
                        ddlvillageComm.SelectedValue = ddlvillage.SelectedValue;
                    }
                    else
                    {

                        // distcomm.Visible = true;
                        txtDistrictComm.Text = txtDistrict.Text.Trim();
                        // mandalComm.Visible = true;
                        txtMandalComm.Text = txtMandal.Text.Trim();
                        //  Villcomm.Visible = true;
                        txtVillageComm.Text = txtVillage.Text.Trim();
                    }

                    txtPincodeComm.Text = txtPincode.Text.Trim();
                    txtmobileNo1Comm.Text = txtmobileNo1.Text;
                    txtmobileNoComm.Text = txtmobileNo.Text;
                    txtAltmobileno1Comm.Text = txtAltmobileno1.Text;
                    txtAltmobilenoComm.Text = txtAltmobileno.Text;

                }
                else
                {
                    txtDoorNoComm.Text = "";
                    txtstreetNameComm.Text = "";
                    txtstreetName2Comm.Text = "";


                    if (ddlstate.SelectedValue == "31")
                    {
                        ddldistrictComm.SelectedIndex = 0;
                        ddlMandalComm.Items.Clear();
                        AddSelect(ddlMandalComm);
                        ddlvillageComm.Items.Clear();
                        AddSelect(ddlvillageComm);
                    }
                    else
                    {
                        // distcomm.Visible = false;
                        txtDistrictComm.Text = txtDistrict.Text.Trim();
                        //mandalComm.Visible = false;
                        txtMandalComm.Text = txtMandal.Text.Trim();
                        //Villcomm.Visible = false;
                        txtVillageComm.Text = txtVillage.Text.Trim();
                    }

                    ddlstateComm.SelectedValue = "";
                    txtPincodeComm.Text = "";
                    //txtmobileNo1.Text = "";
                    //txtmobileNo.Text = "";
                    //txtAltmobileno1.Text = "";
                    //txtAltmobileno.Text = "";
                    txtmobileNo1Comm.Text = "";
                    txtmobileNoComm.Text = "";
                    txtAltmobileno1Comm.Text = "";
                    txtAltmobilenoComm.Text = "";
                }
            }
        }
        else
        {

            txtDoorNoComm.Text = "";
            txtstreetNameComm.Text = "";
            txtstreetName2Comm.Text = "";
            if (ddlstate.SelectedValue == "31")
            {
                ddldistrictComm.SelectedIndex = 0;
                ddlMandalComm.Items.Clear();
                AddSelect(ddlMandalComm);
                ddlvillageComm.Items.Clear();
                AddSelect(ddlvillageComm);
            }
            else
            {
                // distcomm.Visible = false;
                txtDistrictComm.Text = txtDistrict.Text.Trim();
                //mandalComm.Visible = false;
                txtMandalComm.Text = txtMandal.Text.Trim();
                //Villcomm.Visible = false;
                txtVillageComm.Text = txtVillage.Text.Trim();
            }
            txtPincodeComm.Text = "";
            //txtmobileNo1.Text = "";
            //txtmobileNo.Text = "";
            //txtAltmobileno1.Text = "";
            //txtAltmobileno.Text = "";

            txtmobileNo1Comm.Text = "";
            txtmobileNoComm.Text = "";
            txtAltmobileno1Comm.Text = "";
            txtAltmobilenoComm.Text = "";

        }
    }
    public string RegisteredAddreecheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (TxtNameOftheFirmApplicant.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name Of the Firm/Applicant \\n";
            slno = slno + 1;
        }
        if (txtDoorNo.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Registered Office Door Number \\n";
            slno = slno + 1;
        }
        if (txtstreetName.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Registered Street1 \\n";
            slno = slno + 1;
        }
        if (ddlstate.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Registered State \\n";
            slno = slno + 1;
        }
        if (ddlstate.SelectedValue != "0" && ddlstate.SelectedValue == "31")
        {
            if (ddldistrict.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Registered District \\n";
                slno = slno + 1;
            }
            if (ddlMandal.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Registered Mandal \\n";
                slno = slno + 1;
            }
            if (ddlvillage.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Registered Village \\n";
                slno = slno + 1;
            }
        }
        else
        {
            if (txtDistrict.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Registered Office District \\n";
                slno = slno + 1;
            }
            if (txtMandal.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Registered Office Mandal \\n";
                slno = slno + 1;
            }
            if (txtVillage.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Registered Office Village \\n";
                slno = slno + 1;
            }
        }

        if (txtPincode.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Registered Office Pincode \\n";
            slno = slno + 1;
        }
        int items = (from ListItem li in lstboxCategory.Items where li.Selected == true select li).Count();
        if (items == 0 || items < 1)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Category Under Registered Office \\n";
            slno = slno + 1;
        }
        if (ddlConst_of_unit.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of Organization Under Registered Office \\n";
            slno = slno + 1;
        }
        else if (ddlConst_of_unit.SelectedValue == "8" && txtOraganisationgovt.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Department Name \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    public string CommunicationAddresscheck()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (txtDoorNoComm.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Communication Office Door Number \\n";
            slno = slno + 1;
        }
        if (txtstreetNameComm.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Communication Street1 \\n";
            slno = slno + 1;
        }
        if (ddlstateComm.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Communication State \\n";
            slno = slno + 1;
        }
        if (ddlstateComm.SelectedValue != "0" && ddlstateComm.SelectedValue == "31")
        {
            if (ddldistrictComm.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Communication District \\n";
                slno = slno + 1;
            }
            if (ddlMandalComm.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Communication Mandal \\n";
                slno = slno + 1;
            }
            if (ddlvillageComm.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Communication Village \\n";
                slno = slno + 1;
            }
        }
        else
        {
            if (txtDistrictComm.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Communication Office District \\n";
                slno = slno + 1;
            }
            if (txtMandalComm.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Communication Office Mandal \\n";
                slno = slno + 1;
            }
            if (txtVillageComm.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Communication Office Village \\n";
                slno = slno + 1;
            }
        }
        if (txtPincodeComm.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Communication Office Pincode \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }

    public string SaveAllFormDtls(string FormNo, Int64 AplicantID)
    {
        int Output = 0;
        TsiicMainApplicantDtls Objdtls = new TsiicMainApplicantDtls();

        Objdtls.Created_by = Session["uid"].ToString().Trim();
        Objdtls.PageSaveNumber = FormNo;
        Objdtls.ApplicationId = AplicantID;
        if (FormNo == "1")
        {
            Objdtls.NameOftheFirm_Applicant = TxtNameOftheFirmApplicant.Text.TrimStart().Trim();
            Objdtls.Door_No_RegOffice = txtDoorNo.Text.TrimStart().Trim();
            Objdtls.Street_1_RegOffice = txtstreetName.Text.TrimStart().Trim();
            Objdtls.Street_2_RegOffice = txtstreetName2.Text.TrimStart().Trim();

            Objdtls.State_RegOffice = Convert.ToInt64(ddlstate.SelectedValue);

            if (ddlstate.SelectedValue == "31")
            {
                Objdtls.Distid_RegOffice = Convert.ToInt64(ddldistrict.SelectedValue);
                Objdtls.Mandal_RegOffice = Convert.ToInt64(ddlMandal.SelectedValue);
                Objdtls.Village_RegOffice = Convert.ToInt64(ddlvillage.SelectedValue);
                Objdtls.OtherState_RegOffice_flag = "N";
            }
            else
            {
                Objdtls.DistName_RegOffice = txtDistrict.Text.TrimStart().Trim();
                Objdtls.MandalName_RegOffice = txtMandal.Text.TrimStart().Trim();
                Objdtls.VillageName_RegOffice = txtVillage.Text.TrimStart().Trim();
                Objdtls.OtherState_RegOffice_flag = "Y";
            }
            if (txtPincode.Text.TrimStart().Trim() != "")
            {
                Objdtls.Pincode_RegOffice = Convert.ToInt64(txtPincode.Text.TrimStart().Trim());
            }
            if (txtmobileNo1.Text.TrimStart().Trim() != "")
            {
                Objdtls.TelephonoNo1_RegOffice = Convert.ToInt64(txtmobileNo1.Text.TrimStart().Trim());
            }
            if (txtmobileNo.Text.TrimStart().Trim() != "")
            {
                Objdtls.TelephonoNo2_RegOffice = Convert.ToInt64(txtmobileNo.Text.TrimStart().Trim());
            }
            Objdtls.FaxNo1_RegOffice = txtAltmobileno1.Text.TrimStart().Trim();
            Objdtls.FaxNo2_RegOffice = txtAltmobileno.Text.TrimStart().Trim();

            string SelectedValus = "";
            foreach (ListItem li in lstboxCategory.Items)
            {
                if (li.Selected)
                {
                    if (SelectedValus == "")
                    {
                        SelectedValus = li.Value;
                    }
                    else
                    {
                        SelectedValus = SelectedValus + "," + li.Value;
                    }
                }
            }
            Objdtls.Category_RegOffice = SelectedValus;
            Objdtls.TypeofOrganization_RegOffice = ddlConst_of_unit.SelectedValue;
            Objdtls.GovtDeptName_RegOffice = txtOraganisationgovt.Text.TrimStart().Trim();
            Objdtls.DiffCommunicationAddr_Flag = rbtaddress.SelectedValue;
            Objdtls.Door_No_CommAddr = txtDoorNoComm.Text.TrimStart().Trim();
            Objdtls.Street_1_CommAddr = txtstreetNameComm.Text.TrimStart().Trim();
            Objdtls.Street_2_CommAddr = txtstreetName2Comm.Text.TrimStart().Trim();
            Objdtls.State_CommAddr = Convert.ToInt64(ddlstateComm.SelectedValue);
            if (ddlstateComm.SelectedValue == "31")
            {
                Objdtls.Distid_CommAddr = Convert.ToInt64(ddldistrictComm.SelectedValue);
                Objdtls.Mandal_CommAddr = Convert.ToInt64(ddlMandalComm.SelectedValue);
                Objdtls.Village_CommAddr = Convert.ToInt64(ddlvillageComm.SelectedValue);
                Objdtls.OtherState_CommAddr_flag = "N";
            }
            else
            {
                Objdtls.DistName_CommAddr = txtDistrictComm.Text.TrimStart().Trim();
                Objdtls.MandalName_CommAddr = txtMandalComm.Text.TrimStart().Trim();
                Objdtls.VillageName_CommAddr = txtVillageComm.Text.TrimStart().Trim();
                Objdtls.OtherState_CommAddr_flag = "Y";
            }
            if (txtPincodeComm.Text.TrimStart().Trim() != "")
            {
                Objdtls.Pincode_CommAddr = Convert.ToInt64(txtPincodeComm.Text.TrimStart().Trim());
            }

            if (txtmobileNo1Comm.Text.TrimStart().Trim() != "")
            {
                Objdtls.TelephonoNo1_CommAddr = txtmobileNo1Comm.Text.TrimStart().Trim();
            }
            if (txtmobileNoComm.Text.TrimStart().Trim() != "")
            {
                Objdtls.TelephonoNo2_CommAddr = txtmobileNoComm.Text.TrimStart().Trim();
            }


            Objdtls.FaxNo1_CommAddr = txtAltmobileno1Comm.Text.TrimStart().Trim();
            Objdtls.FaxNo2_CommAddr = txtAltmobilenoComm.Text.TrimStart().Trim();

            Objdtls.YearofEstablishment_Firmregistration = Convert.ToInt64(ddlYearofEstablishment.SelectedValue);

            Objdtls.YearofCommencement_Firmregistration = Convert.ToInt64(ddlYearofCommencement.SelectedValue);
            Objdtls.RegistrationNo_Firmregistration = txtfirmregno.Text.TrimStart().Trim();
            Objdtls.RegisteringAuthority_Firmregistration = txtRegAuthority.Text.TrimStart().Trim();

            Objdtls.PlotNo_Prv_flot = txtPrvplotNo.Text.TrimStart().Trim();
            Objdtls.ShedName_Prv_flot = txtshed.Text.TrimStart().Trim();
            Objdtls.House_Prv_flot = txtHouse.Text.TrimStart().Trim();
            Objdtls.OtherDetails_Prv_flot = txtprvother.Text.TrimStart().Trim();
            Objdtls.Shop_Prv_flot = txtshop.Text.TrimStart().Trim();
            Objdtls.StatusAllotted_Lease_Name_Prv_flot = txtstatusprv.Text.TrimStart().Trim();
        }
        else if (FormNo == "2")
        {
            Objdtls.Surname_Cont_info = txtsurname.Text.TrimStart().Trim();
            Objdtls.FirstName_Cont_info = txtFirstName.Text.TrimStart().Trim();

            Objdtls.Door_No_Cont_info = txtDoorNoContact.Text.TrimStart().Trim();
            Objdtls.Street_1_Cont_info = txtstreetNameContact.Text.TrimStart().Trim();
            Objdtls.Street_2_Cont_info = txtstreetName2Contact.Text.TrimStart().Trim();
            Objdtls.State_Cont_info = Convert.ToInt64(ddlstateContact.SelectedValue);
            if (ddlstateContact.SelectedValue.ToString() == "31")
            {
                Objdtls.Distid_Cont_info = Convert.ToInt64(ddldistrictContact.SelectedValue);
                Objdtls.Mandal_Cont_info = Convert.ToInt64(ddlMandalContact.SelectedValue);
                Objdtls.Village_Cont_info = Convert.ToInt64(ddlvillageContact.SelectedValue);
                Objdtls.OtherState_Cont_info_flag = "Y";
            }
            else
            {
                Objdtls.DistName_Cont_info = txtDistrictContact.Text.TrimStart().Trim();
                Objdtls.MandalName_Cont_info = txtMandalContact.Text.TrimStart().Trim();
                Objdtls.VillageName_Cont_info = txtVillageContact.Text.TrimStart().Trim();
                Objdtls.OtherState_Cont_info_flag = "N";
            }

            if (txtPincodeContact.Text.TrimStart().Trim() != "")
            {
                Objdtls.Pincode_Cont_info = Convert.ToInt64(txtPincodeContact.Text.TrimStart().Trim());
            }
            if (txtmobileNoContactnew.Text.TrimStart().Trim() != "")
            {
                Objdtls.MobileNo_Cont_info = Convert.ToInt64(txtmobileNoContactnew.Text.TrimStart().Trim());
            }
            if (txtmobileNo1Contact.Text.TrimStart().Trim() != "")
            {
                Objdtls.TelephonoNo1_Cont_info = Convert.ToInt32(txtmobileNo1Contact.Text.TrimStart().Trim());
            }
            if (txtmobileNoContact.Text.TrimStart().Trim() != "")
            {
                Objdtls.TelephonoNo2_Cont_info = Convert.ToInt32(txtmobileNoContact.Text.TrimStart().Trim());
            }
            Objdtls.FaxNo1_Cont_info = txtfaxone.Text.TrimStart().Trim();
            Objdtls.FaxNo2_Cont_info = txtfaxonenew.Text.TrimStart().Trim();
            Objdtls.Email_Cont_info = txtEmail.Text.TrimStart().Trim();
            if (txtfunctionalProposed.Text.TrimStart().Trim() != "")
            {
                Objdtls.ProposedProject_Financial = txtfunctionalProposed.Text.TrimStart().Trim();
            }
            if (txtassetsrs.Text.TrimStart().Trim() != "")
            {
                Objdtls.Assets_Financial_Inlakhs = Convert.ToDecimal(txtassetsrs.Text.TrimStart().Trim());
            }
            if (txtfunctionalliabilites.Text.TrimStart().Trim() != "")
            {
                Objdtls.Liabilities_Financial_Inlakhs = Convert.ToDecimal(txtfunctionalliabilites.Text.TrimStart().Trim());
            }
            if (txtGst.Text.TrimStart().Trim() != "")
            {
                Objdtls.GSTNumber = txtGst.Text.TrimStart().Trim();
            }


            if (txtotherassets.Text.TrimStart().Trim() != "")
            {
                Objdtls.OtherAssets_Financial_Inlakhs = Convert.ToDecimal(txtotherassets.Text.TrimStart().Trim());
            }
            if (txtassetsland.Text.TrimStart().Trim() != "")
            {
                Objdtls.Immovable_Assets_Land_Building_Financial = txtassetsland.Text.TrimStart().Trim();
            }
            Objdtls.Anyother_Financial_Info = txtfinancialotherinfo.Text.TrimStart().Trim();
            Objdtls.PanNumber_Financial_Info = txtpannofinancial.Text.TrimStart().Trim();

            DataTable dt = (DataTable)Session["CertificateDir"];


            List<Additionalpromotor> addldetails = new List<Additionalpromotor>();

            if (dt.Rows.Count > 0)
            {

                foreach (GridViewRow gvrow in Addlpromotordetails.Rows)
                {

                    Additionalpromotor Addl = new Additionalpromotor();

                    int rowIndex = gvrow.RowIndex;
                    Addl.Name = dt.Rows[rowIndex][0].ToString();
                    Addl.Address = dt.Rows[rowIndex][1].ToString();
                    Addl.ContactNo = Convert.ToInt64(dt.Rows[rowIndex][2]);

                    Addl.Qualification = dt.Rows[rowIndex][3].ToString();

                    Addl.Experience = dt.Rows[rowIndex][4].ToString();

                    Addl.Networth = Convert.ToDecimal(dt.Rows[rowIndex][5]);

                    Addl.createdby = Convert.ToInt32(Session["uid"].ToString());


                    addldetails.Add(Addl);

                }

            }

            if (Session["Applicationid"] != "")
            {

                string st = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(st);
                SqlTransaction trans = null;
                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INSERT_TSIIC_addlpromotordelete_DTLS", connection);
                command.CommandType = CommandType.StoredProcedure;
                command = new SqlCommand();
                command.CommandText = "USP_INSERT_TSIIC_addlpromotordelete_DTLS";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt32(Session["Applicationid"]));
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();

            }


            foreach (Additionalpromotor addl in addldetails)
            {


                string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(str);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INSERT_TSIIC_addlpromotor_DTLS", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_INSERT_TSIIC_addlpromotor_DTLS";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt64(Session["Applicationid"]));
                command.Parameters.AddWithValue("@Name", addl.Name);
                command.Parameters.AddWithValue("@Address", addl.Address);
                command.Parameters.AddWithValue("@ContactNo", addl.ContactNo);
                command.Parameters.AddWithValue("@Qualification", addl.Qualification);
                command.Parameters.AddWithValue("@Experience", addl.Experience);
                command.Parameters.AddWithValue("@Networth", addl.Networth);
                command.Parameters.AddWithValue("@Created_by", addl.createdby);

                //command2.Parameters.AddWithValue("@plotdec", VotsiicProperties.plotdescripton);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();
            }
        }
        else if (FormNo == "3")
        {
            Objdtls.TypeofVenture_General_Info = ddlSector_Ent.SelectedValue;
            Objdtls.ProjectStatus_General_Info = ddlproposal.SelectedValue;
            Objdtls.ProjectCategory1_General_Info = ddlprojectcategory.SelectedValue;
            Objdtls.ProjectCategory2_General_Info = ddlprojectcategory1.SelectedValue;
            Objdtls.ProjectCategory3_General_Info = txtProjectcategorytext.Text.Trim().TrimStart();
            Objdtls.ProjectName_Description_General_Info = txtProjectNameDescription.Text.Trim().TrimStart();
            DataTable dt1 = (DataTable)Session["Proposedprj"];

            List<proposedproduct> addl = new List<proposedproduct>();

            if (dt1.Rows.Count != 0)
            {

                foreach (GridViewRow gvrow in GridView1.Rows)
                {

                    proposedproduct Adl = new proposedproduct();

                    int rowIndex = gvrow.RowIndex;


                    Adl.product = dt1.Rows[rowIndex][0].ToString();

                    Adl.productcode = dt1.Rows[rowIndex][1].ToString();


                    Adl.unitmwasurenent = dt1.Rows[rowIndex][2].ToString();

                    Adl.installedcapacity = dt1.Rows[rowIndex][3].ToString();



                    Adl.createdby = Convert.ToInt32(Session["uid"].ToString());


                    addl.Add(Adl);

                }

            }

            if (Session["Applicationid"] != "")
            {

                string st = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(st);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INSERT_TSIIC_proposeddelete_DTLS", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_INSERT_TSIIC_proposeddelete_DTLS";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt32(Session["Applicationid"]));
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();

            }



            foreach (proposedproduct ad in addl)
            {


                string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(str);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INS_Tsiicproposedproduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_INS_Tsiicproposedproduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@appid", Convert.ToInt64(Session["Applicationid"]));
                command.Parameters.AddWithValue("@Product", ad.product);
                command.Parameters.AddWithValue("@Itemcode", ad.productcode);
                command.Parameters.AddWithValue("@Unitmeasurement", ad.unitmwasurenent);
                command.Parameters.AddWithValue("@Installedcapacity", ad.installedcapacity);

                command.Parameters.AddWithValue("@Createdby", ad.createdby);

                //command2.Parameters.AddWithValue("@plotdec", VotsiicProperties.plotdescripton);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();

            }


            if (txtdatecommercialoperations.Text.TrimStart().Trim() != "")
            {
                string[] date = txtdatecommercialoperations.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.DtCommencement_Commercial_Operations_General_Info = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();


                //  Objdtls.DtCommencement_Commercial_Operations_General_Info = Convert.ToString(DateTime.ParseExact(txtdatecommercialoperations.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtdatecommencementconstruction.Text.TrimStart().Trim() != "")
            {

                string[] date = txtdatecommencementconstruction.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Expected_Dt_Commencement_Construction_General_Info = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                // Objdtls.Expected_Dt_Commencement_Construction_General_Info = Convert.ToString(DateTime.ParseExact(txtdatecommencementconstruction.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtdatetrialoperations.Text.TrimStart().Trim() != "")
            {
                string[] date = txtdatetrialoperations.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Expected_Dt_Trial_Operations_General_Info = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                // Objdtls.Expected_Dt_Trial_Operations_General_Info = Convert.ToString(DateTime.ParseExact(txtdatetrialoperations.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }

            if (txtdatecommercialoperationsphase2.Text.TrimStart().Trim() != "")
            {
                string[] date = txtdatecommercialoperationsphase2.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.DtCommencement_Commercial_Operations_General_Infophase2 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();


                //  Objdtls.DtCommencement_Commercial_Operations_General_Info = Convert.ToString(DateTime.ParseExact(txtdatecommercialoperations.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtdatecommencementconstructionphase2.Text.TrimStart().Trim() != "")
            {

                string[] date = txtdatecommencementconstructionphase2.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Expected_Dt_Commencement_Construction_General_Infophase2 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                // Objdtls.Expected_Dt_Commencement_Construction_General_Info = Convert.ToString(DateTime.ParseExact(txtdatecommencementconstruction.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtdatetrialoperationsphase2.Text.TrimStart().Trim() != "")
            {
                string[] date = txtdatetrialoperationsphase2.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Expected_Dt_Trial_Operations_General_Infophase2 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                // Objdtls.Expected_Dt_Trial_Operations_General_Info = Convert.ToString(DateTime.ParseExact(txtdatetrialoperations.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }


            if (txtdatecommercialoperationsphase3.Text.TrimStart().Trim() != "")
            {
                string[] date = txtdatecommercialoperationsphase3.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.DtCommencement_Commercial_Operations_General_Infophase3 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();


                //  Objdtls.DtCommencement_Commercial_Operations_General_Info = Convert.ToString(DateTime.ParseExact(txtdatecommercialoperations.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtdatecommencementconstructionphase3.Text.TrimStart().Trim() != "")
            {

                string[] date = txtdatecommencementconstructionphase3.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Expected_Dt_Commencement_Construction_General_Infophase3 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                // Objdtls.Expected_Dt_Commencement_Construction_General_Info = Convert.ToString(DateTime.ParseExact(txtdatecommencementconstruction.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtdatetrialoperationsphase3.Text.TrimStart().Trim() != "")
            {
                string[] date = txtdatetrialoperationsphase3.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Expected_Dt_Trial_Operations_General_Infophase3 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                // Objdtls.Expected_Dt_Trial_Operations_General_Info = Convert.ToString(DateTime.ParseExact(txtdatetrialoperations.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtland.Text.TrimStart().Trim() != "")
            {
                Objdtls.Land_Project_Cost_Lakhs = Convert.ToDecimal(txtland.Text.TrimStart().Trim());
            }
            if (txtbuilding.Text.TrimStart().Trim() != "")
            {
                Objdtls.Buildings_Project_Cost_Lakhs = Convert.ToDecimal(txtbuilding.Text.TrimStart().Trim());
            }
            if (txtmachinaryimp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Imported_Project_Cost_Lakhs = Convert.ToDecimal(txtmachinaryimp.Text.TrimStart().Trim());
            }
            if (txtmachinaryindenous.Text.TrimStart().Trim() != "")
            {
                Objdtls.Indigenous_Project_Cost_Lakhs = Convert.ToDecimal(txtmachinaryindenous.Text.TrimStart().Trim());
            }
            if (txtmachinaryauxequ.Text.TrimStart().Trim() != "")
            {
                Objdtls.AuxiliaryEquipment_Project_Cost_Lakhs = Convert.ToDecimal(txtmachinaryauxequ.Text.TrimStart().Trim());
            }
            if (txtfixedassets.Text.TrimStart().Trim() != "")
            {
                Objdtls.Misc_FixedAssets_Project_Cost_Lakhs = Convert.ToDecimal(txtfixedassets.Text.TrimStart().Trim());
            }
            if (txtContinencies.Text.TrimStart().Trim() != "")
            {
                Objdtls.Contingencies_Project_Cost_Lakhs = Convert.ToDecimal(txtContinencies.Text.TrimStart().Trim());
            }
            if (txtpreliminaryexp.Text.TrimStart().Trim() != "")
            {
                Objdtls.PreliminaryExp_Project_Cost_Lakhs = Convert.ToDecimal(txtpreliminaryexp.Text.TrimStart().Trim());
            }
            if (txtworkcapital.Text.TrimStart().Trim() != "")
            {
                Objdtls.WorkCapitalMargin_Project_Cost_Lakhs = Convert.ToDecimal(txtworkcapital.Text.TrimStart().Trim());
            }
            if (txttotalprojcost.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_Project_Cost_Lakhs = Convert.ToDecimal(txttotalprojcost.Text.TrimStart().Trim());
            }
            if (txtUnskilledemp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Unskilled_Emp = Convert.ToInt64(txtUnskilledemp.Text.TrimStart().Trim());
            }
            if (txtSkilledemp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Skilled_Emp = Convert.ToInt64(txtSkilledemp.Text.TrimStart().Trim());
            }
            if (txtSupervisoryemp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Supervisory_Emp = Convert.ToInt64(txtSupervisoryemp.Text.TrimStart().Trim());
            }
            if (txtManagerialemp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Managerial_Emp = Convert.ToInt64(txtManagerialemp.Text.TrimStart().Trim());
            }
            if (txttotalempdirect.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_Emp = Convert.ToInt64(txttotalempdirect.Text.TrimStart().Trim());
            }


            if (txtlandphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Land_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtlandphase2.Text.TrimStart().Trim());
            }
            if (txtbuildingphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Buildings_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtbuildingphase2.Text.TrimStart().Trim());
            }
            if (txtmachinaryimpphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Imported_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtmachinaryimpphase2.Text.TrimStart().Trim());
            }
            if (txtmachinaryindenousphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Indigenous_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtmachinaryindenousphase2.Text.TrimStart().Trim());
            }
            if (txtauxilaryequipphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.AuxiliaryEquipment_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtauxilaryequipphase2.Text.TrimStart().Trim());
            }
            if (txtfixedassetsphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Misc_FixedAssets_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtfixedassetsphase2.Text.TrimStart().Trim());
            }
            if (txtContinenciesphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Contingencies_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtContinenciesphase2.Text.TrimStart().Trim());
            }
            if (txtpreliminaryexpphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.PreliminaryExp_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtpreliminaryexpphase2.Text.TrimStart().Trim());
            }
            if (txtworkcapitalphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.WorkCapitalMargin_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txtworkcapitalphase2.Text.TrimStart().Trim());
            }
            if (txttotalprojcostphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_Project_Cost_Lakhsphase2 = Convert.ToDecimal(txttotalprojcostphase2.Text.TrimStart().Trim());
            }

            if (txtunskilledphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Unskilled_Empphase2 = Convert.ToInt64(txtunskilledphase2.Text.TrimStart().Trim());
            }
            if (txtskilledphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Skilled_Empphase2 = Convert.ToInt64(txtskilledphase2.Text.TrimStart().Trim());
            }
            if (txtsupervisoryphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Supervisory_Empphase2 = Convert.ToInt64(txtsupervisoryphase2.Text.TrimStart().Trim());
            }
            if (txtmanagerialphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Managerial_Empphase2 = Convert.ToInt64(txtmanagerialphase2.Text.TrimStart().Trim());
            }
            if (txttotalempdirectphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_Empphase2 = Convert.ToInt64(txttotalempdirectphase2.Text.TrimStart().Trim());

            }

            if (txtlandphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Land_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtlandphase3.Text.TrimStart().Trim());
            }
            if (txtbuildingphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Buildings_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtbuildingphase3.Text.TrimStart().Trim());
            }
            if (txtmachinaryimpphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Imported_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtmachinaryimpphase3.Text.TrimStart().Trim());
            }
            if (txtmachinaryindenousphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Indigenous_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtmachinaryindenousphase3.Text.TrimStart().Trim());
            }
            if (txtauxilaryequipphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.AuxiliaryEquipment_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtauxilaryequipphase3.Text.TrimStart().Trim());
            }
            if (txtfixedassetsphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Misc_FixedAssets_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtfixedassetsphase3.Text.TrimStart().Trim());
            }
            if (txtContinenciesphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Contingencies_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtContinenciesphase3.Text.TrimStart().Trim());
            }
            if (txtpreliminaryexpphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.PreliminaryExp_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtpreliminaryexpphase3.Text.TrimStart().Trim());
            }
            if (txtworkcapitalphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.WorkCapitalMargin_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txtworkcapitalphase3.Text.TrimStart().Trim());
            }
            if (txttotalprojcostphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_Project_Cost_Lakhsphase3 = Convert.ToDecimal(txttotalprojcostphase3.Text.TrimStart().Trim());
            }
            if (txtdomestic.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic = Convert.ToDecimal(txtdomestic.Text.TrimStart().Trim());
            }
            if (txtforeigns.Text.TrimStart().Trim() != "")
            {
                Objdtls.Foreigns = Convert.ToDecimal(txtforeigns.Text.TrimStart().Trim());
            }
            if (txtequity.Text.TrimStart().Trim() != "")
            {
                Objdtls.TotalEquity = Convert.ToDecimal(txtequity.Text.TrimStart().Trim());
            }
            if (txtamount.Text.TrimStart().Trim() != "")
            {
                Objdtls.Amount = Convert.ToDecimal(txtamount.Text.TrimStart().Trim());
            }

            if (txtname.Text.TrimStart().Trim() != "")
            {
                Objdtls.EquityName = txtname.Text.TrimStart().Trim();
            }
            if (txteuitdebit.Text.TrimStart().Trim() != "")
            {
                Objdtls.TotalEquitdebit = Convert.ToDecimal(txteuitdebit.Text.TrimStart().Trim());
            }
            if (txtforeign.Text.TrimStart().Trim() != "")
            {
                Objdtls.Foreigninvestment = txtforeign.Text.TrimStart().Trim();
            }
            if (txtforeigndate.Text.TrimStart().Trim() != "")
            {


                string[] date = txtforeigndate.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Foreigninvestmentdate = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();

            }
            if (txtIEM.Text.TrimStart().Trim() != "")
            {
                Objdtls.IEM = txtIEM.Text.TrimStart().Trim();



            }
            if (txtIEMdate.Text.TrimStart().Trim() != "")
            {



                string[] date = txtIEMdate.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.IEMdate = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
            }
            if (txtloi.Text.TrimStart().Trim() != "")
            {
                Objdtls.LOI = txtloi.Text.TrimStart().Trim();
            }
            if (txtloidate.Text.TrimStart().Trim() != "")
            {

                string[] date = txtloidate.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.LOIdate = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();


            }
            if (txteou.Text.TrimStart().Trim() != "")
            {
                Objdtls.EOUNo = txteou.Text.TrimStart().Trim();
            }
            if (txteoudate.Text.TrimStart().Trim() != "")
            {


                string[] date = txteoudate.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.EOUdate = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
            }





            if (txtunskilledphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Unskilled_Empphas3 = Convert.ToInt64(txtunskilledphase3.Text.TrimStart().Trim());
            }
            if (txtskilledphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Skilled_Empphase3 = Convert.ToInt64(txtskilledphase3.Text.TrimStart().Trim());
            }
            if (txtsupervisoryphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Supervisory_Empphase3 = Convert.ToInt64(txtsupervisoryphase3.Text.TrimStart().Trim());
            }
            if (txtmanagerialphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Managerial_Empphase3 = Convert.ToInt64(txtmanagerialphase3.Text.TrimStart().Trim());
            }
            if (txttotalempdirectphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_Empphase3 = Convert.ToInt64(txttotalempdirectphase3.Text.TrimStart().Trim());
            }
            if (txtMaximumempfactory.Text.TrimStart().Trim() != "")
            {
                Objdtls.Workers_factory_emp = Convert.ToInt64(txtMaximumempfactory.Text.TrimStart().Trim());
            }

            if (txtmalephase1.Text.TrimStart().Trim() != "")
            {
                Objdtls.malephase1 = Convert.ToInt64(txtmalephase1.Text.TrimStart().Trim());
            }

            if (txtmalephase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.malephase2 = Convert.ToInt64(txtmalephase2.Text.TrimStart().Trim());
            }

            if (txtmalephase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.malephase3 = Convert.ToInt64(txtmalephase3.Text.TrimStart().Trim());
            }

            if (txtfemalephase1.Text.TrimStart().Trim() != "")
            {
                Objdtls.femalephase1 = Convert.ToInt64(txtfemalephase1.Text.TrimStart().Trim());
            }
            if (txtfemalephase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.femalephase2 = Convert.ToInt64(txtfemalephase2.Text.TrimStart().Trim());
            }
            if (txtfemalephase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.femalephase3 = Convert.ToInt64(txtfemalephase3.Text.TrimStart().Trim());
            }



            DataTable dt2 = (DataTable)Session["Certificate"];


            List<materialmanufacturing> raw = new List<materialmanufacturing>();

            if (dt2.Rows.Count != 0)
            {

                foreach (GridViewRow gvrow in rawmaterialconsumption.Rows)
                {

                    materialmanufacturing Adl = new materialmanufacturing();

                    int rowIndex = gvrow.RowIndex;


                    Adl.Describeitem = dt2.Rows[rowIndex][0].ToString();

                    Adl.Itemcode = dt2.Rows[rowIndex][1].ToString();


                    Adl.dailyconsumption = dt2.Rows[rowIndex][2].ToString();

                    Adl.unitmeasurement = dt2.Rows[rowIndex][3].ToString();



                    Adl.createdby = Convert.ToInt32(Session["uid"].ToString());


                    raw.Add(Adl);

                }

            }


            if (Session["Applicationid"] != "")
            {

                string st = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(st);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INSERT_TSIIC_materialmanufacturingdelete_DTLS", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_INSERT_TSIIC_materialmanufacturingdelete_DTLS";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt32(Session["Applicationid"]));
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();

            }




            foreach (materialmanufacturing ads in raw)
            {


                string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(str);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INSERT_TSIIC_materialmanufacturing_DTLS", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_INSERT_TSIIC_materialmanufacturing_DTLS";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt64(Session["Applicationid"]));
                command.Parameters.AddWithValue("@Descriptionitem", ads.Describeitem);
                command.Parameters.AddWithValue("@Itemcode", ads.Itemcode);
                command.Parameters.AddWithValue("@DailyConsumption", ads.dailyconsumption);
                command.Parameters.AddWithValue("@unitmeasurement", ads.unitmeasurement);


                command.Parameters.AddWithValue("@Created_by", ads.createdby);

                //command2.Parameters.AddWithValue("@plotdec", VotsiicProperties.plotdescripton);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();





            }

            DataTable dt5 = (DataTable)Session["CertificateDirTb5"];


            List<plantmachinery> machinerydetails = new List<plantmachinery>();

            if (dt5.Rows.Count > 0)
            {

                foreach (GridViewRow gvrow in GridView2.Rows)
                {

                    plantmachinery machineries = new plantmachinery();

                    int rowIndex = gvrow.RowIndex;


                    machineries.Descriptionplantmachinery = dt5.Rows[rowIndex][0].ToString();

                    machineries.capacitykw = dt5.Rows[rowIndex][1].ToString();



                    machineries.Quantity = dt5.Rows[rowIndex][2].ToString();
                    machineries.Cost = Convert.ToDecimal(dt5.Rows[rowIndex][3].ToString());


                    machineries.createdby = Convert.ToInt32(Session["uid"].ToString());

                    machinerydetails.Add(machineries);

                }

            }

            if (Session["Applicationid"] != "")
            {

                string st = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(st);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_delete_tsiicplantmachinery", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_delete_tsiicplantmachinery";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt32(Session["Applicationid"]));
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();

            }


            foreach (plantmachinery machineries in machinerydetails)
            {


                string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                int valid = 0;

                SqlConnection connection = new SqlConnection(str);
                SqlTransaction trans = null;

                connection.Open();
                trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand("USP_INSERT_tsiicplantmachinery", connection);
                command.CommandType = CommandType.StoredProcedure;

                command = new SqlCommand();
                command.CommandText = "USP_INSERT_tsiicplantmachinery";
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;
                command.Connection = connection;
                command.Parameters.AddWithValue("@ApplicationId", Convert.ToInt64(Session["Applicationid"]));
                command.Parameters.AddWithValue("@Descplantmachinery", machineries.Descriptionplantmachinery);
                command.Parameters.AddWithValue("@capacitykw", machineries.capacitykw);
                command.Parameters.AddWithValue("@Quantity", machineries.Quantity);
                command.Parameters.AddWithValue("@cost", machineries.Cost);

                command.Parameters.AddWithValue("@Created_by", machineries.createdby);


                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;
                //command2.Transaction = transss;
                command.ExecuteNonQuery();

                valid = (int)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();
            }






        }
        else if (FormNo == "4")
        {
            if (txtPlantFactoryBuildings.Text.TrimStart().Trim() != "")
            {
                Objdtls.PlantFactoryBuildings_LandRequired = Convert.ToDecimal(txtPlantFactoryBuildings.Text.TrimStart().Trim());
            }
            if (txtAdministrationBuildings.Text.TrimStart().Trim() != "")
            {
                Objdtls.AdministrationBuildings_LandRequired = Convert.ToDecimal(txtAdministrationBuildings.Text.TrimStart().Trim());
            }
            if (txtStorageWarehousing.Text.TrimStart().Trim() != "")
            {
                Objdtls.StorageWarehousing_LandRequired = Convert.ToDecimal(txtStorageWarehousing.Text.TrimStart().Trim());
            }
            if (txtRoadsWaterstorage.Text.TrimStart().Trim() != "")
            {
                Objdtls.RoadsWaterstorage_LandRequired = Convert.ToDecimal(txtRoadsWaterstorage.Text.TrimStart().Trim());
            }
            if (txtOpenAreasGreenBelt.Text.TrimStart().Trim() != "")
            {
                Objdtls.OpenAreasGreenBelt_LandRequired = Convert.ToDecimal(txtOpenAreasGreenBelt.Text.TrimStart().Trim());
            }
            if (txttotalAreaLandRequired.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_LandRequired = Convert.ToDecimal(txttotalAreaLandRequired.Text.TrimStart().Trim());
            }

            if (txtPlantFactoryBuildingsphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.PlantFactoryBuildings_LandRequiredphase2 = Convert.ToDecimal(txtPlantFactoryBuildingsphase2.Text.TrimStart().Trim());
            }
            if (txtAdministrationBuildingsphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.AdministrationBuildings_LandRequiredphase2 = Convert.ToDecimal(txtAdministrationBuildingsphase2.Text.TrimStart().Trim());
            }
            if (txtStorageWarehousingphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.StorageWarehousing_LandRequiredphase2 = Convert.ToDecimal(txtStorageWarehousingphase2.Text.TrimStart().Trim());
            }
            if (txtRoadsWaterstoragephase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.RoadsWaterstorage_LandRequiredphase2 = Convert.ToDecimal(txtRoadsWaterstoragephase2.Text.TrimStart().Trim());
            }
            if (txtOpenAreasGreenBeltphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.OpenAreasGreenBelt_LandRequiredphase2 = Convert.ToDecimal(txtOpenAreasGreenBeltphase2.Text.TrimStart().Trim());
            }
            if (txttotalAreaLandRequiredphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_LandRequiredphase2 = Convert.ToDecimal(txttotalAreaLandRequiredphase2.Text.TrimStart().Trim());
            }
            if (txtPlantFactoryBuildingsphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.PlantFactoryBuildings_LandRequiredphase3 = Convert.ToDecimal(txtPlantFactoryBuildingsphase3.Text.TrimStart().Trim());
            }
            if (txtAdministrationBuildingsphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.AdministrationBuildings_LandRequiredphase3 = Convert.ToDecimal(txtAdministrationBuildingsphase3.Text.TrimStart().Trim());
            }
            if (txtStorageWarehousingphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.StorageWarehousing_LandRequiredphase3 = Convert.ToDecimal(txtStorageWarehousingphase3.Text.TrimStart().Trim());
            }
            if (txtRoadsWaterstoragephase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.RoadsWaterstorage_LandRequiredphase3 = Convert.ToDecimal(txtRoadsWaterstoragephase3.Text.TrimStart().Trim());
            }
            if (txtOpenAreasGreenBeltphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.OpenAreasGreenBelt_LandRequiredphase3 = Convert.ToDecimal(txtOpenAreasGreenBeltphase3.Text.TrimStart().Trim());
            }
            if (txttotalAreaLandRequiredphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Total_LandRequiredphase3 = Convert.ToDecimal(txttotalAreaLandRequiredphase3.Text.TrimStart().Trim());
            }
            if (TextBox49.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrialshed = TextBox49.Text.TrimStart().Trim();
            }

            if (TextBox1.Text.TrimStart().Trim() != "")
            {
                Objdtls.Tstranscosupply = TextBox1.Text.TrimStart().Trim();
            }
            if (TextBox2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Owngeneration = TextBox2.Text.TrimStart().Trim();
            }
            if (TextBox3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Dgset = TextBox3.Text.TrimStart().Trim();
            }


            if (txtPowerrequirements.Text.TrimStart().Trim() != "")
            {
                Objdtls.TSTRANSCO_Energy_KVA = Convert.ToDecimal(txtPowerrequirements.Text.TrimStart().Trim());
            }
            if (txtContractedmaximumdemand.Text.TrimStart().Trim() != "")
            {
                Objdtls.ContractedMaxDem_KVA = Convert.ToDecimal(txtContractedmaximumdemand.Text.TrimStart().Trim());
            }
            if (txtRequiredpowersupplyline.Text.TrimStart().Trim() != "")
            {
                Objdtls.Req_PowerSupply_KV = Convert.ToDecimal(txtRequiredpowersupplyline.Text.TrimStart().Trim());
            }
            if (txtVoltagerating.Text.TrimStart().Trim() != "")
            {
                Objdtls.VoltageRating_HT = Convert.ToDecimal(txtVoltagerating.Text.TrimStart().Trim());
            }
            if (txtConnectedload.Text.TrimStart().Trim() != "")
            {
                Objdtls.Connectedload_KW = Convert.ToDecimal(txtConnectedload.Text.TrimStart().Trim());
            }
            if (txtLoadfactor.Text.TrimStart().Trim() != "")
            {
                Objdtls.Loadfactor = Convert.ToDecimal(txtLoadfactor.Text.TrimStart().Trim());
            }

            if (txtPowerrequirementsphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.TSTRANSCO_Energy_KVAphase2 = Convert.ToDecimal(txtPowerrequirementsphase2.Text.TrimStart().Trim());
            }
            if (txtContractedmaximumdemandphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.ContractedMaxDem_KVphase2 = Convert.ToDecimal(txtContractedmaximumdemandphase2.Text.TrimStart().Trim());
            }
            if (txtRequiredpowersupplylinephase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Req_PowerSupply_KVphase2 = Convert.ToDecimal(txtRequiredpowersupplylinephase2.Text.TrimStart().Trim());
            }
            if (txtVoltageratingphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.VoltageRating_HTphase2 = Convert.ToDecimal(txtVoltageratingphase2.Text.TrimStart().Trim());
            }
            if (txtConnectedloadphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Connectedload_KWphase2 = Convert.ToDecimal(txtConnectedloadphase2.Text.TrimStart().Trim());
            }
            if (txtLoadfactorphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Loadfactorphase2 = Convert.ToDecimal(txtLoadfactorphase2.Text.TrimStart().Trim());
            }

            if (txtPowerrequirementsphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.TSTRANSCO_Energy_KVAphase3 = Convert.ToDecimal(txtPowerrequirementsphase3.Text.TrimStart().Trim());
            }
            if (txtContractedmaximumdemandphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.ContractedMaxDem_KVAphase3 = Convert.ToDecimal(txtContractedmaximumdemandphase3.Text.TrimStart().Trim());
            }
            if (txtRequiredpowersupplylinephase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Req_PowerSupply_KVphase3 = Convert.ToDecimal(txtRequiredpowersupplylinephase3.Text.TrimStart().Trim());
            }
            if (txtVoltageratingphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.VoltageRating_HTphase3 = Convert.ToDecimal(txtVoltageratingphase3.Text.TrimStart().Trim());
            }
            if (txtConnectedloadphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Connectedload_KWphase3 = Convert.ToDecimal(txtConnectedloadphase3.Text.TrimStart().Trim());
            }
            if (txtLoadfactorphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Loadfactorphase3 = Convert.ToDecimal(txtLoadfactorphase3.Text.TrimStart().Trim());
            }
            if (txtConstructionphasedate.Text.TrimStart().Trim() != "")
            {

                string[] date = txtConstructionphasedate.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Dt_Construction_PowerSupply = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();

                //Objdtls.Dt_Construction_PowerSupply = Convert.ToString(DateTime.ParseExact(txtConstructionphasedate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtCommercialproductiondate.Text.TrimStart().Trim() != "")
            {
                string[] date = txtCommercialproductiondate.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Dt_Commercial_PowerSupply = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                // Objdtls.Dt_Commercial_PowerSupply = Convert.ToString(DateTime.ParseExact(txtCommercialproductiondate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtConstructionphasedatephase2.Text.TrimStart().Trim() != "")
            {

                string[] date = txtConstructionphasedatephase2.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Dt_Construction_PowerSupplyphase2 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();

                //Objdtls.Dt_Construction_PowerSupply = Convert.ToString(DateTime.ParseExact(txtConstructionphasedate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtCommercialproductiondatephase2.Text.TrimStart().Trim() != "")
            {
                string[] date = txtCommercialproductiondatephase2.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Dt_Commercial_PowerSupplyphase2 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                // Objdtls.Dt_Commercial_PowerSupply = Convert.ToString(DateTime.ParseExact(txtCommercialproductiondate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtConstructionphasedatephase3.Text.TrimStart().Trim() != "")
            {

                string[] date = txtConstructionphasedatephase3.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Dt_Construction_PowerSupplyphase3 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();

                //Objdtls.Dt_Construction_PowerSupply = Convert.ToString(DateTime.ParseExact(txtConstructionphasedate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtCommercialproductiondatephase3.Text.TrimStart().Trim() != "")
            {
                string[] date = txtCommercialproductiondatephase3.Text.Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                Objdtls.Dt_Commercial_PowerSupplyphase3 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                // Objdtls.Dt_Commercial_PowerSupply = Convert.ToString(DateTime.ParseExact(txtCommercialproductiondate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (txtDomesticTemporary.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic_Temp_WaterReq = Convert.ToDecimal(txtDomesticTemporary.Text.TrimStart().Trim());
            }
            if (txtIndustrialTemporary.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrial_Temp_WaterReq = Convert.ToDecimal(txtIndustrialTemporary.Text.TrimStart().Trim());
            }
            if (txtDomesticPermanent.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic_Perm_WaterReq = Convert.ToDecimal(txtDomesticPermanent.Text.TrimStart().Trim());
            }
            if (txtIndustrialPermanent.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrial_Perm_WaterReq = Convert.ToDecimal(txtIndustrialPermanent.Text.TrimStart().Trim());
            }

            if (txtdomesticphase2temp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic_Temp_WaterReqphase2 = Convert.ToDecimal(txtdomesticphase2temp.Text.TrimStart().Trim());
            }
            if (txtindustrialphase2temp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrial_Temp_WaterReqphase2 = Convert.ToDecimal(txtindustrialphase2temp.Text.TrimStart().Trim());
            }
            if (txtdomesticpermphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic_Perm_WaterReqphase2 = Convert.ToDecimal(txtdomesticpermphase2.Text.TrimStart().Trim());
            }
            if (txtIndustrialPermanentphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrial_Perm_WaterReqphase2 = Convert.ToDecimal(txtIndustrialPermanentphase2.Text.TrimStart().Trim());
            }

            if (txtdomesticphase3temp.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic_Temp_WaterReqphase3 = Convert.ToDecimal(txtdomesticphase3temp.Text.TrimStart().Trim());
            }
            if (txtindustrialphasetemp3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrial_Temp_WaterReqphase3 = Convert.ToDecimal(txtindustrialphasetemp3.Text.TrimStart().Trim());
            }
            if (txtdomesticpermphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Domestic_Perm_WaterReqphase3 = Convert.ToDecimal(txtdomesticpermphase3.Text.TrimStart().Trim());
            }
            if (txtIndustrialPermanentphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Industrial_Perm_WaterReqphase3 = Convert.ToDecimal(txtIndustrialPermanentphase3.Text.TrimStart().Trim());
            }

            if (txteffluentqtyphase1.Text.TrimStart().Trim() != "")
            {
                Objdtls.Effluentsphase1 = txteffluentqtyphase1.Text.TrimStart().Trim();
            }

            if (txteffluentqtyphase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.Effluentsphase2 = txteffluentqtyphase2.Text.TrimStart().Trim();
            }

            if (txteffluentqtyphase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.Effluentsphase3 = txteffluentqtyphase3.Text.TrimStart().Trim();
            }

            if (txtsolidwastephase1.Text.TrimStart().Trim() != "")
            {
                Objdtls.SolidWastephase1 = txtsolidwastephase1.Text.TrimStart().Trim();
            }

            if (txtsolidwastephase2.Text.TrimStart().Trim() != "")
            {
                Objdtls.SolidWastephase2 = txtsolidwastephase2.Text.TrimStart().Trim();
            }

            if (txtsolidwastephase3.Text.TrimStart().Trim() != "")
            {
                Objdtls.SolidWastephase3 = txtsolidwastephase3.Text.TrimStart().Trim();
            }

            if (txtdesceffluents.Text.TrimStart().Trim() != "")
            {
                Objdtls.Descriptioneffulents = txtdesceffluents.Text.TrimStart().Trim();
            }

            if (txtBanAccNO.Text.TrimStart().Trim() != "")
            {
                Objdtls.AccountNo = txtBanAccNO.Text.TrimStart().Trim();
            }

            if (txtBankBranchName.Text.TrimStart().Trim() != "")
            {
                Objdtls.BranchName = txtBankBranchName.Text.TrimStart().Trim();
            }

            if (txtBankName.Text.TrimStart().Trim() != "")
            {
                Objdtls.BankName = txtBankName.Text.TrimStart().Trim();
            }

            if (txtIfsccode.Text.TrimStart().Trim() != "")
            {
                Objdtls.Ifsccode = txtIfsccode.Text.TrimStart().Trim();
            }

            if (txtTypeAccount.Text.TrimStart().Trim() != "")
            {
                Objdtls.TypeofAccount = txtTypeAccount.Text.TrimStart().Trim();
            }

            if (txtAccountHolderName.Text.TrimStart().Trim() != "")
            {
                Objdtls.AccountHolderName = txtAccountHolderName.Text.TrimStart().Trim();
            }


        }
        if (FormNo != "")
        {
            Output = InsertUpdateMainApplicantDtls(Objdtls);
        }

        return Output.ToString();
    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    public string ContactInfoAddreecheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtsurname.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Surname \\n";
            slno = slno + 1;
        }
        if (txtFirstName.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter First Name \\n";
            slno = slno + 1;
        }
        if (txtDoorNoContact.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Door Number \\n";
            slno = slno + 1;
        }
        if (txtstreetNameContact.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Street1 \\n";
            slno = slno + 1;
        }
        if (ddlstateContact.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select State \\n";
            slno = slno + 1;
        }
        if (ddlstateContact.SelectedValue != "0" && ddlstateContact.SelectedValue == "31")
        {
            if (ddldistrictContact.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select District \\n";
                slno = slno + 1;
            }
            if (ddlMandalContact.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Mandal \\n";
                slno = slno + 1;
            }
            if (ddlvillageContact.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Village \\n";
                slno = slno + 1;
            }
        }
        else if (ddlstateContact.SelectedValue != "0")
        {
            if (txtDistrictContact.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office District \\n";
                slno = slno + 1;
            }
            if (txtMandalContact.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office Mandal \\n";
                slno = slno + 1;
            }
            if (txtVillageContact.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office Village \\n";
                slno = slno + 1;
            }
        }
        if (txtPincodeContact.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Office Pincode \\n";
            slno = slno + 1;
        }
        if (txtmobileNoContactnew.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile\\n";
            slno = slno + 1;
        }
        if (txtEmail.Text.TrimStart().Trim() != "")
        {

            bool Statusvalid = IsValidEmail(txtEmail.Text.TrimStart().Trim());
            if (Statusvalid == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Valid Maill Address\\n";
                slno = slno + 1;
            }
        }
        return ErrorMsg;
    }
    public string FinancialInformationcheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        //if (txtpannofinancial.Text.TrimStart().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Pan Number \\n";
        //    slno = slno + 1;
        //}

        if (txtfunctionalProposed.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Functional Responsibilities in Proposed Project \\n";
            slno = slno + 1;
        }
        if (txtassetsrs.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Assets(Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (txtfunctionalliabilites.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Liabilities(Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        //if (txtGst.Text.TrimStart().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter GST Number \\n";
        //    slno = slno + 1;
        //}
        if (txtotherassets.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Other Assets(Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    public bool IsValidEmailAddress(string email)
    {
        try
        {
            var emailChecked = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9]+.[a-zA-Z]{2,}$";


        if (string.IsNullOrEmpty(email))
            return false;

        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }
    protected void txtland_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();


    }
    protected void txtbuilding_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }
    protected void txtmachinaryimp_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }
    protected void txtmachinaryindenous_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }
    protected void txtmachinaryauxequ_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }
    protected void txtfixedassets_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }
    protected void txtContinencies_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }
    protected void txtpreliminaryexp_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }


    protected void txtworkcapital_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCost();
    }

    protected void txtlandphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }

    protected void txtbuildingphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }

    protected void txtmachinaryimpphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();


    }
    protected void txtmachinaryindenousphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }
    protected void txtContinenciesphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }
    protected void txtauxilaryequipphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }
    protected void txtfixedassetsphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }
    protected void txtpreliminaryexpphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }
    protected void txtworkcapitalphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtpreliminaryexpphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtContinenciesphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtfixedassetsphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtauxilaryequipphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtmachinaryindenousphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtworkcapitalphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase2();
    }

    protected void txtbuildingphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtlandphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }
    protected void txtmachinaryimpphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalProjectCostphase3();
    }



    private void CalculateTotalProjectCost()
    {
        string message = "alert('Please Enter the Phase 1 Estimated Project Cost in lakhs only')";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
        decimal TotalProjCost = 0, strland = 0, strbuilding = 0, strmachinaryimp = 0, strmachinaryindenous = 0, strmachinaryauxequ = 0, strfixedassets = 0, strContinencies = 0, strpreliminaryexp = 0, strworkcapital = 0;

        if (txtland.Text.Trim().TrimStart() != "")
        {
            strland = Convert.ToDecimal(txtland.Text.Trim().TrimStart());
        }
        else
        {
            strland = 0;
        }
        //-----------------------------------------------
        if (txtbuilding.Text.Trim().TrimStart() != "")
        {
            strbuilding = Convert.ToDecimal(txtbuilding.Text.Trim().TrimStart());
        }
        else
        {
            strbuilding = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryimp.Text.Trim().TrimStart() != "")
        {
            strmachinaryimp = Convert.ToDecimal(txtmachinaryimp.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryimp = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryindenous.Text.Trim().TrimStart() != "")
        {
            strmachinaryindenous = Convert.ToDecimal(txtmachinaryindenous.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryindenous = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryauxequ.Text.Trim().TrimStart() != "")
        {
            strmachinaryauxequ = Convert.ToDecimal(txtmachinaryauxequ.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryauxequ = 0;
        }
        //-----------------------------------------------
        if (txtfixedassets.Text.Trim().TrimStart() != "")
        {
            strfixedassets = Convert.ToDecimal(txtfixedassets.Text.Trim().TrimStart());
        }
        else
        {
            strfixedassets = 0;
        }
        //-----------------------------------------------
        if (txtContinencies.Text.Trim().TrimStart() != "")
        {
            strContinencies = Convert.ToDecimal(txtContinencies.Text.Trim().TrimStart());
        }
        else
        {
            strContinencies = 0;
        }
        //-----------------------------------------------
        if (txtpreliminaryexp.Text.Trim().TrimStart() != "")
        {
            strpreliminaryexp = Convert.ToDecimal(txtpreliminaryexp.Text.Trim().TrimStart());
        }
        else
        {
            strpreliminaryexp = 0;
        }
        //-----------------------------------------------
        if (txtworkcapital.Text.Trim().TrimStart() != "")
        {
            strworkcapital = Convert.ToDecimal(txtworkcapital.Text.Trim().TrimStart());
        }
        else
        {
            strworkcapital = 0;
        }
        //-----------------------------------------------
        //  = 0,  = 0, 

        TotalProjCost = strland + strbuilding + strmachinaryimp + strmachinaryindenous + strmachinaryauxequ + strfixedassets + strContinencies + strpreliminaryexp + strworkcapital;

        txttotalprojcost.Text = TotalProjCost.ToString();
    }


    private void CalculateTotalProjectCostphase2()
    {
        string message = "alert('Please Enter the Phase 2 Estimated Project Cost in lakhs only')";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);

        decimal TotalProjCost = 0, strland = 0, strbuilding = 0, strmachinaryimp = 0, strmachinaryindenous = 0, strmachinaryauxequ = 0, strfixedassets = 0, strContinencies = 0, strpreliminaryexp = 0, strworkcapital = 0;

        if (txtlandphase2.Text.Trim().TrimStart() != "")
        {
            strland = Convert.ToDecimal(txtlandphase2.Text.Trim().TrimStart());
        }
        else
        {
            strland = 0;
        }
        //-----------------------------------------------
        if (txtbuildingphase2.Text.Trim().TrimStart() != "")
        {
            strbuilding = Convert.ToDecimal(txtbuildingphase2.Text.Trim().TrimStart());
        }
        else
        {
            strbuilding = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryimpphase2.Text.Trim().TrimStart() != "")
        {
            strmachinaryimp = Convert.ToDecimal(txtmachinaryimpphase2.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryimp = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryindenousphase2.Text.Trim().TrimStart() != "")
        {
            strmachinaryindenous = Convert.ToDecimal(txtmachinaryindenousphase2.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryindenous = 0;
        }
        //-----------------------------------------------
        if (txtauxilaryequipphase2.Text.Trim().TrimStart() != "")
        {
            strmachinaryauxequ = Convert.ToDecimal(txtauxilaryequipphase2.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryauxequ = 0;
        }
        //-----------------------------------------------
        if (txtfixedassetsphase2.Text.Trim().TrimStart() != "")
        {
            strfixedassets = Convert.ToDecimal(txtfixedassetsphase2.Text.Trim().TrimStart());
        }
        else
        {
            strfixedassets = 0;
        }
        //-----------------------------------------------
        if (txtContinenciesphase2.Text.Trim().TrimStart() != "")
        {
            strContinencies = Convert.ToDecimal(txtContinenciesphase2.Text.Trim().TrimStart());
        }
        else
        {
            strContinencies = 0;
        }
        //-----------------------------------------------
        if (txtpreliminaryexpphase2.Text.Trim().TrimStart() != "")
        {
            strpreliminaryexp = Convert.ToDecimal(txtpreliminaryexpphase2.Text.Trim().TrimStart());
        }
        else
        {
            strpreliminaryexp = 0;
        }
        //-----------------------------------------------
        if (txtworkcapitalphase2.Text.Trim().TrimStart() != "")
        {
            strworkcapital = Convert.ToDecimal(txtworkcapitalphase2.Text.Trim().TrimStart());
        }
        else
        {
            strworkcapital = 0;
        }
        //-----------------------------------------------
        //  = 0,  = 0, 

        TotalProjCost = strland + strbuilding + strmachinaryimp + strmachinaryindenous + strmachinaryauxequ + strfixedassets + strContinencies + strpreliminaryexp + strworkcapital;

        txttotalprojcostphase2.Text = TotalProjCost.ToString();
    }


    private void CalculateTotalProjectCostphase3()
    {
        string message = "alert('Please Enter the Phase 3 Estimated Project Cost in lakhs only')";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);

        decimal TotalProjCost = 0, strland = 0, strbuilding = 0, strmachinaryimp = 0, strmachinaryindenous = 0, strmachinaryauxequ = 0, strfixedassets = 0, strContinencies = 0, strpreliminaryexp = 0, strworkcapital = 0;

        if (txtlandphase3.Text.Trim().TrimStart() != "")
        {
            strland = Convert.ToDecimal(txtlandphase3.Text.Trim().TrimStart());
        }
        else
        {
            strland = 0;
        }
        //-----------------------------------------------
        if (txtbuildingphase3.Text.Trim().TrimStart() != "")
        {
            strbuilding = Convert.ToDecimal(txtbuildingphase3.Text.Trim().TrimStart());
        }
        else
        {
            strbuilding = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryimpphase3.Text.Trim().TrimStart() != "")
        {
            strmachinaryimp = Convert.ToDecimal(txtmachinaryimpphase3.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryimp = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryindenousphase3.Text.Trim().TrimStart() != "")
        {
            strmachinaryindenous = Convert.ToDecimal(txtmachinaryindenousphase3.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryindenous = 0;
        }
        //-----------------------------------------------
        if (txtauxilaryequipphase3.Text.Trim().TrimStart() != "")
        {
            strmachinaryauxequ = Convert.ToDecimal(txtauxilaryequipphase3.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryauxequ = 0;
        }
        //-----------------------------------------------
        if (txtfixedassetsphase3.Text.Trim().TrimStart() != "")
        {
            strfixedassets = Convert.ToDecimal(txtfixedassetsphase3.Text.Trim().TrimStart());
        }
        else
        {
            strfixedassets = 0;
        }
        //-----------------------------------------------
        if (txtContinenciesphase3.Text.Trim().TrimStart() != "")
        {
            strContinencies = Convert.ToDecimal(txtContinenciesphase3.Text.Trim().TrimStart());
        }
        else
        {
            strContinencies = 0;
        }
        //-----------------------------------------------
        if (txtpreliminaryexpphase3.Text.Trim().TrimStart() != "")
        {
            strpreliminaryexp = Convert.ToDecimal(txtpreliminaryexpphase3.Text.Trim().TrimStart());
        }
        else
        {
            strpreliminaryexp = 0;
        }
        //-----------------------------------------------
        if (txtworkcapitalphase3.Text.Trim().TrimStart() != "")
        {
            strworkcapital = Convert.ToDecimal(txtworkcapitalphase3.Text.Trim().TrimStart());
        }
        else
        {
            strworkcapital = 0;
        }
        //-----------------------------------------------
        //  = 0,  = 0, 

        TotalProjCost = strland + strbuilding + strmachinaryimp + strmachinaryindenous + strmachinaryauxequ + strfixedassets + strContinencies + strpreliminaryexp + strworkcapital;

        txttotalprojcostphase3.Text = TotalProjCost.ToString();
    }






    protected void txtUnskilledemp_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalemp();
    }
    protected void txtSkilledemp_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalemp();
    }
    protected void txtSupervisoryemp_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalemp();
    }
    protected void txtManagerialemp_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalemp();
    }
    protected void txtskilledphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase2();
    }

    protected void txtsupervisoryphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase2();
    }

    protected void txtmanagerialphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase2();
    }
    protected void txtunskilledphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase2();
    }

    protected void txtmanagerialphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase3();
    }

    protected void txtunskilledphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase3();
    }
    protected void txtskilledphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase3();
    }
    protected void txtsupervisoryphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalempphase3();
    }





    private void CalculateTotalemp()
    {
        decimal Totalemp = 0, strUnskilledemp = 0, strSkilledemp = 0, strSupervisoryemp = 0, strManagerialemp = 0;

        if (txtUnskilledemp.Text.Trim().TrimStart() != "")
        {
            strUnskilledemp = Convert.ToDecimal(txtUnskilledemp.Text.Trim().TrimStart());
        }
        else
        {
            strUnskilledemp = 0;
        }
        //-----------------------------------------------
        if (txtSkilledemp.Text.Trim().TrimStart() != "")
        {
            strSkilledemp = Convert.ToDecimal(txtSkilledemp.Text.Trim().TrimStart());
        }
        else
        {
            strSkilledemp = 0;
        }
        //-----------------------------------------------
        if (txtSupervisoryemp.Text.Trim().TrimStart() != "")
        {
            strSupervisoryemp = Convert.ToDecimal(txtSupervisoryemp.Text.Trim().TrimStart());
        }
        else
        {
            strSupervisoryemp = 0;
        }
        //-----------------------------------------------
        if (txtManagerialemp.Text.Trim().TrimStart() != "")
        {
            strManagerialemp = Convert.ToDecimal(txtManagerialemp.Text.Trim().TrimStart());
        }
        else
        {
            strManagerialemp = 0;
        }
        //-----------------------------------------------

        Totalemp = strUnskilledemp + strSkilledemp + strSupervisoryemp + strManagerialemp;
        txttotalempdirect.Text = Totalemp.ToString();
    }

    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
        calculatetoatalequitydebit();
    }

    private void calculatetoatalequitydebit()
    {
        string message1 = "alert('Please Enter the Equity and Debt Information in lakhs only')";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message1, true);
        decimal Totalequity = 0, Domestic = 0, Foreign = 0, totalphase1 = 0, totalphase2 = 0, totalphase3 = 0, amount = 0;
        try
        {

            if (txtdomestic.Text.Trim().TrimStart() != "")
            {
                Domestic = Convert.ToDecimal(txtdomestic.Text.Trim().TrimStart());
            }
            else if (txtforeigns.Text.Trim().TrimStart() != "")
            {

                Foreign = Convert.ToDecimal(txtforeigns.Text.Trim().TrimStart());
            }
            else
            {
                txtamount.Text = "";

                string message = "alert('Please enter the Domestic details and Foreign Details first')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;

            }
            if (txtforeigns.Text.Trim().TrimStart() != "")
            {
                Foreign = Convert.ToDecimal(txtforeigns.Text.Trim().TrimStart());
            }
            else
            {
                Foreign = 0;
            }

            if (txtamount.Text.Trim().TrimStart() != "")
            {
                amount = Convert.ToDecimal(txtamount.Text.Trim().TrimStart());

            }
            else
            {
                amount = 0;
            }

            Totalequity = Domestic + Foreign + amount;
            if (txttotalprojcost.Text.Trim().TrimStart() != "")
            {
                totalphase1 = Convert.ToDecimal(txttotalprojcost.Text.Trim().TrimStart());
            }
            else
            {
                totalphase1 = 0;
            }

            if (txttotalprojcostphase2.Text.Trim().TrimStart() != "")
            {
                totalphase2 = Convert.ToDecimal(txttotalprojcostphase2.Text.Trim().TrimStart());
            }
            else
            {
                totalphase2 = 0;
            }

            if (txttotalprojcostphase3.Text.Trim().TrimStart() != "")
            {
                totalphase3 = Convert.ToDecimal(txttotalprojcostphase3.Text.Trim().TrimStart());
            }
            else
            {
                totalphase3 = 0;
            }
            TotalPhase = totalphase1 + totalphase2 + totalphase3;

            ViewState["Totalphase"] = TotalPhase;


            if (TotalPhase != Totalequity)
            {


                txtamount.Text = "";
                txteuitdebit.Text = "";

                string message = "alert('Total Estimated Project Cost should be equal to Equity and Debt Information')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;
            }
            //txtequity.Text = Totalequity.ToString();

            txteuitdebit.Text = Totalequity.ToString();

        }
        catch (Exception ex)
        {
        }

    }

    protected void txtmalephase1_TextChanged(object sender, EventArgs e)
    {

        decimal total = 0; decimal maletotal = 0; decimal totals = 0;




        if (txttotalempdirect.Text.TrimStart() == "")
        {
            txtmalephase1.Text = "";
            txtfemalephase1.Text = "";
            string message = "alert('Please fill Phase1 Direct  employment fields first')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }
        else
        {

            totals = Convert.ToDecimal(txttotalempdirect.Text);

            if (txtmalephase1.Text.Trim().TrimStart() != "")
            {

                maletotal = Convert.ToDecimal(txtmalephase1.Text);

                if (maletotal > totals)
                {
                    txtmalephase1.Text = "";
                    txtfemalephase1.Text = "";
                    string message = "alert('Male Phase 1 must be less than or equal to Direct Employment's Phase1 total')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    total = (totals - maletotal);

                }
            }

            else
            {
                txtmalephase1.Text = "";

                //string message = "alert('Enter Male Phase1')";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                //return;


            }


        }




        txtfemalephase1.Text = total.ToString();



    }

    protected void txtfemalephase1_TextChanged(object sender, EventArgs e)
    {
        decimal total = 0; decimal femaletotal = 0; decimal totals = 0;


        if (txttotalempdirect.Text == "")
        {

            txtmalephase1.Text = "";
            txtfemalephase1.Text = "";
            string message = "alert('Please fill Phase1 Direct  employment fields first')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }

        else
        {

            totals = Convert.ToDecimal(txttotalempdirect.Text);
            if (txtfemalephase1.Text.Trim().TrimStart() != "")
            {
                femaletotal = Convert.ToDecimal(txtfemalephase1.Text);

                if (femaletotal > totals)
                {
                    txtmalephase1.Text = "";
                    txtfemalephase1.Text = "";
                    string message = "alert('Female Phase 1 must be less than or equal to Direct Employment's Phase1 total')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    total = (totals - femaletotal);

                }
            }
            else
            {
                txtfemalephase1.Text = "";

            }


        }



        txtmalephase1.Text = total.ToString();



    }


    protected void txtmalephase2_TextChanged(object sender, EventArgs e)
    {



        decimal total = 0; decimal maletotal = 0; decimal totals = 0;


        if (txttotalempdirectphase2.Text.TrimStart() == "")
        {
            txtmalephase2.Text = "";
            txtfemalephase2.Text = "";
            string message = "alert('Please fill Phase2 Direct  employment fields first')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            totals = Convert.ToDecimal(txttotalempdirectphase2.Text);
            if (txtmalephase2.Text.Trim().TrimStart() != "")
            {

                maletotal = Convert.ToDecimal(txtmalephase2.Text);

                if (maletotal > totals)
                {
                    txtmalephase2.Text = "";
                    txtfemalephase2.Text = "";
                    string message = "alert('Male Phase 2 must be less than or equal to Direct Employment's Phase2 total')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    total = (totals - maletotal);

                }
            }
            else
            {

                txtmalephase2.Text = "";
                //total = (totals - maletotal);
                //txtfemalephase2.Text = total.ToString();

            }


            txtfemalephase2.Text = total.ToString();


        }
    }

    protected void txtfemalephase2_TextChanged(object sender, EventArgs e)
    {

        decimal total = 0; decimal femaletotal = 0; decimal totals = 0;


        if (txttotalempdirectphase2.Text.TrimStart() == "")
        {
            txtmalephase2.Text = "";
            txtfemalephase2.Text = "";
            string message = "alert('Please fill Phase2 Direct  employment fields first')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }

        else
        {

            totals = Convert.ToDecimal(txttotalempdirectphase2.Text);
            if (txtfemalephase2.Text.Trim().TrimStart() != "")
            {

                femaletotal = Convert.ToDecimal(txtfemalephase2.Text);

                if (femaletotal > totals)
                {
                    txtmalephase2.Text = "";
                    txtfemalephase2.Text = "";
                    string message = "alert('Female Phase 2 must be less than or equal to Direct Employment's Phase2 total')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    total = (totals - femaletotal);

                }


            }
            else
            {
                txtfemalephase1.Text = "";

                //total = (totals - femaletotal);
                //txtmalephase2.Text = total.ToString();

            }
        }

        txtmalephase2.Text = total.ToString();




    }

    protected void txtmalephase3_TextChanged(object sender, EventArgs e)
    {


        decimal total = 0; decimal maletotal = 0; decimal totals = 0;



        if (txttotalempdirectphase3.Text.TrimStart() == "")
        {
            txtmalephase3.Text = "";
            txtfemalephase3.Text = "";
            string message = "alert('Please fill Phase3 Direct  employment fields first')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            totals = Convert.ToDecimal(txttotalempdirectphase3.Text);

            if (txtmalephase3.Text.Trim().TrimStart() != "")
            {

                maletotal = Convert.ToDecimal(txtmalephase3.Text);

                if (maletotal > totals)
                {
                    txtmalephase3.Text = "";
                    txtfemalephase3.Text = "";
                    string message = "alert('Male Phase 3 must be less than or equal to Direct Employment's Phase3 total')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    total = (totals - maletotal);

                }
            }
            else
            {
                txtmalephase3.Text = "";
                //total = (totals - maletotal);
                //txtfemalephase3.Text = total.ToString();

            }

            txtfemalephase3.Text = total.ToString();

        }

    }




    protected void txtfemalephase3_TextChanged(object sender, EventArgs e)
    {


        decimal total = 0; decimal femaletotal = 0; decimal totals = 0;



        if (txttotalempdirectphase3.Text.TrimStart() == "")
        {
            txtmalephase3.Text = "";
            txtfemalephase3.Text = "";
            string message = "alert('Please fill Phase3 Direct  employment fields first')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }
        else
        {

            totals = Convert.ToDecimal(txttotalempdirectphase3.Text);
            if (txtfemalephase3.Text.Trim().TrimStart() != "")
            {

                femaletotal = Convert.ToDecimal(txtfemalephase3.Text);

                if (femaletotal > totals)
                {
                    txtmalephase3.Text = "";
                    txtfemalephase3.Text = "";
                    string message = "alert('Female Phase 3 must be less than or equal to Direct Employment's Phase3 total ')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    total = (totals - femaletotal);

                }
            }
            else
            {
                txtfemalephase3.Text = "";

                //total = (totals - femaletotal);
                //txtmalephase3.Text = total.ToString();

            }


            txtmalephase3.Text = total.ToString();

        }


    }




    protected void txtdomestic_TextChanged(object sender, EventArgs e)
    {
        calculateequitydebit();

        if (txtamount.Text.ToString().TrimStart() != "")
        {
            txtequity_TextChanged(sender, e);
        }




    }


    protected void txtequity_TextChanged(object sender, EventArgs e)
    {

        try
        {
            decimal Totalequity = 0, Amount = 0, totalphase1 = 0, totalphase2 = 0, totalphase3 = 0, totalphase = 0, totalequitdebit = 0;

            if (txtequity.Text.Trim().TrimStart() != "")
            {
                Totalequity = Convert.ToDecimal(txtequity.Text.Trim().TrimStart());

            }
            else
            {
                Totalequity = 0;
            }


            if (txtamount.Text.TrimStart() != "")
            {
                Amount = Convert.ToDecimal(txtamount.Text.Trim().TrimStart());



            }
            else
            {
                Amount = 0;
            }


            totalequitdebit = Totalequity + Amount;


            txteuitdebit.Text = totalequitdebit.ToString();



            if (txttotalprojcost.Text.Trim().TrimStart() != "")
            {
                totalphase1 = Convert.ToDecimal(txttotalprojcost.Text.Trim().TrimStart());
            }
            else
            {
                totalphase1 = 0;
            }

            if (txttotalprojcostphase2.Text.Trim().TrimStart() != "")
            {
                totalphase2 = Convert.ToDecimal(txttotalprojcostphase2.Text.Trim().TrimStart());
            }
            else
            {
                totalphase2 = 0;
            }

            if (txttotalprojcostphase3.Text.Trim().TrimStart() != "")
            {
                totalphase3 = Convert.ToDecimal(txttotalprojcostphase3.Text.Trim().TrimStart());
            }
            else
            {
                totalphase3 = 0;
            }
            totalphase = totalphase1 + totalphase2 + totalphase3;

            if (totalphase != totalequitdebit)
            {
                txtamount.Text = "";
                txteuitdebit.Text = "";


                string message = "alert('Total Estimated Project Cost should be equal to Equit" +
                    "" +
                    "" +
                    "y and Debt Information')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;
            }
        }
        catch (Exception)
        {

            throw;
        }




    }

    protected void txtforeigns_TextChanged(object sender, EventArgs e)
    {
        calculateequitydebit();


        if (txtamount.Text.ToString().TrimStart() != "")
        {
            txtequity_TextChanged(sender, e);
        }

    }


    private void calculateequitydebit()
    {
        string message1 = "alert('Please Enter the Domestic and Foriegn Equity and Debt Information in lakhs only')";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message1, true);
        decimal Totalequity = 0, Domestic = 0, Foreign = 0, totalphase1 = 0, totalphase2 = 0, totalphase3 = 0,
            totalphase = 0;
        try
        {




            if (txttotalprojcost.Text.Trim().TrimStart() != "")
            {
                totalphase1 = Convert.ToDecimal(txttotalprojcost.Text.Trim().TrimStart());
            }
            else
            {
                totalphase1 = 0;
            }

            if (txttotalprojcostphase2.Text.Trim().TrimStart() != "")
            {
                totalphase2 = Convert.ToDecimal(txttotalprojcostphase2.Text.Trim().TrimStart());
            }
            else
            {
                totalphase2 = 0;
            }

            if (txttotalprojcostphase3.Text.Trim().TrimStart() != "")
            {
                totalphase3 = Convert.ToDecimal(txttotalprojcostphase3.Text.Trim().TrimStart());
            }
            else
            {
                totalphase3 = 0;
            }
            totalphase = totalphase1 + totalphase2 + totalphase3;


            if (txtdomestic.Text.Trim().TrimStart() == "")
            {



                string message = "alert('Please enter the Domestic Details')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;

            }

            if (txtforeigns.Text.Trim().TrimStart() == "")
            {



                string message = "alert('Please enter the Foreign Details')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;

            }


            if (txtdomestic.Text.Trim().TrimStart() != "")
            {
                Domestic = Convert.ToDecimal(txtdomestic.Text.Trim().TrimStart());

            }
            else
            {
                Domestic = 0;

            }



            if (txtforeigns.Text.Trim().TrimStart() != "")
            {
                Foreign = Convert.ToDecimal(txtforeigns.Text.Trim().TrimStart());

            }
            else
            {
                Foreign = 0;

            }

            Totalequity = Domestic + Foreign;

            //if (Totalequity == totalphase)
            //{

            //    txtdomestic.Text = "";
            //    txtforeigns.Text = "";
            //    txtequity.Text = "";

            //    string message = "alert('Total Estimated Project Cose should be equal to Equity and Debt Information ')";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            //    return;
            //}

            txtequity.Text = Totalequity.ToString();



        }
        catch (Exception ex)
        {
        }

    }


    private void CalculateTotalempphase2()
    {
        decimal Totalemp = 0, strUnskilledemp = 0, strSkilledemp = 0, strSupervisoryemp = 0, strManagerialemp = 0;

        if (txtunskilledphase2.Text.Trim().TrimStart() != "")
        {
            strUnskilledemp = Convert.ToDecimal(txtunskilledphase2.Text.Trim().TrimStart());
        }
        else
        {
            strUnskilledemp = 0;
        }
        //-----------------------------------------------
        if (txtskilledphase2.Text.Trim().TrimStart() != "")
        {
            strSkilledemp = Convert.ToDecimal(txtskilledphase2.Text.Trim().TrimStart());
        }
        else
        {
            strSkilledemp = 0;
        }
        //-----------------------------------------------
        if (txtsupervisoryphase2.Text.Trim().TrimStart() != "")
        {
            strSupervisoryemp = Convert.ToDecimal(txtsupervisoryphase2.Text.Trim().TrimStart());
        }
        else
        {
            strSupervisoryemp = 0;
        }
        //-----------------------------------------------
        if (txtmanagerialphase2.Text.Trim().TrimStart() != "")
        {
            strManagerialemp = Convert.ToDecimal(txtmanagerialphase2.Text.Trim().TrimStart());
        }
        else
        {
            strManagerialemp = 0;
        }
        //-----------------------------------------------

        Totalemp = strUnskilledemp + strSkilledemp + strSupervisoryemp + strManagerialemp;
        txttotalempdirectphase2.Text = Totalemp.ToString();
    }


    private void CalculateTotalempphase3()
    {
        decimal Totalemp = 0, strUnskilledemp = 0, strSkilledemp = 0, strSupervisoryemp = 0, strManagerialemp = 0;

        if (txtunskilledphase3.Text.Trim().TrimStart() != "")
        {
            strUnskilledemp = Convert.ToDecimal(txtunskilledphase3.Text.Trim().TrimStart());
        }
        else
        {
            strUnskilledemp = 0;
        }
        //-----------------------------------------------
        if (txtskilledphase3.Text.Trim().TrimStart() != "")
        {
            strSkilledemp = Convert.ToDecimal(txtskilledphase3.Text.Trim().TrimStart());
        }
        else
        {
            strSkilledemp = 0;
        }
        //-----------------------------------------------
        if (txtsupervisoryphase3.Text.Trim().TrimStart() != "")
        {
            strSupervisoryemp = Convert.ToDecimal(txtsupervisoryphase3.Text.Trim().TrimStart());
        }
        else
        {
            strSupervisoryemp = 0;
        }
        //-----------------------------------------------
        if (txtmanagerialphase3.Text.Trim().TrimStart() != "")
        {
            strManagerialemp = Convert.ToDecimal(txtmanagerialphase3.Text.Trim().TrimStart());
        }
        else
        {
            strManagerialemp = 0;
        }
        //-----------------------------------------------

        Totalemp = strUnskilledemp + strSkilledemp + strSupervisoryemp + strManagerialemp;
        txttotalempdirectphase3.Text = Totalemp.ToString();
    }
    public string GeneralInformationcheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlSector_Ent.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of Venture \\n";
            slno = slno + 1;
        }
        if (ddlproposal.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Project Status \\n";
            slno = slno + 1;
        }
        if (ddlprojectcategory.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Project Category \\n";
            slno = slno + 1;
        }

        if (txtProjectNameDescription.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Project Name/Description \\n";
            slno = slno + 1;
        }
        if (txtdatecommercialoperations.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Expected date of commencement of commercial operations \\n";
            slno = slno + 1;
        }
        if (txtdatecommencementconstruction.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Expected date of commencement of construction \\n";
            slno = slno + 1;
        }
        if (txtdatetrialoperations.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Expected date of trial operations \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }

    private string ProjectCostCheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        decimal TotalProjCost = 0, strland = 0, strbuilding = 0, strmachinaryimp = 0, strmachinaryindenous = 0, strmachinaryauxequ = 0, strfixedassets = 0, strContinencies = 0, strpreliminaryexp = 0, strworkcapital = 0;

        if (txtland.Text.Trim().TrimStart() != "")
        {
            strland = Convert.ToDecimal(txtland.Text.Trim().TrimStart());
        }
        else
        {
            strland = 0;
        }
        //-----------------------------------------------
        if (txtbuilding.Text.Trim().TrimStart() != "")
        {
            strbuilding = Convert.ToDecimal(txtbuilding.Text.Trim().TrimStart());
        }
        else
        {
            strbuilding = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryimp.Text.Trim().TrimStart() != "")
        {
            strmachinaryimp = Convert.ToDecimal(txtmachinaryimp.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryimp = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryindenous.Text.Trim().TrimStart() != "")
        {
            strmachinaryindenous = Convert.ToDecimal(txtmachinaryindenous.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryindenous = 0;
        }
        //-----------------------------------------------
        if (txtmachinaryauxequ.Text.Trim().TrimStart() != "")
        {
            strmachinaryauxequ = Convert.ToDecimal(txtmachinaryauxequ.Text.Trim().TrimStart());
        }
        else
        {
            strmachinaryauxequ = 0;
        }
        //-----------------------------------------------
        if (txtfixedassets.Text.Trim().TrimStart() != "")
        {
            strfixedassets = Convert.ToDecimal(txtfixedassets.Text.Trim().TrimStart());
        }
        else
        {
            strfixedassets = 0;
        }
        //-----------------------------------------------
        if (txtContinencies.Text.Trim().TrimStart() != "")
        {
            strContinencies = Convert.ToDecimal(txtContinencies.Text.Trim().TrimStart());
        }
        else
        {
            strContinencies = 0;
        }
        //-----------------------------------------------
        if (txtpreliminaryexp.Text.Trim().TrimStart() != "")
        {
            strpreliminaryexp = Convert.ToDecimal(txtpreliminaryexp.Text.Trim().TrimStart());
        }
        else
        {
            strpreliminaryexp = 0;
        }
        //-----------------------------------------------
        if (txtworkcapital.Text.Trim().TrimStart() != "")
        {
            strworkcapital = Convert.ToDecimal(txtworkcapital.Text.Trim().TrimStart());
        }
        else
        {
            strworkcapital = 0;
        }
        //-----------------------------------------------
        //  = 0,  = 0, 

        // TotalProjCost = strland + strbuilding + strmachinaryimp + strmachinaryindenous + strmachinaryauxequ + strfixedassets + strContinencies + strpreliminaryexp + strworkcapital;

        if (strland == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Land Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (strbuilding == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Buildings Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        //if (strmachinaryimp == 0)  /commented on 23.12.19.
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Imported Value (Rs. in Lakhs) \\n";
        //    slno = slno + 1;
        //}
        if (strmachinaryindenous == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Indigenous Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (strmachinaryauxequ == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Auxiliary Equipment Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (strfixedassets == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Misc. Fixed Assets Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (strContinencies == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contingencies Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (strpreliminaryexp == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Preliminary and Pre-operative Expenses Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        if (strworkcapital == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Work Capital Margin Value (Rs. in Lakhs) \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    private string EmpCheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        decimal Totalemp = 0, strUnskilledemp = 0, strSkilledemp = 0, strSupervisoryemp = 0, strManagerialemp = 0, strfactworkers = 0, malephase1 = 0, femalephase1;

        if (txtUnskilledemp.Text.Trim().TrimStart() != "")
        {
            strUnskilledemp = Convert.ToDecimal(txtUnskilledemp.Text.Trim().TrimStart());
        }
        else
        {
            strUnskilledemp = 0;
        }
        //-----------------------------------------------
        if (txtSkilledemp.Text.Trim().TrimStart() != "")
        {
            strSkilledemp = Convert.ToDecimal(txtSkilledemp.Text.Trim().TrimStart());
        }
        else
        {
            strSkilledemp = 0;
        }
        //-----------------------------------------------
        if (txtSupervisoryemp.Text.Trim().TrimStart() != "")
        {
            strSupervisoryemp = Convert.ToDecimal(txtSupervisoryemp.Text.Trim().TrimStart());
        }
        else
        {
            strSupervisoryemp = 0;
        }
        //-----------------------------------------------
        if (txtManagerialemp.Text.Trim().TrimStart() != "")
        {
            strManagerialemp = Convert.ToDecimal(txtManagerialemp.Text.Trim().TrimStart());
        }
        else
        {
            strManagerialemp = 0;
        }
        //-----------------------------------------------

        // Totalemp = strUnskilledemp + strSkilledemp + strSupervisoryemp + strManagerialemp;

        if (strUnskilledemp == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unskilled Employment \\n";
            slno = slno + 1;
        }
        if (strSkilledemp == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Skilled Employment \\n";
            slno = slno + 1;
        }
        if (strSupervisoryemp == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Supervisory Employment \\n";
            slno = slno + 1;
        }
        if (strManagerialemp == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Managerial Employment \\n";
            slno = slno + 1;
        }

        if (txtMaximumempfactory.Text.Trim().TrimStart() != "")
        {
            strfactworkers = Convert.ToDecimal(txtMaximumempfactory.Text.Trim().TrimStart());
        }
        else
        {
            strfactworkers = 0;
        }
        if (strfactworkers == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Maximum no. of workers proposed to be employed in the factory \\n";
            slno = slno + 1;
        }
        //if (txtmalephase1.Text.Trim().TrimStart() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Male  \\n";
        //    slno = slno + 1;
        //}

        //if (txtfemalephase1.Text.Trim().TrimStart() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Female  \\n";
        //    slno = slno + 1;
        //}
        ////if (txtmalephase2.Text.Trim().TrimStart() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Male  \\n";
        //    slno = slno + 1;
        //}

        //if (txtfemalephase2.Text.Trim().TrimStart() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Female  \\n";
        //    slno = slno + 1;
        //}
        //if (txtmalephase3.Text.Trim().TrimStart() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Male  \\n";
        //    slno = slno + 1;
        //}

        //if (txtfemalephase3.Text.Trim().TrimStart() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Female  \\n";
        //    slno = slno + 1;
        //}


        return ErrorMsg;
    }
    private void CalculateTotalAreaofProjectCost()
    {
        decimal shedarea = 0; decimal TotalAreaofProjectCost = 0, strPlantFactoryBuildings = 0, strAdministrationBuildings = 0, strStorageWarehousing = 0, strRoadsWaterstorage = 0, strOpenAreasGreenBelt = 0;


        try
        {
            if (txtPlantFactoryBuildings.Text.Trim().TrimStart() != "")
            {
                strPlantFactoryBuildings = Convert.ToDecimal(txtPlantFactoryBuildings.Text.Trim().TrimStart());
            }
            else
            {
                strPlantFactoryBuildings = 0;
            }
            //-----------------------------------------------
            if (txtAdministrationBuildings.Text.Trim().TrimStart() != "")
            {
                strAdministrationBuildings = Convert.ToDecimal(txtAdministrationBuildings.Text.Trim().TrimStart());
            }
            else
            {
                strAdministrationBuildings = 0;
            }
            //-----------------------------------------------
            if (txtStorageWarehousing.Text.Trim().TrimStart() != "")
            {
                strStorageWarehousing = Convert.ToDecimal(txtStorageWarehousing.Text.Trim().TrimStart());
            }
            else
            {
                strStorageWarehousing = 0;
            }
            //-----------------------------------------------
            if (txtRoadsWaterstorage.Text.Trim().TrimStart() != "")
            {
                strRoadsWaterstorage = Convert.ToDecimal(txtRoadsWaterstorage.Text.Trim().TrimStart());
            }
            else
            {
                strRoadsWaterstorage = 0;
            }
            //-----------------------------------------------
            if (txtOpenAreasGreenBelt.Text.Trim().TrimStart() != "")
            {
                strOpenAreasGreenBelt = Convert.ToDecimal(txtOpenAreasGreenBelt.Text.Trim().TrimStart());
            }
            else
            {
                strOpenAreasGreenBelt = 0;
            }

            //-----------------------------------------------

            TotalAreaofProjectCost = strPlantFactoryBuildings + strAdministrationBuildings + strStorageWarehousing + strRoadsWaterstorage + strOpenAreasGreenBelt;
            txttotalAreaLandRequired.Text = TotalAreaofProjectCost.ToString();


            if (TextBox49.Text.Trim().TrimStart() != "")
            {
                shedarea = Convert.ToDecimal(TextBox49.Text.Trim().TrimStart());
            }
            else
            {
                shedarea = 0;
            }


            if (TotalAreaofProjectCost > shedarea)
            {

                Clearcontrols();
                string message = "alert('Total area of Land not more than selection of plot area')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;




            }
        }

        catch (Exception ex)
        {

        }

    }


    public void Clearcontrols()
    {
        txtPlantFactoryBuildings.Text = "";
        txtAdministrationBuildings.Text = "";
        txtStorageWarehousing.Text = "";
        txtOpenAreasGreenBelt.Text = "";
        txttotalAreaLandRequired.Text = "";
        txtRoadsWaterstorage.Text = "";
    }

    private void CalculateTotalAreaofProjectCostphase2()
    {
        decimal TotalAreaofProjectCost = 0, strPlantFactoryBuildings = 0, strAdministrationBuildings = 0, strStorageWarehousing = 0, strRoadsWaterstorage = 0, strOpenAreasGreenBelt = 0;

        if (txtPlantFactoryBuildingsphase2.Text.Trim().TrimStart() != "")
        {
            strPlantFactoryBuildings = Convert.ToDecimal(txtPlantFactoryBuildingsphase2.Text.Trim().TrimStart());
        }
        else
        {
            strPlantFactoryBuildings = 0;
        }
        //-----------------------------------------------
        if (txtAdministrationBuildingsphase2.Text.Trim().TrimStart() != "")
        {
            strAdministrationBuildings = Convert.ToDecimal(txtAdministrationBuildingsphase2.Text.Trim().TrimStart());
        }
        else
        {
            strAdministrationBuildings = 0;
        }
        //-----------------------------------------------
        if (txtStorageWarehousingphase2.Text.Trim().TrimStart() != "")
        {
            strStorageWarehousing = Convert.ToDecimal(txtStorageWarehousingphase2.Text.Trim().TrimStart());
        }
        else
        {
            strStorageWarehousing = 0;
        }
        //-----------------------------------------------
        if (txtRoadsWaterstoragephase2.Text.Trim().TrimStart() != "")
        {
            strRoadsWaterstorage = Convert.ToDecimal(txtRoadsWaterstoragephase2.Text.Trim().TrimStart());
        }
        else
        {
            strRoadsWaterstorage = 0;
        }
        //-----------------------------------------------
        if (txtOpenAreasGreenBeltphase2.Text.Trim().TrimStart() != "")
        {
            strOpenAreasGreenBelt = Convert.ToDecimal(txtOpenAreasGreenBeltphase2.Text.Trim().TrimStart());
        }
        else
        {
            strOpenAreasGreenBelt = 0;
        }

        //-----------------------------------------------

        TotalAreaofProjectCost = strPlantFactoryBuildings + strAdministrationBuildings + strStorageWarehousing + strRoadsWaterstorage + strOpenAreasGreenBelt;
        txttotalAreaLandRequiredphase2.Text = TotalAreaofProjectCost.ToString();
    }


    private void CalculateTotalAreaofProjectCostphase3()
    {
        decimal TotalAreaofProjectCost = 0, strPlantFactoryBuildings = 0, strAdministrationBuildings = 0, strStorageWarehousing = 0, strRoadsWaterstorage = 0, strOpenAreasGreenBelt = 0;

        if (txtPlantFactoryBuildingsphase3.Text.Trim().TrimStart() != "")
        {
            strPlantFactoryBuildings = Convert.ToDecimal(txtPlantFactoryBuildingsphase3.Text.Trim().TrimStart());
        }
        else
        {
            strPlantFactoryBuildings = 0;
        }
        //-----------------------------------------------
        if (txtAdministrationBuildingsphase3.Text.Trim().TrimStart() != "")
        {
            strAdministrationBuildings = Convert.ToDecimal(txtAdministrationBuildingsphase3.Text.Trim().TrimStart());
        }
        else
        {
            strAdministrationBuildings = 0;
        }
        //-----------------------------------------------
        if (txtStorageWarehousingphase3.Text.Trim().TrimStart() != "")
        {
            strStorageWarehousing = Convert.ToDecimal(txtStorageWarehousingphase3.Text.Trim().TrimStart());
        }
        else
        {
            strStorageWarehousing = 0;
        }
        //-----------------------------------------------
        if (txtRoadsWaterstoragephase3.Text.Trim().TrimStart() != "")
        {
            strRoadsWaterstorage = Convert.ToDecimal(txtRoadsWaterstoragephase3.Text.Trim().TrimStart());
        }
        else
        {
            strRoadsWaterstorage = 0;
        }
        //-----------------------------------------------
        if (txtOpenAreasGreenBeltphase3.Text.Trim().TrimStart() != "")
        {
            strOpenAreasGreenBelt = Convert.ToDecimal(txtOpenAreasGreenBeltphase3.Text.Trim().TrimStart());
        }
        else
        {
            strOpenAreasGreenBelt = 0;
        }

        //-----------------------------------------------

        TotalAreaofProjectCost = strPlantFactoryBuildings + strAdministrationBuildings + strStorageWarehousing + strRoadsWaterstorage + strOpenAreasGreenBelt;
        txttotalAreaLandRequiredphase3.Text = TotalAreaofProjectCost.ToString();
    }
    protected void txtPlantFactoryBuildings_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCost();
    }
    protected void txtPlantFactoryBuildingsphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase2();
    }
    protected void txtPlantFactoryBuildingsphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase3();
    }
    protected void txtAdministrationBuildingsphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase2();
    }
    protected void txtAdministrationBuildingsphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase3();
    }
    protected void txtStorageWarehousingphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase2();
    }
    protected void txtStorageWarehousingphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase3();
    }
    protected void txtRoadsWaterstoragephase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase2();
    }
    protected void txtRoadsWaterstoragephase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase3();
    }
    protected void txtOpenAreasGreenBeltphase2_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase2();
    }
    protected void txtOpenAreasGreenBeltphase3_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCostphase3();


    }

    protected void txtAdministrationBuildings_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCost();
    }
    protected void txtStorageWarehousing_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCost();
    }
    protected void txtRoadsWaterstorage_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCost();
    }
    protected void txtOpenAreasGreenBelt_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalAreaofProjectCost();

        //Areavalidation();





    }
    private string ProjectAreaCheck()
    {
        int slno = 1;
        string ErrorMsg = "";
        decimal TotalAreaofProjectCost = 0, strPlantFactoryBuildings = 0, strAdministrationBuildings = 0, strStorageWarehousing = 0, strRoadsWaterstorage = 0, strOpenAreasGreenBelt = 0;

        if (txtPlantFactoryBuildings.Text.Trim().TrimStart() != "")
        {
            strPlantFactoryBuildings = Convert.ToDecimal(txtPlantFactoryBuildings.Text.Trim().TrimStart());
        }
        else
        {
            strPlantFactoryBuildings = 0;
        }
        //-----------------------------------------------
        if (txtAdministrationBuildings.Text.Trim().TrimStart() != "")
        {
            strAdministrationBuildings = Convert.ToDecimal(txtAdministrationBuildings.Text.Trim().TrimStart());
        }
        else
        {
            strAdministrationBuildings = 0;
        }
        //-----------------------------------------------
        if (txtStorageWarehousing.Text.Trim().TrimStart() != "")
        {
            strStorageWarehousing = Convert.ToDecimal(txtStorageWarehousing.Text.Trim().TrimStart());
        }
        else
        {
            strStorageWarehousing = 0;
        }
        //-----------------------------------------------
        if (txtRoadsWaterstorage.Text.Trim().TrimStart() != "")
        {
            strRoadsWaterstorage = Convert.ToDecimal(txtRoadsWaterstorage.Text.Trim().TrimStart());
        }
        else
        {
            strRoadsWaterstorage = 0;
        }
        //-----------------------------------------------
        if (txtOpenAreasGreenBelt.Text.Trim().TrimStart() != "")
        {
            strOpenAreasGreenBelt = Convert.ToDecimal(txtOpenAreasGreenBelt.Text.Trim().TrimStart());
        }
        else
        {
            strOpenAreasGreenBelt = 0;
        }

        //-----------------------------------------------

        // TotalAreaofProjectCost = strPlantFactoryBuildings + strAdministrationBuildings + strStorageWarehousing + strRoadsWaterstorage + strOpenAreasGreenBelt;

        if (strPlantFactoryBuildings == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant and Factory Buildings \\n";
            slno = slno + 1;
        }
        if (strAdministrationBuildings == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Administration Buildings \\n";
            slno = slno + 1;
        }
        if (strStorageWarehousing == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Storage and Warehousing  \\n";
            slno = slno + 1;
        }
        if (strRoadsWaterstorage == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Roads,Water storage, sub-station etc. \\n";
            slno = slno + 1;
        }
        if (strOpenAreasGreenBelt == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Open Areas, Green Belt etc. \\n";
            slno = slno + 1;
        }
        return ErrorMsg;

    }

    protected void btnPlotsConfirmSave_Click(object sender, EventArgs e)
    {
        TsiicPropertiesMain VoTsiicPropertiesMain = new TsiicPropertiesMain();

        List<TsiicProperties> VotsiicPropertieslst = new List<TsiicProperties>();

        DataTable dt = (DataTable)Session["CertificateDirTb1"];

        if (ddlIndustrialParkName.SelectedValue == "0")
        {
            ddlIndustrialParkName.Enabled = true;
            string message = "alert('" + "Please select Industrial Park" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        #region CommentedCode
        //if (dt.Rows.Count != 0)
        //{
        //    if (ddlavailableplots.SelectedValue != "")
        //    {
        //        foreach (GridViewRow gvrow in grdDetails.Rows)
        //        {
        //            TsiicProperties tsii = new TsiicProperties();
        //            int rowIndex = gvrow.RowIndex;

        //            tsii.PlotNo = dt.Rows[rowIndex][2].ToString();
        //            //dsmypower.Tables[0].Rows[rowIndex][2].ToString();
        //            tsii.Areain_Sq_Mtrs = Convert.ToDecimal(dt.Rows[rowIndex][3]);
        //            //(dsmypower.Tables[0].Rows[rowIndex][3]);

        //            tsii.Created_by = Session["uid"].ToString();
        //            tsii.EMD_inRs = Convert.ToDecimal(dt.Rows[rowIndex][4]);
        //            //(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][5]);
        //            tsii.CGST = Convert.ToDecimal(dt.Rows[rowIndex][5]);
        //            //Convert.ToDecimal(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][5]);
        //            tsii.ProcessFee = Convert.ToDecimal(dt.Rows[rowIndex][6]);
        //            //Convert.ToDecimal(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][6]);
        //            tsii.Price_inRs = Convert.ToDecimal(dt.Rows[rowIndex][7]);
        //            //Convert.ToDecimal(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][7]);
        //            totalprice = tsii.Price_inRs;
        //            // tsii.plotdescripton = txttsiixplotexpl.Text;
        //            VotsiicPropertieslst.Add(tsii);
        //        }
        //    }
        //}
        //else
        //{
        //    foreach (GridViewRow gvrow in grdDetails.Rows)
        //    {
        //        int rowIndex = gvrow.RowIndex;
        //        TsiicProperties tsii = new TsiicProperties();
        //        tsii.PlotNo = dt1.Rows[rowIndex][2].ToString();
        //        //dsmypower.Tables[0].Rows[rowIndex][2].ToString();
        //        tsii.Areain_Sq_Mtrs = Convert.ToDecimal(dt1.Rows[rowIndex][3]);
        //        //(dsmypower.Tables[0].Rows[rowIndex][3]);
        //        tsii.Created_by = Session["uid"].ToString();
        //        tsii.EMD_inRs = Convert.ToDecimal(dt1.Rows[rowIndex][4]);
        //        //(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][5]);
        //        tsii.CGST = Convert.ToDecimal(dt1.Rows[rowIndex][5]);
        //        //Convert.ToDecimal(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][5]);
        //        tsii.ProcessFee = Convert.ToDecimal(dt1.Rows[rowIndex][6]);
        //        //Convert.ToDecimal(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][6]);
        //        tsii.Price_inRs = Convert.ToDecimal(dt1.Rows[rowIndex][7]);
        //        //Convert.ToDecimal(dsmypower.Tables["CertificateDirTb1"].Rows[rowIndex][7]);
        //        totalprice += tsii.Price_inRs;
        //        // tsii.plotdescripton = txttsiixplotexpl.Text;
        //        VotsiicPropertieslst.Add(tsii);
        //    }
        //}
        #endregion

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TsiicProperties tsii = new TsiicProperties();
            tsii.PlotNo = dt.Rows[i]["plotno"].ToString();
            tsii.Areain_Sq_Mtrs = Convert.ToDecimal(dt.Rows[i]["sqmts"].ToString());
            tsii.Price_inRs = Convert.ToDecimal(dt.Rows[i]["price"].ToString());
            tsii.EMD_inRs = Convert.ToDecimal(dt.Rows[i]["EMD"].ToString());
            tsii.PerSqrmtrPrice_inRs = Convert.ToDecimal(dt.Rows[i]["Persqmtsprice"].ToString());
            tsii.DistrictId = ddlProp_intDistrictid.SelectedValue;
            tsii.DistrictName = ddlProp_intDistrictid.SelectedItem.Text;
            tsii.Created_by = Session["uid"].ToString();
            tsii.IndustrialParkId = ddlIndustrialParkName.SelectedValue;
            tsii.IndustrialParkName = ddlIndustrialParkName.SelectedItem.Text;
            tsii.PlotNoID = dt.Rows[i]["plotid"].ToString();// ddlavailableplots.SelectedValue;
            VotsiicPropertieslst.Add(tsii);
        }

        VoTsiicPropertiesMain = (TsiicPropertiesMain)ViewState["TsiicPropertiesMain"];  // Taken from add plot details button click event

        int output = InsertUpdateDeleteflotdetails(VotsiicPropertieslst, VoTsiicPropertiesMain);

        ActiveIndex(1);



        //if (Convert.ToInt64(Request.QueryString["ApId"]) != 0)
        //{
        //    formdata();
        //}
    }







    public DataSet tsiicdetailsdata(Int64 createdby, Int64 applicationid)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@createdby",SqlDbType.Int),
                  new SqlParameter("@Appid",SqlDbType.Int),
                };
            p[0].Value = createdby;
            p[1].Value = applicationid;

            // XmlDocument doc = new XmlDocument(); USP_GET_RM_ABSTRACTDETAILS

            GDs = Gen.GenericFillDs("USP_GET_TSIICDETAILSss", p);


            GDs.Tables[0].TableName = "tsiicplotallotmentmain";
            GDs.Tables[1].TableName = "tsiicplotallotmentdetails";
            GDs.Tables[2].TableName = "tsiicapplicantdetails";
            GDs.Tables[3].TableName = "TSIICAttachments";



            return GDs;
        }
        catch (Exception ex)
        {
            throw ex;
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, HttpContext.Current.Session["uid"].ToString());
        }
    }



    private void AlertMessage(string message)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload=function(){");
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("')};");
        sb.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    }




    protected void rdIaLa_Lst_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (rdIaLa_Lst.SelectedValue.ToString() == "Y")
        {
            txtprovidedetails.Enabled = true;

        }
        else
        {
            txtprovidedetails.Enabled = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string errormsg = GeneralInformationcheck();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        errormsg = ProjectCostCheck();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        errormsg = EmpCheck();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }


        if (lblprojectupload.Text == "")
        {
            string message = "alert('" + " please upload the working sheets on project cost breakup " + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;


        }

        if (GridView2.Rows.Count == 0)
        {
            string message = "alert('" + " please Add Plant and Machinery Details" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (rawmaterialconsumption.Rows.Count == 0)
        {
            string message = "alert('" + " please Add Rawmaterial consumption Details" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (GridView1.Rows.Count == 0)
        {
            string message = "alert('" + " please Add Proposed Project Details" + "')";

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        if (txteuitdebit.Text == "" || txtequity.Text == "")
        {
            string message = "alert('" + " please Add Equity and Debt Information Details" + "')";

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;

        }

        decimal totalequitydebit = Convert.ToDecimal(txteuitdebit.Text.ToString());

        decimal totalphase1 = 0, totalphase2 = 0, totalphase3 = 0, totalphase = 0;

        if (txttotalprojcost.Text.Trim().TrimStart() != "")
        {
            totalphase1 = Convert.ToDecimal(txttotalprojcost.Text.Trim().TrimStart());
        }
        else
        {
            totalphase1 = 0;
        }

        if (txttotalprojcostphase2.Text.Trim().TrimStart() != "")
        {
            totalphase2 = Convert.ToDecimal(txttotalprojcostphase2.Text.Trim().TrimStart());
        }
        else
        {
            totalphase2 = 0;
        }

        if (txttotalprojcostphase3.Text.Trim().TrimStart() != "")
        {
            totalphase3 = Convert.ToDecimal(txttotalprojcostphase3.Text.Trim().TrimStart());
        }
        else
        {
            totalphase3 = 0;
        }
        totalphase = totalphase1 + totalphase2 + totalphase3;



        if (totalphase != totalequitydebit)
        {
            string message = "alert('Total Estimated Project Cost should be equal to Equity  and Debt Information')";

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;

        }




        ActiveIndex(4);
        Int64 Applicantid = Convert.ToInt64(Session["Applicationid"]);
        string Result = SaveAllFormDtls("3", Applicantid);
        if (Result.Trim().TrimStart() == "1")
        {
            string message = "alert('" + Result + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }





    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string errormsg = ProjectAreaCheck();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //errormsg = ProjectEnergyRequirementCheck();
        errormsg = errormsg + ProjectEnergyRequirementCheck();
        if (!IsValidIFSC(txtIfsccode.Text))
        {
            errormsg = errormsg + "Invalid IFSC Code!Please enter a valid 11 - character IFSC code.\\n";
            txtIfsccode.Text = "";

        }
        if (!IsValidAccountNumber(txtBanAccNO.Text))
        {

            errormsg = errormsg + "Invalid Account Number! Enter a valid number between 6 and 18 digits.\\n";
            txtBanAccNO.Text = "";

        }
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        if (txtBankName.Text == "0" || string.IsNullOrWhiteSpace(txtBankName.Text) || txtBankBranchName.Text == "0" || string.IsNullOrWhiteSpace(txtBankBranchName.Text) ||
           txtBanAccNO.Text == "0" || string.IsNullOrWhiteSpace(txtBanAccNO.Text) || txtTypeAccount.Text == "0" || string.IsNullOrWhiteSpace(txtTypeAccount.Text) ||
               txtAccountHolderName.Text == "0" || string.IsNullOrWhiteSpace(txtAccountHolderName.Text))
        {
            string message = "alert('Please enter all bank details other than zero')";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            Int64 Applicantid = Convert.ToInt64(Session["Applicationid"]);
            string Result = SaveAllFormDtls("4", Applicantid);
            if (Result.Trim().TrimStart() == "1")
            {
                string message = "alert('" + Result + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }

            if (Convert.ToDecimal(txttotalAreaLandRequired.Text) > Convert.ToDecimal(TextBox49.Text))
            {
                Clearcontrols();

                string message = "alert('Total area of Land should be equal or less than Plot Area')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", message, true);
                return;
            }

            if (Convert.ToInt64(Session["Applicationid"]) != 0)
            {
                Response.Redirect("frmtsiicattachments.aspx?appid=" + Session["Applicationid"].ToString());
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string errormsg = RegisteredAddreecheck();


        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        string errorms = CommunicationAddresscheck();
        if (errorms.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorms + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        Int64 Applicantid = Convert.ToInt64(Session["Applicationid"]);
        string Result = SaveAllFormDtls("1", Applicantid);
        ActiveIndex(2);
        if (Result.Trim().TrimStart() == "1")
        {
            string message = "alert('" + Result + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }
    protected void btnview3save_Click(object sender, EventArgs e)
    {
        string errormsg = ContactInfoAddreecheck();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        errormsg = FinancialInformationcheck();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        Int64 Applicantid = Convert.ToInt64(Session["Applicationid"]);
        string Result = SaveAllFormDtls("2", Applicantid);
        ActiveIndex(3);
        if (Result.Trim().TrimStart() == "1")
        {
            string message = "alert('" + Result + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }

    private string ProjectEnergyRequirementCheck()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtPowerrequirements.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Power requirements from TSTRANSCO (in KVA) \\n";
            slno = slno + 1;
        }
        if (txtContractedmaximumdemand.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contracted maximum demand (in KVA) \\n";
            slno = slno + 1;
        }
        if (txtRequiredpowersupplyline.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Required power supply line (KV) \\n";
            slno = slno + 1;
        }
        if (txtVoltagerating.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Voltage rating at which HT supplies required \\n";
            slno = slno + 1;
        }
        if (txtConnectedload.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Connected load (KW) \\n";
            slno = slno + 1;
        }
        if (txtLoadfactor.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Load factor \\n";
            slno = slno + 1;
        }
        if (txtConstructionphasedate.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Construction phase date \\n";
            slno = slno + 1;
        }
        if (txtCommercialproductiondate.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Commercial production date \\n";
            slno = slno + 1;
        }
        if (txtDomesticTemporary.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Peak Water Requirement for Temporary Domestic  \\n";
            slno = slno + 1;
        }
        if (txtIndustrialTemporary.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Peak Water Requirement for Temporary Industrial   \\n";
            slno = slno + 1;
        }

        if (txtDomesticPermanent.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Peak Water Requirement for Permanent Domestic  \\n";
            slno = slno + 1;
        }
        if (txtIndustrialPermanent.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Peak Water Requirement for Permanent Industrial   \\n";
            slno = slno + 1;
        }
        if (txtAccountHolderName.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the Account Holder Name  \\n";
            slno = slno + 1;
        }
        if (txtBanAccNO.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the Bank Account No   \\n";
            slno = slno + 1;
        }

        if (txtBankBranchName.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the  Branch Name  \\n";
            slno = slno + 1;
        }
        if (txtBankName.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the Bank Name   \\n";
            slno = slno + 1;
        }
        if (txtTypeAccount.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the  type of Account  \\n";
            slno = slno + 1;
        }
        if (txtIfsccode.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the IFSC Code   \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }

    protected void ddmanu_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlprojectcategory.SelectedValue != "11")
        {
            ddlprojectcategory1.Enabled = false;
            ddlprojectcategory1.SelectedValue = "0";
            txtProjectcategorytext.Text = "";
        }
        else
        {
            ddlprojectcategory1.Enabled = true;
            ddlprojectcategory1.SelectedValue = "0";
            txtProjectcategorytext.Text = "";
        }

    }



    public int InsertUpdateMainApplicantDtls(TsiicMainApplicantDtls Objdtls)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int ApplicationId = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("USP_INSERT_TSIIC_APPLICATION_DTLS", connection);
        command.CommandType = CommandType.StoredProcedure;
        try
        {
            command.Parameters.AddWithValue("@PageSaveNumber", Objdtls.PageSaveNumber);
            command.Parameters.AddWithValue("@ApplicationId", Objdtls.ApplicationId);
            command.Parameters.AddWithValue("@NameOftheFirm_Applicant", Objdtls.NameOftheFirm_Applicant);
            command.Parameters.AddWithValue("@Door_No_RegOffice", Objdtls.Door_No_RegOffice);
            command.Parameters.AddWithValue("@Street_1_RegOffice", Objdtls.Street_1_RegOffice);
            command.Parameters.AddWithValue("@Street_2_RegOffice", Objdtls.Street_2_RegOffice);
            command.Parameters.AddWithValue("@State_RegOffice", Objdtls.State_RegOffice);
            command.Parameters.AddWithValue("@Distid_RegOffice", Objdtls.Distid_RegOffice);
            command.Parameters.AddWithValue("@Mandal_RegOffice", Objdtls.Mandal_RegOffice);
            command.Parameters.AddWithValue("@Village_RegOffice", Objdtls.Village_RegOffice);
            command.Parameters.AddWithValue("@OtherState_RegOffice_flag", Objdtls.OtherState_RegOffice_flag);
            command.Parameters.AddWithValue("@DistName_RegOffice", Objdtls.DistName_RegOffice);
            command.Parameters.AddWithValue("@MandalName_RegOffice", Objdtls.MandalName_RegOffice);
            command.Parameters.AddWithValue("@VillageName_RegOffice", Objdtls.VillageName_RegOffice);
            command.Parameters.AddWithValue("@Pincode_RegOffice", Objdtls.Pincode_RegOffice);
            command.Parameters.AddWithValue("@TelephonoNo1_RegOffice", Objdtls.TelephonoNo1_RegOffice);
            command.Parameters.AddWithValue("@TelephonoNo2_RegOffice", Objdtls.TelephonoNo2_RegOffice);
            command.Parameters.AddWithValue("@FaxNo1_RegOffice", Objdtls.FaxNo1_RegOffice);
            command.Parameters.AddWithValue("@FaxNo2_RegOffice", Objdtls.FaxNo2_RegOffice);
            command.Parameters.AddWithValue("@Category_RegOffice", Objdtls.Category_RegOffice);
            command.Parameters.AddWithValue("@TypeofOrganization_RegOffice", Objdtls.TypeofOrganization_RegOffice);
            command.Parameters.AddWithValue("@GovtDeptName_RegOffice", Objdtls.GovtDeptName_RegOffice);
            command.Parameters.AddWithValue("@DiffCommunicationAddr_Flag", Objdtls.DiffCommunicationAddr_Flag);
            command.Parameters.AddWithValue("@Door_No_CommAddr", Objdtls.Door_No_CommAddr);
            command.Parameters.AddWithValue("@Street_1_CommAddr", Objdtls.Street_1_CommAddr);
            command.Parameters.AddWithValue("@Street_2_CommAddr", Objdtls.Street_2_CommAddr);
            command.Parameters.AddWithValue("@State_CommAddr", Objdtls.State_CommAddr);
            command.Parameters.AddWithValue("@Distid_CommAddr", Objdtls.Distid_CommAddr);
            command.Parameters.AddWithValue("@Mandal_CommAddr", Objdtls.Mandal_CommAddr);
            command.Parameters.AddWithValue("@Village_CommAddr", Objdtls.Village_CommAddr);
            command.Parameters.AddWithValue("@OtherState_CommAddr_flag", Objdtls.OtherState_CommAddr_flag);
            command.Parameters.AddWithValue("@DistName_CommAddr", Objdtls.DistName_CommAddr);
            command.Parameters.AddWithValue("@MandalName_CommAddr", Objdtls.MandalName_CommAddr);
            command.Parameters.AddWithValue("@VillageName_CommAddr", Objdtls.VillageName_CommAddr);
            command.Parameters.AddWithValue("@Pincode_CommAddr", Objdtls.Pincode_CommAddr);
            command.Parameters.AddWithValue("@TelephonoNo1_CommAddr", Objdtls.TelephonoNo1_CommAddr);
            command.Parameters.AddWithValue("@TelephonoNo2_CommAddr", Objdtls.TelephonoNo2_CommAddr);
            command.Parameters.AddWithValue("@FaxNo1_CommAddr", Objdtls.FaxNo1_CommAddr);
            command.Parameters.AddWithValue("@FaxNo2_CommAddr", Objdtls.FaxNo2_CommAddr);
            command.Parameters.AddWithValue("@YearofEstablishment_Firmregistration", Objdtls.YearofEstablishment_Firmregistration);
            command.Parameters.AddWithValue("@YearofCommencement_Firmregistration", Objdtls.YearofCommencement_Firmregistration);
            command.Parameters.AddWithValue("@RegistrationNo_Firmregistration ", Objdtls.RegistrationNo_Firmregistration);
            command.Parameters.AddWithValue("@RegisteringAuthority_Firmregistration ", Objdtls.RegisteringAuthority_Firmregistration);
            command.Parameters.AddWithValue("@PlotNo_Prv_flot", Objdtls.PlotNo_Prv_flot);
            command.Parameters.AddWithValue("@ShedName_Prv_flot", Objdtls.ShedName_Prv_flot);
            command.Parameters.AddWithValue("@House_Prv_flot", Objdtls.House_Prv_flot);
            command.Parameters.AddWithValue("@OtherDetails_Prv_flot", Objdtls.OtherDetails_Prv_flot);
            command.Parameters.AddWithValue("@Shop_Prv_flot", Objdtls.Shop_Prv_flot);
            command.Parameters.AddWithValue("@StatusAllotted_Lease_Name_Prv_flot", Objdtls.StatusAllotted_Lease_Name_Prv_flot);
            command.Parameters.AddWithValue("@Surname_Cont_info", Objdtls.Surname_Cont_info);
            command.Parameters.AddWithValue("@FirstName_Cont_info", Objdtls.FirstName_Cont_info);
            command.Parameters.AddWithValue("@Door_No_Cont_info", Objdtls.Door_No_Cont_info);
            command.Parameters.AddWithValue("@Street_1_Cont_info", Objdtls.Street_1_Cont_info);
            command.Parameters.AddWithValue("@Street_2_Cont_info", Objdtls.Street_2_Cont_info);
            command.Parameters.AddWithValue("@State_Cont_info", Objdtls.State_Cont_info);
            command.Parameters.AddWithValue("@Distid_Cont_info", Objdtls.Distid_Cont_info);
            command.Parameters.AddWithValue("@Mandal_Cont_info", Objdtls.Mandal_Cont_info);
            command.Parameters.AddWithValue("@Village_Cont_info", Objdtls.Village_Cont_info);
            command.Parameters.AddWithValue("@OtherState_Cont_info_flag", Objdtls.OtherState_Cont_info_flag);
            command.Parameters.AddWithValue("@DistName_Cont_info", Objdtls.DistName_Cont_info);
            command.Parameters.AddWithValue("@MandalName_Cont_info", Objdtls.MandalName_Cont_info);
            command.Parameters.AddWithValue("@VillageName_Cont_info", Objdtls.VillageName_Cont_info);
            command.Parameters.AddWithValue("@Pincode_Cont_info", Objdtls.Pincode_Cont_info);
            command.Parameters.AddWithValue("@MobileNo_Cont_info", Objdtls.MobileNo_Cont_info);
            command.Parameters.AddWithValue("@TelephonoNo1_Cont_info", Objdtls.TelephonoNo1_Cont_info);
            command.Parameters.AddWithValue("@TelephonoNo2_Cont_info", Objdtls.TelephonoNo2_Cont_info);
            command.Parameters.AddWithValue("@FaxNo1_Cont_info", Objdtls.FaxNo1_Cont_info);
            command.Parameters.AddWithValue("@FaxNo2_Cont_info", Objdtls.FaxNo2_Cont_info);
            command.Parameters.AddWithValue("@Email_Cont_info", Objdtls.Email_Cont_info);
            command.Parameters.AddWithValue("@ProposedProject_Financial", Objdtls.ProposedProject_Financial);
            command.Parameters.AddWithValue("@Assets_Financial_Inlakhs", Objdtls.Assets_Financial_Inlakhs);
            command.Parameters.AddWithValue("@Liabilities_Financial_Inlakhs", Objdtls.Liabilities_Financial_Inlakhs);
            command.Parameters.AddWithValue("@OtherAssets_Financial_Inlakhs", Objdtls.OtherAssets_Financial_Inlakhs);
            command.Parameters.AddWithValue("@Immovable_Assets_Land_Building_Financial", Objdtls.Immovable_Assets_Land_Building_Financial);
            command.Parameters.AddWithValue("@Anyother_Financial_Info", Objdtls.Anyother_Financial_Info);
            command.Parameters.AddWithValue("@PanNumber_Financial_Info", Objdtls.PanNumber_Financial_Info);
            command.Parameters.AddWithValue("@GstNumber", Objdtls.GSTNumber);
            command.Parameters.AddWithValue("@TypeofVenture_General_Info", Objdtls.TypeofVenture_General_Info);
            command.Parameters.AddWithValue("@ProjectStatus_General_Info", Objdtls.ProjectStatus_General_Info);
            command.Parameters.AddWithValue("@ProjectCategory1_General_Info", Objdtls.ProjectCategory1_General_Info);
            command.Parameters.AddWithValue("@ProjectCategory2_General_Info", Objdtls.ProjectCategory2_General_Info);
            command.Parameters.AddWithValue("@ProjectCategory3_General_Info", Objdtls.ProjectCategory3_General_Info);
            command.Parameters.AddWithValue("@ProjectName_Description_General_Info", Objdtls.ProjectName_Description_General_Info);
            command.Parameters.AddWithValue("@DtCommencement_Commercial_Operations_General_Info", Objdtls.DtCommencement_Commercial_Operations_General_Info);
            command.Parameters.AddWithValue("@Expected_Dt_Commencement_Construction_General_Info", Objdtls.Expected_Dt_Commencement_Construction_General_Info);
            command.Parameters.AddWithValue("@Expected_Dt_Trial_Operations_General_Info", Objdtls.Expected_Dt_Trial_Operations_General_Info);
            command.Parameters.AddWithValue("@DtCommencement_Commercial_Operations_General_Infophase2", Objdtls.DtCommencement_Commercial_Operations_General_Infophase2);
            command.Parameters.AddWithValue("@Expected_Dt_Commencement_Construction_General_Infophase2", Objdtls.Expected_Dt_Commencement_Construction_General_Infophase2);
            command.Parameters.AddWithValue("@Expected_Dt_Trial_Operations_General_Infophase2", Objdtls.Expected_Dt_Trial_Operations_General_Infophase2);
            command.Parameters.AddWithValue("@DtCommencement_Commercial_Operations_General_Infophase3", Objdtls.DtCommencement_Commercial_Operations_General_Infophase3);
            command.Parameters.AddWithValue("@Expected_Dt_Commencement_Construction_General_Infophase3", Objdtls.Expected_Dt_Commencement_Construction_General_Infophase3);
            command.Parameters.AddWithValue("@Expected_Dt_Trial_Operations_General_Infophase3", Objdtls.Expected_Dt_Trial_Operations_General_Infophase3);
            command.Parameters.AddWithValue("@Land_Project_Cost_Lakhs", Objdtls.Land_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Buildings_Project_Cost_Lakhs", Objdtls.Buildings_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Imported_Project_Cost_Lakhs", Objdtls.Imported_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Indigenous_Project_Cost_Lakhs", Objdtls.Indigenous_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@AuxiliaryEquipment_Project_Cost_Lakhs", Objdtls.AuxiliaryEquipment_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Misc_FixedAssets_Project_Cost_Lakhs", Objdtls.Misc_FixedAssets_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Contingencies_Project_Cost_Lakhs", Objdtls.Contingencies_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@PreliminaryExp_Project_Cost_Lakhs", Objdtls.PreliminaryExp_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@WorkCapitalMargin_Project_Cost_Lakhs", Objdtls.WorkCapitalMargin_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Total_Project_Cost_Lakhs", Objdtls.Total_Project_Cost_Lakhs);
            command.Parameters.AddWithValue("@Unskilled_Emp", Objdtls.Unskilled_Emp);
            command.Parameters.AddWithValue("@Skilled_Emp", Objdtls.Skilled_Emp);
            command.Parameters.AddWithValue("@Supervisory_Emp", Objdtls.Supervisory_Emp);
            command.Parameters.AddWithValue("@Managerial_Emp", Objdtls.Managerial_Emp);
            command.Parameters.AddWithValue("@Total_Emp", Objdtls.Total_Emp);
            command.Parameters.AddWithValue("@Land_Project_Cost_Lakhsphase2", Objdtls.Land_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Buildings_Project_Cost_Lakhsphase2", Objdtls.Buildings_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Imported_Project_Cost_Lakhsphase2", Objdtls.Imported_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Indigenous_Project_Cost_Lakhsphase2", Objdtls.Indigenous_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@AuxiliaryEquipment_Project_Cost_Lakhsphase2", Objdtls.AuxiliaryEquipment_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Misc_FixedAssets_Project_Cost_Lakhsphase2", Objdtls.Misc_FixedAssets_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Contingencies_Project_Cost_Lakhsphase2", Objdtls.Contingencies_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@PreliminaryExp_Project_Cost_Lakhsphase2", Objdtls.PreliminaryExp_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@WorkCapitalMargin_Project_Cost_Lakhsphase2", Objdtls.WorkCapitalMargin_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Total_Project_Cost_Lakhsphase2", Objdtls.Total_Project_Cost_Lakhsphase2);
            command.Parameters.AddWithValue("@Unskilled_Empphase2", Objdtls.Unskilled_Empphase2);
            command.Parameters.AddWithValue("@Skilled_Empphase2", Objdtls.Skilled_Empphase2);
            command.Parameters.AddWithValue("@Supervisory_Empphase2", Objdtls.Supervisory_Empphase2);
            command.Parameters.AddWithValue("@Managerial_Empphase2", Objdtls.Managerial_Empphase2);
            command.Parameters.AddWithValue("@Total_Empphase2", Objdtls.Total_Empphase2);
            command.Parameters.AddWithValue("@Land_Project_Cost_Lakhsphase3", Objdtls.Land_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Buildings_Project_Cost_Lakhsphase3", Objdtls.Buildings_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Imported_Project_Cost_Lakhsphase3", Objdtls.Imported_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Indigenous_Project_Cost_Lakhsphase3", Objdtls.Indigenous_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@AuxiliaryEquipment_Project_Cost_Lakhsphase3", Objdtls.AuxiliaryEquipment_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Misc_FixedAssets_Project_Cost_Lakhsphase3", Objdtls.Misc_FixedAssets_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Contingencies_Project_Cost_Lakhsphase3", Objdtls.Contingencies_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@PreliminaryExp_Project_Cost_Lakhsphase3", Objdtls.PreliminaryExp_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@WorkCapitalMargin_Project_Cost_Lakhsphase3", Objdtls.WorkCapitalMargin_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Total_Project_Cost_Lakhsphase3", Objdtls.Total_Project_Cost_Lakhsphase3);
            command.Parameters.AddWithValue("@Domestic", Objdtls.Domestic);
            command.Parameters.AddWithValue("@Foreigns", Objdtls.Foreigns);
            command.Parameters.AddWithValue("@TotalEquity", Objdtls.TotalEquity);
            command.Parameters.AddWithValue("@EquityName", Objdtls.EquityName);
            command.Parameters.AddWithValue("@Amount", Objdtls.Amount);
            command.Parameters.AddWithValue("@TotalEquitdebit", Objdtls.TotalEquitdebit);
            command.Parameters.AddWithValue("@Foreigninvestment", Objdtls.Foreigninvestment);
            command.Parameters.AddWithValue("@Foreigninvestmentdate", Objdtls.Foreigninvestmentdate);
            command.Parameters.AddWithValue("@IEM", Objdtls.IEM);
            command.Parameters.AddWithValue("@IEMdate", Objdtls.IEMdate);
            command.Parameters.AddWithValue("@LOI", Objdtls.LOI);
            command.Parameters.AddWithValue("@LOIdate", Objdtls.LOIdate);
            command.Parameters.AddWithValue("@EOUNo", Objdtls.EOUNo);
            command.Parameters.AddWithValue("@EOUdate", Objdtls.EOUdate);
            command.Parameters.AddWithValue("@Unskilled_Empphase3", Objdtls.Unskilled_Empphas3);
            command.Parameters.AddWithValue("@Skilled_Empphase3", Objdtls.Skilled_Empphase3);
            command.Parameters.AddWithValue("@Supervisory_Empphase3", Objdtls.Supervisory_Empphase3);
            command.Parameters.AddWithValue("@Managerial_Empphase3", Objdtls.Managerial_Empphase3);
            command.Parameters.AddWithValue("@Total_Empphase3", Objdtls.Total_Empphase3);
            command.Parameters.AddWithValue("@Workers_factory_emp", Objdtls.Workers_factory_emp);
            command.Parameters.AddWithValue("@malephase1", Objdtls.malephase1);
            command.Parameters.AddWithValue("@malephase2", Objdtls.malephase2);
            command.Parameters.AddWithValue("@malephase3", Objdtls.malephase3);
            command.Parameters.AddWithValue("@femalephase1", Objdtls.femalephase1);
            command.Parameters.AddWithValue("@femalephase2", Objdtls.femalephase2);
            command.Parameters.AddWithValue("@femalephase3", Objdtls.femalephase3);
            command.Parameters.AddWithValue("@process", txtuidno.Text);
            command.Parameters.AddWithValue("@techinical", rdIaLa_Lst.SelectedValue);
            command.Parameters.AddWithValue("@providedetails", txtprovidedetails.Text);
            command.Parameters.AddWithValue("@processtechnology", txtprocesstechnology.Text);
            //command.Parameters.AddWithValue("@filename", ViewState["AttachmentName"]);
            // command.Parameters.AddWithValue("@filepath", ViewState["pathAttachment"]);
            command.Parameters.AddWithValue("@highpressurevessels", RadioButtonList1.SelectedValue);
            command.Parameters.AddWithValue("@noofvessels", TextBox13.Text);
            command.Parameters.AddWithValue("@PlantFactoryBuildings_LandRequired", Objdtls.PlantFactoryBuildings_LandRequired);
            command.Parameters.AddWithValue("@AdministrationBuildings_LandRequired", Objdtls.AdministrationBuildings_LandRequired);
            command.Parameters.AddWithValue("@StorageWarehousing_LandRequired", Objdtls.StorageWarehousing_LandRequired);
            command.Parameters.AddWithValue("@RoadsWaterstorage_LandRequired", Objdtls.RoadsWaterstorage_LandRequired);
            command.Parameters.AddWithValue("@OpenAreasGreenBelt_LandRequired", Objdtls.OpenAreasGreenBelt_LandRequired);
            command.Parameters.AddWithValue("@Total_LandRequired", Objdtls.Total_LandRequired);
            command.Parameters.AddWithValue("@PlantFactoryBuildings_LandRequiredphase2", Objdtls.PlantFactoryBuildings_LandRequiredphase2);
            command.Parameters.AddWithValue("@AdministrationBuildings_LandRequiredphase2", Objdtls.AdministrationBuildings_LandRequiredphase2);
            command.Parameters.AddWithValue("@StorageWarehousing_LandRequiredphase2", Objdtls.StorageWarehousing_LandRequiredphase2);
            command.Parameters.AddWithValue("@RoadsWaterstorage_LandRequiredphase2", Objdtls.RoadsWaterstorage_LandRequiredphase2);
            command.Parameters.AddWithValue("@OpenAreasGreenBelt_LandRequiredphase2", Objdtls.OpenAreasGreenBelt_LandRequiredphase2);
            command.Parameters.AddWithValue("@Total_LandRequiredphase2", Objdtls.Total_LandRequiredphase2);
            command.Parameters.AddWithValue("@PlantFactoryBuildings_LandRequiredphase3", Objdtls.PlantFactoryBuildings_LandRequiredphase3);
            command.Parameters.AddWithValue("@AdministrationBuildings_LandRequiredphase3", Objdtls.AdministrationBuildings_LandRequiredphase3);
            command.Parameters.AddWithValue("@StorageWarehousing_LandRequiredphase3", Objdtls.StorageWarehousing_LandRequiredphase3);
            command.Parameters.AddWithValue("@RoadsWaterstorage_LandRequiredphase3", Objdtls.RoadsWaterstorage_LandRequiredphase3);
            command.Parameters.AddWithValue("@OpenAreasGreenBelt_LandRequiredphase3", Objdtls.OpenAreasGreenBelt_LandRequiredphase3);
            command.Parameters.AddWithValue("@Total_LandRequiredphase3", Objdtls.Total_LandRequiredphase3);
            command.Parameters.AddWithValue("@tstranscosupply", Objdtls.Tstranscosupply);
            command.Parameters.AddWithValue("@owngeneration", Objdtls.Owngeneration);
            command.Parameters.AddWithValue("@Dgset", Objdtls.Dgset);
            command.Parameters.AddWithValue("@TSTRANSCO_Energy_KVA", Objdtls.TSTRANSCO_Energy_KVA);
            command.Parameters.AddWithValue("@ContractedMaxDem_KVA", Objdtls.ContractedMaxDem_KVA);
            command.Parameters.AddWithValue("@Req_PowerSupply_KV", Objdtls.Req_PowerSupply_KV);
            command.Parameters.AddWithValue("@VoltageRating_HT", Objdtls.VoltageRating_HT);
            command.Parameters.AddWithValue("@Connectedload_KW", Objdtls.Connectedload_KW);
            command.Parameters.AddWithValue("@Loadfactor", Objdtls.Loadfactor);
            command.Parameters.AddWithValue("@TSTRANSCO_Energy_KVAphase2", Objdtls.TSTRANSCO_Energy_KVAphase2);
            command.Parameters.AddWithValue("@ContractedMaxDem_KVAphase2", Objdtls.ContractedMaxDem_KVphase2);
            command.Parameters.AddWithValue("@Req_PowerSupply_KVphase2", Objdtls.Req_PowerSupply_KVphase2);
            command.Parameters.AddWithValue("@VoltageRating_HTphase2", Objdtls.VoltageRating_HTphase2);
            command.Parameters.AddWithValue("@Connectedload_KWphase2", Objdtls.Connectedload_KWphase2);
            command.Parameters.AddWithValue("@Loadfactorphase2", Objdtls.Loadfactorphase2);
            command.Parameters.AddWithValue("@TSTRANSCO_Energy_KVAphase3", Objdtls.TSTRANSCO_Energy_KVAphase3);
            command.Parameters.AddWithValue("@ContractedMaxDem_KVAphase3", Objdtls.ContractedMaxDem_KVAphase3);
            command.Parameters.AddWithValue("@Req_PowerSupply_KVphase3", Objdtls.Req_PowerSupply_KVphase3);
            command.Parameters.AddWithValue("@VoltageRating_HTphase3", Objdtls.VoltageRating_HTphase3);
            command.Parameters.AddWithValue("@Connectedload_KWphase3", Objdtls.Connectedload_KWphase3);
            command.Parameters.AddWithValue("@Loadfactorphase3", Objdtls.Loadfactorphase3);
            command.Parameters.AddWithValue("@Dt_Construction_PowerSupply", Objdtls.Dt_Construction_PowerSupply);
            command.Parameters.AddWithValue("@Dt_Commercial_PowerSupply", Objdtls.Dt_Commercial_PowerSupply);
            command.Parameters.AddWithValue("@Dt_Construction_PowerSupplyphase2", Objdtls.Dt_Construction_PowerSupplyphase2);
            command.Parameters.AddWithValue("@Dt_Commercial_PowerSupplyphase2", Objdtls.Dt_Commercial_PowerSupplyphase2);
            command.Parameters.AddWithValue("@Dt_Construction_PowerSupplyphase3", Objdtls.Dt_Construction_PowerSupplyphase3);
            command.Parameters.AddWithValue("@Dt_Commercial_PowerSupplyphase3", Objdtls.Dt_Commercial_PowerSupplyphase3);
            command.Parameters.AddWithValue("@Domestic_Temp_WaterReq", Objdtls.Domestic_Temp_WaterReq);
            command.Parameters.AddWithValue("@Industrial_Temp_WaterReq", Objdtls.Industrial_Temp_WaterReq);
            command.Parameters.AddWithValue("@Domestic_Perm_WaterReq", Objdtls.Domestic_Perm_WaterReq);
            command.Parameters.AddWithValue("@Industrial_Perm_WaterReq", Objdtls.Industrial_Perm_WaterReq);
            command.Parameters.AddWithValue("@Domestic_Temp_WaterReqphase2", Objdtls.Domestic_Temp_WaterReqphase2);
            command.Parameters.AddWithValue("@Industrial_Temp_WaterReqphase2", Objdtls.Industrial_Temp_WaterReqphase2);
            command.Parameters.AddWithValue("@Domestic_Perm_WaterReqphase2", Objdtls.Domestic_Perm_WaterReqphase2);
            command.Parameters.AddWithValue("@Industrial_Perm_WaterReqphase2", Objdtls.Industrial_Perm_WaterReqphase2);
            command.Parameters.AddWithValue("@Domestic_Temp_WaterReqphase3", Objdtls.Domestic_Temp_WaterReqphase3);
            command.Parameters.AddWithValue("@Industrial_Temp_WaterReqphase3", Objdtls.Industrial_Temp_WaterReqphase3);
            command.Parameters.AddWithValue("@Domestic_Perm_WaterReqphase3", Objdtls.Domestic_Perm_WaterReqphase3);
            command.Parameters.AddWithValue("@Industrial_Perm_WaterReqphase3", Objdtls.Industrial_Perm_WaterReqphase3);
            command.Parameters.AddWithValue("@Effluentsphase1", Objdtls.Effluentsphase1);
            command.Parameters.AddWithValue("@Effluentsphase2", Objdtls.Effluentsphase2);
            command.Parameters.AddWithValue("@Effluentsphase3", Objdtls.Effluentsphase3);
            command.Parameters.AddWithValue("@SolidWastephase1", Objdtls.SolidWastephase1);
            command.Parameters.AddWithValue("@SolidWastephase2", Objdtls.SolidWastephase2);
            command.Parameters.AddWithValue("@SolidWastephase3", Objdtls.SolidWastephase3);
            command.Parameters.AddWithValue("@Descriptioneffulents", Objdtls.Descriptioneffulents);
            command.Parameters.AddWithValue("@Created_by", Objdtls.Created_by);
            command.Parameters.AddWithValue("@AccountHolderName", Objdtls.AccountHolderName);
            command.Parameters.AddWithValue("@AccountNo", Objdtls.AccountNo);
            command.Parameters.AddWithValue("@BankName", Objdtls.BankName);
            command.Parameters.AddWithValue("@BranchName", Objdtls.BranchName);
            command.Parameters.AddWithValue("@Ifsccode", Objdtls.Ifsccode);
            command.Parameters.AddWithValue("@TypeofAccount", Objdtls.TypeofAccount);
            command.Parameters.AddWithValue("@Industrialshed", Objdtls.Industrialshed);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            trans.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        return ApplicationId;
    }
    public int InsertUpdateDeleteflotdetails(List<TsiicProperties> VotsiicPropertieslst, TsiicPropertiesMain VoTsiicPropertiesMain)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int ApplicationId = 0;
        SqlConnection connection = new SqlConnection(str);

        SqlTransaction trans = null;
        // SqlTransaction transs = null;

        connection.Open();

        trans = connection.BeginTransaction();
        // transs = connection1.BeginTransaction();


        SqlCommand command = new SqlCommand();
        SqlCommand command1 = new SqlCommand();
        SqlCommand command2 = new SqlCommand();

        try
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "USP_INSERT_TSIIC_MAIN_DTLS";
            command.Transaction = trans;
            command.Connection = connection;
            command.Parameters.AddWithValue("@ApplicationIdNew", VoTsiicPropertiesMain.ApplicationId); //
            command.Parameters.AddWithValue("@DistrctID", VoTsiicPropertiesMain.DistrictId); //
            command.Parameters.AddWithValue("@IndustrialParkId", VoTsiicPropertiesMain.IndustrialParkId); //
            command.Parameters.AddWithValue("@PlotTotalArea", VoTsiicPropertiesMain.PlotTotalArea); //
            command.Parameters.AddWithValue("@PlotTotalamount", VoTsiicPropertiesMain.PlotTotalamount); //
            command.Parameters.AddWithValue("@TotalEmd", VoTsiicPropertiesMain.TotalEmd); //
            command.Parameters.AddWithValue("@ProcessFee", VoTsiicPropertiesMain.ProcessFee); //
            command.Parameters.AddWithValue("@CGST", VoTsiicPropertiesMain.CGST); //
            command.Parameters.AddWithValue("@SGST", VoTsiicPropertiesMain.SGST); //
            command.Parameters.AddWithValue("@Amounttobepaid", VoTsiicPropertiesMain.Amounttobepaid); //
            command.Parameters.AddWithValue("@Created_by", VoTsiicPropertiesMain.Created_by); //
            command.Parameters.AddWithValue("@IndustrialParkNAME", VoTsiicPropertiesMain.IndustrialParkNAME); //
            command.Parameters.AddWithValue("@PlotID", VoTsiicPropertiesMain.PlotID); //
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;
            command.Parameters.Add("@ApplicationId", SqlDbType.Int, 500);
            command.Parameters["@ApplicationId"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            //trans.Commit();
            valid = (Int32)command.Parameters["@VALID"].Value;
            Session["Applicationid"] = (Int32)command.Parameters["@ApplicationId"].Value;
            //connection.Close();

            if (valid == 1 && Convert.ToInt64(Session["Applicationid"]) != 0)
            {
                command1.CommandText = "USP_INSERT_TSIIC_deletedpLOT_DTLS";
                command1.CommandType = CommandType.StoredProcedure;
                command1.Transaction = trans;
                command1.Connection = connection;
                command1.Parameters.AddWithValue("@ApplicationId", Convert.ToInt64(Session["Applicationid"]));
                command1.ExecuteNonQuery();

                foreach (TsiicProperties VotsiicProperties in VotsiicPropertieslst)
                {
                    command2 = new SqlCommand();
                    command2.CommandText = "USP_INSERT_TSIIC_SELECTEDFLOT_DTLS";
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Transaction = trans;
                    command2.Connection = connection;
                    command2.Parameters.AddWithValue("@ApplicationId", Convert.ToInt64(Session["Applicationid"]));
                    command2.Parameters.AddWithValue("@PlotNo", VotsiicProperties.PlotNo);
                    command2.Parameters.AddWithValue("@Area_in_Sq_Mtrs", VotsiicProperties.Areain_Sq_Mtrs);
                    command2.Parameters.AddWithValue("@Persqmtsprice", VotsiicProperties.PerSqrmtrPrice_inRs);
                    command2.Parameters.AddWithValue("@Price", VotsiicProperties.Price_inRs);
                    command2.Parameters.AddWithValue("@EMD", VotsiicProperties.EMD_inRs);
                    command2.Parameters.AddWithValue("@DistrictId", VotsiicProperties.DistrictId);
                    command2.Parameters.AddWithValue("@DistrictName", VotsiicProperties.DistrictName);
                    command2.Parameters.AddWithValue("@IndustrialParkId", VotsiicProperties.IndustrialParkId);
                    command2.Parameters.AddWithValue("@IndustrialParkName", VotsiicProperties.IndustrialParkName);
                    command2.Parameters.AddWithValue("@Created_by", VotsiicProperties.Created_by);
                    command2.Parameters.AddWithValue("@PlotnoID", VotsiicProperties.PlotNoID);
                    command2.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command2.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command2.ExecuteNonQuery();

                    valid = (int)command2.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            //connection2.Close();
        }

        catch (Exception ex)
        {
            command2.Dispose();
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            command1.Dispose();
            command2.Dispose();
            connection.Close();
            connection.Dispose();
        }
        return ApplicationId;
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Texthd = e.Row.Cells[3].Text.ToString();
                ImageButton imgbtn = (ImageButton)e.Row.FindControl("ImageButton1");
                if (Texthd.ToUpper().Trim().TrimStart() == "TOTAL")
                {
                    e.Row.Font.Bold = true;

                    e.Row.Cells[0].ColumnSpan = 4;
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells.RemoveAt(1);
                    e.Row.Cells.RemoveAt(1);
                    e.Row.Cells.RemoveAt(1);
                    // e.Row.Cells.RemoveAt(1);
                    //e.Row.Cells.RemoveAt(3);
                    e.Row.Cells[0].Text = Texthd;
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                    //e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E5E5");    // "#E5E5E5"
                    //e.Row.Attributes.CssStyle.Value = "background-color: #E5E5E5;";
                    e.Row.Attributes.Add("class", "highlighted");
                    imgbtn.Visible = false;
                }

                Texthd = e.Row.Cells[5].Text.ToString();
                if (Texthd.Trim().TrimStart() == "Process Fee" || Texthd.Trim().TrimStart() == "CGST" || Texthd.Trim().TrimStart() == "SGST" || Texthd.Trim().TrimStart() == "Amount to be paid")
                {
                    e.Row.Font.Bold = true;
                    e.Row.Cells[0].ColumnSpan = 6;
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells.RemoveAt(1);
                    e.Row.Cells.RemoveAt(1);
                    e.Row.Cells.RemoveAt(1);
                    e.Row.Cells.RemoveAt(1);
                    e.Row.Cells.RemoveAt(1);
                    //e.Row.Cells.RemoveAt(3);
                    e.Row.Cells[0].Text = Texthd;
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Attributes.Add("class", "highlighted");
                    imgbtn.Visible = false;
                }

            }

            TextBox49.Text = ViewState["total"].ToString();


        }
        catch (Exception ex)
        {
        }
    }











    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        string newPath = "";


        string filePath = string.Empty;

        if (fupResAttachment.HasFile)
        {

            if ((fupResAttachment.PostedFile != null) && (fupResAttachment.PostedFile.ContentLength > 0))
            {
                filePath = System.IO.Path.GetFileName(fupResAttachment.PostedFile.FileName);
                try
                {


                    string[] fileType = fupResAttachment.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        string serverpath = Server.MapPath("~\\UI\\TSIPASS\\Tsiicrawattachments\\" + Session["ApplicationId"].ToString());  // incentiveid2

                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);
                        fupResAttachment.PostedFile.SaveAs(serverpath + "\\" + filePath);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = filePath;
                        int result = 0;

                        result = InsertAttachement(Convert.ToInt64(Session["ApplicationId"]), filePath, serverpath, Convert.ToInt64(Session["uid"]), 15);


                        if (result > 0)
                        {

                            HyperLink1.Text = fupResAttachment.FileName;
                            Label444.Text = fupResAttachment.FileName;

                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {

                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }



                    }
                    else
                    {
                        Label444.Visible = true;

                        Label444.Text = "<font color='red'>Upload Pdf Only</font>";

                    }




                }
                catch (Exception ex)//in case of an error
                {


                    throw ex;

                }
            }
        }
        else
        {
            Response.Write("<script>alert('Attachment Failed to Add ')</script> ");

        }
    }




    public int InsertAttachement(Int64 appid, string AttachmentFilename, string AttachmentFilePath, Int64 Created_by, int attachmentid)
    {
        try
        {

            string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("USP_INS_TsiicATTACHMENTS", con);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Convert.ToInt64(Session["ApplicationId"]) == 0 || Session["ApplicationId"] == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@appid", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@appid", SqlDbType.BigInt).Value = appid;
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (attachmentid == 0 || attachmentid == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@attachmentid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@attachmentid", SqlDbType.VarChar).Value = Convert.ToInt32(attachmentid);
            }


            if (Created_by == 0 || Created_by == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Convert.ToInt64(Created_by);
            }
            myDataAdapter.SelectCommand.Parameters.Add("@Result", SqlDbType.VarChar, 500);
            myDataAdapter.SelectCommand.Parameters["@Result"].Direction = ParameterDirection.Output;








            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {



        }
    }




    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();

                dt = (DataTable)Session["Proposedprj"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["Proposedprj"] = dt;
                if (dt.Rows.Count > 0)
                {
                    prosed(dt);
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }


            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }



    protected void Addlpromotordetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();

                dt = (DataTable)Session["CertificateDir"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["CertificateDir"] = dt;
                if (dt.Rows.Count > 0)
                {
                    dsgvaddl(dt);
                }
                else
                {
                    Addlpromotordetails.DataSource = dt;
                    Addlpromotordetails.DataBind();
                }


            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }



    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();
                dt = (DataTable)Session["CertificateDirTb1"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["CertificateDirTb1"] = dt;
                if (dt.Rows.Count > 0)
                {
                    bindfeegrid(dt);
                }
                else
                {
                    grdDetails.DataSource = dt;
                    grdDetails.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    protected void rawmaterialconsumption_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();
                dt = (DataTable)Session["Certificate"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["Certificate"] = dt;
                if (dt.Rows.Count > 0)
                {
                    Rawed(dt);
                }
                else
                {
                    rawmaterialconsumption.DataSource = dt;
                    rawmaterialconsumption.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }



    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();
                dt = (DataTable)Session["CertificateDirTb5"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["CertificateDirTb5"] = dt;
                if (dt.Rows.Count > 0)
                {
                    plantmachinery(dt);
                }
                else
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        string newPath = "";


        string filePath = string.Empty;

        if (fileprojectupload.HasFile)
        {

            if ((fileprojectupload.PostedFile != null) && (fileprojectupload.PostedFile.ContentLength > 0))
            {
                filePath = System.IO.Path.GetFileName(fileprojectupload.PostedFile.FileName);
                try
                {
                    string[] fileType = fileprojectupload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        string serverpath = Server.MapPath("~\\UI\\TSIPASS\\Projectattachments\\" + Session["ApplicationId"].ToString());  // incentiveid2

                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);
                        fileprojectupload.PostedFile.SaveAs(serverpath + "\\" + filePath);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = filePath;
                        int result = 0;

                        result = InsertAttachement(Convert.ToInt64(Session["ApplicationId"]), filePath, serverpath, Convert.ToInt64(Session["uid"]), 14);


                        if (result > 0)
                        {

                            hyprojectupload.Text = fileprojectupload.FileName;
                            lblprojectupload.Text = fileprojectupload.FileName;

                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {

                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }




                    }
                    else
                    {
                        lblprojectupload.Visible = true;

                        lblprojectupload.Text = "<font color='red'>Upload Pdf Only</font>";

                    }




                }
                catch (Exception ex)//in case of an error
                {


                    throw ex;

                }
            }
        }
        else
        {
            Response.Write("<script>alert('Attachment Added Failed')</script> ");

        }
    }
    protected void txtIfsccode_TextChanged(object sender, EventArgs e)
    {
        string ifscCode = txtIfsccode.Text.Trim();
        if (IsValidIFSC(ifscCode))
        {

          //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Valid IFSC Code!');", true);
          //  return;
        }
        else
        {
            txtIfsccode.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Invalid IFSC Code! Please enter a valid 11-character IFSC code.');", true);
            return;
        }
    }

    private bool IsValidIFSC(string ifsc)
    {
        // IFSC Regex Pattern: First 4 letters, 5th character is '0', last 6 are alphanumeric
        string pattern = @"^[A-Z]{4}0[A-Z0-9]{6}$";
        return Regex.IsMatch(ifsc, pattern, RegexOptions.IgnoreCase);
    }

    protected void txtBanAccNO_TextChanged(object sender, EventArgs e)
    {
        string accountNumber = txtBanAccNO.Text.Trim();
        if (IsValidAccountNumber(accountNumber))
        {

           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Valid Bank Account Number!');", true);
            //return;
        }
        else
        {
            txtBanAccNO.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Invalid Account Number! Enter a valid number between 6 and 18 digits.');", true);
            return;
        }

    }

    private bool IsValidAccountNumber(string accountNumber)
    {
        // Regex Pattern: Account number should be between 6 and 18 digits
        string pattern = @"^\d{6,18}$";
        return Regex.IsMatch(accountNumber, pattern);
    }
}