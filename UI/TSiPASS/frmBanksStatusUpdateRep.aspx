
<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmBanksStatusUpdateRep.aspx.cs" Inherits="UI_TSIPASS_frmBanksStatusUpdateRep" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>
   
  

     <%--datepicker added on 17/01/2019--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
           
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index:9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>


    <table  id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 100%;font-family:'Trebuchet MS'">
                                
                                
                                
                                
                                <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                             Width="100%"  
                                            ShowFooter="True" >
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="District" HeaderText="District">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Incipient_Sick" HeaderText="Incipient Sick">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Incipient_Sick_GM" HeaderText="Incipient Sick<br/>GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Incipient_Sick_CC" HeaderText="Incipient Sick<br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Incipient_Sick_CC" HeaderText="Incipient Sick<br/>Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Sick" HeaderText="Sick">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Sick_GM" HeaderText="Sick GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Sick_CC" HeaderText="Sick<br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Sick_Bank" HeaderText="Sick Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                       <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Willful_Defaulters" HeaderText="Willful Defaulters">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Willful_Defaulters_GM" HeaderText="Willful Defaulters GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Willful_Defaulters_CC" HeaderText="Willful Defaulters<br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Willful_Defaulters_Bank" HeaderText="Willful Defaulters Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                   <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="TEV_Study_Done" HeaderText="TEV Study Done">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="TEV_Study_Done_GM" HeaderText="TEV Study Done GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="TEV_Study_Done_CC" HeaderText="TEV Study Done<br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="TEV_Study_Done_Bank" HeaderText="TEV Study Done Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                  <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Restructuring_under_taken" HeaderText="Restructuring under taken">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Restructuring_under_taken_GM" HeaderText="Restructuring under<br/>taken GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Restructuring_under_taken_CC" HeaderText="Restructuring under taken<br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Restructuring_under_taken_Bank" HeaderText="Restructuring under taken Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="SARFAESI" HeaderText="SARFAESI">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="SARFAESI_GM" HeaderText="SARFAESI GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="SARFAESI_CC" HeaderText="SARFAESI <br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="SARFAESI_Bank" HeaderText="SARFAESI Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                   <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Account_Closed" HeaderText="Account Closed">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Account_Closed_GM" HeaderText="Account Closed GM">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Account_Closed_CC" HeaderText="Account Closed<br/>Call Center">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Account_Closed_Bank" HeaderText="Account Closed Bank">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="GraphPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


