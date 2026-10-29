using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class UI_TSiPASS_frmincentiveformtransportduty : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DB.DB con = new DB.DB();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    PCBClass objPCB = new PCBClass();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;



    protected void Page_Load(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;


        if (!IsPostBack)
        {
            lblwood.Text = "<center>" + "ANNEXURE: XI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>CLAIMING REIMBURSEMENT OF TRANSPORT SUBSIDY </center></u></b></span>" + "<center>UNDER TELANGANA ELECTRONICS POLOCY 2016</center>";

            if (Session["incentivedata"] != null)
            {


                string userid = Session["uid"].ToString();
                string IncentveID = Session["EntprIncentive"].ToString();
              

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 20);  //  Reimbursement of Transport Duty
                if (drs.Length > 0)
                {

                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                       // Response.Redirect("FinalPage.aspx?next=" + "N");
                        Response.Redirect("APMCReimbursement.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmIncentiveform_WOOD.aspx?Previous=" + "P");
                    }
                }

                BindFinancialYears(ddlfinancialyeartransportduty, "10", IncentveID);
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

                dtMyTableCertificate = createtablecrtificate1();
                Session["CertificateTb2"] = dtMyTableCertificate;
            }
        }
        if (!IsPostBack)
        {
            FillDetails();

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected DataTable createtablecrtificate1()
    {
        dtMyTablepr = new DataTable("CertificateTb2");

        dtMyTablepr.Columns.Add("Partorcomponentorgoodsname", typeof(string));
        dtMyTablepr.Columns.Add("InstalledCapacity", typeof(string));
        dtMyTablepr.Columns.Add("unit", typeof(string));
        dtMyTablepr.Columns.Add("units_others", typeof(string));
        dtMyTablepr.Columns.Add("Created_by", typeof(string));




        return dtMyTablepr;
    }
    protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquantityin.SelectedValue.ToString() == "Others")
        {
            txtunit.Visible = true;
            ddlquantityin.Visible = true;
        }
        else
        {
            txtunit.Visible = false;
            ddlquantityin.Visible = true;
        }

    }
    private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
    {
       

        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives(Count, incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = dsYears.Tables[0];
            ddl.DataTextField = "FinancialYear";
            ddl.DataValueField = "SlNo";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, "--Select--");

    }


    private void FillDetails()
    {
        DataSet ds = new DataSet();
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());
        ds = TRANSPORYDUTYIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
 BtnSave1.Enabled = false;
            hdntransportdutyid.Value = ds.Tables[0].Rows[0]["Id"].ToString();
            if(ds.Tables[0].Rows[0]["THIRDPARTYAGENCY"].ToString()=="Y")
            {
                chkthirdpartylogistics.Checked = true;
                trtransportagency.Visible = true;
                txtnameofthirdpartyagency.Text = ds.Tables[0].Rows[0]["Nameofthirdpartagency"].ToString();

            }
            if (ds.Tables[0].Rows[0]["TRAIN"].ToString() == "Y")
            {
                chktrain.Checked = true;
            }
            if (ds.Tables[0].Rows[0]["OWNTRANSPORTATION"].ToString() == "Y")
            {
                chkowntransport.Checked = true;
            }
            if (ds.Tables[0].Rows[0]["WAYBILL"].ToString() == "Y")
            {
                chkwaybill.Checked = true;
            }
            if (ds.Tables[0].Rows[0]["FUELBILL"].ToString() == "Y")
            {
                chkfuelbill.Checked = true;
            }
            if (ds.Tables[0].Rows[0]["FREIGHTCHARGES"].ToString() == "Y")
            {
                chkfreightcharges.Checked = true;
            }
            txttotalamountofexpincurred.Text = ds.Tables[0].Rows[0]["Totalamountofexpenditure"].ToString();
            txtamountofsubsidyclaimed.Text = ds.Tables[0].Rows[0]["Amountofsubsidyclaimed"].ToString();
            txtalreadysanctionedamount.Text = ds.Tables[0].Rows[0]["Alreadysanctionedamount"].ToString();


            ddlfinancialyeartransportduty.SelectedValue = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
            ddlFin1stOr2ndHalfyear.SelectedValue = ds.Tables[0].Rows[0]["Fin1stOr2ndHalfYear"].ToString();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2;

                foreach (DataRow dr in table.Rows)
                {
                    string AttcahmentId = dr["AttachmentId"].ToString();

                    sen2 = dr["FilePath"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (AttcahmentId == "301")
                    {
                        hypauditorsstatement.NavigateUrl = sen;
                        hypauditorsstatement.Text = dr["FileNm"].ToString();
                        lblauditorsstatement.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "302")
                    {
                        hypbills.NavigateUrl = sen;
                        hypbills.Text = dr["FileNm"].ToString();
                        lblbills.Text = dr["FileNm"].ToString();
                    }


                }

            }
            if(ds.Tables.Count>2&& ds.Tables[2].Rows.Count>0)
            {
                gvInstalledCapNew.Visible = true;
                gvInstalledCapNew.DataSource = ds.Tables[2];
                gvInstalledCapNew.DataBind();
            }
        }

    }
    public DataSet TRANSPORYDUTYIncentives(int incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TRANSPORTDUTYInentives_INC", con.GetConnection);
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
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveform_WOOD.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        int start = 0;


        if (hypauditorsstatement.Text == string.Empty || hypbills.Text == string.Empty)
        {
            start = 1;
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave1.Enabled = true;
        }
        else
        {
            if (start == 0)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "20", "Y", "");
                Response.Redirect("APMCReimbursement.aspx?next=" + "N");
            }
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
string errormsg = ValidateControls();
if (errormsg.Trim().TrimStart() != "")
{
    string message = "alert('" + errormsg + "')";
    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    return;
}
        string thirdparty;
        string train;
            string owntransport;
        string waybill;
        string fuelbill;
        string freightcharges;

        string result;
        try
        {
 if (gvInstalledCap.Visible == false)
 {
     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Details of parts/components/Goods transported and click on Add button');", true);
     return;
 }
            if(chkthirdpartylogistics.Checked)
            {
                thirdparty = "Y";
            }
            else
            {
                thirdparty = "";
            }
            if (chktrain.Checked)
            {
                train = "Y";
            }
            else
            {
                train = "";
            }
            if (chkowntransport.Checked)
            {
                owntransport = "Y";
            }
            else
            {
                owntransport = "";
            }
            if (chkwaybill.Checked)
            {
                waybill = "Y";
            }
            else
            {
                waybill = "";
            }
            if (chkfuelbill.Checked)
            {
                fuelbill = "Y";
            }
            else
            {
                fuelbill = "";
            }
            if (chkfreightcharges.Checked)
            {
                freightcharges = "Y";
            }
            else
            {
                freightcharges = "";
            }
            List<Componentdetails> lstcomponentdetails = new List<Componentdetails>();

            foreach (GridViewRow RowInd in gvInstalledCap.Rows)
            {
                Componentdetails voscompdetails = new Componentdetails();
                voscompdetails.slno = "0";
                voscompdetails.Partorcomponentorgoodsname = RowInd.Cells[1].Text.Trim().ToString();
                voscompdetails.InstalledCapacity = RowInd.Cells[2].Text.Trim().ToString();
                voscompdetails.Unit = RowInd.Cells[3].Text.Trim().ToString();
                voscompdetails.units_others = RowInd.Cells[4].Text.Trim().ToString();
                voscompdetails.Created_by = Session["uid"].ToString();
                voscompdetails.IncentiveId = Session["IncentveID"].ToString();
                lstcomponentdetails.Add(voscompdetails);
            }

           
       result = InsertTransportAnnexureDetails(Session["EntprIncentive"].ToString(), "20",thirdparty,train,owntransport,  txtnameofthirdpartyagency.Text,
                waybill,fuelbill,freightcharges,txttotalamountofexpincurred.Text, txtamountofsubsidyclaimed.Text,
                txtalreadysanctionedamount.Text,  Session["uid"].ToString(), hdntransportdutyid.Value,
                 ddlfinancialyeartransportduty.SelectedValue, ddlFin1stOr2ndHalfyear.SelectedValue, lstcomponentdetails);
            if(result!=""&&result!=null&&result!="0")
            {
                 string message = "alert('Transport Subsidy Annexture Submitted Successfully')";
 ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

 BtnSave1.Enabled = false;
 BtnDelete.Enabled = true;

            }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public class Componentdetails
    {
        public string slno { get; set; }
        public string Partorcomponentorgoodsname { get; set; }
        public string InstalledCapacity { get; set; }
        public string Unit { get; set; }
        public string units_others { get; set; }
        public string Created_by { get; set; }
        public string IncentiveId { get; set; }

        internal void Add(Componentdetails voscompdetails)
        {
            throw new NotImplementedException();
        }
    }

    public string InsertTransportAnnexureDetails(string Incentiveid, string MasterIncentiveid,
 string THIRDPARTYAGENCY, string TRAIN, string OWNTRANSPORTATION, string Nameofthirdpartagency,
string WAYBILL, string FUELBILL,string FREIGHTCHARGES, string Totalamountofexpenditure, string Amountofsubsidyclaimed,
string Alreadysanctionedamount, string createdby, string transportid, string FinancialYear, string Fin1stOr2ndHalfYear, List<Componentdetails> lstcomponentdetails)
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
            com.CommandText = "SP_INSERTWTRANSPORTDETAILS_INC";

            com.Transaction = transaction;
            com.Connection = connection;


            //com = new SqlcomtaAcompter("SP_INSERTWTRANSPORTDETAILS_INC", osqlConnection);
            //com.SelectCommand.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = Incentiveid.ToString();
            com.Parameters.Add("@MasterIncentiveid", SqlDbType.VarChar).Value = MasterIncentiveid.ToString();
            if (THIRDPARTYAGENCY.Trim() == "" || THIRDPARTYAGENCY.Trim() == null || THIRDPARTYAGENCY.Trim() == "--Select--")
            {
                com.Parameters.Add("@THIRDPARTYAGENCY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@THIRDPARTYAGENCY", SqlDbType.VarChar).Value = THIRDPARTYAGENCY.ToString();
            
            if (TRAIN.Trim() == "" || TRAIN.Trim() == null || TRAIN.Trim() == "--Select--")
            {
                com.Parameters.Add("@TRAIN", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@TRAIN", SqlDbType.VarChar).Value = TRAIN.ToString();

            if (OWNTRANSPORTATION.Trim() == "" || OWNTRANSPORTATION.Trim() == null || OWNTRANSPORTATION.Trim() == "--Select--")
            {
                com.Parameters.Add("@OWNTRANSPORTATION", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@OWNTRANSPORTATION", SqlDbType.VarChar).Value = OWNTRANSPORTATION.ToString();

            if (Nameofthirdpartagency.Trim() == "" || Nameofthirdpartagency.Trim() == null || Nameofthirdpartagency.Trim() == "--Select--")
            {
                com.Parameters.Add("@Nameofthirdpartagency", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@Nameofthirdpartagency", SqlDbType.VarChar).Value = Nameofthirdpartagency.ToString();

            if (WAYBILL.Trim() == "" || WAYBILL.Trim() == null || WAYBILL.Trim() == "--Select--")
            {
                com.Parameters.Add("@WAYBILL", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@WAYBILL", SqlDbType.VarChar).Value = WAYBILL.ToString();

            if (FUELBILL.Trim() == "" || FUELBILL.Trim() == null || FUELBILL.Trim() == "--Select--")
            {
                com.Parameters.Add("@FUELBILL", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@FUELBILL", SqlDbType.VarChar).Value = FUELBILL.ToString();

            if (FREIGHTCHARGES.Trim() == "" || FREIGHTCHARGES.Trim() == null || FREIGHTCHARGES.Trim() == "--Select--")
            {
                com.Parameters.Add("@FREIGHTCHARGES", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@FREIGHTCHARGES", SqlDbType.VarChar).Value = FREIGHTCHARGES.ToString();

            if (Totalamountofexpenditure.Trim() == "" || Totalamountofexpenditure.Trim() == null || Totalamountofexpenditure.Trim() == "--Select--")
            {
                com.Parameters.Add("@Totalamountofexpenditure", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@Totalamountofexpenditure", SqlDbType.VarChar).Value = Totalamountofexpenditure.ToString();


            if (Amountofsubsidyclaimed.Trim() == "" || Amountofsubsidyclaimed.Trim() == null || Amountofsubsidyclaimed.Trim() == "--Select--")
            {
                com.Parameters.Add("@Amountofsubsidyclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@Amountofsubsidyclaimed", SqlDbType.VarChar).Value = Amountofsubsidyclaimed.ToString();
            
            if (Alreadysanctionedamount.Trim() == "" || Alreadysanctionedamount.Trim() == null || Alreadysanctionedamount.Trim() == "--Select--")
            {
                com.Parameters.Add("@Alreadysanctionedamount", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@Alreadysanctionedamount", SqlDbType.VarChar).Value = Alreadysanctionedamount.ToString();

          

            if (createdby.Trim() == "" || createdby.Trim() == null || createdby.Trim() == "--Select--")
            {
                com.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();
            if (transportid.Trim() == "" || transportid.Trim() == null || transportid.Trim() == "--Select--")
            {
                com.Parameters.Add("@transportid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@transportid", SqlDbType.VarChar).Value = transportid.ToString();


            if (FinancialYear.Trim() == "" || FinancialYear.Trim() == null || FinancialYear.Trim() == "--Select--")
            {
                com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = FinancialYear.ToString();


            if (Fin1stOr2ndHalfYear.Trim() == "" || Fin1stOr2ndHalfYear.Trim() == null || Fin1stOr2ndHalfYear.Trim() == "--Select--")
            {
                com.Parameters.Add("@Fin1stOr2ndHalfYear", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                com.Parameters.Add("@Fin1stOr2ndHalfYear", SqlDbType.VarChar).Value = Fin1stOr2ndHalfYear.ToString();

            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();

            if (valid != "0")
            {
                foreach (Componentdetails lstcomp in lstcomponentdetails)
                {
                    SqlCommand COMNew = new SqlCommand();
                    COMNew.CommandType = CommandType.StoredProcedure;
                    COMNew.CommandText = "USP_INS_COMPONENTDETAILS_TRANSPORTDUTY";
                    COMNew.Transaction = transaction;
                    COMNew.Connection = connection;
                    COMNew.Parameters.AddWithValue("@slno", lstcomp.slno);
                    COMNew.Parameters.AddWithValue("@Partorcomponentorgoodsname", lstcomp.Partorcomponentorgoodsname);
                    COMNew.Parameters.AddWithValue("@InstalledCapacity", lstcomp.InstalledCapacity);
                    COMNew.Parameters.AddWithValue("@Unit", lstcomp.Unit);
                    COMNew.Parameters.AddWithValue("@units_others", lstcomp.units_others);
                    COMNew.Parameters.AddWithValue("@IncentiveId", lstcomp.IncentiveId);
                    COMNew.Parameters.AddWithValue("@Created_by", lstcomp.Created_by);
                    COMNew.ExecuteNonQuery();
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

    protected void btnauditorsstatement_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (fupauditorsstatement.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupauditorsstatement.PostedFile != null) && (fupauditorsstatement.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(fupauditorsstatement.PostedFile.FileName);
                try
                {

                    string[] fileType = fupauditorsstatement.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\2\\301");
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupauditorsstatement.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "301", sFileName, serverpath, CrtdUser);

                        hypauditorsstatement.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
                    }
                    else
                    {
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
        }
    }

    protected void btnbill_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (fupbills.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupbills.PostedFile != null) && (fupbills.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(fupbills.PostedFile.FileName);
                try
                {

                    string[] fileType = fupbills.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\2\\302");
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupbills.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "302", sFileName, serverpath, CrtdUser);

                        hypbills.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
                    }
                    else
                    {
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
        }
    }
 public string ValidateControls()
 {
     int slno = 1;
     string ErrorMsg = "";

     if (chkthirdpartylogistics.Checked == false && chktrain.Checked == false && chkowntransport.Checked == false)
     {
         ErrorMsg = ErrorMsg + slno + ". Please Select Means Of Transportation\\n";
         slno = slno + 1;
     }
     if (chkthirdpartylogistics.Checked == true)
     {
         if (txtnameofthirdpartyagency.Text == "" || txtnameofthirdpartyagency.Text == null)
         {
             ErrorMsg = ErrorMsg + slno + ". Please enter name of the third party transport agent \\n";
             slno = slno + 1;
         }
     }
     if (chkwaybill.Checked == false && chkfuelbill.Checked == false && chkfreightcharges.Checked == false)
     {
         ErrorMsg = ErrorMsg + slno + ". Please Select Nature of Expenditure Incurred(waybill/Fuel Bill/Freight Charges)\\n";
         slno = slno + 1;
     }
     
     if (txttotalamountofexpincurred.Text == ""|| txttotalamountofexpincurred.Text == null)
     {
         ErrorMsg = ErrorMsg + slno + ". Please enter Total Amount of Expenditure Incurred \\n";
         slno = slno + 1;
     }

     if (txtamountofsubsidyclaimed.Text == "" || txtamountofsubsidyclaimed.Text == null)
     {
         ErrorMsg = ErrorMsg + slno + ". Please enter Amount of Subsidy being claimed(INR) \\n";
         slno = slno + 1;
     }
     if (txtalreadysanctionedamount.Text == "" || txtalreadysanctionedamount.Text == null)
     {
         ErrorMsg = ErrorMsg + slno + ". Please enter Total amount of subsidy already sanctioned till date for Transport Subsidy(INR) \\n";
         slno = slno + 1;
     }

     
     if (ddlfinancialyeartransportduty.SelectedValue == "0" || ddlfinancialyeartransportduty.SelectedValue == "--Select--")
     {
         ErrorMsg = ErrorMsg + slno + ". Please select Financial year \\n";
         slno = slno + 1;
     }
     if (ddlFin1stOr2ndHalfyear.SelectedValue == "" || ddlFin1stOr2ndHalfyear.SelectedValue == "--Select--")
     {
         ErrorMsg = ErrorMsg + slno + ". Please select first or second half year \\n";
         slno = slno + 1;
     }

     return ErrorMsg;
 }
    protected void btnInstalledcap_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            if (txtLOActivity.Text == "" || txtLOActivity.Text == null)
            {
                lblmsg0.Text = "Line Of Activity Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtLOActivity.Focus();
                valid = 1;
            }
            if (txtinstalledccap.Text == "" || txtinstalledccap.Text == null)
            {
                lblmsg0.Text = "Installed Capacity Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtinstalledccap.Focus();
                valid = 1;
            }
           if (ddlquantityin.SelectedValue == "--Select--"|| ddlquantityin.SelectedValue =="0"|| ddlquantityin.SelectedValue ==null|| ddlquantityin.SelectedValue =="")
{
    lblmsg0.Text = "Units Cannot be blank" + "<br/>";
    Failure.Visible = true;
    txtinstalledccap.Focus();
    valid = 1;
}
            string strunit_OTHERS = "";
            if(ddlquantityin.SelectedValue == "Others")
            {
                if (txtunit.Text == "" || txtunit.Text == null)
                {
                    lblmsg0.Text = "Unit Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtunit.Focus();
                    valid = 1;
                }
                else
                {
                    strunit_OTHERS = txtunit.Text;
                }
            }
            else
            {
                strunit_OTHERS = null;
            }
      
            if (valid == 0)
            {
                if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    AddDataToTableCeertificate(txtLOActivity.Text, txtinstalledccap.Text,ddlquantityin.SelectedValue, strunit_OTHERS,  Session["uid"].ToString(),  (DataTable)Session["CertificateTb2"]);

                    this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvInstalledCap.DataBind();
                    ClearTxt();
                }
               
                gvInstalledCap.Visible = true;
                lblmsg0.Text = "";
                Failure.Visible = false;

                txtLOActivity.Text = "";
                txtinstalledccap.Text = "";
                ddlquantityin.ClearSelection();
                txtunit.Text = "";

            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected void gvInstalledCap_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
            //{
                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvInstalledCap.DataBind();
            //}
            //else
            //{
            //    if (hdfFlagID.Value.Trim() != "")
            //    {
            //        try
            //        {
            //            string traineetradesnames = gvInstalledCap.DataKeys[e.RowIndex].Values["Slno"].ToString();
            //            DataSet dsna = new DataSet();
            //            int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

            //            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
            //            this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            //            this.gvInstalledCap.DataBind();
            //        }
            //        catch (Exception eee)
            //        {
            //            throw eee;
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvInstalledCap_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void ClearTxt()
    {
        txtLOActivity.Text = "";
        txtunit.Text = "";
        txtinstalledccap.Text = "";

    }

    private void AddDataToTableCeertificate( string Partorcomponentorgoodsname, 
        string InstalledCapacity, string Unit, string units_others,string CREATEDBY,  DataTable myTable)
    {
        try
        {

            DataRow Row;
            Row = myTable.NewRow();

            dtMyTablepr = new DataTable("CertificateTb2");

       
            Row["Partorcomponentorgoodsname"] = Partorcomponentorgoodsname;
            Row["InstalledCapacity"] = InstalledCapacity;
            Row["Unit"] = Unit;
            Row["units_others"] = units_others;
            Row["Created_by"] = CREATEDBY;

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }


    protected void chkthirdpartylogistics_CheckedChanged(object sender, EventArgs e)
    {
        if(chkthirdpartylogistics.Checked==true)
        {
            trtransportagency.Visible = true;
        }
        else
        {
            trtransportagency.Visible = false;
        }
    }
}