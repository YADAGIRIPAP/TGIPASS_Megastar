<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DepartmentService.aspx.cs" Inherits="UI_TSiPASS_DepartmentService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Department Service</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 90%">

                                        <tr>
                                            <td style=" margin: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px; width:350px">
                                                <asp:Label ID="Label303" runat="server" CssClass="LBLBLACK" Width="165px"> CFE Application UID NO.</asp:Label>
                                            </td>
                                            <td style="padding: 5px;padding-right: 5px; padding-top: 5px; padding-bottom: 5px;">:</td>
                                            <td style="margin: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;">
                                                <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtuidno" ErrorMessage="Please Enter UID No"
                                                    ValidationGroup="group">* Please Enter UID No</asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3"
                                                style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary"
                                                    Height="32px"  OnClick="btnSubmit_Click" TabIndex="10" Text="Submit"
                                                    ValidationGroup="group" Width="90px" />
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" Visible="false"
                                                    CssClass="btn btn-warning" Height="32px"  TabIndex="10"
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
                                                    <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

