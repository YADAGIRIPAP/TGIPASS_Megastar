<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="SupporttoNewbyInteractionDrillDown.aspx.cs" Inherits="UI_TSiPASS_SupporttoNewbyInteractionDrillDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
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
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server" Visible="false">SupporttoNewbyInteraction Details</asp:Label>
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
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/SupporttoNewbyInteraction.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                 <%-- <div>
                    <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnkbtn_Click">Back</asp:LinkButton>
                </div>--%>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="text-align: center;">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Entrepreneur Details</asp:Label>
                        </h3>
                    </div>
                    <br />
                   <%-- <div style="overflow-x: auto; width: 950px; max-height: 300px">--%>
                        <asp:GridView ID="grdnewintrcton" runat="server" AutoGenerateColumns="False" Width="90%" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                            Style="margin-left:15px; margin-right:5px;" AllowSorting="true" CssClass="floatingtable" HeaderStyle-CssClass="FixedHeader" OnRowDataBound="grdnewintrcton_RowDataBound">
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
                               
                                
                                <asp:TemplateField HeaderText="ApplicantName" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("ApplicantName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender"  Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("GENDER") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Age" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ContactNumber" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactNumber" runat="server" Text='<%# Bind("Contactnumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EmailId" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("Emailid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qualifucation" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblqualfcton" runat="server" Text='<%# Bind("EDUCATIONALQUALIFICATION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SOCIAL CATEGORY" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcaste" runat="server" Text='<%# Bind("SOCIALCATEGORY") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PHC" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblphc" runat="server" Text='<%# Bind("isPHC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Purpose of Visit" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblprpsevst" runat="server" Text='<%# Bind("PurposeofVisit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Any Sector Experience" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblsctorexprince" runat="server" Text='<%# Bind("AnySectorExperience") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SECTOR Name" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblsctorname" runat="server" Text='<%# Bind("SECTORName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Experience in Years"  Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsctorexprinceyrs" runat="server" Text='<%# Bind("ExperienceinYears") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PMEGP Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblpmegp" runat="server" Text='<%# Bind("ExplainedSchemePMEGP") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PMFME Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblpmfme" runat="server"  Text='<%# Bind("ExplainedSchemePMFME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="T-IDEA Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblTideaschm" runat="server"  Text='<%# Bind("ExplainedSchemeTIDEA") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="T-PRIDE Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbltprideschm" runat="server"  Text='<%# Bind("ExplainedSchemeTPRIDE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mudra Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblmudraSchm" runat="server" Text='<%# Bind("ExplainedSchemeMudra") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CGTMSE Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcgtmseSchm" runat="server"  Text='<%# Bind("ExplainedSchemeCGTMSE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dalitha Bandhu Scheme" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbldalthbanduSchm" runat="server"  Text='<%# Bind("ExplainedSchemeDalithaBandhu") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                       <asp:TemplateField HeaderText="No.of Persons visited  for Training" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lbltrining" runat="server"  Text='<%# Bind("ExplainedTrainings") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Land Type Interaction" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lbllndintrcton" runat="server"  Text='<%# Bind("ExplainedLand") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Other Issues" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblotherises" runat="server"  Text='<%# Bind("OthersIssues") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:HyperLinkField HeaderText="View" DataTextField="" Text="View" />
                    <asp:TemplateField HeaderText=" New Entrepreneur" Visible="false">
                         <ItemTemplate>
                          <asp:Label id="lblNewEntrpneurID" runat="server" Text='<%# Eval("PersonalInteractionID") %>' ></asp:Label>
                            </ItemTemplate>
                         </asp:TemplateField>
                                </Columns>
                        </asp:GridView>

                    </div>

                    <%-- <div  style="overflow-x: auto; width: 950px; max-height: 300px">
       <asp:GridView ID="grdschemes" runat="server" AutoGenerateColumns="False" Width="90%"  BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" 
           Style="margin-left:5%; margin-right:5%;overflow: scroll;" AllowSorting="true" CssClass="floatingtable"  HeaderStyle-CssClass="FixedHeader" >
            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
            <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item"  />
    <Columns>
        
                    <asp:TemplateField HeaderText="PMEGP Scheme">
                        <ItemTemplate>
                            <asp:Label ID="lblpmegp" runat="server" Text='<%# Bind("[Explained Scheme PMEGP]") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="PMFME Scheme ">
                        <ItemTemplate>
                            <asp:Label ID="lblpmfme" runat="server" Text='<%# Bind("[Explained Scheme PMFME]") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="T-IDEA Scheme">
                        <ItemTemplate>
                            <asp:Label ID="lblTideaschm" runat="server" Text='<%# Bind("[Explained Scheme T-IDEA]") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="T-PRIDE Scheme ">
                        <ItemTemplate>
                            <asp:Label ID="lbltprideschm" runat="server" Text='<%# Bind("[Explained Scheme T-PRIDE]") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mudra Scheme">
                        <ItemTemplate>
                            <asp:Label ID="lblmudraSchm" runat="server" Text='<%# Bind("[Explained Scheme Mudra]") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="CGTMSE Scheme">
                        <ItemTemplate>
                            <asp:Label ID="lblcgtmseSchm" runat="server" Text='<%# Bind("[Explained Scheme CGTMSE]") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dalitha Bandhu Scheme ">
                        <ItemTemplate>
                            <asp:Label ID="lbldalthbanduSchm" runat="server" Text='<%# Bind("[Explained Scheme Dalitha Bandhu]") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Tasks">
                        <ItemTemplate>
                            <asp:Label ID="lbltasks" runat="server" Text='<%# Bind("ExplainedTasks") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="DET">
                        <ItemTemplate>
                            <asp:Label ID="lbldet" runat="server" Text='<%# Bind("ExplainedDET") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="VacantPlots">
                        <ItemTemplate>
                            <asp:Label ID="lblVacantPlots" runat="server" Text='<%# Bind("ExplainedAbtVacantPlots") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
  </Columns>
   </asp:GridView>
   </div>--%>
                </div>
            </div>
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>

