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
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    decimal TotalFee = Convert.ToDecimal("0");
    string Grivance_File_Path, Grivance_File_Type, Grievnace_FileName;
    string Grivance_File_Path1, Grivance_File_Type1, Grievnace_FileName1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

      

        //if (!IsPostBack)
        //{


        //    DataSet dscheck = new DataSet();
        //    dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
        //    if (dscheck.Tables[0].Rows.Count > 0)
        //    {
        //        Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
        //    }
        //    else
        //    {
        //        Session["Applid"] = "0";
        //    }

        //    DataSet dsver = new DataSet();

        //    dsver = Gen.Getverifyofque9(Session["Applid"].ToString());

        //    if (dsver.Tables[0].Rows.Count > 0)
        //    {
        //        string res = Gen.RetriveStatus(Session["Applid"].ToString());
        //        ////string res = Gen.RetriveStatus("1002");


        //        if (res == "3" || Convert.ToInt32(res) >= 3)
        //        {
        //            ResetFormControl(this);
        //            BtnClear.Visible = false;
        //            BtnSave.Visible = false;
        //            BtnSave1.Visible = false;
        //        }

        //    }



        //}




        if (!IsPostBack)
        {
            BtnSave0.Visible = false;
            GetDistrict();

            if (Session["userlevel"].ToString() == "10")
            {
                ddlProp_intDistrictid.SelectedValue = ddlProp_intDistrictid.Items.FindByValue(Gen.GetDistrictByUsercode(Session["DistrictID"].ToString().Trim()).Tables[0].Rows[0][0].ToString().Trim()).Value;
                ddlProp_intDistrictid.Enabled = false;

                if (ddlProp_intDistrictid.SelectedValue != "--Select--")
                {

                    DataSet dsnew = new DataSet();

                    dsnew = Gen.Getmandalsbydistrict(ddlProp_intDistrictid.SelectedValue.ToString());
                    ddlLoc_of_unit.DataSource = dsnew.Tables[0];
                    ddlLoc_of_unit.DataTextField = "Manda_lName";
                    ddlLoc_of_unit.DataValueField = "Mandal_Id";
                    ddlLoc_of_unit.DataBind();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                }
            }
            else if (Session["userlevel"].ToString() == "13")
            {
                GetDistrict();
            }

           

            //if (ddlProp_intDistrictid.SelectedValue.ToString() != "--District--")
            //{

                //DataSet dsss = new DataSet();
                //dsss = Gen.GetShowLOcationofUnitByDistict(ddlProp_intDistrictid.SelectedValue);
                //if (dsss.Tables[0].Rows.Count > 0)
                //{
                //    if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
                //    {
                //        ddlLoc_of_unit.Items.Clear();
                //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
                //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));






                //    }
                //    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
                //    {
                //        ddlLoc_of_unit.Items.Clear();
                //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
                //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));




                //    }
                //    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
                //    {
                //        ddlLoc_of_unit.Items.Clear();
                //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
                //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));


                //        if (ddlProp_intDistrictid.SelectedValue.ToString() == "9" || ddlProp_intDistrictid.SelectedValue.ToString() == "3")
                //        {
                //            ddlLoc_of_unit.Items.Insert(3, new ListItem("Within the purview of DT&CP", "2"));

                //        }



                //    }
                //    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
                //    {
                //        ddlLoc_of_unit.Items.Clear();
                //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
                //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

                //    }
                //}
                //else
                //{
                //    ddlLoc_of_unit.Items.Clear();
                //    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //}

            //}
                


            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            ddlintLineofActivity.Items.Insert(0, "--Select--");
            Session["Applid"] = "0";
            tr3.Visible = false;
           // ddlLoc_of_unit.Items.Clear();
           // ddlLoc_of_unit.Items.Insert(0, "--Select--");
        }
        if (!IsPostBack)
        {
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb"] = dtMyTableCertificate;
           // BtnSave.Visible = false;

          //  fillDetails();
           // CalcFees();
           // hdnfocus.Value = ddlConst_of_unit.ClientID;
        }

        //    if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        //    {

        //    }
        //}


        //public void ResetFormControl(Control parent)
        //{
        //    foreach (Control c in parent.Controls)
        //    {
        //        if (c.Controls.Count > 0)
        //        {
        //            ResetFormControl(c);
        //        }
        //        else
        //        {
        //            switch (c.GetType().ToString())
        //            {
        //                case "System.Web.UI.WebControls.TextBox":
        //                    ((TextBox)c).ReadOnly = true;
        //                    break;

        //                case "System.Web.UI.WebControls.DropDownList":

        //                    if (((DropDownList)c).Items.Count > 0)
        //                    {
        //                        ((DropDownList)c).Enabled = false;
        //                    }
        //                    break;
        //                case "System.Web.UI.WebControls.FileUpload":
        //                    ((FileUpload)c).Enabled = false;
        //                    break;
        //                case "System.Web.UI.WebControls.RadioButtonList":
        //                    ((RadioButtonList)c).Enabled = false;
        //                    break;

        //                case "System.Web.UI.WebControls.CheckBoxList":
        //                    ((CheckBoxList)c).Enabled = false;
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
    //    public void fillDetails()
    //    {

    //         DataSet dscheck = new DataSet();
    //            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
    //            if (dscheck.Tables[0].Rows.Count > 0)
    //            {
                   
    //DataSet dsss = new DataSet();
    //                    dsss = Gen.GetShowLOcationofUnitByDistict(ddlProp_intDistrictid.SelectedValue);
    //                    if (dsss.Tables[0].Rows.Count > 0)
    //                    {
    //                        if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
    //                        {
    //                            ddlLoc_of_unit.Items.Clear();
    //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
    //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));






    //                        }
    //                        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
    //                        {
    //                            ddlLoc_of_unit.Items.Clear();
    //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
    //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                              



    //                        }
    //                        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
    //                        {
    //                            ddlLoc_of_unit.Items.Clear();
    //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
    //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                             

    //                            if (ddlProp_intDistrictid.SelectedValue.ToString() == "9" || ddlProp_intDistrictid.SelectedValue.ToString() == "3")
    //                            {
    //                                ddlLoc_of_unit.Items.Insert(3, new ListItem("Within the purview of DT&CP", "2"));

    //                            }



    //                        }
    //                        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
    //                        {
    //                            ddlLoc_of_unit.Items.Clear();
    //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
    //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                                
    //                        }
    //                    }
    //                    else
    //                    {
    //                        ddlLoc_of_unit.Items.Clear();
    //                        ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                    }
    //                }
                   
                 
    //                ddlintLineofActivity.SelectedValue =ddlintLineofActivity.Items.FindByValue( dscheck.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;



    //                if (ddlintLineofActivity.SelectedIndex == 0)
    //                {
    //                    HdfLblPol_Category.Value = "";
    //                    LblPol_Category.Text = "";
    //                 //   trFallinPolution.Visible = false;
    //                   //RdPol_Indus.Enabled = false;
    //                }
    //                else
    //                {
    //                    DataSet dsct = new DataSet();
    //                    dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
    //                    if (dsct.Tables[0].Rows.Count > 0)
    //                    {

    //                        if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
    //                        {
    //                            HdfLblPol_Category.Value = "Orange";
    //                            LblPol_Category.Text = "<font color=Orange>Orange</font>";
    //                            //if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
    //                            //{
    //                            //    //   trFallinPolution.Visible = true;
    //                            //}
    //                            //else
    //                            //{
    //                            //    //     trFallinPolution.Visible = false;
    //                            //}

    //                        }
    //                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
    //                        {
    //                            HdfLblPol_Category.Value = "Red";
    //                            LblPol_Category.Text = "<font color=Red>Red</font>";
    //                            //  trFallinPolution.Visible = false;
    //                        }
    //                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
    //                        {
    //                            HdfLblPol_Category.Value = "Green";
    //                            // trFallinPolution.Visible = true;
    //                            LblPol_Category.Text = "<font color=Green>Green</font>";
    //                        }
    //                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
    //                        {
    //                            HdfLblPol_Category.Value = "White";
    //                            //   trFallinPolution.Visible = true;
    //                            LblPol_Category.Text = "White";
    //                        }
                            
                           
    //                    }

    //                    else
    //                    {
    //                        HdfLblPol_Category.Value = "";
    //                        LblPol_Category.Text = "";
    //                        //RdPol_Indus.Enabled = false;
    //                        //trFallinPolution.Visible = false;
    //                    }

    //                }
                    
            

    //                //RdDo_Store_Kerosine.SelectedValue = RdDo_Store_Kerosine.Items.FindByValue(dscheck.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim()).Value;

                    
    //                TxtnameofUnit.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
    //                if(dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim() !="")
                       

    //                //if (dscheck.Tables[1].Rows.Count > 0)
    //                //{
    //                //    grdDetails.DataSource = dscheck.Tables[1];
    //                //    grdDetails.DataBind();
    //                //}
    //                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
    //                BtnClear.Visible = false;
    //                if (ddlLoc_of_unit.SelectedIndex != 0)
    //                {
    //                    if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "1")
    //                    {
    //                        trApplType.Visible = true;
    //                    }
    //                    else
    //                    {
    //                        trApplType.Visible = false;
    //                    }
    //                }
    //                else
    //                {
    //                    trApplType.Visible = false;
    //                }
    //                //CalcFees();
    //            }
       protected void   GetDistrict()
{

    DataSet dsd = new DataSet();
    dsd = Gen.GetDistrictsWithoutHYD();
    ddlProp_intDistrictid.DataSource = dsd.Tables[0];
    ddlProp_intDistrictid.DataValueField = "District_Id";
    ddlProp_intDistrictid.DataTextField = "District_Name";
    ddlProp_intDistrictid.DataBind();
    //ddlProp_intDistrictid.Items.Insert(0, "--District--");
    //ddlLoc_of_unit.DataSource = dsd.Tables[0];
    //ddlLoc_of_unit.DataValueField = "District_Id";
    //ddlLoc_of_unit.DataTextField = "District_Name";
    //ddlLoc_of_unit.DataBind();
    //ddlLoc_of_unit.Items.Insert(0, "--Select--");

        //if (Session["userlevel"].ToString().Trim() == "6")
        //{
        //    ddlProp_intDistrictid.SelectedValue = ddlProp_intDistrictid.Items.FindByValue(Gen.GetDistrictByUsercode(Session["DistrictID"].ToString().Trim()).Tables[0].Rows[0][0].ToString().Trim()).Value;
        //    ddlProp_intDistrictid.Enabled = false;
        //}
}
     

             protected void  RdDo_Store_Kerosine_SelectedIndexChanged(object sender, EventArgs e)
{

}


        protected void btnOrgLookup_Click(object sender, EventArgs e)
        {

        }
        protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {


                DataSet ds = new DataSet();
                ds = Gen.FetchUserdetEMINo(TxtEMNo.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                   string mesg1 = "This User was Already Registered";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mesg1 + "');", true);
                    //TxtMandalCode.Focus();
                    //ddlVillage.Focus();
                    return;
                }


                int s = Gen.InsertMEMS(txtMinorityType.Text, RadioButtonList1.SelectedValue, txtUnitAddress.Text, ddlLoc_of_unit0.SelectedValue, RdDo_Store_Kerosine0.SelectedValue, TxtnameofUnit.Text, ddlLoc_of_unit.SelectedValue, TxtEMNo.Text, ddlProp_intDistrictid.SelectedValue, ddlintLineofActivity.SelectedValue, txtProdution.Text, "", "", "", "", "", "", txtInverstment.Text, txtEmployement.Text, txtRegDate.Text, ddlcategory.SelectedValue, HdfLblPol_Category.Value, ddlCaste.SelectedValue, RdDo_Store_Kerosine.SelectedValue, ddlPower.SelectedValue, txtVoltage.Text, txtMajorclients.Text, txtOutSideclients.Text, Session["uid"].ToString().Trim(),TxtSector.Text,TxtindicateState1.Text,txtIndicateState2.Text,txtCountry1.Text,TxtCountry2.Text);


                if (s != 999)
                {
                   // clear();
                    
                    Label584.Text = "Please Upload Documents";

                    BtnSave.Visible = false;
                    BtnClear.Visible = false;
                    uploadnew.Visible = true;
                    uploadnew1.Visible = true;
                    uploadnew2.Visible = true;
                    uploadnew3.Visible = true;
                    uploadnew4.Visible = true;
                    uploadnew5.Visible = true;
                  //  uploadnew6.Visible = true;
                    BtnSave0.Visible = true;

                    //string applno = "";
                    hdfFlagID0.Value = s.ToString();



                    
                }

               
           
            }
            catch (Exception ex)
            {


            }
            finally
            {

                
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
        public void DeleteFile1(string strFileName1)
        {//Delete file from the server
            if (strFileName1.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName1);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        
        void clear()
        {
txtMinorityType.Text="";
            RadioButtonList1.SelectedIndex=0;
             txtUnitAddress.Text="";
            ddlLoc_of_unit0.SelectedIndex=0;
           
            TxtnameofUnit.Text="";
            ddlLoc_of_unit.SelectedIndex = 0;
            TxtEMNo.Text="";
            
            ddlProp_intDistrictid.SelectedIndex=0;
            ddlintLineofActivity.SelectedIndex=0;
            txtProdution.Text="";
            txtInverstment.Text="";
            txtEmployement.Text="";
            txtRegDate.Text="";
            ddlcategory.SelectedIndex=0;
            LblPol_Category.Text="";
            ddlCaste.SelectedIndex=0;
            ddlPower.SelectedIndex=0;
            txtVoltage.Text="";
            txtMajorclients.Text="";
            txtOutSideclients.Text="";
            TxtSector.Text = ""; TxtindicateState1.Text = ""; txtIndicateState2.Text = ""; txtCountry1.Text = ""; TxtCountry2.Text = "";

            //gvCertificate.DataSource = null;
            //gvCertificate.DataBind();
            //Session["CertificateTb"] = null;
           


        }




        protected void BtnClear_Click(object sender, EventArgs e)
        {
            cmf.ResetFormControl(this);
            //grdDetails.DataSource = null;
            //grdDetails.DataBind();
           // HdfLblEnt_is.Value = "";
            HdfLblPol_Category.Value = "";
           // LblEnt_is.Text = "";
            LblPol_Category.Text = "";
           // BtnSave.Visible = false;
           // Txt_NoofTrees.Text = "";
            clear();
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void BtnSave2_Click(object sender, EventArgs e)
        {

            try
            {



            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.ToString();
            }
            finally
            {

            }

        }

        private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
        {




        }

        protected void BtnClear0_Click1(object sender, EventArgs e)
        {

        }
        


        protected void GetNewRectoInsertdr()
        {

        }


        protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlintLineofActivity.SelectedIndex == 0)
            {
                HdfLblPol_Category.Value = "";
                LblPol_Category.Text = "";
                //  trFallinPolution.Visible = false;
                // RdPol_Indus.Enabled = false;
            }
            else
            {
                DataSet dsct = new DataSet();
                dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
                if (dsct.Tables[0].Rows.Count > 0)
                {

                    if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                    {
                        HdfLblPol_Category.Value = "Orange";
                        LblPol_Category.Text = "<font color=Orange>Orange</font>";

                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                    {
                        HdfLblPol_Category.Value = "Red";
                        LblPol_Category.Text = "<font color=Red>Red</font>";
                        //  trFallinPolution.Visible = false;
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                    {
                        HdfLblPol_Category.Value = "Green";
                        // trFallinPolution.Visible = true;
                        LblPol_Category.Text = "<font color=Green>Green</font>";
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                    {
                        HdfLblPol_Category.Value = "White";
                        //   trFallinPolution.Visible = true;
                        LblPol_Category.Text = "White";
                    }


                    else
                    {
                        HdfLblPol_Category.Value = "";
                        LblPol_Category.Text = "";
                        // RdPol_Indus.Enabled = false;
                        //trFallinPolution.Visible = false;
                    }

                }
                hdnfocus.Value = ddlintLineofActivity.ClientID;
            }
        }
        //protected void TxtVal_Plant_TextChanged(object sender, EventArgs e)
        //{
        //    CalculatationEnterprisePrjCost();
        //    CalculatationEnterprise();
        //    //hdnfocus.Value = TxtVal_Plant.ClientID;
        //}

        // public void CalculatationEnterprisePrjCost()
        //{
        //    if (ddlSector_Ent.SelectedIndex != 0)
        //    {
        //        if (TxtVal_Build.Text.Trim() == "")
        //        {
        //            TxtVal_Build.Text = "0";
        //        }

        //        if (TxtVal_Land.Text.Trim() == "")
        //        {
        //            TxtVal_Land.Text = "0";
        //        }

        //        if (TxtVal_Plant.Text.Trim() == "")
        //        {
        //            TxtVal_Plant.Text = "0";
        //        }
        //        TxtTot_PrjCost.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Build.Text) + Convert.ToDecimal(TxtVal_Land.Text) + Convert.ToDecimal(TxtVal_Plant.Text)));
        //        lblmsg.Text = "";
        //    }
        //    else
        //    {
        //        TxtTot_PrjCost.Text = "0";
        //        lblmsg.Text = "Please Select Sector of Enterprise";
        //    }
        //}

        //public void CalculatationEnterprise()
        //{
        //    if (ddlSector_Ent.SelectedIndex != 0)
        //    {

        //        if (TxtProp_Emp.Text.Trim() == "")
        //        {
        //            TxtProp_Emp.Text = "0";
        //        }

        //        lblmsg.Text = "";
        //        DataSet dsEnter = new DataSet();
        //        if (ddlSector_Ent.SelectedValue == "2")
        //        {
        //            if (Convert.ToDecimal(TxtTot_PrjCost.Text) >= Convert.ToDecimal("20000"))
        //            {
        //                HdfLblEnt_is.Value = "Mega";

        //                LblEnt_is.Text = "Mega";
        //            }
        //            else
        //            {
        //                dsEnter = Gen.GetEnterPriseIs(TxtVal_Plant.Text, ddlSector_Ent.SelectedValue);
        //                if (dsEnter.Tables[0].Rows.Count > 0)
        //                {
        //                    HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
        //                    LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
        //                }
        //                else
        //                {
        //                    HdfLblEnt_is.Value = "";
        //                    LblEnt_is.Text = "";
        //                }
        //            }
        //        }
        //        else if (ddlSector_Ent.SelectedValue == "1")
        //        {
        //            if (Convert.ToDecimal(TxtTot_PrjCost.Text) >= Convert.ToDecimal("20000"))
        //            {
        //                HdfLblEnt_is.Value = "Mega";

        //                LblEnt_is.Text = "Mega";
        //            }
        //            else
        //            {
        //                dsEnter = Gen.GetEnterPriseIs(TxtVal_Plant.Text, ddlSector_Ent.SelectedValue);
        //                if (dsEnter.Tables[0].Rows.Count > 0)
        //                {
        //                    HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
        //                    LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
        //                }
        //                else
        //                {
        //                    HdfLblEnt_is.Value = "";
        //                    LblEnt_is.Text = "";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            HdfLblEnt_is.Value = "";
        //            LblEnt_is.Text = "";
        //        }

        //        if (Convert.ToDecimal(TxtProp_Emp.Text) >= Convert.ToDecimal("1000"))
        //        { HdfLblEnt_is.Value = "Mega";
        //        LblEnt_is.Text = "Mega";
        //        }
        //        success.Visible = false;
        //    }
        //    else
        //    {
        //        HdfLblEnt_is.Value = "";
        //        LblEnt_is.Text = "";
        //        success.Visible = true;
        //        lblmsg.Text = "Please Select Sector of Enterprise";
        //    }


        //    if (ddlintLineofActivity.SelectedIndex == 0)
        //    {
        //        HdfLblPol_Category.Value = "";
        //        LblPol_Category.Text = "";
        //        //   trFallinPolution.Visible = false;
        //        RdPol_Indus.Enabled = false;
        //    }
        //    else
        //    {
        //        DataSet dsct = new DataSet();
        //        dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
        //        if (dsct.Tables[0].Rows.Count > 0)
        //        {

        //            if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
        //            {
        //                HdfLblPol_Category.Value = "Orange";
        //                LblPol_Category.Text = "<font color=Orange>Orange</font>";
        //                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
        //                {
        //                    //   trFallinPolution.Visible = true;
        //                }
        //                else
        //                {
        //                    //     trFallinPolution.Visible = false;
        //                }

        //            }
        //            else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
        //            {
        //                HdfLblPol_Category.Value = "Red";
        //                LblPol_Category.Text = "<font color=Red>Red</font>";
        //                //  trFallinPolution.Visible = false;
        //            }
        //            else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
        //            {
        //                HdfLblPol_Category.Value = "Green";
        //                // trFallinPolution.Visible = true;
        //                LblPol_Category.Text = "<font color=Green>Green</font>";
        //            }
        //            else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
        //            {
        //                HdfLblPol_Category.Value = "White";
        //                //   trFallinPolution.Visible = true;
        //                LblPol_Category.Text = "White";
        //            }
        //            if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
        //            {
        //                if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
        //                {
        //                    RdPol_Indus.SelectedValue = "Y";

        //                }
        //                else
        //                {
        //                    RdPol_Indus.SelectedValue = "N";

        //                }
        //            }
        //            else
        //            { RdPol_Indus.SelectedValue = "Y"; }
        //            RdPol_Indus.Enabled = false;
        //        }

        //        else
        //        {
        //            HdfLblPol_Category.Value = "";
        //            LblPol_Category.Text = "";
        //            RdPol_Indus.Enabled = false;
        //            trFallinPolution.Visible = false;
        //        }

        //    }

        //    if (TxtVal_Plant.Text == "" || TxtVal_Plant.Text == "0")
        //    {
        //        HdfLblEnt_is.Value = "";
        //        LblEnt_is.Text = "";
        //    }
        //}
        //protected void TxtVal_Land_TextChanged(object sender, EventArgs e)
        //{
        //    CalculatationEnterprisePrjCost();
        //    CalculatationEnterprise();
        //    if (ddlSector_Ent.SelectedIndex == 0)
        //    {
        //        HdfLblEnt_is.Value = "";
        //        LblEnt_is.Text = "";
        //    }

        //    hdnfocus.Value =TxtVal_Build.ClientID;
        //}
        //protected void TxtVal_Build_TextChanged(object sender, EventArgs e)
        //{
        //    CalculatationEnterprisePrjCost();
        //    CalculatationEnterprise();
        //    if (ddlSector_Ent.SelectedIndex == 0)
        //    {
        //        HdfLblEnt_is.Value = "";
        //        LblEnt_is.Text = "";
        //    }
        //    hdnfocus.Value =TxtVal_Plant.ClientID;
        //}
        //protected void ddlSector_Ent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CalculatationEnterprisePrjCost();
        //    CalculatationEnterprise();
        //    if (ddlSector_Ent.SelectedIndex == 0)
        //    {
        //        HdfLblEnt_is.Value = "";
        //        LblEnt_is.Text = "";
        //    }

        //    hdnfocus.Value = ddlSector_Ent.ClientID;
        //}
        protected void BtnApprovalFees_Click(object sender, EventArgs e)
        {
            //string SearchVerfi = "";

            //if (RdFall_in_Municipal.SelectedValue.ToString().Trim() == "N")
            //{
            //    SearchVerfi = "2";
            //}
            //DataSet dsv = new DataSet();
            //dsv = Gen.GetShowApprovalandFees(SearchVerfi);
            //if (dsv.Tables[0].Rows.Count > 0)
            //{
            //    grdDetails.DataSource = dsv.Tables[0];
            //    grdDetails.DataBind();
            //}
            //else
            //{
            //    grdDetails.DataSource = null;
            //    grdDetails.DataBind();
            //}
        }
        //protected void TxtProp_Emp_TextChanged(object sender, EventArgs e)
        //{
        //    CalculatationEnterprise();
        //    hdnfocus.Value =TxtVal_Land.ClientID;
        //}
        //protected void RdProp_Site_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (RdProp_Site.SelectedValue.ToString().Trim() == "Y")
        //    {
        //        trtrees.Visible = true;
        //        Txt_NoofTrees.Text = "";
        //        tr4.Visible = true;
        //    }
        //    else
        //    {
        //        Txt_NoofTrees.Text = "";
        //        trtrees.Visible = false;
        //        tr4.Visible = false;
        //    }
        //    hdnfocus.Value = RdProp_Site.ClientID;
        //}
       
        protected void BtnClear0_Click(object sender, EventArgs e)
        {
           
        }
        //protected void ddlLoc_of_unit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlLoc_of_unit.SelectedIndex != 0)
        //    {
        //        if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "1")
        //        {
        //            trApplType.Visible = true;

        //            ddlAppl_Type.Items.Clear();
        //            ddlAppl_Type.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlAppl_Type.Items.Insert(1, new ListItem("Change of Land Use", "1"));
        //            ddlAppl_Type.Items.Insert(2, new ListItem("Industrial Building Approval", "2"));
        //            ddlAppl_Type.Items.Insert(3, new ListItem("Both", "3"));
        //            ChkWater_reg_from.Items[1].Selected = true;
        //            ChkWater_reg_from.Items[1].Enabled = false;
        //        }
        //        else if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "5")
        //        {
        //            trApplType.Visible = true;
        //            ddlAppl_Type.Items.Clear();
        //            ddlAppl_Type.Items.Insert(0,new ListItem("Industrial Building Approval", "2"));

        //            ChkWater_reg_from.Items[1].Selected = true;
        //            ChkWater_reg_from.Items[1].Enabled = true;
        //        }
        //        else if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "3")
        //        {
        //            trApplType.Visible = true;
        //            ddlAppl_Type.Items.Clear();
        //            ddlAppl_Type.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlAppl_Type.Items.Insert(1, new ListItem("Change of Land Use", "1"));
        //            ddlAppl_Type.Items.Insert(2, new ListItem("Industrial Building Approval", "2"));
        //            ddlAppl_Type.Items.Insert(3, new ListItem("Both", "3"));
        //            ChkWater_reg_from.Items[1].Selected = false;
        //            ChkWater_reg_from.Items[1].Enabled = false;
        //        }

        //        else
        //        {
        //            trApplType.Visible = false;
        //            ChkWater_reg_from.Items[1].Selected = false;
        //            ChkWater_reg_from.Items[1].Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        trApplType.Visible = false;
        //    }
        //    hdnfocus.Value = ddlLoc_of_unit.ClientID;
        //   // ddlLoc_of_unit.Focus();
        //}
       

    
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        string applMSME = "";
        applMSME = hdfFlagID0.Value.ToString();

            string newPath = "";
            Grivance_File_Path= "";
            Grivance_File_Type = "";
            Grievnace_FileName = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MSME\\Certifications");

            General t1 = new General();
            if (FileUpload17.HasFile)
            {
                if ((FileUpload17.PostedFile != null) && (FileUpload17.PostedFile.ContentLength > 0))//(FileUpload4.PostedFile != null) &&
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload17.PostedFile.FileName);
                    try
                    {
                        //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                        //{
                        //    //Save File on disk


                        //if (FileUpload1.FileContent.Length > 102400 * 18)
                        //{
                        //     lblmsg0.Text = "size should be less than 600KB";
                        //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                        //    return;
                        //}

                        string[] fileType = FileUpload17.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                            //////////////
                            Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                            Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                            Grievnace_FileName = sFileName;
                            // Create the subfolder
                            if (!Directory.Exists(Grivance_File_Path))

                                System.IO.Directory.CreateDirectory(Grivance_File_Path);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Grivance_File_Path);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload17.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(Grivance_File_Path);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload17.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                                }
                            }

                            int result = 0;
                            result = t1.sp_InsertMSMEImagenew(Session["uid"].ToString(), fileType[i - 1].ToUpper(), Grivance_File_Path, Grievnace_FileName, "Other", "C", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), applMSME.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName.Text = FileUpload17.FileName;
                                Label444.Text = FileUpload17.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(Grivance_File_Path + "\\" + Grievnace_FileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }

            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
            
        
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        string newPath = "";
        Grivance_File_Path = "";
        Grivance_File_Type = "";
        Grievnace_FileName = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\MSME\\Products");

        General t1 = new General();
        if ((FileUpload9.PostedFile != null) && (FileUpload9.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload9.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload9.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                    Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                    Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                    Grievnace_FileName = sFileName;
                    // Create the subfolder
                    if (!Directory.Exists(Grivance_File_Path))

                        System.IO.Directory.CreateDirectory(Grivance_File_Path);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Grivance_File_Path);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload9.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(Grivance_File_Path);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload9.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                        }
                    }
                   
                    int result = 0;
                    gvCertificate.Visible = true;
                    string other;
                    //if (txtOthers.Text == "" || txtOthers.Text == null)
                    //    other = ddlAttachmentType.SelectedItem.Text;
                    //else
                       other = txtOthers.Text;
                    AddDataToTableCeertificate(other, "0", sFileName, (DataTable)Session["CertificateTb"]);

                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                    this.gvCertificate.DataBind();
                    //   result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.sp_InsertMSMEImagenew(Session["uid"].ToString(), fileType[i - 1].ToUpper(), Grivance_File_Path, Grievnace_FileName, txtOthers.Text, "P", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(),hdfFlagID0.Value.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label5.Text = FileUpload9.FileName;
                        txtOthers.Text = "";
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(Grivance_File_Path + "\\" + Grievnace_FileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }

    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
        //dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
        // dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        //  dtMyTable.Columns.Add("Created_by", typeof(string));

        //   dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


        return dtMyTable;
    }

    private void AddDataToTableCeertificate(string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb");

              Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["Manf_ItemName"] = Manf_ItemName;
            //Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            //    Row["Created_by"] = Session["uid"].ToString().Trim();
            //   Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }



    //protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlintLineofActivity.SelectedIndex == 0)
    //    {
    //        HdfLblPol_Category.Value = "";
    //        LblPol_Category.Text = "";
    //        //  trFallinPolution.Visible = false;
    //        // RdPol_Indus.Enabled = false;
    //    }
    //    else
    //    {
    //        DataSet dsct = new DataSet();
    //        dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
    //        if (dsct.Tables[0].Rows.Count > 0)
    //        {

    //            if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
    //            {
    //                HdfLblPol_Category.Value = "Orange";
    //                LblPol_Category.Text = "<font color=Orange>Orange</font>";
    //                //if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
    //                //{
    //                //    //   trFallinPolution.Visible = true;
    //                //}
    //                //else
    //                //{
    //                //    //     trFallinPolution.Visible = false;
    //                //}

    //            }
    //            else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
    //            {
    //                HdfLblPol_Category.Value = "Red";
    //                LblPol_Category.Text = "<font color=Red>Red</font>";
    //                //  trFallinPolution.Visible = false;
    //            }
    //            else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
    //            {
    //                HdfLblPol_Category.Value = "Green";
    //                // trFallinPolution.Visible = true;
    //                LblPol_Category.Text = "<font color=Green>Green</font>";
    //            }
    //            else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
    //            {
    //                HdfLblPol_Category.Value = "White";
    //                //   trFallinPolution.Visible = true;
    //                LblPol_Category.Text = "White";
    //            }
    //            //    if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
    //            //    {
    //            //        if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
    //            //        {
    //            //            RdPol_Indus.SelectedValue = "Y";

    //        //        }
    //            //        else
    //            //        {
    //            //            RdPol_Indus.SelectedValue = "N";

    //        //        }
    //            //    }
    //            //    else
    //            //    { RdPol_Indus.SelectedValue = "Y"; }
    //            //    RdPol_Indus.Enabled = false;
    //            //}

    //            else
    //            {
    //                HdfLblPol_Category.Value = "";
    //                LblPol_Category.Text = "";
    //                //RdPol_Indus.Enabled = false;
    //                //trFallinPolution.Visible = false;
    //            }

    //        }
    //        hdnfocus.Value = ddlintLineofActivity.ClientID;
    //    }
    //}

    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddlProp_intDistrictid.SelectedValue.ToString());
        ddlLoc_of_unit.DataSource = dsnew.Tables[0];
        ddlLoc_of_unit.DataTextField = "Manda_lName";
        ddlLoc_of_unit.DataValueField = "Mandal_Id";
        ddlLoc_of_unit.DataBind();
        ddlLoc_of_unit.Items.Insert(0, "--Select--");


    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged1(object sender, EventArgs e)
    {

        if (ddlProp_intDistrictid.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }

        //DataSet dsss = new DataSet();
        //                    dsss = Gen.GetShowLOcationofUnitByDistict(ddlProp_intDistrictid.SelectedValue);
        //                    if (dsss.Tables[0].Rows.Count > 0)
        //                    {
        //                        if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
        //                        {
        //                            ddlLoc_of_unit.Items.Clear();
        //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
        //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
        //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));






        //                        }
        //                        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
        //                        {
        //                            ddlLoc_of_unit.Items.Clear();
        //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
        //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
        //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));




        //                        }
        //                        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
        //                        {
        //                            ddlLoc_of_unit.Items.Clear();
        //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
        //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
        //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));


        //                            if (ddlProp_intDistrictid.SelectedValue.ToString() == "9" || ddlProp_intDistrictid.SelectedValue.ToString() == "3")
        //                            {
        //                                ddlLoc_of_unit.Items.Insert(3, new ListItem("Within the purview of DT&CP", "2"));

        //                            }



        //                        }
        //                        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
        //                        {
        //                            ddlLoc_of_unit.Items.Clear();
        //                            ddlLoc_of_unit.Items.Insert(0, "--Select--");
        //                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
        //                            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

        //                        }
        //                    }
        //                    else
        //                    {
        //                        ddlLoc_of_unit.Items.Clear();
        //                        ddlLoc_of_unit.Items.Insert(0, "--Select--");
        //                    }
        //               
    }


    protected void RdDo_Store_Kerosine0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdDo_Store_Kerosine0.SelectedValue=="Y")
        {
            trfallin.Visible = true;
            trCountry1.Visible = true;
            trCountry2.Visible = true;
        }
        else
        {
            trfallin.Visible = false;
            trCountry1.Visible = false;
            trCountry2.Visible = false;
        }
    }
    protected void BtnSave0_Click(object sender, EventArgs e)
    {


        if (((DataTable)Session["CertificateTb"]).Rows.Count == 0)
        {
            //lblresult.Text = "Please Add Product Details";
            string mesg1 = "Please Add Product Document";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mesg1 + "');", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mesg1 + "');", true);
            //TxtMandalCode.Focus();
            //ddlVillage.Focus();
            return;
        }

        gvCertificate.DataSource = null;
        gvCertificate.DataBind();
        Session["CertificateTb"] = null;

        Response.Redirect("Resultdatalatest.aspx?id=A");

        lblmsg.Text = "Your Application was Submitted successfully";
        success.Visible = true;
        Failure.Visible = false;

        


    }
    protected void ddlLoc_of_unit0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLoc_of_unit0.SelectedValue == "With in IALA/Industrial Estate/Industrial Park")
        {

            Label587.Text = "Details Industrial Estate";
        }
        else if (ddlLoc_of_unit0.SelectedValue == "Out Side IALA/Industrial Estate/Industrial Park")
        {

            Label587.Text = "Address of Unit";
        }
    }
    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCaste.SelectedValue == "5")
        {
            TrMoniorty.Visible = true;
        }
        else
        {
            TrMoniorty.Visible = false;
        }
    }
    protected void RdbMarket_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbMarket.SelectedIndex == 0)
        {
            tr3.Visible = true;
            trindicateState1.Visible = true;
            trindicateState2.Visible = true;
        }
        else
        {
            tr3.Visible = false;
            trindicateState1.Visible = false;
            trindicateState2.Visible = false;
        }
    }
}
