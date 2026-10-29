<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmcentralinspectionreport.aspx.cs" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" Inherits="UI_TSiPASS_frmcentralinspectionreport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay
        {
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
        
        .style8
        {
            height: 30px;
        }
        
        .style9
        {
            width: 27px;
            height: 30px;
        }
    </style>
    
     <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }

        }
    </style>
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }


        .button {
            background-color: #004A7F;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: none;
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-family: Arial;
            font-size: 15px;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
        }

        @-webkit-keyframes glowing {
            0% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -webkit-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }
        }

        @-moz-keyframes glowing {
            0% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -moz-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }
        }



        @keyframes glowing {
            0% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }
        }

        .button {
            -webkit-animation: glowing 1500ms infinite;
            -moz-animation: glowing 1500ms infinite;
            -o-animation: glowing 1500ms infinite;
            animation: glowing 1500ms infinite;
        }

        .overlay {
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

        .textboxPge {
            border: 1px solid #c4c4c4;
            height: 30px;
            width: 140px;
            font-size: 13px;
            padding: 4px 4px 4px 4px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #d9d9d9;
            -moz-box-shadow: 0px 0px 8px #d9d9d9;
            -webkit-box-shadow: 0px 0px 8px #d9d9d9;
        }

            .textboxPge:focus {
                outline: none;
                border: 1px solid #7bc1f7;
                box-shadow: 0px 0px 8px #7bc1f7;
                -moz-box-shadow: 0px 0px 8px #7bc1f7;
                -webkit-box-shadow: 0px 0px 8px #7bc1f7;
            }
    </style>
<%--    <script type="text/javascript">
        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
        [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
        [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
        [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
        [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
        [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
        [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
        [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
        [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

        function validateVerhoeff() {
            //document.getElementById('txtadhar1'+'txtadhar2'+'txtadhar3').value

            var num = document.getElementById("<%=txtadhar1.ClientID %>").value + document.getElementById("<%=txtadhar2.ClientID %>").value + document.getElementById("<%=txtadhar3.ClientID %>").value;
            //alert(num);
            //alert('hi');
            var num;
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
            }
            else {

                alert("This is not Valid Aadhar Number");
                document.getElementById("<%=txtadhar1.ClientID %>").value = "";
                document.getElementById("<%=txtadhar2.ClientID %>").value = "";
                document.getElementById("<%=txtadhar3.ClientID %>").value = "";
            }
        }



        /*
        * Converts a string to a reversed integer array.
        */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
        * Reverses an int array
        */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }

        function ValidatePAN() {
            var Obj = document.getElementById("txtcontact0");
            if (Obj.value != "") {
                ObjVal = Obj.value;
                var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
                if (ObjVal.search(panPat) == -1) {
                    alert("Invalid Pan No");
                    Obj.focus();
                    return false;
                }
            }
        }
    </script>--%>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTST.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != null && el.value.length != 0 && el.value.length != 10) {
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
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
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
                        <%-- <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">New User Registration</h3>
                            </div>--%>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="left" style="font-size: x-large">
                                Central Inspection Report</h1>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="panel-body">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                        &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                        Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            
                                            <td valign="top" align="center" style="width: 50%">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; width: 40%">
                                                            <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="165px">UserId</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 2%">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 50%">
                                                            <asp:TextBox ID="txtemail" runat="server" autocomplete="off" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtemail"
                                                                ErrorMessage="Please Enter Email Id" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtemail"
                                                                ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label361" runat="server" CssClass="LBLBLACK" Width="137px">Password</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtcontact" runat="server"  class="form-control txtbox" autocomplete="off" type="Password"
                                                                Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" onblur="checkLength(this)"
                                                                ValidationGroup="group" Width="220px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtcontact"
                                                                ErrorMessage="Please Enter Contact No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtcontact"
                                                                ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                            <asp:Button ID="Button1" runat="server" CssClass="button" Height="30px" Text="Click Here to Verify Mobile No"
                                                                Width="220px" OnClick="Button1_Click" ValidationGroup="group"  />
                                                        </td>
                                                    </tr>
                                                <tr id="OTPTR" runat="server">
                                                        <td style="padding: 5px; margin: 5px">
                                                            Please Enter OTP received on your phone
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtOTPVerify" autocomplete="off" Enabled="true" runat="server" 
                                                                class="form-control txtbox" MaxLength="6" Height="28px" Width="220px" ToolTip="Please enter OTP Rcvd on your phone here"
                                                                OnTextChanged="txtOTPVerify_TextChanged1" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:ImageButton ID="imgid" runat="server" ImageUrl="~/images/update.png" Visible="false" />
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <%--  <td>Enter Below Code 
                                                        </td>--%>
                                                        <%--    <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:TextBox ID="txtCaptcha" autocomplete="off"  class="form-control txtbox"  TabIndex="1" Height="28px" runat="server" Width="220px"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                      
                                    </table>
                                    </td> </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            <%--<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                OnClick="BtnSave_Click" TabIndex="10" Text="Register" ValidationGroup="group"
                                                Width="90px" />--%>
                                            &nbsp<%--;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                Width="90px" Visible="false" />--%>&nbsp;<%--<asp:Button ID="BtnDelete" Visible="false" runat="server" CausesValidation="False"
                                                CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                                Text="Delete" Width="90px" OnClientClick="return confirm('Do you want to delete the record ? ');" />--%></td>
                                    </tr>
                                    <tr>
                                         <td colspan="2">
                                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="12px" ForeColor="#333333" Height="62px" ShowFooter="True" Width="100%"
                                                 Font-Bold="true" Visible="false"  SkinID="gridviewSkin"  OnRowDataBound="GridView1_RowDataBound1">
                                                  <FooterStyle BackColor="#B8860B" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                                         <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                 <Columns>
                                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                         <ItemTemplate>
                                                             <%# Container.DataItemIndex +1 %>
                                                         </ItemTemplate>
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <ItemStyle Width="20px" />
                                                     </asp:TemplateField>
                                                     <asp:BoundField DataField="UnitName" HeaderText="Name of Unit" />
                                                     <asp:BoundField DataField="Department" HeaderText="DEPARTMENT NAME" />
                                                     <asp:BoundField DataField="Date_Inspection" HeaderText="INSPECTION DATE" />      
                                                     <asp:BoundField DataField="Inspection_Authority_Desg" HeaderText="InspectionAuthorityDesignation" />
                                                     <asp:BoundField DataField="NeedforInspection" HeaderText="Type of Inspection" />
                                                      <asp:BoundField DataField="ADDRES_S" HeaderText="Address of Unit" />
                                                     <asp:TemplateField HeaderText="Uploaded Doc 1" ItemStyle-Width="30">
                                                         <ItemTemplate>
                                                             <asp:HyperLink ID="hprlink1" runat="server" NavigateUrl='<%#Eval("File_Link")%>'   Target="_blank" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Uploaded Doc 2" ItemStyle-Width="30">
                                                         <ItemTemplate>
                                                             <asp:HyperLink ID="hprlink2" runat="server" NavigateUrl='<%#Eval("File_Link2")%>'   Target="_blank" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Uploaded Doc 3" ItemStyle-Width="30">
                                                         <ItemTemplate>
                                                             <asp:HyperLink ID="hprlink3" runat="server" NavigateUrl='<%#Eval("File_Link3")%>'  Target="_blank" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Uploaded Doc 4" ItemStyle-Width="30">
                                                         <ItemTemplate>
                                                             <asp:HyperLink ID="hprlink4" runat="server" NavigateUrl='<%#Eval("File_Link4")%>' Target="_blank" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />--%>
                                                     </Columns>
                                             </asp:GridView>
                                         </td>
                                    </tr>
                                    <tr>
                                         <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                    </tr>
                                    </table>
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:HiddenField ID="hdfUploadFile1" runat="server" />
                                    <asp:HiddenField ID="HDFmsgOTP" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group1" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- </div>--%>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <%--  <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                    <%-- <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />

                        </div>--%>
                    <%-- </div>--%>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>