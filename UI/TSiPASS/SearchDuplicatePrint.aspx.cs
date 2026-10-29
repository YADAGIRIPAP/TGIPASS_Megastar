using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//creted by suresh on 14-1-2016 for lookup payam Development Name 
//table:td_PDCDet,Procedures:getBDCSearch

public partial class LookupPAD : System.Web.UI.Page
{
    #region Declaration
    General Gen = new General();
    
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        if (!IsPostBack)
        {
            ////Gen.getStates(ddlState);
            ////fillgrid();
        }
    }
    #endregion


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = Gen.getreceiptDetails(txtTrnsNo.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
            Response.Redirect("DuplicatePrintReceipt.aspx?prj=" + txtTrnsNo.Text.ToString().Trim());

        }
        else
        {
            lblMsg.Text = "No Records found.";
           
        }

      
    }
   
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
   
}
