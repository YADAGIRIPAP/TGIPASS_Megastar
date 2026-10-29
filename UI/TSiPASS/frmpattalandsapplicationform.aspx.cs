using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf.hyphenation;
//using Org.BouncyCastle.Asn1.X509;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
//using static TSIPASSPropertiesModel;

public partial class UI_TSiPASS_frmpattalandsapplicationform : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    Double NumberTotal = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Response objRes = new Response();
    static DataTable dtTable;
    static DataTable dtMyTable;//
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    List<VillageAddDetails> lstVillages = new List<VillageAddDetails>();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    public class VillageAddDetails
    {
        public string VillageID
        {
            get;
            set;
        }
        public string Village
        {
            get;
            set;
        }
        public string SurveyNo
        {
            get;
            set;
        }
        public string Extent
        {
            get;
            set;
        }
        public string ID
        {
            get;
            set;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
           
            Response.Redirect("~/Index.aspx");
        }
        if (!Page.IsPostBack)
        {
            Page.Form.Enctype = "multipart/form-data";
        }

        if (!IsPostBack)
        {
            getMineralNames();
            getdistricts();
            //ddldistrict.SelectedValue = (Session["DistrictID"].ToString());
            //ddldistrict.Enabled = false;
            //getMandals();
            if (!IsPostBack)
            {
                dtTable = createTableAddVillages();
                Session["AddedVillagesTable"] = dtTable;
            }

            //if already applied to retrieve date 
            if (Session["uid"].ToString() != "" || Session["uid"].ToString() != "0")
            {
                DataSet dsdatenew = new DataSet();
                dsdatenew = RetrivePattadarLandData(Session["uid"].ToString());
                if (dsdatenew.Tables[0].Rows.Count > 0)
                {
                    txtpattadarname.Text = dsdatenew.Tables[0].Rows[0]["PATTADARNAME"].ToString();
                    txtdharaninumber.Text = dsdatenew.Tables[0].Rows[0]["DHARANINUMBER"].ToString();
                    //txtmineralname.Text = dsdatenew.Tables[0].Rows[0]["MINERALNAME"].ToString();
                    //txtextentinhectare.Text = dsdatenew.Tables[0].Rows[0]["EXTENTINHECTARE"].ToString();
                    //txtsurveyno.Text = dsdatenew.Tables[0].Rows[0]["SURVEYNO"].ToString();
                                 
                    HDNAPPLICATIONID.Value = dsdatenew.Tables[0].Rows[0]["ID"].ToString().Trim();
                    if (dsdatenew.Tables[0].Rows[0]["MINERALNAME"].ToString() != "")
                    {
                        ddlMineral.SelectedItem.Text = dsdatenew.Tables[0].Rows[0]["MINERALNAME"].ToString();
                        //ddlMineral.Text.FindByValue(dsdatenew.Tables[0].Rows[0]["NameoftheMineral"].ToString().Trim());
                        ddlMineral.Enabled = true;
                    }
                    ddlMineral_SelectedIndexChanged(sender, e);
                    if (dsdatenew.Tables[0].Rows[0]["DISTRICT"].ToString() != "")
                    {
                        ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(dsdatenew.Tables[0].Rows[0]["DISTRICT"].ToString().Trim()).Value;
                        ddldistrict.Enabled = true;
                    }
                    ddldistrict_SelectedIndexChanged(sender, e);

                    if (dsdatenew.Tables[0].Rows[0]["MANDAL"].ToString() != "")
                    {
                        ddlmandal.SelectedValue = ddlmandal.Items.FindByValue(dsdatenew.Tables[0].Rows[0]["MANDAL"].ToString().Trim()).Value;
                        ddlmandal.Enabled = true;
                    }
                    ddlmandal_SelectedIndexChanged(sender, e);
                    //if (dsdatenew.Tables[0].Rows[0]["VILLAGE"].ToString() != "")
                    //{
                    //    ddlvillage.SelectedValue = ddlvillage.Items.FindByValue(dsdatenew.Tables[0].Rows[0]["VILLAGE"].ToString().Trim()).Value;
                    //    ddlvillage.Enabled = true;
                    //}
                    if (dsdatenew != null && dsdatenew.Tables.Count > 1 && dsdatenew.Tables[1].Rows.Count > 0)
                    {
                        gvVillageAdd.DataSource = dsdatenew.Tables[1];
                        gvVillageAdd.DataBind();
                    }
                }
            }
        }


    }

    protected void getMineralNames()
    {
        ddlMineral.Items.Clear();
        string strConnectionString = ConfigurationManager.ConnectionStrings["tsipassskils"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnectionString);

        SqlDataAdapter da = new SqlDataAdapter("select *  from  MineralNames", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlMineral.DataSource = ds.Tables[0];
            ddlMineral.DataValueField = "MineralID";
            ddlMineral.DataTextField = "MineralName";
            ddlMineral.DataBind();
            ddlMineral.Items.Insert(0, "--Select--");
        }
        else
        {
            ddlMineral.Items.Insert(0, "--select--");
        }
    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
    }
    public DataSet GetDistricts()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetDistricts_ADMG", con.GetConnection);
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

    protected void getMandals()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetMandals(ddldistrict.SelectedValue.ToString());
        ddlmandal.DataSource = dsnew.Tables[0];
        ddlmandal.DataTextField = "Manda_lName";
        ddlmandal.DataValueField = "Mandal_Id";
        ddlmandal.DataBind();
        ddlmandal.Items.Insert(0, "--Select--");
    }

    void getVillages()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetVillages(ddlmandal.SelectedValue.ToString());
        ddlvillage.DataSource = dsnew.Tables[0];
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "Village_Id";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, "--Select--");
    }
    protected DataTable createTableAddVillages()
    {
        dtMyTable = new DataTable("AddedVillagesTable");
        dtMyTable.Columns.Add("VillageID", typeof(string));
        dtMyTable.Columns.Add("Village", typeof(string));
        dtMyTable.Columns.Add("SurveyNo", typeof(string));
        dtMyTable.Columns.Add("Extent", typeof(string));
        dtMyTable.Columns.Add("ID", typeof(string));

        return dtMyTable;
    }
    protected void BtnVlgAdd_Click(object sender, EventArgs e)
    {
        gvVillageAdd.Visible = true;
        try
        {
            if (ddlvillage.SelectedIndex != 0 && TxtSurveyNo.Text != "" && TxtPartExtent.Text != "")
            {
                AddDataToVillages(ddlvillage.SelectedValue, ddlvillage.SelectedItem.Text, TxtSurveyNo.Text, TxtPartExtent.Text,
                (DataTable)Session["AddedVillagesTable"]);
                gvVillageAdd.DataSource = ((DataTable)Session["AddedVillagesTable"]).DefaultView;
                gvVillageAdd.DataBind();
            }
            else
            {
                if (ddlvillage.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Vilage')", true);
                }
                if (TxtSurveyNo.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Survey No ')", true);
                }
                if (TxtPartExtent.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Extent')", true);
                }
            }
        }
        
        catch
        {

        }
        gvVillageAdd.Visible = true;
    }

    private void AddDataToVillages(string villageID, string Village, string SurveyNo, string Partextent, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("AddedVillagesTable");
            Row["VillageID"] = villageID;
            Row["Village"] = Village;
            Row["SurveyNo"] = SurveyNo;
            Row["Extent"] = Partextent;
            Row["ID"] = "";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {

        }
    }

    protected void gvVillageAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ((DataTable)Session["AddedVillagesTable"]).Rows.RemoveAt(e.RowIndex);
            this.gvVillageAdd.DataSource = ((DataTable)Session["AddedVillagesTable"]).DefaultView;
            this.gvVillageAdd.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
        }
        finally
        {

        }
    }
    protected void gvVillageAdd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Double NumberTotal1 = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Extent"));
            NumberTotal = NumberTotal1 + NumberTotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Total Extent";
            e.Row.Cells[3].Text = NumberTotal.ToString();
            HdfldTotalExtent.Value = NumberTotal.ToString();
        }
       // TxtTotalExtent.Text = NumberTotal.ToString();
    }


    protected void ddlMineral_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmandal.SelectedValue.ToString() != "--Select--")
        {
            getVillages();
        }
        else
        {
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, "--Select--");
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        txtpattadarname.Text = "";
        txtdharaninumber.Text = "";
        ddlMineral.SelectedIndex = 0;
        ddlmandal.SelectedIndex = 0;
        ddlvillage.SelectedIndex = 0;
        TxtSurveyNo.Text = "";
        TxtPartExtent.Text = "";
        gvVillageAdd.Visible = false;
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        if (ddlMineral.SelectedIndex == 0 || ddlmandal.SelectedIndex == 0 || gvVillageAdd.Rows.Count == 0)
        {
            if (txtpattadarname.Text == "")
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Pattadar Name";
                txtpattadarname.Focus();
                return;
            }
            if (txtdharaninumber.Text == "")
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Pattadar Pass Book Number";
                txtdharaninumber.Focus();

                return;
            }
            if (ddlMineral.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Mineral')", true);



            }
            if (ddldistrict.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select District')", true);

                Failure.Visible = true;
                lblmsg0.Text = "Please Select District";
                ddldistrict.Focus();


            }
            if (ddlmandal.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Mandal')", true);

            }
            if (gvVillageAdd.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Village Survey Nos Details and Click Add Button </font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        else
        {
            lstVillages.Clear();
            foreach (GridViewRow gvrow in gvVillageAdd.Rows)
            {

                VillageAddDetails Vad = new VillageAddDetails();
                int rowIndex = gvrow.RowIndex;
                Vad.VillageID = ((Label)gvrow.FindControl("lblVillageid")).Text.ToString();
                Vad.Village = gvVillageAdd.Rows[rowIndex].Cells[1].Text;
                Vad.SurveyNo = gvVillageAdd.Rows[rowIndex].Cells[2].Text;
                Vad.Extent = gvVillageAdd.Rows[rowIndex].Cells[3].Text;
                Vad.ID = ((Label)gvrow.FindControl("lblid")).Text.ToString();

                lstVillages.Add(Vad);
            }

            DataSet ds = new DataSet();
            ds = Insertpattadardata(txtpattadarname.Text.ToString().Trim(),
                txtdharaninumber.Text.ToString().Trim(), ddlMineral.SelectedItem.Text,
                HdfldTotalExtent.Value.ToString().Trim(), ddldistrict.SelectedValue,
                ddlmandal.SelectedValue, Session["uid"].ToString().Trim(),
                ddldistrict.SelectedItem.Text, ddlmandal.SelectedItem.Text);

            HDNAPPLICATIONID.Value = ds.Tables[0].Rows[0]["ID"].ToString().Trim();
            int result = 0;
            result = InsertVillagesData(HDNAPPLICATIONID.Value, Session["uid"].ToString().Trim(), ddldistrict.SelectedValue,
                ddldistrict.SelectedItem.Text, ddlmandal.SelectedValue, ddlmandal.SelectedItem.Text, lstVillages);
            if (ds.Tables[0].Rows.Count > 0 && result > 0)
            {
                //HDNAPPLICATIONID.Value= ds.Tables[0].Rows[0]["ID"].ToString().Trim();
                lblmsg.Text = "<font color='GREEN'> Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                BtnSave1.Enabled = false;
                BtnClear.Enabled = false;
                trDoc.Visible = true;
                trAtchment.Visible = true;
                tratchmentsave.Visible = true;
                trsuccess.Visible = true;
            }
            
        }
    }

public DataSet Insertpattadardata( string PATTADARNAME, string DHARANINUMBER, string MINERALNAME, 
    string EXTENTINHECTARE, string DISTRICT, string MANDAL, string CREATED_BY,string Districtname, string Mandalname)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_PATTADARLAND", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
    
            if (PATTADARNAME.ToString().Trim() == "" || PATTADARNAME.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@PATTADARNAME", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@PATTADARNAME", SqlDbType.VarChar).Value = PATTADARNAME.Trim();

            if (DHARANINUMBER.ToString().Trim() == "" || DHARANINUMBER.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@DHARANINUMBER", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@DHARANINUMBER", SqlDbType.VarChar).Value = DHARANINUMBER.Trim();

            if (MINERALNAME.ToString().Trim() == "" || MINERALNAME.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@MINERALNAME", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@MINERALNAME", SqlDbType.VarChar).Value = MINERALNAME.Trim();

            if (EXTENTINHECTARE.ToString().Trim() == "" || EXTENTINHECTARE.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@EXTENTINHECTARE", SqlDbType.Decimal).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@EXTENTINHECTARE", SqlDbType.Decimal).Value =Convert.ToDecimal( EXTENTINHECTARE.Trim());
           
           
            if (DISTRICT.ToString().Trim() == "" || DISTRICT.ToString().Trim() == null|| DISTRICT== "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DISTRICT.Trim();

            if (MANDAL.ToString().Trim() == "" || MANDAL.ToString().Trim() == null || MANDAL == "--Select--")
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = MANDAL.Trim();


            if (CREATED_BY.ToString().Trim() == "" || CREATED_BY.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY.Trim();

            if (Districtname.ToString().Trim() == "" || Districtname.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@Districtname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@Districtname", SqlDbType.VarChar).Value = Districtname.Trim();

            if (Mandalname.ToString().Trim() == "" || Mandalname.ToString().Trim() == null)
                da.SelectCommand.Parameters.Add("@Mandalname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@Mandalname", SqlDbType.VarChar).Value = Mandalname.Trim();

            da.Fill(ds);
            return ds;

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
    public int InsertVillagesData(string ID, string Created_by, string DistrictID, string District,
        string MandalID, string Mandal, List<VillageAddDetails> lstVillages)
    {

        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = null;
        //List<VillageAddDetails> lstVillages = new List<VillageAddDetails>();
        foreach (VillageAddDetails Vad in lstVillages)
        {
            cmd = new SqlCommand("USP_INSERT_PattadarVillages", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Convert.ToString(ID));
            cmd.Parameters.AddWithValue("@Created_by", Convert.ToString(Created_by));
            cmd.Parameters.AddWithValue("@DistrictID", Convert.ToString(DistrictID));
            cmd.Parameters.AddWithValue("@District", Convert.ToString(District));
            cmd.Parameters.AddWithValue("@MandalID", Convert.ToString(MandalID));
            cmd.Parameters.AddWithValue("@Mandal", Convert.ToString(Mandal));

            cmd.Parameters.AddWithValue("@VillageID", Convert.ToString(Vad.VillageID));
            cmd.Parameters.AddWithValue("@Village", Convert.ToString(Vad.Village));
            cmd.Parameters.AddWithValue("@SurveyNo", Convert.ToString(Vad.SurveyNo));
            cmd.Parameters.AddWithValue("@Extent", Convert.ToString(Vad.Extent));
            //cmd.Parameters.AddWithValue("@ID", Convert.ToString(Vad.ID));

            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            valid = (Int32)cmd.Parameters["@Valid"].Value;

        }
        if (valid == 1)
        {
            return 1;
        }
        else
            return 0;

    }
    protected void BTNDGPSMAP_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\PATTADARATTACHMENTS");

            if ((FUPDGPSMAP.PostedFile != null) && (FUPDGPSMAP.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FUPDGPSMAP.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPDGPSMAP.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" )
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, HDNAPPLICATIONID.Value + "\\DGPSMAP");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FUPDGPSMAP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FUPDGPSMAP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = InsertImagedata(HDNAPPLICATIONID.Value, HDNAPPLICATIONID.Value,
                            fileType[i - 1].ToUpper(), newPath, sFileName, "DGPS MAP",
                            Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            Label13.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HYPDGPSMAP.Text = FUPDGPSMAP.FileName;
                            LBLDGPSMAP.Text = FUPDGPSMAP.FileName;
                            AtchSuccess.Visible = true;
                            AtchFailure.Visible = false;
                        }
                        else
                        {
                            Label14.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            AtchSuccess.Visible = false;
                            AtchFailure.Visible = true;
                        }

                    }
                    else
                    {
                        Label14.Text = "<font color='red'>Upload PDF files only..!</font>";
                        AtchSuccess.Visible = false;
                        AtchFailure.Visible = true;
                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        catch (Exception ex)
        {
            Label14.Text = ex.Message;
            AtchFailure.Visible = true;
            // DeleteFile(newPath + "\\" + sFileName);
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
    public int InsertImagedata(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName,
        string FileDescription, string Created_by, string Created_dt, string Modified_by, string Modified_dt)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertImage_Pattadar", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }


            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }



            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            //if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            //}
            //else
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            //}

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }

            if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            }


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (Modified_dt.Trim() == "" || Modified_dt.Trim() == null || Modified_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = Modified_dt.Trim();
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (HYPDGPSMAP.Text == "" || HYPDGPSMAP.Text == null)
        {
            Label14.Text = "Please upload DGPS map and click on upload button";
            AtchFailure.Visible = true;
        }
        else
        {
            try
            {
                int valid = UpdatePattadarCompletion(Session["uid"].ToString(), HDNAPPLICATIONID.Value);
                int village = UpdatePattadarCompletionwithVillages(Session["uid"].ToString(), HDNAPPLICATIONID.Value);
                if (valid == 1 && village == 1)
                {
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Completed Successfully');", true);
                    Label13.Text = "<font color='green'>Application Submitted Successfully..!</font>";
                    success.Visible = false;
                    AtchSuccess.Visible = true;
                    Button3.Enabled = false;
                    Button4.Enabled = false;
                    AtchFailure.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Label14.Text = ex.Message;
                AtchFailure.Visible = true;
            }
        }
    }
    public int UpdatePattadarCompletion(string createdby, string ID)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        connection.Open();
        int valid = 0;
        SqlTransaction trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_PATTADAR_APPSTATUS]", connection);
        command.CommandType = CommandType.StoredProcedure;

        try
        {
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Created_by", createdby);

            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }
    public int UpdatePattadarCompletionwithVillages(string createdby, string ID)/*, string appldate)*/
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("USP_UPDATE_Pattadar_Villages", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (createdby.Trim() == "" || createdby.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(createdby.Trim());
            }
            if (ID.Trim() == "" || ID.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = Int32.Parse(ID.Trim());
            }
            //    if (appldate.Trim() == "" || appldate.Trim() == null)
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@appldate", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@appldate", SqlDbType.DateTime).Value = appldate.Trim();
            //}

            myDataAdapter.SelectCommand.Parameters.Add("@VALID", SqlDbType.Int, 500);
            myDataAdapter.SelectCommand.Parameters["@VALID"].Direction = ParameterDirection.Output;
            //string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
            //SqlConnection connection = new SqlConnection(str);
            //connection.Open();
            ////int valid = 0;
            //SqlTransaction trans = connection.BeginTransaction();
            //SqlCommand command = new SqlCommand("USP_UPDATE_ADMandG_APPSTATUS", connection);
            //command.CommandType = CommandType.StoredProcedure;
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

    public DataSet RetrivePattadarLandData(string CREATED_BY)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_Retrieve_PattadarLandData", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (CREATED_BY.Trim() == "" || CREATED_BY.Trim() == null)
                da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY.ToString();

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
    protected void btnclear_Click(object sender, EventArgs e)
    {
        HYPDGPSMAP.Visible = false;
    }

    //protected void Btnnext_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string AdharCardno = "";
    //        if (txtadhar1.Text.Trim() != "" && txtadhar2.Text.Trim() != "" && txtadhar3.Text.Trim() != "")
    //        {
    //            AdharCardno = txtadhar1.Text.Trim() + txtadhar2.Text.Trim() + txtadhar3.Text.Trim();
    //        }
    //        DataSet ds = new DataSet();
    //        ds = Insertpattadardata(txtpattadarname.Text.ToString().Trim(), txtrelation.Text.ToString().Trim(),
    //            txtdharaninumber.Text.ToString().Trim(), txtmineralname.Text.ToString().Trim(),
    //            txtextentinhectare.Text.ToString().Trim(), txtsurveyno.Text.ToString().Trim(),
    //            ddldistrict.SelectedValue, ddlmandal.SelectedValue, ddlvillage.SelectedValue,
    //            txtpannumber.Text.ToString().Trim(), AdharCardno.ToString().Trim(),
    //            txtemail.Text.ToString().Trim(), txtgst.Text.ToString().Trim(), txtmobilenumber.Text.ToString().Trim(),
    //            Session["uid"].ToString().Trim(), ddldistrict.SelectedItem.Text, ddlmandal.SelectedItem.Text,
    //        ddlvillage.SelectedItem.Text);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HDNAPPLICATIONID.Value = ds.Tables[0].Rows[0]["ID"].ToString().Trim();
    //            lblmsg.Text = "<font color='GREEN'> Details Added Successfully..!</font>";
    //            success.Visible = true;
    //            Failure.Visible = false;
    //            Response.Redirect("PATTADARATTACHMENTS.aspx?intApplicationId=" + HDNAPPLICATIONID.Value);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //    finally
    //    {

    //    }
    //    return;

    //}
}