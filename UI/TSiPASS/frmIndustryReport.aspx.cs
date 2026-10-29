using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class UI_TSiPASS_frmIndustryReport : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    string checkSno;
    string sno;
    General gen = new General();
    General Gen = new General();
    int Sno = 0;
    string rstages = "0";
    DataSet ds;
    DataTable dt;
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    DataSet dslist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dsd = new DataSet();
            dsd = Gen.GetDistrictsWithoutHYD();
            ddldistrict.DataSource = dsd.Tables[0];
            ddldistrict.DataValueField = "District_Id";
            ddldistrict.DataTextField = "District_Name";
            ddldistrict.DataBind();
            ddldistrict.Items.Insert(0, "--Select--");
            getnature();
            fillgrid();
            

        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        //BtnClear0_Click(sender, e);
    }
    //protected void GETBANKINDUSTRYDETAILS()
    //{
    //    DataSet dsnew = new DataSet();
    //    dsnew = ApplicantData(Session["uid"].ToString());

    //    if (dsnew.Tables[0].Rows.Count > 0)
    //    {
    //        grdDetails.DataSource = dsnew.Tables[0];
    //        grdDetails.DataBind();
    //        Failure.Visible = false;
    //    }

    //    if (dsnew.Tables[0].Rows.Count <= 0)
    //    {
    //        Failure.Visible = true;
    //        lblmsg0.Text = "No records found";
    //    }
    //}

    //public DataSet ApplicantData(string CREATED_BY)
    //{
    //    try
    //    {
    //        osqlConnection.Open();
    //        oSqlDataAdapter = new SqlDataAdapter("GETBANKINDUSTRYDETAILS", osqlConnection);
    //        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        if (CREATED_BY.Trim() == "" || CREATED_BY.Trim() == null)
    //        {
    //            oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
    //        }
    //        else
    //        {
    //            oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY.Trim();
    //        }



    //        oDataSet = new DataSet();
    //        oSqlDataAdapter.Fill(oDataSet);
    //        //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
    //        //Session["impSno"] = sno.ToString();
    //        osqlConnection.Close();
    //        //osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        osqlConnection.Close();
    //    }
    //    return oDataSet;
    //}

    public void gettYPEofSICK()
    {
        ddlType.Items.Clear();
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("SELECT", "0"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("Incipient Sick", "1"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("Sick", "2"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("Willful Defaulters", "3"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("TEV Study Done", "4"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("Restructuring under taken", "5"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("SARFAESI", "6"));
        ddlType.Items.Add(new System.Web.UI.WebControls.ListItem("Account Closed", "7"));



    }

    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //gettYPEofSICK();
            //tblappldetails.Visible = true;

            foreach (GridViewRow oldrow in grdDetails.Rows)
            {

                ((CheckBox)oldrow.FindControl("ChkApproval")).Checked = false;
                ((CheckBox)oldrow.FindControl("ChkApproval")).Enabled = true;

            }
            CheckBox rb = (CheckBox)sender;

            GridViewRow rows = (GridViewRow)rb.NamingContainer;

            bool CHK = ((CheckBox)rows.FindControl("ChkApproval")).Checked = true;
            if (CHK == true)
            {

                if (((CheckBox)rows.FindControl("ChkApproval")).Checked)
                {
                    ((CheckBox)rows.FindControl("ChkApproval")).Enabled = false;
                    tblappldetails.Visible = true;
                    gettYPEofSICK();
                    // string name = rows.Cells[0].Text;
                    //sno = rows.Cells[0].Text.ToString();
                    ViewState["sno"] = rows.Cells[0].Text.ToString();
                    txtUnitName.Text = rows.Cells[1].Text;
                    ddlintLineofActivity.SelectedItem.Text = rows.Cells[2].Text;
                    ddlProp_intDistrictid.SelectedItem.Text = rows.Cells[3].Text;
                    ddlProp_intMandalid.SelectedItem.Text = rows.Cells[4].Text;
                    txtcontact.Text = rows.Cells[5].Text;
                    txtemail.Text = rows.Cells[6].Text;
                    //ddlType.SelectedItem.Text = rows.Cells[7].Text;
                    ddlType.Items.Remove(ddlType.Items.FindByText(rows.Cells[7].Text));
                    txtDate.Text = rows.Cells[8].Text;
                    txtLoanAmount.Text = rows.Cells[9].Text;
                    txtLoanDate.Text = rows.Cells[10].Text;

                    txtUnitName.Enabled = false;
                    ddlintLineofActivity.Enabled = false;
                    ddlProp_intDistrictid.Enabled = false;
                    ddlProp_intMandalid.Enabled = false;
                    txtcontact.Enabled = false;
                    txtemail.Enabled = false;
                    txtLoanAmount.Enabled = false;
                    txtLoanDate.Enabled = false;
                }

            }
            else
            {
                tblappldetails.Visible = false;
            }
        }
        catch(Exception EX)
        {

        }
        finally
        {

        }

    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblmsg0.Text = "";
        Failure.Visible = false;


        fillgrid();
    }
    public void fillgrid()
    {
        DataSet dsnew = new DataSet();

        //if (txtFromDate.Text == "" || txtFromDate.Text == null)
        //{
        //    lblmsg0.Text = "Please Enter From Date <br/>";
        //    valid = 1;
        //}
        //if (txtTodate.Text == "" || txtTodate.Text == null)
        //{
        //    lblmsg0.Text += "Please Enter To Date <br/>";
        //    valid = 1;
        //}
        if (valid == 0)
        {
            //string[] FromDt11 = txtFromDate.Text.Split('/');
            //FromdateforDB = FromDt11[2].ToString() + "/" + FromDt11[1].ToString() + "/" + FromDt11[0].ToString();
            //string[] ToDt11 = txtTodate.Text.Split('/');
            //TodateforDB = ToDt11[2].ToString() + "/" + ToDt11[1].ToString() + "/" + ToDt11[0].ToString();
            //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        //rstages = 0;//Request.QueryString[0].ToString().Trim();
        dsnew = GetAppealApplications(Session["DistrictID"].ToString(),rstages.ToString().Trim(),TxtnameofUnit.Text.Trim());
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            //lblMsg.Text = "";
            //Label1.Text = "No Records Found ";

            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    public DataSet GetAppealApplications(string districtid, string stageid, string nameofunit)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@intDistrictid",SqlDbType.VarChar),
                new SqlParameter("@intStageid",SqlDbType.VarChar),
                new SqlParameter("@Nameofunit",SqlDbType.VarChar),
               
           };
        pp[0].Value = districtid;
        pp[1].Value = stageid;
        pp[2].Value = nameofunit;


        Dsnew = gen.GenericFillDs("GET_APPLICATIONS_LIST", pp);
        return Dsnew;
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        fillgrid();

    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txtDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select   date');", true);
            //    return;
            //}
            //General.BANKINDUSTRYSTATUS objbankstatus = new General.BANKINDUSTRYSTATUS();
            //objbankstatus.NAME_OF_THE_UNIT = txtUnitName.Text.Trim();
            //objbankstatus.LINE_OF_ACTIVITY = ddlintLineofActivity.SelectedValue.ToString().Trim();
            //objbankstatus.DISTRICT_ID = ddlProp_intDistrictid.SelectedValue.ToString().Trim();
            //objbankstatus.MANDAL_ID = ddlProp_intMandalid.SelectedValue.ToString().Trim();
            //objbankstatus.CONTACT_NO = txtcontact.Text.Trim();
            //objbankstatus.GMAIL_ID = txtemail.Text.Trim();
            //objbankstatus.TYPE = ddlType.SelectedValue.ToString().Trim();
            //if (txtDate.Text == "" || txtDate.Text == null)
            //{
            //    objbankstatus.SICKDATE = null;
            //}
            //else
            //{
            //    string[] ConvertedDt11 = txtDate.Text.Split('/');
            //    objbankstatus.SICKDATE = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[0].ToString() + "/" + ConvertedDt11[1].ToString();
            //}
            //objbankstatus.CREATED_BY = Session["uid"].ToString();
            //objbankstatus.SICKDATE = txtDate.Text.Trim();
            //General gen = new General();
            //int i = gen.UpdateSickStatus(objbankstatus);
            //if (i == 1)
            //{
            //    success.Visible = true;
            //    Failure.Visible = false;
            //    lblmsg.Text = "RECORD INSERTED SUCCESSFULLY";
            //    //ClearAllControls();
            //    // BindDistricts();
            //    //BindBankNames();
            //    //Bindbranchname(ddl_banknames.SelectedValue.ToString().ToUpper());
            //}
            //else
            //{
            //    Failure.Visible = true;
            //    success.Visible = false;
            //    lblmsg0.Text = "RECORD NOT INSERTED";
            //}
            //CheckBox ocheckBox = (CheckBox)sender;

            //GridViewRow row = (GridViewRow)ocheckBox.NamingContainer;
            //GridViewRow row = (GridViewRow)(((Control)sender).NamingContainer);

            //int Rowindex = row.RowIndex;

            int insertCheck = 0;
            Failure.Visible = false;
            osqlConnection.Open();
            SqlCommand oSqlCommand = new SqlCommand("SICK_STATUS");
            oSqlCommand.Connection = osqlConnection;
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.CommandText = "SICK_STATUS";
            oSqlCommand.Parameters.AddWithValue("@DATE", txtDate.Text);
            oSqlCommand.Parameters.AddWithValue("@TYPE", ddlType.SelectedValue);
            oSqlCommand.Parameters.AddWithValue("@SNO", ViewState["sno"].ToString());
            oSqlCommand.Parameters.AddWithValue("@CREATED_BY", Session["uid"].ToString());
            oSqlCommand.Parameters.AddWithValue("@REMARKS",txtremarks.Text);
            oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);

            oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oSqlCommand.ExecuteNonQuery();
            insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;
            if (insertCheck == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Approved Successfully!";
                string message = "alert('Approved Successfully!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else if (insertCheck == 2)
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg0.Text = "Details not updated.Please try again!";
                string message = "alert('Details not updated.Please try again!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
        finally
        {
           // gettYPEofSICK();
        }
    }

    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            }
            else
            {
                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
                    ddlProp_intMandalid.DataTextField = "Manda_lName";
                    ddlProp_intMandalid.DataBind();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }


    }
    public void GET_LINE_OF_ACTIVE()
    {
        try
        {
            //DataTable dtLineOfActive = gen.GetTypeofSector();

            //if (dtLineOfActive != null && dtLineOfActive.Rows.Count > 0)
            //{
            //    ddlintLineofActivity.DataSource = dtLineOfActive;
            //    ddlintLineofActivity.DataTextField = "SectorName";
            //    ddlintLineofActivity.DataValueField = "SectorName";
            //    ddlintLineofActivity.DataBind();
            //    ddlintLineofActivity.Items.Insert(0, "--Select--");
            //}
            //else
            //{
            //    ddlintLineofActivity.ClearSelection();
            //    ddlintLineofActivity.Items.Insert(0, "--Select--");
            //}

            DataSet dsd = new DataSet();
            //ddlFinYear.Items.Clear();
            dsd = gen.GetTypeofSector();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = dsd.Tables[0];
                ddlintLineofActivity.DataValueField = "SectorName";
                ddlintLineofActivity.DataTextField = "SectorName";
                ddlintLineofActivity.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlFinYear);
                //}
            }


            ddlintLineofActivity.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void ddlnatureofaccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlnatureofaccount.SelectedValue == "4")
            {
                trotheraccounts.Visible = true;
            }
            else
            {
                trotheraccounts.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void getnature()
    {
        DataSet dsnew = new DataSet();

        dsnew = GetNatureofAccounts();
        ddlnatureofaccount.DataSource = dsnew.Tables[0];
        ddlnatureofaccount.DataTextField = "TYPEName";
        ddlnatureofaccount.DataValueField = "TYPEId";
        ddlnatureofaccount.DataBind();
        ddlnatureofaccount.Items.Insert(0, "--Select--");
    }
    public DataSet GetNatureofAccounts()
    {
        DataSet Dsnew = new DataSet();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_NATUREOFACCOUNTS", con.GetConnection);
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
}