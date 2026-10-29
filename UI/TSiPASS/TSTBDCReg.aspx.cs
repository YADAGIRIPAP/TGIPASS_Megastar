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

            Session["dtMyTabledr"] = createtabledr();
            Session["tmpdrDataTable"] = ((DataTable)Session["dtMyTabledr"]);

            if (Request.QueryString.Count > 0)
            {
                Failure.Visible = false;
                success.Visible = false;
                FillDetails();
                if (Session["userlevel"].ToString() == "1")
                {
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                BtnSave1.Text = "Update";
            }
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "1")
            {
                BtnDelete.Visible = true;
            }
            else
            {
                BtnDelete.Visible = false;
            }
            BtnSave1.Text = "Update";
        }
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {


        string ids = "";
        if (Request.QueryString.Count > 0)
        {
            ids = Request.QueryString[0].ToString();
        }
        else
        {
            ids = hdfID.Value;
        }

        Gen.BDCName = txtBDC.Text;
        Gen.intStateid = ddlState.SelectedValue;
        Gen.intCountieid = ddlCounties.SelectedValue;
        Gen.intPayamid = ddlpayam.SelectedValue;
        Gen.Address = txtaddress.Text;
        Gen.Email = txtemail.Text;
        Gen.Contact_No = txtcontact.Text;
        Gen.Status = ddlstatus.SelectedValue;


        if (((DataTable)Session["tmpdrDataTable"]).Rows.Count == 0)
        {
            lblmsg0.Text = "Please Add atleast one Member Details. ";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }


        System.Threading.Thread.Sleep(5000);

        if (BtnSave1.Text == "Save")
        {

            //DataSet dsUser = new DataSet();
            //dsUser = Gen.CheckUserid(txtuser.Text.Trim());
            
            //if (dsUser.Tables[0].Rows.Count > 0)
            //{
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    lblmsg0.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";
            //    txtuser.Text = "";
            //    txtpass.Text = "";
            //    return;
                
            //}

            int i = Gen.insrtBDC("0", Session["uid"].ToString(),txtuser.Text.ToString(), txtpass.Text.ToString());
            if (i != 999)
            {

                if (((DataTable)Session["tmpdrDataTable"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["tmpdrDataTable"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["tmpdrDataTable"]).Rows[m]["intMemid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertdrCouncilNewDetails(myDtNewRecdr);

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
            int i = Gen.insrtBDC(ids.ToString(), Session["uid"].ToString(), txtuser.Text.ToString(), txtpass.Text.ToString());

            if (i != 999)
            {

               

                     if (((DataTable)Session["tmpdrDataTable"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["tmpdrDataTable"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["tmpdrDataTable"]).Rows[m]["intMemid"].ToString().Trim() == "0")
                        {
                            ((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(hdfID.Value);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertdrCouncilNewDetails(myDtNewRecdr);

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
        BtnDelete.Visible = false;
        ddlState.SelectedIndex = 0;
        //ddlministry.Items.Insert(0, "--Select--");
        txtBDC.Text = "";
        ddlCounties.SelectedIndex = 0;
        ddlpayam.SelectedIndex = 0;
        txtaddress.Text = "";
        txtemail.Text = "";
        txtcontact.Text = "";
        ddlstatus.SelectedIndex = 0;
        txtuser.Text = "";
        txtpass.Text = "";
        ((DataTable)Session["tmpdrDataTable"]).Clear();
        gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
        gvpractical0.DataBind();
        txtuser.Enabled = true;
        txtpass.Enabled = true;
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        int i = Gen.deleteBDC(hdfID.Value);

        if (i == 1)
        {
            lblmsg.Text = "Deleted Successfully.";
            success.Visible = true;
            Failure.Visible = false;
            clear();
        }
        else if (i == 3)
        {
            lblmsg0.Text = "Not Possible.";
            success.Visible = false;
            Failure.Visible = true;
            clear();
        }
        else
        {
            lblmsg0.Text = "Please contact to Administrator.";
            success.Visible = false;
            Failure.Visible = true;
            clear();
        }

    }
    void FillDetails()
    {
        string ids = "";
        if (Request.QueryString.Count > 0)
        {
            ids = Request.QueryString[0].ToString();
        }
        else
        {
            ids = hdfID.Value;
        }

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.getBDCbyID(ids.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            txtBDC.Text = ds.Tables[0].Rows[0]["BDCName"].ToString();
            ddlState.SelectedValue = ddlState.Items.FindByValue(ds.Tables[0].Rows[0]["intStateid"].ToString()).Value;
            getcounties();
            ddlCounties.SelectedValue = ddlCounties.Items.FindByValue(ds.Tables[0].Rows[0]["intCountieid"].ToString()).Value;
            getPayams();
            ddlpayam.SelectedValue = ddlpayam.Items.FindByValue(ds.Tables[0].Rows[0]["intPayamid"].ToString()).Value;
            txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtcontact.Text = ds.Tables[0].Rows[0]["Contact_No"].ToString();
            ddlstatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
            if (ds.Tables[2].Rows.Count > 0)
            {
                txtuser.Text = ds.Tables[2].Rows[0]["User_id"].ToString();
                txtuser.Enabled = false;
                txtpass.Enabled = false;
                txtpass.TextMode = TextBoxMode.SingleLine;
                txtpass.Text = "*****"; //ds.Tables[2].Rows[0]["Password"].ToString();
            }
        }

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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("TSTBDCReg.aspx");
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcounties();
    }
    void getcounties()
    {
        ddlCounties.Items.Clear();
        ddlpayam.Items.Clear();
        if (ddlState.SelectedIndex != 0)
        {
            Gen.getCounties(ddlCounties, ddlState.SelectedValue);
        }
        else
        {
            ddlCounties.Items.Insert(0, "--Select--");
            ddlpayam.Items.Insert(0, "--Select--");

        }
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPayams();
    }
    void getPayams()
    {
        ddlpayam.Items.Clear();
        if (ddlCounties.SelectedIndex != 0)
        {
            Gen.getPayams(ddlpayam, ddlCounties.SelectedValue);
        }
        else
        {
            ddlpayam.Items.Insert(0, "--Select--");
        }
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

            fillTrademappingGriddr((DataTable)Session["tmpdrDataTable"],"BDC",txtauthorised.Text, txtdesignation.Text,RadioButtonList1.SelectedValue, txtmobile.Text, txtemail2.Text,Session["uid"].ToString());

            this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
            this.gvpractical0.DataBind();


            txtauthorised.Text = ""; txtdesignation.Text = ""; RadioButtonList1.SelectedIndex = 0; txtmobile.Text = ""; txtemail2.Text = "";

            //string dr = Label27.Text;
            //Label27.Text = "Domain Lab " + Convert.ToString(Convert.ToInt32(dr.Substring(11)) + 1);
            //Button1.Focus();

            // Commented by Srikanth on 20-08-2013 for Page Breakup
            // Added by Srikanth on 20-08-2013 for Page Breakup
            //hdnfocus.Value = btnAddNewPR.ClientID;

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

        dtrdr = tmpTabledr.NewRow();
        dtrdr["intMemid"] = "0";
        dtrdr["new"] = "0";
        dtrdr["MemType"] = MemType.Trim();
        dtrdr["intCPBid"] = "0";
        dtrdr["AuthorizedPerson"] = authorised.Trim();
        dtrdr["Designation"] = designation.Trim();
        dtrdr["MobileNo"] = mobile.Trim();
        dtrdr["Email"] = email2.Trim();
        dtrdr["Gender"] = gender.Trim();
          
         
        tmpTabledr.Rows.Add(dtrdr);


    }
    protected DataTable createtabledr()
    {
        Session["dtMyTabledr"] = new DataTable("drDetails");
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("new", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("AuthorizedPerson", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Designation", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("MobileNo", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Email", typeof(string));

        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Gender", typeof(string));

        

        ((DataTable)Session["dtMyTabledr"]).Columns.Add("Created_by", typeof(string));
        
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("MemType", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intCPBid", typeof(string));
        ((DataTable)Session["dtMyTabledr"]).Columns.Add("intMemid", typeof(string));


        return ((DataTable)Session["dtMyTabledr"]);
    }
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
        txtauthorised.Text = ""; txtdesignation.Text = ""; RadioButtonList1.SelectedIndex = 0; txtmobile.Text = ""; txtemail2.Text = "";
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

                //TextBox1.Text = "";
                //txtDomainArea.Text = "";
                //TextBox3.Text = "";
                //TextBox4a.Text = "";




            }
            else
            {
                if (((DataTable)Session["tmpdrDataTable"]).Rows[e.RowIndex]["new"].ToString().Trim() == "")
                {
                    int i = Gen.DeleteCouncilMemsInvolved(gvpractical0.DataKeys[e.RowIndex].Values["intMemid"].ToString());
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    txtauthorised.Text = ""; txtdesignation.Text = ""; RadioButtonList1.SelectedIndex = 0; txtmobile.Text = ""; txtemail2.Text = "";

                }
                else
                {
                    ((DataTable)Session["tmpdrDataTable"]).Rows.RemoveAt(e.RowIndex);
                    this.gvpractical0.DataSource = ((DataTable)Session["tmpdrDataTable"]);
                    this.gvpractical0.DataBind();

                    txtauthorised.Text = ""; txtdesignation.Text = ""; RadioButtonList1.SelectedIndex = 0; txtmobile.Text = ""; txtemail2.Text = "";

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



    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["tmpdrDataTable"];
        DataView dvdr = new DataView(myDtNewRecdr);
        dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();
    }
}
