using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;
/// <summary>
/// Summary description for PCBClass
/// </summary>
public class PCBClass
{
    Globavaribles gbp = new Globavaribles();

    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    public PCBClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GetPresentLandPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_PresentLandPCB", con.GetConnection);
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
    public DataSet GetLocationPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LocationPCB", con.GetConnection);
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
    public DataSet GetFeaturesPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_FeaturePCB]", con.GetConnection);
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
    public DataSet GetDisposalPointsPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_DisposalPointPCB]", con.GetConnection);
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

    public DataSet GetLocationTypePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LocationPCB", con.GetConnection);
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

    public DataSet GetWaterSorceTypePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_WaterSourcePCB", con.GetConnection);
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

    public DataSet GetWaterConsumptionTypesPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_WaterConsumptionPCB", con.GetConnection);
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

    public DataSet GetWaterDischargeTypePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_WaterDischargePCB", con.GetConnection);
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

    public DataSet GetToxinPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ToxinPCB", con.GetConnection);
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

    public DataSet GetDischargePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DischargePCB", con.GetConnection);
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

    public DataSet GetDischargePurposePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DischargePurposePCB", con.GetConnection);
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

    public DataSet GETFinalDischargePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_FinalDischargePCB", con.GetConnection);
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

    public DataSet GETEmissionGasesPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_EmissionGasesPCB", con.GetConnection);
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

    public DataSet GETFuelPurposePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_FuelPurposePCB", con.GetConnection);
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
    public DataSet GETDisposalPointPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DisposalPointPCB", con.GetConnection);
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

    public DataSet GETHazarPurposePCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HazarPurposePCB", con.GetConnection);
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
    public DataSet GETWasteWaterSourcePCB(string QuestionnaireId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_WasteWaterSource_PCB", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (QuestionnaireId != "")
                da.SelectCommand.Parameters.Add("@QuestionnaireId", SqlDbType.VarChar).Value = QuestionnaireId.ToString();
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
    public DataSet GETUnitsPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_UnitPCB", con.GetConnection);
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
    public int InsertWaterSourceDetails(string CreatedBy, int Questionnaireid, List<WaterSourcePCB> lstwaterSource)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDelWatersource = new SqlCommand("USP_DEL_WaterSource_PCB", connection);
            cmdDelWatersource.CommandType = CommandType.StoredProcedure;
            cmdDelWatersource.Transaction = transaction;
            cmdDelWatersource.Connection = connection;
            cmdDelWatersource.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDelWatersource.ExecuteNonQuery();

            foreach (WaterSourcePCB waterSourcevo in lstwaterSource)
            {
                SqlCommand cmdwaterS = new SqlCommand("USP_INS_WaterSource_PCB", connection);
                cmdwaterS.CommandType = CommandType.StoredProcedure;
                cmdwaterS.Transaction = transaction;
                cmdwaterS.Connection = connection;

                cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (waterSourcevo.Source_Type != null)
                    cmdwaterS.Parameters.AddWithValue("@Source_Type", waterSourcevo.Source_Type);
                if (waterSourcevo.SourceName != null)
                    cmdwaterS.Parameters.AddWithValue("@SourceName", waterSourcevo.SourceName);

                if (waterSourcevo.Quantity != null && waterSourcevo.Quantity != "")
                    cmdwaterS.Parameters.AddWithValue("@Quantity", waterSourcevo.Quantity);

                cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdwaterS.ExecuteNonQuery();
                valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
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

    public int InsertWaterConsumptionDetails(string CreatedBy, int Questionnaireid, List<WaterConsumptionPCB> lstwaterConsumption)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("[USP_DEL_WaterConsumption_PCB]", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (WaterConsumptionPCB waterConsumptionvo in lstwaterConsumption)
            {
                SqlCommand cmdInsert = new SqlCommand("[USP_INS_WaterConsumption_PCB]", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (waterConsumptionvo.Purpose != null)
                    cmdInsert.Parameters.AddWithValue("@Purpose", waterConsumptionvo.Purpose);
                if (waterConsumptionvo.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", waterConsumptionvo.Quantity);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertWasterWaterDetails(string CreatedBy, int Questionnaireid, List<WasteWaterDischargePCB> lstWasteWaterdtls)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("[USP_DEL_WasteWaterDischarge_PCB]", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (WasteWaterDischargePCB wasteWatervo in lstWasteWaterdtls)
            {
                SqlCommand cmdInsert = new SqlCommand("[USP_INS_WasteWaterDischarge_PCB]", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (wasteWatervo.Source != null)
                    cmdInsert.Parameters.AddWithValue("@Source", wasteWatervo.Source);
                if (wasteWatervo.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", wasteWatervo.Quantity);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertToxicWaterDetails(string CreatedBy, int Questionnaireid, List<ToxicSubstancePCB> lstToxics)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("[USP_DEL_ToxicSubstance_PCB]", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (ToxicSubstancePCB toxicVo in lstToxics)
            {
                SqlCommand cmdInsert = new SqlCommand("[USP_INS_ToxicSubstance_PCB]", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (toxicVo.Source != null)
                    cmdInsert.Parameters.AddWithValue("@Source", toxicVo.Source);
                if (toxicVo.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", toxicVo.Quantity);
                if (toxicVo.Substance != null)
                    cmdInsert.Parameters.AddWithValue("@Substance", toxicVo.Substance);
                if (toxicVo.Name != null)
                    cmdInsert.Parameters.AddWithValue("@Name", toxicVo.Name);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertFinalDischargeDetails(string CreatedBy, int Questionnaireid, List<PointofFinalDischargePCB> lstFinalDischarge)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_PointofFinalDischarge_PCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (PointofFinalDischargePCB finalvo in lstFinalDischarge)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_PointofFinalDischarge_PCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (finalvo.FSource != null)
                    cmdInsert.Parameters.AddWithValue("@Source", finalvo.FSource);
                if (finalvo.PointofDischarge != null)
                    cmdInsert.Parameters.AddWithValue("@PointofDischarge", finalvo.PointofDischarge);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertPhysicalCharDetails(string CreatedBy, int Questionnaireid, List<PhysicalCharactersticsPCB> lstPhyChars)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_PhysicalCharacterstics_PCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (PhysicalCharactersticsPCB phyCharvo in lstPhyChars)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_PhysicalCharacterstics_PCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;

                if (phyCharvo.PCSource != null)
                    cmdInsert.Parameters.AddWithValue("PCSource", phyCharvo.PCSource);
                if (phyCharvo.Temprature != null)
                    cmdInsert.Parameters.AddWithValue("Temprature", phyCharvo.Temprature);
                if (phyCharvo.PH != null)
                    cmdInsert.Parameters.AddWithValue("PH", phyCharvo.PH);
                if (phyCharvo.Colour != null)
                    cmdInsert.Parameters.AddWithValue("Colour", phyCharvo.Colour);
                if (phyCharvo.Turbidity != null)
                    cmdInsert.Parameters.AddWithValue("Turbidity", phyCharvo.Turbidity);
                if (phyCharvo.Odour != null)
                    cmdInsert.Parameters.AddWithValue("Odour", phyCharvo.Odour);
                if (phyCharvo.TotalSolids != null)
                    cmdInsert.Parameters.AddWithValue("TotalSolids", phyCharvo.TotalSolids);
                if (phyCharvo.SuspendedSolids != null)
                    cmdInsert.Parameters.AddWithValue("SuspendedSolids", phyCharvo.SuspendedSolids);
                if (phyCharvo.VolatileSolids != null)
                    cmdInsert.Parameters.AddWithValue("VolatileSolids", phyCharvo.VolatileSolids);
                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertChemicalCharDetails(string CreatedBy, int Questionnaireid, List<ChemicalDetailsPCB> lstChemicalChars)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_ChemicalDetails_PCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (ChemicalDetailsPCB checmicalVo in lstChemicalChars)
            {
                SqlCommand cmdInsert = new SqlCommand("[USP_INS_ChemicalDetails_PCB]", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (checmicalVo.Source != null)
                    cmdInsert.Parameters.AddWithValue("@Source", checmicalVo.Source);
                if (checmicalVo.Acidity != null)
                    cmdInsert.Parameters.AddWithValue("@Acidity", checmicalVo.Acidity);

                if (checmicalVo.Alkalinity != null)
                    cmdInsert.Parameters.AddWithValue("@Alkalinity", checmicalVo.Alkalinity);
                if (checmicalVo.Hardness != null)
                    cmdInsert.Parameters.AddWithValue("@Hardness", checmicalVo.Hardness);
                if (checmicalVo.BOD != null)
                    cmdInsert.Parameters.AddWithValue("@BOD", checmicalVo.BOD);
                if (checmicalVo.COD != null)
                    cmdInsert.Parameters.AddWithValue("@COD", checmicalVo.COD);
                if (checmicalVo.Oil_Greases != null)
                    cmdInsert.Parameters.AddWithValue("@Oil_Greases", checmicalVo.Oil_Greases);
                if (checmicalVo.Nitrogen_Phosphate != null)
                    cmdInsert.Parameters.AddWithValue("@Nitrogen_Phosphate", checmicalVo.Nitrogen_Phosphate);
                if (checmicalVo.Sulphates != null)
                    cmdInsert.Parameters.AddWithValue("@Sulphates", checmicalVo.Sulphates);
                if (checmicalVo.Total_Phosphates != null)
                    cmdInsert.Parameters.AddWithValue("@Total_Phosphates", checmicalVo.Total_Phosphates);
                if (checmicalVo.Total_Chloride != null)
                    cmdInsert.Parameters.AddWithValue("@Total_Chloride", checmicalVo.Total_Chloride);
                if (checmicalVo.Sodium != null)
                    cmdInsert.Parameters.AddWithValue("@Sodium", checmicalVo.Sodium);
                if (checmicalVo.Potassium != null)
                    cmdInsert.Parameters.AddWithValue("@Potassium", checmicalVo.Potassium);
                if (checmicalVo.Calcium != null)
                    cmdInsert.Parameters.AddWithValue("@Calcium", checmicalVo.Calcium);
                if (checmicalVo.Magnesium != null)
                    cmdInsert.Parameters.AddWithValue("@Magnesium", checmicalVo.Magnesium);
                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertOtherCharDetails(string CreatedBy, int Questionnaireid, List<OtherCharactersticsPCB> lstOtherChars)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_OtherCharacterstics_PCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (OtherCharactersticsPCB otherCharvo in lstOtherChars)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_OtherCharacterstics_PCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (otherCharvo.OSource != null)
                    cmdInsert.Parameters.AddWithValue("@OSource", otherCharvo.OSource);
                if (otherCharvo.Item != null)
                    cmdInsert.Parameters.AddWithValue("@Item", otherCharvo.Item);
                if (otherCharvo.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", otherCharvo.Quantity);
                if (otherCharvo.Units != null)
                    cmdInsert.Parameters.AddWithValue("@Units", otherCharvo.Units);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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
    public DataSet GetGasesPCB()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_EmissionGasesPCB", con.GetConnection);
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
    public int InsertStackDetailsPCB(string CreatedBy, int Questionnaireid, List<StackDetailsPCB> lstStackDetailsPCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_StackDetailsPCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (StackDetailsPCB stackdtlspcb in lstStackDetailsPCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_StackDetailsPCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackdtlspcb.StackAttached != null)
                    cmdInsert.Parameters.AddWithValue("@StackAttached", stackdtlspcb.StackAttached);
                if (stackdtlspcb.StackHeight != null)
                    cmdInsert.Parameters.AddWithValue("@StackHeight", stackdtlspcb.StackHeight);
                if (stackdtlspcb.Temprature != null)
                    cmdInsert.Parameters.AddWithValue("@Temprature", stackdtlspcb.Temprature);
                if (stackdtlspcb.ExpectedQuantity != null)
                    cmdInsert.Parameters.AddWithValue("@ExpectedQuantity", stackdtlspcb.ExpectedQuantity);
                if (stackdtlspcb.AirPollution != null)
                    cmdInsert.Parameters.AddWithValue("@AirPollution", stackdtlspcb.AirPollution);
                if (stackdtlspcb.Diameter != null)
                    cmdInsert.Parameters.AddWithValue("@Diameter", stackdtlspcb.Diameter);
                if (stackdtlspcb.FlowRate != null)
                    cmdInsert.Parameters.AddWithValue("@FlowRate", stackdtlspcb.FlowRate);
                if (stackdtlspcb.StackHeightGround != null)
                    cmdInsert.Parameters.AddWithValue("@StackHeightGround", stackdtlspcb.StackHeightGround);
                if (stackdtlspcb.StackTop != null)
                    cmdInsert.Parameters.AddWithValue("@StackTop", stackdtlspcb.StackTop);

                if (stackdtlspcb.EmissionStandards != null)
                    cmdInsert.Parameters.AddWithValue("@EmissionStandards", stackdtlspcb.EmissionStandards);
                if (stackdtlspcb.StackCount != null)
                    cmdInsert.Parameters.AddWithValue("@StackCount", stackdtlspcb.StackCount);
                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertStackDustPCB(string CreatedBy, int Questionnaireid, List<StackDustPCB> lstStackDustPCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_StackDustPCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (StackDustPCB stackdtlspcb in lstStackDustPCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_StackDustPCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;
                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackdtlspcb.StackName != null)
                    cmdInsert.Parameters.AddWithValue("@StackName", stackdtlspcb.StackName);
                if (stackdtlspcb.NatureofDust != null)
                    cmdInsert.Parameters.AddWithValue("@NatureofDust", stackdtlspcb.NatureofDust);
                if (stackdtlspcb.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", stackdtlspcb.Quantity);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertStackGasesPCB(string CreatedBy, int Questionnaireid, List<StackGasesPCB> lstStackGasesPCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_StackGasesPCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (StackGasesPCB stackdtlspcb in lstStackGasesPCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_StackGasesPCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;
                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackdtlspcb.StackName != null)
                    cmdInsert.Parameters.AddWithValue("@StackName", stackdtlspcb.StackName);
                if (stackdtlspcb.Gases != null)
                    cmdInsert.Parameters.AddWithValue("@Gases", stackdtlspcb.Gases);
                if (stackdtlspcb.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", stackdtlspcb.Quantity);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertStackDetailsFugitivePCB(string CreatedBy, int Questionnaireid, List<StackDetailsFugitivePCB> lstStackDetailsFugitivePCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_StackDetailsFugitivePCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (StackDetailsFugitivePCB stackdtlsFugpcb in lstStackDetailsFugitivePCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_StackDetailsFugitivePCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;

                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackdtlsFugpcb.StackAttached != null)
                    cmdInsert.Parameters.AddWithValue("@StackAttached", stackdtlsFugpcb.StackAttached);
                if (stackdtlsFugpcb.StackHeight != null)
                    cmdInsert.Parameters.AddWithValue("@StackHeight", stackdtlsFugpcb.StackHeight);
                if (stackdtlsFugpcb.Temprature != null)
                    cmdInsert.Parameters.AddWithValue("@Temprature", stackdtlsFugpcb.Temprature);
                if (stackdtlsFugpcb.ExpectedQuantity != null)
                    cmdInsert.Parameters.AddWithValue("@ExpectedQuantity", stackdtlsFugpcb.ExpectedQuantity);
                if (stackdtlsFugpcb.AirPollution != null)
                    cmdInsert.Parameters.AddWithValue("@AirPollution", stackdtlsFugpcb.AirPollution);
                if (stackdtlsFugpcb.Diameter != null)
                    cmdInsert.Parameters.AddWithValue("@Diameter", stackdtlsFugpcb.Diameter);
                if (stackdtlsFugpcb.FlowRate != null)
                    cmdInsert.Parameters.AddWithValue("@FlowRate", stackdtlsFugpcb.FlowRate);
                if (stackdtlsFugpcb.StackHeightGround != null)
                    cmdInsert.Parameters.AddWithValue("@StackHeightGround", stackdtlsFugpcb.StackHeightGround);
                if (stackdtlsFugpcb.StackTop != null)
                    cmdInsert.Parameters.AddWithValue("@StackTop", stackdtlsFugpcb.StackTop);

                if (stackdtlsFugpcb.EmissionStandards != null)
                    cmdInsert.Parameters.AddWithValue("@EmissionStandards", stackdtlsFugpcb.EmissionStandards);
                if (stackdtlsFugpcb.StackCount != null)
                    cmdInsert.Parameters.AddWithValue("@StackCount", stackdtlsFugpcb.StackCount);
                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertStackDustFugitivePCB(string CreatedBy, int Questionnaireid, List<StackDustFugitivePCB> lstStackDustFugitivePCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_StackDustFugitivePCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (StackDustFugitivePCB stackDustFugpcb in lstStackDustFugitivePCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_StackDustFugitivePCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;
                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackDustFugpcb.StackName != null)
                    cmdInsert.Parameters.AddWithValue("@StackName", stackDustFugpcb.StackName);
                if (stackDustFugpcb.NatureofDust != null)
                    cmdInsert.Parameters.AddWithValue("@NatureofDust", stackDustFugpcb.NatureofDust);
                if (stackDustFugpcb.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", stackDustFugpcb.Quantity);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertStackGasesFugitivePCB(string CreatedBy, int Questionnaireid, List<StackGasesFugitivePCB> lstStackGasesFugitivePCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_StackGasesFugitivePCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (StackGasesFugitivePCB stackGasFugpcb in lstStackGasesFugitivePCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_StackGasesFugitivePCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;
                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackGasFugpcb.StackName != null)
                    cmdInsert.Parameters.AddWithValue("@StackName", stackGasFugpcb.StackName);
                if (stackGasFugpcb.Gases != null)
                    cmdInsert.Parameters.AddWithValue("@Gases", stackGasFugpcb.Gases);
                if (stackGasFugpcb.Quantity != null)
                    cmdInsert.Parameters.AddWithValue("@Quantity", stackGasFugpcb.Quantity);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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

    public int InsertFuelPCB(string CreatedBy, int Questionnaireid, List<FuelPCB> lstFuelPCB)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDel = new SqlCommand("USP_DEL_FuelPCB", connection);
            cmdDel.CommandType = CommandType.StoredProcedure;
            cmdDel.Transaction = transaction;
            cmdDel.Connection = connection;
            cmdDel.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDel.ExecuteNonQuery();

            foreach (FuelPCB stackGasFugpcb in lstFuelPCB)
            {
                SqlCommand cmdInsert = new SqlCommand("USP_INS_FuelPCB", connection);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Transaction = transaction;
                cmdInsert.Connection = connection;
                cmdInsert.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (stackGasFugpcb.NameFuel != null)
                    cmdInsert.Parameters.AddWithValue("@NameFuel", stackGasFugpcb.NameFuel);
                if (stackGasFugpcb.DailyConsumption != null)
                    cmdInsert.Parameters.AddWithValue("@DailyConsumption", stackGasFugpcb.DailyConsumption);
                if (stackGasFugpcb.Purpose != null)
                    cmdInsert.Parameters.AddWithValue("@Purpose", stackGasFugpcb.Purpose);
                if (stackGasFugpcb.Unit != null)
                    cmdInsert.Parameters.AddWithValue("@Unit", stackGasFugpcb.Unit);

                cmdInsert.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdInsert.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdInsert.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdInsert.ExecuteNonQuery();
                valid = (Int32)cmdInsert.Parameters["@Valid"].Value;
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
    public DataSet GetSTACKNAMES(string QuestionnaireId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_STACKNAMES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (QuestionnaireId != "")
                da.SelectCommand.Parameters.Add("@QuestionnaireId", SqlDbType.VarChar).Value = QuestionnaireId.ToString();
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
    public DataSet GetFugitiveSTACKNAMES(string QuestionnaireId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_FUGITIVE_STACKNAMES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (QuestionnaireId != "")
                da.SelectCommand.Parameters.Add("@QuestionnaireId", SqlDbType.VarChar).Value = QuestionnaireId.ToString();
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
    public DataSet getAirEmissionPCBDetails(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[getPCBDetails_AirEmission]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEnterprenuerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEnterprenuerid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();



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
    public DataSet GetDrugSections()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_SECTIONDRUG", con.GetConnection);
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

    public int InsertDrugDetails(string CreatedBy, int Questionnaireid, List<DirectorDetails_Drug> lstDirectorDrug, List<PRODUCTS_Drug> lstProductDrug, List<TechStaff_Drug> lstTechStaffDrug, String catogorylicensence, String Licensetype, String typeform, string typeofLicene)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDelWatersource = new SqlCommand("USP_DEL_DirectorDetailsDrug", connection);
            cmdDelWatersource.CommandType = CommandType.StoredProcedure;
            cmdDelWatersource.Transaction = transaction;
            cmdDelWatersource.Connection = connection;
            cmdDelWatersource.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDelWatersource.ExecuteNonQuery();

            foreach (DirectorDetails_Drug dirdrugvo in lstDirectorDrug)
            {
                SqlCommand cmdwaterS = new SqlCommand("USP_INS_DirectorDetailsDrug", connection);
                cmdwaterS.CommandType = CommandType.StoredProcedure;
                cmdwaterS.Transaction = transaction;
                cmdwaterS.Connection = connection;

                cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (dirdrugvo.Name != null)
                    cmdwaterS.Parameters.AddWithValue("@Name", dirdrugvo.Name);
                if (dirdrugvo.Designation != null)
                    cmdwaterS.Parameters.AddWithValue("@Designation", dirdrugvo.Designation);
                if (dirdrugvo.Address != null)
                    cmdwaterS.Parameters.AddWithValue("@Address", dirdrugvo.Address);
                if (dirdrugvo.IdProofNo != null)
                    cmdwaterS.Parameters.AddWithValue("@IdProofNo", dirdrugvo.IdProofNo);
                if (dirdrugvo.EffectiveDate != null)
                    cmdwaterS.Parameters.AddWithValue("@Effdate", dirdrugvo.EffectiveDate);
                if (dirdrugvo.CertificateDate != null)
                    cmdwaterS.Parameters.AddWithValue("@CerDate", dirdrugvo.CertificateDate);
                if (catogorylicensence != "0")
                    cmdwaterS.Parameters.AddWithValue("@Catogorylicencen", catogorylicensence);
                if (Licensetype != "0")
                    cmdwaterS.Parameters.AddWithValue("@Licensetype", Licensetype);
                if (typeform != "0")
                    cmdwaterS.Parameters.AddWithValue("@Typeform", typeform);
                if (dirdrugvo.transformerfilepath != null)
                    cmdwaterS.Parameters.AddWithValue("@transformerfilepath", dirdrugvo.transformerfilepath);
                if (dirdrugvo.SalesManufacturer != null)
                    cmdwaterS.Parameters.AddWithValue("@SalesManufacturer", dirdrugvo.SalesManufacturer);

                cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdwaterS.ExecuteNonQuery();
                valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
            }

            SqlCommand cmdDelProductDrug = new SqlCommand("USP_DEL_ProductDrug", connection);
            cmdDelProductDrug.CommandType = CommandType.StoredProcedure;
            cmdDelProductDrug.Transaction = transaction;
            cmdDelProductDrug.Connection = connection;
            cmdDelProductDrug.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDelProductDrug.ExecuteNonQuery();

            foreach (PRODUCTS_Drug proddrug in lstProductDrug)
            {
                SqlCommand cmdwaterS = new SqlCommand("USP_INS_ProductDrug", connection);
                cmdwaterS.CommandType = CommandType.StoredProcedure;
                cmdwaterS.Transaction = transaction;
                cmdwaterS.Connection = connection;

                cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (proddrug.Name != null)
                    cmdwaterS.Parameters.AddWithValue("@Name", proddrug.Name);
                if (proddrug.Composition != null)
                    cmdwaterS.Parameters.AddWithValue("@Composition", proddrug.Composition);
                if (proddrug.ExportDomestic != null)
                    cmdwaterS.Parameters.AddWithValue("@ExportDomestic", proddrug.ExportDomestic);
                if (proddrug.BrandName != null)
                    cmdwaterS.Parameters.AddWithValue("@BrandName", proddrug.BrandName);
                if (proddrug.ProductCategory != null)
                    cmdwaterS.Parameters.AddWithValue("@ProdCategory", proddrug.ProductCategory);

                cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdwaterS.ExecuteNonQuery();
                valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
            }

            SqlCommand cmdDelTechDrug = new SqlCommand("USP_DEL_TechStaffDrug", connection);
            cmdDelTechDrug.CommandType = CommandType.StoredProcedure;
            cmdDelTechDrug.Transaction = transaction;
            cmdDelTechDrug.Connection = connection;
            cmdDelTechDrug.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDelTechDrug.ExecuteNonQuery();

            if (typeofLicene == "1")
            {
                foreach (TechStaff_Drug techstaffdrug in lstTechStaffDrug)
                {
                    SqlCommand cmdwaterS = new SqlCommand("USP_INS_TechStaffDrug", connection);
                    cmdwaterS.CommandType = CommandType.StoredProcedure;
                    cmdwaterS.Transaction = transaction;
                    cmdwaterS.Connection = connection;

                    cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                    if (techstaffdrug.Name != null)
                        cmdwaterS.Parameters.AddWithValue("@Name", techstaffdrug.Name);
                    if (techstaffdrug.Qualification != null)
                        cmdwaterS.Parameters.AddWithValue("@Qualification", techstaffdrug.Qualification);
                    if (techstaffdrug.Designation != null)
                        cmdwaterS.Parameters.AddWithValue("@Designation", techstaffdrug.Designation);
                    if (techstaffdrug.Experience != null)
                        cmdwaterS.Parameters.AddWithValue("@Experience", techstaffdrug.Experience);
                    if (techstaffdrug.Section != null)
                        cmdwaterS.Parameters.AddWithValue("@Section", techstaffdrug.Section);

                    cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                    cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                    cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    cmdwaterS.ExecuteNonQuery();
                    valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
                }
            }

            if (typeofLicene == "2")
            {
                foreach (TechStaff_Drug techstaffdrug in lstTechStaffDrug)
                {
                    SqlCommand cmdwaterS = new SqlCommand("USP_INS_TechStaffDrug_Sales", connection);
                    cmdwaterS.CommandType = CommandType.StoredProcedure;
                    cmdwaterS.Transaction = transaction;
                    cmdwaterS.Connection = connection;

                    cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                    if (techstaffdrug.Name != null)
                        cmdwaterS.Parameters.AddWithValue("@Name", techstaffdrug.Name);
                    if (techstaffdrug.Qualification != null)
                        cmdwaterS.Parameters.AddWithValue("@Qualification", techstaffdrug.Qualification);
                    if (techstaffdrug.IDProof != null)
                        cmdwaterS.Parameters.AddWithValue("@IDProofNo", techstaffdrug.IDProof);
                    if (techstaffdrug.Experience != null)
                        cmdwaterS.Parameters.AddWithValue("@Experience", techstaffdrug.Experience);
                    if (techstaffdrug.ApprovalSought != null)
                        cmdwaterS.Parameters.AddWithValue("@ApprovalSught", techstaffdrug.ApprovalSought);

                    cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                    cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                    cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    cmdwaterS.ExecuteNonQuery();
                    valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
                }

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

    public DataSet GetDrugDetails(string Questionnaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DRUGDETAILS_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Questionnaireid != "")
                da.SelectCommand.Parameters.Add("@Questionnaireid", SqlDbType.VarChar).Value = Questionnaireid.ToString();
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
    public DataSet GetHazardousProcessPCB(string schedule)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HazarPurposePCB", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (schedule != "")
                da.SelectCommand.Parameters.Add("@Schedule", SqlDbType.VarChar).Value = schedule.ToString();
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
    public DataSet GetHazardousNamePCB(string processid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HazarWastePCB", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (processid != "")
                da.SelectCommand.Parameters.Add("@ProcessId", SqlDbType.VarChar).Value = processid.ToString();
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
    public int InsertHazardousDetails(string CreatedBy, int Questionnaireid, List<HazardousWastePCB> lstHazardousWaste)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDelWatersource = new SqlCommand("USP_DEL_HazarWastePCB", connection);
            cmdDelWatersource.CommandType = CommandType.StoredProcedure;
            cmdDelWatersource.Transaction = transaction;
            cmdDelWatersource.Connection = connection;
            cmdDelWatersource.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDelWatersource.ExecuteNonQuery();

            foreach (HazardousWastePCB hazardousvo in lstHazardousWaste)
            {
                SqlCommand cmdwaterS = new SqlCommand("USP_INS_HazarWastePCB", connection);
                cmdwaterS.CommandType = CommandType.StoredProcedure;
                cmdwaterS.Transaction = transaction;
                cmdwaterS.Connection = connection;

                cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (hazardousvo.Activity != null)
                    cmdwaterS.Parameters.AddWithValue("@Activity", hazardousvo.Activity);
                if (hazardousvo.Schedule != null)
                    cmdwaterS.Parameters.AddWithValue("@Schedule", hazardousvo.Schedule);
                if (hazardousvo.Process != null)
                    cmdwaterS.Parameters.AddWithValue("@Process", hazardousvo.Process);
                if (hazardousvo.HazardousName != null)
                    cmdwaterS.Parameters.AddWithValue("@HazardousName", hazardousvo.HazardousName);
                if (hazardousvo.HazardousDesc != null)
                    cmdwaterS.Parameters.AddWithValue("@HazardousDesc", hazardousvo.HazardousDesc);
                if (hazardousvo.Quantity != null)
                    cmdwaterS.Parameters.AddWithValue("@Quantity", hazardousvo.Quantity);
                if (hazardousvo.Unit != null)
                    cmdwaterS.Parameters.AddWithValue("@Unit", hazardousvo.Unit);
                if (hazardousvo.Storage != null)
                    cmdwaterS.Parameters.AddWithValue("@Storage", hazardousvo.Storage);
                if (hazardousvo.Recycle != null)
                    cmdwaterS.Parameters.AddWithValue("@Recycle", hazardousvo.Recycle);
                if (hazardousvo.Disposal != null)
                    cmdwaterS.Parameters.AddWithValue("@Disposal", hazardousvo.Disposal);
                if (hazardousvo.Existing != null)
                    cmdwaterS.Parameters.AddWithValue("@Existing", hazardousvo.Existing);
                if (hazardousvo.Proposed != null)
                    cmdwaterS.Parameters.AddWithValue("@Proposed", hazardousvo.Proposed);
                if (hazardousvo.Total != null)
                    cmdwaterS.Parameters.AddWithValue("@Total", hazardousvo.Total);

                cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdwaterS.ExecuteNonQuery();
                valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
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
    public int InsertNonHazardousDetails(string CreatedBy, int Questionnaireid, List<NonHazardousWastePCB> lstNonHazardousWaste)
    {
        int valid = 1;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand cmdDelWatersource = new SqlCommand("USP_DEL_NonHazarWastePCB", connection);
            cmdDelWatersource.CommandType = CommandType.StoredProcedure;
            cmdDelWatersource.Transaction = transaction;
            cmdDelWatersource.Connection = connection;
            cmdDelWatersource.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
            cmdDelWatersource.ExecuteNonQuery();

            foreach (NonHazardousWastePCB nonhazardousvo in lstNonHazardousWaste)
            {
                SqlCommand cmdwaterS = new SqlCommand("USP_INS_NonHazarWastePCB", connection);
                cmdwaterS.CommandType = CommandType.StoredProcedure;
                cmdwaterS.Transaction = transaction;
                cmdwaterS.Connection = connection;

                cmdwaterS.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = Questionnaireid;
                if (nonhazardousvo.Description != null)
                    cmdwaterS.Parameters.AddWithValue("@Description", nonhazardousvo.Description);
                if (nonhazardousvo.Quantity != null)
                    cmdwaterS.Parameters.AddWithValue("@Quantity", nonhazardousvo.Quantity);
                if (nonhazardousvo.Unit != null)
                    cmdwaterS.Parameters.AddWithValue("@Unit", nonhazardousvo.Unit);
                if (nonhazardousvo.Disposal != null)
                    cmdwaterS.Parameters.AddWithValue("@Disposal", nonhazardousvo.Disposal);
                if (nonhazardousvo.Existing != null)
                    cmdwaterS.Parameters.AddWithValue("@Existing", nonhazardousvo.Existing);
                if (nonhazardousvo.Proposed != null)
                    cmdwaterS.Parameters.AddWithValue("@Proposed", nonhazardousvo.Proposed);
                if (nonhazardousvo.Total != null)
                    cmdwaterS.Parameters.AddWithValue("@Total", nonhazardousvo.Total);

                cmdwaterS.Parameters.AddWithValue("@Created_by", CreatedBy);
                cmdwaterS.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmdwaterS.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmdwaterS.ExecuteNonQuery();
                valid = (Int32)cmdwaterS.Parameters["@Valid"].Value;
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

    public DataSet GetHazardousDetailsPCB(string Questionnaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HAZARDOUSPCB", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Questionnaireid != "")
                da.SelectCommand.Parameters.Add("@Questionnaireid", SqlDbType.VarChar).Value = Questionnaireid.ToString();
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