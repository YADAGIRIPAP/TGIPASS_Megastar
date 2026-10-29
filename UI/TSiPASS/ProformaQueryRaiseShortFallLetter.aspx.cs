using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_ProformaQueryRaiseShortFallLetter : System.Web.UI.Page
{
    General Gen = new General();
    string Incids = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                //if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
                //{
                string userid = Session["uid"].ToString();
                string incentiveid = "";
                incentiveid = Request.QueryString["incentiveid"].ToString();
                if (Request.QueryString.ToString().Contains("IncIds"))
                {
                    Incids = Request.QueryString["IncIds"].ToString();
                }
                // incentiveid = "1096";
                DataSet ds = new DataSet();
                ds = Gen.GetBasicUnitDetailsNewPsr(incentiveid, Incids);
                binddata(ds);

                DataSet dsname = new DataSet();
                dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, Incids, userid, "", "JDQUERYLETTERS");
                if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                {
                    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                    {
                        lblqueryraisedby.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                        lblqueryraisedbydesignation.Text = dsname.Tables[0].Rows[0]["Designation"].ToString();
                    }
                }
                //}
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        List<officerForwarded> lstincentives = new List<officerForwarded>();

        lstincentives = (List<officerForwarded>)Session["lstincentives"];
        officerForwarded frmvo = new officerForwarded();

        // int valid = Gen.InsertincentiveOfficerCommentsjDtoGM(lstincentives);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Query Submitted Successfully');" + "window.location='ApplicantIncentiveDtls.aspx?" + Session["querystring"].ToString() + "';", true);
    }


    public DataTable FilterDataTableBasedOnIncentiveIds(DataSet ds, string Incids, int index, string SearchText)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        dt = ds.Tables[index];
        dt1 = ds.Tables[index].Clone();//IncentiveID
        DataRow[] dw = dt.Select("" + SearchText + " in (" + Incids + ")");
        ds.Tables.RemoveAt(index);
        dt1.Rows.Clear();
        foreach (DataRow dr in dw)
        {
            dt1.ImportRow(dr);
        }
        return dt1;
    }

    public void binddata(DataSet ds)
    {
        // tmd.District_Name [unitdistrict],tmm.Manda_lName[unitmandal], tmv.Village_Name[unitvillage],comm.UnitHNO, comm.UnitStreet

        // lblLetterDate.Text = ds.Tables[0].Rows[0]["binddata"].ToString();
        if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
        {
            if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
            {
                lblTIdeaTPride.Text = "T-IDEA";
            }
        }
        if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
        {

            if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
            {
                lblTIdeaTPride.Text = "T-PRIDE";
            }
        }
        if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
        {
            if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
            {
                lblTIdeaTPride.Text = "T-PRIDE";
            }
        }
        if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
        {

            lblTIdeaTPride.Text = lblTIdeaTPride.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
           

        }
        if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != "")
        {
            lblEntDist.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            // lblEntDist1.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist2.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist4.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist5.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist6.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist3.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();

        }

        lblLetterNo.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
        //lblRefLetterNo.Text = "COI/" + Request.QueryString["incentiveid"].ToString();

        if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
        {
            lblEnterpreneurDetails.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
            lblApplicationNo.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
            lblEnterpreneurDetails2.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            //lblRefLetterDate.Text = ds.Tables[1].Rows[0]["DDAprrovalSent"].ToString();
            lblRefLetterDate.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
        }

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
        {
            lblquerydays.Text = Convert.ToString(ds.Tables[2].Rows[0]["querydays"]);
        }

        // bind query details grid
        string incentiveid = "";
        incentiveid = Request.QueryString["incentiveid"].ToString();
        DataSet daquerie = new DataSet();
        daquerie = Gen.GetIncetiveDetailsdeptOfficerRemarksDraft(incentiveid, "", Session["User_Code"].ToString(), "JD");
        if (daquerie != null && daquerie.Tables.Count > 0 && daquerie.Tables[0].Rows.Count > 0)
        {
            if (daquerie.Tables[0].Rows[0]["CreatedDate"].ToString() != null || daquerie.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
            {
                lblLetterDate.Text = daquerie.Tables[0].Rows[0]["CreatedDate"].ToString();
            }

            // added on 04/04/2018 
            //if (daquerie.Tables[0].Rows[0]["CreatedBy"].ToString() != null || daquerie.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
            //{
            //    if (daquerie.Tables[0].Rows[0]["CreatedBy"].ToString() == "Addl_director")
            //    {
            //        DateTime Addl_Date = Convert.ToDateTime(daquerie.Tables[0].Rows[0]["CreatedDate"].ToString());
            //        Addl_Date = Addl_Date.Date;
            //        DateTime addl_JoinDt = new DateTime(2018, 12, 01);
            //        if (Addl_Date >= addl_JoinDt.Date)
            //        {
            //            lblqueryraisedby.Text = "RAJKUMAR OHATKER";
            //            lblqueryraisedbydesignation.Text = "Additional Director";
            //        }
            //        if (Addl_Date < addl_JoinDt.Date)
            //        {
            //            lblqueryraisedby.Text = "RB DEVANAND";
            //            lblqueryraisedbydesignation.Text = "Additional Director";
            //        }
            //    }
            //}
            //

            if (Incids != "0" && Incids != "")
            {
                DataTable dt = FilterDataTableBasedOnIncentiveIds(daquerie, Incids, 0, "MstIncentiveId");
                daquerie.Tables.Add(dt);
            }

            gvShortfalls.DataSource = daquerie.Tables["Table"];
            gvShortfalls.DataBind();
            Session["CertificateTb2"] = daquerie.Tables["Table"];



            //foreach (GridViewRow rown in gvShortfalls.Rows)
            //{
            //    string name = ((Label)rown.FindControl("lblCreatedByid")).Text.ToString();
            //    if (Session["uid"].ToString() != name)
            //    {
            //        DataControlFieldCell editable = (DataControlFieldCell)rown.Controls[1];
            //        editable.Enabled = false;
            //    }
            //}
        }
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetIncetiveDetailsdept(incentiveid);

        //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        //{
        //    gvShortfalls.DataSource = dsnew.Tables[0];
        //    gvShortfalls.DataBind();
        //    gvShortfalls.Visible = true;
        //}

    }
}




