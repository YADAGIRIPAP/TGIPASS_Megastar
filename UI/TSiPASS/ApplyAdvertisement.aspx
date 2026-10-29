<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ApplyAdvertisement.aspx.cs" Inherits="UI_TSiPASS_ApplyAdvertisement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
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
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }

        .LBLBLACK {
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

        .style5 {
            width: 13px;
        }

        .style6 {
            width: 203px;
        }

        .auto-style6 {
            width: 858px;
        }

        .auto-style7 {
            height: 57px;
        }

        .auto-style8 {
            width: 192px;
            height: 57px;
        }

        .auto-style9 {
            width: 10px;
            height: 57px;
        }

        .auto-style10 {
            margin-top: 0;
            margin-bottom: 0;
            font-size: 16px;
            color: white;
            width: 100%;
            text-align: left;
        }
    </style>
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("You cannot select a day olderr than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }

        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtstartdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtenddate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtrentorleasedeeddate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodfrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodto']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtstartdate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)

                });

            $("input[id$='txtenddate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtoccupancycertificatedate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodfrom']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodto']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
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
    <script type="text/javascript" language="javascript">
        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;
                alert("Enter DecimalValues Only");
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function NumberhyphenOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 45) || (AsciiValue == 47))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter NumericValues, '/', '-' Only");
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>


    <script type="text/javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter NumericValues Only");
            }
        }

    </script>
    <script type="text/javascript" language="javascript">
        function CharOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Charcters Only");
            }
        }
    </script>
    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">Advertismenr</i>
            </li>
          <%--  <li class="active">
                <i class="fa fa-edit"></i><a href="#">ADVERTISEMENT Details</a>
            </li>--%>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel-heading" align="center" style="background-color: forestgreen">
                    <h3 class="auto-style10">ADVERTISEMENT</h3>
                </div>
                <div id="Div1" class="panel panel-primary"  runat="server">
                    <div class="panel-body">
                        <table align="center" style="width: 100%">
                            <tr>
                                <th>District<font color="red">*</font></th>
                                <th>Mandal<font color="red">*</font></th>
                                <th>Village<font color="red">*</font></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddl_district" runat="server" class="form-control txtbox"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" Height="33px" Width="180px" TabIndex="1">
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_mandal" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_village" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_village_SelectedIndexChanged"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" style="width: 100%" runat="server" visible="false" id="tbl_appdetails">
                            <tr>
                                <th>Applicant/Advertiser Mobile Number<font color="red">*</font></th>
                                <th>Applicant/Advertiser EmailID<font color="red">*</font></th>
                                <th>Applicant/Advertiser Name<font color="red">*</font></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_appmobileno" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_appemail" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_applicantName" runat="server" class="form-control txtbox" onkeypress="Names()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_cdmaappdetails" visible="false" style="width: 100%">
                            <tr>
                                <th>Applicant/Advertisment Surname Name<font color="red">*</font></th>
                                <th>Pan Number<font color="red">*</font></th>
                                <th>Adhar Number<font color="red">*</font></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_applicantsurname" runat="server" class="form-control txtbox" onkeypress="Names()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_pannumber" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AdharNumber" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_ghmclicenumber" visible="false" style="width: 100%">
                            <caption>
                                <h4><b>Continue with ?</b></h4>
                            </caption>
                            <tr>
                                <th>Trade License Number
        <asp:RadioButton ID="rbd_tradelicensenumber" runat="server" />
                                </th>
                                <th>Provisional License Number
        <asp:RadioButton ID="rdb_provisionallicense" runat="server" />
                                </th>
                                <th>Without License Number
        <asp:RadioButton ID="rdb_withoutlicense" runat="server" />
                                </th>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                         <table align="center" runat="server" id="Table1" visible="false" style="width: 100%">
                            <tr>
                                <th>Trade License NO</th>
                                
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txttradelicenseno" runat="server" class="form-control txtbox" 
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                
                                
                            </tr>
                        </table>
                        <table align="center" runat="server" id="tbl_ghmctrade" visible="false" style="width: 100%">
                            <tr>
                                <th>Trade Name</th>
                                <th>Trader License Holder</th>
                                <th>Address</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_ghmctradename" runat="server" class="form-control txtbox" onkeypress="Names()" 
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmctradelicensenumber" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmcaddress" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_ghmcarea" visible="false" style="width: 100%">
                            <tr>
                                <th>Area</th>
                                <th>StreetName</th>
                                <th>Locatlity</th>
                            </tr>
                            <tr>
                                 <td>
                                    <asp:DropDownList ID="ddl_ghmcarea" runat="server" class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                    <asp:ListItem Value="1" Selected="True">All Metro Corridors</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Appstreet" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmclocality" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_ghmcbuildingvalues" visible="false" style="width: 100%">
                            <tr>
                                <th>Height of Building(in sq.mts)</th>
                                <th>Width of Building (in sq.mts)</th>
                                <th>Trade Permise Frontage Area</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_ghmcheightofbuilding" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmcwidthofbuilding" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmctradepermisearea" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_ghmcadvcat" visible="false" style="width: 100%">
                            <tr>
                                <th>AdvertismentType</th>
                                <th>Advertisment content</th>
                                <th>Categoery</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddl_ghmcadvertismenttype" runat="server" class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                    <asp:ListItem Value="1" Selected="True">Neon And Glow Sign Boards</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmcadvertismentcontent" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmccategory" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center"  id="tbl_ghmcadvmts" runat="server" visible="false" style="width: 100%">
                            <caption>
                               
    
                            </caption>
                            <tr>
                                <th>EMD</th>
                                <th>Advertisment Height(in Mts)</th>
                                <th>Advertisment Width(in Mts)</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_ghmcemd" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmcadvehight" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmcadvwidth" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
<td>
 Whether Apply for the frist time
</td>
                                <td>
  <asp:RadioButtonList ID="rdb_ghmcfirsttime" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Text="yes" Value="Y"></asp:ListItem>
          <asp:ListItem Text="No" Value="N"></asp:ListItem>
      </asp:RadioButtonList>
                                </td>
                                <td>

                                </td>
                            </tr>



                       </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_ghmcadvfee" visible="false" style="width: 100%">

                            <tr>
                                <th>Advertisment Rate(Per.sqmts)</th>
                                <th>Advertisment fee</th>
                                <th>Advertisment Photo</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_ghmcadvertismentrate" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_ghmcadvfee" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:FileUpload ID="fpd_ghmcadvphoto" runat="server" />
                                    <asp:Label ID="lbl_ghmcadvphotoname" runat="server" />
                                    <asp:HyperLink ID="HyperLinkProofofAddress" runat="server" />
                                    <asp:HiddenField ID="hdnProofofAddressType" runat="server" />
                                    <asp:HiddenField ID="hdnFileNameProofofAddress" runat="server" />
                                    <asp:Button ID="btn_ghmcuploadphoto" runat="server" Text="Upload" OnClick="btn_ghmcuploadphoto_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_cdmaappcontdetails" visible="false" style="width: 100%">
                            <caption>Applicant Contact Details</caption>
                            <tr>
                                <th>Locality</th>
                                <th>Zone<font color="red">*</font></th>
                                <th>Ward<font color="red">*</font></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddllocality" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">ULB1</asp:ListItem>
                                        <asp:ListItem Value="2">ULB2</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlzone" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">ULB1</asp:ListItem>
                                        <asp:ListItem Value="2">ULB2</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlward" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">ULB1</asp:ListItem>
                                        <asp:ListItem Value="2">ULB2</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Block Number<font color="red">*</font></td>
                                <td>City</td>
                                <td>ULB</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlblocknumber" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">ULB1</asp:ListItem>
                                        <asp:ListItem Value="2">ULB2</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AppCity" runat="server" class="form-control txtbox" Height="28px"
                                        TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlulb" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">ULB1</asp:ListItem>
                                        <asp:ListItem Value="2">ULB2</asp:ListItem>
                                    </asp:DropDownList>
                                </td>



                            </tr>
                            <tr>
                                <td>Door No<font color="red">*</font></td>
                                <td>Address</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_appdoorno" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_appaddress" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_cdmaadvlocdetails" visible="false" style="width: 100%">
                            <caption>Advertisement Location Details</caption>
                            <tr>
                                <th>LandMark of Building/Premises</th>
                                <th>Door Number<font color="red">*</font></th>
                                <th>Building Assessment Number<font color="red">*</font></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtlandmark" runat="server" class="form-control txtbox" onkeypress="CharOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdoornmber" runat="server" class="form-control txtbox" onkeypress="NumberhyphenOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbuildingassesmentnumber" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Owner Name(Building/Premises)<font color="red">*</font></td>
                                <td>Address</td>
                                <td>City</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtownername" runat="server" class="form-control txtbox" onkeypress="Names()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtaddress" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcity" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_cdmaadvsubcat" visible="false" style="width: 100%">
                            <caption>Advertisement Category</caption>

                            <tr>
                                <th>Advertisement Category</th>
                                <th>Unit Name</th>
                                <th>Advertisement Sub Category</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddladvertisementcategoery" runat="server" class="form-control txtbox"
                                        OnSelectedIndexChanged="ddladvertisementcategoery_SelectedIndexChanged" AutoPostBack="true" Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">advertisecategoery1</asp:ListItem>
                                        <asp:ListItem Value="2">advertisecategoery2</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtunitname" runat="server" class="form-control txtbox" onkeypress="Names()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddladvertisementsubcategoery" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">adversubcategoery1</asp:ListItem>
                                        <asp:ListItem Value="2">adversubcategoery2</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Land OwnerShip</td>
                                <td>Wheather it is Hoarding or Non-Hoarding Advertisement<font color="red">*</font></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddllandownership" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Central Govt. Bilding</asp:ListItem>
                                        <asp:ListItem Value="2">House Owned Under EWSHS</asp:ListItem>
                                        <asp:ListItem Value="3">State Govt. Bilding</asp:ListItem>
                                        <asp:ListItem Value="4">Private Bildings</asp:ListItem>
                                        <asp:ListItem Value="5">Private Bildings-Companies</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbthoarding" runat="server" AutoPostBack="true" TextAlign="Right" RepeatDirection="Horizontal" Width="282px" TabIndex="1" OnSelectedIndexChanged="rbthoarding_SelectedIndexChanged">
                                        <asp:ListItem Value="H">HOARDING</asp:ListItem>
                                        <asp:ListItem Value="NH">NON-HOARDING</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_cdmanonhoarding" visible="false" style="width: 100%">
                            <caption>Non Hoarding Details</caption>
                            <tr>
                                <th>Length in mts/Nos<font color="red">*</font></th>
                                <th>Total Area</th>
                                <th>Width in mts<font color="red">*</font></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtlengthinmtsornos" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttotalarea" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtwidthinmts" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Details</td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtdetails" runat="server" class="form-control txtbox" Height="28px"
                                        onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center" runat="server" id="tbl_cdmaadvdates" visible="false" style="width: 100%">
                            <caption>Advertisement Details</caption>
                            <tr>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Any Other PartiCulars</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtstartdate" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtenddate" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtanyotherparticulars" runat="server" class="form-control txtbox" onkeypress="Names()"
                                        Height="28px" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trfacing" runat="server">
                                <td>Facing</td>
                                <td>
                                    <asp:DropDownList ID="ddlfacing" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="1">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">North</asp:ListItem>
                                        <asp:ListItem Value="2">South</asp:ListItem>
                                        <asp:ListItem Value="3">East</asp:ListItem>
                                        <asp:ListItem Value="4">West</asp:ListItem>
                                        <asp:ListItem Value="5">East and South</asp:ListItem>
                                        <asp:ListItem Value="6">East and North</asp:ListItem>
                                        <asp:ListItem Value="7">West and South</asp:ListItem>
                                        <asp:ListItem Value="8">West and North</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td></td>
                            </tr>
                        </table>

                    </div>
                </div>
                <div style="padding: 5px; margin: 5px; text-align: center;">
                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                        CssClass="btn btn-warning" Height="32px" TabIndex="10"
                        Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group"
                        Width="90px" />
                    &nbsp;&nbsp;
                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False"
                                        CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10"
                                        Text="Save" ValidationGroup="group" Width="90px" />
                    &nbsp; &nbsp;
                                    <asp:Button ID="btnNext0" runat="server" Visible="false"
                                        CssClass="btn btn-danger" Height="32px" OnClick="btnNext0_Click" TabIndex="10"
                                        Text="Previous"
                                        Width="90px" />
                    &nbsp; &nbsp;  
                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger"
                                        Height="32px" OnClick="btnNext_Click" TabIndex="10" Text="Payment"
                                        ValidationGroup="group" Width="90px" />
                </div>

                <div id="success" runat="server" visible="false" style="text-align: center" class="alert alert-success">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>
                <div id="Failure" runat="server" visible="false" style="text-align: center" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Warning!</strong>
                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                </div>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                <asp:HiddenField ID="hdnflagapprovalid" runat="server" />
                <asp:HiddenField ID="hdnidentityid" runat="server" />
                <br />
                <asp:HiddenField ID="hdfpencode" runat="server" />
                <asp:HiddenField ID="hdnapplicationid" runat="server" />
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
</asp:Content>

