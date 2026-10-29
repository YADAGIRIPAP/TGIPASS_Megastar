using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_SewerageConnection : System.Web.UI.Page
{

    // General Gen = new General();
    string ErrorMsg, Result;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Binddata();
        }
    }
    public void Binddata()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = GetSewerageConnection(Session["uid"].ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdfSWGQID.Value = Convert.ToString(ds.Tables[0].Rows[0]["SCD_QDID"]);
                txtPTINno.Text = ds.Tables[0].Rows[0]["SCD_PTINNO"].ToString();
                txtPTINno_TextChanged(txtPTINno, EventArgs.Empty);

                if (Dist.Visible == true)
                {
                    if (Dist1.Visible == true)
                    {
                        txtPtinDistrict.Text = ds.Tables[0].Rows[0]["SCD_DISTRICT"].ToString();
                    }
                    else { Dist1.Visible = false; }
                }
                else { Dist.Visible = false; }

                if (Muncipal.Visible == true)
                {
                    if (Muncipal1.Visible == true)
                    {
                        txtPtinMuncipality.Text = ds.Tables[0].Rows[0]["SCD_MUNICIPALITY"].ToString();
                    }
                    else { Muncipal1.Visible = false; }
                }
                else { Muncipal.Visible = false; }

                if (PTIN.Visible == true)
                {
                    txtPTINName.Text = ds.Tables[0].Rows[0]["SCD_PTINNAME"].ToString();
                    txtPtinCategory.Text = ds.Tables[0].Rows[0]["SCD_PTINCATEGORY"].ToString();
                    txtPtinMobileno.Text = ds.Tables[0].Rows[0]["SCD_PTINMOBILENO"].ToString();
                }
                else { PTIN.Visible = false; }

                if (CAN.Visible == true)
                {
                    if (CAN1.Visible == true)
                    {
                        txtCANNO.Text = ds.Tables[0].Rows[0]["SCD_CANWATER"].ToString();
                        txtCANNO_TextChanged(txtCANNO, EventArgs.Empty);
                    }
                    else { CAN1.Visible = false; }
                }
                else { CAN.Visible = false; }

                if (Category2.Visible == true)
                {
                    if (Category3.Visible == true)
                    {
                        txtCanName.Text = ds.Tables[0].Rows[0]["SCD_PTINOWNERNAME"].ToString();
                    }
                    else { Category3.Visible = false; }
                }
                else { Category2.Visible = false; }
                if (Mobile2.Visible == true)
                {
                    if (Mobile3.Visible == true)
                    {
                        txtCanCategory.Text = ds.Tables[0].Rows[0]["SCD_PTINCANCATEGORY"].ToString();
                    }
                    else { Mobile3.Visible = false; }
                }
                else { Mobile2.Visible = false; }

                if (NOMObile.Visible == true)
                {
                    txtCanMobileNo.Text = ds.Tables[0].Rows[0]["SCD_PTINCANMOBILENO"].ToString();
                }
                else { NOMObile.Visible = false; }

                if (States.Visible == true)
                {
                    txtCanstate.Text = ds.Tables[0].Rows[0]["SCD_STATE"].ToString();
                    txtCanDistrict.Text = ds.Tables[0].Rows[0]["SCD_DISTRICTS"].ToString();
                    txtCanMandal.Text = ds.Tables[0].Rows[0]["SCD_MANDAL"].ToString();
                }
                else { States.Visible = false; }

                if (Post.Visible == true)
                {
                    txtCanVillage.Text = ds.Tables[0].Rows[0]["SCD_VILLAGE"].ToString();
                    txtCanLocality.Text = ds.Tables[0].Rows[0]["SCD_LOCALITY"].ToString();
                    txtCanStreet.Text = ds.Tables[0].Rows[0]["SCD_STREET"].ToString();
                }
                else { Post.Visible = false; }

                if (Address.Visible == true)
                {
                    txtCanAddress.Text = ds.Tables[0].Rows[0]["SCD_LANDMARK"].ToString();
                    txtCanHNO.Text = ds.Tables[0].Rows[0]["SCD_H_NO"].ToString();
                    txtCanLandmark.Text = ds.Tables[0].Rows[0]["SCD_ADDRESS_CORRESPONDED"].ToString();
                }
                else { Address.Visible = false; }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetSewerageConnection(string userid)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("USP_GETSEWERAGECONNECTIONDETAILS", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Transaction = transaction;

                    da.SelectCommand.Parameters.AddWithValue("@SCD_CREATEDBY", userid);

                    da.Fill(ds);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        return ds;
    }
    protected void txtPTINno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string ptinNo = txtPTINno.Text.Trim();
            if (!string.IsNullOrEmpty(ptinNo))
            {
                string apiUrl = "https://uatcdmacore22.cgg.gov.in/iccc_web_api/PT/" + ptinNo;
                JObject response = GetApiResponse(apiUrl);
                if (response != null && response["status"] != null && response["status"].ToString() == "200")
                {
                    JObject payload = (JObject)response["payload"];
                    if (payload != null)
                    {
                        BindPtinPropertyDetails(payload);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(txtPTINno.Text))
            {
                Dist.Visible = true;
                Dist1.Visible = true;
                Muncipal.Visible = true;
                Muncipal1.Visible = true;
                PTIN.Visible = true;
                CAN.Visible = true;
                CAN1.Visible = true;
            }
            else
            {
                Dist.Visible = false;
                Dist1.Visible = false;
                Muncipal.Visible = false;
                Muncipal1.Visible = false;
                PTIN.Visible = false;
                CAN.Visible = false;
                CAN1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void BindPtinPropertyDetails(JObject data)
    {
        txtPTINName.Text = data["OWNER_NAME"] != null ? data["OWNER_NAME"].ToString() : "";
        txtPtinDistrict.Text = data["DISTRICT"] != null ? data["DISTRICT"].ToString() : "";
        txtPtinMuncipality.Text = data["MANDAL"] != null ? data["MANDAL"].ToString() : "";
        txtPtinCategory.Text = data["PROPERTY_TYPE"] != null ? data["PROPERTY_TYPE"].ToString() : "";
        txtPtinMobileno.Text = data["MOBILE_NO"] != null ? data["MOBILE_NO"].ToString() : "";

    }

    protected void txtCANNO_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(txtCANNO.Text))
            {
                Category2.Visible = true;
                Category3.Visible = true;
                Mobile2.Visible = true;
                Mobile3.Visible = true;
                NOMObile.Visible = true;
                States.Visible = true;
                Post.Visible = true;
                Address.Visible = true;
            }
            else
            {
                Category2.Visible = false;
                Category3.Visible = false;
                Mobile2.Visible = false;
                Mobile3.Visible = false;
                NOMObile.Visible = false;
                States.Visible = false;
                Post.Visible = false;
                Address.Visible = false;
            }
            string canNo = txtCANNO.Text.Trim();
            if (!string.IsNullOrEmpty(canNo))
            {
                string apiUrl = "https://uatcdmacore22.cgg.gov.in/iccc_web_api/WT/" + canNo;
                JObject response = GetApiResponse(apiUrl);
                if (response != null && response["status"] != null && response["status"].ToString() == "200")
                {
                    JObject payload = (JObject)response["payload"];
                    if (payload != null)
                    {
                        BindCanPropertyDetails(payload);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void BindCanPropertyDetails(JObject data)
    {
        txtCanName.Text = data["OWNER_NAME"] != null ? data["OWNER_NAME"].ToString() : "";
        txtCanCategory.Text = data["PROPERTY_TYPE"] != null ? data["PROPERTY_TYPE"].ToString() : "";
        txtCanMobileNo.Text = data["MOBILE_NO"] != null ? data["MOBILE_NO"].ToString() : "";
        txtCanstate.Text = data["STATE"] != null ? data["STATE"].ToString() : "";
        txtCanDistrict.Text = data["DISTRICT"] != null ? data["DISTRICT"].ToString() : "";
        txtCanMandal.Text = data["MANDAL"] != null ? data["MANDAL"].ToString() : "";
        txtCanVillage.Text = data["VILLAGE"] != null ? data["VILLAGE"].ToString() : "";
        txtCanLocality.Text = data["LOCALITY"] != null ? data["LOCALITY"].ToString() : "";
        txtCanStreet.Text = data["STREET"] != null ? data["STREET"].ToString() : "";
        txtCanAddress.Text = data["LANDMARK"] != null ? data["LANDMARK"].ToString() : "";
        txtCanHNO.Text = data["DOOR_NO"] != null ? data["DOOR_NO"].ToString() : "";
        txtCanLandmark.Text = data["LANDMARK"] != null ? data["LANDMARK"].ToString() : "";
    }

    public JObject GetApiResponse(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    return JObject.Parse(result);
                }
            }
        }
        catch (Exception ex)
        {
            // Optional: Log or handle error
            return null;
        }
    }

    //private void BindPropertyDetails(JObject data)
    //{
    //    txtPtinDistrict.Text = data["DISTRICT"] != null ? data["DISTRICT"].ToString() : "";
    //    txtPtinMuncipality.Text = data["MANDAL"] != null ? data["MANDAL"].ToString() : "";
    //    txtPTINName.Text = data["OWNER_NAME"] != null ? data["OWNER_NAME"].ToString() : "";
    //    txtPtinCategory.Text = data["PROPERTY_TYPE"] != null ? data["PROPERTY_TYPE"].ToString() : "";
    //    txtPtinMobileno.Text = data["MOBILE_NO"] != null ? data["MOBILE_NO"].ToString() : "";
    //    txtCanHNO.Text = data["DOOR_NO"] != null ? data["DOOR_NO"].ToString() : "";
    //    txtCanLocality.Text = data["LOCALITY"] != null ? data["LOCALITY"].ToString() : "";
    //    txtCanVillage.Text = data["VILLAGE"] != null ? data["VILLAGE"].ToString() : "";
    //    txtCanStreet.Text = data["STREET"] != null ? data["STREET"].ToString() : "";
    //    txtCanLandmark.Text = data["LANDMARK"] != null ? data["LANDMARK"].ToString() : "";
    //    txtCanstate.Text = data["STATE"] != null ? data["STATE"].ToString() : "";
    //    txtCanDistrict.Text = data["DISTRICT"] != null ? data["DISTRICT"].ToString() : "";
    //    txtCanMandal.Text = data["MANDAL"] != null ? data["MANDAL"].ToString() : "";
    //}



    public class SwerageConn
    {
        public string Questionnariid { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        public string PTINNo { get; set; }
        public string PTINName { get; set; }
        public string Category { get; set; }
        public string Mobile { get; set; }
        public string CANno { get; set; }
        public string PTINOwnwer { get; set; }
        public string CategoryPTIN { get; set; }
        public string MobilePTIN { get; set; }
        public string State { get; set; }
        public string District1 { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string HNo { get; set; }
        public string Landmark { get; set; }
        public string ModifiedBy { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ErrorMsg = validations();
            if (ErrorMsg == "")
            {
                Result=SwerageConnection();
                if (Result != "")
                {
                    hdfSWGQID.Value = Result;
                    success.Visible = true;
                    lblmsg.Text = "Sewerage Connection Details Submitted Successfully";
                    string message = "alert('" + lblmsg.Text + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            else
            {
                string message = "alert('" + ErrorMsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string SwerageConnection()
    {

        SwerageConn Swerage = new SwerageConn();

        if (hdfSWGQID.Value != "")
            Swerage.Questionnariid = hdfSWGQID.Value; //Session["Applid"].ToString();
        Swerage.District = txtPtinDistrict.Text;
        Swerage.Municipality = txtPtinMuncipality.Text;
        Swerage.PTINNo = txtPTINno.Text;
        Swerage.PTINName = txtPTINName.Text;
        Swerage.Category = txtPtinCategory.Text;
        Swerage.Mobile = txtPtinMobileno.Text;
        Swerage.CANno = txtCANNO.Text;
        Swerage.PTINOwnwer = txtCanName.Text;
        Swerage.CategoryPTIN = txtCanCategory.Text;
        Swerage.MobilePTIN = txtCanMobileNo.Text;
        Swerage.State = txtCanstate.Text;
        Swerage.District1 = txtCanDistrict.Text;
        Swerage.Mandal = txtCanMandal.Text;
        Swerage.Village = txtCanVillage.Text;
        Swerage.Locality = txtCanLocality.Text;
        Swerage.Street = txtCanStreet.Text;
        Swerage.Address = txtCanAddress.Text;
        Swerage.HNo = txtCanHNO.Text;
        Swerage.Landmark = txtCanLandmark.Text;
        Swerage.Createdby = Session["uid"].ToString();
        Swerage.IPAddress = getclientIP();
        string Result = "";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INSSEWERAGECONNECTIONDETAILS";
            com.Transaction = transaction;
            com.Connection = connection;

            if (Swerage.Questionnariid != null)
                com.Parameters.AddWithValue("@SCD_QID", Convert.ToInt32(Swerage.Questionnariid));
            else
                com.Parameters.AddWithValue("@SCD_QID", null);

            if (Swerage.Createdby != null)
                com.Parameters.AddWithValue("@SCD_CREATEDBY", Swerage.Createdby);
            else
                com.Parameters.AddWithValue("@SCD_CREATEDBY", null);

            com.Parameters.AddWithValue("@SCD_DISTRICT", Swerage.District);
            com.Parameters.AddWithValue("@SCD_MUNICIPALITY", Swerage.Municipality);
            com.Parameters.AddWithValue("@SCD_PTINNO", Swerage.PTINNo);
            com.Parameters.AddWithValue("@SCD_PTINNAME", Swerage.PTINName);
            com.Parameters.AddWithValue("@SCD_PTINCATEGORY", Swerage.Category);
            com.Parameters.AddWithValue("@SCD_PTINMOBILENO", Convert.ToInt64(Swerage.Mobile));
            com.Parameters.AddWithValue("@SCD_CANWATER", Swerage.CANno);
            com.Parameters.AddWithValue("@SCD_PTINOWNERNAME", Swerage.PTINOwnwer);
            com.Parameters.AddWithValue("@SCD_PTINCANCATEGORY", Swerage.CategoryPTIN);
            com.Parameters.AddWithValue("@SCD_PTINCANMOBILENO", Convert.ToInt64(Swerage.MobilePTIN));
            com.Parameters.AddWithValue("@SCD_STATE", Swerage.State);
            com.Parameters.AddWithValue("@SCD_DISTRICTS", Swerage.District1);
            com.Parameters.AddWithValue("@SCD_MANDAL", Swerage.Mandal);
            com.Parameters.AddWithValue("@SCD_VILLAGE", Swerage.Village);
            com.Parameters.AddWithValue("@SCD_LOCALITY", Swerage.Locality);
            com.Parameters.AddWithValue("@SCD_STREET", Swerage.Street);
            com.Parameters.AddWithValue("@SCD_ADDRESS_CORRESPONDED", Swerage.Address);
            com.Parameters.AddWithValue("@SCD_H_NO", Swerage.HNo);
            com.Parameters.AddWithValue("@SCD_LANDMARK", Swerage.Landmark);
            com.Parameters.AddWithValue("@SCD_CREATEDBYIP", Swerage.IPAddress);

            com.Parameters.Add("@RESULT", SqlDbType.VarChar, 500);
            com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            Result = com.Parameters["@RESULT"].Value.ToString();

            transaction.Commit();
            connection.Close();

           
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return Result;
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
    public string validations()
    {
        try
        {
            int slno = 1;
            string errormsg = "";

            if (string.IsNullOrEmpty(txtPTINno.Text) || txtPTINno.Text == "" || txtPTINno.Text == null)
            {
                errormsg = errormsg + slno + ". Please Enter PTIN Number\\n";
                slno = slno + 1;
            }

            if (!string.IsNullOrEmpty(txtPTINno.Text))
            {
                if (Dist.Visible == true)
                {


                    if (string.IsNullOrEmpty(txtPtinDistrict.Text) || txtPtinDistrict.Text == "" || txtPtinDistrict.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter District\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtPtinMuncipality.Text) || txtPtinMuncipality.Text == "" || txtPtinMuncipality.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Municipality\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtPTINName.Text) || txtPTINName.Text == "" || txtPTINName.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter PTIN Name\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtPtinCategory.Text) || txtPtinCategory.Text == "" || txtPtinCategory.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Category\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtPtinMobileno.Text) || txtPtinMobileno.Text == "" || txtPtinMobileno.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Mobile Number\\n";
                        slno = slno + 1;

                    }
                }
                else { Dist.Visible = false; }
            }
            if (CAN.Visible == true)
            {
                if (string.IsNullOrEmpty(txtCANNO.Text) || txtCANNO.Text == "" || txtCANNO.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter CAN (Water) Number\\n";
                    slno = slno + 1;
                }
                if (!string.IsNullOrEmpty(txtCANNO.Text) || txtCANNO.Text == "" || txtCANNO.Text == null)
                {
                    if (Category2.Visible == true)
                    {
                        if (string.IsNullOrEmpty(txtCanName.Text) || txtCanName.Text == "" || txtCanName.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter PTIN Owner Name\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanName.Text) || txtCanName.Text == "" || txtCanName.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter PTIN Owner Name\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanCategory.Text) || txtCanCategory.Text == "" || txtCanCategory.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Category\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanMobileNo.Text) || txtCanMobileNo.Text == "" || txtCanMobileNo.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Mobile Number\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanstate.Text) || txtCanstate.Text == "" || txtCanstate.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter State\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanDistrict.Text) || txtCanDistrict.Text == "" || txtCanDistrict.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter District\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanMandal.Text) || txtCanMandal.Text == "" || txtCanMandal.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Mandal\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanVillage.Text) || txtCanVillage.Text == "" || txtCanVillage.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Village/Post\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanLocality.Text) || txtCanLocality.Text == "" || txtCanLocality.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Locality\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanStreet.Text) || txtCanStreet.Text == "" || txtCanStreet.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Street/Ropad\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanAddress.Text) || txtCanAddress.Text == "" || txtCanAddress.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Address for Correspondence\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanHNO.Text) || txtCanHNO.Text == "" || txtCanHNO.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter H.No\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtCanLandmark.Text) || txtCanLandmark.Text == "" || txtCanLandmark.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Landmark\\n";
                            slno = slno + 1;
                        }
                    }
                    else { Category2.Visible = false; }
                }
            }
            else { CAN.Visible = false; }



            return errormsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        //SwerageConnection();
        btnSubmit_Click(sender, e);
        Response.Redirect("~/UI/TSIPASS/DepartmentApprovalDetailsSWG.aspx?SWGQDId=" + hdfSWGQID.Value);

    }
}





