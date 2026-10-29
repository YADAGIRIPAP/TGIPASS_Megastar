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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        if (!IsPostBack)
        {
            Label1.Text = "Report from 01-Apr-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            string strDept = Request.QueryString[0].ToString().Trim();
            string status = Request.QueryString[1].ToString().Trim();
            try
            {
                if (status == "1")
                {
                    switch (strDept)
                    {
                        case "boilers":
                            strDept = "Boilers ";
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getBoilersAppProgressReport()), gvEodbReports, '_', ' ', false);
                            //objCom.FillGrid_Replace(StringToDataTable(objCGG.getBoilerInspectionDetails()), gvEodbinspection, '_', ' ', false);
                            break;
                        case "factories":
                            strDept = "Factories ";
                            // objCom.FillGrid_Replace(StringToDataTable(objCGG.getInsepectionDetails()), gvEodbinspection, '_', ' ', false);
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getAppProgressDetails()), gvEodbReports, '_', ' ', false);
                            break;
                        case "forest":
                            strDept = "Forest ";
                            //objCom.FillGrid_Replace(objCom.ConvertXmlElementToDataTable(objEodb.Inspec_Indicator(), "Table1"), gvEodbinspection, '_', ' ', false);
                            objCom.FillGrid_Replace(objCom.ConvertXmlElementToDataTable(objEodb.Per_Indicator(), "Table"), gvEodbReports, '_', ' ', false);
                            break;

                        case "fire":
                            strDept = "Fire ";
                            //objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objfire.GetInspectionApplications(), "Table"), gvEodbinspection, false);
                            objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objfire.GetApplicationsRecived("01/01/2000", DateTime.Now.ToString("dd/MM/yyyy")), "Table"), gvEodbReports, false);
                            break;
                        case "labour":
                            strDept = "Labour ";
                            trLabourRenewals.Visible = true;
                            lblLabourRenewals.Text = "Labour: Progress Report - Renewals";
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourFreshRegistration()), gvEodbReports, '_', ' ', false);
                            //   objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourInspections()), gvEodbinspection, '_', ' ', false);
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourRenewalRegistration()), gvRenewals, '_', ' ', false);
                            break;
                    }



                    lblHeading.Text = strDept.ToUpper() + " DEPARTMENT";
                    // lblInspection.Text = strDept + " Inspection Progress Report";
                }

                if (status == "2")
                {
                    switch (strDept)
                    {
                        case "boilers":
                            strDept = "Boilers ";
                            //objCom.FillGrid_Replace(StringToDataTable(objCGG.getBoilersAppProgressReport()), gvEodbReports, '_', ' ', false);
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getBoilerInspectionDetails()), gvEodbinspection, '_', ' ', false);
                            break;
                        case "factories":
                            strDept = "Factories ";
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getInsepectionDetails()), gvEodbinspection, '_', ' ', false);
                            // objCom.FillGrid_Replace(StringToDataTable(objCGG.getAppProgressDetails()), gvEodbReports, '_', ' ', false);
                            break;
                        case "forest":
                            strDept = "Forest ";
                            objCom.FillGrid_Replace(objCom.ConvertXmlElementToDataTable(objEodb.Inspec_Indicator(), "Table1"), gvEodbinspection, '_', ' ', false);
                            //  objCom.FillGrid_Replace(objCom.ConvertXmlElementToDataTable(objEodb.Per_Indicator(), "Table"), gvEodbReports, '_', ' ', false);
                            break;

                        case "fire":
                            strDept = "Fire ";
                            objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objfire.GetInspectionApplications(), "Table"), gvEodbinspection, false);
                            // objCom.FillGrid(objCom.ConvertXmlElementToDataTable(objfire.GetApplicationsRecived("01/04/2016", DateTime.Now.ToString("dd/MM/yyyy")), "Table"), gvEodbReports, false);
                            break;
                        case "labour":
                            strDept = "Labour ";
                            trLabourRenewals.Visible = true;
                            // lblLabourRenewals.Text = "Labour: Progress Report - Renewals";
                            //  objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourFreshRegistration()), gvEodbReports, '_', ' ', false);
                            objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourInspections()), gvEodbinspection, '_', ' ', false);
                            // objCom.FillGrid_Replace(StringToDataTable(objCGG.getLabourRenewalRegistration()), gvRenewals, '_', ' ', false);
                            break;
                    }



                    //lblProgress.Text = strDept + " Application Progress Report";
                    lblHeading.Text = strDept.ToUpper() + " Department Inspection Reports";
                }

            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblInspection.Visible = false;
                lblProgress.ForeColor = System.Drawing.Color.Red;
                lblProgress.Text = "Regrets for the inconvenience caused. We are unable to retrieve data from " + strDept.Replace(":", "") + " department as there was a problem with " + strDept.Replace(":", "") + " server.";

                objCom.FillGrid(null, gvEodbinspection, false);
                objCom.FillGrid(null, gvEodbReports, false);
                objCom.FillGrid(null, gvRenewals, false);
            }
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
        catch (Exception ex) { Errors.ErrorLog(ex); return null; }
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try { AssignGridRowStyle(e.Row, "GridviewScrollC1Item"); }
        catch (Exception ex) { Errors.ErrorLog(ex);} 
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
