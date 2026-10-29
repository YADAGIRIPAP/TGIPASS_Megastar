<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CentralInspectionSystemServiceReport.aspx.cs" Inherits="UI_TSiPASS_CentralInspectionSystemServiceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function PrintPage() {
            window.print()
        }
    </script>

    <style type="text/css">
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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
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
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }

    </script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a> </li>
            <li class=""><i class="fa fa-fw fa-table"></i>Helpdesk </li>
            <li class="active"><i class="fa fa-edit"></i>View Status </li>
        </ol>
    </div>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>CENTRAL INSPECTION SYSTEM</h3>
                    </div>

                    <div class="panel-body">
                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                            width="90%">
                            <tr>
                                <td>
                                    <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                        width="100%">
                                        <tr>
                                            <td>
                                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                                    width="90%">
                                                    <tr style="height: 35px">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><strong>YEAR : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <asp:DropDownList ID="ddlyear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><strong>MONTH : </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <asp:DropDownList ID="ddlmonth" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 35px">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><strong>Inspection Date: </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>

                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1" id="todate" runat="server" visible="false"><strong>To Date: </strong></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1" id="todate1" runat="server" visible="false">
                                                            <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" class="auto-style1">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="SUBMIT" Width="90px" OnClick="btnGet_Click" />

                                            </td>

                                        </tr>
                                        <tr style="height: 35px" id="trprint" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: right;" class="auto-style1">
                                                <input type="button" value="Print" width="61" height="21" onclick="PrintPage()" class="BTN_Login">
                                                <asp:Button ID="Button1" runat="server" Text="Excel" Width="61" Height="25" OnClick="BtnSave2_Click1"
                                                    class="BTN_Login" /></td>

                                        </tr>
                                        <tr style="height: 35px" id="trdate" runat="server" visible="false">

                                            <td style="padding: 5px; margin: 5px; text-align: right;" class="auto-style1">
                                                <strong>Date:</strong> <strong><asp:Label runat="server" ID="lbldate" Font-Bold="true"></asp:Label></strong></td>


                                        </tr>
                                        <tr style="height: 35px" id="TRDATETIME" runat="server" >

                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                        </tr>

                                        <tr style="height: 35px" id="tr1" runat="server">

                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label runat="server" ID="lblDeptName" Font-Bold="true"></asp:Label></td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr runat="server" id="trabstract" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvinspection" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="90%" OnRowCommand="gvinspection_RowCommand">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Department Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DEPARTMENTNAME") %>'
                                                                                CommandName="Department" Text='<%# Eval("DEPARTMENTNAME") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labeldept" Text='<%# Eval("DEPARTMENTNAME") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Scheduled Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("SCHEDULED") %>'
                                                                                CommandName="Scheduled" Text='<%# Eval("SCHEDULED") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelschedule" Text='<%# Eval("SCHEDULED") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspections Conducted">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("INSPECTED") %>'
                                                                                CommandName="Inspected" Text='<%# Eval("INSPECTED") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelinspected" Text='<%# Eval("INSPECTED") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pending Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("PENDING") %>'
                                                                                CommandName="Pending" Text='<%# Eval("PENDING") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelpending" Text='<%# Eval("PENDING") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Uploaded Within 24Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("WITHIN24HR") %>'
                                                                                CommandName="Within24hrs" Text='<%# Eval("WITHIN24HR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelwithin24" Text='<%# Eval("WITHIN24HR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Uploaded Beyond 24Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("BEYOND24HR") %>'
                                                                                CommandName="Beyond24hrs" Text='<%# Eval("BEYOND24HR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelbeyond24" Text='<%# Eval("BEYOND24HR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                    <%--   <tr runat="server" id="trMandalData" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr runat="server" id="trVillageData" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            &nbsp;</td>
                                                    </tr>--%>
                                                    <tr runat="server" id="trdistrictwise" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvdist" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="90%" OnRowCommand="gvdist_RowCommand">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="District Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DISTID") %>'
                                                                                CommandName="DISTRICT" Text='<%# Eval("DISTRICTNAME") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Label5" Text='<%# Eval("DISTID") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Scheduled Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("SCHEDULED") %>'
                                                                                CommandName="Scheduled" Text='<%# Eval("SCHEDULED") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelschedule" Text='<%# Eval("SCHEDULED") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspections Conducted">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("INSPECTED") %>'
                                                                                CommandName="Inspected" Text='<%# Eval("INSPECTED") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelinspected" Text='<%# Eval("INSPECTED") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pending Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("PENDING") %>'
                                                                                CommandName="Pending" Text='<%# Eval("PENDING") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelpending" Text='<%# Eval("PENDING") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Uploaded Within 24Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("WITHIN24HR") %>'
                                                                                CommandName="Within24hrs" Text='<%# Eval("WITHIN24HR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelwithin24" Text='<%# Eval("WITHIN24HR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Uploaded Beyond 24Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("BEYOND24HR") %>'
                                                                                CommandName="Beyond24hrs" Text='<%# Eval("BEYOND24HR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelbeyond24" Text='<%# Eval("BEYOND24HR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>

                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trCentralInfo" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="gvCluster" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="100%" OnRowCommand="gvCluster_RowCommand">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />


                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="NAMEOFESTABLISHMENT" HeaderText="Name Of Establishment">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SCHEDULEDINSPECTIONDATE" HeaderText="Scheduled Inspcetion Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Inspection Notice">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnView" runat="server" CommandArgument='<%# Eval("REGISTRATIONNO") %>'
                                                                                CommandName="VIEW" Text="View"></asp:LinkButton>
                                                                            <%--<a href="ClusterPrint.aspx"  height="32px" tabindex="11" target="_blank">View</a>--%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="INSPECTIONCONDUCTEDDATE" HeaderText="Inspection Conducted Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ALLOCATEDINSPECTOR" HeaderText="Allocated Inspector">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DATEOFUPLOADINGINSPECTIONREPORT" HeaderText="Inspection Upload Report Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="UPLOADWITHIN24HRS" HeaderText="Inspection Uploaded Within 24hours">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Inspection Report">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLink2" Text="INSPECTIONREPORT" Target="_blank" NavigateUrl='<%# Eval("INSPECTIONREPORT") %>' runat="server">View</asp:HyperLink>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>

                                                            </asp:GridView>


                                                        </td>
                                                    </tr>

                                                    <tr runat="server" id="trjoint" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="grdjoint" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="100%" OnRowCommand="grdjoint_RowCommand" OnRowDataBound="grdjoint_RowDataBound">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="NAMEOFESTABLISHMENT" HeaderText="Name Of Establishment">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SCHEDULEDINSPECTIONDATE" HeaderText="Scheduled Inspcetion Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Scheduled Notice">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnView" runat="server" CommandArgument='<%# Eval("REGISTRATIONNO") %>'
                                                                                CommandName="VIEW" Text="View"></asp:LinkButton>
                                                                            <%--<a href="ClusterPrint.aspx"  height="32px" tabindex="11" target="_blank">View</a>--%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="INSPECTIONCONDUCTEDDATE" HeaderText="Inspection Conducted Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ALLOCATEDINSPECTOR" HeaderText="Labour Inspector">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="FACTORYINSPECTOR" HeaderText="Factory Inspector">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DATEOFUPLOADINGINSPECTIONREPORT" HeaderText="Inspection Upload Report Date">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="UPLOADWITHIN24HRS" HeaderText="Inspection Uploaded Within 24hours">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="left" />
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Labour Inspection Report">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinklabour" Text="INSPECTIONREPORT" Target="_blank" NavigateUrl='<%# Eval("INSPECTIONREPORT") %>' runat="server">View</asp:HyperLink>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Factory Inspection Report">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinkfactory" Text="INSPECTIONREPORT" Target="_blank" NavigateUrl='<%# Eval("FACTORYIRREPORT") %>' runat="server">View</asp:HyperLink>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>

                                                            </asp:GridView>


                                                        </td>
                                                    </tr>
                                                    <tr style="height: 50px">
                                                        <td>
                                                            <h2 class="panel-title" style="font-weight: bold;">Joint Inspections
                                                            </h2>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trjoinfactorylabour" visible="false">
                                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center">
                                                            <asp:GridView ID="grdjoinfactorylabour" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" Width="90%" OnRowCommand="grdjoinfactorylabour_RowCommand" OnRowCreated="grdjoinfactorylabour_RowCreated">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Department Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DEPARTMENTNAME") %>'
                                                                                CommandName="Department" Text='<%# Eval("DEPARTMENTNAME") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labeldept" Text='<%# Eval("DEPARTMENTNAME") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Scheduled Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("SCHEDULED") %>'
                                                                                CommandName="Scheduled" Text='<%# Eval("SCHEDULED") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelschedule" Text='<%# Eval("SCHEDULED") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspections Conducted Together">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("INSPECTEDTOGETHER") %>'
                                                                                CommandName="InspectedTogether" Text='<%# Eval("INSPECTEDTOGETHER") %>'></asp:LinkButton>
                                                                            <asp:Label ID="LabelinspectedTogether" Text='<%# Eval("INSPECTEDTOGETHER") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Conducted">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("INSPECTEDFACTORY") %>'
                                                                                CommandName="InspectedFactory" Text='<%# Eval("INSPECTEDFACTORY") %>'></asp:LinkButton>
                                                                            <asp:Label ID="LabelinspectedFactory" Text='<%# Eval("INSPECTEDFACTORY") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pending">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("PENDINGFACTORY") %>'
                                                                                CommandName="PendingFactory" Text='<%# Eval("PENDINGFACTORY") %>'></asp:LinkButton>
                                                                            <asp:Label ID="LabelpendingFactory" Text='<%# Eval("PENDINGFACTORY") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Conducted">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("INSPECTEDLABOUR") %>'
                                                                                CommandName="InspectedLabour" Text='<%# Eval("INSPECTEDLABOUR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="LabelinspectedLabour" Text='<%# Eval("INSPECTEDLABOUR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Pending">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton7" runat="server" CommandArgument='<%# Eval("PENDINGLABOUR") %>'
                                                                                CommandName="PendingLabour" Text='<%# Eval("PENDINGLABOUR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="LabelpendingLabour" Text='<%# Eval("PENDINGLABOUR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Within 24Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton8" runat="server" CommandArgument='<%# Eval("WITHIN24HR") %>'
                                                                                CommandName="Within24hrs" Text='<%# Eval("WITHIN24HR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelwithin24" Text='<%# Eval("WITHIN24HR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Beyond 24Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# Eval("BEYOND24HR") %>'
                                                                                CommandName="Beyond24hrs" Text='<%# Eval("BEYOND24HR") %>'></asp:LinkButton>
                                                                            <asp:Label ID="Labelbeyond24" Text='<%# Eval("BEYOND24HR") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>


                                                        </td>
                                                    </tr>

                                                    <tr runat="server" id="Reject">
                                                        <td align="center" style="padding: 5px; vertical-align: middle; text-align: center">
                                                            <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
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

                </div>
            </div>
        </div>
    </div>
</asp:Content>

