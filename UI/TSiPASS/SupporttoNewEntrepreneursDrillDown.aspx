<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="SupporttoNewEntrepreneursDrillDown.aspx.cs" Inherits="UI_TSiPASS_SupporttoNewEntrepreneursDrillDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }

        .hiddenLabel {
            display: none;
        }
    </style>
     <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
     </script>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12" id="divPrint1" runat="server">
                  <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server" Visible="false">SupporttoNewEntrepreneurs Details</asp:Label>
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
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/SupporttoNewEntrepreneurs.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                 <%-- <div>
                    <asp:LinkButton ID="lnkbutton" runat="server" OnClick="lnkbutton_Click">Back</asp:LinkButton>
                </div>--%>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="text-align: center;">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px"> New Entrepreneurs Details</asp:Label>
                        </h3>
                    </div>
                    <br />
                    <div >
                        <%--style="overflow-x: auto; width: 950px; max-height: 300px"--%>
                        <asp:GridView ID="GrdnewEntpnrdtls" runat="server" Width="95%" AutoGenerateColumns="False" BorderColor="#003399" 
                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                            Style="margin-left:15px; margin-right:5px;" AllowSorting="true" CssClass="floatingtable" HeaderStyle-CssClass="FixedHeader" OnRowDataBound="GrdnewEntpnrdtls_RowDataBound">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item" />
                            <Columns>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Venue">
                                    <ItemTemplate>
                                        <asp:Label ID="VenueName" runat="server" Text='<%# Bind("Venue") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="VenueADDRESS" runat="server" Text='<%# Bind("LocCordinates") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Venue Type">
                                    <ItemTemplate>
                                        <asp:Label ID="VenueTYPE" runat="server" Text='<%# Bind("VenueType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Camp Date">
                                    <ItemTemplate>
                                        <asp:Label ID="Camp_Date" runat="server" Text='<%# Bind("CampDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Camp Time">
                                    <ItemTemplate>
                                        <asp:Label ID="Camp_Time" runat="server" Text='<%# Bind("Camptime") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Males Attended">
                                    <ItemTemplate>
                                        <asp:Label ID="Males_attended" runat="server" Text='<%# Bind("MalesAttended") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Females Attended">
                                    <ItemTemplate>
                                        <asp:Label ID="Females_attended" runat="server" Text='<%# Bind("FemalesAttended") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                  <asp:HyperLinkField HeaderText="View" DataTextField="" Text="View" />
                                 <asp:TemplateField HeaderText=" New Entrepreneur" Visible="false">
                         <ItemTemplate>
                          <asp:Label id="lblcampID" runat="server" Text='<%# Eval("GMCampID") %>' ></asp:Label>
                            </ItemTemplate>
                         </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                <%--    <div  style="overflow-x: auto; width: 950px; max-height: 600px">
       <asp:GridView ID="GrdnewEntpnrdtlsNew" runat="server" AutoGenerateColumns="False" Width="95%"  BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" 
           Style="margin-left:auto; overflow: scroll;" AllowSorting="true" CssClass="floatingtable"  HeaderStyle-CssClass="FixedHeader" >
            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
            <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item"  />
    <Columns>
     
                       <asp:TemplateField HeaderText="Venue of Interaction">
                        <ItemTemplate>
                          <asp:Label ID="VenueLabel" runat="server" Text='<%# Bind("Venue_of_Interaction") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ApplicantName">
                        <ItemTemplate>
                            <asp:Label ID="ApplicantNameLabel" runat="server" Text='<%# Bind("ApplicantName") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
         <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="GenderLabel" runat="server" Text='<%# Bind("GENDER") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                            <asp:Label ID="AgeLabel" runat="server" Text='<%# Bind("Age") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ContactNumber">
                        <ItemTemplate>
                            <asp:Label ID="ContactNumberLabel" runat="server" Text='<%# Bind("Contactnumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="EmailId">
                        <ItemTemplate>
                            <asp:Label ID="EmailIdLabel" runat="server" Text='<%# Bind("Emailid") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                      </div>--%>
                    <br />
                </div>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>

