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
using BusinessLogic;
using Forest;
using System.Xml;
using GHMC;
using CGG;
using System.IO;
using Fire;
using HMWSSB;
using FireNew;

public partial class UI_EODBReports : System.Web.UI.Page
{
    GHMC.WebService objGHMC = new GHMC.WebService();
    Fetch objFetch = new Fetch();
    comFunctions objCom = new comFunctions();
    EODBIPassIndicator objEodb = new EODBIPassIndicator();
    CGG.ProgressReportService objCGG = new ProgressReportService();
    FireNew.Service objfire = new FireNew.Service();
    HMWSSB.TSIPassUC objHMWSSb = new HMWSSB.TSIPassUC();

    protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strDept = "";
        try
        {
            trLabourRenewals.Visible = false;
            lblInspection.Visible = true;
            lblProgress.ForeColor = System.Drawing.Color.Black;
            switch (ddlDepartments.SelectedValue.ToLower())
            { 
                case "boilers":
                    strDept = "Boilers:";
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getBoilersAppProgressReport()), gvEodbReports,'_',' ', false);
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getBoilerInspectionDetails()), gvEodbinspection, '_', ' ', false);
                    break;
                case "factories":
                    strDept = "Factories:";
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getInsepectionDetails()), gvEodbinspection, '_', ' ', false);
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getAppProgressDetails()), gvEodbReports, '_', ' ', false);
                    break;
                case "forest":
                    strDept = "Forest:";
                    objCom.FillGrid_Replace(objCom.ConvertXmlElementToDataTable(objEodb.Inspec_Indicator(), "Table1"), gvEodbinspection, '_', ' ', false);
                    objCom.FillGrid_Replace(objCom.ConvertXmlElementToDataTable(objEodb.Per_Indicator(), "Table"), gvEodbReports, '_', ' ', false);
                    break;
                //case "hmwssb":
                //    strDept = "HMWS SB:";
                //    objHMWSSb.GetPerformanceIndicatorDetails();
                //    //objCom.FillGrid(objCom.ConvertXmlElementToDataTable(.Inspec_Indicator(), "Table1"), gvEodbinspection, false);
                //    //objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objEodb.Per_Indicator(), "Table"), gvEodbReports, false);
                //    break;
                case "fire":
                    strDept = "Fire:";
                    objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objfire.GetInspectionApplications(), "Table"), gvEodbinspection, false);
                    objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objfire.GetApplicationsRecived("01/04/2016",DateTime.Now.ToString("dd/MM/yyyy")), "Table"), gvEodbReports, false);
                    break;
                case "labour":
                    strDept = "Labour:";
                    trLabourRenewals.Visible = true;
                    lblLabourRenewals.Text = "Labour: Progress Report - Renewals";
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourFreshRegistration()), gvEodbReports, '_', ' ', false);
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourInspections()), gvEodbinspection, '_', ' ', false);
                    objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourRenewalRegistration()), gvRenewals, '_', ' ', false);
                    break;  
            }

            lblProgress.Text = strDept + " Application Progress Report";
            lblInspection.Text = strDept + " Inspection Progress Report";
            //objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objEodb.Inspec_Indicator(), "Table1"), gvEodbinspection, false);
            //objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objEodb.Per_Indicator(), "Table1"), gvEodbReports, false);
        }
        catch (Exception ex) { Errors.ErrorLog(ex);
        lblInspection.Visible = false;
        lblProgress.ForeColor = System.Drawing.Color.Red;
        lblProgress.Text = "Regrets for the inconvenience caused. We are unable to retrieve data from " + strDept.Replace(":", "") + " department as there was a problem with " + strDept.Replace(":", "") + " server.";
        
        objCom.FillGrid(null, gvEodbinspection,false);
        objCom.FillGrid(null, gvEodbReports, false);
        objCom.FillGrid(null, gvRenewals, false);
        }
    }

    public DataTable StringToDataTable(string xmlString)
    {
        try
        {
            xmlString = xmlString.Replace("(", "").Replace(")", "");
            xmlString = xmlString.Replace(" ", "_");
            StringReader theReader = new StringReader(xmlString);
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(theReader);

            return theDataSet.Tables[0];
        }
        catch (Exception ex) { Errors.ErrorLog(ex); return null;  }
    }

    private void AssigncsstoGridCells(GridViewRow gr, string cssName)
    {
        try
        {
            if (cssName == "") cssName = "gvrowpadding";
            gr.CssClass = cssName;

            for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
            {
                gr.Cells[cellIndex].CssClass = cssName;
                string s = gr.Cells[cellIndex].Text;
                try
                {   
                    double d;
                    if (Double.TryParse(s, out d)) gr.Cells[cellIndex].HorizontalAlign = HorizontalAlign.Right; else ToTitleCase(s); ;
                    
                    gr.Cells[cellIndex].Text = Convert.ToDouble(gr.Cells[cellIndex].Text).ToString();
                }
                catch (Exception) { ToTitleCase(s); }
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void gvEodbReports_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try { AssigncsstoGridCells(e.Row,""); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    public string ToTitleCase(string str)
    {
        string result = str;
        if (!string.IsNullOrEmpty(str))
        {
            var words = str.Split(' ');
            for (int index = 0; index < words.Length; index++)
            {
                var s = words[index];
                if (s.Length > 0)
                {
                    words[index] = s[0].ToString().ToUpper() + s.Substring(1);
                }
            }
            result = string.Join(" ", words);
        }
        return result;
    }

}
