using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddBomas : System.Web.UI.Page
{
    
    General Gen = new General();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (!IsPostBack)
        {
            
        }
       
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            //filldetails();

            BtnSave1.Text = "Update";
        }
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {        
        //Gen.BomaCode = txtBomaCode.Text;
        //Gen.intPayamid = ddlPayams.SelectedValue;
        //Gen.BomaName = txtBoma.Text;
        //Gen.Latitude = txtLatitude.Text;
        //Gen.Longitude = txtLongitude.Text;

        //int i = Gen.insertBomas("0", Session["uid"].ToString());

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
}
