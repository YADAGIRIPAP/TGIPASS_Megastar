<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/OtherServiceMaster.master" AutoEventWireup="true" CodeFile="ApplicationTrakerDetailedOtherService.aspx.cs" Inherits="UI_TSiPASS_ApplicationTrakerDetailedOtherService" %>

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

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <style>
        .Grid
        {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }
        
        .Grid td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
        }
        
        .Grid th
        {
            padding: 4px 2px;
            color: #fff;
            background: #363670 url(Images/grid-header.png) repeat-x top;
            border-left: solid 1px #525252;
            font-size: 0.9em;
        }
        
        .Grid .alt
        {
            background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
        }
        
        .Grid .pgr
        {
            background: #363670 url(Images/grid-pgr.png) repeat-x top;
        }
        
        .Grid .pgr table
        {
            margin: 3px 0;
        }
        
        .Grid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        
        .Grid .pgr a
        {
            color: Gray;
            text-decoration: none;
        }
        
        .Grid .pgr a:hover
        {
            color: #000;
            text-decoration: none;
        }
    </style>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            APPLICATION WISE DETAILED TRACKER</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px;">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%" __designer:mapid="363">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">1. UID 
                                                        Number</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <a target="_blank" id="labUidNumber" runat="server">
                                                    <asp:Label ID="lblUID" runat="server" CssClass="LBLBLACK" Font-Bold="true" Width="165px"></asp:Label></a>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr6" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label361" runat="server" CssClass="LBLBLACK" Width="224px" Font-Bold="True">6. Date of Industry Application</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labDOA" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr3" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label355" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">3. Line of Activity</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labLineofActivity" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr4" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">4. Sector</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblSector" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr5" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">3. District / Division	</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblDistrict" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="height:10px">
                                            <td>

                                            </td>
                                        </tr>
                                        <tr id="trpayment" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; font-weight:bold;" align="left" colspan="4" valign="bottom">
                                               <asp:HyperLink ID="hprcoipaynetdtls" Text='Click Here For View Industry Payment Details' Target="_blank" runat="server" />
                                            </td>
                                           
                                           
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px;">
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; height: 102px; vertical-align: top;">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%; vertical-align: top;">
                                         <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label353" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">2. Name of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labNameandAddress" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>

                                       
                                        <tr id="tr7" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="365" align="left">
                                                <asp:Label ID="Label359" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">7. Category of Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="367">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="368" align="left">
                                                <asp:Label ID="labCategoryofIndustry" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" __designer:mapid="36b">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr  id="tr8" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="233px" Font-Bold="True">8. Pollution Category of Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblpolution" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr  id="tr9" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label357" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True">9. Total Investment</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labTotalInvestment" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr  id="tr10" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label362" runat="server" CssClass="LBLBLACK" Width="233px" Font-Bold="True">10. Employment</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="lblEmploymenttot" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr  id="tr11" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="Label362123" runat="server" CssClass="LBLBLACK" Width="233px" Font-Bold="True">5. Address of the Industry</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:Label ID="labNameandAddress0" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium" align="center"
                                                colspan="4">
                                                <asp:HyperLink ID="HyperLinkSubsidy" Text='Click Here For Attachments' Target="_blank"
                                                    runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; height: 280px;" colspan="3">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdDetails_RowDataBound"
                                        OnPageIndexChanging="grdDetails_PageIndexChanging" OnRowCreated="grdDetails_RowCreated"
                                        EnableModelValidation="True" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                                        <HeaderStyle Height="40px" BackColor="#363670" ForeColor="White" />
                                        <FooterStyle Height="40px" />
                                        <AlternatingRowStyle />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of Approval">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hplkapprovalsname" Text='<%#Eval("Name of the approval")%>' NavigateUrl='<%#Eval("Approvalnfo")%>'
                                                        Target="_blank" runat="server" />
                                                    <asp:Label ID="lblapprovalname" Text='<%#Eval("Name of the approval")%>' runat="server"
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Name of the approval" HeaderText="Name of Approval" />--%>
                                            <asp:BoundField DataField="Approval Application Date" HeaderText="Approval Applied Date" />
                                            
                                            <asp:TemplateField HeaderText="Appealed Status(Y/N)">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hplCheckAppeal" Text="Revoke Status" NavigateUrl='<%#Eval("appealSubmitted")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Payment Date" HeaderText="Date of Payment" />--%>
                                            <asp:TemplateField HeaderText="Date of Payment">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperPayment" Text='<%#Eval("Payment Date")%>' NavigateUrl='<%#Eval("Paymentlink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Query">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperQuery" Text='<%#Eval("Query Date")%>' NavigateUrl='<%#Eval("Querypagelink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Query Response">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperQuery1" Text='<%#Eval("Query Response Date")%>' NavigateUrl='<%#Eval("Querypagelink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pre-Scrutiny Completion Date">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hplpscstataus" Text='<%#Eval("PSC Completion_Rejection Date")%>'
                                                        NavigateUrl='<%#Eval("PSCDOC")%>' Target="_blank" runat="server" />
                                                    <asp:Label ID="lblpscstataus" Text='<%#Eval("PSC Completion_Rejection Date")%>' runat="server"
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="PSC Completion_Rejection Date" HeaderText="Pre-Scrutiny Completion Date" />--%>
                                            <asp:BoundField DataField="No of days taken for PSC excluding holidays" HeaderText="Number of days taken" />
                                            <asp:TemplateField HeaderText="Date of Additional Payment">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyperaddPayment" Text='<%#Eval("AdditionalPayment")%>' NavigateUrl='<%#Eval("AddPaymentlink")%>'
                                                        Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <%--  <asp:BoundField DataField="AdditionalPayment" HeaderText="Date of Additional Payment" />
                                                <asp:BoundField DataField="Payment Type" HeaderText="Payment Type" />
                                            <asp:BoundField DataField="Amount Paid" HeaderText="Amount Paid (Rs)" />--%>
                                            <asp:BoundField DataField="Date of Approval received to Approval Stage Max of payment or PSC date"
                                                HeaderText="Date Received to Approval Stage" />
                                            <asp:BoundField DataField="Actual Date of Approval Rejection" HeaderText="Date of Completion" />
                                            <asp:BoundField DataField="SLA_Approval No of days" HeaderText="SLA" />
                                            <asp:BoundField DataField="No of days taken for Approval excluding holidays" HeaderText="Number of days taken" />
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                        NavigateUrl='<%#Eval("ApprovalDoc")%>' Target="_blank" runat="server" />
                                                    <asp:Label ID="lblverified" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                        runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                            <tr id="trcoicertificate" runat="server" visible="false">
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top"
                                    colspan="3">
                                    <asp:HyperLink ID="HyperLinkcoi" runat="server" Font-Bold="true" ForeColor="#FF6600">TS-iPASS consolidated certificate</asp:HyperLink>
                                    <%-- <asp:Button ID="Button1" runat="server" CssClass="btn-primary" Height="32px"
                                                        TabIndex="10" Text="TS-iPASS consolidated certificate" Width="185px" OnClientClick="document.forms[0].target = '_blank';" OnClick="BtnSave2_Click" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

