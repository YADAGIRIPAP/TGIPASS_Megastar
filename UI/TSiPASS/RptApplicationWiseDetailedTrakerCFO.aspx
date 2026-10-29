<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="RptApplicationWiseDetailedTrakerCFO.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }

    </script>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">APPLICATION WISE DETAILED TRACKER REPORT</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                            <tr>
                                <td align="center"
                                    style="padding: 5px; margin: 5px; text-align: center;" colspan="3">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" TabIndex="10" Text="Search"
                                        Width="90px" OnClick="BtnSave1_Click" Visible="False" />
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="90px"
                                        Visible="False" />
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana"
                                        Font-Size="13px" ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center"
                                    style="padding: 5px; margin: 5px; text-align: center;" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px;">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%"
                                        __designer:mapid="363">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">1. UID 
                                                        Number</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labUidNumber" runat="server" CssClass="LBLBLACK" Width="165px">MG07003123456</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label353" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">2. Name of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labNameandAddress" runat="server" CssClass="LBLBLACK"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label355" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">3. 
                                                        Line of Activity</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labLineofActivity" runat="server" CssClass="LBLBLACK"
                                                    Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label357" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">4. 
                                                        Total Investment</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labTotalInvestment" runat="server" CssClass="LBLBLACK"
                                                    Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px;"></td>
                                <td align="center"
                                    style="padding: 5px; margin: 5px; height: 102px; vertical-align: top;">
                                    <table cellpadding="4" cellspacing="5"
                                        style="width: 100%; vertical-align: top;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="365">
                                                <asp:Label ID="Label359" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True" Visible="False">5. 
                                                        Category of Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="367">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="368">
                                                <asp:Label ID="labCategoryofIndustry" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="36b">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label361" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">6. 
                                                        Date of Application</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labDOA" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label362" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">7. Address of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labNameandAddress0" runat="server" CssClass="LBLBLACK"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; height: 280px;"
                                    colspan="3">
                                    <asp:GridView ID="grdDetails" runat="server"
                                        AutoGenerateColumns="False" CellPadding="4" CssClass="GRD"
                                        ForeColor="#333333" Height="62px"
                                        OnRowDataBound="grdDetails_RowDataBound" PageSize="20" Width="100%"
                                        OnPageIndexChanging="grdDetails_PageIndexChanging" ShowFooter="True"
                                        OnRowCreated="grdDetails_RowCreated" BorderColor="Black">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                            VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataTextField="Name of Approvals required as per Questionnaire" HeaderText="Name of Approvals required as per Questionnaire" />
                                            <asp:HyperLinkField DataTextField="Name of the Department" HeaderText="Name of the Department" />
                                            <asp:HyperLinkField DataTextField="Already taken offline approval" HeaderText="Already taken offline approval" />
                                            <asp:HyperLinkField DataTextField="Date of Application" HeaderText="Date of Application" />
                                            <asp:HyperLinkField DataTextField="Not Yet Applied" HeaderText="Not Yet Applied" />
                                            <asp:HyperLinkField DataTextField="Date of Query raised by Dept" HeaderText="Date of Query raised by Dept" />
                                            <asp:HyperLinkField DataTextField="Date of response to query by applicant" HeaderText="Date of response to query by applicant" />
                                            <asp:HyperLinkField DataTextField="Status Pre-scrutiny (Completed / Pending / Query raised" HeaderText="Status Pre-scrutiny (Completed / Pending / Query raised)" />
                                            <asp:HyperLinkField DataTextField="Number of days taken " HeaderText="Number of days taken" />
                                            <asp:HyperLinkField DataTextField="Date of Payemnt" HeaderText="Date of Payment" />
                                            <asp:HyperLinkField DataTextField="Amount Paid" HeaderText="Amount Paid (Rs)" />
                                            <asp:HyperLinkField DataTextField="ApprovedStat" HeaderText="Status (Approved/ Under Process/ Rejected" />
                                            <asp:HyperLinkField DataTextField="ApprovedDate" HeaderText="Date of Approval / Rejection" />
                                            <asp:HyperLinkField DataTextField="ApprovalNoofDays" HeaderText="Number of days taken for Approval / Rejection" />
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Certificate">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="HyperLink1" PostBackUrl='<%# Eval("link") %>' runat="server">Certificate</asp:LinkButton>--%>
                                                    <asp:HyperLink ID="HyperLink2" Text='<%# Eval("FileName") %>' Target="_blank" NavigateUrl='<%# Eval("link") %>' runat="server">Certificate</asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                            ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%"
                                        __designer:mapid="363">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label363" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">21. STATUS OF TSIPASS APPROVAL</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labUidNumber0" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label364" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">22. DATE OF APPROVAL / REJECTION</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labNameandAddress1" runat="server" CssClass="LBLBLACK"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                <td align="center" style="padding: 5px; margin: 5px; vertical-align: top;">
                                    <table cellpadding="4" cellspacing="5"
                                        style="width: 100%; vertical-align: top;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="365">
                                                <asp:Label ID="Label367" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">23. NUMBER OF DAYS TAKEN FOR APPROVAL</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="367">:</td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="368">
                                                <asp:Label ID="labCategoryofIndustry0" runat="server" CssClass="LBLBLACK"
                                                    Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="36b">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

