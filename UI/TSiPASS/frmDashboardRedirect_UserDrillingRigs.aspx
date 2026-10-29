<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDashboardRedirect_UserDrillingRigs.aspx.cs" Inherits="UI_TSiPASS_frmDashboardRedirect_UserDrillingRigs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .GRDHEADER {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">VIEW DETAILS</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">VIEW DETAILS</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                             <tr>
                                                <td align="right" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                   <asp:HyperLink ID="hyp_back" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1); return false;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="150px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="checkQuery"> 
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">

                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Application No">
                                                                <ItemTemplate>
                                                                    <%# Eval("UIDNo") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <%# Eval("Status") %>
                                                                    <asp:Label ID="lbl_grdrejectedremarks"  Visible="false" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Query Response">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_queryrespond" runat="server" Text="Respond"   Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Application Form">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_applicationform" runat="server" Text="View"   Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Payment Details">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_payment" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Attachments">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_attachment" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:BoundField DataField="Applicationtype" HeaderText="Application Type" />
                                                             <asp:BoundField DataField="Nameoftheapplicant" HeaderText="Applicant Name" />
                                                            <asp:BoundField DataField="AddressApplicant" HeaderText="Address of Applicant" />
                                                            <asp:BoundField DataField="ApplicantMobileno" HeaderText="Contact Mobile No"  />
                                                            <asp:BoundField DataField="ApplicantEmailID" HeaderText="Contact Email ID"  />
                                                            <asp:BoundField DataField="regvehicleno" HeaderText="Registration No. of the vehicle" />
                                                            <asp:BoundField DataField="RTODistrictName" HeaderText="In which District RTO registration "  />                                                             
                                                            <asp:BoundField DataField="Descofdrillrigs" HeaderText="Description of the drilling rig"  />
                                                            <asp:BoundField DataField="maxdiameterdepth" HeaderText="Capacity of Drilling Max Diameter Depth(In inchs)" />
                                                            <asp:BoundField DataField="Areaofoperation" HeaderText="Area of operation" />
                                                            <asp:BoundField DataField="FeeAmount" HeaderText="Application Fee" />
                                                            <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date"  />
                                                             <asp:BoundField DataField="Query_RaiseDate" HeaderText="Query Raise Date" />
                                                            <asp:BoundField DataField="QueryRespondDate" HeaderText="Query Responded  Date" />
                                                             <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" />
                                                            <asp:BoundField DataField="RejectedDate" HeaderText="Rejected Date" />
                                                                 <asp:TemplateField>
                                                                 <HeaderTemplate>
                                                                     Query Raise/Approval/Rejected Document
                                                                 </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_approvalrejectedattachment" runat="server" Text="View" Font-Bold="true" 
                                                                        Target="_blank" />
                                                                    <br /> <br /> <br />
                                                                     <asp:HyperLink ID="hyp_viewqueryresponse" runat="server" Text="view Query Response"  Visible="false"  Font-Bold="true" ForeColor="Blue"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                                </td>
                                            </tr>
                                           
                                            
                                        </table>
                                      
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                     
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

