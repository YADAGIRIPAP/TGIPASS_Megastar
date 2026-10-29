<%@ Page Title="" Language="C#" MasterPageFile="CCMaster.master" AutoEventWireup="true" CodeFile="UserCommentsAmmendmentView.aspx.cs" Inherits="UI_TSiPASS_UserCommentsAmmendmentView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">



        function OpenPopup() {

            window.open("Lookups/MobilizationLookup.aspx", "List", "scrollbars=yes,resizable=yes,width=900,height=750");

            return false;
        }


        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });


    </script>
       <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a> </li>
            <li class=""><i class="fa fa-fw fa-table"></i>Helpdesk </li>
            <li class="active"><i class="fa fa-edit"></i>View Status </li>
        </ol>
    </div>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">DEPARTMENT AMENDMENTS</h3>
                    </div>
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <%--   <tr>
                                <td align="center" style="padding: 5px; vertical-align: top; text-align: center"
                                    valign="middle">
                                    <table style="width: 96%; height: 53px"
                                        width="80%">
                                        <tr>
                                            <td >
                                                <table cellpadding="0" cellspacing="0" style="width: 70%">--%>
                            <tr style="height:60px;">
                                <td align="right" valign="middle" >Ammendments : &nbsp;&nbsp;&nbsp;&nbsp;</td> <td align="left" valign="middle">
                                    <asp:DropDownList ID="ddlammendments" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlammendments_SelectedIndexChanged" >
                                        <asp:ListItem>--District--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView Width="100%" ID="gvComments" runat="server" AutoGenerateColumns="true" border="3" CellPadding="4" CellSpacing="1">
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle Height="50px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <%-- </table>
                                            </td>
                                            <td style="width: 50%; height: 80px" valign="top">&nbsp;</td>
                                        </tr>
                                    </table>
                                   
                                </td>
                            </tr>--%>
                            <tr id="Tr1" runat="server">
                                <td align="center" colspan="2" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; text-align: center"
                                    valign="middle">
                                    <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                        ForeColor="Green" Style="position: static"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" id="Reject">
                                <td align="center" colspan="2" style="padding: 5px; vertical-align: middle; text-align: center"
                                    valign="middle">
                                    <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" id="Close">
                                <td align="center" colspan="2" style="padding: 5px; vertical-align: middle; text-align: center"
                                    valign="middle">
                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding: 5px; vertical-align: middle; height: 35px; text-align: left"
                                    valign="middle">&nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; height: 35px; text-align: center"
                                    valign="middle">&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                            ShowSummary="False" Style="position: static" ValidationGroup="group" />
                        </td> </tr> </table>
                                        <asp:HiddenField ID="hdfusercode" runat="server" />
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

