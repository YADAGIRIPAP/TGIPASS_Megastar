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

public partial class UI_TSiPASS_DD_Updated_List_Approval : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    decimal NoofClaimsTotal, AmountTotal;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSuccessMessage.Text = "Records have been Approved and Forwarded to JD Incentives!";
        lblSuccessMessage.CssClass = "alert blink alert-dismissible";

        if (!IsPostBack)
        {
            tblselection.Visible = false;
            lblSuccessMessage.Visible = false;
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
    }

    private DataTable LIST_No_DropDown_Procedure(string selectedValue)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("LIST_No_DropDown_DD_APPROVAL", con.GetConnection))
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

    private DataTable GVData_DD_APPROVAL_Procedure(string Caste, string ListNo)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();

        {
            using (SqlCommand command = new SqlCommand("GVData_DD_APPROVAL", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Caste", Caste);
                command.Parameters.AddWithValue("@ListNo", ListNo);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                con.CloseConnection();
            }
        }
        return dataTable;
    }

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
            DataTable dropdownData = GVData_DD_APPROVAL_Procedure(ddlcaste.SelectedValue, DropDown_LIST_No.SelectedValue);

            gvProceedings.DataSource = dropdownData;
            gvProceedings.DataBind();

            txtFromDate.Text = "01-08-2017";
                txtTodate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

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
                ds2 = gen.GenericFillDs("Updated_List_DD_APPROVAL", pp);
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    grdDetails.Visible = true;
                    grdDetails.DataSource = ds2.Tables[0];
                    grdDetails.DataBind();
                    tblselection.Visible = true;
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
        //string IP_ADDRESS = "";
        //string CreatedBy_AnnextureUpdateid = "";

        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            int rowIndex = gvrow.RowIndex;
            string ANNEXTURE = ((Label)gvrow.FindControl("ANNEXTURENUMBER")).Text.ToString();
            string MasterId = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();

            SqlParameter[] pp = new SqlParameter[] {
                  new SqlParameter("@ANNEXTURENUMBER",SqlDbType.VarChar),
                  new SqlParameter("@MasterIncentiveId",SqlDbType.VarChar)
            };
                pp[0].Value = ANNEXTURE;
                pp[1].Value = MasterId;

                gen.GenericExecuteNonQuery("DD_APPROVE_TO_JD", pp);
        }
        
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
        string currentPageUrl = "~/UI/TSIPASS/DD_Updated_List_Approval.aspx";
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

    protected void gvProceedings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            string id = rowView["ListNo"].ToString();
            string dataToPass = DropDown_LIST_No.SelectedItem.Text;

            HyperLink hyperLink = (HyperLink)e.Row.FindControl("HyperLink1");
            hyperLink.NavigateUrl = "Updated_Annexures_PRINT_PDF.aspx?ListNo=" + dataToPass;
            hyperLink.Text = "Document - " + id;
            
            hyperLink.Target = "_blank";

            hyperLink.Attributes["onclick"] = "window.open('" + hyperLink.NavigateUrl + "', '_blank', 'width=850,height=1500'); return false;";
        }
    }

    protected string GetPageUrl(object id)
    {
        string pageUrl = "~/UI/TSIPASS/Updated_Annexures_PRINT_PDF.aspx?id=" + id.ToString();
        return ResolveUrl(pageUrl);
    }

}




