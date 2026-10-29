<%@ Page Title=":: TSiPASS : Works wise Report " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmOtherServices.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="#">Other Services</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    Other Services</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%; text-align: center">
                                                        <%--<tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/HomeDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>Other Services</b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%" align="center" colspan="3" valign="top">
                                                                <div class="list-group" style="width: 100%">
                                                                    <a id="lst1" runat="server" target="_blank" class="list-group-item" 
                                                                        style="font-weight: bold" href='#'><span class="badge">
                                                                            <asp:Label ID="Label7" Text="Click Here" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-bullseye"></i>Engaging Contract Labour - Principal
                                                                        Employer</a> 
                                                                    <a id="lst2" runat="server" target="_blank" class="list-group-item"
                                                                            style="font-weight: bold" href='#'><span class="badge">
                                                                                <asp:Label ID="Label8" Text="Click Here" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-bullseye"></i>Engaging Contract Labour - Contractor
                                                                        </a><a id="lst3" runat="server" class="list-group-item" style="font-weight: bold"
                                                                            target="_blank"><i class="fa fa-fw fa-bullseye"></i>Shops and Establishment Registration<span
                                                                                class="badge">
                                                                                <asp:Label ID="Label10" Text="Click Here" runat="server"></asp:Label>
                                                                            </span></a>
                                                                            
                                                                            <a target="_blank" class="list-group-item" style="font-weight: bold" 
                                                                                href="https://labour.telangana.gov.in/IPASSAbstractReport.do">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label1" Text="Click Here" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-bullseye"></i>Registrations through TSiPASS - Abstract Report
                                                                        </a>
                                                                            
                                                                            <a id="lst4" class="list-group-item" style="font-weight: bold" href="../../NewRegistration.aspx"
                                                                                target="_blank"><span class="badge">
                                                                                    <asp:Label ID="Label11" Text="Click Here" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-bullseye"></i>VAT Registration</a>
                                                                                <a target="_blank" class="list-group-item" style="font-weight: bold" 
                                                                                href="https://labour.telangana.gov.in/TrackApplicationStatus.do?iPASS=T&iPASSUSER=<%= Session["uid"]%>">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label2" Text="Click Here" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-bullseye"></i>Track your status for Labour Department
                                                                        </a>
                                                                        
                                                                        <a target="_blank" class="list-group-item" style="font-weight: bold" 
                                                                                href="https://tsboilers.cgg.gov.in/ipassBoilerRenewal.do?IPASSUSER=<%= Session["uid"]%>">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label3" Text="Click Here" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-bullseye"></i>Track for Boiler Renewal Status
                                                                        </a>
                                                                        
                                                                        <a target="_blank" class="list-group-item" style="font-weight: bold" 
                                                                                href="http://tsfactories.cgg.gov.in/VerifyApplicationStatus.do?ipass=T">
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label4" Text="Click Here" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-bullseye"></i>Track for Factories Renewal Status
                                                                        </a>
                                                                        
                                                                        <%--<a target="_blank" class="list-group-item" style="font-weight: bold" 
                                                           href="https://tsboilers.cgg.gov.in/ipassBoilerRenewal.do?IPASSUSER=<%= Session["user_id"]%>>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label3" Text="Click Here" runat="server"></asp:Label>
                                                               </span><i class="fa fa-fw fa-bullseye"></i>Track for Boiler Renewal Status
                                                                        </a>--%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </div>
                        </div>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px">
                                <table cellpadding="2" style="width: 100%">
                                    <tr>
                                        <td style="width: 417px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px">
                            </td>
                        </tr>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
