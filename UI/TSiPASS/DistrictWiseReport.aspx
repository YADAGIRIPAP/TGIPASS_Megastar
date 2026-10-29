<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="~/UI/TSiPASS/DistrictWiseReport.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        .GRD
        {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }
        
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        
        .GRDHEADER
        {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function doPrint() {
            var prtContent = document.getElementById('<%= grdDetails.ClientID %>');
            prtContent.border = 2; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i>
                        <asp:Label ID="lblHeading2" runat="server"></asp:Label>
                    </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#"></a></li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <%--<tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                            class="style8" align="center">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" 
                                                class="form-control txtbox" Height="33px" 
                                                onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged" 
                                                Width="180px" Visible="False">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>--%>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/HomeCommDashboard.aspx">Back</asp:HyperLink>
                                                    <a id="A1" href="#" visible="true" runat="server" onclick="doPrint()">
                                                        <img src="../../images/png-for-print-1.png" width="50px;" height="20px;" style="float: right;"
                                                            alt="PDF" /></a>
                                                    <%-- <a id="btnPrnt" href="#" onclick="doPrint()" runat="server">
                                             
                                              <img src="../../images/png-for-print-1.png" width="50px;" height="20px;" style="float: right;"
                                                  alt="PDF" /></a>--%>
                                                    <a id="Button2" href="#" onclick="javascript:return Panel1();" runat="server" visible="false">
                                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                            alt="PDF" /></a>
                                                    <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%>
                                                    <a id="A2" href="#" onserverclick="BtnPDF_Click" runat="server">
                                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                            alt="PDF" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="left">
                                                </td>
                                                <td style="padding: 5px; margin: 5px; margin-left: 149px;" colspan="3" align="center">
                                                    <asp:RadioButtonList ID="rbtnlstInputType" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="rbtnlstInputType_SelectedIndexChanged">
                                                        <asp:ListItem Value="F">Financial Years</asp:ListItem>
                                                        <asp:ListItem Value="N" Selected="True">Between Dates</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trFinYears" visible="false">
                                                <td style="padding: 5px; margin: 5px" align="left">
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="center" colspan="3">
                                                    <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlFinancialYear_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="250px">TS-iPASS District Wise
                                            Report</asp:Label>
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" BorderColor="Black"
                                                        CellPadding="5" CssClass="GRD" ForeColor="#333333" Height="62px" OnRowCreated="grdDetails_RowCreated"
                                                        OnRowDataBound="grdDetails_RowDataBound" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged"
                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
                                                            <asp:HyperLinkField DataTextField="District Level" HeaderText="District Level" />
                                                            <asp:HyperLinkField DataTextField="State Level" HeaderText="State Level" />
                                                            <asp:HyperLinkField DataTextField="District Level1" HeaderText="District Level" />
                                                            <asp:HyperLinkField DataTextField="State Level1" HeaderText="State Level" />
                                                            <asp:HyperLinkField DataTextField="District Level2" HeaderText="District Level" />
                                                            <asp:HyperLinkField DataTextField="State Level2" HeaderText="State Level" />
                                                            <asp:HyperLinkField DataTextField="District Level Rejected" HeaderText="District Level" />
                                                            <asp:HyperLinkField DataTextField="State Level Rejected" HeaderText="State Level" />
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White"
                                                            HorizontalAlign="Center" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    &nbsp;
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
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
