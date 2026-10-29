<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  CodeFile="UserDashboardrenewal_EODB.aspx.cs" Inherits="UI_TSiPASS_UserDashboardrenewal_EODB" %>

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
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">5. 
                                                        Industry Scale</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lblindustryscale" runat="server" CssClass="LBLBLACK"
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
                                        <tr runat="server" visible="false">
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
                                                    Font-Bold="True">6. Address of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="labNameandAddress0" runat="server" CssClass="LBLBLACK"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">7. Risk Category</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lblriskcategory" runat="server" CssClass="LBLBLACK"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Font-Bold="True">9. Type of Business</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lbltypeofbusiness" runat="server" CssClass="LBLBLACK"
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
                                        PageSize="20" Width="100%"
                                        ShowFooter="True"
                                        BorderColor="Black">
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
                                            <asp:HyperLinkField DataTextField="Department" HeaderText="Department" />
                                            <asp:HyperLinkField DataTextField="Compliance" HeaderText="Compliance" />
                                            <asp:HyperLinkField DataTextField="ComplianceDocument" HeaderText="Compliance Document (Download)" />
                                            <asp:HyperLinkField DataTextField="Actapplicable" HeaderText="Act applicable" />
                                            <asp:HyperLinkField DataTextField="Rulesapplicable" HeaderText="Rules applicable" />
                                            <asp:HyperLinkField DataTextField="Penalprovision" HeaderText="Penal provision in case of noncompliance" />
                                            <asp:HyperLinkField DataTextField="PeriodicityofCompliance" HeaderText="Periodicity of Compliance" />
                                            <asp:HyperLinkField DataTextField="ComplianceStartDate" HeaderText="Compliance Start Date" />
                                            <asp:HyperLinkField DataTextField="ComplianceendDate" HeaderText="Compliance end Date" />
                                            <asp:HyperLinkField DataTextField="EmailSMSothtriggerdate" HeaderText="Email/ SMS/ Both trigger date" />
                                            <asp:HyperLinkField DataTextField="Approval" HeaderText="Approval" />
                                            <asp:HyperLinkField DataTextField="CurrentComplianceStatus" HeaderText="Current Compliance Status" />
                                            
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
                                        <tr id="trtsipass" runat="server" visible="false">
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
                                        <tr id="trdateofapproval" runat="server" visible="false">
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
                                        <tr id="trnoofdays" runat="server" visible="false">
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

