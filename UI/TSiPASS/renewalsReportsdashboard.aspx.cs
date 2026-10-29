using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Text;

public partial class Default3 : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //FillDetails();
            if (Session["uid"] != null)
            {
                HyperLink5.NavigateUrl = "https://tsboilers.cgg.gov.in/ipassBoilerRenewal.do?IPASSUSER=" + Session["uid"].ToString().Trim();
                HyperLink4.NavigateUrl = "https://labour.telangana.gov.in/TrackApplicationStatus.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim();
                //HyperLink6.NavigateUrl = "https://tsboilers.cgg.gov.in/ipassBoilerRenewal.do?IPASSUSER=" + Session["uid"].ToString().Trim();
            }

        }

    }



}
