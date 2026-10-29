using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CheckPOITD : System.Web.UI.Page
{

    //designing and developed by siva as on 27-02-2016

    //Purpose : To update work Progress Details
    //Tables used :tbl_WorkProgress, tbl_WorkMaster,tbl_BeneficiaryDet
    //Stored procedures Used : GetworkproposalforProgress,GetBomawiseBeneficiarywithIP2,InsrtWorkProgressDet,WorkAllocation


    General Gen = new General();
    byte[] Photo = new byte[1];
    string PhotoFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        if (!IsPostBack)
        {
           
        }
        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
        {
            if (FileUpload1.PostedFile.ContentLength <= 307200)
            {
                lblmsg.Text = "";
                //lblFileName.Text = "";
                UploadImage();

            }
            else
                lblmsg.Text = "Trainee image should be less than 300 KB";
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Session["Photo"] = Photo;
            Session["PhotoFileName"] = "";

            if (FileUpload1.HasFile)
            {
                Session["FileUpload11"] = FileUpload1;
                hdfUploadFile1.Value = FileUpload1.FileName;
            }
            else if (Session["FileUpload11"] != null)
            {
                FileUpload1 = (FileUpload)Session["FileUpload11"];
                hdfUploadFile1.Value = FileUpload1.FileName;
            }
            
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            
            BtnSave1.Text = "Update";
        }

    }

    void UploadImage()
    {

        //PhotoFilename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        Session["PhotoFileName"] = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

        try
        {
            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
            int letterI = fileType.Length;
            //Photo = new byte[FileUpload1.PostedFile.ContentLength];

            //    Session["Photo"] = new byte[FileUpload1.PostedFile.ContentLength];

            if (
                fileType[letterI - 1].ToUpper().Trim() == "PNG" ||
                fileType[letterI - 1].ToUpper().Trim() == "JPG" ||
                fileType[letterI - 1].ToUpper().Trim() == "GIF" ||
                fileType[letterI - 1].ToUpper().Trim() == "JPEG")
            {
                //Photo = new byte[FileUpload1.PostedFile.ContentLength];

                Session["Photo"] = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                //Image.InputStream.Read(Photo, 0, (int)FileUpload1.PostedFile.ContentLength);
                //lblFileName.Text = PhotoFilename;
                //  ObjectToByteArray(Session["Photo"]);
                Image.InputStream.Read((byte[])Session["Photo"], 0, (int)FileUpload1.PostedFile.ContentLength);
                lblFileName.Text = Session["PhotoFileName"].ToString();

                //   Session["Photo"] = Photo;
                //   Session["PhotoFileName"] = PhotoFilename;

                Image1.ImageUrl = "ScanImage.aspx";



            }
            else
            {
                lblmsg.Text = "Image format should be JPG or JPEG or GIF or PNG";

            }

        }
        catch (Exception ex)
        {

            lblmsg.Text = "An Error Occured. Please Try Again!" + ex.Message;

        }

        finally
        {

        }


        FileUpload1.Focus();

    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.GetworkproposalforProgress(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblProject.Text = ds.Tables[0].Rows[0]["PrjName"].ToString();
            lblWorkCode.Text = ds.Tables[0].Rows[0]["workcode"].ToString();           
            //lblWorkActivity.Text=ds.Tables[0].Rows[0]["workcode"].ToString();
            //lblTarget.Text = ds.Tables[0].Rows[0]["EstManPower"].ToString();
            lblBoma.Text = ds.Tables[0].Rows[0]["BomaName"].ToString();
            lblWorkStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PDC_ApprvDate"].ToString()).ToString("dd-MM-yyyy");


            lblState.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
            lblCounty.Text = ds.Tables[0].Rows[0]["CountieName"].ToString();
            lblPayam.Text = ds.Tables[0].Rows[0]["PayamName"].ToString();



            //lblEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EstWorkEndDate"].ToString()).ToString("dd-MM-yyyy");
            //lblCost.Text = ds.Tables[0].Rows[0]["EstCost"].ToString();


            //////////////////////////


        //    DataSet dsBen = new DataSet();
        //    dsBen = Gen.GetBomawiseBeneficiarywithIP(ds.Tables[0].Rows[0]["intBomasid"].ToString(), Session["User_Code"].ToString());
       


        //DataTable dt = new DataTable();
        //Session["dss1"] = Gen.GetBomawiseBeneficiarywithIP(ds.Tables[0].Rows[0]["intBomasid"].ToString(), Session["User_Code"].ToString());
        //dt = new DataTable();
        //dt = ((DataSet)Session["dss1"]).Tables[0];
        //DataView dv = new DataView(dt);

        //dv.RowFilter = "WorkCode = " + dsBen.Tables[0].Rows[0]["WorkCode"].ToString().Trim();
        
        //dt = dv.ToTable();

        //((DataSet)Session["dss1"]).Tables[0].Clear();

        ////dss1.Tables.Add(dt);
        //DataSet ds12 = new DataSet();
        //ds12.Tables.Add(dt);

        //Session["dss1"] = ds12;



        //grdDetails.DataSource = dt;
        //grdDetails.DataBind();





            ///////////////////////////////




            //DataSet dsBen = new DataSet();
            //dsBen = Gen.GetBomawiseBeneficiarywithIP(ds.Tables[0].Rows[0]["intBomasid"].ToString(), Session["User_Code"].ToString());
            //if (dsBen.Tables[0].Rows.Count > 0)
            //{
            //    grdDetails.DataSource = dsBen.Tables[0];
            //    grdDetails.DataBind();
            //}

            if (ds.Tables[1].Rows.Count > 0)
            {
                gvpractical0.DataSource = ds.Tables[1];
                gvpractical0.DataBind();
            }

            DataSet dsnew = Gen.workProgressBendet(hdfID.Value.ToString());
            if (dsnew.Tables[1].Rows.Count > 0)
            {
                txtStartDate.Text = Convert.ToDateTime(dsnew.Tables[1].Rows[0]["WorkStartDate"].ToString()).ToString("dd-MM-yyyy");
                ddlStatus.SelectedValue = ddlStatus.Items.FindByValue(dsnew.Tables[1].Rows[0]["Status"].ToString()).Value;
                txtRemarks.Text = dsnew.Tables[1].Rows[0]["Remarks"].ToString();
                txtIncharge.Text = dsnew.Tables[1].Rows[0]["Incharge"].ToString();
                DataSet dsBen = new DataSet();
                dsBen = Gen.GetBomawiseBeneficiarywithIP2(ds.Tables[0].Rows[0]["intBomasid"].ToString(), Session["User_Code"].ToString(), dsnew.Tables[0].Rows[0]["WorkCode"].ToString());
                if (dsBen.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsBen.Tables[0];
                    grdDetails.DataBind();
                }


                
            }
            else
            {
                DataSet dsBen = new DataSet();
                dsBen = Gen.GetBomawiseBeneficiarywithIP(ds.Tables[0].Rows[0]["intBomasid"].ToString(), Session["User_Code"].ToString());
                if (dsBen.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsBen.Tables[0];
                    grdDetails.DataBind();
                }
            }
            if (dsnew.Tables[2].Rows.Count > 0)
            {
                if (dsnew.Tables[2].Rows[0]["PhotoFileName"].ToString() != "" && dsnew.Tables[2].Rows[0]["PhotoFileName"] != null)
                {
                    lblFileName.Text = dsnew.Tables[2].Rows[0]["PhotoFileName"].ToString();

                    Image1.ImageUrl = "viewAttachemnt.aspx?id=" + Convert.ToString(hdfID.Value.ToString()).Trim() + "&Type=Work Progress";


                    if (dsnew.Tables[2].Rows[0]["Photo"].ToString().Trim() != "")
                    {
                        Photo = (byte[])dsnew.Tables[2].Rows[0]["Photo"];
                        Session["Photo"] = Photo;
                        Session["PhotoFileName"] = dsnew.Tables[2].Rows[0]["PhotoFileName"].ToString();
                    }

                }
                else
                {
                    lblFileName.Text = "";
                }
            }

        }
    }    



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        
        int count = 0;
        for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
        {
            CheckBox c = (CheckBox)grdDetails.Rows[iii].Cells[0].FindControl("CheckBox1");


            if (c.Checked == true)
            {
                count++;
            }
            else
            {
            }
        }
        if (count == 0)
        {
            lblmsg0.Text = "At lease one Household should be selected";
            Failure.Visible = true;
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", lblmsg0.Text, true);
            return;

        }

        

        int i = Gen.InsrtWorkProgressDet(hdfID.Value.ToString(), txtStartDate.Text, ddlStatus.SelectedValue, txtRemarks.Text, Session["uid"].ToString(), txtIncharge.Text);
        if (i >0)
        {
            int j = Gen.InsrtUpdAttachment(i.ToString(), (byte[])(Session["Photo"]), Session["PhotoFileName"].ToString().Trim(), "Work Progress", Session["uid"].ToString());

            for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
            {
                GridViewRow row = (GridViewRow)grdDetails.Rows[iii];

                CheckBox c = (CheckBox)grdDetails.Rows[iii].Cells[0].FindControl("CheckBox1");
                if (c.Checked == true && c.Enabled == true)
                {
                    int s = Gen.WorkAllocation(hdfID.Value.ToString(), grdDetails.DataKeys[iii].Value.ToString(), Session["uid"].ToString());
                }
                
            }

            lblmsg.Text = "Submited Successfully..!";
            success.Visible = true;
            Failure.Visible = false;
            clear();
        }
        else
        {
            lblmsg0.Text = "Already Exist. ";
            success.Visible = false;
            Failure.Visible = true;
        }
    }

    void clear()
    {

    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            CheckBox chk = (CheckBox)e.Row.Cells[0].FindControl("CheckBox1");
            DataSet dsnew = Gen.workProgressBendet(hdfID.Value.ToString());
            int n = dsnew.Tables[0].Rows.Count;
            for (int r = 0; r < n; r++)
            {
                if (grdDetails.DataKeys[e.Row.RowIndex].Values[0].ToString() == dsnew.Tables[0].Rows[r]["intBenid"].ToString().Trim())
                {

                    chk.Checked = true;
                    chk.Enabled = false;
                    //BtnBatchsave.Visible = true;
                }
                else
                {
                    //BtnBatchsave.Visible= false;
                }
            }
        }
    }
    protected void grdDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        

        
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;

        DataSet ds = Gen.GetworkproposalforProgress(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            DataSet dsBen = new DataSet();
            dsBen = Gen.GetBomawiseBeneficiary(ds.Tables[0].Rows[0]["intBomasid"].ToString());
            if (dsBen.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsBen.Tables[0];
                grdDetails.DataBind();
            }

        }
    }
}
