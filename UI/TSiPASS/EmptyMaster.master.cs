using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class EmptyMaster : System.Web.UI.MasterPage
{

    comFunctions cmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session.Count != 0)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                if (!Page.IsPostBack)
                    Session.Abandon();
            }
            

            StringBuilder line = new StringBuilder();
            StringBuilder sbNews = new StringBuilder();
            DataSet ds = new DataSet();
            ds = objcommon.GetHomepagecontete();
           
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                string base64String1;
                string CMSrc = "";
                if (!string.IsNullOrEmpty(ds.Tables[2].Rows[0]["Image"].ToString()))
                {
                    byte[] bytes1 = (byte[])ds.Tables[2].Rows[0]["Image"];
                    base64String1 = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                    // UserImage.Src = "data:image/jpeg;base64," + base64String;
                    CMSrc = "data:image/jpeg;base64," + base64String1;
                    imgcm.Src = CMSrc;
                }
            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                string base64String2;
                string itSrc = "";
                if (!string.IsNullOrEmpty(ds.Tables[3].Rows[0]["Image"].ToString()))
                {
                    byte[] bytes1 = (byte[])ds.Tables[3].Rows[0]["Image"];
                    base64String2 = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                    // UserImage.Src = "data:image/jpeg;base64," + base64String;
                    itSrc = "data:image/jpeg;base64," + base64String2;
                    imgitm.Src = itSrc;
                }
            }
            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
            }
        }
    }



}
