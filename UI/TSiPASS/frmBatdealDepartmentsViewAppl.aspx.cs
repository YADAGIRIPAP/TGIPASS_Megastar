using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmBatdealDepartmentsViewAppl : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            GetDetails();
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
        }
    }
    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            rstages = Request.QueryString[0].ToString().Trim();
            DataSet dsn = new DataSet();
            //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
            //return;
            dsn = GetShowDepartmentFilesbatdealer(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
            if (dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }   
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
            {
            }
            else
            {
                // grdDetails.Columns[10].Visible = false;
                //grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[12].Visible = false;
            }
        }
        else
        {
            //grdDetails.Columns[10].Visible = false;
            //grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[12].Visible = false;
        }
    }
   
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();
    }
    void clear()
    {
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
    }
    void FillDetails()
    {
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    void getcounties()
    {
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    void getPayams()
    {
    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
        }
    }
    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {
    }
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void GetNewRectoInsertdr()
    {
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h1 = (HyperLink)e.Row.Cells[4].Controls[0];
                HyperLink h2 = (HyperLink)e.Row.Cells[5].Controls[0];
                HyperLink h3 = (HyperLink)e.Row.Cells[6].Controls[0];
                h1.Target = "_blank";
                h1.NavigateUrl = "Batdealerprint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
                h2.Target = "_blank";
                h2.NavigateUrl = "frmViewAttachmentDetailsBatdealer.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
                h3.Target = "_blank";
                h3.NavigateUrl = "FrmqueryresponsestatusBatdealer.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
                DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
                TextBox txtPromotor = (TextBox)e.Row.Cells[11].FindControl("txtPromotor");
                Label Label378 = (Label)e.Row.Cells[11].FindControl("Label378");
                Label Label379 = (Label)e.Row.Cells[11].FindControl("Label379");
                Label LabelDiscription = (Label)e.Row.Cells[11].FindControl("LabelDiscription");
                TextBox txtAmount = (TextBox)e.Row.Cells[11].FindControl("txtAmount");
                HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
                HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo");
                hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
                HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo0");
                hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
                HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo1");
                hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
                HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo2");
                hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();
                HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo3");
                DataSet dsquery = new DataSet();
                dsquery =GetQueryRaisedRENOneTime(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value);
                if (dsquery.Tables[0].Rows.Count > 0)
                {
                    ddlStatus.Items.RemoveAt(1);
                }
                //HyperLink h4 = (HyperLink)e.Row.Cells[17].Controls[0];
                //h4.Target = "_blank";
                //if (e.Row.Cells[18].Text.Trim() == "Y")
                //{
                //    e.Row.Cells[18].Text = "Please process this application in Concerned Department portal";
                //    e.Row.Cells[18].Font.Bold = true;
                //}
                //else
                //{
                //    e.Row.Cells[18].Text = "Please process this application in TS-iPASS portal";
                //}
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        Label Label378 = (Label)row.FindControl("Label378");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        Label Label379 = (Label)row.FindControl("Label379");
        Label LabelDiscription = (Label)row.FindControl("LabelDiscription");

        if (ddlStatus.SelectedValue.ToString() == "5")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = false;
            txtAmount.Visible = false;
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;

            LabelDiscription.Visible = true;

            LabelDiscription.Text = "Please Mention on which act or rule,you are Rejecting?";

            Label378.Text = "Reason For Rejection";

            Label379.Visible = false;
            txtAmount.Visible = false;
        }
        else
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            LabelDiscription.Visible = false;
        }
        // if(ddlStatus.)
        //if()
    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        HyperLink h1 = (HyperLink)row.FindControl("h1");
        HyperLink h2 = (HyperLink)row.FindControl("h2");
        HyperLink h3 = (HyperLink)row.FindControl("h3");
        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");
        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }
        int result = 0;
        result = insertDepartmentProcessbatdealer(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());
        if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
        {
         
            if (txtPromotor.Text == "")
            {
                lblmsg.Text = "Please Enter Query Description";
            }
            else
            {
                int i = insertQueryResponsedataBatdealer(hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(),hdfGroundedNo1.Value, hdfGroundedNo0.Value);
                DataSet dsMail = new DataSet();
                //dsMail = GetShowEmailidandMobileNumberBattery(hdfGroundedNo.Value);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ":<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                //    //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                if (i > 0)
                {
                    GetDetails();
                }
            }
        }

       
      else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            int j = UpdateDeptapprovalBatdealer(hdfGroundedNo.Value, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP(),"");
            //int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", hdfGroundedNo1.Value);
            DataSet dsMail = new DataSet();
            dsMail = GetShowEmailidandMobileNumberBattery(hdfGroundedNo.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            int j = UpdateDeptapprovalBatdealer(hdfGroundedNo.Value,"Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value,getclientIP(), txtPromotor.Text);
           // int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", hdfGroundedNo1.Value);
            DataSet dsMail = new DataSet();
            dsMail = GetShowEmailidandMobileNumberBattery(hdfGroundedNo.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has Rejected your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        if (result > 0)
        {
            ddlStatus.SelectedIndex = 0;
            txtPromotor.Text = "";
            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Registered";
        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";
        }
        GetDetails();
        //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
        //{
        //    Failure.Visible = true;
        //    success.Visible = false;
        //    lblmsg.Text = "Please Select Status";
        //}
    }

    public DataSet GetShowEmailidandMobileNumberBattery(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumberBattery", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();



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

    public int UpdateDeptapprovalBatdealer(string BatdealerID, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress,string remarks)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBatdealer";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (BatdealerID.Trim() == "" || BatdealerID.Trim() == null)
            com.Parameters.Add("@BatdealerID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BatdealerID", SqlDbType.VarChar).Value = BatdealerID.Trim();

 
        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (remarks.Trim() == "" || remarks.Trim() == null)
            com.Parameters.Add("@txtpromoter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@txtpromoter", SqlDbType.VarChar).Value = remarks.Trim();



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

    public int insertQueryResponsedataBatdealer(string batdealerID, string QueryDescription, string QueryStatus, string Created_by,string intApprovalid,string intDeptid)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertQueriesDetailsBatdealer]";

        if (batdealerID.Trim() == "" || batdealerID.Trim() == null)
            com.Parameters.Add("@batdealerID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@batdealerID", SqlDbType.VarChar).Value = batdealerID.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();


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

    public int insertDepartmentProcessbatdealer(string BatdealerID, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcessbatdealer";

        if (BatdealerID == "" || BatdealerID == null)
            com.Parameters.Add("@BatbealerID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BatbealerID", SqlDbType.VarChar).Value = BatdealerID.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

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

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    public DataSet GetShowDepartmentFilesbatdealer(string Deptid, string intStageid, string intDistrictid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowDepartmentFilesbatdealer", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();


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

    public DataSet GetQueryRaisedRENOneTime(string intCFEEnterpid, string intDeptid, string intApprovalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetQueryRaisedBaterrybyOnetime", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();


            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.ToString();

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