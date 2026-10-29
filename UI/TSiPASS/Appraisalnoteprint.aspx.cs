using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_Appraisalnoteprint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printTD.Visible = true;

        if (txtINCNoEntry.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        }




        //if(txtPrintINCID.Text=="")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        //}
        else
        {
            //    string incID = txtPrintINCID.Text;

            //    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            //    SqlTransaction transaction = null; connection.Open();
            //    transaction = connection.BeginTransaction();
            //    string testss = Session["incentiveid"].ToString();

            //    string testss1 = Session["uid"].ToString();

            //    SqlCommand com = new SqlCommand();
            //    com.CommandType = CommandType.StoredProcedure;
            //    com.CommandText = "[checkiincAppraisal]";

            //    com.Transaction = transaction;
            //    com.Connection = connection;

            //    com.Parameters.AddWithValue("@lineofact", Manf_ItemName.ToString());
            //    com.Parameters.AddWithValue("@lineofact_unit", strunit.ToString());
            //    com.Parameters.AddWithValue("@lineofact_qty", Manf_Item_Qty.ToString());
            //    com.Parameters.AddWithValue("@lineofact_instCap", Manf_units.ToString());
            //    com.Parameters.AddWithValue("@lineofact_value", Manf_Item_Price.ToString());
            //    com.Parameters.AddWithValue("@incentiveid", testss.ToString());
            //    com.Parameters.AddWithValue("@createdby", testss1.ToString());
            //    com.Parameters.AddWithValue("@updDel", updDelete.ToString());
            //    //com.Parameters.Add("@retval", SqlDbType.Int);
            //    //com.Parameters["@retval"].Direction = ParameterDirection.Output;

            //    //com.ExecuteNonQuery();

            //    //com.ExecuteNonQuery();
            //    //int iCount = 

            //    //object retval =  com.ExecuteScalar();

            //    string firstColumn = Convert.ToString(com.ExecuteScalar());

            //    transaction.Commit();
            //    string retvals = firstColumn.ToString();
            //    //com.ExecuteNonQuery();
            //    //string retval = com.Parameters["@rretVAl"].Value.ToString();

            //    if (retvals == "not done")
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity already exists!');", true);


            //    //if (retval == "deleted")
            //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity deleted');", true);
            Response.Redirect("appraisalNote2.aspx?incid=" + txtINCNoEntry.Text.ToString() + "&mstid=6");
        }


    }
}