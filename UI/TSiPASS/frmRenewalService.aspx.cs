using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using AjaxControlToolkit;

public partial class UI_TSiPASS_frmRenewalService : System.Web.UI.Page
{
    General Gen = new General();
    string statuss;
    string intqnreid;
    String radioflag = "";
    DB.DB con = new DB.DB();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    //List<RenewalsVo> lstrenvo = new List<RenewalsVo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../../Index.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["status"] == null)
                {
                    statuss = "B";
                }
                if (Request.QueryString["intqnreid"] == null)
                {

                }
                statuss = Request.QueryString["status"].ToString();
                DataSet dscheck = new DataSet();
                string createvdby = Session["uid"].ToString();
                if (Request.QueryString["status"].ToString() == "A")
                {
                    osqlConnection.Open();
                    SqlDataAdapter da;
                    DataSet ds = new DataSet();
                    try
                    {
                        da = new SqlDataAdapter("GetShowRenewalQuestionaries", osqlConnection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        if (createvdby.Trim() == "" || createvdby.Trim() == null)
                            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
                        else
                            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = createvdby.ToString();
                        if (createvdby.Trim() == "" || createvdby.Trim() == null)
                            da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
                        else
                            da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "A";
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            //if (ds.Tables[0].Rows.Count >= 1)
                                //Session["Applid"] = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                        }
                        //if (ds.Tables[0].Rows.Count >= 1)
                        //    Session["Applid"] = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        osqlConnection.Close();
                    }
                }

                else if (Request.QueryString["status"].ToString() == "B")
                {
                    osqlConnection.Open();
                    SqlDataAdapter da;
                    DataSet ds = new DataSet();
                    try
                    {
                        da = new SqlDataAdapter("GetShowRenewalQuestionaries", osqlConnection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        if (createvdby.Trim() == "" || createvdby.Trim() == null)
                            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
                        else
                            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = createvdby.ToString();
                        if (createvdby.Trim() == "" || createvdby.Trim() == null)
                            da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
                        else
                            da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "B";
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count >= 1)
                                Session["Applid"] = Request.QueryString["intqnreid"].ToString();// ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                        }
                        //if (ds.Tables[0].Rows.Count >= 1)
                        //    Session["Applid"] = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        osqlConnection.Close();
                    }
                }


                //if (Request.QueryString["status"].ToString() == "A" || Session["Applid"] != null)
                //{
                //    Session["mainQnreid"] = Session["Applid"].ToString();
                //}

                //if (Session["Applid"].ToString().Trim() == "0")
                //{
                //    Response.Redirect("frmRenewalDetail.aspx");
                //}

                DataSet ds1 = new DataSet();
                ds1 = GetRenewalServices(Session["uid"].ToString().Trim(), rdrenewalservice.SelectedValue.Trim());
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds1.Tables[0];
                    //grdDetails.DataTextField = "Approvalid";
                    //grdDetails.DataValueField = "ApprovalName";
                    grdDetails.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Uid"].ToString().Trim() == "" || Session["Uid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmRenewalService.aspx");

            }
            else
            {
                int cnt = 0;
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        cnt = cnt + 1;
                    }
                }

                //lstrenvo.Clear();
                //RenewalsVo ren = new RenewalsVo();
                ////string s = string.Empty;
                //for (int i = 0; i < chckren.Items.Count; i++)
                //{

                //    if (chckren.Items[i].Selected)
                //    {
                //        //s += chckren.Items[i].Value + ";";
                //        ren.Approvalid = chckren.Items[i].Value;
                //        ren.ApprovalName = chckren.Items[i].Text.Trim();
                //        lstrenvo.Add(ren);
                //    }

                //}
                if (cnt < 1)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Select Atleast one Department for Approval";
                    lblmsg0.Visible = true;
                    Failure.Visible = true;
                    return;
                }
                else
                {

                    Failure.Visible = false;
                    lblmsg0.Text = "";
                    lblmsg0.Visible = false;
                    string HdfQueid = "";
                    int s = 0;
                    //Session["Applid"]
                    // HdfQueid = Convert.ToString(Gen.insertRenewalQuestionnaireAprroval(Session["uid"].ToString()));
                    //HdfQueid = Convert.ToString(Gen.insertRenewalQuestionnaireAprroval(Session["uid"].ToString()));
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            if (Request.QueryString["status"].ToString() == "B" || Request.QueryString["status"].ToString() == "A")
                            {
                                if (Session["Applid"] != null && Session["Applid"].ToString() != "")
                                {
                                    HdfQueid = Session["Applid"].ToString();
                                }
                                //((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            }
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            // string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();
                            string tourismflag = rdrenewalservice.SelectedValue;

                            s = Gen.insertRenewalDepartmentAprroval(HdfQueid, HdfDeptid, HdfApprovalid, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved, tourismflag);
                            Session["Applid"] = s.ToString();
                        }
                        else
                        {
                            if (Request.QueryString["status"].ToString() == "B" || Request.QueryString["status"].ToString() == "A")
                            {
                                if (Session["Applid"] != null && Session["Applid"].ToString() != "")
                                {
                                    HdfQueid = Session["Applid"].ToString();
                                }
                                //((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            }

                            //if (Request.QueryString.Count > 0)
                            //{
                            //    HdfQueid = Session["Applid"].ToString();//((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            //}
                            //HdfQueid = Request.QueryString[0].ToString();// ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            //string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                            s = UpdDepartmentRenewalAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);

                            //if (Request.QueryString.Count > 0)
                            //{
                            //    HdfQueid = Request.QueryString[0].ToString(); //((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            //}
                            ////HdfQueid = Request.QueryString[0].ToString();// ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            //string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            //string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            ////string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            //string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                            //s = Gen.UpdDepartmentRenewalAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                        }


                    }
                }

                Response.Redirect("frmRenewalDetail.aspx");
            }

            //foreach (ListItem li in chckren.Items)
            //{

            //    //int count = chckren.;

            //    if (li.Selected == true)
            //    {
            //        ren.Approvalid = chckren.SelectedValue;
            //        ren.ApprovalName = chckren.SelectedItem.Text.Trim();
            //        lstrenvo.Add(ren);
            //    }

            //}
            //Session["RenewalApprovals"] = lstrenvo;



            // }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmRenewalService.aspx");
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            //decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            //TotalFee = TotalFee + TotalFee1;
            //string s = "0";
            //if (e.Row.Cells[6].Text != "")
            //{
            //    s = e.Row.Cells[6].Text;
            //}
            //decimal TotalFee1a = Convert.ToDecimal(s);
            // TotalFeeNExt = TotalFeeNExt + TotalFee1a;

            //HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
            HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
            //HiddenField HdfQueid = Request.QueryString[0].ToString(); // (HiddenField)e.Row.FindControl("HdfQueid");
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");
            RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)e.Row.FindControl("RdWhetherAlreadyApproved");
            //RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)e.Row.FindControl("RdWhetherAlreadyApproved");

            //HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();
            //HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim();



            DataSet dsappr = new DataSet();
            if (Request.QueryString[0].ToString() != "A")
            {
                //COMMNETED ON 27/02/2021 BY MADHURI///
                //if (Session["Applid"] == null)
                //{
                //    Session["Applid"] = Session["uid"].ToString();
                //}
                //END OF COMMNETED ON 27/02/2021 BY MADHURI///
            }

            if (Session["Applid"] != null)
            {
                dsappr = Gen.GetQuestionaryRenewalsAprovalsApplyData(Session["Applid"].ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim());
                if (dsappr.Tables[0].Rows.Count > 0)
                {
                    if (dsappr.Tables[0].Rows[0]["IsOffline"].ToString().Trim() != "N")
                    {
                        //RdWhetherAlreadyApproved.SelectedValue = RdWhetherAlreadyApproved.Items.FindByValue(dsappr.Tables[1].Rows[0]["IsOffline"].ToString().Trim()).Value;
                    }
                }
                if (dsappr.Tables[0].Rows.Count > 0)
                {
                    //RdWhetherAlreadyApproved.SelectedValue = RdWhetherAlreadyApproved.Items.FindByValue(dsappr.Tables[0].Rows[0]["IsOffline"].ToString().Trim()).Value;
                    //if (dsappr.Tables[0].Rows[0]["IsPayment"].ToString().Trim() == "Y")
                    //{



                    //ChkApproval.Checked = true;
                    //ChkApproval.Enabled = false;

                    ChkApproval.Checked = true;
                    ChkApproval.Enabled = false;

                    //}

                    if (ChkApproval.Checked == true)
                    {
                        RdWhetherAlreadyApproved.Enabled = false;
                        //ChkApproval.Visible = false;
                        //e.Row.Cells[6].Text = "0";
                    }
                    else
                    {
                        RdWhetherAlreadyApproved.Enabled = true;
                    }
                    //else
                    //{

                    //    ChkApproval.Visible = true;
                    //    //   ChkApproval.Checked = false;
                    //    if (ChkApproval.Checked == true)
                    //    {
                    //        //e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                    //        // RdWhetherAlreadyApproved.Items[1].Selected = true;
                    //        // RdWhetherAlreadyApproved.Enabled = false;
                    //    }
                    //}


                }
                if (dsappr.Tables[1].Rows.Count > 0)
                {
                    if (dsappr.Tables[1].Rows[0]["Approval_Status"].ToString().Trim() == "3")
                    {
                        RdWhetherAlreadyApproved.Enabled = false;
                        ChkApproval.Enabled = false;
                    }
                    else
                    {
                        RdWhetherAlreadyApproved.Enabled = true;
                        ChkApproval.Enabled = true;
                    }
                }
            }


            if (HdfApprovalid.Value == "33")
            {
                RdWhetherAlreadyApproved.Items[1].Selected = true;
                RdWhetherAlreadyApproved.Enabled = false;
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                // e.Row.Cells[6].Text = e.Row.Cells[4].Text;
            }
            //if (HdfApprovalid.Value == "53" && dsappr.Tables[1].Rows[0]["Approval_Status"].ToString().Trim() != "3")
            //{
            //    RdWhetherAlreadyApproved.Items[1].Selected = false;
            //    RdWhetherAlreadyApproved.Enabled = false;
            //    ChkApproval.Checked = false;
            //    ChkApproval.Enabled = false;
            //    // e.Row.Cells[6].Text = e.Row.Cells[4].Text;
            //}


            //e.Row.Cells[4].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");
            //if (e.Row.Cells[6].Text != "")
            //{

            //    decimal TotalFeeAmount1 = Convert.ToDecimal(e.Row.Cells[6].Text);
            //    TotalFeeAmount = TotalFeeAmount + TotalFeeAmount1;
            //    if (e.Row.Cells[6].Text != "")
            //        e.Row.Cells[6].Text = Convert.ToDecimal(e.Row.Cells[6].Text).ToString("#,##0");
            //}

        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            //e.Row.Cells[5].Text = "Total Fee";
            ////  e.Row.Cells[4].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0"); ;
            //e.Row.Cells[6].Text = Convert.ToDecimal(TotalFeeAmount.ToString()).ToString("#,##0");
        }
    }

    protected void RdWhetherAlreadyApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)RdWhetherAlreadyApproved.NamingContainer;
        CheckBox ChkApproval = (CheckBox)row.FindControl("ChkApproval");

        // HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        if (RdWhetherAlreadyApproved.Items[0].Selected == true)
        {

            ChkApproval.Visible = false;
            row.Cells[6].Text = "0";
        }
        else
        {

            ChkApproval.Visible = true;
            ChkApproval.Checked = false;
            if (ChkApproval.Checked == true)
            {
                row.Cells[6].Text = row.Cells[4].Text;
                RdWhetherAlreadyApproved.Items[1].Selected = true;
                RdWhetherAlreadyApproved.Enabled = false;
            }
            else
            {
                row.Cells[6].Text = "0";
            }


        }
    }

    public DataSet GetRenewalServices(string createdby, string flag)
    {

        osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_RENEWALAPPROVALS]", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (createdby == "" || createdby == null)
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.Trim();
            if (flag == "" || flag == null)
                da.SelectCommand.Parameters.Add("@InputType", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@InputType", SqlDbType.VarChar).Value = flag.Trim();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }

    }

    protected void rdrenewalservice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdrenewalservice.SelectedValue == "I")
        {
            radioflag = "1";
            trheading.Visible = true;
            trgrid.Visible = true;
            trbuttons.Visible = true;

        }
        else if (rdrenewalservice.SelectedValue == "H")
        {
            radioflag = "2";
            trheading.Visible = true;
            trgrid.Visible = true;
            trbuttons.Visible = true;

        }
        else if (rdrenewalservice.SelectedValue == "O")
        {
            radioflag = "3";
            trheading.Visible = true;
            trgrid.Visible = true;
            trbuttons.Visible = true;

        }
        if (rdrenewalservice.SelectedValue != "")
        {
            DataSet ds1 = new DataSet();
            ds1 = GetRenewalServices(Session["uid"].ToString().Trim(), radioflag);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds1.Tables[0];
                //grdDetails.DataTextField = "Approvalid";
                //grdDetails.DataValueField = "ApprovalName";
                grdDetails.DataBind();

            }
        }

    }

    public int UpdDepartmentRenewalAprrovalNew(string intQuessionaireid, string intDeptid, string intApprovalid, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdDepartmentRenewalAprrovalNew";

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        //if (Approval_Fee == "" || Approval_Fee == null)
        //    com.Parameters.Add("@Approval_Fee", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@Approval_Fee", SqlDbType.VarChar).Value = Approval_Fee.Trim();

        if (IsPayment == "" || IsPayment == null)
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = IsPayment;

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (IsOffline == "" || IsOffline == null)
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = IsOffline.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
}