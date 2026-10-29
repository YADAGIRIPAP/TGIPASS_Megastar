<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="FinalPage.aspx.cs" Inherits="UI_TSiPASS_FinalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <table style="width: 100%">
            <tr id="check123" runat="server" visible="false">
                <td  style="width: 65%; color: green; font-weight: bold; font-size: x-large; height: 200px" align="center" id="tdmsg" runat="server">
                    <asp:Label ID="lblAppliedSuccesful"  runat="server" Visible="false" Text="Incentives Applied Successfully!"></asp:Label>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="false" style="height: 40px" width="65%">
                <td align="center" colspan="4">
                    <table style="width: 65%; border-color: black; border-style: solid; font-weight: bold" border="2">
                        <tr>
                            <td style="height: 48px"></td>
                            <td align="left">Incentives Application Form</td>
                            <td>
                                <asp:LinkButton ID="lnkapplntotalprint" runat="server" OnClick="lnkapplntotalprint_Click">Print</asp:LinkButton>
                            </td>
                            <td>
                                <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkapplntotalprint_Click">Download</asp:LinkButton--%>
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Acknowledgement</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr id="trIncentivewisePrint" runat="server" visible="false">
                <td align="center">
                    <table style="width: 65%; border-color: black; border-style: solid; font-weight: bold" border="2">
                        <tr>
                            <td align="center" colspan="4" style="background-color: gold; font-size: x-large; border-color: black; border-style: solid;">Incentives Draft Print</td>
                        </tr>
                        <tr id="trInvestmentSubsidy" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Investment Subsidy</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkInvestmentSubsidy" runat="server" OnClick="lnkInvestmentSubsidy_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr id="trstampDuty" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkstampDuty" runat="server" OnClick="lnkstampDuty_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr id="trQualityCertification" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Reimbursement of all expenses incurred for Quality Certification/Patent Registration</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkQualityCertification" runat="server" OnClick="lnkQualityCertification_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr id="trCleanerProduction" runat="server" visible="false" style="height: 40px">
                            <td></td>
                            <td align="left">Specific Cleaner Production measures</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkCleanerProduction" runat="server" OnClick="lnkCleanerProduction_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr id="trPavallavaddi" runat="server" visible="false" style="height: 40px">
                            <td></td>
                            <td align="left" style="height: 30px;">Pavalla vaddi</td>
                            <td align="center" style="width: 60px">
                                <asp:LinkButton ID="lnkPavallavaddi" runat="server" OnClick="lnkPavallavaddi_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr id="trTransportVehicle" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left" style="height: 30px">Application For Transport Vehicle Under T-Pride</td>
                            <td align="center" style="height: 30px">
                                <asp:LinkButton ID="lnkTransportVehicle" runat="server" OnClick="lnkTransportVehicle_Click">Print</asp:LinkButton></td>
                            <td style="height: 26px"></td>
                        </tr>
                        <tr id="trpowercost" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Power Cost Reimbursement</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkpowercost" runat="server" OnClick="lnkpowercost_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>

                        <tr id="trSalesTax" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Sales TAX(VAT/GST/SGST) Reimbursement</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkSalesTax" runat="server" OnClick="lnkSalesTax_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>

                        <tr id="trIIDF" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Industrial Infrastructure Development Fund(IIDF)</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkIIDF" runat="server" OnClick="lnkIIDF_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr style="height: 40px" id="trReimbursementofcost" runat="server" visible="false">
                            <td style="height: 30px"></td>
                            <td align="left">Reimbursement of cost involved in skill upgradation and training</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkReimbursementofcost" runat="server" OnClick="lnkReimbursementofcost_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>

                        <tr id="trSeedCap" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Seed Capital Assistance for 1st generation Entrepreneur for Micro Enterprise</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkSeedCap" runat="server" OnClick="lnkSeedCap_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>

                        <tr id="trAdvanceSubsidySCST" runat="server" visible="false" style="height: 40px">
                            <td style="height: 30px"></td>
                            <td align="left">Advance Subsidy before DCP for SC/ST Enterprises</td>
                            <td align="center">
                                <asp:LinkButton ID="lnkAdvanceSubsidySCST" runat="server" OnClick="lnkAdvanceSubsidySCST_Click">Print</asp:LinkButton></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>

        </table>
    </div>
</asp:Content>

