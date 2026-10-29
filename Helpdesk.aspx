<%@ Page Title=":: TSiPASS : Helpdesk Registration" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Helpdesk.aspx.cs" Inherits="Helpdesk" %>


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

        .style5 {
            width: 159px;
        }

        .style6 {
            width: 4px;
        }

        .style7 {
            width: 734px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style5 {
            width: 73px;
        }
        .auto-style6 {
            width: 70px;
        }
        .auto-style7 {
            width: 80%;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/Bomas.aspx", "List", "scrollbars=yes,resizable=yes,width=920,height=650;display = block;position=absolute");

            return false;
        }
    </script>




    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a>
                            </li>
                    <%--<li class="">
                                <i class="fa fa-fw fa-table"></i> Masters
                            </li>--%>
                    <li class="active">
                        <i class="fa fa-edit"></i>Helpdesk Registration
                    </li>
                </ol>
            </div>
            <div align="center">


                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Helpdesk Registration</h3>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                           <!-- <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                            </tr>-->
                                            <!--<tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>-->
                                            
                                            </tr>
                                            
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center" valign="top">
                                                    <table cellpadding="3" cellspacing="5" style="width: 60%">
                                                        <tr id="nameRow" runat="server">
                                                            <td class="auto-style5" style="padding: 2px; margin: 5px">
                                                                <asp:Label ID="lbldeptname" runat="server" CssClass="LBLBLACK" Width="90">Name</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px" align="left">
                                                                <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="300px">Name</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style5" style="padding: 2px; margin: 5px">
                                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="90px">User Name</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" width="10%">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px" align="left">
                                                                <asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" Width="165px">Name</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="unitnameRow" runat="server">
                                                            <td class="auto-style5" style="padding: 2px; margin: 5px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="90px">Unit Name</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td align="left" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="lblUnitname" runat="server" CssClass="LBLBLACK" Width="300px"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style5" style="padding: 2px; margin: 5px">
                                                                <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="90px">Your Mail Id</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtemail" runat="server" class="form-control txtbox" MaxLength="40" TabIndex="1" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Please Correct Email of Trainee" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtemail" ErrorMessage="Enter Officer Mail id" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px"></td>
                                                <td valign="top">
                                                    <table cellpadding="3" cellspacing="3">
                                                        <tr id="uidnumberRow" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="90px">UID Number</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td align="left" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="lbluidNo" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label304" runat="server" CssClass="LBLBLACK" Width="100px">Feedback Type</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td align="left" style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlfeedback" runat="server" AutoPostBack="True" class="form-control txtbox" Height="30px" TabIndex="1" ToolTip="Please select the FeedBack" ValidationGroup="group" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlfeedback" ErrorMessage="Select the Feedback" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style3" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label355" runat="server" CssClass="LBLBLACK" Width="113px">Upload</asp:Label>
                                                            </td>
                                                            <td class="auto-style3" style="padding: 5px; margin: 5px">:</td>
                                                            <td align="left" style="padding: 5px; margin: 5px">
                                                                <asp:FileUpload ID="txtupload" runat="server" class="form-control txtbox" Height="30px" onchange="this.form.submit();" TabIndex="1" Width="180px" />
                                                            </td>
                                                            <td class="auto-style3" style="padding: 5px; margin: 5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td>&nbsp;<asp:HyperLink ID="hypScanLetter" runat="server" CssClass="LBLBLACKFOOTER" Target="_blank"></asp:HyperLink>
                                                                <asp:Label ID="lblScanLetter" runat="server" CssClass="LBLBLACKFOOTER"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 4px; margin: 4px">
                                                        <table cellpadding="4" cellspacing="5" class="auto-style7">
                                                            <tr>
                                                               
                                                                <td style="width:90px">
                                                                    <asp:Label ID="lbldeptname0" runat="server" CssClass="LBLBLACK" Width="90px">Comments</asp:Label>
                                                                </td>
                                                                
                                                                <td class="style6" style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style7" style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtsubjet" runat="server" class="form-control txtbox" Height="69px" MaxLength="1500" TabIndex="1" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsubjet" ErrorMessage="Enter the Subject/Comments" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Submit" ToolTip="To Save  the data" ValidationGroup="group" />
                                                        &nbsp;&nbsp;<asp:Button ID="BtnClosebatchClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="100px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px"><%--<b style="color: rgb(255, 0, 0); font-family: arial, sans-serif; font-size: medium; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                                            Your Helpdesk will be redressed within 24 hours. In case of any delay kindly 
                                            contact to Toll Free No: 7306-600-600.</b>--%></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
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

