<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BilldeskPaymentPage_RegDrillingrigsborewells.aspx.cs" Inherits="UI_TSiPASS_BilldeskPaymentPage_RegDrillingrigsborewells" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>  
    <form method="post" name="customerData" action="ccavRequestHandlerRegRegDrillingrigsborewells.aspx">
    <div id="myDIV">
        <center>
            <input type="submit" value="Pay" /></center>
        <table width="50%" height="100" border='1' align="center" runat="server" visible="true"
            style="display: none">
            <tr>
                <td>
                    Parameter Name:
                </td>
                <td>
                    Parameter Value:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Compulsory information
                </td>
            </tr>
            <tr>
                <td>
                    Tid
                </td>
                <%--                    <td>

                        <input readonly="readonly" type="text" name="tid" id="tid" value="" runat="server" /></td>--%>
            </tr>
            <tr>
                <td>
                    Merchant Id :
                </td>
                <td>
                    <input type="text" name="merchant_id" id="merchant_id" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Order Id :
                </td>
                <td>
                    <input type="text" name="order_id" id="order_id" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Amount :
                </td>
                <td>
                    <input type="text" name="amount" id="amount" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Currency :
                </td>
                <td>
                    <input type="text" name="currency" value="INR" />
                </td>
            </tr>
            <tr>
                <td>
                    Redirect URL :
                </td>
                <td>
                    <input type="text" name="redirect_url" value="https://ipass.telangana.gov.in/UI/TSiPASS/ccavResponseHandlerRegDrillingRigsBorewells.aspx" />
                </td>
            </tr>
            <tr>
                <td>
                    Cancel URL :
                </td>
                <td>
                    <input type="text" name="cancel_url" value="https://ipass.telangana.gov.in/UI/TSiPASS/frmDepartmentRegistrationfordrillingrigsborewellPaymentDetails.aspx" />
                </td>
            </tr>
            <tr>
                <td>
                    Language :
                </td>
                <td>
                    <input type="text" name="language" value="EN" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Billing information(optional):
                </td>
            </tr>
            <tr>
                <td>
                    Billing Name :
                </td>
                <td>
                    <input type="text" name="billing_name" id="billing_name" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing Address :
                </td>
                <td>
                    <input type="text" name="billing_address" id="billing_address" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing City :
                </td>
                <td>
                    <input type="text" name="billing_city" id="billing_city" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing State :
                </td>
                <td>
                    <input type="text" name="billing_state" id="billing_state" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing Zip :
                </td>
                <td>
                    <input type="text" name="billing_zip" id="billing_zip" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing Country :
                </td>
                <td>
                    <input type="text" name="billing_country" id="billing_country" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing Tel :
                </td>
                <td>
                    <input type="text" name="billing_tel" id="billing_tel" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Billing Email :
                </td>
                <td>
                    <input type="text" name="billing_email" id="billing_email" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Shipping information(optional)
                </td>
            </tr>
            <tr>
                <td>
                    Shipping Name :
                </td>
                <td>
                    <input type="text" name="delivery_name" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    Shipping Address :
                </td>
                <td>
                    <input type="text" name="delivery_address" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    shipping City :
                </td>
                <td>
                    <input type="text" name="delivery_city" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    shipping State :
                </td>
                <td>
                    <input type="text" name="delivery_state" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    shipping Zip :
                </td>
                <td>
                    <input type="text" name="delivery_zip" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    shipping Country :
                </td>
                <td>
                    <input type="text" name="delivery_country" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    Shipping Tel :
                </td>
                <td>
                    <input type="text" name="delivery_tel" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    Merchant Param1 :
                </td>
                <td>
                    <input type="text" name="merchant_param1" id="merchant_param1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Merchant Param2 :
                </td>
                <td>
                    <input type="text" name="merchant_param2" id="merchant_param2" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Merchant Param3 :
                </td>
                <td>
                    <input type="text" name="merchant_param3" id="merchant_param3" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Merchant Param4 :
                </td>
                <td>
                    <input type="text" name="merchant_param4" id="merchant_param4" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Merchant Param5 :
                </td>
                <td>
                    <input type="text" name="merchant_param5" id="merchant_param5" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Payment information:
                </td>
            </tr>
            <tr>
                <td>
                    Payment Option:
                </td>
                <td>
                    <input class="payOption" type="radio" name="payment_option" value="OPTCRDC">Credit
                    Card
                    <input class="payOption" type="radio" name="payment_option" value="OPTDBCRD">Debit
                    Card
                    <br />
                    <input class="payOption" type="radio" name="payment_option" value="OPTNBK">Net Banking
                    <input class="payOption" type="radio" name="payment_option" value="OPTCASHC">Cash
                    Card
                    <br />
                    <input class="payOption" type="radio" name="payment_option" value="OPTMOBP">Mobile
                    Payments
                    <input class="payOption" type="radio" name="payment_option" value="OPTEMI">EMI
                    <input class="payOption" type="radio" name="payment_option" value="OPTWLT">Wallet
                </td>
            </tr>
            <!-- EMI section start -->
            <tr style="display: none">
                <td colspan="2">
                    <div id="emi_div" style="display: none">
                        <table border="1" width="100%">
                            <tr>
                                <td colspan="2">
                                    EMI Section
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Emi plan id:
                                </td>
                                <td>
                                    <input readonly="readonly" type="text" id="emi_plan_id" name="emi_plan_id" value="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Emi tenure id:
                                </td>
                                <td>
                                    <input readonly="readonly" type="text" id="emi_tenure_id" name="emi_tenure_id" value="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Pay Through
                                </td>
                                <td>
                                    <select name="emi_banks" id="emi_banks">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="emi_duration" class="span12">
                                        <span class="span12 content-text emiDetails">EMI Duration</span>
                                        <table id="emi_tbl" cellpadding="0" cellspacing="0" border="1">
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td id="processing_fee" colspan="2">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <!-- EMI section end -->
            <tr style="display: none">
                <td>
                    Card Type:
                </td>
                <td>
                    <input type="text" id="card_type" name="card_type" value="" readonly="readonly" />
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Card Name:
                </td>
                <td>
                    <select name="card_name" id="card_name">
                        <option value="">Select Card Name</option>
                    </select>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Data Accepted At
                </td>
                <td>
                    <input type="text" id="data_accept" name="data_accept" readonly="readonly" />
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Card Number:
                </td>
                <td>
                    <input type="text" id="card_number" name="card_number" value="" />e.g. 4111111111111111
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Expiry Month:
                </td>
                <td>
                    <input type="text" name="expiry_month" value="" />e.g. 07
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Expiry Year:
                </td>
                <td>
                    <input type="text" name="expiry_year" value="" />e.g. 2027
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    CVV Number:
                </td>
                <td>
                    <input type="text" name="cvv_number" value="" />e.g. 328
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Issuing Bank:
                </td>
                <td>
                    <input type="text" name="issuing_bank" value="" />e.g. State Bank Of India
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Mobile Number:
                </td>
                <td>
                    <input type="text" name="mobile_number" value="" />e.g. 9770707070
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    MMID:
                </td>
                <td>
                    <input type="text" name="mm_id" value="" />e.g. 1234567
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    OTP:
                </td>
                <td>
                    <input type="text" name="otp" value="" />e.g. 123456
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Promotions:
                </td>
                <td>
                    <select name="promo_code" id="promo_code">
                        <option value="">All Promotions &amp; Offers</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>


</body>
</html>
