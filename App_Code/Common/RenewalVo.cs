using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RenewalVo
/// </summary>
/// 
[Serializable]
public class RenewalVo
{
    #region Labour
    public int Intenterprenurid;
    public string uidno;
    public int stageid;
    public string renewalCaseType;
    public string ClassificationofEstablishment;
    public string CategoryofEstablishments;
    public string Natureofbusiness;
    public string actID;
    public int compound_fee;
    public string employer_age;
    public string employer_agent_so_do_wo;
    public string employer_email;
    public string employer_mobile;
    public string employer_name;
    public string employer_permanent_door;
    public string employer_permanent_locality;
    public string employer_permanent_pincode;
    public string establishment_name;
    public string establishment_postal_district;
    public string establishment_postal_mandal;
    public string establishment_postal_village;
    public string establishment_postal_door;
    public string establishment_postal_locality;
    public string establishment_postal_pincode;
    public string manager_agent_age;
    public string manager_agent_name;
    public string manager_agent_so_do_wo;
    public string max_employees_aday;
    public int newPenalityAmount2017;
    public int newPenalityYears2017;
    public int newRegistrationAmount2017;
    public int newRegistrationYears2017;
    public int oldPenalityAmount2016;
    public int oldPenalityYears2016;
    public int oldRegistrationAmount2016;
    public int oldRegistrationYears2016;
    public int penality_percentage;
    public int penality_years;
    public string previous_certificate_valid_from;
    public string previous_certificate_valid_to;
    public string previous_registration_no;
    public int registration_fee;
    public int registration_years;
    public bool renewalExpired;
    public int total_amount_payable;
    public int total_penality_amount;
    public int total_registration_fee;
    public string totalAmount;
    public int unpaid_balance_welfare;
    public string valid_from_date;
    public string valid_to_date;
    public int AdultMale;
    public int AdultFemale;
    public int YoungMale;
    public int YoungFemale;
    public int TotalAdult;
    public int TotalYoung;
    public string Created_by;
    public string Dateofcommencement;
    public string manager_agent_Mobile;
    public string manager_agent_Email;
    public string previous_Renewaldate;
    public string previous_RenewalYear;
    public string employer_district;
    public string employer_mandal;
    public string employer_village;
    public string entrepreneur_id;
    public string establishment_category_others;
    public string manager_agent_designation;
    public string manager_agent_district;
    public string manager_agent_door;
    public string manager_agent_locality;
    public string manager_agent_mandal;
    public string manager_agent_street;
    public string manager_agent_village;
    public string nature_work;
    public string other_attachement_1;
    public string other_attachement_2;
    public string other_attachement_3;
    public string other_attachement_4;
    public string payment_mode;
    public string paymentFlag;
    public string previous_certificate_from;
    public string previous_certificate_to;
    public string previous_registration_certificate;
    public string previous_registration_year;
    public string projectSubmitDate;
    public int questionnaire_id;
    public string stageID;
    public string total_adults;
    public string total_young;
    public string transaction_for;
    public string transaction_id;
    public string transaction_status;
    public string transactionDate;
    public string transactionNumber;
    public string tsipassApplicationID;
    public string type_of_application;
    //public string Questionnaireid;

    #endregion

    #region factory
    public string annualLicenceFee;
    public string arrearsAmount;
    public string factoryAddress;
    public string factoryCircleID;
    public string factoryCircleName;
    public string factoryHP;
    public string factoryLicenseNumber;
    public string factoryName;
    public string factoryNumberOfEmployees;
    public string factoryRegistrationNumber;
    public string interestOnAnnualLicenceFee;
    public string interestOnArrearsAmount;
    public string licenceValidFrom;
    public string licenceValidUpto;
    public string selectedCalendarYear;
    public string selectedNumberOfLicenseYears;
    public string status;
    public string totalFee;
    public string regid;
    public string totalamount;
    public string intStageid;
    #endregion

    public RenewalVo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}