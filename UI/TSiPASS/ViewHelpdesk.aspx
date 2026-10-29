<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="ViewHelpdesk.aspx.cs" Inherits="Default3" Title="::TSiPASS TSiPASS   :: Helpdesk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<%--<script src="resources/scripts/PopUpCalenderLeft.js" type="text/javascript"></script>--%>
    <script language="javascript">



        function OpenPopup() {

            window.open("Lookups/MobilizationLookup.aspx", "List", "scrollbars=yes,resizable=yes,width=900,height=750");

            return false;
        }


        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>
    <style type="text/css">
        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
        <ProgressTemplate>
            <%--  <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
            <%-- <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />  <a href="HomeCommDashboard.aspx">Dashboard</a>
                              
                        </div>--%>
            <%-- </div>--%>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                   
                    <li class=""><i class="fa fa-fw fa-table"></i>Helpdesk Status </li>
                    <li class="active"><i class="fa fa-edit"></i>View Status </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    View Status</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                            width="100%">
                                            <tr>
                                                <td align="center" style="padding: 5px; vertical-align: top; text-align: center"
                                                    valign="middle">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table style="width: 96%;
                                                        height: 53px" width="80%">
                                                        <tr>
                                                            <td style="width: 50%; height: 80px" valign="top">
                                                                <table cellpadding="0" cellspacing="0" style="width: 50%">
                                                                    <tr>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="lbldeptname2" runat="server" CssClass="LBLBLACK" Text="Feedback Type"
                                                                                Width="110px"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 3%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Text=":" Width="2px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:DropDownList ID="ddlfeedbak" runat="server" CssClass="DROPDOWN" AutoPostBack="True"
                                                                                TabIndex="1" ToolTip="Please select the FeedBack" ValidationGroup="group" Width="150px"
                                                                                OnSelectedIndexChanged="ddlfeedbak_SelectedIndexChanged">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Text="NAME" Width="110px"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 3%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Text=":" Width="2px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:DropDownList ID="ddlPIA" runat="server" CssClass="DROPDOWN" AutoPostBack="True"
                                                                                TabIndex="1" ToolTip="Please Select PIA" ValidationGroup="group" Width="150px"
                                                                                OnSelectedIndexChanged="ddlPIA_SelectedIndexChanged">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Text="From" Width="110px"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 3%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Text=":" Width="2px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="40" Enabled="true" onkeypress="NumberOnly()" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                            <script type="text/javascript">
                                                                                function dateSelectionChanged(sender, args) {
                                                                                    selectedDate = sender.get_selectedDate();
                                                                                    /* replace this next line with your JS code to get the Sunday date */
                                                                                    sundayDate = getSundayDateUsingYourAlgorithm(selectedDate);
                                                                                    /* this sets the date on both the calendar and textbox */
                                                                                    sender.set_SelectedDate(sundayDate);
                                                                                }
                                                                            </script>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 50%; height: 80px" valign="top">
                                                                <table cellpadding="0" cellspacing="0" style="width: 50%; height: 40px">
                                                                    <tr>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 2%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="lbldeptname3" runat="server" CssClass="LBLBLACK" Text="      Status"
                                                                                Width="110px"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 2%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Text=":" Width="2px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 2%; padding-top: 5px; text-align: left">
                                                                            <asp:DropDownList ID="ddlstat" runat="server" CssClass="DROPDOWN" AutoPostBack="True"
                                                                                TabIndex="1" ToolTip="Please select the FeedBack" ValidationGroup="group" Width="150px"
                                                                                OnSelectedIndexChanged="ddlstat_SelectedIndexChanged">
                                                                                <asp:ListItem Value="Open">Open</asp:ListItem>
                                                                                <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                                                                <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 2%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Text="Reference No" Width="110px">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 2%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Text=":" Width="2px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 2%; padding-top: 5px; text-align: left">
                                                                            <asp:TextBox ID="txtrefno" runat="server" CssClass="TXTBOX" MaxLength="15" TabIndex="1"
                                                                                Width="150px" AutoPostBack="True" OnTextChanged="txtrefno_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Text="To" Width="110px"></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 3%; padding-top: 5px; text-align: left">
                                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Text=":" Width="2px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:TextBox ID="txtToDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="40" Enabled="true" onkeypress="NumberOnly()" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                                            <asp:Button ID="btnSearchHelpDesk" Visible="false" CssClass="btn btn-primary" Width="85px"
                                                                                Height="30px" runat="server" Text="SEARCH" OnClick="Button1_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%-- <asp:TextBox ID="txtPrno0" runat="server" AutoPostBack="True" CssClass="TXTBOX" 
                                                                                            MaxLength="30" onkeypress="CharbarOnly()" OnTextChanged="txtPrno_TextChanged" 
                                                                                            TabIndex="1" Width="130px"></asp:TextBox>--%>
                                                </td>
                                            </tr>
                                            <tr id="Tr1" runat="server">
                                                <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                    vertical-align: middle; padding-top: 5px; text-align: center" valign="middle">
                                                    <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" Visible="false" Font-Size="8pt"
                                                        ForeColor="Red" Width="270px"></asp:Label>
                                                    <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                        ForeColor="Green" Style="position: static"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Reject">
                                                <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                    valign="middle">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Close">
                                                <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                    valign="middle">
                                                    <table width="100%">
                                                        <asp:GridView ID="gvComplaintsList" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                                            BorderWidth="1px" CellPadding="4" Font-Names="Verdana" Font-Size="9pt" ForeColor="#333333"
                                                            OnSelectedIndexChanged="gvComplaintsList_SelectedIndexChanged" PageSize="30"
                                                            Width="98%" AllowPaging="false" DataKeyNames="int_fbid,Fb_Type,hd_desc,hd_uplddocname,Status"
                                                            OnPageIndexChanging="gvComplaintsList_PageIndexChanging" CssClass="TXTBOX" OnRowDataBound="gvComplaintsList_RowDataBound">
                                                            <HeaderStyle BackColor Height="40px" CssClass="GridviewScrollC1HeaderWrapblue" />
                                                            <RowStyle CssClass="GridviewScrollC1Item2blue" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pagerblue" />
                                                            <FooterStyle Height="40px" CssClass="GridviewScrollC1Headerblue" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2blue" />
                                                            <Columns>
                                                                <asp:HyperLinkField DataTextField="int_fbid" HeaderText="ID">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataTextField="hd_Code" HeaderText="Reference No">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:HyperLinkField>
                                                                <asp:BoundField DataField="UID_No" HeaderText="UID No">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                    <ControlStyle Width="50px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NameofIndustrialUnder" HeaderText="Unit Name">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Fb_Type" HeaderText="Feedback Type"></asp:BoundField>
                                                                <asp:BoundField DataField="hd_desc" HeaderText="User change Request/ Comments">
                                                                    <HeaderStyle HorizontalAlign="Left" Width="300px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
                                                                    <ControlStyle Width="450px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Uploaded Document">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("hd_uplddocname") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="hypLetter" runat="server" Target="_blank"> </asp:HyperLink>
                                                                        <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%#Eval("FilePath") %>' Target="_blank"></asp:HyperLink>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Status" HeaderText="Status">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks"></asp:BoundField>
                                                                <asp:BoundField DataField="regdate" HeaderText="Date of Reg'n">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="respdate" HeaderText="Date of Closure" />
                                                                <asp:TemplateField HeaderText="Change Status">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:RequiredFieldValidator ID="rfvVehicle0" runat="server" ControlToValidate="ddlVehicle"
                                                                            ErrorMessage="Please Select Vehicle" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                                        <asp:DropDownList ID="ddlVehicle" runat="server" CssClass="DROPDOWN" Width="82px">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 35%; height: 100%" cellspacing="0" cellpadding="2" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 100px; height: 45px; text-align: left" align="left">
                                                                                        <asp:DropDownList ID="ddlchStatus" runat="server" Width="152px" CssClass="DROPDOWN"
                                                                                            OnSelectedIndexChanged="ddlchStatus_SelectedIndexChanged" ValidationGroup="group">
                                                                                            <asp:ListItem>Open</asp:ListItem>
                                                                                            <asp:ListItem>Closed</asp:ListItem>
                                                                                            <asp:ListItem>Rejected</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Pending" runat="server">
                                                                                    <td style="width: 100px; height: 45px; text-align: left" align="left">
                                                                                        <asp:TextBox ID="txtremarks" TabIndex="1" runat="server" Width="150px" CssClass="TXTBOX"
                                                                                            ValidationGroup="group" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Close" runat="server">
                                                                                    <td style="padding-bottom: 5px; padding-top: 5px; text-align: center">
                                                                                        &nbsp;<asp:Button ID="BtnSave" TabIndex="10" OnClick="BtnSave_Click" runat="server"
                                                                                            Width="122px" Text="Change Status" CssClass="BUTTONLONG" ValidationGroup="group"
                                                                                            ToolTip="To Save  the data" Height="20px"></asp:Button>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="anothermailid" Visible="False" />
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <font color="red"><b>No Records Found</b></font>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </table>
                                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; vertical-align: middle; height: 35px; text-align: left"
                                                    valign="middle">
                                                    &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                    vertical-align: middle; padding-top: 5px; height: 35px; text-align: center" valign="middle">
                                                    &nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                                            ShowSummary="False" Style="position: static" ValidationGroup="group" />
                                        </td> </tr> </table>
                                        <asp:HiddenField ID="hdfusercode" runat="server" />
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>
<div class="overlay">

<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
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

              $("input[id$='txtFromDate']").datepicker(
                 {
                     dateFormat: "dd/mm/yy",
                     // maxDate: new Date(currentYear, currentMonth, currentDate)
                 }); // Will run at every postback/AsyncPostback

              $("input[id$='txtToDate']").datepicker(
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
              $("input[id$='txtFromDate']").datepicker(
                  {
                      //dateFormat: "dd/mm/yy",
                      dateFormat: "dd/mm/yy",
                     
                      //maxDate: new Date(currentYear, currentMonth, currentDate)
                  });
              $("input[id$='txtToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
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
