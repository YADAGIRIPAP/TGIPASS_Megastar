<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TSipassfeedbackPostCertificate.aspx.cs" Inherits="UI_TSiPASS_TSipassfeedbackPostCertificate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        a {
            color: #337ab7;
            text-decoration: none;
        }

        a {
            background-color: transparent;
        }

        .LBLBLACK {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" style="border: 1px solid #000000; font-family: Verdana; font-size: 12px; text-align: left; width: 800px;">
            <tr>
                <td align="center" style="/*padding: 0px; margin: 0px; text-align: center*/">
                    <img src="telanganalogo.png" width="75px" height="65px" />
                </td>
            </tr>
            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000; font-family: Verdana; font-size: 18px;">
                <td align="center" style="text-align: center; font-family: Verdana; font-weight: bold; font-size: 18px; border: 1px solid #000000;">TS-iPASS FEEDBACK FORM</td>
            </tr>
            <tr>
                <td align="center">
                    <table bgcolor="White" width="900" border="2px" cellpadding="22" style="font-family: Verdana; font-size: 14px;">

                        <tr style="background-color: #6699FF">
                            <td colspan="2" style="padding: 5px; margin: 5px" valign="top"><b><span>Post Download of Certificate</span></b></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>1.	Were you given the license / approval / certificate within the stipulated timelines* </b>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rblLicenseApproval" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trissues1" runat="server" visible="false">
                                        <td align="left" colspan="2">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr id="trissues1a" runat="server" visible="false">
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtLicenseApprovalIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox><br />
                                            * To select license / approval / certificate based on the department
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="2" align="left">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 300px">Department Name <font color="red">*</font></td>

                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:DropDownList ID="ddlDeptlist" runat="server" class="form-control txtbox"
                                                            Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlDeptlist_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                          <%--  <asp:ListItem Text="PCB" Value="1"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                            ControlToValidate="ddlDeptlist"
                                                            ErrorMessage="Please Select Department Name" InitialValue="0"
                                                            ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="170px">Approval Name <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:DropDownList ID="ddldeptApprovals" runat="server" class="form-control txtbox"
                                                            Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                            ValidationGroup="group" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                         <%--   <asp:ListItem Text="PCB Approval" Value="1"></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" InitialValue="--Select--"
                                                            ControlToValidate="ddldeptApprovals"
                                                            ErrorMessage="Please Select Approval Name" ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label411" runat="server" CssClass="LBLBLACK" Width="287px">Issues Faced and Recommendations : <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtThirdissuesfaced" runat="server" class="form-control txtbox"
                                                            Height="80px"  TabIndex="1"
                                                            ValidationGroup="group" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="txtThirdissuesfaced"
                                                            ErrorMessage="Please enter issues faced" ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="tr2" runat="server">
                                        <td style="padding: 5px; margin: 5px" colspan="10" align="center">
                                            <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning"
                                                Height="28px" TabIndex="10" Text="Add"
                                                Width="72px" OnClick="BtnSave2_Click1" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear0" runat="server" CausesValidation="False" Visible="false"
                                                CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel"
                                                ToolTip="To Clear  the Screen" Width="73px" OnClick="BtnClear0_Click2" /></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="10">
                                            <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                                Width="100%" OnRowDataBound="gvCertificate_RowDataBound"
                                                OnRowDeleting="gvCertificate_RowDeleting">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                                    <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                                    <asp:BoundField DataField="deptname" HeaderText="department Name" />
                                                    <asp:BoundField DataField="approvalname" HeaderText="Approval" />
                                                    <asp:BoundField DataField="issuesfaced" HeaderText="Issues Faced" />
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldeptid" runat="server" Text='<%# Bind("deptid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApprovalid" runat="server" Text='<%# Bind("approvalid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblquestionid" runat="server" Text='<%# Bind("questionid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#013161" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>

                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>
                                        2.	Were you able to track the status of your application through the website
                                            ble to track the status of your application through the website
                                            
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:RadioButtonList ID="rblTrackstatus" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtTrackStatusIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>3.	Were you asked for any offline information or documentsfor application processing</b>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:RadioButtonList ID="rblOfflineInfoasked" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtOfflineInfoaskedIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2"><table>
                                                <tr>
                                                    <td colspan="2" align="left"><b>4.	Provide your feedback on the inspection on your premises** 
                                            <br />
                                                    </b>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left">
                                                        <asp:RadioButtonList ID="rblInspectionFeedback" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="1" Text="Inspection was well informed, scheduled and conducted"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Inspection scheduled but not conducted on time"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Inspection conducted without prior intimation"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="Inspection not conducted"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr id="trissues4" runat="server" visible="false">
                                                    <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                                </tr>
                                                <tr id="trissues4a" runat="server" visible="false">
                                                    <td colspan="2" align="left">
                                                        <asp:TextBox ID="txtInspectionFeedbackIssuesfaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox><br />
                                                        ** To be included only by departments carrying out inspection
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="2">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 300px;">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Department Name<font 
                                                            color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlDeptlist4" runat="server" class="form-control txtbox"
                                                                        Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlDeptlist4_SelectedIndexChanged" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                       <%-- <asp:ListItem Text="PCB" Value="1"></asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                        ControlToValidate="ddlDeptlist4"
                                                                        ErrorMessage="Please Select Department Name" InitialValue="0"
                                                                        ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Approval Name <font 
                                                            color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                    <asp:DropDownList ID="ddldeptApprovals4" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                        ValidationGroup="group" Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                      <%--  <asp:ListItem Text="PCB Approval" Value="1"></asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="--Select--"
                                                                        ControlToValidate="ddldeptApprovals4"
                                                                        ErrorMessage="Please Select Approval Name" ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                                </td>

                                                            </tr>
                                                           
                                                                        <tr>
                                                                   <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="288px">Issues Faced and Recommendation <font 
                                                            color="red">*</font></asp:Label></td>
                                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                    <asp:TextBox ID="txtFourthIssuesFaced" runat="server" class="form-control txtbox"
                                                                        Height="80px"  TabIndex="1"
                                                                        ValidationGroup="group" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                        ControlToValidate="txtFourthIssuesFaced"
                                                                        ErrorMessage="Please enter issues faced" ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        
                                            </table>
                            </td>

                        </tr>
                        <tr id="tr1" runat="server">
                            <td style="padding: 5px; margin: 5px" colspan="10" align="center">
                                <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Add"
                                    Width="72px" OnClick="BtnSave4_Click1" />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear4" runat="server" CausesValidation="False" Visible="false"
                                    CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel"
                                    ToolTip="To Clear  the Screen" Width="73px" OnClick="BtnClear4_Click2" /></td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="10">
                                <asp:GridView ID="gvCertificate4" runat="server" AutoGenerateColumns="False"
                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                    CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                    Width="100%" OnRowDataBound="gvCertificate4_RowDataBound"
                                    OnRowDeleting="gvCertificate4_RowDeleting">
                                    <RowStyle BackColor="#ffffff" />
                                    <Columns>
                                        <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                        <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                        <asp:BoundField DataField="deptname" HeaderText="department Name" />
                                        <asp:BoundField DataField="approvalname" HeaderText="Approval" />
                                        <asp:BoundField DataField="issuesfaced" HeaderText="Issues Faced" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldeptid" runat="server" Text='<%# Bind("deptid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApprovalid" runat="server" Text='<%# Bind("approvalid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblquestionid" runat="server" Text='<%# Bind("questionid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#013161" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>

                        </tr>
                    </table>
            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left" style="padding: 5px; margin: 5px" valign="top"><b>5.	Rate the overall quality of your experience in availing the service from application submission till service fulfillment rall quality of your experience in availing the service from application submission till service fulfillment </b></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="2">
                                            <asp:RadioButtonList ID="rblrateQltyPost" runat="server" Height="60px" Width="720px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Text="Poor"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Fair"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Good"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Very Good"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Excellent"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtrateqltyPostIssuesfaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"> </asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
        </table>
        </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" align="center">

                    <asp:Button ID="btnSubmit" runat="server" Height="40px" Text="Submit" Width="120px" OnClick="btnSubmit_Click"></asp:Button>
                    <asp:Button ID="btnclear" runat="server" Height="40px" Text="Clear" Width="120px" OnClick="btnclear_Click"></asp:Button>

                </td>
            </tr>
        <%--<tr>
                <td align="center" class="style2" style="text-align: center">
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </td>
            </tr>--%>

        <tr>
            <td style="width: 100%">
                <table style="width: 100%">
                    <tr>
                        <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary3" runat="server"
            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
    </form>
</body>
</html>
