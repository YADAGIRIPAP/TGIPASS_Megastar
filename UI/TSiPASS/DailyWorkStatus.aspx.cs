using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSiPASS_DailyWorkStatus : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtdateofentry.Text = DateTime.Now.ToShortDateString();
        BindUsername();
    }
    public void BindUsername()
    {
        DataSet dausername = new DataSet();
        dausername = Getusername(Session["uid"].ToString());
        if (dausername.Tables[0].Rows.Count > 0)
        {
           txtnameofemployee.Text= Convert.ToString(dausername.Tables[0].Rows[0]["User_name"]);

        }
    }
    public DataSet Getusername(string CREATEDBY)
    {

        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@createdby",SqlDbType.VarChar)
       };
        pp[0].Value = CREATEDBY;
        Dsnew = Gen.GenericFillDs("GetUsername", pp);
        return Dsnew;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

            if (txtworkdone.Text == "" || txtworkdone.Text == null)
            {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter work done status');", true);
              return;
                 }
        else
            {
                
            
            int i = 0;
            i = Gen.InserttWorkStatus( Session["uid"].ToString(),txtnameofemployee.Text,
                txtdateofentry.Text, txtworkdone.Text);

            if (i > 0)
            {
                if (i == 1)
                {
                    //lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('TODAYS WORK STATUS UPDATED..!');", true);
                    return;
                }

                else if(i==2)
                {

                    //lblmsg.Text = "Added Successfully..!";
                   // success.Visible = true;
                   // Failure.Visible = false;

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('WORK STATUS ALREDAY UPDATED TODAY..!');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('RECORD SUBMISSION FAILED..!');", true);
                    return;
                }
            }
        }
    }



}