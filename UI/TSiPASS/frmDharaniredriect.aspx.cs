using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;


public partial class UI_TSiPASS_frmDharaniredriect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // string DharaniApprovalID = Convert.ToString(Session["DharaniApprovalID"]);
        //string DharaniDeptid =Convert.ToString(Session["DharaniDeptid"]);
        string intQuessionaireid = Convert.ToString(Session["Applid"]);
        //string stageID = "2";


        string secretKey = ConfigurationManager.AppSettings["DharanisecretKey"].ToString();
        byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        //string slatkey = Guid.NewGuid().ToString();
        //slatkey is intquestionerreid
        //string slatkey = "50001";

        string userId = Session["uid"].ToString().Trim();
        Session["userId"] = Convert.ToString(userId).Trim();

             string slatkey = Convert.ToString(intQuessionaireid).Trim();
        Session["Saltkey"] = Convert.ToString(slatkey);
        //byte[] saltBytes = Encoding.UTF8.GetBytes(slatkey);
       
        string source = slatkey + secretKey;
        //string source = "1245447904f55c633d8b520cf05930809849605e306c1";
        using (SHA1 sha1Hash = SHA1.Create())
        {
            //From String to byte array
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
            string hashCode = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            Session["Hashcode"] = hashCode;
            //  Console.WriteLine("The SHA1 hash of " + source + " is: " + hash);
        }


    }

}