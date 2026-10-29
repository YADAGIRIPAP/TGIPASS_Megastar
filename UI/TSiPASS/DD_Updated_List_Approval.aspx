<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="DD_Updated_List_Approval.aspx.cs" Inherits="UI_TSiPASS_DD_Updated_List_Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">Li
</script>
    <style type="text/css">
        .hidden-checkbox 
        {
        display: none;
        }
        .gridview th:nth-child(6),
    .gridview td:nth-child(6) {
        width: 80px; /* Adjust the width as needed */
    }

    .id-link {
        display: inline-block;
        max-width: 100%;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
    }
    .hyperlink {
        color: #0000EE; 
        text-decoration: none;
    }
    .hyperlink:visited {
        color: #0000EE;
    }
        .custom-checkbox input[type="checkbox"] {
        transform: scale(1.65); /* Increase the scale value to make the checkbox bigger */
        margin: 20px; /* Adjust the margin as needed */
        }

        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }

        .GRDHEADER {
            border: 1px solid #1d9a5b;
            color: #1d9a5b;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .LBLBLACK {
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--<div align="left">--%>
    <div class="row" align="center">
        <div class="col-lg-12">
            <%--<tr><td>--%>
            <table style="width: 100%" id="divUpdate" runat="server">
                <tr>
                    <td>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="left" style="font-size: large">Cheque Preparation List DD Incentives</h1>
                        </div>

                        <table align="left" cellpadding="10" cellspacing="5" style="width: 70%">
                            <tr id="trdates" runat="server" visible="false">

                                <td style="vertical-align: middle; padding: 15px;" align="left" class="auto-style1">From Date:
                                </td>
                                <td class="auto-style2">
                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td style="padding: 15px; margin: 5px;" align="left" class="auto-style6">To Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td id="td1" runat="server" align="left" class="auto-style1" style="vertical-align: middle; padding: 15px">Caste : </td>
                                <td class="auto-style2" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="ddlcaste" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="ddlcaste_SelectedIndexChanged"> </asp:DropDownList>
                                    <td id="td2" runat="server" align="left" class="auto-style1" style="vertical-align: middle; padding: 15px">List No : </td>
                                    <td class="auto-style2" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="DropDown_LIST_No" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" Width="220px" AutoPostBack="True"> </asp:DropDownList>
                                    <tr>
                                        <td align="right" colspan="2" style="padding: 15px; margin: 5px;" class="auto-style1">
                                            <asp:Button ID="Getlist" runat="server" CssClass="btn btn-primary" Text="Get List" Width="150px" OnClick="Getlist_Click" />
                                        </td>
                                        <td style="padding: 15px; margin: 5px;" colspan="2" align="left">
                                            <asp:Button ID="ClearFields" CssClass="btn btn-primary" runat="server"
                                                AutoPostBack="true" Text="Clear" Width="150px" OnClick="ClearFields_Click"/>
                                        </td>
                                    </tr>
                                </td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                        <div id="Div2" style="width: 100%" runat="server">
                           <asp:GridView ID="gvProceedings" runat="server" AutoGenerateColumns="false"  CellPadding="4" OnRowDataBound="gvProceedings_RowDataBound" 
                                BackColor="#1d9a5b" CssClass="GRD gridview" ForeColor="White" Font-Bold="True" Height="62px" PageSize="15" ShowFooter="False" Width="100%" CellSpacing="4" HeaderStyle-HorizontalAlign="Center">
            <%--<FooterStyle BackColor="#1d9a5b" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />--%> <RowStyle BackColor="#D1DDF1" Font-Bold="True" CssClass="GRDITEM" HorizontalAlign="Center" VerticalAlign="Middle"/>
                <Columns>                        
                                        <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="List No.">
                                        <ItemTemplate>
                                            <asp:Label ID="ListNo" runat="server" CssClass="center-align" Text='<%#Eval("ListNo") %>'></asp:Label>
                                        </ItemTemplate> 
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of Claims">
                                        <ItemTemplate>
                                            <asp:Label ID="NoOfClaims" runat="server" CssClass="center-align" Text='<%#Eval("NoofClaims") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Total_Amount" runat="server" CssClass="center-align" Text='<%# Bind("Amount", "Rs. {0:0,0.00}/-") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IPO Recommended Date">
                                        <ItemTemplate>
                                            <asp:Label ID="RecommendedDate" runat="server" CssClass="center-align"  Text='<%#Bind("LatestUpdatedDateTime", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate> 
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="List no. [APPROVED DOCUMENT]">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="id-link hyperlink" ></asp:HyperLink>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                 </Columns>
            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                        <div id="Div1" style="width: 100%" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="false" OnRowCreated="grdDetails_RowCreated"
                                Width="100%" CellSpacing="4" Visible="true">
                                <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Pay">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" onclick="checkAll(this)" AutoPostBack="false" runat="server" CssClass="custom-checkbox" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkApproval" runat="server" CssClass="hidden-checkbox" AutoPostBack="false" onclick="Check_Click(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="List Number" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="ANNEXTURENUMBER" runat="server" Text='<%#Eval("ANNEXTURENUMBER") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NameofUnitAddress" HeaderText="Name of Unit &amp; Address" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateofReceipt" HeaderText="Date of Receipt" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Scheme" HeaderText="Scheme" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VehicleDetails" HeaderText="VehicleDetails" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RecommendedAmount" HeaderText="Recommended Amount" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LOC_Number" HeaderText="LOC Number" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LOC_Date" HeaderText="LOC Date" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LOC_AMOUNT" HeaderText="Total LOC Amount" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sanctioned_LOCAMOUNT" HeaderText="Sanctioned LOC Amount" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SLCORDIPC" ItemStyle-HorizontalAlign="Center" HeaderText="SLC/DIPC" Visible="false">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SLCORDIPCNumer" HeaderText="SLC/ DIPC Number " ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SLCORDIPCDate" HeaderText="SLC/ DIPC Date" ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Master Incentiveid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnterperIncentiveID" runat="server" Text='<%#Eval("EnterperIncentiveID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIncentiveID" runat="server" Text='<%#Eval("IncentiveId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Working Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("WorkingStatus") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBnkAccName" runat="server" Text='<%#Eval("BankAccountName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Type" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccType" runat="server" Text='<%#Eval("AccountType") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of the Bank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%#Eval("NewBankName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("NewBranchName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccno" runat="server" Text='<%#Eval("NewAccNo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IFSC Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIFSCCode" runat="server" Text='<%#Eval("NewIFSCCode") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBankRemark" runat="server" Text='<%#Eval("BankAccountRemarks") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loan Aggrement AcNo" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLoanAcNo" runat="server" Text='<%#Eval("LoanAggrementAcNo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount in Rs." ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#B9D684" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="dvSUnits" style="margin-top: 15px; margin-bottom: 20px;">
                        </div>
                    </td>
                </tr>
                <table>
                    <tr>
                        <td colspan="1" style="padding: 5px; margin: 5px" align="Center" class="style7"
                            id="tblselection" runat="server">
                            <br />
                            <asp:Button ID="UpdateFlagToDB" CssClass="btn btn-primary" runat="server" Text="Approve and Forward to JD"
                                OnClick="UpdateFlagToDB_Click" OnClientClick="return checkValidation()"/>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>

                <div>
                    <tr>
                        <td align="center"><asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#800020" Font-Bold="true" class="alert blink alert-dismissible" data-dismiss="alert" text-size="50px" Text="Records have been Approved and Sent to JD!" /><br /></td>
                    </tr>
                </div>

                <div align="center"><tr>
                <td align="center" style="padding: 5px; margin: 5px" class="auto-style8">
                    <div id="success" runat="server" class="alert alert-success" visible="false">
                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Data Missing!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                    </div>
                </td>
            </tr></div><br />

            </table>


            <tr>
                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
            </tr>
            
            </table>
        </div>
    </div>
    <%--</div>--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtinspectiondate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });
            $("input[id$='txtslcnodate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });
            $("input[id$='txtsvcdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });
        }

        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtinspectiondate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });
            $("input[id$='txtslcnodate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });

            $("input[id$='txtsvcdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });
        });

function checkAll(objRef) {
            var gridViewCheckboxes = document.querySelectorAll('#<%= grdDetails.ClientID %> input[id*="ChkApproval"]');
        for (var i = 0; i < gridViewCheckboxes.length; i++) {
        gridViewCheckboxes[i].checked = objRef.checked;
         }
        }

function Check_Click(objRef) {
    var GridView = objRef.parentNode.parentNode.parentNode;
            var headerCheckBox = GridView.querySelector('#<%= grdDetails.ClientID %> input[id*="chkAll"]');
            headerCheckBox.checked = areAllCheckboxesChecked(GridView);
        }

function areAllCheckboxesChecked(GridView) {
            var checkboxes = GridView.querySelectorAll('input[id*="ChkApproval"]');
            for (var i = 0; i < checkboxes.length; i++) {
                if (!checkboxes[i].checked) {
                    return false;
                }
            }
            return true;
        }

        function checkValidation() {

            debugger;
            var msg = "";

            var allcount = 0, rowcount = 0;

            $("#<%=grdDetails.ClientID%> input[id*='ChkApproval']:checkbox").each(function (index) {
                if ($(this).is(':checked')) rowcount++;
            });

            if (allcount == 0) {
                if (rowcount == 0) {
                    alert('Please Select the CheckBox to Update the Displayed Records');
                    return false;
                }
                debugger;
                console.log('checking')
                console.log(msg);
                if (msg != "") {
                    alert(msg);
                    return false;
                }
                return true;
            }
        }

    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }

        .auto-style1 {
            width: 447px;
            height: 40px;
        }

        .auto-style2 {
            width: 297px;
            height: 40px;
        }

        .auto-style6 {
            width: 200px;
            height: 72px;
        }

        .blink {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }

        .form-control {
        }
    </style>

</asp:Content>
