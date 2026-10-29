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

public partial class UI_TSiPASS_frmConstofWomencell_DistrictLevel : System.Web.UI.Page
{
    DataSet ds = new DataSet();
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
                DataSet ds = new DataSet();
                ds = GETWOMENCELLDATA_DISTRICTLEVEL(Session["uid"].ToString());
                if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {

                    rbtcellatdistrictlevel.SelectedValue = "YES";
                    rbtcellatdistrictlevel.Enabled = false;
                    rbtcellatdistrictlevel_SelectedIndexChanged(sender, e);
                    trdistrict.Visible = true;
                    DayOfOperationDropDown.Visible = true;
                    ddlDayofoperation.SelectedItem.Text= ds.Tables[0].Rows[0]["DAYOFOPERATION"].ToString();
                    TimeofOperationDropdown.Visible = true;
                    ddlHours.SelectedValue = ds.Tables[0].Rows[0]["TIMEOFOPERATIONHOURS"].ToString();
                    ddlMinutes.SelectedValue = ds.Tables[0].Rows[0]["TIMEOFOPERATIONMINUTES"].ToString();
                    ddlAMPM.SelectedValue= ds.Tables[0].Rows[0]["TIME_AMORPM"].ToString();
                    trplaceofoperation.Visible = true;
                    txtplaceofperation.Text = ds.Tables[0].Rows[0]["PLACEOFOPERATION"].ToString();
                    trwomencellconstituteddate.Visible = true;
                    txtwomencellconstituteddate.Text = ds.Tables[0].Rows[0]["WOMENCELLCONSTDATE"].ToString();
                    Getlist_Click(sender, e);
                }
            }
            else
            {
                Response.Redirect("~/tsHome.aspx");
            }
  
        }
    }
    protected void Getlist_Click(object sender, EventArgs e)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_FACILITATORDETAILS_ID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Session["uid"].ToString();
            da.Fill(ds);
            con.CloseConnection();

            if (ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                trgrid.Visible = true;
                grdDetails.DataSource = ds;
                grdDetails.DataBind();
                 btnsave.Visible = true;
BtnClear1.Visible = true;


            }
            else
            {
                trgrid.Visible = false;
            }
           
        }
        catch (Exception Ex)
        { throw Ex; }
    }

    public void BindDistricts()
    {
        try
        {
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

    protected void rbtcellatdistrictlevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtcellatdistrictlevel.SelectedValue == "YES")
        {
            trdistrict.Visible = true;
            DayOfOperationDropDown.Visible = true;
            trplaceofoperation.Visible = true;
            trwomencellconstituteddate.Visible = true;
            TimeofOperationDropdown.Visible = true;
            //Getlist_Click(sender, e);
            TRNOOFMEMBERS.Visible = true;
            
            
            BtnClear1.Visible =false;
            grdDetails.Visible = true;

           
            
        }
        else
        {
            trdistrict.Visible = false;

            BtnClear1.Visible = false;
            grdDetails.Visible = false; 
            DayOfOperationDropDown.Visible = true;
            TimeofOperationDropdown.Visible = true;
            txtnoofmembersinwomencell.Text = "";
            TRNOOFMEMBERS.Visible = false;
            TR1.Visible = false;
            detailsBlock.Visible = false;
            AddNewFacilitatorBtn.ClearSelection();
        }

    }
    public DataSet GETWOMENCELLDATA_DISTRICTLEVEL(string created_by)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_DISTWOMENCELL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (created_by.ToString() != "" || created_by.ToString() != null)
            {
                da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = created_by;
                
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

    public string MainValidationcontrols()
    {


        int slno = 1;
        string ErrorMsg = "";
        if (rbtcellatdistrictlevel.SelectedValue == null || rbtcellatdistrictlevel.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether Women Cell constituted at District Level or not\\n";
            slno = slno + 1;
        }
        if (rbtcellatdistrictlevel.SelectedValue == "YES")
        {

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
                if(txtplaceofperation.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter place of operation \\n";
                    slno = slno + 1;
                }
                if (txtwomencellconstituteddate.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Women cell constituted date \\n";
                    slno = slno + 1;
                }
            }
            if(grdDetails.Rows.Count<=0)
            {
                if (txtnoofmembersinwomencell.Text.TrimStart().TrimEnd().Trim() == "" || txtnoofmembersinwomencell.Text.TrimStart().TrimEnd().Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter No of Members in the Women Cell added newly \\n";
                    slno = slno + 1;
                }
            }
        }

        return ErrorMsg;
    }
    public string ValidateLandControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (rbtcellatdistrictlevel.SelectedValue == "YES")
        {
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
        }
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

   
    protected void grdDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdDetails.EditIndex = e.NewEditIndex;
        Getlist_Click(sender, e);
    }

    protected void grdDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdDetails.EditIndex = -1;
        Getlist_Click(sender, e);
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

                if (GRDDISTRICTCELLFECILITATORS.Rows.Count == 0 && grdDetails.Rows.Count==0)
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

                    x = INSERTDISTWOMENCELL(rbtcellatdistrictlevel.SelectedValue,  ddlHours.SelectedValue , ddlMinutes.SelectedValue,
                        ddlAMPM.SelectedValue, ddlDayofoperation.SelectedItem.Text, ddldistrict.SelectedValue, 
                        txtnoofmembersinwomencell.Text, Session["uid"].ToString(),txtplaceofperation.Text,txtwomencellconstituteddate.Text);

                    if (x != 0)
                    {

                        ViewState["DISTCELLID"] = x;


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

                                objDISTWOMENSCELL.DISTCELLID = ViewState["DISTCELLID"].ToString();
                                objDISTWOMENSCELL.FECILITATORNAME = ds1.Tables[0].Rows[rowIndex]["nameoffacilitator"].ToString();
                                objDISTWOMENSCELL.DESIGNATION = ds1.Tables[0].Rows[rowIndex]["designation"].ToString();
                                objDISTWOMENSCELL.CONTACTNO = ds1.Tables[0].Rows[rowIndex]["contactno"].ToString();
                                objDISTWOMENSCELL.EMAILID = ds1.Tables[0].Rows[rowIndex]["emailid"].ToString();
                                objDISTWOMENSCELL.CreatedBy = Session["uid"].ToString();
                                LISTDISTWOMENSCELL.Add(objDISTWOMENSCELL);
                            }
                        }

                        int Insertion = insertFECILITATORSetailsDB(LISTDISTWOMENSCELL);
                        if (Insertion >= 1)
                        {
                            string message = "alert('Application Submitted Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                            Getlist_Click(sender, e);
BtnClear1.Visible=true;
                            btnsave.Enabled = false;
                             TRSUBGRID.Visible = false;
                            detailsBlock.Visible = false;
                            txtnoofmembersinwomencell.Text = "";
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
    public int insertFECILITATORSetailsDB(List<DISTWOMENSCELL> OBJLISTDISTWOMENSCELL)
    {

        int result = 0;
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
            {
                con.Open();
                foreach (DISTWOMENSCELL OBJDISTWOMENCELL in OBJLISTDISTWOMENSCELL)
                {
                    using (SqlCommand cmdE = new SqlCommand("SP_INSER_FACILITATORDETAILS", con))
                    {
                        cmdE.CommandType = CommandType.StoredProcedure;
                        cmdE.Parameters.AddWithValue("@DISTCELLID", OBJDISTWOMENCELL.DISTCELLID);
                      
                        cmdE.Parameters.AddWithValue("@FECILITATORNAME", OBJDISTWOMENCELL.FECILITATORNAME);
                        cmdE.Parameters.AddWithValue("@DESIGNATION", OBJDISTWOMENCELL.DESIGNATION);
                        cmdE.Parameters.AddWithValue("@CONTACTNO", OBJDISTWOMENCELL.CONTACTNO);
                        cmdE.Parameters.AddWithValue("@EMAILID", OBJDISTWOMENCELL.EMAILID);
                        cmdE.Parameters.AddWithValue("@CreatedBy", OBJDISTWOMENCELL.CreatedBy);
                        cmdE.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = ddldistrict.SelectedValue;
                        result = cmdE.ExecuteNonQuery();
                    }
                }

                result = 1;

                con.Close();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return result;
    }

    public class DISTWOMENSCELL
    {
        public String DISTCELLID { get; set; }
        public String FECILITATORNAME { get; set; }
        public String DESIGNATION { get; set; }
        public string CONTACTNO { get; set; }
        public string EMAILID { get; set; }
        public string CreatedBy { get; set; }


    }

    public int INSERTDISTWOMENCELL(string weatherdistin, string TIMEOFOPERATIONHOURS, string TIMEOFOPERATIONMINUTES, string ampm, string day, string district, string noofmembersinwomencell, string Created_by, string PLACEOFOPERATION,string womencellconstituteddate)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_INSERT_DISTRICT_WOMEN_CELL";


        if (weatherdistin == "" || weatherdistin == null)
            com.Parameters.Add("@RBTWOMENCELLYESORNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RBTWOMENCELLYESORNO", SqlDbType.VarChar).Value = weatherdistin.Trim();

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

        if (PLACEOFOPERATION == "" || PLACEOFOPERATION == null)
            com.Parameters.Add("@PLACEOFOPERATION", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PLACEOFOPERATION", SqlDbType.VarChar).Value = PLACEOFOPERATION.Trim();

        if (district.ToString() == "" || district.ToString() == null || district.ToString() == "--Select--" || district.ToString() == "0")
            com.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = district.Trim();

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
        Response.Redirect("~/UI/TSIPASS/frmConstofWomencell_DistrictLevel.aspx");
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Record Deleted Successfully');", true);
                Getlist_Click(this, EventArgs.Empty);
            }

        }
    }

    public int Delete_Records(string FACILITATORID, string Created_by, string IPAddress, string remarks)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[SP_DELETE_FACILITATORRECORDS]";

        if (FACILITATORID.Trim() == "" || FACILITATORID.Trim() == null)
            com.Parameters.Add("@ID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ID", SqlDbType.VarChar).Value = FACILITATORID.Trim();

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



    protected void btnenter_Click(object sender, EventArgs e)
    {
        txtnoofmembersinwomencell_TextChanged(sender, e);
    }

    protected void txtnoofmembersinwomencell_TextChanged(object sender, EventArgs e)
    {
        if (txtnoofmembersinwomencell.Text != null)
        {
            detailsBlock.Visible = true;
            btnsave.Visible = true;
            //BtnClear1.Visible = true;
        }
        else
        {
            detailsBlock.Visible = false;

            btnsave.Visible = false;
        }
    }
}