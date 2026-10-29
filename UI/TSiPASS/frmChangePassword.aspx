<%@ Page Title=":: TSiPASS : Add States" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmChangePassword.aspx.cs" Inherits="AddQualiication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookup/Qualification.aspx", "List", "scrollbars=yes,resizable=yes,width=920,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <style>
        @-webkit-keyframes blinker {
            from {
                opacity: 5.0;
            }

            to {
                opacity: 0.4;
            }
        }

        .blink {
            color: red;
            text-decoration: blink;
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 0.3s;
            -webkit-animation-iteration-count: infinite;
            -webkit-animation-timing-function: ease-in-out;
            -webkit-animation-direction: alternate;
        }
    </style>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>Change Password
                    </li>

                </ol>
            </div>
            <%--<div class="alert alert-warning fade in" id="warning" runat="server" visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> <asp:Label ID="lbluserid0" runat="server" 
        CssClass="" ></asp:Label>
    &nbsp;
  </div>--%>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Change Password</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    <tr id="hidetablepassword" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: larger" colspan="3" align="center" class="blink">&nbsp;
                                           <%-- Your Default Password : TSIPASS123--%>
                                        </td>
                                    </tr>
                                    <tr id="hidetable" runat="server">
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 90%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label349" runat="server" CssClass="LBLBLACK" Width="165px">User ID</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lbluserid" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label303" runat="server" CssClass="LBLBLACK" Width="165px">Old Password</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtPwd" runat="server" class="form-control txtbox"
                                                            Height="28px" MaxLength="50" oncopy="return false" oncut="return false"
                                                            onkeypress="Names()" onpaste="return false" TabIndex="1"
                                                            ValidationGroup="group" Width="180px" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="txtPwd" ErrorMessage="Please Enter Old Password"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label298" runat="server" CssClass="LBLBLACK" Width="165px">New Password</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtNpwd" runat="server" class="form-control txtbox"
                                                            Height="28px" MaxLength="100" oncopy="return false" oncut="return false"
                                                            onpaste="return false" TabIndex="1" ValidationGroup="group" Width="180px"
                                                            TextMode="Password"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtNpwd" ErrorMessage="Please Enter New Password"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ErrorMessage="<br/>Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit." ForeColor="Red"
                                                            ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$" ControlToValidate="TxtNpwd" runat="server"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                     <td  align="left" >
                                                        *Note: Password must be at least 8 characters, must include
                                                        <br />
                                                         at least one upper case letter, one lower case letter,
                                                        <br />
                                                         one numeric digit and one Special Character.
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>Enter Below Code 
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtCaptcha" class="form-control txtbox" TabIndex="1" Height="28px" runat="server" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px"></td>
                                                    <td style="padding: 5px; margin: 5px"></td>
                                                    <td valign="middle" align="left">
                                                        <asp:UpdatePanel ID="UP1" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:Image ID="imgCaptcha" runat="server" />
                                                                        </td>
                                                                        <td style="width: 5px"></td>
                                                                        <td style="padding: 5px; margin: 5px" valign="middle">
                                                                            <asp:ImageButton ID="btnRefresh" ImageUrl="~/images/refresh.png" Height="30px" Width="30px" runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                </td>
                                  
                                    </tr>
                                       
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                    </tr>
                                <tr id="trsubmittion" runat="server">
                                    <td align="center" colspan="3"
                                        style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                            Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Submit"
                                            ValidationGroup="group" Width="90px" />
                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                            CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                            Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>


                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>Warning!</strong> <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trchangepewmessage" runat="server" visible="false">
                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                        <span style="font-weight: bold; font-size: 15pt">Please Click Here 
                                                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/IpassLogin.aspx" runat="server">Click </asp:HyperLink>

                                            &nbsp;to Login Again </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>




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

