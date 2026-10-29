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
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class Default2 : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {

            DataSet ds = new DataSet();
            ds = Gen.GetQuestionereisReceiptDetails(Request.QueryString[0].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTreesToBeFelled0.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                LblSectionofExterprise.Text = ds.Tables[0].Rows[0]["Sec_EnterpriseName"].ToString().Trim();
                txtExtant.Text = ds.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim() + " (in Sq mtrs)";
                //txtValueOfLand.Text = ds.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
                //txtValueOfBulding.Text = ds.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
                //txtValueOfPlant.Text = ds.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
                //txtTotalValue.Text = ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();
                txtEnterprisesName.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim() + " Enterprise";
                txtActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString().Trim();
                txtPolutionCategory.Text = ds.Tables[0].Rows[0]["LineofActivityType"].ToString().Trim();
                txtProposedEmployement.Text = ds.Tables[0].Rows[0]["Prop_Emp"].ToString().Trim() + " Persons";
               // if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "2")
               // {
               //     txtPowerRequierement.Text = "Greater than 30 HP";
               // }
               // else if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "3")
                //{
                //    txtPowerRequierement.Text = "Greater than 500 HP";
                //  }
               // else
               // {
                //    txtPowerRequierement.Text = "Less than 30 HP";
               // }
                if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "1")
                {
                    txtPowerRequierement.Text = "Less than 30 HP";
                }
                else if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "2")
                {
                    txtPowerRequierement.Text = "Greater than or equals to 30 HP and less than or equals to 100 HP";
                }
                else if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "3")
                {
                    txtPowerRequierement.Text = "Greater than or equals to 101 HP and less than or equals to 500 HP";
                }
                else if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "4")
                {
                    txtPowerRequierement.Text = "Greater than or equals to 501 HP and less than or equals to 1500 HP";
                }
                else if (ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim() == "5")
                {
                    txtPowerRequierement.Text = "Greater than or equals to 1501 HP and less than or equals to 10000 HP";
                }
                else
                {
                    txtPowerRequierement.Text = "Greater than 10000 HP";
                }
                //  txtPowerRequierement.Text = ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim();
                txtLocationofUnit.Text = ds.Tables[0].Rows[0]["LocationofUnit"].ToString().Trim();
                txtApplicationType.Text = "CFE";
                if (ds.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "")
                {
                    txtWaterRequiredFrom.Text = ds.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "")
                {
                    if (txtWaterRequiredFrom.Text.Trim() != "")
                        txtWaterRequiredFrom.Text = txtWaterRequiredFrom.Text + ", " + ds.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim();
                    else
                        txtWaterRequiredFrom.Text = ds.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "")
                {
                    if (txtWaterRequiredFrom.Text.Trim() != "")
                        txtWaterRequiredFrom.Text = txtWaterRequiredFrom.Text + ", " + ds.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim();
                    else
                        txtWaterRequiredFrom.Text = ds.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim();
                }
                // txtWaterRequiredFrom.Text = ds.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() + "," + ds.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() + "," + ds.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim();
                txtWaterRequiredPerDay.Text = ds.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim() + " (in KLD)";
                if (ds.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim() == "Y")
                {
                    txtSpirit.Text = "Yes";
                }
                else
                {
                    txtSpirit.Text = "No";
                }
                //   txtSpirit.Text = ds.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim();
                txtConsitutionOfUnit.Text = ds.Tables[0].Rows[0]["Cons_of_UnitName"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim() == "Y")
                {
                    txtGeneratorRequirement.Text = "Yes";
                }
                else
                {
                    txtGeneratorRequirement.Text = "No";
                }
                // txtGeneratorRequirement.Text = ds.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim();
                txtHightOfBulding.Text = ds.Tables[0].Rows[0]["Hight_Build"].ToString().Trim() + " (In Meters)";
                txtBuiltUpArea.Text = ds.Tables[0].Rows[0]["Built_up_Area"].ToString().Trim() + " (In Square Meters)";
                if (ds.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim() == "Y" || ds.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim() == "M")
                {
                    txtAreaType.Text = "Municipal";
                }
                else
                {
                    txtAreaType.Text = "Rural";
                }
                // txtAreaType.Text = ds.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim();
                //  txtFellTrees.Text = ds.Tables[0].Rows[0]["Prop_Site"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["Prop_Site"].ToString().Trim() == "Y")
                {
                    txtFellTrees.Text = "Yes";
                }
                else
                {
                    txtFellTrees.Text = "No";
                }
                txtTreesToBeFelled.Text = ds.Tables[0].Rows[0]["NoofTrees"].ToString().Trim();

                grdDetails.DataSource = ds.Tables[1];
                grdDetails.DataBind();



                GvProjectdtls.DataSource = ds.Tables[3];
                GvProjectdtls.DataBind();

                GvProjectdtls.Rows[GvProjectdtls.Rows.Count - 1].Style["font-weight"] = "bold";

                foreach (GridViewRow row in GvProjectdtls.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.Attributes.CssStyle["text-align"] = "center";
                    }
                }

                if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "")
                {
                    if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() == "1")
                    {
                        txtApplicationType.Text = "Change of Land Use";

                    }
                    else if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() == "2")
                    {
                        txtApplicationType.Text = "Build Permission Approval";

                    }
                    else if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() == "3")
                    {
                        txtApplicationType.Text = "Both";
                    }
                    else 
                    {
                        txtApplicationType.Text = "";
                    }
                }
                else
                {
                    txtApplicationType.Text = "";
                }

                if (Convert.ToDecimal(ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString()) > 10000)
                {
                    string Message = "";
                    string mobileNo = "";

                    if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            mobileNo = ds.Tables[2].Rows[i]["MobileNO"].ToString();
                            Message = ds.Tables[2].Rows[i]["message"].ToString();
                            // SendSingleSMSnew(mobileNo, Message);
                        }
                    }
                }
            }
            else
            {
            }
        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            TotalFee = TotalFee + TotalFee1;

        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = TotalFee.ToString();
        }
    }

    public String SendSingleSMSnew(String mobileNo, String message)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }

    protected String encryptedPasswod(String password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        // static string result = System.Text.Encoding.UTF8.GetString(pp);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

    /// <summary>

    /// Method to Generate hash code 

    /// </summary>

    /// <param name="secure_key">your last generated Secure_key

    protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
        byte[] sec_key = sha1.ComputeHash(genkey);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < sec_key.Length; i++)
        {
            sb1.Append(sec_key[i].ToString("x2"));
        }
        return sb1.ToString();
    }

    //public string SendSingleSMSnew(String mobileNo, String message)
    //{
    //    //String username = "cgg-tipass";
    //    //String password = "tip@$$@2016";
    //    //String senderid = "TiPASS";
    //    String username = "TSIPASS";
    //    String password = "kcsb@786";
    //    String senderid = "TSIPAS";
    //    HttpWebRequest request;


    //    string responseFromServer = "";
    //    try
    //    {
    //        request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
    //        request.ProtocolVersion = HttpVersion.Version10;
    //        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
    //        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
    //        request.Method = "POST";
    //        String smsservicetype = "singlemsg"; //For single message.
    //        String query = "username=" + HttpUtility.UrlEncode(username) +
    //            "&password=" + HttpUtility.UrlEncode(password) +
    //            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
    //            "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
    //            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
    //            "&senderid=" + HttpUtility.UrlEncode(senderid);

    //        byte[] byteArray = Encoding.ASCII.GetBytes(query);
    //        request.ContentType = "application/x-www-form-urlencoded";
    //        request.ContentLength = byteArray.Length;
    //        Stream dataStream = request.GetRequestStream();
    //        dataStream.Write(byteArray, 0, byteArray.Length);
    //        dataStream.Close();
    //        WebResponse response = request.GetResponse();
    //        String Status = ((HttpWebResponse)response).StatusDescription;
    //        dataStream = response.GetResponseStream();
    //        StreamReader reader = new StreamReader(dataStream);
    //        responseFromServer = reader.ReadToEnd();
    //        reader.Close();
    //        response.Close();
    //        dataStream.Close();
    //        //  request.KeepAlive = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);

    //    }
    //    responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
    //    return responseFromServer.Trim();
    //    // return "402,1,0";
    //}

    protected void GvProjectdtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // set formatting for the category cell
            TableCell cell = e.Row.Cells[0];
            cell.Width = new Unit("15px");

            TableCell cell1 = e.Row.Cells[1];
            cell1.Width = new Unit("280px");

            if (e.Row.Cells.Count == 5)
            {
                TableCell celllast = e.Row.Cells[e.Row.Cells.Count - 1];
                celllast.Width = new Unit("200px");
            }



            // cell.Style["border-right"] = "2px solid #666666";

            // set formatting for value cells
            //for (int i = 2; i < e.Row.Cells.Count; i++)
            //{
            //    cell = e.Row.Cells[i];
            //    // right-align each of the column cells after the first
            //    // and set the width
            //    cell.HorizontalAlign = HorizontalAlign.Right;
            //    cell.Width = new Unit("110px");
            //    // alternate background colors
            //    //if (i % 2 == 1)
            //    //    cell.BackColor
            //    //        = System.Drawing.ColorTranslator.FromHtml("#EFEFEF");
            //    // check value columns for a high enough value
            //    // (value >= 8000) and apply special highlighting
            //}
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Style["border-bottom"] = "2px solid #666666";
                cell.BackColor = System.Drawing.Color.LightGray;
            }
        }

    }

}
