using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;
using System.Web.Services;
using System.IO;

using System.Web.Security;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

/// <summary>
/// Summary description for Departtsiicservice
/// </summary>
public class Departtsiicservice
{

    

    DataSet GDs = new DataSet();
    General Gen = new General();


    public Departtsiicservice()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void TSiicdetailsdata(int intuserid, int appid)
    {


        TSIICLANDCGG.LandAllotmentService landservice = new TSIICLANDCGG.LandAllotmentService();
        //TSIICLANDCGG.LandAllotmentService landservice = new TSIICLANDCGG.LandAllotmentService();
        TSIICLANDCGG.Plot plotvo = new TSIICLANDCGG.Plot();
        TSIICLANDCGG.VerifyFirmDetails verifyFirmvo = new TSIICLANDCGG.VerifyFirmDetails();
        TSIICLANDCGG.PromoterDetails promoterDetailsvo = new TSIICLANDCGG.PromoterDetails();
        TSIICLANDCGG.Landline landlinevo = new TSIICLANDCGG.Landline();

        TSIICLANDCGG.Mobile mobilevo = new TSIICLANDCGG.Mobile();
        //TSIICLANDCGG.


        TSIICLANDCGG.Address addressvo = new TSIICLANDCGG.Address();
        TSIICLANDCGG.CommunicationAddress communicationAddressvo = new TSIICLANDCGG.CommunicationAddress();

        TSIICLANDCGG.Address Commaddressvo = new TSIICLANDCGG.Address();
        TSIICLANDCGG.CommunicationAddress CommcommunicationAddressvo = new TSIICLANDCGG.CommunicationAddress();

        TSIICLANDCGG.Address Contactaddressvo = new TSIICLANDCGG.Address();
        TSIICLANDCGG.CommunicationAddress ContactcommunicationAddressvo = new TSIICLANDCGG.CommunicationAddress();


        TSIICLANDCGG.FirmDetails firmDetailsvo = new TSIICLANDCGG.FirmDetails();
        TSIICLANDCGG.FirmRegistrationDetails firmRegistrationDetailsvo = new TSIICLANDCGG.FirmRegistrationDetails();

        TSIICLANDCGG.ProjectGeneral projectGeneralvo = new TSIICLANDCGG.ProjectGeneral();
        TSIICLANDCGG.ProjectFinancial projectFinancialvo = new TSIICLANDCGG.ProjectFinancial();
        TSIICLANDCGG.ProjectEmployment projectEmploymentvo = new TSIICLANDCGG.ProjectEmployment();
        TSIICLANDCGG.ProjectMaterialManufacturing projectMaterialManufacturingvo = new TSIICLANDCGG.ProjectMaterialManufacturing();
        TSIICLANDCGG.ProjectPlantMachinery projectPlantMachineryvo = new TSIICLANDCGG.ProjectPlantMachinery();
        TSIICLANDCGG.Land landvo = new TSIICLANDCGG.Land();
        TSIICLANDCGG.CodeDesc codeDescvo = new TSIICLANDCGG.CodeDesc();
        TSIICLANDCGG.Electricity electricityvo = new TSIICLANDCGG.Electricity();
        TSIICLANDCGG.Water watervo = new TSIICLANDCGG.Water();
        TSIICLANDCGG.Effluents effluentsvo = new TSIICLANDCGG.Effluents();
        TSIICLANDCGG.PaymentDetails paymentDetailsvo = new TSIICLANDCGG.PaymentDetails();
        TSIICLANDCGG.DocumentCheckList documentCheckListvo = new TSIICLANDCGG.DocumentCheckList();

        TSIICLANDCGG.Product gsvg = new TSIICLANDCGG.Product();
        TSIICLANDCGG.PromoterFinancialInformation promoterFinancialInformationvo = new TSIICLANDCGG.PromoterFinancialInformation();
        TSIICLANDCGG.DateHolder comdate = new TSIICLANDCGG.DateHolder();
        TSIICLANDCGG.User registraionvo = new TSIICLANDCGG.User();
        TSIICLANDCGG.PersonName personvo = new TSIICLANDCGG.PersonName();
        TSIICLANDCGG.Product productvo = new TSIICLANDCGG.Product();
        TSIICLANDCGG.DateHolder datevo = new TSIICLANDCGG.DateHolder();

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        GDs = tsiicdetailsdata(intuserid, appid);


        if (GDs.Tables[0].Rows.Count > 0)
        {

            plotvo.district = GDs.Tables[0].Rows[0]["DistrictIdCGG"].ToString(); // GDs.Tables[0].Rows[0]["DistrictName"].ToString();
            plotvo.emd = 0;
            plotvo.industrialPark = GDs.Tables[0].Rows[0]["IndustrialParkIdCGG"].ToString();

        }

        if (GDs.Tables[1].Rows.Count > 0)
        {
            string str = "";
            string area = "";
            string Plotdatanew = "";
            for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
            {
                str += GDs.Tables[1].Rows[i]["PlotnoID"].ToString() + ",";
                Plotdatanew += GDs.Tables[1].Rows[i]["PLOTDATA"].ToString() + "$";
            }

            plotvo.plotNo = str.Substring(0, str.Length - 1);
            plotvo.plotData = Plotdatanew.Substring(0, Plotdatanew.Length - 1);// GDs.Tables[1].Rows[0]["PLOTDATA"].ToString();
            //plotvo.plotNo = GDs.Tables[1].Rows[0]["PlotID"].ToString();
            plotvo.price = GDs.Tables[1].Rows[0]["Persqmtsprice"].ToString();// Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);

            //for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
            //{
            //    str += GDs.Tables[1].Rows[i]["PlotnoID"].ToString() + ",";
            //}

            //plotvo.plotNo = str.Substring(0, str.Length - 1);
            //plotvo.plotData = GDs.Tables[1].Rows[0]["PLOTDATA"].ToString();
            ////plotvo.plotNo = GDs.Tables[1].Rows[0]["PlotnoID"].ToString();
            //plotvo.price = GDs.Tables[1].Rows[0]["Persqmtsprice"].ToString();// Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
            plotvo.totalArea = Convert.ToDouble(GDs.Tables[1].Rows[0]["PlotTotalArea"]);
            plotvo.amount = Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
            plotvo.area = Convert.ToDouble(GDs.Tables[1].Rows[0]["Area_in_Sq_Mtrs"]);
            plotvo.amountSpecified = true;
            plotvo.areaSpecified = true;
            plotvo.emdSpecified = true;
            plotvo.gstSpecified = true;
            //plotvo.priceSpecified = true;
            plotvo.processFeeSpecified = true;
            plotvo.totalAreaSpecified = true;
            plotvo.totalEmdSpecified = true;
            plotvo.totalPriceSpecified = true;

        }

        if (GDs.Tables[2].Rows.Count > 0)
        {
            verifyFirmvo.alloteeName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

            paymentDetailsvo.clientName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

            verifyFirmvo.applicantName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();
            verifyFirmvo.catDesc = GDs.Tables[2].Rows[0]["GovtDeptName_RegOffice"].ToString();
            TSIICLANDCGG.CodeDesc categorycodeDescvo = new TSIICLANDCGG.CodeDesc();
            categorycodeDescvo.code = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
            categorycodeDescvo.desc = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
            verifyFirmvo.categoryOfAllotment = categorycodeDescvo;
            addressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            addressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            addressvo.district = GDs.Tables[2].Rows[0]["Distid_regoffice"].ToString();
            addressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_RegOffice"].ToString();
            addressvo.mandal = GDs.Tables[2].Rows[0]["mandal_regoffice"].ToString();
            addressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_RegOffice"].ToString();

            TSIICLANDCGG.CodeDesc statestnames = new TSIICLANDCGG.CodeDesc();
            statestnames.code = GDs.Tables[2].Rows[0]["stateNames"].ToString();
            statestnames.desc = GDs.Tables[2].Rows[0]["stateNames"].ToString();
            addressvo.state = statestnames;


            addressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_RegOffice"].ToString();
            addressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_RegOffice"].ToString();
            addressvo.village = GDs.Tables[2].Rows[0]["village_regoffice"].ToString();

            communicationAddressvo.address = addressvo;


            TSIICLANDCGG.Landline comphone = new TSIICLANDCGG.Landline();
            comphone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            comphone.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            comphone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            comphone.phone = "";
            comphone.valid = true;
            comphone.validSpecified = true;
            communicationAddressvo.phoneNum = comphone;



            TSIICLANDCGG.Landline faxno = new TSIICLANDCGG.Landline();
            faxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            faxno.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            faxno.number = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            faxno.phone = "";
            faxno.valid = true;
            faxno.validSpecified = true;
            communicationAddressvo.faxNum = faxno;

            verifyFirmvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            verifyFirmvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            verifyFirmvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            verifyFirmvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();

            firmDetailsvo.communicationAddress = communicationAddressvo;
            firmRegistrationDetailsvo.regstrAuthority = GDs.Tables[2].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
            firmRegistrationDetailsvo.regstrNumber = GDs.Tables[2].Rows[0]["RegistrationNo_Firmregistration"].ToString();
            firmRegistrationDetailsvo.yrOfCommence = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofCommencement_Firmregistration"].ToString());
            firmRegistrationDetailsvo.yrOfCommenceSpecified = true;
            firmRegistrationDetailsvo.yrOfEstbl = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofEstablishment_Firmregistration"].ToString());
            firmRegistrationDetailsvo.yrOfEstblSpecified = true;

            firmDetailsvo.firmRegistrationDetails = firmRegistrationDetailsvo;
            firmDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
            firmDetailsvo.userIdSpecified = true;
            verifyFirmvo.firmDetails = firmDetailsvo;
            verifyFirmvo.houseNo = GDs.Tables[2].Rows[0]["House_Prv_flot"].ToString();

            TSIICLANDCGG.CodeDesc orgtype = new TSIICLANDCGG.CodeDesc();
            orgtype.code = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            orgtype.desc = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            verifyFirmvo.orgType = orgtype;
            Commaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            Commaddressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            Commaddressvo.district = GDs.Tables[2].Rows[0]["Distid_CommAddrs"].ToString();
            Commaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_CommAddr"].ToString();
            Commaddressvo.mandal = GDs.Tables[2].Rows[0]["mandal_commaddrs"].ToString();
            Commaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_CommAddr"].ToString();
            //CommcodeDescvo.code = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
            // CommcodeDescvo.desc = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
            Commaddressvo.state = codeDescvo;


            Commaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_CommAddr"].ToString();
            Commaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_CommAddr"].ToString();
            Commaddressvo.village = GDs.Tables[2].Rows[0]["Village_CommAddrs"].ToString();
            CommcommunicationAddressvo.address = Commaddressvo;


            TSIICLANDCGG.Landline comtelephone = new TSIICLANDCGG.Landline();

            TSIICLANDCGG.Landline comfaxno = new TSIICLANDCGG.Landline();
            //comtelephone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
            landlinevo.formattedPhone = "";
            //comtelephone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            landlinevo.phone = "";
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.phoneNum = comtelephone;
            comfaxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
            landlinevo.formattedPhone = "";
            comfaxno.number = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            landlinevo.phone = "";
            landlinevo.valid = true;
            landlinevo.validSpecified = true;

            verifyFirmvo.otherCommFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            verifyFirmvo.otherCommFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString();
            verifyFirmvo.otherCommPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();
            verifyFirmvo.otherCommPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString();



            verifyFirmvo.otherCommunicationAddress = CommcommunicationAddressvo;
            verifyFirmvo.others = GDs.Tables[2].Rows[0]["OtherDetails_Prv_flot"].ToString();
            verifyFirmvo.plotNo = GDs.Tables[2].Rows[0]["PlotNo_Prv_flot"].ToString();
            verifyFirmvo.shedName = GDs.Tables[2].Rows[0]["ShedName_Prv_flot"].ToString();
            verifyFirmvo.shopNo = GDs.Tables[2].Rows[0]["Shop_Prv_flot"].ToString();

            ///promoter details///

            Contactaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.district = GDs.Tables[2].Rows[0]["Distidcontactinfo"].ToString();
            Contactaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_Cont_info"].ToString();
            Contactaddressvo.mandal = GDs.Tables[2].Rows[0]["mandalcontinfo"].ToString();
            Contactaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_Cont_info"].ToString();
            codeDescvo.code = GDs.Tables[2].Rows[0]["statecontinfos"].ToString();
            codeDescvo.desc = GDs.Tables[2].Rows[0]["statecontinfos"].ToString(); // GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.state = codeDescvo;
            Contactaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_Cont_info"].ToString();
            Contactaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_Cont_info"].ToString();
            Contactaddressvo.village = GDs.Tables[2].Rows[0]["villagecontinfo"].ToString();
            ContactcommunicationAddressvo.address = Contactaddressvo;

            TSIICLANDCGG.Landline contfax = new TSIICLANDCGG.Landline();
            contfax.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
            landlinevo.formattedPhone = "";
            contfax.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            //landlinevo.phone =GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.faxNum = landlinevo;
            landlinevo.areaCode = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
            landlinevo.formattedPhone = "";
            //landlinevo.number = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            landlinevo.phone = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.phoneNum = landlinevo;

            promoterDetailsvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
            promoterDetailsvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
            promoterDetailsvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            promoterDetailsvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            promoterDetailsvo.cellNumber = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();

            promoterDetailsvo.communicationAddress = ContactcommunicationAddressvo;
            promoterDetailsvo.emailId = GDs.Tables[2].Rows[0]["Email_Cont_info"].ToString();
            mobilevo.areaCode = "";// GDs.Tables[2].Rows[0][""].ToString();
            mobilevo.formattedPhone = "";
            mobilevo.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            mobilevo.phone = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            mobilevo.valid = true;
            mobilevo.validSpecified = true;
            promoterDetailsvo.mobile = mobilevo;
            personvo.firstName = GDs.Tables[2].Rows[0]["FirstName_Cont_info"].ToString();
            personvo.surname = GDs.Tables[2].Rows[0]["Surname_Cont_info"].ToString();
            promoterDetailsvo.personName = personvo;
            promoterFinancialInformationvo.detlsImvableAssests = GDs.Tables[2].Rows[0]["Immovable_Assets_Land_Building_Financial"].ToString();
            promoterFinancialInformationvo.funcResponsibilities = GDs.Tables[2].Rows[0]["ProposedProject_Financial"].ToString();
            promoterFinancialInformationvo.otherAssests = Convert.ToDouble(GDs.Tables[2].Rows[0]["OtherAssets_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.otherAssestsSpecified = true;
            promoterFinancialInformationvo.otherInfo = GDs.Tables[2].Rows[0]["Anyother_Financial_Info"].ToString();
            promoterFinancialInformationvo.panNo = GDs.Tables[2].Rows[0]["PanNumber_Financial_Info"].ToString();
            promoterFinancialInformationvo.personalAsset = Convert.ToDouble(GDs.Tables[2].Rows[0]["Assets_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.personalAssetSpecified = true;
            promoterFinancialInformationvo.personalLiability = Convert.ToDouble(GDs.Tables[2].Rows[0]["Liabilities_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.personalLiabilitySpecified = true;
            promoterDetailsvo.promoterFinancialInformation = promoterFinancialInformationvo;
            promoterDetailsvo.promoterId = 0;// GDs.Tables[2].Rows[0][""].ToString();
            promoterDetailsvo.promoterIdSpecified = true;
            promoterDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
            promoterDetailsvo.userIdSpecified = true;

            TSIICLANDCGG.Product[] product = null;
            projectGeneralvo.byProductList = product;
            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                TSIICLANDCGG.DateHolder datevocomme = new TSIICLANDCGG.DateHolder();
                datevocomme.day = newdate[0].ToString();
                datevocomme.displayDate = "";
                datevocomme.empty = true;
                datevocomme.emptySpecified = true;
                datevocomme.month = newdate[1].ToString();
                datevocomme.sqlDateStr = "";
                datevocomme.valid = true;
                datevocomme.validSpecified = true;
                datevocomme.year = newdate[2].ToString();

                projectGeneralvo.commOperationPhase1 = datevocomme;
            }

            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                TSIICLANDCGG.DateHolder datevocommercial = new TSIICLANDCGG.DateHolder();

                datevocommercial.day = newdate[0].ToString();
                datevocommercial.displayDate = "";
                datevocommercial.empty = true;
                datevocommercial.emptySpecified = true;
                datevocommercial.month = newdate[1].ToString();
                datevocommercial.sqlDateStr = "";
                datevocommercial.valid = true;
                datevocommercial.validSpecified = true;
                datevocommercial.year = newdate[2].ToString();
                projectGeneralvo.commOperationPhase2 = datevocommercial;
            }
            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                TSIICLANDCGG.DateHolder datevocommercialphase2 = new TSIICLANDCGG.DateHolder();
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();

                datevocommercialphase2.day = newdate[0].ToString();
                datevocommercialphase2.displayDate = "";
                datevocommercialphase2.empty = true;
                datevocommercialphase2.emptySpecified = true;
                datevocommercialphase2.month = newdate[1].ToString();
                datevocommercialphase2.sqlDateStr = "";
                datevocommercialphase2.valid = true;
                datevocommercialphase2.validSpecified = true;
                datevocommercialphase2.year = newdate[2].ToString();
                projectGeneralvo.commOperationPhase3 = datevocommercialphase2;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevoconstruction = new TSIICLANDCGG.DateHolder();

                datevoconstruction.day = newdate[0].ToString();
                datevoconstruction.displayDate = "";
                datevoconstruction.empty = true;
                datevoconstruction.emptySpecified = true;
                datevoconstruction.month = newdate[1].ToString();
                datevoconstruction.sqlDateStr = "";
                datevoconstruction.valid = true;
                datevoconstruction.validSpecified = true;
                datevoconstruction.year = newdate[2].ToString();

                projectGeneralvo.constructionPhase1 = datevoconstruction;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevoconstructionphase2 = new TSIICLANDCGG.DateHolder();
                datevoconstructionphase2.day = newdate[0].ToString();
                datevoconstructionphase2.displayDate = "";
                datevoconstructionphase2.empty = true;
                datevoconstructionphase2.emptySpecified = true;
                datevoconstructionphase2.month = newdate[1].ToString();
                datevoconstructionphase2.sqlDateStr = "";
                datevoconstructionphase2.valid = true;
                datevoconstructionphase2.validSpecified = true;
                datevoconstructionphase2.year = newdate[2].ToString();
                projectGeneralvo.constructionPhase2 = datevoconstructionphase2;
            }

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder datevoconstructionphase3 = new TSIICLANDCGG.DateHolder();
                datevoconstructionphase3.day = newdate[0].ToString();
                datevoconstructionphase3.displayDate = "";
                datevoconstructionphase3.empty = true;
                datevoconstructionphase3.emptySpecified = true;
                datevoconstructionphase3.month = newdate[1].ToString();
                datevoconstructionphase3.sqlDateStr = "";
                datevoconstructionphase3.valid = true;
                datevoconstructionphase3.validSpecified = true;
                datevoconstructionphase3.year = newdate[2].ToString();
                projectGeneralvo.constructionPhase3 = datevoconstructionphase3;
            }
            projectGeneralvo.projCategory = GDs.Tables[2].Rows[0]["typeofprojectscategory"].ToString();
            projectGeneralvo.projCatgryOther = GDs.Tables[2].Rows[0]["projectother"].ToString();
            projectGeneralvo.projCatgryOtherValue = GDs.Tables[2].Rows[0]["ProjectCategory3_General_Info"].ToString();
            projectGeneralvo.projDesc = GDs.Tables[2].Rows[0]["ProjectName_Description_General_Info"].ToString();
            projectGeneralvo.projectId = 0;
            projectGeneralvo.projectIdSpecified = true;
            projectGeneralvo.projStatus = GDs.Tables[2].Rows[0]["typeofprojectstatus"].ToString();
            TSIICLANDCGG.Product[] productprosposed = null;
            if (GDs.Tables[7].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[7];
                productprosposed = new TSIICLANDCGG.Product[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.Product Productvo = new TSIICLANDCGG.Product();
                    Productvo.code = dtraw.Rows[k]["Itemcode"].ToString();
                    Productvo.expectedOutput = 0.00; //dtraw.Rows[k][""].ToString();
                    Productvo.expectedOutputSpecified = true;

                    if (dtraw.Rows[k]["Installedcapacity"].ToString() == "")
                    {


                        Productvo.installedCapacity = 0;

                    }
                    else
                    {
                        Productvo.installedCapacity = Convert.ToDouble(dtraw.Rows[k]["Installedcapacity"]);
                    }

                    Productvo.installedCapacitySpecified = true;
                    Productvo.measurement = dtraw.Rows[k]["Unitmeasurement"].ToString();
                    Productvo.name = dtraw.Rows[k]["Product"].ToString();
                    Productvo.productId = 0;
                    Productvo.productIdSpecified = false;
                    productprosposed[k] = Productvo;
                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                }
                projectGeneralvo.propProductList = productprosposed;
            }
            projectGeneralvo.propProductList = productprosposed;

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder datevotrialperation = new TSIICLANDCGG.DateHolder();
                datevotrialperation.day = newdate[0].ToString();
                datevotrialperation.displayDate = "";
                datevotrialperation.empty = true;
                datevotrialperation.emptySpecified = true;
                datevotrialperation.month = newdate[1].ToString();
                datevotrialperation.sqlDateStr = "";
                datevotrialperation.valid = true;
                datevotrialperation.validSpecified = true;
                datevotrialperation.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase1 = datevotrialperation;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevotrialperationphase2 = new TSIICLANDCGG.DateHolder();
                datevotrialperationphase2.day = newdate[0].ToString();
                datevotrialperationphase2.displayDate = "";
                datevotrialperationphase2.empty = true;
                datevotrialperationphase2.emptySpecified = true;
                datevotrialperationphase2.month = newdate[1].ToString();
                datevotrialperationphase2.sqlDateStr = "";
                datevotrialperationphase2.valid = true;
                datevotrialperationphase2.validSpecified = true;
                datevotrialperationphase2.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase2 = datevotrialperationphase2;
            }

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString().Split(' ');


                TSIICLANDCGG.DateHolder datevotrialperationphase3 = new TSIICLANDCGG.DateHolder();
                string[] newdate = date[0].ToString().Split('-');
                datevotrialperationphase3.day = newdate[0].ToString();
                datevotrialperationphase3.displayDate = "";
                datevotrialperationphase3.empty = true;
                datevotrialperationphase3.emptySpecified = true;
                datevotrialperationphase3.month = newdate[1].ToString();
                datevotrialperationphase3.sqlDateStr = "";
                datevotrialperationphase3.valid = true;
                datevotrialperationphase3.validSpecified = true;
                datevotrialperationphase3.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase3 = datevotrialperationphase3;
            }
            projectGeneralvo.ventureType1 = GDs.Tables[2].Rows[0]["Typeofventure"].ToString();
            projectGeneralvo.ventureType2 = "";
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase3Specified = true;
            projectFinancialvo.auxillaryId = 0;
            projectFinancialvo.auxillaryIdSpecified = true;
            projectFinancialvo.buildingId = 0;
            projectFinancialvo.buildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.buildingsPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.buildingsPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.buildingsPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.contingenciesPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.contingenciesPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.contingenciesPhase3Specified = true;
            projectFinancialvo.contingeniousId = 0;
            projectFinancialvo.contingeniousIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Amount"].ToString() != null && GDs.Tables[2].Rows[0]["Amount"].ToString() != "")
            {
                projectFinancialvo.debtAmount = Convert.ToDouble(GDs.Tables[2].Rows[0]["Amount"].ToString());
            }
            projectFinancialvo.debtAmountSpecified = true;
            projectFinancialvo.debtName = GDs.Tables[2].Rows[0]["EquityName"].ToString();
            if (GDs.Tables[2].Rows[0]["EOUdate"].ToString() != "" && GDs.Tables[2].Rows[0]["EOUdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["EOUdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder equdate = new TSIICLANDCGG.DateHolder();
                equdate.day = newdate[0].ToString();
                equdate.displayDate = "";
                equdate.empty = true;
                equdate.emptySpecified = true;
                equdate.month = newdate[1].ToString();
                equdate.sqlDateStr = "";
                equdate.valid = true;
                equdate.validSpecified = true;
                equdate.year = newdate[2].ToString();
                projectFinancialvo.eouDate = equdate;
            }
            projectFinancialvo.eouNo = GDs.Tables[2].Rows[0]["EOUNo"].ToString();
            if (GDs.Tables[2].Rows[0]["Domestic"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic"].ToString() != "")
            {
                projectFinancialvo.equityDomestic = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic"].ToString());
            }
            projectFinancialvo.equityDomesticSpecified = true;
            if (GDs.Tables[2].Rows[0]["Foreigns"].ToString() != null && GDs.Tables[2].Rows[0]["Foreigns"].ToString() != "")
            {
                projectFinancialvo.equityForiegn = Convert.ToDouble(GDs.Tables[2].Rows[0]["Foreigns"].ToString());
            }
            projectFinancialvo.equityForiegnSpecified = true;

            if (GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != "" && GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder foreigndate = new TSIICLANDCGG.DateHolder();
                foreigndate.day = newdate[0].ToString();
                foreigndate.displayDate = "";
                foreigndate.empty = true;
                foreigndate.emptySpecified = true;
                foreigndate.month = newdate[1].ToString();
                foreigndate.sqlDateStr = "";
                foreigndate.valid = true;
                foreigndate.validSpecified = true;
                foreigndate.year = newdate[2].ToString();
                projectFinancialvo.fipbRbiApprDate = foreigndate;
            }

            projectFinancialvo.fipbRbiApprNo = GDs.Tables[2].Rows[0]["Foreigninvestment"].ToString();
            if (GDs.Tables[2].Rows[0]["IEMdate"].ToString() != "" && GDs.Tables[2].Rows[0]["IEMdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["IEMdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder Iemdate = new TSIICLANDCGG.DateHolder();
                Iemdate.day = newdate[0].ToString();
                Iemdate.displayDate = "";
                Iemdate.empty = true;
                Iemdate.emptySpecified = true;
                Iemdate.month = newdate[1].ToString();
                Iemdate.sqlDateStr = "";
                Iemdate.valid = true;
                Iemdate.validSpecified = true;
                Iemdate.year = newdate[2].ToString();
                projectFinancialvo.iemDate = Iemdate;
            }
            projectFinancialvo.iemNo = GDs.Tables[2].Rows[0]["IEM"].ToString();
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.indigeneousPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.indigeneousPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.indigeneousPhase3Specified = true;
            projectFinancialvo.indigeniousId = 0;
            projectFinancialvo.indigeniousIdSpecified = true;
            projectFinancialvo.landId = 0;
            projectFinancialvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.landPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.landPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.landPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.landPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.landPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.landPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["LOIdate"].ToString() != "" && GDs.Tables[2].Rows[0]["LOIdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["LOIdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder loidate = new TSIICLANDCGG.DateHolder();
                loidate.day = newdate[0].ToString();
                loidate.displayDate = "";
                loidate.empty = true;
                loidate.emptySpecified = true;
                loidate.month = newdate[1].ToString();
                loidate.sqlDateStr = "";
                loidate.valid = true;
                loidate.validSpecified = true;
                loidate.year = newdate[2].ToString();
                projectFinancialvo.loiDate = loidate;
            }
            projectFinancialvo.loiNo = GDs.Tables[2].Rows[0]["LOI"].ToString();
            projectFinancialvo.machineryImportedId = 0;
            projectFinancialvo.machineryImportedIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.machineryImportedPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.machineryImportedPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.machineryImportedPhase3Specified = true;
            projectFinancialvo.miscFixedId = 0;
            projectFinancialvo.miscFixedIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase3Specified = true;
            projectFinancialvo.preliminaryId = 0;
            projectFinancialvo.preliminaryIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase3Specified = true;
            projectFinancialvo.projectId = 0;
            projectFinancialvo.projectIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != "")
            {
                projectFinancialvo.totalEqtyDebt = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString());
            }
            projectFinancialvo.totalEqtyDebtSpecified = true;
            if (GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != "")
            {
                projectFinancialvo.totalEquity = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquity"].ToString());
            }
            projectFinancialvo.totalEquitySpecified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.totalPhase3Specified = true;
            projectFinancialvo.workCapitalId = 0;
            projectFinancialvo.workCapitalIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["femalephase1"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase1"].ToString() != "")
            {
                projectEmploymentvo.femalePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase1"].ToString());
            }
            projectEmploymentvo.femalePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["femalephase2"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase2"].ToString() != "")
            {
                projectEmploymentvo.femalePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase2"].ToString());
            }
            projectEmploymentvo.femalePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["femalephase3"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase3"].ToString() != "")
            {
                projectEmploymentvo.femalePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase3"].ToString());
            }
            projectEmploymentvo.femalePhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase1"].ToString() != null && GDs.Tables[2].Rows[0]["malephase1"].ToString() != "")
            {
                projectEmploymentvo.malePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase1"].ToString());
            }
            projectEmploymentvo.malePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase2"].ToString() != null && GDs.Tables[2].Rows[0]["malephase2"].ToString() != "")
            {
                projectEmploymentvo.malePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase2"].ToString());
            }
            projectEmploymentvo.malePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase3"].ToString() != null && GDs.Tables[2].Rows[0]["malephase3"].ToString() != "")
            {
                projectEmploymentvo.malePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase3"].ToString());
            }
            projectEmploymentvo.malePhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString());
            }
            projectEmploymentvo.managerialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString());
            }
            projectEmploymentvo.managerialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString());
            }
            projectEmploymentvo.managerialPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != null && GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != "")
            {
                projectEmploymentvo.maxNoWorkers = Convert.ToInt64(GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString());
            }
            projectEmploymentvo.maxNoWorkersSpecified = true;
            projectEmploymentvo.projectId = 0;
            projectEmploymentvo.projectIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString());
            }
            projectEmploymentvo.skilledPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString());
            }
            projectEmploymentvo.skilledPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString());
            }
            projectEmploymentvo.skilledPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString());
            }
            projectEmploymentvo.supervisoryPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString());
            }
            projectEmploymentvo.supervisoryPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString());
            }
            projectEmploymentvo.supervisoryPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != "")
            {
                projectEmploymentvo.totalPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Emp"].ToString());
            }
            projectEmploymentvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.totalPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString());
            }
            projectEmploymentvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.totalPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString());
            }
            projectEmploymentvo.totalPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString());
            }
            projectEmploymentvo.unSkilledPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString());
            }
            projectEmploymentvo.unSkilledPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString());
            }
            projectEmploymentvo.unSkilledPhase3Specified = true;


            projectMaterialManufacturingvo.descProcessTech = GDs.Tables[2].Rows[0]["providedetails"].ToString();
            projectMaterialManufacturingvo.fileName = GDs.Tables[2].Rows[0]["filepath"].ToString();
            projectMaterialManufacturingvo.processTechnology = GDs.Tables[2].Rows[0]["processtechnology"].ToString();
            projectMaterialManufacturingvo.projectId = 0;
            projectMaterialManufacturingvo.projectIdSpecified = true;
            projectMaterialManufacturingvo.projectmatManf = "";
            TSIICLANDCGG.RawMaterial[] rawmaterial = null;
            if (GDs.Tables[8].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[8];
                rawmaterial = new TSIICLANDCGG.RawMaterial[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.RawMaterial rawmaterialvo = new TSIICLANDCGG.RawMaterial();

                    rawmaterialvo.dailyConsumption = Convert.ToDouble(dtraw.Rows[k]["DailyConsumption"].ToString());
                    rawmaterialvo.dailyConsumptionSpecified = true;
                    rawmaterialvo.itemCode = dtraw.Rows[k]["Itemcode"].ToString();
                    rawmaterialvo.itemDescription = dtraw.Rows[k]["Descriptionitem"].ToString();
                    rawmaterialvo.rawMaterialId = 0;// Convert.ToInt64(dtraw.Rows[k]["queryRespDocName"].ToString());
                    rawmaterialvo.rawMaterialIdSpecified = true;
                    rawmaterialvo.unitOfMeasure = dtraw.Rows[k]["unitmeasurement"].ToString();
                    rawmaterial[k] = rawmaterialvo;
                }
                projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
            }

            projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
            projectMaterialManufacturingvo.techCollaborationDetails = GDs.Tables[2].Rows[0]["technicalcollabration"].ToString();
            projectMaterialManufacturingvo.technicalCollaboration = true;
            projectMaterialManufacturingvo.technicalCollaborationSpecified = true;
            if (GDs.Tables[2].Rows[0]["noofvessels"] != null && GDs.Tables[2].Rows[0]["noofvessels"].ToString() != "")
            {
                projectPlantMachineryvo.highPressureLevel = Convert.ToInt64(GDs.Tables[2].Rows[0]["noofvessels"].ToString());
            }
            projectPlantMachineryvo.highPressureLevelSpecified = true;

            TSIICLANDCGG.MachineryCapacity[] machinery = null;
            if (GDs.Tables[9].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[9];
                machinery = new TSIICLANDCGG.MachineryCapacity[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.MachineryCapacity MachineryCapacityvo = new TSIICLANDCGG.MachineryCapacity();
                    MachineryCapacityvo.plantCapacity = Convert.ToDouble(dtraw.Rows[k]["capacitykw"].ToString());
                    MachineryCapacityvo.plantCapacitySpecified = true;
                    MachineryCapacityvo.plantDescription = dtraw.Rows[k]["descplantmachinery"].ToString();
                    MachineryCapacityvo.plantMachineryId = 0;
                    MachineryCapacityvo.plantMachineryIdSpecified = true;
                    machinery[k] = MachineryCapacityvo;
                }
            }
            projectPlantMachineryvo.machineryCapacties = machinery;

            projectPlantMachineryvo.projectId = 0;
            projectPlantMachineryvo.projectIdSpecified = true;

            landvo.adminBuildingId = 0;
            landvo.adminBuildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != "")
            {
                landvo.adminBuildingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString());
            }
            landvo.adminBuildingPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != "")
            {
                landvo.adminBuildingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString());
            }
            landvo.adminBuildingPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != "")
            {
                landvo.adminBuildingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString());
            }
            landvo.adminBuildingPhase3Specified = true;
            landvo.estimatedarea = 0.00;// Convert.ToDouble(GDs.Tables[2].Rows[0][""].ToString());
            landvo.estimatedareaSpecified = true;
            landvo.indusShed = Convert.ToDouble(GDs.Tables[1].Rows[0]["Area_in_Sq_Mtrs"].ToString());
            landvo.indusShedSpecified = true;
            landvo.landId = 0;
            landvo.landIdSpecified = true;
            landvo.openAreaId = 0;
            landvo.openAreaIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != "")
            {
                landvo.openAreaPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString());
            }
            landvo.openAreaPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != "")
            {
                landvo.openAreaPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString());
            }
            landvo.openAreaPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != "")
            {
                landvo.openAreaPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString());
            }
            landvo.openAreaPhase3Specified = true;
            landvo.plantFactoryBuildingId = 0;
            landvo.plantFactoryBuildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != "")
            {
                landvo.plantFactoryPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString());
            }
            landvo.plantFactoryPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != "")
            {
                landvo.plantFactoryPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString());
            }
            landvo.plantFactoryPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != "")
            {
                landvo.plantFactoryPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString());
            }
            landvo.plantFactoryPhase3Specified = true;
            landvo.remarks = "";
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != "")
            {
                landvo.roadWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString());
            }
            landvo.roadWaterPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != "")
            {
                landvo.roadWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString());
            }
            landvo.roadWaterPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != "")
            {
                landvo.roadWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString());
            }
            landvo.roadWaterPhase3Specified = true;
            landvo.roadWtrStrgId = 0;
            landvo.roadWtrStrgIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != "")
            {
                landvo.storageWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString());
            }
            landvo.storageWaterPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != "")
            {
                landvo.storageWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString());
            }
            landvo.storageWaterPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != "")
            {
                landvo.storageWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString());
            }
            landvo.storageWaterPhase3Specified = true;
            landvo.storageWtrHosueId = 0;
            landvo.storageWtrHosueIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != "")
            {
                landvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString());
            }
            landvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != "")
            {
                landvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString());
            }
            landvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != "")
            {
                landvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString());
            }
            landvo.totalPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                TSIICLANDCGG.DateHolder commmercialpowersupply = new TSIICLANDCGG.DateHolder();

                commmercialpowersupply.day = newdate[0].ToString();
                commmercialpowersupply.displayDate = "";
                commmercialpowersupply.empty = true;
                commmercialpowersupply.emptySpecified = true;
                commmercialpowersupply.month = newdate[1].ToString();
                commmercialpowersupply.sqlDateStr = "";
                commmercialpowersupply.valid = true;
                commmercialpowersupply.validSpecified = true;
                commmercialpowersupply.year = newdate[2].ToString();
                electricityvo.commercialPhase1 = commmercialpowersupply;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder commmercialpowersupplyphase2 = new TSIICLANDCGG.DateHolder();
                commmercialpowersupplyphase2.day = newdate[0].ToString();
                commmercialpowersupplyphase2.displayDate = "";
                commmercialpowersupplyphase2.empty = true;
                commmercialpowersupplyphase2.emptySpecified = true;
                commmercialpowersupplyphase2.month = newdate[1].ToString();
                commmercialpowersupplyphase2.sqlDateStr = "";
                commmercialpowersupplyphase2.valid = true;
                commmercialpowersupplyphase2.validSpecified = true;
                commmercialpowersupplyphase2.year = newdate[2].ToString();
                electricityvo.commercialPhase2 = commmercialpowersupplyphase2;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder commmercialpowersupplyphase3 = new TSIICLANDCGG.DateHolder();
                commmercialpowersupplyphase3.day = newdate[0].ToString();
                commmercialpowersupplyphase3.displayDate = "";
                commmercialpowersupplyphase3.empty = true;
                commmercialpowersupplyphase3.emptySpecified = true;
                commmercialpowersupplyphase3.month = newdate[1].ToString();
                commmercialpowersupplyphase3.sqlDateStr = "";
                commmercialpowersupplyphase3.valid = true;
                commmercialpowersupplyphase3.validSpecified = true;
                commmercialpowersupplyphase3.year = newdate[2].ToString();
                electricityvo.commercialPhase3 = commmercialpowersupplyphase3;
            }
            if (GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != "")
            {
                electricityvo.connectedLoadPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString());
            }
            electricityvo.connectedLoadPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != "")
            {
                electricityvo.connectedLoadPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString());
            }
            electricityvo.connectedLoadPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != "")
            {
                electricityvo.connectedLoadPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString());
            }
            electricityvo.connectedLoadPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');



                TSIICLANDCGG.DateHolder constructionpowersupply = new TSIICLANDCGG.DateHolder();


                constructionpowersupply.day = newdate[0].ToString();
                constructionpowersupply.displayDate = "";
                constructionpowersupply.empty = true;
                constructionpowersupply.emptySpecified = true;
                constructionpowersupply.month = newdate[1].ToString();
                constructionpowersupply.sqlDateStr = "";
                constructionpowersupply.valid = true;
                constructionpowersupply.validSpecified = true;
                constructionpowersupply.year = newdate[2].ToString();
                electricityvo.constructionPhase1 = constructionpowersupply;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder constructionpowersupply2 = new TSIICLANDCGG.DateHolder();
                constructionpowersupply2.day = newdate[0].ToString();
                constructionpowersupply2.day = "";
                constructionpowersupply2.displayDate = "";
                constructionpowersupply2.empty = true;
                constructionpowersupply2.emptySpecified = true;
                constructionpowersupply2.month = newdate[1].ToString();
                constructionpowersupply2.sqlDateStr = "";
                constructionpowersupply2.valid = true;
                constructionpowersupply2.validSpecified = true;
                constructionpowersupply2.year = newdate[2].ToString();
                electricityvo.constructionPhase2 = constructionpowersupply2;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder constructionpowersupply3 = new TSIICLANDCGG.DateHolder();

                constructionpowersupply3.day = newdate[0].ToString();

                constructionpowersupply3.displayDate = "";
                constructionpowersupply3.empty = true;
                constructionpowersupply3.emptySpecified = true;
                constructionpowersupply3.month = newdate[1].ToString();
                constructionpowersupply3.sqlDateStr = "";
                constructionpowersupply3.valid = true;
                constructionpowersupply3.validSpecified = true;
                constructionpowersupply3.year = newdate[2].ToString();
                electricityvo.constructionPhase3 = constructionpowersupply3;
            }
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != "")
            {
                electricityvo.contractDemandPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString());
            }
            electricityvo.contractDemandPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != "")
            {
                electricityvo.contractDemandPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString());
            }
            electricityvo.contractDemandPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != "")
            {
                electricityvo.contractDemandPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString());
            }
            electricityvo.contractDemandPhase3Specified = true;
            electricityvo.energySrcDGSet = GDs.Tables[2].Rows[0]["DGset"].ToString();
            electricityvo.energySrcGeneration = GDs.Tables[2].Rows[0]["owngeneration"].ToString();
            electricityvo.energySrcSupply = GDs.Tables[2].Rows[0]["TStranscosupply"].ToString();
            electricityvo.landId = 0;
            electricityvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != "")
            {
                electricityvo.loadFactorPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactor"].ToString());
            }
            electricityvo.loadFactorPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != "")
            {
                electricityvo.loadFactorPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString());
            }
            electricityvo.loadFactorPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != "")
            {
                electricityvo.loadFactorPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString());
            }
            electricityvo.loadFactorPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != "")
            {
                electricityvo.powerRequirementPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString());
            }
            electricityvo.powerRequirementPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != "")
            {
                electricityvo.powerRequirementPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString());
            }
            electricityvo.powerRequirementPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != "")
            {
                electricityvo.powerRequirementPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString());
            }
            electricityvo.powerRequirementPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != "")
            {
                electricityvo.powerSupplyPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString());
            }
            electricityvo.powerSupplyPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != "")
            {
                electricityvo.powerSupplyPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString());
            }
            electricityvo.powerSupplyPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != "")
            {
                electricityvo.powerSupplyPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString());
            }
            electricityvo.powerSupplyPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != "")
            {
                electricityvo.voltageRatingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString());
            }
            electricityvo.voltageRatingPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != "")
            {
                electricityvo.voltageRatingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString());
            }
            electricityvo.voltageRatingPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != "")
            {
                electricityvo.voltageRatingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString());
            }
            electricityvo.voltageRatingPhase3Specified = true;

            watervo.landId = 0;
            watervo.landIdSpecified = true;
            watervo.permtDomesticId = 0;
            watervo.permtDomesticIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != "")
            {
                watervo.permtDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString());
            }
            watervo.permtDomesticPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != "")
            {
                watervo.permtDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString());
            }
            watervo.permtDomesticPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != "")
            {
                watervo.permtDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString());
            }
            watervo.permtDomesticPhase3Specified = true;
            watervo.permtIndustrialId = 0;
            watervo.permtIndustrialIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != "")
            {
                watervo.permtIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString());
            }
            watervo.permtIndustrialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != "")
            {
                watervo.permtIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString());
            }
            watervo.permtIndustrialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != "")
            {
                watervo.permtIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString());
            }
            watervo.permtIndustrialPhase3Specified = true;
            watervo.tempDomesticId = 0;
            watervo.tempDomesticIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != "")
            {
                watervo.tempDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString());
            }
            watervo.tempDomesticPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString());
            }
            watervo.tempDomesticPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != "")
            {
                watervo.tempDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString());
            }
            watervo.tempDomesticPhase3Specified = true;
            watervo.tempIndustrialId = 0;
            watervo.tempIndustrialIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReq"].ToString());
            }
            watervo.tempIndustrialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString());
            }
            watervo.tempIndustrialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != "")
            {
                watervo.tempIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString());
            }
            watervo.tempIndustrialPhase3Specified = true;

            effluentsvo.disposalSystem = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            effluentsvo.landId = 0;
            effluentsvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() != null && GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() != "")
            {
                effluentsvo.quantityPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString());
            }
            effluentsvo.quantityPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() != "")
            {
                effluentsvo.quantityPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString());
            }
            effluentsvo.quantityPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() != "")
            {
                effluentsvo.quantityPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString());
            }
            effluentsvo.quantityPhase3Specified = true;
            effluentsvo.typeDescription = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            if (GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != "")
            {
                effluentsvo.wastagePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString());
            }
            effluentsvo.wastagePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != "")
            {
                effluentsvo.wastagePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString());
            }
            effluentsvo.wastagePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != "")
            {
                effluentsvo.wastagePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString());
            }
            effluentsvo.wastagePhase3Specified = true;

        }

        if (GDs.Tables[3].Rows.Count > 0)
        {
            DataTable dtceigdocuments = new DataTable();
            dtceigdocuments = GDs.Tables[3];
            for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
            {
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "1")
                {
                    documentCheckListvo.detailedProject = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }

                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "2")
                {
                    documentCheckListvo.enterpreneurMemorandum = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                //documentCheckListvo.
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "3")
                {
                    documentCheckListvo.partnerShipDeed = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "4")
                {
                    documentCheckListvo.shareHolderDetails = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "5")
                {
                    documentCheckListvo.plantLayout = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "6")
                {
                    documentCheckListvo.casteCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "7")
                {
                    documentCheckListvo.addressProof = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "8")
                {
                    documentCheckListvo.panCard = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "9")
                {
                    documentCheckListvo.photoGraph = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "10")
                {
                    documentCheckListvo.financeCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "11")
                {
                    documentCheckListvo.paymentReceipt = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "12")
                {
                    documentCheckListvo.gstCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "13")
                {
                    documentCheckListvo.otherDocument = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "16")
                {
                    documentCheckListvo.cancelledCheck = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }

            }
        }


        TSIICLANDCGG.AdditionalPromoter[] additionalPromotervo = null;// new TSIICLANDCGG.AdditionalPromoter();

        //new TSIICLANDCGG.AdditionalPromoter();
        if (GDs.Tables[4].Rows.Count > 0)
        {
            TSIICLANDCGG.AdditionalPromoter[] AdditionalPromotervo = null;
            DataTable dtraw = new DataTable();
            dtraw = GDs.Tables[4];
            AdditionalPromotervo = new TSIICLANDCGG.AdditionalPromoter[dtraw.Rows.Count];

            for (int k = 0; k < dtraw.Rows.Count; k++)
            {
                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                TSIICLANDCGG.AdditionalPromoter coc = new TSIICLANDCGG.AdditionalPromoter();
                coc.additionalPromoterId = 0;// Convert.ToInt32(dtraw.Rows[k]["0"]);
                coc.additionalPromoterIdSpecified = false;// Convert.ToBoolean(dtraw.Rows[k]["false"]);
                if (dtraw.Rows[k]["Experience"].ToString() != null && dtraw.Rows[k]["Experience"].ToString() != "")
                {
                    coc.experience = Convert.ToDouble(dtraw.Rows[k]["Experience"].ToString());
                }
                coc.experienceSpecified = true;
                coc.name = dtraw.Rows[k]["Name"].ToString();
                coc.netWorthSpecified = true;
                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                coc.netWorth = Convert.ToInt32(dtraw.Rows[k]["Networth"]);
                coc.qualification = dtraw.Rows[k]["Qualification"].ToString();
                coc.contactNo = dtraw.Rows[k]["ContactNo"].ToString();
                coc.address = dtraw.Rows[k]["Address"].ToString();
                AdditionalPromotervo[k] = coc;
                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
            }
            additionalPromotervo = AdditionalPromotervo;

        }
        if (GDs.Tables[5].Rows.Count > 0)
        {

            registraionvo.companyAddress = "";
            registraionvo.companyAreaCode = "";
            registraionvo.companyName = "";
            registraionvo.companyPhone = "";
            registraionvo.emailId = GDs.Tables[5].Rows[0]["Email"].ToString();
            registraionvo.firstName = GDs.Tables[5].Rows[0]["Firstname"].ToString();
            registraionvo.ipassRegistrationId = Convert.ToInt64(GDs.Tables[5].Rows[0]["INTUSERID"].ToString());
            registraionvo.ipassRegistrationIdSpecified = true;
            registraionvo.mobile = GDs.Tables[5].Rows[0]["MobileNo"].ToString();
            registraionvo.password = "";
            registraionvo.surname = GDs.Tables[5].Rows[0]["Lastname"].ToString();
        }
        if (GDs.Tables[6].Rows.Count > 0)
        {

            //paymentDetailsvo.area = "61169.00";
            paymentDetailsvo.bankReferenceNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();


            paymentDetailsvo.customerReferenceNumber = GDs.Tables[6].Rows[0]["UIDNO"].ToString();
            paymentDetailsvo.dateAndTime = "";
            paymentDetailsvo.emd = "";
            paymentDetailsvo.gstNumber = "";
            paymentDetailsvo.gstRegesterd = "";
            paymentDetailsvo.industrialPark = "";
            paymentDetailsvo.landCost = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
            paymentDetailsvo.landCostSpecified = true;
            paymentDetailsvo.paidAmount = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
            paymentDetailsvo.paidAmountSpecified = true;
            paymentDetailsvo.paymentMode = "Online";
            //paymentDetailsvo.processFee = "";
            paymentDetailsvo.referenceId = GDs.Tables[6].Rows[0]["OnlineOrderNo"].ToString();
            paymentDetailsvo.remarks = "";
            //paymentDetailsvo.sgst = "";
            paymentDetailsvo.statusCode = "";
            paymentDetailsvo.transactionNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();
            paymentDetailsvo.dateAndTime = GDs.Tables[6].Rows[0]["Transactiondatetime"].ToString();
            paymentDetailsvo.account_branch = GDs.Tables[6].Rows[0]["account_branch"].ToString();
            paymentDetailsvo.account_ifsc = GDs.Tables[6].Rows[0]["account_ifsc"].ToString();
            paymentDetailsvo.account_name = GDs.Tables[6].Rows[0]["account_name"].ToString();
            paymentDetailsvo.account_no = GDs.Tables[6].Rows[0]["account_no"].ToString();
            paymentDetailsvo.account_type = GDs.Tables[6].Rows[0]["account_type"].ToString();
        }

        if (GDs.Tables[10].Rows.Count > 0)
        {
            paymentDetailsvo.area = GDs.Tables[10].Rows[0]["PlotTotalArea"].ToString();
            paymentDetailsvo.cgst = GDs.Tables[10].Rows[0]["CGST"].ToString();
            paymentDetailsvo.sgst = GDs.Tables[10].Rows[0]["SGST"].ToString();
            paymentDetailsvo.processFee = GDs.Tables[10].Rows[0]["ProcessFee"].ToString();
            paymentDetailsvo.emd = GDs.Tables[10].Rows[0]["TotalEmd"].ToString();
        }
        if (GDs.Tables[12].Rows.Count > 0)
        {
            plotvo.totalArea = Convert.ToDouble(GDs.Tables[12].Rows[0]["PlotTotalArea"]);
        }
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        string useroutput = landservice.registerUser(registraionvo);
        string output = landservice.saveApplicationDetails(plotvo, intuserid, appid, verifyFirmvo, promoterDetailsvo, additionalPromotervo, projectGeneralvo, projectFinancialvo,
              projectEmploymentvo, projectMaterialManufacturingvo, projectPlantMachineryvo, landvo, electricityvo, watervo, effluentsvo, paymentDetailsvo, documentCheckListvo);
        if (output == "Applications details are saved successfully....")
        {
            Gen.UpdateDepartwebserviceflagtsiic(appid.ToString(), "3", "C", "Y", output);

        }
        else
        {
            Gen.UpdateDepartwebserviceflagtsiic(appid.ToString(), "3", "C", "N", output);
        }

        //string useroutput = landservice.registerUser(registraionvo);
        //string output = landservice.saveApplicationDetails(plotvo, Convert.ToInt32(createdby), applicationid, verifyFirmvo, promoterDetailsvo, additionalPromotervo, projectGeneralvo, projectFinancialvo,
        //      projectEmploymentvo, projectMaterialManufacturingvo, projectPlantMachineryvo, landvo, electricityvo, watervo, effluentsvo, paymentDetailsvo, documentCheckListvo);
        //if (output == "Applications details are saved successfully....")
        //{
        //    Gen.UpdateDepartwebserviceflagtsiic(Convert.ToString(applicationid), "3", "C", "Y", output);

        //}
        //else
        //{
        //    Gen.UpdateDepartwebserviceflagtsiic(Convert.ToString(applicationid), "3", "C", "N", output);
        //}

        //if (GDs.Tables[0].Rows.Count > 0)
        //{

        //    plotvo.district = GDs.Tables[0].Rows[0]["DistrictName"].ToString();
        //    plotvo.emd = 0;
        //    plotvo.industrialPark = GDs.Tables[0].Rows[0]["IndustrialParkId"].ToString();
        //}

        //if (GDs.Tables[1].Rows.Count > 0)
        //{
        //    string str = "";
        //    for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
        //    {
        //        str += GDs.Tables[1].Rows[i]["PLOTNO"].ToString() + ",";
        //    }

        //    plotvo.plotNo = str.Substring(0, str.Length - 1);
        //    plotvo.price = Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
        //    plotvo.totalArea = Convert.ToDouble(GDs.Tables[1].Rows[0]["PlotTotalArea"]);
        //    plotvo.amount = Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
        //    plotvo.area = Convert.ToDouble(GDs.Tables[1].Rows[0]["PlotTotalArea"]);
        //    plotvo.amountSpecified = true;
        //    plotvo.areaSpecified = true;
        //    plotvo.emdSpecified = true;
        //    plotvo.gstSpecified = true;
        //    plotvo.priceSpecified = true;
        //    plotvo.processFeeSpecified = true;
        //    plotvo.totalAreaSpecified = true;
        //    plotvo.totalEmdSpecified = true;
        //    plotvo.totalPriceSpecified = true;



        //}

        //if (GDs.Tables[2].Rows.Count > 0)
        //{

        //    //if (Convert.ToDouble(GDs.Tables[2].Rows[0]["GSTNumber"].ToString())!=0 ||   GDs.Tables[2].Rows[0]["GSTNumber"].ToString() != " " || GDs.Tables[2].Rows[0]["GSTNumber"].ToString() != null)
        //    //{
        //    //    plotvo.gst = Convert.ToDouble(GDs.Tables[2].Rows[0]["GSTNumber"].ToString());

        //    //}


        //    //else
        //    //{

        //    //plotvo.gst = 0;
        //    //}

        //    verifyFirmvo.alloteeName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

        //    paymentDetailsvo.clientName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

        //    verifyFirmvo.applicantName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();
        //    verifyFirmvo.catDesc = GDs.Tables[2].Rows[0]["GovtDeptName_RegOffice"].ToString();
        //    TSIICLANDCGG.CodeDesc categorycodeDescvo = new TSIICLANDCGG.CodeDesc();
        //    categorycodeDescvo.code = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
        //    categorycodeDescvo.desc = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
        //    verifyFirmvo.categoryOfAllotment = categorycodeDescvo;
        //    addressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
        //    addressvo.country = "INDIA";// GDs.Tables[2].Rows[0][""].ToString();
        //    addressvo.district = GDs.Tables[2].Rows[0]["Distid_regoffices"].ToString();
        //    addressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_RegOffice"].ToString();
        //    addressvo.mandal = GDs.Tables[2].Rows[0]["mandal_regoffices"].ToString();
        //    addressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_RegOffice"].ToString();
        //    TSIICLANDCGG.CodeDesc statestnames = new TSIICLANDCGG.CodeDesc();
        //    statestnames.code = GDs.Tables[2].Rows[0]["stateNames"].ToString();
        //    statestnames.desc = GDs.Tables[2].Rows[0]["stateNames"].ToString();
        //    addressvo.state = statestnames;
        //    addressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_RegOffice"].ToString();
        //    addressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_RegOffice"].ToString();
        //    addressvo.village = GDs.Tables[2].Rows[0]["village_regoffices"].ToString();

        //    communicationAddressvo.address = addressvo;


        //    TSIICLANDCGG.Landline comphone = new TSIICLANDCGG.Landline();
        //    comphone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
        //    comphone.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
        //    comphone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
        //    comphone.phone = "";
        //    comphone.valid = true;
        //    comphone.validSpecified = true;
        //    communicationAddressvo.phoneNum = comphone;



        //    TSIICLANDCGG.Landline faxno = new TSIICLANDCGG.Landline();
        //    faxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
        //    faxno.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
        //    faxno.number = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
        //    faxno.phone = "";
        //    faxno.valid = true;
        //    faxno.validSpecified = true;
        //    communicationAddressvo.faxNum = faxno;

        //    verifyFirmvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
        //    verifyFirmvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
        //    verifyFirmvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
        //    verifyFirmvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();

        //    firmDetailsvo.communicationAddress = communicationAddressvo;
        //    firmRegistrationDetailsvo.regstrAuthority = GDs.Tables[2].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
        //    firmRegistrationDetailsvo.regstrNumber = GDs.Tables[2].Rows[0]["RegistrationNo_Firmregistration"].ToString();
        //    firmRegistrationDetailsvo.yrOfCommence = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofCommencement_Firmregistration"].ToString());
        //    firmRegistrationDetailsvo.yrOfCommenceSpecified = true;
        //    firmRegistrationDetailsvo.yrOfEstbl = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofEstablishment_Firmregistration"].ToString());
        //    firmRegistrationDetailsvo.yrOfEstblSpecified = true;





        //    firmDetailsvo.firmRegistrationDetails = firmRegistrationDetailsvo;
        //    firmDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
        //    firmDetailsvo.userIdSpecified = true;
        //    verifyFirmvo.firmDetails = firmDetailsvo;
        //    verifyFirmvo.houseNo = GDs.Tables[2].Rows[0]["House_Prv_flot"].ToString();


        //    TSIICLANDCGG.CodeDesc orgtype = new TSIICLANDCGG.CodeDesc();
        //    orgtype.code = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
        //    orgtype.desc = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
        //    verifyFirmvo.orgType = orgtype;
        //    Commaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
        //    Commaddressvo.country = "INDIA";// GDs.Tables[2].Rows[0][""].ToString();
        //    Commaddressvo.district = GDs.Tables[2].Rows[0]["Distid_CommAddrs"].ToString();
        //    Commaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_CommAddr"].ToString();
        //    Commaddressvo.mandal = GDs.Tables[2].Rows[0]["mandal_commaddrs"].ToString();
        //    Commaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_CommAddr"].ToString();
        //    //CommcodeDescvo.code = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
        //    // CommcodeDescvo.desc = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
        //    Commaddressvo.state = codeDescvo;


        //    Commaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_CommAddr"].ToString();
        //    Commaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_CommAddr"].ToString();
        //    Commaddressvo.village = GDs.Tables[2].Rows[0]["Village_CommAddrs"].ToString();
        //    CommcommunicationAddressvo.address = Commaddressvo;


        //    TSIICLANDCGG.Landline comtelephone = new TSIICLANDCGG.Landline();

        //    TSIICLANDCGG.Landline comfaxno = new TSIICLANDCGG.Landline();
        //    //comtelephone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
        //    landlinevo.formattedPhone = "";
        //    //comtelephone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
        //    landlinevo.phone = "";
        //    landlinevo.valid = true;
        //    landlinevo.validSpecified = true;
        //    communicationAddressvo.phoneNum = comtelephone;
        //    comfaxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
        //    landlinevo.formattedPhone = "";
        //    comfaxno.number = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
        //    landlinevo.phone = "";
        //    landlinevo.valid = true;
        //    landlinevo.validSpecified = true;

        //    verifyFirmvo.otherCommFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
        //    verifyFirmvo.otherCommFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString();
        //    verifyFirmvo.otherCommPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();
        //    verifyFirmvo.otherCommPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString();



        //    verifyFirmvo.otherCommunicationAddress = CommcommunicationAddressvo;
        //    verifyFirmvo.others = GDs.Tables[2].Rows[0]["OtherDetails_Prv_flot"].ToString();
        //    verifyFirmvo.plotNo = GDs.Tables[2].Rows[0]["PlotNo_Prv_flot"].ToString();
        //    verifyFirmvo.shedName = GDs.Tables[2].Rows[0]["ShedName_Prv_flot"].ToString();
        //    verifyFirmvo.shopNo = GDs.Tables[2].Rows[0]["Shop_Prv_flot"].ToString();

        //    ///promoter details///

        //    Contactaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
        //    Contactaddressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
        //    Contactaddressvo.district = GDs.Tables[2].Rows[0]["Distidcontactinfo"].ToString();
        //    Contactaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_Cont_info"].ToString();
        //    Contactaddressvo.mandal = GDs.Tables[2].Rows[0]["mandalcontinfo"].ToString();
        //    Contactaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_Cont_info"].ToString();
        //    codeDescvo.code = GDs.Tables[2].Rows[0]["statecontinfos"].ToString();
        //    codeDescvo.desc = GDs.Tables[2].Rows[0]["statecontinfos"].ToString(); // GDs.Tables[2].Rows[0][""].ToString();
        //    Contactaddressvo.state = codeDescvo;
        //    Contactaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_Cont_info"].ToString();
        //    Contactaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_Cont_info"].ToString();
        //    Contactaddressvo.village = GDs.Tables[2].Rows[0]["villagecontinfo"].ToString();
        //    ContactcommunicationAddressvo.address = Contactaddressvo;

        //    TSIICLANDCGG.Landline contfax = new TSIICLANDCGG.Landline();
        //    contfax.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
        //    landlinevo.formattedPhone = "";
        //    contfax.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
        //    //landlinevo.phone =GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
        //    landlinevo.valid = true;
        //    landlinevo.validSpecified = true;
        //    communicationAddressvo.faxNum = landlinevo;
        //    landlinevo.areaCode = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
        //    landlinevo.formattedPhone = "";
        //    //landlinevo.number = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
        //    landlinevo.phone = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
        //    landlinevo.valid = true;
        //    landlinevo.validSpecified = true;
        //    communicationAddressvo.phoneNum = landlinevo;


        //    promoterDetailsvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
        //    promoterDetailsvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
        //    promoterDetailsvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
        //    promoterDetailsvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
        //    promoterDetailsvo.cellNumber = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();

        //    promoterDetailsvo.communicationAddress = ContactcommunicationAddressvo;
        //    promoterDetailsvo.emailId = GDs.Tables[2].Rows[0]["Email_Cont_info"].ToString();
        //    mobilevo.areaCode = "";// GDs.Tables[2].Rows[0][""].ToString();
        //    mobilevo.formattedPhone = "";
        //    mobilevo.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
        //    mobilevo.phone = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
        //    mobilevo.valid = true;
        //    mobilevo.validSpecified = true;
        //    promoterDetailsvo.mobile = mobilevo;
        //    personvo.firstName = GDs.Tables[2].Rows[0]["FirstName_Cont_info"].ToString();
        //    personvo.surname = GDs.Tables[2].Rows[0]["Surname_Cont_info"].ToString();
        //    promoterDetailsvo.personName = personvo;
        //    promoterFinancialInformationvo.detlsImvableAssests = GDs.Tables[2].Rows[0]["Immovable_Assets_Land_Building_Financial"].ToString();
        //    promoterFinancialInformationvo.funcResponsibilities = GDs.Tables[2].Rows[0]["ProposedProject_Financial"].ToString();
        //    promoterFinancialInformationvo.otherAssests = Convert.ToDouble(GDs.Tables[2].Rows[0]["OtherAssets_Financial_Inlakhs"].ToString());
        //    promoterFinancialInformationvo.otherAssestsSpecified = true;
        //    promoterFinancialInformationvo.otherInfo = GDs.Tables[2].Rows[0]["Anyother_Financial_Info"].ToString();
        //    promoterFinancialInformationvo.panNo = GDs.Tables[2].Rows[0]["PanNumber_Financial_Info"].ToString();
        //    promoterFinancialInformationvo.personalAsset = Convert.ToDouble(GDs.Tables[2].Rows[0]["Assets_Financial_Inlakhs"].ToString());
        //    promoterFinancialInformationvo.personalAssetSpecified = true;
        //    promoterFinancialInformationvo.personalLiability = Convert.ToDouble(GDs.Tables[2].Rows[0]["Liabilities_Financial_Inlakhs"].ToString());
        //    promoterFinancialInformationvo.personalLiabilitySpecified = true;
        //    promoterDetailsvo.promoterFinancialInformation = promoterFinancialInformationvo;
        //    promoterDetailsvo.promoterId = 0;// GDs.Tables[2].Rows[0][""].ToString();
        //    promoterDetailsvo.promoterIdSpecified = true;
        //    promoterDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
        //    promoterDetailsvo.userIdSpecified = true;
        //    TSIICLANDCGG.Product[] product = null;
        //    projectGeneralvo.byProductList = product;
        //    if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');
        //        // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
        //        TSIICLANDCGG.DateHolder datevocomme = new TSIICLANDCGG.DateHolder();
        //        datevocomme.day = newdate[0].ToString();
        //        datevocomme.displayDate = "";
        //        datevocomme.empty = true;
        //        datevocomme.emptySpecified = true;
        //        datevocomme.month = newdate[1].ToString();
        //        datevocomme.sqlDateStr = "";
        //        datevocomme.valid = true;
        //        datevocomme.validSpecified = true;
        //        datevocomme.year = newdate[2].ToString();

        //        projectGeneralvo.commOperationPhase1 = datevocomme;
        //    }

        //    if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');
        //        // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
        //        TSIICLANDCGG.DateHolder datevocommercial = new TSIICLANDCGG.DateHolder();

        //        datevocommercial.day = newdate[0].ToString();
        //        datevocommercial.displayDate = "";
        //        datevocommercial.empty = true;
        //        datevocommercial.emptySpecified = true;
        //        datevocommercial.month = newdate[1].ToString();
        //        datevocommercial.sqlDateStr = "";
        //        datevocommercial.valid = true;
        //        datevocommercial.validSpecified = true;
        //        datevocommercial.year = newdate[2].ToString();
        //        projectGeneralvo.commOperationPhase2 = datevocommercial;
        //    }
        //    if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');
        //        TSIICLANDCGG.DateHolder datevocommercialphase2 = new TSIICLANDCGG.DateHolder();
        //        // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();

        //        datevocommercialphase2.day = newdate[0].ToString();
        //        datevocommercialphase2.displayDate = "";
        //        datevocommercialphase2.empty = true;
        //        datevocommercialphase2.emptySpecified = true;
        //        datevocommercialphase2.month = newdate[1].ToString();
        //        datevocommercialphase2.sqlDateStr = "";
        //        datevocommercialphase2.valid = true;
        //        datevocommercialphase2.validSpecified = true;
        //        datevocommercialphase2.year = newdate[2].ToString();
        //        projectGeneralvo.commOperationPhase3 = datevocommercialphase2;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');
        //        TSIICLANDCGG.DateHolder datevoconstruction = new TSIICLANDCGG.DateHolder();
        //        datevoconstruction.day = newdate[0].ToString();
        //        datevoconstruction.displayDate = "";
        //        datevoconstruction.empty = true;
        //        datevoconstruction.emptySpecified = true;
        //        datevoconstruction.month = newdate[1].ToString();
        //        datevoconstruction.sqlDateStr = "";
        //        datevoconstruction.valid = true;
        //        datevoconstruction.validSpecified = true;
        //        datevoconstruction.year = newdate[2].ToString();

        //        projectGeneralvo.constructionPhase1 = datevoconstruction;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder datevoconstructionphase2 = new TSIICLANDCGG.DateHolder();
        //        datevoconstructionphase2.day = newdate[0].ToString();
        //        datevoconstructionphase2.displayDate = "";
        //        datevoconstructionphase2.empty = true;
        //        datevoconstructionphase2.emptySpecified = true;
        //        datevoconstructionphase2.month = newdate[1].ToString();
        //        datevoconstructionphase2.sqlDateStr = "";
        //        datevoconstructionphase2.valid = true;
        //        datevoconstructionphase2.validSpecified = true;
        //        datevoconstructionphase2.year = newdate[2].ToString();
        //        projectGeneralvo.constructionPhase2 = datevoconstructionphase2;
        //    }

        //    if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');


        //        TSIICLANDCGG.DateHolder datevoconstructionphase3 = new TSIICLANDCGG.DateHolder();
        //        datevoconstructionphase3.day = newdate[0].ToString();
        //        datevoconstructionphase3.displayDate = "";
        //        datevoconstructionphase3.empty = true;
        //        datevoconstructionphase3.emptySpecified = true;
        //        datevoconstructionphase3.month = newdate[1].ToString();
        //        datevoconstructionphase3.sqlDateStr = "";
        //        datevoconstructionphase3.valid = true;
        //        datevoconstructionphase3.validSpecified = true;
        //        datevoconstructionphase3.year = newdate[2].ToString();
        //        projectGeneralvo.constructionPhase3 = datevoconstructionphase3;
        //    }

        //    projectGeneralvo.projCategory = GDs.Tables[2].Rows[0]["typeofprojectscategory"].ToString();
        //    projectGeneralvo.projCatgryOther = GDs.Tables[2].Rows[0]["projectother"].ToString();
        //    projectGeneralvo.projCatgryOtherValue = GDs.Tables[2].Rows[0]["ProjectCategory3_General_Info"].ToString();
        //    projectGeneralvo.projDesc = GDs.Tables[2].Rows[0]["ProjectName_Description_General_Info"].ToString();
        //    projectGeneralvo.projectId = 0;
        //    projectGeneralvo.projectIdSpecified = true;
        //    projectGeneralvo.projStatus = GDs.Tables[2].Rows[0]["typeofprojectstatus"].ToString();
        //    TSIICLANDCGG.Product[] productprosposed = null;
        //    if (GDs.Tables[7].Rows.Count > 0)
        //    {
        //        DataTable dtraw = new DataTable();
        //        dtraw = GDs.Tables[7];
        //        productprosposed = new TSIICLANDCGG.Product[dtraw.Rows.Count];

        //        for (int k = 0; k < dtraw.Rows.Count; k++)
        //        {
        //            TSIICLANDCGG.Product Productvo = new TSIICLANDCGG.Product();
        //            Productvo.code = dtraw.Rows[k]["Itemcode"].ToString();
        //            Productvo.expectedOutput = 0.00; //dtraw.Rows[k][""].ToString();
        //            Productvo.expectedOutputSpecified = true;

        //            if (dtraw.Rows[k]["Installedcapacity"].ToString() == "")
        //            {


        //                Productvo.installedCapacity = 0;

        //            }
        //            else
        //            {
        //                Productvo.installedCapacity = Convert.ToDouble(dtraw.Rows[k]["Installedcapacity"]);
        //            }

        //            Productvo.installedCapacitySpecified = true;
        //            Productvo.measurement = dtraw.Rows[k]["Unitmeasurement"].ToString();
        //            Productvo.name = dtraw.Rows[k]["Product"].ToString();
        //            Productvo.productId = 0;
        //            Productvo.productIdSpecified = false;
        //            productprosposed[k] = Productvo;
        //            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
        //            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
        //        }
        //        projectGeneralvo.propProductList = productprosposed;
        //    }
        //    projectGeneralvo.propProductList = productprosposed;

        //    if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');


        //        TSIICLANDCGG.DateHolder datevotrialperation = new TSIICLANDCGG.DateHolder();
        //        datevotrialperation.day = newdate[0].ToString();
        //        datevotrialperation.displayDate = "";
        //        datevotrialperation.empty = true;
        //        datevotrialperation.emptySpecified = true;
        //        datevotrialperation.month = newdate[1].ToString();
        //        datevotrialperation.sqlDateStr = "";
        //        datevotrialperation.valid = true;
        //        datevotrialperation.validSpecified = true;
        //        datevotrialperation.year = newdate[2].ToString();
        //        projectGeneralvo.trailOperationPhase1 = datevotrialperation;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder datevotrialperationphase2 = new TSIICLANDCGG.DateHolder();
        //        datevotrialperationphase2.day = newdate[0].ToString();
        //        datevotrialperationphase2.displayDate = "";
        //        datevotrialperationphase2.empty = true;
        //        datevotrialperationphase2.emptySpecified = true;
        //        datevotrialperationphase2.month = newdate[1].ToString();
        //        datevotrialperationphase2.sqlDateStr = "";
        //        datevotrialperationphase2.valid = true;
        //        datevotrialperationphase2.validSpecified = true;
        //        datevotrialperationphase2.year = newdate[2].ToString();
        //        projectGeneralvo.trailOperationPhase2 = datevotrialperationphase2;

        //    }

        //    if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString().Split(' ');


        //        TSIICLANDCGG.DateHolder datevotrialperationphase3 = new TSIICLANDCGG.DateHolder();
        //        string[] newdate = date[0].ToString().Split('-');
        //        datevotrialperationphase3.day = newdate[0].ToString();
        //        datevotrialperationphase3.displayDate = "";
        //        datevotrialperationphase3.empty = true;
        //        datevotrialperationphase3.emptySpecified = true;
        //        datevotrialperationphase3.month = newdate[1].ToString();
        //        datevotrialperationphase3.sqlDateStr = "";
        //        datevotrialperationphase3.valid = true;
        //        datevotrialperationphase3.validSpecified = true;
        //        datevotrialperationphase3.year = newdate[2].ToString();
        //        projectGeneralvo.trailOperationPhase3 = datevotrialperationphase3;
        //    }
        //    projectGeneralvo.ventureType1 = GDs.Tables[2].Rows[0]["Typeofventure"].ToString();
        //    projectGeneralvo.ventureType2 = "";
        //    if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.auxillaryEquipPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.auxillaryEquipPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.auxillaryEquipPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.auxillaryEquipPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.auxillaryEquipPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.auxillaryEquipPhase3Specified = true;
        //    projectFinancialvo.auxillaryId = 0;
        //    projectFinancialvo.auxillaryIdSpecified = true;
        //    projectFinancialvo.buildingId = 0;
        //    projectFinancialvo.buildingIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.buildingsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.buildingsPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.buildingsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString());
        //    }


        //    projectFinancialvo.buildingsPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.buildingsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.buildingsPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.contingenciesPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.contingenciesPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.contingenciesPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.contingenciesPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.contingenciesPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.contingenciesPhase3Specified = true;
        //    projectFinancialvo.contingeniousId = 0;
        //    projectFinancialvo.contingeniousIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Amount"].ToString() != null && GDs.Tables[2].Rows[0]["Amount"].ToString() != "")
        //    {
        //        projectFinancialvo.debtAmount = Convert.ToDouble(GDs.Tables[2].Rows[0]["Amount"].ToString());
        //    }
        //    projectFinancialvo.debtAmountSpecified = true;
        //    projectFinancialvo.debtName = GDs.Tables[2].Rows[0]["EquityName"].ToString();
        //    if (GDs.Tables[2].Rows[0]["EOUdate"].ToString() != "" && GDs.Tables[2].Rows[0]["EOUdate"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["EOUdate"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder equdate = new TSIICLANDCGG.DateHolder();
        //        equdate.day = newdate[0].ToString();
        //        equdate.displayDate = "";
        //        equdate.empty = true;
        //        equdate.emptySpecified = true;
        //        equdate.month = newdate[1].ToString();
        //        equdate.sqlDateStr = "";
        //        equdate.valid = true;
        //        equdate.validSpecified = true;
        //        equdate.year = newdate[2].ToString();
        //        projectFinancialvo.eouDate = equdate;
        //    }
        //    projectFinancialvo.eouNo = GDs.Tables[2].Rows[0]["EOUNo"].ToString();
        //    if (GDs.Tables[2].Rows[0]["Domestic"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic"].ToString() != "")
        //    {
        //        projectFinancialvo.equityDomestic = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic"].ToString());
        //    }
        //    projectFinancialvo.equityDomesticSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Foreigns"].ToString() != null && GDs.Tables[2].Rows[0]["Foreigns"].ToString() != "")
        //    {
        //        projectFinancialvo.equityForiegn = Convert.ToDouble(GDs.Tables[2].Rows[0]["Foreigns"].ToString());
        //    }
        //    projectFinancialvo.equityForiegnSpecified = true;

        //    if (GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != "" && GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder foreigndate = new TSIICLANDCGG.DateHolder();
        //        foreigndate.day = newdate[0].ToString();
        //        foreigndate.displayDate = "";
        //        foreigndate.empty = true;
        //        foreigndate.emptySpecified = true;
        //        foreigndate.month = newdate[1].ToString();
        //        foreigndate.sqlDateStr = "";
        //        foreigndate.valid = true;
        //        foreigndate.validSpecified = true;
        //        foreigndate.year = newdate[2].ToString();
        //        projectFinancialvo.fipbRbiApprDate = foreigndate;
        //    }

        //    projectFinancialvo.fipbRbiApprNo = GDs.Tables[2].Rows[0]["Foreigninvestment"].ToString();
        //    if (GDs.Tables[2].Rows[0]["IEMdate"].ToString() != "" && GDs.Tables[2].Rows[0]["IEMdate"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["IEMdate"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder Iemdate = new TSIICLANDCGG.DateHolder();
        //        Iemdate.day = newdate[0].ToString();
        //        Iemdate.displayDate = "";
        //        Iemdate.empty = true;
        //        Iemdate.emptySpecified = true;
        //        Iemdate.month = newdate[1].ToString();
        //        Iemdate.sqlDateStr = "";
        //        Iemdate.valid = true;
        //        Iemdate.validSpecified = true;
        //        Iemdate.year = newdate[2].ToString();
        //        projectFinancialvo.iemDate = Iemdate;
        //    }
        //    projectFinancialvo.iemNo = GDs.Tables[2].Rows[0]["IEM"].ToString();
        //    if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.indigeneousPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString());

        //    }
        //    projectFinancialvo.indigeneousPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.indigeneousPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.indigeneousPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.indigeneousPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.indigeneousPhase3Specified = true;
        //    projectFinancialvo.indigeniousId = 0;
        //    projectFinancialvo.indigeniousIdSpecified = true;
        //    projectFinancialvo.landId = 0;
        //    projectFinancialvo.landIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.landPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.landPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.landPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.landPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.landPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.landPhase3Specified = true;



        //    if (GDs.Tables[2].Rows[0]["LOIdate"].ToString() != "" && GDs.Tables[2].Rows[0]["LOIdate"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["LOIdate"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder loidate = new TSIICLANDCGG.DateHolder();
        //        loidate.day = newdate[0].ToString();
        //        loidate.displayDate = "";
        //        loidate.empty = true;
        //        loidate.emptySpecified = true;
        //        loidate.month = newdate[1].ToString();
        //        loidate.sqlDateStr = "";
        //        loidate.valid = true;
        //        loidate.validSpecified = true;
        //        loidate.year = newdate[2].ToString();
        //        projectFinancialvo.loiDate = loidate;
        //    }
        //    projectFinancialvo.loiNo = GDs.Tables[2].Rows[0]["LOI"].ToString();
        //    projectFinancialvo.machineryImportedId = 0;
        //    projectFinancialvo.machineryImportedIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.machineryImportedPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.machineryImportedPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.machineryImportedPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.machineryImportedPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.machineryImportedPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.machineryImportedPhase3Specified = true;
        //    projectFinancialvo.miscFixedId = 0;
        //    projectFinancialvo.miscFixedIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.miscFxdAssestsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.miscFxdAssestsPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.miscFxdAssestsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.miscFxdAssestsPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.miscFxdAssestsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.miscFxdAssestsPhase3Specified = true;
        //    projectFinancialvo.preliminaryId = 0;
        //    projectFinancialvo.preliminaryIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.preliminaryPreOperativePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.preliminaryPreOperativePhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.preliminaryPreOperativePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.preliminaryPreOperativePhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.preliminaryPreOperativePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.preliminaryPreOperativePhase3Specified = true;
        //    projectFinancialvo.projectId = 0;
        //    projectFinancialvo.projectIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != "")
        //    {
        //        projectFinancialvo.totalEqtyDebt = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString());
        //    }
        //    projectFinancialvo.totalEqtyDebtSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != "")
        //    {
        //        projectFinancialvo.totalEquity = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquity"].ToString());
        //    }
        //    projectFinancialvo.totalEquitySpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.totalPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.totalPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {

        //        projectFinancialvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString());
        //    }




        //    projectFinancialvo.totalPhase3Specified = true;
        //    projectFinancialvo.workCapitalId = 0;
        //    projectFinancialvo.workCapitalIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != "")
        //    {
        //        projectFinancialvo.workCptlMarginPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString());
        //    }
        //    projectFinancialvo.workCptlMarginPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != "")
        //    {
        //        projectFinancialvo.workCptlMarginPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString());
        //    }
        //    projectFinancialvo.workCptlMarginPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != "")
        //    {
        //        projectFinancialvo.workCptlMarginPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString());
        //    }
        //    projectFinancialvo.workCptlMarginPhase3Specified = true;





        //    if (GDs.Tables[2].Rows[0]["femalephase1"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase1"].ToString() != "")
        //    {
        //        projectEmploymentvo.femalePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase1"].ToString());
        //    }
        //    projectEmploymentvo.femalePhase1Specified = true;


        //    if (GDs.Tables[2].Rows[0]["femalephase2"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.femalePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase2"].ToString());
        //    }
        //    projectEmploymentvo.femalePhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["femalephase3"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.femalePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase3"].ToString());
        //    }
        //    projectEmploymentvo.femalePhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["malephase1"].ToString() != null && GDs.Tables[2].Rows[0]["malephase1"].ToString() != "")
        //    {
        //        projectEmploymentvo.malePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase1"].ToString());
        //    }
        //    projectEmploymentvo.malePhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["malephase2"].ToString() != null && GDs.Tables[2].Rows[0]["malephase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.malePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase2"].ToString());
        //    }
        //    projectEmploymentvo.malePhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["malephase3"].ToString() != null && GDs.Tables[2].Rows[0]["malephase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.malePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase3"].ToString());
        //    }
        //    projectEmploymentvo.malePhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != "")
        //    {
        //        projectEmploymentvo.managerialPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString());
        //    }
        //    projectEmploymentvo.managerialPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.managerialPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString());
        //    }
        //    projectEmploymentvo.managerialPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.managerialPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString());
        //    }
        //    projectEmploymentvo.managerialPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != null && GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != "")
        //    {
        //        projectEmploymentvo.maxNoWorkers = Convert.ToInt64(GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString());
        //    }
        //    projectEmploymentvo.maxNoWorkersSpecified = true;
        //    projectEmploymentvo.projectId = 0;
        //    projectEmploymentvo.projectIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != "")
        //    {
        //        projectEmploymentvo.skilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString());
        //    }
        //    projectEmploymentvo.skilledPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.skilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString());
        //    }
        //    projectEmploymentvo.skilledPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.skilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString());
        //    }
        //    projectEmploymentvo.skilledPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != "")
        //    {
        //        projectEmploymentvo.supervisoryPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString());
        //    }
        //    projectEmploymentvo.supervisoryPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.supervisoryPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString());
        //    }
        //    projectEmploymentvo.supervisoryPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.supervisoryPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString());
        //    }
        //    projectEmploymentvo.supervisoryPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != "")
        //    {
        //        projectEmploymentvo.totalPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Emp"].ToString());
        //    }
        //    projectEmploymentvo.totalPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.totalPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString());
        //    }
        //    projectEmploymentvo.totalPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.totalPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString());
        //    }
        //    projectEmploymentvo.totalPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != "")
        //    {
        //        projectEmploymentvo.unSkilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString());
        //    }
        //    projectEmploymentvo.unSkilledPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != "")
        //    {
        //        projectEmploymentvo.unSkilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString());
        //    }
        //    projectEmploymentvo.unSkilledPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != "")
        //    {
        //        projectEmploymentvo.unSkilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString());
        //    }
        //    projectEmploymentvo.unSkilledPhase3Specified = true;


        //    projectMaterialManufacturingvo.descProcessTech = GDs.Tables[2].Rows[0]["providedetails"].ToString();

        //    projectMaterialManufacturingvo.processTechnology = GDs.Tables[2].Rows[0]["processtechnology"].ToString();
        //    projectMaterialManufacturingvo.projectId = 0;
        //    projectMaterialManufacturingvo.projectIdSpecified = true;
        //    projectMaterialManufacturingvo.projectmatManf = "";
        //    TSIICLANDCGG.RawMaterial[] rawmaterial = null;
        //    if (GDs.Tables[8].Rows.Count > 0)
        //    {
        //        DataTable dtraw = new DataTable();
        //        dtraw = GDs.Tables[8];
        //        rawmaterial = new TSIICLANDCGG.RawMaterial[dtraw.Rows.Count];

        //        for (int k = 0; k < dtraw.Rows.Count; k++)
        //        {
        //            TSIICLANDCGG.RawMaterial rawmaterialvo = new TSIICLANDCGG.RawMaterial();


        //            if (dtraw.Rows[k]["DailyConsumption"].ToString() == "")
        //            {
        //                rawmaterialvo.dailyConsumption = 0;
        //            }
        //            else
        //            {

        //                rawmaterialvo.dailyConsumption = Convert.ToDouble(dtraw.Rows[k]["DailyConsumption"].ToString());
        //            }


        //            rawmaterialvo.dailyConsumptionSpecified = true;
        //            rawmaterialvo.itemCode = dtraw.Rows[k]["Itemcode"].ToString();
        //            rawmaterialvo.itemDescription = dtraw.Rows[k]["Descriptionitem"].ToString();
        //            rawmaterialvo.rawMaterialId = 0;
        //            // Convert.ToInt64(dtraw.Rows[k]["queryRespDocName"].ToString());
        //            rawmaterialvo.rawMaterialIdSpecified = true;
        //            rawmaterialvo.unitOfMeasure = dtraw.Rows[k]["unitmeasurement"].ToString();
        //            rawmaterial[k] = rawmaterialvo;
        //        }
        //        projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
        //    }

        //    projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
        //    projectMaterialManufacturingvo.techCollaborationDetails = GDs.Tables[2].Rows[0]["technicalcollabration"].ToString();
        //    projectMaterialManufacturingvo.technicalCollaboration = true;
        //    projectMaterialManufacturingvo.technicalCollaborationSpecified = true;

        //    if (GDs.Tables[2].Rows[0]["noofvessels"] != null && GDs.Tables[2].Rows[0]["noofvessels"]
        //        .ToString() != "")
        //    {
        //        projectPlantMachineryvo.highPressureLevel = Convert.ToInt64(GDs.Tables[2].Rows[0]
        //            ["noofvessels"].ToString());
        //    }
        //    projectPlantMachineryvo.highPressureLevelSpecified = true;

        //    TSIICLANDCGG.MachineryCapacity[] machinery = null;
        //    if (GDs.Tables[9].Rows.Count > 0)
        //    {
        //        DataTable dtraw = new DataTable();
        //        dtraw = GDs.Tables[9];
        //        machinery = new TSIICLANDCGG.MachineryCapacity[dtraw.Rows.Count];

        //        for (int k = 0; k < dtraw.Rows.Count; k++)
        //        {
        //            TSIICLANDCGG.MachineryCapacity MachineryCapacityvo = new TSIICLANDCGG.MachineryCapacity();

        //            if (dtraw.Rows[k]["capacitykw"].ToString() == "")
        //            {
        //                MachineryCapacityvo.plantCapacity = 0;

        //            }
        //            else
        //            {
        //                MachineryCapacityvo.plantCapacity = Convert.ToDouble(dtraw.Rows[k]["capacitykw"]);

        //            }

        //            MachineryCapacityvo.plantCapacitySpecified = true;
        //            MachineryCapacityvo.plantDescription = dtraw.Rows[k]["descplantmachinery"].ToString();
        //            MachineryCapacityvo.plantMachineryId = 0;
        //            MachineryCapacityvo.plantMachineryIdSpecified = true;
        //            MachineryCapacityvo.costofmachinery = dtraw.Rows[k]["cost"].ToString();
        //            MachineryCapacityvo.numberofmachineries = dtraw.Rows[k]["Quantity"].ToString();





        //            machinery[k] = MachineryCapacityvo;
        //        }
        //    }
        //    projectPlantMachineryvo.machineryCapacties = machinery;





        //    projectPlantMachineryvo.projectId = 0;
        //    projectPlantMachineryvo.projectIdSpecified = true;

        //    landvo.adminBuildingId = 0;
        //    landvo.adminBuildingIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != "")
        //    {
        //        landvo.adminBuildingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString());
        //    }
        //    landvo.adminBuildingPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != "")
        //    {
        //        landvo.adminBuildingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString());
        //    }
        //    landvo.adminBuildingPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != "")
        //    {
        //        landvo.adminBuildingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString());
        //    }
        //    landvo.adminBuildingPhase3Specified = true;
        //    landvo.estimatedarea = 0.00;// Convert.ToDouble(GDs.Tables[2].Rows[0][""].ToString());
        //    landvo.estimatedareaSpecified = true;
        //    landvo.indusShed = Convert.ToDouble(GDs.Tables[1].Rows[0]["Area_in_Sq_Mtrs"].ToString());
        //    landvo.indusShedSpecified = true;
        //    landvo.landId = 0;
        //    landvo.landIdSpecified = true;
        //    landvo.openAreaId = 0;
        //    landvo.openAreaIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != "")
        //    {
        //        landvo.openAreaPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString());
        //    }
        //    landvo.openAreaPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != "")
        //    {
        //        landvo.openAreaPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString());
        //    }
        //    landvo.openAreaPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != "")
        //    {
        //        landvo.openAreaPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString());
        //    }
        //    landvo.openAreaPhase3Specified = true;
        //    landvo.plantFactoryBuildingId = 0;
        //    landvo.plantFactoryBuildingIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != "")
        //    {
        //        landvo.plantFactoryPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString());
        //    }
        //    landvo.plantFactoryPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != "")
        //    {
        //        landvo.plantFactoryPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString());
        //    }
        //    landvo.plantFactoryPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != "")
        //    {
        //        landvo.plantFactoryPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString());
        //    }
        //    landvo.plantFactoryPhase3Specified = true;
        //    landvo.remarks = "";
        //    if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != "")
        //    {
        //        landvo.roadWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString());
        //    }
        //    landvo.roadWaterPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != "")
        //    {
        //        landvo.roadWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString());
        //    }
        //    landvo.roadWaterPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != "")
        //    {
        //        landvo.roadWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString());
        //    }
        //    landvo.roadWaterPhase3Specified = true;
        //    landvo.roadWtrStrgId = 0;
        //    landvo.roadWtrStrgIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != "")
        //    {
        //        landvo.storageWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString());
        //    }
        //    landvo.storageWaterPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != "")
        //    {
        //        landvo.storageWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString());
        //    }
        //    landvo.storageWaterPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != "")
        //    {
        //        landvo.storageWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString());
        //    }
        //    landvo.storageWaterPhase3Specified = true;
        //    landvo.storageWtrHosueId = 0;
        //    landvo.storageWtrHosueIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != "")
        //    {
        //        landvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString());
        //    }
        //    landvo.totalPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != "")
        //    {
        //        landvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString());
        //    }
        //    landvo.totalPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != "")
        //    {
        //        landvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString());
        //    }
        //    landvo.totalPhase3Specified = true;

        //    if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');
        //        TSIICLANDCGG.DateHolder commmercialpowersupply = new TSIICLANDCGG.DateHolder();

        //        commmercialpowersupply.day = newdate[0].ToString();
        //        commmercialpowersupply.displayDate = "";
        //        commmercialpowersupply.empty = true;
        //        commmercialpowersupply.emptySpecified = true;
        //        commmercialpowersupply.month = newdate[1].ToString();
        //        commmercialpowersupply.sqlDateStr = "";
        //        commmercialpowersupply.valid = true;
        //        commmercialpowersupply.validSpecified = true;
        //        commmercialpowersupply.year = newdate[2].ToString();
        //        electricityvo.commercialPhase1 = commmercialpowersupply;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder commmercialpowersupplyphase2 = new TSIICLANDCGG.DateHolder();
        //        commmercialpowersupplyphase2.day = newdate[0].ToString();
        //        commmercialpowersupplyphase2.displayDate = "";
        //        commmercialpowersupplyphase2.empty = true;
        //        commmercialpowersupplyphase2.emptySpecified = true;
        //        commmercialpowersupplyphase2.month = newdate[1].ToString();
        //        commmercialpowersupplyphase2.sqlDateStr = "";
        //        commmercialpowersupplyphase2.valid = true;
        //        commmercialpowersupplyphase2.validSpecified = true;
        //        commmercialpowersupplyphase2.year = newdate[2].ToString();
        //        electricityvo.commercialPhase2 = commmercialpowersupplyphase2;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder commmercialpowersupplyphase3 = new TSIICLANDCGG.DateHolder();
        //        commmercialpowersupplyphase3.day = newdate[0].ToString();
        //        commmercialpowersupplyphase3.displayDate = "";
        //        commmercialpowersupplyphase3.empty = true;
        //        commmercialpowersupplyphase3.emptySpecified = true;
        //        commmercialpowersupplyphase3.month = newdate[1].ToString();
        //        commmercialpowersupplyphase3.sqlDateStr = "";
        //        commmercialpowersupplyphase3.valid = true;
        //        commmercialpowersupplyphase3.validSpecified = true;
        //        commmercialpowersupplyphase3.year = newdate[2].ToString();
        //        electricityvo.commercialPhase3 = commmercialpowersupplyphase3;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != "")
        //    {
        //        electricityvo.connectedLoadPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString());
        //    }
        //    electricityvo.connectedLoadPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != "")
        //    {
        //        electricityvo.connectedLoadPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString());
        //    }
        //    electricityvo.connectedLoadPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != "")
        //    {
        //        electricityvo.connectedLoadPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString());
        //    }
        //    electricityvo.connectedLoadPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');



        //        TSIICLANDCGG.DateHolder constructionpowersupply = new TSIICLANDCGG.DateHolder();


        //        constructionpowersupply.day = newdate[0].ToString();
        //        constructionpowersupply.displayDate = "";
        //        constructionpowersupply.empty = true;
        //        constructionpowersupply.emptySpecified = true;
        //        constructionpowersupply.month = newdate[1].ToString();
        //        constructionpowersupply.sqlDateStr = "";
        //        constructionpowersupply.valid = true;
        //        constructionpowersupply.validSpecified = true;
        //        constructionpowersupply.year = newdate[2].ToString();
        //        electricityvo.constructionPhase1 = constructionpowersupply;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');


        //        TSIICLANDCGG.DateHolder constructionpowersupply2 = new TSIICLANDCGG.DateHolder();
        //        constructionpowersupply2.day = newdate[0].ToString();
        //        constructionpowersupply2.day = "";
        //        constructionpowersupply2.displayDate = "";
        //        constructionpowersupply2.empty = true;
        //        constructionpowersupply2.emptySpecified = true;
        //        constructionpowersupply2.month = newdate[1].ToString();
        //        constructionpowersupply2.sqlDateStr = "";
        //        constructionpowersupply2.valid = true;
        //        constructionpowersupply2.validSpecified = true;
        //        constructionpowersupply2.year = newdate[2].ToString();
        //        electricityvo.constructionPhase2 = constructionpowersupply2;
        //    }
        //    if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != null)
        //    {
        //        string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString().Split(' ');
        //        string[] newdate = date[0].ToString().Split('-');

        //        TSIICLANDCGG.DateHolder constructionpowersupply3 = new TSIICLANDCGG.DateHolder();

        //        constructionpowersupply3.day = newdate[0].ToString();

        //        constructionpowersupply3.displayDate = "";
        //        constructionpowersupply3.empty = true;
        //        constructionpowersupply3.emptySpecified = true;
        //        constructionpowersupply3.month = newdate[1].ToString();
        //        constructionpowersupply3.sqlDateStr = "";
        //        constructionpowersupply3.valid = true;
        //        constructionpowersupply3.validSpecified = true;
        //        constructionpowersupply3.year = newdate[2].ToString();
        //        electricityvo.constructionPhase3 = constructionpowersupply3;
        //    }
        //    if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != "")
        //    {
        //        electricityvo.contractDemandPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString());
        //    }
        //    electricityvo.contractDemandPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != "")
        //    {
        //        electricityvo.contractDemandPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString());
        //    }
        //    electricityvo.contractDemandPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != "")
        //    {
        //        electricityvo.contractDemandPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString());
        //    }
        //    electricityvo.contractDemandPhase3Specified = true;
        //    electricityvo.energySrcDGSet = GDs.Tables[2].Rows[0]["DGset"].ToString();
        //    electricityvo.energySrcGeneration = GDs.Tables[2].Rows[0]["owngeneration"].ToString();
        //    electricityvo.energySrcSupply = GDs.Tables[2].Rows[0]["TStranscosupply"].ToString();
        //    electricityvo.landId = 0;
        //    electricityvo.landIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != "")
        //    {
        //        electricityvo.loadFactorPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactor"].ToString());
        //    }
        //    electricityvo.loadFactorPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != "")
        //    {
        //        electricityvo.loadFactorPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString());
        //    }
        //    electricityvo.loadFactorPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != "")
        //    {
        //        electricityvo.loadFactorPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString());
        //    }
        //    electricityvo.loadFactorPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != "")
        //    {
        //        electricityvo.powerRequirementPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString());
        //    }
        //    electricityvo.powerRequirementPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != "")
        //    {
        //        electricityvo.powerRequirementPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString());
        //    }
        //    electricityvo.powerRequirementPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != "")
        //    {
        //        electricityvo.powerRequirementPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString());
        //    }
        //    electricityvo.powerRequirementPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != "")
        //    {
        //        electricityvo.powerSupplyPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString());
        //    }
        //    electricityvo.powerSupplyPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != "")
        //    {
        //        electricityvo.powerSupplyPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString());
        //    }
        //    electricityvo.powerSupplyPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != "")
        //    {
        //        electricityvo.powerSupplyPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString());
        //    }
        //    electricityvo.powerSupplyPhase3Specified = true;
        //    if (GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != "")
        //    {
        //        electricityvo.voltageRatingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString());
        //    }
        //    electricityvo.voltageRatingPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != "")
        //    {
        //        electricityvo.voltageRatingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString());
        //    }
        //    electricityvo.voltageRatingPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != "")
        //    {
        //        electricityvo.voltageRatingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString());
        //    }
        //    electricityvo.voltageRatingPhase3Specified = true;

        //    watervo.landId = 0;
        //    watervo.landIdSpecified = true;
        //    watervo.permtDomesticId = 0;
        //    watervo.permtDomesticIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != "")
        //    {
        //        watervo.permtDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString());
        //    }
        //    watervo.permtDomesticPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != "")
        //    {
        //        watervo.permtDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString());
        //    }
        //    watervo.permtDomesticPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != "")
        //    {
        //        watervo.permtDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString());
        //    }
        //    watervo.permtDomesticPhase3Specified = true;
        //    watervo.permtIndustrialId = 0;
        //    watervo.permtIndustrialIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != "")
        //    {
        //        watervo.permtIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString());
        //    }
        //    watervo.permtIndustrialPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != "")
        //    {
        //        watervo.permtIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString());
        //    }
        //    watervo.permtIndustrialPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != "")
        //    {
        //        watervo.permtIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString());
        //    }
        //    watervo.permtIndustrialPhase3Specified = true;
        //    watervo.tempDomesticId = 0;
        //    watervo.tempDomesticIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != "")
        //    {
        //        watervo.tempDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString());
        //    }
        //    watervo.tempDomesticPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != "")
        //    {
        //        watervo.tempDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString());
        //    }
        //    watervo.tempDomesticPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != "")
        //    {
        //        watervo.tempDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString());
        //    }
        //    watervo.tempDomesticPhase3Specified = true;
        //    watervo.tempIndustrialId = 0;
        //    watervo.tempIndustrialIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
        //    {
        //        watervo.tempIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReq"].ToString());
        //    }
        //    watervo.tempIndustrialPhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
        //    {
        //        watervo.tempIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString());
        //    }
        //    watervo.tempIndustrialPhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != "")
        //    {
        //        watervo.tempIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString());
        //    }
        //    watervo.tempIndustrialPhase3Specified = true;

        //    effluentsvo.disposalSystem = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
        //    effluentsvo.landId = 0;
        //    effluentsvo.landIdSpecified = true;
        //    if (GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() == "NIL" || GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() == "")
        //    {
        //        effluentsvo.quantityPhase1 = 0;
        //    }
        //    else
        //    {
        //        effluentsvo.quantityPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString());
        //    }
        //    effluentsvo.quantityPhase1Specified = true;


        //    if (GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() == null || GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() == "")
        //    {
        //        effluentsvo.quantityPhase2 = 0;
        //    }
        //    else
        //    {

        //        effluentsvo.quantityPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString());
        //    }
        //    effluentsvo.quantityPhase2Specified = true;

        //    if (GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() == null || GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() == "")
        //    {
        //        effluentsvo.quantityPhase3 = 0;
        //    }
        //    else
        //    {

        //        effluentsvo.quantityPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString());
        //    }
        //    effluentsvo.quantityPhase3Specified = true;
        //    effluentsvo.typeDescription = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
        //    if (GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != "")
        //    {
        //        effluentsvo.wastagePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString());
        //    }
        //    effluentsvo.wastagePhase1Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != "")
        //    {
        //        effluentsvo.wastagePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString());
        //    }
        //    effluentsvo.wastagePhase2Specified = true;
        //    if (GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != "")
        //    {
        //        effluentsvo.wastagePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString());
        //    }
        //    effluentsvo.wastagePhase3Specified = true;

        //}

        //if (GDs.Tables[3].Rows.Count > 0)
        //{
        //    //TSIICLANDCGG.DocumentCheckList documentCheckListvo = new TSIICLANDCGG.DocumentCheckList();

        //    DataTable dtceigdocuments = new DataTable();
        //    dtceigdocuments = GDs.Tables[3];
        //    for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
        //    {
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "1")
        //        {
        //            documentCheckListvo.detailedProject = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }

        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "2")
        //        {
        //            documentCheckListvo.enterpreneurMemorandum = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        //documentCheckListvo.
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "3")
        //        {
        //            documentCheckListvo.partnerShipDeed = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "4")
        //        {
        //            documentCheckListvo.shareHolderDetails = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "5")
        //        {
        //            documentCheckListvo.plantLayout = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "6")
        //        {
        //            documentCheckListvo.casteCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "7")
        //        {
        //            documentCheckListvo.addressProof = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "8")
        //        {
        //            documentCheckListvo.panCard = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "9")
        //        {
        //            documentCheckListvo.photoGraph = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "10")
        //        {
        //            documentCheckListvo.financeCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "11")
        //        {
        //            documentCheckListvo.paymentReceipt = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "12")
        //        {
        //            documentCheckListvo.gstCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "13")
        //        {
        //            documentCheckListvo.otherDocument = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "14")
        //        {
        //            projectFinancialvo.workingSheet = dtceigdocuments.Rows[n]["Filepath"].ToString();
        //        }
        //        if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "15")
        //        {

        //            projectMaterialManufacturingvo.fileName = dtceigdocuments.Rows[n]["Filepath"].ToString();

        //        }
        //        else
        //        {

        //            projectMaterialManufacturingvo.fileName = GDs.Tables[2].Rows[0]["filepath"].ToString();
        //        }


        //    }
        //}


        //TSIICLANDCGG.AdditionalPromoter[] additionalPromotervo = null;// new TSIICLANDCGG.AdditionalPromoter();

        ////new TSIICLANDCGG.AdditionalPromoter();
        //if (GDs.Tables[4].Rows.Count > 0)
        //{
        //    TSIICLANDCGG.AdditionalPromoter[] AdditionalPromotervo = null;
        //    DataTable dtraw = new DataTable();
        //    dtraw = GDs.Tables[4];
        //    AdditionalPromotervo = new TSIICLANDCGG.AdditionalPromoter[dtraw.Rows.Count];

        //    for (int k = 0; k < dtraw.Rows.Count; k++)
        //    {
        //        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
        //        TSIICLANDCGG.AdditionalPromoter coc = new TSIICLANDCGG.AdditionalPromoter();
        //        coc.additionalPromoterId = 0;// Convert.ToInt32(dtraw.Rows[k]["0"]);
        //        coc.additionalPromoterIdSpecified = false;// Convert.ToBoolean(dtraw.Rows[k]["false"]);
        //        if (dtraw.Rows[k]["Experience"].ToString() != null && dtraw.Rows[k]["Experience"].ToString() != "")
        //        {
        //            coc.experience = Convert.ToDouble(dtraw.Rows[k]["Experience"].ToString());
        //        }
        //        coc.experienceSpecified = true;
        //        coc.name = dtraw.Rows[k]["Name"].ToString();
        //        coc.netWorthSpecified = true;
        //        //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
        //        coc.netWorth = Convert.ToInt32(dtraw.Rows[k]["Networth"]);
        //        coc.qualification = dtraw.Rows[k]["Qualification"].ToString();
        //        coc.contactNo = dtraw.Rows[k]["ContactNo"].ToString();
        //        coc.address = dtraw.Rows[k]["Address"].ToString();
        //        AdditionalPromotervo[k] = coc;
        //        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
        //        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
        //    }
        //    additionalPromotervo = AdditionalPromotervo;

        //}
        //if (GDs.Tables[5].Rows.Count > 0)
        //{

        //    registraionvo.companyAddress = "";
        //    registraionvo.companyAreaCode = "";
        //    registraionvo.companyName = "";
        //    registraionvo.companyPhone = "";
        //    registraionvo.emailId = GDs.Tables[5].Rows[0]["Email"].ToString();
        //    registraionvo.firstName = GDs.Tables[5].Rows[0]["Firstname"].ToString();
        //    registraionvo.ipassRegistrationId = Convert.ToInt64(GDs.Tables[5].Rows[0]["INTUSERID"].ToString());
        //    registraionvo.ipassRegistrationIdSpecified = true;
        //    registraionvo.mobile = GDs.Tables[5].Rows[0]["MobileNo"].ToString();
        //    registraionvo.password = "";
        //    registraionvo.surname = GDs.Tables[5].Rows[0]["Lastname"].ToString();
        //}
        //if (GDs.Tables[6].Rows.Count > 0)
        //{

        //    //paymentDetailsvo.area = "61169.00";
        //    paymentDetailsvo.bankReferenceNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();


        //    paymentDetailsvo.customerReferenceNumber = GDs.Tables[6].Rows[0]["UIDNO"].ToString();
        //    paymentDetailsvo.dateAndTime = "";
        //    paymentDetailsvo.emd = "";
        //    paymentDetailsvo.gstNumber = GDs.Tables[2].Rows[0]["GSTNumber"].ToString();
        //    paymentDetailsvo.gstRegesterd = "";
        //    paymentDetailsvo.industrialPark = "";
        //    paymentDetailsvo.landCost = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
        //    paymentDetailsvo.landCostSpecified = true;
        //    paymentDetailsvo.paidAmount = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
        //    paymentDetailsvo.paidAmountSpecified = true;
        //    paymentDetailsvo.paymentMode = "Online";
        //    //paymentDetailsvo.processFee = "";
        //    paymentDetailsvo.referenceId = GDs.Tables[6].Rows[0]["OnlineOrderNo"].ToString();
        //    paymentDetailsvo.remarks = "";
        //    //paymentDetailsvo.sgst = "";
        //    paymentDetailsvo.statusCode = "";
        //    paymentDetailsvo.transactionNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();
        //    paymentDetailsvo.dateAndTime = GDs.Tables[6].Rows[0]["Transactiondatetime"].ToString();
        //}

        //if (GDs.Tables[10].Rows.Count > 0)
        //{
        //    paymentDetailsvo.area = GDs.Tables[10].Rows[0]["PlotTotalArea"].ToString();
        //    paymentDetailsvo.cgst = GDs.Tables[10].Rows[0]["CGST"].ToString();
        //    paymentDetailsvo.sgst = GDs.Tables[10].Rows[0]["SGST"].ToString();
        //    paymentDetailsvo.processFee = GDs.Tables[10].Rows[0]["ProcessFee"].ToString();
        //    paymentDetailsvo.emd = GDs.Tables[10].Rows[0]["TotalEmd"].ToString();

        //}

        //if (GDs.Tables[2].Rows.Count > 0)
        //{

        //    paymentDetailsvo.account_branch = GDs.Tables[2].Rows[0]["BranchName"].ToString();
        //    paymentDetailsvo.account_ifsc = GDs.Tables[2].Rows[0]["Ifsccode"].ToString();
        //    paymentDetailsvo.account_name = GDs.Tables[2].Rows[0]["AccountHolderName"].ToString();
        //    paymentDetailsvo.account_no = GDs.Tables[2].Rows[0]["AccountNo"].ToString();
        //    paymentDetailsvo.account_type = GDs.Tables[2].Rows[0]["TypeofAccount"].ToString();
        //    paymentDetailsvo.bank_name = GDs.Tables[2].Rows[0]["BankName"].ToString();
        //}

        //string useroutput = landservice.registerUser(registraionvo);
        //string output = landservice.saveApplicationDetails(plotvo, intuserid, appid, verifyFirmvo, promoterDetailsvo, additionalPromotervo, projectGeneralvo, projectFinancialvo,
        //      projectEmploymentvo, projectMaterialManufacturingvo, projectPlantMachineryvo, landvo, electricityvo, watervo, effluentsvo, paymentDetailsvo, documentCheckListvo);
        //if (output == "Applications details are saved successfully....")
        //{
        //    Gen.UpdateDepartwebserviceflagtsiic(appid.ToString(), "3", "C", "Y", output);

        //}
        //else
        //{
        //    Gen.UpdateDepartwebserviceflagtsiic(appid.ToString(), "3", "C", "N", output);
        //}




    }


    public DataSet tsiicdetailsdata(int createdby, int applicationid)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@createdby",SqlDbType.Int),
                  new SqlParameter("@Appid",SqlDbType.Int),
                };
            p[0].Value = createdby;
            p[1].Value = applicationid;

            // XmlDocument doc = new XmlDocument(); USP_GET_RM_ABSTRACTDETAILS
            GDs = Gen.GenericFillDs("USP_GET_TSIICDETAILS", p);
            GDs.Tables[0].TableName = "tsiicplotallotmentmain";
            GDs.Tables[1].TableName = "tsiicplotallotmentdetails";
            GDs.Tables[2].TableName = "tsiicapplicantdetails";
            GDs.Tables[3].TableName = "TSIICAttachments";
            GDs.Tables[4].TableName = "AdditionalPromoterdetails";
            GDs.Tables[5].TableName = "UserRegisterationDetails";
            GDs.Tables[6].TableName = "PaymentDetails";
            GDs.Tables[7].TableName = "ProductDetails";
            GDs.Tables[8].TableName = "RawmaterialDetails";
            GDs.Tables[9].TableName = "PlantMachineryDetails";
            GDs.Tables[10].TableName = "PlotpaymentDetails";

            return GDs;
        }
        catch (Exception ex)
        {
            throw ex;
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, HttpContext.Current.Session["uid"].ToString());
        }
    }





}