<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMASTER.master"  CodeFile="frmSVCDEPTProcessedApplication_Commissioner.aspx.cs" Inherits="UI_TSiPASS_frmSVCDEPTProcessedApplication_Commissioner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>
    <script type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Commissioner's Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">

                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">

                                                    <table cellpadding="3" cellspacing="5" style="width: 50%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small"
                                                                    NavigateUrl="~/UI/TSiPASS/COIDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 100px" valign="top">
                                                                <div class="list-group">




                                                                    
                                                                    <a style="width: 400px" class="list-group-item" href="IncentiveApplicationsSVCList_COMMISSIONER.aspx?Stg=1"><span class="badge">
                                                                        <asp:Label ID="lblpending_commissioner" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Pending Applications</a>

                                                                    <a style="width: 400px"  class="list-group-item" href="IncentiveApplicationsSVCList_COMMISSIONER.aspx?Stg=2"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="lblreturnedby_comissioner" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Commissioner Returned Applications </a>
                                                                    <a style="width: 400px"  class="list-group-item" href="IncentiveApplicationsSVCList_COMMISSIONER.aspx?Stg=3"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="lblprocessed_commissioner" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Commissioner Approved Applications </a>

                                                                    

                                                                </div>
                                                            </td>
                                                            
                                                            
                                                        </tr>

                                                    </table>

                                                </div>
                                            </div>

                                        </td>
                                    </tr>
                                    
                                </table>
                                </td>
                                    </tr>
                                   
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>


            <br />
            <br />
            <br />


        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


