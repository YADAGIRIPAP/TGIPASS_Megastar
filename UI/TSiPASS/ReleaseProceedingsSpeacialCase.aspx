<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReleaseProceedingsSpeacialCase.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="ReleaseProceedingsSpeacialCase" %>


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
        function Panel1() {


            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');
            printWindow.document.write('<h3 style="width: 100%;text-align: center;">Commissionerate of Industries :: Hyderabad</h3>');
            printWindow.document.write('<center> <img src="telanganalogo.png" width="75px" height="75px" /> </center>');
            printWindow.document.write('<h4 align="left" style="font-size: Large" id="h1heading"><u><b>List of cases sanctioned incentives :</b></u></h4>');
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
    <div align="left" id="divPrint" runat="server">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">List of cases sanctioned incentives
                                </h1>
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%" id="Table1" runat="server">
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-primary" Height="40px" TabIndex="10" Text="BACK" Width="120px" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveProceedingsStep1.aspx?Stg=5" Visible="false"></asp:HyperLink>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="40px"
                                                        TabIndex="10" Text="PRINT" Visible="false" Width="111px" OnClientClick="javascript:Panel1()" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<div class="col-md-12">
                                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1">
                                                </h1>
                                            </div>--%>
                                            <div class="panel-body">
                                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td colspan="4" align="left">
                                                            <asp:CheckBox ID="chkIsSpecialUnit" Font-Size="Medium" Font-Bold="true" runat="server"
                                                                Text="Is Special Release Units"

                                                                AutoPostBack="true" Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="panel-body">
                                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                                                <tr id="tblspecialcasesSearch" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; font-weight: bold" valign="top">
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <td style="width: 20%">District
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:DropDownList ID="ddlDist" runat="server" class="form-control txtbox" Height="33px"
                                                                                        Width="180px">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                
                                                                                <td style="width: 20%">IncentiveType
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:DropDownList ID="ddlIncentiveType" runat="server" class="form-control txtbox" Height="33px">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Unit Name
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" Height="28px"
                                                                                        MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="300px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Social Status<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" RepeatDirection="Horizontal"
                                                                        TabIndex="1" Height="33px" Width="180px" OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged" AutoPostBack="true">
                                   
                                                                        <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                                        <asp:ListItem Value="1">General</asp:ListItem>
                                                                        <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                        <asp:ListItem Value="3">SC</asp:ListItem>
                                                                        <asp:ListItem Value="4">ST</asp:ListItem>
                                                                        <asp:ListItem Value="5">Minority</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trddlslc" runat="server" visible="false">
                                                                                <td style="width: 20%">SLC Number
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:DropDownList ID="ddlSLCNo" runat="server" class="form-control txtbox" Height="33px">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" style="text-align: center">
                                                                                    <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                                                                        Text="GET Unit Details" Width="200px" ValidationGroup="group" OnClick="btnGet_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trlblmsg" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">No Records Found
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr1" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">Please Select Special Case Units
                                                                    </td>
                                                                </tr>
                                                                <tr id="trsearchresult" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                                        <div id="Div2" style="width: 100%" runat="server">
                                                                            <asp:GridView ID="gvData2" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                                                Width="100%" CellSpacing="4" OnRowDataBound="gvData2_RowDataBound" EmptyDataText="No Results Found" EnableViewState="true">
                                                                                <%-- <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />--%>
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Select">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox runat="server" ID="chkSameUnit" Text="" AutoPostBack="true" OnCheckedChanged="ChckedChanged" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                                                    <asp:BoundField DataField="DCP" HeaderText="DCP" />
                                                                                    
                                                                                   

                                                                                    <%--<asp:BoundField DataField="ReleasedAmount" HeaderText="Released Amount" />--%>
                                                                                    <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>

                                                                                    <asp:TemplateField HeaderText=" Total Sanction Amount" Visible="true">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbltotalSanctionAmount" Text='<%#Eval("SanctionedAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                     <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />

                                                                                    <asp:TemplateField HeaderText=" Total Released Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblReleasedAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                     <asp:TemplateField HeaderText=" Pending Sanctioned Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPendingSanctionAmount" Text='<%#Eval("SanctionedAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                   <%-- <asp:BoundField DataField="SanctionedAmount" HeaderText=" Pending Sanctioned Amount" />--%>
                                                                                    

                                                                                    <asp:TemplateField HeaderText="Pending Amount" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblpendingAmount" Text='<%#Eval("PendingAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                   
                                                                                    <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="SlNo" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblslno" Text='<%#Eval("tdSanctcionSlcSlno") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="SLCNumer" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSLCNumer" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:HyperLink ID="anchortaglinkAdd" runat="server" Text="ADD" Font-Bold="true" ForeColor="Green"
                                                                                                Target="_blank" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>

                                                               <%-- added by sridhar--%>

                                                                 <tr id="trsearchresult1" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                                        <div id="Div3" style="width: 100%" runat="server">
                                                                            <asp:GridView ID="gvData3" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                                                Width="100%" CellSpacing="4" OnRowDataBound="gvData3_RowDataBound" EmptyDataText="No Results Found">
                                                                                <%-- <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />--%>
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Select" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox runat="server" ID="chkSameUnit" Text="" AutoPostBack="true"  />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                                                    <asp:BoundField DataField="DCP" HeaderText="DCP" />
                                                                                    <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount" />
                                                                                  

                                                                                    <asp:TemplateField HeaderText="Released Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblReleasedAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Pending Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPendingAmount" Text='<%#Eval("PendingAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    
                                                                                    
                                                                                    <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="SLCNumer" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSLCNumer" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:HyperLink ID="anchortaglinkAdd" runat="server" Text="ADD" Font-Bold="true" ForeColor="Green"
                                                                                                Target="_blank" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <%------------------------------------------ADDED BY SRIDHAR--%>
                                                    <tr>
                                                        <td colspan="12" style="padding: 5px; margin: 5px; font-weight: bold" align="left" runat="server" visible="false" id="trslAmount"
                                                            class="style7" >&nbsp;&nbsp;&nbsp; Remaining Amount :
                                            <asp:Label ID="lblslcRemaingAmount" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px" runat="server" id="trslc" visible="false">
                                                        <td colspan="12" style="padding-bottom: 10px;">
                                                            <div style="margin-top: 10px;">
                                                                <div style="float: left; margin-left: 20px; margin-right: 180px;">
                                                                    <label style="font-weight: bold; float: left">Release Amount.<font color="red" size="3"><font color="red">*</font></font> :</label>
                                                                    <asp:TextBox runat="server" ID="txtReleasingSlcSpeacCaseAmount" class="form-control txtbox" Height="28px" OnTextChanged="txtReleasingSlcSpeacCaseAmount_TextChanged" onkeypress="DecimalOnly()" AutoPostBack="true" Style="float: left" TabIndex="1" Width="150px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReleasingSlcSpeacCaseAmount" ErrorMessage="Please Enter Release proceeding Amount " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div style="float: left;">
                                                                    <div>
                                                                        <label style="font-weight: bold; float: left">Release Proceding Date <font color="red" size="3"><font color="red">*</font></font> :</label>
                                                                        <asp:TextBox runat="server" ID="txtReleasingSlcSpeacCaseDate" class="form-control txtbox" Height="28px" Style="float: left" placeholder="DD/MM/YYYY" TabIndex="1" Width="150px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReleasingSlcSpeacCaseDate" ErrorMessage="Please Enter Release Proceding Date " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>


                                                    </tr>

                                                    <tr style="height: 40px" runat="server" id="trslc1" visible="false">
                                                        <td colspan="12" style="padding-bottom: 10px;">
                                                            <div style="margin-top: 10px;">
                                                                <div style="float: left; margin-left: 20px; margin-right: 180px;">
                                                                    <label style="font-weight: bold; float: left">GO.NO.<font color="red" size="3"><font color="red">*</font></font> :&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                                                    <asp:TextBox runat="server" ID="txtSpeacialCaseGoNo" class="form-control txtbox" Height="28px" Style="float: left" TabIndex="1" Width="150px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReleasingSlcSpeacCaseAmount" ErrorMessage="Please Enter Release proceeding Amount " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </div>
                                                                
                                                                <div style="float: left;">
                                                                    <label style="font-weight: bold; float: left">Sanctioned Amount.<font color="red" size="3"><font color="red">*</font></font> :&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                                                    <asp:TextBox runat="server" ID="txtActualSanctionAmount" class="form-control txtbox" Height="28px" Style="float: left" TabIndex="1" Width="150px" Enabled="false"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReleasingSlcSpeacCaseAmount" ErrorMessage="Please Enter Release proceeding Amount " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                                
                                                        </td>


                                                    </tr>

                                                    <tr style="height: 40px" runat="server" id="trslc2" visible="false">
                                                        <td colspan="12" style="padding-bottom: 10px;">
                                                            <div style="margin-top: 10px;">
                                                                <div style="float: left; margin-left: 20px; margin-right: 180px;">
                                                                    <label style="font-weight: bold; float: left">Pending Amount.<font color="red" size="3"><font color="red">*</font></font> :</label>
                                                                    <asp:TextBox runat="server" ID="txtPendingAmount" class="form-control txtbox" Height="28px" Style="float: left" TabIndex="1" Width="150px" Enabled="false"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtReleasingSlcSpeacCaseAmount" ErrorMessage="Please Enter Release proceeding Amount " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div style="margin-top: 10px;">
                                                                <div style="float: left; margin-left: 20px; margin-right: 180px;">
                                                                    <label style="font-weight: bold; float: left">Remarks.<font color="red" size="3"><font color="red">*</font></font> :&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                                                    <asp:TextBox runat="server" ID="txtRemarks" class="form-control txtbox" Height="28px" Style="float: left" TabIndex="1" Width="150px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtReleasingSlcSpeacCaseAmount" ErrorMessage="Please Enter Release proceeding Amount " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                                
                                                            </div>
                                                        </td>


                                                    </tr>

                                                    <tr id="trUpdate" runat="server" visible="false">
                                                        <td colspan="3" style="padding: 5px; margin: 5px" align="center" class="style7" id="Td1"
                                                            runat="server">
                                                            <br />
                                                            <asp:Button ID="btnUpdate" runat="server" Visible="false" CssClass="btn btn-primary"
                                                                Height="38px" TabIndex="10" Text="UPDATEDETAILS" Width="160px" OnClick="btnUpdate_Click" />
                                                        </td>
                                                    </tr>
                                                    <%-- -----------------------------------UPTO HERE-----------------%>

                                                    <tr>
                                                        <td>
                                                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%" id="tblselectedcases"
                                                                runat="server" visible="false">
                                                                <tr id="tr2" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">Selected Special Case Units
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                                        <div id="Div1" style="width: 100%" runat="server">
                                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4"
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
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                                                    <asp:BoundField DataField="DCP" HeaderText="DCP" />
                                                                                    <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount" />
                                                                                    <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                                                    <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>

                                                                                    <asp:TemplateField HeaderText="Released Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblReleasedAmount" Text='<%#Eval("ReleasedAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Alloted Amount" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label2" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label3" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="SLCNumer" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label4" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="anchortaglinkDelete" runat="server" Text="DELETE" Font-Bold="true"
                                                                                                ForeColor="Green" CommandName="delete" CommandArgument='<%#Eval("EnterperIncentiveID") %>' />
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trRemainingAmount2" runat="server" visible="false">
                                        <td colspan="12" style="padding: 5px; margin: 5px; font-weight: bold" align="left"
                                            class="style7">&nbsp;&nbsp;&nbsp; Remaning Amount :
                                            <asp:Label ID="lblremaingAmount2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr id="trprint" runat="server" visible="false">
                                        <td colspan="3" style="padding: 5px; margin: 5px" align="center" class="style7" id="tblselection"
                                            runat="server">
                                            <br />
                                            <asp:Button ID="btnNext" runat="server" Visible="false" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="10" Text="NEXT" Width="120px"  />
                                        </td>
                                    </tr>
                                </table>
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%" id="tblmain"
                                    runat="server" visible="false">

                                    <tr id="trno" runat="server">
                                        <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top"
                                            colspan="12" runat="server" id="tdinvestments">List of cases sanctioned incentives
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                            <div style="width: 100%">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
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
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                                        <asp:BoundField DataField="DCP" HeaderText="DCP" />
                                                        <asp:BoundField DataField="SanctionedAmount" ItemStyle-CssClass="rowAmt" HeaderText="Sanctioned Amount" />
                                                        <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                        <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>
                                                        <asp:TemplateField HeaderText="Alloted Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAllotedAmount" Text='<%#Eval("AllotedAmount") %>' CssClass="rowAmt" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SLCNumer" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSLCNumer" Text='<%#Eval("SLCNumer") %>' runat="server" />
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
                                        <td colspan="12" style="padding: 5px; margin: 5px; font-weight: bold" align="left"
                                            class="style7">&nbsp;&nbsp;&nbsp; Remaning Amount :
                                            <asp:Label ID="lblremaingAmount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--     <tr style="height: 30px" id="tradditional" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold; width: 10px">1.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">G.O No. </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td>
                                            <asp:TextBox ID="txtGoNo" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">2.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">G.O Date
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox runat="server" ID="txtGodate" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 30px" id="tr1" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">LOC No. </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td>
                                            <asp:TextBox ID="txtLocno" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">4.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">LOC Date
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox runat="server" ID="txtLocdate" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>--%>


                                    <tr style="height: 40px">
                                        <td colspan="12" style="padding-bottom: 10px;">
                                            <div style="margin-top: 10px;">
                                                <div style="float: left; margin-left: 20px; margin-right: 180px;">
                                                    <label style="font-weight: bold; float: left">Release Proceding No.<font color="red" size="3"><font color="red">*</font></font> :</label>
                                                    <asp:TextBox runat="server" ID="txtRelProNo" class="form-control txtbox" Height="28px" Style="float: left" TabIndex="1" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRelProNo" ErrorMessage="Please Enter Release Proceding No " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div style="float: left;">
                                                    <div>
                                                        <label style="font-weight: bold; float: left">Release Proceding Date <font color="red" size="3"><font color="red">*</font></font> :</label>
                                                        <asp:TextBox runat="server" ID="txtRelProDate" class="form-control txtbox" Height="28px" Style="float: left" placeholder="DD/MM/YYYY" TabIndex="1" Width="150px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRelProDate" ErrorMessage="Please Enter Release Proceding Date " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr style="height: 30px">
                                        <td>
                                            <div style="float: left; margin-top: 5px; margin-left: 20px;">
                                                <label style="font-weight: bold">
                                                    Upload Release Proceding Copy :</label>
                                            </div>
                                            <div style="float: left">
                                                <asp:FileUpload ID="fucReleaseProCopy" runat="server" class="form-control txtbox" />
                                            </div>
                                            <div style="float: left">
                                                <asp:Button runat="server" Text="Upload" ID="bntUpload" CssClass="btn btn-primary"
                                                    Style="margin-left: 12px; margin-top: 1px;" OnClick="bntUpload_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:HyperLink runat="server" ID="lnkReleaseCopy" Target="_blank" Style="margin-left: 262px;"></asp:HyperLink>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" align="center" style="padding-top: 50px;">
                                            <asp:Button ID="Button3" runat="server" ValidationGroup="group" CssClass="btn btn-primary" Height="32px"
                                                TabIndex="10" Text="Submit" Width="100px" />
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
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;
                        </td>
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
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <style>
        .totalCol {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtGodate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtLocdate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 
            $("input[id$='txtRelProDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtReleasingSlcSpeacCaseDate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               });
        }
        $(function () {

            var totals = [0, 0];
            $("#ctl00_ContentPlaceHolder1_grdDetails").append('<tr class="totalColumn" align="left" valign="middle"><td style="width:50px;"></td><td colspan="3" style="font-weight:bold;text-align:center;">Total</td><td class="totalCol"></td><td ></td><td class="totalCol"></td><td></td></tr>')

            var $dataRows = $("#ctl00_ContentPlaceHolder1_grdDetails tr:not('.totalColumn')");

            $dataRows.each(function () {
                $(this).find('.rowAmt').each(function (i) {
                    if ($(this).html() != '') {
                        totals[i] += parseInt(parseFloat($(this).html()) * 100, 10) / 100;
                    }
                });
            });
            $("#ctl00_ContentPlaceHolder1_grdDetails td.totalCol").each(function (i) {
                // $(this).html(totals[i].toFixed(2).replace(/\d(?=(?:\d{2})+\.)/g, '$&,'));
                $(this).html(NumberToIndianRupees(totals[i].toFixed(2)));
            });



            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtGodate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback
            $("input[id$='txtLocdate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
        });

        function NumberToIndianRupees(x) {
            x = x.toString();
            var afterPoint = '';
            if (x.indexOf('.') > 0)
                afterPoint = x.substring(x.indexOf('.'), x.length);
            x = Math.floor(x);
            x = x.toString();
            var lastThree = x.substring(x.length - 3);
            var otherNumbers = x.substring(0, x.length - 3);
            if (otherNumbers != '')
                lastThree = ',' + lastThree;
            var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;
            return res;
        }

    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
</asp:Content>
