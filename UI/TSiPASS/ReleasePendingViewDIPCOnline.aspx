<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ReleasePendingViewDIPCOnline.aspx.cs" Inherits="UI_TSIPASS_ReleasePendingViewDIPCOnline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function Panel1() {


            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;
        }

        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <style type="text/css">
        .overlay
        {
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
        
        .CS
        {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }
        
        .update
        {
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
        
        .style7
        {
            color: #FF3300;
        }
        
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        
        .GRD
        {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }
        
        .GRDHEADER
        {
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
        
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        
        .LBLBLACK
        {
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
                <table style="width: 100%" id="divPrint" runat="server">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">
                                    List of cases sanctioned incentives
                                </h1>
                            </div>
                            <div class="panel-body">
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr id="trno" runat="server">
                                        <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top"
                                            colspan="12" runat="server" id="tdinvestments">
                                            List of cases sanctioned incentives
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                            <div style="width: 100%">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="false"
                                                    Width="100%" CellSpacing="4" OnRowDataBound="grdDetails_RowDataBound">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ApplicationNo" ItemStyle-HorizontalAlign="Center"
                                                            HeaderText="Online Application Number">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NameofUnitAddress" ItemStyle-HorizontalAlign="Center"
                                                            HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt of Application">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center" Visible="false"
                                                            HeaderText="G.M Recommended Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount by DIPC">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <%-- <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>--%>
                                                        <asp:BoundField DataField="DIPCNumer" ItemStyle-HorizontalAlign="Center" HeaderText="DIPC Numer">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="DIPC Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="DIPC Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Intimation Letter/Status">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagGMCertificate" Target="_blank" runat="server" Text="Intimation Letter"></asp:HyperLink>
                                                                <asp:Label ID="lbloffiline" Visible="false" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Scheme" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScheme" Text='<%#Eval("Scheme") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DIPCNumer" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDIPCNumer" Text='<%#Eval("DIPCNumer") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="OfflineFlag" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOfflineFlag" Text='<%#Eval("OfflineFlag") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                        <td colspan="12" style="padding: 5px; margin: 5px" align="center" class="style7">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" style="padding: 5px; margin: 5px" align="center" class="style7"
                                            id="tblselection" runat="server">
                                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Visible="false"
                                                Text="Submit Proposed DIPC Agenda" />
                                            &nbsp; &nbsp;
                                            <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary" Visible="true"
                                                Text="Print Agenda" OnClientClick="javascript:Panel1()" />
                                            &nbsp; &nbsp;
                                            <%--<input type="button" value="Print" class="btn btn-primary" onclick="javascript:CallPrint('divPrint')" />--%>
                                            <asp:Button ID="Button6" CssClass="btn btn-primary" Visible="false" runat="server"
                                                Text="Download PDF" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="group" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                    &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

