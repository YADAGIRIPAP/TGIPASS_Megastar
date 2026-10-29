using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Web.UI.HtmlControls;
using Org.BouncyCastle.Asn1.Ocsp;
//using System.Reflection.Emit;
//using System.Reflection.Emit;
//created by suresh as on 13-1-2016
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General(); DB.DB con = new DB.DB();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dsd = new DataSet();
            dsd = Gen.GetDistrictsWithoutHYD();
            ddldistrict.DataSource = dsd.Tables[0];
            ddldistrict.DataValueField = "District_Id";
            ddldistrict.DataTextField = "District_Name";
            ddldistrict.DataBind();
            ddldistrict.Items.Insert(0, "--Select--");
            GetDetails();
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }
    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            rstages = Request.QueryString[0].ToString().Trim();

            DataSet dsn = new DataSet();
            //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
            //return;
            if (Session["user_code"].ToString().Trim() == "15")//GROUND WATER
            {
                dsn = GetShowDepartmentFiles_GROUNDWATER(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());

            }
            else
            {
                dsn = Gen.GetShowDepartmentFiles(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
            }

            if (dsn.Tables[0].Rows.Count > 0)
            {

                //grdDetails.DataSource = dsn.Tables[0];
                //grdDetails.DataBind();
                if (rstages == "5" || rstages == "6" || rstages == "7" || rstages == "8" || rstages == "12" || rstages == "17" || rstages == "21")
                {
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    rptDetails.DataSource = dsn.Tables[0];
                    rptDetails.DataBind();
                }

                if (rstages == "13")
                {
                    grdDetails.Columns[17].Visible = true;
                    grdDetails.Columns[18].Visible = true;
                    // rptDetails.FindControl("tdRefNO").Visible = true;
                    // rptDetails.FindControl("thRefNO").Visible = true;
                }
                else if (rstages == "16")
                {
                    //grdDetails.Columns[20].Visible = true;
                    //rptDetails.FindControl("thRejection").Visible = true;
                    //rptDetails.FindControl("tdRejection").Visible = true;
                }
                else
                {
                    grdDetails.Columns[17].Visible = false;
                    grdDetails.Columns[18].Visible = false;
                }
                if (Session["uid"].ToString().Trim() == "1027" || Session["uid"].ToString().Trim() == "1028")
                {
                    grdDetails.Columns[18].Visible = true;
                }
                else
                {
                    grdDetails.Columns[18].Visible = false;
                }
                if (Session["uid"].ToString().Trim() == "1042")
                {
                    grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[12].Visible = false;
                }
                else
                {
                    grdDetails.Columns[11].Visible = true;
                    grdDetails.Columns[12].Visible = true;
                }

                if (Session["uid"].ToString().Trim() == "1021")
                {
                    grdDetails.Columns[24].Visible = true;
                    grdDetails.Columns[25].Visible = true;
                    grdDetails.Columns[26].Visible = true;
                }
                else
                {
                    grdDetails.Columns[24].Visible = false;
                    grdDetails.Columns[25].Visible = false;
                    grdDetails.Columns[26].Visible = false;
                }

                //if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
                //{
                //    if (dsn.Tables[0].Rows[0]["UPDATEDFLAG"].ToString() != null && dsn.Tables[0].Rows[0]["UPDATEDFLAG"].ToString() != "")
                //    {
                //        if (dsn.Tables[0].Rows[0]["UPDATEDFLAG"].ToString() == "Y")
                //        {
                //            grdDetails.Columns[22].Visible = true;
                //        }
                //        else
                //        {
                //            grdDetails.Columns[22].Visible = false;
                //        }
                //    }
                //    else
                //    {
                //        grdDetails.Columns[22].Visible = false;
                //    }
                //}
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
            {
            }
            else
            {
                // grdDetails.Columns[10].Visible = false;
                //grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[12].Visible = false;
            }
            if (Request.QueryString[0].ToString().Trim() == "17")
            {
                grdDetails.Columns[27].Visible = true;
            }
        }
        else
        {
            //grdDetails.Columns[10].Visible = false;
            //grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[12].Visible = false;
        }
        grdDetails.Columns[23].Visible = false;

    }
    public DataSet GetShowDepartmentFiles_GROUNDWATER(string Deptid, string intStageid, string intDistrictid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();



        try
        {
            da = new SqlDataAdapter("GetShowDepartmentFiles_GROUNDWATER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();
            da.SelectCommand.CommandTimeout = 3600;

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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();

    }
    void clear()
    {



    }
    public void GetDetailsSearch()
    {
        if (TxtnameofUnit.Text == String.Empty && TxtnameofUnit0.Text == String.Empty && ddldistrict.SelectedItem.Text == "--Select--" && ddldistrict0.SelectedItem.Text == "--Select--")
        {
            GetDetails();
        }
        else
        {
            if (Request.QueryString.Count > 0)
            {
                rstages = Request.QueryString[0].ToString().Trim();
                DataSet dsn = new DataSet();
                //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
                //return;
                dsn = Gen.GetShowDepartmentFilesIndusSearchCFE(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim(), TxtnameofUnit.Text, TxtnameofUnit0.Text, ddldistrict.SelectedValue.ToString(), ddldistrict0.SelectedValue.ToString());
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
                {
                }
                else
                {
                    // grdDetails.Columns[10].Visible = false;
                    //grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[12].Visible = false;
                }
            }
            else
            {
                //grdDetails.Columns[10].Visible = false;
                //grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[12].Visible = false;
            }
        }
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        GetDetailsSearch();

    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
        }

    }
    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GetNewRectoInsertdr()
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                switch (Session["uid"].ToString().Trim())
                {
                    case "1027":
                    case "1028":
                        e.Row.Cells[19].Visible = true;
                        break;
                    default:
                        e.Row.Cells[19].Visible = false;
                        break;
                }
                if (Session["User_Code"].ToString().Trim() == "1")
                {
                    grdDetails.Columns[21].Visible = true;
                }
                else
                {
                    grdDetails.Columns[21].Visible = false;
                }
                //if (Session["User_Code"].ToString().Trim() == "1" || Session["User_Code"].ToString().Trim() == "9" || Session["User_Code"].ToString().Trim() == "3")
                //{
                //    grdDetails.Columns[22].Visible = true;
                //}
                //else
                //{
                //    grdDetails.Columns[22].Visible = false;
                //}
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (Session["User_Code"].ToString().Trim() == "1" || Session["User_Code"].ToString().Trim() == "9")
                //{
                DropDownList ddlStatus1 = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
                //if (Session["uid"].ToString().Trim() != "1031")
                //{
                if (e.Row.Cells[22].Text.Trim() == "Y" && (Session["User_Code"].ToString().Trim() != "13" && Session["User_Code"].ToString().Trim() != "11" && Session["User_Code"].ToString().Trim() != "3" && Session["User_Code"].ToString().Trim() != "15" && Session["User_Code"].ToString().Trim() != "404"))
                {
                    if ((Session["User_Code"].ToString().Trim() == "13") && (e.Row.Cells[23].Text.Trim() == "N"))
                    {
                        e.Row.Cells[22].Text = "Please process this application in TS-iPASS portal";
                        ddlStatus1.Enabled = true;
                    }
                    else
                    {

                        e.Row.Cells[22].Text = "Please process this application in Concerned Department portal";
                        e.Row.Cells[22].Font.Bold = true;
                        ddlStatus1.Enabled = false;
                    }
                }
                else
                {
                    //if ((Session["User_Code"].ToString().Trim() == "404")) //irrigation to stop processing in tgipass even common details are not updated to them
                    //{
                    //    e.Row.Cells[22].Text = "Please process this application in Concerned Department portal";
                    //    e.Row.Cells[22].Font.Bold = true;
                    //    ddlStatus1.Enabled = false;
                    //}
                    //else
                    //{
                        e.Row.Cells[22].Text = "Please process this application in TS-iPASS portal";
                        ddlStatus1.Enabled = true;
                    //}
                }
                //}
                //else
                //{
                //    e.Row.Cells[22].Text = "Please process this application in TS-iPASS portal";
                //    ddlStatus1.Enabled = true;
                //}
                //}
                HyperLink h1 = (HyperLink)e.Row.Cells[8].Controls[0];
                HyperLink h2 = (HyperLink)e.Row.Cells[9].Controls[0];
                HyperLink h3 = (HyperLink)e.Row.Cells[10].Controls[0];
                HyperLink h4 = (HyperLink)e.Row.Cells[16].Controls[0];
                //HyperLink h5 = (HyperLink)e.Row.Cells[18].Controls[0];
                string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
                LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
                btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
                btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
                h1.Target = "_blank";
                //h1.NavigateUrl = "ViewCFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();  commented on 21.1.2019
                h1.NavigateUrl = "CFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                h2.Target = "_blank";
                h2.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                h3.Target = "_blank";
                h3.NavigateUrl = "frmQurieResponseStatus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                h4.Target = "_blank";
                h4.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
                // h5.Target = "_blank";
                //h5.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));
                DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
                TextBox txtPromotor = (TextBox)e.Row.Cells[11].FindControl("txtPromotor");
                Label Label378 = (Label)e.Row.Cells[11].FindControl("Label378");
                Label Label379 = (Label)e.Row.Cells[11].FindControl("Label379");
                Label LabelDiscription = (Label)e.Row.Cells[11].FindControl("LabelDiscription");
                TextBox txtAmount = (TextBox)e.Row.Cells[11].FindControl("txtAmount");

                HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
                hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

                HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo");
                hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

                HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo0");
                hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();

                HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo1");
                hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

                HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo2");
                hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();

                HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo3");
                hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();
                //if (Session["uid"].ToString().Trim() == "1027" || Session["uid"].ToString().Trim() == "1028")
                //{
                //    HyperLink h6 = (HyperLink)e.Row.Cells[19].Controls[0];
                //    h6.Target = "_blank";
                //    h6.NavigateUrl = "RPTTSSPDCL.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                //}
                DataSet dsquery = new DataSet();
                dsquery = Gen.GetQueryRaised(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value);
                if (dsquery.Tables[0].Rows.Count > 0)
                {

                    ddlStatus.Items.RemoveAt(3);
                    //ddlStatus.Items.RemoveAt(2);
                }

                if (Session["intDeptid"] != null && Session["User_Code"].ToString() == "1" || Session["intDeptid"] != null && Session["User_Code"].ToString() == "3" || Session["intDeptid"] != null && Session["User_Code"].ToString() == "13" || Session["intDeptid"] != null && Session["User_Code"].ToString() == "142"
                    || Session["intDeptid"] != null && Session["User_Code"].ToString() == "1016" || Session["intDeptid"] != null && Session["User_Code"].ToString() == "1018" || Session["intDeptid"] != null && Session["User_Code"].ToString() == "1019" || Session["intDeptid"] != null && Session["User_Code"].ToString() == "1020" || Session["User_Code"].ToString() == "15")
                {

                }
                else
                {
                    if (hdfGroundedNo1.Value == "34" || hdfGroundedNo1.Value == "28")//28. Added forest department also..
                    {
                    }
                    else
                    {
                        if (ddlStatus.Items.FindByValue("11") != null)
                            ddlStatus.Items.RemoveAt(ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("11")));
                    }
                }

                //if(Session["User_Code"].ToString() == "404")
                //{
                //    ddlStatus1.Enabled = false;
                //}


                HyperLink h6 = (HyperLink)e.Row.Cells[19].Controls[0];

                e.Row.Cells[19].Visible = true;
                h6.Target = "_blank";
                switch (Session["uid"].ToString().Trim())
                {
                    case "1027":
                        h6.NavigateUrl = "RPTTSNPDCL.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                        break;
                    case "1028":
                        h6.NavigateUrl = "RPTTSSPDCL.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                        break;
                    default:
                        e.Row.Cells[19].Visible = false;
                        break;
                }

                if (Session["User_Code"].ToString().Trim() == "1")
                {
                    grdDetails.Columns[21].Visible = true;
                }
                else
                {
                    grdDetails.Columns[21].Visible = false;
                }

                Button BtnSave = (Button)e.Row.Cells[12].FindControl("BtnSave");
                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim() != "")
                {
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim() == "34")
                    {
                        Cls_Dharnidata obj_dharanidata = new Cls_Dharnidata();
                        DataTable dt_dharani = obj_dharanidata.DB_statusdisabledformrocount(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim());
                        if (dt_dharani != null)
                        {
                            if (dt_dharani.Rows.Count > 0)//&& dt_dharani.Rows[n]["redirectcount"].ToString() !="0"
                            {
                                ddlStatus.Visible = false;
                                txtPromotor.Visible = false;
                                BtnSave.Visible = false;
                                //e.Row.Cells[11].Visible = false;
                                // e.Row.Cells[12].Visible = false;
                            }
                            else
                            {
                                ddlStatus.Visible = true;
                                BtnSave.Visible = true;
                            }
                        }
                        else
                        {
                            ddlStatus.Visible = true;
                            BtnSave.Visible = true;
                        }

                    }
                }

                //DataSet dsDCR = new DataSet();
                //dsDCR = checkDCRPortal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")));

                //if (Session["User_Code"].ToString().Trim() == "11" || Session["User_Code"].ToString().Trim() == "13")
                //{
                //    if (Convert.ToString(dsDCR.Tables[0].Rows[0]["DCRPORTAL"]) == "Y")
                //    {
                //        e.Row.Cells[22].Text = "Please process this application in Concerned Department portal";
                //        e.Row.Cells[22].Font.Bold = true;
                //        ddlStatus.Enabled = false;
                //    }
                //    else
                //    {
                //        e.Row.Cells[22].Text = "Please process this application in TS-iPASS portal";
                //        ddlStatus.Enabled = true;
                //    }
                //}

            }
        }

        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        Label Label378 = (Label)row.FindControl("Label378");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        Label Label379 = (Label)row.FindControl("Label379");
        Label LabelDiscription = (Label)row.FindControl("LabelDiscription");
        //DropDownList ddlCorporation1 = (DropDownList)row.FindControl("ddlCorporation");
        //DropDownList ddlWard = (DropDownList)row.FindControl("ddlWard");
        //GetWards(ddlWard, ddlCorporation1.SelectedValue);
        ////DropDownList ddlStatus = (DropDownList).FindControl("ddlStatus");
        //Button BtnSave = (Button)sender;
        //GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

        FileUpload fupIrrgFeasibiltyReprt = (FileUpload)row.FindControl("fupIrrgFsbltyRept");
        Button btnIrrgFeasibiltyReprt = (Button)row.FindControl("btnIrrgFsbltyRept");
        Label lblFeasblty = (Label)row.FindControl("lblIrrgFsbltyRept");

        if (ddlStatus.SelectedValue.ToString() == "5")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = false;
            txtAmount.Visible = false;
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {

            txtPromotor.Visible = true;
            Label378.Visible = true;
            LabelDiscription.Visible = true;

            LabelDiscription.Text = "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please mention on which act or rule,you are Rejecting?";
            string CloseWindow; CloseWindow = "alert('Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please mention on which act or rule,you are Rejecting?')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);
            // success.Visible = true;
            // Failure.Visible = false;
            //  lblmsg.Text = "Please Mention on which act or rule,you are Rejecting?";
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblmsg.Text + "');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please Mention on which act or rule,you are Rejecting?", true);

            string message = "Please mention on which act or rule,you are Rejecting?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            // string message = "Your request is being processed.";

            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());

            Label378.Text = "Reason For Rejection";
            Label379.Visible = false;
            txtAmount.Visible = false;

        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = true;
            txtAmount.Visible = true;
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = true;
            txtAmount.Visible = true;
            LabelDiscription.Visible = false;
            if (Convert.ToString(Session["uid"]) == "0000") //sowjanya
            {
                fupIrrgFeasibiltyReprt.Visible = true;
                btnIrrgFeasibiltyReprt.Visible = true;

            }
            else
            {
                fupIrrgFeasibiltyReprt.Visible = false;
                btnIrrgFeasibiltyReprt.Visible = false;
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            LabelDiscription.Visible = false;

            if (Convert.ToString(Session["uid"]) == "0000") //sowjanya
            {
                fupIrrgFeasibiltyReprt.Visible = true;
                btnIrrgFeasibiltyReprt.Visible = true;
                lblFeasblty.Visible = true;
            }
            else
            {
                fupIrrgFeasibiltyReprt.Visible = false;
                btnIrrgFeasibiltyReprt.Visible = false;
                lblFeasblty.Visible = false;
            }
        }
        else
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            LabelDiscription.Visible = false;
            lblFeasblty.Visible = false;
            fupIrrgFeasibiltyReprt.Visible = false;
            btnIrrgFeasibiltyReprt.Visible = false;
        }

        // if(ddlStatus.)
        //if()
    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        HyperLink h1 = (HyperLink)row.FindControl("h1");
        HyperLink h2 = (HyperLink)row.FindControl("h2");
        HyperLink h3 = (HyperLink)row.FindControl("h3");
        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");
        Label lblFsbltyReptName = (Label)row.FindControl("lblFsbltyReptName");
        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }
        int result = 0;
        result = Gen.insertDepartmentProcess(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());
        if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
        {
            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
            ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
            ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
            if (txtPromotor.Text == "")
            {
                lblmsg.Text = "Please Enter Query Description";
            }
            else
            {
                int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
                int i = Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);
                try
                {
                    int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFE", hdfGroundedNo1.Value);
                }
                catch (Exception ex)
                {

                }

                //Approvals status queryraised to nsws
                Cls_nswswebapiafterpayment obj_nsws = new Cls_nswswebapiafterpayment();
                string ApplicationID = hdfGroundedNo.Value; string DeptID = hdfGroundedNo0.Value;
                string ApprovalID = hdfGroundedNo1.Value;
                string CategoryType = "CFE"; string StatusType = "query";
                string sedqueryraisedtonswsapp = obj_nsws.callwebapitosendqueryraiseddata(ApplicationID, DeptID, ApprovalID, CategoryType);
                string approvalstatusqueryraised = obj_nsws.getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, StatusType);


                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
                if (dsMail.Tables[0].Rows.Count > 0)
                {
                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                }
                GetDetails();
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {
            int i = Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Y", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

            //Approvals status queryraised  to nsws
            Cls_nswswebapiafterpayment obj_nsws = new Cls_nswswebapiafterpayment();
            string ApplicationID = hdfGroundedNo.Value; string DeptID = hdfGroundedNo0.Value;
            string ApprovalID = hdfGroundedNo1.Value;
            string CategoryType = "CFE"; string StatusType = "query";
            string sedqueryraisedtonswsapp = obj_nsws.callwebapitosendqueryraiseddata(ApplicationID, DeptID, ApprovalID, CategoryType);
            string approvalstatusqueryraised = obj_nsws.getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, StatusType);


            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query and requested additional payment on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has raised a query  and requested additional payment on your application. Please respond to the query  in your login in TS-iPASS. Thank You.");
                //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            if (txtAmount.Text.Trim() == "")
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg.Text = "Please Eneter Additional Payment Amount";
                return;
            }
            if (Convert.ToString(Session["uid"]) == "0000")//sowjanya
            {
                if (lblFsbltyReptName.Text.Trim() == "")
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Please Upolad Feasibility Report";
                    return;
                }
            }
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text.Replace(",", ""), "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            DataSet dsMail = new DataSet();
            try
            {
                int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            if (Convert.ToString(Session["uid"]) == "0000") //sowjanya 1040
            {
                if (lblFsbltyReptName.Text.Trim() == "")
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Please Upolad Feasibility Report";
                    return;
                }
            }
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            try
            {
                int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {

            //if (txtPromotor.Text == "" || txtPromotor.Text == null)
            //{
            //    Failure.Visible = true;
            //    success.Visible = false;

            //    lblmsg0.Text = " Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.";

            //   // lblmsg0.Text = " File size should be less than 300KB";
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblmsg0.Text + "');", true);
            //    return;


            //   // return;
            //}
            if (txtPromotor.Text.Trim() != "")
            {

                int j = Gen.UpdateAdditionalpaymentsBeforePre(hdfGroundedNo.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, txtPromotor.Text, getclientIP());
                int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);

                //Approvals status rejected to nsws
                Cls_nswswebapiafterpayment obj_nsws = new Cls_nswswebapiafterpayment();
                string ApplicationID = hdfGroundedNo.Value; string DeptID = hdfGroundedNo0.Value;
                string ApprovalID = hdfGroundedNo1.Value;
                string CategoryType = "CFE"; string StatusType = "rejected";
                obj_nsws.getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, StatusType);

                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
                if (dsMail.Tables[0].Rows.Count > 0)
                {
                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                    //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                }
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Reason For Rejection";
            }
        }
        if (result > 0)
        {
            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Updated";
            if (ddlStatus.SelectedValue.ToString() == "16")
            {
                if (txtPromotor.Text.Trim() == "")
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Enter Reason For Rejection";
                }
            }
            ddlStatus.SelectedIndex = 0;
            txtAmount.Text = "";
            txtPromotor.Text = "";
        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";
        }
        GetDetails();
        //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
        //{
        //    Failure.Visible = true;
        //    success.Visible = false;
        //    lblmsg.Text = "Please Select Status";

        //}
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

    public DataSet checkDCRPortal(string intcfeid)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_CHECK_DCRPORTAL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intcfeid.Trim() == "" || intcfeid.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTCFEID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTCFEID", SqlDbType.VarChar).Value = intcfeid.ToString();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

        }

    }
    protected void btnIrrgFsbltyRept_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "", sFileDir = Server.MapPath("~\\Attachments");
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            FileUpload fupFsbltyReport = (FileUpload)row.FindControl("fupIrrgFsbltyRept");
            HiddenField hdfQuesID = (HiddenField)row.FindControl("hdfApplID");
            HiddenField hdfEnterpid = (HiddenField)row.FindControl("hdfGroundedNo"); //intCFEEnterpid
            HiddenField hdfDeptid = (HiddenField)row.FindControl("hdfGroundedNo0"); //intDeptid
            HiddenField hdfApprovalid = (HiddenField)row.FindControl("hdfGroundedNo1"); //intApprovalid
            Label lblFsbltyReptName = (Label)row.FindControl("lblFsbltyReptName");

            if (fupFsbltyReport != null && fupFsbltyReport.HasFile)
            {
                if (fupFsbltyReport.PostedFile != null && fupFsbltyReport.PostedFile.ContentLength > 0 && fupFsbltyReport.PostedFile.ContentType == "application/pdf")
                {
                    string sFileName = System.IO.Path.GetFileName(fupFsbltyReport.PostedFile.FileName);

                    newPath = System.IO.Path.Combine(sFileDir, hdfEnterpid.Value + "\\IrrigationFeasibiltyDocument\\" + hdfDeptid.Value + System.DateTime.Now.ToString("ddMMyyyyHHmmtt"));

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupFsbltyReport.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupFsbltyReport.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;

                    result = Gen.InsertImagedataApproval(hdfQuesID.Value, hdfEnterpid.Value, fupFsbltyReport.PostedFile.ContentType,
                        newPath, sFileName, "IrrigationFeasibiltyDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(),
                        "1000", DateTime.Now.ToString(), hdfDeptid.Value, hdfApprovalid.Value);

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFsbltyReptName.Text = fupFsbltyReport.FileName;
                        lblFsbltyReptName.Visible = true;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Upload PDF document only ";
                }

            }
            else
            {
                Failure.Visible = true;

                lblmsg0.Text = "Please Upload Feasibility Report ";
            }

        }
        catch (Exception)//in case of an error
        {

        }
    }
    protected void rptDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {


        try
        {
            if (Convert.ToString(Session["uid"]) == "1027" || Convert.ToString(Session["uid"]) == "1028")
            {
                //HtmlTableCell thFeasibility; HtmlTableCell tdFeasibility;
                if (e.Item.ItemType == ListItemType.Header)
                {
                    HtmlTableCell thFeasibility = (HtmlTableCell)e.Item.FindControl("thFeasibility");
                    thFeasibility.Visible = true;
                    var thWTL = e.Item.FindControl("thRejection") as HtmlTableCell;
                    if (thWTL != null)
                        thWTL.Visible = true;
                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HyperLink hplFeasibility = e.Item.FindControl("hplFeasibility") as HyperLink;
                    HtmlTableCell tdFeasibility = (HtmlTableCell)e.Item.FindControl("tdFeasibility");


                    HiddenField hdnhdnEntrID = (HiddenField)e.Item.FindControl("hdnEntrID");
                    tdFeasibility.Visible = true;


                    if (Convert.ToString(Session["uid"]) == "1027")
                        hplFeasibility.NavigateUrl = "RPTTSNPDCL.aspx?intApplicationId=" + hdnhdnEntrID.Value;
                    else if (Convert.ToString(Session["uid"]) == "1028")
                        hplFeasibility.NavigateUrl = "RPTTSSPDCL.aspx?intApplicationId=" + hdnhdnEntrID.Value;

                    var tdWTL = e.Item.FindControl("tdRejection") as HtmlTableCell;
                    if (tdWTL != null)
                        tdWTL.Visible = true;
                }
            }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void BtnRevoke_Click(object sender, EventArgs e)
    {
        try
        {
            Button BtnSave = (Button)sender;
            GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
            Button BtnReject = (Button)row.FindControl("BtnReject");
            BtnReject.Visible = false;
            TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject"); //For approval remarks
            if (!TxtRemarks.Visible)
                TxtRemarks.Visible = true;

            if ((TxtRemarks.Visible) && (TxtRemarks.Text.Trim() != ""))
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate", "RejectValidate();", true);
                //return;
            }
            else
            {
                //Response.Write("<script>alert('Please enter remarks');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate1", "RejectValidate1();", true);
                TxtRemarks.Focus();
                return;
            }



            HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
            //hdfApplID.Value = row.Cells[26].Text;
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            HyperLink h1 = (HyperLink)row.FindControl("h1");
            HyperLink h2 = (HyperLink)row.FindControl("h2");
            HyperLink h3 = (HyperLink)row.FindControl("h3");

            HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
            HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
            HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
            HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
            HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");

            LinkButton lnkuidno = (LinkButton)row.FindControl("LinkButton1");

            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
            ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
            ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
            // int j = Gen.UpdatetAppealApprovalnew(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value);
            int j = UpdatetAppealApprovalnew(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text);

            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Revoked your application. Thank You."); //+ Session["user_id"].ToString() +
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Revoked your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //}

                if (j > 0)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Successfully Updated";
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Failed..";
                }
                GetDetails();
                //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
                //{
                //    Failure.Visible = true;
                //    success.Visible = false;
                //    lblmsg.Text = "Please Select Status";

                //}

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //string UIDNO = Request.QueryString["UIDNO"].ToString();
                //string UIDNO = "LRG00600335772";//"MEG02000064425";//"SML00500064419";//"SML00500064419";
                string UIDNO = lnkuidno.Text;// "MEG01500315533 ";//
                ds = Gen.GetDepartmentonuid(UIDNO);

                if (ds != null)
                {
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        dt = ds.Tables[2];
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "35")//HMDA
                        {
                            DataSet dsdept = new DataSet();
                            string valueshmda = "";
                            string outputhmda = "";
                            string outpayhmda = "";
                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            valueshmda = dsdept.GetXml();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(valueshmda);
                            //string jsonText = JsonConvert.SerializeXmlNode(doc); // To convert JSON text contained in string json into an XML node XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                //hmdapplication.
                                //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                                hmdapplication = hmdaservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017
                                                                                            //Kindly contact to Administrator regarding post mapping configuration for revenue department.
                                DataSet dsdeptattachmentsHMDA = new DataSet();
                                dsdeptattachmentsHMDA = Gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplication.FileNo);// "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

                                //Kindly contact to administrator regarding add work flow.
                                string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                                hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                                if (hmdapplication.FileNo != "" && hmdapplication.FileNo != null)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.FileNo, "Y");
                                    int k = Gen.InsertDeptDateTracing("11", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.ErrorMessage, "N");
                                }
                            }
                        }
                        if (deptid == "31")//TSIIC APPEAL
                        {
                            DataSet dsdept = new DataSet();
                            string valueshmda = "";
                            string outputhmda = "";
                            string outpayhmda = "";
                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            valueshmda = dsdept.GetXml();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(valueshmda);
                            //string jsonText = JsonConvert.SerializeXmlNode(doc); // To convert JSON text contained in string json into an XML node XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                //hmdapplication.
                                //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                                tsiicapplication = tsiicservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017

                                DataSet dsdeptattachmentsTSIIC = new DataSet();
                                dsdeptattachmentsTSIIC = Gen.getattachmentdetailsonuid(UIDNO, deptid, tsiicapplication.FileNo);
                                //Kindly contact to administrator regarding add work flow.
                                string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
                                tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017//
                                if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", tsiicapplication.FileNo, "Y");
                                    int k = Gen.InsertDeptDateTracing("3", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", tsiicapplication.ErrorMessage, "N");
                                }
                            }
                        }
                        if (deptid == "4")//NPDCL
                        {
                            try
                            {
                                string valueNPDCL = "";
                                string outputnpdcl = "";
                                string npdclattachments = "";
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valueNPDCL = dsdept.GetXml();
                                outputnpdcl = tsnpdcl.insertAppealAgainstRejects(valueNPDCL);// tsnpdcl.insertTsipassUidDetaisls(valueNPDCL);
                                StringReader str = new StringReader(outputnpdcl);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdclout = dsout.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclout, "Y");
                                        }
                                        else
                                        {
                                            string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclouterror, "N");
                                        }
                                    }
                                }
                                //dsdeptattachments = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");
                                //npdclattachments = dsdeptattachments.GetXml();
                                //outputnpdcl = tsnpdcl.insertAllAttachments(npdclattachments);
                                //StringReader str1 = new StringReader(outputnpdcl);
                                //DataSet dsout1 = new DataSet();
                                //dsout1.ReadXml(str1);
                                //if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                                //{
                                //    if (dsout1.Tables[0].Columns.Contains("status"))
                                //    {
                                //        if (dsout1.Tables[0].Rows[0]["status"].ToString() == "S")
                                //        {
                                //            string npdclsattachment = dsout1.Tables[0].Rows[0]["status"].ToString();
                                //            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclsattachment, "Y");
                                //            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["deptId"].ToString(), dsdept.Tables[0].Rows[0]["questionniareId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                //        }
                                //        else
                                //        {
                                //            string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["status"].ToString();
                                //            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclsattachmenterror, "N");
                                //        }
                                //    }
                                //}
                            }
                            catch (Exception ex)
                            {
                                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                            }
                        }
                        if (deptid == "21" || deptid == "5" || deptid == "44")//FACTORIES
                        {
                            try
                            {
                                //FactoryService.plan factoryvo = new FactoryService.plan();
                                FactoryService.rawMaterial rawvo = new FactoryService.rawMaterial();
                                FactoryService.UpdateAppealAgainstRejection factoryvo = new FactoryService.UpdateAppealAgainstRejection();

                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    valuefactory = dsdept.GetXml();
                                    //outputfactory = factory.insertIntoPlanApproval(factoryvo);
                                    factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                    factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                    factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                                    factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();

                                    factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();
                                    factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                                    factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
                                    factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                                    factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
                                    factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Land_intMandalid"].ToString();
                                    factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                    factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                    factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Land_intVillageid"].ToString();
                                    factoryvo.hazardousNature = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                    factoryvo.installedHP = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                    factoryvo.mailID = dsdept.Tables[0].Rows[0]["Land_Email"].ToString();
                                    factoryvo.mobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                    factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factoryvo.planReferenceNumber = "NA";//dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.planType = dsdept.Tables[0].Rows[0]["ProposalFor"].ToString();
                                    factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                    factoryvo.ssiType = "0";// dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                                    factoryvo.workersToBeEmployedMen = dsdept.Tables[0].Rows[0]["DirectMale"].ToString();
                                    factoryvo.workersToBeEmployedWomen = dsdept.Tables[0].Rows[0]["DirectFemale"].ToString();

                                    FactoryService.rawMaterial[] lst = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[1];
                                        lst = new FactoryService.rawMaterial[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                            BBB.materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            lst[k] = BBB;
                                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                        }
                                        //rawvo.materialDescr
                                    }

                                    factoryvo.rawMaterials = lst;

                                    FactoryService.productsOutput[] product = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtproduct = new DataTable();
                                        dtproduct = dsdept.Tables[2];
                                        product = new FactoryService.productsOutput[dtproduct.Rows.Count];

                                        for (int m = 0; m < dtproduct.Rows.Count; m++)
                                        {
                                            FactoryService.productsOutput productvo = new FactoryService.productsOutput();
                                            productvo.product = dtproduct.Rows[m]["Manf_ItemName"].ToString();
                                            productvo.output = dtproduct.Rows[m]["OUTPUT"].ToString();
                                            product[m] = productvo;
                                        }
                                    }

                                    factoryvo.productsOutputs = product;

                                    FactoryService.saleLeaseDeed[] registrationdeed = null;
                                    FactoryService.sitePlan[] siteplan = null;
                                    FactoryService.buildingPlan[] buildingplan = null;
                                    FactoryService.partnershipDeed[] partnershipdeed = null;
                                    FactoryService.processFlowChart[] flowchat = null;
                                    FactoryService.panAadharCard[] panaadhar = null;
                                    FactoryService.additionalAttachment[] AdditionalAttachment = null;
                                    FactoryService.appealAttachment[] AppealAttachment = null;

                                    //factory.insertIntoPlanApprovalCompleted factoryoutput = new FactoryService.insertIntoPlanApprovalCompletedEventHandler();


                                    DataSet dsfactroy = new DataSet();
                                    dsfactroy = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");

                                    if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                                    {
                                        ///Registration Deed////

                                        if (dsfactroy.Tables[0].Rows.Count > 0)
                                        {
                                            DataTable dtregistrationdeed = new DataTable();
                                            dtregistrationdeed = dsfactroy.Tables[0];
                                            registrationdeed = new FactoryService.saleLeaseDeed[dtregistrationdeed.Rows.Count];

                                            for (int n = 0; n < dtregistrationdeed.Rows.Count; n++)
                                            {
                                                FactoryService.saleLeaseDeed registrationdeedvo = new FactoryService.saleLeaseDeed();
                                                registrationdeedvo.documentName = dtregistrationdeed.Rows[n]["FileName"].ToString();
                                                registrationdeedvo.documentPath = dtregistrationdeed.Rows[n]["Filepath"].ToString();
                                                registrationdeed[n] = registrationdeedvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtsiteplan = new DataTable();
                                            dtsiteplan = dsfactroy.Tables[1];
                                            siteplan = new FactoryService.sitePlan[dtsiteplan.Rows.Count];

                                            for (int o = 0; o < dtsiteplan.Rows.Count; o++)
                                            {
                                                FactoryService.sitePlan siteplanvo = new FactoryService.sitePlan();
                                                siteplanvo.documentName = dtsiteplan.Rows[o]["FileName"].ToString();
                                                siteplanvo.documentPath = dtsiteplan.Rows[o]["Filepath"].ToString();
                                                siteplan[o] = siteplanvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtbuildingplan = new DataTable();
                                            dtbuildingplan = dsfactroy.Tables[2];
                                            buildingplan = new FactoryService.buildingPlan[dtbuildingplan.Rows.Count];

                                            for (int p = 0; p < dtbuildingplan.Rows.Count; p++)
                                            {
                                                FactoryService.buildingPlan buildingplanvo = new FactoryService.buildingPlan();
                                                buildingplanvo.documentName = dtbuildingplan.Rows[p]["FileName"].ToString();
                                                buildingplanvo.documentPath = dtbuildingplan.Rows[p]["Filepath"].ToString();
                                                buildingplan[p] = buildingplanvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtpartnershipdeed = new DataTable();
                                            dtpartnershipdeed = dsfactroy.Tables[3];
                                            partnershipdeed = new FactoryService.partnershipDeed[dtpartnershipdeed.Rows.Count];

                                            for (int n = 0; n < dtpartnershipdeed.Rows.Count; n++)
                                            {
                                                FactoryService.partnershipDeed partnershipdeedvo = new FactoryService.partnershipDeed();
                                                partnershipdeedvo.documentName = dtpartnershipdeed.Rows[n]["FileName"].ToString();
                                                partnershipdeedvo.documentPath = dtpartnershipdeed.Rows[n]["Filepath"].ToString();
                                                partnershipdeed[n] = partnershipdeedvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[4].Rows.Count > 0)
                                        {
                                            DataTable dtflowchat = new DataTable();
                                            dtflowchat = dsfactroy.Tables[4];
                                            flowchat = new FactoryService.processFlowChart[dtflowchat.Rows.Count];

                                            for (int n = 0; n < dtflowchat.Rows.Count; n++)
                                            {
                                                FactoryService.processFlowChart flowchatvo = new FactoryService.processFlowChart();
                                                flowchatvo.documentName = dtflowchat.Rows[n]["FileName"].ToString();
                                                flowchatvo.documentPath = dtflowchat.Rows[n]["Filepath"].ToString();
                                                flowchat[n] = flowchatvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[5].Rows.Count > 0)
                                        {
                                            DataTable dtpanaadhar = new DataTable();
                                            dtpanaadhar = dsfactroy.Tables[5];
                                            panaadhar = new FactoryService.panAadharCard[dtpanaadhar.Rows.Count];

                                            for (int n = 0; n < dtpanaadhar.Rows.Count; n++)
                                            {
                                                FactoryService.panAadharCard panaadharvo = new FactoryService.panAadharCard();
                                                panaadharvo.documentName = dtpanaadhar.Rows[n]["FileName"].ToString();
                                                panaadharvo.documentPath = dtpanaadhar.Rows[n]["Filepath"].ToString();
                                                panaadhar[n] = panaadharvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[6].Rows.Count > 0)
                                        {
                                            DataTable dtAdditionalAttachment = new DataTable();
                                            dtAdditionalAttachment = dsfactroy.Tables[6];
                                            AdditionalAttachment = new FactoryService.additionalAttachment[dtAdditionalAttachment.Rows.Count];

                                            for (int n = 0; n < dtAdditionalAttachment.Rows.Count; n++)
                                            {
                                                FactoryService.additionalAttachment AdditionalAttachmentvo = new FactoryService.additionalAttachment();
                                                AdditionalAttachmentvo.documentName = dtAdditionalAttachment.Rows[n]["FileName"].ToString();
                                                AdditionalAttachmentvo.documentPath = dtAdditionalAttachment.Rows[n]["Filepath"].ToString();
                                                AdditionalAttachment[n] = AdditionalAttachmentvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[7].Rows.Count > 0)
                                        {
                                            DataTable dtAppealAttachment = new DataTable();
                                            dtAppealAttachment = dsfactroy.Tables[7];
                                            AppealAttachment = new FactoryService.appealAttachment[dtAppealAttachment.Rows.Count];

                                            for (int n = 0; n < dtAppealAttachment.Rows.Count; n++)
                                            {
                                                FactoryService.appealAttachment AppealAttachmentvo = new FactoryService.appealAttachment();
                                                AppealAttachmentvo.documentName = dtAppealAttachment.Rows[n]["FileName"].ToString();
                                                AppealAttachmentvo.documentPath = dtAppealAttachment.Rows[n]["Filepath"].ToString();
                                                AppealAttachment[n] = AppealAttachmentvo;
                                            }
                                        }
                                    }
                                    factoryvo.saleLeaseDeeds = registrationdeed;
                                    factoryvo.sitePlans = siteplan;
                                    factoryvo.buildingPlans = buildingplan;
                                    factoryvo.partnershipDeeds = partnershipdeed;
                                    factoryvo.processFlowCharts = flowchat;
                                    factoryvo.panAadharCards = panaadhar;
                                    factoryvo.additionalAttachments = AdditionalAttachment;
                                    factoryvo.appealAttachments = AppealAttachment;

                                    string OUTPUT = factory.updateAppealAgainstRejection(factoryvo);
                                    // factory.insertIntoPlanApprovalCompleted 
                                    //factory.insertIntoPlanApproval(factoryvo);
                                    // factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                    //factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                    if (OUTPUT == "SUCCESS")
                                    {
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", OUTPUT, "Y");
                                        //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", OUTPUT, "Y");
                                        int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                    }
                                    else
                                    {
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", OUTPUT, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
    }

    public int UpdatetAppealApprovalnew(string intCFEEnterpid, string Status, string Created_by, string stageid, string dept, string Approval, string Remarks)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetAppealApprovalnew";


        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();



        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@RevokeRemarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RevokeRemarks", SqlDbType.VarChar).Value = Remarks.Trim();


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

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        try
        {
            Button BtnReject = (Button)sender;
            GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
            Button BtnRevoke = (Button)row.FindControl("BtnRevoke");
            BtnRevoke.Visible = false;
            TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
            if (!TxtRemarks.Visible)
                TxtRemarks.Visible = true;

            if ((TxtRemarks.Visible) && (TxtRemarks.Text.Trim() != ""))
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate", "RejectValidate();", true);
                //return;
            }
            else
            {
                //Response.Write("<script>alert('Please enter remarks');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate1", "RejectValidate1();", true);
                TxtRemarks.Focus();
                return;
            }


            HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            HyperLink h1 = (HyperLink)row.FindControl("h1");
            HyperLink h2 = (HyperLink)row.FindControl("h2");
            HyperLink h3 = (HyperLink)row.FindControl("h3");

            HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
            HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
            HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
            HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
            HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");
            LinkButton lnkuidno = (LinkButton)row.FindControl("LinkButton1");
            int j = Gen.UpdatetAppealApprovalnewCOIReject(hdfGroundedNo.Value, "Rejected", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text.Trim(), getclientIP());

            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                try
                {
                    //cmf.SendMailTSiPASS("anandsharmavaranasi@gmail.com", "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Rejected your application with Remarks:- " + TxtRemarks.Text.Trim() + " . Thank You.");
                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + " . Thank You."); //+ Session["user_id"].ToString() +
                }
                catch (Exception ee)
                {
                    throw;
                }
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                try
                {
                    //cmf.SendSingleSMS("8500602468", "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Rejected your application with Remarks:- " + TxtRemarks.Text.Trim() + ". Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + ". Thank You.");
                }
                catch (Exception ee)
                {
                    throw;
                }
                if (j > 0)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Successfully Updated";
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Failed..";
                }
                //GetDetails();

            }

            ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate2", "RejectValidate2();", true);
            TxtRemarks.Text = "";
            TxtRemarks.Visible = false;
            GetDetails();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }

    }
}
