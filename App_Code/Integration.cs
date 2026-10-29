using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using BusinessLogic;
/// <summary>
/// Summary description for Integration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Integration : System.Web.Services.WebService {
    BusinessLogic.DML objdml=new BusinessLogic.DML();
    public Integration () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UnitName">Unit Name</param>
    /// <param name="Location_District">District</param>
    /// <param name="Location_Mandal">Mandal</param>
    /// <param name="Location_Village">Village Name</param>
    /// <param name="Inspection_Authority_Desg">Inspection Authority Designation</param>
    /// <param name="Date_Inspection">Date of Inspection format should be in "yyyy-MM-dd"</param>
    /// <param name="Date_Uploading_Inspection">Date of Uploading Inspection format should be in "yyyy-MM-dd"</param>
    /// <param name="Unique_Number">Unique Number</param>
    /// <param name="File_Link">File Location</param>
    /// <param name="Department">Name of the Department</param>
    /// <returns></returns>
    [WebMethod]    
    public int InsertDetails(string UnitName, string Location_District, string Location_Mandal, string Location_Village, string Inspection_Authority_Desg, DateTime Date_Inspection, DateTime Date_Uploading_Inspection, string Unique_Number, string File_Link, string Department)
    {
        return objdml.InsUpdDeltbl_InspectionDet("I", 0, UnitName, Location_District, Location_Mandal, Location_Village, Inspection_Authority_Desg, Date_Inspection, Date_Uploading_Inspection, Unique_Number, File_Link, Department);
        
    }
}

