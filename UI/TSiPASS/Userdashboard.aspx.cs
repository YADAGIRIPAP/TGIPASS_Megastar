using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSIPASS_Userdashboard : System.Web.UI.Page
{
    string result = "";
    public static string StageId { get; set; }
    public static DataSet GDs { get; set; }
    public static int uid { get; set; }
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)

    {
        if (Session["uid"] != null)
        {
            uid = Convert.ToInt32(Session["uid"]);
            if (!IsPostBack)
            {
                bindData();
            }

        }
        else
        {
            Response.Redirect("~/TSHome.aspx");
        }
    }


    public void bindData()
    {
        SqlParameter[] p = new SqlParameter[] {
           new SqlParameter("@createdby",SqlDbType.Int),
        };

        p[0].Value = uid;

        GDs = Gen.GenericFillDs("USP_userdashboard", p);

        string gghf = GDs.Tables[0].Columns[7].ToString();

        if (GDs.Tables[0].Rows.Count > 0)
        {
            gvdetailsnew.DataSource = GDs.Tables[0];
            gvdetailsnew.DataBind();

        }

    }


    protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ViewState["ApplicationId"] = e.Row.Cells[1].Text;


            Label lblA = e.Row.FindControl("lblRmTypeid") as Label;

            Label lbls = e.Row.FindControl("lblname") as Label;

            HyperLink lnk_downloadcert = e.Row.FindControl("lnk_downloadcert") as HyperLink;
            lnk_downloadcert.Visible = false;
            string AttachmentCertificate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AttachmentCertificate"));
            

            ViewState["lblid"] =  lblA.Text;


            string  intstageid =lblA.Text.ToString();

            int stageid;


            if (intstageid==null || intstageid=="")
            {
                stageid = 0;
            }
            else
            {
                stageid = Convert.ToInt32(intstageid);
            }
            

            Button lblAssId = e.Row.FindControl("anchortaglin") as Button;

            Button lblAd = e.Row.FindControl("anchortagli") as Button;

            if (Convert.ToString(Session["uid"]) == "378226")
            {
                lblAssId.Enabled = false;
                // lblAssId.Visible = false;
                //e.Row.Cells[9].Visible = false;
            }
            if (stageid >= 3)
            {
                lblAssId.Text = "Complete Application";
                lblAssId.Visible = true;

            }
            else
            {
                lblAssId.Text = "Incomplete Application";
                lblAssId.Visible = true;
            }


            if(stageid==16)
            {

                lbls.Text = "Rejected";
                lbls.CssClass = "LabelGrey";
            }
            else if (stageid==13)
            {

                lbls.Text = "Approved";
                lbls.CssClass = "labelgreen";
                if (!string.IsNullOrEmpty(AttachmentCertificate))
                {
                    lnk_downloadcert.Visible = true;
                    lnk_downloadcert.NavigateUrl = AttachmentCertificate;
                }
            }
            else if(stageid==19)
            {
                lbls.Text = "Differed";
                lbls.CssClass = "labelblue";

            }
            else if(stageid==5)
            {

                lbls.Text = "Query Raised";
                lbls.CssClass = "labeldark";
            }
        }
    }



    public DataSet GetTSIICdata(Int64 uid, Int64 appid, string form)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@createdby",SqlDbType.Int),
                      new SqlParameter("@APPID",SqlDbType.Int),
                 new SqlParameter("@form1",SqlDbType.VarChar),
                };
            p[0].Value = uid;
            p[1].Value = appid;
            p[2].Value = form;


            GDs = Gen.GenericFillDs("USP_GET_tsiiccheckdata", p);


            return GDs;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }




    protected void anchortaglin_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        string id = row.Cells[1].Text;
        Label TypeId = (Label)row.FindControl("lblRmTypeid");




        if (TypeId.Text.ToString() == "2")
        {

            string newurl = "frmtsiicplotallotment.aspx?AppId=" + id;

            Response.Redirect(newurl);

        }
        else
        {

            string newurl = "UserFormView.aspx?AppId=" + id;
            Response.Redirect(newurl);
        }

   }



    //public void anchortaglinks_Click(object sender,EventArgs e)
    //{

    //    Button btn = (Button)sender;
    //    GridViewRow row = (GridViewRow)btn.NamingContainer;
    //    string id = row.Cells[1].Text;
    //    Label TypeId = (Label)row.FindControl("lblRmTypeid");


    //    if (stageid >= 3)
    //    {
    //        lblAssId.Text = "Complete Application";
    //        lblAssId.Visible = true;

    //    }
    //    else
    //    {
    //        lblAssId.Text = "Incomplete Application";
    //        lblAssId.Visible = true;
    //    }
    //}

    protected void anchortagli_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        string id = row.Cells[1].Text;

   }





}

