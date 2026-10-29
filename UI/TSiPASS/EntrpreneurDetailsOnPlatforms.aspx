<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="EntrpreneurDetailsOnPlatforms.aspx.cs" Inherits="UI_TSiPASS_EntrpreneurDetailsOnPlatforms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <div allign="left">
        <div class="row" align="left">
            <div>
                 <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
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
                                Width="500px">Entrepreneur Details</asp:Label>
                        </h3>
                    </div>
                    <div>

                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%" >
                            <tr>
                                <td colspan="8" style="width: 883px; padding-left:15px">
                                    <asp:Label ID="lblForGrid" Visible="false" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style=" padding-left:15px">
                                   
                                        <asp:GridView ID="grdMeeshoDetails" runat="server" AutoGenerateColumns="false"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                           CssClass="HeaderFloat"  OnRowDataBound="grdMeeshoDetails_RowDataBound" GridLines="Both">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688"  CssClass="GridviewScrollC1HeaderWrap" />
                                            <%--<RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                             <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" Visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Name of the Platform" DataField="Meesho" />
                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" ItemStyle-Width="100px"  />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />
                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" ItemStyle-Width="500px" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />

                                                <%--Meesho--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrMEC_MeeshorefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrMEC_Meeshorefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrMEC_Meeshorefbycampdate" Visible="true" />
                                                <asp:BoundField HeaderText="Meesho Regestration ID" DataField="GrMEC_MeeshoId" Visible="true" />
                                                <asp:BoundField HeaderText="Meesho Regestration Date" DataField="GrMEC_MeeshoRegDt" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Transactions on Meesho" DataField="GrMEC_MeeshoTranscount" Visible="true" />
                                                <asp:BoundField HeaderText="Value Transactions on Meesho (in Lakhs)" DataField="GrMEC_MeeshoTransvalue" Visible="true" />

                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style=" padding-left:15px">
                                    <div >
                                        <asp:GridView ID="grdJustdialDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                           <%-- <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                            <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" Visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Name of the Platform" DataField="JustDial" />

                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" ItemStyle-Width="200px" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />

                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" ItemStyle-Width="200px" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />

                                                <%--JustDial--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrMEC_JustDialrefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrMEC_JustDialrefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrMEC_JustDialrefbycampdate" Visible="true" />
                                                <asp:BoundField HeaderText="JustDial Regestration ID" DataField="GrMEC_JustDialId" Visible="true" />
                                                <asp:BoundField HeaderText="JustDial Regestration Date" DataField="GrMEC_JustDialRegDt" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Transactions on JustDial" DataField="GrMEC_JustDialTranscount" Visible="true" />
                                                <asp:BoundField HeaderText="Value Transactions on JustDial (in Lakhs)" DataField="GrMEC_JustDialTransvalue" Visible="true" />

                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style=" padding-left:15px">
                                    <div >
                                        <asp:GridView ID="grdTSGlobalDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                             AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <%--<RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                            <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" Visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Name of the Platform" DataField="TSGlobal" />
                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" ItemStyle-Width="200px" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />

                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" ItemStyle-Width="200px" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />

                                                <%--TSGLOBAL--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrMEC_TSGlobalrefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrMEC_TSGlobalrefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrMEC_TSGlobalrefbycampdate" Visible="true" />
                                                <asp:BoundField HeaderText="TS-Global Linker Regestration ID" DataField="GrMEC_TSGlobalId" Visible="true" />
                                                <asp:BoundField HeaderText="TS-Global Linker Regestration Date" DataField="GrMEC_TSGlobalRegDt" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Transactions on TS-Global Linker" DataField="GrMEC_TSGlobalTranscount" Visible="true" />
                                                <asp:BoundField HeaderText="Value Transactions on TS-Global Linker (in Lakhs)" DataField="GrMEC_TSGlobalTransvalue" Visible="true" />


                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style=" padding-left:15px">
                                    <div >
                                        <asp:GridView ID="grdwallmartDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                             AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <%--<RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                            <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" Visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Name of the Platform" DataField="Wallmart" />
                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" ItemStyle-Width="200px" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />

                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" ItemStyle-Width="200px" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />

                                                <%--wallmart--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrMEC_WallmartrefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrMEC_Wallmartrefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrMEC_Wallmartrefbycampdate" Visible="true" />
                                                <asp:BoundField HeaderText="WallMart Vriddi Regestration ID" DataField="GrMEC_WallmartId" Visible="true" />
                                                <asp:BoundField HeaderText="WallMart Vriddi Regestration Date" DataField="GrMEC_WallmartRegDt" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Transactions on WallMart Vriddi" DataField="GrMEC_WallmartTranscount" Visible="true" />
                                                <asp:BoundField HeaderText="Value Transactions on WallMart Vriddi (in Lakhs)" DataField="GrMEC_WallmartTransvalue" Visible="true" />


                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </td>
                            </tr>

                            <tr>
                                <td style=" padding-left:15px">
                                    <div >
                                        <asp:GridView ID="grdInvoiceMartDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <%--<RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                            <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Name of the Platform" DataField="InvoiceMart" />
                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />
                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />
                                                <%--InvoiceMArt--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrFOLP_InvoiceMartrefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrFOLP_InvoiceMartrefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrFOLP_InvoiceMartrefbycampdate" Visible="true" />
                                                <asp:BoundField HeaderText="Invoice Mart Regestration ID" DataField="GrFOLP_InvoiceMartID" Visible="true" />
                                                <asp:BoundField HeaderText="Invoice Mart Regestration Date" DataField="GrFOLP_InvoiceMartRegDt" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Orders Received" DataField="GrFOLP_InvoiceMartOrdrsRcvdCount" Visible="true" />
                                                <asp:BoundField HeaderText="Value of Orders Received  (in Lakhs)" DataField="GrFOLP_InvoiceMartOrdrsRcvdCost" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Bills Uploaded" DataField="GrFOLP_InvoiceMartBlsUploadedCount" Visible="true" />
                                                <asp:BoundField HeaderText="Value of Bills Uploaded  (in Lakhs)" DataField="GrFOLP_InvoiceMartBlsUploadedCost" Visible="true" />
                                                <asp:BoundField HeaderText="No.of Bills Sold" DataField="GrFOLP_InvoiceMartBlsSoldCount" Visible="true" />
                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td style=" padding-left:15px">
                                    <div >
                                        <asp:GridView ID="grdNSEandSIDBI" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <%--<RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                            <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Name of the Platform" DataField="NSE" />
                                                  <asp:BoundField HeaderText="Name of the Platform" DataField="SIDBI" />
                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />
                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />
                                                <%--NSE 13--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrFOLP_NSErefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrFOLP_NSErefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrFOLP_NSErefbycampdate" Visible="true" />
                                                <asp:BoundField HeaderText="Listed onto NSE" DataField="GrFOLP_NSEListedAbout" Visible="true" />
                                                <asp:BoundField HeaderText="Filed with NSE " DataField="GrFOLP_NSEFiled" Visible="true" />
                                                <asp:BoundField HeaderText="Audit" DataField="GrFOLP_NSEAudit" Visible="true" />
                                                 <%--SIDBI 19--%>
                                                <asp:BoundField HeaderText="OnBoarded With Officer Reference" DataField="GrFOLP_SIDBIrefbyOffcr" Visible="true" />
                                                <asp:BoundField HeaderText="OnBoarded after attending the Camp" DataField="GrFOLP_SIDBIrefbycamp" Visible="true" />
                                                <asp:BoundField HeaderText="Attended Camp Date" DataField="GrFOLP_SIDBIrefbycampdate" Visible="true" />

                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td style=" padding-left:15px">
                                    <div >
                                        <asp:GridView ID="grdinterested" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <%--<RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />--%>
                                            <RowStyle Height="40px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" visible="false" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />                                              
                                                <asp:BoundField HeaderText="Name of the Unit" DataField="Name" />
                                                <asp:BoundField HeaderText="Address of the Unit" DataField="Address" Visible="true" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contact" Visible="true" />
                                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" Visible="true" />
                                                <asp:BoundField HeaderText="Investment" DataField="Investment" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employment" Visible="true" />
                                                <asp:BoundField HeaderText="Line Of Activity" DataField="LineOfActivity" Visible="false" />
                                                <asp:BoundField HeaderText="Sector" DataField="EnterpriseSector" Visible="true" />
                                               
                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="ExistingTableID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcampid" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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

