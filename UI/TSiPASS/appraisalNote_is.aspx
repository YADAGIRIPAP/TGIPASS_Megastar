<%@ Page Language="C#" AutoEventWireup="true" CodeFile="appraisalNote_is.aspx.cs"
    Inherits="UI_TSIPASS_appraisalNote_is" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }

        }
        .auto-style1 {
            width: 333px;
        }
        .auto-style2 {
            height: 50px;
        }
        .auto-style3 {
            height: 38px;
            width: 38%;
        }
        .auto-style4 {
            height: 34px;
        }
        .auto-style5 {
            width: 483px;
        }
        .auto-style6 {
            width: 484px;
        }
        .auto-style7 {
            width: 29px;
        }
        .auto-style8 {
            width: 38%;
        }
        .auto-style9 {
            width: 475px;
        }
        .auto-style10 {
            width: 4px;
        }
        .auto-style11 {
            width: 2%;
        }
        .auto-style12 {
            width: 274px;
        }
        .auto-style13 {
            width: 255px;
        }
        .auto-style14 {
            width: 312px;
        }
        .auto-style15 {
            width: 293px;
        }
        .auto-style16 {
            width: 694px;
        }
        .auto-style18 {
            height: 34px;
            width: 38%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <div align="center" style="text-align: center">
            <div align="center">
                <center>
                    <img src="telanganalogo.png" width="75px" height="75px" />
                </center>
                <%--<h3>TS-iPASS APPLICATION FORM</h3>--%>
            </div>
            <br />
            <div>
                <div>
                    <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td style="text-align: right">
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/appraisalNote2.aspx"
                                    Font-Bold="True" Font-Names="Gadugi" Font-Underline="True">Appraisal Note</asp:HyperLink>
                            </td>
                        </tr>
                        <tr id="tideaTr" runat="server">
                            <td style="text-align: left; font-weight: bold;">
                                <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                                Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO
                                29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                Dated : 29/11/2014
                            </td>
                        </tr>
                        <tr id="tprideTr" runat="server">
                            <td style="text-align: center; font-weight: bold;">
                                Telangana State Program for Rapid Incubation of Dalit Entrepreneurs - G.O M.S. NO
                                29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                Dated : 29/11/2014
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; vertical-align: middle">
                                <u><b>
                                    <%--Telangana State Industrial Development and Entrepreneur Advancement - GO MS. NO 28, Industries & Commerce (IP & INF) Department, Dated : 29/11/2014--%>
                                    Appraisal
                                    <br />
                                    <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                </b></u>
                            </td>
                        </tr>
                    </table>
                    <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                2.0 Application no
                            </td>
                            <td>
                                <asp:Label ID="lblApplication_no" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td style="font: bolder; font-size: small" class="auto-style1">
                                <b>2.1 Name of Industrial Concern</b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblUnitname" runat="server"></asp:Label></b> &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                2.2 Location of the Industrial concern
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblLocaddress" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                2.3 Constitution of the Industrial Concern
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                2.4.a. Whether the SSI Prov. regn. or any other regn/ approval
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp; in terms of IEM, ackngmnt LI/IL etc., has the continuity
                                in
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp; validity of commercial production
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblSSIApprovalofIEM" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                &nbsp;&nbsp;&nbsp;&nbsp; b. PMT/SSI/IEM acknowledgement, LI/IL No & Dt
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblAcknoledgementLIORIL" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                    <%--//style="font-family: Verdana; font-size: small;"--%>
                    <table style="width: 100%; font-family: Verdana; font-size: small">
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td>
                                <u><b>2.5 PRODUCTS MANUFACTURED</b></u>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td>
                                <u>Product Details</u>
                            </td>
                        </tr>
                        <%-- <tr>
                                <td>Line of Activity
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLOA" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Capacity
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCapacity" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Units
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnitNumbers" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Value in Rs
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblValue" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>--%><tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" GridLines="Both" Width="90%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                        </Columns>
                                        <RowStyle ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                            Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                    </table>
                </div>
                <br />
                <div>
                    <table style="font-family: Verdana; font-size: small; width: 100%">
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td style="font-weight: bold;" class="auto-style9">
                                <b>2.6 INITIAL STEPS TAKEN FOR IMPLEMENTATION</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                Date of filing of application with the lead financial Institution
                                <br />
                                for term loan/Date of openings of first Public issue is financed
                                <br />
                                through public issues.
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDateOfFilingOfAppln" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                2.7.a. In case term loan obtained from the Financial Institution/Bank
                                <br />
                                Term loan sanction letter No. and date.
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblBankSanctionLetter_No" runat="server"></asp:Label>
                                    &nbsp; </span>Dt:
                                <asp:Label ID="lblLoansanctionDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                &nbsp;&nbsp;&nbsp;&nbsp; b. Name of the Financing Institution.
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lead Instn. in case of Joint finance.
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblNameOfFinacingInstin" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                2.8 Date of Power connection with connected load
                            </td>
                            <td>
                                <span>Date:
                                    <asp:Label ID="lblPowerConnection_Date_connected" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblPowerConnection_HP_connected" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <%-- <tr>
                                <td>Date of Power connection with contracted load
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPowerConnection_Date_contracted" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblPowerConnection_HP_contracted" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>--%>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                2.9 Date of Commencement of Commercial production
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblCommencmentOfCommrclProdcn_Date" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                2.10.a. Date of receipt of claim application(in DIC)
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblClaimAppln_Date_DIC" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b. Date of communication of shortfalls
                                to the party(in DIC)
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDate_Communcn_ShortFalls_DIC" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c. Date of receipt of complete information
                                from the party(in DIC)
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDateOfReceipt_DIC" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                2.11.a. Date of receipt of claim application(in COI)
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblClaimAppln_Date_COI" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b. Date of communication of shortfalls
                                to the party(in COI)
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDate_Communcn_ShortFalls_COI" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style9">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c. Date of receipt of complete information
                                from the party(in COI)
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDateOfReceipt_COI" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                    <div>
                        <table style="font-family: Verdana; font-size: small; width: 100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" style="color: black; font-weight: bold;">
                                    <u>2.12. Approved Project Cost As Per Guidelines (Rs. in Lakhs)</u>
                                </td>
                                <td colspan="2" style="color: black; font-weight: bold;">
                                    <u>Means of finance(Rs in Lakhs)</u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    a. Land
                                </td>
                                <td>
                                    <asp:Label ID="lblApprovedLnd" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                                <td class="auto-style13">
                                    1. Own share capital
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblshareCapita_MF" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    b. Building
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApprBuilding" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style13">
                                    2. State Subsidy
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblStateSubsidy" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    c. Plant & M/C
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApprovPlantMachinery" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style13">
                                    3. Funds through public issues
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFunds_MF" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    d. Preliminery/Preoperative expenditure
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPreoperativeexpenditure" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style13">
                                    4. Soft,loan/capital
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblloan_capital" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    e. (i). Tech-know how feasibility study
                                    <br />
                                    and turn key charges
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApprovedTechFeasibility" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style13">
                                    5. Term loan
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTermLoan_MF" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    (ii). Vehicles
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApprvVehicles" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style13">
                                    6. Unsecured loans
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnsecuredloans" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    (iii). Others
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApprovOthers" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style13">
                                    7. Working capital loan
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblworkingCapital_MF" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    f. Others
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblOthers1Approve" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style12">
                                    g. Working Capital
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApprovWorkingCapital" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="text-align: center" class="auto-style12">
                                    <b>Total: Rs.</b>
                                </td>
                                <td>
                                    <u><span>
                                        <asp:Label ID="lblApprovlTotal" runat="server"></asp:Label>
                                    </span></u>
                                </td>
                                <td style="text-align: center" class="auto-style13">
                                    <b>Total: Rs.</b>
                                </td>
                                <td>
                                    <u><span>
                                        <asp:Label ID="lblTotal_MF" runat="server"></asp:Label>
                                    </span></u>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div align="center">
                        <table style="font-family: Verdana; font-size: small; width: 100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="5" style="color: black; font-weight: bold;">
                                    <u><b>2.13. Details of Investment on fixed Capital assets as on:</b></u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td align="center">
                                </td>
                                <td align="center">
                                    <b>Project Cost as Approved </b>
                                </td>
                                <td align="center">
                                    <b>Loan Sanctioned</b>
                                </td>
                                <td align="center">
                                    <b>Loan Disbursed</b>
                                </td>
                                <td align="center">
                                    <b>Assets Certified by Banks/<br />
                                        Fin Instn. as on</b>
                                </td>
                                <td align="center">
                                    <b>Assets expr incurred as per C.A as on 27/10/2015</b>
                                </td>
                                <td align="center">
                                    <b>Value Recommended by G.M</b>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="1px">
                                    a. Land-Purchased
                                </td>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblLand_ProjectCost"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblLand_LoanSanctioned"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblLand_LoanDisbursed"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblLand_Assets"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblLand_ActualExpend_CA"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label runat="server" ID="lblLand_ValueRecommendedByGM"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    b. Building-Constructed
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBuilding_ProjectCost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBuilding_LoanSanctioned"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBuilding_LoanDisbursed"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBuilding_Assets"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBuilding_ActualExpend_CA"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBuilding_ValueRecommendedByGM"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    c. Plant & M/C
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPlantMachry_ProjectCost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPlantMachry_LoanSanctioned"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPlantMachry_LoanDisbursed"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPlantMachry_Assets"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPlantMachry_ActualExpend_CA"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPlantMachry_ValueRecommendedByGM"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="1.5px">
                                    d.Tech.Knows -how feasibility study & turn key charges
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFeasibilityStudyCharges_ProjectCost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFeasibilityStudyCharges_Land_LoanSanctioned"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFeasibilityStudyCharges_Land_LoanDisbursed"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFeasibilityStudyCharges_Assets"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFeasibilityStudyCharges_ActualExpend_CA"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFeasibilityStudyCharges_ValueRecommendedByGM"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    e.Vehicles
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblVehicles_ProjectCost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblVehicles_LoanSanctioned"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblVehicles_LoanDisbursed"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblVehicles_Assets"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblVehicles_ActualExpend_CA"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblVehicles_ValueRecommendedByGM"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    f.Other eligible
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblOthersEligible_ProjectCost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblOthersEligible_LoanSanctioned"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblOthersEligible_LoanDisbursed"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblOthersEligible_Assets"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblOthersEligible_ActualExpend_CA"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblOthersEligible_ValueRecommendedByGM"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align: center">
                                <td style="width: 2%">
                                </td>
                                <td>
                                    Total
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal_ProjectCost"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal_LoanSanctioned"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal_LoanDisbursed"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal_Assets"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal_ActualExpend_CA"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal_ValueRecommendedByGM"></asp:Label>
                                </td>
                        </table>
                    </div>
                    <div>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style14">
                                    <u>2.14. Computation of Capital Cost</u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" style="color: black; font-weight: bold;">
                                    <u>A. LAND</u>
                                </td>
                                <td colspan="2" style="color: black; font-weight: bold;">
                                    <u>B. FACTORY BUILDINGS</u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (i). As per approved project cost.
                                </td>
                                <td>
                                    <asp:Label ID="lblApprovedLandPrjCost" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                                <td class="auto-style15">
                                    (i) As per Approved Project cost in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFactryProjCost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (ii) Land measuring in Sq.mts.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandMeasuring" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style15">
                                    (ii) Factory building's plinth area/item wise<br />
                                    total value assessed by G.M,DIC.in Rs
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFactoryPlinthArea" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (iii). Purchase value as per in document.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandPurchaseValue" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style15">
                                    (iii).As per Civil Engineer&#39;s Certificate in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFactryCivilEngineerCert" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (iv). Stamp Duty in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandStampDuty" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style15">
                                    (iv). Value assesses as per TSSSFC rates in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFactryTSSFCrates" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (v). Registration fee in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandRegistrationFee" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style15">
                                    (v).Expenditure as per C.A Certificate in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFactoryExpendutreCert" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    <b>Total</b>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTotalLand" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style15">
                                    (vi) Computed Value
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFactoryComputedValue" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (vi). Building plinth area in Sq.Mts.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandBuildingPlinthArea" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td class="auto-style15">
                                    (vii) Reasons of variations with that of
                                    <br />
                                    G.M.'s recommendation.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblReasonFactoryGMrecom" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (viii). Value recommended by G.M DIC. in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandValue_RecommdedBy_GM" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (ix). Value Computed in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandValue_Computed" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style14">
                                    (x). Reasons of variations with that of G.M.'s recommendation.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandReasons_GM_Recommendation" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style6">
                                    <u>C.PLANT & MACHINERY</u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    i. As per Approved Project Cost
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProjcostPlant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    ii. Technical know-how & feasibility study and turnkey charges as per approved project
                                    cost.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTechFeasibilityPlantprjcost" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="text-align: center" class="auto-style6">
                                    <b>Sub Total Rs.</b>
                                </td>
                                <td>
                                    <u><span>
                                        <asp:Label ID="lblPlantSubTotal" runat="server"></asp:Label>
                                    </span></u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    iii. As recommended by G.M.,DIC
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblRecomGmPlant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    iv. As per the M/C Statement(s) certified by fin.Instn in case aided units.<br />
                                    As per M/C statement supported by copies of purchase invoices and certified by G.M
                                    <br />
                                    (in case of financed/financed through public issues without any loan).
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPlantMCstatements" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    v. As per C.A. Certificate
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPlantCACerti" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    vi. Whether technical know-how & feasibility & turnkey charges capitilised
                                    <br />
                                    and Certificate to this effect produced from C.A.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPlantCapitalisCerti" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    vii.Computed value in Rs.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblComputdValuePlant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style6">
                                    viii.Reasons of Variations with that of G.M. recommendation.
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblGmrecommnPlant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <div align="center" id="trproporalexisting" runat="server">
                                <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td class="auto-style10">
                                        </td>
                                        <td align="center" style="color: black" class="auto-style5">
                                            <b><u>D.ABSTRACT</u></b>
                                        </td>
                                    </tr>
                                    <%--  <tr>

                                        <td>Building (in Lakhs.) </td>
                                        <td>&nbsp;</td>
                                        <td>Plant and Machinery(in Lakhs.)</td>
                                        <td>&nbsp;</td>
                                    </tr>--%>
                                    <tr>
                                        <td class="auto-style10">
                                        </td>
                                        <td class="auto-style5">
                                        </td>
                                        <td style="font-weight: bold">
                                            <u>As per approved costs</u>
                                        </td>
                                        <td style="font-weight: bold">
                                            <u>Computed as eligible investment</u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">
                                        </td>
                                        <td class="auto-style5">
                                            i) Land
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLandCost_Abstract" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblComputedLandValue_Abstract" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">
                                        </td>
                                        <td class="auto-style5">
                                            ii) Building
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBuldingCost_Abstract" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblComputedBuildingValue_Abstract" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">
                                        </td>
                                        <td class="auto-style5">
                                            iii) Plant and Machinery
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPlantCost_Abstract" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblComputedtPlantlValue_Abstract" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">
                                        </td>
                                        <td class="auto-style5">
                                            iv) Technical Know-how feasibility study<br />
                                            and turn Key Charges
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFeasibilityCharges_Abstract" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFeasibilityComputedCharges_Abstract" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2%">
                                        </td>
                                        <td style="font-weight: bold; text-align: center" class="auto-style10">
                                            TOTAL
                                        </td>
                                        <td>
                                            <u>
                                                <asp:Label ID="lblTotApproveInvest_Abstract" runat="server"></asp:Label></u>
                                        </td>
                                        <td>
                                            <u>
                                                <asp:Label ID="lblComputedTotalValue_Abstract" runat="server"></asp:Label></u>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                        </div>
                    </div>
                    <br />
                    <div id="Div1" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="text-align: left; color: black; font-weight: bold;" class="auto-style8">
                                    3.0 <u>REMARKS </u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    3.1 Second Hand Machinery (Value in Rs.)
                                </td>
                                <td>
                                    <asp:Label ID="lblSecondHandMchValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    3.2 Social Status
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    3.3 Belated Claim(%Reduction)
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblBelatedClaim" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    3.4 Amt of Subsidy already availed/ availing in Rs.
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblAvailedSubsidy" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <u>3.5 Conditions to be fulfilled</u>
                                </td>
                                <td class="auto-style7">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    Date upto Which unit shall be in Continous production
                                    <br />
                                    and shall not change Management.
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblDateofProdctn" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div align="center" id="Div2" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style3">
                                    3.6 <u>EXPANSION/DIVERSIFICATION CASES </u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" class="auto-style16">
                                    a. Investment prior to E/D in Rs.
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblInvestPriorED" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" class="auto-style16">
                                    b. Investment under to E/D in Rs.
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblInvestUnderED" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" class="auto-style16">
                                    c. % Increase in Investment under E/D
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblIncreaseInvestnED" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" class="auto-style16">
                                    d. Production Capacity prior to E/D
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblProdCapcityED" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" class="auto-style16">
                                    e. Additional Capacity proposed under E/D
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblAddinCapacityED" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="2" class="auto-style16">
                                    f. % Increase in Capacity under E/D
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblIncresCapcityUndrED" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div align="center" id="Div3" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    a) Investment Subsidy @ Eligible %
                                </td>
                                <td>
                                    <asp:Label ID="lblPercent" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    b) State Investment Subsidy in Rs.
                                </td>
                                <td>
                                    <asp:Label ID="lblStateInvesSubsidy" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    c) Addl Sub. for Women in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblAddlSubWomen" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    d) Application Type
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblapplicationtype_IS" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    e) Is LMV or NONLMV
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbllmvornonlmv" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    f) Is Men or Women
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblmenorwomen" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    g) Percentage(%).
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblpercentage_is" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    h) Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLREMARKS" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblEligi_TotalSubsidy" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divLandconversion" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Land measuring in Square meters
                                </td>
                                <td>
                                    <asp:Label ID="lblLConLandMeasure" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Land Conversion Charges Paid:
                                </td>
                                <td>
                                    <asp:Label ID="LblLconPurchaseValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Building plinth Area in Square meters
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconBuildingPlnth" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Five Times plinth area:
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblfietimesplintharea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Land Area Considered:
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconLandValueComputed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Proportionate Land Conversion Charges
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconProportionate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 (25 %) on computed value in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconTwntyFveComputed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Value Recommended by GM
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconValueGMRecom" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Elegible Land conversion charges in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLConEligibleLandConversion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.10 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconClaimType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.11 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLREMARKS_LANDCONVERSION" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divmortgage" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Name of the Financial Institution
                                </td>
                                <td>
                                    <asp:Label ID="lblMortFinancialIns" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Term Loan Sacnctioned
                                </td>
                                <td>
                                    <asp:Label ID="lblMortTermLoan" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Mortgage Duty Paid
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortMortgageDutyPaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Term Loan availed by Unit
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortTermloanAvailed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Proportionate Mortgage Duty
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortProportionateMortgage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Mortgage Duty Recommended by GM
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortMortgageDuty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 Elegible for Reimbursement of Mortgage Duty in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortElgibleReimbursement" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortTypeofClaim" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_mortegage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divlandcost" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Land Purchase in Sq. Mts.
                                </td>
                                <td>
                                    <asp:Label ID="lblLcLandPurchase" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Land Value in Rs
                                </td>
                                <td>
                                    <asp:Label ID="lblLCLandvalue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Plinth Area in Sq.Mts.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCPlnthArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Five times of Builtup Area (Sq.Mts.)
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCfiveTimes" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Proportionate value in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCProportionate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Value recommended by G.M., DIC. in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCValueRecmGM" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 Eligible Land Cost in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCEligibleLandCost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclainlandcost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_landcost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divStampduty" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Land measuring in Sq. Mts.
                                </td>
                                <td>
                                    <asp:Label ID="lblSDLandmeasuring" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Stamp duty paid by the unit in Rs.
                                </td>
                                <td>
                                    <asp:Label ID="lblSDStampduty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Building plinth area in Sq.Mts.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDBuildingPlinth" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Building plinth area 5 times (Sq.Mts.)
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDBuildingplnthfvTimes" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Proportionate value for the area in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDProportionateVAlue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Value recommended by G.M., DIC. in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDValueRecomndGM" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 Value Computed in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDValueComputed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLTYPEOFCLAIM_STAMPDUTY" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_stampduty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="DIVQUALITYCERTIFICATION" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>QUALITY CERTIFICATION </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Quality certification charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lblqualitycertificationcgargespaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 50% of amount of certification charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lblfiftypercentage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 G.M Recommended Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecomamount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Eligible amount whichever is less
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbllesselegibleamount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclaim_quality" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_qualitycertification" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="DIVSALESTAX" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    i. Scheme Type
                                </td>
                                <td>
                                    <asp:Label ID="LBLSCHEMETYPE" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    ii. Application Type
                                </td>
                                <td>
                                    <asp:Label ID="lblapplicationtype" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    iii. Production
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblproduction" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    iv. Tax Paid
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltaxpaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    v. Base Production
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblbaseproduction" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    vi. Eligible Production Quantity over and the above base production
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblelgprodqty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    vii. Proportionate SGST value on eligible prodution
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblproportionatesgst" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    viii. Category
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblcategory" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    ix. Percentage
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblpercentage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trcapitaleligibleinvestment">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    x. Total Capital Eligible Investment
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblcapitalelginvestment" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trsalestaxsanctionedonthisclaim">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xi. Total Sales Tax Already Sanctioned Prior to This Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblsalestaxsanctioned" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xii. GM Recommended Value
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecommendedvalue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xiii. Eligible Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbleligibleamount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xiv. Type of claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclaim" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xv. Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_salestax" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div align="center" id="div_pallavaddi" visible="false" runat="server">


                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">
                                    <u>ELIGIBLE INCENTIVES </u>
                                </td>
                            </tr>
                        </table>
                          <table style="width: 100%">
                            <tr>
                                <td></td>
                                <td colspan="4">
                                    <asp:GridView ID="grd_claimperiodofloanadd" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                        AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="true" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sr.#
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Claim Period
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:HiddenField ID="hf_claimperiodofloanaddIncentiveId" Value='<%# Eval("Incentiveid") %>' runat="server" />
                                                         <asp:HiddenField ID="hf_claimperiodofloanaddFinancialYear" Value='<%# Eval("FinancialYear") %>' runat="server" />
                                                        <asp:HiddenField ID="hf_claimperiodofloanadd_ID" Value='<%# Eval("ClaimPeriodID") %>' runat="server" />--%>
                                                    <%# Eval("ClaimPeriodName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    No of Loans Applied for this Claim
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Eval("LoanCount") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="gridview"></PagerStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td></td>
                                <td colspan="4">
  <asp:GridView ID="grd_eglibilepallavaddi" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                           
                                            AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="true"  EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" >
                                            <Columns>
                                                   <asp:TemplateField>
                                                  
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hf_grdeglibilepallavaddiFY_ID" Value='<%# Eval("ClaimPeriodID") %>' runat="server" />
                                                        <table>
                                                            <tr>
                                                                <th style="font-family: Calibri"><%#Container.DataItemIndex+1 %> Claim Period:   
                                                                     <asp:Label ID="lbl_grdeglibilepallavaddiFYname" Text='<%# Eval("ClaimPeriodName") %>' runat="server"></asp:Label>
                                                                </th>
                                                                <th style="font-family: Calibri"></th>
                                                                <th style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;  Loan-
                                                                     <asp:Label ID="lbl_claimeglibleincentivesloanwiseLoanID" Text='<%# Eval("LoanNumber") %>' runat="server"></asp:Label></th>
                                                                <th style="font-family: Calibri"></th>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Date of Commencement of activity:</b></td>
                                                                <td style="font-family: Calibri">
                                                                   <%# Eval("dcpdate") %>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Loan installment start Date</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <%# Eval("loaninstallmentstartdate") %>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Total Term Loan Availed(In Rs.)</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <%# Eval("tottermloanavil") %>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Period of installment</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <%# Eval("Periodofinstallmentname") %>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>No of installment</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <%# Eval("Noofinstallmentforloan") %>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Installment amount</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <%# Eval("Installmentamountforloan") %>
                                                                    <br />
                                                                </td>

                                                            </tr>
                                                           
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>No of installments completed</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <%# Eval("NoofinstallmentcompletedfortheloanFY") %>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>PrincipalAmount become DUE before this HALFYEAR</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <%# Eval("principalamountdueforhalfyrFY") %>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <table border="1" width="100%" align="center" cellpadding="10" cellspacing="5">
                                                                        <tr style="column-rule-style: solid">
                                                                            <th style="font-family: Calibri">Sr.#	</th>
                                                                            <th style="font-family: Calibri">Period of Claim</th>
                                                                            <th style="font-family: Calibri">Principal amounnt due</th>

                                                                            <th style="font-family: Calibri">No of Installment</th>
                                                                            <th style="font-family: Calibri">Rate of Interest</th>
                                                                            <th style="font-family: Calibri">Interest due</th>

                                                                            <th style="font-family: Calibri">Unit Holder  Contribution</th>
                                                                            <th style="font-family: Calibri">Eligible Rate of interest</th>
                                                                            <th style="font-family: Calibri">Eligible Interest Amount</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">1</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthoneid" Value='<%# Eval("PeriodofClaimMonth1ID") %>' runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthonename" Text='<%# Eval("PeriodofClaimMonth1Name") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthnonePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth1") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneNoofInstallment" Text='<%# Eval("NoofInstallmentMonth1") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                  <asp:Label ID="lbl_grd_monthoneRateofinterest" Text='<%# Eval("rateofinterestMonth1") %>' runat="server"></asp:Label>
                                                                                
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneInterestamount" Text='<%# Eval("interestamountMonth1") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneUnitHolderContribution" Text='<%# Eval("unitholdercontMonth1") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth1") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthoneEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth1") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">2</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthtwoid" Value='<%# Eval("PeriodofClaimMonth2ID") %>' runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthtwoname" Text='<%# Eval("PeriodofClaimMonth2Name") %>' runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth2") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoNoofInstallment" Text='<%# Eval("NoofInstallmentMonth2") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                 <asp:Label ID="lbl_grd_monthtwoRateofinterest" Text='<%# Eval("rateofinterestMonth2") %>' runat="server"></asp:Label>
                                                                             
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoInterestamount" Text='<%# Eval("interestamountMonth2") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoUnitHolderContribution" Text='<%# Eval("unitholdercontMonth2") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth2") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthtwoEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth2") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">3</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monththreeid"  Value='<%# Eval("PeriodofClaimMonth3ID") %>' runat="server" />
                                                                                <asp:Label ID="lbl_grd_monththreename" Text='<%# Eval("PeriodofClaimMonth3Name") %>'  runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeNoofInstallment" Text='<%# Eval("NoofInstallmentMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                  <asp:Label ID="lbl_grd_monththreeRateofinterest" Text='<%# Eval("rateofinterestMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeInterestamount" Text='<%# Eval("interestamountMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeUnitHolderContribution" Text='<%# Eval("unitholdercontMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monththreeEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth3") %>'  runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">4</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthfourid" Value='<%# Eval("PeriodofClaimMonth4ID") %>' runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthfourname" Text='<%# Eval("PeriodofClaimMonth4Name") %>' runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourNoofInstallment" Text='<%# Eval("NoofInstallmentMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourRateofinterest" Text='<%# Eval("rateofinterestMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourInterestamount" Text='<%# Eval("interestamountMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourUnitHolderContribution" Text='<%# Eval("unitholdercontMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfourEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth4") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">5</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthfiveid" Value='<%# Eval("PeriodofClaimMonth5ID") %>' runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthfivename" Text='<%# Eval("PeriodofClaimMonth5Name") %>' runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfivePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth5") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveNoofInstallment" Text='<%# Eval("NoofInstallmentMonth5") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                 <asp:Label ID="lbl_grd_monthfiveRateofinterest" Text='<%# Eval("rateofinterestMonth5") %>' runat="server"></asp:Label>
                                                                             
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveInterestamount" Text='<%# Eval("interestamountMonth5") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveUnitHolderContribution" Text='<%# Eval("unitholdercontMonth5") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth5") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthfiveEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth5") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-family: Calibri">6</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:HiddenField ID="hfgrd_monthsixid" Value='<%# Eval("PeriodofClaimMonth6ID") %>' runat="server" />
                                                                                <asp:Label ID="lbl_grd_monthsixname" Text='<%# Eval("PeriodofClaimMonth6Name") %>' runat="server"></asp:Label>

                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixNoofInstallment" Text='<%# Eval("NoofInstallmentMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                 <asp:Label ID="lbl_grd_monthsixRateofinterest" Text='<%# Eval("rateofinterestMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixInterestamount" Text='<%# Eval("interestamountMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixUnitHolderContribution" Text='<%# Eval("unitholdercontMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_monthsixEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth6") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                          <tr>
                                                                            <td style="font-family: Calibri">6</td>
                                                                            <td style="font-family: Calibri">
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                Total Interest Amount:
                                                                            </td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_totmonthsInterestamount"  Text='<%# Eval("totmonthsinterestamountMonth") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="font-family: Calibri"></td>
                                                                            <td style="font-family: Calibri">Total Eligible Interest Amount:</td>
                                                                            <td style="font-family: Calibri">
                                                                                <asp:Label ID="lbl_grd_totmonthsEligibleInterestAmount"  Text='<%# Eval("totmonthseligibleinterestamount") %>' runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td style="font-family: Calibri"><b>Eligible period in months</b>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">
                                                                    <br />
                                                                     <asp:Label ID="txt_grdeglibilepallavaddiEligibleperiodinmonths"  Text='<%# Eval("eligibleperiodinmonths") %>' runat="server"></asp:Label>
                                                                  
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Insert amount to be paid as per calculations</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations"  Text='<%# Eval("CPL_interestamountpaidaspercal") %>' runat="server"></asp:Label>
                                                                  
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Actual interest amount paid</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:Label ID="txt_grdeglibilepallavaddiActualinterestamountpaid"  Text='<%# Eval("CPL_actualinterestamountpaid") %>' runat="server"></asp:Label>
                                                                 
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                             <tr>
                                                                <td style="font-family: Calibri"><b>Rate of Interest</b></td>
                                                                <td style="font-family: Calibri">
                                                                    <asp:Label ID="txt_claimeglibleincentivesloanwiseRateofInterest"  Text='<%# Eval("Rateofinterestforloan") %>' runat="server"></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Eligible rate of reimbursement</b></td>
                                                                <td style="font-family: Calibri">
                                                                      <asp:Label ID="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement"  Text='<%# Eval("Eligibleratereimbursementforlaon") %>' runat="server"></asp:Label>
                                                                 
                                                                    <br />
                                                                </td>

                                                            </tr>
                                                             <tr>
                                                                <td style="font-family: Calibri"><b>Considered Amount for Interest</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest"  Text='<%# Eval("CPL_Conamountforcalintreimberest") %>' runat="server"></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Interst reimbursement calculated</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="txt_grdeglibilepallavaddiInsertreimbursementcalculated"  Text='<%# Eval("CPL_interestreimbersementcal") %>' runat="server"></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Eligible Type</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="rbtgrdeglibilepallavaddi_isbelated"  Text='<%# Eval("CPL_ELIGIBLETYPEName") %>' runat="server"></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Interst reimbursement(After selecting the eglible Type)</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype"  Text='<%# Eval("CPL_interestreimbersementcal_finaleligibletype") %>' runat="server"></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>GM recommended amount</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="txt_grdeglibilepallavaddiGMrecommendedamount"  Text='<%# Eval("CPL_gmrecommendedamount") %>' runat="server"></asp:Label>
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Calibri"><b>Eligible amount</b></td>
                                                                <td style="font-family: Calibri">
                                                                     <asp:Label ID="txt_grdeglibilepallavaddiEligibleamount"  Text='<%# Eval("CPL_FINALELIGIBLEAMOUNT") %>' runat="server"></asp:Label>
                                                                 
                                                                   
                                                                    <br />
                                                                </td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                          
                                                            <tr>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                                <td style="font-family: Calibri"></td>
                                                            </tr>
                                                        </table>
                                                      

                                                    </ItemTemplate>                                            
                                                </asp:TemplateField>    
                                            </Columns>
                                            <PagerStyle CssClass="gridview"></PagerStyle>
                                        </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Interest amount to be paid as per calculations</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertamounttobepaidaspercalculations" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Actual interest amount paid</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Actualinterestamountpaid" runat="server" Height="28px"
                                        Width="180px"></asp:Label>

                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Considered Amount of Interest</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_ConsideredAmountofInterest" runat="server" Height="28px"
                                        Width="180px"></asp:Label>

                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Interst reimbursement calculated</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertreimbursementcalculated" runat="server" Height="28px"
                                        Width="180px"></asp:Label>

                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Interst reimbursement(After selecting the eglible Type)</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server" RepeatDirection="Horizontal" Height="33px" Width="200px">
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">GM recommended amount</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_GMrecommendedamount" runat="server" Height="28px" Width="180px"></asp:Label>

                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Eligible amount</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">

                                    <asp:Label ID="txt_Eligibleamount" runat="server" Height="28px" Width="180px"></asp:Label>

                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Remarks given by Clerk</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">

                                    <asp:Label ID="lbl_pavallavaddiremarksbyclerk" runat="server" Height="28px" Width="180px"></asp:Label>

                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                        </table>

                        <%--  <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">
                                    <u>ELIGIBLE INCENTIVES </u>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    1.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Total Term Loan Availed(Value in Rs.)
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_eglsacamountinterestreimbursement" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    2.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Date of Commencement of activity
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_DateofCommencementofactivity" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>3.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Period of installment
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="ddl_periodofinstallment" runat="server" Height="33px" Width="180px">
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    4.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Date from which installment starts
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_installmentstartdate" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    5.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    No of installment
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_noofinstallment" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>6.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Installment amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="txt_Installmentamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>7.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Rate of Interest
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="txt_RateofInterest" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    8.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible rate of reimbursement
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligiblerateofreimbursement" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>9.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Claim Period
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="ddl_ClaimPeriod" runat="server" Height="33px" Visible="true" Width="180px">
                              
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>10.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    No of installments completed
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="txt_Noofinstallmentscompleted" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    11.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Principal amount become DUE before this HALF YEAR
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_PrincipalamountbecomeDUEbeforethisHALFYEAR" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:GridView ID="grd_financalyeargrid" runat="server" CssClass="table table-small-font table-bordered table-striped"
                                        AutoGenerateColumns="false" OnRowDataBound="grd_financalyeargrid_RowDataBound"
                                        GridLines="Both" ShowHeaderWhenEmpty="true" ShowFooter="true" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                        <Columns>
                                            <%--  <asp:BoundField ItemStyle-Width="150px" DataField="CLAIMPERIODName_Grid" HeaderText="Finaincal" />--%>
                        <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <b>
                                                        <asp:Label ID="lbl_data" Text='<%# Eval("CLAIMPERIODName_Grid") %>' runat="server"></asp:Label></b>
                                                    <br />
                                                    <asp:GridView ID="grd_Addclaimperiod" runat="server" CssClass="table table-small-font table-bordered table-striped"
                                                        AutoGenerateColumns="false" AllowPaging="true" ShowHeaderWhenEmpty="true" ShowFooter="true"
                                                        EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" PageSize="50">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Sr.#
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Claim Period
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("CLAIMPERIODName_Grid") %>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Period of Claim/Month wise
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("PERIODOFCLAIM_MONTHWISE_VALUE_GRID") %>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Principal amounnt due
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("PRINCIPALAMOUNTDUE_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    No of Installment
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("NOOFINSTALLMENT_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Interest amount
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("INTERESTAMOUNT_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <%-- <PagerStyle CssClass="gridview"></PagerStyle>--%>
                        <%--  </asp:GridView>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />--%>
                        <%-- <table style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible period in months
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligibleperiodinmonths" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Insert amount to be paid as per calculations
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertamounttobepaidaspercalculations" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Actual interest amount paid
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Actualinterestamountpaid" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interst reimbursement calculated
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertreimbursementcalculated" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible Type
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="rbtgrd_isbelated" runat="server" RepeatDirection="Horizontal" Height="33px"
                                        Width="200px">
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interst reimbursement(After selecting the eglible Type)
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    GM recommended amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_GMrecommendedamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligibleamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>--%>
                    </div> 

                    <div>
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr runat="server" visible="false" id="trAsperDecisionIS">
                                <td style="width: 2%">
                                </td>
                                <td style="width: 3%">
                                    5)
                                </td>
                                <td>
                                    As per the decision taken by the SLC in its meeting held on
                                    <asp:Label ID="lblSLCDate" runat="server"></asp:Label>, the claim application may
                                    be referred to the Constituted Committee of Investment Subsidy
                                    <br />
                                    for scrutinise/verification please.
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td class="auto-style11">
                                </td>
                                <td style="height: 70px; vertical-align: bottom; border: 1px">
                                    Assistant Director
                                </td>
                                <td style="height: 70px; vertical-align: bottom; border: 1px">
                                    Dy. Director
                                </td>
                                <td style="height: 70px; vertical-align: bottom; border: 1px">
                                    Joint Director(II)
                                </td>
                                <td style="height: 70px; vertical-align: bottom; border: 1px">
                                    Addl. Director
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid;
                        border-left: thin solid; border-bottom: thin solid" type="button" value="Print" />
                    &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                </div>
            </div>
        </div>
    </form>
</body>
