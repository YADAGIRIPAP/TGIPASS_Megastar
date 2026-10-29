<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmprofessiontax.aspx.cs" Inherits="UI_TSiPASS_frmprofessiontax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
        .nav-pills.nav-wizard > li {
            position: relative;
            overflow: visible;
            border-right: 15px solid transparent;
            border-left: 15px solid transparent;
        }


            .nav-pills.nav-wizard > li + li {
                margin-left: 0;
            }

            .nav-pills.nav-wizard > li:first-child {
                border-left: 0;
            }

                .nav-pills.nav-wizard > li:first-child a {
                    border-radius: 5px 0 0 5px;
                }

            .nav-pills.nav-wizard > li:last-child {
                border-right: 0;
            }

                .nav-pills.nav-wizard > li:last-child a {
                    border-radius: 0 5px 5px 0;
                }

            .nav-pills.nav-wizard > li a {
                border-radius: 0;
                background-color: #eee;
            }

            .nav-pills.nav-wizard > li:not(:last-child) a:after {
                position: absolute;
                content: "";
                top: 0px;
                right: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: transparent transparent transparent #eee;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:not(:first-child) a:before {
                position: absolute;
                content: "";
                top: 0px;
                left: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: #eee #eee #eee transparent;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:hover:not(:last-child) a:after {
                border-color: transparent transparent transparent #aaa;
            }

            .nav-pills.nav-wizard > li:hover:not(:first-child) a:before {
                border-color: #aaa #aaa #aaa transparent;
            }

            .nav-pills.nav-wizard > li:hover a {
                background-color: #aaa;
                color: #fff;
            }

            .nav-pills.nav-wizard > li.active:not(:last-child) a:after {
                border-color: transparent transparent transparent #428bca;
            }

            .nav-pills.nav-wizard > li.active:not(:first-child) a:before {
                border-color: #428bca #428bca #428bca transparent;
            }

            .nav-pills.nav-wizard > li.active a {
                background-color: #428bca;
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
        /*Newly Added*/
        .rightAlign {
            text-align: right;
        }

        .tdh {
            border-bottom: solid thin black;
            border-top: solid thin black;
            border-left: solid thin black;
            border-right: solid thin white;
        }

        .td {
            border-bottom: solid thin black;
            border-top: solid thin black;
            border-left: solid thin black;
            border-right: solid thin black;
        }
        /*End*/

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

        .wizard > .content {
            height: 850px;
            width: 1085px;
        }

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

        .lblinv {
            font-weight: bolder;
            color: Red;
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
    <style type="text/css">
        .tooltipDemo
        {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 0px;
            top: 0px;
        }
        
        .tooltipDemo:hover:before
        {
            border: solid;
            border-color: transparent rgb(111, 13, 53);
            border-width: 6px 6px 6px 0px;
            bottom: 21px;
            content: "";
            left: 35px;
            top: 5px;
            position: absolute;
            z-index: 95;
        }
        
        .tooltipDemo:hover:after
        {
            /*background: rgb(111, 13, 53);*/
            background: #2184be;
            border-radius: 5px;
            color: #fff;
            width: 300px;
            left: 40px;
            top: -5px;
            content: attr(alt);
            position: absolute;
            padding: 5px 15px;
            z-index: 95;
        }
        
        .LBLBLACK
        {
            top: 0px;
            left: 0px;
        }
        
        
        /*.auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }*/
        
        .auto-style8
        {
            width: 472px;
        }
    </style>
    <%--<script type="text/javascript">
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

            var num = document.getElementById("<%=txtaadhar.ClientID %>").value;
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
                document.getElementById("<%=txtaadhar.ClientID %>").value = "";
                
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

      for (var i = 0; i < myArray.length ; i++) {
          reversed[i] = myArray[myArray.length - (i + 1)];

      }

      return reversed;
  }

  
    </script>--%>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
        function ValidatePAN() {
            var Obj = document.getElementById("txtpanindustrl");
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
        function ValidatePAN1() {
            var Obj = document.getElementById("txtpan");
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
    </script>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">
                <asp:Label ID="lblHead2" runat="server" Text="Professional Tax Details"></asp:Label></a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div align="left" class="row">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div align="center" class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead1" runat="server" Text="Professional Tax Details"></asp:Label></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="210px"><font 
                                                            color="Red">*</font>PAN of Industrial Undertaking </asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtpanindustrl" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" MaxLength="10" onblur="fnValidatePAN(this);" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtpanindustrl"
                                                    ErrorMessage="Please Enter PAN Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="210px"><font 
                                                            color="Red">*</font>ESTIMATED ANNUAL TURNOVER(Rupees)</asp:Label>
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlanualtrnovr" class="form-control txtbox" runat="server">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Less than 10Lakhs</asp:ListItem>
                                                    <asp:ListItem Value="2">10-50Lakhs</asp:ListItem>
                                                    <asp:ListItem Value="3">50Lakhs</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlanualtrnovr"
                                                    ErrorMessage="Please enter Industries Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">PROFESSIONAL TAX</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td>
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <span style="font-weight: bold;">1.Bank Details</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr>
                                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                        1
                                                                    </td>
                                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                        Bank Name
                                                                    </td>
                                                                    <td class="style21" style="padding: 5px; margin: 5px">
                                                                        :
                                                                    </td>
                                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                        <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox" TabIndex="5"
                                                                            ValidationGroup="group">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" InitialValue="-- SELECT --"
                                                                            ControlToValidate="ddlBank" ErrorMessage="Please Select Bank Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                        2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        Branch<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        :
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtBranchName" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="40" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtBranchName"
                                                                            ErrorMessage="Please Enter Bank Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                        3
                                                                    </td>
                                                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                        IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        :
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtIfscCode" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="12" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtIfscCode"
                                                                            ErrorMessage="Please Enter IFSC Code" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                        5
                                                                    </td>
                                                                    <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">
                                                                        Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                                                    </td>
                                                                    <td class="style21" style="padding: 5px; margin: 5px">
                                                                        :
                                                                    </td>
                                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtAccNumber" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="25" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAccNumber"
                                                                            ErrorMessage="Please Enter Bank Account Number" ValidationGroup="group" SetFocusOnError="true"
                                                                            Display="None">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <span style="font-weight: bold;">2.Details of all promoters/partners/Directors/others
                                                                as applicable(include the principal promoters also)</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvdirectordetails" runat="server" AutoGenerateColumns="False" border="3"
                                                                CellPadding="1" CellSpacing="1" OnRowCommand="gvdirectordetails_RowCommand" OnRowDataBound="gvdirectordetails_RowDataBound">
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Patner/Director Name">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtName" runat="server" class="form-control txtbox" Height="25px"
                                                                                MaxLength="40" ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DOB">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtdob" runat="server" class="form-control txtbox" Height="25px"
                                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Partner Type">
                                                                        <%--//write stored procedure//--%>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlpartnertype" runat="server" class="form-control txtbox"
                                                                                Height="30px" Width="100px">
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Gender">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlGender" runat="server" class="form-control txtbox" Height="30px"
                                                                                Width="120px">
                                                                                <asp:ListItem Value="1">Male</asp:ListItem>
                                                                                <asp:ListItem Value="2">FeMale</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:CheckBox ID="txthousewife" runat="server" MaxLength="40" onkeypress="Names()"
                                                                                TabIndex="1" ValidationGroup="group" Visible="false" Width="65px" Height="30px">
                                                                            </asp:CheckBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Door No">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtdoor_no" runat="server" class="form-control txtbox" Height="25px"
                                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="PAN No">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtpan" runat="server" MaxLength="10" onblur="fnValidatePAN(this);"
                                                                                class="form-control txtbox" Height="16px" ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Road/street/Building">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtroad" runat="server" class="form-control txtbox" Height="25px"
                                                                                MaxLength="40" ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Country">
                                                                        <%--write stored procedure--%>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="true" class="form-control txtbox"
                                                                                Height="30px" Width="120px">
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="State">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlstate" runat="server" class="form-control txtbox" Height="30px"
                                                                                Width="120px">
                                                                                <%-- write stored procedure--%>
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                <%--<asp:ListItem Value="1">Telangana</asp:ListItem>
                                                                                    <asp:ListItem Value="2">A.p</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="txtstate" runat="server" MaxLength="40" onkeypress="Names()" TabIndex="1"
                                                                                ValidationGroup="group" Visible="false" Width="65px" Height="30px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="District">
                                                                        <%--write stored procedure--%>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Height="30px"
                                                                                Width="120px">
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                <%-- <asp:ListItem Value="1">R.R</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Medchal</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="txtdistrict" runat="server" MaxLength="40" onkeypress="Names()"
                                                                                TabIndex="1" ValidationGroup="group" Visible="false" Width="65px" Height="30px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="City">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtcity" runat="server" class="form-control txtbox" Height="25px"
                                                                                MaxLength="15" ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="PIN/ZIP">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtpin" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                                                                class="form-control txtbox" Height="25px" MaxLength="6" ValidationGroup="group"
                                                                                Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Aadhar">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtaadhar" runat="server" class="form-control txtbox" Height="25px"
                                                                                MaxLength="12" ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtemail" runat="server" class="form-control txtbox" Height="25px"
                                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtemail"
                                                                                ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="scroll_td" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mobile Number">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtmobileno" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                                                                class="form-control txtbox" Height="25px" MaxLength="10" ValidationGroup="group"
                                                                                Width="120px"></asp:TextBox>
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
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <div id="flashingtext" style="font-size: 15px;">
                                                                <b>Please click on ADD,before Proceeding</b>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                    <span style="font-weight: bold;">3.Name & Address of other places of work Business(including
                                        Registered Office)</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3" width="100%">
                                    <asp:GridView ID="gvbusinessplaces" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvbusinessplaces_RowCommand" OnRowDataBound="gvbusinessplaces_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Door No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtdoor_no" runat="server" class="form-control txtbox" Height="25px"
                                                        ValidationGroup="group" Width="120px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Road/Street/Building">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtroad" runat="server" class="form-control txtbox" Height="25px"
                                                        ValidationGroup="group" Width="120px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Locality">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtlocality" runat="server" class="form-control txtbox" Height="25px"
                                                        ValidationGroup="group" Width="120px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mandal">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtmandal" runat="server" class="form-control txtbox" Height="25px"
                                                        ValidationGroup="group" Width="120px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlstate" runat="server" class="form-control txtbox" Height="30px"
                                                        Width="120px">
                                                        <%-- write stored procedure--%>
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">Telangana</asp:ListItem>
                                                        <asp:ListItem Value="2">A.p</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="District">
                                                <%--write stored procedure--%>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Height="30px"
                                                        Width="120px">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">R.R</asp:ListItem>
                                                        <asp:ListItem Value="2">Medchal</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtcity" runat="server" class="form-control txtbox" Height="25px"
                                                        ValidationGroup="group" Width="120px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PIN/ZIP">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtpin" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                                        class="form-control txtbox" Height="25px" ValidationGroup="group" Width="120px"></asp:TextBox>
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
                            <tr id="trsubmitactual" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" OnClick="BtnSave_Click" />
                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                        TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" OnClick="btnNext_Click" />
                                    <asp:Button ID="btnPrevious" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                        Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="btnPrevious_Click" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group"
                                        Width="90px" OnClick="BtnClear_Click" />
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
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
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

            $("input[id$='txtdob']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange
              });

        }
        $(function () {
            var date = new Date();
            var yrRange = "1900:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtdob']").datepicker(
               {
                   //dateFormat: "dd/mm/yy",
                   dateFormat: "dd-mm-yy",
                   //maxDate: new Date(currentYear, currentMonth, currentDate)
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange
               });

        });
    </script>
</asp:Content>
