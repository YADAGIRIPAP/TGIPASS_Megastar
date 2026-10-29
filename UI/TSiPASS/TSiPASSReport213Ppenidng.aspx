<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="TSiPASSReport213Ppenidng.aspx.cs" Inherits="TSTBDCReg1" %>

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

            window.open("Lookups/LookupTSiPASSReport4.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        }
        function getChildControl() {
            if (win != null && !win.closed) {

                var form1 = win.document.getElementsbyId("ctl00_ContentPlaceHolder1_hdfID").value;
                alert(form1);
            }
        }

        function Load_hdfID(val) {
            win.close();
            $get("ctl00_ContentPlaceHolder1_hdfID").value = val;
            __doPostBack("LOOKUP", val);
            alert(val);
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
                                    TS-IPASS Details</h3>
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
                                                             <asp:BoundField DataField="UID_No" HeaderText="UID No" />
                                                            <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                            <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                            <asp:BoundField DataField="MonthName" HeaderText="Month" />
                                                            <asp:BoundField DataField="VI_Year" HeaderText="Year " />
                                                            
                                                            <asp:BoundField DataField="iPASSStatus" HeaderText="TSiPASS Status" />
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
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
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
