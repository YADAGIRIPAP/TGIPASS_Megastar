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

public partial class UI_TSiPASS_UpdateCheckDeatailFinal : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }


    public void BindGrid()
    {
        string Cast = Request.QueryString[0].ToString();
        string Dipc = Request.QueryString[4].ToString();
        string Investmentid = Request.QueryString[1].ToString();
        h1heading.InnerHtml = Cast + " Category";
        txtsvcdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy"); // Request.QueryString[2].ToString();
                                                                      //string[] datett = txtsvcdate.Text.Trim().Split('/');
                                                                      //string ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
        // added by chaitanya  
        //string[] datett = txtsvcdate.Text.Trim().Split(' ');
        //string datett1 = datett[0];
        ////string[] datett2 = datett1.Split('/');
        ////string ProposedDate = datett2[1] + "/" + datett2[0] + "/" + datett2[2];
        string ProposedDate = "";
        //if (datett1.Contains('/'))
        //{
        //    string[] datett12 = txtsvcdate.Text.Trim().Split('/');
        //    ProposedDate = datett12[2] + "/" + datett12[1] + "/" + datett12[0];
        //}
        //else if (datett1.Contains('-'))
        //{
        //    string[] datett13 = txtsvcdate.Text.Trim().Split('-');
        //    ProposedDate = datett13[2] + "/" + datett13[1] + "/" + datett13[0];
        //}
        DataSet ds = new DataSet();
        // commented by chaitanya
        //   ds = gen.getReleaseProceedingsCheckUpdate(Cast, Investmentid, txtsvcdate.Text);
        //ds = gen.getReleaseProceedingsCheckUpdate(Cast, Investmentid, Request.QueryString[2].ToString());
       
          SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                 new SqlParameter("@Cast",SqlDbType.VarChar),
                  new SqlParameter("@date",SqlDbType.VarChar),
                  new SqlParameter("@subIncType",SqlDbType.VarChar),
                new SqlParameter("@dipc",SqlDbType.VarChar)
            };
        pp[0].Value = Investmentid;
        pp[1].Value = Cast;
        pp[2].Value = Request.QueryString[2].ToString();
        pp[3].Value = Request.QueryString[3].ToString();
        pp[4].Value = Dipc;


        ds = gen.GenericFillDs("USP_GET_UNIT_INCENTIVEWISE_CheckUPdated_new", pp);


       
       // ds = getReleaseProceedingsCheckUpdate(Cast, Investmentid, Request.QueryString[2].ToString(), Request.QueryString[3].ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }

         


    }


    


    public DataSet getReleaseProceedingsCheckUpdate(string Cast, string IncetiveID, string date,string subInctype)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_CheckUPdated_new", con.GetConnection);
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




    protected void Button1_Click(object sender, EventArgs e)
    {
        string msg="";
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
            string Dipc = Request.QueryString[4].ToString();
            foreach (GridViewRow gvrow in grdDetails.Rows)
            {
                var checkbox = gvrow.FindControl("chkRow") as CheckBox;
                if (checkbox.Checked)
                {
                    int rowIndex = gvrow.RowIndex;
                    string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                    string checkno = txtcheckNO.Text;
                    string[] datett = txtCheckdate.Text.Trim().Split('/');
                    string checkdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    string checkamount = txtamount.Text;
                    string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    string RlsProceedNo = Request.QueryString[2].ToString();

                     SqlParameter[] pp = new SqlParameter[] {
                  new SqlParameter("@EnterperIncentiveID",SqlDbType.VarChar),
                  new SqlParameter("@MstIncentiveId",SqlDbType.VarChar),
                  new SqlParameter("@CreatedByid",SqlDbType.VarChar),
                  new SqlParameter("@checkno",SqlDbType.VarChar),
                  new SqlParameter("@checkdate",SqlDbType.VarChar),
                  new SqlParameter("@checkamount",SqlDbType.VarChar),
                  new SqlParameter("@RlsProceedNo",SqlDbType.VarChar),
                  new SqlParameter("@DIPCFlag",SqlDbType.VarChar),
                  new SqlParameter("@Valid",SqlDbType.Int)
                };
                pp[0].Value = EnterperIncentiveID;
                pp[1].Value = MstIncentiveId;
                pp[2].Value = Session["uid"].ToString();
                pp[3].Value = checkno;
                pp[4].Value = checkdate;
                pp[5].Value = checkamount;
                pp[6].Value = RlsProceedNo;
                pp[7].Value = Dipc;
                pp[8].Value = 0;
                pp[8].Direction = ParameterDirection.Output;

                gen.GenericExecuteNonQuery("USP_UPD_UPDATECHeckLIstDTLS_COI", pp);

                valid = Convert.ToInt32(pp[8].Value);

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
            txtCheckdate.Text = "";
            txtcheckNO.Text = "";
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


}