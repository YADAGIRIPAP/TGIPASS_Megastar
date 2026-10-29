using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Crypto;
using System.Activities.Expressions;
using System.Windows.Forms;

public partial class UI_TSiPASS_Personal_Interaction_Page_New_Entrepreneurs_PrintPage : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["InteractionID"] != null)
            {
                string InteractionID = Request.QueryString["InteractionID"];
                Interaction_ID.Text = InteractionID;
            }
        }

        DataSet ds1 = new DataSet();
        {
            SqlParameter[] pp = new SqlParameter[]
            {
                new SqlParameter("@InteractionID", SqlDbType.VarChar)
            };

            pp[0].Value = Interaction_ID.Text;
            ds1 = gen.GenericFillDs("USP_GET_NEW_ENTREPRENEUR_PRINT", pp);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {    
                DataRow row = ds1.Tables[0].Rows[0];
                modeofinteraction.Text = row["Mode of Interaction"].ToString();
                womencell.Text = row["Women Cell"].ToString();
                mandalname.Text = row["Mandal"].ToString();
                dateofinteraction.Text = row["Date_WomenCell"].ToString();
                if (row["Venue of Interaction"].ToString() == "Others")
                {interactionvenue.Text = row["Other Venue"].ToString();}
                else{interactionvenue.Text = row["Venue of Interaction"].ToString();}
                candidatename.Text = row["ApplicantName"].ToString();
                candidatenumber.Text = row["Contactnumber"].ToString();
                candidatemail.Text = row["Emailid"].ToString();
                candidateage.Text = row["Age"].ToString();
                candidategender.Text = row["GENDER"].ToString();
                socialcategory.Text = row["SOCIAL CATEGORY"].ToString();
                phd.Text = row["isPHC"].ToString();
                qualification.Text = row["EDUCATIONAL QUALIFICATION"].ToString();
                visitpurpose.Text = row["Purpose of Visit"].ToString();
                sectorexperience.Text = row["Any Sector Experience"].ToString();
                sectorname.Text = row["SECTOR Name"].ToString();
                experienceinsector.Text = row["Experience in Years"].ToString();
                pmegpproposed.Text = row["Explained Scheme PMEGP"].ToString();
                pmegpinterested.Text = row["Interested in PMEGP"].ToString();
                pmfmeproposed.Text = row["Explained Scheme PMFME"].ToString();
                pmfmeinterested.Text = row["Interested in PMFME"].ToString();
                t_ideaproposed.Text = row["Explained Scheme T-IDEA"].ToString();
                t_ideainterested.Text = row["Interested in T-IDEA"].ToString();
                t_prideproposed.Text = row["Explained Scheme T-PRIDE"].ToString();
                t_prideinterested.Text = row["Interested in T-PRIDE"].ToString();
                mudraproposed.Text = row["Explained Scheme Mudra"].ToString();
                mudrainterested.Text = row["Interested in Mudra"].ToString();
                cgtmseproposed.Text = row["Explained Scheme CGTMSE"].ToString();
                cgtmseinterested.Text = row["Interested in CGTMSE"].ToString();
                dalithabandhuproposed.Text = row["Explained Scheme Dalitha Bandhu"].ToString();
                dalithabandhuinterested.Text = row["Interested in Dalitha Bandhu"].ToString();
                tasksproposed.Text = row["ExplainedTasks"].ToString();
                tasksinterested.Text = row["Interested in TASKS"].ToString();
                detproposed.Text = row["ExplainedDET"].ToString();
                detinterested.Text = row["Interested in DET"].ToString(); 
                landproposed.Text = row["ExplainedAbtVacantPlots"].ToString();
                otherissues.Text = row["Others Issues"].ToString();
            }
        }
    }
}