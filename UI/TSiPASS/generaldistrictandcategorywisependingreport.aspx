<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="generaldistrictandcategorywisependingreport.aspx.cs"
    inherits="UI_TSiPASS_generaldistrictandcategorywisependingreport" enableeventvalidation="false" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PrintPendingReport() {
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            if (!panel) return false;

            var printWindow = window.open('', '', 'height=600,width=1100');
            printWindow.document.write('<html><head><title>T-IDEA/TTAP Incentives Release Pending</title>');
            printWindow.document.write('<style>table{width:100%;border-collapse:collapse;font-family:Arial;font-size:11px;} th,td{border:1px solid #777;padding:4px;text-align:center;} .district-column{text-align:left;font-weight:bold;}</style>');
            printWindow.document.write('</head><body>');
            printWindow.document.write('<h3 style="text-align:center;">Government of Telangana</h3>');
            printWindow.document.write('<h4 style="text-align:center;">T-IDEA/TTAP Incentives Release Pending</h4>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                printWindow.close();
            }, 800);
            return false;
        }

        $(function () {
            $('#MstLftMenu').remove();
        });
    </script>

    <style type="text/css">
        .report-grid {
            width: 100% !important;
             min-width: 1500px;
            border-collapse: collapse;
            table-layout: fixed;
            font-family: 'Trebuchet MS', Arial, sans-serif;
            font-size: 11px;
        }

            .report-grid th,
            .report-grid td {
                border: 1px solid #777777;
                padding: 5px 3px;
                text-align: center;
                vertical-align: middle;
                white-space: normal;
                word-wrap: break-word;
            }

        .main-header {
            background-color: #f3f3f3 !important;
            color: #000000 !important;
            font-size: 13px;
            font-weight: bold;
            text-align: center;
            border-bottom: 2px solid #777777;
        }

        .category-empty {
            background-color: #ffffff !important;
        }

        .sub-header th {
            background-color: #fafafa !important;
            color: #000000 !important;
            font-size: 11px;
            font-weight: bold;
            text-align: center;
            vertical-align: middle;
            line-height: 1.3;
            padding: 6px 4px;
        }

            .sub-header th.district-column {
                text-align: left;
            }

        .report-grid td {
            background-color: #ffffff;
            color: #000000;
            font-size: 11px;
        }

        .report-grid tr:nth-child(even) td {
            background-color: #f8f8f8;
        }

        .report-grid tr:hover td {
            background-color: #fff4cc;
        }

        .slno-column {
            width: 4%;
            text-align: center !important;
        }

        .district-id-column {
            width: 5%;
            text-align: center !important;
        }

        .district-column {
            width: 12%;
            text-align: left !important;
            font-weight: bold;
        }

        .units-column {
            width: 5%;
        }

        .claims-column {
            width: 5%;
        }

        .amount-column {
            width: 6.6%;
        }

        .claim-link {
            color: #0000cc;
            font-weight: bold;
            text-decoration: underline;
        }

        .total-row td {
            background-color: #eeeeee !important;
            color: #000000;
            font-weight: bold;
            text-align: center;
            border: 1px solid #555555;
        }

            .total-row td:nth-child(2) {
                text-align: right;
                padding-right: 10px;
            }

        .report-toolbar td {
            padding: 5px;
        }
    </style>
    <style type="text/css">
        /* Main Grid Wrapper & Layout */
        .report-grid {
            width: 100% !important;
            border-collapse: separate !important; /* Allows rounded corners to render correctly */
            border-spacing: 0;
            table-layout: fixed;
            font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, Helvetica, Arial, sans-serif;
            font-size: 12px;
            color: #2d3748;
            background-color: #ffffff;
            border: 1px solid #e2e8f0 !important;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.05), 0 2px 4px -1px rgba(0, 0, 0, 0.03);
        }

            /* Universal Cell Padding & Soft Gridlines */
            .report-grid th,
            .report-grid td {
                border-right: 1px solid #edf2f7 !important;
                border-bottom: 1px solid #edf2f7 !important;
                padding: 12px 8px;
                text-align: center;
                vertical-align: middle;
                white-space: normal;
                word-wrap: break-word;
                transition: background-color 0.15s ease;
            }

                .report-grid th:last-child,
                .report-grid td:last-child {
                    border-right: none !important;
                }

        /* Primary Category Header (MICRO, SMALL, etc.) */
        .main-header {
            background-color: #1e293b !important; /* Deep charcoal/slate profile */
            color: #ffffff !important;
            font-size: 12px;
            font-weight: 600;
            text-transform: uppercase;
            letter-spacing: 0.75px;
            padding: 14px 8px !important;
            border-bottom: 2px solid #0f172a !important;
        }

        /* Secondary Headers (No of Units, Claims, Amount) */
        .sub-header th {
            background-color: #f8fafc !important;
            color: #64748b !important;
            font-size: 11px;
            font-weight: 600;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            padding: 10px 6px !important;
            border-bottom: 2px solid #e2e8f0 !important;
        }

            .sub-header th.district-column {
                text-align: left !important;
                padding-left: 16px !important;
            }

        /* Row Alternation for High-Density Readability */
        .report-grid tr:nth-child(even) td {
            background-color: #f8fafc;
        }

        /* Velvet Hover Indicator */
        .report-grid tr:hover td {
            background-color: #f0f7ff !important; /* Elegant light blue tracing color */
        }

        /* Column Specific Formatting rules */
        .slno-column {
            width: 4%;
            text-align: center !important;
            color: #94a3b8 !important;
            font-weight: 500;
        }

        .district-id-column {
            width: 5%;
        }

        .district-column {
            width: 14%;
            text-align: left !important;
            font-weight: 600;
            color: #0f172a;
            padding-left: 16px !important;
        }

        .units-column {
            width: 5.5%;
            color: #334155;
        }

        .claims-column {
            width: 5.5%;
        }

        .amount-column {
            width: 7%;
            font-weight: 500;
            color: #0f172a;
        }

        /* Styled Interactive Action Items (Claims Links) */
        .claim-link {
            color: #2563eb !important; /* Modern system blue link */
            font-weight: 600;
            text-decoration: none !important;
            padding: 4px 8px;
            border-radius: 4px;
            background-color: rgba(37, 99, 235, 0.04);
            display: inline-block;
            transition: all 0.2s ease;
        }

            .claim-link:hover {
                color: #1d4ed8 !important;
                background-color: rgba(37, 99, 235, 0.12);
                text-decoration: none !important;
            }

        /* Summary/Total Aggator Row Styling */
        .total-row td {
            background-color: #e2e8f0 !important;
            color: #0f172a !important;
            font-weight: 700 !important;
            border-top: 2px solid #cbd5e1 !important;
            border-bottom: none !important;
            padding: 14px 8px !important;
        }

            .total-row td:nth-child(2) {
                text-align: right !important;
                padding-right: 20px !important;
            }

        /* Structural Container Polish */
        .panel-default {
            border: 1px solid #e2e8f0;
            border-radius: 12px;
            background-color: #ffffff;
            box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px -1px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }

        .panel-heading {
            background-color: #ffffff !important;
            border-bottom: 1px solid #f1f5f9 !important;
            padding: 20px !important;
        }

        .panel-title {
            color: #0f172a !important;
            font-size: 16px !important;
            letter-spacing: -0.025em;
        }
    </style>
    <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center;">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:label id="lblHeading" runat="server" text="T-IDEA/TTAP Incentives District Wise Release Pending"></asp:label>
                            <a id="lnkPrint" href="#" visible="false" onclick="javascript:return PrintPendingReport();" runat="server">
                                <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="Print" width="30" height="30" style="float: right;" />
                            </a>
                            <asp:linkbutton id="btnExportExcel" visible="false" runat="server" onclick="btnExportExcel_Click" causesvalidation="false" style="float: right; margin-right: 8px;">
                                <img src="../../Resource/Images/Excel-icon.png" alt="Excel" width="20" height="20" />
                            </asp:linkbutton>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="8" cellspacing="4" style="width: 100%; font-family: 'Trebuchet MS';">
                            <tr class="report-toolbar">
                                <td align="left">
                                    <asp:hyperlink cssclass="btn btn-link" id="lnkBack" runat="server"
                                        navigateurl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx" text="&lt;&lt; Back" />
                                </td>
                                <td align="right">
                                    <asp:button id="btnRefresh" runat="server" cssclass="btn btn-default" text="Refresh"
                                        onclick="btnRefresh_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right" style="padding-right: 10px;">
                                    <asp:label id="lblReportDate" runat="server" cssclass="LBLBLACK"></asp:label>
                                </td>
                            </tr>
                            <tr id="divPrint" runat="server">
                                <td align="center" colspan="2" style="padding: 5px;">
                                    <div style="width: 100%; overflow-x: auto;">
                                        <asp:gridview id="gvPendingReport" runat="server" width="100%" autogeneratecolumns="False"
                                            cssclass="report-grid table table-bordered table-striped" gridlines="None"
                                            showheader="True" showfooter="True" cellpadding="4"
                                            onrowcreated="gvPendingReport_RowCreated"
                                            onrowdatabound="gvPendingReport_RowDataBound"
                                            onrowcommand="gvPendingReport_RowCommand">
                                            <headerstyle cssclass="GridviewScrollC1HeaderWrap" />
                                            <rowstyle cssclass="GridviewScrollC1Item" />
                                            <footerstyle cssclass="GridviewScrollC1Header" />
                                            <alternatingrowstyle cssclass="GridviewScrollC1Item2" />
                                            <columns>
                                                <asp:templatefield headertext="Slno">
                                                    <itemtemplate><%# Container.DataItemIndex + 1 %></itemtemplate>
                                                    <headerstyle cssclass="slno-column" />
                                                    <itemstyle cssclass="slno-column" />
                                                    <footerstyle cssclass="slno-column" />
                                                </asp:templatefield>

                                                <asp:boundfield datafield="DISTRICT" headertext="District" visible="false">
                                                    <headerstyle cssclass="district-id-column" />
                                                    <itemstyle cssclass="district-id-column" />
                                                    <footerstyle cssclass="district-id-column" />
                                                </asp:boundfield>

                                                <asp:boundfield datafield="District_Name" headertext="District Name">
                                                    <headerstyle cssclass="district-column" />
                                                    <itemstyle cssclass="district-column" />
                                                    <footerstyle cssclass="district-column" />
                                                </asp:boundfield>

                                                <asp:boundfield datafield="MicroUnits" headertext="No of Units">
                                                    <headerstyle cssclass="units-column" />
                                                    <itemstyle cssclass="units-column" />
                                                </asp:boundfield>
                                                <asp:templatefield headertext="No of Claims">
                                                    <itemtemplate>
                                                        <asp:linkbutton id="lnkMicroClaims" runat="server" cssclass="claim-link"
                                                            text='<%# Eval("MicroClaims") %>' commandname="ViewClaims"
                                                            commandargument='<%# Eval("DISTRICT") + "|" + Eval("District_Name") + "|MICRO" %>' causesvalidation="false" />
                                                    </itemtemplate>
                                                    <headerstyle cssclass="claims-column" />
                                                    <itemstyle cssclass="claims-column" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="MicroAmount" headertext="Sanctioned Amount (in Cr)" dataformatstring="{0:0.##}">
                                                    <headerstyle cssclass="amount-column" />
                                                    <itemstyle cssclass="amount-column" />
                                                </asp:boundfield>

                                                <asp:boundfield datafield="SmallUnits" headertext="No of Units">
                                                    <headerstyle cssclass="units-column" />
                                                    <itemstyle cssclass="units-column" />
                                                </asp:boundfield>
                                                <asp:templatefield headertext="No of Claims">
                                                    <itemtemplate>
                                                        <asp:linkbutton id="lnkSmallClaims" runat="server" cssclass="claim-link"
                                                            text='<%# Eval("SmallClaims") %>' commandname="ViewClaims"
                                                            commandargument='<%# Eval("DISTRICT") + "|" + Eval("District_Name") + "|SMALL" %>' causesvalidation="false" />
                                                    </itemtemplate>
                                                    <headerstyle cssclass="claims-column" />
                                                    <itemstyle cssclass="claims-column" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="SmallAmount" headertext="Sanctioned Amount (in Cr)" dataformatstring="{0:0.##}">
                                                    <headerstyle cssclass="amount-column" />
                                                    <itemstyle cssclass="amount-column" />
                                                </asp:boundfield>

                                                <asp:boundfield datafield="MediumUnits" headertext="No of Units">
                                                    <headerstyle cssclass="units-column" />
                                                    <itemstyle cssclass="units-column" />
                                                </asp:boundfield>
                                                <asp:templatefield headertext="No of Claims">
                                                    <itemtemplate>
                                                        <asp:linkbutton id="lnkMediumClaims" runat="server" cssclass="claim-link"
                                                            text='<%# Eval("MediumClaims") %>' commandname="ViewClaims"
                                                            commandargument='<%# Eval("DISTRICT") + "|" + Eval("District_Name") + "|MEDIUM" %>' causesvalidation="false" />
                                                    </itemtemplate>
                                                    <headerstyle cssclass="claims-column" />
                                                    <itemstyle cssclass="claims-column" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="MediumAmount" headertext="Sanctioned Amount (in Cr)" dataformatstring="{0:0.##}">
                                                    <headerstyle cssclass="amount-column" />
                                                    <itemstyle cssclass="amount-column" />
                                                </asp:boundfield>

                                                <asp:boundfield datafield="LargeUnits" headertext="No of Units">
                                                    <headerstyle cssclass="units-column" />
                                                    <itemstyle cssclass="units-column" />
                                                </asp:boundfield>
                                                <asp:templatefield headertext="No of Claims">
                                                    <itemtemplate>
                                                        <asp:linkbutton id="lnkLargeClaims" runat="server" cssclass="claim-link"
                                                            text='<%# Eval("LargeClaims") %>' commandname="ViewClaims"
                                                            commandargument='<%# Eval("DISTRICT") + "|" + Eval("District_Name") + "|LARGE" %>' causesvalidation="false" />
                                                    </itemtemplate>
                                                    <headerstyle cssclass="claims-column" />
                                                    <itemstyle cssclass="claims-column" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="LargeAmount" headertext="Sanctioned Amount (in Cr)" dataformatstring="{0:0.##}">
                                                    <headerstyle cssclass="amount-column" />
                                                    <itemstyle cssclass="amount-column" />
                                                </asp:boundfield>

                                                <asp:boundfield datafield="MegaUnits" headertext="No of Units">
                                                    <headerstyle cssclass="units-column" />
                                                    <itemstyle cssclass="units-column" />
                                                </asp:boundfield>
                                                <asp:templatefield headertext="No of Claims">
                                                    <itemtemplate>
                                                        <asp:linkbutton id="lnkMegaClaims" runat="server" cssclass="claim-link"
                                                            text='<%# Eval("MegaClaims") %>' commandname="ViewClaims"
                                                            commandargument='<%# Eval("DISTRICT") + "|" + Eval("District_Name") + "|MEGA" %>' causesvalidation="false" />
                                                    </itemtemplate>
                                                    <headerstyle cssclass="claims-column" />
                                                    <itemstyle cssclass="claims-column" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="MegaAmount" headertext="Sanctioned Amount (in Cr)" dataformatstring="{0:0.##}">
                                                    <headerstyle cssclass="amount-column" />
                                                    <itemstyle cssclass="amount-column" />
                                                </asp:boundfield>

                                                <%-- TOTAL (all 5 categories) --%>
                                                <asp:templatefield headertext="No of Units">
                                                    <itemtemplate>
                                                        <asp:label id="lblTotalUnits" runat="server"></asp:label>
                                                    </itemtemplate>
                                                    <headerstyle cssclass="units-column" />
                                                    <itemstyle cssclass="units-column" />
                                                    <footerstyle cssclass="units-column" />
                                                </asp:templatefield>
                                                <asp:templatefield headertext="No of Claims">
                                                    <itemtemplate>
                                                        <asp:label id="lblTotalClaims" runat="server"></asp:label>
                                                    </itemtemplate>
                                                    <headerstyle cssclass="claims-column" />
                                                    <itemstyle cssclass="claims-column" />
                                                    <footerstyle cssclass="claims-column" />
                                                </asp:templatefield>
                                                <asp:templatefield headertext="Sanctioned Amount in(Cr)">
                                                    <itemtemplate>
                                                        <asp:label id="lblTotalAmount" runat="server"></asp:label>
                                                    </itemtemplate>
                                                    <headerstyle cssclass="amount-column" />
                                                    <itemstyle cssclass="amount-column" />
                                                    <footerstyle cssclass="amount-column" />
                                                </asp:templatefield>
                                            </columns>
                                        </asp:gridview>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:content>
