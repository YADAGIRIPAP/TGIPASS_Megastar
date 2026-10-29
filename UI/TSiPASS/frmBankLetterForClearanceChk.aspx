<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmBankLetterForClearanceChk.aspx.cs" Inherits="UI_TSiPASS_frmBankLetterForClearanceChk" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        p.MsoNormal {
            margin-top: 0cm;
            margin-right: 0cm;
            margin-bottom: 10.0pt;
            margin-left: 0cm;
            line-height: 13.8pt;
            text-autospace: none;
            font-size: 11.0pt;
            font-family: "Calibri",sans-serif;
        }
    p.MsoNoSpacing
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%;" align="center">

            <table style="width: 60%" align="center" border="1">
                <tr>
                    <td>
                        <div align="center">
                            <br />
                            <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                            <br />
                            <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA <br />COMMISSIONERATE OF INDUSTRIES::  HYDERABAD</asp:Label>
                            <br />
                            <br />
                        </div>

                        <div style="width: 100%" align="center">
                            <table style="width: 100%; font-weight: bold;">
                                <tr>
                                    <td style="width: 10px"></td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">From:<br />
                                        The Commissioner of Industries,<br />
                                        Chirag Ali Lane,<br />
                                        Hyderabad</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 50px"></td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">To:<br />
                                        The Chief Manager,<br />
                                        State Bank of India,<br />
                                        Treasury Branch, Gunfoundry,<br />
                                        Hyderabad
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr style="height: 10px">
                                    <td></td>
                                </tr>
                                <tr>
                                    
                                    <td style="text-align: center; font-weight: bold; text-underline-position: below;" colspan="2"><u>Lr. No.&nbsp;<asp:Label ID="lblLetterNo" runat="server"></asp:Label>&nbsp;Dated:&nbsp;<asp:Label ID="lblLetterDate" runat="server"></asp:Label>.</u>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                     
                                    <td  align="left" style="font-weight: bold" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sir / Madam,</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td></td>
                                </tr>
                                <tr>
                                    
                                    <td style="text-align: left">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 55px"></td>
                                                <td style="width: 20px; vertical-align: top;">Sub: </td>
                                                <td style="width: 5px"></td>
                                                <td>Electronic Remittance by way of RTGS / NEFT</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50px; height: 10px">&nbsp;</td>
                                                <td style="width: 20px; vertical-align: top;">&nbsp;</td>
                                                <td style="width: 5px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td style="width: 50px">&nbsp;</td>
                                                <td style="width: 20px; vertical-align: top;">&nbsp;</td>
                                                <td style="width: 5px">&nbsp;</td>
                                                <td style="text-align: center">******</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table>
                                            <tr>
                                                <td style="width: 20px"></td>
                                                <td style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We are sending a Sealed Cover through Sri
                                                    <asp:Label ID="lblAssistantName" runat="server" ></asp:Label>, <asp:Label ID="lblDesignation" runat="server" ></asp:Label> of our Office containing list of payees. An e-mail is also sent 
                                                    containing the text files titled:
                                                    <asp:Label ID="lblTextFilesNames" runat="server"></asp:Label>. Please arrange to remit the 
                                                    amounts by way of RTGS / NEFT to the 
                                                    beneficiaries / payees as mentioned in the e-mail by debit to our Account No.
                                                    <asp:Label ID="lblAccountNo" runat="server" ></asp:Label>.  
                                                    We confirm that, the particulars mentioned in the e-mail are correct and undertake that, we are responsible for any omission.  
                                                    Break up of amount to be remitted to SBI Accounts and other Bank Accounts is furnished below:   </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 20px" colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" colspan="2">
                                        <table style="border: 1px solid black; border-collapse:collapse"  width="100%">
                                            <tr runat="server" id="trSBIData" visible="false">
                                                <td style="width: 20px;vertical-align:top; border: 1px solid black;"><span id="spn1" runat="server">1.</span></td>
                                                <td style="vertical-align:top; border: 1px solid black;">Total 
                                                    <br />
                                                    Amount to be<br />
                                                    remitted to 
                                                    <br />
                                                    SBI Account<br />
                                                    holders</td>
                                                <td style="vertical-align:top; border: 1px solid black;">
                                                    <asp:Label ID="lblSBIDateWithUnits" runat="server"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblSBIAmount" runat="server"></asp:Label> &nbsp;( Rupees 
                                                    <asp:Label ID="lblSBIAmountInwords" runat="server"></asp:Label> Only )
                                                </td>
                                            </tr>
                                             <tr  runat="server" id="trOtherBankData" visible="false">
                                                <td style="width: 20px; vertical-align:top; border: 1px solid black;" ><span id="Span2" runat="server">2.</span></td>
                                                <td style="vertical-align:top; border: 1px solid black;width: 120px;">Total 
                                                    <br />
                                                    Amount to be<br />
                                                    remitted to 
                                                    <br />
                                                    other Bank Account<br />
                                                    holders</td>
                                                <td style="vertical-align:top; border: 1px solid black;">
                                                    <asp:Label ID="lblOtherBankDateWithUnits" runat="server"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblOtherBankAmount" runat="server"></asp:Label>&nbsp;( Rupees 
                                                    <asp:Label ID="lblOtherBankAmountinWords" runat="server"></asp:Label> Only )
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle"
                                        >&nbsp;</td>
                                    <td style="text-align:left;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align:left;">Encl: As above</td>
                                    <td style="text-align:left;"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td style="height: 20px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="text-align: right;">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 90px"></td>
                                                <td>Authorised Signature with Seal</td>
                                                <td style="width: 2px"></td>
                                            </tr>

                                          
                                        </table>
                                    </td>

                                </tr>
                                <tr>
                                    <td  style="padding: 5px; margin: 5px; text-align: center;" valign="middle"></td>
                                    <td></td>
                                </tr>
                                <tr><td colspan="2"  style="padding: 5px; margin: 5px; text-align: center;" valign="middle" >---------------------------------------------------------------------------------------------------------------</td></tr>
                                <tr><td colspan="2"  style="padding: 5px; margin: 5px; text-align: center;" valign="middle" >
                                    
                                  ACKNOWLEDGEMENT
                                    </td></tr>
                                <tr><td colspan="2"  style="padding: 5px; margin: 5px; text-align: left;" valign="middle" >
                                    
                                    Received sealed cover reported to be containing list of beneficiaries submitted by Sri  <asp:Label ID="lblAssistantName2" runat="server" ></asp:Label>, Senior Assistant, O/o Commissioner of Industries.</td></tr>
                                <tr><td colspan="2"  style="padding: 5px; margin: 5px; text-align: left;" valign="middle" >
                                    
                                    &nbsp;</td></tr>
                                <tr><td colspan="2"  style="padding: 5px; margin: 5px; text-align: left;" valign="middle" >
                                    
                                    Department</td></tr>
                                <tr><td colspan="2"  style="padding: 5px; margin: 5px; text-align: left;" valign="middle" >
                                    
                                    &nbsp;</td></tr>
                                <tr><td colspan="1"  style="padding: 5px; margin: 5px; text-align: left;" valign="middle" >
                                    
                                    Deputy Manager,</td><td>Date:</td></tr>
                            </table>
                           
                        </div>
                    </td>
                </tr>
            </table>

            <%-- <pagebreak:before></pagebreak:before>--%>
        </div>
    </form>
</body>
</html>
