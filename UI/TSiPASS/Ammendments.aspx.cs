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

public partial class UI_TSiPASS_Ammendments : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = 0;
            if (txtAmendmentName.Text == "" && ddlamendmenttype.SelectedValue != "2")
            {
                lblerrMsg.Text = "<font color='red'>Please Enter Regulation </font>" + "<br/>";
                //lblresult.Visible = false;
                //lblerrMsg.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (txtAmendmentDate.Text == "")
            {
                lblerrMsg.Text += "<font color='red'>Please Enter Regulation Date </font>";
                //lblresult.Visible = false;
                //lblerrMsg.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (ddlamendmenttype.SelectedValue == "0")
            {
                lblerrMsg.Text += "<font color='red'>Please Select Regulation Type </font>";
                //lblresult.Visible = false;
                //lblerrMsg.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                valid = 1;
            }
            if (valid == 0)
            {
                string newPath = "";

                string sFileDir = Server.MapPath("~\\Attachments");

                General t1 = new General();
                if (FileUpload1.HasFile)
                {
                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {

                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {

                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF")
                            //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                string serverpath = Server.MapPath("~/Attachments/AMENDMENTS/");
                                if (!Directory.Exists(serverpath))
                                    Directory.CreateDirectory(serverpath);

                                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Attachments/AMENDMENTS/") + sFileName);
                                string CrtdUser = Session["uid"].ToString();

                                int result = 0;
                                AmmendmentVo ammendment = new AmmendmentVo();
                                ammendment.Ammendment = txtAmendmentName.Text;
                                if (ddlamendmenttype.SelectedValue == "2")
                                {
                                    ammendment.Ammendment = ddlAmendment.SelectedItem.Text;
                                    ammendment.Ammendment_Id = ddlAmendment.SelectedValue;
                                }
                                ammendment.Ammendment_Date = txtAmendmentDate.Text;
                                ammendment.Ammendment_Path = serverpath;
                                ammendment.Amm_FileName = sFileName;

                                string intPIAid = "";
                                if (Session["user_type"].ToString().Trim() == "MORD")
                                {
                                    intPIAid = Session["uid"].ToString().Trim();
                                }
                                else
                                {
                                    intPIAid = Session["user_code"].ToString().Trim();
                                }
                                ammendment.Dept_ID = intPIAid;
                                ammendment.Created_By = Session["uid"].ToString();
                                ammendment.Amm_Type = ddlamendmenttype.SelectedValue;
                                List<Deptcomments> lstformvo = new List<Deptcomments>();
                                lstformvo.Clear();
                                if (ddlamendmenttype.SelectedValue == "2")
                                {
                                    foreach (GridViewRow gvrow in gvComments.Rows)
                                    {
                                        Deptcomments fromvo = new Deptcomments();
                                        int rowIndex = gvrow.RowIndex;

                                        fromvo.DeptComments = ((TextBox)gvrow.FindControl("lbldeptcoments")).Text.ToString().Trim().TrimStart();
                                        fromvo.id = ((Label)gvrow.FindControl("lblamdid")).Text.ToString();
                                        fromvo.Created_By = Session["uid"].ToString();
                                        if (fromvo.DeptComments != "")
                                        {
                                            lstformvo.Add(fromvo);
                                        }
                                    }
                                }
                                t1.InsertDeptAmmendments(ammendment, lstformvo);


                                //if (result > 0)
                                //{
                                //ResetFormControl(this);
                                lblresult.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                //lblFileName.Text = FileUpload1.FileName;
                                Label444.Text = FileUpload1.FileName;

                                //lblresult.Visible = true;
                                //lblerrMsg.Visible = false;

                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                                //}
                                //else
                                //{
                                //    lblerrMsg.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                //    lblresult.Visible = false;
                                //    lblerrMsg.Visible = true;
                                //    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                                //}

                            }
                            else
                            {
                                lblerrMsg.Text = "<font color='red'>Upload PDF files only..!</font>";
                                //lblresult.Visible = false;
                                //lblerrMsg.Visible = true;

                                success.Visible = false;
                                Failure.Visible = true;
                                //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                            }

                        }
                        catch (Exception)//in case of an error
                        {
                            //lblError.Visible = true;
                            //lblError.Text = "An Error Occured. Please Try Again!";
                            DeleteFile(newPath + "\\" + sFileName);
                            // DeleteFile(sFileDir + sFileName);
                        }
                    }
                }
                else
                {
                    lblerrMsg.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    //lblresult.Visible = false;
                    //lblerrMsg.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblerrMsg.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void DeleteFile(string strFileName)
    {//Delete file from the server
        try
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblerrMsg.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{

    //}
    protected void BTNcLEAR_Click(object sender, EventArgs e)
    {
        Response.Redirect("Ammendments.aspx");
    }
    protected void ddlamendmenttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlamendmenttype.SelectedValue == "1")
            {
                lblammentname.Text = "Draft Regulation";
                lblamendentdate.Text = "Draft Regulation Date";
                lblamendentupload.Text = "Draft Regulation Upload";
                tramendentype.Visible = false;
                tramentext.Visible = true;
            }
            else if (ddlamendmenttype.SelectedValue == "2")
            {
                tramendenname.Visible = true;
                tramentext.Visible = false;
                //lblammentname.Text = "Final Regulation Name";
                lblamendentdate.Text = "Final Regulation Date";
                lblamendentupload.Text = "Final Regulation Upload";
                //tramendentype.Visible = true;

                ddlAmendment.Items.Clear();
                int DEPTID = Convert.ToInt32(Session["intDeptid"].ToString().Trim());
                DataSet ds1 = gen.GetAmmendments(DEPTID);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ddlAmendment.DataSource = ds1.Tables[0];
                    ddlAmendment.DataTextField = "Ammendment";
                    ddlAmendment.DataValueField = "Ammendment_Id";
                    ddlAmendment.DataBind();
                }
                AddSelect(ddlAmendment);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblerrMsg.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblerrMsg.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void GV_RowDataBound(object o, GridViewRowEventArgs e)
    {
        try
        {
            // apply custom formatting to data cells
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // set formatting for the category cell
                TableCell cell = e.Row.Cells[0];
                cell.Width = new Unit("500px");
                // cell.Style["border-right"] = "2px solid #666666";
                //cell.BackColor = System.Drawing.Color.LightGray;

                // set formatting for value cells
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];

                    // right-align each of the column cells after the first
                    // and set the width
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.Width = new Unit("500px");
                    //if (cell.Text.Contains("Comments"))
                    //{
                    //    cell.Width = new Unit("1000px");
                    //}
                    // alternate background colors
                    //if (i % 2 == 1)
                    //    cell.BackColor
                    //      = System.Drawing.ColorTranslator.FromHtml("#EFEFEF");

                    // check value columns for a high enough value
                    // (value >= 8000) and apply special highlighting
                    //if (GetCellValue(cell) >= 8000)
                    //{
                    // cell.Font.Bold = true;
                    cell.BorderWidth = new Unit("1px");
                    cell.BorderColor = System.Drawing.Color.Red;
                    cell.BorderStyle = BorderStyle.Dotted;
                    // cell.BackColor = System.Drawing.Color.Honeydew;

                    //}

                }
            }

            // apply custom formatting to the header cells
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (cell.Text.Contains("Comments"))
                    {
                        cell.Width = new Unit("1000px");
                    }
                    // cell.Style["border-bottom"] = "2px solid #666666";
                    //cell.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblerrMsg.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlAmendment_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            string intPIAid = "0";
            if (Session["user_type"].ToString().Trim() == "MORD")
            {

                intPIAid = Session["uid"].ToString().Trim();
            }
            else
            {
                intPIAid = Session["user_code"].ToString().Trim();
            }

            DataSet ds = new DataSet();
            ds = gen.GetUserCommentsofAmmendmentsid(Convert.ToInt32(ddlAmendment.SelectedValue));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvComments.DataSource = ds.Tables[0];
                gvComments.DataBind();
                trusercomments.Visible = true;
            }
            else
            {
                trusercomments.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblerrMsg.Text = ex.Message;
            Failure.Visible = true;
        }

    }
}