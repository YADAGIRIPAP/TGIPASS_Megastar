using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using Image = System.Drawing.Image;

public partial class UI_TSiPASS_PMEGP_SUCCESS_PRINT_PAGE : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    byte imageId1; byte imageId2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PmegpID"] != null)
            {
                string PmegpID = Request.QueryString["PmegpID"];
                Pmegp_ID.Text = PmegpID;

            }
        }

        if (!IsPostBack)
        {
            int PmegpID = Convert.ToInt32(Request.QueryString["PmegpID"]);

            string filePath1 = GetImageFilePathFromDatabase(PmegpID, 1);
            string filePath2 = GetImageFilePathFromDatabase(PmegpID, 2);

            if (File.Exists(filePath1))
            {
                byte[] image1Data = File.ReadAllBytes(filePath1);
                string base64String = Convert.ToBase64String(image1Data);
                Image1.ImageUrl = "data:image/jpeg;base64," + base64String;
            }

            if (File.Exists(filePath2))
            {
                byte[] image2Data = File.ReadAllBytes(filePath2);
                string base64String = Convert.ToBase64String(image2Data);
                Image2.ImageUrl = "data:image/jpeg;base64," + base64String;
            }
        }

        DataSet ds1 = new DataSet();
        {
            SqlParameter[] pp = new SqlParameter[]
             {
                  new SqlParameter("@PmegpID", SqlDbType.VarChar)
             };

            pp[0].Value = Pmegp_ID.Text;
            ds1 = gen.GenericFillDs("USP_GET_PMEGPSUCCESSSTROIES", pp);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds1.Tables[0].Rows[0];
                Applicantname.Text = row["ApplicantName"].ToString();
                fatherName.Text = row["FatherorSpouseName"].ToString();
                Caste.Text = row["caste"].ToString();
                Age.Text = row["Age"].ToString();
                EducationQualification.Text = row["Educationalqualifiaction"].ToString();
                SpecialCategory.Text = row["SpecialCategory"].ToString();
                HNo.Text = row["HNO"].ToString();
                Street.Text = row["Street"].ToString();
                VillageWard.Text = row["VillageWard"].ToString();
                Mandalmunicipality.Text = row["Mandalmunicipality"].ToString();
                District.Text = row["District"].ToString();
                AreaorRegion.Text = row["AreaorRegion"].ToString();
                Aadharnumber.Text = row["Aadharnumber"].ToString();
                Pannumber.Text = row["Pannumber"].ToString();
                Udayamregisternumber.Text = row["Udayamregisternumber"].ToString();
                Rationcradnumber.Text = row["Rationcradnumber"].ToString();
                Contactnumber.Text = row["Contactnumber"].ToString();
                Emailid.Text = row["Emailid"].ToString();
                PMEGP_ID_TSIPASS.Text = row["PMEGP_ID_TSIPASS"].ToString();
                EDPcertifiacte.Text = row["EDPcertifiacte"].ToString();
                Anyotherprograms.Text = row["Anyotherprograms"].ToString();
                Unitname.Text = row["Unitname"].ToString();
                Lineofactivity.Text = row["Lineofactivity"].ToString();
                productname.Text = row["productname"].ToString();
                unitsofproduction.Text = row["unitsofproduction"].ToString();
                Dateofcommencementproduction.Text = ((DateTime)row["Dateofcommencementproduction"]).ToString("dd/MM/yyyy");
                Employement.Text = row["Employement"].ToString();
                Investment.Text = row["Investment"].ToString();
                Benificarycontribution.Text = row["Benificarycontribution"].ToString();
                Bankloan.Text = row["Bankloan"].ToString();
                //production.Text = row["production"].ToString();
                Subsidyclaim.Text = row["Subsidyclaim"].ToString();
                Mmadjustments.Text = row["Mmadjustments"].ToString();
                Annualsales.Text = row["Annualsales"].ToString();
                Annualprofit.Text = row["Annualprofit"].ToString();
                Loanrepaymentcompleted.Text = row["Loanrepaymentcompleted"].ToString();
                Physicalvericationdate.Text = ((DateTime)row["Physicalvericationdate"]).ToString("dd/MM/yyyy");
                B_Assetvalue.Text = row["B_Assetvalue"].ToString();
                A_Assetvalue.Text = row["A_Assetvalue"].ToString();
                B_House.Text = row["B_House"].ToString();
                A_House.Text = row["A_House"].ToString();
                B_Land.Text = row["B_Land"].ToString();
                A_Land.Text = row["A_Land"].ToString();
                B_Vehicles.Text = row["B_Vehicles"].ToString();
                A_Vehicles.Text = row["A_Vehicles"].ToString();
                B_Health.Text = row["B_Health"].ToString();
                A_Health.Text = row["A_Health"].ToString();
                B_Childreneducation.Text = row["B_Childreneducation"].ToString();
                A_Childreneducation.Text = row["A_Childreneducation"].ToString();
                B_Reinvestments.Text = row["B_Reinvestments"].ToString();
                A_Reinvestments.Text = row["A_Reinvestments"].ToString();
            }
        }

        DataSet ds2 = new DataSet();
        {
            SqlParameter[] pp = new SqlParameter[]
             {
                  new SqlParameter("@PmegpID", SqlDbType.VarChar)
             };

            pp[0].Value = Pmegp_ID.Text;
            ds2 = gen.GenericFillDs("USP_GET_PMEGPSUCCESSSTROIES_family", pp);
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                FamilyDetailsGrid.DataSource= ds2.Tables[0];
                FamilyDetailsGrid.DataBind();
            }
        }
    }

    private string GetImageFilePathFromDatabase(int PmegpID, int imageId)
    {
        string filePath = string.Empty;

        using (SqlCommand command = new SqlCommand("USP_GET_PMEGPSUCCESSSTROIES_IMAGES", con.GetConnection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PmegpID", PmegpID);
            command.Parameters.AddWithValue("@imageId", imageId);
            con.OpenConnection();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    filePath = reader["filePath"].ToString();
                }
            }
            con.CloseConnection();
        }
        return filePath;
    }


    protected void FamilyDetailsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            TableCell headerCell = new TableCell();
            headerCell.Text = "FAMILY";
            headerCell.ColumnSpan = 5;
            headerCell.Style.Add("font-weight", "bold");
            headerCell.Style.Add("font-size", "14px");
            headerCell.Style.Add("text-align", "center");

            headerRow.Cells.Add(headerCell);

            FamilyDetailsGrid.Controls[0].Controls.AddAt(0, headerRow);
        }
    }
}

