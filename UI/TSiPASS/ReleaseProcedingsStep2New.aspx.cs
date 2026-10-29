using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_ReleaseProcedingsStep2New : System.Web.UI.Page
{
    string Cast, Investmentid, GoAllotedAmount;
    DB.DB con = new DB.DB();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDistricts(ddlDist);
        }
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {

            int valid = 0;
            ViewState["UIDNO"] = null;
            Session["UIDNO"] = null;

            Cast = "%";
            Investmentid = "%";
            GoAllotedAmount = "%";
 

            if (txtUnitName.Text.Trim() == "")
            {
               // lblmsg0.Text += "Please enter Unit Name" + "<br/>";
                valid = 1;
            }
         
            if (valid == 0)
            {
                DataSet ds = new DataSet();
                ds = GetIncentives_Release_Proceedings_UnitName_search("%", txtUnitName.Text, ddlDist.SelectedValue, "%", "%");
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvData2.DataSource = ds.Tables[0];
                        gvData2.DataBind();
                        tblspecialcasesSearch.Visible = true;
                        trsearchresult.Visible = true;
                    }
                    else
                    {
                        gvData2.DataSource = null;
                        gvData2.DataBind();
                        
                        tblspecialcasesSearch.Visible = true;
                        trsearchresult.Visible = false;

                    }
                }
                else
                {
                    gvData2.DataSource = null;
                    gvData2.DataBind();
   
                    tblspecialcasesSearch.Visible = true;
                    trsearchresult.Visible = false;
                }
                // Failure.Visible = false;
            }
            else
            {
                gvData2.DataSource = null;
                gvData2.DataBind();
                tblspecialcasesSearch.Visible = true;
                trsearchresult.Visible = false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetIncentives_Release_Proceedings_UnitName_search(String SLCNo, String UnitName, String Dist, String Investmentid, String Cast)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GetIncentives_Release_Proceedings_UnitName_search_NEW", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@SlcNo", SqlDbType.VarChar).Value = SLCNo;
            if (Dist != "--Select--" && Dist != "")
            {
                da.SelectCommand.Parameters.Add("@Distid", SqlDbType.VarChar).Value = Dist;
            }

            da.SelectCommand.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = UnitName;
            da.SelectCommand.Parameters.Add("@Incentivetype", SqlDbType.VarChar).Value = Investmentid;
            da.SelectCommand.Parameters.Add("@Cast", SqlDbType.VarChar).Value = Cast;

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
    private void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsForOldSanctionedIncentives();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
            // Clear the response and set up the response headers
            Response.Clear();
            Response.Buffer = true;

            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            // Use a StringWriter and HtmlTextWriter to render the GridView
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    // Make the GridView temporarily visible if hidden
                    gvData2.Visible = true;

                    // Optional: Remove unnecessary styles for cleaner Excel rendering
                    gvData2.Style["width"] = "100%";

                    // Render the GridView
                    gvData2.RenderControl(hw);

                    // Write the rendered HTML to the response
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (log the error or show a message)
            Console.WriteLine("Error during export: " + ex.Message);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Allows the GridView to be rendered
    }


}