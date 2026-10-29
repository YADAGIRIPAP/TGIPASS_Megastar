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
using System.Globalization;
using System.Net;
using System.Text;

public partial class UI_TSiPASS_frmSupportToWeakerSection : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    DataTable myDtNewRecdr = new DataTable();
    General gen = new General();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDistricts();
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddldistrict.Enabled = false;
            }
            Getlist_Click(sender, e);
        }
    }
    protected void Getlist_Click(object sender, EventArgs e)
    {
        try
        {


            int valid = 0;

            if (valid == 0)
            {
                SqlParameter[] pp = new SqlParameter[]
                     {
                    new SqlParameter("@CREATED_BY", SqlDbType.VarChar),
                    new SqlParameter("@DISTRICT", SqlDbType.VarChar)

                     };

                pp[0].Value = Session["uid"].ToString();
                pp[1].Value = ddldistrict.SelectedValue;
                DataSet ds2 = new DataSet();
                ds2 = gen.GenericFillDs("SP_GET_INDUSTRIALESTATEDETAILS", pp);
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    //rbtcellatdistrictlevel.SelectedValue = "YES";
                    //rbtcellatdistrictlevel_SelectedIndexChanged(sender, e);
                    //rbtcellatdistrictlevel.Enabled = false;
                    grdDetails.Visible = true;
                    grdDetails.DataSource = ds2.Tables[0];
                    grdDetails.DataBind();
                    //trupdate.Visible = true;
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }
    }

    public void BindDistricts()
    {
        try
        {
            //DataSet dsd = new DataSet();
            //ddldistrict.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "MSME");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddldistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }

    public string MainValidationcontrols()
    {


        int slno = 1;
        string ErrorMsg = "";
       
          
            if (txtnoofiesindistrict.Text.TrimStart().TrimEnd().Trim() == "" || txtnoofiesindistrict.Text.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter No of Industrial Estates added newly to the district\\n";
                slno = slno + 1;
            }
       

        return ErrorMsg;
    }
    public string validateindustrialestatedetails()
    {
        int slno = 1;
        string ErrorMsg = "";


        if (txtindustrialestatename.Text.TrimStart().TrimEnd().Trim() == "" || txtindustrialestatename.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Industial Estate \\n";
            slno = slno + 1;
        }
        if (RBTPROMOTEDORPRIVATE.SelectedValue == null || RBTPROMOTEDORPRIVATE.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether TSIIC Promoted/Private\\n";
            slno = slno + 1;
        }
        if (txtnodalofficername.Text.TrimStart().TrimEnd().Trim() == "" || txtnodalofficername.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter nodal officer name \\n";
            slno = slno + 1;
        }
        if (txtdesignation.Text.TrimStart().TrimEnd().Trim() == "" || txtdesignation.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Designation of the nodal officer \\n";
            slno = slno + 1;
        }
        if (txtnoofplotsavailable.Text.TrimStart().TrimEnd().Trim() == "" || txtnoofplotsavailable.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots available \\n";
            slno = slno + 1;
        }
        if (txtnoofplotsalloted.Text.TrimStart().TrimEnd().Trim() == "" || txtnoofplotsalloted.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted \\n";
            slno = slno + 1;
        }

        if (txtnoofplotsvacant.Text.TrimStart().TrimEnd().Trim() == "" || txtnoofplotsvacant.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots vacant \\n";
            slno = slno + 1;
        }

        if (txtplotsnotsetupaftermandatoryperiod.Text.TrimStart().TrimEnd().Trim() == "" || txtplotsnotsetupaftermandatoryperiod.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter no of plots where units are not set up after mandatory period \\n";
            slno = slno + 1;
        }
        if (txtplotsforreallocation.Text.TrimStart().TrimEnd().Trim() == "" || txtplotsforreallocation.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter no of plots available for reallocation to weaker sections \\n";
            slno = slno + 1;
        }
        if (txtsc_mandated.Text.TrimStart().TrimEnd().Trim() == "" || txtsc_mandated.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots mandated for SC \\n";
            slno = slno + 1;
        }
        if (txtst_mandated.Text.TrimStart().TrimEnd().Trim() == "" || txtst_mandated.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots mandated for ST \\n";
            slno = slno + 1;
        }
        if (txtbc_mandated.Text.TrimStart().TrimEnd().Trim() == "" || txtbc_mandated.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots mandated for BC \\n";
            slno = slno + 1;
        }
        if (txtminority_mandated.Text.TrimStart().TrimEnd().Trim() == "" || txtminority_mandated.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots mandated for Minority \\n";
            slno = slno + 1;
        }
        if (txtwomen_mandated.Text.TrimStart().TrimEnd().Trim() == "" || txtwomen_mandated.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots mandated for Women \\n";
            slno = slno + 1;
        }

        if (txtsc_alloted.Text.TrimStart().TrimEnd().Trim() == "" || txtsc_alloted.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted for SC \\n";
            slno = slno + 1;
        }
        if (txtst_alloted.Text.TrimStart().TrimEnd().Trim() == "" || txtst_alloted.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted for ST \\n";
            slno = slno + 1;
        }
        if (txtbc_alloted.Text.TrimStart().TrimEnd().Trim() == "" || txtbc_alloted.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted for BC \\n";
            slno = slno + 1;
        }
        if (txtminority_alloted.Text.TrimStart().TrimEnd().Trim() == "" || txtminority_alloted.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted for Minority \\n";
            slno = slno + 1;
        }
        if (txtwomen_alloted.Text.TrimStart().TrimEnd().Trim() == "" || txtwomen_alloted.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted for Women \\n";
            slno = slno + 1;
        }

        if (txtsc_vacant.Text.TrimStart().TrimEnd().Trim() == "" || txtsc_vacant.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots vacant for SC \\n";
            slno = slno + 1;
        }
        if (txtst_vacant.Text.TrimStart().TrimEnd().Trim() == "" || txtst_vacant.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots alloted for ST \\n";
            slno = slno + 1;
        }
        if (txtbc_vacant.Text.TrimStart().TrimEnd().Trim() == "" || txtbc_vacant.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots vacant for BC \\n";
            slno = slno + 1;
        }
        if (txtminority_vacant.Text.TrimStart().TrimEnd().Trim() == "" || txtminority_vacant.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots vacant for Minority \\n";
            slno = slno + 1;
        }
        if (txtwomen_vacant.Text.TrimStart().TrimEnd().Trim() == "" || txtwomen_vacant.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter total no of plots vacant for Women \\n";
            slno = slno + 1;
        }
        if (txtanyotherremarks.Text.TrimStart().TrimEnd().Trim() == "" || txtanyotherremarks.Text.TrimStart().TrimEnd().Trim() == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter any other remarks \\n";
            slno = slno + 1;
        }


        return ErrorMsg;
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        string errormsg = validateindustrialestatedetails();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("district", typeof(string));
                dt.Columns.Add("nameofindestate", typeof(string));
                dt.Columns.Add("whethertsiicpromotedorprivate", typeof(string));
                dt.Columns.Add("nodalofficername", typeof(string));
                dt.Columns.Add("nodalofficerdesignation", typeof(string));
                dt.Columns.Add("totalnoofplotsavailable", typeof(string));
                dt.Columns.Add("totalnoofplotsalloted", typeof(string));
                dt.Columns.Add("totalnoofplotsvacant", typeof(string));
                dt.Columns.Add("noofplotsunitsnotsetmandatory", typeof(string));
                dt.Columns.Add("noofplotsforreallocation", typeof(string));
                dt.Columns.Add("totalplotsmandatedforsc", typeof(string));
                dt.Columns.Add("totalplotsmandatedforst", typeof(string));
                dt.Columns.Add("totalplotsmandatedforbc", typeof(string));
                dt.Columns.Add("totalplotsmandatedforminority", typeof(string));
                dt.Columns.Add("totalplotsmandatedforwomen", typeof(string));
                dt.Columns.Add("totalplotsallottedforsc", typeof(string));
                dt.Columns.Add("totalplotsallottedforst", typeof(string));
                dt.Columns.Add("totalplotsallottedforbc", typeof(string));
                dt.Columns.Add("totalplotsallottedforminority", typeof(string));
                dt.Columns.Add("totalplotsallottedforwomen", typeof(string));
                dt.Columns.Add("totalplotsvacantforsc", typeof(string));
                dt.Columns.Add("totalplotsvacantforst", typeof(string));
                dt.Columns.Add("totalplotsvacantforbc", typeof(string));
                dt.Columns.Add("totalplotsvacantforminority", typeof(string));
                dt.Columns.Add("totalplotsvacantforwomen", typeof(string));
                dt.Columns.Add("anyotherremarks", typeof(string));

                if (ViewState["INDUSTRIALESTATEDETAILS"] != null)
                {
                    if (ViewState["INDUSTRIALESTATEDETAILS"].ToString() != "0")
                    {
                        dt = (DataTable)ViewState["INDUSTRIALESTATEDETAILS"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["district"] = ddldistrict.SelectedValue;

                    dr["nameofindestate"] = txtindustrialestatename.Text;
                    dr["whethertsiicpromotedorprivate"] = RBTPROMOTEDORPRIVATE.SelectedValue;
                    dr["nodalofficername"] = txtnodalofficername.Text.ToString();
                    dr["nodalofficerdesignation"]= txtdesignation.Text.ToString();
                    dr["totalnoofplotsavailable"]= txtnoofplotsavailable.Text.ToString();
                    dr["totalnoofplotsalloted"]= txtnoofplotsalloted.Text.ToString();
                    dr["totalnoofplotsvacant"]= txtnoofplotsvacant.Text.ToString();
                    dr["noofplotsunitsnotsetmandatory"]= txtplotsnotsetupaftermandatoryperiod.Text.ToString();
                    dr["noofplotsforreallocation"]= txtplotsforreallocation.Text.ToString();
                    dr["totalplotsmandatedforsc"]= txtsc_mandated.Text.ToString();
                    dr["totalplotsmandatedforst"]= txtst_mandated.Text.ToString();
                    dr["totalplotsmandatedforbc"]= txtbc_mandated.Text.ToString();
                    dr["totalplotsmandatedforminority"]= txtminority_mandated.Text.ToString();
                    dr["totalplotsmandatedforwomen"]= txtwomen_mandated.Text.ToString();
                    dr["totalplotsallottedforsc"]= txtsc_alloted.Text.ToString();
                    dr["totalplotsallottedforst"]= txtst_alloted.Text.ToString();
                    dr["totalplotsallottedforbc"]= txtbc_alloted.Text.ToString();
                    dr["totalplotsallottedforminority"]= txtminority_alloted.Text.ToString();
                    dr["totalplotsallottedforwomen"]= txtwomen_alloted.Text.ToString();
                    dr["totalplotsvacantforsc"]= txtsc_vacant.Text.ToString();
                    dr["totalplotsvacantforst"]= txtst_vacant.Text.ToString();
                    dr["totalplotsvacantforbc"]= txtbc_vacant.Text.ToString();
                    dr["totalplotsvacantforminority"]= txtminority_vacant.Text.ToString();
                    dr["totalplotsvacantforwomen"]= txtwomen_vacant.Text.ToString();
                    dr["anyotherremarks"]= txtanyotherremarks.Text.ToString();


                    dt.Rows.Add(dr);
                    gridindustrialestates.DataSource = dt;
                    gridindustrialestates.DataBind();
                    ViewState["INDUSTRIALESTATEDETAILS"] = dt;
                    ClearManufactureGridData();
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["district"] = ddldistrict.SelectedValue;

                    dr["nameofindestate"] = txtindustrialestatename.Text;
                    dr["whethertsiicpromotedorprivate"] = RBTPROMOTEDORPRIVATE.SelectedValue;
                    dr["nodalofficername"] = txtnodalofficername.Text.ToString();
                    dr["nodalofficerdesignation"]= txtdesignation.Text.ToString();
                    dr["totalnoofplotsavailable"]= txtnoofplotsavailable.Text.ToString();
                    dr["totalnoofplotsalloted"]= txtnoofplotsalloted.Text.ToString();
                    dr["totalnoofplotsvacant"]= txtnoofplotsvacant.Text.ToString();
                    dr["noofplotsunitsnotsetmandatory"]= txtplotsnotsetupaftermandatoryperiod.Text.ToString();
                    dr["noofplotsforreallocation"]= txtplotsforreallocation.Text.ToString();
                    dr["totalplotsmandatedforsc"]= txtsc_mandated.Text.ToString();
                    dr["totalplotsmandatedforst"]= txtst_mandated.Text.ToString();
                    dr["totalplotsmandatedforbc"]= txtbc_mandated.Text.ToString();
                    dr["totalplotsmandatedforminority"]= txtminority_mandated.Text.ToString();
                    dr["totalplotsmandatedforwomen"]= txtwomen_mandated.Text.ToString();
                    dr["totalplotsallottedforsc"]= txtsc_alloted.Text.ToString();
                    dr["totalplotsallottedforst"]= txtst_alloted.Text.ToString();
                    dr["totalplotsallottedforbc"]= txtbc_alloted.Text.ToString();
                    dr["totalplotsallottedforminority"]= txtminority_alloted.Text.ToString();
                    dr["totalplotsallottedforwomen"]= txtwomen_alloted.Text.ToString();
                    dr["totalplotsvacantforsc"]= txtsc_vacant.Text.ToString();
                    dr["totalplotsvacantforst"]= txtst_vacant.Text.ToString();
                    dr["totalplotsvacantforbc"]= txtbc_vacant.Text.ToString();
                    dr["totalplotsvacantforminority"]= txtminority_vacant.Text.ToString();
                    dr["totalplotsvacantforwomen"]= txtwomen_vacant.Text.ToString();
                    dr["anyotherremarks"]= txtanyotherremarks.Text.ToString();

                    dt.Rows.Add(dr);
                    gridindustrialestates.DataSource = dt;
                    gridindustrialestates.DataBind();
                    ViewState["INDUSTRIALESTATEDETAILS"] = dt;
                    ClearManufactureGridData();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public void ClearManufactureGridData()
    {
       
        txtindustrialestatename.Text = string.Empty;
        RBTPROMOTEDORPRIVATE.SelectedValue= string.Empty;
        txtnodalofficername.Text= string.Empty;
        txtdesignation.Text= string.Empty;
        txtnoofplotsavailable.Text= string.Empty;
        txtnoofplotsalloted.Text= string.Empty;
        txtnoofplotsvacant.Text= string.Empty;
        txtplotsnotsetupaftermandatoryperiod.Text= string.Empty;
        txtplotsforreallocation.Text= string.Empty;
        txtsc_mandated.Text= string.Empty;
        txtst_mandated.Text= string.Empty;
        txtbc_mandated.Text= string.Empty;
        txtminority_mandated.Text= string.Empty;
        txtwomen_mandated.Text= string.Empty;
        txtsc_alloted.Text= string.Empty;
        txtst_alloted.Text= string.Empty;
        txtbc_alloted.Text= string.Empty;
        txtminority_alloted.Text= string.Empty;
        txtwomen_alloted.Text= string.Empty;
        txtsc_vacant.Text= string.Empty;
        txtst_vacant.Text= string.Empty;
        txtbc_vacant.Text= string.Empty;
        txtminority_vacant.Text= string.Empty;
        txtwomen_vacant.Text= string.Empty;
        txtanyotherremarks.Text= string.Empty;

    }

    protected void btnclear_Click(object sender, EventArgs e)
    {

    }
    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        //dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {

            string errormsg = MainValidationcontrols();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {


                if (gridindustrialestates.Rows.Count == 0)
                {
                    string message = "alert('Please Add Industrial Estate details and click on ADD NEW')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);


                    return;
                }
                else if (gridindustrialestates.Rows.Count != Convert.ToInt32(txtnoofiesindistrict.Text))
                {
                    string message = "alert(' Added count of Industrial Estate detailsshould be equals to No of Industrial Estates in district...!!')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    int x = 0;

                    x = INSERTDISTINDUSTRIALESTATES(ddldistrict.SelectedValue, txtnoofiesindistrict.Text, Session["uid"].ToString());

                    if (x != 0)
                    {

                        ViewState["INDUSTRIALESTATEID"] = x;


                        DataSet ds1 = new DataSet();
                        List<INDUSTRIALESATES> LISTINDUSTRIALESATES = new List<INDUSTRIALESATES>();
                        if (gridindustrialestates.Rows.Count != 0)
                        {
                            LISTINDUSTRIALESATES.Clear();
                            ds1.Tables.Add((DataTable)ViewState["INDUSTRIALESTATEDETAILS"]);

                            foreach (GridViewRow row in gridindustrialestates.Rows)
                            {
                                INDUSTRIALESATES objINDUSTRIALESATES = new INDUSTRIALESATES();
                                int rowIndex = row.RowIndex;

                                objINDUSTRIALESATES.INDUSTRIALESTATEID = ViewState["INDUSTRIALESTATEID"].ToString();
                                objINDUSTRIALESATES.DISTRICT = ds1.Tables[0].Rows[rowIndex]["district"].ToString();
                                objINDUSTRIALESATES.INDUSTRIALESTATENAME = ds1.Tables[0].Rows[rowIndex]["nameofindestate"].ToString();
                                objINDUSTRIALESATES.TSIICPROMOTEDORPRIVATE = ds1.Tables[0].Rows[rowIndex]["whethertsiicpromotedorprivate"].ToString();
                                objINDUSTRIALESATES.NODALOFFICERNAME = ds1.Tables[0].Rows[rowIndex]["nodalofficername"].ToString();
                                objINDUSTRIALESATES.NODALOFFICERDESIGNATION = ds1.Tables[0].Rows[rowIndex]["nodalofficerdesignation"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSAVAILABLE = ds1.Tables[0].Rows[rowIndex]["totalnoofplotsavailable"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSALLOTED = ds1.Tables[0].Rows[rowIndex]["totalnoofplotsalloted"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSVACANT = ds1.Tables[0].Rows[rowIndex]["totalnoofplotsvacant"].ToString();
                                objINDUSTRIALESATES.NOOFPLOTSWHEREUNITSNOTSETUPFORMANDATORYPERIOD = ds1.Tables[0].Rows[rowIndex]["noofplotsunitsnotsetmandatory"].ToString();
                                objINDUSTRIALESATES.NOOFPLOTSAVAILABLEFORREALLOCATION = ds1.Tables[0].Rows[rowIndex]["noofplotsforreallocation"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSMANDATEDSC = ds1.Tables[0].Rows[rowIndex]["totalplotsmandatedforsc"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSMANDATEDST = ds1.Tables[0].Rows[rowIndex]["totalplotsmandatedforst"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSMANDATEDBC = ds1.Tables[0].Rows[rowIndex]["totalplotsmandatedforbc"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSMANDATEDMINORITY = ds1.Tables[0].Rows[rowIndex]["totalplotsmandatedforminority"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSMANDATEDWOMEN = ds1.Tables[0].Rows[rowIndex]["totalplotsmandatedforwomen"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSALLOTEDSC = ds1.Tables[0].Rows[rowIndex]["totalplotsallottedforsc"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSALLOTEDST = ds1.Tables[0].Rows[rowIndex]["totalplotsallottedforst"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSALLOTEDBC = ds1.Tables[0].Rows[rowIndex]["totalplotsallottedforbc"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSALLOTEDMINORITY = ds1.Tables[0].Rows[rowIndex]["totalplotsallottedforminority"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSALLOTEDWOMEN = ds1.Tables[0].Rows[rowIndex]["totalplotsallottedforwomen"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSVACANTSC = ds1.Tables[0].Rows[rowIndex]["totalplotsvacantforsc"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSVACANTST = ds1.Tables[0].Rows[rowIndex]["totalplotsvacantforst"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSVACANTBC = ds1.Tables[0].Rows[rowIndex]["totalplotsvacantforbc"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSVACANTMINORITY = ds1.Tables[0].Rows[rowIndex]["totalplotsvacantforminority"].ToString();
                                objINDUSTRIALESATES.TOTALNOOFPLOTSVACANTWOMEN = ds1.Tables[0].Rows[rowIndex]["totalplotsvacantforwomen"].ToString();
                                objINDUSTRIALESATES.ANYOTHEREMARKS = ds1.Tables[0].Rows[rowIndex]["anyotherremarks"].ToString();
                                objINDUSTRIALESATES.CreatedBy = Session["uid"].ToString();
                                LISTINDUSTRIALESATES.Add(objINDUSTRIALESATES);



                            }
                        }

                        int Insertion = INSERTINDUSTRIALESTATEDETAILS(LISTINDUSTRIALESATES);
                        if (Insertion >= 1)
                        {
                            string message = "alert('Application Submitted Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);



                            btnsave.Enabled = false;

                        }
                        else
                        {
                            string message = "alert('Application not processed please try again!!')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            btnsave.Enabled = false;
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

    }
    public int INSERTINDUSTRIALESTATEDETAILS(List<INDUSTRIALESATES> OBJLISTINDUSTRIALESATES)
    {

        int result = 0;
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
            {
                con.Open();
                foreach (INDUSTRIALESATES OBJDISTWOMENCELL in OBJLISTINDUSTRIALESATES)
                {
                    using (SqlCommand cmdE = new SqlCommand("SP_INSERT_DIST_INDUSTRIALESTATEDETAILS", con))
                    {
                        cmdE.CommandType = CommandType.StoredProcedure;
                        cmdE.Parameters.AddWithValue("@INDUSTRIALESTATEID", OBJDISTWOMENCELL.INDUSTRIALESTATEID);
                        cmdE.Parameters.AddWithValue("@DISTRICT", OBJDISTWOMENCELL.DISTRICT);
                        cmdE.Parameters.AddWithValue("@INDUSTRIALESTATENAME", OBJDISTWOMENCELL.INDUSTRIALESTATENAME);
                        cmdE.Parameters.AddWithValue("@TSIICPROMOTEDORPRIVATE", OBJDISTWOMENCELL.TSIICPROMOTEDORPRIVATE);
                        cmdE.Parameters.AddWithValue("@NODALOFFICERNAME", OBJDISTWOMENCELL.NODALOFFICERNAME);
                        cmdE.Parameters.AddWithValue("@NODALOFFICERDESIGNATION", OBJDISTWOMENCELL.NODALOFFICERDESIGNATION);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSAVAILABLE", OBJDISTWOMENCELL.TOTALNOOFPLOTSAVAILABLE);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSALLOTED", OBJDISTWOMENCELL.TOTALNOOFPLOTSALLOTED);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSVACANT", OBJDISTWOMENCELL.TOTALNOOFPLOTSVACANT);
                        cmdE.Parameters.AddWithValue("@NOOFPLOTSWHEREUNITSNOTSETUPFORMANDATORYPERIOD", OBJDISTWOMENCELL.NOOFPLOTSWHEREUNITSNOTSETUPFORMANDATORYPERIOD);
                        cmdE.Parameters.AddWithValue("@NOOFPLOTSAVAILABLEFORREALLOCATION", OBJDISTWOMENCELL.NOOFPLOTSAVAILABLEFORREALLOCATION);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSMANDATEDSC", OBJDISTWOMENCELL.TOTALNOOFPLOTSMANDATEDSC);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSMANDATEDST", OBJDISTWOMENCELL.TOTALNOOFPLOTSMANDATEDST);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSMANDATEDBC", OBJDISTWOMENCELL.TOTALNOOFPLOTSMANDATEDBC);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSMANDATEDMINORITY", OBJDISTWOMENCELL.TOTALNOOFPLOTSMANDATEDMINORITY);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSMANDATEDWOMEN", OBJDISTWOMENCELL.TOTALNOOFPLOTSMANDATEDWOMEN);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSALLOTEDSC", OBJDISTWOMENCELL.TOTALNOOFPLOTSALLOTEDSC);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSALLOTEDST", OBJDISTWOMENCELL.TOTALNOOFPLOTSALLOTEDST);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSALLOTEDBC", OBJDISTWOMENCELL.TOTALNOOFPLOTSALLOTEDBC);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSALLOTEDMINORITY", OBJDISTWOMENCELL.TOTALNOOFPLOTSALLOTEDMINORITY);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSALLOTEDWOMEN", OBJDISTWOMENCELL.TOTALNOOFPLOTSALLOTEDWOMEN);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSVACANTSC", OBJDISTWOMENCELL.TOTALNOOFPLOTSVACANTSC);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSVACANTST", OBJDISTWOMENCELL.TOTALNOOFPLOTSVACANTST);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSVACANTBC", OBJDISTWOMENCELL.TOTALNOOFPLOTSVACANTBC);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSVACANTMINORITY", OBJDISTWOMENCELL.TOTALNOOFPLOTSVACANTMINORITY);
                        cmdE.Parameters.AddWithValue("@TOTALNOOFPLOTSVACANTWOMEN", OBJDISTWOMENCELL.TOTALNOOFPLOTSVACANTWOMEN);
                        cmdE.Parameters.AddWithValue("@ANYOTHEREMARKS", OBJDISTWOMENCELL.ANYOTHEREMARKS);
                        cmdE.Parameters.AddWithValue("@CreatedBy", OBJDISTWOMENCELL.CreatedBy);
                        result = cmdE.ExecuteNonQuery();
                    }
                }

                result = 1;

                con.Close();
            }
        }
        catch (Exception ex)
        {
            //General.LogerrorDB(ex, "DB");
            //result = "Fail";
            throw ex;
        }
        return result;
    }

    public class INDUSTRIALESATES
    {
        public string INDUSTRIALESTATEID { get; set; }
        public string DISTRICT { get; set; }
        public string INDUSTRIALESTATENAME { get; set; }
        public string TSIICPROMOTEDORPRIVATE { get; set; }
        public string NODALOFFICERNAME { get; set; }
        public string NODALOFFICERDESIGNATION { get; set; }
        public string TOTALNOOFPLOTSAVAILABLE { get; set; }
        public string TOTALNOOFPLOTSALLOTED { get; set; }
        public string TOTALNOOFPLOTSVACANT { get; set; }
        public string NOOFPLOTSWHEREUNITSNOTSETUPFORMANDATORYPERIOD { get; set; }
        public string NOOFPLOTSAVAILABLEFORREALLOCATION { get; set; }
        public string TOTALNOOFPLOTSMANDATEDSC { get; set; }
        public string TOTALNOOFPLOTSMANDATEDST { get; set; }
        public string TOTALNOOFPLOTSMANDATEDBC { get; set; }
        public string TOTALNOOFPLOTSMANDATEDMINORITY { get; set; }
        public string TOTALNOOFPLOTSMANDATEDWOMEN { get; set; }
        public string TOTALNOOFPLOTSALLOTEDSC { get; set; }
        public string TOTALNOOFPLOTSALLOTEDST { get; set; }
        public string TOTALNOOFPLOTSALLOTEDBC { get; set; }
        public string TOTALNOOFPLOTSALLOTEDMINORITY { get; set; }
        public string TOTALNOOFPLOTSALLOTEDWOMEN { get; set; }
        public string TOTALNOOFPLOTSVACANTSC { get; set; }
        public string TOTALNOOFPLOTSVACANTST { get; set; }
        public string TOTALNOOFPLOTSVACANTBC { get; set; }
        public string TOTALNOOFPLOTSVACANTMINORITY { get; set; }
        public string TOTALNOOFPLOTSVACANTWOMEN { get; set; }
        public string ANYOTHEREMARKS { get; set; }

        public string CreatedBy { get; set; }


    }

    public int INSERTDISTINDUSTRIALESTATES( string district, string noofindustrialestatesindistrict, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_INSERT_DISTRICT_INDUSTRIALESTATES";

        if (district.ToString() == "" || district.ToString() == null || district.ToString() == "--Select--" || district.ToString() == "0")
            com.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = district.Trim();

        if (noofindustrialestatesindistrict.ToString() == "" || noofindustrialestatesindistrict.ToString() == null)
            com.Parameters.Add("@NOOFINDUSTRIALESTATESINDISTRICT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NOOFINDUSTRIALESTATESINDISTRICT", SqlDbType.VarChar).Value = noofindustrialestatesindistrict.Trim();

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }



    }


    protected void BtnClear1_Click(object sender, EventArgs e)
    {

    }

    protected void gridindustrialestates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("INDUSTRIALESTATEDELETE"))
        {
            DataTable dt = (DataTable)ViewState["INDUSTRIALESTATEDETAILS"];
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowINdex = gvr.RowIndex;
            if (dt.Rows.Count >= 1)
            {
                dt.Rows[RowINdex].Delete();
                dt.AcceptChanges();
                ViewState["INDUSTRIALESTATEDETAILS"] = dt;
                gridindustrialestates.DataSource = ViewState["INDUSTRIALESTATEDETAILS"];
                gridindustrialestates.DataBind();
            }
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        Button btndelete = (Button)sender;
        GridViewRow row = (GridViewRow)btndelete.NamingContainer;


        Label INDUSTRIALESTATEID = (Label)row.FindControl("LBLINDESTID_GRID");


        TextBox remarks = (TextBox)row.FindControl("txtremarks");


        if (remarks.Text == "" || remarks.Text == null)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason to delete')", true);
            remarks.Focus();


        }
        else
        {

            int returnValue = Delete_Records(INDUSTRIALESTATEID.Text, Session["uid"].ToString(), getclientIP(), remarks.Text);
            if (returnValue > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Record Deleted Successfully');", true);
                // Getlist_Click(this, EventArgs.Empty);
                Response.Redirect("frmSupportToWeakerSection.aspx");
            }

        }
    }

    public int Delete_Records(string INDESTID_GRID, string Created_by, string IPAddress, string remarks)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[SP_DELETE_INDUSTRIALESTATEDETAILS]";

        if (INDESTID_GRID.Trim() == "" || INDESTID_GRID.Trim() == null)
            com.Parameters.Add("@INDESTID_GRID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@INDESTID_GRID", SqlDbType.VarChar).Value = INDESTID_GRID.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Created_by.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = IPAddress.Trim();





        if (remarks.Trim() == "" || remarks.Trim() == null)
            com.Parameters.Add("@DELETEREMARKS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DELETEREMARKS", SqlDbType.VarChar).Value = remarks.Trim();



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            return com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
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

    protected void gridindustrialestates_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.gridindustrialestates.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11 ||
                    i == 12 || i == 13 || i == 14 || i == 15 || i == 16
                   || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24 || i == 25 || i == 26)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Total no of Plots";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Total no of Plots Mandated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Total no of Plots Allotted";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage2);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Total no of Plots Vacant";
            tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage4.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(10, tcMergePackage4);

        }
    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11||
                    i == 12 || i == 13 || i == 14 || i == 15 || i == 16
                   || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24 || i == 25||i==26)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Total no of Plots";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Total no of Plots Mandated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Total no of Plots Allotted";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage2);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Total no of Plots Vacant";
            tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage4.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(10, tcMergePackage4);

        }
    }
}