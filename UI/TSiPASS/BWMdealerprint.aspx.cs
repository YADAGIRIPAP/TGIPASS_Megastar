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
using System.Data.SqlClient;

public partial class UI_TSiPASS_BWMdealerprint : System.Web.UI.Page
{
    BMWClass clsBMW = new BMWClass();
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    General Gen = new General();
    String BWMdealerid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != "")
                {
                    BWMdealerid = Request.QueryString[0].ToString();
                    FillGrid();
                }
            }
           
        }
        catch (Exception ex)
        {
        }
    }

    public void FillGrid()
    {
        try
        {
            ds = Getbwmdealerapplication(BWMdealerid);

            //-------- td_EntrepreneurDetRen
            if (ds.Tables[0].Rows.Count != 0)
            {
                lblnameofthebwmdealer.Text = ds.Tables[0].Rows[0]["Health_care_establishmentname"].ToString().ToUpper();

                if (ds.Tables[0].Rows[0]["District_Name"].ToString().Trim() != "")
                {
                    lblDistrict0.Text = ds.Tables[0].Rows[0]["District_Name"].ToString().ToUpper();
                }
                if (ds.Tables[0].Rows[0]["Manda_lName"].ToString().Trim() != "")
                {
                    lblMandal0.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString().ToUpper();
                }
                if (ds.Tables[0].Rows[0]["Village_Name"].ToString().Trim() != "")
                {
                    lblvillage0.Text = ds.Tables[0].Rows[0]["Village_Name"].ToString().ToUpper();
                }
                if (ds.Tables[0].Rows[0]["Downloadlink"].ToString() != null && ds.Tables[0].Rows[0]["Downloadlink"].ToString() != "")
                {
                    pcbnew.Visible = true;
                    hylinkpcb.Visible = true;
                    hylinkpcb.NavigateUrl = ds.Tables[0].Rows[0]["Downloadlink"].ToString();
                }
                //lbldoorno.Text = ds.Tables[0].Rows[0]["batdoorno"].ToString();
                lblPincode0.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                //lbltelno.Text = ds.Tables[0].Rows[0]["Telephoneno"].ToString();
                //lblEmailId.Text = ds.Tables[0].Rows[0]["Email"].ToString().ToUpper();
                //lbllati.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
                //lbllong.Text = ds.Tables[0].Rows[0]["Longitude"].ToString().ToUpper();
                //lblgst.Text = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
                //lblbatdealervaldate.Text = ds.Tables[0].Rows[0]["ValidityofBatteryDealerRegistration"].ToString().ToUpper();
            }
        }



        catch (Exception ex)
        {

        }
    }

    public DataSet Getbwmdealerapplication(string intSBenid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("Usp_Get_Application_Form_Dtls_BWMdealer", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intSBenid.Trim() == "" || intSBenid.Trim() == null || intSBenid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bwmdealerid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bwmdealerid", SqlDbType.VarChar).Value = intSBenid;
            }

            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return ds;
    }
}
