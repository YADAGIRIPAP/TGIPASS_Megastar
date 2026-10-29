using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class UI_TSiPASS_CentralInspectionSystemServiceReport : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DateTime fromdt, todt;
    DataSet dsdl = new DataSet();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //txtFMDD.Text = DateTime.Today.Day.ToString();
                //txtFMMM.Text = DateTime.Today.Month.ToString();
                //txtFMYYYY.Text = DateTime.Today.Year.ToString();
                //txtTODD.Text = DateTime.Today.Day.ToString();
                //txtTOMM.Text = DateTime.Today.Month.ToString();
                //txtTOYYYY.Text = DateTime.Today.Year.ToString();
                DateTime today = DateTime.Today;
                //txtFromDate.Text = today.ToString("dd-MM-yyyy");
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                Label1.Text = "Report as on date " + DateTime.Now;
                BindYears(ddlyear);
                BindMonths(ddlmonth);
                ddlyear.SelectedValue = DateTime.Now.Year.ToString();
                ddlmonth.SelectedValue = DateTime.Now.Month.ToString();
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
        }
    }

    public void BindYears(DropDownList ddlyears)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlyear.Items.Clear();
            dsd = Gen.GetYEARS();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlyear.DataSource = dsd.Tables[0];
                ddlyear.DataValueField = "Year";
                ddlyear.DataTextField = "Year";
                ddlyear.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlDistrict);
                //}
            }


        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void BindMonths(DropDownList ddlmonths)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlmonth.Items.Clear();
            dsd = Gen.GetMONTHS();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlmonth.DataSource = dsd.Tables[0];
                ddlmonth.DataValueField = "intMonthid";
                ddlmonth.DataTextField = "MonthName";
                ddlmonth.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlDistrict);
                //}
            }


        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            string FromdateforDB = "", TodateforDB = "";
            lblDeptName.Text = "";
            if (txtFromDate.Text != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            ds = GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, null, null, null, FromdateforDB, TodateforDB);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                trdate.Visible = true;
                trprint.Visible = true;
                gvinspection.DataSource = ds.Tables[0];
                gvinspection.DataBind();
                //trMandalData.Visible = true;
                trdistrictwise.Visible = false;
                trCentralInfo.Visible = false;
                trabstract.Visible = true;
                trjoint.Visible = false;
                foreach (GridViewRow gvr in gvinspection.Rows)
                {
                    LinkButton lbtn = (LinkButton)gvr.FindControl("LinkButton1");
                    Label lbl = (Label)gvr.FindControl("Labeldept");
                    if (lbtn.Text.ToUpper() == "TOTAL")
                    {
                        lbtn.Visible = false;
                        lbl.Visible = true;

                        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                        GVR1.Style.Add("font-weight", "bold");
                        GVR1.Cells[0].Text = "";
                        //GVR1.Cells.RemoveAt(0);
                        //GVR1.Cells[0].ColumnSpan = 2;
                        //GVR1.Cells[0].Style.Add("text-align", "center");
                    }
                    if (lbtn.Text.ToUpper() == "PCB DEPARTMENT" || lbtn.Text.ToUpper().Contains("BOILER"))
                    {
                        lbtn.Visible = false;
                        lbl.Visible = true;
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    trjoinfactorylabour.Visible = true;
                    grdjoinfactorylabour.DataSource = ds.Tables[1];
                    grdjoinfactorylabour.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    lbldate.Text= ds.Tables[2].Rows[0]["InspectionSechduleInsertDate"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void gvinspection_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            //fromdt = Convert.ToDateTime(txtFMMM.Text + "/" + txtFMDD.Text + "/" + txtFMYYYY.Text);
            //todt = Convert.ToDateTime(txtTOMM.Text + "/" + txtTODD.Text + "/" + txtTOYYYY.Text);
            //if (fromdt > todt)
            //{
            //    //lblerrMsg.Text = "From date should be less than Todate";
            //    //lblerrMsg.CssClass = "errormsg";
            //    //valid = 1;
            //}

            //int introwIndex = gvinspection.Rows[index];
            string RetrievalFlag = "GRID";
            string status = "";
            string deptname = "";
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (e.CommandName.ToString() == "Department")
            {
                lblDeptName.Text = e.CommandArgument.ToString();
                deptname = e.CommandArgument.ToString();
                status = null;
                dsdl = GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, null, status, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    gvdist.DataSource = dsdl.Tables[0];
                    gvdist.DataBind();
                    //trMandalData.Visible = true;
                    trCentralInfo.Visible = false;
                    trabstract.Visible = false;
                    trdistrictwise.Visible = true;
                    trjoint.Visible = false;
                    foreach (GridViewRow gvr in gvdist.Rows)
                    {
                        LinkButton lbtn = (LinkButton)gvr.FindControl("LinkButton1");
                        Label lbl = (Label)gvr.FindControl("Label5");
                        if (lbtn.Text.ToUpper() == "TOTAL")
                        {
                            lbtn.Visible = false;
                            lbl.Visible = true;

                            GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                            GVR1.Style.Add("font-weight", "bold");
                            GVR1.Cells[0].Text = "";
                            //GVR1.Cells.RemoveAt(0);
                            //GVR1.Cells[0].ColumnSpan = 2;
                            //GVR1.Cells[0].Style.Add("text-align", "center");
                        }
                    }
                }
            }
            else
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                Label lblProdId = (Label)row.FindControl("Labeldept");
                //int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = gvinspection.Rows[index];
                deptname = lblProdId.Text;
                status = e.CommandName.ToString();
                dsdl = GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, null, status, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    if (deptname.Contains("Joint Inspection with"))
                    {

                        trjoint.Visible = true;
                        grdjoint.DataSource = dsdl.Tables[0];
                        grdjoint.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = false;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                    }
                    else
                    {

                        gvCluster.DataSource = dsdl.Tables[0];
                        gvCluster.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = true;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                        trjoint.Visible = false;
                    }
                    //foreach (GridViewRow gvr in gvCluster.Rows)
                    //{
                    //    LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnMandal");
                    //    Label lbl = (Label)gvr.FindControl("lblMandalName");
                    //    if (lbtn.Text.ToUpper() == "TOTAL")
                    //    {
                    //        lbtn.Visible = false;
                    //        lbl.Visible = true;

                    //        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                    //        GVR1.Style.Add("font-weight", "bold");
                    //        GVR1.Cells[0].Text = "";

                    //    }
                    //}
                }

            }
            Session["DEptname"] = deptname;


        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvdist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            //fromdt = Convert.ToDateTime(txtFMMM.Text + "/" + txtFMDD.Text + "/" + txtFMYYYY.Text);
            //todt = Convert.ToDateTime(txtTOMM.Text + "/" + txtTODD.Text + "/" + txtTOYYYY.Text);
            //if (fromdt > todt)
            //{
            //    //lblerrMsg.Text = "From date should be less than Todate";
            //    //lblerrMsg.CssClass = "errormsg";
            //    //valid = 1;
            //}
            string RetrievalFlag = "GRID";
            string deptname = "";
            string status = "";
            string distcd = "";
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (Session["DEptname"] != null)
            {
                deptname = Session["DEptname"].ToString();
            }
            if (e.CommandName.ToString() == "DISTRICT")
            {
                distcd = e.CommandArgument.ToString();
                status = null;


                //string distcd = e.CommandArgument.ToString();
                dsdl =GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, distcd, null, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    // if (deptname == "Joint Inspection with Labour & Factories Departments")
                    if (deptname.Contains("Joint Inspection with"))
                    {

                        trjoint.Visible = true;
                        grdjoint.DataSource = dsdl.Tables[0];
                        grdjoint.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = false;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                    }
                    else
                    {

                        gvCluster.DataSource = dsdl.Tables[0];
                        gvCluster.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = true;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                        trjoint.Visible = false;
                        if (e.CommandName == "VIEW")
                        {
                            // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('ClusterPrint.aspx?ClusterID=" + ClusterID + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
                        }
                    }
                    //foreach (GridViewRow gvr in gvCluster.Rows)
                    //{
                    //    LinkButton lbtn = (LinkButton)gvr.FindControl("lbtnMandal");
                    //    Label lbl = (Label)gvr.FindControl("lblMandalName");
                    //    if (lbtn.Text.ToUpper() == "TOTAL")
                    //    {
                    //        lbtn.Visible = false;
                    //        lbl.Visible = true;

                    //        GridViewRow GVR1 = (GridViewRow)lbl.Parent.Parent;
                    //        GVR1.Style.Add("font-weight", "bold");
                    //        GVR1.Cells[0].Text = "";

                    //    }
                    //}
                }
            }
            else
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                Label lblProdId = (Label)row.FindControl("Label5");
                distcd = lblProdId.Text;
                status = e.CommandName.ToString();
                dsdl =GetCentralInspectionAbstractReport(ddlmonth.SelectedValue, ddlyear.SelectedValue, deptname, distcd, status, FromdateforDB, TodateforDB);
                if (dsdl != null && dsdl.Tables.Count > 0 && dsdl.Tables[0].Rows.Count > 0)
                {
                    trdate.Visible = true;
                    trprint.Visible = true;
                    //if (deptname == "Joint Inspection with Labour & Factories Departments")
                    if (deptname.Contains("Joint Inspection with"))
                    {
                        trjoint.Visible = true;
                        grdjoint.DataSource = dsdl.Tables[0];
                        grdjoint.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = false;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                    }
                    else
                    {
                        trdate.Visible = true;
                        gvCluster.DataSource = dsdl.Tables[0];
                        gvCluster.DataBind();
                        //trMandalData.Visible = true;
                        trCentralInfo.Visible = true;
                        trabstract.Visible = false;
                        trdistrictwise.Visible = false;
                        trjoint.Visible = false;
                        if (e.CommandName == "VIEW")
                        {
                            // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('ClusterPrint.aspx?ClusterID=" + ClusterID + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=CentralInspectionSystem" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                if (trabstract.Visible == true)
                {
                    gvinspection.RenderControl(hw);
                }
                else if (trdistrictwise.Visible == true)
                {
                    gvdist.RenderControl(hw);
                }
                else if (trCentralInfo.Visible == true)
                {
                    gvCluster.RenderControl(hw);
                }

                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    //protected void BTNbACK_Click(object sender, EventArgs e)
    //{
    //    if (trdistrictwise.Visible == true)
    //    {
    //        trdistrictwise.Visible = false;
    //        trabstract.Visible = true;
    //    }        
    //}
    protected void grdjoint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string regnno = e.CommandArgument.ToString();
        string deptname = Session["DEptname"].ToString();
        string year = ddlyear.SelectedItem.Text.Trim();
        string month = ddlmonth.SelectedValue;
        if (e.CommandName == "VIEW")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('CentralInspectionPrint.aspx?regnno=" + regnno + "&query1=" + deptname + "&query2=" + year + "&query3=" + month + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        }
    }
    protected void gvCluster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string regnno = e.CommandArgument.ToString();
        string deptname = Session["DEptname"].ToString();
        string year = ddlyear.SelectedItem.Text.Trim();
        string month = ddlmonth.SelectedValue;
        if (e.CommandName == "VIEW")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('CentralInspectionPrint.aspx?regnno=" + regnno + "&query1=" + deptname + "&query2=" + year + "&query3=" + month + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        }
    }

    protected void grdjoint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Finding label
            HyperLink HyperLinkfactory = (HyperLink)e.Row.FindControl("HyperLinkfactory");
            HyperLink HyperLinklabour = (HyperLink)e.Row.FindControl("HyperLinklabour");
            if (HyperLinklabour.NavigateUrl.Trim() == "")
            {
                HyperLinklabour.Visible = false;

            }
            if (HyperLinkfactory.NavigateUrl.Trim() == "")
            {
                HyperLinkfactory.Visible = false;
            }
        }
        if (lblDeptName.Text.Trim() == "Joint Inspection with Labour Department")
        {
            //grdjoint.
            e.Row.Cells[10].Visible = false;
        }
        else if (lblDeptName.Text.Trim() == "Joint Inspection with Factories Department")
        {
            //grdjoint.
            e.Row.Cells[9].Visible = false;

        }
        //if (lblDeptName.Text.Trim() == "Joint Inspection with Labour Department")
        //{
        //    //grdjoint.
        //    e.Row.Cells[10].Visible = false;
        //}
    }


    public DataSet GetCentralInspectionAbstractReport(string month, string Year, string Department, string District, string status, string inspectionformdate, string inspectiontodate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_CENTRALINSPECTION_ABSTRACT_NEW]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (month != null && month.Trim().ToString() != "" && month.ToString().Trim() != "--Select--")
                da.SelectCommand.Parameters.Add("@MONTH", SqlDbType.VarChar).Value = month.Trim();
            else
                da.SelectCommand.Parameters.Add("@MONTH", SqlDbType.VarChar).Value = DBNull.Value;


            if (Year != null && Year.Trim().ToString() != "" && Year.ToString().Trim() != "--Select--")
                da.SelectCommand.Parameters.Add("@YEAR", SqlDbType.VarChar).Value = Year.Trim();
            else
                da.SelectCommand.Parameters.Add("@YEAR", SqlDbType.VarChar).Value = DBNull.Value;


            if (Department != null && Department != "")
                da.SelectCommand.Parameters.Add("@DEPARTMENT", SqlDbType.VarChar).Value = Department.Trim();
            else
                da.SelectCommand.Parameters.Add("@DEPARTMENT", SqlDbType.VarChar).Value = DBNull.Value;


            if (District != null && District != "")
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = District.Trim();
            else
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DBNull.Value;

            if (status != null && status != "")
                da.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = status.Trim();
            else
                da.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = DBNull.Value;

            if (inspectionformdate != null && inspectionformdate != string.Empty && inspectionformdate != "")
                da.SelectCommand.Parameters.Add("@INSPECTIONDATE", SqlDbType.VarChar).Value = inspectionformdate.ToString();
            else
                da.SelectCommand.Parameters.Add("@INSPECTIONDATE", SqlDbType.VarChar).Value = DBNull.Value;

            if (inspectiontodate != null && inspectiontodate != string.Empty && inspectiontodate != "")
                da.SelectCommand.Parameters.Add("@INSPECTIONTODATE", SqlDbType.VarChar).Value = inspectiontodate.ToString();
            else
                da.SelectCommand.Parameters.Add("@INSPECTIONTODATE", SqlDbType.VarChar).Value = DBNull.Value;

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    //public DataSet GetPCBDistricts()
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("GetPCBDistricts", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;




    //        da.Fill(ds);
    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}

    protected void grdjoinfactorylabour_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdjoinfactorylabour_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdjoinfactorylabour.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Factory Inspections";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Labour Inspections";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Report Uploaded";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);

        }
    }
}