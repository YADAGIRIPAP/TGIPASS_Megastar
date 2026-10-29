<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="TravelAgencyReport.aspx.cs" Inherits="UI_TSiPASS_TravelAgencyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="assets/css/basic.css" rel="stylesheet" />
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

        th {
            text-align: center;
        }
    </style>
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
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2020:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    minDate: new Date(2020, 11 - 1, 1)

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
            var yrRange = "2020:" + (date.getFullYear() + 1);
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
                    yearRange: yrRange,
                    minDate: new Date(2020, 11 - 1, 1)
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
        });
    </script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js" type="text/javascript"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table>
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large">Travel Agency Report</h1>
                                <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="30px;" height="30px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnExcel_Click" runat="server" title="Export to Excel">
                                            <img src="../../Resource/Images/Excel-icon.png" width="30px;" height="30px;" style="float: right;" title="Export to Pdf" /></a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="left">
                            <table align="center">
                                <tr>
                                    <td>From Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Style="margin: 5px 30px 5px 7px;"
                                            Width="125px"></asp:TextBox>
                                    </td>
                                    <td >To Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Style="margin-left: 5px;"
                                            Width="125px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnData" runat="server" CssClass="btn btn-default" TabIndex="10" Style="margin-left: 50px;"
                                            Text="Get Data" OnClick="btnData_Click" />
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <h4 runat="server" id="header"></h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                           <%-- <tr>
                                                <td style="padding: 5px; margin: 5px; font-size: 13pt" valign="top" class="style8"></td>
                                            </tr>--%>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <div style="width: 100%">
                                                        <asp:GridView ID="gvTravel" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="gvTravel_RowDataBound"
                                                            OnRowCreated="gvTravel_RowCreated" PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4">
                                                            <FooterStyle BackColor="#be8c2f" HorizontalAlign="Center" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DIST_NAME" HeaderText="District">
                                                                    <ItemStyle Width="450px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="No Of Approvals">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hypTRAVEL_AGENCY_COUNT" Text='<%#Eval("TRAVEL_AGENCY_COUNT")%>' />
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Amount">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hypTRAVEL_AGENCY_AMOUNT" Text='<%#Eval("TRAVEL_AGENCY_AMOUNT")%>' />
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No Of Approvals">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hypTOUR_OPERATOR_COUNT" Text='<%#Eval("TOUR_OPERATOR_COUNT")%>' />
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Amount">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hypTOUR_OPERATOR_AMOUNT" Text='<%#Eval("TOUR_OPERATOR_AMOUNT")%>' />
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DistId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDistId" runat="server" Text='<%#Eval("DIST_ID")%>'></asp:Label>
                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#1d9a5b" HorizontalAlign="NotSet" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</asp:Content>

