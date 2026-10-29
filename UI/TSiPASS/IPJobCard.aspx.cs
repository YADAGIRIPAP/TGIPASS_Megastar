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
    //Purpose : To Generating JOB Card
    //Tables used : tbl_BeneficiaryDet
    //Stored procedures Used :GetBenficiaryDetByIDForJobCard



    General Gen = new General();
    byte[] Photo = new byte[1];
    string PhotoFileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        if (!IsPostBack)
        {
            
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            FillDetails();
            
            //BtnSave1.Text = "Update";

        }

           
    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.GetBenficiaryDetByIDForJobCard(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            lblJobcard.Text = "TSiPASS-PW-"+ ds.Tables[0].Rows[0]["intBenid"].ToString();
            lblHHname.Text = ds.Tables[0].Rows[0]["NameofHousehold"].ToString();
            lblSpouse.Text = ds.Tables[0].Rows[0]["NameofSpouse"].ToString();
            lblRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Created_dt"].ToString()).ToString("dd-MM-yyyy");
            if (ds.Tables[0].Rows[0]["Sex"].ToString() == "M")
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            lblIncome.Text = ds.Tables[0].Rows[0]["FamilyIncome"].ToString();
            lblState.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
            lblCounti.Text = ds.Tables[0].Rows[0]["CountieName"].ToString();
            lblPayam.Text = ds.Tables[0].Rows[0]["PayamName"].ToString();
            lblBoma.Text = ds.Tables[0].Rows[0]["BomaName"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            lblAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
            //
            //lblWorkCode.Text = ds.Tables[0].Rows[0]["WorkCode"].ToString();


            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["PhotoFileName"].ToString() != "" && ds.Tables[1].Rows[0]["PhotoFileName"] != null)
                {
                    //lblFileName.Text = ds.Tables[1].Rows[0]["PhotoFileName"].ToString();

                    Image1.ImageUrl = "viewAttachemnt.aspx?id=" + Convert.ToString(hdfID.Value.ToString()).Trim() + "&Type=Appicant Photo";


                    if (ds.Tables[1].Rows[0]["Photo"].ToString().Trim() != "")
                    {
                        Photo = (byte[])ds.Tables[1].Rows[0]["Photo"];
                        Session["Photo"] = Photo;
                        Session["PhotoFileName"] = ds.Tables[1].Rows[0]["PhotoFileName"].ToString();
                    }

                }
                else
                {
                    //lblFileName.Text = "";
                }
            }



        }
    }    



    protected void BtnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

    }
}
