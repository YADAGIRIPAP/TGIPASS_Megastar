<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ReportOnPlatforms.aspx.cs" Inherits="UI_TSiPASS_ReportOnPlatforms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
     </script>
    <div allign="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                 <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;"></h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server" Visible="false">Report on Support to SICK Entrepreneurs</asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h2>
                        </div>
                 <div>
                      <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/ReportOnFacilataionofMSME.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">E-Commerce Platforms OnBoarded Details</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">

                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="overflow-x: auto; width: 1000px; max-height: 300px">
                                        <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader" OnRowCreated="grdsupport_RowCreated" OnRowDataBound="grdsupport_RowDataBound">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />
                                            <Columns>
                                                <%-- 0--%>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <%-- <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" />--%>
                                                 <%-- 1--%><asp:BoundField HeaderText="District" DataField="District_Name" />
                                                 <%-- 2--%><asp:BoundField HeaderText="Ecommerce-OnBoarded" DataField="Ecommerce" />
                                                 <%-- 3--%><asp:HyperLinkField HeaderText="Meesho OnBoarded " DataTextField="Meesho" Visible="true" />
                                                <%-- 4--%> <asp:HyperLinkField HeaderText="JustDial OnBoarded " DataTextField="JustDial" Visible="true" />
                                                <%-- 5--%> <asp:HyperLinkField HeaderText="TSGLinker OnBoarded " DataTextField="TSGlobal" Visible="true" />
                                               <%-- 6--%>  <asp:HyperLinkField HeaderText="WalmartVriddi OnBoarded " DataTextField="Wallmart" Visible="true" />
                                                 
                                                <%-- 7--%><asp:BoundField HeaderText="Online Platforms-OnBoarded" DataField="Online" />
                                                 <%-- 8--%><asp:HyperLinkField HeaderText="InvoiceMart OnBoarded " DataTextField="Invoice" Visible="true" />
                                                <%-- 9--%> <asp:HyperLinkField HeaderText="NSE OnBoarded" DataTextField="NSE" Visible="true" />
                                                 <%-- 10--%><asp:HyperLinkField HeaderText="SIDBI OnBoarded" DataTextField="SIDBI" Visible="true" />

                                                <%-- 11--%> <asp:BoundField HeaderText="Ecommerce-Interseted" DataField="Ecommerceintrsted" />
                                                 <%-- 12--%><asp:HyperLinkField HeaderText="Meesho Interseted " DataTextField="Meeshointrsted" Visible="true" />
                                                 <%-- 13--%><asp:HyperLinkField HeaderText="JustDial Interseted " DataTextField="JustDialintrsted" Visible="true" />
                                                 <%-- 14--%><asp:HyperLinkField HeaderText="TSGLinker Interseted " DataTextField="TSGlobalintrsted" Visible="true" />
                                                 <%-- 15--%><asp:HyperLinkField HeaderText="WalmartVriddi Interseted " DataTextField="Wallmartintrsted" Visible="true" />
                                                 <%-- 16--%><asp:BoundField HeaderText="Online Platforms-Interseted" DataField="Onlineintrsted" />
                                                <%-- 17--%> <asp:HyperLinkField HeaderText="InvoiceMart Interseted " DataTextField="Invoiceintrsted" Visible="true" />
                                                 <%--18--%><asp:HyperLinkField HeaderText="NSE Interseted" DataTextField="NSEintrsted" Visible="true" />
                                                <%-- 19--%> <asp:HyperLinkField HeaderText="SIDBI Interseted" DataTextField="SIDBIintrsted" Visible="true" />

                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />

                                                <%-- <asp:TemplateField HeaderText="Camp Id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("GMCampID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>
        </div>

    </div>

</asp:Content>

