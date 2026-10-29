<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="OldSanctionedIncentives.aspx.cs" Inherits="UI_TSiPASS_OldSanctionedIncentives" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

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
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
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

    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table style="width: 100%" id="divPrint" runat="server">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading"></h1>
                            </div>

                            <div class="panel-body">
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; font-weight: bold" valign="top">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>District</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDist" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>Incentive Type</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlIncentive" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Unit Name</td>
                                                    <td>
                                                        <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" Height="28px" MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="380px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="text-align: center">
                                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary"
                                                            Height="32px" TabIndex="10" Text="GET OLD SANCTIONED INCENTIVES"
                                                            Width="297px" ValidationGroup="group" OnClick="btnGet_Click" /></td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 10px">&nbsp;</td>

                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div id="Div1" style="width: 100%" runat="server">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4" OnRowDataBound="grdDetails_RowDataBound">
                                                    <%-- <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />--%>

                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="hdfSanctionSlNo" runat="server" />
                                                                <asp:HiddenField ID="hdfUID" runat="server" />
                                                                <asp:HiddenField ID="hdfIncentiveID" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Name_Address" ItemStyle-HorizontalAlign="Center" HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Amount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FinancialYear" ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCNo" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Number">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkView" runat="server" Text="ENTRY" Font-Bold="true" Target="_blank"    />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <FooterStyle BackColor="#1d9a5b" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />

                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 10px">
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div id="Div2" style="width: 100%" runat="server">
                                                <asp:GridView ID="gvData2" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4" OnRowDataBound="gvData2_RowDataBound">
                                                    <%-- <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />--%>

                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                           <asp:TemplateField HeaderText="Please Select If same Unit">
                                                            <ItemTemplate>
                                                               <asp:CheckBox runat="server" ID="chkSameUnit" Text="" AutoPostBack="true" OnCheckedChanged="ChckedChanged"/>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="hdfSanctionSlNo" runat="server" />
                                                                <asp:HiddenField ID="hdfUID" runat="server" />
                                                                 <asp:HiddenField ID="hdfIncentiveID" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Name_Address" ItemStyle-HorizontalAlign="Center" HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Amount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FinancialYear" ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCNo" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Number">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                     <%--   <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkView" runat="server" Text="VIEW" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <FooterStyle BackColor="#1d9a5b" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />

                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr style="height: 10px">
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>

    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();


            $("input[id$='txtCheckdate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtCheckdate']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250p
            ;
            ;
            adding: 0.2em 0.2em 0;
        }
    </style>
</asp:Content>



