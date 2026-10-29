<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="COINOTVERIFIEDRECORDS_CFE.aspx.cs" Inherits="UI_TSiPASS_COINOTVERIFIEDRECORDS_CFE" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
</script>
    <style type="text/css">
        function printPage() {
            window .open('PrintPage.aspx', '_blank');
        }

        .hidden-checkbox {
            display: none;
        }

        .custom-checkbox input[type="checkbox"] {
            transform: scale(1.65); /* Increase the scale value to make the checkbox bigger */
            margin: 20px; /* Adjust the margin as needed */
        }

        @media screen and (max-width: 768px) {
          .auto-style8 {
            max-width: 100%;
          }
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

        .style7 {
            color: #FF3300;
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
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

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
                            <h1 class="page-head-line" align="left" style="font-size: large">
                                CONFIRMED APPROVAL ISSUED UNITS DATA</h1>
                        </div>
                        <table align="left" cellpadding="10" cellspacing="5" style="width: 70%">
                            <tr id="trdates" runat="server" visible="true">
                                <td style="vertical-align: middle; padding: 15px;" align="left" class="auto-style1">
                                    From Date:
                                </td>
                                <td class="auto-style2">
                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                        Width="125px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td style="padding: 15px; margin: 5px;" align="left" class="auto-style6">
                                    To Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                        Width="125px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="padding: 15px; margin: 5px;" class="auto-style1">
                                    <asp:Button ID="Getlist" runat="server" CssClass="btn btn-primary" Text="Get List"
                                        Width="150px" OnClick="Getlist_Click" />
                                </td>
                                <td style="padding: 15px; margin: 5px;" colspan="2" align="left">
                                    <asp:Button ID="ClearFields" CssClass="btn btn-primary" runat="server" AutoPostBack="true"
                                        Text="Clear" Width="150px" />
                                </td>
                            </tr>
                    </td>
                </tr>
            </table>
            </td> </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                    <div id="Div1" style="width: 100%" runat="server">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"  OnRowDataBound="grdDetails_RowDataBound" 
                            CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="false"
                            Width="100%" CellSpacing="4">
                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="25px" />
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="intQuessionaireid"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="intQuessionaireid" runat="server" Text='<%#Eval("intQuessionaireid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="INTCFEENTERPID"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="INTCFEENTERPID" runat="server" Text='<%#Eval("intcfeenterpid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="INTDEPTID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="INTDEPTID" runat="server" Text='<%#Eval("INTDEPTID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="INTAPPROVALID"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="INTAPPROVALID" runat="server" Text='<%#Eval("INTAPPROVALID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>--%>
                                <%--<asp:BoundField DataField="UID_No" HeaderText="UID Number" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                 <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("UID_No") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                <asp:BoundField DataField="UnitName" HeaderText="Name of Unit" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="lineofActivity" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="Latest Approval Date" HeaderText="Latest Approval Date" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Latest Approval Date"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lbllatestapprovaldate" runat="server" Text='<%#Eval("ApprovalDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UNITPROPOSAL" HeaderText="Unit Proposal" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Notverifiedremarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Investment" HeaderText="Investment  (In Cr)" ItemStyle-HorizontalAlign="Center"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="caste" HeaderText="caste" ItemStyle-HorizontalAlign="Center"
                                    Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Is_women" HeaderText="Is_women" ItemStyle-HorizontalAlign="Center"
                                    Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval Status" ItemStyle-HorizontalAlign="Center"
                                    Visible="false">
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
            <table>
                <%--<tr id="trupdate" runat="server" visible="false">
                    <td colspan="1" style="padding: 5px; margin: 5px" align="Center" class="style7" id="tblselection"
                        runat="server">
                        <br />
                        <asp:Button ID="Update" CssClass="btn btn-primary" runat="server" Text="UPDATE" OnClick="Update_Click" />
                        <br />
                        <br />
                    </td>
                </tr>--%>
                <div align="center">
                    <tr>
                        <td>
                            <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#800020" Font-Bold="true"
                                class="alert-dismissible" data-dismiss="alert" text-size="50px" Text="" /><br />
                        </td>
                    </tr>
                </div>
                <div align="center">
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px;" class="auto-style8">
                            <div id="SUCCESS" runat="server" class="alert alert-success" visible="false">
                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                    ×</a> <strong>Success!</strong><asp:Label ID="Label1" runat="server"></asp:Label>
                            </div>
                            <div id="ERROR" runat="server" class="alert alert-danger" visible="false">
                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>ALERT!</strong>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </div>
            </table>
            <br />
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

        //function openPrintPage() {
        //    var printUrl = 'http://localhost:18188/UI/TSIPASS/Updated_Annexures_PRINT_PDF.aspx'; // Replace 'print.pdf' with the URL of your print PDF page
        //    var windowOptions = 'width=850,height=1500'; // Adjust the width and height as per your requirements

        //    window.open(printUrl, '_blank', windowOptions);
        //}

        //function openPrintPage() {
        //    var printUrl = 'http://localhost:18188/UI/TSIPASS/Updated_Annexures_PRINT_PDF.aspx'; // Replace 'print.aspx' with the URL of your print page
        //    var windowOptions = 'width=850,height=1500';
        //    var printWindow = window.open(printUrl, '_blank');

        //    // Store the reference to the print window in a variable accessible to the PDF page
        //    sessionStorage.setItem('printWindow', printWindow);
        //}

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


        <%--function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;

                        var id = row.cells[1].textContent;
                        var name = row.cells[2].textContent;
                        var MasterID = row.cells[16].textContent;

                        var dd = $.trim($('#dvSUnits').html()) == "" ? true : false;
                        if (dd) {
                            $('#dvSUnits').html($('<div style="font-size: 16px;font-weight:bold;">Selected Units</div><table style="text-align:left" id="tblUnits" cellspacing="4" cellpadding="4" border="1" ></table>'));
                            $('#tblUnits').append('<tr><th style="padding:10px;text-align:center;">ANNEXURE NUMBER</th><th style="padding:10px;text-align:center;">Master Incentiveid</th></tr>');
                        }

                        $('#tblUnits').append('<tr data-for="' + $.trim(id) + '"><td style="padding-left:10px;padding-right:10px; text-align:Center;">' + name + '</td><td style="text-align:Center;">' + MasterID + '</td></tr>');
                    } else {
                        inputList[i].checked = false;
                        $('#dvSUnits').html('');
                    }
                }
            }
        }

        function Check_Click(objRef) {
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                var id = row.cells[1].textContent;
                var name = row.cells[2].textContent;
                var MasterID = row.cells[16].textContent;

                var dd = $.trim($('#dvSUnits').html()) == "" ? true : false;
                if (dd) {
                    $('#dvSUnits').html($('<div style="font-size: 16px;font-weight:bold;">Selected Units</div><table style="text-align:left" id="tblUnits" cellspacing="4" cellpadding="4" border="1" ></table>'));
                    $('#tblUnits').append('<tr><th style="padding:10px;text-align:center;">ANNEXURE NUMBER</th><th style="padding:10px;text-align:center;">Master Incentiveid</th></tr>');
                }

                $('#tblUnits').append('<tr data-for="' + $.trim(id) + '"><td style="padding-left:10px;padding-right:10px; text-align:Center;">' + name + '</td><td style="text-align:Center;">' + MasterID + '</td></tr>');
            } else {
                var id = row.cells[1].textContent;
                $('#tblUnits tr[data-for="' + $.trim(id) + '"]').remove();
            }
            var GridView = row.parentNode;

            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var headerCheckBox = inputList[0];
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        return;
                    }
                }
            }
        }--%>

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
