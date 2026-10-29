<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Personal_Interaction_Page_EXISTING_EntrepreneursNew.aspx.cs" Inherits="UI_TSiPASS_Personal_Interaction_Page_EXISTING_EntrepreneursNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        html {
            scroll-behavior: auto;
        }

        .div-contentcenter {
            display: flex;
            justify-content: left;
            align-items: center;
            font-weight: bold;
            font-size: 15px;
            /*padding-bottom: 55px;*/
        }

            .div-contentcenter input[type="checkbox"] {
                transform: scale(1.25);
                margin-right: 15px;
            }

        .div-Content {
            display: flex;
            padding-left: 65px;
            padding-bottom: 5px;
            font-size: 15px;
            justify-content: space-between;
        }

        .div-Content-NEW {
            display: flex;
            padding-left: 63px;
            padding-bottom: 5px;
            font-size: 15px;
            justify-content: space-between;
        }

        .checkbox-list label {
            display: inline-block;
            font-size: 15px;
            margin-left: 10px;
        }

        .checkbox-list1 label {
            display: inline-block;
            text-align: center;
            font-size: 15px;
            margin-left: 5px;
            margin-right: 10px;
            font-weight: bold;
        }

        .required-field {
            color: red;
            margin-left: 5px;
        }

        .platform-name-cell {
            padding-right: 118px;
        }

        .platform-id-cell {
            padding-right: 15px;
        }

        .auto-style1 {
            display: flex;
            justify-content: left;
            align-items: center;
            font-weight: bold;
            font-size: 18px;
            width: 263px;
        }

        .auto-style2 {
            width: 204px;
        }

        .auto-style3 {
            width: 175px;
        }

        .auto-style4 {
            width: 226px;
        }

        .auto-style6 {
            height: 30px;
        }

        .auto-style7 {
            height: 25px;
        }

        .auto-style8 {
            width: 88px;
        }

        .auto-style10 {
            margin-left: 33px;
        }

        .auto-style11 {
            width: 267px;
            height: 68px;
        }

        .auto-style12 {
            height: 68px;
        }

        .auto-style13 {
            width: 451px;
        }

        .auto-style14 {
            width: 267px;
        }

        .auto-style16 {
            display: flex;
            padding-left: 63px;
            padding-bottom: 5px;
            font-size: 15px;
            justify-content: space-between;
            width: 271px;
        }
    </style>
    <script type="text/javascript">

        function pageLoad() {
            var date = new Date();
            var yrRange = "1990:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            //$("input[id$='Interaction_Date']").datepicker(
            //    {
            //        dateFormat: "dd/mm/yy",
            //        changeMonth: true,
            //        changeYear: true,
            //        yearRange: yrRange,
            //        maxDate: 0
            //    })
        }
    </script>

    <contenttemplate>
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading" align="center">
                    <h3 class="panel-title">
                        <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                            Width="199px">Personal Interaction</asp:Label></h3>
                </div>
                
        <div class="panel-body">

            <h2 runat="server" style="text-align: center; font-weight: bold; text-decoration: underline; font-size: 25px;">Interaction with Existing Entrepreneurs</h2>
            <br />
            <div>
                <table style="width:100%">
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" colspan="2">
                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                <a aria-label="close" class="close" data-dismiss="alert"  href="#" >×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row">
                <div class="row">
                    <table>
                        <tr>
                            <td>
                                <label class="div-Content">1. Interaction Type :</label>
                            </td>
                            <td style="padding-left: 100px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="ModeOfInteraction" Font-Bold="false" runat="server" Font-Size="15px" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Telephone" Value="0" style="margin-right: 0px;" />
                                        <asp:ListItem Text="Physical" Value="1" />
                                    </asp:RadioButtonList>
                                </div>

                            </td>
                        </tr>
                        <tr id="tronlydate" runat="server" visible="true">
                            <td>
                                <label class="div-Content">2. Interaction&nbsp; Date:</label></td>
                            <td style="padding-left: 100px;">
                                <input type="text" id="intrctiondt" autocomplete="off" runat="server" maxlength="16" class="datetimepicker form-control" style="width: 85%" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">3. Whether the interaction at Women Cell :</label>
                            </td>
                            <td style="padding-left: 100px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="Women_Cell" runat="server" AutoPostBack="true" Font-Size="15px" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Women_Cell_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>


                        <tr id="Interaction_Id" runat="server" visible="false">
                            <td>
                                <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3a. Interaction took place at</label>
                            </td>
                            <td style="padding-left: 100px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="Interaction_Level_Existing" Font-Bold="false" runat="server" AutoPostBack="true" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Interaction_Level_Existing_SelectedIndexChanged">
                                        <asp:ListItem Text="District Level" Value="0" style="margin-right: 0px;" />
                                        <asp:ListItem Text="Mandal Level" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row" id="Interaction_Block" runat="server" style="padding-left: 80px;" visible="false">
                    <table>
                        <tr>
                            <td>
                                <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mandal:</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:DropDownList ID="ddl_Mandal" runat="server" Width="150px" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddl_Mandal_SelectedIndexChanged" />
                            </td>
                            <td>
                                <label>&nbsp;&nbsp;&nbsp; Venue of Interaction :</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:DropDownList ID="ddlvenuemandl" Width="150px" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlvenuemandl_SelectedIndexChanged">
                                    <asp:ListItem Text="--Select--" Value="0"> </asp:ListItem>
                                    <asp:ListItem Text="MPDO" Value="1"> </asp:ListItem>
                                    <asp:ListItem Text="Municipal Commissioner Office" Value="2"> </asp:ListItem>
                                    <asp:ListItem Text="Mandal Mahila Samakhya" Value="30"> </asp:ListItem>
                                    <asp:ListItem Text="Others" Value="4"> </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <%-- </tr>
                        <tr>--%>
                            <td>
                                <label id="lblothrvenue" runat="server" visible="false">&nbsp;&nbsp;&nbsp;&nbsp; Enter Other Venue:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="Interaction_Venue" autocomplete="off" oninput="validateInputText(this)" Width="150px" runat="server" Visible="false" class="form-control"></asp:TextBox>

                            </td>
                            <td runat="server" visible="false">
                                <label class="div-Content">Date:</label>
                            </td>
                            <td class="div-contentcenter" runat="server" visible="false">
                                <input type="text" id="Interaction_Date" autocomplete="off" width="240px" runat="server" maxlength="16" class="datetimepicker form-control" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row" id="Interaction_block_District" runat="server" style="padding-left: 80px;" visible="false">
                    <table>
                        <tr>
                            <td visible="false" runat="server">
                                <label class="div-Content">Date:</label>
                            </td>
                            <td visible="false" runat="server">
                                <input type="text" id="Text1" autocomplete="off" width="240px" runat="server" maxlength="16" class="datetimepicker form-control" />
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>Venue of Interaction :</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:TextBox ID="TextBox4" autocomplete="off" oninput="validateInputText(this)" Width="150px" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <table>
                        <tr>
                            <td>
                                <label class="div-Content">4. Whether the unit registered under TS-IPASS :</label>
                            </td>
                            <td style="padding-left: 62px;">
                                <div class="auto-style1">
                                    <asp:RadioButtonList ID="TS_IPASS_REGISTERED_Unit" runat="server" Font-Size="15px" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="TS_IPASS_REGISTERED_Unit_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row" id="TS_IPASS_SEARCH_BLOCK" runat="server" visible="false">
                    <table>
                        <tr>
                            <td colspan="4" style="padding-left: 30px">
                                <label class="div-Content">4a. TS-IPASS UID Search Option :</label></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 40px;">
                                <label class="div-Content">Mandal:</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" />
                            </td>
                            <td style="padding-left: 20px;">
                                <label>Enter Moble No. to which details to be sent:</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:TextBox ID="txtmobileExistng" runat="server" Width="200px" class="form-control" autocomplete="off" MaxLength="10" onkeypress="NumberOnly()" onkeyup="validatePhoneNumber()" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 40px;">
                                <label class="div-Content" style="padding-right: 0px;">Village:</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" />
                            </td>
                            <td style="padding-left: 20px; width: 300px">
                                <label>Enter e-Mail to which details to be sent:</label>
                            </td>
                            <td class="div-contentcenter">
                                <asp:TextBox ID="txtemailExistng" runat="server" Width="200px" class="form-control" autocomplete="off" onkeyup="validateEmail(this.value)" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtemailExistng"
                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="group"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 40px;">
                                <label class="div-Content">
                                    Search by UID / Phone Number / 
                                <br />
                                    Unit Name:</label></td>
                            <td colspan="1" style="padding-left: 0px;" align="left">
                                <asp:TextBox ID="TS_IPASS_UID_SEARCH" Width="200px" autocomplete="off" placeholder="Search By UID or Unit Name or Phone Number" runat="server" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding-left: 30px;">
                                <asp:Button ID="SearchButton" runat="server" Text="SEARCH" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="25px" Width="75px" OnClick="SearchButton_Click" />

                            </td>
                        </tr>
                    </table>
                    <%--<div class="col-sm-5 form-group" align="center">
                    <label class="div-Content">4(a). TS-IPASS UID Search Option :</label>
                </div>--%>
                    <%--<div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="TS_IPASS_UID_SEARCH" autocomplete="off" AutoPostBack="true" placeholder="Search By UID or Unit Name or Phone Number" runat="server" class="form-control" OnTextChanged="TS_IPASS_UID_SEARCH_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="SearchButton" runat="server" Text="SEARCH" Enabled="false" AutoPostBack="true" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="25px" Width="75px" OnClick="SearchButton_Click" />
                </div>--%>
                </div>
                <div id="UID_SEARCHGRID" runat="server" class="row" style="padding-left: 70px; padding-bottom: 15px;" visible="false">
                    <asp:GridView ID="UID_SEARCH_GRID" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" CellPadding="2"
                        CssClass="GRD" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" AutoPostBack="true" Width="95%">
                        <HeaderStyle CssClass="gridcolor" />
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <div style="text-align: center;">Select</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:CheckBox ID="SelectCheckBox" AutoPostBack="true" runat="server" OnCheckedChanged="SelectCheckBox_CheckedChanged" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="UID_No" HeaderText="UID No" ItemStyle-Width="90" />--%>
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <div style="text-align: center;">UID No</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="UIDNo" runat="server" Text='<%#Eval("UID_No") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <div style="text-align: center;">Name</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="Applicant_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ADDRESS" HeaderText="Address" ItemStyle-Width="90" />
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <div style="text-align: center;">Contact No.</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="applContact" runat="server" Text='<%#Eval("CONTACT") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                            <asp:BoundField DataField="CONTACT" HeaderText="CONTACT" ItemStyle-Width="90" />--%>
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <div style="text-align: center;">Email ID</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="applEmail" runat="server" Text='<%#Eval("EMAILID") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <HeaderTemplate>
                                    <div style="text-align: center;">Social Category</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="applCaste" runat="server" Text='<%#Eval("SOCIALCATEGORY") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <div style="text-align: center;">Gender</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="applGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IsPHC" HeaderText="Differently Abled" ItemStyle-Width="90" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="INVESTMENT" HeaderText="Investment" ItemStyle-Width="90" />
                            <asp:BoundField DataField="EMPLOYMENT" HeaderText="Employment" ItemStyle-Width="90" />
                            <asp:BoundField DataField="LineofActivity" HeaderText="Line of Activity" ItemStyle-Width="90" />
                            <asp:BoundField DataField="MFGSERVICE" HeaderText="Sector" ItemStyle-Width="90" />
                            <asp:TemplateField Visible="false">
                                <HeaderTemplate>
                                    <div style="text-align: center;">Line of Activity ID</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="Lineofactivity" runat="server" Text='<%#Eval("intlineofactivity") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <%--<div style="text-align: Center">--%>
                            No Records Found, Search Using UID Number or Complete Unit Name.<%--</div>--%>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#013161" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
                <div class="row" id="TS_IPASS_REGISTRATION" runat="server" visible="false" style="font-size: 15px; padding-left: 100px;" align="left">
                    <table width="80%">
                        <tr>
                            <td class="auto-style3">a) Unit Name</td>
                            <td style="padding-left: 10px; text-align: center;" class="auto-style4">
                                <asp:TextBox ID="Applicant_Name" runat="server" autocomplete="off" oninput="validateInputName(this)" class="form-control" Width="200px" /></td>
                            <td style="text-align: center;" width="15px"></td>
                            <td class="auto-style2">b) Address: Mandal<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Village</td>
                            <td style="padding-left: 10px; text-align: center;">
                                <%--<asp:TextBox ID="Applicant_Address" runat="server" autocomplete="off" oninput="validateInputText(this)" class="form-control" />--%>
                                <asp:DropDownList ID="ddladrsmandal" runat="server" Width="200px" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddladrsmandal_SelectedIndexChanged" />
                                <asp:DropDownList ID="ddladrsvlg" runat="server" Width="200px" AutoPostBack="true" class="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">c) Contact</td>
                            <td style="padding-left: 10px; text-align: center;" class="auto-style4">
                                <asp:TextBox ID="Applicant_Contact" runat="server" autocomplete="off" MaxLength="10" onkeypress="NumberOnly()" onkeyup="validatePhoneNumber()" class="form-control" Width="200px" ValidationGroup="group" />
                                <div id="error" style="color: red;"></div>
                            </td>
                            <td class="div-errorcenter" style="margin-bottom: 10px;">
                                <%--<div id="error" style="color: red;"></div>--%>
                            </td>
                            <td class="auto-style2">d) E-Mail ID</td>
                            <td style="padding-left: 10px; text-align: center; width: 200px;">
                                <asp:TextBox ID="Applicant_Email" runat="server" autocomplete="off" onkeyup="validateEmail(this.value)" class="form-control" Width="200px" />
                                <span id="error-message" style="color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">e) Social Category</td>
                            <td style="padding-left: 10px; text-align: center;" class="auto-style4">
                                <asp:DropDownList ID="Applicant_caste" runat="server" class="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="Applicant_caste_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td></td>
                            <td class="auto-style2">f) Gender</td>
                            <td style="padding-left: 10px; text-align: center;">
                                <asp:DropDownList ID="Applicant_Gender" runat="server" TabIndex="1" AutoPostBack="true" class="form-control" Width="200px" OnSelectedIndexChanged="Applicant_Gender_SelectedIndexChanged">
                                    <asp:ListItem Text="--Select--" Value="0" />
                                    <asp:ListItem Text="Male" Value="1" />
                                    <asp:ListItem Text="Female" Value="2" />
                                </asp:DropDownList></td>
                        </tr>

                        <tr>

                            <td class="auto-style3">g)Differently Abled:</td>
                            <td style="padding-left: 40px;">
                                <asp:RadioButtonList ID="Differently_able" Font-Bold="false" runat="server" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="0" style="margin-right: 10px;" />
                                    <asp:ListItem Text="No" Value="1" />
                                </asp:RadioButtonList>
                                <td></td>
                                <td class="auto-style3">h) Investment (in lakhs)</td>
                                <td style="padding-left: 10px; text-align: center;" class="auto-style4">
                                    <asp:TextBox ID="Applicant_Investment" runat="server" autocomplete="off" AutoPostBack="true" onkeypress="NumberOnly()" class="form-control" Width="200px" OnTextChanged="Applicant_Investment_TextChanged" /></td>

                            </td>

                        </tr>

                        <tr style="padding-bottom: 10px">
                            <td class="auto-style2">j) Employment</td>
                            <td style="padding-left: 10px; text-align: center; width: 200px">
                                <asp:TextBox ID="Applicant_Employees" runat="server" autocomplete="off" onkeypress="NumberOnly()" class="form-control" Width="200px" /></td>
                            <td></td>
                            <td class="auto-style3">i) Line Of Activity</td>
                            <td style="padding-left: 10px; text-align: center;" class="auto-style4">
                                <asp:DropDownList ID="sector_dropdown" runat="server" TabIndex="1" class="form-control" Width="200px" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">k) Enterprise Sector</td>
                            <td style="padding-left: 10px; text-align: center;">
                                <asp:DropDownList ID="Enterprise_Sector" runat="server" TabIndex="1" class="form-control" Width="200px">
                                    <asp:ListItem Text="--Select--" Value="0" />
                                    <asp:ListItem Text="MANUFACTURING" Value="1" />
                                    <asp:ListItem Text="SERVICE" Value="2" />
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <table>
                        <tr id="trmsmeqsn" visible="false" runat="server">
                            <td style="width: 450px">
                                <div style="padding-top: 10px">
                                    <label class="div-Content">
                                        &nbsp;&nbsp;&nbsp;
                                        4.1)Whether Unit Registered in Industry Catalogue :</label>
                                </div>
                            </td>
                            <td style="width: 200px" class="div-contentcenter">
                                <div style="padding-left: 10px; padding-top: 10px">
                                    <asp:RadioButtonList ID="rblMSMEreg" runat="server" AutoPostBack="true" Font-Bold="false" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMSMEreg_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:Label ID="lblnomsmeunits" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trmsmeunits" visible="false" runat="server">
                            <td>
                                <label class="div-Content">&nbsp;&nbsp;&nbsp; 4.2) Please Map MSME Unit </label>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddlmapunits" runat="server" AutoPostBack="true" class="form-control" Width="200px" />
                            </td>
                        </tr>
                        <tr id="trMSMEmap" visible="false" runat="server">
                            <td style="padding-left: 130px" colspan="2">
                                <asp:LinkButton runat="server" ID="linkMSMECatlg" ForeColor="DarkGreen" Font-Bold="true" Text="Click here to Share Industry Catalogue link to Applicant" OnClick="linkMSMECatlg_Click"></asp:LinkButton>

                            </td>

                        </tr>
                    </table>
                </div>
                <div class="row">
                    <table>
                        <tr>
                            <td>
                                <label class="div-Content">5. Whether Line of Activity falls under ODOP :</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="LineOfActivity" runat="server" Font-Bold="false" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="LineOfActivity_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>

                        <tr id="trodopexport" runat="server" visible="false">
                            <td>
                                <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5a. Whether interested to export</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="rdodpexport" runat="server" Font-Bold="false" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdodpexport_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr id="trodoplink" visible="false" runat="server">
                            <td style="padding-left: 130px" colspan="2">
                                <asp:LinkButton runat="server" ID="lnkodop" ForeColor="DarkGreen" Font-Bold="true" Text="Click here to send DGFT link to the applicant" OnClick="lnkodop_Click"></asp:LinkButton>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">6. Whether the unit is Sick :</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="rblsick" runat="server" Font-Bold="false" Font-Size="15px" TabIndex="1" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblsick_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <label class="div-Content">7. Whether unit established under PMEGP :</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="rblPMEGP" runat="server" Font-Size="15px" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">8. Enter PAN Card Details</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter">
                                    <asp:TextBox ID="txtPAN" runat="server" Width="200px" onpaste="return false" onblur="fnValidatePAN(this);" Class="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">9. Whether any Grievance identified :</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter">
                                    <asp:RadioButtonList ID="Grievance_Identified" Enabled="true" runat="server" Font-Bold="false" Font-Size="15px" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Grievance_Identified_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 30px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr id="Grievance_Details_TXT_BOX" runat="server" visible="false">
                            <td>
                                <label class="div-Content">10. Details of the Grievance :</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <div class="div-contentcenter" style="margin-right: 105px;">
                                    <asp:TextBox ID="Grievance_Details" runat="server" autocomplete="off" oninput="validateInputName(this)" Width="200px" class="form-control" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="Grievance_Type_Block" runat="server" visible="false">
                    <div class="row">
                        <table>
                            <tr>
                                <td>
                                    <div id="Broad_Grievance" runat="server" visible="false">
                                        <label class="div-Content-NEW">10. Broad Type of Grievance :</label>
                                    </div>
                                    <div id="Broad_Guidance" runat="server" visible="false">
                                        <label class="div-Content-NEW">10. Broad Type of Guidance :</label>
                                    </div>
                                </td>
                                <td style="padding-left: 0px; font-size: 17px">
                                    <div>
                                        <%-- <asp:CheckBoxList ID="TypeOfGrievance" runat="server" AutoPostBack="true" CssClass="checkbox-list" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="TypeOfGrievance_SelectedIndexChanged" Visible="false"></asp:CheckBoxList>--%>
                                        <%--<label>1.Department Implemented Schemes&nbsp;&nbsp;&nbsp; 2.Marketing &nbsp;&nbsp; 3. Financial&nbsp;&nbsp;&nbsp;&nbsp;4. Land&nbsp;&nbsp;&nbsp;&nbsp; 5. Others </label>--%>
                                        <asp:RadioButtonList ID="rdboardgrivance" Font-Bold="true" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Vertical" RepeatColumns="5" OnSelectedIndexChanged="rdboardgrivance_SelectedIndexChanged" CssClass="auto-style10">
                                            <asp:ListItem Text="1.Department Implemented Schemes" Value="0" />
                                            <asp:ListItem Text="2.Marketing" Value="1" style="padding-left: 20px" />
                                            <asp:ListItem Text="3.Financial" Value="2" style="padding-left: 10px" />
                                            <asp:ListItem Text="4.Land" Value="3" style="padding-left: 20px" />
                                            <asp:ListItem Text="5.Others" Value="4" style="padding-left: 20px" />
                                        </asp:RadioButtonList>

                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <!---------------------------------------- Technical Block -------------------------------------------------------->
                    <div class="row" style="padding-left: 80px">
                        <label runat="server" id="lbl3" visible="false" style="font-size: 20px; font-weight: bold;">1.</label><asp:CheckBox ID="chkTechnical" Font-Size="20px" Font-Bold="true" Text="Department Implemented Schemes" runat="server" AutoPostBack="true" OnCheckedChanged="chkTechnical_CheckedChanged" Visible="false" />
                    </div>
                    <div class="row" id="Techblock" runat="server" visible="false">
                        <div class="row" id="Technical_block" runat="server" visible="false">
                            <div style="padding-left: 40px;">
                                <table>
                                    <tr id="Trdepartmentissues" runat="server" visible="true"
                                        style="padding-left: 35px; padding-top: 15px">
                                        <td style="padding-left: 85px;">
                                            <label>Details of the Grievance :</label>
                                        </td>
                                        <td style="padding-left: 35px;">
                                            <div class="div-contentcenter" style="margin-right: 105px;">
                                                <asp:TextBox ID="txtdepartmentissues" TextMode="MultiLine" runat="server" autocomplete="off" oninput="validateInputName(this)" Width="200px" class="form-control" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 85px;" class="auto-style11">a)Select Type of Schemes </td>
                                        <td class="auto-style12">
                                            <asp:RadioButtonList ID="rblTechnSchms" Font-Bold="false" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" RepeatColumns="5" OnSelectedIndexChanged="rblTechnSchms_SelectedIndexChanged" CssClass="auto-style10">
                                                <asp:ListItem Text="TSIPASS" Value="0" />
                                                <asp:ListItem Text="Incentives" Value="1" style="padding-left: 20px" />
                                                <asp:ListItem Text="Raw-Material" Value="2" style="padding-left: 10px" />
                                                <asp:ListItem Text="MSEFC" Value="3" style="padding-left: 20px" />
                                                <asp:ListItem Text="PMEGP" Value="4" style="padding-left: 20px" />
                                                <asp:ListItem Text="PMFME" Value="5" />
                                                <asp:ListItem Text="Udyam Registration" Value="6" style="padding-left: 20px" />
                                                <asp:ListItem Text="IE's/IL's" Value="7" style="padding-left: 12px" />
                                                <asp:ListItem Text="Others" Value="8" style="padding-left: 20px" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>

                                    <tr style="padding-left: 15px; padding-top: 15px" id="trtechissue" visible="false" runat="server">
                                        <td style="padding-left: 15px;" class="auto-style14">
                                            <label id="lbltechgrv" runat="server" visible="true" class="auto-style16">&nbsp; a-1. Select Issue related to:</label>
                                            <%--                                    <label id="lbltechgdnc" runat="server" visible="false" class="div-Content-NEW">a) Technical Type of Guidance related to:</label>--%>
                                    
                                        </td>
                                        <td style="padding-left: 32px;">
                                            <asp:RadioButtonList ID="TechnicalType_Grievance" Font-Bold="false" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="TechnicalType_Grievance_SelectedIndexChanged">
                                                <asp:ListItem Text="S/W Related" Value="0" />
                                                <asp:ListItem Text="Line Departments Related" Value="1" />
                                                <asp:ListItem Text="Others" Value="2" />
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr style="padding-left: 15px; padding-top: 15px" id="trincentives" visible="false" runat="server">
                                        <td style="padding-left: 15px;" class="auto-style14">
                                            <label id="Label1" runat="server" visible="true" class="auto-style16">&nbsp; a-1. Select Issue related to:</label>
                                            <%--                                    <label id="lbltechgdnc" runat="server" visible="false" class="div-Content-NEW">a) Technical Type of Guidance related to:</label>--%>
                                    
                                        </td>
                                        <td style="padding-left: 32px;">
                                            <asp:RadioButtonList ID="rdincentives" Font-Bold="false" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdincentives_SelectedIndexChanged">
                                                <asp:ListItem Text="S/W Related" Value="0" />
                                                <asp:ListItem Text="Sanction Pending" Value="1" />
                                                <asp:ListItem Text="Release Pending" Value="2" />
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr style="padding-left: 15px; padding-top: 15px" id="trRawmaterial" visible="false" runat="server">
                                        <td style="padding-left: 15px;" class="auto-style14">
                                            <label id="Label2" runat="server" visible="true" class="auto-style16">&nbsp; a-1. Select Issue related to:</label>
                                            <%--                                    <label id="lbltechgdnc" runat="server" visible="false" class="div-Content-NEW">a) Technical Type of Guidance related to:</label>--%>
                                    
                                        </td>
                                        <td style="padding-left: 32px;">
                                            <asp:RadioButtonList ID="rdrawmaterial" Font-Bold="false" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdrawmaterial_SelectedIndexChanged">
                                                <asp:ListItem Text="S/W Related" Value="0" />
                                                <asp:ListItem Text="Application Status" Value="1" />
                                            </asp:RadioButtonList></td>
                                    </tr>

                                    <tr id="trtechschmsothrs" runat="server" visible="false">
                                        <td style="padding-left: 65px; width: 340px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a-1. Please Enter Other Scheme Issue:

                                        </td>
                                        <td style="padding-left: 10px">
                                            <asp:TextBox ID="txttechschmsothrs" TextMode="MultiLine" runat="server" oninput="validateInputText(this)" class="form-control" Width="350px" />
                                        </td>

                                    </tr>

                                </table>
                            </div>
                            <div id="Line_department_block" runat="server" visible="false" style="padding-left: 65px;">
                                <div>
                                    <table>
                                        <tr visible="true" runat="server">
                                            <td class="auto-style13">
                                                <label id="lbltechgrvA2" runat="server" visible="false" class="div-Content-NEW">a-2. Please Select Line Department issue type</label>
                                                <label id="lbltechgdncA2" runat="server" visible="false" class="div-Content-NEW">a-2. Please Select Line Department issue type</label>
                                            </td>
                                            <td style="padding-left: 10px">
                                                <asp:DropDownList ID="ddlLineDepartment" Width="300px" Font-Size="15px" runat="server" TabIndex="1" class="form-control" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row" id="Financial_Departmental_Issues" runat="server" visible="false">
                                <p runat="server" style="font-size: 15px; padding-left: 130px;">&nbsp;&nbsp; a-1. Issues Related to Delayed Payments:</p>
                                <div style="padding-left: 80px;">
                                    <div>
                                        <table visible="false" runat="server">

                                            <tr>
                                                <td>
                                                    <label class="div-Content">i. Types of Issues related to Department: </label>
                                                </td>
                                                <td>
                                                    <div class="div-contentcenter" style="padding-left: 50px;">
                                                        <asp:RadioButtonList ID="department_issues_type" Font-Bold="false" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="department_issues_type_SelectedIndexChanged">
                                                            <asp:ListItem Text="Incentive" Value="0" />
                                                            <asp:ListItem Text="Delayed Payments" Value="1" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="MSEFC_Case_Filed_Yes" runat="server" visible="true">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">i. Whether Unit filed case under MSEFC :</label></td>
                                                <td>
                                                    <div class="div-contentcenter" style="padding-left: 50px;">
                                                        <asp:RadioButtonList ID="MSEFCCase_Filed" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="MSEFCCase_Filed_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <asp:ListItem Text="No" Value="1" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="CaseDetails" runat="server" visible="false">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">ii. Please Enter Case Details here :</label></td>
                                                    <td>
                                                        <div class="div-contentcenter" style="padding-left: 90px;">
                                                            <asp:TextBox ID="MSEFC_Case_Details" runat="server" Width="350px" TextMode="MultiLine" class="form-control" Height="40px" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="MSEFC_Case_Filed_No" runat="server" visible="false">
                                            <div id="Facilitation_Council_Block" runat="server" style="font-size: 15px; padding-left: 60px; padding-right: 50px;">
                                                <asp:BulletedList ID="BulletedList4" runat="server" BulletStyle="Disc" ForeColor="Brown">
                                                    <asp:ListItem Text="Eligibility: Unit may file the case after 45 days of delayed payment" />
                                                    <asp:ListItem Text="Checklist: Bills/work order for which payment not received, UAM" />
                                                    <asp:ListItem Text="Benefits: Clearance in 90 days" />
                                                    <asp:ListItem Text="Very low registration fees of Rs. 1000" />
                                                    <asp:ListItem Text="Case can be self-advocated" />
                                                    <asp:ListItem Text="If payment is not cleared in 3 months from the issue MSEFC order, applicant can approach the Collector and claim under revenue recovery act." />
                                                </asp:BulletedList>
                                            </div>
                                            <div>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iii. Whether Awareness on Facilitation Council is given :</label></td>
                                                        <td>
                                                            <div class="div-contentcenter" style="padding-left: 50px;">
                                                                <asp:RadioButtonList ID="MSEFCCase_Filed_No" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="MSEFCCase_Filed_No_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trmsefc" visible="false" runat="server">
                                                        <td style="padding-left: 130px" colspan="2">
                                                            <asp:LinkButton runat="server" ID="lnkmsefc" ForeColor="DarkGreen" Font-Bold="true" Text="Click here to send Esamadhan link to the applicant" OnClick="lnkmsefc_Click"></asp:LinkButton>

                                                        </td>

                                                    </tr>
                                                </table>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div id="Technical_Others_TXT_BOX" runat="server" visible="false" style="padding-left: 65px;">
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <label id="lbltechgrvA3" runat="server" visible="false" class="div-Content-NEW">a-2. Please Enter Other Issue</label>
                                                <label id="lbltechgdncA3" runat="server" visible="false" class="div-Content-NEW">a-2. Please Enter Other Issue</label>

                                            </td>
                                            <td style="padding-left: 30px">
                                                <asp:TextBox ID="Technical_Others" TextMode="MultiLine" runat="server" oninput="validateInputText(this)" class="form-control" Width="350px" /></td>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="div-contentcenter" style="padding-left: 130px; padding-bottom: 10px">
                            <asp:Label ID="lbltchNA" Visible="false" ForeColor="DarkViolet" runat="server" Font-Size="18px" Text="Not Applicable" Font-Bold="false"></asp:Label>

                        </div>

                        <div class="div-contentcenter" style="padding-left: 130px;">
                            <asp:Label ID="lblmarketing" Visible="false" ForeColor="RoyalBlue" runat="server" Font-Size="18px" Text="Please Explain about 2.Marketing related ecommerce platforms and other govt schemes to the applicant if applicable" Font-Bold="false"></asp:Label>
                        </div>

                    </div>

                    <!---------------------------------------- Marketing Block -------------------------------------------------------->
                    <div class="row" style="padding-left: 80px">
                        <label style="font-size: 20px; font-weight: bold;">2.</label><asp:CheckBox ID="chkMarketing" Font-Size="20px" Font-Bold="true" Text="Marketing" runat="server" AutoPostBack="true" Visible="true" OnCheckedChanged="chkMarketing_CheckedChanged" />
                    </div>

                    <div class="row" id="MarketingTypes" runat="server" visible="false">
                        <div class="row">
                            <table>
                                <tr id="trmarketing" runat="server" visible="false"
                                    style="padding-left: 15px; padding-top: 15px">
                                    <td style="padding-left: 85px;">
                                        <label class="div-Content">Details of the Grievance :</label>
                                    </td>
                                    <td style="padding-left: 80px;">
                                        <div class="div-contentcenter" style="margin-right: 105px;">
                                            <asp:TextBox ID="txtmarketing" runat="server" autocomplete="off" TextMode="MultiLine" oninput="validateInputName(this)" Width="200px" class="form-control" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <label id="lblmrkgrv" runat="server" visible="false" class="div-Content" style="padding-left: 150px;">Please select Marketing Grievance type :</label>
                                        <label id="lblmrkgdnc" runat="server" visible="false" class="div-Content" style="padding-left: 150px;">Please select Marketing Guidance type :</label></td>

                                    <td>
                                        <asp:CheckBoxList ID="Marketing_Types" runat="server" Font-Size="15px" class="form-control" AutoPostBack="true" Width="350px" Visible="false" OnSelectedIndexChanged="Marketing_Types_SelectedIndexChanged"></asp:CheckBoxList></td>
                                </tr>
                            </table>

                        </div>

                        <div class="div-contentcenter" style="padding-left: 115px">
                            <asp:CheckBox ID="chkecommrce" Visible="false" ForeColor="DarkViolet" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="E-Commerce Platforms" Font-Bold="false" OnCheckedChanged="chkecommrce_CheckedChanged"></asp:CheckBox>

                        </div>
                    </div>
                    <div id="Marketing_BLOCK_OFF" runat="server">
                        <div id="Grievance_Identified_Marketing_ECOMMERCE" runat="server" visible="false">
                            <div class="row">
                                <label class="div-Content" style="padding-left: 150px;">a-1. Whether Unit Onboarded onto below e-commerce platforms </label>
                            </div>
                            <div class="row" runat="server" id="divmeeshorbl" style="padding-left: 145px">
                                <table>
                                    <tr>
                                        <td style="width: 150px">
                                            <label style="font-size: 15px; color: blue;">1.Meesho</label></td>
                                        <td>
                                            <asp:RadioButtonList ID="rblMeesho" Font-Size="15px" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMeesho_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="0" />
                                                <asp:ListItem Text="No" Value="1" />
                                                <asp:ListItem Text="NA" Value="2" />
                                            </asp:RadioButtonList></td>
                                    </tr>
                                </table>
                            </div>
                            <%-- <div class="row">
                                <div style="padding-left: 305px; font-weight: bold; font-size: 22px;">
                                    <div id="PlatformTablePlaceholder" runat="server"></div>
                                </div>
                            </div>--%>
                            <div>
                                <div class="row">
                                    <div class="row" id="Meesho_Details" runat="server" visible="false">
                                        <div>
                                            <label class="div-Content" style="padding-left: 180px">Please Enter Meesho Platform Details : </label>
                                            <div style="padding-left: 120px">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">&nbsp; i. Onboarded with reference of DIC officer</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblmeeshoofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">&nbsp; ii. Onboarded after attending the camps conducted</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblMSaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMSaftrCamps_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trMScampdate" runat="server" visible="false">
                                                        <td>
                                                            <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ii-a. Date of camp attended<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtMScampdate" runat="server" autocomplete="off" class="datepicker form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">&nbsp; iii. Unique ID provided by Meesho Platform<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="Meesho_Unique_ID" runat="server" autocomplete="off" class="form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">&nbsp; iv. Date of Registration for Meesho Platform<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <input type="text" id="Meesho_Registration_Date" autocomplete="off" runat="server" maxlength="10" class=" datepicker form-control" />
                                                                <%--<cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="Meesho_Registration_Date" Format="MM/dd/yyyy"></cc1:CalendarExtender>--%>

                                                                <%--<asp:TextBox ID="Meesho_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">&nbsp; v. No. of Transactions/Queries (approx.)<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtmeeshocount" runat="server" autocomplete="off" class="form-control" onkeypress="NumberOnly()" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">&nbsp; vi. Value of Transactions (in lakhs approx.)<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtmeeshovalue" autocomplete="off" runat="server" MaxLength="10" class="form-control" onkeypress="NumberOnly()" />
                                                                <%--<cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="Meesho_Registration_Date" Format="MM/dd/yyyy"></cc1:CalendarExtender>--%>

                                                                <%--<asp:TextBox ID="Meesho_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="Meesho_Details_NO" runat="server" visible="false">
                                        <div class="row">
                                            <label class="div-Content" style="padding-left: 150px; font-size: 15px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Meesho Benefits:</label>
                                        </div>
                                        <div class="row">
                                            <div style="padding-left: 190px; font-size: 20px;">
                                                <div class="div-contentcenter">
                                                    <asp:CheckBoxList ID="Meesho_Awareness_No_List" ForeColor="Brown" Font-Bold="false" runat="server" TabIndex="1" RepeatDirection="vertical"></asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="padding-left: 130px">
                                            <table>

                                                <tr>
                                                    <td>
                                                        <label class="div-Content">i. Is Awareness provided about the Meesho Platform :</label>
                                                    </td>
                                                    <td style="padding-left: 25px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="Meesho_NO" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" Enabled="false" RepeatDirection="Horizontal" OnSelectedIndexChanged="Meesho_NO_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <%--<asp:ListItem Text="No" Value="1" />--%>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div id="Meesho_Awareness_Yes" runat="server" visible="false">
                                        <div class="row" style="padding-left: 130px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">ii. Whether unit is interested to onBoard onto Meesho Platform :</label>
                                                    </td>
                                                    <td style="padding-left: 20px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="rblMSintrsted" runat="server" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblMSintrsted_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <asp:ListItem Text="No" Value="1" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="padding-left: 180px; font-size: 15px;" id="Div4" runat="server" visible="false">
                                            <asp:LinkButton runat="server" ID="LinkMeesho" ForeColor="DarkGreen" Font-Bold="true" Text="iii. Click To Send Link to the Applicant about MEESHO Platform" OnClick="LinkMeesho_Click"></asp:LinkButton>
                                            <%--                                                        "window.open('https://www.meesho.com/', 'NewWindow', 'width=1200,height=600');--%>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="divjustdialrbl" style="padding-left: 160px; padding-top: 15px;">
                                        <table>
                                            <tr>
                                                <td style="width: 150px">
                                                    <label style="font-size: 15px; color: blue;">2.Just-Dial</label></td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblJustDial" Font-Size="15px" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblJustDial_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                        <asp:ListItem Text="NA" Value="2" />
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row" id="Just_Dial_Details" runat="server" visible="false">
                                        <div>
                                            <label class="div-Content" style="padding-left: 180px">Please Enter Just-Dial Platform Details : </label>
                                            <div style="padding-left: 120px">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">i. Onboarded with reference of DIC officer:</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rbljustdialofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">ii. Onboarded after attending the camps conducted:</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblJDaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblJDaftrCamps_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                    <tr id="trJDcampdate" runat="server" visible="false">
                                                        <td>
                                                            <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ii-a. Date of camp attended:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtJDcampdate" runat="server" autocomplete="off" class="datepicker form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iii. Unique ID provided by Just-Dial Platform:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="Just_Dial_ID" runat="server" autocomplete="off" class="form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iv. Date of Registration for Just-Dial Platform:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <input type="text" id="Just_Dial_Registration_Date" autocomplete="off" runat="server" maxlength="10" class="datepicker form-control" />
                                                                <%--<asp:TextBox ID="Just_Dial_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">v. No. of Transactions/Queries (approx.):<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtjstdialcount" runat="server" autocomplete="off" class="form-control" onkeypress="NumberOnly()" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">vi. Value of Transactions (in lakhs approx.):<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtjstdialvalue" autocomplete="off" runat="server" MaxLength="10" class="form-control" onkeypress="NumberOnly()" />
                                                                <%--<cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="Meesho_Registration_Date" Format="MM/dd/yyyy"></cc1:CalendarExtender>--%>

                                                                <%--<asp:TextBox ID="Meesho_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="Just_Dial_NO" runat="server" visible="false">
                                        <div class="row">
                                            <label class="div-Content" style="padding-left: 180px; font-size: 15px;">Just Dial Benefits:</label>
                                        </div>
                                        <div class="row">
                                            <div style="padding-left: 180px; font-size: 15px;">
                                                <div class="div-contentcenter">
                                                    <asp:CheckBoxList ID="Just_Dial_Awareness_No_List" ForeColor="Brown" runat="server" Font-Bold="false" TabIndex="1" RepeatDirection="vertical"></asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="padding-left: 130px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">i. Is Awareness provided about the Just Dial Platform :</label>
                                                    </td>
                                                    <td style="padding-left: 25px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="JustDialNOBtn" runat="server" AutoPostBack="true" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="JustDialNOBtn_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <%--  <asp:ListItem Text="No" Value="1" />--%>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div id="Just_Dial_Awareness_Yes" runat="server" visible="false">
                                        <div class="row" style="padding-left: 130px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">ii. Whether unit is interested to onBoard onto Just Dial Platform:</label>
                                                    </td>
                                                    <td style="padding-left: 25px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="rblJDintrsted" runat="server" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblJDintrsted_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <asp:ListItem Text="No" Value="1" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="padding-left: 180px; font-size: 15px;" id="Div5" runat="server" visible="false">
                                            <asp:LinkButton runat="server" ID="LinkJustdial" ForeColor="DarkGreen" Font-Bold="true" Text="iii. Click To Send Link to the Applicant about JUST DIAL Platform" OnClick="LinkJustdial_Click"></asp:LinkButton>
                                            <%--                                                        window.open('https://www.justdial.com/', 'NewWindow', 'width=1200,height=600');--%>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="divTSGlobalrbl" style="padding-left: 160px; padding-top: 15px;">
                                        <table>
                                            <tr>
                                                <td style="width: 150px">
                                                    <label style="font-size: 15px; color: blue;">3.TS-Global Linker</label></td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblTSGlobal" Font-Size="15px" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblTSGlobal_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                        <asp:ListItem Text="NA" Value="2" />
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row" id="TS_Global_Details" runat="server" visible="false">
                                        <div>
                                            <label class="div-Content" style="padding-left: 180px">Please Enter TS-Global Linker Platform Details: </label>
                                            <div style="padding-left: 130px">
                                                <table>
                                                    <tr>
                                                        <td class="auto-style7">
                                                            <label class="div-Content">i. Onboarded with reference of DIC officer:</label>
                                                        </td>
                                                        <td style="padding-left: 50px;" class="auto-style7">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblTSGofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">ii. Onboarded after attending the camps conducted:</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblTSGaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblTSGaftrCamps_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trTSGcampdate" runat="server" visible="false">
                                                        <td>
                                                            <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ii-a. Date of camp attended: <span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtTSGcampdate" runat="server" autocomplete="off" class="datepicker form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iii. Unique ID provided by TS-Global Linker Platform:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="TS_Global_UNIQUE_ID" runat="server" autocomplete="off" class="form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iv. Date of Registration for TS-Global Linker Platform:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <input type="text" id="TS_Global_Registration_Date" autocomplete="off" runat="server" maxlength="10" class="datepicker form-control" />
                                                                <%--<asp:TextBox ID="TS_Global_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">v.No. of Transactions/Queries (approx.):<span class="required-field">*</span>&nbsp; </label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txttsglobalcount" autocomplete="off" runat="server" MaxLength="10" onkeypress="NumberOnly()" class="form-control" />
                                                                <%--<asp:TextBox ID="TS_Global_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">vi. Value of Transactions (in lakhs approx.):<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txttsglobalvalue" autocomplete="off" runat="server" MaxLength="10" onkeypress="NumberOnly()" class=" form-control" />
                                                                <%--<asp:TextBox ID="TS_Global_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="TS_Global_No" runat="server" visible="false">
                                        <div class="row">
                                            <label class="div-Content" style="padding-left: 190px; font-size: 15px;">TS-Global Linker Benefits:</label>
                                        </div>
                                        <div class="row">
                                            <div style="padding-left: 190px; font-size: 15px;">
                                                <div class="div-contentcenter">
                                                    <asp:CheckBoxList ID="TS_GLOBAL_DETAILS_LIST" runat="server" Font-Bold="false" TabIndex="1" RepeatDirection="vertical" ForeColor="Brown"></asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="padding-left: 130px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">i. Is Awareness provided about the TS-Global Linker Platform :</label>
                                                    </td>
                                                    <td style="padding-left: 25px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="TS_Global_NO_BTN" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="TS_Global_NO_BTN_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <%--<asp:ListItem Text="No" Value="1" />--%>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div id="TS_GLOBAL_Awareness_Yes" runat="server" visible="false">
                                        <div class="row" style="padding-left: 130px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">ii. Whether unit is interested to onBoard onto TS-Global Linker Platform:</label>
                                                    </td>
                                                    <td style="padding-left: 50px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="rblTSGintrsted" runat="server" Font-Bold="false" TabIndex="1" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblTSGintrsted_SelectedIndexChanged" Style="height: 25px">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <asp:ListItem Text="No" Value="1" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="padding-left: 180px; font-size: 15px;" id="Div6" runat="server" visible="false">
                                            <asp:LinkButton runat="server" ID="LinkTSGlobal" ForeColor="DarkGreen" Font-Bold="true" Text="iii. Click To Send Link to the Applicant about TS-GLOBAL LINKER Platform" OnClick="LinkTSGlobal_Click"></asp:LinkButton>
                                            <%--                                                        window.open('https://ts-msme.globallinker.com/', 'NewWindow', 'width=1200,height=600');--%>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="divwallmartrbl" style="padding-left: 160px; padding-top: 15px;">
                                        <table>
                                            <tr>
                                                <td style="width: 150px">
                                                    <label style="font-size: 15px; color: blue;">4.WalMart Vriddi</label></td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblWallmart" Font-Size="15px" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblWallmart_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                        <asp:ListItem Text="NA" Value="2" />
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row" id="Walmart_Vriddi_Details" runat="server" visible="false">
                                        <div>
                                            <label class="div-Content" style="padding-left: 180px;">Please Enter Walmart Vriddi Platform Details: </label>
                                            <div style="padding-left: 130px;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">i. Onboarded with reference of DIC officer:</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblwallmartofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">ii. Onboarded after attending the camps conducted:</label>
                                                        </td>
                                                        <td style="padding-left: 50px;">
                                                            <div class="div-contentcenter">
                                                                <asp:RadioButtonList ID="rblWMVaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblWMVaftrCamps_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="0" />
                                                                    <asp:ListItem Text="No" Value="1" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="trWMVcampdate" runat="server" visible="false">
                                                        <td>
                                                            <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ii-a. Date of camp attended: <span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtWMVcampdate" runat="server" autocomplete="off" class="datepicker form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iii. Unique ID provided by Walmart Vriddi Platform:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="Walmart_Vriddi_UNIQUE_ID" runat="server" autocomplete="off" class="form-control" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">iv. Date of Registration for Walmart Vriddi Platform:<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <input type="text" id="Walmart_Vriddi_Registration_Date" autocomplete="off" runat="server" maxlength="10" class="datepicker form-control" />
                                                                <%--<asp:TextBox ID="Walmart_Vriddi_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">v.No. of Transactions/Queries (approx.):<span class="required-field">*</span>&nbsp; </label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtwallmartcount" autocomplete="off" runat="server" MaxLength="10" onkeypress="NumberOnly()" class="form-control" />
                                                                <%--<asp:TextBox ID="TS_Global_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label class="div-Content">vi. Value of Transactions (in lakhs approx.):<span class="required-field">*</span></label>
                                                        </td>
                                                        <td style="padding-left: 15px;">
                                                            <div class="div-contentcenter">
                                                                <asp:TextBox ID="txtwallmartvalue" autocomplete="off" runat="server" MaxLength="10" onkeypress="NumberOnly()" class="form-control" />
                                                                <%--<asp:TextBox ID="TS_Global_Registration_Date" autocomplete="off" runat="server" class="form-control"></asp:TextBox>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="Walmart_Vriddi_NO" runat="server" visible="false">

                                    <div class="row" runat="server" id="wlmrtbnfts">
                                        <label class="div-Content" style="padding-left: 180px; font-size: 15px;">Wallmart Vriddi Benefits:</label>
                                    </div>
                                    <div class="row" runat="server" id="wlmrtbnftslst">
                                        <div style="padding-left: 190px; font-size: 20px;">
                                            <div class="div-contentcenter">
                                                <asp:CheckBoxList ID="WALMART_VRIDDI_DETAILS_LIST" runat="server" Font-Bold="false" ForeColor="Brown" TabIndex="1" RepeatDirection="vertical"></asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-left: 130px" runat="server" id="wlmrtNorbl" visible="true">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">i. Is Awareness provided about the Walmart Vriddi Platform:</label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <div class="div-contentcenter">
                                                        <asp:RadioButtonList ID="Walmart_Vriddi_NO_Btn" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Walmart_Vriddi_NO_Btn_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <%-- <asp:ListItem Text="No" Value="1" />--%>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                    <div id="WALMART_VRIDDI_Awareness_Yes" runat="server" visible="false">
                                        <div class="row" style="padding-left: 130px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">ii. Whether unit is interested to onBoard onto Walmart Vriddi Platform:</label>
                                                    </td>
                                                    <td style="padding-left: 20px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="rblWMVintrsted" runat="server" Font-Bold="false" TabIndex="1" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblWMVintrsted_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <asp:ListItem Text="No" Value="1" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="padding-left: 180px; font-size: 15px;" id="Div7" runat="server" visible="false">
                                            <asp:LinkButton runat="server" ID="LinkWallmart" ForeColor="DarkGreen" Font-Bold="true" Text="iii. Click To Send Link to the Applicant about Walmart Vriddi Platform" OnClick="LinkWallmart_Click"></asp:LinkButton>
                                            <%--                                                    window.open('https://www.walmartvriddhi.org/', 'NewWindow', 'width=1200,height=600');--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="div-contentcenter" style="padding-left: 100px;">
                            <asp:CheckBox ID="chkOtherSchms" Style="padding-top: 15px" Visible="false" ForeColor="DarkViolet" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="Govt. Schemes" Font-Bold="false" OnCheckedChanged="chkOtherSchms_CheckedChanged"></asp:CheckBox>

                        </div>
                        <div id="Grievance_Identified_Marketing_Schemes" runat="server" visible="false">
                            <div class="row">
                                <label id="lblmrkgrvA2" runat="server" visible="false" class="div-Content" style="padding-left: 150px; padding-top: 15px;">a-2. Select whether the below Schemes are applicable to the Entrepreneur or not </label>
                            </div>
                            <div class="row">
                                <label id="lblmrkgdncA2" runat="server" visible="false" class="div-Content" style="padding-left: 150px; padding-top: 15px;">a-2. Select whether the below Schemes are applicable to the Entrepreneur or not </label>
                            </div>
                            <div class="row" id="divMAS" runat="server" visible="true">
                                <div style="padding-left: 150px; font-size: 15px; padding-top: 15px;">
                                    <div class="div-contentcenter">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkMAS" Visible="false" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="Marketing Assistance Scheme (NSIC)" Font-Bold="false" OnCheckedChanged="chkMAS_CheckedChanged"></asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label style="font-size: 15px; color: blue; font-weight: lighter">1. Marketing Assistance Scheme (NSIC)</label>
                                                </td>
                                                <td style="padding-left: 50px">
                                                    <asp:RadioButtonList ID="rblMAS" Visible="true" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Font-Bold="false" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMAS_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="NA" Value="1" />
                                                    </asp:RadioButtonList>

                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="SCHEME_MAS_BLOCK" runat="server" visible="false">
                                    <div style="font-size: 15px; padding-left: 160px; padding-right: 50px;">
                                        <%--                                    <p runat="server" style="font-size: 20px;">a-2a. Marketing Assistance Scheme (NSIC)</p>--%>
                                        <asp:BulletedList ID="BulletedList1" ForeColor="Brown" runat="server"></asp:BulletedList>
                                    </div>
                                    <div style="padding-left: 130px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">i. Is Awareness provided about the Marketing Assistance Scheme :</label>
                                                </td>
                                                <td style="padding-left: 60px;">
                                                    <div class="div-contentcenter">
                                                        <asp:RadioButtonList ID="rblMASawrns" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMASawrns_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <%-- <asp:ListItem Text="No" Value="1" />--%>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row">
                                    <div id="Div1" runat="server" visible="false">
                                        <div class="row" style="padding-left: 160px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label class="div-Content">ii. Whether unit is interested to know more about Marketing Assistance Scheme :</label>
                                                    </td>
                                                    <td style="padding-left: 20px;">
                                                        <div class="div-contentcenter">
                                                            <asp:RadioButtonList ID="rblMASintrsted" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMASintrsted_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="0" />
                                                                <asp:ListItem Text="No" Value="1" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="padding-left: 210px; font-size: 15px;" id="NSIC_LINK" runat="server" visible="false">
                                        <asp:LinkButton runat="server" ID="LinkMAS" ForeColor="DarkGreen" Font-Bold="true" Text="iii. Click To Send Link to the Applicant about NSIC" OnClick="LinkMAS_Click"></asp:LinkButton>
                                        <%-- window.open('https://www.nsic.co.in/schemes/MarketingAssistance', 'NewWindow', 'width=1200,height=600');--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="divPMS" runat="server" visible="true">
                                <div style="padding-left: 150px; padding-top: 15px; font-size: 15px;">
                                    <div class="div-contentcenter">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkPMS" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="Procurement and Marketing Support Scheme (P&MS)-(MSME)" Visible="false" Font-Bold="false" OnCheckedChanged="chkPMS_CheckedChanged"></asp:CheckBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label style="font-size: 15px; color: blue; font-weight: lighter">2. Procurement and Marketing Support Scheme (P&MS)-(MSME)</label></td>
                                                <td style="padding-left: 50px">
                                                    <asp:RadioButtonList ID="rblPMS" Visible="true" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Font-Bold="false" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblPMS_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="NA" Value="1" />
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="SCHEME_PMS_BLOCK" runat="server" visible="false">
                                    <div style="font-size: 15px; padding-left: 140px; padding-right: 50px;">
                                        <%--                                <p runat="server" style="font-size: 20px; font-weight: bold; text-decoration: underline;">a-2b.Procurement and Marketing Support Scheme (P&MS) – MSME</p>--%>
                                        <asp:BulletedList ID="BulletedList2" ForeColor="Brown" runat="server"></asp:BulletedList>
                                    </div>
                                    <div style="padding-left: 130px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">i. Is Awareness provided about Procurement and Marketing Support Scheme :</label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <div class="div-contentcenter">
                                                        <asp:RadioButtonList ID="rblPMSawrns" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblPMSawrns_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <%--<asp:ListItem Text="No" Value="1" />--%>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="Div2" runat="server" visible="false">
                                    <div class="row" style="padding-left: 160px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">ii. Whether unit is interested to know more about Marketing Support Scheme :</label>
                                                </td>
                                                <td style="padding-left: 30px;">
                                                    <div class="div-contentcenter">
                                                        <asp:RadioButtonList ID="rblPMSintrsted" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblPMSintrsted_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <asp:ListItem Text="No" Value="1" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="padding-left: 210px; font-size: 15px;" id="MSME_LINK" runat="server" visible="false">
                                        <asp:LinkButton runat="server" ID="LinkPMS" Font-Bold="true" ForeColor="DarkGreen" Text="iii. Click To Send Link to Applicant about MSME" OnClick="LinkPMS_Click"></asp:LinkButton>
                                        <%--                                    window.open('https://msme.gov.in/1-marketing-promotion-schemes', 'NewWindow', 'width=1200,height=600');--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="divSMAS" runat="server" visible="true">
                                <div style="padding-left: 150px; padding-top: 15px; font-size: 15px;">
                                    <div class="div-contentcenter">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox Visible="false" ID="chkSMAS" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="Special Marketing Assistance Scheme (SMAS) fro SC/ST Entrepreneurs (National SC-ST-Hub)" Font-Bold="false" OnCheckedChanged="chkSMAS_CheckedChanged"></asp:CheckBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label style="font-size: 15px; color: blue; font-weight: lighter">3. Special Marketing Assistance Scheme (SMAS) fro SC/ST Entrepreneurs (National SC-ST-Hub)</label>
                                                </td>
                                                <td style="padding-left: 50px">
                                                    <asp:RadioButtonList ID="rblSMAS" Visible="true" ForeColor="Blue" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Font-Bold="false" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSMAS_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="NA" Value="1" />
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="SCHEME_SMAS_BLOCK" runat="server" visible="false">
                                    <div style="font-size: 15px; padding-left: 140px; padding-right: 50px;">
                                        <%--                                <p runat="server" style="font-size: 20px; font-weight: bold; text-decoration: underline;" class="auto-style5">a-2c. Special marketing assistance scheme (SMAS) for SC/ST entrepreneurs (National SC-ST-HUB)</p>--%>
                                        <asp:BulletedList ID="BulletedList3" runat="server" ForeColor="Brown"></asp:BulletedList>
                                    </div>
                                    <div style="padding-left: 130px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">i. Is Awareness provided about Special marketing assistance scheme (SMAS) :</label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <div class="div-contentcenter">
                                                        <asp:RadioButtonList ID="rblSMASawrns" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSMASawrns_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <%--  <asp:ListItem Text="No" Value="1" />--%>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="Div3" runat="server" visible="false">
                                    <div class="row" style="padding-left: 160px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="div-Content">ii. Whether unit is interested to know more about Special marketing assistance scheme :</label>
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <div class="div-contentcenter">
                                                        <asp:RadioButtonList ID="rblSMASintrsted" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSMASintrsted_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" />
                                                            <asp:ListItem Text="No" Value="1" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="padding-left: 210px; font-size: 15px;" id="SMAS_LINK" runat="server" visible="false">
                                        <asp:LinkButton runat="server" ID="LinkSMAS" ForeColor="DarkGreen" Font-Bold="true" Text="iii. Click To Send Link to Applicant about SMAS" OnClick="LinkSMAS_Click"></asp:LinkButton>
                                        <%--  window.open('https://msme.gov.in/special-marketing-assistance-scheme', 'NewWindow', 'width=1200,height=600');--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="div-contentcenter" style="padding-left: 100px;">
                            <asp:CheckBox ID="chkmrkOthrs" Visible="false" ForeColor="DarkViolet" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Style="padding-top: 15px" Text="Others" Font-Bold="false" OnCheckedChanged="chkmrkOthrs_CheckedChanged"></asp:CheckBox>

                        </div>
                        <div class="row" id="Grievance_Identified_Marketing_Others" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label id="lblmrkgrvA3" runat="server" visible="false" class="div-Content-NEW" style="padding-left: 160px; padding-top: 15px;">a-3. Mention Other Marketing Grievance: </label>
                                        </div>
                                        <div class="row">
                                            <label id="lblmrkgdncA3" runat="server" visible="false" class="div-Content-NEW" style="padding-left: 160px; padding-top: 15px;">a-3. Mention Other Marketing Guidance: </label>
                                        </div>
                                    </td>
                                    <td>
                                        <div style="padding-left: 20px; padding-top: 15px;">
                                            <asp:TextBox ID="Marketing_Others_Text_Box" runat="server" TextMode="MultiLine" oninput="validateInputName(this)" Width="350px" class="form-control" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div class="div-contentcenter" style="padding-left: 130px">
                            <asp:Label ID="lblFinancial" Visible="false" ForeColor="RoyalBlue" runat="server" Style="text-decoration: blink; text-decoration-style: wavy" Font-Size="18px" Text="Please Explain about 3.Financial related Online platforms to applicant if applicable" Font-Bold="false"></asp:Label>

                        </div>
                    </div>


                    <!---------------------------------------- Financial Block -------------------------------------------------------->
                    <div class="row" style="padding-left: 80px">
                        <label runat="server" id="lbl2" visible="false" style="font-size: 20px; font-weight: bold;">3.</label><asp:CheckBox ID="chkFinancial" Font-Size="20px" Font-Bold="true" Text="Financial" runat="server" AutoPostBack="true" OnCheckedChanged="chkFinancial_CheckedChanged" Visible="false" />
                    </div>
                    <div class="row" id="FinancialTypes" runat="server" visible="false">
                        <table>
                            <tr id="trFinancial" runat="server" visible="true"
                                style="padding-left: 15px; padding-top: 15px">
                                <td style="padding-left: 65px;">
                                    <label id="lblfncgrv" runat="server" visible="true" class="div-Content" style="padding-left: 113px;">&nbsp;Details of the Grievance :</label>
                                    <label id="lblfncgdnc" runat="server" visible="true" class="div-Content" style="padding-left: 113px;">&nbsp;Details of the Guidance :</label>
                                    <%--<label class="div-Content">Details of the Grievance :</label>--%>
                                </td>
                                <td style="padding-left: 80px;">
                                    <div class="div-contentcenter" style="margin-right: 105px;">
                                        <asp:TextBox ID="txtFinancial" TextMode="MultiLine" runat="server" autocomplete="off" oninput="validateInputName(this)" Width="200px" class="form-control" />
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td>
                                    <%--<label id="lblfncgrv" runat="server" visible="false" class="div-Content" style="padding-left: 113px;">&nbsp;a) Please select Financial Grievance type :</label>--%>
                                    <%--<label id="lblfncgdnc" runat="server" visible="false" class="div-Content" style="padding-left: 113px;">&nbsp;a) Please select Financial Guidance type :</label>--%>

                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:DropDownList ID="Financial_Types" Visible="false" runat="server" class="form-control" AutoPostBack="true" Width="350px" Font-Size="15px" OnSelectedIndexChanged="Financial_Types_SelectedIndexChanged"></asp:DropDownList></td>
                            </tr>
                        </table>

                        <div class="div-contentcenter" style="padding-left: 115px">
                            <asp:CheckBox ID="chckonlineplatforms" Visible="false" ForeColor="DarkViolet" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="Online Platforms" Font-Bold="false" OnCheckedChanged="chckonlineplatforms_CheckedChanged"></asp:CheckBox>

                        </div>

                        <div id="Financial_Block_OFF" runat="server">
                            <div class="row" id="Online_Financial_Platforms_Block" runat="server" visible="false">
                                <p runat="server" style="font-size: 15px; padding-left: 145px;">a-2. Whether Unit OnBoarded onto below Online Platforms :</p>
                                <div class="div-Content" style="padding-left: 100px; padding-top: 15px;">
                                    <table>
                                        <tr>
                                            <td style="width: 180px">
                                                <label class="div-Content" style="color: blue; font-size: 15px;">1. Invoice Mart</label></td>
                                            <td>
                                                <asp:RadioButtonList ID="Invoice_Mart" ForeColor="blue" Font-Size="15px" runat="server" AutoPostBack="true" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Invoice_Mart_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                    <asp:ListItem Text="NA" Value="2" />
                                                </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="Invoice_Mart_No" runat="server" visible="false" style="padding-left: 120px;">
                                    <div id="divfactrong" runat="server" style="font-size: 15px; padding-left: 40px; padding-right: 50px;">
                                        <label class="div-Content" style="padding-left: 20px">Factoring:  </label>
                                        <asp:BulletedList ID="BulletedList5" runat="server" BulletStyle="Disc" ForeColor="Brown">
                                            <asp:ListItem Text="It enables suppliers to reduce the payment period for their goods/services" />
                                            <asp:ListItem Text="It does this by introducing a financier between the supplier and the corporate buyer" />
                                            <asp:ListItem Text="The financier finances the supplier against the invoice/bill of exchange raised on the corporate buyer for the goods/services provided by the supplier." />
                                        </asp:BulletedList>
                                    </div>
                                    <div id="divrevfactrong" runat="server" style="font-size: 15px; padding-left: 40px; padding-right: 50px;">
                                        <label class="div-Content" style="padding-left: 20px">InReverse Factoring:  </label>
                                        <asp:BulletedList ID="BulletedList6" runat="server" BulletStyle="Disc" ForeColor="Brown">
                                            <asp:ListItem Text="A buyer raises an invoice, as opposed to factoring in which a seller raises the invoice on the system" />
                                            <asp:ListItem Text="The financier finances the supplier against the invoice/bill of exchange raised on the corporate buyer for the goods/services provided by the supplier." />
                                        </asp:BulletedList>
                                    </div>
                                    <table>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1a. Whether awareness provided on Factoring and InReverse Factoring:</label>
                                            </td>
                                            <td style="padding-left: 18px;">
                                                <asp:RadioButtonList ID="rblIMawrns" runat="server" AutoPostBack="true" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIMawrns_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <%-- <asp:ListItem Text="No" Value="1" />--%>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <%--</table>
                                    <table>--%>
                                        <%--<tr>
                                            <td>
                                                <label class="div-Content">1b. Is Awareness provided about the Invoice Mart Platform :</label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="RadioButtonList20" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Walmart_Vriddi_NO_Btn_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>--%>

                                        <tr id="trIMrtonbord" runat="server" visible="false">
                                            <td>
                                                <label class="div-Content">1b.Whether unit is interested to onBoard onto Invoice Mart Platform :</label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblIMintrsted" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIMintrsted_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trIMrtonbordlink" runat="server" visible="false">
                                            <td>
                                                <div style="padding-left: 65px; font-size: 15px;" id="Div8" runat="server" visible="true">
                                                    <asp:LinkButton ID="LinkInvoice" runat="server" ForeColor="DarkGreen" Font-Bold="true" Text="1c. Click To Send Link to Applicant about Invoice Mart" OnClick="LinkInvoice_Click"></asp:LinkButton>
                                                    <%--                                        window.open('https://www.invoicemart.com', 'NewWindow', 'width=1200,height=600');--%>
                                                </div>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                                <div id="Invoice_Mart_Yes" runat="server" visible="false" style="padding-left: 120px;">
                                    <table>
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <label class="div-Content">1a. Onboarded with reference of DIC officer</label>
                                            </td>
                                            <td style="padding-left: 90px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblIMofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <label class="div-Content">1b. Onboarded after attending the camps conducted</label>
                                            </td>
                                            <td style="padding-left: 90px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblIMaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIMaftrCamps_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trIMcampdate" runat="server" visible="false">
                                            <td>
                                                <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date of camp attended<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="txtIMcampdate" Width="200px" runat="server" class="datepicker form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1c. Invoice Mart ID<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="InvoiceMartID" Width="200px" runat="server" class="form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1d. Invoice Mart Registration Date<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <input type="text" id="INVOICE_MART_Registration_DATE" autocomplete="off" runat="server" maxlength="10" width="200px" class="datepicker form-control" />
                                                    <%--<asp:TextBox ID="INVOICE_MART_Registration_DATE" runat="server" class="form-control" />--%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1e. No. of orders received<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="No_of_Orders_received_Invoice_Mart" Width="200px" onkeypress="NumberOnly()" runat="server" class="form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <label class="div-Content">1f. Value of orders received(in Lakhs)<span class="required-field">*</span></label></td>
                                            <td class="auto-style6">
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="Order_Value_Invoice_Mart" onkeypress="NumberOnly()" runat="server" class="form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1g. No. of Bills uploaded<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="No_of_Bills_Invoice_Mart" onkeypress="NumberOnly()" runat="server" class="form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1h. Value of Bills uploaded<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="Bills_Value_Invoice_Mart" onkeypress="NumberOnly()" runat="server" class="form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">1i. No. of Bills Sold<span class="required-field">*</span></label></td>
                                            <td>
                                                <div style="padding-left: 50px;">
                                                    <asp:TextBox ID="No_of_Bills_Sold_Invoice_Mart" onkeypress="NumberOnly()" runat="server" class="form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="div-Content" style="padding-left: 100px; padding-top: 15px;">
                                    <table>
                                        <tr>
                                            <td style="width: 180px">
                                                <label class="div-Content" style="color: blue; font-size: 15px;">2. NSE</label></td>
                                            <td>
                                                <asp:RadioButtonList ID="NSE" runat="server" Font-Size="15px" AutoPostBack="true" ForeColor="blue" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="NSE_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                    <asp:ListItem Text="NA" Value="2" />
                                                </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="NSE_No" runat="server" visible="false" style="padding-left: 120px;">
                                    <div id="div12" runat="server" style="font-size: 15px; padding-left: 40px; padding-right: 50px;">

                                        <asp:BulletedList ID="BulletedList7" runat="server" BulletStyle="Disc" ForeColor="Brown">
                                            <asp:ListItem Text="Comprehensive marketplace: NSE offers comprehensive coverage of the Indian capital markets across asset classes, including equity, fixed income and derivative securities. " />
                                            <asp:ListItem Text="Scale of operations: The scale and breadth of NSE's products and services help to attract additional participants to the exchange, which in turn results in more efficient price discovery." />
                                            <asp:ListItem Text="Visibility & Broadcast facility for corporate announcements: The best 5 buy and sell orders are displayed on the trading system and the total number of securities available for buying and selling is also displayed. This helps the investor to know the depth of the market. Further, corporate announcements, results, corporate actions etc. are also available on the trading system." />
                                            <asp:ListItem Text="Trade statistics for listed companies: Listed companies are provided with monthly trade statistics for all the securities of the company listed on the Exchange. " />
                                        </asp:BulletedList>
                                    </div>
                                    <table>

                                        <tr>
                                            <td>
                                                <label class="div-Content">2a. Awareness Provided on Listing</label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <asp:RadioButtonList ID="rblNSEawrns" runat="server" Font-Size="15px" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblNSEawrns_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <%--<asp:ListItem Text="No" Value="1" />--%>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr id="trNSEonbord" runat="server" visible="false">
                                            <td>
                                                <label class="div-Content">2b.Whether unit is interested to onBoard onto NSE Platform :</label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblNSEintrsted" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblNSEintrsted_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trNSEonbordlink" runat="server" visible="false">
                                            <td>
                                                <div style="padding-left: 65px; font-size: 15px;" id="Div9" runat="server" visible="true">
                                                    <asp:LinkButton runat="server" ID="LinkNSE" Font-Bold="true" ForeColor="DarkGreen" Text="2c. Click To Send Link to Applicant about NSE" OnClick="LinkNSE_Click"></asp:LinkButton>
                                                    <%--                                        window.open('https://www.nseindia.com', 'NewWindow', 'width=1200,height=600');--%>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="NSE_YES" runat="server" visible="false" style="padding-left: 120px;">
                                    <table>
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <label class="div-Content">2a. Onboarded with reference of DIC officer</label>
                                            </td>
                                            <td style="padding-left: 40px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblNSEofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <label class="div-Content">2b. Onboarded after attending the camps conducted</label>
                                            </td>
                                            <td style="padding-left: 40px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblNSEaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblNSEaftrCamps_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trNSEcampdate" runat="server" visible="false">
                                            <td>
                                                <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date of camp attended </label>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <div class="div-contentcenter">
                                                    <asp:TextBox ID="txtNSEcampdate" runat="server" autocomplete="off" class="datepicker form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">2c. Whether filed with NSE Platform</label>
                                            </td>
                                            <td style="padding-left: 40px;">
                                                <asp:RadioButtonList ID="rblNSEFiled" runat="server" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">2d. Whether Listed onto NSE Platform</label>
                                            </td>
                                            <td style="padding-left: 40px;">
                                                <asp:RadioButtonList ID="rblNSElisted" runat="server" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="div-Content">2d. Whether Undergoing Audit</label>
                                            </td>
                                            <td style="padding-left: 40px;">
                                                <asp:RadioButtonList ID="rblNSEAudit" runat="server" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <asp:ListItem Text="No" Value="1" />
                                                </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="div-Content" style="padding-left: 100px; padding-top: 15px;" visible="false">
                                    <table visable="false">
                                        <tr>
                                            <%-- <td style="width: 180px">
                                    <label class="div-Content" style="color: blue; font-size: 15px;">3. SIDBI</label></td>
                                <td>--%>
                                            <asp:RadioButtonList ID="SIDBI" Font-Size="15px" runat="server" Visible="false" ForeColor="blue" AutoPostBack="true" Font-Bold="false" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="SIDBI_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="0" />
                                                <asp:ListItem Text="No" Value="1" />
                                                <asp:ListItem Text="NA" Value="2" />
                                            </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="padding-left: 100px;">
                                    <table runat="server" visible="false" id="tblSidbiYes">
                                        <tr>
                                            <td style="padding-left: 30px;">
                                                <label class="div-Content">3a. Onboarded with reference of DIC officer</label>
                                            </td>
                                            <td style="padding-left: 30px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblSIDBIofcrref" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 30px;">
                                                <label class="div-Content">3b. Onboarded after attending the camps conducted</label>
                                            </td>
                                            <td style="padding-left: 30px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblSIDBIaftrCamps" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSIDBIaftrCamps_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trSIDBIcampdate" runat="server" visible="false">
                                            <td>
                                                <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date of camp attended </label>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <div class="div-contentcenter">
                                                    <asp:TextBox ID="txtSIDBIcampdate" runat="server" autocomplete="off" class="datepicker form-control" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div id="Div10" runat="server" visible="true" style="padding-left: 130px;">
                                    <table>

                                        <tr id="trsidbiawrns" visible="false" runat="server">
                                            <td>
                                                <label class="div-Content">3a. Awareness Provided on Listing</label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <asp:RadioButtonList ID="rblSIDBIawrns" runat="server" Font-Size="15px" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSIDBIawrns_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" />
                                                    <%--<asp:ListItem Text="No" Value="1" />--%>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr id="trsidbiintrst" visible="false" runat="server">
                                            <td>
                                                <label class="div-Content">3b.Whether unit is interested to onBoard onto SIDBI Platform :</label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <div class="div-contentcenter">
                                                    <asp:RadioButtonList ID="rblSIDBIintrsted" runat="server" Font-Bold="false" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSIDBIintrsted_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="0" />
                                                        <asp:ListItem Text="No" Value="1" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trsidblink" visible="false" runat="server">
                                            <td>
                                                <div style="padding-left: 65px; font-size: 15px;" id="Div11" runat="server" visible="true">
                                                    <asp:LinkButton runat="server" ID="SidbiLink" Font-Bold="true" ForeColor="DarkGreen" Text="3c. Click To Send Link to Applicant about SIDBI" OnClick="SidbiLink_Click"></asp:LinkButton>
                                                    <%--                                        window.open('https://www.sidbi.in/en', 'NewWindow', 'width=1200,height=600');--%>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </div>
                        </div>
                        <div class="div-contentcenter" style="padding-left: 115px">
                            <asp:CheckBox ID="chckfinothers" Visible="false" ForeColor="DarkViolet" runat="server" AutoPostBack="true" TabIndex="1" Font-Size="15px" Text="Others" Font-Bold="false" OnCheckedChanged="chckfinothers_CheckedChanged"></asp:CheckBox>

                        </div>
                        <div class="row" id="divfinancialOthers" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <label id="lblfncgrvA3" runat="server" visible="false" class="div-Content-NEW" style="padding-left: 150px;">a-3. Mention Other Financial Grievance: </label>
                                        </div>
                                        <div class="row">
                                            <label id="lblfncgdncA3" runat="server" visible="false" class="div-Content-NEW" style="padding-left: 150px;">a-3. Mention Other Financial Guidance: </label>
                                        </div>
                                    </td>
                                    <td>
                                        <div style="padding-left: 25px;">
                                            <asp:TextBox ID="txtFinancialOthers" TextMode="MultiLine" runat="server" oninput="validateInputName(this)" Width="350px" class="form-control" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="div-contentcenter" style="padding-left: 130px; padding-bottom: 10px">
                            <asp:Label ID="lblLand" Visible="false" ForeColor="RoyalBlue" runat="server" Style="text-decoration: blink; text-decoration-style: wavy" Font-Size="18px" Text="Please Explain about 4.Land (Vacant Plots) to the applicant if applicable" Font-Bold="false"></asp:Label>
                        </div>
                    </div>
                    <!---------------------------------------- Land Block -------------------------------------------------------->
                    <div class="row" style="padding-left: 80px">
                        <label runat="server" id="lbl4" visible="false" style="font-size: 20px; font-weight: bold;">4.</label><asp:CheckBox ID="chkLand" Font-Size="20px" Font-Bold="true" Text="Land" runat="server" AutoPostBack="true" OnCheckedChanged="chkLand_CheckedChanged" Visible="false" />
                    </div>
                    <div class="row" id="Land_Block" runat="server" visible="false">
                        <div style="padding-left: 40px;">
                            <table>
                                <tr id="trLand" runat="server" visible="true"
                                    style="padding-left: 15px; padding-top: 15px">
                                    <td style="padding-left: 25px;">
                                        <label class="div-Content">Details of the Grievance :</label>
                                    </td>
                                    <td style="padding-left: 80px;">
                                        <div class="div-contentcenter" style="margin-right: 105px;">
                                            <asp:TextBox ID="txtLand" TextMode="MultiLine" runat="server" autocomplete="off" oninput="validateInputName(this)" Width="200px" class="form-control" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="padding-left: 18px;">
                                        <label id="lbllandgrv" runat="server" visible="false" class="div-Content">a) Land Type of Grievance related to:</label>
                                        <label id="lbllandgdnc" runat="server" visible="false" class="div-Content">a) Land Type of Guidance related to:</label>
                                    </td>
                                    <td style="padding-left: 50px;">
                                        <asp:RadioButtonList ID="Land_Grievance" runat="server" Font-Bold="false" AutoPostBack="true" CssClass="checkbox-list" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Land_Grievance_SelectedIndexChanged">
                                            <asp:ListItem Text="TSIIC Land" Value="0" style="padding-right: 10px;" />
                                            <asp:ListItem Text="Others" Value="1" />
                                        </asp:RadioButtonList></td>
                                </tr>
                            </table>
                        </div>
                        <div id="TSIIC_LAND_Select" runat="server" visible="false">
                            <div style="padding-left: 60px;">
                                <table>
                                    <tr>
                                        <td colspan="2" style="padding-left: 100px">
                                            <%--Vacant plots available:--%>
                                            <asp:GridView ID="grdvacantplots" Visible="false" runat="server" Width="80%" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                                ForeColor="DarkGreen" AutoPostBack="true" GridLines="Both" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                RowStyle-HorizontalAlign="left">
                                                <HeaderStyle BackColor="#5B5A94" BorderColor="Black"
                                                    Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="District" DataField="DISTRICT" Visible="false" />
                                                    <asp:BoundField HeaderText="IE Name" DataField="IENAME" />
                                                    <asp:BoundField HeaderText="Plot Allotable" DataField="PLOTALLOTABLE" />
                                                    <asp:BoundField HeaderText="Plot No's" DataField="PLOTNO" />
                                                    <asp:BoundField HeaderText="Plot Area" DataField="PLOTAREA" />
                                                    <asp:BoundField HeaderText="Plot Cost" DataField="PLOTCOST" />
                                                </Columns>

                                                <EmptyDataTemplate>
                                                    <div style="text-align: Center">No Vacant Plots available</div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- <label class="div-Content-NEW">a-1. Whether information on vacant plots mandated to Weaker Section is informed :</label>--%>
                                            <asp:Label ID="landdesc" runat="server" class="div-Content-NEW" />
                                        </td>
                                        <td style="padding-left: 5px;">
                                            <asp:RadioButtonList ID="rblvacantplots" runat="server" Font-Bold="false" CssClass="checkbox-list" TabIndex="1" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Yes" Value="0" />
                                                <asp:ListItem Text="No" Value="1" />
                                            </asp:RadioButtonList></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="Land_Text_Box" runat="server" visible="false" style="padding-left: 65px">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <label id="lbllandgrvA2" runat="server" visible="false" class="div-Content-NEW">a-2. Please Enter Other Land Grievance Type</label>
                                            <label id="lbllandgdncA2" runat="server" visible="false" class="div-Content-NEW">a-2. Please Enter Other Land Guidance Type</label>

                                        </td>
                                        <td style="padding-left: 30px">
                                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" oninput="validateInputText(this)" class="form-control" Width="350px" /></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <!---------------------------------------- Others Block -------------------------------------------------------->

                    <div class="row" style="padding-left: 80px">
                        <label runat="server" id="lbl5" visible="false" style="font-size: 20px; font-weight: bold;">5.</label><asp:CheckBox ID="chkOthers" Font-Size="20px" Font-Bold="true" Text="Other" runat="server" AutoPostBack="true" OnCheckedChanged="chkOthers_CheckedChanged" Visible="false" />
                        <label runat="server" id="lblothrs" visible="false" style="font-size: 20px; font-weight: bold;" class="auto-style8">Grievance</label>
                    </div>
                    <div class="row" id="Other_Grievance_Block" runat="server" visible="false">
                        <%-- <div>--%>
                        <table>
                            <tr>
                                <td style="padding-left: 55px;">
                                    <label id="lblothrgrv" runat="server" visible="false" class="div-Content">a) Please Enter Other Grievance Type:</label>
                                    <label id="lblothrgdnc" runat="server" visible="false" class="div-Content">a) Please Enter Other Guidance Type:</label>

                                </td>
                                <td style="padding-left: 85px">
                                    <asp:TextBox ID="TextBox2" TextMode="MultiLine" runat="server" oninput="validateInputText(this)" class="form-control" Width="350px" /></td>
                            </tr>
                        </table>
                        <%--</div>--%>
                    </div>
                </div>
                <!---------------------------------------- Resolution Proposed Block -------------------------------------------------------->
                <div class="row" id="Grievance_Resolution" runat="server" visible="false" style="padding-top: 10px">
                    <table>
                        <tr>
                            <td style="padding-left: 60px; font-size: 15px;">
                                <label>12. Details of the Resolution Proposed for the Grievance</label>
                            </td>
                            <td style="padding-left: 50px;">
                                <asp:TextBox ID="TextBox3" TextMode="MultiLine" runat="server" oninput="validateInputText(this)" class="form-control" Width="350px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!---------------------------------------- Grievance Status Block -------------------------------------------------------->

                <div class="row" id="Grievance_Status" runat="server" visible="false" style="padding-top: 10px">
                    <table>
                        <tr>
                            <td style="padding-left: 60px; font-size: 15px;">
                                <label>13. Grievance status</label>
                            </td>
                            <td style="padding-left: 80px;">
                                <asp:DropDownList ID="GrievanceStatus_dropdown" runat="server" AutoPostBack="true" Font-Size="15px" class="form-control" Width="350px"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="row" id="divWandH" runat="server" visible="true" style="padding-top: 10px">
                    <table>
                        <tr id="trwehub" runat="server" visible="false" style="padding-top: 10px">
                            <td style="padding-left: 60px; font-size: 15px;">
                                <asp:Label ID="lblwehub" runat="server" Text="Do you want to forward to We-Hub"></asp:Label>
                            </td>
                            <td style="padding-left: 60px;">
                                <div class="div-contentcenter">
                                    <%-- <asp:RadioButtonList ID="rblWeHub" Font-Bold="false" runat="server" AutoPostBack="true" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblWeHub_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="0" style="margin-right: 0px;" />
                                        <asp:ListItem Text="No" Value="1" />
                                    </asp:RadioButtonList>--%>
                                    <asp:CheckBox runat="server" ID="chkwehub" Visible="true" ForeColor="DarkGreen" AutoPostBack="true" OnCheckedChanged="chkwehub_CheckedChanged" />
                                    <asp:LinkButton runat="server" ID="linkwehub" Visible="true" ForeColor="DarkGreen" Text="Click here to forward to We-Hub" OnClick="linkwehub_Click"></asp:LinkButton>
                                </div>
                            </td>
                            <%--</tr>
                        <tr id="trwehublink" runat="server" visible="false">--%>
                            <%--   <td id="trwehublink" runat="server" visible="false">--%>

                            <%--</td>    --%>
                        </tr>

                        <tr id="trHealthclinic" runat="server" visible="false">
                            <td style="padding-left: 60px; font-size: 15px; padding-top: 10px">
                                <asp:Label runat="server" ID="lblhlthclnc">Do you want to forawrd to Health Clinic</asp:Label>
                            </td>
                            <td style="padding-left: 60px; padding-top: 10px">
                                <div class="div-contentcenter">
                                    <asp:CheckBox ID="chkhlthclinc" runat="server" AutoPostBack="true" OnCheckedChanged="chkhlthclinc_CheckedChanged" />
                                    <asp:LinkButton runat="server" ID="linkhealthclinic" ForeColor="DarkGreen" Text="Click here to forward to Health-Clinic" OnClick="linkhealthclinic_Click"></asp:LinkButton>

                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <!---------------------------------------- Submit Button and Clear Block -------------------------------------------------------->

            <br />
            <div id="SUBMIT_CLEAR_BTNS" runat="server" class="row" align="center">
                <asp:Button ID="SubmitBtn" runat="server" BackColor="ForestGreen" Text="SUBMIT" Style="color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="SubmitBtn_Click" />
                <asp:Button ID="ClearBtn" runat="server" Text="CLEAR" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="ClearBtn_Click" />
            </div>
            <br />
        </div>
                 </div>
        </div>

        <link href="assets/css/basic.css" rel="stylesheet" />
        <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
        <script src="../../js/jquery-1.7.2.min.js"></script>
        <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
        <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
            type="text/css" />
        <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
        <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
        <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
        <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

        <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"> </script>


        <!-------  DatePicker and DatetimePicker jquery   --------->
        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-datetimepicker/2.5.20/jquery.datetimepicker.min.css">
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-datetimepicker/2.5.20/jquery.datetimepicker.full.min.js"></script>

    </contenttemplate>
    <script src="../jquery-1.3.2.min.js" language="javascript" type="text/javascript">    </script>
    <script src="../jquery-blink.js" language="javscript" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $('.blink').blink();

        }, 10);

    </script>
    <script type="text/javascript">

        function validatePhoneNumber() {
            var phoneNumber = document.getElementById("<%= Applicant_Contact.ClientID %>").value;
            var errorDiv = document.getElementById("error");
            var regex = /^[6-9]\d{9}$/;

            if (phoneNumber === "") {
                errorDiv.innerHTML = "";
            } else if (regex.test(phoneNumber)) {
                errorDiv.innerHTML = "";
            } else {
                errorDiv.innerHTML = "Invalid Phone Number";
                document.getElementById("<%= Applicant_Contact.ClientID %>").value = "";
            }
        }

        function validateEmail(txtmail) {
            var pattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            var errorMessage = document.getElementById("error-message");

            if (txtmail === "") {
                errorMessage.innerHTML = "";
            } else if (pattern.test(txtmail)) {
                errorMessage.innerHTML = "";
            } else {
                errorMessage.style.color = "red";
                errorMessage.innerHTML = "Invalid Mail Id";
                txtmail.text = ""
            }
        }

        function CapitalizeText(textbox) {
            var EnteredText = textbox.value.replace(/\s/g, '').toUpperCase();
            textbox.value = EnteredText;
        }

        function validateInputName(input) {
            input.value = input.value.replace(/[^A-Za-z ]/g, '');
            input.value = input.value.replace(/ {2,}/g, ' ');
            input.value = input.value.split(' ').map(function (word) {
                return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
            }).join(' ');
        }

        function validateInputText(input) {
            var pattern = /^[a-zA-Z0-9\s\-\/,.\']+$/;
            var inputValue = input.value;
            if (!pattern.test(inputValue)) {
                input.value = inputValue.replace(/[^a-zA-Z0-9\s\-\/,.\']+/g, '');
            }
        }

        //function validateInputName(input) {
        //    input.value = input.value.replace(/[^A-Za-z ]/g, '');
        //    input.value = input.value.replace(/ {2,}/g, ' ');
        //    input.value = input.value.split(' ').map(function (word) {
        //        return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
        //    }).join(' ');
        //}
        //function validateInputText(input) {
        //    var pattern = /^[a-zA-Z0-9\s\-\/,.\']+$/;
        //    var inputValue = input.value;
        //    if (!pattern.test(inputValue)) {
        //        input.value = inputValue.replace(/[^a-zA-Z0-9\s\-\/,.\']+/g, '');
        //    }
        //}

        function formatCurrency(input) {
            var value = input.value.replace(/,/g, '').replace(/[^\d.]/g, '');
            var formattedValue = Number(value).toLocaleString('en-IN');
            input.value = formattedValue;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datetimepicker").datetimepicker({
                format: 'd-m-Y H:i A ',
                step: '30',
                allowTimes: [
                    '00:00', '00:30', '01:00', '01:30', '2:00', '2:30', '3:00', '3:30',
                    '4:00', '4:30', '5:00', '5:30', '6:00', '6:30', '7:00', '7:30',
                    '8:00', '8:30', '9:00', '9:30', '10:00', '10:30', '11:00', '11:30', '12:00',
                    '12:30', '13:00', '13:30', '14:00', '14:30', '15:00', '15:30', '16:00',
                    '16:30', '17:00', '17:30', '18:00', '18:30', '19:00', '19:30', '20:00',
                    '20:30', '21:00', '21:30', '22:00', '22:30', '23:00', '23:30'
                ],
                maxDate: 0,
                //minDate: new Date(new Date().setDate(new Date().getDate() - 7))
                 minDate: new Date('01-01-2024')
            });

            $(".datepicker").datepicker({
                dateFormat: 'dd-m-yy',
                maxDate: 0
            });
        });
        $(document).ready(function () {
            $("#<%=UID_SEARCH_GRID.ClientID%> input[type='checkbox']").change(function () {
                var checkboxes = $("#<%=UID_SEARCH_GRID.ClientID%> input[type='checkbox']");
                checkboxes.each(function () {
                    if ($(this).prop('checked')) {
                        checkboxes.not(this).closest('tr').hide();
                        var selectedName = $(this).closest('tr').find('[id$=Applicant_Name]').text();
                        alert("Selected Applicant Name: " + selectedName);
                    } else {
                        checkboxes.not(this).closest('tr').show();
                    }
                });
            });
        });

        $(document).ready(function () {
            $('input[type="text"]').on('paste', function (e) {
                e.preventDefault();
            });
        });
    </script>
    <script type="text/javascript">
        function validatePhoneNumber() {
            var phoneNumber = document.getElementById("<%= Applicant_Contact.ClientID %>").value;
            var errorDiv = document.getElementById("error");
            var regex = /^[6-9]\d{9}$/;

            if (phoneNumber === "") {
                errorDiv.innerHTML = "";
            } else if (regex.test(phoneNumber)) {
                errorDiv.innerHTML = "";
            } else {
                errorDiv.innerHTML = "Invalid Phone Number";
            }
        }

        function validateEmail(txtmail) {
            var pattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            var errorMessage = document.getElementById("error-message");

            if (txtmail === "") {
                errorMessage.innerHTML = "";
            } else if (pattern.test(txtmail)) {
                errorMessage.innerHTML = "";
            } else {
                errorMessage.style.color = "red";
                errorMessage.innerHTML = "Invalid Mail Id";
            }
        }

        function CapitalizeText(textbox) {
            var EnteredText = textbox.value.replace(/\s/g, '').toUpperCase();
            textbox.value = EnteredText;
        }

        function validateInputName(input) {
            input.value = input.value.replace(/[^A-Za-z ]/g, '');
            input.value = input.value.replace(/ {2,}/g, ' ');
            input.value = input.value.split(' ').map(function (word) {
                return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
            }).join(' ');
        }

        function validateInputText(input) {
            var pattern = /^[a-zA-Z0-9\s\-\/,.\']+$/;
            var inputValue = input.value;
            if (!pattern.test(inputValue)) {
                input.value = inputValue.replace(/[^a-zA-Z0-9\s\-\/,.\']+/g, '');
            }
        }

        //function validateInputName(input) {
        //    input.value = input.value.replace(/[^A-Za-z ]/g, '');
        //    input.value = input.value.replace(/ {2,}/g, ' ');
        //    input.value = input.value.split(' ').map(function (word) {
        //        return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
        //    }).join(' ');
        //}
        //function validateInputText(input) {
        //    var pattern = /^[a-zA-Z0-9\s\-\/,.\']+$/;
        //    var inputValue = input.value;
        //    if (!pattern.test(inputValue)) {
        //        input.value = inputValue.replace(/[^a-zA-Z0-9\s\-\/,.\']+/g, '');
        //    }
        //}

        function formatCurrency(input) {
            var value = input.value.replace(/,/g, '').replace(/[^\d.]/g, '');
            var formattedValue = Number(value).toLocaleString('en-IN');
            input.value = formattedValue;
        }
    </script>

</asp:Content>

