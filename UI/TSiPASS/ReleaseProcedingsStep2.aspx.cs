using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class UI_TSiPASS_ReleaseProcedingsStep2 : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // string Slcno = Request.QueryString[0].ToString();
            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            string GoAllotedAmount = Request.QueryString[2].ToString();
            h1heading.InnerHtml = Cast + " Category";

            DataSet ds = new DataSet();
            ds = gen.getReleaseProceedingsStep2(Cast, Investmentid, GoAllotedAmount,"","");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                tdinvestments.InnerHtml = "--> " + ds.Tables[0].Rows[0]["IncentiveName"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();

                lblremaingAmount.Text = ds.Tables[1].Rows[0]["RemainingAmount"].ToString();
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        List<ReleasingProceedings> lstincentives = new List<ReleasingProceedings>();
        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            ReleasingProceedings frmvo = new ReleasingProceedings();
            string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
            string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
            string lblAllotedAmount = ((Label)gvrow.FindControl("lblAllotedAmount")).Text;
            string lblSLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;

            frmvo.EnterperIncentiveID = lblIncentiveID;
            frmvo.MstIncentiveId = lblMstIncentiveId;
            frmvo.CreatedByid = Session["uid"].ToString();
            frmvo.AllotedAmount = lblAllotedAmount;
            frmvo.SLCNo = lblSLCNumer;

            string txtGoNo = Session["txtGoNo"].ToString();
            string txtGodate = Session["txtGodate"].ToString();
            string txtLocno = Session["txtLocno"].ToString();
            string txtLocdate = Session["txtLocdate"].ToString();

            string[] godatett = txtGodate.Split('/');
            string[] locdate = txtLocdate.Split('/');

            frmvo.Godate = godatett[2] + "/" + godatett[1] + "/" + godatett[0];
            frmvo.Locdate = locdate[2] + "/" + locdate[1] + "/" + locdate[0];
            frmvo.Gono = txtGoNo;
            frmvo.Locno = txtLocno;

            lstincentives.Add(frmvo);
        }

        int valid = gen.InsertFinalProceedingsStep2(lstincentives);

        if (valid == 1)
        {
            //lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
            //success.Visible = true;
            //Failure.Visible = false;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);

            string message = "alert('amount alloted Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            lblmsg.Text = "Amount alloted Successfully";
            success.Visible = true;
            trprint.Visible = true;

        }
        else
        {
            trprint.Visible = false;
        }
        //lblmsg.Text = "<font color='green'>Saved Successfully..!</font>";
        //success.Visible = true;
        //Failure.Visible = false;
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

}