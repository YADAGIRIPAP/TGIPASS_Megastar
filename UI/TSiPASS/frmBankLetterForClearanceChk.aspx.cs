using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class UI_TSiPASS_frmBankLetterForClearanceChk : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session.Count == 0)
                {
                    Response.Redirect("../../Index.aspx");
                    return;
                }

                string SLCNumber = Request.QueryString[0].ToString();
                string SLCDate = Request.QueryString[1].ToString();
                string CheckNO = Request.QueryString[3].ToString();
                string rlsproceedno = Request.QueryString[2].ToString();
                // SLCNumber = "45";
                //SLCDate = "07/22/2017";
                DataSet ds = new DataSet();
                ds = GetBankLetterDetails(SLCNumber, SLCDate, rlsproceedno.Trim(), CheckNO.Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblLetterNo.Text = ds.Tables[0].Rows[0]["LetterNo"].ToString();
                    lblLetterDate.Text = ds.Tables[0].Rows[0]["LetterDt"].ToString();
                    lblAssistantName.Text = ds.Tables[0].Rows[0]["lblAssistantName"].ToString();
                    lblDesignation.Text = ds.Tables[0].Rows[0]["lblDesignation"].ToString();
                    lblTextFilesNames.Text = ds.Tables[0].Rows[0]["lblTextFilesNames"].ToString();
                    lblAccountNo.Text = ds.Tables[0].Rows[0]["lblAccountNo"].ToString();
                    lblSBIDateWithUnits.Text = ds.Tables[0].Rows[0]["lblSBIDateWithUnits"].ToString();
                    lblSBIAmount.Text = ds.Tables[0].Rows[0]["SBISanctionedAmount"].ToString();
                    lblOtherBankDateWithUnits.Text = ds.Tables[0].Rows[0]["lblOtherBankDateWithUnits"].ToString();
                    lblOtherBankAmount.Text = ds.Tables[0].Rows[0]["OtherBankSanctionedAmount"].ToString();

                    lblAssistantName2.Text = ds.Tables[0].Rows[0]["lblAssistantName"].ToString();
                    if (lblSBIAmount.Text != "")
                    {
                        lblSBIAmountInwords.Text = gen.NumberToWord(Convert.ToInt32(lblSBIAmount.Text.Trim()));
                    }
                    if (lblOtherBankAmount.Text != "")
                    {
                        lblOtherBankAmountinWords.Text = gen.NumberToWord(Convert.ToInt32(lblOtherBankAmount.Text.Trim()));
                    }
                    //lblSBIAmountInwords.Text = "";
                    if (lblSBIDateWithUnits.Text.Trim() != "")
                    {
                        trSBIData.Visible = true;
                    }
                    else
                    {
                        trSBIData.Visible = false;
                    }

                    if (lblOtherBankDateWithUnits.Text.Trim() != "")
                    {
                        trOtherBankData.Visible = true;
                    }
                    else
                    {
                        trOtherBankData.Visible = false;
                    }
                    if (trOtherBankData.Visible == true && trSBIData.Visible == false)
                    {
                        Span2.InnerText = "1.";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
           // lblmsg0.Text = ex.Message;
           // Failure.Visible = true;
        }
    }



    public DataSet GetBankLetterDetails(string SLCNumber, string SLCDate, string releaseProcedingNo, string checkno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_BANKLETTER_CLEARANCECHECK", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@SLCNUMBER", SqlDbType.VarChar).Value = SLCNumber;
            da.SelectCommand.Parameters.Add("@SLCDATE", SqlDbType.VarChar).Value = SLCDate;
            da.SelectCommand.Parameters.Add("@RlsProno", SqlDbType.VarChar).Value = releaseProcedingNo;
            da.SelectCommand.Parameters.Add("@Checkno", SqlDbType.VarChar).Value = checkno;


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