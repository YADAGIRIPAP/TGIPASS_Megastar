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

public partial class UI_TSiPASS_frmPulgandplayDetails : System.Web.UI.Page
{
    General Gen = new General();
    TsiicProperties tsiic = new TsiicProperties();
    CommonBL objcommon = new CommonBL();
    TSIICPLOTCGG.TSPlotDetailsService tsiicplotobj = new TSIICPLOTCGG.TSPlotDetailsService();
    DB.DB con = new DB.DB();

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
    //List<Emp> lstEmp = new List<Emp>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDistricts();
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
                ddlIndustrialParkName.Enabled = true;

                DataSet dsnew = new DataSet();
                dsnew = GETPLUGANDPLAYDETAILS(ddlProp_intDistrictid.SelectedValue,ddlIndustrialParkName.SelectedValue);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    pre1.Visible = true;
                    pre2.Visible = true;
                    remaing1.Visible = true;
                    remaing2.Visible = true;
                    gvmodelsnames.DataSource = dsnew;
                    gvmodelsnames.DataBind();

                }

            }


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

    protected void btntab1next_Click(object sender, EventArgs e)
    {
        BindAvailablePlots();
    }

    protected void ddlavailableplots_SelectedIndexChanged(object sender, EventArgs e)
    {

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


                //DataTable dts = (DataTable)Session["CertificateDirTb1"];
                //AddDataToTableCeertificateDir(ddlProp_intDistrictid.SelectedItem.Text, ddlIndustrialParkName.SelectedItem.Text, ddlavailableplots.SelectedItem.Text,
                //    tdAreasqrmtrs.InnerText, tdrssqmtrs.InnerText, dts);

                //Session["CertificateDirTb1"] = dts;
                //bindfeegrid(dts);
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }

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


        //grdDetails.DataSource = null;

        //string newurl = "frmtsiicplotallotment.aspx?ApId=" + Session["Applicationid"];
        //Response.Redirect(newurl);


    }

    public class approvallist
    {
        public string DepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string RequiredFlag
        {
            get;
            set;
        }
    }
    public List<approvallist> GetApprovalList()
    {
        List<approvallist> lstEmp = new List<approvallist>();

        approvallist objapprovallist = new approvallist();

        objapprovallist.DepartmentID = "23";

        objapprovallist.DepartmentName = "DEVESH OMAR";

        lstEmp.Add(objapprovallist);
        return lstEmp;

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPulgandplayDetails.aspx");
    }

    private DataSet GETPLUGANDPLAYDETAILS (string distid, string ipid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            
            da = new SqlDataAdapter("USP_GET_PLUGANDPLAYDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (distid !="" && ipid != null)
            {
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = distid.ToString();
            }
            else
            {                
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            }
            if (ipid !="" && ipid != null)
            {
                da.SelectCommand.Parameters.Add("@IPID", SqlDbType.VarChar).Value = ipid.ToString();
            }
            else
            {                
                da.SelectCommand.Parameters.Add("@IPID", SqlDbType.VarChar).Value = "%";
            }
            da.Fill(ds);
            return ds;
            



        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}

