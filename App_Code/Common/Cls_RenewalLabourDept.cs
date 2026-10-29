using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Cls_RenewalLabourDept
/// </summary>
public class Cls_RenewalLabourDept
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    public Cls_RenewalLabourDept()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Insert_Contractlabourrenwal(contractLicenceActRenewalCheckVo objpar_labourcontractrenewal)
    {
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Insert_Contractlabourrenwal";

            if (objpar_labourcontractrenewal.name_pe.Trim() == "" || objpar_labourcontractrenewal.name_pe.Trim() == null)
                com.Parameters.Add("@name_pe", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@name_pe", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.name_pe.Trim();
            if (objpar_labourcontractrenewal.max_contract_labour.Trim() == "" || objpar_labourcontractrenewal.max_contract_labour.Trim() == null)
                com.Parameters.Add("@max_contract_labour", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@max_contract_labour", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.max_contract_labour.Trim();

            if (objpar_labourcontractrenewal.application_code.Trim() == "" || objpar_labourcontractrenewal.application_code.Trim() == null)
                com.Parameters.Add("@application_code  ", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@application_code", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.application_code.Trim();

            if (objpar_labourcontractrenewal.contractor_name.Trim() == "" || objpar_labourcontractrenewal.contractor_name.Trim() == null)
                com.Parameters.Add("@contractor_name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@contractor_name", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.contractor_name.Trim();

            if (objpar_labourcontractrenewal.licence_num.Trim() == "" || objpar_labourcontractrenewal.licence_num.Trim() == null)
                com.Parameters.Add("@licence_num", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@licence_num", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.licence_num.Trim();

            if (objpar_labourcontractrenewal.expiry_date == "" || objpar_labourcontractrenewal.expiry_date == null)
                com.Parameters.Add("@expiry_date", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@expiry_date", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.expiry_date.Trim();
            if (objpar_labourcontractrenewal.worksiteDoorNo.Trim() == "" || objpar_labourcontractrenewal.worksiteDoorNo.Trim() == null)
                com.Parameters.Add("@worksiteDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksiteDoorNo", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteDoorNo.Trim();

            if (objpar_labourcontractrenewal.worksiteLocality.Trim() == "" || objpar_labourcontractrenewal.worksiteLocality.Trim() == null)
                com.Parameters.Add("@worksiteLocality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksiteLocality", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteLocality.Trim();

            if (objpar_labourcontractrenewal.worksiteDistrict.Trim() == "" || objpar_labourcontractrenewal.worksiteDistrict.Trim() == null)
                com.Parameters.Add("@worksiteDistrict   ", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksiteDistrict", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteDistrict.Trim();

            if (objpar_labourcontractrenewal.worksiteMandal.Trim() == "" || objpar_labourcontractrenewal.worksiteMandal.Trim() == null)
                com.Parameters.Add("@worksiteMandal ", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksiteMandal", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteMandal.Trim();

            if (objpar_labourcontractrenewal.worksiteVillage.Trim() == "" || objpar_labourcontractrenewal.worksiteVillage.Trim() == null)
                com.Parameters.Add("@worksiteVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksiteVillage", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteVillage.Trim();

            if (objpar_labourcontractrenewal.worksitePinNo.Trim() == "" || objpar_labourcontractrenewal.worksitePinNo.Trim() == null)
                com.Parameters.Add("@worksitePinNo", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksitePinNo.Trim();
            else
                com.Parameters.Add("@worksitePinNo    ", SqlDbType.VarChar).Value = DBNull.Value;
            if (objpar_labourcontractrenewal.nature_of_work.Trim() == "" || objpar_labourcontractrenewal.nature_of_work.Trim() == null)
                com.Parameters.Add("@nature_of_work", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@nature_of_work", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.nature_of_work.Trim();

            if (objpar_labourcontractrenewal.act.Trim() == "" || objpar_labourcontractrenewal.act.Trim() == null)
                com.Parameters.Add("@act", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@act", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.act.Trim();



            if (string.IsNullOrEmpty(objpar_labourcontractrenewal.payment_mode.Trim()) && objpar_labourcontractrenewal.amount.Trim() == "" && objpar_labourcontractrenewal.amount.Trim() == null)
                com.Parameters.Add("@payment_mode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@payment_mode", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.payment_mode.Trim();

            if (objpar_labourcontractrenewal.amount.Trim() == "" || objpar_labourcontractrenewal.amount.Trim() == null)
                com.Parameters.Add("@amount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@amount", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.amount.Trim();

            if (objpar_labourcontractrenewal.bank_code.Trim() == "" || objpar_labourcontractrenewal.bank_code.Trim() == null)
                com.Parameters.Add("@bank_code", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@bank_code", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.bank_code.Trim();

            if (objpar_labourcontractrenewal.CreatedBy.Trim() == "" || objpar_labourcontractrenewal.CreatedBy.Trim() == null)
                com.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.CreatedBy.Trim();

            if (objpar_labourcontractrenewal.CreatedIP.Trim() == "" || objpar_labourcontractrenewal.CreatedIP.Trim() == null)
                com.Parameters.Add("@CreatedIP  ", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.CreatedIP.Trim();
            if (objpar_labourcontractrenewal.CLCAFPID.Trim() == "" || objpar_labourcontractrenewal.CLCAFPID.Trim() == null)
                com.Parameters.Add("@CLCAFPID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@CLCAFPID", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.CLCAFPID.Trim();
            if (objpar_labourcontractrenewal.intQuessionaireid.Trim() == "" || objpar_labourcontractrenewal.intQuessionaireid.Trim() == null)
                com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.intQuessionaireid.Trim();
            if (objpar_labourcontractrenewal.actID.Trim() == "" || objpar_labourcontractrenewal.actID.Trim() == null)
                com.Parameters.Add("@actID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@actID", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.actID.Trim();

            if (objpar_labourcontractrenewal.bank_ref_number.Trim() == "" || objpar_labourcontractrenewal.bank_ref_number.Trim() == null)
                com.Parameters.Add("@bank_ref_number", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@bank_ref_number", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.bank_ref_number.Trim();
            if (objpar_labourcontractrenewal.bankName.Trim() == "" || objpar_labourcontractrenewal.bankName.Trim() == null)
                com.Parameters.Add("@bankName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@bankName", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.bankName.Trim();
            if (objpar_labourcontractrenewal.cin.Trim() == "" || objpar_labourcontractrenewal.cin.Trim() == null)
                com.Parameters.Add("@cin", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@cin", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.cin.Trim();
            if (objpar_labourcontractrenewal.compound_fee.Trim() == "" || objpar_labourcontractrenewal.compound_fee.Trim() == null)
                com.Parameters.Add("@compound_fee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@compound_fee", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.compound_fee.Trim();
            if (objpar_labourcontractrenewal.contractor_email.Trim() == "" || objpar_labourcontractrenewal.contractor_email.Trim() == null)
                com.Parameters.Add("@contractor_email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@contractor_email", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.contractor_email.Trim();
            if (objpar_labourcontractrenewal.contractor_mobile.Trim() == "" || objpar_labourcontractrenewal.contractor_mobile.Trim() == null)
                com.Parameters.Add("@contractor_mobile", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@contractor_mobile", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.contractor_mobile.Trim();
            if (objpar_labourcontractrenewal.entrepreneur_id.Trim() == "" || objpar_labourcontractrenewal.entrepreneur_id.Trim() == null)
                com.Parameters.Add("@entrepreneur_id", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@entrepreneur_id", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.entrepreneur_id.Trim();
            if (objpar_labourcontractrenewal.establishment_name.Trim() == "" || objpar_labourcontractrenewal.establishment_name.Trim() == null)
                com.Parameters.Add("@establishment_name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_name", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_name.Trim();
            if (objpar_labourcontractrenewal.establishment_otherstate_address.Trim() == "" || objpar_labourcontractrenewal.establishment_otherstate_address.Trim() == null)
                com.Parameters.Add("@establishment_otherstate_address", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_otherstate_address", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_otherstate_address.Trim();
            if (objpar_labourcontractrenewal.establishment_postal_district.Trim() == "" || objpar_labourcontractrenewal.establishment_postal_district.Trim() == null)
                com.Parameters.Add("@establishment_postal_district", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_postal_district", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_postal_district.Trim();
            if (objpar_labourcontractrenewal.establishment_postal_door.Trim() == "" || objpar_labourcontractrenewal.establishment_postal_door.Trim() == null)
                com.Parameters.Add("@establishment_postal_door", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_postal_door", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_postal_door.Trim();

            if (objpar_labourcontractrenewal.establishment_postal_locality.Trim() == "" || objpar_labourcontractrenewal.establishment_postal_locality.Trim() == null)
                com.Parameters.Add("@establishment_postal_locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_postal_locality", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_postal_locality.Trim();
            if (objpar_labourcontractrenewal.establishment_postal_mandal.Trim() == "" || objpar_labourcontractrenewal.establishment_postal_mandal.Trim() == null)
                com.Parameters.Add("@establishment_postal_mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_postal_mandal", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_postal_mandal.Trim();

            if (objpar_labourcontractrenewal.establishment_postal_village.Trim() == "" || objpar_labourcontractrenewal.establishment_postal_village.Trim() == null)
                com.Parameters.Add("@establishment_postal_village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_postal_village", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_postal_village.Trim();

            if (objpar_labourcontractrenewal.establishment_postal_pincode.Trim() == "" || objpar_labourcontractrenewal.establishment_postal_pincode.Trim() == null)
                com.Parameters.Add("@establishment_postal_pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@establishment_postal_pincode", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.establishment_postal_pincode.Trim();
            if (objpar_labourcontractrenewal.max_employees_aday.Trim() == "" || objpar_labourcontractrenewal.max_employees_aday.Trim() == null)
                com.Parameters.Add("@max_employees_aday", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@max_employees_aday", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.max_employees_aday.Trim();
            if (objpar_labourcontractrenewal.nature_work.Trim() == "" || objpar_labourcontractrenewal.nature_work.Trim() == null)
                com.Parameters.Add("@nature_work", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@nature_work", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.nature_work.Trim();
            if (objpar_labourcontractrenewal.paymentFlag.Trim() == "" || objpar_labourcontractrenewal.paymentFlag.Trim() == null)
                com.Parameters.Add("@paymentFlag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@paymentFlag", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.paymentFlag.Trim();
            if (objpar_labourcontractrenewal.penality_percentage.Trim() == "" || objpar_labourcontractrenewal.penality_percentage.Trim() == null)
                com.Parameters.Add("@penality_percentage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@penality_percentage", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.penality_percentage.Trim();
            if (objpar_labourcontractrenewal.penality_years.Trim() == "" || objpar_labourcontractrenewal.penality_years.Trim() == null)
                com.Parameters.Add("@penality_years", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@penality_years", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.penality_years.Trim();
            if (objpar_labourcontractrenewal.previous_registration_no.Trim() == "" || objpar_labourcontractrenewal.previous_registration_no.Trim() == null)
                com.Parameters.Add("@previous_registration_no", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@previous_registration_no", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.previous_registration_no.Trim();

            if (objpar_labourcontractrenewal.principal_employer_name.Trim() == "" || objpar_labourcontractrenewal.principal_employer_name.Trim() == null)
                com.Parameters.Add("@principal_employer_name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@principal_employer_name", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.principal_employer_name.Trim();
            if (objpar_labourcontractrenewal.projectSubmitDate.Trim() == "" || objpar_labourcontractrenewal.projectSubmitDate.Trim() == null)
                com.Parameters.Add("@projectSubmitDate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@projectSubmitDate", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.projectSubmitDate.Trim();
            if (objpar_labourcontractrenewal.questionnaire_id.Trim() == "" || objpar_labourcontractrenewal.questionnaire_id.Trim() == null)
                com.Parameters.Add("@questionnaire_id", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@questionnaire_id", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.questionnaire_id.Trim();

            if (objpar_labourcontractrenewal.registration_fee.Trim() == "" || objpar_labourcontractrenewal.registration_fee.Trim() == null)
                com.Parameters.Add("@registration_fee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@registration_fee", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.registration_fee.Trim();

            if (objpar_labourcontractrenewal.registration_years.Trim() == "" || objpar_labourcontractrenewal.registration_years.Trim() == null)
                com.Parameters.Add("@registration_years", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@registration_years", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.registration_years.Trim();

            if (objpar_labourcontractrenewal.renewalCaseType.Trim() == "" || objpar_labourcontractrenewal.renewalCaseType.Trim() == null)
                com.Parameters.Add("@renewalCaseType", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@renewalCaseType", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.renewalCaseType.Trim();

            if (objpar_labourcontractrenewal.stageID.Trim() == "" || objpar_labourcontractrenewal.stageID.Trim() == null)
                com.Parameters.Add("@stageID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@stageID", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.stageID.Trim();

            if (objpar_labourcontractrenewal.total_amount_payable.Trim() == "" || objpar_labourcontractrenewal.total_amount_payable.Trim() == null)
                com.Parameters.Add("@total_amount_payable", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@total_amount_payable", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.total_amount_payable.Trim();
            if (objpar_labourcontractrenewal.total_penality_amount.Trim() == "" || objpar_labourcontractrenewal.total_penality_amount.Trim() == null)
                com.Parameters.Add("@total_penality_amount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@total_penality_amount", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.total_penality_amount.Trim();
            if (objpar_labourcontractrenewal.total_registration_fee.Trim() == "" || objpar_labourcontractrenewal.total_registration_fee.Trim() == null)
                com.Parameters.Add("@total_registration_fee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@total_registration_fee", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.total_registration_fee.Trim();

            if (objpar_labourcontractrenewal.totalAmount.Trim() == "" || objpar_labourcontractrenewal.totalAmount.Trim() == null)
                com.Parameters.Add("@totalAmount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@totalAmount", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.totalAmount.Trim();

            if (objpar_labourcontractrenewal.transaction_for.Trim() == "" || objpar_labourcontractrenewal.transaction_for.Trim() == null)
                com.Parameters.Add("@transaction_for", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@transaction_for", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.transaction_for.Trim();
            if (objpar_labourcontractrenewal.transaction_id.Trim() == "" || objpar_labourcontractrenewal.transaction_id.Trim() == null)
                com.Parameters.Add("@transaction_id", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@transaction_id", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.transaction_id.Trim();
            if (objpar_labourcontractrenewal.transaction_status.Trim() == "" || objpar_labourcontractrenewal.transaction_status.Trim() == null)
                com.Parameters.Add("@transaction_status", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@transaction_status", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.transaction_status.Trim();
            if (objpar_labourcontractrenewal.transactionDate.Trim() == "" || objpar_labourcontractrenewal.transactionDate.Trim() == null)
                com.Parameters.Add("@transactionDate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@transactionDate", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.transactionDate.Trim();
            if (objpar_labourcontractrenewal.transactionNumber.Trim() == "" || objpar_labourcontractrenewal.transactionNumber.Trim() == null)
                com.Parameters.Add("@transactionNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@transactionNumber", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.transactionNumber.Trim();
            if (objpar_labourcontractrenewal.type_of_application.Trim() == "" || objpar_labourcontractrenewal.type_of_application.Trim() == null)
                com.Parameters.Add("@type_of_application", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@type_of_application", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.type_of_application.Trim();

            if (objpar_labourcontractrenewal.uID.Trim() == "" || objpar_labourcontractrenewal.uID.Trim() == null)
                com.Parameters.Add("@uID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@uID", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.uID.Trim();
            if (objpar_labourcontractrenewal.unpaid_balance_welfare.Trim() == "" || objpar_labourcontractrenewal.unpaid_balance_welfare.Trim() == null)
                com.Parameters.Add("@unpaid_balance_welfare", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@unpaid_balance_welfare", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.unpaid_balance_welfare.Trim();
            if (objpar_labourcontractrenewal.valid_from_date.Trim() == "" || objpar_labourcontractrenewal.valid_from_date.Trim() == null)
                com.Parameters.Add("@valid_from_date", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@valid_from_date", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.valid_from_date.Trim();

            if (objpar_labourcontractrenewal.valid_to_date.Trim() == "" || objpar_labourcontractrenewal.valid_to_date.Trim() == null)
                com.Parameters.Add("@valid_to_date", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@valid_to_date", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.valid_to_date.Trim();
            if (objpar_labourcontractrenewal.date_commencement.Trim() == "" || objpar_labourcontractrenewal.date_commencement.Trim() == null)
                com.Parameters.Add("@date_commencement", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@date_commencement", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.date_commencement.Trim();
            if (objpar_labourcontractrenewal.date_ending.Trim() == "" || objpar_labourcontractrenewal.date_ending.Trim() == null)
                com.Parameters.Add("@date_ending", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@date_ending", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.date_ending.Trim();
            if (objpar_labourcontractrenewal.previous_certificate_valid_from.Trim() == "" || objpar_labourcontractrenewal.previous_certificate_valid_from.Trim() == null)
                com.Parameters.Add("@previous_certificate_valid_from", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@previous_certificate_valid_from", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.previous_certificate_valid_from.Trim();
            if (objpar_labourcontractrenewal.previous_certificate_valid_to.Trim() == "" || objpar_labourcontractrenewal.previous_certificate_valid_to.Trim() == null)
                com.Parameters.Add("@previous_certificate_valid_to", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@previous_certificate_valid_to", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.previous_certificate_valid_to.Trim();
            if (objpar_labourcontractrenewal.previous_registered_act.Trim() == "" || objpar_labourcontractrenewal.previous_registered_act.Trim() == null)
                com.Parameters.Add("@previous_registered_act", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@previous_registered_act", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.previous_registered_act.Trim();

            if (objpar_labourcontractrenewal.previous_registration_certificate.Trim() == "" || objpar_labourcontractrenewal.previous_registration_certificate.Trim() == null)
                com.Parameters.Add("@previous_registration_certificate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@previous_registration_certificate", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.previous_registration_certificate.Trim();

            if (objpar_labourcontractrenewal.principal_employees.Trim() == "" || objpar_labourcontractrenewal.principal_employees.Trim() == null)
                com.Parameters.Add("@principal_employees", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@principal_employees", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.principal_employees.Trim();

            if (objpar_labourcontractrenewal.worksite_district.Trim() == "" || objpar_labourcontractrenewal.worksite_district.Trim() == null)
                com.Parameters.Add("@worksite_district", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_district", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_district.Trim();
            if (objpar_labourcontractrenewal.worksite_door.Trim() == "" || objpar_labourcontractrenewal.worksite_door.Trim() == null)
                com.Parameters.Add("@worksite_door", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_door", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_door.Trim();

            if (objpar_labourcontractrenewal.worksite_locality.Trim() == "" || objpar_labourcontractrenewal.worksite_locality.Trim() == null)
                com.Parameters.Add("@worksite_locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_locality", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_locality.Trim();
            if (objpar_labourcontractrenewal.worksite_mandal.Trim() == "" || objpar_labourcontractrenewal.worksite_mandal.Trim() == null)
                com.Parameters.Add("@worksite_mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_mandal", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_mandal.Trim();
            if (objpar_labourcontractrenewal.worksite_name.Trim() == "" || objpar_labourcontractrenewal.worksite_name.Trim() == null)
                com.Parameters.Add("@worksite_name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_name", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_name.Trim();
            if (objpar_labourcontractrenewal.worksite_pincode.Trim() == "" || objpar_labourcontractrenewal.worksite_pincode.Trim() == null)
                com.Parameters.Add("@worksite_pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_pincode", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_pincode.Trim();
            if (objpar_labourcontractrenewal.worksite_village.Trim() == "" || objpar_labourcontractrenewal.worksite_village.Trim() == null)
                com.Parameters.Add("@worksite_village ", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@worksite_village", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksite_village.Trim();

            if (string.IsNullOrWhiteSpace(objpar_labourcontractrenewal.user_serial_no.Trim()) || objpar_labourcontractrenewal.user_serial_no.Trim() == "" || objpar_labourcontractrenewal.user_serial_no.Trim() == null)
                com.Parameters.Add("@user_serial_no", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@user_serial_no", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.user_serial_no.Trim();

            #region
            //if (objpar_labourcontractrenewal.name_pe.Trim() == "" || objpar_labourcontractrenewal.name_pe.Trim() == null)
            //    com.Parameters.Add("@name_pe", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@name_pe", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.name_pe.Trim();
            //if (objpar_labourcontractrenewal.max_contract_labour.Trim() == "" || objpar_labourcontractrenewal.max_contract_labour.Trim() == null)
            //    com.Parameters.Add("@max_contract_labour", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@max_contract_labour", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.max_contract_labour.Trim();

            //if (objpar_labourcontractrenewal.application_code.Trim() == "" || objpar_labourcontractrenewal.application_code.Trim() == null)
            //    com.Parameters.Add("@application_code", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@application_code", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.application_code.Trim();

            //if (objpar_labourcontractrenewal.contractor_name.Trim() == "" || objpar_labourcontractrenewal.contractor_name.Trim() == null)
            //    com.Parameters.Add("@contractor_name", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@contractor_name", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.contractor_name.Trim();
            //if (objpar_labourcontractrenewal.licence_num.Trim() == "" || objpar_labourcontractrenewal.licence_num.Trim() == null)
            //    com.Parameters.Add("@licence_num", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@licence_num", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.licence_num.Trim();
            //if (Convert.ToString(objpar_labourcontractrenewal.expiry_date) == "" || objpar_labourcontractrenewal.expiry_date == null)
            //    com.Parameters.Add("@expiry_date", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@expiry_date", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.expiry_date;

            //if (objpar_labourcontractrenewal.worksiteDoorNo.Trim() == "" || objpar_labourcontractrenewal.worksiteDoorNo.Trim() == null)
            //    com.Parameters.Add("@worksiteDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@worksiteDoorNo", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteDoorNo.Trim();

            //if (objpar_labourcontractrenewal.worksiteLocality.Trim() == "" || objpar_labourcontractrenewal.worksiteLocality.Trim() == null)
            //    com.Parameters.Add("@worksiteLocality", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@worksiteLocality", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteLocality.Trim();

            //if (objpar_labourcontractrenewal.worksiteDistrict.Trim() == "" || objpar_labourcontractrenewal.worksiteDistrict.Trim() == null)
            //    com.Parameters.Add("@worksiteDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@worksiteDistrict", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteDistrict.Trim();

            //if (objpar_labourcontractrenewal.worksiteMandal.Trim() == "" || objpar_labourcontractrenewal.worksiteMandal.Trim() == null)
            //    com.Parameters.Add("@worksiteMandal", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@worksiteMandal", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteMandal.Trim();

            //if (objpar_labourcontractrenewal.worksiteVillage.Trim() == "" || objpar_labourcontractrenewal.worksiteVillage.Trim() == null)
            //    com.Parameters.Add("@worksiteVillage", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@worksiteVillage", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksiteVillage.Trim();

            //if (objpar_labourcontractrenewal.worksitePinNo.Trim() == "" || objpar_labourcontractrenewal.worksitePinNo.Trim() == null)
            //    com.Parameters.Add("@worksitePinNo", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@worksitePinNo", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.worksitePinNo.Trim();

            //if (objpar_labourcontractrenewal.nature_of_work.Trim() == "" || objpar_labourcontractrenewal.nature_of_work.Trim() == null)
            //    com.Parameters.Add("@nature_of_work", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@nature_of_work", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.nature_of_work.Trim();

            //if (objpar_labourcontractrenewal.act.Trim() == "" || objpar_labourcontractrenewal.act.Trim() == null)
            //    com.Parameters.Add("@act", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@act", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.act.Trim();

            //if (Convert.ToString(objpar_labourcontractrenewal.user_serial_no).Trim() == "" || Convert.ToString(objpar_labourcontractrenewal.user_serial_no).Trim() == null)
            //    com.Parameters.Add("@user_serial_no", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@user_serial_no", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.user_serial_no;

            //if (objpar_labourcontractrenewal.payment_mode.Trim() == "" || objpar_labourcontractrenewal.payment_mode.Trim() == null)
            //    com.Parameters.Add("@payment_mode", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@payment_mode", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.payment_mode.Trim();

            //if (objpar_labourcontractrenewal.amount.Trim() == "" || objpar_labourcontractrenewal.amount.Trim() == null)
            //    com.Parameters.Add("@amount", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@amount", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.amount.Trim();

            //if (objpar_labourcontractrenewal.bank_code.Trim() == "" || objpar_labourcontractrenewal.bank_code.Trim() == null)
            //    com.Parameters.Add("@bank_code", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@bank_code", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.bank_code.Trim();
            //if (Convert.ToString(objpar_labourcontractrenewal.CLCAFPID).Trim() == "" || Convert.ToString(objpar_labourcontractrenewal.CLCAFPID).Trim() == null)
            //    com.Parameters.Add("@CLCAFPID", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@CLCAFPID", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.CLCAFPID;

            //com.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.CreatedBy.Trim();
            //com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.CreatedIP.Trim();
            //com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = objpar_labourcontractrenewal.intQuessionaireid.Trim();

            #endregion

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {
                // return com.ExecuteNonQuery();
                return Convert.ToInt32(com.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                throw ex;
                return 0;
            }
            finally
            {
                com.Dispose();
                con.CloseConnection();
            }

        }
        catch (Exception ex2)
        {
            throw ex2;
        }

    }

    public DataSet getdetailsrenewalcontractlabourinxmlformat(string IntuserID, int intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getdetailsrenewalcontractlabourinxmlformat", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = IntuserID.Trim();
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid;
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

    public int insertupdateiSMWrenewalannualfee(ismwContractorAnnualFeePaymentCheckvo objpar_ismwContractorAnnualFeePaymentCheck)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertupdateiSMWrenewalannualfee";

        if (objpar_ismwContractorAnnualFeePaymentCheck.ISMWID.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.ISMWID.Trim() == null)
            com.Parameters.Add("@ISMWID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ISMWID", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.ISMWID.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.act.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.act.Trim() == null)
            com.Parameters.Add("@act ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@act ", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.act.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.actID.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.actID.Trim() == null)
            com.Parameters.Add("@actID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@actID", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.actID.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.amount.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.amount.Trim() == null)
            com.Parameters.Add("@amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@amount", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.amount.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.application_code.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.application_code.Trim() == null)
            com.Parameters.Add("@application_code", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@application_code", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.application_code.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.bank_code.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.bank_code.Trim() == null)
            com.Parameters.Add("@bank_code", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@bank_code", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.bank_code.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.bank_ref_number.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.bank_ref_number.Trim() == null)
            com.Parameters.Add("@bank_ref_number", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@bank_ref_number", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.bank_ref_number.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.bankName.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.bankName.Trim() == null)
            com.Parameters.Add("@bankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@bankName", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.bankName.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.cin.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.cin.Trim() == null)
            com.Parameters.Add("@cin", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@cin", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.cin.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.compound_fee.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.compound_fee.Trim() == null)
            com.Parameters.Add("@compound_fee", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compound_fee", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.compound_fee.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.contractor_mobile.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.contractor_mobile.Trim() == null)
            com.Parameters.Add("@contractor_mobile", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@contractor_mobile", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.contractor_mobile.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.contractor_name.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.contractor_name.Trim() == null)
            com.Parameters.Add("@contractor_name", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@contractor_name", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.contractor_name.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.contractorName.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.contractorName.Trim() == null)

            com.Parameters.Add("@contractorName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@contractorName", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.contractorName.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.district_establishment.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.district_establishment.Trim() == null)
            com.Parameters.Add("@district_establishment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@district_establishment", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.district_establishment.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.door_no_establishment.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.door_no_establishment.Trim() == null)
            com.Parameters.Add("@door_no_establishment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@door_no_establishment", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.door_no_establishment.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.entrepreneur_id.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.entrepreneur_id.Trim() == null)
            com.Parameters.Add("@entrepreneur_id", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@entrepreneur_id", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.entrepreneur_id.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.existing_licence_no.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.existing_licence_no.Trim() == null)
            com.Parameters.Add("@existing_licence_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@existing_licence_no", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.existing_licence_no.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.existing_registration_validity_date.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.existing_registration_validity_date.Trim() == null)
            com.Parameters.Add("@existing_registration_validity_date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@existing_registration_validity_date", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.existing_registration_validity_date.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.existingLicenceNo.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.existingLicenceNo.Trim() == null)
            com.Parameters.Add("@existingLicenceNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@existingLicenceNo", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.existingLicenceNo.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.licence_expiry_date.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.licence_expiry_date.Trim() == null)
            com.Parameters.Add("@licence_expiry_date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@licence_expiry_date", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.licence_expiry_date.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.locality_establishment.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.locality_establishment.Trim() == null)
            com.Parameters.Add("@locality_establishment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@locality_establishment", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.locality_establishment.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.mandal_establishment.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.mandal_establishment.Trim() == null)
            com.Parameters.Add("@mandal_establishment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@mandal_establishment", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.mandal_establishment.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.max_contract_labour.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.max_contract_labour.Trim() == null)
            com.Parameters.Add("@max_contract_labour", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@max_contract_labour", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.max_contract_labour.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.name_pe.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.name_pe.Trim() == null)
            com.Parameters.Add("@name_pe", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@name_pe", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.name_pe.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.nature_of_activity.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.nature_of_activity.Trim() == null)
            com.Parameters.Add("@nature_of_activity", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@nature_of_activity", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.nature_of_activity.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.nature_of_work.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.nature_of_work.Trim() == null)
            com.Parameters.Add("@nature_of_work", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@nature_of_work", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.nature_of_work.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.nature_work.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.nature_work.Trim() == null)
            com.Parameters.Add("@nature_work", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@nature_work", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.nature_work.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.payment_mode.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.payment_mode.Trim() == null)
            com.Parameters.Add("@payment_mode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@payment_mode", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.payment_mode.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.paymentFlag.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.paymentFlag.Trim() == null)
            com.Parameters.Add("@paymentFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@paymentFlag", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.paymentFlag.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.penality_percentage.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.penality_percentage.Trim() == null)
            com.Parameters.Add("@penality_percentage", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@penality_percentage", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.penality_percentage.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.penality_years.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.penality_years.Trim() == null)
            com.Parameters.Add("@penality_years", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@penality_years", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.penality_years.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.pincode_establishment.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.pincode_establishment.Trim() == null)
            com.Parameters.Add("@pincode_establishment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@pincode_establishment", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.pincode_establishment.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.principalEmployerName.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.principalEmployerName.Trim() == null)
            com.Parameters.Add("@principalEmployerName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@principalEmployerName", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.principalEmployerName.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.projectSubmitDate.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.projectSubmitDate.Trim() == null)
            com.Parameters.Add("@projectSubmitDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@projectSubmitDate", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.projectSubmitDate.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.questionnaire_id.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.questionnaire_id.Trim() == null)
            com.Parameters.Add("@questionnaire_id", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@questionnaire_id", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.questionnaire_id.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.registration_fee.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.registration_fee.Trim() == null)
            com.Parameters.Add("@registration_fee", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registration_fee", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.registration_fee.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.registration_years.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.registration_years.Trim() == null)
            com.Parameters.Add("@registration_years", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registration_years", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.registration_years.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.stageID.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.stageID.Trim() == null)

            com.Parameters.Add("@stageID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageID", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.stageID.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.total_amount_payable.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.total_amount_payable.Trim() == null)
            com.Parameters.Add("@total_amount_payable", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@total_amount_payable", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.total_amount_payable.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.total_employees.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.total_employees.Trim() == null)
            com.Parameters.Add("@total_employees", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@total_employees", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.total_employees.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.total_penality_amount.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.total_penality_amount.Trim() == null)
            com.Parameters.Add("@total_penality_amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@total_penality_amount", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.total_penality_amount.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.total_registration_fee.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.total_registration_fee.Trim() == null)
            com.Parameters.Add("@total_registration_fee", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@total_registration_fee", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.total_registration_fee.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.totalAmount.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.totalAmount.Trim() == null)
            com.Parameters.Add("@totalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@totalAmount", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.totalAmount.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.transaction_for.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.transaction_for.Trim() == null)
            com.Parameters.Add("@transaction_for", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transaction_for", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.transaction_for.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.transaction_id.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.transaction_id.Trim() == null)
            com.Parameters.Add("@transaction_id", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transaction_id", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.transaction_id.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.transaction_status.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.transaction_status.Trim() == null)
            com.Parameters.Add("@transaction_status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transaction_status", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.transaction_status.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.transactionDate.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.transactionDate.Trim() == null)
            com.Parameters.Add("@transactionDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transactionDate", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.transactionDate.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.transactionNumber.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.transactionNumber.Trim() == null)
            com.Parameters.Add("@transactionNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transactionNumber", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.transactionNumber.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.tsipassApplicationID.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.tsipassApplicationID.Trim() == null)
            com.Parameters.Add("@tsipassApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@tsipassApplicationID", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.tsipassApplicationID.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.type_of_application.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.type_of_application.Trim() == null)
            com.Parameters.Add("@type_of_application", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@type_of_application", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.type_of_application.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.uID.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.uID.Trim() == null)
            com.Parameters.Add("@uID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@uID", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.uID.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.user_serial_no.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.user_serial_no.Trim() == null)
            com.Parameters.Add("@user_serial_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@user_serial_no", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.user_serial_no.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.valid_from_date.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.valid_from_date.Trim() == null)
            com.Parameters.Add("@valid_from_date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@valid_from_date", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.valid_from_date.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.valid_to_date.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.valid_to_date.Trim() == null)
            com.Parameters.Add("@valid_to_date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@valid_to_date", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.valid_to_date.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.village_establishment.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.village_establishment.Trim() == null)
            com.Parameters.Add("@village_establishment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@village_establishment", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.village_establishment.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.workSiteDistrcitId.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.workSiteDistrcitId.Trim() == null)
            com.Parameters.Add("@workSiteDistrcitId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@workSiteDistrcitId", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.workSiteDistrcitId.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.workSiteDoorNo.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.workSiteDoorNo.Trim() == null)
            com.Parameters.Add("@workSiteDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@workSiteDoorNo", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.workSiteDoorNo.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.workSiteLocality.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.workSiteLocality.Trim() == null)
            com.Parameters.Add("@workSiteLocality", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@workSiteLocality", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.workSiteLocality.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.workSiteMandalId.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.workSiteMandalId.Trim() == null)
            com.Parameters.Add("@workSiteMandalId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@workSiteMandalId", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.workSiteMandalId.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.workSitePincode.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.workSitePincode.Trim() == null)
            com.Parameters.Add("@workSitePincode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@workSitePincode", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.workSitePincode.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.workSiteVillageId.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.workSiteVillageId.Trim() == null)
            com.Parameters.Add("@workSiteVillageId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@workSiteVillageId", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.workSiteVillageId.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.CreatedBy.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.CreatedBy.Trim() == null)
            com.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.CreatedBy.Trim();

        if (objpar_ismwContractorAnnualFeePaymentCheck.CreatedIP.Trim() == "" || objpar_ismwContractorAnnualFeePaymentCheck.CreatedIP.Trim() == null)
            com.Parameters.Add("@CreatedIP ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CreatedIP ", SqlDbType.VarChar).Value = objpar_ismwContractorAnnualFeePaymentCheck.CreatedIP.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            // return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteNonQuery());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public DataSet getdetailsismwforxmlformat(string IntuserID, int intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getdetailsismwforxmlformat", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = IntuserID.Trim();
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid;
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