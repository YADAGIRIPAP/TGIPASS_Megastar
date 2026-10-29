using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CheckPOITD : System.Web.UI.Page
{

    //designing and developed by siva as on 27-02-2016
    //Purpose : To Save the Project Details
    //Tables used : td_ProjectDet,tr_ProjectTarget
    //Stored procedures Used :InsUpdProjectDet,GetProjectDetailsByid



    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            Gen.getStates(ddlState);
            Gen.getIpDet(ddlIP);
            Gen.getAreaOfWork(ddlAreasofWork);

            if (Session["user_type"].ToString() == "IP")
            {
                ddlIP.SelectedValue = ddlIP.Items.FindByValue(Session["User_Code"].ToString()).Value;
                ddlIP.Enabled = false;                
            }

            Session["dtMyTabledr"] = createtabledr();
            Session["tmpdrDataTable"] = ((DataTable)Session["dtMyTabledr"]);
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "1")
            {
                //BtnDelete.Visible = true;
            }
            else
            {
                //BtnDelete.Visible = false;
            }
            BtnSave1.Text = "Update";
        }
    }


    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.GetProjectDetailsByid(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlIP.SelectedValue = ddlIP.Items.FindByValue(ds.Tables[0].Rows[0]["intIP"].ToString()).Value;
            ddlIP.Enabled = false;


            txtProjectName.Text = ds.Tables[0].Rows[0]["PrjName"].ToString();
            if (ds.Tables[0].Rows[0]["StartDate"].ToString() != "")
            txtStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"].ToString()).ToString("dd-MM-yyyy");
            if (ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
            txtEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"].ToString()).ToString("dd-MM-yyyy");
            if (ds.Tables[0].Rows[0]["PrjSanctionDate"].ToString()!="")
            txtActStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrjSanctionDate"].ToString()).ToString("dd-MM-yyyy");
            txtTargetBen.Text = ds.Tables[0].Rows[0]["TargetBeneficiary"].ToString();
            txtPrjCost.Text = ds.Tables[0].Rows[0]["ProjectCost"].ToString();
            txtPrjInchargeName.Text = ds.Tables[0].Rows[0]["PrjInchargeName"].ToString();
            txtPrjInchMobile.Text = ds.Tables[0].Rows[0]["PrjInchargeMobile"].ToString();
            txtPrjInchEmail.Text = ds.Tables[0].Rows[0]["PrjInchargeEmail"].ToString();
             ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                        

            if (ds.Tables[1].Rows.Count > 0)
            {

                DataTableReader rdp = new DataTableReader(ds.Tables[1]);
                IDataReader readerp = rdp;


                ((DataTable)Session["tmpdrDataTable"]).Clear();
                ((DataTable)Session["tmpdrDataTable"]).Load(readerp);
                gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                gvpractical0.DataBind();
                gvpractical0.Columns[0].Visible = false;

            }
            else
            {
                gvpractical0.DataSource = null;
                gvpractical0.DataBind();
            }


        }
    }    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (((DataTable)Session["tmpdrDataTable"]).Rows.Count == 0)
        {
            gvpractical0.DataSource = null;
            gvpractical0.DataBind();
            lblmsg0.Text = "Please Add atleast one Boma wise target. ";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }


        System.Threading.Thread.Sleep(5000);

        if (BtnSave1.Text == "Save")
        {
            int i = Gen.InsUpdProjectDet("0",ddlIP.SelectedValue, txtProjectName.Text, txtStartDate.Text, txtEndDate.Text, txtActStartDate.Text, txtTargetBen.Text, txtPrjCost.Text, txtPrjInchargeName.Text, txtPrjInchMobile.Text, txtPrjInchEmail.Text, ddlStatus.SelectedValue, Session["uid"].ToString());
            if (i != 999)
            {
                //siva as on 11-1-2016
                if (((DataTable)Session["tmpdrDataTable"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["tmpdrDataTable"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["tmpdrDataTable"]).Rows[m]["intPrjtarget"].ToString().Trim() == "0")
                        {
                            ((DataTable)Session["tmpdrDataTable"]).Rows[m]["intPrjid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertdrPrjTargetDetails(myDtNewRecdr);

                }


                lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {
            int i = Gen.InsUpdProjectDet(hdfID.Value, ddlIP.SelectedValue, txtProjectName.Text, txtStartDate.Text, txtEndDate.Text, txtActStartDate.Text, txtTargetBen.Text, txtPrjCost.Text, txtPrjInchargeName.Text, txtPrjInchMobile.Text, txtPrjInchEmail.Text, ddlStatus.SelectedValue, Session["uid"].ToString());

            if (i != 999)
            {

                //siva as on 11-1-2016
                if (((DataTable)Session["tmpdrDataTable"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["tmpdrDataTable"]).Rows.Count; m++)
                    {
                        //if (((DataTable)Session["tmpdrDataTable"]).Rows[m]["intPrjid"].ToString().Trim() == "0")
                        //{
                            ((DataTable)Session["tmpdrDataTable"]).Rows[m]["intPrjid"] = hdfID.Value;
                        //}
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertdrPrjTargetDetails(myDtNewRecdr);

                }

                lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
                //lblmsg.Text = "Added Successfully..!";
            }
        }
    }

    void clear()
    {
        BtnSave1.Text = "Save";
        txtProjectName.Text="";
        txtStartDate.Text="";
        txtEndDate.Text="";
        txtActStartDate.Text="";
        txtTargetBen.Text="";
        txtPrjCost.Text="";
        txtPrjInchargeName.Text="";
        txtPrjInchMobile.Text="";
        txtPrjInchEmail.Text = "";
        ddlStatus.SelectedIndex = 0;

        gvpractical0.DataSource = null;
        gvpractical0.DataBind();
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("IPProjectRegistration.aspx");
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {

            fillTrademappingGriddr((DataTable)Session["tmpdrDataTable"], ddlState.SelectedValue,ddlCounties.SelectedValue,ddlPayams.SelectedValue,ddlBoma.SelectedValue,txtProposedTarget.Text,ddlAreasofWork.SelectedValue,ddlWorkActivity.SelectedValue , Session["uid"].ToString(),ddlState.SelectedItem.Text,ddlCounties.SelectedItem.Text,ddlPayams.SelectedItem.Text,ddlBoma.SelectedItem.Text,ddlAreasofWork.SelectedItem.Text,ddlWorkActivity.SelectedItem.Text);

            this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
            this.gvpractical0.DataBind();

            ddlState.SelectedIndex = 0;
            ddlCounties.Items.Clear();
            ddlCounties.Items.Insert(0, "--Select--");
            ddlCounties.SelectedIndex=0;
            ddlPayams.Items.Clear();
            ddlPayams.Items.Insert(0, "--Select--");
            ddlPayams.SelectedIndex=0;

            ddlBoma.Items.Clear();
            ddlBoma.Items.Insert(0, "--Select--");
            ddlBoma.SelectedIndex=0;
            txtProposedTarget.Text="";
            ddlAreasofWork.SelectedIndex=0;

            ddlWorkActivity.Items.Clear();
            ddlWorkActivity.Items.Insert(0, "--Select--");
            ddlWorkActivity.SelectedIndex = 0;
            
            


        }
        catch (Exception ex)
        {
            //   lblresult.Text = ex.ToString();
        }
        finally
        {

        }
    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string intStateid,string intCountieid,string intPayamid,string intBomasid,string Proposedtarget, string intAreaofWork, string intWorkActivity,  string Created_by,string StateName,string CountieName,string PayamName,string BomaName, string AreaofWork, string WorkActivity)
    {

        dtrdr = tmpTabledr.NewRow();
        dtrdr["intPrjtarget"] = "0";
        dtrdr["new"] = "0";
        dtrdr["intStateid"] = intStateid.Trim();
        dtrdr["intCountieid"] = intCountieid.Trim();
        dtrdr["intPayamid"] = intPayamid.Trim();
        dtrdr["intBomasid"] = intBomasid.Trim();
        dtrdr["Proposedtarget"] = Proposedtarget.Trim();

        dtrdr["intAreaofWork"] = intAreaofWork.Trim();
        dtrdr["intWorkActivity"] = intWorkActivity.Trim();
        //,string ,string ,string 
        dtrdr["StateName"] = StateName.Trim();
        dtrdr["CountieName"] = CountieName.Trim();
        dtrdr["PayamName"] = PayamName.Trim();
        dtrdr["BomaName"] = BomaName.Trim();

        dtrdr["WorkActivity"] = WorkActivity.Trim();
        dtrdr["AreaofWork"] = AreaofWork.Trim();
        dtrdr["Created_by"] = Created_by.Trim();


        tmpTabledr.Rows.Add(dtrdr);


    }

    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["tmpdrDataTable"];
        DataView dvdr = new DataView(myDtNewRecdr);
        dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }

    protected DataTable createtabledr()
    {
        Session["dtMyTabledr"] = new DataTable("drDetails");
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("new", typeof(string));


        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intStateid", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intCountieid", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intPayamid", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intBomasid", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Proposedtarget", typeof(string));      
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Created_by", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intPrjid", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intAreaofWork", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intWorkActivity", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("AreaofWork", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("WorkActivity", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("StateName", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("CountieName", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("PayamName", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("BomaName", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intPrjtarget", typeof(string));
        
        

        return ((DataTable)Session["dtMyTabledr"]);
    }

    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {
                ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                this.gvpractical0.DataBind();
                
            }
            else
            {
                if (((DataTable)Session["tmpdrDataTable"]).Rows[e.RowIndex]["new"].ToString().Trim() == "")
                {
                    int i = Gen.DeleteProjectTargets(gvpractical0.DataKeys[e.RowIndex].Values["intPrjtarget"].ToString());
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    ddlState.SelectedIndex = 0;
                    ddlCounties.Items.Clear();
                    ddlCounties.Items.Insert(0, "--Select--");
                    ddlCounties.SelectedIndex = 0;
                    ddlPayams.Items.Clear();
                    ddlPayams.Items.Insert(0, "--Select--");
                    ddlPayams.SelectedIndex = 0;

                    ddlBoma.Items.Clear();
                    ddlBoma.Items.Insert(0, "--Select--");
                    ddlBoma.SelectedIndex = 0;
                    txtProposedTarget.Text = "";
                    ddlAreasofWork.SelectedIndex = 0;
                    ddlWorkActivity.SelectedIndex = 0;

                }
                else
                {
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    ddlState.SelectedIndex = 0;
                    ddlCounties.Items.Clear();
                    ddlCounties.Items.Insert(0, "--Select--");
                    ddlCounties.SelectedIndex = 0;
                    ddlPayams.Items.Clear();
                    ddlPayams.Items.Insert(0, "--Select--");
                    ddlPayams.SelectedIndex = 0;

                    ddlBoma.Items.Clear();
                    ddlBoma.Items.Insert(0, "--Select--");
                    ddlBoma.SelectedIndex = 0;
                    txtProposedTarget.Text = "";
                    ddlAreasofWork.SelectedIndex = 0;
                    ddlWorkActivity.SelectedIndex = 0;

                }

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
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPayams();
    }
    void getPayams()
    {
        ddlPayams.Items.Clear();
        if (ddlCounties.SelectedIndex != 0)
        {
            Gen.getPayams(ddlPayams, ddlCounties.SelectedValue);
        }
        else
        {
            ddlPayams.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlPayams_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBomas();
    }

    void getBomas()
    {
        ddlBoma.Items.Clear();
        if (ddlPayams.SelectedIndex != 0)
        {
            Gen.getBomas(ddlBoma, ddlPayams.SelectedValue);
        }
        else
        {
            ddlBoma.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcounties();
    }

    void getcounties()
    {
        ddlCounties.Items.Clear();
        ddlPayams.Items.Clear();
        if (ddlState.SelectedIndex != 0)
        {
            Gen.getCounties(ddlCounties, ddlState.SelectedValue);
        }
        else
        {
            ddlCounties.Items.Insert(0, "--Select--");
            ddlPayams.Items.Insert(0, "--Select--");

        }
    }
    protected void ddlAreasofWork_SelectedIndexChanged(object sender, EventArgs e)
    {
        getWorkActivities();
    }
    void getWorkActivities()
    {

        ddlWorkActivity.Items.Clear();
        
        if (ddlAreasofWork.SelectedIndex != 0)
        {
            Gen.getWorkActivities(ddlWorkActivity, ddlAreasofWork.SelectedValue);
        }
        else
        {
            ddlWorkActivity.Items.Insert(0, "--Select--");
            

        }
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        ddlState.SelectedIndex = 0;
        ddlCounties.Items.Clear();
        ddlCounties.Items.Insert(0, "--Select--");
        ddlCounties.SelectedIndex = 0;
        ddlPayams.Items.Clear();
        ddlPayams.Items.Insert(0, "--Select--");
        ddlPayams.SelectedIndex = 0;

        ddlBoma.Items.Clear();
        ddlBoma.Items.Insert(0, "--Select--");
        ddlBoma.SelectedIndex = 0;
        txtProposedTarget.Text = "";
        ddlAreasofWork.SelectedIndex = 0;
        ddlWorkActivity.SelectedIndex = 0;
    }
}
