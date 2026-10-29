<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmConstofWomencell_DistrictLevel.aspx.cs" Inherits="UI_TSiPASS_frmConstofWomencell_DistrictLevel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
        <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />

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
            width: 464px;
        }


        .time-container {
            display: flex;
            text-align: left;
        }

        .form-control1 {
            font-size: 16px; /* Adjust the font size as needed */
            padding: 6px; /* Adjust the padding as needed */
            border: 1px solid #ccc; /* Define the border style as needed */
            border-radius: 4px;
            height: 33px;
            width: 62px;
        }
        .auto-style3 {
            width: 178px;
        }
        .auto-style4 {
            width: 187px;
        }
        .auto-style5 {
            width: 416px;
        }
    </style>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
           
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index:9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <script type="text/javascript">



        function validatePhoneNumber() {
            var phoneNumber = document.getElementById("<%= txtcontactno.ClientID %>").value;
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
                errorMessage.innerHTML = "Invalid email address";

            }
        }

    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtwomencellconstituteddate']").datepicker(
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
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtwomencellconstituteddate']").datepicker(
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
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBankReport.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
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

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt;
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }

    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit">IPO</i>
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#"></a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Constitution of Women Cell-District Level</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            
                                            <tr>
                                                <td style="padding-left: 30px; padding-top: 10px;" class="auto-style5">
                                                    <asp:Label ID="Label2" runat="server">1. Whether Women Cell constituted at District Level : </asp:Label></td>
                                                <td style="padding-top: 10px;padding-left:30px">
                                                    <asp:RadioButtonList ID="rbtcellatdistrictlevel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtcellatdistrictlevel_SelectedIndexChanged"
                                                        Height="33px" TabIndex="1" Width="120px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                                        <asp:ListItem Value="NO">NO</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <%--<tr id="trdistrict" runat="server" visible="false">
                                                <td style="padding-left: 30px; padding-top: 10px;" class="auto-style2">
                                                    <asp:Label ID="Label435" runat="server" Width="180px">2. District<font id="lbl1" runat="server" color="red">*</font> : </asp:Label></td>
                                                <td style="padding-top: 10px;" class="auto-style2">
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox"
                                                        Height="33px" TabIndex="1" Width="180px">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>--%>
                                            <tr >
                                                <td style="padding-bottom:10px" class="auto-style5">
                                                    <table>
                                                        <tr id="trdistrict" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label3" runat="server">2. District<font id="Font1" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td class="auto-style3">
                                                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" Width="173px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        
                                                      <%--  <tr id="DayOfOperationTextBox" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label3" runat="server">3. Day of Operation<font id="Font1" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="DayOfOperationText" runat="server" class="form-control" Width="180px" /></td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                                <td style="padding-bottom:10px">
                                                    <table>
                                                        <tr id="DayOfOperationDropDown" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label437" runat="server">3. Day of Operation<font id="lb5" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td class="auto-style3">
                                                                <asp:DropDownList ID="ddlDayofoperation" runat="server" class="form-control" Width="173px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Monday</asp:ListItem>
                                                                    <asp:ListItem Value="2">Tuesday</asp:ListItem>
                                                                    <asp:ListItem Value="3">Wednesday</asp:ListItem>
                                                                    <asp:ListItem Value="4">Thursday</asp:ListItem>
                                                                    <asp:ListItem Value="5">Friday</asp:ListItem>
                                                                    <asp:ListItem Value="6">Saturday</asp:ListItem>
                                                                    <asp:ListItem Value="7">Sunday</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        
                                                      <%--  <tr id="TimeOfOperationsTextBox" runat="server" visible="false">
                                                            <td width="200px">
                                                                <asp:Label ID="Label6" runat="server">4. Time of Operation<font id="Font3" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="TimeOfOperationsText" runat="server" class="form-control" Width="180px" /></td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-bottom:10px" class="auto-style5">
                                                    <table>
                                                        <tr id="TimeofOperationDropdown" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label434" runat="server">4. Time of Operation<font id="lbl2" runat="server" color="red">*</font> : </asp:Label>
                                                            </td>
                                                            <td>
                                                                <div class="time-container" width="180px">
                                                                    <asp:DropDownList ID="ddlHours" runat="server" class="form-control1">
                                                                        <asp:ListItem Value="0">HH</asp:ListItem>
                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlMinutes" runat="server" class="form-control1">
                                                                        <asp:ListItem Value="-1">MM</asp:ListItem>
                                                                        <asp:ListItem Value="00">00</asp:ListItem>
                                                                        <asp:ListItem Value="01">01</asp:ListItem>
                                                                        <asp:ListItem Value="02">02</asp:ListItem>
                                                                        <asp:ListItem Value="03">03</asp:ListItem>
                                                                        <asp:ListItem Value="04">04</asp:ListItem>
                                                                        <asp:ListItem Value="05">05</asp:ListItem>
                                                                        <asp:ListItem Value="06">06</asp:ListItem>
                                                                        <asp:ListItem Value="07">07</asp:ListItem>
                                                                        <asp:ListItem Value="08">08</asp:ListItem>
                                                                        <asp:ListItem Value="09">09</asp:ListItem>
                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                                        <asp:ListItem Value="21">21</asp:ListItem>
                                                                        <asp:ListItem Value="22">22</asp:ListItem>
                                                                        <asp:ListItem Value="23">23</asp:ListItem>
                                                                        <asp:ListItem Value="24">24</asp:ListItem>
                                                                        <asp:ListItem Value="25">25</asp:ListItem>
                                                                        <asp:ListItem Value="26">26</asp:ListItem>
                                                                        <asp:ListItem Value="27">27</asp:ListItem>
                                                                        <asp:ListItem Value="28">28</asp:ListItem>
                                                                        <asp:ListItem Value="29">29</asp:ListItem>
                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                        <asp:ListItem Value="31">31</asp:ListItem>
                                                                        <asp:ListItem Value="32">32</asp:ListItem>
                                                                        <asp:ListItem Value="33">33</asp:ListItem>
                                                                        <asp:ListItem Value="34">34</asp:ListItem>
                                                                        <asp:ListItem Value="35">35</asp:ListItem>
                                                                        <asp:ListItem Value="36">36</asp:ListItem>
                                                                        <asp:ListItem Value="37">37</asp:ListItem>
                                                                        <asp:ListItem Value="38">38</asp:ListItem>
                                                                        <asp:ListItem Value="39">39</asp:ListItem>
                                                                        <asp:ListItem Value="40">40</asp:ListItem>
                                                                        <asp:ListItem Value="41">41</asp:ListItem>
                                                                        <asp:ListItem Value="42">42</asp:ListItem>
                                                                        <asp:ListItem Value="43">43</asp:ListItem>
                                                                        <asp:ListItem Value="44">44</asp:ListItem>
                                                                        <asp:ListItem Value="45">45</asp:ListItem>
                                                                        <asp:ListItem Value="46">46</asp:ListItem>
                                                                        <asp:ListItem Value="47">47</asp:ListItem>
                                                                        <asp:ListItem Value="48">48</asp:ListItem>
                                                                        <asp:ListItem Value="49">49</asp:ListItem>
                                                                        <asp:ListItem Value="50">50</asp:ListItem>
                                                                        <asp:ListItem Value="51">51</asp:ListItem>
                                                                        <asp:ListItem Value="52">52</asp:ListItem>
                                                                        <asp:ListItem Value="53">53</asp:ListItem>
                                                                        <asp:ListItem Value="54">54</asp:ListItem>
                                                                        <asp:ListItem Value="55">55</asp:ListItem>
                                                                        <asp:ListItem Value="56">56</asp:ListItem>
                                                                        <asp:ListItem Value="57">57</asp:ListItem>
                                                                        <asp:ListItem Value="58">58</asp:ListItem>
                                                                        <asp:ListItem Value="59">59</asp:ListItem>
                                                                        <asp:ListItem Value="60">60</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlAMPM" runat="server" class="form-control1">
                                                                        <asp:ListItem Value="0">---</asp:ListItem>
                                                                        <asp:ListItem Value="AM">AM</asp:ListItem>
                                                                        <asp:ListItem Value="PM">PM</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                </td>
                                                <td style="padding-bottom:10px">
                                                    <table>
                                                    <tr id="trplaceofoperation" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label5" runat="server" Width="171px">5. Place of Operation<font id="Font4" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txtplaceofperation" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                    Width="173px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr >
                                                <td style="padding-bottom:10px" class="auto-style5">
                                                    <table>
                                                        <tr id="trwomencellconstituteddate" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label6" runat="server">6. Women Cell Constituted Date<font id="Font2" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtwomencellconstituteddate" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                    Width="173px"></asp:TextBox></td>
                                                        </tr>
                                                        
                                                      <%--  <tr id="DayOfOperationTextBox" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                <asp:Label ID="Label3" runat="server">3. Day of Operation<font id="Font1" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="DayOfOperationText" runat="server" class="form-control" Width="180px" /></td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                                <td style="padding-bottom:10px">
                                                    <table>
                                                        <tr id="Tr4" runat="server" visible="false">
                                                            <td style="padding-left: 30px;" width="200px">
                                                                </td>
                                                            <td class="auto-style3">
                                                                </td>
                                                        </tr>
                                                        
                                                      <%--  <tr id="TimeOfOperationsTextBox" runat="server" visible="false">
                                                            <td width="200px">
                                                                <asp:Label ID="Label6" runat="server">4. Time of Operation<font id="Font3" runat="server" color="red">*</font> : </asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="TimeOfOperationsText" runat="server" class="form-control" Width="180px" /></td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>


                                        <table align="center" cellpadding="12" cellspacing="5" style="width: 100%">
                                            <tr id="trgrid" runat="server" visible="false">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="false"
                                                        Width="100%" CellSpacing="4" ShowHeaderWhenEmpty="true"  Visible="false"
                                                        OnRowEditing="grdDetails_RowEditing" OnRowCancelingEdit="grdDetails_RowCancelingEdit">
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="25px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="FACILITATOR ID"
                                                                Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="FACILITATORID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                            </asp:TemplateField>

                                                            
                                                              
                                                              

                                                            
                                                             <asp:TemplateField HeaderText="Place of Operation" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPlaceOfOperation" runat="server" Text='<%# Eval("PLACEOFOPERATION") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Facilitator Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFacilitatorName" runat="server" Text='<%# Eval("FACILITATORNAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("DESIGNATION") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CONTACT NO">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCONTACTNO" runat="server" Text='<%# Eval("CONTACTNO") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EMAIL ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEMAILID" runat="server" Text='<%# Eval("EMAILID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Remarks to Delete">
                                                                <ItemTemplate>

                                                                    <asp:TextBox runat="server" class="form-control txtbox" Height="50px" Width="180px"
                                                                        ID="txtremarks" placeholder="Remarks" TextMode="MultiLine" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Edit" ControlStyle-CssClass="btn-primary" Visible="false"/>

                                                            <%--<asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btndelete" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                        Height="32px" OnClick="btndelete_Click" OnClientClick="return confirm('Do you want to update the record ? ');"
                                                                        TabIndex="10" Text="Delete" ValidationGroup="group" Width="100px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btndelete" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                        Height="32px" OnClick="btndelete_Click" OnClientClick="return confirm('Do you want to update the record ? ');"
                                                                        TabIndex="10" Text="Delete" ValidationGroup="group" Width="100px" />

                                                                    <br />

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="text-align: center;">No Data to Display</div>
                                                        </EmptyDataTemplate>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr id="TR1" runat="server" visible="false">
                                                <td width="430px" style="padding-left: 30px; padding-top: 10px;">
                                                    <asp:Label ID="Label4" runat="server">6. Would you like to add new facilitators to this District : </asp:Label>
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <asp:RadioButtonList ID="AddNewFacilitatorBtn" runat="server" Height="33px" TabIndex="1" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="AddNewFacilitatorBtn_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">YES</asp:ListItem>
                                                        <asp:ListItem Value="1">NO</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr id="TRNOOFMEMBERS" runat="server" visible="false">
                                                <td width="500px" style="padding-left: 30px; padding-top: 10px;">
                                                    <asp:Label ID="Label438" runat="server">6. Please enter no of Women Cell Members(<a style="color:red"> Enter New Members Count</a>) : </asp:Label>
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                            <asp:TextBox ID="txtnoofmembersinwomencell" autoComplete="off" runat="server" class="form-control txtbox" min="1" 
                                                        Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" AutoPostBack="true"
                                                        ValidationGroup="group" Width="45px" OnTextChanged="txtnoofmembersinwomencell_TextChanged"></asp:TextBox>
                                                   </td>
                                                <td>
                                                    <asp:Button ID="btnenter" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" OnClick="btnenter_Click"
                                                        TabIndex="10" Text="Enter"
                                                    Width="69px" ValidationGroup="group"  />
                                                    </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="detailsBlock" runat="server" visible="false">
                                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                                <caption>
                                                    <p style="font-weight: bold; font-size: 15px; padding-left: 40px; padding-top: 20px">
                                                        Details<font color="red">*</font></p>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding-left: 40px; padding-bottom: 5px;">
                                                                        <asp:Label ID="Label1" runat="server" Width="168px">1.Facilitator Name : <font id="lbl6" runat="server" color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding-right: 40px; padding-bottom: 5px;" class="auto-style4">
                                                                        <asp:TextBox ID="txtnameoffacilitator" runat="server" autoComplete="off" class="form-control txtbox" MaxLength="200" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="156px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding-left: 20px; padding-bottom: 5px;">
                                                                        <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="168px">2. Designation : <font id="lb3" runat="server" color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding-bottom: 5px;">
                                                                        <asp:TextBox ID="txtdesignation" runat="server" autoComplete="off" class="form-control txtbox" onkeypress="Names()" TabIndex="1" ValidationGroup="child" Width="156px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding-left: 40px;">
                                                                        <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="168px">3. Contact No : <font id="lbl7" runat="server" color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding-right: 40px;">
                                                                        <asp:TextBox ID="txtcontactno" runat="server" autoComplete="off" class="form-control txtbox" MaxLength="10" onkeypress="NumberOnly()" onkeyup="validatePhoneNumber()" TabIndex="1" ValidationGroup="group" Width="156px"></asp:TextBox>
                                                                        <div id="error" style="color: red;">
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding-left: 20px; padding-bottom: 5px;">
                                                                        <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="168px">4. Mail Id : <font color="red" id="lbl4" runat="server">*</font></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtemailid" runat="server" autoComplete="off" class="form-control txtbox" onkeyup="validateEmail(this.value)" TabIndex="1" ValidationGroup="child" Width="156px"></asp:TextBox>
                                                                        <span id="error-message" style="color: red;"></span></td>

                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </caption>
                                            </table>
                                            <table align="right">
                                                <tr id="tr2" runat="server">
                                                    <td style="padding-right: 10px; padding-top: 10px;">
                                                        <asp:Button ID="btnadd" runat="server" CssClass="btn btn-xs btn-warning"
                                                            Height="28px" OnClick="btnadd_Click" TabIndex="10" Text="Add New"
                                                            ValidationGroup="child" Width="72px" /></td>
                                                    <td style="padding-top: 10px; padding-right: 50px;">
                                                        <asp:Button ID="btnclear" runat="server" CausesValidation="False"
                                                            CssClass="btn btn-xs btn-danger" Height="28px" OnClick="btnclear_Click"
                                                            TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%" id="TRSUBGRID" runat="server">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                                    <asp:GridView runat="server" ID="GRDDISTRICTCELLFECILITATORS" AutoGenerateColumns="false" OnRowCommand="GRDDISTRICTCELLFECILITATORS_RowCommand"
                                                        BorderColor="#003399" BorderStyle="Solid"
                                                        BorderWidth="1px" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" GridLines="None" Width="100%">
                                                        <HeaderStyle CssClass="gridcolor" />
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name of Facilitator">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLFECILITATORNAME" runat="server" Text='<%#Eval("nameoffacilitator") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblManfquantityperannum" runat="server" Text='<%#Eval("designation") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Contact No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblManfquantityin" runat="server" Text='<%#Eval("contactno") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Email ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMfgothers" runat="server" Text='<%#Eval("emailid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                                HeaderText="Delete">
                                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkRenRemove" runat="server" CommandName="FACILITATORDELETE" Font-Bold="true"
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
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                    <table align="center">
                                        <tr>
                                            <td style="padding-right: 10px; padding-bottom: 20px;">
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" OnClick="btnsave_Click" TabIndex="10" Text="Save"
                                                    Width="90px" ValidationGroup="group" Visible="false" />
                                            </td>
                                            <td style="padding-bottom: 20px;">
                                                <asp:Button ID="BtnClear1" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-warning" Height="32px" OnClick="BtnClear1_Click"  TabIndex="10"
                                                    Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />

                        </div>

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
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="btnadd"></asp:PostBackTrigger>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>


