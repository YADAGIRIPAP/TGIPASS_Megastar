<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="Personal_Interaction_Page_New_Entrepreneurs.aspx.cs" Inherits="UI_TSiPASS_Personal_Interaction_Page_New_Entrepreneurs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        html {
            scroll-behavior: auto;
        }

        .div-errorcenter {
            display: flex;
            justify-content: center;
            font-size: 15px;
        }

        .div-contentcenter {
            display: flex;
            justify-content: left;
            align-items: center;
            font-weight: bold;
            font-size: 15px;
        }

            .div-contentcenter input[type="checkbox"] {
                transform: scale(1.25);
                margin-right: 15px;
            }

        .div-contentcenter-NEW {
            display: flex;
            justify-content: center;
            align-items: center;
            font-weight: bold;
            font-size: 15px;
        }

            .div-contentcenter-NEW input[type="checkbox"] {
                transform: scale(1.25);
                margin-right: 15px;
            }

        .div-Content {
            display: flex;
            padding-left: 65px;
            font-size: 15px;
            justify-content: space-between;
        }

        .checkbox-list label {
            display: inline-block;
            text-align: center;
            font-size: 20px;
            margin-left: 10px;
            margin-right: 45px;
        }

        .checkbox-list1 label {
            display: inline-block;
            text-align: center;
            font-size: 17px;
            margin-left: 5px;
            margin-right: 10px;
            font-weight: bold;
        }

        .error-border {
            /*border: 2px solid red;*/
            box-shadow: 0 0 5px red;
            width: 100%;
            padding: 8px 12px;
            border: 1px solid red;
            border-radius: 4px;
            background-color: #fff;
            color: #333;
            font-size: 14px;
            line-height: 1.4;
        }

        .pointing-hand {
            font-size: 30px;
            animation: blink 1s infinite alternate;
            color: yellowgreen;
        }

        @keyframes blink {
            0% {
                opacity: 1;
            }

            100% {
                opacity: 0;
            }
        }

        .auto-style1 {
            width: 239px;
        }

        .auto-style5 {
            width: 259px;
            height: 35px;
        }

        .auto-style7 {
            width: 503px;
            height: 31px;
        }

        .auto-style9 {
            width: 120px;
        }

        .auto-style10 {
            width: 65px;
        }

        .auto-style11 {
            width: 47px;
        }

        .auto-style12 {
            width: 728px;
        }

        .auto-style13 {
            width: 731px;
        }

        .auto-style14 {
            width: 756px;
        }

        .auto-style18 {
            height: 45px;
        }

        .auto-style25 {
            height: 13px;
        }

        .auto-style26 {
            display: flex;
            justify-content: left;
            align-items: center;
            font-weight: bold;
            font-size: 20px;
            height: 13px;
        }

        .auto-style29 {
            height: 35px;
        }

        .auto-style31 {
            display: flex;
            justify-content: center;
            font-size: 15px;
            height: 13px;
        }

        .auto-style32 {
            width: 246px;
            height: 31px;
        }

        .auto-style33 {
            width: 395px;
        }

        .auto-style34 {
            height: 38px;
        }
    </style>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

    <contenttemplate>
        <div class="panel-body">
            <h1 runat="server" style="text-align: center; font-weight: bold; text-decoration: underline; font-size: 22px;">Interaction With New Entrepreneurs</h1>
            <br />
            <div class="row">


                <table>
                    <tr>
                        <td style="padding-bottom: 10px;">
                            <label class="div-Content">1. Mode of Interaction :</label></td>
                        <td>
                            <div style="padding-left: 75px;">
                                <asp:RadioButtonList ID="ModeOfInteraction" runat="server" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Physical" Value="0" />
                                    <asp:ListItem Text="Telephone" Value="1" />
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>


                    <%--<td style="padding-bottom: 10px;">
                            <label class="div-Content">1a. Udyam Registration :</label></td>
                        <td>--%>

                    <%--                            <div style="padding-left: 75px;">
                                <asp:TextBox ID="txtudyamregno" autocomplete="off" Visible="false" runat="server" oninput="validateInputName(this)" class="form-control" TabIndex="1" Width="100px"></asp:TextBox>
                           
                        </td>
                 
                        </div>--%>

                    <tr>
                        <td style="padding-bottom: 10px;">
                            <label class="div-Content">2. Date of Interaction :</label></td>
                        <td>
                            <div style="padding-left: 70px;">
                                <asp:TextBox ID="txtintractionDt" autocomplete="off" Width="200px" runat="server" MaxLength="16" class="datetimepicker form-control" />

                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td style="padding-top: 10px;">
                            <label class="div-Content">3. Whether the interaction happened at Women Cell :</label></td>
                        <td style="padding-top: 10px;">
                            <div style="padding-left: 25px;">
                                <asp:RadioButtonList ID="WomenCell" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="WomenCell_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="0" />
                                    <asp:ListItem Text="No" Value="1" />
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                    <tr id="Interaction_Id" runat="server" visible="false">
                        <td style="padding-bottom: 10px;">
                            <label class="div-Content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3a. Interaction took place at</label>
                        </td>
                        <td style="padding-left: 25px;">
                            <div>
                                <asp:RadioButtonList ID="Interaction_Level_Existing" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Interaction_Level_Existing_SelectedIndexChanged">
                                    <asp:ListItem Text="District Level" Value="0" />
                                    <asp:ListItem Text="Mandal Level" Value="1" />
                                </asp:RadioButtonList>
                            </div>
                        </td>
                        <td></td>
                        <td></td>
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
                            <asp:TextBox ID="Interaction_Venue_District" autocomplete="off" oninput="validateInputText(this)" Width="150px" runat="server" class="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row" id="Interaction_Block" runat="server" style="padding-left: 80px; padding-bottom: 10px;" visible="false">
                <table>
                    <tr style="margin-bottom: 10px;">
                        <td id="tdmandal" visible="false" runat="server">
                            <label class="div-Content">Mandal:</label>
                        </td>
                        <td class="div-contentcenter" id="tdmandalddl" visible="false" runat="server">
                            <asp:DropDownList ID="ddl_Mandal" runat="server" Width="200px" class="form-control" />
                        </td>
                        <td id="celldate" runat="server" visible="false">
                            <label class="div-Content">Date:</label>
                        </td>
                        <td class="div-contentcenter" id="celldate1" runat="server" visible="false">
                            <asp:TextBox ID="Interaction_Date" autocomplete="off" Width="200px" runat="server" MaxLength="16" class="datetimepicker form-control" />
                        </td>
                        <%--<td>
                            <label class="div-Content">Village:</label>
                        </td>
                        <td class="div-contentcenter">
                            <asp:DropDownList ID="ddl_Village" runat="server" Width="240px" class="form-control" />
                        </td>--%>
                    </tr>
                    <tr style="margin-bottom: 10px;">
                        <%--<td>
                            <label class="div-Content">Date:</label>
                        </td>
                        <td class="div-contentcenter">
                            <input type="text" id="Interaction_Date" autocomplete="off" width="240px" runat="server" maxlength="16" class="datetimepicker form-control" />
                        </td>--%>
                        <td>
                            <label class="div-Content">Venue of Interaction :</label>
                        </td>
                        <td class="div-contentcenter">
                            <asp:DropDownList ID="Interaction_Venue" Width="200px" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="Interaction_Venue_SelectedIndexChanged"></asp:DropDownList>
                            <%--<asp:TextBox ID="Interaction_Venue" Width="200px" runat="server"></asp:TextBox>--%>
                        </td>
                        <td>
                            <div id="Other_Venue_1" runat="server" visible="false">
                                <label class="div-Content">Other Venue :</label>
                            </div>
                        </td>
                        <td class="div-contentcenter">
                            <div id="Other_Venue_2" runat="server" visible="false">
                                <asp:TextBox ID="OtherVenue" autocomplete="off" runat="server" oninput="validateInputName(this)" class="form-control" TabIndex="1"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="row">
                <table>
                    <tr style="margin-bottom: 15px; margin-top: 10px;">
                        <td width="300px" style="margin-bottom: 25px; margin-top: 10px;">
                            <label class="div-Content">4. Candidate's Name :</label>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;">
                            <asp:TextBox ID="Candidate_Name_New" runat="server" autocomplete="off" class="form-control" oninput="validateInputName(this)" TabIndex="1" ValidationGroup="group" Width="200px"></asp:TextBox>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;">
                            <label class="div-Content">5. Contact Number :</label>
                        </td>
                        <td class="div-contentcenter" style="margin-top: 10px;">
                            <asp:TextBox ID="Contact_Number_New" runat="server" autocomplete="off" onkeypress="NumberOnly()" onkeyup="validatePhoneNumber()" Width="200px" MaxLength="10" class="form-control" ValidationGroup="group" TabIndex="1"></asp:TextBox>
                        </td>
                        <td class="div-errorcenter" style="margin-bottom: 10px;">
                            <div id="error" style="color: red;"></div>
                        </td>
                        <%--<td>
                            <label class="div-Content">Village:</label>
                        </td>
                        <td class="div-contentcenter">
                            <asp:DropDownList ID="ddl_Village" runat="server" Width="240px" class="form-control" />
                        </td>--%>
                    </tr>
                    <tr style="margin-bottom: 15px; margin-top: 10px;">
                        <%--<td>
                            <label class="div-Content">Date:</label>
                        </td>
                        <td class="div-contentcenter">
                            <input type="text" id="Interaction_Date" autocomplete="off" width="240px" runat="server" maxlength="16" class="datetimepicker form-control" />
                        </td>--%>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style25">
                            <label class="div-Content">6. Email ID :</label>
                        </td>
                        <td class="auto-style26" style="margin-top: 10px;">
                            <asp:TextBox ID="Mail_ID_New" autocomplete="off" runat="server" oninput="CapitalizeText(this)" onkeyup="validateEmail(this.value)" class="form-control" Width="200px" TabIndex="1"></asp:TextBox>
                        </td>
                        <td class="auto-style31" style="margin-bottom: 5px; margin-top: 10px;">
                            <span id="error-message" style="color: red;"></span>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style25">
                            <div>
                                <label class="div-Content">7. Age :</label>
                            </div>
                        </td>
                        <td class="auto-style26" style="margin-bottom: 15px; margin-top: 10px;">
                            <div>
                                <asp:TextBox ID="Candidate_Age_New" runat="server" autocomplete="off" class="form-control" MaxLength="2" onkeypress="NumberOnly()" OnTextChanged="Candidate_Age_New_TextChanged" AutoPostBack="true" TabIndex="1" ValidationGroup="group" Width="200px"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr style="margin-bottom: 10px; margin-top: 10px;">
                        <td style="margin-bottom: 10px; margin-top: 10px;" class="auto-style29">
                            <div>
                                <label class="div-Content">8. Gender :</label>
                            </div>
                        </td>
                        <td style="margin-bottom: 10px; margin-top: 10px;" class="auto-style29">
                            <div>
                                <asp:RadioButtonList ID="Gender_New" runat="server" Font-Size="15px" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Gender_New_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Male" Value="0" style="margin-right: 15px;" />
                                    <asp:ListItem Text="Female" Value="1" />
                                </asp:RadioButtonList>
                            </div>
                        </td>
                        <td class="auto-style5" style="margin-bottom: 15px; margin-top: 10px;">
                            <div>
                                <label class="div-Content">9. Social Category :</label>
                            </div>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style29">
                            <div style="margin-bottom: 7px;">
                                <asp:DropDownList ID="Social_Category_New" runat="server" Font-Size="15px" Width="200px" class="form-control" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Social_Category_New_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="--Select--" Value="0" style="margin-right: 10px;" />
                                    <asp:ListItem Text="General" Value="1" style="margin-right: 10px;" />
                                    <asp:ListItem Text="OBC" Value="2" style="margin-right: 10px;" />
                                    <asp:ListItem Text="SC" Value="3" style="margin-right: 10px;" />
                                    <asp:ListItem Text="ST" Value="4" style="margin-right: 10px;" />
                                    <asp:ListItem Text="MINORITY" Value="5" style="margin-right: 10px;" />
                                    <%-- <asp:ListItem Text="PHYSICALLY HANDICAPPED" Value="5" />--%>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr style="margin-bottom: 15px; margin-top: 10px;">
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style18">
                            <div>
                                <label class="div-Content">10. PHC Category :</label>
                            </div>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style18">
                            <asp:RadioButtonList ID="rblPHC" runat="server" Font-Size="15px" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="1">
                                <asp:ListItem Text="Yes" Value="0" />
                                <asp:ListItem Text="No" Value="1" />
                            </asp:RadioButtonList>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style18">
                            <div>
                                <label class="div-Content">11. Qualification :</label>
                            </div>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style18">
                            <div>
                                <asp:DropDownList ID="Qualification_List_New" Font-Size="15px" runat="server" Width="200px" class="form-control" TabIndex="1" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="--Select--" Value="0" />
                                    <asp:ListItem Text="Under 12ᵗʰ" Value="1" />
                                    <asp:ListItem Text="Graduate" Value="2" />
                                    <asp:ListItem Text="Post Graduate" Value="3" />
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr style="margin-bottom: 15px; margin-top: 10px;">
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style18">
                            <div>
                                <label class="div-Content">12. PAN Card No. :</label>
                            </div>
                        </td>
                        <td style="margin-bottom: 15px; margin-top: 10px;" class="auto-style18">
                            <asp:TextBox ID="txtPAN" runat="server" Width="200px" onpaste="return false" onblur="fnValidatePAN(this);" Class="form-control" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </div>
            <div class="row">
                <table width="90%" style="margin-bottom: 0px; margin-top: 10px;">
                    <tr>
                        <td style="padding-bottom: 5px; width: 500px">
                            <div style="padding-top: 0px; padding-bottom: 0px">
                                <label class="div-Content">13. Whether the applicant has any Sector specific Experience :</label>
                            </div>
                        </td>
                        <td style="padding-bottom: 5px;">
                            <div class="auto-style32" style="padding-top: 0px; padding-bottom: 0px">
                                <asp:RadioButtonList ID="RadioButtonList1" Font-Size="15px" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="0" />
                                    <asp:ListItem Text="No" Value="1" />
                                </asp:RadioButtonList>
                            </div>

                        </td>
                    </tr>
                </table>
                <table width="90%" style="margin-bottom: 0px; margin-top: 0px;">
                    <tr>
                        <td style="width:200px">
                            <div style="margin-bottom: 0px; padding-left: 35px;" id="sector_category_1" runat="server" visible="false">
                                <label class="div-Content">13a. Sector:</label>
                            </div>
                        </td>
                        <td style="width:300px">
                            <div style="margin-bottom: 0px; padding-top: 0px;" id="sector_category_2" runat="server" visible="false" class="auto-style1">
                                <asp:DropDownList ID="sector_dropdown" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="sector_dropdown_SelectedIndexChanged" Width="200px" />
                            </div>
                        </td>

                        <td style="width:200px">
                            <div id="ExperienceSectorBlock_1" runat="server" visible="false">
                                <label style="font-size: 15px" >13b. Experience in Sector:</label>
                            </div>
                        </td>
                        <td>
                            <div id="TextYears" runat="server" visible="false">
                                <asp:TextBox ID="YearsofExperience" runat="server" Width="200px" onkeypress="NumberOnly()" MaxLength="2" class="form-control" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>


            <div class="row">
                <table>
                    <tr style="margin-bottom: 15px; margin-top: 10px;">
                        <td width="300px" style="margin-bottom: 15px; margin-top: 10px;">

                            <label class="div-Content">14. Purpose of Visit / Interaction :</label></td>
                        <td class="auto-style34" allign="left" style="margin-bottom: 15px; margin-top: 10px;">
                            <asp:TextBox ID="Visit_Purpose" Width="200px" autocomplete="off" runat="server" oninput="validateInputText(this)" class="form-control" TabIndex="1"></asp:TextBox>

                        </td>
                    </tr>

                </table>
            </div>
            
            
        </div>

        <div class="row" runat="server">
            <div class="div-Content">
                <table>
                    <tr>
                        <td width="5px">
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td align="left" style="padding-top: 10px">
                            <label>Type of Interaction: 1. Schemes &nbsp;&nbsp;&nbsp; 2. Trainings&nbsp;&nbsp;&nbsp;&nbsp; 3. Land </label>
                            <%--                            <asp:CheckBoxList ID="Main_Interaction" runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="Main_Interaction_SelectedIndexChanged" Visible="true" />--%>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 75px">
            <label style="font-size: 20px; font-weight: bold;">1.</label><asp:CheckBox ID="chkSchemes" Font-Size="20px" Font-Bold="true" Text="Schemes" runat="server" AutoPostBack="true" OnCheckedChanged="chkSchemes_CheckedChanged" />
            <%--                <label id="lblschms" runat="server" visible="false" style="padding-left: 15px; font-size: 18px">The type of Schemes are: a.PMEGP&nbsp;&nbsp; b. PMFME&nbsp;&nbsp; c. T-IDEA&nbsp;&nbsp; d. T-PRIDE&nbsp;&nbsp; e. MUDRA&nbsp;&nbsp; f.CGTMSE&nbsp;&nbsp; g. DalithaBandhu </label>--%>
            <label id="lblschms" runat="server" visible="false" style="padding-left: 15px; font-size: 15px">The type of Schemes are: a.TSiPASS &nbsp;&nbsp; b.PMEGP&nbsp;&nbsp; c. PMFME&nbsp;&nbsp; d. T-IDEA&nbsp;&nbsp; e. T-PRIDE&nbsp;&nbsp; f. MUDRA&nbsp;&nbsp; g.CGTMSE&nbsp;&nbsp; h.DALITHABANDHU </label>

        </div>
        <div class="row" id="SchemeName" runat="server" visible="false">
            <div class="div-contentcenter-NEW" style="color: darkslateblue;">
                <asp:CheckBoxList ID="Scheme_Names" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="Scheme_Names_SelectedIndexChanged" />

            </div>
        </div>

        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lblTS" visible="false" style="font-size: 20px">1a.</label><asp:CheckBox ID="CheckTSIPASS" Font-Size="20px" Text="TSiPASS" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="CheckTSIPASS_CheckedChanged" />
        </div>
        <div class="row" id="Tsipass" runat="server" visible="false" style="padding-left: 120px; padding-right: 50px;">
            <br />

            <%--            <p style="font-size: 22px; font-weight: bold; text-decoration: underline;">MUDRA :</p>--%>
            <label style="font-size: 15px;">
                &nbsp;&nbsp;&nbsp; The Telangana Government has enacted the “Telangana State Industrial Project Approval and Self-Certification System (TS-iPASS) Act, 2014” (Act No.3 of 2014) for speedy processing of applications for issue of various clearances required for setting up of industries at a single point based on the self-certificate provided by the entrepreneur and also to create investor friendly environment in the State of Telangana.
            </label>

            <br />
            <div class="row" style="font-size: 15px; padding-left: 50px">
                &nbsp;&nbsp;&nbsp;&nbsp;
                 
                <asp:Label runat="server" Style="font-weight: bold;">a.The Salient features of the TS-iPASS are:</asp:Label>
                <ul>
                    <li>All departments connected for establishing and operation of an Enterprise brought under purview of TS-iPASS.</li>
                    <li>Time Limits set for each approval varying from 1 day to a maximum of 30 days depending upon on the complexity of the approval.</li>
                    <li>Pre-Scrutiny of the applications at State Level and District Level to assist the entrepreneurs in a proper submission of applications and to avoid delay in processing the files by the departments.</li>
                    <li>Making mandatory for the Competent Authorities to seek shortfall/additional information required, if any, only once, within three days from receipt of the application.</li>
                    <li>Empowering the Entrepreneurs with Right to clearances under TS-iPASS, to know the reasons for delay if any in getting the clearance within time limits and penalizing the officers responsible for the delay.</li>

                </ul>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div style="color: orange" class="pointing-hand _colored:red">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="chkTSIPASSintrsted" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under TSIPASS" OnCheckedChanged="chkTSIPASSintrsted_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div>
                                <asp:LinkButton runat="server" ID="LinkTSIPASS" Visible="false" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about TSIPASS" OnClick="LinkTSIPASS_Click"></asp:LinkButton>

                                <%--click here <a href="https://kviconline.gov.in/pmegpeportal/pmegphome/index.jsp" target="_blank">PMEGP Portal</a> to know more about PMEGP.--%><%-- → --%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1a" visible="false" style="font-size: 20px">1b.</label><asp:CheckBox ID="chkPMEGP" Font-Size="20px" Text="PMEGP" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPMEGP_CheckedChanged" />
        </div>
        <div class="row" id="PMEGP_CONTENT" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">

            <%--<p style="font-size: 22px; font-weight: bold; text-decoration: underline;">1. PMEGP :</p>--%>
            <div class="row">
                <table>
                    <tr>
                        <td style="font-weight: bold; padding-left: 30px">a. Eligibility Criteria</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="PMEGP_ELIGIBILTY" runat="server"></asp:BulletedList>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; padding-left: 30px">b. Financial Details</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="PMEGP_FINANCIAL" runat="server"></asp:BulletedList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row" style="padding-left: 50px">
                <table style="border: 1px solid #000;" class="auto-style12">
                    <tr style="border: 1px solid #000;">
                        <td style="border: 1px solid #000; font-weight: bold;">Categories of beneficiaries under PMEGP 
                            <br />
                            (for setting up of new enterprises)</td>
                        <td style="border: 1px solid #000; font-weight: bold;" class="auto-style9">Beneficiary's
                            <br />
                            contribution<br />
                            (of project cost)</td>
                        <td colspan="2" style="border: 1px solid #000; font-weight: bold;">Rate of Subsidy<br />
                            (of project cost)</td>
                    </tr>
                    <tr style="border: 1px solid #000;">
                        <td style="border: 1px solid #000;">Area (location of project/unit)</td>
                        <td style="border: 1px solid #000;" class="auto-style9"></td>
                        <td style="border: 1px solid #000;" class="auto-style10">Urban</td>
                        <td style="border: 1px solid #000;" class="auto-style11">Rural</td>
                    </tr>
                    <tr style="border: 1px solid #000;">
                        <td style="border: 1px solid #000;">General Category</td>
                        <td style="border: 1px solid #000;" class="auto-style9">10%</td>
                        <td style="border: 1px solid #000;" class="auto-style10">15%</td>
                        <td style="border: 1px solid #000;" class="auto-style11">25%</td>
                    </tr>
                    <tr style="border: 1px solid #000;">
                        <td style="border: 1px solid #000;">Special Category (including SC,ST,OBC, 
                            Minorities, Women, Ex-Servicemen, 
                            <br />
                            Transgender,
                            Differently abled, NER, Aspirational Districts, 
                            Hill and 
                            <br />
                            Border areas (as notified by the Government) etc.</td>
                        <td style="border: 1px solid #000;" class="auto-style9">05%</td>
                        <td style="border: 1px solid #000;" class="auto-style10">25%</td>
                        <td style="border: 1px solid #000;" class="auto-style11">35%</td>
                    </tr>
                </table>
            </div>
            <div class="row">
                <asp:Label runat="server" Style="font-weight: bold; padding-left: 30px;">c. Required Documents</asp:Label>
                <ul>
                    <li>Aadhar card</li>
                    <li>Caste Certificate</li>
                    <li>Special Category Certificate, wherever required</li>
                    <li>Rural Area certificate</li>
                    <li>Project Report</li>
                    <li>Education/EDP/Skill Development training certificate</li>
                    <%--<li><a href="https://kviconline.gov.in/pmegpeportal/pmegphome/index.jsp" target="_blank">PMEGP Portal</a></li>--%>
                </ul>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div style="color: orange" class="pointing-hand _colored:red">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="PMEGP_VALIDATION" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under PMEGP" OnCheckedChanged="PMEGP_VALIDATION_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="PMEGP_LINK" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="LinkPMEGP" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about PMEGP" OnClick="LinkPMEGP_Click"></asp:LinkButton>
                                <%--click here <a href="https://kviconline.gov.in/pmegpeportal/pmegphome/index.jsp" target="_blank">PMEGP Portal</a> to know more about PMEGP.--%><%-- → --%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1b" visible="false" style="font-size: 20px">1c.</label><asp:CheckBox ID="ChkPMFME" Font-Size="20px" Text="PMFME" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="ChkPMFME_CheckedChanged" />
        </div>
        <div class="row" id="PMFME_CONTENT" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <%--            <p style="font-size: 22px; font-weight: bold; text-decoration: underline;">2.PMFME :</p>--%>
            <div class="row">
                <table>
                    <tr>
                        <td style="font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a.&nbsp; Eligilibility Criteria</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="PMFME_ELIGIBILTY" runat="server"></asp:BulletedList>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b. Financial Details</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="PMFME_FINANCIAL" runat="server"></asp:BulletedList>
                        </td>
                    </tr>
                    <%--<tr>
                                <td style="padding-left: 40px;"><a href="https://pmfme.mofpi.gov.in/pmfme/#/Home-Page" target="_blank">PMFME Portal</a></td>
                            </tr>--%>
                </table>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under PMFME" OnCheckedChanged="CheckBox1_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="Div1" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="LinkPMFME" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about PMFME" OnClick="LinkPMFME_Click"></asp:LinkButton>
                                <%--click here <a href="https://pmfme.mofpi.gov.in/pmfme/#/Home-Page" target="_blank">PMFME Portal</a> to know more about PMFME.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1c" visible="false" style="font-size: 20px">1d.</label><asp:CheckBox ID="chkTidea" Font-Size="20px" Text="T-IDEA" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chkTidea_CheckedChanged" />
        </div>
        <div class="row" id="T_IDEA" runat="server" visible="false" style="padding-left: 120px; padding-right: 50px;">
            <p style="font-size: 15px; padding-left: 60px">T-IDEA stands for “Telangana State Industrial Development and Entrepreneur Advancement) incentive scheme (G.O.MS.No.28) for General Category entrepreneurs. </p>
            <p style="font-size: 15px; padding-left: 60px">Incentives to encourage the process of industrialization: </p>
            <table style="border: 1px solid #000;" class="auto-style15">
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000; font-weight: bold;">Type of Incentive</td>
                    <td style="border: 1px solid #000; font-weight: bold;" class="auto-style9">Micro</td>
                    <td style="border: 1px solid #000; font-weight: bold;">Small</td>
                    <td style="border: 1px solid #000; font-weight: bold;">Medium</td>
                    <td style="border: 1px solid #000; font-weight: bold;">Large</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Stamp duty/Transfer duty reimbursement</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Rebate in land cost in IE s /IP s</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Investment Subsidy</td>
                    <td style="border: 1px solid #000;" class="auto-style9">15% limited to Rs.20  lakh</td>
                    <td style="border: 1px solid #000;" class="auto-style9">15% limited to Rs.20  lakh</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of VAT/CST/SGST</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100% for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100% for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">75% for 7 years from DCP or upto realization of 100% fixed capital investment</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% for 7 years from DCP or upto realization of 100% fixed capital investment</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Seed capital assistance to 1st generation entrepreneurs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">10% of machinery cost, later deducted from Investment Subsidy</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of cost involved in skill upgradation </td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of costs incurred for quality certification</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of costs incurred for adopting cleaner technologies</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Interest subsidy under Pavala Vaddi Scheme</td>
                    <td style="border: 1px solid #000;" class="auto-style9">3% to 9%  on term loan for 5years from  DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">3% to 9%  on term loan for 5years from  DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Rebate in land conversion charges</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Power cost reimbursement</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.00 per unit for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.00 per unit for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.00 per unit for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.00 per unit for 5 years from DCP</td>
                </tr>
            </table>

            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under T-IDEA" OnCheckedChanged="CheckBox5_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="Div5" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="LinkTIDEA" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about T-IDEA" OnClick="LinkTIDEA_Click"></asp:LinkButton>

                                <%--click here <a href="https://industries.telangana.gov.in/Library/2015INDS_MS77.pdf" target="_blank">T-IDEA</a> to know more about T-IDEA.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1d" visible="false" style="font-size: 20px">1e.</label><asp:CheckBox ID="chkTpride" Font-Size="20px" Text="T-PRIDE" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chkTpride_CheckedChanged" />
        </div>
        <div class="row" id="T_PRIDE" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <%--            <p style="font-size: 22px; font-weight: bold; text-decoration: underline;">T-PRIDE :</p>--%>

            <%--            <p style="font-size: 22px; font-weight: bold; text-decoration: underline;">T-IDEA :</p>--%>

            <p style="font-size: 15px; padding-left: 60px">T-PRIDE stands for Telangana State Program for Rapid Incubation for Dalit Entrepreneurs incentive scheme (G.O.MS.No 29).</p>
            <p style="font-size: 15px; padding-left: 60px">Special incentive package for SC/ST/PHC Entrepreneurs: </p>
            <table style="border: 1px solid #000;" class="auto-style15">
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000; font-weight: bold;">Type of Incentive</td>
                    <td style="border: 1px solid #000; font-weight: bold;" class="auto-style9">Micro</td>
                    <td style="border: 1px solid #000; font-weight: bold;">Small</td>
                    <td style="border: 1px solid #000; font-weight: bold;">Medium</td>
                    <td style="border: 1px solid #000; font-weight: bold;">Large</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Stamp duty/Transfer duty reimbursement</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100%</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Rebate in land cost in IE s /IP s</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50%</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50%</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Rebate in land conversion charges</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.10lakhs</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Subsidy on expenses incurred for  quality certification</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100% limited to Rs.3.00lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100% limited to Rs.3.00lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Infrastructure costs reimbursement for standalone units</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.1 crore</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.1 crore</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Power cost reimbursement</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.50 per unit for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.50 per unit for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.50 per unit for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">@Rs.1.50 per unit for 5 years from DCP</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Investment Subsidy</td>
                    <td colspan="2" style="border: 1px solid #000;" class="auto-style18"><u>35% limited to Rs.75 lakhs.</u></BR>Additional 5% investment subsidy for units setup in Schedule areas by  ST entrepreneurs with a max limit of Rs.75.00 Lakh.</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of VAT/CST/SGST</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100% for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">100% for 5 years from DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">75% for 7 years from DCP or upto realization of 100% fixed capital investment</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% for 7 years from DCP or upto realization of 100% fixed capital investment</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Seed capital assistance to 1st generation entrepreneurs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">20% of machinery cost, later deducted from Investment Subsidy</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of cost involved in skill upgradation </td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                    <td style="border: 1px solid #000;" class="auto-style9">50% limited to Rs.2000 per person</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Reimbursement of costs incurred for adopting cleaner technologies</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                    <td style="border: 1px solid #000;" class="auto-style9">25% limited to Rs.5.00 lakhs</td>
                </tr>
                <tr style="border: 1px solid #000;">
                    <td style="border: 1px solid #000;">Interest subsidy under Pavala Vaddi Scheme</td>
                    <td style="border: 1px solid #000;" class="auto-style9">3% to 9%  on term loan for 5years from  DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">3% to 9%  on term loan for 5years from  DCP</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                    <td style="border: 1px solid #000;" class="auto-style9">NA</td>
                </tr>
            </table>
            <p style="font-size: 15px; padding-left: 60px"><b>Additional benefits under T-PRIDE:</b></p>

            <ul style="font-size: 15px; padding-left: 90px">
                <li>Additional 10% investment subsidy on fixed capital investment limited to Rs. 10.00 lakh to MSEs, solely owned by women entrepreneur (total investment subsidy limited to Rs.75 lakhs only)</li>
                <li>Land will be allotted to SC / ST Entrepreneurs in proportion to their population in the State.</li>
                <li>It will be allotted on lease basis for a period of 10 years with lease rent @ Rs. 100/- per annum per acre</li>
                <li>Special fund for direct lending to SC/ST entrepreneurs</li>
            </ul>
            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under T-PRIDE" OnCheckedChanged="CheckBox6_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="Div6" runat="server" visible="false" style="font-size: 15px" class="auto-style13">
                                <asp:LinkButton runat="server" ID="LinkTPRIDE" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about T-PRIDE" OnClick="LinkTPRIDE_Click"></asp:LinkButton>
                                <%--click here <a href="https://industries.telangana.gov.in/Library/2015INDS_MS78.pdf" target="_blank">T-PRIDE</a> to know more about T-PRIDE.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <%--  </div>--%>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1e" visible="false" style="font-size: 20px">1f.</label><asp:CheckBox ID="chkMudra" Font-Size="20px" Text="Mudra" runat="server" AutoPostBack="true" Visible="false" OnCheckedChanged="chkMudra_CheckedChanged" />
        </div>
        <div class="row" id="Mudra_block" runat="server" visible="false" style="padding-left: 120px; padding-right: 50px;">
            <%--            <p style="font-size: 22px; font-weight: bold; text-decoration: underline;">MUDRA :</p>--%>
            <label style="font-size: 15px;">
                &nbsp;&nbsp;&nbsp; Pradhan Mantri Mudra Yojana (PMMY) is a scheme set up by the Government of India (GoI) through
                <br />
            </label>
            <p style="font-size: 15px;">&nbsp;&nbsp;&nbsp;&nbsp;MUDRA (a subsidiary of SIDBI) that helps in facilitating micro credit upto Rs. 10 lakh to small business owners</p>
            <div class="row" style="font-size: 15px;">
                <table>
                    <tr>
                        <td style="font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp; a. Eligilibility Criteria</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="MUDRA_ELIGIBILITY" runat="server"></asp:BulletedList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row" style="font-size: 15px;">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" Style="font-weight: bold;">b. The loans under MUDRA scheme can be availed only through:</asp:Label>
                <ul>
                    <li>Public Sector Banks</li>
                    <li>Private Sector Banks</li>
                    <li>State Operated Cooperative Banks</li>
                    <li>Rural Banks from Regional Sector</li>
                    <li>Institutions Offering Micro Finance</li>
                    <li>Financial Companies Other Than Banks</li>
                </ul>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under MUDRA" OnCheckedChanged="CheckBox2_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="Div2" runat="server" visible="false" class="auto-style14">
                                <asp:LinkButton runat="server" ID="LinkMUDRA" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about MUDRA" OnClick="LinkMUDRA_Click"></asp:LinkButton>

                                <%--click here <a href="https://www.mudra.org.in/" target="_blank">MUDRA</a> to know more about MUDRA.--%>
                                <br />
                                <%--                                    <asp:LinkButton runat="server" ID="LinkUDYAMIMITRA" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about UDYAMIMITRA" OnClick="LinkUDYAMIMITRA_Click"></asp:LinkButton>--%>

                                <%--click here <a href="https://udyamimitra.in/page/mudra-loans" target="_blank">UDYAMIMITRA</a> to know more about UDYAMIMITRA.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 92px">
            <label runat="server" id="lbl1f" visible="false" style="font-size: 20px">1g.</label><asp:CheckBox ID="chkCGTMSE" Font-Size="20px" Text="CGTMSE" runat="server" AutoPostBack="true" Visible="false" OnCheckedChanged="chkCGTMSE_CheckedChanged" />
        </div>
        <div class="row" id="CGTMSE_block" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <%--                <p style="font-size: 15px; padding-left: 60px">Availability of bank credit without the hassles of collaterals / third party guarantees</p>--%>
            <p style="font-size: 15px; padding-left: 60px">Credit Guarantee Fund Trust for Micro and Small Enterprises (CGTMSE) is jointly set up by Ministry of Micro, Small & Medium Enterprises (MSME), Government of India and Small Industries Development Bank of India (SIDBI) to catalyse flow of institutional credit to Micro & Small Enterprises (MSEs). </p>
            <p style="font-size: 15px; padding-left: 60px">Credit Guarantee Scheme (CGS) was launched to strengthen credit delivery system and to facilitate flow of credit to the MSE sector, create access to finance for unserved, under-served and underprivileged, making availability of finance from conventional lenders to new generation entrepreneurs. </p>


            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under CGTMSE" OnCheckedChanged="CheckBox7_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div style="font-size: 15px" id="Div7" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="LinkCGTMSE" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about CGTMSE" OnClick="LinkCGTMSE_Click"></asp:LinkButton>
                                <%--click here <a href="https://www.cgtmse.in/Home" target="_blank">CGTMSE</a> to know more about CGTMSE.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1g" visible="false" style="font-size: 20px">1h.</label><asp:CheckBox ID="chkDalitabandu" Font-Size="20px" Text="DalithaBandhu" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chkDalitabandu_CheckedChanged" />
        </div>
        <div class="row" id="DALITHA_BANDHU" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <p style="font-size: 15px; padding-left: 60px">One time capital assistance @ Rs.10.00 lakhs per SC family for all SC eligible families as 100% grant / subsidy to establish a suitable income generating schemes as per their choice (without bank loan linkage)</p>

            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="CheckBox8" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under Dlitha Bandhu" OnCheckedChanged="CheckBox8_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="Div8" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="LinkDalithaBandhu" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about Dalitha Bandhu" OnClick="LinkDalithaBandhu_Click"></asp:LinkButton>
                                <%--click here <a href="https://www.db2021.telangana.gov.in/" target="_blank">DALITHA BANDHU</a> to know more about DALITHA BANDHU.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1j" visible="false" style="font-size: 20px">1i.</label><asp:CheckBox ID="chckudyam" Font-Size="20px" Text="Udyam Registration" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chckudyam_CheckedChanged" />
        </div>
        <div class="row" id="divudyam" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <p style="font-size: 15px; padding-left: 60px">Udyam Registration is a simple yet significant step taken by the Government of India to empower and uplift small businesses. Formerly known as the Udyog Aadhaar registration, this new process aims to simplify how SMEs register themselves under the Micro, Small, and Medium Enterprises Development (MSMED) Act, 2006.</p>
            <p style="font-size: 15px; padding-left: 60px">Registration Process is totally free.</p>
            <p style="font-size: 15px; padding-left: 60px">Eligibility</p>
            <p style="font-size: 15px; padding-left: 60px">Any enterprise that meets the criteria of micro, small, or medium enterprise as per the investment and turnover limits specified in the MSMED Act, 2006 is eligible for Udyam registration. The Aadhaar number of the proprietor, partner is required for the registration process.</p>
            <p style="font-size: 15px; padding-left: 60px"><b>Benefits of Udyam Registration</b></p>

            <ul style="font-size: 15px; padding-left: 90px">
                <li>Access to Benefits and Subsidies</li>
                <li>Easier Bank Loans</li>
                <li>Collateral-Free Loans</li>
                <li>Protection against Delayed Payments</li>
                <li>Global Recognition</li>
                <li>Easier Compliance</li>
                <li>Priority Sector Lending</li>
            </ul>

            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="chckdivudyam1" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under Udyam" OnCheckedChanged="chckdivudyam1_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="Divudaym1" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="lnkudyam" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about Udyam Registration" OnClick="lnkudyam_Click"></asp:LinkButton>
                                <%--click here <a href="https://www.db2021.telangana.gov.in/" target="_blank">DALITHA BANDHU</a> to know more about DALITHA BANDHU.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="padding-left: 75px">
            <label style="font-size: 20px; font-weight: bold;">2.</label><asp:CheckBox ID="chkTrainings" Font-Size="20px" Font-Bold="true" Text="Trainings" runat="server" AutoPostBack="true" OnCheckedChanged="chkTrainings_CheckedChanged" />
            <label id="lbltrainings" runat="server" visible="false" style="padding-left: 15px; font-size: 15px"></label>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl2a" visible="false" style="font-size: 20px">2a.</label><asp:CheckBox ID="chktasks" Font-Size="20px" Text="TASK (Telangana Academy of Skill and Knowledge)" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chktasks_CheckedChanged" />
        </div>
        <div class="row" id="Trainingtasks_Block" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <%--<p style="font-size: 22px; font-weight: bold; text-decoration: underline;">TRAININGS [TASKS & DET] :</p>--%>
            <table>
                <%--   <tr>
                    <td style="font-weight: bold; font-size: 18px;">TASKS</td>
                </tr>--%>
                <tr>
                    <td style="font-size: 15px;">
                        <ul>
                            <li>TASK offers a wide range of skill development programs across various sectors, including IT and IT-enabled services, manufacturing, healthcare, hospitality, and more.</li>
                            <li>TASK provides Skill Offerings for Students of Engineering, Degree, Pharmacy, Polytechnic, MBA, MCA & PG</li>
                        </ul>
                        <div class="row">
                            <table>
                                <tr>
                                    <td>
                                        <div style="color: orange" class="pointing-hand">👉</div>
                                    </td>
                                    <td style="padding-left: 15px;">
                                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under Training (TASK)" OnCheckedChanged="CheckBox3_CheckedChanged" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                                        <div id="Div3" runat="server" visible="false">
                                            <asp:LinkButton runat="server" ID="LinkTASK" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about TASK (Telangana)" OnClick="LinkTASK_Click"></asp:LinkButton>

                                            <%--click here <a href="https://task.telangana.gov.in/" target="_blank">TASK(TELANGANA)</a> to know more about TASK(TELANGANA).--%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </td>
                </tr>
            </table>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl2b" visible="false" style="font-size: 20px">2b.</label><asp:CheckBox ID="chkDET" Font-Size="20px" Text="DET (Department of Employment and Training)" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chkDET_CheckedChanged" />
        </div>
        <div class="row" id="TrainingDET_Block" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <table>
                <%--<tr>
                    <td style="font-weight: bold; font-size: 18px;">DET(DEPARTMENT OF EMPLOYMENT AND TRAINING)</td>
                </tr>--%>
                <tr>
                    <td style="font-size: 15px;">
                        <ul>
                            <li>Information about various skill development and training programs offered by the government to enhance employability.</li>
                        </ul>
                        <div class="row">
                            <table>
                                <tr>
                                    <td>
                                        <div class="pointing-hand">👉</div>
                                    </td>
                                    <td style="padding-left: 15px;">
                                        <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under Training (DET)" OnCheckedChanged="CheckBox4_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                                        <div id="Div4" runat="server" visible="false">
                                            <asp:LinkButton runat="server" ID="LinkDET" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about Employment (Telangana)" OnClick="LinkDET_Click"></asp:LinkButton>

                                            <%--click here <a href="https://employment.telangana.gov.in/" target="_blank">EMPLOYMENT(TELANGANA)</a> to know more about EMPLOYMENT(TELANGANA).--%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="row" style="padding-left: 90px">
            <label runat="server" id="lbl1i" visible="false" style="font-size: 20px">3c.</label><asp:CheckBox ID="chckNIMSME" Font-Size="20px" Text="NIMSME" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="chckNIMSME_CheckedChanged" />
        </div>
        <div class="row" id="divNIMSME" runat="server" visible="false" style="padding-left: 100px; padding-right: 50px;">
            <p style="font-size: 15px; padding-left: 60px">NIMSME (National Institute for Micro, Small and Medium Enterprises) is an Organisation of Ministry of MSME, Govt. of India located at Yousufguda, Hyderabad. It is a pioneer institute in the field of MSME and Entrepreneurship Development. The Institute provides a host of services with focus on Capacity Building, Research, Consultancy, Skilling, Education and Extension.</p>

            <div class="row">
                <table>
                    <tr>
                        <td>
                            <div class="pointing-hand">👉</div>
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:CheckBox ID="chckNIMSMEd" runat="server" AutoPostBack="true" Font-Bold="true" TabIndex="1" Text="Whether the applicant is interested to apply under NIMSME" OnCheckedChanged="chckNIMSMEd_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="DivNIMSME1" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="lnkNIMSME" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about NIMSME" OnClick="lnkNIMSME_Click"></asp:LinkButton>
                                <%--click here <a href="https://www.db2021.telangana.gov.in/" target="_blank">DALITHA BANDHU</a> to know more about DALITHA BANDHU.--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="row" style="padding-left: 75px">

            <label style="font-size: 20px; font-weight: bold;">3.</label><asp:CheckBox ID="chkLand" Font-Size="20px" Font-Bold="true" Text="Land" runat="server" AutoPostBack="true" OnCheckedChanged="chkLand_CheckedChanged" />
            <%--             <label id="Label1" runat="server" visible="false" style="padding-left: 15px; font-size:18px " >The Land type of&nbsp; Interactions are:&nbsp; a.TASKS&nbsp; &nbsp;&nbsp; b. DET </label>--%>


            <div id="TSIIC_LAND_Select" runat="server" visible="false" style="padding-left: 40px">
                <table align="left">

                    <tr>
                        <td>
                            <label class="div-Content">Vacant Plots Available are as below:</label>

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
                        <td></td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px; padding-top: 7px; padding-bottom: 10px">
                            <asp:Label ID="landdesc" class="div-Content" runat="server"></asp:Label></td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList10" Font-Size="15px" runat="server" TabIndex="1" RepeatDirection="Horizontal">
                                <asp:ListItem Text="YES" Value="0" />
                                <asp:ListItem Text="NO" Value="1" />
                            </asp:RadioButtonList>

                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px; padding-top: 7px; padding-bottom: 10px">
                            <label class="div-Content">3b.Whether the applicant is interested to apply under TSIIC :</label></td>
                        <td>
                            <asp:RadioButtonList ID="rdtsiic" Font-Size="15px" runat="server" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdtsiic_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="YES" Value="0" />
                                <asp:ListItem Text="NO" Value="1" />
                            </asp:RadioButtonList>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left: 85px; padding-top: 7px; padding-bottom: 10px">
                            <div id="divtsiic" runat="server" visible="false">
                                <asp:LinkButton runat="server" ID="lkbtsiic" Visible="true" ForeColor="DarkGreen" Font-Bold="true" Text="Click To Send Link to the Applicant about TSIIC plots" OnClick="lkbtsiic_Click"></asp:LinkButton>
                                <%--click here <a href="https://www.db2021.telangana.gov.in/" target="_blank">DALITHA BANDHU</a> to know more about DALITHA BANDHU.--%>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />

            </div>
        </div>
        <div class="row" id="OTHERS" runat="server" style="width: 100%">
            <table>
                <tr>
                    <td>
                        <div style="margin-bottom: 7px;">
                            <label class="div-Content">15. Any other issue (Mention Here) :</label>
                        </div>
                    </td>
                    <td>
                        <div style="margin-bottom: 7px;">
                            <asp:TextBox ID="OTHER_ISSUES" autocomplete="off" oninput="validateInputText(this)" runat="server" TextMode="MultiLine" Width="400px" Height="40px" class="form-control" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />
        <div id="SUBMIT_CLEAR_BTNS" runat="server" class="row" align="center">
            <asp:Button ID="SubmitBtn" runat="server" Text="SUBMIT" BackColor="ForestGreen" Style=" color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="SubmitBtn_Click" />
            <asp:Button ID="PrintBtn" runat="server" Text="PRINT" Style="background-color: royalblue; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="PrintBtn_Click" Visible="false" />
            <asp:Button ID="ClearBtn" runat="server" Text="CLEAR" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="ClearBtn_Click" />
        </div>
        <br />


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

    <script type="text/javascript">
        function validatePhoneNumber() {
            var phoneNumber = document.getElementById("<%= Contact_Number_New.ClientID %>").value;
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
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".datetimepicker").datetimepicker({
                format: 'd-m-Y H:i A',
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
                dateFormat: 'd-m-yy',
                maxDate: 0
            });
        });
    </script>
</asp:Content>
