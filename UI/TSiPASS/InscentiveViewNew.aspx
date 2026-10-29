<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="InscentiveViewNew.aspx.cs" Inherits="UI_TSiPASS_InscentiveViewNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .padding
        {
            margin: 10px 10px 10px 10px;
            padding-left: 10px;
        }
    </style>
    <script type="text/javascript" language="javascript">
       var win = new Object();
       function Popup(intVal) {

           win = window.open("../../UI/TSiPASS/IncetivesNewFormDeptView.aspx?EntrpId=" + intVal, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

       }
</script>
    
    <table style="padding-left: 25px; width: 100%;">
        <tr><td><br /><br /><br /></td></tr>
        <tr>
            <th style="text-align:center;">
                Incentive Details
            </th>
        </tr>
        <tr><td><br /></td></tr>
        <tr>
            <td>
                <asp:GridView ID="gvDetails" runat="server" CellPadding="4" AutoGenerateColumns="false"
                    CssClass="GRD" ForeColor="#333333" Height="62px" Width="100%" OnRowDataBound="gvDetails_RowDataBound">
                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#B9D684" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="EM / Udyog Adhar No" />
                        <asp:BoundField DataField="ApplciantName" HeaderText="Applicant Name" />
                        <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                        <asp:BoundField DataField="UnitEmail" HeaderText="Email Id" />
                        <asp:BoundField DataField="UnitMObileNo" HeaderText="Mobile No." />
                        <asp:TemplateField HeaderText="Incentives">
                            <ItemTemplate>                                
                                <asp:LinkButton ID="lbtIncentive" runat="server" Text="View" />
                                <asp:Label ID="lblEntrpId" runat="server" Visible="false" Text='<%# Eval("IncentveID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <%--<table style="padding-left: 25px; width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gvIncetiveTypes" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Incentives">
                            <ItemTemplate>
                                <asp:Label ID="lblIncentiveName" runat="server" Text='<%# Eval("IncentiveName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View Attachments">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtVwatt" runat="server" Text="View" OnClick="lbtVwatt_Click"></asp:LinkButton>
                                <asp:Label ID="lblEntrpId" runat="server" Visible="false" Text='<%# Eval("EnterperIncentiveID") %>' 
                                    ToolTip='<%# Eval("MstIncentiveId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table style="padding-left: 25px; width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gvAttachments" runat="server" AutoGenerateColumns="False">
                    <Columns>                        
                        <asp:TemplateField HeaderText="Attachments">
                            <ItemTemplate>
                                <asp:Label id="lbl" runat="server" Text='<%# Eval("AttachmentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlVw" runat="server" Text='<%# Eval("FileNm") %>' NavigateUrl='<%# Eval("FilePath") %>'
                                    Target="_blank" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>--%>
</asp:Content>

