<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmBankVistReport213.aspx.cs" Inherits="TSTBDCReg1" %>

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
        </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBankVisit.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a day later than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }

        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">IPO</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Bank Visit Details</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    BANK VISIT </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
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
                                                         <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                        <ItemTemplate>
                                                           <%# Container.DataItemIndex +1 %>
                                                         </ItemTemplate>
                                                           <HeaderStyle HorizontalAlign="Center" />
                                                           <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="SLNo" HeaderText="SLNo" />--%>
                                                            <%-- <asp:BoundField DataField="incentive" HeaderText="Type of Incentive" />--%>
                                                            
                                                            <asp:BoundField DataField="User_name" HeaderText="IPO Name" />
                                                            <%-- <asp:BoundField DataField="UID_No" HeaderText="UID No" />--%>
                                                            <asp:BoundField DataField="BankName" HeaderText="Bank id" />
                                                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                                            <asp:BoundField DataField="MonthName" HeaderText="Month" />
                                                            <asp:BoundField DataField="BankVisit_Year" HeaderText="Year " />
                                                            <asp:BoundField DataField="NatureofLoan" HeaderText="Nature of Loan" />
                                                            <asp:BoundField DataField="LoanAmount" 
                                                                HeaderText="Loan Amount" />
                                                            <asp:BoundField DataField="DateofSanction" HeaderText="DateofSanction" DataFormatString={0:dd-MM-yyyy} />
                                                            <asp:BoundField DataField="PromoterName" 
                                                                HeaderText="Promoter Name" />
                                                            
                                                            
                                                           <%-- <asp:BoundField DataField="Remarks" HeaderText="Remarks" />--%>
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
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
    e
</asp:Content>
