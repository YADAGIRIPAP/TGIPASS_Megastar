<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="FRMCaptureMSME.aspx.cs" Inherits="UI_TSiPASS_FRMCaptureMSME" %>

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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style5 {
            color: #FF0000;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }
    </script>
    <script type="text/javascript">
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }
    </script>
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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style5 {
            color: #FF0000;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <style type="text/css">
        input#ctl00_ContentPlaceHolder1_RadioButtonList1_1 {
            height: 17px;
            width: 33px;
        }

        input#ctl00_ContentPlaceHolder1_RadioButtonList1_0 {
            height: 17px;
            width: 33px;
        }

        label {
            font-size: large;
        }

        td {
            font-size: 17px;
        }

        h4 {
            color: mediumblue;
        }
    </style>

    <asp:UpdatePanel ID="upd1" runat="server">

        <Triggers>
            <asp:PostBackTrigger ControlID="btnFirstGrid" />

        </Triggers>
        <ContentTemplate>

            <h3 style="text-align: center; font-weight: bold; color: green;">INDUSTRY CATALOGUE</h3>
            <table class="auto-style7" style="width: 70%;">
                <tr>
                    <h4 style="font-weight: 700; margin-left: 36px; margin-bottom: -10px;">UNIT DETAILS</h4>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; margin: 5px">Whether the unit is in IE/Not</td>
                    <td style="padding: 5px; margin: 5px">
                        <asp:RadioButtonList ID="rdunitIEORNOT" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="1">yes</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">1.Category :<font 
                                                            color="red">*</font></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Width="180px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">MEGA</asp:ListItem>
                            <asp:ListItem Value="2">LARGE</asp:ListItem>
                            <asp:ListItem Value="3">MEDIUM</asp:ListItem>
                            <asp:ListItem Value="4">SMALL</asp:ListItem>
                            <asp:ListItem Value="5">MICRO</asp:ListItem>
                        </asp:DropDownList></td>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddldistrict" ErrorMessage="Please select  District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                    <td>2.UAM / IEM / IL ID :</td>
                    <td>
                        <asp:TextBox ID="txtUAMID" autocomplete="off" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtUAMID" ErrorMessage="Please enter UAMID" ValidationGroup="group">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>3.Unit Name :<span class="style5">*</span> </td>
                    <td>
                        <asp:TextBox ID="txtUnitName" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtUnitName" ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lbldistrict" runat="server" CssClass="LBLBLACK" Width="165px">4.District :<font 
                                                            color="red">*</font></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddldistrict"
                            ErrorMessage="Please select  District" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>5.Mandal :<font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                            Width="180px" AutoPostBack="True" TabIndex="1">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal"
                            ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </td>
                    <td>6. Employment :<span class="style5">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployment" autocomplete="off" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtEmployment"
                            ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table style="width: 70%">
                <tr>
                    <h4 style="font-weight: 700; margin-left: 36px; margin-bottom: 21px;">ENTREPRENEUR CONTACT DETAILS</h4>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNameofEntrepreneur" runat="server" CssClass="LBLBLACK" Style="margin-bottom: 17px;" Width="210px">1.Name of Entrepreneur : <font 
                                                            color="red">*</font></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNameofEntrepreneur" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group"
                            Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameofEntrepreneur"
                            ErrorMessage="Please enter Name of Entrepreneur" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" CssClass="LBLBLACK" Width="210px">3.Email:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" autocomplete="off" runat="server" class="form-control txtbox" Height="28px"
                            MaxLength="40" TabIndex="1" ValidationGroup="group"
                            Width="180px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobileNO" runat="server" CssClass="LBLBLACK" Style="margin-bottom: 20px;" Width="210px">2.Mobile No : <font 
                                                            color="red">*</font></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMObileNo" autocomplete="off" runat="server" class="form-control txtbox" Height="28px"
                            MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                            Width="180px" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMObileNo"
                            ErrorMessage="Please enter Your Mobile number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMObileNo"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <table width="70%">
                <tr>
                    <h4 style="font-weight: 700; margin-left: 36px; margin-bottom: 21px;">PRODUCT DETAILS</h4>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLineofActivity" runat="server" CssClass="LBLBLACK" Width="165px">1. Line of Activity :<font 
                                                            color="red">*</font></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlintLineofActivity" runat="server"
                            class="form-control txtbox" Height="33px" Width="550px">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblProductSpec" runat="server" CssClass="LBLBLACK" Width="165px">2.Product Specification(if any) : </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductSpec" autocomplete="off" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <div>
                    <tr>
                        <h4 style="font-weight: 700; margin-left: 36px; margin-bottom: 21px; margin-top: 21px;">ITEMS MANUFACTURED</h4>
                    </tr>
                    <tr>
                        <div class="rowcol">
                            <div class="col-xs-12 col-sm-2">
                                <label class="formlabel">
                                    1.Item <font color="red">*</font></label>
                                <asp:TextBox ID="txtManfitem" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtManfitem" ErrorMessage="Please enter Item" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-xs-12 col-sm-2">
                                <label class="formlabel">
                                    2.Quantity Per Annum <font color="red">*</font></label>
                                <asp:TextBox ID="txtManfquantityperannum" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtManfquantityperannum" ErrorMessage="Please select Manf Item Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-xs-12 col-sm-2">
                                <label class="formlabel">
                                    3. Production In Units <font color="red">*</font></label>
                                <asp:DropDownList ID="ddlManfquantityin" runat="server" class="form-control txtbox" AutoPostBack="True" Height="33px" TabIndex="1"
                                    OnSelectedIndexChanged="ddlManfquantityin_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem Value="KG">KG</asp:ListItem>
                                    <asp:ListItem Value="Tone">Tone</asp:ListItem>
                                    <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-12 col-sm-2" style="margin-top: -20px;" id="trothers" runat="server" visible="false">
                                <label class="formlabel">
                                    5.others <font color="red"></font>
                                </label>
                                <asp:TextBox ID="txtMfgothers" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please select Quantity(Per Annum)" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-xs-12 col-sm-2">
                                <label class="formlabel">
                                    4.Upload Photo of unit<font color="red"></font></label>
                                <asp:FileUpload ID="fpdSketch" runat="server"  class="form-control txtbox"
                                    Height="33px" />
                                <asp:HyperLink ID="hplSketch" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <%-- <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>--%>
                            </div>
                            <div class="col-xs-12 col-sm-2">
                                <label class="formlabel">
                                    5.Other Product Related Details (If Any)</label>
                                <asp:TextBox ID="txtotherproduct" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" ></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtManfquantityperannum" ErrorMessage="Please select Manf Item Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </tr>



                    <tr>
                        <div class="col-xs-12" style="text-align: center; margin-top: -10px;">
                            <asp:Button ID="btnFirstGrid" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="10" Text="Add New" ValidationGroup="child" Width="72px" OnClick="btnFirstGrid_Click" />
                            &nbsp;<asp:Button ID="ButtonMfgcancel" runat="server" OnClick="ButtonMfgcancel_Click" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                        </div>
                    </tr>
                    <tr>
                        <div class="form-group" style="width: 100%;">
                            <asp:GridView CssClass="table table-bordered" runat="server" ID="grdEnergyConsumed"
                                AutoGenerateColumns="false" OnRowCommand="grdEnergyConsumed_RowCommand" OnRowDeleting="grdEnergyConsumed_RowDeleting">
                                <HeaderStyle CssClass="gridcolor" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="lblManfitem" runat="server" Text='<%#Eval("Manfitem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Per Annum">
                                        <ItemTemplate>
                                            <asp:Label ID="lblManfquantityperannum" runat="server" Text='<%#Eval("Manfquantityperannum") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production In Units">
                                        <ItemTemplate>
                                            <asp:Label ID="lblManfquantityin" runat="server" Text='<%#Eval("Manfquantityin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMfgothers" runat="server" Text='<%#Eval("Mfgothers") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Upload Photo" ItemStyle-Width="30">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("SketchCopy_Path") %>'
                                                Text='View' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderText="Delete">
                                        <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRenRemove" runat="server" CommandName="EnergyDelete" Font-Bold="true" ForeColor="#ff3300"><u>Delete</u></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </tr>
            </table>
            <table width="100%">
                <div>
                    <tr>
                       <h4 style="font-weight: 700; margin-left: 36px; margin-bottom: 21px; margin-top: 21px;">Materials used For Manufacturing other than Coal,Ethanol etc</h4>
                    </tr>
                    <tr>
                        <div class="container">
                            <div class="col-xs-12 col-sm-3">
                                <label class="formlabel">
                                    1.Item</label>
                                <asp:TextBox ID="txtRawItem" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRawItem" ErrorMessage="Please enter  Raw Item" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                                <label class="formlabel">
                                    2.Quantity Per Annum</label>
                                <asp:TextBox ID="txtRawQntyperAnnum" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRawQntyperAnnum" ErrorMessage="Please select Raw Item  Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                                <label class="formlabel">
                                    3. Production In Units</label>
                                <asp:DropDownList ID="ddlRawUnits" runat="server" class="form-control txtbox" Width="180px" AutoPostBack="True" Height="33px" TabIndex="1"
                                    OnSelectedIndexChanged="ddlRawUnits_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem Value="KG">KG</asp:ListItem>
                                    <asp:ListItem Value="Tone">Tone</asp:ListItem>
                                    <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-12 col-sm-3" id="trrawothers" runat="server" visible="false">
                                <label class="formlabel">
                                    4.Others <font color="red"></font>
                                </label>
                                <asp:TextBox ID="txtRawothers" autocomplete="off" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please select Quantity(Per Annum)" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </tr>
                    <tr>
                        <div class="col-xs-12" style="text-align: center; margin-top: 12px">
                            <asp:Button ID="btnSecondGridAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="10" Text="Add New" ValidationGroup="child" Width="72px" OnClick="btnSecondGridAdd_Click" />
                            &nbsp;<asp:Button ID="btnSecondGridClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnSecondGridClear_Click" />
                        </div>
                    </tr>
                    <tr>
                        <div class="form-group" style="width: 100%;">
                            <asp:GridView CssClass="table table-bordered" runat="server" ID="grdPowerutilized"
                                AutoGenerateColumns="false" OnRowCommand="grdPowerutilized_RowCommand" OnRowDeleting="grdPowerutilized_RowDeleting">
                                <HeaderStyle CssClass="gridcolor" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ITEM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRawItem" runat="server" Text='<%#Eval("RawItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Per Annum">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRawQntyperAnnum" runat="server" Text='<%#Eval("RawQntyperAnnum") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production In Units">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRawUnits" runat="server" Text='<%#Eval("RawUnits") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOtherUnits" runat="server" Text='<%#Eval("OtherUnits") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderText="Delete">
                                        <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRenRemove" runat="server" CommandName="Delete" Font-Bold="true" ForeColor="#ff3300"><u>Delete</u></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </tr>
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
            <div class="col-xs-12" style="text-align: center; margin-top: 30px;">
                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Height="28px" TabIndex="10" Text="Submit" ValidationGroup="group" Width="72px" OnClick="btnsubmit_Click" />
                &nbsp;<asp:Button ID="btnclear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnclear_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
