using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using BusinessLogic;
using System.Web.Services;
using System.Text;
using System.Collections;

public partial class IncentiveRegistrationViewDocsNew : System.Web.UI.Page
{
    Fetch objFetch = new Fetch();
    comFunctions objCmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            objCmf.BindCtlto(true, ddlCategory, objFetch.FetchCategory(), 1, 0, false);
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                ds = objcommon.GetHomepagecontete();
                if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
                }
              //  objCmf.BindCtlto(true, ddlCategory, objFetch.FetchCategory(), 1, 0, false);
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { VehicleVisible(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { VehicleVisible(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void cbphysicalHandicapped_CheckedChanged(object sender, EventArgs e)
    {
        try { VehicleVisible(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    private void VehicleVisible()
    {
        try
        {
            Label4.Visible = rblVehicleIncetive.Visible = false;
            if ((ddlCaste.SelectedValue == "3" || ddlCaste.SelectedValue == "4" || cbphysicalHandicapped.Checked) && ddlSector.SelectedValue == "1")
            Label4.Visible = rblVehicleIncetive.Visible = true;
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                DataTable dt = new DataTable();
                if (Page.IsValid && ddlCaste.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0 && ddlSector.SelectedIndex > 0)
                    dt = objFetch.FetchEligibleIncentives(Convert.ToInt32(ddlCaste.SelectedValue),
                                                                    Convert.ToInt32(ddlSector.SelectedValue),
                                                                    (rblGHMC.SelectedValue == "0" ? true : false),
                                                                    Convert.ToInt32(rblSelection.SelectedValue),
                                                                    Convert.ToInt32(ddlCategory.SelectedValue),
                                                                    cbphysicalHandicapped.Checked,
                                                                    (rblVehicleIncetive.SelectedValue == "1" ? true : false)
                                                        );
                else
                    dt = null;

                objCmf.FillGrid_EmptyDatatext(dt, grdDetails);
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }


    [WebMethod]
    public static object GetDetails(string caste,string sector,bool rblGHMC,string rblSelection,string Category,bool IsCheck,bool rblVechicleInc ) {
        Fetch objFetch = new Fetch();
        DataTable dt = new DataTable();
        //dt = objFetch.FetchEligibleIncentives(Convert.ToInt32(ddlCaste.SelectedValue),
        //                                                 Convert.ToInt32(ddlSector.SelectedValue),
        //                                                 (rblGHMC.SelectedValue == "0" ? true : false),
        //                                                 Convert.ToInt32(rblSelection.SelectedValue),
        //                                                 Convert.ToInt32(ddlCategory.SelectedValue),
        //                                                 cbphysicalHandicapped.Checked,
        //                                                 (rblVehicleIncetive.SelectedValue == "1" ? true : false)
        //                                     );
        dt = objFetch.FetchEligibleIncentives(Convert.ToInt32(caste), Convert.ToInt32(sector), rblGHMC, Convert.ToInt32(rblSelection), Convert.ToInt32(Category),IsCheck,rblVechicleInc );
       // dt = objFetch.FetchEligibleIncentives(3,1,true,1,1,false,true);


        //ArrayList myArrayList = new ArrayList();
        //for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //{
        //    for (int j = 0; j <= dt.Columns.Count - 1; j++)
        //    {
        //        myArrayList.Add(dt.Rows[i][j].ToString());
        //    }
        //}

        //var q = (from n in dt.AsEnumerable() select n).ToList();

        //List<object> lst = new List<object>();




        List<EligibleIncentives> listName = dt.AsEnumerable().Select(m => new EligibleIncentives()
        {
            IncentiveType = m.Field<string>("IncentiveType"),
            IncentiveName = m.Field<string>("IncentiveName"),
            DocName = m.Field<string>("DocName"),
            FilePath = m.Field<string>("FilePath")
        }).ToList();



        return listName;
       // return DataTableToJSONWithStringBuilder(dt);

    }



    public static string DataTableToJSONWithStringBuilder(DataTable table)
    {
        var JSONString = new StringBuilder();
        if (table.Rows.Count > 0)
        {
            JSONString.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                JSONString.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (j < table.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == table.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == table.Rows.Count - 1)
                {
                    JSONString.Append("}");
                }
                else
                {
                    JSONString.Append("},");
                }
            }
            JSONString.Append("]");
        }
        return JSONString.ToString();
    }


    protected void grdDetails_RowDataBound(object sender, EventArgs e)
    {
        try
        {
            for (int rowIndex = grdDetails.Rows.Count - 2;
                                               rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = grdDetails.Rows[rowIndex];
                GridViewRow gvPreviousRow = grdDetails.Rows[rowIndex + 1];
                for (int cellCount = 0; cellCount < gvRow.Cells.Count - 1;
                                                              cellCount++)
                {
                    if (gvRow.Cells[cellCount].Text ==
                                           gvPreviousRow.Cells[cellCount].Text)
                    {
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan =
                                gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;
                    }
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }



}



public class EligibleIncentives
{
    public string IncentiveType { get; set;}
    public string IncentiveName { get; set; }
    public string DocName { get; set; }
    public string FilePath { get; set; }
}