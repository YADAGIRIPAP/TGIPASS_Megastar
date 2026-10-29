using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class UI_TSiPASS_frmCOI_SPEECH : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet DSSPEECHDATA = new DataSet();
        DSSPEECHDATA = GETSPEECHDATA();
        if (DSSPEECHDATA.Tables[0].Rows.Count > 0&& DSSPEECHDATA.Tables.Count>0)
        {
            lblyear.Text= DSSPEECHDATA.Tables[1].Rows[0]["Year"].ToString();
            lbltotalnoofunits.Text = DSSPEECHDATA.Tables[0].Rows[0]["TotalUnits"].ToString();
            lbltotalinvestment.Text = DSSPEECHDATA.Tables[0].Rows[0]["TotalInvestment"].ToString();
            lbltotalemployment.Text = DSSPEECHDATA.Tables[0].Rows[0]["TotalEmployment"].ToString();
            lbltotalunits_commenced.Text = DSSPEECHDATA.Tables[1].Rows[0]["CommencedUnits"].ToString();
            lbltotalinvestment_commenced.Text = DSSPEECHDATA.Tables[1].Rows[0]["CommencedUnitsInvestment"].ToString();
            lbltotalemployment_commenced.Text = DSSPEECHDATA.Tables[1].Rows[0]["CommencedUnitsEmployment"].ToString();
            decimal percentageofunits = (Convert.ToDecimal(lbltotalunits_commenced.Text) / Convert.ToDecimal(lbltotalnoofunits.Text)) * 100;
            lblpercentageofunits.Text = ( Math.Round(percentageofunits, 2) ).ToString();
            lblclaims_tidea.Text= DSSPEECHDATA.Tables[2].Rows[0]["TOTALUNITS"].ToString();
            decimal TIDEASANCTIONEDAMOUNT= Convert.ToDecimal(DSSPEECHDATA.Tables[2].Rows[0]["TOTALSANCTIONEDAMOUNT"].ToString());
            lblamount_tidea.Text = Math.Round(TIDEASANCTIONEDAMOUNT,2).ToString();

            lblNOOFSCAPPLICATIONS.Text = (DSSPEECHDATA.Tables[3].Rows[0]["TOTALUNITS"].ToString());
            decimal SCAMOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[3].Rows[0]["TOTALSANCTIONEDAMOUNT"].ToString());
            LBLSCSANCTIONEDAMOUNT.Text = Math.Round(SCAMOUNT, 2).ToString();

            LBLNOOFSTAPPLICATIONS.Text = (DSSPEECHDATA.Tables[4].Rows[0]["TOTALUNITS"].ToString());
            decimal STAMOUNT=Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["TOTALSANCTIONEDAMOUNT"].ToString());
            LBLSTSANCTIONEDAMOUNT.Text = Math.Round(STAMOUNT, 2).ToString();

            LBLNOOFPHCAPPLICATIONS.Text = (DSSPEECHDATA.Tables[5].Rows[0]["TOTALUNITS"].ToString());
            decimal PHCAMOUNT=Convert.ToDecimal(DSSPEECHDATA.Tables[5].Rows[0]["TOTALSANCTIONEDAMOUNT"].ToString());
            LBLPHCSANCTIONEDAMOUNT.Text = Math.Round(PHCAMOUNT, 2).ToString();

            lblfinancialyear_tidea.Text = DSSPEECHDATA.Tables[6].Rows[0]["FinYear"].ToString();
            lblfinancialyearclaims_tidea.Text = DSSPEECHDATA.Tables[6].Rows[0]["GENERALCOUNT"].ToString();
            decimal GENERALAMOUNT= (Convert.ToDecimal(DSSPEECHDATA.Tables[6].Rows[0]["GENERALAMOUNT"].ToString()) / 10000000);
            lblclaimwisesanctionedamount_tidea.Text = Math.Round(GENERALAMOUNT, 2).ToString();

           

            //decimal TPRIDESANCTIONEDAMOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[3].Rows[0]["TOTALSANCTIONEDAMOUNT"].ToString());
            //  lblclaims_tpride.Text = DSSPEECHDATA.Tables[3].Rows[0]["TOTALUNITS"].ToString();
            //  lblsanctionedamopunt_tpride.Text = Math.Round(TPRIDESANCTIONEDAMOUNT, 2).ToString();
            // lblfinancialyear_tpride.Text = DSSPEECHDATA.Tables[4].Rows[0]["FinYear"].ToString();
            //decimal SCCOUNT= Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["SCCOUNT"].ToString());
            //decimal STCOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["STCOUNT"].ToString());
            //decimal PHCCOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["PHCCOUNT"].ToString());
            //decimal SCAMOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["SCAMOUNT"].ToString());
            //decimal STAMOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["STAMOUNT"].ToString());
            //decimal PHCAMOUNT = Convert.ToDecimal(DSSPEECHDATA.Tables[4].Rows[0]["PHCAMOUNT"].ToString());
            //decimal TPIDECOUNT = (SCCOUNT + STCOUNT + PHCCOUNT);
            //decimal TRIDEAMOUNT = (SCAMOUNT + STAMOUNT + PHCAMOUNT)/10000000;
            // lblfinancialyearclaims_tpride.Text = (Math.Round(TPIDECOUNT, 2)).ToString();
            // lblfinancialyearsanctionedamount_tpride.Text = (Math.Round(TRIDEAMOUNT, 2)).ToString();
            if (DSSPEECHDATA.Tables[7].Rows.Count>0)
            {
                lblyear_EODB.Text= DSSPEECHDATA.Tables[7].Rows[0]["txtDBIITYEAR"].ToString();
                LBLSETODREFORMS.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTNOOFREFORMS"].ToString();
                LBLYEAR_TOPACHIEVER.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTTOPACHIEVERYEAR"].ToString();
                lblhealthclinicamount.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTAMOUNTSETTINGUPFORNBFC"].ToString();
                lbltelanganagovtfount.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTAMOUNTFOUNDEDBYTGGOVT"].ToString();
                lblsickunits.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTNOOFSICKUNITS"].ToString();
                lblmsmeunits.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTNOOFMSMEUNITS"].ToString();
                lbltilldate.Text= DSSPEECHDATA.Tables[7].Rows[0]["TILLDATE"].ToString();
                LBLNOOFAPPLICATIONSFILED.Text = DSSPEECHDATA.Tables[7].Rows[0]["txtnoofapplicationsfiled"].ToString();
                lblcases.Text= DSSPEECHDATA.Tables[7].Rows[0]["TXTNOOFCASES"].ToString();
                LBLDISPOSEDAMOUNT.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTAMOUNTDISPOSED"].ToString();
                LBLINVESTMENT.Text = DSSPEECHDATA.Tables[7].Rows[0]["txttechorextcentersinvestment"].ToString();

                lblbudgetallocated_tidea.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETALLOCATEDTIDEA"].ToString();
                lblreleasedamount_tidea.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETRELEASEDTIDEA"].ToString();
                lblpendingamount_tidea.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETPENDINGTIDEA"].ToString();
                lblutilizedamount_tidea.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETUNILIZEDTIDEA"].ToString();

              //  lblbudgetallocatedtpride.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETALLOCATEDTPRIDE"].ToString();
               // lblbudgetreleasedtpride.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETRELEASEDTPRIDE"].ToString();
               // lblbudgetpendingtpride.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETPENDINGTPRIDE"].ToString();
               // lblbudgetutilizedtpride.Text = DSSPEECHDATA.Tables[7].Rows[0]["TXTBUDGETUNILIZEDTPRIDE"].ToString();

            }

        }

    }
    public DataSet GETSPEECHDATA()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GETCOISPEECHDATA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;         

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
}