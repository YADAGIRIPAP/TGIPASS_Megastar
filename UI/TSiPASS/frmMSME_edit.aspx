<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmMSME_edit.aspx.cs" Inherits="UI_TSiPASS_frmMSME_edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>--%>
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
    <link href="<%= ResolveUrl("assets/css/basic.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("../../css/ui-lightness/jquery-ui-1.8.19.custom.css") %>"
        rel="stylesheet" />
    <script src="<%= ResolveUrl("../../js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("../../js/jquery-ui-1.8.19.custom.min.js") %>"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("../../Resource/Scripts/js/validations.js") %>" type="text/javascript"></script>
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
        
        .auto-style1
        {
            left: 3px;
            top: 0px;
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
    <script>
        // The function below will start the confirmation dialog
        function confirmAction() {
            var okst=new String("OK");
            var canst=new String("Cancel");
            let confirmAction = confirm("Press a button!\nClick "+okst.bold()+" to Map to Next MSME Unit.\nClick"+ canst.bold()+" to Edit this MSME Unit.");
            if (confirmAction) {
                alert("Map next this MSME Unit");
            } else {
                alert("Edit this MSME Unit");
            }
        }
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script>
        function functionConfirm(msg, myYes, myNo) {
            var confirmBox = $("#confirm");
            confirmBox.find(".message").text(msg);
            confirmBox.find(".yes,.no").unbind().click(function () {
                confirmBox.hide();
            });
            confirmBox.find(".yes").click(myYes);
            confirmBox.find(".no").click(myNo);
            confirmBox.show();
        }
    </script>
    <style>
        #confirm
        {
            display: none;
            background-color: #91FF00;
            border: 1px solid #aaa;
            position: fixed;
            width: 250px;
            left: 50%;
            margin-left: -100px;
            padding: 6px 8px 8px;
            box-sizing: border-box;
            text-align: center;
        }
        
        #confirm button
        {
            background-color: #48E5DA;
            display: inline-block;
            border-radius: 5px;
            border: 1px solid #aaa;
            padding: 5px;
            text-align: center;
            width: 80px;
            cursor: pointer;
        }
        
        #confirm .message
        {
            text-align: left;
        }
    </style>
    <script>
        function confirmActionbootbox() {
            let confirmActionbootbox = bootbox.confirm({
                message: "This is a confirm with custom button text and color! Do you like it?",
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'No',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    console.log('This was logged in the callback: ' + result);
                }
            });
    </script>
    <script>
        function myFunction() {
            var txt;
            var r = confirm("Click OK to Map to Next MSME Unit.\nClick Cancel to Edit this MSME Unit.");
            if (r == true) {
                txt = "You pressed OK!Map Next MSME Unit";
            } else {
                txt = "You pressed Cancel!Edit this MSME Unit";
            }
            // document.getElementById("demo").innerHTML = txt;
        }
    </script>
      <%-- //Added --%>
    <link href="<%= ResolveUrl("../../css/ui-lightness/jquery-ui-1.8.19.custom.css") %>"
        rel="stylesheet" />
    <script src="<%= ResolveUrl("../../js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("../../js/jquery-ui-1.8.19.custom.min.js") %>"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnFirstGrid" />
            <asp:PostBackTrigger ControlID="btn_saveupload" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel-body">
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
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Unit Name :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtUnitName" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" onkeypress="Names()" TabIndex="1" ValidationGroup="group"
                                        Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtUnitName"
                                        ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        UAM / IEM / IL ID : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtUAMID" autocomplete="off" runat="server" AutoPostBack="True"
                                        class="form-control txtbox" Height="28px" TabIndex="2" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtUAMID"
                                        ErrorMessage="Please enter UAMID" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Whether the unit is in Industrial estate or Park/Not <font color="red">*</font></label>
                                    <asp:RadioButtonList ID="rdunitIEORNOT" RepeatDirection="Horizontal" ValidationGroup="group"
                                        AutoPostBack="true" OnSelectedIndexChanged="rdunitIEORNOT_SelectedIndexChanged"
                                        TabIndex="4" runat="server">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        District :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddldistrict" runat="server" ValidationGroup="group" AutoPostBack="True"
                                        Enabled="false" class="form-control txtbox" Height="33px" TabIndex="5" Width="180px"
                                        OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddldistrict"
                                        ErrorMessage="Please select  District" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_industrialparks">
                                    <label class="formlabel">
                                        Name of the Industrial Park :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_induspark" runat="server" ValidationGroup="group" class="form-control txtbox"
                                        Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddl_induspark_SelectedIndexChanged"
                                        TabIndex="6">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddl_induspark"
                                        ErrorMessage="Please select  Industrial Park" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Mandal :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlMandal" runat="server" ValidationGroup="group" class="form-control txtbox"
                                        Enabled="true" Height="33px" Width="180px" AutoPostBack="True" TabIndex="7" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal"
                                        ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Village :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_village" runat="server" ValidationGroup="group" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="8" OnSelectedIndexChanged="ddl_village_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddl_village"
                                        ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                 <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        TS-iPASS UidNo :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddltsipass" runat="server" ValidationGroup="group" class="form-control txtbox"
                                        Height="33px" Width="180px" TabIndex="8">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" CausesValidation="False"
                                        Height="32px" Text="Map MSME Unit with TS-iPASS" ValidationGroup="group" Width="250px"
                                        OnClick="btnupdate_Click" OnClientClick="return confirmAction()" />
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                </div>
                            </div>
                            <div class="row">

                              <div class="col-sm-3 form-group" align="left">
                                <asp:LinkButton ID="btn_close" Text="Add Location" runat="server" OnClientClick="togglePopup()" />
                            </div>
                            <div class="col-sm-3 form-group" align="left">
                                <label class="formlabel">
                                    Lalatitude :<font color="red">*</font></label>
                                <br />
                                <input type="text" id="_txtlangitude1" name="latitude" size="25" value="<%=latitude%>" />
                            </div>
                            <div class="col-sm-3 form-group" align="left">
                                <label class="formlabel">
                                    Longitude :<font color="red">*</font></label>
                                <br />
                                <input type="text" id="_txtlonngitude1" name="logititude" size="25" value="<%=logititude%>" />
                            </div>

                                <div class="col-sm-3 form-group" align="left" runat="server" visible="false">
                                    <label class="formlabel">
                                        Lalatitude :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_laltuide" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txt_laltuide"
                                        ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server" visible="false">
                                    <label class="formlabel">
                                        longitude :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_longitude" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txt_longitude"
                                        ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <label class="formlabel">
                                        Complete Unit Address : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtunitaddress" autocomplete="off" runat="server" Width="1000px"
                                        class="form-control txtbox" Height="28px" TabIndex="13" ValidationGroup="group"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtunitaddress"
                                        ErrorMessage="Please enter Unit Address" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <b style="color: red">Please Fill below fields from the Complete Unit Address Field
                                Above</b>
                            <div class="row" style="border: double">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        House No : <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_houseno" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="9" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_houseno"
                                        ErrorMessage="Please enter House No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Locality : <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_Locality" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txt_Locality"
                                        ErrorMessage="Please enter Locality" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Street : <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_street" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="11" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_street"
                                        ErrorMessage="Please enter Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Land Mark : <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_landmark" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="12" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_landmark"
                                        ErrorMessage="Please enter Land Mark" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Investment in Lakhs :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtinvestment" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="6" onkeypress="return isNumberKey(event,this)" TabIndex="14"
                                        AutoPostBack="true" OnTextChanged="txtinvestment_TextChanged" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtinvestment"
                                        ErrorMessage="Please enter Investment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Category : <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                                         onfocus="this.oldIndex=this.selectedIndex" onChange="if(!confirm('1) Are you sure you want to change the category of industry\r\n 2) Please be informed no further changes will be allowed\r\n 3) GMs will be responsible for CORRECTIONS\r\n 4) Still want to change the category'))this.selectedIndex=this.oldIndex"
                                        TabIndex="3" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">MEGA</asp:ListItem>
                                        <asp:ListItem Value="2">LARGE</asp:ListItem>
                                        <asp:ListItem Value="3">MEDIUM</asp:ListItem>
                                        <asp:ListItem Value="4">SMALL</asp:ListItem>
                                        <asp:ListItem Value="5">MICRO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Present Status <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px" AutoPostBack="true" TabIndex="16" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Working</asp:ListItem>
                                        <asp:ListItem Value="2">Closed</asp:ListItem>
                                        <asp:ListItem Value="3">Other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlstatus"
                                        ErrorMessage="Please select Present Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left" id="otherstatus" runat="server" visible="false">
                                    <label class="formlabel">
                                        Other Status <font color="red">*</font></label>
                                    <asp:TextBox ID="txtOtherStatus" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" TabIndex="17" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Type Of Industry : <font color="red">*</font>
                                    </label>
                                    <asp:DropDownList ID="ddlConst_of_unit" runat="server" TabIndex="18" class="form-control txtbox"
                                        Height="33px" Width="180px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="ddlConst_of_unit"
                                        ErrorMessage="Please select Type Of Industry" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Date Of Commencement of Production <font color="red">*</font></label>
                                    <asp:TextBox ID="txtDateOfCommencement" AutoPostBack="true" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" OnTextChanged="txtDateofCommencement_TextChanged"
                                        onkeypress="NumberOnly()" TabIndex="19" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDateOfCommencement"
                                        ErrorMessage="Please enter  Date Of Commencement of Production" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Type Of Connection : <font color="red">*</font></label>
                                    <asp:RadioButtonList ID="RdtypeofConn" runat="server" TabIndex="20" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">LT</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">HT</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Does Unit Export <font color="red">*</font></label>
                                    <asp:RadioButtonList ID="rdnUnitExport" runat="server" AutoPostBack="true" TabIndex="21"
                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rdnUnitExport_SelectedIndexChanged">
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlstatus"
                                        ErrorMessage="Please select Present Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" id="divcountry" runat="server" visible="false">
                                    <label class="formlabel">
                                        Major Export to Which countries <font color="red">*</font></label>
                                    <asp:TextBox ID="txtEXPORTCOUNTRY" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="100" TabIndex="22" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </div>
                                <div id="div_dateofcapture" class="col-sm-3 form-group" runat="server" visible="false"
                                    align="left">
                                    <label class="formlabel">
                                        Date of Capture : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtDate" runat="server" AutoComplete="off" class="form-control txtbox"
                                        Height="28px" MaxLength="15" TabIndex="23" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                        ErrorMessage="Please Select Date" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row" id="Employment1" runat="server" visible="false">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Employment Details</b></h4>
                                </div>
                            </div>
                            <div class="row"  id="Employment2" runat="server" visible="false">
                                <div class="col-sm-12 form-group" align="left">
                                    <asp:Table ID="trAgewiseEmployees" runat="server" CellPadding="1" CellSpacing="1"
                                        Font-Size="Medium" GridLines="Both" Width="1000">
                                        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Style="color: White; background-color: #013161;
                                            font-weight: bold;">
                                            <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="150px">Company rolls</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="170px">Contract/Out Sourcing</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="170px">Total</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell>Skilled</asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtskilledcontract" Width="60px"
                                                    OnTextChanged="txtskilledcontract_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtskilledoutsourcing" Width="60px"
                                                    OnTextChanged="txtskilledoutsourcing_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtskilledtotal" Width="60px"
                                                    OnTextChanged="txtskilledtotal_TextChanged" onkeypress="return inputOnlyNumbers(event)" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">Semi-Skilled</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtsemiskilledcontract" Width="60px"
                                                    OnTextChanged="txtsemiskilledcontract_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtsemiskilledoutsourcing" Width="60px"
                                                    OnTextChanged="txtsemiskilledoutsourcing_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtsemiskilledtotal" Width="60px"
                                                    OnTextChanged="txtsemiskilledtotal_TextChanged" onkeypress="return inputOnlyNumbers(event)" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell>UnSkilled</asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtunskilledcontract" Width="60px"
                                                    OnTextChanged="txtunskilledcontract_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtunskilledoutsourcing" Width="60px"
                                                    OnTextChanged="txtunskilledoutsourcing_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtunskilledtotal" Width="60px"
                                                    OnTextChanged="txtunskilledtotal_TextChanged" onkeypress="return inputOnlyNumbers(event)" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">Managerial</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtmanagerialcontract" Width="60px"
                                                    OnTextChanged="txtmanagerialcontract_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtmanagerialoutsourcing" Width="60px"
                                                    OnTextChanged="txtmanagerialoutsourcing_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtmanagerialtotal" Width="60px"
                                                    OnTextChanged="txtmanagerialtotal_TextChanged" onkeypress="return inputOnlyNumbers(event)" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableFooterRow ID="TableFooterRow1" runat="server" HorizontalAlign="Center"
                                            Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">Total</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" ID="txttotalcontract" Width="60px" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" ID="txttotaloutsourcing" Width="60px" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" ID="txtEmployment" Width="60px" Enabled="false" AutoPostBack="true"
                                                    OnTextChanged="txtEmployment_TextChanged" Height="28px" MaxLength="8" onkeypress="NumberOnly()"
                                                    TabIndex="15" ValidationGroup="group"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableFooterRow>
                                    </asp:Table>
                                </div>
                            </div>
                            <div class="row"  id="Employment3" runat="server" visible="false">
                                <div class="col-sm-2 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of Men Employees :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txtmenemp" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px" OnTextChanged="txtmenemp_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtmenemp"
                                        ErrorMessage="Please enter no of Men Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of WoMen Employees :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txtwomen" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group" Enabled="false"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtwomen"
                                        ErrorMessage="Please enter no of WoMen Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of Employees getting PF:</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txt_totemppfesi" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txt_totemppfesi"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of Employees getting ESI:</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txt_totempnopfesi" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txt_totempnopfesi"
                                        ErrorMessage="Please enter no of Employees given ESI" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="row"  id="Employment4" runat="server" visible="false">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of Local Employees :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txtlocal" autocomplete="off" runat="server" class="form-control txtbox"
                                        OnTextChanged="txtlocal_TextChanged" AutoPostBack="true" Height="28px"
                                        MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txt_noofdirectemp"
                                        ErrorMessage="Please enter no of Local Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of Non Local Employees :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txtnonlocal" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px"
                                        MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txt_noofdirectemp"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of Migrant Employees :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txtmigrant" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px"
                                        MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtmigrant"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row"  id="Employment5" runat="server" visible="false">

                                <div class="col-sm-3 form-group" align="left" id="directemp" runat="server" visible="false">
                                    <label class="formlabel">
                                        <b>No of direct Employees :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txt_noofdirectemp" autocomplete="off" runat="server" class="form-control txtbox"
                                        OnTextChanged="txt_noofdirectemp_TextChanged" AutoPostBack="true" Height="28px"
                                        MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txt_noofdirectemp"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        <b>No of people employed Indirectly:</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txt_totnoofindirectemp" autocomplete="off" runat="server" class="form-control txtbox"
                                        OnTextChanged="txt_totnoofindirectemp_TextChanged" AutoPostBack="true" Height="28px"
                                        MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                        <b style="color: red">Like people working in Industries and Establishments supported by this industry like hotels,transport companies etc..</b>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txt_totnoofindirectemp"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" id="totemp" runat="server" visible="false">
                                    <label class="formlabel">
                                        <b>Total Employment :</b><font color="red">*</font></label>
                                    <asp:TextBox ID="txttotalemployement" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txttotalemployement"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row" id="divoldgrid1" runat="server" visible="false">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No of Employees Not given PF/ESI :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_totempnotpfesi" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txt_totempnotpfesi"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No of Employees Local :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_totlocalemp" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txt_totlocalemp"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No of Employees Non Local :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_totalnonlocal" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txt_totalnonlocal"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No of Employees Out Sourcing :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_noofempoutsourcing" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txt_noofempoutsourcing"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No of Employees Contract :<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_noofempcontract" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txt_noofempcontract"
                                        ErrorMessage="Please enter no of Employees" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row" id="divoldgrid2" runat="server" visible="false">
                                <h4>
                                    <b>Out Sourcing Employee</b></h4>
                                <div class="col-sm-12 table-responsive" align="center">
                                    <asp:GridView runat="server" ID="grd_employeedetails_outsourcing" AutoGenerateColumns="false"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                        ForeColor="#333333" GridLines="Both" Width="100%">
                                        <HeaderStyle CssClass="gridcolor" />
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                    <asp:HiddenField ID="hf_osemptypeid" Value='<%#Eval("emptypeid") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_osemptype" runat="server" Text='<%#Eval("emptypename") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Women Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtempos_women" Text='<%#Eval("Women") %>' autocomplete="off" runat="server"
                                                        class="form-control txtbox" Height="28px" MaxLength="8" onkeypress="NumberOnly()"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator115" runat="server" ControlToValidate="txtempos_women"
                                                        ErrorMessage="Please enter Women Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Men Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtempos_men" Text='<%#Eval("men") %>' autocomplete="off" runat="server"
                                                        class="form-control txtbox" Height="28px" MaxLength="8" onkeypress="NumberOnly()"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ControlToValidate="txtempos_men"
                                                        ErrorMessage="Please enter Men Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--   <asp:TemplateField HeaderText="Each Employee Pay Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_payamount" Text='<%#Eval("payamount") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator119" runat="server" ControlToValidate="txtemp_payamount"
                                                        ErrorMessage="Please enter Each Employee Pay Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Each Employee PF Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_pfamount" Text='<%#Eval("Pfamount") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator118" runat="server" ControlToValidate="txtemp_pfamount"
                                                        ErrorMessage="Please enter Each Employee PF Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Each Employee ESI Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_esiamount" Text='<%#Eval("esiamount") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator117" runat="server" ControlToValidate="txtemp_esiamount"
                                                        ErrorMessage="Please enter Each Employee ESI Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No of Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_noofposts" Text='<%#Eval("noofpost") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator116" runat="server" ControlToValidate="txtemp_noofposts"
                                                        ErrorMessage="Please enter No of Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%-- <asp:TemplateField HeaderText="Local Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_local" Text='<%#Eval("Local") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator113" runat="server" ControlToValidate="txtemp_local"
                                                        ErrorMessage="Please enter Local Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Non-Local Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_nonlocal" Text='<%#Eval("Nonlocal") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator112" runat="server" ControlToValidate="txtemp_nonlocal"
                                                        ErrorMessage="Please enter Non-Local Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualifications">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_qualifications" Text='<%#Eval("qualiskillsreq") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txtemp_qualifications"
                                                        ErrorMessage="Please enter  Qualifications" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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
                            <br />
                            <div class="row" id="divoldgrid3" runat="server" visible="false">
                                <h4>
                                    <b>Contract Employee</b></h4>
                                <div class="col-sm-12 table-responsive" align="center">
                                    <asp:GridView runat="server" ID="grd_employeedetails_contract" AutoGenerateColumns="false"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                        ForeColor="#333333" GridLines="Both" Width="100%">
                                        <HeaderStyle CssClass="gridcolor" />
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                    <asp:HiddenField ID="hf_emptypeidcon" Value='<%#Eval("emptypeid") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_emptypecon" Text='<%#Eval("emptypename") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Women Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_conwomen" Text='<%#Eval("Women") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator115" runat="server" ControlToValidate="txtemp_conwomen"
                                                        ErrorMessage="Please enter Women Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Men Employee">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtemp_conmen" Text='<%#Eval("men") %>' runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ControlToValidate="txtemp_conmen"
                                                        ErrorMessage="Please enter Men Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                            <br />
                            <%-- <div class="row">
                                
                                    <div class="col-sm-12 table-responsive" align="center">
                                        <asp:GridView runat="server" ID="grd_employeedetails" AutoGenerateColumns="false" BorderColor="#003399" BorderStyle="Solid"
                                            BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333" GridLines="None" Width="100%">
                                            <HeaderStyle CssClass="gridcolor" />
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex + 1 %>
                                                        <asp:HiddenField ID="hf_emptypeid" Value='<%#Eval("emptypeid") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_emptype" Text='<%#Eval("emptypename") %>' Enabled="false" runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1120" runat="server" ControlToValidate="txt_emptype"
                                        ErrorMessage="Please enter Type" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Each Employee Pay Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_payamount" Text='<%#Eval("payamount") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator119" runat="server" ControlToValidate="txtemp_payamount"
                                        ErrorMessage="Please enter Each Employee Pay Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Each Employee PF Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_pfamount" Text='<%#Eval("Pfamount") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator118" runat="server" ControlToValidate="txtemp_pfamount"
                                        ErrorMessage="Please enter Each Employee PF Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Each Employee ESI Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_esiamount" Text='<%#Eval("esiamount") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator117" runat="server" ControlToValidate="txtemp_esiamount"
                                        ErrorMessage="Please enter Each Employee ESI Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No of Employee">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_noofposts" Text='<%#Eval("noofpost") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator116" runat="server" ControlToValidate="txtemp_noofposts"
                                        ErrorMessage="Please enter No of Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Women Employee">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_women" Text='<%#Eval("Women") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator115" runat="server" ControlToValidate="txtemp_women"
                                        ErrorMessage="Please enter Women Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Men Employee">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_men" Text='<%#Eval("men") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ControlToValidate="txtemp_men"
                                        ErrorMessage="Please enter Men Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Local Employee">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_local" Text='<%#Eval("Local") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator113" runat="server" ControlToValidate="txtemp_local"
                                        ErrorMessage="Please enter Local Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Non-Local Employee">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_nonlocal" Text='<%#Eval("Nonlocal") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator112" runat="server" ControlToValidate="txtemp_nonlocal"
                                        ErrorMessage="Please enter Non-Local Employee" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qualifications">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtemp_qualifications" Text='<%#Eval("qualiskillsreq") %>' runat="server"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txtemp_qualifications"
                                        ErrorMessage="Please enter  Qualifications" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                              
                            </div>--%>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>ENTREPRENEUR DETAILS</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Name of Entrepreneur : <font color="red">*</font></label>
                                    <asp:TextBox ID="txtNameofEntrepreneur" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" TabIndex="24" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameofEntrepreneur"
                                        ErrorMessage="Please enter Name of Entrepreneur" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Mobile No :<font color="red">*</font></label>
                                    <asp:TextBox ID="txtMObileNo" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="25" ValidationGroup="group"
                                        onblur="checkLength(this)" Width="180px" AutoPostBack="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMObileNo"
                                        ErrorMessage="Please enter Your Mobile number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMObileNo"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Email:<font color="red"></font></label>
                                    <asp:TextBox ID="txtEmail" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" TabIndex="26" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator191" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please Enter Email Id" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Social Status : <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" TabIndex="27"
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
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Is Promoter Differently Abled :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlDifferentlyabled" runat="server" class="form-control txtbox"
                                        TabIndex="28" Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDifferentlyabled"
                                        ErrorMessage="Please Select Differently Abled" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Is Promoter Women:<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlWomenEnterprenuer" runat="server" class="form-control txtbox"
                                        TabIndex="29" Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlWomenEnterprenuer"
                                        ErrorMessage="Please Select Women Enterprenuer" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>PRODUCT DETAILS</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Sector :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="33px"
                                        TabIndex="30" Width="230px" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlSector"
                                        ErrorMessage="Please select Sector" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Line of Activity :<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox"
                                        TabIndex="31" AutoPostBack="true" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                        Height="33px" Width="230px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlintLineofActivity"
                                        ErrorMessage="Please select  Line of Activity" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server">
                                    <label class="formlabel">
                                        Category by PCB <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlCategorybyZone" runat="server" class="form-control txtbox"
                                        TabIndex="32" Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">WHITE</asp:ListItem>
                                        <asp:ListItem Value="2">GREEN</asp:ListItem>
                                        <asp:ListItem Value="3">ORANGE</asp:ListItem>
                                        <asp:ListItem Value="4">RED</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlCategorybyZone"
                                        ErrorMessage="Please select Category Zone" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div id="div_productspecfication" class="col-sm-3 form-group" runat="server" visible="false"
                                    align="left">
                                    <label class="formlabel">
                                        2.Product Specification(if any) :
                                    </label>
                                    <asp:TextBox ID="txtProductSpec" autocomplete="off" runat="server" AutoPostBack="True"
                                        class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="33" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h5 class="text-blue font-SemiBold">
                                        ITEMS MANUFACTURED</h5>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel control-label">
                                        Item Name<font color="red">*</font></label>
                                    <asp:TextBox ID="txtManfitem" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="34" ValidationGroup="group"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtManfitem"
                                        ErrorMessage="Please enter Item" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Quantity Per Annum <font color="red">*</font></label>
                                    <asp:TextBox ID="txtManfquantityperannum" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="35" ValidationGroup="group"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtManfquantityperannum"
                                        ErrorMessage="Please select Manf Item Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Production In Units <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlManfquantityin" runat="server" class="form-control txtbox"
                                        AutoPostBack="True" Height="33px" TabIndex="36" OnSelectedIndexChanged="ddlManfquantityin_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="KG">KG</asp:ListItem>
                                        <asp:ListItem Value="Tons">Tons</asp:ListItem>
                                        <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3 form-group" style="margin-top: -20px;" id="trothers" runat="server"
                                    visible="false">
                                    <label class="formlabel">
                                        others <font color="red"></font>
                                    </label>
                                    <asp:TextBox ID="txtMfgothers" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator612" runat="server" ControlToValidate="txtMfgothers"
                                        ErrorMessage="Please select Quantity(Per Annum)" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Other Product Related Details (If Any)</label>
                                    <asp:TextBox ID="txtotherproduct" autocomplete="off" runat="server" class="form-control txtbox"
                                        Width="180px" Height="28px" MaxLength="40" TabIndex="38" ValidationGroup="group"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3134" runat="server" ControlToValidate="txtotherproduct"
                                        ErrorMessage="Please select Manf Item Quantity(Per Annum)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Upload Photo of Product(.pdf,.png,.jpg,.jpeg Only) (If Any)<font color="red"></font></label>
                                    <asp:FileUpload ID="fpdSketch" runat="server" class="form-control txtbox" Height="33px" />
                                    <asp:HyperLink ID="hplSketch" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                    <br />
                                </div>
                                <div class="col-sm-6 form-group" style="text-align: center; margin-top: -10px;">
                                    <asp:HiddenField ID="hf_productmanfactureID" runat="server" />
                                    <asp:Button ID="btnFirstGrid" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        Text="Add" ValidationGroup="child" Width="90px" OnClick="btnFirstGrid_Click" />
                                    &nbsp;<asp:Button ID="ButtonMfgcancel" runat="server" OnClick="ButtonMfgcancel_Click"
                                        CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" Text="Cancel"
                                        ToolTip="To Clear  the Screen" Width="73px" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" style="text-align: center; margin-top: 12px">
                                    <b style="color: red">Please click on Add after entering details.</b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 table-responsive" align="center">
                                    <asp:GridView runat="server" ID="grd_manufacturedproducts" AutoGenerateColumns="false"
                                        OnRowCommand="grd_manufacturedproducts_RowCommand" BorderColor="#003399" BorderStyle="Solid"
                                        BorderWidth="1px" CellPadding="4" OnRowDataBound="grd_manufacturedproducts_RowDataBound"
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
                                                HeaderText="Edit">
                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_prodmanfedit" runat="server" Text="Edit" CausesValidation="true"
                                                        CssClass="btn vd_btn vd_bg-blue vd_white btn-sm" CommandName="edit_prodmanf"
                                                        CommandArgument='<%#Eval("ProdManID")+";"+Eval("MSME_NO")+";"+((GridViewRow) Container).RowIndex %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                HeaderText="Delete">
                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_prodmanfdeactive" runat="server" Text="Delete" CausesValidation="true"
                                                        CssClass="nbtn btn-danger" CommandName="deactive_manfacture" OnClientClick="return confirm('Are you sure? If you delete you cannot View it again');"
                                                        CommandArgument='<%#Eval("ProdManID")+";"+((GridViewRow) Container).RowIndex %>' />
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
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h5 class="text-blue font-SemiBold">
                                        <b>Raw Materials used For Manufacturing other than Coal,Ethanol etc</b>
                                    </h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel control-label">
                                        Raw Materials is Procurred From <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlrawmaterialprocured" runat="server" Width="180px" class="form-control txtbox"
                                        AutoPostBack="True" Height="33px" TabIndex="39" OnSelectedIndexChanged="ddlrawmaterialprocured_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="31">From the State</asp:ListItem>
                                        <asp:ListItem Value="1">Outside the State</asp:ListItem>
                                        <asp:ListItem Value="2">Outside the Country</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3 form-group" runat="server" id="div_rawDistrict" visible="false">
                                    <label class="formlabel  control-label">
                                        District <font color="red">*</font>
                                    </label>
                                    <asp:DropDownList ID="ddl_rawdistrict" runat="server" class="form-control txtbox"
                                        Height="33px" TabIndex="40" Width="180px" Visible="false">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3 form-group" id="div_rawstate" runat="server" visible="false">
                                    <label class="formlabel  control-label">
                                        State <font color="red">*</font>
                                    </label>
                                    <asp:DropDownList ID="ddlState" runat="server" Visible="false" class="form-control txtbox"
                                        Height="33px" TabIndex="41" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3 form-group" runat="server" id="div_rawcountry">
                                    <label class="formlabel  control-label">
                                        Country <font color="red">*</font>
                                    </label>
                                    <asp:TextBox ID="txtfromcountry" Width="180px" autocomplete="off" Visible="false"
                                        runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="42"
                                        ValidationGroup="group"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Item Name: <font color="red">*</font></label>
                                    <asp:TextBox ID="txtRawItem" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="43" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Quantity Per Annum : <font color="red">*</font>
                                    </label>
                                    <asp:TextBox ID="txtRawQntyperAnnum" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="44" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="formlabel">
                                        Units : <font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlRawUnits" runat="server" class="form-control txtbox" Width="180px"
                                        AutoPostBack="True" Height="33px" TabIndex="45" OnSelectedIndexChanged="ddlRawUnits_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="KG">KG</asp:ListItem>
                                        <asp:ListItem Value="Tone">Tons</asp:ListItem>
                                        <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3 form-group" id="trrawothers" runat="server" visible="false">
                                    <label class="formlabel">
                                        4.Others <font color="red"></font>
                                    </label>
                                    <asp:TextBox ID="txtRawothers" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" TabIndex="46" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12 form-group" style="text-align: center; margin-top: 12px">
                                    <asp:HiddenField ID="hf_rawmaterialid" runat="server" />
                                    <asp:Button ID="btn_addrawmaterial" runat="server" CssClass="btn btn-xs btn-warning"
                                        Height="28px" Text="Add" ValidationGroup="child" Width="90px" OnClick="btn_addrawmaterial_Click" />
                                    &nbsp;<asp:Button ID="btnSecondGridClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-xs btn-danger" Height="28px" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="73px" OnClick="btnSecondGridClear_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" style="text-align: center; margin-top: 12px">
                                    <b style="color: red">Please click on Add after entering details.</b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 table-responsive" align="center">
                                    <asp:GridView runat="server" ID="grd_rawmaterial" AutoGenerateColumns="false" OnRowCommand="grd_rawmaterial_RowCommand"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                        ForeColor="#333333" GridLines="None" Width="100%">
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
                                                HeaderText="Edit">
                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_rawmaterialedit" runat="server" Text="Edit" CausesValidation="false"
                                                        CssClass="btn vd_btn vd_bg-blue vd_white btn-sm" CommandName="edit_rawmaterial"
                                                        CommandArgument='<%#Eval("RawmatID")+";"+Eval("MSME_NO")+";"+((GridViewRow) Container).RowIndex %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                HeaderText="Delete">
                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_rawmaterialdeactive" runat="server" Text="Delete" CssClass="nbtn btn-danger"
                                                        CommandName="deactive_rawmaterial" OnClientClick="return confirm('Are you sure? If you Delete you cannot view it again');"
                                                        CommandArgument='<%#Eval("RawmatID")+";"+((GridViewRow) Container).RowIndex %>' />
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
                            <br />
                            <div class="row">
                                <div class="col-sm-12 form-group" style="text-align: left; margin-top: 12px">
                                    <label class="formlabel">
                                        REMARKS <font color="red"></font>
                                    </label>
                                    <asp:TextBox ID="txtremarks" runat="server" TabIndex="47" TextMode="MultiLine" Height="38px"
                                        Width="169px"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-4 form-group" align="left">
                                    <label class="formlabel">
                                        Upload Photo of Unit(.pdf,.png,.jpg,.jpeg Only) <font color="red">*</font></label>
                                    <asp:FileUpload ID="file_uploadmachinery" Width="300px" runat="server" class="form-control txtbox"
                                        Height="33px" />
                                    <asp:HyperLink ID="hypmsme" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                    <asp:Button ID="btn_saveupload" runat="server" CssClass="btn btn-xs btn-warning"
                                        Height="33px" Text="Upload" OnClick="btn_saveupload_Click" Width="72px" />
                                </div>
                                <div class="col-sm-4 form-group" align="left">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4 form-group" align="center">
                                    <asp:GridView ID="grd_uploadgrid" runat="server" OnRowCommand="grd_uploadgrid_RowCommand"
                                        AutoGenerateColumns="False" CellPadding="3" EnableModelValidation="True" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblslno" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachment">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hprlink" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>'
                                                        Target="_blank"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                HeaderText="Delete">
                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_uploafiledeactive" runat="server" Text="Delete" CssClass="nbtn btn-danger"
                                                        CommandName="deactive_uploadlistdetails" OnClientClick="return confirm('Are you sure? If you this Delete you cannot view it again');"
                                                        CommandArgument='<%#Eval("intMSMEID")+";"+((GridViewRow) Container).RowIndex %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="auREMARKSto-style1">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Success!</strong>
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" style="text-align: center; margin-top: 12px">
                                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" CausesValidation="False"
                                        Height="28px" Text="Submit" ValidationGroup="group" Width="72px" OnClick="btnsubmit_Click"
                                        OnClientClick="return confirm('Do you want to Save  the record ? ');" />
                                    &nbsp;<asp:Button ID="btnclear" runat="server" CausesValidation="false" CssClass="btn btn-xs btn-danger"
                                        Height="28px" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnclear_Click" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
  



     <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
    </style>
    <style type="text/css">
        .modalBackground {
            background-color: #4e5e6a;
            border-color: Blue;
            border: 1px;
            filter: alpha(opacity=70);
            opacity: 0.4;
            z-index: 10000;
        }
    </style>
    <script type="text/javascript">
        function Newwindow() {
            args = Newwindow.arguments
            rht = (window.screen.availHeight - 50);
            rht = 580;
            rwt = 920;
            win2 = window.open(args[0], "win3", "height=" + rht + ",width=" + rwt + ",status=yes,toolbar=no,menubar=no,top=10,left=10,scrollbars=yes");
        }
    </script>
    <style type="text/css">
        .content {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 800px;
            height: 700px;
            text-align: center;
            background-color: #e8eae6;
            box-sizing: border-box;
            padding: 10px;
            z-index: 100;
            display: none;
            /*to hide popup initially*/
        }

        .close-btn {
            position: absolute;
            right: 20px;
            top: 15px;
            background-color: black;
            color: white;
            border-radius: 50%;
            padding: 4px;
        }
    </style>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=true"></script>
    <script type="text/javascript">
        // Function to show and hide the popup
        function togglePopup() {
            $(".content").toggle();
            showMap()
        }
        function showMap() {
            var mapOptions = {
                center: new google.maps.LatLng(18.1124, 79.0193),
                zoom: 14,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            //var test = new google.maps.mapOptions.MapTypeId;
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
            google.maps.event.addListener(map, 'click', function (e) {
                if (e.latLng.lat() != "" && e.latLng.lng() != "") {
                    var r = confirm("Are you Sure about the location");
                    if (r == true) {

                        $("#_txtlangitude1").val(e.latLng.lat());
                        $("#_txtlonngitude1").val(e.latLng.lng());
                        //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
                        togglePopup();
                    }
                } else {
                }
            });
        }
    </script>
    <div class="content">
        <div onclick="togglePopup()" class="close-btn">
            ×
        </div>
        <div id="dvMap" style="width: 500px; height: 500px">
        </div>
    </div>
</asp:Content>
