using iTextSharp.text;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class UI_TSiPASS_IncentiveApplicationsSVCList_COMMISSIONER : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/TSHome.aspx");

            }
            else
            {
                if (Convert.ToString(Session["uid"]) == "1213" || Convert.ToString(Session["uid"]) == "21345")
                {
                    if (!IsPostBack)
                    {
                        if (Request.QueryString.Count > 0)
                        {
                            
                                filldetails(Request.QueryString["Stg"].ToString());
                            //else if (Convert.ToString(Request.QueryString["status"]) == "Completed")
                            //    fillCompleteddetails();
                        }
                        else
                            Response.Redirect("DashboardINC.aspx");

                    }
                }
                else
                {
                    Response.Redirect("~/TSHome.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    public void filldetails(string stage)
    {
        try
        {
            if (Request.QueryString["Stg"].ToString() == "1")
            {
                lblhdngmsg.Text = "Applications to be Processed";

            }
            if (Request.QueryString["Stg"].ToString() == "2")
            {
                lblhdngmsg.Text = "Returned Applications";
            }
            if (Request.QueryString["Stg"].ToString() == "3")
            {
                lblhdngmsg.Text = "Approved Applications";
            }
            DataSet dsn = new DataSet();
            SqlDataAdapter da;
            con.OpenConnection();

            da = new SqlDataAdapter("SP_GENERATEAGENDA_COMMISSIONER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@STAGE", SqlDbType.VarChar).Value = stage;
            da.Fill(dsn);
            con.CloseConnection();
            if (dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                if (Convert.ToString(Session["uid"]) == "21345")
                    grdDetails.Columns[11].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                //lblmsg0.Text = "No Records Found";
                //Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            throw ex;
        }

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int gvrcnt = grdDetails.Rows.Count;
                Button BtnApprove;
                Button BtnReject;

                for (int i = 0; i <= gvrcnt; i++)
                {
                    if (i == 0)
                    {
                        BtnApprove = (Button)e.Row.FindControl("BtnApprove");
                        BtnApprove.Enabled = true;
                        BtnReject = (Button)e.Row.FindControl("BtnReject");
                        BtnReject.Enabled = true;

                    }
                    //else if (Session["uid"].ToString() == "324565")
                    //{
                    //    BtnApprove = (Button)e.Row.FindControl("BtnApprove");
                    //    BtnApprove.Enabled = true;
                    //    BtnReject = (Button)e.Row.FindControl("BtnReject");
                    //    BtnReject.Enabled = true;
                    //}
                    else
                    {
                        //BtnApprove = (Button)e.Row.FindControl("BtnApprove");
                        //BtnApprove.Enabled = false;
                        //BtnApprove.BackColor = System.Drawing.Color.LightGray;

                        //BtnReject = (Button)e.Row.FindControl("BtnReject");
                        //BtnReject.Enabled = false;
                        //BtnReject.BackColor = System.Drawing.Color.LightGray;

                    }
                }

                if (Request.QueryString["Stg"].ToString() == "1")
                {
                    grdDetails.Columns[12].Visible = false;
                    grdDetails.Columns[13].Visible = false;
                    grdDetails.Columns[14].Visible = false;
                }
                if (Request.QueryString["Stg"].ToString() == "2")
                {
                    grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[12].Visible = false;
                    grdDetails.Columns[13].Visible = true;
                    grdDetails.Columns[14].Visible = true;
                }
                if (Request.QueryString["Stg"].ToString() == "3")
                {
                    grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[12].Visible = true;
                    grdDetails.Columns[13].Visible = false;
                    grdDetails.Columns[14].Visible = false;
                }
                HyperLink hpViewAppl = (HyperLink)e.Row.Cells[1].Controls[0];
                HyperLink hpAppraisal = (HyperLink)e.Row.Cells[2].Controls[0];
                Label EnterperIncentiveID = (Label)e.Row.Cells[9].FindControl("lblEnterperIncentiveID");
                EnterperIncentiveID.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")).Trim();
                Label MasterIncentiveID = (Label)e.Row.Cells[10].FindControl("lblIncentiveId");
                MasterIncentiveID.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
                hpAppraisal.Target = "_blank";
                hpAppraisal.NavigateUrl = "appraisalNote2.aspx?incid=" + EnterperIncentiveID.Text + "&mstid=" + MasterIncentiveID.Text;
                hpViewAppl.Target = "_blank";
                hpViewAppl.NavigateUrl = "ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + EnterperIncentiveID.Text + "&Sts=1";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            throw ex;
        }
    }
    protected void BtnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnApprove = (Button)sender;
            GridViewRow row = (GridViewRow)btnApprove.NamingContainer;
            Label EnterperIncentiveID = (Label)row.FindControl("lblEnterperIncentiveID");
            Label MasterIncentiveID = (Label)row.FindControl("lblIncentiveId");

            int j = UpdateDeptProcess(EnterperIncentiveID.Text, MasterIncentiveID.Text, "", "A");
            if (j == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Successfully Updated";
                string message = "alert('Successfully Updated')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                filldetails(Request.QueryString["Stg"].ToString());
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }


    }
    protected void BtnReject_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnReject = (Button)sender;
            GridViewRow row = (GridViewRow)btnReject.NamingContainer;
            Label EnterperIncentiveID = (Label)row.FindControl("lblEnterperIncentiveID");
            Label MasterIncentiveID = (Label)row.FindControl("lblIncentiveId");
            TextBox TxtReject = (TextBox)row.FindControl("TxtReject");
            if (TxtReject.Visible && (TxtReject.Text == "" || TxtReject.Text == null || string.IsNullOrWhiteSpace(TxtReject.Text)))
            {
                string message = "alert('Please enter Return remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                TxtReject.Focus();
                return;
            }

            if (!TxtReject.Visible)
            {
                TxtReject.Visible = true;
                TxtReject.Focus();
                return;
            }

            if ((TxtReject.Visible) && (TxtReject.Text != ""))
            {
                int j = UpdateDeptProcess(EnterperIncentiveID.Text, MasterIncentiveID.Text, TxtReject.Text, "R");
                if (j == 1)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Successfully Updated";
                    string message = "alert('Successfully Updated')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    filldetails(Request.QueryString["Stg"].ToString());
                }
            }
            else
            {
                string message = "alert('Please enter Rejection remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                TxtReject.Focus();
                return;
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    public int UpdateDeptProcess(string EnterperIncentiveID, string MstIncentiveId, string Rejreason, string ProcFlag)
    {
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_UPDATE_COMMISSIONER_BEFORESVC";
            con.OpenConnection();
            com.Connection = con.GetConnection;

            if (EnterperIncentiveID.Trim() == "" || EnterperIncentiveID.Trim() == null)
                com.Parameters.Add("@EnterperIncentiveID", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@EnterperIncentiveID", SqlDbType.Int).Value = Convert.ToInt64(EnterperIncentiveID.Trim());

            if (MstIncentiveId.Trim() == "" || MstIncentiveId.Trim() == null)
                com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@MstIncentiveId", SqlDbType.Int).Value = Convert.ToInt64(MstIncentiveId.Trim());

            if (Rejreason.Trim() == "" || Rejreason.Trim() == null)
                com.Parameters.Add("@RETURNREASON_COMMISSIONER", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@RETURNREASON_COMMISSIONER", SqlDbType.VarChar).Value = Rejreason.Trim();

            if (ProcFlag.Trim() == "" || ProcFlag.Trim() == null)
                com.Parameters.Add("@PROCESSEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@PROCESSEDFLAG", SqlDbType.VarChar).Value = ProcFlag.Trim();

            com.Parameters.Add("@PROCESSEDIP_DEPT", SqlDbType.VarChar).Value = getclientIP();
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
            //com.Parameters.Add("@Result", SqlDbType.Int).Value = 0;
            com.Parameters.Add("@Result", SqlDbType.Int, 500);
            com.Parameters["@Result"].Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();


            int valid = (Int32)com.Parameters["@Result"].Value;

            try
            {
                return valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                com.Dispose();
                con.CloseConnection();
            }
        }
        catch (Exception ex)
        { throw ex; }

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