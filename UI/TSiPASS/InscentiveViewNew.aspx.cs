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
using BusinessLogic;

public partial class UI_TSiPASS_InscentiveViewNew : System.Web.UI.Page
{
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("Index.aspx", false);
                return;
            }
            if (!Page.IsPostBack)
            {
                int IncentveID = 0;

                IncentveID = Convert.ToInt32(Session["EntprIncentive"]);
                Session["Incentive_DateOfCommencement"] = Session["Incentive_isVehicle"] = Session["Incentive_GHMC"] = Session["Incentive_Caste"] = Session["Incentive_Sector"] = Session["Incentive_PHC"] = Session["Incentive_Category"] = null;

                //obcmf.FillGrid(objFetch.FetchIncentiveViewNew(Convert.ToInt32(Session["uid"].ToString()), Convert.ToInt32(IncentveID)), gvDetails, false);
                //Session["EntprIncentive"] = null;
                try
                {
                    DataTable dt = objFetch.FetchIncentiveViewNew(Convert.ToInt32(Session["uid"].ToString()), IncentveID);
                    DataSet dss = new DataSet();

                    //dss.Tables.Add(dt);
                    gvDetails.DataSource = dt;
                    gvDetails.DataBind();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    //protected void lbtIncentive_Click(object sender, EventArgs e)
    //{
    //    try
    //    {            
    //        GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);            

    //        obcmf.FillGrid(objFetch.FetchIncentiveTypesView(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text)),gvIncetiveTypes,false);
    //    }
    //    catch (Exception ex) { Errors.ErrorLog(ex); }
    //}

    //protected void lbtAttachments_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
    //        obcmf.FillGrid(objFetch.FetchIncetiveUploadsView(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text),0), gvAttachments, false);
    //    }
    //    catch (Exception ex) { Errors.ErrorLog(ex); }
    //}

    //protected void lbtVwatt_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
    //        obcmf.FillGrid(objFetch.FetchIncetiveUploadsView(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text),
    //                                                            Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).ToolTip)),
    //                        gvAttachments, false);
    //    }
    //    catch (Exception ex) { Errors.ErrorLog(ex); }
    //}

    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Label lb1 = (Label)e.Row.FindControl("lblEntrpId");
        //LinkButton btn1 = (LinkButton)e.Row.FindControl("lbtIncentive");
        //btn1.OnClientClick = "javascript:return Popup('" + lb1.Text + "')";
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
                Label lb = (Label)e.Row.FindControl("lblEntrpId");
                LinkButton btn = (LinkButton)e.Row.FindControl("lbtIncentive");

                //btn.Text = intUid;

                //btn.OnClientClick = "javascript:return Popup('" + lb.Text + "')";
                Response.Redirect("IncetivesNewFormDeptView.aspx?EntrpId=" + lb.Text);
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

}