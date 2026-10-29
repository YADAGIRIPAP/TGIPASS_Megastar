<%@ Page Language="C#"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="frmPMEGPReport.aspx.cs" Inherits="UI_TSiPASS_frmPMEGPReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

    </script>
     <script language="javascript" type="text/javascript">
         $(function () {

             $('#MstLftMenu').remove();
             s
         });
     </script>
    <style type="text/css">
    /*.col-lg-10 {*/
        width: 1050px;
    }
        .auto-style1 {
            width: 76%;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            top: 0px;
            left: 0px;
            float: left;
            width: 1573px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <div align="left">
        <div class="row" align="left">
            <div class="auto-style2">
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
                 <div>
                      <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/InteractionsReportsDashBoard.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Visible="false"
                                Width="500px"></asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom:30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> Report on Analysis and Resolution on PMEGP Rejections</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            
                                            <td class="style3" align="right" style="width: 178px">
                                                <asp:Label ID="Label1" runat="server">District </asp:Label>
                                            </td>
                                            <td style="width: 11px">:</td>
                                            <td style="width:200px">
                                                <div>
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" style="width:150px" >
                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                        
                                       
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: left; height: 50px" colspan="10">&nbsp;&nbsp;
                                                <asp:Button ID="BtnGetData" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Get Report" ValidationGroup="group"
                                                    Width="120px" OnClick="BtnGetData_Click" />
                                                &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10" style="height:30px"></td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" class="auto-style1">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="PMEGP Reports" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdwomencells" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" OnRowDataBound="grdwomencells_RowDataBound" >
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
                                            <asp:BoundField HeaderText="District" DataField="DISTRICTNAME"  />                                            
                                            <asp:HyperLinkField HeaderText="Total No of applications" DataTextField="TOTALNOOFAPPLICATIONS" />
                                            <asp:HyperLinkField HeaderText="No of applications pending at GM" DataTextField="NOOFAPPLICATIONSPENDINGATGM" />
                                            <asp:HyperLinkField HeaderText="No of facilitators rejected by GM" DataTextField="NOOFAPPLICATIONSREJECTED" />
                                            <asp:HyperLinkField HeaderText="Applicant Requested to Return" DataTextField="ApplicantRequestedtoReturn" />
                                            <asp:HyperLinkField HeaderText="Beneficiary Not Responding/Not Reachable/Not Interested" DataTextField="BeneficiaryNotRespondingorNotReachableorNotInterested" />
                                            <asp:HyperLinkField HeaderText="CIBIL Score not Satisfactory/NPA/Defaulter" DataTextField="CIBILScorenotSatisfactoryorNPAorDefaulter" />
                                            <asp:HyperLinkField HeaderText="Details Mismatch/Miscellaneous" DataTextField="DetailsMismatchorMiscellaneous" />
                                            <asp:HyperLinkField HeaderText="Existing Unit" DataTextField="ExistingUnit" />
                                            <asp:HyperLinkField HeaderText="Inadequate knowledge in proposed industry" DataTextField="Inadequateknowledgeinproposedindustry" />
                                            <asp:HyperLinkField HeaderText="Not Viable/Not Feasible" DataTextField="NotViableorNotFeasible" />
                                            <asp:HyperLinkField HeaderText="Out of Service Area" DataTextField="OutofServiceArea" />
                                            <asp:HyperLinkField HeaderText="Required Documents not Submitted/Unable to complete Bank Formalities" DataTextField="RequiredDocumentsnotSubmittedorUnabletocompleteBankFormalities" />
                                            <asp:HyperLinkField HeaderText="Target Achieved for the Year" DataTextField="TargetAchievedfortheYear" />
                                            <asp:HyperLinkField HeaderText="Unable to provide collateral security" DataTextField="Unabletoprovidecollateralsecurity" />
                                            <asp:HyperLinkField HeaderText="Wrong Project Report" DataTextField="WrongProjectReport" />

                                            <asp:BoundField HeaderText="District ID" DataField="DISTRICTID" Visible="false" />
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
