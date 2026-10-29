<%@ Page Title=":: TS-iPass Govenrnment of Telengana : TST Team " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="AddNewInspectionUser.aspx.cs" Inherits="CheckPOITD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 1px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTST.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>

    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>

<%--    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <%--<ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx">Dashboard</a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-table"></i> Masters
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">TST Team</a>
                            </li>
                        </ol>--%>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title" >
                                   <asp:Label id="lblHeading" runat="server" Text="To Upload Inspection Report"></asp:Label></h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body" style="vertical-align:middle" >
                                        <div runat="server" id="divbtn" visible="false" style="padding-left:20%; padding-right:20%;vertical-align:middle">
                                            &nbsp;</div>
                                        <div>
                                            <table runat="server" align="center" cellpadding="10" cellspacing="5" 
                                                style="width: 30%">
                                                <tr>
                                                    <td style=" vertical-align: middle; text-align: center;" 
                                                        valign="middle" colspan="2" align="center">
                                                        
                                                       
                                                       
                                                       
                                                       
                                                            
                                                             <table cellpadding="4" cellspacing="5" style="width: 53%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center" 
                                                                    colspan="2">
                                                                   <asp:Label ID="Label386" runat="server" Font-Bold="True" ForeColor="#FF0066" 
                                                            style=" vertical-align:middle; text-align:center; font-size:large">Official User</asp:Label> 
                                                                </td>
                                                               
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                   <asp:ImageButton ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                                                            src="../../images/register.jpg" /> 
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:ImageButton ID="btnLogin" runat="server" PostBackUrl="../../Index.aspx" 
                                                            src="../../images/login.jpg" />
                                                                </td>
                                                               
                                                            </tr>
                                                             <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" colspan="2" align="center">
                                                                  <b> <a href="RptInspectionRptDrillDown.aspx" target="_blank">Search & Download Inspection Report</a> </b>
                                                                </td>
                                                               
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr runat="server"  visible="false" id="tblRegister">
                                                    <td 
                                                        style="padding: 5px; margin: 5px; " valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Width="165px">Department<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" 
                                                                        Height="28px" TabIndex="1" Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                        ControlToValidate="ddlDepartment" ErrorMessage="Please select Department" 
                                                                        InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label385" runat="server" CssClass="LBLBLACK" Width="137px">Designation<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:TextBox ID="txtDesignation" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="25" TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RegularExpressionValidator4" runat="server" 
                                                                        ControlToValidate="txtDesignation" ErrorMessage="Enter Designation" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" 
                                                                        class="form-control txtbox" Height="28px" 
                                                                        OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" TabIndex="3" 
                                                                        Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                        ControlToValidate="ddlDistrict" ErrorMessage="Please select District" 
                                                                        InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" 
                                                                        Height="28px" TabIndex="4" Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                        ControlToValidate="ddlMandal" ErrorMessage="Please select Mandal" 
                                                                        InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label376" runat="server" CssClass="LBLBLACK" Width="165px">First Name<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:TextBox ID="txtfirstname" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="50" onkeypress="Names()" TabIndex="5" 
                                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                                        ControlToValidate="txtfirstname" ErrorMessage="Please Enter FirstName" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="165px">Last Name<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:TextBox ID="txtLastname" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="50" onkeypress="Names()" TabIndex="6" 
                                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                                        ControlToValidate="txtLastname" ErrorMessage="Please Enter last name" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label372" runat="server" CssClass="LBLBLACK" Width="137px">Office Address<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:TextBox ID="txtaddress" runat="server" class="form-control txtbox" 
                                                                        Height="45px" TabIndex="7" TextMode="MultiLine" ValidationGroup="group" 
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    
                                                    <td align="center" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label361" runat="server" CssClass="LBLBLACK" Width="137px">Aadhaar Number<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtAadhaar" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="12" onblur="checkLength1(this)" 
                                                                        onkeypress="NumberOnly()" TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                        ControlToValidate="txtAadhaar" ErrorMessage="Please Enter Aadhaar Number" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="137px">Mobile Number<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtcontact" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="10" onblur="checkLength(this)" 
                                                                        onkeypress="NumberOnly()" TabIndex="9" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                        ControlToValidate="txtcontact" ErrorMessage="Please Enter Contcat" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                        ControlToValidate="txtcontact" ErrorMessage="Invalid Mobile Number" 
                                                                        ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="165px">Email Id<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtemail" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="40" TabIndex="10" ValidationGroup="group" 
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                                        ControlToValidate="txtemail" ErrorMessage="Please Enter Email" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                                        ControlToValidate="txtemail" ErrorMessage="Please Enter Correct Email" 
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label381" runat="server" CssClass="LBLBLACK" Width="137px">Enter User Name<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtname2" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="15" onkeypress="Names()" TabIndex="11" 
                                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                                        ControlToValidate="txtname2" ErrorMessage="Please Enter username" 
                                                                        ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" 
                                                                        Height="30px" OnClick="BtnSave2_Click" TabIndex="12" Text="Check Availability" 
                                                                        ValidationGroup="group1" Width="140px" />
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label382" runat="server" CssClass="LBLBLACK" Width="137px">Enter Password<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtpasswordnew" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="15" TabIndex="13" TextMode="Password" 
                                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                                        ControlToValidate="txtpasswordnew" ErrorMessage="Please Enter password" 
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label383" runat="server" CssClass="LBLBLACK" Width="137px">Re Enter Password<font 
                                                                        color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtcomparepwd" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="15" TabIndex="14" TextMode="Password" 
                                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                                        ControlToCompare="txtpasswordnew" ControlToValidate="txtcomparepwd" 
                                                                        ErrorMessage="Please Enter Correct Passowrd" ValidationGroup="group">*</asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    
                                                </tr>
                                                
                                                <tr runat="server"  visible="false" id="tblRegister1">
                                                    <td align="center" colspan="2" 
                                                        style="padding: 5px; margin: 5px; text-align: center;">
                                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                            Height="32px" OnClick="BtnSave_Click" TabIndex="15" Text="Register" 
                                                            ValidationGroup="group" Width="90px" />
                                                        &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-danger" Height="32px" OnClick="BtnClear_Click" TabIndex="16" 
                                                            Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                        &nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" 
                                                            OnClientClick="return confirm('Do you want to delete the record ? ');" 
                                                            TabIndex="17" Text="Delete" Visible="false" Width="90px" />
                                                    
                                                    </td>
                                                   </tr>
                                                   <tr runat="server"  visible="false" id="tblRegister2" >
                                                    <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="2" >
                                                        <div ID="success" runat="server" class="alert alert-success" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" 
                                                                href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                                ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div ID="Failure" runat="server" class="alert alert-danger" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                                            Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                    
                                                   </tr>
                                                   
                                                   
                                                
                                            </table>
                                        </div>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:HiddenField ID="hdfUploadFile1" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group1" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
           <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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
