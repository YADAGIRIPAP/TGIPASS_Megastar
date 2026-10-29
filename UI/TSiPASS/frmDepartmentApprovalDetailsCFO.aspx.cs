using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee;
    decimal TotalFeeNExt;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");

            
        }

        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}


        




        if (!IsPostBack)
        {
            //if (Session["Applid"] != null || Session["Applid"] != "")
            //{
            //    //  Response.Redirect("frmDepartmentApprovalDetails.aspx");

            //}
            //else
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");

            //}

             DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            //if ( Session["Applid"].ToString().Trim() =="0")
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");
            //}

            DataSet ss = new DataSet();
            ss = Gen.GetQuesionaryID(Session["uid"].ToString());
            //hdfFlagID0.Value = .Tables[0].Rows[0][0].ToString();
            if (ss.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = ss.Tables[0].Rows[0][0].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }

            if (Session["ApplidA"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareRegCFO.aspx");
            }


                DataSet ds = new DataSet();
                ds = Gen.GetQuestionereisReceiptDetailsCFO(Session["ApplidA"].ToString().Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    //grdDetails.Columns[6].Visible = false;
                    grdDetails.DataBind();
                    //grdDetails.Columns[3].Visible = false;
                    //grdDetails.Columns[4].Visible = false;

            //        grdDetails.Columns[5].Visible = false;

                  //  grdDetails.Columns[6].Visible = false;
                }


           
           
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {


       
    }
    void clear()
    {

        
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        if (Session["ApplidA"].ToString().Trim() == "" || Session["ApplidA"].ToString().Trim() == "0")
        {

            Response.Redirect("frmQuesstionniareRegCFO.aspx");

        }
        else
        {

            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {


                    string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                    string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                    string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                    string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();


                    int s = Gen.insertDepartmentAprrovalNewCFO(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                }
                else
                {
                    string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                    string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                    string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                    string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                    int s = Gen.UpdDepartmentAprrovalNewCFO(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                }
            }



            Response.Redirect("frmCFOQuesbyattachmentDetails.aspx");

        }

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
        try
        {
            if (BtnSave1.Text == "Save")
            {

              




            }
            else
            {
               

            }
        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {
        }
    }



    protected void GetNewRectoInsertdr()
    {
        
    }
    protected void RdWhetherAlreadyApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)RdWhetherAlreadyApproved.NamingContainer;
        CheckBox ChkApproval = (CheckBox)row.FindControl("ChkApproval");

        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        
        if (RdWhetherAlreadyApproved.Items[0].Selected == true)
        {

            ChkApproval.Visible = false;
           // ChkApproval.Checked = false;
            row.Cells[6].Text = "0";
        }
        
        else
        {
             
             ChkApproval.Visible = true;
             ChkApproval.Checked = false;
             if (ChkApproval.Checked == true)
             {
                 row.Cells[6].Text = row.Cells[4].Text;
             }
             else
             {
                 row.Cells[6].Text = "0";
             }
             
        
        }
    }
    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        if (ChkApproval.Checked == true)
        {
            row.Cells[6].Text = row.Cells[4].Text;
           
        }
        else
        {
            row.Cells[6].Text = "0";  
            

        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
           // decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            //TotalFee = TotalFee + TotalFee1;
            //string s = "0";
            //if (e.Row.Cells[6].Text != "")
            //{
            //    s = e.Row.Cells[6].Text;
            //}
            //decimal TotalFee1a = Convert.ToDecimal(s);
            // TotalFeeNExt = TotalFeeNExt + TotalFee1a;

            HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
            HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
            HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");

            RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)e.Row.FindControl("RdWhetherAlreadyApproved");
            
            HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();        
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();
            
            

                //HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();

                HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim();
          


            DataSet dsappr = new DataSet();
            dsappr = Gen.GetQuestionaryAprovalsApplyDataCFO(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim());
            if (dsappr.Tables[1].Rows.Count > 0)
            {
                if (dsappr.Tables[1].Rows[0]["IsOffline"].ToString().Trim() != "N")
                {
                    RdWhetherAlreadyApproved.SelectedValue = RdWhetherAlreadyApproved.Items.FindByValue(dsappr.Tables[1].Rows[0]["IsOffline"].ToString().Trim()).Value;
                }
            }
            if (dsappr.Tables[0].Rows.Count > 0)
            {
                RdWhetherAlreadyApproved.SelectedValue = RdWhetherAlreadyApproved.Items.FindByValue(dsappr.Tables[0].Rows[0]["IsOffline"].ToString().Trim()).Value;
                //if (dsappr.Tables[0].Rows[0]["IsPayment"].ToString().Trim() == "Y")
                //{
                    ChkApproval.Checked = true;
                    ChkApproval.Enabled = false;
                //}
                
                if (RdWhetherAlreadyApproved.Items[0].Selected == true)
                {

                    ChkApproval.Visible = false;
                    e.Row.Cells[6].Text = "0";
                }
                else
                {

                    ChkApproval.Visible = true;
                 //   ChkApproval.Checked = false;
                    if (ChkApproval.Checked == true)
                    {
                        e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                    }
                    


                }

               
            }

            if (HdfApprovalid.Value == "33")//INDUSTRY DEPARTMENY USER CHARGES
            {
                RdWhetherAlreadyApproved.Items[1].Selected = true;
                RdWhetherAlreadyApproved.Enabled = false;
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[4].Text;
            }
            //if (HdfApprovalid.Value == "52")//LABOUR SHOPS AND ESTABLISHMENT 1988
            //{
            //    RdWhetherAlreadyApproved.Items[1].Selected = true;
            //    RdWhetherAlreadyApproved.Enabled = false;
            //    ChkApproval.Checked = true;
            //    ChkApproval.Enabled = false;
            //    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
            //}

            if (HdfApprovalid.Value == "52")//LABOUR SHOPS AND ESTABLISHMENT 1988
            {
                if (Session["uid"].ToString().Trim() == "60689" || Session["uid"].ToString().Trim() == "101657" || Session["uid"].ToString().Trim() == "69714"
                    || Session["uid"].ToString().Trim() == "78701" || Session["uid"].ToString().Trim() == "30666" || Session["uid"].ToString().Trim() == "75234"
                    || Session["uid"].ToString().Trim() == "96569" || Session["uid"].ToString().Trim() == "102436" || Session["uid"].ToString().Trim() == "102707"
                    || Session["uid"].ToString().Trim() == "102632" || Session["uid"].ToString().Trim() == "101908" || Session["uid"].ToString().Trim() == "88369"
                    || Session["uid"].ToString().Trim() == "95920" || Session["uid"].ToString().Trim() == "94917" || Session["uid"].ToString().Trim() == "102788"
                    || Session["uid"].ToString().Trim() == "101570" || Session["uid"].ToString().Trim() == "99007" || Session["uid"].ToString().Trim() == "101137"
                    || Session["uid"].ToString().Trim() == "103250" || Session["uid"].ToString().Trim() == "54500" || Session["uid"].ToString().Trim() == "76624")
                {
                    RdWhetherAlreadyApproved.Items[1].Selected = true;
                    RdWhetherAlreadyApproved.Enabled = true;
                    ChkApproval.Checked = false;
                    ChkApproval.Enabled = true;
                    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                }
                else if (Session["uid"].ToString().Trim() == "56882")
                {
                    RdWhetherAlreadyApproved.Items[1].Selected = true;
                    RdWhetherAlreadyApproved.Enabled = true;
                    ChkApproval.Checked = true;
                    ChkApproval.Enabled = true;
                    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                }
                else
                {
                    RdWhetherAlreadyApproved.Items[1].Selected = true;
                    RdWhetherAlreadyApproved.Enabled = true;
                    ChkApproval.Checked = false;
                    ChkApproval.Enabled = true;
                    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                }
            }

            if (HdfApprovalid.Value == "118")//TRADE LICENSE CFO
            {
                if (Session["uid"].ToString().Trim() == "60689" || Session["uid"].ToString().Trim() == "101657" || Session["uid"].ToString().Trim() == "69714"
                    || Session["uid"].ToString().Trim() == "78701" || Session["uid"].ToString().Trim() == "30666" || Session["uid"].ToString().Trim() == "75234"
                    || Session["uid"].ToString().Trim() == "96569" || Session["uid"].ToString().Trim() == "102436" || Session["uid"].ToString().Trim() == "102707"
                    || Session["uid"].ToString().Trim() == "102632" || Session["uid"].ToString().Trim() == "101908"
                    || Session["uid"].ToString().Trim() == "95920" || Session["uid"].ToString().Trim() == "94917" || Session["uid"].ToString().Trim() == "102788"
                     || Session["uid"].ToString().Trim() == "103250" || Session["uid"].ToString().Trim() == "54500" || Session["uid"].ToString().Trim() == "76624")
                {
                    RdWhetherAlreadyApproved.Items[1].Selected = true;
                    RdWhetherAlreadyApproved.Enabled = true;
                    ChkApproval.Checked = false;
                    ChkApproval.Enabled = true;
                    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                }
                else if (Session["uid"].ToString().Trim() == "56882" || Session["uid"].ToString().Trim() == "53512")
                {
                    RdWhetherAlreadyApproved.Items[1].Selected = true;
                    RdWhetherAlreadyApproved.Enabled = true;
                    ChkApproval.Checked = true;
                    ChkApproval.Enabled = true;
                    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                }
                else
                {
                    RdWhetherAlreadyApproved.Items[1].Selected = true;
                    RdWhetherAlreadyApproved.Enabled = true;
                    ChkApproval.Checked = false;
                    ChkApproval.Enabled = true;
                    e.Row.Cells[6].Text = e.Row.Cells[4].Text;
                }
            }
            if (HdfApprovalid.Value == "63")
            {
                if (dsappr.Tables[0].Rows.Count > 0)
                {
                    if ((dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "13" || dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "15") && dsappr.Tables[0].Rows[0]["intApprovalid"].ToString().Trim() == "27")
                    {
                        ChkApproval.Enabled = true;
                        ChkApproval.Checked = false;
                    }
                    else
                    {
                        ChkApproval.Enabled = false;
                        ChkApproval.Checked = false;
                    }
                }
                else
                {
                    ChkApproval.Enabled = false;
                    ChkApproval.Checked = false;
                }
            }
            if (HdfApprovalid.Value == "64")
            {
                if (dsappr.Tables[0].Rows.Count > 0)
                {
                    //if ((dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "13"  || dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "15")&& dsappr.Tables[0].Rows[0]["intApprovalid"].ToString().Trim() == "27")
                    //{
                    if ((dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "13" || dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "15") && dsappr.Tables[0].Rows[0]["intApprovalid"].ToString().Trim() == "63")
                    {
                        ChkApproval.Enabled = true;
                        ChkApproval.Checked = false;
                    }
                    else
                    {
                        ChkApproval.Enabled = false;
                        ChkApproval.Checked = false;
                    }
                    //}
                    //else
                    //{
                    //    ChkApproval.Enabled = false;
                    //    ChkApproval.Checked = false;
                    //}
                }
                else
                {
                    ChkApproval.Enabled = false;
                    ChkApproval.Checked = false;
                }
            }
            if (HdfApprovalid.Value == "68")
            {
                if (dsappr.Tables[0].Rows.Count > 0)
                {
                    if ((dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "13" || dsappr.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "15") && dsappr.Tables[0].Rows[0]["intApprovalid"].ToString().Trim() == "67")
                    {
                        ChkApproval.Enabled = true;
                        ChkApproval.Checked = false;
                    }
                    else
                    {
                        ChkApproval.Enabled = false;
                        ChkApproval.Checked = false;
                    }
                }
                else
                {
                    ChkApproval.Enabled = false;
                    ChkApproval.Checked = false;
                }
            }

        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[3].Text = "";//Total Fee
            e.Row.Cells[4].Text = TotalFee.ToString();
        }
    }
    protected void HdfAmount_ValueChanged(object sender, EventArgs e)
    {

    }
}
