<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="WeakerSectionPlotDetails.aspx.cs" Inherits="UI_TSiPASS_WeakerSectionPlotDetails" %>

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
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; align-content:center"><asp:Label ID="lblHeading" runat="server" Visible="false">WeakerSectionPlotDetails Details</asp:Label>
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
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/SupporttoWeakerSectionEntrepreneurs.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Plot Details</asp:Label>
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
                                    <div>
                                        <%--style="overflow-x: auto; width: 1000px; max-height: 300px"--%>
                                        <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable" GridLines="Both"
                                            HeaderStyle-CssClass="FixedHeader" OnRowCreated="grdsupport_RowCreated" OnRowDataBound="grdsupport_RowDataBound">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" BorderWidth="1px" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>                                             

                                                <asp:BoundField HeaderText="District" DataField="DistrictName" ItemStyle-HorizontalAlign="left" />
                                                <asp:BoundField HeaderText="IEName" DataField="IEName" />
                                                <asp:BoundField HeaderText="TSIIC Status" DataField="TSIICSTATUS" Visible="true" />
                                                <asp:BoundField HeaderText="Officer Name" DataField="OFFICERNAME" Visible="true" />
                                                <asp:BoundField HeaderText="Officer Designation" DataField="OFFICERDESIGNATION" Visible="true" />

                                                <asp:BoundField HeaderText="Available" DataField="TotalPlotsAvailable" Visible="true"  ItemStyle-HorizontalAlign="center" />
                                                <asp:BoundField HeaderText="Alloted" DataField="TotalPlotsAlloted" Visible="true" />
                                                <asp:BoundField HeaderText="Vacant" DataField="TotalPlotsVacant" Visible="true" />
                                                <asp:BoundField HeaderText="Not mandated" DataField="PlotsNotMandatory" Visible="true" />
                                                <asp:BoundField HeaderText="for Reallocation" DataField="PlotsReallocated_Weaker" Visible="true" />

                                                <asp:BoundField HeaderText="SC" DataField="PlotsMandated_SC" Visible="true" />
                                                <asp:BoundField HeaderText="ST" DataField="PlotsMandated_ST" Visible="true" />
                                                <asp:BoundField HeaderText="BC" DataField="PlotsMandated_BC" Visible="true" />
                                                <asp:BoundField HeaderText="Minority" DataField="PlotsMandated_MINORITY" Visible="true" />
                                                <asp:BoundField HeaderText="Women" DataField="PlotsMandated_WOMEN" />
                                                <asp:BoundField HeaderText="General" DataField="PlotsMandated_GENERAL" />


                                                <asp:BoundField HeaderText="SC" DataField="PlotsAlloted_SC" />
                                                <asp:BoundField HeaderText="ST" DataField="PlotsAlloted_ST" Visible="true" />
                                                <asp:BoundField HeaderText="BC" DataField="PlotsAlloted_BC" />
                                                <asp:BoundField HeaderText="Minority" DataField="PlotsAlloted_MINORITY" />
                                                <asp:BoundField HeaderText="Women" DataField="PlotsAlloted_WOMEN" />
                                                <asp:BoundField HeaderText="General" DataField="PlotsAlloted_GENERAL" />

                                                <asp:BoundField HeaderText="SC" DataField="PlotsVacant_SC" Visible="true" />
                                                <asp:BoundField HeaderText="ST" DataField="PlotsVacant_ST" Visible="true" />
                                                <asp:BoundField HeaderText="BC" DataField="PlotsVacant_BC" Visible="true" />
                                                <asp:BoundField HeaderText="Minority" DataField="PlotsVacant_MINORITY" Visible="true" />
                                                <asp:BoundField HeaderText="Women" DataField="PlotsVacant_WOMEN" Visible="true" />
                                                <asp:BoundField HeaderText="General" DataField="PlotsVacant_GENERAL" Visible="true" />

                                                <asp:BoundField HeaderText="SC" DataField="PlotsAllotable_SC" Visible="true" />
                                                <asp:BoundField HeaderText="ST" DataField="PlotsAllotable_ST" Visible="true" />
                                                <asp:BoundField HeaderText="BC" DataField="PlotsAllotable_BC" Visible="true" />
                                                <asp:BoundField HeaderText="Minority" DataField="PlotsAllotable_MINORITY" Visible="true" />
                                                <asp:BoundField HeaderText="Women" DataField="PlotsAllotable_WOMEN" Visible="true" />
                                                <asp:BoundField HeaderText="General" DataField="PlotsAllotable_GENERAL" Visible="true" />

                                                <asp:BoundField HeaderText="Remarks" DataField="REMARKS" Visible="true" />

                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <%--<asp:TemplateField HeaderText="Guest Details">
                                                    <ItemTemplate>

                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grdGuests" runat="server" AutoGenerateColumns="true">
                                                                        <%--<Columns>
                                                                            <asp:BoundField HeaderText="Relation" DataField="Person" />
                                                                            <asp:BoundField HeaderText="Name" DataField="Name" />
                                                                            <asp:BoundField HeaderText="Age" DataField="Person_Age" />
                                                                            <asp:BoundField HeaderText="Profession" DataField="Profession" />

                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

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
                            <tr>
                                <td>
                                    <div >
                                        <%--style="overflow-x: auto; width: 1000px;"--%>
                                        <asp:GridView ID="grdallotable" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" GridLines="Both"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable"
                                            HeaderStyle-CssClass="FixedHeader">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle HorizontalAlign="Center" Height="40px" CssClass="GridviewScrollC1Item" />
                                            <AlternatingRowStyle Height="40px" BackColor="LightGray" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="IEName" DataField="IEName" />
                                                <asp:BoundField HeaderText="TSIIC Status" DataField="TSIICSTATUS" Visible="true" />
                                                <asp:BoundField HeaderText="Officer Name" DataField="OFFICERNAME" Visible="true" />
                                                <asp:BoundField HeaderText="Officer Designation" DataField="OFFICERDESIGNATION" Visible="true" />

                                                <asp:BoundField HeaderText="SC Allotable" DataField="PlotsAllotable_SC" Visible="true" />
                                                <asp:BoundField HeaderText="ST Allotable" DataField="PlotsAllotable_ST" Visible="true" />
                                                <asp:BoundField HeaderText="BC Allotable" DataField="PlotsAllotable_BC" Visible="true" />
                                                <asp:BoundField HeaderText="Minority Allotable" DataField="PlotsAllotable_MINORITY" Visible="true" />
                                                <asp:BoundField HeaderText="Women Allotable" DataField="PlotsAllotable_WOMEN" Visible="true" />
                                                <asp:BoundField HeaderText="General Allotable" DataField="PlotsAllotable_GENERAL" Visible="true" />

                                                <asp:BoundField HeaderText="Plot No." DataField="PlotNo" Visible="true" />
                                                <asp:BoundField HeaderText="Plot Area" DataField="Area" Visible="true" />
                                                <asp:BoundField HeaderText="Plot Cost" DataField="cost" Visible="true" />


                                                <asp:BoundField HeaderText="DistrictID" DataField="DistrictID" Visible="false" />
                                                <asp:TemplateField HeaderText="IEId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIEid" runat="server" Text='<%#Eval("IE_ID") %>'></asp:Label>
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

