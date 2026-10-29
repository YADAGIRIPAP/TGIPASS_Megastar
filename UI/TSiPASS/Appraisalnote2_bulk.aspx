<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Appraisalnote2_bulk.aspx.cs" Inherits="UI_TSiPASS_Appraisalnote2_bulk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<style type="text/css">
        .table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            text-align: left;
            border: 1px solid #777;
            padding: 6px;
        }
        .auto-style1 { width: 333px; }
        .auto-style2 { height: 35px; }
        .auto-style4 { height: 30px; }
        .auto-style8 { width: 38%; }
        .auto-style18 { height: 30px; width: 38%; }
        .auto-style20 { width: 25px; }
        .auto-style28 { width: 190px; }
        .auto-style29 { width: 160px; }
        
        .filter-panel {
            background-color: #f4f6f9;
            border: 1px solid #ced4da;
            padding: 15px;
            margin-bottom: 20px;
            font-family: Verdana;
            font-size: 13px;
        }
        .btn-action {
            padding: 6px 16px;
            font-weight: bold;
            cursor: pointer;
            border: none;
            border-radius: 3px;
        }
        
        /* Screen styling */
        .print-page {
            width: 100%;
            margin: 0 auto 30px auto;
            background-color: #fff;
            padding: 10px;
            box-sizing: border-box;
        }

        /* ================= PRINT BREAK RULES ================= */
        @media print {
            @page {
                size: A4 portrait;
                margin: 12mm 10mm 12mm 10mm;
            }

            html, body {
                margin: 0 !important;
                padding: 0 !important;
                background: #fff !important;
            }

            .no-print {
                display: none !important;
            }

            /* Forces each appraisal note to start on a brand-new printed page */
            .print-page {
                page-break-before: always !important;
                break-before: page !important;
                page-break-after: auto !important;
                break-after: auto !important;
                margin: 0 !important;
                padding: 0 !important;
                display: block !important;
                position: relative !important;
                float: none !important;
            }

            /* Prevents a leading blank page on the very first record */
            .print-page:first-of-type,
            .print-page:first-child {
                page-break-before: avoid !important;
                break-before: avoid !important;
            }

            /* Prevents mid-row table splitting */
            tr {
                page-break-inside: avoid !important;
                break-inside: avoid !important;
            }
            
            table {
                page-break-inside: auto;
            }
        }
    </style>--%>
<%--    <style type="text/css">
    /* Base Screen Styles */
    .table {
        border-collapse: collapse;
        width: 100%;
    }
    th, td {
        text-align: left;
        border: 1px solid #777;
        padding: 5px;
    }
    .auto-style1 { width: 333px; }
    .auto-style2 { height: 35px; }
    .auto-style4 { height: 30px; }
    .auto-style8 { width: 38%; }
    .auto-style18 { height: 30px; width: 38%; }
    .auto-style20 { width: 25px; }
    .auto-style28 { width: 190px; }
    .auto-style29 { width: 160px; }
    
    .filter-panel {
        background-color: #f4f6f9;
        border: 1px solid #ced4da;
        padding: 15px;
        margin-bottom: 20px;
        font-family: Verdana;
        font-size: 13px;
    }
    .btn-action {
        padding: 6px 16px;
        font-weight: bold;
        cursor: pointer;
        border: none;
        border-radius: 3px;
    }
    
    .print-page {
        width: 100%;
        margin: 0 auto 30px auto;
        background-color: #fff;
        padding: 10px;
        box-sizing: border-box;
    }

    /* ================= BULK PRINT PAGE BREAK FIX ================= */
    @media print {
        @page {
            size: A4 portrait;
            margin: 10mm 8mm 10mm 8mm; /* Provides safe print margins */
        }

        html, body {
            margin: 0 !important;
            padding: 0 !important;
            background: #fff !important;
            height: auto !important;
        }

        .no-print {
            display: none !important;
        }

        /* 1. Every note starts on its own sheet */
        .print-page {
            page-break-before: always !important;
            break-before: page !important;
            page-break-after: auto !important;
            break-after: auto !important;
            margin: 0 !important;
            padding-top: 5mm !important;
            display: block !important;
            float: none !important;
            clear: both !important;
            position: static !important;
        }

        /* 2. No blank sheet before the very first note */
        .print-page:first-of-type,
        .print-page:first-child {
            page-break-before: avoid !important;
            break-before: avoid !important;
            padding-top: 0 !important;
        }

        /* 3. Stop tables and sections from breaking ugly across pages */
        table {
            page-break-inside: auto;
            border-collapse: collapse !important;
        }

        tr {
            page-break-inside: avoid !important;
            break-inside: avoid !important;
        }

        /* 4. Prevent headers, logo, and summary rows from detaching */
        thead {
            display: table-header-group;
        }

        tfoot {
            display: table-footer-group;
        }

        /* 5. Prevent sub-scheme DIVs (Pavala Vaddi, Sales Tax, etc.) from splitting at edges */
        .print-page > div {
            page-break-inside: auto;
        }
    }
</style>--%>
    <style type="text/css">
    /* Base Screen Styles */
    .table {
        border-collapse: collapse;
        width: 100%;
    }
    th, td {
        text-align: left;
        border: 1px solid #777;
        padding: 5px;
    }
    .auto-style1 { width: 333px; }
    .auto-style2 { height: 35px; }
    .auto-style4 { height: 30px; }
    .auto-style8 { width: 38%; }
    .auto-style18 { height: 30px; width: 38%; }
    .auto-style20 { width: 25px; }
    .auto-style28 { width: 190px; }
    .auto-style29 { width: 160px; }
    
    .filter-panel {
        background-color: #f4f6f9;
        border: 1px solid #ced4da;
        padding: 15px;
        margin-bottom: 20px;
        font-family: Verdana;
        font-size: 13px;
    }
    .btn-action {
        padding: 6px 16px;
        font-weight: bold;
        cursor: pointer;
        border: none;
        border-radius: 3px;
    }
    
    .print-page {
        width: 100%;
        margin: 0 auto 30px auto;
        background-color: #fff;
        padding: 10px;
        box-sizing: border-box;
    }

    /* ================= BULK PRINT PAGE BREAK & GAP FIX ================= */
    @media print {
        @page {
            size: A4 portrait;
            margin: 8mm 6mm 8mm 6mm; /* Reduces margins to fit more content per page */
        }

        html, body {
            margin: 0 !important;
            padding: 0 !important;
            background: #fff !important;
            font-size: 11px !important;
            line-height: 1.2 !important;
        }

        .no-print {
            display: none !important;
        }

        /* Removes empty gap spaces created by <br> tags during printing */
        .print-page br {
            display: none !important;
        }

        /* 1. Each note starts on its own sheet */
        .print-page {
            page-break-before: always !important;
            break-before: page !important;
            page-break-after: auto !important;
            break-after: auto !important;
            margin: 0 !important;
            padding: 0 !important;
            display: block !important;
            float: none !important;
            clear: both !important;
            position: static !important;
        }

        /* 2. No blank sheet before the very first note */
        .print-page:first-of-type,
        .print-page:first-child {
            page-break-before: avoid !important;
            break-before: avoid !important;
        }

        /* 3. Allow tables and big outer rows to split naturally across pages */
        table {
            page-break-inside: auto !important;
            break-inside: auto !important;
            border-collapse: collapse !important;
            margin-bottom: 4px !important;
        }

        tr {
            page-break-inside: auto !important;
            break-inside: auto !important;
        }

        /* 4. Keep individual data rows intact without pushing the entire section to a new page */
        table tr:not(:has(table)) {
            page-break-inside: avoid !important;
            break-inside: avoid !important;
        }

        th, td {
            padding: 3px 4px !important;
            font-size: 10.5px !important;
        }

        thead {
            display: table-header-group;
        }

        tfoot {
            display: table-footer-group;
        }

        .print-page > div {
            page-break-inside: auto !important;
            break-inside: auto !important;
        }
    }
</style>
    <script type="text/javascript">
        function selectAllCheckboxes(headerChk) {
            var grid = document.getElementById('<%= gvApplications.ClientID %>');
            if (!grid) return;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type === "checkbox" && inputs[i] !== headerChk) {
                    inputs[i].checked = headerChk.checked;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <!-- ================= PANEL 1: SELECTION & DYNAMIC GRIDVIEW ================= -->
        <asp:Panel ID="pnlSelection" runat="server">
            <div class="filter-panel no-print">
                <table cellpadding="6" cellspacing="0">
                    <tr>
                        <td><strong>SVC Date:</strong></td>
                        <td>
                            <asp:DropDownList ID="ddlapplicationto" runat="server" Width="150px" CssClass="form-control txtbox" Height="33px">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td><strong>Category:</strong></td>
                        <td>
                            <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control txtbox" Height="33px" TabIndex="1" Width="160px">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">General</asp:ListItem>
                                <asp:ListItem Value="3">SC</asp:ListItem>
                                <asp:ListItem Value="4">ST</asp:ListItem>
                                <asp:ListItem Value="9">PHC</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td><strong>Type of Incentive:</strong></td>
                        <td>
                            <asp:DropDownList ID="ddlincentivetype" runat="server" CssClass="form-control txtbox" Height="33px" TabIndex="1" Width="200px">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Pavalla vaddi</asp:ListItem>
                                <asp:ListItem Value="3">Power Cost Reimbursement</asp:ListItem>
                                <asp:ListItem Value="4">Specific Cleaner Production</asp:ListItem>
                                <asp:ListItem Value="5">Sales TAX(VAT/GST/SGST) Reimbursement</asp:ListItem>
                                <asp:ListItem Value="6">Investment Subsidy</asp:ListItem>
                                <asp:ListItem Value="7">Industrial Infrastructure Development Fund(IIDF)</asp:ListItem>
                                <asp:ListItem Value="8">Skill Upgradation and Training</asp:ListItem>
                                <asp:ListItem Value="11">Quality Certification/Patent Registration</asp:ListItem>
                                <asp:ListItem Value="14">Stamp Duty/Transfer Duty</asp:ListItem>
                                <asp:ListItem Value="15">Reimbursement of Mortgage</asp:ListItem>
                                <asp:ListItem Value="16">Reimbursement of Land Conversion</asp:ListItem>
                                <asp:ListItem Value="17">Reimbursement of Land Cost</asp:ListItem>
                                <asp:ListItem Value="18">Reimbursement of Coal</asp:ListItem>
                                <asp:ListItem Value="19">Reimbursement of Wood</asp:ListItem>
                                <asp:ListItem Value="20">Transport Duty</asp:ListItem>
                                <asp:ListItem Value="21">Reimbursement of APMC</asp:ListItem>
                                <asp:ListItem Value="22">Capital Subsidy</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnGetData" runat="server" Text="Get Data" OnClick="btnGetData_Click" CssClass="btn-action" BackColor="#003366" ForeColor="White" />
                        </td>
                        <td>
                            <asp:Button ID="btnPrintAppraisals" runat="server" Text="Print Selected Appraisals" OnClick="btnPrintAppraisals_Click" CssClass="btn-action" BackColor="#28a745" ForeColor="White" />
                        </td>
                    </tr>
                </table>
            </div>

            <div style="padding: 10px;">
                <asp:Label ID="lblGridMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                <asp:GridView ID="gvApplications" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="IncentiveId,MasterIncentiveId" CssClass="table" Width="100%" 
                    EmptyDataText="<b>No Applications Found. Select criteria and click 'Get Data'.</b>">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <input type="checkbox" id="chkHeader" onclick="selectAllCheckboxes(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                                <asp:HiddenField ID="hfGridIncId" runat="server" Value='<%# Eval("IncentiveId") %>' />
                                <asp:HiddenField ID="hfGridMstId" runat="server" Value='<%# Eval("MasterIncentiveId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="50px">
                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="lblApplicationno" ItemStyle-HorizontalAlign="Left" HeaderText="Online Application Number" />
                        <asp:BoundField DataField="txtunitnames" ItemStyle-HorizontalAlign="Left" HeaderText="Name of Unit & Address" />
                        <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Left" HeaderText="Incentive Type" />
                        <asp:BoundField DataField="Caste_Name" ItemStyle-HorizontalAlign="Left" HeaderText="Category" />
                        <asp:BoundField DataField="Remarks" ItemStyle-HorizontalAlign="Left" HeaderText="ADDL_RECON_AMOUNT" />
                        <asp:BoundField DataField="EnterperIncentiveID" ItemStyle-HorizontalAlign="Left" HeaderText="EnterperIncentiveID" Visible="false" />
                        <asp:BoundField DataField="IncentiveId" ItemStyle-HorizontalAlign="Left" HeaderText="IncentiveId" />
                    </Columns>
                    <HeaderStyle BackColor="#003366" ForeColor="White" Font-Bold="true" />
                    <RowStyle Font-Names="Verdana" Font-Size="12px" />
                </asp:GridView>
            </div>
        </asp:Panel>

        <!-- ================= PANEL 2: BULK PRINT REPEATER VIEW ================= -->
        <asp:Panel ID="pnlPrintView" runat="server" Visible="false">
            <div class="no-print" style="text-align: center; margin: 15px 0; padding: 12px; background: #eee; border-bottom: 2px solid #ccc;">
                <asp:Label ID="lblPrintCount" runat="server" Font-Bold="true" ForeColor="#003366"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <input id="btnPrintTrigger" onclick="window.print()" style="font-weight: bold; padding: 6px 20px; cursor: pointer; background: #28a745; color: white; border: none; border-radius: 3px;" type="button" value="Print All Notes" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBackToSelection" runat="server" Text="Back to Selection List" OnClick="btnBackToSelection_Click" CssClass="btn-action" BackColor="#6c757d" ForeColor="White" />
            </div>

            <!-- Page-break wrapper -->
            <div style="width: 100%; display: block;">
                <asp:Repeater ID="rptAppraisals" runat="server" OnItemDataBound="rptAppraisals_ItemDataBound">
                    <ItemTemplate>
                        <div class="print-page">
                            <div align="center">
                                <asp:HiddenField ID="hfIncentiveId" Value='<%# Eval("IncentiveId") %>' runat="server" />
                                <asp:HiddenField ID="hfMasterIncentiveId" Value='<%# Eval("MasterIncentiveId") %>' runat="server" />

                                <div align="center">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" alt="Logo" />
                                </div>
                                <br />

                                <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                                    <tr id="tideaTr" runat="server">
                                        <td style="text-align: left; font-weight: bold;">
                                            <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                                            Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department,
                                            <br />Dated : 29/11/2014
                                        </td>
                                    </tr>
                                    <tr id="tprideTr" runat="server">
                                        <td style="text-align: center; font-weight: bold;">
                                            T-PRIDE -
                                            <asp:Label ID="LBLCASTE" runat="server" Visible="false" Text="Label"></asp:Label>
                                            - G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department,
                                            <br />Dated : 29/11/2014
                                        </td>
                                    </tr>
                                    <tr id="TRMSME" runat="server" visible="false">
                                        <td style="text-align: center; font-weight: bold;">
                                            Micro, Small & Medium Enterprises Policy,2024 - G.O M.S. NO 6, Industries and Commerce (FP &amp; MSME) Department,
                                            <br />Dated : 23/03/2026
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; vertical-align: middle">
                                            <u><b>Appraisal Note<br />
                                            <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                            </b></u>
                                        </td>
                                    </tr>
                                </table>

                                <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        
                                        <td class="auto-style1">Application no</td>
                                        <td><asp:Label ID="lblApplication_no" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td style="font-weight: bold;" class="auto-style1">1 Name of Industrial Concern</td>
                                        <td><b><asp:Label ID="lblUnitname" runat="server"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">2 Location of the Industrial concern</td>
                                        <td><asp:Label ID="lblLocaddress" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">3 Name of Promoter</td>
                                        <td><asp:Label ID="lblPromoterName" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">4 Constitution of the Industrial Concern</td>
                                        <td><asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">5 Social Status</td>
                                        <td><asp:Label ID="lblSocialStatus" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">6 Share of SC/ST/Women Enterpreneur</td>
                                        <td>
                                            <asp:Label ID="lblEntrprName" runat="server"></asp:Label>
                                            <b><asp:Label ID="lblwomen" runat="server" Visible="false"></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">7 PMT SSI Registration. No. &amp; Date</td>
                                        <td><asp:Label ID="lblSSIRegn" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">8 New/Expansion/Diversification Unit</td>
                                        <td><asp:Label ID="lblNewExpnDiver" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">9 Date of commencement of production</td>
                                        <td><asp:Label ID="lblCommencmentOfCommrclProdcn_Date" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">10 Date of filing of claim application in DIC</td>
                                        <td><asp:Label ID="lblApplicationDateDIC" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">11 Name of Financing Institution in case of Aided Units</td>
                                        <td><asp:Label ID="lblFinInstn" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id="TRCLAIMPERIOD" runat="server" visible="false">
                                        
                                        <td class="auto-style1">12 Claim Period</td>
                                        <td><asp:Label ID="lblclaimperiod" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id="TRSCHEME" runat="server" visible="false">
                                        
                                        <td class="auto-style1">13 Scheme</td>
                                        <td><asp:Label ID="LBLSCHEME" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="auto-style1">Confirmed Details by GM</td>
                                        <td><asp:Label ID="lblDetailsConfirmed" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id="clerkattachment" runat="server" visible="false">
                                        
                                        <td class="auto-style1">Clerk Worksheet</td>
                                        <td><asp:HyperLink ID="hylinkattachment" runat="server" Visible="false">Attachment</asp:HyperLink></td>
                                    </tr>
                                </table>

                                <!-- Line of Activity Grid -->
                                <table style="width: 100%; font-family: Verdana; font-size: small">
                                    <tr>
                                        
                                        <td><u><b>Line of Activity</b></u></td>
                                    </tr>
                                    <tr>
                                        
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
                                                </Columns>
                                                <RowStyle ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>

                                <!-- Fixed Capital Investment -->
                                <table style="font-family: Verdana; font-size: small; width: 100%">
                                    <tr>
                                        
                                        <td align="center" colspan="4"><b>Fixed Capital Investment</b></td>
                                        <td style="text-align: right"><b>(In Rupees)</b></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td align="center">Details of Fixed Assets</td>
                                        <td align="center"><b>As per Approved project cost</b></td>
                                        <td align="center"><b>As per GM Recommendation</b></td>
                                        <td align="center"><b>Computed as per Guidelines</b></td>
                                        <td align="center"><b>Reasons for variation</b></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td>a. Land</td>
                                        <td class="auto-style2"><asp:Label runat="server" ID="lblLand_ProjectCost"></asp:Label></td>
                                        <td class="auto-style2"><asp:Label runat="server" ID="lblLand_ValueRecommendedByGM"></asp:Label></td>
                                        <td class="auto-style2"><asp:Label runat="server" ID="lblLandComputed"></asp:Label></td>
                                        <td class="auto-style2"><asp:Label runat="server" ID="lblLand_GMRec"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td>b. Building</td>
                                        <td><asp:Label runat="server" ID="lblBuilding_ProjectCost"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblBuilding_ValueRecommendedByGM"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblBuildingComputed"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblBuilding_GMRec"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td>c. Plant &amp; M/C</td>
                                        <td><asp:Label runat="server" ID="lblPlantMachry_ProjectCost"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblPlantMachry_ValueRecommendedByGM"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblPlantMachryComputed"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblPlantMachry_GMRec"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td>d. Tech.Knows-how feasibility study &amp; turn key charges</td>
                                        <td><asp:Label runat="server" ID="lblFeasibilityStudyCharges_ProjectCost"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblFeasibilityStudyCharges_ValueRecommendedByGM"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblFeasibilityStudyChargesComputed"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblFeasibilityStudyCharges_GMRec"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td>e. Vehicles</td>
                                        <td><asp:Label runat="server" ID="lblVehicles_ProjectCost"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblVehicles_ValueRecommendedByGM"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblVehiclesComputed"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblVehicles_GMRec"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        
                                        <td>f. Other eligible</td>
                                        <td><asp:Label runat="server" ID="lblOthersEligible_ProjectCost"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblOthersEligible_ValueRecommendedByGM"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblOthersEligibleComputed"></asp:Label></td>
                                        <td><asp:Label runat="server" ID="lblOthersEligible_GMRec"></asp:Label></td>
                                        
                                    </tr>
                                    <tr style="text-align: center">
                                        
                                        <td>Total</td>
                                        <td><b><asp:Label runat="server" ID="lblTotal_ProjectCost"></asp:Label></b></td>
                                        <td><b><asp:Label runat="server" ID="lblTotal_ValueRecommendedByGM"></asp:Label></b></td>
                                        <td><b><asp:Label runat="server" ID="lblTotalComputed"></asp:Label></b></td>
                                        <td><b><asp:Label runat="server" ID="lblTotal_GMRec"></asp:Label></b></td>
                                        
                                    </tr>
                                </table>

                                <br />

                                <!-- Scheme Section 12: Investment Subsidy (6) -->
                                <div align="center" id="Div3" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">12 <u>ELIGIBLE INCENTIVES </u></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">a) Investment Subsidy @ Eligible %</td>
                                            <td><asp:Label ID="lblPercent" runat="server"></asp:Label><b>%</b></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">b) State Investment Subsidy in Rs.</td>
                                            <td><asp:Label ID="lblStateInvesSubsidy" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">c) Additional Women Percentage(%).</td>
                                            <td class="auto-style4"><asp:Label ID="lblpercentage_is" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">d) Addl Sub. for Women in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblAddlSubWomen" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">e) Application Type</td>
                                            <td class="auto-style4"><asp:Label ID="lblapplicationtype_IS" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">f) Is LMV or NONLMV</td>
                                            <td class="auto-style4"><asp:Label ID="lbllmvornonlmv" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">g) Is Men or Women</td>
                                            <td class="auto-style4"><asp:Label ID="lblmenorwomen" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">h) Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="LBLREMARKS" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY</b></td>
                                            <td><asp:Label ID="lblEligi_TotalSubsidy" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"><b>CONDITIONS TO BE FULFILLED BY THE UNIT</b></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"><asp:Label ID="lblConditionsFulfil" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trgmremarks">
                                            <td><b><u>REMARKS</u></b></td>
                                            <td colspan="2" style="text-align: justify">
                                                The GM,DIC - <asp:Label ID="LblDICName" runat="server"></asp:Label>&nbsp;District has recommended the claim application along with all required documents/certificates as per the Guidelines. The unit has submitted the claim application within the stipulated period in the office of the GM,DIC, as such there is no delay in submitting the claim application and the line of activity is eligible of Investment subsidy under
                                                <b><asp:Label ID="lblFinalSchemeName" runat="server"></asp:Label>
                                                   <asp:Label ID="LBLCASTE2" runat="server" Visible="false"></asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Land Conversion (16) -->
                                <div align="center" id="divLandconversion" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8">4.0 <u>ELIGIBLE INCENTIVES</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.1 Land measuring in Square meters</td>
                                            <td><asp:Label ID="lblLConLandMeasure" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.2 Land Conversion Charges Paid:</td>
                                            <td><asp:Label ID="LblLconPurchaseValue" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.3 Building plinth Area in Square meters</td>
                                            <td class="auto-style4"><asp:Label ID="lblLconBuildingPlnth" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.4 Five Times plinth area:</td>
                                            <td class="auto-style4"><asp:Label ID="lblfietimesplintharea" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.5 Land Area Considered:</td>
                                            <td class="auto-style4"><asp:Label ID="lblLconLandValueComputed" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.6 Proportionate Land Conversion Charges</td>
                                            <td class="auto-style4"><asp:Label ID="lblLconProportionate" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.7 (25 %) on computed value in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblLconTwntyFveComputed" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.8 Value Recommended by GM</td>
                                            <td class="auto-style4"><asp:Label ID="lblLconValueGMRecom" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.9 Elegible Land conversion charges in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblLConEligibleLandConversion" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.10 Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lblLconClaimType" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.11 Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="LBLREMARKS_LANDCONVERSION" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="Tr2" runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label5" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Mortgage (15) -->
                                <div align="center" id="divmortgage" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8">4.0 <u>ELIGIBLE INCENTIVES</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.1 Name of the Financial Institution</td>
                                            <td><asp:Label ID="lblMortFinancialIns" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.2 Term Loan Sacnctioned</td>
                                            <td><asp:Label ID="lblMortTermLoan" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.3 Mortgage Duty Paid</td>
                                            <td class="auto-style4"><asp:Label ID="lblMortMortgageDutyPaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.4 Term Loan availed by Unit</td>
                                            <td class="auto-style4"><asp:Label ID="lblMortTermloanAvailed" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.5 Proportionate Mortgage Duty</td>
                                            <td class="auto-style4"><asp:Label ID="lblMortProportionateMortgage" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.6 Mortgage Duty Recommended by GM</td>
                                            <td class="auto-style4"><asp:Label ID="lblMortMortgageDuty" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.7 Elegible for Reimbursement of Mortgage Duty in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblMortElgibleReimbursement" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.8 Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lblMortTypeofClaim" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.9 Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_mortegage" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label9" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Land Cost (17) -->
                                <div align="center" id="divlandcost" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8">4.0 <u>ELIGIBLE INCENTIVES</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.1 Land Purchase in Sq. Mts.</td>
                                            <td><asp:Label ID="lblLcLandPurchase" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.2 Land Value in Rs</td>
                                            <td><asp:Label ID="lblLCLandvalue" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.3 Plinth Area in Sq.Mts.</td>
                                            <td class="auto-style4"><asp:Label ID="lblLCPlnthArea" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.4 Five times of Builtup Area (Sq.Mts.)</td>
                                            <td class="auto-style4"><asp:Label ID="lblLCfiveTimes" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.5 Proportionate value in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblLCProportionate" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.6 Value recommended by G.M., DIC. in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblLCValueRecmGM" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.7 Eligible Land Cost in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblLCEligibleLandCost" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.8 Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lbltypeofclainlandcost" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.9 Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_landcost" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label13" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Stamp Duty (14) -->
                                <div align="center" id="divStampduty" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8">4.0 <u>ELIGIBLE INCENTIVES</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.1 Land measuring in Sq. Mts.</td>
                                            <td><asp:Label ID="lblSDLandmeasuring" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.2 Stamp duty paid by the unit in Rs.</td>
                                            <td><asp:Label ID="lblSDStampduty" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.3 Building plinth area in Sq.Mts.</td>
                                            <td class="auto-style4"><asp:Label ID="lblSDBuildingPlinth" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.4 Building plinth area 5 times (Sq.Mts.)</td>
                                            <td class="auto-style4"><asp:Label ID="lblSDBuildingplnthfvTimes" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.5 Proportionate value for the area in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblSDProportionateVAlue" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.6 Value recommended by G.M., DIC. in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblSDValueRecomndGM" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.7 Value Computed in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblSDValueComputed" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.8 Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="LBLTYPEOFCLAIM_STAMPDUTY" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.9 Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_stampduty" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label17" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Quality Certification (11) -->
                                <div align="center" id="DIVQUALITYCERTIFICATION" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8">4.0 <u>QUALITY CERTIFICATION</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.1 Quality certification charges paid</td>
                                            <td><asp:Label ID="lblqualitycertificationcgargespaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.2 50% of amount of certification charges paid</td>
                                            <td><asp:Label ID="lblfiftypercentage" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.3 G.M Recommended Amount</td>
                                            <td class="auto-style4"><asp:Label ID="lblgmrecomamount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.4 Eligible amount whichever is less</td>
                                            <td class="auto-style4"><asp:Label ID="lbllesselegibleamount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.5 Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lbltypeofclaim_quality" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.6 Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_qualitycertification" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="Tr1" runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label14" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Sales Tax (5) -->
                                <div align="center" id="DIVSALESTAX" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8">4.0 <u>ELIGIBLE INCENTIVES</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">i. Scheme Type</td>
                                            <td><asp:Label ID="LBLSCHEMETYPE" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">ii. Application Type</td>
                                            <td><asp:Label ID="lblapplicationtype" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">iii. Production</td>
                                            <td class="auto-style4"><asp:Label ID="lblproduction" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">iv. Tax Paid</td>
                                            <td class="auto-style4"><asp:Label ID="lbltaxpaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">v. Base Production</td>
                                            <td class="auto-style4"><asp:Label ID="lblbaseproduction" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">vi. Eligible Production Quantity over and the above base production</td>
                                            <td class="auto-style4"><asp:Label ID="lblelgprodqty" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">vii. Proportionate SGST value on eligible prodution</td>
                                            <td class="auto-style4"><asp:Label ID="lblproportionatesgst" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">viii. Category</td>
                                            <td class="auto-style4"><asp:Label ID="lblcategory" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">ix. Percentage</td>
                                            <td class="auto-style4"><asp:Label ID="lblpercentage" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trcapitaleligibleinvestment">
                                            
                                            <td class="auto-style18">x. Total Capital Eligible Investment</td>
                                            <td class="auto-style4"><asp:Label ID="lblcapitalelginvestment" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trsalestaxsanctionedonthisclaim">
                                            
                                            <td class="auto-style18">xi. Total Sales Tax Already Sanctioned Prior to This Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lblsalestaxsanctioned" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">xii. GM Recommended Value</td>
                                            <td class="auto-style4"><asp:Label ID="lblgmrecommendedvalue" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">xiii. Eligible Amount</td>
                                            <td class="auto-style4"><asp:Label ID="lbleligibleamount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">xiv. Type of claim</td>
                                            <td class="auto-style4"><asp:Label ID="lbltypeofclaim" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">xv. Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_salestax" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label12" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <!-- Scheme Section: Pavala Vaddi (1) -->
                                <div align="center" id="div_pallavaddi" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8"><u>ELIGIBLE INCENTIVES</u></td>
                                        </tr>
                                    </table>

                                    <!-- Summary of Loans Grid -->
                                    <table style="width: 100%">
                                        <tr>
                                            
                                            <td colspan="4">
                                                <asp:GridView ID="grd_claimperiodofloanadd" runat="server" CssClass="table"
                                                    AutoGenerateColumns="false" AllowPaging="false" ShowHeaderWhenEmpty="true" 
                                                    EmptyDataText="<b>No Data Available</b>">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.#">
                                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Claim Period">
                                                            <ItemTemplate><%# Eval("ClaimPeriodName") %></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No of Loans Applied for this Claim">
                                                            <ItemTemplate><%# Eval("LoanCount") %></ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <!-- Full Loan-Wise Calculation Table with 6-Month Breakdown -->
                                    <table style="width: 100%">
                                        <tr>                                            
                                            <td colspan="4">
                                                <asp:GridView ID="grd_eglibilepallavaddi" runat="server" CssClass="table"
                                                    AutoGenerateColumns="false" AllowPaging="false" ShowHeaderWhenEmpty="false"  ShowHeader="false"
                                                    EmptyDataText="<b>No Data Available</b>">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hf_grdeglibilepallavaddiFY_ID" Value='<%# Eval("ClaimPeriodID") %>' runat="server" />
                                                                <table style="width: 100%; font-family: Calibri;">
                                                                    <tr>
                                                                        <th style="font-family: Calibri">
                                                                            <%# Container.DataItemIndex + 1 %> Claim Period:
                                                                            <asp:Label ID="lbl_grdeglibilepallavaddiFYname" Text='<%# Eval("ClaimPeriodName") %>' runat="server"></asp:Label>
                                                                        </th>
                                                                        <th></th>
                                                                        <th style="font-family: Calibri">
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;Loan-
                                                                            <asp:Label ID="lbl_claimeglibleincentivesloanwiseLoanID" Text='<%# Eval("LoanNumber") %>' runat="server"></asp:Label>
                                                                        </th>
                                                                        <th></th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Date of Commencement of activity:</b></td>
                                                                        <td><%# Eval("dcpdate") %></td>
                                                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<b>Loan installment start Date</b></td>
                                                                        <td><%# Eval("loaninstallmentstartdate") %></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Total Term Loan Availed(In Rs.)</b></td>
                                                                        <td><%# Eval("tottermloanavil") %></td>
                                                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<b>Period of installment</b></td>
                                                                        <td><%# Eval("Periodofinstallmentname") %></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>No of installment</b></td>
                                                                        <td><%# Eval("Noofinstallmentforloan") %></td>
                                                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<b>Installment amount</b></td>
                                                                        <td><%# Eval("Installmentamountforloan") %></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>No of installments completed</b></td>
                                                                        <td><%# Eval("NoofinstallmentcompletedfortheloanFY") %></td>
                                                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<b>PrincipalAmount become DUE before this HALFYEAR</b></td>
                                                                        <td><%# Eval("principalamountdueforhalfyrFY") %></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <!-- 6-Month Breakdown Grid Inside Each Loan -->
                                                                            <table border="1" width="100%" align="center" cellpadding="6" cellspacing="0" style="margin-top: 10px; margin-bottom: 10px;">
                                                                                <tr style="background-color: #f2f2f2;">
                                                                                    <th>Sr.#</th>
                                                                                    <th>Period of Claim</th>
                                                                                    <th>Principal amount due</th>
                                                                                    <th>No of Installment</th>
                                                                                    <th>Rate of Interest</th>
                                                                                    <th>Interest due</th>
                                                                                    <th>Unit Holder Contribution</th>
                                                                                    <th>Eligible Rate of interest</th>
                                                                                    <th>Eligible Interest Amount</th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>1</td>
                                                                                    <td><asp:Label ID="lbl_grd_monthonename" Text='<%# Eval("PeriodofClaimMonth1Name") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthnonePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth1") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthoneNoofInstallment" Text='<%# Eval("NoofInstallmentMonth1") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthoneRateofinterest" Text='<%# Eval("rateofinterestMonth1") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthoneInterestamount" Text='<%# Eval("interestamountMonth1") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthoneUnitHolderContribution" Text='<%# Eval("unitholdercontMonth1") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthoneEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth1") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthoneEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth1") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>2</td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoname" Text='<%# Eval("PeriodofClaimMonth2Name") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth2") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoNoofInstallment" Text='<%# Eval("NoofInstallmentMonth2") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoRateofinterest" Text='<%# Eval("rateofinterestMonth2") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoInterestamount" Text='<%# Eval("interestamountMonth2") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoUnitHolderContribution" Text='<%# Eval("unitholdercontMonth2") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth2") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthtwoEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth2") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>3</td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreename" Text='<%# Eval("PeriodofClaimMonth3Name") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth3") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreeNoofInstallment" Text='<%# Eval("NoofInstallmentMonth3") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreeRateofinterest" Text='<%# Eval("rateofinterestMonth3") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreeInterestamount" Text='<%# Eval("interestamountMonth3") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreeUnitHolderContribution" Text='<%# Eval("unitholdercontMonth3") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreeEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth3") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monththreeEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth3") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>4</td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourname" Text='<%# Eval("PeriodofClaimMonth4Name") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth4") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourNoofInstallment" Text='<%# Eval("NoofInstallmentMonth4") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourRateofinterest" Text='<%# Eval("rateofinterestMonth4") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourInterestamount" Text='<%# Eval("interestamountMonth4") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourUnitHolderContribution" Text='<%# Eval("unitholdercontMonth4") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth4") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfourEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth4") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>5</td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfivename" Text='<%# Eval("PeriodofClaimMonth5Name") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfivePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth5") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfiveNoofInstallment" Text='<%# Eval("NoofInstallmentMonth5") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfiveRateofinterest" Text='<%# Eval("rateofinterestMonth5") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfiveInterestamount" Text='<%# Eval("interestamountMonth5") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfiveUnitHolderContribution" Text='<%# Eval("unitholdercontMonth5") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfiveEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth5") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthfiveEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth5") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>6</td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixname" Text='<%# Eval("PeriodofClaimMonth6Name") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth6") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixNoofInstallment" Text='<%# Eval("NoofInstallmentMonth6") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixRateofinterest" Text='<%# Eval("rateofinterestMonth6") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixInterestamount" Text='<%# Eval("interestamountMonth6") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixUnitHolderContribution" Text='<%# Eval("unitholdercontMonth6") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth6") %>' runat="server"></asp:Label></td>
                                                                                    <td><asp:Label ID="lbl_grd_monthsixEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth6") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr style="font-weight: bold; background-color: #fafafa;">
                                                                                    <td colspan="5" align="right">Total Interest Amount:</td>
                                                                                    <td><asp:Label ID="lbl_grd_totmonthsInterestamount" Text='<%# Eval("totmonthsinterestamountMonth") %>' runat="server"></asp:Label></td>
                                                                                    <td colspan="2" align="right">Total Eligible Interest Amount:</td>
                                                                                    <td><asp:Label ID="lbl_grd_totmonthsEligibleInterestAmount" Text='<%# Eval("totmonthseligibleinterestamount") %>' runat="server"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Eligible period in months:</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddiEligibleperiodinmonths" Text='<%# Eval("eligibleperiodinmonths") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Insert amount to be paid as per calculations:</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations" Text='<%# Eval("CPL_interestamountpaidaspercal") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Actual interest amount paid:</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddiActualinterestamountpaid" Text='<%# Eval("CPL_actualinterestamountpaid") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Rate of Interest:</b></td>
                                                                        <td><asp:Label ID="txt_claimeglibleincentivesloanwiseRateofInterest" Text='<%# Eval("Rateofinterestforloan") %>' runat="server"></asp:Label></td>
                                                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<b>Eligible rate of reimbursement:</b></td>
                                                                        <td><asp:Label ID="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement" Text='<%# Eval("Eligibleratereimbursementforlaon") %>' runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Considered Amount for Interest:</b></td>
                                                                        <td><asp:Label ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest" Text='<%# Eval("CPL_Conamountforcalintreimberest") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Interest reimbursement calculated:</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddiInsertreimbursementcalculated" Text='<%# Eval("CPL_interestreimbersementcal") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Eligible Type:</b></td>
                                                                        <td><asp:Label ID="rbtgrdeglibilepallavaddi_isbelated" Text='<%# Eval("CPL_ELIGIBLETYPEName") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Interest reimbursement (After selecting Eligible Type):</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype" Text='<%# Eval("CPL_interestreimbersementcal_finaleligibletype") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>GM recommended amount:</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddiGMrecommendedamount" Text='<%# Eval("CPL_gmrecommendedamount") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><b>Eligible amount:</b></td>
                                                                        <td><asp:Label ID="txt_grdeglibilepallavaddiEligibleamount" Text='<%# Eval("CPL_FINALELIGIBLEAMOUNT") %>' runat="server"></asp:Label></td>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                </table>
<%--                                                                <hr style="border: 0; border-top: 1px dashed #ccc; margin: 15px 0;" />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />

                                    <!-- Summary Values -->
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px;">Interest amount to be paid as per calculations</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_Insertamounttobepaidaspercalculations" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">Actual interest amount paid</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_Actualinterestamountpaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">Considered Amount of Interest</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_ConsideredAmountofInterest" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">Interest reimbursement calculated</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_Insertreimbursementcalculated" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">Interest reimbursement (After selecting Eligible Type)</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">GM recommended amount</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_GMrecommendedamount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">Eligible amount</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="txt_Eligibleamount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">Remarks given by Clerk</td>
                                            <td>:</td>
                                            <td class="auto-style28"><asp:Label ID="lbl_pavallavaddiremarksbyclerk" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Specific Cleaner Production (4) -->
                                <div align="center" id="divspecificcleaner" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="color: black; font-weight: bold;" class="auto-style8"><u>ELIGIBLE INCENTIVES</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Expenditure Incurred.</td>
                                            <td><asp:Label ID="lblExpenditure" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">25% Expenditure Incurred.</td>
                                            <td><asp:Label ID="lblExpenditure25" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Value recommended by G.M., DIC. in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lblgmspecific" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Final Value Computed in Rs.</td>
                                            <td class="auto-style4"><asp:Label ID="lvlfinalpecific" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label11" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Skill Upgradation (8) -->
                                <div align="center" id="DIVSKILLUPGRADE" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="color: black; font-weight: bold;" class="auto-style8">4.0 <u>Reimbursement of cost involved in skill upgradation and training</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.1 Skill Upgradation charges paid</td>
                                            <td><asp:Label ID="lblskillupchargespaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">4.2 50% of amount of skill upgradation charges paid</td>
                                            <td><asp:Label ID="lbl50perskillupchargespaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.3 G.M Recommended Amount</td>
                                            <td class="auto-style4"><asp:Label ID="lblgmrecomamount_skillupgrade" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.4 Eligible amount whichever is less</td>
                                            <td class="auto-style4"><asp:Label ID="lblelegamountless_skillupgrade" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.5 Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lbltypeofclaim_skillupgrade" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">4.6 Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_skillupgrade" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="Tr5" runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label20" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: IIDF (7) -->
                                <div align="center" id="DIVIIDF" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="color: black; font-weight: bold;" class="auto-style8"><u>Industrial Infrastructure Development Fund(IIDF)</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">a. IIDF charges paid</td>
                                            <td><asp:Label ID="lbliidfchargespaid" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">b. 50% of amount of IIDF charges paid</td>
                                            <td><asp:Label ID="lbl50perofiidf" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">c. 15% of amount of computed cost</td>
                                            <td><asp:Label ID="lbl15perofcompcost" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">d. G.M Recommended Amount</td>
                                            <td class="auto-style4"><asp:Label ID="lblgmrecomamount_iidf" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">e. Eligible amount whichever is less</td>
                                            <td class="auto-style4"><asp:Label ID="lblelegamountless_iidf" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">f. Type of Claim</td>
                                            <td class="auto-style4"><asp:Label ID="lbltypeofclaim_iidf" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">g. Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremarks_iidf" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="Tr6" runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label21" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Coal (18) -->
                                <div align="center" id="divcoal" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8"><u>REIMBURSEMENT OF COAL</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Coal Quantity</td>
                                            <td><asp:Label ID="lblcoalquantity" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Eligible Amount</td>
                                            <td><asp:Label ID="lbleligibleamount_coal" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">GM Recommended Value</td>
                                            <td class="auto-style4"><asp:Label ID="lblgmrecommendedvalue_coal" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Final Subsidy Amount</td>
                                            <td class="auto-style4"><asp:Label ID="lblfinalsubsidyamount_coal" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="lblremark_coal" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="Tr3" runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label16" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Wood (19) -->
                                <div align="center" id="DIVWOOD" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8"><u>REIMBURSEMENT OF WOOD</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">WOOD Quantity</td>
                                            <td><asp:Label ID="LBLQUANTITY_WOOD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Eligible Amount</td>
                                            <td><asp:Label ID="LBLELIGIBLEAMOUNT_WOOD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">GM Recommended Value</td>
                                            <td class="auto-style4"><asp:Label ID="LBLGMRECOMMENDEDVALUE_WOOD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Final Subsidy Amount</td>
                                            <td class="auto-style4"><asp:Label ID="LBLFINALSUBSIDYAMOUNT_WOOD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="LBLREMARKS_WOOD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="Tr4" runat="server" visible="false">
                                            
                                            <td class="auto-style8"><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                            <td><asp:Label ID="Label15" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Capital Subsidy (22) -->
                                <div align="center" id="DIVCAPITALSUBSIDY" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8"><u>REIMBURSEMENT OF CAPITAL SUBSIDY</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Investment for the Year</td>
                                            <td><asp:Label ID="lblinvestment_CS" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Eligible Type</td>
                                            <td><asp:Label ID="lblelegibletype_CS" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">10 % of Investment</td>
                                            <td><asp:Label ID="lbltenperinvestment_CS" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Final Subsidy Amount</td>
                                            <td class="auto-style4"><asp:Label ID="lblfinalsubsidyamount_CS" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="LBLREMARKS_CS" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: APMC (21) -->
                                <div align="center" id="DIVAPMC" visible="false" runat="server">
                                    <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                                        <tr>
                                            
                                            <td style="font-weight: bold;" class="auto-style8"><u>REIMBURSEMENT OF APMC</u></td>
                                            
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">APMC fee paid year</td>
                                            <td><asp:Label ID="LBLAPMCFEEPAIDYEAR" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">Amount Paid in rupees</td>
                                            <td><asp:Label ID="LBLAPMCFEEPAID" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style8">First/Second Half Year</td>
                                            <td><asp:Label ID="LBLFIRSTORSECONDHALFYEAR_APMC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Eligible Type</td>
                                            <td class="auto-style4"><asp:Label ID="LBLELIGIBLETYPE_APMC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Eligible Amount(in Rs.)</td>
                                            <td class="auto-style4"><asp:Label ID="LBLELIGIBLEAMOUNT_APMC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">GM Recommended Amount(in Rs.)</td>
                                            <td class="auto-style4"><asp:Label ID="LBLGMRECOMMENDEDAMOUNT_APMC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Final Subsidy Amount</td>
                                            <td class="auto-style4"><asp:Label ID="LBLFINALSUBSIDYAMOUNT_APMC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="auto-style18">Remarks</td>
                                            <td class="auto-style4"><asp:Label ID="LBLREMARKS_APMC" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Transport Duty (20) -->
                                <div align="center" id="DIVTRANSPORTDUTY" visible="false" runat="server" style="padding-left:40px">
                                    <table style="font-family: Verdana; font-size: small;" bgcolor="White" width="100%">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">Month</td>
                                            <td style="border: solid thin black; font-weight: bold;">Financial-year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Units Consumed in Nos.</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible amount Re-imbursement in Rs.</td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="lblmonth1" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblfinyear1" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblunitsconsumed1" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblelegamount1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="lblmonth2" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblfinyear2" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblunitsconsumed2" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblelegamount2" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="lblmonth3" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblfinyear3" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblunitsconsumed3" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblelegamount3" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="lblmonth4" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblfinyear4" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblunitsconsumed4" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblelegamount4" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="lblmonth5" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblfinyear5" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblunitsconsumed5" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblelegamount5" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="lblmonth6" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblfinyear6" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblunitsconsumed6" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="lblelegamount6" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;" colspan="4">
                                                <br />Total amount : <asp:Label ID="lbltotalmaount" runat="server"></asp:Label>
                                                <br /><br />Type : <asp:Label ID="lbltype" runat="server"></asp:Label>
                                                <br /><br />GM Recommended Amount : <asp:Label ID="lblGMreconamount" runat="server"></asp:Label>
                                                <br /><br />Total Eligible amount : <asp:Label ID="lblfinanelgamount" runat="server"></asp:Label>
                                                <br /><br />Remarks: <asp:Label ID="lblremarks_TRDUTY" runat="server"></asp:Label>
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Scheme Section: Power Cost (3) [All 4 Sub-Tables Included] -->
                                <div align="center">
                                    <!-- 1. New Unit Standard Table -->
                                    <table id="tblNewUnit" runat="server" visible="false" style="font-family: Verdana; font-size: small;" bgcolor="White" width="100%">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">Financial Year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Month-year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Units Consumed</td>
                                            <td style="border: solid thin black; font-weight: bold;">Rate per Units</td>
                                            <td style="border: solid thin black; font-weight: bold;">Amount Paid (Rs.)</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible rate Re-imbursement</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible amount Re-imbursement</td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear1New" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear1NewFinyear" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox23" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox24" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox25" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox21" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox28" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear2New" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear2NewFinyear" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox50" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox51" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox52" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox22" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox29" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear3New" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear3NewFinyear" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox63" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox64" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox65" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox26" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox49" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear4New" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear4NewFinyear" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox71" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox72" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox73" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox27" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox53" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear5New" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear5NewFinyear" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox79" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox80" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox81" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox95" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox54" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear6New" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear6NewFinyear" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox87" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox88" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox89" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox96" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox55" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;" colspan="7">
                                                <br />Total amount : <asp:Label ID="lblGmAmount0" runat="server"></asp:Label>
                                                <br /><br />Is Belated : <asp:Label ID="lblTotalEligibleAm0" runat="server"></asp:Label>
                                                <br /><br />Total Eligible amount : <asp:Label ID="lblTotalEligibleAm" runat="server"></asp:Label>
                                                <br /><br />GM Recommended Amount : <asp:Label ID="lblGmAmount" runat="server"></asp:Label>
                                                <br /><br />Remarks: <asp:Label ID="lblremarks_powernew" runat="server"></asp:Label>
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>

                                    <!-- 2. New Unit Both Table -->
                                    <table id="tblNewUnitBoth" runat="server" visible="false" style="font-family: Verdana; font-size: small;" bgcolor="White" width="100%">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">Financial Year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Month-year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Units Consumed</td>
                                            <td style="border: solid thin black; font-weight: bold;">Rate per Units</td>
                                            <td style="border: solid thin black; font-weight: bold;">Amount Paid (Rs.)</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible rate Re-imbursement</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible amount Re-imbursement</td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear1NewBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear1NewFinyearBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox23Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox24Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox25Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox21Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox28Both" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear2NewBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear2NewFinyearBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox50Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox51Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox52Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox22Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox29Both" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear3NewBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear3NewFinyearBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox63Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox64Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox65Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox26Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox49Both" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear4NewBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear4NewFinyearBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox71Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox72Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox73Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox27Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox53Both" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear5NewBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear5NewFinyearBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox79Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox80Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox81Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox95Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox54Both" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear6NewBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear6NewFinyearBoth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox87Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox88Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox89Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox96Both" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox55Both" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;" colspan="7">
                                                <br />Total amount : <asp:Label ID="lblGmAmount0Both" runat="server"></asp:Label>
                                                <br /><br />Is Belated : <asp:Label ID="lblTotalEligibleAm0Both" runat="server"></asp:Label>
                                                <br /><br />Total Eligible amount : <asp:Label ID="lblTotalEligibleAmBoth" runat="server"></asp:Label>
                                                <br /><br />GM Recommended Amount : <asp:Label ID="lblGmAmountBoth" runat="server"></asp:Label>
                                                <br /><br />Remarks: <asp:Label ID="lblremarks_powernewBoth" runat="server"></asp:Label>
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>

                                    <!-- 3. Expansion Unit Table -->
                                    <table id="tbl_monthyeardataExpansion" runat="server" visible="false" bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">Financial Year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Month-year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Units Consumed</td>
                                            <td style="border: solid thin black; font-weight: bold;">Rate per Units</td>
                                            <td style="border: solid thin black; font-weight: bold;">Amount Paid (Rs.)</td>
                                            <td style="border: solid thin black; font-weight: bold;">Base fixed per month</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible Units (Over base)</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible Rate</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible amount (Rs.)</td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear1" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1unitsconsumed" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1rateperunit" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1amountpaid" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1basefixedunitspermonth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1eligibleunits" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1eligiblerateofreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear1eligibleamountforreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox75" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear2" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2unitsconsumed" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2rateperunit" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2amountpaid" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2basefixedunitspermonth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2eligibleunits" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2eligiblerateofreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear2eligibleamountforreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox76" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear3" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3unitsconsumed" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3rateperunit" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3amountpaid" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3basefixedunitspermonth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3eligibleunits" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3eligiblerateofreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear3eligibleamountforreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox77" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear4" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4unitsconsumed" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4rateperunit" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4amountpaid" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4basefixedunitspermonth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4eligibleunits" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4eligiblerateofreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear4eligibleamountforreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox78" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear5" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5unitsconsumed" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5rateperunit" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5amountpaid" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5basefixedunitspermonth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5eligibleunits" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5eligiblerateofreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear5eligibleamountforreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox82" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdmonthyear6" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6unitsconsumed" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6rateperunit" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6amountpaid" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6basefixedunitspermonth" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6eligibleunits" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6eligiblerateofreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="txt_grdyear6eligibleamountforreimbursement" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="TextBox83" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <br />Total amount : <asp:Label ID="Label1" runat="server"></asp:Label>
                                                <br /><br />Is Belated : <asp:Label ID="Label2" runat="server"></asp:Label>
                                                <br /><br />Total Eligible amount : <asp:Label ID="Label3" runat="server"></asp:Label>
                                                <br /><br />GM Recommended Amount : <asp:Label ID="Label4" runat="server"></asp:Label>
                                                <br /><br />Remarks: <asp:Label ID="lblremarks_monthyearexp" runat="server"></asp:Label>
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>

                                    <!-- 4. Expansion Unit Both Table -->
                                    <table id="tbl_monthyeardataExpansionBoth" runat="server" visible="false" bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">Financial Year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Month-year</td>
                                            <td style="border: solid thin black; font-weight: bold;">Units Consumed</td>
                                            <td style="border: solid thin black; font-weight: bold;">Rate per Units</td>
                                            <td style="border: solid thin black; font-weight: bold;">Amount Paid (Rs.)</td>
                                            <td style="border: solid thin black; font-weight: bold;">Base fixed per month</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible Units (Over base)</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible Rate</td>
                                            <td style="border: solid thin black; font-weight: bold;">Eligible amount (Rs.)</td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="Label117" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label118" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label119" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label120" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label121" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label122" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label123" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label124" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label125" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="Label126" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label127" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label128" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label129" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label130" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label131" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label132" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label133" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label134" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="Label135" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label136" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label137" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label138" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label139" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label140" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label141" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label142" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label143" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="Label144" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label145" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label146" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label147" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label148" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label149" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label150" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label151" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label152" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="Label153" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label154" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label155" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label156" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label157" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label158" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label159" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label160" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label161" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;"><asp:Label ID="Label162" Enabled="false" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label163" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label164" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label165" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label166" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label167" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label168" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label169" runat="server"></asp:Label></td>
                                            <td style="border: solid thin black;"><asp:Label ID="Label170" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <br />Total amount : <asp:Label ID="Label171" runat="server"></asp:Label>
                                                <br /><br />Is Belated : <asp:Label ID="Label172" runat="server"></asp:Label>
                                                <br /><br />Total Eligible amount : <asp:Label ID="Label173" runat="server"></asp:Label>
                                                <br /><br />GM Recommended Amount : <asp:Label ID="Label174" runat="server"></asp:Label>
                                                <br /><br />Remarks: <asp:Label ID="Label175" runat="server"></asp:Label>
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>

                                    <div id="Div1" runat="server" align="left" visible="false">
                                        <asp:Label ID="lblfinalsubsidyamount" runat="server" Text="Final Subsidy Amount"></asp:Label>:&nbsp;
                                        <asp:Label ID="lblamount" runat="server"></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:Panel>

    </form>
</body>
</html>