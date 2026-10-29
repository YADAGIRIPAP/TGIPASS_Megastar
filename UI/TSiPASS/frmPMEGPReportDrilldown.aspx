<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"  CodeFile="frmPMEGPReportDrilldown.aspx.cs" Inherits="UI_TSiPASS_frmPMEGPReportDrilldown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <script language="javascript" type="text/javascript">
         $(function () {

             $('#MstLftMenu').remove();
             
         });
      </script>
    <div allign="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                 <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; align-content:center"><asp:Label ID="lblHeading" runat="server" Visible="false">frmPMEGPReport Details</asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick1"
                                runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h2>
                        </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Facilitator Details District Wise</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">

                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmPMEGPREPORT.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="overflow-x: auto; width: 1000px; max-height: 500px">
                                        <asp:GridView ID="grddistfacilitatordetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"  
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true"
                                            HeaderStyle-CssClass="FixedHeader" >
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Applicant ID" DataField="ApplicantID" />
                                                <asp:BoundField HeaderText="Applicant Name" DataField="ApplicantName" />
                                                <asp:BoundField HeaderText="Applicant Address" DataField="ApplicantAddress" />
                                                <asp:BoundField HeaderText="Unit Address" DataField="UnitAddress" />
                                                <asp:BoundField HeaderText="Financing Branch Address" DataField="FinancingBranchAddress" />
                                                <asp:BoundField HeaderText="Online Submission Date" DataField="OnlineSubmissionDate" />
                                                <asp:BoundField HeaderText="Forwarding Date to Bank" DataField="ForwardingDatetoBank" />
                                                <asp:BoundField HeaderText="UnderProcess Rejection by Agency Reason" DataField="UnderProcess_RejectionbyAgencyreason" Visible="false" />
                                                <asp:BoundField HeaderText="Bank Remarks" DataField="BankRemarks" />
                                              
                                                <asp:BoundField HeaderText="Reason for Rejection" DataField="REJECTIONREASON" />
                                                
                                               
                                                


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
        <asp:Label ID="lblForGrid" runat="server"></asp:Label>
    </div>

</asp:Content>



