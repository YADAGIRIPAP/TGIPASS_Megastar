<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="MSEFCDrilldown.aspx.cs" Inherits="UI_TSiPASS_MSEFCDrilldown" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                    <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                        <asp:Label ID="lblHeading" runat="server" CssClass="text-center" Visible="false">SupporttoExistingEntrepreneur Details</asp:Label>
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
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/ReportOnMSEFCawarenessCamps.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">MSEFC</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom: 30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> MESFC Awareness</asp:Label>
                                </td>
                            </tr>

                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdcamps" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle HorizontalAlign="Center" />  
                                        <AlternatingRowStyle  HorizontalAlign="Center" BackColor="LightGray" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                                <%--Districtid--%>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="District" DataField="DistrictName" ItemStyle-HorizontalAlign="center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" />                                            
                                             <asp:BoundField HeaderText="Camp Venue" DataField="Venue" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Location Cordinates" DataField="LocCordinates" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>                                           
                                            <asp:BoundField HeaderText="Venue Type" DataField="VenueType" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>  
                                             <asp:BoundField HeaderText="Other Venue" DataField="OtherVenue" Visible="false" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>   
                                            <asp:BoundField HeaderText="Camp Conducted Date" DataField="CampDate" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Camp Conducted Time" DataField="Camptime" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>                                       
                                             <asp:BoundField HeaderText="No.of Males Attended" DataField="MalesAttended" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>   
                                             <asp:BoundField HeaderText="No.of Females Attended" DataField="FemalesAttended" ItemStyle-Width="200px" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>   
                                            <asp:BoundField HeaderText="District ID" DataField="DistrictID" Visible="false" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdExisting" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <AlternatingRowStyle  HorizontalAlign="Center" BackColor="LightGray" />
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
                                            <asp:BoundField HeaderText="Interaction Date" DataField="onlyDateofInteraction" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Interaction Type" DataField="InteractionType" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Through WomenCell" DataField="ThroughWomenCell" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="TSIPASS Regestered" DataField="TSiPASSReg" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="UID No." DataField="UIDno" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Name" DataField="Name" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Address" DataField="Address" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Contact" DataField="Contact" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="E-mail" DataField="EmailId" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Socail Category" DataField="SocialCategory" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Gender" DataField="Gender" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Line of Activity" DataField="LineOfActivity" Visible="false" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Enterprise Sector" DataField="EnterpriseSector" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Case filed" DataField="GrFDptIssue_CaseunderMSME" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Case Details" DataField="GrFDptIssue_CaseMSMEdetails" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
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

