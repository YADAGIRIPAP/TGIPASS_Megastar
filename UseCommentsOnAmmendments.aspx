<%@ Page Title="" Language="C#" MasterPageFile="EmptyMaster2.master" AutoEventWireup="true" CodeFile="UseCommentsOnAmmendments.aspx.cs" Inherits="UseCommentsOnAmmendments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

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

        table {
            width: 900px;
        }

        .style7 {
            width: 42px;
        }

        .style8 {
            height: 30px;
        }

        .style9 {
            width: 27px;
            height: 30px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
           <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i></i><a href="TSHome.aspx">Home</a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i ></i>Business Regulations
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">BUSINESS REGULATIONS (ACT/RULES/REGULATIONS/ORDERS)</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table cellspacing="0" cellspacing="0" border="1" style="padding: 0; margin: 0;" width="100%">

                                            <tr>
                                                <td style="text-align: center;">
                                                    <table width="50%">
                                                        <tr>
                                                            <td>
                                                                <table width="50%">
                                                                    <tr>
                                                                        <td>Draft Regulations</td>
                                                                        <td>Final Regulations
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFCC" BorderStyle="Inset"
                                                                                BorderWidth="3" Width="600px">
                                                                                <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()"
                                                                                    scrolldelay="150" style="height: 300px;">
<asp:Literal ID="lt1" runat="server" ></asp:Literal></marquee>
                                                                            </asp:Panel>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFCC" BorderStyle="Inset"
                                                                                BorderWidth="3" Width="600px">
                                                                                <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()"
                                                                                    scrolldelay="150" style="height: 300px;">
<asp:Literal ID="lt2" runat="server" ></asp:Literal></marquee>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>


                                            </tr>

                                        </table>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="text-align: center; height: 20px"></td>
                                            </tr>
                                            <tr id="ddd" runat="server" visible="false">
                                                <td style="text-align: center;" colspan="8">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnComments" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" Text="USER COMMENTS" Width="177px" OnClick="btnComments_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 30px">
                                                    <%--  <table>
                                                        <tr>
                                                            <td>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trComments" visible="false">
                                                <td style="text-align: center; width: 100%" align="center">
                                                    <table cellpadding="4" cellspacing="5" align="center">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">User Name</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtUserName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                                                                    ErrorMessage="Please Enter User Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">District</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrict" InitialValue="--District--"
                                                                    ErrorMessage="Please select District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mobile Number</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="0" ToolTip="text" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNo"
                                                                    ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mail Id</td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmailId" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Department</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartments" InitialValue="--Select--"
                                                                    ErrorMessage="Please select Department" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Amendment</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlAmendment" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAmendment" InitialValue="--Select--"
                                                                    ErrorMessage="Please select Amendment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Comments</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                <asp:TextBox ID="txtComments" runat="server" class="form-control txtbox" Height="91px" MaxLength="50" TabIndex="0" TextMode="MultiLine" ValidationGroup="group" Width="500px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtComments"
                                                                    ErrorMessage="Please enter Comments" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <%--<td></td>
                                                            <td></td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="text-align: center; height: 20px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="text-align: center">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" Height="32px" OnClick="btnSave_Click" Text="SUBMIT USER COMMENTS" ValidationGroup="group" Width="200px" />
                                                                &nbsp;
                                                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-warning" Height="32px" OnClick="btnClear_Click" Text="CLEAR" Width="120px" />
                                                            </td>
                                                            <%--  <td colspan="4" style="text-align: center">&nbsp;</td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" align="center">
                                                    <table style="width: 100%">
                                                        <tr id="Tr1" runat="server">
                                                            <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; text-align: center"
                                                                valign="middle">
                                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                                    ForeColor="Green" Style="position: static"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="Reject">
                                                            <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                                valign="middle">
                                                                <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="Close">
                                                            <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                                valign="middle">
                                                                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                                                <%--<a target="_blank" style="font-family: fantasy; font-size: larger; font-weight: bold; font-style: normal; color: #8B0000; text-underline-position: auto">AAAA</a>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <%--   <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                      
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>



