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


public partial class UI_TSiPASS_frmCapitalSubsidy : System.Web.UI.Page
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
                    if(userid!= "329447" && userid != "45881" && userid!= "69494" && userid!= "346844" && userid != "351576" && userid != "314951")
                    {
                        Response.Redirect("Finalpage.aspx?next=" + "N");

                    }
                    dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                    string lblscheme = dscaste.Tables[0].Rows[0]["Scheme"].ToString();
                    string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                    string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                    string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();
                    string isAllWomen = dscaste.Tables[0].Rows[0]["isAllWomen"].ToString();



                    LBLCS.Visible = true;

                    LBLCS.Text = "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>CAPITAL SUBSIDY REIMBURSEMENT UNDER T IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    LBLCS.ForeColor = System.Drawing.Color.White;

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


                    BindFinancialYears_CAPITALSUBSDY("22", Session["EntprIncentive"].ToString());

                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 22);
                    if (drs.Length > 0)
                    {
                        DataSet dsnew = new DataSet();
                        dsnew = Gen.GetIncentivesISdata(IncentveID, "22");
                        // Filldata(dsnew);
                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("FinalPage.aspx?next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("APMCReimbursement.aspx?Previous=" + "P");
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
                    }
                }
            }
        }
        if (!IsPostBack)
        {
            FillDetails();

        }
    }
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());
        ds = GetCAPSUBSIDYIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnNext.Enabled = true;
            BtnSave.Enabled = false;
            if (ds.Tables[0].Rows[0]["FinancialYearNew"].ToString() != "" && ds.Tables[0].Rows[0]["FinancialYearNew"].ToString() != "" && ds.Tables[0].Rows[0]["FinancialYearNew"].ToString() != "--Select--")
            {
                ddlcapitalsubsidyfinyear.SelectedValue = ds.Tables[0].Rows[0]["FinancialYearNew"].ToString();
                ddlcapitalsubsidyfinyear.Enabled = false;
            }
            if (ds.Tables[0].Rows[0]["FIRSTORSECONDHALFYEAR"].ToString() != "" && ds.Tables[0].Rows[0]["FIRSTORSECONDHALFYEAR"].ToString() != "" && ds.Tables[0].Rows[0]["FIRSTORSECONDHALFYEAR"].ToString() != "--Select--")
            {
                ddlfirstorsecondhalfyear_CS.SelectedValue = ds.Tables[0].Rows[0]["FIRSTORSECONDHALFYEAR"].ToString();
                ddlfirstorsecondhalfyear_CS.Enabled = false;

            }
            if (ds.Tables[0].Rows[0]["INVESTMENT_FINYEAR"].ToString() != "" && ds.Tables[0].Rows[0]["INVESTMENT_FINYEAR"].ToString() != "" && ds.Tables[0].Rows[0]["INVESTMENT_FINYEAR"].ToString() != "--Select--")
            {
                txtinvestment_currentfinyear.Text = ds.Tables[0].Rows[0]["INVESTMENT_FINYEAR"].ToString();
                txtinvestment_currentfinyear.Enabled = false;

            }

        }
    }
    public DataSet GetCAPSUBSIDYIncentives(int incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETCAPITALSUBSIDYINC", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
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


    private void BindFinancialYears_CAPITALSUBSDY(string Count, string incentiveid)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        DataSet dsYears = new DataSet();
        dsYears = GetFinancialYearIncentives(Count, incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlcapitalsubsidyfinyear.DataSource = dsYears.Tables[0];
            ddlcapitalsubsidyfinyear.DataTextField = "FinancialYear";
            ddlcapitalsubsidyfinyear.DataValueField = "SlNo";
            ddlcapitalsubsidyfinyear.DataBind();
        }
        ddlcapitalsubsidyfinyear.Items.Insert(0, "--Select--");

    }
    public DataSet GetFinancialYearIncentives(string MSTINCID, string incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETFINANCIALYEARS_CAPITALSUBSIDY", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@MSTINCID", SqlDbType.VarChar).Value = MSTINCID;
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = incentiveid;
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

    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnNext.Enabled = true;
            BtnSave.Enabled = false;

            BtnSave.Enabled = false;
        }
        else
        {

            BtnSave.Enabled = true;


        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();

        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            if (save())
            {

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "22", "Y", "");
                string message = "alert('Capital Subsidy Reimbursement Details Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                BtnNext.Enabled = true;
                BtnSave.Enabled = false;
            }

        }

    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

            if (ddlcapitalsubsidyfinyear.SelectedValue == "0" || ddlcapitalsubsidyfinyear.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Financial Year \\n";
                slno = slno + 1;
            }
            if (ddlfirstorsecondhalfyear_CS.SelectedValue == "0" || ddlfirstorsecondhalfyear_CS.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select 1st or 2nd half year \\n";
                slno = slno + 1;
            }
            if (txtinvestment_currentfinyear.Text==""|| txtinvestment_currentfinyear.Text ==null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter investment for the Current Financial Year \\n";
                slno = slno + 1;
            }

        return ErrorMsg;
    }

    public bool save()
    {
        try
        {

                string valid = InsertIncentCAPSUBSIDY(ddlcapitalsubsidyfinyear.SelectedValue, ddlfirstorsecondhalfyear_CS.SelectedValue, txtinvestment_currentfinyear.Text, Session["uid"].ToString(), Session["EntprIncentive"].ToString());

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
    public string InsertIncentCAPSUBSIDY(string year, string FIRSTORSECONDHALFYEAR, string amount, string createdby, string IncentveID)
    {
        string valid = "";


        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_INSERT_CAPSUBSIDYDETAILS";

            if (year == null || year == "" || year == "--Select--")
                com.Parameters.AddWithValue("@year", null);
            else
                com.Parameters.AddWithValue("@year", year);

            if (FIRSTORSECONDHALFYEAR == null || FIRSTORSECONDHALFYEAR == "" || FIRSTORSECONDHALFYEAR == "--Select--")
                com.Parameters.AddWithValue("@FIRSTORSECONDHALFYEAR", null);
            else
                com.Parameters.AddWithValue("@FIRSTORSECONDHALFYEAR", FIRSTORSECONDHALFYEAR);


            if (amount == null || amount == "")
                com.Parameters.AddWithValue("@amount", null);
            else
                com.Parameters.AddWithValue("@amount", Convert.ToDecimal(amount));


            if (createdby == null || createdby == "")
                com.Parameters.AddWithValue("@createdby", null);
            else
                com.Parameters.AddWithValue("@createdby", createdby);

            if (IncentveID == null || IncentveID == "")
                com.Parameters.AddWithValue("@IncentveID", null);
            else
                com.Parameters.AddWithValue("@IncentveID", Convert.ToInt32(IncentveID));


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;

            con.OpenConnection();
            com.Connection = con.GetConnection;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //com.Dispose();
            con.CloseConnection();
        }
        return valid;
    }


    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("APMCReimbursement.aspx?Previous=" + "P");
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "22", "Y", "");

            Response.Redirect("Finalpage.aspx?next=" + "N");
        
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCapitalSubsidy.aspx");
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