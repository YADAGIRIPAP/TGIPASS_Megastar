using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class ReleaseProceedingsSpeacialCase : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DB.DB con = new DB.DB();
    string lblIncentiveID;
    string lblMstIncentiveId;
    //static int gvData2RAmtEmpty = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();

            tblmain.Visible = false;
            tblspecialcasesSearch.Visible = true;

            ddlDist.Items.Clear();
            ddlSLCNo.Items.Clear();
            txtUnitName.Text = "";

            ViewState["SelectedRecords"] = null;
            ddlSLCNo.Items.Insert(0, "--Select--");
            BindDistricts(ddlDist);

            BindIncentiveType(ddlIncentiveType);
            trRemainingAmount2.Visible = false;
        }


    }

    protected void bntUpload_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\GoCOIIncentiveAttachments");
        General t1 = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();

        string MstIncentiveId = "";
        string IncentiveID = "";
        string SLCNumer = string.Empty;



        if (fucReleaseProCopy.HasFile)
        {
            if ((fucReleaseProCopy.PostedFile != null) && (fucReleaseProCopy.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fucReleaseProCopy.PostedFile.FileName);
                try
                {
                    string[] fileType = fucReleaseProCopy.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        foreach (GridViewRow gvrow in grdDetails.Rows)
                        {
                            SLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;
                            newPath = System.IO.Path.Combine(sFileDir, SLCNumer);

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            //int count = dir.GetFiles().Length;
                            //if (count == 0)

                            fucReleaseProCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }

                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);

                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        fucReleaseProCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        foreach (GridViewRow gvrow in grdDetails.Rows)
                        {
                            MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                            IncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                            SLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;
                            newPath = System.IO.Path.Combine(sFileDir, SLCNumer);
                            if (MstIncentiveId != "" && IncentiveID != "" && SLCNumer != "")
                            {
                                objDml.InsUpdCOI_Incentive_Attachments(2, Convert.ToInt32(IncentiveID), Convert.ToInt32(MstIncentiveId), Convert.ToInt32(SLCNumer), sFileName, newPath, Convert.ToInt32(Session["uid"].ToString()));
                            }
                        }



                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lnkReleaseCopy.Text = fucReleaseProCopy.FileName;
                        lnkReleaseCopy.NavigateUrl = newPath + "\\" + sFileName;

                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    private void BindIncentiveType(DropDownList ddlIncentive)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlIncentiveType.Items.Clear();
            dsd = Gen.GetTypeOfIncentives();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlIncentiveType.DataSource = dsd.Tables[0];
                ddlIncentiveType.DataValueField = "IncentiveID";
                ddlIncentiveType.DataTextField = "IncentiveName";
                ddlIncentiveType.DataBind();
                ddlIncentiveType.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlIncentiveType.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    private void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsForOldSanctionedIncentives();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    private void BindSlcNos(DropDownList ddlSLCNo)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlSLCNo.Items.Clear();
            string Cast2;
            //string Cast2 = Request.QueryString[0].ToString();
            //string Investmentid2 = Request.QueryString[1].ToString();

            Cast2 = ddlCaste.SelectedItem.Text;


            string Investmentid2 = ddlIncentiveType.SelectedValue.ToString();

            dsd = Gen.GetIncentivesSLCNosList(Cast2, Investmentid2);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlSLCNo.DataSource = dsd.Tables[0];
                ddlSLCNo.DataValueField = "SLCNumer";
                ddlSLCNo.DataTextField = "SLCNumer";
                ddlSLCNo.DataBind();
                ddlSLCNo.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlSLCNo.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        ViewState["UIDNO"] = null;

        Failure.Visible = false;



        string Cast2 = ddlCaste.SelectedItem.Text;


        string Investmentid2 = ddlIncentiveType.SelectedValue.ToString();



        if (txtUnitName.Text.Trim() == "")
        {
            lblmsg0.Text += "Please enter Unit Name" + "<br/>";
            valid = 1;
        }
        if (ddlDist.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select District" + "<br/>";
            valid = 1;
        }
        if (ddlSLCNo.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select SLC No" + "<br/>";
            valid = 1;
        }

        if (ddlCaste.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select Caste" + "<br/>";
            valid = 1;
        }

        if (valid == 0)
        {
            DataSet dsd = new DataSet();
            dsd = Gen.GetIncentives_Release_Proceedings_UnitName_search(ddlSLCNo.SelectedValue, ddlDist.SelectedValue, txtUnitName.Text.Trim(), Investmentid2, Cast2);


            if (dsd != null && dsd.Tables.Count > 0)
            {
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    gvData2.DataSource = dsd.Tables[0];
                    gvData2.DataBind();
                    gvData3.DataSource = dsd.Tables[0];
                    gvData3.DataBind();

                    tr1.Visible = true;
                    tblspecialcasesSearch.Visible = true;
                    trsearchresult.Visible = true;
                    trUpdate.Visible = true;






                }
                else
                {
                    gvData2.DataSource = null;
                    gvData2.DataBind();
                    gvData3.DataSource = null;
                    gvData3.DataBind();
                    Failure.Visible = true;
                    lblmsg0.Text = "No Details Found ";
                    tr1.Visible = false;
                    tblspecialcasesSearch.Visible = true;
                    trsearchresult.Visible = false;



                }

            }
            else
            {
                gvData2.DataSource = null;
                gvData2.DataBind();
                gvData3.DataSource = null;
                gvData3.DataBind();
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                Failure.Visible = true;
                lblmsg0.Text = "No Details Found ";
                tr1.Visible = false;
                tblspecialcasesSearch.Visible = true;
                trsearchresult.Visible = false;

            }

        }
        else
        {
            Failure.Visible = true;
            gvData2.DataSource = null;
            gvData2.DataBind();
            gvData3.DataSource = null;
            gvData3.DataBind();
            grdDetails.DataSource = null;
            grdDetails.DataBind();
            Failure.Visible = true;

            tr1.Visible = false;
            tblspecialcasesSearch.Visible = true;
            trsearchresult.Visible = false;

        }
    }

    protected void ChckedChanged(object sender, EventArgs e)
    {
        GetData();


    }

    protected void gvData2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
                Label ReleasedAmount = (e.Row.FindControl("lblReleasedAmount") as Label);
                if (ReleasedAmount.Text.Trim() == null || ReleasedAmount.Text.Trim() == "" || ReleasedAmount.Text.Trim() == string.Empty)
                {
                    gvData2.Columns[7].Visible = false;
                }
                else
                {
                    gvData2.Columns[7].Visible = true;
                }




            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("NameofUnit");
        dt.Columns.Add("Address");
        dt.Columns.Add("DCP");
        dt.Columns.Add("IncentiveName");
        dt.Columns.Add("SanctionedAmount", typeof(decimal));
        dt.Columns.Add("SanctionedDate");
        dt.Columns.Add("AllotedAmount", typeof(decimal));
        dt.Columns.Add("ReleasedAmount", typeof(decimal));
        dt.Columns.Add("MstIncentiveId");
        dt.Columns.Add("EnterperIncentiveID");
        dt.Columns.Add("SLCNumer");

        dt.AcceptChanges();
        return dt;

    }


    int AddStatus = 0;
    int RemoveStatus = 0;

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();

        for (int i = 0; i < gvData2.Rows.Count; i++)
        {


            

            CheckBox chk = (CheckBox)gvData2.Rows[i]
                            .Cells[0].FindControl("chkSameUnit");
            if (chk.Checked)
            {
                Label lblpendingSanctionAmount = gvData2.Rows[i].Cells[0].FindControl("lblPendingSanctionAmount") as Label;
                txtActualSanctionAmount.Text = lblpendingSanctionAmount.Text;
                Label lblIncentiveID = gvData2.Rows[i].Cells[0].FindControl("lblIncentiveID") as Label;
                string IncId = lblIncentiveID.Text;
                Label lblslno = gvData2.Rows[i].Cells[0].FindControl("lblslno") as Label;
                string slno = lblslno.Text;
                Session["slno"] = slno;

                Session["IncId"] = IncId;
                btnUpdate.Visible = true;
                trslc.Visible = true;
                trslc1.Visible = true;
                trslc2.Visible = true;



            }

            chk.Enabled = false;

        }

    }


    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {

        Label enterid = (gvRow.FindControl("lblIncentiveID") as Label);
        Label lblAllotedAmount = (gvRow.FindControl("lblAllotedAmount") as Label);
        Label lblReleasedAmount = (gvRow.FindControl("lblReleasedAmount") as Label);
        Label lblPendingAmount = (gvRow.FindControl("lblPendingAmount") as Label);

        Label lblMstIncentiveId = (gvRow.FindControl("lblMstIncentiveId") as Label);
        Label lblIncentiveID = (gvRow.FindControl("lblIncentiveID") as Label);
        Label lblSLCNumer = (gvRow.FindControl("lblSLCNumer") as Label);

        DataRow[] dr = dt.Select("EnterperIncentiveID = '" + enterid.Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["NameofUnit"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Address"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["DCP"] = gvRow.Cells[4].Text;

            dt.Rows[dt.Rows.Count - 1]["SanctionedAmount"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["SanctionedDate"] = gvRow.Cells[6].Text;

            // dt.Rows[dt.Rows.Count - 1]["AllotedAmount"] = lblAllotedAmount.Text;
            dt.Rows[dt.Rows.Count - 1]["AllotedAmount"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["ReleasedAmount"] = (lblReleasedAmount.Text);



            dt.Rows[dt.Rows.Count - 1]["MstIncentiveId"] = lblMstIncentiveId.Text;
            dt.Rows[dt.Rows.Count - 1]["EnterperIncentiveID"] = lblIncentiveID.Text;
            dt.Rows[dt.Rows.Count - 1]["SLCNumer"] = lblSLCNumer.Text;


            dt.AcceptChanges();
            AddStatus = 1;
        }
        else
        {
            AddStatus = 0;
        }

        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        Label enterid = (gvRow.FindControl("lblIncentiveID") as Label);
        DataRow[] dr = dt.Select("EnterperIncentiveID = '" + enterid.Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
            RemoveStatus = 1;
        }
        else
        {
            RemoveStatus = 0;
        }
        return dt;
    }

    public void uncheck(string str)
    {
        for (int i = 0; i < gvData2.Rows.Count; i++)
        {
            Label lblIncentiveID = gvData2.Rows[i].Cells[0].FindControl("lblIncentiveID") as Label;
            CheckBox chk = (CheckBox)gvData2.Rows[i].Cells[0].FindControl("chkSameUnit");
            if (lblIncentiveID.Text == str)
            {
                if (chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }

    }

    public DataSet GetIncentiveNamebyId(string IncentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_IncentiveName_by_ID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveID;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtReleasingSlcSpeacCaseAmount.Text != "" && txtReleasingSlcSpeacCaseDate.Text != "" && txtReleasingSlcSpeacCaseAmount.Text != null && txtReleasingSlcSpeacCaseDate.Text != null && txtSpeacialCaseGoNo.Text != null && txtSpeacialCaseGoNo.Text != "" && txtActualSanctionAmount.Text != null && txtActualSanctionAmount.Text != "" && txtPendingAmount.Text != null && txtPendingAmount.Text != "" && txtReleasingSlcSpeacCaseAmount.Text != null && txtReleasingSlcSpeacCaseAmount.Text != "")
        {

            string Investmentid = ddlIncentiveType.SelectedValue.ToString();

            ReleasingProceedings frmvo = new ReleasingProceedings();
            frmvo.ReleasingSlcSpeacCaseAmount = txtReleasingSlcSpeacCaseAmount.Text;
            string[] releaseProDate = txtReleasingSlcSpeacCaseDate.Text.Split('/');
            frmvo.ReleasingSlcSpeacCaseDate = releaseProDate[2] + "/" + releaseProDate[1] + "/" + releaseProDate[0];
            frmvo.Remarks = txtRemarks.Text;
            frmvo.GOSpeaclCaseNo = txtSpeacialCaseGoNo.Text;
            frmvo.PendingAmount = txtPendingAmount.Text;
            frmvo.SanctionSpecialCaseAmount = txtActualSanctionAmount.Text;

            frmvo.EnterperIncentiveID = Session["IncId"].ToString();
            frmvo.slno = Session["slno"].ToString();
            frmvo.MstIncentiveId = Investmentid;
            frmvo.CreatedByid = Session["uid"].ToString();
            int valid = Gen.InsertSlcspecialDetails(frmvo);
            if (valid == 1)
            {

                string message = "alert('Details Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);


                tr1.Visible = false;
                trsearchresult1.Visible = false;
                trsearchresult.Visible = false;
                trslc.Visible = false;
                trslc1.Visible = false;
                trslc2.Visible = false;
                btnUpdate.Visible = false;
                trslAmount.Visible = false;
                trddlslc.Visible = false;

                Cleartext();



            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Details Not Updated... Please Try Again...');", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Fill The Required Details');", true);
            return;
        }
    }

    protected void gvData3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);

            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindSlcNos(ddlSLCNo);
        trddlslc.Visible = true;
    }
    protected void txtReleasingSlcSpeacCaseAmount_TextChanged(object sender, EventArgs e)
    {
        decimal sanctionedAmount;
        decimal ReleaseAmount = Convert.ToDecimal(txtReleasingSlcSpeacCaseAmount.Text);
        sanctionedAmount = Convert.ToDecimal(txtActualSanctionAmount.Text);


        if (ReleaseAmount <= sanctionedAmount)
        {


            decimal pendingAmount = sanctionedAmount - ReleaseAmount;
            txtPendingAmount.Text = Convert.ToString(pendingAmount);
        }

        else
        {
            txtReleasingSlcSpeacCaseAmount.Text = "";
            txtPendingAmount.Text = "";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('please Enter Release Amount less then Sanction Amount');", true);
            return;

        }

    }

    private void Cleartext()
    {

        ddlDist.SelectedIndex = 0;

        ddlIncentiveType.SelectedIndex = 0;
        txtUnitName.Text = string.Empty;
        ddlCaste.SelectedIndex = 0;
        ddlSLCNo.SelectedIndex = 0;
        txtReleasingSlcSpeacCaseAmount.Text = "";
        txtReleasingSlcSpeacCaseDate.Text = "";
        txtSpeacialCaseGoNo.Text = "";
        txtActualSanctionAmount.Text = "";
        txtPendingAmount.Text = "";
        txtRemarks.Text = "";



    }
}