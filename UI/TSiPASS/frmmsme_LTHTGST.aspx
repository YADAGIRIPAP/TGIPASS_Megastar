<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmmsme_LTHTGST.aspx.cs" Inherits="UI_TSiPASS_frmmsme_LTHTGST" MasterPageFile="~/UI/TSIPASS/EmptyMaster.master" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function pageLoad() {
            var date = new Date();
            var yrRange = "1900:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();


            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange


                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "1990:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    maxDate: dateToday
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
       function pageLoad() {
           var date = new Date();
           var currentMonth = date.getMonth();
           var currentDate = date.getDate();
           var currentYear = date.getFullYear();

           $("input[id$='txtLoanDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
       }
       $(function () {
           var date = new Date();
           var currentMonth = date.getMonth();
           var currentDate = date.getDate();
           var currentYear = date.getFullYear();
           $("input[id$='txtLoanDate']").datepicker(
               {
                   //dateFormat: "dd/mm/yy",
                   dateFormat: "dd/mm/yy",
                   maxDate: new Date(currentYear, currentMonth, currentDate)
               });
       });
    </script>--%>
    <%--<script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtLoanDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtLoanDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>--%>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "1900:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "1990:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnFirstGrid" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <%-- <div class="col-md-12">
                            <h1 class="page-head-line" align="left" style="font-size: x-large">TS - INDUSTRY CATALOGUE</h1>
                        </div>--%>
                        <div class="panel-body">
                        <div class="row">
                        </div>
                        <div class="row">
                        </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large">
                                    TS - INDUSTRY CATALOGUE</h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>UNIT DETAILS</b></h4>
                                </div>
                            </div>
                            <div class="some-class">
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        1.Unit Name :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtUnitName" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="50" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtUnitName"
                                        ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        2. PartII/SSI/Udyogaadhar Memorundum/ IEM / IL ID : </label>
                                    <asp:TextBox ID="txtUAMID" autocomplete="off" runat="server" AutoPostBack="True"
                                        class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtUAMID"
                                        ErrorMessage="Please enter UAMID" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        3.Category : <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">MEGA</asp:ListItem>
                                        <asp:ListItem Value="2">LARGE</asp:ListItem>
                                        <asp:ListItem Value="3">MEDIUM</asp:ListItem>
                                        <asp:ListItem Value="4">SMALL</asp:ListItem>
                                        <asp:ListItem Value="5">MICRO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        4.District :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddldistrict" runat="server"  class="form-control txtbox" Enabled="false"
                                        Height="33px" TabIndex="1" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddldistrict"
                                        ErrorMessage="Please select  District" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        5.Mandal :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px" Enabled="true"
                                        Width="180px"  TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal"
                                        ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        6.Complete Unit Address : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtunitaddress" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtunitaddress"
                                        ErrorMessage="Please enter Unit Address" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        7. Investment in Lakhs :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtinvestment" autocomplete="off" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                        Height="28px" MaxLength="6" onkeypress="return isNumberKey(event,this)" TabIndex="1"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtinvestment"
                                        ErrorMessage="Please enter Investment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        8. Employment :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtEmployment" autocomplete="off" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtEmployment"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        9. Whether the unit is in Industrial estate or Park/Not <font color="red">*</font></label>
                                    <asp:RadioButtonList ID="rdunitIEORNOT" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div id="Div1" class="col-sm-4 form-group" runat="server" visible="false" align="left">
                                    <label class="formlabel">
                                        10. Date of Capture : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtDate" runat="server" AutoComplete="off" class="form-control txtbox"
                                        Height="28px" MaxLength="15" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                        ErrorMessage="Please Select Date" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        10. Present Status <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Working</asp:ListItem>
                                        <asp:ListItem Value="2">Closed</asp:ListItem>
                                        <asp:ListItem Value="3">Other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlstatus"
                                        ErrorMessage="Please select Present Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left" id="otherstatus" runat="server" visible="false">
                                    <label class="formlabel">
                                        10 a. Other Status <font color="red">*</font></label>
                                    <asp:TextBox ID="txtOtherStatus" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </div>
                            </div>
                            <%--  Adding New Fields--%>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        11. Type Of Industry : <font color="red">*</font>
                                    </label>
                                    <asp:DropDownList ID="ddlConst_of_unit" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="ddlConst_of_unit"
                                        ErrorMessage="Please select Type Of Industry" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        12. Date Of Commencement of Production <font color="red">*</font></label>
                                    <asp:TextBox ID="txtDateOfCommencement" AutoPostBack="true" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" OnTextChanged="txtDateofCommencement_TextChanged"
                                        onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDateOfCommencement"
                                        ErrorMessage="Please enter  Date Of Commencement of Production" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        13. Type Of Connection : <font color="red">*</font></label>
                                    <asp:RadioButtonList ID="RdtypeofConn" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1"  Selected="True">LT</asp:ListItem>
                                        <asp:ListItem Value="2" >HT</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        14. Does Unit Export <font color="red">*</font></label>
                                    <asp:RadioButtonList ID="rdnUnitExport" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="rdnUnitExport_SelectedIndexChanged">
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlstatus"
                                        ErrorMessage="Please select Present Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left" id="divcountry" runat="server" visible="false">
                                    <label class="formlabel">
                                        15a. Major Export to Which countries <font color="red">*</font></label>
                                    <asp:TextBox ID="txtEXPORTCOUNTRY" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </div>
                            </div>
                            <%--    //upto Here--%>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>ENTREPRENEUR DETAILS</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        1.Name of Entrepreneur : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtNameofEntrepreneur" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameofEntrepreneur"
                                        ErrorMessage="Please enter Name of Entrepreneur" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        2.Mobile No :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtMObileNo" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                        onblur="checkLength(this)" Width="180px" AutoPostBack="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMObileNo"
                                        ErrorMessage="Please enter Your Mobile number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMObileNo"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        3.Email:<font color="red"></font></label>
                                    <asp:TextBox ID="txtEmail" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please Enter Email Id" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        4.Social Status : <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" TabIndex="1"
                                        Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">OC</asp:ListItem>
                                        <asp:ListItem Value="2">OBC</asp:ListItem>
                                        <asp:ListItem Value="3">SC</asp:ListItem>
                                        <asp:ListItem Value="4">ST</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlCaste"
                                        ErrorMessage="Please enter Caste" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        5.Is Promoter Differently Abled :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlDifferentlyabled" runat="server" class="form-control txtbox"
                                        TabIndex="1" Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDifferentlyabled"
                                        ErrorMessage="Please Select Differently Abled" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        6.Is Promoter Women:<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlWomenEnterprenuer" runat="server" class="form-control txtbox"
                                        TabIndex="1" Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlWomenEnterprenuer"
                                        ErrorMessage="Please Select Women Enterprenuer" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>PRODUCT DETAILS</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 form-group" align="left">
                                    <label class="formlabel">
                                        1. Sector :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="33px"
                                        Width="230px" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged" AutoPostBack="true" Enabled="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlSector"
                                        ErrorMessage="Please select Sector" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                </div>
                                <asp:HiddenField ID="HDNUNITNAME" runat="server" />
                                <asp:HiddenField ID="HDNLOAID" runat="server" />
                                <asp:HiddenField ID="HDNIDENTITYID" runat="server" />
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        2. Line of Activity :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                        Height="33px" Width="430px" Enabled="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlintLineofActivity"
                                        ErrorMessage="Please select  Line of Activity" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                </div>

                                <div id="Div2" class="col-sm-4 form-group" align="left" runat="server">
                                    <label class="formlabel">
                                        3. Category by PCB <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlCategorybyZone" runat="server" class="form-control txtbox"
                                        TabIndex="1" Height="33px" Width="180px" Enabled="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">WHITE</asp:ListItem>
                                        <asp:ListItem Value="2">GREEN</asp:ListItem>
                                        <asp:ListItem Value="3">ORANGE</asp:ListItem>
                                        <asp:ListItem Value="4">RED</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlCategorybyZone"
                                        ErrorMessage="Please select Category Zone" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div id="Div3" class="col-sm-4 form-group" runat="server" visible="false" align="left">
                                    <label class="formlabel">
                                        2.Product Specification(if any) :
                                    </label>
                                    <asp:TextBox ID="txtProductSpec" autocomplete="off" runat="server" AutoPostBack="True"
                                        class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h5 class="text-blue font-SemiBold">
                                        ITEMS MANUFACTURED</h5>
                                </div>
                            </div>
                            <div class="row">
                                <div class="rowcol">
                                    <div class="col-xs-12 col-sm-2">
                                        <label class="formlabel control-label">
                                            1.Item <font color="red">*</font></label>
                                        <asp:TextBox ID="txtManfitem" autocomplete="off" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtManfitem" ErrorMessage="Please enter Item" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12 col-sm-2">
                                        <label class="formlabel">
                                            2.Quantity Per Annum <font color="red">*</font></label>
                                        <asp:TextBox ID="txtManfquantityperannum" autocomplete="off" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()"  TabIndex="1"
                                            ValidationGroup="group"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtManfquantityperannum" ErrorMessage="Please select Manf Item Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12 col-sm-2">
                                        <label class="formlabel">
                                            3. Production In Units <font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlManfquantityin" runat="server" class="form-control txtbox"
                                            AutoPostBack="True" Height="33px" TabIndex="1" OnSelectedIndexChanged="ddlManfquantityin_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="KG">KG</asp:ListItem>
                                            <asp:ListItem Value="Tons">Tons</asp:ListItem>
                                            <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                            <asp:ListItem Value="Others">Others</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12 col-sm-2" style="margin-top: -20px;" id="trothers" runat="server"
                                        visible="false">
                                        <label class="formlabel">
                                            3a.others <font color="red"></font>
                                        </label>
                                        <asp:TextBox ID="txtMfgothers" autocomplete="off" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please select Quantity(Per Annum)" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12 col-sm-3">
                                        <label class="formlabel">
                                            4.Upload Photo of Unit (If Any)<font color="red"></font></label>
                                        <asp:FileUpload ID="fpdSketch" runat="server" class="form-control txtbox" Height="33px" />
                                        <asp:HyperLink ID="hplSketch" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        <br />
                                        <%-- <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>--%>
                                    </div>
                                    <div class="col-xs-12 col-sm-3">
                                        <label class="formlabel">
                                            5.Other Product Related Details (If Any)</label>
                                        <asp:TextBox ID="txtotherproduct" autocomplete="off" runat="server" class="form-control txtbox"
                                            Width="180px" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtManfquantityperannum" ErrorMessage="Please select Manf Item Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12" style="text-align: center; margin-top: -10px;">
                                        <asp:Button ID="btnFirstGrid" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Add" ValidationGroup="child" Width="90px" OnClick="btnFirstGrid_Click" />
                                        &nbsp;<asp:Button ID="ButtonMfgcancel" runat="server" OnClick="ButtonMfgcancel_Click"
                                            CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                            Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-xs-12" style="text-align: center; margin-top: 12px">
                                        <b style="color: red">Please click on Add after entering details.</b>
                                    </div>
                                    <div class="col-sm-8 table-responsive" align="center">
                                        <asp:GridView runat="server" ID="grdEnergyConsumed" AutoGenerateColumns="false" OnRowCommand="grdEnergyConsumed_RowCommand"
                                            OnRowDeleting="grdEnergyConsumed_RowDeleting" BorderColor="#003399" BorderStyle="Solid"
                                            BorderWidth="1px" CellPadding="4" OnRowDataBound="grdEnergyConsumed_RowDataBound"
                                            CssClass="GRD" ForeColor="#333333" GridLines="None" Width="100%">
                                            <HeaderStyle CssClass="gridcolor" />
                                            <RowStyle BackColor="#ffffff" />
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
                                                        <asp:HyperLink ID="HyperLink1" runat="server" Visible="false" NavigateUrl='<%# Eval("SketchCopy_Path") %>'
                                                            Text='View' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OthersSpecify">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOthersSpecify" runat="server" Text='<%#Eval("OthersSpecify") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                    HeaderText="Delete">
                                                    <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkRenRemove" runat="server" CommandName="EnergyDelete" Font-Bold="true"
                                                            ForeColor="#ff3300"><u>Delete</u></asp:LinkButton>
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
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Raw Materials used For Manufacturing other than Coal,Ethanol etc</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="rowcol">
                                    <div class="col-xs-12 col-sm-3">
                                        <label class="formlabel">
                                            Raw Materials is Procurred From <font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlrawmaterialprocured" runat="server" Width="180px" class="form-control txtbox"
                                            AutoPostBack="True" Height="33px" TabIndex="1" OnSelectedIndexChanged="ddlrawmaterialprocured_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="31">From the State</asp:ListItem>
                                            <asp:ListItem Value="1">Outside the State</asp:ListItem>
                                            <asp:ListItem Value="2">Outside the Country</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <div id="Div4" class="col-xs-12 col-sm-2" runat="server">
                                        <label class="formlabel" runat="server" id="labelDistrict" visible="false">
                                            District <font color="red">*</font>
                                        </label>
                                        <label class="formlabel" runat="server" id="labelState" visible="false">
                                            State <font color="red">*</font>
                                        </label>
                                        <label class="formlabel" runat="server" id="labelCountry" visible="false">
                                            Country <font color="red">*</font>
                                        </label>
                                        <asp:DropDownList ID="ddldistrict1" runat="server" AutoPostBack="True" class="form-control txtbox"
                                            Height="33px" TabIndex="1" Width="180px" Visible="false">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" Visible="false"
                                            class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtfromcountry" Width="180px" autocomplete="off" Visible="false"
                                            runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1"
                                            ValidationGroup="group"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                    </h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="rowcol">
                                    <div class="col-xs-12 col-sm-3">
                                        <label class="formlabel">
                                            1.Item : <font color="red">*</font></label>
                                        <asp:TextBox ID="txtRawItem" autocomplete="off" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"
                                            Width="180px"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRawItem" ErrorMessage="Please enter  Raw Item" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12 col-sm-3">
                                        <label class="formlabel">
                                            2.Quantity Per Annum : <font color="red">*</font>
                                        </label>
                                        <asp:TextBox ID="txtRawQntyperAnnum" autocomplete="off" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()"  TabIndex="1"
                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRawQntyperAnnum" ErrorMessage="Please select Raw Item  Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12 col-sm-3">
                                        <label class="formlabel">
                                            3. Units : <font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlRawUnits" runat="server" class="form-control txtbox" Width="180px"
                                            AutoPostBack="True" Height="33px" TabIndex="1" OnSelectedIndexChanged="ddlRawUnits_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="KG">KG</asp:ListItem>
                                            <asp:ListItem Value="Tone">Tons</asp:ListItem>
                                            <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                            <asp:ListItem Value="Others">Others</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12 col-sm-3" id="trrawothers" runat="server" visible="false">
                                        <label class="formlabel">
                                            4.Others <font color="red"></font>
                                        </label>
                                        <asp:TextBox ID="txtRawothers" autocomplete="off" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please select Quantity(Per Annum)" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-xs-12" style="text-align: center; margin-top: 12px">
                                        <asp:Button ID="btnSecondGridAdd" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Add" ValidationGroup="child" Width="90px"
                                            OnClick="btnSecondGridAdd_Click" />
                                        &nbsp;<asp:Button ID="btnSecondGridClear" runat="server" CausesValidation="False"
                                            CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                            Width="73px" OnClick="btnSecondGridClear_Click" />
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-xs-12" style="text-align: center; margin-top: 12px">
                                        <b style="color: red">Please click on Add after entering details.</b>
                                    </div>
                                    <div class="col-sm-8 table-responsive" align="center">
                                        <asp:GridView runat="server" ID="grdPowerutilized" AutoGenerateColumns="false" OnRowCommand="grdPowerutilized_RowCommand"
                                            OnRowDeleting="grdPowerutilized_RowDeleting" BorderColor="#003399" BorderStyle="Solid"
                                            BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333" GridLines="None"
                                            Width="100%">
                                            <HeaderStyle CssClass="gridcolor" />
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
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
                                                <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                    HeaderText="Delete">
                                                    <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Font-Bold="true"
                                                            ForeColor="#ff3300"><u>Delete</u></asp:LinkButton>
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
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 text-center mt-3">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                    &times;</a> <strong>Success!</strong>
                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                    Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 text-center mt-3">
                                    <div class="col-xs-12" style="text-align: center; margin-top: 30px;">
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary"
                                            Height="28px" TabIndex="10" Text="Submit" ValidationGroup="group" Width="72px"
                                            OnClick="btnsubmit_Click" />
                                        &nbsp;<asp:Button ID="btnclear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                            Height="28px" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen" Width="73px"
                                            OnClick="btnclear_Click" />
                                            <asp:LinkButton ID="IAT" runat="server" Visible="false" PostBackUrl="~/UI/tsipass/IncentiveFormCFECFO.aspx" Text="Click here to Apply for Incentives"> </asp:LinkButton>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- //Added --%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <%--
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    // maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDate']").datepicker(
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
            $("input[id$='txtExpectedMonthandYearofTrialProduction']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",

                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtProbableDateofRequirementofPowerSupply']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>--%>
</asp:Content>
