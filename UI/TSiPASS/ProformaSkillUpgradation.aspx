<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaSkillUpgradation.aspx.cs" Inherits="UI_TSiPASS_ProformaSkillUpgradation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-size: large">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <br />
                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                    <br />
                    <br />
                </div>
                <div align="center" id="Receipt" runat="server">
                    <table style="width: 1000px">
                        <tr>
                            <td style="vertical-align: top; width: 400px; text-align: left">From<br />
                                The General Manager,<br />
                                District Industries Centre,<br />
                                <asp:Label ID="lblDistrict" runat="server"></asp:Label></td>
                            <td style="vertical-align: top; width: 400px; text-align: left">To<br />
                                The Commissioner of Industries,<br />
                                Government of Telangana,<br />
                                Chirag Ali Lane, Abids,<br />
                                Hyderabad.</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNo" runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">Sir,</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Skill Upgradation 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">********</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Skill Upgradation under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddt" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloa" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharno" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardate" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCP" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>.--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">The eligible reimbursement of Skill Upgradation is calculated as under :- </td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2" runat="server"></asp:Label></span>&nbsp;</td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp; As per form - A the Skill Upgradation Amount paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaid" runat="server"></asp:Label></span>.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp; The eligible reimbursement of Skill Upgradation @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                <asp:Label ID="lblSTAmountPaid1" runat="server"></asp:Label></span>.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Skill Upgradation of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3" runat="server"></asp:Label></span>&nbsp;<br />
                                &nbsp;(<asp:Label ID="lblSanctionedAmtDesc" runat="server"></asp:Label>
                                &nbsp;Rupees only), 
                                for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center">
                                <br />
                                <span style="font-weight: bold">Yours faithfully,</span>
                                <br />
                                <%--<asp:Label ID="lblName" runat="server"></asp:Label>--%>
                                <asp:Label ID="lblGMname" runat="server" Font-Bold="true"></asp:Label>
                                <br />
                                General Manager
                        <br />
                                <asp:Label ID="lbldist3" runat="server" Font-Bold="true"></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Encl : As above.</td>
                            <td style="text-align: center"><strong></strong></td>
                        </tr>
                    </table>
                    <table style="width: 1000px">
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning" Text=" Print " OnClientClick="javascript:CallPrint('Receipt')" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
