<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="MajorIndustries_ReportDrilldown.aspx.cs" Inherits="UI_TSiPASS_MajorIndustries_ReportDrilldown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                 <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server" Visible="false">MajorIndustries_Report Details</asp:Label>
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
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/MajorIndustries_Report.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Major Industries</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom: 30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> Support to Major Industries by Interaction - Details</asp:Label>
                                </td>
                            </tr>

                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="" Visible="true" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                                <%--Districtid--%>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="District" DataField="DistrictName" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Left" />
                                          
                                            <asp:BoundField HeaderText="Unit Name" DataField="Name" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Address" DataField="Address" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Mobile No." DataField="Contact" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="e-Mail" DataField="EmailId" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                              <asp:BoundField HeaderText="Social Category"  DataField="SocialCategory" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Gender" DataField="Gender" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Investment" DataField="Investment" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Employment" DataField="Employment" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="District ID" DataField="DistrictID" Visible="false" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>
        </div>

    </div>
</asp:Content>

