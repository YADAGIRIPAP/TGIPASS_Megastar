using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_IncentivesAnnexure_InvestmentSubsidy : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DataSet dscaste = new DataSet();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                if (Session["incentivedata"] != null)
                {
                    string userid = Session["uid"].ToString();
                    string IncentveID = Session["EntprIncentive"].ToString();

                    //dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                    if (Convert.ToString(Session["AddlInvSubsidy"]) == "")
                    {
                        dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                    }
                    else
                    {
                        dscaste = GetIncentivesCaste_AddlInvSubsidy(userid, IncentveID);
                    }
                    if (dscaste!=null)
                    {
                        ViewState["dscaste"] = dscaste;                        
                    }
                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                    string lblscheme = dscaste.Tables[0].Rows[0]["Scheme"].ToString();
                    string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                    string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                    string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();
                    string isAllWomen = dscaste.Tables[0].Rows[0]["isAllWomen"].ToString();


                    //if (caste == "3" || caste == "4" )   //SC, ST  
                    if (lblscheme.ToString() == "TIDEA")
                    {
                        //  if (caste == "3" || caste == "4")   //SC, ST
                        if (TSCPflag == "Y" || TSPflag == "Y")
                        {
                            lblheadTPRIDE.Visible = true;
                            lblheadTIDEA.Visible = false;
                            lblheadTPRIDE.Text = "<center>" + "ANNEXURE: VIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INVESTMENT SUBSIDY  UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                            lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                            lblheadTIDEA.Visible = false;

                            //txtSchemeEligible.Text = "T-PRIDE(TSCP)";  //"T-PRIDE";
                            // txtSchemeEligible.Enabled = false;

                        }
                        else if (TIDEAflag == "Y")
                        {
                            lblheadTIDEA.Visible = true;

                            lblheadTIDEA.Text = "<center>" + "ANNEXURE: VIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INVESTMENT SUBSIDY UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                            lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                            lblheadTPRIDE.Visible = false;

                        }
                    }
                    else if (lblscheme.ToString() == "TFAP")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: VIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INVESTMENT SUBSIDY UNDER TFAP </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2022 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                    else
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: VIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INVESTMENT SUBSIDY UNDER " + lblscheme.ToString() + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }

                    // for tr visible true or false



                    if (dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "2" || dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "3")
                    {
                        trex1.Visible = true;
                        trex2.Visible = true;
                        trex3.Visible = true;
                    }
                    else
                    {
                        trex1.Visible = false;
                        trex2.Visible = false;
                        trex3.Visible = false;
                    }
                    if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                    {
                        trisdeclare2_1.Visible = true;
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                    {
                        trisdeclare2_2.Visible = true;
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                    {
                        trisdeclare2_3.Visible = true;
                    }
                    //if (dscaste != null && dscaste.Tables.Count > 1 && dscaste.Tables[1].Rows.Count > 0)
                    //{
                    //    if (dscaste.Tables[1].Rows[0]["StatusGender"].ToString().Trim() == "Y")
                    //    {
                    //        txtAppldAddlAmtWomen.Text = "500000.00";
                    //        txtAppldAddlAmtWomen.Enabled = false;
                    //        Session["StatusGender"] = "Y";
                    //        txtAppldAddlAmtWomen_TextChanged(sender, e);
                    //    }
                    //    else
                    //    {
                    //        txtAppldAddlAmtWomen.Enabled = true;
                    //        Session["StatusGender"] = "N";
                    //    }
                    //}

                    if ((TIDEAflag == "Y" && isAllWomen == "Y"))
                    {
                        if (dscaste != null && dscaste.Tables.Count > 2 && dscaste.Tables[2].Rows.Count > 0)
                        {
                            txtAppldInvestSubsidy.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentmen"].ToString().Trim();
                            txtAppldAddlAmtWomen.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentAdditionalWomen"].ToString().Trim();

                            // txtAppldInvestSubsidy_TextChanged(sender, e);
                        }
                        trgenSC1.Visible = true;
                        trSC1.Visible = true;
                    }
                    else if (TIDEAflag == "Y" && isAllWomen != "Y")
                    {
                        if (dscaste != null && dscaste.Tables.Count > 2 && dscaste.Tables[2].Rows.Count > 0)
                        {
                            txtAppldInvestSubsidy.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentmen"].ToString().Trim();
                            txtAppldAddlAmtWomen.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentAdditionalWomen"].ToString().Trim();

                            // txtAppldInvestSubsidy_TextChanged(sender, e);
                        }
                        trgenSC1.Visible = true;
                        trSC1.Visible = false;
                    }
                    if ((TSCPflag == "Y" && (isAllWomen == null || isAllWomen == "")) || (TSPflag == "Y" && (isAllWomen == null || isAllWomen == "")))
                    {
                        if (dscaste != null && dscaste.Tables.Count > 2 && dscaste.Tables[2].Rows.Count > 0)
                        {
                            txtISCSCT.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentmen"].ToString().Trim();
                            txtScheduledAreas.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentAdditionalWomen"].ToString().Trim();

                            // txtAppldInvestSubsidy_TextChanged(sender, e);
                        }
                        trSC2.Visible = true;
                        trSC3.Visible = false;
                    }
                    else if ((TSCPflag == "Y" && isAllWomen == "Y") || (TSPflag == "Y" && isAllWomen == "Y"))
                    {
                        if (dscaste != null && dscaste.Tables.Count > 2 && dscaste.Tables[2].Rows.Count > 0)
                        {
                            txtISCSCT.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentmen"].ToString().Trim();
                            txtScheduledAreas.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentAdditionalWomen"].ToString().Trim();

                        }
                        trSC2.Visible = true;
                        trSC3.Visible = true;
                    }
                    if (dscaste != null && dscaste.Tables.Count > 2 && dscaste.Tables[2].Rows.Count > 0)
                    {
                        txtAppldTotInvestSubsidy.Text = dscaste.Tables[2].Rows[0]["TotalInvestMentPer"].ToString().Trim();
                    }

                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 6);
                    if (drs.Length > 0)
                    {
                        DataSet dsnew = new DataSet();
                        dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                        Filldata(dsnew);
                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("StampDutyAnnex.aspx?next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("frmIncentiveCAFDetails.aspx?Previous=" + "P");
                        }
                    }
                    DataSet dsdisable = new DataSet();
                    dsdisable = Gen.GETINCENTIVESCAFDATA(userid, IncentveID);
                    if (dsdisable.Tables.Count > 0 && dsdisable.Tables[6].Rows.Count > 0)
                    {
                        string applicationStatus = "";
                        applicationStatus = dsdisable.Tables[6].Rows[0]["intStatusid"].ToString();
                        if (applicationStatus != "")
                        {

                            if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                            {
                                ResetFormControl(this);
                            }
                        }
                        hdnMSMEApplied.Value = dsdisable.Tables[6].Rows[0]["MSME_Applied"].ToString();//Applied under MSME policy
                        if (hdnMSMEApplied.Value == "Y")
                        {
                            trMSME1Women.Visible = false;
                            
                            if(TSCPflag == "Y"||TSPflag == "Y")
                                {
                                lblSTSTID.Text = "Investment subsidy for Women entrepreneurs in ST/ST/PWD Category";
                            }
                            

                            //trMSME2Schedule.Visible = true;
                            //trSC3.Visible = false;
                            lblMSMEPolicy.Visible = true;
                            lblheadTIDEA.Visible = false;
                            lblheadTPRIDE.Visible = false;
                        }
                    }
                }
            }
        }
    }
    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnNext.Enabled = true;
            BtnSave.Enabled = false;
            //txtAppldAddlAmtWomen.Text = ds.Tables[0].Rows[0]["AppldAddlAmtWomen"].ToString();
            //txtAppldInvestSubsidy.Text = ds.Tables[0].Rows[0]["AppldInvestSubsidy"].ToString();
            //txtAppldTotInvestSubsidy.Text = ds.Tables[0].Rows[0]["AppldTotInvestSubsidy"].ToString();
            txtAvldSubsidyAmt.Text = ds.Tables[0].Rows[0]["AvldSubsidyAmt"].ToString();
            txtAvldSubsidyScheme.Text = ds.Tables[0].Rows[0]["AvldSubsidyScheme"].ToString();

            txtSchemeEligible.Text = ds.Tables[0].Rows[0]["SchemeEligible"].ToString();

            //if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
            //{
            //     txtSchemeEligible.Text
            //}
            //else if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
            //{

            //}
            //else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
            //{

            //}
            // added newly on 12.06.2017
          //  txtScheduledAreas.Text = ds.Tables[0].Rows[0]["ISubsidyScheduledAreas"].ToString();
           // txtISCSCT.Text = ds.Tables[0].Rows[0]["ISubsidySCSCT"].ToString();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int c = ds.Tables[1].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[1].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = ds.Tables[1].Rows[i]["LINKNEW"].ToString();// LINKNEW
                   string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                    if (sen.Contains("13")) // if (sen.Contains("62"))
                    {
                       //lblUpload1.NavigateUrl = sen;
                        lblUpload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblUpload1.Visible = true;
                        lblAttachedFileName1.Visible = false;
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("15"))                    //if (sen.Contains("63"))
                    {
                      //  lblUpload2.NavigateUrl = sen;
                        lblUpload2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblUpload2.Visible = true;
                        lblAttachedFileName2.Visible = false;
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("9053"))                    //if (sen.Contains("63"))
                    {
                       // lblUpload3.NavigateUrl = sen;
                        lblUpload3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblUpload3.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName3.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblUpload3.Visible = true;
                        lblAttachedFileName3.Visible = false;
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    i++;
                }
            }


            txtAppldAddlAmtWomen.Enabled = false;
            txtAppldInvestSubsidy.Enabled = false;
            txtAppldTotInvestSubsidy.Enabled = false;
            txtAvldSubsidyAmt.Enabled = false;
            txtAvldSubsidyScheme.Enabled = false;
            txtSchemeEligible.Enabled = false;
            BtnSave.Enabled = false;

            txtScheduledAreas.Enabled = false;
            txtISCSCT.Enabled = false;
            Totalinvestment();
        }
        else
        {
            txtAppldAddlAmtWomen.Enabled = true;
            txtAppldInvestSubsidy.Enabled = true;
            txtAppldTotInvestSubsidy.Enabled = true;
            txtAvldSubsidyAmt.Enabled = true;
            txtAvldSubsidyScheme.Enabled = true;
            txtSchemeEligible.Enabled = true;
            BtnSave.Enabled = true;

            txtScheduledAreas.Enabled = true;
            txtISCSCT.Enabled = true;
        }
    }
    public DataSet GetIncentivesCaste_AddlInvSubsidy(string createdby, string incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INCENTIVES_CASTE_FOR_ADDL_INV_SUBSIDY", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (createdby != null)
                da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();

            if (incentiveid != null)
                da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            else
                da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = null;

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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "")
        {
            if (save())
            {
                //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                //success.Visible = true;
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "6", "Y", "");
                string message = "alert('Investment Subsidy Applied Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                BtnNext.Enabled = true;
                BtnSave.Enabled = false;
            }
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave.Enabled = true;
        }
    }
    public bool save()
    {
        try
        {
            AssignValuestoVosFromcontrols();

            //string valid = Gen.InsertIncentIS(objvoA);
            string valid = "";
            if (Convert.ToString(Session["AddlInvSubsidy"]) == "")
            {
                valid = Gen.InsertIncentIS(objvoA);
            }
            else
            { valid = InsertIncentIS(objvoA); }
            if (valid == "Y")
            {
                lblmsg.Text = "Submitted Successfully";
                success.Visible = true;

            }

        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        return true;
    }
    public string InsertIncentIS(IncentiveVosIncetForms objvo1)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        string valid = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INS_INCENT_IS";

            com.Transaction = transaction;
            com.Connection = connection;

            if (objvo1.AppldAddlAmtWomen != null)
                com.Parameters.AddWithValue("@AppldAddlAmtWomen", objvo1.AppldAddlAmtWomen);
            else
                com.Parameters.AddWithValue("@AppldAddlAmtWomen", null);
            if (objvo1.AppldInvestSubsidy != null)
                com.Parameters.AddWithValue("@AppldInvestSubsidy", objvo1.AppldInvestSubsidy);
            else
                com.Parameters.AddWithValue("@AppldInvestSubsidy", null);
            if (objvo1.AppldTotInvestSubsidy != null)
                com.Parameters.AddWithValue("@AppldTotInvestSubsidy", objvo1.AppldTotInvestSubsidy);
            else
                com.Parameters.AddWithValue("@AppldTotInvestSubsidy", null);

            if (objvo1.AvldSubsidyAmt != null)
                com.Parameters.AddWithValue("@AvldSubsidyAmt", objvo1.AvldSubsidyAmt);
            else
                com.Parameters.AddWithValue("@AvldSubsidyAmt", null);


            if (objvo1.AvldSubsidyScheme != null)
                com.Parameters.AddWithValue("@AvldSubsidyScheme", objvo1.AvldSubsidyScheme);
            else
                com.Parameters.AddWithValue("@AvldSubsidyScheme", null);


            if (objvo1.Created_by != null)
                com.Parameters.AddWithValue("@Created_by", objvo1.Created_by);
            else
                com.Parameters.AddWithValue("@Created_by", null);

            if (objvo1.IncentveID != null)
                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);
            else
                com.Parameters.AddWithValue("@IncentveID", null);

            if (objvo1.SchemeEligible != null)
                com.Parameters.AddWithValue("@SchemeEligible", objvo1.SchemeEligible);
            else
                com.Parameters.AddWithValue("@SchemeEligible", null);

            // added newly on 12.06.2017
            if (objvo1.SchemeEligible != null)
                com.Parameters.AddWithValue("@ISubsidySCSCT", objvo1.ISubsidySCSCT);
            else
                com.Parameters.AddWithValue("@ISubsidySCSCT", null);

            if (objvo1.SchemeEligible != null)
                com.Parameters.AddWithValue("@ISubsidyScheduledAreas", objvo1.ISubsidyScheduledAreas);
            else
                com.Parameters.AddWithValue("@ISubsidyScheduledAreas", null);
            if (objvo1.WomenSubsidy != null)
                com.Parameters.AddWithValue("@WomenSubsidy", objvo1.WomenSubsidy);
            else
                com.Parameters.AddWithValue("@WomenSubsidy", null);
            //if (objvo1.ScheduledAreasSubsidy != null)
            //    com.Parameters.AddWithValue("@ScheduledAreasSubsidy", objvo1.ScheduledAreasSubsidy);
            //else
            //    com.Parameters.AddWithValue("@ScheduledAreasSubsidy", null);

            if (Convert.ToString(Session["AddlInvSubsidy"]) != "")
                com.Parameters.AddWithValue("@addlsubsidy_MSME", Convert.ToString(Session["AddlInvSubsidy"]));
            else
                com.Parameters.AddWithValue("@addlsubsidy_MSME", null);

            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();

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
    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveCAFDetails.aspx?Previous=" + "P");
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "")
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "6", "Y", "");

            Response.Redirect("StampDutyAnnex.aspx?next=" + "N");
        }
        else
        {
           

            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave.Enabled = true;
        }

        //Response.Redirect("c.aspx?next=" + "N");

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("investmentsubsidy.aspx");
    }

    public void AssignValuestoVosFromcontrols()
    {
        try
        {

            objvoA.AppldInvestSubsidy = txtAppldInvestSubsidy.Text;
            objvoA.AppldTotInvestSubsidy = txtAppldTotInvestSubsidy.Text;
            objvoA.AvldSubsidyAmt = txtAvldSubsidyAmt.Text;
            objvoA.AvldSubsidyScheme = txtAvldSubsidyScheme.Text;
            objvoA.SchemeEligible = txtSchemeEligible.Text;
            objvoA.IncentveID = Session["EntprIncentive"].ToString();
            objvoA.Created_by = Session["uid"].ToString();
            
            if (trSC1.Visible == true)
            {
                objvoA.AppldAddlAmtWomen = txtAppldAddlAmtWomen.Text;
            }
            else objvoA.AppldAddlAmtWomen = null;
            // added on 12.06.2017
            if (txtISCSCT.Visible == true)
            {
                objvoA.ISubsidySCSCT = txtISCSCT.Text;
            }
            else objvoA.ISubsidySCSCT = null;
            if (txtScheduledAreas.Visible == true)
            {
                objvoA.ISubsidyScheduledAreas = txtScheduledAreas.Text;
                objvoA.WomenSubsidy = txtWomenSubsidy.Text;
            }
            else
            {
                objvoA.ISubsidyScheduledAreas = null;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");  commented on 07.02.2018 by chh
       string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fuDocuments1.HasFile)
        {
            if ((fuDocuments1.PostedFile != null) && (fuDocuments1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fuDocuments1.PostedFile.FileName);
                try
                {
                    string[] fileType = fuDocuments1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\62");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\6\\13");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()),"NA",
                            //62,
                                                      13,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName1.Text = fuDocuments1.FileName;
                        lblAttachedFileName1.Visible = true;

                        //lblUpload1.Text = fuDocuments1.FileName;
                        //lblUpload1.Visible = true;

                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
       string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];

        General t1 = new General();
        if (fuDocuments2.HasFile)
        {
            if ((fuDocuments2.PostedFile != null) && (fuDocuments2.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fuDocuments2.PostedFile.FileName);
                try
                {
                    string[] fileType = fuDocuments2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\63");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\6\\15");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuDocuments2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuDocuments2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()),"NA",
                            //  63,
                                                    15,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName2.Text = fuDocuments2.FileName;
                        lblAttachedFileName2.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void txtAppldInvestSubsidy_TextChanged(object sender, EventArgs e)
    {
        Totalinvestment();
    }

    void Totalinvestment()
    {
        DataSet dst = (DataSet)ViewState["dscaste"];
        if (dst.Tables.Count > 2)
        {
            if (dst.Tables[2].Rows.Count > 0)
            {

            }
        }

        double AppldTotInvestSubsidy = 0, AppldInvestSubsidy = 0, AppldAddlAmtWomen = 0, ISCSCT = 0, ScheduledAreas = 0,
            WomenSubsidy = 0;

        if (txtAppldInvestSubsidy.Text.Trim() != "" && txtAppldInvestSubsidy.Text.Trim() != "0")
        {
            AppldInvestSubsidy = Convert.ToDouble(txtAppldInvestSubsidy.Text.Trim());
        }
        if (txtAppldAddlAmtWomen.Text.Trim() != "" && txtAppldAddlAmtWomen.Text.Trim() != "0")
        {
            AppldAddlAmtWomen = Convert.ToDouble(txtAppldAddlAmtWomen.Text.Trim());
        }
        if (txtISCSCT.Text.Trim() != "" && txtISCSCT.Text.Trim() != "0")
        {
            ISCSCT = Convert.ToDouble(txtISCSCT.Text.Trim());
        }
        if (txtScheduledAreas.Text.Trim() != "" && txtScheduledAreas.Text.Trim() != "0")
        {
            ScheduledAreas = Convert.ToDouble(txtScheduledAreas.Text.Trim());
        }
        if (trMSME1Women.Visible == true && txtWomenSubsidy.Text.Trim() != "" && txtWomenSubsidy.Text.Trim() != "0")
        {
            WomenSubsidy = Convert.ToDouble(txtWomenSubsidy.Text.Trim());
        }
        AppldTotInvestSubsidy = AppldInvestSubsidy + AppldAddlAmtWomen + ISCSCT + ScheduledAreas+ WomenSubsidy;
        if (AppldTotInvestSubsidy == 0)     //added on 07.06.2018  HD : kurakulavi-004
            AppldTotInvestSubsidy = Convert.ToDouble(dst.Tables[2].Rows[0]["TotalInvestMentPer"].ToString()); //dscaste.Tables[2].Rows[0]["TotalInvestMentPer"].ToString()

        //txtAppldTotInvestSubsidy.Text = AppldTotInvestSubsidy.ToString();
    }
    protected void txtAppldAddlAmtWomen_TextChanged(object sender, EventArgs e)
    {
        Totalinvestment();
    }
    protected void txtISCSCT_TextChanged(object sender, EventArgs e)
    {
        Totalinvestment();
    }
    protected void txtScheduledAreas_TextChanged(object sender, EventArgs e)
    {
        Totalinvestment();
    }
    protected void btnUpload3_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
       string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fuDocuments3.HasFile)
        {
            if ((fuDocuments3.PostedFile != null) && (fuDocuments3.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fuDocuments3.PostedFile.FileName);
                try
                {
                    string[] fileType = fuDocuments3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\63");
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\9053");

                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\6\\9053");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuDocuments3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuDocuments3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                            //  63,
                                                    9053,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName3.Text = fuDocuments3.FileName;
                        lblAttachedFileName3.Visible = true;

                        lblUpload3.Text = fuDocuments3.FileName;
                        lblUpload3.Visible = false;

                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    public int UpdateAnnexureflag(string EnterperIncentiveID, string MstIncentiveId, string flag, string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_ANNEXUREFLA_INCENTIVE";

        if (EnterperIncentiveID == "" || EnterperIncentiveID == null)
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = EnterperIncentiveID.Trim();

        if (MstIncentiveId == "" || MstIncentiveId == null)
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

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
    public void ResetFormControl(Control parent)
    {
        try
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).ReadOnly = true;
                            break;

                        case "System.Web.UI.WebControls.DropDownList":

                            if (((DropDownList)c).Items.Count > 0)
                            {
                                ((DropDownList)c).Enabled = false;
                            }
                            break;
                        case "System.Web.UI.WebControls.FileUpload":
                            ((FileUpload)c).Enabled = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).Enabled = false;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}