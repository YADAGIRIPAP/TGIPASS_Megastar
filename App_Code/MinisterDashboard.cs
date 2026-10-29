using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Caching;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for MinisterDashboard
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class MinisterDashboard : System.Web.Services.WebService
{
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();
    public MinisterDashboard()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public string TGiPASSData(string fromdate, string todate)
    {
        string lblmsg = "";
        string FromdateforDB = "", TodateforDB = "";
        try
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(fromdate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(todate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("USP_GET_MINISTER_DASHBOARD", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromdateforDB.Trim() == "" || FromdateforDB.Trim() == null || FromdateforDB.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromdateforDB;
            }
            if (TodateforDB.Trim() == "" || TodateforDB.Trim() == null || TodateforDB.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = TodateforDB;
            }

            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    [WebMethod]
    public string TGIncentivesData(string Caste, string fromdate, string todate)
    {
        string lblmsg = "";
        string FromdateforDB = "", TodateforDB = "";
        try
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(fromdate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(todate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("USP_GET_INCENTIVES_SANCTIONED_MINISTER", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Caste.Trim() == "" || Caste.Trim() == null || Caste.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CASTE", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CASTE", SqlDbType.VarChar).Value = Caste;
            }
            if (FromdateforDB.Trim() == "" || FromdateforDB.Trim() == null || FromdateforDB.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromdateforDB;
            }
            if (TodateforDB.Trim() == "" || TodateforDB.Trim() == null || TodateforDB.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = TodateforDB;
            }

            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    [WebMethod]
    public string DepartmentWisePendency(string status, string type, string dept, string fromdate, string todate)
    {
        string lblmsg = "";
        string FromdateforDB = "", TodateforDB = "";
        try
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(fromdate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(todate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("DeptReportDepartmentWise_New1_CFE_FORAGENDA_drilldown_MinisterDashboard", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (status.Trim() == "" || status.Trim() == null || status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            }
            if (type.Trim() == "" || type.Trim() == null || type.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
            }
            if (dept.Trim() == "" || dept.Trim() == null || dept.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.AddWithValue("@dept", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
            }

            if (FromdateforDB.Trim() == "" || FromdateforDB.Trim() == null || FromdateforDB.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromdateforDB;
            }
            if (TodateforDB.Trim() == "" || TodateforDB.Trim() == null || TodateforDB.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = TodateforDB;
            }

            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public object GetCAFAccessToken(string username, string password)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        try
        {
            string cfgUser = Convert.ToString(ConfigurationManager.AppSettings["CAF_API_User"]);
            string cfgPwd = Convert.ToString(ConfigurationManager.AppSettings["CAF_API_Password"]);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)
                || username.Trim() != cfgUser || password != cfgPwd)
            {
                result["status"] = "error";
                result["message"] = "Invalid username or password";
                result["token"] = "";
                return result;
            }

            string token = Guid.NewGuid().ToString("N");
            DateTime expiresAt = DateTime.Now.AddHours(8);
            HttpRuntime.Cache.Insert("CAF_API_TOKEN_" + token, expiresAt, null, expiresAt, Cache.NoSlidingExpiration);

            result["status"] = "success";
            result["message"] = "Token generated successfully";
            result["token"] = token;
            result["expiresAt"] = expiresAt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }
        catch (Exception ex)
        {
            result["status"] = "error";
            result["message"] = ex.Message;
            result["token"] = "";
            return result;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public object GetCAFFieldsByUID(string token, string uidno, string unitname)
    {
        string uidVal = uidno == null ? "" : uidno.Trim();
        string unitVal = unitname == null ? "" : unitname.Trim();
        try
        {
            if (!IsValidCafToken(token))
            {
                return BuildCafErrorJson(uidVal, unitVal, "Invalid or expired token. Call GetCAFAccessToken first.");
            }

            if ((uidVal == "" || uidVal == "--Select--") && unitVal == "")
            {
                return BuildCafErrorJson("", "", "UID No or Unit Name is required");
            }

            con.OpenConnection();
            SqlDataAdapter daCaf = new SqlDataAdapter("USP_GET_CAF_FIELDS_BY_UID", con.GetConnection);
            daCaf.SelectCommand.CommandType = CommandType.StoredProcedure;
            daCaf.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value =
                (uidVal == "" || uidVal == "--Select--") ? (object)DBNull.Value : uidVal;
            daCaf.SelectCommand.Parameters.Add("@unitname", SqlDbType.VarChar).Value =
                unitVal == "" ? (object)DBNull.Value : unitVal;

            ds = new DataSet();
            daCaf.Fill(ds);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return BuildCafErrorJson(uidVal, unitVal, "No CAF data found for the given UID No / Unit Name");
            }

            return BuildCafJsonFromBackend(ds, uidVal);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            return BuildCafErrorJson(uidVal, unitVal, ex.Message);
        }
        finally
        {
            con.CloseConnection();
        }
    }

    private static bool IsValidCafToken(string token)
    {
        if (token == null || token.Trim() == "")
            return false;

        object cached = HttpRuntime.Cache["CAF_API_TOKEN_" + token.Trim()];
        if (cached == null)
            return false;

        DateTime expiresAt;
        if (cached is DateTime)
        {
            expiresAt = (DateTime)cached;
            return expiresAt >= DateTime.Now;
        }
        return true;
    }

    private static Dictionary<string, object> BuildCafErrorJson(string uidNo, string unitName, string message)
    {
        Dictionary<string, object> err = new Dictionary<string, object>();
        err["status"] = "error";
        err["message"] = message;
        err["uidNo"] = uidNo;
        err["unitName"] = unitName;
        err["data"] = null;
        return err;
    }

    private static string GetRowVal(DataRow r, params string[] columns)
    {
        if (r == null || r.Table == null) return "";
        for (int i = 0; i < columns.Length; i++)
        {
            string c = columns[i];
            if (r.Table.Columns.Contains(c) && r[c] != DBNull.Value)
            {
                string v = Convert.ToString(r[c]);
                if (v != null && v.Trim() != "")
                    return v.Trim();
            }
        }
        return "";
    }

    private static DataRow SafeRow(DataSet dsCaf, int tableIndex)
    {
        if (dsCaf == null || dsCaf.Tables.Count <= tableIndex || dsCaf.Tables[tableIndex].Rows.Count == 0)
            return null;
        return dsCaf.Tables[tableIndex].Rows[0];
    }

    private static string FormatDateVal(string raw)
    {
        if (raw == null || raw.Trim() == "") return "";
        DateTime dtVal;
        if (DateTime.TryParse(raw, out dtVal))
            return dtVal.ToString("dd-MM-yyyy");
        return raw.Trim();
    }

    private Dictionary<string, object> BuildCafJsonFromBackend(DataSet dsCaf, string uidNo)
    {
        // Result sets from USP_GET_CAF_FIELDS_BY_UID (PCB removed):
        // 0 Entrepreneur+Questionnaire, 1 Land, 2 Power, 3 Water,
        // 4 TSIIC Main+Fees, 5 TSIIC Plot Details, 6 TSIIC Applicant
        DataRow t0 = SafeRow(dsCaf, 0);
        DataRow t1 = SafeRow(dsCaf, 1);
        DataRow t2 = SafeRow(dsCaf, 2);
        DataRow t3 = SafeRow(dsCaf, 3);
        DataRow t4 = SafeRow(dsCaf, 4);
        DataRow t6 = SafeRow(dsCaf, 6);

        string uid = GetRowVal(t0, "UID_No");
        if (uid == "") uid = uidNo;

        string village = GetRowVal(t1, "Village_Name");
        string mandal = GetRowVal(t1, "Manda_lName");
        string district = GetRowVal(t1, "District_Name");

        string directMale = GetRowVal(t0, "DirectMale");
        string directFemale = GetRowVal(t0, "DirectFemale");
        string directTotal = "";
        int dm, df;
        if (int.TryParse(directMale, out dm) && int.TryParse(directFemale, out df))
            directTotal = Convert.ToString(dm + df);

        string indirectMale = GetRowVal(t0, "InDirectMale");
        string indirectFemale = GetRowVal(t0, "InDirectFemale");
        string indirectTotal = "";
        int im, idf;
        if (int.TryParse(indirectMale, out im) && int.TryParse(indirectFemale, out idf))
            indirectTotal = Convert.ToString(im + idf);

        List<object> plotDetailsList = new List<object>();
        if (dsCaf != null && dsCaf.Tables.Count > 5)
        {
            foreach (DataRow pr in dsCaf.Tables[5].Rows)
            {
                Dictionary<string, object> pItem = new Dictionary<string, object>();
                pItem["plotNo"] = GetRowVal(pr, "PlotNo");
                pItem["areaInSqMtrs"] = GetRowVal(pr, "Area_in_Sq_Mtrs", "Area_in_S");
                pItem["perSqmtsPrice"] = GetRowVal(pr, "Persqmtsprice");
                pItem["price"] = GetRowVal(pr, "Price");
                pItem["emd"] = GetRowVal(pr, "EMD");
                pItem["processFee"] = GetRowVal(pr, "ProcessFee", "ProcessFe");
                pItem["plotDescription"] = GetRowVal(pr, "plotdescription", "plotdescri");
                plotDetailsList.Add(pItem);
            }
        }

        string unitName = GetRowVal(t0, "UnitName", "NameofIndustrialUnder");

        Dictionary<string, object> identity = new Dictionary<string, object>();
        identity["uidNo"] = uid;
        identity["unitName"] = unitName;
        identity["nameOfIndustrialUndertaking"] = unitName;
        identity["nameOfPromoter"] = GetRowVal(t0, "NameofthePromoter");
        identity["natureOfOrganisation"] = GetRowVal(t0, "Const_of_unit");
        identity["categoryOfRegistration"] = GetRowVal(t0, "intCategoryofReg");
        identity["registrationNo"] = GetRowVal(t0, "Reg_No");
        identity["registrationDate"] = FormatDateVal(GetRowVal(t0, "Reg_Date"));
        identity["registrationExpiryDate"] = "";
        identity["categoryOfIndustry"] = GetRowVal(t1, "Categoryid");
        identity["proposalFor"] = GetRowVal(t0, "ProposalFor");

        Dictionary<string, object> location = new Dictionary<string, object>();
        location["locationOfFactory"] = GetRowVal(t1, "LocationName", "ProposedLocationdata", "District_Name");
        location["surveyNoPlotNumbers"] = GetRowVal(t1, "SurveyNo");
        location["nameOfGrampanchayat"] = GetRowVal(t1, "Name_Gramapachayat");
        location["villageTown"] = village;
        location["mandal"] = mandal;
        location["district"] = district;
        location["pinCode"] = GetRowVal(t1, "Land_Pincode");
        if (Convert.ToString(location["pinCode"]) == "")
            location["pinCode"] = GetRowVal(t0, "Pincode");
        location["emailId"] = GetRowVal(t1, "Land_Email");
        if (Convert.ToString(location["emailId"]) == "")
            location["emailId"] = GetRowVal(t0, "Email");
        location["telephone"] = GetRowVal(t1, "Land_TelephoneNumber");
        if (Convert.ToString(location["telephone"]) == "")
            location["telephone"] = GetRowVal(t0, "TelephoneNumber", "MobileNumber");
        location["totalExtentOfSiteAreaSqMts"] = GetRowVal(t1, "Land_TotExtent", "Tot_Extent");
        if (Convert.ToString(location["totalExtentOfSiteAreaSqMts"]) == "")
            location["totalExtentOfSiteAreaSqMts"] = GetRowVal(t0, "Tot_Extent");

        Dictionary<string, object> project = new Dictionary<string, object>();
        project["lineOfActivity"] = GetRowVal(t0, "LineofActivity_Name");
        project["lineOfManufacture"] = new List<object>();
        Dictionary<string, object> cost = new Dictionary<string, object>();
        cost["land"] = GetRowVal(t0, "Val_Land", "Land_Value");
        cost["building"] = GetRowVal(t0, "Val_Build", "Building_value");
        cost["plantAndMachinery"] = GetRowVal(t0, "Val_Plant", "plant_value");
        cost["total"] = GetRowVal(t0, "Tot_PrjCost", "Total_value");
        project["projectCostBreakUp"] = cost;
        Dictionary<string, object> finance = new Dictionary<string, object>();
        finance["equity"] = "";
        finance["debt"] = "";
        project["meansOfFinance"] = finance;
        Dictionary<string, object> directEmp = new Dictionary<string, object>();
        directEmp["male"] = directMale;
        directEmp["female"] = directFemale;
        directEmp["total"] = directTotal;
        project["directEmployment"] = directEmp;
        project["indirectEmployment"] = indirectTotal;

        string priceLand = GetRowVal(t4, "PriceOfTheLand", "Fees_PlotTotalamount", "PlotTotalamount");
        string emd = GetRowVal(t4, "EMD", "Fees_TotalEmd", "TotalEmd");
        string processFee = GetRowVal(t4, "ProcessFee", "Fees_ProcessFee");
        if (priceLand == "" && plotDetailsList.Count > 0)
        {
            Dictionary<string, object> firstPlot = plotDetailsList[0] as Dictionary<string, object>;
            if (firstPlot != null)
            {
                if (priceLand == "") priceLand = Convert.ToString(firstPlot["price"]);
                if (emd == "") emd = Convert.ToString(firstPlot["emd"]);
                if (processFee == "") processFee = Convert.ToString(firstPlot["processFee"]);
            }
        }

        Dictionary<string, object> tsiic = new Dictionary<string, object>();
        tsiic["applicationId"] = GetRowVal(t4, "ApplicationId");
        tsiic["industrialParkName"] = GetRowVal(t4, "IndustrialParkNAME");
        tsiic["plotTotalArea"] = GetRowVal(t4, "PlotTotalArea");
        tsiic["priceOfTheLand"] = priceLand;
        tsiic["emd"] = emd;
        tsiic["processFee"] = processFee;
        tsiic["cgst"] = GetRowVal(t4, "CGST", "Fees_CGST");
        tsiic["sgst"] = GetRowVal(t4, "SGST", "Fees_SGST");
        tsiic["amountToBePaid"] = GetRowVal(t4, "Amounttobepaid", "Fees_Amounttobepaid");
        tsiic["plotDetails"] = plotDetailsList;
        tsiic["assetsAndLiabilitiesDeclared"] = "";
        tsiic["declaredDateCommencementOfConstruction"] = "";
        tsiic["declaredDateTrialProduction"] = FormatDateVal(GetRowVal(t2, "Trail_Production"));
        tsiic["declaredDateCommercialOperations"] = FormatDateVal(GetRowVal(t2, "Portable_Date"));

        Dictionary<string, object> water = new Dictionary<string, object>();
        water["sourceOfWater"] = GetRowVal(t3, "SourceWater");
        water["totalWaterRequirementKlDay"] = GetRowVal(t3, "Requirement_Water");
        water["drinkingWaterKlDay"] = GetRowVal(t3, "Drink_Water");
        water["processingIndustrialUseKlDay"] = GetRowVal(t3, "Water_Processing");
        water["consumptiveUseKlDay"] = GetRowVal(t3, "Quant_Water_Consumptive");
        water["nonConsumptiveUseKlDay"] = GetRowVal(t3, "Quant_Water_NonConsumptive");

        Dictionary<string, object> power = new Dictionary<string, object>();
        power["contractedMaximumDemandKva"] = GetRowVal(t2, "Cont_Demand_Max");
        power["connectedLoadHp"] = GetRowVal(t2, "Connect_Load_A");
        power["transformerCapacityKva"] = GetRowVal(t2, "Aggrigate_Capcity");
        power["requiredVoltageLevelKv"] = GetRowVal(t2, "Req_Voltage");
        power["powerForConstructionHp"] = GetRowVal(t2, "Connect_Load_B");
        power["projectRequiresGenerator"] = "";

        Dictionary<string, object> labour = new Dictionary<string, object>();
        labour["categoryOfEstablishment"] = "";
        labour["managerOccupier"] = GetRowVal(t6, "ApplicantName", "NameofthePromoter", "Name");
        labour["natureOfWork"] = "";
        labour["peakBuildingWorkersMaxPerDay"] = GetRowVal(t0, "Prop_Emp");
        labour["contractorsAndMigrantWorkmen"] = new List<object>();
        labour["buildingWorkStartDate"] = "";
        labour["buildingWorkCompletionDate"] = "";
        labour["applicantDetails"] = (t6 == null) ? null : RowToDictionary(t6);

        Dictionary<string, object> data = new Dictionary<string, object>();
        data["identityAndRegistration"] = identity;
        data["locationAddress"] = location;
        data["projectCostAndEmployment"] = project;
        data["tsiicLandAllotmentAndMilestones"] = tsiic;
        data["water"] = water;
        data["powerCeig"] = power;
        data["labour"] = labour;

        Dictionary<string, object> response = new Dictionary<string, object>();
        response["status"] = "success";
        response["message"] = "CAF fields retrieved successfully";
        response["uidNo"] = uid;
        response["unitName"] = unitName;
        response["intCFEEnterpid"] = GetRowVal(t0, "intCFEEnterpid");
        response["data"] = data;

        return response;
    }

    private static Dictionary<string, object> RowToDictionary(DataRow r)
    {
        Dictionary<string, object> d = new Dictionary<string, object>();
        if (r == null || r.Table == null) return d;
        foreach (DataColumn col in r.Table.Columns)
            d[col.ColumnName] = r[col] == DBNull.Value ? "" : Convert.ToString(r[col]);
        return d;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public object InsertMobileAppUser(MobileAppUserRequest request)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        try
        {
            if (request == null)
            {
                result["status"] = "error";
                result["message"] = "Request body is required.";
                result["id"] = "";
                return result;
            }

            string unitName = request.UNIT_NAME == null ? "" : request.UNIT_NAME.Trim();
            string promoterName = request.PROMOTER_NAME == null ? "" : request.PROMOTER_NAME.Trim();
            string mobileNo = request.MOBILE_NO == null ? "" : request.MOBILE_NO.Trim();
            string product = request.PRODUCT == null ? "" : request.PRODUCT.Trim();
            string emailId = request.EMAIL_ID == null ? "" : request.EMAIL_ID.Trim();
            string ipAddress = request.IP_ADDRESS == null ? "" : request.IP_ADDRESS.Trim();

            if (ipAddress == "" && HttpContext.Current != null && HttpContext.Current.Request != null)
                ipAddress = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

            if (unitName == "")
            {
                result["status"] = "error";
                result["message"] = "Unit Name is required.";
                result["id"] = "";
                return result;
            }
            if (promoterName == "")
            {
                result["status"] = "error";
                result["message"] = "Promoter Name is required.";
                result["id"] = "";
                return result;
            }
            if (mobileNo == "")
            {
                result["status"] = "error";
                result["message"] = "Mobile Number is required.";
                result["id"] = "";
                return result;
            }
            if (mobileNo.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(mobileNo, @"^\d{10}$"))
            {
                result["status"] = "error";
                result["message"] = "Mobile Number must be exactly 10 digits.";
                result["id"] = "";
                return result;
            }
            if (product == "")
            {
                result["status"] = "error";
                result["message"] = "Product is required.";
                result["id"] = "";
                return result;
            }

            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_INSERT_MOBILEAPPUSER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UNIT_NAME", SqlDbType.VarChar, 250).Value = unitName;
            da.SelectCommand.Parameters.Add("@PROMOTER_NAME", SqlDbType.VarChar, 250).Value = promoterName;
            da.SelectCommand.Parameters.Add("@MOBILE_NO", SqlDbType.VarChar, 10).Value = mobileNo;
            da.SelectCommand.Parameters.Add("@PRODUCT", SqlDbType.VarChar, 500).Value = product;
            da.SelectCommand.Parameters.Add("@EMAIL_ID", SqlDbType.VarChar, 250).Value =
                emailId == "" ? (object)DBNull.Value : emailId;
            da.SelectCommand.Parameters.Add("@IP_ADDRESS", SqlDbType.VarChar, 100).Value =
                ipAddress == "" ? (object)DBNull.Value : ipAddress;

            ds = new DataSet();
            da.Fill(ds);

            string newId = "";
            string msg = "Record inserted successfully.";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                newId = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
                if (ds.Tables[0].Columns.Contains("MESSAGE") && ds.Tables[0].Rows[0]["MESSAGE"] != DBNull.Value)
                    msg = Convert.ToString(ds.Tables[0].Rows[0]["MESSAGE"]);
            }

            result["status"] = "success";
            result["message"] = msg;
            result["id"] = newId;
            return result;
        }
        catch (Exception ex)
        {
            result["status"] = "error";
            result["message"] = ex.Message;
            result["id"] = "";
            return result;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}
public class MobileAppUserRequest
{
    public string UNIT_NAME { get; set; }
    public string PROMOTER_NAME { get; set; }
    public string MOBILE_NO { get; set; }
    public string PRODUCT { get; set; }
    public string EMAIL_ID { get; set; }
    public string IP_ADDRESS { get; set; }
}
