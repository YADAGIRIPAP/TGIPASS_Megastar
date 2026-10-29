using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CAFIntegration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CAFIntegration : System.Web.Services.WebService {
    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
    DML obj = new DML();
    public CAFIntegration () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    [WebMethod]
    public XmlElement InsQueryRaise(string Uid_No, int IntDeptID, string QueryDesc, double AdditionalPayement) { return returnXmlElement(obj.InsQueryRaise(Uid_No, IntDeptID, QueryDesc, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsPreScuitinyCompleted(string Uid_No, int IntDeptID, double AdditionalPayement) { return returnXmlElement(obj.InsPreScuitinyCompleted(Uid_No, IntDeptID, AdditionalPayement)); }

    public XmlElement returnXmlElement(DataSet ds)
    {
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        else
        {
            //DataSet ds1 = new DataSet("EmptyTable");
            DataTable dt = new DataTable();
            dt.Columns.Add("ErrorMessage", typeof(string));
            dt.Rows.Add("No Data Found ");
            ds.Tables.Add(dt);
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            return (xmldata.DocumentElement);
        }
    }
}

