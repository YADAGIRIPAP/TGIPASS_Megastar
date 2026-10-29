<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/R1NewCCMaster.master"
    AutoEventWireup="true" CodeFile="rptR1PrintCFO.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%= PrintPDF.ClientID %>");
            var printWindow = window.print('', '', 'height=650,width=1000');
            printWindow.document.write('<html><head><title>R1: CM DASHBOARD</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function() {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);

            return false;
        }
    </script>

    

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

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <asp:Button Visible="false" ID="Button1" runat="server" Text="Print" OnClick="Button1_Click1"
                                                OnClientClick="window.print();" />
                                            <tr>
                                                <td>
                                                    <div id="PrintPDF" runat="server">
                                                        <table width="100%" style="font-family: Verdana; font-size: 12px">
                                                            <tr runat="server">
                                                                <td align="center" style="padding: 5px; width: 25%; color: #F322EB;
                                                                    margin: 5px; text-align: center;" valign="middle">
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/RptLogo.png" />
                                                                </td>
                                                                <td align="left" style="padding: 5px; margin: 5px; width:100%; text-align: center;" valign="middle"
                                                                    >
                                                                    <h3 align="center" style="vertical-align: middle; font-size: 16px; text-align: center">
                                                                       <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
                                                                    <br />
                                                                    
                                                                    <asp:Label ID="Label1" runat="server" CssClass="align-right">Report as on: 30.03.2016</asp:Label>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" Width="100%">
                                                                        
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                            </asp:TemplateField>
                                                                            <asp:HyperLinkField DataTextField="No of Application" HeaderText="No of Applications">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="No of Approvals Required" HeaderText="Approvals required as per Questionnaire">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="No of Approvals Taken offline" HeaderText="Approvals already obtained">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Net Approvals required" HeaderText="Department Approvals required(Net)">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="No of Approvals Applied for" HeaderText="Approvals Applied">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="LblProjCost" Font-Size="14px" runat="server" CssClass="LBLBLACK">Total Capital Investment (Rs. in Crores)</asp:Label>
                                                                    <asp:LinkButton Font-Underline="false" ForeColor="Black" ID="lbtProjCost" runat="server" Font-Size="14px"
                                                                        PostBackUrl="frmstatus1.aspx" target="_blank"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="621px">PRESCRUTINY STAGE : STATUS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails0" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        OnRowDataBound="grdDetails0_RowDataBound" ShowFooter="false" Width="100%">
                                                                        
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Left"  Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="No Query but Pending" HeaderText="Pending">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        OnRowDataBound="grdDetails3_RowDataBound" ShowFooter="false" Width="100%">
                                                                        
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid3" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid3" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Right" Width="220px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="400px">APPROVAL STAGE : STATUS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        OnRowDataBound="grdDetails1_RowDataBound" ShowFooter="false" Width="100%">
                                                                        
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid1" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid1" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Left" Width="220px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="Approved" HeaderText="Approved">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Under Process" HeaderText="Under Process">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Rejected" HeaderText="Rejected">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label484" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="400px">TS-iPASS APPROVAL : UNIT WISE STATUS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" 
                                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                                    <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails2_RowDataBound"
                                                                        PageSize="15" Width="100%">
                                                                       
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid2" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid2" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Right" Width="220px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="Total Appliacations Fully Paid" HeaderText="Units">
                                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total Appliacations Approved with in Time Limits"
                                                                                HeaderText="% Approvals within time limits">
                                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="TotalAppliacationsApprovedbeyondTimeLimits" HeaderText="% Approvals beyond time limits">
                                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Grand Total" HeaderText="Total">
                                                                                <ItemStyle Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
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
