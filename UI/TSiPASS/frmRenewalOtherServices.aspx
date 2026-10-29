<%@ Page Title=":: TSiPASS : Works wise Report " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmRenewalOtherServices.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="#">Renewals Registration</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    Renewals Registration</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%; text-align: center">                                                        
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>Renewals Registration</b>
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
                                                                    <a id="lst1" runat="server" class="list-group-item" style="font-weight: bold" target="_blank"
                                                                        ><span class="badge">
                                                                        <asp:Label ID="Label7" Text="Click Here" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-bullseye"></i>Boilers</a>
                                                                    <a id="lst2" target="_blank" class="list-group-item" style="font-weight: bold" href="RenewalNew.aspx"><span class="badge">
                                                                        <asp:Label ID="Label8" Text="Click Here" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-bullseye"></i>Fire</a>
                                                                    
                                                                    <a id="lst3" runat="server" class="list-group-item" style="font-weight: bold" 
                                                                        target="_blank"><i class="fa fa-fw fa-bullseye">
                                                                    </i>Factories<span class="badge">
                                                                        <asp:Label ID="Label10" Text="Click Here" runat="server"></asp:Label>
                                                                    </span></a>
                                                                    
                                                                    <a id="lst4" runat="server" class="list-group-item" style="font-weight: bold" 
                                                                        target="_blank"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label11" Text="Click Here" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-bullseye"></i>Shops & Establishment Act</a>
                                                                                                                                        
                                                                    <a id="lst5" runat="server" class="list-group-item" style="font-weight: bold" 
                                                                         target="_blank"><span
                                                                        class="badge">
                                                                        <asp:Label ID="Label1" Text="Click Here" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-bullseye"></i>PCB(Auto Renewal)</a>
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
