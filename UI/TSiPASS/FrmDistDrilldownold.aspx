<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="FrmDistDrilldownold.aspx.cs" Inherits="LookupCA"
    Title=":: TSiPASS Online Management System ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {

            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: 101 + "%",
                height: 100 + "%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>

    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
    <table runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeader" runat="server"></asp:Label>&nbsp; <a id="A1" href="#" onserverclick="BtnPDF_Click"
                                    runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a></h3>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: right;">
                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click1" />
                                    <asp:Button ID="BtnPDF" runat="server" CssClass="btn btn-warning" Height="32px" OnClick="BtnPDF_Click"
                                        TabIndex="10" Text="PDF" Width="90px" />
                                </td>
                            </tr>--%>
                                <tr>
                                    <td align="right" style="padding: 5px; color: Red; font-weight: bold; margin: 5px;
                                        text-align: right;" valign="top">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td align="right" style="padding: 5px; color: Red; font-weight: bold; margin: 5px;
                                        text-align: right;" valign="top">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK">Last updated on</asp:Label>
                                    </td>
                                </tr>--%>
                                <tr id="divPrint" runat="server" style="width: 100%">
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="true" CellPadding="4"
                                            OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged">
                                            <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="District" HeaderText="District" >
                                               <ItemStyle Width="180px" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Number" HeaderText="No of Industries">
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Investment" HeaderText="Investment (Rs. in Cr)" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Employment" HeaderText="Total Employment" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
