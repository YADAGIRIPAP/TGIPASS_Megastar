<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SBHChallan.aspx.cs" Inherits="SBHChallan" EnableEventValidation="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SBH Challan</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divPDF" runat="server" >
            <table  align="center" style="width: 842px;height:595px;">
                <tr>
                    <td>
                        <table align="center" style="width: 842px; height: 595px;">
                            <tr>
                                <td style="width: 400px; height: 595px; padding-right: 10px;" >
                                    <table border="1" cellpadding="1" align="left" cellspacing="2" style="width: 420px;
                                        border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
                                        border-bottom: #000000 thin solid; ">
                                        <%--style="width: 595px;  height: 642px;"--%>
                                        <tr>
                                            <td colspan="4" align="right">
                                                Cash Voucher|Customer Copy &nbsp;</td>
                                              
                                        </tr>
                                        <tr>
                                            <td align="left">
                                               <img src="../../images/tsSmalllogo.png" />
                                                <%--<img src="E:/suri/TS-iPASSFinal/images" />--%></td>
                                            <td colspan="2" align="center">
                                                <%-- <div>--%>
                                                <font size="2"><strong style="font-family: Arial">TS iPASS CFE Fee Challan<br />
                                                    - At any Branch of SBH (CBS Screen No: 8888) </strong></font>
                                                <%--</div>--%>
                                            </td>
                                            <td align="center">
                                            <img src="../../images/sbh.jpg" />
                                                <%--<img src="E:/Webapps/e-PTax/images/sbh.jpg" D:\Rishi\TSIPass\TSIPassWebsite1\images />--%></td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="2" align="left">
                                                Reference No:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblRefNo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Challan Date:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblChallanDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Unit Name:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblCustName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                TSIPASS Ref No:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblTSIpassRefNo1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr><td colspan="2" align="left">Transaction Amount:</td><td colspan="2" align="left"> <asp:Label ID="lblTransAmount" runat="server"></asp:Label></td></tr>
                                          <tr>
                                            <td colspan="2" align="left">
                                              <b>  Fee Type</b>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="true">2037</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Bank Charges(in Rs.):
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblBankcharges" runat="server">50</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Total Amount(in Rs.):
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="2" align="left">
                                                Cheque /DD No:<%--<asp:CheckBox ID="chkUsrDd" runat="server" />--%>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblChequeNo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Bank and Branch:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblBankBranch" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:Label ID="lblAmounttoWords" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:Label ID="lblBankUsrSig" runat="server" Text="Customer Signature:"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Bank Ref No/<br />
                                                Journal No:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblBankRefJournal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left" style="height:30px;">
                                                Bank Authorized Signature and Stamp.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <strong>NOTE:</strong><br />
                                                1.Cheque/DD Subject to realization.<br />
                                                2.Make Cash Payments at Branch Only after 24 hrs<br />
                                                3.Cash transaction cannot exceed rupees 50,000.<br />
                                                4.<span style="color:Red; font-weight:bold;">Please visit your nearest SBH Bank after 24 hrs and remit your payment</span><br />
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                              
                                <td style="width: 842px;height:595px;">
                             
                                    <table border="1" cellpadding="1" align="right" cellspacing="2" style="width: 420px;
                                        border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
                                        border-bottom: #000000 thin solid; ">                                        
                                       
                                        <tr>
                                            <td colspan="4" align="right">
                                                Cash Voucher|Bankers Copy &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            <img src="../../images/tsSmalllogo.png" />
                                                <%--<img src="E:/Webapps/e-PTax/images/ghmclogo.png" />--%>
                                            </td>
                                            <td colspan="2" align="center">
                                                <%-- <div>--%>
                                                <font size="2"><strong style="font-family: Arial">TS iPASS CFE Fee Challan<br />
                                                    - At any Branch of SBH (CBS Screen No: 8888)</strong></font><%--</div>--%></td>
                                            <td align="center">
                                            <img src="../../images/sbh.jpg" />
                                              
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td colspan="2" align="left">
                                                Challan
                                                Reference No:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblRefNumber2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Challan Date:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblChallanDate2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Unit Name:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblCustName2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                TSIPASS Ref No:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblTSIpassRefNo2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr><td colspan="2" align="left">Transaction Amount:</td><td colspan="2" align="left"> <asp:Label ID="lblTransAmount2" runat="server"></asp:Label></td></tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                              <b>  Fee Type</b>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="true">2037</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Bank Charges(in Rs.):
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblBankcharges2" runat="server">50</asp:Label>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td colspan="2" align="left">
                                                Total Amount(in Rs.):
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lbltotAmount2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="2" align="left">
                                                Cheque / DD No:<%--<asp:CheckBox ID="chkDd" runat="server" />--%>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblChequeNo2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Bank and Branch:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblBankBranch2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:Label ID="lblnotowords2" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:Label ID="lblusrSign" runat="server" Text="Customer Signature:"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                Bank Ref No/<br />
                                                Journal No:
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblBankRefJournal2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left" style="height:30px;">
                                                Bank Authorized Signature and Stamp.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <strong>NOTE:</strong><br />
                                                1.Cheque/DD Subject to realization.<br />
                                                2.Make Cash Payments at Branch Only after 24 hrs<br />
                                                3.Cash transaction cannot exceed rupees 50,000.<br />
                                                4.<span style="color:Red; font-weight:bold;">Please visit your nearest SBH Bank after 24 hrs and remit your payment</span><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <table border="0" align="center" cellpadding="1" cellspacing="2" style="width: 842px">
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnclose" runat="server"     Text="Close" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnprint" runat="server"  Text=" Print " OnClick="btnprint_Click" />
                                            </td>
                                        </tr>
                                    </table>
    </form>
</body>
</html>
