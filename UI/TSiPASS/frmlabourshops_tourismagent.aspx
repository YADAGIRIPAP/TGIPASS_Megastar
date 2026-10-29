<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmlabourshops_tourismagent.aspx.cs" Inherits="UI_TSiPASS_frmlabourshops_tourismagent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
        
        .AjaxCalendar .ajax__calendar_container
        {
            border: 1px solid #646464;
            background-color: yellow;
            color: red;
        }
        
        .AjaxCalendar .ajax__calendar_other .ajax__calendar_day, .AjaxCalendar .ajax__calendar_other .ajax__calendar_year
        {
            color: Black;
        }
        
        .AjaxCalendar .ajax__calendar_hover .ajax__calendar_day, .AjaxCalendar .ajax__calendar_hover .ajax__calendar_month, .AjaxCalendar .ajax__calendar_hover .ajax__calendar_year
        {
            color: White;
        }
        
        .AjaxCalendar .ajax__calendar_active .ajax__calendar_day, .AjaxCalendar .ajax__calendar_active .ajax__calendar_month, .AjaxCalendar .ajax__calendar_active .ajax__calendar_year
        {
            color: Purple;
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var hexvalues
            = Array("A", "B", "C", "D", "E", "F", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9");

        function flashtext() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext").style.color = colour;
        }

        setInterval("flashtext()", 500);
        function flashtext1() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext1").style.color = colour;
        }

        setInterval("flashtext1()", 500);
        function flashtext2() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext2").style.color = colour;
        }

        setInterval("flashtext2()", 500);


    </script>
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
        
        .style6
        {
            width: 192px;
        }
        
        .auto-style1
        {
            width: 200px;
        }
        
        .auto-style2
        {
            width: 47px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

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

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">
                <asp:Label ID="lblHead2" runat="server" Text="Labour Details"></asp:Label></a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div align="left" class="row">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div align="center" class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead1" runat="server" Text="Labour Details"></asp:Label></h3>
                    </div>
              
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr runat="server" visible="false" id="trAct3Registration">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl" runat="server" CssClass="LBLBLACK" Width="300px">Select Already Registered Act/Scheme
                                                                <font color="red">*</font></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlSchemAct3" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" OnSelectedIndexChanged="ddlSchemAct3_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="250px">Registration/License No
                                                                <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtRegLicAct3" runat="server" class="form-control txtbox" Height="28px"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK">Re- enter Registration/License No
                                                                <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtReRegLicAct3" runat="server" class="form-control txtbox" Height="28px"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtRegLicAct3"
                                                    ControlToValidate="txtReRegLicAct3" ErrorMessage="Registration/ License Number not matched"
                                                    Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr1">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 89%">
                                        <tr runat="server" visible="false" id="trClassification">
                                            <td style="text-align: left; font-weight: bold">
                                                1. Classification of Establishment <font color="red">*</font>
                                            </td>
                                            <td style="">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlEstClassification" runat="server" class="form-control txtbox"
                                                    Height="33px" OnSelectedIndexChanged="ddlEstClassification_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                       
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trCategory">
                                            <td style="text-align: left; font-weight: bold">
                                                <asp:Label ID="lblCategoryofEstab" runat="server" data-balloon-pos="down" data-balloon-length="large"
                                                    CssClass="LBLBLACK">2. Category of Establishment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlCategoryofEstablishment" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                     <asp:ListItem Value="20">TRAVEL AGENCY(FOR BOOKING OPERATIONS)</asp:ListItem>                                                   
                                                </asp:DropDownList>
                                            </td>
                                            <td style="">
                                                
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trNameofEstab">
                                            <td style="text-align: left;">
                                                3. Name of Shop/Establishment <font color="red">*</font>
                                            </td>
                                            <td style="">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtNameofShopAct1" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"></asp:TextBox>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr2">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="3">
                                                <asp:Label ID="lblPostalAddress" runat="server" Text="4. Address of the Shop/Establishment"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Door No. <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtShopDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtShopDoorNo"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Locality <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtShopLocality" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtShopLocality"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            District <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlShopDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopDistrict_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlShopDistrict"
                                                                ErrorMessage="Please Select District of Shop/Establishment" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Mandal <font color="red">*</font>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlShopMandal" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopMandal_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlShopMandal"
                                                                ErrorMessage="Please Select Mandal of Shop/Establishment" InitialValue="--Mandal--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Village <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlShopVillage" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlShopVillage"
                                                                ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Pin Code <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtShopPincode" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtShopPincode"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Pin Code)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr4">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trGodown1" visible="false">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                4. Location of Office, Godown, Warehouse or workplace attached to the shop/establishment
                                                but situated outside the premisis of it
                                            </td>
                                  
                                        </tr>
                                        <tr runat="server" id="trGodown2" visible="false">
                                            <td colspan="3" style="text-align: left;">
                                                <asp:GridView ID="gvWorkerDtls" runat="server" AutoGenerateColumns="False" border="3"
                                                    CellPadding="1" CellSpacing="1" OnRowCommand="gvWorkerDtls_RowCommand" OnRowDataBound="gvWorkerDtls_RowDataBound">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Work Place">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlWorkPlace" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Door No.">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDoorNo" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Locality">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtLocality" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:ButtonField CommandName="Add" Text="Add">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField CommandName="Remove" Text="Delete">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                            <td>
                                                <div id="flashingtext" style="font-size: 15px;">
                                                    <b>Please click on ADD,before Proceeding</b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr5">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerDetails1">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                <asp:Label ID="lblEmployer" runat="server" Text="5. Employer, Managing Partner or Managing Director as the case may be (Name, Father Name, Designation, Age, Mobile, e-Mail)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerDetails2">
                                            <td colspan="4">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Name <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TxtnameofUnitAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TxtnameofUnitAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Name)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Father's Name <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPGNameAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPGNameAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Father's Name)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Designation <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDesigAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDesigAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Designation)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Age <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtAgeAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAgeAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Age)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mobile <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtMobileAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtMobileAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Mobile)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Email <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEmailAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEmailAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Email)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr6">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerAddress1">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblEmployerAddress" runat="server" Text="6. Residential address of the employer"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerAddress2">
                                            <td colspan="3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Door No.<font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDoorNoResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDoorNoResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Locality <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtLocalResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtLocalResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            District <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDistrictResidentialAct1" runat="server" AutoPostBack="True"
                                                                class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlDistrictResidentialAct1_SelectedIndexChanged"
                                                                Width="180px">
                                                                <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDistrictResidentialAct1"
                                                                ErrorMessage="Please Select District of Employer" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mandal <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalResidentialAct1_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandalResidentialAct1"
                                                                ErrorMessage="Please Select Mandal of Employer" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Village <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillageResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                ErrorMessage="Please Select Residential Village of the Employer (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr7">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trPermanentAddressofEstab" visible="false">
                                            <td>
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>
                                                                <asp:Label ID="lblPermanentAddress" runat="server" CssClass="LBLBLACK">3. Full name and Permanent Address of the establishment, if any
                                                                <font color="red">*</font></asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="110px"> Full Name
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtFullNamePermAct2" runat="server" class="form-control txtbox"
                                                                Height="28px" ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="110px"> District
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDistrictPermAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictPermAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="110px"> Mandal
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalPermAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalPermAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="110px"> Village
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillagePermAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="110px"> Door No
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDoorNoPermAct2" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="110px"> Pin Code
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPinCodePermAct2" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr8">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trDirectorAddress">
                                            <td>
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>
                                                                <asp:Label ID="lblDirector" runat="server" CssClass="LBLBLACK">4.  Name and address of the Director / Partners (in case of companies/firm)</asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="110px"> Full Name
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDirFullName" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="110px"> Door No
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDirDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="110px"> District
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDirDistrict" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlDirDistrict_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="110px"> Mandal
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDirMandal" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" OnSelectedIndexChanged="ddlDirMandal_SelectedIndexChanged" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="110px"> Village/Town
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDirVillage" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr9">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trManagerorNot">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblManagerOrNot" runat="server" CssClass="LBLBLACK"> 7. Manager/Agent if any (with residential address):
                                                                <font color="red">*</font></asp:Label>
                                                <asp:RadioButtonList ID="Rd_ManagerResidenceAct1" runat="server" AutoPostBack="true"
                                                    RepeatDirection="Horizontal" Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr id="trManagerResidenceAct1" runat="server" visible="false">
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 89%">
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Label ID="lblManagerAddress" runat="server" Text="4. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Name <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerNameAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Father&#39;s Name <span class="reqFields" style="display: inline;"><font color="red"
                                                                size="3">*</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerPGNameAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Designation <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerDesignationAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Door No <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerDoorNoAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Locality <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerLocalityAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            District <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlManagerDistrictAct1" runat="server" AutoPostBack="true"
                                                                class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlManagerDistrictAct1_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mandal <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font>
                                                            </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlManagerMandalAct1" runat="server" AutoPostBack="true" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlManagerMandalAct1_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Village <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlManagerVillageAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2" style="padding: 3px; margin: 3px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="110px">Mobile No
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtMobileNoManagerAct2" runat="server" class="form-control txtbox"
                                                                Height="28px" ToolTip="text" MaxLength="10" onkeypress="NumberOnly()" TabIndex="0"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="110px">Email Id
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmailManagerAct2" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px;">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr3">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 89%">
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lblNatureofBusiness" runat="server" Text="8. Nature of business *"
                                                                Font-Bold="true" Width="600px"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNatureofBusinessAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNatureofBusinessAct1"
                                                                ErrorMessage="Please Enter Nature of business " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trDateofCommencement" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ID="lblDateofCommencement" runat="server" Text="9. Date of Commencement of business *"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateofCommenceAct1">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr10">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr runat="server" id="tr11">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr id="trFamilyMembers1" runat="server" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblFamily" runat="server" Text="10. Name of family members of employees family engaged in Shop / Establishment"
                                                    Font-Bold="true"></asp:Label>
                                            </td>
                                        
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr12">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr id="trFamilyMembers2" runat="server" visible="false">
                                <td colspan="3">
                                    <table>
                                        <tr>
                                            <td colspan="3" style="text-align: left">
                                                <asp:GridView ID="gvFamilyMembersAct1" runat="server" AutoGenerateColumns="False"
                                                    border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFamilyMembersAct1_RowCommand"
                                                    OnRowDataBound="gvFamilyMembersAct1_RowDataBound">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFamilyNameAct1" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Relationship">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlRelationshipAct1" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Gender">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFamilyGenderAct1" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Adult/Young Person">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFamilyAdultAct1" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                     
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:ButtonField CommandName="Add" Text="Add">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField CommandName="Remove" Text="Delete">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                            <td>
                                                <div id="flashingtext1" style="font-size: 15px;">
                                                    <b>Please click on ADD,before Proceeding</b>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                   
                            <tr runat="server" id="tr13">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr id="trTotalEmps" runat="server" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 84%">
                                        <tr>
                                            <td style="font-weight: bold">
                                                <asp:Label ID="lblTotalEmps" runat="server" Width="500px" Text="11. Total No. of Employees *:"></asp:Label>
                                            </td>
                                            <td style="height: 35px; text-align: left">
                                                <asp:TextBox ID="txtTotalEmployees" runat="server" class="form-control txtbox" Enabled="false"
                                                    MaxLength="6" onkeypress="NumberOnly()" Width="50px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trAgewiseEmployees" runat="server" visible="false">
                                <td colspan="3">
                                    <asp:Table ID="tblNoofEmployees" runat="server" CellPadding="1" CellSpacing="1" Font-Size="Medium"
                                        GridLines="Both" Width="400">
                                        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Style="color: White; background-color: #013161;
                                            font-weight: bold;">
                                            <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="150px">Adults (18 years and above)</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="170px">Young Persons (From 14 years to Below 18 years)</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell>MALE</asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Male" Width="40px"
                                                    OnTextChanged="txtAbove18Male_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18Male" Width="40px"
                                                    OnTextChanged="txtBelow18Male_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">FEMALE</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Female" Width="40px"
                                                    OnTextChanged="txtAbove18Female_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18FeMale" Width="40px"
                                                    OnTextChanged="txtBelow18FeMale_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableFooterRow ID="TableFooterRow1" runat="server" HorizontalAlign="Center"
                                            Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">Total</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" ID="txtTotalAbove18" Width="40px" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" ID="txtTotalBelow18" Width="40px" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableFooterRow>
                                    </asp:Table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 20px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="trNamesofEmployees1" runat="server" visible="false">
                                <td colspan="3" style="font-weight: bold">
                                    <asp:Label ID="lblEmployeeNames" runat="server" Text="12. Name of Employees (Optional):"
                                        Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trNamesofEmployees2" runat="server" visible="false">
                                <td colspan="3" style="text-align: left">
                                    <asp:GridView ID="gvEmployeeNames" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvEmployeeNames_RowCommand" OnRowDataBound="gvEmployeeNames_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Occupation">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlOccupationAct1" runat="server">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeNameAct1" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlEmployeeGenderAct1" runat="server">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="Add" Text="Add">
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="Remove" Text="Delete">
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <div id="flashingtext2" style="font-size: 15px;">
                                        <b>Please click on ADD,before Proceeding</b>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            </td> </tr>
                            <tr>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <tr id="trCompletionDate" runat="server" visible="false">
                                    <td>
                                        <table cellpadding="4" cellspacing="5" style="width: 50%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCompletionDate" runat="server" CssClass="LBLBLACK" Font-Bold="true"
                                                        Width="600px">7. Estimated date of completion of building or other construction work
                                                                <font color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtEstDateCompAct2" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEstDateCompAct2" Display="None" ErrorMessage="Please give particulars of proposed date of commencing and ending" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                              
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                 
                                <tr id="trContractorDetailsAct4" runat="server" visible="false">
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 5px">
                                                </td>
                                                <td colspan="6">
                                                    <strong>
                                                        <asp:Label ID="lblContractor" runat="server" CssClass="LBLBLACK" Font-Bold="true">7. Particulars of Contractors and migrant workmen</asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <asp:GridView ID="gvContractorAct4" runat="server" AutoGenerateColumns="False" border="3"
                                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvContractorAct4_RowCommand" OnRowDataBound="gvContractorAct4_RowDataBound">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name of the Contractor">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorNameAct4" runat="server" Height="25px" Width="150px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Address">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorAddressAct4" runat="server" Height="50px" TextMode="MultiLine"
                                                                        Width="150px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No.">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorMobileNoAct4" runat="server" Height="25px" MaxLength="10"
                                                                        onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nature of Work">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorNatureAct4" runat="server" Height="25px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Maximum No. of Migrant Workmen">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorMaximumNoAct4" runat="server" AutoPostBack="true" Height="25px"
                                                                        onkeypress="return inputOnlyNumbers(event)" OnTextChanged="GetTotalWorkMan" Width="35"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estimated Date of Commencement">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorCommenceAct4" runat="server" Height="25px"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtContractorCommenceAct4">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estimated Date of Completion">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorCompAct4" runat="server" Height="25px"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy-MM-dd" TargetControlID="txtContractorCompAct4">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Details of Manufacturing Depts">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtManufacturingDepts" runat="server" Height="25px" TextMode="MultiLine"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:ButtonField CommandName="Add" Text="Add">
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White"
                                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trTotalContractors" runat="server" visible="false">
                              
                                    <td>
                                        <table style="width: 50%">
                                            <tr>
                                                <td>
                                                    <strong>Total No.of Contract Employees * :</strong>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtTotalContractors" runat="server" class="form-control txtbox"
                                                        Enabled="false" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                        Width="54px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server" id="trattachment" visible="false">
                                    <td>
                                        <strong>Upload Attachments:</strong>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trteluguboard" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Telugu Board Upload<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileTeluguBoard" runat="server" class="form-control txtbox" Height="48px" />
                                                    <asp:HyperLink ID="lblTeluguBoard" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblTeluguBoard]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="LabelTeluguBoard" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="BtnTeluguBoard" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" OnClick="BtnTeluguBoard_Click" TabIndex="10" Text="Upload" Width="72px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="tridproof" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">ID Proof of Employer<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadidproof" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkidproof" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblidproof]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelidproof" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnidproof" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnidproof_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trphoto" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px">Passport Size of Employee<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadphoto" runat="server" class="form-control txtbox" Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkphoto" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblphoto]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelphoto" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnphoto" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnphoto_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trrenetaldeed" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    4
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="210px">Rental Deed/Sale Deed/Ownership Proof<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadrenetaldeed" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkrenetaldeed" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblrenetaldeed]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelrenetaldeed" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnrenetaldeed" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnrenetaldeed_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trMemorandum" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    5
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Memorandum of Articles(Companies)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadMemorandum" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkMemorandum" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblMemorandum]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="LabelMemorandum" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnMemorandum" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnMemorandum_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trincorportaion" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    6
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="210px">Certification of Incorporation(Companies)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadincorportaion" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkincorportaion" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblincorportaion]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelincorportaion" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnincorportaion" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnincorportaion_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        &nbsp;
                                    </td>
                                    <td style="width: 27px">
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <caption>
                                    &nbsp;</caption>
                                <tr id="trsubmitactual" runat="server">
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                            OnClick="BtnSave1_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                 <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                            OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                    </td>
                                </tr>
                                <tr id="trsubmitqury" runat="server" visible="false">
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btnsubmitform" runat="server" CssClass="btn btn-primary" Height="32px"
                                            OnClick="btnsubmitform_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                                            Width="90px" />
                                         &nbsp;&nbsp;
                              
                                        <asp:Button ID="btnNext0" Visible="true" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                            Height="32px" OnClick="btnNext0_Click" TabIndex="10" Text="Next" Width="90px" />
                                        &nbsp;<asp:Button ID="BtnClear" Visible="true"  runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                            ValidationGroup="group" Width="90px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
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
    <br />
    <br />
    <br />
  
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtEstDateCompAct2']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtEstDateCompAct2']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
</asp:Content>

