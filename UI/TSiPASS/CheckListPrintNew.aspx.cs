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
using ListItem = System.Web.UI.WebControls.ListItem;

public partial class UI_TSiPASS_CheckListPrintNew : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
        if (!IsPostBack)
        {
            SCHCATEGORY.Items.Add(new ListItem("--Select--", "0"));
            SCHCATEGORY.Items.Add(new ListItem("GEN - IS", "1"));
            SCHCATEGORY.Items.Add(new ListItem("GEN - PV", "2"));
            SCHCATEGORY.Items.Add(new ListItem("GEN - PT", "3"));
            SCHCATEGORY.Items.Add(new ListItem("PHC - IS", "4"));
            SCHCATEGORY.Items.Add(new ListItem("PHC - PV", "5"));
            SCHCATEGORY.Items.Add(new ListItem("PHC - PT", "6"));
            SCHCATEGORY.Items.Add(new ListItem("SCP - IS", "7"));
            SCHCATEGORY.Items.Add(new ListItem("SCP - PV", "8"));
            SCHCATEGORY.Items.Add(new ListItem("SCP - PT", "9"));
            SCHCATEGORY.Items.Add(new ListItem("TSP - IS", "10"));
            SCHCATEGORY.Items.Add(new ListItem("TSP - PV", "11"));
            SCHCATEGORY.Items.Add(new ListItem("TSP - PT", "12"));
        }
    }
    public void BindGrid()
    {
        string Cast = Request.QueryString[0].ToString();
        string Investmentid = Request.QueryString[1].ToString();
        string Date = Request.QueryString[2].ToString();
        string SubIncTypeId = Request.QueryString[3].ToString();
        string Dipc = Request.QueryString[4].ToString();
        string financialyear = Request.QueryString[5].ToString();

        h1heading.InnerHtml = Cast + " Category";
        txtsvcdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");  
        string ProposedDate = "";
      
        DataSet ds = new DataSet(); 
        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@date",SqlDbType.VarChar),
                 new SqlParameter("@Cast",SqlDbType.VarChar),
                  new SqlParameter("@FinancialYearCd",SqlDbType.VarChar),
                  new SqlParameter("@DIPCFlag",SqlDbType.VarChar),
                  new SqlParameter("@SubIncTypeId",SqlDbType.VarChar),
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar)
            };
 

        pp[0].Value = Date;
        pp[1].Value = Cast;
        pp[2].Value = financialyear;
        pp[3].Value = Dipc;
        pp[4].Value = SubIncTypeId;
        pp[5].Value = Investmentid;


        ds = gen.GenericFillDs("USP_GET_UNIT_INCENTIVEWISE_CheckLIst_NEW", pp);



        // ds = getReleaseProceedingsCheckUpdate(Cast, Investmentid, Request.QueryString[2].ToString(), Request.QueryString[3].ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }


    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkAll = (CheckBox)grdDetails.HeaderRow.FindControl("chkAll");

        if (checkAll.Checked)
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("ChkApproval");
                checkone.Checked = true;
                ChkApproval_CheckedChanged(sender, e);
            }

        }
        else
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("ChkApproval");
                checkone.Checked = false;
            }
        }
    }


    public DataSet getReleaseProceedingsCheckUpdate(string Cast, string IncetiveID, string date, string subInctype)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_CheckUPdated_new_ALL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@IncentiveTypID", SqlDbType.VarChar).Value = IncetiveID;
            da.SelectCommand.Parameters.Add("@Cast", SqlDbType.VarChar).Value = Cast;
            da.SelectCommand.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            da.SelectCommand.Parameters.Add("@subIncType", SqlDbType.VarChar).Value = subInctype;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string msg = "";
        //if (txtcheckNO.Text == "" && txtCheckdate.Text == "" && txtamount.Text == "")
        //{
        //    msg = "Please Enter Cheque No \\n Please Enter Cheque Date \\n Please Enter Cheque Amount";
        //}
        //if (txtcheckNO.Text == "" && txtCheckdate.Text == "")
        //{
        //    msg = "";
        //}
        //if (txtCheckdate.Text == "" && txtamount.Text == "")
        //{
        //    msg = "";
        //}
        //if (txtcheckNO.Text == "" && txtamount.Text == "")
        //{
        //    msg = "";
        //}
        //if (txtcheckNO.Text == "" )
        //{
        //    msg = "";
        //}
        //if (txtCheckdate.Text == "" )
        //{
        //    msg = "";
        //}
        //if (txtamount.Text == "")
        //{
        //    msg = "";
        //}

        //if (msg == "")
        //{
        int valid = 0;
        //string Dipc = Request.QueryString[4].ToString();
        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            var checkbox = gvrow.FindControl("ChkApproval") as CheckBox;
            if (checkbox.Checked)
            {
                int rowIndex = gvrow.RowIndex;
                string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                string ANNEXTURENUMBER = txtannexturenumber.Text;
                string LOC_NUMBER = LOC_NO.Text;
                //string[] datett = txtCheckdate.Text.Trim().Split('/');
                //string checkdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                string selectedScheme = SCHCATEGORY.SelectedItem.Text; 
                string checkamount = txtamount.Text;
                string LOC_AMOUNT = LOCAMOUNT.Text;
                string Cheque_Proceeding_No = ChequeProceedingNo.Text;
                string Sanctioned_LOC_AMOUNT = San_LOC_AMOUNT.Text;
                string[] LOCDATE = LOCDate.Text.Trim().Split('/');
                string LOC_DATE = LOCDATE[2] + "/" + LOCDATE[1] + "/" + LOCDATE[0];
                string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                string RlsProceedNo = Request.QueryString[2].ToString();
                string Dipc = ((Label)gvrow.FindControl("lblfalg")).Text.ToString();


                SqlParameter[] pp = new SqlParameter[] {
                  new SqlParameter("@EnterperIncentiveID",SqlDbType.VarChar),
                  new SqlParameter("@MstIncentiveId",SqlDbType.VarChar),
                  new SqlParameter("@CreatedByid",SqlDbType.VarChar),
                  new SqlParameter("@ANNEXTURENUMBER",SqlDbType.VarChar),
                  new SqlParameter("@SelectedScheme",SqlDbType.VarChar),
                  new SqlParameter("@checkamount",SqlDbType.VarChar),
                  new SqlParameter("@RlsProceedNo",SqlDbType.VarChar),
                  new SqlParameter("@Dipc",SqlDbType.VarChar),
                  new SqlParameter("@LOC_NUMBER",SqlDbType.VarChar),
                  new SqlParameter("@LOC_AMOUNT",SqlDbType.VarChar),
                  new SqlParameter("@Sanctioned_LOC_AMOUNT",SqlDbType.VarChar),
                  new SqlParameter("@LOC_DATE",SqlDbType.VarChar),
                  new SqlParameter("@Cheque_Proceeding_Number",SqlDbType.VarChar),
                  new SqlParameter("@IPADDRESS",SqlDbType.VarChar),
                  new SqlParameter("@Valid",SqlDbType.Int)
                };
                pp[0].Value = EnterperIncentiveID;
                pp[1].Value = MstIncentiveId;
                pp[2].Value = Session["uid"].ToString();
                pp[3].Value = ANNEXTURENUMBER.Trim();
                pp[4].Value = selectedScheme;
                pp[5].Value = checkamount;
                pp[6].Value = RlsProceedNo;
                pp[7].Value = Dipc;
                pp[8].Value = LOC_NUMBER;
                pp[9].Value = LOC_AMOUNT;
                pp[10].Value = Sanctioned_LOC_AMOUNT;
                pp[11].Value = LOC_DATE;
                pp[12].Value = Cheque_Proceeding_No;
                pp[13].Value = getclientIP();
                pp[14].Value = 0;
                pp[14].Direction = ParameterDirection.Output;

                gen.GenericExecuteNonQuery("USP_UPD_UPDATECHeckLIst", pp);

                valid = Convert.ToInt32(pp[14].Value);

                //valid = gen.UpdateincentiveProposedSLCCheckdtlsdate(EnterperIncentiveID, MstIncentiveId, checkno, checkdate, checkamount, Session["uid"].ToString(), RlsProceedNo);
            }

        }
        if (valid == 1)
        {
            BindGrid();
            string message = "alert('Updated Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            // Button6.Visible = true;
            txtamount.Text = "";
            //txtcheckNO.Text = "";
        }

        // }

    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell cell in e.Row.Cells)
        {
            cell.Style.Add("mso-style-parent", "style0");
            cell.Style.Add("mso-number-format", "\\@");
        }
    }

    protected void ExportToExcel()
    {
        try
        {
            // Button6.Visible = false;
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("dd/M/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                divPrint.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint.RenderControl(hw);
                string label1text = txtsvcdate.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception e)
        {

        }
        finally
        {
            //  Button6.Visible = true;
        }
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=PendingUploadCheckDetailsforSLC.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Government.Visible = true;
        divPrint.Style["width"] = "680px";
        Button1.Visible = false;
        Button2.Visible = false;
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            grdDetails.AllowPaging = false;

            divPrint.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        //HiddenField HdfAmount = (HiddenField)row.FindControl("AllotedAmount");
        //if (ChkApproval.Checked == true)
        //{
        //    row.Cells[5].Text = row.Cells[11].Text;

        //}
        //else
        //{
        //    row.Cells[5].Text = "0";


        //}
        decimal sum = Convert.ToDecimal("0");
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (row1.Cells[8].Text != "" && row1.Cells[8].Text != "0")
                {

                    sum = sum + Convert.ToDecimal(row1.Cells[8].Text);
                }


                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
            }
        }

        txtamount.Text = sum.ToString();
        //txtAmount.Text = HdfA.Value;
        //TxtAmountOnline.Text = HdfA.Value;
        //if (TxtAmountOnline.Text == "0")
        //{
        //    BtnDelete.Text = "Submit Applications";
        //}
        //else
        //{
        //    BtnDelete.Text = "Pay";
        //}
    }

}