<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPublicViewDashBoardEmployee.aspx.cs" Inherits="UI_TSiPASS_frmPublicViewDashBoardEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";

             var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }

        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>

    <style>
        .algnCenter {
            text-align: right;
        }
    </style>
    <%--datepicker added on 17/01/2019--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter {
            text-align: center;
        }
    </style>

    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <%--<h2 class="panel-title" style="font-weight: bold;">R5.1: Department wise performance Tracker</h2>--%>
                            <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                            <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <%--<img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" />--%></a>
                            <%--<a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a> </h2>--%>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx" Text="<< Back">
                        </asp:HyperLink>
                    </td>

                    <td align="right">
                        <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" Visible="false" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>

                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="grdDetails_RowDataBound" Width="100%"
                            ShowFooter="True">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#fafafb" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />

                            <Columns>

                                <%--00--%>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <%--01--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year"
                                    DataTextField="FinYear">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--02--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Micro"
                                    DataTextField="Micro">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--03--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Small"
                                    DataTextField="Small">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--04--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Medium"
                                    DataTextField="Medium">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--05--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Large"
                                    DataTextField="Large">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--06--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Mega"
                                    DataTextField="Mega">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--07--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No Of Sectors"
                                    DataTextField="ManufacturingTotal">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--08--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total Investments (Rs Crores)"
                                    DataTextField="Total Investments">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--09--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total Employment"
                                    DataTextField="Total Empolyment">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                                <%--10--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Investment Per Unit (Rs Crores)"
                                    DataTextField="Investment Per Unit">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                
                                <%--11--%>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Employement Per Unit"
                                    DataTextField="Employement Per Unit">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                
                            </Columns>


                        </asp:GridView>
                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>

