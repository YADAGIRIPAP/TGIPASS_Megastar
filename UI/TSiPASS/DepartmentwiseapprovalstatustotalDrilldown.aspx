<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DepartmentwiseapprovalstatustotalDrilldown.aspx.cs" Inherits="UI_TSiPASS_DepartmentwiseapprovalstatustotalDrilldown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                    valign="top" align="center">
                    <div class="col-lg-14" style="margin-left: 0px;">
                        <div class="panel panel-default">
                            <div class="panel-heading" >
                                <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                                <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server" Visible="false"> Incentives Applications- Department Wise Applications Status  </asp:Label>
                                    <a id="Button2" href="#" onserverclick="Button2_ServerClick1"
                                        runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="30px;" height="30px;" style="float: right;"
                                            alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick1" runat="server">
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                    alt="Excel" /></a></h2>
                            </div>
                        </div>
                    </div>
                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                        <tr>
                            <td style="padding: 5px; margin: 5px">
                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/Departmentwiseapprovalstatus.aspx"
                                    Text="<< Back">
                                </asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">

                            <tr id="GridPrint" runat="server">
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                        Width="100%"
                                        ShowFooter="True">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ApplicationNo" HeaderText="Application Number" />

                                            <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="UdyogAadhar No." />
                                            <asp:BoundField DataField="UnitName" HeaderText="Name of Unit" Visible="true" />
                                            <asp:BoundField DataField="ApplciantName" HeaderText="Applciant Name" />
                                            <asp:BoundField DataField="EnterperIncentiveID" HeaderText="Enterpreneur Incentive ID" />
                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive ID " />
                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />

                                            <asp:BoundField DataField="CASTE" HeaderText="Social Category" />
                                            <asp:BoundField DataField="DateofReceipt" HeaderText="Application Received Date" />
                                            <asp:BoundField DataField="RecommendedAmount" HeaderText="Recommended Amount" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <asp:BoundField DataField="Processeddate" HeaderText="ProcessDate" />
                                            <asp:BoundField DataField="RejectedReason" HeaderText="Returned Reason" />
                                            <%-- <asp:BoundField DataField="Dept" HeaderText=" Processed by Department"  visible="false"/>--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
    </div>
</asp:Content>

