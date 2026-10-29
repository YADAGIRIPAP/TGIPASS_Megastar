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

public partial class UI_TSiPASS_frmConstofWomencell_MandalLevel : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    DataTable myDtNewRecdr = new DataTable();
    General gen = new General();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    string mandal;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindDistricts();
                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
                    ddldistrict_SelectedIndexChanged(sender, e);

                    ddldistrict.Enabled = false;
                   
                }
                else
                {
                    Response.Redirect("~/tsHome.aspx");
                }
                //Getlist_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            //lblmsg.Text = ex.Message;
            //lblmsg.Visible = true;
        }
    }
    public DataSet GETWOMENCELLDATA_MANDALLEVEL(string DISTRICTID,string MANDALID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_MANDALWOMENCELL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (DISTRICTID.ToString() == "" || DISTRICTID.ToString() == null|| DISTRICTID== "--Select--"|| DISTRICTID=="0")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "";

            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = DISTRICTID;

            }
            if (MANDALID.ToString() == "" || MANDALID.ToString() == null|| MANDALID == "--Select--" || MANDALID == "0")
            {
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = "";

            }
            else
            {
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = MANDALID;

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

    //protected void Getlist_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        con.OpenConnection();
    //        SqlDataAdapter da = new SqlDataAdapter("SP_GET_MANDAL_FACILITATORDETAILS_ID", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = ddldistrict.SelectedValue;
    //        da.SelectCommand.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = ddlmandal.SelectedValue;
    //        da.Fill(ds);
    //        con.CloseConnection();
    //        grdDetails.DataSource = ds;
    //        grdDetails.DataBind();
    //    }
    //    catch (Exception Ex)
    //    { throw Ex; }
    //    //try
    //    //{
    //    //    int valid = 0;
    //    //    if (valid == 0)
    //    //    {
    //    //        SqlParameter[] pp = new SqlParameter[]
    //    //             {
    //    //            new SqlParameter("@CREATED_BY", SqlDbType.VarChar)

    //    //             };

    //    //        pp[0].Value = Session["uid"].ToString();
    //    //        DataSet ds2 = new DataSet();
    //    //        ds2 = gen.GenericFillDs("SP_GET_MANDAL_FACILITATORDETAILS_ID", pp);
    //    //        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
    //    //        {
    //    //            grdDetails.Visible = true;
    //    //            grdDetails.DataSource = ds2.Tables[0];
    //    //            grdDetails.DataBind();
    //    //        }
    //    //    }
    //    //    else
    //    //    {

    //    //    }
    //    //}
    //    //catch (Exception ex)
    //    //{

    //    //}
    //}
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
        //if (RBTMANDALLEVEL.SelectedValue == null || RBTMANDALLEVEL.SelectedValue == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Whether Women Cell constituted at Mandal Level or not\\n";
        //    slno = slno + 1;
        //}
        //if (RBTMANDALLEVEL.SelectedValue == "YES")
        //{
        if (grdDetails.Rows.Count > 0)
        {

        }
        else
        {
            if (ddlDayofoperation.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Day of Operation \\n";
                slno = slno + 1;
            }
            if (ddlHours.SelectedValue == "0" && ddlMinutes.SelectedValue == "-1")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Time of Operation \\n";
                slno = slno + 1;
            }
            if (ddlAMPM.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select AM/PM \\n";
                slno = slno + 1;
            }
            if (txtplaceofperation.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Place of Operation \\n";
                slno = slno + 1;
            }
        }
        //if ((ddlmandal.SelectedValue == "--Select--" || ddlmandal.SelectedValue == "0" )&&(ddlyettoconstituewomencellmandals.SelectedValue != "--Select--" || ddlyettoconstituewomencellmandals.SelectedValue != "0"))
        //{
        //    if()
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Mandal for which mandal you want to add facilitator details \\n";
        //    slno = slno + 1;
        //}
        if (grdDetails.Rows.Count <= 0)
        {
            if (txtnoofmembersinwomencell.Text.TrimStart().TrimEnd().Trim() == "" || txtnoofmembersinwomencell.Text.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter No of Members in the Women Cell added newly \\n";
                slno = slno + 1;
            }
        }
        if (txtplaceofperation.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Place of Operation \\n";
            slno = slno + 1;
        }
        if (txtwomencellconstituteddate.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Women cell constituted date \\n";
            slno = slno + 1;
        }
        // }

        return ErrorMsg;
    }
    public string ValidateLandControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        //if (RBTMANDALLEVEL.SelectedValue == "YES")
        //{
            if (txtnameoffacilitator.Text.TrimStart().TrimEnd().Trim() == "" || txtnameoffacilitator.Text.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Facilitator \\n";
                slno = slno + 1;
            }
            if (txtdesignation.Text.TrimStart().TrimEnd().Trim() == "" || txtdesignation.Text.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Designation of the Facilitator \\n";
                slno = slno + 1;
            }
            if (txtcontactno.Text.TrimStart().TrimEnd().Trim() == "" || txtcontactno.Text.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Contact Number of the Facilitator \\n";
                slno = slno + 1;
            }
            if (txtemailid.Text.TrimStart().TrimEnd().Trim() == "" || txtemailid.Text.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Mail Id of the Facilitator \\n";
                slno = slno + 1;
            }
        //}
        return ErrorMsg;
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateLandControls();
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

                dt.Columns.Add("nameoffacilitator", typeof(string));
                dt.Columns.Add("designation", typeof(string));
                dt.Columns.Add("contactno", typeof(string));
                dt.Columns.Add("emailid", typeof(string));
                dt.Columns.Add("district", typeof(string));
                dt.Columns.Add("mandal", typeof(string));

                if (ViewState["FACILITATORCURRENTTABLE"] != null)
                {
                    if (ViewState["FACILITATORCURRENTTABLE"].ToString() != "0")
                    {
                        dt = (DataTable)ViewState["FACILITATORCURRENTTABLE"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["nameoffacilitator"] = txtnameoffacilitator.Text;
                    dr["designation"] = txtdesignation.Text;
                    dr["contactno"] = txtcontactno.Text.ToString();
                    dr["emailid"] = txtemailid.Text;
                    dr["district"] = ddldistrict.SelectedItem.Text;
                    //dr["mandal"] = ddlmandal.SelectedItem.Text;


                    dt.Rows.Add(dr);
                    GRDDISTRICTCELLFECILITATORS.DataSource = dt;
                    GRDDISTRICTCELLFECILITATORS.DataBind();
                    ViewState["FACILITATORCURRENTTABLE"] = dt;
                    ClearManufactureGridData();
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["nameoffacilitator"] = txtnameoffacilitator.Text;
                    dr["designation"] = txtdesignation.Text;
                    dr["contactno"] = txtcontactno.Text.ToString();
                    dr["emailid"] = txtemailid.Text;
                    dr["district"] = ddldistrict.SelectedItem.Text;
                    //dr["mandal"] = ddlmandal.SelectedItem.Text;
                    dt.Rows.Add(dr);
                    GRDDISTRICTCELLFECILITATORS.DataSource = dt;
                    GRDDISTRICTCELLFECILITATORS.DataBind();
                    ViewState["FACILITATORCURRENTTABLE"] = dt;
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
        txtnameoffacilitator.Text = string.Empty;
        txtdesignation.Text = string.Empty;
        txtcontactno.Text = string.Empty;
        txtemailid.Text = string.Empty;

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
                if (txtnoofmembersinwomencell.Text == "")
                {
                    txtnoofmembersinwomencell.Text = "0";
                }

                if (GRDDISTRICTCELLFECILITATORS.Rows.Count == 0 && grdDetails.Rows.Count == 0)
                {
                    string message = "alert('Please Add facilitator details and click on ADD NEW')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);


                    return;
                }
                else if (GRDDISTRICTCELLFECILITATORS.Rows.Count != Convert.ToInt32(txtnoofmembersinwomencell.Text))
                {
                    string message = "alert(' Added count of members in women cell should be equals to No of Members in the Women Cell count...!!')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    int x = 0;
                    if(ddlmandal.SelectedValue!="--Select--"&& ddlmandal.SelectedValue != "0")
                    {
                        mandal = ddlmandal.SelectedValue;
                    }

                    if (ddlyettoconstituewomencellmandals.SelectedValue != "--Select--" && ddlyettoconstituewomencellmandals.SelectedValue != "0")
                    {
                        mandal = ddlyettoconstituewomencellmandals.SelectedValue;
                    }
                    x = INSERTDISTWOMENCELL("Y",  ddlHours.SelectedItem.Text , ddlMinutes.SelectedItem.Text , ddlAMPM.SelectedValue, ddlDayofoperation.SelectedItem.Text, 
                        ddldistrict.SelectedValue, txtnoofmembersinwomencell.Text, Session["uid"].ToString(), mandal,
                        txtplaceofperation.Text,txtwomencellconstituteddate.Text);

                    if (x != 0)
                    {

                        ViewState["MANDALCELLID"] = x;


                        DataSet ds1 = new DataSet();
                        List<DISTWOMENSCELL> LISTDISTWOMENSCELL = new List<DISTWOMENSCELL>();
                        if (GRDDISTRICTCELLFECILITATORS.Rows.Count != 0)
                        {
                            LISTDISTWOMENSCELL.Clear();
                            ds1.Tables.Add((DataTable)ViewState["FACILITATORCURRENTTABLE"]);

                            foreach (GridViewRow row in GRDDISTRICTCELLFECILITATORS.Rows)
                            {
                                DISTWOMENSCELL objDISTWOMENSCELL = new DISTWOMENSCELL();
                                int rowIndex = row.RowIndex;

                                objDISTWOMENSCELL.MANDALCELLID = ViewState["MANDALCELLID"].ToString();
                                objDISTWOMENSCELL.FECILITATORNAME = ds1.Tables[0].Rows[rowIndex]["nameoffacilitator"].ToString();
                                objDISTWOMENSCELL.DESIGNATION = ds1.Tables[0].Rows[rowIndex]["designation"].ToString();
                                objDISTWOMENSCELL.CONTACTNO = ds1.Tables[0].Rows[rowIndex]["contactno"].ToString();
                                objDISTWOMENSCELL.EMAILID = ds1.Tables[0].Rows[rowIndex]["emailid"].ToString();
                                objDISTWOMENSCELL.District = ds1.Tables[0].Rows[rowIndex]["district"].ToString();

                                if (ddlmandal.SelectedValue != "--Select--" && ddlmandal.SelectedValue != "0")
                                {
                                    objDISTWOMENSCELL.Mandal =  ddlmandal.SelectedValue;
                                }

                                if (ddlyettoconstituewomencellmandals.SelectedValue != "--Select--" && ddlyettoconstituewomencellmandals.SelectedValue != "0")
                                {
                                    objDISTWOMENSCELL.Mandal = ddlyettoconstituewomencellmandals.SelectedValue;
                                }


                                //objDISTWOMENSCELL.Mandal = ds1.Tables[0].Rows[rowIndex]["mandal"].ToString();


                                objDISTWOMENSCELL.CreatedBy = Session["uid"].ToString();
                                LISTDISTWOMENSCELL.Add(objDISTWOMENSCELL);



                            }
                        }

                        int Insertion = insertFACILITATORDetailsDB(LISTDISTWOMENSCELL);
                        if (Insertion >= 1)
                        {
                            success.Visible = true;
                            lblmsg.Text = "Application Submitted Successfully";
                           // string message = "alert('Application Submitted Successfully')";
                           // ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                           //btnsave.Enabled = false;
                            clearall();
                            //if (grdDetails.Rows.Count > 0)
                            //{
                            //    TRNOOFMEMBERS.Visible = false;
                            //   // DayOfOperationDropDown.Visible = true; 
                            //   // TimeofOperationDropdown.Visible = true; 
                            //    //trplaceofoperation.Visible = true;
                            //   // trwomencellconstituteddate.Visible = true;
                            //    detailsBlock.Visible = false;
                            //    //TR1.Visible = true;

                            //}
                            //else
                            //{
                            //    TRNOOFMEMBERS.Visible = true;
                            //    DayOfOperationDropDown.Visible = true;
                            //    TimeofOperationDropdown.Visible = true;
                            //    ddlDayofoperation.Enabled = true;
                            //    ddlHours.Enabled = true;
                            //    ddlMinutes.Enabled = true;
                            //    ddlAMPM.Enabled = true;
                            //    detailsBlock.Visible = true;
                            //    TR1.Visible = false;
                            //    trplaceofoperation.Visible = true;
                            //    trwomencellconstituteddate.Visible = true;
                            //    AddNewFacilitatorBtn.ClearSelection();
                            //}
                        }
                        else
                        {
                            lblmsg0.Text = "Failed to submit the application, Please try again!!";
                             //string message = "alert('Application not processed please try again!!')";
                           // ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            btnsave.Enabled = true;
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

    }
    public void clearall()
    {
        ddlmandal.ClearSelection();
        ddlmandal.Enabled = true;
        ddlyettoconstituewomencellmandals.ClearSelection();
        ddlyettoconstituewomencellmandals.Enabled = true;
        
        ddlDayofoperation.ClearSelection();


        ddlHours.ClearSelection();

       
    
        ddlMinutes.ClearSelection();
        ddlAMPM.ClearSelection();
        DayOfOperationDropDown.Visible = false;
        grdDetails.Visible = false;
        trwomencellconstituteddate.Visible = false;
        trplaceofoperation.Visible = false;
        TimeofOperationDropdown.Visible = false;
        btnsave.Visible = false;
        BtnClear1.Visible = false;
TRNOOFMEMBERS.Visible = false;
        detailsBlock.Visible = false;
        GRDDISTRICTCELLFECILITATORS.Visible = false;
    }
    public int insertFACILITATORDetailsDB(List<DISTWOMENSCELL> OBJLISTDISTWOMENSCELL)
    {

        int result = 0;
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
            {
                con.Open();
                foreach (DISTWOMENSCELL OBJDISTWOMENCELL in OBJLISTDISTWOMENSCELL)
                {
                    using (SqlCommand cmdE = new SqlCommand("SP_INSERT_FACILITATORDETAILS_MANDALCELL", con))
                    {
                        cmdE.CommandType = CommandType.StoredProcedure;
                        cmdE.Parameters.AddWithValue("@MANDALCELLID", OBJDISTWOMENCELL.MANDALCELLID);
                        cmdE.Parameters.AddWithValue("@FECILITATORNAME", OBJDISTWOMENCELL.FECILITATORNAME);
                       
                        cmdE.Parameters.AddWithValue("@DESIGNATION", OBJDISTWOMENCELL.DESIGNATION);
                        cmdE.Parameters.AddWithValue("@CONTACTNO", OBJDISTWOMENCELL.CONTACTNO);
                        cmdE.Parameters.AddWithValue("@EMAILID", OBJDISTWOMENCELL.EMAILID);
                        cmdE.Parameters.AddWithValue("@DISTRICT",ddldistrict.SelectedValue);
                        cmdE.Parameters.AddWithValue("@MANDAL", OBJDISTWOMENCELL.Mandal);
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

    //protected void Savedata()
    //{
    //    try
    //    {
    //        con.OpenConnection();
    //        SqlDataAdapter da = new SqlDataAdapter("SP_INSERT_FACILITATORDETAILS_MANDALCELL", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.SelectCommand.Parameters.Add("@MANDALCELLID", SqlDbType.VarChar).Value = ddlmandal.SelectedValue;
    //        da.SelectCommand.Parameters.Add("@DayofOperation", SqlDbType.Char).Value = ddlDayofoperation.SelectedItem.Text;
    //        da.SelectCommand.Parameters.Add("@TimeofOperation", SqlDbType.VarChar).Value = (ddlHours.SelectedItem.Text + " : " + ddlMinutes.SelectedItem.Text + " " + ddlAMPM.SelectedValue);
    //        da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = ddldistrict.SelectedItem.Text;
    //        da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = ddlmandal.SelectedItem.Text;
    //        da.SelectCommand.Parameters.Add("@FECILITATORNAME", SqlDbType.VarChar).Value = txtnameoffacilitator.Text;
    //        da.SelectCommand.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = txtdesignation.Text;
    //        da.SelectCommand.Parameters.Add("@CONTACTNO", SqlDbType.VarChar).Value = txtcontactno.Text;
    //        da.SelectCommand.Parameters.Add("@EMAILID", SqlDbType.VarChar).Value = txtemailid.Text;
    //        da.SelectCommand.ExecuteNonQuery();
    //        con.CloseConnection();
    //    }
    //    catch (Exception Ex)
    //    { throw Ex; }
    //}
    public class DISTWOMENSCELL
    {
        public String MANDALCELLID { get; set; }
        public String FECILITATORNAME { get; set; }
        public String DESIGNATION { get; set; }
        public string CONTACTNO { get; set; }
        public string EMAILID { get; set; }
        public string CreatedBy { get; set; }

        public string District { get; set; }

        public string Mandal { get; set; }
        public string Placeofoperation { get; set; }
    }
    public int INSERTDISTWOMENCELL(string whethermandalcellornot, string TIMEOFOPERATIONHOURS,
        string TIMEOFOPERATIONMINUTES, string ampm, string day, string district, 
        string noofmembersinwomencell, string Created_by, string Mandal,string placeofoperation,string womencellconstituteddate)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_INSERT_MANDAL_WOMEN_CELL";


        if (whethermandalcellornot == "" || whethermandalcellornot == null)
            com.Parameters.Add("@RBTWOMENCELLYESORNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RBTWOMENCELLYESORNO", SqlDbType.VarChar).Value = whethermandalcellornot.Trim();

        if (TIMEOFOPERATIONHOURS == "" || TIMEOFOPERATIONHOURS == null)
            com.Parameters.Add("@TIMEOFOPERATIONHOURS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TIMEOFOPERATIONHOURS", SqlDbType.VarChar).Value = TIMEOFOPERATIONHOURS.Trim();
        if (TIMEOFOPERATIONMINUTES == "" || TIMEOFOPERATIONMINUTES == null)
            com.Parameters.Add("@TIMEOFOPERATIONMINUTES", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TIMEOFOPERATIONMINUTES", SqlDbType.VarChar).Value = TIMEOFOPERATIONMINUTES.Trim();

        if (ampm.ToString() == "" || ampm.ToString() == null || ampm.ToString() == "--SELECT--" || ampm.ToString() == "0")
            com.Parameters.Add("@TIME_AMORPM", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TIME_AMORPM", SqlDbType.VarChar).Value = ampm.Trim();

        if (day == "" || day == null)
            com.Parameters.Add("@DAYOFOPERATION", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DAYOFOPERATION", SqlDbType.VarChar).Value = day.Trim();

        if (placeofoperation == "" || day == null)
            com.Parameters.Add("@PLACEOFOPERATION", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PLACEOFOPERATION", SqlDbType.VarChar).Value = placeofoperation.Trim();

        if (district.ToString() == "" || district.ToString() == null || district.ToString() == "--Select--" || district.ToString() == "0")
            com.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = district.Trim();

        if (Mandal.ToString() == "" || Mandal.ToString() == null || Mandal.ToString() == "--Select--" || Mandal.ToString() == "0")
            com.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = Mandal.Trim();

        if (noofmembersinwomencell.ToString() == "" || noofmembersinwomencell.ToString() == null)
            com.Parameters.Add("@NOOFMEMBERSINWOMENCELL", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NOOFMEMBERSINWOMENCELL", SqlDbType.VarChar).Value = noofmembersinwomencell.Trim();

        if (womencellconstituteddate.ToString() == "" || womencellconstituteddate.ToString() == null)
            com.Parameters.Add("@Womencellconstuteddate", SqlDbType.DateTime).Value = DBNull.Value;
        else
            com.Parameters.Add("@Womencellconstuteddate", SqlDbType.DateTime).Value = womencellconstituteddate.Trim();
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

    protected void GRDDISTRICTCELLFECILITATORS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("FACILITATORDELETE"))
        {
            DataTable dt = (DataTable)ViewState["FACILITATORCURRENTTABLE"];
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowINdex = gvr.RowIndex;
            if (dt.Rows.Count >= 1)
            {
                dt.Rows[RowINdex].Delete();
                dt.AcceptChanges();
                ViewState["FACILITATORCURRENTTABLE"] = dt;
                GRDDISTRICTCELLFECILITATORS.DataSource = ViewState["FACILITATORCURRENTTABLE"];
                GRDDISTRICTCELLFECILITATORS.DataBind();
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        Button btndelete = (Button)sender;
        GridViewRow row = (GridViewRow)btndelete.NamingContainer;


        Label FACILITATORID = (Label)row.FindControl("FACILITATORID");


        TextBox remarks = (TextBox)row.FindControl("txtremarks");


        if (remarks.Text == "" || remarks.Text == null)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason to delete')", true);
            remarks.Focus();


        }
        else
        {

            int returnValue = Delete_Records(FACILITATORID.Text, Session["uid"].ToString(), getclientIP(), remarks.Text);
            if (returnValue > 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Record Deleted Successfully');", true);
                //Getlist_Click(this, EventArgs.Empty);

                string message = "alert('Record Deleted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                Response.Redirect("frmConstofWomencell_MandalLevel.aspx");
            }

        }
    }
    public int Delete_Records(string FACILITATORID_MANDALCELL, string Created_by, string IPAddress, string remarks)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[SP_DELETE_FACILITATORRECORDS_MANDALCELL]";

        if (FACILITATORID_MANDALCELL.Trim() == "" || FACILITATORID_MANDALCELL.Trim() == null)
            com.Parameters.Add("@FACILITATORID_MANDALCELL", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FACILITATORID_MANDALCELL", SqlDbType.VarChar).Value = FACILITATORID_MANDALCELL.Trim();

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

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddlmandal.Items.Clear();
                ddlmandal.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlmandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = GetMandals_WOMENCELLFORMED(ddldistrict.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal.DataSource = dsm.Tables[0];
                    ddlmandal.DataValueField = "Mandal_Id";
                    ddlmandal.DataTextField = "Manda_lName";
                    ddlmandal.DataBind();
                    ddlmandal.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlmandal.Enabled = false;
                    ddlmandal.Items.Clear();
                    ddlmandal.Items.Insert(0, "--Select--");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddlyettoconstituewomencellmandals.Items.Clear();
                ddlyettoconstituewomencellmandals.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlyettoconstituewomencellmandals.Items.Clear();
                DataSet dsm1 = new DataSet();
                dsm1 = GetMandals_WOMENCELLNOTFORMED(ddldistrict.SelectedValue);
                if (dsm1.Tables[0].Rows.Count > 0)
                {
                    ddlyettoconstituewomencellmandals.DataSource = dsm1.Tables[0];
                    ddlyettoconstituewomencellmandals.DataValueField = "Mandal_Id";
                    ddlyettoconstituewomencellmandals.DataTextField = "Manda_lName";
                    ddlyettoconstituewomencellmandals.DataBind();
                    ddlyettoconstituewomencellmandals.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlyettoconstituewomencellmandals.Enabled = false;
                    ddlyettoconstituewomencellmandals.Items.Clear();
                    ddlyettoconstituewomencellmandals.Items.Insert(0, "--Select--");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }

    }
    public DataSet GetMandals_WOMENCELLFORMED(string District)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GetMandals_WOMENCELLCONSTITUTED", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (District.Trim() == "" || District.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = District.ToString();

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
    public DataSet GetMandals_WOMENCELLNOTFORMED(string District)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GetMandals_WOMENCELL_NOTCONSTITUTED", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (District.Trim() == "" || District.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = District.ToString();

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


    protected void RBTMANDALLEVEL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (RBTMANDALLEVEL.SelectedValue == "YES")
        //{
            //tdnoofmembers.Visible = true;
            //trdetails.Visible = true;
            //trfacilitatordetails.Visible = true;
            //TRTIME.Visible = true;
            //Day_TimeOfOperations.Visible = true;
            //BtnClear1.Visible = true;
            grdDetails.Visible = true;
           // Getlist_Click(sender, e);

            if (grdDetails.Rows.Count > 0)
            {
                TRNOOFMEMBERS.Visible = false;
                DayOfOperationDropDown.Visible = true; 
                TimeofOperationDropdown.Visible = true; 
                detailsBlock.Visible = false;
                TR1.Visible = true;

            }
            else
            {
                TRNOOFMEMBERS.Visible = true;
                DayOfOperationDropDown.Visible = true;
                TimeofOperationDropdown.Visible = true;
                ddlDayofoperation.Enabled = true;
                ddlHours.Enabled = true;
                ddlMinutes.Enabled = true;
                ddlAMPM.Enabled = true;
                detailsBlock.Visible = true;
                TR1.Visible = false;
                AddNewFacilitatorBtn.ClearSelection();
            }
        //}
        //else
        //{
        //    BtnClear1.Visible = false;
        //    grdDetails.Visible = false;
        //    DayOfOperationTextBox.Visible = false;
        //    TimeOfOperationsTextBox.Visible = false;
        //    txtnoofmembersinwomencell.Text = "";
        //    TRNOOFMEMBERS.Visible = false;
        //    TR1.Visible = false;
        //    detailsBlock.Visible = false;
        //    AddNewFacilitatorBtn.ClearSelection();
        //}
    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            DataSet ds = new DataSet();
            ds = GETWOMENCELLDATA_MANDALLEVEL(ddldistrict.SelectedValue, ddlmandal.SelectedValue);
            if (ds.Tables.Count == 2)
            {
                if(ds.Tables[0].Rows.Count > 0)
                { 
                ddlmandal.Enabled = false;
                ddlyettoconstituewomencellmandals.Enabled = false;
                DayOfOperationDropDown.Visible = true;
                ddlDayofoperation.SelectedItem.Text = ds.Tables[0].Rows[0]["DAYOFOPERATION"].ToString();
                TimeofOperationDropdown.Visible = true;
                ddlHours.SelectedValue = ds.Tables[0].Rows[0]["TIMEOFOPERATIONHOURS"].ToString();
                ddlMinutes.SelectedValue = ds.Tables[0].Rows[0]["TIMEOFOPERATIONMINUTES"].ToString();
                ddlAMPM.SelectedValue = ds.Tables[0].Rows[0]["TIME_AMORPM"].ToString();
                trplaceofoperation.Visible = true;
                txtplaceofperation.Text = ds.Tables[0].Rows[0]["PLACEOFOPERATION"].ToString();
                trwomencellconstituteddate.Visible = true;
                txtwomencellconstituteddate.Text = ds.Tables[0].Rows[0]["WOMENCELLCONSTDATE"].ToString();

                    TRNOOFMEMBERS.Visible = true;

            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[1];
                grdDetails.DataBind();
btnsave.Visible = true;
                    btnsave.Enabled = true;
                    BtnClear1.Visible = true;

                }
        }

        }
        catch (Exception ex)
        { }

    }


    protected void AddNewFacilitatorBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (AddNewFacilitatorBtn.SelectedValue == "0")
        {
            TRNOOFMEMBERS.Visible = true;
            detailsBlock.Visible = true;
        }
        else
        {
            TRNOOFMEMBERS.Visible = false;
            detailsBlock.Visible = false;
        }
    }



    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/frmConstofWomencell_MandalLevel.aspx");
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {

    }


   

    protected void txtnoofmembersinwomencell_TextChanged(object sender, EventArgs e)
    {
        if (txtnoofmembersinwomencell.Text != null)
        {
            btnsave.Visible = true;
            detailsBlock.Visible = true;
        }
        else
        {
            //btnsave.Visible = false;
            detailsBlock.Visible = false;
        }
    }

    protected void btnenter_Click(object sender, EventArgs e)
    {
        txtnoofmembersinwomencell_TextChanged(sender, e);
    }
    protected void ddlyettoconstituewomencellmandals_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlmandal.Enabled = false;
        ddlmandal.Enabled = false;
        ddlyettoconstituewomencellmandals.Enabled = false;
        DayOfOperationDropDown.Visible = true;
        TimeofOperationDropdown.Visible = true;
        trplaceofoperation.Visible = true;
        trwomencellconstituteddate.Visible = true;
        TRNOOFMEMBERS.Visible = true;
    }
}