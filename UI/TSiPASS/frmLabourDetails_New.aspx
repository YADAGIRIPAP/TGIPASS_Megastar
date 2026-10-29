<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmLabourDetails_New.aspx.cs" Inherits="UI_TSiPASS_frmLabourDetails_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .AjaxCalendar .ajax__calendar_container {
            border: 1px solid #646464;
            background-color: yellow;
            color: red;
        }

        .AjaxCalendar .ajax__calendar_other .ajax__calendar_day,
        .AjaxCalendar .ajax__calendar_other .ajax__calendar_year {
            color: Black;
        }

        .AjaxCalendar .ajax__calendar_hover .ajax__calendar_day,
        .AjaxCalendar .ajax__calendar_hover .ajax__calendar_month,
        .AjaxCalendar .ajax__calendar_hover .ajax__calendar_year {
            color: White;
        }

        .AjaxCalendar .ajax__calendar_active .ajax__calendar_day,
        .AjaxCalendar .ajax__calendar_active .ajax__calendar_month,
        .AjaxCalendar .ajax__calendar_active .ajax__calendar_year {
            color: Purple;
            font-weight: bold;
        }
    </style>
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

        .style6 {
            width: 192px;
        }

        .col-lg-11 {
            padding-left: 30px !important;
        }

        .checkcss tr input {
            border: 1px solid red;
            margin-right: 20px;
            padding-right: 10px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

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

    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPERCert" />
            <asp:PostBackTrigger ControlID="BtnFuEmpFrmV" />
            <asp:PostBackTrigger ControlID="btnAttachChallan" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">
                        <asp:Label ID="lblHead2" runat="server" Text="Labour Details"></asp:Label></a> </li>
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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr id="trCategory" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 20px; margin-bottom: 20px">
                                                        <tr>
                                                            <td style="text-align: left; font-weight: bold; width: 680px;">
                                                                <asp:Label ID="lblCategoryofEstab" runat="server" data-balloon-pos="down" data-balloon-length="large" CssClass="LBLBLACK"> Category of Establishment<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="">: </td>
                                                            <td style="text-align: left;">
                                                                <asp:DropDownList ID="ddlCategoryofEstablishment" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false" id="trNameofEstab">

                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 20px; margin-bottom: 20px">
                                                        <tr id="tr1" runat="server" visible="false">
                                                            <td style="text-align: left;">3. Name of Shop/Establishment <font color="red">*</font> </td>
                                                            <td style="">: </td>
                                                            <td style="text-align: left;">
                                                                <asp:TextBox ID="txtNameofShopAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtNameofShopAct1"
                                                                    ErrorMessage="Please Enter Name of the Shop/Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                            <tr runat="server" visible="false" id="trContratorDetls">
                                                <td style="width: 100%">
                                                    <table width="100%; margin-top: 20px; margin-bottom: 20px">
                                                        <tr>
                                                            <td colspan="8" style="font-weight: bold">
                                                                <asp:Label ID="lblHContrator" runat="server" Text="1. Name and address of the contractor(including his father's/ husband's name in case of individuals)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 200px">Name of the Contractor/Firm <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorName" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtContractorName" Display="None" ErrorMessage="Please Enter Address of Contractor (Name of the Contractor/Firm)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Mobile No.<font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorMobile" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtContractorMobile" Display="None" ErrorMessage="Please Enter Address of Contractor (Mobile Number)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Email Id.<font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorEmail" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtContractorEmail" Display="None" ErrorMessage="Please Enter Address of Contractor (Email)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Father's Name </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorFname" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtContractorFname" Display="None" ErrorMessage="Please Enter Address of Contractor (Father name)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Door No. <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorDoorNo" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtContractorDoorNo" Display="None" ErrorMessage="Please Enter Address of Contractor (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Locality <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorLocality" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtContractorLocality" Display="None" ErrorMessage="Please Enter Address of Contractor (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">District <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlContractorDistrict" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlContractorDistrict_SelectedIndexChanged">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlContractorDistrict"
                                                                    ErrorMessage="Please Select District Address of Contractor" InitialValue="--District--" Display="None"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlContractorMandal" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlContractorMandal_SelectedIndexChanged">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="ddlContractorMandal"
                                                                    ErrorMessage="Please Select Mandal Address of Contractor" InitialValue="--Mandal--" Display="None"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Village <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlContractorVillage" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlContractorVillage"
                                                                    ErrorMessage="Please Select Village Address of Contractor" InitialValue="--Village--" Display="None"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Pincode <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorPincode" MaxLength="6" runat="server" class="form-control txtbox" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtContractorPincode" Display="None" ErrorMessage="Please Enter Address of Contractor (Pincode)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="2">Note: If you are outside Telangana State, enter the address here </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Other State Address </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtContractorOtherStateAddress" runat="server" class="form-control txtbox" TextMode="MultiLine" Height="60px" TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                        </tr>
                                                        <tr style="height: 30px">
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                    <tr id="trcontractzone" runat="server" visible="false">
                                                <td class="auto-style1">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr id="trzone" runat="server" visible="false">
                                                            <td colspan="10">
                                                                <asp:Label ID="lblcontractzone" runat="server" Text="Please Select Zone" Font-Bold="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trzonechecklist" runat="server" visible="false">
                                                            <td style="padding: 15px; margin: 5px; text-align: left;">
                                                                <asp:CheckBoxList ID="chkzones" CssClass="checkcss" runat="server" RepeatDirection="Vertical" CellSpacing="20" Font-Bold="true">
                                                                    <asp:ListItem Value="Zone1" Text="Zone 1  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Adilabad, Karimnagar, Khammam, Warangal"></asp:ListItem>
                                                                    <asp:ListItem Value="Zone2" Text="Zone 2  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Mahbubnagar, Medak, Nalgonda, Nizambad, Ranga Reddy"></asp:ListItem>
                                                                    <asp:ListItem Value="Zone3" Text="Zone 3  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Hyderabad"></asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                                </td>
                                            </tr>

                                            <tr runat="server" visible="false" id="trContractorDob">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 20px; margin-bottom: 20px">
                                                        <tr>
                                                            <td style="text-align: left; width: 300px">
                                                                <asp:Label ID="lblHCDob" runat="server" Style="font-weight: bold; margin-right: 10px" Text="2. Date of birth (in case of individuals)"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px">
                                                                <asp:TextBox ID="txtContractorDob" runat="server" class="form-control txtbox" Height="28px" MaxLength="15" AutoPostBack="true" OnTextChanged="txtContractorDob_TextChanged" TabIndex="0" ToolTip="Date" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 45px"></td>
                                                            <td style="margin-left: 5px; width: 165px">
                                                                <asp:Label ID="lblHCAge" runat="server" Style="font-weight: bold; margin-left: 10px; margin-right: 10px" Text="Age"></asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtContractorAge" onkeypress="return inputOnlyNumbers(event)" runat="server" class="form-control txtbox" Height="28px" MaxLength="3" TabIndex="0" ToolTip="Number" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trGodown1">
                                            
                                            <td>
                                                <b>
                                                Location of Office, Godown, Warehouse or workplace attached to the shop/establishment
                                                but situated outside the premisis of it
                                                </b>
                                             
                                            </td>
                                            <%--<td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>--%>
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
                                                    <b>Please click on ADD,before Proceeding</b>
                                                </td>
                                            <td>
                                                <div id="flashingtext" style="font-size: 15px;">
                                                </div>
                                            </td>
                                        </tr>
                                            
                                            <tr runat="server" visible="false" id="trprincipalCert">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 20px; margin-bottom: 20px">
                                                        <tr id="trnoanddate1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left; padding-left: 0px; font-weight: bold" colspan="8">
                                                                <asp:Label ID="lblprincipalCert" runat="server" Text="Number and date of certificate of registration of the establishment under the act(of Principal Employer)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trnoanddate2" runat="server" visible="false" >
                                                            <td style="margin-left: 5px; width: 255px">
                                                                <asp:Label ID="Label2" runat="server" Style="font-weight: bold; margin-left: 10px; margin-right: 10px" Text="Number"></asp:Label></td>
                                                            <td style="margin-left: 5px; width: 250px">
                                                                <asp:TextBox ID="txtprincipalNumber" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="Number" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 45px"></td>
                                                            <td style="text-align: left; width: 165px; margin-left: 5px;">
                                                                <asp:Label ID="Label1" runat="server" Style="font-weight: bold; margin-right: 10px" Text="Date"></asp:Label>
                                                            </td>
                                                            <td style="margin-left: 5px;">
                                                                <asp:TextBox ID="txtdateprincipalemployer" runat="server" class="form-control txtbox" Height="28px" MaxLength="15" TabIndex="0" ToolTip="Date" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr id="truploadandworksers" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label3" runat="server" Text="Upload Principal Employers Registration Certificate"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" >
                                                                <div style="float: left">
                                                                    <asp:FileUpload ID="fluPrincipalEmployersRegistrationCertificate" Width="220px" runat="server" Height="28px" />
                                                                    <asp:Label ForeColor="Blue" runat="server" ID="Label6"></asp:Label>
                                                                </div>
                                                                <div style="float: left">
                                                                    &nbsp;&nbsp;&nbsp; 
                                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning" Height="30px" TabIndex="10" Text="Upload" Width="100px" OnClick="Button1_Click" />
                                                                </div>
                                                            </td>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; font-weight: bold">
                                                                <asp:Label ID="Label13" runat="server" Text="No of workers under all Contractors of the Principal Employer"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtprvprincipal" runat="server" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px" Enabled="true" MaxLength="6" Width="100px" AutoPostBack="false" ></asp:TextBox></td>
                                                           
                                                             <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtprvprincipal" Display="None" ErrorMessage="Please Enter No of workers under all Contractors of the Principal Employer" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trPostalAddress" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; padding-left: 0px; font-weight: bold" colspan="3">
                                                                <asp:Label ID="lblPostalAddress" runat="server" Text="4. Address of the Shop/Establishment"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="text-align: left; width: 160px">Door No. <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtShopDoorNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtShopDoorNo"
                                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Door No)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Locality <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtShopLocality" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtShopLocality" Display="None"
                                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="text-align: left">District <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlShopDistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlShopDistrict_SelectedIndexChanged">
                                                                                <asp:ListItem>--District--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlShopDistrict"
                                                                                ErrorMessage="Please Select District of Shop/Establishment" InitialValue="--District--" Display="None"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlShopMandal" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlShopMandal_SelectedIndexChanged">
                                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlShopMandal"
                                                                                ErrorMessage="Please Select Mandal of Shop/Establishment" InitialValue="--Mandal--" Display="None"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="text-align: left">Village <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlShopVillage" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlShopVillage"
                                                                                ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--" Display="None"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Pin Code <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtShopPincode"  runat="server" class="form-control txtbox" Height="28px" MaxLength="6" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtShopPincode"
                                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Pin Code)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trselectZone" visible="false">
                                            <td class="auto-style3">
                                                &nbsp;</td>
                                        </tr>
                                            <tr runat="server" visible="false" id="trEmployerDetails1Main">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr runat="server" visible="false" id="trEmployerDetails1">
                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                                <asp:Label ID="lblEmployer" runat="server" Text="5. Employer, Managing Partner or Managing Director as the case may be (Name, Father Name, Designation, Age, Mobile, e-Mail)"></asp:Label></td>
                                                        </tr>
                                                        <tr runat="server" visible="false" id="trEmployerDetails2">
                                                            <td colspan="4">
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Name <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="TxtnameofUnitAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TxtnameofUnitAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Name)" ValidationGroup="group" Display="none"> *</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Father's Name <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtPGNameAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px" OnTextChanged="txtPGNameAct1_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPGNameAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Father's Name)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Designation <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtDesigAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDesigAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Designation)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Age <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtAgeAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="4" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAgeAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Age)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mobile <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtMobileAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtMobileAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Mobile)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Email <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtEmailAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEmailAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Email)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false" id="trEmployerAddress1main">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr runat="server" visible="false" id="trEmployerAddress1">
                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                                <asp:Label ID="lblEmployerAddress" runat="server" Text="6. Residential address of the employer"></asp:Label></td>
                                                        </tr>
                                                        <tr runat="server" visible="false" id="trEmployerAddress2">
                                                            <td>
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Door No.<font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtDoorNoResidentialAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDoorNoResidentialAct1"
                                                                                ErrorMessage="Please Enter  Residential address of the employer (Door No)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Locality <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtLocalResidentialAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtLocalResidentialAct1"
                                                                                ErrorMessage="Please Enter  Residential address of the employer (Locality)" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">District <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlDistrictResidentialAct1" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px"
                                                                                OnSelectedIndexChanged="ddlDistrictResidentialAct1_SelectedIndexChanged" Width="220px">
                                                                                <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDistrictResidentialAct1"
                                                                                ErrorMessage="Please Select District of Employer" InitialValue="--District--" Display="None"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlMandalResidentialAct1" runat="server" class="form-control txtbox" Height="33px" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalResidentialAct1_SelectedIndexChanged">
                                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandalResidentialAct1"
                                                                                ErrorMessage="Please Select Mandal of Employer" InitialValue="--Mandal--" Display="None"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Village <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlVillageResidentialAct1" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                                ErrorMessage="Please Select Residential Village of the Employer (Village)" InitialValue="--Village--" Display="None"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                             <tr runat="server" visible="false" id="trprincpleemployee">
                                                <td>
                                                     <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                         <tr runat="server" visible="false" id="trDetailofPrinEmploy">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="Label31" runat="server" Text="Details of the Principal Employer"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trDetailofPrinEmploy1">
                                            <td colspan="3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" >
                                                            Name of Principal Employer<font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNamePrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtDoorNoResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" >
                                                           Door No & Locality <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDoornoPrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtLocalResidentialAct1"
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
                                                            <asp:DropDownList ID="ddlDistPrinEmploy" runat="server" AutoPostBack="True"
                                                                class="form-control txtbox" Height="33px"  
                                                                Width="180px" OnSelectedIndexChanged="ddlDistPrinEmploy_SelectedIndexChanged">
                                                                <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="ddlDistrictResidentialAct1"
                                                                ErrorMessage="Please Select District of Employer" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mandal <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalPrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalPrinEmploy_SelectedIndexChanged"  >
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="ddlMandalResidentialAct1"
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
                                                            <asp:DropDownList ID="ddlVillagePrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                ErrorMessage="Please Select Residential Village of the Employer (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Pin Code <font color="red" size="3">*</font></td>
                                                        <td>
                                                                                                                        <asp:TextBox ID="txtPrinEmployPincode" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>

                                                        </td>
                                                        <td colspan="2">
<font color="red"><b>Note:If you are outside Telangana State, enter the address here</b></font>
                                                        </td>
                                                        <td>

                                                        </td>
                                                        <td>
                                                            Other State Address
                                                        </td>
                                                        <td>
                                                                                                                        <asp:TextBox ID="txtOtherStateAddrPrinEmploy" runat="server" TextMode="MultiLine" class="form-control txtbox"
                                                                Height="40px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        
                                                        </td>
                                                    </tr>
                                                        
                                                     
                                                     
                                                </table>
                                            </td>
                                        </tr>
                                                         </table>
                                                    </td>
                                            </tr>
                                            <tr runat="server" id="trPermanentAddressofEstab" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>
                                                                    <asp:Label ID="lblPermanentAddress" runat="server" CssClass="LBLBLACK">3. Full name and Permanent Address of the establishment, if any <font color="red">*</font></asp:Label></strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 165px">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK"> Full Name <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtFullNamePermAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; width: 160px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK"> District <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrictPermAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictPermAct2_SelectedIndexChanged">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK"> Mandal <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMandalPermAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalPermAct2_SelectedIndexChanged">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK"> Village <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillagePermAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="220px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK"> Door No <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDoorNoPermAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK"> Pin Code <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPinCodePermAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="6" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false" id="trDirectorAddress">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>

                                                                    <asp:Label ID="lblDirector" runat="server" CssClass="LBLBLACK">4. Name and address of the Director / Partners (in case of companies/firm)</asp:Label></strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="110px"> Full Name <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDirFullName" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; width: 160px">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK"> Door No <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDirDoorNo" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK"> District <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDirDistrict" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="220px" OnSelectedIndexChanged="ddlDirDistrict_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="110px"> Mandal <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDirMandal" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="220px" OnSelectedIndexChanged="ddlDirMandal_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="110px"> Village/Town <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDirVillage" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="220px">
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trManagerResidenceAct1" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="10">
                                                                <asp:Label ID="lblManagerAddress" runat="server" Text="4. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment" Font-Bold="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">Name <font color="red" size="3">*</font> </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtManagerNameAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtManagerNameAct1" Display="None" ErrorMessage="Please Enter Full name and Address of the Manager or person(Name)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">Father&#39;s Name <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtManagerPGNameAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtManagerNameAct1" Display="None" ErrorMessage="Please Enter Full name and Address of the Manager or person(Father's Name)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Designation <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtManagerDesignationAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtManagerNameAct1" Display="None" ErrorMessage="Please Enter Full name and Address of the Manager or person(Designation)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Door No <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtManagerDoorNoAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtManagerNameAct1" Display="None" ErrorMessage="Please Enter Full name and Address of the Manager or person(Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Locality <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtManagerLocalityAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtManagerLocalityAct1" Display="None" ErrorMessage="Please Enter Full name and Address of the Manager or person(Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">District <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlManagerDistrictAct1" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlManagerDistrictAct1_SelectedIndexChanged">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlManagerMandalAct1" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlManagerMandalAct1_SelectedIndexChanged">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Village <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlManagerVillageAct1" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="110px">Mobile No <font color="red">*</font></asp:Label>
                                                            </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMobileNoManagerAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK">Email Id <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEmailManagerAct2" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Pincode <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtmanageragenpincode" runat="server" MaxLength="6" class="form-control txtbox" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 3px; margin-bottom: 3px;" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtmanageragenpincode" Display="None" ErrorMessage="Please Enter Pincode of Manager or person" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Address <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtmanageragenAddress" runat="server" class="form-control txtbox" TextMode="MultiLine" Height="60px" TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 3px; margin-bottom: 3px;" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtmanageragenAddress" Display="None" ErrorMessage="Please Enter Address of Manager or person" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false" id="trManagerorNot">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblManagerOrNot" runat="server" CssClass="LBLBLACK">Manager/Agent if any (with residential address):
                                                                <font color="red">*</font></asp:Label>
                                                <asp:RadioButtonList ID="Rd_ManagerResidenceAct1" runat="server" AutoPostBack="true"
                                                    RepeatDirection="Horizontal" Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                            <tr runat="server" visible="false" id="trcommencementdatecontractlabor">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 20px; margin-bottom: 20px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; padding-left: 0px; font-weight: bold" colspan="8">
                                                                <asp:Label ID="lblcommencementdatecontractlabor" runat="server" Text="Duration of the proposed contract work(give particulars of proposed date of commencing and ending)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="margin-left: 5px; width: 165px">
                                                                <asp:Label ID="lblcommececontract" runat="server" Style="font-weight: bold; margin-left: 10px; margin-right: 10px" Text="Commence Date"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="margin-left: 5px; width: 250px">
                                                                <asp:TextBox ID="txtcontractcommence" runat="server" class="form-control txtbox" Height="28px" MaxLength="3" TabIndex="0" ToolTip="Commence Date" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcontractcommence" Display="None" ErrorMessage="Please give particulars of proposed date of commencing and ending" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 45px"></td>
                                                            <td style="text-align: left; width: 165px; margin-left: 5px;">
                                                                <asp:Label ID="lblcontactend" runat="server" Style="font-weight: bold; margin-right: 10px" Text="End Date"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="margin-left: 5px;">
                                                                <asp:TextBox ID="txtEndDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="15" TabIndex="0" ToolTip="Date" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtEndDate" Display="None" ErrorMessage="Please give particulars of proposed date of commencing and ending" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trAgentOrMangerWorkSite" visible="false">
                                                <td>
                                                    <table width="100%" style="margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:Label ID="lblAgentOrMangerWorkSite" runat="server" Style="font-weight: bold; margin-right: 8px" Text="10. Name and address of the agent or manager of the contractor at the work-site"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Name <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtagentormanagername" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Door No. <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtagentormanagerdoorno" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                        </tr>


                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Locality <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtagentormanagerlocality" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">District <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlagentormanagerdistrict" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlagentormanagerdistrict_SelectedIndexChanged">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlagentormanagermandal" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="220px" OnSelectedIndexChanged="ddlagentormanagermandal_SelectedIndexChanged">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Village <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlagentormanagervillage" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>


                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Pincode <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtagentormanagerpincode" runat="server" MaxLength="6" class="form-control txtbox" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                            <td>Address <font color="red">*</font></td>
                                                            <td><asp:TextBox ID="txtagentormanageraddress" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false" id="trTypeOfEstablishment">
                                                <td colspan="4">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px">
                                                                <asp:Label ID="lblTypeOfEstablishment" runat="server" Style="font-weight: bold; margin-right: 8px" Text="6. Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlTypeOfBussiness" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="ddlTypeOfBussiness"
                                                                    ErrorMessage="Please Select Type of business" InitialValue="0" Display="None"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trCertRegEstablish" visible="false">
                                                <td colspan="4">
                                                    <table style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr ID="TRNAMEANDDATE" runat="server" visible="false">
                                                            <td colspan="7">
                                                                <asp:Label ID="lblCertRegEstablish" runat="server" Style="font-weight: bold; margin-right: 8px" Text="7. Number and date of certificate of registration of the establishment under the act"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="TRNUMANDDATE" runat="server" visible="false">
                                                            <td></td>
                                                            <td style="padding-left: 5px; width: 200px">
                                                                <asp:Label ID="Label4" runat="server" Text="Number :"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 260px">
                                                                <asp:TextBox ID="txtEstRegNumber" runat="server" class="form-control txtbox" Height="28px" onkeypress="NumberOnly()" TabIndex="0" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtEstRegNumber" Display="None" ErrorMessage="Please Enter  certificate of registration of the establishment(Number)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-left: 5px; width: 160px">
                                                                <asp:Label ID="Label5" runat="server" Text="Date :"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtRegEstdate" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" Width="220px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegEstdate"></cc1:CalendarExtender>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtEstRegNumber" Display="None" ErrorMessage="Please Enter  certificate of registration of the establishment(Date)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>
                                                        <tr style="height: 20px">
                                                            <td></td>
                                                        </tr>
                                                        <tr ID="TRPEREGCERT" runat="server" visible="false">
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label16" runat="server" Text="P.E. Regitration Certificate :"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="5">
                                                                <div style="float: left">
                                                                    <asp:FileUpload ID="fupPERCert" Width="220px" runat="server" Height="28px" />
                                                                    <asp:Label ForeColor="Blue" runat="server" ID="lblPERCert"></asp:Label>
                                                                </div>
                                                                <div style="float: left">
                                                                    &nbsp;&nbsp;&nbsp; 
                                                                    <asp:Button ID="btnPERCert" runat="server" CssClass="btn btn-xs btn-warning" Height="30px" TabIndex="10" Text="Upload" Width="100px" OnClick="btnPERCert_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trNatureofBusinessAct1" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px">
                                                                <asp:Label ID="lblNatureofBusiness" runat="server" Text="8. Nature of business *" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtNatureofBusinessAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNatureofBusinessAct1" ErrorMessage="Please Enter Nature of business " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trDateofCommencement" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px">
                                                                <asp:Label ID="lblDateofCommencement" runat="server" Text="9. Date of Commencement of business *" Font-Bold="true"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2new" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateofCommenceAct1">
                                                                </cc1:CalendarExtender>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtDateofCommenceAct1" ErrorMessage="Please Enter Estimated date of commencement " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trTotalEmps" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>

                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px; font-weight: bold">
                                                                <asp:Label ID="lblTotalEmps" runat="server" Text="11. Total No. of Employees "></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtTotalEmployees" runat="server" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px" Enabled="false" MaxLength="6" Width="100px" AutoPostBack="True" OnTextChanged="txtTotalEmployees_TextChanged"></asp:TextBox></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trCompletionDate" runat="server" visible="false">
                                                <td colspan="4">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px; font-weight: bold">
                                                                <asp:Label ID="lblCompletionDate" runat="server" CssClass="LBLBLACK" Font-Bold="true">7. Estimated date of completion of building or other construction work </asp:Label><font color="red" size="3"><font color="red"> *</font></font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstDateCompAct2" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEstDateCompAct2" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtEstDateCompAct2" ErrorMessage="Please Enter Estimated date of completion " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trMaxMigrantEstabDate" visible="false">
                                                <td colspan="4">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px; font-weight: bold">
                                                                <asp:Label ID="lblMaxMigrantNo" runat="server" Style="font-weight: bold; margin-right: 8px" Text="12. Maximum Number of migrant workmen proposed to be employed in the establishment on any date"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font> </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMaxMigrantNo" runat="server" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px" TabIndex="0" Width="220px" onblur="CalulateSecurityPayable(this);"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtMaxMigrantNo" ErrorMessage=" Maximum Number of migrant workmen proposed to be employed " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trOptions" runat="server" visible="false">
                                                <td colspan="4">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px; font-weight: bold">
                                                                <asp:Label ID="lblOption1" runat="server" Style="font-weight: bold; margin-right: 8px" Text="13. Whether the contractor was convicted of any offence within the preceding five years. If so give details"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td>
                                                                <div style="margin-left: 10px;">
                                                                    <asp:RadioButtonList ID="rdlOptList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdlOptList1_SelectedIndexChanged" Width="100px" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtOpt1" ErrorMessage="Please Enter Whether the contractor was convicted Details " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtxtOp1" runat="server" visible="false">
                                                            <td></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOpt1" TextMode="MultiLine" runat="server" Height="28px" class="form-control txtbox"
                                                                    TabIndex="0" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="3" style="height: 20px;">&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblOption2" runat="server" Style="font-weight: bold; margin-right: 8px" Text="14. Whether there was any order against the contractor revoking or suspending license or forefeiting security deposits in respect of an earlier contract . If so the date of such order."></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td>
                                                                <div style="margin-left: 10px;">
                                                                    <asp:RadioButtonList ID="rdlOptList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdlOptList2_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtOpt2" ErrorMessage="Please Enter Whether there was any order against.if so date " Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtxtOp2" runat="server" visible="false">
                                                            <td></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOpt2" runat="server" Height="28px" class="form-control txtbox"
                                                                    TabIndex="0" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtOpt2">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 20px;">&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblOption3" runat="server" Style="font-weight: bold; margin-right: 8px" Text="15. Whether the contractor has worked in any other establishment within the past five years, If so, give details of the Principal Emplyer,Establishments and nature of work"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>
                                                            <td>
                                                                <div style="margin-left: 10px;">
                                                                    <asp:RadioButtonList ID="rdlOptList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdlOptList3_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtOpt3" ErrorMessage="Please Enter Whether the contractor has worked in any other Details" Display="None" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtxtOp3" runat="server" visible="false">
                                                            <td></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOpt3" TextMode="MultiLine" runat="server" Height="28px" class="form-control txtbox"
                                                                    TabIndex="0" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false" id="trPrinEmpFrmV">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblPrinEmpFrmV" runat="server" Style="font-weight: bold; margin-right: 8px" Text="16. Whether a certificate by the Principal Employer in Form V is enclosed"></asp:Label>
                                                                <font color="red" size="3"><font color="red">*</font></font>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 10px; text-align: left;">
                                                                <div style="float: left; margin-left: 15px">
                                                                    <asp:FileUpload ID="FuEmpFrmV" runat="server" Width="220px" Height="28px" />
                                                                    <asp:Label ID="lblEmpFrmV" ForeColor="Blue" runat="server"></asp:Label>
                                                                </div>
                                                                <div style="float: left; margin-left: 15px">
                                                                    <asp:Button ID="BtnFuEmpFrmV" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="BtnFuEmpFrmV_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trDeposit" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:Label ID="lblHDeposit" runat="server" Style="font-weight: bold; margin-right: 8px" Text="17. Security Deposit Details"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">Amount paid (Rs) <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAmountPaid" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtAmountPaid" Display="None" ErrorMessage="Please Enter Security Deposit Amount paid" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Amount payable (Rs) <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAmountPayable" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" Width="220px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtAmountPayable" Display="None" ErrorMessage="Please Enter Security Deposit Amount Payable" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Challan No. <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtChallanNo" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtChallanNo" Display="None" ErrorMessage="Please Enter Security Deposit Challan No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Attach Challan <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <div style="float: left">
                                                                    <asp:FileUpload ID="fucAttachChallan" runat="server" Width="220px" Height="28px" />
                                                                    <asp:Label ID="lblAttachChallan" ForeColor="Blue" runat="server"></asp:Label>
                                                                    <%--<asp:HyperLink ID="lnkEmpFrmV" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>--%>
                                                                    <%--<asp:CustomValidator ValidateEmptyText="true" ControlToValidate="txtEmpFrmV"  ClientValidationFunction="Check(txtEmpFrmV)" Display="None" ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" ValidationGroup="group"></asp:CustomValidator>--%>
                                                                </div>
                                                                <div style="float: left">
                                                                    <asp:Button ID="btnAttachChallan" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnAttachChallan_Click" />
                                                                </div>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 3px; margin: 3px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Challan Date. <font color="red" size="3"><font color="red">*</font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtchallandate" runat="server" class="form-control txtbox" Height="28px" TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtchallandate" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtchallandate" Display="None" ErrorMessage="Please select challan date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"> <font color="red" size="3"><font color="red"></font></font></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trContractorDetailsAct4" runat="server" visible="false">
                                                <td>
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td colspan="7"><strong>
                                                                <asp:Label ID="lblContractor" runat="server" CssClass="LBLBLACK" Font-Bold="true">7. Particulars of Contractors and migrant workmen</asp:Label>
                                                            </strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:GridView ID="gvContractorAct4" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvContractorAct4_RowCommand" OnRowDataBound="gvContractorAct4_RowDataBound">
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
                                                                                <asp:TextBox ID="txtContractorNameAct4" runat="server" Height="25px" Width="150px" class="form-control txtbox"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorAddressAct4" runat="server"  TextMode="MultiLine" style="height: 102px; width: 155px;" class="form-control txtbox"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mobile No.">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorMobileNoAct4" runat="server" Height="25px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Nature of Work">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorNatureAct4" runat="server" Height="25px" class="form-control txtbox"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Maximum No. of Migrant Workmen">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorMaximumNoAct4" runat="server" AutoPostBack="true" Height="25px" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="GetTotalWorkMan" Width="80px" class="form-control txtbox"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Date of Commencement">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorCommenceAct4" runat="server" Height="25px" class="form-control txtbox"></asp:TextBox>
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
                                                                                <asp:TextBox ID="txtManufacturingDepts" runat="server" style="height: 102px; width: 155px;" TextMode="MultiLine" class="form-control txtbox"></asp:TextBox>
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
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                                    <table style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; padding-left: 0px; text-align: left; width: 750px; font-weight: bold">
                                                                <strong>Total No.of Contract Employees * :</strong> </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtTotalContractors" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="54px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trsubmitactual" runat="server">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave1_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px" OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext0" runat="server" CausesValidation="False" CssClass="btn btn-danger" Height="32px" OnClick="btnNext0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr id="trsubmitqury" runat="server" visible="false">
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnsubmitform" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnsubmitform_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                </td>
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


                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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

    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>

    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
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
            
             $("input[id$='txtcontractcommence']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtdateprincipalemployer']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); 
            $("input[id$='txtStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtEndDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
             $("input[id$='txtRegEstdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtContractorDob']").datepicker(
                {
                    dateFormat: "yy/mm/dd",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtPartEstablDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtMaxoEmployees']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtchallandate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
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
             $("input[id$='txtdateprincipalemployer']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
             $("input[id$='txtRegEstdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); 
            $("input[id$='txtcontractcommence']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); 
            $("input[id$='txtStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtEndDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtContractorDob']").datepicker(
                {
                    dateFormat: "yy/mm/dd",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtPartEstablDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtMaxoEmployees']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
                $("input[id$='txtchallandate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <script type="text/javascript">
        var v_message = '';
        var n_errorcount = 0;
        function isEmpty(val) {
            if (val.length == 0) return true;
            return false;
        }
        function addErrorMessage(msg) {
            n_errorcount = n_errorcount + 1;
            v_message = v_message + " - " + msg + "</br>";
        }
        function displayErrors() {
            if (n_errorcount == 0) {
                return true;
            }
            else {
                alert('Please check the following:\n\n' + v_message);
                v_message = '';
                n_errorcount = 0;
                return false;
            }
            return false;
        }

        function Check(sender, args) {
            debugger;
            console.log(args);
            var v = args[0].val;
            console.log(v);
            if (v == "") {
                args.IsValid = false;
            }

        }


        function CalulateSecurityPayable(e) {
            var count = e.value;

            if (count != undefined && count >= 0) {
                var amount = 1400 * count;
                $("input[id$='txtAmountPayable']").val(amount);
            }
            else if (count == "") {
                $("input[id$='txtAmountPayable']").val('');
            }
            console.log(e.value);
        }

        $(function () {
            var count = $("input[id$='txtMaxMigrantNo']").val();
            if ($.trim(count) != "") {
                var amount = 1400 * count;
                $("input[id$='txtAmountPayable']").val(amount);
            }
        });
    </script>

    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 220px;
            padding: 0.2em 0.2em 0;
            width: 220px;
        }
        .auto-style1 {
            height: 230px;
        }
    </style>
</asp:Content>
