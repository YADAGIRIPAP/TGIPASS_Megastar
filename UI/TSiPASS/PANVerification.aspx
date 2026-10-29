<%@ page language="C#" autoeventwireup="true" codefile="PANVerification.aspx.cs" inherits="UI_TSiPASS_PANVerification" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 212px;
        }

        .auto-style2 {
            width: 650px;
        }
    </style>
    <script src="../../Resource/Scripts/js/validations.js"></script>
    <script>
        function validateIndianMobileNumber(mobileNumber) {
            var value = mobileNumber.value;
            if (value != "") {
                if (value.length != 10) {
                    mobileNumber.focus();
                    mobileNumber.value = "";
                    return alert('Mobile number should be 10 digits');
                }
                else {
                    var firstChar = value.charCodeAt(0)
                    if (firstChar < 54 || firstChar > 57) {
                        mobileNumber.value = "";
                        alert("Please enter valid Mobile number");
                        return false;
                    }
                }
            }
        }
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    maxDate: 0
                });

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td>
                    <div id="Receipt" runat="server" class="auto-style2">
                        <table style="width: 595px;">
                            <tr>
                                <td>
                                    <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black; width: 750px;">

                                        <tr>
                                            <td align="center">
                                                <img src="../../Resource/Images/telanganalogo.png" height="60px" width="60px" />
                                                <br />
                                                <div>
                                                    <font size="2"><strong style="font-family: Arial">Commissioner of Industries,<br />
                                                        Chirag Ali Lane, Abids,<br />
                                                        Hyderabad - 500 001<br />
                                                        Phone : 040-23441636<br />
                                                    </strong></font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong style="font-weight: bold" class="tdStyle">User Details Update</strong></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table runat="server" id="tblbase" align="center" border="1" style="width: 100%; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; border-collapse: collapse;">
                                                    <tr style="height: 40px">
                                                        <td class="auto-style1" align="left">
                                                            <asp:Label ID="Label2" runat="server">Email Id</asp:Label></td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                                                            OTP will be sent to the entered Email</td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left">Mobile No:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtMobileNo" runat="server" onkeypress="NumberOnly()" MaxLength="10" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                            OTP will be sent to the entered Mobile No.</td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td class="auto-style1" align="left">PAN Category:</td>
                                                        <td class="tdStyle" align="left" colspan="3">
                                                            <asp:RadioButtonList ID="rblPanCategory" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblPanCategory_SelectedIndexChanged">
                                                                <asp:ListItem Text="Individual" Value="Individual"></asp:ListItem>
                                                                <asp:ListItem Text="Company" Value="Company"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td class="auto-style1" align="left">PAN Number:
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtPANNumber" onblur="fnValidatePAN(this);" MaxLength="10" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="lblName" runat="server">Name as per PAN</asp:Label>
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtNamePerPAN" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="lblDate" runat="server">Date of Incorporation:</asp:Label>
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                                            (DD-MM-YYYY)
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" class="tdStyle">
                                                            <asp:Button ID="btnSave" runat="server" Text="Send OTP" CssClass="btnStyle" OnClick="btnSave_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>


                                        <tr>
                                            <td>
                                                <table runat="server" id="tblverify" visible="false" align="center" border="1" style="width: 100%; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; border-collapse: collapse;">
                                                    <tr style="height: 40px">
                                                        <td class="auto-style1" align="left">
                                                            <asp:Label ID="lblEmailOtp" runat="server">E-mail OTP:</asp:Label></td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtEmailOtp" MaxLength="8" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td class="auto-style1" align="left">Mobile OTP:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:TextBox ID="txtMobileOtp" MaxLength="6" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" class="tdStyle">
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Submit" CssClass="btnStyle" OnClick="btnUpdate_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
