using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Activities.Expressions;
using System.Drawing;
using System.Security.Cryptography;

public partial class UI_TSiPASS_frmtodeleteOldData : System.Web.UI.Page
{

    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        if (Session["uid"] ==null)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUID.Text != "")
            {
                fillGrid();
            }
            else
            {
                lblError.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    void fillGrid()
    {
        try
        {
            DataSet dsn = new DataSet();

            // dsn = Gen.GetApplicationTracker(txtnameofUnit.Text, txtUID.Text,ddlquantityper.SelectedValue.ToString());
            //SP_GET_DATA_OLDDATANEW_UID
            SqlParameter[] pp = new SqlParameter[] 
            {             
               new SqlParameter("@UID_NO",SqlDbType.VarChar),
            };
            
            
            pp[0].Value = (txtUID.Text == "") ? "%" : txtUID.Text;


            dsn = Gen.GenericFillDs("SP_GET_DATA_OLDDATANEW_UID", pp);

                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.Visible = true;
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    
                }
                else
                {
                    lblrecords.Text = "NO RECORD TO DISPLAY";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }    
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h1 = (HyperLink)e.Row.FindControl("hypLetter");
                h1.NavigateUrl = "ApplicationTrakerDetailed.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
                h1.Text = "View";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        txtUID.Text = "";
    }
    protected void DltRecord_Click(object sender, EventArgs e)
    {
        try 
        {
            Button dltbtn = (Button)sender;
            GridViewRow row = (GridViewRow)dltbtn.NamingContainer;
            Label lbluid=(Label)row.FindControl("lbluid");
            TextBox dltreasn= (TextBox)row.FindControl("dltreason");
            if(dltreasn.Text=="")
            {
                //lblmsg0.Text = "Please enter reason to delete the record";
                //Failure.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason to delete the record')", true);
                dltreasn.Focus();
            }
            else if(dltreasn.Text != "")
            {
                SqlParameter[] p = new SqlParameter[]
                {
                   new SqlParameter("@UID_NO", SqlDbType.VarChar),
                   new SqlParameter("@DELETEDBY", SqlDbType.VarChar),
                   new SqlParameter("@DELETEDIPADDRESS", SqlDbType.VarChar),
                   new SqlParameter("@DELETEREMARKS", SqlDbType.VarChar),
                };
                p[0].Value = lbluid.Text.Trim();
                p[1].Value = Session["uid"].ToString();
                p[2].Value = getclientIP();
                p[3].Value = dltreasn.Text.Trim();
                int i = Gen.GenericExecuteNonQuery("SP_DELETE_DUPLICATERECORDS_OLDDATANEW", p);
                
                if(i == 2)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                    fillGrid();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record not deleted')", true);
                    fillGrid();
                }
            }
        }
        catch
        { }

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
}