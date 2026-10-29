<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaIntimationLetter.aspx.cs" Inherits="UI_TSiPASS_ProformaIntimationLetter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
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
                            <center>
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                    </center>
                            <br />
                            <asp:Label Font-Bold="true" Font-Size="X-Large" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                            <br />
                            <br />
                        </div>

                        <div style="width: 100%" align="center">
                            <table style="width: 100%; font-weight: bold;">
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">TO
                                        <br />
                                        <span>
                                            <asp:Label ID="lblEnterpreneurDetails" runat="server" Width="200px"></asp:Label></span>
                                        &nbsp;,<br />

                                    </td>
                                    <td style="width: 40%;"></td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr style="height: 10px">
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="text-align: left; font-weight: bold">Letter No :
                            <asp:Label ID="lblLetterNo" runat="server"></asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp;Dated:&nbsp;
                            <asp:Label ID="lblLetterDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="font-weight: bold">Sir / Madam,</td>
                                </tr>
                                <tr style="height: 10px">
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="text-align: left">&nbsp; &nbsp; &nbsp;<span style="font-weight: bold"> Sub:-	</span>
                                        &nbsp;<asp:Label ID="lblTIdeaTPride" runat="server"></asp:Label>&nbsp; - Sanction of Reiumbersement of Power Cost to  &nbsp; 
                                <asp:Label ID="lblEnterpreneurDetails3" runat="server"></asp:Label><br />
                                        &nbsp; &nbsp;&nbsp;&nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  District - Intimation – Reg.

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <table>
                                            <tr>
                                                <td style="width: 20px"></td>
                                                <td style="text-align: left"><span style="font-weight: bold">Ref:- </span>1. G.O. Ms. No.61, Industries & Commerce (IP) Dept. dt. 29.06.2010 read with G.O.Ms.No.42, I&amp;C(IP) Dept.,dated 05/05/2011.<br />
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 2. Letter No
                            <asp:Label ID="lblRefLetterNo" runat="server"> </asp:Label>&nbsp;, dated &nbsp;<asp:Label ID="lblRefLetterDated" runat="server"> </asp:Label>&nbsp;
                            of the General Manager, District Industries centre, &nbsp;<asp:Label ID="lbldist" runat="server"></asp:Label>&nbsp; District.<br />
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 3. Minutes of the
                                                    <asp:Label ID="lblSLCNo" runat="server"></asp:Label>
                                                    SLC meeting held on
                                                    <asp:Label ID="lblSLCDate" runat="server"></asp:Label>

                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center" class="auto-style1">*******</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">With reference to the subject cited, we are pleased to inform you that you have been sanctioned Reimbursement of power cost of Rs.
                            <asp:Label ID="lblSanctionedPowerCost" runat="server"></asp:Label>
                                        &nbsp; to the captioned unit&nbsp; for the&nbsp;<asp:Label ID="lbl1st2ndhallfyear" runat="server"></asp:Label>&nbsp; of &nbsp;
                            <asp:Label ID="lblFinancialYear" runat="server"></asp:Label>&nbsp;
                            under the scheme of &nbsp;
                            <asp:Label ID="lblTIdeaTPride2" runat="server"></asp:Label>&nbsp; vide reference 3rd cited.
                            <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">This amount will be released as and when your unit’s turn comes as per seriatim for disbursement of available funds.     
                                    </td>
                                </tr>
                                <tr style="height: 10px">
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>

                            <table align="right">

                                <tr>
                                    <td colspan="2" style="text-align: left; font-weight: bold">Your's faithfully,</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left">Deputy Director (II)
                                <br />
                                        O/o. Commissioner of Industries     
                            <br />
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left"></td>
                                </tr>
                            </table>
                            <table style="width: 100%" align="left">
                                <tr>
                                    <td align="left" colspan="2">Copy to the General Manager, District Industries Centre, &nbsp;<asp:Label ID="lbldist2" runat="server"></asp:Label>&nbsp; District for information. 

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left"></td>
                                </tr>
                                <tr style="height: 300px">
                                    <td align="left" colspan="2" valign="bottm"><b>Note:</b>	27/ &nbsp;<asp:Label ID="lblTIdeaTPride3" runat="server"></asp:Label>&nbsp; – Furnishing of Statement of Accounts / Information by eligible Industrial Enterprises. Industrial units, which obtain incentives under the scheme, shall furnish certified copy of audited accounts including Balance Sheet before 30th June of the succeeding year to the disbursing agencies. Such statement should be furnished for a period of minimum six (6) years.  Further, industrial units should also furnish details of production, sales employment, etc., in the proforma prescribed to the  General Manager, District Industries Centre concerned as an Annual Return before 30th June of the succeeding year and obtain acknowledgement thereof”.  However, Enterprises which are released capital subsidy Rs.
                            <asp:Label ID="lblcapitalSubsidyReleased" runat="server"></asp:Label>
                                        may furnish only the Annual Performance Report in the format prescribed to the General Manager, DIC concerned as an Annual Return before 30th June of the succeeding year and obtain acknowledgement thereof for a period of six (6) years after going into Commercial Production
                                    </td>
                                </tr>

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
