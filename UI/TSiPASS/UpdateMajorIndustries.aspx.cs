using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UI_TSiPASS_UpdateMajorIndustries : System.Web.UI.Page
{
    DataSet dsnew = new DataSet();
    DataSet dsnew1 = new DataSet();
    DB.DB con = new DB.DB();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {
            if (Session["Role_Code"].ToString() == "GM")
            {
                if (!IsPostBack)
                {
                    bindmajorunits();
                    Getlist_Click(sender, e);
                    Bindofficer();
                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }


    }
    protected void bindmajorunits()
    {
        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("sp_GetMajorIndustriesList", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = Session["DistrictID"].ToString();
        da.Fill(dsnew);
        con.CloseConnection();
        ddlIndustries.DataSource = dsnew;
        ddlIndustries.DataTextField = "UnitName";
        ddlIndustries.DataValueField = "UID_No";
        //ddlIndustries.Items.Add("--Select--");       
        ddlIndustries.DataBind();
        ddlIndustries.Items.Insert(0, new ListItem { Text = "--Select--", Value = "0" });

    }

    protected void ddlIndustries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIndustries.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text = "Please select Industry";
            Failure.Visible = true;
        }
        else
        {
            Failure.Visible = false;
            txtUIDno.Text = ddlIndustries.SelectedValue;
            txtUIDno.Enabled = false;
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_GetMajorIndustriesList", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = Session["DistrictID"].ToString();
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = ddlIndustries.SelectedValue;
            da.Fill(dsnew);
            con.CloseConnection();
            //ddlIndustries.DataSource = dsnew;
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {

                if (dsnew.Tables[0].Rows[0]["MobileNumber"].ToString() != "" &&
                    dsnew.Tables[0].Rows[0]["MobileNumber"].ToString() != null)
                {
                    txtmobile.Text = dsnew.Tables[0].Rows[0]["MobileNumber"].ToString();
                }
                if (dsnew.Tables[0].Rows[0]["Email"].ToString() != "" &&
                    dsnew.Tables[0].Rows[0]["Email"].ToString() != null)
                {
                    txtEmail.Text = dsnew.Tables[0].Rows[0]["Email"].ToString();
                }
            }
            else
            {


            }
        }

    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (ddlIndustries.Text != "--Select--" && txtUIDno.Text != "" && txtEmail.Text != "" && txtmobile.Text != "" &&
            ddlOfficerName.SelectedItem.Text != "" && txtofcrDesgn.Text != "" && txtofcrMobile.Text != "" && txtofcremail.Text != "")
        {
            try
            {
                string errorMessage = "";

                string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address
                string to = txtEmail.Text;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);
                mail.Subject = "Nodal Officer Details";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "Dear Sir/madam, <br><br> The following Officer is alloted as Nodal Officer for your Industry. For any further queries, You may contact the officer. "
                    + "<br>Nodal Officer Details: <br>Name: " + ddlOfficerName.SelectedItem.Text + " <br>Designation: " + txtofcrDesgn.Text + " <br> Mobile No.: " + txtofcrMobile.Text + " <br>Email.: " + txtofcremail.Text + "<br> <br>Regards,<br>Commissionerate of Industries,<br>TS-iPASS Cell.";
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                //client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");
                client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");
                client.Port = 587; // Gmail works on this port lrefskmlxnoowqtc
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true; //Gmail works on Server Secured Layer tsipass@2016
                try
                {
                    client.Send(mail);

                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    //HttpContext.Current.Response.Write(errorMessage);
                }
                if (errorMessage == "")
                {
                    con.OpenConnection();
                    SqlCommand cmd = new SqlCommand("InsertNodalOfcrallotedtoMajorIndstry", con.GetConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NameofUnit", SqlDbType.VarChar).Value = ddlIndustries.SelectedItem.Text;
                    cmd.Parameters.Add("@UIDNo", SqlDbType.VarChar).Value = txtUIDno.Text;
                    cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = txtmobile.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@NodalOfficerName", SqlDbType.VarChar).Value = ddlOfficerName.SelectedItem.Text;
                    cmd.Parameters.Add("@NodalOfficerDesignation", SqlDbType.VarChar).Value = txtofcrDesgn.Text;
                    cmd.Parameters.Add("@NodalOfficerMobileNo", SqlDbType.VarChar).Value = txtofcrMobile.Text;
                    cmd.Parameters.Add("@NodalOfficerEmail", SqlDbType.VarChar).Value = txtofcremail.Text;
                    cmd.Parameters.Add("@createdby", SqlDbType.Int).Value = Convert.ToUInt32(Session["uid"].ToString());
                    cmd.Parameters.Add("@DistrictId", SqlDbType.Int).Value = Convert.ToUInt32(Session["DistrictID"].ToString());
                    cmd.Parameters.Add("@Nodalofficerid", SqlDbType.Int).Value =ddlOfficerName.SelectedValue;
                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int value = Convert.ToInt32(cmd.Parameters["@Result"].Value);

                    if (value > 0)
                    {
                        Getlist_Click(sender, e);

                    }
                    BtnSave.Enabled = false;
                    lblmsg.Text = "The Nodal Officer Details has been send to Industry Email...";
                    success.Visible = true;
                }
                else
                {
                    lblmsg0.Text = "Email sending failed....";
                    Failure.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            lblmsg0.Text = "Please Fill all details";
            Failure.Visible = true;
        }
    }
    protected void Getlist_Click(object sender, EventArgs e)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter da1 = new SqlDataAdapter("sp_GetMajorIndustriesallotedList", con.GetConnection);
            da1.SelectCommand.CommandType = CommandType.StoredProcedure;
            da1.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = Session["DistrictID"].ToString();
            da1.Fill(dsnew1);
            con.CloseConnection();
            if (dsnew1.Tables.Count > 0)
            {
                grdNodalOfficers.DataSource = dsnew1;
                grdNodalOfficers.DataBind();
                lblForGrid.Visible = true;
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }

    protected void ddlOfficerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlOfficerName.SelectedValue != null && ddlOfficerName.SelectedValue != "0")
            {
                DataSet dsApplicationType = new DataSet();
                dsApplicationType = GetDepartmentINcentiveNew(Session["DistrictID"].ToString(), ddlOfficerName.SelectedValue);
                if (dsApplicationType != null && dsApplicationType.Tables.Count > 0 && dsApplicationType.Tables[0].Rows.Count > 0)
                {
                    if (dsApplicationType.Tables[0].Rows[0]["Designation"].ToString() != "" &&
                        dsApplicationType.Tables[0].Rows[0]["Designation"].ToString() != null)
                    {
                        txtofcrDesgn.Text = dsApplicationType.Tables[0].Rows[0]["Designation"].ToString();
                    }
                    if (dsApplicationType.Tables[0].Rows[0]["mobilenumber"].ToString() != "" &&
                        dsApplicationType.Tables[0].Rows[0]["mobilenumber"].ToString() != null)
                    {
                        txtofcrMobile.Text = dsApplicationType.Tables[0].Rows[0]["mobilenumber"].ToString();
                    }
                    if (dsApplicationType.Tables[0].Rows[0]["emailid"].ToString() != "" &&
                        dsApplicationType.Tables[0].Rows[0]["emailid"].ToString() != null)
                    {
                        txtofcremail.Text = dsApplicationType.Tables[0].Rows[0]["emailid"].ToString();
                    }
                }
                else
                {


                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void Bindofficer()
    {
        try
        {
            ddlOfficerName.Items.Clear();
            DataSet dsApplicationType = new DataSet();
            dsApplicationType = GetDepartmentINcentiveNew(Session["DistrictID"].ToString(), null);
            if (dsApplicationType != null && dsApplicationType.Tables.Count > 0 && dsApplicationType.Tables[0].Rows.Count > 0)
            {
                ddlOfficerName.DataSource = dsApplicationType.Tables[0];
                ddlOfficerName.DataTextField = "Dept_Name";
                ddlOfficerName.DataValueField = "Dept_Id";
                ddlOfficerName.DataBind();
                if (dsApplicationType.Tables[0].Rows.Count > 1)
                    AddSelect(ddlOfficerName);

            }
            else
            {

                AddSelect(ddlOfficerName);
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
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public DataSet GetDepartmentINcentiveNew(string Districtid, string usercode)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetDepartmentIncentive_NEW_11REPORTS]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Dept_ID", SqlDbType.VarChar).Value = Districtid;


            da.SelectCommand.Parameters.Add("@usercode", SqlDbType.VarChar).Value = usercode;




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