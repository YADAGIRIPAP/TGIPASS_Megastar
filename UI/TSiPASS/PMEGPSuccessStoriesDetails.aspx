<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="PMEGPSuccessStoriesDetails.aspx.cs" Inherits="UI_TSiPASS_PMEGPSuccessStoriesDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/ReportOnPMEGPSuccessStories.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">PMEGP Success Stories Details</asp:Label>
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
                                    <div >
                                        <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true"
                                            HeaderStyle-CssClass="FixedHeader" OnRowCreated="grdsupport_RowCreated" OnRowDataBound="grdsupport_RowDataBound">
                                            <HeaderStyle ForeColor="#FFFFFF"  Height="50px" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
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
                                                <asp:HyperLinkField HeaderText="Print" DataTextField="" Text="Print" />
                                                <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                                <asp:BoundField HeaderText="Applicant Name" DataField="ApplicantName" />
                                                <asp:BoundField HeaderText="Father / Spouse Name" DataField="FatherorSpouseName" />
                                                <asp:BoundField HeaderText="Caste" DataField="caste" />
                                                <asp:BoundField HeaderText="Age" DataField="Age" />
                                                <asp:BoundField HeaderText="Education Qualification" DataField="Educationalqualifiaction" />
                                                <asp:BoundField HeaderText="House No." DataField="HNO" />
                                                <asp:BoundField HeaderText="Street" DataField="Street" />
                                                <asp:BoundField HeaderText="Village / Ward" DataField="VillageWard" />
                                                <asp:BoundField HeaderText="Mandal / Municipality" DataField="Mandalmunicipality" />
                                                <asp:BoundField HeaderText="Aadhar No." DataField="Aadharnumber" />
                                                <asp:BoundField HeaderText="PAN No." DataField="Pannumber" />
                                                <asp:BoundField HeaderText="Udyam Reg No." DataField="Udayamregisternumber" />
                                                <asp:BoundField HeaderText="Ration Card No." DataField="Rationcradnumber" />
                                                <asp:BoundField HeaderText="Contact No." DataField="Contactnumber" />
                                                <asp:BoundField HeaderText="E-mail ID" DataField="Emailid" />
                                                <asp:BoundField ItemStyle-Width="500px" HeaderText="EDP Certificate obtained from" DataField="EDPcertifiacte" />
                                                <asp:BoundField HeaderText="Other Trainings attended (Y/N)" DataField="Anyotherprograms" />
                                                <asp:TemplateField HeaderText="Family Details">
                                                    <ItemTemplate>
                                                        
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grdfamily" runat="server" AutoGenerateColumns="true">
                                                                        <%--<Columns>
                                                                            <asp:BoundField HeaderText="Relation" DataField="Person" />
                                                                            <asp:BoundField HeaderText="Name" DataField="Name" />
                                                                            <asp:BoundField HeaderText="Age" DataField="Person_Age" />
                                                                            <asp:BoundField HeaderText="Profession" DataField="Profession" />

                                                                        </Columns>--%>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Unit Name" DataField="Unitname" />
                                                <asp:BoundField HeaderText="Line of Activity" DataField="Lineofactivity" />
                                                <asp:BoundField HeaderText="Product Name" DataField="productname" />
                                                <asp:BoundField HeaderText="Employment" DataField="Employement" />
                                                <asp:BoundField HeaderText="Investment (Amount in Rs)" DataField="Investment" />
                                                <asp:BoundField HeaderText="Beneficiary Contribution (Amount in Rs.)" DataField="Benificarycontribution" />
                                                <asp:BoundField HeaderText="Bank Loan (Amount in Rs.)" DataField="Bankloan" />
                                                <asp:BoundField HeaderText="Quantity of Production (Annual)(Number)" DataField="production" />
                                                <asp:BoundField HeaderText="Quantity of Production (Annual)(Units)" DataField="unitsofproduction" />
                                                <asp:BoundField HeaderText="Turn over Sales (Amount in Rs.)" DataField="Annualsales" />
                                                <asp:BoundField HeaderText="Profit (Annual) (Amount in Rs.)" DataField="Annualprofit" />
                                                <asp:BoundField HeaderText="whether Repayment of loan is completed " DataField="Loanrepaymentcompleted" />
                                                <asp:BoundField HeaderText="Physical Verification Date" DataField="Physicalvericationdate" />
                                                <asp:BoundField HeaderText="Subsidy Claim (Amount in Rs.)" DataField="Subsidyclaim" />
                                                <asp:BoundField HeaderText="MM Adjustment (Amount in Rs.)" DataField="Mmadjustments" />
                                                <asp:BoundField HeaderText="Assets (Before)" DataField="B_Assetvalue" />
                                                <asp:BoundField HeaderText="Assets (After)" DataField="A_Assetvalue" />
                                                <asp:BoundField HeaderText="House (Before)" DataField="B_House" />
                                                <asp:BoundField HeaderText="House (After)" DataField="A_House" />
                                                <asp:BoundField HeaderText="Land (Before)" DataField="B_Land" />
                                                <asp:BoundField HeaderText="Land (After)" DataField="A_Land" />
                                                <asp:BoundField HeaderText="Vehicles (Before)" DataField="B_Vehicles" />
                                                <asp:BoundField HeaderText="Vehicles (After)" DataField="A_Vehicles" />
                                                <asp:BoundField HeaderText="Health (Before)" DataField="B_Health" />
                                                <asp:BoundField HeaderText="Health (After)" DataField="A_Health" />
                                                <asp:BoundField HeaderText="Education (Before)" DataField="B_Childreneducation" />
                                                <asp:BoundField HeaderText="Education (After)" DataField="A_Childreneducation" />
                                                <asp:BoundField HeaderText="Re-investment (Before)" DataField="B_Reinvestments" />
                                                <asp:BoundField HeaderText="Re-investment (After)" DataField="A_Reinvestments" />
                                                <%--<asp:BoundField HeaderText="PmegpID" DataField="PmegpID" Visible="false" />--%>
                                                <asp:TemplateField HeaderText="PMEGP Id" Visible="false">
                                                    <ItemTemplate>
                                                    <asp:Label id="lblpmegpid" runat="server" Text='<%#Eval("PmegpID") %>'  ></asp:Label>
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

