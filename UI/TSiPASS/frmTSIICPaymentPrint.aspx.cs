using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_frmTSIICPaymentPrint : System.Web.UI.Page
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
            Response.Redirect("~/Home.aspx");
        }
    }

    public void bindData()
    {
        SqlParameter[] p = new SqlParameter[] {
           new SqlParameter("@createdby",SqlDbType.VarChar),
        };


        //p[0].Value = Convert.ToInt32(Session["uid"].ToString());
        p[0].Value = uid;

        GDs = Gen.GenericFillDs("USP_GET_tsiiccheckdata_Payment", p);


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

            ViewState["lblid"] = lblA.Text;

            Button lblAssId = e.Row.FindControl("anchortaglin") as Button;

            //Button lblAd = e.Row.FindControl("anchortagli") as Button;
            if (lblA.Text.ToString() != "" && lblA.Text.ToString() != null && lblA.Text.ToString() != "2")
            {
                lblAssId.Text = "Print Receipt";
                lblAssId.Visible = true;

            }          

        }
    }


    protected void anchortaglin_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        string id = row.Cells[1].Text;
        string Amount = row.Cells[8].Text;
        Label TypeId = (Label)row.FindControl("lbltransno");

        //if (TypeId.Text.ToString() == "2")
        //{
            //string newurl = "IpassPrintReceiptPlot.aspx?AppId=" + id;
            //Response.Redirect(newurl);
        Session["Amount"] = Amount; //paymentresponseVOsobj.TxnAmount_4;
            Session["RefNo"] = id;
            Session["TranRefNo"] = TypeId.Text.Trim().ToString();

            Response.Redirect("IpassReceiptPrintTSIIC.aspx");

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassReceiptPrintTSIIC.aspx';", true);
        //}
        //else
        //{

        //    string newurl = "UserFormView.aspx?AppId=" + id;
        //    Response.Redirect(newurl);
        //}
    }


    //protected void anchortagli_Click(object sender, EventArgs e)
    //{

    //    Button btn = (Button)sender;
    //    GridViewRow row = (GridViewRow)btn.NamingContainer;
    //    string id = row.Cells[1].Text;

    //}
}