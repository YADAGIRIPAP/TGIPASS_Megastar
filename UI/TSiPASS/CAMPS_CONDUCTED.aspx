<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CAMPS_CONDUCTED.aspx.cs" Inherits="UI_TSiPASS_CAMPS_CONDUCTED" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .checkbox-list label {
            display: inline-block;
            text-align: center;
            font-size: 15px;
            margin-left: 10px;
            margin-right: 45px;
        }

        .div-contentcenter {
            display: flex;
            justify-content: center;
            align-items: center;
            font-weight: bold;
            padding-bottom: 55px;
        }

            .div-contentcenter input[type="checkbox"] {
                transform: scale(1.5);
            }

        .div-Content {
            display: flex;
            padding-left: 65px;
            font-size: 15px;
            justify-content: space-between;
        }

        .form-control {
            width: 100%;
            padding: 8px 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
            background-color: #fff;
            color: #333;
            font-size: 15px;
            line-height: 1.4;
            box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .column {
            display: flex;
        }

        .sidebyside {
            margin-right: 10px;
        }

        .Custom-table {
            width: 100%;
        }

            .Custom-table th, .Custom-table td {
                border: 1px solid #000;
                padding: 5px;
                text-align: left;
            }

        .div-table-margin {
            margin-left: 20px;
        }

        .auto-style1 {
            margin-left: 40px;
        }

        .auto-style2 {
            width: 91%;
            height: 129px;
        }

        .auto-style5 {
            display: flex;
            justify-content: center;
            align-items: center;
            font-weight: bold;
            padding-bottom: 20px;
            width: 985px;
            height: 1px;
            margin-top: 0px;
        }

        .auto-style6 {
            height: 29px;
        }

        .auto-style10 {
            width: 90px;
        }

        .auto-style13 {
            display: block;
            width: 90%;
            font-size: 14px;
            line-height: 1.4;
            color: #333;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.1);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #ccc;
            margin-left: 12px;
            padding: 8px 12px;
            background-color: #fff;
            background-image: none;
        }

        .auto-style14 {
            border: 1px solid #013161;
            padding: 10px;
            text-transform: capitalize;
            text-indent: 5px;
        }

        .auto-style16 {
            display: flex;
            justify-content: center;
            align-items: center;
            font-weight: bold;
            padding-bottom: 20px;
            width: 985px;
            height: 122px;
            margin-top: 0px;
        }
    </style>
    <contenttemplate runat="server">
         <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading" align="center">
                    <h3 class="panel-title">
                        <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                            Width="199px">Camps</asp:Label></h3>
                </div>
                <div class="panel-body">

        <h1 style="text-align: center; font-size: 30px; font-weight: bold; text-decoration: underline;">Camps conducted</h1>
        <div class="auto-style6"></div>
        <div>
            <table>
                <tr id="campalong" runat="server" visible="true">
                    <td style="padding-left:65px; font-size:15px">
                        Camps Conducted 
                        <br />
                        along with:
                        <%--<asp:Label  Font-Size="20px" runat="server">Camps Conducted along with: </asp:Label>--%>
                    </td>
                    <td style="width:100px"></td>
                    <td>
                        <asp:CheckBoxList ID="chkofficers" runat="server" Visible="true" CssClass="checkbox-list" AutoPostBack="true" OnSelectedIndexChanged="chekEDPCamplist_SelectedIndexChanged" RepeatDirection="vertical" Height="63px">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-top:15px" >
            <table>
                <tr>
                    <td>
                        <label class="div-Content">Entrepreneur Type:</label>
                    </td>
                    <td style="width:20px; padding-left:85px"> </td>
                    <td>
                        <asp:RadioButtonList ID="rblentrpnr" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblentrpnr_SelectedIndexChanged" Font-size="15px" RepeatDirection="Horizontal">
                            <asp:ListItem Text="New Entrepreneur" Value="0" style="padding-right:25px"></asp:ListItem>
                            <asp:ListItem Text="Existing Entrepreneur" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>


        </div>
        <div id="divblinkingText" runat="server" visible="false">
            <p id="blinkingText" style="text-align:left; color: red; font-weight: bold; padding-left:70px">[Multiple Camps can also be selected if it is occured in single event]</p>
        </div>
        <%--<div class="auto-style7"></div>--%>
        <div id="divEDP" visible="false" runat="server" align="left">
            <div runat="server" style="text-align: left; padding-left:70px">
                <label style="text-align-last: left;  font-size: 15px;" runat="server">EDP Camp Type:</label>
            </div>
            <div style="text-align: left; padding-left:70px">
                <%--            <asp:CheckBox ID="ChkEDP" runat="server" Text="EDP" AutoPostBack="true" OnCheckedChanged="ChkEDP_CheckedChanged" CssClass="checkbox-list" />--%>
                <asp:CheckBoxList ID="chekEDPCamplist" runat="server" Visible="true" CssClass="checkbox-list" AutoPostBack="true" OnSelectedIndexChanged="chekEDPCamplist_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatColumns="4" Height="63px">
                    <asp:ListItem Text="PMEGP" Value="0"></asp:ListItem>
                    <asp:ListItem Text="PMFME" Value="1"></asp:ListItem>
                    <asp:ListItem Text="TS-iPASS" Value="2"></asp:ListItem>
                    <asp:ListItem Text="T-IDEA" Value="3"></asp:ListItem>
                    <asp:ListItem Text="T-PRIDE" Value="4"></asp:ListItem>
                    <asp:ListItem Text="MUDRA" Value="5"></asp:ListItem>
                    <asp:ListItem Text="TASK" Value="6"></asp:ListItem>
                    <asp:ListItem Text="DEET" Value="7"></asp:ListItem>
                    <asp:ListItem Text="CGTMSE" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Other State Schemes" Value="9"></asp:ListItem>
                    <asp:ListItem Text="GOI Schemes" Value="10"></asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
        <div align="left" style="padding-top: 5px; padding-left:70px">
            <%--             <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>--%>
            <asp:CheckBoxList ID="TYPEOFCAMPLIST" runat="server" Visible="false" AutoPostBack="true" CssClass="checkbox-list" Font-Bold="false" OnSelectedIndexChanged="TYPEOFCAMPLIST_SelectedIndexChanged" Font-Size="20px" RepeatDirection="Horizontal">
                <%-- <asp:ListItem Text="EDP" Value="0"></asp:ListItem>--%>
                <asp:ListItem Text="MSEFC AWARENESS" Value="0"></asp:ListItem>
                <asp:ListItem Text="MSME INTERVENTIONS AWARENESS" Value="1"></asp:ListItem>
                <%--                <asp:ListItem Text="PMEGP" Value="3"></asp:ListItem>--%>
            </asp:CheckBoxList>
        </div>

        <!-----------CONTENT EDP-------------->

        <div class="row" id="EDP_CONTENT" runat="server" visible="false">
            <div class="row">
                <div style="padding-left: 80px;">
                    <p runat="server" style="text-align: left; font-size: 15px; font-weight: bold; text-decoration: underline; padding-bottom: 5px; padding-top: 5px">Camp(s) Venue Details :</p>
                </div>
                <div class="col-sm-3 form-group" align="left" style="height: min-content">
                    <label class="div-Content">Venue :</label>
                </div>
                <div class="col-sm-4 form-group" align="left" style="left: 0px; top: 0px; height: 38px;">
                    <asp:TextBox ID="VenueTXTEDP" autocomplete="off" oncopy="return false" onpaste="return false" runat="server" class="form-control" TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="VenueTXTEDP" ErrorMessage="Please Enter VENUE" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 form-group" align="left">
                    <label class="div-Content">Venue Location :</label>
                </div>
                <div class="col-sm-3 form-group" align="left">
                    <asp:TextBox ID="VENUE_EDP_LOCATION" runat="server" class="form-control" TabIndex="1" placeholder="PLEASE GET THE GEO CO-ORDINATES FROM HERE ➔" ValidationGroup="group" Width="250px"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="VENUE_EDP_LOCATION" ErrorMessage="Please Enter VENUE Location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    <asp:HyperLink ID="OpenMapLink" runat="server" Text="Click Here to get location Cordinates" onclick="window.open('https://www.google.com/maps/@17.45127,78.5500305,12z?entry=ttu', 'NewWindow', 'width=1200,height=600');"></asp:HyperLink>

                </div>
                <div class="col-sm-5 form-group" style="font-size: 15px; color: red; text-align: left; padding-top: 0px;">
                    <asp:Label ID="getmap" runat="server" Text="Click on below link, search for location, then right click on location, you will get coordinates then paste here"></asp:Label>

                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 form-group" align="left">
                    <label class="div-Content">Type of Venue :</label>
                </div>
                <div class="col-sm-4 form-group" align="left">
                    <asp:DropDownList ID="ChkEDP_Venue" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChkEDP_Venue_SelectedIndexChanged" Width="250px" Height="35px" class="form-control">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="College" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Women's College" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Training Institutions" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Zilla Samakhya" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Mandal Samakhya" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Slum Level Federation" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="7"></asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:CheckBox ID="COLLEGE_CHK_BOX_EDP" runat="server" Text="COLLEGE" CssClass="checkbox-list" /><br />
                    <asp:CheckBox ID="WOMENSCOLLEGE_CHK_BOX_EDP" runat="server" Text="WOMEN'S COLLEGE" CssClass="checkbox-list" /><br />
                    <asp:CheckBox ID="TrainingInstitution_CHK_BOX_EDP" runat="server" Text="TRAINING INSTITUTIONS" CssClass="checkbox-list" /><br />
                    <div class="column">
                        <asp:CheckBox ID="Other_CHK_BOX_EDP" runat="server" Text="OTHERS" AutoPostBack="true" CssClass="checkbox-list" OnCheckedChanged="Other_CHK_BOX_EDP_CheckedChanged" />&nbsp;&nbsp;--%>
                    <asp:TextBox ID="EDP_OTHERS_CHK_BOX_Input" runat="server" oncopy="return false" onpaste="return false" Height="35px" Visible="false" Width="350px" class="form-control" />
                    <%--</div>--%>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 form-group" align="left">
                    <label class="div-Content">Date and Time:</label>
                </div>
                <div class="col-sm-4 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="DateOfCampConducted_EDP" autocomplete="off" oncopy="return false" onpaste="return false" Font-Size="Large" Height="33px" Width="250px" runat="server" class="form-control"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DateOfCampConducted_EDP" ErrorMessage="Please Select VENUE Date" ValidationGroup="group">*</asp:RequiredFieldValidator>

                        <asp:DropDownList ID="ddltime_EDP" runat="server" Font-Size="Medium" Height="33px" Width="250px" class="form-control">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="AM" Text="Forenoon"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="Afternoon"></asp:ListItem>
                            <asp:ListItem Value="FD" Text="Full Day"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 form-group" align="left">
                    <label id="lblindividuals" runat="server" class="div-Content">No. of Individuals Attended :</label>
                </div>
                <div class="col-sm-4 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="NoOfMALES_ATTENDED_EDP" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Males Attended" Width="250px" />&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NoOfMALES_ATTENDED_EDP" ErrorMessage="Please Enter Number of Males Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="NoOfFEMALES_ATTENDED_EDP" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Females Attended" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NoOfFEMALES_ATTENDED_EDP" ErrorMessage="Please Enter Number of Females Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row" id="divplatfomrs" visible="false" runat="server">
                <div class="col-sm-3 form-group" align="left">
                    <label id="Label1" runat="server" class="div-Content">Platforms Covered:</label>
                </div>
                <div class="col-sm-9 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:CheckBoxList ID="chkPlatforms" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" Font-Size="20px" RepeatColumns="4" CssClass="checkbox-list">
                            <asp:ListItem Value="0" Text="Meesho"></asp:ListItem>
                            <asp:ListItem Value="1" Text="JustDial"></asp:ListItem>
                            <asp:ListItem Value="2" Text="TS-Global Linker"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Walmart Vriddi "></asp:ListItem>
                            <asp:ListItem Value="4" Text="Invoice Mart"></asp:ListItem>
                            <asp:ListItem Value="5" Text="NSE"></asp:ListItem>
                            <asp:ListItem Value="6" Text="SIDBI"></asp:ListItem>
                            <asp:ListItem Value="7" Text="MAS"></asp:ListItem>
                            <asp:ListItem Value="8" Text="SMAS"></asp:ListItem>
                            <asp:ListItem Value="9" Text="P&MS"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
            <%--<br />--%>
            <%-- <div class="row; div-table-margin;"  >
                <div class="col-sm-12 form-group" align="center" width="80px">--%>
            <div>
                <table align="center" class="auto-style2" style="border-left: 3px solid black; border: 2px solid #555;">
                    <%--border: 3px solid blue--%>
                    <tr>
                        <th colspan="4" style="font-size: 16px; font-weight: bold; text-align: left; padding-left: 20px; background-color: darkslateblue; color: ghostwhite;">Guests on Dias :</th>
                    </tr>
                    <tr style="border: 3px  blue">

                        <td width="150px" style="text-align: center; font-weight: bold; font-size: 14px; border: 2px solid #555">Name</td>
                        <td width="150px" style="text-align: center; font-weight: bold; font-size: 14px; border: 2px solid #555">Designation</td>
                        <td style="text-align: center; font-weight: bold; font-size: 14px; border: 2px solid #555" class="auto-style10">Department/Organisation</td>
                        <td width="150px" style="text-align: center; font-weight: bold; font-size: 14px; border: 2px solid #555">Click Add Guest</td>
                    </tr>
                    <tr style="border: 3px blue">
                        <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: white; color: black; border: 2px solid #555">
                            <input type="text" id="EDP_Guest_Name_1" runat="server" oncopy="return false" onpaste="return false" class="auto-style13" /></td>
                        <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: white; color: black; border: 2px solid #555">
                            <input type="text" id="EDP_Guest_Designation_1" runat="server" oncopy="return false" onpaste="return false" style="background-color: white; color: black; text-align: center;" class="auto-style13" /></td>
                        <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: white; color: black; border: 2px solid #555">
                            <input type="text" id="EDP_Guest_Department_1" runat="server" oncopy="return false" onpaste="return false" style="background-color: white; color: black; text-align: center;" class="auto-style13" /></td>
                        <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: white; color: black; border: blue">
                            <asp:Button ID="EDPGuests" Text="Add Guest" CssClass="btn-warning" Width="100px" runat="server" OnClick="EDPGuests_Click" />
                        </td>
                    </tr>
                </table>
                <br />

                <table align="center" width="800px">
                    <tr>
                        <td>
                            <asp:GridView ID="gvEDPguests" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="auto-style14" ForeColor="#333333"
                                OnRowDeleting="gvEDPguests_RowDeleting" OnRowEditing="gvEDPguests_RowEditing" OnRowCancelingEdit="gvEDPguests_RowCancelingEdit"
                                OnRowUpdating="gvEDPguests_RowUpdating" HorizontalAlign="Center"
                                Width="90%" EnableModelValidation="True" Visible="false" HeaderStyle-HorizontalAlign="Center">
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-Width="50px" ItemStyle-ForeColor="WindowText" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="EDP_GuestName" HeaderText="Guest Name" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField DataField="EDP_GuestDesgn" HeaderText="GusetDesignation" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField DataField="EDP_GuestDept" ItemStyle-Width="120px" HeaderText="Department/Organisation" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" ItemStyle-Width="50px" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <%--</div>
            </div>--%>
            <%--  <br />--%>
            <div class="row">
                <div align="center">
                    <label width="500px" class="div-Content" style="text-align: center; font-weight: bold;">Photographs of the event (Upload jpg images only):</label>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <label class="div-Content">1. Guests on the Dias Photograph:</label>
                            </td>
                            <td style="padding-top: 20px">
                                <asp:FileUpload ID="FupEDP_Dias" runat="server" EnableViewState="True" ViewStateMode="Enabled" ValidateRequestMode="Enabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FupEDP_Dias" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplEDP_Dias" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">2. Speaker Photograph:</label>
                            </td>
                            <td style="padding-top: 20px">
                                <asp:FileUpload ID="FupEDP_Speaker" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FupEDP_Speaker" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplEDP_Speaker" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">3. Audience Photograph:</label>
                            </td>
                            <td style="padding-top: 20px">
                                <asp:FileUpload ID="FupEDP_Audience" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFupEDP_Audience" runat="server" ControlToValidate="FupEDP_Audience" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplEDP_Audience" runat="server" Visible="false" Target="_blank"></asp:HyperLink>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">4. If any other Photograph:</label>
                            </td>
                            <td style="padding-top: 20px">
                                <asp:FileUpload ID="FupEDP_Others" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFupEDP_Others" runat="server" ControlToValidate="FupEDP_Others" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplEDP_Others" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>
        <p class="auto-style1">
            <br />

            <!-------- CONTENT MSEFC AWARENESS ------------>

        </p>

        <%--<div class="row" id="CONTENT_MSEFC_AWARENESS" runat="server" visible="false">
            <div class="row">
                <div style="padding-left: 80px;">
                    <p runat="server" style="text-align: left; font-size: 23px; font-weight: bold; text-decoration: underline; padding-bottom: 10px;">MSEFC AWARENESS VENUE DETAILS :</p>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">VENUE :</label>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="VenueTXTMSEFC" autocomplete="off" oncopy="return false" onpaste="return false" runat="server" class="form-control" TabIndex="1" ValidationGroup="group" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorVenueTXTMSEFC" runat="server" ControlToValidate="VenueTXTMSEFC" ErrorMessage="Please Enter VENUE" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">VENUE Location :</label>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="VENUE_MSEFC_LOCATION" runat="server" class="form-control" TabIndex="1" placeholder="PLEASE GET THE GEO CO-ORDINATES FROM HERE ➔" ValidationGroup="group" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="VENUE_MSEFC_LOCATION" ErrorMessage="Please Enter VENUE Location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4 form-group" style="font-size: 16px; font-weight: bold; text-align: center; padding-top: 8px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Click Here" onclick="window.open('https://www.google.com/maps/@17.45127,78.5500305,12z?entry=ttu', 'NewWindow', 'width=1200,height=600');"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">Type of VENUE :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <asp:RadioButtonList ID="ChkMSEFC_Venue" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChkMSEFC_Venue_SelectedIndexChanged" CssClass="checkbox-list" RepeatDirection="Vertical">
                        <asp:ListItem Text="COLLEGE" Value="0"></asp:ListItem>
                        <asp:ListItem Text="WOMEN'S COLLEGE" Value="1"></asp:ListItem>
                        <asp:ListItem Text="TRAINING INSTITUTIONS" Value="2"></asp:ListItem>
                        <asp:ListItem Text="OTHERS" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>                   
                    <div class="column">
                        <asp:TextBox ID="OTHERS_CHK_BOX_INPUT_MSEFC" runat="server" oncopy="return false" onpaste="return false" Height="35px" Visible="false" Width="350px" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">DATE :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="DateOfCampConducted_MSEFC" autocomplete="off" oncopy="return false" onpaste="return false" Font-Size="Large" Height="33px" Width="250px" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DateOfCampConducted_MSEFC" ErrorMessage="Please Select VENUE Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddltime_MSEFC" runat="server" Font-Size="Medium" Height="33px" Width="230px" class="form-control">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="AM" Text="Forenoon"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="Afternoon"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">No. of Individuals Attended :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="NoOfMALES_ATTENDED_MSEFC" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" MaxLength="2" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Males Attended" />&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="NoOfMALES_ATTENDED_MSEFC" ErrorMessage="Please Enter Number of Males Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="NoOfFEMALES_ATTENDED_MSEFC" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" MaxLength="2" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Females Attended" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="NoOfFEMALES_ATTENDED_MSEFC" ErrorMessage="Please Enter Number of Females Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row; div-table-margin;">
                <div class="col-sm-12 form-group" align="center">
                    <table width="100%" align="center" class="Custom-table">
                        <tr>
                            <th colspan="4" style="font-size: 16px; font-weight: bold; text-align: left; padding-left: 20px; background-color: darkslateblue; color: ghostwhite;">Guests on Dias :</th>
                        </tr>
                        <tr>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Name</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Designation</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Department/Organisation</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Click Add Guest</td>
                        </tr>
                        <tr>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="MSEFC_Guest_Name_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="MSEFC_Guest_Designation_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="MSEFC_Guest_Department_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <asp:Button ID="MSEFCGuests" Text="Add Guest" CssClass="btn-warning" Width="100px" runat="server" OnClick="MSEFCGuests_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMSEFCguests" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                    GridLines="None" OnRowDeleting="gvMSEFCguests_RowDeleting"
                                    Width="100%" EnableModelValidation="True" Visible="false">
                                    <RowStyle BackColor="#ffffff" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="MSEFC_GuestName" HeaderText="Guest Name" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="MSEFC_GuestDesgn" HeaderText="GusetDesignation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="MSEFC_GuestDept" HeaderText="Department/Organisation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                    </Columns>
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="row">

                <div class="row">
                    <div align="center">
                        <label class="div-Content" style="text-align: center; font-weight: bold;">Photographs of the event:</label>
                    </div>
                    <div>
                        <table>
                            <tr>    
                                <td>
                                    <label class="div-Content">1. People on the Dias Photograph:</label>
                                </td>
                                <td> 
                                    <asp:FileUpload ID="FupMSEFC_Dias" runat="server" EnableViewState="True" ViewStateMode="Enabled" ValidateRequestMode="Enabled" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11"  runat="server" ControlToValidate="FupMSEFC_Dias" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:HyperLink ID="HplMSEFC_Dias" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="div-Content">2. Speaker Photograph:</label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FupMSEFC_Speaker" runat="server" AutoPostback="false" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="FupMSEFC_Speaker" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:HyperLink ID="HplMSEFC_Speaker" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="div-Content">3. Aidience Photograph:</label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FupMSEFC_Audience" runat="server" AutoPostback="false" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="FupMSEFC_Audience" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:HyperLink ID="HplMSEFC_Audience" runat="server" Visible="false" Target="_blank"></asp:HyperLink>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="div-Content">4. If any other Photograph:</label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FupMSEFC_Others" runat="server" AutoPostback="false" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="FupMSEFC_Others" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    <asp:HyperLink ID="HplMSEFC_Others" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </div>--%>


        <!-------  CONTENT MSME INTERVENTIONS AWARENESS -------------->


        <%--<div class="row" id="CONTENT_MSME_INTERVENTIONS_AWARENESS" runat="server" visible="false">
            <div class="row">
                <div style="padding-left: 80px;">
                    <p runat="server" style="text-align: left; font-size: 23px; font-weight: bold; text-decoration: underline; padding-bottom: 10px;">MSME INTERVENTIONS AWARENESS VENUE DETAILS :</p>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">VENUE :</label>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="VenueTXTMSME" autocomplete="off" oncopy="return false" onpaste="return false" runat="server" class="form-control" TabIndex="1" ValidationGroup="group" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="VenueTXTMSME" ErrorMessage="Please Enter VENUE" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">VENUE Location :</label>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="VENUELOCATION_MSME" runat="server" class="form-control" TabIndex="1" placeholder="PLEASE GET THE GEO CO-ORDINATES FROM HERE ➔" ValidationGroup="group" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="VENUELOCATION_MSME" ErrorMessage="Please Enter VENUE Location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4 form-group" style="font-size: 16px; font-weight: bold; text-align: center; padding-top: 8px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Text="Click Here" onclick="window.open('https://www.google.com/maps/@17.45127,78.5500305,12z?entry=ttu', 'NewWindow', 'width=1200,height=600');"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">Type of VENUE :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <asp:RadioButtonList ID="ChkMSME_Venue" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChkMSME_Venue_SelectedIndexChanged" CssClass="checkbox-list" RepeatDirection="Vertical">
                        <asp:ListItem Text="COLLEGE" Value="0"></asp:ListItem>
                        <asp:ListItem Text="WOMEN'S COLLEGE" Value="1"></asp:ListItem>
                        <asp:ListItem Text="TRAINING INSTITUTIONS" Value="2"></asp:ListItem>
                        <asp:ListItem Text="OTHERS" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    
                    <div class="column">
                        <asp:TextBox ID="OTHERS_CHK_BOX_INPUT_MSME" oncopy="return false" onpaste="return false" runat="server" Height="35px" Visible="false" Width="350px" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">DATE :</label>
                </div>
                <div class="col-sm-4 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="DateOfCampConducted_MSME" autocomplete="off" oncopy="return false" onpaste="return false" Font-Size="Large" Height="33px" Width="250px" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="DateOfCampConducted_MSME" ErrorMessage="Please Select VENUE Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddltime_MSME" runat="server" Font-Size="Medium" Height="33px" Width="230px" class="form-control">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="AM" Text="Forenoon"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="Afternoon"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">No. of Individuals Attended :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="NoOfMALES_ATTENDED_MSME" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" MaxLength="2" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Males Attended" />&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="NoOfMALES_ATTENDED_MSME" ErrorMessage="Please Enter Number of Males Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="NoOfFEMALES_ATTENDED_MSME" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" MaxLength="2" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Females Attended" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="NoOfFEMALES_ATTENDED_MSME" ErrorMessage="Please Enter Number of Females Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row; div-table-margin;">
                <div class="col-sm-12 form-group" align="center">
                    <table width="100%" align="center" class="Custom-table">
                        <tr>
                            <th colspan="4" style="font-size: 16px; font-weight: bold; text-align: left; padding-left: 20px; background-color: darkslateblue; color: ghostwhite;">Guests on Dias :</th>
                        </tr>
                        <tr>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Name</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Designation</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Department/Organisation</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;"></td>

                        </tr>
                        <tr>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="MSME_Guest_Name_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="MSME_Guest_Designation_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="MSME_Guest_Department_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <asp:Button ID="MSMEGuests" Text="Add Guest" CssClass="btn-warning" Width="100px" runat="server" OnClick="MSMEGuests_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMSMEguests" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                    GridLines="None" OnRowDeleting="gvMSMEguests_RowDeleting"
                                    Width="100%" EnableModelValidation="True" Visible="false">
                                    <RowStyle BackColor="#ffffff" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="MSME_GuestName" HeaderText="Guest Name" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="MSME_GuestDesgn" HeaderText="GusetDesignation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="MSME_GuestDept" HeaderText="Department/Organisation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                    </Columns>
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>

                </div>
            </div>
            <div class="row">
                <div align="center">
                    <label class="div-Content" style="text-align: center; font-weight: bold;">Photographs of the event:</label>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <label class="div-Content">1. People on the Dias Photograph:</label>
                            </td>
                            <td>  
                                <asp:FileUpload ID="FupMSME_Dias" runat="server" EnableViewState="True" ViewStateMode="Enabled" ValidateRequestMode="Enabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17"  runat="server" ControlToValidate="FupMSME_Dias" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplMSME_Dias" runat="server" Visible="false" Target="_blank"></asp:HyperLink>                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">2. Speaker Photograph:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FupMSME_Speaker" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="FupMSME_Speaker" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplMSME_Speaker" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">3. Aidience Photograph:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FupMSME_Audience" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="FupMSME_Audience" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplMSME_Audience" runat="server" Visible="false" Target="_blank"></asp:HyperLink>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">4. If any other Photograph:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FupMSME_Others" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="FupMSME_Others" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplMSME_Others" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>--%>

        <!-------------- CONTENT PMEGP ------------------->


        <%--<div class="row" id="CONTENT_PMEGP" runat="server" visible="false">
            <div class="row">
                <div style="padding-left: 80px;">
                    <p runat="server" style="text-align: left; font-size: 23px; font-weight: bold; text-decoration: underline; padding-bottom: 10px;">PMEGP VENUE DETAILS :</p>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">VENUE :</label>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="VenueTXTPMEGP" autocomplete="off" oncopy="return false" onpaste="return false" runat="server" class="form-control" TabIndex="1" ValidationGroup="group" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="VenueTXTPMEGP" ErrorMessage="Please Enter VENUE" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">VENUE Location :</label>
                </div>
                <div class="col-sm-4 form-group" align="center">
                    <asp:TextBox ID="VENUELOCATION_PMEGP" runat="server" class="form-control" TabIndex="1" placeholder="PLEASE GET THE GEO CO-ORDINATES FROM HERE ➔" ValidationGroup="group" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="VENUELOCATION_PMEGP" ErrorMessage="Please Enter VENUE Location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4 form-group" style="font-size: 16px; font-weight: bold; text-align: center; padding-top: 8px;">
                    <asp:HyperLink ID="HyperLink3" runat="server" Text="Click Here" onclick="window.open('https://www.google.com/maps/@17.45127,78.5500305,12z?entry=ttu', 'NewWindow', 'width=1200,height=600');"></asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">Type of VENUE :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <asp:RadioButtonList ID="ChkPMEGP_Venue" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChkPMEGP_Venue_SelectedIndexChanged" CssClass="checkbox-list" RepeatDirection="Vertical">
                        <asp:ListItem Text="COLLEGE" Value="0"></asp:ListItem>
                        <asp:ListItem Text="WOMEN'S COLLEGE" Value="1"></asp:ListItem>
                        <asp:ListItem Text="TRAINING INSTITUTIONS" Value="2"></asp:ListItem>
                        <asp:ListItem Text="OTHERS" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <div class="column">
                        <asp:TextBox ID="OTHERS_CHK_BOX_INPUT_PMEGP" oncopy="return false" onpaste="return false" runat="server" Height="35px" Visible="false" Width="350px" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">DATE :</label>
                </div>
                <div class="col-sm-4 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="DateOfCampConducted_PMEGP" autocomplete="off" oncopy="return false" onpaste="return false" Font-Size="Large" Height="33px" Width="250px" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="DateOfCampConducted_PMEGP" ErrorMessage="Please Select VENUE Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddltime_PMEGP" runat="server" Font-Size="Medium" Height="33px" Width="230px" class="form-control">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="AM" Text="Forenoon"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="Afternoon"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group" align="center">
                    <label class="div-Content">No. of Individuals Attended :</label>
                </div>
                <div class="col-sm-6 form-group" align="left">
                    <div class="column" runat="server">
                        <asp:TextBox ID="NoOfMALES_ATTENDED_PMEGP" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" MaxLength="2" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Males Attended" />&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="NoOfMALES_ATTENDED_PMEGP" ErrorMessage="Please Enter Number of Males Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="NoOfFEMALES_ATTENDED_PMEGP" runat="server" autocomplete="off" oncopy="return false" onpaste="return false" MaxLength="2" onkeypress="NumberOnly()" class="form-control" placeholder="No. of Females Attended" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="NoOfFEMALES_ATTENDED_PMEGP" ErrorMessage="Please Enter Number of Females Attended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row; div-table-margin;">
                <div class="col-sm-12 form-group" align="center">
                    <table width="100%" align="center" class="Custom-table">
                        <tr>
                            <th colspan="4" style="font-size: 16px; font-weight: bold; text-align: left; padding-left: 20px; background-color: darkslateblue; color: ghostwhite;">Guests on Dias :</th>
                        </tr>
                        <tr>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Name</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Designation</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Department/Organisation</td>
                            <td width="250px" style="text-align: center; font-weight: bold; font-size: 14px;">Click Add Guests</td>

                        </tr>
                        <tr>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="PMEGP_Guest_Name_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="PMEGP_Guest_Designation_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <input type="text" id="PMEGP_Guest_Department_1" runat="server" oncopy="return false" onpaste="return false" style="border: none; background-color: lightgrey; color: black; width: 100%; text-align: center;" /></td>
                            <td style="text-align: center; font-weight: bold; font-size: 14px; background-color: lightgrey; color: black;">
                                <asp:Button ID="PMEGPGuests" Text="Add Guest" CssClass="btn-warning" Width="100px" runat="server" OnClick="PMEGPGuests_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvPMEGPGuests" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                    GridLines="None" OnRowDeleting="gvPMEGPGuests_RowDeleting"
                                    Width="100%" EnableModelValidation="True" Visible="false">
                                    <RowStyle BackColor="#ffffff" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="PMEGP_GuestName" HeaderText="Guest Name" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="PMEGP_GuestDesgn" HeaderText="GusetDesignation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField DataField="PMEGP_GuestDept" HeaderText="Department/Organisation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                    </Columns>
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row">
                <div align="center">
                    <label class="div-Content" style="text-align: center; font-weight: bold;">Photographs of the event:</label>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <label class="div-Content">1. People on the Dias Photograph:</label>
                            </td>
                            <td> 
                                <asp:FileUpload ID="FupPMEGP_Dias" runat="server" EnableViewState="True" ViewStateMode="Enabled" ValidateRequestMode="Enabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23"  runat="server" ControlToValidate="FupPMEGP_Dias" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplPMEGP_Dias" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">2. Speaker Photograph:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FupPMEGP_Speaker" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="FupPMEGP_Speaker" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplPMEGP_Speaker" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">3. Aidience Photograph:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FupPMEGP_Audience" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="FupPMEGP_Audience" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplPMEGP_Audience" runat="server" Visible="false" Target="_blank"></asp:HyperLink>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="div-Content">4. If any other Photograph:</label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FupPMEGP_Others" runat="server" AutoPostback="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="FupPMEGP_Others" ErrorMessage="Please Upload Event Photos" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HplPMEGP_Others" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>--%>

        <!---------------  Submit Button & Clear Button --------------------->

        <br />
        <div id="SUBMIT_CLEAR_BTNS" runat="server" class="row" align="center" visible="false">
            <asp:Button ID="SubmitBtn" runat="server" Text="SUBMIT" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="SubmitBtn_Click" />
            <asp:Button ID="ClearBtn" runat="server" Text="CLEAR" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="ClearBtn_Click" />
            <asp:HiddenField ID="HdnCampID" runat="server" />
        </div>
</div>
                 </div>
        </div>
        <br />
        <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
        <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    </contenttemplate>
    <script type="text/javascript">

        const blinkingText = document.getElementById("blinkingText");
        function blink() {
            blinkingText.style.visibility = (blinkingText.style.visibility === 'hidden') ? 'visible' : 'hidden';
        } setInterval(blink, 500);

        //$(document).ready(function ()
        //{
        //    $('input[type="text"]').on('paste', function (e) {
        //        e.preventDefault();
        //    });
        //});
        function pageLoad() {
            var date = new Date();
            var yrRange = "1990:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='DateOfCampConducted_EDP']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    maxDate: 0
                })
            $("input[id$='DateOfCampConducted_MSEFC']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    maxDate: 0
                })
            $("input[id$='DateOfCampConducted_MSME']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    maxDate: 0
                })
            $("input[id$='DateOfCampConducted_PMEGP']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    maxDate: 0
                });
        }

    </script>
</asp:Content>
