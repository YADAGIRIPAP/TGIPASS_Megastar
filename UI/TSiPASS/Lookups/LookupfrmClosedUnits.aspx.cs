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
//creted by suresh on 14-1-2016 for lookup boma Development Comitte 
//table:td_BDCDet,Procedures:getBDCSearch

public partial class LookupBDC : System.Web.UI.Page
{
    #region Declaration
    General Gen = new General();
    
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        //if (!IsPostBack)
        //{
        //    getIPOS();
        //}
        if (!IsPostBack)
        {
            //Gen.getStates(ddlState);
            //fillgrid();
        }
    }
    #endregion


    //protected void getIPOS()
    //{
    //    DataSet dsnew = new DataSet();
    //    dsnew = Gen.GetIPOS(Session["uid"].ToString());

    //    ddlIPOname.DataSource = dsnew.Tables[0];
    //    ddlIPOname.DataTextField = "Dept_Name";
    //    ddlIPOname.DataValueField = "intUserid";
    //    ddlIPOname.DataBind();
    //    ddlIPOname.Items.Insert(0, "--Select--");
    //}
    void fillgrid()
    {
        string User = "";
        User = Session["uid"].ToString();

        DataSet ds = Gen.getClosedUnitsLoockp(User, ddlMonth.SelectedValue, ddlYear.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblMsg.Text = "No Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {

            ((LinkButton)e.Row.FindControl("LinkButton1")).Attributes.Add("onclick", "javascript:GetRowValue('" + DataBinder.Eval(e.Row.DataItem, "intClosedUnitid") + "')");
        }
    }
   

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtPromoterName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TxtNameofUnit_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlLTHT_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
