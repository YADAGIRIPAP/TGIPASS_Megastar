<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncentiveApplicationsList.aspx.cs" Inherits="UI_TSiPASS_IncentiveApplicationsList" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function RejectValidate()
        {
            return confirm('Do you want to reject the record ?');
        }

        function RejectValidate1() {
            return alert('Please enter the Remarks');
        }
        function RejectValidate2() {
            return alert('Record Deleted Sucessfully');
        }
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="199px">Incentive Applications</asp:Label></h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style26" colspan="5"
                                                style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblhdngmsg" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                    Width="300px"></asp:Label>
                                            </td>
                                            <td class="style27" colspan="4" style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" ShowHeader="true" CellPadding="5" ShowHeaderWhenEmpty="true"
                                                    ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True"
                                                    EmptyDataText="No records found">
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>

                                                        <asp:HyperLinkField HeaderText="View Application" Text="View Application" />
                                                        <asp:HyperLinkField HeaderText="Appraisal Note" Text="View Appraisal Note" />
                                                        <asp:BoundField DataField="UnitName" HeaderText="Name of Unit" Visible="true" />
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                                        <asp:BoundField DataField="CLAIMPERIOD" HeaderText="Claim Period" />
                                                        <asp:BoundField DataField="CASTE" HeaderText="Social Category" />
                                                        <asp:BoundField DataField="DateofReceipt" HeaderText="Application Received Date" />
                                                        <asp:BoundField DataField="RecommendedAmount" HeaderText="Recommended Amount" />
                                                        <asp:TemplateField HeaderText="Applciant Incentive ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEnterperIncentiveID" runat="server" Text='<%# Eval("EnterperIncentiveID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Master Incentive ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveId" runat="server" Text='<%# Eval("IncentiveId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Submit">
                                                            <ItemTemplate>
                                                                <asp:Button ID="BtnApprove" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                    Height="32px" OnClick="BtnApprove_Click" OnClientClick="return confirm('Do you want to Approve the record ? ');"
                                                                    TabIndex="10" Text="Approve" ValidationGroup="group" Width="100px" />
                                                                <br />
                                                                <br />
                                                                <asp:Button ID="BtnReject" runat="server" CausesValidation="False" CssClass="btn-danger"
                                                                    Height="32px" OnClick="BtnReject_Click" OnClientClick="return confirm('Do you want to Return the record ? ');" TabIndex="1" Text="Return" ValidationGroup="group"
                                                                    Width="100px" />
                                                                <br />
                                                                <br />
                                                                <asp:TextBox runat="server" class="form-control txtbox" Height="50px" Width="180px"
                                                                    AutoComplete="false" ID="TxtReject" Visible="false" placeholder="Remarks" TextMode="MultiLine" />
                                                                <br />
                                                                <br />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle BorderStyle="None" BorderColor="White" />

                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:GridView ID="grdCompleted" runat="server" AutoGenerateColumns="False" ShowHeader="true" CellPadding="5" ShowHeaderWhenEmpty="true"
                                                    ForeColor="#333333" Height="62px" OnRowDataBound="grdCompleted_RowDataBound" ShowFooter="True"
                                                    EmptyDataText="No records found">
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>

                                                        <asp:HyperLinkField HeaderText="View Application" Text="View Application" />

                                                        <%--                                                        <asp:BoundField DataField="ApplicationNo" HeaderText="Incentive Application no." />--%>
                                                        <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="UdyogAadhar No." />
                                                        <asp:BoundField DataField="UnitName" HeaderText="Name of Unit" Visible="true" />
                                                        <asp:BoundField DataField="ApplciantName" HeaderText="Applciant Name" Visible="false" />
                                                        <asp:TemplateField HeaderText="Applciant Incentive ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEnterperIncentiveID" runat="server" Text='<%# Eval("EnterperIncentiveID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <%--<asp:BoundField DataField="EnterperIncentiveID" HeaderText="Applciant Incentive ID" Visible="false" />--%>
                                                        <%--<asp:BoundField DataField="IncentiveId" HeaderText="ID of Incentive Name" />--%>
                                                        <asp:TemplateField HeaderText="Master Incentive ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveId" runat="server" Text='<%# Eval("IncentiveId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                                        <asp:BoundField DataField="CASTE" HeaderText="Social Category" />
                                                        <asp:BoundField DataField="DateofReceipt" HeaderText="Application Received Date" />
                                                        <asp:BoundField DataField="RecommendedAmount" HeaderText="Recommended Amount" />
                                                        <asp:HyperLinkField HeaderText="Appraisal Note" Text="View Appraisal Note" />
                                                        <asp:BoundField HeaderText="Status" DataField="Status" />
                                                        <asp:BoundField HeaderText="If Rejected Reason" DataField="REJECTREASON_DEPT" />
                                                        <asp:BoundField HeaderText="Processed Date" DataField="processeddate" />
                                                    </Columns>
                                                    <EmptyDataRowStyle BorderStyle="None" BorderColor="White" />

                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>

                                        </tr>

                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a aria-label="close" class="close" data-dismiss="alert">×</a> <strong>Success!</strong><asp:Label
                                            ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>

                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </td>
                            </tr>
                        </table>



                    </div>

                </div>
            </div>
        </div>

    </div>


</asp:Content>

