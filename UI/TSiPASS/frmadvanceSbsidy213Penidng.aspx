<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmadvanceSbsidy213Penidng.aspx.cs" Inherits="TSTBDCReg1" %>

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
        .style5
        {
            width: 17px;
        }
        .style8
        {
            width: 30px;
            height: 25px;
        }
        .style9
        {
            width: 216px;
            height: 25px;
        }
        .style10
        {
            width: 36px;
        }
        .style11
        {
            width: 4px;
            height: 25px;
        }
        .style12
        {
            height: 25px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupfrmadvanceSbsidy.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
<asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    ADVANCE SUBSIDY </h3>
                            </div>
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1</td>
                                                            <td class="style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="210px">Month<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlmonth0" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="center" class="style10" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                                2</td>
                                                            <td class="style9">
                                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK">Year<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlyear0" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="2018">2018</asp:ListItem>
                                                                    <asp:ListItem Value="2017">2017</asp:ListItem>
                                                                    <asp:ListItem Value="2016">2016</asp:ListItem>
                                                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-primary" 
                                                        Height="32px" OnClick="BtnSave4_Click" TabIndex="10" Text="Search" 
                                                        Width="90px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="BtnClear1" runat="server" CausesValidation="False" 
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear1_Click" TabIndex="10" 
                                                        Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:GridView ID="gvCertificate0" runat="server" AllowPaging="True" 
                                                        AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333" 
                                                        Height="62px" onpageindexchanging="grdDetails_PageIndexChanging" 
                                                        onrowcreated="grdDetails_RowCreated" OnRowDataBound="grdDetails_RowDataBound" 
                                                        onselectedindexchanged="grdDetails_SelectedIndexChanged" PageSize="20" 
                                                        ShowFooter="True" Width="100%">
                                                        <RowStyle BackColor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                            verticalalign="Middle" />
                                                        <Columns>
                                                            <%--<asp:BoundField DataField="SLNo" HeaderText="SLNo" />--%>
                                                            <%-- <asp:BoundField DataField="incentive" HeaderText="Type of Incentive" />--%>
                                                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                            <asp:BoundField DataField="User_name" HeaderText="IPO Name" />
                                                           <%-- <asp:BoundField DataField="UID_No" HeaderText="UID No" />--%>
                                                            <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                            <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                            <asp:BoundField DataField="MonthName" HeaderText="Month" />
                                                            <asp:BoundField DataField="VI_Year" HeaderText="Year " />
                                                            <asp:BoundField DataField="FirstInstalment" HeaderText="First Instalment" />
                                                            <asp:BoundField DataField="DateofReleaseFirstInstalment" HeaderText="Date of Release First Instalment" DataFormatString={0:dd-MM-yyyy} />
                                                            <asp:BoundField DataField="SecondInstalment" HeaderText="Second Instalment" />
                                                            <asp:BoundField DataField="DateofReleaseSecondInstalment" HeaderText="Date of Release Second Instalment"  DataFormatString={0:dd-MM-yyyy}  />
                                                            <%--<asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" />--%>
                                                            <asp:BoundField DataField="SubsidyStatus" HeaderText="Subsidy Status" />
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" cssclass="GRDHEADER" Font-Bold="True" 
                                                            ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
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
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
