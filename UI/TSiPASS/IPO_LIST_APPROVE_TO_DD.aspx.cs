using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using ListItem = System.Web.UI.WebControls.ListItem;

public partial class UI_TSiPASS_IPO_LIST_APPROVE_TO_DD : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSuccessMessage.Text = "Selected List Number is Successfully Updated and Forwarded to DD INCENTIVES";
        lblSuccessMessage.CssClass = "alert blink alert-dismissible";

        if (!IsPostBack)
        {
            trdates.Visible = true;
            txtFromDate.Text = "01-08-2017";
            txtTodate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            UpdateFlagToDB.Visible = false;
            PrintButton.Visible = false;
            lblSuccessMessage.Visible = false;
            ApprovedListDownload.Visible = false;
        }

        if (!IsPostBack)
        {
            DataTable dropdownData = LIST_No_DropDown_Procedure(ddlcaste.SelectedValue);

                DataRow defaultRow = dropdownData.NewRow();
                defaultRow["List No"] = "-1";
                defaultRow["List No"] = "--Select--";
                dropdownData.Rows.InsertAt(defaultRow, 0);

            DropDown_LIST_No.DataSource = dropdownData;
            DropDown_LIST_No.DataTextField = "List No";
            DropDown_LIST_No.DataValueField = "List No";
            DropDown_LIST_No.DataBind();
        }

        if (!IsPostBack)
        {
            ddlcaste.Items.Add(new ListItem("--Select--", "0"));
            ddlcaste.Items.Add(new ListItem("General", "1"));
            ddlcaste.Items.Add(new ListItem("PHC", "2"));
            ddlcaste.Items.Add(new ListItem("SC", "3"));
            ddlcaste.Items.Add(new ListItem("ST", "4"));
        }

        if (!IsPostBack)
        {
            DataTable dropdownData = APPROVED_LIST_No_DropDown_Procedure();

            DataRow defaultRow = dropdownData.NewRow();
            defaultRow["Approved LIST No."] = "-1";
            defaultRow["Approved LIST No."] = "--Select--";
            dropdownData.Rows.InsertAt(defaultRow, 0);

            DropDownList1.DataSource = dropdownData;
            DropDownList1.DataTextField = "Approved LIST No.";
            DropDownList1.DataValueField = "Approved LIST No.";
            DropDownList1.DataBind();

        }

    }

    private DataTable APPROVED_LIST_No_DropDown_Procedure()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("APPROVEDListNo", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                con.CloseConnection();
            }
        }
        return dataTable;
    }

    private DataTable LIST_No_DropDown_Procedure(string selectedValue)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("LIST_No_DropDown", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Caste", selectedValue);
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                con.CloseConnection();
            }
        }
        return dataTable;
    }

    //public DataTable GetLISTNOFromStoredProcedure()
    //{
    //    DataTable dataTable = new DataTable();

    //    using (SqlConnection connection = new SqlConnection("Data Source= 120.138.9.236;Initial Catalog=TSIPASS19102022;User ID=madhuri;Password=Devansh@26;"))
    //    {
    //        SqlCommand command = new SqlCommand("LIST_No_DropDown", connection);
    //        command.CommandType = CommandType.StoredProcedure;

    //        SqlDataAdapter adapter = new SqlDataAdapter(command);
    //        adapter.Fill(dataTable);
    //    }
    //    return dataTable;
    //}

   

    protected void Getlist_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;

        //string FromdateforDB = "", TodateforDB = "";

        if (ddlcaste.SelectedItem.ToString() == "--Select--")
        {
            lblmsg0.Text = "<br/> Please Select 'Caste'";
            valid = 1;
        }
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "<br/> Please Enter 'From Date'";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "<br/> Please Enter 'To Date'";
            valid = 1;
        }
        if (DropDown_LIST_No.SelectedItem != null && DropDown_LIST_No.SelectedItem.ToString() == "--Select--")
        {
            lblmsg0.Text += "<br/> Please Select 'List Number'";
            valid = 1;
        }
        if (DropDown_LIST_No.Items.Count == 0)
        {
            lblmsg0.Text += "<br/> There are no records to process in this category!!";
            valid = 1;
        }
        if (valid == 0)
        {
            //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        if (valid == 0)
        {
            SqlParameter[] pp = new SqlParameter[]
                 {
                    new SqlParameter("@Caste",SqlDbType.VarChar),
                    new SqlParameter("@FromDate", SqlDbType.Date),
                    new SqlParameter("@ToDate", SqlDbType.Date),
                    new SqlParameter("@LIST_NUMBER", SqlDbType.VarChar)
                 };

            pp[0].Value = ddlcaste.SelectedItem.Text;
            pp[1].Value = txtFromDate.Text;
            pp[2].Value = txtTodate.Text;
            pp[3].Value = DropDown_LIST_No.SelectedItem.Text;
            DataSet ds2 = new DataSet();
            ds2 = gen.GenericFillDs("Update_SLC_OR_DIPC_FLAGS_TO_DB", pp);
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                grdDetails.Visible = true;
                grdDetails.DataSource = ds2.Tables[0];
                grdDetails.DataBind();
                UpdateFlagToDB.Visible = true;
                PrintButton.Visible = false;
            }
        }
        else
        {
            Failure.Visible = true;
        }
    }

    protected void UpdateFlagToDB_Click(object sender, EventArgs e)
    {
        string msg = "";
        int valid = 0;
        string IP_ADDRESS = "";
        string CreatedBy_AnnextureUpdateid = "";

        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            //var checkbox = gvrow.FindControl("chkAll") as CheckBox;
            var checkbox = gvrow.FindControl("ChkApproval") as CheckBox;
            if (checkbox.Checked)
            {
                int rowIndex = gvrow.RowIndex;
                string ANNEXTURE = ((Label)gvrow.FindControl("ANNEXTURENUMBER")).Text.ToString();
                string MasterId = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();

                SqlParameter[] pp = new SqlParameter[] {
                      new SqlParameter("@ANNEXTURENUMBER",SqlDbType.VarChar),
                      new SqlParameter("@MasterIncentiveId",SqlDbType.VarChar),
                      new SqlParameter("@IP_ADDRESS", SqlDbType.VarChar),
                      new SqlParameter("@CreatedBy_AnnextureUpdateid", SqlDbType.VarChar)
            };
                pp[0].Value = ANNEXTURE;
                pp[1].Value = MasterId;
                pp[2].Value = getclientIP();
                pp[3].Value = Session["uid"].ToString();

                gen.GenericExecuteNonQuery("Update_SLC_DIPC_FLAGS", pp);
                PrintButton.Visible = true;
            }
        }
        if (valid == 1)
        {

        }
        string message = "alert('Updated Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        lblSuccessMessage.Visible = true;
        ClientScript.RegisterStartupScript(this.GetType(), "alert blink alert-dismissible", "HideLabel();", true);
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
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }


    protected void ClearFields_Click(object sender, EventArgs e)
    {
        string currentPageUrl = "~/UI/TSIPASS/IPO_LIST_APPROVE_TO_DD.aspx";
        Response.Redirect(currentPageUrl);
    }


    protected void ddlcaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = ddlcaste.SelectedValue;
        DropDown_LIST_No.Items.Clear();

        DataTable dropdownData = LIST_No_DropDown_Procedure(selectedValue);

        if (dropdownData.Rows.Count > 0)
        {
            DropDown_LIST_No.Items.Add(new ListItem("--Select--", "-1"));
            foreach (DataRow row in dropdownData.Rows)
            {
                string text = row["List No"].ToString();
                string value = row["List No"].ToString();
                DropDown_LIST_No.Items.Add(new ListItem(text, value));
            }
        }
    }

    protected void PrintButton_Click(object sender, EventArgs e)
    {
        string dataToPass = DropDown_LIST_No.SelectedItem.Text;

        //string redirectUrl = "Updated_Annexures_PRINT_PDF.aspx?ListNo=" + dataToPass;

        string dataToPass2 = ddlcaste.SelectedItem.Text;

        string redirectUrl = "Updated_Annexures_PRINT_PDF.aspx?ListNo=" + dataToPass + "&Caste=" + dataToPass2;

        string script = "window.open('" + redirectUrl + "', '_blank', 'width=850,height=1500');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
    }

    protected void ApprovedListDownload_Click(object sender, EventArgs e)
    {
        string dataToPass = DropDownList1.SelectedItem.Text;
        string redirectUrl = "Updated_Annexures_PRINT_PDF.aspx?ListNo=" + dataToPass;

        string script = "window.open('" + redirectUrl + "', '_blank', 'width=850,height=1500');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text != "--Select--")
        {
            ApprovedListDownload.Visible = true;
        }
        else
        {
            ApprovedListDownload.Visible = false;
        }
    }
}




