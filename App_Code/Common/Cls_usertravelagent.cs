using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;

/// <summary>
/// Summary description for Cls_usertravelagent
/// </summary>
public class Cls_usertravelagent
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_usertravelagent()
    {
        //
        // TODO: Add constructor logic here
        //
    }


   public DataSet Tourismagentshops_GetShowQuestionaries(string Created_by)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("Tourismagentshops_GetShowQuestionaries", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (Created_by.Trim() == "" || Created_by.Trim() == null)
                    da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();



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
    public DataSet Tourismaegntshops_getdatavarifyqueCFO(string Created_by)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Tourismaegntshops_getdatavarifyqueCFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();
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
    public string Tourismagentshops_RetriveStatusCFO(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Tourismagentshops_RetriveStatusCFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();
            da.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString().Trim();
        }
        catch (Exception ex)
        {
            //throw ex;
            return "0";
        }
        finally
        {
            con.CloseConnection();
        }
    }
    public DataSet GetverifyofqueLabour_tourismagentshops(string Created_by)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("tourismagentshops_getdataverifyqueLabourCFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();
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
    public DataSet GetShowQuestionariesCFO_tourismagentshops(string Created_by)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("tourismagentshops_getQuesssionerCFOID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();
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

    #region master general class
    public DataSet GetLabourActClassification()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LabourActEst_Classification_MASTER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetLabourActCategoryMaster()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LabourActEst_Category_MASTER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetWorkPlaceMaster()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_LABOUR_WORKPLACE_MASTER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetLabourActOccupationMaster()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LabourActEst_Occupation_MASTER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetDistrictsWithoutHYD_Labour()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetDistricts_Labour", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;




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
    public DataSet GetMandalsLabour(string District)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetMandals_Labour", con.GetConnection);
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
    public DataSet GetVillagesLabour(string Mandal)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetVillages_Labour", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = Mandal.ToString();

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
    public DataSet GetLabourActRelationshipMaster()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_LabourActEst_Relationship_MASTER]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetGender()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_LabourActEst_Gender_MASTER]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetLabourActPersonMaster()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LabourActEst_PersonType_MASTER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    #endregion
    public DataSet tourismagentshops_getLabourDetails_CFO(string intEnterprenuerid, int QuestionnaireId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("tourismagentshops_getLabourDetails_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEnterprenuerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEnterprenuerid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();
            if (QuestionnaireId != null)
                da.SelectCommand.Parameters.Add("@QuestionnairId", SqlDbType.Int).Value = QuestionnaireId;

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

    public DataSet ViewAttachment_tourismagentshops(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("RetriveCFOAttachment_tourismagentshops", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();
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

    public int InsertLabourDetails_tourismagentshops(LabourActVO labouractvo, List<LabourWorkPlace> lstworkplacevo, List<EmployeesDetails> LstLabourEmployeesvo, List<FamilyMembersAct1> lstFamilyMembers, List<ContractorDetails> lstContractorVoAct3, List<ContractorDetails> lstContractorVoAct4)
    {
        int valid = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "INS_Questionnaire_Labour_tourismagentshops";

            com.Transaction = transaction;
            com.Connection = connection;
            if (labouractvo.intCFEEnterpid == 0 || labouractvo.intCFEEnterpid == null)
                com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = labouractvo.intCFEEnterpid;


            if (labouractvo.QuestionnaireId == 0 || labouractvo.QuestionnaireId == null)
                com.Parameters.Add("@QuestionnaireId", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            if (labouractvo.Uid_No == null || labouractvo.Uid_No.ToString().Trim() == "" || labouractvo.Uid_No.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = labouractvo.Uid_No.Trim();

            if (labouractvo.Reg_Id == null || labouractvo.Reg_Id.ToString().Trim() == "" || labouractvo.Reg_Id.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = labouractvo.Reg_Id;

            if (labouractvo.LabourActId == null || labouractvo.LabourActId.ToString().Trim() == "" || labouractvo.LabourActId.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Labour_ActId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Labour_ActId", SqlDbType.VarChar).Value = labouractvo.LabourActId.Trim();
            //----------------------------
            if (labouractvo.EstClassification == null || labouractvo.EstClassification.ToString().Trim() == "" || labouractvo.EstClassification.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Estb_Classification", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Estb_Classification", SqlDbType.VarChar).Value = labouractvo.EstClassification.Trim();

            if (labouractvo.CategoryofEstablishment == null || labouractvo.CategoryofEstablishment.ToString().Trim() == "" || labouractvo.CategoryofEstablishment.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Estb_Category", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Estb_Category", SqlDbType.VarChar).Value = labouractvo.CategoryofEstablishment.Trim();
            if (labouractvo.NameofShopAct1 == null || labouractvo.NameofShopAct1.ToString().Trim() == "" || labouractvo.NameofShopAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estb_Name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estb_Name", SqlDbType.VarChar).Value = labouractvo.NameofShopAct1.Trim();

            if (labouractvo.ShopDoorNo == null || labouractvo.ShopDoorNo.ToString().Trim() == "" || labouractvo.ShopDoorNo.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_DoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_DoorNo", SqlDbType.VarChar).Value = labouractvo.ShopDoorNo.Trim();

            if (labouractvo.ShopLocality == null || labouractvo.ShopLocality.ToString().Trim() == "" || labouractvo.ShopLocality.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_Locality", SqlDbType.VarChar).Value = labouractvo.ShopLocality.Trim();

            if (labouractvo.ShopDistrict == null || labouractvo.ShopDistrict.ToString().Trim() == "" || labouractvo.ShopDistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_District", SqlDbType.VarChar).Value = labouractvo.ShopDistrict.Trim();

            if (labouractvo.ShopMandal == null || labouractvo.ShopMandal.ToString().Trim() == "" || labouractvo.ShopMandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_Mandal", SqlDbType.VarChar).Value = labouractvo.ShopMandal.Trim();

            if (labouractvo.ShopVillage == null || labouractvo.ShopVillage.ToString().Trim() == "" || labouractvo.ShopVillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_Village", SqlDbType.VarChar).Value = labouractvo.ShopVillage.Trim();
            if (labouractvo.ShopPincode == null || labouractvo.ShopPincode.ToString().Trim() == "" || labouractvo.ShopPincode.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_PinCode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_PinCode", SqlDbType.VarChar).Value = labouractvo.ShopPincode.Trim();

            if (labouractvo.NameofUnitAct1 == null || labouractvo.NameofUnitAct1.ToString().Trim() == "" || labouractvo.NameofUnitAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Name", SqlDbType.VarChar).Value = labouractvo.NameofUnitAct1.Trim();

            if (labouractvo.PGNameAct1 == null || labouractvo.PGNameAct1.ToString().Trim() == "" || labouractvo.PGNameAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Empolyer_FatherName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Empolyer_FatherName", SqlDbType.VarChar).Value = labouractvo.PGNameAct1.Trim();
            if (labouractvo.EmpDesignation == null || labouractvo.EmpDesignation.ToString().Trim() == "" || labouractvo.EmpDesignation.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Designation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Designation", SqlDbType.VarChar).Value = labouractvo.EmpDesignation.Trim();

            if (labouractvo.AgeAct1 == null || labouractvo.AgeAct1.ToString().Trim() == "" || labouractvo.AgeAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Age", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Age", SqlDbType.VarChar).Value = labouractvo.AgeAct1.Trim();

            if (labouractvo.MobileAct1 == null || labouractvo.MobileAct1.ToString().Trim() == "" || labouractvo.MobileAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_MobileNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_MobileNo", SqlDbType.VarChar).Value = labouractvo.MobileAct1.Trim();

            if (labouractvo.EmailAct1 == null || labouractvo.EmailAct1.ToString().Trim() == "" || labouractvo.EmailAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_EmailID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_EmailID", SqlDbType.VarChar).Value = labouractvo.EmailAct1.Trim();
            if (labouractvo.DoorNoResidentialAct1 == null || labouractvo.DoorNoResidentialAct1.ToString().Trim() == "" || labouractvo.DoorNoResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_DoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_DoorNo", SqlDbType.VarChar).Value = labouractvo.DoorNoResidentialAct1.Trim();
            if (labouractvo.LocalResidentialAct1 == null || labouractvo.LocalResidentialAct1.ToString().Trim() == "" || labouractvo.LocalResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Locality", SqlDbType.VarChar).Value = labouractvo.LocalResidentialAct1.Trim();

            if (labouractvo.DistrictResidentialAct1 == null || labouractvo.DistrictResidentialAct1.ToString().Trim() == "" || labouractvo.DistrictResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_District", SqlDbType.VarChar).Value = labouractvo.DistrictResidentialAct1.Trim();

            if (labouractvo.MandalResidentialAct1 == null || labouractvo.MandalResidentialAct1.ToString().Trim() == "" || labouractvo.MandalResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Mandal", SqlDbType.VarChar).Value = labouractvo.MandalResidentialAct1.Trim();

            if (labouractvo.VillageResidentialAct1 == null || labouractvo.VillageResidentialAct1.ToString().Trim() == "" || labouractvo.VillageResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Village", SqlDbType.VarChar).Value = labouractvo.VillageResidentialAct1.Trim();

            if (labouractvo.ManagerResidenceAct1 == null || labouractvo.ManagerResidenceAct1.ToString().Trim() == "" || labouractvo.ManagerResidenceAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Agent_Flag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Agent_Flag", SqlDbType.VarChar).Value = labouractvo.ManagerResidenceAct1.Trim();

            if (labouractvo.ManagerNameAct1 == null || labouractvo.ManagerNameAct1.ToString().Trim() == "" || labouractvo.ManagerNameAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Name", SqlDbType.VarChar).Value = labouractvo.ManagerNameAct1.Trim();
            if (labouractvo.ManagerPGNameAct1 == null || labouractvo.ManagerPGNameAct1.ToString().Trim() == "" || labouractvo.ManagerPGNameAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_FatherName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_FatherName", SqlDbType.VarChar).Value = labouractvo.ManagerPGNameAct1.Trim();

            if (labouractvo.ManagerDesignationAct1 == null || labouractvo.ManagerDesignationAct1.ToString().Trim() == "" || labouractvo.ManagerDesignationAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Designation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Designation", SqlDbType.VarChar).Value = labouractvo.ManagerDesignationAct1.Trim();

            if (labouractvo.ManagerDoorNo == null || labouractvo.ManagerDoorNo.ToString().Trim() == "" || labouractvo.ManagerDoorNo.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_DoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_DoorNo", SqlDbType.VarChar).Value = labouractvo.ManagerDoorNo.Trim();

            if (labouractvo.ManagerLocalityAct1 == null || labouractvo.ManagerLocalityAct1.ToString().Trim() == "" || labouractvo.ManagerLocalityAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Locality", SqlDbType.VarChar).Value = labouractvo.ManagerLocalityAct1.Trim();

            if (labouractvo.ManagerDistrictAct1 == null || labouractvo.ManagerDistrictAct1.ToString().Trim() == "" || labouractvo.ManagerDistrictAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_District", SqlDbType.VarChar).Value = labouractvo.ManagerDistrictAct1.Trim();

            if (labouractvo.ManagerMandalAct1 == null || labouractvo.ManagerMandalAct1.ToString().Trim() == "" || labouractvo.ManagerMandalAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Mandal", SqlDbType.VarChar).Value = labouractvo.ManagerMandalAct1.Trim();
            if (labouractvo.ManagerVillageAct1 == null || labouractvo.ManagerVillageAct1.ToString().Trim() == "" || labouractvo.ManagerVillageAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Village", SqlDbType.VarChar).Value = labouractvo.ManagerVillageAct1.Trim();
            if (labouractvo.NatureofBusinessAct1 == null || labouractvo.NatureofBusinessAct1.ToString().Trim() == "" || labouractvo.NatureofBusinessAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Nature_of_Business", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Nature_of_Business", SqlDbType.VarChar).Value = labouractvo.NatureofBusinessAct1.Trim();

            if (labouractvo.DateofCommenceAct1 == null || labouractvo.DateofCommenceAct1.ToString().Trim() == "" || labouractvo.DateofCommenceAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_DateofCommencement", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_DateofCommencement", SqlDbType.VarChar).Value = labouractvo.DateofCommenceAct1.Trim();

            if (labouractvo.Above18Male == null || labouractvo.Above18Male == 0)
                com.Parameters.Add("@Form1_1_Employees_Above18_Male", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_Above18_Male", SqlDbType.Int).Value = labouractvo.Above18Male;

            if (labouractvo.Above18FeMale == null || labouractvo.Above18FeMale == 0)
                com.Parameters.Add("@Form1_1_Employees_Above18_Female", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_Above18_Female", SqlDbType.Int).Value = labouractvo.Above18FeMale;

            if (labouractvo.Below18Male == null || labouractvo.Below18Male == 0)
                com.Parameters.Add("@Form1_1_Employees_14_18_Male", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_14_18_Male", SqlDbType.Int).Value = labouractvo.Below18Male;

            if (labouractvo.Below18FeMale == null || labouractvo.Below18FeMale == 0)
                com.Parameters.Add("@Form1_1_Employees_14_18_Female", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_14_18_Female", SqlDbType.Int).Value = labouractvo.Below18FeMale;

            if (labouractvo.CreatedBy == null || labouractvo.CreatedBy == 0)
                com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.Int).Value = labouractvo.CreatedBy;

            if (labouractvo.TotalAbove18 == 0 || labouractvo.TotalAbove18 == null)
                com.Parameters.Add("@TotalAbove18", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@TotalAbove18", SqlDbType.Int).Value = labouractvo.TotalAbove18;

            if (labouractvo.TotalBelow18 == 0 || labouractvo.TotalBelow18 == null)
                com.Parameters.Add("@TotalBelow18Emps", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@TotalBelow18Emps", SqlDbType.Int).Value = labouractvo.TotalBelow18;

            if (labouractvo.TotalEmployees == 0 || labouractvo.TotalEmployees == null)
                com.Parameters.Add("@TotalEmployees", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@TotalEmployees", SqlDbType.Int).Value = labouractvo.TotalEmployees;
            //if (labouractvo.DateofCommenceAct1 != null && labouractvo.DateofCommenceAct1 != "")
            //    com.Parameters.Add("@Form1_1_DateofCommencement", SqlDbType.VarChar).Value = labouractvo.DateofCommenceAct1.Trim();
            com.Parameters.Add("@Created_User", SqlDbType.VarChar).Value = labouractvo.CreatedUser;

            if (labouractvo.FullNamePerAct2 != null)
                com.Parameters.AddWithValue("@Form1_2_FullName", labouractvo.FullNamePerAct2);
            if (labouractvo.PerDoorNoAct2 != null)
                com.Parameters.AddWithValue("@Form1_2_Per_DoorNo", labouractvo.PerDoorNoAct2);
            if (labouractvo.PerVillage != null)
                com.Parameters.AddWithValue("@Form1_2_Per_Village", labouractvo.PerVillage);
            if (labouractvo.PerMandal != null)
                com.Parameters.AddWithValue("@Form1_2_Per_Mandal", labouractvo.PerMandal);
            if (labouractvo.PerDistrict != null)
                com.Parameters.AddWithValue("@Form1_2_Per_District", labouractvo.PerDistrict);
            if (labouractvo.PerPincode != null)
                com.Parameters.AddWithValue("@Form1_2_Per_PinCode", labouractvo.PerPincode);
            if (labouractvo.CompletionDateAct2 != "" && labouractvo.CompletionDateAct2 != null)
                com.Parameters.AddWithValue("@Form1_2_Est_Compltd_Dt", cmf.convertDateIndia(labouractvo.CompletionDateAct2));
            if (labouractvo.ManagerMobileNo != null)
                com.Parameters.AddWithValue("@Form1_Manager_MobileNo", labouractvo.ManagerMobileNo);
            if (labouractvo.ManagerEmail != null)
                com.Parameters.AddWithValue("@Form1_Manager_EMail", labouractvo.ManagerEmail);

            if (labouractvo.RegActId != null)
                com.Parameters.AddWithValue("@Form1_3_Registered_Act", labouractvo.RegActId);
            if (labouractvo.LicenseRegNo != null)
                com.Parameters.AddWithValue("@Form1_3_Reg_Lic", labouractvo.LicenseRegNo);

            if (labouractvo.DirNameAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_FullName", labouractvo.DirNameAct4);
            if (labouractvo.DirDoorNoAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_DoorNo", labouractvo.DirDoorNoAct4);
            if (labouractvo.DirVillageAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_Village", labouractvo.DirVillageAct4);
            if (labouractvo.DirMandalAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_Mandal", labouractvo.DirMandalAct4);
            if (labouractvo.DirDistrictAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_District", labouractvo.DirDistrictAct4);

            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            //FamilyMembersAct1
            //EmployeeDetails
            // object returnvalue = com.ExecuteScalar();
            com.ExecuteNonQuery();
            //if (returnvalue == DBNull.Value || returnvalue == null)
            //    return 0;
            //else
            //    return Convert.ToInt32(returnvalue);

            valid = (Int32)com.Parameters["@Valid"].Value;

            SqlCommand cmdDelWorkPlace = new SqlCommand("USP_DEL_Godown_Labour_tourismagentshops", connection);
            cmdDelWorkPlace.CommandType = CommandType.StoredProcedure;
            cmdDelWorkPlace.Transaction = transaction;
            cmdDelWorkPlace.Connection = connection;
            cmdDelWorkPlace.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelWorkPlace.ExecuteNonQuery();

            foreach (LabourWorkPlace workplacevo in lstworkplacevo)
            {
                SqlCommand cmdEnj = new SqlCommand("INS_Godown_Labour_tourismagentshops", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
                cmdEnj.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (workplacevo.WorkPlace != null)
                    cmdEnj.Parameters.AddWithValue("@Work_Place", workplacevo.WorkPlace);
                if (workplacevo.DoorNo != null)
                    cmdEnj.Parameters.AddWithValue("@Door_No", workplacevo.DoorNo);

                if (workplacevo.Locality != null && workplacevo.Locality != "")
                    cmdEnj.Parameters.AddWithValue("@Locality", workplacevo.Locality);
                cmdEnj.ExecuteNonQuery();
            }
            SqlCommand cmdDelFamilyMembers = new SqlCommand("DEL_Family_Member_Labour_tourismagentshops", connection);
            cmdDelFamilyMembers.CommandType = CommandType.StoredProcedure;
            cmdDelFamilyMembers.Transaction = transaction;
            cmdDelFamilyMembers.Connection = connection;
            cmdDelFamilyMembers.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelFamilyMembers.ExecuteNonQuery();

            foreach (FamilyMembersAct1 familyvo in lstFamilyMembers)
            {
                SqlCommand cmdInsFamily = new SqlCommand("INS_Family_Member_Labour_tourismagentshops", connection);
                cmdInsFamily.CommandType = CommandType.StoredProcedure;
                cmdInsFamily.Transaction = transaction;
                cmdInsFamily.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdInsFamily);
                cmdInsFamily.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (familyvo.FamilyNameAct1 != null)
                    cmdInsFamily.Parameters.AddWithValue("@Name", familyvo.FamilyNameAct1);
                if (familyvo.RelationshipAct1 != null)
                    cmdInsFamily.Parameters.AddWithValue("@RelationShip", familyvo.RelationshipAct1);

                if (familyvo.GenderAct1 != null && familyvo.GenderAct1 != "")
                    cmdInsFamily.Parameters.AddWithValue("@Gender", familyvo.GenderAct1);
                if (familyvo.AdultAct1 != null && familyvo.AdultAct1 != "")
                    cmdInsFamily.Parameters.AddWithValue("@Adult_Flag", familyvo.AdultAct1);
                cmdInsFamily.ExecuteNonQuery();
            }
            SqlCommand cmdDelEmp = new SqlCommand("DEL_Employees_Labour_tourismagentshops", connection);
            cmdDelEmp.CommandType = CommandType.StoredProcedure;
            cmdDelEmp.Transaction = transaction;
            cmdDelEmp.Connection = connection;
            cmdDelEmp.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelEmp.ExecuteNonQuery();

            foreach (EmployeesDetails empvo in LstLabourEmployeesvo)
            {
                SqlCommand cmdInsEmp = new SqlCommand("INS_Employees_Labour_tourismagentshops", connection);
                cmdInsEmp.CommandType = CommandType.StoredProcedure;
                cmdInsEmp.Transaction = transaction;
                cmdInsEmp.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdInsEmp);
                cmdInsEmp.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (empvo.Occupation != null)
                    cmdInsEmp.Parameters.AddWithValue("@Occupation", empvo.Occupation);
                if (empvo.EmployeeNameAct1 != null)
                    cmdInsEmp.Parameters.AddWithValue("@Name", empvo.EmployeeNameAct1);
                if (empvo.EmployeeGenderAct1 != null && empvo.EmployeeGenderAct1 != "")
                    cmdInsEmp.Parameters.AddWithValue("@Gender", empvo.EmployeeGenderAct1);

                cmdInsEmp.ExecuteNonQuery();
            }
            SqlCommand cmdDelContractor = new SqlCommand("DEL_Contractor_Workmen_Labour_tourismagentshops", connection);
            cmdDelContractor.CommandType = CommandType.StoredProcedure;
            cmdDelContractor.Transaction = transaction;
            cmdDelContractor.Connection = connection;
            cmdDelContractor.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelContractor.ExecuteNonQuery();

            foreach (ContractorDetails Contractorvo in lstContractorVoAct3)
            {
                SqlCommand cmdEnj = new SqlCommand("INS_Contractor_Workmen_Labour_tourismagentshops", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                cmdEnj.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (Contractorvo.ContractorName != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Name", Contractorvo.ContractorName);
                if (Contractorvo.ContractorAddress != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Address", Contractorvo.ContractorAddress);
                if (Contractorvo.ContractorMobileNo != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MobileNo", Contractorvo.ContractorMobileNo);
                if (Contractorvo.ContractorWorkNature != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Work_Nature", Contractorvo.ContractorWorkNature);
                if (Contractorvo.ContractorWorkMen != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MaxWorkers", Contractorvo.ContractorWorkMen);
                if (Contractorvo.ContractorCommence != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Commence_Dt", Contractorvo.ContractorCommence);
                if (Contractorvo.ContractorComplete != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Compltd_Dt", Contractorvo.ContractorComplete);
                if (Contractorvo.ManufacturingDepts != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_ManufacturingDepts", Contractorvo.ManufacturingDepts);
                cmdEnj.ExecuteNonQuery();
            }
            foreach (ContractorDetails Contractorvo in lstContractorVoAct4)
            {
                SqlCommand cmdEnj = new SqlCommand("INS_Contractor_Workmen_Labour_tourismagentshops", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                cmdEnj.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (Contractorvo.ContractorName != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Name", Contractorvo.ContractorName);
                if (Contractorvo.ContractorAddress != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Address", Contractorvo.ContractorAddress);
                if (Contractorvo.ContractorMobileNo != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MobileNo", Contractorvo.ContractorMobileNo);
                if (Contractorvo.ContractorWorkNature != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Work_Nature", Contractorvo.ContractorWorkNature);
                if (Contractorvo.ContractorWorkMen != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MaxWorkers", Contractorvo.ContractorWorkMen);
                if (Contractorvo.ContractorCommence != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Commence_Dt", Contractorvo.ContractorCommence);
                if (Contractorvo.ContractorComplete != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Compltd_Dt", Contractorvo.ContractorComplete);
                if (Contractorvo.ManufacturingDepts != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_ManufacturingDepts", Contractorvo.ManufacturingDepts);
                cmdEnj.ExecuteNonQuery();
            }
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
        return valid;
    }

    public DataSet getdepartmentdetailsonuid_tourismagentshops(string uidno, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDETAILS_DEPARTMENT_SERVICE_tourismagentshops", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (deptid.Trim() != "" || deptid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = deptid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = null;
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

    public DataSet getattachmentdetailsonuid_tourismagentshops(string uidno, string deptid, string applid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GET_ATTACHMENTS_UID_tourismagentshops", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (deptid.Trim() != "" || deptid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = deptid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = null;
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

    public DataSet GetQueryStatusByTransactionID_tourismagentshops(string User_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetQueryStatusByTransactionID_tourismagentshops", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (User_id.Trim() == "" || User_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = User_id.ToString();

            if (User_id.Trim() == "" || User_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";



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


    public int InsertQueryDetails_tourismagentshops(string intEnterpreniourApprovalid,string intQuessionaireid,string intCFEEnterpid,string intDeptid,
string intApprovalid,string QueryRaiseDate,string QueryDescription,string QueryStatus,string QueryAttachmentFileName,string QueryAttachmentFilePath,
string QueryRespondDate,string QueryRespondRemarks,string Created_by,string Created_dt,string Modified_by, string Modified_dt, string IPAddress)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("InsertQueryDetails_tourismagentshops", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (IPAddress.Trim() == "" || IPAddress.Trim() == null || IPAddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            }
            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null || intEnterpreniourApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = Int32.Parse(intEnterpreniourApprovalid.Trim());
            }
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null || intCFEEnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }
            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (QueryDescription.ToString().Trim() == "" || QueryDescription.ToString().Trim() == null || QueryDescription.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();

            if (QueryStatus.ToString().Trim() == "" || QueryStatus.ToString().Trim() == null || QueryStatus.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

            if (QueryAttachmentFileName.ToString().Trim() == "" || QueryAttachmentFileName.ToString().Trim() == null || QueryAttachmentFileName.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.ToString().Trim() == "" || QueryAttachmentFilePath.ToString().Trim() == null || QueryAttachmentFilePath.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();

            if (QueryRespondRemarks.ToString().Trim() == "" || QueryRespondRemarks.ToString().Trim() == null || QueryRespondRemarks.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }
            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }
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
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }



    public int InsertCFOAttachement_tourismagentshops(string intQuessionaireCFOid,string intCFOEnterpid,string Uid_No,string Reg_Id,string AttachmentTypeName,
string AttachmentFilename,string AttachmentFilePath,string Status,string Created_by,string FileDescription)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("CFOAttachmentDet_tourismagentshops", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Int32.Parse(Created_by.Trim());
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
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
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }


    public DataSet getLabourRegisteredActs_tourismagentshops(string intEnterprenuerid, int QuestionnaireId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GET_LABOUR_RegisteredAct_tourismagentshops", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEnterprenuerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEnterprenuerid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();
            if (QuestionnaireId != null)
                da.SelectCommand.Parameters.Add("@QuestionnairId", SqlDbType.Int).Value = QuestionnaireId;

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