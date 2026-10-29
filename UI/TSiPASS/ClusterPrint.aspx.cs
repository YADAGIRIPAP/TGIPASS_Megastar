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


public partial class UI_TSiPASS_ClusterPrint : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string ClusterId1 = "";
            if (Request.QueryString["ClusterID"] != null && Request.QueryString["ClusterID"].ToString() != "")
            {
                ClusterId1 = Request.QueryString["ClusterID"].ToString();
            }
            if ((Session["clusterId"] != null && Session["clusterId"].ToString() != "") || ClusterId1 != "")
            {
                DataSet dsCluster = new DataSet();
                string ClusterId = "";
                if (Session["clusterId"] != null)
                {
                    ClusterId = Session["clusterId"].ToString();
                }
                if (ClusterId1 != "")
                {
                    ClusterId = ClusterId1;
                }
                dsCluster = Gen.GetClusterInformation(Convert.ToInt32(ClusterId));
                if (dsCluster != null && dsCluster.Tables.Count > 0 && dsCluster.Tables[0].Rows.Count > 0)
                {
                    lblMandalName.Text = dsCluster.Tables[0].Rows[0]["Manda_lName"].ToString();
                    lblVillageName.Text = dsCluster.Tables[0].Rows[0]["Village_Name"].ToString();

                    lblLineofActivity.Text = dsCluster.Tables[0].Rows[0]["LineofActivity"].ToString();
                    lblSubStationName.Text = dsCluster.Tables[0].Rows[0]["Infra_SubStation"].ToString();
                    lblCapacity.Text = dsCluster.Tables[0].Rows[0]["Infra_Sub_Capacity"].ToString();
                    lblTrainingFacility.Text = dsCluster.Tables[0].Rows[0]["Infra_Training_Facility"].ToString();
                    lblRawMater.Text = dsCluster.Tables[0].Rows[0]["Raw_Material_Source"].ToString();
                    lblMajorMarkets.Text = dsCluster.Tables[0].Rows[0]["Major_Markets"].ToString();

                    if (dsCluster.Tables.Count > 1 && dsCluster.Tables[1].Rows.Count > 0)
                    {
                        gvUnitDetails.DataSource = dsCluster.Tables[1];
                        gvUnitDetails.DataBind();
                    }
                    if (dsCluster.Tables.Count > 2 && dsCluster.Tables[2].Rows.Count > 0)
                    {
                        gvCommonFacility.DataSource = dsCluster.Tables[2];
                        gvCommonFacility.DataBind();
                    }
                    if (dsCluster.Tables.Count > 3 && dsCluster.Tables[3].Rows.Count > 0)
                    {
                        gvExports.DataSource = dsCluster.Tables[3];
                        gvExports.DataBind();
                    }
                    if (dsCluster.Tables.Count > 4 && dsCluster.Tables[4].Rows.Count > 0)
                    {
                        gvIndustriesList.DataSource = dsCluster.Tables[4];
                        gvIndustriesList.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblerrMsg.Text = ex.Message;
            //lblerrMsg.CssClass = "errormsg";
        }
    }
}