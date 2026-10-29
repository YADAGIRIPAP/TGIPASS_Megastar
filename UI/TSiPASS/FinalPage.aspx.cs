using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessLogic;

public partial class UI_TSiPASS_FinalPage : System.Web.UI.Page
{
    General Gen = new General();
    Fetch objFetch = new Fetch();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();

    DataSet ds = new DataSet();
    DataSet dsCAF = new DataSet();
    string incentiveid = "";
    string checkMstid = "";
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            try
            {

                if (!IsPostBack)
                {

                    if (Session["EntprIncentive"] != null)
                    {
                        incentiveid = Session["EntprIncentive"].ToString();
                        // ds = Gen.GetAllIncentives(Session["uid"].ToString().Trim());

                        checkMstid = getMstSubmittedVal(incentiveid);
                        if (checkMstid == "2")
                        {
                            DataSet dscaste = new DataSet();
                            dscaste = Gen.GetIncentivesCaste(Session["uid"].ToString(), incentiveid);

                            if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
                            {
                                string applicationStatus = dscaste.Tables[0].Rows[0]["intstatusid"].ToString();
                                if (applicationStatus == null || applicationStatus == "")
                                {
                                    // SendSmsEmail(incentiveid, dscaste);
                                    Gen.UpdateIncentivesCAFStatus(incentiveid);
                                    lblAppliedSuccesful.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            //string message = "alert('Annexures not filled completely!')";
                            //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            ScriptManager.RegisterStartupScript((sender as Control), this.GetType(), "alert", "alert('Annexures not filled completely!');window.location =TypeOfIncentivesNew.aspx;", true);
                            lblAppliedSuccesful.Visible = false;
                            Response.Redirect("TypeOfIncentivesNew.aspx");
                        }
                    
                    }
                    else
                    {
                        incentiveid = Request.QueryString[0].ToString();

                        checkMstid = getMstSubmittedVal(incentiveid);

                        if(checkMstid=="2")
                        {



                            ds = Gen.GetAllIncentivesByid(incentiveid);
                            tdmsg.InnerHtml = "";

                            DataSet dscaste = new DataSet();
                            dscaste = Gen.GetIncentivesCaste(Session["uid"].ToString(), incentiveid);

                            if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
                            {
                                string applicationStatus = dscaste.Tables[0].Rows[0]["intstatusid"].ToString();
                                if (applicationStatus == null || applicationStatus == "")
                                {
                                    //SendSmsEmail(incentiveid, dscaste);
                                    Gen.UpdateIncentivesCAFStatus(incentiveid);
                                    lblAppliedSuccesful.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            
                            Response.Redirect("TypeOfIncentivesNew.aspx");
                            string message = "alert('Annexures not filled completely!')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            lblAppliedSuccesful.Visible = false;
                        }
                    }
                    tr1.Visible = true;

                    //  ds = Gen.GetAllIncentives(Session["uid"].ToString().Trim());
                    try
                    {

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            // Session["EntprIncentive"] = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                            Session["incentivedata"] = ds;

                            for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
                            {
                                string mstincentiveid = ds.Tables[0].Rows[i]["IncentiveID"].ToString();  // tm_Incentive --> Master table

                                if (mstincentiveid == "1")
                                {
                                    trPavallavaddi.Visible = true;
                                }
                                if (mstincentiveid == "2")
                                {
                                    trTransportVehicle.Visible = false;
                                }
                                if (mstincentiveid == "3")
                                {
                                    trpowercost.Visible = true;
                                }
                                if (mstincentiveid == "4")
                                {
                                    trCleanerProduction.Visible = true;
                                }
                                if (mstincentiveid == "5")
                                {
                                    trSalesTax.Visible = true;
                                }
                                if (mstincentiveid == "6")
                                {
                                    trInvestmentSubsidy.Visible = true;
                                }
                                if (mstincentiveid == "7")
                                {
                                    trIIDF.Visible = true;
                                }
                                if (mstincentiveid == "8")
                                {
                                    trReimbursementofcost.Visible = true;
                                }
                                if (mstincentiveid == "9")
                                {
                                    trstampDuty.Visible = true;
                                }
                                if (mstincentiveid == "10")
                                {
                                    trSeedCap.Visible = true;
                                }
                                if (mstincentiveid == "11")
                                {
                                    trQualityCertification.Visible = true;
                                }
                                if (mstincentiveid == "12")
                                {
                                    trAdvanceSubsidySCST.Visible = true;
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }

    public string getMstSubmittedVal(string incentiveid )
    {
        string valid = "";

        try
        {     
            SqlTransaction transaction = null;
            osqlConnection.Open();
            //transaction = osqlConnection.BeginTransaction();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[USP_INCFORMCHECK]";

            com.Transaction = transaction;
            com.Connection = osqlConnection;

            if (incentiveid!="" && incentiveid!=null)
                com.Parameters.AddWithValue("@incentiveid", incentiveid);
            else
                com.Parameters.AddWithValue("@incentiveid", null);
             

            com.Parameters.Add("@validCheck", SqlDbType.VarChar, 500);
            com.Parameters["@validCheck"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@validCheck"].Value.ToString();

            osqlConnection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
        return valid;
    }

    public void SendSmsEmail(string incentiveid, DataSet dscaste)
    {
        string useridnew = Session["uid"].ToString();
        string IncentveID = incentiveid;
        DataSet dsAppliedIncentives = new DataSet();
        string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", AppliedIncentives = "", ApplicationDate = "", DistrictName = "";

        dsAppliedIncentives = Gen.GetAllIncentivesDeptView(incentiveid);
        if (dsAppliedIncentives != null && dsAppliedIncentives.Tables.Count > 0 && dsAppliedIncentives.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsAppliedIncentives.Tables[0].Rows.Count; i++)
            {
                if (dsAppliedIncentives.Tables[0].Rows[i]["IncentiveName"] != null && dsAppliedIncentives.Tables[0].Rows[i]["IncentiveName"] != "")
                {
                    AppliedIncentives += dsAppliedIncentives.Tables[0].Rows[i]["IncentiveName"].ToString() + ", ";
                }
            }
        }

        //DataSet dscaste = new DataSet();
        //dscaste = Gen.GetIncentivesCaste(useridnew, IncentveID);        

        if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
        {
            string applicationStatus = dscaste.Tables[0].Rows[0]["intstatusid"].ToString();

            UnitName = dscaste.Tables[0].Rows[0]["UnitName"].ToString();
            ApplicantName = dscaste.Tables[0].Rows[0]["ApplciantName"].ToString();
            UnitEmail = dscaste.Tables[0].Rows[0]["UnitEmail"].ToString();
            UnitMobileNo = dscaste.Tables[0].Rows[0]["UnitMObileNo"].ToString();
            ApplicationDate = dscaste.Tables[0].Rows[0]["Created_dtNew"].ToString();
            DistrictName = dscaste.Tables[0].Rows[0]["District"].ToString();
        }

        DataTable dtMandt = objFetch.FetchIncentiveMandatoryDocuments(Convert.ToInt32(incentiveid));

        System.Text.StringBuilder strMandt = new System.Text.StringBuilder();
        string nameuid = UnitEmail.Replace("@", "(at)");
        for (int i = 0; i < dtMandt.Rows.Count - 1; i++) strMandt.Append(dtMandt.Rows[i]["AttachmentName"].ToString() + "<br />");

        try
        {
            cmf.SendMailIncentive(UnitEmail, "You have successfully filed claim application of M/s " + UnitName + " for the following incentives " + AppliedIncentives + "on Date " + ApplicationDate + ", <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");

            // cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ",  Your incentives application is filed successfully on " + ApplicationDate + ", and your applied incentives list: " + AppliedIncentives + " and a detail mail is sent to " + nameuid + ". Thank You, GM, DIC - ASIFABAD Thank You,<br />  Govt. of Telangana.");

        }
        catch (Exception ex)
        {

        }
        try
        {
            cmf.SendSingleSMS(UnitMobileNo, "You have successfully filed claim application of M/s " + UnitName + " for the following incentives " + AppliedIncentives + "on Date " + ApplicationDate + " and a detail mail is sent to " + nameuid + "," + '\n' + "Thank You," + '\n' + "GM, DIC -" + DistrictName + "," + '\n' + "Govt. of Telangana.");

        }
        catch (Exception ex)
        {

        }

    }
    protected void lnkPavallavaddi_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexPavalaVaddi.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexPavalaVaddi.aspx");
    }
    protected void lnkTransportVehicle_Click(object sender, EventArgs e)
    {
        Response.Redirect("");
    }
    protected void lnkpowercost_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexPowerCost.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexPowerCost.aspx");
    }
    protected void lnkCleanerProduction_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexCleanerProduction.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexCleanerProduction.aspx");
    }
    protected void lnkSalesTax_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexSalesTax.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexSalesTax.aspx");
    }
    protected void lnkInvestmentSubsidy_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexInvestSubsidyS.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexInvestSubsidyS.aspx");
    }
    protected void lnkIIDF_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexIIDF.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexIIDF.aspx");
    }
    protected void lnkReimbursementofcost_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexSkillIUpg.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexSkillIUpg.aspx");
    }
    protected void lnkstampDuty_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexStampDuty.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexStampDuty.aspx");
    }
    protected void lnkSeedCap_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexSeedCap.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexSeedCap.aspx");
    }
    protected void lnkQualityCertification_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexQualityCertification.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexQualityCertification.aspx");
    }
    protected void lnkAdvanceSubsidySCST_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/TSiPASS/IncentivesAnnexures/AnnexAdvancedSubsidySCST.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexAdvancedSubsidySCST.aspx");
    }


    //adde newly
    protected void lnkapplntotalprint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/Tsipass/IncetivesDraft.aspx','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexInvestSubsidyS.aspx");
    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../UI/TSiPASS/InscentiveView_AttachmentsNewIncType.aspx?EntrpId=" + Session["EntprIncentive"].ToString());
    }
}